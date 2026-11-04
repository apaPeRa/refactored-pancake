using System.Collections.ObjectModel;
using ApaTec.Hmi.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// Basisklasse aller Seiten-ViewModels (Konzept.md 6.2). Der Navigationsdienst erzeugt das ViewModel (transient, per DI),
/// setzt <see cref="PageKey"/>, <see cref="Title"/> und <see cref="Breadcrumb"/> und ruft <see cref="OnNavigatedTo"/> auf.
/// Jedes Seiten-ViewModel braucht zusaetzlich einen parameterlosen Konstruktor fuer den Entwurfsmodus (DesignData).
/// </summary>
public abstract partial class PageViewModelBase : ObservableObject
{
    /// <summary>Hoechstzahl seitenspezifischer Tasten in der Funktionsleiste (Designsystem 3.2).</summary>
    public const int MaxFunctionBarItems = 5;

    [ObservableProperty]
    private string _title = string.Empty;

    [ObservableProperty]
    private IReadOnlyList<BreadcrumbItem> _breadcrumb = Array.Empty<BreadcrumbItem>();

    /// <summary>Seitenschluessel (<see cref="PageKeys"/>), gesetzt vom Navigationsdienst.</summary>
    public string PageKey { get; private set; } = string.Empty;

    /// <summary>Tasten der unteren Funktionsleiste, links beginnend (HM-06).</summary>
    public ObservableCollection<FunctionBarItem> FunctionBarItems { get; } = new();

    /// <summary>Wird nach dem Seitenwechsel aufgerufen; <paramref name="parameter"/> siehe <see cref="NavigationParameters"/>. Auch beim Blaettern (ReplaceParameter).</summary>
    public virtual void OnNavigatedTo(object? parameter)
    {
    }

    /// <summary>Wird vor dem Verlassen der Seite aufgerufen (Zustand freigeben, Timer stoppen).</summary>
    public virtual void OnNavigatedFrom()
    {
    }

    /// <summary>
    /// true, wenn die Seite ungeschriebene Aenderungen haelt und das Verlassen bestaetigen lassen muss. Der Navigationsdienst ruft dann
    /// bei Zurueck, Seitenleiste, Brotkruemel und Home <see cref="CanLeaveAsync"/> auf (Leave-Hook).
    /// </summary>
    public virtual bool HasLeaveGuard => false;

    /// <summary>Leave-Hook: false = Seite bleibt stehen (z. B. "Aenderungen verwerfen?" abgebrochen). Vorgabe: true.</summary>
    public virtual Task<bool> CanLeaveAsync() => Task.FromResult(true);

    internal void Attach(string pageKey, string title, IReadOnlyList<BreadcrumbItem> breadcrumb)
    {
        PageKey = pageKey;
        Title = title;
        Breadcrumb = breadcrumb;
    }
}
