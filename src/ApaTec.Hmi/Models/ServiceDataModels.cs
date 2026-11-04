namespace ApaTec.Hmi.Models;

/// <summary>Treffer einer Variablenabfrage (HS-36): angezeigte Namen (hoechstens das Anzeigelimit) und Gesamtzahl der Treffer.</summary>
public sealed record VariableQueryResult(IReadOnlyList<string> Names, int MatchCount);

/// <summary>Ergebnis eines Datei-Vorgangs (Import/Export, HS-36 und HS-37). <see cref="ErrorText"/> nur bei Misserfolg.</summary>
public sealed record FileOperationResult(bool Success, int Count, string? FileName, string? ErrorText);
