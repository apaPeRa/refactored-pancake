using ApaTec.Hmi.Models;
using ApaTec.Hmi.Services;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// Gemeinsame Dienste und Berechtigungsablauf der Heissleimseiten (HS-07 bis HS-10). Dienste ausser <see cref="Service"/> duerfen im Entwurfsmodus null sein.
/// </summary>
public sealed class HotGlueEditContext
{
    /// <summary>Mindestrolle fuer Eingaben (Dummy, A-41, OP-25).</summary>
    public const UserRole RequiredRole = UserRole.Technician;

    public HotGlueEditContext(IHotGlueService service, IDialogService? dialogs, IUserSession? session, IMessageService? messages, ILocalizationService localization)
    {
        Service = service;
        Dialogs = dialogs;
        Session = session;
        Messages = messages;
        Localization = localization;
    }

    public IHotGlueService Service { get; }

    public IDialogService? Dialogs { get; }

    public IUserSession? Session { get; }

    public IMessageService? Messages { get; }

    public ILocalizationService Localization { get; }

    public bool IsAuthorized => Session?.HasRole(RequiredRole) ?? true;

    /// <summary>Prueft die Berechtigung; ohne Rolle erscheint der Hinweis in der Meldezeile und die Anmeldung wird angefordert. true = Aktion darf weiterlaufen.</summary>
    public async Task<bool> EnsureAuthorizedAsync()
    {
        if (IsAuthorized)
        {
            return true;
        }

        Messages?.ShowHint(Localization.Format("Msg_PermissionRequired", Localization.GetString("Role_" + RequiredRole)));
        return Session is not null && await Session.RequestRoleAsync(RequiredRole);
    }
}
