using System.ComponentModel;

namespace ApaTec.Hmi.Controls;

/// <summary>Eingabeart des Eingabe-Pop-ups (HM-13).</summary>
public enum InputKind
{
    Number,
    Time,
    Text,
    Filter,
}

/// <summary>Art eines Filterfelds in der Filtervariante (HS-37).</summary>
public enum FilterFieldKind
{
    Number,
    DateTime,
}

/// <summary>
/// Ein Filterfeld der Filtervariante: Beschriftung, Art, aktueller Wert und Formatplatzhalter; leerer Wert = kein Kriterium.
/// Meldet Aenderungen von <see cref="Value"/> und <see cref="IsActive"/> (Datentyp, keine Seitenlogik), damit die Zeile waehrend der Eingabe aktualisiert wird.
/// </summary>
public sealed class FilterField : INotifyPropertyChanged
{
    private string _value = string.Empty;
    private bool _isActive;

    public event PropertyChangedEventHandler? PropertyChanged;

    public string Name { get; set; } = string.Empty;

    public FilterFieldKind Kind { get; set; }

    public string Value
    {
        get => _value;
        set
        {
            if (_value != value)
            {
                _value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
            }
        }
    }

    /// <summary>Formatplatzhalter als Text, z. B. <c>__.__.____ __:__:__</c>.</summary>
    public string Placeholder { get; set; } = string.Empty;

    /// <summary>Aktive Eingabezeile (Kontur <c>Border.Thick</c>, <c>Brush.Border.Focus</c>).</summary>
    public bool IsActive
    {
        get => _isActive;
        set
        {
            if (_isActive != value)
            {
                _isActive = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsActive)));
            }
        }
    }
}
