using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// HS-11 Hauptdosierer 1 und 2: eine Seite fuer beide Dosierer (Parameter <c>doserIndex</c>). Funktionsleiste: Blaettertasten "«" "»" (Positionsanzeige "1 von 2" in der Titelzeile)
/// und "Motorparameter" (HS-12); "Einstellung Regulierung" (HS-23) liegt im Inhaltsbereich (S11-2).
/// </summary>
[PageKey(PageKeys.MainDosers)]
public sealed partial class MainDosersViewModel : DosingPageViewModelBase
{
    private readonly DoserItemViewModel _main1;
    private readonly DoserItemViewModel _main2;

    [ObservableProperty]
    private DoserItemViewModel _doser;

    /// <summary>Entwurfsmodus.</summary>
    public MainDosersViewModel()
        : this(new Services.Dummy.DummyDoserService(), null, new Services.Dummy.DummyUserSession(), null, null, LocalizationService.Instance)
    {
    }

    public MainDosersViewModel(
        IDoserService service,
        INavigationService? navigation,
        IUserSession? session,
        IDialogService? dialogs,
        IMessageService? messages,
        ILocalizationService localization)
        : base(service, navigation, session, dialogs, messages, localization)
    {
        _main1 = new DoserItemViewModel(DoserId.Main1, service, Interaction, localization);
        _main2 = new DoserItemViewModel(DoserId.Main2, service, Interaction, localization);
        _doser = _main1;
        AddPagerItems();
        FunctionBarItems.Add(CreateBarItem("Dosing_FunctionBar_Motor", "Icon.Motor.Screw", OpenMotorCommand, targetId: PageKeys.MainDoserMotor));
    }

    protected override bool UsesPaging => true;

    public override string? ObjectSuffix => DoserIndex.ToString();

    protected override void RefreshState()
    {
        _main1.Refresh();
        _main2.Refresh();
        Doser = DoserIndex == 2 ? _main2 : _main1;
        OnPropertyChanged(nameof(PositionValues));
    }

    [RelayCommand]
    private Task OpenMotorAsync() => NavigateAsync(PageKeys.MainDoserMotor, new NavigationParameters("doserIndex", DoserIndex));

    [RelayCommand]
    private Task OpenRegulationAsync() => NavigateAsync(PageKeys.Regulation);
}
