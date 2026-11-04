using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ApaTec.Hmi.Controls;

/// <summary>Ergebnis der Gewichtsanpassung.</summary>
public enum CalculationState
{
    None,
    TooFewPoints,
    Invalid,
    Calculated,
}

/// <summary>Stuetzstelle der Dosierkorrektur: SOLL und IST in g (0 = leer); Block 1 oder 2 der Tabelle.</summary>
public sealed partial class CorrectionPoint : ObservableObject
{
    [ObservableProperty]
    private double nominal;

    [ObservableProperty]
    private double actual;

    [ObservableProperty]
    private int block = 1;
}

/// <summary>HM-22 Gewichtskorrektur-Tabelle: 2 Bloecke mit je 10 Stuetzstellen SOLL/IST, Sollgewicht und Tasten.</summary>
public sealed class HM22_WeightCorrectionTable : Control
{
    static HM22_WeightCorrectionTable()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM22_WeightCorrectionTable), new FrameworkPropertyMetadata(typeof(HM22_WeightCorrectionTable)));
    }

    /// <summary>Stuetzstellen (20 Paare, Block 1 und 2).</summary>
    public static readonly DependencyProperty PointsProperty =
        DependencyProperty.Register(nameof(Points), typeof(IList<CorrectionPoint>), typeof(HM22_WeightCorrectionTable), new PropertyMetadata(null));

    public IList<CorrectionPoint>? Points
    {
        get => (IList<CorrectionPoint>?)GetValue(PointsProperty);
        set => SetValue(PointsProperty, value);
    }

    /// <summary>Sollgewicht in g.</summary>
    public static readonly DependencyProperty TargetWeightProperty =
        DependencyProperty.Register(nameof(TargetWeight), typeof(double), typeof(HM22_WeightCorrectionTable), new PropertyMetadata(0d));

    public double TargetWeight
    {
        get => (double)GetValue(TargetWeightProperty);
        set => SetValue(TargetWeightProperty, value);
    }

    /// <summary>Gueltige Stuetzstellen (vom ViewModel berechnet).</summary>
    public static readonly DependencyProperty ValidPointCountProperty =
        DependencyProperty.Register(nameof(ValidPointCount), typeof(int), typeof(HM22_WeightCorrectionTable), new PropertyMetadata(0));

    public int ValidPointCount
    {
        get => (int)GetValue(ValidPointCountProperty);
        set => SetValue(ValidPointCountProperty, value);
    }

    /// <summary>Ergebnis der Berechnung.</summary>
    public static readonly DependencyProperty CalculationStateProperty =
        DependencyProperty.Register(nameof(CalculationState), typeof(CalculationState), typeof(HM22_WeightCorrectionTable), new PropertyMetadata(CalculationState.None));

    public CalculationState CalculationState
    {
        get => (CalculationState)GetValue(CalculationStateProperty);
        set => SetValue(CalculationStateProperty, value);
    }

    /// <summary>Gewichtsanpassung berechnen.</summary>
    public static readonly DependencyProperty AdjustCommandProperty =
        DependencyProperty.Register(nameof(AdjustCommand), typeof(ICommand), typeof(HM22_WeightCorrectionTable), new PropertyMetadata(null));

    public ICommand? AdjustCommand
    {
        get => (ICommand?)GetValue(AdjustCommandProperty);
        set => SetValue(AdjustCommandProperty, value);
    }

    /// <summary>Dosierer manuell ausloesen.</summary>
    public static readonly DependencyProperty TriggerCommandProperty =
        DependencyProperty.Register(nameof(TriggerCommand), typeof(ICommand), typeof(HM22_WeightCorrectionTable), new PropertyMetadata(null));

    public ICommand? TriggerCommand
    {
        get => (ICommand?)GetValue(TriggerCommandProperty);
        set => SetValue(TriggerCommandProperty, value);
    }
    /// <summary>Antippen des Felds Sollgewicht (oeffnet das Eingabe-Pop-up im ViewModel).</summary>
    public static readonly DependencyProperty EditTargetWeightCommandProperty =
        DependencyProperty.Register(nameof(EditTargetWeightCommand), typeof(ICommand), typeof(HM22_WeightCorrectionTable), new PropertyMetadata(null));

    public ICommand? EditTargetWeightCommand
    {
        get => (ICommand?)GetValue(EditTargetWeightCommandProperty);
        set => SetValue(EditTargetWeightCommandProperty, value);
    }

    /// <summary>Antippen eines SOLL-Felds; <c>CommandParameter</c> = <see cref="CorrectionPoint"/> der Zeile.</summary>
    public static readonly DependencyProperty EditNominalCommandProperty =
        DependencyProperty.Register(nameof(EditNominalCommand), typeof(ICommand), typeof(HM22_WeightCorrectionTable), new PropertyMetadata(null));

    public ICommand? EditNominalCommand
    {
        get => (ICommand?)GetValue(EditNominalCommandProperty);
        set => SetValue(EditNominalCommandProperty, value);
    }

    /// <summary>Antippen eines IST-Felds; <c>CommandParameter</c> = <see cref="CorrectionPoint"/> der Zeile.</summary>
    public static readonly DependencyProperty EditActualCommandProperty =
        DependencyProperty.Register(nameof(EditActualCommand), typeof(ICommand), typeof(HM22_WeightCorrectionTable), new PropertyMetadata(null));

    public ICommand? EditActualCommand
    {
        get => (ICommand?)GetValue(EditActualCommandProperty);
        set => SetValue(EditActualCommandProperty, value);
    }
}
