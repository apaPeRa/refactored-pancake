using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// HS-05 Zufuehrung Papier: Packstoffrolle (Bremskennlinie), Klebestelle (Auswurf, zwei Zustaende) und Kupplung (Verschiebung, Anhalteposition).
/// Neun Eingabefelder mit Schluessel (HM-12), zwei Anzeigefelder (HM-11), zwei Status-LEDs (HM-09); Funktionsleiste leer (Navigation.md 3.3).
/// </summary>
[PageKey(PageKeys.FeederPaper)]
public sealed partial class FeederPaperViewModel : FeederPageViewModelBase
{
    [ObservableProperty]
    private double? _rollDiameter;

    [ObservableProperty]
    private double? _brakePressure;

    /// <summary>Grenzwertzustand von "Durchmesser Rolle": Rollenende erreicht (Fuellstand nicht ueber dem Wert "Durchmesser Rollenende").</summary>
    [ObservableProperty]
    private bool _isRollEndReached;

    [ObservableProperty]
    private LedState _spliceDetectedState;

    [ObservableProperty]
    private string _spliceDetectedText = string.Empty;

    [ObservableProperty]
    private LedState _spliceSensorState;

    [ObservableProperty]
    private string _spliceSensorText = string.Empty;

    private readonly IMessageService? _messages;

    /// <summary>Entwurfsmodus: Beispielwerte aus dem Dummy-Dienst, keine Navigation und keine Pop-ups.</summary>
    public FeederPaperViewModel()
        : this(new DummyFeederService(), null, null, null, LocalizationService.Instance)
    {
    }

    public FeederPaperViewModel(IFeederService feeder, IDialogService? dialogs, IUserSession? session, IMessageService? messages, ILocalizationService localization)
        : base(feeder, session, localization, new FeederValueEditor(dialogs, session, messages, localization))
    {
        _messages = messages;
        DiameterRollEnd = CreateField(FeederValue.PaperDiameterRollEnd, "HS05_DiameterRollEnd_Label", "Feeder_Unit_Percent", "HS05_DiameterRollEnd_Label", "HS05_DiameterRollEnd_Help");
        BrakeStandstill = CreateField(FeederValue.PaperBrakeStandstill, "HS05_BrakeStandstill_Label", "Feeder_Unit_Percent", "HS05_BrakeStandstill_Label", "HS05_BrakeStandstill_Help");
        DiameterMax = CreateField(FeederValue.PaperDiameterMax, "HS05_DiameterMax_Label", "Feeder_Unit_Percent", "HS05_DiameterMax_Label", "HS05_DiameterMax_Help");
        BrakeAtMax = CreateField(FeederValue.PaperBrakeAtMax, "HS05_BrakeAtMax_Label", "Feeder_Unit_Percent", "HS05_BrakeAtMax_Label", "HS05_BrakeAtMax_Help");
        DiameterMin = CreateField(FeederValue.PaperDiameterMin, "HS05_DiameterMin_Label", "Feeder_Unit_Percent", "HS05_DiameterMin_Label", "HS05_DiameterMin_Help");
        BrakeAtMin = CreateField(FeederValue.PaperBrakeAtMin, "HS05_BrakeAtMin_Label", "Feeder_Unit_Percent", "HS05_BrakeAtMin_Label", "HS05_BrakeAtMin_Help");
        SpliceEjectCount = CreateField(FeederValue.PaperSpliceEjectCount, "HS05_SpliceEject_Label", "Feeder_Unit_Pieces", "HS05_SpliceEject_Label", "HS05_SpliceEject_Help");
        CouplingShift = CreateField(FeederValue.PaperCouplingShift, "HS05_CouplingShift_Label", "Unit_Degree", "HS05_CouplingShift_Label", "HS05_CouplingShift_Help");
        CouplingStopPosition = CreateField(FeederValue.PaperCouplingStopPosition, "HS05_CouplingStop_Label", "Unit_Degree", "HS05_CouplingStop_Label", "HS05_CouplingStop_Help");
        RefreshAll();
    }

    public FeederValueField DiameterRollEnd { get; }

    public FeederValueField BrakeStandstill { get; }

    public FeederValueField DiameterMax { get; }

    public FeederValueField BrakeAtMax { get; }

    public FeederValueField DiameterMin { get; }

    public FeederValueField BrakeAtMin { get; }

    public FeederValueField SpliceEjectCount { get; }

    public FeederValueField CouplingShift { get; }

    public FeederValueField CouplingStopPosition { get; }

    protected override void LoadValues()
    {
        var state = Feeder.GetPaper();
        DiameterRollEnd.Value = state.DiameterRollEnd;
        BrakeStandstill.Value = state.BrakeStandstill;
        DiameterMax.Value = state.DiameterMax;
        BrakeAtMax.Value = state.BrakeAtMax;
        DiameterMin.Value = state.DiameterMin;
        BrakeAtMin.Value = state.BrakeAtMin;
        SpliceEjectCount.Value = state.SpliceEjectCount;
        CouplingShift.Value = state.CouplingShift;
        CouplingStopPosition.Value = state.CouplingStopPosition;
        RollDiameter = state.RollDiameter;
        BrakePressure = state.BrakePressure;
        var rollEnd = state.RollDiameter <= state.DiameterRollEnd;
        if (rollEnd && !IsRollEndReached)
        {
            // Meldung "Rollenende" in der Meldezeile (einmal beim Erreichen der Grenze).
            _messages?.ShowHint(Localization.GetString("HS05_RollEnd_Message"));
        }

        IsRollEndReached = rollEnd;
        SpliceDetectedState = state.SpliceDetected ? LedState.On : LedState.Off;
        SpliceSensorState = state.SpliceSensor ? LedState.On : LedState.Off;
        SpliceSensorText = Localization.GetString(state.SpliceSensor ? "HS05_SpliceSensor_On" : "HS05_SpliceSensor_Off");
        SpliceDetectedText = Localization.GetString(state.SpliceDetected ? "HS05_SpliceDetected_On" : "HS05_SpliceDetected_Off");
    }
}
