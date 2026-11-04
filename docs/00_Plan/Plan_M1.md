# Plan Meilenstein 1 – Dokumentation und Konzept

Stand: 2026-11-04. Grundlage: `Agent.md`, `Task.md`, Sichtung von `src_Data/Design` und `src_Data/Referenz/Referenz.docx`.

## 1. Umfang der Quellen

### Design (`src_Data/Design`)
Fünf PNG-Screenshots (PowerPoint-Entwurf, nicht final):

| Datei | Seite | Brotkrümel | Auffälligkeiten |
|---|---|---|---|
| `Seite_Produktion.png` | Produktion | Produktion | Kacheln Geschwindigkeit („Schnell“), Produktion (Rezeptanwahl, aktuelle/letzte Produktion), EKW (leer), Versorgung (Druckluft, Papier, Produkt, Linienbetrieb); 6 Funktionstasten, 7 Umschalter; Schaltfläche „Schichtplan“ |
| `Seite_Einstellungen.png` | Einstellung | Einstellung | Bereich „Anwählen/Schnelle Einstellungen“ (Beleuchtung), 2 × 8 Kacheln (4 leer), Schaltfläche „Sprache“ |
| `Seite_Heissleim.png` | Heißleim | Einstellung › Zuführungen › Heißleim | Tasten Heizung/Standby/Pumpe/Zeitplan, 7 Status-LEDs, Temperaturen, Füllstand Tank, Eingabefelder mit Schlüsselsymbol, Funktionsleiste Temperatur/Druck/Zeitplan |
| `Seite_Dosierer.png` | Dosierer | Einstellung › Dosierer | Sollgewicht-Kopfzeile; Karten Hauptdosierer 1, 2 und Nachdosierer mit Soll/Regulierwert, Trichter-LEDs, Umschaltern, Auslastungsbalken, Tasten Manuell/Entleeren |
| `Seite_Kartonzufuehrung.png` | Karton | Einstellung › Zuführungen › Karton | Schalter Ein/Aus, Leimspuren-Grafik mit Eingabefeldern |

Gemeinsamer Rahmen auf allen Seiten: Seitenleiste (Benutzerkreis „MM“ mit Name und Rolle, Home, Einstellungen, Meldungen, Zurück), Kopfzeile (Logo, Meldezeile, Betriebsart, Uhrzeit/Datum), Brotkrümel, Kennzahlen Geschwindigkeit (1/min) und Maschinenwinkel (°), untere Funktionsleiste.

### Referenz (`src_Data/Referenz/Referenz.docx`)
- Gliederung: 1 Titel „Funktionsumfang“, **39 Kapitel der Ebene 2 (= 39 Seiten/Pop-ups)**, je Kapitel „Zweck“, „Seitenübersicht“, „Funktionsbeschreibung“ (Ebene 3), teils Ebene 4 (Unterbereiche).
- **Tabellen:** 50 Tabellen auf Kapitelebene (insgesamt 54 `w:tbl`-Elemente, davon 4 verschachtelt).
- **Bilder:** 83 Bildverweise (`w:drawing`) im Dokument, davon 44 direkt im Fließtext (je Kapitel ein Seitenbild, Zeitschaltuhr 6, Heizungen und Geber setzen je 2) und 37 innerhalb von Tabellen; 63 eindeutige Dateien in `word/media`.
- Pandoc-Ausgabe: 1537 Zeilen Markdown.

## 2. Vorläufige Seitenliste (Referenz, in Handbuchreihenfolge)

Die RS-Nummern folgen der Handbuchreihenfolge (`RS-01` … `RS-39`). Mehrfach vorkommende Kapitel („Motorparameter“, „Gewichtskorrektur“) sind eigene Seiten und werden über Unterordner-/Namenszusatz unterschieden (z. B. `RS-12_Motorparameter-Hauptdosierer`).

