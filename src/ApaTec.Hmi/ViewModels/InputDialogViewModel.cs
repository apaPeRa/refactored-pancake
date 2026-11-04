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
/// Eingabe-Pop-up (HM-13, <see cref="DialogKeys.Input"/>) fuer Zahl, Zeit (hh:mm) und Text. Parameter: <see cref="IInputRequest"/> (alle Request-Typen der Seiten)
/// oder <see cref="NavigationParameters"/> mit den Schluesseln title, currentValue/value, text, unit, minimum, maximum, decimals, helpText, errorText, inputKind (beliebige Schreibweise).
/// Uebernehmen ist gesperrt, solange der Wert fehlt oder ausserhalb von Minimum/Maximum liegt (Fehlertext am Feld). Ergebnis: <c>double</c> (Zeit als Minuten seit 00:00) bzw. <c>string</c>.
/// </summary>
[DialogKey(DialogKeys.Input)]
public sealed partial class InputDialogViewModel : PopupViewModelBase
{
    private const int TimeDigits = 4;
    private const int MaxTextLength = 40;
    private const int MaxNumberLength = 12; // HM-13: Zahl hoechstens 12 Zeichen (Vorzeichen, Ziffern, Komma)
    private const int MinutesPerHour = 60;
    private const int HoursPerDay = 24;

    private readonly ILocalizationService _loc;
    private string _buffer = string.Empty;
    private double? _result;
    private string? _customError;

    [ObservableProperty]
    private string _fieldTitle = string.Empty;

    [ObservableProperty]
    private InputKind _kind = InputKind.Number;

    [ObservableProperty]
    private string _inputText = string.Empty;

    [ObservableProperty]
    private double? _currentValue;

    [ObservableProperty]
    private string _unit = string.Empty;

    [ObservableProperty]
    private double? _minimum;

    [ObservableProperty]
    private double? _maximum;

    [ObservableProperty]
    private int _decimals;

    [ObservableProperty]
    private string? _helpText;

    [ObservableProperty]
    private string? _errorText;

    [ObservableProperty]
    private bool _isValid;

    public InputDialogViewModel()
        : this(LocalizationService.Instance)
    {
        FieldTitle = LocalizationService.Instance.GetString("Dialog_Design_Input_Field");
        CurrentValue = 12.5;
        Unit = LocalizationService.Instance.GetString("Dialog_Design_Input_Unit");
        Decimals = 1;
        Minimum = 0;
        Maximum = 100;
    }

    public InputDialogViewModel(ILocalizationService localization)
    {
        _loc = localization;
        Title = _loc.GetString("Dialog_Input_Title");
    }

    public override void OnOpened(object? parameter)
    {
        var request = parameter as IInputRequest ?? FromParameters(parameter);
        FieldTitle = request.Title;
        Kind = request.Kind == InputKind.Filter ? InputKind.Number : request.Kind;
        Unit = request.Unit;
        Decimals = Math.Max(0, request.Decimals);
        Minimum = request.Minimum;
        Maximum = request.Maximum;
        _customError = request.ErrorText;
        CurrentValue = Kind == InputKind.Number ? request.Value : null;
        HelpText = BuildHelpText(request);

        _buffer = Kind == InputKind.Text ? request.Text ?? string.Empty : string.Empty;
        Refresh();
    }

    private string? BuildHelpText(IInputRequest request)
    {
        if (Kind == InputKind.Time && request.Value is { } minutes)
        {
            var current = _loc.Format("Dialog_Input_CurrentTime", FormatMinutes(minutes));
            return string.IsNullOrEmpty(request.HelpText) ? current : current + " " + request.HelpText;
        }

        return string.IsNullOrEmpty(request.HelpText) ? null : request.HelpText;
    }

    protected override object? GetResult() => Kind == InputKind.Text ? InputText : _result;

    protected override bool CanAccept() => IsValid;

    [RelayCommand]
    private void Digit(string? text)
    {
        if (string.IsNullOrEmpty(text) || Kind == InputKind.Text)
        {
            return;
        }

        var separator = Separator;
        if (text == "," || text == "." || text == separator)
        {
            AppendSeparator();
            return;
        }

        if (text.Length != 1 || !char.IsAsciiDigit(text[0]))
        {
            return;
        }

        if (Kind == InputKind.Time)
        {
            if (_buffer.Length < TimeDigits)
            {
                _buffer += text;
            }
        }
        else if (CanAppendDigit())
        {
            _buffer = _buffer == "0" ? text : _buffer == "-0" ? "-" + text : _buffer + text;
        }

        Refresh();
    }

    [RelayCommand]
    private void DecimalSeparator()
    {
        AppendSeparator();
        Refresh();
    }

    [RelayCommand]
    private void Sign()
    {
        if (Kind != InputKind.Number)
        {
            return;
        }

        _buffer = _buffer.StartsWith('-') ? _buffer[1..] : "-" + _buffer;
        Refresh();
    }

    [RelayCommand]
    private void Backspace()
    {
        if (Kind == InputKind.Text || _buffer.Length == 0)
        {
            return;
        }

        _buffer = _buffer[..^1];
        if (_buffer == "-")
        {
            _buffer = string.Empty;
        }

        Refresh();
    }

    [RelayCommand]
    private void Clear()
    {
        _buffer = string.Empty;
        InputText = string.Empty;
        Refresh();
    }

