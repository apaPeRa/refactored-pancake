using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ApaTec.Hmi.Controls;

/// <summary>Kartenart der Motorparameter-Karte.</summary>
public enum MotorCardKind
{
    ClosureClosed,
    ClosureOpen,
    Screw,
}

/// <summary>HM-21 Motorparameter-Karte: Verschluss Zu/Auf (5 Zeilen) oder Schnecke (3 Zeilen).</summary>
public sealed class HM21_MotorParameterCard : Control
{
    static HM21_MotorParameterCard()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM21_MotorParameterCard), new FrameworkPropertyMetadata(typeof(HM21_MotorParameterCard)));
    }

    /// <summary>Kartenueberschrift.</summary>
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(nameof(Title), typeof(string), typeof(HM21_MotorParameterCard), new PropertyMetadata(""));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    /// <summary>Kartenart.</summary>
    public static readonly DependencyProperty CardKindProperty =
        DependencyProperty.Register(nameof(CardKind), typeof(MotorCardKind), typeof(HM21_MotorParameterCard), new PropertyMetadata(MotorCardKind.ClosureClosed));

    public MotorCardKind CardKind
    {
        get => (MotorCardKind)GetValue(CardKindProperty);
        set => SetValue(CardKindProperty, value);
    }

    /// <summary>Position in Grad (nur Verschluss).</summary>
    public static readonly DependencyProperty PositionProperty =
        DependencyProperty.Register(nameof(Position), typeof(double), typeof(HM21_MotorParameterCard), new PropertyMetadata(0d));

    public double Position
    {
        get => (double)GetValue(PositionProperty);
        set => SetValue(PositionProperty, value);
    }

    /// <summary>Geschwindigkeit in % (nur Verschluss).</summary>
    public static readonly DependencyProperty SpeedProperty =
        DependencyProperty.Register(nameof(Speed), typeof(double), typeof(HM21_MotorParameterCard), new PropertyMetadata(0d));

    public double Speed
    {
        get => (double)GetValue(SpeedProperty);
        set => SetValue(SpeedProperty, value);
    }

    /// <summary>Beschleunigung in %.</summary>
    public static readonly DependencyProperty AccelerationProperty =
        DependencyProperty.Register(nameof(Acceleration), typeof(double), typeof(HM21_MotorParameterCard), new PropertyMetadata(0d));

    public double Acceleration
    {
        get => (double)GetValue(AccelerationProperty);
        set => SetValue(AccelerationProperty, value);
    }

    /// <summary>Verzoegerung in %.</summary>
    public static readonly DependencyProperty DecelerationProperty =
        DependencyProperty.Register(nameof(Deceleration), typeof(double), typeof(HM21_MotorParameterCard), new PropertyMetadata(0d));

    public double Deceleration
    {
        get => (double)GetValue(DecelerationProperty);
        set => SetValue(DecelerationProperty, value);
    }

    /// <summary>Ruck in %.</summary>
    public static readonly DependencyProperty JerkProperty =
        DependencyProperty.Register(nameof(Jerk), typeof(double), typeof(HM21_MotorParameterCard), new PropertyMetadata(0d));

    public double Jerk
    {
        get => (double)GetValue(JerkProperty);
        set => SetValue(JerkProperty, value);
    }

    /// <summary>Dosierer, fuer den die Seite geoeffnet wurde (z. B. HD1).</summary>
    public static readonly DependencyProperty DoserNameProperty =
        DependencyProperty.Register(nameof(DoserName), typeof(string), typeof(HM21_MotorParameterCard), new PropertyMetadata(null));

    public string? DoserName
    {
        get => (string?)GetValue(DoserNameProperty);
        set => SetValue(DoserNameProperty, value);
    }

    /// <summary>Uebernahme eines geaenderten Werts.</summary>
    public static readonly DependencyProperty CommitCommandProperty =
        DependencyProperty.Register(nameof(CommitCommand), typeof(ICommand), typeof(HM21_MotorParameterCard), new PropertyMetadata(null));

    public ICommand? CommitCommand
    {
        get => (ICommand?)GetValue(CommitCommandProperty);
        set => SetValue(CommitCommandProperty, value);
    }
}
