# RS-37 – Meldearchiv
- Quelle: Referenz.docx, Kapitel 37 „Meldearchiv“ (Zweck, Seitenübersicht, Funktionsbeschreibung, Tabelle 47); Bild [RS-37_01.png](../Medien/RS-37_01.png)   - Navigationspfad: Einstellung › Systemeinstellungen › Meldearchiv (Taste „Meldearchiv“ in [RS-35](RS-35_Systemeinstellungen.md); im Design zusätzlich Seitenleiste „Meldungen“)

## Zweck
Wortgetreu: „Diese Seite zeigt alle gespeicherten Systemmeldungen der Maschine an. Sie dient der Nachverfolgung von Ereignissen, Störungen und Bedienvorgängen zur Analyse und Dokumentation.“

## Aufbau (Bereiche, Layout)
Beschreibung von [RS-37_01.png](../Medien/RS-37_01.png):
- **Kopfzeile:** Logo, Titel „Meldearchiv“, Wirbelsymbol, Uhrzeit 13:06:11, Datum 12.05.2025.
- **Tabelle links (große Liste)** mit Kopfzeile und 3 Spalten: „Zeit“ · „Ereignis“ · „Beschreibung“. Beispielzeilen im Bild (alle Ereignis „KO“):
  - rot: 05.05.2025 10:13:55 – „*120* Störung Hauptantrieb 1MA1: <GR001_Aktoren.instAktor_1MA1.o_sError, STRING>“; „*112* Klimagerät Schaltschrank nicht bereit 0E4“; „*111* Sicherung 0Q3 FU-Antriebe ausgelöst“; „*110* Sicherung 0Q2 Servoantriebe ausgelöst“; „*109*“ bis „*102* Sicherung 0F24A Kanal 8 … Kanal 1 ausgelöst“; „*101* Sicherung 0F24A DC 24 V nicht bereit“; „*100* Steuerung ein Schalter ist ausgeschaltet“
  - gelb: 05.05.2025 10:13:55 – „*081* Höhenregulierung Endlage unten“, „*080* Höhenregulierung Endlage oben“, „*070* Rolle fast leer“; 14.11.2024 16:13:17 / 16:12:07 / 11:06:31 – je „*054* Inbetriebnahme Funktionen aktiv“
  - grün: 13.11.2024 13:46:57 – „*000* Maschine ist bereit“
  - Sortierung: im Bild absteigend nach Nummer bzw. Zeit.
- **Rechts neben der Liste:** vier Scrolltasten untereinander: „an den Anfang“ (Pfeil nach oben mit Balken), „eine Seite hoch“ (Pfeil nach oben), „eine Seite runter“ (Pfeil nach unten), „ans Ende“ (Pfeil nach unten mit Balken); letztere hat blauen Rahmen (Fokus).
- **Unter der Liste, vier Tasten:** „Export“ (Schlüsselsymbol) · „Liste leeren“ (Schlüsselsymbol) · „Filter“ · „Alle Anzeigen“.
- **Meldezeile:** rot „*450* Palettierung nicht bereit“.
- **Untere Leiste:** links keine Taste; Vorhängeschloss (offen), „Produktion“, „Einstellungen“, „Zurück“.

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Alle 4 Zeilen der Tabelle 47, wortgetreu:

| Element | Typ | Funktion | Berechtigung (laut Bild) | verwendetes Modul |
|---|---|---|---|---|
| Export | Taste | „Exportiert die aktuelle Meldeliste zur externen Auswertung.“ | Schlüsselsymbol | [RM-11](../Module/RM-11_Aktionstaste.md) (Aktion); [RM-11](../Module/RM-11_Aktionstaste.md) (Berechtigung) |
| Liste leeren | Taste | „Löscht alle gespeicherten Meldungen aus dem Archiv.“ | Schlüsselsymbol | [RM-11](../Module/RM-11_Aktionstaste.md) (Aktion); [RM-11](../Module/RM-11_Aktionstaste.md) (Berechtigung) |
| Filter | Taste | „Ermöglicht die gezielte Suche nach bestimmten Meldungen anhand von Kriterien wie Zeit oder Meldenummer.“ | kein Schlüssel | [RM-11](../Module/RM-11_Aktionstaste.md) (Aktion) |
| Alle anzeigen | Taste (im Bild „Alle Anzeigen“) | „Hebt Filtereinstellungen auf und zeigt alle verfügbaren Meldungen an.“ | kein Schlüssel | [RM-11](../Module/RM-11_Aktionstaste.md) (Aktion) |

Nur im Bild sichtbar:

| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Meldungstabelle (Zeit, Ereignis, Beschreibung) | Liste, Zeilen farbcodiert | nicht im Handbuch beschrieben; Farben wie [RS-38](RS-38_Meldeanzeige.md) (rot/gelb/grün) | [RM-21](../Module/RM-21_Meldungsliste.md) mit Farbcodierung |
| Scrolltasten (4 Stück) | Tasten | Blättern in der Liste (aus Symbolen abgeleitet) | [RM-21](../Module/RM-21_Meldungsliste.md) |
| Spalte „Ereignis“ (Wert „KO“) | Listenspalte | nicht beschrieben (vermutlich „kommend“) | [RM-21](../Module/RM-21_Meldungsliste.md) mit Farbcodierung |
| Meldezeile, Kopfzeile, Funktionsleiste unten | Rahmen | siehe [RS-35](RS-35_Systemeinstellungen.md) | [RM-02](../Module/RM-02_Meldezeile.md); [RM-01](../Module/RM-01_Kopfzeile.md); [RM-03](../Module/RM-03_Funktionsleiste-unten.md) |

## Verwendete Module (IDs)

Module dieser Seite (Definitionen in der [Modulliste](../Module/Modulliste.md)):

- [RM-01](../Module/RM-01_Kopfzeile.md) – Kopfzeile
- [RM-02](../Module/RM-02_Meldezeile.md) – Meldezeile
- [RM-03](../Module/RM-03_Funktionsleiste-unten.md) – Funktionsleiste unten
- [RM-06](../Module/RM-06_Eingabe-Pop-up.md) – Eingabe-Pop-up
- [RM-11](../Module/RM-11_Aktionstaste.md) – Aktionstaste
- [RM-21](../Module/RM-21_Meldungsliste.md) – Meldungsliste

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- Berechtigung: „Export“ und „Liste leeren“ mit Schlüsselsymbol, „Filter“ und „Alle Anzeigen“ ohne.
- Filter: Kriterien laut Handbuch „wie Zeit oder Meldenummer“; Eingabe-Pop-up nicht dokumentiert ([RM-06](../Module/RM-06_Eingabe-Pop-up.md) wäre wahrscheinlich, aber nicht belegt).
- „Alle anzeigen“ hebt Filter auf.
- „Liste leeren“ löscht alle Meldungen; Sicherheitsabfrage nicht beschrieben.
- Zeilenfarben: rot, gelb, grün (Bedeutung im Archiv nicht beschrieben; siehe RS-38: Grün Betriebsstatus Automatik, Gelb Hinweise und Statusmeldungen, Rot Störung oder sicherheitsrelevant).

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RS-37-P01 | Navigationspfad | Einstellung › Systemeinstellungen › Meldearchiv, Zugang aus RS-35 | offen |
| RS-37-P02 | Listenspalten | Zeit, Ereignis, Beschreibung | offen |
| RS-37-P03 | Zeitformat und Meldungstext | „TT.MM.JJJJ hh:mm:ss“; Beschreibung beginnt mit Meldungsnummer in Sternen, z. B. „*120* …“ | offen |
| RS-37-P04 | Zeilenfarben | Rot, Gelb, Grün je Meldungsart | offen |
| RS-37-P05 | Scrolltasten | Vier Tasten (Anfang, hoch, runter, Ende) rechts neben der Liste | offen |
| RS-37-P06 | Taste Export | Exportiert aktuelle Meldeliste zur externen Auswertung; Schlüsselsymbol | offen |
| RS-37-P07 | Taste Liste leeren | Löscht alle gespeicherten Meldungen; Schlüsselsymbol | offen |
| RS-37-P08 | Taste Filter | Suche nach Kriterien wie Zeit oder Meldenummer | offen |
| RS-37-P09 | Taste Alle anzeigen | Filter aufgehoben, alle Meldungen sichtbar | offen |
| RS-37-P10 | Untere Leiste | Schloss, Produktion, Einstellungen, Zurück; keine Taste links | offen |

## Offene Punkte
- Bedeutung der Spalte „Ereignis“ (Wert „KO“) nicht beschrieben.
- Filterdialog (Eingabeformat, Kriterien über Zeit und Meldenummer hinaus) nicht beschrieben.
- Exportformat und -ziel; Sicherheitsabfrage bei „Liste leeren“ nicht beschrieben.
- Maximale Archivgröße, Sortierung, Funktion der Scrolltasten nicht im Handbuch.
- Im Bild kein Brotkrümel; Zugang über Seitenleiste „Meldungen“ nur im Design (siehe Referenz-Übersicht).
