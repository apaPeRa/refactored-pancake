using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>
/// Kalibrierung der verbauten Waagen (HS-27, Konzept.md 6.6 Zeile "Waagen"). Eigene Schnittstelle neben <see cref="IScaleService"/> (HS-13 bis HS-15),
/// damit beide Seitenpakete unabhaengig arbeiten; ein Zusammenfuehren ist im Integrationsschritt moeglich. Befehle wirken in M2 nur auf Dummy-Daten.
/// </summary>
public interface IScaleCalibrationService
{
    /// <summary>Zahl der verbauten Waagen (OP-41).</summary>
    int ScaleCount { get; }

    /// <summary>Waehlbare digitale Filter (konfigurationsabhaengig, offen).</summary>
    IReadOnlyList<string> FilterTypes { get; }

    /// <summary>Aktueller Zustand der Waage.</summary>
    ScaleSnapshot GetSnapshot(int scaleIndex);

    /// <summary>Schreibt den Filtertyp (Index in <see cref="FilterTypes"/>).</summary>
    Task<ScaleOperationResult> SetFilterAsync(int scaleIndex, int filterIndex);

    /// <summary>Setzt den Nullpunkt (nur bei unbelasteter Waage sinnvoll, keine Sperre).</summary>
    Task<ScaleOperationResult> SetZeroAsync(int scaleIndex);

    /// <summary>Startet den Kalibriervorgang.</summary>
    Task<ScaleOperationResult> StartCalibrationAsync(int scaleIndex);

    /// <summary>Taste "Entlastet".</summary>
    Task<ScaleOperationResult> ConfirmUnloadedAsync(int scaleIndex);

    /// <summary>Taste "Belastet".</summary>
    Task<ScaleOperationResult> ConfirmLoadedAsync(int scaleIndex);

    /// <summary>Bricht den Vorgang ab, setzt Zwischenschritte zurueck und quittiert Fehler der Waage.</summary>
    Task<ScaleOperationResult> ResetAsync(int scaleIndex);

    /// <summary>Wenn sich eine Waage aendert (Parameter = Index; ggf. nicht im UI-Thread).</summary>
    event EventHandler<int>? Changed;
}
