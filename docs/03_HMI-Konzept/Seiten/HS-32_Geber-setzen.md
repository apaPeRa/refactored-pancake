# HS-32 – Geber setzen

- Quelle: [RS-32 Geber setzen](../../02_Referenz-Analyse/Seiten/RS-32_Geber-setzen.md) (Handbuch Kapitel „Geber setzen“, Tabelle T42, Hinweis-Textfeld, Bild [RS-32_01.png](../../02_Referenz-Analyse/Medien/RS-32_01.png)). Kein Design-Screenshot vorhanden: Aufbau abgeleitet aus [Designsystem](../Designsystem.md) und den HM-Modulen.
- Navigationspfad (Brotkrümel laut [Navigation.md](../Navigation.md), Abschnitt 2): **Einstellung › Geber setzen**. Zugang: HS-04, Kachel „Geber setzen“ (A-36). Zurück-Ziel: HS-04 (Verlauf). Seitenregister: `EncoderSetting` / `settings/encoders`, Eltern HS-04, Parameter `encoderIndex`, keine Mindestrolle der Seite (die Taste „Geber setzen“ ist einzeln geschützt).

## Zweck

Setzen des Nullpunkts eines Gebers, z. B. nach dem Austausch eines Drehgebers oder Servomotors. Der korrekte Nullpunkt ist entscheidend für die präzise Positionierung im Betrieb (Handbuch, RS-32 Zweck). Die Seite zeigt Motorposition, Geberposition und den automatisch berechneten Offset, den Initialisierungszustand der Achse und übernimmt mit einem langen Druck auf „Geber setzen“ die aktuelle Motorposition als neuen Nullpunkt. Die Blättertasten wechseln zwischen den Gebern. Die Aktion verändert die Positionsreferenz der Maschine und ist daher sicherheitsrelevant (Not-Aus-Voraussetzung).

## Aufbau (Bereiche, Layout)

Rahmen wie auf allen Seiten (Seitenleiste 3\* : Arbeitsbereich 37\*; Zeilen 4\* : 3\* : 34\* : 4\*). Der Inhaltsbereich (Außenrand `Space.L`, 12 Spalten, Abstand `Size.Touch.Gap`) hat fünf Zeilen:

1. **Objektüberschrift** (Auto): Titelzeile mit dem Namen des Gebers/Antriebs, 12 Spalten.
2. **Werte und Aktion** (Stern): links Spalten 1–7 vier Zeilen (je Beschriftung links, Wert rechts: Motor Position, Geber Position, Positions Offset, Achse initialisiert); rechts Spalten 9–12 die große Taste „Geber setzen“ (Höhe über die Zeilen, mindestens `Size.Touch.Large`).
3. **Statustext** (Auto): Spalten 1–7 zentriert unter der LED der Textzeile „Messer beginnt Schneidbewegung.“ (Statustext der Steuerung).
4. **Warnhinweis** (Auto): Hinweis-Textfeld zum Not-Aus über alle 12 Spalten. In der Referenz steht der Text nur im Handbuch, nicht im Bild; im neuen HMI ist er dauerhaft sichtbar, weil er eine Bedienvoraussetzung nennt.
5. **Blättern und Meldung** (Auto): Spalten 1–4 Blättertasten (Paar mit „n von m“), Spalten 5–12 Meldungsfeld „Meldung:“.
6. **Funktionsleiste:** leer, aber sichtbar (keine Taste „Suchen“, RS-32-P11).

```
Inhaltsbereich (12 Spalten)
+--------------------------------------------------------------------+
|            Antrieb Zuführung 2MA1           (HM-17, Sp. 1-12)      |
+--------------------------------------------+---+-------------------+
| Motor Position:        [      -2596,261 ]  |   |                   |
| Geber Position:        [          0,000 ]  |   |   [ Geber setzen ]|
| Positions Offset:      [      -2596,261 ]  |   |   Key  (Halten)   |
| Achse initialisiert:   (v) OK              |   |      Sp. 9-12     |
|                    Sp. 1-7                 |   |                   |
+--------------------------------------------+   +-------------------+
|        Messer beginnt Schneidbewegung.   (Statustext, Sp. 1-7)     |
+--------------------------------------------------------------------+
| (!) Warnung: Zum Setzen eines Gebers muss mindestens ein Not-Aus-  |
|     Taster gedrückt sein. ... (HM-27, Sp. 1-12)                    |
+-----------+--------------------------------------------------------+
| [<<] [>>] |  Meldung:  –                                           |
| 1 von 2   |                                                        |
+-----------+--------------------------------------------------------+
Funktionsleiste:  (leer)
```

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)

