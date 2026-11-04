using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Controls;

/// <summary>HM-28 Temperaturzonen-Zeile: Dependency Properties, Komposition aus HM-12, HM-11, HM-08 und HM-09 in HM28_HeatZoneRow.Styles.xaml.</summary>
public sealed class HM28_HeatZoneRow : Control
{
    public static readonly DependencyProperty ZoneNameProperty = DependencyProperty.Register(
        nameof(ZoneName), typeof(string), typeof(HM28_HeatZoneRow), new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty RowKindProperty = DependencyProperty.Register(
        nameof(RowKind), typeof(ZoneRowKind), typeof(HM28_HeatZoneRow), new PropertyMetadata(ZoneRowKind.Glue));

    public static readonly DependencyProperty SetpointProperty = DependencyProperty.Register(
        nameof(Setpoint), typeof(double), typeof(HM28_HeatZoneRow),
        new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public static readonly DependencyProperty ActualProperty = DependencyProperty.Register(
        nameof(Actual), typeof(double?), typeof(HM28_HeatZoneRow), new PropertyMetadata(null));

    /// <summary>Entspricht „Zone ein (IsEnabled)“ der Moduldefinition; umbenannt, weil <c>UIElement.IsEnabled</c> die Bedienbarkeit regelt.</summary>
    public static readonly DependencyProperty IsZoneEnabledProperty = DependencyProperty.Register(
        nameof(IsZoneEnabled), typeof(bool), typeof(HM28_HeatZoneRow),
        new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public static readonly DependencyProperty IsMonitoredProperty = DependencyProperty.Register(
        nameof(IsMonitored), typeof(bool), typeof(HM28_HeatZoneRow),
        new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public static readonly DependencyProperty StateLedProperty = DependencyProperty.Register(
        nameof(StateLed), typeof(LedState), typeof(HM28_HeatZoneRow), new PropertyMetadata(LedState.Off));

    public static readonly DependencyProperty OutputLedProperty = DependencyProperty.Register(
        nameof(OutputLed), typeof(LedState), typeof(HM28_HeatZoneRow), new PropertyMetadata(LedState.Off));

    public static readonly DependencyProperty ToggleZoneCommandProperty = DependencyProperty.Register(
        nameof(ToggleZoneCommand), typeof(ICommand), typeof(HM28_HeatZoneRow), new PropertyMetadata(null));

    public static readonly DependencyProperty ToggleMonitorCommandProperty = DependencyProperty.Register(
        nameof(ToggleMonitorCommand), typeof(ICommand), typeof(HM28_HeatZoneRow), new PropertyMetadata(null));

    // Ergaenzung (Integration, A-88): Antippen des Soll-Felds (HM-12) und Berechtigung; null = Feld reagiert nicht.
    public static readonly DependencyProperty EditCommandProperty = DependencyProperty.Register(
        nameof(EditCommand), typeof(ICommand), typeof(HM28_HeatZoneRow), new PropertyMetadata(null));

    public static readonly DependencyProperty IsAuthorizedProperty = DependencyProperty.Register(
        nameof(IsAuthorized), typeof(bool), typeof(HM28_HeatZoneRow), new PropertyMetadata(true));

    // Heizungen (HS-22): Schluessel/Schloss und Zustand "Ausstehend" der beiden Zustandstasten.
    public static readonly DependencyProperty RequiresPermissionProperty = DependencyProperty.Register(
        nameof(RequiresPermission), typeof(bool), typeof(HM28_HeatZoneRow), new PropertyMetadata(true));

    public static readonly DependencyProperty IsZonePendingProperty = DependencyProperty.Register(
        nameof(IsZonePending), typeof(bool), typeof(HM28_HeatZoneRow), new PropertyMetadata(false));

    public static readonly DependencyProperty IsMonitorPendingProperty = DependencyProperty.Register(
        nameof(IsMonitorPending), typeof(bool), typeof(HM28_HeatZoneRow), new PropertyMetadata(false));

    static HM28_HeatZoneRow()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(HM28_HeatZoneRow), new FrameworkPropertyMetadata(typeof(HM28_HeatZoneRow)));
    }

    public string ZoneName
    {
        get => (string)GetValue(ZoneNameProperty);
        set => SetValue(ZoneNameProperty, value);
    }

    public ZoneRowKind RowKind
    {
        get => (ZoneRowKind)GetValue(RowKindProperty);
        set => SetValue(RowKindProperty, value);
    }

    public double Setpoint
    {
        get => (double)GetValue(SetpointProperty);
        set => SetValue(SetpointProperty, value);
    }

    public double? Actual
    {
        get => (double?)GetValue(ActualProperty);
        set => SetValue(ActualProperty, value);
    }

    public bool IsZoneEnabled
    {
        get => (bool)GetValue(IsZoneEnabledProperty);
        set => SetValue(IsZoneEnabledProperty, value);
    }

    public bool IsMonitored
    {
        get => (bool)GetValue(IsMonitoredProperty);
        set => SetValue(IsMonitoredProperty, value);
    }

    public LedState StateLed
    {
        get => (LedState)GetValue(StateLedProperty);
        set => SetValue(StateLedProperty, value);
    }

    public LedState OutputLed
    {
        get => (LedState)GetValue(OutputLedProperty);
        set => SetValue(OutputLedProperty, value);
    }

    public ICommand? ToggleZoneCommand
    {
        get => (ICommand?)GetValue(ToggleZoneCommandProperty);
        set => SetValue(ToggleZoneCommandProperty, value);
    }

    public ICommand? ToggleMonitorCommand
    {
        get => (ICommand?)GetValue(ToggleMonitorCommandProperty);
        set => SetValue(ToggleMonitorCommandProperty, value);
    }

    /// <summary>Antippen des Soll-Felds (Eingabe-Pop-up); wird vom ViewModel der Zeile bereitgestellt.</summary>
    public ICommand? EditCommand
    {
        get => (ICommand?)GetValue(EditCommandProperty);
        set => SetValue(EditCommandProperty, value);
    }

    /// <summary>Berechtigung fuer das Soll-Feld; false = Schloss statt Schluessel.</summary>
    public bool IsAuthorized
    {
        get => (bool)GetValue(IsAuthorizedProperty);
        set => SetValue(IsAuthorizedProperty, value);
    }

    /// <summary>Heizung und Meldung tragen Schluessel (bzw. Schloss ohne Rolle, <see cref="IsAuthorized"/>).</summary>
    public bool RequiresPermission
    {
        get => (bool)GetValue(RequiresPermissionProperty);
        set => SetValue(RequiresPermissionProperty, value);
    }

    /// <summary>Befehl "Heizung ein/aus" ist gesendet, Rueckmeldung steht aus.</summary>
    public bool IsZonePending
    {
        get => (bool)GetValue(IsZonePendingProperty);
        set => SetValue(IsZonePendingProperty, value);
    }

    /// <summary>Befehl "Meldung ein/aus" ist gesendet, Rueckmeldung steht aus.</summary>
    public bool IsMonitorPending
    {
        get => (bool)GetValue(IsMonitorPendingProperty);
        set => SetValue(IsMonitorPendingProperty, value);
    }
}
