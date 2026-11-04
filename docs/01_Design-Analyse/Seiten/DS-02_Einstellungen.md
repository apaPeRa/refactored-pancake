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
| Rahmen (Benutzer, Navigationssymbole, Logo, Meldezeile, Betriebsart, Uhr, Kennzahlen 112 1/min, 245°) | Rahmen | wie DS-01 | [DM-01](../Module/DM-01_Benutzerkennung.md) bis [DM-06](../Module/DM-06_Uhrzeit-und-Datum.md), [DM-08](../Module/DM-08_Kennzahl-Kachel.md) |
| Brotkrümel „Einstellung“ | Navigation | Pfad | [DM-07](../Module/DM-07_Brotkruemel-Navigation.md) |
| Bereich „Anwählen/Schnelle Einstellungen“ | Gruppenbereich | Schnellzugriff | [DM-11](../Module/DM-11_Gruppenbereich.md) |
| Taste „Beleuchtung“ | Kachel-Taste (kleiner, blau) | Funktion nicht beschrieben | [DM-12](../Module/DM-12_Kachel-Taste.md) |
| Kachel „Zuführungen“ | Kachel-Taste | führt zu Zuführungen (Breadcrumb in DS-03, DS-05) | [DM-12](../Module/DM-12_Kachel-Taste.md) |
| Kachel „Schließ-maschine“ (Text „Schließ-“ / „maschine“) | Kachel-Taste | Ziel nicht abgebildet | [DM-12](../Module/DM-12_Kachel-Taste.md) |
| Kachel „Dosierer“ | Kachel-Taste | führt zu DS-04 | [DM-12](../Module/DM-12_Kachel-Taste.md) |
| Kachel „Heizungen“ | Kachel-Taste | Ziel nicht abgebildet | [DM-12](../Module/DM-12_Kachel-Taste.md) |
| Kachel (leer), Mitte Reihe 3 links | Kachel-Taste ohne Text | reservierter Platz | [DM-12](../Module/DM-12_Kachel-Taste.md) |
| Kachel (leer), Mitte Reihe 3 rechts | Kachel-Taste ohne Text | reservierter Platz | [DM-12](../Module/DM-12_Kachel-Taste.md) |
| Kachel „Waagen“ | Kachel-Taste | Ziel nicht abgebildet | [DM-12](../Module/DM-12_Kachel-Taste.md) |
| Kachel „Packungs-register“ (Text „Packungs-“ / „register“) | Kachel-Taste | Ziel nicht abgebildet | [DM-12](../Module/DM-12_Kachel-Taste.md) |
| Kachel „Nocken-schaltwerk“ (Text „Nocken-“ / „schaltwerk“) | Kachel-Taste | Ziel nicht abgebildet | [DM-12](../Module/DM-12_Kachel-Taste.md) |
| Kachel „Handbetrieb“ | Kachel-Taste | Ziel nicht abgebildet | [DM-12](../Module/DM-12_Kachel-Taste.md) |
| Kachel (leer), rechts Reihe 2 links | Kachel-Taste ohne Text | reservierter Platz | [DM-12](../Module/DM-12_Kachel-Taste.md) |
| Kachel „Geräte“ | Kachel-Taste | Ziel nicht abgebildet | [DM-12](../Module/DM-12_Kachel-Taste.md) |
| Kachel (leer), rechts Reihe 3 links | Kachel-Taste ohne Text | reservierter Platz | [DM-12](../Module/DM-12_Kachel-Taste.md) |
| Kachel „EA Übersicht“ | Kachel-Taste | Ziel nicht abgebildet | [DM-12](../Module/DM-12_Kachel-Taste.md) |
| Kachel „Bildschirm reinigen“ | Kachel-Taste | Ziel nicht abgebildet | [DM-12](../Module/DM-12_Kachel-Taste.md) |
| Kachel „System-einstellungen“ (Text „System-“ / „einstellungen“) | Kachel-Taste | Ziel nicht abgebildet | [DM-12](../Module/DM-12_Kachel-Taste.md) |
| Funktionsleiste | Leiste | Container | [DM-09](../Module/DM-09_Funktionsleiste.md) |
| Taste „Sprache“ (grau) | Funktionstaste | Sprachumschaltung (vermutet) | [DM-10](../Module/DM-10_Funktionstaste-grau.md) |

## Verwendete Module (IDs)
[DM-01](../Module/DM-01_Benutzerkennung.md) bis [DM-09](../Module/DM-09_Funktionsleiste.md) (Rahmen), [DM-10](../Module/DM-10_Funktionstaste-grau.md), [DM-11](../Module/DM-11_Gruppenbereich.md), [DM-12](../Module/DM-12_Kachel-Taste.md).

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
- Zwischenseite „Zuführungen“ (Ziel der Kachel „Zuführungen“) fehlt im Design: OP-20; Kachelziele ohne Designseite: OP-07.
- Seitenleisten-Symbole, Antippbarkeit: OP-08, OP-21; identische Rahmenwerte: OP-22.
