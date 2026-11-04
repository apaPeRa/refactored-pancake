# Referenz-Übersicht – Seitenliste und Navigationsbaum

Paket R0, Stand 2026-11-04. Quelle: `src_Data/Referenz/Referenz.docx` (alt: Handbuch „Funktionsumfang“), ausgewertet mit `python-docx`/`lxml` (Dokumentreihenfolge, Relationships) und `pandoc`. Medien: [Medien/Medienliste.md](Medien/Medienliste.md).

## 1. Kennzahlen

| Größe | Wert |
|---|---|
| Seiten (Kapitel Ebene 2) | 39 (RS-01 … RS-39) |
| Tabellen | 50 (Kapitelebene, laufend T1–T50) |
| Tabellenzeilen insgesamt (inkl. Kopfzeilen) | 339 |
| Bildverweise `w:drawing` | 83 = 81 Bilder + 2 Hinweis-Textfelder |
| Bilddateien extrahiert | 81 (44 Fließtext, 37 in Tabellenzellen), 61 eindeutige Originale |
| Textfelder mit Hinweis | 2 (RS-22 Heizungen, RS-32 Geber setzen) |

## 2. Abgleich mit Plan_M1.md

Die Zuordnung Kapitel → RS-Nummer (Handbuchreihenfolge, 39 Kapitel), die Tabellenzahl je Seite (Summe 50) und die Kapitelnamen stimmen mit dem Plan überein. Abweichungen:

1. **Bilder RS-22 und RS-32:** Der Plan führt je 2 Fließtextbilder. Tatsächlich hat jede dieser Seiten 1 Bild und 1 Hinweis-Textfeld (`w:drawing` ohne Bild). Fließtextbilder sind 44, nicht 46; Tabellenbilder 37; Bilddateien 81, nicht 83.
2. **Tabellenbilder in Tabellen:** Die 37 Tabellenbilder liegen in RS-01 (8), RS-11 (8), RS-13 (13), RS-19 (8). Die „4 verschachtelten Tabellen“ (54 `w:tbl` gegenüber 50) sind die Tabellen in den Hinweis-Textfeldern von RS-22 und RS-32 (je einmal in `wps` und einmal im VML-Fallback), keine Tabellen im Fließtext.
3. **RS-17/RS-18 (Elternseite):** Die Kapitel „Motorparameter“ und „Gewichtskorrektur“ nach „Schließmaschine“ stehen laut Handbuchposition unter der Schließmaschine. RS-16 beschreibt aber nur Auslaufband, Kopfleim, Rüttlung und keine Navigation zu diesen Seiten; die Navigationstabellen der Dosierer nennen „Motorparameter“ (RS-11) bzw. „Gewichtskorrektur/Motorparameter/Regulierung“ (RS-19). Die Seiten sind inhaltlich identisch zu RS-12/RS-20 bzw. RS-21 (Bild `image29.png` bzw. `image42.png` dreimal bzw. zweimal verwendet). Die ID-Vergabe bleibt wie im Plan (Handbuchposition); die Elternseite ist offen (Annahme A-04).
4. **RS-04:** Die Tabelle nennt 18 Funktionen. „Endkontrollwaage“ hat kein eigenes Kapitel im Handbuch; „Handbetrieb“ steht für RS-30/RS-31, „Nockenschaltwerk“ für RS-25/RS-26, „Waagen kalibrieren“ für RS-27 (Annahme A-05).
5. **Spalte „Abschnitt“ in RS-04:** leer in allen Zeilen.

## 3. Seitenliste RS-01 … RS-39

