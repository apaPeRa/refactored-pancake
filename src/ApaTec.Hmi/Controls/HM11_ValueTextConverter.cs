using System.Globalization;
using System.Windows.Data;

namespace ApaTec.Hmi.Controls;

/// <summary>
/// Formatierung fuer HM-11 (Designsystem 11): Zahl mit <c>CurrentCulture</c> (Dezimalkomma), Datum "TT.MM.JJJJ hh:mm:ss", Dauer "hhh:mm:ss" oder einzeln
/// ("Hours", "Minutes", "Seconds" als ConverterParameter), Text unveraendert; leerer oder ungueltiger Wert ergibt "---" bzw. den Platzhalter.
/// Eingaben: ValueKind, NumberValue, TextValue, TimeValue, Decimals. Die Einheit setzt die Vorlage hinter einem geschuetzten Leerzeichen an.
/// </summary>
public sealed class HM11_ValueTextConverter : IMultiValueConverter
{
    private const string Invalid = "---";
    private const string DatePattern = "dd.MM.yyyy HH:mm:ss";
    private const string DatePlaceholder = "--.--.---- --:--:--";
    private const string DurationPlaceholder = "---:--:--";

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length < 5 || values[0] is not ValueKind kind)
        {
            return Invalid;
        }

        var decimals = values[4] is int d ? Math.Clamp(d, 0, 3) : 0;
        return kind switch
        {
            ValueKind.Number => values[1] is double number ? number.ToString("N" + decimals, CultureInfo.CurrentCulture) : Invalid,
            ValueKind.Text => values[2] is string { Length: > 0 } text ? text : Invalid,
            ValueKind.DateTime => values[3] is DateTime time ? time.ToString(DatePattern, CultureInfo.CurrentCulture) : DatePlaceholder,
            ValueKind.Duration => FormatDuration(values[3], parameter as string),
            _ => Invalid,
        };
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotSupportedException();

    private static string FormatDuration(object? value, string? part)
    {
        if (value is not TimeSpan span)
        {
            return part is null ? DurationPlaceholder : Invalid;
        }

        var hours = (long)Math.Floor(span.TotalHours);
        return part switch
        {
            "Hours" => hours.ToString(CultureInfo.CurrentCulture),
            "Minutes" => span.Minutes.ToString(CultureInfo.CurrentCulture),
            "Seconds" => span.Seconds.ToString(CultureInfo.CurrentCulture),
            _ => string.Create(CultureInfo.CurrentCulture, $"{hours:000}:{span.Minutes:00}:{span.Seconds:00}"),
        };
    }
}
