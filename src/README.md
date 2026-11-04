# ApaTec.Hmi – WPF-Lösung (Meilenstein 2)

Neue Maschinen-HMI der APA-TEC GmbH: C# / WPF / .NET 8, MVVM, Zielauflösung 1920 × 1080, Touch. Dieses Fundament (Paket M2-01) enthält Lösung, Designsystem, Hauptfenster, Navigation, Dienste und Basisklassen. Module (`HM-xx`) und Seiten (`HS-xx`) folgen in den weiteren Paketen (Konzept.md Abschnitt 7).

## Build und Prüfung

```
cd src
dotnet build ApaTec.Hmi.sln -p:EnableWindowsTargeting=true     # 0 Fehler, 0 Warnungen (Warnungen sind Fehler)
python3 tools/check_design.py                                   # statische Prüfungen (siehe unten)
python3 tools/check_modules.py                                  # HM-01..HM-38 gegen Modulliste.md (Klasse, Stil, DesignData, kein Logik-Code)
find . -name '*.xaml' -o -name '*.resx' | grep -v -e /obj/ -e /bin/ | xargs xmllint --noout
```

WPF läuft nur unter Windows; in der Cloud wird nur kompiliert und statisch geprüft (Agent.md Abschnitt 7). Das .NET-8-SDK der Cloud-Umgebung braucht das Windows-Desktop-SDK (Microsoft-Paket, nicht die Ubuntu-Variante), siehe A-81. Die Anwendung startet unter Windows mit `dotnet run --project src/ApaTec.Hmi`.

`tools/check_design.py` prüft: XML wohlgeformt, `Theme.Light.xaml` und `Theme.Dark.xaml` mit denselben Schlüsseln und den Hex-Werten aus Designsystem 10.1, alle Tokens aus 10.2/10.3, alle 68 Symbole aus Abschnitt 6/6.1, alle `StaticResource`/`DynamicResource`-Verweise definiert, leeres Code-behind, keine Literale in `Views/`, `Controls/` und `MainWindow.xaml`, alle `{res:Loc …}`-Schlüssel vorhanden, 43 Seitenschlüssel samt Titel- und Brotkrümeltexten.

## Struktur

```
src/
├─ ApaTec.Hmi.sln
├─ tools/check_design.py                 statische Prüfungen (Designsystem, Literale, Ressourcen)
├─ tools/check_modules.py                Modulprüfung HM-01 bis HM-38
└─ ApaTec.Hmi/                            net8.0-windows, WPF, Nullable, TreatWarningsAsErrors
   ├─ Program.cs                          Einstieg und Composition Root (Generic Host)
   ├─ App.xaml(.cs)                       bindet Theme, Tokens, Icons, Basisstile; ViewLocator; kein StartupUri
   ├─ MainWindow.xaml(.cs)                Hauptfenster 1920 × 1080 mit Rahmen-Grid (leeres Code-behind)
   ├─ Themes/                             Tokens.xaml, Theme.Light.xaml, Theme.Dark.xaml, Icons.xaml, Controls.Base.xaml
   ├─ Resources/                          Strings.resx (deutsche Neutralsprache), Strings/<Paket>.resx, LocExtension
   ├─ Navigation/                         INavigationService, NavigationService, PageKeys, PageCatalog, PageRegistry, ViewLocator, Attribute
   ├─ Services/                           Schnittstellen (Dialog, Benutzer, Thema, Sprache, Einstellungen, Uhr), echte Dienste
   │  └─ Dummy/                           Dummy-Implementierungen mit [DummyService]
   ├─ ViewModels/                         PageViewModelBase, PopupViewModelBase, ShellViewModel, FunctionBarItem, Platzhalter-VMs
   ├─ Views/                              <Name>View.xaml (leeres Code-behind); PlaceholderPageView, PlaceholderPopupView
   ├─ Controls/                           wiederverwendbare Module HM<nn>_<Name> (Custom Controls, A-73)
   ├─ Models/                             Datenmodelle der Dienste (UserRole, UserInfo, OperatingMode, MessageClass …)
   └─ DesignData/                         Beispielwerte für den Entwurfsmodus
```

Namespaces: Stamm `ApaTec.Hmi`; `.Navigation`, `.Services`, `.Services.Dummy`, `.ViewModels`, `.Views` (auch `.Views.<Gruppe>`), `.Controls`, `.Models`, `.Resources`, `.DesignData`. Code-Bezeichner Englisch, Dokumentation und sichtbare Texte Deutsch.

