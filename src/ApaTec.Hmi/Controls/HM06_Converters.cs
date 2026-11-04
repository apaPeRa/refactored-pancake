using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ApaTec.Hmi.Controls;

/// <summary>Token-Name (<c>Icon.Schedule</c>) in die Symbol-Geometrie der Anwendungsressourcen.</summary>
public sealed class HM06_IconKeyConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        value is string key && key.Length > 0 ? Application.Current?.TryFindResource(key) as Geometry : null;

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => Binding.DoNothing;
}

/// <summary>values[0] = <c>IsActive</c> der Taste, values[1] = <c>TargetId</c> der Taste, values[2] = <c>CurrentTargetId</c> der Leiste; true, wenn aktiv oder die Ziele gleich sind.</summary>
public sealed class HM06_ActiveConverter : IMultiValueConverter
{
    public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values.Length > 0 && values[0] is true)
        {
            return true;
        }

        return values.Length > 2
               && values[1] is string target && target.Length > 0
               && values[2] is string current && string.Equals(target, current, StringComparison.Ordinal);
    }

    public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture) => throw new NotSupportedException();
}
