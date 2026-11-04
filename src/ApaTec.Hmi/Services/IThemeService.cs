namespace ApaTec.Hmi.Services;

/// <summary>Hell- oder Dunkelthema (Designsystem.md 8).</summary>
public enum ThemeMode
{
    Light,
    Dark,
}

/// <summary>Schaltet das Thema zur Laufzeit um, indem das Theme-ResourceDictionary ausgetauscht wird.</summary>
public interface IThemeService
{
    ThemeMode Current { get; }

    void SetTheme(ThemeMode mode);

    void Toggle();

    event EventHandler<ThemeMode>? ThemeChanged;
}
