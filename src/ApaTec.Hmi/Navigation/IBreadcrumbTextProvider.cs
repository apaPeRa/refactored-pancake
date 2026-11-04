namespace ApaTec.Hmi.Navigation;

/// <summary>
/// Optional fuer Seiten-ViewModels mit dynamischem Brotkruemel-Segment (HS-31 Gruppe, HS-34 Karte) und/oder Objektkennung (HS-11, HS-12, HS-20).
/// Nach einer Aenderung <see cref="INavigationService.RefreshBreadcrumb"/> aufrufen.
/// </summary>
public interface IBreadcrumbTextProvider
{
    /// <summary>Ersetzt den Text des letzten Segments; null = Ressourcentext.</summary>
    string? GetCrumbText();

    /// <summary>Zusatz hinter dem Segmenttext (z. B. "HD1"); null = kein Zusatz.</summary>
    string? ObjectSuffix { get; }
}
