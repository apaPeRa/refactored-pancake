# HM-19 – Blättertasten

## Funktion
Paar Pfeiltasten in der Funktionsleiste ([HM-06](HM-06_Funktionsleiste.md)), das innerhalb derselben Seitenform zwischen gleichartigen Objekten blättert (Hauptdosierer 1/2, Nocken, Waagen, Aktoren, Geber, EA-Karten). Eine Positionsanzeige „n von m“ ist zweiter Kanal und ersetzt das Raten der Wirkung (Wirkung am Rand im Handbuch nicht beschrieben, Annahme: Taste deaktiviert). Variante „einzelne Taste“ (»), die zur nächsten Seite wechselt.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Objektanzahl (`Count`) | int | Stk | 1 bis 99 |
| Aktueller Index (`CurrentIndex`) | int | – | 0 bis Count − 1 |
| Objektname (`CurrentLabel`) | string? | – | z. B. „Hauptdosierer 1“ |
| Darstellung (`PagerStyle`) | enum PagerStyle { Pair, Single } | – | Pair Standard |
| Umlaufend (`IsCyclic`) | bool | – | Standard false |
| Zurück (`PreviousCommand`), Vor (`NextCommand`) | ICommand | – | – |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Aktiv | `Brush.Button.Normal`, Kontur `Border.Thin`, Tasten `Size.Touch.Default` × `Size.Touch.Default` | Pfeilsymbole und Positionsanzeige „1 von 2“ |
| Am Rand | Taste deaktiviert, Kontur gestrichelt (`Border.Dash`) | gestrichelte Kontur |
| Gedrückt | `Brush.Button.Pressed`, `Border.Medium` | dickere Kontur |
| Einzeltaste | wie Aktiv, eine Taste | Symbol `Icon.Chevron` doppelt |

## Verwendet auf Seiten (IDs)
- [HS-11](../Seiten/HS-11_Hauptdosierer-1-und-2.md) – Hauptdosierer 1 & 2
- [HS-12](../Seiten/HS-12_Motorparameter.md) – Motorparameter (Hauptdosierer)
- [HS-20](../Seiten/HS-20_Motorparameter.md) – Motorparameter (Nachdosierer)
- [HS-25](../Seiten/HS-25_Nocken.md) – Nocken
- [HS-26](../Seiten/HS-26_Nockenuebersicht.md) – Nockenübersicht
- [HS-27](../Seiten/HS-27_Waagen-Kalibrieren.md) – Waagen Kalibrieren
- [HS-31](../Seiten/HS-31_Handbetrieb.md) – Handbetrieb
- [HS-32](../Seiten/HS-32_Geber-setzen.md) – Geber setzen
- [HS-34](../Seiten/HS-34_EA-Anzeige.md) – EA-Anzeige

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die HS-Dateien entstehen in Phase 3 (Punkt 4); die Links sind vorläufig.

## Herkunft
- [RM-04](../../02_Referenz-Analyse/Module/RM-04_Blaettertasten.md) – Blättertasten: Paar „<<“ „>>“ bzw. einzelne Taste „»“
- Design: keine Entsprechung (Element nur in der Referenz).

## WPF-Umsetzung
- **Control:** `HM19_PagerButtons` (UserControl), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `UserControl` (`HM19_PagerButtons`) aus zwei Tasten im Stil von HM07.
- **Dependency Properties:** `Count`, `CurrentIndex`, `CurrentLabel`, `PagerStyle`, `IsCyclic`; **Commands:** `PreviousCommand`, `NextCommand`.
- **Neue Symbole** (`Themes/Icons.xaml`): `Icon.Chevron` (Designsystem).
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-19-P01 | Seiten | HS-11, 12, 20, 25, 26, 27, 31, 32, 34 | offen |
| HM-19-P02 | Positionsanzeige | „n von m“ sichtbar | offen |
| HM-19-P03 | Rand | Taste deaktiviert, nicht umlaufend | offen |
| HM-19-P04 | Lage | links in der Funktionsleiste | offen |
| HM-19-P05 | Touch | Tasten ≥ `Size.Touch.Default` × `Size.Touch.Default` | offen |
