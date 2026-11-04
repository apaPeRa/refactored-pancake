using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace ApaTec.Hmi.Controls;

/// <summary>Untere Funktionsleiste (HM-06): Container fuer die seitenspezifischen Tasten (HM-07, HM-08, HM-19). Nur Dependency Properties, Darstellung in HM06_FunctionBar.Styles.xaml.</summary>
public sealed class HM06_FunctionBar : Control
{
    /// <summary>Tasten links beginnend (Beschreibungen vom Typ <c>FunctionBarItem</c>), hoechstens 5.</summary>
    public static readonly DependencyProperty ItemsProperty =
        DependencyProperty.Register(nameof(Items), typeof(IEnumerable), typeof(HM06_FunctionBar), new PropertyMetadata(null));

    /// <summary>Tasten der rechtsbuendigen Gruppe (Hauptaktion der Seite), 0 bis 2.</summary>
    public static readonly DependencyProperty TrailingItemsProperty =
        DependencyProperty.Register(nameof(TrailingItems), typeof(IEnumerable), typeof(HM06_FunctionBar), new PropertyMetadata(null));

    /// <summary>Seitenkennung (Seitenschluessel); markiert die Taste mit gleicher <c>TargetId</c> als Taste der aktuellen Seite.</summary>
    public static readonly DependencyProperty CurrentTargetIdProperty =
        DependencyProperty.Register(nameof(CurrentTargetId), typeof(string), typeof(HM06_FunctionBar), new PropertyMetadata(string.Empty));

    static HM06_FunctionBar()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM06_FunctionBar), new FrameworkPropertyMetadata(typeof(HM06_FunctionBar)));
    }

    public IEnumerable? Items
    {
        get => (IEnumerable?)GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }

    public IEnumerable? TrailingItems
    {
        get => (IEnumerable?)GetValue(TrailingItemsProperty);
        set => SetValue(TrailingItemsProperty, value);
    }

    public string CurrentTargetId
    {
        get => (string)GetValue(CurrentTargetIdProperty);
        set => SetValue(CurrentTargetIdProperty, value);
    }
}
