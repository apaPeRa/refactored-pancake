# RS-36 – Service
- Quelle: Referenz.docx, Kapitel 36 „Service“ (Zweck, Seitenübersicht, Funktionsbeschreibung, Tabelle 46); Bild [RS-36_01.png](../Medien/RS-36_01.png)   - Navigationspfad: Einstellung › Systemeinstellungen › Service (Taste „Service“ in [RS-35](RS-35_Systemeinstellungen.md))

## Zweck
Wortgetreu: „Diese Seite dient der Sicherung und Wiederherstellung von Maschinenparametern. Alle oder ausgewählte Variablen inklusive ihrer aktuellen Werte können in einer Datei gespeichert und bei Bedarf wieder eingelesen werden.“

## Aufbau (Bereiche, Layout)
Beschreibung von [RS-36_01.png](../Medien/RS-36_01.png):
- **Kopfzeile:** Logo APA-TEC, Seitentitel „Service“ (unterstrichen), rechts neben dem Wirbelsymbol roter Schriftzug „Service“, Uhrzeit 13:06:36, Datum 12.05.2025.
- **Links (breit):** oben ein leeres weißes Eingabefeld (Textzeile, vermutlich Suchfeld/Filter, im Handbuch nicht beschrieben); darunter eine scrollbare Liste mit Variablennamen, z. B. „.G_astGeber[1].alrPos[1]“ … „.G_astGeber[1].alrPos[12]“, „.G_astGeber[1].lrPeriode“, „.G_astGeber[1].lrVel“, „.G_astGeber[1].sName“, „.G_astGeber[1].xDirection“, „.G_astGeber[2].alrPos[1]“ … ; ein Eintrag (.G_astGeber[1].alrPos[10]) ist blau markiert; Rollbalken rechts. Unter der Liste, rechtsbündig, klein: „500 von 111427 Variablen“.
- **Rechts oben:** weißes Anzeigefeld mit rotem Zahlenwert „859,81“ (Bedeutung nicht beschrieben; vermutlich Wert der markierten Variable).
- **Rechts:** drei große graue Tasten untereinander: „Importieren“, „Alle Exportieren“, „Liste Exportieren“.
- **Meldezeile:** rot, „*450* Palettierung nicht bereit“.
- **Untere Leiste:** links Taste „Wago“ (statt „Lampentest“); Vorhängeschloss (offen, gelb); rechts „Produktion“ (Haus), „Einstellungen“ (Zahnrad), „Zurück“.

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Alle 3 Zeilen der Tabelle 46, wortgetreu:

| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Importieren | Taste | „Lädt eine zuvor gespeicherte Datei mit Variablenwerten und stellt die enthaltenen Werte wieder her.“ | Modulkandidat: Standardtaste (Aktion) |
| Alle exportieren | Taste (im Bild „Alle Exportieren“) | „Speichert sämtliche aktuellen Variablen der Maschine in einer Datei.“ | Modulkandidat: Standardtaste (Aktion) |
| Liste exportieren | Taste (im Bild „Liste Exportieren“) | „Speichert nur die in der Liste ausgewählten Variablen in einer Datei.“ | Modulkandidat: Standardtaste (Aktion) |

Nur im Bild sichtbar (nicht im Handbuch beschrieben):

| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Eingabefeld über der Liste | Textfeld | nicht beschrieben | Modulkandidat: Eingabefeld (Text) |
| Variablenliste (500 von 111427 Variablen) | scrollbare Auswahlliste, Zeile markierbar | „in der Liste ausgewählte Variablen“ (Handbuch) | Modulkandidat: Auswahlliste mit Rollbalken |
| Zahlenanzeige „859,81“ (rot) | Anzeigefeld | nicht beschrieben | Modulkandidat: Wertanzeige-Feld |
| Roter Schriftzug „Service“ im Kopf | Statusanzeige | nicht beschrieben (vermutlich Hinweis auf aktiven Servicemodus) | Modulkandidat: Kopfzeile |
| Taste „Wago“ | Taste | nicht beschrieben | Modulkandidat: Funktionsleiste unten |
| Meldezeile, Navigationstasten Produktion/Einstellungen/Zurück, Schloss | Rahmen | siehe [RS-35](RS-35_Systemeinstellungen.md) | Modulkandidat: Meldezeile; Modulkandidat: Funktionsleiste unten |

## Verwendete Module (IDs)
Noch keine RM-IDs. Modulkandidaten: Standardtaste (Aktion), Eingabefeld (Text), Auswahlliste mit Rollbalken, Wertanzeige-Feld, Kopfzeile, Meldezeile, Funktionsleiste unten.

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- Berechtigung: Die Taste „Service“ in RS-35 trägt ein Schlüsselsymbol; auf der Seite selbst zeigen die Tasten keine Schlüsselsymbole.
- Ausgewählte Zeile: blau hinterlegt. Mehrfachauswahl nicht beschrieben.
- Pop-ups (Dateiauswahl, Fortschritt, Fehler beim Import/Export): im Handbuch nicht beschrieben.
- Fehlerfälle: nicht beschrieben.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RS-36-P01 | Navigationspfad | Einstellung › Systemeinstellungen › Service, Zugang über Taste „Service“ in RS-35 | offen |
| RS-36-P02 | Tasten rechts | „Importieren“, „Alle Exportieren“, „Liste Exportieren“ vorhanden | offen |
| RS-36-P03 | Importieren | Datei mit Variablenwerten wird geladen, Werte werden wiederhergestellt | offen |
| RS-36-P04 | Alle exportieren | Sämtliche aktuellen Variablen werden in einer Datei gespeichert | offen |
| RS-36-P05 | Liste exportieren | Nur die in der Liste ausgewählten Variablen werden in einer Datei gespeichert | offen |
| RS-36-P06 | Variablenliste | Scrollbare Liste mit Variablennamen, Auswahlzeile markiert (blau) | offen |
| RS-36-P07 | Mengenanzeige | Text „500 von 111427 Variablen“ unter der Liste (Format: n von m Variablen) | offen |
| RS-36-P08 | Eingabefeld und Zahlenfeld | Leeres Eingabefeld über der Liste; Anzeigefeld rechts oben (im Bild „859,81“, rot) | offen |
| RS-36-P09 | Kopfzeile | Titel „Service“, roter Schriftzug „Service“, Uhrzeit und Datum | offen |
| RS-36-P10 | Untere Leiste | Taste „Wago“ links, Schloss, Produktion, Einstellungen, Zurück | offen |

## Offene Punkte
- Funktion des Eingabefelds über der Liste (Suche/Filter?) und der roten Zahl „859,81“ nicht beschrieben.
- Bedeutung „500 von 111427“ (Anzeigelimit? Treffer?) und Auswahlmodus der Liste nicht beschrieben.
- Dateiformat, Speicherort und Dateiauswahldialog für Import/Export nicht beschrieben.
- Funktion der Taste „Wago“ und des roten Schriftzugs „Service“ im Kopf nicht beschrieben.
- Schreibweise Handbuch „Alle exportieren“ vs. Bild „Alle Exportieren“.
