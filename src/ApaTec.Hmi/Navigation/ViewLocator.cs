using System.Collections.Concurrent;
using System.Windows;
using System.Windows.Controls;
using ApaTec.Hmi.ViewModels;

namespace ApaTec.Hmi.Navigation;

/// <summary>
/// Loest ein ViewModel nach Namenskonvention in seine View auf: <c>&lt;Name&gt;ViewModel</c> wird zu <c>&lt;Name&gt;View</c> in einem Namespace
/// <c>ApaTec.Hmi.Views</c> (auch Unternamespaces wie <c>ApaTec.Hmi.Views.Feeders</c>). Gefundene Views werden per Reflection gesucht und gecacht.
/// Fehlt die View, erscheint <c>PlaceholderPageView</c> (bzw. <c>PlaceholderPopupView</c>). Einsatz in XAML:
/// <c>ContentTemplateSelector="{StaticResource ViewLocator}"</c> (Ressource in App.xaml). Kein Code-behind in Views noetig.
/// </summary>
public sealed class ViewLocator : DataTemplateSelector
{
    private const string ViewModelSuffix = "ViewModel";
    private const string ViewSuffix = "View";
    private const string ViewsNamespace = "ApaTec.Hmi.Views";

    private static readonly ConcurrentDictionary<Type, DataTemplate> Templates = new();
    private static readonly Lazy<Dictionary<string, Type>> ViewTypes = new(ScanViews);

    public override DataTemplate? SelectTemplate(object? item, DependencyObject container)
    {
        if (item is null)
        {
            return null;
        }

        return Templates.GetOrAdd(item.GetType(), CreateTemplate);
    }

    /// <summary>Liefert den View-Typ zu einem ViewModel-Typ oder null.</summary>
    public static Type? ResolveViewType(Type viewModelType)
    {
        var name = viewModelType.Name;
        if (!name.EndsWith(ViewModelSuffix, StringComparison.Ordinal))
        {
            return null;
        }

        var viewName = string.Concat(name.AsSpan(0, name.Length - ViewModelSuffix.Length), ViewSuffix);
        return ViewTypes.Value.TryGetValue(viewName, out var view) ? view : null;
    }

    private static DataTemplate CreateTemplate(Type viewModelType)
    {
        var viewType = ResolveViewType(viewModelType)
            ?? (typeof(PopupViewModelBase).IsAssignableFrom(viewModelType)
                ? ResolveViewType(typeof(PlaceholderPopupViewModel))
                : ResolveViewType(typeof(PlaceholderPageViewModel)))
            ?? typeof(ContentControl);
        return new DataTemplate(viewModelType) { VisualTree = new FrameworkElementFactory(viewType) };
    }

    private static Dictionary<string, Type> ScanViews()
    {
        var result = new Dictionary<string, Type>(StringComparer.Ordinal);
        foreach (var type in typeof(ViewLocator).Assembly.GetTypes())
        {
            if (type.IsAbstract || !type.IsClass || !typeof(FrameworkElement).IsAssignableFrom(type))
            {
                continue;
            }

            var ns = type.Namespace;
            if (ns is null || (ns != ViewsNamespace && !ns.StartsWith(ViewsNamespace + ".", StringComparison.Ordinal)) || !type.Name.EndsWith(ViewSuffix, StringComparison.Ordinal))
            {
                continue;
            }

            if (!result.TryAdd(type.Name, type))
            {
                throw new InvalidOperationException($"View-Name '{type.Name}' ist mehrfach vorhanden ({result[type.Name].FullName}, {type.FullName}).");
            }
        }

        return result;
    }
}
