namespace ApaTec.Hmi.Models;

/// <summary>Geber/Antrieb der Seite Geber setzen (HS-32): laufende Nummer und Bezeichnung aus der Konfiguration.</summary>
public sealed record EncoderInfo(int Index, string Designation);

/// <summary>
/// Momentaufnahme eines Gebers (HS-32). Der Offset ist Motor minus Geber und wird automatisch berechnet, nicht editierbar.
/// <c>null</c> = ungueltig beziehungsweise unbekannt.
/// </summary>
public sealed record EncoderState(
    bool IsReachable,
    double? MotorPosition,
    double? EncoderPosition,
    bool? IsInitialized,
    string? StatusText,
    string? Message,
    bool IsFault)
{
    /// <summary>Positions-Offset (Motor minus Geber); null, wenn eine der beiden Positionen fehlt.</summary>
    public double? PositionOffset => MotorPosition is { } motor && EncoderPosition is { } encoder ? motor - encoder : null;
}
