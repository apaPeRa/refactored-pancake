# HM-35 – Regulierungs-Parameterblock

## Funktion
Parametersatz der automatischen Gewichtsregulierung je Dosierer (HS-23, zweimal gleich aufgebaut: Hauptdosierer und Nachdosierer). Felder: Anzahl Gewichte, Regulierschritt, Toleranz, Regulierung max, Regulierung ist ([HM-12](HM-12_Eingabefeld-Schluesselsymbol.md)); Mittelwert mit Zähler ([HM-11](HM-11_Anzeigefeld.md)); Umschalter „Regulierung“ ([HM-08](HM-08_Zustandstaste-Umschalter.md)) und Tasten „Regulierung −“/„Regulierung +“ ([HM-07](HM-07_Aktionstaste.md)). Der Zähler zählt gewogene Packungen; bei Erreichen von „Anzahl Gewichte“ wird der gleitende Mittelwert ausgewertet. Rahmen: [HM-15](HM-15_Gruppenbereich.md).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Titel (`Title`) | string | – | Hauptdosierer, Nachdosierer |
| Anzahl Gewichte (`SampleCount`) | int | Stk | Bild 10 (HD), 15 (ND) |
| Regulierschritt (`Step`) | double | % | Bild 50,0 |
| Toleranz (`Tolerance`) | double | g | Bild 1,0 (HD), 0,2 (ND) |
| Regulierung max (`MaxCorrection`) | double | g | Bild 75,0 (HD), 20,0 (ND) |
| Regulierung ist (`CurrentCorrection`) | double | g | Bild 0,0 (HD), 4,8 (ND) |
| Mittelwert (`Mean`) | double | g | Bild 0,0 (HD), 250,4 (ND) |
| Mittelwert-Zähler (`MeanCount`) | int | Stk | Bild 0 (HD), 11 (ND) |
| Regulierung ein (`IsRegulationOn`) | bool | – | – |
| Befehle | ICommand | – | `DecreaseCommand`, `IncreaseCommand`, `ToggleCommand` |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Regulierung ein | Umschalter Ein (HM-08) | `Icon.State.On` und Wort „Ein“ |
| Regulierung aus | Umschalter Aus | `Icon.State.Off` und Wort „Aus“ |
| Berechnung | Mittelwert-Feld mit Zähler „11 von 15“ | Zähler als Text |
| Korrektur am Limit | Feld „Regulierung ist“ Warnung | `Icon.Status.Warning` und Text „Maximum erreicht“ |
| Handeingriff | Tasten − / + gedrückt | Kontur `Border.Medium` |
| Gesperrt | Tasten deaktiviert | `Icon.Lock` |

## Verwendet auf Seiten (IDs)
- [HS-23](../Seiten/HS-23_Regulierung.md) – Regulierung

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die Liste ist aus den Abschnitten „Verwendete Module“ und den Elemente-Tabellen der HS-Seiten abgeleitet (Stand Konsolidierung nach Phase 3, Punkt 4); „inkl. Verwendung über Kompositmodul“ nennt Seiten, auf denen das Modul nur innerhalb eines Kompositmoduls vorkommt.

## Herkunft
- [RM-34](../../02_Referenz-Analyse/Module/RM-34_Regulierungs-Parameterblock.md) – Regulierungs-Parameterblock: Parametersatz der automatischen Gewichtsregulierung je Dosierer
- Design: keine Entsprechung (Element nur in der Referenz).

## WPF-Umsetzung
- **Control:** `HM35_RegulationBlock` (UserControl), Ordner `src/.../Controls/`, Code-behind nur Dependency-Property-Deklarationen ohne Logik (Custom Control, A-73).
- **Typ:** `UserControl` (`HM35_RegulationBlock`), `HM15_GroupPanel` mit `HM12_ValueInput`, `HM11_ValueDisplay`, `HM08_ToggleSwitch`, `HM07_ActionButton`.
- **Dependency Properties:** siehe Tabelle; **Commands:** `DecreaseCommand`, `IncreaseCommand`, `ToggleCommand`.
- **Symbole** (`Themes/Icons.xaml`, Schema `Icon.<Bereich>.<Name>`): Designsystem: `Icon.Lock`, `Icon.State.Off`, `Icon.State.On`, `Icon.Status.Warning`.
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-35-P01 | Aufbau | 5 Eingabefelder, Mittelwert mit Zähler, Umschalter, Tasten − / + | offen |
| HM-35-P02 | Werte HD | Anzahl 10, Schritt 50,0 %, Toleranz 1,0 g, max 75,0 g, ist 0,0 g | offen |
| HM-35-P03 | Werte ND | Anzahl 15, Toleranz 0,2 g, max 20,0 g, ist 4,8 g, Mittelwert 250,4 g (11 Stk) | offen |
| HM-35-P04 | Zweimal | Hauptdosierer und Nachdosierer gleich aufgebaut | offen |
| HM-35-P05 | Schlüssel | Eingabefelder, Umschalter und Tasten mit Schlüssel | offen |
