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

## Verwendet auf Seiten (IDs)
- [HS-01](../Seiten/HS-01_Produktion.md) – Produktion
- [HS-04](../Seiten/HS-04_Einstellungen.md) – Einstellungen
- [HS-05](../Seiten/HS-05_Zufuehrung-Papier.md) – Zuführung Papier
- [HS-06](../Seiten/HS-06_Zufuehrung-Karton.md) – Zuführung Karton
- [HS-07](../Seiten/HS-07_Heissleim-Nordson.md) – Heißleim Nordson
- [HS-16](../Seiten/HS-16_Schliessmaschine.md) – Schließmaschine

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die HS-Dateien entstehen in Phase 3 (Punkt 4); die Links sind vorläufig.

## Herkunft
- [DM-11](../../01_Design-Analyse/Module/DM-11_Gruppenbereich.md) – Gruppenbereich: grauer Container mit Überschrift, Zwischenüberschrift
- [RM-15](../../02_Referenz-Analyse/Module/RM-15_Gruppenrahmen.md) – Gruppenrahmen: hellgraues Panel mit Überschrift; Textüberschrift ohne Rahmen als Variante

## WPF-Umsetzung
- **Control:** `HM15_GroupPanel` (UserControl (`HeaderedContentControl`)), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `UserControl`/`HeaderedContentControl` mit `ControlTemplate` (`HM15_GroupPanel`).
- **Dependency Properties:** `Header`, `Subheader`, `GroupStyle`, `IsHighlighted`, `HighlightText`, `Content`.
- Keine feste Größe; belegt Spalten- und Zeilenanteile im 12-Spalten-Raster der Seite.
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
