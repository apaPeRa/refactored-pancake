using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ApaTec.Hmi.Controls;

/// <summary>Zustand der Status-LED (HM-09): Off = inaktiv, On = ok.</summary>
public enum LedState
{
    Off,
    On,
    Warning,
    Error,
    Unknown,
}

/// <summary>
/// HM-09 Status-LED: runde Zustandsanzeige mit Beschriftung, nur Anzeige (nicht bedienbar, nicht fokussierbar). Nur Dependency Properties (A-73);
/// Darstellung in <c>HM09_StatusLed.Styles.xaml</c>. Ein leerer <see cref="StateText"/> zeigt das Standardwort des Zustands aus den Ressourcen.
/// </summary>
public class HM09_StatusLed : Control
{
    public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
        nameof(Label), typeof(string), typeof(HM09_StatusLed), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty StateProperty = DependencyProperty.Register(
        nameof(State), typeof(LedState), typeof(HM09_StatusLed), new PropertyMetadata(LedState.Off));

    public static readonly DependencyProperty StateTextProperty = DependencyProperty.Register(
        nameof(StateText), typeof(string), typeof(HM09_StatusLed), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty ShowStateWordProperty = DependencyProperty.Register(
        nameof(ShowStateWord), typeof(bool), typeof(HM09_StatusLed), new PropertyMetadata(true));

    public static readonly DependencyProperty IsCompactProperty = DependencyProperty.Register(
        nameof(IsCompact), typeof(bool), typeof(HM09_StatusLed), new PropertyMetadata(false));

    public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
        nameof(Icon), typeof(Geometry), typeof(HM09_StatusLed), new PropertyMetadata(null));

    public static readonly DependencyProperty IdentifierProperty = DependencyProperty.Register(
        nameof(Identifier), typeof(string), typeof(HM09_StatusLed), new PropertyMetadata(string.Empty));

    static HM09_StatusLed()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM09_StatusLed), new FrameworkPropertyMetadata(typeof(HM09_StatusLed)));
    }

    public string Label
    {
        get => (string)GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    public LedState State
    {
        get => (LedState)GetValue(StateProperty);
        set => SetValue(StateProperty, value);
    }

    public string StateText
    {
        get => (string)GetValue(StateTextProperty);
        set => SetValue(StateTextProperty, value);
    }

    public bool ShowStateWord
    {
        get => (bool)GetValue(ShowStateWordProperty);
        set => SetValue(ShowStateWordProperty, value);
    }

    public bool IsCompact
    {
        get => (bool)GetValue(IsCompactProperty);
        set => SetValue(IsCompactProperty, value);
    }

    public Geometry? Icon
    {
        get => (Geometry?)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public string Identifier
    {
        get => (string)GetValue(IdentifierProperty);
        set => SetValue(IdentifierProperty, value);
    }
}
