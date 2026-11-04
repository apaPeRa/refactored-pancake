# HS-31 – Handbetrieb

- Quelle: [RS-31 Handbetrieb](../../02_Referenz-Analyse/Seiten/RS-31_Handbetrieb.md) (Handbuch Kapitel „Handbetrieb“, Tabelle T41, Bild [RS-31_01.png](../../02_Referenz-Analyse/Medien/RS-31_01.png)). Kein Design-Screenshot vorhanden: Aufbau abgeleitet aus [Designsystem](../Designsystem.md) (12-Spalten-Raster, Abschnitte 3 bis 7) und den HM-Modulen.
- Navigationspfad (Brotkrümel laut [Navigation.md](../Navigation.md), Abschnitt 2): **Einstellung › Handbetrieb › `<Gruppe>`** (Beispiel „Einstellung › Handbetrieb › GR20 Schließmaschine“). Zugang: HS-30, Gruppentaste GRxx (Parameter `groupId`); Such-Pop-up: Treffer. Zurück-Ziel: HS-30. Seitenregister: `ManualOperation` / `settings/manual/group`, Eltern HS-30, Parameter `groupId`, optional `actorId`, keine Mindestrolle der Seite (Felder und Tasten sind einzeln geschützt).

## Zweck

Gezieltes Ansteuern **eines** Aktors im Handbetrieb (Jog in beide Richtungen, bei Servoantrieben im Positioniermodus Positionsschritte) und Anzeige der Statusinformationen zur aktuellen Position und Bewegung (Freigabe, Endlage, Position, Meldung). Vorgabe von Beschleunigung, Geschwindigkeit und Verzögerung. Handbuch: „Nicht alle beschriebenen Funktionen sind bei jedem Aktor vorhanden. Aktoren können nur im Handbetrieb angesteuert werden.“ Mit den Blättertasten wird zwischen den Aktoren der gewählten Gruppe gewechselt (A-39).

## Aufbau (Bereiche, Layout)

Rahmen wie auf allen Seiten (Seitenleiste 3\* : Arbeitsbereich 37\*; Zeilen 4\* : 3\* : 34\* : 4\*). Der Inhaltsbereich (Außenrand `Space.L`, 12 Spalten, Abstand `Size.Touch.Gap`) hat fünf Zeilen:

1. **Objektüberschrift** (Auto): Titelzeile mit dem Aktornamen über alle 12 Spalten.
2. **Bewegung und Status** (Stern, doppelte Gewichtung): Spalten 1–2 Taste Jog−, 3–4 zwei LEDs links (Freigabe, Endlage), 5–8 Positionsfeld, 9–10 zwei LEDs rechts, 11–12 Taste Jog+. Die Jog-Tasten füllen die Zeilenhöhe, mindestens `Size.Touch.Large`.
3. **Positionierung** (Stern, nur bei Servoantrieben im Positioniermodus; sonst vollständig ausgeblendet, die Zeile fällt weg): Spalten 1–2 „Position zurück“, 3–6 LED „Freigabe bei Position-Nr“, 7–10 Anzeige „Position-Nr“, 11–12 „Position vor“.
4. **Vorgabewerte** (Auto): drei Eingabefelder zu je 4 Spalten (Beschleunigung, Geschwindigkeit, Verzögerung), darunter eine Hinweiszeile (`Font.Size.Caption`, `Brush.Text.Secondary`).
5. **Blättern und Meldung** (Auto): Spalten 1–4 Blättertasten (Paar mit Positionsanzeige „n von m“), Spalten 5–12 Meldungsfeld „Meldung:“.
6. **Funktionsleiste:** Taste „Suchen“ links ([HM-06](../Module/HM-06_Funktionsleiste.md)).

