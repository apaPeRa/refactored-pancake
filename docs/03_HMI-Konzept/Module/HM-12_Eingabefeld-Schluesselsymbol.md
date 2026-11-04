# HM-12 – Eingabefeld mit Schlüsselsymbol

## Funktion
Feld zur Eingabe eines Einstellwerts mit Beschriftung. Das Schlüsselsymbol kennzeichnet ein berechtigungspflichtiges Feld (A-08). Antippen öffnet das Eingabe-Pop-up [HM-13](HM-13_Eingabe-Pop-up.md) mit vorbelegtem Wert und den Grenzen (A-20). Der Wert steht nicht in Rot, sondern in `Font.Weight.Strong` (Rot nur für Fehler). Varianten als Parameter: mit/ohne Beschriftung (in Grafiken), mit/ohne Schlüssel (RS-03 „Schnell“, „Langsam“), Zahl, Zeit (hh:mm), Text (Bezeichnung), mit Symbol vor dem Feld, mit Zusatzzähler und gekoppeltem Zähler (RS-13).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Beschriftung (`Label`) | string? | – | z. B. „Ziel Füllstand:“, „Durchmesser Max.:“; entfällt in Grafiken |
| Wert (`NumberValue`) | double? | Einheit | Beispiele 50 %, 290 °, 20 ms, 60 s, 235,0 g, 125 1/min, 150 °C, 1,7 bar |
| Textwert (`TextValue`) | string? | – | Variante Text |
| Eingabeart (`InputKind`) | enum InputKind { Number, Time, Text } | – | Number Standard |
| Einheit (`Unit`) | string | – | %, °, ms, s, g, Stk, 1/min, °C, bar, ohne |
| Nachkommastellen (`Decimals`) | int | – | 0 bis 3 |
| Minimum (`Minimum`), Maximum (`Maximum`) | double? | wie Wert | fachlich nicht dokumentiert (OP-28), konfigurierbar |
| Schlüssel (`RequiresPermission`) | bool | – | false = Feld ohne Schlüssel |
| Benötigte Rolle (`RequiredRole`) | string? | – | offen (OP-04) |
| Berechtigt (`IsAuthorized`) | bool | – | false zeigt Schloss |
| Symbol (`Icon`) | Geometry? | – | z. B. `Icon.Speed` |
| Zusatzzähler (`Counter`) | int? | Stk | RS-13 Automatischer Nullpunkt |
| Gekoppelter Zähler (`CoupledCounter`) | int? | Stk | RS-13 Übergewicht, Untergewicht |
| Wert geändert (`IsPendingWrite`) | bool | – | Wert erst nach „Werte schreiben“ wirksam (RS-25) |
| Fehlertext (`ErrorText`) | string? | – | bei ungültiger Eingabe |
| Befehl (`CommitCommand`) | ICommand<double?> | – | nach Übernehmen im Pop-up |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Normal | `Brush.Surface`, Kontur `Border.Thin` `Brush.Border.Control`, Wert `Font.Size.Value` `Font.Weight.Strong` `Brush.Text.Primary`, Einheit `Brush.Text.Secondary`, Höhe `Size.Touch.Default` | Beschriftung, Einheit; `Icon.Key` (`Size.Icon.S`) oben rechts |
| Gedrückt | `Brush.Button.Pressed`, Kontur `Border.Medium` | dickere Kontur |
| In Bearbeitung | Kontur `Border.Thick` `Brush.Border.Focus` | Rahmen (Form) und geöffnetes Pop-up |
| Fehler | Kontur `Border.Thick` `Brush.Status.Error.Fill`, Fläche `Brush.Status.Error.Subtle` | `Icon.Status.Error` und Fehlertext („Wert außerhalb 0 bis 100 %“) |
| Nicht berechtigt | Normal, öffnet kein Pop-up | `Icon.Lock` und Hinweis „Berechtigung erforderlich: <Rolle>“ |
| Deaktiviert | Kontur gestrichelt (`Border.Dash`), Text `Brush.Text.Disabled` | gestrichelte Kontur; Grund in Meldezeile (A-28) |
| Geändert, nicht geschrieben | Normal | Punkt-Symbol `Icon.State.Pending` und Text „Nicht geschrieben“ |
| Ohne Schlüssel | Normal | kein Schlüssel-Symbol |

