namespace ApaTec.Hmi.ViewModels;

/// <summary>Ersatz fuer Pop-ups, deren ViewModel noch nicht umgesetzt ist (unbekannter Dialogschluessel bzw. Pop-up-Seite ohne ViewModel).</summary>
public sealed class PlaceholderPopupViewModel : PopupViewModelBase
{
    public PlaceholderPopupViewModel(string key) => Title = key;
}
