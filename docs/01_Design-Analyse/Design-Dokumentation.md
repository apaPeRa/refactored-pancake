# Design-Dokumentation

Grundlage: die fünf PNG-Screenshots in `src_Data/Design` (PowerPoint-Entwurf, **nicht final**). Farbwerte sind **Hex-Schätzungen** aus dem Bild, keine Vorgaben. Alle Zahlen, Texte und Namen stammen aus den Bildern; was nicht sichtbar ist, steht in `docs/00_Plan/Offene-Punkte.md`.

## 1. Quellen

| ID | Datei | Seite | Brotkrümel (sichtbar) |
|---|---|---|---|
| DS-01 | `Seite_Produktion.png` | Produktion | Produktion |
| DS-02 | `Seite_Einstellungen.png` | Einstellungen | Einstellung |
| DS-03 | `Seite_Heissleim.png` | Heißleim | Einstellung › Zuführungen › Heißleim |
| DS-04 | `Seite_Dosierer.png` | Dosierer | Einstellung › Dosierer |
| DS-05 | `Seite_Kartonzufuehrung.png` | Kartonzuführung | Einstellung › Zuführungen › Karton |

Seitenbeschreibungen: [DS-01](Seiten/DS-01_Produktion.md), [DS-02](Seiten/DS-02_Einstellungen.md), [DS-03](Seiten/DS-03_Heissleim.md), [DS-04](Seiten/DS-04_Dosierer.md), [DS-05](Seiten/DS-05_Kartonzufuehrung.md).

Bildgröße: ca. 1390 × 785 Pixel (Seitenverhältnis ca. 1,77 : 1, also annähernd 16 : 9). Alle Pixelangaben unten beziehen sich auf diese Bildgröße und sind Schätzwerte; sie müssen auf 1920 × 1080 proportional umgerechnet werden (Faktor ca. 1,38).

## 2. Rahmen (auf allen fünf Seiten identisch)

```
+------+-----------------------------------------------------------------+
|      | Logo | Meldezeile (gelb)              | Betriebsart | Uhr/Datum |   Kopfzeile  (y 0-75)
| Seiten+-----------------------------------------------------------------+
| leiste| Brotkrümel                      [Geschwindigkeit] [Winkel]      |   Zeile 2    (y 80-130)
| (x    +-----------------------------------------------------------------+
| 0-100)|                                                                 |
|      |                  Inhaltsbereich                                  |   (y 135-720)
|      |                                                                 |
|      +-----------------------------------------------------------------+
|      | Funktionsleiste (hellblau)                                      |   (y 725-775)
+------+-----------------------------------------------------------------+
```

| Bereich | Lage (Bild, ca.) | Inhalt | Modul |
|---|---|---|---|
| Seitenleiste | x 0–102, volle Höhe, Blau `#4472C4` | oben Benutzerkreis „MM“ (orange `#ED7D31`) mit Text „Max Mustermann“ (Name, blassblau) und „Technik“ (Rolle, orange/ocker); darunter 3 Symbole (Home, Zahnrad, Sprechblase mit Ausrufezeichen in Gelb); ganz unten Symbol „Zurück“ (Rücktaste mit X) | DM-01, DM-02 |
| Logo | x 105–555, y 5–68, weiß | „APA-TEC GmbH AUTOMATION AND PACKAGING TECHNOLOGY“, Logo in Dunkelblau/Grau | DM-03 |
| Meldezeile | x 556–1037, Amber `#FFC000` | Text „014: Sicherung 4F24 Auslaufband ausgelöst.“ in Orangebraun (`#C55A11`), identisch auf allen Seiten | DM-04 |
| Betriebsart | x 1040–1270, Grün `#70AD47` | Symbol „kreisförmige Pfeile“ und Text „Produktion“ in Weiß | DM-05 |
| Uhrzeit/Datum | x 1272–1388, Blau `#2E75B6` | „9:15“ und „06.01.2026“ in Weiß | DM-06 |
| Brotkrümel | x 108 ff., y 82–130 | Pfeil-/Chevron-Segmente, Text schwarz, klein | DM-07 |
| Kennzahl Geschwindigkeit | x 1055–1237, y 83–125, Grau `#7F7F7F` | Tachosymbol, „112 1/min“ in Weiß | DM-08 |
| Kennzahl Maschinenwinkel | x 1248–1380, y 83–125, Grau | Winkelsymbol, „245°“ in Weiß | DM-08 |
| Inhaltsbereich | y 135–720 | seitenspezifisch | – |
| Funktionsleiste | x 105–1380, y 725–777, Hellblau `#AECAE8` | graue Tasten links (seitenspezifisch, auf DS-04 und DS-05 leer) | DM-09, DM-10 |

