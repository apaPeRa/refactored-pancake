# HS-05 – Zuführung Papier
- Quelle: [RS-05](../../02_Referenz-Analyse/Seiten/RS-05_Zufuehrung-Papier.md) (Handbuch Kapitel 5, Tabellen T5, T6, T7; Bild RS-05_01). Kein Design-Screenshot; Layout aus [Designsystem](../Designsystem.md) (Abschnitte 3.2, 3.3, 7) und den Modulen abgeleitet, Muster DS-03/DS-05   - Navigationspfad: Einstellung › Zuführungen › Papier (Zugang: HS-40, Kachel „Papier“; Zurück-Ziel: HS-40 über den Verlauf; [Navigation.md](../Navigation.md) Abschnitt 2)

## Zweck
Wortgetreu (Handbuch): „Auf dieser Seite werden die Einstellungen für die Packstoffrolle, die Klebestelle und der Kupplung vorgenommen.“ Die Seite stellt die Bremskennlinie der Papierrolle (Durchmesser und Bremsstellwerte), die Behandlung der Klebestelle (Auswurf) und die elektronische Kupplung zur Hauptmaschine (Verschiebung, Anhalteposition) ein und zeigt Messwerte (Rollendurchmesser, aktueller Bremsdruck) und zwei Zustände (Klebestelle erkannt, Sensor Klebestelle) an.

## Aufbau (Bereiche, Layout)
Rahmen nach [Designsystem](../Designsystem.md) Abschnitt 3.2. Der Inhaltsbereich (Außenrand `Size.Content.Margin`, Gutter `Space.M`, Abstand zwischen Gruppen `Space.L`) hat zwei Gruppenzeilen im 12-Spalten-Raster:

- **Zeile 1:** Gruppe „Packstoffrolle“ über alle **12** Spalten.
- **Zeile 2:** links Gruppe „Klebestelle“ (**6** Spalten), rechts Gruppe „Kupplung“ (**6** Spalten).

Die Referenz stapelt die drei Gruppen untereinander; die Reihenfolge Packstoffrolle, Klebestelle, Kupplung bleibt erhalten (Leserichtung links nach rechts, oben nach unten). Klebestelle und Kupplung stehen nebeneinander, damit der Warnhinweis der Kupplung (Papierriss) ohne Scrollen Platz hat. Zeilenhöhen: Inhalt bestimmt die Höhe (Zeile `Size.Touch.Default`, Abstand `Size.Touch.Gap`); die Summe der Gruppen bleibt kleiner als der Inhaltsbereich (kein Scrollen bei 1920 × 1080).

```
Inhaltsbereich (12 Spalten)
+------------------------------------------------------------------------+
| Packstoffrolle (HM-15)                                       Spalten 12|
|  Durchmesser Rollenende: [ 4 %  ⚿]      Bremse Stillstand:  [ 50 % ⚿]  |
|  Durchmesser Max.:       [ 100 % ⚿]     Bremse bei Max.:    [ 14 % ⚿]  |
|  Durchmesser Min.:       [ 10 % ⚿]      Bremse bei Min.:    [ 5 %  ⚿]  |
|  Durchmesser Rolle:      [ 100 % ]      Aktueller Bremsdruck:[ 50 % ]   |
+-----------------------------------+------------------------------------+
| Klebestelle (HM-15)      Spalten 6| Kupplung (HM-15)          Spalten 6|
|  Auswurf:   [ 3 Stk. ⚿]           |  Verschiebung:     [ 290 ° ⚿]      |
|  (o) Klebestelle erkannt: Aus     |  Anhalte Position: [ 180 ° ⚿]      |
|  (o) Sensor Klebestelle:  Aus     |  [!] Hinweis Papierriss (HM-27)    |
+-----------------------------------+------------------------------------+
Funktionsleiste: leer
```
(⚿ = Schlüsselsymbol `Icon.Key`; Skizze nur zur Orientierung.)

