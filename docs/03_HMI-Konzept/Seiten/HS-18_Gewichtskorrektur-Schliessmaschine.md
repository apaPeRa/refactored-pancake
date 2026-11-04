# HS-18 – Gewichtskorrektur (Schließmaschine)
- Quelle: Referenz [RS-18](../../02_Referenz-Analyse/Seiten/RS-18_Gewichtskorrektur-Schliessmaschine.md) (keine Handbuchtabellen; Anleitung mit vier Schritten, vier Hinweise; Bild [RS-18_01](../../02_Referenz-Analyse/Medien/RS-18_01.png), identisch mit RS-21_01). Design: keine Design-Seite; Aufbau aus [Designsystem](../Designsystem.md) und [HM-22](../Module/HM-22_Gewichtskorrektur-Tabelle.md); gleicher Aufbau wie [HS-21](../Seiten/HS-21_Gewichtskorrektur.md).
- Navigationspfad: **Einstellung › Schließmaschine › Gewichtskorrektur** (Brotkrümel laut [Navigation.md](../Navigation.md), Abschnitt 2). Zugang: [HS-16](HS-16_Schliessmaschine.md) Funktionsleiste „Gewichtskorrektur“ (Annahme A-37, Lücke 6.2). Zurück-Ziel: HS-16. PageKey `ClosingWeightCorrection`, Route `settings/closing/weightcorrection`, Mindestrolle „–“.

## Zweck
Korrektur und Feinabstimmung der Dosiergenauigkeit. Wortgetreu (RS-18): „Diese Seite dient der Korrektur und Feinabstimmung der Dosiergenauigkeit von Schneckendosierern. Durch die Eingabe mehrerer Soll-Ist-Wertepaare werden sogenannte Stützstellen definiert. Daraus berechnet die Steuerung eine Korrekturkurve, mit der die Dosierleistung über den gesamten Gewichtsbereich verbessert wird.“ Inhaltlich identisch mit RS-21; der Bezug zur Schließmaschine bleibt fachlich offen (OP-45, OP-55).

## Aufbau (Bereiche, Layout)
Inhaltsbereich des Rahmen-Grids (Zeile 34\* von 45\*, Außenrand `Space.L`, 12-Spalten-Raster, Gutter `Space.M`). Zwei Bereiche, beide Teil von [HM-22](../Module/HM-22_Gewichtskorrektur-Tabelle.md):

- **Links, Spalten 8 von 12: Stützstellen.** Zwei gleich breite Blöcke nebeneinander (je 4 Spalten); jeder Block hat die Spaltenköpfe „SOLL“ und „IST“ (`Font.Weight.Strong`) und zehn Zeilen aus je zwei Zahlenfeldern (Einheit g, zwei Nachkommastellen, ohne Schlüsselsymbol). Zeilenhöhe `Size.Touch.Min`, Zeilenabstand `Size.Touch.Gap`; Summe 20 Wertepaare (2 × 10).
- **Rechts, Spalten 4 von 12: Ablauf Dosierkorrektur** (Gruppenbereich [HM-15](../Module/HM-15_Gruppenbereich.md)). Von oben nach unten nach dem Bedienablauf des Handbuchs: Schritt 1 Sollgewicht, Schritt 2 „Dosierer Auslösen manuell“, Schritt 3 Verweis „Soll links, gemessenes Ist daneben eintragen“, Schritt 4 „Gewichtsanpassung“; darunter die Ergebniszeile (Zustand der Berechnung) und die Hinweise zur optimalen Nutzung in der Restfläche.

