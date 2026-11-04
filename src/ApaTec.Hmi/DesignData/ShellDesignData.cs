using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.DesignData;

/// <summary>Beispielwerte des Rahmens aus dem Design (Konzept.md 6.7, OP-22): Meldung 014, 112 1/min, 245 Grad, 9:15, 06.01.2026.</summary>
public static class ShellDesignData
{
    public const int MessageNumber = 14;

    public const string MessageText = "Sicherung 4F24 Auslaufband ausgelöst.";

    public const MessageClass MessageClass = Models.MessageClass.Notice;

    public const int AdditionalMessageCount = 2;

    public const int UnreadMessageCount = 3;

    public const double MachineSpeed = 112;

    public const double MachineAngle = 245;

    public const OperatingMode OperatingMode = Models.OperatingMode.Production;
}
