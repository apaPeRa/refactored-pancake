using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
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
    private readonly ILocalizationService _loc;
    private bool _subscribed;

    [ObservableProperty]
    private IReadOnlyList<TileItem> _tiles = Array.Empty<TileItem>();

    public ScalesViewModel(INavigationService? navigation, IMessageService? messages, ILocalizationService loc)
    {
        _navigation = navigation;
        _messages = messages;
        _loc = loc;
        Tiles = CreateTiles();
    }

    // Beschriftungen und Grund neu aufbauen, wenn die Sprache wechselt (nur solange die Seite offen ist).
    public override void OnNavigatedTo(object? parameter)
    {
        if (!_subscribed)
        {
            _subscribed = true;
            _loc.CultureChanged += OnCultureChanged;
        }

        Tiles = CreateTiles();
    }

    public override void OnNavigatedFrom()
    {
        if (_subscribed)
        {
            _subscribed = false;
            _loc.CultureChanged -= OnCultureChanged;
        }
    }

    private void OnCultureChanged(object? sender, EventArgs e) => Tiles = CreateTiles();

    private IReadOnlyList<TileItem> CreateTiles() => new[]
    {
        new TileItem { Label = _loc.GetString("Nav_CheckWeigher_Crumb"), TargetPageId = PageKeys.CheckWeigher },
        new TileItem { Label = _loc.GetString("HS42_FinalCheckWeigher_Label"), IsDisabled = true, DisabledReason = _loc.GetString("HS42_FinalCheckWeigher_Reason") },
        new TileItem { Label = _loc.GetString("Nav_ScaleCalibration_Crumb"), TargetPageId = PageKeys.ScaleCalibration },
    };

    /// <summary>Entwurfsmodus (DesignData): keine Navigation, Texte aus den Ressourcen.</summary>
    public ScalesViewModel()
        : this(null, null, LocalizationService.Instance)
    {
    }

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