```
Inhaltsbereich (12 Spalten)
+---------------------------------------------+-----------------------+
| Stützstellen (8)                            | Ablauf            (4) |
| +------------------+ +--------------------+ | 1 Sollgewicht:        |
| | SOLL     IST     | | SOLL      IST      | | [ 250,4 g       K ]   |
| | [18,00] [20,00]  | | [0,00]   [0,00]    | | 2 [Dosierer Auslösen  |
| | [22,00] [24,00]  | | [0,00]   [0,00]    | |    manuell      K ]   |
| | [ 0,00] [ 0,00]  | |  ...               | | 3 Soll links, Ist     |
| |  ... (10 Zeilen) | |  ... (10 Zeilen)   | |   rechts eintragen    |
| +------------------+ +--------------------+ | 4 [Gewichtsanpassung  |
|                                             |        K ]            |
|                                             | Ergebnis: Zustand     |
|                                             | Hinweise (4)          |
+---------------------------------------------+-----------------------+
Funktionsleiste: leer (sichtbar)
K = Schlüsselsymbol (Icon.Key)
```

Höhenkontrolle bei 1920 × 1080: Innenrand `Space.M`, Spaltenkopf (`Font.Size.Body`), 10 Zeilen à `Size.Touch.Min` mit 9 Abständen `Size.Touch.Gap` ergeben zusammen weniger als die Inhaltshöhe von 768 px; ein Scrollen der Tabelle entfällt. Die rechte Spalte nutzt die Restfläche für die Hinweise (Hinweis-Textfeld nimmt die Stern-Resthöhe).

Abweichungen zum Bild: Im Referenzbild liegen die beiden Tasten oben rechts und das Sollgewicht darunter (rechts unten). Das neue Layout stellt das Sollgewicht an den Anfang des Ablaufs (Schritt 1 des Handbuchs) und ordnet Tasten und Feld in der Reihenfolge der vier Schritte an (OP-34: Handbuch „rechts unten“, Bild darunter). Die Inhalte bleiben unverändert. Die Funktionsleiste bleibt leer, aber sichtbar (Navigation.md Abschnitt 3.3, „Ohne eigene Tasten“; Referenz hat links keine Taste).

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Spalte „Herkunft“ = Rückverfolgung auf [RS-18](../../02_Referenz-Analyse/Seiten/RS-18_Gewichtskorrektur-Schliessmaschine.md). Das Handbuch enthält keine Tabellen für diese Seite; Funktionen stammen aus Anleitung und Hinweisen (zitiert wie in RS-18). Wertebereiche und Standardwerte fehlen (OP-28).

