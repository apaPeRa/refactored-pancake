# HM-06 – Funktionsleiste unten

## Funktion
Leiste am unteren Rand (Zeile `Size.FunctionBar.Height`, `Brush.Surface.Sunken`) als Container für die seitenspezifischen Tasten ([HM-07](HM-07_Aktionstaste.md), [HM-08](HM-08_Zustandstaste-Umschalter.md)) und die Blättertasten ([HM-19](HM-19_Blaettertasten.md)). Tasten beginnen links mit `Size.Touch.Gap` Abstand, Breite je Taste mindestens `Size.FunctionButton.MinWidth`, höchstens 5 seitenspezifische Tasten, weitere hinter einer Überlauf-Taste „Mehr“ (`Icon.More`); eine rechtsbündige Gruppe nimmt die Hauptaktion der Seite auf. Die Leiste bleibt auch leer sichtbar (Rahmenkonsistenz). Die festen Tasten der Referenz (Produktion, Einstellungen, Zurück) liegen in der Seitenleiste [HM-01](HM-01_Seitenleiste.md).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Tasten links (`Items`) | IReadOnlyList<object> | – | 0 bis 5 Tasten (Referenz 0 bis 3, mit Blättertasten bis 4); Rest im Überlauf |
| Tasten rechts (`TrailingItems`) | IReadOnlyList<object> | – | 0 bis 2 |
| Aktuelle Seite (`CurrentTargetId`) | string | – | Seiten-ID; markiert die Seitentaste (z. B. „Druck“ auf HS-07) |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Mit Tasten | `Brush.Surface.Sunken`, Tasten `Size.Touch.Default`, Innenrand `Space.M` | Tastenbeschriftung |
| Leer | `Brush.Surface.Sunken` bleibt sichtbar | keine Platzhalter |
| Taste der aktuellen Seite | `Brush.Button.Active`, Text `Brush.Text.OnActive` | Haken-Symbol `Icon.State.On` und Balken (`Border.Thick`) unter der Taste |
| Überlauf (> 5 Tasten) | Taste „Mehr“ | Text „Mehr“ und `Icon.More` |

