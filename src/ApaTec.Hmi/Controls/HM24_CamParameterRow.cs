using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ApaTec.Hmi.Controls;

/// <summary>HM-24 Nocken-Parameterzeile: Beschriftung mit Winkel, Zeit und berechnetem Ergebnis.</summary>
public sealed class HM24_CamParameterRow : Control
{
    static HM24_CamParameterRow()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM24_CamParameterRow), new FrameworkPropertyMetadata(typeof(HM24_CamParameterRow)));
    }

    /// <summary>Beschriftung (Anfang, Ende, Dauer).</summary>
    public static readonly DependencyProperty LabelProperty =
        DependencyProperty.Register(nameof(Label), typeof(string), typeof(HM24_CamParameterRow), new PropertyMetadata(""));

    public string Label
    {
        get => (string)GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    /// <summary>Winkel in Grad.</summary>
    public static readonly DependencyProperty AngleProperty =
        DependencyProperty.Register(nameof(Angle), typeof(double?), typeof(HM24_CamParameterRow), new PropertyMetadata(null));

    public double? Angle
    {
        get => (double?)GetValue(AngleProperty);
        set => SetValue(AngleProperty, value);
    }

    /// <summary>Zeit in ms.</summary>
    public static readonly DependencyProperty TimeProperty =
        DependencyProperty.Register(nameof(Time), typeof(double?), typeof(HM24_CamParameterRow), new PropertyMetadata(null));

    public double? Time
    {
        get => (double?)GetValue(TimeProperty);
        set => SetValue(TimeProperty, value);
    }

    /// <summary>Ergebnis in Grad (berechnet, nur Anzeige).</summary>
    public static readonly DependencyProperty ResultProperty =
        DependencyProperty.Register(nameof(Result), typeof(double?), typeof(HM24_CamParameterRow), new PropertyMetadata(null));

    public double? Result
    {
        get => (double?)GetValue(ResultProperty);
        set => SetValue(ResultProperty, value);
    }

    /// <summary>Geber (z. B. Geber 1GF Hauptantrieb).</summary>
    public static readonly DependencyProperty EncoderNameProperty =
        DependencyProperty.Register(nameof(EncoderName), typeof(string), typeof(HM24_CamParameterRow), new PropertyMetadata(null));

    public string? EncoderName
    {
        get => (string?)GetValue(EncoderNameProperty);
        set => SetValue(EncoderNameProperty, value);
    }

    /// <summary>Antippen des Winkelfelds (Eingabe-Pop-up). Ergaenzung (Integration, A-88).</summary>
    public static readonly DependencyProperty EditAngleCommandProperty =
        DependencyProperty.Register(nameof(EditAngleCommand), typeof(ICommand), typeof(HM24_CamParameterRow), new PropertyMetadata(null));

    public ICommand? EditAngleCommand
    {
        get => (ICommand?)GetValue(EditAngleCommandProperty);
        set => SetValue(EditAngleCommandProperty, value);
    }

    /// <summary>Antippen des Zeitfelds (Eingabe-Pop-up). Ergaenzung (Integration, A-88).</summary>
    public static readonly DependencyProperty EditTimeCommandProperty =
        DependencyProperty.Register(nameof(EditTimeCommand), typeof(ICommand), typeof(HM24_CamParameterRow), new PropertyMetadata(null));

    public ICommand? EditTimeCommand
    {
        get => (ICommand?)GetValue(EditTimeCommandProperty);
        set => SetValue(EditTimeCommandProperty, value);
    }

    /// <summary>Berechtigung fuer die Felder; false = Schloss statt Schluessel. Ergaenzung (Integration, A-88).</summary>
    public static readonly DependencyProperty IsAuthorizedProperty =
        DependencyProperty.Register(nameof(IsAuthorized), typeof(bool), typeof(HM24_CamParameterRow), new PropertyMetadata(true));

    public bool IsAuthorized
    {
        get => (bool)GetValue(IsAuthorizedProperty);
        set => SetValue(IsAuthorizedProperty, value);
    }

    /// <summary>Nicht geschrieben (erst nach Werte schreiben wirksam).</summary>
    public static readonly DependencyProperty IsPendingWriteProperty =
        DependencyProperty.Register(nameof(IsPendingWrite), typeof(bool), typeof(HM24_CamParameterRow), new PropertyMetadata(false));

    public bool IsPendingWrite
    {
        get => (bool)GetValue(IsPendingWriteProperty);
        set => SetValue(IsPendingWriteProperty, value);
    }
}