| Nr. | Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-18) |
|---|---|---|---|---|---|
| E01 | Sollgewicht (Bild 250,4 g) | Eingabefeld, Zahl, Einheit g, eine Nachkommastelle, mit Schlüsselsymbol | „Geben Sie rechts unten das gewünschte Zielgewicht ein (Sollgewicht). Dieses Gewicht wird bei der manuellen Dosierung verwendet.“ (Schritt 1; im neuen Layout am Anfang des Ablaufs, nicht „rechts unten“) | [HM-22](../Module/HM-22_Gewichtskorrektur-Tabelle.md) mit [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), Pop-up [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | Elemente: Zeile „Sollgewicht“; Ablauf Schritt 1 |
| E02 | Taste „Dosierer Auslösen manuell“ | Aktionstaste (Antippen), mit Schlüsselsymbol | „… um eine Probe mit dem eingestellten Sollgewicht zu dosieren. Die Probe in einem Behälter auffangen und wiegen.“ (Schritt 2) | [HM-22](../Module/HM-22_Gewichtskorrektur-Tabelle.md) mit [HM-07](../Module/HM-07_Aktionstaste.md) | Elemente: Zeile Taste „Dosierer Auslösen manuell“; Ablauf Schritt 2 |
| E03 | Block links: SOLL und IST, 10 Zeilen | Wertetabelle, 20 Zahlenfelder (10 Paare), Einheit g, zwei Nachkommastellen, ohne Schlüsselsymbol; Bild: 18,00/20,00 und 22,00/24,00, übrige 0,00 | Eingabe der Stützstellen: „Tragen Sie das verwendete Sollgewicht in die linke Spalte (SOLL) ein … und das gemessene tatsächliche Gewicht in die rechte Spalte (IST).“ (Schritt 3) | [HM-22](../Module/HM-22_Gewichtskorrektur-Tabelle.md) mit [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) | Elemente: Zeilen „Spalte SOLL“ und „Spalte IST“ (linke Tabelle); Bild: linke Tabelle |
| E04 | Block rechts: SOLL und IST, 10 Zeilen | Wertetabelle, 20 Zahlenfelder (10 Paare), Einheit g, zwei Nachkommastellen, ohne Schlüsselsymbol; Bild: alle 0,00 | wie E03: „Wiederholen Sie diesen Vorgang für mehrere Gewichte über den typischen Arbeitsbereich des Dosierers hinweg.“ | [HM-22](../Module/HM-22_Gewichtskorrektur-Tabelle.md) mit [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) | Elemente: Zeilen „Spalte SOLL“ und „Spalte IST“ (rechte Tabelle); Bild: rechte Tabelle |
| E05 | Zeilenmarke gefüllt/leer | Symbol `Icon.State.On` in gefüllten Zeilen, leere Zeilen in `Brush.Text.Secondary` | macht sichtbar, welche Paare in die Berechnung eingehen: „leere Felder bleiben unberücksichtigt“ (0,00 g gilt als leer) | [HM-22](../Module/HM-22_Gewichtskorrektur-Tabelle.md) (Zustände Leer/Gefüllt) | Zustände: Leere Felder; Hinweis 3 |
| E06 | Taste „Gewichtsanpassung“ | Aktionstaste (Antippen), mit Schlüsselsymbol | „… drücken Sie die Taste Gewichtsanpassung. Die Steuerung erstellt daraus eine Korrekturkennlinie, mit der das Dosierergebnis automatisch an das tatsächliche Verhalten des Systems angepasst wird.“ (Schritt 4) | [HM-22](../Module/HM-22_Gewichtskorrektur-Tabelle.md) mit [HM-07](../Module/HM-07_Aktionstaste.md) | Elemente: Zeile Taste „Gewichtsanpassung“; Ablauf Schritt 4 |
| E07 | Ablaufhinweise Schritt 1 bis 4 | Beschriftung mit Schrittnummer (Text, kein Bedienelement) | gibt die vier Schritte des Bedienablaufs wieder: 1 Dosiergewicht einstellen, 2 Manuelle Auslösung des Dosierers, 3 Wert eintragen, 4 Gewichtsanpassung berechnen | [HM-15](../Module/HM-15_Gruppenbereich.md) (Gruppe „Ablauf“) | Bedienablauf (4 Schritte) |
| E08 | Ergebniszeile | Statusanzeige mit Symbol und Text (Zustände Leer, zu wenige Stützstellen, ungültiges Paar, berechnet) | zeigt Rückmeldung der Gewichtsanpassung bzw. Prüfung der Stützstellen (im Handbuch nicht beschrieben, Modulannahme HM-22) | [HM-22](../Module/HM-22_Gewichtskorrektur-Tabelle.md) | Zustände: Rückmeldung/Fehlermeldung „nicht beschrieben“ |
| E09 | Hinweis 1 | Hinweis-Textfeld, Art Info | „Es sollten mindestens drei, besser fünf bis acht Stützstellen gleichmäßig über den gesamten Gewichtsbereich verteilt eingetragen werden.“ | [HM-27](../Module/HM-27_Hinweis-Textfeld.md) | Hinweise zur optimalen Nutzung, Punkt 1 |
| E10 | Hinweis 2 | Hinweis-Textfeld, Art Info | „Die Werte sollten unter reproduzierbaren Bedingungen aufgenommen werden (z. B. gleiche Produkttemperatur, gleiche Füllhöhe).“ | [HM-27](../Module/HM-27_Hinweis-Textfeld.md) | Hinweise, Punkt 2 |
| E11 | Hinweis 3 | Hinweis-Textfeld, Art Info | „Tragen Sie nur gültige Messwerte ein – leere Felder bleiben unberücksichtigt.“ | [HM-27](../Module/HM-27_Hinweis-Textfeld.md) | Hinweise, Punkt 3 |
| E12 | Hinweis 4 | Hinweis-Textfeld, Art Info | „Diese Korrektur ist insbesondere bei nichtlinearer Dosiercharakteristik hilfreich (z. B. bei fein rieselnden oder klebrigen Produkten).“ | [HM-27](../Module/HM-27_Hinweis-Textfeld.md) | Hinweise, Punkt 4 |

Die vier Hinweise E09 bis E12 stehen untereinander in einem Hinweis-Textfeld (eine Instanz je Aufzählungspunkt oder eine Instanz mit vier Punkten, Wortlaut unverändert).

### Rahmenelemente (aus dem Rahmen-Grid, nicht seitenspezifisch)
| Nr. | Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-18) |
|---|---|---|---|---|---|
| R01 | Logo, Uhrzeit 13:03:35, Datum 12.05.2025 | Anzeige | Kopfzeile (Dummy-Daten) | [HM-02](../Module/HM-02_Kopfzeile.md) | Rahmenelemente: Kopfzeile |
| R02 | Seitentitel „Gewichtskorrektur“ | Anzeige | letztes Brotkrümel-Segment „Einstellung › Schließmaschine › Gewichtskorrektur“; „Einstellung“ und „Schließmaschine“ antippbar | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | Bild: Titel |
| R03 | Rundes Wirbelsymbol | – | entfällt als eigenes Element (OP-26) | [HM-02](../Module/HM-02_Kopfzeile.md) | Bild: Wirbelsymbol |
| R04 | Meldezeile „\*450\* Palettierung nicht bereit“ | Anzeige, Statusfarbe mit Symbol und Schweregradwort | zeigt die anstehende Meldung („450: Palettierung nicht bereit“, Dummy); Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | Rahmenelemente: Meldezeile |
| R05 | Schloss-Symbol | Anzeige/Bedienung | Seitenleiste: Benutzerkennung mit `Icon.Key`/`Icon.Lock`, Benutzer-Pop-up | [HM-01](../Module/HM-01_Seitenleiste.md) | Rahmenelemente: Schloss-Symbol |
| R06 | Tasten „Produktion“, „Einstellungen“, „Zurück“ | Navigation | Seitenleiste: „Home“ → HS-01, „Einstellungen“ → HS-04 (hervorgehoben), „Zurück“ → Verlauf (HS-16) | [HM-01](../Module/HM-01_Seitenleiste.md) | Rahmenelemente: Tasten „Produktion“, „Einstellungen“, „Zurück“ |
| R07 | Funktionsleiste ohne Taste (links keine Taste) | Leiste | leer, aber sichtbar | [HM-06](../Module/HM-06_Funktionsleiste.md) | Bild: „links keine Taste“ |
| R08 | Kennzahlen Geschwindigkeit und Maschinenwinkel | Anzeige | Rahmen des Designs, in der Referenz nicht vorhanden | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | Design-Rahmen |

