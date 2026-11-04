using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ApaTec.Hmi.Controls;

/// <summary>HM-17 Titelzeile (Objektueberschrift) mit optionalen Kennwerten und Detail-Symbol. Nur Dependency Properties (A-73).</summary>
public class HM17_TitleBar : Control
{
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string), typeof(HM17_TitleBar), new PropertyMetadata(string.Empty));
    public static readonly DependencyProperty ValuesProperty = DependencyProperty.Register(nameof(Values), typeof(IReadOnlyList<TitleValue>), typeof(HM17_TitleBar), new PropertyMetadata(null));
    public static readonly DependencyProperty DeviationLimitProperty = DependencyProperty.Register(nameof(DeviationLimit), typeof(double?), typeof(HM17_TitleBar), new PropertyMetadata(null));
    public static readonly DependencyProperty HasDeviationProperty = DependencyProperty.Register(nameof(HasDeviation), typeof(bool), typeof(HM17_TitleBar), new PropertyMetadata(false));
    public static readonly DependencyProperty DetailCommandProperty = DependencyProperty.Register(nameof(DetailCommand), typeof(ICommand), typeof(HM17_TitleBar), new PropertyMetadata(null));
    public static readonly DependencyProperty TitleAlignmentProperty = DependencyProperty.Register(nameof(TitleAlignment), typeof(TitleAlignment), typeof(HM17_TitleBar), new PropertyMetadata(TitleAlignment.Center));

    static HM17_TitleBar()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM17_TitleBar), new FrameworkPropertyMetadata(typeof(HM17_TitleBar)));
    }

    public string Title { get => (string)GetValue(TitleProperty); set => SetValue(TitleProperty, value); }

    public IReadOnlyList<TitleValue>? Values { get => (IReadOnlyList<TitleValue>?)GetValue(ValuesProperty); set => SetValue(ValuesProperty, value); }

    public double? DeviationLimit { get => (double?)GetValue(DeviationLimitProperty); set => SetValue(DeviationLimitProperty, value); }

    /// <summary>Ergaenzung zur Moduldefinition: vom ViewModel aus <see cref="DeviationLimit"/> und den Kennwerten berechnet (die Vorlage rechnet nicht).</summary>
    public bool HasDeviation { get => (bool)GetValue(HasDeviationProperty); set => SetValue(HasDeviationProperty, value); }

    public ICommand? DetailCommand { get => (ICommand?)GetValue(DetailCommandProperty); set => SetValue(DetailCommandProperty, value); }

    public TitleAlignment TitleAlignment { get => (TitleAlignment)GetValue(TitleAlignmentProperty); set => SetValue(TitleAlignmentProperty, value); }
}
