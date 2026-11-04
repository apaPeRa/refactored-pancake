# Navigation – Struktur, Brotkrümel und Navigationsdienst

Phase 3, Meilenstein 1. Grundlage: [Referenz-Uebersicht.md](../02_Referenz-Analyse/Referenz-Uebersicht.md) (Navigationsbaum), die Seiten [RS-01](../02_Referenz-Analyse/Seiten/RS-01_Produktion.md) bis [RS-39](../02_Referenz-Analyse/Seiten/RS-39_System-und-Antriebsinfos.md), [Design-Dokumentation.md](../01_Design-Analyse/Design-Dokumentation.md) (Abschnitte 2 und 7) und die Seiten DS-01 bis DS-05. Regel (Agent.md Abschnitt 2): **Funktion und Zugänge** folgen der Referenz, **Aufbau der Rahmennavigation und Beschriftung** folgt dem Design. Alle Annahmen stehen in [Annahmen.md](../00_Plan/Annahmen.md) (A-33 ff.), Lücken in Abschnitt 6.

## 0. Grundsätze

1. **Zwei Ebenen.** Rahmennavigation (Seitenleiste, Brotkrümel, Funktionsleiste unten, Meldezeile) ist auf jeder Seite gleich aufgebaut. Seiteninhalt (Kacheln, Tasten) führt in die Tiefe.
2. **Seiten-IDs.** Jede der 39 Referenzseiten `RS-xx` hat die neue Seite `HS-xx` mit gleicher Nummer; Dateiname `HS-xx_<Name>.md` mit dem Namensteil der RS-Datei. Vier Zusatzseiten ohne RS-Entsprechung (HS-40 bis HS-43, Annahme A-33) schließen Lücken des Designs.
3. **Der Brotkrümel ist der kanonische Pfad der Seite**, nicht der Verlauf. Eine Seite hat genau einen Brotkrümel, auch wenn sie von mehreren Stellen erreichbar ist (A-34).
4. **„Zurück“ geht im Verlauf zurück**, nicht im Brotkrümel nach oben (A-42). Wer den Elternpfad will, tippt auf ein Brotkrümel-Segment.
5. **Schloss und untere Rahmentasten der Referenz** („Produktion“, „Einstellungen“, „Zurück“, Schloss) wandern in die Seitenleiste des Designs; die untere Funktionsleiste enthält nur seitenspezifische Tasten (A-35).
6. Navigation ändert keinen Maschinenzustand. Kein Seitenwechsel startet, stoppt oder bestätigt eine Funktion.

## 1. Navigationsstruktur (Baum)

Legende: `[Zugang]` = Element, das die Seite öffnet. `(Pop-up)` = modal, nicht im Verlauf. `(Z)` = Zusatzseite ohne RS (A-33). `(abgeleitet)` = im Handbuch nicht ausdrücklich beschrieben. Rücksprung überall: Seitenleiste „Zurück“ (Verlauf), bei Pop-ups „Schließen“.

```
Rahmen (auf jeder Seite)
├─ Seitenleiste „Home“ ................ HS-01 Produktion (Stapel `[]`)
├─ Seitenleiste „Einstellungen“ ....... HS-04 Einstellungen (Stapel `[HS-01]`)
├─ Seitenleiste „Meldungen“ ........... HS-38 Meldeanzeige (OP-08, A-35)
├─ Meldezeile antippen ................ HS-38 Meldeanzeige (Handbuch RS-38)
├─ Seitenleiste „Zurück“ .............. vorherige Seite im Verlauf
├─ Benutzerkreis „MM“ ................. Benutzer-Pop-up (Anmelden/Abmelden, A-35)
└─ Kennzahl „Geschwindigkeit“ ......... HS-03 Maschinengeschwindigkeit (Pop-up, A-38)

HS-01 Produktion (Startseite, Home)
├─ [Symbol „Aktuelle Produktion“] ..... HS-02 Produktionszähler (Pop-up)
├─ [Tacho-Symbol „Geschw. Soll“ (Referenz: rot)]  HS-03 Maschinengeschwindigkeit (Pop-up)
├─ [Funktionsleiste „Schichtplan“] .... HS-43 Schichtplan (Z, Platzhalter, OP-02)
└─ [Feld „Rezept“] .................... Rezeptauswahl-Pop-up (Platzhalter, OP-01)

HS-04 Einstellungen
├─ [Kachel „Zuführungen“] ............. HS-40 Zuführungen (Z)
│  ├─ [Kachel „Papier“] ............... HS-05 Zuführung Papier
│  ├─ [Kachel „Karton“] ............... HS-06 Zuführung Karton
│  │   └─ [Taste „Heißleimgerät“] ..... HS-07 (zweiter Zugang, Handbuch RS-06)
│  └─ [Kachel „Heißleim“] ............. HS-07 Heißleim Nordson
│      ├─ [Taste „Temperatur“] ........ HS-08 Heißleim Parameter   (abgeleitet)
│      ├─ [Taste „Druck“] ............. HS-09 Heißleim Druck       (abgeleitet)
│      └─ [Taste „Zeitplan“] .......... HS-10 Zeitschaltuhr        (abgeleitet)
│          └─ [Eintrag / Plus-Taste] .. Zeitplan-Eintrag-Pop-up (RM-27)
├─ [Kachel „Schließmaschine“] ......... HS-16 Schließmaschine
│  ├─ [Taste „Heißleimgerät“] ......... HS-07 (A-37, Sprungziel im Handbuch nicht belegt)
│  ├─ [Taste „Motorparameter“] ........ HS-17 Motorparameter Schließmaschine (A-37)
│  └─ [Taste „Gewichtskorrektur“] ..... HS-18 Gewichtskorrektur Schließmaschine (A-37)
├─ [Kachel „Dosierer“] ................ HS-41 Dosierer-Übersicht (Z, Design DS-04)
│  ├─ [Symbol „Detail“ in Karte HD 1/2]  HS-11 Hauptdosierer 1 & 2 (Pfeiltasten: HD 1 ⇄ HD 2)
│  │   ├─ [Taste „Motorparameter“] .... HS-12 Motorparameter (aktueller Dosierer)
│  │   └─ [Taste „Regulierung“] ....... HS-23 Regulierung
│  └─ [Symbol „Detail“ in Karte ND] ... HS-19 Nachdosierer
│      ├─ [Taste „Gewichtskorrektur“] . HS-21 Gewichtskorrektur
│      ├─ [Taste „Motorparameter“] .... HS-20 Motorparameter
│      └─ [Taste „Regulierung“] ....... HS-23 Regulierung
├─ [Kachel „Waagen“] .................. HS-42 Waagen (Z)
│  ├─ [Kachel „Kontrollwaage“] ........ HS-13 Kontrollwaage
│  │   ├─ [Taste „Einzelgewichte“] .... HS-14 Einzelgewichte
│  │   └─ [Taste „Trend“] ............. HS-15 Trend
│  ├─ [Kachel „Endkontrollwaage“] ..... Platzhalter, deaktiviert (Lücke, OP-24)
│  └─ [Kachel „Waagen kalibrieren“] ... HS-27 Waagen Kalibrieren (Pfeiltasten: Waage ⇄ Waage)
├─ [Kachel „Heizungen“] ............... HS-22 Heizungen
├─ [Kachel „Regulierung“] ............. HS-23 Regulierung
├─ [Kachel „Bildschirm reinigen“] ..... HS-24 Bildschirm reinigen (Vollbild, schließt selbst)
├─ [Kachel „Nockenschaltwerk“] ........ HS-25 Nocken ⇄ [Taste „Übersicht“] HS-26 Nockenübersicht
├─ [Kachel „Packungsregister“] ........ HS-28 Packungsregister
├─ [Kachel „Produktionsstatistik“] .... HS-29 Produktionsstatistik
├─ [Kachel „Handbetrieb“] ............. HS-30 Handbetrieb Auswahl
│  └─ [Gruppentaste GRxx] ............. HS-31 Handbetrieb (abgeleitet)
├─ [Kachel „Geber setzen“] ............ HS-32 Geber setzen
├─ [Kachel „EA Übersicht“] ............ HS-33 EA-Übersicht
│  └─ [Taste „Eingänge/Ausgänge Sx“] .. HS-34 EA-Anzeige (abgeleitet)
├─ [Kachel „Systemeinstellungen“] ..... HS-35 Systemeinstellungen
│  ├─ [Taste „Service“] ............... HS-36 Service (berechtigungspflichtig)
│  ├─ [Taste „Meldearchiv“] ........... HS-37 Meldearchiv
│  └─ [Taste „System- und Antriebsinfo“] HS-39 System- und Antriebsinfos
├─ [Kachel „Geräte“] .................. reserviert, ohne Ziel (OP-05)
├─ [Schnellzugriff „Beleuchtung“] ..... Aktion Maschinenbeleuchtung, keine Navigation (A-36)
└─ [Funktionsleiste „Sprache“] ........ Sprachwahl-Pop-up (OP-03)

HS-38 Meldeanzeige (jede Seite über Meldezeile / Seitenleiste „Meldungen“)
└─ [Funktionsleiste „Archiv“] ......... HS-37 Meldearchiv (Annahme des Handbuchs, RS-38)
```

