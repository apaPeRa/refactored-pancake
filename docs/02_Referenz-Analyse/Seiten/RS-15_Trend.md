# RS-15 – Trend
- Quelle: `src_Data/Referenz/Referenz.docx`, Kapitel „Trend“ (Kapitel 15; Zweck, Seitenübersicht; keine Tabelle, kein Abschnitt Funktionsbeschreibung), Bild [RS-15_01](../Medien/RS-15_01.png).   - Navigationspfad: Einstellung › Kontrollwaage › Trend (Taste „Trend“ in der Navigation unten links von [RS-13](RS-13_Kontrollwaage.md)).

## Zweck
Wortgetreu: „Auf dieser Seite werden die letzten 20 gewogenen Gewichte grafisch dargestellt. Dadurch können Schwankungen besser erkannt werden.“

## Aufbau (Bereiche, Layout)
Seitenbild (1024 × 768): [RS-15_01](../Medien/RS-15_01.png).

1. **Kopfzeile:** Logo „APA-TEC“, Titel „Trend KW“ (fett, unterstrichen), Wirbelsymbol, Uhrzeit „13:02:56“, Datum „12.05.2025“.
2. **Diagrammfläche** (blauer Hintergrund, volle Breite): Liniendiagramm mit orangefarbener, geglätteter Kurve und orangen Punktmarkern; hellblaue Gitterlinien (horizontal und vertikal).
   - **Y-Achse (links):** Beschriftung 234,0 g / 234,5 g / 235,0 g / 235,5 g / 236,0 g / 236,5 g (Schritt 0,5 g).
   - **X-Achse (unten):** Beschriftung -20, -19, … -1, -0 (21 Positionen; -0 = aktuellstes Gewicht, Annahme).
   - **Datenbeschriftung** über jedem Punkt, Format „235,8g“ (ohne Leerzeichen vor g). Werte von -20 bis -0: 235,8 / 234,0 / 235,3 / 234,8 / 235,3 / 235,7 / 236,4 (Beschriftung am oberen Rand angeschnitten, lesbar als „236,4g“) / 234,6 / 235,2 / 234,5 / 234,8 / 235,2 / 235,3 / 234,9 / 236,0 / 235,3 / 235,1 / 235,8 / 235,3 / 234,7 / 235,0 (g).
3. **Meldezeile** (rot): „*450* Palettierung nicht bereit“.
4. **Untere Funktionsleiste:** links keine Tasten; Mitte gelbes Vorhängeschloss; rechts „Produktion“ (Haus), „Einstellungen“ (Zahnrad), „Zurück“ (Rücktaste).

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Das Handbuch enthält für diese Seite keine Tabelle und keine Funktionsbeschreibung (0 Tabellenzeilen). Die Elemente stammen aus dem Seitenbild:

| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Trenddiagramm (Kurve, Punkte, Gitter) | Liniendiagramm | stellt „die letzten 20 gewogenen Gewichte grafisch“ dar, „Dadurch können Schwankungen besser erkannt werden“ | Modulkandidat: Trend-Diagramm |
| Y-Achse Gewicht in g | Achse | Skala 234,0 g bis 236,5 g in Schritten von 0,5 g (Bild) | Modulkandidat: Trend-Diagramm |
| X-Achse -20 … -0 | Achse | Position der Messung relativ zur letzten (Bild) | Modulkandidat: Trend-Diagramm |
| Punktbeschriftungen („235,8g“) | Datenbeschriftung | Gewichtswert je Punkt (Bild) | Modulkandidat: Trend-Diagramm |
| Kopfzeile (Titel „Trend KW“) | Rahmenelement | im Handbuch nicht beschrieben | Modulkandidat: Kopfzeile |
| Meldezeile „*450* Palettierung nicht bereit“ | Statusleiste, rot | im Handbuch auf dieser Seite nicht beschrieben; siehe [RS-38](RS-38_Meldeanzeige.md) | Modulkandidat: Meldezeile |
| Vorhängeschloss, „Produktion“, „Einstellungen“, „Zurück“ | Funktionsleiste | im Handbuch nicht beschrieben | Modulkandidat: Funktionsleiste |

## Bilder
| Nr. | Datei | Pixel | Position | Beschreibung (angesehen) |
|---|---|---|---|---|
| 1 | [RS-15_01.png](../Medien/RS-15_01.png) | 1024 × 768 | Seitenübersicht | Gesamtseite „Trend KW“: orangefarbene Kurve mit 21 beschrifteten Punkten über X-Achse -20 … -0, Y-Achse 234,0 g bis 236,5 g, hellblaues Gitter auf blauem Grund; Aufbau und alle Werte siehe „Aufbau“. |

## Verwendete Module (IDs)
RM-IDs werden später vergeben. Modulkandidaten:
- Modulkandidat: Trend-Diagramm
- Modulkandidat: Kopfzeile
- Modulkandidat: Meldezeile
- Modulkandidat: Funktionsleiste

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- **Pop-ups:** keine.
- **Bedienung:** keine Eingabe- oder Schaltelemente im Inhaltsbereich; reine Anzeigeseite.
- **Berechtigungen:** keine beschrieben.
- **Navigation:** Annahme (Handbuch sagt dazu nichts): Rückkehr über „Zurück“ zur Kontrollwaage (RS-13); Produktion / Einstellungen über die Funktionsleiste.
- **Fehlerfälle:** keine beschrieben.

## Prüfpunkte (Tabelle: ID | Prüfung | erwartetes Ergebnis | Status)
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RS-15-P01 | Zugang | Einstellung › Kontrollwaage › Trend über Taste „Trend“ in RS-13 | offen |
| RS-15-P02 | Titel | „Trend KW“ in der Kopfzeile | offen |
| RS-15-P03 | Inhalt | Grafische Darstellung der letzten 20 gewogenen Gewichte als Kurve mit Punkten | offen |
| RS-15-P04 | Y-Achse | Gewicht in g, Skala im Beispiel 234,0 g bis 236,5 g in 0,5-g-Schritten | offen |
| RS-15-P05 | X-Achse | Positionen -20 bis -0, -0 am rechten Rand | offen |
| RS-15-P06 | Datenbeschriftung | jeder Punkt trägt seinen Gewichtswert (Format „235,8g“) | offen |
| RS-15-P07 | Funktionsleiste | links keine Tasten; Vorhängeschloss, Produktion, Einstellungen, Zurück vorhanden | offen |
| RS-15-P08 | Seitenbild verlinkt und beschrieben | RS-15_01 verlinkt, Beschreibung vorhanden | offen |

## Offene Punkte
1. **Anzahl Punkte:** Handbuch „letzte 20 gewogene Gewichte“, Bild zeigt 21 Positionen (-20 bis -0); RS-13 nennt „letzten 50 Packungen“ für die Taste „Trend“. Widerspruch, maßgeblicher Wert offen.
2. **Skalierung der Y-Achse:** automatisch oder fest, Grenzen/Zoom nicht beschrieben; Beschriftung am oberen Rand wird angeschnitten.
3. **Grenzlinien:** keine Soll-/Grenzwertlinien (Sollgewicht, Über-/Untergewicht) im Bild; ob vorgesehen, unklar.
4. **Aktualisierung/Interaktion** (Live-Aktualisierung, Antippen von Punkten, Berechtigungen) im Handbuch nicht beschrieben; Kapitel hat keine Funktionsbeschreibung.
5. **Titel „Trend KW“** weicht von Kapitelname „Trend“ ab; Bedeutung -0 und Reihenfolge der X-Achse (Annahme: -0 = aktuellstes) nicht erklärt.
