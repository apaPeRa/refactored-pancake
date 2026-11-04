# DS-02 – Einstellungen
- Quelle: `src_Data/Design/Seite_Einstellungen.png`   - Navigationspfad: Einstellung

## Zweck
Einstiegsseite für alle Einstellungen: Schnellzugriff links, Kachelmenü zu den Einstellungsbereichen in der Mitte und rechts, Schaltfläche „Sprache“ unten.

## Aufbau (Bereiche, Layout)
1. Rahmen wie in der [Design-Dokumentation](../Design-Dokumentation.md), Abschnitt 2; Brotkrümel „Einstellung“ (lachsfarben).
2. Linker grauer Bereich „Anwählen/Schnelle Einstellungen“ mit einer Taste.
3. Mittlerer grauer Bereich: Kachelraster 2 Spalten × 4 Reihen (8 Kacheln).
4. Rechter grauer Bereich: Kachelraster 2 Spalten × 4 Reihen (8 Kacheln).
5. Funktionsleiste mit Taste „Sprache“.

## Elemente
| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Rahmen (Benutzer, Navigationssymbole, Logo, Meldezeile, Betriebsart, Uhr, Kennzahlen 112 1/min, 245°) | Rahmen | wie DS-01 | DM-01 bis DM-06, DM-08 |
| Brotkrümel „Einstellung“ | Navigation | Pfad | DM-07 |
| Bereich „Anwählen/Schnelle Einstellungen“ | Gruppenbereich | Schnellzugriff | DM-11 |
| Taste „Beleuchtung“ | Kachel-Taste (kleiner, blau) | Funktion nicht beschrieben | DM-12 |
| Kachel „Zuführungen“ | Kachel-Taste | führt zu Zuführungen (Breadcrumb in DS-03, DS-05) | DM-12 |
| Kachel „Schließ-maschine“ (Text „Schließ-“ / „maschine“) | Kachel-Taste | Ziel nicht abgebildet | DM-12 |
| Kachel „Dosierer“ | Kachel-Taste | führt zu DS-04 | DM-12 |
| Kachel „Heizungen“ | Kachel-Taste | Ziel nicht abgebildet | DM-12 |
| Kachel (leer), Mitte Reihe 3 links | Kachel-Taste ohne Text | reservierter Platz | DM-12 |
| Kachel (leer), Mitte Reihe 3 rechts | Kachel-Taste ohne Text | reservierter Platz | DM-12 |
| Kachel „Waagen“ | Kachel-Taste | Ziel nicht abgebildet | DM-12 |
| Kachel „Packungs-register“ (Text „Packungs-“ / „register“) | Kachel-Taste | Ziel nicht abgebildet | DM-12 |
| Kachel „Nocken-schaltwerk“ (Text „Nocken-“ / „schaltwerk“) | Kachel-Taste | Ziel nicht abgebildet | DM-12 |
| Kachel „Handbetrieb“ | Kachel-Taste | Ziel nicht abgebildet | DM-12 |
| Kachel (leer), rechts Reihe 2 links | Kachel-Taste ohne Text | reservierter Platz | DM-12 |
| Kachel „Geräte“ | Kachel-Taste | Ziel nicht abgebildet | DM-12 |
| Kachel (leer), rechts Reihe 3 links | Kachel-Taste ohne Text | reservierter Platz | DM-12 |
| Kachel „EA Übersicht“ | Kachel-Taste | Ziel nicht abgebildet | DM-12 |
| Kachel „Bildschirm reinigen“ | Kachel-Taste | Ziel nicht abgebildet | DM-12 |
| Kachel „System-einstellungen“ (Text „System-“ / „einstellungen“) | Kachel-Taste | Ziel nicht abgebildet | DM-12 |
| Funktionsleiste | Leiste | Container | DM-09 |
| Taste „Sprache“ (grau) | Funktionstaste | Sprachumschaltung (vermutet) | DM-10 |

## Verwendete Module (IDs)
DM-01 bis DM-09 (Rahmen), DM-10, DM-11, DM-12.

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- Alle Kacheln im gleichen Zustand (normal). Gedrückt, gesperrt oder aktiv nicht dargestellt.
- Die vier leeren Kacheln sind gleich gestaltet wie belegte; ob sie bedienbar sind, ist unbekannt.
- Pop-up der Sprachauswahl ist nicht abgebildet.
- Berechtigungen nicht erkennbar.
- Kachelmenü ist spaltenweise gruppiert (Mitte: Maschinenteile, rechts: Systemfunktionen); eine Gruppenbeschriftung existiert nicht.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DS-02-P01 | Anzahl Kacheln | 16 Kacheln (2 × 4 Mitte, 2 × 4 rechts), davon 4 ohne Text | offen |
| DS-02-P02 | Beschriftungen Mitte | Zuführungen, Schließ-maschine, Dosierer, Heizungen, (leer), (leer), Waagen, Packungs-register | offen |
| DS-02-P03 | Beschriftungen rechts | Nocken-schaltwerk, Handbetrieb, (leer), Geräte, (leer), EA Übersicht, Bildschirm reinigen, System-einstellungen | offen |
| DS-02-P04 | Linker Bereich | Überschrift „Anwählen/Schnelle Einstellungen“, eine Taste „Beleuchtung“ | offen |
| DS-02-P05 | Funktionsleiste | Taste „Sprache“ | offen |
| DS-02-P06 | Brotkrümel | ein Segment „Einstellung“ | offen |
| DS-02-P07 | Rahmenwerte | wie DS-01 (112 1/min, 245°, 9:15, 06.01.2026) | offen |

## Offene Punkte
- Ziele der Kacheln mit Referenzseiten abgleichen: OP-12.
- Leere Kacheln, „Geräte“, „Beleuchtung“: OP-05; Sprache: OP-03.
- Mehrzeilige Kachelbeschriftung mit Trennstrich („Schließ-maschine“): Silbentrennung im Entwurf, im neuen HMI klären: OP-13.
