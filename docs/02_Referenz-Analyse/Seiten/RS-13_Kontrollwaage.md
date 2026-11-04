# RS-13 – Kontrollwaage
- Quelle: `src_Data/Referenz/Referenz.docx`, Kapitel „Kontrollwaage“ (Kapitel 13; Zweck, Seitenübersicht, Funktionsbeschreibung › Hauptbereich, Navigation (unten links)); Bilder [RS-13_01](../Medien/RS-13_01.png) bis [RS-13_14](../Medien/RS-13_14.png), siehe [Medienliste](../Medien/Medienliste.md).   - Navigationspfad: Einstellung › Kontrollwaage (Eintrag in [RS-04](RS-04_Einstellungen.md)); Untergeordnet: Einzelgewicht ([RS-14](RS-14_Einzelgewichte.md)), Trend ([RS-15](RS-15_Trend.md)).

## Zweck
Wortgetreu: „Auf dieser Seite haben Sie die Möglichkeit, die Kontrollwaage zu beobachten und Einstellungen an den Zielgewichten und statistischen Werten vorzunehmen. Zusätzlich werden Werte angezeigt, die zur Berechnung der Nachdosierung dienen.“

## Aufbau (Bereiche, Layout)
Seitenbild (1024 × 768, 4:3): [RS-13_01](../Medien/RS-13_01.png). Blauer Arbeitsbereich zwischen Kopfzeile und Meldezeile. Von oben nach unten:

1. **Kopfzeile** (hellgrau): links Logo „APA-TEC GmbH Automation and Packaging Technology“; Mitte Seitentitel „Kontrollwaage“ (fett, unterstrichen); rechts davon ein schwarzes Wirbel-/Spiralsymbol (im Handbuch nicht erklärt); rechts Uhrzeit „13:02:51“ und darunter Datum „12.05.2025“.
2. **Zeile Netto:** Beschriftung „Netto:“ (fett, groß), weißes Anzeigefeld „0,0 g“ (groß, fett), rechts daneben Waagensymbol ([RS-13_02](../Medien/RS-13_02.png)).
3. **Zeile Brutto/Live** mit Taste rechts: „Brutto:“ weißes Feld „0,0 g“ + Waagensymbol; „Live:“ weißes Feld „-399,0 g“ + Waagensymbol; ganz rechts graue Taste „Nullpunkt setzen“ mit gelbem Schlüsselsymbol oben rechts.
4. **Statistikzeile** (3 Spalten, je Symbol links + weißes Feld mit schwarzer Schrift): Mittelwert-Symbol X̄ → „235,1 g“; Symbol „S“ → „1,2 g“; Tachosymbol → „114,6 1/min“.
5. **Parameterzeile 1** (je Symbol + weißes Feld mit **roter** Schrift und kleinem gelben Schlüsselsymbol oben rechts): Sollgewicht-Symbol (blaue Packung mit grünem Haken) → „235,0 g“; Tara-Symbol → „15,0 g“; Symbol „Pfeile gegeneinander“ → „5000 Stk“ mit kleiner Zahl „104“ unten rechts im Feld.
6. **Parameterzeile 2 mit Zählern** (je Spalte oben ein rotes Eingabefeld mit Schlüsselsymbol, darunter ein weißes Zählfeld mit schwarzer Schrift): Spalte 1 Übergewicht-Symbol (blaue Packung mit rotem Kreuz) → „268,0 g“, darunter „435“; Spalte 2 Symbol „Tu1“ → „200,0 g“, darunter „0“; Spalte 3 Symbol „Tu2“ → „200,0 g“, darunter „1093“.
7. **Zählerzeile:** grünes Kreis-Symbol mit Haken → „874794“; Beschriftung „T1 %:“ → „0,000“; rotes Kreis-Symbol mit weißem Kreuz → „1528“; rechts graue Taste „Zähler löschen“ mit gelbem Schlüsselsymbol.
8. **Meldezeile** (rot, volle Breite): „*450* Palettierung nicht bereit“.
9. **Untere Funktionsleiste:** links Tasten „Trend“ (mit Liniendiagramm-Symbol) und „Einzelgewichte“ (mit Listensymbol; Navigation unten links), in der Mitte ein gelbes Vorhängeschloss-Symbol (geschlossen), rechts „Produktion“ (Haus-Symbol), „Einstellungen“ (Zahnrad-Symbol), „Zurück“ (Rücktasten-Symbol).

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Tabelle 19 „Hauptbereich“ (18 Zeilen inkl. Kopfzeile = 17 Datenzeilen; Spalten Funktion | Beschreibung | Grafik) und Tabelle 20 „Navigation (unten links)“ (3 Zeilen inkl. Kopfzeile = 2 Datenzeilen) vollständig. Die Spalte „Funktion“ enthält die Beschreibung wortgetreu aus dem Handbuch; „Bild“ nennt die Grafik der Tabellenzeile. Werte-Beispiele stammen aus [RS-13_01](../Medien/RS-13_01.png).

