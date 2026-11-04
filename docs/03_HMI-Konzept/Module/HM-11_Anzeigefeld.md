# HM-11 – Anzeigefeld (Wert-Zeile)

## Funktion
Schreibgeschützte Anzeige eines Werts mit Beschriftung: Messwert, Berechnetes, Statustext, Datum/Uhrzeit, Zeitdauer. Darstellung als Parameter: **Feld** (Fläche mit Kontur, Wert rechtsbündig) oder **Zeile** (reiner Text ohne Fläche, Beschriftung links, Wert rechts). Optional mit Einheit, kleinem Zähler (z. B. Mittelwert mit Stückzahl), Symbol und Rücksetzfunktion (Maximalwerte in HS-39). Einheitliche Schreibweise: Wert, geschütztes Leerzeichen, Einheit. Eingabefelder: [HM-12](HM-12_Eingabefeld-Schluesselsymbol.md).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
Wertebereiche und Standardwerte fehlen in der Quelle (OP-28); angegeben sind UI-technische Grenzen und Beispielwerte aus den Bildern (A-50). Die Eigenschaftsnamen sind die Dependency Properties des Controls.

| Name (Eigenschaft) | C#-Typ | Einheit | Wertebereich |
|---|---|---|---|
| Beschriftung (`Label`) | string | – | z. B. Aktueller Druck, Maschinenwinkel, Soll, Regulierwert, Aktuelle Produktion |
| Wertart (`ValueKind`) | enum ValueKind { Number, Text, DateTime, Duration } | – | – |
| Zahlenwert (`NumberValue`) | double? | Einheit | z. B. 150 °C, 0,7 bar, 113 g, 48 %, −398,9 g |
| Textwert (`TextValue`) | string? | – | z. B. „IO“, „Bereit“, „Läuft“ |
| Zeitwert (`TimeValue`) | DateTime? / TimeSpan? | TT.MM.JJJJ hh:mm:ss / hhh:mm:ss | Platzhalter „--.--.---- --:--:--“ bei leer |
| Einheit (`Unit`) | string | – | °C, bar, g, %, °, s, h/m/s, Stk, 1/min |
| Nachkommastellen (`Decimals`) | int | – | 0 bis 3 |
| Darstellung (`Presentation`) | enum ValuePresentation { Field, Row } | – | Field Standard |
| Zusatztext (`Suffix`) | string? | – | z. B. „entspricht“ |
| Zähler (`Counter`) | int? | Stk | 0 bis 99999 |
| Rücksetzbar (`ResetCommand`) | ICommand? | – | null = nicht rücksetzbar |
| Größe (`Emphasis`) | enum ValueEmphasis { Normal, Large } | – | Large für große Gewichtsanzeige |

## Zustände und Darstellung
Zustände nie nur über Farbe: jede Zeile nennt den zweiten Kanal (Symbol, Text, Form, Kontur). Tokens aus [Designsystem](../Designsystem.md).

| Zustand | Darstellung (Tokens) | Zweiter Kanal |
|---|---|---|
| Normal (Feld) | `Brush.Surface`, Kontur `Border.Thin`, Wert `Font.Size.Value` `Font.Weight.Strong` `Brush.Text.Primary`, Einheit `Brush.Text.Secondary`, Höhe `Size.Field.Height` | Beschriftung und Einheit als Text |
| Zeile | ohne Fläche, Wert `Font.Size.Body` | Beschriftung links, Wert rechts |
| Statuswert (Text) | wie Normal, optional Symbol des Status | Zustandswort „IO“, „Bereit“, „Läuft“ |
| Grenzwert verletzt | Fläche `Brush.Status.Warning.Subtle`, Kontur `Border.Medium` `Brush.Status.Warning.Fg` | `Icon.Status.Warning` und Text |
| Wert ungültig | wie Normal | Text „---“ |
| Rücksetzbar | wie Normal, Kontur `Border.Medium` beim Drücken | `Icon.Action.Reset` rechts im Feld |
| Mit Zähler | Zähler `Font.Size.Caption` unten rechts | Zahl als Text |

