# RS-22 – Heizungen
- Quelle: Referenz.docx, Kapitel 22 „Heizungen“ (Zweck, Seitenübersicht, Funktionsbeschreibung, Tabelle T32 mit 7 Zeilen inkl. Kopfzeile, 1 Hinweis-Textfeld); Bild [RS-22_01.png](../Medien/RS-22_01.png)
- Navigationspfad: Einstellung › Heizungen (Eintrag in der Tabelle von [RS-04](RS-04_Einstellungen.md); die Aktivierung der Heizungen erfolgt laut Handbuch über die Seite Produktion, [RS-01](RS-01_Produktion.md))

## Zweck
Zum Verschließen des Siegelpapiers sind Heizungen im Dornrad und in der Schließmaschine verbaut. Auf der Seite werden für jede Zone die Temperaturen überwacht und eingestellt. Die Aktivierung der Heizungen erfolgt über die Seite Produktion (Handbuch wörtlich: „Hier können für jede Zone die Temperaturen überwacht und eingestellt werden. Die Aktivierung der Heizungen erfolgt über die Seite Produktion.“).

## Aufbau (Bereiche, Layout)
Beschreibung des Bildes [RS-22_01.png](../Medien/RS-22_01.png) (Altes HMI, 1024 × 768, Querformat):

- **Kopfzeile (hellgrau):** links Logo „APA-TEC GmbH – Automation and Packaging Technology“, in der Mitte der unterstrichene Seitentitel „Heizungen“, rechts davon ein schwarzes Wirbel-Symbol (Firmen-/Statussymbol, ohne Beschriftung), ganz rechts Uhrzeit „13:04:05“ und darunter Datum „12.05.2025“.
- **Arbeitsbereich:** blauer Hintergrund mit einem hellgrauen Panel. Das Panel ist eine Tabelle aus 12 Zeilen und 6 Spalten. Kopfzeile der Spalten (fett): Heizung | Meldung | Soll | Ist | State | Out.
- **Zeilenbeschriftungen (links neben der Spalte Heizung, rechtsbündig), 12 Zonen von oben nach unten:**
  1. 6E1 Längsnaht Links Zone 1
  2. 6E1 Längsnaht Links Zone 2
  3. 6E1 Längsnaht Links Zone 3
  4. 6E2 Längsnaht Rechts
  5. 6E3 Boden Oben Vorsiegeln
  6. 6E4 Boden Unten Vorsiegeln
  7. 6E4 Boden Oben Fertigsiegeln
  8. 6E4 Boden Unten Fertigsiegeln
  9. 20E1 Kopf Vorsiegeln Hinten
  10. 20E2 Kopf Vorsiegeln Vorne
  11. 20E3 Kopf Fertigsiegeln Hinten
  12. 20E4 Kopf Fertigsiegeln Vorne
- **Spalte Heizung:** je Zeile eine grüne Schaltfläche mit Beschriftung „Ein“ und gelbem Schlüsselsymbol in der oberen rechten Ecke (alle 12 Zeilen „Ein“).
- **Spalte Meldung:** je Zeile eine graue Schaltfläche mit grünem Häkchen-Symbol und gelbem Schlüsselsymbol oben rechts (Überwachung aktiv, alle 12 Zeilen gleich dargestellt).
- **Spalte Soll:** je Zeile ein weißes Zahlenfeld mit roter Schrift, Einheit „°“ und gelbem Schlüsselsymbol. Werte im Bild: 150 ° in den Zeilen 1–8, 170 ° in den Zeilen 9–12.
- **Spalte Ist:** je Zeile ein weißes Anzeigefeld mit schwarzer Schrift „0 °“, ohne Schlüsselsymbol (reine Anzeige).
- **Spalte State:** je Zeile eine graue runde LED (alle 12 grau).
- **Spalte Out:** je Zeile eine graue runde LED (alle 12 grau).
- **Meldezeile (rot, unter dem Panel, volle Breite):** Text „*450* Palettierung nicht bereit“ in fetter schwarzer Schrift.
- **Fußleiste:** links leer (keine Navigation unten links auf dieser Seite), mittig ein gelbes Schloss-Symbol (geschlossenes Schloss), rechts drei Tasten: „Produktion“ (Haus-Symbol), „Einstellungen“ (Zahnrad-Symbol), „Zurück“ (Rückwärts-Löschen-Pfeil-Symbol).
- **Hinweis-Textfeld im Handbuch (kein Bild, Warnsymbol ⚠️):** „Hinweis: Heizungen bleiben nach dem Abschalten noch eine Zeit lang heiß. Achtung: Verbrennungsgefahr!“

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Tabelle T32 des Handbuchs (Spalten Funktion | Beschreibung), 6 Datenzeilen, wortgetreu:

| Element (Handbuch: Funktion) | Typ | Funktion (Beschreibung wörtlich) | verwendetes Modul |
|---|---|---|---|
| Heizung | Schaltfläche Ein/Aus je Zone (Bild: grün, Text „Ein“, Schlüsselsymbol) | „Jede Heizung kann einzeln ein- oder ausgeschaltet werden.“ | Modulkandidat: Umschalter mit Schlüsselsymbol (Ein/Aus) |
| Meldung | Schaltfläche je Zone (Bild: grau mit grünem Häkchen, Schlüsselsymbol) | „Überwacht jede Heizung auf Funktion und Sollwertabweichung. Die Überwachung ist separat deaktivierbar.“ | Modulkandidat: Umschalter mit Schlüsselsymbol (Überwachung) |
| Soll | Zahlenfeld (Bild: rote Schrift, Einheit °, Schlüsselsymbol) | „Vorgabe der Zieltemperatur der entsprechenden Heizung.“ | Modulkandidat: Eingabefeld mit Schlüsselsymbol; Modulkandidat: Eingabe-Pop-up |
| Ist | Anzeigefeld (Bild: schwarze Schrift, Einheit °) | „Aktuell Temperatur der der entsprechenden Heizung.“ (Schreibweise wörtlich aus Handbuch) | Modulkandidat: Anzeigefeld Istwert |
| State | Status-LED | „Zeigt den Status der Heizung an. Grau: Heizung ist aus; Grün: Zieltemperatur erreicht; Rot: Heizung nicht bereit oder Fehler.“ | Modulkandidat: Status-LED |
| Out | Status-LED | „Zustand des Ausgangs.“ (Farbbedeutung im Handbuch nicht beschrieben) | Modulkandidat: Status-LED |
| Zeilenbeschriftung (nur im Bild) | Text | Zonenname der Heizung (12 Zonen, siehe Aufbau); im Handbuchtext nicht beschrieben | Modulkandidat: Statusliste (Tabelle mit Zeilen je Zone) |
| Seitenkopf mit Logo, Titel, Symbol, Uhrzeit/Datum (nur im Bild) | Rahmen | Standard-Kopfzeile des alten HMI | Modulkandidat: Seitenkopf (Rahmen) |
| Meldezeile (nur im Bild) | Anzeige | Aktuelle Meldung „*450* Palettierung nicht bereit“ | Modulkandidat: Meldezeile |
| Fußleiste Produktion / Einstellungen / Zurück, Schloss-Symbol (nur im Bild) | Tasten | Seitenwechsel; Schloss-Symbol im Handbuch nicht beschrieben | Modulkandidat: Fußleiste (Rahmennavigation) |

Medien dieser Seite (1 Bild, 1 Hinweis-Textfeld):

| Bild | Zeigt |
|---|---|
| [RS-22_01.png](../Medien/RS-22_01.png) | Seitenübersicht Heizungen: Tabelle mit 12 Heizzonen und den Spalten Heizung, Meldung, Soll, Ist, State, Out (Details siehe Aufbau) |