### Tabelle 19 – Hauptbereich
| Nr. | Element (Handbuch: Funktion) | Typ | Funktion (Beschreibung wortgetreu) | Bild (Spalte „Grafik“) | verwendetes Modul |
|---|---|---|---|---|---|
| 1 | Netto | Anzeigefeld, Gewicht, Einheit g (Beispiel „0,0 g“) | Zeigt das aktuelle berechnete Nettogewicht der Packung an. | [RS-13_02](../Medien/RS-13_02.png) | [RM-12](../Module/RM-12_Kennzahl-Kachel.md) (Wert mit Symbol und Einheit) |
| 2 | Brutto | Anzeigefeld, Gewicht, g (Beispiel „0,0 g“) | Zeigt das aktuelle Bruttogewicht inklusive Tara an. | [RS-13_03](../Medien/RS-13_03.png) | [RM-12](../Module/RM-12_Kennzahl-Kachel.md) (Wert mit Symbol und Einheit) |
| 3 | Live | Anzeigefeld, Gewicht, g (Beispiel „-399,0 g“) | Zeigt den ungefilterten Rohwert der Waage. Hilfreich für Diagnosen. | [RS-13_04](../Medien/RS-13_04.png) | [RM-12](../Module/RM-12_Kennzahl-Kachel.md) (Wert mit Symbol und Einheit) |
| 4 | Mittelwert | Anzeigefeld, Gewicht, g (Beispiel „235,1 g“) | Zeigt den Mittelwert der zuletzt gewogenen Packungen an. | [RS-13_05](../Medien/RS-13_05.png) | [RM-12](../Module/RM-12_Kennzahl-Kachel.md) (Wert mit Symbol und Einheit) |
| 5 | Standardabweichung | Anzeigefeld, Gewicht, g (Beispiel „1,2 g“) | Zeigt die Standardabweichung der zuletzt gewogenen Packungen an. | kein Bild; im Handbuch steht in der Grafik-Spalte der fette Buchstabe „S“ (auf dem Seitenbild als Symbol „S“) | [RM-12](../Module/RM-12_Kennzahl-Kachel.md) (Wert mit Symbol und Einheit) |
| 6 | Leistung Ist | Anzeigefeld, Leistung, 1/min (Beispiel „114,6 1/min“) | Zeigt die durchschnittlich gewogenen Packungen pro Minute an. | [RS-13_06](../Medien/RS-13_06.png) | [RM-12](../Module/RM-12_Kennzahl-Kachel.md) (Wert mit Symbol und Einheit) |
| 7 | Sollgewicht | Eingabefeld mit Schlüsselsymbol, Gewicht, g (Beispiel „235,0 g“, rote Schrift) | Zielgewicht für die Hauptdosierer. | [RS-13_07](../Medien/RS-13_07.png) | [RM-05](../Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md); [RM-06](../Module/RM-06_Eingabe-Pop-up.md) |
| 8 | Tara | Eingabefeld mit Schlüsselsymbol, Gewicht, g (Beispiel „15,0 g“, rote Schrift) | Gewicht der leeren Packung. | [RS-13_08](../Medien/RS-13_08.png) | [RM-05](../Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md); [RM-06](../Module/RM-06_Eingabe-Pop-up.md) |
| 9 | Automatischer Nullpunkt | Eingabefeld mit Schlüsselsymbol, Stückzahl, Stk (Beispiel „5000 Stk“, rote Schrift) mit Zusatzwert unten rechts (Beispiel „104“) | Hier kann angegeben werden nach wieviel Packungen die Maschine einen automatischen Nullpunkt durchführen soll. 0 deaktiviert den automatischen Nullpunkt. Der kleiner Wert unten rechts zeigt die Packungen seit dem letzten Nullpunkt an. | [RS-13_09](../Medien/RS-13_09.png) | [RM-05](../Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) (mit Zusatzzähler); [RM-06](../Module/RM-06_Eingabe-Pop-up.md) |
| 10 | Übergewicht | Eingabefeld mit Schlüsselsymbol, Gewicht, g (Beispiel „268,0 g“, rote Schrift) + darunter Zählfeld (Beispiel „435“) | Packungen mit einem Produktgewicht gleich oder größer werden als schlecht markiert und ausgeworfen. Zählwert zeigt die Anzahl schlechter Packungen seit dem letzten *Zähler löschen*. | [RS-13_10](../Medien/RS-13_10.png) | [RM-05](../Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md); [RM-06](../Module/RM-06_Eingabe-Pop-up.md); [RM-12](../Module/RM-12_Kennzahl-Kachel.md) |
| 11 | Untergewicht TU 1 (Handbuch: „UntergewichtTU 1“, zweizeilig „Untergewicht / TU 1“) | Eingabefeld mit Schlüsselsymbol, Gewicht, g (Beispiel „200,0 g“, rote Schrift) + darunter Zählfeld (Beispiel „0“) | Packungen mit einem Produktgewicht gleich oder kleiner werden als schlecht markiert und ausgeworfen, wenn kein Guthaben mehr vorhanden ist. Zählwert zeigt die Anzahl schlechter Packungen seit dem letzten *Zähler löschen*. | [RS-13_11](../Medien/RS-13_11.png) | [RM-05](../Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md); [RM-06](../Module/RM-06_Eingabe-Pop-up.md); [RM-12](../Module/RM-12_Kennzahl-Kachel.md) |
| 12 | Untergewicht TU 2 | Eingabefeld mit Schlüsselsymbol, Gewicht, g (Beispiel „200,0 g“, rote Schrift) + darunter Zählfeld (Beispiel „1093“) | Packungen mit einem Produktgewicht gleich oder kleiner werden als schlecht markiert und ausgeworfen. Zählwert zeigt die Anzahl schlechter Packungen seit dem letzten *Zähler löschen*. | [RS-13_12](../Medien/RS-13_12.png) | [RM-05](../Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md); [RM-06](../Module/RM-06_Eingabe-Pop-up.md); [RM-12](../Module/RM-12_Kennzahl-Kachel.md) |
| 13 | Gut-Packungen | Zählfeld (Beispiel „874794“) | Anzahl Gut Packungen seit dem letzten *Zähler löschen* | [RS-13_13](../Medien/RS-13_13.png) | [RM-12](../Module/RM-12_Kennzahl-Kachel.md) |
| 14 | T1 % | Anzeigefeld, Verhältnis, % laut Beschreibung (Beispiel „0,000“; Beschriftung „T1 %:“) | Prozentuale Verhältnis der Schlecht-Packungen von Tu1 zu Tu2. | kein Bild (Grafik-Zelle leer) | [RM-12](../Module/RM-12_Kennzahl-Kachel.md) (Wert mit Symbol und Einheit) |
| 15 | Schlecht Packungen | Zählfeld (Beispiel „1528“) | Anzahl Schlecht Packungen seit dem letzten *Zähler löschen*. | [RS-13_14](../Medien/RS-13_14.png) | [RM-12](../Module/RM-12_Kennzahl-Kachel.md) |
| 16 | Taste Nullpunkt setzen | Taste mit Schlüsselsymbol | Setzt den Waagen-Nullpunkt neu. Es muss sichergestellt sein, dass die Waage unbelastet und sauber ist. | kein Bild (Grafik-Zelle leer) | [RM-11](../Module/RM-11_Aktionstaste.md) mit Schlüsselsymbol |
| 17 | Taste Zähler löschen | Taste mit Schlüsselsymbol | Setzt alle Zählwerte auf dieser Seite auf 0. | kein Bild (Grafik-Zelle leer) | [RM-11](../Module/RM-11_Aktionstaste.md) mit Schlüsselsymbol |

