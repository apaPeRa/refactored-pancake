using ApaTec.Hmi.Controls;

namespace ApaTec.Hmi.Models;

/// <summary>Gruppe der Stationen im Packungsregister (HS-28): bestimmt die Lage in der Grafik.</summary>
public enum PackStationGroup
{
    /// <summary>Linker Block, 6 Felder nebeneinander.</summary>
    Block,

    /// <summary>Drehstern, 12 Arme.</summary>
    Star,

    /// <summary>Nummerierte rechte Reihe ab Nr. 40.</summary>
    Row,

    /// <summary>Senkrechte Spalte, 9 Felder.</summary>
    Column,
}

/// <summary>Zustand einer Station des Packungsregisters.</summary>
/// <param name="Number">Stationsnummer (Annahme: Block 1 bis 6, Stern 7 bis 18, Reihe 40 bis 61, Spalte 62 bis 70).</param>
/// <param name="Group">Gruppe in der Grafik.</param>
/// <param name="Position">Nullbasierte Position innerhalb der Gruppe.</param>
/// <param name="State">Packungszustand.</param>
public sealed record PackStationState(int Number, PackStationGroup Group, int Position, PackState State);
