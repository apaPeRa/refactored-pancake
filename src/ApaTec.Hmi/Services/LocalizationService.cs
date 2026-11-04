using System.Globalization;
using System.Resources;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ApaTec.Hmi.Services;

/// <summary>
/// Liest <c>Resources/Strings.resx</c> (Neutralsprache Deutsch), weitere <c>Strings.&lt;Kultur&gt;.resx</c> und alle Paketdateien <c>Resources/Strings/&lt;Paket&gt;.resx</c>.
/// Die Indexer-Bindung (<c>Item[]</c>) macht die Sprachumschaltung zur Laufzeit in XAML wirksam (siehe <c>LocExtension</c>).
/// </summary>
public sealed class LocalizationService : ObservableObject, ILocalizationService
{
    private static readonly Lazy<LocalizationService> LazyInstance = new(() => new LocalizationService());

    private const string BaseNamePrefix = "ApaTec.Hmi.Resources.Strings";
    private const string ResourcesSuffix = ".resources";

    private readonly IReadOnlyList<ResourceManager> _resources = DiscoverResources();
    private CultureInfo _culture = CultureInfo.GetCultureInfo("de-DE");

    private LocalizationService()
    {
    }

    /// <summary>Gemeinsame Instanz fuer XAML (<c>LocExtension</c>) und Dependency Injection.</summary>
    public static LocalizationService Instance => LazyInstance.Value;

    public CultureInfo Culture => _culture;

    public IReadOnlyList<CultureInfo> SupportedCultures { get; } = new[] { CultureInfo.GetCultureInfo("de-DE") };

    public event EventHandler? CultureChanged;

    public string this[string key] => GetString(key);

    public string GetString(string key)
    {
        foreach (var manager in _resources)
        {
            var value = manager.GetString(key, _culture);
            if (value is not null)
            {
                return value;
            }
        }

        return $"!{key}!";
    }

    public string Format(string key, params object?[] args) => string.Format(_culture, GetString(key), args);

    // Strings.resx plus alle Resources/Strings/<Paket>.resx: eingebettete Ressourcen, deren Name mit ApaTec.Hmi.Resources.Strings beginnt.
    private static IReadOnlyList<ResourceManager> DiscoverResources()
    {
        var assembly = typeof(LocalizationService).Assembly;
        return assembly.GetManifestResourceNames()
            .Where(n => n.StartsWith(BaseNamePrefix, StringComparison.Ordinal) && n.EndsWith(ResourcesSuffix, StringComparison.Ordinal))
            .Select(n => new ResourceManager(n[..^ResourcesSuffix.Length], assembly))
            .ToList();
    }

    public void SetCulture(CultureInfo culture)
    {
        _culture = culture;
        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
        OnPropertyChanged(nameof(Culture));
        OnPropertyChanged("Item[]");
        CultureChanged?.Invoke(this, EventArgs.Empty);
    }
}
