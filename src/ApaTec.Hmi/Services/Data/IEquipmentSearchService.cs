using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>Suche nach Betriebsmittelkennzeichen (Such-Pop-up HM-38 auf HS-30, HS-31, HS-33). Gefiltert wird im Pop-up, der Dienst liefert die Quelle.</summary>
public interface IEquipmentSearchService
{
    /// <summary>Aktoren aller Gruppen (HS-30, HS-31).</summary>
    IReadOnlyList<EquipmentEntry> GetActorEntries();

    /// <summary>Betriebsmittel (Kanaele) aller EA-Karten (HS-33).</summary>
    IReadOnlyList<EquipmentEntry> GetIoEntries();
}
