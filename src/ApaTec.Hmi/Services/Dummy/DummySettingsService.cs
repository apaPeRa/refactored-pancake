namespace ApaTec.Hmi.Services.Dummy;

/// <summary>Dummy-Einstellungen im Speicher (keine Persistenz).</summary>
[DummyService]
public sealed class DummySettingsService : ISettingsService
{
    public ThemeMode Theme { get; set; } = ThemeMode.Light;

    public string Language { get; set; } = "de-DE";

    public int ScreenCleaningSeconds { get; set; } = 30;
}
