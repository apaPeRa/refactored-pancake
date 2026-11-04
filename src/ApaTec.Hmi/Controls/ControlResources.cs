using System.Collections;
using System.Resources;
using System.Windows;

namespace ApaTec.Hmi.Controls;

/// <summary>
/// Bindet alle Stil-Dictionaries der Module ein, ohne gemeinsame Datei: jede Datei <c>Controls/*.Styles.xaml</c> (ein <c>ResourceDictionary</c>,
/// z. B. <c>Controls/HM07_ActionButton.Styles.xaml</c>) wird beim Start per Reflection auf die kompilierten Ressourcen gefunden und in die
/// Anwendungsressourcen gemerged. Das Theme bleibt dabei das erste Dictionary (Designsystem 8).
/// </summary>
public static class ControlResources
{
    private const string ResourceSetName = "ApaTec.Hmi.g.resources";
    private const string Folder = "controls/";
    private const string Suffix = ".styles.baml";

    public static void MergeAll(Application application)
    {
        var stream = typeof(ControlResources).Assembly.GetManifestResourceStream(ResourceSetName);
        if (stream is null)
        {
            return;
        }

        using (stream)
        using (var reader = new ResourceReader(stream))
        {
            foreach (DictionaryEntry entry in reader)
            {
                if (entry.Key is string name
                    && name.StartsWith(Folder, StringComparison.OrdinalIgnoreCase)
                    && name.EndsWith(Suffix, StringComparison.OrdinalIgnoreCase))
                {
                    var path = string.Concat(name.AsSpan(0, name.Length - ".baml".Length), ".xaml");
                    application.Resources.MergedDictionaries.Add(new ResourceDictionary
                    {
                        Source = new Uri($"pack://application:,,,/ApaTec.Hmi;component/{path}", UriKind.Absolute),
                    });
                }
            }
        }
    }
}
