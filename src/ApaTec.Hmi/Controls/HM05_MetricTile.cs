using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ApaTec.Hmi.Controls;

/// <summary>Breite der Kennzahl-Kachel: Frame = Rahmenzeile (Mindestbreite <c>Size.Metric.MinWidth</c>), Content = Inhaltsbereich.</summary>
public enum TileSize
{
    Content,
    Frame,
}

/// <summary>Kennzahl-Kachel (HM-05): Symbol und Messwert, optional mit Index und als antippbare Kachel. Nur Dependency Properties, Darstellung in HM05_MetricTile.Styles.xaml.</summary>
public sealed class HM05_MetricTile : Button
{
    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register(nameof(Icon), typeof(Geometry), typeof(HM05_MetricTile), new PropertyMetadata(null));

    /// <summary>Optionale Beschriftung, z. B. "Soll" oder "Netto".</summary>
    public static readonly DependencyProperty LabelProperty =
        DependencyProperty.Register(nameof(Label), typeof(string), typeof(HM05_MetricTile), new PropertyMetadata(string.Empty));

    /// <summary>Messwert; null (und kein <see cref="TimeValue"/>) zeigt "---".</summary>
    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register(nameof(Value), typeof(double?), typeof(HM05_MetricTile), new PropertyMetadata(null));

    /// <summary>Zeitwert h:m:s (Betriebsstunden), ersetzt <see cref="Value"/>.</summary>
    public static readonly DependencyProperty TimeValueProperty =
        DependencyProperty.Register(nameof(TimeValue), typeof(TimeSpan?), typeof(HM05_MetricTile), new PropertyMetadata(null));

    public static readonly DependencyProperty UnitProperty =
        DependencyProperty.Register(nameof(Unit), typeof(string), typeof(HM05_MetricTile), new PropertyMetadata(string.Empty));

    /// <summary>Zahlenformat des Werts, z. B. "N0" oder "N1".</summary>
    public static readonly DependencyProperty StringFormatProperty =
        DependencyProperty.Register(nameof(StringFormat), typeof(string), typeof(HM05_MetricTile), new PropertyMetadata("N0"));

    /// <summary>Kleiner Index unten rechts (Nummer des Dosierers/der Waage, 1 bis 99).</summary>
    public static readonly DependencyProperty IndexProperty =
        DependencyProperty.Register(nameof(Index), typeof(int?), typeof(HM05_MetricTile), new PropertyMetadata(null));

    public static readonly DependencyProperty TileSizeProperty =
        DependencyProperty.Register(nameof(TileSize), typeof(TileSize), typeof(HM05_MetricTile), new PropertyMetadata(TileSize.Content));

    /// <summary>true: antippbare Kachel mit Chevron, oeffnet ein Pop-up.</summary>
    public static readonly DependencyProperty IsInteractiveProperty =
        DependencyProperty.Register(nameof(IsInteractive), typeof(bool), typeof(HM05_MetricTile), new PropertyMetadata(false));

    public static readonly DependencyProperty OpenCommandProperty =
        DependencyProperty.Register(nameof(OpenCommand), typeof(ICommand), typeof(HM05_MetricTile), new PropertyMetadata(null));

    static HM05_MetricTile()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM05_MetricTile), new FrameworkPropertyMetadata(typeof(HM05_MetricTile)));
    }

    public Geometry? Icon
    {
        get => (Geometry?)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public string Label
    {
        get => (string)GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    public double? Value
    {
        get => (double?)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public TimeSpan? TimeValue
    {
        get => (TimeSpan?)GetValue(TimeValueProperty);
        set => SetValue(TimeValueProperty, value);
    }

    public string Unit
    {
        get => (string)GetValue(UnitProperty);
        set => SetValue(UnitProperty, value);
    }

    public string StringFormat
    {
        get => (string)GetValue(StringFormatProperty);
        set => SetValue(StringFormatProperty, value);
    }

    public int? Index
    {
        get => (int?)GetValue(IndexProperty);
        set => SetValue(IndexProperty, value);
    }

    public TileSize TileSize
    {
        get => (TileSize)GetValue(TileSizeProperty);
        set => SetValue(TileSizeProperty, value);
    }

    public bool IsInteractive
    {
        get => (bool)GetValue(IsInteractiveProperty);
        set => SetValue(IsInteractiveProperty, value);
    }

    public ICommand? OpenCommand
    {
        get => (ICommand?)GetValue(OpenCommandProperty);
        set => SetValue(OpenCommandProperty, value);
    }
}
