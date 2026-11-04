# HS-01 – Produktion
- Quelle: Referenz [RS-01](../../02_Referenz-Analyse/Seiten/RS-01_Produktion.md) (Funktion, Tabellen T1 und T2, Prüfpunkte); Design [DS-01](../../01_Design-Analyse/Seiten/DS-01_Produktion.md) mit Screenshot `src_Data/Design/Seite_Produktion.png` (Layout, Rahmen, Optik); Navigation: [Navigation.md](../Navigation.md)
- Navigationspfad: **Produktion** (Brotkrümel mit einem Segment, nur Anzeige). Zugang: Seitenleiste „Home“ und Startseite nach Anmeldung; „Zurück“ ist auf dieser Seite deaktiviert (Wurzel, Stapel `[]`). Seitenschlüssel `Production` / `production`.

## Zweck
Startseite im Betrieb. Wortgetreu (Referenz): „Die Hauptseite „Produktion“ dient der Überwachung und Steuerung der laufenden Produktionsprozesse. Sie ermöglicht es dem Bedienpersonal, wesentliche Funktionen direkt zu aktivieren bzw. zu deaktivieren und Betriebszustände in Echtzeit zu erkennen.“ Die Seite zeigt Geschwindigkeit, Produktionszähler, Gewichtskennzahlen und Versorgung auf einen Blick, schaltet die 16 Betriebsfunktionen der Referenz und führt über Symbole in die Pop-ups [HS-02](HS-02_Produktionszaehler.md) und [HS-03](HS-03_Maschinengeschwindigkeit.md). Die Seite navigiert sonst nicht: die Tasten „Zuführung Papier“, „Zuführung Karton“ und „Heizungen“ aktivieren Funktionen (A-38).

## Aufbau (Bereiche, Layout)
Rahmen (HM-01 bis HM-06) laut [Designsystem](../Designsystem.md) 3.2 unverändert. Der **Inhaltsbereich** (Außenrand `Size.Content.Margin`, Gutter `Space.M`) hat das 12-Spalten-Raster aus Designsystem 3.3 und zwei Zeilen im Verhältnis **11\* : 14\***; keine festen Pixelpositionen.

```
Inhaltsbereich, 12 Spalten
Zeile 1 (11*)  +----------+--------------+--------------+------------------+
               | Geschw.  | Produktion   | EKW          | Versorgung       |
               | (Sp. 2)  | (Sp. 3)      | (Sp. 3)      | (Sp. 4)          |
               | Soll  >  | Rezeptanw.   | Letztes Gew. | Druckluft   IO   |
               | Ist      | Akt. Prod. > | Mittelwert + | Papier      IO   |
               | [Schnell]| Letzte Prod. |  [Fortlauf.] | Produkt     IO   |
               |          |              | Std.abw.     | Linienbetrieb    |
               |          |              |              | Bandwaage Bereit |
               |          |              |              | Folgemasch. Läuft|
Zeile 2 (14*)  +----------+--------------+--------------+------------------+
               | Tastenblock 3 x 2 (Sp. 5)  | Umschalter-Gruppe (Sp. 7)     |
               | [Automatik][Papier][Karton]| Bahnkontrolle    | Rüttlung    |
               | [Leerpak.][Abfüll.][Bunker]| Heizungen        | Entstaubung |
               |                            | Gebläse Dornrad  | Linienbetr. |
               |                            | Produktzuführung | Beleuchtung |
               |                            | Produktüberwachung|            |
               +----------------------------+-------------------------------+
Funktionsleiste: [Schichtplan]
```

| Bereich | Spalten | Aufbau |
|---|---|---|
| Gruppe „Geschwindigkeit“ | 2 von 12 | [HM-15](../Module/HM-15_Gruppenbereich.md) Panel mit Überschrift; von oben: Kennzahl Soll (bedienbar), Kennzahl Ist, Zustandstaste „Schnell“ am unteren Rand; Abstand `Size.Touch.Gap` |
| Gruppe „Produktion“ | 3 von 12 | Panel; von oben: Rezeptanwahl, Aktuelle Produktion (bedienbar), Letzte Produktion |
| Gruppe „EKW“ | 3 von 12 | Panel mit Überschrift „EKW“; Letztes Gewicht, Mittelwert mit Umschalter, Standardabweichung (S01-2) |
| Gruppe „Versorgung“ | 4 von 12 | Panel; Zeilen Druckluft, Papier, Produkt; Zwischenüberschrift „Linienbetrieb“; Zeilen Bandwaage, Folgemaschine; Zeilen sind reine Anzeige (Presentation `Row`, Zeilenhöhe Body) |
| Tastenblock | 5 von 12 | Panel ohne Überschrift; Raster 3 Spalten × 2 Zeilen nach [HM-16](../Module/HM-16_Kachel-Navigation.md) (Kachelgröße `Large`, Abstand `Size.Touch.Gap`); jede Kachel ist eine Zustandstaste in Kachelhöhe (`Size.Touch.Large`) nach der HM-08-Variante `Button` mit Kachelgröße (S01-5) |
| Umschalter-Gruppe | 7 von 12 | Panel ohne Überschrift; zwei Spalten mit 5 und 4 Umschalterzeilen (`Size.Touch.Default` hoch, Abstand `Size.Touch.Gap`) |
| Funktionsleiste | volle Breite | [HM-06](../Module/HM-06_Funktionsleiste.md) mit einer Taste „Schichtplan“ |

