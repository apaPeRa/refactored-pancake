# RS-34 – EA-Anzeige

- Quelle: `src_Data/Referenz/Referenz.docx`, Kapitel „EA-Anzeige“ (Zweck, Seitenübersicht, Funktionsbeschreibung, Tabelle T44); Bild [RS-34_01.png](../Medien/RS-34_01.png)
- Navigationspfad: Einstellung › EA-Übersicht › EA-Anzeige (Herkunft: abgeleitet; Zugang von [RS-33](RS-33_EA-Uebersicht.md) im Handbuch nicht beschrieben, Annahme A-14). Navigationstasten blättern zwischen EA-Karten.

## Zweck

Wortgetreu: „Die Seite EA-Anzeige dient der Diagnose aller digitalen und analogen Ein- und Ausgänge an der SPS. Sie zeigt den aktuellen Zustand der angeschlossenen Betriebsmittel und Signale“ (Satz im Original ohne Schlusspunkt).

## Aufbau (Bereiche, Layout)

Bild [RS-34_01.png](../Medien/RS-34_01.png) (blauer Hintergrund):

- **Kopfzeile:** Logo, Titel „Eingänge S1“ (fett, unterstrichen), Wirbel-Symbol, Uhrzeit „13:05:52“, Datum „12.05.2025“.
- **Karten-Überschrift:** „S1_0KDE1“ (unterstrichen, zentriert).
- **Signalliste:** 8 Zeilen untereinander. Je Zeile links eine graue runde Status-LED (alle 8 im Bild grau), daneben ein weißes Feld mit der SPS-Kennung und rechts ein breiteres weißes Feld mit der Klartextbeschreibung (Großbuchstaben, kleine Schrift). Zeileninhalte (Kennung | Klartext):
  1. 0F24A_rdy | SICHERUNGS MODUL BEREIT (0F24A)
  2. 0F24A_state | SICHERUNGS MODUL STATUS (0F24A)
  3. S1_0KDE1_3 | RESERVE
  4. S1_0KDE1_4 | RESERVE
  5. 0E3 | KUEHLGERAET BEREIT
  6. S1_0KDE1_6 | RESERVE
  7. 0Q5 | SPANNUNG FU-ANTRIEBE OK
  8. 0Q7 | SPANNUNG SERVO-ANTRIEBE OK
- **Meldezeile:** roter Balken „*450* Palettierung nicht bereit“.
- **Untere Funktionsleiste:** links Tasten „<<“ und (etwas rechts davon) „>>“; gelbes Schloss; „Produktion“ (Haus), „Einstellungen“ (Zahnrad), „Zurück“ (Rücktaste). Keine Taste „Suchen“.
- Keine Zahlenfelder (analoge Anzeige im Bild nicht zu sehen), keine Schlüsselsymbole.

## Elemente

| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Karten-Überschrift „S1_0KDE1“ | Anzeige (Text) | Bezeichnung der angezeigten EA-Karte (Bildbeispiel) | Modulkandidat: Aktor-Überschrift |
| Digitale Anzeige (LED) | Status-LED mit SPS-Kennung und Klartext | Handbuch (T44): „Jeder digitale Ein- oder Ausgang wird mit einer Statusleuchte angezeigt. Daneben steht die SPS-Kennung sowie eine Klartextbeschreibung.“ | Modulkandidat: EA-Zeile (LED, Kennung, Klartext); Status-LED |
| Analoge Anzeige | numerische Anzeige | Handbuch (T44): „Analoge Eingänge oder Ausgänge werden als numerische Werte angezeigt. Diese Darstellung ist auf speziellen Karten aktiv, auf denen analoge Signale verarbeitet werden.“ Im Bild nicht dargestellt | Modulkandidat: Anzeigefeld mit Beschriftung |
| Navigationstasten „<<“ / „>>“ | Tasten (untere Leiste) | Handbuch (T44): „Blättern zwischen den einzelnen EA-Karten. Jede Karte ist auf einer eigenen Seite dargestellt.“ | Modulkandidat: Navigationstasten << / >> |
| Kopfzeile, Meldezeile, Untere Funktionsleiste | Rahmen | wie RS-30 | Modulkandidat: Seitenkopf; Meldezeile; Untere Funktionsleiste |

### Tabelle T44 (Funktionsbeschreibung), 4 Zeilen (1 Kopfzeile + 3 Datenzeilen), vollständig

