using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>Dummy-Benutzer "Max Mustermann" (Technician, Design). Eine Rollenanforderung gilt als erfolgreich angemeldet.</summary>
[DummyService]
public sealed class DummyUserSession : IUserSession
{
    public UserInfo Current { get; private set; } = new("Max Mustermann", "MM", UserRole.Technician);

    public event EventHandler? SessionChanged;

    public bool HasRole(UserRole minimum) => Current.Role >= minimum;

    public void SignIn(UserRole role) => SetRole(role);

    public void SignOut() => SetRole(UserRole.Operator);

    public Task<bool> RequestRoleAsync(UserRole minimum)
    {
        if (!HasRole(minimum))
        {
            Current = Current with { Role = minimum };
            SessionChanged?.Invoke(this, EventArgs.Empty);
        }

        return Task.FromResult(true);
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
