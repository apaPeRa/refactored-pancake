# DS-05 – Kartonzuführung
- Quelle: `src_Data/Design/Seite_Kartonzufuehrung.png`   - Navigationspfad: Einstellung › Zuführungen › Karton

## Zweck
Zuführung Karton ein-/ausschalten und die Einstellungen der Leimspuren (je Spur ein Wert) auf einer Zuschnittsgrafik einstellen.

## Aufbau (Bereiche, Layout)
1. Rahmen wie in der [Design-Dokumentation](../Design-Dokumentation.md), Abschnitt 2; Brotkrümel mit 3 Segmenten.
2. Ein großer grauer Bereich. Links: Text „Karton“ mit Taste „Ein / Aus“ und Text „Einstellungen Leimspuren“ (in Weiß). Rechts: Grafik „Leimspuren“ (Kartonzuschnitt mit Leimspuren und 18 Wertfeldern).
3. Funktionsleiste leer.

## Elemente
| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Rahmen (Benutzer, Navigationssymbole, Logo, Meldezeile, Betriebsart, Uhr, Kennzahlen 112 1/min, 245°) | Rahmen | wie DS-01 | [DM-01](../Module/DM-01_Benutzerkennung.md) bis [DM-06](../Module/DM-06_Uhrzeit-und-Datum.md), [DM-08](../Module/DM-08_Kennzahl-Kachel.md) |
| Brotkrümel „Einstellung“, „Zuführungen“, „Karton“ | Navigation | Pfad, 3 Segmente | [DM-07](../Module/DM-07_Brotkruemel-Navigation.md) |
| Text „Karton“ | Beschriftung | Bereichstitel | [DM-11](../Module/DM-11_Gruppenbereich.md) |
| Taste „Ein / Aus“ (grün) | Zustandstaste | Kartonzuführung ein/aus | [DM-19](../Module/DM-19_Zustandstaste.md) |
| Text „Einstellungen Leimspuren“ (weiß) | Beschriftung | Zwischenüberschrift; darunter ist der Bereich links leer | [DM-11](../Module/DM-11_Gruppenbereich.md) |
| Grafik „Leimspuren“ (Titel oben links in der Grafik, blauer Rahmen) | Grafik | Kartonzuschnitt mit Leimspuren | [DM-22](../Module/DM-22_Leimspuren-Grafik.md) |
| Leimspuren (helle senkrechte Balken) | Grafik | 1 lange Spur links über die ganze Höhe, je 4 kurze Spuren oben und unten (jeweils die erste direkt neben der langen Spur) | [DM-22](../Module/DM-22_Leimspuren-Grafik.md) |
| Wertfelder oben, Reihe 1 | Eingabefeld (weiß, rot, kleines gelbes Symbol oben rechts) | 200, 205, 205, 205, 205 | [DM-17](../Module/DM-17_Eingabefeld-mit-Schluesselsymbol.md) (in Grafik [DM-22](../Module/DM-22_Leimspuren-Grafik.md) platziert) |
| Wertfelder oben, Reihe 2 | Eingabefeld | 225, 225, 225, 225 | [DM-17](../Module/DM-17_Eingabefeld-mit-Schluesselsymbol.md) (in Grafik [DM-22](../Module/DM-22_Leimspuren-Grafik.md) platziert) |
| Wertfelder unten, Reihe 1 | Eingabefeld | 300, 310, 310, 310, 310 | [DM-17](../Module/DM-17_Eingabefeld-mit-Schluesselsymbol.md) (in Grafik [DM-22](../Module/DM-22_Leimspuren-Grafik.md) platziert) |
| Wertfelder unten, Reihe 2 | Eingabefeld | 325, 329, 329, 329 | [DM-17](../Module/DM-17_Eingabefeld-mit-Schluesselsymbol.md) (in Grafik [DM-22](../Module/DM-22_Leimspuren-Grafik.md) platziert) |
| Funktionsleiste (leer) | Leiste | Container, ohne Tasten | [DM-09](../Module/DM-09_Funktionsleiste.md) |

Anordnung der Wertfelder (von links nach rechts, Position im Zuschnitt):

| Reihe | Werte |
|---|---|
| oben 1 (an der oberen Klappenkante) | 200 · 205 · 205 · 205 · 205 |
| oben 2 (unterhalb der Kante, im Zuschnitt) | – · 225 · 225 · 225 · 225 |
| unten 1 (an der unteren Kante) | 300 · 310 · 310 · 310 · 310 |
| unten 2 (unterhalb, auf den unteren Klappen) | – · 325 · 329 · 329 · 329 |

## Verwendete Module (IDs)
[DM-01](../Module/DM-01_Benutzerkennung.md) bis [DM-09](../Module/DM-09_Funktionsleiste.md) (Rahmen), [DM-11](../Module/DM-11_Gruppenbereich.md), [DM-17](../Module/DM-17_Eingabefeld-mit-Schluesselsymbol.md), [DM-19](../Module/DM-19_Zustandstaste.md), [DM-22](../Module/DM-22_Leimspuren-Grafik.md). Aufteilung: [DM-22](../Module/DM-22_Leimspuren-Grafik.md) ist die Grafik (Kartonzuschnitt, Leimspuren, Platzierung der Felder), [DM-17](../Module/DM-17_Eingabefeld-mit-Schluesselsymbol.md) sind die 18 Wertfelder (Eingabefeld mit Schlüssel) darin.

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- Taste „Ein / Aus“ im Bild grün; Aus-Zustand nicht dargestellt.
- Die 18 Wertfelder sind rot beschriftet und tragen ein sehr kleines gelbes Symbol oben rechts (vermutlich Schlüssel wie in DS-03, im Bild zu klein für sichere Erkennung). Annahme: berechtigungspflichtige Eingabefelder.
- Einheit der Werte nicht abgebildet; Eingabe-Pop-up nicht abgebildet.
- Die Felder liegen über den Leimspuren; die Felder 200 und 300 stehen über bzw. unter der langen linken Spur (Zuordnung aus der Lage abgeleitet).
- Funktionsleiste leer.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DS-05-P01 | Brotkrümel | Einstellung › Zuführungen › Karton | offen |
| DS-05-P02 | Bedienbereich links | Text „Karton“, grüne Taste „Ein / Aus“, Text „Einstellungen Leimspuren“ | offen |
| DS-05-P03 | Grafiktitel | „Leimspuren“ | offen |
| DS-05-P04 | Anzahl Wertfelder | 18 (5 + 4 oben, 5 + 4 unten) | offen |
| DS-05-P05 | Werte oben | 200, 205, 205, 205, 205 und 225, 225, 225, 225 | offen |
| DS-05-P06 | Werte unten | 300, 310, 310, 310, 310 und 325, 329, 329, 329 | offen |
| DS-05-P07 | Leimspuren | 1 lange linke Spur, je 4 kurze Spuren oben und unten (jeweils die erste direkt neben der langen Spur) | offen |
| DS-05-P08 | Funktionsleiste | leer | offen |
| DS-05-P09 | Rahmenwerte | wie DS-01 | offen |

## Offene Punkte
- Einheit der Leimspurwerte und Bedeutung der Felder (Position/Länge?): OP-19.
- Symbol an Wertfeldern vs. Schlüsselsymbol: OP-04.
- Abgleich mit Referenz (Zuführung Karton): OP-15.
- Zwischenseite „Zuführungen“ (mittleres Brotkrümel-Segment) fehlt im Design: OP-20.
- Seitenleisten-Symbole, Antippbarkeit: OP-08, OP-21; identische Rahmenwerte: OP-22.