Kontrolle (keine Vorgabe): Die höchste Spalte der Umschalter-Gruppe braucht 5 × `Size.Touch.Default` + 4 × `Size.Touch.Gap` + 2 × `Space.M` Innenrand und passt bei 1920 × 1080 in die Zeile 2 (416 von 421 verfügbaren Einheiten). Deshalb 5 + 4 statt 6 + 2 des Entwurfs und 11\* : 14\* statt rund 45 % für die obere Reihe (S01-6 und S01-7). Die obere Reihe braucht für die höchste Gruppe (Geschwindigkeit, Produktion, EKW: Überschrift plus drei Zeilen à `Size.Touch.Default`) weniger als ihre Höhe.

## Elemente
Typ „Z-Taste“ = Zustandstaste mit Ein/Aus ([HM-08](../Module/HM-08_Zustandstaste-Umschalter.md), Darstellung `Button` in Kachelhöhe `Size.Touch.Large`, S01-5), „Umschalter“ = HM-08 Darstellung `Switch`. Zustände neutral mit Symbol und Wort „Ein“/„Aus“, nie grün (A-31). Spalte „Herkunft“: RS-Zeile (T1 Statusanzeige, T2 Steuerfunktionen, Rahmen = Tabelle „Rahmenelemente laut Seitenbild“) bzw. DS-Element.

### Kennzahlen (RS-01 Tabelle T1, 8 Zeilen)

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Geschwindigkeit Soll | Kennzahl, bedienbar (Symbol `Icon.Speed`, Beschriftung „Soll“, Einheit 1/min, `Icon.Chevron`) | „Vorgabe der gewünschten Maschinengeschwindigkeit. Je nach Situation kann die Maschinengeschwindigkeit von diesem Wert abweichen.“ „Ein Klick auf das rote Tachosymbol öffnet eine Eingabe für alle Geschwindigkeiten.“ Im neuen HMI öffnet das Antippen der Kennzahl (Symbol nicht mehr rot) [HS-03](HS-03_Maschinengeschwindigkeit.md). Zeigt den wirksamen Sollwert (Schnell oder Langsam, je nach Taste „Schnell“). Wert nicht rot (Referenz rot) | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) (`IsInteractive`) | T1 Zeile 1; Navigation.md Baum HS-01 |
| Geschwindigkeit Ist | Kennzahl, nur Anzeige (`Icon.Speed`, Beschriftung „Ist“, 1/min) | „Ausgabe der aktuellen Maschinengeschwindigkeit. Hat die Maschine einen zentralen Geber oder Servomotor entspricht der Wert dieser Geschwindigkeit. Handelt es sich um eine getaktete Maschine wird der Wert anhand der Ausbringung berechnet.“ Gleiche Quelle wie die Rahmenkennzahl „Geschwindigkeit“ (S01-3) | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | T1 Zeile 2 |
| Aktuelle Produktion | Kennzahl, bedienbar (Symbol `Icon.Production.Current`, `Icon.Chevron`) | „Ein rücksetzbarer Stückzähler. Ein Klick auf das Symbol öffnet das Pop-Up Produktionszähler.“ Antippen öffnet [HS-02](HS-02_Produktionszaehler.md) | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) (`IsInteractive`) | T1 Zeile 3; DS-01 „Aktuelle Produktion 9854“ |
| Letzte Produktion | Kennzahl, nur Anzeige (Symbol `Icon.Production.Last`) | „Der Wert des Stückzählers beim letzten Rücksetzen.“ | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | T1 Zeile 4; DS-01 „Letzte Produktion 14531“ |
| Maschinenwinkel | Kennzahl im Rahmen (`Icon.Angle`, °) | „Winkel des Hauptgebers. Die meisten Nocken und Antriebe richten sich nach diesem Geber.“ Steht im Rahmen (Brotkrümelzeile), nicht doppelt im Inhaltsbereich; nur Anzeige | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) (Größe `Frame`) | T1 Zeile 5; DS-01 „245°“ |
| Letztes Gewicht | Kennzahl mit Index (Symbol `Icon.Weight.Last`, g, kleine Zahl unten rechts) | „Das letzte gewogene Gewicht in der Maschine. gibt es mehrere Dosierer oder Waagen zeigt der kleinere Wert unten rechts im Feld die Nummer des Dosierers oder der Waage an.“ | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) (`Index`) | T1 Zeile 6 |
| Mittelwert | Kennzahl (Symbol `Icon.Stat.Mean`, g) mit Umschalter | „Mittleres Gewicht der ausgebrachten Packungen. Kann fortlaufend oder stichprobenartig erfasst werden. Die Schaltfläche rechts vom Ausgabefeld erlaubt das Umschalten.“ | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) + Umschalter (nächste Zeile) | T1 Zeile 7 |
| Umschalter Erfassung (Beschriftung „Fortlaufend“ / „Stichprobe“) | Z-Taste mit Textumschaltung, rechts vom Mittelwert | wechselt zwischen fortlaufender und stichprobenartiger Erfassung; das Wort zeigt den aktiven Modus (Bild: „Fortlaufend“; Gegenwort „Stichprobe“ S01-8). Die Standardabweichung folgt dem Modus. Kein Ein/Aus-Wort | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) (`OnText`, `OffText`) | T1 Zeile 7, Bild „Fortlaufend“ |
| Standardabweichung | Kennzahl, nur Anzeige (Symbol `Icon.Stat.Sigma`, g) | „Die Standartabweichung der ausgebrachten Packungen. Der Wert wird anhand derselben Gewichte wie der Mittelwert berechnet. Entsprechend kann die Ausgabe fortlaufend oder stichprobenartig sein.“ UI-Text korrekt geschrieben (S01-12) | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | T1 Zeile 8 |

