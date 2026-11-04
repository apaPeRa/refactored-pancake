# HS-16 – Schließmaschine
- Quelle: Referenz [RS-16](../../02_Referenz-Analyse/Seiten/RS-16_Schliessmaschine.md) (Handbuchtabellen T22, T23, T24; Bild [RS-16_01](../../02_Referenz-Analyse/Medien/RS-16_01.png)). Design: keine eigene Design-Seite; die Kachel „Schließmaschine“ steht in [DS-02](../../01_Design-Analyse/Seiten/DS-02_Einstellungen.md) (Ziel nicht abgebildet). Aufbau abgeleitet aus [Designsystem](../Designsystem.md) (Abschnitt 3.3, Muster DS-02 „3 Gruppen 4 : 4 : 4“) und den Modulen HM.
- Navigationspfad: **Einstellung › Schließmaschine** (Brotkrümel laut [Navigation.md](../Navigation.md), Abschnitt 2). Zugang: [HS-04](../Seiten/HS-04_Einstellungen.md) Kachel „Schließmaschine“. Zurück-Ziel: HS-04 (Verlauf). PageKey `ClosingMachine`, Route `settings/closing`, Mindestrolle „–“ (Seitenregister).

## Zweck
Einstellungen für das **Auslaufband** (Sollgeschwindigkeit), den **Kopfleim** (Ein/Aus, Nockenbeginn, Nockenende, Einschaltdauer des Ventils) und die **Rüttlung** (Ein/Aus, Intensität der Rüttlungen 1 und 2). Wortgetreu (RS-16): „Auf der Seite Schließmaschine sind die Einstellungen für das Auslaufband, den Kopfleim und der Rüttlung zu finden.“

Die Seite ist außerdem Elternseite von [HS-17](HS-17_Motorparameter-Schliessmaschine.md) (Motorparameter) und [HS-18](HS-18_Gewichtskorrektur-Schliessmaschine.md) (Gewichtskorrektur) und hat einen zweiten Zugang zu [HS-07](HS-07_Heissleim-Nordson.md) (Taste „Heißleimgerät“) (Annahme A-37 in [Annahmen.md](../../00_Plan/Annahmen.md)).

## Aufbau (Bereiche, Layout)
Die Seite liegt im Inhaltsbereich des Rahmen-Grids (Zeile 34\* von 45\*, Außenrand `Size.Content.Margin`, 12-Spalten-Raster, Gutter `Space.M`, [Designsystem](../Designsystem.md) Abschnitt 3.2/3.3). Rahmen (HM-01 bis HM-06) siehe Abschnitt „Rahmenelemente“.

**Inhaltsbereich:** eine Zeile (Stern-Höhe), drei Gruppenbereiche in den Spalten **4 : 4 : 4**, in der Reihenfolge des Referenzbilds von links nach rechts: **Auslaufband | Kopfleim | Rüttlung**. Die Gruppe „Auslaufband“ nimmt nur ihre Inhaltshöhe ein und ist oben bündig (Restfläche bleibt leer, wie im Referenzbild). Die Gruppen „Kopfleim“ und „Rüttlung“ haben Inhaltshöhe (Mindesthöhe: alle Zeilen ohne Scrollen).

```
Inhaltsbereich (12 Spalten)
+----------------------+----------------------+----------------------+
| Auslaufband      (4) | Kopfleim         (4) | Rüttlung         (4) |
| Geschwindigkeit:     | [Kopfleim   Ein/Aus] | [Rüttlung   Ein/Aus] |
| [ 50 %           K ] | [Düsen] Anfang:      | Rüttlung 1:          |
|                      |         [ 280 °  K ] | [ 25 %           K ] |
|   (leer)             |         Ende:        | Rüttlung 2:          |
|                      |         [ 325 °  K ] | [ 25 %           K ] |
|                      |         Dauer:       | Hinweis: schaltet    |
|                      |         [ 50 ms  K ] | beide Rüttlungen ab  |
|                      | Hinweis Taktung      |                      |
+----------------------+----------------------+----------------------+
Funktionsleiste: [Heißleimgerät] [Motorparameter] [Gewichtskorrektur]
K = Schlüsselsymbol (Icon.Key, oben rechts im Element)
```

