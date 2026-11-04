# HS-04 – Einstellungen
- Quelle: [RS-04](../../02_Referenz-Analyse/Seiten/RS-04_Einstellungen.md) (Funktion: Tabelle T4, 18 Kacheln; Bild RS-04_01) und [DS-02](../../01_Design-Analyse/Seiten/DS-02_Einstellungen.md) (Layout: `src_Data/Design/Seite_Einstellungen.png`; Design-Seite DS-02 = HS-04 nach A-46)   - Navigationspfad: Einstellung (Brotkrümel mit einem Segment; Zugang über Seitenleiste „Einstellungen“, Verlauf `[HS-01]`; Zurück-Ziel: Verlauf, sonst HS-01; [Navigation.md](../Navigation.md) Abschnitt 2)

## Zweck
Zentrale Einstiegsseite zu allen Seiten für Konfiguration und Fehlerbeseitigung (Handbuch: „Die Einstellungs-Seite ist die zentrale Seite um zu allen Seiten zu kommen, welche für die Konfiguration und Fehlerbeseitigung nötig sind.“). Die Seite hat keine eigenen Parameter, Zahlenfelder oder Statusanzeigen, sondern nur Kachel-Tasten zur Navigation, einen Schnellzugriff („Beleuchtung“) und in der Funktionsleiste die Sprachwahl. Navigation ändert keinen Maschinenzustand (Navigation.md Abschnitt 0, Punkt 6).

Funktion und Ziele der Kacheln folgen der Referenz (T4), Aufbau, Anordnung und Beschriftung dem Design (DS-02, 16 Kachelplätze). Weil das Design 16 Plätze gegenüber 18 Referenzeinträgen hat, gelten die Gruppierungen und Belegungen nach A-36: „Zuführungen“ (statt der Einzelkacheln „Zuführung Papier“ und „Zuführung Karton“), „Dosierer“ (statt „Hauptdosierer“ und „Nachdosierer“) und „Waagen“ (statt „Kontrollwaage“, „Endkontrollwaage“, „Waagen kalibrieren“) führen über je eine Zwischenseite (HS-40, HS-41, HS-42), sodass alle 18 Referenzfunktionen erreichbar bleiben (RS-04-P09).

## Aufbau (Bereiche, Layout)
Rahmen nach [Designsystem](../Designsystem.md) Abschnitt 3.2 (Seitenleiste 3\* : Arbeitsbereich 37\*; Kopfzeile 4\*, Brotkrümel-/Kennzahlzeile 3\*, Inhalt 34\*, Funktionsleiste 4\*). Der Inhaltsbereich folgt dem 12-Spalten-Raster (Außenrand `Size.Content.Margin`, Gutter `Space.M`) mit der Aufteilung von DS-02: **4 : 4 : 4** Spalten, eine Zeile über die volle Inhaltshöhe.

```
Inhaltsbereich (12 Spalten, 4 : 4 : 4)
+---------------------+-----------------------------+-----------------------------+
| Gruppe              | Gruppe Mitte (HM-15)        | Gruppe Rechts (HM-15)       |
| „Anwählen/Schnelle  | +-------------+-----------+ | +-------------+-----------+ |
|  Einstellungen“     | |Zuführungen  |Schließma- | | |Nockenschalt-|Handbetrieb| |
|  (HM-15)            | |             |schine     | | |werk         |           | |
|                     | +-------------+-----------+ | +-------------+-----------+ |
| [Beleuchtung]       | |Dosierer     |Heizungen  | | |Produktions- |Geräte     | |
|  (Kachel klein)     | +-------------+-----------+ | |statistik    |(reserv.)  | |
|                     | |Regulierung  |Geber      | | +-------------+-----------+ |
|                     | |             |setzen     | | |(Reserviert) |EA Über-   | |
|                     | +-------------+-----------+ | |             |sicht      | |
|                     | |Waagen       |Packungs-  | | +-------------+-----------+ |
|                     | |             |register   | | |Bildschirm   |System-    | |
|                     | |             |           | | |reinigen     |einstellun.| |
|                     | +-------------+-----------+ | +-------------+-----------+ |
+---------------------+-----------------------------+-----------------------------+
Funktionsleiste: [Sprache]
```

