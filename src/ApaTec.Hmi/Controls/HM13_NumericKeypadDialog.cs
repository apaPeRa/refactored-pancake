using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ApaTec.Hmi.Controls;

/// <summary>HM-13 Eingabe-Pop-up (Ziffernblock). Inhalt von <see cref="HM14_PopupFrame"/>; nur Dependency Properties, Darstellung in HM13_NumericKeypadDialog.Styles.xaml (A-73).</summary>
public class HM13_NumericKeypadDialog : Control
{
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string), typeof(HM13_NumericKeypadDialog), new PropertyMetadata(string.Empty));
    public static readonly DependencyProperty CurrentValueProperty = DependencyProperty.Register(nameof(CurrentValue), typeof(double?), typeof(HM13_NumericKeypadDialog), new PropertyMetadata(null));
    public static readonly DependencyProperty InputTextProperty = DependencyProperty.Register(nameof(InputText), typeof(string), typeof(HM13_NumericKeypadDialog), new PropertyMetadata(string.Empty));
    public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(nameof(Unit), typeof(string), typeof(HM13_NumericKeypadDialog), new PropertyMetadata(string.Empty));
    public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register(nameof(Minimum), typeof(double?), typeof(HM13_NumericKeypadDialog), new PropertyMetadata(null));
    public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register(nameof(Maximum), typeof(double?), typeof(HM13_NumericKeypadDialog), new PropertyMetadata(null));
    public static readonly DependencyProperty DecimalsProperty = DependencyProperty.Register(nameof(Decimals), typeof(int), typeof(HM13_NumericKeypadDialog), new PropertyMetadata(0));
    public static readonly DependencyProperty InputKindProperty = DependencyProperty.Register(nameof(InputKind), typeof(InputKind), typeof(HM13_NumericKeypadDialog), new PropertyMetadata(InputKind.Number));
    public static readonly DependencyProperty HelpTextProperty = DependencyProperty.Register(nameof(HelpText), typeof(string), typeof(HM13_NumericKeypadDialog), new PropertyMetadata(null));
    public static readonly DependencyProperty FilterFieldsProperty = DependencyProperty.Register(nameof(FilterFields), typeof(IReadOnlyList<FilterField>), typeof(HM13_NumericKeypadDialog), new PropertyMetadata(null));
    public static readonly DependencyProperty IsValidProperty = DependencyProperty.Register(nameof(IsValid), typeof(bool), typeof(HM13_NumericKeypadDialog), new PropertyMetadata(false));
    public static readonly DependencyProperty ErrorTextProperty = DependencyProperty.Register(nameof(ErrorText), typeof(string), typeof(HM13_NumericKeypadDialog), new PropertyMetadata(null));
    public static readonly DependencyProperty ApplyCommandProperty = DependencyProperty.Register(nameof(ApplyCommand), typeof(ICommand), typeof(HM13_NumericKeypadDialog), new PropertyMetadata(null));
    public static readonly DependencyProperty CancelCommandProperty = DependencyProperty.Register(nameof(CancelCommand), typeof(ICommand), typeof(HM13_NumericKeypadDialog), new PropertyMetadata(null));
    public static readonly DependencyProperty DigitCommandProperty = DependencyProperty.Register(nameof(DigitCommand), typeof(ICommand), typeof(HM13_NumericKeypadDialog), new PropertyMetadata(null));
    public static readonly DependencyProperty BackspaceCommandProperty = DependencyProperty.Register(nameof(BackspaceCommand), typeof(ICommand), typeof(HM13_NumericKeypadDialog), new PropertyMetadata(null));
    public static readonly DependencyProperty ClearCommandProperty = DependencyProperty.Register(nameof(ClearCommand), typeof(ICommand), typeof(HM13_NumericKeypadDialog), new PropertyMetadata(null));
    public static readonly DependencyProperty SignCommandProperty = DependencyProperty.Register(nameof(SignCommand), typeof(ICommand), typeof(HM13_NumericKeypadDialog), new PropertyMetadata(null));
    public static readonly DependencyProperty DecimalSeparatorCommandProperty = DependencyProperty.Register(nameof(DecimalSeparatorCommand), typeof(ICommand), typeof(HM13_NumericKeypadDialog), new PropertyMetadata(null));

    static HM13_NumericKeypadDialog()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM13_NumericKeypadDialog), new FrameworkPropertyMetadata(typeof(HM13_NumericKeypadDialog)));
    }

    public string Title { get => (string)GetValue(TitleProperty); set => SetValue(TitleProperty, value); }

    public double? CurrentValue { get => (double?)GetValue(CurrentValueProperty); set => SetValue(CurrentValueProperty, value); }

    public string InputText { get => (string)GetValue(InputTextProperty); set => SetValue(InputTextProperty, value); }

    public string Unit { get => (string)GetValue(UnitProperty); set => SetValue(UnitProperty, value); }

    public double? Minimum { get => (double?)GetValue(MinimumProperty); set => SetValue(MinimumProperty, value); }

    public double? Maximum { get => (double?)GetValue(MaximumProperty); set => SetValue(MaximumProperty, value); }

    public int Decimals { get => (int)GetValue(DecimalsProperty); set => SetValue(DecimalsProperty, value); }

    public InputKind InputKind { get => (InputKind)GetValue(InputKindProperty); set => SetValue(InputKindProperty, value); }

    public string? HelpText { get => (string?)GetValue(HelpTextProperty); set => SetValue(HelpTextProperty, value); }

    public IReadOnlyList<FilterField>? FilterFields { get => (IReadOnlyList<FilterField>?)GetValue(FilterFieldsProperty); set => SetValue(FilterFieldsProperty, value); }

    public bool IsValid { get => (bool)GetValue(IsValidProperty); set => SetValue(IsValidProperty, value); }

    public string? ErrorText { get => (string?)GetValue(ErrorTextProperty); set => SetValue(ErrorTextProperty, value); }

    public ICommand? ApplyCommand { get => (ICommand?)GetValue(ApplyCommandProperty); set => SetValue(ApplyCommandProperty, value); }

    public ICommand? CancelCommand { get => (ICommand?)GetValue(CancelCommandProperty); set => SetValue(CancelCommandProperty, value); }

    /// <summary>Ziffer als <c>CommandParameter</c> (string), auch fuer das Komma.</summary>
    public ICommand? DigitCommand { get => (ICommand?)GetValue(DigitCommandProperty); set => SetValue(DigitCommandProperty, value); }

    public ICommand? BackspaceCommand { get => (ICommand?)GetValue(BackspaceCommandProperty); set => SetValue(BackspaceCommandProperty, value); }

    public ICommand? ClearCommand { get => (ICommand?)GetValue(ClearCommandProperty); set => SetValue(ClearCommandProperty, value); }

    public ICommand? SignCommand { get => (ICommand?)GetValue(SignCommandProperty); set => SetValue(SignCommandProperty, value); }

    public ICommand? DecimalSeparatorCommand { get => (ICommand?)GetValue(DecimalSeparatorCommandProperty); set => SetValue(DecimalSeparatorCommandProperty, value); }
}
