using ApaTec.Hmi.DesignData;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>Dummy: Archiv mit den Beispielmeldungen aus dem Bild; "Liste leeren" leert es bis zum Programmende.</summary>
[DummyService]
public sealed class DummyMessageArchiveService : IMessageArchiveService
{
    private bool _cleared;

    public IReadOnlyList<MessageEntry> GetEntries(ArchiveFilter? filter)
    {
        if (_cleared)
        {
            return Array.Empty<MessageEntry>();
        }

        IEnumerable<MessageEntry> query = MessageArchive_DesignData.CreateEntries();
        if (filter?.Number is { } number)
        {
            query = query.Where(e => e.Number == number);
        }

        if (filter?.From is { } from)
        {
            query = query.Where(e => e.Timestamp >= from);
        }

        return query.OrderByDescending(e => e.Timestamp).ThenByDescending(e => e.Number).ToList();
    }

    public Task ClearAsync()
    {
        _cleared = true;
        return Task.CompletedTask;
    }

    public Task<FileOperationResult> ExportAsync(ArchiveFilter? filter, string fileName) =>
        Task.FromResult(string.IsNullOrWhiteSpace(fileName)
            ? new FileOperationResult(false, 0, null, null)
            : new FileOperationResult(true, GetEntries(filter).Count, fileName, null));
}
