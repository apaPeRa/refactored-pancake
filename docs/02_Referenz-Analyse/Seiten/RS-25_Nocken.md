# RS-25 – Nocken
- Quelle: Referenz.docx, Kapitel 25 „Nocken“ (Zweck, Seitenübersicht, Funktionsbeschreibung mit Unterbereichen „Einstellungen“ (T34, 9 Zeilen inkl. Kopfzeile) und „Navigation (unten links)“ (T35, 3 Zeilen inkl. Kopfzeile)); Bild [RS-25_01.png](../Medien/RS-25_01.png)
- Navigationspfad: Einstellung › Nockenschaltwerk › Nocken (Eintrag „Nockenschaltwerk“ in der Tabelle von [RS-04](RS-04_Einstellungen.md)); Wechsel zur Übersicht: [RS-26](RS-26_Nockenuebersicht.md)

## Zweck
Die Maschine arbeitet mit einem elektronischen Nockenschaltwerk. Einzelne Nocken können während des Betriebs eingesehen und angepasst werden.

## Aufbau (Bereiche, Layout)
Beschreibung des Bildes [RS-25_01.png](../Medien/RS-25_01.png) (Altes HMI, 1024 × 768):

- **Kopfzeile:** Logo „APA-TEC GmbH – Automation and Packaging Technology“, unterstrichener Titel „Nocken“, Wirbel-Symbol, Uhrzeit „13:04:19“, Datum „12.05.2025“.
- **Arbeitsbereich (blau), Zeilen von oben nach unten, Beschriftungen links in fetter Schrift:**
  1. „Nummer:“ – weißes Feld mit roter Schrift „12“ (ohne Schlüsselsymbol), rechts daneben zwei graue Tasten „<<“ und „>>“ (ohne Schlüsselsymbol).
  2. „Anfang:“ – drei weiße Felder: „330 °“ (rot, Schlüsselsymbol), „50 ms“ (rot, Schlüsselsymbol), „330 °“ (schwarz, kein Schlüsselsymbol). Rechts daneben „Position:“ mit weißem Anzeigefeld „140 °“ (schwarz).
  3. „Ende:“ – drei weiße Felder: „790 °“ (rot, Schlüsselsymbol), „50 ms“ (rot, Schlüsselsymbol), „790 °“ (schwarz). Rechts daneben „Status:“ mit einer grauen runden LED.
  4. „Typ:“ – weißes Feld rote Schrift „3“ mit Schlüsselsymbol; rechts daneben schwarzer Text „0 - 1079“. Rechts große graue Schaltfläche „Werte schreiben“ mit großem gelbem Schlüsselsymbol (spannt sich über die Zeilen Typ und Geber).
  5. „Geber:“ – weißes Feld mit roter, zweizeiliger Schrift „Geber 1GF Hauptantrie[b]“ (im Bild am Feldrand abgeschnitten, Schlüsselsymbol), rechts daneben zwei graue Tasten „<<“ und „>>“ mit Schlüsselsymbol.
  6. „Bezeichnung:“ – breites weißes Feld mit roter, zentrierter Schrift „Karton ansaugen 1 3KY40“ und Schlüsselsymbol.
- **Meldezeile (rot):** „*450* Palettierung nicht bereit“.
- **Fußleiste:** links Navigation unten links: Taste „<<“, Taste „Übersicht“ (mit Listen-Symbol „1 2 3“), Taste „>>“; mittig gelbes Schloss-Symbol; rechts „Produktion“ (Haus, im Bild mit hellblauem Rand hervorgehoben), „Einstellungen“ (Zahnrad), „Zurück“.

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Tabelle T34 „Einstellungen“ (Spalten Funktion | Beschreibung), 8 Datenzeilen, wortgetreu:

