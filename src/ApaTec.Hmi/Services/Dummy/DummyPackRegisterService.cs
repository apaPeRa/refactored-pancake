using ApaTec.Hmi.Controls;
using ApaTec.Hmi.DesignData;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>Dummy des Packungsregisters (HS-28): Stationen und Zustaende aus RS-28_01. Zustandsaenderungen gelten nur im Speicher.</summary>
[DummyService]
public sealed class DummyPackRegisterService : IPackRegisterService
{
    private readonly object _gate = new();
    private List<PackStationState> _stations = PackRegister_DesignData.Stations.ToList();

    public bool IsConnected => true;

    public event EventHandler? Changed;

    public IReadOnlyList<PackStationState> GetStations()
    {
        lock (_gate)
        {
            return _stations.ToList();
        }
    }

    public Task<bool> SetStationStateAsync(int number, PackState state)
    {
        lock (_gate)
        {
            var index = _stations.FindIndex(s => s.Number == number);
            if (index < 0)
            {
                return Task.FromResult(false);
            }

            _stations = _stations.Select((s, i) => i == index ? s with { State = state } : s).ToList();
        }

        Changed?.Invoke(this, EventArgs.Empty);
        return Task.FromResult(true);
    }
}