## Konventionen für die folgenden Pakete

### Dateien und Namen

| Was | Wohin / Name |
|---|---|
| Seite `HS-xx` | `ViewModels/<Key>ViewModel.cs` und `Views/<Key>View.xaml` (+ leeres `.xaml.cs`); optional `Views/<Gruppe>/…` mit Namespace `ApaTec.Hmi.Views.<Gruppe>`. `<Key>` = Schlüssel aus Navigation.md 5.1 / `PageKeys` (z. B. `HotGlueNordsonViewModel`, `HotGlueNordsonView`) |
| Modul `HM-xx` | `Controls/HM<nn>_<Name>.cs` (Custom Control: nur Dependency Properties) und Template-Stil in `Controls/HM<nn>_<Name>.Styles.xaml` (wird automatisch eingebunden, siehe „Controls einbinden“) |
| Dienst-Schnittstelle | `Services/Data/I<Name>Service.cs` (Konzept.md 6.6), Datenmodelle in `Models/` |
| Dummy-Dienst | `Services/Dummy/Dummy<Name>Service.cs` mit `[DummyService]` |
| Texte | `Resources/Strings/<Paket>.resx`, Schlüssel `<Bereich>_<Element>_<Eigenschaft>`, Englisch, PascalCase; seitenspezifisch mit Präfix (`HS07_…`, `HM08_…`) |
| Entwurfsdaten | `DesignData/<Name>DesignData.cs`; jedes ViewModel hat zusätzlich einen parameterlosen Konstruktor, jede View `d:DataContext="{d:DesignInstance Type=vm:<Key>ViewModel, IsDesignTimeCreatable=True}"` |

### Registrierung ohne gemeinsame Dateien

Es gibt keine Registrierungsdatei, die mehrere Agenten bearbeiten müssen:

- **Seite:** `[PageKey(PageKeys.HotGlueNordson)] public sealed partial class HotGlueNordsonViewModel : PageViewModelBase` – `PageRegistry` findet die Klasse per Reflection, `AddApaTecHmi` registriert sie transient, der `ViewLocator` findet `HotGlueNordsonView`. Pop-up-Seiten (HS-02, HS-03) erben von `PopupViewModelBase`.
- **Dialog:** `[DialogKey(DialogKeys.Input)] public sealed partial class InputPopupViewModel : PopupViewModelBase`; Aufruf über `IDialogService.ShowAsync<T>(DialogKeys.Input, parameter)`.
- **Dienst:** `[DummyService] public sealed class DummyXyzService : IXyzService` – wird als Singleton für alle Schnittstellen der Assembly registriert.
- Die 43 Schlüssel und ihre Metadaten (Route, Eltern, Art, Mindestrolle) sind fertig (`PageKeys.cs`, `PageCatalog.cs`); sie werden **nicht** geändert. Bis ein ViewModel existiert, zeigt die Seite eine Platzhalteransicht.
- Titel (`Nav_<Key>_Title`) und Brotkrümel (`Nav_<Key>_Crumb`) aller Seiten stehen bereits in `Strings.resx`. Dynamische Segmente und Objektkennung: ViewModel implementiert `IBreadcrumbTextProvider` und ruft nach Änderung `INavigationService.RefreshBreadcrumb()`.

### Navigation (Navigation.md 5)

```csharp
await navigation.NavigateToAsync(PageKeys.HotGluePressure);                       // Kachel/Funktionsleiste
await navigation.NavigateToAsync(PageKeys.MainDosers, new NavigationParameters("doserIndex", 2));
navigation.ReplaceParameter(new NavigationParameters("doserIndex", 1));            // Blättern, kein Verlaufseintrag
navigation.GoToAncestor(PageKeys.HotGlueNordson);                                  // Brotkrümel-Segment
```

