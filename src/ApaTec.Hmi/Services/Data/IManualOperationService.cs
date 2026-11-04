using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>Handbetrieb (HS-30, HS-31): Gruppen, Aktoren, Aktorzustand und Handbefehle. Die Maschinenanbindung ist nicht Teil des Projekts (Dummy).</summary>
public interface IManualOperationService
{
    /// <summary>Gruppen der Maschinenkonfiguration in Anzeigereihenfolge (OP-41).</summary>
    IReadOnlyList<ManualGroup> GetGroups();

    /// <summary>Aktoren einer Gruppe in Blaetterreihenfolge; leer, wenn die Gruppe unbekannt ist.</summary>
    IReadOnlyList<ManualActor> GetActors(string groupId);

    /// <summary>Aktueller Zustand eines Aktors.</summary>
    ManualActorState GetState(string actorId);

    /// <summary>Handbewegung starten (<paramref name="active"/> true) oder beenden (false); die Bewegung laeuft nur, solange sie aktiv gehalten wird (Totmann).</summary>
    void SetJog(string actorId, JogDirection direction, bool active);

    /// <summary>Positionsschritt (nur Servoantriebe im Positioniermodus).</summary>
    void StepPosition(string actorId, JogDirection direction);

    /// <summary>Vorgabewert schreiben (Prozent).</summary>
    void SetParameter(string actorId, ManualParameter parameter, double value);

    /// <summary>Wenn sich ein Aktorzustand aendert (ggf. nicht im UI-Thread).</summary>
    event EventHandler? Changed;
}
