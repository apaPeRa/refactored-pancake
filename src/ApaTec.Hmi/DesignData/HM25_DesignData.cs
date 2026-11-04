using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.DesignData;

/// <summary>Beispielwerte fuer HM-25 aus den Bildern (Konzept A-50): Meldearchiv, Meldeanzeige, Variablenliste.</summary>
public static class HM25_DesignData
{
    public static IReadOnlyList<MessageEntry> ArchiveItems { get; } = new List<MessageEntry>
    {
        Archive(new DateTime(2025, 5, 5, 10, 13, 55), "Gekommen", "Sicherung 4F24 Auslaufband ausgelöst.", MessageClass.Fault),
        Archive(new DateTime(2025, 5, 5, 10, 12, 31), "Gekommen", "Füllstand Trichter unten", MessageClass.Notice),
        Archive(new DateTime(2025, 5, 5, 10, 05, 02), "Gegangen", "Motorschutz Dosierer 1", MessageClass.Fault),
        Archive(new DateTime(2025, 5, 5, 09, 58, 47), "Gekommen", "Motorschutz Dosierer 1", MessageClass.Fault),
        Archive(new DateTime(2025, 5, 5, 09, 30, 10), "Gekommen", "Produktion gestartet", MessageClass.Operation),
        Archive(new DateTime(2025, 5, 5, 09, 15, 00), "Gekommen", "Heizung Tank Solltemperatur erreicht", MessageClass.Operation),
    };

    public static IReadOnlyList<MessageEntry> LiveItems { get; } = new List<MessageEntry>
    {
        Live(0, "Keine Störung", MessageClass.Operation),
        Live(81, "Hauptdosierer 1 Füllstand niedrig", MessageClass.Notice),
        Live(90, "Sicherung 4F24 Auslaufband ausgelöst.", MessageClass.Fault),
        Live(120, "Kartonmagazin leer", MessageClass.Notice),
    };

    public static IReadOnlyList<MessageEntry> SelectionItems { get; } = new List<MessageEntry>
    {
        Variable("Dosierer1.Gewicht.Ist", true),
        Variable("Dosierer1.Gewicht.Soll", true),
        Variable("Dosierer2.Gewicht.Ist", false),
        Variable("Heizung.Tank.Temperatur", false),
        Variable("Maschine.Geschwindigkeit", false),
    };

    public static IList<MessageEntry> SelectedItems { get; } = SelectionItems.Where(i => i.IsSelected).ToList();

    public static int VariableTotalCount => 111427;

    private static MessageEntry Archive(DateTime time, string kind, string text, MessageClass cls)
        => new() { Timestamp = time, Event = kind, Text = text, Class = cls };

    private static MessageEntry Live(int number, string text, MessageClass cls)
        => new() { Number = number, Text = text, Class = cls };

    private static MessageEntry Variable(string name, bool selected)
        => new() { Text = name, Class = MessageClass.None, IsSelected = selected };
}
