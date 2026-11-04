using ApaTec.Hmi.DesignData;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>Dummy: Beispielwerte des Bildes im Speicher; Zuruecksetzen und Limit aendern wirken auf diese Werte.</summary>
[DummyService]
public sealed class DummySystemInfoService : ISystemInfoService
{
    private SystemInfoSnapshot _info = SystemInfo_DesignData.CreateSnapshot();
    private List<DriveDiagnostics> _drives = SystemInfo_DesignData.CreateDrives();

    public event EventHandler? Changed;

    public SystemInfoSnapshot GetSystemInfo() => _info;

    public IReadOnlyList<DriveDiagnostics> GetDrives() => _drives.ToList();

    public void ResetCpuMax()
    {
        _info = _info with { CpuMax = _info.CpuCurrent };
        Changed?.Invoke(this, EventArgs.Empty);
    }

    public void ResetDriveCurrentMax(string driveId) => Update(driveId, d => d with { CurrentMax = 0 });

    public void SetDriveCurrentLimit(string driveId, double limit) => Update(driveId, d => d with { CurrentLimit = limit });

    private void Update(string driveId, Func<DriveDiagnostics, DriveDiagnostics> change)
    {
        _drives = _drives.Select(d => d.Id == driveId ? change(d) : d).ToList();
        Changed?.Invoke(this, EventArgs.Empty);
    }
}
