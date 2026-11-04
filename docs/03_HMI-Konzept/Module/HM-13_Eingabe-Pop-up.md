# HM-13 – Eingabe-Pop-up (Ziffernblock)

## Funktion
**Annahme (A-51):** Gemeinsamer Dialog zur Eingabe eines Werts beim Antippen eines Eingabefelds ([HM-12](HM-12_Eingabefeld-Schluesselsymbol.md)). Im Handbuch und in den Bildern nicht dokumentiert. Inhalt im [Pop-up-Rahmen](HM-14_Popup-Rahmen.md): Titel (Feldname), aktueller Wert, Eingabezeile, Ziffernblock (0 bis 9, Komma, Vorzeichen, Rücktaste, Löschen), Hinweis auf Grenzen (Min/Max mit Einheit), Tasten „Übernehmen“ und „Abbrechen“. Übernehmen ist nur bei gültigem Wert aktiv. Varianten: Zeit (hh:mm) für die Zeitschaltuhr, Text (Bezeichnung, Annahme: Windows-Bildschirmtastatur) und **Filter** (Meldenummer und Zeit, HS-37, siehe unten). Optional trägt der Dialog einen **Hilfetext** (Caption unter der Eingabezeile, z. B. „Bereich 0 bis 100 %; 0 entspricht 100 % bzw. Hardwarevorgabe“ in HS-31) zusätzlich zur Bereichsangabe. Die **Suche mit Trefferliste** (HS-30, HS-31, HS-33) ist kein Teil dieses Moduls, sondern [HM-38](HM-38_Such-Pop-up.md); sie nutzt von hier nur die Texteingabe. Das Eingabe-Pop-up darf über einem Pop-up liegen (z. B. über HS-03, Stapeltiefe 2, A-40). Ein Dialog für alle Felder, keine Kopien je Seite. Modale Regeln (ein Pop-up zur Zeit, Stapeltiefe höchstens 2, kein Schließen durch Antippen außerhalb) gelten nach A-40.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Titel (`Title`) | string | – | Name des Felds |
| Aktueller Wert (`CurrentValue`) | double? | Einheit des Felds | vorbelegt |
| Eingegebener Wert (`InputText`) | string | – | Ziffern, Komma, Vorzeichen; maximal 12 Zeichen |
| Einheit (`Unit`) | string | – | wie Feld |
| Minimum (`Minimum`), Maximum (`Maximum`) | double? | Einheit des Felds | fachlich offen (OP-28); null = ungeprüft |
| Nachkommastellen (`Decimals`) | int | – | 0 bis 3 |
| Eingabeart (`InputKind`) | enum InputKind { Number, Time, Text, Filter } | – | Number, Time, Text siehe HM-12; Filter nur in diesem Dialog |
| Hilfetext (`HelpText`) | string? | – | Caption unter der Eingabezeile, mehrzeilig, aus `.resx`; null = nur Bereichsangabe |
| Filterfelder (`FilterFields`) | IReadOnlyList<FilterField> | – | nur bei Filter: je Name, Eingabeart (Zahl oder Zeit TT.MM.JJJJ hh:mm:ss), Wert; leeres Feld = kein Kriterium (HS-37: Meldenummer, Zeit) |
| Gültig (`IsValid`) | bool | – | berechnet |
| Fehlertext (`ErrorText`) | string? | – | z. B. „Wert außerhalb 0 bis 100 %“ |
| Übernehmen (`ApplyCommand`), Abbrechen (`CancelCommand`) | ICommand | – | – |
| Ziffer (`DigitCommand`), Rücktaste, Löschen, Vorzeichen, Komma | ICommand<string> | – | – |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Geöffnet | in [HM-14](HM-14_Popup-Rahmen.md): `Brush.Surface`, Eingabezeile `Font.Size.Metric`, Ziffernblock-Tasten `Size.Touch.Large` × `Size.Touch.Default` (`Brush.Button.Normal`) | Titel und Einheit als Text; Grenzen als Caption „Bereich 0 bis 100 %“ |
| Eingabe gültig | Übernehmen aktiv (`Brush.Button.Active`) | `Icon.Confirm` und Text „Übernehmen“ |
| Eingabe ungültig | Eingabezeile Kontur `Border.Thick` `Brush.Status.Error.Fg`, Fläche `Brush.Status.Error.Subtle`; Übernehmen deaktiviert (gestrichelt) | `Icon.Status.Error` und Fehlertext |
| Taste gedrückt | `Brush.Button.Pressed`, `Border.Medium` | dickere Kontur |
| Zeitvariante | Eingabezeile „__:__“, nur Ziffern, Doppelpunkt fest | Platzhalterstruktur hh:mm |
| Filtervariante | zwei Eingabezeilen (Meldenummer, Zeit „__.__.____ __:__:__“), aktive Zeile `Border.Thick` `Brush.Border.Focus`; „Übernehmen“ wendet den Filter an, „Abbrechen“ verwirft | Feldbeschriftungen und Formatplatzhalter als Text; Fehler mit `Icon.Status.Error` und Text |
| Hilfetext | `Font.Size.Caption`, `Brush.Text.Secondary` unter der Eingabezeile | Text, mehrzeilig |
| Nicht berechtigt | Dialog öffnet nicht | Hinweis „Berechtigung erforderlich: <Rolle>“ in der Meldezeile; das Benutzer-Pop-up öffnet sich stattdessen (Navigation.md 4.1) |

