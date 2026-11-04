using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>Rezeptanwahl auf HS-01. Platzhalter ohne Fachlogik (OP-01, S01-13).</summary>
public interface IRecipeService
{
    /// <summary>Name des gewaehlten Rezepts; leer = keines gewaehlt.</summary>
    string CurrentRecipe { get; }

    IReadOnlyList<ProductionRecipe> Recipes { get; }

    /// <summary>Waehlt ein Rezept; false, wenn der Name unbekannt ist.</summary>
    bool Select(string name);

    event EventHandler? Changed;
}
