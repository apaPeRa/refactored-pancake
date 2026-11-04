# DM-16 – Wertfeld (Anzeige)

## Funktion
Weißes Feld mit Beschriftung zur Anzeige eines Messwerts. Nicht änderbar, kein Schlüsselsymbol. Abgrenzung zu [DM-17](DM-17_Eingabefeld-mit-Schluesselsymbol.md): dort Sollwert, änderbar, rot.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
| Name | Typ | Einheit | Wertebereich |
|---|---|---|---|
| Beschriftung | Text (`.resx`) | – | Tank, Verteiler, Pistole 1, Schlauch 1 (DS-03) |
| Wert | Zahl | °C | Bild 150, 150, 170, 160; Bereich aus Referenz |
| Einheit | Text | – | „°C“ mit Leerzeichen |

## Zustände und Darstellung
| Zustand | Darstellung |
|---|---|
| Normal | weißes Feld, schwarzer Text, Format „150 °C“ |
| Grenzwert verletzt | im Bild nicht dargestellt; Annahme: Symbol und Textmarke zusätzlich zur Farbe |
| Wert ungültig | im Bild nicht dargestellt; Annahme: „---“ |

Schwarzer Text kennzeichnet Anzeigewerte, roter Text (DM-17) Eingabewerte (Design-Dokumentation Abschnitt 4).

## Verwendet auf Seiten (IDs)
- [DS-03](../Seiten/DS-03_Heissleim.md) – Heißleim

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DM-16-P01 | Instanzen | 4 Felder: Tank 150 °C, Verteiler 150 °C, Pistole 1 170 °C, Schlauch 1 160 °C | offen |
| DM-16-P02 | Anzeige | keine Eingabe, kein Schlüsselsymbol | offen |
| DM-16-P03 | Format | Zahl, Leerzeichen, Einheit | offen |
