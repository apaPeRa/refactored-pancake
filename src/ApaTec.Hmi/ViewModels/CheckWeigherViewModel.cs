using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// HS-13 Kontrollwaage (Einstellung > Waagen > Kontrollwaage): Anzeigen zu Gewicht und Statistik, Waegeparameter, Grenzwerte mit Zaehlern,
/// Zaehlerzeile, Nullpunkt setzen und Zaehler loeschen (mit Bestaetigung, S13-1). Funktionsleiste: Trend (HS-15), Einzelgewichte (HS-14).
/// </summary>
[PageKey(PageKeys.CheckWeigher)]
public sealed partial class CheckWeigherViewModel : PageViewModelBase
{
    /// <summary>Mindestrolle fuer Eingaben und Aktionen (Dummy, OP-25, OP-04).</summary>
    private const UserRole RequiredUserRole = UserRole.Technician;

    private readonly IScaleService _scales;
    private readonly IUserSession _session;
    private readonly IDialogService? _dialogs;
    private readonly INavigationService? _navigation;
    private readonly IMessageService? _messages;
    private readonly ILocalizationService _loc;
    private SynchronizationContext? _context;
    private bool _wasConnected = true;

    public CheckWeigherViewModel(
        IScaleService scales,
        IUserSession session,
        IDialogService? dialogs,
        INavigationService? navigation,
        IMessageService? messages,
        ILocalizationService loc)
    {
        _scales = scales;
        _session = session;
        _dialogs = dialogs;
        _navigation = navigation;
        _messages = messages;
        _loc = loc;

        var gram = loc.GetString("HS13_Unit_Gram");
        TargetWeight = new CheckWeigherFieldViewModel(CheckWeigherParameter.TargetWeight, loc.GetString("HS13_TargetWeight_Label"), gram, 1, EditFieldAsync);
        Tare = new CheckWeigherFieldViewModel(CheckWeigherParameter.Tare, loc.GetString("HS13_Tare_Label"), gram, 1, EditFieldAsync);
        AutoZero = new CheckWeigherFieldViewModel(CheckWeigherParameter.AutoZeroInterval, loc.GetString("HS13_AutoZero_Label"), loc.GetString("HS13_Unit_Piece"), 0, EditFieldAsync);
        OverWeight = new CheckWeigherFieldViewModel(CheckWeigherParameter.OverWeight, loc.GetString("HS13_OverWeight_Label"), gram, 1, EditFieldAsync);
        Under1 = new CheckWeigherFieldViewModel(CheckWeigherParameter.Under1, loc.GetString("HS13_Under1_Label"), gram, 1, EditFieldAsync);
        Under2 = new CheckWeigherFieldViewModel(CheckWeigherParameter.Under2, loc.GetString("HS13_Under2_Label"), gram, 1, EditFieldAsync);
        Fields = new[] { TargetWeight, Tare, AutoZero, OverWeight, Under1, Under2 };

        FunctionBarItems.Add(new FunctionBarItem
        {
            Label = loc.GetString("HS13_Trend_Label"),
            IconKey = "Icon.Nav.Trend",
            Kind = FunctionBarItemKind.Action,
            TargetId = PageKeys.Trend,
            Command = NavigateToCommand,
            CommandParameter = PageKeys.Trend,
        });
        FunctionBarItems.Add(new FunctionBarItem
        {
            Label = loc.GetString("HS13_SingleWeights_Label"),
            IconKey = "Icon.Nav.List",
            Kind = FunctionBarItemKind.Action,
            TargetId = PageKeys.SingleWeights,
            Command = NavigateToCommand,
            CommandParameter = PageKeys.SingleWeights,
        });

        Refresh();
    }

    /// <summary>Entwurfsmodus (DesignData): Dummy-Dienste, keine Navigation und keine Pop-ups.</summary>
    public CheckWeigherViewModel()
        : this(new DummyScaleService(), new DummyUserSession(), null, null, null, LocalizationService.Instance)
    {
    }

    public CheckWeigherFieldViewModel TargetWeight { get; }

    public CheckWeigherFieldViewModel Tare { get; }

    public CheckWeigherFieldViewModel AutoZero { get; }

    public CheckWeigherFieldViewModel OverWeight { get; }

    public CheckWeigherFieldViewModel Under1 { get; }

    public CheckWeigherFieldViewModel Under2 { get; }

    private IReadOnlyList<CheckWeigherFieldViewModel> Fields { get; }

    [ObservableProperty]
    private double? _net;

    [ObservableProperty]
    private double? _gross;

    [ObservableProperty]
    private double? _live;

    [ObservableProperty]
    private double? _mean;

    [ObservableProperty]
    private double? _stdDev;

    [ObservableProperty]
    private double? _performance;

    [ObservableProperty]
    private double? _under1Percent;

    [ObservableProperty]
    private int? _goodCount;

    [ObservableProperty]
    private int? _badCount;

    /// <summary>Benutzer hat die Rolle fuer Eingaben und Aktionen (Schluessel statt Schloss).</summary>
    [ObservableProperty]
    private bool _isAuthorized = true;

    /// <summary>Name der erforderlichen Rolle (Hinweis am Schloss).</summary>
    [ObservableProperty]
    private string _requiredRoleName = string.Empty;

    public override void OnNavigatedTo(object? parameter)
    {
        _context = SynchronizationContext.Current;
        _scales.Changed += OnServiceChanged;
        _session.SessionChanged += OnServiceChanged;
        Refresh();
    }

