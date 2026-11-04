# HM-09 – Status-LED

## Funktion
Runde Anzeige für einen Zustand mit Beschriftung; nur Anzeige, nicht bedienbar. Die zwei Entwurfsvarianten (Ring/flach) und die Farbvarianten der Referenz (grau/grün/rot) werden eine Variante: Kreis `Size.Led` mit Statussymbol in der Statusfarbe und Wort. Anordnung als Parameter: einzeln, in Liste (Statusliste), kompakt in Tabellen/Gittern (ohne Wort, Symbol bleibt). Optionales Fachsymbol (Trichter) und Kennung (SPS-Name) sind möglich.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Beschriftung (`Label`) | string? | – | z. B. Bereitschaft, Temperatur, Füllsystem, Tankfüllstand, Keine Störung, oben, unten |
| Zustand (`State`) | enum LedState { Off, On, Warning, Error, Unknown } | – | Off = Inaktiv, On = Ok |
| Zustandswort (`StateText`) | string? | – | überschreibt das Standardwort |
| Wort zeigen (`ShowStateWord`) | bool | – | Standard true, in kompakter Form false |
| Kompakt (`IsCompact`) | bool | – | ohne Beschriftung und kleinere LED; das Statuswort steuert getrennt `ShowStateWord`: In kompakter Form darf es entfallen, wenn die Symbolform den Zustand eindeutig trägt (Haken, Dreieck, Kreuz, leerer Kreis) und das Wort als Tooltip und `AutomationProperties.Name` erhalten bleibt; wo Platz ist (z. B. HS-14), bleibt das Wort sichtbar |
| Fachsymbol (`Icon`) | Geometry? | – | z. B. `Icon.Fill.Hopper` |
| Kennung (`Identifier`) | string? | – | SPS-Name, z. B. S1_0KDE1_3 |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Aus / inaktiv | Symbol `Icon.Status.Inactive` (leerer Kreis) in `Brush.Status.Inactive.Fg`, ohne Fläche | leere Form und Wort „Aus“ |
| Ok / erfüllt | Kreis `Size.Led` mit Haken in `Brush.Status.Ok.Fg`, ohne Fläche | `Icon.Status.Ok` und Wort „OK“ |
| Warnung | Dreieck in `Brush.Status.Warning.Fg` (dunkles Bernstein), ohne Fläche | `Icon.Status.Warning` (Dreieck) und Wort „Warnung“ |
| Fehler | Kreuz in `Brush.Status.Error.Fg`, ohne Fläche | `Icon.Status.Error` (Kreuz) und Wort „Fehler“ |
| Unbekannt | `Brush.Status.Inactive.Fg` | Text „---“ |
| Gedrückt | reagiert nicht | kein Hover-/Pressed-Zustand |

## Verwendet auf Seiten (IDs)
- [HS-05](../Seiten/HS-05_Zufuehrung-Papier.md) – Zuführung Papier
- [HS-07](../Seiten/HS-07_Heissleim-Nordson.md) – Heißleim Nordson
- [HS-11](../Seiten/HS-11_Hauptdosierer-1-und-2.md) – Hauptdosierer 1 & 2
- [HS-14](../Seiten/HS-14_Einzelgewichte.md) – Einzelgewichte
- [HS-19](../Seiten/HS-19_Nachdosierer.md) – Nachdosierer
- [HS-22](../Seiten/HS-22_Heizungen.md) – Heizungen
- [HS-25](../Seiten/HS-25_Nocken.md) – Nocken
- [HS-26](../Seiten/HS-26_Nockenuebersicht.md) – Nockenübersicht (inkl. Verwendung über Kompositmodul HM-23)
- [HS-31](../Seiten/HS-31_Handbetrieb.md) – Handbetrieb
- [HS-32](../Seiten/HS-32_Geber-setzen.md) – Geber setzen
- [HS-34](../Seiten/HS-34_EA-Anzeige.md) – EA-Anzeige (inkl. Verwendung über Kompositmodul HM-36)
- [HS-41](../Seiten/HS-41_Dosierer-Uebersicht.md) – Dosierer-Übersicht (inkl. Verwendung über Kompositmodul HM-20)

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die Liste ist aus den Abschnitten „Verwendete Module“ und den Elemente-Tabellen der HS-Seiten abgeleitet (Stand Konsolidierung nach Phase 3, Punkt 4); „inkl. Verwendung über Kompositmodul“ nennt Seiten, auf denen das Modul nur innerhalb eines Kompositmoduls vorkommt.

## Herkunft
- [DM-14](../../01_Design-Analyse/Module/DM-14_Status-LED.md) – Status-LED: runde Zustandsanzeige
- [RM-08](../../02_Referenz-Analyse/Module/RM-08_Status-LED.md) – Status-LED: Kontrollleuchte einzeln, Liste, Tabellenzelle, Gitterzelle

## WPF-Umsetzung
- **Control:** `HM09_StatusLed` (ControlTemplate auf `Control`), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `ControlTemplate` auf `Control` (`HM09_StatusLed`), Symbol per `Path` aus `Themes/Icons.xaml`.
- **Dependency Properties:** `Label`, `State`, `StateText`, `ShowStateWord`, `IsCompact`, `Icon`, `Identifier`.
- **Maße:** LED `Size.Led`, Zeile ≥ `Size.Touch.Min` mit Beschriftung. Nicht fokussierbar (`IsHitTestVisible=False`).
- **Symbole** (`Themes/Icons.xaml`, Schema `Icon.<Bereich>.<Name>`): Designsystem: `Icon.Status.Error`, `Icon.Status.Inactive`, `Icon.Status.Ok`, `Icon.Status.Warning`; **neu, hier definiert:** `Icon.Fill.Hopper`.
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-09-P01 | Reihenfolge DS-03 | 7 LEDs in Seitenreihenfolge | offen |
| HM-09-P02 | Karte DS-04 | je Karte 2 LEDs „oben“, „unten“ | offen |
| HM-09-P03 | Zweiter Kanal | jeder Zustand hat eigene Form und Wort | offen |
| HM-09-P04 | Keine Bedienung | Antippen löst nichts aus | offen |
| HM-09-P05 | Variante | nur eine Form (kein Ring/flach) | offen |
