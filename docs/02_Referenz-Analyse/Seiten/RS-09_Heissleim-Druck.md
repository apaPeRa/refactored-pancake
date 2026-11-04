# RS-09 – Heißleim Druck

- Quelle: Handbuch `src_Data/Referenz/Referenz.docx`, Kapitel 9 „Heißleim Druck“ (Zweck, Seitenübersicht, Funktionsbeschreibung mit Tabellen T12 „Druckregelung“ und T13 „Gerätelimits“); Bild [RS-09_01](../Medien/RS-09_01.png) (`image17.png`).
- Navigationspfad: Einstellung › Zuführung Karton › Heißleimgerät › Druck (Herkunft „abgeleitet“, Zugang im Handbuch nicht beschrieben). Seitentitel im Bild: „Heißleim Zuführung Druck“. Im Bild von [RS-07](RS-07_Heissleim-Nordson.md) die Funktionsleistentaste „Druck“ (Ziel nach Name vermutet).

## Zweck

Wortgetreu: „Auf dieser Seite werden alle druckrelevanten Parameter des Nordson-Heißleimgeräts eingestellt. Die Druckregelung erfolgt basierend auf der Fördergeschwindigkeit und den definierten Druckgrenzen. Zusätzlich werden Gerätegrenzwerte überwacht, um den sicheren Betrieb des Systems zu gewährleisten.“

## Aufbau (Bereiche, Layout)

Bild [RS-09_01](../Medien/RS-09_01.png) (1024 × 768):

1. **Kopfzeile:** Logo, Titel „Heißleim Zuführung Druck“, Wirbel-Symbol, Uhrzeit „13:01:59“, Datum „12.05.2025“.
2. **Hauptfläche (blauer Hintergrund), zwei Spalten:**
   - Links Überschrift „Druckregelung“ (unterstrichen) mit fünf Zeilen Beschriftung + weißem Wertfeld: „Obere Geschwindigkeit:“ 120 1/min; „Untere Geschwindigkeit:“ 20 1/min; „Oberer Druck:“ 1,7 bar; „Unterer Druck:“ 0,7 bar; „Aktueller Druck:“ 0,7 bar. Die ersten vier Felder: rote Schrift, gelbes Schlüsselsymbol oben rechts. „Aktueller Druck“: schwarze Schrift, kein Schlüssel.
   - Rechts Überschrift „Gerätelimits“ (unterstrichen) mit vier Zeilen: „Oberes Drucklimit:“ 5,0 bar; „Unteres Drucklimit:“ 0,7 bar; „Überdruck Delta:“ 3,0 bar; „Unterdruck Delta:“ 0,3 bar. Alle rote Schrift mit Schlüsselsymbol.
3. **Meldezeile:** roter Balken „*450* Palettierung nicht bereit“.
4. **Untere Funktionsleiste:** links leer; rechts gelbes Vorhängeschloss, „Produktion“ (Haus), „Einstellungen“ (Zahnrad), „Zurück“ (Rücktaste).

## Elemente

### Tabelle T12 – Druckregelung (5 Zeilen)

| Element | Typ | Funktion (wortgetreu) | verwendetes Modul |
|---|---|---|---|
| Obere Geschwindigkeit | Eingabefeld mit Schlüsselsymbol, Einheit 1/min (Bild: 120 1/min) | „Oberer Maschinentakte (in 1/min) bei der, der obere Druck gilt.“ | [RM-05](../Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) |
| Untere Geschwindigkeit | Eingabefeld mit Schlüsselsymbol, Einheit 1/min (Bild: 20 1/min) | „Untere Maschinentakte (in 1/min) bei der, der untere Druck gilt.“ | [RM-05](../Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) |
| Oberer Druck | Eingabefeld mit Schlüsselsymbol, Einheit bar (Bild: 1,7 bar) | „Zielwert für den oberen Betriebsdruck.“ | [RM-05](../Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) |
| Unterer Druck | Eingabefeld mit Schlüsselsymbol, Einheit bar (Bild: 0,7 bar) | „Zielwert für den unteren Betriebsdruck.“ | [RM-05](../Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) |
| Aktueller Druck | Anzeigefeld, nur lesend, Einheit bar (Bild: 0,7 bar) | „Anzeige des aktuell anliegenden Systemdrucks.“ | [RM-07](../Module/RM-07_Anzeigefeld.md) mit Einheit |

### Tabelle T13 – Gerätelimits (4 Zeilen)

| Element | Typ | Funktion (wortgetreu) | verwendetes Modul |
|---|---|---|---|
| Oberes Drucklimit | Eingabefeld mit Schlüsselsymbol, Einheit bar (Bild: 5,0 bar) | „Maximal zulässiger Druck im Prozess. Wird dieser überschritten, erfolgt eine Abschaltung.“ | [RM-05](../Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) |
| Unteres Drucklimit | Eingabefeld mit Schlüsselsymbol, Einheit bar (Bild: 0,7 bar) | „Minimal zulässiger Druck im Prozess. Bei Unterschreitung kann eine Störung ausgelöst werden.“ | [RM-05](../Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) |
| Überdruck Delta | Eingabefeld mit Schlüsselsymbol, Einheit bar (Bild: 3,0 bar) | „Toleranzwert oberhalb des Sollwerts, bevor eine Überdruckmeldung erfolgt.“ | [RM-05](../Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) |
| Unterdruck Delta | Eingabefeld mit Schlüsselsymbol, Einheit bar (Bild: 0,3 bar) | „Toleranzwert unterhalb des Sollwerts, bevor eine Unterdruckmeldung erfolgt.“ | [RM-05](../Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) |