| RS | Kapitel (H2 Nr.) | Navigationspfad (Brotkrümel) | Herkunft | Tabellen (Zeilen) | Bilder gesamt (Fließtext / Tabelle) | Mediendateien |
|---|---|---|---|---|---|---|
| RS-01 | Produktion (1) | Produktion | Handbuch | 2 (9, 17) | 9 (1 / 8) | `RS-01_01` … `RS-01_09` |
| RS-02 | Produktionszähler (2) | Produktion › Produktionszähler | Handbuch | 0 (–) | 1 (1 / 0) | `RS-02_01` … `RS-02_01` |
| RS-03 | Maschinengeschwindigkeit (3) | Produktion › Maschinengeschwindigkeit | Handbuch | 1 (7) | 1 (1 / 0) | `RS-03_01` … `RS-03_01` |
| RS-04 | Einstellungen (4) | Einstellung | Handbuch | 1 (19) | 1 (1 / 0) | `RS-04_01` … `RS-04_01` |
| RS-05 | Zuführung Papier (5) | Einstellung › Zuführung Papier | Handbuch | 3 (9, 4, 3) | 1 (1 / 0) | `RS-05_01` … `RS-05_01` |
| RS-06 | Zuführung Karton (6) | Einstellung › Zuführung Karton | Handbuch | 1 (8) | 1 (1 / 0) | `RS-06_01` … `RS-06_01` |
| RS-07 | Heißleim Nordson (7) | Einstellung › Zuführung Karton › Heißleimgerät | Handbuch | 2 (5, 6) | 1 (1 / 0) | `RS-07_01` … `RS-07_01` |
| RS-08 | Heißleim Parameter (8) | Einstellung › Zuführung Karton › Heißleimgerät › Parameter | abgeleitet | 1 (5) | 1 (1 / 0) | `RS-08_01` … `RS-08_01` |
| RS-09 | Heißleim Druck (9) | Einstellung › Zuführung Karton › Heißleimgerät › Druck | abgeleitet | 2 (6, 5) | 1 (1 / 0) | `RS-09_01` … `RS-09_01` |
| RS-10 | Zeitschaltuhr (10) | Einstellung › Zuführung Karton › Heißleimgerät › Zeitschaltuhr | abgeleitet | 0 (–) | 6 (6 / 0) | `RS-10_01` … `RS-10_06` |
| RS-11 | Hauptdosierer 1 & 2 (11) | Einstellung › Hauptdosierer | Handbuch | 3 (13, 8, 3) | 9 (1 / 8) | `RS-11_01` … `RS-11_09` |
| RS-12 | Motorparameter (12) | Einstellung › Hauptdosierer › Motorparameter | Handbuch | 2 (6, 4) | 1 (1 / 0) | `RS-12_01` … `RS-12_01` |
| RS-13 | Kontrollwaage (13) | Einstellung › Kontrollwaage | Handbuch | 2 (18, 3) | 14 (1 / 13) | `RS-13_01` … `RS-13_14` |
| RS-14 | Einzelgewichte (14) | Einstellung › Kontrollwaage › Einzelgewicht | Handbuch | 1 (7) | 1 (1 / 0) | `RS-14_01` … `RS-14_01` |
| RS-15 | Trend (15) | Einstellung › Kontrollwaage › Trend | Handbuch | 0 (–) | 1 (1 / 0) | `RS-15_01` … `RS-15_01` |
| RS-16 | Schließmaschine (16) | Einstellung › Schließmaschine | Handbuch | 3 (2, 5, 3) | 1 (1 / 0) | `RS-16_01` … `RS-16_01` |
| RS-17 | Motorparameter (17) | Einstellung › Schließmaschine › Motorparameter (Elternseite unklar) | abgeleitet | 2 (6, 4) | 1 (1 / 0) | `RS-17_01` … `RS-17_01` |
| RS-18 | Gewichtskorrektur (18) | Einstellung › Schließmaschine › Gewichtskorrektur (Elternseite unklar) | abgeleitet | 0 (–) | 1 (1 / 0) | `RS-18_01` … `RS-18_01` |
| RS-19 | Nachdosierer (19) | Einstellung › Nachdosierer | Handbuch | 3 (14, 7, 4) | 9 (1 / 8) | `RS-19_01` … `RS-19_09` |
| RS-20 | Motorparameter (20) | Einstellung › Nachdosierer › Motorparameter | Handbuch | 2 (6, 4) | 1 (1 / 0) | `RS-20_01` … `RS-20_01` |
| RS-21 | Gewichtskorrektur (21) | Einstellung › Nachdosierer › Gewichtskorrektur | Handbuch | 0 (–) | 1 (1 / 0) | `RS-21_01` … `RS-21_01` |
| RS-22 | Heizungen (22) | Einstellung › Heizungen | Handbuch | 1 (7) | 1 (1 / 0) + 1 Hinweis-Textfeld | `RS-22_01` … `RS-22_01` |
| RS-23 | Regulierung (23) | Einstellung › Regulierung | Handbuch | 1 (9) | 1 (1 / 0) | `RS-23_01` … `RS-23_01` |
| RS-24 | Bildschirm reinigen (24) | Einstellung › Bildschirm reinigen | Handbuch | 0 (–) | 1 (1 / 0) | `RS-24_01` … `RS-24_01` |
| RS-25 | Nocken (25) | Einstellung › Nockenschaltwerk › Nocken | Handbuch | 2 (9, 3) | 1 (1 / 0) | `RS-25_01` … `RS-25_01` |
| RS-26 | Nockenübersicht (26) | Einstellung › Nockenschaltwerk › Nocken › Übersicht | Handbuch | 1 (5) | 1 (1 / 0) | `RS-26_01` … `RS-26_01` |
| RS-27 | Waagen Kalibrieren (27) | Einstellung › Waagen kalibrieren | Handbuch | 2 (10, 2) | 1 (1 / 0) | `RS-27_01` … `RS-27_01` |
| RS-28 | Packungsregister (28) | Einstellung › Packungsregister | Handbuch | 1 (6) | 1 (1 / 0) | `RS-28_01` … `RS-28_01` |
| RS-29 | Produktionsstatistik (29) | Einstellung › Produktionsstatistik | Handbuch | 0 (–) | 1 (1 / 0) | `RS-29_01` … `RS-29_01` |
| RS-30 | Handbetrieb Auswahl (30) | Einstellung › Handbetrieb | Handbuch | 1 (3) | 1 (1 / 0) | `RS-30_01` … `RS-30_01` |
| RS-31 | Handbetrieb (31) | Einstellung › Handbetrieb › (Aktor) | abgeleitet | 1 (12) | 1 (1 / 0) | `RS-31_01` … `RS-31_01` |
| RS-32 | Geber setzen (32) | Einstellung › Geber setzen | Handbuch | 1 (8) | 1 (1 / 0) + 1 Hinweis-Textfeld | `RS-32_01` … `RS-32_01` |
| RS-33 | EA-Übersicht (33) | Einstellung › EA-Übersicht | Handbuch | 1 (3) | 1 (1 / 0) | `RS-33_01` … `RS-33_01` |
| RS-34 | EA-Anzeige (34) | Einstellung › EA-Übersicht › EA-Anzeige | abgeleitet | 1 (4) | 1 (1 / 0) | `RS-34_01` … `RS-34_01` |
| RS-35 | Systemeinstellungen (35) | Einstellung › Systemeinstellungen | Handbuch | 1 (9) | 1 (1 / 0) | `RS-35_01` … `RS-35_01` |
| RS-36 | Service (36) | Einstellung › Systemeinstellungen › Service | Handbuch | 1 (4) | 1 (1 / 0) | `RS-36_01` … `RS-36_01` |
| RS-37 | Meldearchiv (37) | Einstellung › Systemeinstellungen › Meldearchiv | Handbuch | 1 (5) | 1 (1 / 0) | `RS-37_01` … `RS-37_01` |
| RS-38 | Meldeanzeige (38) | Meldezeile (jede Seite) › Meldeanzeige | Handbuch | 1 (7) | 1 (1 / 0) | `RS-38_01` … `RS-38_01` |
| RS-39 | System- und Antriebsinfos (39) | Einstellung › Systemeinstellungen › System- und Antriebsinfo | Handbuch | 2 (7, 6) | 1 (1 / 0) | `RS-39_01` … `RS-39_01` |

