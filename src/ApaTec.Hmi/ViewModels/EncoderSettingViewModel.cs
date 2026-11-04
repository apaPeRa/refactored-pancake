using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// HS-32 Geber setzen: zeigt Motor-, Geberposition und Offset (Motor minus Geber, nicht editierbar) sowie den Initialisierungszustand; "Geber setzen" uebernimmt nach
/// langem Druecken die Motorposition als neuen Nullpunkt. Voraussetzung: Not-Aus gedrueckt (Annahme OP-60) und Rolle. Abbruch bei Loslassen, Seitenwechsel,
/// Blaettern, Verlust von Not-Aus oder Rolle. Blaettern ersetzt nur <c>encoderIndex</c>.
/// </summary>
[PageKey(PageKeys.EncoderSetting)]
public sealed partial class EncoderSettingViewModel : PageViewModelBase
{
    public const string EncoderIndexParameter = "encoderIndex";

    /// <summary>Mindestrolle fuer "Geber setzen" (Dummy, OP-25, OP-04).</summary>
    public const UserRole RequiredRole = UserRole.Technician;

    /// <summary>Haltedauer des langen Druckens in Millisekunden (Dummy, OP-42).</summary>
    public const int HoldMilliseconds = 1000;

    private readonly INavigationService _navigation;
    private readonly IUserSession _session;
    private readonly IEncoderService _encoders;
    private readonly IMessageService _messages;
    private readonly ILocalizationService _localization;
    private readonly SynchronizationContext? _ui = SynchronizationContext.Current;

    private IReadOnlyList<EncoderInfo> _list = Array.Empty<EncoderInfo>();
    private int _index;
    private string? _feedback;
    private bool _subscribed;

    [ObservableProperty]
    private string _encoderTitle = string.Empty;

    [ObservableProperty]
    private double? _motorPosition;

    [ObservableProperty]
    private double? _encoderPosition;

    [ObservableProperty]
    private double? _positionOffset;

    [ObservableProperty]
    private LedState _initializedState = LedState.Unknown;

    [ObservableProperty]
    private string _initializedText = string.Empty;

    [ObservableProperty]
    private string _statusText = string.Empty;

    [ObservableProperty]
    private string _messageText = "–";

    [ObservableProperty]
    private NoticeKind _messageKind = NoticeKind.MessageLine;

    [ObservableProperty]
    private bool _isReachable;

    [ObservableProperty]
    private bool _isEmergencyStopPressed;

    [ObservableProperty]
    private bool _isAuthorized = true;

    /// <summary>Lauf des langen Drueckens; wird von <c>HM07_PressBehavior</c> an der Taste gesetzt (OneWayToSource) und sperrt das Blaettern.</summary>
    [ObservableProperty]
    private bool _isHolding;

    [ObservableProperty]
    private int _encoderCount = 1;

    [ObservableProperty]
    private int _encoderIndex;

    public EncoderSettingViewModel(INavigationService navigation, IUserSession session, IEncoderService encoders, IMessageService messages, ILocalizationService localization)
    {
        _navigation = navigation;
        _session = session;
        _encoders = encoders;
        _messages = messages;
        _localization = localization;
    }

    /// <summary>Entwurfsmodus: Dummy-Dienste, erster Geber (Bildbeispiel).</summary>
    public EncoderSettingViewModel()
        : this(null!, new DummyUserSession(), new DummyEncoderService(), new DummyMessageService(), LocalizationService.Instance)
    {
        Load(0);
    }

    public string RequiredRoleText => _localization.GetString("Role_" + RequiredRole);

    public TimeSpan HoldDuration => TimeSpan.FromMilliseconds(HoldMilliseconds);

    public bool ShowStatusText => StatusText.Length > 0;

    /// <summary>Taste bedienbar: Geber erreichbar und Not-Aus gedrueckt (sonst deaktiviert, Grund im Warnhinweis).</summary>
    public bool CanSet => IsReachable && IsEmergencyStopPressed;

    public bool CanPage => !IsHolding;

    public override void OnNavigatedTo(object? parameter)
    {
        Subscribe();
        _feedback = null;
        Load(parameter is NavigationParameters p ? p.Get<int>(EncoderIndexParameter) : 0);
        if (!CanSet)
        {
            _messages.ShowHint(_localization.GetString("HS32_NoEmergencyStop_Text"));
        }
    }

    public override void OnNavigatedFrom() => Unsubscribe();

    partial void OnIsHoldingChanged(bool value) => NotifyPaging();