Die Spalte „Herkunft (RS-32)“ ist die Rückverfolgung zur Referenzseite (Elementetabelle, T42, Hinweis-Textfeld, Bild).

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-32) |
|---|---|---|---|---|
| E01 Brotkrümel „Einstellung › Geber setzen“ | Anzeige / Navigation | Pfad; „Einstellung“ → HS-04, letztes Segment nur Anzeige; bleibt beim Blättern der Geber unverändert. Ersetzt den Seitentitel „Geber setzen“ der Referenz-Kopfzeile | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | Kopfzeile (Seitentitel); Navigationspfad |
| E02 Kopfzeile: Logo, Betriebsart, Uhrzeit/Datum | Anzeige | Logo, Betriebsart (Wirbel-Symbol → A-48), Uhrzeit „13:05:44“ als Beispiel, Datum | [HM-02](../Module/HM-02_Kopfzeile.md) | Kopfzeile |
| E03 Kennzahlen Geschwindigkeit, Maschinenwinkel | Anzeige | Rahmenelement des Designs | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | – (Rahmen) |
| E04 Meldezeile „450: Palettierung nicht bereit“ | Anzeige | Wichtigste Maschinenmeldung (global); Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | Meldezeile |
| E05 Seitenleiste | Navigation | Benutzerkreis (Schloss), Home („Produktion“), Einstellungen, Meldungen, Zurück (→ HS-04) | [HM-01](../Module/HM-01_Seitenleiste.md) | Schloss; Tasten „Produktion“, „Einstellungen“, „Zurück“ |
| E06 Achs-Überschrift „Antrieb Zuführung 2MA1“ | Anzeige (Text) | Name des Gebers/Antriebs; wechselt mit den Blättertasten | [HM-17](../Module/HM-17_Titelzeile.md) | Achs-Überschrift; T42 (Bildbeispiel) |
| E07 Motor Position | Anzeigefeld numerisch mit Beschriftung | Aktuelle Position des Motors, Beispiel „-2596,261“; Dezimalkomma, drei Nachkommastellen, Einheit nicht angegeben | [HM-11](../Module/HM-11_Anzeigefeld.md) (Feld, Zahl) | Motor Position; T42 „Motor Position“ |
| E08 Geber Position | Anzeigefeld numerisch mit Beschriftung | Derzeitige Position des Gebers, Beispiel „0,000“ | [HM-11](../Module/HM-11_Anzeigefeld.md) (Feld, Zahl) | Geber Position; T42 „Geber Position“ |
| E09 Positions Offset | Anzeigefeld numerisch mit Beschriftung | Differenz zwischen Motor- und Geberposition (Motor minus Geber), automatisch berechnet, nicht editierbar; Beispiel „-2596,261“ | [HM-11](../Module/HM-11_Anzeigefeld.md) (Feld, Zahl) | Positions Offset; T42 „Positions Offset“ |
| E10 Achse initialisiert | Status-LED | Zeigt, ob die Initialisierung der Achse erfolgreich war: „OK“ mit Haken (Referenz: grüne Anzeige); sonst „Nicht initialisiert“ mit Warnsymbol | [HM-09](../Module/HM-09_Status-LED.md) | Achse initialisiert; T42 „Achse initialisiert“ |
| E11 Taste „Geber setzen“ | Taste mit Schlüsselsymbol (langes Drücken) | Speichert die aktuelle Motorposition als neuen Nullpunkt (Geberposition); löst erst nach der Haltedauer aus, mit Fortschrittsstreifen und Text „Halten …“ | [HM-07](../Module/HM-07_Aktionstaste.md) (Auslösung Halten, Schlüssel) | Taste „Geber setzen“; T42 „Geber setzen“; Hinweis-Textfeld (langes Drücken) |
| E12 Statustext „Messer beginnt Schneidbewegung.“ | Anzeige (Text) | Von der Steuerung gelieferte Textzeile, in der Referenz ohne Handbuchbeschreibung (Bildbeispiel); Darstellung als Info-Zeile | [HM-27](../Module/HM-27_Hinweis-Textfeld.md) (Art Info) | Text unter der LED (im Handbuch nicht beschrieben) |
| E13 Hinweis-Textfeld Not-Aus | Hinweis-Textfeld mit Warnzeichen | Wortlaut des Handbuchs (siehe unten) als dauerhafter Warnhinweis mit `Icon.Status.Warning` und Wort „Warnung“ | [HM-27](../Module/HM-27_Hinweis-Textfeld.md) (Art Warnung) | Hinweis-Textfeld (⚠) |
| E14 „Meldung:“ mit Text | Statusanzeige | Systemhinweise oder Fehler; Bild: leer („–“). Getrennt von der globalen Meldezeile E04 | [HM-27](../Module/HM-27_Hinweis-Textfeld.md) (Art `MessageLine`; bei Störungstext Art `Error` mit Caption „Meldung:“) | Meldung; T42 „Meldung“ |
| E15 Tasten „<<“ und „>>“ | Blättertasten | Wechseln zwischen den Gebern (`encoderIndex`); Paar mit Positionsanzeige „n von m“; am Rand deaktiviert | [HM-19](../Module/HM-19_Blaettertasten.md) | Tasten „<<“ / „>>“; T42 „Navigationstasten“ |
| E16 Funktionsleiste unten | Container | Leer, aber sichtbar; keine Taste „Suchen“ | [HM-06](../Module/HM-06_Funktionsleiste.md) | Untere Funktionsleiste (ohne „Suchen“) |

