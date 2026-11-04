using ApaTec.Hmi.Services;
using ApaTec.Hmi.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace ApaTec.Hmi.Navigation;

/// <summary>
/// Umsetzung von <see cref="INavigationService"/> nach Navigation.md 5.2 bis 5.5 (A-42, A-44):
/// Zurueck-Stapel ohne aktuelle Seite (Tiefe 20), Popup-Stapel Tiefe 2, Brotkruemel aus der Kette der Elternschluessel.
/// </summary>
public sealed class NavigationService : INavigationService
{
    private const int MaxHistoryDepth = 20;

    private readonly PageRegistry _registry;
    private readonly IServiceProvider _services;
    private readonly IUserSession _session;
    private readonly ILocalizationService _localization;
    private readonly List<NavigationEntry> _history = new();
    private readonly List<PopupViewModelBase> _popups = new();

    public NavigationService(PageRegistry registry, IServiceProvider services, IUserSession session, ILocalizationService localization)
    {
        _registry = registry;
        _services = services;
        _session = session;
        _localization = localization;
        _localization.CultureChanged += (_, _) => OnCultureChanged();
        _session.SessionChanged += (_, _) => OnSessionChanged();
    }

    public event EventHandler<NavigatedEventArgs>? Navigated;

    public event EventHandler? PopupStackChanged;

    public PageDescriptor? Current { get; private set; }

    public object? CurrentParameter { get; private set; }

    public PageViewModelBase? CurrentViewModel { get; private set; }

    public IReadOnlyList<NavigationEntry> History => _history;

    public IReadOnlyList<BreadcrumbItem> Breadcrumb { get; private set; } = Array.Empty<BreadcrumbItem>();

    public IReadOnlyList<PopupViewModelBase> PopupStack => _popups;

    public PopupViewModelBase? CurrentPopup => _popups.Count > 0 ? _popups[^1] : null;

    public bool IsModalOpen => _popups.Count > 0;

    public int MaxPopupDepth => 2;

    public bool CanGoBack => !IsModalOpen && Current is not null && Current.Key != PageKeys.Production;

    public async Task<bool> NavigateToAsync(string pageKey, object? parameter = null)
    {
        if (!_registry.TryGet(pageKey, out var descriptor))
        {
            return false;
        }

        if (descriptor.Kind == PageKind.Popup)
        {
            return OpenPopupPage(descriptor, parameter);
        }

        if (IsModalOpen || (Current is not null && Current.Key == descriptor.Key))
        {
            return false;
        }

        if (descriptor.MinimumRole is { } minimum && !_session.HasRole(minimum) && !await _session.RequestRoleAsync(minimum))
        {
            return false;
        }

        if (IsModalOpen)
        {
            return false;
        }

        // Leave-Hook (Abbrechen/Verwerfen): die aktuelle Seite darf den Wechsel ablehnen.
        var leaving = CurrentViewModel;
        if (leaving is not null && !await leaving.CanLeaveAsync())
        {
            return false;
        }

        if (IsModalOpen || !ReferenceEquals(leaving, CurrentViewModel))
        {
            return false;
        }

        return NavigateCore(descriptor, parameter);
    }

    public void ReplaceParameter(object? parameter)
    {
        if (Current is null || CurrentViewModel is null)
        {
            return;
        }

        CurrentParameter = parameter;
        CurrentViewModel.OnNavigatedTo(parameter);
        Navigated?.Invoke(this, new NavigatedEventArgs(Current, parameter));
    }

    public bool GoBack()
    {
        if (!CanGoBack || Current is null)
        {
            return false;
        }

        return Guard(GoBackCore);
    }

    private bool GoBackCore()
    {
        if (Current is null)
        {
            return false;
        }

        if (_history.Count > 0)
        {
            var entry = _history[^1];
            _history.RemoveAt(_history.Count - 1);
            return Show(_registry.Get(entry.Key), entry.Parameter);
        }

        var parent = Current.ParentKey is { } p && _registry.TryGet(p, out var pd) && pd.Kind != PageKind.Popup
            ? pd
            : _registry.Get(PageKeys.Production);
        return Show(parent, null);
    }

