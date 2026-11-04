# HS-33 – EA-Übersicht

- Quelle: [RS-33 EA-Übersicht](../../02_Referenz-Analyse/Seiten/RS-33_EA-Uebersicht.md) (Handbuch Kapitel „EA-Übersicht“, Tabelle T43, Bild [RS-33_01.png](../../02_Referenz-Analyse/Medien/RS-33_01.png)). Kein Design-Screenshot vorhanden: Aufbau abgeleitet aus [Designsystem](../Designsystem.md) (Kachelmenü wie HS-04/DS-02), Kachelmodul [HM-16](../Module/HM-16_Kachel-Navigation.md) und den Rahmenmodulen.
- Navigationspfad (Brotkrümel laut [Navigation.md](../Navigation.md), Abschnitt 2): **Einstellung › EA-Übersicht**. Zugang: HS-04, Kachel „EA Übersicht“. Zurück-Ziel: HS-04 (Verlauf). Seitenregister: `IoOverview` / `settings/io`, Eltern HS-04, keine Parameter, keine Mindestrolle.

## Zweck

Die Seite zeigt den Zugang zu allen Ein- und Ausgängen (EA) der Maschine für Diagnose und Kontrolle der über die SPS angebundenen Betriebsmittel (Handbuch, RS-33 Zweck; RS-04: „Zeigt alle EA-Karten und den Zustand der entsprechenden Kanäle an“). Sie ist ein Auswahlmenü: Jede EA-Schaltfläche öffnet die EA-Anzeige [HS-34](HS-34_EA-Anzeige.md) der gewählten Kartengruppe (A-39). Die Taste „Suchen“ findet ein Betriebsmittel über seine Betriebsmittelkennzeichnung. Die Seite ist reine Anzeige und Navigation und ändert keinen Maschinenzustand.

## Aufbau (Bereiche, Layout)

Rahmen wie auf allen Seiten (Seitenleiste 3\* : Arbeitsbereich 37\*; Zeilen 4\* : 3\* : 34\* : 4\*). Der Inhaltsbereich hat Außenrand `Space.L` und das 12-Spalten-Raster (Abstand `Size.Touch.Gap`).

- **Inhaltsbereich:** ein Kachelraster [HM-16](../Module/HM-16_Kachel-Navigation.md) mit **4 Spalten × 2 Zeilen** (jede Kachel belegt 3 von 12 Spalten), Kachelhöhe `Size.Touch.Large`, oben links beginnend. 6 Kacheln sind beschriftet; die letzten 2 Rasterzellen der Zeile 2 sind leer und erscheinen als „Reserviert“ (A-29, `EmptyTileMode = Reserved`). Die großen quadratischen Tasten der Referenz werden an die Kachelgröße des Designsystems angepasst (Höhe `Size.Touch.Large`, Breite 3 Spalten).
- **Untere Funktionsleiste ([HM-06](../Module/HM-06_Funktionsleiste.md)):** eine seitenspezifische Taste „Suchen“, links beginnend (Navigation.md 3.3, Seitentyp „Suche“).
- Das Schloss und die Tasten „Produktion“, „Einstellungen“, „Zurück“ der Referenz-Fußleiste liegen in der Seitenleiste [HM-01](../Module/HM-01_Seitenleiste.md) (A-35).

```
Inhaltsbereich (12 Spalten; Raster 4 x 2, je Kachel 3 Spalten, Höhe Size.Touch.Large)
+------------------+------------------+------------------+------------------+
| Eingänge S1      | Ausgänge S1      | Eingänge S300    | Ausgänge S300    |
+------------------+------------------+------------------+------------------+
| Eingänge S500    | Ausgänge S500    | - - Reserviert - | - - Reserviert - |
|                  |                  | (gestrichelt)    | (gestrichelt)    |
+------------------+------------------+------------------+------------------+
                       (freier Raum bis zur Funktionsleiste)
Funktionsleiste:  [ Suchen ]
```

### Belegung des Rasters (Reihenfolge wie Bild RS-33_01)

| Zeile / Spalte | Beschriftung (`.resx`) | `cardGroup` | Ziel |
|---|---|---|---|
| 1 / 1 | Eingänge S1 | Eingänge, S1 | HS-34, erste Karte der Gruppe |
| 1 / 2 | Ausgänge S1 | Ausgänge, S1 | HS-34 |
| 1 / 3 | Eingänge S300 | Eingänge, S300 | HS-34 |
| 1 / 4 | Ausgänge S300 | Ausgänge, S300 | HS-34 |
| 2 / 1 | Eingänge S500 | Eingänge, S500 | HS-34 |
| 2 / 2 | Ausgänge S500 | Ausgänge, S500 | HS-34 |
| 2 / 3, 2 / 4 | leer (Referenz) → „Reserviert“ | – | keines (deaktiviert) |

Anzahl und Kürzel der Schaltflächen sind maschinenabhängig (OP-41); die Bedeutung der Kürzel S1, S300, S500 (vermutlich SPS-Stationen) ist ungeklärt und wird unverändert übernommen.

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)

