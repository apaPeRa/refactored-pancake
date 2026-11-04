# HS-15 – Trend
- Quelle: [RS-15](../../02_Referenz-Analyse/Seiten/RS-15_Trend.md) (Handbuch Kapitel 15, nur Zweck und Seitenübersicht, keine Tabelle; Bild [RS-15_01](../../02_Referenz-Analyse/Medien/RS-15_01.png)). Keine Design-Seite (DS) vorhanden: Aufbau abgeleitet aus dem [Designsystem](../Designsystem.md) und [HM-26](../Module/HM-26_Diagramm.md).   - Navigationspfad: **Einstellung › Waagen › Kontrollwaage › Trend** (Brotkrümel nach [Navigation.md](../Navigation.md) Abschnitt 2; Zugang: HS-13 Funktionsleiste „Trend“; Zurück-Ziel: HS-13; PageKey `Trend`, Route `settings/scales/check/trend`, Mindestrolle: keine).

## Zweck
Die Seite stellt die letzten gewogenen Gewichte grafisch als Kurve dar, damit Schwankungen besser erkannt werden (Handbuch, wortgetreu: „Auf dieser Seite werden die letzten 20 gewogenen Gewichte grafisch dargestellt. Dadurch können Schwankungen besser erkannt werden.“). Reine Anzeigeseite ohne Eingabe. Der Titel „Trend KW“ des Handbuchbilds wird nicht übernommen, die Seite heißt „Trend“ (OP-33).

## Aufbau (Bereiche, Layout)
Rahmen wie in Designsystem Abschnitt 3.2. Der **Inhaltsbereich** (Außenrand `Size.Content.Margin`) enthält ein einziges Element (HM-05 wird nicht verwendet; die Kennzahlen im Rahmen gehören zum Rahmen), das Liniendiagramm über alle 12 Spalten und die volle Höhe (Zeile 1\*, Kontrollwert ca. 768 px × 1728 px bei 1920 × 1080: 816 px Inhaltsbereich abzüglich 2 × `Size.Content.Margin` = 768 px Höhe; Breite 1776 px abzüglich 48 px = 1728 px). Die Diagrammfläche liegt auf `Brush.Surface` mit Kontur `Border.Thin` `Brush.Border.Control` und `Radius.Card`; Innenabstand `Space.M`, damit Achsenbeschriftung und Datenbeschriftung am Rand nicht angeschnitten werden (Referenz: oberste Beschriftung „236,4g“ angeschnitten, OP-44). Die Funktionsleiste hat keine seitenspezifischen Tasten (leer, sichtbar).

```
Inhaltsbereich (12 Spalten, 1 Zeile)
+--------------------------------------------------------------------------------+
| g                                                                               |
| 236,5 |.....................235,8 g...............................236,4 g.......|
| 236,0 |...      ...                                                            |
| 235,5 |.. o----o                 o---o-- ...                                    |
| 235,0 |.        \   /\   /\ ...                                                  |
| 234,5 |.         \_/  \_/                                                       |
| 234,0 |..o.............................................................         |
|        -20 -19 -18 ... -3  -2  -1  -0   (-0 = aktuellster Wert)                |
+--------------------------------------------------------------------------------+
Funktionsleiste: (leer)
```

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Das Handbuch enthält für diese Seite keine Tabelle (0 Tabellenzeilen); Rückverfolgung zu den Elementen der Spalte „Element“ in [RS-15](../../02_Referenz-Analyse/Seiten/RS-15_Trend.md) (Abschnitt „Elemente“, Zeilen 1–7).

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Trenddiagramm (Kurve, Punkte, Gitter) | Liniendiagramm, `ChartKind` Line; Linie `Border.Thick` und Punkte `Brush.Text.Primary`, Gitter `Brush.Divider` | stellt die letzten gewogenen Gewichte grafisch dar, damit Schwankungen besser erkannt werden; geglättete Kurve der Referenz wird als gerade Verbindung dargestellt (keine Interpolation, die Zwischenwerte vortäuscht; Annahme S15-1) | [HM-26](../Module/HM-26_Diagramm.md) (`ChartKind` Line, `MaxPoints` 21, `ShowValueLabels` true) | RS-15 Element 1, Bild RS-15_01 |
| Y-Achse „Gewicht in g“ | Achse links, Beschriftung mit Einheit (Beispiel 234,0 g bis 236,5 g, Schritt 0,5 g) | Skala des Gewichts; Bereich automatisch aus den Daten, Schritt `YStep` 0,5 (Bild); Beschriftung nie angeschnitten | [HM-26](../Module/HM-26_Diagramm.md) (`YUnit` „g“, `YMinimum`/`YMaximum` null = automatisch, `YStep` 0,5) | RS-15 Element 2 |
| X-Achse „−20 … −0“ | Achse unten, 21 Positionen, Beschriftung Caption | Position der Messung relativ zur letzten; −0 = aktuellster Wert am rechten Rand (Annahme der Referenz) | [HM-26](../Module/HM-26_Diagramm.md) (`XLabels` −20 bis −0) | RS-15 Element 3 |
| Punktbeschriftungen („235,8 g“) | Datenbeschriftung über jedem Punkt, Format `N1` mit geschütztem Leerzeichen und Einheit (Referenz „235,8g“ ohne Leerzeichen) | Gewichtswert je Punkt; der letzte Punkt ist größer markiert und trägt zusätzlich die Beschriftung „aktuell“ | [HM-26](../Module/HM-26_Diagramm.md) (`ShowValueLabels`, Zustand „Aktueller Wert“) | RS-15 Element 4 |

