# RS-14 – Einzelgewichte
- Quelle: `src_Data/Referenz/Referenz.docx`, Kapitel „Einzelgewichte“ (Kapitel 14; Zweck, Seitenübersicht, Funktionsbeschreibung), Bild [RS-14_01](../Medien/RS-14_01.png).   - Navigationspfad: Einstellung › Kontrollwaage › Einzelgewicht (Taste „Einzelgewichte“ in der Navigation unten links von [RS-13](RS-13_Kontrollwaage.md)).

## Zweck
Wortgetreu: „Die Seite Einzelgewichte zeigt eine tabellarische Historie der letzten 50 gemessenen Gewichte sowie statistische Kennzahlen. Sie dient der Kontrolle der Gewichtsgenauigkeit in der laufenden Produktion oder im Stichprobenbetrieb.“

## Aufbau (Bereiche, Layout)
Seitenbild (1024 × 768): [RS-14_01](../Medien/RS-14_01.png).

1. **Kopfzeile:** Logo „APA-TEC“, Titel „Einzelgewichte KW“ (fett, unterstrichen), Wirbelsymbol, Uhrzeit „13:03:11“, Datum „12.05.2025“.
2. **Kennzahlenzeile** (hellgrauer Streifen, 3 Paare Beschriftung + weißes Feld): „Standard-abweichung:“ (zweizeilig) → „0,7 g“; „Mittelwert:“ → „235,4 g“; „Anzahl:“ → „50“ (rote Schrift).
3. **Wertegitter** (blauer Hintergrund): 10 Zeilen × 5 Spalten = 50 Zellen. Jede Zelle: runde LED (grün mit grauem Rand) links, weißes Feld mit Gewicht rechts (Format „235,7 g“). Auf dem Bild sind alle 50 LEDs grün. Ein schwarzes Dreieck (Pfeil) steht links neben der LED in Zeile 2, Spalte 2 (Wert „234,4 g“).
   - Werte auf dem Bild (Zeile für Zeile, Spalten 1–5): Z1: 235,7 / 235,0 / 236,1 / 234,0 / 235,2; Z2: 235,3 / 234,4 (Pfeil) / 235,2 / 235,3 / 235,3; Z3: 235,6 / 235,0 / 234,4 / 234,8 / 234,9; Z4: 236,0 / 236,8 / 236,5 / 235,3 / 236,0; Z5: 234,6 / 236,2 / 236,3 / 235,7 / 235,3; Z6: 234,8 / 235,1 / 235,7 / 236,4 / 235,1; Z7: 236,7 / 237,0 / 235,2 / 234,6 / 235,8; Z8: 236,1 / 234,3 / 234,9 / 235,2 / 235,3; Z9: 234,8 / 235,3 / 235,0 / 234,5 / 234,7; Z10: 235,7 / 236,3 / 235,8 / 234,8 / 235,0 (alle in g).
4. **Meldezeile** (rot): „*450* Palettierung nicht bereit“.
5. **Untere Funktionsleiste:** links graue Taste „Fortlaufend“; Mitte gelbes Vorhängeschloss; rechts „Produktion“ (Haus), „Einstellungen“ (Zahnrad), „Zurück“ (Rücktaste).

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Tabelle 21 „Funktionsbeschreibung“ (7 Zeilen inkl. Kopfzeile = 6 Datenzeilen; Spalten Funktion | Beschreibung), Beschreibung wortgetreu:

| Nr. | Element (Handbuch: Funktion) | Typ | Funktion (Beschreibung wortgetreu) | verwendetes Modul |
|---|---|---|---|---|
| 1 | Standardabweichung | Anzeigefeld, g (Beispiel „0,7 g“) | Zeigt die Standardabweichung der gemessenen Werte an. | Modulkandidat: Kennzahl-Anzeige (Wert mit Symbol und Einheit) |
| 2 | Mittelwert | Anzeigefeld, g (Beispiel „235,4 g“) | Zeigt den Mittelwert der letzten 50 Messwerte an. | Modulkandidat: Kennzahl-Anzeige (Wert mit Symbol und Einheit) |
| 3 | Anzahl | Anzeigefeld, Stückzahl (Beispiel „50“, rote Schrift) | Anzahl zu erfassenden Werte. | Modulkandidat: Kennzahl-Anzeige (Wert mit Symbol und Einheit) |
| 4 | Werte | Wertegitter 10 × 5 mit Status-LED je Wert und Positionspfeil | Werte sind von oben nach unten und links nach rechts sortiert. Ein Pfeil zeigt auf das zuletzt erfasste Gewicht. Grüne LED zeigt ein gutes Gewicht an. Grau steht für ein schlechtes Gewicht. | Modulkandidat: Wertegitter mit Status-LED; Modulkandidat: Status-LED |
| 5 | Start | Taste | Startet ein neuer Messdurchlauf. | Modulkandidat: Schaltfläche (Funktionsleiste unten links) |
| 6 | Einzel / Fortlaufend | Umschalter (auf dem Bild Taste mit Beschriftung „Fortlaufend“) | Einzel: Manuelle Stichprobenmessung. Start löscht alle bisherigen Werte. Fortlaufend: Automatischer Betrieb. Nach Erreichen von 50 Werten wird fortlaufend überschrieben. Ermöglicht gleitenden Mittelwert. (Im Handbuch „Einzel“ und „Fortlaufend“ unterstrichen.) | Modulkandidat: Umschalter |

