using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>
/// Schliessmaschine (HS-16 Einstellungen, HS-17 Motorparameter, HS-18 Gewichtskorrektur; Konzept.md 6.6).
/// Buendelt die in Konzept 6.6 getrennt genannten Schnittstellen IClosingMachineService, IMotorParameterService und IWeightCorrectionService
/// fuer die Schliessmaschine, damit die Seitengruppe ohne Namenskonflikte zu HS-12/HS-20/HS-21 bleibt.
/// </summary>
public interface IClosingMachineService
{
    /// <summary>Aktuelle Einstellungen von HS-16.</summary>
    ClosingMachineSettings Settings { get; }

    /// <summary>Aktuelle Motorparameter von HS-17.</summary>
    ClosingMotorSettings MotorSettings { get; }

    /// <summary>Aktuelle Daten der Gewichtskorrektur von HS-18.</summary>
    ClosingWeightCorrectionData WeightCorrection { get; }

    /// <summary>Ob Aenderungen im aktuellen Betriebszustand zulaessig sind (Dummy, OP-31).</summary>
    bool IsEditingAllowed { get; }

    /// <summary>Ob "Dosierer Ausloesen manuell" im aktuellen Betriebszustand zulaessig ist (Dummy, OP-31).</summary>
    bool CanDoseManually { get; }

    /// <summary>Dummy-Grenzen und Einheit eines Felds (OP-28).</summary>
    ClosingValueLimits GetLimits(ClosingField field);

    Task SetSettingsAsync(ClosingMachineSettings settings);

    Task SetMotorSettingsAsync(ClosingMotorSettings settings);

    Task SetWeightCorrectionAsync(ClosingWeightCorrectionData data);

    /// <summary>Loest eine einzelne Dosierung mit dem eingestellten Sollgewicht aus (HS-18 Schritt 2).</summary>
    Task TriggerManualDosingAsync();

    /// <summary>Berechnet die Korrekturkennlinie aus den gueltigen Stuetzstellen (HS-18 Schritt 4).</summary>
    Task<ClosingAdjustResult> AdjustWeightAsync();

    /// <summary>Wenn sich Werte oder Zulaessigkeiten aendern (ggf. nicht im UI-Thread).</summary>
    event EventHandler? Changed;
}
