using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>
/// Beispielzustand der 16 Betriebsfunktionen (DS-01: die Umschalter stehen auf Ein; Beleuchtung, Leerpakete ausblasen und Bunker leerfahren Aus,
/// daher zeigt "Automatik" den Sammelzustand "Teilweise"). Keine Maschinenanbindung.
/// </summary>
[DummyService]
public sealed class DummyProductionFunctionService : IProductionFunctionService
{
    private static readonly TimeSpan WriteDelay = TimeSpan.FromMilliseconds(250);

    private readonly Dictionary<ProductionFunction, bool> _on = new()
    {
        [ProductionFunction.Fast] = true,
        [ProductionFunction.Lighting] = false,
        [ProductionFunction.MandrelBlower] = true,
        [ProductionFunction.FeedPaper] = true,
        [ProductionFunction.FeedCarton] = true,
        [ProductionFunction.WebControl] = true,
        [ProductionFunction.BlowOutEmptyPacks] = false,
        [ProductionFunction.ProductFeed] = true,
        [ProductionFunction.ProductMonitoring] = true,
        [ProductionFunction.Filling] = true,
        [ProductionFunction.Shaking] = true,
        [ProductionFunction.DustExtraction] = true,
        [ProductionFunction.EmptyHopper] = false,
        [ProductionFunction.Heating] = true,
        [ProductionFunction.LineOperation] = true,
    };

    private readonly HashSet<ProductionFunction> _pending = new();

    public IReadOnlyList<ProductionFunction> AutomaticFunctions { get; } = Enum.GetValues<ProductionFunction>()
        .Where(f => f is not (ProductionFunction.Automatic or ProductionFunction.Fast))
        .ToArray();

    public event EventHandler? Changed;

    public ProductionFunctionStatus GetStatus(ProductionFunction function)
    {
        var isOn = function == ProductionFunction.Automatic
            ? AutomaticFunctions.All(f => _on[f])
            : _on[function];
        return new ProductionFunctionStatus(function, isOn, IsEnabled: true, HasFault: false, _pending.Contains(function));
    }

    public async Task<bool> SetAsync(ProductionFunction function, bool on)
    {
        if (function == ProductionFunction.Automatic)
        {
            // Der Sammelzustand wird nur ueber "alle anwaehlen" veraendert (S01-9).
            return false;
        }

        _pending.Add(function);
        Changed?.Invoke(this, EventArgs.Empty);
        await Task.Delay(WriteDelay).ConfigureAwait(true);
        _on[function] = on;
        _pending.Remove(function);
        Changed?.Invoke(this, EventArgs.Empty);
        return true;
    }

    public async Task<IReadOnlyList<ProductionFunction>> SelectAllAutomaticAsync()
    {
        var added = AutomaticFunctions.Where(f => !_on[f]).ToArray();
        foreach (var function in added)
        {
            _pending.Add(function);
        }

        Changed?.Invoke(this, EventArgs.Empty);
        await Task.Delay(WriteDelay).ConfigureAwait(true);
        foreach (var function in added)
        {
            _on[function] = true;
            _pending.Remove(function);
        }

        Changed?.Invoke(this, EventArgs.Empty);
        return added;
    }
}
