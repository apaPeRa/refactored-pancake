# DM-04 – Meldezeile

## Funktion
Zeigt die aktuelle Meldung der Maschine (Nummer und Text) in der Kopfzeile. Rahmenelement auf allen Seiten.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
| Name | Typ | Einheit | Wertebereich |
|---|---|---|---|
| Meldungsnummer | Ganzzahl, dreistellig | – | Bild: „014“; Bereich unbekannt |
| Meldungstext | Text | – | Bild: „Sicherung 4F24 Auslaufband ausgelöst.“ |
| Schweregrad | Aufzählung | – | Bild nur Warnung (gelb); Aufzählung, z. B. Information / Warnung / Alarm, aus Referenz abzuleiten (OP-22) |

## Zustände und Darstellung
| Zustand | Darstellung |
|---|---|
| Meldung aktiv (Warnung) | Amber `#FFC000` mit orangebraunem Text `#C55A11`; Format „NNN: Text“; zusätzlich Symbol für den Schweregrad (Annahme), damit Zustand nicht nur über Farbe erkennbar ist |
| Alarm | im Bild nicht dargestellt; Annahme: eigene Farbe, anderes Symbol und Text „Alarm“ |
| Keine Meldung | im Bild nicht dargestellt; Annahme: neutrale Fläche, Text „Keine Meldung“ |
| Mehrere Meldungen | Verhalten nicht dargestellt (OP-22); Annahme: höchste Priorität zuerst, Zähler für weitere |

Der Text ist im Entwurf orangebraun auf Amber und damit kontrastschwach; im neuen HMI korrigieren.

## Verwendet auf Seiten (IDs)
- [DS-01](../Seiten/DS-01_Produktion.md) – Produktion
- [DS-02](../Seiten/DS-02_Einstellungen.md) – Einstellungen
- [DS-03](../Seiten/DS-03_Heissleim.md) – Heißleim
- [DS-04](../Seiten/DS-04_Dosierer.md) – Dosierer
- [DS-05](../Seiten/DS-05_Kartonzufuehrung.md) – Kartonzuführung

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DM-04-P01 | Format | „014: Sicherung 4F24 Auslaufband ausgelöst.“ | offen |
| DM-04-P02 | Platzhalter | identischer Text auf allen 5 Seiten, vermutlich Dummy | offen |
| DM-04-P03 | Lage | Kopfzeile zwischen Logo und Betriebsart | offen |