    public bool GoToAncestor(string pageKey)
    {
        if (IsModalOpen || !_registry.TryGet(pageKey, out var descriptor) || descriptor.Kind == PageKind.Popup)
        {
            return false;
        }

        return Guard(() => NavigateCore(descriptor, null));
    }

    public void GoHome()
    {
        Guard(() =>
        {
            CloseAllPopups();
            _history.Clear();
            Show(_registry.Get(PageKeys.Production), null);
            return true;
        });
    }

    public void GoToSettings()
    {
        if (IsModalOpen)
        {
            return;
        }

        Guard(() =>
        {
            _history.Clear();
            _history.Add(new NavigationEntry(PageKeys.Production, null));
            Show(_registry.Get(PageKeys.Settings), null);
            return true;
        });
    }

    // Synchrone Navigationswege (Zurueck, Brotkruemel, Home, Einstellungen) pruefen den Leave-Hook der Seite. Meldet die Seite
    // Aenderungen (HasLeaveGuard), laeuft die Rueckfrage asynchron; die Navigation wird danach ausgefuehrt, falls die Seite zustimmt.
    // Rueckgabe: true = ausgefuehrt oder angenommen (Rueckfrage laeuft), false = abgelehnt.
    private bool Guard(Func<bool> navigate)
    {
        if (CurrentViewModel is not { HasLeaveGuard: true } leaving || IsModalOpen)
        {
            return navigate();
        }

        _ = GuardAsync(leaving, navigate);
        return true;
    }

    private async Task GuardAsync(PageViewModelBase leaving, Func<bool> navigate)
    {
        if (await leaving.CanLeaveAsync() && !IsModalOpen && ReferenceEquals(CurrentViewModel, leaving))
        {
            navigate();
        }
    }

    // Rollenverlust (Navigation.md 5.4, 4.2 Nr. 5): geschuetzte Seite verlassen, Pop-ups ohne Uebernehmen schliessen.
    private void OnSessionChanged()
    {
        if (Current is not { MinimumRole: { } minimum } descriptor || _session.HasRole(minimum))
        {
            return;
        }

        CloseAllPopups();
        _history.RemoveAll(e => _registry.TryGet(e.Key, out var d) && d.MinimumRole is { } r && !_session.HasRole(r));
        var parent = descriptor.ParentKey is { } p && _registry.TryGet(p, out var pd) && pd.Kind != PageKind.Popup
            ? pd
            : _registry.Get(PageKeys.Production);
        Show(parent, null);
    }

    public Task<bool> OpenMessagesAsync() => NavigateToAsync(PageKeys.MessageView);

    public bool TryOpenPopup(PopupViewModelBase popup)
    {
        if (_popups.Count >= MaxPopupDepth)
        {
            return false;
        }

        popup.Closed += OnPopupClosed;
        _popups.Add(popup);
        PopupStackChanged?.Invoke(this, EventArgs.Empty);
        return true;
    }

    public bool CloseTopPopup()
    {
        if (CurrentPopup is not { } top)
        {
            return false;
        }

        top.Dismiss();
        return true;
    }

    public void CloseAllPopups()
    {
        while (CurrentPopup is not null)
        {
            CloseTopPopup();
        }
    }

    public void RefreshBreadcrumb()
    {
        if (Current is null || CurrentViewModel is null)
        {
            return;
        }

        Breadcrumb = BuildBreadcrumb(Current, CurrentViewModel);
        CurrentViewModel.Breadcrumb = Breadcrumb;
        Navigated?.Invoke(this, new NavigatedEventArgs(Current, CurrentParameter));
    }

