using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ApaTec.Hmi.ViewModels;

/// <summary>Art einer Taste der unteren Funktionsleiste (HM-06): Aktion, Zustandstaste (HM-08) oder Blaettertaste (HM-19).</summary>
public enum FunctionBarItemKind
{
    Action,
    State,
    Paging,
}

/// <summary>
/// Beschreibung einer Funktionsleisten-Taste. Das Seiten-ViewModel liefert die Sammlung, die View liefert nichts (Konzept.md 6.5).
/// Hoechstens <see cref="PageViewModelBase.MaxFunctionBarItems"/> Tasten, weitere hinter "Mehr".
/// </summary>
public sealed partial class FunctionBarItem : ObservableObject
{
    [ObservableProperty]
    private string _label = string.Empty;

    /// <summary>Token-Name des Symbols, z. B. <c>Icon.Schedule</c>; leer = ohne Symbol.</summary>
    [ObservableProperty]
    private string _iconKey = string.Empty;

    [ObservableProperty]
    private ICommand? _command;

    [ObservableProperty]
    private object? _commandParameter;

    [ObservableProperty]
    private FunctionBarItemKind _kind;

    /// <summary>Zustandstaste ein, bzw. markiert die Seitentaste der aktuellen Seite (HM-06 <c>CurrentTargetId</c>).</summary>
    [ObservableProperty]
    private bool _isActive;

    [ObservableProperty]
    private bool _isEnabled = true;

    /// <summary>Kennung des Navigationsziels (Seitenschluessel) oder leer.</summary>
    [ObservableProperty]
    private string _targetId = string.Empty;
}
