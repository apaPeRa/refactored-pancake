using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// HS-03 Maschinengeschwindigkeit (Pop-up): fuenf Eingabefelder. Das Antippen oeffnet das Eingabe-Pop-up (HM-13, <see cref="DialogKeys.Input"/>) ueber dem Pop-up.
/// Parameter des Eingabe-Pop-ups als <see cref="NavigationParameters"/>: title, currentValue, unit, minimum, maximum, decimals; Ergebnis: double.
/// </summary>
[PageKey(PageKeys.MachineSpeed)]
public sealed partial class MachineSpeedViewModel : PopupViewModelBase
{
    private const UserRole FieldRole = UserRole.Technician;

    private readonly IMachineSpeedService _speeds;
    private readonly IUserSession _session;
    private readonly IMessageService _messages;
    private readonly IDialogService _dialogs;
    private readonly ILocalizationService _loc;
    private bool _subscribed;

    public MachineSpeedViewModel(
        IMachineSpeedService speeds,
        IUserSession session,
        IMessageService messages,
        IDialogService dialogs,
        ILocalizationService localization)
    {
        _speeds = speeds;
        _session = session;
        _messages = messages;
        _dialogs = dialogs;
        _loc = localization;

        // Reihenfolge der Referenz: Maximum, Schnell, Langsam, Tippen, Minimum.
        Fields = new[]
        {
            new MachineSpeedField(MachineSpeedKind.Maximum, requiresPermission: true),
            new MachineSpeedField(MachineSpeedKind.Fast, requiresPermission: false),
            new MachineSpeedField(MachineSpeedKind.Slow, requiresPermission: false),
            new MachineSpeedField(MachineSpeedKind.Jog, requiresPermission: true),
            new MachineSpeedField(MachineSpeedKind.Minimum, requiresPermission: true),
        };
        Refresh();
    }

    /// <summary>Entwurfsmodus: Dummy-Dienst, ohne Benutzer, Meldungen und Dialoge.</summary>
    public MachineSpeedViewModel()
        : this(new DummyMachineSpeedService(), null!, null!, null!, LocalizationService.Instance)
    {
    }

    public IReadOnlyList<MachineSpeedField> Fields { get; }

    public override void OnOpened(object? parameter)
    {
        if (!_subscribed)
        {
            _subscribed = true;
            _speeds.Changed += OnChanged;
            _session.SessionChanged += OnChanged;
            Closed += OnClosed;
        }

        Refresh();
    }

    private void OnClosed(object? sender, PopupClosedEventArgs e)
    {
        _speeds.Changed -= OnChanged;
        _session.SessionChanged -= OnChanged;
        Closed -= OnClosed;
        _subscribed = false;
    }

    private void OnChanged(object? sender, EventArgs e) => Refresh();

    private void Refresh()
    {
        var role = _loc.GetString($"HM01_Role_{FieldRole}");
        foreach (var field in Fields)
        {
            field.Name = _loc.GetString($"MachineSpeed_{field.Kind}_Name");
            field.Label = _loc.Format("MachineSpeed_Field_Label", field.Name);
            field.Unit = _loc.GetString("Unit_RevPerMin");
            field.Value = _speeds.GetSpeed(field.Kind);
            field.RequiredRole = role;
            field.IsAuthorized = _session is null || _session.HasRole(FieldRole);
        }
    }

    [RelayCommand]
    private async Task EditAsync(MachineSpeedField field)
    {
        if (field.RequiresPermission && !_session.HasRole(FieldRole))
        {
            // Ohne Rolle: Hinweis und Benutzer-Pop-up; nach der Anmeldung laeuft die Eingabe weiter (S03-3).
            _messages.ShowHint(_loc.Format("Msg_PermissionRequired", field.RequiredRole));
            if (!await _session.RequestRoleAsync(FieldRole))
            {
                return;
            }
        }

        var limits = _speeds.GetLimits(field.Kind);
        var parameter = new NavigationParameters("title", field.Name)
            .With("currentValue", field.Value)
            .With("unit", field.Unit)
            .With("minimum", limits.Minimum)
            .With("maximum", limits.Maximum)
            .With("decimals", 0);
        var result = await _dialogs.ShowAsync<double>(DialogKeys.Input, parameter);
        if (!result.Accepted)
        {
            return;
        }

        field.IsPendingWrite = true;
        field.ErrorText = null;
        var ok = await _speeds.SetSpeedAsync(field.Kind, result.Value);
        field.IsPendingWrite = false;
        Refresh();

        // Schreibfehler: der zuletzt gueltige Wert bleibt, Fehlertext am Feld.
        field.ErrorText = ok ? null : _loc.GetString("MachineSpeed_WriteError_Text");
    }
}
