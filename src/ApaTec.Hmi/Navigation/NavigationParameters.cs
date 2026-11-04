namespace ApaTec.Hmi.Navigation;

/// <summary>
/// Benannte Seitenparameter (z. B. <c>doserIndex</c>, <c>camNumber</c>; Navigation.md 5.1).
/// Beim Sprung auf einen Eintrag des Zurueck-Stapels werden gleichnamige Parameter der aktuellen Seite uebernommen (Navigation.md 5.3).
/// </summary>
public sealed class NavigationParameters
{
    private readonly Dictionary<string, object?> _values = new(StringComparer.Ordinal);

    public NavigationParameters()
    {
    }

    public NavigationParameters(string name, object? value) => _values[name] = value;

    public IReadOnlyDictionary<string, object?> Values => _values;

    public NavigationParameters With(string name, object? value)
    {
        _values[name] = value;
        return this;
    }

    public T? Get<T>(string name) => _values.TryGetValue(name, out var v) && v is T t ? t : default;

    /// <summary>Liefert <paramref name="baseValue"/> mit den Werten aus <paramref name="overrides"/>; sind beide keine <see cref="NavigationParameters"/>, gewinnt <paramref name="overrides"/>, wenn nicht null.</summary>
    public static object? Merge(object? baseValue, object? overrides)
    {
        if (baseValue is NavigationParameters b && overrides is NavigationParameters o)
        {
            var merged = new NavigationParameters();
            foreach (var kv in b._values)
            {
                merged._values[kv.Key] = kv.Value;
            }

            foreach (var kv in o._values)
            {
                merged._values[kv.Key] = kv.Value;
            }

            return merged;
        }

        return overrides ?? baseValue;
    }
}
