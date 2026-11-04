using System.Globalization;
using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// HS-04 Einstellungen: Kachelmenue (A-36) mit kleiner Kachel "Beleuchtung" (Schnellzugriff), zwei Kachelrastern 2 x 4 und der Funktionsleistentaste "Sprache".
/// Navigation aendert keinen Maschinenzustand; deaktivierte Kacheln nennen ihren Grund in der Meldezeile (A-28).
/// </summary>
[PageKey(PageKeys.Settings)]
public sealed partial class SettingsViewModel : PageViewModelBase
{
    private readonly INavigationService? _navigation;
    private readonly IDialogService? _dialogs;
    private readonly IMessageService? _messages;
    private readonly IProductionFunctionService? _functions;
    private readonly ILocalizationService _localization;
    private readonly FunctionBarItem _languageItem;
    private bool _subscribed;

    [ObservableProperty]
    private IReadOnlyList<TileItem> _quickTiles = Array.Empty<TileItem>();

    [ObservableProperty]
    private IReadOnlyList<TileItem> _plantTiles = Array.Empty<TileItem>();

    [ObservableProperty]
    private IReadOnlyList<TileItem> _systemTiles = Array.Empty<TileItem>();

    /// <summary>Entwurfsmodus: Kacheln ohne Navigation, Dialoge und Dienste.</summary>
    public SettingsViewModel()
        : this(null, null, null, null, LocalizationService.Instance)
    {
    }

    public SettingsViewModel(
        INavigationService? navigation,
        IDialogService? dialogs,
        IMessageService? messages,
        IProductionFunctionService? functions,
        ILocalizationService localization)
    {
        _navigation = navigation;
        _dialogs = dialogs;
        _messages = messages;
        _functions = functions;
        _localization = localization;
        _languageItem = new FunctionBarItem
        {
            IconKey = "Icon.Language",
            Kind = FunctionBarItemKind.Action,
            Command = OpenLanguageCommand,
        };
        FunctionBarItems.Add(_languageItem);
        RefreshTexts();
    }

    public override void OnNavigatedTo(object? parameter)
    {
        if (!_subscribed)
        {
            _subscribed = true;
            _localization.CultureChanged += OnCultureChanged;
        }

        RefreshTexts();
    }

    public override void OnNavigatedFrom()
    {
        if (_subscribed)
        {
            _subscribed = false;
            _localization.CultureChanged -= OnCultureChanged;
        }
    }

    /// <summary>Kachel antippen: Navigation, Aktion (Beleuchtung) oder Grund der deaktivierten Kachel in der Meldezeile.</summary>
    [RelayCommand]
    private async Task OpenTileAsync(TileItem? tile)
    {
        if (tile is null)
        {
            return;
        }

        if (tile.IsDisabled || tile.IsEmpty)
        {
            if (!string.IsNullOrEmpty(tile.DisabledReason))
            {
                _messages?.ShowHint(tile.DisabledReason);
            }

            return;
        }

        if (tile.TargetPageId is { } target)
        {
            if (_navigation is not null)
            {
                await _navigation.NavigateToAsync(target);
            }
        }
        else
        {
            await ToggleLightingAsync();
        }
    }

    /// <summary>Schaltet die Maschinenbeleuchtung (Betriebsfunktion <see cref="ProductionFunction.Lighting"/> aus HS-01); der Zustand wird nicht angezeigt (OP-05).</summary>
    private async Task ToggleLightingAsync()
    {
        if (_functions is null)
        {
            return;
        }

        var status = _functions.GetStatus(ProductionFunction.Lighting);
        await _functions.SetAsync(ProductionFunction.Lighting, !status.IsOn);
    }

    /// <summary>Sprachwahl-Pop-up (Platzhalter, OP-03): bei Uebernehmen wird die gewaehlte Kultur gesetzt.</summary>
    [RelayCommand]
    private async Task OpenLanguageAsync()
    {
        if (_dialogs is null)
        {
            return;
        }

        var result = await _dialogs.ShowAsync<CultureInfo>(DialogKeys.Language);
        if (result.Accepted && result.Value is { } culture)
        {
            _localization.SetCulture(culture);
        }
    }

    private void RefreshTexts()
    {
        _languageItem.Label = _localization.GetString("HS04_Fn_Language_Label");
        QuickTiles = new[]
        {
            new TileItem { Label = _localization.GetString("HS04_Tile_Lighting_Label") },
        };
        PlantTiles = new[]
        {
            Tile("HS04_Tile_Feeders_Label", PageKeys.Feeders, "HS04_Tile_Feeders_Help"),
            Tile("HS04_Tile_ClosingMachine_Label", PageKeys.ClosingMachine, "HS04_Tile_ClosingMachine_Help"),
            Tile("HS04_Tile_Dosers_Label", PageKeys.DoserOverview, "HS04_Tile_Dosers_Help"),
            Tile("HS04_Tile_Heaters_Label", PageKeys.Heaters, "HS04_Tile_Heaters_Help"),
            Tile("HS04_Tile_Regulation_Label", PageKeys.Regulation, "HS04_Tile_Regulation_Help"),
            Tile("HS04_Tile_EncoderSetting_Label", PageKeys.EncoderSetting, "HS04_Tile_EncoderSetting_Help"),
            Tile("HS04_Tile_Scales_Label", PageKeys.Scales, "HS04_Tile_Scales_Help"),
            Tile("HS04_Tile_PackRegister_Label", PageKeys.PackRegister, "HS04_Tile_PackRegister_Help"),
        };
        SystemTiles = new[]
        {
            Tile("HS04_Tile_Cams_Label", PageKeys.Cams, "HS04_Tile_Cams_Help"),
            Tile("HS04_Tile_ManualOperation_Label", PageKeys.ManualSelection, "HS04_Tile_ManualOperation_Help"),
            Tile("HS04_Tile_Statistics_Label", PageKeys.ProductionStatistics, "HS04_Tile_Statistics_Help"),
            new TileItem
            {
                Label = _localization.GetString("HS04_Tile_Devices_Label"),
                IsDisabled = true,
                DisabledReason = _localization.GetString("HS04_Tile_Devices_Reason"),
            },
            new TileItem
            {
                IsEmpty = true,
                DisabledReason = _localization.GetString("HS04_Tile_Reserved_Reason"),
            },
            Tile("HS04_Tile_IoOverview_Label", PageKeys.IoOverview, "HS04_Tile_IoOverview_Help"),
            Tile("HS04_Tile_ScreenCleaning_Label", PageKeys.ScreenCleaning, "HS04_Tile_ScreenCleaning_Help"),
            Tile("HS04_Tile_SystemSettings_Label", PageKeys.SystemSettings, "HS04_Tile_SystemSettings_Help"),
        };
    }

    private TileItem Tile(string labelKey, string target, string helpKey) =>
        new() { Label = _localization.GetString(labelKey), TargetPageId = target, HelpText = _localization.GetString(helpKey) };

    private void OnCultureChanged(object? sender, EventArgs e) => RefreshTexts();
}
