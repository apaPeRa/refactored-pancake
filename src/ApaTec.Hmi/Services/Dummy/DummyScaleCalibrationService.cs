using ApaTec.Hmi.DesignData;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>Dummy der Waagenkalibrierung (HS-27): Beispielwerte aus RS-27_01, Zustandsfolge Start, Entlastet, Belastet, Bestaetigung. Keine Maschinenanbindung.</summary>
[DummyService]
public sealed class DummyScaleCalibrationService : IScaleCalibrationService
{
    private readonly object _gate = new();
    private readonly List<ScaleSnapshot> _scales = ScaleCalibration_DesignData.Scales.ToList();

    public int ScaleCount => _scales.Count;

    public IReadOnlyList<string> FilterTypes => ScaleCalibration_DesignData.Filters;

    public event EventHandler<int>? Changed;

    public ScaleSnapshot GetSnapshot(int scaleIndex)
    {
        lock (_gate)
        {
            return _scales[Math.Clamp(scaleIndex, 0, _scales.Count - 1)];
        }
    }

    public async Task<ScaleOperationResult> SetFilterAsync(int scaleIndex, int filterIndex)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(100)).ConfigureAwait(true);
        if (filterIndex == ScaleCalibration_DesignData.FailingFilterIndex)
        {
            return ScaleOperationResult.FilterWriteFailed;
        }

        return Update(scaleIndex, s => s.IsFaulted ? null : s with { WrittenFilterIndex = filterIndex }, ScaleOperationResult.ScaleFault);
    }

    public Task<ScaleOperationResult> SetZeroAsync(int scaleIndex) =>
        Task.FromResult(Update(scaleIndex, s => s.IsFaulted ? null : s with { Weight = 0 }, ScaleOperationResult.ScaleFault));

    public Task<ScaleOperationResult> StartCalibrationAsync(int scaleIndex) =>
        Task.FromResult(Update(scaleIndex, s => s.IsFaulted ? null : s.Step is CalibrationStep.Idle or CalibrationStep.Completed ? s with { Step = CalibrationStep.AwaitUnloaded } : null, ScaleOperationResult.NotAllowed));

    public Task<ScaleOperationResult> ConfirmUnloadedAsync(int scaleIndex) =>
        Task.FromResult(Update(scaleIndex, s => s.Step == CalibrationStep.AwaitUnloaded ? s with { Step = CalibrationStep.AwaitLoaded } : null, ScaleOperationResult.NotAllowed));

    public Task<ScaleOperationResult> ConfirmLoadedAsync(int scaleIndex) =>
        Task.FromResult(Update(scaleIndex, s => s.Step == CalibrationStep.AwaitLoaded ? s with { Step = CalibrationStep.Completed, Weight = 500 } : null, ScaleOperationResult.NotAllowed));

    public Task<ScaleOperationResult> ResetAsync(int scaleIndex) =>
        Task.FromResult(Update(scaleIndex, s => s with { Step = CalibrationStep.Idle }, ScaleOperationResult.NotAllowed));

    // Wendet die Aenderung an; liefert die Funktion null, gilt der Befehl als abgelehnt (Ergebnis <paramref name="rejected"/>).
    private ScaleOperationResult Update(int scaleIndex, Func<ScaleSnapshot, ScaleSnapshot?> change, ScaleOperationResult rejected)
    {
        var index = Math.Clamp(scaleIndex, 0, _scales.Count - 1);
        lock (_gate)
        {
            var next = change(_scales[index]);
            if (next is null)
            {
                return rejected;
            }

            _scales[index] = next;
        }

        Changed?.Invoke(this, index);
        return ScaleOperationResult.Success;
    }
}
