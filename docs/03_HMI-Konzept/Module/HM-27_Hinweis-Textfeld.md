# HM-27 – Hinweis-Textfeld

## Funktion
Nicht editierbares Textfeld für Hinweise, Warnungen und Statusmeldungen mit Symbol: Warnhinweis (Not-Aus-Hinweis HS-32, Verbrennungsgefahr HS-22), Statusanzeige (HS-27 „Fehler beim Schreiben der Filterwerte“), Meldungszeile „Meldung:“ (HS-31 „Motorschutz ausgelöst“). Mehrzeiliger Text, Längen variieren. Art als Parameter, Symbol und Wort folgen der Art.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Text (`Text`) | string | – | mehrzeilig |
| Art (`Kind`) | enum NoticeKind { Info, Warning, Error, MessageLine } | – | MessageLine = „Meldung:“ mit Text |
| Schweregrad (`Severity`) | enum NoticeSeverity { None, Info, Warning, Error } | – | nur mit Kind = MessageLine: Kombination „Meldung:“ + Text + Symbol + Wort (z. B. Aktormeldung in HS-31 mit `Icon.Status.Error` und Wort „Fehler“); None = nur Text oder „–“ |
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
| Meldungszeile mit Schweregrad (Kind = MessageLine, Severity ≠ None) | Fläche und Kontur des Schweregrads wie Warnhinweis, Fehler oder Info | Caption „Meldung:“, Text, Statussymbol und Statuswort („Fehler“, „Warnung“, „Info“) |
| Meldungszeile gefüllt | `Brush.Surface`, Kontur `Border.Thin` | Caption „Meldung:“ und Text |
| Meldungszeile leer | neutral | Text „–“ |

## Verwendet auf Seiten (IDs)
- [HS-05](../Seiten/HS-05_Zufuehrung-Papier.md) – Zuführung Papier
- [HS-07](../Seiten/HS-07_Heissleim-Nordson.md) – Heißleim Nordson
- [HS-10](../Seiten/HS-10_Zeitschaltuhr.md) – Zeitschaltuhr
- [HS-11](../Seiten/HS-11_Hauptdosierer-1-und-2.md) – Hauptdosierer 1 & 2
- [HS-16](../Seiten/HS-16_Schliessmaschine.md) – Schließmaschine
- [HS-18](../Seiten/HS-18_Gewichtskorrektur-Schliessmaschine.md) – Gewichtskorrektur (Schließmaschine)
- [HS-19](../Seiten/HS-19_Nachdosierer.md) – Nachdosierer
- [HS-21](../Seiten/HS-21_Gewichtskorrektur.md) – Gewichtskorrektur (Nachdosierer)
- [HS-22](../Seiten/HS-22_Heizungen.md) – Heizungen
- [HS-24](../Seiten/HS-24_Bildschirm-reinigen.md) – Bildschirm reinigen
- [HS-27](../Seiten/HS-27_Waagen-Kalibrieren.md) – Waagen Kalibrieren
- [HS-28](../Seiten/HS-28_Packungsregister.md) – Packungsregister
- [HS-31](../Seiten/HS-31_Handbetrieb.md) – Handbetrieb
- [HS-32](../Seiten/HS-32_Geber-setzen.md) – Geber setzen
- [HS-41](../Seiten/HS-41_Dosierer-Uebersicht.md) – Dosierer-Übersicht
- [HS-43](../Seiten/HS-43_Schichtplan.md) – Schichtplan

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die Liste ist aus den Abschnitten „Verwendete Module“ und den Elemente-Tabellen der HS-Seiten abgeleitet (Stand Konsolidierung nach Phase 3, Punkt 4); „inkl. Verwendung über Kompositmodul“ nennt Seiten, auf denen das Modul nur innerhalb eines Kompositmoduls vorkommt.

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