Die Spalte „Herkunft (RS-33)“ ist die Rückverfolgung zur Referenzseite.

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-33) |
|---|---|---|---|---|
| E01 Brotkrümel „Einstellung › EA-Übersicht“ | Anzeige / Navigation | Pfad; „Einstellung“ antippbar (→ HS-04), letztes Segment nur Anzeige. Ersetzt den Seitentitel der Referenz-Kopfzeile; sichtbarer Name ist „EA-Übersicht“ (Handbuchkapitel), nicht die Bildschreibweise „EA Auswahl“ (OP-33) | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | Kopfzeile (Titel „EA Auswahl“); Navigationspfad |
| E02 Kopfzeile: Logo, Betriebsart, Uhrzeit/Datum | Anzeige | Logo, Betriebsart (Wirbel-Symbol → A-48), Uhrzeit „13:05:49“ als Beispiel, Datum | [HM-02](../Module/HM-02_Kopfzeile.md) | Kopfzeile |
| E03 Kennzahlen Geschwindigkeit, Maschinenwinkel | Anzeige | Rahmenelement des Designs | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | – (Rahmen) |
| E04 Meldezeile „450: Palettierung nicht bereit“ | Anzeige | Wichtigste Maschinenmeldung; Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | Meldezeile |
| E05 Seitenleiste | Navigation | Benutzerkreis (Schloss), Home („Produktion“), Einstellungen, Meldungen, Zurück (→ HS-04) | [HM-01](../Module/HM-01_Seitenleiste.md) | Schloss; Tasten „Produktion“, „Einstellungen“, „Zurück“ |
| E06 EA-Schaltflächen (6: Eingänge/Ausgänge S1, S300, S500, Raster 4 × 2) | Kachel-Taste | Antippen öffnet HS-34 mit `cardGroup` und erster Karte; Ein- und Ausgänge werden gezielt angezeigt und überprüft (T43). Beschriftung automatisch umbrochen | [HM-16](../Module/HM-16_Kachel-Navigation.md) | EA-Schaltflächen; T43 „EA-Schaltflächen“; Bild |
| E07 Zwei leere Rasterzellen (Zeile 2, Spalten 3 und 4) | Kachel (deaktiviert) | „Reserviert“, gestrichelte Kontur, keine Aktion | [HM-16](../Module/HM-16_Kachel-Navigation.md) | leere Rasterzellen im Bild |
| E08 Funktionsleiste unten | Container | Nimmt „Suchen“ links auf | [HM-06](../Module/HM-06_Funktionsleiste.md) | Untere Funktionsleiste |
| E09 Taste „Suchen“ | Taste (Antippen) | Öffnet das Such-Pop-up E10 | [HM-07](../Module/HM-07_Aktionstaste.md) | Taste „Suchen“; T43 „Suchen“ |
| E10 Such-Pop-up „Betriebsmittel suchen“ | Pop-up (modal) | Suche nach Betriebsmittelkennzeichnung (z. B. „0E3“, „0Q5“); Treffer öffnen HS-34 mit der EA-Karte des Betriebsmittels. Aufbau und Verhalten wie in [HS-30](HS-30_Handbetrieb-Auswahl.md) definiert, Trefferzeile zeigt Kennzeichnung, Klartext und Karte | [HM-14](../Module/HM-14_Popup-Rahmen.md) mit Texteingabe nach [HM-13](../Module/HM-13_Eingabe-Pop-up.md) (Variante Text) | T43 „Suchen“ (Suchfunktion nicht abgebildet) |

## Verwendete Module (IDs)

- Rahmen: [HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md)
- Seite: [HM-16](../Module/HM-16_Kachel-Navigation.md) Kachel-Navigation, [HM-07](../Module/HM-07_Aktionstaste.md) Aktionstaste
- Such-Pop-up: [HM-14](../Module/HM-14_Popup-Rahmen.md) Pop-up-Rahmen, [HM-13](../Module/HM-13_Eingabe-Pop-up.md) Eingabe-Pop-up (Variante Text). Die Trefferliste hat kein eigenes Modul (Modulwunsch im Bericht).

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

