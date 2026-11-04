using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>Hilfen der Seiten HS-30 bis HS-34: Marshalling in den UI-Thread, Beschriftung von Gruppen, Aufbau der Suchanforderung.</summary>
internal static class HandbetriebSupport
{
    /// <summary>Fuehrt <paramref name="action"/> im Kontext aus, in dem das ViewModel erzeugt wurde (Dienstereignisse kommen ggf. aus einem Hintergrundthread).</summary>
    public static void Post(SynchronizationContext? context, Action action)
    {
        if (context is null)
        {
            action();
        }
        else
        {
            context.Post(_ => action(), null);
        }
    }

    /// <summary>Text zum Schluessel; fehlt er, gilt <paramref name="fallback"/>.</summary>
    public static string TextOrFallback(ILocalizationService localization, string key, string fallback)
    {
        var text = localization.GetString(key);
        return text.StartsWith('!') ? fallback : text;
    }

    public static string GroupLabel(ILocalizationService localization, string groupId) =>
        TextOrFallback(localization, $"HS30_{groupId}_Label", groupId);

    /// <summary>Trefferliste fuer das Such-Pop-up (HM-38): Kennzeichnung, Bezeichnung, Gruppe/Karte; das Ziel steht in <c>TargetKey</c>.</summary>
    public static SearchRequest BuildRequest(string title, string placeholder, IEnumerable<EquipmentEntry> entries, Func<EquipmentEntry, string> groupText) =>
        new(title, placeholder, entries
            .Select(entry => new SearchHit { Identifier = entry.Identifier, Description = entry.Description, Group = groupText(entry), TargetKey = entry })
            .ToList());

    /// <summary>Oeffnet das Such-Pop-up und liefert den gewaehlten Eintrag oder null (Abbruch).</summary>
    public static async Task<EquipmentEntry?> ShowSearchAsync(IDialogService dialogs, SearchRequest request)
    {
        var result = await dialogs.ShowAsync<SearchHit>(DialogKeys.Search, request);
        return result.Accepted ? result.Value?.TargetKey as EquipmentEntry : null;
    }
}

/// <summary>
/// HS-31 Handbetrieb: ein Aktor der Gruppe <c>groupId</c> (optional <c>actorId</c>), Jog nur bei gehaltener Taste (Totmann, OP-57), Statusanzeigen, Vorgabewerte,
/// Blaettern innerhalb der Gruppe und Suche. Bewegungstasten nur in der Betriebsart Handbetrieb (A-69). Brotkruemel-Segment: Name der Gruppe.
/// </summary>
[PageKey(PageKeys.ManualOperation)]
public sealed partial class ManualOperationViewModel : PageViewModelBase, IBreadcrumbTextProvider
{
    /// <summary>Parametername Gruppe.</summary>
    public const string GroupIdParameter = "groupId";

    /// <summary>Parametername Aktor (Betriebsmittelkennzeichen).</summary>
    public const string ActorIdParameter = "actorId";

    /// <summary>Mindestrolle fuer Jog und Vorgabewerte (Dummy, OP-25, OP-04).</summary>
    public const UserRole RequiredRole = UserRole.Technician;

    private readonly INavigationService _navigation;
    private readonly IDialogService _dialogs;
    private readonly IUserSession _session;
    private readonly IManualOperationService _manual;
    private readonly IEquipmentSearchService _search;
    private readonly IMachineStatusService _machine;
    private readonly IMessageService _messages;
    private readonly ILocalizationService _localization;
    private readonly SynchronizationContext? _ui = SynchronizationContext.Current;
    private readonly FunctionBarItem _searchItem = new();

    private string _groupId = string.Empty;
    private IReadOnlyList<ManualActor> _actors = Array.Empty<ManualActor>();
    private ManualActor? _actor;
    private ManualActorState? _state;
    private JogDirection? _jogging;
    private bool _subscribed;

    [ObservableProperty]
    private string _actorTitle = string.Empty;

    [ObservableProperty]
    private ManualActorKind _actorKind;

    [ObservableProperty]
    private string _jogMinusLabel = string.Empty;

    [ObservableProperty]
    private string _jogPlusLabel = string.Empty;

    [ObservableProperty]
    private int _actorCount = 1;

    [ObservableProperty]
    private int _actorIndex;

    [ObservableProperty]
    private double? _position;

    [ObservableProperty]
    private LedState _releaseMinusState = LedState.Unknown;

    [ObservableProperty]
    private string _releaseMinusText = string.Empty;