### Steuerfunktionen (RS-01 Tabelle T2, 16 Zeilen)

| Element | Typ | Funktion (Referenz) | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Automatik (Referenz „Automatik Produktion“) | Z-Taste, Sammelzustand; Tastenblock Zeile 1 Spalte 1 | „Aktiviert alle Funktionen der Maschine für die Produktion. Ist die Schaltfläche grau, so ist mindestens eine Funktion abgewählt.“ Zustände: Ein (alle angewählt) oder „Teilweise“ mit `Icon.State.Partial`; Antippen im Zustand „Teilweise“ wählt alle Funktionen an (S01-9) | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) (`IsAggregate`) | T2 Z1/S1; DS-01 „Automatik“ |
| Schnell (Referenz „Maschine schnell / langsam“) | Z-Taste in Gruppe „Geschwindigkeit“, Wortpaar „Schnell“ / „Langsam“ | „Erlaubt eine direkte Umschaltung zwischen zwei Geschwindigkeiten. Hilfreich beim Anlauf und bei der Problemsuche.“ Ein = Sollwert „Schnell“, Aus = Sollwert „Langsam“ aus [HS-03](HS-03_Maschinengeschwindigkeit.md) (S01-4) | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) (`OnText`, `OffText`) | T2 Z2/S1; DS-01 Taste „Schnell“ |
| Maschinenbeleuchtung | Umschalter, Umschalter-Gruppe Spalte 2 Zeile 4 | „Schaltet die Maschinenbeleuchtung ein oder aus.“ Im Design nicht vorhanden, ergänzt (S01-1) | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | T2 Z3/S1 |
| Gebläse Dornrad | Umschalter | „Erlaubt das Schalten des Sauggebläses im Dornrad. Wird in der Regel automatisch gesteuert.“ | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | T2 Z4/S1; DS-01 Umschalter |
| Zuführung Papier | Z-Taste, Tastenblock Zeile 1 Spalte 2 | „Aktiviert die Zuführung für das Innenpapier.“ Aktiviert, navigiert nicht (A-38) | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | T2 Z1/S2; DS-01 Taste |
| Zuführung Karton | Z-Taste, Tastenblock Zeile 1 Spalte 3 | „Aktiviert die Zuführung des Außenkartons. Ist kein Papier auf dem Dorn wird kein Karton abgezogen.“ Aktiviert, navigiert nicht (A-38) | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | T2 Z2/S2; DS-01 Taste |
| Bahnkontrolle | Umschalter | „Schaltet die Überwachung des Papierabzugs in der Papierzuführung ein. Abhängig von der Nocke muss der entsprechende Sensor belegt werden und auch wieder frei werden. Fehler beim Abzug oder beim Nachfüllen führen zu einer Störung und zum Stopp der Maschine.“ | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | T2 Z3/S2; DS-01 Umschalter |
| Leerpakete ausblasen | Z-Taste, Tastenblock Zeile 2 Spalte 1 | „Alle Packungen im Dornrad werden als schlecht markiert und bei der nächsten Möglichkeit ausgeblasen.“ | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | T2 Z4/S2; DS-01 Taste |
| Produktzuführung | Umschalter | „Schaltet alle Komponenten ein welche für die Produktzuführung nötig sind. Das beinhaltet Bänder, Schnecken. Klappen werden geöffnet.“ | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | T2 Z1/S3; DS-01 Umschalter |
| Produktüberwachung | Umschalter | „Ist die Überwachung aktiv, stoppt die Maschine mit einer Störung, wenn die Trichter und Füllrohre an den Dosierern leer sind. Zum Leerfahren der Produktzuführung muss die Überwachung abgeschaltet werden.“ | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | T2 Z2/S3; DS-01 Umschalter |
| Abfüllung | Z-Taste, Tastenblock Zeile 2 Spalte 2 | „Damit kann das Abfüllen der Packungen abgeschaltet werden. Die Packungen werden auf den Waagen als schlecht markiert und werden an der nächsten Möglichkeit ausgeschleust.“ | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | T2 Z3/S3; DS-01 Taste |
| Rüttlung | Umschalter | „Erlaubt das Zu- und Abschalten der Rüttlung im Schließteil der Maschine.“ | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | T2 Z4/S3; DS-01 Umschalter |
| Entstaubung | Umschalter | „Steuert das Ventil für die Entstaubung in der Schließmaschine.“ | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | T2 Z1/S4; DS-01 Umschalter |
| Bunker leerfahren | Z-Taste, Tastenblock Zeile 2 Spalte 3 | „Sendet ein Signal an die vorgelagerte Produktzuführung und fordert ein Leerfahren des Produktbunkers an.“ | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | T2 Z2/S4; DS-01 Taste |
| Heizungen | Umschalter | „Erlaubt das Zu- und Abschalten aller Heizungen in der Maschine.“ Schaltet nur; die Detailseite [HS-22](HS-22_Heizungen.md) erreicht man über „Einstellung“ (A-38) | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | T2 Z3/S4; DS-01 Umschalter |
| Linienbetrieb | Umschalter | „Ist der Linienbetrieb aktiv, reagiert die Maschine auf nachfolgende Anlagen und Stoppt oder fährt Leer abhängig von den Signalen.“ | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | T2 Z4/S4; DS-01 Umschalter |

