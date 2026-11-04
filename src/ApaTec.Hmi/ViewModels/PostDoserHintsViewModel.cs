using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;

namespace ApaTec.Hmi.ViewModels;

/// <summary>Pop-up "Hinweise zur optimalen Nutzung" der Gewichtskorrektur (HS-21, S21-1): die vier Schritte und vier Hinweise des Handbuchs; Schliessen ueber Kreuz oder "Schliessen".</summary>
[DialogKey(DialogKey)]
public sealed class PostDoserHintsViewModel : PopupViewModelBase
{
    /// <summary>Dialogschluessel (kein Eintrag in <c>DialogKeys</c>, da nur HS-21 das Pop-up nutzt).</summary>
    public const string DialogKey = "PostDoserHints";

    public PostDoserHintsViewModel()
        : this(LocalizationService.Instance)
    {
    }

    public PostDoserHintsViewModel(ILocalizationService localization)
    {
        Title = localization.GetString("Dosing_Correction_HintsTitle");
    }
}
