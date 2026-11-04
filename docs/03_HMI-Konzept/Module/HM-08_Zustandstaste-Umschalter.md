# HM-08 – Zustandstaste / Umschalter

## Funktion
Ein/Aus-Element für eine Teilfunktion. Eine Funktion, zwei Darstellungen als Parameter: **Schalter** (Bahn `Size.Toggle.Width` × `Size.Toggle.Height` mit Knopf `Size.Toggle.Knob`, Beschriftung links, Wort rechts) und **Taste** (Taste `Size.Touch.Default` hoch mit Beschriftung, Symbol und Wort). Die Taste gibt es zusätzlich in **Kachelhöhe** (`ButtonSize = Tile`: `Size.Touch.Large` hoch, füllt eine Rasterzelle, zweizeilige Beschriftung), z. B. der Tastenblock 3 × 2 auf HS-01; die Rasteranordnung liefert [HM-16](HM-16_Kachel-Navigation.md) (Elementart `StateToggle`), der Zustand bleibt in diesem Modul. Beide zeigen den Zustand über Position/Symbol und Wort („Ein“/„Aus“), nicht über Grün (A-31). Textumschaltung je Zustand ist möglich („Ausschalten“/„Einschalten“, „Fortlaufend“/„Einzel“). Berechtigungssymbol und Ausstehend-Zustand (Befehl gesendet, Rückmeldung fehlt) sind Parameter.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Beschriftung (`Label`) | string | – | z. B. Bahnkontrolle, Heizungen, Querschnecke, Rührer, Regulierung, Standby, Pumpe, Füllsystem, Maschine schnell |
| Zustand (`IsChecked`) | bool? | – | true = Ein, false = Aus, null = teilweise (nur Sammelzustand) |
| Sammelzustand (`IsAggregate`) | bool | – | true bei „Automatik Produktion“ (HS-01): Ein nur, wenn alle Funktionen angewählt sind |
| Text teilweise (`PartialText`) | string | – | Standard „Teilweise“ |
| Text Ein (`OnText`), Text Aus (`OffText`) | string | – | Standard „Ein“/„Aus“; Varianten „Einschalten“/„Ausschalten“, „Fortlaufend“/„Einzel“ |
| Darstellung (`ToggleStyle`) | enum ToggleStyle { Switch, Button } | – | Switch Standard |
| Tastengröße (`ButtonSize`) | enum ToggleButtonSize { Default, Tile } | – | nur bei Button: Default = `Size.Touch.Default` hoch, Tile = `Size.Touch.Large` hoch (Kachelhöhe, HS-01) |
| Symbol (`Icon`) | Geometry? | – | optional |
| Befehl (`ToggleCommand`) | ICommand<bool> | – | Sollzustand |
| Ausstehend (`IsPending`) | bool | – | Befehl gesendet, Istzustand noch offen |
| Fehler (`ErrorText`) | string? | – | Text bei gestörter Funktion |
| Berechtigung erforderlich (`RequiresPermission`), Berechtigt (`IsAuthorized`) | bool | – | Schlüssel bzw. Schloss |
| Bedienbar (`IsEnabled`) | bool | – | false im ungeeigneten Betriebszustand |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Aus | `Brush.Button.Normal`, Kontur `Border.Thin`, Knopf links | `Icon.State.Off` und Wort „Aus“ |
| Ein | `Brush.Button.Active`, Text `Brush.Text.OnActive`, Knopf rechts, Bahn gefüllt (neutral, nicht grün) | `Icon.State.On` und Wort „Ein“ |
| Gedrückt | `Brush.Button.Pressed`, Kontur `Border.Medium` | dickere Kontur |
| Teilweise abgewählt (Sammelzustand) | `Brush.Button.Normal`, Kontur `Border.Medium` `Brush.Border.Control` | `Icon.State.Partial` (Strich im Kreis) und Wort „Teilweise“; Tooltip nennt die abgewählten Funktionen |
| Ausstehend | Zustand wie Soll, Kontur gestrichelt (`Border.Dash`) | `Icon.State.Pending` und Text „Wird gesetzt“ |
| Fehler | Kontur `Border.Thick` `Brush.Status.Error.Fg`, Fläche `Brush.Status.Error.Subtle` | `Icon.Status.Error` und Fehlertext |
| Deaktiviert | Kontur gestrichelt (`Border.Dash`), Text `Brush.Text.Disabled` | gestrichelte Kontur; Grund in Meldezeile (A-28) |
| Berechtigung | Normal | `Icon.Key` (berechtigt) bzw. `Icon.Lock` (nicht berechtigt) |

