namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// Ersatz fuer Seiten, deren ViewModel noch nicht umgesetzt ist (kein Typ mit <c>[PageKey]</c>). Wird nicht per DI aufgeloest,
/// sondern vom Navigationsdienst direkt erzeugt; die View <c>PlaceholderPageView</c> zeigt Titel und Hinweis.
/// </summary>
public sealed class PlaceholderPageViewModel : PageViewModelBase
{
}
