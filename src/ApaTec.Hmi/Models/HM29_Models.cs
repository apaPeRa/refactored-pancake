namespace ApaTec.Hmi.Models;

/// <summary>Art eines Zeitplan-Eintrags (HM-29, HM-30): Heizphase oder Absenkphase innerhalb einer Heizphase.</summary>
public enum ScheduleKind
{
    Heat,
    Setback,
}

/// <summary>
/// Eintrag der Zeitschaltuhr (HM-29). Heizphase: Start = Aufheizen, End = alle Heizungen aus. Absenkphase: Start = absenken, End = aufheizen;
/// <see cref="ParentId"/> verweist auf die Heizphase. <see cref="IsInvalid"/> markiert Ueberschneidung oder ungueltige Zeiten.
/// </summary>
public sealed record ScheduleEntry(int Id, DayOfWeek Day, ScheduleKind Kind, TimeOnly? Start, TimeOnly? End, int? ParentId = null, bool IsInvalid = false);
