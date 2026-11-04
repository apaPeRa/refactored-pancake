using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ApaTec.Hmi.Controls;

/// <summary>Eintrag der Seitenleiste (HM-01): Symbol mit Kurzbeschriftung, optional mit Zaehler-Punkt. Nur Dependency Properties, Darstellung im Template.</summary>
public sealed class HM01_SidebarButton : Button
{
    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register(nameof(Icon), typeof(Geometry), typeof(HM01_SidebarButton), new PropertyMetadata(null));

    public static readonly DependencyProperty LabelProperty =
        DependencyProperty.Register(nameof(Label), typeof(string), typeof(HM01_SidebarButton), new PropertyMetadata(string.Empty));

    /// <summary>Eintrag der aktuellen Seite: Balken links und hellerer Grund.</summary>
    public static readonly DependencyProperty IsCurrentProperty =
        DependencyProperty.Register(nameof(IsCurrent), typeof(bool), typeof(HM01_SidebarButton), new PropertyMetadata(false));

    /// <summary>Wirkt deaktiviert (gestrichelte Kontur), bleibt aber antippbar (Zurueck auf der Startseite nennt den Grund in der Meldezeile, A-28).</summary>
    public static readonly DependencyProperty IsDimmedProperty =
        DependencyProperty.Register(nameof(IsDimmed), typeof(bool), typeof(HM01_SidebarButton), new PropertyMetadata(false));

    /// <summary>Neue Meldungen im Zaehler-Punkt; 0 = kein Punkt.</summary>
    public static readonly DependencyProperty BadgeCountProperty =
        DependencyProperty.Register(nameof(BadgeCount), typeof(int), typeof(HM01_SidebarButton), new PropertyMetadata(0));

    static HM01_SidebarButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM01_SidebarButton), new FrameworkPropertyMetadata(typeof(HM01_SidebarButton)));
    }

    public Geometry? Icon
    {
        get => (Geometry?)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public string Label
    {
        get => (string)GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    public bool IsCurrent
    {
        get => (bool)GetValue(IsCurrentProperty);
        set => SetValue(IsCurrentProperty, value);
    }

    public bool IsDimmed
    {
        get => (bool)GetValue(IsDimmedProperty);
        set => SetValue(IsDimmedProperty, value);
    }

    public int BadgeCount
    {
        get => (int)GetValue(BadgeCountProperty);
        set => SetValue(BadgeCountProperty, value);
    }
}
