using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>Variablenliste, Sicherung und Wiederherstellung (HS-36; Konzept.md 6.6).</summary>
public interface IServiceDataService
{
    /// <summary>Anzahl aller Variablen der Maschine (konfigurationsabhaengig, OP-41).</summary>
    int TotalVariableCount { get; }

    /// <summary>Variablen, deren Name <paramref name="filter"/> enthaelt (leer = alle); hoechstens <paramref name="maxCount"/> Namen.</summary>
    VariableQueryResult Query(string? filter, int maxCount);

    /// <summary>Aktueller Wert der Variable oder null, wenn nicht lesbar.</summary>
    double? GetValue(string variableName);

    Task<FileOperationResult> ImportAsync(string fileName);

    Task<FileOperationResult> ExportAllAsync(string fileName);

    Task<FileOperationResult> ExportSelectionAsync(IReadOnlyCollection<string> variableNames, string fileName);

    /// <summary>Taste "Wago" (Funktion im Handbuch nicht beschrieben, OP-49).</summary>
    Task<bool> RunWagoAsync();
}