### Tabelle 20 – Navigation (unten links)
| Nr. | Funktion | Typ | Beschreibung (wortgetreu) | verwendetes Modul |
|---|---|---|---|---|
| 18 | Trend | Taste mit Liniendiagramm-Symbol, links in der Funktionsleiste | Zeigt den Verlauf der letzten 50 Packungen in einem Diagramm an. | [RM-03](../Module/RM-03_Funktionsleiste-unten.md) |
| 19 | Einzelgewicht | Taste „Einzelgewichte“ mit Listensymbol, links in der Funktionsleiste | Zeigt bis zu 50 letzten Gewichte tabellarisch an. | [RM-03](../Module/RM-03_Funktionsleiste-unten.md) |

### Weitere Elemente laut Seitenbild (nicht in den Handbuchtabellen)
| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Kopfzeile (Logo, Titel „Kontrollwaage“, Wirbelsymbol, Uhrzeit, Datum) | Rahmenelement | im Handbuch nicht beschrieben | [RM-01](../Module/RM-01_Kopfzeile.md) |
| Meldezeile „*450* Palettierung nicht bereit“ | Statusleiste, rot | im Handbuch auf dieser Seite nicht beschrieben; Antippen siehe [RS-38](RS-38_Meldeanzeige.md) | [RM-02](../Module/RM-02_Meldezeile.md) |
| Vorhängeschloss (gelb, geschlossen) | Symbol, Mitte der Funktionsleiste | im Handbuch nicht beschrieben | [RM-03](../Module/RM-03_Funktionsleiste-unten.md) (Berechtigungsanzeige) |
| Tasten „Produktion“, „Einstellungen“, „Zurück“ | Navigationstasten, rechts in der Funktionsleiste | im Handbuch auf dieser Seite nicht beschrieben | [RM-03](../Module/RM-03_Funktionsleiste-unten.md) |

