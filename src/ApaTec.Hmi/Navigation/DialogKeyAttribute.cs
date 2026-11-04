namespace ApaTec.Hmi.Navigation;

/// <summary>
/// Meldet ein Pop-up-ViewModel (abgeleitet von <c>PopupViewModelBase</c>) fuer <c>IDialogService.ShowAsync</c> unter einem Dialogschluessel an
/// (Eingabe, Suche, Benutzer, Sprache, Rezept, Bestaetigung, Zeitplan-Eintrag, Filter, Datei/Ergebnis; siehe <see cref="DialogKeys"/>).
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public sealed class DialogKeyAttribute : Attribute
{
    public DialogKeyAttribute(string key) => Key = key;

    public string Key { get; }
}
