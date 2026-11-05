using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApaTec.Hmi;

/// <summary>Einstiegspunkt und Composition Root (A-74): Generic Host mit Dienstregistrierung per Assembly-Scan, dann WPF-Anwendung starten.</summary>
public static class Program
{
    [STAThread]
    public static int Main(string[] args)
    {
        // Startparameter (--page, --dialog, --theme, --culture, --role, --designdata), siehe StartupOptions und src/README.md.
        var options = StartupOptions.Parse(args);
        foreach (var warning in options.Warnings)
        {
            System.Diagnostics.Debug.WriteLine($"[Start] {warning}");
            Console.Error.WriteLine($"[Start] {warning}");
        }

        // App-Kultur (Standard de-DE: Dezimalkomma, Datum/Zeit): fuer alle Threads und fuer die Sprache der WPF-Elemente (sonst en-US bei Bindungen mit StringFormat).
        var culture = options.Culture ?? System.Globalization.CultureInfo.GetCultureInfo("de-DE");
        System.Globalization.CultureInfo.CurrentCulture = culture;
        System.Globalization.CultureInfo.CurrentUICulture = culture;
        System.Globalization.CultureInfo.DefaultThreadCurrentCulture = culture;
        System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = culture;
        System.Windows.FrameworkElement.LanguageProperty.OverrideMetadata(
            typeof(System.Windows.FrameworkElement),
            new System.Windows.FrameworkPropertyMetadata(System.Windows.Markup.XmlLanguage.GetLanguage(culture.IetfLanguageTag)));

        using var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services => services.AddApaTecHmi())
            .Build();

        var services = host.Services;

        // Gespeicherte Einstellungen anwenden: Sprache und Thema.
        var settings = services.GetRequiredService<ISettingsService>();
        if (options.Culture is not null)
        {
            settings.Language = options.Culture.Name;
        }

        if (options.Theme is { } theme)
        {
            settings.Theme = theme;
        }

        services.GetRequiredService<ILocalizationService>().SetCulture(System.Globalization.CultureInfo.GetCultureInfo(settings.Language));

        // Dummy-Sitzung mit der gewuenschten Rolle (Standard: Bediener, A-96).
        if (options.Role is { } role)
        {
            services.GetRequiredService<IUserSession>().SignIn(role);
        }

        var app = new App();
        ControlResources.MergeAll(app);
        services.GetRequiredService<IThemeService>().SetTheme(settings.Theme);

        var window = services.GetRequiredService<MainWindow>();
        window.DataContext = services.GetRequiredService<ShellViewModel>();

        // Start in den Pfad HS-01 (Startseite).
        var navigation = services.GetRequiredService<INavigationService>();
        navigation.GoHome();

        // Direktstart auf Seite oder Dialog nach dem Laden des Fensters (die Dispatcher-Schleife laeuft dann; Dialoge und Rollenabfragen sind moeglich).
        if (options.Page is not null || options.Dialog is not null)
        {
            window.Loaded += async (_, _) => await OpenRequestedAsync(services, navigation, options);
        }

        return app.Run(window);
    }

    private static async Task OpenRequestedAsync(IServiceProvider services, INavigationService navigation, StartupOptions options)
    {
        try
        {
            var registry = services.GetRequiredService<PageRegistry>();

            if (options.Page is not null)
            {
                if (TryResolvePage(registry, options.Page, out var descriptor))
                {
                    if (descriptor.Key != PageKeys.Start && !await navigation.NavigateToAsync(descriptor.Key))
                    {
                        Warn($"Seite '{descriptor.Key}' wurde abgelehnt (Rolle, Verlassen-Rueckfrage oder offenes Pop-up).");
                    }
                }
                else
                {
                    Warn($"Unbekannter Seitenschluessel '{options.Page}'.");
                }
            }

            if (options.Dialog is not null)
            {
                if (TryResolveDialog(registry, options.Dialog, out var dialogKey, out var popupPage))
                {
                    if (popupPage)
                    {
                        await navigation.NavigateToAsync(dialogKey);
                    }
                    else
                    {
                        await services.GetRequiredService<IDialogService>().ShowAsync<object>(dialogKey, SampleParameter(dialogKey));
                    }
                }
                else
                {
                    Warn($"Unbekannter Dialogschluessel '{options.Dialog}'.");
                }
            }
        }
        catch (Exception ex)
        {
            Warn($"Direktstart fehlgeschlagen: {ex.Message}");
        }
    }

    private static bool TryResolvePage(PageRegistry registry, string name, out PageDescriptor descriptor)
    {
        foreach (var candidate in PageCatalog.All)
        {
            if (string.Equals(candidate.Key, name, StringComparison.OrdinalIgnoreCase) && registry.TryGet(candidate.Key, out descriptor))
            {
                return true;
            }
        }

        descriptor = null!;
        return false;
    }

    // Dialogschluessel (DialogKeys, PostDoserHints) oder Pop-up-Seite (HS-02, HS-03) in beliebiger Schreibweise.
    private static bool TryResolveDialog(PageRegistry registry, string name, out string key, out bool popupPage)
    {
        foreach (var field in typeof(DialogKeys).GetFields().Where(f => f.IsLiteral).Select(f => (string)f.GetRawConstantValue()!).Append(PostDoserHintsViewModel.DialogKey))
        {
            if (string.Equals(field, name, StringComparison.OrdinalIgnoreCase))
            {
                key = field;
                popupPage = false;
                return true;
            }
        }

        if (TryResolvePage(registry, name, out var descriptor) && descriptor.Kind == PageKind.Popup)
        {
            key = descriptor.Key;
            popupPage = true;
            return true;
        }

        key = string.Empty;
        popupPage = false;
        return false;
    }

    // Beispielwerte fuer Dialoge, die ohne Parameter leer wirken wuerden.
    private static object? SampleParameter(string dialogKey) => dialogKey == DialogKeys.Input
        ? new NavigationParameters("title", "Beispielwert").With("currentValue", 50.0).With("unit", "%").With("minimum", 0.0).With("maximum", 100.0).With("decimals", 0)
        : null;

    private static void Warn(string text)
    {
        System.Diagnostics.Debug.WriteLine($"[Start] {text}");
        Console.Error.WriteLine($"[Start] {text}");
    }
}
