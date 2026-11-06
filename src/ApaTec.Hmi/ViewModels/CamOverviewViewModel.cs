using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>HS-26 Nockenuebersicht: Tabelle (11 Zeilen je Seite), Blaettern seitenweise, Nummer antippen oeffnet HS-25 (S26-1 bis S26-3).</summary>
[PageKey(PageKeys.CamOverview)]
public sealed partial class CamOverviewViewModel : PageViewModelBase
{
    /// <summary>Die Seite scrollt selbst und fuellt den Inhaltsbereich (S-01).</summary>
    public override bool FillsContentArea => true;

    /// <summary>Zeilen je Seite (Annahme S26-1).</summary>
    public const int RowsPerPage = 11;

    private readonly ICamService _service;
    private readonly INavigationService? _navigation;
    private readonly ILocalizationService _localization;
    private readonly FunctionBarItem _previousItem = new();
    private readonly FunctionBarItem _nextItem = new();
    private List<CamRow> _all = new();

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(PositionText))]
    [NotifyCanExecuteChangedFor(nameof(PreviousPageCommand), nameof(NextPageCommand))]
    private int _pageIndex;

    [ObservableProperty]
    private IReadOnlyList<CamRow> _rows = Array.Empty<CamRow>();

    [ObservableProperty]
    private int? _selectedNumber;

    public CamOverviewViewModel()
        : this(new DummyCamService(), null, LocalizationService.Instance)
    {
    }

    public CamOverviewViewModel(ICamService service, INavigationService? navigation, ILocalizationService localization)
    {
        _service = service;
        _navigation = navigation;
        _localization = localization;
        _previousItem.Label = localization.GetString("HS26_Bar_Previous");
        _previousItem.Kind = FunctionBarItemKind.Paging;
        _previousItem.Command = PreviousPageCommand;
        _nextItem.Label = localization.GetString("HS26_Bar_Next");
        _nextItem.Kind = FunctionBarItemKind.Paging;
        _nextItem.Command = NextPageCommand;
        FunctionBarItems.Add(_previousItem);
        FunctionBarItems.Add(_nextItem);
        LoadAll();
        ShowPage(0);
    }

    public int PageCount => Math.Max(1, (_all.Count + RowsPerPage - 1) / RowsPerPage);

    public string PositionText => _localization.Format("HS26_Position_Text", PageIndex + 1, PageCount);

    public override void OnNavigatedTo(object? parameter)
    {
        LoadAll();
        var number = (parameter as NavigationParameters)?.Get<int?>("camNumber");
        var index = number is { } wanted ? _all.FindIndex(c => c.Number == wanted) : -1;
        SelectedNumber = index >= 0 ? number : null;
        ShowPage(index >= 0 ? index / RowsPerPage : 0);
    }

    private void LoadAll()
    {
        _all = _service.GetOverview()
            .Select(c => new CamRow { Number = c.Number, Name = c.Name, StartAngle = c.StartAngle, EndAngle = c.EndAngle, IsActive = c.IsActive })
            .ToList();
        OnPropertyChanged(nameof(PageCount));
    }

    private void ShowPage(int index)
    {
        PageIndex = Math.Clamp(index, 0, PageCount - 1);
        Rows = _all.Skip(PageIndex * RowsPerPage).Take(RowsPerPage).ToList();
        _previousItem.IsEnabled = PageIndex > 0;
        _nextItem.IsEnabled = PageIndex < PageCount - 1;
    }

    [RelayCommand(CanExecute = nameof(CanGoPrevious))]
    private void PreviousPage() => ShowPage(PageIndex - 1);

    [RelayCommand(CanExecute = nameof(CanGoNext))]
    private void NextPage() => ShowPage(PageIndex + 1);

    private bool CanGoPrevious() => PageIndex > 0;

    private bool CanGoNext() => PageIndex < PageCount - 1;

    /// <summary>Parameter: Nockennummer; oeffnet HS-25 (Verlauf wird gekuerzt, kein Schleifenverlauf).</summary>
    [RelayCommand]
    private async Task SelectCamAsync(int number)
    {
        SelectedNumber = number;
        if (_navigation is not null)
        {
            await _navigation.NavigateToAsync(PageKeys.Cams, new NavigationParameters("camNumber", number));
        }
    }
}
