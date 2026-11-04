# HM-07 – Aktionstaste (Funktionstaste)

## Funktion
Taste mit Beschriftung (und optionalem Symbol), die genau eine Aktion auslöst oder zu einer Seite führt; sie hat **keinen** Ein/Aus-Zustand (Zustandstasten: [HM-08](HM-08_Zustandstaste-Umschalter.md)). Auslöseverhalten als Parameter: Antippen, Halten (Haltetaste, z. B. Reset, Jog) oder Dauerfunktion bis Abbruch (z. B. Entleeren) oder **Gedrückt-Halten (`WhilePressed`, Totmann)**: Die Aktion läuft nur, solange die Taste gedrückt ist (Jog+/Jog− in HS-31 und „Manuell“ in HS-07, Annahme, OP-57). `Hold` wartet eine Haltedauer ab und löst dann einmal aus; `WhilePressed` löst sofort aus und beendet die Aktion beim Loslassen. Mit oder ohne Schlüssel-/Schloss-Symbol für berechtigungspflichtige Aktionen. Einheitlich für Funktionsleiste, Dosiererkarten und Seiten.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Beschriftung (`Label`) | string | – | Ressourcentext, bis 2 Zeilen, z. B. Reset, Schließen, Manuell, Entleeren, Eichdosierung, Jog+, Jog−, Geber setzen, Suchen |
| Symbol (`Icon`) | Geometry? | – | optional, links |
| Befehl (`Command`) | ICommand | – | Aktion oder Navigation |
| Befehlsparameter (`CommandParameter`) | object? | – | z. B. Seiten-ID |
| Auslösung (`TriggerMode`) | enum ActionTriggerMode { Tap, Hold, Continuous, WhilePressed } | – | Standard Tap; WhilePressed = Totmann (Aktion nur während des Drückens) |
| Haltedauer (`HoldDuration`) | TimeSpan | ms | 200 bis 5000, Standard 1000 (Dummy, OP-42) |
| Läuft (`IsRunning`) | bool | – | bei Continuous und WhilePressed |
| Abbruch beim Verlassen (`CancelOnLeave`) | bool | – | Standard true bei WhilePressed: Finger gleitet aus der Taste, Seitenwechsel, Rollenverlust oder Störung beenden die Aktion |
| Berechtigung erforderlich (`RequiresPermission`) | bool | – | Schlüssel-Symbol |
| Berechtigt (`IsAuthorized`) | bool | – | false zeigt Schloss |
| Bedienbar (`IsEnabled`) | bool | – | false im ungeeigneten Betriebszustand |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Normal | `Brush.Button.Normal`, Kontur `Border.Thin` `Brush.Border.Control`, Text `Brush.Text.Primary`, Höhe `Size.Touch.Default`, `Radius.Control` | Beschriftung |
| Gedrückt | `Brush.Button.Pressed`, Kontur `Border.Medium` | dickere Kontur; Auslösen beim Loslassen im Ziel |
| Halten | wie gedrückt, Fortschrittsstreifen unten in `Brush.Progress.Fill` | Streifen und Text „Halten …“ |
| Läuft (Dauerfunktion) | `Brush.Button.Active`, Text `Brush.Text.OnActive` | `Icon.State.On` und Wort „Läuft“ |
| Gehalten (WhilePressed) | `Brush.Button.Active`, Text `Brush.Text.OnActive`, solange gedrückt | `Icon.State.On` und Wort „Läuft“; endet beim Loslassen sofort |
| Deaktiviert | Kontur gestrichelt (`Border.Dash`), Text `Brush.Text.Disabled` | gestrichelte Kontur; Tippen nennt Grund in der Meldezeile (A-28) |
| Berechtigung vorhanden | Normal | `Icon.Key` (`Size.Icon.S`) oben rechts |
| Berechtigung fehlt | Normal, nicht bedienbar | `Icon.Lock` und Hinweis „Berechtigung erforderlich: <Rolle>“; Tippen öffnet zusätzlich das Benutzer-Pop-up (Navigation.md 4.1), nach der Anmeldung läuft die Aktion weiter |

