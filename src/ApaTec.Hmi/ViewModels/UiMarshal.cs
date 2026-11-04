namespace ApaTec.Hmi.ViewModels;

/// <summary>Fuehrt Aktionen im Kontext des Erzeugers (UI) aus; Dienstereignisse kommen ggf. aus einem Hintergrundthread.</summary>
internal static class UiMarshal
{
    public static void Run(SynchronizationContext? context, Action action)
    {
        if (context is null || SynchronizationContext.Current == context)
        {
            action();
        }
        else
        {
            context.Post(_ => action(), null);
        }
    }
}