    public override void OnNavigatedFrom()
    {
        _scales.Changed -= OnServiceChanged;
        _session.SessionChanged -= OnServiceChanged;
    }

    private void OnServiceChanged(object? sender, EventArgs e)
    {
        if (_context is null || SynchronizationContext.Current == _context)
        {
            Refresh();
        }
        else
        {
            _context.Post(_ => Refresh(), null);
        }
    }

    private void Refresh()
    {
        var snapshot = _scales.GetCheckWeigher();
        var connected = snapshot.IsConnected;
        var reading = snapshot.Reading;
        var settings = snapshot.Settings;
        var counters = snapshot.Counters;

        Net = connected ? reading.Net : null;
        Gross = connected ? reading.Gross : null;
        Live = connected ? reading.Live : null;
        Mean = connected ? reading.Mean : null;
        StdDev = connected ? reading.StdDev : null;
        Performance = connected ? reading.Performance : null;
        Under1Percent = connected ? counters.Under1Percent : null;
        GoodCount = connected ? counters.Good : null;
        BadCount = connected ? counters.Bad : null;

        SetField(TargetWeight, connected ? settings.TargetWeight : null);
        SetField(Tare, connected ? settings.Tare : null);
        SetField(AutoZero, connected ? settings.AutoZeroInterval : null);
        SetField(OverWeight, connected ? settings.OverWeight : null);
        SetField(Under1, connected ? settings.Under1 : null);
        SetField(Under2, connected ? settings.Under2 : null);
        AutoZero.Counter = connected ? settings.PacksSinceZero : null;
        OverWeight.CoupledCounter = connected ? counters.Over : null;
        Under1.CoupledCounter = connected ? counters.Under1 : null;
        Under2.CoupledCounter = connected ? counters.Under2 : null;
        AutoZero.Unit = AutoZero.Value is 0d ? _loc.GetString("HS13_AutoZero_UnitOff") : AutoZero.BaseUnit;

        var authorized = _session.HasRole(RequiredUserRole);
        var roleName = _loc.GetString("Role_" + RequiredUserRole);
        IsAuthorized = authorized;
        RequiredRoleName = roleName;
        foreach (var field in Fields)
        {
            field.IsAuthorized = authorized;
            field.RequiredRole = roleName;
        }

        if (!connected && _wasConnected)
        {
            _messages?.ShowHint(_loc.GetString("HS13_Offline_Hint"));
        }

        _wasConnected = connected;
    }

    private void SetField(CheckWeigherFieldViewModel field, double? value)
    {
        var limits = _scales.GetLimits(field.Parameter);
        field.Value = value;
        field.Minimum = limits.Minimum;
        field.Maximum = limits.Maximum;
    }

    /// <summary>Prueft die Rolle; ohne Rolle erscheint der Hinweis in der Meldezeile und das Benutzer-Pop-up oeffnet (Navigation.md 4.1).</summary>
    private async Task<bool> EnsureRoleAsync()
    {
        if (_session.HasRole(RequiredUserRole))
        {
            return true;
        }

        _messages?.ShowHint(_loc.Format("Msg_PermissionRequired", _loc.GetString("Role_" + RequiredUserRole)));
        return await _session.RequestRoleAsync(RequiredUserRole);
    }

    private async Task EditFieldAsync(CheckWeigherFieldViewModel field)
    {
        if (_dialogs is null || !await EnsureRoleAsync())
        {
            return;
        }

        var request = new NavigationParameters("title", field.Label)
            .With("value", field.Value)
            .With("unit", field.BaseUnit)
            .With("decimals", field.Decimals)
            .With("minimum", field.Minimum)
            .With("maximum", field.Maximum);

        field.IsEditing = true;
        DialogResult<double> result;
        try
        {
            result = await _dialogs.ShowAsync<double>(DialogKeys.Input, request);
        }
        finally
        {
            field.IsEditing = false;
        }

        if (!result.Accepted)
        {
            return;
        }

        var limits = _scales.GetLimits(field.Parameter);
        if (result.Value < limits.Minimum || result.Value > limits.Maximum)
        {
            var format = "N" + field.Decimals;
            field.ErrorText = _loc.Format("HS13_Error_OutOfRange", limits.Minimum.ToString(format, _loc.Culture), limits.Maximum.ToString(format, _loc.Culture));
            return;
        }

        field.ErrorText = null;
        _scales.SetParameter(field.Parameter, result.Value);
        Refresh();
    }

    private async Task<bool> ConfirmAsync(string titleKey, string textKey)
    {
        if (_dialogs is null)
        {
            return false;
        }

        var request = new NavigationParameters("title", _loc.GetString(titleKey)).With("text", _loc.GetString(textKey));
        var result = await _dialogs.ShowAsync<bool>(DialogKeys.Confirmation, request);
        return result.Accepted;
    }

    [RelayCommand]
    private async Task SetZeroAsync()
    {
        if (await EnsureRoleAsync() && await ConfirmAsync("HS13_SetZero_Title", "HS13_SetZero_Text"))
        {
            await _scales.SetZeroAsync();
            Refresh();
        }
    }

    [RelayCommand]
    private async Task ClearCountersAsync()
    {
        if (await EnsureRoleAsync() && await ConfirmAsync("HS13_ClearCounters_Title", "HS13_ClearCounters_Text"))
        {
            await _scales.ResetCountersAsync();
            Refresh();
        }
    }

    [RelayCommand]
    private async Task NavigateToAsync(string pageKey)
    {
        if (_navigation is not null)
        {
            await _navigation.NavigateToAsync(pageKey);
        }
    }
}
