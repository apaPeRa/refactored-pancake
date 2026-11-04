using System.Globalization;
using System.Windows.Data;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Services;

namespace ApaTec.Hmi.Controls;

/// <summary>Sieben Wochentage ab <c>FirstDay</c> (HM-29).</summary>
[ValueConversion(typeof(DayOfWeek), typeof(IReadOnlyList<DayOfWeek>))]
public sealed class HM29_DaysConverter : IValueConverter
{
    public static HM29_DaysConverter Instance { get; } = new();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var first = value is DayOfWeek d ? (int)d : (int)DayOfWeek.Monday;
        return Enumerable.Range(0, 7).Select(i => (DayOfWeek)((first + i) % 7)).ToList();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotSupportedException();
}

/// <summary>Tagesname aus den Ressourcen (Schluessel <c>HM29_Day_&lt;Tag&gt;</c>).</summary>
[ValueConversion(typeof(DayOfWeek), typeof(string))]
public sealed class HM29_DayNameConverter : IValueConverter
{
    public static HM29_DayNameConverter Instance { get; } = new();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value is DayOfWeek d ? LocalizationService.Instance.GetString("HM29_Day_" + d) : string.Empty;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotSupportedException();
}

/// <summary>
/// Eintraege eines Tages in Anzeigereihenfolge: Heizphasen nach Startzeit, direkt darunter ihre Absenkphasen (eingerueckt dargestellt),
/// zuletzt Absenkphasen ohne passende Heizphase. Eingaben: Entries, Tag.
/// </summary>
public sealed class HM29_DayEntriesConverter : IMultiValueConverter
{
    public static HM29_DayEntriesConverter Instance { get; } = new();

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length < 2 || values[0] is not IReadOnlyList<ScheduleEntry> all || values[1] is not DayOfWeek day)
        {
            return Array.Empty<ScheduleEntry>();
        }

        var ofDay = all.Where(e => e.Day == day).ToList();
        var result = new List<ScheduleEntry>();
        foreach (var heat in ofDay.Where(e => e.Kind == ScheduleKind.Heat).OrderBy(e => e.Start ?? e.End))
        {
            result.Add(heat);
            result.AddRange(ofDay.Where(e => e.Kind == ScheduleKind.Setback && e.ParentId == heat.Id).OrderBy(e => e.Start ?? e.End));
        }

        var placed = result.Select(e => e.Id).ToHashSet();
        result.AddRange(ofDay.Where(e => !placed.Contains(e.Id)).OrderBy(e => e.Start ?? e.End));
        return result;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
