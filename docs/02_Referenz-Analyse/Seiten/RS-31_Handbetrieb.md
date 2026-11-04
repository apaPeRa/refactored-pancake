# RS-31 – Handbetrieb

- Quelle: `src_Data/Referenz/Referenz.docx`, Kapitel „Handbetrieb“ (Zweck, Seitenübersicht, Funktionsbeschreibung, Tabelle T41); Bild [RS-31_01.png](../Medien/RS-31_01.png)
- Navigationspfad: Einstellung › Handbetrieb › (Aktor) (Herkunft: abgeleitet; Wechsel von [RS-30](RS-30_Handbetrieb-Auswahl.md) zur Aktorseite im Handbuch nicht ausdrücklich beschrieben, Annahme A-14).

## Zweck

Wortgetreu: „Diese Seite dient dem gezielten Ansteuern einzelner Aktoren im Handbetrieb. Zusätzlich werden relevante Statusinformationen zur aktuellen Position und Bewegung angezeigt. Nicht alle beschriebenen Funktionen sind bei jedem Aktor vorhanden. Aktoren können nur im Handbetrieb angesteuert werden.“

## Aufbau (Bereiche, Layout)

Bild [RS-31_01.png](../Medien/RS-31_01.png) (blauer Hintergrund):

- **Kopfzeile:** Logo APA-TEC links, Seitentitel „Handbetrieb“ (fett, unterstrichen), Wirbel-Symbol, Uhrzeit „13:05:39“ und Datum „12.05.2025“.
- **Aktor-Überschrift:** zentriert, fett, unterstrichen: „Antrieb Zuführung 2MA1“.
- **Oberer Bereich (Bewegung/Status):** links große Taste „Jog-“ mit gelbem Schlüsselsymbol oben rechts an der Taste; rechts daneben Beschriftung „Freigabe“ und darunter „Endlage“, je mit grauer runder Status-LED (im Bild beide aus/grau); Mitte weißes Anzeigefeld mit Titel „Position:“ und Wert „283,74 °/s“; rechts von der Mitte wieder zwei graue LEDs mit den Beschriftungen „Freigabe“ und „Endlage“; ganz rechts große Taste „Jog+“ mit gelbem Schlüsselsymbol.
- **Mittlerer Bereich:** drei weiße Eingabefelder nebeneinander, je mit gelbem Schlüsselsymbol oben rechts und rotem Wert: „Beschleunigung:“ „100 %“, „Geschwindigkeit:“ „20 %“, „Verzögerung:“ „100 %“.
- **Unterer Bereich:** links Taste „<<“, in der Mitte die Beschriftung „Meldung:“ mit Text „Motorschutz ausgelöst“, rechts Taste „>>“.
- **Meldezeile:** roter Balken „*450* Palettierung nicht bereit“.
- **Untere Funktionsleiste:** Taste „Suchen“ (im Bild nach rechts versetzt, nicht am linken Rand wie in RS-30), gelbes Schloss, „Produktion“ (Haus), „Einstellungen“ (Zahnrad), „Zurück“ (Rücktaste).

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)

| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Aktor-Überschrift „Antrieb Zuführung 2MA1“ | Anzeige (Text) | Name des angewählten Aktors (Bildbeispiel) | Modulkandidat: Aktor-Überschrift |
| Jog- (Aus / Grundstellung / Jog –) | Taste mit Schlüsselsymbol | „Steuert den Aktor in die Grundstellung oder Richtung *Minus*.“ Im Bild beschriftet „Jog-“. | Modulkandidat: Taste mit Schlüsselsymbol |
| Jog+ (Ein / Arbeitsstellung / Jog +) | Taste mit Schlüsselsymbol | „Steuert den Aktor in die Arbeitsstellung oder Richtung *Plus*.“ Im Bild beschriftet „Jog+“. | Modulkandidat: Taste mit Schlüsselsymbol |
| Freigabe (links und rechts) | Status-LED | „Freigabe für eine Bewegung in die jeweilige Richtung.“ | Modulkandidat: Status-LED |
| Endlage (links und rechts) | Status-LED | „Zeigt an, ob die Endlage erreicht wurde.“ | Modulkandidat: Status-LED |
| Position | Anzeigefeld numerisch | „Zeigt die aktuelle Position des Aktors an.“ Bildbeispiel „283,74 °/s“ | Modulkandidat: Anzeigefeld mit Titel |
| Beschleunigung | Eingabefeld mit Schlüsselsymbol | „Vorgabewert für die Beschleunigung bzw. Verzögerung des Aktors. Der Wert 0 entspricht 100% oder Hardwarevorgabe.“ Bild: „100 %“ | Modulkandidat: Eingabefeld mit Schlüsselsymbol |
| Verzögerung | Eingabefeld mit Schlüsselsymbol | wie Beschleunigung (gemeinsame Zeile im Handbuch). Bild: „100 %“ | Modulkandidat: Eingabefeld mit Schlüsselsymbol |
| Geschwindigkeit | Eingabefeld mit Schlüsselsymbol | „Sollgeschwindigkeit des Aktors.“ Bild: „20 %“ | Modulkandidat: Eingabefeld mit Schlüsselsymbol |
| Position zurück / Position vor | Tasten (im Bild nicht sichtbar) | Siehe Tabelle; nur Servoantriebe im Positioniermodus | – |
| Freigabe bei Position-Nr, Position-Nr | Elemente (im Bild nicht sichtbar) | Siehe Tabelle | – |
| Tasten „<<“ / „>>“ | Navigationstasten | Im Handbuch zu dieser Seite nicht beschrieben; im Bild links und rechts der Meldungszeile (vermutlich Wechsel zwischen Aktoren) | Modulkandidat: Navigationstasten << / >> |
| „Meldung:“ mit Text | Statusanzeige | Im Handbuch zu dieser Seite nicht beschrieben; Bildbeispiel „Motorschutz ausgelöst“ | Modulkandidat: Meldungsanzeige (Statusliste) |
| Taste „Suchen“ | Taste | im Handbuch nicht beschrieben (siehe RS-30) | Modulkandidat: Suchen-Taste |
| Kopfzeile, Meldezeile, Untere Funktionsleiste | Rahmen | wie RS-30 | Modulkandidat: Seitenkopf; Meldezeile; Untere Funktionsleiste |

### Tabelle T41 (Funktionsbeschreibung), 12 Zeilen (1 Kopfzeile + 11 Datenzeilen), vollständig

| Funktion | Beschreibung |
|---|---|
| Aus / Grundstellung / Jog – | Steuert den Aktor in die Grundstellung oder Richtung *Minus*. |
| Ein / Arbeitsstellung / Jog + | Steuert den Aktor in die Arbeitsstellung oder Richtung *Plus*. |
| Position zurück | Fährt eine Position zurück. Nur für Servoantriebe, welche im Positioniermodus arbeiten. |
| Position vor | Fährt eine Position vor. Nur für Servoantriebe, welche im Positioniermodus arbeiten. |
| Freigabe | Freigabe für eine Bewegung in die jeweilige Richtung. |
| Endlage | Zeigt an, ob die Endlage erreicht wurde. |
| Freigabe bei Position-Nr | Freigabe für das Anfahren einer bestimmten Positionsnummer. |
| Position | Zeigt die aktuelle Position des Aktors an. |
| Position-Nr | Zeigt die aktuelle Positionsnummer an. |
| Beschleunigung / Verzögerung | Vorgabewert für die Beschleunigung bzw. Verzögerung des Aktors. Der Wert 0 entspricht 100% oder Hardwarevorgabe. |
| Geschwindigkeit | Sollgeschwindigkeit des Aktors. |

### Bilder

| Bild | Beschreibung |
|---|---|
| [RS-31_01.png](../Medien/RS-31_01.png) (Original `image53.png`, Fließtext, Seitenübersicht) | Aktorseite für „Antrieb Zuführung 2MA1“ mit Jog-/Jog+-Tasten (je Schlüssel), je zwei LEDs Freigabe/Endlage, Positionsfeld „283,74 °/s“, Feldern Beschleunigung 100 %, Geschwindigkeit 20 %, Verzögerung 100 % (rot, je Schlüssel), Tasten „<<“ „>>“, Meldung „Motorschutz ausgelöst“, rote Meldezeile, untere Leiste. |

## Verwendete Module (IDs)

Noch keine RM-IDs vergeben. Modulkandidaten: Seitenkopf, Meldezeile, Untere Funktionsleiste, Suchen-Taste, Taste mit Schlüsselsymbol, Status-LED, Eingabefeld mit Schlüsselsymbol, Anzeigefeld mit Titel, Navigationstasten << / >>, Meldungsanzeige (Statusliste), Aktor-Überschrift.

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