| Element (Handbuch: Funktion) | Typ | Funktion (Beschreibung wörtlich) | verwendetes Modul |
|---|---|---|---|
| Auswahl Fixierkurve | Zahlenfeld „Nummer“ (Bild: 12) mit Tasten << und >> | „Direkte Auswahl einer Nockennummer zur Anzeige oder Bearbeitung. Mit den Pfeiltasten kann zwischen Nocken geblättert werden.“ | [RM-32](../Module/RM-32_Auswahlfeld-mit-Pfeiltasten.md) (Blättern); [RM-06](../Module/RM-06_Eingabe-Pop-up.md) |
| Anfang / Ende | je drei Felder (Winkel °, Zeit ms, Ergebnis °), Schlüsselsymbol bei den ersten beiden | „Eingabe der Start- und Endposition der Nocke in Bezug auf den ausgewählten Geber. Über die Zeiten können Ansprechzeiten der Hardware kompensiert werden. Richtig eingestellt führen Kompensationszeiten zu einem gleichbleibenden Ergebnis unabhängig von der Maschinengeschwindigkeit“ | [RM-05](../Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md); [RM-20](../Module/RM-20_Nocken-Parameterzeile.md) (Winkel, Zeit, Ergebnis) |
| Typ | Zahlenfeld (Bild: 3) mit Schlüsselsymbol, daneben Text „0 - 1079“ | „Erlaubt eine Untersetzung der Nocke. Muss nach der Inbetriebnahme der Maschine nicht mehr verändert werden.“ | [RM-05](../Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) |
| Geber | Auswahlfeld (Bild: „Geber 1GF Hauptantrieb“) mit Tasten << und >> und Schlüsselsymbol | „Auswahl des Gebers auf den sich die Nocke bezieht. Ändert sich nicht mehr nach der Inbetriebnahme.“ | [RM-32](../Module/RM-32_Auswahlfeld-mit-Pfeiltasten.md) und Schlüsselsymbol |
| Bezeichnung | Textfeld (Bild: „Karton ansaugen 1 3KY40“) mit Schlüsselsymbol | „Name und Beschreibung der Nocke. Kann angepasst werden, wenn nötig.“ | [RM-05](../Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) (Text) |
| Position | Anzeigefeld (Bild: 140 °) | „Aktueller Wert des angewählten Gebers.“ | [RM-07](../Module/RM-07_Anzeigefeld.md) Istwert |
| Status | Status-LED (Bild: grau) | „Zeigt an ob die aktuelle Geberposition innerhalb der Nocke ist.“ | [RM-08](../Module/RM-08_Status-LED.md) |
| Werte schreiben | Taste mit Schlüsselsymbol | „Erst nach dem Schreiben werden die Änderungen aktiv.“ | [RM-11](../Module/RM-11_Aktionstaste.md) (Übernehmen) |

Tabelle T35 „Navigation (unten links)“ (Spalten Funktion | Beschreibung), 2 Datenzeilen, wortgetreu:

| Element | Typ | Funktion (Beschreibung wörtlich) | verwendetes Modul |
|---|---|---|---|
| Pfeiltasten | Tasten << und >> (Fußleiste links) | „Erlaubt das blättern zwischen den Nocken“ | [RM-04](../Module/RM-04_Blaettertasten.md) |
| Übersicht | Taste mit Listen-Symbol | „Öffnet die Seite Nockenübersicht.“ | [RM-04](../Module/RM-04_Blaettertasten.md) |

Nur im Bild: Seitenkopf, Meldezeile, Fußleiste Produktion/Einstellungen/Zurück mit Schloss-Symbol ([RM-01](../Module/RM-01_Kopfzeile.md); [RM-02](../Module/RM-02_Meldezeile.md); [RM-03](../Module/RM-03_Funktionsleiste-unten.md)).

Medien dieser Seite (1 Bild):

| Bild | Zeigt |
|---|---|
| [RS-25_01.png](../Medien/RS-25_01.png) | Seite Nocken: Nummer 12, Anfang 330 ° / 50 ms / 330 °, Ende 790 ° / 50 ms / 790 °, Position 140 °, Status-LED, Typ 3 (0 - 1079), Geber „Geber 1GF Hauptantrieb“, Taste „Werte schreiben“, Bezeichnung „Karton ansaugen 1 3KY40“, Navigation unten links <<, Übersicht, >> |

## Verwendete Module (IDs)

Module dieser Seite (Definitionen in der [Modulliste](../Module/Modulliste.md)):