Die Reihenfolge der Umschalter folgt dem Entwurf (Bahnkontrolle, Heizungen, Gebläse Dornrad, Produktzuführung, Produktüberwachung | Rüttlung, Entstaubung, Linienbetrieb, ergänzt Maschinenbeleuchtung). Die Tasten stehen wie im Entwurf (Automatik, Zuführung Papier, Zuführung Karton | Leerpakete ausblasen, Abfüllung, Bunker leerfahren).

### Gruppen „Produktion“ und „Versorgung“ (nur Design, DS-01)

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Überschriften „Geschwindigkeit“, „Produktion“, „EKW“, „Versorgung“ | Gruppenüberschrift | gliedert die vier oberen Gruppen; „EKW“ im Entwurf leer, hier mit den Gewichtskennzahlen gefüllt (S01-2) | [HM-15](../Module/HM-15_Gruppenbereich.md) | DS-01 Kacheln; OP-06 |
| Rezeptanwahl | Aktionstaste, zweizeilige Beschriftung „Rezeptanwahl“ und Name des gewählten Rezepts (Dummy), `Icon.Key` | Antippen öffnet das Rezeptauswahl-Pop-up (Platzhalter, OP-01; Rolle Technik, Navigation.md 4.1). Der Platzhaltertext „Tolles Rezept“ entfällt (Designsystem 12) | [HM-07](../Module/HM-07_Aktionstaste.md); Pop-up: Platzhalter „Rezeptauswahl-Pop-up“ (Abschnitt Platzhalter-Pop-ups) | DS-01 „Rezeptanwahl / Tolles Rezept“ |
| Druckluft | Zeile mit Zustandswort „IO“ und Symbol `Icon.Status.Ok` | Zustand der Druckluftversorgung (S01-11) | [HM-11](../Module/HM-11_Anzeigefeld.md) (Textwert, `Row`) | DS-01 „Druckluft / IO“ |
| Papier | Zeile „IO“ | Zustand der Papierversorgung | [HM-11](../Module/HM-11_Anzeigefeld.md) | DS-01 „Papier / IO“ |
| Produkt | Zeile „IO“ | Zustand der Produktversorgung | [HM-11](../Module/HM-11_Anzeigefeld.md) | DS-01 „Produkt / IO“ |
| Zwischenüberschrift „Linienbetrieb“ | Text ohne Wert | gliedert Bandwaage und Folgemaschine | [HM-15](../Module/HM-15_Gruppenbereich.md) (`Subheader`) | DS-01 „Linienbetrieb“ |
| Bandwaage | Zeile „Bereit“ | Zustand der Bandwaage | [HM-11](../Module/HM-11_Anzeigefeld.md) | DS-01 „Bandwaage / Bereit“ |
| Folgemaschine | Zeile „Läuft“ | Zustand der Folgemaschine | [HM-11](../Module/HM-11_Anzeigefeld.md) | DS-01 „Folgemaschine / Läuft“ |
| Schichtplan | Aktionstaste mit `Icon.Schedule` in der Funktionsleiste | öffnet [HS-43](HS-43_Schichtplan.md) (Platzhalter, OP-02) | [HM-07](../Module/HM-07_Aktionstaste.md) in [HM-06](../Module/HM-06_Funktionsleiste.md) | DS-01 „Schichtplan“ |

