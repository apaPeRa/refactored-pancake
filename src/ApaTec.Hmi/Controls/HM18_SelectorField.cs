using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ApaTec.Hmi.Controls;

/// <summary>HM-18 Auswahlfeld mit Pfeiltasten. Nur Dependency Properties, Darstellung in HM18_SelectorField.Styles.xaml (A-73).</summary>
public class HM18_SelectorField : Control
{
    public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(nameof(Label), typeof(string), typeof(HM18_SelectorField), new PropertyMetadata(null));
    public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(nameof(ItemsSource), typeof(IEnumerable), typeof(HM18_SelectorField), new PropertyMetadata(null));
    public static readonly DependencyProperty SelectedIndexProperty = DependencyProperty.Register(nameof(SelectedIndex), typeof(int), typeof(HM18_SelectorField), new PropertyMetadata(0));
    public static readonly DependencyProperty DisplayTextProperty = DependencyProperty.Register(nameof(DisplayText), typeof(string), typeof(HM18_SelectorField), new PropertyMetadata(string.Empty));
    public static readonly DependencyProperty IsCyclicProperty = DependencyProperty.Register(nameof(IsCyclic), typeof(bool), typeof(HM18_SelectorField), new PropertyMetadata(false));
    public static readonly DependencyProperty RequiresApplyProperty = DependencyProperty.Register(nameof(RequiresApply), typeof(bool), typeof(HM18_SelectorField), new PropertyMetadata(false));
    public static readonly DependencyProperty IsPendingProperty = DependencyProperty.Register(nameof(IsPending), typeof(bool), typeof(HM18_SelectorField), new PropertyMetadata(false));
    public static readonly DependencyProperty RequiresPermissionProperty = DependencyProperty.Register(nameof(RequiresPermission), typeof(bool), typeof(HM18_SelectorField), new PropertyMetadata(false));
    public static readonly DependencyProperty IsAuthorizedProperty = DependencyProperty.Register(nameof(IsAuthorized), typeof(bool), typeof(HM18_SelectorField), new PropertyMetadata(true));
    public static readonly DependencyProperty AllowDirectEntryProperty = DependencyProperty.Register(nameof(AllowDirectEntry), typeof(bool), typeof(HM18_SelectorField), new PropertyMetadata(false));
    public static readonly DependencyProperty DirectEntryCommandProperty = DependencyProperty.Register(nameof(DirectEntryCommand), typeof(ICommand), typeof(HM18_SelectorField), new PropertyMetadata(null));
    public static readonly DependencyProperty PreviousCommandProperty = DependencyProperty.Register(nameof(PreviousCommand), typeof(ICommand), typeof(HM18_SelectorField), new PropertyMetadata(null));
    public static readonly DependencyProperty NextCommandProperty = DependencyProperty.Register(nameof(NextCommand), typeof(ICommand), typeof(HM18_SelectorField), new PropertyMetadata(null));

    static HM18_SelectorField()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM18_SelectorField), new FrameworkPropertyMetadata(typeof(HM18_SelectorField)));
    }

    public string? Label { get => (string?)GetValue(LabelProperty); set => SetValue(LabelProperty, value); }

    public IEnumerable? ItemsSource { get => (IEnumerable?)GetValue(ItemsSourceProperty); set => SetValue(ItemsSourceProperty, value); }

    public int SelectedIndex { get => (int)GetValue(SelectedIndexProperty); set => SetValue(SelectedIndexProperty, value); }

    public string DisplayText { get => (string)GetValue(DisplayTextProperty); set => SetValue(DisplayTextProperty, value); }

    public bool IsCyclic { get => (bool)GetValue(IsCyclicProperty); set => SetValue(IsCyclicProperty, value); }

    public bool RequiresApply { get => (bool)GetValue(RequiresApplyProperty); set => SetValue(RequiresApplyProperty, value); }

    /// <summary>Ergaenzung zur Moduldefinition: Auswahl getroffen, aber noch nicht uebernommen (nur bei <see cref="RequiresApply"/>); zeigt „Nicht uebernommen“ mit <c>Icon.State.Pending</c>.</summary>
    public bool IsPending { get => (bool)GetValue(IsPendingProperty); set => SetValue(IsPendingProperty, value); }

    public bool RequiresPermission { get => (bool)GetValue(RequiresPermissionProperty); set => SetValue(RequiresPermissionProperty, value); }

    public bool IsAuthorized { get => (bool)GetValue(IsAuthorizedProperty); set => SetValue(IsAuthorizedProperty, value); }

    public bool AllowDirectEntry { get => (bool)GetValue(AllowDirectEntryProperty); set => SetValue(AllowDirectEntryProperty, value); }

    public ICommand? DirectEntryCommand { get => (ICommand?)GetValue(DirectEntryCommandProperty); set => SetValue(DirectEntryCommandProperty, value); }

    public ICommand? PreviousCommand { get => (ICommand?)GetValue(PreviousCommandProperty); set => SetValue(PreviousCommandProperty, value); }

    public ICommand? NextCommand { get => (ICommand?)GetValue(NextCommandProperty); set => SetValue(NextCommandProperty, value); }
}
