using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>Geber setzen (HS-32): Geberliste, Positionen, Initialisierung und Nullpunkt setzen. Sicherheitsrelevant (Not-Aus-Voraussetzung).</summary>
public interface IEncoderService
{
    /// <summary>Geber der Maschinenkonfiguration in Blaetterreihenfolge (OP-41).</summary>
    IReadOnlyList<EncoderInfo> GetEncoders();

    EncoderState GetState(int index);

    /// <summary>true, wenn die Steuerung "Not-Aus gedrueckt" meldet; false bei nicht gedrueckt oder unbekannt (sicherer Zustand).</summary>
    bool IsEmergencyStopPressed { get; }

    /// <summary>Uebernimmt die aktuelle Motorposition als neue Geberposition (Nullpunkt). Wirkungslos ohne Not-Aus.</summary>
    bool SetEncoderZero(int index);

    /// <summary>Wenn sich ein Geberzustand oder der Not-Aus-Zustand aendert (ggf. nicht im UI-Thread).</summary>
    event EventHandler? Changed;
}
