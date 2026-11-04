using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// Eingabefeld (HM-12) fuer einen Einstellwert des Heissleimgeraets. Antippen: Berechtigung pruefen, Eingabe-Pop-up (HM-13) mit vorbelegtem Wert und Grenzen,
/// danach Schreiben ans Geraet. Texte (Titel, Einheit, Hilfetext) kommen aus den <c>.resx</c>-Schluesseln.
/// </summary>
public sealed partial class HotGlueFieldViewModel : ObservableObject
{
    private readonly HotGlueParameter _parameter;
    private readonly HotGlueEditContext _context;
    private readonly string _titleKey;
    private readonly string _unitKey;
    private readonly string? _helpKey;

    [ObservableProperty]
    private double? _value;

    [ObservableProperty]
    private bool _isAuthorized;

    [ObservableProperty]
    private bool _isEditing;

    [ObservableProperty]
    private bool _isPendingWrite;

    [ObservableProperty]
    private string? _errorText;

    public HotGlueFieldViewModel(HotGlueParameter parameter, HotGlueEditContext context, string titleKey, string unitKey, string? helpKey = null)
    {
        _parameter = parameter;
        _context = context;
        _titleKey = titleKey;
        _unitKey = unitKey;
        _helpKey = helpKey;
        Refresh();
    }

    public int Decimals => _context.Service.GetLimits(_parameter).Decimals;

    public void Refresh()
    {
        Value = _context.Service.IsConnected ? _context.Service.GetParameter(_parameter) : null;
        IsAuthorized = _context.IsAuthorized;
    }

    [RelayCommand]
    private async Task EditAsync()
    {
        if (_context.Dialogs is null || !_context.Service.IsConnected || !await _context.EnsureAuthorizedAsync())
        {
            return;
        }

        ErrorText = null;
        IsEditing = true;
        try
        {
            var limits = _context.Service.GetLimits(_parameter);
            var loc = _context.Localization;
            var request = new HotGlueInputRequest(
                loc.GetString(_titleKey), Value, loc.GetString(_unitKey), limits.Minimum, limits.Maximum, limits.Decimals,
                HelpText: _helpKey is null ? null : loc.GetString(_helpKey));
            var result = await _context.Dialogs.ShowAsync<double>(DialogKeys.Input, request);
            if (!result.Accepted)
            {
                return;
            }

            if (result.Value < limits.Minimum || result.Value > limits.Maximum)
            {
                ErrorText = loc.Format("HotGlue_Error_Range", limits.Minimum, limits.Maximum);
                return;
            }

            IsPendingWrite = true;
            await _context.Service.SetParameterAsync(_parameter, result.Value);
            Value = _context.Service.GetParameter(_parameter);
        }
        catch (Exception)
        {
            ErrorText = _context.Localization.GetString("HotGlue_Error_Write");
        }
        finally
        {
            IsPendingWrite = false;
            IsEditing = false;
        }
    }
}
