using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// Such-Pop-up (HM-38) fuer HS-30, HS-31 und HS-33. Parameter: <see cref="SearchRequest"/>. Gefiltert wird bei jeder Eingabe nach Teilzeichenfolge in Kennzeichnung und
/// Bezeichnung (ohne Gross-/Kleinschreibung); die Liste zeigt ein Fenster von <see cref="PageSize"/> Treffern, die Scrolltasten verschieben es.
/// Ergebnis bei Treffer: der gewaehlte <see cref="SearchHit"/>.
/// </summary>
[DialogKey(DialogKeys.Search)]
public sealed partial class SearchPopupViewModel : PopupViewModelBase
{
    /// <summary>Sichtbare Trefferzeilen (Dummy, Zeilenhoehe Size.Touch.Min).</summary>
    public const int PageSize = 6;

    private IReadOnlyList<SearchHit> _matches = Array.Empty<SearchHit>();
    private int _offset;

    [ObservableProperty]
    private string _searchText = string.Empty;

    [ObservableProperty]
    private string _placeholder = string.Empty;

    [ObservableProperty]
    private IReadOnlyList<SearchHit> _items = Array.Empty<SearchHit>();

    [ObservableProperty]
    private IReadOnlyList<SearchHit>? _filteredItems = Array.Empty<SearchHit>();

    [ObservableProperty]
    private SearchHit? _selectedHit;

    private readonly IDialogService? _dialogs;

    /// <summary>Entwurfsmodus und Tests: ohne Dialogdienst (die Texteingabe ueber HM-13 entfaellt).</summary>
    public SearchPopupViewModel()
        : this(null)
    {
    }

    public SearchPopupViewModel(IDialogService? dialogs)
    {
        _dialogs = dialogs;
        Title = LocalizationService.Instance.GetString("Dialog_Design_Search_Title");
        Placeholder = LocalizationService.Instance.GetString("Dialog_Design_Search_Placeholder");
        Items = new[]
        {
            new SearchHit { Identifier = "2MA1", Description = LocalizationService.Instance.GetString("Dialog_Design_Search_Hit1"), Group = LocalizationService.Instance.GetString("Dialog_Design_Search_Group2") },
            new SearchHit { Identifier = "2MA2", Description = LocalizationService.Instance.GetString("Dialog_Design_Search_Hit2"), Group = LocalizationService.Instance.GetString("Dialog_Design_Search_Group2") },
            new SearchHit { Identifier = "20MA1", Description = LocalizationService.Instance.GetString("Dialog_Design_Search_Hit3"), Group = LocalizationService.Instance.GetString("Dialog_Design_Search_Group20") },
        };
        ApplyFilter();
    }

    public override void OnOpened(object? parameter)
    {
        if (parameter is SearchRequest request)
        {
            Title = request.Title;
            Placeholder = request.Placeholder;
            Items = request.Items;
        }

        SearchText = string.Empty;
        ApplyFilter();
    }

    partial void OnSearchTextChanged(string value) => ApplyFilter();

    [RelayCommand]
    private void SelectHit(SearchHit? hit)
    {
        if (hit is null)
        {
            return;
        }

        SelectedHit = hit;
        Close(true, hit);
    }

    /// <summary>Antippen der Suchzeile: Bildschirmtastatur ueber das Eingabe-Pop-up HM-13, Eingabeart Text (HM-38).</summary>
    [RelayCommand]
    private async Task EditTextAsync()
    {
        if (_dialogs is null)
        {
            return;
        }

        var result = await _dialogs.ShowAsync<string>(DialogKeys.Input, new InputRequest(Title, null, Kind: InputKind.Text, Text: SearchText));
        if (result.Accepted && result.Value is { } text)
        {
            SearchText = text;
        }
    }

    [RelayCommand]
    private void ClearText() => SearchText = string.Empty;

    [RelayCommand(CanExecute = nameof(CanScrollUp))]
    private void ScrollUp()
    {
        _offset = Math.Max(0, _offset - PageSize);
        UpdateWindow();
    }

    [RelayCommand(CanExecute = nameof(CanScrollDown))]
    private void ScrollDown()
    {
        _offset = Math.Min(Math.Max(0, _matches.Count - PageSize), _offset + PageSize);
        UpdateWindow();
    }

    private bool CanScrollUp() => _offset > 0;

    private bool CanScrollDown() => _offset + PageSize < _matches.Count;

    private void ApplyFilter()
    {
        var text = SearchText.Trim();
        _matches = text.Length == 0
            ? Items
            : Items.Where(hit => Contains(hit.Identifier, text) || Contains(hit.Description, text)).ToList();
        _offset = 0;
        UpdateWindow();
    }

    private static bool Contains(string value, string text) => value.Contains(text, StringComparison.CurrentCultureIgnoreCase);

    private void UpdateWindow()
    {
        FilteredItems = _matches.Skip(_offset).Take(PageSize).ToList();
        ScrollUpCommand.NotifyCanExecuteChanged();
        ScrollDownCommand.NotifyCanExecuteChanged();
    }
}
