# DM-14 – Status-LED

## Funktion
Runde Anzeige für einen binären Zustand (erfüllt / nicht erfüllt) mit Beschriftung. Nur Anzeige, nicht bedienbar.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
| Name | Typ | Einheit | Wertebereich |
|---|---|---|---|
| Beschriftung | Text (`.resx`) | – | DS-03: Bereitschaft, Temperatur, Füllsystem, Tankfüllstand, Tank Klappe, Keine Störung, Kein Alarm; DS-04: „oben:“, „unten:“ |
| Zustand | Aufzählung | – | Bild nur „grün“ (erfüllt); weitere Zustände (aus, Warnung, Alarm) Annahme |

## Zustände und Darstellung
| Zustand | Darstellung |
|---|---|
| Erfüllt | grün `#00B000` (DS-03: mit dunklem Ring `#404040`; DS-04: flach `#70AD47`) plus Haken oder Text (Annahme) |
| Nicht erfüllt / aus | im Bild nicht dargestellt; Annahme: grauer Ring ohne Füllung plus Symbol |
| Warnung / Alarm | im Bild nicht dargestellt; Annahme: andere Form (Dreieck/Kreuz) plus Farbe |

Beschriftungen wie „Keine Störung“ sind positiv formuliert: grün = erfüllt. Die zwei Entwurfsvarianten (Ring/flach) sind zu einer zu vereinheitlichen. Zustand wird nie nur über Farbe vermittelt (Agent.md Abschnitt 6): zusätzlich Symbol oder Text. Farben und Fasen des Entwurfs sind Schätzwerte bzw. PowerPoint-Artefakte und werden nicht übernommen.

## Verwendet auf Seiten (IDs)
- [DS-03](../Seiten/DS-03_Heissleim.md) – Heißleim
- [DS-04](../Seiten/DS-04_Dosierer.md) – Dosierer

DS-04: als Teil von [DM-20](DM-20_Dosierer-Karte.md) (Füllstand Trichter oben/unten).

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DM-14-P01 | DS-03 | 7 LEDs in der Reihenfolge der Seite, alle grün | offen |
| DM-14-P02 | DS-04 | je Karte 2 LEDs „oben“, „unten“ | offen |
| DM-14-P03 | Nicht nur Farbe | Zustand zusätzlich über Symbol oder Text | offen |
| DM-14-P04 | Keine Bedienung | LED reagiert nicht auf Antippen | offen |
