using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// Ein Schneckendosierer fuer HS-41 (Karte HM-20), HS-11 und HS-19 (Detail): Werte, Anwahlen, Status und Befehle. Schreibt ueber <see cref="IDoserService"/>;
/// <see cref="Refresh"/> uebernimmt den Stand des Dienstes. Keine UI-Referenzen.
/// </summary>
public sealed partial class DoserItemViewModel : ObservableObject
{
    private readonly IDoserService _service;
    private readonly DosingInteraction _interaction;
    private readonly ILocalizationService _localization;
    private readonly Func<DoserId, Task>? _openDetail;
    private bool _isSyncing;

    [ObservableProperty]
    private double _targetPercent;

    [ObservableProperty]
    private double _targetWeight;

    [ObservableProperty]
    private double _maxRefill;

    [ObservableProperty]
    private double _currentRefill;

    [ObservableProperty]
    private RefillResult _refillResult;

    [ObservableProperty]
    private double _regulationValue;

    [ObservableProperty]
    private double _calibrationRevolutions;

    [ObservableProperty]
    private double _calibrationWeight;

    [ObservableProperty]
    private double _screwSpeed;

    [ObservableProperty]
    private double _agitatorPercent;

    [ObservableProperty]
    private double _agitatorRunOn;

    [ObservableProperty]
    private double _crossScrewPercent;

    [ObservableProperty]
    private LedState _hopperUpper;

    [ObservableProperty]
    private LedState _hopperLower;

    [ObservableProperty]
    private double _load;

    [ObservableProperty]
    private bool _crossScrewEnabled;

    [ObservableProperty]
    private bool _agitatorEnabled;

    [ObservableProperty]
    private bool _regulationEnabled;

    [ObservableProperty]
    private bool _isEmptying;

