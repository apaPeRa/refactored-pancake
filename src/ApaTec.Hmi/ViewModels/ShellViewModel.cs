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
/// Betriebsart, Meldung und Kennzahlen tragen vorerst die Entwurfswerte (<see cref="ShellDesignData"/>) und werden spaeter an
/// <c>IMachineStatusService</c>/<c>IMessageService</c> gebunden (Konzept.md 6.6).
/// </summary>
public sealed partial class ShellViewModel : ObservableObject
{
    private readonly INavigationService _navigation;
    private readonly IUserSession _session;
    private readonly IClockService _clock;
    private readonly IDialogService _dialogs;

    // ---- Inhalt und Pop-up ----
    [ObservableProperty]
    private PageViewModelBase? _currentPage;

    [ObservableProperty]
    private PopupViewModelBase? _currentPopup;

    [ObservableProperty]
    private bool _isModalOpen;

    // ---- Rahmenvarianten (Konzept.md 2) ----
    /// <summary>false nur im Vollbild (HS-24): Seitenleiste, Brotkruemel, Kennzahlen und Funktionsleiste ausgeblendet.</summary>
    [ObservableProperty]
    private bool _showFrame = true;

    [ObservableProperty]
    private bool _showMessageLine = true;

    // ---- HM-01 Seitenleiste ----
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
    [ObservableProperty]
    private ObservableCollection<FunctionBarItem>? _functionBarItems;

    public ShellViewModel(INavigationService navigation, IUserSession session, IClockService clock, IDialogService dialogs)
    {
        _navigation = navigation;
        _session = session;
        _clock = clock;
        _dialogs = dialogs;

        _navigation.Navigated += (_, _) => RefreshFromNavigation();
        _navigation.PopupStackChanged += (_, _) => RefreshPopup();
        _session.SessionChanged += (_, _) => RefreshUser();
        _clock.Tick += (_, _) => Now = _clock.Now;

        Now = _clock.Now;
        RefreshUser();
        RefreshFromNavigation();
        RefreshPopup();
    }

    /// <summary>Entwurfsmodus: leerer Rahmen mit Beispielwerten, ohne Dienste.</summary>
    public ShellViewModel()
    {
        _navigation = null!;
        _session = null!;
        _clock = null!;
        _dialogs = null!;
        UserInitials = "MM";
        UserName = "Max Mustermann";
        UserRoleText = nameof(UserRole.Technician);
        Now = new DateTime(2026, 1, 6, 9, 15, 0);
    }

    // ---- Befehle (Seitenleiste, Brotkruemel, Meldezeile, Kennzahl) ----
    [RelayCommand]
    private void Home() => _navigation.GoHome();

    [RelayCommand]
    private void Settings() => _navigation.GoToSettings();

    [RelayCommand]
    private async Task MessagesAsync() => await _navigation.OpenMessagesAsync();

    [RelayCommand]
    private void Back() => _navigation.GoBack();

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
        UserRoleText = user.Role.ToString();
    }
}