- `History` ist der Zurück-Stapel nach A-44: nur Vorgängerseiten, **ohne** die aktuelle Seite; Tiefe 20; Sprung auf eine Seite im Stapel kürzt ihn und übernimmt gleichnamige Parameter der aktuellen Seite; HS-24 (Vollbild) wird nie gestapelt.
- Pop-up-Seiten und Dialoge liegen im Popup-Stapel (Tiefe 2, `PopupStack`, `IsModalOpen`); dahinter ist die Navigation gesperrt (`GoBack`/`NavigateToAsync` liefern `false`).
- Seiten sind in `OnNavigatedTo(object? parameter)` initialisierbar (auch beim Blättern); `OnNavigatedFrom()` gibt Zustand frei. Funktionsleistentasten befüllt das ViewModel in `FunctionBarItems` (höchstens 5, `FunctionBarItem`).
- ViewModels kennen keine Views und keine Fenster; Navigation nur über den Dienst.

### Designsystem verwenden

- **Farben** nur als `{DynamicResource Brush.…}` (sonst wirkt die Themenumschaltung nicht). **Maße, Schriften, Radien, Rahmen** als `{StaticResource Space.M}`, `Size.Touch.Default`, `Font.Size.Body`, `Radius.Control`, `Border.Thin` usw.; für `Margin`/`Padding` die Thickness-Tokens `Inset.XS/S/M/L/XL`, `Size.Content.Margin`. Textstile: `Text.Body`, `Text.Caption`, `Text.Value`, `Text.Title`, `Text.Metric`, `Text.Disabled`.
- **Symbole** als `Geometry`: `<Path Data="{StaticResource Icon.Home}" Stroke="{DynamicResource Brush.Text.Primary}" StrokeThickness="2" StrokeStartLineCap="Round" StrokeEndLineCap="Round" StrokeLineJoin="Round">` innerhalb einer `Viewbox` der Größe `Size.Icon.S/M/L` (Raster 24 × 24). Die Geometrien sind Platzhalter (Verfeinerung in M3).
- **Verbot von Literalen:** keine Hex-Farben, `Color=`, Pixelmaße (`Width`, `Height`, `Margin`, `Padding`, `FontSize`, `CornerRadius`, `BorderThickness` mit Zahl) und festen Texte in Views und Controls; Stern-Proportionen (`Width="3*"`, `"2.5*"`) sind erlaubt und werden vom Lint nicht gemeldet. Strichstärken von Symbolen und Linien: `StrokeThickness="{StaticResource Size.Icon.Stroke}"` (2) bzw. `Size.Icon.Stroke.Thick` (3); der frühere Umweg `{Binding Source={StaticResource Border.Medium}, Path=Left}` ist verboten (Lint). Fehlt ein Token, wird es in `Tokens.xaml` bzw. den Theme-Dateien ergänzt und in `Annahmen.md` vermerkt (Abstimmung über den Verwalter).
- **Zustände** nie nur über Farbe (Symbol, Text, Kontur; Designsystem 5). Touch-Ziele mindestens 48 px, Standard 64 px, Abstand mindestens 16 px.
- **Texte:** `Text="{res:Loc Schlüssel}"` mit `xmlns:res="clr-namespace:ApaTec.Hmi.Resources"`; im ViewModel `ILocalizationService.GetString(key)`.
- **Thema zur Laufzeit:** `IThemeService.SetTheme(ThemeMode.Dark)` tauscht das erste `MergedDictionary` (Theme) aus; deshalb steht das Theme in `App.xaml` immer an erster Stelle.

### Code-behind-Regel (A-73)

- Views, `MainWindow` und `App`: nur Konstruktor mit `InitializeComponent()`; keine Ereignisbehandler, keine Logik.
- Controls `HM<nn>_…`: Custom Controls; C# enthält ausschließlich Dependency-Property-Deklarationen mit CLR-Eigenschaften. Logik gehört ins ViewModel (`CommunityToolkit.Mvvm`: `[ObservableProperty]` auf Feldern, `[RelayCommand]`; Klassen `partial`).
- `check_design.py` prüft das Code-behind der Views automatisch.

### Controls einbinden

Ein Modul besteht aus `Controls/HM<nn>_<Name>.cs` (Custom Control, nur Dependency Properties; im statischen Konstruktor `DefaultStyleKeyProperty.OverrideMetadata`) und dem Template-Stil in **`Controls/HM<nn>_<Name>.Styles.xaml`** (ein `ResourceDictionary` mit implizitem Stil für den Control-Typ). Alle Dateien `Controls/*.Styles.xaml` (38 Module, HM-01 und HM-16 ff. teils mit Zusatzdateien) werden beim Start von `ControlResources.MergeAll` automatisch in die Anwendungsressourcen eingebunden; eine Sammeldatei gibt es nicht. UserControls für Komposita liegen ohne `.Styles` im Namen unter `Controls/` und werden direkt per Typ verwendet.

