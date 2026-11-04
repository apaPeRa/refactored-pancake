using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>Kennzahlen, Versorgung, Stueckzaehler und Historie der Seiten HS-01 und HS-02 (Konzept.md 6.6). Befehle haben in M2 keine Wirkung auf eine Maschine.</summary>
public interface IProductionService
{
    /// <summary>false bei Kommunikationsausfall: Anzeigen zeigen "---", Reset ist deaktiviert (HS-02).</summary>
    bool IsValid { get; }

    /// <summary>Aktuelle Produktion (ruecksetzbarer Stueckzaehler) = Zeile "Aktuell".</summary>
    long CurrentProduction { get; }

    /// <summary>Wert des Stueckzaehlers beim letzten Ruecksetzen = Zeile "Historie 1".</summary>
    long LastProduction { get; }

    /// <summary>Letztes gewogenes Gewicht in g; null = ungueltig.</summary>
    double? LastWeight { get; }

    /// <summary>Nummer des Dosierers bzw. der Waage zum letzten Gewicht; null = nur ein Dosierer.</summary>
    int? LastWeightIndex { get; }

    /// <summary>Mittleres Gewicht in g.</summary>
    double? MeanWeight { get; }

    /// <summary>Standardabweichung in g.</summary>
    double? StandardDeviation { get; }

    ProductionWeightMode WeightMode { get; }

    /// <summary>Ggesamte Produktion seit Inbetriebnahme (HS-02).</summary>
    long TotalProduction { get; }

    /// <summary>Betriebsstunden der Maschine (HS-02, Format hhh:mm:ss).</summary>
    TimeSpan OperatingTime { get; }

    /// <summary>Haltedauer der Reset-Taste (Dummy, OP-42).</summary>
    TimeSpan ResetHoldDuration { get; }

    /// <summary>Versorgung: Druckluft, Papier, Produkt, Bandwaage, Folgemaschine.</summary>
    IReadOnlyList<ProductionSupply> Supplies { get; }

    /// <summary>13 Zaehlerzeilen: Index 0 = Aktuell, 1 bis 12 = Historie.</summary>
    IReadOnlyList<ProductionCounterEntry> Counters { get; }

    /// <summary>Stellt Erfassungsart um; Mittelwert und Standardabweichung folgen (S01-8). false = Maschine hat nicht quittiert.</summary>
    Task<bool> SetWeightModeAsync(ProductionWeightMode mode);

    /// <summary>Ruecksetzen: alle Eintraege rutschen eine Zeile nach unten, "Aktuell" beginnt bei 0 (S02-4).</summary>
    Task<bool> ResetCounterAsync();

    /// <summary>Wenn sich ein Wert aendert (ggf. nicht im UI-Thread).</summary>
    event EventHandler? Changed;
}