## Bilder
Alle 14 Bilder der Seite (1 Fließtextbild, 13 Bilder in den Zellen der Tabelle 19, Spalte „Grafik“). Mehrfach verwendete Originale: `image7.png` in Zeilen 1–3, vgl. [Medienliste](../Medien/Medienliste.md).

| Nr. | Datei | Pixel | Position | Beschreibung (angesehen) |
|---|---|---|---|---|
| 1 | [RS-13_01.png](../Medien/RS-13_01.png) | 1024 × 768 | Seitenübersicht | Gesamtseite Kontrollwaage, Aufbau siehe Abschnitt „Aufbau“. Alle Feldwerte: Netto 0,0 g; Brutto 0,0 g; Live -399,0 g; Mittelwert 235,1 g; S 1,2 g; Leistung 114,6 1/min; Soll 235,0 g; Tara 15,0 g; Autom. Nullpunkt 5000 Stk (Zusatzwert 104); Übergewicht 268,0 g (435); Tu1 200,0 g (0); Tu2 200,0 g (1093); Gut 874794; T1 % 0,000; Schlecht 1528; Meldung „*450* Palettierung nicht bereit“. |
| 2 | [RS-13_02.png](../Medien/RS-13_02.png) | 48 × 48 | Tab. 19 Zeile 1 (Netto) | Schwarzes Waagensymbol: oben breite Platte, darunter halbkreisförmige Skala mit Zeiger. |
| 3 | [RS-13_03.png](../Medien/RS-13_03.png) | 48 × 48 | Tab. 19 Zeile 2 (Brutto) | Dasselbe Waagensymbol wie Bild 2 (gleiches Original). |
| 4 | [RS-13_04.png](../Medien/RS-13_04.png) | 48 × 48 | Tab. 19 Zeile 3 (Live) | Dasselbe Waagensymbol wie Bild 2 (gleiches Original). |
| 5 | [RS-13_05.png](../Medien/RS-13_05.png) | 48 × 48 | Tab. 19 Zeile 4 (Mittelwert) | Schwarzes „X“ mit Querstrich darüber (X̄, Mittelwert-Symbol). |
| 6 | [RS-13_06.png](../Medien/RS-13_06.png) | 48 × 48 | Tab. 19 Zeile 6 (Leistung Ist) | Schwarzes Tachometer-Symbol (Kreis mit Zeiger). |
| 7 | [RS-13_07.png](../Medien/RS-13_07.png) | 41 × 56 | Tab. 19 Zeile 7 (Sollgewicht) | Blaue Packung (hochkant) mit grünem Haken. |
| 8 | [RS-13_08.png](../Medien/RS-13_08.png) | 57 × 67 | Tab. 19 Zeile 8 (Tara) | Hochkant-Rechteck mit der um 90° gedrehten Aufschrift „Tara“. |
| 9 | [RS-13_09.png](../Medien/RS-13_09.png) | 48 × 48 | Tab. 19 Zeile 9 (Automatischer Nullpunkt) | Schwarzer senkrechter Strich, von links und rechts je ein Pfeil darauf zu. |
| 10 | [RS-13_10.png](../Medien/RS-13_10.png) | 69 × 92 | Tab. 19 Zeile 10 (Übergewicht) | Blaue, oben und unten abgerundete Packung (breit) mit rotem Kreuz am unteren Rand. |
| 11 | [RS-13_11.png](../Medien/RS-13_11.png) | 65 × 89 | Tab. 19 Zeile 11 (Untergewicht TU 1) | Blaue Packung mit rotem Kreuz und der Aufschrift „Tu1“ (fett, schwarz) am oberen Rand. |
| 12 | [RS-13_12.png](../Medien/RS-13_12.png) | 59 × 86 | Tab. 19 Zeile 12 (Untergewicht TU 2) | Blaue Packung mit rotem Kreuz und der Aufschrift „Tu2“. |
| 13 | [RS-13_13.png](../Medien/RS-13_13.png) | 100 × 100 | Tab. 19 Zeile 13 (Gut-Packungen) | Grüner Kreis mit weißem Haken. |
| 14 | [RS-13_14.png](../Medien/RS-13_14.png) | 76 × 76 | Tab. 19 Zeile 15 (Schlecht Packungen) | Roter Kreis mit weißem Kreuz. |

