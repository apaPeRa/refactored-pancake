using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ApaTec.Hmi.Controls;

/// <summary>
/// Formatiert (nach CurrentCulture, nicht nach der Binding-Kultur: Dezimalkomma) den Wert von HM-10 mit <c>StringFormat</c> und geschuetztem Leerzeichen vor "%" (z. B. "83 %"). Ungueltiger Wert ergibt "---".
/// Eingaben: Value, StringFormat, IsValueValid.
/// </summary>
public sealed class HM10_PercentTextConverter : IMultiValueConverter
{
    private const string Invalid = "---";
    private const string Suffix = " %";

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length < 3 || values[0] is not double value || values[2] is not true)
        {
            return Invalid;
        }

        var format = values[1] as string;
        return value.ToString(string.IsNullOrEmpty(format) ? "N0" : format, CultureInfo.CurrentCulture) + Suffix;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotSupportedException();
}

/// <summary>Bestimmt die Stufe des Balkens ("Normal", "Warning", "Error") aus Value, WarningThreshold, ErrorThreshold und IsValueValid.</summary>
public sealed class HM10_LevelConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length < 4 || values[0] is not double value || values[3] is not true)
        {
            return "Normal";
        }

        if (values[2] is double error && value >= error)
        {
            return "Error";
        }

        if (values[1] is double warning && value >= warning)
        {
            return "Warning";
        }

        return "Normal";
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotSupportedException();
}
