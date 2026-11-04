using System.Reflection;
using ApaTec.Hmi.ViewModels;

namespace ApaTec.Hmi.Navigation;

/// <summary>
/// Register der 43 Seiten (Navigation.md 5.1) und der Dialoge. Die Metadaten stehen in <see cref="PageCatalog"/>;
/// die ViewModels werden per Reflection ueber <see cref="PageKeyAttribute"/> bzw. <see cref="DialogKeyAttribute"/> in der Assembly gefunden.
/// Parallel arbeitende Agenten legen nur ihre ViewModel-Klasse mit Attribut an, es gibt keine gemeinsame Registrierungsdatei.
/// </summary>
public sealed class PageRegistry
{
    private readonly Dictionary<string, PageDescriptor> _pages;
    private readonly Dictionary<string, Type> _dialogs;

    public PageRegistry(Assembly assembly)
    {
        var pageTypes = new Dictionary<string, Type>(StringComparer.Ordinal);
        _dialogs = new Dictionary<string, Type>(StringComparer.Ordinal);

        foreach (var type in assembly.GetTypes())
        {
            if (type.IsAbstract || !type.IsClass)
            {
                continue;
            }

            var pageAttr = type.GetCustomAttribute<PageKeyAttribute>(false);
            if (pageAttr is not null)
            {
                if (!pageTypes.TryAdd(pageAttr.Key, type))
                {
                    throw new InvalidOperationException($"Seitenschluessel '{pageAttr.Key}' ist mehrfach vergeben: {pageTypes[pageAttr.Key].FullName} und {type.FullName}.");
                }
            }

            var dialogAttr = type.GetCustomAttribute<DialogKeyAttribute>(false);
            if (dialogAttr is not null)
            {
                if (!typeof(PopupViewModelBase).IsAssignableFrom(type))
                {
                    throw new InvalidOperationException($"{type.FullName} traegt [DialogKey], ist aber nicht von PopupViewModelBase abgeleitet.");
                }

                if (!_dialogs.TryAdd(dialogAttr.Key, type))
                {
                    throw new InvalidOperationException($"Dialogschluessel '{dialogAttr.Key}' ist mehrfach vergeben: {_dialogs[dialogAttr.Key].FullName} und {type.FullName}.");
                }
            }
        }

        _pages = new Dictionary<string, PageDescriptor>(StringComparer.Ordinal);
        foreach (var descriptor in PageCatalog.All)
        {
            pageTypes.TryGetValue(descriptor.Key, out var vmType);
            if (vmType is not null)
            {
                var expected = descriptor.Kind == PageKind.Popup ? typeof(PopupViewModelBase) : typeof(PageViewModelBase);
                if (!expected.IsAssignableFrom(vmType))
                {
                    throw new InvalidOperationException($"{vmType.FullName} (Seite {descriptor.Key}) muss von {expected.Name} abgeleitet sein.");
                }
            }

            _pages[descriptor.Key] = descriptor with { ViewModelType = vmType };
        }

        foreach (var key in pageTypes.Keys)
        {
            if (!_pages.ContainsKey(key))
            {
                throw new InvalidOperationException($"[PageKey(\"{key}\")] ist kein Schluessel des Seitenregisters (siehe PageKeys).");
            }
        }
    }

    /// <summary>Register der Anwendungs-Assembly.</summary>
    public static PageRegistry CreateDefault() => new(typeof(PageRegistry).Assembly);

    /// <summary>Alle 43 Seiten in der Reihenfolge HS-01 bis HS-43.</summary>
    public IReadOnlyCollection<PageDescriptor> Pages => _pages.Values;

    /// <summary>Alle gefundenen Dialog-ViewModels (Schluessel zu Typ).</summary>
    public IReadOnlyDictionary<string, Type> Dialogs => _dialogs;

    public PageDescriptor Get(string key) =>
        _pages.TryGetValue(key, out var d) ? d : throw new KeyNotFoundException($"Unbekannter Seitenschluessel '{key}'.");

    public bool TryGet(string key, out PageDescriptor descriptor) => _pages.TryGetValue(key, out descriptor!);

    public bool TryGetDialogType(string dialogKey, out Type type) => _dialogs.TryGetValue(dialogKey, out type!);
}
