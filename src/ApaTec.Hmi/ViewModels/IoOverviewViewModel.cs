using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// HS-33 EA-Uebersicht: Kachelraster 4 x 2 mit den EA-Schaltflaechen (Eingaenge/Ausgaenge S1, S300, S500; restliche Zellen "Reserviert") und Taste "Suchen".
/// Reine Anzeige und Navigation: eine Schaltflaeche oeffnet HS-34 mit <c>cardGroup</c> und der ersten Karte (A-39), nichts wird geschaltet.
/// </summary>
[PageKey(PageKeys.IoOverview)]
public sealed partial class IoOverviewViewModel : PageViewModelBase
{
    private const int GridColumns = 4;
    private const int MinRows = 2;

    private readonly INavigationService _navigation;
    private readonly IDialogService _dialogs;
    private readonly IEquipmentSearchService _search;
    private readonly ILocalizationService _localization;
    private readonly IMessageService? _messages;

    public IoOverviewViewModel(INavigationService navigation, IDialogService dialogs, IIoService io, IEquipmentSearchService search, ILocalizationService localization, IMessageService? messages = null)
    {
        _messages = messages;
        _navigation = navigation;
        _dialogs = dialogs;
        _search = search;
        _localization = localization;

        var groups = io.GetCardGroups();
        var cells = Math.Max(MinRows, (groups.Count + GridColumns - 1) / GridColumns) * GridColumns;
        var tiles = groups
            .Select(group => new TileItem { Label = IoDisplayViewModel.GroupLabel(_localization, group.GroupId), TargetPageId = group.GroupId })
            .ToList();
        while (tiles.Count < cells)
        {
            tiles.Add(new TileItem { IsEmpty = true });
        }

        Tiles = tiles;
        RowCount = cells / GridColumns;
        FunctionBarItems.Add(new FunctionBarItem { Label = _localization.GetString("HS30_Search_Label"), Command = SearchCommand });
    }

    /// <summary>Entwurfsmodus mit Dummy-Diensten.</summary>
    public IoOverviewViewModel()
        : this(null!, null!, new DummyIoService(), null!, LocalizationService.Instance)
    {
    }

    public IReadOnlyList<TileItem> Tiles { get; }

    public int ColumnCount => GridColumns;

    public int RowCount { get; }

    [RelayCommand]
    private async Task OpenCardGroupAsync(TileItem? tile)
    {
        if (tile is { IsEmpty: true })
        {
            _messages?.ShowHint(_localization.GetString("HS33_Empty_Hint"));
            return;
        }

        if (tile is null || tile.TargetPageId is not { } cardGroup)
        {
            return;
        }

        await _navigation.NavigateToAsync(PageKeys.IoDisplay, IoDisplayViewModel.Parameters(cardGroup, 0));
    }

    [RelayCommand]
    private async Task SearchAsync()
    {
        var request = HandbetriebSupport.BuildRequest(
            _localization.GetString("HS33_SearchEquipment_Title"),
            _localization.GetString("HS30_SearchPlaceholder"),
            _search.GetIoEntries(),
            entry => entry.ItemId);
        if (await HandbetriebSupport.ShowSearchAsync(_dialogs, request) is { } hit)
        {
            await _navigation.NavigateToAsync(PageKeys.IoDisplay, IoDisplayViewModel.Parameters(hit.GroupId, hit.ItemIndex));
        }
    }
}
