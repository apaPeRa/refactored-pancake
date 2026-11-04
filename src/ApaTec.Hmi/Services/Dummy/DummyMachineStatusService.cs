using ApaTec.Hmi.DesignData;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>Beispielwerte aus dem Design: Produktion, 112 1/min, 245 Grad (keine Maschinenanbindung). Die Betriebsart ist ueber <see cref="SetOperatingMode"/> setzbar (HS-36: Service).</summary>
[DummyService]
public sealed class DummyMachineStatusService : IMachineStatusService
{
    private volatile OperatingMode _mode = ShellDesignData.OperatingMode;

    public OperatingMode OperatingMode => _mode;

    public double Speed => ShellDesignData.MachineSpeed;

    public double Angle => ShellDesignData.MachineAngle;

    public event EventHandler? Changed;

    public void SetOperatingMode(OperatingMode mode)
    {
        if (_mode == mode)
        {
            return;
        }

        _mode = mode;
        Changed?.Invoke(this, EventArgs.Empty);
    }
}
