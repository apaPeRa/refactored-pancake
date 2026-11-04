using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// Pop-up "Neuer Eintrag" der Zeitschaltuhr (HM-14 mit HM-30): Neuanlage, Bearbeiten Heizphase, Bearbeiten Absenkphase. Das Ergebnis (<see cref="HotGlueScheduleResult"/>)
/// speichert die Seite HS-10; Zeiteingaben oeffnen das Eingabe-Pop-up (zweite Ebene).
/// </summary>
[DialogKey(DialogKeys.ScheduleEntry)]
public sealed partial class HotGlueScheduleEntryViewModel : PopupViewModelBase
{
    private readonly IDialogService? _dialogs;
    private readonly ILocalizationService _localization;
    private HotGlueScheduleEntryRequest _request = new(DayOfWeek.Monday, null, Array.Empty<ScheduleEntry>(), true);

    [ObservableProperty]
    private ScheduleKind _kind;

    [ObservableProperty]
    private bool _startActive;

    [ObservableProperty]
    private bool _endActive;

    [ObservableProperty]
    private TimeOnly? _startTime;

    [ObservableProperty]
    private TimeOnly? _endTime;

    [ObservableProperty]
    private int _childCount;

    [ObservableProperty]
    private bool _isNew = true;

    [ObservableProperty]
    private string? _errorText;

    /// <summary>Entwurfsmodus.</summary>
    public HotGlueScheduleEntryViewModel()
        : this(null, LocalizationService.Instance)
    {
        Title = _localization.GetString("HS10_Entry_Title");
    }

    public HotGlueScheduleEntryViewModel(IDialogService? dialogs, ILocalizationService localization)
    {
        _dialogs = dialogs;
        _localization = localization;
    }

    public override void OnOpened(object? parameter)
    {
        // Titel immer "Neuer Eintrag", auch beim Bearbeiten (RS-10).
        Title = _localization.GetString("HS10_Entry_Title");
        if (parameter is not HotGlueScheduleEntryRequest request)
        {
            return;
        }

        _request = request;
        var existing = request.Existing;
        IsNew = existing is null;
        Kind = existing?.Kind ?? ScheduleKind.Heat;
        StartTime = existing?.Start;
        EndTime = existing?.End;
        StartActive = existing?.Start is not null;
        EndActive = existing?.End is not null;
        ChildCount = existing is null ? 0 : request.DayEntries.Count(e => e.ParentId == existing.Id);
        Validate();
    }

    partial void OnStartActiveChanged(bool value) => Validate();

    partial void OnEndActiveChanged(bool value) => Validate();

    partial void OnStartTimeChanged(TimeOnly? value) => Validate();

    partial void OnEndTimeChanged(TimeOnly? value) => Validate();

    partial void OnKindChanged(ScheduleKind value)
    {
        ChildCount = IsNew || value == ScheduleKind.Setback ? 0 : _request.DayEntries.Count(e => e.ParentId == _request.Existing?.Id);
        PreviousKindCommand.NotifyCanExecuteChanged();
        NextKindCommand.NotifyCanExecuteChanged();
    }

    protected override bool CanAccept() => string.IsNullOrEmpty(ErrorText) && (StartActive || EndActive) && _request.IsAuthorized;

    protected override object? GetResult() => new HotGlueScheduleResult(HotGlueScheduleAction.Save, BuildEntry());

    private ScheduleEntry BuildEntry()
    {
        var start = StartActive ? StartTime : null;
        var end = EndActive ? EndTime : null;
        int? parent = null;
        if (Kind == ScheduleKind.Setback)
        {
            parent = _request.Existing?.ParentId ?? ParentHeatPhase(start ?? end);
        }

        return new ScheduleEntry(_request.Existing?.Id ?? 0, _request.Day, Kind, start, end, parent);
    }

    // Annahme (OP-46): Absenkphase gehoert zur Heizphase des Tages, die ihre Startzeit umschliesst; sonst ohne Heizphase.
    private int? ParentHeatPhase(TimeOnly? time)
    {
        if (time is not { } t)
        {
            return null;
        }

        return _request.DayEntries
            .FirstOrDefault(e => e.Kind == ScheduleKind.Heat && e.Start is { } s && e.End is { } en && s <= t && t <= en)?.Id;
    }

    private void Validate()
    {
        if (!_request.IsAuthorized)
        {
            ErrorText = _localization.Format("Msg_PermissionRequired", _localization.GetString("Role_" + HotGlueEditContext.RequiredRole));
        }
        else if (!StartActive && !EndActive)
        {
            ErrorText = _localization.GetString("HS10_Error_NoTime");
        }
        else if (StartActive && EndActive && StartTime is { } s && EndTime is { } e && e < s)
        {
            ErrorText = _localization.GetString("HS10_Error_EndBeforeStart");
        }
        else if ((StartActive && StartTime is null) || (EndActive && EndTime is null))
        {
            ErrorText = _localization.GetString("HS10_Error_TimeMissing");
        }
        else
        {
            ErrorText = null;
        }

        AcceptCommand.NotifyCanExecuteChanged();
        DeleteCommand.NotifyCanExecuteChanged();
    }

    private bool CanDelete() => !IsNew && _request.IsAuthorized && !(Kind == ScheduleKind.Heat && ChildCount > 0);

    [RelayCommand(CanExecute = nameof(CanDelete))]
    private void Delete() => Close(true, new HotGlueScheduleResult(HotGlueScheduleAction.Delete, _request.Existing!));

    private bool CanPrevious() => IsNew && Kind == ScheduleKind.Setback;

    private bool CanNext() => IsNew && Kind == ScheduleKind.Heat;

    [RelayCommand(CanExecute = nameof(CanPrevious))]
    private void PreviousKind() => Kind = ScheduleKind.Heat;

    [RelayCommand(CanExecute = nameof(CanNext))]
    private void NextKind() => Kind = ScheduleKind.Setback;

    [RelayCommand]
    private async Task EditStartTimeAsync()
    {
        if (await RequestTimeAsync("HS10_StartTime_Title", StartTime) is { } time)
        {
            StartTime = time;
            StartActive = true;
        }
    }

    [RelayCommand]
    private async Task EditEndTimeAsync()
    {
        if (await RequestTimeAsync("HS10_EndTime_Title", EndTime) is { } time)
        {
            EndTime = time;
            EndActive = true;
        }
    }

    private async Task<TimeOnly?> RequestTimeAsync(string titleKey, TimeOnly? current)
    {
        if (_dialogs is null || !_request.IsAuthorized)
        {
            return null;
        }

        var minutes = current is { } c ? c.Hour * 60 + c.Minute : (double?)null;
        var request = new HotGlueInputRequest(_localization.GetString(titleKey), minutes, string.Empty, 0, 1439, 0, Controls.InputKind.Time);
        var result = await _dialogs.ShowAsync<double>(DialogKeys.Input, request);
        return result.Accepted ? TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(Math.Clamp(Math.Round(result.Value), 0, 1439))) : null;
    }
}
