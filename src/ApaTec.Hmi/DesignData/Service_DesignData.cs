namespace ApaTec.Hmi.DesignData;

/// <summary>Beispielwerte HS-36 (Bild RS-36_01): Variablennamen der Geber, Anzahl 111427, Wert 859,81 der Variable alrPos[10].</summary>
public static class Service_DesignData
{
    public const int TotalVariableCount = 111427;

    public const string MarkedVariable = ".G_astGeber[1].alrPos[10]";

    public const double MarkedVariableValue = 859.81;

    private static readonly Lazy<string[]> LazyNames = new(Build);

    public static string[] VariableNames => LazyNames.Value;

    private static string[] Build()
    {
        var names = new List<string>(TotalVariableCount);
        for (var g = 1; names.Count < TotalVariableCount; g++)
        {
            for (var i = 1; i <= 12; i++)
            {
                names.Add($".G_astGeber[{g}].alrPos[{i}]");
            }

            names.Add($".G_astGeber[{g}].lrPeriode");
            names.Add($".G_astGeber[{g}].lrVel");
            names.Add($".G_astGeber[{g}].sName");
            names.Add($".G_astGeber[{g}].xDirection");
        }

        names.RemoveRange(TotalVariableCount, names.Count - TotalVariableCount);
        return names.ToArray();
    }
}
