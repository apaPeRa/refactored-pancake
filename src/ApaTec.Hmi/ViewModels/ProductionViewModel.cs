using System.Collections.ObjectModel;
using ApaTec.Hmi.Controls;
using ApaTec.Hmi.Models;
using ApaTec.Hmi.Navigation;
using ApaTec.Hmi.Services;
using ApaTec.Hmi.Services.Dummy;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ApaTec.Hmi.ViewModels;

/// <summary>HS-01 Produktion: Kennzahlen, Versorgung, Tastenblock, Umschalter, Funktionsleiste "Schichtplan"; oeffnet HS-02, HS-03 und das Rezeptauswahl-Pop-up.</summary>
[PageKey(PageKeys.Production)]
public sealed partial class ProductionViewModel : PageViewModelBase
{
    private const UserRole RecipeRole = UserRole.Technician;

    private readonly IProductionService _production;
    private readonly IProductionFunctionService _functions;
    private readonly IMachineSpeedService _speeds;
    private readonly IMachineStatusService _machine;
    private readonly IRecipeService _recipes;
    private readonly INavigationService _navigation;
    private readonly IUserSession _session;
    private readonly SynchronizationContext? _context = SynchronizationContext.Current;
    private readonly IMessageService _messages;
    private readonly IDialogService _dialogs;
    private readonly ILocalizationService _loc;
    private readonly Dictionary<ProductionFunction, ProductionToggleItem> _items = new();
    private readonly FunctionBarItem _shiftPlanItem = new();

    public ProductionViewModel(
        IProductionService production,
        IProductionFunctionService functions,
        IMachineSpeedService speeds,
        IMachineStatusService machine,
        IRecipeService recipes,
        INavigationService navigation,
        IUserSession session,
        IMessageService messages,
        IDialogService dialogs,
        ILocalizationService localization)
    {
        _production = production;
        _functions = functions;
        _speeds = speeds;
        _machine = machine;
        _recipes = recipes;
        _navigation = navigation;
        _session = session;
        _messages = messages;
        _dialogs = dialogs;
        _loc = localization;

        foreach (var function in Enum.GetValues<ProductionFunction>())
        {
            _items[function] = new ProductionToggleItem(function, ToggleFunctionAsync);
        }

        TileItems = new[]
        {
            ProductionFunction.Automatic,
            ProductionFunction.FeedPaper,
            ProductionFunction.FeedCarton,
            ProductionFunction.BlowOutEmptyPacks,
            ProductionFunction.Filling,
            ProductionFunction.EmptyHopper,
        }.Select(f => new TileItem { Content = _items[f] }).ToArray();

        // Reihenfolge laut HS-01: Bahnkontrolle, Heizungen, Gebläse Dornrad, Produktzuführung, Produktüberwachung | Rüttlung, Entstaubung, Linienbetrieb, Maschinenbeleuchtung.
        WebControl = _items[ProductionFunction.WebControl];
        Heating = _items[ProductionFunction.Heating];
        MandrelBlower = _items[ProductionFunction.MandrelBlower];
        ProductFeed = _items[ProductionFunction.ProductFeed];
        ProductMonitoring = _items[ProductionFunction.ProductMonitoring];
        Shaking = _items[ProductionFunction.Shaking];
        DustExtraction = _items[ProductionFunction.DustExtraction];
        LineOperation = _items[ProductionFunction.LineOperation];
        Lighting = _items[ProductionFunction.Lighting];
        FastItem = _items[ProductionFunction.Fast];

        _shiftPlanItem.IconKey = "Icon.Schedule";
        _shiftPlanItem.Kind = FunctionBarItemKind.Action;
        _shiftPlanItem.TargetId = PageKeys.ShiftPlan;
        _shiftPlanItem.Command = OpenShiftPlanCommand;
        FunctionBarItems.Add(_shiftPlanItem);

        BuildTexts();
        Refresh();
    }

    /// <summary>Entwurfsmodus: Dummy-Dienste, ohne Navigation, Benutzer und Dialoge.</summary>
    public ProductionViewModel()
        : this(
            new DummyProductionService(),
            new DummyProductionFunctionService(),
            new DummyMachineSpeedService(),
            new DummyMachineStatusService(),
            new DummyRecipeService(),
            null!,
            null!,
            null!,
            null!,
            LocalizationService.Instance)
    {
    }

