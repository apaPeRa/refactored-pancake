using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using ApaTec.Hmi.ViewModels;

namespace ApaTec.Hmi.DesignData;

/// <summary>Entwurfsdaten der Heissleimseiten HS-07 bis HS-10: Dummy-Dienste mit den Beispielwerten aus den Bildern der Referenz und des Designs (Dialoge und Navigation entfallen im Entwurf).</summary>
public static class HotGlueDesignData
{
    public static IHotGlueService Service { get; } = new DummyHotGlueService();

    public static IHotGlueScheduleService ScheduleService { get; } = new DummyHotGlueScheduleService();

    public static HotGlueEditContext CreateContext() =>
        new(Service, null, new DummyUserSession(), null, LocalizationService.Instance);
}
