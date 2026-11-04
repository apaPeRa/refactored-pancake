using CommunityToolkit.Mvvm.ComponentModel;

namespace ApaTec.Hmi.ViewModels;

/// <summary>Fehlertexte der Eingabefelder, per Feldname bindbar: <c>{Binding Errors[TargetPercent]}</c> (HM-12 Zustand Fehler).</summary>
public sealed class DoserFieldErrors : ObservableObject
{
    private readonly Dictionary<string, string?> _texts = new(StringComparer.Ordinal);

    public string? this[string field] => _texts.TryGetValue(field, out var text) ? text : null;

    public void Set(string field, string? text)
    {
        _texts[field] = text;
        OnPropertyChanged("Item[]");
    }
}
