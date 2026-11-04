using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ApaTec.Hmi.Navigation;

namespace ApaTec.Hmi.Controls;

/// <summary>Brotkruemel-Navigation (HM-04): Seitenpfad als Segmente, das letzte ist die aktuelle Seite. Nur Dependency Properties, Darstellung in HM04_Breadcrumb.Styles.xaml.</summary>
public sealed class HM04_Breadcrumb : Control
{
    /// <summary>Segmente des Pfads (<see cref="BreadcrumbItem"/>: Schluessel, Text, aktuell, navigierbar).</summary>
    public static readonly DependencyProperty SegmentsProperty =
        DependencyProperty.Register(nameof(Segments), typeof(IReadOnlyList<BreadcrumbItem>), typeof(HM04_Breadcrumb), new PropertyMetadata(null));

    /// <summary>Objektkennung hinter dem letzten Segment, z. B. "HD1"; leer = keine.</summary>
    public static readonly DependencyProperty ObjectSuffixProperty =
        DependencyProperty.Register(nameof(ObjectSuffix), typeof(string), typeof(HM04_Breadcrumb), new PropertyMetadata(string.Empty));

    /// <summary>Parameter: Seitenschluessel des Segments.</summary>
    public static readonly DependencyProperty NavigateCommandProperty =
        DependencyProperty.Register(nameof(NavigateCommand), typeof(ICommand), typeof(HM04_Breadcrumb), new PropertyMetadata(null));

    static HM04_Breadcrumb()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM04_Breadcrumb), new FrameworkPropertyMetadata(typeof(HM04_Breadcrumb)));
    }

    public IReadOnlyList<BreadcrumbItem>? Segments
    {
        get => (IReadOnlyList<BreadcrumbItem>?)GetValue(SegmentsProperty);
        set => SetValue(SegmentsProperty, value);
    }

    public string ObjectSuffix
    {
        get => (string)GetValue(ObjectSuffixProperty);
        set => SetValue(ObjectSuffixProperty, value);
    }

    public ICommand? NavigateCommand
    {
        get => (ICommand?)GetValue(NavigateCommandProperty);
        set => SetValue(NavigateCommandProperty, value);
    }
}