**Querzugänge** (zusätzlich zum Baum):

| Ziel | weiterer Zugang | Quelle |
|---|---|---|
| HS-07 | HS-06 Taste „Heißleimgerät“; HS-16 Taste „Heißleimgerät“ | Handbuch (RS-06); RS-16 nur im Bild |
| HS-23 | HS-11 und HS-19 Taste „Regulierung“ | Handbuch (RS-11, RS-19) |
| HS-26 ⇄ HS-25 | Nockennummer in der Übersicht führt zurück zur Nocken-Seite dieser Nocke | Handbuch (RS-26) |
| HS-37 | HS-38 Taste „Archiv“ | Handbuch (angenommen), Bild RS-38 |
| HS-31, HS-34 | Such-Pop-up von HS-30/HS-31/HS-33: Treffer öffnet direkt die Aktor- bzw. EA-Seite | Handbuch (Suche), Zielseite abgeleitet (A-39) |
| HS-22, HS-05, HS-06 | **kein** Zugang aus HS-01: die Tasten „Heizungen“, „Zuführung Papier“, „Zuführung Karton“ in HS-01 aktivieren die Funktion, sie navigieren nicht | A-38 |

## 2. Brotkrümel-Pfad je Seite

Brotkrümel-Regeln (A-34): Wurzel „Einstellung“ (Design, Singular) bzw. „Produktion“. Segmentbeschriftung nach dem Design, soweit vorhanden („Zuführungen“, „Heißleim“, „Dosierer“, „Zeitplan“); sonst Seitenname der Referenz. Segmente für Seiten ohne eigene Seite (z. B. „Nocken“ in `Nockenschaltwerk › Nocken`) entfallen; das Segment „Nockenschaltwerk“ führt dann auf HS-25. Alle Segmente außer dem letzten sind antippbar und öffnen die jeweilige Seite (Verlauf wird dabei bis dorthin gekürzt, Abschnitt 5). Maximale Tiefe 4 Segmente. Spalte „Quelle“: Handbuch = Zugang ausdrücklich beschrieben; Design = Brotkrümel/Zugang aus Design-Screenshot; abgeleitet = nicht belegt, Annahme.

