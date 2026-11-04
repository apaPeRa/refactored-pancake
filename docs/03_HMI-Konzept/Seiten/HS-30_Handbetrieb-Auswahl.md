# HS-30 – Handbetrieb Auswahl

- Quelle: [RS-30 Handbetrieb Auswahl](../../02_Referenz-Analyse/Seiten/RS-30_Handbetrieb-Auswahl.md) (Handbuch Kapitel „Handbetrieb Auswahl“, Tabelle T40, Bild [RS-30_01.png](../../02_Referenz-Analyse/Medien/RS-30_01.png)). Kein Design-Screenshot vorhanden: Aufbau abgeleitet aus [Designsystem](../Designsystem.md) (Kachelmenü wie DS-02 / HS-04), Kachelmodul [HM-16](../Module/HM-16_Kachel-Navigation.md) und den Rahmenmodulen.
- Navigationspfad (Brotkrümel laut [Navigation.md](../Navigation.md), Abschnitt 2): **Einstellung › Handbetrieb**. Zugang: HS-04, Kachel „Handbetrieb“. Zurück-Ziel: HS-04 (Verlauf). Seitenregister: `ManualSelection` / `settings/manual`, Eltern HS-04, keine Parameter, keine Mindestrolle.

## Zweck

Gezieltes Ansteuern einzelner Aktoren der Maschine für Inbetriebnahme, Wartung und Fehlersuche (Handbuch, RS-30 Zweck). Die Seite ist ein reines Auswahlmenü: Sie wählt über die Gruppentasten GR1 bis GR100 einen Maschinenbereich und führt auf die Aktorseite [HS-31](HS-31_Handbetrieb.md). Die Taste „Suchen“ findet einen Aktor über seine Betriebsmittelkennzeichnung. Die Seite selbst steuert nichts und ändert keinen Maschinenzustand (Navigation.md, Grundsatz 6).

## Aufbau (Bereiche, Layout)

Rahmen wie auf allen Seiten (Seitenleiste 3\* : Arbeitsbereich 37\*; Kopfzeile 4\*, Brotkrümel-/Kennzahlzeile 3\*, Inhalt 34\*, Funktionsleiste 4\*; [Designsystem](../Designsystem.md) 3.2). Der Inhaltsbereich hat Außenrand `Space.L` und das 12-Spalten-Raster (Abstand `Space.M` = `Size.Touch.Gap`).

- **Inhaltsbereich:** ein Kachelraster [HM-16](../Module/HM-16_Kachel-Navigation.md) mit **4 Spalten × 4 Zeilen** (jede Kachel belegt 3 von 12 Spalten), Kachelhöhe `Size.Touch.Large`, oben links beginnend (Muster HS-04). 14 Kacheln sind beschriftet, die letzten 2 Rasterzellen der Zeile 4 sind leer und erscheinen als „Reserviert“ (A-29, `EmptyTileMode = Reserved`). Der Raum unterhalb des Rasters bleibt frei.
- **Untere Funktionsleiste ([HM-06](../Module/HM-06_Funktionsleiste.md)):** eine seitenspezifische Taste „Suchen“, links beginnend (Navigation.md 3.3, Seitentyp „Suche“).
- Das Schloss und die Tasten „Produktion“, „Einstellungen“, „Zurück“ der Referenz-Fußleiste liegen in der Seitenleiste [HM-01](../Module/HM-01_Seitenleiste.md) (A-35).

```
Inhaltsbereich (12 Spalten; Raster 4 x 4, je Kachel 3 Spalten, Höhe Size.Touch.Large)
+------------------+------------------+------------------+------------------+
| GR1              | GR2              | GR3              | GR4              |
| Hauptantrieb     | Zuführung Papier | Zuführung Karton | Dornrad          |
+------------------+------------------+------------------+------------------+
| GR5 Dornrad      | GR6 Heizungen    | GR10             | GR11 Rüttlung    |
|                  |                  | Paketübergabe    |                  |
+------------------+------------------+------------------+------------------+
| GR14             | GR20             | GR41             | GR42             |
| Endkontrollwaage | Schließmaschine  | Hauptdosierer 1  | Hauptdosierer 2  |
+------------------+------------------+------------------+------------------+
| GR45             | GR100            | - - Reserviert - | - - Reserviert - |
| Nachdosierer     | Schnittstelle    | (gestrichelt)    | (gestrichelt)    |
+------------------+------------------+------------------+------------------+
                       (freier Raum bis zur Funktionsleiste)
Funktionsleiste:  [ Suchen ]
```

### Belegung des Rasters (Reihenfolge wie Bild RS-30_01)