- **Linke Gruppe (4 Spalten):** Gruppenbereich mit Überschrift „Anwählen/Schnelle Einstellungen“ (Rechtschreibung korrigiert, Unterstreichung entfällt). Darin oben links die kleine Kachel „Beleuchtung“ (Höhe `Size.Touch.Default`); darunter bleibt die Fläche frei (Platz für weitere Schnellzugriffe, nichts erfunden).
- **Mittlere und rechte Gruppe (je 4 Spalten):** je ein Gruppenbereich ohne Überschrift (das Design hat keine Gruppenbeschriftung) mit einem Kachelraster 2 Spalten × 4 Zeilen, Kachelhöhe `Size.Touch.Large`, Abstand `Size.Touch.Gap`. Zeilenhöhen und Spaltenbreiten sind Stern-Anteile; die Kachelbreite ist mindestens `Size.Button.MinWidth`. Die Gruppen haben für die Barrierefreiheit die Namen „Anlage“ (Mitte) und „System“ (rechts), ohne sichtbare Überschrift (Annahme, nicht aus Design oder Referenz).
- **Kachelbeschriftung:** Wörter ohne Trennstrich, automatischer Umbruch (OP-13, Designsystem 11): „Schließmaschine“, „Packungsregister“, „Nockenschaltwerk“, „Systemeinstellungen“. Layouts planen +40 % Textbreite ein.
- **Reihenfolge der Tab-/Fokus-Navigation:** links nach rechts, oben nach unten (Beleuchtung, Mitte Zeile 1 bis 4, rechts Zeile 1 bis 4, Funktionsleiste).
- **Funktionsleiste:** links die Taste „Sprache“, sonst leer (Navigation.md 3.3).

### Kachelbelegung (A-36, Design-Reihenfolge)

| Gruppe | Zeile | Spalte 1 | Spalte 2 |
|---|---|---|---|
| Mitte | 1 | Zuführungen (HS-40) | Schließmaschine (HS-16) |
| Mitte | 2 | Dosierer (HS-41) | Heizungen (HS-22) |
| Mitte | 3 | Regulierung (HS-23) | Geber setzen (HS-32) |
| Mitte | 4 | Waagen (HS-42) | Packungsregister (HS-28) |
| Rechts | 1 | Nockenschaltwerk (HS-25) | Handbetrieb (HS-30) |
| Rechts | 2 | Produktionsstatistik (HS-29) | Geräte (reserviert, ohne Ziel) |
| Rechts | 3 | (Reserviert, frei) | EA Übersicht (HS-33) |
| Rechts | 4 | Bildschirm reinigen (HS-24) | Systemeinstellungen (HS-35) |

Gegenüber DS-02 sind drei der vier leeren Design-Kacheln belegt: Mitte Zeile 3 mit Regulierung und Geber setzen, Rechts Zeile 2 links mit Produktionsstatistik (A-36, OP-05). „Geräte“ (Rechts Zeile 2 rechts) und die freie Kachel (Rechts Zeile 3 links) bleiben an den Plätzen des Entwurfs.

## Elemente

Spalte „Herkunft“ = Rückverfolgung: RS-04 Teil A (Rahmen), Teil B (Funktionstabelle T4, Nr. 1 bis 20, Raster Zeile/Spalte), DS-02 (Elementtabelle).

