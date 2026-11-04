using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>
/// Schneckendosierer (HS-41 Uebersicht, HS-11 Hauptdosierer 1 und 2, HS-12 und HS-20 Motorparameter, HS-19 Nachdosierer, HS-21 Gewichtskorrektur; Konzept.md 6.6).
/// Buendelt die in Konzept 6.6 getrennt genannten Schnittstellen IDoserService, IMotorParameterService und IWeightCorrectionService (Nachdosierer)
/// in einer Schnittstelle, damit die Seitengruppe ohne Namenskonflikte zur Schliessmaschine (IClosingMachineService) bleibt.
/// </summary>
public interface IDoserService
{
    /// <summary>Sollgewicht und letztes Gewicht der Kontrollwaage (Titelzeile HS-41, Basis fuer "Soll absolut").</summary>
    DoserReferenceWeights ReferenceWeights { get; }

    /// <summary>Aktueller Stand eines Dosierers.</summary>
    DoserSnapshot GetDoser(DoserId id);

    /// <summary>Dummy-Grenzen und Einheit eines Werts (OP-28).</summary>
    DoserValueLimits GetLimits(DoserField field);

    /// <summary>Setzt einen Parameter (Sollwerte, Eichdosierung, Drehzahlen und Motorparameter). Bei <see cref="DoserField.TargetPercent"/> wird "Soll absolut" neu berechnet.</summary>
    Task SetValueAsync(DoserId id, DoserField field, double value);

    /// <summary>Waehlt Querschnecke, Ruehrer oder Regulierung an bzw. ab.</summary>
    Task SetSwitchAsync(DoserId id, DoserSwitch which, bool enabled);

    /// <summary>"Manuell": fordert einen Dosiervorgang an (RS-11 T15 Nr. 4).</summary>
    Task TriggerManualAsync(DoserId id);

    /// <summary>"Entleeren": Dauerfunktion, bis sie abgebrochen wird (RS-11 T15 Nr. 5).</summary>
    Task SetEmptyingAsync(DoserId id, bool enabled);

    /// <summary>"Eichdosierung": startet einen Dosiervorgang mit den Umdrehungen aus dem Feld "Eichdosierung Umdrehungen".</summary>
    Task StartCalibrationAsync(DoserId id);

    /// <summary>Motorparameter eines Dosierers (HS-12 fuer Main1 und Main2, HS-20 fuer Post).</summary>
    DoserMotorSettings GetMotorSettings(DoserId id);

    /// <summary>Gewichtskorrektur des Nachdosierers (HS-21).</summary>
    DoserWeightCorrectionData WeightCorrection { get; }

    Task SetWeightCorrectionAsync(DoserWeightCorrectionData data);

    /// <summary>"Dosierer Ausloesen manuell": dosiert eine Probe mit dem Sollgewicht der Gewichtskorrektur (HS-21 Schritt 2).</summary>
    Task TriggerWeightSampleAsync();

    /// <summary>"Gewichtsanpassung": berechnet die Korrekturkennlinie aus den gueltigen Stuetzstellen (HS-21 Schritt 4).</summary>
    Task<DoserAdjustResult> AdjustWeightAsync();

    /// <summary>Wenn sich Werte, Status oder Zulaessigkeiten aendern (ggf. nicht im UI-Thread).</summary>
    event EventHandler? Changed;
}
