using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>Packungsregister (HS-28, Konzept.md 6.6 Zeile "Maschinenfunktionen"). Befehle wirken in M2 nur auf Dummy-Daten.</summary>
public interface IPackRegisterService
{
    /// <summary>false = keine Verbindung zur Steuerung bzw. keine Stationsdaten (Annahme K28-4).</summary>
    bool IsConnected { get; }

    /// <summary>Alle Stationen mit Zustand.</summary>
    IReadOnlyList<PackStationState> GetStations();

    /// <summary>Aendert den Zustand einer Station manuell; false = Schreiben fehlgeschlagen.</summary>
    Task<bool> SetStationStateAsync(int number, PackState state);

    /// <summary>Wenn sich Stationszustaende aendern (ggf. nicht im UI-Thread).</summary>
    event EventHandler? Changed;
}
