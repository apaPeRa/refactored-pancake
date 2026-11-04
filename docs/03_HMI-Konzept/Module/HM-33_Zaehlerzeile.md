# HM-33 – Zählerzeile

## Funktion
Zeile aus Beschriftung, Zähler und Zeitpunkt des Zurücksetzens (HS-02): „Aktuell“ und „Historie 1“ bis „Historie 12“ (13 Zeilen), Spaltenkopf „Datum / Uhrzeit“. Der Reset (Haltetaste, [HM-07](HM-07_Aktionstaste.md)) schiebt alle Einträge um eine Zeile nach unten. Zähler und Zeitpunkt sind Anzeigefelder ([HM-11](HM-11_Anzeigefeld.md)); eigen ist nur die Historienlogik der Zeile.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Zeilenname (`RowName`) | string | – | Aktuell, Historie 1 bis Historie 12 |
| Zähler (`Count`) | long | Stk | 0 bis 999999999 (Bild 874183, 7, 7636, 773682) |
| Zeitpunkt (`ResetTime`) | DateTime? | TT.MM.JJJJ hh:mm:ss | null = leer |
| Aktuell (`IsCurrent`) | bool | – | nur die erste Zeile |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Gefüllt | `Brush.Surface`, Zähler `Font.Size.Value` | Zähler und Zeitpunkt |
| Leer | Text `Brush.Text.Secondary` | Zähler „0“ und „--.--.---- --:--:--“ |
| Aktuell | Zeile `Font.Weight.Strong` | Beschriftung „Aktuell“ und Fettschrift |
| Nach Reset | Einträge verschoben | Zeitpunkt der neuen Historie 1 sichtbar |

## Verwendet auf Seiten (IDs)
- [HS-02](../Seiten/HS-02_Produktionszaehler.md) – Produktionszähler (Pop-up)

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die Liste ist aus den Abschnitten „Verwendete Module“ und den Elemente-Tabellen der HS-Seiten abgeleitet (Stand Konsolidierung nach Phase 3, Punkt 4); „inkl. Verwendung über Kompositmodul“ nennt Seiten, auf denen das Modul nur innerhalb eines Kompositmoduls vorkommt.

## Herkunft
- [RM-31](../../02_Referenz-Analyse/Module/RM-31_Zaehlerzeile.md) – Zählerzeile: Zeile Aktuell/Historie 1 bis 12 mit Zähler und Zeitpunkt
- Design: keine Entsprechung (Element nur in der Referenz).

## WPF-Umsetzung
- **Control:** `HM33_CounterRow` (UserControl), Ordner `src/.../Controls/`, Code-behind nur Dependency-Property-Deklarationen ohne Logik (Custom Control, A-73).
- **Typ:** `UserControl` (`HM33_CounterRow`) in einem `ItemsControl` (13 Zeilen, `Size.Touch.Min`).
- **Dependency Properties:** `RowName`, `Count`, `ResetTime`, `IsCurrent`; Reset-Logik im ViewModel (`CounterHistoryViewModel`).
- **Symbole** (`Themes/Icons.xaml`, Schema `Icon.<Bereich>.<Name>`): .
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-33-P01 | Zeilen | Aktuell und Historie 1 bis 12 | offen |
| HM-33-P02 | Werte | Bild 874183 / 09.04.2025 14:55:09 usw. | offen |
| HM-33-P03 | Leer | Platzhalterdatum und Zähler 0 | offen |
| HM-33-P04 | Reset | schiebt Einträge nach unten | offen |
| HM-33-P05 | Format | Zeitstempel TT.MM.JJJJ hh:mm:ss | offen |