## Verwendet auf Seiten (IDs)
- [HS-01](../Seiten/HS-01_Produktion.md) – Produktion
- [HS-06](../Seiten/HS-06_Zufuehrung-Karton.md) – Zuführung Karton
- [HS-07](../Seiten/HS-07_Heissleim-Nordson.md) – Heißleim Nordson
- [HS-08](../Seiten/HS-08_Heissleim-Parameter.md) – Heißleim Parameter (inkl. Verwendung über Kompositmodul HM-28)
- [HS-10](../Seiten/HS-10_Zeitschaltuhr.md) – Zeitschaltuhr (inkl. Verwendung über Kompositmodul HM-30)
- [HS-11](../Seiten/HS-11_Hauptdosierer-1-und-2.md) – Hauptdosierer 1 & 2
- [HS-14](../Seiten/HS-14_Einzelgewichte.md) – Einzelgewichte
- [HS-16](../Seiten/HS-16_Schliessmaschine.md) – Schließmaschine
- [HS-19](../Seiten/HS-19_Nachdosierer.md) – Nachdosierer
- [HS-22](../Seiten/HS-22_Heizungen.md) – Heizungen
- [HS-23](../Seiten/HS-23_Regulierung.md) – Regulierung
- [HS-41](../Seiten/HS-41_Dosierer-Uebersicht.md) – Dosierer-Übersicht (inkl. Verwendung über Kompositmodul HM-20)

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die Liste ist aus den Abschnitten „Verwendete Module“ und den Elemente-Tabellen der HS-Seiten abgeleitet (Stand Konsolidierung nach Phase 3, Punkt 4); „inkl. Verwendung über Kompositmodul“ nennt Seiten, auf denen das Modul nur innerhalb eines Kompositmoduls vorkommt.

## Herkunft
- [DM-13](../../01_Design-Analyse/Module/DM-13_Umschalter.md) – Umschalter: Schiebeschalter
- [DM-19](../../01_Design-Analyse/Module/DM-19_Zustandstaste.md) – Zustandstaste: Taste mit Zustand
- [RM-10](../../02_Referenz-Analyse/Module/RM-10_Umschalter-Taste.md) – Umschalter-Taste: Umschalter-Taste, Anwahl-, Ein/Aus-Tasten, Fortlaufend/Einzel

## WPF-Umsetzung
- **Control:** `HM08_ToggleSwitch` (ControlTemplate auf `ToggleButton`), Ordner `src/.../Controls/`, Code-behind nur Dependency-Property-Deklarationen ohne Logik (Custom Control, A-73).
- **Typ:** `ControlTemplate` auf `ToggleButton` (Stile `HM08_SwitchStyle`, `HM08_ToggleButtonStyle`); `HM08_ToggleSwitch` als Control mit den Eigenschaften der Tabelle.
- **Dependency Properties:** `Label`, `IsChecked`, `OnText`, `OffText`, `ToggleStyle`, `ButtonSize`, `Icon`, `IsPending`, `ErrorText`, `RequiresPermission`, `IsAuthorized`; **Command:** `ToggleCommand`.
- **Ergänzung (Behebung der Prüfbefunde M2):** Im Sammelzustand „Teilweise“ (`IsChecked = null`) zeigt die Taste Tooltip und `AutomationProperties.HelpText` aus der neuen Eigenschaft `PartialTooltip` (Standardtext `HM08_Partial_Hint`; das ViewModel nennt darin die abgewählten Funktionen). Auf Touch meldet das Antippen den Zustand über `ToggleCommand`.
- **Maße:** Bahn `Size.Toggle.Width` × `Size.Toggle.Height`, Knopf `Size.Toggle.Knob`, ganze Zeile (≥ `Size.Touch.Default`) antippbar; Knopfbewegung ohne Verzögerung > 100 ms.
- **Symbole** (`Themes/Icons.xaml`, Schema `Icon.<Bereich>.<Name>`): Designsystem: `Icon.Key`, `Icon.Lock`, `Icon.State.Off`, `Icon.State.On`, `Icon.Status.Error`; **neu, hier definiert:** `Icon.State.Partial`, `Icon.State.Pending`.
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-08-P01 | Zustand ohne Farbe | Ein/Aus erkennbar an Knopfposition bzw. Symbol und Wort | offen |
| HM-08-P02 | Neutral | Ein-Zustand nicht grün (A-31) | offen |
| HM-08-P03 | Beispiele | DS-01 8 Umschalter, DS-04 je Karte 3 (Querschnecke, Rührer, Regulierung), DS-03 Tasten Heizung, Standby, Pumpe, Zeitplan, DS-05 Ein/Aus | offen |
| HM-08-P04 | Textumschaltung | Fortlaufend/Einzel und Ausschalten/Einschalten ersetzen das Wort | offen |
| HM-08-P05 | Fehler und Ausstehend | jeweils mit Symbol und Text | offen |
| HM-08-P06 | Sammelzustand | Automatik Produktion (HS-01) zeigt „Teilweise“ mit Symbol, solange mindestens eine Funktion abgewählt ist, sonst „Ein“ (RS-01-P09) | offen |
| HM-08-P07 | Touch | Trefferfläche ≥ `Size.Touch.Default` hoch | offen |
| HM-08-P08 | Kachelhöhe | `ButtonSize = Tile`: Taste `Size.Touch.Large` hoch, Zustand weiterhin mit Symbol und Wort, zweizeilige Beschriftung bricht um (HS-01 Tastenblock) | offen |