Herkunft: „Handbuch“ = Zugang ausdrücklich im Handbuch beschrieben; „abgeleitet“ = nicht ausdrücklich beschrieben, siehe Spalte Hinweis in Abschnitt 4. Zeilenzahl enthält die Kopfzeile.
Summen: Tabellen 50, Bilder 81.

## 4. Handbuchabschnitt, Tabellen und Bilder je Seite (Kapitelstruktur)

Jedes Kapitel hat die Gliederung Zweck (H3), Seitenübersicht bzw. „Darstellung des Pop-Ups“ (H3, mit dem Seitenbild im Fließtext) und Funktionsbeschreibung (H3), darunter teils Unterbereiche (H4) mit Tabellen. Aufgeführt ist die Bildeinbindung: `B` = Bild im Fließtext, `Tn` = Tabelle n mit Anzahl der Bilder in ihren Zellen.

### RS-01 Produktion

- Navigation: Produktion – Startseite; Seitenleiste „Home“ (Design)
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung – Unterbereiche (H4): Statusanzeige (oben) · Steuerfunktionen (mittig)
- Bildeinbindung: Seitenübersicht: B RS-01_01.png; Funktionsbeschreibung › Statusanzeige (oben): T1 RS-01_02.png … RS-01_09.png (8)
- Tabellen: T1 (Statusanzeige (oben), 9 Zeilen): Spalten Funktion | Beschreibung | Grafik; T2 (Steuerfunktionen (mittig), 17 Zeilen): Spalten Funktion | Beschreibung

### RS-02 Produktionszähler

- Navigation: Produktion › Produktionszähler – Klick auf Symbol bei „Aktuelle Produktion“
- Gliederung: Zweck · Darstellung des Pop-Ups · Funktionsbeschreibung
- Bildeinbindung: Darstellung des Pop-Ups: B RS-02_01.png
- Tabellen: keine

### RS-03 Maschinengeschwindigkeit

- Navigation: Produktion › Maschinengeschwindigkeit – Klick auf rotes Tacho-Symbol
- Gliederung: Zweck · Darstellung des Pop-Ups · Funktionsbeschreibung
- Bildeinbindung: Darstellung des Pop-Ups: B RS-03_01.png
- Tabellen: T3 (Funktionsbeschreibung, 7 Zeilen): Spalten Funktion | Beschreibung

### RS-04 Einstellungen

- Navigation: Einstellung – Seitenleiste „Einstellungen“ (Design); Handbuch: „zentrale Seite“
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung
- Bildeinbindung: Seitenübersicht: B RS-04_01.png
- Tabellen: T4 (Funktionsbeschreibung, 19 Zeilen): Spalten Funktion | Beschreibung | Abschnitt

### RS-05 Zuführung Papier

- Navigation: Einstellung › Zuführung Papier – Eintrag in Tabelle von RS-04
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung – Unterbereiche (H4): Packstoffrolle · Klebestelle · Kupplung
- Bildeinbindung: Seitenübersicht: B RS-05_01.png
- Tabellen: T5 (Packstoffrolle, 9 Zeilen): Spalten Funktion | Beschreibung; T6 (Klebestelle, 4 Zeilen): Spalten Funktion | Beschreibung; T7 (Kupplung, 3 Zeilen): Spalten Funktion | Beschreibung

### RS-06 Zuführung Karton

- Navigation: Einstellung › Zuführung Karton – Eintrag in Tabelle von RS-04
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung
- Bildeinbindung: Seitenübersicht: B RS-06_01.png
- Tabellen: T8 (Funktionsbeschreibung, 8 Zeilen): Spalten Funktion | Beschreibung

