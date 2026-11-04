using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.DesignData;

/// <summary>Beispielwerte fuer HM-26 (Trend der letzten Gewichte HS-15, Tagesbalken HS-29).</summary>
public static class HM26_DesignData
{
    private static readonly double?[] TrendValues =
    {
        235.2, 235.5, 235.0, 235.9, 236.1, 235.4, 235.7, 235.3, 234.6, 235.1, 235.8,
        235.6, 235.0, null, 235.2, 235.9, 236.4, 235.5, 235.3, 235.7, 235.8,
    };

    private static readonly double[] BarValues =
    {
        0, 0, 0, 0, 0, 0, 120, 640, 980, 1250, 1410, 1520, 1100, 1390, 1480, 1600, 1210, 760, 0, 0, 0, 0, 0, 0,
    };

    public static IReadOnlyList<ChartPoint> TrendSeries { get; } =
        TrendValues.Select((v, i) => new ChartPoint((i - 20).ToString(System.Globalization.CultureInfo.InvariantCulture), v)).ToList();

    public static IReadOnlyList<string> TrendLabels { get; } =
        Enumerable.Range(0, 21).Select(i => (i - 20).ToString(System.Globalization.CultureInfo.InvariantCulture)).ToList();

    public static IReadOnlyList<ChartPoint> BarSeries { get; } =
        BarValues.Select((v, i) => new ChartPoint($"{i}:00", v)).ToList();

    public static IReadOnlyList<string> BarLabels { get; } =
        Enumerable.Range(0, 24).Select(i => $"{i}:00").ToList();

    public static IReadOnlyList<ChartPoint> NoSeries { get; } = Array.Empty<ChartPoint>();
}
