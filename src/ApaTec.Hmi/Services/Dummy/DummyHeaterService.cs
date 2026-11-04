using ApaTec.Hmi.DesignData;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>Zwoelf Heizzonen mit den Werten des Bildes (alle Ein, Ueberwachung ein, Ist 0, State/Out aus); keine Maschinenanbindung.</summary>
[DummyService]
public sealed class DummyHeaterService : IHeaterService
{
    private readonly List<HeaterZoneInfo> _zones = HeatersDesignData.ZoneNames
        .Select((n, i) => new HeaterZoneInfo(i, n, true, true, HeatersDesignData.SetpointOf(i), 0, HeaterZoneState.Off, false))
        .ToList();

    public MachineValueLimits SetpointLimits { get; } = new(0, 300);

    public event EventHandler? Changed
    {
        add { }
        remove { }
    }

    public IReadOnlyList<HeaterZoneInfo> GetZones() => _zones.ToList();

    public Task<bool> SetZoneEnabledAsync(int index, bool enabled) => Update(index, z => z with { IsEnabled = enabled });

    public Task<bool> SetMonitoredAsync(int index, bool monitored) => Update(index, z => z with { IsMonitored = monitored });

    public Task<bool> SetSetpointAsync(int index, double value) => Update(index, z => z with { Setpoint = value });

    private Task<bool> Update(int index, Func<HeaterZoneInfo, HeaterZoneInfo> change)
    {
        if (index < 0 || index >= _zones.Count)
        {
            return Task.FromResult(false);
        }

        _zones[index] = change(_zones[index]);
        return Task.FromResult(true);
    }
}
