using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// HS-28 Packungsregister: Stationsgrafik (HM-32) mit manueller Zustandsaenderung durch Antippen, Legende, Abhaengigkeitshinweis. Keine Funktionsleistentasten.
/// Dummy-Zustandsfolge beim Antippen: zyklisch in Legendenreihenfolge (K28-3, OP-53).
/// </summary>
[PageKey(PageKeys.PackRegister)]
public sealed partial class PackRegisterViewModel : PageViewModelBase
{
    // Reihenfolge der Legende (HS-28): Nicht vorhanden, Schlecht, Vorhanden, Befuellt, Gut.
    private static readonly PackState[] StateCycle = { PackState.None, PackState.Bad, PackState.Present, PackState.Filled, PackState.Ok };

    private readonly IPackRegisterService _service;
    private readonly IMessageService? _messages;
    private readonly ILocalizationService _localization;
    private readonly SynchronizationContext? _context = SynchronizationContext.Current;
    private bool _subscribed;

    [ObservableProperty]
    private IReadOnlyList<PackStation> _stations = Array.Empty<PackStation>();

    /// <summary>false = keine Verbindung bzw. keine Stationsdaten (K28-4).</summary>
    [ObservableProperty]
    private bool _hasData = true;

    /// <summary>Entwurfsmodus: Dummy-Dienst.</summary>
    public PackRegisterViewModel()
        : this(new DummyPackRegisterService(), null, LocalizationService.Instance)
    {
    }

    public PackRegisterViewModel(IPackRegisterService service, IMessageService? messages, ILocalizationService localization)
    {
        _service = service;
        _messages = messages;
        _localization = localization;
        Reload();
    }

    public double LayoutWidth => PackRegisterLayout.Width;

    public double LayoutHeight => PackRegisterLayout.Height;

    public override void OnNavigatedTo(object? parameter)
    {
        if (!_subscribed)
        {
            _service.Changed += OnServiceChanged;
            _subscribed = true;
        }

        Reload();
    }

    public override void OnNavigatedFrom()
    {
        if (_subscribed)
        {
            _service.Changed -= OnServiceChanged;
            _subscribed = false;
        }
    }

    private void OnServiceChanged(object? sender, EventArgs e)
    {
        if (_context is null)
        {
            Reload();
        }
        else
        {
            _context.Post(_ => Reload(), null);
        }
    }

    private void Reload()
    {
        HasData = _service.IsConnected;
        Stations = HasData ? _service.GetStations().Select(PackRegisterLayout.Place).ToList() : Array.Empty<PackStation>();
    }

    [RelayCommand]
    private async Task ToggleStationAsync(PackStation? station)
    {
        if (station is null)
        {
            return;
        }

        var next = StateCycle[(Array.IndexOf(StateCycle, station.State) + 1) % StateCycle.Length];
        if (!await _service.SetStationStateAsync(station.Number, next))
        {
            _messages?.ShowHint(_localization.Format("HS28_ToggleFailed_Text", station.Number));
        }

        Reload();
    }
}
