# RS-26 – Nockenübersicht
- Quelle: Referenz.docx, Kapitel 26 „Nockenübersicht“ (Zweck, Seitenübersicht, Funktionsbeschreibung, Tabelle T36 mit 5 Zeilen inkl. Kopfzeile); Bild [RS-26_01.png](../Medien/RS-26_01.png)
- Navigationspfad: Einstellung › Nockenschaltwerk › Nocken › Übersicht (Taste „Übersicht“ in der Navigation unten links von [RS-25](RS-25_Nocken.md)); Tippen auf die Nockennummer führt zurück zur Einstellseite der Nocke

## Zweck
Die Seite Nockenübersicht zeigt alle in der Maschine konfigurierten Nocken in tabellarischer Form. Über die Oberfläche ist eine schnelle Navigation zur jeweiligen Einstellseite möglich.

## Aufbau (Bereiche, Layout)
Beschreibung des Bildes [RS-26_01.png](../Medien/RS-26_01.png) (Altes HMI, 1024 × 768):

- **Kopfzeile:** Logo „APA-TEC GmbH – Automation and Packaging Technology“, unterstrichener Titel „Nocken Übersicht“, Wirbel-Symbol, Uhrzeit „13:04:23“, Datum „12.05.2025“.
- **Arbeitsbereich (blau):** Tabelle mit Spaltenköpfen „Nr.“ (links), „Start“ und „Ende“ (rechts); dazwischen eine breite, zentrierte, fette Bezeichnungsspalte ohne Spaltenkopf. Je Zeile: weißes Nummernfeld (fett), weißes Bezeichnungsfeld, Startwinkel „… °“, Endwinkel „… °“ (fett) und rechts eine runde LED. 20 Zeilen, Nr. 40 bis 59:

| Nr. | Bezeichnung (wörtlich aus dem Bild) | Start | Ende | LED |
|---|---|---|---|---|
| 40 | Start Hauptdoserer 1 | 290 ° | 130 ° | grau |
| 41 | Start Hauptdosierer 2 | 290 ° | 130 ° | grau |
| 42 | Wiegen Kontrollwaage | 40 ° | 110 ° | grau |
| 43 | Wiegen Endkontrollwaage | 40 ° | 110 ° | grau |
| 44 | Blasluft Fehlpaket 14KY23 | 290 ° | 20 ° | grau |
| 45 | Fehlpaketausstoß verriegeln 14KY21 | 200 ° | 140 ° | grün |
| 46 | Fehlaketausstoß vorne 14B10 | 10 ° | 35 ° | grau |
| 47 | Fehlpaketausstoß hinten 14B10 | 120 ° | 284 ° | grün |
| 48 | (leer) | 0 ° | 0 ° | grau |
| 49 | Start Nachdosierer | 260 ° | 130 ° | grau |
| 50 | (leer) | 0 ° | 0 ° | grau |
| 51 | Tastung Kopfleim 20B61 | 35 ° | 45 ° | grau |
| 52 | Kopfleim 20KY21 | 280 ° | 325 ° | grau |
| 53 | Ausstoßer Auslauf vorne 20B71 | 45 ° | 60 ° | grau |
| 54 | Ausstoßer Auslauf hinten 20B71 | 120 ° | 310 ° | grün |
| 55 | Paket schließen 20KY22 | 280 ° | 60 ° | grau |
| 56 | Blasluft Stempel 20KY23 | 75 ° | 130 ° | grau |
| 57 | Siegelbacken Abheben Vorsiegeln 20KY31 | 310 ° | 140 ° | grün |
| 58 | Siegelbacken Abheben Hauptsiegeln 20KY32 | 310 ° (Zeichen im Bild abgeschnitten) | 140 ° | grün |
| 59 | (leer) | 0 ° | 0 ° | grau |

  Schreibfehler in den Bezeichnungen („Hauptdoserer“, „Fehlaketausstoß“) stehen so im Bild.
- **Meldezeile (rot):** „*450* Palettierung nicht bereit“.
- **Fußleiste:** links Taste „<<“ (breit), Lücke, Taste „>>“; mittig gelbes Schloss-Symbol; rechts „Produktion“ (Haus), „Einstellungen“ (Zahnrad), „Zurück“. Keine Taste „Übersicht“ auf dieser Seite.

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Tabelle T36 (Spalten Funktion | Beschreibung), 4 Datenzeilen, wortgetreu:

