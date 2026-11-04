using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Controls;

/// <summary>Kopfzeile (HM-02): Logo, Meldezeile (HM-03), Betriebsart, Uhrzeit und Datum im Raster 12* : 13* : 6* : 4*. Nur Dependency Properties, Darstellung in HM02_HeaderBar.Styles.xaml.</summary>
public sealed class HM02_HeaderBar : Control
{
    /// <summary>Logo-Grafik des aktuellen Themas; null zeigt den Platzhaltertext (A-78, OP-66).</summary>
    public static readonly DependencyProperty LogoSourceProperty =
        DependencyProperty.Register(nameof(LogoSource), typeof(ImageSource), typeof(HM02_HeaderBar), new PropertyMetadata(null));

    public static readonly DependencyProperty OperatingModeProperty =
        DependencyProperty.Register(nameof(OperatingMode), typeof(OperatingMode), typeof(HM02_HeaderBar), new PropertyMetadata(OperatingMode.Production));

    /// <summary>Wort der Betriebsart (aus den Ressourcen).</summary>
    public static readonly DependencyProperty OperatingModeTextProperty =
        DependencyProperty.Register(nameof(OperatingModeText), typeof(string), typeof(HM02_HeaderBar), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty NowProperty =
        DependencyProperty.Register(nameof(Now), typeof(DateTime), typeof(HM02_HeaderBar), new PropertyMetadata(default(DateTime)));

    public static readonly DependencyProperty ShowSecondsProperty =
        DependencyProperty.Register(nameof(ShowSeconds), typeof(bool), typeof(HM02_HeaderBar), new PropertyMetadata(true));

    public static readonly DependencyProperty IsTimeValidProperty =
        DependencyProperty.Register(nameof(IsTimeValid), typeof(bool), typeof(HM02_HeaderBar), new PropertyMetadata(true));

    /// <summary>false: Kopfzeile ohne Meldezeile, das Raster bleibt (Vollbild HS-24).</summary>
    public static readonly DependencyProperty ShowMessageLineProperty =
        DependencyProperty.Register(nameof(ShowMessageLine), typeof(bool), typeof(HM02_HeaderBar), new PropertyMetadata(true));

    // An die Meldezeile (HM-03) durchgereicht
    public static readonly DependencyProperty MessageNumberProperty =
        DependencyProperty.Register(nameof(MessageNumber), typeof(int?), typeof(HM02_HeaderBar), new PropertyMetadata(null));

    public static readonly DependencyProperty MessageTextProperty =
        DependencyProperty.Register(nameof(MessageText), typeof(string), typeof(HM02_HeaderBar), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty MessageClassProperty =
        DependencyProperty.Register(nameof(MessageClass), typeof(MessageClass), typeof(HM02_HeaderBar), new PropertyMetadata(MessageClass.None));

    public static readonly DependencyProperty AdditionalMessageCountProperty =
        DependencyProperty.Register(nameof(AdditionalMessageCount), typeof(int), typeof(HM02_HeaderBar), new PropertyMetadata(0));

    public static readonly DependencyProperty MessageCommandProperty =
        DependencyProperty.Register(nameof(MessageCommand), typeof(ICommand), typeof(HM02_HeaderBar), new PropertyMetadata(null));

    static HM02_HeaderBar()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM02_HeaderBar), new FrameworkPropertyMetadata(typeof(HM02_HeaderBar)));
    }

    public ImageSource? LogoSource
    {
        get => (ImageSource?)GetValue(LogoSourceProperty);
        set => SetValue(LogoSourceProperty, value);
    }

    public OperatingMode OperatingMode
    {
        get => (OperatingMode)GetValue(OperatingModeProperty);
        set => SetValue(OperatingModeProperty, value);
    }

    public string OperatingModeText
    {
        get => (string)GetValue(OperatingModeTextProperty);
        set => SetValue(OperatingModeTextProperty, value);
    }

    public DateTime Now
    {
        get => (DateTime)GetValue(NowProperty);
        set => SetValue(NowProperty, value);
    }

    public bool ShowSeconds
    {
        get => (bool)GetValue(ShowSecondsProperty);
        set => SetValue(ShowSecondsProperty, value);
    }

    public bool IsTimeValid
    {
        get => (bool)GetValue(IsTimeValidProperty);
        set => SetValue(IsTimeValidProperty, value);
    }

    public bool ShowMessageLine
    {
        get => (bool)GetValue(ShowMessageLineProperty);
        set => SetValue(ShowMessageLineProperty, value);
    }

    public int? MessageNumber
    {
        get => (int?)GetValue(MessageNumberProperty);
        set => SetValue(MessageNumberProperty, value);
    }

    public string MessageText
    {
        get => (string)GetValue(MessageTextProperty);
        set => SetValue(MessageTextProperty, value);
    }

    public MessageClass MessageClass
    {
        get => (MessageClass)GetValue(MessageClassProperty);
        set => SetValue(MessageClassProperty, value);
    }

    public int AdditionalMessageCount
    {
        get => (int)GetValue(AdditionalMessageCountProperty);
        set => SetValue(AdditionalMessageCountProperty, value);
    }

    public ICommand? MessageCommand
    {
        get => (ICommand?)GetValue(MessageCommandProperty);
        set => SetValue(MessageCommandProperty, value);
    }
}
