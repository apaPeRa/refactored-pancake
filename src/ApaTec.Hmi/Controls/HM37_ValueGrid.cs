using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ApaTec.Hmi.Controls;

/// <summary>Güte eines erfassten Gewichts.</summary>
public enum WeightQuality
{
    /// <summary>Unbekannt.</summary>
    Unknown,

    /// <summary>Gut.</summary>
    Good,

    /// <summary>Schlecht.</summary>
    Bad,
}

/// <summary>Betriebsart der Gewichtserfassung.</summary>
public enum SamplingMode
{
    /// <summary>Einzel: manuelle Stichprobe.</summary>
    Single,

    /// <summary>Fortlaufend: nach 50 Werten wird überschrieben.</summary>
    Continuous,
}

/// <summary>Zelle des Wertegitters.</summary>
public sealed class WeightCell
{
    /// <summary>Gewicht in g; null = leere Zelle.</summary>
    public double? Weight { get; set; }

    public WeightQuality Quality { get; set; }

    /// <summary>Zuletzt erfasste Zelle (Markierung; vom ViewModel passend zu LastIndex gesetzt).</summary>
    public bool IsLast { get; set; }
}

/// <summary>HM-37 Wertegitter: 10 Zeilen x 5 Spalten für erfasste Einzelgewichte (HS-14).</summary>
public sealed class HM37_ValueGrid : Control
{
    static HM37_ValueGrid()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM37_ValueGrid), new FrameworkPropertyMetadata(typeof(HM37_ValueGrid)));
    }

    /// <summary>Zellen in Anzeigereihenfolge (zeilenweise), höchstens Capacity.</summary>
    /// <summary>false blendet die Kopfzeile (Umschalter, Start) aus, wenn die Tasten bereits in der Funktionsleiste liegen (HS-14, B-16).</summary>
    public static readonly DependencyProperty ShowHeaderProperty = DependencyProperty.Register(
        nameof(ShowHeader), typeof(bool), typeof(HM37_ValueGrid), new PropertyMetadata(true));

    public static readonly DependencyProperty CellsProperty =
        DependencyProperty.Register(nameof(Cells), typeof(IReadOnlyList<WeightCell>), typeof(HM37_ValueGrid), new PropertyMetadata(null));

    public bool ShowHeader
    {
        get => (bool)GetValue(ShowHeaderProperty);
        set => SetValue(ShowHeaderProperty, value);
    }

    public IReadOnlyList<WeightCell>? Cells
    {
        get => (IReadOnlyList<WeightCell>?)GetValue(CellsProperty);
        set => SetValue(CellsProperty, value);
    }

    /// <summary>Index der zuletzt erfassten Zelle (0 bis 49), -1 = keine.</summary>
    public static readonly DependencyProperty LastIndexProperty =
        DependencyProperty.Register(nameof(LastIndex), typeof(int), typeof(HM37_ValueGrid), new PropertyMetadata(-1));

    public int LastIndex
    {
        get => (int)GetValue(LastIndexProperty);
        set => SetValue(LastIndexProperty, value);
    }

    /// <summary>Betriebsart Einzel oder Fortlaufend.</summary>
    public static readonly DependencyProperty ModeProperty =
        DependencyProperty.Register(nameof(Mode), typeof(SamplingMode), typeof(HM37_ValueGrid), new PropertyMetadata(SamplingMode.Single));

    public SamplingMode Mode
    {
        get => (SamplingMode)GetValue(ModeProperty);
        set => SetValue(ModeProperty, value);
    }

    /// <summary>Kapazität in Stück.</summary>
    public static readonly DependencyProperty CapacityProperty =
        DependencyProperty.Register(nameof(Capacity), typeof(int), typeof(HM37_ValueGrid), new PropertyMetadata(50));

    public int Capacity
    {
        get => (int)GetValue(CapacityProperty);
        set => SetValue(CapacityProperty, value);
    }

    /// <summary>Start löscht alle Werte (Modus Einzel).</summary>
    public static readonly DependencyProperty StartCommandProperty =
        DependencyProperty.Register(nameof(StartCommand), typeof(ICommand), typeof(HM37_ValueGrid), new PropertyMetadata(null));

    public ICommand? StartCommand
    {
        get => (ICommand?)GetValue(StartCommandProperty);
        set => SetValue(StartCommandProperty, value);
    }

    /// <summary>Umschalten Einzel/Fortlaufend.</summary>
    public static readonly DependencyProperty ToggleModeCommandProperty =
        DependencyProperty.Register(nameof(ToggleModeCommand), typeof(ICommand), typeof(HM37_ValueGrid), new PropertyMetadata(null));

    public ICommand? ToggleModeCommand
    {
        get => (ICommand?)GetValue(ToggleModeCommandProperty);
        set => SetValue(ToggleModeCommandProperty, value);
    }
}
