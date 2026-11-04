using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace ApaTec.Hmi.Services;

/// <summary>Erzeugt Pop-up-ViewModels zu Dialogschluesseln und legt sie auf den Popup-Stapel des Navigationsdienstes.</summary>
public sealed class DialogService : IDialogService
{
    private readonly INavigationService _navigation;
    private readonly PageRegistry _registry;
    private readonly IServiceProvider _services;

    public DialogService(INavigationService navigation, PageRegistry registry, IServiceProvider services)
    {
        _navigation = navigation;
        _registry = registry;
        _services = services;
    }

    public bool IsModalOpen => _navigation.IsModalOpen;

    public Task<DialogResult<T>> ShowAsync<T>(string dialogKey, object? parameter = null)
    {
        PopupViewModelBase popup = _registry.TryGetDialogType(dialogKey, out var type)
            ? (PopupViewModelBase)_services.GetRequiredService(type)
            : new PlaceholderPopupViewModel(dialogKey);

        var completion = new TaskCompletionSource<DialogResult<T>>();
        popup.Closed += (_, e) => completion.TrySetResult(new DialogResult<T>(e.Accepted, e.Result is T value ? value : default));

        popup.Initialize(dialogKey, parameter);
        if (!_navigation.TryOpenPopup(popup))
        {
            return Task.FromResult(new DialogResult<T>(false, default));
        }

        return completion.Task;
    }

    public void CloseTop() => _navigation.CloseTopPopup();

    public void CloseAll() => _navigation.CloseAllPopups();
}
