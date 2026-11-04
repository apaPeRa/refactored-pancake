using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace ApaTec.Hmi.Controls;

/// <summary>
/// Attached Behavior fuer die Tastenmodi von <see cref="HM07_ActionButton"/>, die ein Halten brauchen (HM-07, A-88). Gemeinsame Grundlage ist <see cref="ButtonBase.IsPressed"/>;
/// der Finger, der aus der Taste gleitet, die Deaktivierung, der Verlust der Berechtigung und das Entladen der Taste beenden das Druecken (Abbruch beim Verlassen).
/// <list type="bullet">
/// <item><description><b>WhilePressed</b> (Totmann, Jog): <see cref="PressCommandProperty"/> beim Druecken, <see cref="ReleaseCommandProperty"/> beim Ende des Drueckens.</description></item>
/// <item><description><b>Hold</b> (langes Druecken, Reset, Geber setzen): zusaetzlich laeuft ueber <see cref="HM07_ActionButton.HoldDuration"/> der Fortschritt
/// (<see cref="HM07_ActionButton.IsHolding"/>, <see cref="HM07_ActionButton.HoldProgress"/> von 0 bis 1); am Ende der Haltedauer wird <see cref="HoldCompletedCommandProperty"/> einmal ausgefuehrt.
/// Ohne Berechtigung (<see cref="HM07_ActionButton.RequiresPermission"/> und nicht <see cref="HM07_ActionButton.IsAuthorized"/>) laeuft kein Halten.</description></item>
/// </list>
/// Keine Fachlogik: das Verhalten meldet nur dem ViewModel; der Fortschritt laeuft ueber eine WPF-Animation.
/// </summary>
public static class HM07_PressBehavior
{
    public static readonly DependencyProperty PressCommandProperty =
        DependencyProperty.RegisterAttached("PressCommand", typeof(ICommand), typeof(HM07_PressBehavior), new PropertyMetadata(null, OnCommandChanged));

    public static readonly DependencyProperty ReleaseCommandProperty =
        DependencyProperty.RegisterAttached("ReleaseCommand", typeof(ICommand), typeof(HM07_PressBehavior), new PropertyMetadata(null, OnCommandChanged));

    public static readonly DependencyProperty HoldCompletedCommandProperty =
        DependencyProperty.RegisterAttached("HoldCompletedCommand", typeof(ICommand), typeof(HM07_PressBehavior), new PropertyMetadata(null, OnCommandChanged));

    private static readonly DependencyProperty IsHookedProperty =
        DependencyProperty.RegisterAttached("IsHooked", typeof(bool), typeof(HM07_PressBehavior), new PropertyMetadata(false));

    private static readonly DependencyProperty WasPressedProperty =
        DependencyProperty.RegisterAttached("WasPressed", typeof(bool), typeof(HM07_PressBehavior), new PropertyMetadata(false));

    private static readonly DependencyProperty ProgressProperty =
        DependencyProperty.RegisterAttached("Progress", typeof(double), typeof(HM07_PressBehavior), new PropertyMetadata(0.0, OnProgressChanged));

    private static readonly DependencyProperty CurrentHoldProperty =
        DependencyProperty.RegisterAttached("CurrentHold", typeof(Timeline), typeof(HM07_PressBehavior), new PropertyMetadata(null));

    public static ICommand? GetPressCommand(DependencyObject element) => (ICommand?)element.GetValue(PressCommandProperty);

    public static void SetPressCommand(DependencyObject element, ICommand? value) => element.SetValue(PressCommandProperty, value);

    public static ICommand? GetReleaseCommand(DependencyObject element) => (ICommand?)element.GetValue(ReleaseCommandProperty);

    public static void SetReleaseCommand(DependencyObject element, ICommand? value) => element.SetValue(ReleaseCommandProperty, value);

    public static ICommand? GetHoldCompletedCommand(DependencyObject element) => (ICommand?)element.GetValue(HoldCompletedCommandProperty);

    public static void SetHoldCompletedCommand(DependencyObject element, ICommand? value) => element.SetValue(HoldCompletedCommandProperty, value);

