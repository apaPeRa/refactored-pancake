# HM-01 – Seitenleiste

## Funktion
Dunkle, neutrale Leiste am linken Rand (Spalte `Size.Sidebar.Width`, volle Höhe), auf allen Vollseiten; bei den Pop-ups (HS-02, HS-03) bleibt sie als Teil der Hintergrundseite sichtbar, ist aber hinter dem Scrim gesperrt (Navigation.md 3.1, 4.2); im Vollbild HS-24 ist sie ausgeblendet (Bildschirm reinigen, Navigation.md). Oben die Benutzerkennung (Kreis `Size.Avatar` mit Initialen, Name, Rolle, Berechtigungssymbol), darunter die Symboltasten Home (Produktion), Einstellungen und Meldungen, ganz unten Zurück (eine Ebene). Sie übernimmt die festen Navigationstasten „Produktion“, „Einstellungen“, „Zurück“ der Referenz-Fußleiste ([RM-03](../../02_Referenz-Analyse/Module/RM-03_Funktionsleiste-unten.md)); der Benutzerkreis öffnet das Benutzer-Pop-up (Anmelden/Abmelden) und ersetzt das gelbe Schloss der Referenz (A-35). Zeitformat und Zähler-Punkt: A-47. Alle Symbole tragen eine Kurzbeschriftung (`Font.Size.Caption`) und einen Barrierefreiheitsnamen (OP-21).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Initialen (`Initials`) | string | – | 2 Zeichen (Bild „MM“) |
| Name (`UserName`) | string | – | Vor- und Nachname, bis 2 Zeilen (Bild „Max Mustermann“) |
| Rolle (`UserRole`) | string | – | Rollenname (Bild „Technik“); weitere Rollen offen (OP-04) |
| Angemeldet (`IsLoggedIn`) | bool | – | true / false |
| Einträge (`Items`) | IReadOnlyList<SidebarItem> | – | 4 Einträge: Home, Einstellungen, Meldungen (oben), Zurück (unten); je Id, Label, Icon, Zielseite |
| Aktueller Eintrag (`CurrentItemId`) | string | – | Id eines Eintrags oder leer |
| Neue Meldungen (`UnreadMessageCount`) | int | Stk | 0 bis 99 (ab 100 „99+“) |
| Zurück möglich (`CanGoBack`) | bool | – | false auf der Startseite |
| Navigieren (`NavigateCommand`) | ICommand (Parameter string Seiten-ID) | – | Zielseiten HS-01, HS-04, HS-38 |
| Zurück (`BackCommand`) | ICommand | – | – |
| Benutzer (`UserCommand`) | ICommand | – | öffnet das Benutzer-Pop-up (A-35) |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Normal | `Brush.Sidebar` Grund, Symbole `Brush.Sidebar.Text`, Caption `Brush.Sidebar.Text.Secondary`, Symbol `Size.Icon.L`, Eintrag volle Spaltenbreite × 96 (`Size.Touch.Large`), Avatar `Size.Avatar` | Symbol und Kurzbeschriftung |
| Aktuelle Seite | `Brush.Sidebar.Selected` Hintergrund | Balken am linken Rand (`Size.SelectionBar`, Form) zusätzlich zum Hintergrund |
| Gedrückt | Hintergrund `Brush.Sidebar.Selected`, Kontur `Border.Medium` | dickere Kontur; Auslösen beim Loslassen |
| Deaktiviert (Zurück auf Startseite) | Symbol `Brush.Sidebar.Text.Secondary`, Kontur gestrichelt (`Border.Dash`) | gestrichelte Kontur; Tippen nennt Grund in der Meldezeile (A-28) |
| Neue Meldungen | Zähler-Punkt am Symbol `Icon.Messages`, `Brush.Status.Warning.Fill` mit `Brush.Status.Warning.On`, Kontur `Border.Medium` `Brush.Status.Warning.Fg` | Zahl im Punkt (1 bis 99) |
| Angemeldet | Kreis `Brush.Sidebar.Selected`, Initialen `Brush.Sidebar.Text`, `Icon.Key` (`Size.Icon.S`) | Name und Rolle als Text; Schlüssel-Symbol |
| Abgemeldet | neutraler Kreis, `Icon.User` | Text „Nicht angemeldet“ und `Icon.Lock` |

