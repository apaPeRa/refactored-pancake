using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ApaTec.Hmi.Controls;

/// <summary>HM-14 Pop-up-Rahmen: Titelzeile mit Schliessen-Kreuz, freier Inhalt, Tasten unten. Nur Dependency Properties, Darstellung in HM14_PopupFrame.Styles.xaml (A-73).</summary>
public class HM14_PopupFrame : ContentControl
{
    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string), typeof(HM14_PopupFrame), new PropertyMetadata(string.Empty));
    public static readonly DependencyProperty WidthRatioProperty = DependencyProperty.Register(nameof(WidthRatio), typeof(double), typeof(HM14_PopupFrame), new PropertyMetadata(0.6));
    public static readonly DependencyProperty IsModalProperty = DependencyProperty.Register(nameof(IsModal), typeof(bool), typeof(HM14_PopupFrame), new PropertyMetadata(true));
    public static readonly DependencyProperty ShowCloseButtonProperty = DependencyProperty.Register(nameof(ShowCloseButton), typeof(bool), typeof(HM14_PopupFrame), new PropertyMetadata(true));
    public static readonly DependencyProperty KindProperty = DependencyProperty.Register(nameof(Kind), typeof(PopupKind), typeof(HM14_PopupFrame), new PropertyMetadata(PopupKind.Content));
    public static readonly DependencyProperty MessageProperty = DependencyProperty.Register(nameof(Message), typeof(string), typeof(HM14_PopupFrame), new PropertyMetadata(null));
    public static readonly DependencyProperty ConfirmTextProperty = DependencyProperty.Register(nameof(ConfirmText), typeof(string), typeof(HM14_PopupFrame), new PropertyMetadata(null));
    public static readonly DependencyProperty CancelTextProperty = DependencyProperty.Register(nameof(CancelText), typeof(string), typeof(HM14_PopupFrame), new PropertyMetadata(null));
    public static readonly DependencyProperty ProgressProperty = DependencyProperty.Register(nameof(Progress), typeof(double?), typeof(HM14_PopupFrame), new PropertyMetadata(null));
    public static readonly DependencyProperty IsBusyProperty = DependencyProperty.Register(nameof(IsBusy), typeof(bool), typeof(HM14_PopupFrame), new PropertyMetadata(false));
    public static readonly DependencyProperty ResultKindProperty = DependencyProperty.Register(nameof(ResultKind), typeof(ResultKind), typeof(HM14_PopupFrame), new PropertyMetadata(ResultKind.None));
    public static readonly DependencyProperty DialogResultProperty = DependencyProperty.Register(nameof(DialogResult), typeof(bool?), typeof(HM14_PopupFrame), new PropertyMetadata(null));
    public static readonly DependencyProperty CloseCommandProperty = DependencyProperty.Register(nameof(CloseCommand), typeof(ICommand), typeof(HM14_PopupFrame), new PropertyMetadata(null));
    public static readonly DependencyProperty ConfirmCommandProperty = DependencyProperty.Register(nameof(ConfirmCommand), typeof(ICommand), typeof(HM14_PopupFrame), new PropertyMetadata(null));
    public static readonly DependencyProperty CancelCommandProperty = DependencyProperty.Register(nameof(CancelCommand), typeof(ICommand), typeof(HM14_PopupFrame), new PropertyMetadata(null));

    static HM14_PopupFrame()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM14_PopupFrame), new FrameworkPropertyMetadata(typeof(HM14_PopupFrame)));
    }

    public string Title { get => (string)GetValue(TitleProperty); set => SetValue(TitleProperty, value); }

    /// <summary>Anteil an der Fensterbreite, 0,3 bis 0,6, Standard 0,6.</summary>
    public double WidthRatio { get => (double)GetValue(WidthRatioProperty); set => SetValue(WidthRatioProperty, value); }

    public bool IsModal { get => (bool)GetValue(IsModalProperty); set => SetValue(IsModalProperty, value); }

    public bool ShowCloseButton { get => (bool)GetValue(ShowCloseButtonProperty); set => SetValue(ShowCloseButtonProperty, value); }

    public PopupKind Kind { get => (PopupKind)GetValue(KindProperty); set => SetValue(KindProperty, value); }

    public string? Message { get => (string?)GetValue(MessageProperty); set => SetValue(MessageProperty, value); }

    /// <summary>Tastentext; null = Standardtext aus den Ressourcen („Ja“).</summary>
    public string? ConfirmText { get => (string?)GetValue(ConfirmTextProperty); set => SetValue(ConfirmTextProperty, value); }

    /// <summary>Tastentext; null = Standardtext aus den Ressourcen („Abbrechen“).</summary>
    public string? CancelText { get => (string?)GetValue(CancelTextProperty); set => SetValue(CancelTextProperty, value); }

    /// <summary>Fortschritt 0 bis 100 %; null bei <see cref="IsBusy"/> = unbestimmt.</summary>
    public double? Progress { get => (double?)GetValue(ProgressProperty); set => SetValue(ProgressProperty, value); }

    /// <summary>Ergaenzung zur Moduldefinition: Datei-/Ergebnis-Pop-up laeuft (Fortschritt sichtbar, Tasten deaktiviert).</summary>
    public bool IsBusy { get => (bool)GetValue(IsBusyProperty); set => SetValue(IsBusyProperty, value); }

    public ResultKind ResultKind { get => (ResultKind)GetValue(ResultKindProperty); set => SetValue(ResultKindProperty, value); }

    public bool? DialogResult { get => (bool?)GetValue(DialogResultProperty); set => SetValue(DialogResultProperty, value); }

    public ICommand? CloseCommand { get => (ICommand?)GetValue(CloseCommandProperty); set => SetValue(CloseCommandProperty, value); }

    public ICommand? ConfirmCommand { get => (ICommand?)GetValue(ConfirmCommandProperty); set => SetValue(ConfirmCommandProperty, value); }

    public ICommand? CancelCommand { get => (ICommand?)GetValue(CancelCommandProperty); set => SetValue(CancelCommandProperty, value); }
}