| HS-ID | Seitenname | Brotkrümel | Zugang | Zurück-Ziel | Quelle |
|---|---|---|---|---|---|
| HS-01 | Produktion | Produktion | Seitenleiste „Home“; Startseite nach Anmeldung | – (Wurzel; „Zurück“ ist deaktiviert) | Design (DS-01), Handbuch |
| HS-02 | Produktionszähler | Produktion (Brotkrümel bleibt; Pop-up-Titel „Produktionszähler“) | HS-01: Symbol bei „Aktuelle Produktion“ | HS-01 (Pop-up schließen: „Schließen“ oder Kreuz) | Handbuch (RS-02) |
| HS-03 | Maschinengeschwindigkeit | Produktion (Brotkrümel bleibt; Pop-up-Titel „Maschinengeschwindigkeit“) | HS-01: Tacho-Symbol am Feld „Geschwindigkeit Soll“ (in der Referenz rot); Kennzahl-Kachel „Geschwindigkeit“ im Rahmen (Annahme) | Aufrufende Seite (Pop-up schließen) | Handbuch (RS-03); Kennzahl abgeleitet (A-38) |
| HS-04 | Einstellungen | Einstellung | Seitenleiste „Einstellungen“ | Verlauf, sonst HS-01 | Design (DS-02), Handbuch |
| HS-05 | Zuführung Papier | Einstellung › Zuführungen › Papier | HS-40: Kachel „Papier“ | HS-40 (Verlauf) | abgeleitet (Muster DS-03/DS-05; Handbuch: Eintrag in RS-04) |
| HS-06 | Zuführung Karton | Einstellung › Zuführungen › Karton | HS-40: Kachel „Karton“ | HS-40 (Verlauf) | Design (DS-05), Handbuch |
| HS-07 | Heißleim Nordson | Einstellung › Zuführungen › Heißleim | HS-40: Kachel „Heißleim“; HS-06 und HS-16: Taste „Heißleimgerät“ | Verlauf (HS-40, HS-06 oder HS-16) | Design (DS-03), Handbuch (RS-06) |
| HS-08 | Heißleim Parameter | Einstellung › Zuführungen › Heißleim › Temperatur | HS-07: Funktionsleiste „Temperatur“ | HS-07 | abgeleitet (Design-Funktionsleiste, A-14) |
| HS-09 | Heißleim Druck | Einstellung › Zuführungen › Heißleim › Druck | HS-07: Funktionsleiste „Druck“ | HS-07 | abgeleitet (Design-Funktionsleiste, A-14) |
| HS-10 | Zeitschaltuhr | Einstellung › Zuführungen › Heißleim › Zeitplan | HS-07: Funktionsleiste „Zeitplan“ (nicht die grüne Taste „Zeitplan“ im Arbeitsbereich: diese aktiviert nur den Zeitplan) | HS-07 | abgeleitet (Design-Funktionsleiste, A-14, OP-14) |
| HS-11 | Hauptdosierer 1 & 2 | Einstellung › Dosierer › Hauptdosierer | HS-41: Detail-Symbol in Karte Hauptdosierer 1 oder 2 (Parameter `doserIndex`); Pfeiltasten wechseln HD 1 ⇄ HD 2 | HS-41 | Handbuch (RS-11), Design (DS-04) |
| HS-12 | Motorparameter | Einstellung › Dosierer › Hauptdosierer › Motorparameter | HS-11: Funktionsleiste „Motorparameter“ (für den aktuellen Dosierer) | HS-11 | Handbuch (RS-12) |
| HS-13 | Kontrollwaage | Einstellung › Waagen › Kontrollwaage | HS-42: Kachel „Kontrollwaage“ | HS-42 | Handbuch (RS-13), Design (Kachel „Waagen“) |
| HS-14 | Einzelgewichte | Einstellung › Waagen › Kontrollwaage › Einzelgewichte | HS-13: Funktionsleiste „Einzelgewichte“ | HS-13 | Handbuch (RS-14) |
| HS-15 | Trend | Einstellung › Waagen › Kontrollwaage › Trend | HS-13: Funktionsleiste „Trend“ | HS-13 | Handbuch (RS-15) |
| HS-16 | Schließmaschine | Einstellung › Schließmaschine | HS-04: Kachel „Schließmaschine“ | HS-04 (Verlauf) | Design (DS-02), Handbuch |
| HS-17 | Motorparameter Schließmaschine | Einstellung › Schließmaschine › Motorparameter | HS-16: Funktionsleiste „Motorparameter“ (Annahme, Lücke 6.2) | HS-16 | abgeleitet (A-11, A-37) |
| HS-18 | Gewichtskorrektur Schließmaschine | Einstellung › Schließmaschine › Gewichtskorrektur | HS-16: Funktionsleiste „Gewichtskorrektur“ (Annahme, Lücke 6.2) | HS-16 | abgeleitet (A-11, A-37) |
| HS-19 | Nachdosierer | Einstellung › Dosierer › Nachdosierer | HS-41: Detail-Symbol in Karte Nachdosierer | HS-41 | Handbuch (RS-19), Design (DS-04) |
| HS-20 | Motorparameter | Einstellung › Dosierer › Nachdosierer › Motorparameter | HS-19: Funktionsleiste „Motorparameter“ | HS-19 | Handbuch (RS-20) |
| HS-21 | Gewichtskorrektur | Einstellung › Dosierer › Nachdosierer › Gewichtskorrektur | HS-19: Funktionsleiste „Gewichtskorrektur“ | HS-19 | Handbuch (RS-21) |
| HS-22 | Heizungen | Einstellung › Heizungen | HS-04: Kachel „Heizungen“ | HS-04 (Verlauf) | Design (DS-02), Handbuch |
| HS-23 | Regulierung | Einstellung › Regulierung | HS-04: Kachel „Regulierung“ (belegt einen der leeren Plätze, A-36); HS-11 und HS-19: Taste „Regulierung“ | Verlauf (HS-04, HS-11 oder HS-19) | Handbuch (RS-23) |
| HS-24 | Bildschirm reinigen | Einstellung › Bildschirm reinigen (Brotkrümel wird ausgeblendet, Vollbild ohne Rahmen) | HS-04: Kachel „Bildschirm reinigen“ | HS-04; Seite schließt nach Ablauf selbst | Handbuch (RS-24), Design (DS-02) |
| HS-25 | Nocken | Einstellung › Nockenschaltwerk | HS-04: Kachel „Nockenschaltwerk“; HS-26: Nockennummer antippen | HS-04 (Verlauf) | Handbuch (RS-25), Design (DS-02) |
| HS-26 | Nockenübersicht | Einstellung › Nockenschaltwerk › Übersicht | HS-25: Funktionsleiste „Übersicht“ | HS-25 | Handbuch (RS-26) |
| HS-27 | Waagen Kalibrieren | Einstellung › Waagen › Waagen kalibrieren | HS-42: Kachel „Waagen kalibrieren“ | HS-42 | Handbuch (RS-27), Design (Kachel „Waagen“) |
| HS-28 | Packungsregister | Einstellung › Packungsregister | HS-04: Kachel „Packungsregister“ | HS-04 (Verlauf) | Design (DS-02), Handbuch |
| HS-29 | Produktionsstatistik | Einstellung › Produktionsstatistik | HS-04: Kachel „Produktionsstatistik“ (belegt einen leeren Platz, A-36) | HS-04 (Verlauf) | Handbuch (RS-29) |
| HS-30 | Handbetrieb Auswahl | Einstellung › Handbetrieb | HS-04: Kachel „Handbetrieb“ | HS-04 (Verlauf) | Design (DS-02), Handbuch |
| HS-31 | Handbetrieb | Einstellung › Handbetrieb › `<Gruppe>` (Beispiel „GR20 Schließmaschine“) | HS-30: Gruppentaste GRxx (Parameter `groupId`); Such-Pop-up: Treffer | HS-30 | abgeleitet (A-14, A-39) |
| HS-32 | Geber setzen | Einstellung › Geber setzen | HS-04: Kachel „Geber setzen“ (belegt einen leeren Platz, A-36) | HS-04 (Verlauf) | Handbuch (RS-32) |
| HS-33 | EA-Übersicht | Einstellung › EA-Übersicht | HS-04: Kachel „EA Übersicht“ | HS-04 (Verlauf) | Design (DS-02), Handbuch |
| HS-34 | EA-Anzeige | Einstellung › EA-Übersicht › `<Karte>` (Beispiel „Eingänge S1“) | HS-33: Taste „Eingänge/Ausgänge S1, S300, S500“ (Parameter `cardGroup`); Such-Pop-up: Treffer | HS-33 | abgeleitet (A-14, A-39) |
| HS-35 | Systemeinstellungen | Einstellung › Systemeinstellungen | HS-04: Kachel „Systemeinstellungen“ | HS-04 (Verlauf) | Design (DS-02), Handbuch |
| HS-36 | Service | Einstellung › Systemeinstellungen › Service | HS-35: Taste „Service“ (Schlüsselsymbol, Mindestrolle Technik) | HS-35 | Handbuch (RS-36) |
| HS-37 | Meldearchiv | Einstellung › Systemeinstellungen › Meldearchiv | HS-35: Taste „Meldearchiv“; HS-38: Funktionsleiste „Archiv“ | Verlauf (HS-35 oder HS-38) | Handbuch (RS-37) |
| HS-38 | Meldeanzeige | Meldungen | Meldezeile (jede Seite); Seitenleiste „Meldungen“ | Aufrufende Seite (Verlauf) | Handbuch (RS-38), Design (Seitenleiste, OP-08) |
| HS-39 | System- und Antriebsinfos | Einstellung › Systemeinstellungen › System- und Antriebsinfo | HS-35: Taste „System- und Antriebsinfo“ | HS-35 | Handbuch (RS-39) |
| HS-40 | Zuführungen (Z) | Einstellung › Zuführungen | HS-04: Kachel „Zuführungen“ | HS-04 | Design (Brotkrümel DS-03/DS-05, Kachel DS-02) |
| HS-41 | Dosierer-Übersicht (Z) | Einstellung › Dosierer | HS-04: Kachel „Dosierer“ | HS-04 | Design (DS-04, Kachel DS-02) |
| HS-42 | Waagen (Z) | Einstellung › Waagen | HS-04: Kachel „Waagen“ | HS-04 | Design (Kachel „Waagen“, DS-02), Gruppierung abgeleitet (A-36) |
| HS-43 | Schichtplan (Z) | Produktion › Schichtplan | HS-01: Funktionsleiste „Schichtplan“ | HS-01 | Design (DS-01), Platzhalter (OP-02) |

Hinweise zur Tabelle:

- **Antippbarkeit der Segmente** (OP-21) ist Annahme. Das letzte Segment ist nur Anzeige. „Einstellung“ führt immer auf HS-04, „Produktion“ auf HS-01.
- **Objektkennung im Brotkrümel (einheitlich):** Dynamische Segmente (HS-31 Gruppe, HS-34 Karte) ersetzen das letzte Segment durch den Namen des gewählten Objekts. Eine Objektkennung als Zusatz am Seitensegment (`ObjectSuffix`) tragen HS-11 („1“/„2“), HS-12 („HD1“/„HD2") und HS-20 („ND“). HS-25 (Nockennummer) und HS-27 (Waagenname, nur in der Titelzeile [HM-17](Module/HM-17_Titelzeile.md), K27-7) haben ein statisches Segment. Der Brotkrümel ändert sich beim Blättern nur bei HS-11, HS-12, HS-31 und HS-34.
- **Dynamische Segmente** (HS-31, HS-34) zeigen den Namen des gewählten Objekts; Quelle ist der Seitentitel im Bild (RS-31: Gruppe, RS-34: „Eingänge S1“). Beim Blättern (Funktionsleisten-Tasten: HS-11, HS-12, HS-25, HS-26, HS-27, HS-34; Tasten im Inhaltsbereich: HS-29, HS-31, HS-32) ändert sich nur das letzte Segment bzw. der Seitentitel, der Verlauf bekommt keinen neuen Eintrag (Abschnitt 5).
- **Zeitplan/Zeitschaltuhr, Temperatur/Parameter:** Brotkrümel und Funktionstaste tragen die Beschriftung aus dem Design („Zeitplan“, „Temperatur“, „Druck“); der Seitentitel (Fenster- und Automationsname) folgt dem Kapitelnamen der Referenz (OP-33): „Heißleim Nordson“ (HS-07), „Heißleim Parameter“ (HS-08), „Heißleim Druck“ (HS-09), „Zeitschaltuhr“ (HS-10). Die Bildtitel („Heißleim Zuführung Druck“, „Zeitschaltuhr Zuführung“) werden nicht übernommen und stehen in HS-09 und HS-10 nur als Hinweis (OP-33).
- **HS-02/HS-03** sind Pop-ups und haben keinen eigenen Brotkrümel; der Brotkrümel der Hintergrundseite bleibt stehen. Der Pfad der Referenz („Produktion › Produktionszähler“) entspricht dem Pop-up-Titel.
- **HS-38 „Meldungen“:** Die Referenz nennt den Pfad „Meldezeile (jede Seite) › Meldeanzeige“; die Meldeanzeige ist Querseite zu jeder Seite und hat im neuen HMI zwei Zugänge (Meldezeile, Seitenleiste), daher steht kein Elternsegment davor und das einzige Segment ist der Seitenleisten-Begriff „Meldungen“ (A-35).
- **HS-14 „Einzelgewichte“:** Die Referenz-Übersicht schreibt „Einzelgewicht“, der Seitenname und die Taste im Handbuchbild heißen „Einzelgewichte“ (Titel im Bild „Einzelgewichte KW“); der Brotkrümel folgt der Taste und dem Seitennamen.
- **HS-24** blendet nach Referenz Meldezeile und Funktionsleiste aus (Bild ohne Rahmen); die Seitenleiste ist ebenfalls ausgeblendet (Vollbild ohne Rahmen, A-42); die Seite endet nach Ablauf selbst.

## 3. Rahmennavigation

### 3.1 Seitenleiste

Aufbau von oben nach unten ([DM-01](../01_Design-Analyse/Module/DM-01_Benutzerkennung.md), [DM-02](../01_Design-Analyse/Module/DM-02_Navigationsleiste.md)); Symbolbedeutung nach A-07 und A-35.

| Position | Element | Aktion | Ziel / Regel | Aktiv auf | Quelle |
|---|---|---|---|---|---|
| 1 | Benutzerkreis „MM“, Name, Rolle | Antippen öffnet Benutzer-Pop-up (Anmelden, Abmelden, Rolle anzeigen) | ersetzt das gelbe Schloss der Referenz; berechtigungspflichtige Felder lösen bei fehlender Rolle dasselbe Pop-up aus | alle Seiten außer HS-24 | Design, Referenz (Schloss), OP-04 |
| 2 | Home (Haus) | Navigation | HS-01; Verlauf wird auf `[]` zurückgesetzt. Auf HS-01 selbst: hervorgehoben, ohne Wirkung | alle außer HS-24 | Design, Referenz (Taste „Produktion“) |
| 3 | Einstellungen (Zahnrad) | Navigation | HS-04; Verlauf wird auf `[HS-01]` gesetzt (Stapel ohne aktuelle Seite). Auf HS-04 hervorgehoben | alle außer HS-24 | Design, Referenz (Taste „Einstellungen“) |
| 4 | Meldungen (Sprechblase „!“) | Navigation | HS-38; Verlauf: Seite bleibt unten im Stapel. Hervorgehoben, wenn Meldungen anstehen (zusätzlich Zahl/Symbol, nicht nur Farbe) | alle außer HS-24 | Design, OP-08 |
| 5 | Zurück (Rücktaste) | Verlauf | oberster Stapeleintrag; deaktiviert auf HS-01 (leerer Stapel) | alle außer HS-24 | Design, Referenz (Taste „Zurück“) |

Die hervorgehobene Taste zeigt die Hauptgruppe der aktuellen Seite: Home auf HS-01, HS-02, HS-03, HS-43; Einstellungen auf allen Seiten unter „Einstellung“; Meldungen auf HS-38. Modal (Pop-up offen): Seitenleiste gesperrt (Abschnitt 4).

### 3.2 Weitere Rahmenelemente mit Navigationsfunktion

| Element | Verhalten |
|---|---|
| Meldezeile ([DM-04](../01_Design-Analyse/Module/DM-04_Meldezeile.md)) | Antippen öffnet HS-38 (Handbuch RS-38). Auf HS-38 selbst ohne Wirkung; auf HS-24 ausgeblendet |
| Kennzahl „Geschwindigkeit“ | öffnet HS-03 (Pop-up, A-38); „Maschinenwinkel“ nur Anzeige |
| Betriebsart-Anzeige, Uhrzeit, Logo | nur Anzeige |
| Brotkrümel | siehe Abschnitt 2 |

### 3.3 Untere Funktionsleiste je Seitentyp

Die Leiste ([DM-09](../01_Design-Analyse/Module/DM-09_Funktionsleiste.md)) enthält nur seitenspezifische Tasten, links beginnend ([DM-10](../01_Design-Analyse/Module/DM-10_Funktionstaste-grau.md) bzw. Zustandstaste [DM-19](../01_Design-Analyse/Module/DM-19_Zustandstaste.md)). Die Referenz-Tasten „Produktion“, „Einstellungen“, „Zurück“ und das Schloss entfallen dort (A-35). Auf Seiten ohne eigene Tasten bleibt die Leiste leer, aber sichtbar (Design: leere Leiste auf DS-04, DS-05).

| Seitentyp | Seiten | Tasten der Funktionsleiste (links nach rechts) | Quelle |
|---|---|---|---|
| Kachelmenü / Zwischenseite | HS-40, HS-42 | keine | Design (DS-04: leer), abgeleitet |
| Kachelmenü Einstellungen | HS-04 | „Sprache“ (Pop-up) | Design (DS-02) |
| Produktion | HS-01 | „Schichtplan“ (→ HS-43) | Design (DS-01) |
| Pop-up | HS-02, HS-03 | im Pop-up: „Reset“ (nur HS-02), „Schließen“ | Handbuch (RS-02, RS-03); Funktionsleiste der Seite dahinter gesperrt |
| Unterseiten-Navigation | HS-06: „Heißleimgerät“ · HS-07: „Temperatur“, „Druck“, „Zeitplan“ · HS-13: „Trend“, „Einzelgewichte“ · HS-16: „Heißleimgerät“, „Motorparameter“, „Gewichtskorrektur“ · HS-19: „Gewichtskorrektur“, „Motorparameter“, „Regulierung“ | siehe Spalte Seitentyp; Reihenfolge wie im Handbuchbild, Ergänzungen in HS-16 nach A-37 | Handbuch (Bilder), Design (DS-03) |
| Blättern innerhalb eines Satzes | HS-11: „«“, „»“ (HD 1 ⇄ HD 2) und „Motorparameter“; die Taste „Einstellung Regulierung“ (→ HS-23) liegt wie in der Referenz im Inhaltsbereich · HS-12: „«“, „»“ (HD 1 ⇄ HD 2, Annahme; das Handbuch zeigt nur „»“) · HS-25: „«“, „Übersicht“, „»“ · HS-26: „«“, „»“ · HS-27: „«“, „»“ (Waagen) · HS-34: „«“, „»“ (EA-Karten) | Blättertasten ([RM-04](../02_Referenz-Analyse/Module/RM-04_Blaettertasten.md)); ändern nur den Parameter der Seite, erzeugen keinen Verlaufseintrag | Handbuch (T16, T35, T38, T44), Bilder |
| Blättern im Inhaltsbereich (nicht in der Funktionsleiste) | HS-29: Pfeiltasten über dem Diagramm (Tag) · HS-31: „«“, „»“ im unteren Bereich (Aktor, A-39) · HS-32: „«“, „»“ (Geber) | wie oben: `ReplaceParameter`, kein Verlaufseintrag | Handbuch (RS-29, RS-31 T41, RS-32 T42) |
| Suche | HS-30, HS-31, HS-33 | „Suchen“ (öffnet Such-Pop-up: Betriebsmittelkennzeichnung) | Handbuch (T40, T43) |
| Aktion / Zustand | HS-14: Umschalter „Einzel / Fortlaufend“ (Zustandstaste) und „Start“ · HS-35: „Lampentest“ · HS-36: „Wago“ (Funktion im Handbuch nicht beschrieben) · HS-38: „Archiv“ (→ HS-37) | Aktionstasten lösen keine Navigation aus, außer „Archiv“ | Handbuch (Bilder), RS-14 (Start „vermutlich“ unten links) |
| Ohne eigene Tasten | HS-05, HS-08, HS-09, HS-10, HS-15, HS-17, HS-18, HS-20, HS-21, HS-22, HS-23, HS-28, HS-37, HS-39, HS-41, HS-43 | keine | Handbuch (Bilder), Design (DS-04/DS-05); HS-17 und HS-20 zeigen im Bild (identisch zu RS-12) ein „»“; das Blättern HD 1 ⇄ HD 2 gibt es nur in HS-11/HS-12, es gibt nur einen Nachdosierer und keine Schließmaschinen-Dosierer, daher entfällt es in HS-17 und HS-20 (A-37, A-44) |
| Vollbild | HS-24 | keine; Seitenleiste, Brotkrümel, Meldezeile und Funktionsleiste ausgeblendet | Handbuch (RS-24) |

Leistenregeln: höchstens 5 seitenspezifische Tasten, Mindestgröße der Tasten nach [Designsystem.md](Designsystem.md); gesperrte Tasten bleiben sichtbar (Symbol oder Text für den Zustand, nicht nur Farbe).

## 4. Pop-ups und modale Regeln

### 4.1 Pop-up-Inventar

| Pop-up | Modul | Öffnet von | Schließen | Berechtigung |
|---|---|---|---|---|
| HS-02 Produktionszähler | [RM-13](../02_Referenz-Analyse/Module/RM-13_Pop-up-Rahmen.md) | HS-01 Symbol „Aktuelle Produktion“ | „Schließen“, Kreuz | „Reset“ je nach Schlüsselsymbol der Seite |
| HS-03 Maschinengeschwindigkeit | RM-13 | HS-01 Tacho-Symbol (Referenz: rot); Kennzahl „Geschwindigkeit“ (A-38) | „Schließen“, Kreuz | Eingabefelder (RM-05) |
| Zeitplan-Eintrag („Neuer Eintrag“) | [RM-27](../02_Referenz-Analyse/Module/RM-27_Zeitplan-Eintrag-Pop-up.md) | HS-10: Plus-Taste je Tag; Eintrag Heizphase; Eintrag Absenkphase | „Übernehmen“, „Abbrechen“ (Löschen: „Eintrag löschen“) | Plus-Taste mit Schlüsselsymbol |
| Eingabe-Pop-up | [RM-06](../02_Referenz-Analyse/Module/RM-06_Eingabe-Pop-up.md) / [HM-13](Module/HM-13_Eingabe-Pop-up.md) | Antippen jedes Eingabefelds mit Schlüsselsymbol ([RM-05](../02_Referenz-Analyse/Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md)); Zeitfelder in RM-27; HS-18 Direkteingabe der Nockennummer (HS-25) | „Übernehmen“, „Abbrechen“ | Annahme (A-20). **Einheitlich ohne Berechtigung (alle Eingaben und Aktionen mit Schlüsselsymbol):** Das Eingabe-Pop-up bzw. die Aktion öffnet nicht, die Meldezeile zeigt „Berechtigung erforderlich: <Rolle>“ und das Benutzer-Pop-up öffnet sich; nach der Anmeldung läuft die ausgelöste Aktion weiter |
| Such-Pop-up (Suche mit Trefferliste) | [HM-38](Module/HM-38_Such-Pop-up.md) in [HM-14](Module/HM-14_Popup-Rahmen.md), Texteingabe nach [HM-13](Module/HM-13_Eingabe-Pop-up.md); im Seitenkonzept HS-30 definiert (A-59, OP-40) | HS-30, HS-31, HS-33 Taste „Suchen“ | Treffer wählen oder „Abbrechen“ | keine |
| Filter-Dialog (Meldenummer, Zeit) | HM-13 Filtervariante in HM-14 | HS-37 Taste „Filter“ | „Übernehmen“, „Abbrechen“ | keine |
| Datei-/Ergebnis-Pop-up | HM-14 (Art FileResult): Dateiauswahl, Fortschritt, Ergebnis | HS-36 „Alle exportieren“, „Liste exportieren“, „Importieren“; HS-37 „Export“ | „Übernehmen“/„Abbrechen“, „Schließen“ | Taste mit Schlüsselsymbol (Dateiformat und Ort offen, OP-49) |
| Eingabe-Pop-up über HS-03 | HM-13 in HM-14, Tiefe 2 | HS-03 Antippen eines Eingabefelds | „Übernehmen“, „Abbrechen“; danach zurück zu HS-03 | Felder mit Schlüsselsymbol |
| Benutzer-Pop-up | im Seitenkonzept HS-01 / Rahmen definiert | Seitenleiste Benutzerkreis; berechtigungspflichtige Eingabe ohne Rolle | „Abbrechen“; nach Anmeldung wird die ausgelöste Aktion fortgesetzt | – |
| Sprachwahl-Pop-up | Platzhalter (OP-03) | HS-04 Funktionsleiste „Sprache“ | Auswahl oder „Abbrechen“ | keine |
| Rezeptauswahl-Pop-up | Platzhalter (OP-01) | HS-01 Rezept-Feld | Auswahl oder „Abbrechen“ | Annahme: Rolle Technik |
| Bestätigungs-Pop-up | HM-14 (Art Confirmation, Fokus auf „Abbrechen“) | zerstörerische, stoppende oder die Messung verändernde Aktionen: HS-13 „Nullpunkt setzen“ und „Zähler löschen“; HS-14 „Start“ im Modus Einzel (löscht vorhandene Werte); HS-35 „Steuerung neu starten“, „Steuerung ausschalten“, „Bedienung beenden“; HS-36 Importieren („Werte aus Datei in die Maschine schreiben?“); HS-37 „Liste leeren“ | „Ja“/„Abbrechen“ | Schlüsselsymbol der Taste |
| Bestätigung „Änderungen verwerfen?“ | HM-14 (Art Confirmation), Tasten „Verwerfen“/„Abbrechen“ | HS-25 beim Blättern, bei „Übersicht“ oder beim Verlassen mit nicht geschriebenen Änderungen (Annahme, im Handbuch nicht beschrieben) | „Verwerfen“, „Abbrechen“ | keine |

Das Handbuch beschreibt Bestätigungsdialoge nicht; sie sind eine Ergänzung (A-40), weil HS-35 laut Handbuch „die Anlage stoppt“.

### 4.2 Modale Regeln (A-40)

1. **Ein Pop-up zur Zeit, Tiefe höchstens 2.** Zulässige Stapelung: Eingabe-Pop-up über Zeitplan-Eintrag (Zeitfelder), Eingabe-Pop-up über HS-03 (Maschinengeschwindigkeit), Benutzer-Pop-up über HS-03 (Eingabe ohne Rolle) und Bestätigungs-Pop-up über ein anderes Pop-up. Alles andere wird abgelehnt (Anforderung wird verworfen, nicht aufgeschoben).
2. **Blockieren.** Hinter einem Pop-up liegt ein Abdunklungsfeld (Scrim). Seitenleiste, Funktionsleiste und Seiteninhalt sind gesperrt; der Brotkrümel ist nicht bedienbar. Meldezeile und Kopfzeile bleiben sichtbar (Anzeige), antippen ist wirkungslos.
3. **Schließen.** Jedes Pop-up hat eine eindeutige Schließen-Aktion (Schließen, Abbrechen oder Kreuz). Ein Antippen außerhalb schließt **nicht** (Schutz vor Fehlbedienung bei Touch). Pop-ups mit Änderungen schließen ohne Übernehmen verwerfen die Änderung.
4. **Verlauf.** Pop-ups stehen nicht im Verlauf. Die Seitenleisten-Taste „Zurück“ ist gesperrt, solange ein Pop-up offen ist; „Schließen“/„Abbrechen“ im Pop-up ersetzt sie.
5. **Seitenwechsel durch das System** (z. B. Zeitablauf bei HS-24, Rollenverlust nach Abmeldung) schließt offene Pop-ups ohne Übernehmen.
6. **Lage.** Mittig über dem Inhaltsbereich; Titelzeile mit Pop-up-Titel; Bedientasten unten rechts (Handbuch: „Schließen“ unten rechts, „Reset“ unten links in HS-02). Maße nach Designsystem.
7. **Meldungen während eines Pop-ups.** Neue Meldungen werden in der Meldezeile angezeigt, öffnen aber HS-38 erst nach Schließen.

## 5. Navigationsdienst (Spezifikation für Meilenstein 2)

Ziel: Seitenwechsel, Brotkrümel, Verlauf und Berechtigung laufen zentral über einen Dienst; ViewModels kennen keine Views (MVVM, Agent.md Abschnitt 7). Code-Bezeichner englisch, sichtbare Texte aus `.resx`.

### 5.1 Seitenregister (Schlüssel je Seite)

Der Schlüssel (`PageKey`) ist eine Konstante, die Route der Zeichenfolge-Bezeichner für Deep Links, Protokoll und Tests. ViewModel-Namen: `<Key>ViewModel`, View: `<Key>View` (Beispiel `HotGlueNordsonViewModel`). Beschriftungsschlüssel in `.resx`: `Nav_<Key>_Title` (Seitentitel) und `Nav_<Key>_Crumb` (Brotkrümel-Segment). Mindestrolle: `–` = jeder angemeldete Benutzer.

| HS-ID | PageKey / Route | Eltern (Brotkrümel) | Typ | Parameter | Mindestrolle |
|---|---|---|---|---|---|
| HS-01 | `Production` / `production` | – | Seite (Wurzel) | – | – |
| HS-02 | `ProductionCounter` / `production/counter` | HS-01 | Pop-up | – | – |
| HS-03 | `MachineSpeed` / `production/speed` | HS-01 | Pop-up | – | – |
| HS-04 | `Settings` / `settings` | – | Seite | – | – |
| HS-05 | `FeederPaper` / `settings/feeders/paper` | HS-40 | Seite | – | – |
| HS-06 | `FeederCarton` / `settings/feeders/carton` | HS-40 | Seite | – | – |
| HS-07 | `HotGlueNordson` / `settings/feeders/hotglue` | HS-40 | Seite | – | – |
| HS-08 | `HotGlueParameters` / `settings/feeders/hotglue/parameters` | HS-07 | Seite | – | – |
| HS-09 | `HotGluePressure` / `settings/feeders/hotglue/pressure` | HS-07 | Seite | – | – |
| HS-10 | `HotGlueSchedule` / `settings/feeders/hotglue/schedule` | HS-07 | Seite | – | – |
| HS-11 | `MainDosers` / `settings/dosers/main` | HS-41 | Seite | `doserIndex` (1, 2) | – |
| HS-12 | `MainDoserMotor` / `settings/dosers/main/motor` | HS-11 | Seite | `doserIndex` | – |
| HS-13 | `CheckWeigher` / `settings/scales/check` | HS-42 | Seite | – | – |
| HS-14 | `SingleWeights` / `settings/scales/check/weights` | HS-13 | Seite | – | – |
| HS-15 | `Trend` / `settings/scales/check/trend` | HS-13 | Seite | – | – |
| HS-16 | `ClosingMachine` / `settings/closing` | HS-04 | Seite | – | – |
| HS-17 | `ClosingMotor` / `settings/closing/motor` | HS-16 | Seite | – | – |
| HS-18 | `ClosingWeightCorrection` / `settings/closing/weightcorrection` | HS-16 | Seite | – | – |
| HS-19 | `PostDoser` / `settings/dosers/post` | HS-41 | Seite | – | – |
| HS-20 | `PostDoserMotor` / `settings/dosers/post/motor` | HS-19 | Seite | – | – |
| HS-21 | `PostDoserWeightCorrection` / `settings/dosers/post/weightcorrection` | HS-19 | Seite | – | – |
| HS-22 | `Heaters` / `settings/heaters` | HS-04 | Seite | – | – |
| HS-23 | `Regulation` / `settings/regulation` | HS-04 | Seite | – | – |
| HS-24 | `ScreenCleaning` / `settings/screencleaning` | HS-04 | Vollbild | `durationSeconds` (aus Konfiguration) | – |
| HS-25 | `Cams` / `settings/cams` | HS-04 | Seite | `camNumber` | – |
| HS-26 | `CamOverview` / `settings/cams/overview` | HS-25 | Seite | – | – |
| HS-27 | `ScaleCalibration` / `settings/scales/calibration` | HS-42 | Seite | `scaleIndex` | – |
| HS-28 | `PackRegister` / `settings/packregister` | HS-04 | Seite | – | – |
| HS-29 | `ProductionStatistics` / `settings/statistics` | HS-04 | Seite | `dayOffset` (0 bis 29) | – |
| HS-30 | `ManualSelection` / `settings/manual` | HS-04 | Seite | – | – |
| HS-31 | `ManualOperation` / `settings/manual/group` | HS-30 | Seite | `groupId`, optional `actorId` | – |
| HS-32 | `EncoderSetting` / `settings/encoders` | HS-04 | Seite | `encoderIndex` | – |
| HS-33 | `IoOverview` / `settings/io` | HS-04 | Seite | – | – |
| HS-34 | `IoDisplay` / `settings/io/card` | HS-33 | Seite | `cardGroup`, `cardIndex` | – |
| HS-35 | `SystemSettings` / `settings/system` | HS-04 | Seite | – | – |
| HS-36 | `Service` / `settings/system/service` | HS-35 | Seite | – | Technik (Dummy, A-41) |
| HS-37 | `MessageArchive` / `settings/system/archive` | HS-35 | Seite | – | – |
| HS-38 | `MessageView` / `messages` | – | Seite | – | – |
| HS-39 | `SystemInfo` / `settings/system/info` | HS-35 | Seite | – | – |
| HS-40 | `Feeders` / `settings/feeders` | HS-04 | Zwischenseite (Z) | – | – |
| HS-41 | `DoserOverview` / `settings/dosers` | HS-04 | Seite (Z) | – | – |
| HS-42 | `Scales` / `settings/scales` | HS-04 | Zwischenseite (Z) | – | – |
| HS-43 | `ShiftPlan` / `production/shiftplan` | HS-01 | Seite (Z, Platzhalter) | – | – |

Pop-ups ohne HS-Seite (Zeitplan-Eintrag, Eingabe, Suche, Benutzer, Sprache, Rezept, Bestätigung) laufen über `IDialogService` mit eigenem `DialogKey`, nicht über das Seitenregister.

Der Brotkrümel einer Seite ergibt sich aus der Kette der Elternschlüssel (Spalte „Eltern“) bis zur Wurzel, ergänzt um die Wurzel „Einstellung“ (HS-04) bzw. „Produktion“ (HS-01); HS-38 hat nur ein Segment. Bei HS-25 ist die Seite selbst das Segment „Nockenschaltwerk“ (Beschriftung `Nav_Cams_Crumb`); der Referenzpfad „… › Nocken“ entfällt (A-34).

### 5.2 Schnittstellen (Entwurf)

```csharp
public enum PageKind { Page, Popup, Fullscreen }

public sealed record PageDescriptor(
    string Key,                    // "HotGlueNordson"
    string Route,                  // "settings/feeders/hotglue"
    string HsId,                   // "HS-07"
    PageKind Kind,
    string? ParentKey,             // Breadcrumb chain
    Type ViewModelType,
    string TitleResourceKey,       // "Nav_HotGlueNordson_Title"
    string CrumbResourceKey,       // "Nav_HotGlueNordson_Crumb"
    FunctionBarKind FunctionBar,   // None, Search, Paging, Actions, ...
    UserRole? MinimumRole,
    bool ShowFrame = true);

public interface INavigationService
{
    PageDescriptor Current { get; }
    object? CurrentParameter { get; }
    IReadOnlyList<PageDescriptor> History { get; }       // back stack: predecessor pages only, without Current; newest last
    IReadOnlyList<BreadcrumbItem> Breadcrumb { get; }    // canonical path of Current
    bool CanGoBack { get; }

    Task<bool> NavigateToAsync(string key, object? parameter = null);
    void ReplaceParameter(object? parameter);            // paging, no history entry
    bool GoBack();
    void GoHome();                                       // Production, stack []
    void GoToSettings();                                 // Settings, stack [Production]
    void GoToAncestor(string key);                       // tap on breadcrumb segment
    void OpenMessages();                                 // MessageView (side bar / message line)

    event EventHandler<NavigatedEventArgs> Navigated;
}

public sealed record BreadcrumbItem(string Key, string DisplayText, bool IsCurrent, bool IsNavigable);

public interface IDialogService
{
    bool IsModalOpen { get; }
    Task<DialogResult<T>> ShowAsync<T>(string dialogKey, object? parameter = null);
    void CloseTop();
    void CloseAll();
}

public interface IUserSession
{
    UserInfo Current { get; }                            // dummy: "Max Mustermann", Technician
    bool HasRole(UserRole minimum);
    Task<bool> RequestRoleAsync(UserRole minimum);       // opens user popup
    event EventHandler SessionChanged;
}
```

DI: `INavigationService`, `IDialogService`, `IUserSession` als Singletons (`Microsoft.Extensions.DependencyInjection`); ein statisches Register `PageRegistry` hält die 43 `PageDescriptor` (aus Tabelle 5.1). Views werden per `DataTemplate` ViewModel→View aufgelöst, kein Code-behind. ViewModels erhalten ihren Parameter über `INavigationAware.OnNavigatedTo(object? parameter)` und geben Zustand frei in `OnNavigatedFrom()`.

### 5.3 Verlauf und Zurück-Stapel (A-42)

| Ereignis | Wirkung auf den Stapel |
|---|---|
| `NavigateTo(Y)` von X (Kachel, Funktionsleiste, Brotkrümel nach unten) | X wird oben auf den Stapel gelegt, Y ist aktuelle Seite |
| Blättern (HS-11, HS-12, HS-25, HS-26, HS-27, HS-29, HS-31, HS-32, HS-34; «/», » bzw. Pfeiltasten) | `ReplaceParameter`, kein Eintrag |
| `NavigateTo(Y)` bzw. `GoToAncestor(Y)` mit Y bereits im Stapel (z. B. Rückweg über Brotkrümel-Segment) | Stapel wird bis unterhalb von Y gekürzt, Y wird aktuell (Sprung zum Vorfahren, keine Schleife). Der Rücksprung folgt dem **Stapeleintrag**: Y erscheint mit den Parametern, die der Stapeleintrag trägt; gleichnamige Parameter der aktuellen Seite (`doserIndex`) werden übernommen (HS-12 → HS-11 zeigt denselben Dosierer). Ist Y nicht im Stapel, wird Y neu geöffnet (Parameter der aktuellen Seite, sonst Standard) |
| Home | Stapel `[]`, aktuell HS-01 (Schreibweise im ganzen Dokument: Stapel = nur Vorgängerseiten, ohne die aktuelle Seite) |
| Einstellungen | Stapel `[HS-01]`, aktuell HS-04 |
| Meldungen / Meldezeile | wie `NavigateTo(HS-38)`; auf HS-38 wirkungslos |
| Zurück | oberster Eintrag wird aktuell. Ist der Stapel leer und die Seite nicht HS-01, geht es zum Elternschlüssel; auf HS-01 deaktiviert |
| Gleiche Seite erneut anwählen | wirkungslos (kein neuer Eintrag) |
| HS-24 | wird nicht in den Stapel gelegt; nach Ablauf wird die vorherige Seite wiederhergestellt |
| Tiefe | begrenzt auf 20; ältester Eintrag fällt weg (Wurzel HS-01 bleibt) |
| Pop-up | nie im Stapel (Abschnitt 4) |

Sprung über Seitenleiste (Home, Einstellungen) setzt den Stapel zurück, damit „Zurück“ nach einem Sprung nicht in eine alte Tiefe führt.

### 5.4 Berechtigungen (A-41)

- Rollen als Dummy: `Operator`, `Technician`, `Service`; Standardbenutzer „Max Mustermann“ mit Rolle `Technician` (Design). Reihenfolge `Operator < Technician < Service`.
- **Seitenzugang:** `PageDescriptor.MinimumRole`. Ist die Rolle zu niedrig, bleibt die Navigation stehen, der Dienst ruft `IUserSession.RequestRoleAsync`; nach erfolgreicher Anmeldung läuft die ursprüngliche Navigation weiter, bei Abbruch bleibt die Seite unverändert. Kachel bzw. Taste bleibt sichtbar und trägt das Schlüsselsymbol ([DM-17](../01_Design-Analyse/Module/DM-17_Eingabefeld-mit-Schluesselsymbol.md)-Symbolik).
- Im Handbuch ist nur HS-36 (Taste „Service“ mit Schlüsselsymbol) seitenseitig geschützt; alle anderen Seiten sind frei erreichbar. **Eingaben und Aktionen** sind auf Feld-/Tastenebene geschützt (Schlüsselsymbol, [RM-05](../02_Referenz-Analyse/Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md), [RM-11](../02_Referenz-Analyse/Module/RM-11_Aktionstaste.md)) und nicht Teil des Navigationsdienstes; er stellt nur `IUserSession` bereit.
- Rollenverlust (Abmeldung) auf einer geschützten Seite: Dienst navigiert zum Elternschlüssel (HS-35), Pop-ups werden geschlossen.
- Wertebereiche und konkrete Rollenzuordnung je Feld nennt die Quelle nicht (OP-04); sie sind Dummy.

### 5.5 Brotkrümel- und Titel-Bildung

- `Breadcrumb` wird aus `PageDescriptor.ParentKey` gebildet: Wurzel („Einstellung“ aus `Nav_Settings_Crumb`) › Zwischenseiten › Seite. Das letzte Element: `IsCurrent = true`, `IsNavigable = false`.
- Dynamische Segmente (HS-31, HS-34) und Objektkennung als Zusatz (`ObjectSuffix`: HS-11, HS-12, HS-20): `ViewModel` liefert den Text über `IBreadcrumbTextProvider.GetCrumbText()`, sonst Ressource. HS-25 und HS-27 haben statische Segmente (Objekt in Seite bzw. Titelzeile).
- Der Brotkrümel ist auf HS-24 (`Fullscreen`) ausgeblendet. Pop-ups (`Popup`) ändern ihn nicht.
- Sprachumschaltung: Ressourcenschlüssel werden zur Anzeigezeit aufgelöst, kein Text im Register.

### 5.6 Meldungs- und Sonderfälle

- Meldezeile öffnet `MessageView`; bei offenem Pop-up wird die Anforderung zurückgestellt (Abschnitt 4.2, Punkt 7).
- `ScreenCleaning` startet einen Timer; bei Ablauf `GoBack()` ohne Stapelwirkung (Abschnitt 5.3).
- Der Dienst hat keinen Zugriff auf die Maschine; Seiten, die Aktionen auslösen, nutzen eigene Schnittstellen (Agent.md Abschnitt 7).

## 6. Lücken und getroffene Annahmen

### 6.1 Zwischenseite „Zuführungen“ (OP-20)

- **Befund.** Das Design zeigt den Brotkrümel „Einstellung › Zuführungen › Heißleim / Karton“ (DS-03, DS-05) und eine Kachel „Zuführungen“ (DS-02), aber keine Seite dazu. Die Referenz kennt keine Zwischenseite: „Zuführung Papier“ und „Zuführung Karton“ sind eigene Kacheln in RS-04, das Heißleimgerät hängt als Taste an RS-06.
- **Annahme (A-33, A-34).** HS-40 „Zuführungen“ ist ein Kachelmenü mit drei Kacheln „Papier“ (HS-05), „Karton“ (HS-06), „Heißleim“ (HS-07), im Stil von HS-04 ([DM-12](../01_Design-Analyse/Module/DM-12_Kachel-Taste.md)). Der Brotkrümel von HS-07 folgt dem Design (unter „Zuführungen“, nicht unter „Karton“); der Handbuchzugang über die Taste „Heißleimgerät“ in HS-06 bleibt als zweiter Zugang erhalten.
- **Folge.** In HS-04 entfallen die Einzelkacheln „Zuführung Papier“ und „Zuführung Karton“ der Referenz zugunsten von „Zuführungen“.

### 6.2 Elternseite RS-17 / RS-18 (OP-23)

- **Befund.** Das Handbuch beschreibt keine Navigation von RS-16 zu „Motorparameter“ und „Gewichtskorrektur“ der Schließmaschine; die Seitenbilder RS-17/RS-18 sind identisch mit RS-12/RS-20 bzw. RS-21 (OP-55). RS-16 hat im Bild die Taste „Heißleimgerät“ mit unklarem Ziel.
- **Annahme (A-37).** HS-17 und HS-18 sind Unterseiten von HS-16 (A-11), erreichbar über zwei zusätzliche Tasten in der Funktionsleiste von HS-16 („Motorparameter“, „Gewichtskorrektur“), analog zu HS-19. Die Taste „Heißleimgerät“ in HS-16 öffnet HS-07. Klärt sich, dass RS-17/RS-18 Handbuchdubletten sind, entfallen HS-17/HS-18 samt Tasten; die übrige Struktur ändert sich nicht.

### 6.3 Endkontrollwaage (OP-24)

- **Befund.** RS-04 führt „Endkontrollwaage“ als Eintrag; ein Kapitel gibt es nicht (A-12). In HS-30 ist „GR14 Endkontrollwaage“ nur eine Handbetriebs-Gruppe.
- **Annahme (A-36).** In HS-42 „Waagen“ steht eine deaktivierte Kachel „Endkontrollwaage“ (Symbol „nicht verfügbar“ und Text, nicht nur Farbe). Keine HS-Seite, kein Verlaufs- oder Brotkrümelpfad. Existiert später ein Kapitel, bekommt die Kachel ein Ziel (neue ID, Nummernkreis ab HS-44).

### 6.4 EA-Zugänge (HS-33, HS-34)

- **Befund.** Der Zugang von RS-33 zu RS-34 ist im Handbuch nicht beschrieben (A-14). RS-33 zeigt sechs Tasten „Eingänge/Ausgänge S1, S300, S500“ („Über die Schaltflächen können Ein- und Ausgänge gezielt angezeigt und überprüft werden“); RS-34 zeigt „Eingänge S1“, Karte „S1_0KDE1“, mit Blättern zwischen Karten.
- **Annahme (A-39).** Jede der sechs Tasten öffnet HS-34 mit dem Parameter `cardGroup` (Eingänge/Ausgänge, S1/S300/S500) und der ersten Karte; « und » blättern in der Gruppe. Die Suche auf HS-33 (und auf HS-30/HS-31) öffnet ein Such-Pop-up; ein Treffer öffnet direkt HS-34 (EA-Karte des Betriebsmittels) bzw. HS-31 (Aktor). Brotkrümel: `Einstellung › EA-Übersicht › Eingänge S1`.
- **Gleiches Muster Handbetrieb.** Gruppentaste GRxx in HS-30 öffnet HS-31 (Annahme A-14); HS-31 blättert mit «/» zwischen Aktoren.

### 6.5 Weitere Lücken

| Thema | Annahme | Bezug |
|---|---|---|
| Dosierer: Design zeigt eine Übersicht (DS-04) mit Karten, die Referenz zwei Detailseiten (RS-11, RS-19) | Kachel „Dosierer“ → HS-41 (DS-04 als Übersicht); Detail-Symbol in der Karte → HS-11 bzw. HS-19; die Einzelkacheln „Hauptdosierer“ und „Nachdosierer“ aus RS-04 entfallen in HS-04 (A-36) | OP-12, OP-17 |
| Design „Waagen“ gegenüber Referenz „Kontrollwaage“ / „Waagen kalibrieren“ / „Endkontrollwaage“ | HS-42 Zwischenseite mit drei Kacheln | A-36 |
| HS-04: 16 Plätze im Design, 18 Einträge in der Referenz | Belegung der Plätze in A-36; „Regulierung“, „Geber setzen“ und „Produktionsstatistik“ belegen drei der vier leeren Plätze, „Geräte“ bleibt reserviert, ein Platz bleibt frei | OP-05, OP-12 |
| Schloss-Symbol der Referenz (gelb) | Nicht Teil der Funktionsleiste; Anmeldestatus über Benutzerkreis der Seitenleiste | A-35, OP-04 |
| Seitenleiste „Meldungen“ und Meldezeile führen beide auf HS-38 | Beide gleichwertig; HS-37 Archiv über Taste „Archiv“ und HS-35 | OP-08 |
| Antippbarkeit von Brotkrümel und Kennzahlen | Brotkrümel-Segmente antippbar, Kennzahl „Geschwindigkeit“ öffnet HS-03, „Winkel“ nicht | A-34, A-38, OP-21 |
| Tasten „Zuführung Papier“/„Zuführung Karton“ in DS-01 (OP-10 nahm Navigation an) | Referenz gewinnt: Zustandstasten (Aktivierung); Navigation nur über „Einstellung › Zuführungen“ | A-38 |
| Rezept (OP-01), Sprache (OP-03), Schichtplan (OP-02) | Pop-ups bzw. Platzhalterseite HS-43 | A-33, A-40 |
| Funktion der Taste „Wago“ (HS-36) und „Lampentest“ (HS-35) | Aktionstasten ohne Navigation; Inhalt offen | Handbuch nennt keine Funktion |
| HS-24 (Bildschirm reinigen): Kopfzeile und Meldezeile | Die Kopfzeile ohne Meldezeile bleibt stehen (HM-02, `ShowMessageLine = false`); Seitenleiste, Brotkrümel, Funktionsleiste und Meldezeile sind ausgeblendet. Ein kritischer Alarm (Meldungsklasse Störung) beendet die Reinigung vorzeitig und gibt die Bedienung frei (Annahme, kein Handbuchbeleg, OP-61) | A-66, OP-31, OP-44 |
| Stapelverhalten bei Parallelzugängen (z. B. HS-23 aus HS-04 und HS-11) | „Zurück“ folgt dem Verlauf (A-42), Brotkrümel bleibt kanonisch (A-34) | – |

## 7. Prüfpunkte

| ID | Prüfung | Erwartetes Ergebnis | Status |
|---|---|---|---|
| NAV-P01 | Alle 39 RS-IDs sind im Baum (Abschnitt 1) und in der Tabelle (Abschnitt 2) als HS-01 bis HS-39 enthalten | 39 Zeilen plus HS-40 bis HS-43 | offen |
| NAV-P02 | Jede Seite hat Zugang, Brotkrümel und Zurück-Ziel | Tabelle ohne leere Zellen | offen |
| NAV-P03 | Brotkrümel stimmt mit den Design-Screenshots überein | DS-01 bis DS-05: Produktion; Einstellung; Einstellung › Zuführungen › Heißleim; Einstellung › Dosierer; Einstellung › Zuführungen › Karton | offen |
| NAV-P04 | Jedes Ziel jeder Funktionsleisten-Taste existiert im Baum | Abschnitt 3.3 und Baum widerspruchsfrei | offen |
| NAV-P05 | Seitenregister (5.1) und Brotkrümel-Tabelle (2) stimmen überein | gleiche Eltern, 43 Einträge | offen |
| NAV-P06 | Jeder Zugang im Baum ist erreichbar und führt zurück | Kein Zyklus, kein Seitenpaar ohne Rückweg | offen |
| NAV-P07 | Pop-up-Regeln gelten für HS-02, HS-03, RM-27, RM-06 | Abschnitt 4 | offen |
| NAV-P08 | Neue Annahmen A-33 ff. stehen in Annahmen.md | vorhanden | offen |
| NAV-P09 | Pop-up-Inventar 4.1 enthält Such-Pop-up, Filter-Dialog, Datei-/Ergebnis-Pop-up, Bestätigungen (HS-13, HS-14, HS-25, HS-35 bis HS-37) und Eingabe-Pop-up über HS-03 | vorhanden | offen |