## Verwendete Module (IDs)
- [HM-01](../Module/HM-01_Seitenleiste.md) – Seitenleiste
- [HM-02](../Module/HM-02_Kopfzeile.md) – Kopfzeile
- [HM-03](../Module/HM-03_Meldezeile.md) – Meldezeile
- [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) – Brotkrümel-Navigation
- [HM-05](../Module/HM-05_Kennzahl-Kachel.md) – Kennzahl-Kachel
- [HM-06](../Module/HM-06_Funktionsleiste.md) – Funktionsleiste unten (leer)
- [HM-07](../Module/HM-07_Aktionstaste.md) – Aktionstaste (in HM-22)
- [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) – Eingabefeld mit Schlüsselsymbol (in HM-22)
- [HM-13](../Module/HM-13_Eingabe-Pop-up.md) – Eingabe-Pop-up
- [HM-14](../Module/HM-14_Popup-Rahmen.md) – Pop-up-Rahmen (trägt HM-13)
- [HM-15](../Module/HM-15_Gruppenbereich.md) – Gruppenbereich
- [HM-22](../Module/HM-22_Gewichtskorrektur-Tabelle.md) – Gewichtskorrektur-Tabelle
- [HM-27](../Module/HM-27_Hinweis-Textfeld.md) – Hinweis-Textfeld

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
**Bedienablauf (Handbuch, vier Schritte, in dieser Reihenfolge).** (1) Sollgewicht einstellen; (2) „Dosierer Auslösen manuell“ drücken, Probe dosieren, auffangen, wiegen; (3) Soll (verwendetes Sollgewicht) links und Ist (gemessenes Gewicht) daneben eintragen, für mehrere Gewichte über den Arbeitsbereich; (4) „Gewichtsanpassung“ drücken. Die Schritte sind nicht erzwungen: alle Elemente sind jederzeit bedienbar, die Reihenfolge ist nur Anleitung (Handbuch beschreibt keine Sperrlogik).

