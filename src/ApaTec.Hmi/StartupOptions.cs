using System.Globalization;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Services;

namespace ApaTec.Hmi;

/// <summary>
/// Startparameter der Anwendung (Meilenstein 3, A-99): <c>--page=&lt;PageKey&gt;</c>, <c>--dialog=&lt;DialogKey&gt;</c>, <c>--theme=light|dark</c>,
/// <c>--culture=de-DE</c>, <c>--role=operator|technician|service</c>, <c>--designdata</c>. Unbekannte oder fehlerhafte Werte erzeugen eine Warnung
/// (Ausgabefenster / Konsole) und werden ignoriert; die Anwendung startet dann mit dem Standard. Schreibweise der Namen und Werte ist unerheblich.
/// </summary>
public sealed class StartupOptions
{
    /// <summary>Seitenschluessel, auf dem die Anwendung startet (null = HS-01).</summary>
    public string? Page { get; private set; }

    /// <summary>Dialogschluessel (oder Pop-up-Seite HS-02/HS-03), der nach dem Start geoeffnet wird.</summary>
    public string? Dialog { get; private set; }

    public ThemeMode? Theme { get; private set; }

    public CultureInfo? Culture { get; private set; }

    public UserRole? Role { get; private set; }

    /// <summary>Dummy-Zustandsvarianten anfordern (derzeit ohne Wirkung: es gibt keine Laufzeit-Zustandsvarianten, A-99).</summary>
    public bool DesignData { get; private set; }

    /// <summary>Hinweise zu nicht erkannten Parametern.</summary>
    public List<string> Warnings { get; } = new();

    public static StartupOptions Parse(IEnumerable<string> args)
    {
        var options = new StartupOptions();
        foreach (var arg in args)
        {
            if (!arg.StartsWith("--", StringComparison.Ordinal))
            {
                continue; // Argumente des Generic Hosts (z. B. Umgebungsvariablen) bleiben unberuehrt.
            }

            var separator = arg.IndexOf('=');
            var name = (separator < 0 ? arg[2..] : arg[2..separator]).ToLowerInvariant();
            var value = separator < 0 ? string.Empty : arg[(separator + 1)..].Trim().Trim('"');

            switch (name)
            {
                case "page":
                    options.Page = NullIfEmpty(value, options, arg);
                    break;
                case "dialog":
                    options.Dialog = NullIfEmpty(value, options, arg);
                    break;
                case "theme":
                    switch (value.ToLowerInvariant())
                    {
                        case "light":
                            options.Theme = ThemeMode.Light;
                            break;
                        case "dark":
                            options.Theme = ThemeMode.Dark;
                            break;
                        default:
                            options.Warnings.Add($"Ungueltiges Thema '{value}' (erlaubt: light, dark).");
                            break;
                    }

                    break;
                case "culture":
                    try
                    {
                        options.Culture = CultureInfo.GetCultureInfo(value);
                    }
                    catch (CultureNotFoundException)
                    {
                        options.Warnings.Add($"Unbekannte Kultur '{value}'.");
                    }

                    break;
                case "role":
                    switch (value.ToLowerInvariant())
                    {
                        case "operator":
                            options.Role = UserRole.Operator;
                            break;
                        case "technician":
                            options.Role = UserRole.Technician;
                            break;
                        case "service":
                            options.Role = UserRole.Service;
                            break;
                        default:
                            options.Warnings.Add($"Ungueltige Rolle '{value}' (erlaubt: operator, technician, service).");
                            break;
                    }

                    break;
                case "designdata":
                    options.DesignData = separator < 0 || !string.Equals(value, "false", StringComparison.OrdinalIgnoreCase);
                    break;
            }
        }

        return options;
    }

    private static string? NullIfEmpty(string value, StartupOptions options, string arg)
    {
        if (value.Length == 0)
        {
            options.Warnings.Add($"Parameter '{arg}' ohne Wert.");
            return null;
        }

        return value;
    }
}
