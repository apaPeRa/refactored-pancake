using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>
/// Beispielwerte fuer HS-32: Bildbeispiel der Referenz (Antrieb Zuefuehrung 2MA1, Motor -2596,261, Geber 0,000, Achse initialisiert,
/// Statustext "Messer beginnt Schneidbewegung."). Der zweite Geber ist ein Dummy. Not-Aus gilt als gedrueckt (Dummy), damit die Seite bedienbar ist.
/// </summary>
[DummyService]
public sealed class DummyEncoderService : IEncoderService
{
    private readonly object _gate = new();
    private readonly IReadOnlyList<EncoderInfo> _encoders = new[]
    {
        new EncoderInfo(0, "Antrieb Zuführung 2MA1"),
        new EncoderInfo(1, "Antrieb Zuführung 2MA2"),
    };

    private readonly Dictionary<int, EncoderState> _states = new()
    {
        [0] = new EncoderState(true, -2596.261, 0.0, true, "Messer beginnt Schneidbewegung.", null, false),
        [1] = new EncoderState(true, 1204.500, 1204.500, true, null, null, false),
    };

    public bool IsEmergencyStopPressed => true;

    public event EventHandler? Changed;

    public IReadOnlyList<EncoderInfo> GetEncoders() => _encoders;

    public EncoderState GetState(int index)
    {
        lock (_gate)
        {
            return _states.TryGetValue(index, out var state) ? state : new EncoderState(false, null, null, null, null, null, false);
        }
    }

    public bool SetEncoderZero(int index)
    {
        if (!IsEmergencyStopPressed)
        {
            return false;
        }

        lock (_gate)
        {
            if (!_states.TryGetValue(index, out var state) || state.MotorPosition is not { } motor)
            {
                return false;
            }

            _states[index] = state with { EncoderPosition = motor };
        }

        Changed?.Invoke(this, EventArgs.Empty);
        return true;
    }
}
