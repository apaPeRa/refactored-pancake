namespace ApaTec.Hmi.DesignData;

/// <summary>Beispielwerte HS-22 aus dem Bild RS-22_01: zwoelf Zonen, 150 Grad (1 bis 8), 170 Grad (9 bis 12), Ist 0.</summary>
public static class HeatersDesignData
{
    public static readonly string[] ZoneNames =
    {
        "6E1 Längsnaht Links Zone 1", "6E1 Längsnaht Links Zone 2", "6E1 Längsnaht Links Zone 3", "6E2 Längsnaht Rechts",
        "6E3 Boden Oben Vorsiegeln", "6E4 Boden Unten Vorsiegeln", "6E4 Boden Oben Fertigsiegeln", "6E4 Boden Unten Fertigsiegeln",
        "20E1 Kopf Vorsiegeln Hinten", "20E2 Kopf Vorsiegeln Vorne", "20E3 Kopf Fertigsiegeln Hinten", "20E4 Kopf Fertigsiegeln Vorne",
    };

    public static double SetpointOf(int index) => index < 8 ? 150 : 170;
}
