using CommunityToolkit.Mvvm.ComponentModel;

namespace ApaTec.Hmi.Models;

/// <summary>Die drei Schneckendosierer: Hauptdosierer 1 und 2 (HS-11, HS-12) und der Nachdosierer (HS-19 bis HS-21); <c>doserIndex</c> 1 und 2 entspricht <see cref="Main1"/> und <see cref="Main2"/>.</summary>
public enum DoserId
{
    Main1 = 1,
    Main2 = 2,
    Post = 3,
}

/// <summary>Bezeichner der editierbaren Werte der Dosierer-Seiten HS-11, HS-12, HS-19 bis HS-21; dient auch als Schluessel fuer Grenzen und Hilfetexte im Eingabe-Pop-up.</summary>
public enum DoserField
{
    // Sollwerte und Eichdosierung (HS-11, HS-19)
    TargetPercent,
    TargetWeight,
    MaxRefill,
    RegulationValue,
    CalibrationRevolutions,
    CalibrationWeight,

    // Schnecke, Ruehrer, Querschnecke (HS-11, HS-19)
    ScrewSpeed,
    AgitatorPercent,
    AgitatorRunOn,
    CrossScrewPercent,

    // Motorparameter Verschluss Zu (HS-12, HS-20)
    ClosedPosition,
    ClosedSpeed,
    ClosedAcceleration,
    ClosedDeceleration,
    ClosedJerk,

    // Motorparameter Verschluss Auf
    OpenPosition,
    OpenSpeed,
    OpenAcceleration,
    OpenDeceleration,
    OpenJerk,

    // Motorparameter Schnecke
    ScrewAcceleration,
    ScrewDeceleration,
    ScrewJerk,

    // Gewichtskorrektur (HS-21)
    CorrectionTargetWeight,
    CorrectionPointValue,
}

/// <summary>Umschalter eines Dosierers (Anwahlen).</summary>
public enum DoserSwitch
{
    CrossScrew,
    Agitator,
    Regulation,
}

/// <summary>Zustand eines Fuellstandssensors im Trichter (Annahme S11-4: Produkt vorhanden = Ok).</summary>
public enum DoserHopperState
{
    Unknown,
    ProductPresent,
    NoProduct,
}

/// <summary>Ergebnis der Nachgabe des Nachdosierers (nIO-Regel, HM-20-P06).</summary>
public enum DoserRefillResult
{
    None,
    Dosed,
    RejectedTooMuch,
}

/// <summary>Ergebnis der Gewichtsanpassung (HS-21).</summary>
public enum DoserAdjustState
{
    Calculated,
    TooFewPoints,
    InvalidPoints,
}

/// <summary>Dummy-Grenzen und Darstellung eines Werts (Wertebereiche fehlen in der Quelle, OP-28).</summary>
public sealed record DoserValueLimits(double Minimum, double Maximum, int Decimals, string Unit);

/// <summary>Anforderung an das Eingabe-Pop-up (<c>DialogKeys.Input</c>, HM-13): Titel, vorbelegter Wert, Grenzen und Handbuchtext als Hilfetext (S11-7); Ergebnis ist <c>double?</c>.</summary>
public sealed record DoserInputRequest(string Title, double Value, DoserValueLimits Limits, string? HelpText);

/// <summary>Sollgewicht und letztes Gewicht der Kontrollwaage (Titelzeile von HS-41, Basis fuer "Soll absolut").</summary>
public sealed record DoserReferenceWeights(double TargetWeight, double LastWeight);

