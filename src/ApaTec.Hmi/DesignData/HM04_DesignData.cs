using ApaTec.Hmi.Navigation;

namespace ApaTec.Hmi.DesignData;

/// <summary>Beispielpfade fuer den Entwurfsmodus der Brotkruemel-Navigation (HM-04, Pfade des Designs, HM-04-P01).</summary>
public static class HM04_DesignData
{
    /// <summary>DS-03: Einstellung &gt; Zufuehrung Karton &gt; Heissleimgeraet (3 Segmente).</summary>
    public static IReadOnlyList<BreadcrumbItem> ThreeSegments { get; } = new[]
    {
        new BreadcrumbItem(PageKeys.Settings, "Einstellung", false, true),
        new BreadcrumbItem(PageKeys.FeederCarton, "Zuführung Karton", false, true),
        new BreadcrumbItem(PageKeys.HotGlueNordson, "Heißleimgerät", true, false),
    };

    /// <summary>DS-01: Produktion (1 Segment, aktuell).</summary>
    public static IReadOnlyList<BreadcrumbItem> OneSegment { get; } = new[]
    {
        new BreadcrumbItem(PageKeys.Production, "Produktion", true, false),
    };
}
