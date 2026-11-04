using System.Collections.ObjectModel;
using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>Eine Signalzeile der EA-Anzeige (HM-36). Die Zeilenobjekte bleiben beim Aktualisieren erhalten, nur ihre Werte aendern sich.</summary>
public sealed partial class IoRowViewModel : ObservableObject
{
    [ObservableProperty]
    private string _identifier = string.Empty;

    [ObservableProperty]
    private string _description = string.Empty;

    [ObservableProperty]
    private IoKind _kind;

    [ObservableProperty]
    private LedState _state = LedState.Unknown;

    [ObservableProperty]
    private double? _analogValue;

    [ObservableProperty]
    private bool _isReserve;

    /// <summary>Uebernimmt Kennung, Klartext (unveraendert aus der Konfiguration) und Zustand; <paramref name="connected"/> false = Zustand unbekannt.</summary>
    public void Apply(IoSignal signal, bool connected)
    {
        Identifier = signal.Identifier;
        Description = signal.Description;
        Kind = signal.IsAnalog ? IoKind.Analog : IoKind.Digital;
        IsReserve = signal.IsReserve;
        State = !connected || signal.DigitalState is null ? LedState.Unknown : signal.DigitalState.Value ? LedState.On : LedState.Off;
        AnalogValue = connected ? signal.AnalogValue : null;
    }
}

/// <summary>
/// HS-34 EA-Anzeige: Signalliste einer EA-Karte (Status-LED mit Wort, SPS-Kennung, Klartext, bei Analogkarten Zahlenwert). Reine Anzeige. Parameter <c>cardGroup</c> und
/// <c>cardIndex</c>; die Blaettertasten in der Funktionsleiste ersetzen nur <c>cardIndex</c>. Brotkruemel-Segment: Name der Kartengruppe. Aktualisierung im Sekundentakt.
/// </summary>
[PageKey(PageKeys.IoDisplay)]
public sealed partial class IoDisplayViewModel : PageViewModelBase, IBreadcrumbTextProvider, IDisposable
{
    public const string CardGroupParameter = "cardGroup";
    public const string CardIndexParameter = "cardIndex";

    /// <summary>Sichtbare Signalzeilen (Dummy); darueber hinaus blaettern die Scrolltasten.</summary>
    public const int VisibleRowCount = 10;

    private const double RefreshIntervalMs = 1000;

    private readonly INavigationService _navigation;
    private readonly IIoService _io;
    private readonly ILocalizationService _localization;
    private readonly SynchronizationContext? _ui = SynchronizationContext.Current;
    private readonly System.Timers.Timer _timer = new(RefreshIntervalMs);
    private readonly List<IoRowViewModel> _rows = new();
    private readonly FunctionBarItem _previousItem = new();
    private readonly FunctionBarItem _nextItem = new();

    private string _cardGroup = string.Empty;
    private int _cardIndex;
    private int _cardCount = 1;
    private string _shownCardId = string.Empty;
    private int _scrollOffset;

    [ObservableProperty]
    private string _cardTitle = string.Empty;

    [ObservableProperty]
    private IReadOnlyList<TitleValue> _positionValues = Array.Empty<TitleValue>();

    [ObservableProperty]
    private bool _canScroll;

    public IoDisplayViewModel(INavigationService navigation, IIoService io, ILocalizationService localization)
    {
        _navigation = navigation;
        _io = io;
        _localization = localization;

        _previousItem.Label = _localization.GetString("HS34_Previous_Label");
        _previousItem.Kind = FunctionBarItemKind.Paging;
        _previousItem.Command = PreviousCardCommand;
        _nextItem.Label = _localization.GetString("HS34_Next_Label");
        _nextItem.Kind = FunctionBarItemKind.Paging;
        _nextItem.Command = NextCardCommand;
        FunctionBarItems.Add(_previousItem);
        FunctionBarItems.Add(_nextItem);

        _timer.Elapsed += (_, _) => HandbetriebSupport.Post(_ui, Refresh);
    }

    /// <summary>Entwurfsmodus: Dummy-Karte S1_0KDE1 der Gruppe "Eingaenge S1".</summary>
    public IoDisplayViewModel()
        : this(null!, new DummyIoService(), LocalizationService.Instance)
    {
        Load("InputsS1", 0);
    }

    /// <summary>Signalzeilen im sichtbaren Fenster.</summary>
    public ObservableCollection<IoRowViewModel> VisibleRows { get; } = new();

