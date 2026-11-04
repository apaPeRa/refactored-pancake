using System.ComponentModel;
using System.Globalization;

namespace ApaTec.Hmi.Services;

/// <summary>Zugriff auf die Texte der <c>.resx</c>-Dateien und Sprachumschaltung zur Laufzeit (A-77, OP-03).</summary>
public interface ILocalizationService : INotifyPropertyChanged
{
    CultureInfo Culture { get; }

    IReadOnlyList<CultureInfo> SupportedCultures { get; }

    /// <summary>Text zum Schluessel; fehlt er, erscheint <c>!Schluessel!</c> (sichtbar, nie leer).</summary>
    string this[string key] { get; }

    string GetString(string key);

    string Format(string key, params object?[] args);

    void SetCulture(CultureInfo culture);

    event EventHandler? CultureChanged;
}
