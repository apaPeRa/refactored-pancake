using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.DesignData;

/// <summary>Beispielwerte HS-39 (Bild RS-39_01). Zwei weitere Antriebe (Annahme) zeigen das Blaettern; Anzahl und Namen sind konfigurationsabhaengig (OP-41).</summary>
public static class SystemInfo_DesignData
{
    public static SystemInfoSnapshot CreateSnapshot() => new(
        CpuCurrent: 15,
        CpuMax: 42,
        SystemStart: new DateTime(2025, 4, 2, 1, 22, 42),
        TotalRuntime: new TimeSpan(744, 1, 14),
        StatusText: "5 - running",
        DiagText: "0 (0x000) - No Error",
        BuildTime: new DateTime(2025, 5, 9, 10, 42, 17));

    public static List<DriveDiagnostics> CreateDrives() => new()
    {
        new("2MA1", "Antrieb Zuführung 2MA1", 0, 0.0, -24.4, 100.0, "Motorschutz ausgelöst"),
        new("41MA1", "Verschluss Dosierer 1 41MA1", 0, 0.0, -17.5, 500.0, "Motorschutz ausgelöst"),
        new("41MA2", "Schnecke Dosierer 1 41MA2", 0, 0.0, 20.3, 100.0, "Motorschutz ausgelöst"),
        new("42MA1", "Verschluss Dosierer 2 42MA1", 0, 0.0, -9.6, 500.0, "Motorschutz ausgelöst"),
        new("3MA1", "Antrieb Auslauf 3MA1", 0, 12.5, 20.3, 100.0, null),
        new("4MA1", "Antrieb Querschnecke 4MA1", 0, 8.0, 15.2, 100.0, null),
    };
}
