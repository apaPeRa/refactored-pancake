# HS-13 – Kontrollwaage
- Quelle: [RS-13](../../02_Referenz-Analyse/Seiten/RS-13_Kontrollwaage.md) (Handbuch Kapitel 13, Tabelle 19 „Hauptbereich“, Tabelle 20 „Navigation (unten links)“, Bilder [RS-13_01](../../02_Referenz-Analyse/Medien/RS-13_01.png) bis [RS-13_14](../../02_Referenz-Analyse/Medien/RS-13_14.png)). Keine Design-Seite (DS) vorhanden: Aufbau abgeleitet aus dem [Designsystem](../Designsystem.md), dem Rahmen-Grid (Abschnitt 3.2/3.3) und den [HM](../Module/Modulliste.md).   - Navigationspfad: **Einstellung › Waagen › Kontrollwaage** (Brotkrümel nach [Navigation.md](../Navigation.md) Abschnitt 2; Zugang: HS-42 Kachel „Kontrollwaage“; Zurück-Ziel: HS-42; PageKey `CheckWeigher`, Route `settings/scales/check`, Mindestrolle: keine).

## Zweck
Die Seite dient dazu, die Kontrollwaage zu beobachten und Einstellungen an den Zielgewichten und den statistischen Werten (Grenzwerte, Tara, automatischer Nullpunkt) vorzunehmen. Zusätzlich zeigt sie Werte, die zur Berechnung der Nachdosierung dienen (Handbuch, wortgetreu: „… die Kontrollwaage zu beobachten und Einstellungen an den Zielgewichten und statistischen Werten vorzunehmen. Zusätzlich werden Werte angezeigt, die zur Berechnung der Nachdosierung dienen.“). Von hier aus erreicht man die Unterseiten [HS-15](HS-15_Trend.md) (Trend) und [HS-14](HS-14_Einzelgewichte.md) (Einzelgewichte).

## Aufbau (Bereiche, Layout)
Rahmen (Seitenleiste, Kopfzeile mit Meldezeile, Brotkrümel mit Kennzahlen, Funktionsleiste) wie in Designsystem Abschnitt 3.2. Der **Inhaltsbereich** (Außenrand `Size.Content.Margin`, 12-Spalten-Raster, Gutter `Space.M`) enthält fünf Gruppen untereinander, jede als Überschrift-Variante von [HM-15](../Module/HM-15_Gruppenbereich.md) (Text mit Trennlinie `Brush.Divider`, keine Panel-Fläche, damit die Höhe für Eingabefelder mit Zähler reicht). Abstand zwischen den Gruppen `Space.L`. Die Reihenfolge folgt der Leserichtung der Referenz (Netto/Brutto/Live, Statistik, Zielwerte, Grenzwerte mit Zählern, Zählerzeile).

Zeilenproportionen im Inhaltsbereich: **4\* : 3\* : 3\* : 4\* : 3\*** (Kontrollwert bei 1920 × 1080: ca. 170 / 127 / 127 / 170 / 127 px bei 816 px Inhaltshöhe abzüglich vier Gruppenabstände; Mindesthöhen: Überschrift `Font.Size.Value` + Eingabefeld `Size.Touch.Default`, mit Zähler zusätzlich `Size.Field.Height`).

```
Inhaltsbereich (12 Spalten)
+------------------------------------------------------------------------------+
| Gewicht                                                                  4*  |
| [ Netto (4)           ] [ Brutto (3)   ] [ Live (3)      ] [Nullpunkt setzen (2)]|
+------------------------------------------------------------------------------+
| Statistik                                                                3*  |
| [ Mittelwert (4)      ] [ Standardabw. S (4)     ] [ Leistung Ist (4)       ]|
+------------------------------------------------------------------------------+
| Zielwerte                                                                3*  |
| [ Sollgewicht (4)     ] [ Tara (4)               ] [ Autom. Nullpunkt (4) 104]|
+------------------------------------------------------------------------------+
| Grenzwerte und Ausschuss                                                 4*  |
| [ Übergewicht (4)     ] [ Untergewicht TU 1 (4)  ] [ Untergewicht TU 2 (4)    ]|
| [   Zähler 435        ] [   Zähler 0             ] [   Zähler 1093            ]|
+------------------------------------------------------------------------------+
| Zähler                                                                   3*  |
| [ Gut (3)  ] [ T1 % (3)       ] [ Schlecht (3)   ] [ Zähler löschen (3)       ]|
+------------------------------------------------------------------------------+
Funktionsleiste: [ Trend ] [ Einzelgewichte ]                       (leer rechts)
```

