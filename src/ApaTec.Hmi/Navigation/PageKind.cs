namespace ApaTec.Hmi.Navigation;

/// <summary>Art einer Seite im Seitenregister (Navigation.md 5.2).</summary>
public enum PageKind
{
    /// <summary>Vollseite mit Rahmen.</summary>
    Page,

    /// <summary>Pop-up (HS-02, HS-03): liegt im Popup-Stapel, nie im Verlauf.</summary>
    Popup,

    /// <summary>Vollbild ohne Rahmen (HS-24); wird nicht im Verlauf gestapelt.</summary>
    Fullscreen,
}
