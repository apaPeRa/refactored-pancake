# HS-39 – System- und Antriebsinfos

- Quelle: [RS-39](../../02_Referenz-Analyse/Seiten/RS-39_System-und-Antriebsinfos.md) (Kapitel 39, Tabellen 49 und 50, Bild RS-39_01); Design: keine eigene Design-Seite, Aufbau aus [Designsystem](../Designsystem.md) und den Modulen abgeleitet
- Navigationspfad: Einstellung › Systemeinstellungen › System- und Antriebsinfo (Zugang: [HS-35](HS-35_Systemeinstellungen.md), Kachel „System- und Antriebsinfo“; Zurück-Ziel: HS-35; Seitenregister `SystemInfo` / `settings/system/info`)

## Zweck

Zeigt den aktuellen Zustand des IPC sowie der angeschlossenen Servomotoren zur Systemdiagnose und zur schnellen Fehleranalyse bei Überlastungen, Störungen oder Ausfällen (Handbuch). Die Seite ist überwiegend Anzeige; bedienbar sind das Zurücksetzen der Maximalwerte und die Eingabe des Strom-Limits (berechtigungspflichtig).

## Aufbau (Bereiche, Layout)

Rahmen: [HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md) mit [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md) (leer, aber sichtbar). Seitenname laut Kapitel „System- und Antriebsinfos“, Brotkrümel-Segment „System- und Antriebsinfo“ (Bildtitel „Systeminfo“ gilt nicht, OP-33).

**Inhaltsbereich** (12-Spalten-Raster, Außenrand `Space.L`, Gutter `Space.M`): zwei Gruppenbereiche ([HM-15](../Module/HM-15_Gruppenbereich.md), Variante Panel) **4 : 8** nebeneinander, Höhe jeweils 1\*.

```
Inhaltsbereich (12 Spalten)
+------------------------+--------------------------------------------+
| Gruppe "IPC" (4 Sp.)   | Gruppe "Servomotoren" (8 Sp.)              |
| Prozessorauslastung:   | Kopf:  Diag | Aktuell | Max | Limit        |
| [=====    ] 15 %       | +----------------------------------------+ |
| Aktuell [15 %] Max     | | Antrieb Zufuehrung 2MA1                | |
|        [42 %] (Reset)  | | [0] [0,0 %] [-24,4 %] [100,0 %]  Key   | |
| Systemstart:           | | Meldung: Motorschutz ausgeloest  Fehler| |
| [02.04.2025 01:22:42]  | +----------------------------------------+ |
| Laufzeit gesamt:       | | Verschluss Dosierer 1 41MA1 ...        | |
| [744 h] [1 m] [14 s]   | | Schnecke Dosierer 1 41MA2 ...          | |
| Status / Diag Code:    | | Verschluss Dosierer 2 42MA1 ...        | |
| [5 - running]          | +----------------------------------------+ |
| [0 (0x000) - No Error] |  Blaettertasten  [ ^ ]  [ v ]  "1-4 von n" |
| HMI Applikation Build: |                                            |
| [09.05.2025 10:42:17]  |                                            |
+------------------------+--------------------------------------------+
Funktionsleiste unten: leer
```

- **Gruppe „IPC“ (Spalten 1 bis 4):** Überschrift „IPC“, darunter die fünf Zeilen der Referenz untereinander. Jede Zeile besteht aus einer Beschriftung (Caption oder Body) und den Feldern darunter, damit sie in die schmale Gruppe passen: Prozessorauslastung (Fortschrittsbalken über die Gruppenbreite, darunter zwei Felder „Aktuell“ und „Max.“ nebeneinander), Systemstart (ein Feld), Laufzeit gesamt (drei Felder „h“, „m“, „s“ nebeneinander), Status / Diag Code (zwei Felder untereinander), HMI Applikation Build (ein Feld).
- **Gruppe „Servomotoren“ (Spalten 5 bis 12):** Überschrift „Servomotoren“; links die Liste der Antriebe, rechts eine schmale Spalte mit den zwei Blättertasten. Je Antrieb ein Block (Motor-Statuszeile) mit zwei Zeilen: Zeile 1 Antriebsname und die Felder Diag Code, Strom Aktuell, Strom Max, Strom Limit; Zeile 2 das Meldungsfeld über die volle Blockbreite. Eine gemeinsame Beschriftungszeile am Listenkopf („Diag Code“, „Aktuell“, „Max“, „Limit“) spart die Wiederholung. Es sind vier Antriebe gleichzeitig sichtbar; die Blättertasten zeigen weitere.
- **Funktionsleiste unten:** leer (Navigation.md 3.3, „Ohne eigene Tasten“).