- **Packstoffrolle:** zwei gleich breite Hälften à 6 Spalten, je 4 Zeilen. Links die Durchmesser-Größen (Rollenende, Max., Min., Rolle), rechts die Bremsgrößen (Stillstand, bei Max., bei Min., Aktueller Bremsdruck); Zeile für Zeile entsprechen die Paare der Reihenfolge von T5 und dem Bild. Beschriftung links, Feld rechts (Beschriftung rechtsbündig zum Feld wie in der Referenz). Eingabefelder `Size.Touch.Default` hoch, Anzeigefelder in derselben Zeilenhöhe ausgerichtet.
- **Klebestelle:** Eingabefeld „Auswurf“ und darunter zwei Status-LED-Zeilen (je ≥ `Size.Touch.Min` hoch).
- **Kupplung:** zwei Eingabefelder untereinander, darunter das Hinweis-Textfeld mit der Warnung aus dem Handbuch.
- **Funktionsleiste:** leer, aber sichtbar (Navigation.md 3.3: HS-05 ohne eigene Tasten).
- **Beschriftungen:** Bildbeschriftung gilt für die Anzeige, Handbuchtext für die Funktion (OP-34); die Schreibweise („Durchmesser Max:“ ohne Punkt) wird einheitlich in der `.resx` festgelegt. Das Layout plant +40 % Textbreite ein.

## Elemente

Spalte „Herkunft“ = Rückverfolgung auf RS-05 (T5/T6/T7 Zeile, Bild, Rahmenelemente). Beschreibungen wortgetreu aus RS-05 als Hilfetext (`AutomationProperties.HelpText`). Wertebereiche, Standardwerte und Berechtigungsstufe nennt die Quelle nicht (OP-28, OP-25): angegeben ist der Beispielwert aus dem Bild; die Grenzen sind konfigurierbare Dummy-Werte (A-50).

### Gruppe „Packstoffrolle“ (T5, 8 Zeilen)

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Durchmesser Rollenende | Eingabefeld mit Schlüssel, Einheit %, Beispiel 4 % | „Prozentualer Füllstand der Rolle, ab dem die Meldung *Rollenende* ausgegeben wird. Diese Meldung führt zum Stopp der Maschine.“ | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) | RS-05 T5 Zeile 1; Bild links oben |
| Bremse Stillstand | Eingabefeld mit Schlüssel, %, Beispiel 50 % | „Stellwert der an die Bremse gesendet wird, wenn die Maschine steht. Soll hoch genug sein um ein Abrollen zu verhindern aber nicht zu hoch, um ein übermäßiges Losbrechmoment zu vermeiden.“ | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) | RS-05 T5 Zeile 2; Bild rechts oben |
| Durchmesser Max | Eingabefeld mit Schlüssel, %, Beispiel 100 % (Bild „Durchmesser Max.:“) | „Oberer Durchmesser, ab dem die Bremse den Stellwert aus dem Feld *Bremse bei Max* als Stellwert erhält. Bei größeren Durchmessern steigt der Bremsdruck nicht weiter.“ | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) | RS-05 T5 Zeile 3; Bild links Zeile 2 |
| Bremse bei Max | Eingabefeld mit Schlüssel, %, Beispiel 14 % (Bild „Bremse bei Max.:“) | „Stellwert der Bremse bei dem Durchmesser welcher im Feld *Durchmesser Max* angegeben wird. Der Bremsdruck steigt im Betrieb nicht über diesen Wert hinaus.“ | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) | RS-05 T5 Zeile 4; Bild rechts Zeile 2 |
| Durchmesser Min | Eingabefeld mit Schlüssel, %, Beispiel 10 % (Bild „Durchmesser Min.:“) | „Unterer Durchmesser, ab dem die Bremse den Wert aus dem Feld *Bremse bei Min* als Stellwert erhält. Bei kleineren Durchmessern sinkt der Bremsdruck nicht weiter.“ | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) | RS-05 T5 Zeile 5; Bild links Zeile 3 |
| Bremse bei Min | Eingabefeld mit Schlüssel, %, Beispiel 5 % (Bild „Bremse bei Min.:“) | „Stellwert der Bremse bei dem Durchmesser welcher im Feld *Durchmesser Min* angegeben wird. Der Bremsdruck sinkt im Betrieb nicht unter diesen Wert.“ | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) | RS-05 T5 Zeile 6; Bild rechts Zeile 3 |
| Durchmesser Rolle | Anzeigefeld ohne Schlüssel, %, Beispiel 100 %, Wertebereich laut Text 0 % bis 100 % | „Aktueller gemessener Rollendurchmesser. 100% entspricht dem maximalen Durchmesser, welcher auf der Maschine gefahren wird. 0% dem Rollenkern. Bei deutlichen Abweichungen sollte der Sensor zur Durchmessermessung geprüft und gegebenenfalls neu justiert werden.“ | [HM-11](../Module/HM-11_Anzeigefeld.md) | RS-05 T5 Zeile 7; Bild links Zeile 4 (schwarz, ohne Schlüssel) |
| Aktueller Bremsdruck | Anzeigefeld ohne Schlüssel, %, Beispiel 50 % (Bild „Aktuelle Bremswert:“, Text „Aktueller Bremsdruck“, OP-34) | „Aktuell an die Bremse gesendeter Stellwert.“ | [HM-11](../Module/HM-11_Anzeigefeld.md) | RS-05 T5 Zeile 8; Bild rechts Zeile 4 |
| Gruppenrahmen „Packstoffrolle“ | Gruppenbereich (Panel) | gliedert die acht Größen | [HM-15](../Module/HM-15_Gruppenbereich.md) | RS-05 Rahmenelemente „Gruppenrahmen“ |

