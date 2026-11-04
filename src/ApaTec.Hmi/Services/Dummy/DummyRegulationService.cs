using ApaTec.Hmi.DesignData;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>Beispielwerte des Bildes RS-23_01; die Berechnung des Korrekturwerts ist Dummy (OP-45).</summary>
[DummyService]
public sealed class DummyRegulationService : IRegulationService
{
    private RegulationSettings _main = RegulationDesignData.Main;
    private RegulationSettings _post = RegulationDesignData.Post;

    public double ManualStep => 0.5;

    public RegulationSettings GetSettings(RegulationDoser doser) => doser == RegulationDoser.Main ? _main : _post;

    public MachineValueLimits GetLimits(RegulationField field) => field switch
    {
        RegulationField.SampleCount => new MachineValueLimits(1, 100),
        RegulationField.Step => new MachineValueLimits(0, 100),
        RegulationField.Tolerance => new MachineValueLimits(0, 50),
        RegulationField.MaxCorrection => new MachineValueLimits(0, 500),
        _ => new MachineValueLimits(-500, 500),
    };

    public Task<RegulationSettings> SetValueAsync(RegulationDoser doser, RegulationField field, double value) =>
        Store(doser, s => field switch
        {
            RegulationField.SampleCount => s with { SampleCount = (int)value },
            RegulationField.Step => s with { Step = value },
            RegulationField.Tolerance => s with { Tolerance = value },
            RegulationField.MaxCorrection => s with { MaxCorrection = value },
            _ => s with { CurrentCorrection = value },
        });

    public Task<RegulationSettings> SetEnabledAsync(RegulationDoser doser, bool enabled) => Store(doser, s => s with { IsRegulationOn = enabled });

    public Task<RegulationSettings> AdjustCorrectionAsync(RegulationDoser doser, int direction) =>
        Store(doser, s => s with { CurrentCorrection = Math.Round(Math.Clamp(s.CurrentCorrection + (Math.Sign(direction) * ManualStep), -s.MaxCorrection, s.MaxCorrection), 1) });

    private Task<RegulationSettings> Store(RegulationDoser doser, Func<RegulationSettings, RegulationSettings> change)
    {
        var updated = change(GetSettings(doser));
        if (doser == RegulationDoser.Main)
        {
            _main = updated;
        }
        else
        {
            _post = updated;
        }

        return Task.FromResult(updated);
    }
}
