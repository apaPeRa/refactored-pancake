using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;

namespace ApaTec.Hmi.ViewModels;

/// <summary>HS-20 Motorparameter (Nachdosierer): wie HS-12, ohne Titelzeile und ohne Blaettertasten; Funktionsleiste leer.</summary>
[PageKey(PageKeys.PostDoserMotor)]
public sealed class PostDoserMotorViewModel : DoserMotorPageViewModelBase
{
    /// <summary>Entwurfsmodus.</summary>
    public PostDoserMotorViewModel()
        : this(new Services.Dummy.DummyDoserService(), null, new Services.Dummy.DummyUserSession(), null, null, LocalizationService.Instance)
    {
    }

    public PostDoserMotorViewModel(
        IDoserService service,
        INavigationService? navigation,
        IUserSession? session,
        IDialogService? dialogs,
        IMessageService? messages,
        ILocalizationService localization)
        : base(service, navigation, session, dialogs, messages, localization)
    {
        RefreshState();
    }

    protected override DoserId CurrentId => DoserId.Post;

    public override string? ObjectSuffix => DoserName;
}
