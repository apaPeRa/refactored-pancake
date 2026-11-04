using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ApaTec.Hmi.Controls;

/// <summary>HM-19 Blaettertasten: Pfeiltasten mit Positionsanzeige. Nur Dependency Properties, Darstellung in HM19_PagerButtons.Styles.xaml (A-73).</summary>
public class HM19_PagerButtons : Control
{
    public static readonly DependencyProperty CountProperty = DependencyProperty.Register(nameof(Count), typeof(int), typeof(HM19_PagerButtons), new PropertyMetadata(1));
    public static readonly DependencyProperty CurrentIndexProperty = DependencyProperty.Register(nameof(CurrentIndex), typeof(int), typeof(HM19_PagerButtons), new PropertyMetadata(0));
    public static readonly DependencyProperty CurrentLabelProperty = DependencyProperty.Register(nameof(CurrentLabel), typeof(string), typeof(HM19_PagerButtons), new PropertyMetadata(null));
    public static readonly DependencyProperty PagerStyleProperty = DependencyProperty.Register(nameof(PagerStyle), typeof(PagerStyle), typeof(HM19_PagerButtons), new PropertyMetadata(PagerStyle.Pair));
    public static readonly DependencyProperty PlacementProperty = DependencyProperty.Register(nameof(Placement), typeof(PagerPlacement), typeof(HM19_PagerButtons), new PropertyMetadata(PagerPlacement.FunctionBar));
    public static readonly DependencyProperty CenterContentProperty = DependencyProperty.Register(nameof(CenterContent), typeof(object), typeof(HM19_PagerButtons), new PropertyMetadata(null));
    public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(nameof(Orientation), typeof(PagerOrientation), typeof(HM19_PagerButtons), new PropertyMetadata(PagerOrientation.Horizontal));
    public static readonly DependencyProperty PositionModeProperty = DependencyProperty.Register(nameof(PositionMode), typeof(PagerPositionMode), typeof(HM19_PagerButtons), new PropertyMetadata(PagerPositionMode.Single));
    public static readonly DependencyProperty RangeStartProperty = DependencyProperty.Register(nameof(RangeStart), typeof(int), typeof(HM19_PagerButtons), new PropertyMetadata(0));
    public static readonly DependencyProperty RangeEndProperty = DependencyProperty.Register(nameof(RangeEnd), typeof(int), typeof(HM19_PagerButtons), new PropertyMetadata(0));
    public static readonly DependencyProperty IsCyclicProperty = DependencyProperty.Register(nameof(IsCyclic), typeof(bool), typeof(HM19_PagerButtons), new PropertyMetadata(false));
    public static readonly DependencyProperty PreviousCommandProperty = DependencyProperty.Register(nameof(PreviousCommand), typeof(ICommand), typeof(HM19_PagerButtons), new PropertyMetadata(null));
    public static readonly DependencyProperty NextCommandProperty = DependencyProperty.Register(nameof(NextCommand), typeof(ICommand), typeof(HM19_PagerButtons), new PropertyMetadata(null));

    static HM19_PagerButtons()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM19_PagerButtons), new FrameworkPropertyMetadata(typeof(HM19_PagerButtons)));
    }

    public int Count { get => (int)GetValue(CountProperty); set => SetValue(CountProperty, value); }

    /// <summary>Nullbasierter Index, 0 bis Count − 1.</summary>
    public int CurrentIndex { get => (int)GetValue(CurrentIndexProperty); set => SetValue(CurrentIndexProperty, value); }

    public string? CurrentLabel { get => (string?)GetValue(CurrentLabelProperty); set => SetValue(CurrentLabelProperty, value); }

    public PagerStyle PagerStyle { get => (PagerStyle)GetValue(PagerStyleProperty); set => SetValue(PagerStyleProperty, value); }

    public PagerPlacement Placement { get => (PagerPlacement)GetValue(PlacementProperty); set => SetValue(PlacementProperty, value); }

    public object? CenterContent { get => GetValue(CenterContentProperty); set => SetValue(CenterContentProperty, value); }

    public PagerOrientation Orientation { get => (PagerOrientation)GetValue(OrientationProperty); set => SetValue(OrientationProperty, value); }

    public PagerPositionMode PositionMode { get => (PagerPositionMode)GetValue(PositionModeProperty); set => SetValue(PositionModeProperty, value); }

    /// <summary>Erste angezeigte Position (1-basiert) bei <see cref="PagerPositionMode.Range"/>.</summary>
    public int RangeStart { get => (int)GetValue(RangeStartProperty); set => SetValue(RangeStartProperty, value); }

    /// <summary>Letzte angezeigte Position (1-basiert) bei <see cref="PagerPositionMode.Range"/>.</summary>
    public int RangeEnd { get => (int)GetValue(RangeEndProperty); set => SetValue(RangeEndProperty, value); }

    public bool IsCyclic { get => (bool)GetValue(IsCyclicProperty); set => SetValue(IsCyclicProperty, value); }

    public ICommand? PreviousCommand { get => (ICommand?)GetValue(PreviousCommandProperty); set => SetValue(PreviousCommandProperty, value); }

    public ICommand? NextCommand { get => (ICommand?)GetValue(NextCommandProperty); set => SetValue(NextCommandProperty, value); }
}
