using ApaTec.Hmi.Models;
using ApaTec.Hmi.Services;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// Gemeinsame Basis der Zufuehrungsseiten HS-05 und HS-06: bearbeitbare Felder (<see cref="FeederValueField"/>), Texte aus <c>.resx</c>,
/// Berechtigungszustand und Abgleich mit <see cref="IFeederService"/>, <see cref="IUserSession"/> und der Sprachumschaltung.
/// </summary>
public abstract class FeederPageViewModelBase : PageViewModelBase
{
    private readonly List<FeederValueField> _fields = new();
    private bool _subscribed;

    protected FeederPageViewModelBase(IFeederService feeder, IUserSession? session, ILocalizationService localization, FeederValueEditor editor)
    {
        Feeder = feeder;
        Session = session;
        Localization = localization;
        Editor = editor;
    }

    protected IFeederService Feeder { get; }

    protected IUserSession? Session { get; }

    protected ILocalizationService Localization { get; }

    protected FeederValueEditor Editor { get; }

    public override void OnNavigatedTo(object? parameter)
    {
        Subscribe();
        RefreshAll();
    }

    public override void OnNavigatedFrom() => Unsubscribe();

    /// <summary>Legt ein Eingabefeld an; Texte und Grenzen setzt <see cref="RefreshAll"/>.</summary>
    protected FeederValueField CreateField(FeederValue id, string labelKey, string unitKey, string titleKey, string helpKey)
    {
        var field = new FeederValueField(id, labelKey, unitKey, titleKey, helpKey, EditFieldAsync);
        _fields.Add(field);
        return field;
    }

    /// <summary>Liest Werte aus dem Dienst (abgeleitete Klasse).</summary>
    protected abstract void LoadValues();

    /// <summary>Setzt Texte (Sprache) neu, z. B. Funktionsleiste oder Tooltips (abgeleitete Klasse).</summary>
    protected virtual void RefreshTexts()
    {
    }

    /// <summary>Texte, Grenzen, Berechtigung und Werte aller Felder neu setzen.</summary>
    protected void RefreshAll()
    {
        foreach (var field in _fields)
        {
            field.Label = Localization.GetString(field.LabelKey);
            field.Unit = Localization.GetString(field.UnitKey);
            field.Title = Localization.GetString(field.TitleKey);
            field.HelpText = Localization.GetString(field.HelpKey);
            var limits = Feeder.GetLimits(field.Id);
            field.Minimum = limits.Minimum;
            field.Maximum = limits.Maximum;
            field.RequiredRoleText = Editor.RequiredRoleText;
            field.IsAuthorized = Editor.IsAuthorized;
        }

        RefreshTexts();
        LoadValues();
    }

    /// <summary>Wird nach einem Wechsel der Berechtigung aufgerufen.</summary>
    protected virtual void OnAuthorizationChanged()
    {
    }

    private async Task EditFieldAsync(FeederValueField field)
    {
        var result = await Editor.RequestValueAsync(
            field.Title, field.Value, field.Unit, decimals: 0, new FeederLimits(field.Minimum ?? 0, field.Maximum ?? 0), field.HelpText, editing => field.IsEditing = editing);
        field.ErrorText = result.ErrorText;
        if (result.Value is { } value)
        {
            Feeder.SetValue(field.Id, value);
            field.Value = value;
        }
    }

    private void Subscribe()
    {
        if (_subscribed)
        {
            return;
        }

        _subscribed = true;
        Feeder.Changed += OnFeederChanged;
        Localization.CultureChanged += OnCultureChanged;
        if (Session is not null)
        {
            Session.SessionChanged += OnSessionChanged;
        }
    }

    private void Unsubscribe()
    {
        if (!_subscribed)
        {
            return;
        }

        _subscribed = false;
        Feeder.Changed -= OnFeederChanged;
        Localization.CultureChanged -= OnCultureChanged;
        if (Session is not null)
        {
            Session.SessionChanged -= OnSessionChanged;
        }
    }

    private void OnFeederChanged(object? sender, EventArgs e) => LoadValues();

    private void OnCultureChanged(object? sender, EventArgs e) => RefreshAll();

    private void OnSessionChanged(object? sender, EventArgs e)
    {
        foreach (var field in _fields)
        {
            field.IsAuthorized = Editor.IsAuthorized;
        }

        OnAuthorizationChanged();
    }
}