    /// <summary>Beginn des Drueckens auf "Geber setzen": ohne Not-Aus oder Rolle nur Hinweis (bzw. Benutzer-Pop-up); die Taste laeuft dann nicht (HM07_PressBehavior).</summary>
    [RelayCommand]
    private async Task BeginSetAsync()
    {
        if (!CanSet)
        {
            _messages.ShowHint(_localization.GetString("HS32_NoEmergencyStop_Text"));
            return;
        }

        if (!_session.HasRole(RequiredRole))
        {
            _messages.ShowHint(_localization.Format("Msg_PermissionRequired", RequiredRoleText));
            await _session.RequestRoleAsync(RequiredRole);
        }
    }

    /// <summary>Haltedauer erreicht (HM07_PressBehavior, Befehl nach <see cref="HoldDuration"/>): uebernimmt die Motorposition als neuen Nullpunkt.</summary>
    [RelayCommand(CanExecute = nameof(CanSetEncoder))]
    private void SetEncoder()
    {
        if (!CanSet || !_session.HasRole(RequiredRole) || _list.Count == 0)
        {
            return;
        }

        if (_encoders.SetEncoderZero(_list[_index].Index))
        {
            _feedback = _localization.GetString("HS32_EncoderSet_Text");
        }

        Refresh();
    }

    // Gesperrt (CanExecute) statt IsEnabled=false: die Taste bleibt antippbar, BeginSet nennt den Grund; das Halten startet nicht (HM07_PressBehavior).
    private bool CanSetEncoder() => CanSet && _session.HasRole(RequiredRole) && _list.Count > 0;

    [RelayCommand(CanExecute = nameof(CanPrevious))]
    private void PreviousEncoder() => Page(-1);

    [RelayCommand(CanExecute = nameof(CanNext))]
    private void NextEncoder() => Page(1);

    private bool CanPrevious() => CanPage && EncoderIndex > 0;

    private bool CanNext() => CanPage && EncoderIndex < _list.Count - 1;

    private void Page(int delta)
    {
        var next = EncoderIndex + delta;
        if (next >= 0 && next < _list.Count)
        {
            _navigation.ReplaceParameter(new NavigationParameters(EncoderIndexParameter, next));
        }
    }

    private void NotifyPaging()
    {
        OnPropertyChanged(nameof(CanPage));
        PreviousEncoderCommand.NotifyCanExecuteChanged();
        NextEncoderCommand.NotifyCanExecuteChanged();
    }

    private void Load(int index)
    {
        _list = _encoders.GetEncoders();
        _index = _list.Count == 0 ? 0 : Math.Clamp(index, 0, _list.Count - 1);
        EncoderCount = Math.Max(1, _list.Count);
        EncoderIndex = _index;
        EncoderTitle = _list.Count == 0 ? string.Empty : _list[_index].Designation;
        _feedback = null;
        Refresh();
        NotifyPaging();
    }

    private void Refresh()
    {
        AuthorizeAndStop();
        var state = _list.Count == 0 ? null : _encoders.GetState(_list[_index].Index);
        IsReachable = state?.IsReachable ?? false;
        MotorPosition = state?.MotorPosition;
        EncoderPosition = state?.EncoderPosition;
        PositionOffset = state?.PositionOffset;
        (InitializedState, InitializedText) = state?.IsInitialized switch
        {
            true => (LedState.On, _localization.GetString("HS32_InitializedOk_Word")),
            false => (LedState.Warning, _localization.GetString("HS32_NotInitialized_Word")),
            _ => (LedState.Unknown, string.Empty),
        };
        StatusText = state?.StatusText ?? string.Empty;
        var message = _feedback ?? state?.Message;
        MessageText = string.IsNullOrEmpty(message) ? _localization.GetString("HS32_Message_Empty") : message;
        MessageKind = state is { IsFault: true } && !string.IsNullOrEmpty(state.Message) && _feedback is null ? NoticeKind.Error : NoticeKind.MessageLine;
        IsEmergencyStopPressed = _encoders.IsEmergencyStopPressed;
        OnPropertyChanged(nameof(ShowStatusText));
        OnPropertyChanged(nameof(CanSet));
        SetEncoderCommand.NotifyCanExecuteChanged();
    }

    private void AuthorizeAndStop() => IsAuthorized = _session.HasRole(RequiredRole);

    private void Subscribe()
    {
        if (_subscribed)
        {
            return;
        }

        _subscribed = true;
        _encoders.Changed += OnExternalChanged;
        _session.SessionChanged += OnExternalChanged;
    }

    private void Unsubscribe()
    {
        if (!_subscribed)
        {
            return;
        }

        _subscribed = false;
        _encoders.Changed -= OnExternalChanged;
        _session.SessionChanged -= OnExternalChanged;
    }

    // Verliert die Taste Not-Aus oder Rolle, sperrt sie sich selbst (IsEnabled/IsAuthorized) und die Haltefunktion bricht ab.
    private void OnExternalChanged(object? sender, EventArgs e) => HandbetriebSupport.Post(_ui, Refresh);
}
