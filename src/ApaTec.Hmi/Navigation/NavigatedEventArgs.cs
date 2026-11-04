namespace ApaTec.Hmi.Navigation;

/// <summary>Ereignisdaten zu <see cref="INavigationService.Navigated"/>.</summary>
public sealed class NavigatedEventArgs : EventArgs
{
    public NavigatedEventArgs(PageDescriptor descriptor, object? parameter)
    {
        Descriptor = descriptor;
        Parameter = parameter;
    }

    public PageDescriptor Descriptor { get; }

    public object? Parameter { get; }
}
