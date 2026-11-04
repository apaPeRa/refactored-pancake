using System.Timers;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>Systemuhr mit Sekundentakt.</summary>
[DummyService]
public sealed class DummyClockService : IClockService, IDisposable
{
    private readonly System.Timers.Timer _timer = new(1000);

    public DummyClockService()
    {
        _timer.Elapsed += OnElapsed;
        _timer.AutoReset = true;
        _timer.Start();
    }

    public DateTime Now => DateTime.Now;

    public event EventHandler? Tick;

    public void Dispose()
    {
        _timer.Elapsed -= OnElapsed;
        _timer.Dispose();
    }

    private void OnElapsed(object? sender, ElapsedEventArgs e) => Tick?.Invoke(this, EventArgs.Empty);
}
