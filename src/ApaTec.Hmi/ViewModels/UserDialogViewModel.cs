using System.Collections.ObjectModel;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// Benutzer-Pop-up (<see cref="DialogKeys.User"/>, Seitenleiste und berechtigungspflichtige Eingaben, Navigation.md 4.1): zeigt Benutzer und aktuelle Rolle, erlaubt Anmelden mit einer Rolle
/// (<see cref="IUserSession.SignIn"/>, Dummy ohne Kennwort, A-41) und Abmelden (<see cref="IUserSession.SignOut"/>). Optionaler Parameter <c>requiredRole</c> (<see cref="UserRole"/>) waehlt die geforderte Rolle vor.
/// Ergebnis: <see cref="UserInfo"/> nach Anmelden oder Abmelden; bei Abbrechen kein Ergebnis.
/// </summary>
[DialogKey(DialogKeys.User)]
public sealed partial class UserDialogViewModel : PopupViewModelBase
{
    private readonly IUserSession _session;
    private readonly ILocalizationService _loc;

    [ObservableProperty]
    private string _initials = string.Empty;

    [ObservableProperty]
    private string _userName = string.Empty;

    [ObservableProperty]
    private string _currentRoleText = string.Empty;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HasRequiredRole))]
    private string? _requiredRoleText;

    [ObservableProperty]
    private DialogChoiceItem? _selected;

    public UserDialogViewModel()
        : this(new DummyUserSession(), LocalizationService.Instance)
    {
    }

    public UserDialogViewModel(IUserSession session, ILocalizationService localization)
    {
        _session = session;
        _loc = localization;
        Title = _loc.GetString("Dialog_User_Title");
        Load(null);
    }

    public ObservableCollection<DialogChoiceItem> Items { get; } = new();

    /// <summary>true, wenn das Pop-up wegen einer fehlenden Rolle geoeffnet wurde (Hinweis "Berechtigung erforderlich").</summary>
    public bool HasRequiredRole => RequiredRoleText is not null;

    public override void OnOpened(object? parameter)
    {
        var required = new DialogParameterReader(parameter).GetEnum<UserRole>("requiredRole", "role");
        Load(required);
    }

    protected override object? GetResult() => _session.Current;

    private bool CanSignIn() => Selected is not null;

    partial void OnSelectedChanged(DialogChoiceItem? value) => SignInCommand.NotifyCanExecuteChanged();

    [RelayCommand]
    private void Choose(DialogChoiceItem? item)
    {
        if (item is null)
        {
            return;
        }

        foreach (var other in Items)
        {
            other.IsSelected = ReferenceEquals(other, item);
        }

        Selected = item;
    }

    [RelayCommand(CanExecute = nameof(CanSignIn))]
    private void SignIn()
    {
        if (Selected?.Value is UserRole role)
        {
            _session.SignIn(role);
            Close(true, _session.Current);
        }
    }

    [RelayCommand]
    private void SignOut()
    {
        _session.SignOut();
        Close(true, _session.Current);
    }

    private void Load(UserRole? required)
    {
        var user = _session.Current;
        Initials = user.Initials;
        UserName = user.Name;
        CurrentRoleText = _loc.GetString("HM01_Role_" + user.Role);
        RequiredRoleText = required is { } r ? _loc.Format("Msg_PermissionRequired", _loc.GetString("Role_" + r)) : null;

        Items.Clear();
        Selected = null;
        foreach (var role in Enum.GetValues<UserRole>())
        {
            var item = new DialogChoiceItem(_loc.GetString("Role_" + role), role, role == (required ?? user.Role));
            Items.Add(item);
            if (item.IsSelected)
            {
                Selected = item;
            }
        }
    }
}
