# DM-22 – Leimspuren-Grafik

## Funktion
Grafik eines Kartonzuschnitts mit Leimspuren, über die die 18 Wertfelder ([DM-17](DM-17_Eingabefeld-mit-Schluesselsymbol.md)) positioniert sind. DM-22 ist die Grafik und die Platzierung, DM-17 liefert Aussehen und Verhalten der Felder.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
| Name | Typ | Einheit | Wertebereich |
|---|---|---|---|
| Titel | Text | – | „Leimspuren“ (oben links, blauer Rahmen) |
| Leimspuren | Grafikelemente | – | 1 lange Spur links über die ganze Höhe; je 4 kurze Spuren oben und unten |
| Wertfelder | 18 × DM-17 | Einheit unbekannt (OP-19) | oben 200, 205, 205, 205, 205 und 225, 225, 225, 225; unten 300, 310, 310, 310, 310 und 325, 329, 329, 329 |
| Zuschnitt | Grafik | – | Karton `#B87A56`, Leimspur `#E8D5A8`, Rahmen `#4A7EBB` |

## Zustände und Darstellung
| Zustand | Darstellung |
|---|---|
| Normal | Zuschnitt mit hellen Leimspuren, Felder darüber (Position aus Lage abgeleitet) |
| Feld in Bearbeitung | Zustände gemäß [DM-17](DM-17_Eingabefeld-mit-Schluesselsymbol.md) |
| Spur aus / Fehler | im Bild nicht dargestellt |

Die Spur ist nur Grafik; Zustände entstehen im Feld. Die Grafik soll skalierbar sein (Vektor); Felder behalten Touch-Größe mindestens 48 px (im Entwurf ca. 45 × 25 px).

## Verwendet auf Seiten (IDs)
- [DS-05](../Seiten/DS-05_Kartonzufuehrung.md) – Kartonzuführung

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DM-22-P01 | Grafiktitel | „Leimspuren“ | offen |
| DM-22-P02 | Spuren | 1 lange linke, je 4 kurze oben und unten | offen |
| DM-22-P03 | Feldanzahl | 18 Wertfelder | offen |
| DM-22-P04 | Werte | oben 200/205/205/205/205 und 225/225/225/225, unten 300/310/310/310/310 und 325/329/329/329 | offen |
| DM-22-P05 | Aufteilung | Felder sind DM-17, Grafik ist DM-22 | offen |
