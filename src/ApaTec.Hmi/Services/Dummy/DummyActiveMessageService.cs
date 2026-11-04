using ApaTec.Hmi.DesignData;
using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Services.Dummy;

/// <summary>Dummy: feste Liste anstehender Meldungen aus dem Bild; das Ereignis wird nie ausgeloest.</summary>
[DummyService]
public sealed class DummyActiveMessageService : IActiveMessageService
{
    public event EventHandler? Changed
    {
        add { }
        remove { }
    }

    public IReadOnlyList<MessageEntry> GetActiveMessages() => MessageView_DesignData.CreateMessages().OrderBy(m => m.Number).ToList();
}