```
Inhaltsbereich (12 Spalten)
+--------------------------------------------------------------------+
|            Antrieb Zuführung 2MA1           (HM-17, Sp. 1-12)      |
+---------+-----------+------------------+-----------+---------------+
| [Jog -] | Freigabe  |   Position:      | Freigabe  |   [Jog +]     |
|  Key    | Endlage   |   283,74 °/s     | Endlage   |    Key        |
| Sp. 1-2 | Sp. 3-4   |     Sp. 5-8      | Sp. 9-10  |   Sp. 11-12   |
+---------+-----------+------------------+-----------+---------------+
| [Pos.-] | LED Freigabe bei | Position-Nr:          | [Pos.+]       |  nur Servo,
| Sp. 1-2 | Position-Nr 3-6  | Sp. 7-10              | Sp. 11-12     |  Positioniermodus
+---------------+---------------+---------------+--------------------+
| Beschleunigung| Geschwindigk. | Verzögerung   |   (HM-12, je 4 Sp.)
| 100 %   Key   | 20 %    Key   | 100 %   Key   |
+---------------+---------------+---------------+
  0 bei Beschleunigung/Verzögerung = 100 % bzw. Hardwarevorgabe  (Hinweiszeile)
+-----------+-------------------------------------------------------+
| [<<] [>>] |  Meldung:  Motorschutz ausgelöst                      |
| 1 von 3   |                                                       |
+-----------+-------------------------------------------------------+
Funktionsleiste:  [ Suchen ]
```

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)

