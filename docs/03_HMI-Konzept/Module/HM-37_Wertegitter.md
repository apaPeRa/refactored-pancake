# HM-37 – Wertegitter (Einzelgewichte)

## Funktion
Gitter aus 10 Zeilen × 5 Spalten (50 Zellen) für die erfassten Einzelgewichte (HS-14): je Zelle Gewichtsfeld und Status-LED ([HM-09](HM-09_Status-LED.md), kompakt), ein Pfeil markiert das zuletzt erfasste Gewicht. Sortierung von oben nach unten und links nach rechts. Betriebsart über den Umschalter „Einzel / Fortlaufend“ ([HM-08](HM-08_Zustandstaste-Umschalter.md)): Einzel = manuelle Stichprobe, „Start“ ([HM-07](HM-07_Aktionstaste.md)) löscht alle Werte; Fortlaufend = nach 50 Werten wird überschrieben. Gut/schlecht über Symbol und Wort (A-55).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Zellen (`Cells`) | IReadOnlyList<WeightCell> | – | bis 50; je Weight, Quality |
| Gewicht (`Weight`) | double? | g | Bild 235,7; 235,0; 236,1; 234,0; 235,2 |
| Güte (`Quality`) | enum WeightQuality { Unknown, Good, Bad } | – | – |
| Letzte Zelle (`LastIndex`) | int | – | 0 bis 49 |
| Modus (`Mode`) | enum SamplingMode { Single, Continuous } | – | – |
| Kapazität (`Capacity`) | int | Stk | 50 |
| Befehle | ICommand | – | `StartCommand`, `ToggleModeCommand` |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Gut | Zelle `Brush.Surface`, LED Ok | `Icon.Status.Ok` und Wort „gut“ |
| Schlecht | Zelle `Brush.Status.Warning.Subtle` | `Icon.Status.Warning` und Wort „schlecht“ |
| Leere Zelle | Text `Brush.Text.Secondary` | Text „–“ |
| Letzter Wert | Kontur `Border.Thick` `Brush.Border.Focus` | Pfeilsymbol `Icon.Marker.Last` an der Zelle |
| Einzel | Umschalter Aus/„Einzel“ | Wort „Einzel“ |
| Fortlaufend | Umschalter Ein/„Fortlaufend“ | Wort „Fortlaufend“ |

## Verwendet auf Seiten (IDs)
- [HS-14](../Seiten/HS-14_Einzelgewichte.md) – Einzelgewichte

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die HS-Dateien entstehen in Phase 3 (Punkt 4); die Links sind vorläufig.

## Herkunft
- [RM-36](../../02_Referenz-Analyse/Module/RM-36_Wertegitter.md) – Wertegitter: Gitter 10 × 5 mit Gewichtswert und Status-LED je Zelle
- Design: keine Entsprechung (Element nur in der Referenz).

## WPF-Umsetzung
- **Control:** `HM37_ValueGrid` (UserControl), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `UserControl` (`HM37_ValueGrid`) mit `UniformGrid` (Zeilen 10, Spalten 5), Zelle `HM37_Cell`.
- **Dependency Properties:** `Cells`, `LastIndex`, `Mode`, `Capacity`; **Commands:** `StartCommand`, `ToggleModeCommand`.
- Zellhöhe ≥ `Size.Touch.Min`.
- **Neue Symbole** (`Themes/Icons.xaml`): `Icon.Marker.Last` (neu).
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-37-P01 | Raster | 10 Zeilen × 5 Spalten = 50 Zellen | offen |
| HM-37-P02 | Letzter Wert | Pfeil markiert das zuletzt erfasste Gewicht | offen |
| HM-37-P03 | Gut/schlecht | LED mit Symbol und Wort | offen |
| HM-37-P04 | Modus | Einzel/Fortlaufend, Fortlaufend überschreibt nach 50 | offen |
| HM-37-P05 | Start | löscht alle Werte im Modus Einzel | offen |
