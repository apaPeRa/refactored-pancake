# HM-25 – Meldungsliste

## Funktion
Scrollbare Liste für Meldungen und Auswahllisten: Meldearchiv (Zeit, Ereignis, Beschreibung), Meldeanzeige (Nummer, Meldung) und Variablenliste mit markierbarer Zeile („500 von 111427 Variablen“). Meldungen sind nach Klasse gekennzeichnet (Betriebsstatus, Hinweis, Störung, A-49). Vier Scrolltasten (Anfang, Seite hoch, Seite runter, Ende) oder ein Rollbalken; Wischen ist möglich. Filter, Export, Liste leeren sind Tasten der Seite ([HM-07](HM-07_Aktionstaste.md)). Sortierung absteigend nach Zeit bzw. Nummer.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Zeilen (`Items`) | IReadOnlyList<MessageEntry> | – | Timestamp (DateTime), Event (string), Number (int), Text (string), Class (MessageClass) |
| Listenart (`ListKind`) | enum MessageListKind { Archive, Live, Selection } | – | – |
| Zeitformat | DateTime | TT.MM.JJJJ hh:mm:ss | z. B. 05.05.2025 10:13:55 |
| Nummer (`Number`) | int | – | 0 bis 999, z. B. 120, 081, 000, 090 |
| Auswahl (`SelectedItem`) | MessageEntry? | – | nur Listenart Selection |
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
| Ausgewählte Zeile | Kontur `Border.Thick` `Brush.Border.Focus` | Rahmen und Haken |
| Gefiltert | Filterhinweis `Brush.Status.Info.Subtle` | `Icon.Status.Info` und Text „Filter aktiv“ |
| Leer | neutral | Text „Keine Meldungen“ |
| Scrolltaste am Rand | deaktiviert, gestrichelt | gestrichelte Kontur |

## Verwendet auf Seiten (IDs)
- [HS-36](../Seiten/HS-36_Service.md) – Service
- [HS-37](../Seiten/HS-37_Meldearchiv.md) – Meldearchiv
- [HS-38](../Seiten/HS-38_Meldeanzeige.md) – Meldeanzeige
- [HS-39](../Seiten/HS-39_System-und-Antriebsinfos.md) – System- und Antriebsinfos

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die HS-Dateien entstehen in Phase 3 (Punkt 4); die Links sind vorläufig.

## Herkunft
- [RM-21](../../02_Referenz-Analyse/Module/RM-21_Meldungsliste.md) – Meldungsliste: Meldearchiv, Meldeanzeige, Variablenliste mit Scrolltasten
- Design: keine Entsprechung (Element nur in der Referenz).

## WPF-Umsetzung
- **Control:** `HM25_MessageList` (UserControl), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `UserControl` (`HM25_MessageList`) auf Basis `ListView`/`ItemsControl` mit virtualisierendem Panel; Zeilenhöhe 48 px; Spalten per `GridViewColumn` oder `DataTemplate` je Listenart.
- **Dependency Properties:** `Items`, `ListKind`, `SelectedItem`, `TotalCount`, `IsFiltered`; **Commands:** vier Scrollbefehle.
- **Neue Symbole** (`Themes/Icons.xaml`): `Icon.Scroll.Up`, `Icon.Scroll.Down` (Designsystem); `Icon.Scroll.First`, `Icon.Scroll.Last` (neu).
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-25-P01 | Spalten | Archiv: Zeit, Ereignis, Beschreibung; Anzeige: Nummer, Meldung | offen |
| HM-25-P02 | Klassen | jede Klasse mit Symbol und Wort | offen |
| HM-25-P03 | Scrollen | vier Tasten ≥ 64 px oder Rollbalken, Wischen | offen |
| HM-25-P04 | Auswahl | markierte Zeile mit Rahmen und Haken | offen |
| HM-25-P05 | Zähler | „500 von 111427“ als Text | offen |
| HM-25-P06 | Sortierung | absteigend nach Zeit bzw. Nummer | offen |
