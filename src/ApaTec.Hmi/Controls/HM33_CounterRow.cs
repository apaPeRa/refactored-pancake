using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ApaTec.Hmi.Controls;

/// <summary>HM-33 Zählerzeile: Beschriftung, Zähler und Zeitpunkt des Zurücksetzens (HS-02).</summary>
public sealed class HM33_CounterRow : Control
{
    static HM33_CounterRow()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM33_CounterRow), new FrameworkPropertyMetadata(typeof(HM33_CounterRow)));
    }

    /// <summary>Zeilenname (Aktuell, Historie 1 bis 12).</summary>
    public static readonly DependencyProperty RowNameProperty =
        DependencyProperty.Register(nameof(RowName), typeof(string), typeof(HM33_CounterRow), new PropertyMetadata(string.Empty));

    public string RowName
    {
        get => (string)GetValue(RowNameProperty);
        set => SetValue(RowNameProperty, value);
    }

    /// <summary>Zähler in Stück.</summary>
    public static readonly DependencyProperty CountProperty =
        DependencyProperty.Register(nameof(Count), typeof(long), typeof(HM33_CounterRow), new PropertyMetadata(0L));

    public long Count
    {
        get => (long)GetValue(CountProperty);
        set => SetValue(CountProperty, value);
    }

    /// <summary>Zeitpunkt des Zurücksetzens; null = leer.</summary>
    public static readonly DependencyProperty ResetTimeProperty =
        DependencyProperty.Register(nameof(ResetTime), typeof(DateTime?), typeof(HM33_CounterRow), new PropertyMetadata(null));

    public DateTime? ResetTime
    {
        get => (DateTime?)GetValue(ResetTimeProperty);
        set => SetValue(ResetTimeProperty, value);
    }

    /// <summary>Nur die erste Zeile (Aktuell).</summary>
    public static readonly DependencyProperty IsCurrentProperty =
        DependencyProperty.Register(nameof(IsCurrent), typeof(bool), typeof(HM33_CounterRow), new PropertyMetadata(false));

    public bool IsCurrent
    {
        get => (bool)GetValue(IsCurrentProperty);
        set => SetValue(IsCurrentProperty, value);
    }
}