/// <summary>Momentaufnahme eines Dosierers: Parameter, Anwahlen und Status (RS-11 T14/T15, RS-19 T27/T28).</summary>
/// <param name="Id">Dosierer.</param>
/// <param name="TargetPercent">Hauptdosierer: Soll in Prozent des Zielgewichts.</param>
/// <param name="TargetWeight">Hauptdosierer: Soll absolut in g (berechnet); Nachdosierer: Soll in g.</param>
/// <param name="MaxRefill">Nachdosierer: Max. Nachgabe in g.</param>
/// <param name="CurrentRefill">Nachdosierer: Aktuelle Nachgabe in g.</param>
/// <param name="RefillResult">Nachdosierer: Ergebnis der letzten Nachgabe.</param>
/// <param name="RegulationValue">Regulierwert (Regulierung Ist) in g.</param>
/// <param name="CalibrationRevolutions">Eichdosierung: Umdrehungen.</param>
/// <param name="CalibrationWeight">Eichdosierung: Gewicht in g.</param>
/// <param name="ScrewSpeed">Solldrehzahl der Schnecke in 1/min.</param>
/// <param name="AgitatorPercent">Ruehrer in Prozent.</param>
/// <param name="AgitatorRunOn">Nachlauf Ruehrer in s.</param>
/// <param name="CrossScrewPercent">Querschnecke in Prozent.</param>
/// <param name="HopperUpper">Fuellstand oben.</param>
/// <param name="HopperLower">Fuellstand unten.</param>
/// <param name="Load">Auslastung in Prozent.</param>
/// <param name="CrossScrewEnabled">Anwahl Querschnecke.</param>
/// <param name="AgitatorEnabled">Anwahl Ruehrer.</param>
/// <param name="RegulationEnabled">Anwahl Regulierung.</param>
/// <param name="IsEmptying">Entleeren laeuft.</param>
/// <param name="IsSelected">Karte ist ausgewaehlt (Dummy, DS-04 hebt den Nachdosierer hervor, OP-18).</param>
/// <param name="ActionsAllowed">Manuell, Entleeren, Eichdosierung sind im aktuellen Betriebszustand zulaessig (Dummy, OP-45).</param>
public sealed record DoserSnapshot(
    DoserId Id,
    double TargetPercent,
    double TargetWeight,
    double MaxRefill,
    double CurrentRefill,
    DoserRefillResult RefillResult,
    double RegulationValue,
    double CalibrationRevolutions,
    double CalibrationWeight,
    double ScrewSpeed,
    double AgitatorPercent,
    double AgitatorRunOn,
    double CrossScrewPercent,
    DoserHopperState HopperUpper,
    DoserHopperState HopperLower,
    double Load,
    bool CrossScrewEnabled,
    bool AgitatorEnabled,
    bool RegulationEnabled,
    bool IsEmptying,
    bool IsSelected,
    bool ActionsAllowed);

/// <summary>Bewegungsparameter einer Verschlussbewegung (Zu oder Auf): Position in Grad, sonst Prozent.</summary>
public sealed record DoserClosureMotion(double Position, double Speed, double Acceleration, double Deceleration, double Jerk);

/// <summary>Bewegungsparameter der Schnecke in Prozent.</summary>
public sealed record DoserScrewMotion(double Acceleration, double Deceleration, double Jerk);

/// <summary>Motorparameter eines Dosierers (HS-12, HS-20): Verschluss Zu, Verschluss Auf, Schnecke.</summary>
public sealed record DoserMotorSettings(DoserClosureMotion Closed, DoserClosureMotion Open, DoserScrewMotion Screw);

/// <summary>Stuetzstelle der Gewichtskorrektur: Soll und Ist in g, 0 = leer.</summary>
public sealed record DoserWeightPoint(double Nominal, double Actual);

/// <summary>Daten der Gewichtskorrektur des Nachdosierers (HS-21): Sollgewicht und 20 Stuetzstellen (2 x 10).</summary>
public sealed record DoserWeightCorrectionData(double TargetWeight, IReadOnlyList<DoserWeightPoint> Points);

/// <summary>Ergebnis der Gewichtsanpassung: Zustand und Zahl der verwendeten Stuetzstellen.</summary>
public sealed record DoserAdjustResult(DoserAdjustState State, int UsedPoints);

/// <summary>Bearbeitbarer Wert eines Dosierer-Eingabefelds (HM-12): Wert, Fehlertext und Befehl zum Oeffnen des Eingabe-Pop-ups.</summary>
public sealed partial class DoserEditableValue : ObservableObject
{
    public DoserEditableValue(DoserField field)
    {
        Field = field;
    }

    public DoserField Field { get; }

    [ObservableProperty]
    private double? _value;

    /// <summary>Fehlertext unter dem Feld ("Wert ausserhalb a bis b Einheit"); null = kein Fehler.</summary>
    [ObservableProperty]
    private string? _errorText;
}
