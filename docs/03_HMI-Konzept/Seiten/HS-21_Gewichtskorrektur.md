# HS-21 – Gewichtskorrektur (Nachdosierer)

- Quelle: [RS-21](../../02_Referenz-Analyse/Seiten/RS-21_Gewichtskorrektur.md) (Zweck, Anwendung und Bedienung in 4 Schritten, 4 Hinweise, Elemente laut Referenzbild, Prüfpunkte; Text und Bild textgleich zu RS-18). Kein Design vorhanden (OP-07); Aufbau aus [Designsystem](../Designsystem.md) und den Modulen abgeleitet. Zugänge und Brotkrümel nach [Navigation.md](../Navigation.md).
- Navigationspfad: Einstellung › Dosierer › Nachdosierer › Gewichtskorrektur. Zugang: [HS-19](../Seiten/HS-19_Nachdosierer.md) Funktionsleiste „Gewichtskorrektur“. Zurück-Ziel: HS-19. Seitenschlüssel `PostDoserWeightCorrection` / `settings/dosers/post/weightcorrection`.

## Zweck

Wortgetreu (Handbuch): „Diese Seite dient der Korrektur und Feinabstimmung der Dosiergenauigkeit von Schneckendosierern. Durch die Eingabe mehrerer Soll-Ist-Wertepaare werden sogenannte Stützstellen definiert. Daraus berechnet die Steuerung eine Korrekturkurve, mit der die Dosierleistung über den gesamten Gewichtsbereich verbessert wird.“ Ablauf: Sollgewicht einstellen, Probe manuell dosieren, wiegen, Soll und Ist eintragen (mehrfach über den Arbeitsbereich), „Gewichtsanpassung“ berechnen. Ob die Daten für den Nachdosierer oder für alle Dosierer gelten, ist nicht belegt (OP-45); der Zugang und der Brotkrümel ordnen die Seite dem Nachdosierer zu.

## Aufbau (Bereiche, Layout)

Rahmen wie auf allen Seiten (Seitenleiste 3\*, Arbeitsbereich 37\*; Kopfzeile 4\*, Brotkrümel/Kennzahlen 3\*, Inhalt 34\*, Funktionsleiste 4\*). Der **Inhaltsbereich** (Außenrand `Size.Content.Margin`, 12-Spalten-Raster, Gutter `Space.M`) hat eine Zeile mit zwei Gruppenbereichen **8 : 4** Spalten, entsprechend den „linken zwei Dritteln“ der Referenz (Tabellen) und der rechten Spalte (Tasten und Sollgewicht).

```
Inhaltsbereich (12 Spalten, Gutter Space.M)
+---------------------------------------------------+----------------------+
| Stützstellen (8 Sp.)                              | Probe und Anpassung  |
|  Nr   SOLL [g]   IST [g]  |  Nr   SOLL [g]  IST [g]|  (4 Sp.)             |
|   1   18,00      20,00    |  11   0,00      0,00   |  Sollgewicht  [ g ]  |
|   2   22,00      24,00    |  12   0,00      0,00   |  [ Dosierer Auslösen  |
|   3    0,00       0,00    |  13   0,00      0,00   |    manuell ]         |
|  ...  (Zeilen 1 bis 10)   |  ... (Zeilen 11 bis 20)|  [ Gewichtsanpassung ]|
|  10    0,00       0,00    |  20   0,00      0,00   |  Gültige Stützstellen |
|                                                   |  n von 20 (Status)    |
|                                                   |  Ablauf (4 Schritte)  |
|                                                   |  [ Hinweise ]         |
+---------------------------------------------------+----------------------+
| Funktionsleiste: leer                                                     |
+--------------------------------------------------------------------------+
```

