using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>Wochenzeitplan (Zeitschaltuhr) des Heissleimgeraets (HS-10; Konzept.md 6.6). Heizphasen enthalten Absenkphasen (<see cref="ScheduleEntry.ParentId"/>).</summary>
public interface IHotGlueScheduleService
{
    /// <summary>Alle Eintraege der Woche.</summary>
    IReadOnlyList<ScheduleEntry> Entries { get; }

    /// <summary>Legt einen Eintrag an (die Kennung wird vergeben) und liefert ihn zurueck.</summary>
    Task<ScheduleEntry> AddAsync(ScheduleEntry entry, CancellationToken cancellationToken = default);

    Task UpdateAsync(ScheduleEntry entry, CancellationToken cancellationToken = default);

    /// <summary>Loescht einen Eintrag; eine Heizphase mit Absenkphasen wird abgelehnt (<see cref="InvalidOperationException"/>).</summary>
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>Wenn sich die Eintraege aendern (ggf. nicht im UI-Thread).</summary>
    event EventHandler? Changed;
}
