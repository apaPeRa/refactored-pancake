using ApaTec.Hmi.DesignData;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ApaTec.Hmi.ViewModels;

/// <summary>HS-09 Heissleim Druck: Gruppe Druckregelung (vier Eingaben, aktueller Druck) und Gruppe Geraetelimits (vier Eingaben); Funktionsleiste leer.</summary>
[PageKey(PageKeys.HotGluePressure)]
public sealed partial class HotGluePressureViewModel : PageViewModelBase
{
    private readonly HotGlueEditContext _context;

    [ObservableProperty]
    private bool _isOnline;

    [ObservableProperty]
    private double? _currentPressure;

    /// <summary>Annahme: aktueller Druck ausserhalb der Drucklimits = Zustand "Grenzwert verletzt" (HM-11).</summary>
    [ObservableProperty]
    private bool _isPressureOutOfLimits;

    /// <summary>Entwurfsmodus.</summary>
    public HotGluePressureViewModel()
        : this(HotGlueDesignData.CreateContext())
    {
    }

    public HotGluePressureViewModel(IHotGlueService service, IDialogService dialogs, IUserSession session, IMessageService messages, ILocalizationService localization)
        : this(new HotGlueEditContext(service, dialogs, session, messages, localization))
    {
    }

    private HotGluePressureViewModel(HotGlueEditContext context)
    {
        _context = context;
        UpperSpeed = Field(HotGlueParameter.UpperSpeed, "HS09_UpperSpeed", "HotGlue_Unit_Rpm");
        LowerSpeed = Field(HotGlueParameter.LowerSpeed, "HS09_LowerSpeed", "HotGlue_Unit_Rpm");
        UpperPressure = Field(HotGlueParameter.UpperPressure, "HS09_UpperPressure", "HotGlue_Unit_Bar");
        LowerPressure = Field(HotGlueParameter.LowerPressure, "HS09_LowerPressure", "HotGlue_Unit_Bar");
        UpperLimit = Field(HotGlueParameter.UpperPressureLimit, "HS09_UpperLimit", "HotGlue_Unit_Bar");
        LowerLimit = Field(HotGlueParameter.LowerPressureLimit, "HS09_LowerLimit", "HotGlue_Unit_Bar");
        OverDelta = Field(HotGlueParameter.OverPressureDelta, "HS09_OverDelta", "HotGlue_Unit_Bar");
        UnderDelta = Field(HotGlueParameter.UnderPressureDelta, "HS09_UnderDelta", "HotGlue_Unit_Bar");
        Refresh();
    }

    public HotGlueFieldViewModel UpperSpeed { get; }

    public HotGlueFieldViewModel LowerSpeed { get; }

    public HotGlueFieldViewModel UpperPressure { get; }

    public HotGlueFieldViewModel LowerPressure { get; }

    public HotGlueFieldViewModel UpperLimit { get; }

    public HotGlueFieldViewModel LowerLimit { get; }

    public HotGlueFieldViewModel OverDelta { get; }

    public HotGlueFieldViewModel UnderDelta { get; }

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

    private HotGlueFieldViewModel Field(HotGlueParameter parameter, string keyPrefix, string unitKey) =>
        new(parameter, _context, keyPrefix + "_Label", unitKey, keyPrefix + "_Caption");

    private void OnChanged(object? sender, EventArgs e) => Refresh();

    private void Refresh()
    {
        var s = _context.Service;
        IsOnline = s.IsConnected;
        CurrentPressure = IsOnline ? s.CurrentPressure : null;
        IsPressureOutOfLimits = CurrentPressure is { } p
            && (p > s.GetParameter(HotGlueParameter.UpperPressureLimit) || p < s.GetParameter(HotGlueParameter.LowerPressureLimit));
        foreach (var field in new[] { UpperSpeed, LowerSpeed, UpperPressure, LowerPressure, UpperLimit, LowerLimit, OverDelta, UnderDelta })
        {
            field.Refresh();
        }
    }
}
