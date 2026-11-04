# HM-16 – Kachel-Navigation

## Funktion
Raster aus großen Kacheltasten für Navigation oder Schnellzugriff (Seite Einstellungen 5 × 4, Handbetrieb-Auswahl 4 × 4, EA-Übersicht 4 × 2, Systemeinstellungen 3 × 3; Schnellzugriff auf der Produktionsseite 3 × 2). Kachel: Beschriftung (mehrzeilig, automatischer Umbruch), optionales Symbol über dem Text, Schlüssel-Symbol bei berechtigungspflichtigen Zielen. Ziel ist eine Seite oder eine Aktion; Warnaktionen (Steuerung neu starten) öffnen vorher ein Bestätigungs-Pop-up. Leere Kacheln erscheinen als „Reserviert“ im Zustand deaktiviert (A-29). Kachel ohne Ein/Aus-Zustand. **Abgrenzung zu den Zustandstasten:** HM-16 ist das Raster (Spalten × Zeilen, Zellmaß `Size.Touch.Large`, Abstand `Size.Touch.Gap`) und die Navigationskachel ohne Zustand. Der Tastenblock 3 × 2 auf HS-01 (Automatik, Zuführung Papier und Karton, Leerpakete ausblasen, Abfüllung, Bunker leerfahren) sind **Zustandstasten**: Sie liegen in diesem Raster (Elementart `StateToggle`), jede Zelle ist aber ein [HM-08](HM-08_Zustandstaste-Umschalter.md) (`ToggleStyle = Button`, `ButtonSize = Tile`); Zustand, Wort und Befehl gehören HM-08, HM-16 liefert nur Anordnung und Maße.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Kacheln (`Items`) | IReadOnlyList<TileItem> | – | je Label, Icon, TargetPageId oder Command, IsEmpty, RequiresPermission |
| Spalten (`Columns`) | int | – | 1 bis 6 (5, 4, 4, 3, 3 in der Referenz) |
| Zeilen (`Rows`) | int | – | 1 bis 4 |
| Kachelgröße (`TileSize`) | enum TileSize { Large, Small } | px | Large `Size.Touch.Large` hoch, Small `Size.Touch.Default` hoch („Beleuchtung“) |
| Leere Kacheln (`EmptyTileMode`) | enum EmptyTileMode { Reserved, Hidden } | – | Reserved Standard (A-29) |
| Item-Felder deaktiviert (`TileItem.IsDisabled`, `DisabledReason`) | bool, string? | – | deaktivierte Kachel mit Beschriftung und Grund (Meldezeile bei Tippen), z. B. Endkontrollwaage in HS-42 mit `Icon.Block` und Text „Nicht verfügbar“ |
| Navigationsanzeiger (`ShowNavigationIndicator`) | bool | – | Standard true: `Icon.Chevron` als zweiter Kanal an Navigationskacheln (HS-35) |
| Elementart (`ItemKind`) | enum TileItemKind { Navigation, StateToggle } | – | Navigation Standard (Kachel-Taste ohne Zustand); StateToggle = jede Zelle ist ein HM-08 in Tastenform, Kachelhöhe |
| Befehl (`NavigateCommand`) | ICommand (Parameter TileItem) | – | Seite oder Aktion (nur ItemKind Navigation) |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Normal | `Brush.Button.Normal`, Kontur `Border.Thin`, Text `Font.Size.Body` zentriert, `Radius.Control`, Höhe `Size.Touch.Large` | Beschriftung (und Symbol) |
| Gedrückt | `Brush.Button.Pressed`, `Border.Medium` | dickere Kontur |
| Leer / reserviert | Kontur gestrichelt (`Border.Dash`), Text `Brush.Text.Disabled` | gestrichelte Kontur und Text „Reserviert“ |
| Deaktiviert | wie leer, mit Beschriftung | gestrichelte Kontur; Grund in Meldezeile (A-28) |
| Berechtigung | Normal | `Icon.Key` bzw. `Icon.Lock` (`Size.Icon.S`) oben rechts |
| Deaktiviert mit Grund | gestrichelte Kontur, Beschriftung `Brush.Text.Disabled`, `Icon.Block` | Text „Nicht verfügbar“ und Grund in der Meldezeile beim Tippen (HS-42) |
| Warnaktion | Normal | `Icon.Status.Warning` in der Kachel; Bestätigung vor Ausführung |

