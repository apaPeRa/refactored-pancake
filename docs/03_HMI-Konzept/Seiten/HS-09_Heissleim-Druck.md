# HS-09 – Heißleim Druck

- Quelle: [RS-09](../../02_Referenz-Analyse/Seiten/RS-09_Heissleim-Druck.md) (Handbuch Kapitel 9, Tabellen T12 „Druckregelung“ und T13 „Gerätelimits“, Bild [RS-09_01](../../02_Referenz-Analyse/Medien/RS-09_01.png)). Es gibt keine Design-Seite; Aufbau und Optik sind aus dem [Designsystem](../Designsystem.md), den Modulen und der Schwesterseite [HS-07](HS-07_Heissleim-Nordson.md) (Design [DS-03](../../01_Design-Analyse/Seiten/DS-03_Heissleim.md)) abgeleitet.
- Navigationspfad: Einstellung › Zuführungen › Heißleim › Druck (Brotkrümel laut [Navigation.md](../Navigation.md), Abschnitt 2). Zugang: Funktionsleiste „Druck“ in [HS-07](HS-07_Heissleim-Nordson.md) (abgeleitet, A-14, OP-36). Zurück-Ziel: HS-07. PageKey `HotGluePressure`, Route `settings/feeders/hotglue/pressure`, Mindestrolle: jeder angemeldete Benutzer.
- Seitentitel (Ressource `Nav_HotGluePressure_Title`): „Heißleim Zuführung Druck“ (Bildtitel der Referenz, so in Navigation.md Abschnitt 2 festgelegt); der Kapitelname lautet „Heißleim Druck“ (OP-33). Im Inhaltsbereich steht kein eigener Titel, das letzte Brotkrümel-Segment „Druck“ ersetzt ihn.

## Zweck

Wortgetreu (Handbuch): „Auf dieser Seite werden alle druckrelevanten Parameter des Nordson-Heißleimgeräts eingestellt. Die Druckregelung erfolgt basierend auf der Fördergeschwindigkeit und den definierten Druckgrenzen. Zusätzlich werden Gerätegrenzwerte überwacht, um den sicheren Betrieb des Systems zu gewährleisten.“

Die Seite enthält zwei Gruppen: **Druckregelung** (zwei Geschwindigkeiten, zwei Zieldrücke, Anzeige des aktuellen Drucks) und **Gerätelimits** (zwei Drucklimits, zwei Toleranzwerte).

## Aufbau (Bereiche, Layout)

Rahmen wie im Designsystem Abschnitt 3.2. Der Inhaltsbereich nutzt das 12-Spalten-Raster, abgeleitet aus dem Designsystem: zwei gleich breite Gruppen **6 : 6** (die Referenz zeigt zwei Spalten, links 5 Zeilen, rechts 4 Zeilen). Jede Gruppe ist ein Panel mit gleich aufgebauten Zeilen: Beschriftung links, Wertfeld rechts, darunter die Beschreibung des Handbuchs als Caption. Zeilen sind Stern-Anteile mit den Mindesthöhen der Module; keine festen Pixelpositionen. Die Funktionsleiste ist leer, aber sichtbar.

```
Inhaltsbereich (12 Spalten)
+------------------------------------+------------------------------------+
| Panel (HM-15)                  6 Sp| Panel (HM-15)                  6 Sp|
| Druckregelung                      | Gerätelimits                       |
| Obere Geschwindigkeit  [120 1/min (K)] | Oberes Drucklimit   [5,0 bar (K)] |
|   Caption                          |   Caption                          |
| Untere Geschwindigkeit [ 20 1/min (K)] | Unteres Drucklimit  [0,7 bar (K)] |
| Oberer Druck           [1,7 bar (K)]   | Überdruck Delta     [3,0 bar (K)] |
| Unterer Druck          [0,7 bar (K)]   | Unterdruck Delta    [0,3 bar (K)] |
| Aktueller Druck        [0,7 bar]       |                                    |
+------------------------------------+------------------------------------+
Funktionsleiste: leer                                 ((K) = Schlüsselsymbol)
```

| Bereich | Spalten / Zeilen | Inhalt |
|---|---|---|
| Linkes Panel „Druckregelung“ | 6 von 12 Spalten; fünf Zeilen | vier Eingabefelder (T12 Zeilen 1 bis 4) und die Anzeige „Aktueller Druck“ (T12 Zeile 5, ohne Schlüssel, optisch als Anzeigefeld abgesetzt: Fläche ohne Eingabe-Pop-up) |
| Rechtes Panel „Gerätelimits“ | 6 von 12 Spalten; vier Zeilen | vier Eingabefelder (T13 Zeilen 1 bis 4); der freie Platz unter der vierten Zeile bleibt leer (Zeilenraster der linken Gruppe) |

