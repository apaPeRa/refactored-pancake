using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// Bestaetigungs-Pop-up (HM-14 Art Confirmation, <see cref="DialogKeys.Confirmation"/>, Fokus auf "Abbrechen"). Parameter: <see cref="IConfirmationRequest"/> oder
/// <see cref="NavigationParameters"/> mit title, message/text, confirmText/acceptLabel, cancelText/cancelLabel (beliebige Schreibweise). Ergebnis: <c>true</c> bei "Ja".
/// </summary>
[DialogKey(DialogKeys.Confirmation)]
public sealed partial class ConfirmationDialogViewModel : PopupViewModelBase
{
    [ObservableProperty]
    private string _message = string.Empty;

    [ObservableProperty]
    private string? _confirmText;

    [ObservableProperty]
    private string? _cancelText;

    public ConfirmationDialogViewModel()
    {
        Title = "Bestätigung";
        Message = "Soll die Aktion ausgeführt werden?";
    }

    public override void OnOpened(object? parameter)
    {
        if (parameter is IConfirmationRequest request)
        {
            Title = request.Title;
            Message = request.Message;
            ConfirmText = request.AcceptLabel;
            CancelText = request.CancelLabel;
            return;
        }

        var reader = new DialogParameterReader(parameter);
        Title = reader.GetString("title") ?? Title;
        Message = reader.GetString("message", "text") ?? string.Empty;
        ConfirmText = reader.GetString("confirmText", "acceptLabel", "acceptText");
        CancelText = reader.GetString("cancelText", "cancelLabel");
    }

    protected override object? GetResult() => true;
}
