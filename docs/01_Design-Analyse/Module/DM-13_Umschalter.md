# DM-13 – Umschalter

## Funktion
Beschrifteter Ein/Aus-Schalter (Schiebeschalter) für eine Teilfunktion. Knopf rechts = ein.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
| Name | Typ | Einheit | Wertebereich |
|---|---|---|---|
| Beschriftung | Text (`.resx`) | – | z. B. Bahnkontrolle, Heizungen, Querschnecke, Rührer, Regulierung |
| Zustand | Wahrheitswert | – | ein / aus |
| Aktivierbar | Wahrheitswert | – | wahr/falsch |

## Zustände und Darstellung
| Zustand | Darstellung |
|---|---|
| Ein | Knopf rechts, grün `#70AD47`, Bahn grau `#A6A6A6`; zusätzlich Text/Symbol „Ein“ (Annahme) |
| Aus | im Bild nicht dargestellt; Annahme: Knopf links, grau, zusätzlich Text/Symbol „Aus“ |
| Gesperrt | im Bild nicht dargestellt; Annahme: Schloss-Symbol |

Der Zustand folgt aus der Knopfposition (nicht nur der Farbe). Im Bild stehen alle 8 + 9 Umschalter auf „ein“. Touch-Ziel mindestens 48 px; im Entwurf ca. 95 × 25 px und zu klein. Die Beschriftung steht links, die Knöpfe sind im Entwurf versetzt (Artefakt).

## Verwendet auf Seiten (IDs)
- [DS-01](../Seiten/DS-01_Produktion.md) – Produktion
- [DS-04](../Seiten/DS-04_Dosierer.md) – Dosierer

DS-04: als Teil von [DM-20](DM-20_Dosierer-Karte.md) (Querschnecke, Rührer, Regulierung).

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DM-13-P01 | DS-01 | 8 Umschalter, alle ein | offen |
| DM-13-P02 | DS-04 | je Karte 3 Umschalter (Querschnecke, Rührer, Regulierung), alle ein | offen |
| DM-13-P03 | Aus-Darstellung | Knopf links plus Text/Symbol | offen |
| DM-13-P04 | Knopfposition | Zustand erkennbar ohne Farbe | offen |