### Rahmenelemente

| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Kopfzeile | Rahmen | Logo, Titel, Symbol, Uhrzeit/Datum | [RM-01](../Module/RM-01_Kopfzeile.md) |
| Meldezeile | Rahmen | Meldung (Bild: „*450* Palettierung nicht bereit“) | [RM-02](../Module/RM-02_Meldezeile.md) |
| Vorhängeschloss (gelb) | Symbol | im Handbuch nicht erklärt | [RM-03](../Module/RM-03_Funktionsleiste-unten.md) |
| Produktion / Einstellungen / Zurück | Navigationstasten | Funktion nur aus Beschriftung/Symbol | [RM-03](../Module/RM-03_Funktionsleiste-unten.md) |

### Bilder

| Bild | Beschreibung |
|---|---|
| [RS-09_01.png](../Medien/RS-09_01.png) | Gesamtansicht „Heißleim Zuführung Druck“: links Block „Druckregelung“ (5 Felder), rechts Block „Gerätelimits“ (4 Felder), alle mit Einheit; Schlüsselsymbole an allen Eingabefeldern, nicht am „Aktueller Druck“. |

## Verwendete Module (IDs)

Module dieser Seite (Definitionen in der [Modulliste](../Module/Modulliste.md)):

- [RM-01](../Module/RM-01_Kopfzeile.md) – Kopfzeile
- [RM-02](../Module/RM-02_Meldezeile.md) – Meldezeile
- [RM-03](../Module/RM-03_Funktionsleiste-unten.md) – Funktionsleiste unten
- [RM-05](../Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) – Eingabefeld mit Schlüsselsymbol
- [RM-06](../Module/RM-06_Eingabe-Pop-up.md) – Eingabe-Pop-up
- [RM-07](../Module/RM-07_Anzeigefeld.md) – Anzeigefeld

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

- **Druckregelung:** Handbuch (Zweck): „basierend auf der Fördergeschwindigkeit und den definierten Druckgrenzen“. Zwischen den Geschwindigkeiten ist der Verlauf zwischen oberem und unterem Druck nicht beschrieben.
- **Oberes Drucklimit überschritten:** Abschaltung.
- **Unteres Drucklimit unterschritten:** „kann eine Störung ausgelöst werden“.
- **Überdruck Delta / Unterdruck Delta:** Toleranz oberhalb/unterhalb des Sollwerts, danach Überdruck- bzw. Unterdruckmeldung.
- **Berechtigungen:** Schlüsselsymbol an acht Eingabefeldern (Bedeutung nicht erklärt).
- **Pop-ups:** keine beschrieben (Werteingabe vermutlich Eingabe-Pop-up, nicht beschrieben).

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RS-09-P01 | Obere Geschwindigkeit | Eingabefeld 1/min mit Schlüsselsymbol; Bildwert 120 1/min | offen |
| RS-09-P02 | Untere Geschwindigkeit | Eingabefeld 1/min mit Schlüsselsymbol; Bildwert 20 1/min | offen |
| RS-09-P03 | Oberer Druck | Eingabefeld bar mit Schlüsselsymbol; Bildwert 1,7 bar | offen |
| RS-09-P04 | Unterer Druck | Eingabefeld bar mit Schlüsselsymbol; Bildwert 0,7 bar | offen |
| RS-09-P05 | Aktueller Druck | Nur Anzeige in bar, ohne Schlüssel; Bildwert 0,7 bar | offen |
| RS-09-P06 | Oberes Drucklimit | Eingabefeld bar; Bildwert 5,0 bar; Beschreibung: Abschaltung bei Überschreitung | offen |
| RS-09-P07 | Unteres Drucklimit | Eingabefeld bar; Bildwert 0,7 bar; Beschreibung: Störung bei Unterschreitung möglich | offen |
| RS-09-P08 | Überdruck Delta | Eingabefeld bar; Bildwert 3,0 bar | offen |
| RS-09-P09 | Unterdruck Delta | Eingabefeld bar; Bildwert 0,3 bar | offen |
| RS-09-P10 | Gruppierung | Zwei Blöcke „Druckregelung“ (5 Felder) und „Gerätelimits“ (4 Felder) | offen |
| RS-09-P11 | Brotkrümel | „Einstellung › Zuführung Karton › Heißleimgerät › Druck“ | offen |
| RS-09-P12 | Rückweg | Tasten Produktion, Einstellungen, Zurück vorhanden | offen |
| RS-09-P13 | Medienbezug | [RS-09_01](../Medien/RS-09_01.png) verlinkt und beschrieben | offen |

## Offene Punkte

1. **Zugang** nicht beschrieben (abgeleitet aus Funktionsleiste „Druck“ auf RS-07).
2. **Wertebereiche/Standardwerte** fehlen; Bildwerte nur Beispiele. Im Bild sind „Unteres Drucklimit“ und „Unterer Druck“ beide 0,7 bar, „Überdruck Delta“ 3,0 bar bei „Oberem Drucklimit“ 5,0 bar; Zusammenhang nicht beschrieben.
3. **Wortlaut Handbuch:** „Oberer/Untere Maschinentakte“ (vermutlich Maschinengeschwindigkeit/Takte); Interpolation zwischen unterem und oberem Druck nicht beschrieben.
4. **Bezug „Sollwert“** bei Überdruck-/Unterdruck Delta: Sollwert nicht definiert (aktueller Zielwert aus Druckregelung?).
5. Schlüsselsymbol/Vorhängeschloss, Meldungstexte für Überdruck/Unterdruck/Störung nicht beschrieben.
