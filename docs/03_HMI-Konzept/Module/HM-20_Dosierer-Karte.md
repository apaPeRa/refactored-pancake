# HM-20 – Dosierer-Karte / Dosierer-Seitengerüst

## Funktion
Karte für einen Schneckendosierer. Eine Funktion, zwei Darstellungen als Parameter: **Kompakt** (Karte der Übersicht mit Soll, Regulierwert, Füllstand Trichter oben/unten, drei Schaltern, Auslastung, Tasten Manuell/Entleeren, Detail-Symbol) und **Detail** (Seitengerüst mit allen Parametern: Eichdosierung, Schnecke Drehzahl, Rührer, Nachlauf Rührer, Querschnecke, Seitenlinks). Variante Hauptdosierer (Soll in %, Soll absolut in g) und Nachdosierer (Soll in g, Max. Nachgabe, Aktuelle Nachgabe). Die Karte setzt nur die Module [HM-12](HM-12_Eingabefeld-Schluesselsymbol.md), [HM-11](HM-11_Anzeigefeld.md), [HM-09](HM-09_Status-LED.md), [HM-08](HM-08_Zustandstaste-Umschalter.md), [HM-10](HM-10_Fortschrittsbalken.md) und [HM-07](HM-07_Aktionstaste.md) zusammen (keine Kopien, Verweise in WPF-Umsetzung).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Titel (`Title`) | string | – | Hauptdosierer 1, Hauptdosierer 2, Nachdosierer |
| Art (`DoserKind`) | enum DoserKind { Main, Secondary } | – | – |
| Darstellung (`CardMode`) | enum CardMode { Compact, Detail } | – | Compact Standard |
| Soll Prozent (`TargetPercent`) | double | % | 0 bis 100 (Bild 48, 52) |
| Soll Gewicht (`TargetWeight`) | double | g | Bild 113, 122 (HD absolut), 250 (ND) |
| Max. Nachgabe (`MaxRefill`), Aktuelle Nachgabe (`CurrentRefill`) | double | g | nur ND (Bild 50, 13) |
| Regulierwert (`RegulationValue`) | double | g | Bild 5,30; 0,00; 4,81 |
| Eichdosierung (`CalibrationWeight`), Umdrehungen (`CalibrationRevolutions`) | double / int | g / – | Bild 137,50 g und 4; 18,50 g und 5 |
| Schnecke Drehzahl (`ScrewSpeed`) | double | 1/min | Bild 2800 |
| Rührer (`AgitatorPercent`), Querschnecke (`CrossScrewPercent`) | double | % | 0 bis 100 (Bild 20, 30) |
| Nachlauf Rührer (`AgitatorRunOn`) | double | s | Bild 0 |
| Trichter oben/unten (`HopperUpper`, `HopperLower`) | LedState | – | Off, On, Warning, Error |
| Auslastung (`Load`) | double | % | 0 bis 100 (Bild 91, 92, 73) |
| Schalter (`CrossScrewEnabled`, `AgitatorEnabled`, `RegulationEnabled`) | bool | – | ein / aus |
| Ausgewählt (`IsSelected`), Gesperrt (`IsLocked`) | bool | – | – |
| Befehle | ICommand | – | `ManualCommand`, `EmptyCommand` (Dauer), `CalibrateCommand`, `OpenDetailCommand`, `OpenRegulationCommand`, `OpenMotorCommand`, `OpenWeightCorrectionCommand` |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Normal | `Brush.Surface`, Kontur `Border.Thin`, `Radius.Card`, Innenabstand `Space.M`, Titel `Font.Size.Value`, Detail-Symbol 48 px oben rechts | Titel als Text |
| Ausgewählt | Kontur `Border.Thick` `Brush.Border.Focus` | Text „Ausgewählt“ und `Icon.State.On` im Titel |
| Gesperrt | Tasten deaktiviert (gestrichelt), `Brush.Text.Disabled` | `Icon.Lock` und Text „Gesperrt“ |
| Entleeren läuft | Taste Entleeren im Zustand Läuft (HM-07) | Wort „Läuft“ |
| Trichter unten leer/Fehler | LED `Brush.Status.Error.Fill` (HM-09) | `Icon.Status.Error` und Wort |
| Auslastung hoch | Balken Warnung (HM-10) | `Icon.Status.Warning` und Zahl |
| Teilzustände | gemäß Bestandteilen | siehe HM-07 bis HM-12 |

## Verwendet auf Seiten (IDs)
- [HS-11](../Seiten/HS-11_Hauptdosierer-1-und-2.md) – Hauptdosierer 1 & 2
- [HS-19](../Seiten/HS-19_Nachdosierer.md) – Nachdosierer
- [HS-41](../Seiten/HS-41_Dosierer-Uebersicht.md) – Dosierer-Übersicht

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die HS-Dateien entstehen in Phase 3 (Punkt 4); die Links sind vorläufig.

## Herkunft
- [DM-20](../../01_Design-Analyse/Module/DM-20_Dosierer-Karte.md) – Dosierer-Karte: Dosierer-Karte der Übersicht
- [RM-18](../../02_Referenz-Analyse/Module/RM-18_Dosierer-Seitengeruest.md) – Dosierer-Seitengerüst: Dosierer-Seitengerüst Hauptdosierer 1/2 und Nachdosierer

## WPF-Umsetzung
- **Control:** `HM20_DosingCard` (UserControl), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `UserControl` (`HM20_DosingCard`), setzt `HM12_ValueInput`, `HM11_ValueDisplay`, `HM09_StatusLed`, `HM08_ToggleSwitch`, `HM10_ProgressBar`, `HM07_ActionButton` ein; Darstellung Compact/Detail per `DataTrigger` auf `CardMode`.
- **Dependency Properties:** siehe Tabelle; **Commands:** `ManualCommand`, `EmptyCommand`, `CalibrateCommand`, `OpenDetailCommand`, `OpenRegulationCommand`, `OpenMotorCommand`, `OpenWeightCorrectionCommand`.
- **Wechsel HD1/HD2** auf der Seite über HM-19; das ViewModel tauscht den Datenkontext. Offene Fachfragen: OP-45.
- **Neue Symbole** (`Themes/Icons.xaml`): `Icon.Fill.Hopper` (neu), `Icon.Move` (Designsystem).
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-20-P01 | Karten | DS-04: 3 Karten Hauptdosierer 1, Hauptdosierer 2, Nachdosierer | offen |
| HM-20-P02 | Bestandteile | Soll/Regulierwert, 2 LEDs, 3 Umschalter, Auslastung, Tasten Manuell/Entleeren, Detail-Symbol | offen |
| HM-20-P03 | Hervorhebung | Nachdosierer mit Text/Symbol „Ausgewählt“, nicht nur Farbe | offen |
| HM-20-P04 | Variante Hauptdosierer | Soll in % mit Soll absolut in g | offen |
| HM-20-P05 | Variante Nachdosierer | Soll in g, Max./Aktuelle Nachgabe statt Soll absolut | offen |
| HM-20-P06 | Keine Kopien | Bestandteile sind HM-07 bis HM-12 | offen |
| HM-20-P07 | Detaildarstellung | Parameter RS-11/RS-19 vollständig: Eichdosierung, Drehzahl, Rührer, Querschnecke | offen |
