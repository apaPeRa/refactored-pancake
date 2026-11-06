using System.Collections.ObjectModel;
using ApaTec.Hmi.DesignData;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// HS-27 Waagen kalibrieren: Livegewicht, Filterwahl mit "Filter setzen", Nullpunkt, Statusanzeige, Tastenfolge Start Kalibrierung, Entlastet, Belastet, Reset
/// und die Ablaufgruppe mit den sieben Handbuchschritten. Die Blaettertasten in der Funktionsleiste wechseln nur den Parameter <c>scaleIndex</c> (kein Verlaufseintrag).
/// </summary>
[PageKey(PageKeys.ScaleCalibration)]
public sealed partial class ScaleCalibrationViewModel : PageViewModelBase
{
    /// <summary>Die Seite scrollt selbst und fuellt den Inhaltsbereich (S-01).</summary>
    public override bool FillsContentArea => true;

    /// <summary>Name des Seitenparameters (Navigation.md 5.1).</summary>
    public const string ScaleIndexParameter = "scaleIndex";

    /// <summary>Anzahl der Handbuchschritte der Ablaufgruppe.</summary>
    private const int StepCount = 7;

    /// <summary>Dummy-Rolle fuer alle Elemente mit Schluesselsymbol (OP-04, OP-25).</summary>
    private const UserRole RequiredRole = UserRole.Technician;

    private readonly IScaleCalibrationService _service;
    private readonly INavigationService? _navigation;
    private readonly IUserSession? _session;
    private readonly IMessageService? _messages;
    private readonly ILocalizationService _localization;
    private readonly SynchronizationContext? _context = SynchronizationContext.Current;
    private readonly FunctionBarItem _previousItem;
    private readonly FunctionBarItem _nextItem;
    private (string Key, NoticeKind Kind)? _statusOverride;
    private bool _subscribed;
    private int _writtenFilterIndex;

    [ObservableProperty]
    private int _scaleIndex;

    [ObservableProperty]
    private int _scaleCount;

    [ObservableProperty]
    private string _scaleName = string.Empty;

    [ObservableProperty]
    private string _positionText = string.Empty;

    /// <summary>Livegewicht in g; null = ungueltig ("---").</summary>
    [ObservableProperty]
    private double? _weight;

