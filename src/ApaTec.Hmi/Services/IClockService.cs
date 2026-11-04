namespace ApaTec.Hmi.Services;

/// <summary>Uhrzeit und Datum fuer die Kopfzeile (HM-02, A-77).</summary>
public interface IClockService
{
    DateTime Now { get; }

    /// <summary>Wird einmal pro Sekunde ausgeloest (ggf. nicht im UI-Thread).</summary>
    event EventHandler? Tick;
}
