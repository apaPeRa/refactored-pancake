using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// HS-41 Dosierer-Uebersicht: Titelzeile mit Sollgewicht und letztem Gewicht der Kontrollwaage und drei Karten (Hauptdosierer 1 und 2, Nachdosierer).
/// Das Detail-Symbol der Karte oeffnet HS-11 (mit <c>doserIndex</c>) bzw. HS-19. Funktionsleiste leer.
/// </summary>
[PageKey(PageKeys.DoserOverview)]
public sealed partial class DoserOverviewViewModel : DosingPageViewModelBase
{
    [ObservableProperty]
    private IReadOnlyList<TitleValue> _referenceValues = Array.Empty<TitleValue>();

    /// <summary>Entwurfsmodus.</summary>
    public DoserOverviewViewModel()
        : this(new Services.Dummy.DummyDoserService(), null, new Services.Dummy.DummyUserSession(), null, null, LocalizationService.Instance)
    {
    }

    public DoserOverviewViewModel(
        IDoserService service,
        INavigationService? navigation,
        IUserSession? session,
        IDialogService? dialogs,
        IMessageService? messages,
        ILocalizationService localization)
        : base(service, navigation, session, dialogs, messages, localization)
    {
        Main1 = new DoserItemViewModel(DoserId.Main1, service, Interaction, localization, OpenDetailAsync);
        Main2 = new DoserItemViewModel(DoserId.Main2, service, Interaction, localization, OpenDetailAsync);
        Post = new DoserItemViewModel(DoserId.Post, service, Interaction, localization, OpenDetailAsync);
        RefreshState();
    }

    public DoserItemViewModel Main1 { get; }

    public DoserItemViewModel Main2 { get; }

    public DoserItemViewModel Post { get; }

    protected override void RefreshState()
    {
        Main1.Refresh();
        Main2.Refresh();
        Post.Refresh();
        var weights = Service.ReferenceWeights;
        ReferenceValues = new[]
        {
            new TitleValue { Label = Localization.GetString("Dosing_TargetWeightCheck_Label"), Value = weights.TargetWeight.ToString("0", Localization.Culture), Unit = "g" },
            new TitleValue { Label = Localization.GetString("Dosing_LastWeightCheck_Label"), Value = weights.LastWeight.ToString("0", Localization.Culture), Unit = "g" },
        };
    }

    private Task OpenDetailAsync(DoserId id) => id == DoserId.Post
        ? NavigateAsync(PageKeys.PostDoser)
        : NavigateAsync(PageKeys.MainDosers, new NavigationParameters("doserIndex", (int)id));
}
