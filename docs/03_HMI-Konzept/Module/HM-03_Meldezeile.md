# HM-03 – Meldezeile

## Funktion
Zeigt die wichtigste aktuelle Maschinenmeldung (Nummer und Text) im Format „NNN: Text“ in der Kopfzeile ([HM-02](HM-02_Kopfzeile.md)). Antippen öffnet die Meldeanzeige (HS-38). Meldungsklassen der Referenz (RS-38): Betriebsstatus, Hinweis/Status, Störung; sie werden auf Ok, Warnung, Fehler abgebildet (A-49). Bei mehreren Meldungen erscheint die mit der höchsten Priorität, ein Zähler nennt die weiteren (Annahme, OP-22). Das Format „NNN: Text“ des Designs ersetzt die Sternchen der Referenz („*450*“).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Nummer (`Number`) | int? | – | 0 bis 999, dreistellig mit führenden Nullen (Bild „014“, Referenz „450“) |
| Text (`Text`) | string | – | Kurzbeschreibung, z. B. „Sicherung 4F24 Auslaufband ausgelöst.“ |
| Klasse (`Class`) | enum MessageClass { None, Operation, Notice, Fault } | – | Operation = Ok, Notice = Warnung, Fault = Fehler (A-49) |
| Weitere Meldungen (`AdditionalCount`) | int | Stk | 0 bis 999 |
| Öffnen (`OpenCommand`) | ICommand | – | Ziel HS-38 Meldeanzeige |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Keine Meldung | `Brush.Surface.Sunken`, Text `Brush.Text.Secondary` | Text „Keine Meldung“ |
| Betriebsstatus | `Brush.Status.Ok.Fill` Fläche, `Brush.Status.Ok.On` | `Icon.Status.Ok` und Klassenwort „Betrieb“ |
| Hinweis / Warnung | `Brush.Status.Warning.Fill` Fläche, Text `Brush.Status.Warning.On`, Kontur `Border.Medium` `Brush.Status.Warning.Fg` | `Icon.Status.Warning` und Klassenwort „Hinweis“ |
| Störung / Alarm | `Brush.Status.Error.Fill` Fläche, `Brush.Status.Error.On` | `Icon.Status.Error` und Klassenwort „Störung“ |
| Mehrere Meldungen | wie höchste Klasse | Zähler „+ n“ |
| Gedrückt | Kontur `Border.Medium` | dickere Kontur |

## Verwendet auf Seiten (IDs)
- [HS-01](../Seiten/HS-01_Produktion.md) – Produktion
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
- [HS-40](../Seiten/HS-40_Zufuehrungen.md) – Zuführungen
- [HS-41](../Seiten/HS-41_Dosierer-Uebersicht.md) – Dosierer-Übersicht
- [HS-42](../Seiten/HS-42_Waagen.md) – Waagen
- [HS-43](../Seiten/HS-43_Schichtplan.md) – Schichtplan

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die Liste ist aus den Abschnitten „Verwendete Module“ und den Elemente-Tabellen der HS-Seiten abgeleitet (Stand Konsolidierung nach Phase 3, Punkt 4); „inkl. Verwendung über Kompositmodul“ nennt Seiten, auf denen das Modul nur innerhalb eines Kompositmoduls vorkommt.

## Herkunft
- [DM-04](../../01_Design-Analyse/Module/DM-04_Meldezeile.md) – Meldezeile: Meldung in der Kopfzeile
- [RM-02](../../02_Referenz-Analyse/Module/RM-02_Meldezeile.md) – Meldezeile: Meldungsnummer und -text, Antippen öffnet die Meldeanzeige

## WPF-Umsetzung
- **Control:** `HM03_MessageLine` (UserControl), Ordner `src/.../Controls/`, Code-behind nur Dependency-Property-Deklarationen ohne Logik (Custom Control, A-73).
- **Typ:** `UserControl`; einzeilig, Text `TextTrimming=CharacterEllipsis`, vollständiger Text im Tooltip und in HS-38.
- **Dependency Properties:** `Number`, `Text`, `Class`, `AdditionalCount`; **Command:** `OpenCommand`.
- **Stil:** `DataTrigger` auf `Class` schaltet Fläche, Symbol und Wort; Wörter aus `.resx` (`Status_Warning_Word` usw.).
- **Symbole** (`Themes/Icons.xaml`, Schema `Icon.<Bereich>.<Name>`): Designsystem: `Icon.Status.Error`, `Icon.Status.Ok`, `Icon.Status.Warning`.
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-03-P01 | Format | „014: Sicherung 4F24 Auslaufband ausgelöst.“ | offen |
| HM-03-P02 | Klasse | jede Klasse mit eigenem Symbol und Wort, Farbe nur zusätzlich | offen |
| HM-03-P03 | Kontrast | Text auf Warnfläche 8,76 : 1 (Designsystem 1.2) | offen |
| HM-03-P04 | Keine Meldung | neutrale Fläche und Text „Keine Meldung“ | offen |
| HM-03-P05 | Antippen | öffnet HS-38 Meldeanzeige | offen |
| HM-03-P06 | Lage | Kopfzeile zwischen Logo und Betriebsart | offen |
