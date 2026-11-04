# HM-02 – Kopfzeile (Logo, Betriebsart, Uhr)

## Funktion
Rahmenzeile oben im Arbeitsbereich (Zeile `Size.Header.Height`). Spalten 12* : 13* : 6* : 4*: Logo, Meldezeile ([HM-03](HM-03_Meldezeile.md)), Betriebsart, Uhrzeit/Datum. Das Logo ist eine feste Grafik (APA-TEC GmbH, „Automation and Packaging Technology“) in je einer Variante für Hell- und Dunkelthema. Die Betriebsart zeigt Symbol und Wort. Das unbeschriebene Wirbel-Symbol und der rote Schriftzug „Service“ der Referenz (RS-24, RS-36) werden als Betriebsart „Service“ mit Warnstatus geführt (A-48). Uhrzeit und Datum sind reine Anzeige.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Logo (`LogoLight`, `LogoDark`) | ImageSource / DrawingImage | – | je Thema eine Variante, fest |
| Betriebsart (`OperatingMode`) | enum OperatingMode { Production, Setup, Manual, Service, Fault } | – | Bild nur Production; weitere offen (OP-22), Aufzählung erweiterbar |
| Betriebsart-Text (`OperatingModeText`) | string | – | Ressourcentext, z. B. „Produktion“ |
| Zeit (`Now`) | DateTime | HH:mm:ss | 00:00:00 bis 23:59:59; Design „9:15“ ohne Sekunden, Referenz „13:01:12“ (A-47) |
| Sekunden zeigen (`ShowSeconds`) | bool | – | Standard true |
| Zeit gültig (`IsTimeValid`) | bool | – | false zeigt „--:--:--“ |
| Betriebsart antippbar (`ModeCommand`) | ICommand | – | im Entwurf keine Interaktion erkennbar; Standard ohne Befehl |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Produktion (Normalzustand) | neutral: `Brush.Surface`, Symbol `Icon.Mode.Production` und Wort „Produktion“ in `Brush.Text.Primary`, `Font.Size.Title` | Symbol (Kreispfeile) und Wort „Produktion“ |
| Andere Betriebsart | `Brush.Surface`, Text `Brush.Text.Primary`, Symbol der Betriebsart | eigenes Symbol und Wort |
| Service / Warnung | `Brush.Status.Warning.Fill` Fläche, `Brush.Status.Warning.On` | `Icon.Status.Warning` und Wort „Service“ |
| Störung | `Brush.Status.Error.Fill` Fläche, `Brush.Status.Error.On` | `Icon.Status.Error` und Wort „Fehler“ |
| Uhrzeit normal | `Brush.Surface.Sunken`, Uhrzeit `Font.Size.Metric`, Datum `Font.Size.Caption`, `Brush.Text.Primary` / `Secondary` | Ziffern, Format nach `CurrentCulture` |
| Zeit ungültig | wie normal | Text „--:--:--“ und „--.--.----“ |

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
- [HS-24](../Seiten/HS-24_Bildschirm-reinigen.md) – Bildschirm reinigen
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
- [DM-03](../../01_Design-Analyse/Module/DM-03_Kopfzeile-Logo.md) – Kopfzeile Logo: Logo
- [DM-05](../../01_Design-Analyse/Module/DM-05_Betriebsart-Anzeige.md) – Betriebsart-Anzeige: Betriebsart-Anzeige
- [DM-06](../../01_Design-Analyse/Module/DM-06_Uhrzeit-und-Datum.md) – Uhrzeit und Datum: Uhrzeit und Datum
- [RM-01](../../02_Referenz-Analyse/Module/RM-01_Kopfzeile.md) – Kopfzeile: Logo, Uhrzeit, Datum, Wirbel-Symbol und „Service“-Schriftzug; der Seitentitel geht in das letzte Brotkrümel-Segment [HM-04](HM-04_Brotkruemel-Navigation.md) über

## WPF-Umsetzung
- **Control:** `HM02_HeaderBar` (UserControl), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `UserControl` mit 4-spaltigem `Grid` (`12* 13* 6* 4*`); enthält [HM-03](HM-03_Meldezeile.md) in Spalte 2.
- **Dependency Properties:** `LogoSource`, `OperatingMode`, `OperatingModeText`, `Now`, `ShowSeconds`, `IsTimeValid`. Uhr über `IClockService` (Dummy), Taktgeber im ViewModel.
- **Mindestbreiten:** Betriebsart `Size.Header.Mode.MinWidth`, Uhr `Size.Header.Clock.MinWidth`.
- **Stil:** `HM02_OperatingModeStyle` per `DataTrigger` auf `OperatingMode`.
- **Neue Symbole** (`Themes/Icons.xaml`): `Icon.Mode.Production` (Designsystem), `Icon.Mode.Setup`, `Icon.Mode.Manual`, `Icon.Mode.Service` (neu).
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-02-P01 | Logo | APA-TEC-Logo links; im Dunkelthema Variante mit passendem Kontrast | offen |
| HM-02-P02 | Betriebsart | „Produktion“ mit Kreispfeil-Symbol, Status Ok (Text und Symbol, nicht nur grün) | offen |
| HM-02-P03 | Uhr | Uhrzeit und Datum rechts, Datum mindestens `Font.Size.Caption` | offen |
| HM-02-P04 | Service-Variante | Betriebsart „Service“ mit Warnsymbol und Wort | offen |
| HM-02-P05 | Proportionen | Spalten 12* : 13* : 6* : 4*, Höhe `Size.Header.Height` | offen |
| HM-02-P06 | Seitenübergreifend | identisch auf allen Vollseiten | offen |
