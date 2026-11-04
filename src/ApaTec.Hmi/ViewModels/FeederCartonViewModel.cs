using System.Collections.ObjectModel;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// HS-06 Zufuehrung Karton: Heissleimauftrag Ein/Aus, Maschinenwinkel (Anzeige), Leim kalt, Kompensation, Anwahl Spuelen (3Y25 bis 3Y29) und
/// die Leimspuren-Grafik mit 18 Winkelfeldern (HM-31). Funktionsleiste: "Heissleimgeraet" (HS-07, zweiter Zugang).
/// </summary>
[PageKey(PageKeys.FeederCarton)]
public sealed partial class FeederCartonViewModel : FeederPageViewModelBase
{
    /// <summary>Anzahl der Felder je Reihe der Grafik (Reihen 1 bis 4: 5, 4, 5, 4).</summary>
    private static readonly int[] RowSizes = { 5, 4, 5, 4 };

    private readonly INavigationService? _navigation;
    private readonly IMachineStatusService? _machine;
    private readonly FunctionBarItem _glueUnitItem;

    [ObservableProperty]
    private bool _glueEnabled;

    [ObservableProperty]
    private bool _isGlueAuthorized = true;

    [ObservableProperty]
    private double? _machineAngle;

    [ObservableProperty]
    private IReadOnlyList<GlueTrackField> _trackFields = Array.Empty<GlueTrackField>();

    /// <summary>Entwurfsmodus: Beispielwerte aus dem Dummy-Dienst, keine Navigation und keine Pop-ups.</summary>
    public FeederCartonViewModel()
        : this(new DummyFeederService(), null, null, null, null, new DummyMachineStatusService(), LocalizationService.Instance)
    {
    }

    public FeederCartonViewModel(
        IFeederService feeder,
        INavigationService? navigation,
        IDialogService? dialogs,
        IUserSession? session,
        IMessageService? messages,
        IMachineStatusService machine,
        ILocalizationService localization)
        : base(feeder, session, localization, new FeederValueEditor(dialogs, session, messages, localization))
    {
        _navigation = navigation;
        _machine = machine;
        CompensationOn = CreateField(FeederValue.CartonCompensationOn, "HS06_CompensationOn_Label", "Feeder_Unit_Milliseconds", "HS06_CompensationOn_Title", "HS06_Compensation_Help");
        CompensationOff = CreateField(FeederValue.CartonCompensationOff, "HS06_CompensationOff_Label", "Feeder_Unit_Milliseconds", "HS06_CompensationOff_Title", "HS06_Compensation_Help");
        GlueCold = CreateField(FeederValue.CartonGlueCold, "HS06_GlueCold_Label", "Feeder_Unit_Seconds", "HS06_GlueCold_Title", "HS06_GlueCold_Help");

        var names = Feeder.FlushValveNames;
        for (var i = 0; i < names.Count; i++)
        {
            var item = new FlushValveItem(i, names[i], false);
            item.SelectionChanged += OnFlushValveChanged;
            FlushValves.Add(item);
        }

        _glueUnitItem = new FunctionBarItem
        {
            IconKey = "Icon.Glue.Nozzle",
            Kind = FunctionBarItemKind.Action,
            TargetId = PageKeys.HotGlueNordson,
            Command = OpenGlueUnitCommand,
        };
        FunctionBarItems.Add(_glueUnitItem);
        RefreshAll();
    }

    public FeederValueField CompensationOn { get; }

    public FeederValueField CompensationOff { get; }

    public FeederValueField GlueCold { get; }

    /// <summary>Spuelventile 3Y25 bis 3Y29 in der Reihenfolge der Tasten.</summary>
    public ObservableCollection<FlushValveItem> FlushValves { get; } = new();

    public override void OnNavigatedTo(object? parameter)
    {
        if (_machine is not null)
        {
            _machine.Changed += OnMachineChanged;
        }

        base.OnNavigatedTo(parameter);
    }

    public override void OnNavigatedFrom()
    {
        if (_machine is not null)
        {
            _machine.Changed -= OnMachineChanged;
        }

        base.OnNavigatedFrom();
    }

    protected override void OnAuthorizationChanged() => IsGlueAuthorized = Editor.IsAuthorized;

