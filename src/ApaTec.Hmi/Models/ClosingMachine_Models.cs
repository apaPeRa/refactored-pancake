using CommunityToolkit.Mvvm.ComponentModel;

namespace ApaTec.Hmi.Models;

/// <summary>Bezeichner der editierbaren Felder der Schliessmaschine (HS-16 bis HS-18); dient als <c>CommandParameter</c> fuer das Eingabe-Pop-up.</summary>
public enum ClosingField
{
    ConveyorSpeed,
    HeadGlueStart,
    HeadGlueEnd,
    HeadGlueDuration,
    Shaker1,
    Shaker2,
    TargetWeight,
}

/// <summary>Dummy-Grenzen und Darstellung eines Felds (Wertebereiche fehlen in der Quelle, OP-28).</summary>
public sealed record ClosingValueLimits(double Minimum, double Maximum, int Decimals, string Unit);

/// <summary>Anforderung an das Eingabe-Pop-up (<c>DialogKeys.Input</c>, HM-13): Feldname, vorbelegter Wert, Einheit und Grenzen.</summary>
public sealed record ClosingInputRequest(string Title, double Value, ClosingValueLimits Limits);

/// <summary>Einstellungen der Seite HS-16: Auslaufband, Kopfleim, Ruettlung.</summary>
public sealed record ClosingMachineSettings(
    double ConveyorSpeed,
    bool HeadGlueEnabled,
    double HeadGlueStart,
    double HeadGlueEnd,
    double HeadGlueDuration,
    bool ShakerEnabled,
    double Shaker1,
    double Shaker2);

/// <summary>Bewegungsparameter einer Verschlussbewegung (Zu oder Auf), HS-17: Position in Grad, sonst Prozent.</summary>
public sealed record ClosingClosureMotion(double Position, double Speed, double Acceleration, double Deceleration, double Jerk);

/// <summary>Bewegungsparameter der Schnecke (HS-17), Prozent.</summary>
public sealed record ClosingScrewMotion(double Acceleration, double Deceleration, double Jerk);

/// <summary>Motorparameter der Schliessmaschine (HS-17): Verschluss Zu, Verschluss Auf, Schnecke.</summary>
public sealed record ClosingMotorSettings(ClosingClosureMotion Closed, ClosingClosureMotion Open, ClosingScrewMotion Screw);

/// <summary>Stuetzstelle der Gewichtskorrektur (HS-18): Soll und Ist in g, 0 = leer.</summary>
public sealed record ClosingWeightPoint(double Nominal, double Actual);

/// <summary>Daten der Gewichtskorrektur (HS-18): Sollgewicht und 20 Stuetzstellen (2 x 10).</summary>
public sealed record ClosingWeightCorrectionData(double TargetWeight, IReadOnlyList<ClosingWeightPoint> Points);

/// <summary>Ergebnis der Gewichtsanpassung: Zahl der verwendeten Stuetzstellen; <c>Accepted</c> false, wenn die Steuerung nicht berechnet hat.</summary>
public sealed record ClosingAdjustResult(bool Accepted, int UsedPoints);

/// <summary>Bearbeitbarer Wert mit Grenzen und Fehlertext fuer Eingabefelder (HM-12/HM-24 binden an <see cref="Value"/>, <see cref="ErrorText"/>).</summary>
public sealed partial class ClosingEditableValue : ObservableObject
{
    public ClosingEditableValue(ClosingField field, double value, ClosingValueLimits limits)
    {
        Field = field;
        _value = value;
        Limits = limits;
    }

    public ClosingField Field { get; }

    public ClosingValueLimits Limits { get; }

    public double Minimum => Limits.Minimum;

    public double Maximum => Limits.Maximum;

    [ObservableProperty]
    private double _value;

    [ObservableProperty]
    private string? _errorText;

    [ObservableProperty]
    private bool _isEditing;
}