### RS-07 Heißleim Nordson

- Navigation: Einstellung › Zuführung Karton › Heißleimgerät – Taste „Heißleimgerät“ auf RS-06 (Design: Einstellung › Zuführungen › Heißleim)
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung – Unterbereiche (H4): Obere Schaltflächen · Linker Anzeigebereich · Rechter Anzeigebereich
- Bildeinbindung: Seitenübersicht: B RS-07_01.png
- Tabellen: T9 (Obere Schaltflächen, 5 Zeilen): Spalten Funktion | Beschreibung; T10 (Rechter Anzeigebereich, 6 Zeilen): Spalten Funktion | Beschreibung

### RS-08 Heißleim Parameter

- Navigation: Einstellung › Zuführung Karton › Heißleimgerät › Parameter – Zugang im Handbuch nicht beschrieben; abgeleitet aus Design-Funktionsleiste (Temperatur/Druck/Zeitplan)
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung – Unterbereiche (H4): Oberer Bereich · Hauptbereich
- Bildeinbindung: Seitenübersicht: B RS-08_01.png
- Tabellen: T11 (Oberer Bereich, 5 Zeilen): Spalten Funktion | Beschreibung

### RS-09 Heißleim Druck

- Navigation: Einstellung › Zuführung Karton › Heißleimgerät › Druck – wie RS-08
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung – Unterbereiche (H4): Druckregelung · Gerätelimits
- Bildeinbindung: Seitenübersicht: B RS-09_01.png
- Tabellen: T12 (Druckregelung, 6 Zeilen): Spalten Funktion | Beschreibung; T13 (Gerätelimits, 5 Zeilen): Spalten Funktion | Beschreibung

### RS-10 Zeitschaltuhr

- Navigation: Einstellung › Zuführung Karton › Heißleimgerät › Zeitschaltuhr – wie RS-08; Taste „Zeitschaltuhr“ in RS-07 aktiviert nur den Zeitplan des Geräts
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung – Unterbereiche (H4): Bedienung · Beschreibung der Phasen
- Bildeinbindung: Seitenübersicht: B RS-10_01.png; Funktionsbeschreibung › Bedienung: B RS-10_02.png … RS-10_06.png (5)
- Tabellen: keine

### RS-11 Hauptdosierer 1 & 2

- Navigation: Einstellung › Hauptdosierer – Eintrag in RS-04; Pfeiltasten wechseln zwischen Hauptdosierer 1 und 2
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung – Unterbereiche (H4): Parameter und Status · Schaltflächen · Navigation (unten links)
- Bildeinbindung: Seitenübersicht: B RS-11_01.png; Funktionsbeschreibung › Parameter und Status: T14 RS-11_02.png … RS-11_09.png (8)
- Tabellen: T14 (Parameter und Status, 13 Zeilen): Spalten Funktion | Beschreibung | Grafik; T15 (Schaltflächen, 8 Zeilen): Spalten Funktion | Beschreibung; T16 (Navigation (unten links), 3 Zeilen): Spalten Funktion | Beschreibung

### RS-12 Motorparameter

- Navigation: Einstellung › Hauptdosierer › Motorparameter – Taste „Motorparameter“ in Navigation unten links (RS-11)
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung – Unterbereiche (H4): Verschluss Zu / Verschluss Auf · Schnecke
- Bildeinbindung: Seitenübersicht: B RS-12_01.png
- Tabellen: T17 (Verschluss Zu / Verschluss Auf, 6 Zeilen): Spalten Funktion | Beschreibung; T18 (Schnecke, 4 Zeilen): Spalten Funktion | Beschreibung

### RS-13 Kontrollwaage

- Navigation: Einstellung › Kontrollwaage – Eintrag in RS-04
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung – Unterbereiche (H4): Hauptbereich · Navigation (unten links)
- Bildeinbindung: Seitenübersicht: B RS-13_01.png; Funktionsbeschreibung › Hauptbereich: T19 RS-13_02.png … RS-13_14.png (13)
- Tabellen: T19 (Hauptbereich, 18 Zeilen): Spalten Funktion | Beschreibung | Grafik; T20 (Navigation (unten links), 3 Zeilen): Spalten Funktion | Beschreibung

### RS-14 Einzelgewichte

- Navigation: Einstellung › Kontrollwaage › Einzelgewicht – Navigation unten links (RS-13)
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung
- Bildeinbindung: Seitenübersicht: B RS-14_01.png
- Tabellen: T21 (Funktionsbeschreibung, 7 Zeilen): Spalten Funktion | Beschreibung

### RS-15 Trend

- Navigation: Einstellung › Kontrollwaage › Trend – Navigation unten links (RS-13)
- Gliederung: Zweck · Seitenübersicht
- Bildeinbindung: Seitenübersicht: B RS-15_01.png
- Tabellen: keine

### RS-16 Schließmaschine

- Navigation: Einstellung › Schließmaschine – Eintrag in RS-04
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung – Unterbereiche (H4): Auslaufband · Kopfleim · Rüttlung
- Bildeinbindung: Seitenübersicht: B RS-16_01.png
- Tabellen: T22 (Auslaufband, 2 Zeilen): Spalten Funktion | Beschreibung; T23 (Kopfleim, 5 Zeilen): Spalten Funktion | Beschreibung; T24 (Rüttlung, 3 Zeilen): Spalten Funktion | Beschreibung

