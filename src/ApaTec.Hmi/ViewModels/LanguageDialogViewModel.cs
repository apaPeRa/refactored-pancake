using System.Collections.ObjectModel;
using System.Globalization;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// Sprachwahl-Pop-up (<see cref="DialogKeys.Language"/>, Platzhalter OP-03): listet <see cref="ILocalizationService.SupportedCultures"/>, die aktuelle Sprache ist vorgewaehlt.
/// Ergebnis: <see cref="CultureInfo"/>; der Aufrufer (HS-04) uebernimmt sie mit <see cref="ILocalizationService.SetCulture"/>.
/// </summary>
[DialogKey(DialogKeys.Language)]
public sealed partial class LanguageDialogViewModel : PopupViewModelBase
{
    private readonly ILocalizationService _loc;

    [ObservableProperty]
    private DialogChoiceItem? _selected;

    public LanguageDialogViewModel()
        : this(LocalizationService.Instance)
    {
    }

    public LanguageDialogViewModel(ILocalizationService localization)
    {
        _loc = localization;
        Title = _loc.GetString("Dialog_Language_Title");
        foreach (var culture in _loc.SupportedCultures)
        {
            var item = new DialogChoiceItem(NativeName(culture), culture, culture.Equals(_loc.Culture));
            Items.Add(item);
            if (item.IsSelected)
            {
                Selected = item;
            }
        }
    }

    public ObservableCollection<DialogChoiceItem> Items { get; } = new();

    protected override object? GetResult() => Selected?.Value;

    protected override bool CanAccept() => Selected is not null;

    partial void OnSelectedChanged(DialogChoiceItem? value) => AcceptCommand.NotifyCanExecuteChanged();

    [RelayCommand]
    private void Choose(DialogChoiceItem? item)
    {
        if (item is null)
        {
            return;
        }

        foreach (var other in Items)
        {
            other.IsSelected = ReferenceEquals(other, item);
        }

        Selected = item;
    }

    private static string NativeName(CultureInfo culture)
    {
        var name = culture.NativeName;
        return name.Length == 0 ? culture.Name : char.ToUpper(name[0], culture) + name[1..];
    }
}