- **EA-Schaltfläche antippen:** Navigation nach HS-34 mit `cardGroup` und der ersten Karte der Gruppe (A-39). Der Brotkrümel von HS-34 zeigt die Gruppe („Einstellung › EA-Übersicht › Eingänge S1“). Es wird nichts geschaltet; die Seiten HS-33 und HS-34 sind Diagnoseseiten ohne Schreibzugriff.
- **Reservierte Kachel:** deaktiviert (gestrichelte Kontur und Text „Reserviert“); Tippen zeigt in der Meldezeile „Keine Kartengruppe belegt“ (A-28), keine Navigation.
- **Berechtigung, Wertebereiche, Einheiten, Standardwerte:** Das Handbuch nennt keine; die Seite ist ohne Rolle erreichbar und bedienbar (Navigation.md 5.4).
- **Taste „Suchen“ und Such-Pop-up:** modal nach Navigation.md 4.2 (Abdunkelung, Seiten- und Funktionsleiste gesperrt, kein Schließen durch Antippen außerhalb, kein Verlaufseintrag). Titel „Betriebsmittel suchen“, Texteingabe, gefilterte Trefferliste (Teilzeichenfolge ohne Unterscheidung von Groß-/Kleinschreibung über Kennzeichnung und Klartext). Treffer antippen öffnet HS-34 mit `cardGroup` und `cardIndex` der Karte, die das Betriebsmittel enthält (Annahme A-39). „Abbrechen“ und Kreuz schließen ohne Wirkung; ohne Treffer: „Kein Treffer“ mit `Icon.Status.Info`. Das Pop-up ist in der Referenz weder beschrieben noch abgebildet (OP-40, OP-30).
- **Zurück:** Seitenleiste „Zurück“ → Verlauf (normalerweise HS-04); Brotkrümel-Segment „Einstellung“ → HS-04. Bei offenem Pop-up ist „Zurück“ gesperrt. Von HS-34 kommend führt „Zurück“ auf diese Seite.
- **Fehlerfälle:** Meldet die Steuerung keine EA-Karten einer Gruppe, bleibt die Schaltfläche wählbar; HS-34 zeigt dann die Zustände als „Unbekannt“. Neue Meldungen bei offenem Pop-up öffnen HS-38 erst nach dem Schließen (Navigation.md 4.2, Punkt 7).

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-33-P01 | Seitentitel (RS-33-P01) | Letztes Brotkrümel-Segment lautet „EA-Übersicht“ (Handbuchname gewinnt, OP-33); die Bildschreibweise „EA Auswahl“ erscheint nicht | offen |
| HS-33-P02 | Anzahl und Beschriftung der EA-Schaltflächen (RS-33-P02) | 6 Kacheln: Eingänge S1, Ausgänge S1, Eingänge S300, Ausgänge S300, Eingänge S500, Ausgänge S500 | offen |
| HS-33-P03 | Anordnung (RS-33-P03) | Raster 4 Spalten; Zeile 1 mit 4 Kacheln (S1 Ein/Aus, S300 Ein/Aus), Zeile 2 mit 2 Kacheln (S500 Ein/Aus) und 2 „Reserviert“ | offen |
| HS-33-P04 | EA-Schaltfläche antippen (RS-33-P04) | Öffnet HS-34 mit der gewählten Kartengruppe; die zugehörigen Ein- bzw. Ausgänge werden zur Überprüfung angezeigt | offen |
| HS-33-P05 | Taste „Suchen“ (RS-33-P05) | Taste links in der Funktionsleiste; öffnet das Such-Pop-up zum Finden von Betriebsmitteln anhand der Betriebsmittelkennzeichnung; Treffer öffnet HS-34 | offen |
| HS-33-P06 | Meldezeile und Rahmentasten (RS-33-P06) | Meldezeile im Format „NNN: Text“; Schloss (Benutzerkreis), Produktion, Einstellungen, Zurück in der Seitenleiste; Funktionsleiste nur „Suchen“ | offen |
| HS-33-P07 | Navigation (RS-33-P07) | „Einstellung › EA-Übersicht“; Zugang über Kachel „EA Übersicht“ in HS-04; Zurück → HS-04 | offen |
| HS-33-P08 | Touch-Ziele (Designsystem) | Kacheln mindestens `Size.Touch.Large` hoch, Abstand mindestens `Size.Touch.Gap`; „Suchen“ mindestens `Size.Touch.Default` hoch; Trefferzeilen mindestens `Size.Touch.Min` hoch | offen |
| HS-33-P09 | Zweiter Kanal (Designsystem) | Reservierte Kachel durch gestrichelte Kontur und Text „Reserviert“ gekennzeichnet, nicht nur durch Farbe | offen |
| HS-33-P10 | Tokens (Designsystem) | Keine Hex-, Pixel- oder Literalwerte; Farben, Schriften, Maße nur als Tokens; Texte aus `.resx` | offen |
| HS-33-P11 | Keine Schreibaktion | Kein Element der Seite verändert einen Maschinenzustand | offen |
| HS-33-P12 | Rückverfolgung | Jede Zeile der Tabelle T43 und jedes Element des Bildes RS-33_01 ist in E01 bis E10 wiederzufinden | offen |
| HS-33-P13 | Such-Pop-up modal | Antippen außerhalb schließt nicht; „Zurück“ der Seitenleiste ist gesperrt; „Abbrechen“ schließt ohne Navigation | offen |

## Offene Punkte

- OP-30 (Eingabe-Pop-up undokumentiert) und OP-40 (Suchfunktion nicht beschrieben): Aufbau des Such-Pop-ups ist Annahme (Definition in HS-30).
- OP-33 (abweichende Seitentitel): Bild „EA Auswahl“ gegen Handbuch „EA-Übersicht“; Handbuchname gewinnt.
- OP-37 (Zugang EA-Anzeige): Zuordnung Schaltfläche zu Karte nicht beschrieben (A-14, A-39).
- OP-41 (geräteabhängige Elemente): Anzahl der Schaltflächen und Kürzel S1, S300, S500 maschinenabhängig und unerklärt.
