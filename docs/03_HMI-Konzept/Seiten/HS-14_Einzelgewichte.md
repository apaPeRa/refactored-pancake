# HS-14 – Einzelgewichte
- Quelle: [RS-14](../../02_Referenz-Analyse/Seiten/RS-14_Einzelgewichte.md) (Handbuch Kapitel 14, Tabelle 21 „Funktionsbeschreibung“, Bild [RS-14_01](../../02_Referenz-Analyse/Medien/RS-14_01.png)). Keine Design-Seite (DS) vorhanden: Aufbau abgeleitet aus dem [Designsystem](../Designsystem.md) (Rahmen-Grid 3.2, 12-Spalten-Raster 3.3) und den [HM](../Module/Modulliste.md).   - Navigationspfad: **Einstellung › Waagen › Kontrollwaage › Einzelgewichte** (Brotkrümel nach [Navigation.md](../Navigation.md) Abschnitt 2; Zugang: HS-13 Funktionsleiste „Einzelgewichte“; Zurück-Ziel: HS-13; PageKey `SingleWeights`, Route `settings/scales/check/weights`, Mindestrolle: keine).

## Zweck
Die Seite zeigt die tabellarische Historie der letzten 50 gemessenen Gewichte sowie statistische Kennzahlen (Standardabweichung, Mittelwert, Anzahl). Sie dient der Kontrolle der Gewichtsgenauigkeit in der laufenden Produktion oder im Stichprobenbetrieb (Handbuch, wortgetreu: „… eine tabellarische Historie der letzten 50 gemessenen Gewichte sowie statistische Kennzahlen. Sie dient der Kontrolle der Gewichtsgenauigkeit in der laufenden Produktion oder im Stichprobenbetrieb.“). Der Seitentitel folgt dem Kapitelnamen „Einzelgewichte“; der Titel „Einzelgewichte KW“ des Handbuchbilds wird nicht übernommen (OP-33).

## Aufbau (Bereiche, Layout)
Rahmen wie in Designsystem Abschnitt 3.2. Der **Inhaltsbereich** (Außenrand `Size.Content.Margin`, 12-Spalten-Raster, Gutter `Space.M`) hat zwei Zeilen im Verhältnis **1\* : 9\***:

1. **Kennzahlenzeile** (Zeile 1\*, Kontrollwert ca. 80 px, Mindesthöhe `Size.Touch.Default` für die Kacheln): drei Kennzahl-Kacheln über je 4 Spalten: Standardabweichung | Mittelwert | Anzahl.
2. **Wertegitter** (Zeile 9\*, Kontrollwert ca. 700 px bei 816 px Inhaltshöhe): 10 Zeilen × 5 Spalten = 50 Zellen als `UniformGrid`, Zeilenabstand `Space.S`, Spaltenabstand `Space.M`; Zellhöhe mindestens `Size.Touch.Min`. Je Zelle von links nach rechts: Positionspfeil (nur an der Zelle des zuletzt erfassten Werts), Status-LED mit Symbol, Gewichtswert, Kurzwort „gut“/„schlecht“.

Die Funktionsleiste enthält links beginnend zwei Zustands-/Aktionstasten: den Umschalter „Einzel / Fortlaufend“ und „Start“ (Reihenfolge nach Navigation.md Abschnitt 3.3; Position von „Start“ in der Referenz unklar, siehe Offene Punkte).

