# DM-17 – Eingabefeld mit Schlüsselsymbol

## Funktion
Weißes Feld mit Beschriftung zur Eingabe eines Sollwerts. Das Schlüsselsymbol kennzeichnet ein berechtigungspflichtiges Feld (A-08, OP-04). Die Eingabe erfolgt vermutlich über Pop-up mit Zahlenfeld (nicht abgebildet). Wird auch als Wertfeld in der Grafik [DM-22](DM-22_Leimspuren-Grafik.md) verwendet (dort ohne eigene Beschriftung).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
| Name | Typ | Einheit | Wertebereich |
|---|---|---|---|
| Beschriftung | Text (`.resx`) | – | „Ziel Füllstand:“, „Max Füllzeit:“; in DM-22 entfällt sie |
| Wert | Zahl | %, s (DS-03); Einheit in DS-05 unbekannt (OP-19) | Bild 50 %, 60 s, 200 bis 329 |
| Min / Max | Zahl | wie Wert | nicht abgebildet; aus Referenz |
| Berechtigung | Rolle | – | erforderliche Rolle unbekannt (OP-04) |

## Zustände und Darstellung
| Zustand | Darstellung |
|---|---|
| Berechtigt | weißes Feld, roter Text `#FF0000`, gelbes Schlüsselsymbol oben rechts |
| Nicht berechtigt | im Bild nicht dargestellt; Annahme: Wert sichtbar, Symbol als „gesperrt“ (Schloss), Antippen öffnet kein Pop-up |
| Eingabe aktiv | im Bild nicht dargestellt; Pop-up mit Zahlenfeld, Grenzen sichtbar |
| Ungültige Eingabe | im Bild nicht dargestellt; Meldung mit Text, nicht nur Rotfärbung |

Roter Text ist im Entwurf die Farbe für Eingabewerte, nicht für einen Fehler; im neuen HMI darf Rot nur Alarm bedeuten (Agent.md Abschnitt 6), daher Eingabewerte anders absetzen. In DS-05 ist das Symbol im Bild nur ca. 10 px groß.

## Verwendet auf Seiten (IDs)
- [DS-03](../Seiten/DS-03_Heissleim.md) – Heißleim
- [DS-05](../Seiten/DS-05_Kartonzufuehrung.md) – Kartonzuführung

DS-05: die 18 Wertfelder in der Grafik [DM-22](DM-22_Leimspuren-Grafik.md); DM-22 platziert, DM-17 liefert das Feld.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DM-17-P01 | DS-03 | „Ziel Füllstand: 50 %“, „Max Füllzeit: 60 s“, je mit Schlüsselsymbol | offen |
| DM-17-P02 | DS-05 | 18 Wertfelder (200 bis 329) innerhalb DM-22 | offen |
| DM-17-P03 | Anzeige vs. Eingabe | Abgrenzung zu DM-16 (kein Schlüssel, schwarz) | offen |
| DM-17-P04 | Nicht berechtigt | kein Pop-up; Zustand nicht nur über Farbe | offen |
