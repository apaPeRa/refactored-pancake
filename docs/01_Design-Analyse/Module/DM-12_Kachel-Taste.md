# DM-12 – Kachel-Taste

## Funktion
Große blaue Taste mit Beschriftung für Navigation oder Schnellzugriff in Menüs (Einstellungen) und die Produktionsseite. Auch ohne Beschriftung als reservierter Platz.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
| Name | Typ | Einheit | Wertebereich |
|---|---|---|---|
| Beschriftung | Text (`.resx`) | – | bis zu zwei Zeilen; Bild z. B. „Automatik“, „Zuführungen“, „Waagen“, leer |
| Ziel | Seiten-ID oder Befehl | – | im Bild nicht erkennbar (OP-10, OP-12) |
| Aktivierbar | Wahrheitswert | – | wahr/falsch |
| Größe | Auswahl | – | normal (Menükachel), klein (DS-02 „Beleuchtung“) |

## Zustände und Darstellung
| Zustand | Darstellung |
|---|---|
| Normal | Blau `#4472C4`, Text weiß (Fase im Entwurf nicht übernehmen) |
| Leer (reserviert) | gleich gestaltet, ohne Text; Bedienbarkeit unbekannt (OP-05); Annahme: sichtbar, aber nicht bedienbar |
| Gedrückt / gesperrt | im Bild nicht dargestellt |

Mehrzeilige Beschriftung mit Trennstrich ist ein Entwurfsartefakt (OP-13): im neuen HMI automatischer Umbruch. Keine Ein/Aus-Zustandsanzeige; Zustandstasten sind [DM-19](DM-19_Zustandstaste.md). Zustand wird nie nur über Farbe vermittelt (Agent.md Abschnitt 6): zusätzlich Symbol oder Text. Farben und Fasen des Entwurfs sind Schätzwerte bzw. PowerPoint-Artefakte und werden nicht übernommen.

## Verwendet auf Seiten (IDs)
- [DS-01](../Seiten/DS-01_Produktion.md) – Produktion
- [DS-02](../Seiten/DS-02_Einstellungen.md) – Einstellungen

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DM-12-P01 | DS-02 | 16 Kacheln im 2 × 4-Raster Mitte und rechts, davon 4 leer, plus kleine Taste „Beleuchtung“ | offen |
| DM-12-P02 | DS-01 | 6 Kachel-Tasten in 2 Reihen à 3 | offen |
| DM-12-P03 | Leere Kachel | ohne Text, gleiche Gestalt | offen |
| DM-12-P04 | Trennstrich | Beschriftung „Schließ-maschine“ ohne Trennstrich im Ressourcentext | offen |
