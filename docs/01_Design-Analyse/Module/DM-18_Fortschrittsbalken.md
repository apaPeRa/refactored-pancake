# DM-18 – Fortschrittsbalken

## Funktion
Horizontaler Balken mit Prozentangabe für einen Füll- oder Lastgrad.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
| Name | Typ | Einheit | Wertebereich |
|---|---|---|---|
| Beschriftung | Text (`.resx`) | – | „Füllstand Tank“ (DS-03), „Auslastung:“ (DS-04) |
| Wert | Zahl | % | 0 bis 100; Bild 83 und 92 |
| Schwellen | Zahlen | % | nicht dokumentiert (Gelb bei 92 %, Grün bei 83 %) |

## Zustände und Darstellung
| Zustand | Darstellung |
|---|---|
| Normal | Balken mit Prozentzahl als Text in der Mitte (DS-03 grün `#00FF00` auf weiß, Rahmen grau; DS-04 gelb `#FFC000`, Text schwarz) |
| Schwelle überschritten | Farbwechsel laut Entwurf unerklärt; Annahme: zusätzlich Text/Symbol; Schwellen aus Referenz |
| Wert ungültig | im Bild nicht dargestellt; Annahme: leerer Balken, „---“ |

Die Prozentzahl steht immer als Text im Balken, damit der Wert nicht von der Farbe abhängt. Schreibweise im Entwurf „83%“ (ohne Leerzeichen), im neuen HMI „83 %“. Darstellung nur Anzeige.

## Verwendet auf Seiten (IDs)
- [DS-03](../Seiten/DS-03_Heissleim.md) – Heißleim
- [DS-04](../Seiten/DS-04_Dosierer.md) – Dosierer

DS-04: als Teil von [DM-20](DM-20_Dosierer-Karte.md) (Auslastung).

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DM-18-P01 | DS-03 | Füllstand Tank 83 %, grün | offen |
| DM-18-P02 | DS-04 | je Karte Auslastung 92 %, gelb | offen |
| DM-18-P03 | Wert als Text | Prozentzahl im Balken | offen |
| DM-18-P04 | Farbwechsel | nur zusätzlich zu Text/Symbol | offen |
