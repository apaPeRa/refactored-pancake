namespace ApaTec.Hmi.Services;

/// <summary>Systemfunktionen der Steuerung und der Bedienoberflaeche (HS-35; Konzept.md 6.6). true = Aktion ausgefuehrt.</summary>
public interface ISystemControlService
{
    Task<bool> RunLampTestAsync();

    Task<bool> RestartControlAsync();

    Task<bool> ShutDownControlAsync();

    Task<bool> QuitUserInterfaceAsync();

    Task<bool> MinimizeUserInterfaceAsync();

    Task<bool> OpenTaskManagerAsync();
}
