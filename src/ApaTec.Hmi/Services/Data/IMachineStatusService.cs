using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>Rahmenwerte der Maschine: Betriebsart, Geschwindigkeit Ist und Maschinenwinkel (HM-02, HM-05; Konzept.md 6.6).</summary>
public interface IMachineStatusService
{
    OperatingMode OperatingMode { get; }

    /// <summary>Geschwindigkeit Ist in 1/min.</summary>
    double Speed { get; }

    /// <summary>Maschinenwinkel in Grad (0 bis 360).</summary>
    double Angle { get; }

    /// <summary>Wenn sich ein Wert aendert (ggf. nicht im UI-Thread).</summary>
    event EventHandler? Changed;
}