### Rahmen

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Seitenleiste: Benutzerkreis „MM“, Name, Rolle | Anzeige und Taste | öffnet das Benutzer-Pop-up (Anmelden, Abmelden); ersetzt das gelbe Schloss-Symbol der Referenz (A-35) | [HM-01](../Module/HM-01_Seitenleiste.md) | RS-04 Teil A „Schloss-Symbol (gelb)“; DS-02 Rahmen |
| Seitenleiste: Taste „Home“ | Navigationstaste | HS-01, Verlauf wird auf `[]` zurückgesetzt | [HM-01](../Module/HM-01_Seitenleiste.md) | RS-04 Teil A „Taste Produktion“ |
| Seitenleiste: Taste „Einstellungen“ | Navigationstaste (hervorgehoben) | aktuelle Hauptgruppe; auf dieser Seite ohne Wirkung | [HM-01](../Module/HM-01_Seitenleiste.md) | RS-04 Teil A „Taste Einstellungen“ |
| Seitenleiste: Taste „Meldungen“ | Navigationstaste | HS-38 Meldeanzeige, mit Zähler-Punkt bei neuen Meldungen | [HM-01](../Module/HM-01_Seitenleiste.md) | DS-02 Rahmen (OP-08) |
| Seitenleiste: Taste „Zurück“ | Verlaufstaste | oberster Verlaufseintrag, sonst HS-01 | [HM-01](../Module/HM-01_Seitenleiste.md) | RS-04 Teil A „Taste Zurück“ |
| Logo APA·TEC | Grafik | Anzeige | [HM-02](../Module/HM-02_Kopfzeile.md) | RS-04 Teil A „Logo“ |
| Seitentitel „Einstellungen“ | Text | entfällt als eigenes Element; der Seitenname steht als letztes Segment des Brotkrümels („Einstellung“) | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | RS-04 Teil A „Seitentitel“; DS-02 Brotkrümel |
| Spiralsymbol (Referenz) | Symbol | wird als Betriebsart „Service“ mit Warnstatus geführt (`Icon.Mode.Service`, Warnfläche, Wort „Service“; A-48, HM-02); im Normalzustand zeigt HM-02 neutral „Produktion“ (DS-01) | [HM-02](../Module/HM-02_Kopfzeile.md) | RS-04 Teil A „Spiralsymbol“ (OP-26) |
| Uhrzeit und Datum | Anzeige | aktuelle Uhrzeit und Datum | [HM-02](../Module/HM-02_Kopfzeile.md) | RS-04 Teil A „Uhrzeit und Datum“ |
| Meldezeile | Anzeige und Taste | zeigt die anstehende Meldung („NNN: Text“, Symbol, Schweregradwort); Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | RS-04 Teil A „Meldezeile (rot)“; DS-02 Rahmen |
| Brotkrümel „Einstellung“ | Navigation | ein Segment, zugleich letztes Segment (nur Anzeige) | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | DS-02 „Brotkrümel“ |
| Kennzahlen Geschwindigkeit und Maschinenwinkel | Anzeige | Geschwindigkeit antippbar (öffnet HS-03), Winkel nur Anzeige | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | DS-02 Rahmen |
| Funktionsleiste | Container | enthält die Taste „Sprache“ | [HM-06](../Module/HM-06_Funktionsleiste.md) | DS-02 „Funktionsleiste“; RS-04 Teil A (Fußleiste, Tasten wandern in die Seitenleiste, A-35) |
| Taste „Sprache“ | Aktionstaste mit `Icon.Language` | öffnet das Sprachwahl-Pop-up (Platzhalter, OP-03) | [HM-07](../Module/HM-07_Aktionstaste.md) | DS-02 „Taste Sprache (grau)“ |

### Inhaltsbereich

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Gruppe „Anwählen/Schnelle Einstellungen“ | Gruppenbereich | Schnellzugriff | [HM-15](../Module/HM-15_Gruppenbereich.md) | DS-02 „Bereich Anwählen/Schnelle Einstellungen“ |
| Kachel „Beleuchtung“ | Kachel-Taste klein (`TileSize = Small`) | schaltet die Maschinenbeleuchtung (Aktion, keine Navigation, A-36); kein Zustandssymbol, Funktion im Design nicht beschrieben (OP-05) | [HM-16](../Module/HM-16_Kachel-Navigation.md) | DS-02 „Taste Beleuchtung“ |
| Gruppe Mitte (Raster 2 × 4) | Gruppenbereich | trägt die Kacheln Mitte (Belegung oben) | [HM-15](../Module/HM-15_Gruppenbereich.md) | DS-02 „mittlerer grauer Bereich“ |
| Gruppe Rechts (Raster 2 × 4) | Gruppenbereich | trägt die Kacheln Rechts | [HM-15](../Module/HM-15_Gruppenbereich.md) | DS-02 „rechter grauer Bereich“ |

