using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.DesignData;

/// <summary>Beispielwerte fuer HM-29 / HM-30 (Zeitschaltuhr HS-10): Heizphase 08:00 bis 16:00, Absenkphase 12:00 bis 13:00.</summary>
public static class HM29_DesignData
{
    public static IReadOnlyList<ScheduleEntry> Entries { get; } = new List<ScheduleEntry>
    {
        new(1, DayOfWeek.Monday, ScheduleKind.Heat, new TimeOnly(8, 0), new TimeOnly(16, 0)),
        new(2, DayOfWeek.Monday, ScheduleKind.Setback, new TimeOnly(12, 0), new TimeOnly(13, 0), 1),
        new(3, DayOfWeek.Tuesday, ScheduleKind.Heat, new TimeOnly(8, 0), new TimeOnly(16, 0)),
        new(4, DayOfWeek.Wednesday, ScheduleKind.Heat, new TimeOnly(8, 0), new TimeOnly(16, 0)),
        new(5, DayOfWeek.Wednesday, ScheduleKind.Setback, new TimeOnly(12, 0), new TimeOnly(13, 0), 4),
        new(6, DayOfWeek.Thursday, ScheduleKind.Heat, new TimeOnly(8, 0), new TimeOnly(16, 0), null, true),
        new(7, DayOfWeek.Friday, ScheduleKind.Heat, new TimeOnly(8, 0), new TimeOnly(14, 0)),
    };

    public static TimeOnly? StartTime => new TimeOnly(8, 0);

    public static TimeOnly? EndTime => new TimeOnly(16, 0);

    public static TimeOnly? NoTime => null;
}
