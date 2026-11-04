using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>Die 16 Betriebsfunktionen von HS-01 als Zustandstasten und Umschalter (Konzept.md 6.6).</summary>
public interface IProductionFunctionService
{
    /// <summary>Zustand der Funktion (fuer <see cref="ProductionFunction.Automatic"/> der abgeleitete Sammelzustand).</summary>
    ProductionFunctionStatus GetStatus(ProductionFunction function);

    /// <summary>Funktionen, die "Automatik" erfasst (Dummy: alle ausser Automatik und Schnell, S01-9, konfigurierbar).</summary>
    IReadOnlyList<ProductionFunction> AutomaticFunctions { get; }

    /// <summary>Schaltet eine Funktion; der Zustand ist bis zur Rueckmeldung ausstehend. false = Maschine hat nicht quittiert.</summary>
    Task<bool> SetAsync(ProductionFunction function, bool on);

    /// <summary>"Automatik" bei Teilweise: waehlt alle erfassten Funktionen an und liefert die dadurch neu angewaehlten (S01-14).</summary>
    Task<IReadOnlyList<ProductionFunction>> SelectAllAutomaticAsync();

    /// <summary>Wenn sich ein Zustand aendert (ggf. nicht im UI-Thread).</summary>
    event EventHandler? Changed;
}
