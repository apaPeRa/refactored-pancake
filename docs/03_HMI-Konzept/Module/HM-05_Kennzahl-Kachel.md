# HM-05 – Kennzahl-Kachel

## Funktion
Kachel mit Symbol und Messwert für eine Kennzahl. Instanzen im Rahmen: Geschwindigkeit (1/min) und Maschinenwinkel (°) in der Brotkrümelzeile. Auf Seiten dient sie für Kennzahlen wie Aktuelle Produktion, Letztes Gewicht, Mittelwert, Netto, Brutto. Optional mit kleinem Index unten rechts (Nummer des Dosierers/der Waage) und als antippbare Kachel, die ein Pop-up öffnet (Geschwindigkeit Soll → HS-03, Aktuelle Produktion → HS-02). Die rote Schrift des Sollwerts der Referenz entfällt (Rot nur für Fehler); der Sollwert ist durch Beschriftung „Soll“ und das Antippen-Symbol erkennbar.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Symbol (`Icon`) | Geometry | – | `Icon.Speed`, `Icon.Angle` u. a. |
| Beschriftung (`Label`) | string | – | optional, z. B. „Soll“, „Netto“ |
| Wert (`Value`) | double? | je Kennzahl: 1/min, °, g, Stk, %, h:m:s | Beispiele: 112 1/min, 245 °, 235,1 g, 874183 Stk; Winkel 0 bis 360 |
| Einheit (`Unit`) | string | – | „1/min“, „°“, „g“, „Stk“, „%“ |
| Format (`StringFormat`) | string | – | z. B. „N0“, „N1“ |
| Index (`Index`) | int? | – | optional, 1 bis 99 |
| Größe (`TileSize`) | enum TileSize { Frame, Content } | – | Frame: Mindestbreite 224 px |
| Bedienbar (`IsInteractive`) | bool | – | true öffnet Pop-up |
| Öffnen (`OpenCommand`) | ICommand | – | Ziel HS-02, HS-03 oder keines |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Anzeige | `Brush.Surface`, Kontur `Border.Thin`, Wert `Font.Size.Metric` `Brush.Text.Primary`, Einheit `Font.Size.Caption` `Brush.Text.Secondary`, `Size.Icon.M` | Symbol und Einheit als Text |
| Bedienbar | wie Anzeige, zusätzlich `Icon.Chevron` rechts | Chevron-Symbol; Höhe 64 px |
| Gedrückt | `Brush.Button.Pressed`, `Border.Medium` | dickere Kontur |
| Wert ungültig | wie Anzeige | Text „---“ |
| Mit Index | Zahl `Font.Size.Caption` unten rechts | Zahl als Text |

