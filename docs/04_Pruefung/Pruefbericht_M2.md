# Prüfbericht Meilenstein 2

- Gegenstand: Gesamtprüfung Meilenstein 2 (WPF-Lösung `src/`, .NET 8, Cloud), Stand Branch-HEAD `44ff17d` („Seiten, Dienste und Navigation nach Prüfung nachgebessert (Fix B)“), Arbeitsbaum ohne lokale Änderungen.
- Prüfdatum: 2026-11-04.
- Prüfer: unabhängiger Gesamt-Prüf-Agent (hat die Erstellung und die Fixes nicht gesehen), nach `Agent.md` Abschnitte 7, 8 und 9.
- Es wurde außer diesem Bericht keine Datei geändert. Build und Skripte liefen auf einer Kopie von `src/` im Scratchpad (`/tmp/claude-0/-home-user-refactored-pancake/654f0234-74a7-5806-871e-2cb9095687b7/scratchpad/chk/src`), Hilfsskripte (Literal-, Code-behind-, Bindungs-, Rückverfolgungsprüfung) liegen im selben Scratchpad.

## 1 Zusammenfassung und Endurteil

**Endurteil: BESTANDEN** (mit Auflagen, siehe Abschnitt 8 und 10).

- Build: **0 Fehler, 0 Warnungen** (`--no-incremental`, `TreatWarningsAsErrors`). `check_design.py`, `check_modules.py` (38/38), `check_pages.py` (43/43 Seiten, 10/10 Dialoge) und `check_icons.py` bestehen; `xmllint` über alle 161 `.xaml`/`.resx` ohne Fehler.
- Code-behind: alle 57 `*.xaml.cs` enthalten ausschließlich `InitializeComponent()`. In `Views/`, `Controls/` und `MainWindow.xaml` stehen keine Hex-Farben, Pixelmaße oder festen Texte; nur 20 Einheitensymbole (`%`, `g`, `s`, `1/min`) sind als `Unit="…"` fest geschrieben (Befund B-04, niedrig).
- Alle 17 stichprobenartig geprüften Fixes (Abschnitt 5) sind im Code **belegt behoben**; die zugehörigen Bindungen View ↔ ViewModel stimmen.
- Rückverfolgung: Alle 43 HS und 38 HM haben View/ViewModel bzw. Control/Stil/Entwurfsdaten (Abschnitt 6). Von 1.004 Prüfpunkten sind 1.004 in den Seiten-/Moduldateien noch mit „offen“ markiert (die Dateien wurden in M2 nicht fortgeschrieben, B-03); die Auswertung in Abschnitt 6 ordnet sie Gruppen zu: 782 Prüfpunkte (A Inhalt/Funktion/Navigation/Berechtigung) und 36 (E Tokens/Texte) sind **statisch belegt**, 73 (B Layout/Bildabgleich) sind **offen für Meilenstein 3**, die 52 Touch-Punkte (C) und 61 Kontrast-/Zweiter-Kanal-Punkte (D) sind in den Größen und Symbolen statisch belegt, ihre Wirkung ist **offen für Meilenstein 3**. **Nicht umgesetzt**: keiner der Prüfpunkte vollständig; eine Abweichung von der Modulzuordnung (B-01: `HM-20` Detail in HS-11/HS-19) und sechs bewusste Platzhalter (Abschnitt 6.4).
- Verbleibende Befunde: **0 hoch, 0 mittel, 6 niedrig** (B-01 bis B-06, Abschnitt 8). Sie verhindern den Abschluss nicht, B-01 bis B-03 sind vor oder zu Beginn von Meilenstein 3 zu erledigen.
- `src_Data` unverändert (`git diff f168526 -- src_Data` leer, 0 Zeilen).
- `Annahmen.md`: A-01 bis A-98 eindeutig, aufsteigend, **eine Lücke: A-94 fehlt** (B-02); alle in Dokumenten und Code genannten A-Nummern sind definiert.

## 2 Methodik (Cloud: nur Build und statische Prüfung)

Die Anwendung kann in der Cloud nicht gestartet werden (WPF, Windows). Geprüft wurde daher:

1. **Build** der Kopie von `src/` mit `DOTNET_ROOT=/opt/dotnet8 PATH=/opt/dotnet8:$PATH dotnet build ApaTec.Hmi.sln -p:EnableWindowsTargeting=true --no-incremental`. Der XAML-Compiler prüft dabei Typen, Eigenschaften und Ressourcenschlüssel der Markup-Erweiterungen; **Bindungspfade (`{Binding …}`) prüft er nicht**.
2. **Projektskripte** `check_design.py`, `check_modules.py`, `check_pages.py`, `check_icons.py` und `xmllint --noout` über alle `.xaml` und `.resx`.
3. **Eigene Skripte** (unabhängig von den Projektskripten): Code-behind je `*.xaml.cs` (Reduktion auf Anweisungen, erwartet genau `InitializeComponent()`), Literalsuche (Hex, Pixelmaße ohne Sternproportion, feste Texte in `Text`, `Content`, `Header`, `ToolTip`, `Title`, `Label`, `Caption`, `HelpText`, `Unit`), Bindungsprüfung (erste Pfadsegmente aller `{Binding …}` je View gegen die Mitglieder des ViewModels einschließlich `[ObservableProperty]` und `[RelayCommand]`), Modul-Rückverfolgung (HM-Klassen je View, transitiv über die Stil-Dateien), Konsistenz der Annahmen-IDs und Verweise.
4. **Stichprobe im Code** (Abschnitt 5): 17 Fixes im Quelltext gelesen, jeweils mit den Bindungen der zugehörigen View.
5. **Gruppenbildung der Prüfpunkte** (Abschnitt 6): Die 1.004 Prüfpunkt-Zeilen (775 HS, 229 HM) wurden anhand des Prüfungstitels automatisch in die Gruppen A bis E eingeordnet. Die Zuordnung „statisch belegt“ gilt auf Gruppenebene (Build, Skripte, Stichprobe, Struktur der Views); **kein Einzelpunkt-Code-Review aller 1.004 Zeilen** – das ist die Grenze dieser Prüfung. Die Laufzeitbestätigung folgt in Meilenstein 3.

Status-Begriffe: **statisch belegt** (aus Build, Skript oder Code ableitbar), **offen für Meilenstein 3** (nur visuell oder zur Laufzeit prüfbar), **nicht umgesetzt**.

## 3 Ergebnisse der Skripte

| Prüfung | Aufruf | Ergebnis |
|---|---|---|
| Build | `dotnet build ApaTec.Hmi.sln … --no-incremental` | `0 Warning(s)`, `0 Error(s)` |
| Designsystem | `python3 tools/check_design.py` | **BESTANDEN**: 162 XML-Dateien; Themes Light/Dark je 42 Brush-Tokens (Tabelle 10.1: 42); 57 geforderte Tokens, 75 vorhanden; 68 Symbole (Designsystem 6/6.1: 68); 323 Ressourcenverweise aufgelöst; 57 Code-behind-Dateien; 97 XAML-Dateien ohne Literale; 609 `Loc`-Schlüssel in XAML, 1.157 Ressourcen; 43 `PageKeys` |
| Module | `python3 tools/check_modules.py` | **38/38 Module OK** (Klasse, Stil, Entwurfsdaten, kein Logik-Code), Einbindung der Stile automatisch |
| Seiten | `python3 tools/check_pages.py` | **43/43 Seiten OK**, **10/10 Dialoge OK** (ViewModel, View, Code-behind, `Loc`-Schlüssel, Titel/Brotkrümel, Literale) |
| Symbole | `python3 tools/check_icons.py` | **BESTANDEN**: 68 definiert, 65 verwendet, 3 Reserve (laut Designsystem 6) |
| XML | `xmllint --noout` über 161 `.xaml`/`.resx` | ohne Ausgabe (wohlgeformt) |
| Code-behind (eigen) | Skript | 57 Dateien, 0 Abweichungen |
| Literale (eigen) | Skript | `Views/**`, `Controls/*.xaml`, `MainWindow.xaml`: 0 Hex, 0 Pixelmaße; feste Texte nur `Unit="%"` (8), `"g"` (8), `"s"` (2), `"1/min"` (2); Formatketten (`StringFormat`, geschützte Leerzeichen) sind keine Texte |
| Bindungen (eigen) | Skript | alle Views mit Entwurfsdaten-Kontext: für alle Bindungen auf Seitenebene existiert das ViewModel-Mitglied; die 10 gemeldeten Views (CheckWeigher, DoserOverview, FeederCarton, FeederPaper, HotGlueParameters, MachineSpeed, ProductionCounter, Production, ScaleCalibration, SystemInfo) binden in `DataTemplate`/Stilen an Listenelement-Typen und wurden stichprobenartig (FeederCarton, MachineSpeed, HotGlueParameters) bestätigt; die übrigen 7 nur über das erfolgreiche Kompilieren der Eigenschaften, nicht der Pfade |
| `src_Data` | `git diff f168526 -- src_Data` | leer |
| Verfolgte Dateien | `git ls-files src` | 501 (keine `bin/`, `obj/`) |

