using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.DesignData;

/// <summary>Beispielwerte fuer HS-27 Waagen kalibrieren (RS-27_01: "16KW1 Kontrollwaage", -398,9 g, Filter "IIR 5 56ms 8Hz"). Zahl und Namen der Waagen sind Annahmen (OP-41).</summary>
public static class ScaleCalibration_DesignData
{
    /// <summary>Filterliste (konfigurationsabhaengig, offen); der erste Eintrag stammt aus dem Bild, die weiteren aus HM-18.</summary>
    public static IReadOnlyList<string> Filters { get; } = new[] { "IIR 5 56ms 8Hz", "IIR 3 28ms 16Hz", "IIR 7 112ms 4Hz" };

    /// <summary>Index des Filters, dessen Schreiben im Dummy fehlschlaegt (zeigt den Fehlerfall der Statusanzeige).</summary>
    public const int FailingFilterIndex = 2;

    public static IReadOnlyList<ScaleSnapshot> Scales { get; } = new[]
    {
        new ScaleSnapshot(0, "16KW1 Kontrollwaage", -398.9, 0, CalibrationStep.Idle, false),
        new ScaleSnapshot(1, "16KW2 Kontrollwaage", 0.4, 1, CalibrationStep.Idle, false),
    };
}
