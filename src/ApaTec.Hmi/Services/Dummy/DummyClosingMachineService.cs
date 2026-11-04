using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>Beispielwerte aus den Bildern RS-16 bis RS-18 (keine Maschinenanbindung); Grenzen sind Dummy (OP-28).</summary>
[DummyService]
public sealed class DummyClosingMachineService : IClosingMachineService
{
    private const int PointCount = 20;
    private const int MinimumPoints = 3;

    public DummyClosingMachineService()
    {
        Settings = new ClosingMachineSettings(
            ConveyorSpeed: 50, HeadGlueEnabled: true, HeadGlueStart: 280, HeadGlueEnd: 325, HeadGlueDuration: 50,
            ShakerEnabled: true, Shaker1: 25, Shaker2: 25);

        MotorSettings = new ClosingMotorSettings(
            Closed: new ClosingClosureMotion(Position: 0, Speed: 80, Acceleration: 0, Deceleration: 0, Jerk: 0),
            Open: new ClosingClosureMotion(Position: 37, Speed: 80, Acceleration: 0, Deceleration: 0, Jerk: 0),
            Screw: new ClosingScrewMotion(Acceleration: 0, Deceleration: 0, Jerk: 0));

        var points = new ClosingWeightPoint[PointCount];
        for (var i = 0; i < PointCount; i++)
        {
            points[i] = i switch
            {
                0 => new ClosingWeightPoint(18, 20),
                1 => new ClosingWeightPoint(22, 24),
                _ => new ClosingWeightPoint(0, 0),
            };
        }

        WeightCorrection = new ClosingWeightCorrectionData(250.4, points);
    }

    public ClosingMachineSettings Settings { get; private set; }

    public ClosingMotorSettings MotorSettings { get; private set; }

    public ClosingWeightCorrectionData WeightCorrection { get; private set; }

    public bool IsEditingAllowed => true;

    public bool CanDoseManually => true;

    public event EventHandler? Changed;

    public ClosingValueLimits GetLimits(ClosingField field) => field switch
    {
        ClosingField.ConveyorSpeed => new ClosingValueLimits(0, 100, 0, "%"),
        ClosingField.HeadGlueStart => new ClosingValueLimits(0, 360, 0, "°"),
        ClosingField.HeadGlueEnd => new ClosingValueLimits(0, 360, 0, "°"),
        ClosingField.HeadGlueDuration => new ClosingValueLimits(0, 1000, 0, "ms"),
        ClosingField.Shaker1 => new ClosingValueLimits(0, 100, 0, "%"),
        ClosingField.Shaker2 => new ClosingValueLimits(0, 100, 0, "%"),
        ClosingField.TargetWeight => new ClosingValueLimits(0, 1000, 1, "g"),
        _ => new ClosingValueLimits(0, 100, 0, string.Empty),
    };

    public Task SetSettingsAsync(ClosingMachineSettings settings)
    {
        Settings = settings;
        Changed?.Invoke(this, EventArgs.Empty);
        return Task.CompletedTask;
    }

    public Task SetMotorSettingsAsync(ClosingMotorSettings settings)
    {
        MotorSettings = settings;
        Changed?.Invoke(this, EventArgs.Empty);
        return Task.CompletedTask;
    }

    public Task SetWeightCorrectionAsync(ClosingWeightCorrectionData data)
    {
        WeightCorrection = data;
        Changed?.Invoke(this, EventArgs.Empty);
        return Task.CompletedTask;
    }

    public Task TriggerManualDosingAsync() => Task.CompletedTask;

    public Task<ClosingAdjustResult> AdjustWeightAsync()
    {
        var used = WeightCorrection.Points.Count(p => p.Nominal > 0 && p.Actual > 0);
        return Task.FromResult(new ClosingAdjustResult(used >= MinimumPoints, used));
    }
}
