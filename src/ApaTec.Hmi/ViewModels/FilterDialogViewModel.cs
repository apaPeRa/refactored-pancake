using System.Globalization;
using System.Text;
using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>
/// Filter-Dialog (HM-13 Filtervariante in HM-14, <see cref="DialogKeys.Filter"/>, HS-37): ein Feld je Kriterium (Meldenummer, Zeit), nur Ziffern, aktive Zeile antippbar.
/// Parameter: <see cref="SystemDialogParameters.Filter"/> (Titel, <c>IReadOnlyList&lt;FilterField&gt;</c>). Ein Zeitfeld folgt seinem Platzhalter (Unterstriche = Ziffern) und gilt erst vollstaendig
/// und als gueltiges Datum als eingegeben; ein leeres Feld ist kein Kriterium. Ergebnis: <c>IReadOnlyList&lt;FilterField&gt;</c> (Kopien) mit dem Eingabewert je Feld.
/// </summary>
[DialogKey(DialogKeys.Filter)]
public sealed partial class FilterDialogViewModel : PopupViewModelBase
{
    private const char Slot = '_';
    private const string DateTimeFormat = "dd.MM.yyyy HH:mm:ss";
    private const int NumberDigits = 3;

    private readonly List<FilterField> _fields = new();
    private readonly List<string> _digits = new();

    [ObservableProperty]
    private IReadOnlyList<FilterField> _filterFields = Array.Empty<FilterField>();

    [ObservableProperty]
    private bool _isValid = true;

    [ObservableProperty]
    private string? _errorText;

    private readonly ILocalizationService _loc;

    public FilterDialogViewModel()
        : this(LocalizationService.Instance)
    {
        Title = "Meldungen filtern";
        Load(new[]
        {
            new FilterField { Name = "Meldenummer", Kind = FilterFieldKind.Number, Placeholder = "___" },
            new FilterField { Name = "Zeit", Kind = FilterFieldKind.DateTime, Placeholder = "__.__.____ __:__:__" },
        });
    }

    public FilterDialogViewModel(ILocalizationService localization)
    {
        _loc = localization;
        Title = _loc.GetString("Dialog_Filter_Title");
    }

    public override void OnOpened(object? parameter)
    {
        var reader = new DialogParameterReader(parameter);
        Title = reader.GetString("title") ?? Title;
        if (reader.Find("filterFields", "fields") is IReadOnlyList<FilterField> fields)
        {
            Load(fields);
        }
    }

    protected override object? GetResult() => _fields.ToList();

    protected override bool CanAccept() => IsValid;

    private void Load(IReadOnlyList<FilterField> source)
    {
        _fields.Clear();
        _digits.Clear();
        foreach (var field in source)
        {
            _fields.Add(new FilterField { Name = field.Name, Kind = field.Kind, Placeholder = field.Placeholder, Value = field.Value, IsActive = field.IsActive });
            _digits.Add(new string(field.Value.Where(char.IsAsciiDigit).ToArray()));
        }

        if (_fields.Count > 0 && !_fields.Any(f => f.IsActive))
        {
            _fields[0].IsActive = true;
        }

        FilterFields = _fields.ToList();
        Update();
    }

    [RelayCommand]
    private void SelectField(FilterField? field)
    {
        if (field is null || !_fields.Contains(field))
        {
            return;
        }

        foreach (var f in _fields)
        {
            f.IsActive = ReferenceEquals(f, field);
        }
    }

    [RelayCommand]
    private void Digit(string? text)
    {
        var index = ActiveIndex;
        if (index < 0 || text is not { Length: 1 } || !char.IsAsciiDigit(text[0]) || _digits[index].Length >= Capacity(_fields[index]))
        {
            return;
        }

        _digits[index] += text;
        Update();
    }

    [RelayCommand]
    private void Backspace()
    {
        var index = ActiveIndex;
        if (index >= 0 && _digits[index].Length > 0)
        {
            _digits[index] = _digits[index][..^1];
            Update();
        }
    }

    [RelayCommand]
    private void Clear()
    {
        var index = ActiveIndex;
        if (index >= 0)
        {
            _digits[index] = string.Empty;
            Update();
        }
    }

    private int ActiveIndex => _fields.FindIndex(f => f.IsActive);

    private static int Capacity(FilterField field)
    {
        var slots = field.Placeholder.Count(c => c == Slot);
        return slots > 0 ? slots : field.Kind == FilterFieldKind.Number ? NumberDigits : 14;
    }

    // Anzeige: Zahl = eingegebene Ziffern; Zeit = Platzhalter, von links mit Ziffern gefuellt (nur wenn schon Ziffern vorhanden).
    private static string Display(FilterField field, string digits)
    {
        if (digits.Length == 0)
        {
            return string.Empty;
        }

        if (field.Kind == FilterFieldKind.Number || !field.Placeholder.Contains(Slot))
        {
            return digits;
        }

        var text = new StringBuilder(field.Placeholder.Length);
        var next = 0;
        foreach (var c in field.Placeholder)
        {
            text.Append(c == Slot && next < digits.Length ? digits[next++] : c);
        }

        return text.ToString();
    }

    private void Update()
    {
        string? error = null;
        var valid = true;
        for (var i = 0; i < _fields.Count; i++)
        {
            var field = _fields[i];
            var digits = _digits[i];
            field.Value = Display(field, digits);
            if (digits.Length == 0 || field.Kind == FilterFieldKind.Number)
            {
                continue;
            }

            if (digits.Length < Capacity(field))
            {
                valid = false;
                error ??= _loc.GetString("Dialog_Filter_Incomplete");
            }
            else if (field.Placeholder.Length == DateTimeFormat.Length
                && !DateTime.TryParseExact(field.Value, DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                valid = false;
                error ??= _loc.GetString("Dialog_Filter_InvalidDate");
            }
        }

        ErrorText = error;
        IsValid = valid;
        AcceptCommand.NotifyCanExecuteChanged();
    }
}
