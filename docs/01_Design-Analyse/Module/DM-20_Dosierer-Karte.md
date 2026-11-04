# DM-20 – Dosierer-Karte

## Funktion
Karte für einen Dosierer. Sie fasst Sollwert, Trichterfüllstand, Antriebsschalter, Auslastung und zwei Tasten zusammen. Verwendet [DM-15](DM-15_Beschriftung-Wert-Zeile.md), [DM-14](DM-14_Status-LED.md), [DM-13](DM-13_Umschalter.md), [DM-18](DM-18_Fortschrittsbalken.md) und [DM-10](DM-10_Funktionstaste-grau.md); deren Details stehen dort.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
| Name | Typ | Einheit | Wertebereich |
|---|---|---|---|
| Titel | Text | – | Hauptdosierer 1, Hauptdosierer 2, Nachdosierer |
| Soll | Zahl | % (und g) | Bild 48 % entspricht 113 g |
| Regulierwert | Zahl | g | Bild 5.30g |
| Füllstand Trichter oben, unten | 2 × Status-LED | – | erfüllt / nicht erfüllt |
| Schalter Querschnecke, Rührer, Regulierung | 3 × Umschalter | – | ein / aus |
| Auslastung | Fortschrittsbalken | % | 0 bis 100; Bild 92 |
| Tasten Manuell, Entleeren | 2 × Funktionstaste | – | Befehl |
| Detail-Symbol | Symboltaste | – | vier Pfeile in Rahmen, öffnet vermutlich Detailseite (OP-17) |
| Hervorgehoben | Wahrheitswert | – | Nachdosierer im Bild hellblau (OP-18) |

## Zustände und Darstellung
| Zustand | Darstellung |
|---|---|
| Normal | Graue Karte `#D0D0D0`, Titel oben links, Detail-Symbol oben rechts |
| Hervorgehoben (ausgewählt/aktiv, Annahme) | hellblau `#AECAE8` (Nachdosierer); zusätzlich Text oder Symbol „Ausgewählt“, nicht nur Farbe |
| Tasten deaktiviert | Hauptdosierer 2: hellere Schrift (OP-18); zusätzlich Symbol oder Text „Gesperrt“ |
| Teilzustände | gemäß Modul der Bestandteile |

Die drei Karten sind im Entwurf gleich groß (ca. 400 px, Abstand ca. 20 px) mit identischen Platzhalterwerten.

## Verwendet auf Seiten (IDs)
- [DS-04](../Seiten/DS-04_Dosierer.md) – Dosierer

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DM-20-P01 | Karten | 3 Stück: Hauptdosierer 1, Hauptdosierer 2, Nachdosierer | offen |
| DM-20-P02 | Bestandteile je Karte | Soll/Regulierwert, 2 LEDs, 3 Umschalter, Auslastung, Tasten Manuell/Entleeren | offen |
| DM-20-P03 | Hervorhebung | Nachdosierer hellblau, mit Text/Symbol zusätzlich | offen |
| DM-20-P04 | Detail-Symbol | je Karte oben rechts | offen |
| DM-20-P05 | Keine Kopien | Bestandteile sind Verweise auf DM-10/13/14/15/18 | offen |