### Gruppe „Klebestelle“ (T6, 3 Zeilen)

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Auswurf | Eingabefeld mit Schlüssel, Einheit Stk., Beispiel 3 Stk. | „Anzahl der Packungen, die bei Erkennung eines Klebestreifens ausgeworfen werden. Die Packungen werden um die erkannte Klebestelle herum als schlecht markiert. Bei einem Wert von 3 werden die betroffene Packung als schlecht markiert und je eine Packung davor und danach.“ | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) | RS-05 T6 Zeile 1; Bild Gruppe Klebestelle links |
| Klebestelle erkannt | Status-LED mit Beschriftung und Zustandswort (Aus: Symbol `Icon.Status.Inactive`, Wort „Nicht erkannt“; Ein: Symbol `Icon.Status.Ok`, Wort „Erkannt“) | „Zeigt an, ob im letzten Takt eine Klebestelle erkannt wurde.“ | [HM-09](../Module/HM-09_Status-LED.md) | RS-05 T6 Zeile 2; Bild runde LED (grau = Aus) |
| Sensor Klebestelle | Status-LED mit Beschriftung und Zustandswort (Aus „Aus“, Ein „Ein“) | „Zeigt den aktuellen Status des Eingangs für den Klebestellensensor an.“ | [HM-09](../Module/HM-09_Status-LED.md) | RS-05 T6 Zeile 3; Bild runde LED (grau = Aus) |
| Gruppenrahmen „Klebestelle“ | Gruppenbereich (Panel) | gliedert die drei Elemente | [HM-15](../Module/HM-15_Gruppenbereich.md) | RS-05 Rahmenelemente |

