using ApaTec.Hmi.DesignData;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>Nocken 1 bis 59 (Anzahl unbekannt, OP-41); die Uebersicht zeigt Nr. 40 bis 59 aus dem Bild, Nocke 12 ist das Beispiel von HS-25.</summary>
[DummyService]
public sealed class DummyCamService : ICamService
{
    private readonly Dictionary<int, CamDetail> _details = new();
    private readonly object _gate = new();
    private Timer? _timer;
    private int _subscribers;
    private int _position = 140;
    private EventHandler? _changed;

    /// <summary>Live-Position: der Dummy-Geber laeuft nur, solange jemand das Ereignis abonniert hat.</summary>
    public event EventHandler? Changed
    {
        add
        {
            lock (_gate)
            {
                _changed += value;
                if (_subscribers++ == 0)
                {
                    _timer = new Timer(_ => Tick(), null, TimeSpan.FromMilliseconds(500), TimeSpan.FromMilliseconds(500));
                }
            }
        }

        remove
        {
            lock (_gate)
            {
                _changed -= value;
                if (_subscribers > 0 && --_subscribers == 0)
                {
                    _timer?.Dispose();
                    _timer = null;
                }
            }
        }
    }

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

    public CamLiveData GetLive(CamDetail cam)
    {
        var position = _position;
        return new(position, position >= cam.StartAngle && position <= cam.EndAngle);
    }

    private void Tick()
    {
        _position = (_position + 20) % 1080;
        _changed?.Invoke(this, EventArgs.Empty);
    }

    public double CalculateResult(double angle, double timeMs) => angle;

    public Task<bool> WriteAsync(CamDetail detail)
    {
        _details[detail.Number] = detail;
        return Task.FromResult(true);
    }
}
