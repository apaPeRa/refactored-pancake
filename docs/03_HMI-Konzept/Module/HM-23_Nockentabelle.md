# HM-23 – Nockentabelle

## Funktion
Tabelle der Nocken des elektronischen Nockenschaltwerks mit den Spalten Nummer, Bezeichnung, Start (°), Ende (°) und Status ([HM-09](HM-09_Status-LED.md), kompakt). Antippen der Nummer öffnet die Einstellseite der Nocke (HS-25). Das Bild zeigt 20 Zeilen (Nr. 40 bis 59). Bei Zeilenhöhe `Size.Touch.Min` passen je nach Zeilenabstand 11 bis 12 Zeilen auf eine Seite (HS-26: 11 Zeilen mit `Size.Touch.Gap` zwischen den Nummernfeldern; `RowsPerPage` ist Parameter, nicht fest); weitere erreicht man mit [HM-19](HM-19_Blaettertasten.md) oder durch Wischen (A-52). Leere Nocken (0 °/0 °, ohne Bezeichnung) bleiben sichtbar. Bezeichnungen stehen im Quellwortlaut der Bilder (Beispieldaten); die Korrektur offensichtlicher Tippfehler („Hauptdoserer“, „Fehlaketausstoß“) ist eine Entscheidung über `.resx` (OP-35), keine stillschweigende Änderung.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Zeilen (`Rows`) | IReadOnlyList<CamRow> | – | Nummern 0 bis 1079 laut Handbuch, Bild 40 bis 59 |
| Nummer (`Number`) | int | – | 0 bis 1079 |
| Bezeichnung (`Name`) | string | – | z. B. „Start Hauptdosierer 1“ |
| Start (`StartAngle`), Ende (`EndAngle`) | double | ° | 0 bis 360 (Bild); Maschinenwinkel |
| Aktiv (`IsActive`) | bool | – | Maschine in der aktiven Phase der Nocke |
| Zeilen je Seite (`RowsPerPage`) | int | Stk | 1 bis 14, abgeleitet aus der verfügbaren Höhe; HS-26 zeigt 11 Zeilen (Nr. 40 bis 50 / 51 bis 59), weil nur das Nummernfeld Touch-Ziel ist und `Size.Touch.Gap` Abstand hält (Seitenannahme S26-1, A-67) |
| Auswahl (`SelectCommand`) | ICommand<int> | – | Nockennummer; Ziel HS-25 |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Inaktiv | Zeile `Brush.Surface`, LED Aus (HM-09) | `Icon.Status.Inactive` (leer) |
| Aktiv | Zeile `Brush.Surface` (kein Farbfüllung im Normalbetrieb, Designsystem 1.2), LED Ok (HM-09) | `Icon.Status.Ok` (Haken) und Wort „aktiv“ |
| Leere Nocke | Text `Brush.Text.Secondary` | „0 ° / 0 °“ und Bezeichnung „–“ |
| Gedrückt | `Brush.Button.Pressed` | Kontur `Border.Medium` |
| Ausgewählt | Kontur `Border.Thick` `Brush.Border.Focus` | Rahmen |

## Verwendet auf Seiten (IDs)
- [HS-26](../Seiten/HS-26_Nockenuebersicht.md) – Nockenübersicht

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die Liste ist aus den Abschnitten „Verwendete Module“ und den Elemente-Tabellen der HS-Seiten abgeleitet (Stand Konsolidierung nach Phase 3, Punkt 4); „inkl. Verwendung über Kompositmodul“ nennt Seiten, auf denen das Modul nur innerhalb eines Kompositmoduls vorkommt.

## Herkunft
- [RM-19](../../02_Referenz-Analyse/Module/RM-19_Nockentabelle.md) – Nockentabelle: Tabelle Nr., Bezeichnung, Start, Ende, Status-LED
- Design: keine Entsprechung (Element nur in der Referenz).

## WPF-Umsetzung
- **Control:** `HM23_CamTable` (UserControl), Ordner `src/.../Controls/`, Code-behind nur Dependency-Property-Deklarationen ohne Logik (Custom Control, A-73).
- **Typ:** `UserControl` (`HM23_CamTable`) auf Basis von `ItemsControl` (virtualisiert); Zeile `HM23_CamRow`.
- **Dependency Properties:** `Rows`, `RowsPerPage`, `SelectedNumber`; **Command:** `SelectCommand`.
- Zahlen mit tabellarischen Ziffern, Zeilenhöhe `Size.Touch.Min`; Abstand zwischen den Nummernfeldern `Size.Touch.Gap` (keine Ausnahme vom Mindestabstand).
- **Symbole** (`Themes/Icons.xaml`, Schema `Icon.<Bereich>.<Name>`): Designsystem: `Icon.Status.Inactive`, `Icon.Status.Ok`.
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-23-P01 | Spalten | Nr., Bezeichnung, Start, Ende, Status | offen |
| HM-23-P02 | Beispiel | Nr. 47 „Fehlpaketausstoß hinten 14B10“ 120 °/284 ° aktiv; Nr. 52 280 °/325 ° | offen |
| HM-23-P03 | Leere Nocken | Nr. 48, 50, 59 mit 0 °/0 ° | offen |
| HM-23-P04 | Status | LED mit Symbol und Wort, Zeilenfläche bleibt neutral (Designsystem 1.2) | offen |
| HM-23-P05 | Beispieltexte | Beispieldaten tragen den Quellwortlaut der Bildbeschriftungen („Hauptdoserer“, „Fehlaketausstoß“); die Korrektur der Schreibweise ist eine Entscheidung (OP-35), nicht stillschweigend | offen |
| HM-23-P06 | Antippen | Nockennummer öffnet HS-25 | offen |
| HM-23-P07 | Zeilenhöhe | ≥ `Size.Touch.Min` | offen |
