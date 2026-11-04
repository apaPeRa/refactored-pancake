using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>Beispielwerte aus RS-03_01: Maximum 125, Schnell 50, Langsam 50, Tippen 15, Minimum 10 (1/min). Absolute Grenzen 1 bis 200 sind Dummywerte (OP-28).</summary>
[DummyService]
public sealed class DummyMachineSpeedService : IMachineSpeedService
{
    private const double HardwareMinimum = 1;
    private const double HardwareMaximum = 200;
    private static readonly TimeSpan WriteDelay = TimeSpan.FromMilliseconds(250);

    private readonly Dictionary<MachineSpeedKind, double> _values = new()
    {
        [MachineSpeedKind.Maximum] = 125,
        [MachineSpeedKind.Fast] = 50,
        [MachineSpeedKind.Slow] = 50,
        [MachineSpeedKind.Jog] = 15,
        [MachineSpeedKind.Minimum] = 10,
    };

    public event EventHandler? Changed;

    public double GetSpeed(MachineSpeedKind kind) => _values[kind];

    // Plausibilitaet S03-2: Minimum <= Tippen <= Langsam <= Maximum und Minimum <= Schnell <= Maximum.
    public MachineSpeedLimits GetLimits(MachineSpeedKind kind) => kind switch
    {
        MachineSpeedKind.Maximum => new MachineSpeedLimits(Math.Max(_values[MachineSpeedKind.Fast], _values[MachineSpeedKind.Slow]), HardwareMaximum),
        MachineSpeedKind.Fast => new MachineSpeedLimits(_values[MachineSpeedKind.Minimum], _values[MachineSpeedKind.Maximum]),
        MachineSpeedKind.Slow => new MachineSpeedLimits(_values[MachineSpeedKind.Jog], _values[MachineSpeedKind.Maximum]),
        MachineSpeedKind.Jog => new MachineSpeedLimits(_values[MachineSpeedKind.Minimum], _values[MachineSpeedKind.Slow]),
        _ => new MachineSpeedLimits(HardwareMinimum, _values[MachineSpeedKind.Jog]),
    };

    public async Task<bool> SetSpeedAsync(MachineSpeedKind kind, double value)
    {
        var limits = GetLimits(kind);
        if (value < limits.Minimum || value > limits.Maximum)
        {
            return false;
        }

        await Task.Delay(WriteDelay).ConfigureAwait(true);
        _values[kind] = value;
        Changed?.Invoke(this, EventArgs.Empty);
        return true;
    }
}
