namespace ApaTec.Hmi.Services;

/// <summary>Gespeicherte Benutzereinstellungen (Thema, Sprache, Reinigungsdauer; A-30, A-77).</summary>
public interface ISettingsService
{
    ThemeMode Theme { get; set; }

    /// <summary>Kulturname, z. B. <c>de-DE</c>.</summary>
    string Language { get; set; }

    /// <summary>Dauer des Bildschirm-Reinigens (HS-24) in Sekunden.</summary>
    int ScreenCleaningSeconds { get; set; }
}
