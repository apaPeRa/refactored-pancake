using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ApaTec.Hmi.Controls;

/// <summary>Art eines EA-Kanals.</summary>
public enum IoKind
{
    /// <summary>Digitalkanal mit Status-LED.</summary>
    Digital,

    /// <summary>Analogkanal mit Zahlenwert.</summary>
    Analog,
}

/// <summary>HM-36 EA-Zeile (Signalzeile): Status-LED oder Analogwert, SPS-Kennung und Klartext (HS-34).</summary>
public sealed class HM36_IoRow : Control
{
    static HM36_IoRow()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM36_IoRow), new FrameworkPropertyMetadata(typeof(HM36_IoRow)));
    }

    /// <summary>SPS-Kennung.</summary>
    public static readonly DependencyProperty IdentifierProperty =
        DependencyProperty.Register(nameof(Identifier), typeof(string), typeof(HM36_IoRow), new PropertyMetadata(string.Empty));

    public string Identifier
    {
        get => (string)GetValue(IdentifierProperty);
        set => SetValue(IdentifierProperty, value);
    }

    /// <summary>Klartext.</summary>
    public static readonly DependencyProperty DescriptionProperty =
        DependencyProperty.Register(nameof(Description), typeof(string), typeof(HM36_IoRow), new PropertyMetadata(string.Empty));

    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    /// <summary>Art des Kanals.</summary>
    public static readonly DependencyProperty IoKindProperty =
        DependencyProperty.Register(nameof(IoKind), typeof(IoKind), typeof(HM36_IoRow), new PropertyMetadata(IoKind.Digital));

    public IoKind IoKind
    {
        get => (IoKind)GetValue(IoKindProperty);
        set => SetValue(IoKindProperty, value);
    }

    /// <summary>Digitalzustand.</summary>
    public static readonly DependencyProperty StateProperty =
        DependencyProperty.Register(nameof(State), typeof(LedState), typeof(HM36_IoRow), new PropertyMetadata(LedState.Off));

    public LedState State
    {
        get => (LedState)GetValue(StateProperty);
        set => SetValue(StateProperty, value);
    }

    /// <summary>Analogwert; null = unbekannt (---).</summary>
    public static readonly DependencyProperty AnalogValueProperty =
        DependencyProperty.Register(nameof(AnalogValue), typeof(double?), typeof(HM36_IoRow), new PropertyMetadata(null));

    public double? AnalogValue
    {
        get => (double?)GetValue(AnalogValueProperty);
        set => SetValue(AnalogValueProperty, value);
    }

    /// <summary>Reservekanal (Klartext in Sekundärfarbe; Ergänzung).</summary>
    public static readonly DependencyProperty IsReserveProperty =
        DependencyProperty.Register(nameof(IsReserve), typeof(bool), typeof(HM36_IoRow), new PropertyMetadata(false));

    public bool IsReserve
    {
        get => (bool)GetValue(IsReserveProperty);
        set => SetValue(IsReserveProperty, value);
    }
}
