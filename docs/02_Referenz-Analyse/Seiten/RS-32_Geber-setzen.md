# RS-32 – Geber setzen

- Quelle: `src_Data/Referenz/Referenz.docx`, Kapitel „Geber setzen“ (Zweck, Seitenübersicht, Funktionsbeschreibung, Tabelle T42, Hinweis-Textfeld); Bild [RS-32_01.png](../Medien/RS-32_01.png); Eintrag „Geber setzen“ in RS-04 („Systemseite für das Null-Setzen von Gebern.“)
- Navigationspfad: Einstellung › Geber setzen (Herkunft: Handbuch). Navigationstasten „<<“ / „>>“ wechseln zwischen Gebern.

## Zweck

Wortgetreu: „Diese Seite dient zum Setzen des Nullpunkts eines Gebers, beispielsweise nach dem Austausch eines Drehgebers oder Servomotors. Der korrekte Nullpunkt ist entscheidend für die präzise Positionierung im Betrieb.“

## Aufbau (Bereiche, Layout)

Bild [RS-32_01.png](../Medien/RS-32_01.png) (blauer Hintergrund):

- **Kopfzeile:** Logo, Titel „Geber setzen“ (fett, unterstrichen), Wirbel-Symbol, Uhrzeit „13:05:44“, Datum „12.05.2025“.
- **Achs-Überschrift:** „Antrieb Zuführung 2MA1“ (fett, unterstrichen, zentriert).
- **Linke Spalte (Beschriftung, Wert):** „Motor Position:“ Feld „-2596,261“; „Geber Position:“ Feld „0,000“; „Positions Offset:“ Feld „-2596,261“ (weiße Felder, kleine Schrift); „Achse initialisiert:“ mit grüner runder LED (an).
- **Rechts:** große Taste „Geber setzen“ mit gelbem Schlüsselsymbol oben rechts.
- **Textzeile unter der LED:** „Messer beginnt Schneidbewegung.“ (zentriert, ohne Beschriftung).
- **Unten:** links Taste „<<“, Mitte Beschriftung „Meldung:“ (Textwert im Bild leer), rechts Taste „>>“.
- **Meldezeile:** roter Balken „*450* Palettierung nicht bereit“.
- **Untere Funktionsleiste:** keine Taste „Suchen“; gelbes Schloss, „Produktion“ (Haus), „Einstellungen“ (Zahnrad), „Zurück“ (Rücktaste).
- Hinweis-Textfeld des Handbuchs (siehe unten) ist im Bild nicht zu sehen.

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)

| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Achs-Überschrift „Antrieb Zuführung 2MA1“ | Anzeige (Text) | Name des Gebers/Antriebs (Bildbeispiel) | [RM-25](../Module/RM-25_Objekt-Ueberschrift.md) |
| Motor Position | Anzeigefeld numerisch | „Aktuelle Position des Motors.“ Bild: „-2596,261“; Einheit nicht angegeben | [RM-07](../Module/RM-07_Anzeigefeld.md) mit Beschriftung |
| Geber Position | Anzeigefeld numerisch | „Derzeitige Position des Gebers.“ Bild: „0,000“ | [RM-07](../Module/RM-07_Anzeigefeld.md) mit Beschriftung |
| Positions Offset | Anzeigefeld numerisch | „Differenz zwischen Motor- und Geberposition. Wird automatisch berechnet.“ Bild: „-2596,261“ | [RM-07](../Module/RM-07_Anzeigefeld.md) mit Beschriftung |
| Achse initialisiert | Status-LED | „Zeigt an, ob die Initialisierung der Achse erfolgreich durchgeführt wurde (grüne Anzeige = OK).“ Bild: grün | [RM-08](../Module/RM-08_Status-LED.md) |
| Geber setzen | Taste mit Schlüsselsymbol | „Schaltfläche zum Speichern der aktuellen Motorposition als neuen Nullpunkt.“ Laut Textfeld: langes Drücken | [RM-11](../Module/RM-11_Aktionstaste.md) |
| Meldung | Statusanzeige | „Statusanzeige für Systemhinweise oder Fehler.“ | [RM-23](../Module/RM-23_Hinweis-Textfeld.md) |
| Navigationstasten „<<“ / „>>“ | Tasten | „Ermöglicht das Wechseln zwischen den Gebern.“ | [RM-04](../Module/RM-04_Blaettertasten.md) |
| Text „Messer beginnt Schneidbewegung.“ | Anzeige (Text) | Im Handbuch nicht beschrieben | – |
| Hinweis-Textfeld (Not-Aus) | Hinweis-Textfeld mit Warnzeichen | siehe unten | [RM-23](../Module/RM-23_Hinweis-Textfeld.md) (Warnung) |
| Kopfzeile, Meldezeile, Untere Funktionsleiste | Rahmen | wie RS-30 | [RM-01](../Module/RM-01_Kopfzeile.md); [RM-02](../Module/RM-02_Meldezeile.md); [RM-03](../Module/RM-03_Funktionsleiste-unten.md) |

