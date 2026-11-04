using System.Windows;

namespace ApaTec.Hmi.Services;

/// <summary>
/// Tauscht das Theme-Dictionary (<c>Themes/Theme.Light.xaml</c> oder <c>Themes/Theme.Dark.xaml</c>) in den Anwendungsressourcen aus.
/// Alle Brush-Verweise muessen <c>DynamicResource</c> verwenden, sonst wirkt die Umschaltung nicht.
/// </summary>
public sealed class ThemeService : IThemeService
{
    private const string ThemePathMarker = "Themes/Theme.";

    public ThemeMode Current { get; private set; } = ThemeMode.Light;

    public event EventHandler<ThemeMode>? ThemeChanged;

    public void SetTheme(ThemeMode mode)
    {
        var app = Application.Current;
        if (app is null)
        {
            Current = mode;
            return;
        }

        var file = mode == ThemeMode.Dark ? "Theme.Dark.xaml" : "Theme.Light.xaml";
        var replacement = new ResourceDictionary
        {
            Source = new Uri($"pack://application:,,,/ApaTec.Hmi;component/Themes/{file}", UriKind.Absolute),
        };

        var dictionaries = app.Resources.MergedDictionaries;
        var index = -1;
        for (var i = 0; i < dictionaries.Count; i++)
        {
            var source = dictionaries[i].Source?.OriginalString;
            if (source is not null && source.Contains(ThemePathMarker, StringComparison.OrdinalIgnoreCase))
            {
                index = i;
                break;
            }
        }

        if (index >= 0)
        {
            dictionaries[index] = replacement;
        }
        else
        {
            dictionaries.Insert(0, replacement);
        }

        Current = mode;
        ThemeChanged?.Invoke(this, mode);
    }

    public void Toggle() => SetTheme(Current == ThemeMode.Light ? ThemeMode.Dark : ThemeMode.Light);
}
