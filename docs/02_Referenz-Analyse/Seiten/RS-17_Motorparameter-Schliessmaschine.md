# RS-17 – Motorparameter (Schließmaschine)
- Quelle: `src_Data/Referenz/Referenz.docx`, Kapitel „Motorparameter“ nach „Schließmaschine“ (Ebene 2, Nr. 17); Bild [RS-17_01](../Medien/RS-17_01.png) (Originaldatei `image29.png`, identisch mit [RS-12_01](../Medien/RS-12_01.png) und [RS-20_01](../Medien/RS-20_01.png)); Tabellen T25, T26
- Navigationspfad: Einstellung › Schließmaschine › Motorparameter (Elternseite unklar, Annahme A-11; Handbuchposition nach [RS-16](RS-16_Schliessmaschine.md))

## Zweck
Wortgetreu: „Auf dieser Seite werden die Bewegungsparameter für den Verschluss und die Schnecke eines Schneckendosierers konfiguriert. Die Einstellungen ermöglichen eine optimale Anpassung an das Produktverhalten und die Maschinengeschwindigkeit.“ Der Text ist identisch mit dem Kapitel Motorparameter der Hauptdosierer ([RS-12](RS-12_Motorparameter.md)) und Nachdosierer ([RS-20](RS-20_Motorparameter.md)).

## Aufbau (Bereiche, Layout)
Das Seitenbild [RS-17_01](../Medien/RS-17_01.png) (blauer Hintergrund, graue Gruppenfelder) zeigt:

- **Kopfzeile:** Logo „APA-TEC GmbH AUTOMATION AND PACKAGING TECHNOLOGY“; Titel „Motorparameter HD1“ (fett, unterstrichen; das Bild stammt von der Hauptdosierer-Seite, nicht von einer Schließmaschinen-Variante); rundes Wirbelsymbol; Uhrzeit „13:02:24“, Datum „12.05.2025“.
- **Oben links:** Gruppenfeld „Verschluss Zu“ mit fünf Zeilen (Beschriftung rechtsbündig, weißes Zahlenfeld mit rotem Wert und Schlüsselsymbol): „Position:“ „0 °“, „Geschwindigkeit:“ „80 %“, „Beschleunigung:“ „0 %“, „Verzögerung:“ „0 %“, „Ruck:“ „0 %“.
- **Oben rechts:** Gruppenfeld „Verschluss Auf“ mit denselben fünf Zeilen: „Position:“ „37 °“, „Geschwindigkeit:“ „80 %“, „Beschleunigung:“ „0 %“, „Verzögerung:“ „0 %“, „Ruck:“ „0 %“.
- **Mitte unten:** Gruppenfeld „Schnecke“ mit Piktogramm einer Förderschnecke (schwarz, links) und drei Zeilen: „Beschleunigung:“ „0 %“, „Verzögerung:“ „0 %“, „Ruck:“ „0 %“.
- **Meldezeile** (rot): „\*450\* Palettierung nicht bereit“.
- **Untere Funktionsleiste:** links ein ausgegrauter Pfeil-Button mit „»“ (deaktiviert wirkend), Schloss-Symbol (gelb, geschlossen), Tasten „Produktion“ (Haus), „Einstellungen“ (Zahnrad), „Zurück“.

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Wertebereiche und Standardwerte sind im Handbuch nicht angegeben; die Bildwerte sind Beispielwerte.

### T25 – Verschluss Zu / Verschluss Auf (6 Zeilen inkl. Kopfzeile; Gruppe erscheint zweimal)
| Element (Funktion) | Typ | Funktion (Beschreibung wortgetreu) | verwendetes Modul |
|---|---|---|---|
| Position | Zahlenfeld mit Schlüsselsymbol, Einheit ° (Bild: Zu 0 °, Auf 37 °) | Position in Grad, an der der Verschluss geöffnet bzw. geschlossen ist. | Modulkandidat: Motorparameter (Verschluss); Eingabefeld mit Schlüsselsymbol (Pop-up-Eingabe) |
| Geschwindigkeit | Zahlenfeld mit Schlüsselsymbol, Einheit % (Bild: 80 % / 80 %) | Bewegungsgeschwindigkeit des Aktors in Prozent. | wie Position |
| Beschleunigung | Zahlenfeld mit Schlüsselsymbol, Einheit % (Bild: 0 % / 0 %) | Anstieg der Geschwindigkeit beim Start der Bewegung. | wie Position |
| Verzögerung | Zahlenfeld mit Schlüsselsymbol, Einheit % (Bild: 0 % / 0 %) | Abbremsen vor Erreichen der Endposition. | wie Position |
| Ruck | Zahlenfeld mit Schlüsselsymbol, Einheit % (Bild: 0 % / 0 %) | Änderung der Beschleunigung (sanfter Bewegungsbeginn und -ende). | wie Position |

### T26 – Schnecke (4 Zeilen inkl. Kopfzeile)
| Element (Funktion) | Typ | Funktion (Beschreibung wortgetreu) | verwendetes Modul |
|---|---|---|---|
| Beschleunigung | Zahlenfeld mit Schlüsselsymbol, Einheit % (Bild: 0 %) | Anstieg der Drehgeschwindigkeit beim Start. | Modulkandidat: Motorparameter (Schnecke); Eingabefeld mit Schlüsselsymbol (Pop-up-Eingabe) |
| Verzögerung | Zahlenfeld mit Schlüsselsymbol, Einheit % (Bild: 0 %) | Abbremsen der Drehung beim Stoppen. | wie Beschleunigung |
| Ruck | Zahlenfeld mit Schlüsselsymbol, Einheit % (Bild: 0 %) | Änderung der Beschleunigung für eine produktschonende Bewegung. | wie Beschleunigung |

