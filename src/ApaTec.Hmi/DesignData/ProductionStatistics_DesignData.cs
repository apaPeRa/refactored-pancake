using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.DesignData;

/// <summary>Beispielwerte fuer HS-29 Produktionsstatistik (RS-29_01): 48 Halbstundenbalken, nach 18 leeren die Bildwerte, dann wieder leer; hoechster Balken 1761 (OP-29).</summary>
public static class ProductionStatistics_DesignData
{
    public const int IntervalMinutes = 30;

    public const int SlotCount = 48;

    /// <summary>Zahl der abrufbaren Tage: heute und 29 Vortage (K29-4).</summary>
    public const int HistoryDays = 30;

    private const int LeadingEmptySlots = 18;

    private static readonly double[] ImageValues = { 63, 802, 624, 591, 449, 0, 41, 0, 226, 208, 839, 353, 450, 447, 1761, 294, 56 };

    /// <summary>Werte des Bildes (Tag "heute") als Reihe der Laenge <see cref="SlotCount"/>.</summary>
    public static IReadOnlyList<double?> TodayValues { get; } = Enumerable.Range(0, SlotCount)
        .Select(i => i >= LeadingEmptySlots && i < LeadingEmptySlots + ImageValues.Length ? (double?)ImageValues[i - LeadingEmptySlots] : 0d)
        .ToList();

    public static ProductionDayStatistics Today { get; } = new(DateTime.Today, TodayValues, IntervalMinutes);
}