    partial void OnInputTextChanged(string value)
    {
        // Textvariante: das Textfeld schreibt direkt in InputText.
        if (Kind == InputKind.Text && value != _buffer)
        {
            _buffer = value.Length > MaxTextLength ? value[..MaxTextLength] : value;
            Refresh();
        }
    }

    private string Separator => _loc.Culture.NumberFormat.NumberDecimalSeparator;

    private bool CanAppendDigit()
    {
        if (_buffer.Length >= MaxNumberLength)
        {
            return false;
        }

        var separatorAt = _buffer.IndexOf(Separator, StringComparison.Ordinal);
        if (separatorAt < 0)
        {
            return true;
        }

        return _buffer.Length - separatorAt - Separator.Length < Decimals;
    }

    private void AppendSeparator()
    {
        if (Kind != InputKind.Number || Decimals == 0 || _buffer.Contains(Separator, StringComparison.Ordinal) || _buffer.Length >= MaxNumberLength - 1)
        {
            return;
        }

        _buffer = (_buffer.Length == 0 || _buffer == "-" ? _buffer + "0" : _buffer) + Separator;
    }

    private void Refresh()
    {
        _result = null;
        string? error = null;
        var valid = false;
        switch (Kind)
        {
            case InputKind.Text:
                InputTextSilently(_buffer);
                valid = true;
                break;
            case InputKind.Time:
                InputTextSilently(FormatTimeDigits(_buffer));
                (valid, error) = ValidateTime();
                break;
            default:
                InputTextSilently(_buffer);
                (valid, error) = ValidateNumber();
                break;
        }

        ErrorText = error;
        IsValid = valid;
        AcceptCommand.NotifyCanExecuteChanged();
    }

    private void InputTextSilently(string value)
    {
        if (InputText != value)
        {
            InputText = value;
        }
    }

    private (bool Valid, string? Error) ValidateNumber()
    {
        if (_buffer.Length == 0 || _buffer == "-" || _buffer.EndsWith(Separator, StringComparison.Ordinal))
        {
            return (false, null);
        }

        if (!double.TryParse(_buffer, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint, _loc.Culture, out var value))
        {
            return (false, ErrorOr("Dialog_Input_Invalid"));
        }

        value = Math.Round(value, Decimals, MidpointRounding.AwayFromZero);
        if (OutOfRange(value))
        {
            return (false, RangeError(FormatNumber));
        }

        _result = value;
        return (true, null);
    }

    private (bool Valid, string? Error) ValidateTime()
    {
        if (_buffer.Length < TimeDigits)
        {
            return (false, null);
        }

        var hours = int.Parse(_buffer[..2], CultureInfo.InvariantCulture);
        var minutes = int.Parse(_buffer[2..], CultureInfo.InvariantCulture);
        if (hours >= HoursPerDay || minutes >= MinutesPerHour)
        {
            return (false, ErrorOr("Dialog_Input_InvalidTime"));
        }

        double total = (hours * MinutesPerHour) + minutes;
        if (OutOfRange(total))
        {
            return (false, RangeError(FormatMinutes));
        }

        _result = total;
        return (true, null);
    }

    private bool OutOfRange(double value) => (Minimum is { } min && value < min) || (Maximum is { } max && value > max);

    private string RangeError(Func<double, string> format)
    {
        if (_customError is not null)
        {
            return _customError;
        }

        return (Minimum, Maximum) switch
        {
            ({ } min, { } max) => _loc.Format("Dialog_Input_Range", format(min), format(max), Unit).Trim(),
            ({ } min, null) => _loc.Format("Dialog_Input_Min", format(min), Unit).Trim(),
            (null, { } max) => _loc.Format("Dialog_Input_Max", format(max), Unit).Trim(),
            _ => ErrorOr("Dialog_Input_Invalid"),
        };
    }

    private string ErrorOr(string key) => _customError ?? _loc.GetString(key);

    private string FormatNumber(double value) => value.ToString("N" + Decimals, _loc.Culture);

    private static string FormatMinutes(double minutes)
    {
        var total = (int)Math.Round(minutes);
        return string.Create(CultureInfo.InvariantCulture, $"{total / MinutesPerHour:00}:{total % MinutesPerHour:00}");
    }

    private static string FormatTimeDigits(string digits)
    {
        var text = new StringBuilder(digits.Length + 1);
        for (var i = 0; i < digits.Length; i++)
        {
            if (i == 2)
            {
                text.Append(':');
            }

            text.Append(digits[i]);
        }

        return text.ToString();
    }

    private static IInputRequest FromParameters(object? parameter)
    {
        var reader = new DialogParameterReader(parameter);
        var text = reader.GetString("text", "textValue");
        var value = reader.Find("currentValue", "value", "current");
        var kind = reader.GetEnum<InputKind>("inputKind", "kind") ?? (value is string || (value is null && text is not null) ? InputKind.Text : InputKind.Number);
        return new InputRequest(
            reader.GetString("title", "name", "label") ?? string.Empty,
            reader.GetDouble("currentValue", "value", "current"),
            reader.GetString("unit") ?? string.Empty,
            reader.GetInt("decimals") ?? 0,
            reader.GetDouble("minimum", "min"),
            reader.GetDouble("maximum", "max"),
            reader.GetString("helpText", "help", "hint"),
            kind,
            value as string ?? text,
            reader.GetString("errorText", "error"));
    }
}