HS-37 (Meldearchiv) nutzt die Filtervariante: die Filter-Taste öffnet den Dialog direkt, ohne Eingabefeld [HM-12](HM-12_Eingabefeld-Schluesselsymbol.md). Zur Übersicht der Seiten gehört auch jede Seite, auf der HM-12 liegt.

## Verwendet auf Seiten (IDs)
- [HS-03](../Seiten/HS-03_Maschinengeschwindigkeit.md) – Maschinengeschwindigkeit (Pop-up)
- [HS-05](../Seiten/HS-05_Zufuehrung-Papier.md) – Zuführung Papier
- [HS-06](../Seiten/HS-06_Zufuehrung-Karton.md) – Zuführung Karton
- [HS-07](../Seiten/HS-07_Heissleim-Nordson.md) – Heißleim Nordson
- [HS-08](../Seiten/HS-08_Heissleim-Parameter.md) – Heißleim Parameter
- [HS-09](../Seiten/HS-09_Heissleim-Druck.md) – Heißleim Druck
- [HS-10](../Seiten/HS-10_Zeitschaltuhr.md) – Zeitschaltuhr
- [HS-11](../Seiten/HS-11_Hauptdosierer-1-und-2.md) – Hauptdosierer 1 & 2
- [HS-12](../Seiten/HS-12_Motorparameter.md) – Motorparameter (Hauptdosierer)
- [HS-13](../Seiten/HS-13_Kontrollwaage.md) – Kontrollwaage
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
- [HS-36](../Seiten/HS-36_Service.md) – Service
- [HS-37](../Seiten/HS-37_Meldearchiv.md) – Meldearchiv
- [HS-39](../Seiten/HS-39_System-und-Antriebsinfos.md) – System- und Antriebsinfos

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die Liste ist aus den Abschnitten „Verwendete Module“ und den Elemente-Tabellen der HS-Seiten abgeleitet (Stand Konsolidierung nach Phase 3, Punkt 4); „inkl. Verwendung über Kompositmodul“ nennt Seiten, auf denen das Modul nur innerhalb eines Kompositmoduls vorkommt.

## Herkunft
- [RM-06](../../02_Referenz-Analyse/Module/RM-06_Eingabe-Pop-up.md) – Eingabe-Pop-up: undokumentiertes Eingabe-Pop-up der Referenz; alle Angaben Annahme (A-51)
- Design: keine Entsprechung (Element nur in der Referenz).

## WPF-Umsetzung
- **Control:** `HM13_NumericKeypadDialog` (UserControl (Inhalt von HM14_PopupFrame)), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `UserControl` als Inhalt von `HM14_PopupFrame`; Ergebnis über `IDialogService.ShowInputAsync(InputRequest) : Task<InputResult?>`.
- **Dependency Properties:** `Title`, `CurrentValue`, `InputText`, `Unit`, `Minimum`, `Maximum`, `Decimals`, `InputKind`, `HelpText`, `FilterFields`, `IsValid`, `ErrorText`; **Commands:** `ApplyCommand`, `CancelCommand`, `DigitCommand`, `BackspaceCommand`, `ClearCommand`, `SignCommand`, `DecimalSeparatorCommand`.
- **Maße:** Ziffernblock 3 × 4 Tasten `Size.Touch.Large` × `Size.Touch.Default`, Abstand `Space.M`; Dialogbreite höchstens `Size.Popup.WidthRatio` der Fensterbreite.
- **Symbole** (`Themes/Icons.xaml`, Schema `Icon.<Bereich>.<Name>`): Designsystem: `Icon.Confirm`, `Icon.Status.Error`.
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-13-P01 | Öffnen | Antippen eines berechtigten HM-12 öffnet den Dialog mit vorbelegtem Wert | offen |
| HM-13-P02 | Ziffernblock | 0 bis 9, Komma, Vorzeichen, Rücktaste, Löschen; Tasten ≥ `Size.Touch.Default` hoch | offen |
| HM-13-P03 | Grenzen | Min/Max mit Einheit sichtbar | offen |
| HM-13-P04 | Ungültig | Fehlertext mit Symbol, Übernehmen deaktiviert | offen |
| HM-13-P05 | Zeit | Zeitvariante hh:mm für HM-30 | offen |
| HM-13-P06 | Abbrechen | schließt ohne Änderung | offen |
| HM-13-P07 | Filtervariante | Meldenummer und Zeit (TT.MM.JJJJ hh:mm:ss) als zwei Felder, Übernehmen filtert, Abbrechen verwirft (HS-37) | offen |
| HM-13-P08 | Hilfetext | Caption unter der Eingabezeile, mehrzeilig, zusätzlich zur Bereichsangabe (HS-31) | offen |
| HM-13-P09 | Stapeltiefe | Eingabe-Pop-up über HS-03 öffnet (Tiefe 2), Schließen kehrt zu HS-03 zurück | offen |