## Verwendet auf Seiten (IDs)
- [HS-01](../Seiten/HS-01_Produktion.md) – Produktion
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
- [HS-15](../Seiten/HS-15_Trend.md) – Trend
- [HS-16](../Seiten/HS-16_Schliessmaschine.md) – Schließmaschine
- [HS-17](../Seiten/HS-17_Motorparameter-Schliessmaschine.md) – Motorparameter (Schließmaschine)
- [HS-18](../Seiten/HS-18_Gewichtskorrektur-Schliessmaschine.md) – Gewichtskorrektur (Schließmaschine)
- [HS-19](../Seiten/HS-19_Nachdosierer.md) – Nachdosierer
- [HS-20](../Seiten/HS-20_Motorparameter.md) – Motorparameter (Nachdosierer)
- [HS-21](../Seiten/HS-21_Gewichtskorrektur.md) – Gewichtskorrektur (Nachdosierer)
- [HS-22](../Seiten/HS-22_Heizungen.md) – Heizungen
- [HS-23](../Seiten/HS-23_Regulierung.md) – Regulierung
- [HS-25](../Seiten/HS-25_Nocken.md) – Nocken
- [HS-26](../Seiten/HS-26_Nockenuebersicht.md) – Nockenübersicht
- [HS-27](../Seiten/HS-27_Waagen-Kalibrieren.md) – Waagen Kalibrieren
- [HS-28](../Seiten/HS-28_Packungsregister.md) – Packungsregister
- [HS-29](../Seiten/HS-29_Produktionsstatistik.md) – Produktionsstatistik
- [HS-30](../Seiten/HS-30_Handbetrieb-Auswahl.md) – Handbetrieb Auswahl
- [HS-31](../Seiten/HS-31_Handbetrieb.md) – Handbetrieb
- [HS-32](../Seiten/HS-32_Geber-setzen.md) – Geber setzen
- [HS-33](../Seiten/HS-33_EA-Uebersicht.md) – EA-Übersicht
- [HS-34](../Seiten/HS-34_EA-Anzeige.md) – EA-Anzeige
- [HS-35](../Seiten/HS-35_Systemeinstellungen.md) – Systemeinstellungen
- [HS-36](../Seiten/HS-36_Service.md) – Service
- [HS-37](../Seiten/HS-37_Meldearchiv.md) – Meldearchiv
- [HS-38](../Seiten/HS-38_Meldeanzeige.md) – Meldeanzeige
- [HS-39](../Seiten/HS-39_System-und-Antriebsinfos.md) – System- und Antriebsinfos
- [HS-40](../Seiten/HS-40_Zufuehrungen.md) – Zuführungen
- [HS-41](../Seiten/HS-41_Dosierer-Uebersicht.md) – Dosierer-Übersicht
- [HS-42](../Seiten/HS-42_Waagen.md) – Waagen
- [HS-43](../Seiten/HS-43_Schichtplan.md) – Schichtplan

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die Liste ist aus den Abschnitten „Verwendete Module“ und den Elemente-Tabellen der HS-Seiten abgeleitet (Stand Konsolidierung nach Phase 3, Punkt 4); „inkl. Verwendung über Kompositmodul“ nennt Seiten, auf denen das Modul nur innerhalb eines Kompositmoduls vorkommt.

## Herkunft
- [DM-01](../../01_Design-Analyse/Module/DM-01_Benutzerkennung.md) – Benutzerkennung: Kreis mit Initialen, Name, Rolle
- [DM-02](../../01_Design-Analyse/Module/DM-02_Navigationsleiste.md) – Navigationsleiste: Symbolleiste Home, Einstellungen, Meldungen, Zurück
- [RM-03](../../02_Referenz-Analyse/Module/RM-03_Funktionsleiste-unten.md) – Funktionsleiste unten: feste Tasten Produktion, Einstellungen, Zurück und Schloss-Symbol der Referenz-Fußleiste

## WPF-Umsetzung
- **Control:** `HM01_Sidebar` (UserControl), Ordner `src/.../Controls/`, Code-behind nur Dependency-Property-Deklarationen ohne Logik (Custom Control, A-73).
- **Typ:** `UserControl`; Eintrag als `HM01_SidebarButton` (`ControlTemplate` auf `Button`/`RadioButton`).
- **Dependency Properties:** `Initials`, `UserName`, `UserRole`, `IsLoggedIn`, `Items`, `CurrentItemId`, `UnreadMessageCount`, `CanGoBack`.
- **Commands:** `NavigateCommand`, `BackCommand`, `UserCommand` (Bindung an Navigationsdienst, `INavigationService`).
- **Layout:** `Grid` mit Zeilen Kennung (Auto), Einträge (`*`), Zurück (Auto); einmal im Hauptfenster (Spalte `Size.Sidebar.Width`).
- **Symbole** (`Themes/Icons.xaml`, Schema `Icon.<Bereich>.<Name>`): Designsystem: `Icon.Key`, `Icon.Lock`, `Icon.Messages`, `Icon.User`.
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-01-P01 | Inhalt | Kreis mit Initialen, Name und Rolle oben | offen |
| HM-01-P02 | Navigation | 3 Symboltasten oben (Home, Einstellungen, Meldungen), Zurück ganz unten | offen |
| HM-01-P03 | Aktuelle Seite | Eintrag der aktuellen Seite mit Balken links und hellerem Grund | offen |
| HM-01-P04 | Touch | jeder Eintrag volle Spaltenbreite × `Size.Touch.Large`, Abstand ≥ `Size.Touch.Gap` | offen |
| HM-01-P05 | Beschriftung | jedes Symbol hat Kurzbeschriftung und Barrierefreiheitsname aus `.resx` | offen |
| HM-01-P06 | Kontrast | Name und Rolle ≥ 4,5 : 1 auf `Brush.Sidebar` (7,89 : 1 / 8,88 : 1) | offen |
| HM-01-P07 | Seitenübergreifend | identisch auf allen Vollseiten; hinter Pop-ups (HS-02, HS-03) sichtbar, aber gesperrt (Scrim); im Vollbild HS-24 nicht sichtbar | offen |
