using System.Reflection;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace ApaTec.Hmi.Services;

/// <summary>Dienstregistrierung per Assembly-Scan; parallel arbeitende Agenten legen nur eigene Dateien an (keine gemeinsame Registrierungsdatei).</summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registriert: Navigation, Dialog, Thema, Lokalisierung (explizit); alle Dummy-Dienste (<see cref="DummyServiceAttribute"/> oder Name <c>*Dummy*Service</c>)
    /// fuer ihre Schnittstellen dieser Assembly (Singleton); alle Seiten- und Dialog-ViewModels mit <see cref="PageKeyAttribute"/>/<see cref="DialogKeyAttribute"/> (transient).
    /// </summary>
    public static IServiceCollection AddApaTecHmi(this IServiceCollection services)
    {
        var assembly = typeof(ServiceCollectionExtensions).Assembly;

        services.AddSingleton(PageRegistry.CreateDefault());
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<IDialogService, DialogService>();
        services.AddSingleton<IThemeService, ThemeService>();
        services.AddSingleton<ILocalizationService>(LocalizationService.Instance);

        foreach (var type in assembly.GetTypes())
        {
            if (type.IsAbstract || !type.IsClass)
            {
                continue;
            }

            if (IsDummyService(type))
            {
                var interfaces = type.GetInterfaces().Where(i => i.Assembly == assembly).ToArray();
                if (interfaces.Length == 0)
                {
                    throw new InvalidOperationException($"Dummy-Dienst {type.FullName} implementiert keine Schnittstelle dieser Assembly.");
                }

                // Eine Instanz je Klasse, fuer jede Schnittstelle dieselbe.
                services.AddSingleton(type);
                foreach (var contract in interfaces)
                {
                    services.AddSingleton(contract, sp => sp.GetRequiredService(type));
                }
            }
            else if ((type.IsDefined(typeof(PageKeyAttribute), false) || type.IsDefined(typeof(DialogKeyAttribute), false))
                     && (typeof(PageViewModelBase).IsAssignableFrom(type) || typeof(PopupViewModelBase).IsAssignableFrom(type)))
            {
                services.AddTransient(type);
            }
        }

        services.AddSingleton<ShellViewModel>();
        services.AddTransient<MainWindow>();
        return services;
    }

    private static bool IsDummyService(Type type) =>
        type.IsDefined(typeof(DummyServiceAttribute), false)
        || (type.Name.Contains("Dummy", StringComparison.Ordinal) && type.Name.EndsWith("Service", StringComparison.Ordinal));
}