Innenaufbau der Gruppen (Maße als Tokens, keine Pixelpositionen):
- **Auslaufband:** Zeile aus Beschriftung (links, `Font.Size.Body`) und Eingabefeld (rechts, Höhe `Size.Touch.Default`).
- **Kopfleim:** oben der Umschalter in voller Gruppenbreite (Darstellung Taste, Höhe `Size.Touch.Default`); darunter zwei Spalten **2\* : 5\***: links das Piktogramm der Kopfleimdüsen (Symbol, mittig zu den drei Zeilen), rechts die drei Nocken-Parameterzeilen Anfang, Ende, Dauer (je `Size.Touch.Default`, Abstand `Size.Touch.Gap`); unten der Hinweis zur Taktung über die volle Gruppenbreite.
- **Rüttlung:** oben der Umschalter in voller Gruppenbreite, darunter die zwei Eingabezeilen Rüttlung 1 und 2, darunter der Hinweistext.
- Beschriftungen stehen links der Felder, rechtsbündig in einer gemeinsamen Beschriftungsspalte je Gruppe; Zahlen mit Einheit: Wert, geschütztes Leerzeichen, Einheit (`50 %`, `280 °`, `50 ms`).

**Funktionsleiste unten (HM-06):** drei seitenspezifische Tasten, links beginnend: „Heißleimgerät“, „Motorparameter“, „Gewichtskorrektur“ (höchstens 5 erlaubt, Navigation.md Abschnitt 3.3).

Bildabgleich: Das Referenzbild zeigt links das Auslaufband und rechts übereinander Kopfleim und Rüttlung. Das neue Layout ordnet die drei Gruppen nebeneinander an (Raster 4 : 4 : 4 des Designs DS-02), damit alle Touch-Ziele (`Size.Touch.Default`) mit Abstand `Size.Touch.Gap` ohne Scrollen in die Inhaltshöhe passen; Reihenfolge der Inhalte und Zeilen bleiben unverändert.

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Spalte „Herkunft“ = Rückverfolgung auf [RS-16](../../02_Referenz-Analyse/Seiten/RS-16_Schliessmaschine.md). Einheiten und Beispielwerte stammen aus dem Bild; Wertebereiche und Standardwerte sind im Handbuch nicht angegeben (OP-28), im neuen HMI konfigurierbare Dummy-Grenzen.