## 4 Zählwerte

| Größe | Wert | Anmerkung |
|---|---|---|
| Dateien unter `src/` (verfolgt) | **501** | 333 `.cs`, 141 `.xaml`, 20 `.resx`, 4 `.py`, 1 `.sln`, 1 `.csproj`, 1 `.md` |
| Codezeilen (`.cs` + `.xaml`) | 35.419 | |
| Controls (Module `HM-01` bis `HM-38`) | **38** Control-Klassen (`HM<nn>_<Name>`) | dazu 39 Stil-Dateien `*.Styles.xaml` (HM-01 mit Zusatzstil `HM01_SidebarButton`), 38 Entwurfsdaten-Dateien `HM<nn>_DesignData.xaml` (+ 5 `.cs`) |
| Views | **55** XAML-Views | 43 Seiten-Views (HS-01 bis HS-43), 3 weitere Pop-up-Views im Ordner `Views/` (Zeitplan-Eintrag, Suche, Nachdosierer-Hinweise), 2 Platzhalter-Views, 7 Dialog-Views in `Views/Dialogs/` (Eingabe, Bestätigung, Filter, Datei/Ergebnis, Sprache, Benutzer, Rezept) |
| ViewModels | **62** `*ViewModel.cs` (83 Dateien in `ViewModels/`) | 43 Seiten-ViewModels mit `[PageKey]`, 10 Dialog-ViewModels mit Dialogschlüssel, dazu `ShellViewModel`, Platzhalter-VMs, Basisklassen |
| Dienste | **33** Schnittstellen (27 Daten-, 6 Rahmendienste) | 30 Dummy-Dienste (`[DummyService]`), 3 echte Dienste (`DialogService`, `LocalizationService`, `ThemeService`) und `NavigationService` |
| Dialoge | **10** Dialogschlüssel (Input, Search, User, Language, Recipe, Confirmation, ScheduleEntry, Filter, FileResult, PostDoserHints) | zusätzlich die Pop-up-Seiten HS-02 und HS-03 im Seitenregister |
| Ressourcenschlüssel | **1.157** Texte in 20 `.resx` (alle eindeutig, 0 Duplikate) | dazu 576 `x:Key` in XAML (Tokens 75, Themes je 42, Symbole 68, Basis 8, Control-Stile und Konverter) |
| Seitenschlüssel / Modelle | 43 `PageKeys`; 31 Dateien in `Models/` | |
| Prüfpunkte in `docs/03_HMI-Konzept` | **1.004** (775 HS, 229 HM) | alle noch „offen“ |

## 5 Wiederholungsprüfung der Befunde (Stichprobe im Code)

| Nr | Befund (aus den Vorprüfungen) | Status | Beleg (Datei, Fundstelle) |
|---|---|---|---|
| 1 | DialogService: Fortsetzung des Aufrufers lief inline im `Closed`-Ereignis | **behoben** | `Services/DialogService.cs` Z. 30: `TaskCreationOptions.RunContinuationsAsynchronously`; Z. 33 `TryOpenPopup` (Navigationsdienst registriert seinen Closed-Handler zuerst), Z. 40 Ergebnis-Handler danach: `IsModalOpen` ist beim Ergebnis schon `false` |
| 2 | NavigationService: Rollenverlust ließ geschützte Seite stehen | **behoben** | `Navigation/NavigationService.cs` Z. 29 Abo `SessionChanged`, Z. 200 `OnSessionChanged`: schließt Pop-ups, entfernt geschützte Verlaufseinträge, wechselt zur Elternseite bzw. HS-01 |
| 3 | Leave-Hook (Verwerfen-Rückfrage) fehlte | **behoben** | `NavigationService.cs` Z. 85 `CanLeaveAsync` bei `NavigateToAsync`, Z. 180–195 `Guard` für Zurück/Brotkrümel/Home/Einstellungen; `PageViewModelBase` Z. 41–46 (`HasLeaveGuard`, `CanLeaveAsync`); Verwendung `ViewModels/CamsViewModel.cs` Z. 144/146. Hinweis: `Guard` meldet „angenommen“ (true), bevor die Rückfrage entschieden ist (kein Fehler) |
| 4 | HM-06: Überlauf „Mehr“, Vorlage je Kind, rechtsbündige Gruppe | **behoben** | `Controls/HM06_FunctionBar.Styles.xaml` Z. 132/181/196 (`HM06.Template.Action/State/Paging`), Z. 214–222 Auswahl nach `Kind`, Z. 255 `MoreHost` mit Popup, Z. 290 `Trailing`; `HM06_Converters.cs` Z. 44 `MaxLeftItems = 5`, Sichten Main/Overflow/Trailing. Hinweis: `IsTrailing` wird von keinem ViewModel gesetzt (Funktion vorhanden, ungenutzt) |
| 5 | Kultur de-DE (Dezimalkomma, Datum) | **behoben** | `Program.cs` Z. 16–25: `CurrentCulture`, `DefaultThread*`, `FrameworkElement.LanguageProperty.OverrideMetadata`; `Services/LocalizationService.cs` Z. 19, 30, 62–68; `DummySettingsService` `Language = "de-DE"`. Laufzeitbestätigung offen (M3-01) |
| 6 | HS-16: Eingabefelder nicht verdrahtet | **behoben** | `Views/ClosingMachineView.xaml` Z. 39–106: `Command="{Binding EditValueCommand}"` + `CommandParameter="{x:Static m:ClosingField.…}"`, `EditHeadGlueStart/End/DurationCommand`, `ToggleHeadGlueCommand`, `ToggleShakerCommand`; im ViewModel `EditValueAsync`, `EditHeadGlueStartAsync` (Z. 181), `ToggleHeadGlueAsync` (Z. 190), `ToggleShakerAsync` (Z. 219) – alle Befehlsnamen vorhanden |
| 7 | HS-17: nicht verdrahtet | **behoben** | `Views/ClosingMotorView.xaml` Z. 33–52: `EditCommand="{Binding EditClosed/EditOpen/EditScrewCommand}"`; `ClosingMotorViewModel` `EditClosedAsync/EditOpenAsync/EditScrewAsync` (`[RelayCommand]`) |
| 8 | HS-18: nicht verdrahtet | **behoben** | `Views/ClosingWeightCorrectionView.xaml` Z. 23–29 (`EditTargetWeight/EditNominal/EditActual/Trigger/AdjustCommand`) ↔ `ClosingWeightCorrectionViewModel` Z. 96–183; Control `HM22_WeightCorrectionTable.Styles.xaml` Z. 37–38, 89–93 ruft sie auf |
| 9 | HS-22: Schalter ohne Zustände Ausstehend/Berechtigung | **behoben** | `Views/HeatersView.xaml` Z. 75–84 bindet `ToggleZone/ToggleMonitorCommand`, `IsZonePending`, `IsMonitorPending`, `IsAuthorized`; `ViewModels/HeatersViewModel.cs` Z. 20–80 (Eigenschaften, Befehle), Z. 139–181 (Pending gesetzt und im `finally` zurückgenommen, Rückfall bei Ablehnung); `HM28_HeatZoneRow.Styles.xaml` Z. 44–83 reicht an `HM08` durch |
| 10 | HM-16: „Reserviert“ nicht antippbar, Hilfetext fehlte | **behoben** | `HM16_TileNavigation.Styles.xaml` Z. 41 (`AutomationProperties.HelpText`), Z. 62/154 (Reserviert-Text, gestrichelt), Z. 195 Befehl für alle Kacheln; `SettingsViewModel.cs` Z. 85–96 (`OpenTileAsync` zeigt `DisabledReason` in der Meldezeile), Z. 175, 184 |
| 11 | HS-36: Betriebsart „Service“ nicht gesetzt | **behoben** | `ViewModels/ServiceViewModel.cs` Z. 110–125 (beim Betreten `SetOperatingMode(Service)`, beim Verlassen wiederhergestellt); `DummyMachineStatusService.cs` Z. 20 löst `Changed` aus; `ShellViewModel.cs` Z. 139, 268 aktualisiert die Kopfzeile |
| 12 | FileResult: Fortschritt/Sperre beim Ablauf | **behoben** | `FileResultDialogViewModel.cs` Z. 27 `IsBusy` mit `NotifyCanExecuteChangedFor(AcceptCommand)`, Z. 67 `CanAccept => !IsBusy`, Z. 84–98 `RunAsync` (IsBusy, `Busy`-Rückruf, Ergebnis im selben Pop-up); `FileResultDialogView.xaml` Z. 13 `IsBusy="{Binding IsBusy}"` |
| 13 | Benutzer-Pop-up über `RequestRoleAsync` | **behoben** | `Services/Dummy/DummyUserSession.cs` Z. 37–52 (öffnet `DialogKeys.User` mit `requiredRole`, löst `IDialogService` erst zur Laufzeit auf, Zyklus vermieden); `NavigationService.cs` Z. 73; Aufrufer z. B. `ClosingMachineViewModel` Z. 283; `UserDialogViewModel` Z. 37–45, 70–95 liest `requiredRole`, meldet über `SignIn/SignOut` an |
| 14 | HM-38: Suchzeile ohne Texteingabe/Kreuz | **behoben** | `HM38_SearchDialog.Styles.xaml` Z. 106–126, 187 (`EditTextCommand`, `ClearTextCommand`, Kreuz `Icon.Close`; ohne Befehl entfällt die Fläche); `Views/SearchPopupView.xaml` Z. 21 bindet beide; `SearchPopupViewModel.cs` Z. 90 `EditTextAsync` (öffnet `DialogKeys.Input`, Art Text), Z. 105 `ClearText` |
| 15 | HM-13: Zeitbereich | **behoben** | `ViewModels/InputDialogViewModel.cs` Z. 100–103 (Anzeige aktueller Zeit), Z. 277–321 (Stunden < 24, Minuten < 60, Min/Max in Minuten, Fehlertext `Dialog_Input_Range` im Format HH:MM) |
| 16 | HS-31: Jog – Gründe für Sperre | **behoben** | `ManualOperationViewModel.cs` Z. 223–229, 305–325: Hinweis `HS31_NotManual_Text` bzw. `Msg_PermissionRequired` + `RequestRoleAsync`; Tasten per `HM07_PressBehavior.PressCommand/ReleaseCommand` (`ManualOperationView.xaml` Z. 36–61); `StopJog` bei Verlassen |
| 17 | HS-32: Geber setzen – Gründe, Halten | **behoben** | `EncoderSettingViewModel.cs` Z. 107–165: `CanSet`, `BeginSetAsync` (Grund `HS32_NoEmergencyStop_Text`/Berechtigung), `SetEncoder` mit `CanExecute`; `EncoderSettingView.xaml` Z. 45–50 (`TriggerMode="Hold"`, `PressCommand`, `HoldCompletedCommand`); `HM07_PressBehavior.cs` Z. 139–140 beachtet `CanExecute`; `NotifyCanExecuteChanged` Z. 223 |
| 18 | `Annahmen.md`: Verweise und IDs | **dokumentiert / offen** | A-94 fehlt (B-02); alle Verweise lösen auf |
| 19 | HM-20 (Detail) in HS-11/HS-19 | **offen** (neu, B-01) | `Views/DoserOverviewView.xaml` Z. 14 nutzt nur `CardMode="Compact"`; `MainDosersView.xaml`/`PostDoserView.xaml` enthalten kein `HM20_DosingCard` |

