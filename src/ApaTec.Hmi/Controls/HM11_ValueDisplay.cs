using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ApaTec.Hmi.Controls;

/// <summary>Wertart des Anzeigefelds (HM-11).</summary>
public enum ValueKind
{
    Number,
    Text,
    DateTime,
    Duration,
}

/// <summary>Darstellung einer Zeitdauer (HM-11): Single = ein Feld hhh:mm:ss, Parts = drei Felder mit Einheiten h, m, s.</summary>
public enum DurationLayout
{
    Single,
    Parts,
}

/// <summary>Darstellung des Anzeigefelds (HM-11): Feld mit Flaeche und Kontur oder Zeile ohne Flaeche.</summary>
public enum ValuePresentation
{
    Field,
    Row,
}

/// <summary>Groesse des Werts (HM-11): Large fuer grosse Gewichtsanzeige.</summary>
public enum ValueEmphasis
{
    Normal,
    Large,
}

/// <summary>
/// HM-11 Anzeigefeld (Wert-Zeile): schreibgeschuetzte Anzeige eines Werts mit Beschriftung, Einheit, optionalem Zaehler, Symbol und Ruecksetzfunktion.
/// Nur Dependency Properties (A-73); Textformat in <c>HM11_ValueTextConverter</c>, Darstellung in <c>HM11_ValueDisplay.Styles.xaml</c>.
/// Als Custom Control (nicht UserControl) umgesetzt, damit kein Code-behind entsteht.
/// </summary>
public class HM11_ValueDisplay : Control
{
    public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
        nameof(Label), typeof(string), typeof(HM11_ValueDisplay), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty ValueKindProperty = DependencyProperty.Register(
        nameof(ValueKind), typeof(ValueKind), typeof(HM11_ValueDisplay), new PropertyMetadata(ValueKind.Number));

    public static readonly DependencyProperty DurationLayoutProperty = DependencyProperty.Register(
        nameof(DurationLayout), typeof(DurationLayout), typeof(HM11_ValueDisplay), new PropertyMetadata(DurationLayout.Single));

    public static readonly DependencyProperty NumberValueProperty = DependencyProperty.Register(
        nameof(NumberValue), typeof(double?), typeof(HM11_ValueDisplay), new PropertyMetadata(null));

    public static readonly DependencyProperty TextValueProperty = DependencyProperty.Register(
        nameof(TextValue), typeof(string), typeof(HM11_ValueDisplay), new PropertyMetadata(null));

    // DateTime (Wertart DateTime) oder TimeSpan (Wertart Duration); null = Platzhalter.
    public static readonly DependencyProperty TimeValueProperty = DependencyProperty.Register(
        nameof(TimeValue), typeof(object), typeof(HM11_ValueDisplay), new PropertyMetadata(null));

    public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
        nameof(Unit), typeof(string), typeof(HM11_ValueDisplay), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty DecimalsProperty = DependencyProperty.Register(
        nameof(Decimals), typeof(int), typeof(HM11_ValueDisplay), new PropertyMetadata(0));

    public static readonly DependencyProperty PresentationProperty = DependencyProperty.Register(
        nameof(Presentation), typeof(ValuePresentation), typeof(HM11_ValueDisplay), new PropertyMetadata(ValuePresentation.Field));

    public static readonly DependencyProperty SuffixProperty = DependencyProperty.Register(
        nameof(Suffix), typeof(string), typeof(HM11_ValueDisplay), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty CounterProperty = DependencyProperty.Register(
        nameof(Counter), typeof(int?), typeof(HM11_ValueDisplay), new PropertyMetadata(null));

    public static readonly DependencyProperty ResetCommandProperty = DependencyProperty.Register(
        nameof(ResetCommand), typeof(ICommand), typeof(HM11_ValueDisplay), new PropertyMetadata(null));

    public static readonly DependencyProperty EmphasisProperty = DependencyProperty.Register(
        nameof(Emphasis), typeof(ValueEmphasis), typeof(HM11_ValueDisplay), new PropertyMetadata(ValueEmphasis.Normal));

    // Ergaenzungen zur Moduldefinition: optionales Symbol (Statuswert, Funktion "Symbol") und Zustand "Grenzwert verletzt".
    public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
        nameof(Icon), typeof(Geometry), typeof(HM11_ValueDisplay), new PropertyMetadata(null));

    public static readonly DependencyProperty IsLimitViolatedProperty = DependencyProperty.Register(
        nameof(IsLimitViolated), typeof(bool), typeof(HM11_ValueDisplay), new PropertyMetadata(false));

    static HM11_ValueDisplay()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM11_ValueDisplay), new FrameworkPropertyMetadata(typeof(HM11_ValueDisplay)));
    }

    public string Label
    {
        get => (string)GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    public ValueKind ValueKind
    {
        get => (ValueKind)GetValue(ValueKindProperty);
        set => SetValue(ValueKindProperty, value);
    }

    public DurationLayout DurationLayout
    {
        get => (DurationLayout)GetValue(DurationLayoutProperty);
        set => SetValue(DurationLayoutProperty, value);
    }

    public double? NumberValue
    {
        get => (double?)GetValue(NumberValueProperty);
        set => SetValue(NumberValueProperty, value);
    }

    public string? TextValue
    {
        get => (string?)GetValue(TextValueProperty);
        set => SetValue(TextValueProperty, value);
    }

    public object? TimeValue
    {
        get => GetValue(TimeValueProperty);
        set => SetValue(TimeValueProperty, value);
    }

    public string Unit
    {
        get => (string)GetValue(UnitProperty);
        set => SetValue(UnitProperty, value);
    }

    public int Decimals
    {
        get => (int)GetValue(DecimalsProperty);
        set => SetValue(DecimalsProperty, value);
    }

    public ValuePresentation Presentation
    {
        get => (ValuePresentation)GetValue(PresentationProperty);
        set => SetValue(PresentationProperty, value);
    }

    public string Suffix
    {
        get => (string)GetValue(SuffixProperty);
        set => SetValue(SuffixProperty, value);
    }

    public int? Counter
    {
        get => (int?)GetValue(CounterProperty);
        set => SetValue(CounterProperty, value);
    }

    public ICommand? ResetCommand
    {
        get => (ICommand?)GetValue(ResetCommandProperty);
        set => SetValue(ResetCommandProperty, value);
    }

    public ValueEmphasis Emphasis
    {
        get => (ValueEmphasis)GetValue(EmphasisProperty);
        set => SetValue(EmphasisProperty, value);
    }

    public Geometry? Icon
    {
        get => (Geometry?)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public bool IsLimitViolated
    {
        get => (bool)GetValue(IsLimitViolatedProperty);
        set => SetValue(IsLimitViolatedProperty, value);
    }
}
