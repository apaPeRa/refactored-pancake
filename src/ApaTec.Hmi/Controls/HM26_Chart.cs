using System.Windows;
using System.Windows.Controls;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Controls;

/// <summary>HM-26 Diagramm (Trend / Balken): Dependency Properties, Darstellung in HM26_Chart.Styles.xaml, Skalierung in HM26_ChartLayoutConverter.</summary>
public sealed class HM26_Chart : Control
{
    public static readonly DependencyProperty ChartKindProperty = DependencyProperty.Register(
        nameof(ChartKind), typeof(ChartKind), typeof(HM26_Chart), new PropertyMetadata(ChartKind.Line));

    public static readonly DependencyProperty SeriesProperty = DependencyProperty.Register(
        nameof(Series), typeof(IReadOnlyList<ChartPoint>), typeof(HM26_Chart), new PropertyMetadata(null));

    public static readonly DependencyProperty YUnitProperty = DependencyProperty.Register(
        nameof(YUnit), typeof(string), typeof(HM26_Chart), new PropertyMetadata(null));

    public static readonly DependencyProperty YMinimumProperty = DependencyProperty.Register(
        nameof(YMinimum), typeof(double?), typeof(HM26_Chart), new PropertyMetadata(null));

    public static readonly DependencyProperty YMaximumProperty = DependencyProperty.Register(
        nameof(YMaximum), typeof(double?), typeof(HM26_Chart), new PropertyMetadata(null));

    public static readonly DependencyProperty YStepProperty = DependencyProperty.Register(
        nameof(YStep), typeof(double), typeof(HM26_Chart), new PropertyMetadata(0d));

    public static readonly DependencyProperty MaxPointsProperty = DependencyProperty.Register(
        nameof(MaxPoints), typeof(int), typeof(HM26_Chart), new PropertyMetadata(21));

    public static readonly DependencyProperty IntervalProperty = DependencyProperty.Register(
        nameof(Interval), typeof(ChartInterval), typeof(HM26_Chart), new PropertyMetadata(ChartInterval.None));

    public static readonly DependencyProperty ShowValueLabelsProperty = DependencyProperty.Register(
        nameof(ShowValueLabels), typeof(bool), typeof(HM26_Chart), new PropertyMetadata(true));

    public static readonly DependencyProperty LowerLimitProperty = DependencyProperty.Register(
        nameof(LowerLimit), typeof(double?), typeof(HM26_Chart), new PropertyMetadata(null));

    public static readonly DependencyProperty UpperLimitProperty = DependencyProperty.Register(
        nameof(UpperLimit), typeof(double?), typeof(HM26_Chart), new PropertyMetadata(null));

    public static readonly DependencyProperty XLabelsProperty = DependencyProperty.Register(
        nameof(XLabels), typeof(IReadOnlyList<string>), typeof(HM26_Chart), new PropertyMetadata(null));

    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
        nameof(Title), typeof(string), typeof(HM26_Chart), new PropertyMetadata(null));

    /// <summary>Zustand „Lädt …“ (Erweiterung gegenueber der Parametertabelle, die Darstellung steht in der Zustandstabelle).</summary>
    public static readonly DependencyProperty IsLoadingProperty = DependencyProperty.Register(
        nameof(IsLoading), typeof(bool), typeof(HM26_Chart), new PropertyMetadata(false));

    static HM26_Chart()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM26_Chart), new FrameworkPropertyMetadata(typeof(HM26_Chart)));
    }

    public ChartKind ChartKind
    {
        get => (ChartKind)GetValue(ChartKindProperty);
        set => SetValue(ChartKindProperty, value);
    }

    public IReadOnlyList<ChartPoint>? Series
    {
        get => (IReadOnlyList<ChartPoint>?)GetValue(SeriesProperty);
        set => SetValue(SeriesProperty, value);
    }

    public string? YUnit
    {
        get => (string?)GetValue(YUnitProperty);
        set => SetValue(YUnitProperty, value);
    }

    public double? YMinimum
    {
        get => (double?)GetValue(YMinimumProperty);
        set => SetValue(YMinimumProperty, value);
    }

    public double? YMaximum
    {
        get => (double?)GetValue(YMaximumProperty);
        set => SetValue(YMaximumProperty, value);
    }

    public double YStep
    {
        get => (double)GetValue(YStepProperty);
        set => SetValue(YStepProperty, value);
    }

    public int MaxPoints
    {
        get => (int)GetValue(MaxPointsProperty);
        set => SetValue(MaxPointsProperty, value);
    }

    public ChartInterval Interval
    {
        get => (ChartInterval)GetValue(IntervalProperty);
        set => SetValue(IntervalProperty, value);
    }

    public bool ShowValueLabels
    {
        get => (bool)GetValue(ShowValueLabelsProperty);
        set => SetValue(ShowValueLabelsProperty, value);
    }

    public double? LowerLimit
    {
        get => (double?)GetValue(LowerLimitProperty);
        set => SetValue(LowerLimitProperty, value);
    }

    public double? UpperLimit
    {
        get => (double?)GetValue(UpperLimitProperty);
        set => SetValue(UpperLimitProperty, value);
    }

    public IReadOnlyList<string>? XLabels
    {
        get => (IReadOnlyList<string>?)GetValue(XLabelsProperty);
        set => SetValue(XLabelsProperty, value);
    }

    public string? Title
    {
        get => (string?)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public bool IsLoading
    {
        get => (bool)GetValue(IsLoadingProperty);
        set => SetValue(IsLoadingProperty, value);
    }
}
