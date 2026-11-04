using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using ApaTec.Hmi.ViewModels;
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

/// <summary>
/// Teilt die Tastensammlung der Funktionsleiste in drei Sichten (Parameter): <c>Main</c> = die ersten 5 Tasten links, <c>Overflow</c> = alle weiteren (hinter "Mehr", HM-06),
/// <c>Trailing</c> = Tasten mit <see cref="FunctionBarItem.IsTrailing"/> (rechtsbuendig, zaehlen nicht zu den 5). Die Sichten sind eigene <see cref="ICollectionView"/>-Filter und folgen Aenderungen der Quelle.
/// </summary>
public sealed class HM06_ItemsViewConverter : IValueConverter
{
    /// <summary>Hoechstzahl der Tasten links, bevor die Ueberlauf-Taste "Mehr" erscheint.</summary>
    public const int MaxLeftItems = 5;

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not IEnumerable items)
        {
            return null;
        }

        var mode = parameter as string ?? "Main";
        var view = new CollectionViewSource { Source = items }.View;
        view.Filter = item => Include(items, item, mode);
        return view;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => Binding.DoNothing;

    private static bool Include(IEnumerable items, object item, string mode)
    {
        var trailing = item is FunctionBarItem { IsTrailing: true };
        if (mode == "Trailing")
        {
            return trailing;
        }

        if (trailing)
        {
            return false;
        }

        var index = items.Cast<object>().Where(i => i is not FunctionBarItem { IsTrailing: true }).ToList().IndexOf(item);
        return mode == "Overflow" ? index >= MaxLeftItems : index < MaxLeftItems;
    }
}

/// <summary>Tasten mit Haltebefehl (<see cref="FunctionBarItem.HoldCommand"/>) sind im Modus Hold, alle anderen Antippen.</summary>
public sealed class HM06_TriggerModeConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        value is null ? ActionTriggerMode.Tap : ActionTriggerMode.Hold;

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => Binding.DoNothing;
}

/// <summary>values[0] = Blaettertaste, values[1] = Tastensammlung der Leiste; die erste Blaettertaste ist "zurueck", jede weitere "vor".</summary>
public sealed class HM06_PagerSideConverter : IMultiValueConverter
{
    public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values.Length > 1 && values[0] is FunctionBarItem item && values[1] is IEnumerable items)
        {
            var first = items.OfType<FunctionBarItem>().FirstOrDefault(i => i.Kind == FunctionBarItemKind.Paging);
            if (ReferenceEquals(first, item))
            {
                return PagerStyle.PreviousOnly;
            }
        }

        return PagerStyle.NextOnly;
    }

    public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture) => throw new NotSupportedException();
}
