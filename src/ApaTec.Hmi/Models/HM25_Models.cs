using CommunityToolkit.Mvvm.ComponentModel;

namespace ApaTec.Hmi.Models;

/// <summary>Listenart der Meldungsliste (HM-25): Meldearchiv, Meldeanzeige, Auswahlliste (Variablenliste).</summary>
public enum MessageListKind
{
    Archive,
    Live,
    Selection,
}

/// <summary>Auswahlmodus einer Liste (HM-25).</summary>
public enum ListSelectionMode
{
    None,
    Single,
    Multiple,
}

/// <summary>Sortierrichtung einer Liste (HM-25).</summary>
public enum SortDirection
{
    Ascending,
    Descending,
}

/// <summary>Blaetterart einer Liste (HM-25): vier Scrolltasten oder Rollbalken.</summary>
public enum ListScrollStyle
{
    Buttons,
    Scrollbar,
}

/// <summary>Zeile der Meldungsliste (HM-25). <see cref="IsSelected"/> ist die Mehrfachauswahl-Markierung der Zeile.</summary>
public sealed class MessageEntry : ObservableObject
{
    private bool _isSelected;

    public DateTime Timestamp { get; init; }

    public string Event { get; init; } = string.Empty;

    public int Number { get; init; }

    public string Text { get; init; } = string.Empty;

    public MessageClass Class { get; init; }

    public bool IsSelected
    {
        get => _isSelected;
        set => SetProperty(ref _isSelected, value);
    }
}