| Zeile / Spalte | Beschriftung (`.resx`) | `groupId` | Ziel |
|---|---|---|---|
| 1 / 1 | GR1 Hauptantrieb | GR1 | HS-31 |
| 1 / 2 | GR2 Zuführung Papier | GR2 | HS-31 |
| 1 / 3 | GR3 Zuführung Karton | GR3 | HS-31 |
| 1 / 4 | GR4 Dornrad | GR4 | HS-31 |
| 2 / 1 | GR5 Dornrad | GR5 | HS-31 |
| 2 / 2 | GR6 Heizungen | GR6 | HS-31 |
| 2 / 3 | GR10 Paketübergabe | GR10 | HS-31 |
| 2 / 4 | GR11 Rüttlung | GR11 | HS-31 |
| 3 / 1 | GR14 Endkontrollwaage | GR14 | HS-31 |
| 3 / 2 | GR20 Schließmaschine | GR20 | HS-31 |
| 3 / 3 | GR41 Hauptdosierer 1 | GR41 | HS-31 |
| 3 / 4 | GR42 Hauptdosierer 2 | GR42 | HS-31 |
| 4 / 1 | GR45 Nachdosierer | GR45 | HS-31 |
| 4 / 2 | GR100 Schnittstelle | GR100 | HS-31 |
| 4 / 3, 4 / 4 | leer (Referenz) → „Reserviert“ | – | keines (deaktiviert) |

Die Gruppenliste ist konfigurationsabhängig (OP-41); das Raster zeigt die Gruppen der Maschinenkonfiguration in dieser Reihenfolge und füllt nicht belegte Zellen als „Reserviert“.

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)

Die Spalte „Herkunft (RS-30)“ ist die Rückverfolgung zur Referenzseite.

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-30) |
|---|---|---|---|---|
| E01 Brotkrümel „Einstellung › Handbetrieb“ | Anzeige / Navigation | Pfad der Seite; „Einstellung“ antippbar (→ HS-04), letztes Segment nur Anzeige. Ersetzt den Seitentitel „Handbetrieb Auswahl“ der Referenz-Kopfzeile | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | Kopfzeile (Seitentitel); Navigationspfad |
| E02 Kopfzeile: Logo, Betriebsart, Uhrzeit/Datum | Anzeige | Logo APA-TEC, Betriebsart (das unbeschriebene Wirbel-Symbol der Referenz wird als Betriebsart geführt, A-48), Uhrzeit mit Sekunden und Datum | [HM-02](../Module/HM-02_Kopfzeile.md) | Kopfzeile (Logo, Symbol, Uhrzeit „13:05:29“, Datum „12.05.2025“) |
| E03 Kennzahlen Geschwindigkeit und Maschinenwinkel | Anzeige | Rahmenelement des Designs (in der Referenz nicht vorhanden); Geschwindigkeit öffnet HS-03 | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | – (Rahmen, Design) |
| E04 Meldezeile „450: Palettierung nicht bereit“ | Anzeige | Wichtigste aktuelle Meldung im Format „NNN: Text“ statt „*450* …“; Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | Meldezeile „*450* Palettierung nicht bereit“ |
| E05 Seitenleiste: Benutzerkreis, Home, Einstellungen, Meldungen, Zurück | Navigation | Schloss → Benutzerkreis (Anmeldestatus, A-35); „Produktion“ → Home; „Einstellungen“ → HS-04; „Zurück“ → Verlauf (HS-04) | [HM-01](../Module/HM-01_Seitenleiste.md) | Schloss-Symbol; Tasten „Produktion“, „Einstellungen“, „Zurück“ |
| E06 Gruppentasten GR1 … GR100 (14 Kacheln, Raster 4 × 4) | Kachel-Taste | Antippen wählt Bereich/Gruppe an und öffnet HS-31 mit `groupId` (A-39). Beschriftung mehrzeilig mit automatischem Umbruch | [HM-16](../Module/HM-16_Kachel-Navigation.md) | Gruppentasten; T40 „Tasten Gruppenanwahl“; Bild |
| E07 Zwei leere Rasterzellen (Zeile 4, Spalten 3 und 4) | Kachel (deaktiviert) | „Reserviert“, gestrichelte Kontur, keine Aktion | [HM-16](../Module/HM-16_Kachel-Navigation.md) | leere Rasterzellen im Bild |
| E08 Funktionsleiste unten | Container | Nimmt „Suchen“ links auf; keine weiteren Tasten | [HM-06](../Module/HM-06_Funktionsleiste.md) | Untere Funktionsleiste |
| E09 Taste „Suchen“ | Taste (Antippen) | Öffnet das Such-Pop-up E10 | [HM-07](../Module/HM-07_Aktionstaste.md) | Taste „Suchen“; T40 „Suchen“ |
| E10 Such-Pop-up „Aktor suchen“ | Pop-up (modal) | Suche nach Betriebsmittelkennzeichnung; Ablauf, Filter und Darstellung siehe HM-38. Seitenspezifisch: Treffer öffnet HS-31 mit `groupId` und `actorId` | [HM-38](../Module/HM-38_Such-Pop-up.md) (Titel „Aktor suchen“) in [HM-14](../Module/HM-14_Popup-Rahmen.md) | T40 „Suchen“ (Suchfunktion nicht abgebildet) |

