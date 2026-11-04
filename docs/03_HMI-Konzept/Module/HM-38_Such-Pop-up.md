# HM-38 – Such-Pop-up (Suche mit Trefferliste)

## Funktion
**Annahme (A-60, OP-40):** Modaler Dialog zur Suche eines Betriebsmittels nach Kennzeichnung oder Bezeichnung, im [Pop-up-Rahmen](HM-14_Popup-Rahmen.md). Die Referenz nennt die Taste „Suchen“ (HS-30, HS-31, HS-33), beschreibt aber weder Eingabe noch Trefferliste. Inhalt: Titel (z. B. „Aktor suchen“, „Betriebsmittel suchen“), Texteingabezeile mit Bildschirmtastatur (Eingabeart Text aus [HM-13](HM-13_Eingabe-Pop-up.md)), darunter die Trefferliste. Die Liste filtert bei jeder Eingabe (Teilzeichenfolge, ohne Unterscheidung von Groß- und Kleinschreibung) über Kennzeichnung und Bezeichnung. Jede Trefferzeile zeigt Kennzeichnung, Bezeichnung und Gruppe bzw. Karte. Treffer antippen schließt den Dialog und liefert das Ziel an die Seite (HS-31 mit `groupId` und `actorId`, HS-34 mit der EA-Karte). „Abbrechen“ und Kreuz schließen ohne Wirkung. Ein Dialog für alle Suchseiten, keine Kopien je Seite. Modale Regeln nach A-40 und Navigation.md 4.2.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Titel (`Title`) | string | – | „Aktor suchen“ (HS-30, HS-31), „Betriebsmittel suchen“ (HS-33) |
| Suchtext (`SearchText`) | string | – | Betriebsmittelkennzeichnung, z. B. „2MA1“, „0E3“; höchstens 40 Zeichen |
| Quelle (`Items`) | IReadOnlyList<SearchHit> | – | je Identifier (Kennzeichnung), Description (Bezeichnung), Group (Gruppe oder Karte), TargetKey (Parameter für die Zielseite) |
| Treffer (`FilteredItems`) | IReadOnlyList<SearchHit> | – | berechnet bei jeder Eingabe |
| Gewählter Treffer (`SelectedHit`) | SearchHit? | – | gesetzt durch Antippen |
| Leertext (`EmptyText`) | string | – | Standard „Kein Treffer“ |
| Platzhalter (`Placeholder`) | string? | – | z. B. „Kennzeichnung eingeben“ |
| Befehle | ICommand | – | `SelectHitCommand`, `CancelCommand`, `ClearTextCommand`, Scrollbefehle (hoch, runter) |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Geöffnet, ohne Eingabe | in [HM-14](HM-14_Popup-Rahmen.md): `Brush.Surface`, Eingabezeile Kontur `Border.Thick` `Brush.Border.Focus`, vollständige Liste | Titel, Platzhaltertext, Fokusrahmen |
| Gefiltert | Trefferzeilen mindestens `Size.Touch.Min` hoch, Text `Font.Size.Body` | Treffer als Text: Kennzeichnung, Bezeichnung, Gruppe |
| Treffer gedrückt | `Brush.Button.Pressed`, Kontur `Border.Medium` | dickere Kontur |
| Kein Treffer | neutral | `Icon.Status.Info` und Text „Kein Treffer“ |
| Liste länger als sichtbar | Scrolltasten bzw. Wischen | `Icon.Scroll.Up` / `Icon.Scroll.Down`; am Rand deaktiviert (gestrichelt) |
| Abgebrochen | Dialog schließt, keine Navigation | – |

## Verwendet auf Seiten (IDs)
- [HS-30](../Seiten/HS-30_Handbetrieb-Auswahl.md) – Handbetrieb Auswahl
- [HS-31](../Seiten/HS-31_Handbetrieb.md) – Handbetrieb
- [HS-33](../Seiten/HS-33_EA-Uebersicht.md) – EA-Übersicht

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die Liste ist aus den Abschnitten „Verwendete Module“ und den Elemente-Tabellen der HS-Seiten abgeleitet (Stand Konsolidierung nach Phase 3, Punkt 4); „inkl. Verwendung über Kompositmodul“ nennt Seiten, auf denen das Modul nur innerhalb eines Kompositmoduls vorkommt. Hinweis: HS-30, HS-31 und HS-33 führen den Dialog in ihrem Abschnitt „Verwendete Module“ noch als „HM-14 mit HM-13 (Variante Text)“; die Nachführung auf HM-38 steht aus.

## Herkunft
- Keine DM- oder RM-Entsprechung: Taste „Suchen“ in [RM-14](../../02_Referenz-Analyse/Module/RM-14_Kachel-Navigation.md)-Seiten (RS-30, RS-31, RS-33); Aufbau und Verhalten sind Annahme (A-60, OP-40, OP-30).
- Design: keine Entsprechung.

## WPF-Umsetzung
- **Control:** `HM38_SearchDialog` (UserControl, Inhalt von `HM14_PopupFrame`), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `UserControl`; Ergebnis über `IDialogService.ShowSearchAsync(SearchRequest) : Task<SearchHit?>`; Filterung im ViewModel (Teilzeichenfolge, `StringComparison.CurrentCultureIgnoreCase`), Liste virtualisierend.
- **Dependency Properties:** `Title`, `SearchText`, `Items`, `FilteredItems`, `SelectedHit`, `EmptyText`, `Placeholder`; **Commands:** `SelectHitCommand`, `CancelCommand`, `ClearTextCommand`, `ScrollUpCommand`, `ScrollDownCommand`.
- **Maße:** Trefferzeile ≥ `Size.Touch.Min` hoch, Tasten `Size.Touch.Default`, Dialogbreite höchstens `Size.Popup.WidthRatio`.
- **Symbole** (`Themes/Icons.xaml`, Schema `Icon.<Bereich>.<Name>`): Designsystem: `Icon.Scroll.Up`, `Icon.Scroll.Down`, `Icon.Status.Info`, `Icon.Close`.
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-38-P01 | Aufbau | Titel, Eingabezeile mit Bildschirmtastatur, Trefferliste, „Abbrechen“ und Kreuz | offen |
| HM-38-P02 | Filter | Liste filtert bei jeder Eingabe nach Teilzeichenfolge in Kennzeichnung und Bezeichnung, ohne Groß-/Kleinschreibung | offen |
| HM-38-P03 | Treffer | Zeile zeigt Kennzeichnung, Bezeichnung und Gruppe, Höhe ≥ `Size.Touch.Min`; Antippen schließt und liefert das Ziel | offen |
| HM-38-P04 | Kein Treffer | Text „Kein Treffer“ mit `Icon.Status.Info` | offen |
| HM-38-P05 | Modal | Antippen außerhalb schließt nicht; „Zurück“ der Seitenleiste gesperrt; „Abbrechen“ ohne Navigation | offen |
| HM-38-P06 | Scrollen | bei mehr Treffern als sichtbar Wischen oder `Icon.Scroll.Up`/`.Down` | offen |
