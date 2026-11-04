using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// Datei-/Ergebnis-Pop-up (HM-14 Art FileResult, <see cref="DialogKeys.FileResult"/>, HS-36 und HS-37). Parameter: <see cref="SystemDialogParameters.FileSelect"/>
/// (Modus "select": Dateiname eingeben, Ergebnis <c>string</c>) oder <see cref="SystemDialogParameters.FileResult"/> (Modus "result": Erfolg bzw. Fehler mit Meldung, Taste "Schliessen",
/// kein Ergebnis). Der Vorgang selbst (Fortschritt, <see cref="IsBusy"/>) liegt beim aufrufenden ViewModel; Dateiformat und Ort sind offen (OP-49).
/// </summary>
[DialogKey(DialogKeys.FileResult)]
public sealed partial class FileResultDialogViewModel : PopupViewModelBase
{
    [ObservableProperty]
    private bool _isSelectMode = true;

    [ObservableProperty]
    private string _fileName = string.Empty;

    [ObservableProperty]
    private string? _message;

    [ObservableProperty]
    private ResultKind _resultKind = ResultKind.None;

    [ObservableProperty]
    private bool _isBusy;

    public FileResultDialogViewModel()
    {
        Title = "Datei";
        FileName = "Export.csv";
    }

    public override void OnOpened(object? parameter)
    {
        var reader = new DialogParameterReader(parameter);
        Title = reader.GetString(SystemDialogParameters.Title) ?? Title;
        var mode = reader.GetString(SystemDialogParameters.FileMode);
        IsSelectMode = !string.Equals(mode, SystemDialogParameters.FileModeResult, StringComparison.OrdinalIgnoreCase);
        if (IsSelectMode)
        {
            FileName = reader.GetString(SystemDialogParameters.FileName) ?? string.Empty;
            Message = null;
            ResultKind = ResultKind.None;
        }
        else
        {
            Message = reader.Find(SystemDialogParameters.Message) as string ?? string.Empty;
            ResultKind = reader.Find(SystemDialogParameters.Success) is true ? ResultKind.Success : ResultKind.Error;
        }
    }

    protected override object? GetResult() => IsSelectMode ? FileName.Trim() : null;
}
