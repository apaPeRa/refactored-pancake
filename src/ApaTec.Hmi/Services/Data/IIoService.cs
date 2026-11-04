using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>EA-Uebersicht und EA-Anzeige (HS-33, HS-34): Kartengruppen, Karten und Kanalzustaende. Nur lesend (kein Schreibzugriff auf Signale).</summary>
public interface IIoService
{
    /// <summary>Kartengruppen in Anzeigereihenfolge (OP-41).</summary>
    IReadOnlyList<IoCardGroup> GetCardGroups();

    /// <summary>Karten einer Gruppe mit den aktuellen Kanalzustaenden (Momentaufnahme); leer, wenn die Gruppe unbekannt ist.</summary>
    IReadOnlyList<IoCard> GetCards(string cardGroupId);

    /// <summary>false, wenn die SPS nicht erreichbar ist: alle Zustaende sind dann unbekannt.</summary>
    bool IsConnected { get; }

    /// <summary>Wenn sich Kanalzustaende oder die Verbindung aendern (ggf. nicht im UI-Thread).</summary>
    event EventHandler? Changed;
}