- **Gruppe links „Stützstellen“ (8 Spalten):** zwei Blöcke zu je 4 Spalten nebeneinander mit den Spaltenköpfen „SOLL“ und „IST“ (fett, `Font.Weight.Strong`; als Kopf der Wertespalten wie in der Referenz) und je 10 Zeilen aus Zeilennummer, Soll-Feld und Ist-Feld. Linker Block Zeilen 1 bis 10, rechter Block Zeilen 11 bis 20 (Annahme 13). Zeilenhöhe `Size.Touch.Min`, Abstand `Size.Touch.Gap` (HM-22); Kopfzeile plus 10 Zeilen plus Innenabstand ergeben rund 94 % der nutzbaren Inhaltshöhe, es wird nicht gescrollt.
- **Gruppe rechts „Probe und Anpassung“ (4 Spalten):** von oben das Eingabefeld „Sollgewicht:“, die Taste „Dosierer Auslösen manuell“, die Taste „Gewichtsanpassung“, die Statuszeile zu den Stützstellen (Zähler und Berechnungsergebnis), das Hinweis-Textfeld mit dem Kurzablauf (4 Schritte) und die Taste „Hinweise“. Die Reihenfolge entspricht der Referenz (Tasten oben, Sollgewicht darunter), jedoch mit dem Sollgewicht an erster Stelle, weil es der erste Schritt des Ablaufs ist (Handbuch: „rechts unten“, Abweichung der Ortsangabe der Referenz, RS-21 Offener Punkt 1).
- Die Funktionsleiste bleibt leer, aber sichtbar (Navigation.md 3.3).

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)

Das Referenzkapitel hat keine Funktionstabellen; die Quelle sind die vier Schritte „Anwendung und Bedienung“ (S1 bis S4), die vier „Hinweise zur optimalen Nutzung“ (H1 bis H4) und die „Elemente der Seite laut Screenshot“ (E). Beispielwerte aus dem Referenzbild sind keine Standardwerte (OP-28). Die Tabelle, das Sollgewicht und die beiden Tasten setzt das Kompositmodul [HM-22](../Module/HM-22_Gewichtskorrektur-Tabelle.md) um.

### Rahmen und Kopf

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-21) |
|---|---|---|---|---|
| Seitenleiste (Benutzerkreis, Home, Einstellungen, Meldungen, Zurück) | Rahmen | ersetzt Schloss, „Produktion“, „Einstellungen“, „Zurück“ der Referenz; „Zurück“ öffnet den obersten Verlaufseintrag (HS-19) | [HM-01](../Module/HM-01_Seitenleiste.md) | E: Funktionsleiste unten (Schloss, „Produktion“, „Einstellungen“, „Zurück“) |
| Kopfzeile: Logo, Betriebsart, Uhrzeit/Datum | Rahmen | Logo, Betriebsart statt Spiral-Symbol (OP-26), Uhrzeit und Datum | [HM-02](../Module/HM-02_Kopfzeile.md) | E: Kopfzeile |
| Meldezeile | Anzeige | aktuelle Meldung (Referenzbild „*450* Palettierung nicht bereit“); Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | E: Meldezeile |
| Brotkrümel „Einstellung › Dosierer › Nachdosierer › Gewichtskorrektur“ | Navigation | Seitenpfad; letztes Segment ersetzt den Titel „Gewichtskorrektur“ der Referenz; „Nachdosierer“ führt zu HS-19 | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | E: Kopfzeile (Titel) |
| Kennzahlen Geschwindigkeit, Maschinenwinkel | Anzeige | Rahmenkennzahlen | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | (Rahmen) |
| Funktionsleiste (leer) | Leiste ohne Tasten | bleibt sichtbar; keine Tasten wie in der Referenz | [HM-06](../Module/HM-06_Funktionsleiste.md) | E: Funktionsleiste (keine Tasten links) |

