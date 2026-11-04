using ApaTec.Hmi.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>Zustandstaste bzw. Umschalter einer Betriebsfunktion auf HS-01 (HM-08). <see cref="IsOn"/> null = Sammelzustand "Teilweise" (nur Automatik).</summary>
public sealed partial class ProductionToggleItem : ObservableObject
{
    private readonly Func<ProductionToggleItem, bool?, Task> _toggle;

    public ProductionToggleItem(ProductionFunction function, Func<ProductionToggleItem, bool?, Task> toggle)
    {
        Function = function;
        _toggle = toggle;
    }

    public ProductionFunction Function { get; }

    [ObservableProperty]
    private string _label = string.Empty;

    [ObservableProperty]
    private bool? _isOn = false;

    [ObservableProperty]
    private bool _isPending;

    [ObservableProperty]
    private string? _errorText;

    [ObservableProperty]
    private bool _isEnabled = true;

    /// <summary>Erzwingt, dass die Ansicht den Zustand neu uebernimmt (z. B. Antippen von "Ein" bei Automatik ohne Wirkung).</summary>
    public void RefreshState() => OnPropertyChanged(nameof(IsOn));

    [RelayCommand]
    private Task ToggleAsync(object? requested) => _toggle(this, requested as bool?);
}
