using System.Collections.ObjectModel;
using ApaTec.Hmi.DesignData;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ApaTec.Hmi.ViewModels;

/// <summary>HS-08 Heissleim Parameter: vier globale Temperatureinstellungen und die Zonenliste (Funktionsleiste leer).</summary>
[PageKey(PageKeys.HotGlueParameters)]
public sealed partial class HotGlueParametersViewModel : PageViewModelBase
{
    private readonly HotGlueEditContext _context;

    [ObservableProperty]
    private bool _isOnline;

    /// <summary>Entwurfsmodus.</summary>
    public HotGlueParametersViewModel()
        : this(HotGlueDesignData.CreateContext())
    {
    }

    public HotGlueParametersViewModel(IHotGlueService service, IDialogService dialogs, IUserSession session, IMessageService messages, ILocalizationService localization)
        : this(new HotGlueEditContext(service, dialogs, session, messages, localization))
    {
    }

    private HotGlueParametersViewModel(HotGlueEditContext context)
    {
        _context = context;
        StandbyDelta = new HotGlueFieldViewModel(HotGlueParameter.StandbyDelta, context, "HS08_StandbyDelta_Label", "HotGlue_Unit_Celsius", "HS08_StandbyDelta_Caption");
        ReadyDelay = new HotGlueFieldViewModel(HotGlueParameter.ReadyDelay, context, "HS08_ReadyDelay_Label", "HotGlue_Unit_Second", "HS08_ReadyDelay_Caption");
        OverTemperatureDelta = new HotGlueFieldViewModel(HotGlueParameter.OverTemperatureDelta, context, "HS08_OverDelta_Label", "HotGlue_Unit_Celsius", "HS08_OverDelta_Caption");
        UnderTemperatureDelta = new HotGlueFieldViewModel(HotGlueParameter.UnderTemperatureDelta, context, "HS08_UnderDelta_Label", "HotGlue_Unit_Celsius", "HS08_UnderDelta_Caption");
        foreach (var zone in context.Service.Zones)
        {
            Zones.Add(new HotGlueZoneViewModel(zone.Id, context));
        }

        Refresh();
    }

    public HotGlueFieldViewModel StandbyDelta { get; }

    public HotGlueFieldViewModel ReadyDelay { get; }

    public HotGlueFieldViewModel OverTemperatureDelta { get; }

    public HotGlueFieldViewModel UnderTemperatureDelta { get; }

    public ObservableCollection<HotGlueZoneViewModel> Zones { get; } = new();

    public override void OnNavigatedTo(object? parameter)
    {
        _context.Service.Changed -= OnChanged;
        _context.Service.Changed += OnChanged;
        if (_context.Session is not null)
        {
            _context.Session.SessionChanged -= OnChanged;
            _context.Session.SessionChanged += OnChanged;
        }

        Refresh();
    }

    public override void OnNavigatedFrom()
    {
        _context.Service.Changed -= OnChanged;
        if (_context.Session is not null)
        {
            _context.Session.SessionChanged -= OnChanged;
        }
    }

    private void OnChanged(object? sender, EventArgs e) => Refresh();

    private void Refresh()
    {
        IsOnline = _context.Service.IsConnected;
        StandbyDelta.Refresh();
        ReadyDelay.Refresh();
        OverTemperatureDelta.Refresh();
        UnderTemperatureDelta.Refresh();
        foreach (var zone in Zones)
        {
            zone.Refresh();
        }
    }
}