**Eingabe.** Antippen eines Felds (E01, E03, E04) öffnet das Eingabe-Pop-up (HM-13 in HM-14) mit vorbelegtem Wert, Einheit g und Grenzen; „Übernehmen“ nur bei gültigem Wert, „Abbrechen“ verwirft, Antippen außerhalb schließt nicht. Ungültiger Wert: `Icon.Status.Error` und Text; Grenzen Dummy (OP-28). Stützstellenfelder tragen kein Schlüsselsymbol (Bild); ihre Bedienung ist damit nicht berechtigungspflichtig (Annahme, OP-25).

**Leere und ungültige Zeilen.** Ein Wertepaar mit 0,00 g in beiden Feldern gilt als leer und bleibt bei der Berechnung unberücksichtigt (Hinweis 3, RS-18). Nur Soll oder nur Ist gefüllt: Zeile im Zustand „Ungültiges Paar“ (`Brush.Status.Error.Subtle`, `Icon.Status.Error`, Text „Soll und Ist erforderlich“, Modulannahme HM-22); dieses Paar wird nicht berechnet.

**„Gewichtsanpassung“ (E06).** Zustände der Ergebniszeile E08 (HM-22): *Zu wenige Stützstellen* (weniger als drei gültige Paare): Warnfläche mit `Icon.Status.Warning` und Text „Mindestens 3 Stützstellen“, die Steuerung erhält keinen Berechnungsauftrag (Annahme); *Ungültig*: Fehler wie oben; *Berechnet*: `Icon.Status.Ok` und Text „Kennlinie berechnet“. Empfehlung „besser fünf bis acht“ steht nur als Hinweis E09. Ob die Anpassung eine bestehende Korrektur ersetzt oder zurücksetzt und wie die Korrektur deaktiviert wird, ist offen (OP-45); es gibt dafür keine Bedienung auf der Seite. Eine Rückfrage vor der Berechnung ist nicht vorgesehen (Navigation.md 4.1 nennt keine; OP-31).

**„Dosierer Auslösen manuell“ (E02).** Antippen löst eine einzelne Dosierung mit dem eingestellten Sollgewicht aus; die Probe wird außerhalb der Seite aufgefangen und gewogen. Ist die Maschine in einem Zustand, in dem manuelles Dosieren nicht zulässig ist (Dummy, OP-31), ist die Taste deaktiviert (gestrichelte Kontur, `Brush.Text.Disabled`, `Icon.Block`); Tippen nennt den Grund in der Meldezeile (A-28). Während der Auslösung zeigt die Taste kurz den Zustand „Läuft“ mit `Icon.State.On` und Wort (Auslösung Antippen, nicht Halten; Dauer Dummy).

