using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ApaTec.Hmi.Controls;

/// <summary>Auslösung der Aktionstaste (HM-07): Antippen, Halten, Dauerfunktion bis Abbruch, Gedrückt-Halten (Totmann).</summary>
public enum ActionTriggerMode
{
    Tap,
    Hold,
    Continuous,
    WhilePressed,
}

/// <summary>
/// HM-07 Aktionstaste: genau eine Aktion, kein Ein/Aus-Zustand. Nur Dependency Properties (A-73); Befehl über <see cref="ButtonBase.Command"/>.
/// Die Darstellung steht in <c>HM07_ActionButton.Styles.xaml</c>.
/// </summary>
public class HM07_ActionButton : Button
{
    public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
        nameof(Label), typeof(string), typeof(HM07_ActionButton), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
        nameof(Icon), typeof(Geometry), typeof(HM07_ActionButton), new PropertyMetadata(null));

    public static readonly DependencyProperty TriggerModeProperty = DependencyProperty.Register(
        nameof(TriggerMode), typeof(ActionTriggerMode), typeof(HM07_ActionButton), new PropertyMetadata(ActionTriggerMode.Tap));

    public static readonly DependencyProperty HoldDurationProperty = DependencyProperty.Register(
        nameof(HoldDuration), typeof(TimeSpan), typeof(HM07_ActionButton), new PropertyMetadata(TimeSpan.FromMilliseconds(1000)));

    public static readonly DependencyProperty IsRunningProperty = DependencyProperty.Register(
        nameof(IsRunning), typeof(bool), typeof(HM07_ActionButton), new PropertyMetadata(false));

    public static readonly DependencyProperty CancelOnLeaveProperty = DependencyProperty.Register(
        nameof(CancelOnLeave), typeof(bool), typeof(HM07_ActionButton), new PropertyMetadata(true));

    public static readonly DependencyProperty RequiresPermissionProperty = DependencyProperty.Register(
        nameof(RequiresPermission), typeof(bool), typeof(HM07_ActionButton), new PropertyMetadata(false));

    public static readonly DependencyProperty IsAuthorizedProperty = DependencyProperty.Register(
        nameof(IsAuthorized), typeof(bool), typeof(HM07_ActionButton), new PropertyMetadata(true));

    // Ergaenzung zur Moduldefinition: Haltezustand und Fortschritt (0 bis 1) fuer den Fortschrittsstreifen im Modus Hold; Wert liefert das ViewModel bzw. ein Verhalten.
    public static readonly DependencyProperty IsHoldingProperty = DependencyProperty.Register(
        nameof(IsHolding), typeof(bool), typeof(HM07_ActionButton), new PropertyMetadata(false));

    public static readonly DependencyProperty HoldProgressProperty = DependencyProperty.Register(
        nameof(HoldProgress), typeof(double), typeof(HM07_ActionButton), new PropertyMetadata(0.0));

    static HM07_ActionButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM07_ActionButton), new FrameworkPropertyMetadata(typeof(HM07_ActionButton)));
    }

    /// <summary>Im Modus Hold loest das Antippen keinen <see cref="ButtonBase.Command"/> aus; die Aktion laeuft erst nach der Haltedauer (<c>HM07_PressBehavior.HoldCompletedCommand</c>).</summary>
    protected override void OnClick()
    {
        if (TriggerMode == ActionTriggerMode.Hold)
        {
            return;
        }

        base.OnClick();
    }

    public string Label
    {
        get => (string)GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    public Geometry? Icon
    {
        get => (Geometry?)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public ActionTriggerMode TriggerMode
    {
        get => (ActionTriggerMode)GetValue(TriggerModeProperty);
        set => SetValue(TriggerModeProperty, value);
    }

    public TimeSpan HoldDuration
    {
        get => (TimeSpan)GetValue(HoldDurationProperty);
        set => SetValue(HoldDurationProperty, value);
    }

    public bool IsRunning
    {
        get => (bool)GetValue(IsRunningProperty);
        set => SetValue(IsRunningProperty, value);
    }

    public bool CancelOnLeave
    {
        get => (bool)GetValue(CancelOnLeaveProperty);
        set => SetValue(CancelOnLeaveProperty, value);
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

    public bool IsHolding
    {
        get => (bool)GetValue(IsHoldingProperty);
        set => SetValue(IsHoldingProperty, value);
    }

    public double HoldProgress
    {
        get => (double)GetValue(HoldProgressProperty);
        set => SetValue(HoldProgressProperty, value);
    }
}
