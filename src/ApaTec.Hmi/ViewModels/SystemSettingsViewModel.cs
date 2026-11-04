using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>HS-35 Systemeinstellungen: Kachelmenue (3 x 3) mit Systemaktionen und Navigationszielen, Taste "Lampentest" in der Funktionsleiste.</summary>
[PageKey(PageKeys.SystemSettings)]
public sealed partial class SystemSettingsViewModel : PageViewModelBase
{
    /// <summary>Rollenstufe der Schluessel-Kacheln (Dummy, OP-25).</summary>
    private const UserRole ActionRole = UserRole.Technician;

    private readonly ISystemControlService _system;
    private readonly INavigationService _navigation;
    private readonly IDialogService _dialogs;
    private readonly IUserSession _session;
    private readonly IMessageService _messages;
    private readonly ILocalizationService _text;
    private readonly Dictionary<TileItem, Func<Task>> _actions = new();

    public SystemSettingsViewModel(
        ISystemControlService system,
        INavigationService navigation,
        IDialogService dialogs,
        IUserSession session,
        IMessageService messages,
        ILocalizationService text)
    {
        _system = system;
        _navigation = navigation;
        _dialogs = dialogs;
        _session = session;
        _messages = messages;
        _text = text;

        var quit = ActionTile("HS35_Tile_Quit_Label", warning: true);
        var restart = ActionTile("HS35_Tile_Restart_Label", warning: true);
        var shutdown = ActionTile("HS35_Tile_Shutdown_Label", warning: true);
        var taskManager = ActionTile("HS35_Tile_TaskManager_Label", warning: false);
        var minimize = ActionTile("HS35_Tile_Minimize_Label", warning: false);
        _actions[quit] = () => ConfirmedAsync("HS35_Tile_Quit_Label", "HS35_Quit_Message", _system.QuitUserInterfaceAsync);
        _actions[restart] = () => ConfirmedAsync("HS35_Tile_Restart_Label", "HS35_Restart_Message", _system.RestartControlAsync);
        _actions[shutdown] = () => ConfirmedAsync("HS35_Tile_Shutdown_Label", "HS35_Shutdown_Message", _system.ShutDownControlAsync);
        _actions[taskManager] = () => ExecuteAsync(_system.OpenTaskManagerAsync);
        _actions[minimize] = () => ExecuteAsync(_system.MinimizeUserInterfaceAsync);

        SystemActionTiles = new[] { quit, restart, shutdown };
        UtilityTiles = new[] { taskManager, minimize, new TileItem { IsEmpty = true } };
        NavigationTiles = new[]
        {
            new TileItem { Label = _text.GetString("HS35_Tile_Service_Label"), TargetPageId = PageKeys.Service, RequiresPermission = true },
            new TileItem { Label = _text.GetString("HS35_Tile_Archive_Label"), TargetPageId = PageKeys.MessageArchive },
            new TileItem { Label = _text.GetString("HS35_Tile_SystemInfo_Label"), TargetPageId = PageKeys.SystemInfo },
        };

        UpdateAuthorization();
        FunctionBarItems.Add(new FunctionBarItem
        {
            Label = _text.GetString("HS35_LampTest_Label"),
            Kind = FunctionBarItemKind.Action,
            Command = LampTestCommand,
        });
    }

    /// <summary>Entwurfsmodus: Dummy-Dienste, ohne Navigation und Pop-ups.</summary>
    public SystemSettingsViewModel()
        : this(new DummySystemControlService(), null!, null!, new DummyUserSession(), new DummyMessageService(), LocalizationService.Instance)
    {
    }

    public override void OnNavigatedTo(object? parameter)
    {
        _session.SessionChanged -= OnSessionChanged;
        _session.SessionChanged += OnSessionChanged;
        UpdateAuthorization();
    }

    public override void OnNavigatedFrom() => _session.SessionChanged -= OnSessionChanged;

    // Kacheln ohne ausreichende Rolle tragen das Schloss statt des Schluessels (HS-35-P14).
    private void UpdateAuthorization()
    {
        var authorized = _session.HasRole(ActionRole);
        foreach (var tile in SystemActionTiles.Concat(UtilityTiles).Concat(NavigationTiles))
        {
            if (tile.RequiresPermission)
            {
                tile.IsAuthorized = authorized;
            }
        }
    }

    private void OnSessionChanged(object? sender, EventArgs e) => UpdateAuthorization();

    /// <summary>Zeile 1: Bedienung beenden, Steuerung neu starten, Steuerung ausschalten (Warnaktionen).</summary>
    public IReadOnlyList<TileItem> SystemActionTiles { get; }

    /// <summary>Zeile 2: Taskmanager, Bedienung minimieren, reservierter Platz.</summary>
    public IReadOnlyList<TileItem> UtilityTiles { get; }

    /// <summary>Zeile 3: Service, Meldearchiv, System- und Antriebsinfo (Navigation).</summary>
    public IReadOnlyList<TileItem> NavigationTiles { get; }

    /// <summary>Parameter: das angetippte <see cref="TileItem"/>.</summary>
    [RelayCommand]
    private async Task ActivateTileAsync(TileItem? tile)
    {
        if (tile is null || tile.IsEmpty)
        {
            return;
        }

        if (tile.TargetPageId is not null)
        {
            // Rollenpruefung des Seitenzugangs (Service: Technik) uebernimmt der Navigationsdienst; der Grund erscheint vorab in der Meldezeile.
            if (!tile.IsAuthorized)
            {
                _messages.ShowHint(_text.Format("Msg_PermissionRequired", _text.GetString($"Role_{ActionRole}")));
            }

            await _navigation.NavigateToAsync(tile.TargetPageId);
            return;
        }

        if (_actions.TryGetValue(tile, out var action) && await EnsureRoleAsync(ActionRole))
        {
            await action();
        }
    }

    [RelayCommand]
    private async Task LampTestAsync()
    {
        await ExecuteAsync(_system.RunLampTestAsync);
        _messages.ShowHint(_text.GetString("HS35_LampTest_Hint"));
    }

    private TileItem ActionTile(string labelKey, bool warning) =>
        new() { Label = _text.GetString(labelKey), RequiresPermission = true, IsWarning = warning };

    private async Task ConfirmedAsync(string titleKey, string messageKey, Func<Task<bool>> operation)
    {
        var answer = await _dialogs.ShowAsync<bool>(
            DialogKeys.Confirmation,
            SystemDialogParameters.Confirmation(
                _text.GetString(titleKey),
                _text.GetString(messageKey),
                _text.GetString("HM14_Confirm_Label"),
                _text.GetString("Popup_Cancel_Label")));
        if (answer.Accepted)
        {
            await ExecuteAsync(operation);
        }
    }

    private async Task ExecuteAsync(Func<Task<bool>> operation)
    {
        if (!await operation())
        {
            _messages.ShowHint(_text.GetString("HS35_Error_ActionFailed"));
        }
    }

    private async Task<bool> EnsureRoleAsync(UserRole role)
    {
        if (_session.HasRole(role))
        {
            return true;
        }

        _messages.ShowHint(_text.Format("Msg_PermissionRequired", _text.GetString($"Role_{role}")));
        return await _session.RequestRoleAsync(role);
    }
}