## Elemente

Spalte „Herkunft“ = Rückverfolgung zu [RS-39](../../02_Referenz-Analyse/Seiten/RS-39_System-und-Antriebsinfos.md) (Tabelle 49 = IPC-Bereich, Tabelle 50 = Servomotoren).

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Prozessorauslastung | Fortschrittsbalken plus 2 Zahlenfelder „Aktuell“ / „Max.“ (Einheit %) | Aktuelle und maximale CPU-Auslastung des IPC. Zahl im Balken; Statusfarbe nur bei Schwellenüberschreitung mit Symbol und Wort (Schwellen konfigurierbar, OP-27). Im Bild ist der Aktuell-Wert teilweise verdeckt; im neuen HMI vollständig. | [HM-10](../Module/HM-10_Fortschrittsbalken.md); [HM-11](../Module/HM-11_Anzeigefeld.md) | RS-39 Tabelle 49, Zeile 1 |
| Systemstart | Datum/Uhrzeit-Anzeige | Datum und Uhrzeit des letzten Starts der Steuerung (Format TT.MM.JJJJ hh:mm:ss). | [HM-11](../Module/HM-11_Anzeigefeld.md) (Wertart DateTime) | Zeile 2 |
| Laufzeit gesamt | Anzeige in h / m / s (3 Felder) | Zeit seit der Inbetriebnahme des Systems; die Felder tragen die Einheiten „h“, „m“, „s“ (Bild 744 h, 1 m, 14 s). | [HM-11](../Module/HM-11_Anzeigefeld.md) (Wertart Duration) | Zeile 3 |
| Status / Diag Code | 2 Textfelder | Diagnosestatus und laufende Systemmeldungen (Bild „5 - running“ und „0 (0x000) - No Error“). | [HM-11](../Module/HM-11_Anzeigefeld.md) (Wertart Text) | Zeile 4 |
| HMI Applikation Build | Datum/Uhrzeit-Anzeige | Zeitpunkt der letzten Softwareinstallation bzw. des letzten Updates der HMI. | [HM-11](../Module/HM-11_Anzeigefeld.md) (Wertart DateTime) | Zeile 5 |
| Maximale Auslastung zurücksetzen | Interaktion (Antippen des Maximalwertfelds) | Der Maximalwert der CPU-Auslastung wird durch Antippen zurückgesetzt; das Feld trägt als zweiten Kanal `Icon.Action.Reset`. | [HM-11](../Module/HM-11_Anzeigefeld.md) (Parameter rücksetzbar) | Zeile 6 |
| Diag Code (je Antrieb) | Zahlenfeld | Diagnosenummer des Antriebs (z. B. für Servofehler oder Überlast). | [HM-34](../Module/HM-34_Motor-Statuszeile.md) | RS-39 Tabelle 50, Zeile 1 |
| Meldung (je Antrieb) | Textfeld | Textmeldung zur Fehlerursache (z. B. „Motorschutz ausgelöst“); bei Meldung Zeilenzustand Fehler mit `Icon.Status.Error` und Text. | [HM-34](../Module/HM-34_Motor-Statuszeile.md) | Zeile 2 |
| Strom Ist / Max / Limit (je Antrieb) | 3 Zahlenfelder (Einheit %, im Bild „Aktuell / Max / Limit“) | Vergleich von aktuellem Stromwert, bisherigem Höchstwert und konfiguriertem Grenzwert. Negative Maximalwerte des Bildes (z. B. −24,4 %) werden unverändert angezeigt (OP-29). | [HM-34](../Module/HM-34_Motor-Statuszeile.md), [HM-11](../Module/HM-11_Anzeigefeld.md) | Zeile 3 |
| Strom Max zurücksetzen (je Antrieb) | Interaktion (Antippen des Maximalwerts) | Antippen setzt den Maximalwert auf 0 zurück (Handbuch „0l“, vermutlich „0“, OP-35); Symbol `Icon.Action.Reset` im Feld. | [HM-34](../Module/HM-34_Motor-Statuszeile.md) (`ResetMaxCommand`) | Zeile 4 |
| Strom Limit (je Antrieb) | Eingabefeld mit Schlüsselsymbol | Begrenzung des zulässigen Motorstroms zur Fehlerprävention. Antippen öffnet das Eingabe-Pop-up mit Grenzen (Bildwerte 100,0 % und 500,0 %, Grenzen offen, OP-28). Die rote Schrift des Bildes entfällt (Rot nur für Fehler). | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) (in [HM-34](../Module/HM-34_Motor-Statuszeile.md)), [HM-13](../Module/HM-13_Eingabe-Pop-up.md), [HM-14](../Module/HM-14_Popup-Rahmen.md) | Zeile 5 |
| Antriebsnamen (Antrieb Zuführung 2MA1, Verschluss Dosierer 1 41MA1, Schnecke Dosierer 1 41MA2, Verschluss Dosierer 2 42MA1) | Beschriftung je Block | Name des Servoantriebs mit Betriebsmittelkennzeichen; Namen und Anzahl konfigurationsabhängig (OP-41). | [HM-34](../Module/HM-34_Motor-Statuszeile.md) | RS-39 „nur im Bild“, Zeile 2 |
| Pfeiltasten hoch/runter | Blättertasten | Im Handbuch nicht beschrieben; Annahme: Blättern durch die Antriebsliste, Positionsanzeige „n–m von k“; am Rand deaktiviert (gestrichelt). Kein Verlaufseintrag. | [HM-19](../Module/HM-19_Blaettertasten.md) | „nur im Bild“, Zeile 1 |
| Gruppen „IPC“ und „Servomotoren“ | Gruppenbereich | Zwei Gruppen mit Überschrift und Rahmen wie im Bild. | [HM-15](../Module/HM-15_Gruppenbereich.md) | Bild RS-39_01 |
| Kopfzeile, Meldezeile, Funktionsleiste unten | Rahmen | Wie [HS-35](HS-35_Systemeinstellungen.md): Uhrzeit und Datum, Meldezeile, Funktionsleiste ohne Tasten, Produktion/Einstellungen/Zurück und Anmeldestatus in der Seitenleiste. | [HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-06](../Module/HM-06_Funktionsleiste.md), [HM-01](../Module/HM-01_Seitenleiste.md) | „nur im Bild“, Zeile 3 |

