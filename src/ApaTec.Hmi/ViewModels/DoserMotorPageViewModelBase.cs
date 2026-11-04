using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>Gemeinsame Basis der Motorparameter-Seiten HS-12 (Hauptdosierer) und HS-20 (Nachdosierer): drei Karten HM-21 mit 13 Werten.</summary>
public abstract partial class DoserMotorPageViewModelBase : DosingPageViewModelBase
{
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

    protected DoserMotorPageViewModelBase(
        IDoserService service,
        INavigationService? navigation,
        IUserSession? session,
        IDialogService? dialogs,
        IMessageService? messages,
        ILocalizationService localization)
        : base(service, navigation, session, dialogs, messages, localization)
    {
    }

    /// <summary>Dosierer, dessen Motorparameter gezeigt werden.</summary>
    protected abstract DoserId CurrentId { get; }

    /// <summary>Kennung am Karten-Kopf ("HD1", "HD2", "ND").</summary>
    public string DoserName => CurrentId == DoserId.Post
        ? Localization.GetString("Dosing_DoserName_Post")
        : Localization.Format("Dosing_DoserName_Main", (int)CurrentId);

    protected override void RefreshState()
    {
        var m = Service.GetMotorSettings(CurrentId);
        ClosedPosition = m.Closed.Position;
        ClosedSpeed = m.Closed.Speed;
        ClosedAcceleration = m.Closed.Acceleration;
        ClosedDeceleration = m.Closed.Deceleration;
        ClosedJerk = m.Closed.Jerk;
        OpenPosition = m.Open.Position;
        OpenSpeed = m.Open.Speed;
        OpenAcceleration = m.Open.Acceleration;
        OpenDeceleration = m.Open.Deceleration;
        OpenJerk = m.Open.Jerk;
        ScrewAcceleration = m.Screw.Acceleration;
        ScrewDeceleration = m.Screw.Deceleration;
        ScrewJerk = m.Screw.Jerk;
        OnPropertyChanged(nameof(DoserName));
    }

    /// <summary>Antippen eines Felds der Karte Verschluss Zu; Parameter = Position, Speed, Acceleration, Deceleration, Jerk.</summary>
    [RelayCommand]
    private Task EditClosedAsync(string? name) => EditAsync("Closed", name);

    [RelayCommand]
    private Task EditOpenAsync(string? name) => EditAsync("Open", name);

    [RelayCommand]
    private Task EditScrewAsync(string? name) => EditAsync("Screw", name);

    private async Task EditAsync(string card, string? name)
    {
        if (name is null || !Enum.TryParse<DoserField>(card + name, out var field))
        {
            return;
        }

        var value = await Interaction.RequestValueAsync(field, Localization.GetString("Dosing_Field_" + field + "_Title"), CurrentValue(field), "Dosing_Field_" + field + "_Help");
        if (value is not { } v)
        {
            return;
        }

        var limits = Service.GetLimits(field);
        if (v < limits.Minimum || v > limits.Maximum)
        {
            return;
        }

        await Service.SetValueAsync(CurrentId, field, v);
    }

    private double CurrentValue(DoserField field) => field switch
    {
        DoserField.ClosedPosition => ClosedPosition,
        DoserField.ClosedSpeed => ClosedSpeed,
        DoserField.ClosedAcceleration => ClosedAcceleration,
        DoserField.ClosedDeceleration => ClosedDeceleration,
        DoserField.ClosedJerk => ClosedJerk,
        DoserField.OpenPosition => OpenPosition,
        DoserField.OpenSpeed => OpenSpeed,
        DoserField.OpenAcceleration => OpenAcceleration,
        DoserField.OpenDeceleration => OpenDeceleration,
        DoserField.OpenJerk => OpenJerk,
        DoserField.ScrewAcceleration => ScrewAcceleration,
        DoserField.ScrewDeceleration => ScrewDeceleration,
        DoserField.ScrewJerk => ScrewJerk,
        _ => 0,
    };
}