### Rahmenelemente (Herkunft RS-01 „Rahmenelemente laut Seitenbild“ und DS-01)

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Logo APA-TEC | Grafik | Kopfzeile | [HM-02](../Module/HM-02_Kopfzeile.md) | RS-01 Logo; DS-01 |
| Seitentitel „Produktion“ (unterstrichen) | Brotkrümel, ein Segment | ersetzt den Seitentitel der Referenz; nur Anzeige | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | RS-01 Seitentitel; DS-01 Brotkrümel |
| Wirbel-Symbol | Betriebsart (Symbol und Wort „Produktion“) | Bedeutung in der Referenz nicht erklärt; als Betriebsart geführt (A-48, OP-26); nur Anzeige | [HM-02](../Module/HM-02_Kopfzeile.md) | RS-01 Wirbel-Symbol; DS-01 Betriebsart |
| Uhrzeit, Datum | Anzeige | nur Anzeige | [HM-02](../Module/HM-02_Kopfzeile.md) | RS-01 Uhrzeit/Datum; DS-01 |
| Meldezeile | Anzeige, antippbar | „NNN: Text“ mit Symbol und Schweregradwort statt rotem Balken; Antippen öffnet [HS-38](HS-38_Meldeanzeige.md) | [HM-03](../Module/HM-03_Meldezeile.md) | RS-01 Meldezeile; DS-01 „014: …“ |
| Kennzahlen Geschwindigkeit und Maschinenwinkel | Kennzahl im Rahmen | „Geschwindigkeit“ öffnet [HS-03](HS-03_Maschinengeschwindigkeit.md) (A-38), „Maschinenwinkel“ nur Anzeige | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | DS-01 „112 1/min“, „245°“ |
| Schloss-Symbol (gelb) | Benutzerkreis „MM“, Name, Rolle | Antippen öffnet das Benutzer-Pop-up (A-35); ersetzt das Schloss | [HM-01](../Module/HM-01_Seitenleiste.md) | RS-01 Schloss; DS-01 Benutzerkreis |
| Taste „Produktion“ (Haus) | Seitenleiste „Home“, hervorgehoben, ohne Wirkung | aktuelle Seite | [HM-01](../Module/HM-01_Seitenleiste.md) | RS-01 Taste „Produktion“; DS-01 |
| Taste „Einstellungen“ (Zahnrad) | Seitenleiste „Einstellungen“ | öffnet [HS-04](HS-04_Einstellungen.md) | [HM-01](../Module/HM-01_Seitenleiste.md) | RS-01 Taste „Einstellungen“; DS-01 |
| Taste „Zurück“ | Seitenleiste „Zurück“, deaktiviert | Wurzel, kein Vorgänger | [HM-01](../Module/HM-01_Seitenleiste.md) | RS-01 Taste „Zurück“; DS-01 |
| Meldungen (Sprechblase) | Seitenleiste „Meldungen“ | öffnet [HS-38](HS-38_Meldeanzeige.md) | [HM-01](../Module/HM-01_Seitenleiste.md) | DS-01 Seitenleiste; OP-08 |

## Verwendete Module (IDs)
[HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md), [HM-07](../Module/HM-07_Aktionstaste.md), [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md), [HM-11](../Module/HM-11_Anzeigefeld.md), [HM-15](../Module/HM-15_Gruppenbereich.md), [HM-16](../Module/HM-16_Kachel-Navigation.md) (nur als Raster des Tastenblocks, Inhalt der Kacheln ist HM-08). Pop-ups: [HS-02](HS-02_Produktionszaehler.md), [HS-03](HS-03_Maschinengeschwindigkeit.md) (beide mit [HM-14](../Module/HM-14_Popup-Rahmen.md)); Platzhalter-Pop-ups ohne HM: Rezeptauswahl, Benutzer.