- „Nicht alle beschriebenen Funktionen sind bei jedem Aktor vorhanden“: Elemente sind je Aktor ein-/ausgeblendet (z. B. Position zurück/vor nur für Servoantriebe im Positioniermodus).
- „Aktoren können nur im Handbetrieb angesteuert werden.“
- Berechtigungen: Schlüsselsymbole an Jog-, Jog+ und den Feldern Beschleunigung, Geschwindigkeit, Verzögerung im Bild; Berechtigungsstufe im Handbuch nicht genannt.
- Eingabe in Zahlenfelder: Eingabeweise (Pop-up) im Handbuch nicht beschrieben.
- Beschleunigung/Verzögerung: Wert 0 entspricht 100 % oder Hardwarevorgabe; Einheit im Bild „%“. Bildwerte rot dargestellt (Bedeutung der Farbe unbekannt).
- Fehler-/Zustandsbeschreibung im Bild: Meldung „Motorschutz ausgelöst“. LED-Zustände im Bild: alle vier LEDs grau (aus).
- Jog gedrückt halten bzw. Tipp-Verhalten: nicht beschrieben.

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RS-31-P01 | Seitentitel in der Kopfzeile | „Handbetrieb“ | offen |
| RS-31-P02 | Aktor-Überschrift | Name des Aktors, im Beispiel „Antrieb Zuführung 2MA1“ | offen |
| RS-31-P03 | Tasten Jog- und Jog+ | Je eine Taste links/rechts mit Schlüsselsymbol; Jog- = Grundstellung/Richtung Minus, Jog+ = Arbeitsstellung/Richtung Plus | offen |
| RS-31-P04 | LEDs Freigabe und Endlage | Je Richtung eine LED „Freigabe“ und eine LED „Endlage“, links und rechts des Positionsfelds | offen |
| RS-31-P05 | Positionsfeld | Feld „Position:“ zeigt aktuelle Position, Bildbeispiel „283,74 °/s“ | offen |
| RS-31-P06 | Felder Beschleunigung, Geschwindigkeit, Verzögerung | Drei Felder mit Schlüsselsymbol; Beispielwerte 100 %, 20 %, 100 % | offen |
| RS-31-P07 | Wert 0 bei Beschleunigung/Verzögerung | Entspricht 100 % oder Hardwarevorgabe | offen |
| RS-31-P08 | Funktionen Position zurück / Position vor | Nur bei Servoantrieben im Positioniermodus vorhanden | offen |
| RS-31-P09 | Freigabe bei Position-Nr / Position-Nr | Freigabe zum Anfahren einer Positionsnummer bzw. Anzeige der aktuellen Positionsnummer | offen |
| RS-31-P10 | Funktionen je Aktor | Nicht vorhandene Funktionen werden beim jeweiligen Aktor nicht angeboten | offen |
| RS-31-P11 | Tasten „<<“ und „>>“ | Links und rechts der Meldungszeile vorhanden (Wechsel zwischen Aktoren vermutet) | offen |
| RS-31-P12 | Meldungszeile | „Meldung:“ mit Text, Bildbeispiel „Motorschutz ausgelöst“ | offen |
| RS-31-P13 | Ansteuerung nur im Handbetrieb | Aktor ist nur im Handbetrieb ansteuerbar | offen |
| RS-31-P14 | Untere Funktionsleiste | „Suchen“, Schloss, „Produktion“, „Einstellungen“, „Zurück“ | offen |
| RS-31-P15 | Navigation | Einstellung › Handbetrieb › (Aktor) | offen |

## Offene Punkte

1. Der Wechsel von RS-30 zur Aktorseite ist im Handbuch nicht beschrieben (Pfad abgeleitet).
2. Im Bild trägt „Position“ die Einheit „°/s“ (eine Geschwindigkeitseinheit); im Handbuch „aktuelle Position“, Einheit nicht angegeben.
3. Im Handbuch fehlen Beschreibungen für „<<“ / „>>“ und „Meldung“ auf dieser Seite; Bild zeigt sie.
4. Bedeutung der roten Schrift bei den Prozentwerten und der Wertebereich (0 bis 100 %?) nicht angegeben.
5. Position-Nr, Freigabe bei Position-Nr, Position zurück/vor sind im Bild nicht sichtbar (Aktor 2MA1 ohne Positioniermodus vermutet).
6. Taste „Suchen“ steht im Bild an anderer Position als in RS-30; Bedeutung der Verschiebung unklar.
7. Beschriftungen im Handbuch („Aus / Grundstellung / Jog –“) und im Bild („Jog-“) weichen ab.
