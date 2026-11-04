using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.DesignData;

/// <summary>Beispielwerte fuer HM-31 (HS-06): Reihe 1: 200/205/205/205/205; 2: 225 x4; 3: 300/310 x4; 4: 325/329 x3.</summary>
public static class HM31_DesignData
{
    public static IReadOnlyList<GlueTrackField> Fields { get; } = Build();

    private static List<GlueTrackField> Build()
    {
        double[][] rows =
        {
            new double[] { 200, 205, 205, 205, 205 },
            new double[] { 225, 225, 225, 225 },
            new double[] { 300, 310, 310, 310, 310 },
            new double[] { 325, 329, 329, 329 },
        };
        var list = new List<GlueTrackField>();
        for (var r = 0; r < rows.Length; r++)
        {
            for (var i = 0; i < rows[r].Length; i++)
            {
                list.Add(new GlueTrackField { Row = r + 1, Index = i + 1, Angle = rows[r][i], Tooltip = $"{r + 1}.{i + 1}" });
            }
        }

        return list;
    }
}