## Verwendet auf Seiten (IDs)
- [HS-01](../Seiten/HS-01_Produktion.md) – Produktion
- [HS-04](../Seiten/HS-04_Einstellungen.md) – Einstellungen
- [HS-05](../Seiten/HS-05_Zufuehrung-Papier.md) – Zuführung Papier
- [HS-06](../Seiten/HS-06_Zufuehrung-Karton.md) – Zuführung Karton
- [HS-07](../Seiten/HS-07_Heissleim-Nordson.md) – Heißleim Nordson
- [HS-08](../Seiten/HS-08_Heissleim-Parameter.md) – Heißleim Parameter
- [HS-09](../Seiten/HS-09_Heissleim-Druck.md) – Heißleim Druck
- [HS-10](../Seiten/HS-10_Zeitschaltuhr.md) – Zeitschaltuhr
- [HS-11](../Seiten/HS-11_Hauptdosierer-1-und-2.md) – Hauptdosierer 1 & 2
- [HS-12](../Seiten/HS-12_Motorparameter.md) – Motorparameter (Hauptdosierer)
- [HS-13](../Seiten/HS-13_Kontrollwaage.md) – Kontrollwaage
- [HS-14](../Seiten/HS-14_Einzelgewichte.md) – Einzelgewichte
- [HS-15](../Seiten/HS-15_Trend.md) – Trend
- [HS-16](../Seiten/HS-16_Schliessmaschine.md) – Schließmaschine
- [HS-17](../Seiten/HS-17_Motorparameter-Schliessmaschine.md) – Motorparameter (Schließmaschine)
- [HS-18](../Seiten/HS-18_Gewichtskorrektur-Schliessmaschine.md) – Gewichtskorrektur (Schließmaschine)
- [HS-19](../Seiten/HS-19_Nachdosierer.md) – Nachdosierer
- [HS-20](../Seiten/HS-20_Motorparameter.md) – Motorparameter (Nachdosierer)
- [HS-21](../Seiten/HS-21_Gewichtskorrektur.md) – Gewichtskorrektur (Nachdosierer)
- [HS-22](../Seiten/HS-22_Heizungen.md) – Heizungen
- [HS-23](../Seiten/HS-23_Regulierung.md) – Regulierung
- [HS-25](../Seiten/HS-25_Nocken.md) – Nocken
- [HS-26](../Seiten/HS-26_Nockenuebersicht.md) – Nockenübersicht
- [HS-27](../Seiten/HS-27_Waagen-Kalibrieren.md) – Waagen Kalibrieren
- [HS-28](../Seiten/HS-28_Packungsregister.md) – Packungsregister
- [HS-29](../Seiten/HS-29_Produktionsstatistik.md) – Produktionsstatistik
- [HS-30](../Seiten/HS-30_Handbetrieb-Auswahl.md) – Handbetrieb Auswahl
- [HS-31](../Seiten/HS-31_Handbetrieb.md) – Handbetrieb
- [HS-32](../Seiten/HS-32_Geber-setzen.md) – Geber setzen
- [HS-33](../Seiten/HS-33_EA-Uebersicht.md) – EA-Übersicht
- [HS-34](../Seiten/HS-34_EA-Anzeige.md) – EA-Anzeige
- [HS-35](../Seiten/HS-35_Systemeinstellungen.md) – Systemeinstellungen
- [HS-36](../Seiten/HS-36_Service.md) – Service
- [HS-37](../Seiten/HS-37_Meldearchiv.md) – Meldearchiv
- [HS-38](../Seiten/HS-38_Meldeanzeige.md) – Meldeanzeige
- [HS-39](../Seiten/HS-39_System-und-Antriebsinfos.md) – System- und Antriebsinfos
- [HS-40](../Seiten/HS-40_Zuefuehrungen.md) – Zuführungen
- [HS-41](../Seiten/HS-41_Dosierer-Uebersicht.md) – Dosierer-Übersicht
- [HS-42](../Seiten/HS-42_Waagen.md) – Waagen
- [HS-43](../Seiten/HS-43_Schichtplan.md) – Schichtplan

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die HS-Dateien entstehen in Phase 3 (Punkt 4); die Links sind vorläufig.

## Herkunft
- [DM-09](../../01_Design-Analyse/Module/DM-09_Funktionsleiste.md) – Funktionsleiste: Container der Funktionstasten
- [RM-03](../../02_Referenz-Analyse/Module/RM-03_Funktionsleiste-unten.md) – Funktionsleiste unten: Leiste unten mit seitenspezifischen Tasten „Navigation unten links“; feste Tasten wandern in HM-01

## WPF-Umsetzung
- **Control:** `HM06_FunctionBar` (UserControl), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `UserControl` mit `ItemsControl` (horizontaler `StackPanel`, Abstand `Space.M`), zwei Bereiche (links, rechts).
- **Dependency Properties:** `Items`, `TrailingItems`, `CurrentTargetId`.
- **Inhaltsvorlagen:** `DataTemplate` je Tastenmodell, rendert HM-07, HM-08 oder HM-19.
- **Neue Symbole** (`Themes/Icons.xaml`): `Icon.More` (Designsystem).
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-06-P01 | Lage | unten, volle Breite des Arbeitsbereichs, Höhe `Size.FunctionBar.Height` | offen |
| HM-06-P02 | Tastenzahl | DS-03: 3 (Temperatur, Druck, Zeitplan), DS-01: 1 (Schichtplan), DS-02: 1 (Sprache) | offen |
| HM-06-P03 | Leer | Leiste bleibt als Fläche sichtbar | offen |
| HM-06-P04 | Aktuelle Seite | Taste der aktuellen Seite mit Symbol und Balken | offen |
| HM-06-P05 | Touch | Tasten `Size.Touch.Default` hoch, Abstand `Size.Touch.Gap` | offen |
