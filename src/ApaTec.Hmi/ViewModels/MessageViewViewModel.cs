using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>HS-38 Meldeanzeige: anstehende Meldungen aufsteigend nach Nummer (live), Taste "Archiv" in der Funktionsleiste. Keine Berechtigung noetig.</summary>
[PageKey(PageKeys.MessageView)]
public sealed partial class MessageViewViewModel : PageViewModelBase
{
    private readonly IActiveMessageService _active;
    private readonly INavigationService _navigation;
    private readonly SynchronizationContext? _sync = SynchronizationContext.Current;

    [ObservableProperty]
    private IReadOnlyList<MessageEntry> _messages = Array.Empty<MessageEntry>();

    [ObservableProperty]
    private int _messageCount;

    /// <summary>Hinweis "Neue Meldung" am Listenanfang, wenn waehrend der Anzeige eine Meldung hinzukommt (Annahme S38-5).</summary>
    [ObservableProperty]
    private bool _hasNewMessage;

    public MessageViewViewModel(IActiveMessageService active, INavigationService navigation, ILocalizationService text)
    {
        _active = active;
        _navigation = navigation;
        Load(markNew: false);
        FunctionBarItems.Add(new FunctionBarItem
        {
            Label = text.GetString("HS38_Archive_Label"),
            IconKey = "Icon.List",
            Kind = FunctionBarItemKind.Action,
            TargetId = PageKeys.MessageArchive,
            Command = OpenArchiveCommand,
        });
    }

    /// <summary>Entwurfsmodus: Dummy-Dienst mit den Meldungen des Bildes.</summary>
    public MessageViewViewModel()
        : this(new DummyActiveMessageService(), null!, LocalizationService.Instance)
    {
    }

    public override void OnNavigatedTo(object? parameter)
    {
        HasNewMessage = false;
        Load(markNew: false);
        _active.Changed += OnActiveChanged;
    }

    public override void OnNavigatedFrom() => _active.Changed -= OnActiveChanged;

    [RelayCommand]
    private async Task OpenArchiveAsync() => await _navigation.NavigateToAsync(PageKeys.MessageArchive);

    private void OnActiveChanged(object? sender, EventArgs e)
    {
        if (_sync is null)
        {
            Load(markNew: true);
        }
        else
        {
            _sync.Post(_ => Load(markNew: true), null);
        }
    }

    private void Load(bool markNew)
    {
        var next = _active.GetActiveMessages();
        if (markNew && next.Any(n => Messages.All(m => m.Number != n.Number)))
        {
            HasNewMessage = true;
        }

        Messages = next;
        MessageCount = next.Count;
    }
}
