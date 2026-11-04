using ApaTec.Hmi.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ApaTec.Hmi.ViewModels;

/// <summary>Eingabefeld einer Geschwindigkeit auf HS-03 (HM-12).</summary>
public sealed partial class MachineSpeedField : ObservableObject
{
    public MachineSpeedField(MachineSpeedKind kind, bool requiresPermission)
    {
        Kind = kind;
        RequiresPermission = requiresPermission;
    }

    public MachineSpeedKind Kind { get; }

    /// <summary>Maximum, Tippen und Minimum tragen das Schluesselsymbol (OP-25).</summary>
    public bool RequiresPermission { get; }

    [ObservableProperty]
    private string _name = string.Empty;

    [ObservableProperty]
    private string _label = string.Empty;

    [ObservableProperty]
    private double? _value;

    [ObservableProperty]
    private string _unit = string.Empty;

    [ObservableProperty]
    private bool _isAuthorized = true;

    [ObservableProperty]
    private string _requiredRole = string.Empty;

    [ObservableProperty]
    private bool _isPendingWrite;

    [ObservableProperty]
    private string? _errorText;
}
