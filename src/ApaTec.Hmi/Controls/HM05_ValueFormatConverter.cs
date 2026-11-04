using System.Globalization;
using System.Windows.Data;

namespace ApaTec.Hmi.Controls;

/// <summary>
/// Anzeigetext der Kennzahl-Kachel (HM-05). values[0] = Wert (double?), values[1] = Zeitwert (TimeSpan?), values[2] = Zahlenformat (string).
/// Zeitwert hat Vorrang und erscheint als h:mm:ss (Stunden auch ueber 24); ohne Wert "---". Formatiert wird nach <see cref="CultureInfo.CurrentCulture"/>.
/// </summary>
public sealed class HM05_ValueFormatConverter : IMultiValueConverter
{
    private const string Invalid = "---";

    public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
    {
        var current = CultureInfo.CurrentCulture;
        if (values.Length > 1 && values[1] is TimeSpan time)
        {
            return $"{(long)time.TotalHours}:{time.Minutes:00}:{time.Seconds:00}";
        }

        if (values.Length > 0 && values[0] is double number && !double.IsNaN(number))
        {
            var format = values.Length > 2 && values[2] is string f && f.Length > 0 ? f : "N0";
            return number.ToString(format, current);
        }

        return Invalid;
    }

    public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture) => throw new NotSupportedException();
}