### Weitere Elemente laut Seitenbild (nicht in der Handbuchtabelle)
| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Kopfzeile (Logo, Titel „Einzelgewichte KW“, Wirbelsymbol, Uhrzeit, Datum) | Rahmenelement | im Handbuch nicht beschrieben | Modulkandidat: Kopfzeile |
| Meldezeile „*450* Palettierung nicht bereit“ | Statusleiste, rot | im Handbuch auf dieser Seite nicht beschrieben; siehe [RS-38](RS-38_Meldeanzeige.md) | Modulkandidat: Meldezeile |
| Vorhängeschloss (gelb), Tasten „Produktion“, „Einstellungen“, „Zurück“ | Funktionsleiste | im Handbuch nicht beschrieben | Modulkandidat: Funktionsleiste |

## Bilder
| Nr. | Datei | Pixel | Position | Beschreibung (angesehen) |
|---|---|---|---|---|
| 1 | [RS-14_01.png](../Medien/RS-14_01.png) | 1024 × 768 | Seitenübersicht | Gesamtseite Einzelgewichte KW, Aufbau und alle 50 Werte siehe Abschnitt „Aufbau“. Kennzahlen: Standardabweichung 0,7 g; Mittelwert 235,4 g; Anzahl 50 (rot). 50 grüne LEDs, ein Pfeil in Zeile 2/Spalte 2, Taste „Fortlaufend“ links unten. |

## Verwendete Module (IDs)
RM-IDs werden später vergeben. Modulkandidaten:
- Modulkandidat: Kopfzeile
- Modulkandidat: Meldezeile
- Modulkandidat: Funktionsleiste
- Modulkandidat: Kennzahl-Anzeige (Wert mit Symbol und Einheit)
- Modulkandidat: Wertegitter mit Status-LED
- Modulkandidat: Status-LED
- Modulkandidat: Umschalter

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- **Pop-ups:** keine beschrieben.
- **Berechtigungen:** keine beschrieben; auf dem Bild haben die Felder kein Schlüsselsymbol.
- **Modus Einzel:** manuelle Stichprobenmessung; „Start“ löscht alle bisherigen Werte.
- **Modus Fortlaufend:** automatischer Betrieb; nach 50 Werten wird fortlaufend überschrieben; ermöglicht gleitenden Mittelwert.
- **LED je Wert:** grün = gutes Gewicht; grau = schlechtes Gewicht.
- **Pfeil:** zeigt auf das zuletzt erfasste Gewicht.
- **Navigation:** Zurück zur Kontrollwaage über „Zurück“ bzw. Funktionsleiste; Produktion / Einstellungen rechts in der Funktionsleiste.
- **Fehlerfälle:** im Handbuch keine beschrieben.

## Prüfpunkte (Tabelle: ID | Prüfung | erwartetes Ergebnis | Status)
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RS-14-P01 | Zugang | Einstellung › Kontrollwaage › Einzelgewicht über Taste „Einzelgewichte“ in RS-13 | offen |
| RS-14-P02 | Kennzahlen oben | Standardabweichung (g), Mittelwert der letzten 50 Messwerte (g) und Anzahl (Wert 50) angezeigt | offen |
| RS-14-P03 | Wertegitter | 50 Werte im Format „xxx,x g“, angeordnet 10 Zeilen × 5 Spalten, mit je einer LED | offen |
| RS-14-P04 | Sortierung | von oben nach unten und links nach rechts sortiert | offen |
| RS-14-P05 | Positionspfeil | ein Pfeil zeigt auf das zuletzt erfasste Gewicht | offen |
| RS-14-P06 | LED-Bedeutung | grün = gutes Gewicht, grau = schlechtes Gewicht (Zustand nicht nur über Farbe, im Konzept zusätzlich Symbol/Text vorzusehen) | offen |
| RS-14-P07 | Taste „Start“ | startet einen neuen Messdurchlauf | offen |
| RS-14-P08 | Umschalter Einzel / Fortlaufend | Einzel: manuelle Stichprobe, Start löscht alle bisherigen Werte; Fortlaufend: nach 50 Werten wird überschrieben, gleitender Mittelwert | offen |
| RS-14-P09 | Seitenbild verlinkt und beschrieben | RS-14_01 verlinkt, Beschreibung vorhanden | offen |
| RS-14-P10 | Vollständigkeit Tabelle 21 | 6 Datenzeilen erfasst | offen |

## Offene Punkte
1. **Taste „Start“** ist in der Tabelle beschrieben, aber auf dem Seitenbild nicht zu sehen; dort ist nur die Taste „Fortlaufend“ links unten sichtbar. Position/Aussehen von „Start“ unklar.
2. **Umschalter Einzel/Fortlaufend:** Auf dem Bild steht „Fortlaufend“ als Taste; unklar, ob die Beschriftung den aktuellen Modus oder die Aktion beim Antippen zeigt; Standardmodus unbekannt.
3. **Sortierung/Pfeil:** Pfeil steht auf dem Bild in Zeile 2, Spalte 2; mit der Beschreibung („von oben nach unten und links nach rechts“) nicht eindeutig vereinbar (spalten- oder zeilenweise?).
4. **Anzahl** („Anzahl zu erfassenden Werte“, rote Schrift): unklar, ob einstellbar (kein Schlüsselsymbol), Wertebereich/Standard nicht angegeben; bei Maximum 50.
5. **Grau = schlechtes Gewicht:** Kriterium für „gut/schlecht“ nicht beschrieben (vermutlich Grenzen aus RS-13); auf dem Bild kein grauer Wert sichtbar.
6. **Seitentitel „Einzelgewichte KW“** (KW = Kontrollwaage, Annahme) weicht von Kapitelname „Einzelgewichte“ und Brotkrümel „Einzelgewicht“ ab.
7. **Wertegitter:** Einheit g; Zahlenformat eine Nachkommastelle (Bild); Verhalten bei weniger als 50 Werten nicht beschrieben.
