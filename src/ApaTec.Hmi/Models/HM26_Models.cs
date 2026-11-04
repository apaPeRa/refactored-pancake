namespace ApaTec.Hmi.Models;

/// <summary>Diagrammart (HM-26): Linie (Trend) oder Balken.</summary>
public enum ChartKind
{
    Line,
    Bar,
}

/// <summary>Intervall der Balken (HM-26, OP-29, OP-54).</summary>
public enum ChartInterval
{
    None,
    Hour,
    HalfHour,
}

/// <summary>Messpunkt (HM-26): X-Beschriftung und Y-Wert; <c>Y = null</c> bedeutet ungueltiger Wert (Luecke, Text „---“).</summary>
public sealed record ChartPoint(string X, double? Y);