Alle Spalten- und Zeilenanteile sind Sternmaße; Mindestbreiten der Kacheln `Size.Metric.MinWidth`, Tasten `Size.Button.MinWidth`, in der Funktionsleiste `Size.FunctionButton.MinWidth`. Abstand zwischen zwei Touch-Zielen mindestens `Size.Touch.Gap`.

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Spalte „Herkunft“ ist die Rückverfolgung zur Referenz ([RS-13](../../02_Referenz-Analyse/Seiten/RS-13_Kontrollwaage.md): Tabelle 19 Zeile 1–17 = Nr. 1–17, Tabelle 20 = Nr. 18–19). Fachsymbole (`Icon.*`) sind im jeweiligen HM-Symbolbestand zu ergänzen (Bericht, Abschnitt fehlende Symbole); die Beschriftung als Text steht immer dabei (zweiter Kanal).

### Gruppe „Gewicht“
| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Netto | Anzeigekachel, Gewicht in g, Format `N1` (Beispiel „0,0 g“), Waagensymbol, größte Kachel der Gruppe (4 Spalten) | zeigt das aktuelle berechnete Nettogewicht der Packung | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) (`TileSize` Content, `Icon.Weight.Scale`, Label „Netto“) | RS-13 Nr. 1, Bild RS-13_02 |
| Brutto | Anzeigekachel, g (Beispiel „0,0 g“), Waagensymbol | zeigt das aktuelle Bruttogewicht inklusive Tara | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) (Label „Brutto“) | RS-13 Nr. 2, Bild RS-13_03 |
| Live | Anzeigekachel, g, vorzeichenbehaftet (Beispiel „−399,0 g“), Waagensymbol | zeigt den ungefilterten Rohwert der Waage, hilfreich für Diagnosen; Minuszeichen und Dezimalkomma nach `CurrentCulture` | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) (Label „Live“) | RS-13 Nr. 3, Bild RS-13_04 |
| Taste „Nullpunkt setzen“ | Aktionstaste mit Schlüsselsymbol, Auslösung Antippen, Höhe `Size.Touch.Default` | setzt den Waagen-Nullpunkt neu; die Waage muss unbelastet und sauber sein; öffnet vorher das Bestätigungs-Pop-up mit diesem Hinweis (Annahme S13-1) | [HM-07](../Module/HM-07_Aktionstaste.md) (`RequiresPermission`); Pop-up: [HM-14](../Module/HM-14_Popup-Rahmen.md) mit Tasten HM-07 | RS-13 Nr. 16 |

### Gruppe „Statistik“
| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Mittelwert (X̄) | Anzeigekachel, g (Beispiel „235,1 g“) | Mittelwert der zuletzt gewogenen Packungen | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) (`Icon.Stat.Mean`, Label „Mittelwert“) | RS-13 Nr. 4, Bild RS-13_05 |
| Standardabweichung (S) | Anzeigekachel, g (Beispiel „1,2 g“) | Standardabweichung der zuletzt gewogenen Packungen; Handbuchbild fehlt, im Seitenbild Symbol „S“ | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) (`Icon.Stat.StdDev`, Label „Standardabweichung“) | RS-13 Nr. 5 |
| Leistung Ist | Anzeigekachel, 1/min (Beispiel „114,6 1/min“), Tachosymbol | durchschnittlich gewogene Packungen pro Minute | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) (`Icon.Speed`, Label „Leistung Ist“) | RS-13 Nr. 6, Bild RS-13_06 |

