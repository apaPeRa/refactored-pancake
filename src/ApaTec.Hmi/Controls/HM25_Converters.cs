using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ApaTec.Hmi.Controls;

/// <summary>Wandelt bool in Visibility (true = Visible, false = Collapsed) fuer Templates ohne Code-behind (HM-25).</summary>
[ValueConversion(typeof(bool), typeof(Visibility))]
public sealed class HM25_BoolToVisibility : IValueConverter
{
    public static HM25_BoolToVisibility Instance { get; } = new();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value is true ? Visibility.Visible : Visibility.Collapsed;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => value is Visibility.Visible;
}
