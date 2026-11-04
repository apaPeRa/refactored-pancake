using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.ViewModels;

/// <summary>Zeile der Gruppe Versorgung (HM-11 Zeile). <see cref="Word"/> null = ungueltig ("---").</summary>
public sealed record ProductionSupplyRow(string Label, string? Word, ProductionSupplyState State);
