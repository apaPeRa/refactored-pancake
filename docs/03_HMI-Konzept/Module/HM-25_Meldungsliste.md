# HM-25 – Meldungsliste

## Funktion
Scrollbare Liste für Meldungen und Auswahllisten: Meldearchiv (Zeit, Ereignis, Beschreibung), Meldeanzeige (Nummer, Meldung) und Variablenliste mit markierbarer Zeile („500 von 111427 Variablen“). Meldungen sind nach Klasse gekennzeichnet (Betriebsstatus, Hinweis, Störung, A-49). Vier Scrolltasten (Anfang, Seite hoch, Seite runter, Ende) oder ein Rollbalken; Wischen ist möglich. Filter, Export, Liste leeren sind Tasten der Seite ([HM-07](HM-07_Aktionstaste.md)). **Sortierrichtung als Parameter** (`SortDirection`): Archiv absteigend nach Zeit (neueste oben), Meldeanzeige HS-38 aufsteigend nach Nummer (Bild). Auswahl: einzeln (Markierung) oder **Mehrfachauswahl** (Variablenliste HS-36, „Liste exportieren“ verlangt ausgewählte Variablen; Antippen einer markierten Zeile hebt die Auswahl auf). Bedienung des Blätterns als vier Scrolltasten oder als **Rollbalken** (HS-38, Trefferbereich ≥ `Size.Touch.Min`, Wischen zusätzlich). Optionale **Klassenspalte** mit Symbol und Klassenwort als zweiter Kanal zur Zeilenfarbe (HS-38 neben Nummer und Meldung).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Zeilen (`Items`) | IReadOnlyList<MessageEntry> | – | Timestamp (DateTime), Event (string), Number (int), Text (string), Class (MessageClass) |
| Listenart (`ListKind`) | enum MessageListKind { Archive, Live, Selection } | – | – |
| Zeitformat | DateTime | TT.MM.JJJJ hh:mm:ss | z. B. 05.05.2025 10:13:55 |
| Nummer (`Number`) | int | – | 0 bis 999, z. B. 120, 081, 000, 090 |
| Auswahlmodus (`SelectionMode`) | enum ListSelectionMode { None, Single, Multiple } | – | None bei Archiv und Live; Single oder Multiple bei Selection (Multiple: HS-36) |
| Auswahl (`SelectedItem`, `SelectedItems`) | MessageEntry?, IList<MessageEntry> | – | nur Listenart Selection |
| Sortierrichtung (`SortDirection`) | enum SortDirection { Ascending, Descending } | – | Archive Descending (Zeit), Live Ascending (Nummer, HS-38); Variablenliste nach Konfiguration |
| Blätterart (`ScrollStyle`) | enum ListScrollStyle { Buttons, Scrollbar } | – | Buttons Standard (HS-37, HS-36); Scrollbar mit Wischen (HS-38) |
| Klassenspalte (`ShowClassColumn`) | bool | – | Symbol und Klassenwort je Zeile; Standard true bei Live |
| Gesamtzahl (`TotalCount`) | int | Stk | z. B. 111427 |
| Filter aktiv (`IsFiltered`) | bool | – | – |
| Scrollen (`ScrollFirstCommand`, `ScrollPageUpCommand`, `ScrollPageDownCommand`, `ScrollLastCommand`) | ICommand | – | – |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Zeile Betriebsstatus | `Brush.Status.Ok.Subtle` | `Icon.Status.Ok` und Klassenwort „Betrieb“ |
| Zeile Hinweis | `Brush.Status.Warning.Subtle` | `Icon.Status.Warning` und Wort „Hinweis“ |
| Zeile Störung | `Brush.Status.Error.Subtle` | `Icon.Status.Error` und Wort „Störung“ |
| Ausgewählte Zeile | Kontur `Border.Thick` `Brush.Border.Focus` | Rahmen und Haken (bei Mehrfachauswahl an jeder gewählten Zeile; Zähler „n ausgewählt“ als Text) |
| Rollbalken | Schieber `Brush.Button.Normal`, Spur `Brush.Surface.Sunken`, Breite ≥ `Size.Touch.Min` | Position als Zeilenbereich („1 bis 12 von 40“) |
| Klassenspalte | schmale Spalte vor dem Text | `Icon.Status.*` und Klassenwort in jeder Zeile |
| Gefiltert | Filterhinweis `Brush.Status.Info.Subtle` | `Icon.Status.Info` und Text „Filter aktiv“ |
| Leer | neutral | Text „Keine Meldungen“ |
| Scrolltaste am Rand | deaktiviert, gestrichelt | gestrichelte Kontur |