## Verwendete Module

- Rahmen: [HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md)
- Seite: [HM-15](../Module/HM-15_Gruppenbereich.md), [HM-10](../Module/HM-10_Fortschrittsbalken.md), [HM-11](../Module/HM-11_Anzeigefeld.md), [HM-34](../Module/HM-34_Motor-Statuszeile.md) (enthält [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md)), [HM-19](../Module/HM-19_Blaettertasten.md), [HM-13](../Module/HM-13_Eingabe-Pop-up.md), [HM-14](../Module/HM-14_Popup-Rahmen.md)

## Zustände und Interaktion

- **Zurücksetzen.** Antippen des Maximalwerts (CPU-Auslastung oder Strom Max) setzt ihn zurück; Rückmeldung unmittelbar (Wert springt auf 0 bzw. aktuellen Wert), die Referenz beschreibt keine Rückfrage. Ob eine Berechtigung nötig ist, ist nicht beschrieben (kein Schlüsselsymbol im Bild).
- **Strom Limit.** Das Feld trägt `Icon.Key`; Eingabe nur mit Berechtigung (Stufe offen, OP-25, Dummy). Ohne Rolle zeigt das Feld `Icon.Lock`, Antippen öffnet das Benutzer-Pop-up. Mit Rolle öffnet Antippen das Eingabe-Pop-up (Titel „Strom Limit <Antrieb>“, Einheit %, Grenzen als Caption). Ungültiger Wert: Fehlerrahmen und Text, „Übernehmen“ deaktiviert; bis zum Übernehmen wird nichts in die Steuerung geschrieben.
- **Fehlerzustand eines Antriebs.** Liegt eine Meldung vor (im Bild bei allen vier Antrieben „Motorschutz ausgelöst“ bei Diag Code 0), zeigt der Block den Zustand Fehler: Flächenton `Brush.Status.Error.Subtle`, `Icon.Status.Error` und der Meldungstext. Der Diag Code wird unverändert angezeigt (Bild: 0 trotz Meldung; Zusammenhang offen).
- **CPU-Schwellen.** Der Balken bleibt neutral; ab konfigurierbarer Schwelle Warnung mit `Icon.Status.Warning` und Wort (Dummy-Schwelle, OP-27).
- **Ungültige Werte.** Fehlen Daten (Kommunikation unterbrochen), zeigen die Felder „---“ und keine Null.
- **Blättern.** Die Pfeiltasten verschieben das Fenster der sichtbaren Antriebe; am Anfang bzw. Ende ist die jeweilige Taste deaktiviert. Die Liste der Antriebe ist konfigurationsabhängig (OP-41).
- **Pop-ups.** Nur das Eingabe-Pop-up und das Benutzer-Pop-up; Seitenleiste und Inhalt gesperrt (Navigation.md 4.2).
- **Zurück.** Seitenleiste „Zurück“ oder Brotkrümel-Segment „Systemeinstellungen“ führt nach HS-35.

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-39-P01 | Navigationspfad (RS-39-P01) | Brotkrümel „Einstellung › Systemeinstellungen › System- und Antriebsinfo“, Zugang über Kachel in HS-35, Zurück nach HS-35 | offen |
| HS-39-P02 | IPC: Prozessorauslastung (RS-39-P02) | Balken mit Zahl plus Felder „Aktuell“ und „Max.“ in % | offen |
| HS-39-P03 | IPC: Systemstart (RS-39-P03) | Datum und Uhrzeit des letzten Starts, Format TT.MM.JJJJ hh:mm:ss | offen |
| HS-39-P04 | IPC: Laufzeit gesamt (RS-39-P04) | Drei Felder mit Einheiten h, m, s | offen |
| HS-39-P05 | IPC: Status / Diag Code (RS-39-P05) | Zwei Felder, z. B. „5 - running“ und „0 (0x000) - No Error“ | offen |
| HS-39-P06 | IPC: HMI Applikation Build (RS-39-P06) | Datum/Uhrzeit der letzten Installation bzw. des letzten Updates | offen |
| HS-39-P07 | Maximale CPU-Auslastung zurücksetzen (RS-39-P07) | Antippen des Maximalwerts setzt ihn zurück; Feld trägt `Icon.Action.Reset` | offen |
| HS-39-P08 | Servo: Diag Code und Meldung (RS-39-P08) | Je Antrieb Diagnosenummer und Textmeldung; Meldung mit `Icon.Status.Error` und Text | offen |
| HS-39-P09 | Servo: Strom Aktuell/Max/Limit (RS-39-P09) | Drei Werte in % je Antrieb | offen |
| HS-39-P10 | Servo: Strom Max zurücksetzen (RS-39-P10) | Antippen des Maximalwerts setzt ihn auf 0 | offen |
| HS-39-P11 | Servo: Strom Limit (RS-39-P11) | Limit-Feld mit `Icon.Key`, Bildwerte 100,0 % und 500,0 %; Eingabe über Pop-up nur mit Rolle; Schrift nicht rot | offen |
| HS-39-P12 | Antriebsliste (RS-39-P12) | Vier Blöcke: Antrieb Zuführung 2MA1, Verschluss Dosierer 1 41MA1, Schnecke Dosierer 1 41MA2, Verschluss Dosierer 2 42MA1; Pfeiltasten blättern; Randtaste deaktiviert | offen |
| HS-39-P13 | Untere Leiste (RS-39-P13) | Funktionsleiste sichtbar ohne Tasten; Produktion, Einstellungen, Zurück, Anmeldestatus in der Seitenleiste | offen |
| HS-39-P14 | Berechtigung Strom Limit | Ohne Rolle `Icon.Lock` und Hinweis „Berechtigung erforderlich: <Rolle>“, kein Eingabe-Pop-up | offen |
| HS-39-P15 | Ungültige Eingabe | Wert außerhalb der Grenzen zeigt Fehlerrahmen mit Fehlertext, „Übernehmen“ deaktiviert | offen |
| HS-39-P16 | Touch-Ziele | Rücksetzbare Felder, Limit-Felder und Blättertasten mindestens `Size.Touch.Min` bzw. `Size.Touch.Default`, Abstand `Size.Touch.Gap`; Schrift mindestens `Font.Size.Caption` | offen |
| HS-39-P17 | Zweiter Kanal | Fehlerzustand über Symbol und Text, Balkenschwelle über Symbol und Wort, Rücksetzen über `Icon.Action.Reset`, Schloss/Schlüssel als Symbol; kein Zustand nur über Farbe | offen |
| HS-39-P18 | Tokens | Keine Hex- und Pixelwerte im Seitenaufbau; nur Tokens des Designsystems | offen |

## Offene Punkte

- OP-25: Berechtigungsstufe für Strom Limit und für das Zurücksetzen.
- OP-27: Bedeutung der roten Schrift bei „Strom Limit“, Farbe des Auslastungsbalkens (Schwellen).
- OP-28: Wertebereich und Einheit von „Strom Limit“, Eingabeverfahren.
- OP-29: Einheiten und Nachkommastellen (Strom in %, negative Maxima).
- OP-30: Eingabe-Pop-up für das Limit nicht belegt.
- OP-33: Titel „Systeminfo“ (Bild) gegenüber „System- und Antriebsinfos“ (Kapitel).
- OP-35: Tippfehler „0l“ im Handbuch.
- OP-41: Anzahl und Namen der Antriebe konfigurationsabhängig, Funktion der Pfeiltasten angenommen.
- OP-44: Aktuell-Wert im Bild teilweise überdeckt.
- OP-49: nicht beschriebene Funktionen.
