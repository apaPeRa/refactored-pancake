# DM-05 – Betriebsart-Anzeige

## Funktion
Zeigt die aktuelle Betriebsart der Maschine mit Symbol und Text in der Kopfzeile.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
| Name | Typ | Einheit | Wertebereich |
|---|---|---|---|
| Betriebsart | Aufzählung (Text) | – | Bild nur „Produktion“; weitere Betriebsarten aus Referenz (OP-22) |
| Symbol | Grafik | – | Kreisförmige Pfeile (zu „Produktion“) |

## Zustände und Darstellung
| Zustand | Darstellung |
|---|---|
| Produktion | Grün `#70AD47`, Symbol Kreispfeile, Text „Produktion“ in Weiß (Text trägt den Zustand) |
| Andere Betriebsarten | im Bild nicht dargestellt; je Betriebsart eigenes Symbol und eigener Text, Farbe nur zusätzlich |

Interaktion (z. B. Wechsel der Betriebsart durch Antippen) ist nicht erkennbar.

## Verwendet auf Seiten (IDs)
- [DS-01](../Seiten/DS-01_Produktion.md) – Produktion
- [DS-02](../Seiten/DS-02_Einstellungen.md) – Einstellungen
- [DS-03](../Seiten/DS-03_Heissleim.md) – Heißleim
- [DS-04](../Seiten/DS-04_Dosierer.md) – Dosierer
- [DS-05](../Seiten/DS-05_Kartonzufuehrung.md) – Kartonzuführung

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DM-05-P01 | Text und Symbol | „Produktion“ mit Kreispfeilen | offen |
| DM-05-P02 | Farbe | grün | offen |
| DM-05-P03 | Seitenübergreifend | auf allen 5 Seiten identisch | offen |
