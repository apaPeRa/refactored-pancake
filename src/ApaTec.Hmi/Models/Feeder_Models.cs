using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.Models;

/// <summary>Bezeichner der editierbaren Zahlenwerte der Zufuehrungen (HS-05 Papier, HS-06 Karton); dient als Schluessel fuer Dienst und Eingabe-Pop-up.</summary>
public enum FeederValue
{
    PaperDiameterRollEnd,
    PaperBrakeStandstill,
    PaperDiameterMax,
    PaperBrakeAtMax,
    PaperDiameterMin,
    PaperBrakeAtMin,
    PaperSpliceEjectCount,
    PaperCouplingShift,
    PaperCouplingStopPosition,
    CartonCompensationOn,
    CartonCompensationOff,
    CartonGlueCold,
    CartonTrackAngle,
}

/// <summary>Dummy-Grenzen eines Zufuehrungswerts (Wertebereiche fehlen in der Quelle, OP-28, A-50).</summary>
public sealed record FeederLimits(double Minimum, double Maximum);

/// <summary>Zustand der Papierzufuehrung (HS-05): Einstellwerte, Messwerte und die zwei Klebestellen-Zustaende.</summary>
public sealed record PaperFeederState(
    double DiameterRollEnd,
    double BrakeStandstill,
    double DiameterMax,
    double BrakeAtMax,
    double DiameterMin,
    double BrakeAtMin,
    double SpliceEjectCount,
    double CouplingShift,
    double CouplingStopPosition,
    double RollDiameter,
    double BrakePressure,
    bool SpliceDetected,
    bool SpliceSensor);

/// <summary>Zustand der Kartonzufuehrung (HS-06): Heissleimauftrag, Kompensation, Leim kalt, Spuelanwahl und 18 Leimspur-Winkel (Reihe 1 bis 4 mit 5, 4, 5, 4 Feldern, zeilenweise).</summary>
public sealed record CartonFeederState(
    bool GlueEnabled,
    double CompensationOn,
    double CompensationOff,
    double GlueCold,
    IReadOnlyList<bool> FlushValves,
    IReadOnlyList<double> TrackAngles);

/// <summary>Anforderung an das Eingabe-Pop-up (<c>DialogKeys.Input</c>, HM-13) der Zufuehrungsseiten; Ergebnis ist der neue Wert (<c>double</c>).</summary>
public sealed record FeederInputRequest(string Title, double Value, string Unit, int Decimals, FeederLimits Limits, string? HelpText) : IInputRequest
{
    double? IInputRequest.Value => Value;

    double? IInputRequest.Minimum => Limits.Minimum;

    double? IInputRequest.Maximum => Limits.Maximum;

    Controls.InputKind IInputRequest.Kind => Controls.InputKind.Number;
}

/// <summary>
/// Bearbeitbarer Zahlenwert einer Zufuehrungsseite fuer ein HM-12-Eingabefeld: Wert, Grenzen, Texte (aus <c>.resx</c>, vom ViewModel gesetzt),
/// Fehlertext, Berechtigungs- und Bearbeitungszustand sowie der Antippen-Befehl.
/// </summary>
public sealed partial class FeederValueField : ObservableObject
{
    private readonly Func<FeederValueField, Task> _edit;

    public FeederValueField(FeederValue id, string labelKey, string unitKey, string titleKey, string helpKey, Func<FeederValueField, Task> edit, int index = 0)
    {
        Id = id;
        LabelKey = labelKey;
        UnitKey = unitKey;
        TitleKey = titleKey;
        HelpKey = helpKey;
        Index = index;
        _edit = edit;
        EditCommand = new AsyncRelayCommand(() => _edit(this));
    }

    public FeederValue Id { get; }

    /// <summary>Index innerhalb einer Gruppe gleichartiger Werte (Leimspur-Feld), sonst 0.</summary>
    public int Index { get; }

    public string LabelKey { get; }

    public string UnitKey { get; }

    public string TitleKey { get; }

    public string HelpKey { get; }

    public ICommand EditCommand { get; }

    [ObservableProperty]
    private double? _value;

    [ObservableProperty]
    private double? _minimum;

    [ObservableProperty]
    private double? _maximum;

    [ObservableProperty]
    private string _label = string.Empty;

    [ObservableProperty]
    private string _unit = string.Empty;

    [ObservableProperty]
    private string _title = string.Empty;

    [ObservableProperty]
    private string _helpText = string.Empty;

    [ObservableProperty]
    private string _requiredRoleText = string.Empty;

    [ObservableProperty]
    private string? _errorText;

    [ObservableProperty]
    private bool _isAuthorized = true;

    [ObservableProperty]
    private bool _isEditing;
}

/// <summary>Spuelventil der Kartonzufuehrung (HS-06 "Anwahl Spuelen", 3Y25 bis 3Y29): Name und Anwahl; <see cref="IsSelected"/> meldet jede Aenderung ueber <see cref="SelectionChanged"/>.</summary>
public sealed partial class FlushValveItem : ObservableObject
{
    public FlushValveItem(int index, string name, bool isSelected)
    {
        Index = index;
        Name = name;
        _isSelected = isSelected;
    }

    public int Index { get; }

    public string Name { get; }

    /// <summary>Wird bei einer Aenderung durch die Bedienung (nicht durch <see cref="SetSilently"/>) ausgeloest.</summary>
    public event EventHandler? SelectionChanged;

    [ObservableProperty]
    private bool _isSelected;

    /// <summary>Setzt die Anwahl ohne <see cref="SelectionChanged"/> (Abgleich mit dem Dienst).</summary>
    public void SetSilently(bool value)
    {
        _suppress = true;
        IsSelected = value;
        _suppress = false;
    }

    private bool _suppress;

    partial void OnIsSelectedChanged(bool value)
    {
        if (!_suppress)
        {
            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
