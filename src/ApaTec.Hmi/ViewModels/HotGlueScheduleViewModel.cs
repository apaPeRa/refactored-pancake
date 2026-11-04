using ApaTec.Hmi.DesignData;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>HS-10 Zeitschaltuhr: Wochenraster (HM-29) mit Eintraegen je Tag; Plus-Taste und Eintraege oeffnen das Zeitplan-Eintrag-Pop-up (HM-30). Funktionsleiste leer.</summary>
[PageKey(PageKeys.HotGlueSchedule)]
public sealed partial class HotGlueScheduleViewModel : PageViewModelBase
{
    private readonly IHotGlueScheduleService _schedule;
    private readonly HotGlueEditContext _context;

    [ObservableProperty]
    private IReadOnlyList<ScheduleEntry> _entries = Array.Empty<ScheduleEntry>();

    [ObservableProperty]
    private bool _isAuthorized;

    [ObservableProperty]
    private bool _isOnline;

    /// <summary>Entwurfsmodus.</summary>
    public HotGlueScheduleViewModel()
        : this(HotGlueDesignData.ScheduleService, HotGlueDesignData.CreateContext())
    {
    }

    public HotGlueScheduleViewModel(
        IHotGlueScheduleService schedule, IHotGlueService service, IDialogService dialogs, IUserSession session, IMessageService messages, ILocalizationService localization)
        : this(schedule, new HotGlueEditContext(service, dialogs, session, messages, localization))
    {
    }

    private HotGlueScheduleViewModel(IHotGlueScheduleService schedule, HotGlueEditContext context)
    {
        _schedule = schedule;
        _context = context;
        Refresh();
    }

    public override void OnNavigatedTo(object? parameter)
    {
        _schedule.Changed -= OnChanged;
        _schedule.Changed += OnChanged;
        if (_context.Session is not null)
        {
            _context.Session.SessionChanged -= OnChanged;
            _context.Session.SessionChanged += OnChanged;
        }

        Refresh();
    }

    public override void OnNavigatedFrom()
    {
        _schedule.Changed -= OnChanged;
        if (_context.Session is not null)
        {
            _context.Session.SessionChanged -= OnChanged;
        }
    }

    private void OnChanged(object? sender, EventArgs e) => Refresh();

    private void Refresh()
    {
        Entries = _schedule.Entries.ToList();
        IsAuthorized = _context.IsAuthorized;
        IsOnline = _context.Service.IsConnected;
    }

    /// <summary>Plus-Taste eines Tages: ohne Rolle Hinweis und Anmeldung, mit Rolle Pop-up "Neuer Eintrag".</summary>
    [RelayCommand]
    private async Task AddAsync(DayOfWeek day)
    {
        if (!IsOnline || !await _context.EnsureAuthorizedAsync())
        {
            return;
        }

        await EditAsync(new HotGlueScheduleEntryRequest(day, null, DayEntries(day), true));
    }

    /// <summary>Antippen eines Eintrags: Pop-up im Bearbeiten-Zustand (Ansehen ohne Rolle erlaubt, Speichern und Loeschen gesperrt).</summary>
    [RelayCommand]
    private async Task EditEntryAsync(ScheduleEntry? entry)
    {
        if (entry is null || !IsOnline)
        {
            return;
        }

        await EditAsync(new HotGlueScheduleEntryRequest(entry.Day, entry, DayEntries(entry.Day), _context.IsAuthorized));
    }

    private IReadOnlyList<ScheduleEntry> DayEntries(DayOfWeek day) => _schedule.Entries.Where(e => e.Day == day).ToList();

    private async Task EditAsync(HotGlueScheduleEntryRequest request)
    {
        if (_context.Dialogs is null)
        {
            return;
        }

        var result = await _context.Dialogs.ShowAsync<HotGlueScheduleResult>(DialogKeys.ScheduleEntry, request);
        if (!result.Accepted || result.Value is null)
        {
            return;
        }

        try
        {
            switch (result.Value.Action)
            {
                case HotGlueScheduleAction.Delete:
                    await _schedule.DeleteAsync(result.Value.Entry.Id);
                    break;
                case HotGlueScheduleAction.Save when request.Existing is null:
                    await _schedule.AddAsync(result.Value.Entry);
                    break;
                default:
                    await _schedule.UpdateAsync(result.Value.Entry);
                    break;
            }
        }
        catch (Exception)
        {
            _context.Messages?.ShowHint(_context.Localization.GetString("HS10_Error_Transfer"));
        }

        Refresh();
    }
}
