using System.Collections.ObjectModel;
using System.ComponentModel;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>HS-36 Service: Variablenliste mit Filter und Mehrfachauswahl, Import und Export, Taste "Wago". Seitenzugang: Mindestrolle Technik (Seitenregister).</summary>
[PageKey(PageKeys.Service)]
public sealed partial class ServiceViewModel : PageViewModelBase
{
    /// <summary>Anzeigelimit der Liste ("500 von 111427", OP-49).</summary>
    private const int DisplayLimit = 500;

    private readonly IServiceDataService _service;
    private readonly IDialogService _dialogs;
    private readonly ILocalizationService _text;
    private readonly IMessageService _messages;
    private readonly HashSet<string> _selectedNames = new(StringComparer.Ordinal);
    private IReadOnlyList<MessageEntry> _entries = Array.Empty<MessageEntry>();
    private string? _markedName;

    [ObservableProperty]
    private string _filterText = string.Empty;

    [ObservableProperty]
    private IReadOnlyList<MessageEntry> _variables = Array.Empty<MessageEntry>();

    [ObservableProperty]
    private int _totalCount;

    [ObservableProperty]
    private double? _markedValue;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HintText), nameof(HasHint))]
    private bool _isBusy;

    public ServiceViewModel(IServiceDataService service, IDialogService dialogs, IMessageService messages, ILocalizationService text)
    {
        _service = service;
        _dialogs = dialogs;
        _messages = messages;
        _text = text;
        FunctionBarItems.Add(new FunctionBarItem { Label = _text.GetString("HS36_Wago_Label"), Kind = FunctionBarItemKind.Action, Command = WagoCommand });
        Reload();
    }

    /// <summary>Entwurfsmodus: Dummy-Dienst; die zehnte Variable ist markiert (Bild: alrPos[10]).</summary>
    public ServiceViewModel()
        : this(new DummyServiceDataService(), null!, new DummyMessageService(), LocalizationService.Instance)
    {
        if (_entries.Count > 9)
        {
            _entries[9].IsSelected = true;
        }
    }

    /// <summary>Aktuell markierte Zeilen der angezeigten Liste (fuer den Auswahlzaehler von HM-25).</summary>
    public ObservableCollection<MessageEntry> SelectedVariables { get; } = new();

    public bool HasSelection => _selectedNames.Count > 0;

    /// <summary>Grund fuer gesperrte Tasten bzw. Fortschrittstext (zweiter Kanal zur gestrichelten Kontur).</summary>
    public string HintText => IsBusy
        ? _text.GetString("HS36_Hint_Busy")
        : HasSelection ? string.Empty : _text.GetString("HS36_Hint_NoSelection");

    public bool HasHint => HintText.Length > 0;

    private bool CanRun() => !IsBusy;

    private bool CanExportList() => !IsBusy && HasSelection;

    partial void OnIsBusyChanged(bool value)
    {
        ImportCommand.NotifyCanExecuteChanged();
        ExportAllCommand.NotifyCanExecuteChanged();
        ExportListCommand.NotifyCanExecuteChanged();
    }

    [RelayCommand]
    private async Task EditFilterAsync()
    {
        var answer = await _dialogs.ShowAsync<string>(DialogKeys.Input, SystemDialogParameters.TextInput(_text.GetString("HS36_Filter_Title"), FilterText));
        if (answer.Accepted)
        {
            FilterText = answer.Value ?? string.Empty;
            Reload();
        }
    }

    [RelayCommand]
    private async Task WagoAsync()
    {
        if (await _service.RunWagoAsync())
        {
            _messages.ShowHint(_text.GetString("HS36_Wago_Hint"));
        }
    }

    [RelayCommand(CanExecute = nameof(CanRun))]
    private Task ImportAsync() => RunFileOperationAsync("HS36_Import_Title", confirmKey: "HS36_Import_Confirm", "HS36_Result_ImportOk", _service.ImportAsync);

    [RelayCommand(CanExecute = nameof(CanRun))]
    private Task ExportAllAsync() => RunFileOperationAsync("HS36_ExportAll_Title", null, "HS36_Result_ExportOk", _service.ExportAllAsync);

    [RelayCommand(CanExecute = nameof(CanExportList))]
    private Task ExportListAsync() =>
        RunFileOperationAsync("HS36_ExportList_Title", null, "HS36_Result_ExportOk", file => _service.ExportSelectionAsync(_selectedNames.ToList(), file));

    // Ablauf: Dateiauswahl, optional Bestaetigung, Vorgang (Tasten gesperrt), Ergebnis. Pop-ups laufen nacheinander, nie gestapelt.
    private async Task RunFileOperationAsync(string titleKey, string? confirmKey, string okKey, Func<string, Task<FileOperationResult>> operation)
    {
        var title = _text.GetString(titleKey);
        var suggested = _text.GetString("HS36_File_SuggestedName");
        var file = await _dialogs.ShowAsync<string>(DialogKeys.FileResult, SystemDialogParameters.FileSelect(title, suggested));
        if (!file.Accepted)
        {
            return;
        }

        if (confirmKey is not null)
        {
            await Task.Yield();
            var answer = await _dialogs.ShowAsync<bool>(
                DialogKeys.Confirmation,
                SystemDialogParameters.Confirmation(title, _text.GetString(confirmKey), _text.GetString("HM14_Confirm_Label"), _text.GetString("Popup_Cancel_Label")));
            if (!answer.Accepted)
            {
                return;
            }
        }

        FileOperationResult result;
        IsBusy = true;
        try
        {
            result = await operation(string.IsNullOrWhiteSpace(file.Value) ? suggested : file.Value);
        }
        finally
        {
            IsBusy = false;
        }

        var message = result.Success
            ? _text.Format(okKey, result.Count)
            : result.ErrorText ?? _text.GetString("HS36_Result_Failed");
        await Task.Yield();
        await _dialogs.ShowAsync<object>(DialogKeys.FileResult, SystemDialogParameters.FileResult(title, result.Success, message));
    }

    private void Reload()
    {
        foreach (var old in _entries)
        {
            old.PropertyChanged -= OnEntryChanged;
        }

        var query = _service.Query(FilterText, DisplayLimit);
        _entries = query.Names
            .Select(name => new MessageEntry { Text = name, Class = MessageClass.None, IsSelected = _selectedNames.Contains(name) })
            .ToList();
        foreach (var entry in _entries)
        {
            entry.PropertyChanged += OnEntryChanged;
        }

        Variables = _entries;
        TotalCount = query.MatchCount;
        SelectedVariables.Clear();
        foreach (var entry in _entries.Where(e => e.IsSelected))
        {
            SelectedVariables.Add(entry);
        }

        UpdateSelectionState();
    }

    private void OnEntryChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (sender is not MessageEntry entry || e.PropertyName != nameof(MessageEntry.IsSelected))
        {
            return;
        }

        if (entry.IsSelected)
        {
            _selectedNames.Add(entry.Text);
            _markedName = entry.Text;
            SelectedVariables.Add(entry);
        }
        else
        {
            _selectedNames.Remove(entry.Text);
            SelectedVariables.Remove(entry);
            if (_markedName == entry.Text)
            {
                _markedName = _selectedNames.LastOrDefault();
            }
        }

        UpdateSelectionState();
    }

    private void UpdateSelectionState()
    {
        if (_markedName is null && _selectedNames.Count > 0)
        {
            _markedName = _selectedNames.Last();
        }

        MarkedValue = _markedName is null ? null : _service.GetValue(_markedName);
        OnPropertyChanged(nameof(HasSelection));
        OnPropertyChanged(nameof(HintText));
        OnPropertyChanged(nameof(HasHint));
        ExportListCommand.NotifyCanExecuteChanged();
    }
}
