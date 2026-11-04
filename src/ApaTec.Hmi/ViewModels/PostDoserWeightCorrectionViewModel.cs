using System.Collections.ObjectModel;
using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// HS-21 Gewichtskorrektur (Nachdosierer): 20 Stuetzstellen (2 x 10) Soll/Ist in g, Sollgewicht, "Dosierer Ausloesen manuell", "Gewichtsanpassung" und das Pop-up "Hinweise".
/// Eine Zeile zaehlt nur, wenn Soll und Ist groesser als 0,00 g sind; die Berechnung braucht mindestens 3 gueltige Stuetzstellen (S21-3). Funktionsleiste leer.
/// </summary>
[PageKey(PageKeys.PostDoserWeightCorrection)]
public sealed partial class PostDoserWeightCorrectionViewModel : DosingPageViewModelBase
{
    private const int PointsPerBlock = 10;

    private bool _isSyncing;

    [ObservableProperty]
    private double _targetWeight;

    [ObservableProperty]
    private int _validPointCount;

    [ObservableProperty]
    private CalculationState _calculationState;

    /// <summary>Entwurfsmodus.</summary>
    public PostDoserWeightCorrectionViewModel()
        : this(new Services.Dummy.DummyDoserService(), null, new Services.Dummy.DummyUserSession(), null, null, LocalizationService.Instance)
    {
    }

    public PostDoserWeightCorrectionViewModel(
        IDoserService service,
        INavigationService? navigation,
        IUserSession? session,
        IDialogService? dialogs,
        IMessageService? messages,
        ILocalizationService localization)
        : base(service, navigation, session, dialogs, messages, localization)
    {
        for (var i = 0; i < service.WeightCorrection.Points.Count; i++)
        {
            Points.Add(new CorrectionPoint { Block = i < PointsPerBlock ? 1 : 2 });
        }

        RefreshState();
    }

    public ObservableCollection<CorrectionPoint> Points { get; } = new();

    protected override void RefreshState()
    {
        var data = Service.WeightCorrection;
        _isSyncing = true;
        try
        {
            TargetWeight = data.TargetWeight;
            for (var i = 0; i < Points.Count && i < data.Points.Count; i++)
            {
                Points[i].Nominal = data.Points[i].Nominal;
                Points[i].Actual = data.Points[i].Actual;
            }
        }
        finally
        {
            _isSyncing = false;
        }

        ValidPointCount = Points.Count(p => p.Nominal > 0 && p.Actual > 0);
    }

    [RelayCommand]
    private async Task EditTargetWeightAsync()
    {
        var value = await Interaction.RequestValueAsync(
            DoserField.CorrectionTargetWeight, Localization.GetString("Dosing_Field_CorrectionTargetWeight_Title"), TargetWeight, "Dosing_Field_CorrectionTargetWeight_Help");
        if (value is { } v)
        {
            TargetWeight = v;
            await PushAsync();
        }
    }

    [RelayCommand]
    private Task EditNominalAsync(CorrectionPoint? point) => EditPointAsync(point, nominal: true);

    [RelayCommand]
    private Task EditActualAsync(CorrectionPoint? point) => EditPointAsync(point, nominal: false);

    private async Task EditPointAsync(CorrectionPoint? point, bool nominal)
    {
        if (point is null)
        {
            return;
        }

        var column = Localization.GetString(nominal ? "HM22_Nominal_Header" : "HM22_Actual_Header");
        var title = $"{Localization.GetString("Dosing_Field_CorrectionPointValue_Title")} {Points.IndexOf(point) + 1} – {column}";
        var value = await Interaction.RequestValueAsync(DoserField.CorrectionPointValue, title, nominal ? point.Nominal : point.Actual, "Dosing_Field_CorrectionPointValue_Help");
        if (value is not { } v)
        {
            return;
        }

        if (nominal)
        {
            point.Nominal = v;
        }
        else
        {
            point.Actual = v;
        }

        CalculationState = CalculationState.None;
        await PushAsync();
    }

    /// <summary>"Dosierer Ausloesen manuell": dosiert eine Probe mit dem Sollgewicht.</summary>
    [RelayCommand]
    private async Task TriggerAsync()
    {
        // Im aktuellen Betriebszustand nicht zulaessig: Grund in der Meldezeile (A-28), keine Aktion.
        if (!Service.GetDoser(DoserId.Post).ActionsAllowed)
        {
            Interaction.ShowBlockedHint();
            return;
        }

        await Service.TriggerWeightSampleAsync();
    }

    /// <summary>"Gewichtsanpassung": berechnet die Korrekturkennlinie; unter 3 gueltigen Stuetzstellen oder bei ungueltigen Zeilen nicht.</summary>
    [RelayCommand]
    private async Task AdjustAsync()
    {
        await PushAsync();
        var result = await Service.AdjustWeightAsync();
        CalculationState = result.State switch
        {
            DoserAdjustState.Calculated => CalculationState.Calculated,
            DoserAdjustState.TooFewPoints => CalculationState.TooFewPoints,
            _ => CalculationState.Invalid,
        };
    }

    /// <summary>Taste "Hinweise": Pop-up mit den vier Schritten und vier Hinweisen.</summary>
    [RelayCommand]
    private async Task ShowHintsAsync()
    {
        if (Dialogs is not null)
        {
            await Dialogs.ShowAsync<object>(PostDoserHintsViewModel.DialogKey);
        }
    }

    private async Task PushAsync()
    {
        if (_isSyncing)
        {
            return;
        }

        ValidPointCount = Points.Count(p => p.Nominal > 0 && p.Actual > 0);
        await Service.SetWeightCorrectionAsync(new DoserWeightCorrectionData(TargetWeight, Points.Select(p => new DoserWeightPoint(p.Nominal, p.Actual)).ToList()));
    }
}
