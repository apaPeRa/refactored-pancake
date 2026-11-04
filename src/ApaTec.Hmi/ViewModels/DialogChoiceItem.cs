using CommunityToolkit.Mvvm.ComponentModel;

namespace ApaTec.Hmi.ViewModels;

/// <summary>Auswahlzeile der Listen-Pop-ups (Benutzerrolle, Sprache, Rezept): Beschriftung, Wert und Auswahlzustand (Haken plus Kontur, nie nur Farbe).</summary>
public sealed partial class DialogChoiceItem : ObservableObject
{
    [ObservableProperty]
    private bool _isSelected;

    public DialogChoiceItem(string label, object value, bool isSelected = false)
    {
        Label = label;
        Value = value;
        _isSelected = isSelected;
    }

    public string Label { get; }

    public object Value { get; }
}
