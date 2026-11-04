using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>Liste der anstehenden Meldungen (HS-38). Ergaenzt <see cref="IMessageService"/>, das nur die Meldezeile bedient.</summary>
public interface IActiveMessageService
{
    /// <summary>Anstehende Meldungen, aufsteigend nach Nummer.</summary>
    IReadOnlyList<MessageEntry> GetActiveMessages();

    /// <summary>Wenn sich die Liste aendert (ggf. nicht im UI-Thread).</summary>
    event EventHandler? Changed;
}