    private void OnPopupClosed(object? sender, PopupClosedEventArgs e)
    {
        if (sender is PopupViewModelBase popup)
        {
            popup.Closed -= OnPopupClosed;
            _popups.Remove(popup);
            PopupStackChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    private bool OpenPopupPage(PageDescriptor descriptor, object? parameter)
    {
        PopupViewModelBase popup = descriptor.ViewModelType is { } type
            ? (PopupViewModelBase)_services.GetRequiredService(type)
            : new PlaceholderPopupViewModel(descriptor.Key);
        popup.Title = _localization.GetString(descriptor.TitleResourceKey);
        popup.Initialize(descriptor.Key, parameter);
        return TryOpenPopup(popup);
    }

    // Seitenwechsel nach Navigation.md 5.3: Sprung auf eine Seite im Stapel kuerzt ihn, sonst wird die aktuelle Seite gestapelt.
    private bool NavigateCore(PageDescriptor target, object? parameter)
    {
        if (Current is not null && Current.Key == target.Key)
        {
            return false;
        }

        var index = _history.FindLastIndex(e => e.Key == target.Key);
        if (index >= 0)
        {
            var entry = _history[index];
            var merged = NavigationParameters.Merge(NavigationParameters.Merge(entry.Parameter, CurrentParameter), parameter);
            _history.RemoveRange(index, _history.Count - index);
            return Show(target, merged);
        }

        if (Current is not null && Current.Kind != PageKind.Fullscreen)
        {
            _history.Add(new NavigationEntry(Current.Key, CurrentParameter));
            if (_history.Count > MaxHistoryDepth)
            {
                // Aeltesten Eintrag entfernen, die Wurzel (HS-01) bleibt.
                _history.RemoveAt(_history.Count > 1 && _history[0].Key == PageKeys.Production ? 1 : 0);
            }
        }

        return Show(target, parameter);
    }

    private bool Show(PageDescriptor descriptor, object? parameter)
    {
        CurrentViewModel?.OnNavigatedFrom();

        PageViewModelBase viewModel = descriptor.ViewModelType is { } type
            ? (PageViewModelBase)_services.GetRequiredService(type)
            : new PlaceholderPageViewModel();

        Current = descriptor;
        CurrentParameter = parameter;
        CurrentViewModel = viewModel;
        Breadcrumb = BuildBreadcrumb(descriptor, viewModel);
        viewModel.Attach(descriptor.Key, _localization.GetString(descriptor.TitleResourceKey), Breadcrumb);
        viewModel.OnNavigatedTo(parameter);
        Navigated?.Invoke(this, new NavigatedEventArgs(descriptor, parameter));
        return true;
    }

    private IReadOnlyList<BreadcrumbItem> BuildBreadcrumb(PageDescriptor descriptor, PageViewModelBase viewModel)
    {
        var chain = new List<PageDescriptor>();
        for (var d = descriptor; ; )
        {
            chain.Insert(0, d);
            if (d.ParentKey is null || !_registry.TryGet(d.ParentKey, out var parent) || chain.Count > 8)
            {
                break;
            }

            d = parent;
        }

        var items = new List<BreadcrumbItem>(chain.Count);
        for (var i = 0; i < chain.Count; i++)
        {
            var isLast = i == chain.Count - 1;
            var text = _localization.GetString(chain[i].CrumbResourceKey);
            if (isLast && viewModel is IBreadcrumbTextProvider provider)
            {
                text = provider.GetCrumbText() ?? text;
                if (!string.IsNullOrEmpty(provider.ObjectSuffix))
                {
                    text = $"{text} {provider.ObjectSuffix}";
                }
            }

            items.Add(new BreadcrumbItem(chain[i].Key, text, isLast, !isLast));
        }

        return items;
    }

    private void OnCultureChanged()
    {
        if (Current is null || CurrentViewModel is null)
        {
            return;
        }

        Breadcrumb = BuildBreadcrumb(Current, CurrentViewModel);
        CurrentViewModel.Attach(Current.Key, _localization.GetString(Current.TitleResourceKey), Breadcrumb);
        Navigated?.Invoke(this, new NavigatedEventArgs(Current, CurrentParameter));
    }
}