## 6 Rückverfolgung HS/HM ↔ Code

### 6.1 Gruppen der Prüfpunkte und Status

| Gruppe | Inhalt (Titel des Prüfpunkts) | Status | Begründung |
|---|---|---|---|
| A | Inhalt, Funktion, Navigation, Berechtigung, Zugang, Brotkrümel, Funktionsleiste, Pop-ups, Einheiten, Zustände | **statisch belegt** (Ablauf zur Laufzeit zusätzlich in M3) | Build, `check_pages`/`check_modules` (ViewModel, View, Titel, Schlüssel), Elementbindungen, Stichprobe Abschnitt 5 |
| B | Layout, Raster, Bildabgleich, Bildabdeckung, Aufbau, Anordnung | **offen für Meilenstein 3** | rein visuell; Grid-Proportionen sind angelegt, der Abgleich mit den Bildern ist nur unter Windows möglich |
| C | Touch-Ziele | Größen **statisch belegt** (Tokens `Size.Touch.*` in den Stilen); Bedienung am Gerät **offen für Meilenstein 3** | |
| D | Zweiter Kanal, Farbe nur für Status, Kontrast, Hell/Dunkel | Symbol/Text je Zustand **statisch belegt**; Wirkung (Graustufen, Kontrast, Themenwechsel) **offen für Meilenstein 3** | |
| E | Tokens und Texte | **statisch belegt** (`check_design`, Literalsuche) | |

Die Spalten „A…E“ der Tabellen nennen die Zahl der Prüfpunkte je Gruppe.

Summen: HS 775 (A 594, B 52, C 41, D 52, E 36), HM 229 (A 188, B 21, C 11, D 9), zusammen 1.004 (A 782, B 73, C 52, D 61, E 36).

### 6.2 Seiten HS-01 bis HS-43

Die Spalte „Module“ nennt die Controls, die die View direkt einsetzt; Rahmenmodule (HM-01 bis HM-06 in `MainWindow.xaml`), Pop-up-Rahmen und Eingabe-Pop-up (HM-13/HM-14 über `DialogService`) und die Module der Funktionsleiste (HM-07, HM-08, HM-19) kommen über den Rahmen bzw. die Dialoge hinzu. Entwurfsdaten: „–“ = Beispielwerte über den parameterlosen Konstruktor mit Dummy-Dienst.

