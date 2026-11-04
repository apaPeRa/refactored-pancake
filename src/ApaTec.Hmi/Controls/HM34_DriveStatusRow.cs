using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ApaTec.Hmi.Controls;

/// <summary>HM-34 Motor-Statuszeile: Antriebsname, Diag Code, Strom aktuell/max/Limit und Meldung (HS-39).</summary>
public sealed class HM34_DriveStatusRow : Control
{
    static HM34_DriveStatusRow()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM34_DriveStatusRow), new FrameworkPropertyMetadata(typeof(HM34_DriveStatusRow)));
    }

    /// <summary>Antriebsname.</summary>
    public static readonly DependencyProperty DriveNameProperty =
        DependencyProperty.Register(nameof(DriveName), typeof(string), typeof(HM34_DriveStatusRow), new PropertyMetadata(string.Empty));

    public string DriveName
    {
        get => (string)GetValue(DriveNameProperty);
        set => SetValue(DriveNameProperty, value);
    }

    /// <summary>Diag Code.</summary>
    public static readonly DependencyProperty DiagCodeProperty =
        DependencyProperty.Register(nameof(DiagCode), typeof(int), typeof(HM34_DriveStatusRow), new PropertyMetadata(0));

    public int DiagCode
    {
        get => (int)GetValue(DiagCodeProperty);
        set => SetValue(DiagCodeProperty, value);
    }

    /// <summary>Strom aktuell in Prozent.</summary>
    public static readonly DependencyProperty CurrentActualProperty =
        DependencyProperty.Register(nameof(CurrentActual), typeof(double), typeof(HM34_DriveStatusRow), new PropertyMetadata(0d));

    public double CurrentActual
    {
        get => (double)GetValue(CurrentActualProperty);
        set => SetValue(CurrentActualProperty, value);
    }

    /// <summary>Strom max in Prozent (Antippen setzt zurück).</summary>
    public static readonly DependencyProperty CurrentMaxProperty =
        DependencyProperty.Register(nameof(CurrentMax), typeof(double), typeof(HM34_DriveStatusRow), new PropertyMetadata(0d));

    public double CurrentMax
    {
        get => (double)GetValue(CurrentMaxProperty);
        set => SetValue(CurrentMaxProperty, value);
    }

    /// <summary>Strom Limit in Prozent (Eingabe mit Schlüssel).</summary>
    public static readonly DependencyProperty CurrentLimitProperty =
        DependencyProperty.Register(nameof(CurrentLimit), typeof(double), typeof(HM34_DriveStatusRow), new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public double CurrentLimit
    {
        get => (double)GetValue(CurrentLimitProperty);
        set => SetValue(CurrentLimitProperty, value);
    }

    /// <summary>Meldung; null = keine Meldung (Normalzustand).</summary>
    public static readonly DependencyProperty MessageProperty =
        DependencyProperty.Register(nameof(Message), typeof(string?), typeof(HM34_DriveStatusRow), new PropertyMetadata(null));

    public string? Message
    {
        get => (string?)GetValue(MessageProperty);
        set => SetValue(MessageProperty, value);
    }

    /// <summary>Berechtigung für die Limit-Eingabe; false zeigt das Schloss (Ergänzung zur Moduldefinition).</summary>
    public static readonly DependencyProperty IsLimitAuthorizedProperty =
        DependencyProperty.Register(nameof(IsLimitAuthorized), typeof(bool), typeof(HM34_DriveStatusRow), new PropertyMetadata(true));

    public bool IsLimitAuthorized
    {
        get => (bool)GetValue(IsLimitAuthorizedProperty);
        set => SetValue(IsLimitAuthorizedProperty, value);
    }

    /// <summary>Setzt Strom max zurück.</summary>
    public static readonly DependencyProperty ResetMaxCommandProperty =
        DependencyProperty.Register(nameof(ResetMaxCommand), typeof(ICommand?), typeof(HM34_DriveStatusRow), new PropertyMetadata(null));

    public ICommand? ResetMaxCommand
    {
        get => (ICommand?)GetValue(ResetMaxCommandProperty);
        set => SetValue(ResetMaxCommandProperty, value);
    }
}