**Berechtigungen.** Schlüsselsymbole (`Icon.Key`, `Brush.Text.Primary`) an E01, E02, E06 (Sollgewicht und beide Tasten; Tasten nach HM-22-P02, im Bild ohne Schlüssel, Annahme). Ohne Rolle: `Icon.Lock`, kein Pop-up, Meldezeile „Berechtigung erforderlich: <Rolle>“, Benutzer-Pop-up zur Anmeldung (Navigation.md 4.1). Rollen sind Dummy (OP-04, OP-25).

**Navigation und Zurück.** Keine seitenspezifischen Tasten; „Zurück“ führt im Verlauf zu HS-16; Brotkrümel-Segmente „Einstellung“ (HS-04) und „Schließmaschine“ (HS-16) antippbar, der Verlauf wird gekürzt. Die Seitenleisten-Taste „Einstellungen“ ist hervorgehoben. Bei offenem Pop-up sind Seitenleiste, Brotkrümel und Seiteninhalt gesperrt.

**Fehlerfälle.** Wertebereichsverletzung; ungültige oder zu wenige Stützstellen (oben); Meldungen der Steuerung (Meldezeile). Eine Rückmeldung nach „Gewichtsanpassung“ ist im Handbuch nicht beschrieben; die Ergebniszeile ist eine Modulannahme.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-18-P01 | Titel und Pfad (RS-18-P01) | Brotkrümel „Einstellung › Schließmaschine › Gewichtskorrektur“; „Einstellung“ und „Schließmaschine“ antippbar | offen |
| HS-18-P02 | Stützstellentabelle (RS-18-P02) | zwei Blöcke mit je Spalten SOLL und IST und je 10 Zeilen (20 Wertepaare, 40 Felder), Einheit g, zwei Nachkommastellen | offen |
| HS-18-P03 | Sollgewicht (RS-18-P03) | Feld „Sollgewicht:“ mit Schlüsselsymbol, Einheit g (Beispiel 250,4 g), eine Nachkommastelle; Gewicht für die manuelle Dosierung | offen |
| HS-18-P04 | Taste „Dosierer Auslösen manuell“ (RS-18-P04) | dosiert eine Probe mit dem eingestellten Sollgewicht; nur bei zulässigem Betriebszustand bedienbar, sonst deaktiviert mit Grund in der Meldezeile | offen |
| HS-18-P05 | Taste „Gewichtsanpassung“ (RS-18-P05) | erstellt aus den Stützstellen eine Korrekturkennlinie; Ergebniszeile „Kennlinie berechnet“ mit `Icon.Status.Ok` | offen |
| HS-18-P06 | Leere Felder (RS-18-P06) | Paare mit 0,00 g werden nicht berücksichtigt (Zeile ohne Haken); gültige Paare zeigen `Icon.State.On` | offen |
| HS-18-P07 | Hinweise (RS-18-P07) | alle vier Hinweise im Wortlaut vorhanden (mind. 3, besser 5 bis 8 Stützstellen; reproduzierbare Bedingungen; nur gültige Messwerte; nichtlineare Dosiercharakteristik) | offen |
| HS-18-P08 | Bedienablauf (RS-18-P08) | vier Schritte in der Reihenfolge Sollgewicht, manuell auslösen, Werte eintragen, Gewichtsanpassung; Anordnung von oben nach unten in dieser Reihenfolge | offen |
| HS-18-P09 | Beispielwerte (RS-18-P09) | Paar 1: 18,00 g / 20,00 g; Paar 2: 22,00 g / 24,00 g; alle übrigen Felder 0,00 g; Sollgewicht 250,4 g | offen |
| HS-18-P10 | Untere Leiste und Rahmentasten (RS-18-P10) | Funktionsleiste leer, aber sichtbar (keine Taste links); Schloss/Benutzerkennung, „Produktion“, „Einstellungen“, „Zurück“ in der Seitenleiste | offen |
| HS-18-P11 | Bildabgleich (RS-18-P11) | jedes Element des Bildes [RS-18_01](../../02_Referenz-Analyse/Medien/RS-18_01.png) ist in der Elementtabelle (E01 bis E12, R01 bis R08) wiederzufinden | offen |
| HS-18-P12 | Zu wenige Stützstellen | bei weniger als drei gültigen Paaren zeigt E08 `Icon.Status.Warning` und Text „Mindestens 3 Stützstellen“; keine Berechnung | offen |
| HS-18-P13 | Ungültiges Paar | nur Soll oder nur Ist gefüllt: Zeile mit `Icon.Status.Error` und Text, nicht nur rote Fläche | offen |
| HS-18-P14 | Schlüsselsymbole | Schlüsselsymbol an Sollgewicht und beiden Tasten; Stützstellenfelder ohne Schlüsselsymbol (wie Bild) | offen |
| HS-18-P15 | Touch-Ziele | Tabellenzeilen ≥ `Size.Touch.Min`, Felder und Tasten außerhalb der Tabelle ≥ `Size.Touch.Default` hoch, Abstände ≥ `Size.Touch.Gap` | offen |
| HS-18-P16 | Zweiter Kanal | Zustände Leer, Warnung, Fehler, Berechnet, Deaktiviert durch Symbol, Text bzw. gestrichelte Kontur erkennbar; Werte nicht rot | offen |
| HS-18-P17 | Tokens | keine Hex- oder Pixelwerte; nur Tokens; Tabelle und Tasten aus HM-22, HM-12, HM-07 (keine Kopien) | offen |
| HS-18-P18 | Berechtigung | ohne Rolle: `Icon.Lock`, kein Eingabe-Pop-up, Hinweis „Berechtigung erforderlich: <Rolle>“ | offen |
| HS-18-P19 | Layout ohne Scrollen | Tabelle mit 10 Zeilen und Spaltenkopf sowie die rechte Spalte passen bei 1920 × 1080 in 768 px Inhaltshöhe ohne Scrollen der Tabelle | offen |
| HS-18-P20 | Zurück | „Zurück“ führt im Verlauf zu HS-16; bei offenem Pop-up gesperrt | offen |
| HS-18-P21 | Identität mit HS-21 | identischer Aufbau (HM-22-P06) | offen |
| HS-18-P22 | Texte | alle sichtbaren Texte aus `.resx` | offen |

