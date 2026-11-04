# HS-34 – EA-Anzeige

- Quelle: [RS-34 EA-Anzeige](../../02_Referenz-Analyse/Seiten/RS-34_EA-Anzeige.md) (Handbuch Kapitel „EA-Anzeige“, Tabelle T44, Bild [RS-34_01.png](../../02_Referenz-Analyse/Medien/RS-34_01.png)). Kein Design-Screenshot vorhanden: Aufbau abgeleitet aus [Designsystem](../Designsystem.md) und den HM-Modulen.
- Navigationspfad (Brotkrümel laut [Navigation.md](../Navigation.md), Abschnitt 2): **Einstellung › EA-Übersicht › `<Karte>`** (Beispiel „Einstellung › EA-Übersicht › Eingänge S1“; das letzte Segment trägt den Namen der Kartengruppe). Zugang: HS-33, EA-Schaltfläche (Parameter `cardGroup`); Such-Pop-up: Treffer (Parameter `cardGroup`, `cardIndex`). Zurück-Ziel: HS-33. Seitenregister: `IoDisplay` / `settings/io/card`, Eltern HS-33, keine Mindestrolle.

## Zweck

Diagnose aller digitalen und analogen Ein- und Ausgänge an der SPS: Die Seite zeigt den aktuellen Zustand der angeschlossenen Betriebsmittel und Signale einer EA-Karte (Handbuch, RS-34 Zweck). Jede Karte steht auf einer eigenen Seite, mit den Blättertasten wird zwischen den Karten der gewählten Gruppe gewechselt. Reine Anzeigeseite: kein Bedienelement außer dem Blättern, kein Schreibzugriff auf Signale.

## Aufbau (Bereiche, Layout)

Rahmen wie auf allen Seiten (Seitenleiste 3\* : Arbeitsbereich 37\*; Zeilen 4\* : 3\* : 34\* : 4\*). Der Inhaltsbereich hat Außenrand `Space.L` und das 12-Spalten-Raster (Abstand `Size.Touch.Gap`).

- **Objektüberschrift** (Auto): Titelzeile mit der Kartenbezeichnung (Beispiel „S1_0KDE1“), 12 Spalten.
- **Signalliste** (Stern): die Zeilen der Karte untereinander, jede Zeile über 12 Spalten in der Aufteilung Status-LED mit Zustandswort (Spalten 1–2), SPS-Kennung (Spalten 3–5), Klartextbeschreibung (Spalten 6–12). Zeilenhöhe mindestens `Size.Touch.Min`, Abstand `Space.S`. Die Referenzkarte hat 8 Zeilen; passen mehr Zeilen nicht in den Bereich, scrollt die Liste (`Icon.Scroll.Up`/`.Down`). Auf Analogkarten steht in der Zeile ein Zahlenwert statt der LED.
- **Untere Funktionsleiste ([HM-06](../Module/HM-06_Funktionsleiste.md)):** die Blättertasten „«“ und „»“ links beginnend (Navigation.md 3.3, Seitentyp „Blättern“); keine Taste „Suchen“ (RS-34-P07).
- Das Schloss und die Tasten „Produktion“, „Einstellungen“, „Zurück“ der Referenz-Fußleiste liegen in der Seitenleiste [HM-01](../Module/HM-01_Seitenleiste.md) (A-35).

```
Inhaltsbereich (12 Spalten)
+--------------------------------------------------------------------+
|                    S1_0KDE1                (HM-17, Sp. 1-12)       |
+--------------------------------------------------------------------+
| LED+Wort  | Kennung        | Klartext                              |
| Sp. 1-2   | Sp. 3-5        | Sp. 6-12                              |
+-----------+----------------+---------------------------------------+
| ( ) Aus   | 0F24A_rdy      | SICHERUNGS MODUL BEREIT (0F24A)       |
| ( ) Aus   | 0F24A_state    | SICHERUNGS MODUL STATUS (0F24A)       |
| ( ) Aus   | S1_0KDE1_3     | RESERVE                               |
| ( ) Aus   | S1_0KDE1_4     | RESERVE                               |
| ( ) Aus   | 0E3            | KUEHLGERAET BEREIT                    |
| ( ) Aus   | S1_0KDE1_6     | RESERVE                               |
| ( ) Aus   | 0Q5            | SPANNUNG FU-ANTRIEBE OK               |
| ( ) Aus   | 0Q7            | SPANNUNG SERVO-ANTRIEBE OK            |
+-----------+----------------+---------------------------------------+
Funktionsleiste:  [ << ] [ >> ]   (1 von n)
```

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)

