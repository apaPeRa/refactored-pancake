# HM-17 – Titelzeile (Objektüberschrift)

## Funktion
Überschrift für das Objekt, das die Seite gerade zeigt (Dosierer „Hauptdosierer 1“ auf HS-11 und HS-12, Waage „16KW1 Kontrollwaage“, Antrieb „Antrieb Zuführung 2MA1“, EA-Karte „S1_0KDE1“), gewechselt mit den Blättertasten [HM-19](HM-19_Blaettertasten.md). Optional zeigt die Zeile bis zu zwei Kennwerte (Sollgewicht KW, Letztes Gewicht KW) und ein Detail-Symbol (vier Pfeile in Rahmen, Funktion offen, OP-17). Abgrenzung: Seitentitel ist das letzte Segment von [HM-04](HM-04_Brotkruemel-Navigation.md); diese Zeile benennt das Objekt innerhalb der Seite.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Objektname (`Title`) | string | – | Betriebsmittelkennzeichen und Bezeichnung |
| Kennwerte (`Values`) | IReadOnlyList<TitleValue> | g | 0 bis 2 (Bild: Sollgewicht 235 g, Letztes Gewicht 238 g) |
| Abweichungsgrenze (`DeviationLimit`) | double? | g | offen, null = keine Prüfung |
| Detail (`DetailCommand`) | ICommand? | – | null = Symbol ausgeblendet |
| Ausrichtung (`TitleAlignment`) | enum TitleAlignment { Center, Left } | – | Center für Objektüberschrift |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Überschrift | `Font.Size.Value` `Font.Weight.Strong` `Brush.Text.Primary`, Trennlinie `Brush.Divider` darunter | Fettschrift und Linie (keine Unterstreichung) |
| Mit Kennwerten | `Brush.Surface.Sunken`, Format „Sollgewicht KW: 235 g \| Letztes Gewicht KW: 238 g“ | Text |
| Abweichung | `Brush.Status.Warning.Subtle`, Kontur `Border.Medium` `Brush.Status.Warning.Fg` | `Icon.Status.Warning` und Text „Abweichung“ (Annahme) |
| Detail gedrückt | `Brush.Button.Pressed`, `Border.Medium` | dickere Kontur |
| Objektwechsel | Titel wechselt mit dem Objekt | Titeltext |

## Verwendet auf Seiten (IDs)
- [HS-11](../Seiten/HS-11_Hauptdosierer-1-und-2.md) – Hauptdosierer 1 & 2
- [HS-12](../Seiten/HS-12_Motorparameter.md) – Motorparameter (Hauptdosierer)
- [HS-27](../Seiten/HS-27_Waagen-Kalibrieren.md) – Waagen Kalibrieren
- [HS-31](../Seiten/HS-31_Handbetrieb.md) – Handbetrieb
- [HS-32](../Seiten/HS-32_Geber-setzen.md) – Geber setzen
- [HS-34](../Seiten/HS-34_EA-Anzeige.md) – EA-Anzeige
- [HS-41](../Seiten/HS-41_Dosierer-Uebersicht.md) – Dosierer-Übersicht

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die Liste ist aus den Abschnitten „Verwendete Module“ und den Elemente-Tabellen der HS-Seiten abgeleitet (Stand Konsolidierung nach Phase 3, Punkt 4); „inkl. Verwendung über Kompositmodul“ nennt Seiten, auf denen das Modul nur innerhalb eines Kompositmoduls vorkommt.

## Herkunft
- [DM-21](../../01_Design-Analyse/Module/DM-21_Titelzeile-mit-Verschiebesymbol.md) – Titelzeile mit Verschiebesymbol: blaue Titelzeile mit Soll-/Istgewicht und Verschiebesymbol
- [RM-25](../../02_Referenz-Analyse/Module/RM-25_Objekt-Ueberschrift.md) – Objekt-Überschrift: zentrierte Objekt-Überschrift (Waage, Antrieb, EA-Karte)

## WPF-Umsetzung
- **Control:** `HM17_TitleBar` (UserControl), Ordner `src/.../Controls/`, Code-behind nur Dependency-Property-Deklarationen ohne Logik (Custom Control, A-73).
- **Typ:** `UserControl` (`HM17_TitleBar`).
- **Dependency Properties:** `Title`, `Values`, `DeviationLimit`, `TitleAlignment`; **Command:** `DetailCommand`.
- **Ergänzung (Behebung der Prüfbefunde M2):** Der Zustand Abweichung entsteht, wenn `HasDeviation` gesetzt ist oder `DeviationLimit` und zwei Kennwerte vorliegen und der Betrag der Differenz (zweiter Kennwert minus erster, Anzeigetext nach `CurrentCulture`) die Grenze übersteigt (`HM17_DeviationConverter`).
- Detail-Symbol `Icon.Move` mit Trefferfläche ≥ `Size.Touch.Min`.
- **Symbole** (`Themes/Icons.xaml`, Schema `Icon.<Bereich>.<Name>`): Designsystem: `Icon.Move`, `Icon.Status.Warning`.
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-17-P01 | DS-04 | Text „Sollgewicht KW: 235 g \| Letztes Gewicht KW: 238 g“ über den Karten | offen |
| HM-17-P02 | Objekt | HS-11, HS-12, HS-27, HS-31, HS-32, HS-34 und HS-41 zeigen den Objektnamen und wechseln ihn mit HM-19 | offen |
| HM-17-P03 | Schreibweise | Wert, geschütztes Leerzeichen, „g“ | offen |
| HM-17-P04 | Detail-Symbol | rechts in der Zeile, Trefferfläche ≥ `Size.Touch.Min` | offen |
| HM-17-P05 | Keine Unterstreichung | Linie statt Unterstreichung | offen |