### RS-17 Motorparameter

- Navigation: Einstellung › Schließmaschine › Motorparameter (Elternseite unklar) – Handbuchposition nach Schließmaschine; RS-16 beschreibt keine Navigation dorthin (siehe Abweichung 3)
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung – Unterbereiche (H4): Verschluss Zu / Verschluss Auf · Schnecke
- Bildeinbindung: Seitenübersicht: B RS-17_01.png
- Tabellen: T25 (Verschluss Zu / Verschluss Auf, 6 Zeilen): Spalten Funktion | Beschreibung; T26 (Schnecke, 4 Zeilen): Spalten Funktion | Beschreibung

### RS-18 Gewichtskorrektur

- Navigation: Einstellung › Schließmaschine › Gewichtskorrektur (Elternseite unklar) – wie RS-17
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung – Unterbereiche (H4): Anwendung und Bedienung · Hinweise zur optimalen Nutzung
- Bildeinbindung: Seitenübersicht: B RS-18_01.png
- Tabellen: keine

### RS-19 Nachdosierer

- Navigation: Einstellung › Nachdosierer – Eintrag in RS-04
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung – Unterbereiche (H4): Parameter und Status · Schaltflächen · Navigation (unten links)
- Bildeinbindung: Seitenübersicht: B RS-19_01.png; Funktionsbeschreibung › Parameter und Status: T27 RS-19_02.png … RS-19_09.png (8)
- Tabellen: T27 (Parameter und Status, 14 Zeilen): Spalten Funktion | Beschreibung | Grafik; T28 (Schaltflächen, 7 Zeilen): Spalten Funktion | Beschreibung; T29 (Navigation (unten links), 4 Zeilen): Spalten Funktion | Beschreibung

### RS-20 Motorparameter

- Navigation: Einstellung › Nachdosierer › Motorparameter – Navigation unten links (RS-19)
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung – Unterbereiche (H4): Verschluss Zu / Verschluss Auf · Schnecke
- Bildeinbindung: Seitenübersicht: B RS-20_01.png
- Tabellen: T30 (Verschluss Zu / Verschluss Auf, 6 Zeilen): Spalten Funktion | Beschreibung; T31 (Schnecke, 4 Zeilen): Spalten Funktion | Beschreibung

### RS-21 Gewichtskorrektur

- Navigation: Einstellung › Nachdosierer › Gewichtskorrektur – Navigation unten links (RS-19)
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung – Unterbereiche (H4): Anwendung und Bedienung · Hinweise zur optimalen Nutzung
- Bildeinbindung: Seitenübersicht: B RS-21_01.png
- Tabellen: keine

### RS-22 Heizungen

- Navigation: Einstellung › Heizungen – Eintrag in RS-04; Aktivierung über RS-01
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung
- Bildeinbindung: Seitenübersicht: B RS-22_01.png
- Tabellen: T32 (Funktionsbeschreibung, 7 Zeilen): Spalten Funktion | Beschreibung
- Hinweis-Textfeld: ⚠️Hinweis: Heizungen bleiben nach dem Abschalten noch eine Zeit lang heiß. Achtung: Verbre

### RS-23 Regulierung

- Navigation: Einstellung › Regulierung – Eintrag in RS-04; Taste „Einstellung Regulierung“/„Regulierung“ auf RS-11 und RS-19
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung
- Bildeinbindung: Seitenübersicht: B RS-23_01.png
- Tabellen: T33 (Funktionsbeschreibung, 9 Zeilen): Spalten Funktion | Beschreibung

### RS-24 Bildschirm reinigen

- Navigation: Einstellung › Bildschirm reinigen – Eintrag in RS-04; Seite schließt nach Ablauf automatisch
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung
- Bildeinbindung: Seitenübersicht: B RS-24_01.png
- Tabellen: keine

### RS-25 Nocken

- Navigation: Einstellung › Nockenschaltwerk › Nocken – Eintrag „Nockenschaltwerk“ in RS-04
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung – Unterbereiche (H4): Einstellungen · Navigation (unten links)
- Bildeinbindung: Seitenübersicht: B RS-25_01.png
- Tabellen: T34 (Einstellungen, 9 Zeilen): Spalten Funktion | Beschreibung; T35 (Navigation (unten links), 3 Zeilen): Spalten Funktion | Beschreibung

### RS-26 Nockenübersicht

- Navigation: Einstellung › Nockenschaltwerk › Nocken › Übersicht – Navigation unten links (RS-25); Nockennummer führt zurück zur Einstellseite
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung
- Bildeinbindung: Seitenübersicht: B RS-26_01.png
- Tabellen: T36 (Funktionsbeschreibung, 5 Zeilen): Spalten Funktion | Beschreibung

### RS-27 Waagen Kalibrieren

