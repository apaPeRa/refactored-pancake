# HM-22 – Gewichtskorrektur-Tabelle

## Funktion
Eingabetabelle für die Stützstellen der Dosierkorrektur (Schneckendosierer): zwei Blöcke mit je zehn Zeilen und den Spalten SOLL und IST (20 Wertepaare), das Feld „Sollgewicht“ und die Tasten „Dosierer Auslösen manuell“ und „Gewichtsanpassung“. Ablauf in vier Schritten (Handbuch): Sollgewicht einstellen, Dosierer manuell auslösen, Soll und gemessenes Ist eintragen, Gewichtsanpassung berechnen. Leere Zeilen (0,00 g) bleiben unberücksichtigt; empfohlen mindestens 3, besser 5 bis 8 gleichmäßig verteilte Stützstellen. Felder sind [HM-12](HM-12_Eingabefeld-Schluesselsymbol.md), Tasten [HM-07](HM-07_Aktionstaste.md).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Stützstellen (`Points`) | IList<CorrectionPoint> | – | 20 Paare (2 × 10), je Soll, Ist |
| SOLL (`Nominal`) | double | g | Bild 18,00; 22,00; … ; 0,00 = leer |
| IST (`Actual`) | double | g | Bild 20,00; 24,00; … ; 0,00 = leer |
| Sollgewicht (`TargetWeight`) | double | g | Bild 250,4 |
| Gültige Stützstellen (`ValidPointCount`) | int | Stk | berechnet, 0 bis 20; Mindestzahl 3, empfohlen 5 bis 8 |
| Ergebnis (`CalculationState`) | enum CalculationState { None, TooFewPoints, Invalid, Calculated } | – | – |
| Gewichtsanpassung (`AdjustCommand`), Dosierer auslösen (`TriggerCommand`) | ICommand | – | beide ohne Schlüssel (Referenzbild gewinnt); das Schlüsselsymbol steht nur am Sollgewicht-Feld |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Leer | Zeile `Brush.Text.Secondary` | Wert „0,00 g“, Zeile ohne Haken |
| Gefüllt | HM-12-Felder, Zeile mit Haken `Icon.State.On` | Haken in der Zeile |
| Zu wenige Stützstellen | `Brush.Status.Warning.Subtle`, Kontur `Border.Medium` `Brush.Status.Warning.Fg` | `Icon.Status.Warning` und Text „Mindestens 3 Stützstellen“ |
| Ungültiges Paar | Zeile `Brush.Status.Error.Subtle` | `Icon.Status.Error` und Text („Soll und Ist erforderlich“, Annahme) |
| Berechnet | `Brush.Status.Ok.Subtle` | `Icon.Status.Ok` und Text „Kennlinie berechnet“ |
| Gesperrt | Felder und Tasten nicht bedienbar | `Icon.Lock` |

## Verwendet auf Seiten (IDs)
- [HS-18](../Seiten/HS-18_Gewichtskorrektur-Schliessmaschine.md) – Gewichtskorrektur (Schließmaschine)
- [HS-21](../Seiten/HS-21_Gewichtskorrektur.md) – Gewichtskorrektur (Nachdosierer)

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die Liste ist aus den Abschnitten „Verwendete Module“ und den Elemente-Tabellen der HS-Seiten abgeleitet (Stand Konsolidierung nach Phase 3, Punkt 4); „inkl. Verwendung über Kompositmodul“ nennt Seiten, auf denen das Modul nur innerhalb eines Kompositmoduls vorkommt.

## Herkunft
- [RM-17](../../02_Referenz-Analyse/Module/RM-17_Gewichtskorrektur-Tabelle.md) – Gewichtskorrektur-Tabelle: Soll/Ist-Stützstellen, Gewichtsanpassung, Dosierer auslösen
- Design: keine Entsprechung (Element nur in der Referenz).

## WPF-Umsetzung
- **Control:** `HM22_WeightCorrectionTable` (UserControl), Ordner `src/.../Controls/`, Code-behind nur Dependency-Property-Deklarationen ohne Logik (Custom Control, A-73).
- **Typ:** `UserControl` (`HM22_WeightCorrectionTable`), zwei `ItemsControl`-Blöcke mit `HM12_ValueInput` je Zelle.
- **Dependency Properties:** `Points`, `TargetWeight`, `ValidPointCount`, `CalculationState`; **Commands:** `AdjustCommand`, `TriggerCommand`.
- **Ergänzung (Behebung der Prüfbefunde M2):** Zeilenhöhe der Stützstellen explizit `MinHeight = Size.Touch.Min`. Einheiten (g, Stk) aus den Ressourcen.
- Zeilenhöhe `Size.Touch.Min`; zwei Blöcke nebeneinander.
- **Symbole** (`Themes/Icons.xaml`, Schema `Icon.<Bereich>.<Name>`): Designsystem: `Icon.Lock`, `Icon.State.On`, `Icon.Status.Error`, `Icon.Status.Ok`, `Icon.Status.Warning`.
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-22-P01 | Aufbau | 2 Blöcke × 10 Zeilen mit SOLL und IST, 20 Wertepaare | offen |
| HM-22-P02 | Tasten | Gewichtsanpassung und Dosierer Auslösen manuell ohne Schlüsselsymbol; Schlüsselsymbol nur am Sollgewicht-Feld (Referenzbild, OP-25) | offen |
| HM-22-P03 | Sollgewicht | Feld mit Einheit g, 1 Nachkommastelle | offen |
| HM-22-P04 | Leere Felder | 0,00 g wird ignoriert | offen |
| HM-22-P05 | Zu wenige Punkte | Hinweis mit Symbol bei weniger als 3 Stützstellen | offen |
| HM-22-P06 | Seiten | HS-18 und HS-21 identisch | offen |