| HS | PageKey | View | ViewModel | Module (direkt) | Entwurfsdaten | Prüfpunkte | A / B / C / D / E | Hinweis |
|---|---|---|---|---|---|---|---|---|
| HS-01 | `Production` | `Views/ProductionView.xaml` | `ViewModels/ProductionViewModel.cs` | HM-05, HM-07, HM-08, HM-11, HM-15, HM-16 | – | 23 | A 19 / B 1 / C 1 / D 1 / E 1 |  |
| HS-02 | `ProductionCounter` | `Views/ProductionCounterView.xaml` | `ViewModels/ProductionCounterViewModel.cs` | HM-05, HM-07, HM-14, HM-33 | – | 14 | A 10 / B 1 / C 1 / D 1 / E 1 | Pop-up (HM-14 über Popup-Ebene) |
| HS-03 | `MachineSpeed` | `Views/MachineSpeedView.xaml` | `ViewModels/MachineSpeedViewModel.cs` | HM-12, HM-14 | – | 15 | A 11 / B 1 / C 1 / D 1 / E 1 | Pop-up (HM-14 über Popup-Ebene) |
| HS-04 | `Settings` | `Views/SettingsView.xaml` | `ViewModels/SettingsViewModel.cs` | HM-15, HM-16 | – | 20 | A 15 / B 2 / C 1 / D 1 / E 1 | Fix: Reserviert antippbar |
| HS-05 | `FeederPaper` | `Views/FeederPaperView.xaml` | `ViewModels/FeederPaperViewModel.cs` | HM-09, HM-11, HM-12, HM-15, HM-27 | – | 20 | A 16 / B 1 / C 1 / D 1 / E 1 |  |
| HS-06 | `FeederCarton` | `Views/FeederCartonView.xaml` | `ViewModels/FeederCartonViewModel.cs` | HM-08, HM-11, HM-12, HM-15, HM-31 | – | 21 | A 17 / B 1 / C 1 / D 1 / E 1 |  |
| HS-07 | `HotGlueNordson` | `Views/HotGlueNordsonView.xaml` | `ViewModels/HotGlueNordsonViewModel.cs` | HM-07, HM-08, HM-09, HM-10, HM-11, HM-12, HM-15, HM-27 | HotGlueDesignData.cs | 24 | A 19 / B 1 / C 1 / D 2 / E 1 |  |
| HS-08 | `HotGlueParameters` | `Views/HotGlueParametersView.xaml` | `ViewModels/HotGlueParametersViewModel.cs` | HM-12, HM-15, HM-28 | HotGlueDesignData.cs | 19 | A 14 / B 1 / C 1 / D 2 / E 1 |  |
| HS-09 | `HotGluePressure` | `Views/HotGluePressureView.xaml` | `ViewModels/HotGluePressureViewModel.cs` | HM-11, HM-12, HM-15 | HotGlueDesignData.cs | 20 | A 16 / B 0 / C 1 / D 2 / E 1 |  |
| HS-10 | `HotGlueSchedule` | `Views/HotGlueScheduleView.xaml` | `ViewModels/HotGlueScheduleViewModel.cs` | HM-27, HM-29 | HotGlueDesignData.cs | 24 | A 18 / B 2 / C 1 / D 2 / E 1 |  |
| HS-11 | `MainDosers` | `Views/MainDosersView.xaml` | `ViewModels/MainDosersViewModel.cs` | HM-07, HM-08, HM-09, HM-10, HM-11, HM-12, HM-15, HM-17, HM-27 | – | 22 | A 18 / B 2 / C 1 / D 1 / E 0 | HM-20 Detail nicht eingesetzt (B-01) |
| HS-12 | `MainDoserMotor` | `Views/MainDoserMotorView.xaml` | `ViewModels/MainDoserMotorViewModel.cs` | HM-17, HM-21 | – | 17 | A 13 / B 2 / C 1 / D 1 / E 0 |  |
| HS-13 | `CheckWeigher` | `Views/CheckWeigherView.xaml` | `ViewModels/CheckWeigherViewModel.cs` | HM-05, HM-07, HM-12, HM-15 | – | 24 | A 18 / B 2 / C 1 / D 2 / E 1 |  |
| HS-14 | `SingleWeights` | `Views/SingleWeightsView.xaml` | `ViewModels/SingleWeightsViewModel.cs` | HM-05, HM-37 | – | 18 | A 13 / B 2 / C 1 / D 1 / E 1 |  |
| HS-15 | `Trend` | `Views/TrendView.xaml` | `ViewModels/TrendViewModel.cs` | HM-26 | – | 16 | A 12 / B 2 / C 0 / D 1 / E 1 |  |
| HS-16 | `ClosingMachine` | `Views/ClosingMachineView.xaml` | `ViewModels/ClosingMachineViewModel.cs` | HM-08, HM-12, HM-15, HM-24, HM-27 | – | 22 | A 17 / B 2 / C 1 / D 1 / E 1 | Fix: Eingabebefehle gebunden |
| HS-17 | `ClosingMotor` | `Views/ClosingMotorView.xaml` | `ViewModels/ClosingMotorViewModel.cs` | HM-21, HM-27 | – | 21 | A 16 / B 2 / C 1 / D 1 / E 1 | Fix: Eingabebefehle gebunden |
| HS-18 | `ClosingWeightCorrection` | `Views/ClosingWeightCorrectionView.xaml` | `ViewModels/ClosingWeightCorrectionViewModel.cs` | HM-15, HM-22, HM-27 | – | 22 | A 17 / B 2 / C 1 / D 1 / E 1 | Fix: Eingabebefehle gebunden |
| HS-19 | `PostDoser` | `Views/PostDoserView.xaml` | `ViewModels/PostDoserViewModel.cs` | HM-07, HM-08, HM-09, HM-10, HM-11, HM-12, HM-15, HM-27 | – | 21 | A 17 / B 2 / C 1 / D 1 / E 0 | HM-20 Detail nicht eingesetzt (B-01) |
| HS-20 | `PostDoserMotor` | `Views/PostDoserMotorView.xaml` | `ViewModels/PostDoserMotorViewModel.cs` | HM-21 | – | 15 | A 11 / B 2 / C 1 / D 1 / E 0 |  |
| HS-21 | `PostDoserWeightCorrection` | `Views/PostDoserWeightCorrectionView.xaml` | `ViewModels/PostDoserWeightCorrectionViewModel.cs` | HM-07, HM-15, HM-22, HM-27 | – | 18 | A 14 / B 2 / C 1 / D 1 / E 0 |  |
| HS-22 | `Heaters` | `Views/HeatersView.xaml` | `ViewModels/HeatersViewModel.cs` | HM-07, HM-27, HM-28 | Heaters_DesignData.cs | 20 | A 14 / B 3 / C 1 / D 1 / E 1 | Fix: Pending/Auth |
| HS-23 | `Regulation` | `Views/RegulationView.xaml` | `ViewModels/RegulationViewModel.cs` | HM-35 | Regulation_DesignData.cs | 18 | A 14 / B 2 / C 1 / D 1 / E 0 |  |
| HS-24 | `ScreenCleaning` | `Views/ScreenCleaningView.xaml` | `ViewModels/ScreenCleaningViewModel.cs` | HM-10, HM-27 | ScreenCleaning_DesignData.cs | 14 | A 9 / B 2 / C 1 / D 1 / E 1 | Vollbild ohne Rahmen |
| HS-25 | `Cams` | `Views/CamsView.xaml` | `ViewModels/CamsViewModel.cs` | HM-07, HM-09, HM-11, HM-12, HM-18, HM-24 | Cams_DesignData.cs | 18 | A 15 / B 1 / C 1 / D 1 / E 0 |  |
| HS-26 | `CamOverview` | `Views/CamOverviewView.xaml` | `ViewModels/CamOverviewViewModel.cs` | HM-23 | Cams_DesignData.cs | 14 | A 9 / B 2 / C 1 / D 1 / E 1 |  |
| HS-27 | `ScaleCalibration` | `Views/ScaleCalibrationView.xaml` | `ViewModels/ScaleCalibrationViewModel.cs` | HM-07, HM-11, HM-15, HM-17, HM-18, HM-27 | ScaleCalibration_DesignData.cs | 21 | A 17 / B 0 / C 1 / D 2 / E 1 |  |
| HS-28 | `PackRegister` | `Views/PackRegisterView.xaml` | `ViewModels/PackRegisterViewModel.cs` | HM-27, HM-32 | PackRegister_DesignData.cs | 18 | A 14 / B 0 / C 1 / D 2 / E 1 |  |
| HS-29 | `ProductionStatistics` | `Views/ProductionStatisticsView.xaml` | `ViewModels/ProductionStatisticsViewModel.cs` | HM-18, HM-26 | ProductionStatistics_DesignData.cs | 15 | A 11 / B 0 / C 1 / D 2 / E 1 |  |
| HS-30 | `ManualSelection` | `Views/ManualSelectionView.xaml` | `ViewModels/ManualSelectionViewModel.cs` | HM-16 | – | 15 | A 11 / B 1 / C 1 / D 1 / E 1 |  |
| HS-31 | `ManualOperation` | `Views/ManualOperationView.xaml` | `ViewModels/ManualOperationViewModel.cs` | HM-07, HM-09, HM-11, HM-12, HM-17, HM-19, HM-27 | – | 22 | A 18 / B 1 / C 1 / D 1 / E 1 | Fix: Jog-Gründe |
| HS-32 | `EncoderSetting` | `Views/EncoderSettingView.xaml` | `ViewModels/EncoderSettingViewModel.cs` | HM-07, HM-09, HM-11, HM-17, HM-19, HM-27 | – | 19 | A 15 / B 1 / C 1 / D 1 / E 1 | Fix: Geber-Gründe |
| HS-33 | `IoOverview` | `Views/IoOverviewView.xaml` | `ViewModels/IoOverviewViewModel.cs` | HM-16 | – | 13 | A 9 / B 1 / C 1 / D 1 / E 1 |  |
| HS-34 | `IoDisplay` | `Views/IoDisplayView.xaml` | `ViewModels/IoDisplayViewModel.cs` | HM-07, HM-17, HM-36 | – | 15 | A 12 / B 0 / C 1 / D 1 / E 1 |  |
| HS-35 | `SystemSettings` | `Views/SystemSettingsView.xaml` | `ViewModels/SystemSettingsViewModel.cs` | HM-16 | – | 19 | A 15 / B 1 / C 1 / D 1 / E 1 |  |
| HS-36 | `Service` | `Views/ServiceView.xaml` | `ViewModels/ServiceViewModel.cs` | HM-07, HM-11, HM-12, HM-25, HM-27 | Service_DesignData.cs | 15 | A 12 / B 0 / C 1 / D 1 / E 1 | Mindestrolle Technik; Betriebsart Service |
| HS-37 | `MessageArchive` | `Views/MessageArchiveView.xaml` | `ViewModels/MessageArchiveViewModel.cs` | HM-07, HM-25 | MessageArchive_DesignData.cs | 15 | A 11 / B 1 / C 1 / D 1 / E 1 |  |
| HS-38 | `MessageView` | `Views/MessageViewView.xaml` | `ViewModels/MessageViewViewModel.cs` | HM-25, HM-27 | MessageView_DesignData.cs | 14 | A 10 / B 2 / C 1 / D 0 / E 1 |  |
| HS-39 | `SystemInfo` | `Views/SystemInfoView.xaml` | `ViewModels/SystemInfoViewModel.cs` | HM-10, HM-11, HM-15, HM-19, HM-34 | SystemInfo_DesignData.cs | 18 | A 15 / B 0 / C 1 / D 1 / E 1 |  |
| HS-40 | `Feeders` | `Views/FeedersView.xaml` | `ViewModels/FeedersViewModel.cs` | HM-16 | – | 11 | A 8 / B 0 / C 1 / D 1 / E 1 |  |
| HS-41 | `DoserOverview` | `Views/DoserOverviewView.xaml` | `ViewModels/DoserOverviewViewModel.cs` | HM-17, HM-20 | – | 22 | A 17 / B 1 / C 1 / D 2 / E 1 |  |
| HS-42 | `Scales` | `Views/ScalesView.xaml` | `ViewModels/ScalesViewModel.cs` | HM-16 | – | 12 | A 9 / B 0 / C 1 / D 1 / E 1 |  |
| HS-43 | `ShiftPlan` | `Views/ShiftPlanView.xaml` | `ViewModels/ShiftPlanViewModel.cs` | HM-15, HM-27 | – | 11 | A 8 / B 0 / C 0 / D 2 / E 1 | Platzhalterseite (OP-02) |

### 6.3 Module HM-01 bis HM-38

"Seiten" = Zahl der Seiten, deren View das Modul direkt oder über ein Kompositmodul einsetzt; Rahmenmodule und Dialoge sind getrennt vermerkt. Texte stehen in den `Resources/Strings/*.resx` (Schlüssel `HM<nn>_…`).

