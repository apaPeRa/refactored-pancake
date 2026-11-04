namespace ApaTec.Hmi.Models;

/// <summary>Betriebsart der Maschine (Kopfzeile, HM-02). Aufzaehlung erweiterbar (OP-22).</summary>
public enum OperatingMode
{
    Production,
    Setup,
    Manual,
    Service,
    Fault,
}
