using CommunityToolkit.Mvvm.ComponentModel;

namespace ApaTec.Hmi.Models;

/// <summary>Winkelfeld der Leimspuren-Grafik (HM-31): Reihe (1 bis 4), Index in der Reihe, Maschinenwinkel in Grad.</summary>
public sealed class GlueTrackField : ObservableObject
{
    private double? _angle;
    private string? _errorText;
    private bool _isAuthorized = true;
    private bool _isEditing;

    public int Row { get; init; }

    public int Index { get; init; }

    /// <summary>Beschriftung der Spur im Tooltip (Anfang/Ende, Zuordnung offen OP-19).</summary>
    public string? Tooltip { get; init; }

    public double? Angle
    {
        get => _angle;
        set => SetProperty(ref _angle, value);
    }

    public string? ErrorText
    {
        get => _errorText;
        set => SetProperty(ref _errorText, value);
    }

    /// <summary>false: Rolle reicht nicht, das Feld zeigt das Schloss statt des Schluessels (HM-12).</summary>
    public bool IsAuthorized
    {
        get => _isAuthorized;
        set => SetProperty(ref _isAuthorized, value);
    }

    /// <summary>true, solange das Eingabe-Pop-up fuer das Feld offen ist (Fokusrahmen).</summary>
    public bool IsEditing
    {
        get => _isEditing;
        set => SetProperty(ref _isEditing, value);
    }
}

/// <summary>Aenderung eines Winkelfelds (HM-31, Befehlsparameter fuer das ViewModel).</summary>
public sealed record GlueTrackChange(int Row, int Index, double? Angle);
