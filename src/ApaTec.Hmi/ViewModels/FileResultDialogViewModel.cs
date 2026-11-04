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
    [NotifyCanExecuteChangedFor(nameof(AcceptCommand))]
    private bool _isBusy;

    private FileOperationRequest? _operation;

    public FileResultDialogViewModel()
    {
        Title = LocalizationService.Instance.GetString("Dialog_Design_File_Title");
        FileName = LocalizationService.Instance.GetString("Dialog_Design_File_Name");
    }

    public override void OnOpened(object? parameter)
    {
        var reader = new DialogParameterReader(parameter);
        Title = reader.GetString(SystemDialogParameters.Title) ?? Title;
        var mode = reader.GetString(SystemDialogParameters.FileMode);
        _operation = reader.Find(SystemDialogParameters.FileOperation) as FileOperationRequest;
        IsSelectMode = !string.Equals(mode, SystemDialogParameters.FileModeResult, StringComparison.OrdinalIgnoreCase);
        if (IsSelectMode)
        {
            FileName = reader.GetString(SystemDialogParameters.FileName) ?? string.Empty;
            Message = null;
            ResultKind = ResultKind.None;
            if (_operation is { } operation && reader.Find(SystemDialogParameters.FileAutoStart) is true)
            {
                // Vorgang laeuft sofort: Zustand "Laeuft" ohne Auswahlfeld, danach Ergebnis im selben Pop-up.
                IsSelectMode = false;
                _ = RunAsync(operation);
            }
        }
        else
        {
            Message = reader.Find(SystemDialogParameters.Message) as string ?? string.Empty;
            ResultKind = reader.Find(SystemDialogParameters.Success) is true ? ResultKind.Success : ResultKind.Error;
        }
    }

    protected override bool CanAccept() => !IsBusy;

    // Auswahl mit Vorgang: Laeuft (IsBusy) und danach Ergebnis im selben Pop-up; "Schliessen" beendet es.
    protected override bool HandleAccept()
    {
        if (!IsSelectMode || _operation is not { } operation)
        {
            return false;
        }

        _ = RunAsync(operation);
        return true;
    }

    private async Task RunAsync(FileOperationRequest operation)
    {
        var file = FileName.Trim();
        IsBusy = true;
        operation.Busy?.Invoke(true);
        FileOperationResult result;
        try
        {
            result = await operation.Run(file);
        }
        catch (Exception ex)
        {
            result = new FileOperationResult(false, 0, file, ex.Message);
        }
        finally
        {
            operation.Busy?.Invoke(false);
            IsBusy = false;
        }

        Message = operation.Format(result);
        ResultKind = result.Success ? ResultKind.Success : ResultKind.Error;
        IsSelectMode = false;
    }

    protected override object? GetResult() => _operation is not null || IsSelectMode ? FileName.Trim() : null;
}
