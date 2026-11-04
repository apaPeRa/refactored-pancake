using System.Globalization;
using System.Windows.Data;

namespace ApaTec.Hmi.Controls;

/// <summary>HM-21: liefert den Fehlertext nur fuer das Feld, das <c>ConverterParameter</c> nennt (Werte: ErrorField, ErrorText).</summary>
public sealed class HM21_FieldErrorConverter : IMultiValueConverter
{
    public object? Convert(object[] values, Type targetType, object? parameter, CultureInfo culture) =>
        values.Length >= 2 && values[0] is string field && values[1] is string text && string.Equals(field, parameter as string, StringComparison.Ordinal)
            ? text
            : null;

    public object[] ConvertBack(object value, Type[] targetTypes, object? parameter, CultureInfo culture) => throw new NotSupportedException();
}
