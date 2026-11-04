using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace ApaTec.Hmi.Controls;

// Die Eingabeart InputKind (Number, Time, Text, Filter) wird mit HM-13 geteilt und ist in HM13_NumericKeypadDialog.Types.cs definiert.

/// <summary>
/// HM-12 Eingabefeld mit Schluesselsymbol: antippbares Feld fuer einen Einstellwert. Nur Dependency Properties (A-73); das Antippen loest den von
/// <see cref="ButtonBase.Command"/> gebundenen Befehl des ViewModels aus (Eingabe-Pop-up bzw. Benutzer-Pop-up), die Uebernahme meldet <see cref="CommitCommand"/>.
/// Darstellung in <c>HM12_ValueInput.Styles.xaml</c>. Als Custom Control auf <see cref="Button"/> (statt UserControl) umgesetzt, damit kein Code-behind entsteht.
/// </summary>
public class HM12_ValueInput : Button
{
    public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
        nameof(Label), typeof(string), typeof(HM12_ValueInput), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty NumberValueProperty = DependencyProperty.Register(
        nameof(NumberValue), typeof(double?), typeof(HM12_ValueInput), new PropertyMetadata(null));

    public static readonly DependencyProperty TextValueProperty = DependencyProperty.Register(
        nameof(TextValue), typeof(string), typeof(HM12_ValueInput), new PropertyMetadata(null));

    public static readonly DependencyProperty InputKindProperty = DependencyProperty.Register(
        nameof(InputKind), typeof(InputKind), typeof(HM12_ValueInput), new PropertyMetadata(InputKind.Number));

    public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
        nameof(Unit), typeof(string), typeof(HM12_ValueInput), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty DecimalsProperty = DependencyProperty.Register(
        nameof(Decimals), typeof(int), typeof(HM12_ValueInput), new PropertyMetadata(0));

    public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register(
        nameof(Minimum), typeof(double?), typeof(HM12_ValueInput), new PropertyMetadata(null));

    public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register(
        nameof(Maximum), typeof(double?), typeof(HM12_ValueInput), new PropertyMetadata(null));

    public static readonly DependencyProperty RequiresPermissionProperty = DependencyProperty.Register(
        nameof(RequiresPermission), typeof(bool), typeof(HM12_ValueInput), new PropertyMetadata(true));

    public static readonly DependencyProperty RequiredRoleProperty = DependencyProperty.Register(
        nameof(RequiredRole), typeof(string), typeof(HM12_ValueInput), new PropertyMetadata(null));

    public static readonly DependencyProperty IsAuthorizedProperty = DependencyProperty.Register(
        nameof(IsAuthorized), typeof(bool), typeof(HM12_ValueInput), new PropertyMetadata(true));

