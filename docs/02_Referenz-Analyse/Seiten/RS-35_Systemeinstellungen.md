# RS-35 – Systemeinstellungen
- Quelle: Referenz.docx, Kapitel 35 „Systemeinstellungen“ (Zweck, Seitenübersicht, Funktionsbeschreibung, Tabelle 45); Bild [RS-35_01.png](../Medien/RS-35_01.png)   - Navigationspfad: Einstellung › Systemeinstellungen (Eintrag in [RS-04](RS-04_Einstellungen.md))

## Zweck
Wortgetreu (Handbuch): „Auf dieser Seite werden Funktionen zur Systemverwaltung bereitgestellt. Sie dienen der Steuerung der Bedienoberfläche, dem Neustart oder Ausschalten der Steuerung sowie dem Zugriff auf weiterführende Diagnoseseiten.“

## Aufbau (Bereiche, Layout)
Beschreibung von [RS-35_01.png](../Medien/RS-35_01.png) (Bildschirm 4:3, ca. 1024 × 768):
- **Kopfzeile:** links Logo „APA-TEC GmbH – Automation and Packaging Technology“; Mitte der unterstrichene Seitentitel **„Systemeinstellung“** (Singular, im Handbuch heißt das Kapitel „Systemeinstellungen“); rechts ein Symbol (schwarzes Wirbel-/Spiralsymbol, Funktion im Handbuch nicht beschrieben) und die Uhrzeit „13:05:58“ mit Datum „12.05.2025“.
- **Arbeitsbereich** (blauer Hintergrund): Raster aus 3 Spalten × 3 Zeilen grauer rechteckiger Tasten mit zentrierter Beschriftung:
  - Zeile 1: „Bedienung beenden“ (Schlüsselsymbol) · „Steuerung neu starten“ (Schlüsselsymbol) · „Steuerung ausschalten“ (Schlüsselsymbol)
  - Zeile 2: „Taskmanager“ (Schlüsselsymbol) · „Bedienung minimieren“ (Schlüsselsymbol) · (leerer Rasterplatz)
  - Zeile 3: „Service“ (Schlüsselsymbol) · „Meldearchiv“ (kein Schlüssel) · „System- und Antriebsinfo“ (dreizeilig „System- / und / Antriebsinfo“, kein Schlüssel)
  - Gelbe Schlüsselsymbole stehen in der oberen rechten Ecke der Tasten.
- **Meldezeile** (rot, volle Breite): „*450* Palettierung nicht bereit“.
- **Untere Funktionsleiste:** links Taste „Lampentest“; Mitte ein gelbes Vorhängeschloss-Symbol (geschlossen); rechts drei Tasten „Produktion“ (Haus-Symbol), „Einstellungen“ (Zahnrad-Symbol), „Zurück“ (Rückwärts-Löschen-Symbol).
- Kein Brotkrümel-Pfad im Bild sichtbar; der Pfad stammt aus der Referenz-Übersicht.

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Erfasst werden alle 8 Zeilen der Tabelle „Funktionsbeschreibung“ (Tabelle 45), Beschreibung wortgetreu; Berechtigung nach Bild.

| Element | Typ | Funktion (wortgetreu) | Berechtigung (laut Bild) | verwendetes Modul |
|---|---|---|---|---|
| Bedienung beenden | Taste (Kachel) | „Schließt die Bedienoberfläche. Die Maschine produziert weiter, Einstellungen können jedoch nicht mehr geändert werden. Start und Stopp der Anlage bleiben möglich.“ | Schlüsselsymbol | Modulkandidat: Menükachel-Taste; Modulkandidat: Taste mit Schlüsselsymbol (Berechtigung) |
| Bedienung minimieren | Taste (Kachel) | „Minimiert die HMI-Anzeige und gibt den Windows-Desktop frei.“ | Schlüsselsymbol | Modulkandidat: Menükachel-Taste; Modulkandidat: Taste mit Schlüsselsymbol (Berechtigung) |
| Taskmanager | Taste (Kachel) | „Öffnet den Windows-Taskmanager.“ | Schlüsselsymbol | Modulkandidat: Menükachel-Taste; Modulkandidat: Taste mit Schlüsselsymbol (Berechtigung) |
| Steuerung neu starten | Taste (Kachel) | „Startet die Steuerung neu. Achtung: Die Anlage wird dabei gestoppt.“ | Schlüsselsymbol | Modulkandidat: Menükachel-Taste; Modulkandidat: Taste mit Schlüsselsymbol (Berechtigung) |
| Steuerung ausschalten | Taste (Kachel) | „Fährt den IPC herunter. Achtung: Die Anlage wird dabei gestoppt. Ein Neustart erfolgt erst nach dem Wiedereinschalten der Stromversorgung über den Schalter „Steuerung ein“.“ | Schlüsselsymbol | Modulkandidat: Menükachel-Taste; Modulkandidat: Taste mit Schlüsselsymbol (Berechtigung) |
| Meldearchiv | Taste (Kachel), Navigation | „Öffnet die Seite zum Meldearchiv.“ → [RS-37](RS-37_Meldearchiv.md) | kein Schlüsselsymbol | Modulkandidat: Menükachel-Taste |
| System- und Antriebsinfo | Taste (Kachel), Navigation | „Öffnet die Diagnoseseite für System- und Antriebsinformationen.“ → [RS-39](RS-39_System-und-Antriebsinfos.md) | kein Schlüsselsymbol | Modulkandidat: Menükachel-Taste |
| Service | Taste (Kachel), Navigation | „Öffnet die Service-Seite mit erweiterten Systemfunktionen.“ → [RS-36](RS-36_Service.md) | Schlüsselsymbol | Modulkandidat: Menükachel-Taste; Modulkandidat: Taste mit Schlüsselsymbol (Berechtigung) |