### Inhalt
| Nr. | Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-16) |
|---|---|---|---|---|---|
| E01 | Gruppe „Auslaufband“ | Gruppenbereich (Panel) | bündelt die Einstellung des Auslaufbands | [HM-15](../Module/HM-15_Gruppenbereich.md) | Bild: Gruppenfeld „Auslaufband“; T22 (Überschrift) |
| E02 | Geschwindigkeit (Bild 50 %) | Eingabefeld, Zahl, Einheit %, mit Schlüsselsymbol | Sollgeschwindigkeit des Auslaufbands; Antippen öffnet das Eingabe-Pop-up | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), Pop-up [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | T22, Zeile „Geschwindigkeit“ |
| E03 | Gruppe „Kopfleim“ | Gruppenbereich (Panel) | bündelt die Kopfleim-Einstellungen | [HM-15](../Module/HM-15_Gruppenbereich.md) | Bild: Gruppenfeld „Kopfleim“; T23 (Überschrift) |
| E04 | Umschalter Kopfleim Ein/Aus (Bild „Ein“) | Zustandstaste (Darstellung Taste), Wort „Ein“/„Aus“ mit Symbol, mit Schlüsselsymbol | erlaubt das Abwählen des Kopfleims | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | T23, Zeile „Taste Ein / Aus“ |
| E05 | Piktogramm Kopfleimdüsen | Fachsymbol (nur Anzeige, ohne Funktion), Name `Icon.Glue.Nozzle` (Fachsymbol, S16-6) | Bildhinweis auf Leimventil/Kopfleimdüsen | – (Symbol, Definition im Designsystem) | Bild: Piktogramm „grauer Block mit zwei Düsen“ |
| E06 | Anfang (Bild 280 °) | Nocken-Parameterzeile, Winkel in °, mit Schlüsselsymbol | Beginn der Nocke für den Kopfleim | [HM-24](../Module/HM-24_Nocken-Parameterzeile.md) (enthält [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md)) | T23, Zeile „Anfang“ |
| E07 | Ende (Bild 325 °) | Nocken-Parameterzeile, Winkel in °, mit Schlüsselsymbol | Ende der Nocke für den Kopfleim | [HM-24](../Module/HM-24_Nocken-Parameterzeile.md) | T23, Zeile „Ende“ |
| E08 | Dauer (Bild 50 ms) | Nocken-Parameterzeile, Zeit in ms, mit Schlüsselsymbol | Einschaltdauer des Ventils | [HM-24](../Module/HM-24_Nocken-Parameterzeile.md) | T23, Zeile „Dauer“ |
| E09 | Hinweis Taktung | Hinweis-Textfeld, Art Info, dauerhaft sichtbar | Text: „Benötigt die Nocke länger, aufgrund einer reduzierten Maschinengeschwindigkeit, wird das Ventil getaktet. Damit wird die Menge an Heißleim reduziert.“ | [HM-27](../Module/HM-27_Hinweis-Textfeld.md) | T23, Zeile „Dauer“ (zweiter und dritter Satz der Beschreibung) |
| E10 | Gruppe „Rüttlung“ | Gruppenbereich (Panel) | bündelt die Rüttlungs-Einstellungen | [HM-15](../Module/HM-15_Gruppenbereich.md) | Bild: Gruppenfeld „Rüttlung“; T24 (Überschrift) |
| E11 | Umschalter Rüttlung Ein/Aus (Bild „Ein“) | Zustandstaste (Darstellung Taste), Wort „Ein“/„Aus“ mit Symbol, mit Schlüsselsymbol | erlaubt das Abwählen der Rüttlung; schaltet beide Rüttlungen ab | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | T24, Zeile „Taste Ein / Aus“ |
| E12 | Rüttlung 1 (Bild 25 %) | Eingabefeld, Zahl, Einheit %, mit Schlüsselsymbol | Intensität der Rüttlung 1 | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), Pop-up [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | T24, Zeile „Rüttlung 1 / 2“ (erstes Feld) |
| E13 | Rüttlung 2 (Bild 25 %) | Eingabefeld, Zahl, Einheit %, mit Schlüsselsymbol | Intensität der Rüttlung 2 | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), Pop-up [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | T24, Zeile „Rüttlung 1 / 2“ (zweites Feld) |
| E14 | Hinweis Rüttlung | Hinweis-Textfeld, Art Info | Text: „Schaltet beide Rüttlungen ab.“ (bei Aus: beide Rüttlungen abgeschaltet) | [HM-27](../Module/HM-27_Hinweis-Textfeld.md) | T24, Zeile „Taste Ein / Aus“ (zweiter Satz) |

### Funktionsleiste unten
| Nr. | Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-16) |
|---|---|---|---|---|---|
| E15 | Taste „Heißleimgerät“ | Aktionstaste (Navigation), ohne Schlüssel | öffnet [HS-07](HS-07_Heissleim-Nordson.md) (Sprungziel im Handbuch nicht belegt, Annahme A-37); Seitenwechsel ohne Maschinenwirkung | [HM-06](../Module/HM-06_Funktionsleiste.md) mit [HM-07](../Module/HM-07_Aktionstaste.md) | Rahmenelemente: Taste „Heißleimgerät“ |
| E16 | Taste „Motorparameter“ (neu) | Aktionstaste (Navigation) | öffnet [HS-17](HS-17_Motorparameter-Schliessmaschine.md) | [HM-06](../Module/HM-06_Funktionsleiste.md) mit [HM-07](../Module/HM-07_Aktionstaste.md) | Ergänzung nach A-37 (RS-16 offener Punkt 5) |
| E17 | Taste „Gewichtskorrektur“ (neu) | Aktionstaste (Navigation) | öffnet [HS-18](HS-18_Gewichtskorrektur-Schliessmaschine.md) | [HM-06](../Module/HM-06_Funktionsleiste.md) mit [HM-07](../Module/HM-07_Aktionstaste.md) | Ergänzung nach A-37 (RS-16 offener Punkt 5) |

