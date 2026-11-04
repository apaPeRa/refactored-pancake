using System.Globalization;
using System.Windows.Data;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Services;

namespace ApaTec.Hmi.Controls;

/// <summary>Zeit hh:mm als Text; leer als Platzhalter „__:__“ (HM-30).</summary>
[ValueConversion(typeof(TimeOnly?), typeof(string))]
public sealed class HM30_TimeTextConverter : IValueConverter
{
    public static HM30_TimeTextConverter Instance { get; } = new();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value is TimeOnly t ? t.ToString("HH:mm", CultureInfo.InvariantCulture) : LocalizationService.Instance.GetString("HM30_Time_Placeholder");

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => value is string s && TimeOnly.TryParseExact(s, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var t) ? t : null!;
}

/// <summary>Aktion (Heizphase/Absenkphase) als Index fuer das Auswahlfeld HM-18.</summary>
[ValueConversion(typeof(ScheduleKind), typeof(int))]
public sealed class HM30_KindIndexConverter : IValueConverter
{
    public static HM30_KindIndexConverter Instance { get; } = new();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value is ScheduleKind k ? (int)k : 0;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => value is int i && Enum.IsDefined(typeof(ScheduleKind), i) ? (ScheduleKind)i : ScheduleKind.Heat;
}

/// <summary>Anzeigetext der Aktion.</summary>
[ValueConversion(typeof(ScheduleKind), typeof(string))]
public sealed class HM30_KindTextConverter : IValueConverter
{
    public static HM30_KindTextConverter Instance { get; } = new();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => LocalizationService.Instance.GetString(value is ScheduleKind.Setback ? "HM30_Kind_Setback" : "HM30_Kind_Heat");

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotSupportedException();
}

/// <summary>Auswahlliste der Aktionen in Reihenfolge des Enums (Eingabewert wird ignoriert).</summary>
public sealed class HM30_KindListConverter : IValueConverter
{
    public static HM30_KindListConverter Instance { get; } = new();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => new[]
        {
            LocalizationService.Instance.GetString("HM30_Kind_Heat"),
            LocalizationService.Instance.GetString("HM30_Kind_Setback"),
        };

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotSupportedException();
}

/// <summary>Loeschen erlaubt: nicht bei Neuanlage und bei Heizphase nur ohne Absenkphasen. Eingaben: IsNew, Kind, ChildCount.</summary>
public sealed class HM30_CanDeleteConverter : IMultiValueConverter
{
    public static HM30_CanDeleteConverter Instance { get; } = new();

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        var isNew = values.Length > 0 && values[0] is true;
        var kind = values.Length > 1 && values[1] is ScheduleKind k ? k : ScheduleKind.Heat;
        var children = values.Length > 2 && values[2] is int c ? c : 0;
        return !isNew && !(kind == ScheduleKind.Heat && children > 0);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        => throw new NotSupportedException();
}

/// <summary>Hinweis „Zuerst Absenkphasen loeschen“ sichtbar: Heizphase in Bearbeitung mit Absenkphasen. Eingaben: IsNew, Kind, ChildCount.</summary>
public sealed class HM30_ChildHintConverter : IMultiValueConverter
{
    public static HM30_ChildHintConverter Instance { get; } = new();

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        var isNew = values.Length > 0 && values[0] is true;
        var kind = values.Length > 1 && values[1] is ScheduleKind k ? k : ScheduleKind.Heat;
        var children = values.Length > 2 && values[2] is int c ? c : 0;
        return !isNew && kind == ScheduleKind.Heat && children > 0;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        => throw new NotSupportedException();
}

/// <summary>Uebernehmen erlaubt: kein Fehlertext und mindestens eine Zeit aktiv. Eingaben: ErrorText, StartActive, EndActive.</summary>
public sealed class HM30_CanApplyConverter : IMultiValueConverter
{
    public static HM30_CanApplyConverter Instance { get; } = new();

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        var error = values.Length > 0 ? values[0] as string : null;
        var start = values.Length > 1 && values[1] is true;
        var end = values.Length > 2 && values[2] is true;
        return string.IsNullOrEmpty(error) && (start || end);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