| HM | Control (.cs) | Stil (.xaml) | Entwurfsdaten | Seiten | Prüfpunkte | A / B / C / D / E |
|---|---|---|---|---|---|---|
| HM-01 | `HM01_Converters.cs`, `HM01_Sidebar.cs`, `HM01_SidebarButton.cs` | `HM01_Sidebar.Styles.xaml`, `HM01_SidebarButton.Styles.xaml` | `HM01_DesignData.xaml` | Rahmen/Dialoge | 7 | A 5 / B 0 / C 1 / D 1 / E 0 |
| HM-02 | `HM02_HeaderBar.cs` | `HM02_HeaderBar.Styles.xaml` | `HM02_DesignData.xaml` | Rahmen/Dialoge | 6 | A 6 / B 0 / C 0 / D 0 / E 0 |
| HM-03 | `HM03_MessageLine.cs` | `HM03_MessageLine.Styles.xaml` | `HM03_DesignData.xaml` | Rahmen/Dialoge | 6 | A 4 / B 1 / C 0 / D 1 / E 0 |
| HM-04 | `HM04_Breadcrumb.cs` | `HM04_Breadcrumb.Styles.xaml` | `HM04_DesignData.cs`, `HM04_DesignData.xaml` | Rahmen/Dialoge | 5 | A 5 / B 0 / C 0 / D 0 / E 0 |
| HM-05 | `HM05_MetricTile.cs`, `HM05_ValueFormatConverter.cs` | `HM05_MetricTile.Styles.xaml` | `HM05_DesignData.xaml` | 4 + Dialog/Rahmen | 7 | A 7 / B 0 / C 0 / D 0 / E 0 |
| HM-06 | `HM06_Converters.cs`, `HM06_FunctionBar.cs` | `HM06_FunctionBar.Styles.xaml` | `HM06_DesignData.xaml` | Rahmen/Dialoge | 5 | A 3 / B 1 / C 1 / D 0 / E 0 |
| HM-07 | `HM07_ActionButton.cs`, `HM07_PressBehavior.cs` | `HM07_ActionButton.Styles.xaml` | `HM07_DesignData.xaml` | 20 + Dialog/Rahmen | 7 | A 6 / B 0 / C 1 / D 0 / E 0 |
| HM-08 | `HM08_ToggleSwitch.cs` | `HM08_ToggleSwitch.Styles.xaml` | `HM08_DesignData.xaml` | 11 + Dialog/Rahmen | 8 | A 6 / B 0 / C 1 / D 1 / E 0 |
| HM-09 | `HM09_StatusLed.cs` | `HM09_StatusLed.Styles.xaml` | `HM09_DesignData.xaml` | 13 | 5 | A 4 / B 0 / C 0 / D 1 / E 0 |
| HM-10 | `HM10_ProgressBar.cs`, `HM10_ProgressBarConverters.cs` | `HM10_ProgressBar.Styles.xaml` | `HM10_DesignData.xaml` | 6 | 5 | A 4 / B 0 / C 0 / D 1 / E 0 |
| HM-11 | `HM11_ValueDisplay.cs`, `HM11_ValueTextConverter.cs` | `HM11_ValueDisplay.Styles.xaml` | `HM11_DesignData.xaml` | 21 + Dialog/Rahmen | 6 | A 6 / B 0 / C 0 / D 0 / E 0 |
| HM-12 | `HM12_ValueInput.cs` | `HM12_ValueInput.Styles.xaml` | `HM12_DesignData.xaml` | 22 + Dialog/Rahmen | 7 | A 6 / B 0 / C 1 / D 0 / E 0 |
| HM-13 | `HM13_NumericKeypadDialog.Types.cs`, `HM13_NumericKeypadDialog.cs` | `HM13_NumericKeypadDialog.Styles.xaml` | `HM13_DesignData.xaml` | Rahmen/Dialoge | 9 | A 9 / B 0 / C 0 / D 0 / E 0 |
| HM-14 | `HM14_PopupFrame.Types.cs`, `HM14_PopupFrame.cs` | `HM14_PopupFrame.Styles.xaml` | `HM14_DesignData.xaml` | 2 + Dialog/Rahmen | 9 | A 7 / B 1 / C 1 / D 0 / E 0 |
| HM-15 | `HM15_GroupPanel.Types.cs`, `HM15_GroupPanel.cs` | `HM15_GroupPanel.Styles.xaml` | `HM15_DesignData.xaml` | 21 | 5 | A 4 / B 0 / C 0 / D 1 / E 0 |
| HM-16 | `HM16_TileNavigation.Types.cs`, `HM16_TileNavigation.cs` | `HM16_TileNavigation.Styles.xaml` | `HM16_DesignData.xaml` | 7 | 7 | A 4 / B 2 / C 1 / D 0 / E 0 |
| HM-17 | `HM17_TitleBar.Types.cs`, `HM17_TitleBar.cs` | `HM17_TitleBar.Styles.xaml` | `HM17_DesignData.xaml` | 7 | 4 | A 4 / B 0 / C 0 / D 0 / E 0 |
| HM-18 | `HM18_SelectorField.cs` | `HM18_SelectorField.Styles.xaml` | `HM18_DesignData.xaml` | 3 + Dialog/Rahmen | 6 | A 5 / B 0 / C 1 / D 0 / E 0 |
| HM-19 | `HM19_PagerButtons.Types.cs`, `HM19_PagerButtons.cs` | `HM19_PagerButtons.Styles.xaml` | `HM19_DesignData.xaml` | 3 + Dialog/Rahmen | 6 | A 4 / B 1 / C 1 / D 0 / E 0 |
| HM-20 | `HM20_DosingCard.cs` | `HM20_DosingCard.Styles.xaml` | `HM20_DesignData.xaml` | 1 | 8 | A 8 / B 0 / C 0 / D 0 / E 0 |
| HM-21 | `HM21_Converters.cs`, `HM21_MotorParameterCard.cs` | `HM21_MotorParameterCard.Styles.xaml` | `HM21_DesignData.xaml` | 3 | 6 | A 5 / B 1 / C 0 / D 0 / E 0 |
| HM-22 | `HM22_WeightCorrectionTable.cs` | `HM22_WeightCorrectionTable.Styles.xaml` | `HM22_DesignData.xaml` | 2 | 6 | A 5 / B 1 / C 0 / D 0 / E 0 |
| HM-23 | `HM23_CamTable.cs` | `HM23_CamTable.Styles.xaml` | `HM23_DesignData.xaml` | 1 | 7 | A 6 / B 1 / C 0 / D 0 / E 0 |
| HM-24 | `HM24_CamParameterRow.cs` | `HM24_CamParameterRow.Styles.xaml` | `HM24_DesignData.xaml` | 2 | 5 | A 4 / B 1 / C 0 / D 0 / E 0 |
| HM-25 | `HM25_Converters.cs`, `HM25_MessageList.cs` | `HM25_MessageList.Styles.xaml` | `HM25_DesignData.cs`, `HM25_DesignData.xaml` | 3 | 9 | A 8 / B 1 / C 0 / D 0 / E 0 |
| HM-26 | `HM26_Chart.cs`, `HM26_ChartLayout.cs` | `HM26_Chart.Styles.xaml` | `HM26_DesignData.cs`, `HM26_DesignData.xaml` | 2 | 6 | A 5 / B 0 / C 0 / D 1 / E 0 |
| HM-27 | `HM27_NoticeBox.cs` | `HM27_NoticeBox.Styles.xaml` | `HM27_DesignData.xaml` | 19 + Dialog/Rahmen | 5 | A 3 / B 0 / C 0 / D 2 / E 0 |
| HM-28 | `HM28_HeatZoneRow.cs` | `HM28_HeatZoneRow.Styles.xaml` | `HM28_DesignData.xaml` | 2 | 5 | A 5 / B 0 / C 0 / D 0 / E 0 |
| HM-29 | `HM29_Converters.cs`, `HM29_WeekSchedule.cs` | `HM29_WeekSchedule.Styles.xaml` | `HM29_DesignData.cs`, `HM29_DesignData.xaml` | 1 | 5 | A 4 / B 1 / C 0 / D 0 / E 0 |
| HM-30 | `HM30_Converters.cs`, `HM30_ScheduleEntryDialog.cs` | `HM30_ScheduleEntryDialog.Styles.xaml` | `HM30_DesignData.xaml` | Rahmen/Dialoge | 5 | A 5 / B 0 / C 0 / D 0 / E 0 |
| HM-31 | `HM31_Converters.cs`, `HM31_GlueTrackGraphic.cs` | `HM31_GlueTrackGraphic.Styles.xaml` | `HM31_DesignData.cs`, `HM31_DesignData.xaml` | 1 | 6 | A 4 / B 1 / C 1 / D 0 / E 0 |
| HM-32 | `HM32_PackRegisterGraphic.cs` | `HM32_PackRegisterGraphic.Styles.xaml` | `HM32_DesignData.xaml` | 1 | 5 | A 2 / B 2 / C 1 / D 0 / E 0 |
| HM-33 | `HM33_CounterRow.cs` | `HM33_CounterRow.Styles.xaml` | `HM33_DesignData.xaml` | 1 | 5 | A 5 / B 0 / C 0 / D 0 / E 0 |
| HM-34 | `HM34_DriveStatusRow.cs` | `HM34_DriveStatusRow.Styles.xaml` | `HM34_DesignData.xaml` | 1 | 5 | A 3 / B 2 / C 0 / D 0 / E 0 |
| HM-35 | `HM35_RegulationBlock.cs` | `HM35_RegulationBlock.Styles.xaml` | `HM35_DesignData.xaml` | 1 | 5 | A 4 / B 1 / C 0 / D 0 / E 0 |
| HM-36 | `HM36_IoRow.cs` | `HM36_IoRow.Styles.xaml` | `HM36_DesignData.xaml` | 1 | 5 | A 4 / B 1 / C 0 / D 0 / E 0 |
| HM-37 | `HM37_ValueGrid.cs` | `HM37_ValueGrid.Styles.xaml` | `HM37_DesignData.xaml` | 1 | 5 | A 4 / B 1 / C 0 / D 0 / E 0 |
| HM-38 | `HM38_SearchDialog.cs` | `HM38_SearchDialog.Styles.xaml` | `HM38_DesignData.xaml` | Rahmen/Dialoge | 6 | A 5 / B 1 / C 0 / D 0 / E 0 |

