using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>IPC- und Antriebsdiagnose (HS-39; Konzept.md 6.6).</summary>
public interface ISystemInfoService
{
    SystemInfoSnapshot GetSystemInfo();

    IReadOnlyList<DriveDiagnostics> GetDrives();

    /// <summary>Maximale CPU-Auslastung zuruecksetzen (auf den aktuellen Wert).</summary>
    void ResetCpuMax();

    /// <summary>Strom Max des Antriebs auf 0 zuruecksetzen.</summary>
    void ResetDriveCurrentMax(string driveId);

    void SetDriveCurrentLimit(string driveId, double limit);

    event EventHandler? Changed;
}
