using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ApaTec.Hmi.Controls;

/// <summary>Zeile der Nockentabelle.</summary>
public sealed partial class CamRow : ObservableObject
{
    [ObservableProperty]
    private int number;

    [ObservableProperty]
    private string name = string.Empty;

    [ObservableProperty]
    private double startAngle;

    [ObservableProperty]
    private double endAngle;

    [ObservableProperty]
    private bool isActive;
}

/// <summary>HM-23 Nockentabelle: Nummer, Bezeichnung, Start, Ende, Status.</summary>
public sealed class HM23_CamTable : Control
{
    static HM23_CamTable()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM23_CamTable), new FrameworkPropertyMetadata(typeof(HM23_CamTable)));
    }

    /// <summary>Zeilen (Nocken).</summary>
    public static readonly DependencyProperty RowsProperty =
        DependencyProperty.Register(nameof(Rows), typeof(IReadOnlyList<CamRow>), typeof(HM23_CamTable), new PropertyMetadata(null));

    public IReadOnlyList<CamRow>? Rows
    {
        get => (IReadOnlyList<CamRow>?)GetValue(RowsProperty);
        set => SetValue(RowsProperty, value);
    }

    /// <summary>Zeilen je Seite (abgeleitet aus der verfuegbaren Hoehe, vom ViewModel gesetzt).</summary>
    public static readonly DependencyProperty RowsPerPageProperty =
        DependencyProperty.Register(nameof(RowsPerPage), typeof(int), typeof(HM23_CamTable), new PropertyMetadata(11));

    public int RowsPerPage
    {
        get => (int)GetValue(RowsPerPageProperty);
        set => SetValue(RowsPerPageProperty, value);
    }

    /// <summary>Ausgewaehlte Nockennummer.</summary>
    public static readonly DependencyProperty SelectedNumberProperty =
        DependencyProperty.Register(nameof(SelectedNumber), typeof(int?), typeof(HM23_CamTable), new PropertyMetadata(null));

    public int? SelectedNumber
    {
        get => (int?)GetValue(SelectedNumberProperty);
        set => SetValue(SelectedNumberProperty, value);
    }

    /// <summary>Auswahl einer Nockennummer (Parameter: Nummer).</summary>
    public static readonly DependencyProperty SelectCommandProperty =
        DependencyProperty.Register(nameof(SelectCommand), typeof(ICommand), typeof(HM23_CamTable), new PropertyMetadata(null));

    public ICommand? SelectCommand
    {
        get => (ICommand?)GetValue(SelectCommandProperty);
        set => SetValue(SelectCommandProperty, value);
    }
}