    public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
        nameof(Icon), typeof(Geometry), typeof(HM12_ValueInput), new PropertyMetadata(null));

    public static readonly DependencyProperty CounterProperty = DependencyProperty.Register(
        nameof(Counter), typeof(int?), typeof(HM12_ValueInput), new PropertyMetadata(null));

    public static readonly DependencyProperty CoupledCounterProperty = DependencyProperty.Register(
        nameof(CoupledCounter), typeof(int?), typeof(HM12_ValueInput), new PropertyMetadata(null));

    public static readonly DependencyProperty IsPendingWriteProperty = DependencyProperty.Register(
        nameof(IsPendingWrite), typeof(bool), typeof(HM12_ValueInput), new PropertyMetadata(false));

    public static readonly DependencyProperty ErrorTextProperty = DependencyProperty.Register(
        nameof(ErrorText), typeof(string), typeof(HM12_ValueInput), new PropertyMetadata(null));

    public static readonly DependencyProperty CommitCommandProperty = DependencyProperty.Register(
        nameof(CommitCommand), typeof(ICommand), typeof(HM12_ValueInput), new PropertyMetadata(null));

    // Ergaenzung zur Moduldefinition: Zustand "In Bearbeitung" (Eingabe-Pop-up offen), setzt das ViewModel.
    public static readonly DependencyProperty IsEditingProperty = DependencyProperty.Register(
        nameof(IsEditing), typeof(bool), typeof(HM12_ValueInput), new PropertyMetadata(false));

    static HM12_ValueInput()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM12_ValueInput), new FrameworkPropertyMetadata(typeof(HM12_ValueInput)));
    }

    public string Label
    {
        get => (string)GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    /// <summary>Zahlenwert; bei <see cref="InputKind.Time"/> Minuten seit 00:00 (Annahme, Anzeige hh:mm).</summary>
    public double? NumberValue
    {
        get => (double?)GetValue(NumberValueProperty);
        set => SetValue(NumberValueProperty, value);
    }

    public string? TextValue
    {
        get => (string?)GetValue(TextValueProperty);
        set => SetValue(TextValueProperty, value);
    }

    public InputKind InputKind
    {
        get => (InputKind)GetValue(InputKindProperty);
        set => SetValue(InputKindProperty, value);
    }

    public string Unit
    {
        get => (string)GetValue(UnitProperty);
        set => SetValue(UnitProperty, value);
    }

    public int Decimals
    {
        get => (int)GetValue(DecimalsProperty);
        set => SetValue(DecimalsProperty, value);
    }

    public double? Minimum
    {
        get => (double?)GetValue(MinimumProperty);
        set => SetValue(MinimumProperty, value);
    }

    public double? Maximum
    {
        get => (double?)GetValue(MaximumProperty);
        set => SetValue(MaximumProperty, value);
    }

    public bool RequiresPermission
    {
        get => (bool)GetValue(RequiresPermissionProperty);
        set => SetValue(RequiresPermissionProperty, value);
    }

    public string? RequiredRole
    {
        get => (string?)GetValue(RequiredRoleProperty);
        set => SetValue(RequiredRoleProperty, value);
    }

    public bool IsAuthorized
    {
        get => (bool)GetValue(IsAuthorizedProperty);
        set => SetValue(IsAuthorizedProperty, value);
    }

    public Geometry? Icon
    {
        get => (Geometry?)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public int? Counter
    {
        get => (int?)GetValue(CounterProperty);
        set => SetValue(CounterProperty, value);
    }

    public int? CoupledCounter
    {
        get => (int?)GetValue(CoupledCounterProperty);
        set => SetValue(CoupledCounterProperty, value);
    }

    public bool IsPendingWrite
    {
        get => (bool)GetValue(IsPendingWriteProperty);
        set => SetValue(IsPendingWriteProperty, value);
    }

    public string? ErrorText
    {
        get => (string?)GetValue(ErrorTextProperty);
        set => SetValue(ErrorTextProperty, value);
    }

    public ICommand? CommitCommand
    {
        get => (ICommand?)GetValue(CommitCommandProperty);
        set => SetValue(CommitCommandProperty, value);
    }

    public bool IsEditing
    {
        get => (bool)GetValue(IsEditingProperty);
        set => SetValue(IsEditingProperty, value);
    }
}

/// <summary>Hilfswandler fuer die Vorlage von HM-12: true, wenn der Text nicht leer ist (Fehlerzustand).</summary>
[ValueConversion(typeof(string), typeof(bool))]
public sealed class HM12_HasTextConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is string text && text.Length > 0;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotSupportedException();
}

/// <summary>
/// Textformat des Werts in HM-12: Zahl mit <c>CurrentCulture</c> und Nachkommastellen, Zeit als "hh:mm" (Minuten seit 00:00), Text unveraendert; leer ergibt "---".
/// Eingaben: InputKind, NumberValue, TextValue, Decimals. Die Einheit setzt die Vorlage hinter einem geschuetzten Leerzeichen an.
/// </summary>
public sealed class HM12_ValueTextConverter : IMultiValueConverter
{
    private const string Invalid = "---";

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length < 4 || values[0] is not InputKind kind)
        {
            return Invalid;
        }

        var decimals = values[3] is int d ? Math.Clamp(d, 0, 3) : 0;
        return kind switch
        {
            InputKind.Number => values[1] is double number ? number.ToString("N" + decimals, culture) : Invalid,
            InputKind.Time => values[1] is double minutes ? TimeSpan.FromMinutes(minutes).ToString(@"hh\:mm", culture) : values[2] is string { Length: > 0 } timeText ? timeText : Invalid,
            InputKind.Text => values[2] is string { Length: > 0 } text ? text : Invalid,
            _ => Invalid,
        };
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotSupportedException();
}
