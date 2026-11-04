using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>Quelle des Such-Pop-ups: leitet die Eintraege aus den Dummy-Daten des Handbetriebs und der EA-Karten ab (Reservekanaele sind nicht suchbar).</summary>
[DummyService]
public sealed class DummyEquipmentSearchService : IEquipmentSearchService
{
    private readonly IManualOperationService _manual;
    private readonly IIoService _io;

    public DummyEquipmentSearchService(IManualOperationService manual, IIoService io)
    {
        _manual = manual;
        _io = io;
    }

    public IReadOnlyList<EquipmentEntry> GetActorEntries() =>
        _manual.GetGroups()
            .SelectMany(group => _manual.GetActors(group.GroupId)
                .Select((actor, index) => new EquipmentEntry(actor.ActorId, actor.Designation, group.GroupId, actor.ActorId, index)))
            .ToList();

    public IReadOnlyList<EquipmentEntry> GetIoEntries()
    {
        var entries = new List<EquipmentEntry>();
        foreach (var group in _io.GetCardGroups())
        {
            var cards = _io.GetCards(group.GroupId);
            for (var cardIndex = 0; cardIndex < cards.Count; cardIndex++)
            {
                entries.AddRange(cards[cardIndex].Signals
                    .Where(signal => !signal.IsReserve)
                    .Select(signal => new EquipmentEntry(signal.Identifier, signal.Description, group.GroupId, cards[cardIndex].CardId, cardIndex)));
            }
        }

        return entries;
    }
}
