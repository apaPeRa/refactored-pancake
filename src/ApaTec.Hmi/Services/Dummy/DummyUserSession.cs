using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using Microsoft.Extensions.DependencyInjection;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>
/// Dummy-Benutzer "Max Mustermann", startet als angemeldeter Bediener (Operator, A-93), damit der Rollenablauf sichtbar wird.
/// Eine Rollenanforderung oeffnet das Benutzer-Pop-up (Parameter <c>requiredRole</c>, Hinweis "Berechtigung erforderlich"); der Aufrufer
/// laeuft nach der Anmeldung weiter (Dummy: Anmeldung durch Auswahl der Rolle, ohne Kennwort, A-41).
/// </summary>
[DummyService]
public sealed class DummyUserSession : IUserSession
{
    private readonly IServiceProvider? _services;

    /// <summary>Entwurfsmodus und Tests: ohne Pop-up, Rollenanforderung wird nur geprueft.</summary>
    public DummyUserSession()
    {
    }

    public DummyUserSession(IServiceProvider services)
    {
        _services = services;
    }

    public UserInfo Current { get; private set; } = new("Max Mustermann", "MM", UserRole.Operator);

    public event EventHandler? SessionChanged;

    public bool HasRole(UserRole minimum) => Current.Role >= minimum;

    public void SignIn(UserRole role) => SetRole(role);

    public void SignOut() => SetRole(UserRole.Operator);

    public async Task<bool> RequestRoleAsync(UserRole minimum)
    {
        if (HasRole(minimum))
        {
            return true;
        }

        // IDialogService erst hier aufloesen: Dialog- und Navigationsdienst haengen selbst von der Sitzung ab (Zyklus).
        if (_services?.GetService<IDialogService>() is not { } dialogs)
        {
            return false;
        }

        await dialogs.ShowAsync<UserInfo>(DialogKeys.User, new NavigationParameters("requiredRole", minimum));
        return HasRole(minimum);
    }

    private void SetRole(UserRole role)
    {
        if (Current.Role != role)
        {
            Current = Current with { Role = role };
            SessionChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