### Kacheln (alle [HM-16](../Module/HM-16_Kachel-Navigation.md), `TileSize = Large`, Raster aus RS-04 Spalte „Position im Raster“ Zeile/Spalte = Z/S)

Beschreibungen wortgetreu aus T4 (als Hilfetext, `AutomationProperties.HelpText`); die Spalte „Abschnitt“ von T4 ist in allen Zeilen leer (RS-04-P02).

| Kachel (neue Beschriftung) | Platz neu | Ziel (Navigation.md) | RS-04 T4 Nr. / Raster alt | Beschreibung (RS-04, wortgetreu) |
|---|---|---|---|---|
| Zuführungen | Mitte Z1/S1 | HS-40 Zuführungen (dort Papier HS-05, Karton HS-06, Heißleim HS-07) | Nr. 1 „Zuführung Papier“ (Z1/S1), Nr. 2 „Zuführung Karton“ (Z2/S1); Design DS-02 „Kachel Zuführungen“ | Nr. 1: „Enthält alle Einstellungen der Papierzuführung.“ Nr. 2: „Enthält alle Einstellungen der Kartonzuführung. Sowie das Heißleimgerät zuständig für die Kartonzuführung.“ |
| Schließmaschine | Mitte Z1/S2 | HS-16 Schließmaschine | Nr. 5 (Z1/S2) | „Hier sind die Einstellungen für den Kopfleim, die Rüttlung und des Auslaufbands untergebracht.“ |
| Dosierer | Mitte Z2/S1 | HS-41 Dosierer-Übersicht (dort Hauptdosierer HS-11, Nachdosierer HS-19) | Nr. 3 „Hauptdosierer“ (Z3/S1), Nr. 6 „Nachdosierer“ (Z3/S2); Design „Kachel Dosierer“ | Nr. 3: „Die Einstellungen der beiden Hauptdosierer sowie deren Motorparameter.“ Nr. 6: „Die Einstellungen des Nachdosierers sowie dessen Motorparameter.“ |
| Heizungen | Mitte Z2/S2 | HS-22 Heizungen | Nr. 8 (Z1/S3) | „Status und Einstellungen aller Heizungen im Dornrad und Schließmaschine.“ |
| Regulierung | Mitte Z3/S1 | HS-23 Regulierung | Nr. 9 (Z3/S3) | „Parameter und Status der Regulierungen von Haupt- und Nachdosierer.“ |
| Geber setzen | Mitte Z3/S2 | HS-32 Geber setzen | Nr. 16 (Z2/S5) | „Systemseite für das Null-Setzen von Gebern.“ |
| Waagen | Mitte Z4/S1 | HS-42 Waagen (dort Kontrollwaage HS-13, Waagen kalibrieren HS-27, deaktivierte Kachel Endkontrollwaage) | Nr. 4 „Kontrollwaage“ (Z4/S1), Nr. 7 „Endkontrollwaage“ (Z4/S2), Nr. 12 „Waagen kalibrieren“ (Z2/S4); Design „Kachel Waagen“ | Nr. 4: „Einstellungen der Kontrollwaage und ein Verlauf der letzten Gewichte und Statistik.“ Nr. 7: „Einstellungen der Endkontrollwaage und ein Verlauf der letzten Gewichte und Statistik.“ Nr. 12: „Systemseite zu Kalibrierung von Waagen und Wägezellen.“ |
| Packungsregister | Mitte Z4/S2 | HS-28 Packungsregister | Nr. 13 (Z3/S4) | „Zeigt den Status aller Packungen in der Maschine an.“ |
| Nockenschaltwerk | Rechts Z1/S1 | HS-25 Nocken (Übersicht HS-26 über die Funktionsleiste dort) | Nr. 11 (Z1/S4) | „Erlaubt das Bearbeiten aller Nocken. Es gibt eine Übersicht aller Nocken.“ |
| Handbetrieb | Rechts Z1/S2 | HS-30 Handbetrieb Auswahl (danach HS-31) | Nr. 15 (Z1/S5) | „Erlaub das steuern jeden Aktors der Maschine.“ (Quelltext, Tippfehler unverändert zitiert, OP-35) |
| Produktionsstatistik | Rechts Z2/S1 | HS-29 Produktionsstatistik | Nr. 14 (Z4/S4) | „Eine grafische Darstellung der Produktion der letzten 30 Tage.“ |
| Geräte | Rechts Z2/S2 | kein Ziel; Zustand „deaktiviert“ mit Beschriftung „Geräte“ und Symbol `Icon.Block` (A-36, OP-05) | nur DS-02 „Kachel Geräte“ (ohne Entsprechung in RS-04) | – |
| Reserviert | Rechts Z3/S1 | kein Ziel; leere Kachel im Zustand „deaktiviert“ mit Text „Reserviert“ (A-29, A-36) | RS-04 T4 Nr. 19 und Nr. 20 (leere Kacheln Z2/S2 und Z2/S3); DS-02 „Kachel (leer), rechts Reihe 3 links“ | – |
| EA Übersicht | Rechts Z3/S2 | HS-33 EA-Übersicht | Nr. 17 (Z3/S5); Beschriftung „EA Übersicht“ (Bild und Design) gegenüber „EA-Übersicht“ (Tabelle), OP-34 | „Zeigt alle EA-Karten und den Zustand der entsprechenden Kanäle an.“ |
| Bildschirm reinigen | Rechts Z4/S1 | HS-24 Bildschirm reinigen (Vollbild, schließt selbst) | Nr. 10 (Z4/S3) | „Eine Seite ohne Bedienelement. So lange die Seite angezeigt wird kann der Bildschirm gereinigt werden.“ |
| Systemeinstellungen | Rechts Z4/S2 | HS-35 Systemeinstellungen | Nr. 18 (Z4/S5) | „Erlaubt das Beenden und Minimieren der HMI. Der IPC kann neugestartet oder heruntergefahren werden. Funktionen wie das Meldearchive und Diagnose für Servo-Antriebe können über die Seite erreicht werden.“ |