Meldezeile, Betriebsart, Uhrzeit, Geschwindigkeit und Winkel zeigen auf allen fünf Seiten dieselben Werte. Das ist vermutlich der Entwurfsstand und kein Hinweis auf Seitenabhängigkeit.

## 3. Raster

- Kein sichtbares Spaltenraster; der Entwurf ist von Hand in PowerPoint positioniert. Die Ausrichtung ist nicht exakt (z. B. DS-01: Tasten der zweiten Reihe leicht versetzt, Umschalter auf verschiedenen x-Positionen; DS-04: Knöpfe der Umschalter in der Nachdosierer-Karte versetzt).
- Ableitbare Aufteilung des Inhaltsbereichs:
  - DS-01: obere Reihe 4 Kacheln (Geschwindigkeit, Produktion, EKW, Versorgung), Breiten ca. 220 : 257 : 350 : 413 px; untere Reihe 2 Bereiche (Tasten ca. 555 px, Umschalter ca. 695 px).
  - DS-02: 3 Spalten (links breit ca. 405 px, Mitte und rechts je ca. 405 px) mit einem Kachelraster 2 × 4 in der Mitte und 2 × 4 rechts.
  - DS-03: links schmale Tastenspalte (ca. 200 px), Mitte breit (Status und Temperaturen), rechts schmal (Füllstand).
  - DS-04: Titelzeile über 3 gleich breiten Karten (je ca. 400 px, Abstand ca. 20 px).
  - DS-05: links Bedienbereich, rechts Grafik (ca. 650 px breit).
- Außenabstände: ca. 5–10 px zwischen Seitenleiste und Inhalt, ca. 5–10 px zwischen Kacheln.

## 4. Farben (Hex-Schätzung)

| Verwendung | Hex | Hinweis |
|---|---|---|
| Seitenleiste, Titelzeile DS-04, blaue Tasten | `#4472C4` | Taste mit Fasen (3D) |
| Taste, Fasen hell / dunkel | `#7B9AD6` / `#2F4A87` | PowerPoint-Fase, Artefakt |
| Benutzerkreis | `#ED7D31` | Schriftzug „MM“ weiß |
| Name in Seitenleiste / Rolle | `#9DB3E0` / `#F4B183` | Rolle „Technik“ orange-ocker |
| Meldezeile Hintergrund / Text | `#FFC000` / `#C55A11` | Alarm-/Warnanmutung |
| Betriebsart | `#70AD47` | grün = Produktion |
| Uhr | `#2E75B6` | |
| Seitenhintergrund | `#FFFFFF` | |
| Kacheln, Karten | `#D0D0D0` | hellgrau |
| Funktionsleiste, hervorgehobene Karte (Nachdosierer), Panels DS-03 | `#AECAE8` bzw. `#AFC3DE` | DS-03 Rand `#4A7EBB` (2–3 px) |
| Kennzahl-Kachel | `#7F7F7F` | |
| Graue Funktionstaste | `#A6A6A6` mit Fase | Schrift dunkelgrau bzw. weiß (DS-01/02) |
| Brotkrümel DS-01 | Verlauf `#B4C7E7` → `#8FAADC` (blau) | alle anderen Seiten lachsfarben `#F8B896` → `#F4B183` |
| Grüne Zustandstaste (DS-03, DS-05) | `#70AD47` mit Fase | Schrift weiß |
| Taste „Schnell“ (DS-01) | `#70AD47` mit Fase | |
| Taste „Füllsystem“ / „Manuell“ (DS-03) | `#00FF00` / `#FF0000` | Schrift schwarz, reines Signalgrün/-rot, kaum Fase |
| Umschalter | Bahn `#A6A6A6`, Knopf `#70AD47` | Knopf immer rechts, alle „ein“ |
| Status-LED | `#00B000` mit dunklem Ring `#404040` (DS-03); `#70AD47` flach (DS-04) | |
| Fortschrittsbalken Füllstand | `#00FF00` auf Weiß, Rahmen grau | DS-03 |
| Fortschrittsbalken Auslastung | `#FFC000` | DS-04, Text schwarz |
| Eingabefeld | Weiß, Text rot `#FF0000` bzw. schwarz für Anzeigewerte | Schlüssel gelb `#FFC000` |
| Seitenleiste Symbole | Weiß, Sprechblase gelb `#FFFF00` | |
| Karton-Grafik | Karton `#B87A56`, Leimspur `#E8D5A8`, Rahmen `#4A7EBB` | |

