# DM-02 – Navigationsleiste

## Funktion
Senkrechte Symbolleiste der Seitenleiste mit Seitenwechsel: Home, Einstellungen, Meldungen (oben, unter der Benutzerkennung) und Zurück (ganz unten). Zuordnung der Symbole ist Annahme (A-07, OP-08, OP-21).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
| Name | Typ | Einheit | Wertebereich |
|---|---|---|---|
| Symbol Home | Symboltaste | – | Haus-Symbol, Ziel Produktion (DS-01) |
| Symbol Einstellungen | Symboltaste | – | Zahnrad, Ziel Einstellungen (DS-02) |
| Symbol Meldungen | Symboltaste | – | Sprechblase mit „!“ (gelb), Ziel Meldeanzeige (Annahme) |
| Symbol Zurück | Symboltaste | – | Rücktaste mit X, eine Ebene zurück (Annahme) |
| Hinweis Neue Meldung | Anzeige (optional) | – | im Bild nicht dargestellt; Annahme: Zähler/Punkt am Meldungs-Symbol |

## Zustände und Darstellung
| Zustand | Darstellung |
|---|---|
| Normal | weißes Symbol auf blauer Leiste (Meldungs-Symbol gelb) |
| Aktuelle Seite | im Bild nicht dargestellt; Annahme: zusätzliche Markierung (Balken oder Hintergrund), nicht nur Farbwechsel |
| Gedrückt / gesperrt | im Bild nicht dargestellt |

Die Symbole sind unbeschriftet. Für die Bedienung sind Beschriftung oder Tooltip in `.resx` vorzusehen. Touch-Ziel mindestens 48 px (besser 64 px); im Entwurf sind die Symbole klein.

## Verwendet auf Seiten (IDs)
- [DS-01](../Seiten/DS-01_Produktion.md) – Produktion
- [DS-02](../Seiten/DS-02_Einstellungen.md) – Einstellungen
- [DS-03](../Seiten/DS-03_Heissleim.md) – Heißleim
- [DS-04](../Seiten/DS-04_Dosierer.md) – Dosierer
- [DS-05](../Seiten/DS-05_Kartonzufuehrung.md) – Kartonzuführung

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DM-02-P01 | Symbole | 4 Symbole: Home, Zahnrad, Sprechblase mit „!“, Zurück | offen |
| DM-02-P02 | Reihenfolge | drei Symbole oben (Home, Einstellungen, Meldungen), Zurück ganz unten | offen |
| DM-02-P03 | Seitenübergreifend | auf allen 5 Seiten identisch | offen |