### Gruppe „Kupplung“ (T7, 2 Zeilen)

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Verschiebung | Eingabefeld mit Schlüssel, Einheit °, Beispiel 290 ° | „Einstellung der elektronischen Kupplung zur Hauptmaschine. Muss angepasst werden, wenn der Papierabzug nicht mit der Position des Dornrads übereinstimmt. Die Einstellung kann im Stillstand oder während der Produktion erfolgen. Beim Verstellen bewegt sich die Zuführung – eine Bewegung in beide Richtungen ist möglich, was zu einem Papierriss führen kann“ (Satz im Quelltext ohne Punkt, OP-35) | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) | RS-05 T7 Zeile 1; Bild Gruppe Kupplung links |
| Anhalte Position | Eingabefeld mit Schlüssel, Einheit °, Beispiel 180 ° | „Position, an der die Zuführung zum Stillstand kommt, wenn sie ausgekoppelt wird.“ | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) | RS-05 T7 Zeile 2; Bild Gruppe Kupplung rechts |
| Hinweis zur Verschiebung | Hinweis-Textfeld, Art Warnung (`Icon.Status.Warning`, Wort „Warnung“) | dauerhaft sichtbarer Text „Beim Verstellen bewegt sich die Zuführung in beide Richtungen; Papierriss möglich.“ (Warnung aus der Beschreibung von „Verschiebung“; Ergänzung als sichtbares Element, kein Pop-up in der Quelle, Annahme) | [HM-27](../Module/HM-27_Hinweis-Textfeld.md) | RS-05 Zustände „Kupplung“ und Offene Punkte 8 |
| Gruppenrahmen „Kupplung“ | Gruppenbereich (Panel) | gliedert Verschiebung, Anhalte Position, Hinweis | [HM-15](../Module/HM-15_Gruppenbereich.md) | RS-05 Rahmenelemente |

### Rahmen und Pop-up

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Logo, Uhrzeit, Datum | Kopfzeile | Anzeige | [HM-02](../Module/HM-02_Kopfzeile.md) | RS-05 Rahmenelemente „Logo, Titel, Spiralsymbol, Uhrzeit und Datum“ |
| Spiralsymbol (Referenz) | Symbol | wird als Betriebsart geführt (A-48) | [HM-02](../Module/HM-02_Kopfzeile.md) | RS-05 Rahmenelemente (OP-26) |
| Titel „Zuführung Papier“ | Text | entfällt als eigenes Element; letztes Segment des Brotkrümels („Papier“) | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | RS-05 Bild Titel |
| Meldezeile | Anzeige und Taste | Beispielmeldung „\*450\* Palettierung nicht bereit“; Antippen öffnet HS-38; hier erscheint auch die Meldung „Rollenende“ | [HM-03](../Module/HM-03_Meldezeile.md) | RS-05 Rahmenelemente „Meldezeile (rot)“ |
| Seitenleiste mit Benutzerkreis, Home, Einstellungen, Meldungen, Zurück | Navigation | ersetzt Schloss und die Tasten „Produktion“, „Einstellungen“, „Zurück“ der Fußleiste (A-35) | [HM-01](../Module/HM-01_Seitenleiste.md) | RS-05 Rahmenelemente „Schloss-Symbol und Tasten“ |
| Brotkrümel, Kennzahlen Geschwindigkeit und Maschinenwinkel | Navigation und Anzeige | Pfad Einstellung › Zuführungen › Papier; Kennzahlen im Rahmen | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | Rahmen des Designs (A-35, Navigation.md) |
| Funktionsleiste (leer) | Container | ohne Tasten | [HM-06](../Module/HM-06_Funktionsleiste.md) | RS-05 Bild (links unten keine Taste); Navigation.md 3.3 |
| Eingabe-Pop-up | Pop-up (Ziffernblock) | öffnet beim Antippen jedes Eingabefelds mit Titel, aktuellem Wert, Grenzen, „Übernehmen“, „Abbrechen“ (Annahme A-20, nicht im Handbuch) | [HM-13](../Module/HM-13_Eingabe-Pop-up.md), [HM-14](../Module/HM-14_Popup-Rahmen.md) | RS-05 Verwendete Module (RM-06 „vermutet“) |

Summe: 13 Datenzeilen aus T5/T6/T7 (8 + 3 + 2): 9 Eingabefelder mit Schlüssel (6 Bremsparameter und Durchmesser, Auswurf, 2 Kupplung), 2 Anzeigefelder, 2 Status-LEDs.

## Verwendete Module (IDs)