## 5. Typografie

- Schriftart: serifenlose Systemschrift, vermutlich Calibri (PowerPoint-Standard); nicht sicher erkennbar. Das Logo hat eigene Schrift.
- Größen (Schätzung auf Bildgröße 1390 px Breite, gemessen an Zeichenhöhe): Seitentitel/Kachelüberschrift ca. 24 px, Werte und Beschriftungen ca. 22 px, Tastenbeschriftung ca. 21–22 px, Betriebsart „Produktion“ ca. 28 px, Uhrzeit ca. 22 px, Datum ca. 14 px, Meldezeile ca. 19 px, Brotkrümel ca. 14 px (sehr klein), Name/Rolle in Seitenleiste ca. 13 px.
- Auszeichnungen: Überschriften „Status“ und „Aktuelle Temperaturen:“ (DS-03) unterstrichen/fett; sonst keine Fettschrift.
- Farben: dunkelgrau `#404040` auf Grau/Weiß, Weiß auf Blau, Grün, Grau (Kennzahl), Rot `#FF0000` für Eingabewerte.
- Die rote Wellenlinie unter „Gebläse Dornrad“ (DS-01), „Anwählen“ (DS-02) und „Heißleim“ (DS-03) ist Rechtschreibprüfung von PowerPoint, **kein** Designelement.

## 6. Elementarten

| Elementart | Beispiele | Modul |
|---|---|---|
| Rahmenelemente | Seitenleiste, Kopfzeile, Brotkrümel, Kennzahlen, Funktionsleiste | DM-01 bis DM-10 |
| Gruppenbereich (grauer Container mit Überschrift) | „Geschwindigkeit“, „Produktion“, „EKW“, „Versorgung“, „Hauptdosierer 1“ | DM-11 |
| Kachel-Taste (blau, 3D) | „Automatik“, „Zuführungen“, „Waagen“ | DM-12 |
| Umschalter mit Beschriftung | „Bahnkontrolle“, „Querschnecke“ | DM-13 |
| Status-LED mit Beschriftung | „Bereitschaft“, Trichter oben/unten | DM-14 |
| Beschriftung/Wert-Zeile | „Druckluft IO“, „Soll 48 % entspricht 113 g“ | DM-15 |
| Wertfeld (weiß, nur Anzeige) | „Tank: 150 °C“ | DM-16 |
| Eingabefeld mit Schlüsselsymbol | „Ziel Füllstand: 50 %“ | DM-17 |
| Fortschrittsbalken | „Füllstand Tank 83%“, „Auslastung 92%“ | DM-18 |
| Zustandstaste (grün/rot) | „Heizung“, „Schnell“, „Füllsystem“ | DM-19 |
| Dosierer-Karte | Hauptdosierer 1/2, Nachdosierer | DM-20 |
| Titelzeile mit Verschiebesymbol | „Sollgewicht KW: 235g \| Letztes Gewicht KW: 238g“ | DM-21 |
| Grafik mit Eingabefeldern | Leimspuren auf Kartonzuschnitt | DM-22 |

## 7. Navigation

- **Seitenleiste:** Home (Haus-Symbol), Einstellungen (Zahnrad), Meldungen (gelbe Sprechblase mit „!“), Zurück (Rücktaste mit X). Die Bedeutung der Symbole ist nicht beschriftet; die Zuordnung ist Annahme (siehe `Annahmen.md`).
- **Brotkrümel:** Pfeilsegmente. DS-01 „Produktion“; DS-02 „Einstellung“; DS-03 „Einstellung › Zuführungen › Heißleim“; DS-04 „Einstellung › Dosierer“; DS-05 „Einstellung › Zuführungen › Karton“. Das letzte Segment ist die aktuelle Seite. Ob Segmente antippbar sind, ist nicht ersichtlich.
- **Einstieg:** Produktion = Startseite (Home). Von Einstellungen (DS-02) führen blaue Kacheln zu Unterseiten: „Dosierer“ → DS-04; „Zuführungen“ → Zwischenebene (nicht im Design) → Heißleim (DS-03) und Karton (DS-05). Auf DS-01 führen „Zuführung Papier“ und „Zuführung Karton“ vermutlich zu Zuführungsseiten.
- Der Brotkrümel „Zuführungen“ (DS-03, DS-05) belegt eine Zwischenseite „Zuführungen“, die im Design nicht vorhanden ist.
- Funktionsleiste (unten): seitenspezifische Tasten; DS-03 Temperatur/Druck/Zeitplan (Unterseiten bzw. Umschalter der Ansicht, nicht ersichtlich).

