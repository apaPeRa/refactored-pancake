namespace ApaTec.Hmi.Models;

/// <summary>Art eines Hinweis-Textfelds (HM-27).</summary>
public enum NoticeKind
{
    Info,
    Warning,
    Error,
    MessageLine,
}

/// <summary>Schweregrad einer Meldungszeile (HM-27, nur mit Kind = MessageLine).</summary>
public enum NoticeSeverity
{
    None,
    Info,
    Warning,
    Error,
}