## Verwendete Module (IDs)

Module dieser Seite (Definitionen in der [Modulliste](../Module/Modulliste.md)):

- [RM-01](../Module/RM-01_Kopfzeile.md) – Kopfzeile
- [RM-02](../Module/RM-02_Meldezeile.md) – Meldezeile
- [RM-03](../Module/RM-03_Funktionsleiste-unten.md) – Funktionsleiste unten
- [RM-05](../Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) – Eingabefeld mit Schlüsselsymbol
- [RM-06](../Module/RM-06_Eingabe-Pop-up.md) – Eingabe-Pop-up
- [RM-11](../Module/RM-11_Aktionstaste.md) – Aktionstaste
- [RM-12](../Module/RM-12_Kennzahl-Kachel.md) – Kennzahl-Kachel

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- **Pop-ups:** Im Handbuch sind für diese Seite keine Pop-ups beschrieben. Dass ein Antippen der roten Felder ein Eingabe-Pop-up öffnet, ist nicht beschrieben (siehe Offene Punkte).
- **Berechtigungen:** Das Handbuch erwähnt das gelbe Schlüsselsymbol nicht im Text. Auf dem Seitenbild tragen die Felder Sollgewicht, Tara, Automatischer Nullpunkt, Übergewicht, Untergewicht TU 1, Untergewicht TU 2 sowie die Tasten „Nullpunkt setzen“ und „Zähler löschen“ ein gelbes Schlüsselsymbol.
- **Darstellung:** Anzeigewerte schwarz auf Weiß; Werte mit Schlüsselsymbol rot auf Weiß; Zähler schwarz auf Weiß.
- **Automatischer Nullpunkt:** Wert 0 deaktiviert die Funktion (wortgetreu). Der kleine Zusatzwert zählt die Packungen seit dem letzten Nullpunkt.
- **Taste Nullpunkt setzen:** setzt den Waagen-Nullpunkt neu; die Waage muss unbelastet und sauber sein (Bedienhinweis, keine Abfrage beschrieben).
- **Taste Zähler löschen:** setzt alle Zählwerte der Seite auf 0 (wortgetreu: „alle Zählwerte auf dieser Seite“). Die Auslegung auf Gut, Schlecht, Zähler Übergewicht/Tu1/Tu2 ist eine Auslegung, nicht im Handbuch aufgezählt; ob auch der Zusatzzähler „104“ im Feld Automatischer Nullpunkt (Bild RS-13_01) zurückgesetzt wird, ist nicht beschrieben. Eine Rückfrage ist nicht beschrieben.
- **Ausschuss-Logik (wortgetreu):** Übergewicht: gleich oder größer → schlecht, ausgeworfen. TU 1: gleich oder kleiner → schlecht, ausgeworfen, „wenn kein Guthaben mehr vorhanden ist“. TU 2: gleich oder kleiner → schlecht, ausgeworfen.
- **Navigation:** Taste „Trend“ → [RS-15](RS-15_Trend.md); Taste „Einzelgewichte“ → [RS-14](RS-14_Einzelgewichte.md); „Produktion“, „Einstellungen“, „Zurück“ rechts in der Funktionsleiste (Annahme: Zurück führt zur vorherigen Seite; das Handbuch sagt dazu nichts).
- **Fehler-/Zustandsbeschreibungen:** Das Handbuch beschreibt keine Fehlerfälle für diese Seite. Auf dem Seitenbild steht in der Meldezeile „*450* Palettierung nicht bereit“ (rot).

