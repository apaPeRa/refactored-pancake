# DM-11 – Gruppenbereich

## Funktion
Grauer Container mit Überschrift, der zusammengehörige Elemente bündelt. Optional mit Zwischenüberschrift (z. B. „Linienbetrieb“ in „Versorgung“) und unterstrichener Überschrift (DS-03: „Status“, „Aktuelle Temperaturen:“).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
| Name | Typ | Einheit | Wertebereich |
|---|---|---|---|
| Überschrift | Text | – | „Geschwindigkeit“, „Produktion“, „EKW“, „Versorgung“, „Anwählen/Schnelle Einstellungen“, „Karton“ |
| Zwischenüberschrift | Text (optional) | – | „Linienbetrieb“ (ohne Wert), „Status“, „Aktuelle Temperaturen:“, „Einstellungen Leimspuren“ |
| Inhalt | beliebige Module | – | leer erlaubt (Kachel „EKW“, OP-06) |

## Zustände und Darstellung
| Zustand | Darstellung |
|---|---|
| Normal | Hellgrau `#D0D0D0` (DS-03: blau `#AFC3DE` mit Rand `#4A7EBB`), Überschrift oben links |
| Leer | nur Überschrift sichtbar |
| Hervorgehoben | im Bild nur bei Dosierer-Karte (DM-20, OP-18) |

Zwischenüberschrift ist reiner Text (kein eigener Container, kein Wert). Die Überschrift „Einstellungen Leimspuren“ (DS-05) ist im Entwurf weiß auf grau und damit kontrastschwach. Der Bereich hat keinen eigenen Zustand.

## Verwendet auf Seiten (IDs)
- [DS-01](../Seiten/DS-01_Produktion.md) – Produktion
- [DS-02](../Seiten/DS-02_Einstellungen.md) – Einstellungen
- [DS-03](../Seiten/DS-03_Heissleim.md) – Heißleim
- [DS-05](../Seiten/DS-05_Kartonzufuehrung.md) – Kartonzuführung

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DM-11-P01 | Überschriften DS-01 | Geschwindigkeit, Produktion, EKW, Versorgung | offen |
| DM-11-P02 | Zwischenüberschrift | „Linienbetrieb“ als Text ohne Wert | offen |
| DM-11-P03 | Leerer Bereich | EKW zeigt nur die Überschrift | offen |
| DM-11-P04 | DS-03 | Überschriften „Status“ und „Aktuelle Temperaturen:“ unterstrichen | offen |
