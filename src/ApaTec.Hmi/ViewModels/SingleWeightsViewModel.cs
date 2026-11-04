using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// HS-14 Einzelgewichte (Einstellung > Waagen > Kontrollwaage > Einzelgewichte): Standardabweichung, Mittelwert, Anzahl und das Wertegitter mit 50 Zellen (HM-37).
/// Funktionsleiste: Umschalter "Einzel / Fortlaufend" (Zustandstaste) und "Start" (im Modus Einzel mit Bestaetigung vor dem Loeschen, S14-2).
/// </summary>
[PageKey(PageKeys.SingleWeights)]
public sealed partial class SingleWeightsViewModel : PageViewModelBase
{
    private readonly IScaleService _scales;
    private readonly IDialogService? _dialogs;
    private readonly IMessageService? _messages;
    private readonly ILocalizationService _loc;
    private readonly FunctionBarItem _modeItem;
    private readonly FunctionBarItem _startItem;
    private SynchronizationContext? _context;
    private bool _isModeChanging;

    public SingleWeightsViewModel(
        IScaleService scales,
        IDialogService? dialogs,
        IMessageService? messages,
        ILocalizationService loc)
    {
        _scales = scales;
        _dialogs = dialogs;
        _messages = messages;
        _loc = loc;

        _modeItem = new FunctionBarItem { Kind = FunctionBarItemKind.State, Command = ToggleModeCommand };
        _startItem = new FunctionBarItem
        {
            Label = loc.GetString("HS14_Start_Label"),
            Kind = FunctionBarItemKind.Action,
            Command = StartCommand,
        };
        FunctionBarItems.Add(_modeItem);
        FunctionBarItems.Add(_startItem);

        Refresh();
    }

    /// <summary>Entwurfsmodus (DesignData): Dummy-Dienste, keine Pop-ups.</summary>
    public SingleWeightsViewModel()
        : this(new DummyScaleService(), null, null, LocalizationService.Instance)
    {
    }

    /// <summary>Anzahl zu erfassender Werte (Maximum 50); die Kachel "Anzahl" zeigt diesen Wert (Annahme S14-1).</summary>
    [ObservableProperty]
    private int _capacity = 50;

    [ObservableProperty]
    private double? _mean;

    [ObservableProperty]
    private double? _stdDev;

    [ObservableProperty]
    private IReadOnlyList<WeightCell> _cells = Array.Empty<WeightCell>();

    [ObservableProperty]
    private int _lastIndex = -1;

    [ObservableProperty]
    private SamplingMode _mode = SamplingMode.Continuous;

    /// <summary>Messreihe enthaelt mindestens einen Wert.</summary>
    [ObservableProperty]
    private bool _hasValues;

    public override void OnNavigatedTo(object? parameter)
    {
        _context = SynchronizationContext.Current;
        _scales.Changed += OnServiceChanged;
        Refresh();
    }

    public override void OnNavigatedFrom()
    {
        _scales.Changed -= OnServiceChanged;
    }

    private void OnServiceChanged(object? sender, EventArgs e)
    {
        if (_context is null || SynchronizationContext.Current == _context)
        {
            Refresh();
        }
        else
        {
            _context.Post(_ => Refresh(), null);
        }
    }

    private void Refresh()
    {
        var series = _scales.GetSingleWeights();
        Capacity = series.Capacity;
        Mean = series.Mean;
        StdDev = series.StdDev;
        LastIndex = series.LastIndex;
        Mode = series.IsContinuous ? SamplingMode.Continuous : SamplingMode.Single;
        HasValues = series.Samples.Any(s => s is not null);
        Cells = series.Samples
            .Select((sample, index) => new WeightCell
            {
                Weight = sample?.Weight,
                Quality = sample is null ? WeightQuality.Unknown : (sample.IsGood ? WeightQuality.Good : WeightQuality.Bad),
                IsLast = sample is not null && index == series.LastIndex,
            })
            .ToList();
        if (!_isModeChanging)
        {
            ApplyModeItem(series.IsContinuous);
        }
    }

    private void ApplyModeItem(bool continuous)
    {
        var word = _loc.GetString(continuous ? "HS14_Mode_Continuous" : "HS14_Mode_Single");
        _modeItem.Label = _loc.Format("HS14_Mode_Format", word);
        _modeItem.IconKey = continuous ? "Icon.State.On" : "Icon.State.Off";
        _modeItem.IsActive = continuous;
    }

    [RelayCommand]
    private async Task ToggleModeAsync()
    {
        var target = Mode != SamplingMode.Continuous;
        _isModeChanging = true;
        _modeItem.IsEnabled = false;
        _modeItem.IconKey = "Icon.State.Pending";
        _modeItem.Label = _loc.Format("HS14_Mode_Format", _loc.GetString("HS14_Mode_Pending"));
        try
        {
            await _scales.SetSamplingModeAsync(target);
        }
        catch (Exception)
        {
            _modeItem.IconKey = "Icon.Status.Error";
            _modeItem.Label = _loc.Format("HS14_Mode_Format", _loc.GetString("HS14_Mode_Error"));
            _messages?.ShowHint(_loc.GetString("HS14_Mode_Error"));
            _modeItem.IsEnabled = true;
            _isModeChanging = false;
            return;
        }

        _modeItem.IsEnabled = true;
        _isModeChanging = false;
        Refresh();
    }

    [RelayCommand]
    private async Task StartAsync()
    {
        if (Mode == SamplingMode.Single && HasValues && _dialogs is not null)
        {
            var request = new NavigationParameters("title", _loc.GetString("HS14_Start_Title")).With("text", _loc.GetString("HS14_Start_Text"));
            var result = await _dialogs.ShowAsync<bool>(DialogKeys.Confirmation, request);
            if (!result.Accepted)
            {
                return;
            }
        }

        await _scales.StartSamplingAsync();
        Refresh();
    }
}
