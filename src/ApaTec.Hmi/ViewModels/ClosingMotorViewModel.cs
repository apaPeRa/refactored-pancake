using System.ComponentModel;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ApaTec.Hmi.Controls;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// HS-17 Motorparameter (Schliessmaschine): drei Karten Verschluss Zu, Verschluss Auf, Schnecke (HM-21). Die Funktionsleiste bleibt leer (A-37, A-44);
/// ein Dosierer-Wechsel existiert nicht. Geaenderte Werte werden sofort an den Dienst gegeben (S16-3-Muster, HM-24-Zustand "nicht geschrieben" entfaellt).
/// </summary>
[PageKey(PageKeys.ClosingMotor)]
public sealed partial class ClosingMotorViewModel : PageViewModelBase
{
    private static readonly HashSet<string> MotorProperties = new(StringComparer.Ordinal)
    {
        nameof(ClosedPosition), nameof(ClosedSpeed), nameof(ClosedAcceleration), nameof(ClosedDeceleration), nameof(ClosedJerk),
        nameof(OpenPosition), nameof(OpenSpeed), nameof(OpenAcceleration), nameof(OpenDeceleration), nameof(OpenJerk),
        nameof(ScrewAcceleration), nameof(ScrewDeceleration), nameof(ScrewJerk),
    };

    /// <summary>Dummy-Rolle fuer alle Felder mit Schluessel (OP-04, OP-25).</summary>
    private const UserRole RequiredRole = UserRole.Technician;

    private readonly IClosingMachineService _service;
    private readonly IUserSession? _user;
    private readonly IDialogService? _dialogs;
    private readonly IMessageService? _messages;
    private readonly ILocalizationService _localization;
    private bool _isLoading;