### Rahmenelemente (aus dem Rahmen-Grid, nicht seitenspezifisch)
| Nr. | Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-16) |
|---|---|---|---|---|---|
| R01 | Logo APA-TEC, Uhrzeit 13:03:21, Datum 12.05.2025 | Anzeige | Kopfzeile (Dummy-Daten) | [HM-02](../Module/HM-02_Kopfzeile.md) | Rahmenelemente: Logo; Uhrzeit/Datum |
| R02 | Seitentitel „Schließmaschine“ | Anzeige | letztes Brotkrümel-Segment „Einstellung › Schließmaschine“ (ersetzt den Titel der Kopfzeile); „Einstellung“ antippbar → HS-04 | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | Rahmenelemente: Seitentitel |
| R03 | Rundes Wirbelsymbol | – | entfällt als eigenes Element (ohne Funktion, Bedeutung ungeklärt, OP-26); die Kopfzeile zeigt die Betriebsart | [HM-02](../Module/HM-02_Kopfzeile.md) | Rahmenelemente: Wirbelsymbol |
| R04 | Meldezeile „\*450\* Palettierung nicht bereit“ | Anzeige, Statusfarbe der Meldung mit Symbol und Schweregradwort | zeigt die anstehende Meldung („450: Palettierung nicht bereit“, Dummy); Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | Rahmenelemente: Meldezeile |
| R05 | Schloss-Symbol (gelb, geschlossen) | Anzeige/Bedienung | wandert in die Seitenleiste: Benutzerkennung mit `Icon.Key`/`Icon.Lock` und Benutzer-Pop-up (Anmeldung) | [HM-01](../Module/HM-01_Seitenleiste.md) | Rahmenelemente: Schloss-Symbol |
| R06 | Taste „Produktion“ (Haus) | Navigation | Seitenleiste „Home“ → HS-01 | [HM-01](../Module/HM-01_Seitenleiste.md) | Rahmenelemente: Taste „Produktion“ |
| R07 | Taste „Einstellungen“ (Zahnrad) | Navigation | Seitenleiste „Einstellungen“ → HS-04; auf dieser Seite hervorgehoben | [HM-01](../Module/HM-01_Seitenleiste.md) | Rahmenelemente: Taste „Einstellungen“ |
| R08 | Taste „Zurück“ | Navigation (Verlauf) | Seitenleiste „Zurück“ → HS-04 (Verlauf) | [HM-01](../Module/HM-01_Seitenleiste.md) | Rahmenelemente: Taste „Zurück“ |
| R09 | Kennzahlen Geschwindigkeit und Maschinenwinkel | Anzeige | Rahmen des Designs, in der Referenz nicht vorhanden | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | Design-Rahmen (Agent.md Abschnitt 6) |

## Verwendete Module (IDs)
- [HM-01](../Module/HM-01_Seitenleiste.md) – Seitenleiste
- [HM-02](../Module/HM-02_Kopfzeile.md) – Kopfzeile
- [HM-03](../Module/HM-03_Meldezeile.md) – Meldezeile
- [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) – Brotkrümel-Navigation
- [HM-05](../Module/HM-05_Kennzahl-Kachel.md) – Kennzahl-Kachel
- [HM-06](../Module/HM-06_Funktionsleiste.md) – Funktionsleiste unten
- [HM-07](../Module/HM-07_Aktionstaste.md) – Aktionstaste
- [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) – Zustandstaste / Umschalter
- [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) – Eingabefeld mit Schlüsselsymbol
- [HM-13](../Module/HM-13_Eingabe-Pop-up.md) – Eingabe-Pop-up
- [HM-14](../Module/HM-14_Popup-Rahmen.md) – Pop-up-Rahmen (trägt HM-13)
- [HM-15](../Module/HM-15_Gruppenbereich.md) – Gruppenbereich
- [HM-24](../Module/HM-24_Nocken-Parameterzeile.md) – Nocken-Parameterzeile
- [HM-27](../Module/HM-27_Hinweis-Textfeld.md) – Hinweis-Textfeld

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
**Eingabe.** Antippen eines berechtigten Eingabefelds (E02, E06 bis E08, E12, E13) öffnet das Eingabe-Pop-up (HM-13 in HM-14) mit vorbelegtem Wert, Einheit und Grenzen; „Übernehmen“ nur bei gültigem Wert, „Abbrechen“ verwirft. Außerhalb tippen schließt nicht (Navigation.md 4.2). Ungültiger Wert: Fehlerzustand mit `Icon.Status.Error` und Text (z. B. „Wert außerhalb 0 bis 100 %“, Grenzen sind Dummy, OP-28). Der übernommene Wert gilt sofort; „Werte schreiben“ und der Zustand „nicht geschrieben“ von HM-24 entfallen auf dieser Seite (S16-3).

