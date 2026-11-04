# DM-08 – Kennzahl-Kachel

## Funktion
Kleine graue Kachel mit Symbol und Messwert für eine Maschinenkennzahl (Geschwindigkeit, Maschinenwinkel) in der Zeile des Brotkrümels. Instanzen: Geschwindigkeit und Maschinenwinkel.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
| Name | Typ | Einheit | Wertebereich |
|---|---|---|---|
| Symbol | Grafik | – | Tachosymbol (Geschwindigkeit), Winkelsymbol (Maschinenwinkel) |
| Wert | Zahl | Geschwindigkeit: 1/min; Winkel: ° | Bild 112 und 245; Winkel vermutlich 0 bis 360 (Annahme) |
| Einheit | Text | – | „1/min“, „°“ |

## Zustände und Darstellung
| Zustand | Darstellung |
|---|---|
| Normal | Graue Kachel `#7F7F7F`, Symbol und Wert in Weiß, Einheit als Text |
| Wert ungültig | im Bild nicht dargestellt; Annahme: „---“ |

Kachel ist im Entwurf möglicherweise antippbar (Rahmen mit Fase), nicht erkennbar (OP-21). Der Wert hat keinen Farbzustand.

## Verwendet auf Seiten (IDs)
- [DS-01](../Seiten/DS-01_Produktion.md) – Produktion
- [DS-02](../Seiten/DS-02_Einstellungen.md) – Einstellungen
- [DS-03](../Seiten/DS-03_Heissleim.md) – Heißleim
- [DS-04](../Seiten/DS-04_Dosierer.md) – Dosierer
- [DS-05](../Seiten/DS-05_Kartonzufuehrung.md) – Kartonzuführung

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DM-08-P01 | Geschwindigkeit | Tachosymbol, „112 1/min“ | offen |
| DM-08-P02 | Maschinenwinkel | Winkelsymbol, „245°“ | offen |
| DM-08-P03 | Seitenübergreifend | auf allen 5 Seiten identisch (Dummy) | offen |
