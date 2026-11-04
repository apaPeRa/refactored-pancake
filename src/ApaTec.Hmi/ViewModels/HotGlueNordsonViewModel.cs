using ApaTec.Hmi.Controls;
using ApaTec.Hmi.DesignData;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>HS-07 Heissleim Nordson: Schalter, Status-LEDs, Ist-Temperaturen, Fuellsystem; Funktionsleiste Temperatur, Druck, Zeitplan.</summary>
[PageKey(PageKeys.HotGlueNordson)]
public sealed partial class HotGlueNordsonViewModel : PageViewModelBase
{
    /// <summary>Dummy-Ersatz fuer das fehlende Loslassen-Signal von HM-07 WhilePressed: Anforderung endet nach dieser Zeit.</summary>
    private static readonly TimeSpan ManualFillDuration = TimeSpan.FromSeconds(1);

    private readonly HotGlueEditContext _context;
    private readonly INavigationService? _navigation;

    [ObservableProperty]
    private bool _isOnline;

    [ObservableProperty]
    private double? _standbyDelta;

    [ObservableProperty]
    private LedState _readyLed;

    [ObservableProperty]
    private LedState _temperatureLed;

    [ObservableProperty]
    private LedState _refillSystemLed;

    [ObservableProperty]
    private LedState _tankLevelLed;

    [ObservableProperty]
    private LedState _tankLidLed;

    [ObservableProperty]
    private LedState _noFaultLed;

    [ObservableProperty]
    private LedState _noAlarmLed;

    [ObservableProperty]
    private double? _tankTemperature;

    [ObservableProperty]
    private double? _manifoldTemperature;

    [ObservableProperty]
    private double? _gun1Temperature;

    [ObservableProperty]
    private double? _hose1Temperature;

    [ObservableProperty]
    private double? _hose2Temperature;

    [ObservableProperty]
    private double? _gun2Temperature;

    [ObservableProperty]
    private bool _showHose2;

    [ObservableProperty]
    private bool _showGun2;

    [ObservableProperty]
    private double _tankLevel;

    [ObservableProperty]
    private bool _isTankLevelValid;

    [ObservableProperty]
    private bool _isManualFillRunning;

    /// <summary>Entwurfsmodus.</summary>
    public HotGlueNordsonViewModel()
        : this(HotGlueDesignData.CreateContext(), null)
    {
    }

    public HotGlueNordsonViewModel(
        IHotGlueService service, INavigationService navigation, IDialogService dialogs, IUserSession session, IMessageService messages, ILocalizationService localization)
        : this(new HotGlueEditContext(service, dialogs, session, messages, localization), navigation)
    {
    }

    private HotGlueNordsonViewModel(HotGlueEditContext context, INavigationService? navigation)
    {
        _context = context;
        _navigation = navigation;
        Heaters = new HotGlueSwitchViewModel(HotGlueSwitch.Heaters, context);
        Standby = new HotGlueSwitchViewModel(HotGlueSwitch.Standby, context);
        Pump = new HotGlueSwitchViewModel(HotGlueSwitch.Pump, context);
        Timer = new HotGlueSwitchViewModel(HotGlueSwitch.Timer, context);
        RefillSystem = new HotGlueSwitchViewModel(HotGlueSwitch.RefillSystem, context);
        TargetLevel = new HotGlueFieldViewModel(HotGlueParameter.TargetFillLevel, context, "HS07_TargetLevel_Label", "HotGlue_Unit_Percent", "HS07_TargetLevel_Caption");
        MaxFillTime = new HotGlueFieldViewModel(HotGlueParameter.MaxFillTime, context, "HS07_MaxFillTime_Label", "HotGlue_Unit_Second", "HS07_MaxFillTime_Caption");

        var loc = context.Localization;
        FunctionBarItems.Add(new FunctionBarItem { Label = loc.GetString("HS07_Fn_Temperature"), IconKey = "Icon.Temperature", Command = OpenTemperatureCommand, TargetId = PageKeys.HotGlueParameters });
        FunctionBarItems.Add(new FunctionBarItem { Label = loc.GetString("HS07_Fn_Pressure"), IconKey = "Icon.Pressure", Command = OpenPressureCommand, TargetId = PageKeys.HotGluePressure });
        FunctionBarItems.Add(new FunctionBarItem { Label = loc.GetString("HS07_Fn_Schedule"), IconKey = "Icon.Schedule", Command = OpenScheduleCommand, TargetId = PageKeys.HotGlueSchedule });
        Refresh();
    }

    public HotGlueSwitchViewModel Heaters { get; }

    public HotGlueSwitchViewModel Standby { get; }

