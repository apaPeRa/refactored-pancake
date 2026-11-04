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
| Benutzerkreis „MM“, „Max Mustermann“, „Technik“ | Anzeige | angemeldeter Benutzer und Rolle | [DM-01](../Module/DM-01_Benutzerkennung.md) |
| Symbole Home, Zahnrad, Sprechblase „!“, Zurück | Symboltasten | Navigation | [DM-02](../Module/DM-02_Navigationsleiste.md) |
| Logo „APA-TEC GmbH AUTOMATION AND PACKAGING TECHNOLOGY“ | Grafik | Kopfzeile | [DM-03](../Module/DM-03_Kopfzeile-Logo.md) |
| „014: Sicherung 4F24 Auslaufband ausgelöst.“ | Meldezeile (gelb) | aktuelle Meldung | [DM-04](../Module/DM-04_Meldezeile.md) |
| „Produktion“ mit Kreispfeilen (grün) | Anzeige | Betriebsart | [DM-05](../Module/DM-05_Betriebsart-Anzeige.md) |
| „9:15“, „06.01.2026“ | Anzeige | Uhrzeit, Datum | [DM-06](../Module/DM-06_Uhrzeit-und-Datum.md) |
| Brotkrümel „Produktion“ | Navigation | Pfad (einziges Segment, blau) | [DM-07](../Module/DM-07_Brotkruemel-Navigation.md) |
| „112 1/min“ mit Tachosymbol | Kennzahl | Maschinengeschwindigkeit | [DM-08](../Module/DM-08_Kennzahl-Kachel.md) |
| „245°“ mit Winkelsymbol | Kennzahl | Maschinenwinkel | [DM-08](../Module/DM-08_Kennzahl-Kachel.md) |
| Kachel „Geschwindigkeit“ | Gruppenbereich | enthält nur die Taste „Schnell“ (sonst leer) | [DM-11](../Module/DM-11_Gruppenbereich.md) |
| Taste „Schnell“ (grün) | Zustandstaste | Geschwindigkeitsmodus; Funktion im Bild nicht erkennbar | [DM-19](../Module/DM-19_Zustandstaste.md) |
| Kachel „Produktion“ | Gruppenbereich | Produktionsdaten | [DM-11](../Module/DM-11_Gruppenbereich.md) |
| „Rezeptanwahl“ / „Tolles Rezept“ | Beschriftung/Wert | gewähltes Rezept (Auswahl vermutet) | [DM-15](../Module/DM-15_Beschriftung-Wert-Zeile.md) |
| „Aktuelle Produktion“ / „9854“ | Beschriftung/Wert | Zählerwert | [DM-15](../Module/DM-15_Beschriftung-Wert-Zeile.md) |
| „Letzte Produktion“ / „14531“ | Beschriftung/Wert | Zählerwert | [DM-15](../Module/DM-15_Beschriftung-Wert-Zeile.md) |
| Kachel „EKW“ | Gruppenbereich | leer, nur Überschrift | [DM-11](../Module/DM-11_Gruppenbereich.md) |
| Kachel „Versorgung“ | Gruppenbereich | Versorgung und Linienbetrieb | [DM-11](../Module/DM-11_Gruppenbereich.md) |
| „Druckluft“ / „IO“ | Beschriftung/Wert | Zustand | [DM-15](../Module/DM-15_Beschriftung-Wert-Zeile.md) |
| „Papier“ / „IO“ | Beschriftung/Wert | Zustand | [DM-15](../Module/DM-15_Beschriftung-Wert-Zeile.md) |
| „Produkt“ / „IO“ | Beschriftung/Wert | Zustand | [DM-15](../Module/DM-15_Beschriftung-Wert-Zeile.md) |
| Zwischenüberschrift „Linienbetrieb“ (ohne Wert) | Text | Gruppentitel innerhalb der Kachel „Versorgung“; kein Beschriftung/Wert-Paar | [DM-11](../Module/DM-11_Gruppenbereich.md) (Unterüberschrift) |
| „Bandwaage“ / „Bereit“ | Beschriftung/Wert | Zustand | [DM-15](../Module/DM-15_Beschriftung-Wert-Zeile.md) |
| „Folgemaschine“ / „Läuft“ | Beschriftung/Wert | Zustand | [DM-15](../Module/DM-15_Beschriftung-Wert-Zeile.md) |
| Taste „Automatik“ | Kachel-Taste (blau) | Funktion nicht beschrieben | [DM-12](../Module/DM-12_Kachel-Taste.md) |
| Taste „Zuführung Papier“ | Kachel-Taste | Funktion nicht beschrieben (Navigation vermutet) | [DM-12](../Module/DM-12_Kachel-Taste.md) |
| Taste „Zuführung Karton“ | Kachel-Taste | Funktion nicht beschrieben (Navigation vermutet) | [DM-12](../Module/DM-12_Kachel-Taste.md) |
| Taste „Leerpakete ausblasen“ | Kachel-Taste | Funktion nicht beschrieben | [DM-12](../Module/DM-12_Kachel-Taste.md) |
| Taste „Abfüllung“ | Kachel-Taste | Funktion nicht beschrieben | [DM-12](../Module/DM-12_Kachel-Taste.md) |
| Taste „Bunker leerfahren“ | Kachel-Taste | Funktion nicht beschrieben | [DM-12](../Module/DM-12_Kachel-Taste.md) |
| Umschalter „Bahnkontrolle“ | Umschalter (Knopf rechts, grün) | ein/aus | [DM-13](../Module/DM-13_Umschalter.md) |
| Umschalter „Heizungen“ | Umschalter | ein/aus | [DM-13](../Module/DM-13_Umschalter.md) |
| Umschalter „Gebläse Dornrad“ | Umschalter | ein/aus | [DM-13](../Module/DM-13_Umschalter.md) |
| Umschalter „Produktzuführung“ | Umschalter | ein/aus | [DM-13](../Module/DM-13_Umschalter.md) |
| Umschalter „Produktüberwachung“ | Umschalter | ein/aus | [DM-13](../Module/DM-13_Umschalter.md) |
| Umschalter „Rüttlung“ | Umschalter | ein/aus | [DM-13](../Module/DM-13_Umschalter.md) |
| Umschalter „Entstaubung“ | Umschalter (rechte Spalte) | ein/aus | [DM-13](../Module/DM-13_Umschalter.md) |
| Umschalter „Linienbetrieb“ | Umschalter (rechte Spalte) | ein/aus | [DM-13](../Module/DM-13_Umschalter.md) |
| Funktionsleiste | Leiste | Container | [DM-09](../Module/DM-09_Funktionsleiste.md) |
| Taste „Schichtplan“ (grau) | Funktionstaste | öffnet Schichtplan (vermutet) | [DM-10](../Module/DM-10_Funktionstaste-grau.md) |

