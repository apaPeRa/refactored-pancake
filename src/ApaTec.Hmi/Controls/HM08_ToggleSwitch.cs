using System.Globalization;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace ApaTec.Hmi.Controls;

/// <summary>Darstellung der Zustandstaste (HM-08): Schalter mit Bahn und Knopf oder Taste.</summary>
public enum ToggleStyle
{
    Switch,
    Button,
}

/// <summary>Tastenhoehe (HM-08): Default = <c>Size.Touch.Default</c>, Tile = <c>Size.Touch.Large</c> (Kachelhoehe, HS-01).</summary>
public enum ToggleButtonSize
{
    Default,
    Tile,
}

/// <summary>
/// HM-08 Zustandstaste / Umschalter: Ein/Aus (<see cref="ToggleButton.IsChecked"/>, null = teilweise im Sammelzustand). Nur Dependency Properties (A-73);
/// Darstellung in <c>HM08_ToggleSwitch.Styles.xaml</c>. Leere Texte (<see cref="OnText"/>, <see cref="OffText"/>, <see cref="PartialText"/>) zeigen die Standardwoerter aus den Ressourcen.
/// </summary>
public class HM08_ToggleSwitch : ToggleButton
{
    public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
        nameof(Label), typeof(string), typeof(HM08_ToggleSwitch), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty IsAggregateProperty = DependencyProperty.Register(
        nameof(IsAggregate), typeof(bool), typeof(HM08_ToggleSwitch), new PropertyMetadata(false));

    public static readonly DependencyProperty PartialTextProperty = DependencyProperty.Register(
        nameof(PartialText), typeof(string), typeof(HM08_ToggleSwitch), new PropertyMetadata(string.Empty));

    /// <summary>Hinweistext im Sammelzustand "Teilweise" (Tooltip und Automation); nennt z. B. die abgewaehlten Funktionen. Leer = Standardtext.</summary>
    public static readonly DependencyProperty PartialTooltipProperty = DependencyProperty.Register(
        nameof(PartialTooltip), typeof(string), typeof(HM08_ToggleSwitch), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty OnTextProperty = DependencyProperty.Register(
        nameof(OnText), typeof(string), typeof(HM08_ToggleSwitch), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty OffTextProperty = DependencyProperty.Register(
        nameof(OffText), typeof(string), typeof(HM08_ToggleSwitch), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty ToggleStyleProperty = DependencyProperty.Register(
        nameof(ToggleStyle), typeof(ToggleStyle), typeof(HM08_ToggleSwitch), new PropertyMetadata(ToggleStyle.Switch));

    public static readonly DependencyProperty ButtonSizeProperty = DependencyProperty.Register(
        nameof(ButtonSize), typeof(ToggleButtonSize), typeof(HM08_ToggleSwitch), new PropertyMetadata(ToggleButtonSize.Default));

    public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
        nameof(Icon), typeof(Geometry), typeof(HM08_ToggleSwitch), new PropertyMetadata(null));

    public static readonly DependencyProperty ToggleCommandProperty = DependencyProperty.Register(
        nameof(ToggleCommand), typeof(ICommand), typeof(HM08_ToggleSwitch), new PropertyMetadata(null));

    public static readonly DependencyProperty IsPendingProperty = DependencyProperty.Register(
        nameof(IsPending), typeof(bool), typeof(HM08_ToggleSwitch), new PropertyMetadata(false));

    public static readonly DependencyProperty ErrorTextProperty = DependencyProperty.Register(
        nameof(ErrorText), typeof(string), typeof(HM08_ToggleSwitch), new PropertyMetadata(null));

    public static readonly DependencyProperty RequiresPermissionProperty = DependencyProperty.Register(
        nameof(RequiresPermission), typeof(bool), typeof(HM08_ToggleSwitch), new PropertyMetadata(false));

    public static readonly DependencyProperty IsAuthorizedProperty = DependencyProperty.Register(
        nameof(IsAuthorized), typeof(bool), typeof(HM08_ToggleSwitch), new PropertyMetadata(true));

    static HM08_ToggleSwitch()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM08_ToggleSwitch), new FrameworkPropertyMetadata(typeof(HM08_ToggleSwitch)));
    }

    public string Label
    {
        get => (string)GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    public bool IsAggregate
    {
        get => (bool)GetValue(IsAggregateProperty);
        set => SetValue(IsAggregateProperty, value);
    }

    public string PartialText
    {
        get => (string)GetValue(PartialTextProperty);
        set => SetValue(PartialTextProperty, value);
    }

    public string PartialTooltip
    {
        get => (string)GetValue(PartialTooltipProperty);
        set => SetValue(PartialTooltipProperty, value);
    }

    public string OnText
    {
        get => (string)GetValue(OnTextProperty);
        set => SetValue(OnTextProperty, value);
    }

    public string OffText
    {
        get => (string)GetValue(OffTextProperty);
        set => SetValue(OffTextProperty, value);
    }

    public ToggleStyle ToggleStyle
    {
        get => (ToggleStyle)GetValue(ToggleStyleProperty);
        set => SetValue(ToggleStyleProperty, value);
    }

    public ToggleButtonSize ButtonSize
    {
        get => (ToggleButtonSize)GetValue(ButtonSizeProperty);
        set => SetValue(ButtonSizeProperty, value);
    }

    public Geometry? Icon
    {
        get => (Geometry?)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public ICommand? ToggleCommand
    {
        get => (ICommand?)GetValue(ToggleCommandProperty);
        set => SetValue(ToggleCommandProperty, value);
    }

    public bool IsPending
    {
        get => (bool)GetValue(IsPendingProperty);
        set => SetValue(IsPendingProperty, value);
    }

    public string? ErrorText
    {
        get => (string?)GetValue(ErrorTextProperty);
        set => SetValue(ErrorTextProperty, value);
    }

    public bool RequiresPermission
    {
        get => (bool)GetValue(RequiresPermissionProperty);
        set => SetValue(RequiresPermissionProperty, value);
    }

    public bool IsAuthorized
    {
        get => (bool)GetValue(IsAuthorizedProperty);
        set => SetValue(IsAuthorizedProperty, value);
    }
}

/// <summary>Hilfswandler fuer die Vorlage von HM-08: true, wenn der Text nicht leer ist (Fehlerzustand).</summary>
[ValueConversion(typeof(string), typeof(bool))]
public sealed class HM08_HasTextConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is string text && text.Length > 0;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotSupportedException();
}
