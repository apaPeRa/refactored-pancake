using System.Collections.ObjectModel;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>HS-02 Produktionszaehler (Pop-up): 13 Zaehlerzeilen, Gesamtproduktion, Betriebsstunden, Reset als Haltetaste.</summary>
[PageKey(PageKeys.ProductionCounter)]
public sealed partial class ProductionCounterViewModel : PopupViewModelBase
{
    private readonly IProductionService _production;
    private readonly ILocalizationService _loc;
    private bool _subscribed;

    public ProductionCounterViewModel(IProductionService production, ILocalizationService localization)
    {
        _production = production;
        _loc = localization;
        Refresh();
    }

    /// <summary>Entwurfsmodus: Dummy-Dienst.</summary>
    public ProductionCounterViewModel()
        : this(new DummyProductionService(), LocalizationService.Instance)
    {
    }

    public ObservableCollection<ProductionCounterRow> Counters { get; } = new();

    [ObservableProperty]
    private double? _totalProduction;

    [ObservableProperty]
    private TimeSpan? _operatingTime;

    /// <summary>Haltedauer der Reset-Taste (Dummy, OP-42).</summary>
    [ObservableProperty]
    private TimeSpan _resetHoldDuration = TimeSpan.FromMilliseconds(1000);

    /// <summary>false bei ungueltigen Werten: Reset deaktiviert.</summary>
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(ResetCommand))]
    private bool _isValid = true;

    public override void OnOpened(object? parameter)
    {
        if (!_subscribed)
        {
            _subscribed = true;
            _production.Changed += OnChanged;
            Closed += OnClosed;
        }

        Refresh();
    }

    private void OnClosed(object? sender, PopupClosedEventArgs e)
    {
        _production.Changed -= OnChanged;
        Closed -= OnClosed;
        _subscribed = false;
    }

    private void OnChanged(object? sender, EventArgs e) => Refresh();

    private void Refresh()
    {
        IsValid = _production.IsValid;
        ResetHoldDuration = _production.ResetHoldDuration;
        TotalProduction = IsValid ? _production.TotalProduction : null;
        OperatingTime = IsValid ? _production.OperatingTime : null;

        Counters.Clear();
        var index = 0;
        foreach (var entry in _production.Counters)
        {
            var name = index == 0
                ? _loc.GetString("HM33_RowCurrent_Text")
                : string.Concat(_loc.GetString("HM33_RowHistory_Text"), " ", index);
            Counters.Add(new ProductionCounterRow(name, entry.Count, entry.ResetTime, index == 0));
            index++;
        }
    }

    /// <summary>Wird nach Ablauf der Haltedauer ausgeloest (Haltetaste <c>HM07_PressBehavior</c> statt Bestaetigungsdialog, S02-2).</summary>
    [RelayCommand(CanExecute = nameof(IsValid))]
    private async Task ResetAsync()
    {
        await _production.ResetCounterAsync();
        Refresh();
    }
}