**Umschalter (E04, E11).** Zustand „Ein“: neutral aktiv (`Brush.Button.Active`), `Icon.State.On` und Wort „Ein“; Zustand „Aus“: `Icon.State.Off` und Wort „Aus“ (Referenzbild zeigt Aus nicht, Darstellung nach Designsystem Abschnitt 5; nicht grün). Während der Befehl noch nicht rückgemeldet ist: Zustand „Ausstehend“ (gestrichelt, Text „Wird gesetzt“). Bei „Aus“ bleiben die zugehörigen Felder bedienbar und behalten ihre Werte (S16-2). E11 „Aus“ schaltet beide Rüttlungen ab; E14 benennt das als Text.

**Dauer und Taktung (E08, E09).** Das Ventil wird getaktet, wenn die Nocke bei reduzierter Maschinengeschwindigkeit länger als die Dauer braucht; die Heißleimmenge sinkt. Das ist Steuerungsverhalten, die Seite zeigt nur den Hinweistext E09 (keine eigene Anzeige des Taktbetriebs, da im Handbuch keine beschrieben ist).

**Berechtigungen.** Die Schlüsselsymbole (`Icon.Key`, `Size.Icon.S` oben rechts im Element, Farbe `Brush.Text.Primary`, nicht gelb) kennzeichnen berechtigungspflichtige Eingaben: E02, E04, E06, E07, E08, E11, E12, E13 (6 Felder und 2 Umschalter). Rollen und Stufen sind Dummy (OP-04, OP-25). Ohne ausreichende Rolle gilt Navigation.md 4.1: Symbol `Icon.Lock`, Hinweis „Berechtigung erforderlich: <Rolle>“ und Benutzer-Pop-up zur Anmeldung; das Eingabe-Pop-up öffnet erst nach der Anmeldung.

**Sperrzustände.** Ist eine Bedienung im aktuellen Betriebszustand nicht zulässig (Dummy, OP-31), erscheinen die Elemente deaktiviert (gestrichelte Kontur, `Brush.Text.Disabled`, Symbol `Icon.Block`); Tippen nennt den Grund in der Meldezeile (A-28). Die Navigationstasten der Funktionsleiste bleiben bedienbar.

**Navigation und Zurück.** E15 öffnet HS-07, E16 HS-17, E17 HS-18; jeder Wechsel erzeugt einen Verlaufseintrag. „Zurück“ (Seitenleiste) führt im Verlauf zurück, zu HS-04, denn HS-16 wird nur aus HS-04 geöffnet. Die Rückkehr von HS-07, HS-17 und HS-18 hierher regeln die jeweiligen Seiten (Zurück-Ziel HS-16). Das Brotkrümel-Segment „Einstellung“ öffnet HS-04 und kürzt den Verlauf. Die Seitenleisten-Taste „Einstellungen“ ist hervorgehoben (Balken und Hintergrund). Bei offenem Pop-up sind Seitenleiste, Funktionsleiste, Brotkrümel und Seiteninhalt gesperrt. Navigation ändert keinen Maschinenzustand.

**Fehlerfälle.** Wertebereichsverletzung (siehe oben); Meldungen der Steuerung erscheinen in der Meldezeile; Kommunikationsausfall: Felder bleiben mit letztem Wert sichtbar, Dummy-Verhalten in M2.

