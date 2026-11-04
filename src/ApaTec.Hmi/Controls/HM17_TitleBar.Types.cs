using System.Globalization;
using System.Windows.Data;

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

/// <summary>
/// Abweichung der Titelzeile (HM-17): values[0] = <c>HasDeviation</c> (vom ViewModel gesetzt, hat Vorrang), values[1] = <c>DeviationLimit</c>, values[2] = <c>Values</c>.
/// Mit Grenze und zwei Kennwerten (Soll, Letzter Wert; Anzeigetext nach <see cref="CultureInfo.CurrentCulture"/>) ist es eine Abweichung, wenn der Betrag der Differenz die Grenze uebersteigt.
/// </summary>
public sealed class HM17_DeviationConverter : IMultiValueConverter
{
    public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values.Length > 0 && values[0] is true)
        {
            return true;
        }

        if (values.Length < 3 || values[1] is not double limit || values[2] is not IReadOnlyList<TitleValue> { Count: >= 2 } items)
        {
            return false;
        }

        var style = NumberStyles.Float | NumberStyles.AllowThousands;
        return double.TryParse(items[0].Value, style, CultureInfo.CurrentCulture, out var reference)
               && double.TryParse(items[1].Value, style, CultureInfo.CurrentCulture, out var actual)
               && Math.Abs(actual - reference) > limit;
    }

    public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture) => throw new NotSupportedException();
}
