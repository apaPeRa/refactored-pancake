using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>
/// Papier- und Kartonzufuehrung samt Leimspuren (HS-05, HS-06; Konzept.md 6.6). Befehle haben in M2 keine Wirkung auf eine Maschine (Dummy, A-75).
/// Die Zahlen aus den Bildern sind Beispielwerte; Wertebereiche und Plausibilitaetsregeln nennt die Quelle nicht (OP-28).
/// </summary>
public interface IFeederService
{
    /// <summary>Namen der fuenf Spuelventile der Kartonzufuehrung (3Y25 bis 3Y29), in der Reihenfolge der Anwahltasten.</summary>
    IReadOnlyList<string> FlushValveNames { get; }

    PaperFeederState GetPaper();

    CartonFeederState GetCarton();

    /// <summary>Dummy-Grenzen eines Werts (OP-28).</summary>
    FeederLimits GetLimits(FeederValue value);

    /// <summary>Schreibt einen Einstellwert (kein <see cref="FeederValue.CartonTrackAngle"/>, dafuer <see cref="SetGlueTrackAngle"/>).</summary>
    void SetValue(FeederValue value, double newValue);

    /// <summary>Schreibt den Winkel eines Leimspur-Felds (Index 0 bis 17, zeilenweise: Reihe 1 mit 5, Reihe 2 mit 4, Reihe 3 mit 5, Reihe 4 mit 4 Feldern).</summary>
    void SetGlueTrackAngle(int fieldIndex, double angle);

    /// <summary>Heissleimauftrag ein (true) oder abgewaehlt (false).</summary>
    void SetGlueEnabled(bool enabled);

    /// <summary>Waehlt ein Spuelventil an oder ab.</summary>
    void SetFlushValve(int index, bool selected);

    /// <summary>Wenn sich ein Wert aendert (ggf. nicht im UI-Thread).</summary>
    event EventHandler? Changed;
}
