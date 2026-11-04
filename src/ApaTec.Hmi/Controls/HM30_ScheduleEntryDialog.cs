using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Controls;

/// <summary>HM-30 Zeitplan-Eintrag-Pop-up (Inhalt von HM14_PopupFrame): Dependency Properties, Darstellung in HM30_ScheduleEntryDialog.Styles.xaml.</summary>
public sealed class HM30_ScheduleEntryDialog : Control
{
    public static readonly DependencyProperty KindProperty = DependencyProperty.Register(
        nameof(Kind), typeof(ScheduleKind), typeof(HM30_ScheduleEntryDialog),
        new FrameworkPropertyMetadata(ScheduleKind.Heat, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public static readonly DependencyProperty StartActiveProperty = DependencyProperty.Register(
        nameof(StartActive), typeof(bool), typeof(HM30_ScheduleEntryDialog),
        new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public static readonly DependencyProperty EndActiveProperty = DependencyProperty.Register(
        nameof(EndActive), typeof(bool), typeof(HM30_ScheduleEntryDialog),
        new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public static readonly DependencyProperty StartTimeProperty = DependencyProperty.Register(
        nameof(StartTime), typeof(TimeOnly?), typeof(HM30_ScheduleEntryDialog),
        new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public static readonly DependencyProperty EndTimeProperty = DependencyProperty.Register(
        nameof(EndTime), typeof(TimeOnly?), typeof(HM30_ScheduleEntryDialog),
        new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public static readonly DependencyProperty ChildCountProperty = DependencyProperty.Register(
        nameof(ChildCount), typeof(int), typeof(HM30_ScheduleEntryDialog), new PropertyMetadata(0));

    public static readonly DependencyProperty IsNewProperty = DependencyProperty.Register(
        nameof(IsNew), typeof(bool), typeof(HM30_ScheduleEntryDialog), new PropertyMetadata(true));

    public static readonly DependencyProperty ErrorTextProperty = DependencyProperty.Register(
        nameof(ErrorText), typeof(string), typeof(HM30_ScheduleEntryDialog), new PropertyMetadata(null));

    public static readonly DependencyProperty ApplyCommandProperty = DependencyProperty.Register(
        nameof(ApplyCommand), typeof(ICommand), typeof(HM30_ScheduleEntryDialog), new PropertyMetadata(null));

    public static readonly DependencyProperty CancelCommandProperty = DependencyProperty.Register(
        nameof(CancelCommand), typeof(ICommand), typeof(HM30_ScheduleEntryDialog), new PropertyMetadata(null));

    public static readonly DependencyProperty DeleteCommandProperty = DependencyProperty.Register(
        nameof(DeleteCommand), typeof(ICommand), typeof(HM30_ScheduleEntryDialog), new PropertyMetadata(null));

    // Ergaenzungen: Befehle der eingebetteten Module HM-18 (Pfeiltasten) und HM-12 (Antippen oeffnet HM-13) liefert das ViewModel, Code-behind gibt es nicht.
    public static readonly DependencyProperty PreviousKindCommandProperty = DependencyProperty.Register(
        nameof(PreviousKindCommand), typeof(ICommand), typeof(HM30_ScheduleEntryDialog), new PropertyMetadata(null));

    public static readonly DependencyProperty NextKindCommandProperty = DependencyProperty.Register(
        nameof(NextKindCommand), typeof(ICommand), typeof(HM30_ScheduleEntryDialog), new PropertyMetadata(null));

    public static readonly DependencyProperty EditStartTimeCommandProperty = DependencyProperty.Register(
        nameof(EditStartTimeCommand), typeof(ICommand), typeof(HM30_ScheduleEntryDialog), new PropertyMetadata(null));

    public static readonly DependencyProperty EditEndTimeCommandProperty = DependencyProperty.Register(
        nameof(EditEndTimeCommand), typeof(ICommand), typeof(HM30_ScheduleEntryDialog), new PropertyMetadata(null));

    static HM30_ScheduleEntryDialog()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM30_ScheduleEntryDialog), new FrameworkPropertyMetadata(typeof(HM30_ScheduleEntryDialog)));
    }

    public ScheduleKind Kind
    {
        get => (ScheduleKind)GetValue(KindProperty);
        set => SetValue(KindProperty, value);
    }

    public bool StartActive
    {
        get => (bool)GetValue(StartActiveProperty);
        set => SetValue(StartActiveProperty, value);
    }

    public bool EndActive
    {
        get => (bool)GetValue(EndActiveProperty);
        set => SetValue(EndActiveProperty, value);
    }

    public TimeOnly? StartTime
    {
        get => (TimeOnly?)GetValue(StartTimeProperty);
        set => SetValue(StartTimeProperty, value);
    }

    public TimeOnly? EndTime
    {
        get => (TimeOnly?)GetValue(EndTimeProperty);
        set => SetValue(EndTimeProperty, value);
    }

    public int ChildCount
    {
        get => (int)GetValue(ChildCountProperty);
        set => SetValue(ChildCountProperty, value);
    }

    public bool IsNew
    {
        get => (bool)GetValue(IsNewProperty);
        set => SetValue(IsNewProperty, value);
    }

    public string? ErrorText
    {
        get => (string?)GetValue(ErrorTextProperty);
        set => SetValue(ErrorTextProperty, value);
    }

    public ICommand? ApplyCommand
    {
        get => (ICommand?)GetValue(ApplyCommandProperty);
        set => SetValue(ApplyCommandProperty, value);
    }

    public ICommand? CancelCommand
    {
        get => (ICommand?)GetValue(CancelCommandProperty);
        set => SetValue(CancelCommandProperty, value);
    }

    public ICommand? DeleteCommand
    {
        get => (ICommand?)GetValue(DeleteCommandProperty);
        set => SetValue(DeleteCommandProperty, value);
    }

    public ICommand? PreviousKindCommand
    {
        get => (ICommand?)GetValue(PreviousKindCommandProperty);
        set => SetValue(PreviousKindCommandProperty, value);
    }

    public ICommand? NextKindCommand
    {
        get => (ICommand?)GetValue(NextKindCommandProperty);
        set => SetValue(NextKindCommandProperty, value);
    }

    public ICommand? EditStartTimeCommand
    {
        get => (ICommand?)GetValue(EditStartTimeCommandProperty);
        set => SetValue(EditStartTimeCommandProperty, value);
    }

    public ICommand? EditEndTimeCommand
    {
        get => (ICommand?)GetValue(EditEndTimeCommandProperty);
        set => SetValue(EditEndTimeCommandProperty, value);
    }
}
