using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ApaTec.Hmi.Controls;

/// <summary>Darstellung der Blaettertasten (HM-19): Paar, einzelne Taste „»“ oder (Funktionsleiste, HM-06) je eine einzelne Pfeiltaste zurueck bzw. vor.</summary>
public enum PagerStyle
{
    Pair,
    Single,
    PreviousOnly,
    NextOnly,
}

/// <summary>Anordnung: Funktionsleiste (Standard), Paar im Inhaltsbereich oder Tasten links und rechts neben einem Feld.</summary>
public enum PagerPlacement
{
    FunctionBar,
    Inline,
    Flanking,
}

/// <summary>Ausrichtung der Pfeiltasten.</summary>
public enum PagerOrientation
{
    Horizontal,
    Vertical,
}

/// <summary>Positionsanzeige: Single = „n von m“, Range = „n–m von k“.</summary>
public enum PagerPositionMode
{
    Single,
    Range,
}

/// <summary>Wandelt den nullbasierten Index in die angezeigte Nummer (Index + 1). Reiner Wertumsetzer fuer die Vorlage.</summary>
public sealed class HM19_IndexToNumberConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object parameter, CultureInfo culture) => value is int index ? index + 1 : 0;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => DependencyProperty.UnsetValue;
}

/// <summary>
/// Freigabe einer Pfeiltaste nach Index (HM-19): values[0] = <c>CurrentIndex</c>, values[1] = <c>Count</c>, values[2] = <c>IsCyclic</c>; Parameter <c>Previous</c> oder <c>Next</c>.
/// Umlaufend oder Anzahl unbekannt (hoechstens 1) = immer frei, sonst am Rand gesperrt. Der Befehl (<c>CanExecute</c>) sperrt zusaetzlich.
/// </summary>
public sealed class HM19_EdgeEnabledConverter : IMultiValueConverter
{
    public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values.Length < 3 || values[0] is not int index || values[1] is not int count || values[2] is not bool cyclic)
        {
            return true;
        }

        if (cyclic || count <= 1)
        {
            return true;
        }

        return string.Equals(parameter as string, "Previous", StringComparison.Ordinal) ? index > 0 : index < count - 1;
    }

    public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture) => throw new NotSupportedException();
}
