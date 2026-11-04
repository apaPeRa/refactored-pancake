# RS-39 – System- und Antriebsinfos
- Quelle: Referenz.docx, Kapitel 39 „System- und Antriebsinfos“ (Zweck, Seitenübersicht, Funktionsbeschreibung mit Unterbereichen IPC-Bereich und Servomotoren, Tabellen 49 und 50); Bild [RS-39_01.png](../Medien/RS-39_01.png)   - Navigationspfad: Einstellung › Systemeinstellungen › System- und Antriebsinfo (Taste „System- und Antriebsinfo“ in [RS-35](RS-35_Systemeinstellungen.md))

## Zweck
Wortgetreu: „Diese Seite zeigt den aktuellen Zustand des IPCs sowie der angeschlossenen Servomotoren. Sie dient zur Systemdiagnose und zur schnellen Fehleranalyse bei Überlastungen, Störungen oder Ausfällen.“

## Aufbau (Bereiche, Layout)
Beschreibung von [RS-39_01.png](../Medien/RS-39_01.png):
- **Kopfzeile:** Logo, Titel „Systeminfo“ (Handbuch: „System- und Antriebsinfos“), Wirbelsymbol, Uhrzeit 13:06:03, Datum 12.05.2025.
- **Bereich „IPC“** (grauer Rahmen, Überschrift „IPC“ unterstrichen), Zeilen mit Beschriftung links und weißen Anzeigefeldern:
  - „Prozessorauslastung:“ – Balkenanzeige (grüner Füllstand ca. 15 %), daneben „Aktuell / Max.:“ mit zwei Feldern „15 %“ (Anfang im Bild verdeckt, „ı5 %“) und „42 %“
  - „Systemstart:“ – „02.04.2025 01:22:42“
  - „Laufzeit gesamt:“ – drei Felder „744 h“ · „1 m“ · „14 s“
  - „Status / Diag Code:“ – „5 - running“ und „0 (0x000) - No Error“
  - „HMI Applikation Build:“ – „09.05.2025 10:42:17“
- **Bereich „Servomotoren“** (grauer Rahmen, Überschrift unterstrichen): 4 sichtbare Antriebe, je Antrieb ein Block mit Name links und zwei Zeilen rechts. Zeile 1: „Diag Code“ (Zahlenfeld) · „Strom Aktuell / Max / Limit“ (drei Zahlenfelder); Zeile 2: „Meldung“ (breites Textfeld).
  | Antrieb (Name) | Diag Code | Strom Aktuell | Strom Max | Strom Limit | Meldung |
  |---|---|---|---|---|---|
  | Antrieb Zuführung 2MA1 | 0 | 0,0 % | -24,4 % | 100,0 % (rot, Schlüsselsymbol) | Motorschutz ausgelöst |
  | Verschluss Dosierer 1 41MA1 | 0 | 0,0 % | -17,5 % | 500,0 % (rot, Schlüsselsymbol) | Motorschutz ausgelöst |
  | Schnecke Dosierer 1 41MA2 | 0 | 0,0 % | 20,3 % | 100,0 % (rot, Schlüsselsymbol) | Motorschutz ausgelöst |
  | Verschluss Dosierer 2 42MA1 | 0 | 0,0 % | -9,6 % | 500,0 % (rot, Schlüsselsymbol) | Motorschutz ausgelöst |
- **Rechts neben Servomotoren:** zwei große Tasten „Pfeil nach oben“ und „Pfeil nach unten“ (Blättern durch weitere Antriebe).
- **Meldezeile** rot „*450* Palettierung nicht bereit“.
- **Untere Leiste:** links keine Taste; Vorhängeschloss, „Produktion“, „Einstellungen“, „Zurück“.

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Alle 6 Zeilen Tabelle 49 (IPC-Bereich), wortgetreu:

| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Prozessorauslastung | Balken + 2 Zahlenfelder (Aktuell / Max., Einheit %) | „Aktuelle und maximale CPU-Auslastung des IPCs.“ | [RM-09](../Module/RM-09_Fortschrittsbalken.md); [RM-07](../Module/RM-07_Anzeigefeld.md) |
| Systemstart | Datum/Uhrzeit-Anzeige | „Datum und Uhrzeit des letzten Starts der Steuerung.“ | [RM-07](../Module/RM-07_Anzeigefeld.md) |
| Laufzeit gesamt | Anzeige in h / m / s | „Zeit seit der Inbetriebnahme des Systems.“ | [RM-07](../Module/RM-07_Anzeigefeld.md) |
| Status / Diag Code | 2 Textfelder | „Diagnosestatus und laufende Systemmeldungen.“ | [RM-07](../Module/RM-07_Anzeigefeld.md) |
| HMI Applikation Build | Datum/Uhrzeit-Anzeige | „Zeitpunkt der letzten Softwareinstallation bzw. des letzten Updates der HMI.“ | [RM-07](../Module/RM-07_Anzeigefeld.md) |
| Maximale Auslastung zurücksetzen | Interaktion (Antippen des Maximalwertfelds) | „Der Maximalwert der CPU-Auslastung kann durch Antippen zurückgesetzt werden.“ | [RM-07](../Module/RM-07_Anzeigefeld.md) |

Alle 5 Zeilen Tabelle 50 (Servomotoren), wortgetreu:

| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Diag Code | Zahlenfeld je Antrieb | „Diagnosenummer des Antriebs (z. B. für Servofehler oder Überlast).“ | [RM-07](../Module/RM-07_Anzeigefeld.md) |
| Meldung | Textfeld je Antrieb | „Textmeldung zur Fehlerursache (z. B. „Motorschutz ausgelöst“).“ | [RM-07](../Module/RM-07_Anzeigefeld.md) |
| Strom Ist / Max / Limit | 3 Zahlenfelder je Antrieb (Einheit % laut Bild; im Bild „Aktuell / Max / Limit“) | „Vergleich von aktuellem Stromwert, bisherigem Höchstwert und konfiguriertem Grenzwert.“ | [RM-07](../Module/RM-07_Anzeigefeld.md); [RM-07](../Module/RM-07_Anzeigefeld.md) |
| Strom Max zurücksetzen | Interaktion (Klick auf Maximalwert) | „Ein Klick auf den Maximalwert setzt diesen auf 0l zurück.“ (im Handbuch „0l“, vermutlich „0“) | [RM-07](../Module/RM-07_Anzeigefeld.md) |
| Strom Limit | Zahlenfeld mit Schlüsselsymbol (rote Schrift) | „Begrenzung des zulässigen Motorstroms zur Fehlerprävention.“ | [RM-05](../Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) (Berechtigung) |

Nur im Bild sichtbar:

| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Pfeiltasten hoch/runter rechts | Tasten | im Handbuch nicht beschrieben (Blättern durch die Antriebsliste angenommen) | [RM-21](../Module/RM-21_Meldungsliste.md) |
| Antriebsnamen (Antrieb Zuführung 2MA1, Verschluss Dosierer 1 41MA1, Schnecke Dosierer 1 41MA2, Verschluss Dosierer 2 42MA1) | Beschriftung | – | [RM-33](../Module/RM-33_Motor-Statuszeile.md) (Servoantrieb) |
| Kopfzeile, Meldezeile, Funktionsleiste unten | Rahmen | siehe [RS-35](RS-35_Systemeinstellungen.md) | [RM-01](../Module/RM-01_Kopfzeile.md); [RM-02](../Module/RM-02_Meldezeile.md); [RM-03](../Module/RM-03_Funktionsleiste-unten.md) |

## Verwendete Module (IDs)

Module dieser Seite (Definitionen in der [Modulliste](../Module/Modulliste.md)):

