using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ApaTec.Hmi.Controls;

/// <summary>HM-16 Kachel-Navigation: Raster aus Kacheln. Nur Dependency Properties, Darstellung in HM16_TileNavigation.Styles.xaml (A-73).</summary>
public class HM16_TileNavigation : Control
{
    public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(nameof(Items), typeof(IReadOnlyList<TileItem>), typeof(HM16_TileNavigation), new PropertyMetadata(null));
    public static readonly DependencyProperty ColumnsProperty = DependencyProperty.Register(nameof(Columns), typeof(int), typeof(HM16_TileNavigation), new PropertyMetadata(3));
    public static readonly DependencyProperty RowsProperty = DependencyProperty.Register(nameof(Rows), typeof(int), typeof(HM16_TileNavigation), new PropertyMetadata(2));
    public static readonly DependencyProperty TileSizeProperty = DependencyProperty.Register(nameof(TileSize), typeof(TileSize), typeof(HM16_TileNavigation), new PropertyMetadata(TileSize.Large));
    public static readonly DependencyProperty EmptyTileModeProperty = DependencyProperty.Register(nameof(EmptyTileMode), typeof(EmptyTileMode), typeof(HM16_TileNavigation), new PropertyMetadata(EmptyTileMode.Reserved));
    public static readonly DependencyProperty ItemKindProperty = DependencyProperty.Register(nameof(ItemKind), typeof(TileItemKind), typeof(HM16_TileNavigation), new PropertyMetadata(TileItemKind.Navigation));
    public static readonly DependencyProperty ShowNavigationIndicatorProperty = DependencyProperty.Register(nameof(ShowNavigationIndicator), typeof(bool), typeof(HM16_TileNavigation), new PropertyMetadata(true));
    public static readonly DependencyProperty NavigateCommandProperty = DependencyProperty.Register(nameof(NavigateCommand), typeof(ICommand), typeof(HM16_TileNavigation), new PropertyMetadata(null));

    static HM16_TileNavigation()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM16_TileNavigation), new FrameworkPropertyMetadata(typeof(HM16_TileNavigation)));
    }

    public IReadOnlyList<TileItem>? Items { get => (IReadOnlyList<TileItem>?)GetValue(ItemsProperty); set => SetValue(ItemsProperty, value); }

    public int Columns { get => (int)GetValue(ColumnsProperty); set => SetValue(ColumnsProperty, value); }

    public int Rows { get => (int)GetValue(RowsProperty); set => SetValue(RowsProperty, value); }

    public TileSize TileSize { get => (TileSize)GetValue(TileSizeProperty); set => SetValue(TileSizeProperty, value); }

    public EmptyTileMode EmptyTileMode { get => (EmptyTileMode)GetValue(EmptyTileModeProperty); set => SetValue(EmptyTileModeProperty, value); }

    public TileItemKind ItemKind { get => (TileItemKind)GetValue(ItemKindProperty); set => SetValue(ItemKindProperty, value); }

    public bool ShowNavigationIndicator { get => (bool)GetValue(ShowNavigationIndicatorProperty); set => SetValue(ShowNavigationIndicatorProperty, value); }

    /// <summary>Parameter: das angetippte <see cref="TileItem"/>.</summary>
    public ICommand? NavigateCommand { get => (ICommand?)GetValue(NavigateCommandProperty); set => SetValue(NavigateCommandProperty, value); }
}