| RS | Kapitel | Tab. | Bilder (Fließtext) |
|---|---|---|---|
| 01 | Produktion | 2 | 1 |
| 02 | Produktionszähler (Pop-up) | 0 | 1 |
| 03 | Maschinengeschwindigkeit (Pop-up) | 1 | 1 |
| 04 | Einstellungen | 1 | 1 |
| 05 | Zuführung Papier | 3 | 1 |
| 06 | Zuführung Karton | 1 | 1 |
| 07 | Heißleim Nordson | 2 | 1 |
| 08 | Heißleim Parameter | 1 | 1 |
| 09 | Heißleim Druck | 2 | 1 |
| 10 | Zeitschaltuhr | 0 | 6 |
| 11 | Hauptdosierer 1 & 2 | 3 | 1 |
| 12 | Motorparameter (Hauptdosierer) | 2 | 1 |
| 13 | Kontrollwaage | 2 | 1 |
| 14 | Einzelgewichte | 1 | 1 |
| 15 | Trend | 0 | 1 |
| 16 | Schließmaschine | 3 | 1 |
| 17 | Motorparameter (Schließmaschine) | 2 | 1 |
| 18 | Gewichtskorrektur (Schließmaschine) | 0 | 1 |
| 19 | Nachdosierer | 3 | 1 |
| 20 | Motorparameter (Nachdosierer) | 2 | 1 |
| 21 | Gewichtskorrektur (Nachdosierer) | 0 | 1 |
| 22 | Heizungen | 1 | 2 |
| 23 | Regulierung | 1 | 1 |
| 24 | Bildschirm reinigen | 0 | 1 |
| 25 | Nocken | 2 | 1 |
| 26 | Nockenübersicht | 1 | 1 |
| 27 | Waagen Kalibrieren | 2 | 1 |
| 28 | Packungsregister | 1 | 1 |
| 29 | Produktionsstatistik | 0 | 1 |
| 30 | Handbetrieb Auswahl | 1 | 1 |
| 31 | Handbetrieb | 1 | 1 |
| 32 | Geber setzen | 1 | 2 |
| 33 | EA-Übersicht | 1 | 1 |
| 34 | EA-Anzeige | 1 | 1 |
| 35 | Systemeinstellungen | 1 | 1 |
| 36 | Service | 1 | 1 |
| 37 | Meldearchiv | 1 | 1 |
| 38 | Meldeanzeige | 1 | 1 |
| 39 | System- und Antriebsinfos | 2 | 1 |

Summe: 50 Tabellen (Kapitelebene), 46 Fließtextbilder; weitere Bilder liegen in Tabellenzellen. Die genaue Zuordnung Tabelle/Bild → Seite ist Aufgabe der Referenz-Analyse (Phase 2) und wird dort lückenlos erfasst.

Der Navigationsbaum (Einstellungen → Zuführungen/Dosierer/Schließmaschine/Waagen/…) wird in `Referenz-Uebersicht.md` aus der Seite „Einstellungen“ (RS-04) und den Navigationsabschnitten („Navigation (unten links)“) abgeleitet.

## 3. Arbeitspakete

### Phase 1 – Design-Analyse
| Paket | Inhalt | Abhängigkeit |
|---|---|---|
| D1 | Ordner, Plan, Begleitdokumente (dieses Paket, erledigt) | – |
| D2 | `Design-Dokumentation.md` (Rahmen, Raster, Farben, Typografie, Elementarten, Navigation) | D1 |
| D3 | `DS-01` … `DS-05` (je Screenshot eine Seite) | D2 |
| D4 | `DM-xx` Module (Statuskopf, Navigationsleiste, Brotkrümel, Kennzahl-Kachel, Umschalter, Status-LED, Fortschrittsbalken, Eingabefeld mit Schlüssel, Dosierer-Karte, Funktionstaste, …) | D3 |
| D5 | Prüfung Phase 1 gegen Screenshots (separater Prüf-Agent), Commit | D4 |

### Phase 2 – Referenz-Analyse
D2 und die Referenz-Pakete sind unabhängig und können parallel zu Phase 1 laufen; nur Schreibzugriffe auf gemeinsame Dateien sind zu vermeiden.

