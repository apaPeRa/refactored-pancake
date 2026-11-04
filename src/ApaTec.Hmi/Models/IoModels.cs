namespace ApaTec.Hmi.Models;

/// <summary>Richtung einer EA-Kartengruppe.</summary>
public enum IoDirection
{
    Input,
    Output,
}

/// <summary>Kartengruppe der EA-Uebersicht (HS-33): Schluessel (<c>cardGroup</c>), Richtung und Station. Die Beschriftung kommt aus den Ressourcen (<c>HS33_&lt;GroupId&gt;_Label</c>).</summary>
public sealed record IoCardGroup(string GroupId, IoDirection Direction, string Station);

/// <summary>Ein Kanal einer EA-Karte (HS-34). Digital: <paramref name="DigitalState"/> (null = unbekannt); analog: <paramref name="AnalogValue"/> (null = ungueltig).</summary>
public sealed record IoSignal(string Identifier, string Description, bool IsAnalog, bool? DigitalState, double? AnalogValue, bool IsReserve);

/// <summary>EA-Karte mit ihren Kanaelen (Momentaufnahme).</summary>
public sealed record IoCard(string CardId, IReadOnlyList<IoSignal> Signals);
