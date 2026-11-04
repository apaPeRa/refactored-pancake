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

/// <summary>Ein Filterfeld der Filtervariante: Beschriftung, Art, aktueller Wert und Formatplatzhalter; leerer Wert = kein Kriterium.</summary>
public sealed class FilterField
{
    public string Name { get; set; } = string.Empty;

    public FilterFieldKind Kind { get; set; }

    public string Value { get; set; } = string.Empty;

    /// <summary>Formatplatzhalter als Text, z. B. <c>__.__.____ __:__:__</c>.</summary>
    public string Placeholder { get; set; } = string.Empty;

    /// <summary>Aktive Eingabezeile (Kontur <c>Border.Thick</c>, <c>Brush.Border.Focus</c>).</summary>
    public bool IsActive { get; set; }
}
