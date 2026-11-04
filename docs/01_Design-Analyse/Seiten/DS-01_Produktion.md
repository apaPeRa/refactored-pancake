# DS-01 – Produktion
- Quelle: `src_Data/Design/Seite_Produktion.png`   - Navigationspfad: Produktion

## Zweck
Startseite (Home) im Betrieb: Überblick über Geschwindigkeit, laufende und letzte Produktion, Versorgungs- und Linienzustand, Schnellzugriff auf Betriebsfunktionen (Tasten) und Zu-/Abschalten von Teilfunktionen (Umschalter).

## Aufbau (Bereiche, Layout)
1. Rahmen wie in der [Design-Dokumentation](../Design-Dokumentation.md), Abschnitt 2 (Seitenleiste, Kopfzeile, Brotkrümel „Produktion“ in Blau, Kennzahlen).
2. Obere Reihe (y 145–437): vier graue Kacheln nebeneinander: „Geschwindigkeit“ (schmal), „Produktion“, „EKW“ (breit, leer), „Versorgung“.
3. Untere Reihe (y 440–700): links grauer Bereich mit 6 blauen Tasten in 2 Reihen à 3; rechts grauer Bereich mit 8 Umschaltern in zwei Spalten (6 links, 2 rechts).
4. Funktionsleiste (hellblau): eine graue Taste „Schichtplan“.

## Elemente
| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Benutzerkreis „MM“, „Max Mustermann“, „Technik“ | Anzeige | angemeldeter Benutzer und Rolle | DM-01 |
| Symbole Home, Zahnrad, Sprechblase „!“, Zurück | Symboltasten | Navigation | DM-02 |
| Logo „APA-TEC GmbH AUTOMATION AND PACKAGING TECHNOLOGY“ | Grafik | Kopfzeile | DM-03 |
| „014: Sicherung 4F24 Auslaufband ausgelöst.“ | Meldezeile (gelb) | aktuelle Meldung | DM-04 |
| „Produktion“ mit Kreispfeilen (grün) | Anzeige | Betriebsart | DM-05 |
| „9:15“, „06.01.2026“ | Anzeige | Uhrzeit, Datum | DM-06 |
| Brotkrümel „Produktion“ | Navigation | Pfad (einziges Segment, blau) | DM-07 |
| „112 1/min“ mit Tachosymbol | Kennzahl | Maschinengeschwindigkeit | DM-08 |
| „245°“ mit Winkelsymbol | Kennzahl | Maschinenwinkel | DM-08 |
| Kachel „Geschwindigkeit“ | Gruppenbereich | enthält nur die Taste „Schnell“ (sonst leer) | DM-11 |
| Taste „Schnell“ (grün) | Zustandstaste | Geschwindigkeitsmodus; Funktion im Bild nicht erkennbar | DM-19 |
| Kachel „Produktion“ | Gruppenbereich | Produktionsdaten | DM-11 |
| „Rezeptanwahl“ / „Tolles Rezept“ | Beschriftung/Wert | gewähltes Rezept (Auswahl vermutet) | DM-15 |
| „Aktuelle Produktion“ / „9854“ | Beschriftung/Wert | Zählerwert | DM-15 |
| „Letzte Produktion“ / „14531“ | Beschriftung/Wert | Zählerwert | DM-15 |
| Kachel „EKW“ | Gruppenbereich | leer, nur Überschrift | DM-11 |
| Kachel „Versorgung“ | Gruppenbereich | Versorgung und Linienbetrieb | DM-11 |
| „Druckluft“ / „IO“ | Beschriftung/Wert | Zustand | DM-15 |
| „Papier“ / „IO“ | Beschriftung/Wert | Zustand | DM-15 |
| „Produkt“ / „IO“ | Beschriftung/Wert | Zustand | DM-15 |
| Zwischenüberschrift „Linienbetrieb“ | Text | Gruppentitel | DM-15 |
| „Bandwaage“ / „Bereit“ | Beschriftung/Wert | Zustand | DM-15 |
| „Folgemaschine“ / „Läuft“ | Beschriftung/Wert | Zustand | DM-15 |
| Taste „Automatik“ | Kachel-Taste (blau) | Funktion nicht beschrieben | DM-12 |
| Taste „Zuführung Papier“ | Kachel-Taste | Funktion nicht beschrieben (Navigation vermutet) | DM-12 |
| Taste „Zuführung Karton“ | Kachel-Taste | Funktion nicht beschrieben (Navigation vermutet) | DM-12 |
| Taste „Leerpakete ausblasen“ | Kachel-Taste | Funktion nicht beschrieben | DM-12 |
| Taste „Abfüllung“ | Kachel-Taste | Funktion nicht beschrieben | DM-12 |
| Taste „Bunker leerfahren“ | Kachel-Taste | Funktion nicht beschrieben | DM-12 |
| Umschalter „Bahnkontrolle“ | Umschalter (Knopf rechts, grün) | ein/aus | DM-13 |
| Umschalter „Heizungen“ | Umschalter | ein/aus | DM-13 |
| Umschalter „Gebläse Dornrad“ | Umschalter | ein/aus | DM-13 |
| Umschalter „Produktzuführung“ | Umschalter | ein/aus | DM-13 |
| Umschalter „Produktüberwachung“ | Umschalter | ein/aus | DM-13 |
| Umschalter „Rüttlung“ | Umschalter | ein/aus | DM-13 |
| Umschalter „Entstaubung“ | Umschalter (rechte Spalte) | ein/aus | DM-13 |
| Umschalter „Linienbetrieb“ | Umschalter (rechte Spalte) | ein/aus | DM-13 |
| Funktionsleiste | Leiste | Container | DM-09 |
| Taste „Schichtplan“ (grau) | Funktionstaste | öffnet Schichtplan (vermutet) | DM-10 |