Die Panel-Überschriften stehen als Text ohne Unterstreichung ([HM-15](../Module/HM-15_Gruppenbereich.md), Hierarchie über Größe, Gewicht und Trennlinie). Beispielwerte sind Dummy-Werte aus dem Bild (OP-28).

## Elemente

Spalte „Herkunft“ stellt die Rückverfolgung zu RS-09 her. Alle fünf Zeilen von T12, alle vier Zeilen von T13 und alle Rahmenelemente sind enthalten.

### Rahmen

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Seitenleiste (Benutzerkreis, Home, Einstellungen, Meldungen, Zurück) | Rahmen | Navigation; „Zurück“ führt zu HS-07; Benutzerkreis ersetzt das gelbe Vorhängeschloss | [HM-01](../Module/HM-01_Seitenleiste.md) | RS-09 Rahmenelemente „Vorhängeschloss“, „Produktion/Einstellungen/Zurück“ (A-35) |
| Kopfzeile (Logo, Betriebsart, Uhrzeit/Datum) | Rahmen | Anzeige; das Wirbel-Symbol der Referenz entfällt (OP-26) | [HM-02](../Module/HM-02_Kopfzeile.md) | RS-09 Rahmenelemente „Kopfzeile“ |
| Meldezeile | Rahmen | aktuelle Meldung (z. B. Überdruck-, Unterdruckmeldung), Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | RS-09 Rahmenelemente „Meldezeile“ |
| Brotkrümel „Einstellung › Zuführungen › Heißleim › Druck“ | Navigation | Pfad; Segmente „Einstellung“, „Zuführungen“, „Heißleim“ antippbar (HS-04, HS-40, HS-07); ersetzt den Bildtitel | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | RS-09 Aufbau Kopfzeile (Titel) |
| Kennzahlen Geschwindigkeit und Maschinenwinkel | Anzeige | Geschwindigkeit öffnet HS-03 | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | Rahmen des Designs (DS-03) |
| Funktionsleiste (leer) | Rahmen | bleibt sichtbar, keine seitenspezifischen Tasten | [HM-06](../Module/HM-06_Funktionsleiste.md) | RS-09 Aufbau Punkt 4 (links leer) |