### Tabelle T42 (Funktionsbeschreibung), 8 Zeilen (1 Kopfzeile + 7 Datenzeilen), vollständig

| Funktion | Beschreibung |
|---|---|
| Motor Position | Aktuelle Position des Motors. |
| Geber Position | Derzeitige Position des Gebers. |
| Positions Offset | Differenz zwischen Motor- und Geberposition. Wird automatisch berechnet. |
| Achse initialisiert | Zeigt an, ob die Initialisierung der Achse erfolgreich durchgeführt wurde (grüne Anzeige = OK). |
| Geber setzen | Schaltfläche zum Speichern der aktuellen Motorposition als neuen Nullpunkt. |
| Meldung | Statusanzeige für Systemhinweise oder Fehler. |
| Navigationstasten (<< / >>) | Ermöglicht das Wechseln zwischen den Gebern. |

### Hinweis-Textfeld (Warnzeichen ⚠, in der Funktionsbeschreibung eingebettet), wortgetreu

„Zum Setzen eines Gebers muss mindestens ein Not-Aus-Taster gedrückt sein. Anschließend ist die Achse manuell in die Referenzposition bringen. Mit langem Drücken der Taste „Geber setzen“ wird der aktuelle Wert des Motors als neue Geberposition übernommen.“ (Satz „…in die Referenzposition bringen“ so im Original.)

Das Textfeld ist im Dokument doppelt abgelegt (Hauptansicht und Fallback); laut XML sind beide Ablagen vollständig textgleich. Im Original steht „sein.Anschließend“ ohne Leerzeichen nach dem Punkt.

### Bilder

| Bild | Beschreibung |
|---|---|
| [RS-32_01.png](../Medien/RS-32_01.png) (Original `image54.png`, Fließtext, Seitenübersicht) | Seite „Geber setzen“ für „Antrieb Zuführung 2MA1“: Felder Motor Position -2596,261, Geber Position 0,000, Positions Offset -2596,261; grüne LED „Achse initialisiert“; große Taste „Geber setzen“ mit Schlüssel; Text „Messer beginnt Schneidbewegung.“; „Meldung:“ leer; Tasten „<<“ „>>“; rote Meldezeile; untere Leiste ohne „Suchen“. |
| Hinweis-Textfeld (kein Bild, keine Datei) | Warnhinweis zum Not-Aus-Taster, siehe oben. |

## Verwendete Module (IDs)

Module dieser Seite (Definitionen in der [Modulliste](../Module/Modulliste.md)):

- [RM-01](../Module/RM-01_Kopfzeile.md) – Kopfzeile
- [RM-02](../Module/RM-02_Meldezeile.md) – Meldezeile
- [RM-03](../Module/RM-03_Funktionsleiste-unten.md) – Funktionsleiste unten
- [RM-04](../Module/RM-04_Blaettertasten.md) – Blättertasten
- [RM-07](../Module/RM-07_Anzeigefeld.md) – Anzeigefeld
- [RM-08](../Module/RM-08_Status-LED.md) – Status-LED
- [RM-11](../Module/RM-11_Aktionstaste.md) – Aktionstaste
- [RM-23](../Module/RM-23_Hinweis-Textfeld.md) – Hinweis-Textfeld
- [RM-25](../Module/RM-25_Objekt-Ueberschrift.md) – Objekt-Überschrift

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

