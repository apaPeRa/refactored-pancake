using ApaTec.Hmi.DesignData;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>Beispielwerte aus dem Design: Produktion, 112 1/min, 245 Grad (keine Maschinenanbindung).</summary>
[DummyService]
public sealed class DummyMachineStatusService : IMachineStatusService
{
    public OperatingMode OperatingMode => ShellDesignData.OperatingMode;

    public double Speed => ShellDesignData.MachineSpeed;

    public double Angle => ShellDesignData.MachineAngle;

    public event EventHandler? Changed
    {
        add { }
        remove { }
    }
}