### Rahmenelemente laut Bild
| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Kopfzeile (Logo, Titel, Wirbelsymbol, Uhrzeit/Datum) | Anzeige | im Handbuch nicht beschrieben | Modulkandidat: Statuskopf (Kopfzeile) |
| Meldezeile „\*450\* Palettierung nicht bereit“ | Anzeige (rot) | im Handbuch nicht beschrieben | Modulkandidat: Meldezeile |
| Taste „»“ (links unten, grau) | Taste | im Handbuch nicht beschrieben (vermutlich Umschaltung/Weiter, nicht belegt) | Modulkandidat: Navigationsleiste unten |
| Schloss-Symbol | Symbol | im Handbuch nicht beschrieben | Modulkandidat: Navigationsleiste unten (Schloss/Berechtigung) |
| Tasten „Produktion“, „Einstellungen“, „Zurück“ | Tasten | im Handbuch nicht beschrieben | Modulkandidat: Navigationsleiste unten |

Erfasst: 2 Handbuchtabellen mit zusammen 8 Datenzeilen (5 + 3; ohne Kopfzeilen) bzw. 10 Tabellenzeilen inkl. Kopfzeilen; Bildwerte: 13 Zahlenfelder (2 × 5 + 3); 1 Bild.

## Verwendete Module (IDs)
Noch keine RM-IDs. Modulkandidaten: Motorparameter (Verschluss Zu/Auf und Schnecke; wiederkehrend auf RS-12, RS-17, RS-20); Eingabefeld mit Schlüsselsymbol (Pop-up-Eingabe); Statuskopf; Meldezeile; Navigationsleiste unten.

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- Alle Zahlenfelder tragen ein gelbes Schlüsselsymbol (berechtigungsgeschützte Eingabe, nicht erklärt). Ein Eingabe-Pop-up ist im Handbuch nicht beschrieben.
- Wertebereiche, Standardwerte, Fehlermeldungen: im Handbuch nicht angegeben.
- Navigation: Brotkrümel Einstellung › Schließmaschine › Motorparameter (abgeleitet, Elternseite unklar). Rücksprung über „Zurück“; „Produktion“ und „Einstellungen“ in der unteren Leiste.
- Pop-ups/Unterseiten: keine beschrieben. Die Taste „»“ links unten ist im Handbuch nicht erläutert.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RS-17-P01 | Seitentitel und Pfad | Seite „Motorparameter“ (Bild: „Motorparameter HD1“), Pfad Einstellung › Schließmaschine › Motorparameter (Elternseite offen) | offen |
| RS-17-P02 | Gruppen | „Verschluss Zu“, „Verschluss Auf“ und „Schnecke“ vorhanden | offen |
| RS-17-P03 | Verschluss Zu/Auf: Felder | Je Gruppe fünf Felder: Position, Geschwindigkeit, Beschleunigung, Verzögerung, Ruck | offen |
| RS-17-P04 | Position | Einheit Grad (°), Position, an der der Verschluss geöffnet bzw. geschlossen ist | offen |
| RS-17-P05 | Geschwindigkeit | Einheit %, Bewegungsgeschwindigkeit des Aktors | offen |
| RS-17-P06 | Beschleunigung/Verzögerung/Ruck (Verschluss) | Einheit %; Beschreibungen gemäß T25 (Anstieg beim Start; Abbremsen vor Endposition; Änderung der Beschleunigung) | offen |
| RS-17-P07 | Schnecke: Felder | Drei Felder Beschleunigung, Verzögerung, Ruck, Einheit % | offen |
| RS-17-P08 | Schnecke: Beschreibungen | Anstieg der Drehgeschwindigkeit beim Start; Abbremsen der Drehung beim Stoppen; Änderung der Beschleunigung für eine produktschonende Bewegung | offen |
| RS-17-P09 | Schlüsselsymbole | Alle 13 Zahlenfelder mit Schlüsselsymbol | offen |
| RS-17-P10 | Untere Leiste | Taste „»“, Schloss-Symbol, Produktion, Einstellungen, Zurück vorhanden | offen |
| RS-17-P11 | Beispielwerte laut Bild | Zu: 0 °/80 %/0 %/0 %/0 %; Auf: 37 °/80 %/0 %/0 %/0 % | offen |
| RS-17-P12 | Medien | [RS-17_01](../Medien/RS-17_01.png) eingebunden und beschrieben | offen |

## Offene Punkte
1. Elternseite/Navigationsweg zu dieser Seite unklar (A-11): RS-16 zeigt keine Taste dorthin.
2. Seitentitel im Bild lautet „Motorparameter HD1“ (Hauptdosierer 1), nicht Schließmaschine; Handbuch nutzt dasselbe Bild für RS-12, RS-17 und RS-20.
3. Wertebereiche, Standardwerte, Berechtigungsstufen fehlen; Bedeutung der Taste „»“ und des Schloss-Symbols nicht erklärt.
4. Beschreibungstext spricht von „Schneckendosierer“, die Schließmaschine ist laut RS-16 keiner; Bezug zur Schließmaschine bleibt unklar.