    // ---- Kennzahlen ----
    [ObservableProperty]
    private double? _speedSetpoint;

    [ObservableProperty]
    private double? _speedActual;

    [ObservableProperty]
    private double? _currentProduction;

    [ObservableProperty]
    private double? _lastProduction;

    [ObservableProperty]
    private double? _lastWeight;

    [ObservableProperty]
    private int? _lastWeightIndex;

    [ObservableProperty]
    private double? _meanWeight;

    [ObservableProperty]
    private double? _standardDeviation;

    /// <summary>true = fortlaufend, false = Stichprobe (Wort des Umschalters).</summary>
    [ObservableProperty]
    private bool _isContinuous = true;

    [ObservableProperty]
    private bool _isWeightModePending;

    // ---- Rezeptanwahl ----
    [ObservableProperty]
    private string _recipeLabel = string.Empty;

    [ObservableProperty]
    private bool _isRecipeAuthorized = true;

    [ObservableProperty]
    private string _recipeRoleText = string.Empty;

    // ---- Versorgung ----
    [ObservableProperty]
    private IReadOnlyList<ProductionSupplyRow> _supplyRows = Array.Empty<ProductionSupplyRow>();

    [ObservableProperty]
    private IReadOnlyList<ProductionSupplyRow> _lineRows = Array.Empty<ProductionSupplyRow>();

    // ---- Tasten und Umschalter ----
    public IReadOnlyList<TileItem> TileItems { get; }

    public ProductionToggleItem FastItem { get; }

    public ProductionToggleItem WebControl { get; }

    public ProductionToggleItem Heating { get; }

    public ProductionToggleItem MandrelBlower { get; }

    public ProductionToggleItem ProductFeed { get; }

    public ProductionToggleItem ProductMonitoring { get; }

    public ProductionToggleItem Shaking { get; }

    public ProductionToggleItem DustExtraction { get; }

    public ProductionToggleItem LineOperation { get; }

    public ProductionToggleItem Lighting { get; }

    public override void OnNavigatedTo(object? parameter)
    {
        Unsubscribe();
        _production.Changed += OnDataChanged;
        _functions.Changed += OnDataChanged;
        _speeds.Changed += OnDataChanged;
        _machine.Changed += OnDataChanged;
        _recipes.Changed += OnDataChanged;
        if (_session is not null)
        {
            _session.SessionChanged += OnDataChanged;
        }

        _loc.CultureChanged += OnCultureChanged;
        BuildTexts();
        Refresh();
    }

    public override void OnNavigatedFrom() => Unsubscribe();

    private void Unsubscribe()
    {
        _production.Changed -= OnDataChanged;
        _functions.Changed -= OnDataChanged;
        _speeds.Changed -= OnDataChanged;
        _machine.Changed -= OnDataChanged;
        _recipes.Changed -= OnDataChanged;
        if (_session is not null)
        {
            _session.SessionChanged -= OnDataChanged;
        }

        _loc.CultureChanged -= OnCultureChanged;
    }

    // Dienstereignisse koennen auf einem Hintergrundthread kommen: im Kontext des Erzeugers (UI) aktualisieren.
    private void OnDataChanged(object? sender, EventArgs e)
    {
        if (_context is null || SynchronizationContext.Current == _context)
        {
            Refresh();
        }
        else
        {
            _context.Post(_ => Refresh(), null);
        }
    }

    private void OnCultureChanged(object? sender, EventArgs e)
    {
        BuildTexts();
        Refresh();
    }

    private void BuildTexts()
    {
        foreach (var (function, item) in _items)
        {
            item.Label = _loc.GetString(function == ProductionFunction.Fast ? "Production_Speed_Mode_Label" : $"Production_Function_{function}");
        }

        foreach (var tile in TileItems)
        {
            tile.Label = ((ProductionToggleItem)tile.Content!).Label;
        }

        _shiftPlanItem.Label = _loc.GetString("Production_ShiftPlan_Label");
        RecipeRoleText = _loc.GetString($"HM01_Role_{RecipeRole}");
    }

