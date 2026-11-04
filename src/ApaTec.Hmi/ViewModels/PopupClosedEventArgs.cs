namespace ApaTec.Hmi.ViewModels;

/// <summary>Ereignisdaten zu <see cref="PopupViewModelBase.Closed"/>.</summary>
public sealed class PopupClosedEventArgs : EventArgs
{
    public PopupClosedEventArgs(bool accepted, object? result)
    {
        Accepted = accepted;
        Result = result;
    }

    public bool Accepted { get; }

    public object? Result { get; }
}
