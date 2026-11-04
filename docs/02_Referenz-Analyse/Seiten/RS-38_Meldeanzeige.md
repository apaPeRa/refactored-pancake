# RS-38 – Meldeanzeige
- Quelle: Referenz.docx, Kapitel 38 „Meldeanzeige“ (Zweck, Seitenübersicht, Funktionsbeschreibung, Tabelle 48); Bild [RS-38_01.png](../Medien/RS-38_01.png)   - Navigationspfad: Meldezeile (jede Seite) › Meldeanzeige (Antippen der Meldezeile; Schließen per Klick oder „Zurück“)

## Zweck
Wortgetreu: „Die Meldeanzeige stellt aktuelle Systemmeldungen übersichtlich dar. Sie dient dem Bedienpersonal zur Diagnose von Störungen, Warnungen und Hinweisen.“

## Aufbau (Bereiche, Layout)
Beschreibung von [RS-38_01.png](../Medien/RS-38_01.png):
- **Kopfzeile:** Logo, Titel „Meldungsanzeige“ (Handbuch: „Meldeanzeige“), Wirbelsymbol, Uhrzeit 13:06:15, Datum 12.05.2025.
- **Liste (fast Vollbild)** mit Kopfzeile in 2 Spalten: „Nummer“ · „Meldung“; Rollbalken rechts (grau, Schieber im oberen Bereich). Zeilen farbig hinterlegt, aufsteigend nach Nummer:
  - gelb: „*090* Palettierung nicht bereit“, „*098* Grundstellungsfahrt Hochstoß“, „*099* Grundstellungsfahrt aktiv“
  - rot: „*100* Steuerung ein Schalter ist ausgeschaltet“, „*101* Sicherung 0F24A DC 24 V nicht bereit“, „*102*“ bis „*109* Sicherung 0F24A Kanal 1 … Kanal 8 ausgelöst“, „*150* Störung Hochstoß 3Y1: <GR003_Aktoren.instAktor_3Y1.o_sError, STRING>“, „*170* Paket im Einlauf umgefallen“, „*171* Störung Einlaufband 5MA1: Motorschutz ausgelöst“, „*173* Paket im Einlauf verdreht“, „*191* Störung Höhenregulierung 8MA1: <GR008_Aktoren.instAktor_8MA1.o_sError, STRING>“, „*201* Störung Vorabwicklung 9MA1: <GR009_Aktoren.instAktor_9MA1.o_sError, STRING>“, „*203* Pendelposition nicht plausibel“, „*204* Rolle nicht oben“ (abgeschnitten)
- **Meldezeile** (rot) unten: „*450* Palettierung nicht bereit“ (überlagert den unteren Listenrand).
- **Untere Leiste:** links Taste „Archiv“ (Archiv-Symbol mit Ausrufezeichen); Vorhängeschloss (offen); rechts „Produktion“, „Einstellungen“, „Zurück“.

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Alle 6 Zeilen der Tabelle 48, wortgetreu:

| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Automatische Anzeige | Verhalten der Meldezeile | „Beim Auftreten einer Meldung wird die Meldung mit der höchsten Nummer in der Meldezeile im unteren Bereich der HMI-Seiten eingeblendet.“ | Modulkandidat: Meldezeile |
| Meldeanzeige öffnen | Interaktion (Antippen der Meldezeile) | „Durch Antippen dieser Zeile wird die vollständige Meldeanzeige geöffnet.“ | Modulkandidat: Meldezeile |
| Meldeanzeige schließen | Interaktion | „Ein weiterer Klick oder die Schaltfläche *Zurück* schließt die Anzeige.“ | Modulkandidat: Funktionsleiste unten |
| Farbkennzeichnung | Darstellung | „Meldungen sind farblich codiert: Grün: Betriebsstatus Automatik; Gelb: Hinweise und Statusmeldungen; Rot: Störung oder sicherheitsrelevante Meldung. Führen zum Stopp“ | Modulkandidat: Meldungsliste mit Farbcodierung; Modulkandidat: Statusliste |
| Meldungsnummer | Listenspalte „Nummer“ | „Eindeutige Nummer zur Identifikation der Meldung, z. B. für Service oder Dokumentation.“ | Modulkandidat: Meldungsliste mit Farbcodierung |
| Meldungstext | Listenspalte „Meldung“ | „Kurzbeschreibung der Ursache oder des betroffenen Bereichs.“ | Modulkandidat: Meldungsliste mit Farbcodierung |