    [ObservableProperty]
    private LedState _endStopMinusState = LedState.Unknown;

    [ObservableProperty]
    private string _endStopMinusText = string.Empty;

    [ObservableProperty]
    private LedState _releasePlusState = LedState.Unknown;

    [ObservableProperty]
    private string _releasePlusText = string.Empty;

    [ObservableProperty]
    private LedState _endStopPlusState = LedState.Unknown;

    [ObservableProperty]
    private string _endStopPlusText = string.Empty;

    [ObservableProperty]
    private LedState _releaseAtPositionState = LedState.Unknown;

    [ObservableProperty]
    private string _releaseAtPositionText = string.Empty;

    [ObservableProperty]
    private double? _positionNumber;

    [ObservableProperty]
    private double? _acceleration;

    [ObservableProperty]
    private double? _speed;

    [ObservableProperty]
    private double? _deceleration;

    [ObservableProperty]
    private string _messageText = "–";

    [ObservableProperty]
    private NoticeKind _messageKind = NoticeKind.MessageLine;

    [ObservableProperty]
    private bool _isManualMode;

    [ObservableProperty]
    private bool _isReachable;

    [ObservableProperty]
    private bool _isAuthorized = true;

    [ObservableProperty]
    private bool _isJogMinusRunning;

    [ObservableProperty]
    private bool _isJogPlusRunning;

    public ManualOperationViewModel(
        INavigationService navigation,
        IDialogService dialogs,
        IUserSession session,
        IManualOperationService manual,
        IEquipmentSearchService search,
        IMachineStatusService machine,
        IMessageService messages,
        ILocalizationService localization)
    {
        _navigation = navigation;
        _dialogs = dialogs;
        _session = session;
        _manual = manual;
        _search = search;
        _machine = machine;
        _messages = messages;
        _localization = localization;

        _searchItem.Label = L("HS30_Search_Label");
        _searchItem.Command = SearchCommand;
        FunctionBarItems.Add(_searchItem);
    }

    /// <summary>Entwurfsmodus: Dummy-Dienste, Beispielaktor "Antrieb Zuefuehrung 2MA1" (GR2).</summary>
    public ManualOperationViewModel()
        : this(null!, null!, new DummyUserSession(), new DummyManualOperationService(), null!, new DummyMachineStatusService(), new DummyMessageService(), LocalizationService.Instance)
    {
        Load("GR2", "2MA1");
    }

    public string RequiredRoleText => _localization.GetString("Role_" + RequiredRole);

    public bool ShowPositioning => ActorKind == ManualActorKind.ServoPositioning;

    public bool ShowManualModeNotice => !IsManualMode;

    /// <summary>Bewegungstasten bedienbar: Handbetrieb und Aktor erreichbar.</summary>
    public bool CanMove => IsManualMode && IsReachable;

    public bool CanPositionStep => CanMove && ReleaseAtPositionState == LedState.On && _jogging is null;

    public bool CanPage => _jogging is null;

    public string? GetCrumbText() => _groupId.Length == 0 ? null : HandbetriebSupport.GroupLabel(_localization, _groupId);

    public string? ObjectSuffix => null;

    public override void OnNavigatedTo(object? parameter)
    {
        Subscribe();
        StopJog();
        var groupId = parameter is NavigationParameters p ? p.Get<string>(GroupIdParameter) : null;
        var actorId = parameter is NavigationParameters q ? q.Get<string>(ActorIdParameter) : null;
        groupId ??= _manual.GetGroups().FirstOrDefault(g => _manual.GetActors(g.GroupId).Count > 0)?.GroupId ?? string.Empty;
        Load(groupId, actorId);
        _navigation.RefreshBreadcrumb();
        if (!IsManualMode)
        {
            _messages.ShowHint(L("HS31_NotManual_Text"));
        }
    }

    public override void OnNavigatedFrom()
    {
        StopJog();
        Unsubscribe();
    }

    [RelayCommand]
    private async Task BeginJogMinusAsync() => await BeginJogAsync(JogDirection.Minus);

    [RelayCommand]
    private async Task BeginJogPlusAsync() => await BeginJogAsync(JogDirection.Plus);

    [RelayCommand]
    private void EndJogMinus() => EndJog(JogDirection.Minus);

    [RelayCommand]
    private void EndJogPlus() => EndJog(JogDirection.Plus);

    [RelayCommand(CanExecute = nameof(CanPositionStep))]
    private void PositionBack() => StepPosition(JogDirection.Minus);