## Verwendete Module (IDs)

- Rahmen: [HM-01](../Module/HM-01_Seitenleiste.md) Seitenleiste, [HM-02](../Module/HM-02_Kopfzeile.md) Kopfzeile, [HM-03](../Module/HM-03_Meldezeile.md) Meldezeile, [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) Brotkrümel-Navigation, [HM-05](../Module/HM-05_Kennzahl-Kachel.md) Kennzahl-Kachel, [HM-06](../Module/HM-06_Funktionsleiste.md) Funktionsleiste
- Seite: [HM-16](../Module/HM-16_Kachel-Navigation.md) Kachel-Navigation, [HM-07](../Module/HM-07_Aktionstaste.md) Aktionstaste
- Such-Pop-up: [HM-38](../Module/HM-38_Such-Pop-up.md) Such-Pop-up (im Rahmen [HM-14](../Module/HM-14_Popup-Rahmen.md)); Aufbau, Filterlogik, Trefferliste und Zustände sind dort definiert.

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

- **Gruppentaste antippen:** Navigation nach HS-31 mit `groupId` (die Taste löst beim Loslassen im Ziel aus, Designsystem 5). Der Brotkrümel von HS-31 zeigt die Gruppe („Einstellung › Handbetrieb › GR20 Schließmaschine“). Es wird keine Maschinenfunktion ausgelöst.
- **Reservierte Kachel:** deaktiviert (gestrichelte Kontur und Text „Reserviert“); Tippen zeigt in der Meldezeile den Hinweis „Keine Gruppe belegt“ (A-28), keine Navigation.
- **Berechtigung:** Die Referenz nennt kein Schlüsselsymbol auf dieser Seite; die Seite ist für jeden angemeldeten Benutzer frei (Navigation.md 5.4, OP-25). Die Berechtigungsprüfung findet auf HS-31 an den Bedienelementen statt.
- **Taste „Suchen“ und Such-Pop-up** (Aufbau und Verhalten: [HM-38](../Module/HM-38_Such-Pop-up.md); modal nach Navigation.md 4.2):
  - Seitenspezifisch: Titel „Aktor suchen“; ein Treffer schließt das Pop-up und öffnet HS-31 mit `groupId` und `actorId` des Treffers. „Abbrechen“ und Kreuz schließen ohne Navigation.
  - Aufbau und Verhalten der Suche sind in der Referenz nicht beschrieben (OP-40, OP-30): Annahme A-59 in HM-38.