### Konventionen aus den Modulpaketen (HM-01 bis HM-38)

- **Typen-Dateien:** Aufzählungen und kleine Datenklassen eines Moduls (`PagerStyle`, `TileItem`, `PopupKind` …) liegen in `Controls/HM<nn>_<Name>.Types.cs`, Konverter in `HM<nn>_Converters.cs` bzw. `HM<nn>_<Zweck>Converter.cs`; alles im Namespace `ApaTec.Hmi.Controls`. Datenmodelle, die auch Dienste brauchen (`MessageEntry`, `MessageClass`), stehen in `Models/`.
- **Converter** sind `public sealed` (`IValueConverter`/`IMultiValueConverter`), ohne Zustand, mit Modulpräfix und werden im `.Styles.xaml` als Ressource `HM<nn>.<Zweck>` angelegt. Symbole per Token-Name: `HM06_IconKeyConverter` löst `Icon.*` über `Application.Current.TryFindResource` auf. Konverter und Typen sind keine „Logik“ im Sinne der Code-behind-Regel (A-73); `async`, Datei-, Netzwerk- und Thread-Zugriffe sind in `Controls/*.cs` verboten (`check_modules.py`).
- **Ressourcenschlüssel** im Stil-Dictionary tragen das Modulpräfix (`HM25.Row.Archive`, `HM07.Icon`); nie dieselbe Schlüsselbezeichnung in zwei Dictionaries, weil die Dictionaries in einem gemeinsamen `Application.Resources` landen und der spätere gewinnt. Sternbreiten, die als `GridLength` wiederverwendet werden, als `HM28.Star.3` o. Ä. ablegen.
- **`typeof` mit Nullable:** Dependency Properties vom Typ `T?` registrieren den Typ ohne `?` (`typeof(Brush)`, nicht `typeof(Brush?)`) – sonst CS8639; Wertetypen als `double?`/`int?` sind erlaubt.
- **Entwurfsdaten:** `DesignData/HM<nn>_DesignData.xaml` ist ein `ResourceDictionary` mit Beispielinstanzen (`x:Shared="False"`, Schlüssel `HM<nn>.Sample.<Fall>`) mit Werten aus den Moduldateien und Bildern; es wird **nicht** in die Laufzeitressourcen eingebunden (nur Designer/Galerie). Brauchen Beispiele Objektlisten, liegt daneben `HM<nn>_DesignData.cs` (statische Klasse im Namespace `ApaTec.Hmi.DesignData`).
- **Texte** der Module in den sechs Paketdateien `Resources/Strings/*.resx`, Schlüssel `HM<nn>_<Element>_<Eigenschaft>`; ein Schlüssel darf in nur einer Datei stehen. Bezeichner, die Controls als Voreinstellung zeigen, kommen aus `{res:Loc …}` im Template, nicht aus C#.
- **Namenskonflikte** vermeiden: keine Typnamen von WPF (`GroupStyle`, `ProgressBar`, `ToggleButton` …) in `ApaTec.Hmi.Controls` verwenden, wenn das Modul sie unqualifiziert braucht; Klassen tragen die Modulnummer (`HM10_ProgressBar`), Hilfstypen einen fachlichen Namen, der unter allen 38 Modulen eindeutig ist (sonst Doppeldefinition CS0101). Aufzählungsmember, die wie Framework-Typen heißen, vollqualifiziert ansprechen.
- **Lint und Modulprüfung** laufen nach jeder Änderung an Controls: `check_design.py` (Literale, Verweise, Light/Dark gleiche Schlüssel) und `check_modules.py` (Klasse, `.Styles.xaml` mit Stil für den Typ, `DesignData`).

## Hauptfenster und Rahmen (Erweiterungspunkte für HM-01 bis HM-06)

`MainWindow.xaml` ist ein proportionales Grid nach Designsystem 3.2 (Spalten 3\* : 37\*, Zeilen 4\* : 3\* : 34\* : 4\*, Tokens `Size.*`), DataContext ist `ShellViewModel`. Platzhalter-`ContentControl` (Stil `Frame.Placeholder`), die der Rahmen-Agent durch das jeweilige Modul ersetzt:

| Bereich | Name im XAML | Modul | Bindbare `ShellViewModel`-Eigenschaften und -Befehle |
|---|---|---|---|
| Seitenleiste (Spalte 0, volle Höhe) | `SidebarHost` | HM-01 | `UserInitials`, `UserName`, `UserRoleText`, `UnreadMessageCount`, `CurrentSidebarItemId` (`SidebarItemIds`), `CanGoBack`; `HomeCommand`, `SettingsCommand`, `MessagesCommand`, `BackCommand`, `UserCommand`, `NavigateCommand(pageKey)` |
| Kopfzeile (Zeile 0) | `HeaderHost` | HM-02 mit HM-03 | `OperatingMode`, `Now`, `ShowMessageLine`, `MessageNumber`, `MessageText`, `MessageClass`, `AdditionalMessageCount`; Meldezeile: `MessagesCommand`; Spaltenverhältnis `Size.Header.Col.*` (12\* : 13\* : 6\* : 4\*) |
| Brotkrümel (Zeile 1) | `BreadcrumbHost` | HM-04 | `Breadcrumb` (`IReadOnlyList<BreadcrumbItem>`), `NavigateToAncestorCommand(pageKey)` |
| Kennzahlen (Zeile 1) | `SpeedHost`, `AngleHost` | HM-05 | `MachineSpeed` (öffnet per `NavigateCommand` mit `PageKeys.MachineSpeed` das Pop-up), `MachineAngle` |
| Inhaltsbereich (Zeile 2) | `ContentHost` | – | `CurrentPage`; View per `ViewLocator`, Rand `Size.Content.Margin` |
| Funktionsleiste (Zeile 3) | `FunctionBarHost` | HM-06 | `FunctionBarItems` (aus der aktuellen Seite) |
| Pop-up-Ebene | `PopupHost` | HM-14 | `CurrentPopup`, `IsModalOpen`; Scrim `Brush.Scrim` |

`ShowFrame` ist im Vollbild (HS-24) false: Seitenleiste, Brotkrümel, Kennzahlen und Funktionsleiste verschwinden, Kopfzeile und Inhalt überspannen die volle Breite. Vorerst tragen Meldung, Betriebsart und Kennzahlen Entwurfswerte (`DesignData/ShellDesignData.cs`, A-85). Für die Bindung an Maschinendaten kommen `IMachineStatusService` und `IMessageService` (Konzept.md 6.6) in das Rahmenpaket M2-04; `ShellViewModel` ist die einzige Stelle, die dafür geändert wird. Die Pop-up-Ebene zeigt bis zu HM-14 eine Platzhalteransicht.

## Paralleles Arbeiten ohne Dateikonflikte

- Jeder Agent legt **nur eigene Dateien** an (eigene ViewModels, Views, Controls, `Strings/<Paket>.resx`, Dienst-Schnittstellen und Dummy-Dienste, Entwurfsdaten). Namen enthalten den Seiten- bzw. Modulschlüssel, daher kollidieren sie nicht.
- **Gemeinsame Dateien werden nicht von Paketen bearbeitet:** `PageKeys.cs`, `PageCatalog.cs`, `Strings.resx`, `Tokens.xaml`, `Theme.*.xaml`, `Icons.xaml`, `Controls.Base.xaml`, `App.xaml`, `MainWindow.xaml`, `ShellViewModel.cs`, `Annahmen.md`. Bedarf (neues Token, Symbol, Rahmeneigenschaft) wird dem Verwalter gemeldet und im Zusammenführungsschritt eingetragen; Annahmen eines Pakets stehen in dessen Bericht und werden vom Verwalter nach `Annahmen.md` übernommen.
- Neue Dienste und Dummy-Dienste werden nicht in einer Registrierung eingetragen, sondern per Attribut gefunden. Dasselbe gilt für Seiten und Dialoge.
- Vor der Abgabe: Build (0 Warnungen) und `tools/check_design.py` müssen laufen; ein Paket, das nicht baut, wird nicht übernommen.

## Entwurfsentscheidungen und Annahmen

A-81 bis A-87 in `docs/00_Plan/Annahmen.md` (Build-Umgebung, Pakete, Zusatz-Tokens, Architektur, Hauptfenster, Strichstärken-Tokens, Modulprüfung, Integrationsregeln). Der Dienst `IClockService` läuft in der Dummy-Variante mit der Systemzeit; `ISettingsService` hält Thema und Sprache nur im Speicher.
