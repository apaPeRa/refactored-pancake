namespace ApaTec.Hmi.Models;

/// <summary>Angemeldeter Benutzer (Seitenleiste, HM-01).</summary>
public sealed record UserInfo(string Name, string Initials, UserRole Role);