### Gruppe „Druckregelung“ (RS-09 Tabelle T12, fünf Zeilen)

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Panel „Druckregelung“ | Gruppenbereich (Panel mit Überschrift) | bündelt die fünf Zeilen | [HM-15](../Module/HM-15_Gruppenbereich.md) | RS-09 Überschrift „Druckregelung“ |
| Obere Geschwindigkeit | Eingabefeld mit Schlüsselsymbol, Einheit 1/min (Dummy 120 1/min) | „Oberer Maschinentakte (in 1/min) bei der, der obere Druck gilt.“ (Caption, Wortlaut der Referenz) | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), Pop-up [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | RS-09 T12 Zeile 1 |
| Untere Geschwindigkeit | Eingabefeld mit Schlüsselsymbol, Einheit 1/min (Dummy 20 1/min) | „Untere Maschinentakte (in 1/min) bei der, der untere Druck gilt.“ (Caption) | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | RS-09 T12 Zeile 2 |
| Oberer Druck | Eingabefeld mit Schlüsselsymbol, Einheit bar (Dummy 1,7 bar) | „Zielwert für den oberen Betriebsdruck.“ (Caption) | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | RS-09 T12 Zeile 3 |
| Unterer Druck | Eingabefeld mit Schlüsselsymbol, Einheit bar (Dummy 0,7 bar) | „Zielwert für den unteren Betriebsdruck.“ (Caption) | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | RS-09 T12 Zeile 4 |
| Aktueller Druck | Anzeigefeld, nur lesend, Einheit bar, ohne Schlüssel (Dummy 0,7 bar) | „Anzeige des aktuell anliegenden Systemdrucks.“ (Caption) | [HM-11](../Module/HM-11_Anzeigefeld.md) | RS-09 T12 Zeile 5 |

### Gruppe „Gerätelimits“ (RS-09 Tabelle T13, vier Zeilen)

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Panel „Gerätelimits“ | Gruppenbereich (Panel mit Überschrift) | bündelt die vier Zeilen | [HM-15](../Module/HM-15_Gruppenbereich.md) | RS-09 Überschrift „Gerätelimits“ |
| Oberes Drucklimit | Eingabefeld mit Schlüsselsymbol, Einheit bar (Dummy 5,0 bar) | „Maximal zulässiger Druck im Prozess. Wird dieser überschritten, erfolgt eine Abschaltung.“ (Caption) | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | RS-09 T13 Zeile 1 |
| Unteres Drucklimit | Eingabefeld mit Schlüsselsymbol, Einheit bar (Dummy 0,7 bar) | „Minimal zulässiger Druck im Prozess. Bei Unterschreitung kann eine Störung ausgelöst werden.“ (Caption) | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | RS-09 T13 Zeile 2 |
| Überdruck Delta | Eingabefeld mit Schlüsselsymbol, Einheit bar (Dummy 3,0 bar) | „Toleranzwert oberhalb des Sollwerts, bevor eine Überdruckmeldung erfolgt.“ (Caption) | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | RS-09 T13 Zeile 3 |
| Unterdruck Delta | Eingabefeld mit Schlüsselsymbol, Einheit bar (Dummy 0,3 bar) | „Toleranzwert unterhalb des Sollwerts, bevor eine Unterdruckmeldung erfolgt.“ (Caption) | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | RS-09 T13 Zeile 4 |

Die Schreibweisen der Handbuchtexte („Maschinentakte“) werden unverändert in die `.resx` übernommen und dort nach Klärung korrigiert (OP-35). Alle Zahlen erscheinen mit geschütztem Leerzeichen vor der Einheit (`1,7 bar`, `120 1/min`).

## Verwendete Module

[HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md), [HM-11](../Module/HM-11_Anzeigefeld.md), [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](../Module/HM-13_Eingabe-Pop-up.md), [HM-14](../Module/HM-14_Popup-Rahmen.md) (trägt HM-13), [HM-15](../Module/HM-15_Gruppenbereich.md).

## Zustände und Interaktion

- **Druckregelung:** erfolgt „basierend auf der Fördergeschwindigkeit und den definierten Druckgrenzen“ (Handbuch). Der Verlauf zwischen oberem und unterem Druck zwischen den beiden Geschwindigkeiten ist nicht beschrieben (OP-46) und wird nicht dargestellt.
- **Gerätelimits:** Wird das obere Drucklimit überschritten, erfolgt eine Abschaltung; bei Unterschreitung des unteren Drucklimits „kann eine Störung ausgelöst werden“; Überdruck Delta und Unterdruck Delta sind Toleranzen, nach denen eine Überdruck- bzw. Unterdruckmeldung erfolgt. Diese Ereignisse erscheinen als Meldung in der Meldezeile ([HM-03](../Module/HM-03_Meldezeile.md)); eigene Statusanzeigen auf der Seite gibt es nicht (Referenz und Handbuch beschreiben keine). Meldungstexte sind nicht beschrieben.
- **Aktueller Druck:** nur Anzeige. Liegt der Wert außerhalb der Limits (Annahme): Anzeigefeld im Zustand „Grenzwert verletzt“ mit `Icon.Status.Warning` und Text ([HM-11](../Module/HM-11_Anzeigefeld.md)). Bei ungültigem Wert (Kommunikationsfehler) „---“.
- **Eingabe:** Antippen eines Eingabefelds (acht Felder) öffnet das Eingabe-Pop-up ([HM-13](../Module/HM-13_Eingabe-Pop-up.md) im [HM-14](../Module/HM-14_Popup-Rahmen.md)) mit vorbelegtem Wert, Einheit und Dummy-Grenzen; „Übernehmen“ nur bei gültigem Wert, „Abbrechen“ verwirft. Plausibilitätsregeln zwischen den Feldern (z. B. oberes Drucklimit größer als oberer Druck) nennt die Quelle nicht (OP-28, OP-46) und werden nicht erfunden; die Dummy-Grenzen sind je Feld einzeln konfigurierbar.
- **Berechtigungen:** alle acht Eingabefelder tragen das Schlüsselsymbol (`Icon.Key`), „Aktueller Druck“ nicht. Ohne Rolle: `Icon.Lock` und Hinweis „Berechtigung erforderlich: <Rolle>“; das Benutzer-Pop-up öffnet über den Benutzerkreis (OP-04, OP-25).
- **Sperrzustände und Fehlerfälle:** durch den Betriebszustand gesperrte Felder sind deaktiviert (gestrichelte Kontur, Grund in der Meldezeile, A-28). Bei gestörter Kommunikation (Annahme): Anzeige „---“, Eingaben deaktiviert.
- **Navigation und Zurück:** „Zurück“ (Seitenleiste) führt zu HS-07; Segment „Heißleim“ im Brotkrümel springt dorthin, „Zuführungen“ zu HS-40, „Einstellung“ zu HS-04. Pop-ups stehen nicht im Verlauf; bei offenem Pop-up ist die Navigation gesperrt (Navigation.md 4.2).

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-09-P01 | Obere Geschwindigkeit (RS-09-P01) | Eingabefeld 1/min mit Schlüsselsymbol; Beispielwert 120 1/min; Caption „Oberer Maschinentakte …“ | offen |
| HS-09-P02 | Untere Geschwindigkeit (RS-09-P02) | Eingabefeld 1/min mit Schlüsselsymbol; Beispielwert 20 1/min | offen |
| HS-09-P03 | Oberer Druck (RS-09-P03) | Eingabefeld bar mit Schlüsselsymbol; Beispielwert 1,7 bar | offen |
| HS-09-P04 | Unterer Druck (RS-09-P04) | Eingabefeld bar mit Schlüsselsymbol; Beispielwert 0,7 bar | offen |
| HS-09-P05 | Aktueller Druck (RS-09-P05) | nur Anzeige in bar, ohne Schlüssel, nicht antippbar; Beispielwert 0,7 bar | offen |
| HS-09-P06 | Oberes Drucklimit (RS-09-P06) | Eingabefeld bar; Beispielwert 5,0 bar; Caption: Abschaltung bei Überschreitung | offen |
| HS-09-P07 | Unteres Drucklimit (RS-09-P07) | Eingabefeld bar; Beispielwert 0,7 bar; Caption: Störung bei Unterschreitung möglich | offen |
| HS-09-P08 | Überdruck Delta (RS-09-P08) | Eingabefeld bar; Beispielwert 3,0 bar; Caption zur Überdruckmeldung | offen |
| HS-09-P09 | Unterdruck Delta (RS-09-P09) | Eingabefeld bar; Beispielwert 0,3 bar; Caption zur Unterdruckmeldung | offen |
| HS-09-P10 | Gruppierung (RS-09-P10) | zwei Panels „Druckregelung“ (5 Felder) und „Gerätelimits“ (4 Felder), Aufteilung 6 : 6 Spalten von 12 | offen |
| HS-09-P11 | Brotkrümel (RS-09-P11) | „Einstellung › Zuführungen › Heißleim › Druck“ (Abweichung vom Referenzpfad ist in Navigation.md begründet); drei Segmente antippbar | offen |
| HS-09-P12 | Rückweg (RS-09-P12) | „Zurück“, „Home“, „Einstellungen“ und Benutzerkreis in der Seitenleiste; „Zurück“ führt zu HS-07 | offen |
| HS-09-P13 | Quellbezug (RS-09-P13) | RS-09 mit Bild RS-09_01 im Kopf der Seite verlinkt; jede Zeile von T12 und T13 steht in der Elemente-Tabelle | offen |
| HS-09-P14 | Funktionsleiste | leer, aber sichtbar | offen |
| HS-09-P15 | Zweiter Kanal (Designsystem 5) | Grenzwertverletzung, Fehler, Sperre und Schlüssel/Schloss mit Symbol oder Text zusätzlich zur Farbe | offen |
| HS-09-P16 | Farbe nur Status | keine rote Eingabewertschrift, kein gelber Schlüssel | offen |
| HS-09-P17 | Touch (DSY-P04) | alle Eingabefelder mindestens `Size.Touch.Min`, Standard `Size.Touch.Default` hoch; Zeilenabstand mindestens `Size.Touch.Gap` | offen |
| HS-09-P18 | Tokens und Texte (DSY-P06, DSY-P07) | keine Hex- oder Pixelwerte, keine festen Texte im XAML; Captions aus `.resx`; Einheiten mit geschütztem Leerzeichen | offen |
| HS-09-P19 | Eingabe-Pop-up | jedes der acht Eingabefelder öffnet HM-13 im HM-14 mit vorbelegtem Wert; Seite dahinter gesperrt | offen |
| HS-09-P20 | Berechtigung | ohne Rolle: Schloss und Hinweis, kein Pop-up | offen |

## Offene Punkte

- OP-36: Zugang zur Seite im Handbuch nicht beschrieben, abgeleitet aus der Funktionsleiste von HS-07 (A-14).
- OP-25: Berechtigung (Schlüssel an Eingabefeldern, Rollen).
- OP-28: Wertebereiche und Standardwerte fehlen; Bildwerte sind Beispiele, im Bild sind „Unteres Drucklimit“ und „Unterer Druck“ beide 0,7 bar.
- OP-46: Druck-Sollwert und Delta (Bezug „Sollwert“ bei Überdruck-/Unterdruck Delta), Interpolation zwischen den Drücken, Meldungs- und Störungstexte nicht beschrieben.
- OP-33: Seitentitel (Bildtitel „Heißleim Zuführung Druck“ gegenüber Kapitelname „Heißleim Druck“).
- OP-35: Schreibweise der Handbuchtexte („Oberer Maschinentakte“).
