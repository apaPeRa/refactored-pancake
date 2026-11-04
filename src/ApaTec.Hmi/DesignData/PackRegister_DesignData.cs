using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.DesignData;

/// <summary>
/// Beispielwerte fuer HS-28 Packungsregister (RS-28_01). Block: 3 vorhanden, 2 schlecht, 1 keine; Stern im Uhrzeigersinn ab oben: 4 vorhanden, 1 keine, 4 vorhanden, 3 schlecht;
/// Reihe: 40 und 41 vorhanden, 42 bis 52 befuellt, 53 bis 61 gut; Spalte: 9 vorhanden. Nummern ausserhalb der Reihe sind Annahmen (OP-53).
/// </summary>
public static class PackRegister_DesignData
{
    public const int BlockCount = 6;

    public const int StarCount = 12;

    public const int RowFirstNumber = 40;

    public const int RowLastNumber = 61;

    public const int ColumnCount = 9;

    public static IReadOnlyList<PackStationState> Stations { get; } = Build();

    private static List<PackStationState> Build()
    {
        var result = new List<PackStationState>();
        PackState[] block = { PackState.Present, PackState.Present, PackState.Present, PackState.Bad, PackState.Bad, PackState.None };
        for (var i = 0; i < BlockCount; i++)
        {
            result.Add(new PackStationState(1 + i, PackStationGroup.Block, i, block[i]));
        }

        PackState[] star =
        {
            PackState.Present, PackState.Present, PackState.Present, PackState.Present, PackState.None, PackState.Present,
            PackState.Present, PackState.Present, PackState.Present, PackState.Bad, PackState.Bad, PackState.Bad,
        };
        for (var i = 0; i < StarCount; i++)
        {
            result.Add(new PackStationState(BlockCount + 1 + i, PackStationGroup.Star, i, star[i]));
        }

        for (var number = RowFirstNumber; number <= RowLastNumber; number++)
        {
            var state = number <= 41 ? PackState.Present : number <= 52 ? PackState.Filled : PackState.Ok;
            result.Add(new PackStationState(number, PackStationGroup.Row, number - RowFirstNumber, state));
        }

        for (var i = 0; i < ColumnCount; i++)
        {
            result.Add(new PackStationState(RowLastNumber + 1 + i, PackStationGroup.Column, i, PackState.Present));
        }

        return result;
    }
}
