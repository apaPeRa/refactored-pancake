namespace ApaTec.Hmi.Models;

// Datenmodelle der Seitengruppe Produktion (HS-01, HS-02, HS-03, HS-43). Beispielwerte aus den Bildern der Referenz (RS-02, RS-03) und dem Design (DS-01).

/// <summary>Die 16 Betriebsfunktionen der Seite Produktion (RS-01 Tabelle T2). Reihenfolge ohne fachliche Bedeutung.</summary>
public enum ProductionFunction
{
    /// <summary>Sammelzustand "Automatik Produktion": Ein nur, wenn alle erfassten Funktionen angewaehlt sind (S01-9).</summary>
    Automatic,

    /// <summary>"Maschine schnell / langsam": Ein = Sollgeschwindigkeit Schnell, Aus = Langsam (S01-4).</summary>
    Fast,
    Lighting,
    MandrelBlower,
    FeedPaper,
    FeedCarton,
    WebControl,
    BlowOutEmptyPacks,
    ProductFeed,
    ProductMonitoring,
    Filling,
    Shaking,
    DustExtraction,
    EmptyHopper,
    Heating,
    LineOperation,
}

/// <summary>Zustand einer Betriebsfunktion. <see cref="IsPending"/> bis zur Rueckmeldung der Maschine; <see cref="HasFault"/> = Maschine meldet die Funktion als gestoert (S01-10).</summary>
public sealed record ProductionFunctionStatus(ProductionFunction Function, bool IsOn, bool IsEnabled, bool HasFault, bool IsPending);

/// <summary>Erfassungsart von Mittelwert und Standardabweichung (RS-01 T1 Zeile 7).</summary>
public enum ProductionWeightMode
{
    Continuous,
    Sample,
}

/// <summary>Posten der Gruppe Versorgung (DS-01).</summary>
public enum ProductionSupplyItem
{
    CompressedAir,
    Paper,
    Product,
    BeltScale,
    FollowMachine,
}

/// <summary>Zustand eines Versorgungspostens; Ok = "IO", Invalid = Kommunikationsausfall ("---").</summary>
public enum ProductionSupplyState
{
    Ok,
    Warning,
    Error,
    Invalid,
}

/// <summary>Versorgungszeile: Zustand plus Zustandswort der Maschine (S01-11, OP-11).</summary>
public sealed record ProductionSupply(ProductionSupplyItem Item, ProductionSupplyState State, string Word);

/// <summary>Zaehlerzeile von HS-02: Index 0 = "Aktuell", 1 bis 12 = "Historie 1 bis 12". <see cref="ResetTime"/> null = leere Historie.</summary>
public sealed record ProductionCounterEntry(long Count, DateTime? ResetTime);

/// <summary>Die fuenf Geschwindigkeiten des Pop-ups HS-03 in der Reihenfolge der Referenz.</summary>
public enum MachineSpeedKind
{
    Maximum,
    Fast,
    Slow,
    Jog,
    Minimum,
}

/// <summary>Zulaessiger Bereich einer Geschwindigkeit in 1/min (Plausibilitaet S03-2, Dummy).</summary>
public sealed record MachineSpeedLimits(double Minimum, double Maximum);

/// <summary>Ein Eintrag der Rezeptliste (Platzhalter, OP-01).</summary>
public sealed record ProductionRecipe(string Name);
