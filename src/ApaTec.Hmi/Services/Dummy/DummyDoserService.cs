using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>
/// Beispielwerte aus den Bildern RS-11, RS-19, RS-21 und dem Design DS-04 (keine Maschinenanbindung); Grenzen sind Dummy (OP-28).
/// Hauptdosierer 1 zeigt die Werte der Karte aus DS-04 (48 %, 113 g, 5,30 g), Hauptdosierer 2 die Werte des Referenzbilds RS-11 (52 %, 122 g, 0,00 g).
/// </summary>
[DummyService]
public sealed class DummyDoserService : IDoserService
{
    private const int PointCount = 20;
    private const int MinimumPoints = 3;

    private readonly Dictionary<DoserId, DoserSnapshot> _dosers;
    private readonly Dictionary<DoserId, DoserMotorSettings> _motors;
    private DoserWeightCorrectionData _weightCorrection;

    public DummyDoserService()
    {
        ReferenceWeights = new DoserReferenceWeights(TargetWeight: 235, LastWeight: 238);

        _dosers = new Dictionary<DoserId, DoserSnapshot>
        {
            [DoserId.Main1] = new DoserSnapshot(
                DoserId.Main1, TargetPercent: 48, TargetWeight: 113, MaxRefill: 0, CurrentRefill: 0, RefillResult: DoserRefillResult.None,
                RegulationValue: 5.30, CalibrationRevolutions: 4, CalibrationWeight: 137.50,
                ScrewSpeed: 2800, AgitatorPercent: 20, AgitatorRunOn: 0, CrossScrewPercent: 20,
                HopperUpper: DoserHopperState.ProductPresent, HopperLower: DoserHopperState.ProductPresent, Load: 92,
                CrossScrewEnabled: true, AgitatorEnabled: true, RegulationEnabled: true,
                IsEmptying: false, IsSelected: false, ActionsAllowed: true),
            [DoserId.Main2] = new DoserSnapshot(
                DoserId.Main2, TargetPercent: 52, TargetWeight: 122, MaxRefill: 0, CurrentRefill: 0, RefillResult: DoserRefillResult.None,
                RegulationValue: 0.00, CalibrationRevolutions: 4, CalibrationWeight: 137.50,
                ScrewSpeed: 2800, AgitatorPercent: 20, AgitatorRunOn: 0, CrossScrewPercent: 20,
                HopperUpper: DoserHopperState.ProductPresent, HopperLower: DoserHopperState.ProductPresent, Load: 91,
                CrossScrewEnabled: true, AgitatorEnabled: true, RegulationEnabled: true,
                IsEmptying: false, IsSelected: false, ActionsAllowed: false),
            [DoserId.Post] = new DoserSnapshot(
                DoserId.Post, TargetPercent: 0, TargetWeight: 250, MaxRefill: 50, CurrentRefill: 13, RefillResult: DoserRefillResult.Dosed,
                RegulationValue: 4.81, CalibrationRevolutions: 5, CalibrationWeight: 18.50,
                ScrewSpeed: 2800, AgitatorPercent: 30, AgitatorRunOn: 0, CrossScrewPercent: 30,
                HopperUpper: DoserHopperState.ProductPresent, HopperLower: DoserHopperState.ProductPresent, Load: 73,
                CrossScrewEnabled: true, AgitatorEnabled: true, RegulationEnabled: true,
                IsEmptying: false, IsSelected: true, ActionsAllowed: true),
        };

        // Bild RS-12 (Hauptdosierer 1): Verschluss Zu 0 Grad, Auf 37 Grad, Geschwindigkeit 80 %, Rest 0 %. Fuer die anderen Dosierer Platzhalter (OP-39).
        DoserMotorSettings Motor() => new(
            Closed: new DoserClosureMotion(Position: 0, Speed: 80, Acceleration: 0, Deceleration: 0, Jerk: 0),
            Open: new DoserClosureMotion(Position: 37, Speed: 80, Acceleration: 0, Deceleration: 0, Jerk: 0),
            Screw: new DoserScrewMotion(Acceleration: 0, Deceleration: 0, Jerk: 0));
        _motors = new Dictionary<DoserId, DoserMotorSettings>
        {
            [DoserId.Main1] = Motor(),
            [DoserId.Main2] = Motor(),
            [DoserId.Post] = Motor(),
        };

        // Bild RS-21: Sollgewicht 250,4 g; Stuetzstellen 18,00/20,00 und 22,00/24,00, uebrige 0,00.
        var points = new List<DoserWeightPoint>(PointCount) { new(18.00, 20.00), new(22.00, 24.00) };
        while (points.Count < PointCount)
        {
            points.Add(new DoserWeightPoint(0, 0));
        }

        _weightCorrection = new DoserWeightCorrectionData(250.4, points);
    }

    public DoserReferenceWeights ReferenceWeights { get; }

    public DoserWeightCorrectionData WeightCorrection => _weightCorrection;

    public event EventHandler? Changed;

    public DoserSnapshot GetDoser(DoserId id) => _dosers[id];

    public DoserMotorSettings GetMotorSettings(DoserId id) => _motors[id];