### Stützstellen-Tabelle (E, S3)

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-21) |
|---|---|---|---|---|
| Spaltenkopf „SOLL“ (zweimal, je Block) | Beschriftung | Spalte der verwendeten Sollgewichte | [HM-22](../Module/HM-22_Gewichtskorrektur-Tabelle.md) | E: Spaltenkopf „SOLL“ |
| Spaltenkopf „IST“ (zweimal, je Block) | Beschriftung | Spalte der gemessenen Istgewichte | HM-22 | E: Spaltenkopf „IST“ |
| SOLL-Felder linker Block (10) | Eingabefeld, Einheit g, 2 Nachkommastellen, ohne Schlüssel | Soll-Gewicht je Stützstelle; Bild „18,00 g“, „22,00 g“, 8 × „0,00 g“ | HM-22 mit [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) | E: SOLL-Felder linker Block |
| IST-Felder linker Block (10) | Eingabefeld, Einheit g, 2 Nachkommastellen, ohne Schlüssel | gemessenes Ist-Gewicht je Stützstelle; Bild „20,00 g“, „24,00 g“, 8 × „0,00 g“ | HM-22 mit HM-12 | E: IST-Felder linker Block |
| SOLL-Felder rechter Block (10) | Eingabefeld, Einheit g, 2 Nachkommastellen | wie oben; Bild 10 × „0,00 g“ | HM-22 mit HM-12 | E: SOLL-Felder rechter Block |
| IST-Felder rechter Block (10) | Eingabefeld, Einheit g, 2 Nachkommastellen | wie oben; Bild 10 × „0,00 g“ | HM-22 mit HM-12 | E: IST-Felder rechter Block |
| Zeilennummer 1 bis 20 | Beschriftung | macht die 20 Wertepaare zählbar (Annahme 13) | HM-22 | (neu, Rückverfolgung zu E: 2 × 10 Zeilen) |
| Zeilenzustand „leer“ / „gefüllt“ | Zustandsanzeige je Zeile | Wert „0,00 g“ = leer, Zeile in `Brush.Text.Secondary` ohne Haken; gefüllt: Haken `Icon.State.On`; „leere Felder bleiben unberücksichtigt“ | HM-22 | H3 |

### Probe und Anpassung (S1, S2, S4)

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-21) |
|---|---|---|---|---|
| Sollgewicht | Eingabefeld mit Schlüssel, Beschriftung fett, Einheit g, 1 Nachkommastelle | „Geben Sie rechts unten das gewünschte Zielgewicht ein (Sollgewicht). Dieses Gewicht wird bei der manuellen Dosierung verwendet.“ Bild 250,4 g | HM-22 mit HM-12 | S1; E: Feld „Sollgewicht:“ |
| Dosierer Auslösen manuell | Aktionstaste mit Schlüssel | „Verwenden Sie die Taste Dosierer Auslösen manuell, um eine Probe mit dem eingestellten Sollgewicht zu dosieren. Die Probe in einem Behälter auffangen und wiegen.“ | HM-22 mit [HM-07](../Module/HM-07_Aktionstaste.md) | S2; E: Taste „Dosierer Auslösen manuell“ |
| Gewichtsanpassung | Aktionstaste mit Schlüssel | „Nachdem mehrere Stützstellen eingetragen wurden, drücken Sie die Taste Gewichtsanpassung. Die Steuerung erstellt daraus eine Korrekturkennlinie, mit der das Dosierergebnis automatisch an das tatsächliche Verhalten des Systems angepasst wird.“ | HM-22 mit HM-07 | S4; E: Taste „Gewichtsanpassung“ |
| Statuszeile Stützstellen | Anzeige mit Symbol und Text | „Gültige Stützstellen: n von 20“ und Berechnungsergebnis („Mindestens 3 Stützstellen“, „Kennlinie berechnet“, „Soll und Ist erforderlich“); Empfehlung 5 bis 8 | HM-22 (`ValidPointCount`, `CalculationState`) | H1, S4 |
| Ablauf in 4 Schritten (Kurzfassung) | Hinweis-Textfeld (Art Info) | Kurzfassung der Schritte S1 bis S4 (Sollgewicht einstellen, Probe auslösen und wiegen, Soll und Ist eintragen, Gewichtsanpassung drücken) | [HM-27](../Module/HM-27_Hinweis-Textfeld.md) | S1 bis S4 |
| Hinweise | Aktionstaste (öffnet Pop-up), Symbol `Icon.Status.Info` | öffnet das Pop-up „Hinweise zur optimalen Nutzung“ mit dem vollständigen Handbuchtext (Annahme 12) | HM-07 | H1 bis H4 |