Die Spalte „Herkunft (RS-34)“ ist die Rückverfolgung zur Referenzseite (Elementetabelle, T44, Bild).

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-34) |
|---|---|---|---|---|
| E01 Brotkrümel „Einstellung › EA-Übersicht › `<Karte>`“ | Anzeige / Navigation | Pfad; „Einstellung“ → HS-04, „EA-Übersicht“ → HS-33, letztes Segment (Kartengruppe, z. B. „Eingänge S1“) nur Anzeige. Ersetzt den Seitentitel „Eingänge S1“ der Referenz-Kopfzeile; beim Blättern innerhalb der Gruppe bleibt das Segment, die Karte wechselt in E06 | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | Kopfzeile (Titel „Eingänge S1“); Navigationspfad |
| E02 Kopfzeile: Logo, Betriebsart, Uhrzeit/Datum | Anzeige | Logo, Betriebsart (Wirbel-Symbol → A-48), Uhrzeit „13:05:52“ als Beispiel, Datum | [HM-02](../Module/HM-02_Kopfzeile.md) | Kopfzeile |
| E03 Kennzahlen Geschwindigkeit, Maschinenwinkel | Anzeige | Rahmenelement des Designs | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | – (Rahmen) |
| E04 Meldezeile „450: Palettierung nicht bereit“ | Anzeige | Wichtigste Maschinenmeldung; Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | Meldezeile |
| E05 Seitenleiste | Navigation | Benutzerkreis (Schloss), Home („Produktion“), Einstellungen, Meldungen, Zurück (→ HS-33) | [HM-01](../Module/HM-01_Seitenleiste.md) | Schloss; Tasten „Produktion“, „Einstellungen“, „Zurück“ |
| E06 Karten-Überschrift „S1_0KDE1“ | Anzeige (Text) | Bezeichnung der angezeigten EA-Karte; wechselt mit den Blättertasten. Fettschrift und Trennlinie statt Unterstreichung | [HM-17](../Module/HM-17_Titelzeile.md) | Karten-Überschrift |
| E07 Digitale Anzeige: Statusleuchte mit SPS-Kennung und Klartext (8 Zeilen der Karte S1_0KDE1) | Signalzeile | Je digitalem Ein- oder Ausgang eine Status-LED (Aus: leerer Kreis und Wort „Aus“; Ein: Haken und Wort „Ein“), daneben SPS-Kennung und Klartextbeschreibung. Zeileninhalt siehe Tabelle unten | [HM-36](../Module/HM-36_EA-Zeile.md), darin [HM-09](../Module/HM-09_Status-LED.md) (Zeile, kompakt mit Wort) | Digitale Anzeige (LED); T44 „Digitale Anzeige (LED)“; Bild |
| E08 Analoge Anzeige | Signalzeile, numerisch | Analoge Ein- oder Ausgänge als numerische Werte; nur auf speziellen Analogkarten aktiv; Einheit und Format offen (im Bild nicht dargestellt) | [HM-36](../Module/HM-36_EA-Zeile.md) (Art Analog) in der Wertdarstellung von [HM-11](../Module/HM-11_Anzeigefeld.md) (Zeile, mit Beschriftung) | Analoge Anzeige; T44 „Analoge Anzeige“ |
| E09 Funktionsleiste unten | Container | Nimmt die Blättertasten links auf; keine weiteren Tasten, keine Taste „Suchen“ | [HM-06](../Module/HM-06_Funktionsleiste.md) | Untere Funktionsleiste (ohne „Suchen“) |
| E10 Navigationstasten „<<“ / „>>“ | Blättertasten (Funktionsleiste) | Blättern zwischen den einzelnen EA-Karten der Gruppe; jede Karte ist eine eigene Seite; Positionsanzeige „n von m“; am Rand deaktiviert | [HM-19](../Module/HM-19_Blaettertasten.md) (in HM-06) | Navigationstasten; T44 „Navigationstasten << / >>“ |

### Zeilen der Karte S1_0KDE1 (Bildbeispiel, Rückverfolgung zu E07)

| Nr. | SPS-Kennung | Klartext | Zustand im Bild |
|---|---|---|---|
| 1 | 0F24A_rdy | SICHERUNGS MODUL BEREIT (0F24A) | Aus |
| 2 | 0F24A_state | SICHERUNGS MODUL STATUS (0F24A) | Aus |
| 3 | S1_0KDE1_3 | RESERVE | Aus |
| 4 | S1_0KDE1_4 | RESERVE | Aus |
| 5 | 0E3 | KUEHLGERAET BEREIT | Aus |
| 6 | S1_0KDE1_6 | RESERVE | Aus |
| 7 | 0Q5 | SPANNUNG FU-ANTRIEBE OK | Aus |
| 8 | 0Q7 | SPANNUNG SERVO-ANTRIEBE OK | Aus |

