using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>Heizzonen (HS-22; Konzept.md 6.6).</summary>
public interface IHeaterService
{
    MachineValueLimits SetpointLimits { get; }

    IReadOnlyList<HeaterZoneInfo> GetZones();

    Task<bool> SetZoneEnabledAsync(int index, bool enabled);

    Task<bool> SetMonitoredAsync(int index, bool monitored);

    Task<bool> SetSetpointAsync(int index, double value);

    /// <summary>Wenn sich Ist-, State- oder Ausgangswerte aendern (ggf. nicht im UI-Thread).</summary>
    event EventHandler? Changed;
}