Nur im Bild sichtbar:

| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Taste „Archiv“ (links unten) | Taste | im Handbuch nicht beschrieben (vermutlich Wechsel zu [RS-37](RS-37_Meldearchiv.md)) | Modulkandidat: Funktionsleiste unten |
| Rollbalken | Bedienelement | Blättern in der Liste | Modulkandidat: Listen-Scrolltasten (hier als Rollbalken) |
| Kopfzeile, Schloss, Tasten Produktion/Einstellungen/Zurück | Rahmen | siehe [RS-35](RS-35_Systemeinstellungen.md) | Modulkandidat: Kopfzeile; Funktionsleiste unten |

## Verwendete Module (IDs)
Noch keine RM-IDs. Modulkandidaten: Meldezeile, Meldungsliste mit Farbcodierung, Statusliste, Funktionsleiste unten, Kopfzeile, Listen-Scrolltasten.

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- Auslösung: Meldezeile antippen öffnet die Anzeige; erneutes Antippen oder „Zurück“ schließt sie.
- Farben: Grün = Betriebsstatus Automatik; Gelb = Hinweise und Statusmeldungen; Rot = Störung oder sicherheitsrelevante Meldung, führt zum Stopp.
- Meldezeile zeigt die Meldung mit der höchsten Nummer.
- Berechtigungen: keine Schlüsselsymbole auf der Seite.
- Quittieren: im Handbuch nicht beschrieben (Taste „Reset“ o. Ä. nicht sichtbar).

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RS-38-P01 | Automatische Anzeige | Bei Auftreten einer Meldung zeigt die Meldezeile unten auf allen HMI-Seiten die Meldung mit der höchsten Nummer | offen |
| RS-38-P02 | Öffnen | Antippen der Meldezeile öffnet die vollständige Meldeanzeige | offen |
| RS-38-P03 | Schließen | Weiteres Antippen oder „Zurück“ schließt die Anzeige | offen |
| RS-38-P04 | Farbe Grün | Betriebsstatus Automatik | offen |
| RS-38-P05 | Farbe Gelb | Hinweise und Statusmeldungen | offen |
| RS-38-P06 | Farbe Rot | Störung oder sicherheitsrelevante Meldung, führt zum Stopp | offen |
| RS-38-P07 | Listenspalten | „Nummer“ (z. B. *090*) und „Meldung“ (Text) | offen |
| RS-38-P08 | Zustände nicht nur über Farbe | Zusätzlich zur Farbe ist die Meldung über Nummer/Text identifizierbar (siehe Offene Punkte zu Symbolen) | offen |
| RS-38-P09 | Untere Leiste | Taste „Archiv“ links, Schloss, Produktion, Einstellungen, Zurück | offen |
| RS-38-P10 | Bildabgleich | Bild zeigt Liste mit Rollbalken, Meldezeile *450* unten, Titel „Meldungsanzeige“ | offen |

## Offene Punkte
- Titel im Bild „Meldungsanzeige“, Kapitel „Meldeanzeige“.
- Taste „Archiv“ nicht im Handbuch beschrieben (Navigation zu RS-37 angenommen).
- Sortierung der Liste, Verhalten bei mehreren gleichzeitigen Meldungen sowie Quittierung nicht beschrieben.
- Farbe der Meldung *090* „Palettierung nicht bereit“: in der Liste gelb, in der Meldezeile (*450*) rot – Zuordnung Nummer→Farbe nicht erklärt.
- Handbuch nennt rote Meldungen „Führen zum Stopp“ (Satzbau unvollständig).
- Meldezeile im Bild überdeckt die untere Listenzeile (*204*).