## 8. Modulkandidaten (feste IDs)

Die Definitionen `DM-xx` schreibt ein späterer Agent. IDs und Namen sind fest, damit Verweise stabil bleiben. Eine Zusammenfassung oder Ergänzung erfolgt nur durch Anhängen neuer IDs.

| ID | Name | Beispiele |
|---|---|---|
| DM-01 | Benutzerkennung | Kreis „MM“, „Max Mustermann“, „Technik“ |
| DM-02 | Navigationsleiste | Home, Einstellungen, Meldungen, Zurück |
| DM-03 | Kopfzeile Logo | APA-TEC-Logo |
| DM-04 | Meldezeile | „014: Sicherung 4F24 Auslaufband ausgelöst.“ |
| DM-05 | Betriebsart-Anzeige | „Produktion“ mit Symbol |
| DM-06 | Uhrzeit und Datum | 9:15, 06.01.2026 |
| DM-07 | Brotkrümel-Navigation | Einstellung › Zuführungen › Heißleim |
| DM-08 | Kennzahl-Kachel | 112 1/min, 245° |
| DM-09 | Funktionsleiste | untere hellblaue Leiste |
| DM-10 | Funktionstaste (grau) | Schichtplan, Sprache, Temperatur, Druck, Zeitplan |
| DM-11 | Gruppenbereich | grauer Bereich mit Überschrift |
| DM-12 | Kachel-Taste | Automatik, Zuführungen, Waagen, leere Kachel |
| DM-13 | Umschalter | Bahnkontrolle, Querschnecke |
| DM-14 | Status-LED | Bereitschaft, Trichter oben |
| DM-15 | Beschriftung-Wert-Zeile | Druckluft IO, Bandwaage Bereit |
| DM-16 | Wertfeld (Anzeige) | Tank 150 °C |
| DM-17 | Eingabefeld mit Schlüsselsymbol | Ziel Füllstand 50 %, Max Füllzeit 60 s |
| DM-18 | Fortschrittsbalken | Füllstand Tank, Auslastung |
| DM-19 | Zustandstaste | Heizung, Standby, Pumpe, Schnell, Füllsystem, Manuell, Ein / Aus |
| DM-20 | Dosierer-Karte | Hauptdosierer 1, 2, Nachdosierer |
| DM-21 | Titelzeile mit Verschiebesymbol | Sollgewicht-Zeile |
| DM-22 | Leimspuren-Grafik | Karton mit Eingabefeldern |

## 9. PowerPoint-Artefakte (nicht final, nicht übernehmen)

- 3D-Fasen und Verläufe an allen Tasten und Brotkrümeln (verstößt gegen Agent.md Abschnitt 6).
- Rote Rechtschreibwellen („Gebläse Dornrad“, „Anwählen“, „Heißleim“).
- Uneinheitliche Ausrichtung und Größen (Tastengrößen DS-01, versetzte Umschalter, ungleiche Abstände).
- Platzhalterdaten: gleiche Meldung, Zeit, Geschwindigkeit und Winkel auf allen Seiten; identische Werte in allen drei Dosierer-Karten (Soll 48 %, 113 g, 5.30g, 92 %); „Tolles Rezept“ als Beispielname.
- Inkonsistente Schreibweisen: „5.30g“ (Punkt, ohne Leerzeichen) vs. „113 g“, „235g“ (ohne Leerzeichen), „83%“ und „92%“ vs. „50 %“.
- Brotkrümel-Farbe Blau auf DS-01, Lachs auf den übrigen.
- Inkonsistente Signalfarben der Tasten (Füllsystem reingrün, Manuell reinrot ohne Fase).
- Leere Elemente (EKW, 4 leere Kacheln, leere Funktionsleisten).
- Bedeutung von Farbwechseln (hervorgehobene Nachdosierer-Karte, abgeblendete Tasten) ist nicht erklärt.
