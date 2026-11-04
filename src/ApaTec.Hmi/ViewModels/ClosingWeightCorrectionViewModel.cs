using System.Collections.ObjectModel;
using System.ComponentModel;
using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// HS-18 Gewichtskorrektur (Schliessmaschine): Stuetzstellen (2 x 10 Soll/Ist-Paare), Sollgewicht, "Dosierer Ausloesen manuell" und "Gewichtsanpassung" (HM-22),
/// daneben der Bedienablauf mit vier Hinweisen. Gleicher Aufbau wie HS-21. Funktionsleiste leer (A-37). Die Reihenfolge der Schritte ist nur Anleitung (S18-2).
/// </summary>
[PageKey(PageKeys.ClosingWeightCorrection)]
public sealed partial class ClosingWeightCorrectionViewModel : PageViewModelBase
{
    /// <summary>Mindestzahl gueltiger Stuetzstellen (S18-4).</summary>
    public const int MinimumPoints = 3;

    private readonly IClosingMachineService _service;
    private readonly IMessageService? _messages;
    private readonly ILocalizationService _localization;
    private bool _isLoading;

    [ObservableProperty]
    private double _targetWeight;

    [ObservableProperty]
    private int _validPointCount;

    [ObservableProperty]
    private CalculationState _calculationState = CalculationState.None;

    /// <summary>Entwurfsmodus: Dummy-Dienst.</summary>
    public ClosingWeightCorrectionViewModel()
        : this(new DummyClosingMachineService(), null, LocalizationService.Instance)
    {
    }

    public ClosingWeightCorrectionViewModel(IClosingMachineService service, IMessageService? messages, ILocalizationService localization)
    {
        _service = service;
        _messages = messages;
        _localization = localization;
        Load();
    }

    /// <summary>20 Stuetzstellen; <c>Block</c> 1 (Zeilen 1 bis 10) und 2 (Zeilen 11 bis 20).</summary>
    public ObservableCollection<CorrectionPoint> Points { get; } = new();

    partial void OnTargetWeightChanged(double value)
    {
        if (!_isLoading)
        {
            _ = PersistAsync();
        }
    }

    public override void OnNavigatedTo(object? parameter) => Load();

    /// <summary>E02 "Dosierer Ausloesen manuell": eine einzelne Dosierung mit dem Sollgewicht; ausserhalb des zulaessigen Betriebszustands nennt die Meldezeile den Grund (A-28).</summary>
    [RelayCommand]
    private async Task TriggerAsync()
    {
        if (!_service.CanDoseManually)
        {
            _messages?.ShowHint(_localization.GetString("HS18_Dosing_Hint"));
            return;
        }

        await _service.TriggerManualDosingAsync();
    }

    /// <summary>E06 "Gewichtsanpassung": prueft die Stuetzstellen und beauftragt die Berechnung (S18-4: unter 3 gueltigen Paaren Warnung, keine Berechnung).</summary>
    [RelayCommand]
    private async Task AdjustAsync()
    {
        if (Points.Any(IsInvalidPair))
        {
            CalculationState = CalculationState.Invalid;
            return;
        }

        if (ValidPointCount < MinimumPoints)
        {
            CalculationState = CalculationState.TooFewPoints;
            return;
        }

        await PersistAsync();
        var result = await _service.AdjustWeightAsync();
        CalculationState = result.Accepted ? CalculationState.Calculated : CalculationState.TooFewPoints;
    }

    private static bool IsValidPair(CorrectionPoint point) => point.Nominal > 0 && point.Actual > 0;

    private static bool IsInvalidPair(CorrectionPoint point) => (point.Nominal > 0) != (point.Actual > 0);

    private void OnPointChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (_isLoading)
        {
            return;
        }

        ValidPointCount = Points.Count(IsValidPair);
        CalculationState = CalculationState.None;
        _ = PersistAsync();
    }

    private Task PersistAsync() => _service.SetWeightCorrectionAsync(new ClosingWeightCorrectionData(
        TargetWeight,
        Points.Select(p => new ClosingWeightPoint(p.Nominal, p.Actual)).ToList()));

    private void Load()
    {
        var data = _service.WeightCorrection;
        _isLoading = true;
        try
        {
            foreach (var point in Points)
            {
                point.PropertyChanged -= OnPointChanged;
            }

            Points.Clear();
            for (var i = 0; i < data.Points.Count; i++)
            {
                var source = data.Points[i];
                var point = new CorrectionPoint { Nominal = source.Nominal, Actual = source.Actual, Block = i < 10 ? 1 : 2 };
                point.PropertyChanged += OnPointChanged;
                Points.Add(point);
            }

            TargetWeight = data.TargetWeight;
            ValidPointCount = Points.Count(IsValidPair);
            CalculationState = CalculationState.None;
        }
        finally
        {
            _isLoading = false;
        }
    }
}
