# HM-28 – Temperaturzonen-Zeile

## Funktion
Zeile je Heiz-/Temperaturzone. Variante **Heißleim** (HS-08): Zonenname, Soll (Eingabe, °C), Ist (Anzeige, °C), Taste „Ausschalten“/„Einschalten“. Variante **Heizungen** (HS-22, 12 Zonen): Name, Heizung Ein/Aus, Meldung (Überwachung, Haken), Soll, Ist, State, Out. Eigen ist nur die Zeilenkomposition aus [HM-12](HM-12_Eingabefeld-Schluesselsymbol.md) (Soll), [HM-11](HM-11_Anzeigefeld.md) (Ist), [HM-08](HM-08_Zustandstaste-Umschalter.md) (Heizung, Meldung, Statustaste) und [HM-09](HM-09_Status-LED.md) (State, Out).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Zonenname (`ZoneName`) | string | – | Tank, Schlauch 1/2, Pistole 1/2, Verteiler; 12 Zonen „6E1 …“ bis „20E4 …“ |
| Variante (`RowKind`) | enum ZoneRowKind { Glue, Heating } | – | – |
| Soll (`Setpoint`) | double | °C | Bild 150, 160, 170, 100; 150, 170 |
| Ist (`Actual`) | double? | °C | Bild 150, 160, 170, 0 |
| Zone ein (`IsEnabled`) | bool | – | – |
| Überwachung (`IsMonitored`) | bool | – | nur Heating |
| State (`StateLed`), Out (`OutputLed`) | LedState | – | nur Heating: Aus, Ok = Zieltemperatur erreicht, Error = nicht bereit/Fehler |
| Befehle (`ToggleZoneCommand`, `ToggleMonitorCommand`) | ICommand<bool> | – | – |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Aktiv | Zeile `Brush.Surface`, Ist folgt Soll | Taste „Ausschalten“, `Icon.State.On` und Wort „Ein“ |
| Abgewählt | Text `Brush.Text.Secondary`, Ist „0 °C“ | Taste „Einschalten“, `Icon.State.Off` und Wort „Aus“ |
| Zieltemperatur erreicht | State-LED Ok (HM-09) | `Icon.Status.Ok` und Wort „OK“ |
| Fehler / nicht bereit | Zeile `Brush.Status.Error.Subtle`, State-LED Fehler | `Icon.Status.Error` und Wort „Fehler“ |
| Überwachung aus | Meldung-Schalter Aus | `Icon.State.Off` und Wort „Aus“ |

## Verwendet auf Seiten (IDs)
- [HS-08](../Seiten/HS-08_Heissleim-Parameter.md) – Heißleim Parameter
- [HS-22](../Seiten/HS-22_Heizungen.md) – Heizungen

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die HS-Dateien entstehen in Phase 3 (Punkt 4); die Links sind vorläufig.

## Herkunft
- [RM-24](../../02_Referenz-Analyse/Module/RM-24_Temperaturzonen-Zeile.md) – Temperaturzonen-Zeile: Zeile je Heiz- oder Temperaturzone (Heißleim, Heizungen)
- Design: keine Entsprechung (Element nur in der Referenz).

## WPF-Umsetzung
- **Control:** `HM28_HeatZoneRow` (UserControl), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `UserControl` (`HM28_HeatZoneRow`), `Grid` mit festen Spalten, einsetzbar in `ItemsControl`.
- **Dependency Properties:** `ZoneName`, `RowKind`, `Setpoint`, `Actual`, `IsEnabled`, `IsMonitored`, `StateLed`, `OutputLed`; **Commands:** `ToggleZoneCommand`, `ToggleMonitorCommand`.
- Zeilenhöhe 64 px (Heizungen: 12 Zeilen scrollbar).
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-28-P01 | Heißleim | 6 Zonen mit Soll 150, 160, 170, 100, 100, 150 °C und Ist | offen |
| HM-28-P02 | Heizungen | 12 Zonen mit Heizung, Meldung, Soll, Ist, State, Out | offen |
| HM-28-P03 | Zustand ohne Farbe | Ein/Aus und State mit Symbol und Wort | offen |
| HM-28-P04 | Ist abgewählt | „0 °C“ sichtbar | offen |
| HM-28-P05 | Keine Kopien | Soll HM-12, Ist HM-11, Tasten HM-08, State HM-09 | offen |
