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
    /// <summary>Dummy-Rolle fuer das Sollgewicht (Schluessel, OP-04, OP-25).</summary>
    private const UserRole RequiredRole = UserRole.Technician;

    private readonly IUserSession? _user;
    private readonly IDialogService? _dialogs;
    private readonly IMessageService? _messages;
    private readonly ILocalizationService _localization;
    private bool _isLoading;

    [ObservableProperty]
    private bool _isAuthorized = true;

    [ObservableProperty]
    private double _targetWeight;

    [ObservableProperty]
    private int _validPointCount;

    [ObservableProperty]
    private CalculationState _calculationState = CalculationState.None;

    /// <summary>Entwurfsmodus: Dummy-Dienst.</summary>
    public ClosingWeightCorrectionViewModel()
        : this(new DummyClosingMachineService(), null, null, null, LocalizationService.Instance)
    {
    }

    public ClosingWeightCorrectionViewModel(
        IClosingMachineService service, IUserSession? user, IDialogService? dialogs, IMessageService? messages, ILocalizationService localization)
    {
        _service = service;
        _user = user;
        _dialogs = dialogs;
        IsAuthorized = user?.HasRole(RequiredRole) ?? true;
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

    public override void OnNavigatedTo(object? parameter)
    {
        Load();
        IsAuthorized = _user?.HasRole(RequiredRole) ?? true;
        if (_user is not null)
        {
            _user.SessionChanged -= OnSessionChanged;
            _user.SessionChanged += OnSessionChanged;
        }
    }

    public override void OnNavigatedFrom()
    {
        if (_user is not null)
        {
            _user.SessionChanged -= OnSessionChanged;
        }
    }

    private void OnSessionChanged(object? sender, EventArgs e) => IsAuthorized = _user?.HasRole(RequiredRole) ?? true;

    /// <summary>Antippen des Sollgewichts (E01): nur mit Rolle (Schluessel), Eingabe-Pop-up mit Grenzen.</summary>
    [RelayCommand]
    private async Task EditTargetWeightAsync()
    {
        if (_dialogs is null)
        {
            return;
        }

        if (_user is not null && !_user.HasRole(RequiredRole))
        {
            _messages?.ShowHint(_localization.Format("Msg_PermissionRequired", _localization.GetString("HM01_Role_" + RequiredRole)));
            if (!await _user.RequestRoleAsync(RequiredRole))
            {
                return;
            }

            IsAuthorized = _user.HasRole(RequiredRole);
        }

        if (await RequestAsync(_localization.GetString("Dosing_Field_CorrectionTargetWeight_Title"), TargetWeight) is { } value)
        {
            TargetWeight = value;
        }
    }

    [RelayCommand]
    private Task EditNominalAsync(CorrectionPoint? point) => EditPointAsync(point, nominal: true);

    [RelayCommand]
    private Task EditActualAsync(CorrectionPoint? point) => EditPointAsync(point, nominal: false);

    private async Task EditPointAsync(CorrectionPoint? point, bool nominal)
    {
        if (point is null || _dialogs is null)
        {
            return;
        }

        var column = _localization.GetString(nominal ? "HM22_Nominal_Header" : "HM22_Actual_Header");
        var title = $"{_localization.GetString("Dosing_Field_CorrectionPointValue_Title")} {Points.IndexOf(point) + 1} – {column}";
        if (await RequestAsync(title, nominal ? point.Nominal : point.Actual) is { } value)
        {
            if (nominal)
            {
                point.Nominal = value;
            }
            else
            {
                point.Actual = value;
            }
        }
    }

    // Eingabe-Pop-up mit den Grenzen des Sollgewichts; Werte ausserhalb nennt die Meldezeile (Ablehnung statt stummem Verwerfen).
    private async Task<double?> RequestAsync(string title, double current)
    {
        var limits = _service.GetLimits(ClosingField.TargetWeight);
        var result = await _dialogs!.ShowAsync<double?>(DialogKeys.Input, new ClosingInputRequest(title, current, limits));
        if (!result.Accepted || result.Value is not { } value)
        {
            return null;
        }

        if (value < limits.Minimum || value > limits.Maximum)
        {
            _messages?.ShowHint(_localization.Format("HS16_Error_Range", limits.Minimum, limits.Maximum, limits.Unit));
            return null;
        }

        return value;
    }

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
