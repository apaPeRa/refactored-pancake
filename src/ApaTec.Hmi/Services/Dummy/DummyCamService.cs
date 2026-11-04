using ApaTec.Hmi.DesignData;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>Nocken 1 bis 59 (Anzahl unbekannt, OP-41); die Uebersicht zeigt Nr. 40 bis 59 aus dem Bild, Nocke 12 ist das Beispiel von HS-25.</summary>
[DummyService]
public sealed class DummyCamService : ICamService
{
    private readonly Dictionary<int, CamDetail> _details = new();

    public int FirstNumber => 1;

    public int LastNumber => 59;

    public IReadOnlyList<string> EncoderNames => CamsDesignData.Encoders;

    public MachineValueLimits GetLimits(CamField field) => field switch
    {
        CamField.Number => new MachineValueLimits(FirstNumber, LastNumber),
        CamField.StartAngle or CamField.EndAngle => new MachineValueLimits(0, 1079),
        CamField.StartTime or CamField.EndTime => new MachineValueLimits(0, 500),
        _ => new MachineValueLimits(0, 1079),
    };

    public IReadOnlyList<CamSummary> GetOverview() => CamsDesignData.Overview;

    public CamDetail GetDetail(int number)
    {
        if (_details.TryGetValue(number, out var stored))
        {
            return stored;
        }

        if (number == CamsDesignData.Sample.Number)
        {
            return CamsDesignData.Sample;
        }

        var row = CamsDesignData.Overview.FirstOrDefault(c => c.Number == number);
        return row is null
            ? new CamDetail(number, 0, 0, 0, 0, 1, 0, string.Empty)
            : new CamDetail(number, row.StartAngle, 0, row.EndAngle, 0, 1, 0, row.Name);
    }

    public CamLiveData GetLive(CamDetail cam) => new(140, 140 >= cam.StartAngle && 140 <= cam.EndAngle);

    public double CalculateResult(double angle, double timeMs) => angle;

    public Task<bool> WriteAsync(CamDetail detail)
    {
        _details[detail.Number] = detail;
        return Task.FromResult(true);
    }
}
