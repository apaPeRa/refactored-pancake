namespace ApaTec.Hmi.Navigation;

/// <summary>Eintrag im Zurueck-Stapel: Seitenschluessel und Parameter der Vorgaengerseite.</summary>
public sealed record NavigationEntry(string Key, object? Parameter);
