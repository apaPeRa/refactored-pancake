# HM-26 – Diagramm (Trend / Balken)

## Funktion
Reine Anzeige von Messreihen. Eine Funktion, zwei Diagrammarten als Parameter: **Linie** (Trend der letzten gewogenen Gewichte mit Punktmarkern und Wertbeschriftung, HS-15) und **Balken** (Stückzahl je Stunde eines Tages mit Zahlenwert über dem Balken, HS-29). Bei Balken ergänzt die Datumsnavigation [HM-18](HM-18_Auswahlfeld-Pfeiltasten.md) den Tag (letzte 30 Tage). Achsen mit Einheit und Gitternetz. Linie, Punkte und Balken sind neutral (Textfarbe); Statusfarbe tritt nur bei Grenzverletzung auf. Die Anzahl der Trendpunkte ist im Handbuch widersprüchlich (20, 21, 50; OP-32) und deshalb Parameter.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Diagrammart (`ChartKind`) | enum ChartKind { Line, Bar } | – | – |
| Datenreihe (`Series`) | IReadOnlyList<ChartPoint> | – | je X (string/double), Y (double) |
| Y-Einheit (`YUnit`) | string | – | „g“, „Stk“ |
| Y-Minimum / Maximum (`YMinimum`, `YMaximum`) | double? | Y-Einheit | null = automatisch; Bild Trend 234,0 bis 236,5, Balken 0 bis 1800 |
| Y-Schritt (`YStep`) | double | Y-Einheit | Bild 0,5 bzw. 200 |
| Maximale Punkte (`MaxPoints`) | int | Stk | 1 bis 50, Standard 20 (OP-32) |
| Werte beschriften (`ShowValueLabels`) | bool | – | Standard true |
| Unter-/Obergrenze (`LowerLimit`, `UpperLimit`) | double? | Y-Einheit | offen (OP-47), null = keine |
| X-Beschriftung (`XLabels`) | IReadOnlyList<string> | – | Linie: −20 … −0; Balken: 0:00 bis 23:00 |
| Titel (`Title`) | string? | – | – |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Normal | Gitter `Brush.Divider`, Linie 3 px und Punkte `Brush.Text.Primary`, Balken `Brush.Progress.Fill`, Achsentext `Font.Size.Caption` `Brush.Text.Secondary` | Zahlenwerte an Punkten/Balken |
| Aktueller Wert | letzter Punkt größer, `Brush.Text.Primary` | größerer Marker und Beschriftung „aktuell“ |
| Grenze verletzt | Punkt/Balken `Brush.Status.Warning.Fill` | Raute statt Kreis bzw. `Icon.Status.Warning` über dem Balken |
| Zu wenig Daten | Achsen leer | Text „Keine Daten“ und `Icon.Status.Inactive` |
| Wert ungültig | Lücke in der Linie | Text „---“ an der Stelle |

## Verwendet auf Seiten (IDs)
- [HS-15](../Seiten/HS-15_Trend.md) – Trend
- [HS-29](../Seiten/HS-29_Produktionsstatistik.md) – Produktionsstatistik

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die HS-Dateien entstehen in Phase 3 (Punkt 4); die Links sind vorläufig.

## Herkunft
- [RM-22](../../02_Referenz-Analyse/Module/RM-22_Trend-Diagramm.md) – Trend-Diagramm: Trend der letzten Gewichte (Liniendiagramm)
- [RM-30](../../02_Referenz-Analyse/Module/RM-30_Tagesbalkendiagramm.md) – Tagesbalkendiagramm: Tagesbalkendiagramm mit Datumsnavigation
- Design: keine Entsprechung (Element nur in der Referenz).

## WPF-Umsetzung
- **Control:** `HM26_Chart` (UserControl (eigenes Zeichnen mit `Canvas`/`Path`)), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `UserControl` (`HM26_Chart`), Zeichnung über `ItemsControl` mit `Canvas`/`Polyline`/`Rectangle` (kein zusätzliches NuGet-Paket); Skalierung im Control per `MultiValueConverter`.
- **Dependency Properties:** `ChartKind`, `Series`, `YUnit`, `YMinimum`, `YMaximum`, `YStep`, `MaxPoints`, `ShowValueLabels`, `LowerLimit`, `UpperLimit`, `XLabels`, `Title`.
- Mit `AutomationProperties.Name` und Wertetabelle für Zugänglichkeit.
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-26-P01 | Linie | HS-15: Kurve mit Punkten und Beschriftung „235,8 g“ | offen |
| HM-26-P02 | Balken | HS-29: je Stunde ein Balken mit Zahl, Y-Achse 0 bis 1800 | offen |
| HM-26-P03 | Achsen | Einheit sichtbar (g bzw. Stk) | offen |
| HM-26-P04 | Neutral | Farbe nur bei Grenzverletzung, mit Symbol | offen |
| HM-26-P05 | Keine Daten | Text mit Symbol statt leerer Fläche | offen |
| HM-26-P06 | Datumsnavigation | Pfeile (HM-18) wechseln den Tag, 30 Tage | offen |
