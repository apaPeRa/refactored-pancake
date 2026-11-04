using System.Collections.ObjectModel;
using ApaTec.Hmi.DesignData;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// ViewModel des Hauptfensters (Rahmen HM-01 bis HM-06, Konzept.md 6.5). Haelt die aktuelle Seite, das Pop-up, die Rahmenzustaende und die Rahmenbefehle.
/// Erweiterungspunkte fuer die Rahmenmodule: siehe src/README.md, Abschnitt "Hauptfenster und Rahmen".
/// Betriebsart, Geschwindigkeit und Winkel kommen aus <see cref="IMachineStatusService"/>, Meldung und Meldezaehler aus <see cref="IMessageService"/> (Konzept.md 6.6);
/// die Anfangswerte der Eigenschaften sind die Entwurfswerte (<see cref="ShellDesignData"/>) fuer den parameterlosen Entwurfskonstruktor.
/// </summary>
public sealed partial class ShellViewModel : ObservableObject
{
    private readonly INavigationService _navigation;
    private readonly IUserSession _session;
    private readonly IClockService _clock;
    private readonly IDialogService _dialogs;
    private readonly IMachineStatusService _machine;
    private readonly IMessageService _messages;
    private readonly ILocalizationService _localization;

    // ---- Inhalt und Pop-up ----
    [ObservableProperty]
    private PageViewModelBase? _currentPage;

    [ObservableProperty]
    private PopupViewModelBase? _currentPopup;

