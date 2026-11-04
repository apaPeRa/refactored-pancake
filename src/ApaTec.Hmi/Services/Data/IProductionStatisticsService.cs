using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>Produktionsstatistik der letzten 30 Tage (HS-29, Konzept.md 6.6 Zeile "Maschinenfunktionen"). Nur Lesezugriff.</summary>
public interface IProductionStatisticsService
{
    /// <summary>Zahl der abrufbaren Tage (heute und 29 Vortage, K29-4).</summary>
    int HistoryDays { get; }

    /// <summary>Verlauf des Tages; <paramref name="dayOffset"/> 0 = heute bis <c>HistoryDays - 1</c>. null = keine Daten fuer diesen Tag.</summary>
    Task<ProductionDayStatistics?> GetDayAsync(int dayOffset, CancellationToken cancellationToken = default);
}
