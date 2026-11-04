namespace ApaTec.Hmi.Models;

/// <summary>Einstellbare Werte der Kontrollwaage (HS-13): Zielgewichte, Tara, automatischer Nullpunkt und Grenzwerte.</summary>
public enum CheckWeigherParameter
{
    TargetWeight,
    Tare,
    AutoZeroInterval,
    OverWeight,
    Under1,
    Under2,
}

/// <summary>Anzeigewerte der Kontrollwaage; <c>null</c> = ungueltig oder Waage nicht erreichbar (Anzeige "---").</summary>
public sealed record CheckWeigherReading(double? Net, double? Gross, double? Live, double? Mean, double? StdDev, double? Performance);

/// <summary>Einstellwerte der Kontrollwaage (Gramm bzw. Stueck). <see cref="PacksSinceZero"/> ist der Zusatzzaehler des automatischen Nullpunkts.</summary>
public sealed record CheckWeigherSettings(
    double TargetWeight,
    double Tare,
    int AutoZeroInterval,
    int PacksSinceZero,
    double OverWeight,
    double Under1,
    double Under2);

/// <summary>Zaehler der Kontrollwaage seit dem letzten "Zaehler loeschen"; <see cref="Under1Percent"/> ist die Kennzahl "T1 %" (Einheit offen, OP-29).</summary>
public sealed record CheckWeigherCounters(int Over, int Under1, int Under2, int Good, int Bad, double? Under1Percent);

/// <summary>Gesamtzustand der Kontrollwaage fuer HS-13.</summary>
public sealed record CheckWeigherSnapshot(bool IsConnected, CheckWeigherReading Reading, CheckWeigherSettings Settings, CheckWeigherCounters Counters);

/// <summary>Zulaessiger Wertebereich eines Einstellwerts (konfigurierbarer Dummy-Wert, OP-28).</summary>
public sealed record ParameterLimits(double Minimum, double Maximum);

/// <summary>Ein erfasstes Einzelgewicht in Gramm mit Guete (gut/schlecht).</summary>
public sealed record WeightSample(double Weight, bool IsGood);

/// <summary>
/// Messreihe der Einzelgewichte (HS-14): <see cref="Samples"/> hat immer <see cref="Capacity"/> Eintraege in Anzeigereihenfolge (zeilenweise),
/// <c>null</c> = leere Zelle. <see cref="LastIndex"/> ist die zuletzt erfasste Zelle (-1 = keine). Mittelwert und Standardabweichung ueber die vorhandenen Werte.
/// </summary>
public sealed record SingleWeightSeries(
    IReadOnlyList<WeightSample?> Samples,
    int LastIndex,
    bool IsContinuous,
    int Capacity,
    double? Mean,
    double? StdDev);
