using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Controls;

/// <summary>HM-25 Meldungsliste: Dependency Properties, Darstellung in HM25_MessageList.Styles.xaml.</summary>
public sealed class HM25_MessageList : Control
{
    public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(
        nameof(Items), typeof(IReadOnlyList<MessageEntry>), typeof(HM25_MessageList), new PropertyMetadata(null));

    public static readonly DependencyProperty ListKindProperty = DependencyProperty.Register(
        nameof(ListKind), typeof(MessageListKind), typeof(HM25_MessageList), new PropertyMetadata(MessageListKind.Archive));

    public static readonly DependencyProperty SelectionModeProperty = DependencyProperty.Register(
        nameof(SelectionMode), typeof(ListSelectionMode), typeof(HM25_MessageList), new PropertyMetadata(ListSelectionMode.None));

    public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
        nameof(SelectedItem), typeof(MessageEntry), typeof(HM25_MessageList),
        new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register(
        nameof(SelectedItems), typeof(IList<MessageEntry>), typeof(HM25_MessageList), new PropertyMetadata(null));

    public static readonly DependencyProperty SortDirectionProperty = DependencyProperty.Register(
        nameof(SortDirection), typeof(SortDirection), typeof(HM25_MessageList), new PropertyMetadata(SortDirection.Descending));

    public static readonly DependencyProperty ScrollStyleProperty = DependencyProperty.Register(
        nameof(ScrollStyle), typeof(ListScrollStyle), typeof(HM25_MessageList), new PropertyMetadata(ListScrollStyle.Buttons));

    public static readonly DependencyProperty ShowClassColumnProperty = DependencyProperty.Register(
        nameof(ShowClassColumn), typeof(bool), typeof(HM25_MessageList), new PropertyMetadata(false));

    public static readonly DependencyProperty TotalCountProperty = DependencyProperty.Register(
        nameof(TotalCount), typeof(int), typeof(HM25_MessageList), new PropertyMetadata(0));

    public static readonly DependencyProperty IsFilteredProperty = DependencyProperty.Register(
        nameof(IsFiltered), typeof(bool), typeof(HM25_MessageList), new PropertyMetadata(false));

    public static readonly DependencyProperty RangeStartProperty = DependencyProperty.Register(
        nameof(RangeStart), typeof(int), typeof(HM25_MessageList), new PropertyMetadata(0));

    public static readonly DependencyProperty RangeEndProperty = DependencyProperty.Register(
        nameof(RangeEnd), typeof(int), typeof(HM25_MessageList), new PropertyMetadata(0));

    public static readonly DependencyProperty ScrollFirstCommandProperty = DependencyProperty.Register(
        nameof(ScrollFirstCommand), typeof(ICommand), typeof(HM25_MessageList), new PropertyMetadata(null));

    public static readonly DependencyProperty ScrollPageUpCommandProperty = DependencyProperty.Register(
        nameof(ScrollPageUpCommand), typeof(ICommand), typeof(HM25_MessageList), new PropertyMetadata(null));

    public static readonly DependencyProperty ScrollPageDownCommandProperty = DependencyProperty.Register(
        nameof(ScrollPageDownCommand), typeof(ICommand), typeof(HM25_MessageList), new PropertyMetadata(null));

    public static readonly DependencyProperty ScrollLastCommandProperty = DependencyProperty.Register(
        nameof(ScrollLastCommand), typeof(ICommand), typeof(HM25_MessageList), new PropertyMetadata(null));

    static HM25_MessageList()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM25_MessageList), new FrameworkPropertyMetadata(typeof(HM25_MessageList)));
    }

    public IReadOnlyList<MessageEntry>? Items
    {
        get => (IReadOnlyList<MessageEntry>?)GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }

    public MessageListKind ListKind
    {
        get => (MessageListKind)GetValue(ListKindProperty);
        set => SetValue(ListKindProperty, value);
    }

    public ListSelectionMode SelectionMode
    {
        get => (ListSelectionMode)GetValue(SelectionModeProperty);
        set => SetValue(SelectionModeProperty, value);
    }

    public MessageEntry? SelectedItem
    {
        get => (MessageEntry?)GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

    public IList<MessageEntry>? SelectedItems
    {
        get => (IList<MessageEntry>?)GetValue(SelectedItemsProperty);
        set => SetValue(SelectedItemsProperty, value);
    }

    public SortDirection SortDirection
    {
        get => (SortDirection)GetValue(SortDirectionProperty);
        set => SetValue(SortDirectionProperty, value);
    }

    public ListScrollStyle ScrollStyle
    {
        get => (ListScrollStyle)GetValue(ScrollStyleProperty);
        set => SetValue(ScrollStyleProperty, value);
    }

    public bool ShowClassColumn
    {
        get => (bool)GetValue(ShowClassColumnProperty);
        set => SetValue(ShowClassColumnProperty, value);
    }

    public int TotalCount
    {
        get => (int)GetValue(TotalCountProperty);
        set => SetValue(TotalCountProperty, value);
    }

    public bool IsFiltered
    {
        get => (bool)GetValue(IsFilteredProperty);
        set => SetValue(IsFilteredProperty, value);
    }

    /// <summary>Erste sichtbare Zeile (1-basiert) fuer die Positionsanzeige „n bis m von k“ beim Rollbalken (Erweiterung gegenueber der Moduldefinition).</summary>
    public int RangeStart
    {
        get => (int)GetValue(RangeStartProperty);
        set => SetValue(RangeStartProperty, value);
    }

    /// <summary>Letzte sichtbare Zeile (1-basiert), 0 = keine Positionsanzeige.</summary>
    public int RangeEnd
    {
        get => (int)GetValue(RangeEndProperty);
        set => SetValue(RangeEndProperty, value);
    }

    public ICommand? ScrollFirstCommand
    {
        get => (ICommand?)GetValue(ScrollFirstCommandProperty);
        set => SetValue(ScrollFirstCommandProperty, value);
    }

    public ICommand? ScrollPageUpCommand
    {
        get => (ICommand?)GetValue(ScrollPageUpCommandProperty);
        set => SetValue(ScrollPageUpCommandProperty, value);
    }

    public ICommand? ScrollPageDownCommand
    {
        get => (ICommand?)GetValue(ScrollPageDownCommandProperty);
        set => SetValue(ScrollPageDownCommandProperty, value);
    }

    public ICommand? ScrollLastCommand
    {
        get => (ICommand?)GetValue(ScrollLastCommandProperty);
        set => SetValue(ScrollLastCommandProperty, value);
    }
}