### Gruppe „Zielwerte“
| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Sollgewicht | Eingabefeld mit Schlüsselsymbol, g (Beispiel „235,0 g“); Wert nicht rot, sondern `Font.Weight.Strong` | Zielgewicht für die Hauptdosierer; Antippen öffnet das Eingabe-Pop-up | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) (`Icon.Pack.Target`, `Decimals` 1); [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | RS-13 Nr. 7, Bild RS-13_07 |
| Tara | Eingabefeld mit Schlüsselsymbol, g (Beispiel „15,0 g“) | Gewicht der leeren Packung | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) (`Icon.Pack.Tare`); [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | RS-13 Nr. 8, Bild RS-13_08 |
| Automatischer Nullpunkt | Eingabefeld mit Schlüsselsymbol, Stückzahl in Stk (Beispiel „5000 Stk“) mit Zusatzzähler unten rechts im Feld (Beispiel „104“) | Anzahl Packungen, nach der die Maschine einen automatischen Nullpunkt durchführt; **0 deaktiviert** die Funktion (Feld zeigt dann Text „Aus“ zusätzlich zur 0); Zusatzzähler = Packungen seit dem letzten Nullpunkt (`AutomationProperties.Name` „Packungen seit dem letzten Nullpunkt“) | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) (`Counter`, `Icon.Weight.AutoZero`, `Decimals` 0); [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | RS-13 Nr. 9, Bild RS-13_09 |

### Gruppe „Grenzwerte und Ausschuss“
| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Übergewicht | Eingabefeld mit Schlüsselsymbol, g (Beispiel „268,0 g“) mit gekoppeltem Zählfeld darunter (Beispiel „435“) | Packungen mit einem Produktgewicht **gleich oder größer** werden als schlecht markiert und ausgeworfen; Zähler = Anzahl schlechter Packungen seit dem letzten „Zähler löschen“ | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) (`CoupledCounter`, `Icon.Pack.Over`); [HM-13](../Module/HM-13_Eingabe-Pop-up.md); Zählfeld: [HM-11](../Module/HM-11_Anzeigefeld.md) bzw. HM-12-Zähler | RS-13 Nr. 10, Bild RS-13_10 |
| Untergewicht TU 1 | Eingabefeld mit Schlüsselsymbol, g (Beispiel „200,0 g“) mit Zählfeld darunter (Beispiel „0“); Beschriftung „Untergewicht TU 1“ (zweizeilig „Untergewicht / TU 1“) | Packungen mit einem Produktgewicht **gleich oder kleiner** werden als schlecht markiert und ausgeworfen, **wenn kein Guthaben mehr vorhanden ist**; Zähler wie oben | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) (`CoupledCounter`, `Icon.Pack.Under1`); [HM-13](../Module/HM-13_Eingabe-Pop-up.md); [HM-11](../Module/HM-11_Anzeigefeld.md) | RS-13 Nr. 11, Bild RS-13_11 |
| Untergewicht TU 2 | Eingabefeld mit Schlüsselsymbol, g (Beispiel „200,0 g“) mit Zählfeld darunter (Beispiel „1093“) | Packungen mit einem Produktgewicht **gleich oder kleiner** werden als schlecht markiert und ausgeworfen; Zähler wie oben | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) (`CoupledCounter`, `Icon.Pack.Under2`); [HM-13](../Module/HM-13_Eingabe-Pop-up.md); [HM-11](../Module/HM-11_Anzeigefeld.md) | RS-13 Nr. 12, Bild RS-13_12 |

### Gruppe „Zähler“
| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Gut-Packungen | Zählkachel (Beispiel „874794“), Symbol `Icon.Status.Ok` und Wort „Gut“ | Anzahl guter Packungen seit dem letzten „Zähler löschen“ | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) (Einheit „Stk“, `Decimals` 0) | RS-13 Nr. 13, Bild RS-13_13 |
| T1 % | Anzeigekachel, Beschriftung „T1 %“, Wert mit drei Nachkommastellen (Beispiel „0,000“) | prozentuales Verhältnis der Schlecht-Packungen von Tu1 zu Tu2; Einheit und Bezugsgröße offen (OP-29, OP-47) | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) (`StringFormat` `N3`) | RS-13 Nr. 14 (kein Bild) |
| Schlecht Packungen | Zählkachel (Beispiel „1528“), Symbol `Icon.Status.Warning` und Wort „Schlecht“ | Anzahl schlechter Packungen seit dem letzten „Zähler löschen“; Warnsymbol statt rotem Kreuz, weil „schlecht“ ein Qualitätsurteil und kein Alarm ist (Annahme S13-2, analog A-55) | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) (Einheit „Stk“) | RS-13 Nr. 15, Bild RS-13_14 |
| Taste „Zähler löschen“ | Aktionstaste mit Schlüsselsymbol, Höhe `Size.Touch.Default` | setzt alle Zählwerte der Seite auf 0 (Gut, Schlecht, Zähler Übergewicht, TU 1, TU 2; Auslegung S13-3); öffnet vorher das Bestätigungs-Pop-up (Annahme S13-1) | [HM-07](../Module/HM-07_Aktionstaste.md) (`RequiresPermission`); Pop-up [HM-14](../Module/HM-14_Popup-Rahmen.md) | RS-13 Nr. 17 |

