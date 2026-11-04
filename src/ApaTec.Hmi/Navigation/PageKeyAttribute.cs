namespace ApaTec.Hmi.Navigation;

/// <summary>
/// Meldet ein Seiten-ViewModel (abgeleitet von <c>PageViewModelBase</c>, bzw. <c>PopupViewModelBase</c> bei Pop-up-Seiten)
/// unter einem Seitenschluessel an. <see cref="PageRegistry"/> findet alle Typen per Reflection; es gibt keine gemeinsame Registrierungsdatei.
/// Beispiel: <c>[PageKey(PageKeys.HotGlueNordson)] public sealed partial class HotGlueNordsonViewModel : PageViewModelBase</c>.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public sealed class PageKeyAttribute : Attribute
{
    public PageKeyAttribute(string key) => Key = key;

    public string Key { get; }
}
