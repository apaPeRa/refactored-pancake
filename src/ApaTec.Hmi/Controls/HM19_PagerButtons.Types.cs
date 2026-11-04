using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ApaTec.Hmi.Controls;

/// <summary>Darstellung der Blaettertasten (HM-19): Paar oder einzelne Taste „»“.</summary>
public enum PagerStyle
{
    Pair,
    Single,
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
