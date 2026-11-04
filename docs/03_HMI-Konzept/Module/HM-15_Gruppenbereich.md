# HM-15 – Gruppenbereich

## Funktion
Container mit Überschrift, der zusammengehörige Elemente bündelt (Geschwindigkeit, Produktion, Versorgung, Packstoffrolle, Klebestelle, Kupplung, Leimspuren, Auslaufband u. a.). Varianten als Parameter: **Panel** (Fläche vertieft mit Rahmen) und **Überschrift** (nur Text mit Trennlinie, z. B. „Status“, „Aktuelle Temperaturen“; Unterstreichung entfällt). Optional Zwischenüberschrift (reiner Text, z. B. „Linienbetrieb“) und Hervorhebung. Die Anordnung des Inhalts liefert die Seite.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Überschrift (`Header`) | string | – | z. B. „Geschwindigkeit“, „Produktion“, „EKW“, „Versorgung“ |
| Zwischenüberschrift (`Subheader`) | string? | – | optional, ohne Wert |
| Darstellung (`GroupStyle`) | enum GroupStyle { Panel, Heading } | – | Panel Standard |
| Inhalt (`Content`) | object | – | beliebige Module, leer erlaubt |
| Hervorgehoben (`IsHighlighted`) | bool | – | – |
| Hervorhebungstext (`HighlightText`) | string? | – | z. B. „Ausgewählt“ |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Normal (Panel) | `Brush.Surface.Sunken`, `Radius.Card`, Innenabstand `Space.M`, Überschrift `Font.Size.Value` `Font.Weight.Strong` | Überschrift als Text |
| Leer | wie Normal | nur Überschrift sichtbar |
| Hervorgehoben | Kontur `Border.Thick` `Brush.Border.Focus` | Text/Symbol „Ausgewählt“, nicht nur Farbe |
| Überschrift-Variante | ohne Fläche, Linie `Brush.Divider` unter dem Text | Fettschrift und Linie statt Unterstreichung |

Die Überschrift-Variante deckt die Textüberschriften ohne Rahmen ab (HS-07 „Status“, HS-09 „Druckregelung“); RM-15 zählt sie nicht, das Modul führt sie als Variante.

## Verwendet auf Seiten (IDs)
- [HS-01](../Seiten/HS-01_Produktion.md) – Produktion
- [HS-04](../Seiten/HS-04_Einstellungen.md) – Einstellungen
- [HS-05](../Seiten/HS-05_Zufuehrung-Papier.md) – Zuführung Papier
- [HS-06](../Seiten/HS-06_Zufuehrung-Karton.md) – Zuführung Karton
- [HS-07](../Seiten/HS-07_Heissleim-Nordson.md) – Heißleim Nordson
- [HS-08](../Seiten/HS-08_Heissleim-Parameter.md) – Heißleim Parameter
- [HS-09](../Seiten/HS-09_Heissleim-Druck.md) – Heißleim Druck
- [HS-11](../Seiten/HS-11_Hauptdosierer-1-und-2.md) – Hauptdosierer 1 & 2
- [HS-12](../Seiten/HS-12_Motorparameter.md) – Motorparameter (Hauptdosierer)
- [HS-13](../Seiten/HS-13_Kontrollwaage.md) – Kontrollwaage
- [HS-16](../Seiten/HS-16_Schliessmaschine.md) – Schließmaschine
- [HS-17](../Seiten/HS-17_Motorparameter-Schliessmaschine.md) – Motorparameter (Schließmaschine) (inkl. Verwendung über Kompositmodul HM-21)
- [HS-18](../Seiten/HS-18_Gewichtskorrektur-Schliessmaschine.md) – Gewichtskorrektur (Schließmaschine)
- [HS-19](../Seiten/HS-19_Nachdosierer.md) – Nachdosierer
- [HS-20](../Seiten/HS-20_Motorparameter.md) – Motorparameter (Nachdosierer)
- [HS-21](../Seiten/HS-21_Gewichtskorrektur.md) – Gewichtskorrektur (Nachdosierer)
- [HS-23](../Seiten/HS-23_Regulierung.md) – Regulierung
- [HS-27](../Seiten/HS-27_Waagen-Kalibrieren.md) – Waagen Kalibrieren
- [HS-39](../Seiten/HS-39_System-und-Antriebsinfos.md) – System- und Antriebsinfos
- [HS-41](../Seiten/HS-41_Dosierer-Uebersicht.md) – Dosierer-Übersicht
- [HS-43](../Seiten/HS-43_Schichtplan.md) – Schichtplan

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die Liste ist aus den Abschnitten „Verwendete Module“ und den Elemente-Tabellen der HS-Seiten abgeleitet (Stand Konsolidierung nach Phase 3, Punkt 4); „inkl. Verwendung über Kompositmodul“ nennt Seiten, auf denen das Modul nur innerhalb eines Kompositmoduls vorkommt.

## Herkunft
- [DM-11](../../01_Design-Analyse/Module/DM-11_Gruppenbereich.md) – Gruppenbereich: grauer Container mit Überschrift, Zwischenüberschrift
- [RM-15](../../02_Referenz-Analyse/Module/RM-15_Gruppenrahmen.md) – Gruppenrahmen: hellgraues Panel mit Überschrift; Textüberschrift ohne Rahmen als Variante

## WPF-Umsetzung
- **Control:** `HM15_GroupPanel` (UserControl (`HeaderedContentControl`)), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `UserControl`/`HeaderedContentControl` mit `ControlTemplate` (`HM15_GroupPanel`).
- **Dependency Properties:** `Header`, `Subheader`, `GroupStyle`, `IsHighlighted`, `HighlightText`, `Content`.
- Keine feste Größe; belegt Spalten- und Zeilenanteile im 12-Spalten-Raster der Seite.
- **Symbole** (`Themes/Icons.xaml`, Schema `Icon.<Bereich>.<Name>`): .
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-15-P01 | DS-01 | Überschriften Geschwindigkeit, Produktion, EKW, Versorgung | offen |
| HM-15-P02 | Zwischenüberschrift | „Linienbetrieb“ als Text ohne Wert | offen |
| HM-15-P03 | Leer | EKW zeigt nur die Überschrift | offen |
| HM-15-P04 | Überschrift-Variante | „Status“ und „Aktuelle Temperaturen“ ohne Unterstreichung, mit Trennlinie | offen |
| HM-15-P05 | Kontrast | Überschrift ≥ 4,5 : 1 (Entwurf weiß auf grau entfällt) | offen |
