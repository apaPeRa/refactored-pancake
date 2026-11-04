using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Navigation;

namespace ApaTec.Hmi.Models;

/// <summary>
/// Parametervertrag der Seiten HS-35 bis HS-39 fuer <c>IDialogService.ShowAsync</c> (Pop-up-Seiten kennen die Schluessel).
/// Bestaetigung: Ergebnis bool. Eingabe: Ergebnis double bzw. string. Filter: Ergebnis <c>IReadOnlyList&lt;FilterField&gt;</c>.
/// Datei: Modus "select" liefert den Dateinamen (string), Modus "result" zeigt Erfolg oder Fehler (kein Ergebnis).
/// </summary>
public static class SystemDialogParameters
{
    public const string Title = "title";
    public const string Message = "message";
    public const string ConfirmText = "confirmText";
    public const string CancelText = "cancelText";
    public const string Value = "value";
    public const string Unit = "unit";
    public const string Minimum = "minimum";
    public const string Maximum = "maximum";
    public const string Decimals = "decimals";
    public const string InputKind = "inputKind";
    public const string FilterFields = "filterFields";
    public const string FileMode = "fileMode";
    public const string FileName = "fileName";
    public const string Success = "success";

    public const string FileModeSelect = "select";
    public const string FileModeResult = "result";

    public static NavigationParameters Confirmation(string title, string message, string confirmText, string cancelText) =>
        new NavigationParameters(Title, title).With(Message, message).With(ConfirmText, confirmText).With(CancelText, cancelText);

    public static NavigationParameters NumberInput(string title, double value, string unit, double minimum, double maximum, int decimals) =>
        new NavigationParameters(Title, title).With(InputKind, Controls.InputKind.Number).With(Value, value).With(Unit, unit)
            .With(Minimum, minimum).With(Maximum, maximum).With(Decimals, decimals);

    public static NavigationParameters TextInput(string title, string value) =>
        new NavigationParameters(Title, title).With(InputKind, Controls.InputKind.Text).With(Value, value);

    public static NavigationParameters Filter(string title, IReadOnlyList<FilterField> fields) =>
        new NavigationParameters(Title, title).With(InputKind, Controls.InputKind.Filter).With(FilterFields, fields);

    public static NavigationParameters FileSelect(string title, string suggestedFileName) =>
        new NavigationParameters(Title, title).With(FileMode, FileModeSelect).With(FileName, suggestedFileName);

    public static NavigationParameters FileResult(string title, bool success, string message) =>
        new NavigationParameters(Title, title).With(FileMode, FileModeResult).With(Success, success).With(Message, message);
}