- [RM-01](../Module/RM-01_Kopfzeile.md) – Kopfzeile
- [RM-02](../Module/RM-02_Meldezeile.md) – Meldezeile
- [RM-03](../Module/RM-03_Funktionsleiste-unten.md) – Funktionsleiste unten
- [RM-05](../Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) – Eingabefeld mit Schlüsselsymbol
- [RM-07](../Module/RM-07_Anzeigefeld.md) – Anzeigefeld
- [RM-09](../Module/RM-09_Fortschrittsbalken.md) – Fortschrittsbalken
- [RM-21](../Module/RM-21_Meldungsliste.md) – Meldungsliste
- [RM-33](../Module/RM-33_Motor-Statuszeile.md) – Motor-Statuszeile

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- Zurücksetzen: Antippen des Maximalwerts der CPU-Auslastung setzt ihn zurück; Klick auf „Strom Max“ setzt auf 0 (im Handbuch „0l“).
- Berechtigung: Strom-Limit-Felder tragen ein kleines Schlüsselsymbol (Eingabe nur mit Berechtigung, Stufe nicht genannt). Rote Schrift im Bild bei den Limit-Werten (Bedeutung nicht beschrieben).
- Fehlerzustände: Meldung „Motorschutz ausgelöst“ als Beispiel; im Bild zeigen alle 4 Antriebe diese Meldung bei Diag Code 0.
- Pop-ups: keine beschrieben (Eingabe des Limits vermutlich per Zahleneingabe-Pop-up: nicht belegt).
- Anzahl der Antriebe: im Bild 4 sichtbar, weitere über Pfeiltasten erreichbar (angenommen).

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RS-39-P01 | Navigationspfad | Einstellung › Systemeinstellungen › System- und Antriebsinfo, Zugang aus RS-35 | offen |
| RS-39-P02 | IPC: Prozessorauslastung | Balken plus Felder „Aktuell / Max.“ in % | offen |
| RS-39-P03 | IPC: Systemstart | Datum und Uhrzeit des letzten Starts (Format TT.MM.JJJJ hh:mm:ss) | offen |
| RS-39-P04 | IPC: Laufzeit gesamt | Drei Felder h, m, s | offen |
| RS-39-P05 | IPC: Status / Diag Code | Zwei Felder, z. B. „5 - running“ und „0 (0x000) - No Error“ | offen |
| RS-39-P06 | IPC: HMI Applikation Build | Datum/Uhrzeit der letzten Installation/des Updates | offen |
| RS-39-P07 | Max. CPU-Auslastung zurücksetzen | Antippen des Maximalwerts setzt ihn zurück | offen |
| RS-39-P08 | Servo: Diag Code und Meldung | Je Antrieb Diagnosenummer und Textmeldung | offen |
| RS-39-P09 | Servo: Strom Aktuell/Max/Limit | Drei Werte in % je Antrieb | offen |
| RS-39-P10 | Servo: Strom Max zurücksetzen | Klick auf Maximalwert setzt auf 0 | offen |
| RS-39-P11 | Servo: Strom Limit | Limit-Feld mit Schlüsselsymbol, Werte im Bild 100,0 % und 500,0 % | offen |
| RS-39-P12 | Antriebsliste | Blöcke Antrieb Zuführung 2MA1, Verschluss Dosierer 1 41MA1, Schnecke Dosierer 1 41MA2, Verschluss Dosierer 2 42MA1; Pfeiltasten blättern | offen |
| RS-39-P13 | Untere Leiste | Schloss, Produktion, Einstellungen, Zurück; keine Taste links | offen |

## Offene Punkte
- Titel im Bild „Systeminfo“, Kapitel „System- und Antriebsinfos“.
- Einheit und Wertebereich von „Strom Limit“, Eingabeverfahren und Berechtigungsstufe nicht beschrieben; Beispielwerte 100,0 % und 500,0 %.
- Negative Max-Werte im Bild (z. B. -24,4 %) nicht erklärt.
- Handbuch „setzt diesen auf 0l zurück“ (Tippfehler?).
- Pfeiltasten und Anzahl der Antriebe nicht beschrieben; Aktuell-Wert im Bild teilweise überdeckt.
- Bedeutung der roten Schrift bei „Strom Limit“ nicht beschrieben.
