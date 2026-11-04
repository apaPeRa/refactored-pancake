namespace ApaTec.Hmi.Models;

/// <summary>Aktorart im Handbetrieb (HS-31): Antriebe mit Jog, schaltende Aktoren (Grund-/Arbeitsstellung), Servoantriebe im Positioniermodus.</summary>
public enum ManualActorKind
{
    Drive,
    Switching,
    ServoPositioning,
}

/// <summary>Richtung einer Handbewegung beziehungsweise eines Positionsschritts.</summary>
public enum JogDirection
{
    Minus,
    Plus,
}

/// <summary>Vorgabewert eines Aktors im Handbetrieb (HS-31, Felder E18 bis E20).</summary>
public enum ManualParameter
{
    Acceleration,
    Speed,
    Deceleration,
}

/// <summary>Maschinengruppe GRxx der Gruppenanwahl (HS-30). Die Beschriftung kommt aus den Ressourcen (<c>HS30_&lt;GroupId&gt;_Label</c>).</summary>
public sealed record ManualGroup(string GroupId);

/// <summary>Aktor einer Gruppe: Betriebsmittelkennzeichen (<paramref name="ActorId"/>, z. B. 2MA1) und Bezeichnung aus der Konfiguration.</summary>
public sealed record ManualActor(string ActorId, string Designation, ManualActorKind Kind);

/// <summary>
/// Momentaufnahme der Aktordaten (HS-31). <c>null</c> bei einem Wahrheitswert bedeutet unbekannt, bei Zahlen ungueltig (Anzeige <c>---</c>).
/// </summary>
public sealed record ManualActorState(
    bool IsReachable,
    double? Position,
    bool? ReleaseMinus,
    bool? EndStopMinus,
    bool? ReleasePlus,
    bool? EndStopPlus,
    int? PositionNumber,
    bool? ReleaseAtPosition,
    double Acceleration,
    double Speed,
    double Deceleration,
    string? Message,
    bool IsFault);

/// <summary>Anforderung an das Eingabe-Pop-up (<c>DialogKeys.Input</c>, HM-13): Titel, Startwert, Grenzen, Einheit und Hilfetext. Ergebnis: <c>double</c>.</summary>
public sealed record ManualInputRequest(string Title, double Value, double Minimum, double Maximum, int Decimals, string Unit, string? HelpText) : IInputRequest
{
    double? IInputRequest.Value => Value;

    double? IInputRequest.Minimum => Minimum;

    double? IInputRequest.Maximum => Maximum;

    Controls.InputKind IInputRequest.Kind => Controls.InputKind.Number;
}