## Verwendet auf Seiten (IDs)
- [HS-01](../Seiten/HS-01_Produktion.md) – Produktion
- [HS-02](../Seiten/HS-02_Produktionszaehler.md) – Produktionszähler (Pop-up) (inkl. Verwendung über Kompositmodul HM-33)
- [HS-05](../Seiten/HS-05_Zufuehrung-Papier.md) – Zuführung Papier
- [HS-06](../Seiten/HS-06_Zufuehrung-Karton.md) – Zuführung Karton
- [HS-07](../Seiten/HS-07_Heissleim-Nordson.md) – Heißleim Nordson
- [HS-08](../Seiten/HS-08_Heissleim-Parameter.md) – Heißleim Parameter
- [HS-09](../Seiten/HS-09_Heissleim-Druck.md) – Heißleim Druck
- [HS-11](../Seiten/HS-11_Hauptdosierer-1-und-2.md) – Hauptdosierer 1 & 2 (inkl. Verwendung über Kompositmodul HM-20)
- [HS-16](../Seiten/HS-16_Schliessmaschine.md) – Schließmaschine (inkl. Verwendung über Kompositmodul HM-24)
- [HS-19](../Seiten/HS-19_Nachdosierer.md) – Nachdosierer (inkl. Verwendung über Kompositmodul HM-20)
- [HS-22](../Seiten/HS-22_Heizungen.md) – Heizungen
- [HS-23](../Seiten/HS-23_Regulierung.md) – Regulierung
- [HS-25](../Seiten/HS-25_Nocken.md) – Nocken
- [HS-27](../Seiten/HS-27_Waagen-Kalibrieren.md) – Waagen Kalibrieren
- [HS-31](../Seiten/HS-31_Handbetrieb.md) – Handbetrieb
- [HS-32](../Seiten/HS-32_Geber-setzen.md) – Geber setzen
- [HS-34](../Seiten/HS-34_EA-Anzeige.md) – EA-Anzeige
- [HS-36](../Seiten/HS-36_Service.md) – Service
- [HS-39](../Seiten/HS-39_System-und-Antriebsinfos.md) – System- und Antriebsinfos
- [HS-41](../Seiten/HS-41_Dosierer-Uebersicht.md) – Dosierer-Übersicht

Die HS-IDs entsprechen den RS-Nummern 1:1 (A-46). Die HS-Dateien entstehen in Phase 3 (Punkt 4); die Links sind vorläufig.

## Herkunft
- [DM-15](../../01_Design-Analyse/Module/DM-15_Beschriftung-Wert-Zeile.md) – Beschriftung-Wert-Zeile: Beschriftung-Wert-Zeile als reiner Text
- [DM-16](../../01_Design-Analyse/Module/DM-16_Wertfeld-Anzeige.md) – Wertfeld (Anzeige): weißes Wertfeld mit Messwert
- [RM-07](../../02_Referenz-Analyse/Module/RM-07_Anzeigefeld.md) – Anzeigefeld: schreibgeschütztes Anzeigefeld mit Varianten

## WPF-Umsetzung
- **Control:** `HM11_ValueDisplay` (UserControl), Ordner `src/.../Controls/`, kein Code-behind außer `InitializeComponent`.
- **Typ:** `UserControl` (`HM11_ValueDisplay`); Zeile und Feld per `Style`-Trigger auf `Presentation`.
- **Dependency Properties:** `Label`, `ValueKind`, `NumberValue`, `TextValue`, `TimeValue`, `Unit`, `Decimals`, `Presentation`, `Suffix`, `Counter`, `Emphasis`; **Command:** `ResetCommand`.
- **Formatierung:** `IValueConverter` für Zahl + Einheit mit `CurrentCulture` und geschütztem Leerzeichen.
- **Symbole** (`Themes/Icons.xaml`, Schema `Icon.<Bereich>.<Name>`): Designsystem: `Icon.Status.Warning`; **neu, hier definiert:** `Icon.Action.Reset`.
- **Namensschema:** Controls heißen nach der HM-ID (A-56).
- **Texte:** Beschriftungen, Statuswörter und `AutomationProperties.Name` aus `.resx` (Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`); keine Hex-, Pixel- oder Literaltexte im XAML.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-11-P01 | DS-03 | 4 Felder: Tank 150 °C, Verteiler 150 °C, Pistole 1 170 °C, Schlauch 1 160 °C | offen |
| HM-11-P02 | DS-01 Versorgung | Druckluft, Papier, Produkt „IO“, Bandwaage „Bereit“, Folgemaschine „Läuft“ als Zeilen | offen |
| HM-11-P03 | Format | Zahl, geschütztes Leerzeichen, Einheit | offen |
| HM-11-P04 | Keine Eingabe | kein Schlüsselsymbol, nicht änderbar | offen |
| HM-11-P05 | Ungültig | Text „---“ statt leerem Feld | offen |
| HM-11-P06 | Rücksetzbar | Antippen setzt Maximalwert zurück (HS-39) | offen |
