namespace ApaTec.Hmi.Models;

/// <summary>IPC-Kennwerte der Seite System- und Antriebsinfos (HS-39, RS-39 Tabelle 49).</summary>
public sealed record SystemInfoSnapshot(
    double CpuCurrent,
    double CpuMax,
    DateTime SystemStart,
    TimeSpan TotalRuntime,
    string StatusText,
    string DiagText,
    DateTime BuildTime);

/// <summary>Diagnose eines Servoantriebs (HS-39, RS-39 Tabelle 50). Strom in Prozent; <see cref="Message"/> null = keine Meldung.</summary>
public sealed record DriveDiagnostics(
    string Id,
    string Name,
    int DiagCode,
    double CurrentActual,
    double CurrentMax,
    double CurrentLimit,
    string? Message);
