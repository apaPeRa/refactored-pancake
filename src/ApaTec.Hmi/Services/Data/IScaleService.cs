using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>
/// Waagen (Konzept.md 6.6): Kontrollwaage, Einzelgewichte und Trend (HS-13 bis HS-15). Die Kalibrierung (HS-27) wird von dessen Seitenpaket
/// in dieser Schnittstelle ergaenzt. Befehle wirken in M2 nur auf Dummy-Daten, nicht auf eine Maschine.
/// </summary>
public interface IScaleService
{
    /// <summary>Anzahl der Positionen des Trends (20 zurueckliegende plus aktueller Wert, OP-32).</summary>
    int TrendPointCount { get; }

    /// <summary>Aktueller Zustand der Kontrollwaage (HS-13).</summary>
    CheckWeigherSnapshot GetCheckWeigher();

    /// <summary>Zulaessiger Bereich eines Einstellwerts (Dummy, OP-28).</summary>
    ParameterLimits GetLimits(CheckWeigherParameter parameter);

    /// <summary>Schreibt einen Einstellwert (Wert muss in <see cref="GetLimits"/> liegen).</summary>
    void SetParameter(CheckWeigherParameter parameter, double value);

    /// <summary>Setzt den Waagen-Nullpunkt neu.</summary>
    Task SetZeroAsync();

    /// <summary>Setzt Gut, Schlecht und die Zaehler zu Uebergewicht, TU 1 und TU 2 auf 0 (Auslegung S13-3).</summary>
    Task ResetCountersAsync();

    /// <summary>Letzte Einzelgewichte (HS-14).</summary>
    SingleWeightSeries GetSingleWeights();

    /// <summary>Wechselt den Messmodus (true = fortlaufend, false = einzel).</summary>
    Task SetSamplingModeAsync(bool continuous);

    /// <summary>Beginnt einen neuen Messdurchlauf; im Modus Einzel werden alle bisherigen Werte geloescht.</summary>
    Task StartSamplingAsync();

    /// <summary>Letzte Gewichte fuer den Trend (HS-15), aeltester Wert zuerst, <c>null</c> = ungueltiger Wert.</summary>
    IReadOnlyList<double?> GetTrend();

    /// <summary>Wenn sich Werte aendern (ggf. nicht im UI-Thread).</summary>
    event EventHandler? Changed;
}
