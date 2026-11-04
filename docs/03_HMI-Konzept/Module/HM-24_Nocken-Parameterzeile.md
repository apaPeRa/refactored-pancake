# HM-24 – Nocken-Parameterzeile

## Funktion
Zeile zur Einstellung eines Nockenpunkts oder einer Nockenzeit: Beschriftung (Anfang, Ende, Dauer) und bis zu drei Felder nebeneinander (Winkel in °, Zeit in ms, Ergebnis in ° berechnet). Winkel und Zeit sind [HM-12](HM-12_Eingabefeld-Schluesselsymbol.md), das Ergebnis [HM-11](HM-11_Anzeigefeld.md). Mit den Zeiten werden Ansprechzeiten der Hardware kompensiert. Änderungen sind erst nach „Werte schreiben“ wirksam (HS-25); bis dahin zeigt die Zeile „nicht geschrieben“. Auf HS-16 (Kopfleim) trägt die Zeile nur Winkel bzw. Dauer.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Beschriftung (`Label`) | string | – | Anfang, Ende, Dauer |
| Winkel (`Angle`) | double? | ° | Bild 330, 790, 280, 325; Bereich nicht angegeben |
| Zeit (`Time`) | double? | ms | Bild 50 |
| Ergebnis (`Result`) | double? | ° | berechnet, nur Anzeige |
| Geber (`EncoderName`) | string? | – | z. B. „Geber 1GF Hauptantrieb“ |
| Nicht geschrieben (`IsPendingWrite`) | bool | – | – |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Normal | Felder HM-12 mit Schlüssel, Ergebnis HM-11 | Beschriftung und Einheiten |
| Nicht geschrieben | Felder wie HM-12 „Geändert“ | `Icon.State.Pending` und Text „Nicht geschrieben“ |
| Fehler | HM-12 Fehler | `Icon.Status.Error` und Text |

## Verwendet auf Seiten (IDs)
- [HS-16](../Seiten/HS-16_Schliessmaschine.md) – Schließmaschine
- [HS-25](../Seiten/HS-25_Nocken.md) – Nocken

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die Liste ist aus den Abschnitten „Verwendete Module“ und den Elemente-Tabellen der HS-Seiten abgeleitet (Stand Konsolidierung nach Phase 3, Punkt 4); „inkl. Verwendung über Kompositmodul“ nennt Seiten, auf denen das Modul nur innerhalb eines Kompositmoduls vorkommt.

## Herkunft
- [RM-20](../../02_Referenz-Analyse/Module/RM-20_Nocken-Parameterzeile.md) – Nocken-Parameterzeile: Zeile Anfang/Ende/Dauer mit Winkel, Zeit und Ergebnis
- Design: keine Entsprechung (Element nur in der Referenz).

## WPF-Umsetzung
- **Control:** `HM24_CamParameterRow` (UserControl), Ordner `src/.../Controls/`, Code-behind nur Dependency-Property-Deklarationen ohne Logik (Custom Control, A-73).
- **Typ:** `UserControl` (`HM24_CamParameterRow`), `Grid` mit Beschriftung und drei Spalten.
- **Dependency Properties:** `Label`, `Angle`, `Time`, `Result`, `EncoderName`, `IsPendingWrite`.
- **Symbole** (`Themes/Icons.xaml`, Schema `Icon.<Bereich>.<Name>`): Designsystem: `Icon.Status.Error`; neu, definiert in anderem Modul: `Icon.State.Pending` (HM-08).
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-24-P01 | Aufbau | Beschriftung plus Winkel, Zeit, Ergebnis (RS-25) | offen |
| HM-24-P02 | Kopfleim | Anfang 280 °, Ende 325 °, Dauer 50 ms (RS-16) | offen |
| HM-24-P03 | Ergebnis | schreibgeschützt (HM-11), ohne Schlüssel | offen |
| HM-24-P04 | Wirksamkeit | Zeile zeigt „nicht geschrieben“ bis zum Schreiben | offen |
| HM-24-P05 | Einheiten | ° und ms hinter dem Wert | offen |
