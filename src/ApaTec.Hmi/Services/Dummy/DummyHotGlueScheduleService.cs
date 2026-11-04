using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>
/// Dummy-Zeitschaltuhr mit den Beispieleintraegen aus den Bildern RS-10_02 und RS-10_04 (keine Standardwerte, OP-46): Montag und Dienstag Heizphase 06:30 ein / 14:40 aus,
/// Mittwoch Heizphase 08:00 bis 16:00 mit Absenkphase 12:00 bis 13:00. Im Auslieferungszustand waeren alle Spalten leer (RS-10_01).
/// </summary>
[DummyService]
public sealed class DummyHotGlueScheduleService : IHotGlueScheduleService
{
    private List<ScheduleEntry> _entries = new()
    {
        new(1, DayOfWeek.Monday, ScheduleKind.Heat, new TimeOnly(6, 30), new TimeOnly(14, 40)),
        new(2, DayOfWeek.Tuesday, ScheduleKind.Heat, new TimeOnly(6, 30), new TimeOnly(14, 40)),
        new(3, DayOfWeek.Wednesday, ScheduleKind.Heat, new TimeOnly(8, 0), new TimeOnly(16, 0)),
        new(4, DayOfWeek.Wednesday, ScheduleKind.Setback, new TimeOnly(12, 0), new TimeOnly(13, 0), 3),
    };

    private int _nextId = 5;

    public IReadOnlyList<ScheduleEntry> Entries => _entries;

    public event EventHandler? Changed;

    public async Task<ScheduleEntry> AddAsync(ScheduleEntry entry, CancellationToken cancellationToken = default)
    {
        await Task.Yield();
        var added = entry with { Id = _nextId++ };
        _entries = new List<ScheduleEntry>(_entries) { added };
        Changed?.Invoke(this, EventArgs.Empty);
        return added;
    }

    public async Task UpdateAsync(ScheduleEntry entry, CancellationToken cancellationToken = default)
    {
        await Task.Yield();
        _entries = _entries.Select(e => e.Id == entry.Id ? entry : e).ToList();
        Changed?.Invoke(this, EventArgs.Empty);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        await Task.Yield();
        if (_entries.Any(e => e.ParentId == id))
        {
            throw new InvalidOperationException("Eine Heizphase mit Absenkphasen kann nicht geloescht werden.");
        }

        _entries = _entries.Where(e => e.Id != id).ToList();
        Changed?.Invoke(this, EventArgs.Empty);
    }
}
