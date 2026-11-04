using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Controls;

/// <summary>Meldezeile (HM-03): wichtigste aktuelle Meldung im Format "NNN: Text", Antippen oeffnet die Meldeanzeige. Nur Dependency Properties, Darstellung in HM03_MessageLine.Styles.xaml.</summary>
public sealed class HM03_MessageLine : Button
{
    /// <summary>Meldenummer 0 bis 999 (dreistellig angezeigt); null = ohne Nummer (Hinweistext).</summary>
    public static readonly DependencyProperty NumberProperty =
        DependencyProperty.Register(nameof(Number), typeof(int?), typeof(HM03_MessageLine), new PropertyMetadata(null));

    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(nameof(Text), typeof(string), typeof(HM03_MessageLine), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty ClassProperty =
        DependencyProperty.Register(nameof(Class), typeof(MessageClass), typeof(HM03_MessageLine), new PropertyMetadata(MessageClass.None));

    /// <summary>Weitere Meldungen neben der angezeigten (Zaehler "+ n"); 0 = keiner.</summary>
    public static readonly DependencyProperty AdditionalCountProperty =
        DependencyProperty.Register(nameof(AdditionalCount), typeof(int), typeof(HM03_MessageLine), new PropertyMetadata(0));

    public static readonly DependencyProperty OpenCommandProperty =
        DependencyProperty.Register(nameof(OpenCommand), typeof(ICommand), typeof(HM03_MessageLine), new PropertyMetadata(null));

    static HM03_MessageLine()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM03_MessageLine), new FrameworkPropertyMetadata(typeof(HM03_MessageLine)));
    }

    public int? Number
    {
        get => (int?)GetValue(NumberProperty);
        set => SetValue(NumberProperty, value);
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public MessageClass Class
    {
        get => (MessageClass)GetValue(ClassProperty);
        set => SetValue(ClassProperty, value);
    }

    public int AdditionalCount
    {
        get => (int)GetValue(AdditionalCountProperty);
        set => SetValue(AdditionalCountProperty, value);
    }

    public ICommand? OpenCommand
    {
        get => (ICommand?)GetValue(OpenCommandProperty);
        set => SetValue(OpenCommandProperty, value);
    }
}