### Pop-up „Hinweise zur optimalen Nutzung“ (Pop-up, kein eigener Seitenschlüssel)

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-21) |
|---|---|---|---|---|
| Pop-up-Rahmen mit Titel und „Schließen“ | Pop-up | zeigt die vier Schritte (S1 bis S4) und die vier Hinweise (H1 bis H4) wortgetreu, `.resx`; schließt nur über „Schließen“ oder Kreuz | [HM-14](../Module/HM-14_Popup-Rahmen.md) | S1 bis S4, H1 bis H4 |
| H1 | Text | „Es sollten mindestens drei, besser fünf bis acht Stützstellen gleichmäßig über den gesamten Gewichtsbereich verteilt eingetragen werden.“ | HM-14 (Inhalt Text) | H1 |
| H2 | Text | „Die Werte sollten unter reproduzierbaren Bedingungen aufgenommen werden (z. B. gleiche Produkttemperatur, gleiche Füllhöhe).“ | HM-14 (Inhalt Text) | H2 |
| H3 | Text | „Tragen Sie nur gültige Messwerte ein – leere Felder bleiben unberücksichtigt.“ | HM-14 (Inhalt Text) | H3 |
| H4 | Text | „Diese Korrektur ist insbesondere bei nichtlinearer Dosiercharakteristik hilfreich (z. B. bei fein rieselnden oder klebrigen Produkten).“ | HM-14 (Inhalt Text) | H4 |

## Verwendete Module (IDs)

- [HM-01](../Module/HM-01_Seitenleiste.md) – Seitenleiste
- [HM-02](../Module/HM-02_Kopfzeile.md) – Kopfzeile (enthält HM-03)
- [HM-03](../Module/HM-03_Meldezeile.md) – Meldezeile
- [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) – Brotkrümel-Navigation
- [HM-05](../Module/HM-05_Kennzahl-Kachel.md) – Kennzahl-Kachel
- [HM-06](../Module/HM-06_Funktionsleiste.md) – Funktionsleiste unten (leer)
- [HM-07](../Module/HM-07_Aktionstaste.md) – Aktionstaste (Dosierer Auslösen manuell, Gewichtsanpassung, Hinweise)
- [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) – Eingabefeld mit Schlüsselsymbol
- [HM-13](../Module/HM-13_Eingabe-Pop-up.md) – Eingabe-Pop-up
- [HM-14](../Module/HM-14_Popup-Rahmen.md) – Pop-up-Rahmen (Eingabe, Hinweise)
- [HM-22](../Module/HM-22_Gewichtskorrektur-Tabelle.md) – Gewichtskorrektur-Tabelle
- [HM-27](../Module/HM-27_Hinweis-Textfeld.md) – Hinweis-Textfeld (Kurzablauf)

Fehlendes Modul: keines.

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

