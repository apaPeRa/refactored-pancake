# HM-36 – EA-Zeile (Signalzeile)

## Funktion
Zeile der Signalliste einer EA-Karte (HS-34, 8 Zeilen je Karte): Status-LED ([HM-09](HM-09_Status-LED.md), kompakt), SPS-Kennung und Klartext, z. B. „0F24A_rdy – SICHERUNGS MODUL BEREIT (0F24A)“. Analoge Kanäle zeigen einen Zahlenwert statt der LED. Die Karte wird über [HM-19](HM-19_Blaettertasten.md) gewechselt, ihr Name steht in [HM-17](HM-17_Titelzeile.md).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Kennung (`Identifier`) | string | – | SPS-Name, z. B. S1_0KDE1_3 |
| Klartext (`Description`) | string | – | z. B. „RESERVE“, „KUEHLGERAET BEREIT“ |
| Art (`IoKind`) | enum IoKind { Digital, Analog } | – | – |
| Digitalzustand (`State`) | LedState | – | Off, On, Error |
| Analogwert (`AnalogValue`) | double? | je Kanal | Einheit nicht angegeben |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Inaktiv | LED Aus (HM-09) | `Icon.Status.Inactive` und Wort „Aus“ |
| Aktiv | LED Ok | `Icon.Status.Ok` und Wort „Ein“ |
| Analog | Zahl `Font.Size.Value` | Zahlenwert statt LED |
| Reserve | Text `Brush.Text.Secondary` | Klartext „RESERVE“ |
| Fehler | Zeile `Brush.Status.Error.Subtle` | `Icon.Status.Error` |

## Verwendet auf Seiten (IDs)
- [HS-34](../Seiten/HS-34_EA-Anzeige.md) – EA-Anzeige

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die HS-Dateien entstehen in Phase 3 (Punkt 4); die Links sind vorläufig.

## Herkunft
- [RM-35](../../02_Referenz-Analyse/Module/RM-35_EA-Zeile.md) – EA-Zeile: Zeile der Signalliste mit LED, SPS-Kennung und Klartext
- Design: keine Entsprechung (Element nur in der Referenz).

## WPF-Umsetzung
- **Control:** `HM36_IoRow` (UserControl), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `UserControl` (`HM36_IoRow`), `Grid` LED | Kennung | Klartext, Zeilenhöhe 48 px.
- **Dependency Properties:** `Identifier`, `Description`, `IoKind`, `State`, `AnalogValue`.
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-36-P01 | Zeilen | 8 Zeilen je Karte | offen |
| HM-36-P02 | Aufbau | LED, Kennung, Klartext | offen |
| HM-36-P03 | Beispiel | „0E3 – KUEHLGERAET BEREIT“ | offen |
| HM-36-P04 | Zustand | LED mit Symbol und Wort | offen |
| HM-36-P05 | Analog | Zahlenwert statt LED | offen |
