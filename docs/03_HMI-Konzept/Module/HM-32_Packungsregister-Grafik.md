# HM-32 – Packungsregister-Grafik

## Funktion
Grafische Darstellung der Maschinenstationen (HS-28): Stationsfelder in Reihen (linker Block mit 6 Feldern, Drehstern mit 12 Armen, rechte Reihe ab Nr. 40, senkrechte Spalte mit 9 Feldern), Legende und horizontaler Bildlauf. Antippen eines Felds ändert den Zustand der Station manuell (Zustandsfolge nicht beschrieben, OP-53). Die fünf Zustände der Referenz (grau, rot, gelb, orange, grün) werden durch Symbol und Wort unterschieden, die Statusfarbe tritt nur dort auf, wo sie einen Status ausdrückt (A-53).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Stationen (`Stations`) | IReadOnlyList<PackStation> | – | Number (int), State, Position im Layout |
| Zustand (`State`) | enum PackState { None, Present, Filled, Ok, Bad } | – | keine Packung, vorhanden, befüllt, in Ordnung, schlecht |
| Stationsnummer (`Number`) | int | – | ab 40 (Bild 40 bis mindestens 61) |
| Legende zeigen (`ShowLegend`) | bool | – | Standard true; Legende als feste Leiste unter dem Bildlaufbereich (scrollt nicht mit) |
| Antippen (`ToggleStationCommand`) | ICommand<PackStation> | – | manuelle Zustandsänderung |
| Bildlauf (`HorizontalOffset`) | double | – | – |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Keine Packung | `Brush.Surface`, Kontur `Border.Thin` | `Icon.Status.Inactive` (leer) und Wort „keine“ |
| Packung vorhanden | `Brush.Surface.Sunken`, Kontur `Border.Medium` `Brush.Border.Control` | Symbol `Icon.Pack.Present` (gefülltes Quadrat) und Wort „vorhanden“ |
| Befüllt | `Brush.Surface`, Kontur `Border.Medium` `Brush.Status.Info.Fg` (keine Statusfläche im Normalbetrieb, Designsystem 1.2) | `Icon.Pack.Filled` und Wort „befüllt“ |
| In Ordnung | `Brush.Surface`, Kontur `Border.Medium` `Brush.Status.Ok.Fg` (keine Statusfläche im Normalbetrieb) | `Icon.Status.Ok` und Wort „OK“ |
| Schlecht (ausgestoßen) | `Brush.Status.Error.Subtle`, Kontur `Border.Thick` `Brush.Status.Error.Fg` | `Icon.Status.Error` und Wort „schlecht“ |
| Gedrückt | `Brush.Button.Pressed` | Kontur `Border.Medium` |

## Verwendet auf Seiten (IDs)
- [HS-28](../Seiten/HS-28_Packungsregister.md) – Packungsregister

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die Liste ist aus den Abschnitten „Verwendete Module“ und den Elemente-Tabellen der HS-Seiten abgeleitet (Stand Konsolidierung nach Phase 3, Punkt 4); „inkl. Verwendung über Kompositmodul“ nennt Seiten, auf denen das Modul nur innerhalb eines Kompositmoduls vorkommt.

## Herkunft
- [RM-29](../../02_Referenz-Analyse/Module/RM-29_Packungsregister-Grafik.md) – Packungsregister-Grafik: Maschinenstationen mit fünf Packungszuständen
- Design: keine Entsprechung (Element nur in der Referenz).

## WPF-Umsetzung
- **Control:** `HM32_PackRegisterGraphic` (UserControl), Ordner `src/.../Controls/`, Code-behind nur Dependency-Property-Deklarationen ohne Logik (Custom Control, A-73).
- **Typ:** `UserControl` (`HM32_PackRegisterGraphic`) in einem `ScrollViewer` (horizontal), Stationen als `ItemsControl` mit `Canvas`-Layout; Legende `HM32_Legend`.
- **Dependency Properties:** `Stations`, `ShowLegend`; **Command:** `ToggleStationCommand`.
- Stationsfeld mindestens `Size.Touch.Min` × `Size.Touch.Min`.
- **Symbole** (`Themes/Icons.xaml`, Schema `Icon.<Bereich>.<Name>`): Designsystem: `Icon.Status.Error`, `Icon.Status.Inactive`, `Icon.Status.Ok`; **neu, hier definiert:** `Icon.Pack.Filled`, `Icon.Pack.Present`.
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-32-P01 | Layout | Block 6, Drehstern 12, Reihe ab Nr. 40, Spalte 9 | offen |
| HM-32-P02 | Zustände | fünf Zustände mit Symbol und Wort, Legende dazu | offen |
| HM-32-P03 | Antippen | ändert den Zustand der Station | offen |
| HM-32-P04 | Bildlauf | horizontales Scrollen | offen |
| HM-32-P05 | Touch | Stationsfelder ≥ `Size.Touch.Min` | offen |
