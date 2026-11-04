using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;

namespace ApaTec.Hmi.ViewModels;

/// <summary>HS-12 Motorparameter (Hauptdosierer): drei Karten Verschluss Zu, Verschluss Auf, Schnecke; Blaettern HD 1 und HD 2 in der Funktionsleiste (S12-2).</summary>
[PageKey(PageKeys.MainDoserMotor)]
public sealed class MainDoserMotorViewModel : DoserMotorPageViewModelBase
{
    /// <summary>Entwurfsmodus.</summary>
    public MainDoserMotorViewModel()
        : this(new Services.Dummy.DummyDoserService(), null, new Services.Dummy.DummyUserSession(), null, null, LocalizationService.Instance)
    {
    }

    public MainDoserMotorViewModel(
        IDoserService service,
        INavigationService? navigation,
        IUserSession? session,
        IDialogService? dialogs,
        IMessageService? messages,
        ILocalizationService localization)
        : base(service, navigation, session, dialogs, messages, localization)
    {
        AddPagerItems();
        RefreshState();
    }

    protected override bool UsesPaging => true;

    protected override DoserId CurrentId => DoserIndex == 2 ? DoserId.Main2 : DoserId.Main1;

    /// <summary>Titelzeile "Hauptdosierer 1" bzw. "Hauptdosierer 2".</summary>
    public string DoserTitle => Localization.Format("Dosing_MainDoser_Title", DoserIndex);

    public override string? ObjectSuffix => DoserName;

    protected override void RefreshState()
    {
        base.RefreshState();
        OnPropertyChanged(nameof(DoserTitle));
    }
}
