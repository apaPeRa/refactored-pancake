using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>Meldearchiv (HS-37; Konzept.md 6.6).</summary>
public interface IMessageArchiveService
{
    /// <summary>Alle gespeicherten Meldungen passend zum Filter, neueste zuerst (null oder leer = alle).</summary>
    IReadOnlyList<MessageEntry> GetEntries(ArchiveFilter? filter);

    Task ClearAsync();

    Task<FileOperationResult> ExportAsync(ArchiveFilter? filter, string fileName);
}
