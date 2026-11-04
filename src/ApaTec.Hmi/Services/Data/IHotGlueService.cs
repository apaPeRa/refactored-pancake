using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>
/// Nordson-Heissleimgeraet (HS-07 bis HS-09; Konzept.md 6.6): Schalter, Zustands-LEDs, Temperaturzonen, Fuellstand, Einstellwerte und Druck.
/// Schreibende Aufrufe sind asynchron (Rueckmeldung des Geraets); die Zustandsabfrage liefert den zuletzt bestaetigten Stand.
/// </summary>
public interface IHotGlueService
{
    /// <summary>false bei gestoerter Kommunikation zum Geraet: Messwerte "---", LEDs unbekannt, Eingaben gesperrt.</summary>
    bool IsConnected { get; }

    bool GetSwitch(HotGlueSwitch hotGlueSwitch);

    /// <summary>Schaltet und kehrt zurueck, sobald das Geraet den Zustand zurueckmeldet (der bestaetigte Stand steht dann in <see cref="GetSwitch"/>).</summary>
    Task SetSwitchAsync(HotGlueSwitch hotGlueSwitch, bool on, CancellationToken cancellationToken = default);

    HotGlueLedState GetLed(HotGlueLed led);

    /// <summary>Fuellstand Tank in Prozent (0 bis 100); null = ungueltig.</summary>
    double? TankLevel { get; }

    /// <summary>Aktueller Systemdruck in bar; null = ungueltig.</summary>
    double? CurrentPressure { get; }

    /// <summary>Alle Temperaturzonen in der Reihenfolge Tank, Schlauch 1, Pistole 1, Schlauch 2, Pistole 2, Verteiler (konfigurationsabhaengig, OP-41).</summary>
    IReadOnlyList<HotGlueZone> Zones { get; }

    /// <summary>Zulaessiger Bereich der Zonen-Solltemperatur.</summary>
    HotGlueLimits ZoneSetpointLimits { get; }

    Task SetZoneSetpointAsync(string zoneId, double setpoint, CancellationToken cancellationToken = default);

    Task SetZoneEnabledAsync(string zoneId, bool enabled, CancellationToken cancellationToken = default);

    double GetParameter(HotGlueParameter parameter);

    HotGlueLimits GetLimits(HotGlueParameter parameter);

    Task SetParameterAsync(HotGlueParameter parameter, double value, CancellationToken cancellationToken = default);

    /// <summary>true, solange das Nachfuellen manuell angefordert wird (Taste "Manuell", solange sie berührt wird).</summary>
    bool IsManualFillActive { get; }

    Task SetManualFillAsync(bool requested, CancellationToken cancellationToken = default);

    /// <summary>Wenn sich ein Wert aendert (ggf. nicht im UI-Thread).</summary>
    event EventHandler? Changed;
}
