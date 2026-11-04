# HM-10 – Fortschrittsbalken

## Funktion
Horizontaler Balken mit Prozentzahl für Füll-, Lastgrad oder Zeitablauf (Füllstand Tank, Auslastung Dosierer, Reinigungsdauer, Prozessorauslastung). Die Zahl steht immer als Text im Balken, die Füllung ist neutral. Überschreitet der Wert eine Schwelle, erscheint die Statusfarbe zusammen mit Symbol und Wort (Schwellen nicht dokumentiert, konfigurierbar, OP-27). Rein Anzeige.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Beschriftung (`Label`) | string? | – | „Füllstand Tank“, „Auslastung:“, „Prozessorauslastung:“; leer erlaubt |
| Wert (`Value`) | double? | % | 0 bis 100 (Bild 83, 92; 91, 73, 77, 15) |
| Warnschwelle (`WarningThreshold`) | double? | % | z. B. 90 (Annahme), null = keine |
| Fehlerschwelle (`ErrorThreshold`) | double? | % | null = keine |
| Format (`StringFormat`) | string | – | „N0“ ergibt „83 %“ |
| Beschriftung links (`LabelPlacement`) | enum LabelPlacement { Above, Left } | – | Standard Above |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Normal | Füllung `Brush.Progress.Fill`, Bahn `Brush.Surface.Sunken`, Kontur `Border.Thin`, Höhe `Size.Progress.Height`, `Radius.Control` | Zahl „83 %“ im Balken (`Font.Size.Body`, Chip `Brush.Surface`) |
| Warnung (≥ Schwelle) | Füllung `Brush.Status.Warning.Fill`, Kontur `Border.Medium` `Brush.Status.Warning.Fg` | `Icon.Status.Warning` und Zahl |
| Fehler (≥ Schwelle) | Füllung `Brush.Status.Error.Fill` | `Icon.Status.Error` und Zahl |
| Wert ungültig | leere Bahn | Text „---“ |
| Voll (100 %) | Normal | Zahl „100 %“ |

## Verwendet auf Seiten (IDs)
- [HS-07](../Seiten/HS-07_Heissleim-Nordson.md) – Heißleim Nordson
- [HS-11](../Seiten/HS-11_Hauptdosierer-1-und-2.md) – Hauptdosierer 1 & 2
- [HS-19](../Seiten/HS-19_Nachdosierer.md) – Nachdosierer
- [HS-24](../Seiten/HS-24_Bildschirm-reinigen.md) – Bildschirm reinigen
- [HS-39](../Seiten/HS-39_System-und-Antriebsinfos.md) – System- und Antriebsinfos
- [HS-41](../Seiten/HS-41_Dosierer-Uebersicht.md) – Dosierer-Übersicht (inkl. Verwendung über Kompositmodul HM-20)

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die Liste ist aus den Abschnitten „Verwendete Module“ und den Elemente-Tabellen der HS-Seiten abgeleitet (Stand Konsolidierung nach Phase 3, Punkt 4); „inkl. Verwendung über Kompositmodul“ nennt Seiten, auf denen das Modul nur innerhalb eines Kompositmoduls vorkommt.

## Herkunft
- [DM-18](../../01_Design-Analyse/Module/DM-18_Fortschrittsbalken.md) – Fortschrittsbalken: Füllstand und Auslastung
- [RM-09](../../02_Referenz-Analyse/Module/RM-09_Fortschrittsbalken.md) – Fortschrittsbalken: Auslastung, Füllstand, Zeitablauf, CPU-Auslastung

## WPF-Umsetzung
- **Control:** `HM10_ProgressBar` (ControlTemplate auf `ProgressBar`), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `ControlTemplate` auf `ProgressBar` (`HM10_ProgressBar`), Zahl über `TextBlock` im Template.
- **Dependency Properties:** `Label`, `Value` (Basis `RangeBase.Value`), `WarningThreshold`, `ErrorThreshold`, `StringFormat`, `LabelPlacement`.
- **Zeitablauf (HS-24):** `Value` wird vom ViewModel getaktet, keine eigene Animation im Control.
- **Symbole** (`Themes/Icons.xaml`, Schema `Icon.<Bereich>.<Name>`): Designsystem: `Icon.Status.Error`, `Icon.Status.Warning`.
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-10-P01 | DS-03 | Füllstand Tank 83 % | offen |
| HM-10-P02 | DS-04 | je Karte Auslastung 92 % | offen |
| HM-10-P03 | Wert als Text | Prozentzahl im Balken, mit geschütztem Leerzeichen vor „%“ | offen |
| HM-10-P04 | Schwelle | Farbwechsel nur zusammen mit Symbol und Wort | offen |
| HM-10-P05 | Neutral | Normalzustand ohne Statusfarbe | offen |