## Verwendet auf Seiten (IDs)
- [HS-01](../Seiten/HS-01_Produktion.md) – Produktion
- [HS-02](../Seiten/HS-02_Produktionszaehler.md) – Produktionszähler (Pop-up)
- [HS-04](../Seiten/HS-04_Einstellungen.md) – Einstellungen
- [HS-07](../Seiten/HS-07_Heissleim-Nordson.md) – Heißleim Nordson
- [HS-10](../Seiten/HS-10_Zeitschaltuhr.md) – Zeitschaltuhr (inkl. Verwendung über Kompositmodul HM-18)
- [HS-11](../Seiten/HS-11_Hauptdosierer-1-und-2.md) – Hauptdosierer 1 & 2
- [HS-12](../Seiten/HS-12_Motorparameter.md) – Motorparameter (Hauptdosierer) (inkl. Verwendung über Kompositmodul HM-19)
- [HS-13](../Seiten/HS-13_Kontrollwaage.md) – Kontrollwaage
- [HS-14](../Seiten/HS-14_Einzelgewichte.md) – Einzelgewichte
- [HS-15](../Seiten/HS-15_Trend.md) – Trend (inkl. Verwendung über Kompositmodul HM-18)
- [HS-18](../Seiten/HS-18_Gewichtskorrektur-Schliessmaschine.md) – Gewichtskorrektur (Schließmaschine)
- [HS-19](../Seiten/HS-19_Nachdosierer.md) – Nachdosierer
- [HS-20](../Seiten/HS-20_Motorparameter.md) – Motorparameter (Nachdosierer) (inkl. Verwendung über Kompositmodul HM-19)
- [HS-21](../Seiten/HS-21_Gewichtskorrektur.md) – Gewichtskorrektur (Nachdosierer)
- [HS-23](../Seiten/HS-23_Regulierung.md) – Regulierung
- [HS-25](../Seiten/HS-25_Nocken.md) – Nocken
- [HS-26](../Seiten/HS-26_Nockenuebersicht.md) – Nockenübersicht (inkl. Verwendung über Kompositmodul HM-19)
- [HS-27](../Seiten/HS-27_Waagen-Kalibrieren.md) – Waagen Kalibrieren
- [HS-29](../Seiten/HS-29_Produktionsstatistik.md) – Produktionsstatistik (inkl. Verwendung über Kompositmodul HM-18)
- [HS-30](../Seiten/HS-30_Handbetrieb-Auswahl.md) – Handbetrieb Auswahl
- [HS-31](../Seiten/HS-31_Handbetrieb.md) – Handbetrieb
- [HS-32](../Seiten/HS-32_Geber-setzen.md) – Geber setzen
- [HS-33](../Seiten/HS-33_EA-Uebersicht.md) – EA-Übersicht
- [HS-34](../Seiten/HS-34_EA-Anzeige.md) – EA-Anzeige (inkl. Verwendung über Kompositmodul HM-19)
- [HS-35](../Seiten/HS-35_Systemeinstellungen.md) – Systemeinstellungen
- [HS-36](../Seiten/HS-36_Service.md) – Service
- [HS-37](../Seiten/HS-37_Meldearchiv.md) – Meldearchiv
- [HS-38](../Seiten/HS-38_Meldeanzeige.md) – Meldeanzeige (inkl. Verwendung über Kompositmodul HM-25)
- [HS-39](../Seiten/HS-39_System-und-Antriebsinfos.md) – System- und Antriebsinfos (inkl. Verwendung über Kompositmodul HM-25)
- [HS-41](../Seiten/HS-41_Dosierer-Uebersicht.md) – Dosierer-Übersicht

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die HS-Dateien entstehen in Phase 3 (Punkt 4); die Links sind vorläufig.

## Herkunft
- [DM-10](../../01_Design-Analyse/Module/DM-10_Funktionstaste-grau.md) – Funktionstaste (grau): graue Funktionstaste ohne Zustand, auch Manuell/Entleeren in Karten
- [RM-11](../../02_Referenz-Analyse/Module/RM-11_Aktionstaste.md) – Aktionstaste: Funktions-, Service-, Jog-, Kalibrier- und Seitenlink-Tasten

## WPF-Umsetzung
- **Control:** `HM07_ActionButton` (ControlTemplate auf `Button`), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `ControlTemplate` für `Button` (Stil `HM07_ActionButtonStyle`) plus `HM07_ActionButton` als `Control` mit den Eigenschaften der Tabelle (Halte-Logik als Attached Behavior, kein Code-behind).
- **Dependency Properties:** `Label`, `Icon`, `TriggerMode`, `HoldDuration`, `IsRunning`, `RequiresPermission`, `IsAuthorized`; **Command:** `Command`/`CommandParameter`.
- **Maße:** Höhe `Size.Touch.Default`, Mindestbreite `Size.Button.MinWidth` (in der Leiste `Size.FunctionButton.MinWidth`), Innenabstand `Space.M`.
- **Symbole** (`Themes/Icons.xaml`, Schema `Icon.<Bereich>.<Name>`): Designsystem: `Icon.Key`, `Icon.Lock`, `Icon.State.On`.
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-07-P01 | Beispiele | Schichtplan, Sprache, Temperatur, Druck, Zeitplan, Manuell, Entleeren, Reset als Aktionstaste | offen |
| HM-07-P02 | Kein Ein/Aus | keine Zustandsanzeige außer Läuft, Deaktiviert und Berechtigung | offen |
| HM-07-P03 | Halten | Reset löst erst nach Haltedauer aus, Fortschritt sichtbar | offen |
| HM-07-P04 | Gesperrt | Sperre über gestrichelte Kontur und Schloss, nicht nur hellere Schrift | offen |
| HM-07-P05 | Touch | Höhe `Size.Touch.Default`, Abstand ≥ `Size.Touch.Gap` | offen |
| HM-07-P06 | Abgrenzung | Tasten mit Zustand sind HM-08 | offen |
| HM-07-P07 | Totmann | Modus `WhilePressed`: Aktion läuft nur während des Drückens und endet beim Loslassen, beim Gleiten aus der Taste und beim Seitenwechsel; Zustand „Läuft“ mit Symbol und Wort (HS-31 Jog, HS-07 „Manuell“) | offen |