- **Zurück:** Seitenleiste „Zurück“ geht im Verlauf zurück (normalerweise HS-04). Ein Tippen auf das Brotkrümel-Segment „Einstellung“ führt direkt auf HS-04. Bei offenem Pop-up ist „Zurück“ gesperrt, das Pop-up wird mit „Abbrechen“ geschlossen.
- **Fehlerfälle:** Eine Gruppe, deren Aktoren die Steuerung nicht meldet, bleibt wählbar; HS-31 zeigt dann Werte als ungültig („---“). Meldungen der Meldezeile werden bei offenem Pop-up erst nach dem Schließen auf HS-38 geöffnet (Navigation.md 4.2, Punkt 7).

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-30-P01 | Seitentitel (RS-30-P01) | Letztes Brotkrümel-Segment lautet „Handbetrieb“ (Navigation.md); Seitenname „Handbetrieb Auswahl“ ist Fenster-/Automationsname; die Kopfzeile trägt keinen zweiten Titel | offen |
| HS-30-P02 | Anzahl und Beschriftung der Gruppentasten (RS-30-P02) | 14 Kacheln: GR1 Hauptantrieb, GR2 Zuführung Papier, GR3 Zuführung Karton, GR4 Dornrad, GR5 Dornrad, GR6 Heizungen, GR10 Paketübergabe, GR11 Rüttlung, GR14 Endkontrollwaage, GR20 Schließmaschine, GR41 Hauptdosierer 1, GR42 Hauptdosierer 2, GR45 Nachdosierer, GR100 Schnittstelle | offen |
| HS-30-P03 | Anordnung (RS-30-P03) | Raster 4 Spalten × 4 Zeilen in der Reihenfolge der Belegungstabelle; Zeile 4 trägt nur zwei beschriftete Kacheln, die zwei übrigen sind „Reserviert“ | offen |
| HS-30-P04 | Taste „Suchen“ (RS-30-P04) | Taste links in der Funktionsleiste; öffnet das Such-Pop-up (HM-38) zur Suche nach Betriebsmittelkennzeichnung; Treffer öffnet HS-31 | offen |
| HS-30-P05 | Gruppentaste antippen (RS-30-P05) | Öffnet HS-31 mit der gewählten `groupId`; es wird keine Maschinenfunktion ausgelöst | offen |
| HS-30-P06 | Meldezeile (RS-30-P06) | Zeigt die aktive Meldung mit Nummer und Text im Format „NNN: Text“; Antippen öffnet HS-38 | offen |
| HS-30-P07 | Rahmentasten (RS-30-P07) | Schloss/Benutzer, Produktion (Home), Einstellungen, Zurück sind in der Seitenleiste erreichbar; die Funktionsleiste enthält nur „Suchen“ | offen |
| HS-30-P08 | Brotkrümel und Zugang (RS-30-P08) | „Einstellung › Handbetrieb“; Zugang über die Kachel „Handbetrieb“ in HS-04; „Einstellung“ antippbar | offen |
| HS-30-P09 | Zweck (RS-30-P09) | Zweck „einzelne Aktoren gezielt ansteuern (Inbetriebnahme, Wartung, Fehlersuche)“ ist in dieser Seitenbeschreibung dokumentiert; die Seite löst selbst keine Bewegung aus | offen |
| HS-30-P10 | Touch-Ziele (Designsystem) | Kacheln mindestens `Size.Touch.Large` hoch, Abstand mindestens `Size.Touch.Gap`; Taste „Suchen“ mindestens `Size.Touch.Default` hoch und `Size.FunctionButton.MinWidth` breit; Trefferzeilen mindestens `Size.Touch.Min` hoch | offen |
| HS-30-P11 | Zweiter Kanal (Designsystem) | Reservierte Kachel: gestrichelte Kontur und Text „Reserviert“, nicht nur Farbe; Pop-up-Fehlerfälle mit Symbol und Text | offen |
| HS-30-P12 | Tokens (Designsystem) | Keine Hex-, Pixel- oder Literalwerte in der Seite; Farben, Schriften, Maße nur als Tokens (`Brush.*`, `Font.*`, `Size.*`, `Space.*`); Texte aus `.resx` | offen |
| HS-30-P13 | Beschriftung | Mehrzeilige Kacheltexte brechen automatisch an Wortgrenzen um, keine Trennstriche (OP-13) | offen |
| HS-30-P14 | Rückverfolgung | Jede Zeile der Tabelle T40 und jedes Element des Bildes RS-30_01 ist in der Elementetabelle (E01 bis E10) wiederzufinden | offen |
| HS-30-P15 | Such-Pop-up (HM-38) | Modal; Antippen außerhalb schließt nicht; „Zurück“ der Seitenleiste ist gesperrt; Filter und Trefferliste nach HM-38; „Abbrechen“ schließt ohne Navigation | offen |

## Offene Punkte

- OP-25 (Schlüsselsymbol/Berechtigungsstufen): auf dieser Seite kein Schlüssel; Annahme „frei erreichbar“.
- OP-26 (Schloss- und Wirbel-Symbol): Schloss → Benutzerkreis (A-35), Wirbel-Symbol → Betriebsart (A-48); Klärung offen.
- OP-30 (Eingabe-Pop-up undokumentiert) und OP-40 (Suchfunktion nicht beschrieben): Aufbau des Such-Pop-ups ist Annahme (HM-38, A-59).
- OP-35 (Quellfehler): der Handbuchsatz zu „Tasten Gruppenanwahl“ ist unvollständig; die Funktion ist aus Zweck und Bild abgeleitet.
- OP-37 (Zugang Handbetrieb): Wechsel zur Aktorseite abgeleitet (A-14, A-39).
- OP-41 (geräteabhängige Elemente): Anzahl und Namen der Gruppen sind maschinenabhängig.
- OP-58 die doppelte Beschriftung „Dornrad“ bei GR4 und GR5 (RS-30, Offene Punkte 4) bleibt unverändert übernommen; Bedeutung (z. B. Dornrad 1/2) ungeklärt.