```
Inhaltsbereich (12 Spalten)
+--------------------------------------------------------------------------------+
| [ Standardabweichung (4)  ] [ Mittelwert (4)        ] [ Anzahl (4)            ] |  1*
+--------------------------------------------------------------------------------+
| Wertegitter 10 x 5                                                             |  9*
| [>o 235,7 g gut] [ o 235,0 g gut] [ o 236,1 g gut] [ o 234,0 g gut] [ o 235,2 g ]|  Zeile 1
| [ o 235,3 g    ] [ o 234,4 g    ] ...                                           |  Zeile 2
|   ...                                                                           |
| [ o 235,7 g    ] [ o 236,3 g    ] [ o 235,8 g    ] [ o 234,8 g    ] [ o 235,0 g ]|  Zeile 10
+--------------------------------------------------------------------------------+
Funktionsleiste: [ Einzel / Fortlaufend ] [ Start ]
(> = Positionspfeil am zuletzt erfassten Wert, o = Status-LED mit Symbol)
```

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Spalte „Herkunft“ ist die Rückverfolgung: [RS-14](../../02_Referenz-Analyse/Seiten/RS-14_Einzelgewichte.md) Tabelle 21 (Zeile 1–6 = Nr. 1–6) und Bildelemente.

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Standardabweichung | Anzeigekachel, g, Format `N1` (Beispiel „0,7 g“), Symbol `Icon.Stat.StdDev` | zeigt die Standardabweichung der gemessenen Werte an | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) (Label „Standardabweichung“) | RS-14 Nr. 1 |
| Mittelwert | Anzeigekachel, g, Format `N1` (Beispiel „235,4 g“), Symbol `Icon.Stat.Mean` | zeigt den Mittelwert der letzten 50 Messwerte an | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) (Label „Mittelwert“) | RS-14 Nr. 2 |
| Anzahl | Anzeigekachel, Stk (Beispiel „50“); keine rote Schrift, kein Schlüsselsymbol | Anzahl der zu erfassenden Werte (Maximum 50); in der Referenz rot und ohne Schlüssel, Bedienbarkeit unklar; Annahme: reine Anzeige (S14-1) | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) (Label „Anzahl“, Einheit „Stk“, `Decimals` 0) | RS-14 Nr. 3 |
| Werte (Wertegitter) | Gitter 10 Zeilen × 5 Spalten, 50 Zellen, Gewicht in g, Format `N1`, sortiert von oben nach unten und von links nach rechts | zeigt die letzten 50 gemessenen Einzelgewichte; leere Zelle zeigt „–“ | [HM-37](../Module/HM-37_Wertegitter.md) (`Cells`, `Capacity` 50) | RS-14 Nr. 4, Bild RS-14_01 |
| Status-LED je Wert | Symbol je Zelle: `Icon.Status.Ok` (Haken) und Wort „gut“ bzw. `Icon.Status.Warning` (Dreieck) und Wort „schlecht“ | grün = gutes Gewicht, grau = schlechtes Gewicht (Referenz); im neuen HMI Symbol und Wort statt nur Farbe, schlechter Wert zusätzlich mit Fläche `Brush.Status.Warning.Subtle` (A-55) | [HM-09](../Module/HM-09_Status-LED.md) (kompakt, `ShowStateWord` über HM-37) | RS-14 Nr. 4 (LED) |
| Positionspfeil | Marker `Icon.Marker.Last` links der Zelle plus Kontur `Border.Thick` `Brush.Border.Focus` | zeigt auf das zuletzt erfasste Gewicht | [HM-37](../Module/HM-37_Wertegitter.md) (`LastIndex`) | RS-14 Nr. 4 (Pfeil) |
| Taste „Start“ | Aktionstaste, Funktionsleiste, Auslösung Antippen, Höhe `Size.Touch.Default` | startet einen neuen Messdurchlauf; im Modus Einzel löscht Start alle bisherigen Werte (mit Bestätigung, Annahme S14-2) | [HM-07](../Module/HM-07_Aktionstaste.md); Teil von [HM-37](../Module/HM-37_Wertegitter.md) (`StartCommand`) | RS-14 Nr. 5 |
| Umschalter „Einzel / Fortlaufend“ | Zustandstaste in der Funktionsleiste; Beschriftung „Messmodus“, Zustandswort „Einzel“ oder „Fortlaufend“ mit `Icon.State.Off`/`Icon.State.On` | **Einzel:** manuelle Stichprobenmessung, Start löscht alle bisherigen Werte. **Fortlaufend:** automatischer Betrieb; nach Erreichen von 50 Werten wird fortlaufend überschrieben; ermöglicht gleitenden Mittelwert. Das Wort zeigt den aktuellen Modus, nicht die Aktion (S14-3) | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) (`ToggleStyle` Button, `OnText` „Fortlaufend“, `OffText` „Einzel“); Teil von [HM-37](../Module/HM-37_Wertegitter.md) (`ToggleModeCommand`) | RS-14 Nr. 6, Bild „Fortlaufend“ links unten |