Die Kachel „Reserviert“ steht für T4 Nr. 19/20 (beide „im Bild unbeschriftet, nicht im Text“): zwei Referenz-Leerkacheln und vier Design-Leerkacheln werden zu **einer** reservierten Kachel zusammengefasst, weil drei der vier Design-Leerplätze belegt werden (A-36). Es wird keine Funktion erfunden.

### Rückverfolgung RS-04 T4 → neues Layout

| RS-04 Nr. | Funktion alt | Wiederzufinden als |
|---|---|---|
| 1 | Zuführung Papier | Kachel „Zuführungen“ → HS-40 → Kachel „Papier“ → HS-05 |
| 2 | Zuführung Karton | Kachel „Zuführungen“ → HS-40 → Kachel „Karton“ → HS-06 |
| 3 | Hauptdosierer | Kachel „Dosierer“ → HS-41 → Detail-Symbol Hauptdosierer → HS-11 |
| 4 | Kontrollwaage | Kachel „Waagen“ → HS-42 → Kachel „Kontrollwaage“ → HS-13 |
| 5 | Schließmaschine | Kachel „Schließmaschine“ → HS-16 |
| 6 | Nachdosierer | Kachel „Dosierer“ → HS-41 → Detail-Symbol Nachdosierer → HS-19 |
| 7 | Endkontrollwaage | Kachel „Waagen“ → HS-42 → deaktivierte Kachel „Endkontrollwaage“ (OP-24) |
| 8 | Heizungen | Kachel „Heizungen“ → HS-22 |
| 9 | Regulierung | Kachel „Regulierung“ → HS-23 |
| 10 | Bildschirm reinigen | Kachel „Bildschirm reinigen“ → HS-24 |
| 11 | Nockenschaltwerk | Kachel „Nockenschaltwerk“ → HS-25 |
| 12 | Waagen kalibrieren | Kachel „Waagen“ → HS-42 → Kachel „Waagen kalibrieren“ → HS-27 |
| 13 | Packungsregister | Kachel „Packungsregister“ → HS-28 |
| 14 | Produktionsstatistik | Kachel „Produktionsstatistik“ → HS-29 |
| 15 | Handbetrieb | Kachel „Handbetrieb“ → HS-30 |
| 16 | Geber setzen | Kachel „Geber setzen“ → HS-32 |
| 17 | EA-Übersicht | Kachel „EA Übersicht“ → HS-33 |
| 18 | Systemeinstellungen | Kachel „Systemeinstellungen“ → HS-35 |
| 19, 20 | (leere Kacheln) | Kachel „Reserviert“ (keine Funktion) |