    [ObservableProperty]
    private IReadOnlyList<string> _filterTypes = Array.Empty<string>();

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(PreviousFilterCommand))]
    [NotifyCanExecuteChangedFor(nameof(NextFilterCommand))]
    private int _selectedFilterIndex;

    [ObservableProperty]
    private string _selectedFilterText = string.Empty;

    /// <summary>true, wenn die Auswahl vom geschriebenen Filter abweicht ("Nicht übernommen", K27-2).</summary>
    [ObservableProperty]
    private bool _isFilterPending;

    [ObservableProperty]
    private string _statusText = string.Empty;

    [ObservableProperty]
    private NoticeKind _statusKind = NoticeKind.Info;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsCalibrating))]
    [NotifyCanExecuteChangedFor(nameof(StartCalibrationCommand))]
    [NotifyCanExecuteChangedFor(nameof(ConfirmUnloadedCommand))]
    [NotifyCanExecuteChangedFor(nameof(ConfirmLoadedCommand))]
    private CalibrationStep _step;

    [ObservableProperty]
    private bool _isAuthorized = true;

    /// <summary>Entwurfsmodus: Dummy-Dienste, keine Navigation.</summary>
    public ScaleCalibrationViewModel()
        : this(new DummyScaleCalibrationService(), null, new DummyUserSession(), null, LocalizationService.Instance)
    {
    }

    public ScaleCalibrationViewModel(
        IScaleCalibrationService service,
        INavigationService? navigation,
        IUserSession? session,
        IMessageService? messages,
        ILocalizationService localization)
    {
        _service = service;
        _navigation = navigation;
        _session = session;
        _messages = messages;
        _localization = localization;

        for (var number = 1; number <= StepCount; number++)
        {
            Steps.Add(new ScaleCalibrationStepItem(number, _localization.GetString($"HS27_Step{number}_Text"), StepCaption(number, false)));
        }

        _previousItem = CreatePagerItem("HS27_Prev_Label", ShowPreviousScaleCommand);
        _nextItem = CreatePagerItem("HS27_Next_Label", ShowNextScaleCommand);
        FunctionBarItems.Add(_previousItem);
        FunctionBarItems.Add(_nextItem);

        IsAuthorized = session?.HasRole(RequiredRole) ?? true;
        FilterTypes = service.FilterTypes;
        ApplySnapshot(service.GetSnapshot(0), resetSelection: true);
    }

    /// <summary>Die sieben Schritte der Gruppe "Ablauf Kalibrierung" in Handbuchreihenfolge.</summary>
    public ObservableCollection<ScaleCalibrationStepItem> Steps { get; } = new();

    /// <summary>true, solange ein Kalibriervorgang laeuft; die Blaettertasten sind dann gesperrt (K27-4).</summary>
    public bool IsCalibrating => Step is CalibrationStep.AwaitUnloaded or CalibrationStep.AwaitLoaded;

    public override void OnNavigatedTo(object? parameter)
    {
        Subscribe();
        var count = Math.Max(1, _service.ScaleCount);
        var index = Math.Clamp(ReadIndex(parameter), 0, count - 1);
        _statusOverride = null;
        ApplySnapshot(_service.GetSnapshot(index), resetSelection: true);
    }

    public override void OnNavigatedFrom()
    {
        if (!_subscribed)
        {
            return;
        }

        _service.Changed -= OnServiceChanged;
        if (_session is not null)
        {
            _session.SessionChanged -= OnSessionChanged;
        }

        _subscribed = false;
    }

    private static int ReadIndex(object? parameter) => parameter switch
    {
        NavigationParameters p => p.Get<int>(ScaleIndexParameter),
        int i => i,
        _ => 0,
    };

    private void Subscribe()
    {
        if (_subscribed)
        {
            return;
        }

        _service.Changed += OnServiceChanged;
        if (_session is not null)
        {
            _session.SessionChanged += OnSessionChanged;
        }

        _subscribed = true;
    }

    private void OnServiceChanged(object? sender, int changedIndex)
    {
        if (changedIndex != ScaleIndex)
        {
            return;
        }

        RunOnUi(() => ApplySnapshot(_service.GetSnapshot(ScaleIndex), resetSelection: false));
    }

    private void OnSessionChanged(object? sender, EventArgs e) =>
        RunOnUi(() => IsAuthorized = _session?.HasRole(RequiredRole) ?? true);

    private void RunOnUi(Action action)
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

    // Uebernimmt den Zustand der Waage in die Anzeige. Die Filterauswahl bleibt beim Nachladen erhalten (resetSelection = false), sonst gilt der geschriebene Filter.
    private void ApplySnapshot(ScaleSnapshot snapshot, bool resetSelection)
    {
        ScaleIndex = snapshot.Index;
        ScaleCount = Math.Max(1, _service.ScaleCount);
        ScaleName = snapshot.Name;
        PositionText = _localization.Format("HS27_Position_Text", snapshot.Index + 1, ScaleCount);
        Weight = snapshot.IsFaulted ? null : snapshot.Weight;
        Step = snapshot.Step;
        _writtenFilterIndex = snapshot.WrittenFilterIndex;
        if (resetSelection)
        {
            SelectedFilterIndex = snapshot.WrittenFilterIndex;
        }

        UpdateFilterDisplay();
        UpdateSteps();
        UpdateStatus(snapshot);
        UpdatePager();
    }

    private void UpdateFilterDisplay()
    {
        SelectedFilterText = SelectedFilterIndex >= 0 && SelectedFilterIndex < FilterTypes.Count ? FilterTypes[SelectedFilterIndex] : string.Empty;
        IsFilterPending = SelectedFilterIndex != _writtenFilterIndex;
    }

    partial void OnSelectedFilterIndexChanged(int value) => UpdateFilterDisplay();

    private void UpdateSteps()
    {
        var current = Step switch
        {
            CalibrationStep.AwaitUnloaded => 3,
            CalibrationStep.AwaitLoaded => 4,
            CalibrationStep.Completed => 5,
            _ => 0,
        };
        foreach (var item in Steps)
        {
            item.IsCurrent = item.Number == current;
            item.Caption = StepCaption(item.Number, item.IsCurrent);
        }
    }

    private string StepCaption(int number, bool isCurrent) =>
        _localization.Format(isCurrent ? "HS27_StepCurrent_Caption" : "HS27_Step_Caption", number);

    // Statusanzeige: eine aktuelle Rueckmeldung (Fehler, Bestaetigung) hat Vorrang, sonst gilt die Aufforderung zum gemeldeten Schritt.
    private void UpdateStatus(ScaleSnapshot snapshot)
    {
        if (_statusOverride is { } o)
        {
            StatusKind = o.Kind;
            StatusText = _localization.GetString(o.Key);
            return;
        }

        if (snapshot.IsFaulted)
        {
            StatusKind = NoticeKind.Error;
            StatusText = _localization.GetString("HS27_Status_ScaleFault");
            return;
        }

        StatusKind = NoticeKind.Info;
        StatusText = _localization.GetString(snapshot.Step switch
        {
            CalibrationStep.AwaitUnloaded => "HS27_Status_AwaitUnloaded",
            CalibrationStep.AwaitLoaded => "HS27_Status_AwaitLoaded",
            CalibrationStep.Completed => "HS27_Status_Completed",
            _ => "HS27_Status_Idle",
        });
    }

    private void UpdatePager()
    {
        _previousItem.IsEnabled = !IsCalibrating && ScaleIndex > 0;
        _nextItem.IsEnabled = !IsCalibrating && ScaleIndex < ScaleCount - 1;
    }

    private FunctionBarItem CreatePagerItem(string labelKey, IRelayCommand command) => new()
    {
        Label = _localization.GetString(labelKey),
        Command = command,
        Kind = FunctionBarItemKind.Paging,
    };

    // Berechtigung: ohne Rolle Hinweis in der Meldezeile und Benutzer-Pop-up; nach erfolgreicher Anmeldung laeuft die Aktion weiter (Navigation.md 4.1).
    private async Task<bool> EnsureRoleAsync()
    {
        if (_session is null || _session.HasRole(RequiredRole))
        {
            return true;
        }

        _messages?.ShowHint(_localization.Format("Msg_PermissionRequired", _localization.GetString("Role_Technician")));
        return await _session.RequestRoleAsync(RequiredRole);
    }

    // Verarbeitet das Ergebnis eines Schreibbefehls; Erfolg setzt optional eine Bestaetigung, Fehler die Fehlermeldung der Statusanzeige.
    private void Complete(ScaleOperationResult result, string? successKey)
    {
        _statusOverride = result switch
        {
            ScaleOperationResult.Success => successKey is null ? null : (successKey, NoticeKind.Info),
            ScaleOperationResult.FilterWriteFailed => ("HS27_Status_FilterWriteFailed", NoticeKind.Error),
            ScaleOperationResult.ScaleFault => ("HS27_Status_ScaleFault", NoticeKind.Error),
            _ => ("HS27_Status_NotAllowed", NoticeKind.Warning),
        };
        ApplySnapshot(_service.GetSnapshot(ScaleIndex), resetSelection: false);
    }

    [RelayCommand(CanExecute = nameof(CanSelectPreviousFilter))]
    private async Task PreviousFilterAsync()
    {
        if (await EnsureRoleAsync())
        {
            SelectedFilterIndex--;
        }
    }

    private bool CanSelectPreviousFilter() => SelectedFilterIndex > 0;

    [RelayCommand(CanExecute = nameof(CanSelectNextFilter))]
    private async Task NextFilterAsync()
    {
        if (await EnsureRoleAsync())
        {
            SelectedFilterIndex++;
        }
    }

    private bool CanSelectNextFilter() => SelectedFilterIndex < FilterTypes.Count - 1;

    [RelayCommand]
    private async Task SetFilterAsync()
    {
        if (!await EnsureRoleAsync())
        {
            return;
        }

        var result = await _service.SetFilterAsync(ScaleIndex, SelectedFilterIndex);
        Complete(result, "HS27_Status_FilterWritten");
    }

    [RelayCommand]
    private async Task SetZeroAsync()
    {
        var result = await _service.SetZeroAsync(ScaleIndex);
        Complete(result, "HS27_Status_ZeroSet");
    }

    [RelayCommand(CanExecute = nameof(CanStartCalibration))]
    private async Task StartCalibrationAsync()
    {
        if (!await EnsureRoleAsync())
        {
            return;
        }

        var result = await _service.StartCalibrationAsync(ScaleIndex);
        Complete(result, null);
    }

    private bool CanStartCalibration() => Step is CalibrationStep.Idle or CalibrationStep.Completed;

    [RelayCommand(CanExecute = nameof(CanConfirmUnloaded))]
    private async Task ConfirmUnloadedAsync()
    {
        if (!await EnsureRoleAsync())
        {
            return;
        }

        var result = await _service.ConfirmUnloadedAsync(ScaleIndex);
        Complete(result, null);
    }

    private bool CanConfirmUnloaded() => Step == CalibrationStep.AwaitUnloaded;

    [RelayCommand(CanExecute = nameof(CanConfirmLoaded))]
    private async Task ConfirmLoadedAsync()
    {
        if (!await EnsureRoleAsync())
        {
            return;
        }

        var result = await _service.ConfirmLoadedAsync(ScaleIndex);
        Complete(result, null);
    }

    private bool CanConfirmLoaded() => Step == CalibrationStep.AwaitLoaded;

    // Reset ist immer bedienbar und braucht keine Berechtigung; leert die Fehlermeldung der Statusanzeige.
    [RelayCommand]
    private async Task ResetAsync()
    {
        await _service.ResetAsync(ScaleIndex);
        _statusOverride = null;
        ApplySnapshot(_service.GetSnapshot(ScaleIndex), resetSelection: true);
    }

    [RelayCommand]
    private void ShowPreviousScale()
    {
        if (!IsCalibrating && ScaleIndex > 0)
        {
            _navigation?.ReplaceParameter(new NavigationParameters(ScaleIndexParameter, ScaleIndex - 1));
        }
    }

    [RelayCommand]
    private void ShowNextScale()
    {
        if (!IsCalibrating && ScaleIndex < ScaleCount - 1)
        {
            _navigation?.ReplaceParameter(new NavigationParameters(ScaleIndexParameter, ScaleIndex + 1));
        }
    }
}