### Rahmenelemente (nicht in der Handbuchtabelle, laut Seitenbild RS-14_01)
| Element der Referenz | Ort im neuen HMI | verwendetes Modul | Herkunft |
|---|---|---|---|
| Kopfzeile mit Logo, Titel „Einzelgewichte KW“, Wirbelsymbol, Uhrzeit, Datum | Kopfzeile (Logo, Betriebsart, Uhr/Datum); Titel = letztes Brotkrümel-Segment „Einzelgewichte“ | [HM-02](../Module/HM-02_Kopfzeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | Seitenbild, OP-26, OP-33 |
| Meldezeile „*450* Palettierung nicht bereit“ (rot) | Meldezeile in der Kopfzeile; Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | Seitenbild, RS-38 |
| Vorhängeschloss, „Produktion“, „Einstellungen“, „Zurück“ | Seitenleiste: Benutzerkreis, Home, Zahnrad, Zurück | [HM-01](../Module/HM-01_Seitenleiste.md) | Seitenbild, A-35 |

## Verwendete Module (IDs)
- [HM-01](../Module/HM-01_Seitenleiste.md) – Seitenleiste (Rahmen)
- [HM-02](../Module/HM-02_Kopfzeile.md) – Kopfzeile (Rahmen)
- [HM-03](../Module/HM-03_Meldezeile.md) – Meldezeile (Rahmen)
- [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) – Brotkrümel-Navigation (Rahmen)
- [HM-05](../Module/HM-05_Kennzahl-Kachel.md) – Kennzahl-Kachel (Standardabweichung, Mittelwert, Anzahl)
- [HM-06](../Module/HM-06_Funktionsleiste.md) – Funktionsleiste unten (Umschalter, Start)
- [HM-07](../Module/HM-07_Aktionstaste.md) – Aktionstaste (Start, Bestätigungs-Tasten)
- [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) – Zustandstaste / Umschalter (Einzel / Fortlaufend)
- [HM-09](../Module/HM-09_Status-LED.md) – Status-LED (je Zelle, kompakt)
- [HM-14](../Module/HM-14_Popup-Rahmen.md) – Pop-up-Rahmen (Bestätigung vor dem Löschen)
- [HM-37](../Module/HM-37_Wertegitter.md) – Wertegitter (50 Zellen)

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
**Zugang und Zurück.** Die Seite öffnet aus HS-13 über die Funktionsleistentaste „Einzelgewichte“. „Zurück“ (Seitenleiste) führt im Verlauf zu HS-13; das Brotkrümel-Segment „Kontrollwaage“ springt ebenfalls dorthin, „Waagen“ zu HS-42. Der Brotkrümel ist der kanonische Pfad und bleibt gleich.

**Berechtigungen.** Im Handbuch nicht beschrieben; im Bild tragen weder die Kennzahlen noch Start/Umschalter ein Schlüsselsymbol. Alle Elemente sind frei bedienbar (Mindestrolle: keine). Wird die Rolle später verlangt, gilt die Darstellung nach Designsystem Abschnitt 5 (Schlüssel/Schloss in `Brush.Text.Primary`).

**Modus Einzel.** Manuelle Stichprobenmessung. Antippen von „Start“ löscht alle bisherigen Werte und beginnt einen neuen Durchlauf. Sind bereits Werte vorhanden, öffnet vorher ein Bestätigungs-Pop-up (HM-14): Titel „Start“, Text „Alle bisherigen Werte werden gelöscht.“, Tasten „Ja“/„Abbrechen“ (Annahme S14-2; das Handbuch beschreibt keine Rückfrage, OP-31). Das Gitter füllt sich Zelle für Zelle, der Pfeil wandert mit; nicht belegte Zellen zeigen „–“. Ist die Anzahl erreicht, wird nicht überschrieben, der Durchlauf ist beendet (Auslegung, offen).

**Modus Fortlaufend.** Automatischer Betrieb. Nach Erreichen von 50 Werten wird fortlaufend überschrieben, das Gitter bleibt voll, der Pfeil läuft über die Zellen; Mittelwert und Standardabweichung sind gleitend über die letzten 50 Messwerte. Das Verhalten von „Start“ im Modus Fortlaufend ist im Handbuch nicht beschrieben (Annahme S14-2: Start ist in beiden Modi bedienbar und beginnt einen neuen Durchlauf; ob dabei Werte gelöscht werden, ist offen).

**Umschalter.** Der Wechsel ist sofort wirksam; Zustand über Wort („Einzel“/„Fortlaufend“) und Symbol (`Icon.State.On` = Fortlaufend, `Icon.State.Off` = Einzel), nicht über Farbe. Ausstehend (Befehl gesendet, Rückmeldung fehlt): `Icon.State.Pending` und Text „Wird gesetzt“. Fehler: `Icon.Status.Error` und Fehlertext. Ob beim Wechsel Werte erhalten bleiben, ist nicht beschrieben (offen). Der Standardmodus ist unbekannt; das Bild zeigt „Fortlaufend“.

**Gut/schlecht.** Gut = `Icon.Status.Ok` und „gut“; schlecht = `Icon.Status.Warning` und „schlecht“ mit Flächenton `Brush.Status.Warning.Subtle` und Kontur `Border.Medium` `Brush.Status.Warning.Fg` (Warnfläche mit Kontur nach Designsystem 1.2). Das Kriterium gut/schlecht ist nicht beschrieben, vermutet werden die Grenzwerte aus HS-13 (OP-47); im Bild ist kein schlechter Wert sichtbar.

**Fehlerfälle und Sonderzustände.** Kein Messwert vorhanden oder Waage nicht erreichbar: Kennzahlen „---“, Zellen „–“, Meldung in der Meldezeile. Weniger als 50 Werte: Mittelwert und Standardabweichung über die vorhandenen Werte, Anzahl zeigt den Maximalwert 50 (Verhalten nicht beschrieben, offen). Die Seite ist ohne Pop-up reine Anzeige mit zwei Funktionstasten; sie ändert nur die Messreihe, keine Maschinenparameter.

**Modale Regeln.** Bei offenem Bestätigungs-Pop-up sind Seitenleiste, Funktionsleiste und Brotkrümel gesperrt; Schließen nur über „Ja“, „Abbrechen“ oder das Kreuz.

## Prüfpunkte (Tabelle: ID | Prüfung | erwartetes Ergebnis | Status)
Die Punkte HS-14-P01 bis P10 sind die Entsprechung der Prüfpunkte RS-14-P01 bis P10 (Nummer gleich); ab P11 folgen Punkte aus Designsystem und Navigation.

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-14-P01 | Zugang (RS-14-P01) | Brotkrümel „Einstellung › Waagen › Kontrollwaage › Einzelgewichte“; Seite öffnet aus HS-13 über „Einzelgewichte“; „Zurück“ führt zu HS-13 | offen |
| HS-14-P02 | Kennzahlen oben (RS-14-P02) | Standardabweichung (g), Mittelwert (g, letzte 50 Messwerte) und Anzahl (Wert 50) als drei Kacheln in einer Zeile, jeweils mit Beschriftungstext | offen |
| HS-14-P03 | Wertegitter (RS-14-P03) | 50 Werte im Format „xxx,x g“, angeordnet 10 Zeilen × 5 Spalten, mit je einem Status-Symbol | offen |
| HS-14-P04 | Sortierung (RS-14-P04) | Werte sind von oben nach unten und von links nach rechts sortiert (Leserichtung des Gitters) | offen |
| HS-14-P05 | Positionspfeil (RS-14-P05) | genau eine Zelle trägt Pfeil `Icon.Marker.Last` und dicke Kontur; sie enthält das zuletzt erfasste Gewicht | offen |
| HS-14-P06 | Gut/schlecht (RS-14-P06) | gut = Haken und Wort „gut“, schlecht = Dreieck und Wort „schlecht“ mit Flächenton; Zustand auch ohne Farbe erkennbar | offen |
| HS-14-P07 | Taste „Start“ (RS-14-P07) | in der Funktionsleiste vorhanden; startet einen neuen Messdurchlauf | offen |
| HS-14-P08 | Umschalter Einzel / Fortlaufend (RS-14-P08) | Funktionsleiste zeigt Wort des aktuellen Modus mit Symbol; Einzel: Start löscht alle Werte (nach Bestätigung); Fortlaufend: nach 50 Werten wird überschrieben, Mittelwert gleitend | offen |
| HS-14-P09 | Seitenbild und Elemente (RS-14-P09) | alle Elemente aus RS-14_01 sind wiederzufinden: drei Kennzahlen, 50 Zellen mit LED, Pfeil, Taste „Fortlaufend“ (als Umschalter), Meldezeile, Rahmentasten (in der Seitenleiste) | offen |
| HS-14-P10 | Vollständigkeit Tabelle 21 (RS-14-P10) | alle 6 Datenzeilen (Standardabweichung, Mittelwert, Anzahl, Werte, Start, Einzel/Fortlaufend) sind im Layout wiederzufinden (Spalte „Herkunft“) | offen |
| HS-14-P11 | Seitentitel | letztes Brotkrümel-Segment „Einzelgewichte“ (nicht „Einzelgewichte KW“) | offen |
| HS-14-P12 | Anzahl nicht rot | Kachel „Anzahl“ zeigt den Wert in `Brush.Text.Primary`; keine Statusfarbe ohne Statusbedeutung | offen |
| HS-14-P13 | Zellen leer und gefüllt | nicht belegte Zellen zeigen „–“ und kein Status-Symbol; belegte Zellen immer Wert und Symbol | offen |
| HS-14-P14 | Bestätigung vor Löschen | Start im Modus Einzel mit vorhandenen Werten öffnet das Bestätigungs-Pop-up; „Abbrechen“ lässt alle Werte unverändert | offen |
| HS-14-P15 | Zweiter Kanal | gut/schlecht, Modus (Einzel/Fortlaufend), letzter Wert, ausstehender und fehlerhafter Umschalter sind je mit Symbol oder Text erkennbar | offen |
| HS-14-P16 | Touch-Ziele | Umschalter und Start mindestens `Size.Touch.Default` hoch und `Size.FunctionButton.MinWidth` breit, Abstand mindestens `Size.Touch.Gap`; Gitterzellen mindestens `Size.Touch.Min` hoch | offen |
| HS-14-P17 | Tokens und Texte | keine Hex-, Pixel- oder Literalwerte; Beschriftungen, Zustandswörter, Einheiten aus `.resx`; Schrift mindestens `Font.Size.Caption`; Zahlen mit tabellarischen Ziffern | offen |
| HS-14-P18 | Raster bei 1920 × 1080 | Zeilenproportion 1\* : 9\*; alle 50 Zellen ohne Scrollen sichtbar; Wert, Symbol und Wort passen in eine Zelle | offen |

## Offene Punkte
Verweise auf [Offene-Punkte.md](../../00_Plan/Offene-Punkte.md) (Seiten-Index RS-14): OP-27 (Farbbedeutung der LEDs und Schriften), OP-28 (Wertebereich der Anzahl, Maximum 50), OP-32 (Anzahl der Werte 50/20/21), OP-33 (Seitentitel „Einzelgewichte KW“), OP-34 (Abweichungen Bild/Handbuch), OP-39 (Taste „Start“ nicht im Bild), OP-47 (Kriterium gut/schlecht, Kontrollwaage). Zusätzlich offen und in der Referenz nur als offener Punkt der RS-Seite geführt:

- **Sortierrichtung:** „von oben nach unten und links nach rechts“ ist nicht eindeutig (zeilen- oder spaltenweise); der Pfeil des Bilds steht in Zeile 2, Spalte 2. Angenommen wird zeilenweise Lesefolge mit Pfeil an der jüngsten Zelle; Klärung offen (Vorschlag eigener OP).
- **Anzahl:** „Anzahl zu erfassenden Werte“ mit roter Schrift ohne Schlüssel; Bedienbarkeit, Standard und Wertebereich nicht angegeben.
- **Umschalter:** Bildbeschriftung „Fortlaufend“ ist Zustand oder Aktion, Standardmodus und Verhalten beim Wechsel offen.
- **Wertegitter:** Verhalten bei weniger als 50 Werten und das Ende eines Durchlaufs im Modus Einzel nicht beschrieben.

**Seitenannahmen (zur Aufnahme in Annahmen.md vorgeschlagen):**
- S14-1: Die Kachel „Anzahl“ ist reine Anzeige (kein Schlüsselsymbol im Bild); die rote Schrift entfällt.
- S14-2: „Start“ ist in beiden Modi bedienbar; im Modus Einzel mit vorhandenen Werten folgt ein Bestätigungs-Pop-up vor dem Löschen (HM-14 mit HM-07-Tasten; A-40, OP-31). Reihenfolge der Funktionsleiste: Umschalter, dann Start (Navigation.md).
- S14-3: Der Umschalter zeigt den aktuellen Modus als Zustandswort (nicht die Aktion), Standard „Fortlaufend“ wie im Bild.
- S14-4: Schlechte Gewichte erhalten Warnsymbol und Wort „schlecht“ (A-55), nicht „grau“.