Die Spalte „Herkunft (RS-31)“ ist die Rückverfolgung zur Referenzseite (Elementetabelle, T41, Bild).

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-31) |
|---|---|---|---|---|
| E01 Brotkrümel „Einstellung › Handbetrieb › `<Gruppe>`“ | Anzeige / Navigation | Pfad; „Einstellung“ → HS-04, „Handbetrieb“ → HS-30, letztes Segment (Gruppe) nur Anzeige. Ersetzt den Seitentitel „Handbetrieb“ der Referenz-Kopfzeile. Das Segment ändert sich beim Blättern der Aktoren nicht | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | Kopfzeile (Seitentitel); Navigationspfad |
| E02 Kopfzeile: Logo, Betriebsart, Uhrzeit/Datum | Anzeige | Logo, Betriebsart (Wirbel-Symbol → A-48), Uhrzeit „13:05:39“ als Beispiel, Datum | [HM-02](../Module/HM-02_Kopfzeile.md) | Kopfzeile |
| E03 Kennzahlen Geschwindigkeit, Maschinenwinkel | Anzeige | Rahmenelement des Designs | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | – (Rahmen) |
| E04 Meldezeile „450: Palettierung nicht bereit“ | Anzeige | Wichtigste Maschinenmeldung (global); Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | Meldezeile |
| E05 Seitenleiste | Navigation | Benutzerkreis (Schloss), Home („Produktion“), Einstellungen, Meldungen, Zurück (→ HS-30) | [HM-01](../Module/HM-01_Seitenleiste.md) | Schloss; Tasten „Produktion“, „Einstellungen“, „Zurück“ |
| E06 Aktor-Überschrift „Antrieb Zuführung 2MA1“ | Anzeige (Text) | Name des angewählten Aktors (Betriebsmittelkennzeichen und Bezeichnung); wechselt mit den Blättertasten. Fettschrift und Trennlinie statt Unterstreichung | [HM-17](../Module/HM-17_Titelzeile.md) | Aktor-Überschrift |
| E07 Jog− (Aus / Grundstellung / Jog –) | Taste mit Schlüsselsymbol | Steuert den Aktor in die Grundstellung oder Richtung Minus; Bewegung nur solange die Taste gehalten wird. Beschriftung „Jog −“ mit dem Richtungssymbol `Icon.Jog.Minus` (Pfeil nach links bzw. Minus; eigenes Symbol, nicht `Icon.Chevron`, das dem Brotkrümel-Trenner und der Auswahl vorbehalten ist) | [HM-07](../Module/HM-07_Aktionstaste.md) (Auslösung `WhilePressed`, Schlüssel) | Jog-; T41 „Aus / Grundstellung / Jog –“ |
| E08 Jog+ (Ein / Arbeitsstellung / Jog +) | Taste mit Schlüsselsymbol | Steuert den Aktor in die Arbeitsstellung oder Richtung Plus; Verhalten wie E07. Beschriftung „Jog +“ mit `Icon.Jog.Plus` (Pfeil nach rechts bzw. Plus) | [HM-07](../Module/HM-07_Aktionstaste.md) (Auslösung `WhilePressed`, Schlüssel) | Jog+; T41 „Ein / Arbeitsstellung / Jog +“ |
| E09 Freigabe (links) | Status-LED | Freigabe für eine Bewegung in Richtung Minus; Symbol und Wort („Erteilt“ / „Gesperrt“) | [HM-09](../Module/HM-09_Status-LED.md) | Freigabe (links); T41 „Freigabe“ |
| E10 Endlage (links) | Status-LED | Zeigt, ob die Endlage in Richtung Minus erreicht wurde („Erreicht“ / „Nicht erreicht“) | [HM-09](../Module/HM-09_Status-LED.md) | Endlage (links); T41 „Endlage“ |
| E11 Freigabe (rechts) | Status-LED | Freigabe für eine Bewegung in Richtung Plus | [HM-09](../Module/HM-09_Status-LED.md) | Freigabe (rechts); T41 „Freigabe“ |
| E12 Endlage (rechts) | Status-LED | Endlage in Richtung Plus erreicht | [HM-09](../Module/HM-09_Status-LED.md) | Endlage (rechts); T41 „Endlage“ |
| E13 Position | Anzeigefeld numerisch mit Titel | Zeigt die aktuelle Position des Aktors, Beispiel „283,74 °/s“ (Einheit aus dem Bild, Handbuch nennt keine, OP-29), zwei Nachkommastellen | [HM-11](../Module/HM-11_Anzeigefeld.md) (Feld, Zahl) | Position; T41 „Position“ |
| E14 Position zurück | Taste | Fährt eine Position zurück; nur Servoantriebe im Positioniermodus, sonst ausgeblendet | [HM-07](../Module/HM-07_Aktionstaste.md) | T41 „Position zurück“ (im Bild nicht sichtbar) |
| E15 Position vor | Taste | Fährt eine Position vor; Bedingungen wie E14 | [HM-07](../Module/HM-07_Aktionstaste.md) | T41 „Position vor“ (im Bild nicht sichtbar) |
| E16 Freigabe bei Position-Nr | Status-LED | Freigabe für das Anfahren einer bestimmten Positionsnummer; nur im Positioniermodus | [HM-09](../Module/HM-09_Status-LED.md) | T41 „Freigabe bei Position-Nr“ (im Bild nicht sichtbar) |
| E17 Position-Nr | Anzeigefeld numerisch | Zeigt die aktuelle Positionsnummer; nur im Positioniermodus | [HM-11](../Module/HM-11_Anzeigefeld.md) (Feld, Zahl) | T41 „Position-Nr“ (im Bild nicht sichtbar) |
| E18 Beschleunigung | Eingabefeld mit Schlüsselsymbol | Vorgabewert Beschleunigung in %; 0 entspricht 100 % oder Hardwarevorgabe; Wert in `Font.Weight.Strong`, nicht rot | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) | Beschleunigung (Bild 100 %); T41 „Beschleunigung / Verzögerung“ |
| E19 Geschwindigkeit | Eingabefeld mit Schlüsselsymbol | Sollgeschwindigkeit des Aktors in % | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) | Geschwindigkeit (Bild 20 %); T41 „Geschwindigkeit“ |
| E20 Verzögerung | Eingabefeld mit Schlüsselsymbol | Vorgabewert Verzögerung in %; Regel wie E18 | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) | Verzögerung (Bild 100 %); T41 „Beschleunigung / Verzögerung“ |
| E21 Hinweiszeile „0 = 100 % bzw. Hardwarevorgabe“ | Text (Caption) | Erklärt den Wert 0 bei Beschleunigung und Verzögerung (T41); kein Modul, Text aus `.resx` | – | T41 „Beschleunigung / Verzögerung“ (Satz „Der Wert 0 entspricht …“) |
| E22 Tasten „<<“ und „>>“ | Blättertasten | Wechseln zum vorherigen/nächsten Aktor der Gruppe (vermutet, A-39); Paar mit Positionsanzeige „n von m“; am Rand deaktiviert | [HM-19](../Module/HM-19_Blaettertasten.md) | Tasten „<<“ / „>>“ |
| E23 „Meldung:“ mit Text | Statusanzeige | Aktorbezogene Meldung, Beispiel „Motorschutz ausgelöst“ (Normaltext: Art `MessageLine`; Störungstext: Art `Error` mit Caption „Meldung:“, `Icon.Status.Error` und Wort „Fehler“; je Zeitpunkt genau eine Art); leer: „–“. Getrennt von der globalen Meldezeile E04 | [HM-27](../Module/HM-27_Hinweis-Textfeld.md) (Art `MessageLine`; bei Störungstext Art `Error` mit Caption „Meldung:“) | „Meldung:“ mit Text |
| E24 Funktionsleiste unten | Container | Nimmt „Suchen“ links auf | [HM-06](../Module/HM-06_Funktionsleiste.md) | Untere Funktionsleiste |
| E25 Taste „Suchen“ | Taste (Antippen) | Öffnet das Such-Pop-up ([HM-38](../Module/HM-38_Such-Pop-up.md), Titel „Aktor suchen“); Treffer wechselt auf den gefundenen Aktor | [HM-07](../Module/HM-07_Aktionstaste.md) | Taste „Suchen“ |
| E26 Eingabe-Pop-up | Pop-up (modal) | Wertevorgabe zu E18 bis E20 mit Grenzen und „Übernehmen“/„Abbrechen“ | [HM-13](../Module/HM-13_Eingabe-Pop-up.md) in [HM-14](../Module/HM-14_Popup-Rahmen.md) | Eingabe in Zahlenfelder (Eingabeweise im Handbuch nicht beschrieben) |

