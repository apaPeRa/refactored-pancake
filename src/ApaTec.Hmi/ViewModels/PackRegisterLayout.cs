using ApaTec.Hmi.Controls;
using ApaTec.Hmi.DesignData;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// Lage der Stationsfelder in der Grafik von HS-28 (Koordinaten fuer HM-32). Block links, Drehstern in der Mitte, nummerierte Reihe rechts, Spalte unter dem Stern.
/// Feldgroesse und Abstaende entsprechen Size.Touch.Large x Size.Touch.Default und Size.Touch.Gap (Raster der Grafik, Annahme K28-1).
/// </summary>
public static class PackRegisterLayout
{
    private const double FieldWidth = 96;
    private const double FieldHeight = 64;
    private const double StepX = FieldWidth + 16;
    private const double StepY = FieldHeight + 16;
    private const double StarRadius = 230;
    private const double Connector = 64;

    private static readonly double StarCenterX = (PackRegister_DesignData.BlockCount * StepX) - 16 + Connector + StarRadius + (FieldWidth / 2);
    private static readonly double StarCenterY = StarRadius + (FieldHeight / 2);
    private static readonly double RowStartX = StarCenterX + StarRadius + (FieldWidth / 2) + Connector;
    private static readonly double ColumnY = (2 * StarRadius) + FieldHeight + Connector;

    /// <summary>Breite der Grafik.</summary>
    public static double Width { get; } = RowStartX + ((PackRegister_DesignData.RowLastNumber - PackRegister_DesignData.RowFirstNumber) * StepX) + FieldWidth;

    /// <summary>Hoehe der Grafik.</summary>
    public static double Height { get; } = ColumnY + ((PackRegister_DesignData.ColumnCount - 1) * StepY) + FieldHeight;

    public static PackStation Place(PackStationState station)
    {
        var (x, y) = station.Group switch
        {
            PackStationGroup.Block => (station.Position * StepX, StarCenterY - (FieldHeight / 2)),
            PackStationGroup.Star => StarPosition(station.Position),
            PackStationGroup.Row => (RowStartX + (station.Position * StepX), StarCenterY - (FieldHeight / 2)),
            _ => (StarCenterX - (FieldWidth / 2), ColumnY + (station.Position * StepY)),
        };
        return new PackStation { Number = station.Number, State = station.State, X = x, Y = y };
    }

    // Uhrzeigersinn ab oben, 12 Arme im Winkel von 30 Grad.
    private static (double X, double Y) StarPosition(int position)
    {
        var angle = position * 2 * Math.PI / PackRegister_DesignData.StarCount;
        return (StarCenterX + (StarRadius * Math.Sin(angle)) - (FieldWidth / 2), StarCenterY - (StarRadius * Math.Cos(angle)) - (FieldHeight / 2));
    }
}