## Verwendet auf Seiten (IDs)
- [HS-01](../Seiten/HS-01_Produktion.md) – Produktion
- [HS-02](../Seiten/HS-02_Produktionszaehler.md) – Produktionszähler (Pop-up)
- [HS-04](../Seiten/HS-04_Einstellungen.md) – Einstellungen
- [HS-05](../Seiten/HS-05_Zufuehrung-Papier.md) – Zuführung Papier
- [HS-06](../Seiten/HS-06_Zufuehrung-Karton.md) – Zuführung Karton
- [HS-07](../Seiten/HS-07_Heissleim-Nordson.md) – Heißleim Nordson
- [HS-08](../Seiten/HS-08_Heissleim-Parameter.md) – Heißleim Parameter
- [HS-09](../Seiten/HS-09_Heissleim-Druck.md) – Heißleim Druck
- [HS-10](../Seiten/HS-10_Zeitschaltuhr.md) – Zeitschaltuhr
- [HS-11](../Seiten/HS-11_Hauptdosierer-1-und-2.md) – Hauptdosierer 1 & 2
- [HS-12](../Seiten/HS-12_Motorparameter.md) – Motorparameter (Hauptdosierer)
- [HS-13](../Seiten/HS-13_Kontrollwaage.md) – Kontrollwaage
- [HS-14](../Seiten/HS-14_Einzelgewichte.md) – Einzelgewichte
- [HS-15](../Seiten/HS-15_Trend.md) – Trend
- [HS-16](../Seiten/HS-16_Schliessmaschine.md) – Schließmaschine
- [HS-17](../Seiten/HS-17_Motorparameter-Schliessmaschine.md) – Motorparameter (Schließmaschine)
- [HS-18](../Seiten/HS-18_Gewichtskorrektur-Schliessmaschine.md) – Gewichtskorrektur (Schließmaschine)
- [HS-19](../Seiten/HS-19_Nachdosierer.md) – Nachdosierer
- [HS-20](../Seiten/HS-20_Motorparameter.md) – Motorparameter (Nachdosierer)
- [HS-21](../Seiten/HS-21_Gewichtskorrektur.md) – Gewichtskorrektur (Nachdosierer)
- [HS-22](../Seiten/HS-22_Heizungen.md) – Heizungen
- [HS-23](../Seiten/HS-23_Regulierung.md) – Regulierung
- [HS-24](../Seiten/HS-24_Bildschirm-reinigen.md) – Bildschirm reinigen
- [HS-25](../Seiten/HS-25_Nocken.md) – Nocken
- [HS-26](../Seiten/HS-26_Nockenuebersicht.md) – Nockenübersicht
- [HS-27](../Seiten/HS-27_Waagen-Kalibrieren.md) – Waagen Kalibrieren
- [HS-28](../Seiten/HS-28_Packungsregister.md) – Packungsregister
- [HS-29](../Seiten/HS-29_Produktionsstatistik.md) – Produktionsstatistik
- [HS-30](../Seiten/HS-30_Handbetrieb-Auswahl.md) – Handbetrieb Auswahl
- [HS-31](../Seiten/HS-31_Handbetrieb.md) – Handbetrieb
- [HS-32](../Seiten/HS-32_Geber-setzen.md) – Geber setzen
- [HS-33](../Seiten/HS-33_EA-Uebersicht.md) – EA-Übersicht
- [HS-34](../Seiten/HS-34_EA-Anzeige.md) – EA-Anzeige
- [HS-35](../Seiten/HS-35_Systemeinstellungen.md) – Systemeinstellungen
- [HS-36](../Seiten/HS-36_Service.md) – Service
- [HS-37](../Seiten/HS-37_Meldearchiv.md) – Meldearchiv
- [HS-38](../Seiten/HS-38_Meldeanzeige.md) – Meldeanzeige
- [HS-39](../Seiten/HS-39_System-und-Antriebsinfos.md) – System- und Antriebsinfos
- [HS-40](../Seiten/HS-40_Zuefuehrungen.md) – Zuführungen
- [HS-41](../Seiten/HS-41_Dosierer-Uebersicht.md) – Dosierer-Übersicht
- [HS-42](../Seiten/HS-42_Waagen.md) – Waagen
- [HS-43](../Seiten/HS-43_Schichtplan.md) – Schichtplan

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die HS-Dateien entstehen in Phase 3 (Punkt 4); die Links sind vorläufig.

## Herkunft
- [DM-08](../../01_Design-Analyse/Module/DM-08_Kennzahl-Kachel.md) – Kennzahl-Kachel: Kennzahlen Geschwindigkeit und Maschinenwinkel in der Rahmenzeile
- [RM-12](../../02_Referenz-Analyse/Module/RM-12_Kennzahl-Kachel.md) – Kennzahl-Kachel: Kennzahlen der Seiten (Produktion, Zähler, Kontrollwaage, Einzelgewichte)

## WPF-Umsetzung
- **Control:** `HM05_MetricTile` (UserControl), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `UserControl` (Anzeige) mit `ControlTemplate` für den Taster-Modus.
- **Dependency Properties:** `Icon`, `Label`, `Value`, `Unit`, `StringFormat`, `Index`, `TileSize`, `IsInteractive`; **Command:** `OpenCommand`.
- **Verwendung im Rahmen:** zwei Instanzen im `Grid` der Brotkrümelzeile (Spalten `10*` und `10*`), Zahlen mit `Typography.NumeralAlignment="Tabular"`.
- **Neue Symbole** (`Themes/Icons.xaml`): `Icon.Speed`, `Icon.Angle` (Designsystem); `Icon.Metric.Clock`, `Icon.Metric.Weight`, `Icon.Metric.Mean`, `Icon.Metric.Deviation` (neu).
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-05-P01 | Geschwindigkeit | Tachosymbol, „112 1/min“ | offen |
| HM-05-P02 | Maschinenwinkel | Winkelsymbol, „245 °“ | offen |
| HM-05-P03 | Format | Wert, geschütztes Leerzeichen, Einheit | offen |
| HM-05-P04 | Index | kleine Zahl unten rechts (Letztes Gewicht) | offen |
| HM-05-P05 | Antippen | Kennzahl mit Chevron öffnet das Pop-up | offen |
| HM-05-P06 | Farbe | Sollwert nicht rot | offen |
