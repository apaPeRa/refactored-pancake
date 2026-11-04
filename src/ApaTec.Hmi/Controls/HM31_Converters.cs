using System.Globalization;
using System.Windows.Data;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Controls;

/// <summary>Gruppiert die Winkelfelder nach Reihe (aufsteigend) und Index (aufsteigend), z. B. 5, 4, 5, 4 Felder (HM-31).</summary>
[ValueConversion(typeof(IReadOnlyList<GlueTrackField>), typeof(IReadOnlyList<IReadOnlyList<GlueTrackField>>))]
public sealed class HM31_RowsConverter : IValueConverter
{
    public static HM31_RowsConverter Instance { get; } = new();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not IReadOnlyList<GlueTrackField> fields)
        {
            return Array.Empty<IReadOnlyList<GlueTrackField>>();
        }

        return fields.GroupBy(f => f.Row)
            .OrderBy(g => g.Key)
            .Select(g => (IReadOnlyList<GlueTrackField>)g.OrderBy(f => f.Index).ToList())
            .ToList();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
