using ApaTec.Hmi.ViewModels;

namespace ApaTec.Hmi.Navigation;

/// <summary>
/// Zentraler Navigationsdienst (Navigation.md 5). ViewModels kennen keine Views; Seitenwechsel, Verlauf, Brotkruemel und Pop-up-Stapel laufen nur hier.
/// </summary>
public interface INavigationService
{
    /// <summary>Aktuelle Seite (null vor dem Start, siehe <see cref="GoHome"/>).</summary>
    PageDescriptor? Current { get; }

    object? CurrentParameter { get; }

    /// <summary>ViewModel der aktuellen Seite.</summary>
    PageViewModelBase? CurrentViewModel { get; }

    /// <summary>Zurueck-Stapel nach A-44: nur Vorgaengerseiten, <b>ohne</b> die aktuelle Seite; neueste zuletzt; Tiefe 20.</summary>
    IReadOnlyList<NavigationEntry> History { get; }

    /// <summary>Kanonischer Pfad der aktuellen Seite (nicht der Verlauf).</summary>
    IReadOnlyList<BreadcrumbItem> Breadcrumb { get; }

    /// <summary>Popup-Stapel, hoechstens <see cref="MaxPopupDepth"/> tief; nie im Verlauf.</summary>
    IReadOnlyList<PopupViewModelBase> PopupStack { get; }

    PopupViewModelBase? CurrentPopup { get; }

    /// <summary>true, solange ein Pop-up offen ist (Seitenleiste, Funktionsleiste und Inhalt gesperrt).</summary>
    bool IsModalOpen { get; }

    bool CanGoBack { get; }

    /// <summary>Hoechste Tiefe des Popup-Stapels (Navigation.md 4.2).</summary>
    int MaxPopupDepth { get; }

    /// <summary>
    /// Navigiert zur Seite (Kachel, Funktionsleiste, Brotkruemel). Pop-up-Seiten (HS-02, HS-03) gehen auf den Popup-Stapel.
    /// Ist die Rolle zu niedrig, wird <c>IUserSession.RequestRoleAsync</c> gerufen. false = abgelehnt, wirkungslos oder abgebrochen.
    /// </summary>
    Task<bool> NavigateToAsync(string pageKey, object? parameter = null);

    /// <summary>Blaettern: neuer Parameter ohne Verlaufseintrag.</summary>
    void ReplaceParameter(object? parameter);

    /// <summary>Zurueck zum obersten Stapeleintrag; bei leerem Stapel (nicht HS-01) zum Elternschluessel. false bei offenem Pop-up oder auf HS-01.</summary>
    /// <remarks>
    /// Leave-Hook: Zurueck, Brotkruemel, Home, Einstellungen und <see cref="NavigateToAsync"/> fragen <c>PageViewModelBase.CanLeaveAsync</c> der aktuellen Seite.
    /// Bei den synchronen Wegen laeuft eine noetige Rueckfrage asynchron (Rueckgabe true = angenommen); Systemwechsel (Rollenverlust, Zeitablauf) fragen nicht.
    /// </remarks>
    bool GoBack();

    /// <summary>Sprung auf eine Seite im Verlauf oder einen Vorfahren (Brotkruemel-Segment); der Stapel wird bis unterhalb der Zielseite gekuerzt.</summary>
    bool GoToAncestor(string pageKey);

    /// <summary>Home: HS-01, Stapel leer. Dient auch als Start der Anwendung (<see cref="PageKeys.Start"/>).</summary>
    void GoHome();

    /// <summary>Einstellungen: HS-04, Stapel <c>[HS-01]</c>.</summary>
    void GoToSettings();

    /// <summary>Meldeanzeige HS-38 (Seitenleiste, Meldezeile); bei offenem Pop-up zurueckgestellt (abgelehnt).</summary>
    Task<bool> OpenMessagesAsync();

    /// <summary>Legt ein Pop-up auf den Popup-Stapel (Dialogdienst). false, wenn der Stapel voll ist.</summary>
    bool TryOpenPopup(PopupViewModelBase popup);

    /// <summary>Schliesst das oberste Pop-up ohne Uebernehmen.</summary>
    bool CloseTopPopup();

    void CloseAllPopups();

    /// <summary>Baut den Brotkruemel neu auf (nach Aenderung dynamischer Segmente).</summary>
    void RefreshBreadcrumb();

    /// <summary>Nach jedem Seitenwechsel, Blaettern und Wechsel von Titel/Brotkruemel.</summary>
    event EventHandler<NavigatedEventArgs>? Navigated;

    /// <summary>Wenn sich der Popup-Stapel aendert.</summary>
    event EventHandler? PopupStackChanged;
}
