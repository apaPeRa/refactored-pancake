using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services;

/// <summary>Elektronisches Nockenschaltwerk (HS-25, HS-26; Konzept.md 6.6).</summary>
public interface ICamService
{
    int FirstNumber { get; }

    int LastNumber { get; }

    IReadOnlyList<string> EncoderNames { get; }

    MachineValueLimits GetLimits(CamField field);

    IReadOnlyList<CamSummary> GetOverview();

    CamDetail GetDetail(int number);

    CamLiveData GetLive(CamDetail cam);

    /// <summary>Ergebnis fuer Anfang/Ende (Bedeutung offen, OP-48): Dummy ohne Fachlogik.</summary>
    double CalculateResult(double angle, double timeMs);

    Task<bool> WriteAsync(CamDetail detail);
}