- Voraussetzung: mindestens ein Not-Aus-Taster gedrückt. Danach Achse manuell in die Referenzposition bringen. Dann Taste „Geber setzen“ lang drücken: aktueller Motorwert wird als neue Geberposition übernommen (Nullpunkt).
- „Positions Offset“ wird automatisch berechnet (Motor minus Geber, im Bild -2596,261 = -2596,261 − 0,000).
- „Achse initialisiert“: grün = OK; Zustand „nicht OK“ im Handbuch nicht beschrieben.
- „Meldung“: Systemhinweise oder Fehler; Texte im Handbuch nicht aufgelistet.
- Berechtigung: Schlüsselsymbol an der Taste „Geber setzen“; Stufe nicht angegeben.
- Wertebereiche, Einheiten, Standardwerte: keine angegeben. Zahlenformat im Bild: Dezimalkomma, drei Nachkommastellen.
- Pop-ups: keine beschrieben. Bei Bedienung ohne gedrückten Not-Aus: Verhalten nicht beschrieben.

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RS-32-P01 | Seitentitel in der Kopfzeile | „Geber setzen“ | offen |
| RS-32-P02 | Achs-Überschrift | Name des Antriebs, Beispiel „Antrieb Zuführung 2MA1“ | offen |
| RS-32-P03 | Felder Motor Position, Geber Position, Positions Offset | Drei Anzeigefelder, Beispielwerte -2596,261 / 0,000 / -2596,261 (Dezimalkomma, drei Nachkommastellen) | offen |
| RS-32-P04 | Positions Offset | Differenz zwischen Motor- und Geberposition, automatisch berechnet | offen |
| RS-32-P05 | LED „Achse initialisiert“ | Grün = Initialisierung der Achse erfolgreich | offen |
| RS-32-P06 | Taste „Geber setzen“ | Große Taste mit Schlüsselsymbol; speichert die aktuelle Motorposition als neuen Nullpunkt | offen |
| RS-32-P07 | Bedienung der Taste | Langes Drücken übernimmt den Motorwert als neue Geberposition | offen |
| RS-32-P08 | Hinweis Not-Aus | Hinweistext: mindestens ein Not-Aus-Taster muss gedrückt sein; danach Achse manuell in Referenzposition bringen | offen |
| RS-32-P09 | Zeile „Meldung:“ | Statusanzeige für Systemhinweise oder Fehler | offen |
| RS-32-P10 | Tasten „<<“ und „>>“ | Wechseln zwischen den Gebern | offen |
| RS-32-P11 | Untere Funktionsleiste | Keine Taste „Suchen“; Schloss, „Produktion“, „Einstellungen“, „Zurück“ vorhanden | offen |
| RS-32-P12 | Navigation | Einstellung › Geber setzen; Zugang über Eintrag in RS-04 | offen |

## Offene Punkte

1. Im Bild steht „Messer beginnt Schneidbewegung.“ ohne Handbuchbeschreibung und ohne erkennbaren Bezug zur Seite (Platzhalter/Rest?).
2. Einheiten und Wertebereiche der Positionsfelder fehlen.
3. Textfeld enthält Satzfehler („ist die Achse … bringen“); Hinweis fehlt im Bild.
4. Dauer des „langen Drückens“ und Rückmeldung nach dem Setzen nicht angegeben.
5. Zustand „Achse nicht initialisiert“ (Farbe/Symbol) nicht beschrieben.
6. Reihenfolge und Liste der Geber bei „<<“ / „>>“ nicht angegeben.
7. Berechtigungsstufe (Schlüssel) nicht angegeben.
