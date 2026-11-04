# HM-18 – Auswahlfeld mit Pfeiltasten

## Funktion
Feld mit Pfeiltasten (◄ ►) zum Durchschalten einer Auswahl, mit oder ohne Schlüsselsymbol: Filtertyp (HS-27), Geber (HS-25), Datum der letzten 30 Tage (HS-29, Datumsnavigation von [HM-26](HM-26_Diagramm.md)), Nockennummer (HS-25). Übernahme je Seite sofort oder erst nach Bestätigung („Filter setzen“). Die Pfeile sind eigene 64-px-Tasten; das Feld selbst ist Anzeige.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Beschriftung (`Label`) | string? | – | z. B. „Filtertyp“, „Geber“ |
| Auswahlliste (`ItemsSource`) | IEnumerable | – | Filtertypen, Geber, 30 Tage, Nockennummern |
| Auswahlindex (`SelectedIndex`) | int | – | 0 bis Anzahl − 1 |
| Anzeigetext (`DisplayText`) | string | – | z. B. „IIR 5 56ms 8Hz“, „heute“ |
| Umlaufend (`IsCyclic`) | bool | – | Standard false (Listenende nicht beschrieben) |
| Übernahme erforderlich (`RequiresApply`) | bool | – | Standard false |
| Schlüssel (`RequiresPermission`), Berechtigt (`IsAuthorized`) | bool | – | – |
| Zurück (`PreviousCommand`), Vor (`NextCommand`) | ICommand | – | – |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Normal | `Brush.Surface`, Kontur `Border.Thin`, Text `Font.Size.Value`, Pfeiltasten `Brush.Button.Normal` `Size.Touch.Default` × `Size.Touch.Default` | Pfeilsymbole `Icon.Chevron` links/rechts und Anzeigetext |
| Am Listenende | betroffene Pfeiltaste deaktiviert, Kontur gestrichelt (`Border.Dash`) | gestrichelte Kontur |
| Ausgewählt, nicht übernommen | Normal | `Icon.State.Pending` und Text „Nicht übernommen“ |
| Gedrückt | `Brush.Button.Pressed`, `Border.Medium` | dickere Kontur |
| Berechtigung | Normal | `Icon.Key` bzw. `Icon.Lock` |

## Verwendet auf Seiten (IDs)
- [HS-10](../Seiten/HS-10_Zeitschaltuhr.md) – Zeitschaltuhr (inkl. Verwendung über Kompositmodul HM-30)
- [HS-15](../Seiten/HS-15_Trend.md) – Trend (inkl. Verwendung über Kompositmodul HM-26)
- [HS-25](../Seiten/HS-25_Nocken.md) – Nocken
- [HS-27](../Seiten/HS-27_Waagen-Kalibrieren.md) – Waagen Kalibrieren
- [HS-29](../Seiten/HS-29_Produktionsstatistik.md) – Produktionsstatistik

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die HS-Dateien entstehen in Phase 3 (Punkt 4); die Links sind vorläufig.

## Herkunft
- [RM-32](../../02_Referenz-Analyse/Module/RM-32_Auswahlfeld-mit-Pfeiltasten.md) – Auswahlfeld mit Pfeiltasten: Filtertyp, Geber, Datum, Nockennummer
- Design: keine Entsprechung (Element nur in der Referenz).

## WPF-Umsetzung
- **Control:** `HM18_SelectorField` (UserControl), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `UserControl` (`HM18_SelectorField`) aus zwei HM07-Tasten und einem Anzeigefeld.
- **Dependency Properties:** `Label`, `ItemsSource`, `SelectedIndex`, `DisplayText`, `IsCyclic`, `RequiresApply`, `RequiresPermission`, `IsAuthorized`; **Commands:** `PreviousCommand`, `NextCommand`.
- **Symbole** (`Themes/Icons.xaml`, Schema `Icon.<Bereich>.<Name>`): Designsystem: `Icon.Chevron`, `Icon.Key`, `Icon.Lock`; neu, definiert in anderem Modul: `Icon.State.Pending` (HM-08).
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-18-P01 | Filtertyp | Anzeige „IIR 5 56ms 8Hz“ mit Pfeilen und Schlüssel | offen |
| HM-18-P02 | Datum | 30 Tage, Pfeil links = früher (Annahme, OP-54) | offen |
| HM-18-P03 | Listenende | Pfeil deaktiviert statt Fehler | offen |
| HM-18-P04 | Touch | Pfeiltasten `Size.Touch.Default` × `Size.Touch.Default` | offen |
| HM-18-P05 | Übernahme | Auswahl erst nach „Filter setzen“ wirksam, ausstehender Zustand mit Text | offen |