| Element (Handbuch: Funktion) | Typ | Funktion (Beschreibung wörtlich) | verwendetes Modul |
|---|---|---|---|
| Nockennummer | Tippbares Nummernfeld (Spalte „Nr.“) | „Nummer der Nocke. Durch Antippen wird die zugehörige Einstellseite geöffnet.“ | Modulkandidat: Tabelle mit Nocken (Nockenzeile) |
| Start | Anzeigefeld in ° (Spalte „Start“) | „Startposition der Nocke bezogen auf den Maschinenwinkel.“ | Modulkandidat: Tabelle mit Nocken (Nockenzeile) |
| Ende | Anzeigefeld in ° (Spalte „Ende“) | „Endposition der Nocke bezogen auf den Maschinenwinkel.“ | Modulkandidat: Tabelle mit Nocken (Nockenzeile) |
| LED | Status-LED je Zeile | „Zeigt den Status der Nocke an. Leuchtet die LED grün, befindet sich die Maschine aktuell in der aktiven Phase der Nocke.“ | Modulkandidat: Status-LED |
| Bezeichnung (nur im Bild) | Anzeigefeld ohne Spaltenkopf | Name der Nocke; im Handbuchtext nicht beschrieben | Modulkandidat: Tabelle mit Nocken (Nockenzeile) |
| Tasten „<<“ und „>>“ in der Fußleiste (nur im Bild) | Tasten | Im Handbuch dieser Seite nicht beschrieben (vermutlich Blättern zwischen Nockenseiten) | Modulkandidat: Navigation unten links (Blättern mit Pfeiltasten) |
| Seitenkopf, Meldezeile, Fußleiste (nur im Bild) | Rahmen | Standardrahmen | Modulkandidat: Seitenkopf (Rahmen); Modulkandidat: Meldezeile; Modulkandidat: Fußleiste (Rahmennavigation) |

Medien dieser Seite (1 Bild):

| Bild | Zeigt |
|---|---|
| [RS-26_01.png](../Medien/RS-26_01.png) | Tabelle der Nocken 40 bis 59 mit Bezeichnung, Start, Ende und Status-LED (5 grün: 45, 47, 54, 57, 58) |

## Verwendete Module (IDs)
Noch keine RM-IDs vergeben. Modulkandidaten: Tabelle mit Nocken (Nockenzeile); Status-LED; Navigation unten links (Blättern mit Pfeiltasten); Seitenkopf (Rahmen); Meldezeile; Fußleiste (Rahmennavigation).

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- **Sprung zur Einstellseite:** Antippen der Nockennummer öffnet die zugehörige Einstellseite ([RS-25](RS-25_Nocken.md)) mit dieser Nocke.
- **LED:** grün = Maschine befindet sich aktuell in der aktiven Phase der Nocke; sonst grau (Darstellung „grau“ im Handbuch nicht beschrieben).
- **Start / Ende:** nur Anzeige, bezogen auf den Maschinenwinkel (Einheit „°“).
- **Leere Nocken:** Zeilen 48, 50 und 59 ohne Bezeichnung mit 0 ° / 0 °.
- **Blättern:** Tasten „<<“ und „>>“ in der Fußleiste; Wirkung im Handbuch nicht beschrieben.
- **Berechtigungen, Pop-ups, Fehlerfälle:** keine beschrieben; keine Schlüsselsymbole im Bild.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RS-26-P01 | Spalten | Spalten Nr., Bezeichnung (ohne Kopf), Start, Ende, LED | offen |
| RS-26-P02 | Zeilen | Im Bild 20 Zeilen, Nr. 40 bis 59, mit den Bezeichnungen und Winkeln der Tabelle in Abschnitt Aufbau | offen |
| RS-26-P03 | Nockennummer | Antippen öffnet die zugehörige Einstellseite RS-25 mit der gewählten Nocke | offen |
| RS-26-P04 | Start/Ende | Positionen in ° bezogen auf den Maschinenwinkel, nur Anzeige | offen |
| RS-26-P05 | LED | Grün, wenn die Maschine in der aktiven Phase der Nocke ist (Beispiel Nr. 45, 47, 54, 57, 58 grün); Zustand nicht nur über Farbe erkennbar | offen |
| RS-26-P06 | Leere Nocken | Nr. 48, 50, 59 erscheinen ohne Bezeichnung mit 0 ° / 0 ° und grauer LED | offen |
| RS-26-P07 | Fußleiste | Tasten „<<“ und „>>“, Produktion, Einstellungen, Zurück vorhanden; keine Taste „Übersicht“ | offen |
| RS-26-P08 | Zugang | Erreichbar aus RS-25 über „Übersicht“ | offen |
| RS-26-P09 | Bildabdeckung | RS-26_01.png ist verlinkt und beschrieben | offen |

## Offene Punkte
- Wirkung der Tasten „<<“ / „>>“ (Seitenwechsel durch weitere Nocken, vermutlich 20 pro Seite) und Gesamtzahl der Nocken sind im Handbuch nicht beschrieben.
- Bezeichnungsspalte hat im Handbuch keinen Eintrag; Schreibfehler in Bezeichnungen aus dem Bild („Hauptdoserer“, „Fehlaketausstoß“) – wortgetreu übernommen oder im neuen HMI korrigieren?
- Start 310 ° in Zeile 58 im Bild abgeschnitten (Einheit-Zeichen unvollständig).
- Bedeutung grauer LED und Behandlung von Start > Ende (Nocke über 0 °) sind nicht beschrieben.
- Ob die Nockenübersicht im Unterschied zur Einstellseite ohne Berechtigung nutzbar ist, ist nicht beschrieben.
