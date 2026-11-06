using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>Zeile einer Heizzone (HM-28, Variante Heizungen).</summary>
public sealed partial class HeaterZoneViewModel : ObservableObject
{
    private readonly HeatersViewModel _owner;

    public HeaterZoneViewModel(HeatersViewModel owner, HeaterZoneInfo info)
    {
        _owner = owner;
        Index = info.Index;
        ZoneName = info.Name;
        Apply(info);
    }

    public int Index { get; }

    public string ZoneName { get; }

    [ObservableProperty]
    private bool _isZoneEnabled;

    [ObservableProperty]
    private bool _isMonitored;

    [ObservableProperty]
    private double _setpoint;

    [ObservableProperty]
    private double? _actual;

    [ObservableProperty]
    private LedState _stateLed;

    [ObservableProperty]
    private LedState _outputLed;

    [ObservableProperty]
    private bool _isAuthorized = true;

    /// <summary>Befehl "Heizung ein/aus" gesendet, Rueckmeldung steht aus (Zustand "Ausstehend", HM-08).</summary>
    [ObservableProperty]
    private bool _isZonePending;

    [ObservableProperty]
    private bool _isMonitorPending;

    internal void Apply(HeaterZoneInfo info)
    {
        IsZoneEnabled = info.IsEnabled;
        IsMonitored = info.IsMonitored;
        Setpoint = info.Setpoint;
        Actual = info.Actual;
        StateLed = info.State switch
        {
            HeaterZoneState.TargetReached => LedState.On,
            HeaterZoneState.Fault => LedState.Error,
            _ => LedState.Off,
        };
        OutputLed = info.OutputOn ? LedState.On : LedState.Off;
    }

    [RelayCommand]
    private Task ToggleZoneAsync() => _owner.ToggleZoneAsync(this);

    [RelayCommand]
    private Task ToggleMonitorAsync() => _owner.ToggleMonitorAsync(this);

    [RelayCommand]
    private Task EditSetpointAsync() => _owner.EditSetpointAsync(this);
}

/// <summary>HS-22 Heizungen: zwoelf Heizzonen mit Ein/Aus, Ueberwachung, Soll, Ist, State und Out; Funktionsleiste leer.</summary>
[PageKey(PageKeys.Heaters)]
public sealed partial class HeatersViewModel : PageViewModelBase
{
    /// <summary>Die Seite scrollt selbst und fuellt den Inhaltsbereich (S-01).</summary>
    public override bool FillsContentArea => true;

    /// <summary>Dummy-Rolle fuer Heizung, Meldung und Soll (OP-25).</summary>
    private const UserRole RequiredRole = UserRole.Technician;

    private readonly IHeaterService _service;
    private readonly IUserSession? _user;
    private readonly IDialogService? _dialogs;
    private readonly IMessageService? _messages;
    private readonly ILocalizationService _localization;
    private readonly SynchronizationContext? _context = SynchronizationContext.Current;

    /// <summary>Entwurfsmodus: Dummy-Dienste.</summary>
    public HeatersViewModel()
        : this(new DummyHeaterService(), new DummyUserSession(), null, null, LocalizationService.Instance)
    {
    }

    public HeatersViewModel(IHeaterService service, IUserSession? user, IDialogService? dialogs, IMessageService? messages, ILocalizationService localization)
    {
        _service = service;
        _user = user;
        _dialogs = dialogs;
        _messages = messages;
        _localization = localization;
        foreach (var zone in service.GetZones())
        {
            Zones.Add(new HeaterZoneViewModel(this, zone));
        }

        UpdateAuthorization();
    }

    public System.Collections.ObjectModel.ObservableCollection<HeaterZoneViewModel> Zones { get; } = new();

    public override void OnNavigatedTo(object? parameter)
    {
        _service.Changed += OnServiceChanged;
        if (_user is not null)
        {
            _user.SessionChanged += OnSessionChanged;
        }

        Reload();
        UpdateAuthorization();
    }

    public override void OnNavigatedFrom()
    {
        _service.Changed -= OnServiceChanged;
        if (_user is not null)
        {
            _user.SessionChanged -= OnSessionChanged;
        }
    }

    internal async Task ToggleZoneAsync(HeaterZoneViewModel zone)
    {
        var desired = zone.IsZoneEnabled;
        if (!await EnsureAuthorizedAsync())
        {
            zone.IsZoneEnabled = !desired;
            return;
        }

        zone.IsZonePending = true;
        try
        {
            if (!await _service.SetZoneEnabledAsync(zone.Index, desired))
            {
                zone.IsZoneEnabled = !desired;
            }
        }
        finally
        {
            zone.IsZonePending = false;
        }
    }

    internal async Task ToggleMonitorAsync(HeaterZoneViewModel zone)
    {
        var desired = zone.IsMonitored;
        if (!await EnsureAuthorizedAsync())
        {
            zone.IsMonitored = !desired;
            return;
        }

        zone.IsMonitorPending = true;
        try
        {
            if (!await _service.SetMonitoredAsync(zone.Index, desired))
            {
                zone.IsMonitored = !desired;
            }
        }
        finally
        {
            zone.IsMonitorPending = false;
        }
    }

    internal async Task EditSetpointAsync(HeaterZoneViewModel zone)
    {
        if (_dialogs is null || !await EnsureAuthorizedAsync())
        {
            return;
        }

        var limits = _service.SetpointLimits;
        var title = _localization.Format("HS22_Setpoint_Title", zone.ZoneName);
        var request = new MachineInputRequest(title, zone.Setpoint, _localization.GetString("HS22_Unit_Celsius"), 0, limits, InputKind.Number);
        var result = await _dialogs.ShowAsync<double?>(DialogKeys.Input, request);
        if (!result.Accepted || result.Value is not { } value)
        {
            return;
        }

        if (value < limits.Minimum || value > limits.Maximum)
        {
            _messages?.ShowHint(_localization.Format("HS22_Setpoint_Range", limits.Minimum, limits.Maximum));
            return;
        }

        if (await _service.SetSetpointAsync(zone.Index, value))
        {
            zone.Setpoint = value;
        }
    }

    private async Task<bool> EnsureAuthorizedAsync()
    {
        if (_user is null || _user.HasRole(RequiredRole))
        {
            return true;
        }

        _messages?.ShowHint(_localization.Format("Msg_PermissionRequired", _localization.GetString("Role_" + RequiredRole)));
        return await _user.RequestRoleAsync(RequiredRole);
    }

    private void Reload()
    {
        foreach (var info in _service.GetZones())
        {
            if (info.Index < Zones.Count)
            {
                Zones[info.Index].Apply(info);
            }
        }
    }

    private void UpdateAuthorization()
    {
        var allowed = _user?.HasRole(RequiredRole) ?? true;
        foreach (var zone in Zones)
        {
            zone.IsAuthorized = allowed;
        }
    }

    private void OnServiceChanged(object? sender, EventArgs e) => Post(Reload);

    private void OnSessionChanged(object? sender, EventArgs e) => Post(UpdateAuthorization);

    private void Post(Action action)
    {
        if (_context is null)
        {
            action();
        }
        else
        {
            _context.Post(_ => action(), null);
        }
    }
}
