using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>Beispielwerte aus den Bildern RS-05 und RS-06 (keine Maschinenanbindung); Grenzen sind Dummy-Werte (OP-28, A-50).</summary>
[DummyService]
public sealed class DummyFeederService : IFeederService
{
    private readonly object _gate = new();
    private PaperFeederState _paper = new(
        DiameterRollEnd: 4,
        BrakeStandstill: 50,
        DiameterMax: 100,
        BrakeAtMax: 14,
        DiameterMin: 10,
        BrakeAtMin: 5,
        SpliceEjectCount: 3,
        CouplingShift: 290,
        CouplingStopPosition: 180,
        RollDiameter: 100,
        BrakePressure: 50,
        SpliceDetected: false,
        SpliceSensor: false);

    private CartonFeederState _carton = new(
        GlueEnabled: true,
        CompensationOn: 20,
        CompensationOff: 20,
        GlueCold: 3,
        FlushValves: new[] { false, false, false, false, false },
        TrackAngles: new double[] { 200, 205, 205, 205, 205, 225, 225, 225, 225, 300, 310, 310, 310, 310, 325, 329, 329, 329 });

    public IReadOnlyList<string> FlushValveNames { get; } = new[] { "3Y25", "3Y26", "3Y27", "3Y28", "3Y29" };

    public event EventHandler? Changed;

    public PaperFeederState GetPaper()
    {
        lock (_gate)
        {
            return _paper;
        }
    }

    public CartonFeederState GetCarton()
    {
        lock (_gate)
        {
            return _carton;
        }
    }

    public FeederLimits GetLimits(FeederValue value) => value switch
    {
        FeederValue.PaperSpliceEjectCount => new FeederLimits(0, 9),
        FeederValue.PaperCouplingShift or FeederValue.PaperCouplingStopPosition or FeederValue.CartonTrackAngle => new FeederLimits(0, 360),
        FeederValue.CartonCompensationOn or FeederValue.CartonCompensationOff => new FeederLimits(0, 100),
        FeederValue.CartonGlueCold => new FeederLimits(0, 60),
        _ => new FeederLimits(0, 100),
    };

    public void SetValue(FeederValue value, double newValue)
    {
        lock (_gate)
        {
            _paper = value switch
            {
                FeederValue.PaperDiameterRollEnd => _paper with { DiameterRollEnd = newValue },
                FeederValue.PaperBrakeStandstill => _paper with { BrakeStandstill = newValue },
                FeederValue.PaperDiameterMax => _paper with { DiameterMax = newValue },
                FeederValue.PaperBrakeAtMax => _paper with { BrakeAtMax = newValue },
                FeederValue.PaperDiameterMin => _paper with { DiameterMin = newValue },
                FeederValue.PaperBrakeAtMin => _paper with { BrakeAtMin = newValue },
                FeederValue.PaperSpliceEjectCount => _paper with { SpliceEjectCount = newValue },
                FeederValue.PaperCouplingShift => _paper with { CouplingShift = newValue },
                FeederValue.PaperCouplingStopPosition => _paper with { CouplingStopPosition = newValue },
                _ => _paper,
            };
            _carton = value switch
            {
                FeederValue.CartonCompensationOn => _carton with { CompensationOn = newValue },
                FeederValue.CartonCompensationOff => _carton with { CompensationOff = newValue },
                FeederValue.CartonGlueCold => _carton with { GlueCold = newValue },
                _ => _carton,
            };
        }

        Changed?.Invoke(this, EventArgs.Empty);
    }

    public void SetGlueTrackAngle(int fieldIndex, double angle)
    {
        lock (_gate)
        {
            if (fieldIndex < 0 || fieldIndex >= _carton.TrackAngles.Count)
            {
                return;
            }

            var angles = _carton.TrackAngles.ToArray();
            angles[fieldIndex] = angle;
            _carton = _carton with { TrackAngles = angles };
        }

        Changed?.Invoke(this, EventArgs.Empty);
    }

    public void SetGlueEnabled(bool enabled)
    {
        lock (_gate)
        {
            _carton = _carton with { GlueEnabled = enabled };
        }

        Changed?.Invoke(this, EventArgs.Empty);
    }

    public void SetFlushValve(int index, bool selected)
    {
        lock (_gate)
        {
            if (index < 0 || index >= _carton.FlushValves.Count)
            {
                return;
            }

            var valves = _carton.FlushValves.ToArray();
            valves[index] = selected;
            _carton = _carton with { FlushValves = valves };
        }

        Changed?.Invoke(this, EventArgs.Empty);
    }
}
