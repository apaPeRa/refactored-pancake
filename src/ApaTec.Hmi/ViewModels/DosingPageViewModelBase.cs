using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// Basis der Dosierer-Seiten (HS-11, HS-12, HS-19, HS-20, HS-21, HS-41): haelt Dienste und Bedienlogik, abonniert Dienst und Anmeldung nur,
/// solange die Seite offen ist, und ruft bei Aenderungen <see cref="RefreshState"/> im Kontext des Erzeugers auf.
/// </summary>
public abstract partial class DosingPageViewModelBase : PageViewModelBase, IBreadcrumbTextProvider
{
    private const int DoserCount = 2;

    private readonly SynchronizationContext? _context = SynchronizationContext.Current;
    private bool _subscribed;

    [ObservableProperty]
    private bool _isAuthorized = true;

    /// <summary>Gezeigter Hauptdosierer (1 oder 2) bei Seiten mit Blaettern (HS-11, HS-12).</summary>
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(PreviousDoserCommand), nameof(NextDoserCommand))]
    private int _doserIndex = 1;

    /// <summary>Entwurfsmodus: Dummy-Dienste ohne Navigation und Dialoge.</summary>
    protected DosingPageViewModelBase()
        : this(new DummyDoserService(), null, new DummyUserSession(), null, null, LocalizationService.Instance)
    {
    }

    protected DosingPageViewModelBase(
        IDoserService service,
        INavigationService? navigation,
        IUserSession? session,
        IDialogService? dialogs,
        IMessageService? messages,
        ILocalizationService localization)
    {
        Service = service;
        Navigation = navigation;
        Session = session;
        Localization = localization;
        Interaction = new DosingInteraction(service, session, dialogs, messages, localization);
        IsAuthorized = Interaction.IsAuthorized;
    }

    protected IDoserService Service { get; }

    protected INavigationService? Navigation { get; }

    protected IUserSession? Session { get; }

    protected ILocalizationService Localization { get; }

    protected DosingInteraction Interaction { get; }

    /// <summary>true bei Seiten, die per Funktionsleiste zwischen Hauptdosierer 1 und 2 blaettern.</summary>
    protected virtual bool UsesPaging => false;

    /// <summary>Positionsanzeige "1 von 2" als Kennwert der Titelzeile (zweiter Kanal der Blaettertasten).</summary>
    public IReadOnlyList<TitleValue> PositionValues => new[]
    {
        new TitleValue { Label = Localization.GetString("Dosing_Position_Label"), Value = Localization.Format("Dosing_PositionValue_Format", DoserIndex, DoserCount) },
    };

    public string? GetCrumbText() => null;

    public virtual string? ObjectSuffix => null;

    /// <summary>Liest den Stand des Dienstes neu in die Seite.</summary>
    protected abstract void RefreshState();

    public override void OnNavigatedTo(object? parameter)
    {
        if (!_subscribed)
        {
            _subscribed = true;
            Service.Changed += OnServiceChanged;
            if (Session is not null)
            {
                Session.SessionChanged += OnServiceChanged;
            }
        }

        if (UsesPaging)
        {
            var index = parameter is NavigationParameters p ? p.Get<int>("doserIndex") : parameter is int i ? i : 1;
            DoserIndex = Math.Clamp(index == 0 ? 1 : index, 1, DoserCount);
            OnPropertyChanged(nameof(PositionValues));
            OnPropertyChanged(nameof(ObjectSuffix));
            Navigation?.RefreshBreadcrumb();
            UpdatePagerItems();
        }

        IsAuthorized = Interaction.IsAuthorized;
        RefreshState();
    }

    public override void OnNavigatedFrom()
    {
        if (_subscribed)
        {
            _subscribed = false;
            Service.Changed -= OnServiceChanged;
            if (Session is not null)
            {
                Session.SessionChanged -= OnServiceChanged;
            }
        }
    }

    protected FunctionBarItem CreateBarItem(string labelKey, string iconKey, System.Windows.Input.ICommand command, object? parameter = null, FunctionBarItemKind kind = FunctionBarItemKind.Action, string targetId = "") => new()
    {
        Label = Localization.GetString(labelKey),
        IconKey = iconKey,
        Command = command,
        CommandParameter = parameter,
        Kind = kind,
        TargetId = targetId,
    };

    /// <summary>Legt die Blaettertasten "«" und "»" in der Funktionsleiste an (HM-19, Randtaste deaktiviert).</summary>
    protected void AddPagerItems()
    {
        FunctionBarItems.Add(CreateBarItem("Dosing_Pager_Previous", string.Empty, PreviousDoserCommand, kind: FunctionBarItemKind.Paging));
        FunctionBarItems.Add(CreateBarItem("Dosing_Pager_Next", string.Empty, NextDoserCommand, kind: FunctionBarItemKind.Paging));
    }

    private void UpdatePagerItems()
    {
        if (FunctionBarItems.Count >= 2)
        {
            FunctionBarItems[0].IsEnabled = DoserIndex > 1;
            FunctionBarItems[1].IsEnabled = DoserIndex < DoserCount;
        }
    }

    private bool CanPrevious() => DoserIndex > 1;

    private bool CanNext() => DoserIndex < DoserCount;

    [RelayCommand(CanExecute = nameof(CanPrevious))]
    private void PreviousDoser() => PageTo(DoserIndex - 1);

    [RelayCommand(CanExecute = nameof(CanNext))]
    private void NextDoser() => PageTo(DoserIndex + 1);

    // Blaettern aendert nur den Seitenparameter (kein Verlaufseintrag); der Dienst ruft OnNavigatedTo erneut.
    private void PageTo(int index)
    {
        if (Navigation is not null)
        {
            Navigation.ReplaceParameter(new NavigationParameters("doserIndex", index));
        }
        else
        {
            OnNavigatedTo(index);
        }
    }

    protected Task NavigateAsync(string pageKey, object? parameter = null) =>
        Navigation is null ? Task.CompletedTask : Navigation.NavigateToAsync(pageKey, parameter);

    private void OnServiceChanged(object? sender, EventArgs e)
    {
        if (_context is null || SynchronizationContext.Current == _context)
        {
            Update();
        }
        else
        {
            _context.Post(_ => Update(), null);
        }
    }

    private void Update()
    {
        IsAuthorized = Interaction.IsAuthorized;
        RefreshState();
    }
}