    /// <summary>true, solange ein Pop-up offen ist; Seitenleiste, Brotkruemel, Kennzahl "Geschwindigkeit" und Funktionsleiste sind dann gesperrt (Navigation.md 4.2).</summary>
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsFrameInteractive))]
    private bool _isModalOpen;

    // ---- Rahmenvarianten (Konzept.md 2) ----
    /// <summary>false nur im Vollbild (HS-24): Seitenleiste, Brotkruemel, Kennzahlen und Funktionsleiste ausgeblendet.</summary>
    [ObservableProperty]
    private bool _showFrame = true;

    [ObservableProperty]
    private bool _showMessageLine = true;

    /// <summary>false hinter einem Pop-up: bedienbare Rahmenelemente (HM-01, HM-04, HM-05, HM-06) sind gesperrt, bleiben aber sichtbar.</summary>
    public bool IsFrameInteractive => !IsModalOpen;

    // ---- HM-01 Seitenleiste ----
    [ObservableProperty]
    private bool _isLoggedIn = true;

    /// <summary>Die oberen Seitenleisten-Eintraege Home, Einstellungen, Meldungen (Zurueck steht fest in HM-01).</summary>
    [ObservableProperty]
    private IReadOnlyList<SidebarItem> _sidebarItems = Array.Empty<SidebarItem>();

    [ObservableProperty]
    private string _userInitials = string.Empty;

    [ObservableProperty]
    private string _userName = string.Empty;

    [ObservableProperty]
    private string _userRoleText = string.Empty;

    [ObservableProperty]
    private int _unreadMessageCount = ShellDesignData.UnreadMessageCount;

    [ObservableProperty]
    private string _currentSidebarItemId = SidebarItemIds.Home;

    [ObservableProperty]
    private bool _canGoBack;

    // ---- HM-02 Kopfzeile / HM-03 Meldezeile ----
    [ObservableProperty]
    private OperatingMode _operatingMode = ShellDesignData.OperatingMode;

    [ObservableProperty]
    private string _operatingModeText = string.Empty;

    [ObservableProperty]
    private DateTime _now;

    [ObservableProperty]
    private int? _messageNumber = ShellDesignData.MessageNumber;

    [ObservableProperty]
    private string _messageText = ShellDesignData.MessageText;

    [ObservableProperty]
    private MessageClass _messageClass = ShellDesignData.MessageClass;

    [ObservableProperty]
    private int _additionalMessageCount = ShellDesignData.AdditionalMessageCount;

    // ---- HM-04 Brotkruemel ----
    [ObservableProperty]
    private IReadOnlyList<BreadcrumbItem> _breadcrumb = Array.Empty<BreadcrumbItem>();

    // ---- HM-05 Kennzahlen ----
    [ObservableProperty]
    private double _machineSpeed = ShellDesignData.MachineSpeed;

    [ObservableProperty]
    private double _machineAngle = ShellDesignData.MachineAngle;

    // ---- HM-06 Funktionsleiste ----
    /// <summary>Schluessel der aktuellen Seite (HM-06 <c>CurrentTargetId</c>).</summary>
    [ObservableProperty]
    private string _currentPageKey = string.Empty;

    [ObservableProperty]
    private ObservableCollection<FunctionBarItem>? _functionBarItems;

    public ShellViewModel(
        INavigationService navigation,
        IUserSession session,
        IClockService clock,
        IDialogService dialogs,
        IMachineStatusService machine,
        IMessageService messages,
        ILocalizationService localization)
    {
        _navigation = navigation;
        _session = session;
        _clock = clock;
        _dialogs = dialogs;
        _machine = machine;
        _messages = messages;
        _localization = localization;

        _navigation.Navigated += (_, _) => RefreshFromNavigation();
        _navigation.PopupStackChanged += (_, _) => RefreshPopup();
        _session.SessionChanged += (_, _) => RefreshUser();
        _clock.Tick += (_, _) => Now = _clock.Now;
        _machine.Changed += (_, _) => RefreshMachine();
        _messages.Changed += (_, _) => RefreshMessages();
        _localization.CultureChanged += (_, _) => RefreshTexts();

        Now = _clock.Now;
        RefreshMachine();
        RefreshMessages();
        RefreshUser();
        RefreshFromNavigation();
        RefreshPopup();
        RefreshTexts();
    }

    /// <summary>Entwurfsmodus: leerer Rahmen mit Beispielwerten, ohne Dienste.</summary>
    public ShellViewModel()
    {
        _navigation = null!;
        _session = null!;
        _clock = null!;
        _dialogs = null!;
        _machine = null!;
        _messages = null!;
        _localization = LocalizationService.Instance;
        UserInitials = "MM";
        UserName = "Max Mustermann";
        UserRoleText = _localization.GetString("HM01_Role_Technician");
        Now = new DateTime(2026, 1, 6, 9, 15, 0);
        RefreshTexts();
    }

    // ---- Befehle (Seitenleiste, Brotkruemel, Meldezeile, Kennzahl) ----
    [RelayCommand]
    private void Home() => _navigation.GoHome();

    [RelayCommand]
    private void Settings() => _navigation.GoToSettings();

    [RelayCommand]
    private async Task MessagesAsync() => await _navigation.OpenMessagesAsync();

    /// <summary>Zurueck; auf der Startseite (nichts im Verlauf) nennt die Meldezeile den Grund (A-28).</summary>
    [RelayCommand]
    private void Back()
    {
        if (!CanGoBack)
        {
            _messages.ShowHint(_localization.GetString("HM01_Back_DisabledReason"));
            return;
        }

        _navigation.GoBack();
    }

    /// <summary>Parameter: Kennung des Seitenleisten-Eintrags (<see cref="SidebarItemIds"/>); bildet die festen Navigationstasten nach Navigation.md 3.1 ab.</summary>
    [RelayCommand]
    private async Task SidebarNavigateAsync(string itemId)
    {
        switch (itemId)
        {
            case SidebarItemIds.Home:
                _navigation.GoHome();
                break;
            case SidebarItemIds.Settings:
                _navigation.GoToSettings();
                break;
            case SidebarItemIds.Messages:
                await _navigation.OpenMessagesAsync();
                break;
        }
    }

    [RelayCommand]
    private async Task UserAsync() => await _dialogs.ShowAsync<object>(DialogKeys.User);

    /// <summary>Parameter: Seitenschluessel des Segments (HM-04 <c>NavigateCommand</c>).</summary>
    [RelayCommand]
    private void NavigateToAncestor(string pageKey) => _navigation.GoToAncestor(pageKey);

    /// <summary>Parameter: Seitenschluessel (HM-01 <c>NavigateCommand</c>, Kacheln, Kennzahl "Geschwindigkeit" mit <see cref="PageKeys.MachineSpeed"/>).</summary>
    [RelayCommand]
    private async Task NavigateAsync(string pageKey) => await _navigation.NavigateToAsync(pageKey);

    private void RefreshFromNavigation()
    {
        CurrentPage = _navigation.CurrentViewModel;
        Breadcrumb = _navigation.Breadcrumb;
        FunctionBarItems = _navigation.CurrentViewModel?.FunctionBarItems;
        CurrentPageKey = _navigation.Current?.Key ?? string.Empty;
        CanGoBack = _navigation.CanGoBack;
        ShowFrame = _navigation.Current?.ShowFrame ?? true;
        ShowMessageLine = ShowFrame;
        CurrentSidebarItemId = Breadcrumb.Count > 0 ? Breadcrumb[0].Key switch
        {
            PageKeys.Settings => SidebarItemIds.Settings,
            PageKeys.MessageView => SidebarItemIds.Messages,
            _ => SidebarItemIds.Home,
        }
        : SidebarItemIds.Home;
    }

    private void RefreshPopup()
    {
        CurrentPopup = _navigation.CurrentPopup;
        IsModalOpen = _navigation.IsModalOpen;
        CanGoBack = _navigation.CanGoBack;
    }

    private void RefreshUser()
    {
        var user = _session.Current;
        UserInitials = user.Initials;
        UserName = user.Name;
        UserRoleText = _localization.GetString($"HM01_Role_{user.Role}");
        IsLoggedIn = user.Initials.Length > 0;
    }

    private void RefreshMachine()
    {
        OperatingMode = _machine.OperatingMode;
        MachineSpeed = _machine.Speed;
        MachineAngle = _machine.Angle;
        OperatingModeText = _localization.GetString($"HM02_Mode_{_machine.OperatingMode}");
    }

    private void RefreshMessages()
    {
        var message = _messages.Current;
        MessageNumber = message?.Number;
        MessageText = message?.Text ?? string.Empty;
        MessageClass = message?.Class ?? MessageClass.None;
        AdditionalMessageCount = _messages.AdditionalCount;
        UnreadMessageCount = _messages.UnreadCount;
    }

    /// <summary>Sprachabhaengige Texte (Seitenleistenbeschriftungen, Rolle, Betriebsart) neu aufbauen.</summary>
    private void RefreshTexts()
    {
        SidebarItems = new[]
        {
            new SidebarItem { Id = SidebarItemIds.Home, Label = _localization.GetString("Nav_Home_Label"), IconKey = "Icon.Home" },
            new SidebarItem { Id = SidebarItemIds.Settings, Label = _localization.GetString("Nav_SettingsButton_Label"), IconKey = "Icon.Settings" },
            new SidebarItem { Id = SidebarItemIds.Messages, Label = _localization.GetString("Nav_MessagesButton_Label"), IconKey = "Icon.Messages", ShowsBadge = true },
        };

        if (_session is not null)
        {
            RefreshUser();
        }

        if (_machine is not null)
        {
            OperatingModeText = _localization.GetString($"HM02_Mode_{_machine.OperatingMode}");
        }
        else
        {
            OperatingModeText = _localization.GetString($"HM02_Mode_{OperatingMode}");
        }
    }
}
