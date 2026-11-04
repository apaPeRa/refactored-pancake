using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>Platzhalter-Rezeptliste (OP-01, S01-13); der Name entspricht dem Beispiel "Rezept 1" aus HM-12.</summary>
[DummyService]
public sealed class DummyRecipeService : IRecipeService
{
    public string CurrentRecipe { get; private set; } = "Rezept 1";

    public IReadOnlyList<ProductionRecipe> Recipes { get; } = new ProductionRecipe[]
    {
        new("Rezept 1"),
        new("Rezept 2"),
        new("Rezept 3"),
    };

    public event EventHandler? Changed;

    public bool Select(string name)
    {
        if (!Recipes.Any(r => r.Name == name))
        {
            return false;
        }

        CurrentRecipe = name;
        Changed?.Invoke(this, EventArgs.Empty);
        return true;
    }
}
