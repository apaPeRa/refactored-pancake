# HM-30 – Zeitplan-Eintrag-Pop-up

## Funktion
Dialog zum Anlegen, Bearbeiten und Löschen eines Eintrags der Zeitschaltuhr, im [Pop-up-Rahmen](HM-14_Popup-Rahmen.md). Felder: Aktion (Heizphase, Absenkphase; [HM-18](HM-18_Auswahlfeld-Pfeiltasten.md)), Kontrollkästchen für Startzeit und Endzeit ([HM-08](HM-08_Zustandstaste-Umschalter.md); mindestens eine Zeit muss aktiv sein), Startzeit und Endzeit (hh:mm, Eingabe über [HM-13](HM-13_Eingabe-Pop-up.md) in der Zeitvariante), Zähler untergeordneter Absenkphasen. Tasten Übernehmen, Abbrechen, Löschen. Eine Heizphase ist erst löschbar, wenn alle ihre Absenkphasen gelöscht sind. Titel „Neuer Eintrag“ bzw. „Absenkphase“.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Aktion (`Kind`) | ScheduleKind | – | Heat, Setback |
| Startzeit aktiv / Endzeit aktiv (`StartActive`, `EndActive`) | bool | – | mindestens eine true |
| Startzeit (`StartTime`), Endzeit (`EndTime`) | TimeOnly? | hh:mm | 00:00 bis 23:59; leer „__:__“ |
| Absenkphasen (`ChildCount`) | int | Stk | 0 bis 9 (Bild 0, 1) |
| Neu (`IsNew`) | bool | – | – |
| Befehle | ICommand | – | `ApplyCommand`, `CancelCommand`, `DeleteCommand` |
| Fehlertext (`ErrorText`) | string? | – | z. B. „Endzeit vor Startzeit“ |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Neuanlage | Zeitfelder leer, Kontrollkästchen Aus, Löschen deaktiviert (gestrichelt) | „__:__“ und `Icon.State.Off` |
| Bearbeiten Heizphase | Löschen deaktiviert, wenn ChildCount > 0 | Hinweis „Zuerst Absenkphasen löschen“ mit `Icon.Status.Info` |
| Bearbeiten Absenkphase | Löschen aktiv | Taste „Löschen“ mit `Icon.Delete` |
| Fehler | Zeitfeld Kontur `Border.Thick` `Brush.Status.Error.Fill`, Übernehmen deaktiviert | `Icon.Status.Error` und Fehlertext |
| Gültig | Übernehmen aktiv | `Icon.Confirm` |

## Verwendet auf Seiten (IDs)
- [HS-10](../Seiten/HS-10_Zeitschaltuhr.md) – Zeitschaltuhr

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die HS-Dateien entstehen in Phase 3 (Punkt 4); die Links sind vorläufig.

## Herkunft
- [RM-27](../../02_Referenz-Analyse/Module/RM-27_Zeitplan-Eintrag-Pop-up.md) – Zeitplan-Eintrag-Pop-up: Pop-up zum Anlegen, Bearbeiten und Löschen einer Phase
- Design: keine Entsprechung (Element nur in der Referenz).

## WPF-Umsetzung
- **Control:** `HM30_ScheduleEntryDialog` (UserControl (Inhalt von HM14_PopupFrame)), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `UserControl` als Inhalt von `HM14_PopupFrame`, geöffnet über `IDialogService`.
- **Dependency Properties:** `Kind`, `StartActive`, `EndActive`, `StartTime`, `EndTime`, `ChildCount`, `IsNew`, `ErrorText`; **Commands:** `ApplyCommand`, `CancelCommand`, `DeleteCommand`.
- **Neue Symbole** (`Themes/Icons.xaml`): `Icon.Delete`, `Icon.Confirm`, `Icon.Close` (neu bzw. Designsystem).
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-30-P01 | Titel | „Neuer Eintrag“ bzw. „Absenkphase“ | offen |
| HM-30-P02 | Felder | Aktion, 2 Kontrollkästchen, Startzeit, Endzeit, Zähler | offen |
| HM-30-P03 | Tasten | Übernehmen (Haken), Abbrechen (X), Löschen (Papierkorb) | offen |
| HM-30-P04 | Löschregel | Heizphase erst löschbar ohne Absenkphasen | offen |
| HM-30-P05 | Fehler | Endzeit vor Startzeit mit Text und Symbol | offen |
