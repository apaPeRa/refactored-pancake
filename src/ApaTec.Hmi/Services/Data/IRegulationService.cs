using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>Automatische Gewichtsregulierung der Dosierer (HS-23; Konzept.md 6.6).</summary>
public interface IRegulationService
{
    /// <summary>Schrittweite von "Regulierung -/+" in g (Annahme S23-1, Dummy).</summary>
    double ManualStep { get; }

    RegulationSettings GetSettings(RegulationDoser doser);

    MachineValueLimits GetLimits(RegulationField field);

    Task<RegulationSettings> SetValueAsync(RegulationDoser doser, RegulationField field, double value);

    Task<RegulationSettings> SetEnabledAsync(RegulationDoser doser, bool enabled);

    /// <summary>Aendert den Korrekturwert um <see cref="ManualStep"/> in Richtung <paramref name="direction"/> (-1 oder +1), begrenzt durch "Regulierung max".</summary>
    Task<RegulationSettings> AdjustCorrectionAsync(RegulationDoser doser, int direction);
}
