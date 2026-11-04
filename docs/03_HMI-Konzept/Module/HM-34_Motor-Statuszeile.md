# HM-34 – Motor-Statuszeile

## Funktion
Zeile je Servoantrieb (HS-39): Antriebsname, Diag Code, Strom Aktuell, Strom Max (Antippen setzt zurück), Strom Limit (Eingabe mit Schlüssel) und Meldung. Mit zwei Pfeiltasten (hoch/runter, [HM-19](HM-19_Blaettertasten.md)) erreicht man weitere Antriebe (im Bild vier). Aus [HM-11](HM-11_Anzeigefeld.md) (Anzeigewerte, rücksetzbar), [HM-12](HM-12_Eingabefeld-Schluesselsymbol.md) (Limit) und Textmeldung zusammengesetzt.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Antriebsname (`DriveName`) | string | – | z. B. „Antrieb Zuführung 2MA1“ |
| Diag Code (`DiagCode`) | int | – | Bild 0 |
| Strom aktuell (`CurrentActual`) | double | % | Bild 0,0 |
| Strom max (`CurrentMax`) | double | % | Bild −24,4; −17,5; 20,3; −9,6 |
| Strom Limit (`CurrentLimit`) | double | % | Bild 100,0 / 500,0 |
| Meldung (`Message`) | string? | – | Bild „Motorschutz ausgelöst“ |
| Max zurücksetzen (`ResetMaxCommand`) | ICommand | – | – |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Normal | Zeile `Brush.Surface`, Werte HM-11 | Beschriftung und Einheit |
| Fehler (Meldung vorhanden) | Zeile `Brush.Status.Error.Subtle` | `Icon.Status.Error` und Meldungstext |
| Max rücksetzbar | Feld mit Kontur `Border.Medium` beim Drücken | `Icon.Action.Reset` im Feld |
| Limit gesperrt | HM-12 nicht berechtigt | `Icon.Lock` |

## Verwendet auf Seiten (IDs)
- [HS-39](../Seiten/HS-39_System-und-Antriebsinfos.md) – System- und Antriebsinfos

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die HS-Dateien entstehen in Phase 3 (Punkt 4); die Links sind vorläufig.

## Herkunft
- [RM-33](../../02_Referenz-Analyse/Module/RM-33_Motor-Statuszeile.md) – Motor-Statuszeile: Antriebszeile mit Diag Code, Strom, Limit, Meldung
- Design: keine Entsprechung (Element nur in der Referenz).

## WPF-Umsetzung
- **Control:** `HM34_DriveStatusRow` (UserControl), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `UserControl` (`HM34_DriveStatusRow`), `Grid` mit festen Spalten.
- **Dependency Properties:** `DriveName`, `DiagCode`, `CurrentActual`, `CurrentMax`, `CurrentLimit`, `Message`; **Command:** `ResetMaxCommand`.
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-34-P01 | Spalten | Antrieb, Diag Code, Strom Aktuell, Strom Max, Strom Limit, Meldung | offen |
| HM-34-P02 | Bild | vier Antriebe, Meldung „Motorschutz ausgelöst“ bei allen | offen |
| HM-34-P03 | Rücksetzen | Antippen von Strom Max setzt zurück | offen |
| HM-34-P04 | Fehler | Meldung mit Symbol und Text | offen |
| HM-34-P05 | Navigation | weitere Antriebe über HM-19 | offen |
