using System.Collections.ObjectModel;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// Rezeptauswahl-Pop-up (<see cref="DialogKeys.Recipe"/>, Platzhalter OP-01, HS-01): listet <see cref="IRecipeService.Recipes"/>; vorgewaehlt ist der Parameter <c>currentRecipe</c>
/// bzw. das aktuelle Rezept des Dienstes. Ergebnis: Rezeptname (<c>string</c>); der Aufrufer waehlt es mit <see cref="IRecipeService.Select"/>.
/// </summary>
[DialogKey(DialogKeys.Recipe)]
public sealed partial class RecipeDialogViewModel : PopupViewModelBase
{
    private readonly IRecipeService _recipes;

    [ObservableProperty]
    private DialogChoiceItem? _selected;

    public RecipeDialogViewModel()
        : this(new DummyRecipeService(), LocalizationService.Instance)
    {
    }

    public RecipeDialogViewModel(IRecipeService recipes, ILocalizationService localization)
    {
        _recipes = recipes;
        Title = localization.GetString("Dialog_Recipe_Title");
        Load(_recipes.CurrentRecipe);
    }

    public ObservableCollection<DialogChoiceItem> Items { get; } = new();

    public override void OnOpened(object? parameter)
    {
        var current = new DialogParameterReader(parameter).GetString("currentRecipe", "recipe");
        Load(current ?? _recipes.CurrentRecipe);
    }

    protected override object? GetResult() => Selected?.Value;

    protected override bool CanAccept() => Selected is not null;

    partial void OnSelectedChanged(DialogChoiceItem? value) => AcceptCommand.NotifyCanExecuteChanged();

    [RelayCommand]
    private void Choose(DialogChoiceItem? item)
    {
        if (item is null)
        {
            return;
        }

        foreach (var other in Items)
        {
            other.IsSelected = ReferenceEquals(other, item);
        }

        Selected = item;
    }

    private void Load(string current)
    {
        Items.Clear();
        Selected = null;
        foreach (var recipe in _recipes.Recipes)
        {
            var item = new DialogChoiceItem(recipe.Name, recipe.Name, recipe.Name == current);
            Items.Add(item);
            if (item.IsSelected)
            {
                Selected = item;
            }
        }
    }
}
