using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.DesignData;

/// <summary>Beispielwerte HS-38 (Bild RS-38_01): anstehende Meldungen aufsteigend nach Nummer; Platzhalter der Steuerung aufgeloest.</summary>
public static class MessageView_DesignData
{
    public static IReadOnlyList<MessageEntry> CreateMessages()
    {
        var list = new List<MessageEntry>
        {
            Make(0, "Maschine ist bereit", MessageClass.Operation),
            Make(ShellDesignData.MessageNumber, ShellDesignData.MessageText, ShellDesignData.MessageClass),
            Make(90, "Palettierung nicht bereit", MessageClass.Notice),
            Make(98, "Grundstellungsfahrt Hochstoß", MessageClass.Notice),
            Make(99, "Grundstellungsfahrt aktiv", MessageClass.Notice),
            Make(100, "Steuerung ein Schalter ist ausgeschaltet", MessageClass.Fault),
            Make(101, "Sicherung 0F24A DC 24 V nicht bereit", MessageClass.Fault),
        };
        for (var channel = 1; channel <= 8; channel++)
        {
            list.Add(Make(101 + channel, $"Sicherung 0F24A Kanal {channel} ausgelöst", MessageClass.Fault));
        }

        list.Add(Make(150, "Störung Hochstoß 3Y1: Motorschutz ausgelöst", MessageClass.Fault));
        list.Add(Make(170, "Paket im Einlauf umgefallen", MessageClass.Fault));
        list.Add(Make(171, "Störung Einlaufband 5MA1: Motorschutz ausgelöst", MessageClass.Fault));
        list.Add(Make(173, "Paket im Einlauf verdreht", MessageClass.Fault));
        list.Add(Make(191, "Störung Höhenregulierung 8MA1: Überstrom", MessageClass.Fault));
        list.Add(Make(201, "Störung Vorabwicklung 9MA1: Überstrom", MessageClass.Fault));
        return list;
    }

    private static MessageEntry Make(int number, string text, MessageClass cls) => new() { Number = number, Text = text, Class = cls };
}
