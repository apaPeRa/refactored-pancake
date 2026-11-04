# HM-21 – Motorparameter-Karte

## Funktion
Karte mit Überschrift und festen Zeilen aus Beschriftung und Eingabefeld ([HM-12](HM-12_Eingabefeld-Schluesselsymbol.md)) für die Bewegungsparameter eines Schneckendosierers. Zwei Kartenarten als Parameter: **Verschluss** (Zu/Auf; 5 Zeilen: Position, Geschwindigkeit, Beschleunigung, Verzögerung, Ruck) und **Schnecke** (3 Zeilen: Beschleunigung, Verzögerung, Ruck, mit Schnecken-Symbol). Eine Seite enthält drei Karten (13 Felder). Jede Zeile kann den Hilfetext des Handbuchs als Tooltip tragen. Der Dosierer, für den die Seite geöffnet wurde, steht in Titel/Brotkrümel („Motorparameter HD1“). Die Karte nutzt [HM-15](HM-15_Gruppenbereich.md) als Rahmen (keine Kopie).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Kartenüberschrift (`Title`) | string | – | „Verschluss Zu“, „Verschluss Auf“, „Schnecke“ |
| Kartenart (`CardKind`) | enum MotorCardKind { ClosureClosed, ClosureOpen, Screw } | – | – |
| Position (`Position`) | double | ° | nur Verschluss; Bild Zu 0, Auf 37 |
| Geschwindigkeit (`Speed`) | double | % | nur Verschluss; Bild 80 |
| Beschleunigung (`Acceleration`) | double | % | Bild 0 |
| Verzögerung (`Deceleration`) | double | % | Bild 0 |
| Ruck (`Jerk`) | double | % | Bild 0 |
| Dosierer (`DoserName`) | string | – | z. B. „HD1“, „ND“, „Schließmaschine“ |
| Eingabe (`CommitCommand`) | ICommand<MotorParameterChange> | – | je Zeile Name und Wert |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Normal | Rahmen `Brush.Surface.Sunken`, Zeilen als HM-12 (`Brush.Surface`) | Überschrift und Beschriftungen |
| Feld in Eingabe | HM-12 Zustand In Bearbeitung | Rahmen `Border.Thick` |
| Fehler | HM-12 Zustand Fehler | `Icon.Status.Error` und Text |
| Gesperrt | HM-12 Zustand Nicht berechtigt | `Icon.Lock` |
| Kartenart Schnecke | 3 Zeilen und Schnecken-Symbol | `Icon.Motor.Screw` neben der Überschrift |

## Verwendet auf Seiten (IDs)
- [HS-12](../Seiten/HS-12_Motorparameter.md) – Motorparameter (Hauptdosierer)
- [HS-17](../Seiten/HS-17_Motorparameter-Schliessmaschine.md) – Motorparameter (Schließmaschine)
- [HS-20](../Seiten/HS-20_Motorparameter.md) – Motorparameter (Nachdosierer)

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die HS-Dateien entstehen in Phase 3 (Punkt 4); die Links sind vorläufig.

## Herkunft
- [RM-16](../../02_Referenz-Analyse/Module/RM-16_Motorparameter-Karte.md) – Motorparameter-Karte: drei Karten Verschluss Zu, Verschluss Auf, Schnecke
- Design: keine Entsprechung (Element nur in der Referenz).

## WPF-Umsetzung
- **Control:** `HM21_MotorParameterCard` (UserControl), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `UserControl` (`HM21_MotorParameterCard`), Zeilen als `ItemsControl` aus `HM12_ValueInput` in `HM15_GroupPanel`.
- **Dependency Properties:** `Title`, `CardKind`, `Position`, `Speed`, `Acceleration`, `Deceleration`, `Jerk`, `DoserName`; **Command:** `CommitCommand`.
- Zeilenhöhe `Size.Touch.Default`; drei Karten im 12-Spalten-Raster 4 : 4 : 4.
- **Symbole** (`Themes/Icons.xaml`, Schema `Icon.<Bereich>.<Name>`): Designsystem: `Icon.Lock`, `Icon.Status.Error`; **neu, hier definiert:** `Icon.Motor.Screw`.
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-21-P01 | Karten | 3 Karten: Verschluss Zu, Verschluss Auf, Schnecke | offen |
| HM-21-P02 | Felder | 10 Felder in den Verschlusskarten (5 + 5), 3 in der Schneckenkarte, insgesamt 13 | offen |
| HM-21-P03 | Bildwerte | Position Zu 0 °, Auf 37 °; Geschwindigkeit 80 %; Beschleunigung, Verzögerung, Ruck 0 % | offen |
| HM-21-P04 | Einheiten | Einheit je Zeile hinter dem Wert | offen |
| HM-21-P05 | Keine Kopien | Felder sind HM-12, Rahmen HM-15 | offen |
| HM-21-P06 | Seiten | identischer Aufbau auf HS-12, HS-17, HS-20 | offen |
