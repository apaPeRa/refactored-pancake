namespace ApaTec.Hmi.Models;

/// <summary>Filter des Meldearchivs (HS-37): Meldenummer genau, Zeit ab (Annahme S37-5). Leere Kriterien sind null.</summary>
public sealed record ArchiveFilter(int? Number, DateTime? From)
{
    public bool IsEmpty => Number is null && From is null;
}
