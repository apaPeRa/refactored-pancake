# HM-14 – Pop-up-Rahmen

## Funktion
Modaler Rahmen über der Seite für alle Pop-ups (Produktionszähler, Maschinengeschwindigkeit, [Eingabe-Pop-up](HM-13_Eingabe-Pop-up.md), [Zeitplan-Eintrag](HM-30_Zeitplan-Eintrag-Pop-up.md), [Such-Pop-up](HM-38_Such-Pop-up.md), Bestätigungen, Datei- und Ergebnis-Pop-up). Drei Arten (`Kind`): freier Inhalt, **Bestätigung** (Warntext, zwei Tasten, z. B. „Ja“/„Abbrechen“ oder „Verwerfen“/„Abbrechen“; Fokus zunächst auf „Abbrechen“; Beispiele: Steuerung neu starten, Liste leeren, Änderungen verwerfen?, Nullpunkt setzen, Start löschen) und **Datei-/Ergebnis-Pop-up** (HS-36, HS-37: Dateiauswahl für Export und Import, danach Fortschritt und Ergebnis mit Erfolg oder Fehler, Taste „Schließen“; Dateiformat und Ort offen, OP-49). Höchstens zwei Pop-ups gestapelt (A-40). Titelzeile (`Size.Popup.TitleHeight`) mit Schließen-Kreuz oben rechts (`Size.Touch.Default`), freier Inhalt, optionale Taste „Schließen“ unten rechts. Dahinter liegt der Scrim; der Hintergrund ist gesperrt (Annahme der Referenz). Maximale Breite 60 %, kein Schatten.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Titel (`Title`) | string | – | z. B. „Produktionszähler“, „Maschinengeschwindigkeit“, „Änderungen verwerfen?“ |
| Inhalt (`Content`) | object | – | frei |
| Breitenanteil (`WidthRatio`) | double | – | 0,3 bis 0,6, Standard 0,6 |
| Modal (`IsModal`) | bool | – | Standard true |
| Schließen-Taste zeigen (`ShowCloseButton`) | bool | – | Standard true |
| Schließen (`CloseCommand`) | ICommand | – | – |
| Ergebnis (`DialogResult`) | bool? | – | true = übernommen |
| Art (`Kind`) | enum PopupKind { Content, Confirmation, FileResult } | – | Content Standard |
| Meldungstext (`Message`) | string? | – | Bestätigung und Ergebnis: Warn- bzw. Ergebnistext |
| Tastentexte (`ConfirmText`, `CancelText`) | string | – | Standard „Ja“ und „Abbrechen“; Variante „Verwerfen“ |
| Fortschritt (`Progress`) | double? | % | nur FileResult: 0 bis 100, null = unbestimmt |
| Ergebnisart (`ResultKind`) | enum ResultKind { None, Success, Error } | – | nur FileResult |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Offen | `Brush.Surface`, Kontur `Border.Medium` `Brush.Border.Control`, `Radius.Card`, Scrim `Brush.Scrim`, Titel `Font.Size.Title` | Titelzeile mit Schließen-Kreuz, Rahmen |
| Schließen gedrückt | `Brush.Button.Pressed`, `Border.Medium` | dickere Kontur |
| Geschlossen | nicht sichtbar | Scrim verschwindet |
| Fokus | Fokus bleibt im Pop-up | Fokusrahmen `Border.Thick` `Brush.Border.Focus` |
| Bestätigungsvariante | Titel mit `Icon.Status.Warning`, Tasten „Ja“/„Abbrechen“ (Fokus auf „Abbrechen“), kein Schließen durch Antippen außerhalb | Symbol und Text (z. B. Steuerung neu starten) |
| Datei-/Ergebnis-Pop-up: Auswahl | Dateiauswahl (Format, Ort offen), Tasten „Übernehmen“/„Abbrechen“ | Titel und Text |
| Datei-/Ergebnis-Pop-up: Läuft | Fortschrittsbalken ([HM-10](HM-10_Fortschrittsbalken.md)) im Inhalt, Tasten deaktiviert (gestrichelt) | Prozentzahl als Text |
| Datei-/Ergebnis-Pop-up: Erfolg / Fehler | Erfolg `Icon.Status.Ok`, Fehler `Icon.Status.Error` mit `Brush.Status.Error.Subtle`, Taste „Schließen“ | Symbol und Text („Export abgeschlossen“, „Datei unlesbar“) |