## Verwendete Module (IDs)
DM-01, DM-02, DM-03, DM-04, DM-05, DM-06, DM-07, DM-08, DM-09, DM-10, DM-11, DM-12, DM-13, DM-15, DM-19 (Modulkandidaten, siehe Design-Dokumentation Abschnitt 8).

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- Alle 8 Umschalter stehen im Bild auf „ein“ (Knopf rechts, grün). Die Aus-Darstellung ist nicht zu sehen.
- „Schnell“ ist grün hinterlegt; weitere Zustände (z. B. „Langsam“) sind nicht sichtbar.
- Die Tasten haben im Bild nur einen Zustand; Gedrückt/Gesperrt nicht dargestellt.
- Meldezeile zeigt eine Warnung (gelb); Verhalten bei mehreren Meldungen nicht dargestellt.
- Pop-ups sind nicht abgebildet.
- Berechtigungen sind auf dieser Seite nicht erkennbar (keine Schlüsselsymbole).

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DS-01-P01 | Kacheln der oberen Reihe | vier Kacheln: Geschwindigkeit, Produktion, EKW, Versorgung | offen |
| DS-01-P02 | Texte der Kachel „Produktion“ | Rezeptanwahl, Tolles Rezept, Aktuelle Produktion 9854, Letzte Produktion 14531 | offen |
| DS-01-P03 | Kachel „Versorgung“ | Druckluft, Papier, Produkt je „IO“; Linienbetrieb: Bandwaage „Bereit“, Folgemaschine „Läuft“ | offen |
| DS-01-P04 | Kachel „EKW“ | nur Überschrift, ohne Inhalt | offen |
| DS-01-P05 | Tasten untere Reihe links | 6 Tasten: Automatik, Zuführung Papier, Zuführung Karton, Leerpakete ausblasen, Abfüllung, Bunker leerfahren | offen |
| DS-01-P06 | Umschalter | 8 Stück: Bahnkontrolle, Heizungen, Gebläse Dornrad, Produktzuführung, Produktüberwachung, Rüttlung, Entstaubung, Linienbetrieb; alle ein | offen |
| DS-01-P07 | Taste „Schnell“ | vorhanden in Kachel „Geschwindigkeit“, grün | offen |
| DS-01-P08 | Funktionsleiste | nur die Taste „Schichtplan“ | offen |
| DS-01-P09 | Rahmenwerte | 112 1/min, 245°, 9:15, 06.01.2026, Betriebsart „Produktion“, Meldung 014 | offen |
| DS-01-P10 | Brotkrümel | ein Segment „Produktion“ | offen |
| DS-01-P11 | Seitenleiste | MM, Max Mustermann, Technik; 4 Symbole | offen |

## Offene Punkte
- Funktion der Taste „Schnell“ und ihrer Zustände: OP-09.
- Bedeutung der sechs blauen Tasten (Funktion vs. Navigation): OP-10.
- Leere Kachel „EKW“: OP-06; Rezeptanwahl: OP-01; Schichtplan: OP-02; Benutzer: OP-04.
- „IO“ (vermutlich „in Ordnung“) ohne Legende; weitere Werte unbekannt: OP-11.
