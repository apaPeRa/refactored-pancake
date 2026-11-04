using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ApaTec.Hmi.Controls;

/// <summary>HM-35 Regulierungs-Parameterblock: Parametersatz der automatischen Gewichtsregulierung je Dosierer (HS-23).</summary>
public sealed class HM35_RegulationBlock : Control
{
    static HM35_RegulationBlock()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM35_RegulationBlock), new FrameworkPropertyMetadata(typeof(HM35_RegulationBlock)));
    }

    /// <summary>Titel (Hauptdosierer, Nachdosierer).</summary>
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(nameof(Title), typeof(string), typeof(HM35_RegulationBlock), new PropertyMetadata(string.Empty));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    /// <summary>Anzahl Gewichte in Stück.</summary>
    public static readonly DependencyProperty SampleCountProperty =
        DependencyProperty.Register(nameof(SampleCount), typeof(int), typeof(HM35_RegulationBlock), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public int SampleCount
    {
        get => (int)GetValue(SampleCountProperty);
        set => SetValue(SampleCountProperty, value);
    }

    /// <summary>Regulierschritt in Prozent.</summary>
    public static readonly DependencyProperty StepProperty =
        DependencyProperty.Register(nameof(Step), typeof(double), typeof(HM35_RegulationBlock), new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public double Step
    {
        get => (double)GetValue(StepProperty);
        set => SetValue(StepProperty, value);
    }

    /// <summary>Toleranz in g.</summary>
    public static readonly DependencyProperty ToleranceProperty =
        DependencyProperty.Register(nameof(Tolerance), typeof(double), typeof(HM35_RegulationBlock), new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public double Tolerance
    {
        get => (double)GetValue(ToleranceProperty);
        set => SetValue(ToleranceProperty, value);
    }

    /// <summary>Regulierung max in g.</summary>
    public static readonly DependencyProperty MaxCorrectionProperty =
        DependencyProperty.Register(nameof(MaxCorrection), typeof(double), typeof(HM35_RegulationBlock), new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public double MaxCorrection
    {
        get => (double)GetValue(MaxCorrectionProperty);
        set => SetValue(MaxCorrectionProperty, value);
    }

    /// <summary>Regulierung ist in g.</summary>
    public static readonly DependencyProperty CurrentCorrectionProperty =
        DependencyProperty.Register(nameof(CurrentCorrection), typeof(double), typeof(HM35_RegulationBlock), new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public double CurrentCorrection
    {
        get => (double)GetValue(CurrentCorrectionProperty);
        set => SetValue(CurrentCorrectionProperty, value);
    }

    /// <summary>Mittelwert in g.</summary>
    public static readonly DependencyProperty MeanProperty =
        DependencyProperty.Register(nameof(Mean), typeof(double), typeof(HM35_RegulationBlock), new PropertyMetadata(0d));

    public double Mean
    {
        get => (double)GetValue(MeanProperty);
        set => SetValue(MeanProperty, value);
    }

    /// <summary>Zähler der gewogenen Packungen im Mittelwert.</summary>
    public static readonly DependencyProperty MeanCountProperty =
        DependencyProperty.Register(nameof(MeanCount), typeof(int), typeof(HM35_RegulationBlock), new PropertyMetadata(0));

    public int MeanCount
    {
        get => (int)GetValue(MeanCountProperty);
        set => SetValue(MeanCountProperty, value);
    }

    /// <summary>Regulierung ein.</summary>
    public static readonly DependencyProperty IsRegulationOnProperty =
        DependencyProperty.Register(nameof(IsRegulationOn), typeof(bool), typeof(HM35_RegulationBlock), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public bool IsRegulationOn
    {
        get => (bool)GetValue(IsRegulationOnProperty);
        set => SetValue(IsRegulationOnProperty, value);
    }

    /// <summary>Korrektur am Limit (Ergänzung: vom ViewModel gesetzt).</summary>
    public static readonly DependencyProperty IsAtLimitProperty =
        DependencyProperty.Register(nameof(IsAtLimit), typeof(bool), typeof(HM35_RegulationBlock), new PropertyMetadata(false));

    public bool IsAtLimit
    {
        get => (bool)GetValue(IsAtLimitProperty);
        set => SetValue(IsAtLimitProperty, value);
    }

    /// <summary>Berechtigung für die Handeingriffe; false = gesperrt mit Schloss (Ergänzung).</summary>
    public static readonly DependencyProperty IsAuthorizedProperty =
        DependencyProperty.Register(nameof(IsAuthorized), typeof(bool), typeof(HM35_RegulationBlock), new PropertyMetadata(true));

    public bool IsAuthorized
    {
        get => (bool)GetValue(IsAuthorizedProperty);
        set => SetValue(IsAuthorizedProperty, value);
    }

    /// <summary>Regulierung minus.</summary>
    public static readonly DependencyProperty DecreaseCommandProperty =
        DependencyProperty.Register(nameof(DecreaseCommand), typeof(ICommand), typeof(HM35_RegulationBlock), new PropertyMetadata(null));

    public ICommand? DecreaseCommand
    {
        get => (ICommand?)GetValue(DecreaseCommandProperty);
        set => SetValue(DecreaseCommandProperty, value);
    }

    /// <summary>Regulierung plus.</summary>
    public static readonly DependencyProperty IncreaseCommandProperty =
        DependencyProperty.Register(nameof(IncreaseCommand), typeof(ICommand), typeof(HM35_RegulationBlock), new PropertyMetadata(null));

    public ICommand? IncreaseCommand
    {
        get => (ICommand?)GetValue(IncreaseCommandProperty);
        set => SetValue(IncreaseCommandProperty, value);
    }

    /// <summary>Regulierung ein/aus.</summary>
    public static readonly DependencyProperty ToggleCommandProperty =
        DependencyProperty.Register(nameof(ToggleCommand), typeof(ICommand), typeof(HM35_RegulationBlock), new PropertyMetadata(null));

    public ICommand? ToggleCommand
    {
        get => (ICommand?)GetValue(ToggleCommandProperty);
        set => SetValue(ToggleCommandProperty, value);
    }
}