- Navigation: Einstellung › Waagen kalibrieren – Eintrag in RS-04; Pfeiltasten wechseln zwischen Waagen
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung – Unterbereiche (H4): Steuerelemente · Kalibriervorgang · Navigationsbereich (unten links)
- Bildeinbindung: Seitenübersicht: B RS-27_01.png
- Tabellen: T37 (Steuerelemente, 10 Zeilen): Spalten Funktion | Beschreibung; T38 (Navigationsbereich (unten links), 2 Zeilen): Spalten Funktion | Beschreibung

### RS-28 Packungsregister

- Navigation: Einstellung › Packungsregister – Eintrag in RS-04
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung
- Bildeinbindung: Seitenübersicht: B RS-28_01.png
- Tabellen: T39 (Funktionsbeschreibung, 6 Zeilen): Spalten Anzeigezustand | Bedeutung

### RS-29 Produktionsstatistik

- Navigation: Einstellung › Produktionsstatistik – Eintrag in RS-04; Pfeiltasten wechseln zwischen den letzten 30 Tagen
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung
- Bildeinbindung: Seitenübersicht: B RS-29_01.png
- Tabellen: keine

### RS-30 Handbetrieb Auswahl

- Navigation: Einstellung › Handbetrieb – Eintrag „Handbetrieb“ in RS-04; Gruppenanwahl und Suche
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung
- Bildeinbindung: Seitenübersicht: B RS-30_01.png
- Tabellen: T40 (Funktionsbeschreibung, 3 Zeilen): Spalten Funktion | Beschreibung

### RS-31 Handbetrieb

- Navigation: Einstellung › Handbetrieb › (Aktor) – Wechsel von RS-30 zur Aktorseite im Handbuch nicht ausdrücklich beschrieben
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung
- Bildeinbindung: Seitenübersicht: B RS-31_01.png
- Tabellen: T41 (Funktionsbeschreibung, 12 Zeilen): Spalten Funktion | Beschreibung

### RS-32 Geber setzen

- Navigation: Einstellung › Geber setzen – Eintrag in RS-04; Navigationstasten << / >> wechseln zwischen Gebern
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung
- Bildeinbindung: Seitenübersicht: B RS-32_01.png
- Tabellen: T42 (Funktionsbeschreibung, 8 Zeilen): Spalten Funktion | Beschreibung
- Hinweis-Textfeld: ⚠️Zum Setzen eines Gebers muss mindestens ein Not-Aus-Taster gedrückt sein.Anschließend is

### RS-33 EA-Übersicht

- Navigation: Einstellung › EA-Übersicht – Eintrag in RS-04
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung
- Bildeinbindung: Seitenübersicht: B RS-33_01.png
- Tabellen: T43 (Funktionsbeschreibung, 3 Zeilen): Spalten Funktion | Beschreibung

### RS-34 EA-Anzeige

- Navigation: Einstellung › EA-Übersicht › EA-Anzeige – Zugang im Handbuch nicht beschrieben; Navigationstasten blättern zwischen EA-Karten
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung
- Bildeinbindung: Seitenübersicht: B RS-34_01.png
- Tabellen: T44 (Funktionsbeschreibung, 4 Zeilen): Spalten Funktion | Beschreibung

### RS-35 Systemeinstellungen

- Navigation: Einstellung › Systemeinstellungen – Eintrag in RS-04
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung
- Bildeinbindung: Seitenübersicht: B RS-35_01.png
- Tabellen: T45 (Funktionsbeschreibung, 9 Zeilen): Spalten Funktion | Beschreibung

### RS-36 Service

- Navigation: Einstellung › Systemeinstellungen › Service – Taste „Service“ in RS-35
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung
- Bildeinbindung: Seitenübersicht: B RS-36_01.png
- Tabellen: T46 (Funktionsbeschreibung, 4 Zeilen): Spalten Funktion | Beschreibung

### RS-37 Meldearchiv

- Navigation: Einstellung › Systemeinstellungen › Meldearchiv – Taste „Meldearchiv“ in RS-35 (zusätzlich Seitenleiste „Meldungen“ im Design)
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung
- Bildeinbindung: Seitenübersicht: B RS-37_01.png
- Tabellen: T47 (Funktionsbeschreibung, 5 Zeilen): Spalten Funktion | Beschreibung

### RS-38 Meldeanzeige

- Navigation: Meldezeile (jede Seite) › Meldeanzeige – Antippen der Meldezeile; Schließen per Klick oder „Zurück“
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung
- Bildeinbindung: Seitenübersicht: B RS-38_01.png
- Tabellen: T48 (Funktionsbeschreibung, 7 Zeilen): Spalten Funktion | Beschreibung

### RS-39 System- und Antriebsinfos

- Navigation: Einstellung › Systemeinstellungen › System- und Antriebsinfo – Taste „System- und Antriebsinfo“ in RS-35
- Gliederung: Zweck · Seitenübersicht · Funktionsbeschreibung – Unterbereiche (H4): IPC-Bereich · Servomotoren
- Bildeinbindung: Seitenübersicht: B RS-39_01.png
- Tabellen: T49 (IPC-Bereich, 7 Zeilen): Spalten Funktion | Beschreibung; T50 (Servomotoren, 6 Zeilen): Spalten Funktion | Beschreibung

## 5. Navigationsbaum