## Verwendete Module (IDs)
Noch keine RM-IDs vergeben. Modulkandidaten: Seitenkopf (Rahmen); Meldezeile; Fußleiste (Rahmennavigation); Umschalter mit Schlüsselsymbol (Ein/Aus); Eingabefeld mit Schlüsselsymbol; Eingabe-Pop-up; Anzeigefeld Istwert; Status-LED; Statusliste (Tabelle mit Zeilen je Zone).

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- **Heizung ein/aus:** jede der 12 Zonen einzeln schaltbar. Im Bild ist die Schaltfläche grün mit Text „Ein“. Darstellung für „Aus“ ist im Handbuch und im Bild nicht beschrieben.
- **Meldung (Überwachung):** überwacht Funktion und Sollwertabweichung; separat deaktivierbar. Im Bild: grauer Hintergrund mit grünem Häkchen. Darstellung der deaktivierten Überwachung ist nicht beschrieben.
- **Soll:** Eingabe der Zieltemperatur je Zone; im Bild 150 ° (Zonen 6E1 bis 6E4) und 170 ° (Zonen 20E1 bis 20E4). Eingabe vermutlich über ein Zahlen-Pop-up; im Handbuch dieser Seite nicht beschrieben.
- **Ist:** reine Anzeige, im Bild 0 ° in allen Zeilen.
- **State (Status-LED):** Grau = Heizung ist aus; Grün = Zieltemperatur erreicht; Rot = Heizung nicht bereit oder Fehler.
- **Out (Status-LED):** Zustand des Ausgangs.
- **Berechtigungen:** Das Handbuch nennt keine Berechtigungen. Im Bild tragen Heizung, Meldung und Soll ein gelbes Schlüsselsymbol (Annahme: Bedienung ist berechtigungsgeschützt, siehe Offene Punkte); Ist, State und Out haben keines.
- **Sicherheitshinweis:** Heizungen bleiben nach dem Abschalten noch eine Zeit lang heiß; „Achtung: Verbrennungsgefahr!“.
- **Aktivierung:** laut Handbuch über die Seite Produktion ([RS-01](RS-01_Produktion.md)).
- **Navigation:** Fußleiste Produktion (Haus), Einstellungen (Zahnrad), Zurück. Keine Navigation unten links.
- **Pop-ups / Unterseiten:** keine im Handbuch beschrieben.
- **Fehlerfälle:** nur State = Rot („Heizung nicht bereit oder Fehler“) und Meldung (Sollwertabweichung) beschrieben; Meldetexte sind nicht aufgeführt.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RS-22-P01 | Seitentabelle: Spalten | Sechs Spalten in der Reihenfolge Heizung, Meldung, Soll, Ist, State, Out | offen |
| RS-22-P02 | Zeilenzahl und Zonennamen | 12 Zeilen mit den Zonennamen 6E1 Längsnaht Links Zone 1/2/3, 6E2 Längsnaht Rechts, 6E3 Boden Oben Vorsiegeln, 6E4 Boden Unten Vorsiegeln, 6E4 Boden Oben Fertigsiegeln, 6E4 Boden Unten Fertigsiegeln, 20E1 Kopf Vorsiegeln Hinten, 20E2 Kopf Vorsiegeln Vorne, 20E3 Kopf Fertigsiegeln Hinten, 20E4 Kopf Fertigsiegeln Vorne | offen |
| RS-22-P03 | Heizung je Zone | Jede Zone lässt sich einzeln ein- und ausschalten; Anzeige „Ein“ für eingeschaltet | offen |
| RS-22-P04 | Meldung je Zone | Überwachung auf Funktion und Sollwertabweichung je Zone separat deaktivierbar | offen |
| RS-22-P05 | Soll | Zieltemperatur je Zone eingebbar, Einheit „°“; Beispielwerte 150 ° (Zonen 1–8) und 170 ° (Zonen 9–12) | offen |
| RS-22-P06 | Ist | Aktuelle Temperatur je Zone als reine Anzeige in „°“, nicht editierbar | offen |
| RS-22-P07 | State | LED grau = Heizung aus, grün = Zieltemperatur erreicht, rot = Heizung nicht bereit oder Fehler; zusätzlich zur Farbe ein Text oder Symbol (Vorgabe Agent.md Abschnitt 6) | offen |
| RS-22-P08 | Out | LED zeigt den Zustand des Ausgangs je Zone | offen |
| RS-22-P09 | Hinweis Verbrennungsgefahr | Hinweis „Heizungen bleiben nach dem Abschalten noch eine Zeit lang heiß. Achtung: Verbrennungsgefahr!“ ist erfasst und im neuen HMI sichtbar vorgesehen | offen |
| RS-22-P10 | Schlüsselsymbole | Heizung, Meldung und Soll tragen Schlüsselsymbol (berechtigungsgeschützt), Ist, State, Out nicht | offen |
| RS-22-P11 | Zugang | Seite erreichbar über Einstellung › Heizungen (RS-04); Aktivierung der Heizungen über RS-01 | offen |
| RS-22-P12 | Fußleiste | Tasten Produktion, Einstellungen, Zurück vorhanden; keine Navigation unten links | offen |
| RS-22-P13 | Bildabdeckung | RS-22_01.png ist verlinkt und beschrieben | offen |

## Offene Punkte
- Wertebereich (min./max.) und Standardwert der Soll-Temperatur sind im Handbuch nicht angegeben; im Bild nur 150 ° und 170 °.
- Bedeutung des Schlüsselsymbols (Berechtigungsstufe) und des Schloss-Symbols in der Fußleiste ist im Handbuch nicht beschrieben (Annahme: Eingabeschutz je Benutzerrolle).
- Darstellung der Zustände „Heizung aus“ und „Meldung deaktiviert“ ist nicht beschrieben; Farbbedeutung der LED „Out“ ist nicht beschrieben.
- Das Bild zeigt alle Heizungen „Ein“ bei Ist 0 ° und State grau; das Handbuch erklärt diese Kombination nicht (vermutlich Maschine nicht aktiv, Aktivierung über RS-01).
- Zonennamen stehen nur im Bild, nicht im Text; ob alle Maschinenvarianten dieselben 12 Zonen haben, ist unklar.
