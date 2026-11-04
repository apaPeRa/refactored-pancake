namespace ApaTec.Hmi.Controls;

/// <summary>Ausrichtung des Objektnamens in der Titelzeile (HM-17).</summary>
public enum TitleAlignment
{
    Center,
    Left,
}

/// <summary>Kennwert der Titelzeile, z. B. Sollgewicht KW = 235 g.</summary>
public sealed class TitleValue
{
    public string Label { get; set; } = string.Empty;

    /// <summary>Bereits formatierter Wert (ohne Einheit).</summary>
    public string Value { get; set; } = string.Empty;

    public string Unit { get; set; } = string.Empty;
}
