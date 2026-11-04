using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;

namespace ApaTec.Hmi.ViewModels;

/// <summary>Ergebnis einer Werteingabe: neuer gueltiger Wert, oder Fehlertext (Wert ausserhalb der Grenzen), oder beides null bei Abbruch.</summary>
public readonly record struct FeederEditResult(double? Value, string? ErrorText);

/// <summary>
/// Gemeinsamer Ablauf fuer berechtigungspflichtige Eingaben der Zufuehrungsseiten (Navigation.md 4.1): fehlt die Rolle, zeigt die Meldezeile
/// "Berechtigung erforderlich: &lt;Rolle&gt;" und das Benutzer-Pop-up fordert sie an; danach oeffnet das Eingabe-Pop-up (HM-13) mit Titel, Wert und Grenzen.
/// Dienste duerfen fuer den Entwurfsmodus null sein (dann tut der Ablauf nichts).
/// </summary>
public sealed class FeederValueEditor
{
    /// <summary>Mindestrolle fuer Eingaben (Dummy, A-41, OP-25).</summary>
    public const UserRole RequiredRole = UserRole.Technician;

    private readonly IDialogService? _dialogs;
    private readonly IUserSession? _session;
    private readonly IMessageService? _messages;
    private readonly ILocalizationService _localization;

    public FeederValueEditor(IDialogService? dialogs, IUserSession? session, IMessageService? messages, ILocalizationService localization)
    {
        _dialogs = dialogs;
        _session = session;
        _messages = messages;
        _localization = localization;
    }

    /// <summary>true, wenn der Benutzer die Mindestrolle hat (ohne Sitzung im Entwurfsmodus: true).</summary>
    public bool IsAuthorized => _session?.HasRole(RequiredRole) ?? true;

    /// <summary>Name der Mindestrolle in der Anzeigesprache.</summary>
    public string RequiredRoleText => _localization.GetString("Role_" + RequiredRole);

    /// <summary>Prueft die Berechtigung; ohne Rolle erscheint der Hinweis und die Anmeldung wird angefordert. true = Aktion darf weiterlaufen.</summary>
    public async Task<bool> EnsureAuthorizedAsync()
    {
        if (IsAuthorized)
        {
            return true;
        }

        _messages?.ShowHint(_localization.Format("Msg_PermissionRequired", RequiredRoleText));
        return _session is not null && await _session.RequestRoleAsync(RequiredRole);
    }

    /// <summary>Berechtigung pruefen, Eingabe-Pop-up oeffnen und das Ergebnis gegen die Grenzen pruefen.</summary>
    public async Task<FeederEditResult> RequestValueAsync(
        string title, double? current, string unit, int decimals, FeederLimits limits, string? helpText, Action<bool>? setEditing = null)
    {
        if (_dialogs is null || !await EnsureAuthorizedAsync())
        {
            return default;
        }

        setEditing?.Invoke(true);
        try
        {
            var request = new FeederInputRequest(title, current ?? limits.Minimum, unit, decimals, limits, helpText);
            var result = await _dialogs.ShowAsync<double>(DialogKeys.Input, request);
            if (!result.Accepted)
            {
                return default;
            }

            if (result.Value < limits.Minimum || result.Value > limits.Maximum)
            {
                return new FeederEditResult(null, _localization.Format("Feeder_Error_Range", limits.Minimum, limits.Maximum, unit));
            }

            return new FeederEditResult(result.Value, null);
        }
        finally
        {
            setEditing?.Invoke(false);
        }
    }
}