### 6.4 Nicht umgesetzt und bewusste Platzhalter

| Gegenstand | Status | Beleg |
|---|---|---|
| `HM-20` Modus Detail in HS-11 und HS-19 (HM-20-P08, Seitenreferenz „HM-20 (Detail)“) | **nicht wie dokumentiert umgesetzt**; die Seiten sind funktional vollständig, aber aus Einzelmodulen gebaut (B-01) | `Views/MainDosersView.xaml`, `Views/PostDoserView.xaml` |
| HS-43 Schichtplan | Platzhalter wie in OP-02 vorgesehen | `ViewModels/ShiftPlanViewModel.cs`, `Views/ShiftPlanView.xaml` |
| Logo APA-TEC in HM-02 | Platzhalter (A-78, OP-66) | `HM02_HeaderBar.Styles.xaml` |
| Symbole (68) | Platzhaltergeometrien im 24×24-Raster, Verfeinerung in M3 (README) | `Themes/Icons.xaml` |
| Dialoge Sprache/Rezept/Benutzer | Dummy-Inhalt (OP-63); nur Sprache `de-DE` ist wählbar | `LocalizationService.SupportedCultures` |
| Geräte-Kachel und leere Kachel in HS-04 | bewusst deaktiviert mit Grund (antippbar, Meldezeile) | `SettingsViewModel.cs` Z. 168–178 |
| Maschinenanbindung, Dateiformat Import/Export | außerhalb des Projekts bzw. OP-49 | Dummy-Dienste |

## 7 Verbindliche Liste „offen für Meilenstein 3“

Alles Folgende ist in der Cloud nicht prüfbar und wird in `Pruefbericht_M3.md` und `Offene-Punkte.md` übernommen.

**Start und Laufzeit**
- M3-01 Build und Start unter Windows mit .NET 8 (`dotnet run --project src/ApaTec.Hmi`); erste Seite HS-01 erscheint, keine Ausnahme beim Start (u. a. `FrameworkElement.LanguageProperty.OverrideMetadata` in `Program.cs`, Auflösung aller Stile/Converter zur Laufzeit, Dienst-Registrierung per Reflection, DI-Konstruktorwahl von `DummyUserSession`).
- M3-02 Alle 43 Seiten und 10 Dialoge öffnen sich ohne Fehler in der Ausgabe (Bindungsfehler im Ausgabefenster auswerten; Bindungspfade sind nur statisch geprüft).
- M3-03 Entwurfsmodus im Designer (parameterlose Konstruktoren, `d:DataContext`) für alle Views.
- M3-04 Dummy-Uhr, Meldungen und Betriebsart aktualisieren die Kopfzeile (Thread-Marshalling `PostToUi`).

**Layout 1920 × 1080 je Seite**
- M3-05 Jede der 43 Seiten (Rahmen und Inhalt) bei 1920 × 1080 mit den Screenshots (DS-01 bis DS-05) bzw. der Seitenbeschreibung vergleichen: Gruppenverhältnisse, Raster, Abstände, Textabschneidung, Kopf- und Funktionsleiste (Gruppe B: 73 Prüfpunkte).
- M3-06 Skalierung bei abweichender Fenstergröße, Vollbild HS-24 ohne Rahmen.
- M3-07 Funktionsleiste: Überlauf „Mehr“ bei mehr als 5 Tasten, rechtsbündige Gruppe, Popup-Platzierung.

**Touch**
- M3-08 Zielgrößen ≥ 48 px (Standard 64 px) und Abstände ≥ 16 px am Touch-Gerät (Gruppe C: 52 Prüfpunkte); Bedienung mit Handschuh/Finger.
- M3-09 Windows-Bildschirmtastatur bei Touch-Fokus in der Textvariante (HM-13, Filter).

**Kontrast und Hell/Dunkel**
- M3-10 Beide Themen vollständig durchklicken (`IThemeService.SetTheme`), Kontrastverhältnisse messen, Lesbarkeit aus Bedienabstand.
- M3-11 Zustände in Graustufen unterscheidbar (zweiter Kanal; Gruppe D: 61 Prüfpunkte), Fehlerrot nur für Fehler.

**Symbole und Logo**
- M3-12 Platzhaltergeometrien der 68 Symbole gegen die Designvorlage verfeinern; Logo APA-TEC je Thema beschaffen (OP-65, OP-66).

**Fokus und Tastatur**
- M3-13 Tab-Reihenfolge, sichtbarer Fokusring, Enter/Leertaste auf Tasten, Fokus im Pop-up gefangen (modal).

**Verhalten Halten und Jog**
- M3-14 Totmanntasten HS-31 (Jog +/−): Bewegung nur solange gedrückt, Stopp beim Loslassen, beim Seitenwechsel und bei Verlust des Fokus; gleichzeitiges Drücken beider Richtungen.
- M3-15 Haltetasten (HS-32 Geber setzen, Reset): Fortschrittsstreifen, Haltedauer, Abbruch beim Loslassen; Sperrgrund bei fehlendem Not-Aus bzw. fehlender Rolle.
- M3-16 Nachfüllen (WhilePressed) auf HS-11/HS-19/HS-41.

**Bildlauf und Wischen**
- M3-17 Wischen/Bildlauf in HS-22 (12 Zonen), HS-25/HS-26, Meldungslisten HS-37/HS-38, Service-Liste HS-36 (`PanningMode`), Trägheit, Seitenpfeile.

**Sprachumschaltung**
- M3-18 Sprachdialog: derzeit nur `de-DE` wählbar; Umschaltung zur Laufzeit (Texte, Brotkrümel, Titel, Zahlen/Datum) mit mindestens einer zweiten Ressourcensprache testen; Dezimalkomma und Datumsformat in allen Eingaben (Kultur-Fix aus Abschnitt 5).

**Berechtigungsabläufe**
- M3-19 Rollenwechsel: Benutzer-Pop-up bei geschützten Feldern (Technik) und Seiten (HS-36); Rückkehr zur Aktion nach Anmeldung; Rollenverlust auf geschützter Seite (Seite wird verlassen, Pop-ups schließen).
- M3-20 Schlüssel-/Schloss-Symbole und gesperrte Felder an allen Eingaben (HM-12, HM-08, HM-07).

**Dialoge**
- M3-21 Eingabe-Pop-up (Zahl, Zeit, Text): Bereichsprüfung, Fehlertext, Übernehmen gesperrt bei ungültigem Wert; Stapeltiefe 2; Navigation hinter Pop-up gesperrt.
- M3-22 Bestätigung „Änderungen verwerfen?“ (HS-25), Datei-Pop-up mit Lauf/Ergebnis (HS-36/HS-37), Suche (HM-38), Zeitplan-Eintrag (HM-30), Filter, Rezept.

**Windows-spezifische Prüfungen**
- M3-23 Hochdpi/Skalierung 100 % bis 150 %, Mehrmonitor, Bildschirmschoner/Energie.
- M3-24 Performance (Start, Seitenwechsel, Diagramme HM-26, Listen HM-25), Speicher bei langem Betrieb (Abonnements der ViewModels bei `OnNavigatedFrom` freigeben).
- M3-25 Thread-Sicherheit der Dummy-Dienste (Ereignisse aus Hintergrundthreads).
- M3-26 Gesamt-Durchlauf: Navigation vollständig durchklicken (Zurück-Stapel Tiefe 20, Brotkrümel-Sprünge, Home, Einstellungen), Abnahme.

## 8 Verbleibende Befunde

