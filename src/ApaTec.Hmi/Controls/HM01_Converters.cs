using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ApaTec.Hmi.Controls;

/// <summary>Token-Name (<c>Icon.Home</c>) in die Symbol-Geometrie der Anwendungsressourcen.</summary>
public sealed class HM01_IconKeyConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        value is string key && key.Length > 0 ? Application.Current?.TryFindResource(key) as Geometry : null;

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => Binding.DoNothing;
}

/// <summary>values[0] = Kennung des Eintrags, values[1] = <c>CurrentItemId</c>; true bei Gleichheit.</summary>
public sealed class HM01_CurrentItemConverter : IMultiValueConverter
{
    public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture) =>
        values.Length >= 2 && values[0] is string id && id.Length > 0 && values[1] is string current && string.Equals(id, current, StringComparison.Ordinal);

    public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture) => throw new NotSupportedException();
}

/// <summary>values[0] = <c>ShowsBadge</c> des Eintrags, values[1] = Anzahl neuer Meldungen; liefert die Anzahl oder 0.</summary>
public sealed class HM01_BadgeCountConverter : IMultiValueConverter
{
    public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture) =>
        values.Length >= 2 && values[0] is true && values[1] is int count && count > 0 ? count : 0;

    public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture) => throw new NotSupportedException();
}

/// <summary>Zahl im Zaehler-Punkt: 1 bis 99, ab 100 "99+" (HM-01).</summary>
public sealed class HM01_BadgeTextConverter : IValueConverter
{
    private const int MaxShown = 99;

    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        value is int count ? (count > MaxShown ? $"{MaxShown}+" : count.ToString(culture)) : string.Empty;

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => Binding.DoNothing;
}
