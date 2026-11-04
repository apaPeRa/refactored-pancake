using System.ComponentModel;
using System.Windows.Media;

namespace ApaTec.Hmi.Controls;

/// <summary>Kachelgroesse (HM-16): Large = Size.Touch.Large hoch, Small = Size.Touch.Default hoch.</summary>
public enum TileSize
{
    Large,
    Small,
}

/// <summary>Darstellung leerer Kacheln: Reserved = „Reserviert“ deaktiviert (A-29), Hidden = unsichtbar, Zelle bleibt belegt.</summary>
public enum EmptyTileMode
{
    Reserved,
    Hidden,
}

/// <summary>Elementart: Navigation = Kachel-Taste ohne Zustand; StateToggle = jede Zelle traegt ein HM-08 (<see cref="TileItem.Content"/>).</summary>
public enum TileItemKind
{
    Navigation,
    StateToggle,
}

/// <summary>Eine Kachel des Rasters.</summary>
public sealed class TileItem : INotifyPropertyChanged
{
    private bool _isAuthorized = true;

    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>Beschriftung (mehrzeilig, automatischer Umbruch).</summary>
    public string Label { get; set; } = string.Empty;

    /// <summary>Optionales Symbol (Geometry aus <c>Icons.xaml</c>).</summary>
    public Geometry? Icon { get; set; }

    /// <summary>Zielseite (Seitenschluessel) oder null bei Aktion.</summary>
    public string? TargetPageId { get; set; }

    /// <summary>Leere Kachel („Reserviert“, deaktiviert).</summary>
    public bool IsEmpty { get; set; }

    /// <summary>Hilfetext (Beschreibung der Kachel) fuer <c>AutomationProperties.HelpText</c>.</summary>
    public string? HelpText { get; set; }

    /// <summary>Berechtigungspflichtiges Ziel (Schluessel-Symbol; ohne Rolle <see cref="IsAuthorized"/> = false: Schloss <c>Icon.Lock</c>).</summary>
    public bool RequiresPermission { get; set; }

    /// <summary>false, wenn die aktuelle Rolle fuer die Kachel nicht reicht (Schloss statt Schluessel, HS-35-P14).</summary>
    public bool IsAuthorized
    {
        get => _isAuthorized;
        set
        {
            if (_isAuthorized != value)
            {
                _isAuthorized = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAuthorized)));
            }
        }
    }

    /// <summary>Deaktiviert mit Grund (bleibt antippbar, damit die Meldezeile den Grund zeigt).</summary>
    public bool IsDisabled { get; set; }

    public string? DisabledReason { get; set; }

    /// <summary>Warnaktion (Symbol <c>Icon.Status.Warning</c>; Bestaetigung vor Ausfuehrung).</summary>
    public bool IsWarning { get; set; }

    /// <summary>Inhalt einer Zelle bei <see cref="TileItemKind.StateToggle"/> (HM-08-Instanz oder deren ViewModel).</summary>
    public object? Content { get; set; }
}