    private void Refresh()
    {
        foreach (var (function, item) in _items)
        {
            var status = _functions.GetStatus(function);
            item.IsOn = function == ProductionFunction.Automatic && !status.IsOn ? null : status.IsOn;
            item.IsPending = status.IsPending;
            item.IsEnabled = status.IsEnabled;
            item.ErrorText = status.HasFault ? _loc.GetString("Production_Function_Fault_Text") : null;
            item.RefreshState();
        }

        var valid = _production.IsValid;
        SpeedActual = valid ? _machine.Speed : null;
        var fast = _items[ProductionFunction.Fast].IsOn == true;
        SpeedSetpoint = valid ? _speeds.GetSpeed(fast ? MachineSpeedKind.Fast : MachineSpeedKind.Slow) : null;
        CurrentProduction = valid ? _production.CurrentProduction : null;
        LastProduction = valid ? _production.LastProduction : null;
        LastWeight = valid ? _production.LastWeight : null;
        LastWeightIndex = _production.LastWeightIndex;
        MeanWeight = valid ? _production.MeanWeight : null;
        StandardDeviation = valid ? _production.StandardDeviation : null;
        IsContinuous = _production.WeightMode == ProductionWeightMode.Continuous;

        RecipeLabel = string.Concat(_loc.GetString("Production_Recipe_Label"), Environment.NewLine, _recipes.CurrentRecipe);
        IsRecipeAuthorized = _session is null || _session.HasRole(RecipeRole);

        SupplyRows = _production.Supplies.Where(s => s.Item <= ProductionSupplyItem.Product).Select(ToRow).ToArray();
        LineRows = _production.Supplies.Where(s => s.Item > ProductionSupplyItem.Product).Select(ToRow).ToArray();
    }

    private ProductionSupplyRow ToRow(ProductionSupply supply) =>
        new(_loc.GetString($"Production_Supply_{supply.Item}"), supply.State == ProductionSupplyState.Invalid ? null : supply.Word, supply.State);

    private async Task ToggleFunctionAsync(ProductionToggleItem item, bool? requested)
    {
        if (requested is not bool on)
        {
            item.RefreshState();
            return;
        }

        if (item.Function == ProductionFunction.Automatic)
        {
            // Teilweise -> alle erfassten Funktionen anwaehlen; im Zustand Ein ohne Wirkung (S01-9).
            if (!on || item.IsOn == true)
            {
                item.RefreshState();
                return;
            }

            item.IsPending = true;
            var added = await _functions.SelectAllAutomaticAsync();
            item.IsPending = false;
            Refresh();
            var names = string.Join(
                _loc.GetString("Production_Automatic_Separator"),
                added.Select(f => _loc.GetString($"Production_Function_{f}")));
            _messages?.ShowHint(added.Count > 0
                ? _loc.Format("Production_Automatic_Hint", names)
                : _loc.GetString("Production_Automatic_AlreadyAll"));
            return;
        }

        item.IsPending = true;
        var ok = await _functions.SetAsync(item.Function, on);
        Refresh();
        if (!ok)
        {
            item.ErrorText = _loc.GetString("Production_Function_NotAcknowledged_Text");
        }
    }

    [RelayCommand]
    private async Task ToggleWeightModeAsync()
    {
        IsWeightModePending = true;
        var next = _production.WeightMode == ProductionWeightMode.Continuous ? ProductionWeightMode.Sample : ProductionWeightMode.Continuous;
        await _production.SetWeightModeAsync(next);
        IsWeightModePending = false;
        Refresh();
    }

    [RelayCommand]
    private Task OpenMachineSpeedAsync() => _navigation.NavigateToAsync(PageKeys.MachineSpeed);

    [RelayCommand]
    private Task OpenProductionCounterAsync() => _navigation.NavigateToAsync(PageKeys.ProductionCounter);

    [RelayCommand]
    private Task OpenShiftPlanAsync() => _navigation.NavigateToAsync(PageKeys.ShiftPlan);

    /// <summary>Rezeptauswahl-Pop-up (Platzhalter, OP-01); Rolle Technik, sonst Hinweis und Benutzer-Pop-up (Navigation.md 4.1).</summary>
    [RelayCommand]
    private async Task OpenRecipeAsync()
    {
        if (!_session.HasRole(RecipeRole))
        {
            _messages.ShowHint(_loc.Format("Msg_PermissionRequired", RecipeRoleText));
            if (!await _session.RequestRoleAsync(RecipeRole))
            {
                return;
            }
        }

        var result = await _dialogs.ShowAsync<string>(DialogKeys.Recipe, new NavigationParameters("currentRecipe", _recipes.CurrentRecipe));
        if (result.Accepted && result.Value is { Length: > 0 } name)
        {
            _recipes.Select(name);
        }
    }
}
