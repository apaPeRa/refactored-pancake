using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Services;

namespace ApaTec.Hmi.Controls;

/// <summary>Zeichenelement des Diagramms (HM-26) in Pixelkoordinaten des Plotbereichs.</summary>
public abstract record HM26_Mark(double X, double Y, double Width, double Height);

/// <summary>Balken.</summary>
public sealed record HM26_BarMark(double X, double Y, double Width, double Height, bool IsViolation) : HM26_Mark(X, Y, Width, Height);

/// <summary>Punktmarker der Linie; Grenzverletzung = Raute statt Kreis, aktueller Wert = groesser.</summary>
public sealed record HM26_PointMark(double X, double Y, double Width, double Height, bool IsCurrent, bool IsViolation) : HM26_Mark(X, Y, Width, Height);

/// <summary>Text (Wertbeschriftung, Achsenbeschriftung, „---“, „aktuell“).</summary>
public sealed record HM26_TextMark(double X, double Y, double Width, double Height, string Text) : HM26_Mark(X, Y, Width, Height);

/// <summary>Warnsymbol ueber einem Wert mit verletzter Grenze.</summary>
public sealed record HM26_IconMark(double X, double Y, double Width, double Height) : HM26_Mark(X, Y, Width, Height);

/// <summary>Gitterlinie bzw. Grenzlinie (<paramref name="IsLimit"/>), waagerecht ueber die Plotbreite.</summary>
public sealed record HM26_GridLine(double X, double Y, double Width, double Height, bool IsLimit) : HM26_Mark(X, Y, Width, Height);

/// <summary>Ergebnis der Skalierung: alles, was das Template zeichnet.</summary>
public sealed class HM26_Layout
{
    public static HM26_Layout Empty { get; } = new();

    public bool HasData { get; init; }

    public IReadOnlyList<HM26_Mark> Marks { get; init; } = Array.Empty<HM26_Mark>();

    public IReadOnlyList<HM26_GridLine> GridLines { get; init; } = Array.Empty<HM26_GridLine>();

    public IReadOnlyList<HM26_TextMark> YTicks { get; init; } = Array.Empty<HM26_TextMark>();

    public IReadOnlyList<HM26_TextMark> XTicks { get; init; } = Array.Empty<HM26_TextMark>();

    public Geometry? LinePath { get; init; }

    /// <summary>Wertetabelle als Text fuer Screenreader (AutomationProperties.HelpText).</summary>
    public string Table { get; init; } = string.Empty;
}

/// <summary>
/// Skaliert die Datenreihe auf den Plotbereich (Konzept HM-26: „Skalierung im Control per MultiValueConverter“, keine externen Pakete).
/// Eingaben in dieser Reihenfolge: Series, ChartKind, YMinimum, YMaximum, YStep, MaxPoints, ShowValueLabels, LowerLimit, UpperLimit,
/// XLabels, YUnit, Plotbreite, Plothoehe. Abmessungen von Markern und Schrift stammen aus den Tokens (Application.Resources).
/// </summary>
public sealed class HM26_ChartLayoutConverter : IMultiValueConverter
{
    private const double BarFill = 0.6;

    public static HM26_ChartLayoutConverter Instance { get; } = new();

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        var series = values.Length > 0 ? values[0] as IReadOnlyList<ChartPoint> : null;
        if (series is null || series.Count == 0)
        {
            return HM26_Layout.Empty;
        }

        var kind = values[1] is ChartKind k ? k : ChartKind.Line;
        var yMinSet = values[2] as double?;
        var yMaxSet = values[3] as double?;
        var step = values[4] is double st ? st : 0d;
        var maxPoints = values[5] is int mp && mp > 0 ? mp : 21;
        var showLabels = values[6] is not bool sl || sl;
        var lower = values[7] as double?;
        var upper = values[8] as double?;
        var xLabels = values[9] as IReadOnlyList<string>;
        var unit = values[10] as string;
        var w = values[11] is double dw && !double.IsNaN(dw) ? dw : 0d;
        var h = values[12] is double dh && !double.IsNaN(dh) ? dh : 0d;
        var interval = values.Length > 13 && values[13] is ChartInterval ci ? ci : ChartInterval.None;

        var points = series.Skip(Math.Max(0, series.Count - maxPoints)).ToList();
        var table = BuildTable(points, unit);
        if (w <= 0 || h <= 0)
        {
            return new HM26_Layout { HasData = true, Table = table };
        }

        var lineH = Token("Font.LineHeight.Caption", 26);
        var markerS = Token("Space.M", 16);
        var markerL = Token("Space.L", 24);
        var iconS = Token("Size.Icon.S", 24);
        var tickW = Token("Size.Touch.Default", 64);
        var pad = markerL;
        var usable = Math.Max(1, w - (2 * pad));
        var loc = LocalizationService.Instance;
        var cult = loc.Culture;

        // Wertebereich
        var valid = points.Where(p => p.Y.HasValue && !double.IsNaN(p.Y.Value)).Select(p => p.Y!.Value).ToList();
        var dataMin = valid.Count > 0 ? valid.Min() : 0d;
        var dataMax = valid.Count > 0 ? valid.Max() : 1d;
        var min = yMinSet ?? (kind == ChartKind.Bar ? Math.Min(0d, dataMin) : dataMin);
        var max = yMaxSet ?? dataMax;
        if (step > 0 && yMaxSet is null)
        {
            max = Math.Ceiling(max / step) * step;
        }

        if (step > 0 && yMinSet is null)
        {
            min = Math.Floor(min / step) * step;
        }

        if (max <= min)
        {
            max = min + (step > 0 ? step : 1d);
        }

        double YOf(double v) => h - (Math.Clamp(v, min, max) - min) / (max - min) * h;