    [ObservableProperty]
    private bool _isAuthorized = true;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsBlocked))]
    private bool _isEditingAllowed = true;

    /// <summary>Feld der Karte, dessen Eingabe abgelehnt wurde (HM-21 <c>ErrorField</c>).</summary>
    [ObservableProperty]
    private string? _errorField;

    [ObservableProperty]
    private string? _errorText;

    [ObservableProperty]
    private double _closedPosition;

    [ObservableProperty]
    private double _closedSpeed;

    [ObservableProperty]
    private double _closedAcceleration;

    [ObservableProperty]
    private double _closedDeceleration;

    [ObservableProperty]
    private double _closedJerk;

    [ObservableProperty]
    private double _openPosition;

    [ObservableProperty]
    private double _openSpeed;

    [ObservableProperty]
    private double _openAcceleration;

    [ObservableProperty]
    private double _openDeceleration;

    [ObservableProperty]
    private double _openJerk;

    [ObservableProperty]
    private double _screwAcceleration;

    [ObservableProperty]
    private double _screwDeceleration;

    [ObservableProperty]
    private double _screwJerk;

    /// <summary>Entwurfsmodus: Dummy-Dienst.</summary>
    public ClosingMotorViewModel()
        : this(new DummyClosingMachineService(), null, null, null, LocalizationService.Instance)
    {
    }

    public ClosingMotorViewModel(IClosingMachineService service, IUserSession? user, IDialogService? dialogs, IMessageService? messages, ILocalizationService localization)
    {
        _service = service;
        _user = user;
        _dialogs = dialogs;
        _messages = messages;
        _localization = localization;
        MachineName = localization.GetString("HS17_Machine_Name");
        IsAuthorized = user?.HasRole(RequiredRole) ?? true;
        IsEditingAllowed = service.IsEditingAllowed;
        Load();
    }

    /// <summary>Wert fuer <c>DoserName</c> der Karten: "Schliessmaschine" (S17-3), kein Dosierer-Zusatz.</summary>
    public string MachineName { get; }

    /// <summary>true im gesperrten Betriebszustand: Hinweisfeld; Antippen nennt den Grund in der Meldezeile.</summary>
    public bool IsBlocked => !IsEditingAllowed;

    public override void OnNavigatedTo(object? parameter)
    {
        Load();
        ErrorField = null;
        ErrorText = null;
        IsEditingAllowed = _service.IsEditingAllowed;
        IsAuthorized = _user?.HasRole(RequiredRole) ?? true;
        if (_user is not null)
        {
            _user.SessionChanged -= OnSessionChanged;
            _user.SessionChanged += OnSessionChanged;
        }

        if (!IsEditingAllowed)
        {
            _messages?.ShowHint(_localization.GetString("HS17_Blocked_Hint"));
        }
    }

    public override void OnNavigatedFrom()
    {
        if (_user is not null)
        {
            _user.SessionChanged -= OnSessionChanged;
        }
    }

    private void OnSessionChanged(object? sender, EventArgs e) => IsAuthorized = _user?.HasRole(RequiredRole) ?? true;

    /// <summary>Antippen eines Felds der Karte Verschluss Zu; Parameter = Position, Speed, Acceleration, Deceleration, Jerk.</summary>
    [RelayCommand]
    private Task EditClosedAsync(string? name) => EditAsync("Closed", name);

    [RelayCommand]
    private Task EditOpenAsync(string? name) => EditAsync("Open", name);

    [RelayCommand]
    private Task EditScrewAsync(string? name) => EditAsync("Screw", name);

    // Sperrzustand (Grund in der Meldezeile), Rolle, Eingabe-Pop-up mit Grenzen, Fehlertext am Feld.
    private async Task EditAsync(string card, string? name)
    {
        if (name is null || _dialogs is null || !Enum.TryParse<ClosingField>(card + name, out var field))
        {
            return;
        }

        if (!IsEditingAllowed)
        {
            _messages?.ShowHint(_localization.GetString("HS17_Blocked_Hint"));
            return;
        }

        if (_user is not null && !_user.HasRole(RequiredRole))
        {
            _messages?.ShowHint(_localization.Format("Msg_PermissionRequired", _localization.GetString("HM01_Role_" + RequiredRole)));
            if (!await _user.RequestRoleAsync(RequiredRole))
            {
                return;
            }

            IsAuthorized = _user.HasRole(RequiredRole);
        }

        var limits = _service.GetLimits(field);
        var title = $"{_localization.GetString("HS17_" + card + "_Header")} – {_localization.GetString("HM21_" + name + "_Label").TrimEnd(':')}";
        var request = new ClosingInputRequest(title, CurrentValue(field), limits);
        var result = await _dialogs.ShowAsync<double?>(DialogKeys.Input, request);
        if (!result.Accepted || result.Value is not { } value)
        {
            return;
        }

        if (value < limits.Minimum || value > limits.Maximum)
        {
            ErrorField = name;
            ErrorText = _localization.Format("HS17_Error_Range", limits.Minimum, limits.Maximum, limits.Unit);
            return;
        }

        ErrorField = null;
        ErrorText = null;
        SetValue(field, value);
    }

    private double CurrentValue(ClosingField field) => field switch
    {
        ClosingField.ClosedPosition => ClosedPosition,
        ClosingField.ClosedSpeed => ClosedSpeed,
        ClosingField.ClosedAcceleration => ClosedAcceleration,
        ClosingField.ClosedDeceleration => ClosedDeceleration,
        ClosingField.ClosedJerk => ClosedJerk,
        ClosingField.OpenPosition => OpenPosition,
        ClosingField.OpenSpeed => OpenSpeed,
        ClosingField.OpenAcceleration => OpenAcceleration,
        ClosingField.OpenDeceleration => OpenDeceleration,
        ClosingField.OpenJerk => OpenJerk,
        ClosingField.ScrewAcceleration => ScrewAcceleration,
        ClosingField.ScrewDeceleration => ScrewDeceleration,
        ClosingField.ScrewJerk => ScrewJerk,
        _ => 0,
    };

    // Das Setzen loest ueber OnPropertyChanged das Schreiben aus.
    private void SetValue(ClosingField field, double value)
    {
        switch (field)
        {
            case ClosingField.ClosedPosition: ClosedPosition = value; break;
            case ClosingField.ClosedSpeed: ClosedSpeed = value; break;
            case ClosingField.ClosedAcceleration: ClosedAcceleration = value; break;
            case ClosingField.ClosedDeceleration: ClosedDeceleration = value; break;
            case ClosingField.ClosedJerk: ClosedJerk = value; break;
            case ClosingField.OpenPosition: OpenPosition = value; break;
            case ClosingField.OpenSpeed: OpenSpeed = value; break;
            case ClosingField.OpenAcceleration: OpenAcceleration = value; break;
            case ClosingField.OpenDeceleration: OpenDeceleration = value; break;
            case ClosingField.OpenJerk: OpenJerk = value; break;
            case ClosingField.ScrewAcceleration: ScrewAcceleration = value; break;
            case ClosingField.ScrewDeceleration: ScrewDeceleration = value; break;
            case ClosingField.ScrewJerk: ScrewJerk = value; break;
        }
    }

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);
        if (!_isLoading && e.PropertyName is not null && MotorProperties.Contains(e.PropertyName))
        {
            _ = TryPersistAsync();
        }
    }

    private async Task TryPersistAsync()
    {
        try
        {
            await PersistAsync();
        }
        catch (Exception)
        {
            ErrorText = _localization.GetString("HS17_Error_Write");
        }
    }

    /// <summary>Uebernahme eines geaenderten Werts (HM-21 <c>CommitCommand</c>); die Werte stehen bereits im ViewModel, daher nur Schreiben.</summary>
    [RelayCommand]
    private Task CommitAsync() => TryPersistAsync();

    private Task PersistAsync() => _service.SetMotorSettingsAsync(new ClosingMotorSettings(
        new ClosingClosureMotion(ClosedPosition, ClosedSpeed, ClosedAcceleration, ClosedDeceleration, ClosedJerk),
        new ClosingClosureMotion(OpenPosition, OpenSpeed, OpenAcceleration, OpenDeceleration, OpenJerk),
        new ClosingScrewMotion(ScrewAcceleration, ScrewDeceleration, ScrewJerk)));

    private void Load()
    {
        var settings = _service.MotorSettings;
        _isLoading = true;
        try
        {
            ClosedPosition = settings.Closed.Position;
            ClosedSpeed = settings.Closed.Speed;
            ClosedAcceleration = settings.Closed.Acceleration;
            ClosedDeceleration = settings.Closed.Deceleration;
            ClosedJerk = settings.Closed.Jerk;
            OpenPosition = settings.Open.Position;
            OpenSpeed = settings.Open.Speed;
            OpenAcceleration = settings.Open.Acceleration;
            OpenDeceleration = settings.Open.Deceleration;
            OpenJerk = settings.Open.Jerk;
            ScrewAcceleration = settings.Screw.Acceleration;
            ScrewDeceleration = settings.Screw.Deceleration;
            ScrewJerk = settings.Screw.Jerk;
        }
        finally
        {
            _isLoading = false;
        }
    }
}