## Prüfpunkte (Tabelle: ID | Prüfung | erwartetes Ergebnis | Status)
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-16-P01 | Titel und Brotkrümel (RS-16-P01) | Brotkrümel „Einstellung › Schließmaschine“, letztes Segment ist die Seite, „Einstellung“ antippbar | offen |
| HS-16-P02 | Gruppen (RS-16-P02) | drei Gruppenbereiche „Auslaufband“, „Kopfleim“, „Rüttlung“ im Raster 4 : 4 : 4, in dieser Reihenfolge | offen |
| HS-16-P03 | Auslaufband: Geschwindigkeit (RS-16-P03) | Eingabefeld „Geschwindigkeit:“ in %, Sollgeschwindigkeit des Auslaufbands, Beispielwert 50 % | offen |
| HS-16-P04 | Kopfleim: Umschalter (RS-16-P04) | Zustand „Ein“ mit `Icon.State.On` und Wort, Zustand „Aus“ mit `Icon.State.Off` und Wort; Fläche neutral, nicht grün; Funktion: Kopfleim abwählen | offen |
| HS-16-P05 | Kopfleim: Anfang (RS-16-P05) | Eingabe in ° (Beispiel 280 °), Beschriftung „Anfang:“, Beginn der Nocke für den Kopfleim | offen |
| HS-16-P06 | Kopfleim: Ende (RS-16-P06) | Eingabe in ° (Beispiel 325 °), Beschriftung „Ende:“, Ende der Nocke für den Kopfleim | offen |
| HS-16-P07 | Kopfleim: Dauer (RS-16-P07) | Eingabe in ms (Beispiel 50 ms), Beschriftung „Dauer:“, Einschaltdauer des Ventils | offen |
| HS-16-P08 | Kopfleim: Taktung (RS-16-P08) | Hinweistext E09 mit Symbol `Icon.Status.Info` und Wort „Info“ nennt Taktung des Ventils und reduzierte Heißleimmenge bei reduzierter Maschinengeschwindigkeit | offen |
| HS-16-P09 | Rüttlung: Umschalter (RS-16-P09) | Umschalter schaltet beide Rüttlungen ab bzw. ein; Hinweistext E14 vorhanden; Zustände wie P04 | offen |
| HS-16-P10 | Rüttlung 1 / 2 (RS-16-P10) | zwei Eingaben in % (Beispiel je 25 %), Beschriftung „Rüttlung 1:“ und „Rüttlung 2:“, Intensität der Rüttlung | offen |
| HS-16-P11 | Schlüsselsymbole (RS-16-P11) | 8 Schlüsselsymbole: 6 Eingabefelder (E02, E06, E07, E08, E12, E13) und 2 Umschalter (E04, E11); Symbol `Icon.Key`, nicht gelb | offen |
| HS-16-P12 | Funktionsleiste und Rahmentasten (RS-16-P12) | Funktionsleiste: „Heißleimgerät“ (→ HS-07), „Motorparameter“ (→ HS-17), „Gewichtskorrektur“ (→ HS-18); „Produktion“, „Einstellungen“, „Zurück“ und Benutzerkennung (Schloss/Schlüssel) in der Seitenleiste | offen |
| HS-16-P13 | Kopfzeile und Meldezeile (RS-16-P13) | Logo, Uhrzeit/Datum, Betriebsart und Meldezeile mit Symbol, Nummer und Schweregradwort vorhanden; Seitentitel im Brotkrümel | offen |
| HS-16-P14 | Bildabgleich (RS-16-P14) | jedes Element des Bildes [RS-16_01](../../02_Referenz-Analyse/Medien/RS-16_01.png) ist in der Elementtabelle (E01 bis E17, R01 bis R09) wiederzufinden, einschließlich Piktogramm E05 | offen |
| HS-16-P15 | Touch-Ziele | alle Eingabefelder, Umschalter und Tasten ≥ `Size.Touch.Default` hoch (nie < `Size.Touch.Min`), Abstand untereinander ≥ `Size.Touch.Gap` | offen |
| HS-16-P16 | Zweiter Kanal | Ein/Aus nur über Wort und Symbol erkennbar (auch in Graustufen); Fehler mit `Icon.Status.Error` und Text; Schloss/Schlüssel als Symbol; deaktiviert gestrichelt | offen |
| HS-16-P17 | Tokens | keine Hex- oder Pixelwerte in der Seite; Farben, Schriften, Abstände nur als Tokens; Eingabewerte nicht rot (Rot nur für Fehler) | offen |
| HS-16-P18 | Berechtigung | ohne Rolle (Navigation.md 4.1): `Icon.Lock`, Hinweis „Berechtigung erforderlich: <Rolle>“ und Benutzer-Pop-up; Eingabe-Pop-up öffnet nicht vor der Anmeldung | offen |
| HS-16-P19 | Eingabe-Pop-up | Antippen eines Felds öffnet HM-13 mit vorbelegtem Wert, Einheit und Grenzen; ungültiger Wert sperrt „Übernehmen“ mit Fehlertext | offen |
| HS-16-P20 | Layout ohne Scrollen | alle drei Gruppen vollständig im Inhaltsbereich bei 1920 × 1080 (768 px Höhe nach Außenrand) ohne Scrollen | offen |
| HS-16-P21 | Zurück und modal | „Zurück“ führt im Verlauf zurück (Zugang HS-04 → HS-04); bei offenem Pop-up sind Seitenleiste und Funktionsleiste gesperrt | offen |
| HS-16-P22 | Texte | alle sichtbaren Texte (Beschriftungen, Hinweise, Statuswörter) aus `.resx`, keine festen Texte im XAML | offen |

