namespace ApaTec.Hmi.Models;

/// <summary>Anzuzeigende Meldung der Meldezeile (HM-03). <see cref="Number"/> ist bei Hinweistexten ohne Meldenummer null.</summary>
public sealed record MessageInfo(int? Number, string Text, MessageClass Class);
