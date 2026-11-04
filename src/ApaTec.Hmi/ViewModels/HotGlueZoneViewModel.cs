using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>Zeile der Zonenliste von HS-08 (HM-28 Variante Heissleim): Soll (Eingabe), Ist (Anzeige) und Statustaste Ausschalten/Einschalten.</summary>
public sealed partial class HotGlueZoneViewModel : ObservableObject
{
    private readonly HotGlueEditContext _context;
    private bool _syncing;

    [ObservableProperty]
    private double _setpoint;

    [ObservableProperty]
    private double? _actual;

    [ObservableProperty]
    private bool _isZoneEnabled;

    [ObservableProperty]
    private LedState _stateLed;

    [ObservableProperty]
    private bool _isAuthorized;

    public HotGlueZoneViewModel(string id, HotGlueEditContext context)
    {
        Id = id;
        _context = context;
        Name = context.Localization.GetString("HS08_Zone_" + id);
        Refresh();
    }

    public string Id { get; }

    public string Name { get; }

    public void Refresh()
    {
        var zone = _context.Service.Zones.FirstOrDefault(z => z.Id == Id);
        if (zone is null)
        {
            return;
        }

        _syncing = true;
        Setpoint = zone.Setpoint;
        Actual = _context.Service.IsConnected ? zone.Actual : null;
        IsZoneEnabled = zone.IsEnabled;
        StateLed = !_context.Service.IsConnected ? LedState.Unknown : zone.HasFault ? LedState.Error : zone.IsEnabled ? LedState.On : LedState.Off;
        IsAuthorized = _context.IsAuthorized;
        _syncing = false;
    }

    partial void OnIsZoneEnabledChanged(bool value)
    {
        if (!_syncing)
        {
            _ = WriteAsync(() => _context.Service.SetZoneEnabledAsync(Id, value));
        }
    }

    [RelayCommand]
    private async Task EditSetpointAsync()
    {
        if (_context.Dialogs is null || !_context.Service.IsConnected || !await _context.EnsureAuthorizedAsync())
        {
            return;
        }

        var limits = _context.Service.ZoneSetpointLimits;
        var loc = _context.Localization;
        var request = new HotGlueInputRequest(Name, Setpoint, loc.GetString("HotGlue_Unit_Celsius"), limits.Minimum, limits.Maximum, limits.Decimals);
        var result = await _context.Dialogs.ShowAsync<double>(DialogKeys.Input, request);
        if (result.Accepted && result.Value >= limits.Minimum && result.Value <= limits.Maximum)
        {
            await WriteAsync(() => _context.Service.SetZoneSetpointAsync(Id, result.Value));
        }
    }

    private async Task WriteAsync(Func<Task> write)
    {
        try
        {
            await write();
        }
        catch (Exception)
        {
            // Keine Rueckmeldung: Anzeige springt auf den bestaetigten Stand zurueck.
        }

        Refresh();
    }
}