| Funktion | Beschreibung |
|---|---|
| Digitale Anzeige (LED) | Jeder digitale Ein- oder Ausgang wird mit einer Statusleuchte angezeigt. Daneben steht die SPS-Kennung sowie eine Klartextbeschreibung. |
| Analoge Anzeige | Analoge Eingänge oder Ausgänge werden als numerische Werte angezeigt. Diese Darstellung ist auf speziellen Karten aktiv, auf denen analoge Signale verarbeitet werden. |
| Navigationstasten << / >> | Blättern zwischen den einzelnen EA-Karten. Jede Karte ist auf einer eigenen Seite dargestellt. |

### Bilder

| Bild | Beschreibung |
|---|---|
| [RS-34_01.png](../Medien/RS-34_01.png) (Original `image56.png`, Fließtext, Seitenübersicht) | Seite „Eingänge S1“, Karte „S1_0KDE1“: 8 Zeilen mit grauer LED, SPS-Kennung und Klartext (siehe Aufbau), rote Meldezeile, untere Leiste mit „<<“, „>>“, Schloss, „Produktion“, „Einstellungen“, „Zurück“. |

## Verwendete Module (IDs)

Noch keine RM-IDs vergeben. Modulkandidaten: Seitenkopf, Meldezeile, Untere Funktionsleiste, EA-Zeile (LED, Kennung, Klartext), Status-LED, Anzeigefeld mit Beschriftung, Navigationstasten << / >>, Aktor-Überschrift (Karten-Überschrift).

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

- LED-Zustand: Im Bild alle LEDs grau (inaktiv); Farbe/Zustand „aktiv“ im Handbuch nicht beschrieben.
- Blättern zwischen EA-Karten mit „<<“ / „>>“; jede Karte eine eigene Seite.
- Analoge Werte nur auf speziellen Analogkarten.
- Berechtigungen, Einheiten, Wertebereiche, Standardwerte, Pop-ups, Fehlerfälle: im Handbuch keine Angaben. Reine Anzeigeseite, im Bild kein Bedienelement außer Navigationstasten.

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RS-34-P01 | Seitentitel in der Kopfzeile | Bezeichnung der Karte, im Beispiel „Eingänge S1“ | offen |
| RS-34-P02 | Karten-Überschrift | Im Beispiel „S1_0KDE1“ | offen |
| RS-34-P03 | Zeilen der Karte S1_0KDE1 | 8 Zeilen: 0F24A_rdy, 0F24A_state, S1_0KDE1_3, S1_0KDE1_4, 0E3, S1_0KDE1_6, 0Q5, 0Q7 mit den Klartexten SICHERUNGS MODUL BEREIT (0F24A), SICHERUNGS MODUL STATUS (0F24A), RESERVE, RESERVE, KUEHLGERAET BEREIT, RESERVE, SPANNUNG FU-ANTRIEBE OK, SPANNUNG SERVO-ANTRIEBE OK | offen |
| RS-34-P04 | Digitale Anzeige | Je digitalem Ein-/Ausgang eine Statusleuchte, daneben SPS-Kennung und Klartextbeschreibung | offen |
| RS-34-P05 | Analoge Anzeige | Auf Analogkarten werden Ein-/Ausgänge als numerische Werte angezeigt | offen |
| RS-34-P06 | Tasten „<<“ und „>>“ | Blättern zwischen EA-Karten, jede Karte eigene Seite | offen |
| RS-34-P07 | Untere Funktionsleiste | Keine Taste „Suchen“; Schloss, „Produktion“, „Einstellungen“, „Zurück“ vorhanden | offen |
| RS-34-P08 | Navigation | Einstellung › EA-Übersicht › EA-Anzeige | offen |

## Offene Punkte

1. Zugang von RS-33 zur EA-Anzeige und Zuordnung Schaltfläche zu Karte/Seite nicht beschrieben; Anzahl der Karten je Schaltfläche unklar.
2. Zustandsfarbe aktiver LEDs und Bedeutung der Klartextgroßschreibung nicht beschrieben.
3. Aufbau der analogen Anzeige (Einheit, Format) im Bild nicht vorhanden.
4. Klartexte im Bild verwenden Großbuchstaben und ASCII-Schreibung („KUEHLGERAET“); Übernahme oder Normalisierung offen.
5. Titel zeigt „Eingänge S1“ im Bild, Seitenname im Handbuch „EA-Anzeige“.
