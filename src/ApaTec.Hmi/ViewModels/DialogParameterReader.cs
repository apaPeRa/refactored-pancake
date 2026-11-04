using System.Globalization;
using ApaTec.Hmi.Navigation;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// Liest Dialogparameter aus <see cref="NavigationParameters"/> unabhaengig von Gross-/Kleinschreibung und mit mehreren gleichbedeutenden Schluesseln
/// (z. B. <c>currentValue</c>, <c>value</c>, <c>Value</c>). Keine Fachlogik; Grundlage der Dialog-ViewModels, die zusaetzlich Request-Typen verstehen.
/// </summary>
internal sealed class DialogParameterReader
{
    private readonly IReadOnlyDictionary<string, object?> _values;

    public DialogParameterReader(object? parameter)
    {
        _values = parameter is NavigationParameters p ? p.Values : new Dictionary<string, object?>();
    }

    public bool IsEmpty => _values.Count == 0;

    /// <summary>Liefert den ersten vorhandenen Wert zu einem der Schluessel (ohne Beachtung der Schreibweise).</summary>
    public object? Find(params string[] keys)
    {
        foreach (var key in keys)
        {
            foreach (var pair in _values)
            {
                if (string.Equals(pair.Key, key, StringComparison.OrdinalIgnoreCase) && pair.Value is not null)
                {
                    return pair.Value;
                }
            }
        }

        return null;
    }

    public string? GetString(params string[] keys) => Find(keys) switch
    {
        null => null,
        string s => s,
        var other => Convert.ToString(other, CultureInfo.CurrentCulture),
    };

    public double? GetDouble(params string[] keys) => Find(keys) switch
    {
        double d => d,
        float f => f,
        int i => i,
        long l => l,
        decimal m => (double)m,
        short s => s,
        byte b => b,
        _ => null,
    };

    public int? GetInt(params string[] keys) => GetDouble(keys) is { } d ? (int)Math.Round(d) : null;

    public T? GetEnum<T>(params string[] keys)
        where T : struct, Enum => Find(keys) switch
        {
            T value => value,
            string s when Enum.TryParse<T>(s, true, out var parsed) => parsed,
            _ => null,
        };
}
