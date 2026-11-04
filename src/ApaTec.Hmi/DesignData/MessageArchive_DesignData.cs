using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.DesignData;

/// <summary>Beispielwerte HS-37 (Bild RS-37_01), neueste zuerst. Ereignis "KO" unveraendert (OP-49).</summary>
public static class MessageArchive_DesignData
{
    public static IReadOnlyList<MessageEntry> CreateEntries()
    {
        var t = new DateTime(2025, 5, 5, 10, 13, 55);
        return new List<MessageEntry>
        {
            Fault(t, 120, "Störung Hauptantrieb 1MA1: Motorschutz ausgelöst"),
            Fault(t, 112, "Klimagerät Schaltschrank nicht bereit 0E4"),
            Fault(t, 111, "Sicherung 0Q3 FU-Antriebe ausgelöst"),
            Fault(t, 110, "Sicherung 0Q2 Servoantriebe ausgelöst"),
            Fault(t, 109, "Sicherung 0F24A Kanal 8 ausgelöst"),
            Fault(t, 108, "Sicherung 0F24A Kanal 7 ausgelöst"),
            Fault(t, 107, "Sicherung 0F24A Kanal 6 ausgelöst"),
            Fault(t, 106, "Sicherung 0F24A Kanal 5 ausgelöst"),
            Fault(t, 105, "Sicherung 0F24A Kanal 4 ausgelöst"),
            Fault(t, 104, "Sicherung 0F24A Kanal 3 ausgelöst"),
            Fault(t, 103, "Sicherung 0F24A Kanal 2 ausgelöst"),
            Fault(t, 102, "Sicherung 0F24A Kanal 1 ausgelöst"),
            Fault(t, 101, "Sicherung 0F24A DC 24 V nicht bereit"),
            Fault(t, 100, "Steuerung ein Schalter ist ausgeschaltet"),
            Notice(t, 81, "Höhenregulierung Endlage unten"),
            Notice(t, 80, "Höhenregulierung Endlage oben"),
            Notice(t, 70, "Rolle fast leer"),
            Notice(new DateTime(2024, 11, 14, 16, 13, 17), 54, "Inbetriebnahme Funktionen aktiv"),
            Notice(new DateTime(2024, 11, 14, 16, 12, 7), 54, "Inbetriebnahme Funktionen aktiv"),
            Notice(new DateTime(2024, 11, 14, 11, 6, 31), 54, "Inbetriebnahme Funktionen aktiv"),
            new MessageEntry { Timestamp = new DateTime(2024, 11, 13, 13, 46, 57), Event = "KO", Number = 0, Text = "000: Maschine ist bereit", Class = MessageClass.Operation },
        };
    }

    private static MessageEntry Fault(DateTime time, int number, string text) => Entry(time, number, text, MessageClass.Fault);

    private static MessageEntry Notice(DateTime time, int number, string text) => Entry(time, number, text, MessageClass.Notice);

    private static MessageEntry Entry(DateTime time, int number, string text, MessageClass cls) =>
        new() { Timestamp = time, Event = "KO", Number = number, Text = $"{number:000}: {text}", Class = cls };
}