    public HotGlueSwitchViewModel Pump { get; }

    /// <summary>Zustandstaste "Zeitschaltuhr" (aktiviert nur den Zeitplan des Geraets).</summary>
    public HotGlueSwitchViewModel Timer { get; }

    public HotGlueSwitchViewModel RefillSystem { get; }

    public HotGlueFieldViewModel TargetLevel { get; }

    public HotGlueFieldViewModel MaxFillTime { get; }

    public override void OnNavigatedTo(object? parameter)
    {
        _context.Service.Changed -= OnServiceChanged;
        _context.Service.Changed += OnServiceChanged;
        if (_context.Session is not null)
        {
            _context.Session.SessionChanged -= OnServiceChanged;
            _context.Session.SessionChanged += OnServiceChanged;
        }

        Refresh();
    }

    public override void OnNavigatedFrom()
    {
        _context.Service.Changed -= OnServiceChanged;
        if (_context.Session is not null)
        {
            _context.Session.SessionChanged -= OnServiceChanged;
        }
    }

    private void OnServiceChanged(object? sender, EventArgs e) => Refresh();

    private void Refresh()
    {
        var s = _context.Service;
        IsOnline = s.IsConnected;
        StandbyDelta = IsOnline ? s.GetParameter(HotGlueParameter.StandbyDelta) : null;
        ReadyLed = Map(HotGlueLed.Ready);
        TemperatureLed = Map(HotGlueLed.Temperature);
        RefillSystemLed = Map(HotGlueLed.RefillSystem);
        TankLevelLed = Map(HotGlueLed.TankLevel);
        TankLidLed = Map(HotGlueLed.TankLid);
        NoFaultLed = Map(HotGlueLed.NoFault);
        NoAlarmLed = Map(HotGlueLed.NoAlarm);
        TankTemperature = Actual(HotGlueZoneIds.Tank);
        ManifoldTemperature = Actual(HotGlueZoneIds.Manifold);
        Gun1Temperature = Actual(HotGlueZoneIds.Gun1);
        Hose1Temperature = Actual(HotGlueZoneIds.Hose1);
        Hose2Temperature = Actual(HotGlueZoneIds.Hose2);
        Gun2Temperature = Actual(HotGlueZoneIds.Gun2);
        ShowHose2 = s.Zones.Any(z => z.Id == HotGlueZoneIds.Hose2 && z.IsEnabled);
        ShowGun2 = s.Zones.Any(z => z.Id == HotGlueZoneIds.Gun2 && z.IsEnabled);
        IsTankLevelValid = IsOnline && s.TankLevel is not null;
        TankLevel = s.TankLevel ?? 0;
        IsManualFillRunning = s.IsManualFillActive;
        Heaters.Refresh();
        Standby.Refresh();
        Pump.Refresh();
        Timer.Refresh();
        RefillSystem.Refresh();
        TargetLevel.Refresh();
        MaxFillTime.Refresh();
    }

    private double? Actual(string zoneId) =>
        _context.Service.IsConnected ? _context.Service.Zones.FirstOrDefault(z => z.Id == zoneId)?.Actual : null;

    private LedState Map(HotGlueLed led) => !IsOnline
        ? LedState.Unknown
        : _context.Service.GetLed(led) switch
        {
            HotGlueLedState.Ok => LedState.On,
            HotGlueLedState.Fault => LedState.Error,
            _ => LedState.Unknown,
        };

    [RelayCommand]
    private Task OpenTemperatureAsync() => _navigation?.NavigateToAsync(PageKeys.HotGlueParameters) ?? Task.CompletedTask;

    [RelayCommand]
    private Task OpenPressureAsync() => _navigation?.NavigateToAsync(PageKeys.HotGluePressure) ?? Task.CompletedTask;

    [RelayCommand]
    private Task OpenScheduleAsync() => _navigation?.NavigateToAsync(PageKeys.HotGlueSchedule) ?? Task.CompletedTask;

    /// <summary>Taste "Manuell" (HM-07 WhilePressed): fordert Nachfuellen an, solange die Taste gehalten wird. Das Loslassen meldet HM-07 noch nicht (Luecke), daher endet die Anforderung im Dummy nach <see cref="ManualFillDuration"/>.</summary>
    [RelayCommand]
    private async Task ManualFillAsync()
    {
        if (IsManualFillRunning)
        {
            return;
        }

        try
        {
            await _context.Service.SetManualFillAsync(true);
            await Task.Delay(ManualFillDuration);
        }
        finally
        {
            await _context.Service.SetManualFillAsync(false);
        }
    }
}
