using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.DesignData;

/// <summary>Beispielwerte HS-25 (Bild RS-25_01, Nocke 12) und HS-26 (Bild RS-26_01, Nr. 40 bis 59). Schreibweise der Bezeichnungen korrigiert (S26-4, OP-35).</summary>
public static class CamsDesignData
{
    public static readonly string[] Encoders = { "Geber 1GF Hauptantrieb", "Geber 2GF Auslaufband", "Geber 3GF Nachdosierer" };

    public static CamDetail Sample { get; } = new(12, 330, 50, 790, 50, 3, 0, "Karton ansaugen 1 3KY40");

    public static IReadOnlyList<CamSummary> Overview { get; } = new CamSummary[]
    {
        new(40, "Start Hauptdosierer 1", 290, 130, false),
        new(41, "Start Hauptdosierer 2", 290, 130, false),
        new(42, "Wiegen Kontrollwaage", 40, 110, false),
        new(43, "Wiegen Endkontrollwaage", 40, 110, false),
        new(44, "Blasluft Fehlpaket 14KY23", 290, 20, false),
        new(45, "Fehlpaketausstoß verriegeln 14KY21", 200, 140, true),
        new(46, "Fehlpaketausstoß vorne 14B10", 10, 35, false),
        new(47, "Fehlpaketausstoß hinten 14B10", 120, 284, true),
        new(48, string.Empty, 0, 0, false),
        new(49, "Start Nachdosierer", 260, 130, false),
        new(50, string.Empty, 0, 0, false),
        new(51, "Tastung Kopfleim 20B61", 35, 45, false),
        new(52, "Kopfleim 20KY21", 280, 325, false),
        new(53, "Ausstoßer Auslauf vorne 20B71", 45, 60, false),
        new(54, "Ausstoßer Auslauf hinten 20B71", 120, 310, true),
        new(55, "Paket schließen 20KY22", 280, 60, false),
        new(56, "Blasluft Stempel 20KY23", 75, 130, false),
        new(57, "Siegelbacken Abheben Vorsiegeln 20KY31", 310, 140, true),
        new(58, "Siegelbacken Abheben Hauptsiegeln 20KY32", 310, 140, true),
        new(59, string.Empty, 0, 0, false),
    };
}
