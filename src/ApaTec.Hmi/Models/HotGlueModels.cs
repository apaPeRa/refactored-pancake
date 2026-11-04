using ApaTec.Hmi.Controls;

namespace ApaTec.Hmi.Models;

/// <summary>Schalter des Nordson-Heissleimgeraets (HS-07, RS-07 Tabellen T9 und T10).</summary>
public enum HotGlueSwitch
{
    /// <summary>Heizungen von Geraet, Schlaeuchen und Duese.</summary>
    Heaters,

    /// <summary>Standby: alle Temperaturen um die globale Standby-Absenkung reduziert.</summary>
    Standby,

    /// <summary>Foerderpumpe.</summary>
    Pump,

    /// <summary>Interne Zeitschaltuhr (Zeitplan) des Geraets.</summary>
    Timer,

    /// <summary>Verwendung eines Nachfuellsystems.</summary>
    RefillSystem,
}

/// <summary>Einstellwerte des Heissleimgeraets (HS-07 Fuellparameter, HS-08 globale Einstellungen, HS-09 Druck und Geraetelimits).</summary>
public enum HotGlueParameter
{
    TargetFillLevel,
    MaxFillTime,
    StandbyDelta,
    ReadyDelay,
    OverTemperatureDelta,
    UnderTemperatureDelta,
    UpperSpeed,
    LowerSpeed,
    UpperPressure,
    LowerPressure,
    UpperPressureLimit,
    LowerPressureLimit,
    OverPressureDelta,
    UnderPressureDelta,
}

/// <summary>Die sieben Zustandsanzeigen des Geraets in der Reihenfolge von HS-07.</summary>
public enum HotGlueLed
{
    Ready,
    Temperature,
    RefillSystem,
    TankLevel,
    TankLid,
    NoFault,
    NoAlarm,
}

/// <summary>Zustand einer Geraete-LED: OK, Abweichung (Fehler) oder unbekannt (keine Kommunikation).</summary>
public enum HotGlueLedState
{
    Unknown,
    Ok,
    Fault,
}

/// <summary>Zonenkennungen des Heissleimgeraets in der Reihenfolge der Zonenliste von HS-08.</summary>
public static class HotGlueZoneIds
{
    public const string Tank = "Tank";
    public const string Hose1 = "Hose1";
    public const string Gun1 = "Gun1";
    public const string Hose2 = "Hose2";
    public const string Gun2 = "Gun2";
    public const string Manifold = "Manifold";
}

/// <summary>Zulaessiger Bereich und Nachkommastellen eines Einstellwerts (Dummy-Grenzen, OP-28).</summary>
public sealed record HotGlueLimits(double Minimum, double Maximum, int Decimals);

/// <summary>
/// Temperaturzone des Heissleimgeraets. <see cref="Actual"/> ist null bei fehlender Kommunikation; eine abgewaehlte Zone meldet 0 Grad.
/// </summary>
public sealed record HotGlueZone(string Id, double Setpoint, double? Actual, bool IsEnabled, bool HasFault);

/// <summary>Anforderung an das Eingabe-Pop-up (<c>DialogKeys.Input</c>, HM-13) der Heissleimseiten. Zeitwerte (Kind = Time) sind Minuten seit 00:00; Ergebnis ist <c>double</c>.</summary>
public sealed record HotGlueInputRequest(
    string Title,
    double? Value,
    string Unit,
    double? Minimum,
    double? Maximum,
    int Decimals,
    InputKind Kind = InputKind.Number,
    string? HelpText = null) : IInputRequest;

/// <summary>Anforderung an das Zeitplan-Eintrag-Pop-up (<c>DialogKeys.ScheduleEntry</c>, HM-30): Tag, vorhandener Eintrag (null = Neuanlage), alle Eintraege des Tages und Berechtigung.</summary>
public sealed record HotGlueScheduleEntryRequest(DayOfWeek Day, ScheduleEntry? Existing, IReadOnlyList<ScheduleEntry> DayEntries, bool IsAuthorized);

/// <summary>Aktion des Zeitplan-Eintrag-Pop-ups.</summary>
public enum HotGlueScheduleAction
{
    Save,
    Delete,
}

/// <summary>Ergebnis des Zeitplan-Eintrag-Pop-ups (<c>DialogResult&lt;HotGlueScheduleResult&gt;</c>): zu speichernder bzw. zu loeschender Eintrag.</summary>
public sealed record HotGlueScheduleResult(HotGlueScheduleAction Action, ScheduleEntry Entry);
