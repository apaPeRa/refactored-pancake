using ApaTec.Hmi.Controls;

namespace ApaTec.Hmi.Models;

/// <summary>Dummy-Grenzen eines Einstellwerts (Wertebereiche fehlen in der Quelle, OP-28, A-50).</summary>
public sealed record MachineValueLimits(double Minimum, double Maximum);

/// <summary>Anforderung an das Eingabe-Pop-up (<c>DialogKeys.Input</c>, HM-13) der Seiten HS-22 bis HS-26; Ergebnis ist <c>double?</c> (Zahl) bzw. <c>string</c> (Text).</summary>
public sealed record MachineInputRequest(string Title, double? Value, string Unit, int Decimals, MachineValueLimits? Limits, InputKind Kind, string? Text = null, string? HelpText = null);

/// <summary>Anforderung an das Bestaetigungs-Pop-up (<c>DialogKeys.Confirmation</c>, HM-14); Ergebnis ist <c>bool</c>.</summary>
public sealed record MachineConfirmRequest(string Title, string Message, string AcceptLabel, string CancelLabel);

/// <summary>State-Wert einer Heizzone (HS-22): aus, Zieltemperatur erreicht, nicht bereit/Fehler.</summary>
public enum HeaterZoneState
{
    Off,
    TargetReached,
    Fault,
}

/// <summary>Heizzone (HS-22).</summary>
public sealed record HeaterZoneInfo(int Index, string Name, bool IsEnabled, bool IsMonitored, double Setpoint, double Actual, HeaterZoneState State, bool OutputOn);

/// <summary>Dosierer der Regulierung (HS-23).</summary>
public enum RegulationDoser
{
    Main,
    Post,
}

/// <summary>Editierbare Zahlenfelder des Regulierungsblocks (HS-23).</summary>
public enum RegulationField
{
    SampleCount,
    Step,
    Tolerance,
    MaxCorrection,
    CurrentCorrection,
}

/// <summary>Parametersatz der Regulierung eines Dosierers (HS-23).</summary>
public sealed record RegulationSettings(int SampleCount, double Step, double Tolerance, double MaxCorrection, double CurrentCorrection, double Mean, int MeanCount, bool IsRegulationOn);

/// <summary>Editierbare Felder der Nockenseite (HS-25).</summary>
public enum CamField
{
    Number,
    StartAngle,
    StartTime,
    EndAngle,
    EndTime,
    CamType,
}

/// <summary>Zeile der Nockenuebersicht (HS-26).</summary>
public sealed record CamSummary(int Number, string Name, double StartAngle, double EndAngle, bool IsActive);

/// <summary>Einstellwerte einer Nocke (HS-25).</summary>
public sealed record CamDetail(int Number, double StartAngle, double StartTime, double EndAngle, double EndTime, int CamType, int EncoderIndex, string Designation);

/// <summary>Laufende Anzeige einer Nocke: Geberposition und ob sie innerhalb der Nocke liegt.</summary>
public sealed record CamLiveData(double Position, bool IsInside);
