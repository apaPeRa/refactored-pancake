using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Controls;

/// <summary>HM-29 Wochen-Zeitplan: Dependency Properties, Darstellung in HM29_WeekSchedule.Styles.xaml.</summary>
public sealed class HM29_WeekSchedule : Control
{
    public static readonly DependencyProperty EntriesProperty = DependencyProperty.Register(
        nameof(Entries), typeof(IReadOnlyList<ScheduleEntry>), typeof(HM29_WeekSchedule), new PropertyMetadata(null));

    public static readonly DependencyProperty FirstDayProperty = DependencyProperty.Register(
        nameof(FirstDay), typeof(DayOfWeek), typeof(HM29_WeekSchedule), new PropertyMetadata(DayOfWeek.Monday));

    /// <summary>Berechtigung fuer die Plus-Tasten (Schluessel/Schloss); Erweiterung gegenueber der Parametertabelle.</summary>
    public static readonly DependencyProperty IsAuthorizedProperty = DependencyProperty.Register(
        nameof(IsAuthorized), typeof(bool), typeof(HM29_WeekSchedule), new PropertyMetadata(true));

    public static readonly DependencyProperty AddCommandProperty = DependencyProperty.Register(
        nameof(AddCommand), typeof(ICommand), typeof(HM29_WeekSchedule), new PropertyMetadata(null));

    public static readonly DependencyProperty EditCommandProperty = DependencyProperty.Register(
        nameof(EditCommand), typeof(ICommand), typeof(HM29_WeekSchedule), new PropertyMetadata(null));

    static HM29_WeekSchedule()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM29_WeekSchedule), new FrameworkPropertyMetadata(typeof(HM29_WeekSchedule)));
    }

    public IReadOnlyList<ScheduleEntry>? Entries
    {
        get => (IReadOnlyList<ScheduleEntry>?)GetValue(EntriesProperty);
        set => SetValue(EntriesProperty, value);
    }

    public DayOfWeek FirstDay
    {
        get => (DayOfWeek)GetValue(FirstDayProperty);
        set => SetValue(FirstDayProperty, value);
    }

    public bool IsAuthorized
    {
        get => (bool)GetValue(IsAuthorizedProperty);
        set => SetValue(IsAuthorizedProperty, value);
    }

    public ICommand? AddCommand
    {
        get => (ICommand?)GetValue(AddCommandProperty);
        set => SetValue(AddCommandProperty, value);
    }

    public ICommand? EditCommand
    {
        get => (ICommand?)GetValue(EditCommandProperty);
        set => SetValue(EditCommandProperty, value);
    }
}
