namespace ApaTec.Hmi.Models;

/// <summary>Eintrag der Seitenleiste (HM-01): Home, Einstellungen, Meldungen. Das Symbol wird ueber den Token-Namen (<see cref="IconKey"/>) aufgeloest.</summary>
public sealed class SidebarItem
{
    /// <summary>Kennung (<c>SidebarItemIds</c>), vergleicht sich mit <c>CurrentItemId</c>.</summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>Kurzbeschriftung (sichtbar und Barrierefreiheitsname), aus den Ressourcen.</summary>
    public string Label { get; set; } = string.Empty;

    /// <summary>Token-Name des Symbols, z. B. <c>Icon.Home</c>.</summary>
    public string IconKey { get; set; } = string.Empty;

    /// <summary>true: der Eintrag traegt den Zaehler-Punkt der neuen Meldungen (Meldungen).</summary>
    public bool ShowsBadge { get; set; }
}
