using ApaTec.Hmi.DesignData;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>
/// Dummy der Produktionsstatistik (HS-29): heute die Bildwerte aus RS-29_01, fuer die Vortage deterministisch skalierte Werte; Sonntage ohne Daten (zeigt den Zustand "Keine Daten", K29-3).
/// </summary>
[DummyService]
public sealed class DummyProductionStatisticsService : IProductionStatisticsService
{
    private static readonly TimeSpan Latency = TimeSpan.FromMilliseconds(150);

    public int HistoryDays => ProductionStatistics_DesignData.HistoryDays;

    public async Task<ProductionDayStatistics?> GetDayAsync(int dayOffset, CancellationToken cancellationToken = default)
    {
        if (dayOffset < 0 || dayOffset >= HistoryDays)
        {
            return null;
        }

        await Task.Delay(Latency, cancellationToken).ConfigureAwait(true);
        var date = DateTime.Today.AddDays(-dayOffset);
        if (dayOffset > 0 && date.DayOfWeek == DayOfWeek.Sunday)
        {
            return null;
        }

        var factor = dayOffset == 0 ? 1d : 0.6 + (dayOffset * 37 % 8 * 0.1);
        var values = ProductionStatistics_DesignData.TodayValues
            .Select(v => v is { } value ? (double?)Math.Round(value * factor) : null)
            .ToList();
        return new ProductionDayStatistics(date, values, ProductionStatistics_DesignData.IntervalMinutes);
    }
}
