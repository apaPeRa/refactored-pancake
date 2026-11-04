using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>
/// Dummy-Nordson-Heissleimgeraet mit den Beispielwerten aus RS-07 bis RS-09 und DS-03 (OP-28): Tank 150 Grad, Verteiler 150, Pistole 1 170, Schlauch 1 160, Fuellstand 83 %,
/// Ziel Fuellstand 50 %, Max Fuellzeit 60 s, Standby-Absenkung 56 Grad. Schreibzugriffe werden nach kurzer Verzoegerung bestaetigt (Zustand "Ausstehend", HM-08).
/// </summary>
[DummyService]
public sealed class DummyHotGlueService : IHotGlueService
{
    private static readonly TimeSpan Confirmation = TimeSpan.FromMilliseconds(300);

    private readonly Dictionary<HotGlueSwitch, bool> _switches = new()
    {
        [HotGlueSwitch.Heaters] = true,
        [HotGlueSwitch.Standby] = false,
        [HotGlueSwitch.Pump] = true,
        [HotGlueSwitch.Timer] = true,
        [HotGlueSwitch.RefillSystem] = true,
    };

    private readonly Dictionary<HotGlueParameter, double> _values = new()
    {
        [HotGlueParameter.TargetFillLevel] = 50,
        [HotGlueParameter.MaxFillTime] = 60,
        [HotGlueParameter.StandbyDelta] = 56,
        [HotGlueParameter.ReadyDelay] = 0,
        [HotGlueParameter.OverTemperatureDelta] = 15,
        [HotGlueParameter.UnderTemperatureDelta] = 25,
        [HotGlueParameter.UpperSpeed] = 120,
        [HotGlueParameter.LowerSpeed] = 20,
        [HotGlueParameter.UpperPressure] = 1.7,
        [HotGlueParameter.LowerPressure] = 0.7,
        [HotGlueParameter.UpperPressureLimit] = 5.0,
        [HotGlueParameter.LowerPressureLimit] = 0.7,
        [HotGlueParameter.OverPressureDelta] = 3.0,
        [HotGlueParameter.UnderPressureDelta] = 0.3,
    };

    private static readonly IReadOnlyDictionary<HotGlueParameter, HotGlueLimits> LimitTable = new Dictionary<HotGlueParameter, HotGlueLimits>
    {
        [HotGlueParameter.TargetFillLevel] = new(0, 100, 0),
        [HotGlueParameter.MaxFillTime] = new(1, 600, 0),
        [HotGlueParameter.StandbyDelta] = new(0, 100, 0),
        [HotGlueParameter.ReadyDelay] = new(0, 600, 0),
        [HotGlueParameter.OverTemperatureDelta] = new(0, 100, 0),
        [HotGlueParameter.UnderTemperatureDelta] = new(0, 100, 0),
        [HotGlueParameter.UpperSpeed] = new(0, 500, 0),
        [HotGlueParameter.LowerSpeed] = new(0, 500, 0),
        [HotGlueParameter.UpperPressure] = new(0, 10, 1),
        [HotGlueParameter.LowerPressure] = new(0, 10, 1),
        [HotGlueParameter.UpperPressureLimit] = new(0, 10, 1),
        [HotGlueParameter.LowerPressureLimit] = new(0, 10, 1),
        [HotGlueParameter.OverPressureDelta] = new(0, 10, 1),
        [HotGlueParameter.UnderPressureDelta] = new(0, 10, 1),
    };

    private readonly Dictionary<HotGlueLed, HotGlueLedState> _leds = Enum.GetValues<HotGlueLed>().ToDictionary(l => l, _ => HotGlueLedState.Ok);

    private List<HotGlueZone> _zones = new()
    {
        new(HotGlueZoneIds.Tank, 150, 150, true, false),
        new(HotGlueZoneIds.Hose1, 160, 160, true, false),
        new(HotGlueZoneIds.Gun1, 170, 170, true, false),
        new(HotGlueZoneIds.Hose2, 100, 0, false, false),
        new(HotGlueZoneIds.Gun2, 100, 0, false, false),
        new(HotGlueZoneIds.Manifold, 150, 150, true, false),
    };

    public bool IsConnected => true;

    public double? TankLevel => 83;

    public double? CurrentPressure => 0.7;

    public IReadOnlyList<HotGlueZone> Zones => _zones;

    public HotGlueLimits ZoneSetpointLimits { get; } = new(0, 250, 0);

    public bool IsManualFillActive { get; private set; }

    public event EventHandler? Changed;

    public bool GetSwitch(HotGlueSwitch hotGlueSwitch) => _switches[hotGlueSwitch];

    public async Task SetSwitchAsync(HotGlueSwitch hotGlueSwitch, bool on, CancellationToken cancellationToken = default)
    {
        await Task.Delay(Confirmation, cancellationToken);
        _switches[hotGlueSwitch] = on;
        Changed?.Invoke(this, EventArgs.Empty);
    }

    public HotGlueLedState GetLed(HotGlueLed led) => _leds[led];

    public async Task SetZoneSetpointAsync(string zoneId, double setpoint, CancellationToken cancellationToken = default)
    {
        await Task.Delay(Confirmation, cancellationToken);
        _zones = _zones.Select(z => z.Id == zoneId ? z with { Setpoint = setpoint } : z).ToList();
        Changed?.Invoke(this, EventArgs.Empty);
    }

    public async Task SetZoneEnabledAsync(string zoneId, bool enabled, CancellationToken cancellationToken = default)
    {
        await Task.Delay(Confirmation, cancellationToken);

        // Abgewaehlte Zone meldet 0 Grad (RS-08); beim Wiederanwaehlen heizt sie auf die Solltemperatur (Dummy: sofort).
        _zones = _zones.Select(z => z.Id == zoneId ? z with { IsEnabled = enabled, Actual = enabled ? z.Setpoint : 0 } : z).ToList();
        Changed?.Invoke(this, EventArgs.Empty);
    }

    public double GetParameter(HotGlueParameter parameter) => _values[parameter];

    public HotGlueLimits GetLimits(HotGlueParameter parameter) => LimitTable[parameter];

    public async Task SetParameterAsync(HotGlueParameter parameter, double value, CancellationToken cancellationToken = default)
    {
        await Task.Delay(Confirmation, cancellationToken);
        _values[parameter] = value;
        Changed?.Invoke(this, EventArgs.Empty);
    }

    public Task SetManualFillAsync(bool requested, CancellationToken cancellationToken = default)
    {
        IsManualFillActive = requested;
        Changed?.Invoke(this, EventArgs.Empty);
        return Task.CompletedTask;
    }
}