## Annahmen dieser Seite
- **S16-1:** Die drei Gruppen stehen nebeneinander im Raster 4 : 4 : 4 (Muster DS-02), damit alle Touch-Ziele ohne Scrollen passen; das Referenzbild stellt Kopfleim über Rüttlung.
- **S16-2:** Bei Kopfleim „Aus“ oder Rüttlung „Aus“ bleiben die zugehörigen Felder bedienbar und behalten ihre Werte; die Darstellung „Aus“ folgt dem Designsystem (im Bild nicht gezeigt).
- **S16-3:** Werte gelten sofort nach „Übernehmen“; der Zustand „nicht geschrieben“ von HM-24 entfällt (RS-16 kennt keine Schreibtaste).
- **S16-4:** Die Hinweise E09 und E14 sind dauerhaft sichtbare Info-Felder mit Handbuch-Wortlaut.
- **S16-5:** Reihenfolge der Funktionsleiste: Heißleimgerät, Motorparameter, Gewichtskorrektur (A-37); „Heißleimgerät“ ohne Schlüssel.
- **S16-6:** Das Piktogramm der Kopfleimdüsen ist ein reines Anzeigesymbol `Icon.Glue.Nozzle` ohne Funktion.

## Offene Punkte
Seiten-Index der [Offene-Punkte.md](../../00_Plan/Offene-Punkte.md) für RS-16: OP-23, OP-25, OP-26, OP-28, OP-34, OP-36, OP-39.
- **OP-23:** Zugang zu HS-17/HS-18 im Handbuch nicht beschrieben; Annahme A-37 (zwei Tasten in der Funktionsleiste E16, E17).
- **OP-25:** Bedeutung und Stufe des Schlüsselsymbols je Feld offen (Dummy-Rollen).
- **OP-26:** Wirbelsymbol und Schloss-Symbol des Referenzbilds ohne dokumentierte Bedeutung; im neuen HMI Betriebsart bzw. Benutzerkennung.
- **OP-28:** Wertebereiche und Standardwerte (Auslaufband %, Winkel °, Dauer ms, Rüttlung %) fehlen; Dummy-Grenzen, Beispielwerte aus dem Bild.
- **OP-34:** Bildbeschriftung gegen Handbuchtext (Reihenfolge „Kopfleim, Rüttlung, Auslaufband“ in RS-04 gegen Bildreihenfolge); Bildreihenfolge übernommen.
- **OP-36:** Sprungziel „Heißleimgerät“ nicht belegt; Annahme HS-07 (A-37).
- **OP-39:** Darstellung der Umschalter im Zustand „Aus“ nicht gezeigt; Darstellung nach Designsystem.
