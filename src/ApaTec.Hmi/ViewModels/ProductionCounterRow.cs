namespace ApaTec.Hmi.ViewModels;

/// <summary>Zaehlerzeile von HS-02 (HM-33): "Aktuell" bzw. "Historie n".</summary>
public sealed record ProductionCounterRow(string Name, long Count, DateTime? ResetTime, bool IsCurrent);