**Wortlaut des Hinweis-Textfelds (Handbuch, E13):** „Zum Setzen eines Gebers muss mindestens ein Not-Aus-Taster gedrückt sein. Anschließend ist die Achse manuell in die Referenzposition bringen. Mit langem Drücken der Taste „Geber setzen“ wird der aktuelle Wert des Motors als neue Geberposition übernommen.“ Der Quellsatz „… in die Referenzposition bringen“ ist fehlerhaft. Die Seite zeigt den Quellwortlaut; ob die `.resx` ihn korrigiert („… zu bringen“), ist eine offene Entscheidung (OP-35).

## Verwendete Module (IDs)

- Rahmen: [HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md)
- Seite: [HM-07](../Module/HM-07_Aktionstaste.md) Aktionstaste, [HM-09](../Module/HM-09_Status-LED.md) Status-LED, [HM-11](../Module/HM-11_Anzeigefeld.md) Anzeigefeld, [HM-17](../Module/HM-17_Titelzeile.md) Titelzeile, [HM-19](../Module/HM-19_Blaettertasten.md) Blättertasten, [HM-27](../Module/HM-27_Hinweis-Textfeld.md) Hinweis-Textfeld

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

- **Ablauf nach Handbuch:** (1) mindestens ein Not-Aus-Taster gedrückt, (2) Achse manuell in die Referenzposition bringen (außerhalb dieser Seite), (3) Taste „Geber setzen“ lange drücken; der aktuelle Motorwert wird als neue Geberposition übernommen. Danach zeigt „Geber Position“ den Motorwert, „Positions Offset“ ergibt sich neu (Motor minus Geber).
- **Voraussetzung Not-Aus (Annahme, die Referenz beschreibt das Verhalten ohne Not-Aus nicht):** Die Taste „Geber setzen“ ist nur bedienbar, wenn die Steuerung „Not-Aus gedrückt“ meldet. Sonst ist sie deaktiviert (gestrichelte Kontur, Text deaktiviert, `Icon.Block`); Tippen nennt den Grund „Not-Aus-Taster nicht gedrückt“ in der Meldezeile (A-28). Meldet die Steuerung keinen Not-Aus-Zustand, bleibt die Taste deaktiviert (sicherer Zustand).
- **Langes Drücken:** Die Taste löst erst nach der Haltedauer aus (Dummy 1000 ms, konfigurierbar, OP-42); während des Haltens läuft der Fortschrittsstreifen, der Text lautet „Halten …“. Loslassen vor Ablauf bricht ab, es wird nichts gesetzt. Seitenwechsel, Blättern, Verlust von Not-Aus oder Rollenverlust während des Haltens brechen ebenfalls ab. Rückmeldung nach dem Setzen: Eintrag „Geber gesetzt“ in „Meldung:“ (Text Annahme, OP-42).
- **Bestätigung:** Vor dem Setzen erscheint keine zusätzliche Rückfrage, weil das lange Drücken die Absicht bestätigt (Handbuch). Ein Bestätigungs-Pop-up ist nicht vorgesehen; ob es ergänzt wird, ist Entscheidung zu OP-31.
- **Berechtigung:** Schlüsselsymbol (`Icon.Key`) an E11; fehlt die Rolle, steht `Icon.Lock`, Tippen öffnet das Benutzer-Pop-up (Navigation.md 4.1) und die Meldezeile nennt „Berechtigung erforderlich: <Rolle>“. Die Stufe nennt die Quelle nicht (OP-25, OP-04): Dummy-Rolle.
- **Achse nicht initialisiert:** Die Referenz beschreibt nur den OK-Zustand. Annahme: LED „Nicht initialisiert“ mit `Icon.Status.Warning` und Wort; die Taste „Geber setzen“ bleibt bedienbar.
- **Statustext E12 und Meldung E14:** Texte kommen aus der Steuerung (im Handbuch nicht aufgelistet); fehlt ein Text, steht „–“. Störungen erscheinen in E14 als HM-27 Art `Error` mit Caption „Meldung:“, `Icon.Status.Error` und Wort „Fehler“; Normaltext als Art `MessageLine` (je Zeitpunkt genau eine Art).
- **Blättern:** « und » ersetzen nur den Parameter `encoderIndex` (kein Verlaufseintrag, A-42); Titelzeile und Werte wechseln, der Brotkrümel bleibt. Reihenfolge und Liste der Geber kommen aus der Konfiguration (OP-41). Während „Geber setzen“ gehalten wird, sind die Blättertasten gesperrt.
- **Fehlerfälle:** Ist der Geber nicht erreichbar, zeigen die Felder „---“, die LED „Unbekannt“, die Taste ist deaktiviert.
- **Zurück:** Seitenleiste „Zurück“ → HS-04 (Verlauf); Brotkrümel-Segment „Einstellung“ → HS-04.

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-32-P01 | Seitentitel (RS-32-P01) | Letztes Brotkrümel-Segment lautet „Geber setzen“ (Navigation.md), keine zweite Titelzeile in der Kopfzeile | offen |
| HS-32-P02 | Achs-Überschrift (RS-32-P02) | Name des Antriebs, Beispiel „Antrieb Zuführung 2MA1“ | offen |
| HS-32-P03 | Felder Motor Position, Geber Position, Positions Offset (RS-32-P03) | Drei Anzeigefelder, Beispielwerte -2596,261 / 0,000 / -2596,261; Dezimalkomma, drei Nachkommastellen | offen |
| HS-32-P04 | Positions Offset (RS-32-P04) | Differenz Motor minus Geber, automatisch berechnet, nicht editierbar (-2596,261 − 0,000 = -2596,261) | offen |
| HS-32-P05 | LED „Achse initialisiert“ (RS-32-P05) | Initialisierung erfolgreich: Symbol Haken und Wort „OK“ (Referenz: grün); nicht initialisiert: Warnsymbol und Wort | offen |
| HS-32-P06 | Taste „Geber setzen“ (RS-32-P06) | Große Taste mit Schlüsselsymbol; speichert die aktuelle Motorposition als neuen Nullpunkt | offen |
| HS-32-P07 | Bedienung der Taste (RS-32-P07) | Langes Drücken (Fortschrittsstreifen, Text „Halten …“) übernimmt den Motorwert als neue Geberposition; kurzes Antippen oder vorzeitiges Loslassen setzt nichts | offen |
| HS-32-P08 | Hinweis Not-Aus (RS-32-P08) | Hinweistext sichtbar: mindestens ein Not-Aus-Taster muss gedrückt sein; danach Achse manuell in die Referenzposition bringen; Taste ohne gedrückten Not-Aus deaktiviert | offen |
| HS-32-P09 | Zeile „Meldung:“ (RS-32-P09) | Statusanzeige für Systemhinweise oder Fehler; leer als „–“ | offen |
| HS-32-P10 | Tasten „<<“ und „>>“ (RS-32-P10) | Wechseln zwischen den Gebern, „n von m“, am Rand deaktiviert, kein Verlaufseintrag | offen |
| HS-32-P11 | Untere Funktionsleiste (RS-32-P11) | Keine Taste „Suchen“, Leiste leer sichtbar; Schloss (Benutzerkreis), Produktion, Einstellungen, Zurück in der Seitenleiste | offen |
| HS-32-P12 | Navigation (RS-32-P12) | „Einstellung › Geber setzen“; Zugang über Kachel in HS-04; Zurück → HS-04 | offen |
| HS-32-P13 | Statustext (Bild RS-32_01) | Zeile „Messer beginnt Schneidbewegung.“ ist als Info-Zeile unter den Werten vorhanden | offen |
| HS-32-P14 | Abbruchfälle | Loslassen vor Ablauf, Seitenwechsel, Blättern und Verlust von Not-Aus brechen das Setzen ab; der Wert bleibt unverändert | offen |
| HS-32-P15 | Berechtigung | Schlüsselsymbol an „Geber setzen“; ohne Rolle öffnet das Benutzer-Pop-up und nichts wird gesetzt | offen |
| HS-32-P16 | Touch-Ziele (Designsystem) | Taste „Geber setzen“ mindestens `Size.Touch.Large` hoch; Blättertasten mindestens `Size.Touch.Default` × `Size.Touch.Default`; Abstand mindestens `Size.Touch.Gap` | offen |
| HS-32-P17 | Zweiter Kanal (Designsystem) | LED, deaktiviert, Halten, Warnhinweis und Fehler zusätzlich durch Symbol, Wort oder Konturform erkennbar, nicht nur durch Farbe | offen |
| HS-32-P18 | Tokens (Designsystem) | Keine Hex-, Pixel- oder Literalwerte; keine Unterstreichung als Hervorhebung; Texte aus `.resx` | offen |
| HS-32-P19 | Rückverfolgung | Jede Zeile der Tabelle T42, das Hinweis-Textfeld und jedes Element des Bildes RS-32_01 sind in E01 bis E16 wiederzufinden | offen |