| Paket | Seiten (RS) | Themenschwerpunkt |
|---|---|---|
| R0 | – | Extraktion: Bilder nach `02_Referenz-Analyse/Medien` (Benennung `RS-xx_<lfd. Nr>`), Tabellen-/Bildzuordnung, `Referenz-Uebersicht.md` (Seitenliste, Navigationsbaum). Läuft zuerst, einmalig. |
| R1 | 01–03 | Produktion und ihre Pop-ups (Produktionszähler, Maschinengeschwindigkeit) |
| R2 | 04–06 | Einstellungen, Zuführung Papier, Zuführung Karton |
| R3 | 07–10 | Heißleim Nordson, Parameter, Druck, Zeitschaltuhr (6 Bilder) |
| R4 | 11–12, 19–21 | Hauptdosierer 1 & 2, Nachdosierer samt Motorparameter und Gewichtskorrektur (Nachdosierer), hohe Ähnlichkeit |
| R5 | 13–15 | Kontrollwaage, Einzelgewichte, Trend |
| R6 | 16–18 | Schließmaschine, Motorparameter, Gewichtskorrektur (Schließmaschine) |
| R7 | 22–26 | Heizungen, Regulierung, Bildschirm reinigen, Nocken, Nockenübersicht |
| R8 | 27–29 | Waagen Kalibrieren, Packungsregister, Produktionsstatistik |
| R9 | 30–34 | Handbetrieb Auswahl, Handbetrieb, Geber setzen, EA-Übersicht, EA-Anzeige |
| R10 | 35–39 | Systemeinstellungen, Service, Meldearchiv, Meldeanzeige, System- und Antriebsinfos |
| R11 | – | `RM-xx`: wiederkehrende Elemente (u. a. Motorparameter, Gewichtskorrektur, Dosierer-Parameter, Status-LED-Liste, Nockentabelle, Eingabe-Pop-up); läuft nach R1–R10, nacheinander |
| R12 | – | Prüfung Phase 2 (je Paket ein Prüf-Agent, danach Gesamtprüfung: jede Tabellenzeile und jedes Bild erfasst), Commit |

R1–R10 laufen parallel (jeweils nur eigene `RS`-Dateien und eigene Medien). Die ID-Vergabe ist vorab fest (siehe Tabelle oben), damit sich Pakete nicht überschneiden. Pakete bleiben bei höchstens 5 Seiten bzw. höchstens 4 Tabellen-lastigen Seiten.

### Phase 3 – Neues HMI-Konzept
Nacheinander, da zusammenführend: P1 `Designsystem.md`; P2 `Navigation.md`; P3 `HM-xx` (aus DM und RM, Duplikate entfernen); P4 `HS-01` … `HS-39` (parallel in Paketen analog R1–R10, nur lesend auf HM); P5 `Konzept.md`; P6 `Rueckverfolgung.md`; P7 `Pruefbericht_M1.md` durch Prüf-Agenten, Befunde beheben, Commit und Push.

## 4. Reihenfolge

1. D1 (erledigt) → D2 → D3 → D4 → D5 (Commit).
2. R0 → R1–R10 parallel → R11 → R12 (Commit).
3. Phase 3 P1 → P2 → P3 → P4 → P5 → P6 → P7 (Commit, Push).
Phase 1 und R0–R10 dürfen überlappen; Phase 3 beginnt erst nach beiden.

## 5. Prüfstrategie

- Jedes Paket wird von einem **separaten Prüf-Agenten** unabhängig gegen die Quelle geprüft (Agent.md Abschnitt 9); Befunde gehen an den Verwalter, Behebung und Neuprüfung bis zum Bestehen.
- Kriterien (Agent.md Abschnitt 8): Vollständigkeit (jede Seite, jedes Element, jede Tabellenzeile, jedes Bild), Zahlen und Bezeichnungen stimmen mit der Quelle, alle Querverweise lösen auf, keine doppelten Module.
- Maschinelle Zählprüfung: Zahl der RS-Dateien = 39, Zahl der Medien = Zahl der Bildverweise im Handbuch, Tabellenzeilen je Seite gegen pandoc-Ausgabe.
- Link-Check aller relativen Querverweise per Skript am Meilensteinende.
- Gesamtprüfung am Ende durch einen zusätzlichen Prüf-Agenten, Ergebnis in `docs/04_Pruefung/Pruefbericht_M1.md`.
- Pflege: nach jedem Paket `Fortschritt.md`, `Annahmen.md` und `Offene-Punkte.md` aktualisieren, Haken in `Task.md`.