| Nr | Datei | Problem | Schwere |
|---|---|---|---|
| B-01 | `Views/MainDosersView.xaml`, `Views/PostDoserView.xaml` (Controls `HM20_DosingCard`) | HS-11 und HS-19 setzen `HM-20` im Modus Detail nicht ein, sondern wiederholen dasselbe Seitengerüst aus Einzelmodulen (beide Views je ca. 120 Zeilen, rund die Hälfte davon identisch); `HM-20-P08` und die Modulzuordnung in HS-11/HS-19 weichen ab, „keine Kopien“ (Agent.md 5) nicht eingehalten. Entweder auf `CardMode="Detail"` umstellen oder die Abweichung in `Annahmen.md` festhalten. | niedrig |
| B-02 | `docs/00_Plan/Annahmen.md` | Nummer **A-94 fehlt** (A-93 folgt A-95); IDs sind sonst eindeutig und aufsteigend, alle Verweise lösen auf. Lücke schließen oder Hinweis eintragen. | niedrig |
| B-03 | `docs/00_Plan/Fortschritt.md`, `Task.md`, Prüfpunkt-Status in `docs/03_HMI-Konzept/**` | Fortschritt enthält keinen Eintrag für Meilenstein 2; die Punkte von Meilenstein 2 in `Task.md` sind nicht abgehakt; alle 1.004 Prüfpunkte stehen auf „offen“ (Agent.md 3 verlangt Pflege). Nach diesem Bericht vom Verwalter fortzuschreiben. | niedrig |
| B-04 | `Views/MainDosersView.xaml` Z. 57, `Views/PostDoserView.xaml` Z. 69 u. a. (20 Stellen) | Einheitensymbole `%`, `g`, `s`, `1/min` fest als `Unit="…"`, während andere Stellen `Unit_Gram` usw. aus den Ressourcen nutzen; sprachneutral, aber uneinheitlich zur Regel „Text aus `.resx`“. | niedrig |
| B-05 | `ViewModels/FunctionBarItem.cs` / alle Seiten-ViewModels | `IsTrailing` (rechtsbündige Hauptaktion, HM-06) wird von keinem ViewModel gesetzt; Funktion nur über Entwurfsdaten belegt. | niedrig |
| B-06 | `Navigation/NavigationService.cs` Z. 180–195 (`Guard`) | Synchrone Wege (Zurück, Brotkrümel, Home) liefern `true`, bevor die Rückfrage „Verwerfen“ entschieden ist; bei „Nein“ bleibt die Seite stehen, der Aufrufer erfährt es nicht. Wirkung für die Bedienung gering. | niedrig |

Hoch und mittel: keine.

## 9 Konsistenz

- **Annahmen**: 97 Einträge A-01 bis A-98, eine Lücke (A-94), keine Duplikate, aufsteigend, Datumsspalte in allen Zeilen; Verweise auf A-Nummern in `docs/`, `src/` (Code, XAML, README, Skripte) alle definiert; 21 Annahmen werden außerhalb von `Annahmen.md` nicht zitiert (unkritisch).
- **Offene Punkte**: OP-01 bis OP-66 lückenlos und eindeutig. Die Übergabepunkte aus Abschnitt 7 sind noch nicht eingetragen (vom Verwalter zu übernehmen).
- **Seitenregister**: 43 Schlüssel in `Navigation.md` 5.1 = 43 `PageKeys` = 43 Views = 43 ViewModels.
- **Module**: 38 Module in der Modulliste = 38 Controls = 38 Entwurfsdaten.
- **README** `src/README.md` beschreibt die Struktur korrekt (Namen, Pfade, Prüfaufrufe stimmen mit dem Stand überein).
- **`src_Data`**: unverändert.

## 10 Endurteil

**BESTANDEN.** Build ohne Fehler und Warnungen, alle Prüfskripte grün, Code-behind leer, keine Hex-/Pixel-Literale, alle 17 geprüften Fixes behoben und im Code belegt, 43 HS und 38 HM mit Dateien rückverfolgt. Es bleiben sechs Befunde niedriger Schwere (B-01 bis B-06) und die Liste „offen für Meilenstein 3“ (M3-01 bis M3-26), die verbindlich nach Meilenstein 3 übergeht.

## 11 Nachprüfung nach Gesamtprüfung

Gegenstand: Änderungen nach dem Endurteil aus Abschnitt 10 (Commit `0ed32a0`): Async-Navigations-API (`INavigationService.GoBackAsync`, `GoToAncestorAsync`, `GoHomeAsync`, `GoToSettingsAsync`, `NavigationService`, `ShellViewModel`), `StartupOptions.cs` und `Program.cs` (`--page`, `--dialog`, `--theme`, `--culture`, `--role`, `--designdata`), Einheiten-Ressourcen in `ClosingMachineView`, `PostDoserView`, `MainDosersView`, `src/tools/windows/{Build-And-Run.ps1, Capture-Pages.ps1, README.md}`, `M3_Abnahmematrix.md`, `Pruefbericht_M3.md`, `Fortschritt.md`, `Annahmen.md`, `Offene-Punkte.md`. Prüfer: unabhängiger Prüf-Agent, 2026-11-05. Methode: Build in einer Kopie im Scratchpad, Skripte, statische Lektüre (PowerShell nicht ausführbar), keine Änderung am Repository außer diesem Abschnitt.

**Ergebnis: BESTANDEN.** 0 hoch, 0 mittel, 6 niedrig bzw. Hinweis (N-01 bis N-06). Die Befunde B-02, B-04, B-05 und B-06 aus Abschnitt 8 sind wie beschrieben behoben, B-01 bleibt dokumentierte Abweichung, B-03 ist für `Fortschritt.md` erledigt (`Task.md` und Prüfpunktstatus bleiben beim Verwalter).

### 11.1 Automatische Prüfungen

| Prüfung | Ergebnis |
|---|---|
| `dotnet build ApaTec.Hmi.sln -p:EnableWindowsTargeting=true --no-incremental` (Kopie) | 0 Fehler, 0 Warnungen |
| `check_design.py` | BESTANDEN (609 Loc-Schlüssel in XAML, alle in den Ressourcen; 57 Code-behind-Dateien; PageKeys 43) |
| `check_modules.py` | 38/38 Module OK |
| `check_pages.py` | 43/43 Seiten, 10/10 Dialoge OK |
| `check_icons.py` | BESTANDEN (68 Symbole, 65 verwendet, 3 Reserve) |
| `xmllint --noout` über alle `.xaml` | ohne Meldung |
| `git diff f168526 -- src_Data` | leer, `src_Data` unverändert |
| Links in M3-Dokumenten, `Fortschritt.md`, `Offene-Punkte.md`, beiden READMEs (Skript) | alle gültig; einziger nicht auflösender Verweis `../Module/DM-xx_Name.md` in `Annahmen.md` ist die schon vor der Änderung vorhandene Vorlagenzeile (kein Befund) |

### 11.2 Code-Review Navigation und Startparameter

- `GoBackAsync`, `GoToAncestorAsync`, `GoHomeAsync`, `GoToSettingsAsync` laufen über dieselben Kernmethoden (`GoBackCore`, `HomeCore`, `SettingsCore`, `NavigateCore`) wie die synchronen Wege; `GuardAsync` fragt `CanLeaveAsync` nur bei `HasLeaveGuard` und nur ohne offenes Pop-up und prüft nach dem Warten erneut auf offenes Pop-up und unveränderte aktuelle Seite (`ReferenceEquals`). Der Fall „Seite wurde währenddessen gewechselt“ liefert `false`, kein Doppelwechsel.
- Deadlock/Wiederholeintritt: Keine blockierende Wartestelle (kein `.Result`/`.Wait()`), die Rückfrage ist ein Pop-up auf dem Popup-Stapel; während sie offen ist, sperren `CanGoBack`/`IsModalOpen` die Navigationswege, und die `[RelayCommand]`-Async-Befehle im `ShellViewModel` laufen nicht gleichzeitig mit sich selbst. Ein Schließen der Rückfrage durch Dismiss liefert `Accepted = false` (`CamsViewModel.ConfirmDiscardAsync`), die wartende Navigation endet mit `false`.
- Aufrufer migriert: `ShellViewModel` (Home, Settings, Back, Seitenleiste, Brotkrümel) nutzt nur noch die Async-Varianten; verbleibende synchrone Aufrufer sind `Program.cs` (`GoHome()` beim Start, keine Seite vorhanden, daher ohne Rückfrage) und `ScreenCleaningViewModel` (`GoBack()`, Seite ohne Leave-Guard). Der Rückgabewert `false` während einer laufenden Rückfrage ist in `INavigationService` und im Kommentar bei `Guard` eindeutig dokumentiert, Konzept.md und README ziehen nach.
- `StartupOptions`: Nullfälle (leerer Wert, fehlendes `=`, Anführungszeichen, falsche Groß-/Kleinschreibung) erzeugen Warnung oder Standard, keine Ausnahme; Argumente ohne `--` und die des Generic Hosts bleiben unberührt. `--page` und `--dialog` lösen nur gegen `PageCatalog.All` + `PageRegistry` bzw. `DialogKeys` + `PostDoserHints` auf (case-insensitiv), Unbekanntes erzeugt `[Start]`-Warnung (Debug und Standardfehler). `OpenRequestedAsync` fängt jede Ausnahme und meldet sie als Warnung. Der Direktstart läuft nach `Loaded`, ist also nach dem Aufbau des Hauptfensters (Dispatcher-Schleife läuft; Rollenabfrage bei `--page=Service` ohne `--role` öffnet das Benutzer-Pop-up). Alle Dialog-ViewModels sind bei `null`-Parameter ohne Ausnahme (`OnOpened`).
- Kein Code-behind: `StartupOptions.cs`, `Program.cs` und `ShellViewModel` sind code-behind-frei; die 57 `*.xaml.cs` enthalten weiter nur `InitializeComponent()` (`check_design`). Die 20 Einheitenstellen in HS-11/16/19 verwenden `{res:Loc Unit_*}`; alle vier Schlüssel (`Unit_Percent`, `Unit_Gram`, `Unit_Second`, `Unit_RevPerMin`) sind in `Strings.resx` definiert; außerhalb von `DesignData/` bleiben keine festen Einheitentexte.

