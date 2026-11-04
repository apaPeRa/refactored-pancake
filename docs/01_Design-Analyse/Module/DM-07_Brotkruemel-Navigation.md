# DM-07 – Brotkrümel-Navigation

## Funktion
Zeigt den Seitenpfad als Pfeilsegmente; das letzte Segment ist die aktuelle Seite. Antippbarkeit der Segmente ist nicht ersichtlich (OP-21).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
| Name | Typ | Einheit | Wertebereich |
|---|---|---|---|
| Segmente | Liste von Texten | – | 1 bis 3 Segmente im Bild (z. B. „Einstellung › Zuführungen › Heißleim“) |
| Aktuelles Segment | Index | – | letztes Segment |

## Zustände und Darstellung
| Zustand | Darstellung |
|---|---|
| Pfad | Pfeilförmige Segmente, kleiner schwarzer Text (ca. 14 px); DS-01 blau, übrige Seiten lachsfarben (Entwurfsinkonsistenz, nicht übernehmen) |
| Aktuelles Segment | im Bild nicht abgesetzt; Annahme: fett oder Markierung zusätzlich zur Position am Ende |
| Segment gedrückt | im Bild nicht dargestellt |

Die Farbe trägt keine Bedeutung. Schriftgröße ist für Touch zu klein; im neuen HMI anheben, Touch-Ziel mindestens 48 px, falls Segmente antippbar werden.

## Verwendet auf Seiten (IDs)
- [DS-01](../Seiten/DS-01_Produktion.md) – Produktion
- [DS-02](../Seiten/DS-02_Einstellungen.md) – Einstellungen
- [DS-03](../Seiten/DS-03_Heissleim.md) – Heißleim
- [DS-04](../Seiten/DS-04_Dosierer.md) – Dosierer
- [DS-05](../Seiten/DS-05_Kartonzufuehrung.md) – Kartonzuführung

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DM-07-P01 | Segmentanzahl | DS-01: 1, DS-02: 1, DS-03: 3, DS-04: 2, DS-05: 3 | offen |
| DM-07-P02 | Pfadtexte | Produktion / Einstellung / Einstellung › Zuführungen › Heißleim / Einstellung › Dosierer / Einstellung › Zuführungen › Karton | offen |
| DM-07-P03 | Farbe | DS-01 blau, übrige lachsfarben; im Dokument als Artefakt vermerkt | offen |
