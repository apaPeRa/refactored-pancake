# HM-31 – Leimspuren-Grafik

## Funktion
Skalierbare Vektorgrafik eines Kartonzuschnitts (Draufsicht) mit Leimspuren (eine lange Spur links, je vier kurze oben und unten), über der 18 Winkelfelder ([HM-12](HM-12_Eingabefeld-Schluesselsymbol.md), ohne Beschriftung) für Anfang/Ende der Spuren in Maschinenwinkel (°) liegen. Vier Reihen: 5, 4, 5, 4 Felder. Die Grafik skaliert mit dem Seitenverhältnis des Zuschnitts (`Viewbox`); die Felder behalten Touch-Größe (mindestens `Size.Touch.Large` × `Size.Touch.Default`). Karton und Leim nutzen die beiden Neutralbraun-Töne (einzige Nicht-Status-Farbe, Designsystem 1.4). Der Maschinenwinkel (140 °) gehört nicht zu dieser Grafik, sondern steht als Anzeigefeld [HM-11](HM-11_Anzeigefeld.md) im Gruppenbereich „Maschinenwinkel“ ([HM-15](HM-15_Gruppenbereich.md)) der Seite (HS-06). Zuordnung Anfang/Ende der Felder offen (OP-19).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Titel (`Title`) | string | – | „Leimspuren“ |
| Felder (`Fields`) | IReadOnlyList<GlueTrackField> | ° | 18 Felder, je Reihe, Index, Winkel; Reihen 5/4/5/4 |
| Winkel (`Angle`) | double | ° | Bild Reihe 1: 200, 205, 205, 205, 205; 2: 225 ×4; 3: 300, 310 ×4; 4: 325, 329 ×3 |
| Zuschnitt (`CutoutGeometry`) | Geometry | – | Vektor |
| Eingabe (`CommitCommand`) | ICommand<GlueTrackChange> | – | – |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Normal | Karton `Brush.Graphic.Carton`, Leimspur `Brush.Graphic.Glue`, Felder HM-12 (`Brush.Surface`) | Titel „Leimspuren“, Beschriftung der Spur im Tooltip |
| Feld in Bearbeitung | HM-12: Kontur `Border.Thick` `Brush.Border.Focus` | Rahmen |
| Feld Fehler | HM-12: Fehlerzustand | `Icon.Status.Error` und Text |
| Spur aus / Fehler | nicht beschrieben (Annahme: Spur gestrichelt (`Border.Dash`)) | gestrichelte Spur und Text im Tooltip |

## Verwendet auf Seiten (IDs)
- [HS-06](../Seiten/HS-06_Zufuehrung-Karton.md) – Zuführung Karton

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die Liste ist aus den Abschnitten „Verwendete Module“ und den Elemente-Tabellen der HS-Seiten abgeleitet (Stand Konsolidierung nach Phase 3, Punkt 4); „inkl. Verwendung über Kompositmodul“ nennt Seiten, auf denen das Modul nur innerhalb eines Kompositmoduls vorkommt.

## Herkunft
- [DM-22](../../01_Design-Analyse/Module/DM-22_Leimspuren-Grafik.md) – Leimspuren-Grafik: Grafik und Platzierung der 18 Wertfelder
- [RM-28](../../02_Referenz-Analyse/Module/RM-28_Leimspuren-Grafik.md) – Leimspuren-Grafik: aufgefalteter Kartonzuschnitt mit 18 Winkelfeldern

## WPF-Umsetzung
- **Control:** `HM31_GlueTrackGraphic` (UserControl), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `UserControl` (`HM31_GlueTrackGraphic`): `Viewbox` mit `Canvas` für Zuschnitt und Spuren, Felder als `ItemsControl` mit `HM12_ValueInput` in einem `Canvas` (Positionen aus `Fields`).
- **Dependency Properties:** `Title`, `Fields`, `CutoutGeometry`; **Command:** `CommitCommand`.
- Farben nur über `Brush.Graphic.Carton` und `Brush.Graphic.Glue`.
- **Symbole** (`Themes/Icons.xaml`, Schema `Icon.<Bereich>.<Name>`): Designsystem: `Icon.Status.Error`.
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-31-P01 | Grafiktitel | „Leimspuren“ | offen |
| HM-31-P02 | Spuren | 1 lange linke, je 4 kurze oben und unten | offen |
| HM-31-P03 | Felder | 18 Felder, Reihen 5, 4, 5, 4 | offen |
| HM-31-P04 | Werte | Reihe 1: 200/205/205/205/205; Reihe 4: 325/329/329/329 | offen |
| HM-31-P05 | Aufteilung | Felder sind HM-12, Grafik ist HM-31 | offen |
| HM-31-P06 | Touch | Felder ≥ `Size.Touch.Min`, Standard `Size.Touch.Default` hoch | offen |
