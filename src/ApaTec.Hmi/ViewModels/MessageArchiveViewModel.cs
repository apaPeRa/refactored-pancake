using System.Globalization;
using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>HS-37 Meldearchiv: Liste (neueste zuerst) mit vier Scrolltasten, Export, Liste leeren, Filter, Alle anzeigen.</summary>
[PageKey(PageKeys.MessageArchive)]
public sealed partial class MessageArchiveViewModel : PageViewModelBase
{
    /// <summary>Die Seite scrollt selbst und fuellt den Inhaltsbereich (S-01).</summary>
    public override bool FillsContentArea => true;

    /// <summary>Rollenstufe der Schluessel-Tasten Export und Liste leeren (Dummy, OP-25).</summary>
    private const UserRole ActionRole = UserRole.Technician;

    /// <summary>Zeilen je Seite der Scrolltasten (Annahme: das ViewModel kennt die Anzeigehoehe nicht).</summary>
    private const int PageSize = 10;

    private const string TimeFormat = "dd.MM.yyyy HH:mm:ss";

    private readonly IMessageArchiveService _archive;
    private readonly IDialogService _dialogs;
    private readonly IUserSession _session;
    private readonly IMessageService _messages;
    private readonly ILocalizationService _text;
    private IReadOnlyList<MessageEntry> _all = Array.Empty<MessageEntry>();
    private ArchiveFilter? _filter;
    private int _offset;

    [ObservableProperty]
    private IReadOnlyList<MessageEntry> _visibleEntries = Array.Empty<MessageEntry>();

    [ObservableProperty]
    private int _totalCount;

    [ObservableProperty]
    private bool _isFiltered;

    [ObservableProperty]
    private bool _isBusy;

    public MessageArchiveViewModel(
        IMessageArchiveService archive,
        IDialogService dialogs,
        IUserSession session,
        IMessageService messages,
        ILocalizationService text)
    {
        _archive = archive;
        _dialogs = dialogs;
        _session = session;
        _messages = messages;
        _text = text;
        Reload();
    }

    /// <summary>Entwurfsmodus: Dummy-Dienst mit den Beispielmeldungen.</summary>
    public MessageArchiveViewModel()
        : this(new DummyMessageArchiveService(), null!, new DummyUserSession(), new DummyMessageService(), LocalizationService.Instance)
    {
    }

    public bool IsPrivilegedAuthorized => _session.HasRole(ActionRole);

    public override void OnNavigatedTo(object? parameter)
    {
        _session.SessionChanged += OnSessionChanged;
        OnPropertyChanged(nameof(IsPrivilegedAuthorized));
    }

    public override void OnNavigatedFrom() => _session.SessionChanged -= OnSessionChanged;

    private void OnSessionChanged(object? sender, EventArgs e) => OnPropertyChanged(nameof(IsPrivilegedAuthorized));

    private int MaxOffset => Math.Max(0, _all.Count - PageSize);

    private bool CanScrollBack() => _offset > 0;

    private bool CanScrollForward() => _offset < MaxOffset;

    private bool CanRun() => !IsBusy;

    private bool CanShowAll() => IsFiltered;

    partial void OnIsBusyChanged(bool value)
    {
        ExportCommand.NotifyCanExecuteChanged();
        ClearListCommand.NotifyCanExecuteChanged();
        FilterCommand.NotifyCanExecuteChanged();
    }

    [RelayCommand(CanExecute = nameof(CanScrollBack))]
    private void ScrollFirst() => MoveTo(0);

    [RelayCommand(CanExecute = nameof(CanScrollBack))]
    private void ScrollPageUp() => MoveTo(_offset - PageSize);

    [RelayCommand(CanExecute = nameof(CanScrollForward))]
    private void ScrollPageDown() => MoveTo(_offset + PageSize);

    [RelayCommand(CanExecute = nameof(CanScrollForward))]
    private void ScrollLast() => MoveTo(MaxOffset);

