using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>
/// Beispielwerte fuer den Handbetrieb: die 14 Gruppen der Referenz (HS-30) und Aktoren je Gruppe. Das Bildbeispiel der Referenz
/// ("Antrieb Zuefuehrung 2MA1", Position 283,74, Vorgaben 100/20/100 %, Meldung "Motorschutz ausgeloest") liegt in GR2.
/// Weitere Aktoren und ihre Bezeichnungen sind erfundene Dummy-Werte (OP-41). Keine Maschinenanbindung.
/// </summary>
[DummyService]
public sealed class DummyManualOperationService : IManualOperationService
{
    private readonly object _gate = new();
    private readonly IReadOnlyList<ManualGroup> _groups;
    private readonly Dictionary<string, IReadOnlyList<ManualActor>> _actors;
    private readonly Dictionary<string, ManualActorState> _states = new(StringComparer.Ordinal);

    public DummyManualOperationService()
    {
        _groups = new[] { "GR1", "GR2", "GR3", "GR4", "GR5", "GR6", "GR10", "GR11", "GR14", "GR20", "GR41", "GR42", "GR45", "GR100" }
            .Select(id => new ManualGroup(id)).ToList();

        _actors = new Dictionary<string, IReadOnlyList<ManualActor>>(StringComparer.Ordinal)
        {
            ["GR1"] = new[] { new ManualActor("1MA1", "Hauptantrieb 1MA1", ManualActorKind.Drive) },
            ["GR2"] = new[]
            {
                new ManualActor("2MA1", "Antrieb Zuführung 2MA1", ManualActorKind.Drive),
                new ManualActor("2MA2", "Antrieb Zuführung 2MA2", ManualActorKind.Drive),
                new ManualActor("2Y1", "Ventil Papierklappe 2Y1", ManualActorKind.Switching),
            },
            ["GR3"] = new[] { new ManualActor("3MA1", "Antrieb Zuführung Karton 3MA1", ManualActorKind.Drive) },
            ["GR4"] = new[] { new ManualActor("4MA1", "Antrieb Dornrad 4MA1", ManualActorKind.ServoPositioning) },
            ["GR5"] = new[] { new ManualActor("5MA1", "Antrieb Dornrad 5MA1", ManualActorKind.Drive) },
            ["GR6"] = new[] { new ManualActor("6Y1", "Ventil Heizung 6Y1", ManualActorKind.Switching) },
            ["GR10"] = new[] { new ManualActor("10MA1", "Antrieb Paketübergabe 10MA1", ManualActorKind.ServoPositioning) },
            ["GR11"] = new[] { new ManualActor("11M1", "Rüttelmotor 11M1", ManualActorKind.Switching) },
            ["GR14"] = new[] { new ManualActor("14MA1", "Antrieb Endkontrollwaage 14MA1", ManualActorKind.Drive) },
            ["GR20"] = new[]
            {
                new ManualActor("20MA1", "Antrieb Schließmaschine 20MA1", ManualActorKind.ServoPositioning),
                new ManualActor("20Y1", "Zylinder Verschluss 20Y1", ManualActorKind.Switching),
            },
            ["GR41"] = new[]
            {
                new ManualActor("41MA1", "Antrieb Hauptdosierer 1 41MA1", ManualActorKind.Drive),
                new ManualActor("41Y1", "Ventil Dosierklappe 41Y1", ManualActorKind.Switching),
            },
            ["GR42"] = new[] { new ManualActor("42MA1", "Antrieb Hauptdosierer 2 42MA1", ManualActorKind.Drive) },
            ["GR45"] = new[] { new ManualActor("45MA1", "Antrieb Nachdosierer 45MA1", ManualActorKind.Drive) },
            ["GR100"] = new[] { new ManualActor("100X1", "Schnittstelle Palettierung 100X1", ManualActorKind.Switching) },
        };

        foreach (var actor in _actors.Values.SelectMany(a => a))
        {
            _states[actor.ActorId] = CreateState(actor);
        }
    }

    public event EventHandler? Changed;

    public IReadOnlyList<ManualGroup> GetGroups() => _groups;

    public IReadOnlyList<ManualActor> GetActors(string groupId) =>
        _actors.TryGetValue(groupId, out var actors) ? actors : Array.Empty<ManualActor>();

    public ManualActorState GetState(string actorId)
    {
        lock (_gate)
        {
            return _states.TryGetValue(actorId, out var state) ? state : UnreachableState;
        }
    }

    public void SetJog(string actorId, JogDirection direction, bool active)
    {
        // Dummy: keine Maschine; die Bewegung wird nur gemeldet.
        Changed?.Invoke(this, EventArgs.Empty);
    }

    public void StepPosition(string actorId, JogDirection direction)
    {
        Update(actorId, state =>
        {
            var next = (state.PositionNumber ?? 1) + (direction == JogDirection.Plus ? 1 : -1);
            return state with { PositionNumber = Math.Clamp(next, 1, 8) };
        });
    }

    public void SetParameter(string actorId, ManualParameter parameter, double value)
    {
        Update(actorId, state => parameter switch
        {
            ManualParameter.Acceleration => state with { Acceleration = value },
            ManualParameter.Speed => state with { Speed = value },
            _ => state with { Deceleration = value },
        });
    }

    private static ManualActorState UnreachableState { get; } =
        new(false, null, null, null, null, null, null, null, 0, 0, 0, null, false);

    private static ManualActorState CreateState(ManualActor actor)
    {
        var isImageExample = actor.ActorId == "2MA1";
        var isPositioning = actor.Kind == ManualActorKind.ServoPositioning;
        return new ManualActorState(
            IsReachable: true,
            Position: actor.Kind == ManualActorKind.Switching ? null : 283.74,
            ReleaseMinus: !isImageExample,
            EndStopMinus: false,
            ReleasePlus: !isImageExample,
            EndStopPlus: false,
            PositionNumber: isPositioning ? 3 : null,
            ReleaseAtPosition: isPositioning ? false : null,
            Acceleration: 100,
            Speed: 20,
            Deceleration: 100,
            Message: isImageExample ? "Motorschutz ausgelöst" : null,
            IsFault: isImageExample);
    }

    private void Update(string actorId, Func<ManualActorState, ManualActorState> change)
    {
        lock (_gate)
        {
            if (!_states.TryGetValue(actorId, out var state))
            {
                return;
            }

            _states[actorId] = change(state);
        }

        Changed?.Invoke(this, EventArgs.Empty);
    }
}