        // Positionen
        var n = points.Count;
        var labelCount = xLabels?.Count ?? 0;
        // Intervall der Balken: Stunde = 24 Plaetze, Halbstunde = 48 Plaetze je Tag; die Beschriftung der X-Achse wird bei Halbstunde auf jeden zweiten Platz ausgeduennt.
        var intervalSlots = kind == ChartKind.Bar ? interval switch { ChartInterval.Hour => 24, ChartInterval.HalfHour => 48, _ => 1 } : 1;
        var labelEvery = kind == ChartKind.Bar && interval == ChartInterval.HalfHour ? 2 : 1;
        var slots = Math.Max(Math.Max(Math.Max(n, labelCount), intervalSlots), kind == ChartKind.Line ? maxPoints : 1);
        double CenterOf(int slot) => kind == ChartKind.Line
            ? (slots > 1 ? pad + (slot * usable / (slots - 1)) : w / 2)
            : pad + ((slot + 0.5) * usable / slots);
        var slotW = kind == ChartKind.Line ? (slots > 1 ? usable / (slots - 1) : usable) : usable / slots;
        var labelW = Math.Max(slotW, tickW);
        var dataOffset = kind == ChartKind.Line ? slots - n : 0;

        // Gitter und Y-Achse
        var gridLines = new List<HM26_GridLine>();
        var yTicks = new List<HM26_TextMark>();
        var tickStep = step > 0 ? step : (max - min) / 5d;
        var decimals = Math.Abs(tickStep - Math.Round(tickStep)) > 1e-9 ? 1 : 0;
        for (var i = 0; i <= 50; i++)
        {
            var v = min + (i * tickStep);
            if (v > max + (tickStep * 1e-6))
            {
                break;
            }

            var y = YOf(v);
            gridLines.Add(new HM26_GridLine(0, y, w, 0, false));
            yTicks.Add(new HM26_TextMark(0, y - (lineH / 2), tickW, lineH, v.ToString("F" + decimals, cult)));
        }

        foreach (var limit in new[] { lower, upper })
        {
            if (limit is { } l && l >= min && l <= max)
            {
                gridLines.Add(new HM26_GridLine(0, YOf(l), w, 0, true));
            }
        }

        // Datenmarken
        var marks = new List<HM26_Mark>();
        var line = new StreamGeometry();
        using (var ctx = line.Open())
        {
            var inFigure = false;
            for (var i = 0; i < n; i++)
            {
                var p = points[i];
                var cx = CenterOf(i + dataOffset);
                if (p.Y is not { } value || double.IsNaN(value))
                {
                    inFigure = false;
                    marks.Add(new HM26_TextMark(cx - (labelW / 2), h - lineH, labelW, lineH, loc.GetString("HM26_Invalid_Text")));
                    continue;
                }

                var y = YOf(value);
                var violation = (lower is { } lo && value < lo) || (upper is { } up && value > up);
                var isCurrent = kind == ChartKind.Line && i == n - 1;
                var valueText = value.ToString("F" + (kind == ChartKind.Line ? 1 : 0), cult);
                if (isCurrent && !string.IsNullOrEmpty(unit))
                {
                    valueText += " " + unit;
                }

                double labelY;
                if (kind == ChartKind.Bar)
                {
                    var barW = slotW * BarFill;
                    marks.Add(new HM26_BarMark(cx - (barW / 2), y, barW, Math.Max(0, h - y), violation));
                    labelY = y - lineH;
                }
                else
                {
                    var m = isCurrent ? markerL : markerS;
                    marks.Add(new HM26_PointMark(cx - (m / 2), y - (m / 2), m, m, isCurrent, violation));
                    labelY = y - (m / 2) - lineH;
                    if (inFigure)
                    {
                        ctx.LineTo(new Point(cx, y), true, false);
                    }
                    else
                    {
                        ctx.BeginFigure(new Point(cx, y), false, false);
                        inFigure = true;
                    }

                    if (isCurrent)
                    {
                        marks.Add(new HM26_TextMark(cx - (labelW / 2), y + (m / 2), labelW, lineH, loc.GetString("HM26_Current_Text")));
                    }
                }

                if (showLabels)
                {
                    marks.Add(new HM26_TextMark(cx - (labelW / 2), labelY, labelW, lineH, valueText));
                }

                if (violation)
                {
                    marks.Add(new HM26_IconMark(cx - (iconS / 2), labelY - iconS, iconS, iconS));
                }
            }
        }

        line.Freeze();

        // X-Achse
        var xTicks = new List<HM26_TextMark>();
        if (xLabels is not null)
        {
            var offset = kind == ChartKind.Line ? slots - xLabels.Count : 0;
            for (var j = 0; j < xLabels.Count; j += labelEvery)
            {
                xTicks.Add(new HM26_TextMark(CenterOf(j + offset) - (labelW / 2), 0, labelW, lineH, xLabels[j]));
            }
        }

        return new HM26_Layout
        {
            HasData = true,
            Marks = marks,
            GridLines = gridLines,
            YTicks = yTicks,
            XTicks = xTicks,
            LinePath = kind == ChartKind.Line ? line : null,
            Table = table,
        };
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        => throw new NotSupportedException();

    private static string BuildTable(IReadOnlyList<ChartPoint> points, string? unit)
    {
        var sb = new StringBuilder();
        foreach (var p in points)
        {
            sb.Append(p.X).Append(": ").Append(p.Y.HasValue ? p.Y.Value.ToString(LocalizationService.Instance.Culture) : "---").Append(unit is null ? string.Empty : " " + unit).Append("; ");
        }

        return sb.ToString();
    }

    private static double Token(string key, double fallback)
        => Application.Current?.TryFindResource(key) is double d ? d : fallback;
}
