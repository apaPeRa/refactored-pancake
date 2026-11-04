# DM-09 – Funktionsleiste

## Funktion
Hellblaue Leiste am unteren Rand als Container für seitenspezifische Funktionstasten ([DM-10](DM-10_Funktionstaste-grau.md)). Darf leer sein.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
| Name | Typ | Einheit | Wertebereich |
|---|---|---|---|
| Tasten | Liste von DM-10 | – | 0 bis n; im Bild 0 bis 3 (DS-03: 3, DS-01 und DS-02: je 1, DS-04 und DS-05: 0) |
| Anordnung | Reihe | – | von links nach rechts; Lücken im Entwurf ungleich |

## Zustände und Darstellung
| Zustand | Darstellung |
|---|---|
| Mit Tasten | Hellblaue Fläche `#AECAE8`, Tasten linksbündig |
| Leer | Fläche bleibt sichtbar (DS-04, DS-05); keine Platzhalter |

Die Leiste selbst hat keinen Zustand. Die Höhe soll für Tasten mit mindestens 48 px Höhe reichen (im Entwurf ca. 52 px).

## Verwendet auf Seiten (IDs)
- [DS-01](../Seiten/DS-01_Produktion.md) – Produktion
- [DS-02](../Seiten/DS-02_Einstellungen.md) – Einstellungen
- [DS-03](../Seiten/DS-03_Heissleim.md) – Heißleim
- [DS-04](../Seiten/DS-04_Dosierer.md) – Dosierer
- [DS-05](../Seiten/DS-05_Kartonzufuehrung.md) – Kartonzuführung

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DM-09-P01 | Tastenanzahl | DS-01: 1 (Schichtplan), DS-02: 1 (Sprache), DS-03: 3 (Temperatur, Druck, Zeitplan), DS-04: 0, DS-05: 0 | offen |
| DM-09-P02 | Lage | unten, Breite wie Inhaltsbereich | offen |
| DM-09-P03 | Leere Leiste | bleibt als Fläche sichtbar | offen |
