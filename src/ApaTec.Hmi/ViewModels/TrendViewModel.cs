using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// HS-15 Trend (Einstellung > Waagen > Kontrollwaage > Trend): Liniendiagramm der letzten gewogenen Gewichte (HM-26), 21 Positionen -20 bis -0.
/// Reine Anzeigeseite ohne Eingabe und ohne Funktionsleistentasten.
/// </summary>
[PageKey(PageKeys.Trend)]
public sealed partial class TrendViewModel : PageViewModelBase
{
    /// <summary>Schritt der Y-Achse in g (Bild RS-15_01).</summary>
    private const double Step = 0.5;

    private readonly IScaleService _scales;
    private readonly ILocalizationService _loc;
    private SynchronizationContext? _context;

    public TrendViewModel(IScaleService scales, ILocalizationService loc)
    {
        _scales = scales;
        _loc = loc;
        YUnit = loc.GetString("HS15_Unit_Gram");
        Refresh();
    }

    /// <summary>Entwurfsmodus (DesignData): Dummy-Dienst.</summary>
    public TrendViewModel()
        : this(new DummyScaleService(), LocalizationService.Instance)
    {
    }

    /// <summary>Anzahl der Positionen (konfigurierbar, OP-32); HM-26 zeigt hoechstens so viele Punkte.</summary>
    public int MaxPoints => _scales.TrendPointCount;

    public double YStep => Step;

    public string YUnit { get; }

    [ObservableProperty]
    private IReadOnlyList<ChartPoint> _series = Array.Empty<ChartPoint>();

    [ObservableProperty]
    private IReadOnlyList<string> _xLabels = Array.Empty<string>();

    /// <summary>Untergrenze der Y-Achse: eine Schrittweite unter dem kleinsten Wert (HS-15-P04); null = automatisch.</summary>
    [ObservableProperty]
    private double? _yMinimum;

    /// <summary>Obergrenze der Y-Achse: eine Schrittweite ueber dem groessten Wert.</summary>
    [ObservableProperty]
    private double? _yMaximum;

    public override void OnNavigatedTo(object? parameter)
    {
        _context = SynchronizationContext.Current;
        _scales.Changed += OnServiceChanged;
        Refresh();
    }

    public override void OnNavigatedFrom()
    {
        _scales.Changed -= OnServiceChanged;
    }

    private void OnServiceChanged(object? sender, EventArgs e)
    {
        if (_context is null || SynchronizationContext.Current == _context)
        {
            Refresh();
        }
        else
        {
            _context.Post(_ => Refresh(), null);
        }
    }

    private void Refresh()
    {
        var values = _scales.GetTrend();
        var count = values.Count;
        var labels = new List<string>(count);
        var points = new List<ChartPoint>(count);
        for (var i = 0; i < count; i++)
        {
            var label = _loc.Format("HS15_XAxis_Format", count - 1 - i);
            labels.Add(label);
            points.Add(new ChartPoint(label, values[i]));
        }

        var valid = values.Where(v => v.HasValue).Select(v => v!.Value).ToList();
        if (valid.Count >= 2)
        {
            YMinimum = (Math.Floor(valid.Min() / Step) * Step) - Step;
            YMaximum = (Math.Ceiling(valid.Max() / Step) * Step) + Step;
        }
        else
        {
            YMinimum = null;
            YMaximum = null;
        }

        XLabels = labels;
        Series = valid.Count >= 2 ? points : Array.Empty<ChartPoint>();
    }
}
