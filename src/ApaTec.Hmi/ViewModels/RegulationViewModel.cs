using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>Parametersatz eines Dosierers (HM-35).</summary>
public sealed partial class RegulationBlockViewModel : ObservableObject
{
    private readonly RegulationViewModel _owner;
    private bool _loading;

    public RegulationBlockViewModel(RegulationViewModel owner, RegulationDoser doser, string title, RegulationSettings settings)
    {
        _owner = owner;
        Doser = doser;
        Title = title;
        Apply(settings);
    }

    public RegulationDoser Doser { get; }

    public string Title { get; }

    [ObservableProperty]
    private int _sampleCount;

    [ObservableProperty]
    private double _step;

    [ObservableProperty]
    private double _tolerance;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsAtLimit))]
    private double _maxCorrection;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsAtLimit))]
    [NotifyCanExecuteChangedFor(nameof(DecreaseCommand), nameof(IncreaseCommand))]
    private double _currentCorrection;

    [ObservableProperty]
    private double _mean;

    [ObservableProperty]
    private int _meanCount;

    [ObservableProperty]
    private bool _isRegulationOn;

    [ObservableProperty]
    private bool _isAuthorized = true;

    /// <summary>Korrektur am Limit (Betrag erreicht "Regulierung max"), S23-2.</summary>
    public bool IsAtLimit => Math.Abs(CurrentCorrection) >= MaxCorrection;

    internal void Apply(RegulationSettings s)
    {
        _loading = true;
        SampleCount = s.SampleCount;
        Step = s.Step;
        Tolerance = s.Tolerance;
        MaxCorrection = s.MaxCorrection;
        CurrentCorrection = s.CurrentCorrection;
        Mean = s.Mean;
        MeanCount = s.MeanCount;
        IsRegulationOn = s.IsRegulationOn;
        _loading = false;
    }

    internal RegulationSettings Snapshot() => new(SampleCount, Step, Tolerance, MaxCorrection, CurrentCorrection, Mean, MeanCount, IsRegulationOn);

    [RelayCommand]
    private Task ToggleAsync() => _owner.ToggleAsync(this);

    [RelayCommand(CanExecute = nameof(CanDecrease))]
    private Task DecreaseAsync() => _owner.AdjustAsync(this, -1);

    [RelayCommand(CanExecute = nameof(CanIncrease))]
    private Task IncreaseAsync() => _owner.AdjustAsync(this, 1);

    /// <summary>Parameter: Beschriftung des angetippten Feldes (HM-35 liefert keinen Feldbefehl, siehe Bericht).</summary>
    [RelayCommand]
    private Task EditFieldAsync(string? label) => _owner.EditFieldAsync(this, label);

    private bool CanDecrease() => CurrentCorrection > -MaxCorrection;

    private bool CanIncrease() => CurrentCorrection < MaxCorrection;

    partial void OnMaxCorrectionChanged(double value)
    {
        if (!_loading)
        {
            DecreaseCommand.NotifyCanExecuteChanged();
            IncreaseCommand.NotifyCanExecuteChanged();
        }
    }
}

/// <summary>HS-23 Regulierung: zwei gleich aufgebaute Parametersaetze (Hauptdosierer, Nachdosierer); Funktionsleiste leer.</summary>
[PageKey(PageKeys.Regulation)]
public sealed partial class RegulationViewModel : PageViewModelBase
{
    /// <summary>Dummy-Rolle fuer alle Felder und Tasten mit Schluessel (OP-25).</summary>
    private const UserRole RequiredRole = UserRole.Technician;

    private readonly IRegulationService _service;
    private readonly IUserSession? _user;
    private readonly IDialogService? _dialogs;
    private readonly IMessageService? _messages;
    private readonly ILocalizationService _localization;

    public RegulationViewModel()
        : this(new DummyRegulationService(), new DummyUserSession(), null, null, LocalizationService.Instance)
    {
    }

    public RegulationViewModel(IRegulationService service, IUserSession? user, IDialogService? dialogs, IMessageService? messages, ILocalizationService localization)
    {
        _service = service;
        _user = user;
        _dialogs = dialogs;
        _messages = messages;
        _localization = localization;
        Main = new RegulationBlockViewModel(this, RegulationDoser.Main, localization.GetString("HS23_Main_Title"), service.GetSettings(RegulationDoser.Main));
        Post = new RegulationBlockViewModel(this, RegulationDoser.Post, localization.GetString("HS23_Post_Title"), service.GetSettings(RegulationDoser.Post));
        UpdateAuthorization();
    }