### 11.3 PowerShell-Skripte (statisch, nicht ausgeführt)

Syntax, Variablen, Hashtable-/Array-Behandlung (`$wanted += , $hit`), `Add-Type`-Signaturen, Pfade (`$PSScriptRoot\..\..\..` = Repository-Wurzel, Ausgabe `src\ApaTec.Hmi\bin\<Konfiguration>\net8.0-windows\ApaTec.Hmi.exe`, `docs\04_Pruefung\Screenshots_M3`), `ValidateSet`, Fehlerbehandlung (`$ErrorActionPreference = 'Stop'`, `try/finally` mit `CloseMainWindow`/`Kill` des gestarteten Prozesses, Exit-Codes 1 und 2) sind stimmig. Die Auflösungs- und Skalierungswarnung (Bildschirm ≠ 1920 × 1080, DPI ≠ 100 %, Client ≠ 1920 × 1080, Rückfrage außer mit `-Force`) ist vorhanden. Die Seitentabelle in `Capture-Pages.ps1` stimmt in allen 43 Zeilen (HS-Nummer, PageKey, Art, Rolle) mit `PageCatalog.cs` überein. Es gibt keine Löschbefehle (nur `New-Item -Force` für den Screenshot-Ordner und Überschreiben der eigenen PNG-Dateien), keinen Netzwerkzugriff außer dem dokumentierten `dotnet restore`, keine Registry-/Systemänderung (nur `SetProcessDPIAware` im eigenen Prozess).

### 11.4 Dokumente

- `M3_Abnahmematrix.md`: 43 Seitenzeilen (Schlüssel und Startaufruf `--page=`/`--dialog=` stimmen mit `PageKeys.cs`/`PageCatalog.cs` überein, HS-02/HS-03 als `--dialog`, HS-36 mit `--role=technician`), 38 Modulzeilen HM-01 bis HM-38, 10 Dialoge (+ Zeile für HS-02/HS-03), 15 Querschnittspunkte. Alle Dateilinks gültig, alle genannten Prüfpunkt-IDs (`Pnn`) existieren in den HS-/HM-Dateien, alle M3-Bezüge M3-01 bis M3-26 vorhanden. Summen L/T/K stimmen mit den Zeilen überein (Seiten 54/41/52, Module 23/11/9).
- `Pruefbericht_M3.md`: die 26 Punkte M3-01 bis M3-26 entsprechen dem Gegenstand nach Abschnitt 7 dieses Berichts (M3-07 „ab der 6. Taste“ = „mehr als 5 Tasten“); Entscheidungsliste: alle genannten OP-Nummern existieren (`Offene-Punkte.md` OP-01 bis OP-66 lückenlos); Ergebnisfelder leer, Status „vorbereitet“, kein vorweggenommenes Ergebnis.
- `Annahmen.md`: A-01 bis A-100, 100 Einträge, eindeutig, aufsteigend, einzige Lücke A-94 als „bewusst nicht vergeben“ eingetragen; A-99 und A-100 passen zum Code. Alle in `docs/`, `src/`, `Task.md`, `Agent.md` genannten A-Nummern sind definiert (A-101 kommt nur als Ankündigung „ab A-101“ vor). `Fortschritt.md`: neueste Einträge oben, Endurteil-Wortlaut deckt sich mit Abschnitt 1 („BESTANDEN mit Auflagen“). `Offene-Punkte.md`: Abschnitt „Übergabe an Meilenstein 3“ verweist auf existierende Dateien, OP-Bezüge gültig.

### 11.5 Befunde

| Nr | Datei:Zeile | Problem | Soll | Schwere |
|---|---|---|---|---|
| N-01 | `src/tools/windows/Capture-Pages.ps1`:68 | `Add-Type -TypeDefinition` ohne Existenzprüfung des Typs `HmiNative`; beim zweiten Lauf in derselben PowerShell-Sitzung bricht das Skript wegen `$ErrorActionPreference = 'Stop'` mit „Typ existiert bereits“ ab | `if (-not ([System.Management.Automation.PSTypeName]'HmiNative').Type) { Add-Type … }` (oder Hinweis im README: pro Aufruf neue Sitzung) | niedrig |
| N-02 | `src/tools/windows/Build-And-Run.ps1`:99–101 | Bei `-SkipRestore` wird die Argumentliste ersetzt und `--no-restore` entfällt (Zeile 101), obwohl die Beschreibung „Offline-Betrieb“ nennt; mit `-Clean -SkipRestore` geht zudem `--no-incremental` verloren. Die Logik wirkt umgekehrt zum Namen | `-SkipRestore` ⇒ `--no-restore`; Standard ohne `--no-restore` oder Restore explizit; `--no-incremental` unabhängig anhängen | niedrig |
| N-03 | `src/ApaTec.Hmi/Program.cs`:283–285 | Nur `Input` erhält per `--dialog` einen Beispielparameter; `Confirmation`, `Search`, `Filter`, `FileResult`, `ScheduleEntry`, `Recipe` öffnen ohne Text/Trefferliste/Felder. Die Aufnahmen mit `-IncludeDialogs` zeigen daher leere Dialoge, die Matrixzeilen 2.1 („Texte“, „Trefferliste“, „Zeitfelder“) lassen sich so nur teilweise prüfen. Im Risikoabschnitt von `Pruefbericht_M3.md` nur allgemein erwähnt | Beispielparameter für diese Dialoge ergänzen oder in der Matrix 2.1 vermerken, dass sie über die Seiten (HS-10, HS-25, HS-36/37, HM-38) geprüft werden | niedrig |
| N-04 | `src/ApaTec.Hmi/StartupOptions.cs`:69–72 | `--culture` ohne Wert liefert über `CultureInfo.GetCultureInfo("")` die Invariante Kultur ohne Warnung (Dezimalpunkt statt -komma); unbekannte Parameternamen (`--pagee=…`) werden ohne Warnung ignoriert (die Beschreibung nennt nur fehlerhafte Werte) | Leerwert bei `--culture` wie bei `--page` als Warnung behandeln; optional Warnung für unbekannte Namen unter Ausschluss der Host-Parameter | niedrig |
| N-05 | `src/ApaTec.Hmi/Navigation/NavigationService.cs`:162, 174, 203 | `GoToAncestor()` und `GoToSettings()` (synchron) haben keinen Aufrufer mehr (Semantik ist dokumentiert, daher nicht falsch, aber toter Umfang); `Guard` startet `_ = GuardAsync(navigate)` ohne Beobachtung von Ausnahmen aus `CanLeaveAsync`; `GoHome` während eines offenen Pop-ups umgeht den Leave-Guard (wie vor der Änderung, Sidebar ist dann gesperrt) | Hinweis: bei Gelegenheit sync-Varianten streichen oder Ausnahme in `Guard` abfangen; kein Handlungsbedarf für die Abnahme | Hinweis |
| N-06 | `docs/04_Pruefung/M3_Abnahmematrix.md`:9 | Summe B (L) weicht von `Pruefbericht_M2.md` 6.1 ab (Seiten 54 statt 52, Module 23 statt 21; einzelne Seiten HS-01, 02, 28, 31, 32, 37, HM-25, HM-38); die Abweichung ist im Abschnitt 1 der Matrix offen begründet („im Zweifel gilt die Prüfpunkt-Datei“) | keine Änderung nötig; bei Abnahme die Prüfpunkt-Dateien als maßgeblich verwenden | Hinweis |

### 11.6 Urteil

**BESTANDEN.** Build 0/0, vier Prüfskripte und `xmllint` grün, `src_Data` unverändert, die Async-Navigation ist logisch geschlossen (keine Blockade, Wiederholeintritt abgesichert, Aufrufer migriert), die Startparameter fangen Fehler als Warnung ab und lösen nur registrierte Schlüssel auf, die Skripte sind statisch stimmig und ohne gefährliche Aktionen, M3-Dokumente, Plandateien und Nummernkreise (A, OP, M3, HS, HM) sind konsistent. N-01 bis N-04 sind vor oder bei der ersten Windows-Ausführung in Meilenstein 3 zu beheben; N-05 und N-06 sind Hinweise.
