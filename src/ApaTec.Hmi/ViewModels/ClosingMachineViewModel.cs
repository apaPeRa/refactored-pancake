using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// HS-16 Schliessmaschine: Auslaufband (Sollgeschwindigkeit), Kopfleim (Ein/Aus, Nockenbeginn, Nockenende, Einschaltdauer) und Ruettlung (Ein/Aus, Ruettlung 1 und 2).
/// Eingaben gelten sofort nach "Uebernehmen" (S16-3). Navigation zu HS-07, HS-17 und HS-18 ueber die Funktionsleiste (A-37).
/// </summary>
[PageKey(PageKeys.ClosingMachine)]
public sealed partial class ClosingMachineViewModel : PageViewModelBase
{
    /// <summary>Dummy-Rolle fuer alle Felder mit Schluesselsymbol (OP-04, OP-25).</summary>
    private const UserRole RequiredRole = UserRole.Technician;

    private readonly IClosingMachineService _service;
    private readonly INavigationService? _navigation;
    private readonly IUserSession? _user;
    private readonly IDialogService? _dialogs;
    private readonly IMessageService? _messages;
    private readonly ILocalizationService _localization;

    [ObservableProperty]
    private bool _headGlueEnabled;

    [ObservableProperty]
    private bool _isHeadGluePending;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ShakerHintText))]
    private bool _shakerEnabled;

    [ObservableProperty]
    private bool _isShakerPending;

    [ObservableProperty]
    private bool _isAuthorized;

    [ObservableProperty]
    private bool _isEditingAllowed = true;

    /// <summary>Entwurfsmodus: Dummy-Dienste, keine Navigation.</summary>
    public ClosingMachineViewModel()
        : this(new DummyClosingMachineService(), null, new DummyUserSession(), null, null, LocalizationService.Instance)
    {
    }

    public ClosingMachineViewModel(
        IClosingMachineService service,
        INavigationService? navigation,
        IUserSession? user,
        IDialogService? dialogs,
        IMessageService? messages,
        ILocalizationService localization)
    {
        _service = service;
        _navigation = navigation;
        _user = user;
        _dialogs = dialogs;
        _messages = messages;
        _localization = localization;

        var settings = service.Settings;
        ConveyorSpeed = new ClosingEditableValue(ClosingField.ConveyorSpeed, settings.ConveyorSpeed, service.GetLimits(ClosingField.ConveyorSpeed));
        HeadGlueStart = new ClosingEditableValue(ClosingField.HeadGlueStart, settings.HeadGlueStart, service.GetLimits(ClosingField.HeadGlueStart));
        HeadGlueEnd = new ClosingEditableValue(ClosingField.HeadGlueEnd, settings.HeadGlueEnd, service.GetLimits(ClosingField.HeadGlueEnd));
        HeadGlueDuration = new ClosingEditableValue(ClosingField.HeadGlueDuration, settings.HeadGlueDuration, service.GetLimits(ClosingField.HeadGlueDuration));
        Shaker1 = new ClosingEditableValue(ClosingField.Shaker1, settings.Shaker1, service.GetLimits(ClosingField.Shaker1));
        Shaker2 = new ClosingEditableValue(ClosingField.Shaker2, settings.Shaker2, service.GetLimits(ClosingField.Shaker2));
        HeadGlueEnabled = settings.HeadGlueEnabled;
        ShakerEnabled = settings.ShakerEnabled;
        IsEditingAllowed = service.IsEditingAllowed;
        IsAuthorized = user?.HasRole(RequiredRole) ?? true;

        FunctionBarItems.Add(CreateBarItem("HS16_FunctionBar_GlueDevice", "Icon.Glue.Nozzle", PageKeys.HotGlueNordson));
        FunctionBarItems.Add(CreateBarItem("HS16_FunctionBar_Motor", "Icon.Motor.Screw", PageKeys.ClosingMotor));
        FunctionBarItems.Add(CreateBarItem("HS16_FunctionBar_WeightCorrection", "Icon.Weight.Scale", PageKeys.ClosingWeightCorrection));
    }

    /// <summary>E02 Sollgeschwindigkeit des Auslaufbands in %.</summary>
    public ClosingEditableValue ConveyorSpeed { get; }

    /// <summary>E06 Beginn der Nocke fuer den Kopfleim in Grad.</summary>
    public ClosingEditableValue HeadGlueStart { get; }

    /// <summary>E07 Ende der Nocke fuer den Kopfleim in Grad.</summary>
    public ClosingEditableValue HeadGlueEnd { get; }

    /// <summary>E08 Einschaltdauer des Ventils in ms.</summary>
    public ClosingEditableValue HeadGlueDuration { get; }

    /// <summary>E12 Intensitaet der Ruettlung 1 in %.</summary>
    public ClosingEditableValue Shaker1 { get; }

    /// <summary>E13 Intensitaet der Ruettlung 2 in %.</summary>
    public ClosingEditableValue Shaker2 { get; }

    /// <summary>E14 Hinweistext der Ruettlung; im Zustand Aus wird die Abschaltung benannt.</summary>
    public string ShakerHintText => _localization.GetString(ShakerEnabled ? "HS16_Shaker_Hint_On" : "HS16_Shaker_Hint_Off");

    public override void OnNavigatedTo(object? parameter)
    {
        Reload();
        if (_user is not null)
        {
            _user.SessionChanged += OnSessionChanged;
        }

        if (!IsEditingAllowed)
        {
            _messages?.ShowHint(_localization.GetString("HS16_Blocked_Hint"));
        }
    }

    public override void OnNavigatedFrom()
    {
        if (_user is not null)
        {
            _user.SessionChanged -= OnSessionChanged;
        }
    }

    [RelayCommand]
    private async Task NavigateAsync(string? pageKey)
    {
        if (pageKey is not null && _navigation is not null)
        {
            await _navigation.NavigateToAsync(pageKey);
        }
    }

    /// <summary>Antippen eines Eingabefelds: Berechtigung pruefen, Eingabe-Pop-up (HM-13) oeffnen, Wert uebernehmen.</summary>
    [RelayCommand]
    private async Task EditValueAsync(ClosingField field)
    {
        var item = FindValue(field);
        if (item is null || _dialogs is null)
        {
            return;
        }

        if (!await EnsureEditableAsync())
        {
            return;
        }

        item.IsEditing = true;
        try
        {
            var request = new ClosingInputRequest(_localization.GetString("HS16_Field_" + field), item.Value, item.Limits);
            var result = await _dialogs.ShowAsync<double?>(DialogKeys.Input, request);
            if (result.Accepted && result.Value is { } value)
            {
                await ApplyAsync(item, value);
            }
        }
        finally
        {
            item.IsEditing = false;
        }
    }

    [RelayCommand]
    private async Task ToggleHeadGlueAsync()
    {
        if (!await EnsureEditableAsync())
        {
            OnPropertyChanged(nameof(HeadGlueEnabled));
            return;
        }

        IsHeadGluePending = true;
        HeadGlueEnabled = !HeadGlueEnabled;
        await PersistAsync();
        IsHeadGluePending = false;
        OnPropertyChanged(nameof(HeadGlueEnabled));
    }

    [RelayCommand]
    private async Task ToggleShakerAsync()
    {
        if (!await EnsureEditableAsync())
        {
            OnPropertyChanged(nameof(ShakerEnabled));
            return;
        }

        IsShakerPending = true;
        ShakerEnabled = !ShakerEnabled;
        await PersistAsync();
        IsShakerPending = false;
        OnPropertyChanged(nameof(ShakerEnabled));
    }

    private FunctionBarItem CreateBarItem(string labelKey, string iconKey, string targetKey) => new()
    {
        Label = _localization.GetString(labelKey),
        IconKey = iconKey,
        Kind = FunctionBarItemKind.Action,
        Command = NavigateCommand,
        CommandParameter = targetKey,
        TargetId = targetKey,
    };

    private ClosingEditableValue? FindValue(ClosingField field) => field switch
    {
        ClosingField.ConveyorSpeed => ConveyorSpeed,
        ClosingField.HeadGlueStart => HeadGlueStart,
        ClosingField.HeadGlueEnd => HeadGlueEnd,
        ClosingField.HeadGlueDuration => HeadGlueDuration,
        ClosingField.Shaker1 => Shaker1,
        ClosingField.Shaker2 => Shaker2,
        _ => null,
    };

    /// <summary>Sperrzustand (Grund in der Meldezeile, A-28) und Berechtigung (Navigation.md 4.1: Hinweis, Benutzer-Pop-up) pruefen.</summary>
    private async Task<bool> EnsureEditableAsync()
    {
        if (!IsEditingAllowed)
        {
            _messages?.ShowHint(_localization.GetString("HS16_Blocked_Hint"));
            return false;
        }

        if (_user is null || _user.HasRole(RequiredRole))
        {
            return true;
        }

        _messages?.ShowHint(_localization.Format("Msg_PermissionRequired", _localization.GetString("HM01_Role_" + RequiredRole)));
        var granted = await _user.RequestRoleAsync(RequiredRole);
        IsAuthorized = _user.HasRole(RequiredRole);
        return granted && IsAuthorized;
    }

    private async Task ApplyAsync(ClosingEditableValue item, double value)
    {
        var limits = item.Limits;
        if (value < limits.Minimum || value > limits.Maximum)
        {
            item.ErrorText = _localization.Format("HS16_Error_Range", limits.Minimum, limits.Maximum, limits.Unit);
            return;
        }

        item.ErrorText = null;
        item.Value = value;
        await PersistAsync();
    }

    private Task PersistAsync() => _service.SetSettingsAsync(new ClosingMachineSettings(
        ConveyorSpeed.Value,
        HeadGlueEnabled,
        HeadGlueStart.Value,
        HeadGlueEnd.Value,
        HeadGlueDuration.Value,
        ShakerEnabled,
        Shaker1.Value,
        Shaker2.Value));

    private void Reload()
    {
        var settings = _service.Settings;
        ConveyorSpeed.Value = settings.ConveyorSpeed;
        HeadGlueStart.Value = settings.HeadGlueStart;
        HeadGlueEnd.Value = settings.HeadGlueEnd;
        HeadGlueDuration.Value = settings.HeadGlueDuration;
        Shaker1.Value = settings.Shaker1;
        Shaker2.Value = settings.Shaker2;
        HeadGlueEnabled = settings.HeadGlueEnabled;
        ShakerEnabled = settings.ShakerEnabled;
        IsEditingAllowed = _service.IsEditingAllowed;
        IsAuthorized = _user?.HasRole(RequiredRole) ?? true;
    }

    private void OnSessionChanged(object? sender, EventArgs e) => IsAuthorized = _user?.HasRole(RequiredRole) ?? true;
}
