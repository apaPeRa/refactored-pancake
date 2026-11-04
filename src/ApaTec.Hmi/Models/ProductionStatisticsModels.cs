namespace ApaTec.Hmi.Models;

/// <summary>Produktionsverlauf eines Tages (HS-29).</summary>
/// <param name="Date">Datum des Tages.</param>
/// <param name="Values">Balkenwerte ab 0:00 Uhr; null = ungueltiger Wert. Die Zahl folgt der Datenreihe der Steuerung (K29-1).</param>
/// <param name="IntervalMinutes">Dauer eines Balkens in Minuten (Annahme 30, OP-29).</param>
public sealed record ProductionDayStatistics(DateTime Date, IReadOnlyList<double?> Values, int IntervalMinutes);