- [HM-01](../Module/HM-01_Seitenleiste.md) – Seitenleiste
- [HM-02](../Module/HM-02_Kopfzeile.md) – Kopfzeile
- [HM-03](../Module/HM-03_Meldezeile.md) – Meldezeile
- [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) – Brotkrümel-Navigation
- [HM-05](../Module/HM-05_Kennzahl-Kachel.md) – Kennzahl-Kachel
- [HM-06](../Module/HM-06_Funktionsleiste.md) – Funktionsleiste unten
- [HM-09](../Module/HM-09_Status-LED.md) – Status-LED
- [HM-11](../Module/HM-11_Anzeigefeld.md) – Anzeigefeld
- [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) – Eingabefeld mit Schlüsselsymbol
- [HM-13](../Module/HM-13_Eingabe-Pop-up.md) – Eingabe-Pop-up
- [HM-14](../Module/HM-14_Popup-Rahmen.md) – Pop-up-Rahmen
- [HM-15](../Module/HM-15_Gruppenbereich.md) – Gruppenbereich
- [HM-27](../Module/HM-27_Hinweis-Textfeld.md) – Hinweis-Textfeld

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

- **Navigation:** Zugang nur über HS-40 (Kachel „Papier“); Zurück folgt dem Verlauf (HS-40), Brotkrümel-Segmente „Einstellung“ (HS-04) und „Zuführungen“ (HS-40) sind antippbar. Keine Unterseiten, keine seitenspezifischen Tasten. Auf HS-01 aktiviert die Taste „Zuführung Papier“ nur die Funktion und navigiert nicht (A-38).
- **Eingabefelder (HM-12):** Normal, Gedrückt, In Bearbeitung (Fokusrahmen `Border.Thick` und Pop-up), Fehler (Kontur `Border.Thick` `Brush.Status.Error.Fg`, Fläche `Brush.Status.Error.Subtle`, `Icon.Status.Error` und Text, z. B. „Wert außerhalb 0 bis 100 %“), Nicht berechtigt (`Icon.Lock`, kein Pop-up, Hinweis „Berechtigung erforderlich: <Rolle>“), Geändert/nicht geschrieben falls zutreffend. Der Wert steht in Textfarbe, nicht in Rot (Rot nur für Fehler, Designsystem 12).
- **Berechtigungen:** die neun Eingabefelder tragen das Schlüsselsymbol (RS-05-P06); Rolle und Stufe sind Dummy (OP-25, OP-04). Anzeigefelder („Durchmesser Rolle“, „Aktueller Bremsdruck“) tragen kein Symbol und sind nie bedienbar. Ohne Rolle öffnet das Antippen das Benutzer-Pop-up (Navigation.md 4.1); nach Anmeldung läuft die Eingabe weiter.
- **Eingabe-Pop-up (Annahme A-20/A-51):** Ziffernblock, vorbelegter Wert, Grenzen, „Übernehmen“ nur bei gültigem Wert, „Abbrechen“ verwirft; ein Pop-up zur Zeit, kein Schließen durch Antippen außerhalb. Wertebereiche und Plausibilitätsprüfung (z. B. Durchmesser Max größer als Min) nennt die Quelle nicht (OP-28, OP-30): die Grenzen sind konfigurierbare Dummy-Werte im ViewModel, keine fachlichen Regeln erfunden.
- **Bremskennlinie:** Stellwert zwischen „Durchmesser Min/Bremse bei Min“ und „Durchmesser Max/Bremse bei Max“, außerhalb auf dem jeweiligen Grenzwert, im Stillstand „Bremse Stillstand“ (Quelle; der Verlauf dazwischen ist nicht beschrieben, OP-27). Die Seite zeigt keine Kennlinie, nur die Werte.
- **Meldung „Rollenende“:** wird laut Quelle ausgegeben, wenn der Füllstand den Wert „Durchmesser Rollenende“ erreicht (Auslegung der Quelle); sie führt zum Stopp der Maschine. Sie erscheint in der Meldezeile (Klasse Störung, Symbol und Wort). Das Anzeigefeld „Durchmesser Rolle“ nimmt in dieser Lage den Grenzwertzustand von HM-11 an (Fläche `Brush.Status.Warning.Subtle`, `Icon.Status.Warning` und Text; Annahme).
- **Abweichung Durchmesser Rolle:** bei deutlichen Abweichungen soll der Durchmessersensor geprüft und gegebenenfalls neu justiert werden (Hinweis als Hilfetext des Feldes; kein eigener Zustand in der Quelle).
- **Status-LEDs (HM-09):** nur Anzeige, nicht bedienbar, kein Pressed-Zustand. Zustände Aus (Bild) und Ein (Farbe im Bild nicht dargestellt, OP-27) werden über Symbol und Wort gezeigt, nicht über Farbe; Aus = Inaktiv (leerer Kreis), Ein = erfüllt (Kreis mit Haken).
- **Kupplung während der Produktion:** „Verschiebung“ und „Anhalte Position“ bleiben auch während der Produktion bedienbar („im Stillstand oder während der Produktion“); der Warnhinweis bleibt dauerhaft sichtbar. Sperrzustände durch Betriebszustand sind nicht beschrieben (OP-31).
- **Modal:** bei offenem Pop-up sind Seitenleiste, Funktionsleiste, Brotkrümel und Felder gesperrt (Navigation.md 4.2); neue Meldungen bleiben in der Meldezeile sichtbar.
- **Wertdarstellung:** Wert, geschütztes Leerzeichen, Einheit (`4 %`, `3 Stk.`, `290 °`), Dezimalkomma; Einheiten und Beschriftungen aus `.resx`.

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-05-P01 | T5 „Packstoffrolle“ abgleichen (RS-05-P01) | alle 8 Größen (Durchmesser Rollenende, Bremse Stillstand, Durchmesser Max, Bremse bei Max, Durchmesser Min, Bremse bei Min, Durchmesser Rolle, Aktueller Bremsdruck) vorhanden, Beschreibung als Hilfetext | offen |
| HS-05-P02 | T6 „Klebestelle“ abgleichen (RS-05-P02) | Auswurf, Klebestelle erkannt und Sensor Klebestelle vorhanden, Beschreibungen als Hilfetext | offen |
| HS-05-P03 | T7 „Kupplung“ abgleichen (RS-05-P03) | Verschiebung und Anhalte Position vorhanden; die Warnung vor Papierriss ist als Hinweis-Textfeld sichtbar | offen |
| HS-05-P04 | Beispielwerte (RS-05-P04) | 4 %, 100 %, 10 %, 100 % (links) und 50 %, 14 %, 5 %, 50 % (rechts); Auswurf 3 Stk.; Verschiebung 290 °; Anhalte Position 180 ° als Dummy-Startwerte | offen |
| HS-05-P05 | Einheiten (RS-05-P05) | Durchmesser- und Bremsfelder in %, Auswurf in Stk., Verschiebung und Anhalte Position in °, jeweils mit geschütztem Leerzeichen | offen |
| HS-05-P06 | Eingabe gegenüber Anzeige (RS-05-P06) | 9 Eingabefelder mit Schlüsselsymbol (Wert in Textfarbe, nicht rot), 2 Anzeigefelder ohne Schlüssel (Durchmesser Rolle, Aktueller Bremsdruck) | offen |
| HS-05-P07 | Status-LEDs (RS-05-P07) | „Klebestelle erkannt“ und „Sensor Klebestelle“ sind LEDs mit Beschriftung, Symbol und Zustandswort; Aus-Zustand = leerer Kreis mit Wort, nicht nur grau | offen |
| HS-05-P08 | Beschriftungsabweichung (RS-05-P08) | „Aktueller Bremsdruck“ (Text) gegenüber „Aktuelle Bremswert“ (Bild) ist in `.resx` einheitlich benannt und im Offene-Punkte-Eintrag OP-34 dokumentiert | offen |
| HS-05-P09 | Gruppen und Layout (RS-05-P09) | drei Gruppenbereiche in der Reihenfolge Packstoffrolle, Klebestelle, Kupplung; Packstoffrolle zweispaltig mit 4 Zeilen; Klebestelle und Kupplung je 6 von 12 Spalten | offen |
| HS-05-P10 | Navigation und Rahmen (RS-05-P10) | Brotkrümel „Einstellung › Zuführungen › Papier“; Seitenleiste enthält Benutzerkreis (Schloss), Home, Einstellungen, Meldungen, Zurück; Meldezeile vorhanden; Funktionsleiste leer | offen |
| HS-05-P11 | Links (RS-05-P11) | Links auf RS-05, Navigation.md und alle HM lösen auf | offen |
| HS-05-P12 | Bremsparameter und Rollenende (RS-05-P12) | alle 6 Bremsparameter-Eingabefelder und 2 Anzeigewerte vorhanden; die Meldung „Rollenende“ erscheint in der Meldezeile und die Anzeige „Durchmesser Rolle“ nimmt den Grenzwertzustand an | offen |
| HS-05-P13 | Eingabe-Pop-up | Antippen eines Eingabefelds öffnet HM-13 mit Titel, Wert, Grenzen; „Abbrechen“ verwirft; Anzeigefelder öffnen nichts | offen |
| HS-05-P14 | Berechtigung | ohne Rolle: Schloss, kein Pop-up, Hinweis „Berechtigung erforderlich: <Rolle>“; mit Rolle: Schlüssel | offen |
| HS-05-P15 | Fehlerzustand | ungültige Eingabe zeigt Fehlerrahmen, `Icon.Status.Error` und Fehlertext, nicht nur Rot | offen |
| HS-05-P16 | Zurück-Verhalten | Zurück führt nach HS-40; Brotkrümel „Zuführungen“ springt nach HS-40, „Einstellung“ nach HS-04 | offen |
| HS-05-P17 | Touch-Ziele (Designsystem) | Eingabefelder `Size.Touch.Default` hoch und mindestens `Size.Touch.Min` breit, Abstand zwischen Feldern mindestens `Size.Touch.Gap`; Schlüsselsymbol kein eigenes Touch-Ziel | offen |
| HS-05-P18 | Zweiter Kanal (Designsystem) | LED-Zustand, Fehler, Warnung und Schloss/Schlüssel jeweils mit Symbol und Text; keine rote Wertschrift | offen |
| HS-05-P19 | Tokens und Layout (Designsystem) | keine Hex-, Pixel- oder Literaltexte; Gruppen belegen 12 + (6 + 6) Spalten; Inhalt passt ohne Scrollen in den Inhaltsbereich bei 1920 × 1080 | offen |
| HS-05-P20 | Hell-/Dunkelthema | beide Themen ohne Layoutänderung, alle Textpaare nach Designsystem-Kontrasten | offen |

## Offene Punkte
- OP-25: Berechtigungsstufen und Bedeutung des Schlüsselsymbols (Dummy-Rollen).
- OP-26: Bedeutung von Spiralsymbol und Schloss der Referenz (hier Betriebsart und Benutzerkreis).
- OP-27: Farbbedeutung (rote Schrift der Eingabewerte, LED-Zustand „an“), Verlauf der Bremskennlinie.
- OP-28: Wertebereiche, Standardwerte und Plausibilitätsregeln (Max größer Min usw.) fehlen.
- OP-30: Eingabe-Pop-up (Tastenfeld, Bestätigung, Bereichsprüfung) undokumentiert.
- OP-34: Beschriftungsabweichungen („Aktuelle Bremswert“/„Aktueller Bremsdruck“, „Durchmesser Max.:“).
- OP-35: Quellfehler (Satz bei „Verschiebung“ ohne Punkt).
- OP-31 (ergänzend): Sperrzustände während der Produktion nicht beschrieben.
- Zugang: Zwischenseite HS-40 „Zuführungen“ (OP-20, A-33).