- [RM-01](../Module/RM-01_Kopfzeile.md) – Kopfzeile
- [RM-02](../Module/RM-02_Meldezeile.md) – Meldezeile
- [RM-03](../Module/RM-03_Funktionsleiste-unten.md) – Funktionsleiste unten
- [RM-04](../Module/RM-04_Blaettertasten.md) – Blättertasten
- [RM-05](../Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) – Eingabefeld mit Schlüsselsymbol
- [RM-06](../Module/RM-06_Eingabe-Pop-up.md) – Eingabe-Pop-up
- [RM-07](../Module/RM-07_Anzeigefeld.md) – Anzeigefeld
- [RM-08](../Module/RM-08_Status-LED.md) – Status-LED
- [RM-11](../Module/RM-11_Aktionstaste.md) – Aktionstaste
- [RM-20](../Module/RM-20_Nocken-Parameterzeile.md) – Nocken-Parameterzeile
- [RM-32](../Module/RM-32_Auswahlfeld-mit-Pfeiltasten.md) – Auswahlfeld mit Pfeiltasten

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- **Nocke wählen:** Nockennummer direkt eingeben oder mit << / >> (neben dem Feld oder in der Fußleiste) blättern.
- **Bearbeiten:** Anfang, Ende (Winkel in °, Kompensationszeit in ms), Typ, Geber und Bezeichnung sind änderbar. Änderungen werden erst nach der Taste „Werte schreiben“ aktiv.
- **Anzeige:** Position (aktueller Wert des Gebers) und Status (LED) werden laufend angezeigt. Status zeigt, ob die Geberposition innerhalb der Nocke liegt (Farbbedeutung im Handbuch nicht beschrieben; auf RS-26 leuchtet die LED grün in der aktiven Phase).
- **Typ und Geber:** ändern sich nach der Inbetriebnahme nicht mehr; Typ erlaubt eine Untersetzung.
- **Berechtigungen:** Handbuch nennt keine; Schlüsselsymbole im Bild bei Anfang/Ende (Winkel und Zeit), Typ, Geber (Feld und Tasten), Bezeichnung und Werte schreiben (Annahme: berechtigungsgeschützt). Die Nummernauswahl (Feld und Tasten) hat keines.
- **Navigation:** Fußleiste links „<<“, „Übersicht“ (öffnet [RS-26](RS-26_Nockenuebersicht.md)), „>>“; rechts Produktion, Einstellungen, Zurück.
- **Pop-ups / Fehlerfälle:** keine beschrieben.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RS-25-P01 | Nockenauswahl | Nockennummer (Beispiel 12) direkt eingebbar; << und >> blättern zwischen den Nocken | offen |
| RS-25-P02 | Anfang | Drei Felder: Anfangswinkel in ° (Beispiel 330 °), Kompensationszeit in ms (Beispiel 50 ms), Ergebnisfeld in ° (Beispiel 330 °, nicht editierbar) | offen |
| RS-25-P03 | Ende | Drei Felder: Endwinkel in ° (Beispiel 790 °), Kompensationszeit in ms (Beispiel 50 ms), Ergebnisfeld in ° (Beispiel 790 °, nicht editierbar) | offen |
| RS-25-P04 | Typ | Eingabefeld (Beispiel 3) mit Hinweistext „0 - 1079“ | offen |
| RS-25-P05 | Geber | Auswahl des Gebers (Beispiel „Geber 1GF Hauptantrieb“) über << und >> | offen |
| RS-25-P06 | Bezeichnung | Textfeld für Name und Beschreibung der Nocke (Beispiel „Karton ansaugen 1 3KY40“) | offen |
| RS-25-P07 | Position | Anzeige des aktuellen Gebers in ° (Beispiel 140 °), nicht editierbar | offen |
| RS-25-P08 | Status | LED zeigt, ob die Geberposition innerhalb der Nocke liegt; nicht nur über Farbe | offen |
| RS-25-P09 | Werte schreiben | Änderungen werden erst nach Betätigen der Taste aktiv | offen |
| RS-25-P10 | Navigation unten links | Tasten „<<“, „Übersicht“, „>>“; Übersicht öffnet RS-26, Pfeile blättern zwischen Nocken | offen |
| RS-25-P11 | Schlüsselsymbole | Anfang/Ende (Winkel und Zeit), Typ, Geber, Bezeichnung und Werte schreiben tragen Schlüsselsymbol | offen |
| RS-25-P12 | Zugang | Erreichbar über Einstellung › Nockenschaltwerk › Nocken | offen |
| RS-25-P13 | Bildabdeckung | RS-25_01.png ist verlinkt und beschrieben | offen |

## Offene Punkte
- Handbuch nennt „Auswahl Fixierkurve“, im Bild heißt das Feld „Nummer:“; Begriffsabgleich nötig.
- Bedeutung des dritten Feldes je Zeile Anfang/Ende (schwarz, im Bild gleich dem ersten Wert) ist nicht beschrieben (Annahme: wirkende Position nach Zeitkompensation; Annahme nur aus der Darstellung).
- Bedeutung von „0 - 1079“ neben Typ ist nicht erklärt (vermutlich Wertebereich der Position/Untersetzung; Einheit unklar). Die Typ-Werte und ihr Untersetzungsfaktor sind nicht angegeben.
- Wertebereiche für Nummer, Zeit (ms) und Winkel (Bild: 790 ° liegt über 360 °) sind nicht angegeben.
- Geber-Bezeichnung im Bild abgeschnitten („Hauptantrie“); Liste der wählbaren Geber nicht angegeben. Farbbedeutung der Status-LED nicht beschrieben.
- Berechtigung (Schlüssel) und Zusammenspiel der doppelten Pfeiltasten (Feld und Fußleiste) sind nicht beschrieben.
