using System.Windows.Data;
using System.Windows.Markup;
using ApaTec.Hmi.Services;

namespace ApaTec.Hmi.Resources;

/// <summary>
/// Lokalisierungs-Markup-Extension fuer XAML ohne Code-behind: <c>Text="{res:Loc Nav_Home_Label}"</c>
/// (Namespace <c>xmlns:res="clr-namespace:ApaTec.Hmi.Resources"</c>). Bindet an den Indexer des <see cref="LocalizationService"/>,
/// daher wirkt die Sprachumschaltung zur Laufzeit. Schluessel nach Designsystem 11: <c>&lt;Bereich&gt;_&lt;Element&gt;_&lt;Eigenschaft&gt;</c>.
/// </summary>
[MarkupExtensionReturnType(typeof(string))]
public sealed class LocExtension : MarkupExtension
{
    public LocExtension()
    {
    }

    public LocExtension(string key) => Key = key;

    [ConstructorArgument("key")]
    public string Key { get; set; } = string.Empty;

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        var binding = new Binding($"[{Key}]")
        {
            Source = LocalizationService.Instance,
            Mode = BindingMode.OneWay,
        };
        return binding.ProvideValue(serviceProvider);
    }
}
