using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>
/// Beispielwerte aus RS-02_01 (Zaehler, Historie, Gesamtproduktion, Betriebsstunden) und DS-01 (Versorgung); die Gewichtskennzahlen sind Dummywerte (OP-29).
/// Keine Maschinenanbindung: Befehle aendern nur den Speicherzustand und melden danach <see cref="Changed"/>.
/// </summary>
[DummyService]
public sealed class DummyProductionService : IProductionService
{
    private const int CounterCount = 13;
    private static readonly TimeSpan WriteDelay = TimeSpan.FromMilliseconds(250);

    private readonly List<ProductionCounterEntry> _counters = new()
    {
        new(874183, new DateTime(2025, 4, 9, 14, 55, 9)),
        new(7, new DateTime(2025, 3, 28, 14, 8, 2)),
        new(7636, new DateTime(2025, 3, 28, 14, 7, 59)),
        new(773682, new DateTime(2025, 3, 28, 12, 25, 2)),
        new(1, new DateTime(2025, 3, 18, 19, 13, 1)),
        new(4622, new DateTime(2025, 3, 18, 19, 13, 1)),
        new(225070, new DateTime(2025, 3, 18, 17, 55, 7)),
        new(0, null),
        new(0, null),
        new(0, null),
        new(0, null),
        new(0, null),
        new(0, null),
    };

    private ProductionWeightMode _weightMode = ProductionWeightMode.Continuous;

    public bool IsValid => true;

    public long CurrentProduction => _counters[0].Count;

    public long LastProduction => _counters[1].Count;

    public double? LastWeight => 235.4;

    public int? LastWeightIndex => 1;

    public double? MeanWeight => _weightMode == ProductionWeightMode.Continuous ? 234.8 : 235.1;

    public double? StandardDeviation => _weightMode == ProductionWeightMode.Continuous ? 1.9 : 2.3;

    public ProductionWeightMode WeightMode => _weightMode;

    public long TotalProduction => 1885201;

    public TimeSpan OperatingTime => new(289, 38, 12);

    public TimeSpan ResetHoldDuration => TimeSpan.FromMilliseconds(1000);

    public IReadOnlyList<ProductionSupply> Supplies { get; } = new ProductionSupply[]
    {
        new(ProductionSupplyItem.CompressedAir, ProductionSupplyState.Ok, "IO"),
        new(ProductionSupplyItem.Paper, ProductionSupplyState.Ok, "IO"),
        new(ProductionSupplyItem.Product, ProductionSupplyState.Ok, "IO"),
        new(ProductionSupplyItem.BeltScale, ProductionSupplyState.Ok, "Bereit"),
        new(ProductionSupplyItem.FollowMachine, ProductionSupplyState.Ok, "Läuft"),
    };

    public IReadOnlyList<ProductionCounterEntry> Counters => _counters.ToArray();

    public event EventHandler? Changed;

    public async Task<bool> SetWeightModeAsync(ProductionWeightMode mode)
    {
        await Task.Delay(WriteDelay).ConfigureAwait(true);
        _weightMode = mode;
        Changed?.Invoke(this, EventArgs.Empty);
        return true;
    }

    public async Task<bool> ResetCounterAsync()
    {
        await Task.Delay(WriteDelay).ConfigureAwait(true);

        // Alle Eintraege rutschen eine Zeile nach unten, "Historie 12" faellt weg, "Aktuell" beginnt bei 0 mit neuem Zeitpunkt (S02-4).
        _counters.Insert(0, new ProductionCounterEntry(0, DateTime.Now));
        _counters.RemoveRange(CounterCount, _counters.Count - CounterCount);
        Changed?.Invoke(this, EventArgs.Empty);
        return true;
    }
}
