using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// HS-40 Zufuehrungen (Zwischenseite, Annahme A-33): Kachelzeile Papier (HS-05), Karton (HS-06), Heissleim (HS-07); Funktionsleiste leer.
/// Navigation aendert keinen Maschinenzustand.
/// </summary>
[PageKey(PageKeys.Feeders)]
public sealed partial class FeedersViewModel : PageViewModelBase
{
    private readonly INavigationService? _navigation;
    private readonly ILocalizationService _localization;
    private bool _subscribed;

    [ObservableProperty]
    private IReadOnlyList<TileItem> _tiles = Array.Empty<TileItem>();

    /// <summary>Entwurfsmodus: Kacheln ohne Navigation.</summary>
    public FeedersViewModel()
        : this(null, LocalizationService.Instance)
    {
    }

    public FeedersViewModel(INavigationService? navigation, ILocalizationService localization)
    {
        _navigation = navigation;
        _localization = localization;
        Tiles = CreateTiles();
    }

    public override void OnNavigatedTo(object? parameter)
    {
        if (!_subscribed)
        {
            _subscribed = true;
            _localization.CultureChanged += OnCultureChanged;
        }

        Tiles = CreateTiles();
    }

    public override void OnNavigatedFrom()
    {
        if (_subscribed)
        {
            _subscribed = false;
            _localization.CultureChanged -= OnCultureChanged;
        }
    }

    [RelayCommand]
    private async Task OpenTileAsync(TileItem? tile)
    {
        if (tile?.TargetPageId is { } target && _navigation is not null)
        {
            await _navigation.NavigateToAsync(target);
        }
    }

    private IReadOnlyList<TileItem> CreateTiles() => new[]
    {
        new TileItem { Label = _localization.GetString("HS40_Tile_Paper_Label"), TargetPageId = PageKeys.FeederPaper },
        new TileItem { Label = _localization.GetString("HS40_Tile_Carton_Label"), TargetPageId = PageKeys.FeederCarton },
        new TileItem { Label = _localization.GetString("HS40_Tile_HotGlue_Label"), TargetPageId = PageKeys.HotGlueNordson },
    };

    private void OnCultureChanged(object? sender, EventArgs e) => Tiles = CreateTiles();
}
