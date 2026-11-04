using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ApaTec.Hmi.Controls;

/// <summary>Treffer der Suche.</summary>
public sealed class SearchHit
{
    /// <summary>Kennzeichnung.</summary>
    public string Identifier { get; set; } = string.Empty;

    /// <summary>Bezeichnung.</summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>Gruppe oder Karte.</summary>
    public string Group { get; set; } = string.Empty;

    /// <summary>Parameter für die Zielseite.</summary>
    public object? TargetKey { get; set; }
}

/// <summary>HM-38 Such-Pop-up: Suchzeile und Trefferliste, Inhalt von HM14_PopupFrame (HS-30, HS-31, HS-33).</summary>
public sealed class HM38_SearchDialog : Control
{
    static HM38_SearchDialog()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM38_SearchDialog), new FrameworkPropertyMetadata(typeof(HM38_SearchDialog)));
    }

    /// <summary>Titel; wird vom HM14_PopupFrame dargestellt.</summary>
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(nameof(Title), typeof(string), typeof(HM38_SearchDialog), new PropertyMetadata(string.Empty));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    /// <summary>Suchtext, höchstens 40 Zeichen.</summary>
    public static readonly DependencyProperty SearchTextProperty =
        DependencyProperty.Register(nameof(SearchText), typeof(string), typeof(HM38_SearchDialog), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public string SearchText
    {
        get => (string)GetValue(SearchTextProperty);
        set => SetValue(SearchTextProperty, value);
    }

    /// <summary>Quelle der Treffer.</summary>
    public static readonly DependencyProperty ItemsProperty =
        DependencyProperty.Register(nameof(Items), typeof(IReadOnlyList<SearchHit>?), typeof(HM38_SearchDialog), new PropertyMetadata(null));

    public IReadOnlyList<SearchHit>? Items
    {
        get => (IReadOnlyList<SearchHit>?)GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }

    /// <summary>Gefilterte Treffer (vom ViewModel berechnet).</summary>
    public static readonly DependencyProperty FilteredItemsProperty =
        DependencyProperty.Register(nameof(FilteredItems), typeof(IReadOnlyList<SearchHit>?), typeof(HM38_SearchDialog), new PropertyMetadata(null));

    public IReadOnlyList<SearchHit>? FilteredItems
    {
        get => (IReadOnlyList<SearchHit>?)GetValue(FilteredItemsProperty);
        set => SetValue(FilteredItemsProperty, value);
    }

    /// <summary>Gewählter Treffer.</summary>
    public static readonly DependencyProperty SelectedHitProperty =
        DependencyProperty.Register(nameof(SelectedHit), typeof(SearchHit?), typeof(HM38_SearchDialog), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public SearchHit? SelectedHit
    {
        get => (SearchHit?)GetValue(SelectedHitProperty);
        set => SetValue(SelectedHitProperty, value);
    }

    /// <summary>Leertext; null = Standardtext Kein Treffer.</summary>
    public static readonly DependencyProperty EmptyTextProperty =
        DependencyProperty.Register(nameof(EmptyText), typeof(string?), typeof(HM38_SearchDialog), new PropertyMetadata(null));

    public string? EmptyText
    {
        get => (string?)GetValue(EmptyTextProperty);
        set => SetValue(EmptyTextProperty, value);
    }

    /// <summary>Platzhalter der Suchzeile.</summary>
    public static readonly DependencyProperty PlaceholderProperty =
        DependencyProperty.Register(nameof(Placeholder), typeof(string?), typeof(HM38_SearchDialog), new PropertyMetadata(null));

    public string? Placeholder
    {
        get => (string?)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    /// <summary>Treffer antippen (Parameter: SearchHit).</summary>
    public static readonly DependencyProperty SelectHitCommandProperty =
        DependencyProperty.Register(nameof(SelectHitCommand), typeof(ICommand?), typeof(HM38_SearchDialog), new PropertyMetadata(null));

    public ICommand? SelectHitCommand
    {
        get => (ICommand?)GetValue(SelectHitCommandProperty);
        set => SetValue(SelectHitCommandProperty, value);
    }

    /// <summary>Abbrechen ohne Wirkung.</summary>
    public static readonly DependencyProperty CancelCommandProperty =
        DependencyProperty.Register(nameof(CancelCommand), typeof(ICommand?), typeof(HM38_SearchDialog), new PropertyMetadata(null));

    public ICommand? CancelCommand
    {
        get => (ICommand?)GetValue(CancelCommandProperty);
        set => SetValue(CancelCommandProperty, value);
    }

    /// <summary>Suchtext löschen.</summary>
    public static readonly DependencyProperty ClearTextCommandProperty =
        DependencyProperty.Register(nameof(ClearTextCommand), typeof(ICommand?), typeof(HM38_SearchDialog), new PropertyMetadata(null));

    public ICommand? ClearTextCommand
    {
        get => (ICommand?)GetValue(ClearTextCommandProperty);
        set => SetValue(ClearTextCommandProperty, value);
    }

    /// <summary>Liste nach oben.</summary>
    public static readonly DependencyProperty ScrollUpCommandProperty =
        DependencyProperty.Register(nameof(ScrollUpCommand), typeof(ICommand?), typeof(HM38_SearchDialog), new PropertyMetadata(null));

    public ICommand? ScrollUpCommand
    {
        get => (ICommand?)GetValue(ScrollUpCommandProperty);
        set => SetValue(ScrollUpCommandProperty, value);
    }

    /// <summary>Liste nach unten.</summary>
    public static readonly DependencyProperty ScrollDownCommandProperty =
        DependencyProperty.Register(nameof(ScrollDownCommand), typeof(ICommand?), typeof(HM38_SearchDialog), new PropertyMetadata(null));

    public ICommand? ScrollDownCommand
    {
        get => (ICommand?)GetValue(ScrollDownCommandProperty);
        set => SetValue(ScrollDownCommandProperty, value);
    }
}
