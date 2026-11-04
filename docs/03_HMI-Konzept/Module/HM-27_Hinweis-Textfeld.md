# HM-27 – Hinweis-Textfeld

## Funktion
Nicht editierbares Textfeld für Hinweise, Warnungen und Statusmeldungen mit Symbol: Warnhinweis (Not-Aus-Hinweis HS-32, Verbrennungsgefahr HS-22), Statusanzeige (HS-27 „Fehler beim Schreiben der Filterwerte“), Meldungszeile „Meldung:“ (HS-31 „Motorschutz ausgelöst“). Mehrzeiliger Text, Längen variieren. Art als Parameter, Symbol und Wort folgen der Art.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Text (`Text`) | string | – | mehrzeilig |
| Art (`Kind`) | enum NoticeKind { Info, Warning, Error, MessageLine } | – | MessageLine = „Meldung:“ mit Text |
| Beschriftung (`Caption`) | string? | – | z. B. „Meldung:“ |
| Symbol (`Icon`) | Geometry? | – | Standard nach Art |
| Sichtbar (`IsVisible`) | bool | – | Hinweis ohne Text ausblendbar |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Warnhinweis | `Brush.Status.Warning.Subtle`, Kontur `Border.Medium` `Brush.Status.Warning.Fg`, Text `Brush.Text.Primary` | `Icon.Status.Warning` und Wort „Warnung“ |
| Fehler | `Brush.Status.Error.Subtle`, Kontur `Border.Thick` `Brush.Status.Error.Fg` | `Icon.Status.Error` und Wort „Fehler“ |
| Info | `Brush.Status.Info.Subtle` | `Icon.Status.Info` und Wort „Info“ |
| Meldungszeile gefüllt | `Brush.Surface`, Kontur `Border.Thin` | Caption „Meldung:“ und Text |
| Meldungszeile leer | neutral | Text „–“ |

## Verwendet auf Seiten (IDs)
- [HS-11](../Seiten/HS-11_Hauptdosierer-1-und-2.md) – Hauptdosierer 1 & 2 (inkl. Verwendung über Kompositmodul HM-20)
- [HS-19](../Seiten/HS-19_Nachdosierer.md) – Nachdosierer (inkl. Verwendung über Kompositmodul HM-20)
- [HS-22](../Seiten/HS-22_Heizungen.md) – Heizungen
- [HS-27](../Seiten/HS-27_Waagen-Kalibrieren.md) – Waagen Kalibrieren
- [HS-31](../Seiten/HS-31_Handbetrieb.md) – Handbetrieb
- [HS-32](../Seiten/HS-32_Geber-setzen.md) – Geber setzen
- [HS-41](../Seiten/HS-41_Dosierer-Uebersicht.md) – Dosierer-Übersicht (inkl. Verwendung über Kompositmodul HM-20)

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die HS-Dateien entstehen in Phase 3 (Punkt 4); die Links sind vorläufig.

## Herkunft
- [RM-23](../../02_Referenz-Analyse/Module/RM-23_Hinweis-Textfeld.md) – Hinweis-Textfeld: Warnhinweis, Statusmeldung, Meldungszeile
- Design: keine Entsprechung (Element nur in der Referenz).

## WPF-Umsetzung
- **Control:** `HM27_NoticeBox` (UserControl), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `UserControl` (`HM27_NoticeBox`), `TextBlock` mit `TextWrapping`.
- **Dependency Properties:** `Text`, `Kind`, `Caption`, `Icon`; Stil per `DataTrigger` auf `Kind`.
- **Symbole** (`Themes/Icons.xaml`, Schema `Icon.<Bereich>.<Name>`): Designsystem: `Icon.Status.Error`, `Icon.Status.Info`, `Icon.Status.Warning`.
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-27-P01 | Warnhinweis | Not-Aus-Hinweis (HS-32) und Verbrennungsgefahr (HS-22) mit Warnsymbol | offen |
| HM-27-P02 | Meldungszeile | „Meldung: Motorschutz ausgelöst“ | offen |
| HM-27-P03 | Leer | neutrale Darstellung | offen |
| HM-27-P04 | Zweiter Kanal | Art über Symbol und Wort | offen |
| HM-27-P05 | Kontrast | Text ≥ 4,5 : 1 auf Subtle-Fläche | offen |