Der Klartext wird unverändert aus der Konfiguration angezeigt (Großbuchstaben und ASCII-Schreibung „KUEHLGERAET“ wie in der Referenz, keine Normalisierung; OP-43, RS-34 Offene Punkte 4). Reservekanäle zeigen den Klartext „RESERVE“ in `Brush.Text.Secondary`.

## Verwendete Module (IDs)

- Rahmen: [HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md)
- Seite: [HM-17](../Module/HM-17_Titelzeile.md) Titelzeile, [HM-36](../Module/HM-36_EA-Zeile.md) EA-Zeile, [HM-09](../Module/HM-09_Status-LED.md) Status-LED (über HM-36), [HM-11](../Module/HM-11_Anzeigefeld.md) Anzeigefeld (Analogwert), [HM-19](../Module/HM-19_Blaettertasten.md) Blättertasten

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

- **Reine Anzeigeseite:** keine Eingabe, keine Pop-ups, keine Berechtigungsprüfung (Handbuch: keine Angaben; Navigation.md 5.4), kein Schreibzugriff auf Signale.
- **LED-Zustände:** Die Referenz zeigt nur „alle grau“; die Farbe des aktiven Zustands ist im Handbuch nicht beschrieben (OP-27, OP-43). Neu: Aus = `Icon.Status.Inactive` (leerer Kreis) und Wort „Aus“; Ein = `Icon.Status.Ok` (Haken) und Wort „Ein“, in beiden Fällen ergänzt durch das Wort, nicht nur durch Farbe. Der HM-36-Zustand „Fehler“ (Zeile mit `Brush.Status.Error.Subtle`) bleibt auf dieser Seite ungenutzt, weil die Referenz keinen Fehlerzustand eines Kanals kennt.
- **Aktualisierung:** Zustände aktualisieren sich laufend (Dummy-Daten über die Schnittstelle, Takt im ViewModel); die Seite hat keinen Aktualisierungs-Knopf.
- **Datenverlust:** Ist die SPS nicht erreichbar, zeigen alle LEDs „Unbekannt“ (Text „---“, `Brush.Status.Inactive.Fg`), analoge Werte „---“; die Meldezeile nennt die Störung.
- **Analoge Karten:** Auf Karten mit analogen Signalen zeigt die Zeile den Zahlenwert statt der LED (Einheit je Kanal, offen, OP-29). Digitale und analoge Zeilen können je Karte gemischt auftreten.
- **Blättern:** « und » ersetzen nur `cardIndex` (kein Verlaufseintrag, A-42); Titelzeile E06 und Liste wechseln. Das Blättern geschieht innerhalb der gewählten Gruppe (A-39); am Rand sind die Tasten deaktiviert (gestrichelt, nicht umlaufend), „n von m“ nennt die Stellung. Anzahl der Karten je Gruppe ist maschinenabhängig (OP-41, OP-37).
- **Zugang über Suche:** Der Treffer aus dem Such-Pop-up von HS-33 öffnet die Karte, die das Betriebsmittel enthält (Parameter `cardGroup` und `cardIndex`); die Zeile des Treffers wird nicht gesondert hervorgehoben (Annahme, kein HM-Zustand dafür).
- **Zurück:** Seitenleiste „Zurück“ → HS-33 (Verlauf); Brotkrümel-Segmente springen nach HS-33 bzw. HS-04. Beim Blättern entsteht kein Verlaufseintrag, „Zurück“ führt daher immer in die Übersicht.
- **Meldungen:** Die Meldezeile öffnet HS-38 durch Antippen; Meldungen verändern die Signalliste nicht.

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-34-P01 | Seitentitel (RS-34-P01) | Letztes Brotkrümel-Segment nennt die Kartengruppe, im Beispiel „Eingänge S1“ | offen |
| HS-34-P02 | Karten-Überschrift (RS-34-P02) | Im Beispiel „S1_0KDE1“ (Titelzeile, keine Unterstreichung) | offen |
| HS-34-P03 | Zeilen der Karte S1_0KDE1 (RS-34-P03) | 8 Zeilen: 0F24A_rdy, 0F24A_state, S1_0KDE1_3, S1_0KDE1_4, 0E3, S1_0KDE1_6, 0Q5, 0Q7 mit den Klartexten SICHERUNGS MODUL BEREIT (0F24A), SICHERUNGS MODUL STATUS (0F24A), RESERVE, RESERVE, KUEHLGERAET BEREIT, RESERVE, SPANNUNG FU-ANTRIEBE OK, SPANNUNG SERVO-ANTRIEBE OK | offen |
| HS-34-P04 | Digitale Anzeige (RS-34-P04) | Je digitalem Ein-/Ausgang eine Statusleuchte mit Symbol und Wort, daneben SPS-Kennung und Klartextbeschreibung | offen |
| HS-34-P05 | Analoge Anzeige (RS-34-P05) | Auf Analogkarten werden Ein-/Ausgänge als numerische Werte statt der LED angezeigt | offen |
| HS-34-P06 | Tasten „<<“ und „>>“ (RS-34-P06) | Blättern zwischen den EA-Karten der Gruppe, jede Karte eine eigene Seite, „n von m“, am Rand deaktiviert, kein Verlaufseintrag | offen |
| HS-34-P07 | Untere Funktionsleiste und Rahmentasten (RS-34-P07) | Keine Taste „Suchen“; die Funktionsleiste enthält nur die Blättertasten; Schloss (Benutzerkreis), Produktion, Einstellungen, Zurück in der Seitenleiste | offen |
| HS-34-P08 | Navigation (RS-34-P08) | „Einstellung › EA-Übersicht › `<Karte>`“; Zugang von HS-33 (Schaltfläche oder Suche); „EA-Übersicht“ antippbar; Zurück → HS-33 | offen |
| HS-34-P09 | Zustände ohne Farbe | Aus und Ein sind durch Symbol (leerer Kreis, Haken) und Wort unterscheidbar, auch ohne Farbwahrnehmung | offen |
| HS-34-P10 | Meldezeile | Zeigt die aktive Meldung im Format „NNN: Text“ (Referenzbeispiel „*450* Palettierung nicht bereit“); Antippen öffnet HS-38 | offen |
| HS-34-P11 | Datenverlust | Bei fehlender SPS-Verbindung zeigen LEDs „Unbekannt“ mit „---“, analoge Werte „---“ | offen |
| HS-34-P12 | Touch-Ziele (Designsystem) | Zeilen mindestens `Size.Touch.Min` hoch (Abstand `Space.S`); Blättertasten mindestens `Size.Touch.Default` × `Size.Touch.Default`, Abstand mindestens `Size.Touch.Gap` | offen |
| HS-34-P13 | Zweiter Kanal und Lesbarkeit (Designsystem) | Zustandswort, Symbol und Klartext sind Schrift mindestens `Font.Size.Body`; Reserve in `Brush.Text.Secondary` mit Text „RESERVE“ | offen |
| HS-34-P14 | Tokens (Designsystem) | Keine Hex-, Pixel- oder Literalwerte; Farben, Schriften, Maße nur als Tokens; Texte aus `.resx`; Klartexte der Konfiguration unverändert | offen |
| HS-34-P15 | Rückverfolgung | Jede Zeile der Tabelle T44 und jedes Element des Bildes RS-34_01 ist in E01 bis E10 wiederzufinden | offen |

## Offene Punkte

- OP-27 (Farbbedeutung der LEDs) und OP-43 (Zustände nur über Farbe): Zustand „aktiv“ im Handbuch nicht beschrieben; Darstellung nach Designsystem mit Symbol und Wort.
- OP-29 (Einheiten und Format): Analoganzeige im Bild nicht vorhanden, Einheit und Format offen.
- OP-33 (abweichende Seitentitel): Bildtitel „Eingänge S1“ gegen Handbuchname „EA-Anzeige“; sichtbar ist der Name der Kartengruppe als letztes Brotkrümel-Segment (Navigation.md).
- OP-37 (Zugang EA-Anzeige): Zuordnung Schaltfläche zu Karte und Anzahl der Karten je Gruppe nicht beschrieben (A-14, A-39).
- OP-41 (geräteabhängige Elemente): Anzahl der Karten, Zeilen je Karte und analoge Karten sind maschinenabhängig.
- Ohne OP-Eintrag im Seiten-Index (Hinweis an den Verwalter): Übernahme der Klartexte in Großbuchstaben und ASCII-Schreibung (RS-34, Offene Punkte 4) ist als „unverändert“ entschieden; Normalisierung bleibt offen.