    [RelayCommand(CanExecute = nameof(CanPositionStep))]
    private void PositionForward() => StepPosition(JogDirection.Plus);

    [RelayCommand(CanExecute = nameof(CanPrevious))]
    private void PreviousActor() => Page(-1);

    [RelayCommand(CanExecute = nameof(CanNext))]
    private void NextActor() => Page(1);

    [RelayCommand]
    private async Task EditParameterAsync(ManualParameter parameter)
    {
        if (_actor is null)
        {
            return;
        }

        if (!_session.HasRole(RequiredRole))
        {
            _messages.ShowHint(_localization.Format("Msg_PermissionRequired", RequiredRoleText));
            if (!await _session.RequestRoleAsync(RequiredRole))
            {
                return;
            }
        }

        var (key, current) = parameter switch
        {
            ManualParameter.Acceleration => ("HS31_Acceleration_Label", Acceleration),
            ManualParameter.Speed => ("HS31_Speed_Label", Speed),
            _ => ("HS31_Deceleration_Label", Deceleration),
        };
        var request = new ManualInputRequest(L(key), current ?? 0, 0, 100, 0, L("HS31_Percent_Unit"), L("HS31_InputHelp_Text"));
        var result = await _dialogs.ShowAsync<double>(DialogKeys.Input, request);
        if (result.Accepted)
        {
            _manual.SetParameter(_actor.ActorId, parameter, Math.Clamp(result.Value, 0, 100));
            Refresh();
        }
    }

    [RelayCommand(CanExecute = nameof(CanPage))]
    private async Task SearchAsync()
    {
        var request = HandbetriebSupport.BuildRequest(
            L("HS30_SearchActor_Title"), L("HS30_SearchPlaceholder"), _search.GetActorEntries(), e => HandbetriebSupport.GroupLabel(_localization, e.GroupId));
        if (await HandbetriebSupport.ShowSearchAsync(_dialogs, request) is { } entry)
        {
            _navigation.ReplaceParameter(new NavigationParameters(GroupIdParameter, entry.GroupId).With(ActorIdParameter, entry.ItemId));
        }
    }

    private async Task BeginJogAsync(JogDirection direction)
    {
        if (_actor is null)
        {
            return;
        }

        if (!CanMove)
        {
            _messages.ShowHint(L("HS31_NotManual_Text"));
            return;
        }

        if (!_session.HasRole(RequiredRole))
        {
            _messages.ShowHint(_localization.Format("Msg_PermissionRequired", RequiredRoleText));
            await _session.RequestRoleAsync(RequiredRole);
            return;
        }

        if (_jogging is not null)
        {
            // Jog- und Jog+ gleichzeitig: keine Bewegung.
            StopJog();
            return;
        }

        _jogging = direction;
        IsJogMinusRunning = direction == JogDirection.Minus;
        IsJogPlusRunning = direction == JogDirection.Plus;
        _manual.SetJog(_actor.ActorId, direction, true);
        NotifyJogChanged();
    }

    private void EndJog(JogDirection direction)
    {
        if (_jogging == direction)
        {
            StopJog();
        }
    }

    private void StopJog()
    {
        if (_jogging is { } direction && _actor is not null)
        {
            _manual.SetJog(_actor.ActorId, direction, false);
        }

        _jogging = null;
        IsJogMinusRunning = false;
        IsJogPlusRunning = false;
        NotifyJogChanged();
    }

    private void NotifyJogChanged()
    {
        OnPropertyChanged(nameof(CanPage));
        OnPropertyChanged(nameof(CanPositionStep));
        PreviousActorCommand.NotifyCanExecuteChanged();
        NextActorCommand.NotifyCanExecuteChanged();
        PositionBackCommand.NotifyCanExecuteChanged();
        PositionForwardCommand.NotifyCanExecuteChanged();
        SearchCommand.NotifyCanExecuteChanged();
        _searchItem.IsEnabled = CanPage;
    }

    private void StepPosition(JogDirection direction)
    {
        if (_actor is not null)
        {
            _manual.StepPosition(_actor.ActorId, direction);
            Refresh();
        }
    }

    private void Page(int delta)
    {
        var next = ActorIndex + delta;
        if (next < 0 || next >= _actors.Count)
        {
            return;
        }

        _navigation.ReplaceParameter(new NavigationParameters(GroupIdParameter, _groupId).With(ActorIdParameter, _actors[next].ActorId));
    }

