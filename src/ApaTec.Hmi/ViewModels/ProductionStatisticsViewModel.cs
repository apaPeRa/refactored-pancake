using ApaTec.Hmi.DesignData;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// HS-29 Produktionsstatistik: Balkendiagramm (HM-26) des gewaehlten Tages, Datumsleiste mit Pfeiltasten (HM-18). Die Pfeile aendern nur den Parameter <c>dayOffset</c>
/// (0 = heute bis 29, links = frueher, kein Verlaufseintrag). Reine Anzeige, keine Berechtigung, keine Funktionsleistentasten.
/// </summary>
[PageKey(PageKeys.ProductionStatistics)]
public sealed partial class ProductionStatisticsViewModel : PageViewModelBase
{
    /// <summary>Name des Seitenparameters (Navigation.md 5.1).</summary>
    public const string DayOffsetParameter = "dayOffset";

    private readonly IProductionStatisticsService _service;
    private readonly INavigationService? _navigation;
    private readonly ILocalizationService _localization;
    private CancellationTokenSource? _loadCts;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ShowEarlierDayCommand))]
    [NotifyCanExecuteChangedFor(nameof(ShowLaterDayCommand))]
    private int _dayOffset;

    [ObservableProperty]
    private string _dateText = string.Empty;

    [ObservableProperty]
    private IReadOnlyList<ChartPoint> _series = Array.Empty<ChartPoint>();

    [ObservableProperty]
    private IReadOnlyList<string> _xLabels = Array.Empty<string>();

    /// <summary>Zeigt "Lädt …", bis die Daten des neuen Tages vorliegen (K29-3).</summary>
    [ObservableProperty]
    private bool _isLoading;

    /// <summary>Entwurfsmodus: Beispielwerte des Bildes ohne Dienstaufruf.</summary>
    public ProductionStatisticsViewModel()
        : this(new DummyProductionStatisticsService(), null, LocalizationService.Instance)
    {
        ApplyDay(0, ProductionStatistics_DesignData.Today);
    }

    public ProductionStatisticsViewModel(IProductionStatisticsService service, INavigationService? navigation, ILocalizationService localization)
    {
        _service = service;
        _navigation = navigation;
        _localization = localization;
    }

    /// <summary>Balkenzahl der Datenreihe, mindestens 48 (Halbstunden, OP-29).</summary>
    public int MaxPoints => Math.Max(Series.Count, ProductionStatistics_DesignData.SlotCount);

    public override void OnNavigatedTo(object? parameter)
    {
        var offset = Math.Clamp(ReadOffset(parameter), 0, _service.HistoryDays - 1);
        DayOffset = offset;
        DateText = FormatDate(offset, DateTime.Today.AddDays(-offset));
        _ = LoadAsync(offset);
    }

    public override void OnNavigatedFrom()
    {
        _loadCts?.Cancel();
    }

    private static int ReadOffset(object? parameter) => parameter switch
    {
        NavigationParameters p => p.Get<int>(DayOffsetParameter),
        int i => i,
        _ => 0,
    };

    private string FormatDate(int offset, DateTime date) =>
        offset == 0 ? _localization.GetString("HS29_Today_Text") : date.ToString("d", _localization.Culture);

    private async Task LoadAsync(int offset)
    {
        _loadCts?.Cancel();
        var cts = new CancellationTokenSource();
        _loadCts = cts;
        IsLoading = true;
        try
        {
            var day = await _service.GetDayAsync(offset, cts.Token);
            if (!cts.IsCancellationRequested)
            {
                ApplyDay(offset, day);
            }
        }
        catch (OperationCanceledException)
        {
            // Ein neuerer Tageswechsel hat diesen Abruf abgeloest.
        }
        finally
        {
            if (!cts.IsCancellationRequested)
            {
                IsLoading = false;
            }
        }
    }

    // Ohne Daten bleibt die Reihe leer: HM-26 zeigt dann "Keine Daten" mit Symbol (K29-3).
    private void ApplyDay(int offset, ProductionDayStatistics? day)
    {
        IsLoading = false;
        if (day is null)
        {
            Series = Array.Empty<ChartPoint>();
            XLabels = Array.Empty<string>();
            DateText = FormatDate(offset, DateTime.Today.AddDays(-offset));
            OnPropertyChanged(nameof(MaxPoints));
            return;
        }

        var points = new List<ChartPoint>(day.Values.Count);
        var labels = new List<string>(day.Values.Count);
        for (var i = 0; i < day.Values.Count; i++)
        {
            var minutes = i * day.IntervalMinutes;
            var time = $"{minutes / 60}:{minutes % 60:00}";
            points.Add(new ChartPoint(time, day.Values[i]));
            labels.Add(minutes % 60 == 0 ? time : string.Empty);
        }

        Series = points;
        XLabels = labels;
        DateText = FormatDate(offset, day.Date);
        OnPropertyChanged(nameof(MaxPoints));
    }

    // Links = frueher: dayOffset steigt; am aeltesten Tag deaktiviert.
    [RelayCommand(CanExecute = nameof(CanShowEarlierDay))]
    private void ShowEarlierDay() => _navigation?.ReplaceParameter(new NavigationParameters(DayOffsetParameter, DayOffset + 1));

    private bool CanShowEarlierDay() => DayOffset < _service.HistoryDays - 1;

    // Rechts = spaeter; beim aktuellen Tag deaktiviert.
    [RelayCommand(CanExecute = nameof(CanShowLaterDay))]
    private void ShowLaterDay() => _navigation?.ReplaceParameter(new NavigationParameters(DayOffsetParameter, DayOffset - 1));

    private bool CanShowLaterDay() => DayOffset > 0;
}