## Offene Punkte
Seiten-Index der [Offene-Punkte.md](../../00_Plan/Offene-Punkte.md) für RS-18: OP-23, OP-25, OP-28, OP-30, OP-31, OP-39, OP-45, OP-55.
- **OP-23:** Elternseite im Handbuch nicht beschrieben; Annahme A-37 (Taste „Gewichtskorrektur“ in HS-16).
- **OP-25:** Bedeutung und Stufe der Schlüsselsymbole; Schlüssel nur am Sollgewicht im Bild, Tasten laut HM-22 mit Schlüssel.
- **OP-28:** Wertebereiche und Standardwerte (Gewichte in g) fehlen; Dummy-Grenzen.
- **OP-30:** Eingabe-Pop-up der Referenz undokumentiert; HM-13 als Annahme.
- **OP-31:** Rückfragen und Sperrzustände (Gewichtsanpassung, manuelle Auslösung) nicht beschrieben.
- **OP-39:** Fehlende Zustände (Rückmeldung nach Gewichtsanpassung, Aus-/Sperrzustände) im Bild nicht gezeigt.
- **OP-45:** Fachliche Zusammenhänge unklar: „Schneckendosierer“ bei der Schließmaschine, Ersetzen/Zurücksetzen einer bestehenden Korrektur, Deaktivieren der Korrektur.
- **OP-55:** RS-18 und RS-21 nutzen dasselbe Bild; Seite als eigene Seite geführt. Klärt sich eine Dublette, entfällt HS-18 samt Taste in HS-16 (A-37).