## Verwendete Module (IDs)

- [HM-01](../Module/HM-01_Seitenleiste.md) – Seitenleiste
- [HM-02](../Module/HM-02_Kopfzeile.md) – Kopfzeile
- [HM-03](../Module/HM-03_Meldezeile.md) – Meldezeile
- [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) – Brotkrümel-Navigation
- [HM-05](../Module/HM-05_Kennzahl-Kachel.md) – Kennzahl-Kachel
- [HM-06](../Module/HM-06_Funktionsleiste.md) – Funktionsleiste unten
- [HM-07](../Module/HM-07_Aktionstaste.md) – Aktionstaste (Taste „Sprache“)
- [HM-14](../Module/HM-14_Popup-Rahmen.md) – Pop-up-Rahmen (Sprachwahl-Pop-up, Platzhalter OP-03)
- [HM-15](../Module/HM-15_Gruppenbereich.md) – Gruppenbereich
- [HM-16](../Module/HM-16_Kachel-Navigation.md) – Kachel-Navigation

Kein fehlendes Modul: Sprachwahl-, Benutzer- und Bestätigungs-Pop-up haben kein eigenes HM (Navigation.md 4.1: Platzhalter über `IDialogService`, Rahmen HM-14).

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

- **Kacheln (HM-16):** Normal, Gedrückt (dickere Kontur `Border.Medium`, Auslösen beim Loslassen im Ziel), Reserviert/Deaktiviert (gestrichelte Kontur `Border.Dash`, Text `Brush.Text.Disabled`, zusätzlich Text „Reserviert“ bzw. Beschriftung „Geräte“ mit `Icon.Block`). Tippen auf eine deaktivierte Kachel nennt den Grund als Info-Text in der Meldezeile (A-28), z. B. „Geräte: derzeit nicht verfügbar“. Es gibt keinen Zustand „gewählt“ (nur ein Zustand in RS-04 erkennbar).
- **Navigation:** Antippen einer Kachel öffnet die Zielseite nach Abschnitt „Kachelbelegung“; der Zielseite wird `HS-04` auf den Zurück-Stapel gelegt (Navigation.md 5.3). Zurück-Taste der Seitenleiste: oberster Verlaufseintrag, sonst HS-01. Seitenleisten-Taste „Einstellungen“ auf dieser Seite hervorgehoben und ohne Wirkung („Gleiche Seite erneut anwählen“).
- **HS-24 „Bildschirm reinigen“:** Vollbild ohne Rahmen; wird nicht in den Stapel gelegt, nach Ablauf kehrt die Anzeige zu HS-04 zurück.
- **Beleuchtung:** Antippen löst die Aktion „Maschinenbeleuchtung schalten“ aus (Dummy-Schnittstelle, Agent.md Abschnitt 7); Zustand der Beleuchtung wird nicht angezeigt, weil die Quelle keinen nennt (OP-05).
- **Sprache:** Taste „Sprache“ öffnet das Sprachwahl-Pop-up (Auswahlliste mit Sprachname in der Eigensprache, „Übernehmen“/„Abbrechen“; Platzhalter, OP-03). Modalregeln nach Navigation.md 4.2: Scrim, Seitenleiste, Funktionsleiste, Brotkrümel und Kacheln gesperrt, Schließen nur über die Pop-up-Tasten, Pop-up nicht im Verlauf. Nach Übernehmen wird die Ansicht neu aufgebaut (Designsystem 11), die Beschriftungen kommen aus `.resx`.
- **Berechtigungen:** keine Kachel trägt ein Schlüsselsymbol; im Handbuch ist keine Kachel berechtigungsabhängig (RS-04 Offene Punkte 2, OP-04). Seitenzugang nur für HS-36 (Rolle Technik) geschützt, nicht auf dieser Seite.
- **Fehlerfälle und Meldungen:** Neue Meldungen erscheinen in der Meldezeile (Beispielmeldung „014: Sicherung 4F24 Auslaufband ausgelöst.“ im Design, „\*450\* Palettierung nicht bereit“ im Bild); die Seite selbst hat keine Fehlerzustände. Ist ein Pop-up offen, öffnet die Meldezeile HS-38 erst nach Schließen (Navigation.md 4.2 Punkt 7).
- **Theme und Sprache:** Hell-/Dunkelthema über Tokens; Beschriftungen mit +40 % Textbreite, Kacheln brechen mehrzeilig um.

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-04-P01 | Alle Funktionen aus T4 abgleichen (RS-04-P01) | 18 Funktionen (Zuführung Papier, Zuführung Karton, Hauptdosierer, Kontrollwaage, Schließmaschine, Nachdosierer, Endkontrollwaage, Heizungen, Regulierung, Bildschirm reinigen, Nockenschaltwerk, Waagen kalibrieren, Packungsregister, Produktionsstatistik, Handbetrieb, Geber setzen, EA-Übersicht, Systemeinstellungen) sind in der Rückverfolgungstabelle jeweils einer Kachel oder einer Kachelkette zugeordnet, mit Beschreibung als Hilfetext | offen |
| HS-04-P02 | Spalte „Abschnitt“ von T4 (RS-04-P02) | in der Seite kein Verweis darauf, Vermerk „in allen Zeilen leer“ steht in den Elementen | offen |
| HS-04-P03 | Kachelzahl und Raster (RS-04-P03, DS-02-P01) | 16 Kachelplätze in zwei Rastern 2 × 4 plus kleine Kachel „Beleuchtung“; davon 14 mit Ziel, 1 „Geräte“ deaktiviert, 1 „Reserviert“ | offen |
| HS-04-P04 | Anordnung (RS-04-P04, DS-02-P02, DS-02-P03) | Mitte: Zuführungen, Schließmaschine, Dosierer, Heizungen, Regulierung, Geber setzen, Waagen, Packungsregister; Rechts: Nockenschaltwerk, Handbetrieb, Produktionsstatistik, Geräte, Reserviert, EA Übersicht, Bildschirm reinigen, Systemeinstellungen | offen |
| HS-04-P05 | Seitentitel, Uhrzeit, Datum, Meldezeile (RS-04-P05) | Seitenname als Brotkrümel-Segment „Einstellung“, Uhrzeit und Datum in der Kopfzeile, Meldung mit Symbol und Wort in der Meldezeile | offen |
| HS-04-P06 | Fußleistentasten der Referenz (RS-04-P06) | Produktion, Einstellungen, Zurück und Schloss sind in der Seitenleiste (Home, Einstellungen, Zurück, Benutzerkreis) wiederzufinden; die Funktionsleiste enthält nur „Sprache“ | offen |
| HS-04-P07 | Zielseiten gegen Referenz-Übersicht (RS-04-P07) | jede Kachel nennt ihr Ziel gemäß Navigation.md 1 und 2; „Endkontrollwaage“ ist nur in HS-42 als deaktivierte Kachel ohne Ziel (A-12, OP-24) | offen |
| HS-04-P08 | Links der Seite (RS-04-P08) | Links auf RS-04, DS-02, Navigation.md und alle HM lösen auf | offen |
| HS-04-P09 | Erreichbarkeit aller 18 Funktionen (RS-04-P09) | jede der 18 Funktionen ist über höchstens eine Zwischenseite (HS-40, HS-41, HS-42) erreichbar; leere Kacheln erhalten keine erfundene Funktion | offen |
| HS-04-P10 | Brotkrümel (DS-02-P06, NAV-P03) | genau ein Segment „Einstellung“, nur Anzeige | offen |
| HS-04-P11 | Linker Bereich (DS-02-P04) | Überschrift „Anwählen/Schnelle Einstellungen“, eine Kachel „Beleuchtung“ ohne Navigation | offen |
| HS-04-P12 | Funktionsleiste (DS-02-P05) | Taste „Sprache“ öffnet das Sprachwahl-Pop-up; Pop-up schließt nur über „Übernehmen“ oder „Abbrechen“ | offen |
| HS-04-P13 | Rahmenwerte (DS-02-P07) | Rahmen zeigt Kennzahlen Geschwindigkeit und Maschinenwinkel, Uhrzeit und Datum (Dummywerte, OP-22) | offen |
| HS-04-P14 | Reservierte Kacheln | „Geräte“ und „Reserviert“ sind gestrichelt, tragen Text (und `Icon.Block` bei „Geräte“) und lösen keine Navigation aus; Tippen zeigt Grund in der Meldezeile | offen |
| HS-04-P15 | Beschriftung | keine Trennstriche, automatischer Umbruch bei „Schließmaschine“, „Packungsregister“, „Nockenschaltwerk“, „Systemeinstellungen“; Beschriftungen aus `.resx` | offen |
| HS-04-P16 | Zurück-Verhalten | Zurück auf HS-04 führt in den Verlauf, ohne Verlauf nach HS-01; Taste „Einstellungen“ ohne Wirkung; HS-24 nicht im Stapel | offen |
| HS-04-P17 | Touch-Ziele (Designsystem) | Kacheln mindestens `Size.Touch.Large` hoch (Beleuchtung `Size.Touch.Default`), Taste „Sprache“ mindestens `Size.FunctionButton.MinWidth` breit und `Size.Touch.Default` hoch, Abstand zwischen Touch-Zielen mindestens `Size.Touch.Gap` | offen |
| HS-04-P18 | Zweiter Kanal (Designsystem) | deaktivierte Kacheln sind über gestrichelte Kontur und Text erkennbar, nicht nur über Farbe; Seitenleisten-Auswahl „Einstellungen“ über Balken `Size.SelectionBar` und Grund | offen |
| HS-04-P19 | Tokens (Designsystem) | keine Hex-, Pixel- oder Literaltexte im XAML; Hell- und Dunkelthema schalten ohne Layoutänderung um | offen |
| HS-04-P20 | Modalität | bei offenem Pop-up sind Kacheln, Seitenleiste und Funktionsleiste gesperrt; Antippen außerhalb schließt nicht | offen |

## Offene Punkte
- OP-03: Sprachwahl (Funktion, Sprachen, Pop-up) ohne Referenz; hier Platzhalter.
- OP-05: „Geräte“, „Beleuchtung“, leere Kacheln; Zustandsrückmeldung der Beleuchtung offen.
- OP-12: Ziele der 16 Kacheln (durch A-36 und Navigation.md belegt).
- OP-13: mehrzeilige Kachelbeschriftungen ohne Trennstrich.
- OP-21: Antippbarkeit von Brotkrümel und Kennzahlen; Beschriftung der Seitenleisten-Symbole.
- OP-22: identische Rahmenwerte (Dummy).
- OP-24: Endkontrollwaage (kein Kapitel; nur deaktivierte Kachel in HS-42).
- OP-26: Bedeutung von Spiralsymbol und Schloss der Referenz (hier: Betriebsart „Service“ nach A-48 und Benutzerkreis).
- OP-34: Beschriftungsabweichungen („EA Übersicht“ gegenüber „EA-Übersicht“).
- OP-38: Navigationspfade der Kacheln nur durch die Referenz-Übersicht belegt.
- OP-51: RS-04: leere Spalte „Abschnitt“, Berechtigungsabhängigkeit der Kacheln.
