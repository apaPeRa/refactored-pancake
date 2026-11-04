using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>Meldungen fuer die Meldezeile (HM-03) und den Zaehler der Seitenleiste (HM-01; Konzept.md 6.6).</summary>
public interface IMessageService
{
    /// <summary>Anzuzeigende Meldung (hoechste Prioritaet) oder ein befristeter Hinweistext; null = keine Meldung.</summary>
    MessageInfo? Current { get; }

    /// <summary>Anzahl weiterer Meldungen neben <see cref="Current"/>.</summary>
    int AdditionalCount { get; }

    /// <summary>Neue (ungelesene) Meldungen.</summary>
    int UnreadCount { get; }

    /// <summary>Zeigt befristet einen Hinweistext in der Meldezeile (A-28: Grund fuer ein deaktiviertes Element).</summary>
    void ShowHint(string text);

    /// <summary>Wenn sich die Meldung, die Zaehler oder der Hinweis aendern (ggf. nicht im UI-Thread).</summary>
    event EventHandler? Changed;
}
