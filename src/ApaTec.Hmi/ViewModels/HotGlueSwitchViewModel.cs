using ApaTec.Hmi.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ApaTec.Hmi.ViewModels;

/// <summary>Zustandstaste (HM-08) fuer einen Schalter des Heissleimgeraets: Ein/Aus, Ausstehend bis zur Rueckmeldung, Fehler ohne Rueckmeldung.</summary>
public sealed partial class HotGlueSwitchViewModel : ObservableObject
{
    private static readonly TimeSpan ResponseTimeout = TimeSpan.FromSeconds(5);

    private readonly HotGlueSwitch _switch;
    private readonly HotGlueEditContext _context;
    private bool _syncing;

    [ObservableProperty]
    private bool _isOn;

    [ObservableProperty]
    private bool _isPending;

    [ObservableProperty]
    private string? _errorText;

    public HotGlueSwitchViewModel(HotGlueSwitch hotGlueSwitch, HotGlueEditContext context)
    {
        _switch = hotGlueSwitch;
        _context = context;
        Refresh();
    }

    /// <summary>Uebernimmt den bestaetigten Stand des Geraets (waehrend "Ausstehend" unveraendert).</summary>
    public void Refresh()
    {
        if (IsPending)
        {
            return;
        }

        _syncing = true;
        IsOn = _context.Service.GetSwitch(_switch);
        _syncing = false;
    }

    partial void OnIsOnChanged(bool value)
    {
        if (!_syncing)
        {
            _ = ApplyAsync(value);
        }
    }

    private async Task ApplyAsync(bool requested)
    {
        IsPending = true;
        ErrorText = null;
        var confirmed = false;
        try
        {
            using var cts = new CancellationTokenSource(ResponseTimeout);
            await _context.Service.SetSwitchAsync(_switch, requested, cts.Token);
            confirmed = _context.Service.GetSwitch(_switch) == requested;
        }
        catch (Exception)
        {
            confirmed = false;
        }
        finally
        {
            IsPending = false;
        }

        if (!confirmed)
        {
            _syncing = true;
            IsOn = _context.Service.GetSwitch(_switch);
            _syncing = false;
            ErrorText = _context.Localization.GetString("HotGlue_Switch_NoResponse");
        }
    }
}
