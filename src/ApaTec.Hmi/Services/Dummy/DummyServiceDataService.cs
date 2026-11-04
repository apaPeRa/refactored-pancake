using ApaTec.Hmi.DesignData;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>Dummy: 111427 erzeugte Variablennamen, deterministische Werte; Import und Export liefern Erfolg (leerer Dateiname = Fehler).</summary>
[DummyService]
public sealed class DummyServiceDataService : IServiceDataService
{
    public int TotalVariableCount => Service_DesignData.TotalVariableCount;

    public VariableQueryResult Query(string? filter, int maxCount)
    {
        var all = Service_DesignData.VariableNames;
        if (string.IsNullOrWhiteSpace(filter))
        {
            return new VariableQueryResult(all.Take(maxCount).ToList(), all.Length);
        }

        var hits = all.Where(n => n.Contains(filter.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
        return new VariableQueryResult(hits.Take(maxCount).ToList(), hits.Count);
    }

    public double? GetValue(string variableName)
    {
        if (variableName == Service_DesignData.MarkedVariable)
        {
            return Service_DesignData.MarkedVariableValue;
        }

        uint hash = 2166136261;
        foreach (var c in variableName)
        {
            hash = (hash ^ c) * 16777619;
        }

        return Math.Round((hash % 1000000) / 100.0, 2);
    }

    public Task<FileOperationResult> ImportAsync(string fileName) => Task.FromResult(Result(fileName, Service_DesignData.TotalVariableCount));

    public Task<FileOperationResult> ExportAllAsync(string fileName) => Task.FromResult(Result(fileName, Service_DesignData.TotalVariableCount));

    public Task<FileOperationResult> ExportSelectionAsync(IReadOnlyCollection<string> variableNames, string fileName) =>
        Task.FromResult(Result(fileName, variableNames.Count));

    public Task<bool> RunWagoAsync() => Task.FromResult(true);

    private static FileOperationResult Result(string fileName, int count) =>
        string.IsNullOrWhiteSpace(fileName)
            ? new FileOperationResult(false, 0, null, null)
            : new FileOperationResult(true, count, fileName, null);
}