## Platzhalter-Pop-ups
Beide Pop-ups haben weder in der Referenz noch im Design eine Vorlage (OP-01, OP-04). Sie sind Platzhalter, nur der Rahmen ist festgelegt; Inhalt und Fachlogik werden nicht erfunden.
- **Rezeptauswahl-Pop-up (Platzhalter).** Zweck: Rezept für die Produktion wählen (Design: „Rezeptanwahl“). Aufbau: [HM-14](../Module/HM-14_Popup-Rahmen.md) mit Titel „Rezeptauswahl“, Auswahlliste mit Dummy-Rezepten (Annahme S01-13), „Übernehmen“ und „Abbrechen“. Verhalten: modal nach Navigation.md 4.2; Übernehmen setzt den Rezeptnamen in der Gruppe „Produktion“, Abbrechen verwirft; Rolle Technik, sonst Hinweis „Berechtigung erforderlich: Technik“. Rezeptparameter und Wirkung auf die Maschine sind nicht beschrieben (OP-01).
- **Benutzer-Pop-up (Platzhalter).** Zweck: Anmelden, Abmelden und Rolle anzeigen (A-35, OP-04). Aufbau: [HM-14](../Module/HM-14_Popup-Rahmen.md) mit Titel „Benutzer“, Anzeige von Name und Rolle (Dummy „Max Mustermann“, Technik), Tasten „Anmelden“, „Abmelden“, „Abbrechen“; die Art der Anmeldung (PIN, Karte, Passwort) ist nicht festgelegt. Verhalten: öffnet über den Benutzerkreis oder bei fehlender Rolle; nach erfolgreicher Anmeldung wird die ausgelöste Aktion fortgesetzt, bei Abbrechen nicht; Abmelden schließt offene Pop-ups ohne Übernehmen (Navigation.md 4.2 Nr. 5).

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- **Zustandstasten und Umschalter** (alle 16 Funktionen): Aus (leerer Kreis `Icon.State.Off`, Wort „Aus“, Knopf links), Ein (Haken `Icon.State.On`, Wort „Ein“, Knopf rechts, neutral dunkel), Gedrückt (Kontur `Border.Medium`), Ausstehend nach dem Antippen bis zur Rückmeldung der Maschine (gestrichelte Kontur, Symbol `Icon.State.Pending`, Text „Wird gesetzt“), Fehler (Kontur `Border.Thick` in `Brush.Status.Error.Fg`, Fläche `Brush.Status.Error.Subtle`, `Icon.Status.Error` und Fehlertext), Deaktiviert (gestrichelte Kontur, Grund per Tippen in der Meldezeile, A-28). Der Schaltbefehl wirkt sofort ohne Bestätigungsdialog (S01-10). Die Auslösung erfolgt beim Loslassen im Ziel.
- **Automatik (Sammelzustand):** „Ein“ nur, wenn alle erfassten Funktionen angewählt sind, sonst „Teilweise“ mit `Icon.State.Partial`; Antippen bei „Teilweise“ wählt alle erfassten Funktionen an und zeigt als Info-Text in der Meldezeile, welche Funktionen dadurch angewählt wurden (Touch, kein Tooltip, S01-14); im Zustand „Ein“ ohne Wirkung. Die Menge der erfassten Funktionen ist konfigurierbar (S01-9, OP-50).
- **Mittelwert-Umschalter:** wechselt Mittelwert und Standardabweichung gemeinsam zwischen „Fortlaufend“ und „Stichprobe“; der Wert wird bis zur Rückmeldung als ungültig („---“) oder als vorheriger Wert mit Ausstehend-Kennzeichnung gezeigt.
- **Störungen** (Referenz): Bahnkontrolle (Fehler beim Abzug oder Nachfüllen) und Produktüberwachung (Trichter oder Füllrohre leer) führen zu Störung und Maschinenstopp. Die Meldung erscheint in der Meldezeile; der betroffene Umschalter bleibt in seinem Zustand, zeigt aber zusätzlich den Fehlerzustand mit Symbol und Text, solange die Maschine die Funktion als gestört meldet (S01-10). Das HMI löst weder Störung noch Stopp selbst aus.
- **Ungültige Werte** (Kommunikationsausfall): Kennzahlen zeigen „---“ (HM-05), Versorgungszeilen „---“.
- **Versorgung:** „IO“ mit Symbol `Icon.Status.Ok`; weicht ein Zustand ab, zeigt die Zeile `Icon.Status.Warning` oder `Icon.Status.Error` mit dem Zustandswort der Maschine (S01-11, OP-11).
- **Pop-ups:** Antippen von Geschwindigkeit Soll öffnet [HS-03](HS-03_Maschinengeschwindigkeit.md), von Aktuelle Produktion [HS-02](HS-02_Produktionszaehler.md), von Rezeptanwahl das Rezeptauswahl-Pop-up. Ein Pop-up zur Zeit; dahinter Scrim, Seiteninhalt, Seitenleiste, Funktionsleiste und Brotkrümel gesperrt (Navigation.md 4.2). Pop-ups stehen nicht im Verlauf.
- **Navigation:** Home ohne Wirkung; Zurück deaktiviert; Einstellungen setzt den Stapel auf `[HS-01]`; „Schichtplan“ öffnet [HS-43](HS-43_Schichtplan.md), „Zurück“ dort führt hierher (Verlauf).
- **Berechtigungen:** Die Referenz beschreibt keine Berechtigungen für diese Seite (OP-25). Im Design tragen die Tasten und Umschalter kein Schlüsselsymbol; sie sind für jeden angemeldeten Benutzer bedienbar. Nur die Rezeptanwahl hat das Schlüsselsymbol (Rolle Technik, Annahme aus Navigation.md 4.1). Ohne Rolle erscheint „Berechtigung erforderlich: Technik“ und das Benutzer-Pop-up.
- **Betriebszustand:** Funktionen, die im aktuellen Betriebszustand nicht schaltbar sind, werden deaktiviert (gestrichelt) statt ausgeblendet; welche, ist nicht dokumentiert (OP-50).
- **Themen und Sprache:** Hell/Dunkel über Tokens; alle Texte aus `.resx`; Textlängen mit 40 % Zuschlag (Tasten und Kennzahlbeschriftungen brechen um).

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-01-P01 | Kennzahlen (RS-01-P01) | alle 8 Zeilen aus T1 vorhanden: Geschwindigkeit Soll, Geschwindigkeit Ist, Aktuelle Produktion, Letzte Produktion, Maschinenwinkel (Rahmen), Letztes Gewicht, Mittelwert mit Umschalter, Standardabweichung; Beschreibungstexte stimmen mit RS-01 überein | offen |
| HS-01-P02 | Steuerfunktionen (RS-01-P02) | alle 16 Funktionen vorhanden: 6 Tasten (Automatik, Zuführung Papier, Zuführung Karton, Leerpakete ausblasen, Abfüllung, Bunker leerfahren), 9 Umschalter (Bahnkontrolle, Heizungen, Gebläse Dornrad, Produktzuführung, Produktüberwachung, Rüttlung, Entstaubung, Linienbetrieb, Maschinenbeleuchtung) und „Schnell“ | offen |
| HS-01-P03 | Symbole (RS-01-P03) | die 8 Kennzahlen zeigen 7 verschiedene Symbole (RS-01_02 bis RS-01_09; „Soll“ und „Ist“ teilen `Icon.Speed`) und sind durch Beschriftung und Chevron unterscheidbar, nicht durch rote Farbe | offen |
| HS-01-P04 | Layout Kennzahlen (RS-01-P04) | Gruppen „Geschwindigkeit“, „Produktion“, „EKW“ enthalten die 6 Felder links und Mittelwert mit Umschalter sowie Standardabweichung der Referenz | offen |
| HS-01-P05 | Soll antippen (RS-01-P05) | öffnet das Pop-up Maschinengeschwindigkeit (HS-03); Rahmenkennzahl „Geschwindigkeit“ öffnet dasselbe Pop-up | offen |
| HS-01-P06 | Aktuelle Produktion antippen (RS-01-P06) | öffnet das Pop-up Produktionszähler (HS-02) | offen |
| HS-01-P07 | Mittelwert-Umschalter (RS-01-P07) | wechselt zwischen „Fortlaufend“ und „Stichprobe“, das Wort zeigt den Modus, die Standardabweichung folgt | offen |
| HS-01-P08 | Index Letztes Gewicht (RS-01-P08) | bei mehreren Dosierern oder Waagen zeigt die kleine Zahl unten rechts im Feld die Nummer | offen |
| HS-01-P09 | Automatik (RS-01-P09) | zeigt „Teilweise“ mit Symbol, solange mindestens eine erfasste Funktion abgewählt ist, sonst „Ein“; Antippen bei „Teilweise“ wählt alle an | offen |
| HS-01-P10 | Zustandsdarstellung (RS-01-P10) | alle 16 Funktionen zeigen Ein/Aus über Symbol und Wort (Taste) bzw. Knopfposition und Wort (Umschalter), neutral, nicht grün | offen |
| HS-01-P11 | Meldezeile (RS-01-P11) | zeigt „NNN: Text“ mit Symbol und Schweregradwort; Antippen öffnet HS-38 | offen |
| HS-01-P12 | Rahmen und Navigation (RS-01-P12) | Kopfzeile mit Logo, Brotkrümel „Produktion“, Uhrzeit und Datum; Seitenleiste mit Home (hervorgehoben), Einstellungen, Meldungen, Zurück (deaktiviert) und Benutzerkreis; zusätzlich DS-01-P09 (Rahmenwerte 112 1/min, 245°, 9:15, 06.01.2026, Betriebsart „Produktion“, Meldung 014) und DS-01-P11 (Seitenleiste MM, Max Mustermann, Technik; 4 Symbole) | offen |
| HS-01-P13 | Störverhalten (RS-01-P13) | Bahnkontrolle und Produktüberwachung: bei gemeldeter Störung Meldung in der Meldezeile und Fehlerzustand mit Symbol und Text am Umschalter; das HMI löst keinen Stopp selbst aus | offen |
| HS-01-P14 | Gruppen laut Design (DS-01-P01 bis P04) | vier Gruppen Geschwindigkeit, Produktion, EKW, Versorgung in Spalten 2 : 3 : 3 : 4; Versorgung mit Druckluft, Papier, Produkt „IO“ und Linienbetrieb mit Bandwaage „Bereit“, Folgemaschine „Läuft“ | offen |
| HS-01-P15 | Tasten und Umschalter laut Design (DS-01-P05 bis P07) | 6 Tasten im Raster 3 × 2, Reihenfolge wie Entwurf; Umschalter in zwei Spalten; „Schnell“ in der Gruppe Geschwindigkeit | offen |
| HS-01-P16 | Funktionsleiste und Brotkrümel (DS-01-P08, DS-01-P10; zu P09 und P11 siehe HS-01-P12) | nur die Taste „Schichtplan“ (öffnet HS-43); Brotkrümel mit einem Segment | offen |
| HS-01-P17 | Keine Navigation durch Funktionstasten | „Zuführung Papier“, „Zuführung Karton“ und „Heizungen“ aktivieren nur, sie öffnen keine Seite (A-38) | offen |
| HS-01-P18 | Touch-Ziele | jede Taste, Kachel, Umschalterzeile und bedienbare Kennzahl hat Trefferfläche ≥ `Size.Touch.Default` (Tasten im Raster ≥ `Size.Touch.Large`), Abstand ≥ `Size.Touch.Gap` | offen |
| HS-01-P19 | Zweiter Kanal | jeder Zustand (Ein/Aus/Teilweise/Ausstehend/Fehler/Deaktiviert, IO/abweichend) ist ohne Farbe über Symbol und Wort erkennbar; Sollwert nicht rot | offen |
| HS-01-P20 | Tokens und Themen | keine Hex- oder Pixelwerte in der Seite; Hell- und Dunkelthema vollständig; keine Verläufe, Fasen oder Schatten | offen |
| HS-01-P21 | Passt ohne Scrollen | bei 1920 × 1080 sind alle Gruppen und die 5 Umschalterzeilen je Spalte vollständig sichtbar | offen |
| HS-01-P22 | Lokalisierung | alle Beschriftungen aus `.resx`; Beschriftungen brechen bei +40 % Textlänge um, ohne Elemente zu überdecken | offen |
| HS-01-P23 | Platzhalter-Pop-ups | Rezeptauswahl und Benutzer öffnen modal mit Titel, Dummy-Inhalt und eindeutiger Schließen-Aktion, sind als Platzhalter gekennzeichnet; Berechtigungshinweis bei fehlender Rolle | offen |

