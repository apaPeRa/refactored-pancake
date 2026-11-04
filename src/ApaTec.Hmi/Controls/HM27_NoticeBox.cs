using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Controls;

/// <summary>HM-27 Hinweis-Textfeld: Dependency Properties, Darstellung in HM27_NoticeBox.Styles.xaml.</summary>
public sealed class HM27_NoticeBox : Control
{
    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
        nameof(Text), typeof(string), typeof(HM27_NoticeBox), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty KindProperty = DependencyProperty.Register(
        nameof(Kind), typeof(NoticeKind), typeof(HM27_NoticeBox), new PropertyMetadata(NoticeKind.Info));

    public static readonly DependencyProperty SeverityProperty = DependencyProperty.Register(
        nameof(Severity), typeof(NoticeSeverity), typeof(HM27_NoticeBox), new PropertyMetadata(NoticeSeverity.None));

    public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register(
        nameof(Caption), typeof(string), typeof(HM27_NoticeBox), new PropertyMetadata(null));

    public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
        nameof(Icon), typeof(Geometry), typeof(HM27_NoticeBox), new PropertyMetadata(null));

    /// <summary>Entspricht „Sichtbar (IsVisible)“ der Moduldefinition; umbenannt, weil <c>UIElement.IsVisible</c> bereits belegt ist.</summary>
    public static readonly DependencyProperty IsShownProperty = DependencyProperty.Register(
        nameof(IsShown), typeof(bool), typeof(HM27_NoticeBox), new PropertyMetadata(true));

    static HM27_NoticeBox()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM27_NoticeBox), new FrameworkPropertyMetadata(typeof(HM27_NoticeBox)));
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public NoticeKind Kind
    {
        get => (NoticeKind)GetValue(KindProperty);
        set => SetValue(KindProperty, value);
    }

    public NoticeSeverity Severity
    {
        get => (NoticeSeverity)GetValue(SeverityProperty);
        set => SetValue(SeverityProperty, value);
    }

    public string? Caption
    {
        get => (string?)GetValue(CaptionProperty);
        set => SetValue(CaptionProperty, value);
    }

    public Geometry? Icon
    {
        get => (Geometry?)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public bool IsShown
    {
        get => (bool)GetValue(IsShownProperty);
        set => SetValue(IsShownProperty, value);
    }
}
