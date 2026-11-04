using System.ComponentModel;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// HS-17 Motorparameter (Schliessmaschine): drei Karten Verschluss Zu, Verschluss Auf, Schnecke (HM-21). Die Funktionsleiste bleibt leer (A-37, A-44);
/// ein Dosierer-Wechsel existiert nicht. Geaenderte Werte werden sofort an den Dienst gegeben (S16-3-Muster, HM-24-Zustand "nicht geschrieben" entfaellt).
/// </summary>
[PageKey(PageKeys.ClosingMotor)]
public sealed partial class ClosingMotorViewModel : PageViewModelBase
{
    private static readonly HashSet<string> MotorProperties = new(StringComparer.Ordinal)
    {
        nameof(ClosedPosition), nameof(ClosedSpeed), nameof(ClosedAcceleration), nameof(ClosedDeceleration), nameof(ClosedJerk),
        nameof(OpenPosition), nameof(OpenSpeed), nameof(OpenAcceleration), nameof(OpenDeceleration), nameof(OpenJerk),
        nameof(ScrewAcceleration), nameof(ScrewDeceleration), nameof(ScrewJerk),
    };

    private readonly IClosingMachineService _service;
    private bool _isLoading;

    [ObservableProperty]
    private double _closedPosition;

    [ObservableProperty]
    private double _closedSpeed;

    [ObservableProperty]
    private double _closedAcceleration;

    [ObservableProperty]
    private double _closedDeceleration;

    [ObservableProperty]
    private double _closedJerk;

    [ObservableProperty]
    private double _openPosition;

    [ObservableProperty]
    private double _openSpeed;

    [ObservableProperty]
    private double _openAcceleration;

    [ObservableProperty]
    private double _openDeceleration;

    [ObservableProperty]
    private double _openJerk;

    [ObservableProperty]
    private double _screwAcceleration;

    [ObservableProperty]
    private double _screwDeceleration;

    [ObservableProperty]
    private double _screwJerk;

    /// <summary>Entwurfsmodus: Dummy-Dienst.</summary>
    public ClosingMotorViewModel()
        : this(new DummyClosingMachineService(), LocalizationService.Instance)
    {
    }

    public ClosingMotorViewModel(IClosingMachineService service, ILocalizationService localization)
    {
        _service = service;
        MachineName = localization.GetString("HS17_Machine_Name");
        Load();
    }

    /// <summary>Wert fuer <c>DoserName</c> der Karten: "Schliessmaschine" (S17-3), kein Dosierer-Zusatz.</summary>
    public string MachineName { get; }

    public override void OnNavigatedTo(object? parameter) => Load();

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);
        if (!_isLoading && e.PropertyName is not null && MotorProperties.Contains(e.PropertyName))
        {
            _ = PersistAsync();
        }
    }

    /// <summary>Uebernahme eines geaenderten Werts (HM-21 <c>CommitCommand</c>); die Werte stehen bereits im ViewModel, daher nur Schreiben.</summary>
    [RelayCommand]
    private Task CommitAsync() => PersistAsync();

    private Task PersistAsync() => _service.SetMotorSettingsAsync(new ClosingMotorSettings(
        new ClosingClosureMotion(ClosedPosition, ClosedSpeed, ClosedAcceleration, ClosedDeceleration, ClosedJerk),
        new ClosingClosureMotion(OpenPosition, OpenSpeed, OpenAcceleration, OpenDeceleration, OpenJerk),
        new ClosingScrewMotion(ScrewAcceleration, ScrewDeceleration, ScrewJerk)));

    private void Load()
    {
        var settings = _service.MotorSettings;
        _isLoading = true;
        try
        {
            ClosedPosition = settings.Closed.Position;
            ClosedSpeed = settings.Closed.Speed;
            ClosedAcceleration = settings.Closed.Acceleration;
            ClosedDeceleration = settings.Closed.Deceleration;
            ClosedJerk = settings.Closed.Jerk;
            OpenPosition = settings.Open.Position;
            OpenSpeed = settings.Open.Speed;
            OpenAcceleration = settings.Open.Acceleration;
            OpenDeceleration = settings.Open.Deceleration;
            OpenJerk = settings.Open.Jerk;
            ScrewAcceleration = settings.Screw.Acceleration;
            ScrewDeceleration = settings.Screw.Deceleration;
            ScrewJerk = settings.Screw.Jerk;
        }
        finally
        {
            _isLoading = false;
        }
    }
}
