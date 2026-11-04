using System.Windows;
using System.Windows.Controls;

namespace ApaTec.Hmi.Controls;

/// <summary>Platz der Beschriftung am Fortschrittsbalken (HM-10).</summary>
public enum LabelPlacement
{
    Above,
    Left,
}

/// <summary>
/// HM-10 Fortschrittsbalken: horizontaler Balken mit Prozentzahl im Balken, nur Anzeige. Nur Dependency Properties (A-73); der Wert kommt vom ViewModel
/// (<see cref="System.Windows.Controls.Primitives.RangeBase.Value"/>, Minimum 0, Maximum 100). Darstellung in <c>HM10_ProgressBar.Styles.xaml</c>.
/// </summary>
public class HM10_ProgressBar : ProgressBar
{
    public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
        nameof(Label), typeof(string), typeof(HM10_ProgressBar), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty WarningThresholdProperty = DependencyProperty.Register(
        nameof(WarningThreshold), typeof(double?), typeof(HM10_ProgressBar), new PropertyMetadata(null));

    public static readonly DependencyProperty ErrorThresholdProperty = DependencyProperty.Register(
        nameof(ErrorThreshold), typeof(double?), typeof(HM10_ProgressBar), new PropertyMetadata(null));

    public static readonly DependencyProperty StringFormatProperty = DependencyProperty.Register(
        nameof(StringFormat), typeof(string), typeof(HM10_ProgressBar), new PropertyMetadata("N0"));

    public static readonly DependencyProperty LabelPlacementProperty = DependencyProperty.Register(
        nameof(LabelPlacement), typeof(LabelPlacement), typeof(HM10_ProgressBar), new PropertyMetadata(LabelPlacement.Above));

    // Ergaenzung zur Moduldefinition: RangeBase.Value ist nicht nullbar; false = Wert ungueltig (leere Bahn, Text "---").
    public static readonly DependencyProperty IsValueValidProperty = DependencyProperty.Register(
        nameof(IsValueValid), typeof(bool), typeof(HM10_ProgressBar), new PropertyMetadata(true));

    static HM10_ProgressBar()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM10_ProgressBar), new FrameworkPropertyMetadata(typeof(HM10_ProgressBar)));
    }

    public string Label
    {
        get => (string)GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    public double? WarningThreshold
    {
        get => (double?)GetValue(WarningThresholdProperty);
        set => SetValue(WarningThresholdProperty, value);
    }

    public double? ErrorThreshold
    {
        get => (double?)GetValue(ErrorThresholdProperty);
        set => SetValue(ErrorThresholdProperty, value);
    }

    public string StringFormat
    {
        get => (string)GetValue(StringFormatProperty);
        set => SetValue(StringFormatProperty, value);
    }

    public LabelPlacement LabelPlacement
    {
        get => (LabelPlacement)GetValue(LabelPlacementProperty);
        set => SetValue(LabelPlacementProperty, value);
    }

    public bool IsValueValid
    {
        get => (bool)GetValue(IsValueValidProperty);
        set => SetValue(IsValueValidProperty, value);
    }
}