    public RegulationBlockViewModel Main { get; }

    public RegulationBlockViewModel Post { get; }

    public override void OnNavigatedTo(object? parameter)
    {
        Main.Apply(_service.GetSettings(RegulationDoser.Main));
        Post.Apply(_service.GetSettings(RegulationDoser.Post));
        if (_user is not null)
        {
            _user.SessionChanged += OnSessionChanged;
        }

        UpdateAuthorization();
    }

    public override void OnNavigatedFrom()
    {
        if (_user is not null)
        {
            _user.SessionChanged -= OnSessionChanged;
        }
    }

    internal async Task ToggleAsync(RegulationBlockViewModel block)
    {
        var desired = block.IsRegulationOn;
        if (!await EnsureAuthorizedAsync())
        {
            block.IsRegulationOn = !desired;
            return;
        }

        block.Apply(await _service.SetEnabledAsync(block.Doser, desired));
    }

    internal async Task AdjustAsync(RegulationBlockViewModel block, int direction)
    {
        if (!await EnsureAuthorizedAsync())
        {
            return;
        }

        block.Apply(await _service.AdjustCorrectionAsync(block.Doser, direction));
    }

    internal async Task EditFieldAsync(RegulationBlockViewModel block, string? label)
    {
        if (_dialogs is null || FieldOf(label) is not { } field || !await EnsureAuthorizedAsync())
        {
            return;
        }

        var limits = _service.GetLimits(field);
        var current = field switch
        {
            RegulationField.SampleCount => block.SampleCount,
            RegulationField.Step => block.Step,
            RegulationField.Tolerance => block.Tolerance,
            RegulationField.MaxCorrection => block.MaxCorrection,
            _ => block.CurrentCorrection,
        };
        var unitKey = field switch
        {
            RegulationField.SampleCount => "HS23_Unit_Pieces",
            RegulationField.Step => "HS23_Unit_Percent",
            _ => "HS23_Unit_Gram",
        };
        var title = _localization.Format("HS23_Input_Title", label ?? string.Empty, block.Title);
        var request = new MachineInputRequest(title, current, _localization.GetString(unitKey), field == RegulationField.SampleCount ? 0 : 1, limits, InputKind.Number);
        var result = await _dialogs.ShowAsync<double?>(DialogKeys.Input, request);
        if (!result.Accepted || result.Value is not { } value)
        {
            return;
        }

        if (value < limits.Minimum || value > limits.Maximum)
        {
            _messages?.ShowHint(_localization.Format("HS23_Input_Range", limits.Minimum, limits.Maximum));
            return;
        }

        var updated = await _service.SetValueAsync(block.Doser, field, value);
        block.Apply(updated with { Mean = block.Mean, MeanCount = block.MeanCount });
    }

    private RegulationField? FieldOf(string? label)
    {
        if (label is null)
        {
            return null;
        }

        var map = new (string Key, RegulationField Field)[]
        {
            ("HM35_SampleCount_Label", RegulationField.SampleCount),
            ("HM35_Step_Label", RegulationField.Step),
            ("HM35_Tolerance_Label", RegulationField.Tolerance),
            ("HM35_MaxCorrection_Label", RegulationField.MaxCorrection),
            ("HM35_CurrentCorrection_Label", RegulationField.CurrentCorrection),
        };
        foreach (var (key, field) in map)
        {
            if (string.Equals(_localization.GetString(key), label, StringComparison.Ordinal))
            {
                return field;
            }
        }

        return null;
    }

    private async Task<bool> EnsureAuthorizedAsync()
    {
        if (_user is null || _user.HasRole(RequiredRole))
        {
            return true;
        }

        _messages?.ShowHint(_localization.Format("Msg_PermissionRequired", _localization.GetString("Role_" + RequiredRole)));
        return await _user.RequestRoleAsync(RequiredRole);
    }

    private void UpdateAuthorization()
    {
        var allowed = _user?.HasRole(RequiredRole) ?? true;
        Main.IsAuthorized = allowed;
        Post.IsAuthorized = allowed;
    }

    private void OnSessionChanged(object? sender, EventArgs e) => UpdateAuthorization();
}
