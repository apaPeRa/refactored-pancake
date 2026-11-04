using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>Die fuenf Geschwindigkeiten Maximum, Schnell, Langsam, Tippen, Minimum in 1/min (HS-03, Konzept.md 6.6).</summary>
public interface IMachineSpeedService
{
    double GetSpeed(MachineSpeedKind kind);

    /// <summary>Zulaessiger Bereich fuer die Eingabe: Minimum &lt;= Tippen &lt;= Langsam und Schnell &lt;= Maximum (S03-2, OP-28).</summary>
    MachineSpeedLimits GetLimits(MachineSpeedKind kind);

    /// <summary>Schreibt den Wert sofort (ohne "Werte schreiben"); false bei Wert ausserhalb der Grenzen oder Schreibfehler der Maschine (der zuletzt gueltige Wert bleibt).</summary>
    Task<bool> SetSpeedAsync(MachineSpeedKind kind, double value);

    /// <summary>Wenn sich ein Wert aendert (ggf. nicht im UI-Thread).</summary>
    event EventHandler? Changed;
}