## Annahmen dieser Seite
Lokale Kennungen; der Sammeleintrag in `Annahmen.md` verweist auf diesen Abschnitt.

| ID | Annahme |
|---|---|
| S01-1 | „Maschinenbeleuchtung“ (RS-01 T2 Z3/S1) fehlt im Design; sie ist als 9. Umschalter in der Umschalter-Gruppe ergänzt. |
| S01-2 | Letztes Gewicht, Mittelwert mit Umschalter und Standardabweichung stehen in der im Design leeren Kachel „EKW“ (OP-06). |
| S01-3 | Die Rahmenkennzahl „Geschwindigkeit“ ist der Ist-Wert; die Gruppe „Geschwindigkeit“ zeigt zusätzlich Soll (bedienbar) und Ist. Der Maschinenwinkel steht nur im Rahmen. |
| S01-4 | „Schnell“ ist die Referenzfunktion „Maschine schnell / langsam“: Zustandstaste mit Wortpaar Schnell/Langsam; Ein = Sollwert „Schnell“, Aus = Sollwert „Langsam“ aus HS-03 (OP-09). |
| S01-5 | Die 6 Tasten des Tastenblocks sind Zustandstasten (RS-01 T2, A-38); Darstellung HM-08 `Button` in Kachelhöhe (`Size.Touch.Large`), Raster nach HM-16. |
| S01-6 | Die Umschalter-Gruppe hat 5 + 4 Zeilen statt 6 + 2 des Entwurfs, weil 6 Touch-Zeilen mit Abständen nicht in die Zeile passen. |
| S01-7 | Die Zeilen des Inhaltsbereichs verhalten sich 11\* : 14\* statt rund 45 % für die obere Reihe (gleicher Grund). |
| S01-8 | Der Erfassungsumschalter hat das Wortpaar „Fortlaufend“ / „Stichprobe“; „Stichprobe“ ist im Handbuch nicht belegt. |
| S01-9 | „Automatik“ ist ein Sammelzustand mit „Teilweise“; erfasste Funktionen als Dummy alle übrigen 14 außer „Schnell“; Antippen bei „Teilweise“ wählt alle an, bei „Ein“ ohne Wirkung. |
| S01-10 | Schaltbefehle wirken sofort ohne Bestätigung, mit Zustand „Ausstehend“; bei gemeldeter Störung (Bahnkontrolle, Produktüberwachung) zeigt der Umschalter zusätzlich den Fehlerzustand mit Symbol und Text. |
| S01-11 | Versorgungszeilen zeigen „IO“ mit `Icon.Status.Ok`; abweichende Zustände zeigen Warnung oder Fehler mit dem Zustandswort der Maschine (OP-11). |
| S01-12 | UI-Text „Standardabweichung“ statt „Standartabweichung“ (OP-35). |
| S01-13 | Rezeptauswahl- und Benutzer-Pop-up sind Platzhalter mit Dummy-Inhalt (OP-01, OP-04). |
| S01-14 | Welche Funktionen „Automatik“ anwählt, zeigt ein Info-Text in der Meldezeile (Touch, kein Tooltip). |

