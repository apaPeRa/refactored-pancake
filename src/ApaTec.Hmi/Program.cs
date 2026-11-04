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
        using var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services => services.AddApaTecHmi())
            .Build();

        var services = host.Services;

        // Gespeicherte Einstellungen anwenden: Sprache und Thema.
        var settings = services.GetRequiredService<ISettingsService>();
        services.GetRequiredService<ILocalizationService>().SetCulture(System.Globalization.CultureInfo.GetCultureInfo(settings.Language));

        var app = new App();
        ControlResources.MergeAll(app);
        services.GetRequiredService<IThemeService>().SetTheme(settings.Theme);

        var window = services.GetRequiredService<MainWindow>();
        window.DataContext = services.GetRequiredService<ShellViewModel>();

        // Start in den Pfad HS-01 (Startseite).
        services.GetRequiredService<INavigationService>().GoHome();

        return app.Run(window);
    }
}