    public DoserValueLimits GetLimits(DoserField field) => field switch
    {
        DoserField.TargetPercent => new DoserValueLimits(0, 100, 0, "%"),
        DoserField.TargetWeight => new DoserValueLimits(0, 1000, 0, "g"),
        DoserField.MaxRefill => new DoserValueLimits(0, 1000, 0, "g"),
        DoserField.RegulationValue => new DoserValueLimits(-100, 100, 2, "g"),
        DoserField.CalibrationRevolutions => new DoserValueLimits(0, 100, 0, string.Empty),
        DoserField.CalibrationWeight => new DoserValueLimits(0, 1000, 2, "g"),
        DoserField.ScrewSpeed => new DoserValueLimits(0, 6000, 0, "1/min"),
        DoserField.AgitatorPercent or DoserField.CrossScrewPercent => new DoserValueLimits(0, 100, 0, "%"),
        DoserField.AgitatorRunOn => new DoserValueLimits(0, 60, 0, "s"),
        DoserField.ClosedPosition or DoserField.OpenPosition => new DoserValueLimits(0, 360, 0, "°"),
        DoserField.CorrectionTargetWeight => new DoserValueLimits(0, 1000, 1, "g"),
        DoserField.CorrectionPointValue => new DoserValueLimits(0, 1000, 2, "g"),
        _ => new DoserValueLimits(0, 100, 0, "%"),
    };

    public Task SetValueAsync(DoserId id, DoserField field, double value)
    {
        var limits = GetLimits(field);
        value = Math.Round(Math.Clamp(value, limits.Minimum, limits.Maximum), limits.Decimals);

        if (field >= DoserField.ClosedPosition && field <= DoserField.ScrewJerk)
        {
            _motors[id] = ApplyMotor(_motors[id], field, value);
        }
        else
        {
            var snapshot = _dosers[id];
            snapshot = field switch
            {
                DoserField.TargetPercent => snapshot with
                {
                    TargetPercent = value,
                    TargetWeight = Math.Round(value * ReferenceWeights.TargetWeight / 100.0),
                },
                DoserField.TargetWeight => snapshot with { TargetWeight = value },
                DoserField.MaxRefill => snapshot with { MaxRefill = value },
                DoserField.RegulationValue => snapshot with { RegulationValue = value },
                DoserField.CalibrationRevolutions => snapshot with { CalibrationRevolutions = value },
                DoserField.CalibrationWeight => snapshot with { CalibrationWeight = value },
                DoserField.ScrewSpeed => snapshot with { ScrewSpeed = value },
                DoserField.AgitatorPercent => snapshot with { AgitatorPercent = value },
                DoserField.AgitatorRunOn => snapshot with { AgitatorRunOn = value },
                DoserField.CrossScrewPercent => snapshot with { CrossScrewPercent = value },
                _ => snapshot,
            };
            _dosers[id] = snapshot;
        }

        Changed?.Invoke(this, EventArgs.Empty);
        return Task.CompletedTask;
    }

    public Task SetSwitchAsync(DoserId id, DoserSwitch which, bool enabled)
    {
        var snapshot = _dosers[id];
        _dosers[id] = which switch
        {
            DoserSwitch.CrossScrew => snapshot with { CrossScrewEnabled = enabled },
            DoserSwitch.Agitator => snapshot with { AgitatorEnabled = enabled },
            _ => snapshot with { RegulationEnabled = enabled },
        };
        Changed?.Invoke(this, EventArgs.Empty);
        return Task.CompletedTask;
    }

    public Task TriggerManualAsync(DoserId id) => Task.CompletedTask;

    public Task SetEmptyingAsync(DoserId id, bool enabled)
    {
        _dosers[id] = _dosers[id] with { IsEmptying = enabled };
        Changed?.Invoke(this, EventArgs.Empty);
        return Task.CompletedTask;
    }

    public Task StartCalibrationAsync(DoserId id) => Task.CompletedTask;

    public Task SetWeightCorrectionAsync(DoserWeightCorrectionData data)
    {
        _weightCorrection = data;
        Changed?.Invoke(this, EventArgs.Empty);
        return Task.CompletedTask;
    }

    public Task TriggerWeightSampleAsync() => Task.CompletedTask;

    public Task<DoserAdjustResult> AdjustWeightAsync()
    {
        var used = 0;
        foreach (var point in _weightCorrection.Points)
        {
            var nominalSet = point.Nominal > 0;
            var actualSet = point.Actual > 0;
            if (nominalSet != actualSet)
            {
                return Task.FromResult(new DoserAdjustResult(DoserAdjustState.InvalidPoints, used));
            }

            if (nominalSet)
            {
                used++;
            }
        }

        var state = used < MinimumPoints ? DoserAdjustState.TooFewPoints : DoserAdjustState.Calculated;
        return Task.FromResult(new DoserAdjustResult(state, used));
    }

    private static DoserMotorSettings ApplyMotor(DoserMotorSettings motor, DoserField field, double value) => field switch
    {
        DoserField.ClosedPosition => motor with { Closed = motor.Closed with { Position = value } },
        DoserField.ClosedSpeed => motor with { Closed = motor.Closed with { Speed = value } },
        DoserField.ClosedAcceleration => motor with { Closed = motor.Closed with { Acceleration = value } },
        DoserField.ClosedDeceleration => motor with { Closed = motor.Closed with { Deceleration = value } },
        DoserField.ClosedJerk => motor with { Closed = motor.Closed with { Jerk = value } },
        DoserField.OpenPosition => motor with { Open = motor.Open with { Position = value } },
        DoserField.OpenSpeed => motor with { Open = motor.Open with { Speed = value } },
        DoserField.OpenAcceleration => motor with { Open = motor.Open with { Acceleration = value } },
        DoserField.OpenDeceleration => motor with { Open = motor.Open with { Deceleration = value } },
        DoserField.OpenJerk => motor with { Open = motor.Open with { Jerk = value } },
        DoserField.ScrewAcceleration => motor with { Screw = motor.Screw with { Acceleration = value } },
        DoserField.ScrewDeceleration => motor with { Screw = motor.Screw with { Deceleration = value } },
        DoserField.ScrewJerk => motor with { Screw = motor.Screw with { Jerk = value } },
        _ => motor,
    };
}
