using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ApaTec.Hmi.Controls;

/// <summary>Art des Dosierers.</summary>
public enum DoserKind
{
    Main,
    Secondary,
}

/// <summary>Darstellung der Dosierer-Karte.</summary>
public enum CardMode
{
    Compact,
    Detail,
}

/// <summary>Ergebnis der Nachgabe des Nachdosierers.</summary>
public enum RefillResult
{
    None,
    Dosed,
    RejectedTooMuch,
}

/// <summary>HM-20 Dosierer-Karte: Kompaktkarte und Detailseitengeruest eines Schneckendosierers (nur Dependency Properties und Befehle).</summary>
public sealed class HM20_DosingCard : Control
{
    static HM20_DosingCard()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM20_DosingCard), new FrameworkPropertyMetadata(typeof(HM20_DosingCard)));
    }

    /// <summary>Titel (Hauptdosierer 1, Hauptdosierer 2, Nachdosierer).</summary>
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(nameof(Title), typeof(string), typeof(HM20_DosingCard), new PropertyMetadata(""));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    /// <summary>Art: Hauptdosierer oder Nachdosierer.</summary>
    public static readonly DependencyProperty DoserKindProperty =
        DependencyProperty.Register(nameof(DoserKind), typeof(DoserKind), typeof(HM20_DosingCard), new PropertyMetadata(DoserKind.Main));

    public DoserKind DoserKind
    {
        get => (DoserKind)GetValue(DoserKindProperty);
        set => SetValue(DoserKindProperty, value);
    }

    /// <summary>Darstellung Kompakt oder Detail.</summary>
    public static readonly DependencyProperty CardModeProperty =
        DependencyProperty.Register(nameof(CardMode), typeof(CardMode), typeof(HM20_DosingCard), new PropertyMetadata(CardMode.Compact));

    public CardMode CardMode
    {
        get => (CardMode)GetValue(CardModeProperty);
        set => SetValue(CardModeProperty, value);
    }

    /// <summary>Soll in % (nur Hauptdosierer).</summary>
    public static readonly DependencyProperty TargetPercentProperty =
        DependencyProperty.Register(nameof(TargetPercent), typeof(double), typeof(HM20_DosingCard), new PropertyMetadata(0d));

    public double TargetPercent
    {
        get => (double)GetValue(TargetPercentProperty);
        set => SetValue(TargetPercentProperty, value);
    }

    /// <summary>Soll in g (Hauptdosierer: absolut, Nachdosierer: Soll).</summary>
    public static readonly DependencyProperty TargetWeightProperty =
        DependencyProperty.Register(nameof(TargetWeight), typeof(double), typeof(HM20_DosingCard), new PropertyMetadata(0d));

    public double TargetWeight
    {
        get => (double)GetValue(TargetWeightProperty);
        set => SetValue(TargetWeightProperty, value);
    }

    /// <summary>Max. Nachgabe in g (nur Nachdosierer).</summary>
    public static readonly DependencyProperty MaxRefillProperty =
        DependencyProperty.Register(nameof(MaxRefill), typeof(double), typeof(HM20_DosingCard), new PropertyMetadata(0d));

    public double MaxRefill
    {
        get => (double)GetValue(MaxRefillProperty);
        set => SetValue(MaxRefillProperty, value);
    }

    /// <summary>Aktuelle Nachgabe in g (nur Nachdosierer).</summary>
    public static readonly DependencyProperty CurrentRefillProperty =
        DependencyProperty.Register(nameof(CurrentRefill), typeof(double), typeof(HM20_DosingCard), new PropertyMetadata(0d));

    public double CurrentRefill
    {
        get => (double)GetValue(CurrentRefillProperty);
        set => SetValue(CurrentRefillProperty, value);
    }

    /// <summary>Nachgabe-Ergebnis (nur Nachdosierer); RejectedTooMuch zeigt den nIO-Hinweis.</summary>
    public static readonly DependencyProperty RefillResultProperty =
        DependencyProperty.Register(nameof(RefillResult), typeof(RefillResult), typeof(HM20_DosingCard), new PropertyMetadata(RefillResult.None));

    public RefillResult RefillResult
    {
        get => (RefillResult)GetValue(RefillResultProperty);
        set => SetValue(RefillResultProperty, value);
    }

    /// <summary>Regulierwert in g.</summary>
    public static readonly DependencyProperty RegulationValueProperty =
        DependencyProperty.Register(nameof(RegulationValue), typeof(double), typeof(HM20_DosingCard), new PropertyMetadata(0d));

    public double RegulationValue
    {
        get => (double)GetValue(RegulationValueProperty);
        set => SetValue(RegulationValueProperty, value);
    }

    /// <summary>Eichdosierung in g.</summary>
    public static readonly DependencyProperty CalibrationWeightProperty =
        DependencyProperty.Register(nameof(CalibrationWeight), typeof(double), typeof(HM20_DosingCard), new PropertyMetadata(0d));

    public double CalibrationWeight
    {
        get => (double)GetValue(CalibrationWeightProperty);
        set => SetValue(CalibrationWeightProperty, value);
    }

    /// <summary>Eichdosierung: Umdrehungen.</summary>
    public static readonly DependencyProperty CalibrationRevolutionsProperty =
        DependencyProperty.Register(nameof(CalibrationRevolutions), typeof(int), typeof(HM20_DosingCard), new PropertyMetadata(0));

    public int CalibrationRevolutions
    {
        get => (int)GetValue(CalibrationRevolutionsProperty);
        set => SetValue(CalibrationRevolutionsProperty, value);
    }

    /// <summary>Schnecke Drehzahl in 1/min.</summary>
    public static readonly DependencyProperty ScrewSpeedProperty =
        DependencyProperty.Register(nameof(ScrewSpeed), typeof(double), typeof(HM20_DosingCard), new PropertyMetadata(0d));

    public double ScrewSpeed
    {
        get => (double)GetValue(ScrewSpeedProperty);
        set => SetValue(ScrewSpeedProperty, value);
    }

    /// <summary>Ruehrer in %.</summary>
    public static readonly DependencyProperty AgitatorPercentProperty =
        DependencyProperty.Register(nameof(AgitatorPercent), typeof(double), typeof(HM20_DosingCard), new PropertyMetadata(0d));

    public double AgitatorPercent
    {
        get => (double)GetValue(AgitatorPercentProperty);
        set => SetValue(AgitatorPercentProperty, value);
    }

    /// <summary>Querschnecke in %.</summary>
    public static readonly DependencyProperty CrossScrewPercentProperty =
        DependencyProperty.Register(nameof(CrossScrewPercent), typeof(double), typeof(HM20_DosingCard), new PropertyMetadata(0d));

    public double CrossScrewPercent
    {
        get => (double)GetValue(CrossScrewPercentProperty);
        set => SetValue(CrossScrewPercentProperty, value);
    }

    /// <summary>Nachlauf Ruehrer in s.</summary>
    public static readonly DependencyProperty AgitatorRunOnProperty =
        DependencyProperty.Register(nameof(AgitatorRunOn), typeof(double), typeof(HM20_DosingCard), new PropertyMetadata(0d));

    public double AgitatorRunOn
    {
        get => (double)GetValue(AgitatorRunOnProperty);
        set => SetValue(AgitatorRunOnProperty, value);
    }

    /// <summary>Trichter oben.</summary>
    public static readonly DependencyProperty HopperUpperProperty =
        DependencyProperty.Register(nameof(HopperUpper), typeof(LedState), typeof(HM20_DosingCard), new PropertyMetadata(LedState.Off));

    public LedState HopperUpper
    {
        get => (LedState)GetValue(HopperUpperProperty);
        set => SetValue(HopperUpperProperty, value);
    }

    /// <summary>Trichter unten.</summary>
    public static readonly DependencyProperty HopperLowerProperty =
        DependencyProperty.Register(nameof(HopperLower), typeof(LedState), typeof(HM20_DosingCard), new PropertyMetadata(LedState.Off));

    public LedState HopperLower
    {
        get => (LedState)GetValue(HopperLowerProperty);
        set => SetValue(HopperLowerProperty, value);
    }

    /// <summary>Auslastung in %.</summary>
    public static readonly DependencyProperty LoadProperty =
        DependencyProperty.Register(nameof(Load), typeof(double), typeof(HM20_DosingCard), new PropertyMetadata(0d));

    public double Load
    {
        get => (double)GetValue(LoadProperty);
        set => SetValue(LoadProperty, value);
    }

    /// <summary>Warnschwelle der Auslastung in % (Annahme 90, wie HM-10).</summary>
    public static readonly DependencyProperty LoadWarningThresholdProperty =
        DependencyProperty.Register(nameof(LoadWarningThreshold), typeof(double?), typeof(HM20_DosingCard), new PropertyMetadata(90d));

    public double? LoadWarningThreshold
    {
        get => (double?)GetValue(LoadWarningThresholdProperty);
        set => SetValue(LoadWarningThresholdProperty, value);
    }

    /// <summary>Schalter Querschnecke.</summary>
    public static readonly DependencyProperty CrossScrewEnabledProperty =
        DependencyProperty.Register(nameof(CrossScrewEnabled), typeof(bool), typeof(HM20_DosingCard), new PropertyMetadata(false));

    public bool CrossScrewEnabled
    {
        get => (bool)GetValue(CrossScrewEnabledProperty);
        set => SetValue(CrossScrewEnabledProperty, value);
    }

    /// <summary>Schalter Ruehrer.</summary>
    public static readonly DependencyProperty AgitatorEnabledProperty =
        DependencyProperty.Register(nameof(AgitatorEnabled), typeof(bool), typeof(HM20_DosingCard), new PropertyMetadata(false));

    public bool AgitatorEnabled
    {
        get => (bool)GetValue(AgitatorEnabledProperty);
        set => SetValue(AgitatorEnabledProperty, value);
    }

    /// <summary>Schalter Regulierung.</summary>
    public static readonly DependencyProperty RegulationEnabledProperty =
        DependencyProperty.Register(nameof(RegulationEnabled), typeof(bool), typeof(HM20_DosingCard), new PropertyMetadata(false));

    public bool RegulationEnabled
    {
        get => (bool)GetValue(RegulationEnabledProperty);
        set => SetValue(RegulationEnabledProperty, value);
    }

    /// <summary>Ausgewaehlt (Text und Symbol, nicht nur Farbe).</summary>
    public static readonly DependencyProperty IsSelectedProperty =
        DependencyProperty.Register(nameof(IsSelected), typeof(bool), typeof(HM20_DosingCard), new PropertyMetadata(false));

    public bool IsSelected
    {
        get => (bool)GetValue(IsSelectedProperty);
        set => SetValue(IsSelectedProperty, value);
    }

    /// <summary>Gesperrt: Tasten deaktiviert, Schloss und Text.</summary>
    public static readonly DependencyProperty IsLockedProperty =
        DependencyProperty.Register(nameof(IsLocked), typeof(bool), typeof(HM20_DosingCard), new PropertyMetadata(false));

    public bool IsLocked
    {
        get => (bool)GetValue(IsLockedProperty);
        set => SetValue(IsLockedProperty, value);
    }

    /// <summary>Entleeren laeuft (Taste im Zustand Laeuft).</summary>
    public static readonly DependencyProperty IsEmptyingProperty =
        DependencyProperty.Register(nameof(IsEmptying), typeof(bool), typeof(HM20_DosingCard), new PropertyMetadata(false));

    public bool IsEmptying
    {
        get => (bool)GetValue(IsEmptyingProperty);
        set => SetValue(IsEmptyingProperty, value);
    }

    /// <summary>Manuell dosieren (Totmann).</summary>
    public static readonly DependencyProperty ManualCommandProperty =
        DependencyProperty.Register(nameof(ManualCommand), typeof(ICommand), typeof(HM20_DosingCard), new PropertyMetadata(null));

    public ICommand? ManualCommand
    {
        get => (ICommand?)GetValue(ManualCommandProperty);
        set => SetValue(ManualCommandProperty, value);
    }

    /// <summary>Entleeren (Dauer).</summary>
    public static readonly DependencyProperty EmptyCommandProperty =
        DependencyProperty.Register(nameof(EmptyCommand), typeof(ICommand), typeof(HM20_DosingCard), new PropertyMetadata(null));

    public ICommand? EmptyCommand
    {
        get => (ICommand?)GetValue(EmptyCommandProperty);
        set => SetValue(EmptyCommandProperty, value);
    }

    /// <summary>Eichdosierung starten.</summary>
    public static readonly DependencyProperty CalibrateCommandProperty =
        DependencyProperty.Register(nameof(CalibrateCommand), typeof(ICommand), typeof(HM20_DosingCard), new PropertyMetadata(null));

    public ICommand? CalibrateCommand
    {
        get => (ICommand?)GetValue(CalibrateCommandProperty);
        set => SetValue(CalibrateCommandProperty, value);
    }

    /// <summary>Detailseite oeffnen.</summary>
    public static readonly DependencyProperty OpenDetailCommandProperty =
        DependencyProperty.Register(nameof(OpenDetailCommand), typeof(ICommand), typeof(HM20_DosingCard), new PropertyMetadata(null));

    public ICommand? OpenDetailCommand
    {
        get => (ICommand?)GetValue(OpenDetailCommandProperty);
        set => SetValue(OpenDetailCommandProperty, value);
    }

    /// <summary>Seitenlink Regulierung.</summary>
    public static readonly DependencyProperty OpenRegulationCommandProperty =
        DependencyProperty.Register(nameof(OpenRegulationCommand), typeof(ICommand), typeof(HM20_DosingCard), new PropertyMetadata(null));

    public ICommand? OpenRegulationCommand
    {
        get => (ICommand?)GetValue(OpenRegulationCommandProperty);
        set => SetValue(OpenRegulationCommandProperty, value);
    }

    /// <summary>Seitenlink Motorparameter.</summary>
    public static readonly DependencyProperty OpenMotorCommandProperty =
        DependencyProperty.Register(nameof(OpenMotorCommand), typeof(ICommand), typeof(HM20_DosingCard), new PropertyMetadata(null));

    public ICommand? OpenMotorCommand
    {
        get => (ICommand?)GetValue(OpenMotorCommandProperty);
        set => SetValue(OpenMotorCommandProperty, value);
    }

    /// <summary>Seitenlink Gewichtskorrektur.</summary>
    public static readonly DependencyProperty OpenWeightCorrectionCommandProperty =
        DependencyProperty.Register(nameof(OpenWeightCorrectionCommand), typeof(ICommand), typeof(HM20_DosingCard), new PropertyMetadata(null));

    public ICommand? OpenWeightCorrectionCommand
    {
        get => (ICommand?)GetValue(OpenWeightCorrectionCommandProperty);
        set => SetValue(OpenWeightCorrectionCommandProperty, value);
    }

    /// <summary>Antippen eines Eingabefelds (Eingabe-Pop-up); CommandParameter ist das <c>DoserField</c>. Ergaenzung (Integration, A-88), null = Felder reagieren nicht.</summary>
    public static readonly DependencyProperty EditCommandProperty =
        DependencyProperty.Register(nameof(EditCommand), typeof(ICommand), typeof(HM20_DosingCard), new PropertyMetadata(null));

    public ICommand? EditCommand
    {
        get => (ICommand?)GetValue(EditCommandProperty);
        set => SetValue(EditCommandProperty, value);
    }
}