- **Eingabe-Pop-up.** Antippen eines Soll-, Ist- oder Sollgewicht-Felds öffnet HM-13 in HM-14 mit Titel (zum Beispiel „Stützstelle 3 – SOLL“ bzw. „Sollgewicht“), aktuellem Wert, Einheit g und Grenzen; „Übernehmen“ nur bei gültigem Wert, „Abbrechen“ verwirft, Antippen außerhalb schließt nicht. Das Pop-up ist in der Referenz nicht beschrieben (A-20, OP-30); Grenzen sind Dummy (OP-28).
- **Berechtigung.** In der Referenz trägt nur das Feld „Sollgewicht“ ein Schlüsselsymbol, die Tabellenfelder nicht. Das neue HMI übernimmt das: `Icon.Key` am Sollgewicht, an „Dosierer Auslösen manuell“ und an „Gewichtsanpassung“ (beide Tasten mit Schlüssel laut HM-22); ohne Rolle `Icon.Lock` und Hinweis „Berechtigung erforderlich: <Rolle>“ bzw. Benutzer-Pop-up. Die Stufen sind offen (OP-25, OP-04).
- **Gültige Stützstelle.** Eine Zeile zählt nur, wenn Soll und Ist größer als 0,00 g sind; „0,00 g“ gilt als leer und wird nicht berücksichtigt (Handbuch H3). Ist nur eines der beiden Felder gefüllt, zeigt die Zeile den Zustand Ungültig (`Brush.Status.Error.Subtle`, `Icon.Status.Error`, Text „Soll und Ist erforderlich“; Annahme aus HM-22).
- **Gewichtsanpassung.** Bei weniger als 3 gültigen Stützstellen berechnet die Taste nicht; die Statuszeile zeigt `Icon.Status.Warning` und „Mindestens 3 Stützstellen“ (Annahme 14, Handbuch: mindestens drei, besser fünf bis acht). Bei ungültigen Zeilen ebenfalls keine Berechnung. Bei Erfolg: `Icon.Status.Ok` und „Kennlinie berechnet“ (Zustand Berechnet). Rückmeldung nach „Gewichtsanpassung“ ist in der Referenz nicht beschrieben (RS-21 Offener Punkt 3).
- **Dosierer Auslösen manuell.** Dosiert eine Probe mit dem Wert aus „Sollgewicht“. Nicht zulässig im ungeeigneten Betriebszustand: Taste deaktiviert (gestrichelte Kontur, `Brush.Text.Disabled`), Antippen nennt den Grund in der Meldezeile (A-28); fachliche Regeln nicht belegt (Annahme 8).
- **Hinweise.** Taste „Hinweise“ öffnet das Pop-up (ein Pop-up zur Zeit, Seitenleiste und Inhalt gesperrt, Schließen nur über „Schließen“ oder Kreuz; Navigation.md 4.2).
- **Fehlerfälle.** Ungültiger Wert im Eingabe-Pop-up: Fehlertext mit Symbol, Übernehmen gesperrt. Fehler beim Schreiben der Stützstellen: Zeile im Zustand Fehler mit Text. Werte in Textfarbe, nicht in Rot.
- **Navigation.** Seitenleiste „Zurück“ → HS-19 (Verlauf); Brotkrümel „Nachdosierer“ → HS-19, „Dosierer“ → HS-41; Meldezeile → HS-38. Navigation ändert keinen Maschinenzustand.

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-21-P01 | Zweck (RS-21-P01) | Seite dient Korrektur und Feinabstimmung der Dosiergenauigkeit über Soll-Ist-Wertepaare (Stützstellen) und Korrekturkurve | offen |
| HS-21-P02 | Anwendung und Bedienung (RS-21-P02) | vier Schritte auffindbar und wortgetreu: Dosiergewicht einstellen, Manuelle Auslösung, Wert eintragen, Gewichtsanpassung berechnen (Pop-up und Kurzablauf) | offen |
| HS-21-P03 | Hinweise (RS-21-P03, RS-21-P10) | vier Hinweise zur optimalen Nutzung wortgetreu im Pop-up „Hinweise“, erreichbar über die Taste „Hinweise“ | offen |
| HS-21-P04 | Tabellenblöcke (RS-21-P04) | zwei Blöcke SOLL/IST mit je 10 Zeilen (20 Wertepaare), Werte in g mit zwei Nachkommastellen | offen |
| HS-21-P05 | Beispielwerte (RS-21-P05) | Dummy-Daten zeigen 18,00 g / 20,00 g und 22,00 g / 24,00 g in Zeile 1 und 2, übrige 0,00 g | offen |
| HS-21-P06 | Rechte Spalte (RS-21-P06) | Tasten „Gewichtsanpassung“ und „Dosierer Auslösen manuell“ und Feld „Sollgewicht“ mit Beispiel 250,4 g (1 Nachkommastelle) vorhanden | offen |
| HS-21-P07 | Bildbezug (RS-21-P07) | alle Elemente des Referenzbildes sind zugeordnet (Spaltenköpfe, 40 Felder, 2 Tasten, Sollgewicht, Rahmen) | offen |
| HS-21-P08 | Gewichtsanpassung (RS-21-P08) | Taste berechnet die Korrekturkennlinie aus den Stützstellen; leere Felder (0,00 g) bleiben unberücksichtigt; bei weniger als 3 gültigen Stützstellen Warnung mit Symbol und Text | offen |
| HS-21-P09 | Manuelle Dosierung (RS-21-P09) | „Dosierer Auslösen manuell“ dosiert mit dem Wert aus „Sollgewicht“ | offen |
| HS-21-P10 | Wiederverwendung (RS-21-P11) | Stützstellen-Tabelle ist HM-22, dasselbe Modul wie auf HS-18; Felder HM-12, Tasten HM-07 | offen |
| HS-21-P11 | Rahmenelemente (RS-21-P12) | Kopfzeile, Meldezeile, Seitenleiste (Benutzer, Home, Einstellungen, Zurück) vorhanden; Funktionsleiste sichtbar, leer | offen |
| HS-21-P12 | Brotkrümel (RS-21-P13) | „Einstellung › Dosierer › Nachdosierer › Gewichtskorrektur“ | offen |
| HS-21-P13 | Eingabe-Pop-up | jedes Eingabefeld öffnet HM-13 mit Einheit g und Grenzen; ungültiger Wert: Fehlertext mit Symbol | offen |
| HS-21-P14 | Berechtigung | Schlüsselsymbol an Sollgewicht und den zwei Tasten; ohne Rolle Schloss und Hinweis | offen |
| HS-21-P15 | Ungültige Zeile | nur Soll oder nur Ist gefüllt: Zeile mit Symbol und Text als ungültig gekennzeichnet, nicht nur über Farbe | offen |
| HS-21-P16 | Touch-Ziele | Tabellenfelder mindestens `Size.Touch.Min` hoch, Tasten und Sollgewicht mindestens `Size.Touch.Default` hoch, Abstand mindestens `Size.Touch.Gap` | offen |
| HS-21-P17 | Zweiter Kanal und Tokens | leer/gefüllt (Haken), ungültig, berechnet, gesperrt mit Symbol, Form oder Text; keine Hex- oder Pixelwerte; Texte aus `.resx` | offen |
| HS-21-P18 | Layout | Gruppen 8 : 4; die 20 Wertepaare passen ohne Scrollen in den Inhaltsbereich bei Zielauflösung 1920 × 1080 | offen |

## Offene Punkte

- OP-25 Berechtigungsstufen (Schlüssel nur am Sollgewicht); OP-04 Benutzer/Anmeldung.
- OP-28 Wertebereiche, Standardwerte und Darstellung leerer Felder (Bild zeigt „0,00 g“); OP-30 Eingabe-Pop-up und Rückmeldung nach „Gewichtsanpassung“.
- OP-33 Seitentitel Bild gegenüber Handbuch; OP-34 Abweichung der Ortsangabe („rechts unten“ gegenüber Bildmitte rechts).
- OP-39 fehlende Gewichtskorrektur je Dosierer (Geltungsbereich: Nachdosierer oder alle Dosierer); OP-45 Bezug „Sollgewicht“ (250,4 g) zu „Soll“ (250 g) in HS-19; Stützstellenzahl 3 bis 8 empfohlen gegenüber 20 Zeilen.
- OP-55 Seite ist bildidentisch mit RS-18 (gemeinsames Modul HM-22).
