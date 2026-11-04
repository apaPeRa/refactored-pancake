namespace ApaTec.Hmi.Services;

/// <summary>Ergebnis eines Dialogs: bestaetigt (Uebernehmen/Ja) oder abgebrochen.</summary>
public sealed record DialogResult<T>(bool Accepted, T? Value);

/// <summary>Pop-ups ohne HS-Seite (Navigation.md 4 und 5.2). Es gilt der Popup-Stapel des Navigationsdienstes (Tiefe 2).</summary>
public interface IDialogService
{
    bool IsModalOpen { get; }

    /// <summary>Oeffnet den Dialog mit dem Dialogschluessel (<c>DialogKeys</c>) und wartet auf das Schliessen. Wird die Anforderung abgelehnt (Stapel voll), ist <c>Accepted</c> false.</summary>
    Task<DialogResult<T>> ShowAsync<T>(string dialogKey, object? parameter = null);

    void CloseTop();

    void CloseAll();
}