## Verwendete Module (IDs)

- Rahmen: [HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md)
- Seite: [HM-07](../Module/HM-07_Aktionstaste.md) Aktionstaste, [HM-09](../Module/HM-09_Status-LED.md) Status-LED, [HM-11](../Module/HM-11_Anzeigefeld.md) Anzeigefeld, [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) Eingabefeld mit Schlüsselsymbol, [HM-17](../Module/HM-17_Titelzeile.md) Titelzeile, [HM-19](../Module/HM-19_Blaettertasten.md) Blättertasten, [HM-27](../Module/HM-27_Hinweis-Textfeld.md) Hinweis-Textfeld
- Pop-ups: [HM-13](../Module/HM-13_Eingabe-Pop-up.md) Eingabe-Pop-up, [HM-38](../Module/HM-38_Such-Pop-up.md) Such-Pop-up, [HM-14](../Module/HM-14_Popup-Rahmen.md) Pop-up-Rahmen

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

- **Funktionen je Aktor:** Nicht vorhandene Funktionen werden nicht angeboten, sondern ausgeblendet (RS-31-P10). Die Positionszeile (E14 bis E17) erscheint nur bei Servoantrieben im Positioniermodus; bei anderen Aktorarten fehlt die Zeile und der Raum wird an die übrigen Zeilen verteilt. Die Beschriftung der Richtungstasten folgt der Aktorart: Antriebe „Jog −“ / „Jog +“, schaltende Aktoren „Aus / Grundstellung“ / „Ein / Arbeitsstellung“ (Annahme; die Referenz nennt beide Schreibweisen, OP-34).
- **Ansteuerung nur im Handbetrieb:** Die Bewegungstasten E07, E08, E14, E15 sind nur bedienbar, wenn die Betriebsart „Handbetrieb“ ist (HM-02, `OperatingMode.Manual`; Annahme, die Referenz nennt nur „Aktoren können nur im Handbetrieb angesteuert werden“, die Betriebsart-Zuordnung ist nicht belegt). Sonst sind sie deaktiviert (gestrichelte Kontur, Text deaktiviert); Tippen nennt den Grund „Nur im Handbetrieb ansteuerbar“ in der Meldezeile (A-28). Anzeigen (E09 bis E13, E16, E17, E23) bleiben aktiv. Die Vorgabefelder E18 bis E20 bleiben bearbeitbar (Annahme; die Referenz beschränkt nur das Ansteuern, nicht das Vorgeben).
- **Jog (Annahme, Referenz beschreibt Halten oder Tippen nicht):** Die Bewegung läuft nur, solange die Taste gedrückt wird (Auslösemodus `WhilePressed` von HM-07: Auslösung bei Berührung, Ende beim Loslassen, kein Dauerlauf). Sie endet beim Loslassen, beim Gleiten des Fingers aus der Taste, beim Wegblättern, beim Seitenwechsel, bei Rollenverlust und bei einer Störung. Während Jog gehalten wird, sind Blättertasten und Funktionsleiste gesperrt. Während der Bewegung zeigt die Taste Zustand „Läuft“ mit Symbol und Wort, nicht nur Farbe. Gleichzeitiges Drücken von Jog− und Jog+ führt keine Bewegung aus.
- **Position zurück / vor:** Antippen löst einen Positionsschritt aus; Freigabe bei Position-Nr (E16) muss erteilt sein, sonst ist die Taste deaktiviert.
- **Berechtigung:** Schlüsselsymbol an E07, E08, E18, E19, E20 (Berechtigung vorhanden, `Icon.Key`); fehlt die Rolle, steht `Icon.Lock` und Tippen öffnet das Benutzer-Pop-up (Navigation.md 4.1) mit dem Hinweis „Berechtigung erforderlich: <Rolle>“ in der Meldezeile. Die Stufe nennt die Quelle nicht (OP-25, OP-04): Dummy-Rolle.
- **Eingabe:** Antippen von E18 bis E20 öffnet das Eingabe-Pop-up mit vorbelegtem Wert; Grenzen als Caption („Bereich 0 bis 100 %; 0 entspricht 100 % bzw. Hardwarevorgabe“), Dummy-Grenzen (OP-28). „Übernehmen“ nur bei gültigem Wert, der Wert gilt sofort (Annahme). Ungültig: Fehlerkontur, `Icon.Status.Error` und Text „Wert außerhalb 0 bis 100 %“. Wert 0 wird als 0 % angezeigt, die Hinweiszeile E21 steht dauerhaft darunter.
- **Blättern:** « und » ersetzen nur den Parameter `actorId` (kein Verlaufseintrag, A-42); die Titelzeile E06 und alle Werte wechseln. Die Tasten sind am Rand der Gruppe deaktiviert (gestrichelt, nicht umlaufend); die Positionsanzeige „n von m“ nennt die Stellung.
- **Suche:** E25 öffnet das Such-Pop-up ([HM-38](../Module/HM-38_Such-Pop-up.md), Titel „Aktor suchen“). Seitenspezifisch: Ein Treffer ersetzt `groupId`/`actorId` der aktuellen Seite (kein Verlaufseintrag, Brotkrümel-Gruppe wird aktualisiert).
- **Meldungen:** E23 zeigt die Aktormeldung (Störungstext: HM-27 Art `Error` mit Caption „Meldung:“, `Icon.Status.Error` und Wort „Fehler“; Normaltext: Art `MessageLine`), z. B. „Motorschutz ausgelöst“; ohne Meldung „–“. Die globale Meldung steht in E04, Antippen öffnet HS-38 (bei offenem Pop-up erst nach dem Schließen).
- **Fehlerfälle:** Ist der Aktor nicht erreichbar, zeigen LEDs „Unbekannt“ (Text „---“), das Positionsfeld „---“, die Bewegungstasten sind deaktiviert. LED-Zustände der Referenz (alle vier aus) entsprechen „Gesperrt“ und „Nicht erreicht“ mit Symbol und Wort (`Icon.Status.Inactive`).
- **Zurück:** Seitenleiste „Zurück“ → HS-30 (Verlauf). Brotkrümel-Segmente springen nach HS-30 bzw. HS-04. Bei offenem Pop-up ist „Zurück“ gesperrt.

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-31-P01 | Seitentitel (RS-31-P01) | Letztes Segment des Brotkrümels nennt die Gruppe; das vorletzte Segment lautet „Handbetrieb“ und führt auf HS-30 | offen |
| HS-31-P02 | Aktor-Überschrift (RS-31-P02) | Name des Aktors, im Beispiel „Antrieb Zuführung 2MA1“ (Titelzeile, keine Unterstreichung) | offen |
| HS-31-P03 | Jog− und Jog+ (RS-31-P03) | Je eine große Taste links/rechts mit Schlüsselsymbol; Jog− = Grundstellung/Richtung Minus, Jog+ = Arbeitsstellung/Richtung Plus | offen |
| HS-31-P04 | LEDs Freigabe und Endlage (RS-31-P04) | Je Richtung eine LED „Freigabe“ und „Endlage“ links und rechts des Positionsfelds, mit Symbol und Wort | offen |
| HS-31-P05 | Positionsfeld (RS-31-P05) | Feld „Position:“ zeigt die aktuelle Position, Beispiel „283,74 °/s“ | offen |
| HS-31-P06 | Felder Beschleunigung, Geschwindigkeit, Verzögerung (RS-31-P06) | Drei Felder mit Schlüsselsymbol, Beispielwerte 100 %, 20 %, 100 %; Wert nicht rot | offen |
| HS-31-P07 | Wert 0 (RS-31-P07) | Bei Beschleunigung/Verzögerung entspricht 0 dem Wert 100 % oder der Hardwarevorgabe; Hinweiszeile und Pop-up-Grenzen nennen es | offen |
| HS-31-P08 | Position zurück / vor (RS-31-P08) | Nur bei Servoantrieben im Positioniermodus vorhanden, sonst ausgeblendet | offen |
| HS-31-P09 | Position-Nr (RS-31-P09) | „Freigabe bei Position-Nr“ als LED und „Position-Nr“ als Anzeige im Positioniermodus | offen |
| HS-31-P10 | Funktionen je Aktor (RS-31-P10) | Nicht vorhandene Funktionen werden nicht angeboten; die Zeilen verteilen sich ohne Lücke | offen |
| HS-31-P11 | Tasten „<<“ und „>>“ (RS-31-P11) | Blättertasten mit „n von m“ unten links; wechseln den Aktor der Gruppe; am Rand deaktiviert; kein Verlaufseintrag | offen |
| HS-31-P12 | Meldung (RS-31-P12) | „Meldung:“ mit Text, Beispiel „Motorschutz ausgelöst“, mit Symbol und Wort „Fehler“ | offen |
| HS-31-P13 | Ansteuerung nur im Handbetrieb (RS-31-P13) | Außerhalb der Betriebsart Handbetrieb sind Jog und Positionstasten deaktiviert mit Begründung in der Meldezeile | offen |
| HS-31-P14 | Untere Funktionsleiste und Rahmentasten (RS-31-P14) | „Suchen“ links in der Funktionsleiste; Schloss (Benutzerkreis), Produktion, Einstellungen, Zurück in der Seitenleiste | offen |
| HS-31-P15 | Navigation (RS-31-P15) | Brotkrümel „Einstellung › Handbetrieb › `<Gruppe>`“; Zugang aus HS-30 oder Such-Pop-up; Zurück führt nach HS-30 | offen |
| HS-31-P16 | Jog-Sicherheit | Bewegung nur bei gehaltener Taste; sie endet beim Loslassen, Seitenwechsel und bei Störung; Blättern während Jog gesperrt | offen |
| HS-31-P17 | Berechtigung | Schlüsselsymbol an Jog−, Jog+ und den drei Feldern; ohne Rolle öffnet das Benutzer-Pop-up und der Wert bleibt unverändert | offen |
| HS-31-P18 | Eingabe-Pop-up | Ungültiger Wert: Fehlerkontur, Symbol und Fehlertext, „Übernehmen“ deaktiviert; Wert wird erst nach „Übernehmen“ geschrieben | offen |
| HS-31-P19 | Touch-Ziele (Designsystem) | Jog-Tasten mindestens `Size.Touch.Large` hoch; alle übrigen Tasten und Felder mindestens `Size.Touch.Default`; Abstand mindestens `Size.Touch.Gap`; Blättertasten mindestens `Size.Touch.Default` × `Size.Touch.Default` | offen |
| HS-31-P20 | Zweiter Kanal (Designsystem) | LED-Zustände, „Läuft“, deaktiviert, Fehler und Berechtigung sind zusätzlich durch Symbol, Wort oder Konturform erkennbar, nicht nur durch Farbe | offen |
| HS-31-P21 | Tokens (Designsystem) | Keine Hex-, Pixel- oder Literalwerte; die rote Wertschrift der Referenz entfällt; Texte aus `.resx` | offen |
| HS-31-P22 | Rückverfolgung | Jede Zeile der Tabelle T41 und jedes Element des Bildes RS-31_01 ist in E01 bis E26 wiederzufinden | offen |

