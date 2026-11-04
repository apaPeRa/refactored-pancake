using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// HS-30 Handbetrieb Auswahl: Kachelraster 4 x 4 mit den Gruppentasten GR1 bis GR100 (restliche Zellen "Reserviert") und Taste "Suchen" in der Funktionsleiste.
/// Reines Auswahlmenue: eine Gruppentaste oeffnet HS-31 mit <c>groupId</c>, es wird keine Maschinenfunktion ausgeloest.
/// </summary>
[PageKey(PageKeys.ManualSelection)]
public sealed partial class ManualSelectionViewModel : PageViewModelBase
{
    private const int GridColumns = 4;
    private const int MinRows = 4;

    private readonly INavigationService _navigation;
    private readonly IDialogService _dialogs;
    private readonly IManualOperationService _manual;
    private readonly IEquipmentSearchService _search;
    private readonly ILocalizationService _localization;

    public ManualSelectionViewModel(
        INavigationService navigation, IDialogService dialogs, IManualOperationService manual, IEquipmentSearchService search, ILocalizationService localization)
    {
        _navigation = navigation;
        _dialogs = dialogs;
        _manual = manual;
        _search = search;
        _localization = localization;

        var groups = _manual.GetGroups();
        var cells = Math.Max(MinRows, (groups.Count + GridColumns - 1) / GridColumns) * GridColumns;
        var tiles = groups
            .Select(group => new TileItem { Label = HandbetriebSupport.GroupLabel(_localization, group.GroupId), TargetPageId = group.GroupId })
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
    public ManualSelectionViewModel()
        : this(null!, null!, new DummyManualOperationService(), null!, LocalizationService.Instance)
    {
    }

    public IReadOnlyList<TileItem> Tiles { get; }

    public int ColumnCount => GridColumns;

    public int RowCount { get; }

    [RelayCommand]
    private async Task OpenGroupAsync(TileItem? tile)
    {
        if (tile is null || tile.IsEmpty || tile.TargetPageId is not { } groupId)
        {
            return;
        }

        await _navigation.NavigateToAsync(PageKeys.ManualOperation, new NavigationParameters(ManualOperationViewModel.GroupIdParameter, groupId));
    }

    [RelayCommand]
    private async Task SearchAsync()
    {
        var request = HandbetriebSupport.BuildRequest(
            _localization.GetString("HS30_SearchActor_Title"),
            _localization.GetString("HS30_SearchPlaceholder"),
            _search.GetActorEntries(),
            entry => HandbetriebSupport.GroupLabel(_localization, entry.GroupId));
        if (await HandbetriebSupport.ShowSearchAsync(_dialogs, request) is { } hit)
        {
            await _navigation.NavigateToAsync(
                PageKeys.ManualOperation,
                new NavigationParameters(ManualOperationViewModel.GroupIdParameter, hit.GroupId).With(ManualOperationViewModel.ActorIdParameter, hit.ItemId));
        }
    }
}