    [ObservableProperty]
    private bool _isSelected;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ManualCommand), nameof(ToggleEmptyingCommand), nameof(CalibrateCommand), nameof(ShowBlockedHintCommand))]
    private bool _actionsAllowed = true;

    [ObservableProperty]
    private bool _isAuthorized = true;

    public DoserItemViewModel(DoserId id, IDoserService service, DosingInteraction interaction, ILocalizationService localization, Func<DoserId, Task>? openDetail = null)
    {
        Id = id;
        _service = service;
        _interaction = interaction;
        _localization = localization;
        _openDetail = openDetail;
        Refresh();
    }

    public DoserId Id { get; }

    public bool IsPost => Id == DoserId.Post;

    public DoserKind DoserKind => IsPost ? DoserKind.Secondary : DoserKind.Main;

    /// <summary>"Hauptdosierer 1", "Hauptdosierer 2" bzw. "Nachdosierer".</summary>
    public string Title => IsPost
        ? _localization.GetString("Dosing_PostDoser_Title")
        : _localization.Format("Dosing_MainDoser_Title", (int)Id);

    /// <summary>Kennung fuer den Brotkruemel ("HD1", "HD2", "ND").</summary>
    public string ShortName => IsPost
        ? _localization.GetString("Dosing_DoserName_Post")
        : _localization.Format("Dosing_DoserName_Main", (int)Id);

    public DoserFieldErrors Errors { get; } = new();

    /// <summary>Uebernimmt den aktuellen Stand des Dienstes.</summary>
    public void Refresh()
    {
        var s = _service.GetDoser(Id);
        _isSyncing = true;
        try
        {
            TargetPercent = s.TargetPercent;
            TargetWeight = s.TargetWeight;
            MaxRefill = s.MaxRefill;
            CurrentRefill = s.CurrentRefill;
            RefillResult = s.RefillResult switch
            {
                DoserRefillResult.Dosed => RefillResult.Dosed,
                DoserRefillResult.RejectedTooMuch => RefillResult.RejectedTooMuch,
                _ => RefillResult.None,
            };
            RegulationValue = s.RegulationValue;
            CalibrationRevolutions = s.CalibrationRevolutions;
            CalibrationWeight = s.CalibrationWeight;
            ScrewSpeed = s.ScrewSpeed;
            AgitatorPercent = s.AgitatorPercent;
            AgitatorRunOn = s.AgitatorRunOn;
            CrossScrewPercent = s.CrossScrewPercent;
            HopperUpper = s.HopperUpper switch
            {
                DoserHopperState.ProductPresent => LedState.On,
                DoserHopperState.NoProduct => LedState.Off,
                _ => LedState.Unknown,
            };
            HopperLower = s.HopperLower switch
            {
                DoserHopperState.ProductPresent => LedState.On,
                DoserHopperState.NoProduct => LedState.Error,
                _ => LedState.Unknown,
            };
            Load = s.Load;
            CrossScrewEnabled = s.CrossScrewEnabled;
            AgitatorEnabled = s.AgitatorEnabled;
            RegulationEnabled = s.RegulationEnabled;
            IsEmptying = s.IsEmptying;
            IsSelected = s.IsSelected;
            ActionsAllowed = s.ActionsAllowed;
            IsAuthorized = _interaction.IsAuthorized;
        }
        finally
        {
            _isSyncing = false;
        }
    }

    partial void OnCrossScrewEnabledChanged(bool value) => SwitchChanged(DoserSwitch.CrossScrew, value, true, v => CrossScrewEnabled = v);

    partial void OnAgitatorEnabledChanged(bool value) => SwitchChanged(DoserSwitch.Agitator, value, true, v => AgitatorEnabled = v);

    partial void OnRegulationEnabledChanged(bool value) => SwitchChanged(DoserSwitch.Regulation, value, false, v => RegulationEnabled = v);

    private void SwitchChanged(DoserSwitch which, bool desired, bool needsPermission, Action<bool> setLocal)
    {
        if (!_isSyncing)
        {
            _ = ApplySwitchAsync(which, desired, needsPermission, setLocal);
        }
    }

    private async Task ApplySwitchAsync(DoserSwitch which, bool desired, bool needsPermission, Action<bool> setLocal)
    {
        if (needsPermission && !_interaction.IsAuthorized)
        {
            SetSilently(() => setLocal(!desired));
            if (!await _interaction.EnsureAuthorizedAsync())
            {
                return;
            }

            SetSilently(() => setLocal(desired));
        }

        await _service.SetSwitchAsync(Id, which, desired);
    }

    private void SetSilently(Action action)
    {
        var old = _isSyncing;
        _isSyncing = true;
        try
        {
            action();
        }
        finally
        {
            _isSyncing = old;
        }
    }

    /// <summary>Antippen eines Eingabefelds (HM-12): Berechtigung, Eingabe-Pop-up (HM-13), Grenzen pruefen, Schreiben.</summary>
    [RelayCommand]
    private async Task EditFieldAsync(DoserField field)
    {
        var value = await _interaction.RequestValueAsync(field, _localization.GetString("Dosing_Field_" + field + "_Title"), CurrentValue(field), HelpKey(field));
        if (value is not { } v)
        {
            return;
        }

        var limits = _service.GetLimits(field);
        if (v < limits.Minimum || v > limits.Maximum)
        {
            Errors.Set(field.ToString(), _localization.Format("Dosing_OutOfRange_Text", limits.Minimum, limits.Maximum, limits.Unit));
            return;
        }

        try
        {
            await _service.SetValueAsync(Id, field, v);
            Errors.Set(field.ToString(), null);
        }
        catch (Exception)
        {
            Errors.Set(field.ToString(), _localization.GetString("Dosing_WriteFailed_Text"));
        }
    }

    private string HelpKey(DoserField field) =>
        field == DoserField.RegulationValue && IsPost ? "Dosing_Field_RegulationValuePost_Help" : "Dosing_Field_" + field + "_Help";

    private double CurrentValue(DoserField field) => field switch
    {
        DoserField.TargetPercent => TargetPercent,
        DoserField.TargetWeight => TargetWeight,
        DoserField.MaxRefill => MaxRefill,
        DoserField.RegulationValue => RegulationValue,
        DoserField.CalibrationRevolutions => CalibrationRevolutions,
        DoserField.CalibrationWeight => CalibrationWeight,
        DoserField.ScrewSpeed => ScrewSpeed,
        DoserField.AgitatorPercent => AgitatorPercent,
        DoserField.AgitatorRunOn => AgitatorRunOn,
        DoserField.CrossScrewPercent => CrossScrewPercent,
        _ => 0,
    };

    private bool CanOperate() => ActionsAllowed;

    private bool CanShowBlockedHint() => !ActionsAllowed;

    /// <summary>"Manuell": Anforderung eines Dosiervorgangs (Antippen).</summary>
    [RelayCommand(CanExecute = nameof(CanOperate))]
    private async Task ManualAsync()
    {
        if (await _interaction.EnsureAuthorizedAsync())
        {
            await _service.TriggerManualAsync(Id);
        }
    }

    /// <summary>"Entleeren": Dauerfunktion; erneutes Antippen bricht ab (S11-8).</summary>
    [RelayCommand(CanExecute = nameof(CanOperate))]
    private async Task ToggleEmptyingAsync()
    {
        if (await _interaction.EnsureAuthorizedAsync())
        {
            await _service.SetEmptyingAsync(Id, !IsEmptying);
        }
    }

    /// <summary>"Eichdosierung": Dosiervorgang mit den Umdrehungen aus dem Feld.</summary>
    [RelayCommand(CanExecute = nameof(CanOperate))]
    private async Task CalibrateAsync()
    {
        if (await _interaction.EnsureAuthorizedAsync())
        {
            await _service.StartCalibrationAsync(Id);
        }
    }

    /// <summary>Antippen einer gesperrten Taste nennt den Grund in der Meldezeile (A-28).</summary>
    [RelayCommand(CanExecute = nameof(CanShowBlockedHint))]
    private void ShowBlockedHint() => _interaction.ShowBlockedHint();

    /// <summary>Detail-Symbol der Karte (HS-41): oeffnet HS-11 bzw. HS-19.</summary>
    [RelayCommand]
    private Task OpenDetailAsync() => _openDetail?.Invoke(Id) ?? Task.CompletedTask;
}