    [RelayCommand(CanExecute = nameof(CanRun))]
    private async Task ExportAsync()
    {
        if (!await EnsureRoleAsync())
        {
            return;
        }

        var title = _text.GetString("HS37_Export_Title");
        var suggested = _text.GetString("HS37_File_SuggestedName");
        var request = new FileOperationRequest(
            file => _archive.ExportAsync(_filter, string.IsNullOrWhiteSpace(file) ? suggested : file),
            result => result.Success
                ? _text.Format("HS37_Result_ExportOk", result.Count)
                : result.ErrorText ?? _text.GetString("HS37_Result_Failed"),
            busy => IsBusy = busy);
        // Auswahl, Laeuft und Ergebnis in einem Datei-Pop-up.
        await _dialogs.ShowAsync<string>(DialogKeys.FileResult, SystemDialogParameters.FileRun(title, suggested, request));
    }

    [RelayCommand(CanExecute = nameof(CanRun))]
    private async Task ClearListAsync()
    {
        if (!await EnsureRoleAsync())
        {
            return;
        }

        var answer = await _dialogs.ShowAsync<bool>(
            DialogKeys.Confirmation,
            SystemDialogParameters.Confirmation(
                _text.GetString("HS37_Clear_Title"),
                _text.GetString("HS37_Clear_Message"),
                _text.GetString("HM14_Confirm_Label"),
                _text.GetString("Popup_Cancel_Label")));
        if (answer.Accepted)
        {
            await _archive.ClearAsync();
            Reload();
        }
    }

    [RelayCommand(CanExecute = nameof(CanRun))]
    private async Task FilterAsync()
    {
        var fields = new List<FilterField>
        {
            new()
            {
                Name = _text.GetString("HS37_Filter_Number"),
                Kind = FilterFieldKind.Number,
                Value = _filter?.Number?.ToString("000", CultureInfo.InvariantCulture) ?? string.Empty,
                Placeholder = _text.GetString("HS37_Filter_NumberPlaceholder"),
                IsActive = true,
            },
            new()
            {
                Name = _text.GetString("HS37_Filter_Time"),
                Kind = FilterFieldKind.DateTime,
                Value = _filter?.From?.ToString(TimeFormat, CultureInfo.InvariantCulture) ?? string.Empty,
                Placeholder = _text.GetString("HS37_Filter_TimePlaceholder"),
            },
        };
        var answer = await _dialogs.ShowAsync<IReadOnlyList<FilterField>>(
            DialogKeys.Filter,
            SystemDialogParameters.Filter(_text.GetString("HS37_Filter_Title"), fields));
        if (!answer.Accepted || answer.Value is null)
        {
            return;
        }

        int? number = answer.Value.Count > 0 && int.TryParse(answer.Value[0].Value, NumberStyles.None, CultureInfo.InvariantCulture, out var n) ? n : null;
        DateTime? from = answer.Value.Count > 1 && DateTime.TryParseExact(answer.Value[1].Value, TimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var t) ? t : null;
        _filter = new ArchiveFilter(number, from);
        if (_filter.IsEmpty)
        {
            _filter = null;
        }

        Reload();
    }

    [RelayCommand(CanExecute = nameof(CanShowAll))]
    private void ShowAll()
    {
        _filter = null;
        Reload();
    }

    private void Reload()
    {
        _all = _archive.GetEntries(_filter);
        IsFiltered = _filter is not null;
        ShowAllCommand.NotifyCanExecuteChanged();
        MoveTo(0);
    }

    private void MoveTo(int offset)
    {
        _offset = Math.Clamp(offset, 0, MaxOffset);
        VisibleEntries = _all.Skip(_offset).Take(PageSize).ToList();
        TotalCount = _all.Count;
        ScrollFirstCommand.NotifyCanExecuteChanged();
        ScrollPageUpCommand.NotifyCanExecuteChanged();
        ScrollPageDownCommand.NotifyCanExecuteChanged();
        ScrollLastCommand.NotifyCanExecuteChanged();
    }

    private async Task<bool> EnsureRoleAsync()
    {
        if (_session.HasRole(ActionRole))
        {
            return true;
        }

        _messages.ShowHint(_text.Format("Msg_PermissionRequired", _text.GetString($"Role_{ActionRole}")));
        return await _session.RequestRoleAsync(ActionRole);
    }
}
