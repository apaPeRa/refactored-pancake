using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>HS-39 System- und Antriebsinfos: IPC-Kennwerte und Antriebsliste (vier Zeilen sichtbar, Blaettern ueber zwei Pfeiltasten).</summary>
[PageKey(PageKeys.SystemInfo)]
public sealed partial class SystemInfoViewModel : PageViewModelBase
{
    /// <summary>Rollenstufe fuer Strom Limit (Dummy, OP-25).</summary>
    private const UserRole LimitRole = UserRole.Technician;

    private const double LimitMinimum = 0;
    private const double LimitMaximum = 500;
    private const int LimitDecimals = 1;

    private readonly ISystemInfoService _info;
    private readonly IUserSession _session;
    private readonly IDialogService _dialogs;
    private readonly IMessageService _messages;
    private readonly ILocalizationService _text;
    private readonly SynchronizationContext? _sync = SynchronizationContext.Current;
    private readonly List<DriveRowViewModel> _drives = new();
    private int _first;

    [ObservableProperty]
    private double _cpuCurrent;

    [ObservableProperty]
    private double _cpuMax;

    [ObservableProperty]
    private DateTime _systemStart;

    [ObservableProperty]
    private TimeSpan _totalRuntime;

    [ObservableProperty]
    private string _statusText = string.Empty;

    [ObservableProperty]
    private string _diagText = string.Empty;

    [ObservableProperty]
    private DateTime _buildTime;

    [ObservableProperty]
    private IReadOnlyList<DriveRowViewModel> _visibleDrives = Array.Empty<DriveRowViewModel>();

    [ObservableProperty]
    private int _rangeStart;

    [ObservableProperty]
    private int _rangeEnd;

    public SystemInfoViewModel(ISystemInfoService info, IUserSession session, IDialogService dialogs, IMessageService messages, ILocalizationService text)
    {
        _info = info;
        _session = session;
        _dialogs = dialogs;
        _messages = messages;
        _text = text;
        Refresh();
    }

    /// <summary>Entwurfsmodus: Dummy-Dienst mit den Werten des Bildes.</summary>
    public SystemInfoViewModel()
        : this(new DummySystemInfoService(), new DummyUserSession(), null!, new DummyMessageService(), LocalizationService.Instance)
    {
    }

    /// <summary>Gleichzeitig sichtbare Antriebe.</summary>
    public int DrivePageSize => 4;

    /// <summary>Warnschwelle der CPU-Auslastung in Prozent (Dummy, OP-27; A-62: ab 90 %).</summary>
    public double CpuWarningThreshold => 90;

    public int DriveCount => _drives.Count;

    public override void OnNavigatedTo(object? parameter)
    {
        _info.Changed += OnInfoChanged;
        _session.SessionChanged += OnSessionChanged;
        Refresh();
    }

    public override void OnNavigatedFrom()
    {
        _info.Changed -= OnInfoChanged;
        _session.SessionChanged -= OnSessionChanged;
    }

    private bool CanShowPrevious() => _first > 0;

    private bool CanShowNext() => _first + DrivePageSize < _drives.Count;

    [RelayCommand(CanExecute = nameof(CanShowPrevious))]
    private void ShowPrevious() => MoveWindow(_first - 1);

    [RelayCommand(CanExecute = nameof(CanShowNext))]
    private void ShowNext() => MoveWindow(_first + 1);

    [RelayCommand]
    private void ResetCpuMax() => _info.ResetCpuMax();

    private Task ResetDriveMaxAsync(DriveRowViewModel row)
    {
        _info.ResetDriveCurrentMax(row.Id);
        return Task.CompletedTask;
    }

    private async Task EditLimitAsync(DriveRowViewModel row)
    {
        if (!_session.HasRole(LimitRole))
        {
            _messages.ShowHint(_text.Format("Msg_PermissionRequired", _text.GetString($"Role_{LimitRole}")));
            if (!await _session.RequestRoleAsync(LimitRole))
            {
                return;
            }
        }

        var answer = await _dialogs.ShowAsync<double>(
            DialogKeys.Input,
            SystemDialogParameters.NumberInput(_text.Format("HS39_Limit_Title", row.Name), row.CurrentLimit, _text.GetString("HS39_Unit_Percent"), LimitMinimum, LimitMaximum, LimitDecimals));
        if (answer.Accepted)
        {
            _info.SetDriveCurrentLimit(row.Id, answer.Value);
        }
    }

    private void OnInfoChanged(object? sender, EventArgs e)
    {
        if (_sync is null)
        {
            Refresh();
        }
        else
        {
            _sync.Post(_ => Refresh(), null);
        }
    }

    private void OnSessionChanged(object? sender, EventArgs e)
    {
        foreach (var row in _drives)
        {
            row.IsLimitAuthorized = _session.HasRole(LimitRole);
        }
    }

    private void Refresh()
    {
        var snapshot = _info.GetSystemInfo();
        CpuCurrent = snapshot.CpuCurrent;
        CpuMax = snapshot.CpuMax;
        SystemStart = snapshot.SystemStart;
        TotalRuntime = snapshot.TotalRuntime;
        StatusText = snapshot.StatusText;
        DiagText = snapshot.DiagText;
        BuildTime = snapshot.BuildTime;

        var data = _info.GetDrives();
        if (_drives.Count != data.Count)
        {
            _drives.Clear();
            _drives.AddRange(data.Select(d => new DriveRowViewModel(d, ResetDriveMaxAsync, EditLimitAsync)));
            OnPropertyChanged(nameof(DriveCount));
        }
        else
        {
            for (var i = 0; i < data.Count; i++)
            {
                _drives[i].Update(data[i]);
            }
        }

        foreach (var row in _drives)
        {
            row.IsLimitAuthorized = _session.HasRole(LimitRole);
        }

        MoveWindow(_first);
    }

    private void MoveWindow(int first)
    {
        _first = Math.Clamp(first, 0, Math.Max(0, _drives.Count - DrivePageSize));
        VisibleDrives = _drives.Skip(_first).Take(DrivePageSize).ToList();
        RangeStart = _drives.Count == 0 ? 0 : _first + 1;
        RangeEnd = Math.Min(_drives.Count, _first + DrivePageSize);
        ShowPreviousCommand.NotifyCanExecuteChanged();
        ShowNextCommand.NotifyCanExecuteChanged();
    }
}
