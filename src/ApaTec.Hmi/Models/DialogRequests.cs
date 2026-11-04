using ApaTec.Hmi.Controls;

namespace ApaTec.Hmi.Models;

/// <summary>
/// Einheitlicher Anforderungsvertrag des Eingabe-Pop-ups (<c>DialogKeys.Input</c>, HM-13). Alle Request-Typen der Seiten (<c>FeederInputRequest</c>,
/// <c>ClosingInputRequest</c>, <c>DoserInputRequest</c>, <c>HotGlueInputRequest</c>, <c>MachineInputRequest</c>, <c>ManualInputRequest</c>) implementieren ihn;
/// daneben versteht das Pop-up <c>NavigationParameters</c> mit den Schluesseln title, currentValue/value, unit, minimum, maximum, decimals, helpText, kind.
/// Ergebnis: <c>double</c> (Zahl; Zeit als Minuten seit 00:00) bzw. <c>string</c> (Text).
/// </summary>
public interface IInputRequest
{
    /// <summary>Feldname, erscheint als Titel im Pop-up.</summary>
    string Title { get; }

    /// <summary>Aktueller Wert (Zahl) bzw. Minuten seit 00:00 (Zeit); null = kein Wert.</summary>
    double? Value { get; }

    /// <summary>Aktueller Text (Kind = Text); sonst null.</summary>
    string? Text => null;

    string Unit { get; }

    int Decimals { get; }

    double? Minimum { get; }

    double? Maximum { get; }

    string? HelpText { get; }

    /// <summary>Vorgegebener Fehlertext bei ungueltiger Eingabe; null = Standardtext aus den Ressourcen.</summary>
    string? ErrorText => null;

    InputKind Kind { get; }
}

/// <summary>Einheitlicher Anforderungsvertrag des Bestaetigungs-Pop-ups (<c>DialogKeys.Confirmation</c>, HM-14); Ergebnis ist <c>bool</c> (Ja).</summary>
public interface IConfirmationRequest
{
    string Title { get; }

    string Message { get; }

    /// <summary>Text der Bestaetigungstaste; null = Standardtext "Ja".</summary>
    string? AcceptLabel { get; }

    /// <summary>Text der Abbrechen-Taste; null = Standardtext "Abbrechen".</summary>
    string? CancelLabel { get; }
}

/// <summary>Allgemeine Eingabeanforderung fuer neue Aufrufer (alle Felder des Vertrags).</summary>
public sealed record InputRequest(
    string Title,
    double? Value,
    string Unit = "",
    int Decimals = 0,
    double? Minimum = null,
    double? Maximum = null,
    string? HelpText = null,
    InputKind Kind = InputKind.Number,
    string? Text = null,
    string? ErrorText = null) : IInputRequest;

/// <summary>Allgemeine Bestaetigungsanforderung fuer neue Aufrufer.</summary>
public sealed record ConfirmationRequest(string Title, string Message, string? AcceptLabel = null, string? CancelLabel = null) : IConfirmationRequest;
