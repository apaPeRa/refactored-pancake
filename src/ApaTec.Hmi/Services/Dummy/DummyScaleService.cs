using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>
/// Beispielwerte der Kontrollwaage aus den Bildern RS-13 bis RS-15 (Netto 0,0 g, Live -399,0 g, Mittelwert 235,1 g, Sollgewicht 235,0 g, Zaehler 874794 usw.).
/// Keine Maschinenanbindung; "Start" im Modus Einzel loescht die Reihe und fuellt sie danach im Hintergrund Wert fuer Wert (Demo).
/// </summary>
[DummyService]
public sealed class DummyScaleService : IScaleService
{
    private const int Capacity = 50;
    private const int StartLastIndex = 6;
    private static readonly TimeSpan SampleInterval = TimeSpan.FromMilliseconds(400);

    private static readonly double?[] TrendValues =
    {
        234.0, 235.0, 235.8, 235.2, 234.6, 235.1, 235.5, 236.0, 235.4, 234.9, 235.3,
        235.7, 236.4, 235.6, 235.0, 235.2, 235.9, 235.4, 235.1, 235.5, 235.8,
    };

    private readonly object _gate = new();
    private readonly double?[] _weights = new double?[Capacity];
    private CheckWeigherSettings _settings = new(235.0, 15.0, 5000, 104, 268.0, 200.0, 200.0);
    private CheckWeigherCounters _counters = new(435, 0, 1093, 874794, 1528, 0.0);
    private CheckWeigherReading _reading = new(0.0, 0.0, -399.0, 235.1, 1.2, 114.6);
    private bool _isContinuous = true;
    private int _lastIndex = StartLastIndex;
    private CancellationTokenSource? _run;

    public DummyScaleService()
    {
        for (var i = 0; i < Capacity; i++)
        {
            _weights[i] = Math.Round(235.4 + (0.9 * Math.Sin(i * 1.7)), 1);
        }
    }

    public event EventHandler? Changed;

    public int TrendPointCount => TrendValues.Length;

    public CheckWeigherSnapshot GetCheckWeigher()
    {
        lock (_gate)
        {
            return new CheckWeigherSnapshot(true, _reading, _settings, _counters);
        }
    }

    public ParameterLimits GetLimits(CheckWeigherParameter parameter) => parameter switch
    {
        CheckWeigherParameter.Tare => new ParameterLimits(0, 500),
        CheckWeigherParameter.AutoZeroInterval => new ParameterLimits(0, 100000),
        _ => new ParameterLimits(0, 2000),
    };

    public void SetParameter(CheckWeigherParameter parameter, double value)
    {
        lock (_gate)
        {
            _settings = parameter switch
            {
                CheckWeigherParameter.TargetWeight => _settings with { TargetWeight = value },
                CheckWeigherParameter.Tare => _settings with { Tare = value },
                CheckWeigherParameter.AutoZeroInterval => _settings with { AutoZeroInterval = (int)Math.Round(value) },
                CheckWeigherParameter.OverWeight => _settings with { OverWeight = value },
                CheckWeigherParameter.Under1 => _settings with { Under1 = value },
                CheckWeigherParameter.Under2 => _settings with { Under2 = value },
                _ => _settings,
            };
        }

        OnChanged();
    }

    public Task SetZeroAsync()
    {
        lock (_gate)
        {
            _reading = _reading with { Live = 0.0 };
            _settings = _settings with { PacksSinceZero = 0 };
        }

        OnChanged();
        return Task.CompletedTask;
    }

    public Task ResetCountersAsync()
    {
        lock (_gate)
        {
            _counters = new CheckWeigherCounters(0, 0, 0, 0, 0, 0.0);
        }

        OnChanged();
        return Task.CompletedTask;
    }

    public SingleWeightSeries GetSingleWeights()
    {
        lock (_gate)
        {
            var settings = _settings;
            var samples = new WeightSample?[Capacity];
            for (var i = 0; i < Capacity; i++)
            {
                if (_weights[i] is { } w)
                {
                    samples[i] = new WeightSample(w, w > Math.Max(settings.Under1, settings.Under2) && w < settings.OverWeight);
                }
            }

            var valid = _weights.Where(v => v.HasValue).Select(v => v!.Value).ToList();
            double? mean = valid.Count > 0 ? valid.Average() : null;
            double? std = valid.Count > 1 ? Math.Sqrt(valid.Sum(v => (v - mean!.Value) * (v - mean.Value)) / (valid.Count - 1)) : (valid.Count == 1 ? 0.0 : null);
            return new SingleWeightSeries(samples, _lastIndex, _isContinuous, Capacity, mean, std);
        }
    }

    public Task SetSamplingModeAsync(bool continuous)
    {
        lock (_gate)
        {
            _isContinuous = continuous;
        }

        OnChanged();
        return Task.CompletedTask;
    }

    public Task StartSamplingAsync()
    {
        CancellationTokenSource run;
        bool single;
        lock (_gate)
        {
            _run?.Cancel();
            run = _run = new CancellationTokenSource();
            single = !_isContinuous;
            if (single)
            {
                Array.Clear(_weights);
                _lastIndex = -1;
            }
        }

        OnChanged();
        if (single)
        {
            _ = FillAsync(run.Token);
        }

        return Task.CompletedTask;
    }

    public IReadOnlyList<double?> GetTrend() => TrendValues;

    private async Task FillAsync(CancellationToken token)
    {
        try
        {
            for (var i = 0; i < Capacity; i++)
            {
                await Task.Delay(SampleInterval, token).ConfigureAwait(false);
                lock (_gate)
                {
                    _weights[i] = Math.Round(235.4 + (0.9 * Math.Sin(i * 2.9)), 1);
                    _lastIndex = i;
                }

                OnChanged();
            }
        }
        catch (OperationCanceledException)
        {
        }
    }

    private void OnChanged() => Changed?.Invoke(this, EventArgs.Empty);
}
