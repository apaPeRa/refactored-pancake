using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Controls;

/// <summary>HM-31 Leimspuren-Grafik: Dependency Properties, Darstellung in HM31_GlueTrackGraphic.Styles.xaml.</summary>
public sealed class HM31_GlueTrackGraphic : Control
{
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
        nameof(Title), typeof(string), typeof(HM31_GlueTrackGraphic), new PropertyMetadata(null));

    public static readonly DependencyProperty FieldsProperty = DependencyProperty.Register(
        nameof(Fields), typeof(IReadOnlyList<GlueTrackField>), typeof(HM31_GlueTrackGraphic), new PropertyMetadata(null));

    public static readonly DependencyProperty CutoutGeometryProperty = DependencyProperty.Register(
        nameof(CutoutGeometry), typeof(Geometry), typeof(HM31_GlueTrackGraphic), new PropertyMetadata(null));

    public static readonly DependencyProperty CommitCommandProperty = DependencyProperty.Register(
        nameof(CommitCommand), typeof(ICommand), typeof(HM31_GlueTrackGraphic), new PropertyMetadata(null));

    static HM31_GlueTrackGraphic()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM31_GlueTrackGraphic), new FrameworkPropertyMetadata(typeof(HM31_GlueTrackGraphic)));
    }

    public string? Title
    {
        get => (string?)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public IReadOnlyList<GlueTrackField>? Fields
    {
        get => (IReadOnlyList<GlueTrackField>?)GetValue(FieldsProperty);
        set => SetValue(FieldsProperty, value);
    }

    public Geometry? CutoutGeometry
    {
        get => (Geometry?)GetValue(CutoutGeometryProperty);
        set => SetValue(CutoutGeometryProperty, value);
    }

    public ICommand? CommitCommand
    {
        get => (ICommand?)GetValue(CommitCommandProperty);
        set => SetValue(CommitCommandProperty, value);
    }
}