## Offene Punkte

- OP-25 / OP-04 (Berechtigungsstufen, Bedeutung des Schlüssels): Dummy-Rollen; Stufe je Taste/Feld offen.
- OP-27 (Farbbedeutung): rote Eingabewerte und graue LEDs der Referenz werden als Status mit Symbol und Wort neu dargestellt, ohne Handbuchbeleg.
- OP-28 (Wertebereiche): Grenzen 0 bis 100 % sind Dummy.
- OP-29 (Einheiten): die Einheit „°/s“ am Positionsfeld stammt aus dem Bild; das Handbuch nennt „aktuelle Position“ ohne Einheit.
- OP-34 (Beschriftungsabweichungen): „Jog-“ im Bild gegen „Aus / Grundstellung / Jog –“ im Handbuch.
- OP-37 (Zugang Handbetrieb): Wechsel von HS-30 abgeleitet (A-14, A-39).
- OP-39 (fehlende Zustände): Positioniermodus (Position zurück/vor, Position-Nr) im Bild nicht sichtbar; Aufbau nach Handbuchtext, Zustände nach Designsystem.
- OP-40 (Suche): Such-Pop-up als Annahme (HM-38, A-59).
- OP-57 Halte-/Tippverhalten von Jog (`WhilePressed`); Annahmen (A-69): Zuordnung „Handbetrieb“ = `OperatingMode.Manual` und Grenze des Blätterns (nur innerhalb der Gruppe).
