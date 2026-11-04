using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Controls;

/// <summary>Seitenleiste (HM-01): Benutzerkennung, Symboltasten Home, Einstellungen, Meldungen und Zurueck. Nur Dependency Properties, Darstellung in HM01_Sidebar.Styles.xaml.</summary>
public sealed class HM01_Sidebar : Control
{
    public static readonly DependencyProperty InitialsProperty =
        DependencyProperty.Register(nameof(Initials), typeof(string), typeof(HM01_Sidebar), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty UserNameProperty =
        DependencyProperty.Register(nameof(UserName), typeof(string), typeof(HM01_Sidebar), new PropertyMetadata(string.Empty));

    /// <summary>Rollenname als Text (aus den Ressourcen).</summary>
    public static readonly DependencyProperty UserRoleProperty =
        DependencyProperty.Register(nameof(UserRole), typeof(string), typeof(HM01_Sidebar), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty IsLoggedInProperty =
        DependencyProperty.Register(nameof(IsLoggedIn), typeof(bool), typeof(HM01_Sidebar), new PropertyMetadata(false));

    /// <summary>Die drei oberen Eintraege (Home, Einstellungen, Meldungen); Zurueck steht fest unten im Template.</summary>
    public static readonly DependencyProperty ItemsProperty =
        DependencyProperty.Register(nameof(Items), typeof(IReadOnlyList<SidebarItem>), typeof(HM01_Sidebar), new PropertyMetadata(null));

    public static readonly DependencyProperty CurrentItemIdProperty =
        DependencyProperty.Register(nameof(CurrentItemId), typeof(string), typeof(HM01_Sidebar), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty UnreadMessageCountProperty =
        DependencyProperty.Register(nameof(UnreadMessageCount), typeof(int), typeof(HM01_Sidebar), new PropertyMetadata(0));

    public static readonly DependencyProperty CanGoBackProperty =
        DependencyProperty.Register(nameof(CanGoBack), typeof(bool), typeof(HM01_Sidebar), new PropertyMetadata(false));

    /// <summary>Parameter: Kennung des Eintrags (<see cref="SidebarItem.Id"/>).</summary>
    public static readonly DependencyProperty NavigateCommandProperty =
        DependencyProperty.Register(nameof(NavigateCommand), typeof(ICommand), typeof(HM01_Sidebar), new PropertyMetadata(null));

    public static readonly DependencyProperty BackCommandProperty =
        DependencyProperty.Register(nameof(BackCommand), typeof(ICommand), typeof(HM01_Sidebar), new PropertyMetadata(null));

    public static readonly DependencyProperty UserCommandProperty =
        DependencyProperty.Register(nameof(UserCommand), typeof(ICommand), typeof(HM01_Sidebar), new PropertyMetadata(null));

    static HM01_Sidebar()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM01_Sidebar), new FrameworkPropertyMetadata(typeof(HM01_Sidebar)));
    }

    public string Initials
    {
        get => (string)GetValue(InitialsProperty);
        set => SetValue(InitialsProperty, value);
    }

    public string UserName
    {
        get => (string)GetValue(UserNameProperty);
        set => SetValue(UserNameProperty, value);
    }

    public string UserRole
    {
        get => (string)GetValue(UserRoleProperty);
        set => SetValue(UserRoleProperty, value);
    }

    public bool IsLoggedIn
    {
        get => (bool)GetValue(IsLoggedInProperty);
        set => SetValue(IsLoggedInProperty, value);
    }

    public IReadOnlyList<SidebarItem>? Items
    {
        get => (IReadOnlyList<SidebarItem>?)GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }

    public string CurrentItemId
    {
        get => (string)GetValue(CurrentItemIdProperty);
        set => SetValue(CurrentItemIdProperty, value);
    }

    public int UnreadMessageCount
    {
        get => (int)GetValue(UnreadMessageCountProperty);
        set => SetValue(UnreadMessageCountProperty, value);
    }

    public bool CanGoBack
    {
        get => (bool)GetValue(CanGoBackProperty);
        set => SetValue(CanGoBackProperty, value);
    }

    public ICommand? NavigateCommand
    {
        get => (ICommand?)GetValue(NavigateCommandProperty);
        set => SetValue(NavigateCommandProperty, value);
    }

    public ICommand? BackCommand
    {
        get => (ICommand?)GetValue(BackCommandProperty);
        set => SetValue(BackCommandProperty, value);
    }

    public ICommand? UserCommand
    {
        get => (ICommand?)GetValue(UserCommandProperty);
        set => SetValue(UserCommandProperty, value);
    }
}
