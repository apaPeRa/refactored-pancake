using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// Gemeinsame Bedienlogik der Dosierer-Seiten: Berechtigung (Dummy-Rolle, OP-04, OP-25), Eingabe-Pop-up (HM-13 ueber <see cref="IDialogService"/>)
/// und Hinweise in der Meldezeile (A-28). Keine UI-Referenzen; Dienste duerfen im Entwurfsmodus fehlen.
/// </summary>
public sealed class DosingInteraction
{
    /// <summary>Dummy-Rolle fuer alle Felder und Tasten mit Schluesselsymbol.</summary>
    public const UserRole RequiredRole = UserRole.Technician;

    private readonly IDoserService _doser;
    private readonly IUserSession? _session;
    private readonly IDialogService? _dialogs;
    private readonly IMessageService? _messages;
    private readonly ILocalizationService _localization;

    public DosingInteraction(IDoserService doser, IUserSession? session, IDialogService? dialogs, IMessageService? messages, ILocalizationService localization)
    {
        _doser = doser;
        _session = session;
        _dialogs = dialogs;
        _messages = messages;
        _localization = localization;
    }

    public bool IsAuthorized => _session?.HasRole(RequiredRole) ?? true;

    /// <summary>Prueft die Rolle; fehlt sie, erscheint "Berechtigung erforderlich: Rolle" und das Benutzer-Pop-up oeffnet sich. true, wenn die Rolle danach vorhanden ist.</summary>
    public async Task<bool> EnsureAuthorizedAsync()
    {
        if (IsAuthorized || _session is null)
        {
            return true;
        }

        var role = _localization.GetString("Role_" + RequiredRole);
        _messages?.ShowHint(_localization.Format("Msg_PermissionRequired", role));
        return await _session.RequestRoleAsync(RequiredRole);
    }

    /// <summary>Oeffnet das Eingabe-Pop-up fuer ein Feld; null bei fehlender Berechtigung, Abbruch oder fehlendem Dialogdienst.</summary>
    public async Task<double?> RequestValueAsync(DoserField field, string title, double current, string helpKey)
    {
        if (_dialogs is null || !await EnsureAuthorizedAsync())
        {
            return null;
        }

        var request = new DoserInputRequest(title, current, _doser.GetLimits(field), _localization.GetString(helpKey));
        var result = await _dialogs.ShowAsync<double?>(DialogKeys.Input, request);
        return result.Accepted ? result.Value : null;
    }

    /// <summary>Grund einer gesperrten Aktion in der Meldezeile (A-28).</summary>
    public void ShowBlockedHint() => _messages?.ShowHint(_localization.GetString("Dosing_ActionsBlocked_Hint"));
}
