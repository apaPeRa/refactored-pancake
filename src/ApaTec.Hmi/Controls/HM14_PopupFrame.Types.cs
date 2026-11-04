using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ApaTec.Hmi.Controls;

/// <summary>Art des Pop-up-Rahmens (HM-14).</summary>
public enum PopupKind
{
    Content,
    Confirmation,
    FileResult,
}

/// <summary>Ergebnisart des Datei-/Ergebnis-Pop-ups.</summary>
public enum ResultKind
{
    None,
    Success,
    Error,
}

/// <summary>Maximale Breite = Breitenanteil mal Fensterbreite (Werte: Anteil, Fensterbreite). Reiner Wertumsetzer fuer die Vorlage, keine Seitenlogik.</summary>
public sealed class HM14_WidthRatioConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length == 2 && values[0] is double ratio && values[1] is double width)
        {
            return ratio * width;
        }

        return double.PositiveInfinity;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotSupportedException();
}

/// <summary>Liefert true, wenn der Wert null ist (unbestimmter Fortschritt).</summary>
public sealed class HM14_IsNullConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object parameter, CultureInfo culture) => value is null;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => DependencyProperty.UnsetValue;
}
