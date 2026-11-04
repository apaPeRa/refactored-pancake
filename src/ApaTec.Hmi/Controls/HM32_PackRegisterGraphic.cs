using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ApaTec.Hmi.Controls;

/// <summary>Zustand einer Packungsstation (Referenz: grau, rot, gelb, orange, grün).</summary>
public enum PackState
{
    /// <summary>Keine Packung.</summary>
    None,

    /// <summary>Packung vorhanden.</summary>
    Present,

    /// <summary>Befüllt.</summary>
    Filled,

    /// <summary>In Ordnung.</summary>
    Ok,

    /// <summary>Schlecht (ausgestoßen).</summary>
    Bad,
}

/// <summary>Datensatz einer Station: Nummer, Zustand und Position im Layout (X/Y in geräteunabhängigen Einheiten, vom ViewModel berechnet).</summary>
public sealed class PackStation
{
    public int Number { get; set; }

    public PackState State { get; set; }

    public double X { get; set; }

    public double Y { get; set; }
}

/// <summary>HM-32 Packungsregister-Grafik: Stationsfelder im Layout, Legende, horizontaler Bildlauf (HS-28).</summary>
public sealed class HM32_PackRegisterGraphic : Control
{
    static HM32_PackRegisterGraphic()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM32_PackRegisterGraphic), new FrameworkPropertyMetadata(typeof(HM32_PackRegisterGraphic)));
    }

    /// <summary>Stationen mit Nummer, Zustand und Position im Layout.</summary>
    public static readonly DependencyProperty StationsProperty =
        DependencyProperty.Register(nameof(Stations), typeof(IReadOnlyList<PackStation>?), typeof(HM32_PackRegisterGraphic), new PropertyMetadata(null));

    public IReadOnlyList<PackStation>? Stations
    {
        get => (IReadOnlyList<PackStation>?)GetValue(StationsProperty);
        set => SetValue(StationsProperty, value);
    }

    /// <summary>Legende als feste Leiste unter dem Bildlaufbereich.</summary>
    public static readonly DependencyProperty ShowLegendProperty =
        DependencyProperty.Register(nameof(ShowLegend), typeof(bool), typeof(HM32_PackRegisterGraphic), new PropertyMetadata(true));

    public bool ShowLegend
    {
        get => (bool)GetValue(ShowLegendProperty);
        set => SetValue(ShowLegendProperty, value);
    }

    /// <summary>Antippen eines Felds (Parameter: PackStation), manuelle Zustandsänderung.</summary>
    public static readonly DependencyProperty ToggleStationCommandProperty =
        DependencyProperty.Register(nameof(ToggleStationCommand), typeof(ICommand?), typeof(HM32_PackRegisterGraphic), new PropertyMetadata(null));

    public ICommand? ToggleStationCommand
    {
        get => (ICommand?)GetValue(ToggleStationCommandProperty);
        set => SetValue(ToggleStationCommandProperty, value);
    }

    /// <summary>Bildlaufposition (Dependency Property laut Moduldefinition).</summary>
    public static readonly DependencyProperty HorizontalOffsetProperty =
        DependencyProperty.Register(nameof(HorizontalOffset), typeof(double), typeof(HM32_PackRegisterGraphic), new PropertyMetadata(0d));

    public double HorizontalOffset
    {
        get => (double)GetValue(HorizontalOffsetProperty);
        set => SetValue(HorizontalOffsetProperty, value);
    }

    /// <summary>Breite der Layoutfläche (Canvas) in geräteunabhängigen Einheiten, vom ViewModel aus dem Layout berechnet (Ergänzung).</summary>
    public static readonly DependencyProperty LayoutWidthProperty =
        DependencyProperty.Register(nameof(LayoutWidth), typeof(double), typeof(HM32_PackRegisterGraphic), new PropertyMetadata(0d));

    public double LayoutWidth
    {
        get => (double)GetValue(LayoutWidthProperty);
        set => SetValue(LayoutWidthProperty, value);
    }

    /// <summary>Höhe der Layoutfläche (Canvas) in geräteunabhängigen Einheiten (Ergänzung).</summary>
    public static readonly DependencyProperty LayoutHeightProperty =
        DependencyProperty.Register(nameof(LayoutHeight), typeof(double), typeof(HM32_PackRegisterGraphic), new PropertyMetadata(0d));

    public double LayoutHeight
    {
        get => (double)GetValue(LayoutHeightProperty);
        set => SetValue(LayoutHeightProperty, value);
    }
}
