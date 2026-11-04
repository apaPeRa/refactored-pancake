using System.Windows;
using System.Windows.Controls;

namespace ApaTec.Hmi.Controls;

/// <summary>HM-15 Gruppenbereich: Container mit Ueberschrift (Panel oder nur Ueberschrift mit Trennlinie). <c>Header</c> und <c>Content</c> stammen von <see cref="HeaderedContentControl"/>. Nur Dependency Properties (A-73).</summary>
public class HM15_GroupPanel : HeaderedContentControl
{
    public static readonly DependencyProperty SubheaderProperty = DependencyProperty.Register(nameof(Subheader), typeof(string), typeof(HM15_GroupPanel), new PropertyMetadata(null));
    public static readonly DependencyProperty GroupStyleProperty = DependencyProperty.Register(nameof(GroupStyle), typeof(GroupStyle), typeof(HM15_GroupPanel), new PropertyMetadata(GroupStyle.Panel));
    public static readonly DependencyProperty IsHighlightedProperty = DependencyProperty.Register(nameof(IsHighlighted), typeof(bool), typeof(HM15_GroupPanel), new PropertyMetadata(false));
    public static readonly DependencyProperty HighlightTextProperty = DependencyProperty.Register(nameof(HighlightText), typeof(string), typeof(HM15_GroupPanel), new PropertyMetadata(null));

    static HM15_GroupPanel()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM15_GroupPanel), new FrameworkPropertyMetadata(typeof(HM15_GroupPanel)));
    }

    public string? Subheader { get => (string?)GetValue(SubheaderProperty); set => SetValue(SubheaderProperty, value); }

    public GroupStyle GroupStyle { get => (GroupStyle)GetValue(GroupStyleProperty); set => SetValue(GroupStyleProperty, value); }

    public bool IsHighlighted { get => (bool)GetValue(IsHighlightedProperty); set => SetValue(IsHighlightedProperty, value); }

    /// <summary>Text der Hervorhebung (z. B. „Ausgewaehlt“); null = Standardtext aus den Ressourcen.</summary>
    public string? HighlightText { get => (string?)GetValue(HighlightTextProperty); set => SetValue(HighlightTextProperty, value); }
}