Basis ist die Tabelle in RS-04 und die Abschnitte „Navigation (unten links)“ sowie „Schaltflächen“. Pfade mit Herkunft „abgeleitet“ sind mit `(abgeleitet)` gekennzeichnet. Rahmen aus dem Design: Seitenleiste (Home, Einstellungen, Meldungen, Zurück), Meldezeile (öffnet RS-38).

```
Produktion (RS-01, Startseite / Home)
├─ Pop-up Produktionszähler (RS-02)            [Symbol „Aktuelle Produktion“]
├─ Pop-up Maschinengeschwindigkeit (RS-03)      [rotes Tacho-Symbol]
│
Einstellung (RS-04)
├─ Zuführung Papier (RS-05)
├─ Zuführung Karton (RS-06)
│  └─ Heißleimgerät: Heißleim Nordson (RS-07)
│     ├─ Heißleim Parameter (RS-08)   (abgeleitet)
│     ├─ Heißleim Druck (RS-09)       (abgeleitet)
│     └─ Zeitschaltuhr (RS-10)        (abgeleitet)
├─ Hauptdosierer 1 & 2 (RS-11)  [Pfeiltasten wechseln 1/2]
│  ├─ Motorparameter (RS-12)
│  └─ Regulierung (RS-23)
├─ Kontrollwaage (RS-13)
│  ├─ Einzelgewicht (RS-14)
│  └─ Trend (RS-15)
├─ Schließmaschine (RS-16)
│  ├─ Motorparameter (RS-17)       (Handbuchposition, Elternseite unklar)
│  └─ Gewichtskorrektur (RS-18)    (Handbuchposition, Elternseite unklar)
├─ Nachdosierer (RS-19)
│  ├─ Gewichtskorrektur (RS-21)
│  ├─ Motorparameter (RS-20)
│  └─ Regulierung (RS-23)
├─ Endkontrollwaage (laut RS-04 vorhanden, kein eigenes Kapitel)
├─ Heizungen (RS-22)
├─ Regulierung (RS-23)
├─ Bildschirm reinigen (RS-24)
├─ Nockenschaltwerk: Nocken (RS-25) ⇄ Nockenübersicht (RS-26)
├─ Waagen kalibrieren (RS-27)
├─ Packungsregister (RS-28)
├─ Produktionsstatistik (RS-29)
├─ Handbetrieb: Auswahl (RS-30) → Handbetrieb (RS-31, abgeleitet)
├─ Geber setzen (RS-32)
├─ EA-Übersicht (RS-33) → EA-Anzeige (RS-34, abgeleitet)
└─ Systemeinstellungen (RS-35)
   ├─ Service (RS-36)
   ├─ Meldearchiv (RS-37)
   └─ System- und Antriebsinfo (RS-39)

Meldezeile (auf allen Seiten) → Meldeanzeige (RS-38)
```

Querbezüge: Heizungen (RS-22) werden über RS-01 aktiviert; Regulierung (RS-23) ist von RS-11 und RS-19 per Taste erreichbar; Nockenübersicht (RS-26) verzweigt per Nockennummer zur Nocken-Einstellseite (RS-25).

## 6. Brotkrümel und Zugang je Seite

