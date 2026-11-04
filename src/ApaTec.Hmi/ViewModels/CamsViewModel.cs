using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// HS-25 Nocken: Nockennummer, Anfang/Ende (Winkel, Zeit, Ergebnis), Position/Status, Typ, Geber, Bezeichnung, "Werte schreiben".
/// Funktionsleiste: "«", "Uebersicht", "»". Blaettern ersetzt nur den Parameter <c>camNumber</c>. Aenderungen gelten erst nach dem Schreiben.
/// </summary>
[PageKey(PageKeys.Cams)]
public sealed partial class CamsViewModel : PageViewModelBase
{
    /// <summary>Dummy-Rolle fuer Felder mit Schluessel (OP-25).</summary>
    private const UserRole RequiredRole = UserRole.Technician;

    private readonly ICamService _service;
    private readonly INavigationService? _navigation;
    private readonly IUserSession? _user;
    private readonly IDialogService? _dialogs;
    private readonly IMessageService? _messages;
    private readonly ILocalizationService _localization;
    private readonly FunctionBarItem _previousItem = new();
    private readonly FunctionBarItem _nextItem = new();
    private readonly SynchronizationContext? _context = SynchronizationContext.Current;
    private CamDetail _baseline;
    private bool _loading;
    private bool _subscribed;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(NumberText), nameof(PositionText))]
    [NotifyCanExecuteChangedFor(nameof(PreviousCamCommand), nameof(NextCamCommand))]
    private int _camNumber;

    [ObservableProperty]
    private double? _startAngle;

    [ObservableProperty]
    private double? _startTime;

    [ObservableProperty]
    private double? _startResult;

    [ObservableProperty]
    private double? _endAngle;

    [ObservableProperty]
    private double? _endTime;

    [ObservableProperty]
    private double? _endResult;

    [ObservableProperty]
    private double? _camType;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(EncoderName))]
    private int _encoderIndex;

    [ObservableProperty]
    private string? _designation;

    [ObservableProperty]
    private double? _encoderPosition;

    [ObservableProperty]
    private LedState _statusLed;

    [ObservableProperty]
    private string _statusText = string.Empty;

    [ObservableProperty]
    private bool _isAuthorized = true;

    public CamsViewModel()
        : this(new DummyCamService(), null, new DummyUserSession(), null, null, LocalizationService.Instance)
    {
    }

    public CamsViewModel(ICamService service, INavigationService? navigation, IUserSession? user, IDialogService? dialogs, IMessageService? messages, ILocalizationService localization)
    {
        _service = service;
        _navigation = navigation;
        _user = user;
        _dialogs = dialogs;
        _messages = messages;
        _localization = localization;
        _baseline = service.GetDetail(12);

        _previousItem.Label = localization.GetString("HS25_Bar_Previous");
        _previousItem.Kind = FunctionBarItemKind.Paging;
        _previousItem.Command = PreviousCamCommand;
        _nextItem.Label = localization.GetString("HS25_Bar_Next");
        _nextItem.Kind = FunctionBarItemKind.Paging;
        _nextItem.Command = NextCamCommand;
        FunctionBarItems.Add(_previousItem);
        FunctionBarItems.Add(new FunctionBarItem
        {
            Label = localization.GetString("HS25_Bar_Overview"),
            IconKey = "Icon.List",
            Command = OpenOverviewCommand,
            TargetId = PageKeys.CamOverview,
        });
        FunctionBarItems.Add(_nextItem);

        Load(_baseline.Number);
        UpdateAuthorization();
    }

    public string NumberText => CamNumber.ToString(_localization.Culture);

    /// <summary>Positionsanzeige "n von m" (Nocke in der Reihenfolge der Nockennummern).</summary>
    public string PositionText => _localization.Format("HS25_Position_Text", CamNumber - _service.FirstNumber + 1, _service.LastNumber - _service.FirstNumber + 1);

    public string EncoderName => _service.EncoderNames.Count > EncoderIndex && EncoderIndex >= 0 ? _service.EncoderNames[EncoderIndex] : string.Empty;

    public bool HasChanges => IsStartPending || IsEndPending || IsTypePending || IsEncoderPending || IsDesignationPending;

    public bool IsStartPending => !_loading && (StartAngle != _baseline.StartAngle || StartTime != _baseline.StartTime);

    public bool IsEndPending => !_loading && (EndAngle != _baseline.EndAngle || EndTime != _baseline.EndTime);

    public bool IsTypePending => !_loading && CamType != _baseline.CamType;

    public bool IsEncoderPending => !_loading && EncoderIndex != _baseline.EncoderIndex;

    public bool IsDesignationPending => !_loading && !string.Equals(Designation, _baseline.Designation, StringComparison.Ordinal);

    public override void OnNavigatedTo(object? parameter)
    {
        var number = parameter is NavigationParameters p && p.Get<int>("camNumber") is var n and > 0 ? n : _baseline.Number;
        Load(Math.Clamp(number, _service.FirstNumber, _service.LastNumber));
        Subscribe();
        UpdateAuthorization();
    }

    public override void OnNavigatedFrom() => Unsubscribe();

    /// <summary>Ungeschriebene Aenderungen: Zurueck, Seitenleiste, Brotkruemel und Home fragen "Aenderungen verwerfen?" (S25-2).</summary>
    public override bool HasLeaveGuard => HasChanges;

    public override Task<bool> CanLeaveAsync() => ConfirmDiscardAsync();

    // Doppelabo-Schutz: OnNavigatedTo laeuft auch beim Blaettern (ReplaceParameter).
    private void Subscribe()
    {
        Unsubscribe();
        _subscribed = true;
        if (_user is not null)
        {
            _user.SessionChanged += OnSessionChanged;
        }

        _service.Changed += OnServiceChanged;
    }

    private void Unsubscribe()
    {
        if (!_subscribed)
        {
            return;
        }

        _subscribed = false;
        if (_user is not null)
        {
            _user.SessionChanged -= OnSessionChanged;
        }

        _service.Changed -= OnServiceChanged;
    }

    private void OnServiceChanged(object? sender, EventArgs e)
    {
        if (_context is null || SynchronizationContext.Current == _context)
        {
            RefreshLive();
        }
        else
        {
            _context.Post(_ => RefreshLive(), null);
        }
    }

    // Position und Status laufend aktualisieren, ohne eingegebene (ungeschriebene) Werte anzufassen.
    private void RefreshLive()
    {
        if (!_subscribed)
        {
            return;
        }

        var live = _service.GetLive(Current());
        EncoderPosition = live.Position;
        StatusLed = live.IsInside ? LedState.On : LedState.Off;
        StatusText = _localization.GetString(live.IsInside ? "HS25_Status_Inside" : "HS25_Status_Outside");
    }

    partial void OnStartAngleChanged(double? value) => OnFieldChanged();

    partial void OnStartTimeChanged(double? value) => OnFieldChanged();

    partial void OnEndAngleChanged(double? value) => OnFieldChanged();

    partial void OnEndTimeChanged(double? value) => OnFieldChanged();

    partial void OnCamTypeChanged(double? value) => OnFieldChanged();

    partial void OnEncoderIndexChanged(int value) => OnFieldChanged();

    partial void OnDesignationChanged(string? value) => OnFieldChanged();

    private void OnFieldChanged()
    {
        if (_loading)
        {
            return;
        }

        StartResult = _service.CalculateResult(StartAngle ?? 0, StartTime ?? 0);
        EndResult = _service.CalculateResult(EndAngle ?? 0, EndTime ?? 0);
        RefreshPending();
    }

    private void RefreshPending()
    {
        OnPropertyChanged(nameof(IsStartPending));
        OnPropertyChanged(nameof(IsEndPending));
        OnPropertyChanged(nameof(IsTypePending));
        OnPropertyChanged(nameof(IsEncoderPending));
        OnPropertyChanged(nameof(IsDesignationPending));
        OnPropertyChanged(nameof(HasChanges));
    }

    private void Load(int number)
    {
        _loading = true;
        var d = _service.GetDetail(number);
        _baseline = d;
        CamNumber = d.Number;
        StartAngle = d.StartAngle;
        StartTime = d.StartTime;
        EndAngle = d.EndAngle;
        EndTime = d.EndTime;
        CamType = d.CamType;
        EncoderIndex = d.EncoderIndex;
        Designation = d.Designation;
        StartResult = _service.CalculateResult(d.StartAngle, d.StartTime);
        EndResult = _service.CalculateResult(d.EndAngle, d.EndTime);
        var live = _service.GetLive(d);
        EncoderPosition = live.Position;
        StatusLed = live.IsInside ? LedState.On : LedState.Off;
        StatusText = _localization.GetString(live.IsInside ? "HS25_Status_Inside" : "HS25_Status_Outside");
        _loading = false;
        RefreshPending();
        _previousItem.IsEnabled = CamNumber > _service.FirstNumber;
        _nextItem.IsEnabled = CamNumber < _service.LastNumber;
    }

    private CamDetail Current() => new(CamNumber, StartAngle ?? 0, StartTime ?? 0, EndAngle ?? 0, EndTime ?? 0, (int)(CamType ?? 0), EncoderIndex, Designation ?? string.Empty);

    [RelayCommand(CanExecute = nameof(CanGoPrevious))]
    private Task PreviousCamAsync() => GoToCamAsync(CamNumber - 1);

    [RelayCommand(CanExecute = nameof(CanGoNext))]
    private Task NextCamAsync() => GoToCamAsync(CamNumber + 1);

    private bool CanGoPrevious() => CamNumber > _service.FirstNumber;

    private bool CanGoNext() => CamNumber < _service.LastNumber;

    private async Task GoToCamAsync(int number)
    {
        if (number < _service.FirstNumber || number > _service.LastNumber || !await ConfirmDiscardAsync())
        {
            return;
        }

        if (_navigation is null)
        {
            Load(number);
        }
        else
        {
            _navigation.ReplaceParameter(new NavigationParameters("camNumber", number));
        }
    }

    [RelayCommand]
    private async Task OpenOverviewAsync()
    {
        if (_navigation is not null)
        {
            // Die Rueckfrage "Aenderungen verwerfen?" stellt der Navigationsdienst ueber den Leave-Hook.
            await _navigation.NavigateToAsync(PageKeys.CamOverview, new NavigationParameters("camNumber", CamNumber));
        }
    }

    /// <summary>Direkteingabe der Nockennummer (S25-1); unbekannte Nummer: Hinweis, keine Uebernahme.</summary>
    [RelayCommand]
    private async Task EditNumberAsync()
    {
        if (_dialogs is null)
        {
            return;
        }

        var limits = _service.GetLimits(CamField.Number);
        var request = new MachineInputRequest(_localization.GetString("HS25_Number_Title"), CamNumber, string.Empty, 0, limits, InputKind.Number);
        var result = await _dialogs.ShowAsync<double?>(DialogKeys.Input, request);
        if (!result.Accepted || result.Value is not { } value)
        {
            return;
        }

        if (value < limits.Minimum || value > limits.Maximum)
        {
            _messages?.ShowHint(_localization.Format("HS25_Number_Unknown", limits.Minimum, limits.Maximum));
            return;
        }

        await GoToCamAsync((int)value);
    }

    [RelayCommand]
    private Task EditStartAngleAsync() => EditAsync(CamField.StartAngle, "HS25_Start_Angle_Title", "HS25_Unit_Degree", StartAngle, v => StartAngle = v);

    [RelayCommand]
    private Task EditStartTimeAsync() => EditAsync(CamField.StartTime, "HS25_Start_Time_Title", "HS25_Unit_Ms", StartTime, v => StartTime = v);

    [RelayCommand]
    private Task EditEndAngleAsync() => EditAsync(CamField.EndAngle, "HS25_End_Angle_Title", "HS25_Unit_Degree", EndAngle, v => EndAngle = v);

    [RelayCommand]
    private Task EditEndTimeAsync() => EditAsync(CamField.EndTime, "HS25_End_Time_Title", "HS25_Unit_Ms", EndTime, v => EndTime = v);

    [RelayCommand]
    private Task EditTypeAsync() => EditAsync(CamField.CamType, "HS25_Type_Title", null, CamType, v => CamType = v);

    [RelayCommand]
    private async Task EditDesignationAsync()
    {
        if (_dialogs is null || !await EnsureAuthorizedAsync())
        {
            return;
        }

        var request = new MachineInputRequest(_localization.GetString("HS25_Designation_Title"), null, string.Empty, 0, null, InputKind.Text, Designation);
        var result = await _dialogs.ShowAsync<string>(DialogKeys.Input, request);
        if (result.Accepted && result.Value is { } text)
        {
            Designation = text;
        }
    }

    [RelayCommand]
    private async Task PreviousEncoderAsync() => await StepEncoderAsync(-1);

    [RelayCommand]
    private async Task NextEncoderAsync() => await StepEncoderAsync(1);

    private async Task StepEncoderAsync(int direction)
    {
        if (!await EnsureAuthorizedAsync())
        {
            return;
        }

        var count = _service.EncoderNames.Count;
        if (count > 0)
        {
            EncoderIndex = ((EncoderIndex + direction) % count + count) % count;
        }
    }

    [RelayCommand]
    private async Task WriteValuesAsync()
    {
        if (!await EnsureAuthorizedAsync())
        {
            return;
        }

        var detail = Current();
        if (await _service.WriteAsync(detail))
        {
            _baseline = detail;
            RefreshPending();
        }
        else
        {
            _messages?.ShowHint(_localization.GetString("HS25_Write_Failed"));
        }
    }

    private async Task EditAsync(CamField field, string titleKey, string? unitKey, double? current, Action<double> set)
    {
        if (_dialogs is null || !await EnsureAuthorizedAsync())
        {
            return;
        }

        var limits = _service.GetLimits(field);
        var request = new MachineInputRequest(_localization.GetString(titleKey), current, unitKey is null ? string.Empty : _localization.GetString(unitKey), 0, limits, InputKind.Number);
        var result = await _dialogs.ShowAsync<double?>(DialogKeys.Input, request);
        if (!result.Accepted || result.Value is not { } value)
        {
            return;
        }

        if (value < limits.Minimum || value > limits.Maximum)
        {
            _messages?.ShowHint(_localization.Format("HS25_Input_Range", limits.Minimum, limits.Maximum));
            return;
        }

        set(value);
    }

    /// <summary>Bestaetigung "Aenderungen verwerfen?" (S25-2), wenn nicht geschriebene Aenderungen vorliegen.</summary>
    private async Task<bool> ConfirmDiscardAsync()
    {
        if (!HasChanges || _dialogs is null)
        {
            return true;
        }

        var request = new MachineConfirmRequest(
            _localization.GetString("HS25_Discard_Title"),
            _localization.GetString("HS25_Discard_Message"),
            _localization.GetString("HS25_Discard_Accept"),
            _localization.GetString("Popup_Cancel_Label"));
        var result = await _dialogs.ShowAsync<bool>(DialogKeys.Confirmation, request);
        return result.Accepted;
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

    private void UpdateAuthorization() => IsAuthorized = _user?.HasRole(RequiredRole) ?? true;

    private void OnSessionChanged(object? sender, EventArgs e) => UpdateAuthorization();
}