Rahmenelemente (nur im Bild, nicht in der Tabelle):

| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Kopfzeile (Logo, Seitentitel, Symbol, Uhrzeit/Datum) | Rahmen | Anzeige; Funktion des Symbols nicht beschrieben | Modulkandidat: Kopfzeile |
| Meldezeile „*450* Palettierung nicht bereit“ | Anzeige/Taste | Öffnet laut [RS-38](RS-38_Meldeanzeige.md) durch Antippen die Meldeanzeige | Modulkandidat: Meldezeile |
| Taste „Lampentest“ | Taste | im Handbuch nicht beschrieben | Modulkandidat: Funktionsleiste unten |
| Vorhängeschloss-Symbol | Symbol | im Handbuch nicht beschrieben (vermutlich Anmeldestatus) | Modulkandidat: Funktionsleiste unten |
| Tasten „Produktion“, „Einstellungen“, „Zurück“ | Navigation | Wechsel zur Startseite / zu [RS-04](RS-04_Einstellungen.md) / eine Ebene zurück (Bedeutung aus Beschriftung und Symbol, im Handbuch für diese Seite nicht beschrieben) | Modulkandidat: Funktionsleiste unten |

## Verwendete Module (IDs)
Noch keine RM-IDs vergeben. Modulkandidaten: Menükachel-Taste, Taste mit Schlüsselsymbol (Berechtigung), Kopfzeile, Meldezeile, Funktionsleiste unten.

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- Berechtigungen: Fünf Tasten plus „Service“ tragen ein gelbes Schlüsselsymbol (Bedienung beenden, Steuerung neu starten, Steuerung ausschalten, Taskmanager, Bedienung minimieren, Service). „Meldearchiv“ und „System- und Antriebsinfo“ haben keines. Das Handbuch nennt weder Benutzerstufe noch Anmeldeverfahren.
- Warnhinweise im Text: „Steuerung neu starten“ und „Steuerung ausschalten“ stoppen die Anlage („Achtung“). Eine Sicherheitsabfrage (Bestätigungs-Pop-up) ist weder im Handbuch noch im Bild beschrieben.
- „Bedienung beenden“: Maschine produziert weiter; Einstellungen nicht mehr änderbar; Start/Stopp bleibt möglich.
- „Steuerung ausschalten“: Neustart nur über Wiedereinschalten der Stromversorgung mit dem Schalter „Steuerung ein“.
- Navigation: Meldearchiv → RS-37, System- und Antriebsinfo → RS-39, Service → RS-36. Rückweg über „Zurück“ bzw. „Einstellungen“ (Bild).
- Pop-ups: keine beschrieben.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RS-35-P01 | Brotkrümel/Navigationspfad der Seite | Einstellung › Systemeinstellungen, erreichbar aus RS-04 | offen |
| RS-35-P02 | Anzahl und Beschriftung der Funktionstasten | 8 Tasten: Bedienung beenden, Steuerung neu starten, Steuerung ausschalten, Taskmanager, Bedienung minimieren, Service, Meldearchiv, System- und Antriebsinfo | offen |
| RS-35-P03 | Rasteranordnung gemäß Bild | 3 × 3 Raster, Rasterplatz Zeile 2 / Spalte 3 leer | offen |
| RS-35-P04 | Schlüsselsymbole | 6 Tasten mit Schlüssel (alle außer Meldearchiv und System- und Antriebsinfo) | offen |
| RS-35-P05 | Bedienung beenden | Bedienoberfläche schließt, Maschine produziert weiter, Start/Stopp möglich, Einstellungen nicht änderbar | offen |
| RS-35-P06 | Bedienung minimieren | HMI minimiert, Windows-Desktop frei | offen |
| RS-35-P07 | Taskmanager | Windows-Taskmanager öffnet | offen |
| RS-35-P08 | Steuerung neu starten | Steuerung startet neu, Anlage wird gestoppt | offen |
| RS-35-P09 | Steuerung ausschalten | IPC fährt herunter, Anlage gestoppt, Neustart nur nach Wiedereinschalten über Schalter „Steuerung ein“ | offen |
| RS-35-P10 | Navigation Meldearchiv | Öffnet RS-37 | offen |
| RS-35-P11 | Navigation System- und Antriebsinfo | Öffnet RS-39 | offen |
| RS-35-P12 | Navigation Service | Öffnet RS-36 | offen |
| RS-35-P13 | Rahmen laut Bild | Kopfzeile mit Titel, Uhrzeit, Datum; Meldezeile; untere Leiste mit Lampentest, Schloss, Produktion, Einstellungen, Zurück | offen |

## Offene Punkte
- Seitentitel im Bild „Systemeinstellung“, Kapitel „Systemeinstellungen“.
- Erforderliche Berechtigungsstufe der 6 Schlüssel-Tasten nicht beschrieben.
- Kein Bestätigungsdialog für „Steuerung neu starten/ausschalten/Bedienung beenden“ beschrieben; Wiederaufruf der Bedienung nach „Bedienung beenden“ nicht beschrieben.
- Funktion von „Lampentest“, Vorhängeschloss-Symbol und Kopfzeilen-Symbol nicht beschrieben.
- Schalter „Steuerung ein“ ist ein physischer Schalter, nicht Teil des HMI.
- Leerer Rasterplatz (Zeile 2, Spalte 3): ungenutzt oder reserviert?