## Offene Punkte

- OP-25 / OP-04 (Schlüsselsymbol, Berechtigungsstufe): Dummy-Rolle.
- OP-28 (Wertebereiche) und OP-29 (Einheiten): Positionsfelder ohne Einheit und Wertebereich; Anzeige mit drei Nachkommastellen nach dem Bild.
- OP-31 (Sperrzustände, Rückfragen): Verhalten ohne gedrückten Not-Aus und eine mögliche Bestätigung sind Annahmen.
- OP-35 (Quellfehler): Satzfehler im Hinweis-Textfeld; Wortlaut zitiert, Korrektur in der `.resx` ist offene Entscheidung.
- OP-37 (Zugang Geber setzen): im Handbuch nur als Eintrag in RS-04 beschrieben; Kachel nach A-36.
- OP-39 (fehlende Zustände): Zustand „Achse nicht initialisiert“ nicht beschrieben (Annahme: Warnung).
- OP-41 (geräteabhängige Elemente): Anzahl und Reihenfolge der Geber.
- OP-42 (Zeit- und Dauerangaben): Dauer des langen Drückens und Rückmeldung nach dem Setzen; Dummy-Werte.
- OP-48 (Bedeutung Geber setzen): Ablauf und Bedeutung einzelner Felder offen, keine Annahme über Fachlogik.
- OP-59 Bedeutung des Statustexts „Messer beginnt Schneidbewegung.“ (RS-32, Offene Punkte 1; Platzhalter oder Rest); OP-60 Sperre der Taste ohne Not-Aus.
