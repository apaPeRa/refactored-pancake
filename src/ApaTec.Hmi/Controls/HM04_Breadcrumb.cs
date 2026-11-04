using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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

/// <summary>Zusammengefasste mittlere Segmente des Brotkruemel-Pfads (Anzeige "…", HM-04); die verdeckten Segmente stehen im Pop-up hinter der Taste.</summary>
public sealed record HM04_CollapsedSegment(IReadOnlyList<BreadcrumbItem> HiddenSegments, ICommand? NavigateCommand);

/// <summary>
/// Kuerzt den Pfad bei mehr als <see cref="MaxSegments"/> Segmenten: erstes Segment, "…" (<see cref="HM04_CollapsedSegment"/>) und die letzten drei Segmente.
/// </summary>
public sealed class HM04_CollapseConverter : IMultiValueConverter
{
    /// <summary>Hoechstzahl sichtbarer Segmente (inklusive der Taste "…").</summary>
    public const int MaxSegments = 5;

    /// <summary>values[0] = Segmente, values[1] = Navigationsbefehl des Controls.</summary>
    public object? Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values.Length == 0 || values[0] is not IEnumerable items)
        {
            return null;
        }

        var all = items.OfType<BreadcrumbItem>().ToList();
        if (all.Count <= MaxSegments)
        {
            return all;
        }

        var command = values.Length > 1 ? values[1] as ICommand : null;
        var tail = MaxSegments - 2;
        var result = new List<object> { all[0], new HM04_CollapsedSegment(all.GetRange(1, all.Count - 1 - tail), command) };
        result.AddRange(all.GetRange(all.Count - tail, tail));
        return result;
    }

    public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture) => throw new NotSupportedException();
}