## Verwendet auf Seiten (IDs)
- [HS-03](../Seiten/HS-03_Maschinengeschwindigkeit.md) – Maschinengeschwindigkeit (Pop-up)
- [HS-05](../Seiten/HS-05_Zufuehrung-Papier.md) – Zuführung Papier
- [HS-06](../Seiten/HS-06_Zufuehrung-Karton.md) – Zuführung Karton
- [HS-07](../Seiten/HS-07_Heissleim-Nordson.md) – Heißleim Nordson
- [HS-08](../Seiten/HS-08_Heissleim-Parameter.md) – Heißleim Parameter
- [HS-09](../Seiten/HS-09_Heissleim-Druck.md) – Heißleim Druck
- [HS-10](../Seiten/HS-10_Zeitschaltuhr.md) – Zeitschaltuhr
- [HS-11](../Seiten/HS-11_Hauptdosierer-1-und-2.md) – Hauptdosierer 1 & 2
- [HS-12](../Seiten/HS-12_Motorparameter.md) – Motorparameter (Hauptdosierer)
- [HS-13](../Seiten/HS-13_Kontrollwaage.md) – Kontrollwaage
- [HS-16](../Seiten/HS-16_Schliessmaschine.md) – Schließmaschine
- [HS-17](../Seiten/HS-17_Motorparameter-Schliessmaschine.md) – Motorparameter (Schließmaschine)
- [HS-18](../Seiten/HS-18_Gewichtskorrektur-Schliessmaschine.md) – Gewichtskorrektur (Schließmaschine)
- [HS-19](../Seiten/HS-19_Nachdosierer.md) – Nachdosierer
- [HS-20](../Seiten/HS-20_Motorparameter.md) – Motorparameter (Nachdosierer)
- [HS-21](../Seiten/HS-21_Gewichtskorrektur.md) – Gewichtskorrektur (Nachdosierer)
- [HS-22](../Seiten/HS-22_Heizungen.md) – Heizungen
- [HS-23](../Seiten/HS-23_Regulierung.md) – Regulierung
- [HS-25](../Seiten/HS-25_Nocken.md) – Nocken
- [HS-27](../Seiten/HS-27_Waagen-Kalibrieren.md) – Waagen Kalibrieren
- [HS-31](../Seiten/HS-31_Handbetrieb.md) – Handbetrieb
- [HS-36](../Seiten/HS-36_Service.md) – Service
- [HS-37](../Seiten/HS-37_Meldearchiv.md) – Meldearchiv
- [HS-39](../Seiten/HS-39_System-und-Antriebsinfos.md) – System- und Antriebsinfos

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die HS-Dateien entstehen in Phase 3 (Punkt 4); die Links sind vorläufig.

## Herkunft
- [DM-17](../../01_Design-Analyse/Module/DM-17_Eingabefeld-mit-Schluesselsymbol.md) – Eingabefeld mit Schlüsselsymbol: Eingabefeld für Sollwerte
- [RM-05](../../02_Referenz-Analyse/Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) – Eingabefeld mit Schlüsselsymbol: häufigstes Element der Referenz, auch Dosierer-Parameterfeld

## WPF-Umsetzung
- **Control:** `HM12_ValueInput` (UserControl), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `UserControl` (`HM12_ValueInput`); Pop-up über `IDialogService.ShowInputAsync(...)` aus dem ViewModel, nicht im Control.
- **Dependency Properties:** `Label`, `NumberValue`, `TextValue`, `InputKind`, `Unit`, `Decimals`, `Minimum`, `Maximum`, `RequiresPermission`, `RequiredRole`, `IsAuthorized`, `Icon`, `Counter`, `CoupledCounter`, `IsPendingWrite`, `ErrorText`; **Command:** `CommitCommand`.
- **Maße:** Höhe `Size.Touch.Default`, Trefferfläche ≥ `Size.Touch.Min`, Schlüssel `Size.Icon.S`.
- **Neue Symbole** (`Themes/Icons.xaml`): `Icon.Key`, `Icon.Lock` (Designsystem); `Icon.State.Pending` (neu).
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-12-P01 | DS-03 | „Ziel Füllstand: 50 %“ und „Max Füllzeit: 60 s“ mit Schlüsselsymbol | offen |
| HM-12-P02 | DS-05 | 18 Felder ohne Beschriftung in HM-31 | offen |
| HM-12-P03 | Wert nicht rot | Eingabewert in Textfarbe, Fehler nur im Fehlerzustand | offen |
| HM-12-P04 | Nicht berechtigt | kein Pop-up, Schloss und Hinweistext | offen |
| HM-12-P05 | Ungültig | Fehlertext mit Symbol, nicht nur Rotfärbung | offen |
| HM-12-P06 | Abgrenzung | Anzeigefelder ohne Schlüssel sind HM-11 | offen |
| HM-12-P07 | Touch | Höhe `Size.Touch.Default`, Schlüssel nicht als eigenes Ziel | offen |