    /// <summary>Parameter fuer die Navigation nach HS-34.</summary>
    public static NavigationParameters Parameters(string cardGroup, int cardIndex) =>
        new NavigationParameters(CardGroupParameter, cardGroup).With(CardIndexParameter, cardIndex);

    public static string GroupLabel(ILocalizationService localization, string cardGroup) =>
        HandbetriebSupport.TextOrFallback(localization, $"HS33_{cardGroup}_Label", cardGroup);

    public string? GetCrumbText() => _cardGroup.Length == 0 ? null : GroupLabel(_localization, _cardGroup);

    public string? ObjectSuffix => null;

    public override void OnNavigatedTo(object? parameter)
    {
        var p = parameter as NavigationParameters;
        var group = p?.Get<string>(CardGroupParameter) ?? _io.GetCardGroups().FirstOrDefault()?.GroupId ?? string.Empty;
        Load(group, p?.Get<int>(CardIndexParameter) ?? 0);
        _navigation.RefreshBreadcrumb();
        _timer.Start();
    }

    public override void OnNavigatedFrom() => _timer.Stop();

    public void Dispose() => _timer.Dispose();

    [RelayCommand(CanExecute = nameof(CanPrevious))]
    private void PreviousCard() => Page(-1);

    [RelayCommand(CanExecute = nameof(CanNext))]
    private void NextCard() => Page(1);

    [RelayCommand(CanExecute = nameof(CanScrollUp))]
    private void ScrollUp()
    {
        _scrollOffset = Math.Max(0, _scrollOffset - VisibleRowCount);
        UpdateWindow();
    }

    [RelayCommand(CanExecute = nameof(CanScrollDown))]
    private void ScrollDown()
    {
        _scrollOffset = Math.Min(Math.Max(0, _rows.Count - VisibleRowCount), _scrollOffset + VisibleRowCount);
        UpdateWindow();
    }

    private bool CanPrevious() => _cardIndex > 0;

    private bool CanNext() => _cardIndex < _cardCount - 1;

    private bool CanScrollUp() => _scrollOffset > 0;

    private bool CanScrollDown() => _scrollOffset + VisibleRowCount < _rows.Count;

    private void Page(int delta)
    {
        var next = _cardIndex + delta;
        if (next >= 0 && next < _cardCount)
        {
            _navigation.ReplaceParameter(Parameters(_cardGroup, next));
        }
    }

    private void Load(string cardGroup, int cardIndex)
    {
        _cardGroup = cardGroup;
        _cardCount = Math.Max(1, _io.GetCards(cardGroup).Count);
        _cardIndex = Math.Clamp(cardIndex, 0, _cardCount - 1);
        _shownCardId = string.Empty;
        _scrollOffset = 0;
        PositionValues = new[]
        {
            new TitleValue { Label = _localization.GetString("HS34_Card_Label"), Value = _localization.Format("HS34_Position_Format", _cardIndex + 1, _cardCount) },
        };
        _previousItem.IsEnabled = CanPrevious();
        _nextItem.IsEnabled = CanNext();
        PreviousCardCommand.NotifyCanExecuteChanged();
        NextCardCommand.NotifyCanExecuteChanged();
        Refresh();
    }

    private void Refresh()
    {
        var cards = _io.GetCards(_cardGroup);
        if (_cardIndex >= cards.Count)
        {
            CardTitle = string.Empty;
            _rows.Clear();
            UpdateWindow();
            return;
        }

        var card = cards[_cardIndex];
        CardTitle = card.CardId;
        var connected = _io.IsConnected;
        if (card.CardId != _shownCardId || _rows.Count != card.Signals.Count)
        {
            _shownCardId = card.CardId;
            _rows.Clear();
            _rows.AddRange(card.Signals.Select(_ => new IoRowViewModel()));
            _scrollOffset = 0;
            for (var i = 0; i < _rows.Count; i++)
            {
                _rows[i].Apply(card.Signals[i], connected);
            }

            UpdateWindow();
            return;
        }

        for (var i = 0; i < _rows.Count; i++)
        {
            _rows[i].Apply(card.Signals[i], connected);
        }
    }

    private void UpdateWindow()
    {
        VisibleRows.Clear();
        foreach (var row in _rows.Skip(_scrollOffset).Take(VisibleRowCount))
        {
            VisibleRows.Add(row);
        }

        CanScroll = _rows.Count > VisibleRowCount;
        ScrollUpCommand.NotifyCanExecuteChanged();
        ScrollDownCommand.NotifyCanExecuteChanged();
    }
}
