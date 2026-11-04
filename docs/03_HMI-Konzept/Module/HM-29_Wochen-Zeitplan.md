# HM-29 – Wochen-Zeitplan

## Funktion
Raster aus sieben Tagesspalten (Montag bis Sonntag) für die Zeitschaltuhr des Heißleimgeräts (HS-10). Jede Spalte hat eine Kopfzelle mit Plus-Taste (mit Schlüssel) zum Anlegen einer Phase; Einträge sind antippbar und öffnen [HM-30](HM-30_Zeitplan-Eintrag-Pop-up.md). **Heizphase** (Start: Aufheizen auf Solltemperatur, Stopp: alle Heizungen aus) und **Absenkphase** (innerhalb einer Heizphase, reduzierte Temperatur) werden durch Symbol und Text unterschieden, nicht durch Rot/Türkis (A-54). Der Zeitplan läuft unabhängig von der SPS.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Einträge (`Entries`) | IReadOnlyList<ScheduleEntry> | – | je Day (DayOfWeek), Kind, Start, End (TimeOnly), ParentId |
| Art (`Kind`) | enum ScheduleKind { Heat, Setback } | – | – |
| Startzeit / Endzeit | TimeOnly? | hh:mm | 00:00 bis 23:59 (Bild 08:00 bis 16:00; 12:00 und 13:00 Absenkung) |
| Plus (`AddCommand`) | ICommand<DayOfWeek> | – | mit Schlüssel |
| Bearbeiten (`EditCommand`) | ICommand<ScheduleEntry> | – | öffnet HM-30 |
| Erster Wochentag (`FirstDay`) | DayOfWeek | – | Monday |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Spalte leer | Kopfzelle `Brush.Surface.Sunken`, Plus-Taste | Tagesname und Plus-Symbol `Icon.Add` |
| Heizphase | `Brush.Surface`, Kontur `Border.Medium` `Brush.Border.Control` | `Icon.Schedule.Heat` und Text „08:00 ein … 16:00 aus“ |
| Absenkphase | eingerückt innerhalb der Heizphase, Kontur gestrichelt (`Border.Dash`) | `Icon.Schedule.Setback` und Text „12:00 absenken“, „13:00 aufheizen“ |
| Gedrückt | `Brush.Button.Pressed` | Kontur `Border.Medium` |
| Berechtigung | Plus-Taste | `Icon.Key` bzw. `Icon.Lock` |
| Ungültig / Überschneidung | Kontur `Border.Thick` `Brush.Status.Error.Fg` | `Icon.Status.Error` und Text (Annahme, nicht beschrieben) |

## Verwendet auf Seiten (IDs)
- [HS-10](../Seiten/HS-10_Zeitschaltuhr.md) – Zeitschaltuhr

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die Liste ist aus den Abschnitten „Verwendete Module“ und den Elemente-Tabellen der HS-Seiten abgeleitet (Stand Konsolidierung nach Phase 3, Punkt 4); „inkl. Verwendung über Kompositmodul“ nennt Seiten, auf denen das Modul nur innerhalb eines Kompositmoduls vorkommt.

## Herkunft
- [RM-26](../../02_Referenz-Analyse/Module/RM-26_Wochen-Zeitplan.md) – Wochen-Zeitplan: sieben Tagesspalten Montag bis Sonntag mit Heiz- und Absenkphasen
- Design: keine Entsprechung (Element nur in der Referenz).

## WPF-Umsetzung
- **Control:** `HM29_WeekSchedule` (UserControl), Ordner `src/.../Controls/`, Code-behind nur Dependency-Property-Deklarationen ohne Logik (Custom Control, A-73).
- **Typ:** `UserControl` (`HM29_WeekSchedule`), `UniformGrid` mit 7 Spalten und `ItemsControl` je Tag.
- **Dependency Properties:** `Entries`, `FirstDay`; **Commands:** `AddCommand`, `EditCommand`.
- Eintragshöhe ≥ `Size.Touch.Default`; scrollt bei vielen Einträgen.
- **Symbole** (`Themes/Icons.xaml`, Schema `Icon.<Bereich>.<Name>`): Designsystem: `Icon.Key`, `Icon.Lock`, `Icon.Status.Error`; **neu, hier definiert:** `Icon.Add`, `Icon.Schedule.Heat`, `Icon.Schedule.Setback`.
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-29-P01 | Spalten | 7 Tage Montag bis Sonntag | offen |
| HM-29-P02 | Plus-Taste | je Tag mit Schlüssel | offen |
| HM-29-P03 | Phasen | Heiz- und Absenkphase mit Symbol und Zeit im Text | offen |
| HM-29-P04 | Schachtelung | Absenkphase innerhalb der Heizphase | offen |
| HM-29-P05 | Antippen | Eintrag öffnet HM-30 | offen |