    private void Load(string groupId, string? actorId)
    {
        _groupId = groupId;
        _actors = _manual.GetActors(groupId);
        var index = actorId is null ? 0 : Math.Max(0, _actors.ToList().FindIndex(a => a.ActorId == actorId));
        _actor = _actors.Count > 0 ? _actors[index] : null;
        ActorCount = Math.Max(1, _actors.Count);
        ActorIndex = index;
        ActorTitle = _actor?.Designation ?? string.Empty;
        ActorKind = _actor?.Kind ?? ManualActorKind.Drive;
        var switching = ActorKind == ManualActorKind.Switching;
        JogMinusLabel = L(switching ? "HS31_SwitchOff_Label" : "HS31_JogMinus_Label");
        JogPlusLabel = L(switching ? "HS31_SwitchOn_Label" : "HS31_JogPlus_Label");
        OnPropertyChanged(nameof(ShowPositioning));
        Refresh();
    }

    private void Refresh()
    {
        IsManualMode = _machine.OperatingMode == OperatingMode.Manual;
        IsAuthorized = _session.HasRole(RequiredRole);
        _state = _actor is null ? null : _manual.GetState(_actor.ActorId);
        var state = _state;
        IsReachable = state?.IsReachable ?? false;
        Position = state?.Position;
        (ReleaseMinusState, ReleaseMinusText) = Led(state?.ReleaseMinus, "HS31_Released_Word", "HS31_Blocked_Word");
        (EndStopMinusState, EndStopMinusText) = Led(state?.EndStopMinus, "HS31_Reached_Word", "HS31_NotReached_Word");
        (ReleasePlusState, ReleasePlusText) = Led(state?.ReleasePlus, "HS31_Released_Word", "HS31_Blocked_Word");
        (EndStopPlusState, EndStopPlusText) = Led(state?.EndStopPlus, "HS31_Reached_Word", "HS31_NotReached_Word");
        (ReleaseAtPositionState, ReleaseAtPositionText) = Led(state?.ReleaseAtPosition, "HS31_Released_Word", "HS31_Blocked_Word");
        PositionNumber = state?.PositionNumber;
        Acceleration = IsReachable ? state?.Acceleration : null;
        Speed = IsReachable ? state?.Speed : null;
        Deceleration = IsReachable ? state?.Deceleration : null;
        var hasMessage = !string.IsNullOrEmpty(state?.Message);
        MessageText = hasMessage ? state!.Message! : L("HS31_Message_Empty");
        MessageKind = hasMessage && state!.IsFault ? NoticeKind.Error : NoticeKind.MessageLine;
        if (_jogging is not null && !CanMove)
        {
            StopJog();
        }

        OnPropertyChanged(nameof(ShowManualModeNotice));
        OnPropertyChanged(nameof(CanMove));
        OnPropertyChanged(nameof(CanPositionStep));
        PositionBackCommand.NotifyCanExecuteChanged();
        PositionForwardCommand.NotifyCanExecuteChanged();
        PreviousActorCommand.NotifyCanExecuteChanged();
        NextActorCommand.NotifyCanExecuteChanged();
    }

    private (LedState State, string Text) Led(bool? value, string onKey, string offKey) =>
        value is null ? (LedState.Unknown, string.Empty) : value.Value ? (LedState.On, L(onKey)) : (LedState.Off, L(offKey));

    partial void OnActorIndexChanged(int value)
    {
        PreviousActorCommand.NotifyCanExecuteChanged();
        NextActorCommand.NotifyCanExecuteChanged();
    }

    private bool CanPrevious() => CanPage && ActorIndex > 0;

    private bool CanNext() => CanPage && ActorIndex < _actors.Count - 1;

    private void Subscribe()
    {
        if (_subscribed)
        {
            return;
        }

        _subscribed = true;
        _manual.Changed += OnExternalChanged;
        _machine.Changed += OnExternalChanged;
        _session.SessionChanged += OnExternalChanged;
    }

    private void Unsubscribe()
    {
        if (!_subscribed)
        {
            return;
        }

        _subscribed = false;
        _manual.Changed -= OnExternalChanged;
        _machine.Changed -= OnExternalChanged;
        _session.SessionChanged -= OnExternalChanged;
    }

    private void OnExternalChanged(object? sender, EventArgs e) => HandbetriebSupport.Post(_ui, () =>
    {
        Refresh();
        if (_jogging is not null && !_session.HasRole(RequiredRole))
        {
            StopJog();
        }
    });

    private string L(string key) => _localization.GetString(key);
}