    private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not ButtonBase button || (bool)button.GetValue(IsHookedProperty))
        {
            return;
        }

        button.SetValue(IsHookedProperty, true);
        DependencyPropertyDescriptor.FromProperty(ButtonBase.IsPressedProperty, typeof(ButtonBase)).AddValueChanged(button, OnIsPressedChanged);
        if (button is HM07_ActionButton)
        {
            DependencyPropertyDescriptor.FromProperty(HM07_ActionButton.IsAuthorizedProperty, typeof(HM07_ActionButton)).AddValueChanged(button, OnAvailabilityChanged);
        }

        button.IsEnabledChanged += OnIsEnabledChanged;
        button.LostMouseCapture += OnLostMouseCapture;
        button.Unloaded += OnUnloaded;
    }

    private static void OnIsPressedChanged(object? sender, EventArgs e)
    {
        if (sender is not ButtonBase button)
        {
            return;
        }

        if (button.IsPressed)
        {
            if ((bool)button.GetValue(WasPressedProperty))
            {
                return; // Finger kehrt in die Taste zurueck (CancelOnLeave false): das Halten laeuft weiter
            }

            button.SetValue(WasPressedProperty, true);
            Run(GetPressCommand(button));
            if (button is HM07_ActionButton { TriggerMode: ActionTriggerMode.Hold } holdButton && CanHold(holdButton))
            {
                StartHold(holdButton);
            }
        }
        else if (!KeepsHoldingOutside(button))
        {
            EndPress(button);
        }
    }

    // CancelOnLeave false (nur Modus Hold): Haelt der Finger die Taste weiter gedrueckt (Maus bzw. Touch erfasst), bricht das Verlassen der Flaeche das Halten nicht ab;
    // das Ende kommt mit dem Loslassen (LostMouseCapture). Totmann (WhilePressed) bricht immer ab (A-90).
    private static bool KeepsHoldingOutside(ButtonBase button) =>
        button is HM07_ActionButton { TriggerMode: ActionTriggerMode.Hold, CancelOnLeave: false, IsHolding: true } && button.IsMouseCaptured;

    private static void OnLostMouseCapture(object sender, MouseEventArgs e)
    {
        if (sender is ButtonBase { IsPressed: false } button)
        {
            EndPress(button);
        }
    }

    private static void OnIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (sender is ButtonBase { IsEnabled: false } button)
        {
            EndPress(button);
        }
    }

    private static void OnAvailabilityChanged(object? sender, EventArgs e)
    {
        if (sender is HM07_ActionButton button && !CanHold(button))
        {
            CancelHold(button);
        }
    }

    private static void OnUnloaded(object sender, RoutedEventArgs e)
    {
        if (sender is ButtonBase button)
        {
            EndPress(button);
        }
    }

    private static bool CanHold(HM07_ActionButton button) => button.IsEnabled && (!button.RequiresPermission || button.IsAuthorized);

    private static void EndPress(ButtonBase button)
    {
        if (!(bool)button.GetValue(WasPressedProperty))
        {
            return;
        }

        button.SetValue(WasPressedProperty, false);
        if (button is HM07_ActionButton actionButton)
        {
            CancelHold(actionButton);
        }

        Run(GetReleaseCommand(button));
    }

    private static void StartHold(HM07_ActionButton button)
    {
        var duration = button.HoldDuration;
        if (duration <= TimeSpan.Zero)
        {
            Run(GetHoldCompletedCommand(button));
            return;
        }

        var animation = new DoubleAnimation(0.0, 1.0, new Duration(duration)) { FillBehavior = FillBehavior.HoldEnd };
        animation.Completed += (_, _) => OnHoldElapsed(button, animation);
        button.SetValue(CurrentHoldProperty, animation);
        button.SetCurrentValue(HM07_ActionButton.IsHoldingProperty, true);
        button.BeginAnimation(ProgressProperty, animation);
    }

    private static void OnHoldElapsed(HM07_ActionButton button, Timeline animation)
    {
        if (!ReferenceEquals(button.GetValue(CurrentHoldProperty), animation))
        {
            return;
        }

        CancelHold(button);
        Run(GetHoldCompletedCommand(button));
    }

    private static void CancelHold(HM07_ActionButton button)
    {
        if (button.GetValue(CurrentHoldProperty) is null && !button.IsHolding)
        {
            return;
        }

        button.SetValue(CurrentHoldProperty, null);
        button.BeginAnimation(ProgressProperty, null);
        button.SetCurrentValue(HM07_ActionButton.HoldProgressProperty, 0.0);
        button.SetCurrentValue(HM07_ActionButton.IsHoldingProperty, false);
    }

    private static void OnProgressChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is HM07_ActionButton button && button.GetValue(CurrentHoldProperty) is not null)
        {
            button.SetCurrentValue(HM07_ActionButton.HoldProgressProperty, (double)e.NewValue);
        }
    }

    private static void Run(ICommand? command)
    {
        if (command is not null && command.CanExecute(null))
        {
            command.Execute(null);
        }
    }
}
