using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ApaTec.Hmi.Controls;

/// <summary>Zeile der Nockentabelle.</summary>
public sealed class CamRow : ObservableObject
{
    private int number;

    public int Number
    {
        get => number;
        set => SetProperty(ref number, value);
    }

    private string name = string.Empty;

    public string Name
    {
        get => name;
        set => SetProperty(ref name, value);
    }

    private double startAngle;

    public double StartAngle
    {
        get => startAngle;
        set => SetProperty(ref startAngle, value);
    }

    private double endAngle;

    public double EndAngle
    {
        get => endAngle;
        set => SetProperty(ref endAngle, value);
    }

    private bool isActive;

    public bool IsActive
    {
        get => isActive;
        set => SetProperty(ref isActive, value);
    }
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
