using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>Angemeldeter Benutzer und Rollenpruefung (Navigation.md 5.2 und 5.4).</summary>
public interface IUserSession
{
    UserInfo Current { get; }

    bool HasRole(UserRole minimum);

    /// <summary>Fordert mindestens die Rolle an (oeffnet das Benutzer-Pop-up); true, wenn die Rolle danach vorhanden ist.</summary>
    Task<bool> RequestRoleAsync(UserRole minimum);

    /// <summary>Meldet den Benutzer mit der Rolle an (Benutzer-Pop-up; Dummy ohne Kennwort, A-41).</summary>
    void SignIn(UserRole role);

    /// <summary>Meldet ab: zurueck auf die niedrigste Rolle (Bediener).</summary>
    void SignOut();

    event EventHandler? SessionChanged;
}
