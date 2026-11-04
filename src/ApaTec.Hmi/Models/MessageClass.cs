namespace ApaTec.Hmi.Models;

/// <summary>Meldungsklasse (HM-03, A-49): Betrieb = Ok, Hinweis = Warnung, Stoerung = Fehler.</summary>
public enum MessageClass
{
    None,
    Operation,
    Notice,
    Fault,
}