## Offene Punkte
- Rezeptanwahl: OP-01; Schichtplan: OP-02; Benutzer und Rolle: OP-04; leere Kachel „EKW“: OP-06 (hier als Gewichtsgruppe belegt, S01-2).
- Funktion und Zustände von „Schnell“: OP-09 (hier aus RS-01 und RS-03 abgeleitet, S01-4); Funktion der sechs Tasten: OP-10 (A-38: Zustandstasten); „IO“ ohne Legende: OP-11.
- Antippbarkeit und Rahmenwerte: OP-21, OP-22; Zuführungsseiten: OP-20.
- Aus der Referenz: Berechtigungen OP-25; Wirbel- und Schloss-Symbol OP-26; Farbbedeutung OP-27 und OP-43 (neu: Ein/Aus mit Symbol und Wort); Einheiten und Nachkommastellen OP-29; Rückfragen für kritische Aktionen OP-31; Abweichungen Bild und Handbuch OP-34; Quellfehler („Standartabweichung“) OP-35; weitere Lücken (Klickziele, Umschalterbeschriftung) OP-50.
- Neue offene Punkte dieser Seite: (a) Menge der von „Automatik“ erfassten Funktionen und Verhalten beim Antippen im Zustand „Ein“; (b) Gegenwort „Stichprobe“ zum Mittelwert-Umschalter; (c) Zuordnung der Gewichtskennzahlen zur Kachel „EKW“; (d) Zustandswörter der Versorgung außer „IO“; (e) Anmeldeverfahren und Inhalt der Platzhalter-Pop-ups Rezeptauswahl und Benutzer.
