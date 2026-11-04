# DM-06 – Uhrzeit und Datum

## Funktion
Zeigt Uhrzeit und Datum der Steuerung in der Kopfzeile ganz rechts.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
| Name | Typ | Einheit | Wertebereich |
|---|---|---|---|
| Uhrzeit | Zeit | h:mm | Bild „9:15“ (ohne führende Null); 24-Stunden-Format angenommen |
| Datum | Datum | TT.MM.JJJJ | Bild „06.01.2026“ |

## Zustände und Darstellung
| Zustand | Darstellung |
|---|---|
| Normal | Uhrzeit groß (ca. 22 px), Datum klein (ca. 14 px), Weiß auf Blau `#2E75B6` |
| Zeit ungültig | im Bild nicht dargestellt; Annahme: „--:--“ |

Format hängt später von der Sprache ab (`.resx`/Kultur, OP-03). Datum ist im Entwurf sehr klein; im neuen HMI vergrößern.

## Verwendet auf Seiten (IDs)
- [DS-01](../Seiten/DS-01_Produktion.md) – Produktion
- [DS-02](../Seiten/DS-02_Einstellungen.md) – Einstellungen
- [DS-03](../Seiten/DS-03_Heissleim.md) – Heißleim
- [DS-04](../Seiten/DS-04_Dosierer.md) – Dosierer
- [DS-05](../Seiten/DS-05_Kartonzufuehrung.md) – Kartonzuführung

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DM-06-P01 | Werte | „9:15“ und „06.01.2026“ | offen |
| DM-06-P02 | Schreibweise | Uhrzeit ohne führende Null, Datum mit Punkten | offen |
| DM-06-P03 | Seitenübergreifend | auf allen 5 Seiten identisch (Dummy) | offen |