| RS | Brotkrümel | Herkunft | Zugang / Hinweis |
|---|---|---|---|
| RS-01 Produktion | Produktion | Handbuch | Startseite; Seitenleiste „Home“ (Design) |
| RS-02 Produktionszähler (Pop-up) | Produktion › Produktionszähler | Handbuch | Klick auf Symbol bei „Aktuelle Produktion“ |
| RS-03 Maschinengeschwindigkeit (Pop-up) | Produktion › Maschinengeschwindigkeit | Handbuch | Klick auf rotes Tacho-Symbol |
| RS-04 Einstellungen | Einstellung | Handbuch | Seitenleiste „Einstellungen“ (Design); Handbuch: „zentrale Seite“ |
| RS-05 Zuführung Papier | Einstellung › Zuführung Papier | Handbuch | Eintrag in Tabelle von RS-04 |
| RS-06 Zuführung Karton | Einstellung › Zuführung Karton | Handbuch | Eintrag in Tabelle von RS-04 |
| RS-07 Heißleim Nordson | Einstellung › Zuführung Karton › Heißleimgerät | Handbuch | Taste „Heißleimgerät“ auf RS-06 (Design: Einstellung › Zuführungen › Heißleim) |
| RS-08 Heißleim Parameter | Einstellung › Zuführung Karton › Heißleimgerät › Parameter | abgeleitet | Zugang im Handbuch nicht beschrieben; abgeleitet aus Design-Funktionsleiste (Temperatur/Druck/Zeitplan) |
| RS-09 Heißleim Druck | Einstellung › Zuführung Karton › Heißleimgerät › Druck | abgeleitet | wie RS-08 |
| RS-10 Zeitschaltuhr | Einstellung › Zuführung Karton › Heißleimgerät › Zeitschaltuhr | abgeleitet | wie RS-08; Taste „Zeitschaltuhr“ in RS-07 aktiviert nur den Zeitplan des Geräts |
| RS-11 Hauptdosierer 1 & 2 | Einstellung › Hauptdosierer | Handbuch | Eintrag in RS-04; Pfeiltasten wechseln zwischen Hauptdosierer 1 und 2 |
| RS-12 Motorparameter (Hauptdosierer) | Einstellung › Hauptdosierer › Motorparameter | Handbuch | Taste „Motorparameter“ in Navigation unten links (RS-11) |
| RS-13 Kontrollwaage | Einstellung › Kontrollwaage | Handbuch | Eintrag in RS-04 |
| RS-14 Einzelgewichte | Einstellung › Kontrollwaage › Einzelgewicht | Handbuch | Navigation unten links (RS-13) |
| RS-15 Trend | Einstellung › Kontrollwaage › Trend | Handbuch | Navigation unten links (RS-13) |
| RS-16 Schließmaschine | Einstellung › Schließmaschine | Handbuch | Eintrag in RS-04 |
| RS-17 Motorparameter (Schließmaschine) | Einstellung › Schließmaschine › Motorparameter (Elternseite unklar) | abgeleitet | Handbuchposition nach Schließmaschine; RS-16 beschreibt keine Navigation dorthin (siehe Abweichung 3) |
| RS-18 Gewichtskorrektur (Schließmaschine) | Einstellung › Schließmaschine › Gewichtskorrektur (Elternseite unklar) | abgeleitet | wie RS-17 |
| RS-19 Nachdosierer | Einstellung › Nachdosierer | Handbuch | Eintrag in RS-04 |
| RS-20 Motorparameter (Nachdosierer) | Einstellung › Nachdosierer › Motorparameter | Handbuch | Navigation unten links (RS-19) |
| RS-21 Gewichtskorrektur (Nachdosierer) | Einstellung › Nachdosierer › Gewichtskorrektur | Handbuch | Navigation unten links (RS-19) |
| RS-22 Heizungen | Einstellung › Heizungen | Handbuch | Eintrag in RS-04; Aktivierung über RS-01 |
| RS-23 Regulierung | Einstellung › Regulierung | Handbuch | Eintrag in RS-04; Taste „Einstellung Regulierung“/„Regulierung“ auf RS-11 und RS-19 |
| RS-24 Bildschirm reinigen | Einstellung › Bildschirm reinigen | Handbuch | Eintrag in RS-04; Seite schließt nach Ablauf automatisch |
| RS-25 Nocken | Einstellung › Nockenschaltwerk › Nocken | Handbuch | Eintrag „Nockenschaltwerk“ in RS-04 |
| RS-26 Nockenübersicht | Einstellung › Nockenschaltwerk › Nocken › Übersicht | Handbuch | Navigation unten links (RS-25); Nockennummer führt zurück zur Einstellseite |
| RS-27 Waagen Kalibrieren | Einstellung › Waagen kalibrieren | Handbuch | Eintrag in RS-04; Pfeiltasten wechseln zwischen Waagen |
| RS-28 Packungsregister | Einstellung › Packungsregister | Handbuch | Eintrag in RS-04 |
| RS-29 Produktionsstatistik | Einstellung › Produktionsstatistik | Handbuch | Eintrag in RS-04; Pfeiltasten wechseln zwischen den letzten 30 Tagen |
| RS-30 Handbetrieb Auswahl | Einstellung › Handbetrieb | Handbuch | Eintrag „Handbetrieb“ in RS-04; Gruppenanwahl und Suche |
| RS-31 Handbetrieb | Einstellung › Handbetrieb › (Aktor) | abgeleitet | Wechsel von RS-30 zur Aktorseite im Handbuch nicht ausdrücklich beschrieben |
| RS-32 Geber setzen | Einstellung › Geber setzen | Handbuch | Eintrag in RS-04; Navigationstasten << / >> wechseln zwischen Gebern |
| RS-33 EA-Übersicht | Einstellung › EA-Übersicht | Handbuch | Eintrag in RS-04 |
| RS-34 EA-Anzeige | Einstellung › EA-Übersicht › EA-Anzeige | abgeleitet | Zugang im Handbuch nicht beschrieben; Navigationstasten blättern zwischen EA-Karten |
| RS-35 Systemeinstellungen | Einstellung › Systemeinstellungen | Handbuch | Eintrag in RS-04 |
| RS-36 Service | Einstellung › Systemeinstellungen › Service | Handbuch | Taste „Service“ in RS-35 |
| RS-37 Meldearchiv | Einstellung › Systemeinstellungen › Meldearchiv | Handbuch | Taste „Meldearchiv“ in RS-35 (zusätzlich Seitenleiste „Meldungen“ im Design) |
| RS-38 Meldeanzeige | Meldezeile (jede Seite) › Meldeanzeige | Handbuch | Antippen der Meldezeile; Schließen per Klick oder „Zurück“ |
| RS-39 System- und Antriebsinfos | Einstellung › Systemeinstellungen › System- und Antriebsinfo | Handbuch | Taste „System- und Antriebsinfo“ in RS-35 |

Die Pfade folgen den Bezeichnungen des Handbuchs; das Design (Brotkrümel „Einstellung › Zuführungen › Heißleim“, „Einstellung › Dosierer“) gruppiert teils anders und wird in Phase 3 (`Navigation.md`) vereinheitlicht.