## Verwendet auf Seiten (IDs)
- [HS-01](../Seiten/HS-01_Produktion.md) – Produktion
- [HS-02](../Seiten/HS-02_Produktionszaehler.md) – Produktionszähler (Pop-up)
- [HS-03](../Seiten/HS-03_Maschinengeschwindigkeit.md) – Maschinengeschwindigkeit (Pop-up)
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
- [HS-16](../Seiten/HS-16_Schliessmaschine.md) – Schließmaschine
- [HS-17](../Seiten/HS-17_Motorparameter-Schliessmaschine.md) – Motorparameter (Schließmaschine)
- [HS-18](../Seiten/HS-18_Gewichtskorrektur-Schliessmaschine.md) – Gewichtskorrektur (Schließmaschine)
- [HS-19](../Seiten/HS-19_Nachdosierer.md) – Nachdosierer
- [HS-20](../Seiten/HS-20_Motorparameter.md) – Motorparameter (Nachdosierer)
- [HS-21](../Seiten/HS-21_Gewichtskorrektur.md) – Gewichtskorrektur (Nachdosierer)
- [HS-22](../Seiten/HS-22_Heizungen.md) – Heizungen
- [HS-23](../Seiten/HS-23_Regulierung.md) – Regulierung
- [HS-25](../Seiten/HS-25_Nocken.md) – Nocken
- [HS-30](../Seiten/HS-30_Handbetrieb-Auswahl.md) – Handbetrieb Auswahl
- [HS-31](../Seiten/HS-31_Handbetrieb.md) – Handbetrieb
- [HS-33](../Seiten/HS-33_EA-Uebersicht.md) – EA-Übersicht
- [HS-35](../Seiten/HS-35_Systemeinstellungen.md) – Systemeinstellungen
- [HS-36](../Seiten/HS-36_Service.md) – Service
- [HS-37](../Seiten/HS-37_Meldearchiv.md) – Meldearchiv
- [HS-39](../Seiten/HS-39_System-und-Antriebsinfos.md) – System- und Antriebsinfos

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die Liste ist aus den Abschnitten „Verwendete Module“ und den Elemente-Tabellen der HS-Seiten abgeleitet (Stand Konsolidierung nach Phase 3, Punkt 4); „inkl. Verwendung über Kompositmodul“ nennt Seiten, auf denen das Modul nur innerhalb eines Kompositmoduls vorkommt.

## Herkunft
- [RM-13](../../02_Referenz-Analyse/Module/RM-13_Pop-up-Rahmen.md) – Pop-up-Rahmen: Fenster mit Titelleiste, Schließen-Kreuz und Taste „Schließen“ (Produktionszähler, Maschinengeschwindigkeit)
- Design: keine Entsprechung (Element nur in der Referenz).

## WPF-Umsetzung
- **Control:** `HM14_PopupFrame` (UserControl / `ControlTemplate`), Ordner `src/.../Controls/`, Code-behind nur Dependency-Property-Deklarationen ohne Logik (Custom Control, A-73).
- **Typ:** `UserControl` mit `ContentPresenter`; gehostet in einer Overlay-Schicht des Hauptfensters (`HM14_PopupHost`), geöffnet über `IDialogService`.
- **Dependency Properties:** `Title`, `Content`, `WidthRatio`, `IsModal`, `ShowCloseButton`, `Kind`, `Message`, `ConfirmText`, `CancelText`, `Progress`, `ResultKind`; **Commands:** `CloseCommand`, `ConfirmCommand`, `CancelCommand`; `Esc`/Schließen-Kreuz schließt.
- **Symbole** (`Themes/Icons.xaml`, Schema `Icon.<Bereich>.<Name>`): Designsystem: `Icon.Status.Warning`, `Icon.Status.Ok`, `Icon.Status.Error`.
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-14-P01 | Aufbau | Titelzeile, Schließen-Kreuz oben rechts, Inhalt, Taste „Schließen“ unten rechts | offen |
| HM-14-P02 | Modal | Scrim dahinter, Seite nicht bedienbar | offen |
| HM-14-P03 | Breite | höchstens 60 % der Fensterbreite | offen |
| HM-14-P04 | Touch | Schließen-Kreuz und -Taste ≥ `Size.Touch.Default` | offen |
| HM-14-P05 | Kein Schatten | Tiefe nur über Scrim und Kontur | offen |
| HM-14-P06 | Dokumentierte Pop-ups | HS-02 und HS-03 nutzen den Rahmen | offen |
| HM-14-P07 | Bestätigung | Warnsymbol im Titel, „Ja“/„Abbrechen“ (oder „Verwerfen“/„Abbrechen“), Fokus auf „Abbrechen“, Antippen außerhalb schließt nicht (HS-13, HS-14, HS-25, HS-35, HS-37) | offen |
| HM-14-P08 | Datei/Ergebnis | Auswahl, Fortschritt und Ergebnis mit Symbol und Text, Fehler nicht nur in Rot (HS-36, HS-37) | offen |
| HM-14-P09 | Stapeltiefe | höchstens zwei Pop-ups gleichzeitig (z. B. Eingabe-Pop-up über HS-03) | offen |
