using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.DesignData;

/// <summary>Beispielwerte HS-23 aus dem Bild RS-23_01 (Hauptdosierer / Nachdosierer).</summary>
public static class RegulationDesignData
{
    public static RegulationSettings Main { get; } = new(10, 50.0, 1.0, 75.0, 0.0, 0.0, 0, false);

    public static RegulationSettings Post { get; } = new(15, 50.0, 0.2, 20.0, 4.8, 250.4, 11, true);
}