## Prüfpunkte (Tabelle: ID | Prüfung | erwartetes Ergebnis | Status)
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RS-13-P01 | Brotkrümel/Zugang der Seite | Einstellung › Kontrollwaage, erreichbar über den Eintrag Kontrollwaage in RS-04 | offen |
| RS-13-P02 | Seitentitel in der Kopfzeile | „Kontrollwaage“ | offen |
| RS-13-P03 | Anzeigefelder Netto, Brutto, Live vorhanden, Einheit g | drei Felder mit Waagensymbol; Netto = berechnetes Nettogewicht, Brutto = Bruttogewicht inklusive Tara, Live = ungefilterter Rohwert der Waage | offen |
| RS-13-P04 | Anzeigefelder Mittelwert, Standardabweichung (S), Leistung Ist | Mittelwert und Standardabweichung der zuletzt gewogenen Packungen in g; Leistung Ist in Packungen pro Minute (Einheit 1/min) | offen |
| RS-13-P05 | Eingabefelder Sollgewicht, Tara | beide in g, mit Schlüsselsymbol; Sollgewicht = Zielgewicht für die Hauptdosierer; Tara = Gewicht der leeren Packung | offen |
| RS-13-P06 | Eingabefeld Automatischer Nullpunkt | Eingabe in Packungen (Stk); 0 deaktiviert die Funktion; kleiner Zusatzwert unten rechts zeigt die Packungen seit dem letzten Nullpunkt | offen |
| RS-13-P07 | Grenzwerte Übergewicht, Untergewicht TU 1, Untergewicht TU 2 je mit Zählfeld darunter | je Eingabefeld (g) mit Schlüsselsymbol und darunter ein Zählwert; Übergewicht: gleich oder größer → schlecht und ausgeworfen; TU 1: gleich oder kleiner → schlecht, ausgeworfen, wenn kein Guthaben mehr vorhanden; TU 2: gleich oder kleiner → schlecht, ausgeworfen | offen |
| RS-13-P08 | Zähler Gut-Packungen, Schlecht Packungen | Anzahl seit dem letzten „Zähler löschen“; Symbole grüner Kreis mit Haken bzw. roter Kreis mit Kreuz | offen |
| RS-13-P09 | Anzeige „T1 %“ | Beschriftung „T1 %:“, Wert mit drei Nachkommastellen (Beispiel 0,000); Bedeutung: prozentuale Verhältnis der Schlecht-Packungen von Tu1 zu Tu2 | offen |
| RS-13-P10 | Taste „Nullpunkt setzen“ | vorhanden, mit Schlüsselsymbol; setzt den Waagen-Nullpunkt neu; Hinweis, dass die Waage unbelastet und sauber sein muss | offen |
| RS-13-P11 | Taste „Zähler löschen“ | vorhanden, mit Schlüsselsymbol; setzt alle Zählwerte auf der Seite auf 0 | offen |
| RS-13-P12 | Navigation unten links | Taste „Trend“ (Verlauf in einem Diagramm) → RS-15; Taste „Einzelgewichte“ (bis zu 50 letzte Gewichte tabellarisch) → RS-14 | offen |
| RS-13-P13 | Alle 13 Tabellenbilder und das Seitenbild (14 Dateien RS-13_01 … RS-13_14) sind in der Seitendatei verlinkt und beschrieben | 14 Links auf `../Medien/RS-13_nn.png`, jedes mit Beschreibung | offen |
| RS-13-P14 | Vollständigkeit Tabelle 19 und 20 | 17 Datenzeilen Hauptbereich und 2 Datenzeilen Navigation erfasst | offen |
| RS-13-P15 | Funktionsleiste unten | Tasten Trend, Einzelgewichte (links), Vorhängeschloss (Mitte), Produktion, Einstellungen, Zurück (rechts) wie auf RS-13_01 | offen |