    protected override void RefreshTexts()
    {
        _glueUnitItem.Label = Localization.GetString("HS06_Fn_GlueUnit_Label");
        IsGlueAuthorized = Editor.IsAuthorized;
        TrackFields = CreateTrackFields(TrackFields);
    }

    protected override void LoadValues()
    {
        var state = Feeder.GetCarton();
        GlueEnabled = state.GlueEnabled;
        CompensationOn.Value = state.CompensationOn;
        CompensationOff.Value = state.CompensationOff;
        GlueCold.Value = state.GlueCold;
        MachineAngle = _machine?.Angle;
        foreach (var valve in FlushValves)
        {
            valve.SetSilently(valve.Index < state.FlushValves.Count && state.FlushValves[valve.Index]);
        }

        for (var i = 0; i < TrackFields.Count && i < state.TrackAngles.Count; i++)
        {
            TrackFields[i].Angle = state.TrackAngles[i];
        }
    }

    /// <summary>Heissleimauftrag schalten (HM-08 meldet den neuen Zustand; ohne Berechtigung wird zurueckgesetzt).</summary>
    [RelayCommand]
    private async Task ToggleGlueAsync()
    {
        var requested = GlueEnabled;
        if (!await Editor.EnsureAuthorizedAsync())
        {
            GlueEnabled = !requested;
            return;
        }

        Feeder.SetGlueEnabled(requested);
    }

    /// <summary>Winkelfeld der Grafik antippen: Eingabe-Pop-up mit Spurname als Titel.</summary>
    [RelayCommand]
    private async Task EditTrackAsync(GlueTrackField? field)
    {
        if (field is null)
        {
            return;
        }

        var result = await Editor.RequestValueAsync(
            field.Tooltip ?? string.Empty,
            field.Angle,
            Localization.GetString("Feeder_Unit_Degree"),
            decimals: 0,
            Feeder.GetLimits(FeederValue.CartonTrackAngle),
            Localization.GetString("HS06_Track_Help"));
        field.ErrorText = result.ErrorText;
        if (result.Value is { } angle)
        {
            Feeder.SetGlueTrackAngle(FlatIndex(field.Row, field.Index), angle);
            field.Angle = angle;
        }
    }

    [RelayCommand]
    private async Task OpenGlueUnitAsync()
    {
        if (_navigation is not null)
        {
            await _navigation.NavigateToAsync(PageKeys.HotGlueNordson);
        }
    }

    private static int FlatIndex(int row, int index)
    {
        var offset = 0;
        for (var r = 1; r < row; r++)
        {
            offset += RowSizes[r - 1];
        }

        return offset + index - 1;
    }

    private IReadOnlyList<GlueTrackField> CreateTrackFields(IReadOnlyList<GlueTrackField> previous)
    {
        // Winkelfelder mit lokalisierten Tooltips (init-only) neu aufbauen; Zuordnung Anfang/Ende ist Annahme (OP-19).
        var fields = new List<GlueTrackField>();
        var angles = Feeder.GetCarton().TrackAngles;
        for (var row = 1; row <= RowSizes.Length; row++)
        {
            for (var index = 1; index <= RowSizes[row - 1]; index++)
            {
                var flat = FlatIndex(row, index);
                fields.Add(new GlueTrackField
                {
                    Row = row,
                    Index = index,
                    Tooltip = TrackName(row, index),
                    Angle = flat < angles.Count ? angles[flat] : null,
                    ErrorText = previous.FirstOrDefault(f => f.Row == row && f.Index == index)?.ErrorText,
                });
            }
        }

        return fields;
    }

    private string TrackName(int row, int index) => row switch
    {
        1 when index == 1 => Localization.GetString("HS06_Track_LongStart"),
        1 => Localization.Format("HS06_Track_TopStart", index - 1),
        2 => Localization.Format("HS06_Track_TopEnd", index),
        3 when index == 1 => Localization.GetString("HS06_Track_LongEnd"),
        3 => Localization.Format("HS06_Track_BottomStart", index - 1),
        _ => Localization.Format("HS06_Track_BottomEnd", index),
    };

    private void OnFlushValveChanged(object? sender, EventArgs e)
    {
        if (sender is FlushValveItem item)
        {
            Feeder.SetFlushValve(item.Index, item.IsSelected);
        }
    }

    private void OnMachineChanged(object? sender, EventArgs e) => MachineAngle = _machine?.Angle;
}
