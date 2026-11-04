# RS-33 – EA-Übersicht

- Quelle: `src_Data/Referenz/Referenz.docx`, Kapitel „EA-Übersicht“ (Zweck, Seitenübersicht, Funktionsbeschreibung, Tabelle T43); Bild [RS-33_01.png](../Medien/RS-33_01.png); Eintrag „EA-Übersicht“ in RS-04 („Zeigt alle EA-Karten und den Zustand der entsprechenden Kanäle an.“)
- Navigationspfad: Einstellung › EA-Übersicht (Herkunft: Handbuch). Weiterführend: [RS-34](RS-34_EA-Anzeige.md).

## Zweck

Wortgetreu: „Die Seite EA-Übersicht zeigt alle Ein- und Ausgänge (EA) der Maschine an. Sie dient zur Diagnose und Kontrolle der über die SPS angebundenen Betriebsmittel.“

## Aufbau (Bereiche, Layout)

Bild [RS-33_01.png](../Medien/RS-33_01.png) (blauer Hintergrund):

- **Kopfzeile:** Logo, Titel „EA Auswahl“ (fett, unterstrichen; Schreibweise im Bild, nicht „EA-Übersicht“), Wirbel-Symbol, Uhrzeit „13:05:49“, Datum „12.05.2025“.
- **Arbeitsbereich:** Raster 4 Spalten × 2 Zeilen mit großen quadratischen grauen Tasten, 6 beschriftet, 2 Zellen leer. Beschriftungen: Zeile 1 „Eingänge S1“ · „Ausgänge S1“ · „Eingänge S300“ · „Ausgänge S300“; Zeile 2 „Eingänge S500“ · „Ausgänge S500“ · (leer) · (leer).
- **Meldezeile:** roter Balken „*450* Palettierung nicht bereit“.
- **Untere Funktionsleiste:** links Taste „Suchen“; gelbes Schloss; „Produktion“ (Haus), „Einstellungen“ (Zahnrad), „Zurück“ (Rücktaste).
- Keine Zahlenfelder, keine Schlüsselsymbole.

## Elemente

| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| EA-Schaltflächen (6: Eingänge/Ausgänge S1, S300, S500) | Tasten im Raster | Handbuch (T43): „Über die Schaltflächen können Ein- und Ausgänge gezielt angezeigt und überprüft werden.“ | Modulkandidat: Auswahl-Kachelraster |
| Taste „Suchen“ | Taste (untere Leiste, links) | Handbuch (T43): „Öffnet eine Suchfunktion, über die Betriebsmittel anhand ihrer Betriebsmittelkennzeichnung gefunden werden können.“ | Modulkandidat: Suchen-Taste |
| Kopfzeile, Meldezeile, Untere Funktionsleiste | Rahmen | wie RS-30 | Modulkandidat: Seitenkopf; Meldezeile; Untere Funktionsleiste |

### Tabelle T43 (Funktionsbeschreibung), 3 Zeilen (1 Kopfzeile + 2 Datenzeilen), vollständig

| Funktion | Beschreibung |
|---|---|
| EA-Schaltflächen | Über die Schaltflächen können Ein- und Ausgänge gezielt angezeigt und überprüft werden. |
| Suchen | Öffnet eine Suchfunktion, über die Betriebsmittel anhand ihrer Betriebsmittelkennzeichnung gefunden werden können. |

### Bilder

| Bild | Beschreibung |
|---|---|
| [RS-33_01.png](../Medien/RS-33_01.png) (Original `image55.png`, Fließtext, Seitenübersicht) | Seite „EA Auswahl“ mit 6 großen Tasten (Eingänge/Ausgänge S1, S300, S500) im 4 × 2-Raster, rote Meldezeile, untere Leiste mit „Suchen“, Schloss, „Produktion“, „Einstellungen“, „Zurück“. |

## Verwendete Module (IDs)

Noch keine RM-IDs vergeben. Modulkandidaten: Seitenkopf, Meldezeile, Untere Funktionsleiste, Suchen-Taste, Auswahl-Kachelraster.

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

- Tippen auf eine EA-Schaltfläche zeigt die zugehörige EA-Karte (Beispiel „Eingänge S1“ siehe [RS-34](RS-34_EA-Anzeige.md)); Zugang im Handbuch nicht ausdrücklich beschrieben.
- „Suchen“ öffnet eine Suchfunktion (Aufbau nicht beschrieben, nicht abgebildet).
- Berechtigungen, Wertebereiche, Einheiten, Standardwerte, Fehlerfälle: im Handbuch keine Angaben.

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RS-33-P01 | Seitentitel in der Kopfzeile | Im Bild „EA Auswahl“; Seitenname im Handbuch „EA-Übersicht“ | offen |
| RS-33-P02 | Anzahl und Beschriftung der EA-Schaltflächen | 6 Tasten: Eingänge S1, Ausgänge S1, Eingänge S300, Ausgänge S300, Eingänge S500, Ausgänge S500 | offen |
| RS-33-P03 | Anordnung der EA-Schaltflächen | 4 Spalten; Zeile 1 mit 4 Tasten (S1 Ein/Aus, S300 Ein/Aus), Zeile 2 mit 2 Tasten (S500 Ein/Aus) | offen |
| RS-33-P04 | EA-Schaltfläche antippen | Zeigt die zugehörigen Ein- bzw. Ausgänge zur Überprüfung (RS-34) | offen |
| RS-33-P05 | Taste „Suchen“ | Öffnet Suchfunktion zum Finden von Betriebsmitteln anhand der Betriebsmittelkennzeichnung | offen |
| RS-33-P06 | Meldezeile und untere Funktionsleiste | Rote Meldezeile; Schloss, „Produktion“, „Einstellungen“, „Zurück“ | offen |
| RS-33-P07 | Navigation | Einstellung › EA-Übersicht; Zugang über Eintrag in RS-04 | offen |

## Offene Punkte

1. Seitentitel im Bild „EA Auswahl“ (mit Schreibweise „Auswahl“), Handbuchname „EA-Übersicht“; Titel für das neue HMI festlegen.
2. Bedeutung der Kürzel S1, S300, S500 (SPS-Stationen/Karten?) nicht erklärt.
3. Aufbau der Suchfunktion nicht beschrieben.
4. Zugang zu den EA-Karten (RS-34) im Handbuch nicht beschrieben; Anzahl der Schaltflächen vermutlich maschinenabhängig.
