using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// Basisklasse aller Pop-up-ViewModels (Dialoge und Pop-up-Seiten HS-02/HS-03). Pop-ups stehen im Popup-Stapel des Navigationsdienstes
/// (Tiefe 2, nie im Verlauf; Navigation.md 4.2). Das Schliessen erfolgt ueber <see cref="Close"/>, <see cref="AcceptCommand"/> oder <see cref="CancelCommand"/>.
/// </summary>
public abstract partial class PopupViewModelBase : ObservableObject
{
    private bool _isClosed;

    [ObservableProperty]
    private string _title = string.Empty;

    /// <summary>Dialog- bzw. Seitenschluessel, mit dem das Pop-up geoeffnet wurde.</summary>
    public string PopupKey { get; private set; } = string.Empty;

    /// <summary>Wird genau einmal beim Schliessen ausgeloest.</summary>
    public event EventHandler<PopupClosedEventArgs>? Closed;

    /// <summary>Wird vor dem Anzeigen aufgerufen; Parameter des Aufrufers.</summary>
    public virtual void OnOpened(object? parameter)
    {
    }

    /// <summary>Ergebnis, das bei <see cref="AcceptCommand"/> geliefert wird.</summary>
    protected virtual object? GetResult() => null;

    /// <summary>Ob Uebernehmen/Ja zulaessig ist (z. B. gueltiger Eingabewert).</summary>
    protected virtual bool CanAccept() => true;

    /// <summary>Haken fuer Pop-ups, die beim Uebernehmen nicht schliessen, sondern weiterarbeiten (z. B. Vorgang ausfuehren und Ergebnis zeigen). true = Uebernehmen ist behandelt, nicht schliessen.</summary>
    protected virtual bool HandleAccept() => false;

    /// <summary>Schliesst das Pop-up.</summary>
    protected void Close(bool accepted, object? result = null)
    {
        if (_isClosed)
        {
            return;
        }

        _isClosed = true;
        Closed?.Invoke(this, new PopupClosedEventArgs(accepted, result));
    }

    internal void Initialize(string popupKey, object? parameter)
    {
        PopupKey = popupKey;
        OnOpened(parameter);
    }

    /// <summary>Schliesst das Pop-up ohne Uebernehmen (Dienst-Aufruf, z. B. Seitenwechsel durch das System).</summary>
    internal void Dismiss() => Close(false);

    [RelayCommand(CanExecute = nameof(CanAccept))]
    private void Accept()
    {
        if (!HandleAccept())
        {
            Close(true, GetResult());
        }
    }

    [RelayCommand]
    private void Cancel() => Close(false);
}