### Rahmenelemente (nicht in den Handbuchtabellen, laut Seitenbild RS-15_01)
| Element der Referenz | Ort im neuen HMI | verwendetes Modul | Herkunft |
|---|---|---|---|
| Kopfzeile mit Logo, Titel „Trend KW“, Wirbelsymbol, Uhrzeit, Datum | Kopfzeile (Logo, Betriebsart, Uhr/Datum); Titel = letztes Brotkrümel-Segment „Trend“ | [HM-02](../Module/HM-02_Kopfzeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | Seitenbild, OP-26, OP-33 |
| Meldezeile „*450* Palettierung nicht bereit“ (rot) | Meldezeile in der Kopfzeile; Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | Seitenbild, RS-38 |
| Funktionsleiste ohne Tasten links; Vorhängeschloss, „Produktion“, „Einstellungen“, „Zurück“ | Funktionsleiste bleibt leer und sichtbar; Benutzerkreis, Home, Zahnrad, Zurück in der Seitenleiste | [HM-06](../Module/HM-06_Funktionsleiste.md), [HM-01](../Module/HM-01_Seitenleiste.md) | Seitenbild, A-35 |

## Verwendete Module (IDs)
- [HM-01](../Module/HM-01_Seitenleiste.md) – Seitenleiste (Rahmen)
- [HM-02](../Module/HM-02_Kopfzeile.md) – Kopfzeile (Rahmen)
- [HM-03](../Module/HM-03_Meldezeile.md) – Meldezeile (Rahmen)
- [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) – Brotkrümel-Navigation (Rahmen)
- [HM-06](../Module/HM-06_Funktionsleiste.md) – Funktionsleiste unten (leer)
- [HM-26](../Module/HM-26_Diagramm.md) – Diagramm, Variante Linie (Trend)

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
**Zugang und Zurück.** Die Seite öffnet aus HS-13 über „Trend“. „Zurück“ (Seitenleiste) führt im Verlauf zu HS-13; das Brotkrümel-Segment „Kontrollwaage“ springt ebenfalls dorthin, „Waagen“ zu HS-42. Die Funktionsleiste ist leer.

**Bedienung.** Reine Anzeigeseite: keine Eingabe- oder Schaltelemente, keine Pop-ups, keine Berechtigungen. Antippen von Punkten oder Zoomen ist nicht vorgesehen (im Handbuch nicht beschrieben).

**Aktualisierung.** Mit jeder neuen Wägung rückt die Kurve um eine Position nach links; der neue Wert steht bei −0 am rechten Rand, der älteste fällt weg. Der letzte Punkt ist größer und mit „aktuell“ gekennzeichnet (Zustand „Aktueller Wert“ in HM-26, zweiter Kanal Marker und Text).

**Anzahl der Punkte.** Handbuch-Text: 20 Gewichte; Bild: 21 Positionen (−20 bis −0); Navigationstabelle von RS-13: 50 Packungen. Angenommen werden 20 zurückliegende Gewichte plus der aktuelle (21 Positionen, OP-32); `MaxPoints` ist 21 und konfigurierbar (HM-26 nennt Standard 20: Abweichung).

**Achsen.** Y-Bereich automatisch aus den Daten mit festem Schritt 0,5 g; Ober- und Untergrenze liegen mindestens eine Schrittweite (0,5 g) außerhalb von Minimum und Maximum der Daten, sodass Punkte und Beschriftungen vollständig sichtbar sind. Grenz- oder Sollgewichtslinien sind im Bild nicht vorhanden und werden nicht erfunden (`LowerLimit`/`UpperLimit` null, OP-47). Wird eine Grenze später ergänzt, zeigt ein verletzter Punkt eine Raute und `Icon.Status.Warning` statt nur Farbe.

**Fehler- und Sonderfälle.** Zu wenig Daten (weniger als zwei Punkte oder Waage nicht erreichbar): Achsen leer, Text „Keine Daten“ mit `Icon.Status.Inactive`. Ungültiger Wert: Lücke in der Linie und Text „---“ an der Stelle. Beschriftungsüberlappung bei dicht liegenden Punkten: Beschriftungen wechseln zwischen oberhalb und unterhalb des Punkts, damit jede lesbar bleibt (Annahme S15-2).

## Prüfpunkte (Tabelle: ID | Prüfung | erwartetes Ergebnis | Status)
Die Punkte HS-15-P01 bis P08 sind die Entsprechung der Prüfpunkte RS-15-P01 bis P08 (Nummer gleich); ab P09 folgen Punkte aus Designsystem und Navigation.

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-15-P01 | Zugang (RS-15-P01) | Brotkrümel „Einstellung › Waagen › Kontrollwaage › Trend“; Seite öffnet aus HS-13 über „Trend“; „Zurück“ führt zu HS-13 | offen |
| HS-15-P02 | Titel (RS-15-P02) | letztes Brotkrümel-Segment „Trend“ (nicht „Trend KW“, OP-33) | offen |
| HS-15-P03 | Inhalt (RS-15-P03) | Liniendiagramm der letzten gewogenen Gewichte mit Linie und Punkten (Beispielmenge 21 Positionen, 20 zurückliegende und aktueller) | offen |
| HS-15-P04 | Y-Achse (RS-15-P04) | Gewicht in g, Beispielskala 234,0 g bis 236,5 g in 0,5-g-Schritten; bei den Beispieldaten (234,0 g bis 236,4 g) wird die Skala um einen Schritt erweitert (233,5 g bis 237,0 g), sodass kein Punkt auf dem Rand der Diagrammfläche liegt; Beschriftung vollständig, nie angeschnitten | offen |
| HS-15-P05 | X-Achse (RS-15-P05) | Positionen −20 bis −0, −0 am rechten Rand (aktuellster Wert) | offen |
| HS-15-P06 | Datenbeschriftung (RS-15-P06) | jeder Punkt trägt seinen Gewichtswert im Format „235,8 g“ (mit Leerzeichen, Dezimalkomma); keine Beschriftung überdeckt eine andere | offen |
| HS-15-P07 | Funktionsleiste (RS-15-P07) | Funktionsleiste sichtbar und ohne Tasten; Benutzerkreis, Home, Einstellungen, Zurück in der Seitenleiste vorhanden | offen |
| HS-15-P08 | Rückverfolgung zum Seitenbild (RS-15-P08) | alle Elemente aus RS-15_01 sind wiederzufinden: Kurve mit Punkten, Gitter, Y-Achse, X-Achse, Datenbeschriftungen, Meldezeile, Rahmentasten | offen |
| HS-15-P09 | Aktueller Wert | letzter Punkt größer als die übrigen und mit Text „aktuell“ gekennzeichnet | offen |
| HS-15-P10 | Keine Daten | ohne Messwerte zeigt die Fläche „Keine Daten“ mit `Icon.Status.Inactive` statt einer leeren Grafik | offen |
| HS-15-P11 | Neutrale Darstellung | Linie, Punkte und Gitter in neutralen Tokens (`Brush.Text.Primary`, `Brush.Divider`); keine Statusfarbe ohne Grenzverletzung; keine orange Kurve der Referenz | offen |
| HS-15-P12 | Zugänglichkeit | Diagramm hat `AutomationProperties.Name` und eine Wertetabelle als Alternative; Werte sind nicht nur grafisch lesbar | offen |
| HS-15-P13 | Schriftgröße | Achsen- und Datenbeschriftung mindestens `Font.Size.Caption` (20); Zahlen mit tabellarischen Ziffern | offen |
| HS-15-P14 | Tokens und Texte | keine Hex-, Pixel- oder Literalwerte; Einheit, „aktuell“, „Keine Daten“ aus `.resx` | offen |
| HS-15-P15 | Raster bei 1920 × 1080 | Diagramm füllt den Inhaltsbereich (12 Spalten, volle Höhe) ohne Scrollen; Außenrand `Size.Content.Margin` | offen |

## Offene Punkte
Verweise auf [Offene-Punkte.md](../../00_Plan/Offene-Punkte.md) (Seiten-Index RS-15): OP-32 (Anzahl der Punkte 20/21/50), OP-33 (Seitentitel „Trend KW“), OP-44 (Bild abgeschnitten, Beschriftung am oberen Rand angeschnitten), OP-47 (Skalierung der Y-Achse, Grenzlinien, Statistik). Zusätzlich offen aus der RS-Seite: Live-Aktualisierung und Interaktion (Antippen, Zoom) nicht beschrieben; Bedeutung von −0 und Reihenfolge der X-Achse nur als Annahme (−0 = aktuellster Wert).

**Annahmen dieser Seite** (lokale Kennungen, gelten für HS-15):
- S15-1: Die Kurve wird als gerade Verbindung zwischen den Punkten dargestellt statt als geglättete Kurve, damit zwischen den Messwerten keine nicht gemessenen Werte erscheinen; Farbe neutral statt orange (Farbe nur für Status).
- S15-2: Datenbeschriftungen wechseln bei dichten Punkten zwischen oberhalb und unterhalb des Punkts, damit alle lesbar bleiben und keine am Rand angeschnitten wird.
- S15-3: Trend zeigt 21 Positionen (20 zurückliegende plus aktueller Wert), konfigurierbar (OP-32); die Datenbeschriftung trägt ein Leerzeichen vor „g“ (Designsystem Abschnitt 2).
