using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// HS-19 Nachdosierer: Aufbau wie HS-11 mit "Max. Nachgabe" und "Aktuelle Nachgabe" und dem nIO-Hinweis; keine Blaettertasten.
/// Funktionsleiste: Gewichtskorrektur (HS-21), Motorparameter (HS-20), Regulierung (HS-23).
/// </summary>
[PageKey(PageKeys.PostDoser)]
public sealed partial class PostDoserViewModel : DosingPageViewModelBase
{
    /// <summary>Entwurfsmodus.</summary>
    public PostDoserViewModel()
        : this(new Services.Dummy.DummyDoserService(), null, new Services.Dummy.DummyUserSession(), null, null, LocalizationService.Instance)
    {
    }

    public PostDoserViewModel(
        IDoserService service,
        INavigationService? navigation,
        IUserSession? session,
        IDialogService? dialogs,
        IMessageService? messages,
        ILocalizationService localization)
        : base(service, navigation, session, dialogs, messages, localization)
    {
        Doser = new DoserItemViewModel(DoserId.Post, service, Interaction, localization);
        FunctionBarItems.Add(CreateBarItem("Dosing_FunctionBar_WeightCorrection", "Icon.Weight.Scale", OpenWeightCorrectionCommand, targetId: PageKeys.PostDoserWeightCorrection));
        FunctionBarItems.Add(CreateBarItem("Dosing_FunctionBar_Motor", "Icon.Motor.Screw", OpenMotorCommand, targetId: PageKeys.PostDoserMotor));
        FunctionBarItems.Add(CreateBarItem("Dosing_FunctionBar_Regulation", "Icon.Settings", OpenRegulationCommand, targetId: PageKeys.Regulation));
    }

    public DoserItemViewModel Doser { get; }

    protected override void RefreshState() => Doser.Refresh();

    [RelayCommand]
    private Task OpenWeightCorrectionAsync() => NavigateAsync(PageKeys.PostDoserWeightCorrection);

    [RelayCommand]
    private Task OpenMotorAsync() => NavigateAsync(PageKeys.PostDoserMotor);

    [RelayCommand]
    private Task OpenRegulationAsync() => NavigateAsync(PageKeys.Regulation);
}