## Verwendet auf Seiten (IDs)
- [HS-36](../Seiten/HS-36_Service.md) – Service
- [HS-37](../Seiten/HS-37_Meldearchiv.md) – Meldearchiv
- [HS-38](../Seiten/HS-38_Meldeanzeige.md) – Meldeanzeige

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die Liste ist aus den Abschnitten „Verwendete Module“ und den Elemente-Tabellen der HS-Seiten abgeleitet (Stand Konsolidierung nach Phase 3, Punkt 4); „inkl. Verwendung über Kompositmodul“ nennt Seiten, auf denen das Modul nur innerhalb eines Kompositmoduls vorkommt.

## Herkunft
- [RM-21](../../02_Referenz-Analyse/Module/RM-21_Meldungsliste.md) – Meldungsliste: Meldearchiv, Meldeanzeige, Variablenliste mit Scrolltasten
- Design: keine Entsprechung (Element nur in der Referenz).

## WPF-Umsetzung
- **Control:** `HM25_MessageList` (UserControl), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `UserControl` (`HM25_MessageList`) auf Basis `ListView`/`ItemsControl` mit virtualisierendem Panel; Zeilenhöhe `Size.Touch.Min`; Spalten per `GridViewColumn` oder `DataTemplate` je Listenart.
- **Dependency Properties:** `Items`, `ListKind`, `SelectionMode`, `SelectedItem`, `SelectedItems`, `SortDirection`, `ScrollStyle`, `ShowClassColumn`, `TotalCount`, `IsFiltered`; **Commands:** vier Scrollbefehle.
- **Symbole** (`Themes/Icons.xaml`, Schema `Icon.<Bereich>.<Name>`): Designsystem: `Icon.Scroll.Up`, `Icon.Scroll.Down`, `Icon.Status.Error`, `Icon.Status.Info`, `Icon.Status.Ok`, `Icon.Status.Warning`.
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-25-P01 | Spalten | Archiv: Zeit, Ereignis, Beschreibung; Anzeige: Nummer, Meldung | offen |
| HM-25-P02 | Klassen | jede Klasse mit Symbol und Wort | offen |
| HM-25-P03 | Scrollen | vier Tasten ≥ `Size.Touch.Default` oder Rollbalken, Wischen | offen |
| HM-25-P04 | Auswahl | markierte Zeile mit Rahmen und Haken | offen |
| HM-25-P05 | Zähler | „500 von 111427“ als Text | offen |
| HM-25-P06 | Sortierung | `SortDirection` als Parameter: Archiv absteigend nach Zeit, Meldeanzeige (HS-38) aufsteigend nach Nummer | offen |
| HM-25-P07 | Mehrfachauswahl | `SelectionMode = Multiple`: mehrere Variablen markierbar, jede mit Rahmen und Haken, Antippen hebt auf (HS-36) | offen |
| HM-25-P08 | Rollbalken | `ScrollStyle = Scrollbar`: Trefferbereich ≥ `Size.Touch.Min`, Wischen zusätzlich (HS-38) | offen |
| HM-25-P09 | Klassenspalte | Symbol und Klassenwort je Zeile zusätzlich zur Zeilenfarbe (HS-38) | offen |