## Verwendete Module (IDs)
[DM-01](../Module/DM-01_Benutzerkennung.md), [DM-02](../Module/DM-02_Navigationsleiste.md), [DM-03](../Module/DM-03_Kopfzeile-Logo.md), [DM-04](../Module/DM-04_Meldezeile.md), [DM-05](../Module/DM-05_Betriebsart-Anzeige.md), [DM-06](../Module/DM-06_Uhrzeit-und-Datum.md), [DM-07](../Module/DM-07_Brotkruemel-Navigation.md), [DM-08](../Module/DM-08_Kennzahl-Kachel.md), [DM-09](../Module/DM-09_Funktionsleiste.md), [DM-10](../Module/DM-10_Funktionstaste-grau.md), [DM-11](../Module/DM-11_Gruppenbereich.md), [DM-12](../Module/DM-12_Kachel-Taste.md), [DM-13](../Module/DM-13_Umschalter.md), [DM-15](../Module/DM-15_Beschriftung-Wert-Zeile.md), [DM-19](../Module/DM-19_Zustandstaste.md) (Modulkandidaten, siehe Design-Dokumentation Abschnitt 8).

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
- Ziele von „Zuführung Papier“/„Zuführung Karton“ (Zwischenseite „Zuführungen“ fehlt im Design): OP-20; Seiten ohne Design (Schichtplan u. a.): OP-07.
- Bedeutung der Seitenleisten-Symbole und Antippbarkeit von Brotkrümel/Kennzahlen: OP-08, OP-21; identische Rahmenwerte: OP-22.