## Offene Punkte
1. **Schlüsselsymbol:** Bedeutung (Berechtigungsstufe) und Stufen sind im Handbuch nicht erklärt; Annahme: Schlüsselsymbol = Bedienung nur mit Berechtigung. Die Berechtigungsstufe pro Feld ist offen.
2. **Eingabe:** Wie ein Wert eingegeben wird (Pop-up, Tastenfeld), Wertebereiche, Standardwerte und Plausibilitätsprüfungen (z. B. Übergewicht > Sollgewicht > TU 1 ≥ TU 2) sind im Handbuch nicht angegeben.
3. **Einheit T1 %:** Handbuch nennt „Prozentuale Verhältnis“, Beschriftung auf dem Bild „T1 %:“, Feld ohne Einheit mit drei Nachkommastellen; ob der Wert in % oder als Anteil (0 … 1) angezeigt wird, ist unklar.
4. **Trend-Umfang:** Navigationstabelle: „Verlauf der letzten 50 Packungen“; [RS-15](RS-15_Trend.md) nennt 20 Gewichte (Bild zeigt 21 Punkte). Widerspruch.
5. **Wirbelsymbol** in der Kopfzeile und **Vorhängeschloss** in der Funktionsleiste sind im Handbuch nicht beschrieben.
6. **Untergewicht TU 1/TU 2:** Der Begriff „Guthaben“ ist nicht erklärt; Unterschied TU 1/TU 2 nur über diesen Satz erkennbar. Beschriftung im Handbuch teils „UntergewichtTU 1“ ohne Leerzeichen.
7. **Zusatzwert „104“** im Feld Automatischer Nullpunkt: laut Text „Packungen seit dem letzten Nullpunkt“; Einheit nicht angegeben.
8. **Tacho-Symbol** (Leistung Ist) ähnelt dem Tachosymbol in RS-03; Zusammenhang zu einem Pop-up auf dieser Seite nicht beschrieben.
9. **Sperrzustände** (Verhalten der Tasten bei fehlender Berechtigung oder laufender Produktion) nicht beschrieben.
