# HM-04 – Brotkrümel-Navigation

## Funktion
Zeigt den Seitenpfad als Pfeilsegmente (z. B. „Einstellung › Zuführung Karton › Heißleimgerät“). Das letzte Segment ist die aktuelle Seite und ersetzt den Seitentitel der Referenz-Kopfzeile. Die übrigen Segmente sind antippbar und springen zur Ebene (A-27). Eine Objektkennung (z. B. „HD1“, „KW“) wird an das letzte Segment gehängt. Bei mehr als fünf Segmenten werden mittlere Segmente zu „…“ gekürzt. Pfade je Seite stehen in Navigation.md (Phase 3).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Segmente (`Segments`) | IReadOnlyList<BreadcrumbSegment> | – | 1 bis 5 (Bild 1 bis 3, Referenz bis 4); je Label, PageId |
| Objektkennung (`ObjectSuffix`) | string | – | optional, z. B. „HD1“, „KW“ |
| Navigieren (`NavigateCommand`) | ICommand (Parameter string Seiten-ID) | – | Seiten-ID des Segments |
| Segment aktuell (`IsCurrent`) | bool (je Segment) | – | genau das letzte Segment |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Segment | `Brush.Surface.Sunken`, Kontur `Border.Thin` `Brush.Border.Control`, Text `Font.Size.Body` `Brush.Text.Primary`, Höhe `Size.Touch.Default` | Pfeilform (`Icon.Chevron`) als Trenner |
| Aktuelles Segment | Text `Font.Weight.Strong`, keine Navigation | Fettschrift und Position am Ende; `AutomationProperties.ItemStatus="current"` |
| Gedrückt | `Brush.Button.Pressed`, Kontur `Border.Medium` | dickere Kontur |
| Gekürzt | mittleres Segment „…“ | Text „…“, Tippen zeigt vollständigen Pfad |

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
- [HS-40](../Seiten/HS-40_Zufuehrungen.md) – Zuführungen
- [HS-41](../Seiten/HS-41_Dosierer-Uebersicht.md) – Dosierer-Übersicht
- [HS-42](../Seiten/HS-42_Waagen.md) – Waagen
- [HS-43](../Seiten/HS-43_Schichtplan.md) – Schichtplan

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die HS-Dateien entstehen in Phase 3 (Punkt 4); die Links sind vorläufig.

## Herkunft
- [DM-07](../../01_Design-Analyse/Module/DM-07_Brotkruemel-Navigation.md) – Brotkrümel-Navigation: Pfeilsegmente
- [RM-01](../../02_Referenz-Analyse/Module/RM-01_Kopfzeile.md) – Kopfzeile: Seitentitel und Titelzusatz (Objektkennung wie „HD1“) werden letztes Segment

## WPF-Umsetzung
- **Control:** `HM04_Breadcrumb` (UserControl), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `UserControl` (`ItemsControl` mit horizontalem `StackPanel`); Segment als `HM04_BreadcrumbSegment` (`ControlTemplate`).
- **Dependency Properties:** `Segments`, `ObjectSuffix`; **Command:** `NavigateCommand`.
- **Layout:** Spalte 56* der Brotkrümel-/Kennzahlzeile.
- **Symbole** (`Themes/Icons.xaml`, Schema `Icon.<Bereich>.<Name>`): Designsystem: `Icon.Chevron`.
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-04-P01 | Segmentzahl | DS-01: 1, DS-02: 1, DS-03: 3, DS-04: 2, DS-05: 3 (Pfade des Designs) | offen |
| HM-04-P02 | Aktuell | letztes Segment fett, nicht antippbar | offen |
| HM-04-P03 | Antippen | Segment springt zur Ebene | offen |
| HM-04-P04 | Schriftgröße | mindestens `Font.Size.Body`, Segmenthöhe `Size.Touch.Default` | offen |
| HM-04-P05 | Farbe | keine Bedeutung der Farbe (Entwurfsinkonsistenz blau/lachs entfällt) | offen |
