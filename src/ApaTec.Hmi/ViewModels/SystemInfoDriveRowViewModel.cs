using ApaTec.Hmi.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>Zeile eines Servoantriebs auf HS-39 (Daten fuer HM-34).</summary>
public sealed partial class DriveRowViewModel : ObservableObject
{
    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private int _diagCode;

    [ObservableProperty]
    private double _currentActual;

    [ObservableProperty]
    private double _currentMax;

    [ObservableProperty]
    private double _currentLimit;

    [ObservableProperty]
    private string? _message;

    [ObservableProperty]
    private bool _isLimitAuthorized = true;

    public DriveRowViewModel(DriveDiagnostics data, Func<DriveRowViewModel, Task> resetMax, Func<DriveRowViewModel, Task> editLimit)
    {
        Id = data.Id;
        ResetMaxCommand = new AsyncRelayCommand(() => resetMax(this));
        LimitCommand = new AsyncRelayCommand(() => editLimit(this));
        Update(data);
    }

    public string Id { get; }

    public IAsyncRelayCommand ResetMaxCommand { get; }

    public IAsyncRelayCommand LimitCommand { get; }

    public void Update(DriveDiagnostics data)
    {
        Name = data.Name;
        DiagCode = data.DiagCode;
        CurrentActual = data.CurrentActual;
        CurrentMax = data.CurrentMax;
        CurrentLimit = data.CurrentLimit;
        Message = data.Message;
    }
}
