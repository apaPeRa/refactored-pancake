using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace ApaTec.Hmi.Views;

/// <summary>
/// Attached Behavior fuer Totmann- und Haltetasten (HM-07 <c>WhilePressed</c>/<c>Hold</c>, Jog in HS-31, Geber setzen in HS-32): meldet dem ViewModel das Druecken
/// (<see cref="PressCommandProperty"/>) und das Ende des Drueckens (<see cref="ReleaseCommandProperty"/>: Loslassen, Finger gleitet aus der Taste, Taste wird deaktiviert oder entladen).
/// Keine Fachlogik; Grundlage ist <see cref="ButtonBase.IsPressed"/>. HM-07 liefert diese Meldung selbst nicht (Luecke, im Bericht benannt).
/// </summary>
public static class ManualOperationPressBehavior
{
    public static readonly DependencyProperty PressCommandProperty =
        DependencyProperty.RegisterAttached("PressCommand", typeof(ICommand), typeof(ManualOperationPressBehavior), new PropertyMetadata(null, OnCommandChanged));

    public static readonly DependencyProperty ReleaseCommandProperty =
        DependencyProperty.RegisterAttached("ReleaseCommand", typeof(ICommand), typeof(ManualOperationPressBehavior), new PropertyMetadata(null, OnCommandChanged));

    private static readonly DependencyProperty IsHookedProperty =
        DependencyProperty.RegisterAttached("IsHooked", typeof(bool), typeof(ManualOperationPressBehavior), new PropertyMetadata(false));

    private static readonly DependencyProperty WasPressedProperty =
        DependencyProperty.RegisterAttached("WasPressed", typeof(bool), typeof(ManualOperationPressBehavior), new PropertyMetadata(false));

    public static ICommand? GetPressCommand(DependencyObject element) => (ICommand?)element.GetValue(PressCommandProperty);

    public static void SetPressCommand(DependencyObject element, ICommand? value) => element.SetValue(PressCommandProperty, value);

    public static ICommand? GetReleaseCommand(DependencyObject element) => (ICommand?)element.GetValue(ReleaseCommandProperty);

    public static void SetReleaseCommand(DependencyObject element, ICommand? value) => element.SetValue(ReleaseCommandProperty, value);

    private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not ButtonBase button || (bool)button.GetValue(IsHookedProperty))
        {
            return;
        }

        button.SetValue(IsHookedProperty, true);
        DependencyPropertyDescriptor.FromProperty(ButtonBase.IsPressedProperty, typeof(ButtonBase)).AddValueChanged(button, OnIsPressedChanged);
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
            button.SetValue(WasPressedProperty, true);
            Run(GetPressCommand(button));
        }
        else if ((bool)button.GetValue(WasPressedProperty))
        {
            button.SetValue(WasPressedProperty, false);
            Run(GetReleaseCommand(button));
        }
    }

    private static void OnUnloaded(object sender, RoutedEventArgs e)
    {
        if (sender is ButtonBase button && (bool)button.GetValue(WasPressedProperty))
        {
            button.SetValue(WasPressedProperty, false);
            Run(GetReleaseCommand(button));
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
