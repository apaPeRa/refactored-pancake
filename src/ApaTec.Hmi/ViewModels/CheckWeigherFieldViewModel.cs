using ApaTec.Hmi.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// Zustand eines Eingabefelds (HM-12) der Kontrollwaage (HS-13): Wert, Einheit, Grenzen, Zaehler, Fehlertext und Bearbeitungszustand.
/// Die Oberflaeche bindet ein HM-12 mit <c>DataContext="{Binding TargetWeight}"</c> usw.; das Antippen ruft die vom Seiten-ViewModel uebergebene Bearbeitung.
/// </summary>
public sealed partial class CheckWeigherFieldViewModel : ObservableObject
{
    private readonly Func<CheckWeigherFieldViewModel, Task> _edit;

    public CheckWeigherFieldViewModel(CheckWeigherParameter parameter, string label, string baseUnit, int decimals, Func<CheckWeigherFieldViewModel, Task>? edit = null)
    {
        Parameter = parameter;
        Label = label;
        BaseUnit = baseUnit;
        _unit = baseUnit;
        Decimals = decimals;
        _edit = edit ?? (_ => Task.CompletedTask);
    }

    public CheckWeigherParameter Parameter { get; }

    public string Label { get; }

    /// <summary>Einheit des Werts ohne Zusatz (Eingabe-Pop-up).</summary>
    public string BaseUnit { get; }

    public int Decimals { get; }

    [ObservableProperty]
    private double? _value;

    /// <summary>Angezeigte Einheit; beim automatischen Nullpunkt mit Wert 0 um das Wort "Aus" ergaenzt (S13-7).</summary>
    [ObservableProperty]
    private string _unit;

    [ObservableProperty]
    private double? _minimum;

    [ObservableProperty]
    private double? _maximum;

    /// <summary>Zusatzzaehler im Feld (Packungen seit dem letzten Nullpunkt).</summary>
    [ObservableProperty]
    private int? _counter;

    /// <summary>Gekoppeltes Zaehlfeld unter dem Eingabefeld (Uebergewicht, TU 1, TU 2).</summary>
    [ObservableProperty]
    private int? _coupledCounter;

    [ObservableProperty]
    private string? _errorText;

    /// <summary>Eingabe-Pop-up ist offen.</summary>
    [ObservableProperty]
    private bool _isEditing;

    [ObservableProperty]
    private bool _isAuthorized = true;

    /// <summary>Name der erforderlichen Rolle (Hinweis am Feld).</summary>
    [ObservableProperty]
    private string _requiredRole = string.Empty;

    [RelayCommand]
    private Task EditAsync() => _edit(this);
}
