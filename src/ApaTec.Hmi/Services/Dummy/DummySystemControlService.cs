namespace ApaTec.Hmi.Services.Dummy;

/// <summary>Dummy: alle Systemaktionen gelten als ausgefuehrt, ohne Wirkung (keine Maschinenanbindung).</summary>
[DummyService]
public sealed class DummySystemControlService : ISystemControlService
{
    public Task<bool> RunLampTestAsync() => Task.FromResult(true);

    public Task<bool> RestartControlAsync() => Task.FromResult(true);

    public Task<bool> ShutDownControlAsync() => Task.FromResult(true);

    public Task<bool> QuitUserInterfaceAsync() => Task.FromResult(true);

    public Task<bool> MinimizeUserInterfaceAsync() => Task.FromResult(true);

    public Task<bool> OpenTaskManagerAsync() => Task.FromResult(true);
}
