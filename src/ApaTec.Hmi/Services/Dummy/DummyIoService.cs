using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>
/// Beispielwerte fuer HS-33 und HS-34: sechs Kartengruppen (Eingaenge/Ausgaenge S1, S300, S500). Die Karte S1_0KDE1 stammt aus dem Bild der Referenz
/// (acht Kanaele, alle Aus; Klartext unveraendert in Grossbuchstaben und ASCII, OP-43). Alle weiteren Karten und Kanaele sind Dummy-Werte, die
/// Analogkarte (Einheit und Format offen, OP-29) ebenfalls. Der Dienst liefert Momentaufnahmen und aendert sich im Dummy nicht.
/// </summary>
[DummyService]
public sealed class DummyIoService : IIoService
{
    private readonly IReadOnlyList<IoCardGroup> _groups = new[]
    {
        new IoCardGroup("InputsS1", IoDirection.Input, "S1"),
        new IoCardGroup("OutputsS1", IoDirection.Output, "S1"),
        new IoCardGroup("InputsS300", IoDirection.Input, "S300"),
        new IoCardGroup("OutputsS300", IoDirection.Output, "S300"),
        new IoCardGroup("InputsS500", IoDirection.Input, "S500"),
        new IoCardGroup("OutputsS500", IoDirection.Output, "S500"),
    };

    private readonly Dictionary<string, IReadOnlyList<IoCard>> _cards;

    public DummyIoService()
    {
        _cards = new Dictionary<string, IReadOnlyList<IoCard>>(StringComparer.Ordinal)
        {
            ["InputsS1"] = new[]
            {
                Digital("S1_0KDE1", false, ("0F24A_rdy", "SICHERUNGS MODUL BEREIT (0F24A)"), ("0F24A_state", "SICHERUNGS MODUL STATUS (0F24A)"), null, null, ("0E3", "KUEHLGERAET BEREIT"), null, ("0Q5", "SPANNUNG FU-ANTRIEBE OK"), ("0Q7", "SPANNUNG SERVO-ANTRIEBE OK")),
                Digital("S1_0KDE2", true, ("0S1", "NOT-AUS KREIS 1 OK"), ("0S2", "NOT-AUS KREIS 2 OK"), ("0B3", "SCHUTZTUER ZU"), null, null, null, null, null),
            },
            ["OutputsS1"] = new[]
            {
                Digital("S1_0KDA1", true, ("0H1", "MELDELEUCHTE BETRIEB"), ("0H2", "MELDELEUCHTE STOERUNG"), null, null, null, null, null, null),
            },
            ["InputsS300"] = new[]
            {
                Digital("S300_0KDE1", false, ("300B1", "INITIATOR DOSIERER 1"), ("300B2", "INITIATOR DOSIERER 2"), null, null, null, null, null, null),
            },
            ["OutputsS300"] = new[]
            {
                Digital("S300_0KDA1", false, ("300Y1", "VENTIL DOSIERKLAPPE 1"), ("300Y2", "VENTIL DOSIERKLAPPE 2"), null, null, null, null, null, null),
            },
            ["InputsS500"] = new[]
            {
                Digital("S500_0KDE1", false, ("500B1", "INITIATOR SCHLIESSMASCHINE"), null, null, null, null, null, null, null),
                new IoCard("S500_0KAE1", new[]
                {
                    new IoSignal("500R1", "TEMPERATUR LEIMTANK", true, null, 142.5, false),
                    new IoSignal("500R2", "DRUCK LEIMPUMPE", true, null, 3.8, false),
                    new IoSignal("S500_0KAE1_3", "RESERVE", true, null, 0.0, true),
                    new IoSignal("S500_0KAE1_4", "RESERVE", true, null, 0.0, true),
                }),
            },
            ["OutputsS500"] = new[]
            {
                Digital("S500_0KDA1", false, ("500Y1", "ZYLINDER VERSCHLUSS"), null, null, null, null, null, null, null),
            },
        };
    }

    public bool IsConnected => true;

    public event EventHandler? Changed
    {
        add { }
        remove { }
    }

    public IReadOnlyList<IoCardGroup> GetCardGroups() => _groups;

    public IReadOnlyList<IoCard> GetCards(string cardGroupId) =>
        _cards.TryGetValue(cardGroupId, out var cards) ? cards : Array.Empty<IoCard>();

    // Achtung Reihenfolge: acht Kanaele (Kennung, Klartext) oder null = Reserve mit laufender Kennung "<Karte>_<n>" und Klartext RESERVE.
    private static IoCard Digital(string cardId, bool firstOn, params (string Id, string Text)?[] channels)
    {
        var signals = new List<IoSignal>();
        for (var i = 0; i < 8; i++)
        {
            var channel = i < channels.Length ? channels[i] : null;
            var isReserve = channel is null;
            var id = channel?.Id ?? $"{cardId}_{i + 1}";
            var text = channel?.Text ?? "RESERVE";
            signals.Add(new IoSignal(id, text, false, firstOn && i == 0, null, isReserve));
        }

        return new IoCard(cardId, signals);
    }
}