### Funktionsleiste unten (seitenspezifische Tasten)
| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Taste „Trend“ | Aktionstaste (Navigation) mit Liniendiagramm-Symbol `Icon.Nav.Trend`, erste Taste links | zeigt den Verlauf der letzten Gewichte in einem Diagramm; öffnet [HS-15](HS-15_Trend.md) | [HM-06](../Module/HM-06_Funktionsleiste.md) mit [HM-07](../Module/HM-07_Aktionstaste.md) | RS-13 Nr. 18 |
| Taste „Einzelgewichte“ | Aktionstaste (Navigation) mit Listensymbol `Icon.Nav.List`, zweite Taste links | zeigt bis zu 50 letzte Gewichte tabellarisch; öffnet [HS-14](HS-14_Einzelgewichte.md) | [HM-06](../Module/HM-06_Funktionsleiste.md) mit [HM-07](../Module/HM-07_Aktionstaste.md) | RS-13 Nr. 19 |

### Rahmenelemente (nicht in den Handbuchtabellen, laut Seitenbild RS-13_01)
| Element der Referenz | Ort im neuen HMI | verwendetes Modul | Herkunft |
|---|---|---|---|
| Kopfzeile mit Logo, Seitentitel „Kontrollwaage“, Uhrzeit, Datum | Kopfzeile (Logo, Uhr/Datum); der Seitentitel ist das letzte Brotkrümel-Segment „Kontrollwaage“ | [HM-02](../Module/HM-02_Kopfzeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | Seitenbild |
| Wirbel-/Spiralsymbol rechts neben dem Titel (im Handbuch nicht erklärt) | entfällt als eigenes Element; Betriebsart in der Kopfzeile (A-48) | [HM-02](../Module/HM-02_Kopfzeile.md) | Seitenbild, OP-26 |
| Meldezeile „*450* Palettierung nicht bereit“ (rot) | Meldezeile in der Kopfzeile, Format „450: Palettierung nicht bereit“ mit Statussymbol und Klassenwort; Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | Seitenbild, RS-38 |
| Vorhängeschloss (gelb, geschlossen) in der Funktionsleiste | Benutzerkreis in der Seitenleiste (Benutzer-Pop-up), Schloss/Schlüssel an den Feldern | [HM-01](../Module/HM-01_Seitenleiste.md) | Seitenbild, A-35, OP-26 |
| Tasten „Produktion“, „Einstellungen“, „Zurück“ | Seitenleiste: Home, Einstellungen, Zurück (Verlauf) | [HM-01](../Module/HM-01_Seitenleiste.md) | Seitenbild, A-35 |
| Kennzahlen Geschwindigkeit und Maschinenwinkel (Rahmen) | Brotkrümelzeile (Rahmen, nicht Seiteninhalt) | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | Rahmen nach Designsystem |

## Verwendete Module (IDs)
- [HM-01](../Module/HM-01_Seitenleiste.md) – Seitenleiste (Rahmen)
- [HM-02](../Module/HM-02_Kopfzeile.md) – Kopfzeile (Rahmen)
- [HM-03](../Module/HM-03_Meldezeile.md) – Meldezeile (Rahmen)
- [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) – Brotkrümel-Navigation (Rahmen)
- [HM-05](../Module/HM-05_Kennzahl-Kachel.md) – Kennzahl-Kachel (Netto, Brutto, Live, Mittelwert, S, Leistung Ist, Gut, T1 %, Schlecht)
- [HM-06](../Module/HM-06_Funktionsleiste.md) – Funktionsleiste unten (Trend, Einzelgewichte)
- [HM-07](../Module/HM-07_Aktionstaste.md) – Aktionstaste (Nullpunkt setzen, Zähler löschen, Navigationstasten, Pop-up-Tasten)
- [HM-11](../Module/HM-11_Anzeigefeld.md) – Anzeigefeld (Zählfelder unter den Grenzwerten)
- [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) – Eingabefeld mit Schlüsselsymbol (Sollgewicht, Tara, Automatischer Nullpunkt, Übergewicht, TU 1, TU 2)
- [HM-13](../Module/HM-13_Eingabe-Pop-up.md) – Eingabe-Pop-up (Ziffernblock)
- [HM-14](../Module/HM-14_Popup-Rahmen.md) – Pop-up-Rahmen (Bestätigungen)
- [HM-15](../Module/HM-15_Gruppenbereich.md) – Gruppenbereich, Variante Überschrift (fünf Gruppen)

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
**Zugang und Zurück.** Die Seite öffnet aus HS-42 (Kachel „Kontrollwaage“). „Zurück“ (Seitenleiste) führt im Verlauf zurück, normalerweise zu HS-42; das Brotkrümel-Segment „Waagen“ springt ebenfalls zu HS-42. Die Funktionsleistentasten „Trend“ und „Einzelgewichte“ legen HS-13 auf den Verlaufsstapel; „Zurück“ aus HS-14/HS-15 kehrt hierher zurück. Navigation ändert keinen Maschinenzustand.

**Anzeigen.** Alle Kennzahlkacheln und Zählfelder sind reine Anzeige, aktualisiert mit jeder Wägung. Ungültiger oder fehlender Wert: Text „---“ (HM-05/HM-11). Der Live-Wert kann negativ sein (Beispiel −399,0 g); das Vorzeichen ist Teil des Texts. Anzeigewerte in `Brush.Text.Primary`, Einheiten in `Brush.Text.Secondary`.

**Eingabefelder (Berechtigung).** Sollgewicht, Tara, Automatischer Nullpunkt, Übergewicht, Untergewicht TU 1 und TU 2 tragen das Schlüsselsymbol (`Icon.Key`, Textfarbe, nicht gelb). Mit Berechtigung öffnet Antippen das Eingabe-Pop-up [HM-13](../Module/HM-13_Eingabe-Pop-up.md) (Titel = Feldname, aktueller Wert, Grenzen mit Einheit, „Übernehmen“/„Abbrechen“). Ohne Berechtigung zeigt das Feld `Icon.Lock`; Antippen öffnet das Benutzer-Pop-up zur Anmeldung bzw. den Hinweis „Berechtigung erforderlich: <Rolle>“; nach erfolgreicher Anmeldung wird die Eingabe fortgesetzt. Die Rolle je Feld ist offen (OP-25, OP-04). Der alte rote Eingabewert entfällt (Rot nur für Fehler).

**Fehlerfälle.** Ungültige Eingabe (außerhalb der konfigurierten Grenzen): Übernehmen im Pop-up gesperrt; Fehlerzustand mit Kontur `Border.Thick` `Brush.Status.Error.Fg`, Fläche `Brush.Status.Error.Subtle`, `Icon.Status.Error` und Fehlertext. Wertebereiche sind konfigurierbare Dummy-Werte (OP-28); eine Beziehungsprüfung (z. B. Übergewicht > Sollgewicht > TU 1 ≥ TU 2) ist in der Quelle nicht beschrieben und wird nicht erfunden. Kommunikationsausfall der Waage: Werte „---“ und Meldung in der Meldezeile.

**Automatischer Nullpunkt.** Eingabe 0 deaktiviert die Funktion; das Feld zeigt zusätzlich das Wort „Aus“. Der Zusatzzähler zeigt die Packungen seit dem letzten Nullpunkt und läuft weiter, solange die Funktion aktiv ist.

**Taste „Nullpunkt setzen“.** Mit Berechtigung öffnet Antippen ein Bestätigungs-Pop-up (HM-14): Titel „Nullpunkt setzen“, Text „Die Waage muss unbelastet und sauber sein.“, Tasten „Ja“ (Hauptaktion) und „Abbrechen“. Erst „Ja“ setzt den Nullpunkt neu. Ohne Berechtigung: Schloss, Hinweis, keine Aktion. Das Handbuch beschreibt keine Rückfrage; sie ist eine Ergänzung (Annahme S13-1, OP-31).

**Taste „Zähler löschen“.** Mit Berechtigung öffnet Antippen ein Bestätigungs-Pop-up „Alle Zähler dieser Seite auf 0 setzen?“ mit „Ja“/„Abbrechen“; „Ja“ setzt die fünf Zählwerte (Gut, Schlecht, Zähler Übergewicht, TU 1, TU 2) auf 0 und aktualisiert T1 %. Der Zusatzzähler im Feld Automatischer Nullpunkt wird nicht zurückgesetzt (Auslegung S13-3, offen). Ein Pop-up zur Zeit; Seitenleiste, Funktionsleiste und Brotkrümel sind dahinter gesperrt (Navigation.md Abschnitt 4.2).

**Sperrzustände.** Das Verhalten bei laufender Produktion ist im Handbuch nicht beschrieben (OP-31). Vorgesehen ist der Zustand „deaktiviert“ nach Designsystem Abschnitt 5 (gestrichelte Kontur, `Brush.Text.Disabled`, Grund per Tippen in der Meldezeile); die Bedingungen sind offen. Berechtigung und Deaktivierung zeigen gemeinsam Schloss und gestrichelte Kontur.

**Ausschuss-Logik (Anzeige, keine Bedienung).** Die Zähler Übergewicht, TU 1 und TU 2 zählen nur; die Einstufung gut/schlecht und das Auswerfen erfolgen in der Maschine. Der Begriff „Guthaben“ bei TU 1 ist nicht erklärt (OP-47) und wird unverändert übernommen.

## Prüfpunkte (Tabelle: ID | Prüfung | erwartetes Ergebnis | Status)
Die Punkte HS-13-P01 bis P15 sind die Entsprechung der Prüfpunkte RS-13-P01 bis P15 (Nummer gleich); ab P16 folgen Punkte aus Designsystem und Navigation.

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-13-P01 | Brotkrümel und Zugang (RS-13-P01) | Brotkrümel „Einstellung › Waagen › Kontrollwaage“; Seite öffnet aus HS-42 über die Kachel „Kontrollwaage“; „Zurück“ führt zu HS-42; Segmente „Einstellung“ und „Waagen“ sind antippbar | offen |
| HS-13-P02 | Seitentitel (RS-13-P02) | letztes Brotkrümel-Segment lautet „Kontrollwaage“; kein Titel „Kontrollwaage KW“ | offen |
| HS-13-P03 | Netto, Brutto, Live (RS-13-P03) | drei Kacheln mit Waagensymbol und Einheit g, Format `N1`; Netto = berechnetes Nettogewicht, Brutto = Bruttogewicht inklusive Tara, Live = ungefilterter Rohwert (negativer Wert wie „−399,0 g“ wird mit Vorzeichen angezeigt) | offen |
| HS-13-P04 | Mittelwert, S, Leistung Ist (RS-13-P04) | Mittelwert und Standardabweichung in g, Leistung Ist in 1/min, jeweils mit Symbol (X̄, S, Tacho) und Beschriftung als Text | offen |
| HS-13-P05 | Sollgewicht, Tara (RS-13-P05) | zwei Eingabefelder in g mit Schlüsselsymbol; Beschriftung „Sollgewicht“ (Zielgewicht für die Hauptdosierer) und „Tara“ (Gewicht der leeren Packung); Antippen öffnet HM-13 | offen |
| HS-13-P06 | Automatischer Nullpunkt (RS-13-P06) | Eingabe in Stk; Wert 0 deaktiviert die Funktion und zeigt „Aus“; Zusatzzähler unten rechts zeigt die Packungen seit dem letzten Nullpunkt | offen |
| HS-13-P07 | Übergewicht, TU 1, TU 2 mit Zählfeld (RS-13-P07) | drei Eingabefelder in g mit Schlüsselsymbol, darunter je ein Zählfeld; Beschriftungstexte „Übergewicht“, „Untergewicht TU 1“, „Untergewicht TU 2“; fachliche Bedeutung (nur Dokumentation, kein Bedienelement): Übergewicht gleich oder größer = schlecht und ausgeworfen; TU 1 gleich oder kleiner = schlecht, ausgeworfen wenn kein Guthaben mehr vorhanden; TU 2 gleich oder kleiner = schlecht und ausgeworfen | offen |
| HS-13-P08 | Zähler Gut und Schlecht (RS-13-P08) | beide zeigen die Anzahl seit dem letzten „Zähler löschen“; Gut mit `Icon.Status.Ok` und Wort „Gut“, Schlecht mit `Icon.Status.Warning` und Wort „Schlecht“ (nicht nur Farbe) | offen |
| HS-13-P09 | Anzeige T1 % (RS-13-P09) | Beschriftung „T1 %“, Wert mit drei Nachkommastellen (Beispiel „0,000“); Bedeutung (Dokumentation): prozentuales Verhältnis der Schlecht-Packungen von Tu1 zu Tu2 | offen |
| HS-13-P10 | Taste „Nullpunkt setzen“ (RS-13-P10) | vorhanden, Schlüsselsymbol, Höhe `Size.Touch.Default`; nach Bestätigung wird der Waagen-Nullpunkt neu gesetzt; der Hinweis „Waage unbelastet und sauber“ steht im Bestätigungs-Pop-up | offen |
| HS-13-P11 | Taste „Zähler löschen“ (RS-13-P11) | vorhanden, Schlüsselsymbol; nach Bestätigung stehen Gut, Schlecht, Zähler Übergewicht, TU 1 und TU 2 auf 0 | offen |
| HS-13-P12 | Navigation unten links (RS-13-P12) | Funktionsleiste: Taste „Trend“ (öffnet HS-15) und Taste „Einzelgewichte“ (öffnet HS-14), beide links beginnend, mit Symbol und Text | offen |
| HS-13-P13 | Symbole der Referenz-Bilder (RS-13-P13) | Waage (Netto, Brutto, Live), X̄, Tacho, Sollgewicht-Packung, Tara, Pfeile-gegen-Strich (Autom. Nullpunkt), Übergewicht, Tu1, Tu2, Gut-Haken, Schlecht-Kreuz als Vektorsymbole `Icon.*` vorhanden und zusätzlich beschriftet; keine Bitmaps | offen |
| HS-13-P14 | Vollständigkeit Tabelle 19 und 20 (RS-13-P14) | jede der 17 Zeilen Hauptbereich und 2 Zeilen Navigation ist im Layout wiederzufinden (Rückverfolgung in „Elemente“) | offen |
| HS-13-P15 | Funktionsleiste und Rahmen (RS-13-P15) | Trend, Einzelgewichte in der Funktionsleiste; Schloss, „Produktion“, „Einstellungen“, „Zurück“ der Referenz sind als Benutzerkreis, Home, Zahnrad, Zurück in der Seitenleiste vorhanden und nicht doppelt in der Funktionsleiste | offen |
| HS-13-P16 | Berechtigung | alle sechs Eingabefelder und beide Aktionstasten zeigen `Icon.Key` (berechtigt) bzw. `Icon.Lock` (nicht berechtigt); Schlüssel in `Brush.Text.Primary`, nicht gelb; ohne Berechtigung öffnet Antippen das Benutzer-Pop-up statt HM-13 | offen |
| HS-13-P17 | Eingabe und Fehler | Antippen eines berechtigten Felds öffnet HM-13 mit vorbelegtem Wert; ungültiger Wert: Übernehmen gesperrt, Fehlerzustand mit `Icon.Status.Error` und Fehlertext | offen |
| HS-13-P18 | Bestätigungen | „Nullpunkt setzen“ und „Zähler löschen“ lösen erst nach „Ja“ aus; „Abbrechen“ oder Kreuz lässt alles unverändert; Antippen außerhalb des Pop-ups schließt nicht | offen |
| HS-13-P19 | Farbe nur Status (Designsystem 1.2) | Eingabewerte nicht rot; kein Element der Seite nutzt Statusfarbe außer Gut-Symbol (Ok), Schlecht-Symbol (Warnung) und Fehlerzustände; Gruppen neutral | offen |
| HS-13-P20 | Zweiter Kanal | Gut/Schlecht, Berechtigung, Aus (Autom. Nullpunkt = 0), Deaktiviert und Fehler sind jeweils mit Symbol oder Text erkennbar | offen |
| HS-13-P21 | Touch-Ziele | Eingabefelder und Tasten mindestens `Size.Touch.Default` hoch, Trefferfläche nie unter `Size.Touch.Min`; Abstand zwischen Touch-Zielen mindestens `Size.Touch.Gap` | offen |
| HS-13-P22 | Tokens und Texte | keine Hex-, Pixel- oder Literalwerte; alle Texte (Beschriftungen, Einheiten, Pop-up-Texte) aus `.resx`; Schrift mindestens `Font.Size.Caption` | offen |
| HS-13-P23 | Raster bei 1920 × 1080 | Zeilenproportionen 4\* : 3\* : 3\* : 4\* : 3\*; alle Elemente sichtbar ohne Scrollen; Zählfeld unter Eingabefeld verdeckt nichts | offen |
| HS-13-P24 | Modale Regeln | bei offenem Pop-up sind Seitenleiste, Funktionsleiste, Brotkrümel und Seiteninhalt gesperrt; „Zurück“ der Seitenleiste ist gesperrt | offen |

## Offene Punkte
Verweise auf [Offene-Punkte.md](../../00_Plan/Offene-Punkte.md) (Seiten-Index RS-13): OP-25 (Berechtigungsstufen und Bedeutung des Schlüsselsymbols), OP-26 (Schloss und Wirbelsymbol), OP-27 (Farbbedeutung, rote Eingabewerte), OP-28 (Wertebereiche, Plausibilität), OP-29 (Einheit T1 %, Zusatzwert „104“), OP-30 (Eingabe-Pop-up undokumentiert), OP-31 (Sperrzustände und Rückfragen), OP-32 (Trend-Umfang 50/20/21), OP-34 (Abweichungen Beschriftung, z. B. „UntergewichtTU 1“), OP-35 (Quellfehler, fehlendes Leerzeichen), OP-47 (Kontrollwaage: Einheit T1 %, „Guthaben“, Kriterium gut/schlecht, Statistik-Intervall); außerdem OP-04 (Benutzer/Rollen). Zusätzliche Hinweise:

- Statistik-Intervall und -Größe von Mittelwert, S und Leistung Ist („zuletzt gewogene Packungen“) sind nicht angegeben (OP-47).
- Unterschied TU 1/TU 2 ist nur über den Satz „wenn kein Guthaben mehr vorhanden ist“ erkennbar; Beschriftung unverändert übernommen.

**Seitenannahmen (zur Aufnahme in Annahmen.md vorgeschlagen):**
- S13-1: „Nullpunkt setzen“ und „Zähler löschen“ erhalten ein Bestätigungs-Pop-up (HM-14 mit HM-07-Tasten). Begründung: löschende bzw. die Messung verändernde Aktion, OP-31, A-40; das Handbuch beschreibt nur den Bedienhinweis „Waage unbelastet und sauber“.
- S13-2: Das Symbol für „Schlecht Packungen“ ist ein Warndreieck mit Wort „Schlecht“ statt des roten Kreuz-Kreises der Referenz (Rot nur für Fehler/Alarm, A-55 analog).
- S13-3: „Zähler löschen“ setzt die fünf Zählfelder (Gut, Schlecht, Zähler Übergewicht, TU 1, TU 2) zurück; der Zusatzzähler im Feld Automatischer Nullpunkt gehört nicht dazu (zählt „seit dem letzten Nullpunkt“). Das Handbuch sagt nur „alle Zählwerte auf dieser Seite“.
- S13-4: Netto, Brutto, Live, Statistik und Zähler sind Anzeigekacheln HM-05 (nicht HM-11), weil die Referenz sie als Kennzahl-Kachel mit Symbol führt (RM-12 → HM-05).
- S13-5: Die Gruppen verwenden die Überschrift-Variante von HM-15, weil die Panel-Variante in den Zeilen mit Eingabefeld und Zähler die Mindesthöhen nicht einhält.
