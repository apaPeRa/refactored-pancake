using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// HS-42 Waagen (Zwischenseite, Einstellung > Waagen): drei Kacheln Kontrollwaage (HS-13), Endkontrollwaage (deaktiviert, ohne Ziel, OP-24) und
/// Waagen kalibrieren (HS-27). Die Seite hat keine Parameter, Anzeigen oder Funktionsleistentasten.
/// </summary>
[PageKey(PageKeys.Scales)]
public sealed partial class ScalesViewModel : PageViewModelBase
{
    private readonly INavigationService? _navigation;
    private readonly IMessageService? _messages;

    public ScalesViewModel(INavigationService? navigation, IMessageService? messages, ILocalizationService loc)
    {
        _navigation = navigation;
        _messages = messages;

        var reason = loc.GetString("HS42_FinalCheckWeigher_Reason");
        Tiles = new[]
        {
            new TileItem { Label = loc.GetString("Nav_CheckWeigher_Crumb"), TargetPageId = PageKeys.CheckWeigher },
            new TileItem { Label = loc.GetString("HS42_FinalCheckWeigher_Label"), IsDisabled = true, DisabledReason = reason },
            new TileItem { Label = loc.GetString("Nav_ScaleCalibration_Crumb"), TargetPageId = PageKeys.ScaleCalibration },
        };
    }

    /// <summary>Entwurfsmodus (DesignData): keine Navigation, Texte aus den Ressourcen.</summary>
    public ScalesViewModel()
        : this(null, null, LocalizationService.Instance)
    {
    }

    /// <summary>Kacheln in der Reihenfolge des Navigationsbaums (HM-16).</summary>
    public IReadOnlyList<TileItem> Tiles { get; }

    [RelayCommand]
    private async Task OpenTileAsync(TileItem? tile)
    {
        if (tile is null)
        {
            return;
        }

        if (tile.IsDisabled)
        {
            // Deaktivierte Kachel: kein Seitenwechsel, kein Verlaufseintrag; der Grund erscheint in der Meldezeile (A-28).
            if (!string.IsNullOrEmpty(tile.DisabledReason))
            {
                _messages?.ShowHint(tile.DisabledReason);
            }

            return;
        }

        if (_navigation is null || tile.TargetPageId is null)
        {
            return;
        }

        var parameter = tile.TargetPageId == PageKeys.ScaleCalibration ? new NavigationParameters("scaleIndex", 1) : null;
        await _navigation.NavigateToAsync(tile.TargetPageId, parameter);
    }
}