## Verwendet auf Seiten (IDs)
- [HS-01](../Seiten/HS-01_Produktion.md) – Produktion
- [HS-04](../Seiten/HS-04_Einstellungen.md) – Einstellungen
- [HS-30](../Seiten/HS-30_Handbetrieb-Auswahl.md) – Handbetrieb Auswahl
- [HS-33](../Seiten/HS-33_EA-Uebersicht.md) – EA-Übersicht
- [HS-35](../Seiten/HS-35_Systemeinstellungen.md) – Systemeinstellungen
- [HS-40](../Seiten/HS-40_Zufuehrungen.md) – Zuführungen
- [HS-42](../Seiten/HS-42_Waagen.md) – Waagen

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die Liste ist aus den Abschnitten „Verwendete Module“ und den Elemente-Tabellen der HS-Seiten abgeleitet (Stand Konsolidierung nach Phase 3, Punkt 4); „inkl. Verwendung über Kompositmodul“ nennt Seiten, auf denen das Modul nur innerhalb eines Kompositmoduls vorkommt.

## Herkunft
- [DM-12](../../01_Design-Analyse/Module/DM-12_Kachel-Taste.md) – Kachel-Taste: große Kachel-Taste, auch ohne Beschriftung
- [RM-14](../../02_Referenz-Analyse/Module/RM-14_Kachel-Navigation.md) – Kachel-Navigation: Raster aus Kacheltasten (Einstellungen, Handbetrieb-Auswahl, EA-Übersicht, Systemeinstellungen)

## WPF-Umsetzung
- **Control:** `HM16_TileNavigation` (UserControl (Kachel: `ControlTemplate` auf `Button`)), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `UserControl` (`ItemsControl` mit `UniformGrid`), Kachel `HM16_Tile` als `ControlTemplate`.
- **Dependency Properties:** `Items`, `Columns`, `Rows`, `TileSize`, `EmptyTileMode`, `ItemKind`, `ShowNavigationIndicator`; **Command:** `NavigateCommand`.
- Abstand zwischen Kacheln `Size.Touch.Gap`, Beschriftung aus `.resx`, Umbruch automatisch (OP-13).
- **Symbole** (`Themes/Icons.xaml`, Schema `Icon.<Bereich>.<Name>`): Designsystem: `Icon.Block`, `Icon.Chevron`, `Icon.Key`, `Icon.Lock`, `Icon.Status.Warning`.
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-16-P01 | DS-02 | 16 Kacheln 2 × 4 in Mitte und rechts, davon 4 leer, plus kleine Taste „Beleuchtung“ | offen |
| HM-16-P02 | DS-01 | 6 Kacheln in 2 Reihen à 3 | offen |
| HM-16-P03 | Leere Kachel | gleiche Gestalt, Text „Reserviert“, deaktiviert | offen |
| HM-16-P04 | Beschriftung | automatischer Umbruch, keine Trennstriche („Schließmaschine“) | offen |
| HM-16-P05 | Raster Referenz | HS-04 5 × 4 (18 beschriftet, 2 leer), HS-30 4 × 4, HS-33 4 × 2, HS-35 3 × 3 | offen |
| HM-16-P06 | Touch | Höhe ≥ `Size.Touch.Large` (Small `Size.Touch.Default`), Abstand `Size.Touch.Gap` | offen |
| HM-16-P07 | Zustandstasten im Raster | HS-01: 6 Zustandstasten (HM-08, Tile) im Raster 3 × 2 mit `Size.Touch.Large` und `Size.Touch.Gap`; kein Ziel, keine Navigation | offen |
