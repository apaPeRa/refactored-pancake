using CommunityToolkit.Mvvm.ComponentModel;

namespace ApaTec.Hmi.ViewModels;

/// <summary>Ein Schritt der Gruppe "Ablauf Kalibrierung" (HS-27): Wortlaut des Handbuchs, Nummer und Markierung des aktuell erwarteten Schritts (K27-3).</summary>
public sealed partial class ScaleCalibrationStepItem : ObservableObject
{
    public ScaleCalibrationStepItem(int number, string text, string caption)
    {
        Number = number;
        Text = text;
        _caption = caption;
    }

    /// <summary>Nummer des Handbuchschritts (1 bis 7).</summary>
    public int Number { get; }

    public string Text { get; }

    /// <summary>Beschriftung vor dem Text, z. B. "3." bzw. "3. aktuell".</summary>
    [ObservableProperty]
    private string _caption;

    /// <summary>true, wenn die Steuerung diesen Schritt als erwartet meldet (Symbol <c>Icon.State.On</c> plus Wort "aktuell").</summary>
    [ObservableProperty]
    private bool _isCurrent;
}
