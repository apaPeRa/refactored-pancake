# HS-26 – Nockenübersicht
- Quelle: [RS-26](../../02_Referenz-Analyse/Seiten/RS-26_Nockenuebersicht.md) (Handbuch Kapitel 26, Tabelle T36; Bild [RS-26_01.png](../../02_Referenz-Analyse/Medien/RS-26_01.png)); Design: keine Design-Seite; Aufbau aus [Designsystem](../Designsystem.md), HM-23, HM-19, HM-09.
- Navigationspfad: Einstellung › Nockenschaltwerk › Übersicht (Brotkrümel, [Navigation.md](../Navigation.md) Abschnitt 2; Segment „Nockenschaltwerk“ führt zu HS-25). Zugang: HS-25, Funktionsleiste „Übersicht“. Zurück-Ziel: HS-25. Schlüssel `CamOverview` / Route `settings/cams/overview`, Eltern HS-25, Mindestrolle: keine.

## Zweck
Die Seite zeigt alle in der Maschine konfigurierten Nocken tabellarisch (Nummer, Bezeichnung, Start, Ende, Status) und ermöglicht die schnelle Navigation zur Einstellseite der jeweiligen Nocke: Antippen der Nockennummer öffnet [HS-25](HS-25_Nocken.md) mit dieser Nocke. Die Seite ist reine Anzeige; es gibt keine Eingaben und keine Schlüsselsymbole.

## Aufbau (Bereiche, Layout)
Rahmen wie auf allen Vollseiten ([Designsystem](../Designsystem.md) Abschnitt 3.2). Funktionsleiste (links beginnend): Blättertasten „«“ und „»“ ([HM-19](../Module/HM-19_Blaettertasten.md)), keine Taste „Übersicht“ (Referenz). Der Inhaltsbereich besteht aus einer **Tabelle über alle 12 Spalten** (Außenrand `Space.L`):

- **Tabellenkopf** (Höhe `Size.Touch.Min`): „Nr.“, (Bezeichnung ohne Kopftext), „Start“, „Ende“, „Status“ (Referenz: Spalte ohne Kopf, im neuen Layout mit Kopftext, da Symbol und Wort).
- **Zeilen** in Stern-Höhen, Mindesthöhe `Size.Touch.Min`, 11 Zeilen je Seite (`RowsPerPage` konfigurierbar, [HM-23](../Module/HM-23_Nockentabelle.md); A-52 nennt 12, hier wegen des Touch-Abstands 11, Annahme S26-1); Trennlinien `Brush.Divider`. Weitere Nocken erreicht man über „«“ / „»“ in der Funktionsleiste oder durch Wischen. Touch-Ziel ist nur das Nummernfeld (Höhe `Size.Touch.Min`); die Zeilenhöhe beträgt mindestens `Size.Touch.Min` plus `Size.Touch.Gap`, damit der Abstand zwischen zwei Nummernfeldern mindestens `Size.Touch.Gap` ist. Alternativ wäre eine Ausnahme „Tabellenzeile als Touch-Ziel ohne Abstand“ im Designsystem nötig (Wunsch an den Querschnitts-Agenten, Annahme S26-1).

Spaltenproportionen (12 Spalten):

| Spalte | Spalten von 12 | Inhalt |
|---|---|---|
| Nr. | 1 | Nummernfeld (fett, antippbar mit Tastenoptik) |
| Bezeichnung | 6 | Name der Nocke, linksbündig |
| Start | 2 | Startwinkel in ° |
| Ende | 2 | Endwinkel in ° |
| Status | 1 | Status-LED mit Symbol (und Wort „aktiv“) |

```
Inhaltsbereich (12 Spalten, Seite 1 von 2, Nocken 40 bis 50)
| Nr. | Bezeichnung (6 Sp.)                   | Start  | Ende   | Status |
| 40  | Start Hauptdosierer 1                 | 290 °  | 130 °  |  o     |
| 41  | Start Hauptdosierer 2                 | 290 °  | 130 °  |  o     |
| ... |                                       |        |        |        |
| 45  | Fehlpaketausstoß verriegeln 14KY21    | 200 °  | 140 °  | v aktiv|
| ... 11 Zeilen je Seite                    |        |        |        |
Funktionsleiste:  [ << ]  [ >> ]      (Positionsanzeige „1 von 2“)
```

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Rückverfolgung: Spalte „Herkunft“ = Zeile in [RS-26](../../02_Referenz-Analyse/Seiten/RS-26_Nockenuebersicht.md) (T36 = Tabelle des Handbuchs, Bild = RS-26_01.png).

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Nockennummer (Spalte Nr.) | tippbares Nummernfeld je Zeile | „Nummer der Nocke. Durch Antippen wird die zugehörige Einstellseite geöffnet.“ → HS-25 mit `camNumber` = Nummer; Trefferfläche mindestens `Size.Touch.Min` hoch | [HM-23](../Module/HM-23_Nockentabelle.md) (Nockenzeile, `SelectCommand`) | T36 „Nockennummer“, Bild Spalte Nr. |
| Bezeichnung | Anzeigefeld ohne Spaltenkopf in der Referenz | Name der Nocke; im Handbuchtext nicht beschrieben; Tippfehler des Bildes werden in der Ressource korrigiert (OP-35, siehe Tabelle unten) | [HM-23](../Module/HM-23_Nockentabelle.md) | T36 „Bezeichnung (nur im Bild)“, Bild |
| Start | Anzeigefeld in ° | „Startposition der Nocke bezogen auf den Maschinenwinkel.“ Nur Anzeige | [HM-23](../Module/HM-23_Nockentabelle.md) | T36 „Start“, Bild Spalte Start |
| Ende | Anzeigefeld in ° | „Endposition der Nocke bezogen auf den Maschinenwinkel.“ Nur Anzeige; Ende kleiner als Start (Nocke über 0 °, z. B. Nr. 40) wird wie im Bild unverändert angezeigt | [HM-23](../Module/HM-23_Nockentabelle.md) | T36 „Ende“, Bild Spalte Ende |
| Status (LED je Zeile) | Status-LED kompakt mit Symbol; aktive Zeile zusätzlich Wort „aktiv“ | „Zeigt den Status der Nocke an. Leuchtet die LED grün, befindet sich die Maschine aktuell in der aktiven Phase der Nocke.“ Aktiv: Haken, Wort „aktiv“, Kontur, keine Farbfläche; inaktiv: leerer Kreis (Bild: grau) | [HM-09](../Module/HM-09_Status-LED.md) (kompakt) in [HM-23](../Module/HM-23_Nockentabelle.md) | T36 „LED“, Bild Spalte LED |
| Blättertasten „«“ und „»“ (Funktionsleiste) | Blättertasten, Paar | im Handbuch nicht beschrieben (vermutlich Blättern); hier: seitenweises Blättern der Nockentabelle mit Positionsanzeige „n von m“ (`ReplaceParameter`, kein Verlaufseintrag); am Rand deaktiviert (gestrichelt) (Annahme H-10) | [HM-19](../Module/HM-19_Blaettertasten.md) | T36 „Tasten << und >> (nur im Bild)“, Bild Fußleiste |
| Tabellenkopf | Beschriftung „Nr.“, „Start“, „Ende“, „Status“ | benennt die Spalten (Bezeichnung ohne Kopf wie in der Referenz, Kopftext nur als Zugänglichkeitsname); bleibt beim Blättern stehen | [HM-23](../Module/HM-23_Nockentabelle.md) | Aufbau (Spaltenköpfe „Nr.“, „Start“, „Ende“) |
| Kopfzeile mit Logo, Titel, Wirbel-Symbol, Uhr/Datum | Rahmen | Titel „Nocken Übersicht“ entfällt als Seitentitel (Brotkrümel „Übersicht“); Betriebsart, Uhr | [HM-02](../Module/HM-02_Kopfzeile.md) | Bild Kopfzeile, T36 „Seitenkopf“ |
| Meldezeile („*450* Palettierung nicht bereit“) | Rahmen | Aktuelle Meldung; Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | Bild Meldezeile, T36 „Meldezeile“ |
| Brotkrümel und Kennzahlen | Rahmen | „Einstellung › Nockenschaltwerk › Übersicht“; Geschwindigkeit, Maschinenwinkel | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | (Design-Rahmen) |
| Fußleiste „Produktion“, „Einstellungen“, „Zurück“, Schloss | Rahmentasten | wandern in die Seitenleiste (Home, Einstellungen, Zurück, Benutzerkreis, A-35) | [HM-01](../Module/HM-01_Seitenleiste.md), [HM-06](../Module/HM-06_Funktionsleiste.md) | Bild Fußleiste, T36 „Fußleiste“ |

### Zeilen der Tabelle (Beispieldaten aus dem Bild, Nr. 40 bis 59)
Alle 20 Zeilen des Bildes sind erfasst; Seite 1 zeigt Nr. 40 bis 50, Seite 2 Nr. 51 bis 59 (11 Zeilen je Seite, S26-1; Konfiguration der Nocken ist geräteabhängig, OP-41). Schreibweise: Die Bezeichnungen stehen wörtlich wie im Bild, auch mit den Tippfehlern („Hauptdoserer“, „Fehlaketausstoß“). Standard der Umsetzung: Anzeige in der `.resx` korrigiert, offene Entscheidung (OP-35, Annahme S26-4). Herkunft jeder Zeile: Zeile gleicher Nummer im Abschnitt Aufbau von RS-26.

| Nr. | Bezeichnung | Start | Ende | Status (Bild) |
|---|---|---|---|---|
| 40 | Start Hauptdoserer 1 (Anzeige in .resx: „Hauptdosierer“) | 290 ° | 130 ° | inaktiv |
| 41 | Start Hauptdosierer 2 | 290 ° | 130 ° | inaktiv |
| 42 | Wiegen Kontrollwaage | 40 ° | 110 ° | inaktiv |
| 43 | Wiegen Endkontrollwaage | 40 ° | 110 ° | inaktiv |
| 44 | Blasluft Fehlpaket 14KY23 | 290 ° | 20 ° | inaktiv |
| 45 | Fehlpaketausstoß verriegeln 14KY21 | 200 ° | 140 ° | aktiv |
| 46 | Fehlaketausstoß vorne 14B10 (Anzeige in .resx: „Fehlpaketausstoß“) | 10 ° | 35 ° | inaktiv |
| 47 | Fehlpaketausstoß hinten 14B10 | 120 ° | 284 ° | aktiv |
| 48 | (leer, Anzeige „–“) | 0 ° | 0 ° | inaktiv |
| 49 | Start Nachdosierer | 260 ° | 130 ° | inaktiv |
| 50 | (leer, Anzeige „–“) | 0 ° | 0 ° | inaktiv |
| 51 | Tastung Kopfleim 20B61 | 35 ° | 45 ° | inaktiv |
| 52 | Kopfleim 20KY21 | 280 ° | 325 ° | inaktiv |
| 53 | Ausstoßer Auslauf vorne 20B71 | 45 ° | 60 ° | inaktiv |
| 54 | Ausstoßer Auslauf hinten 20B71 | 120 ° | 310 ° | aktiv |
| 55 | Paket schließen 20KY22 | 280 ° | 60 ° | inaktiv |
| 56 | Blasluft Stempel 20KY23 | 75 ° | 130 ° | inaktiv |
| 57 | Siegelbacken Abheben Vorsiegeln 20KY31 | 310 ° | 140 ° | aktiv |
| 58 | Siegelbacken Abheben Hauptsiegeln 20KY32 | 310 ° (im Bild abgeschnitten, OP-44) | 140 ° | aktiv |
| 59 | (leer, Anzeige „–“) | 0 ° | 0 ° | inaktiv |

## Verwendete Module (IDs)
- [HM-23](../Module/HM-23_Nockentabelle.md) – Nockentabelle
- [HM-09](../Module/HM-09_Status-LED.md) – Status-LED (kompakt, in HM-23)
- [HM-19](../Module/HM-19_Blaettertasten.md) – Blättertasten (Funktionsleiste)
- Rahmen: [HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md)

Kein Modul fehlt.

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- **Sprung zur Einstellseite:** Antippen der Nockennummer führt zu HS-25 mit dieser Nocke ([Navigation.md](../Navigation.md) Abschnitt 1: HS-26 ⇄ HS-25). Da HS-25 im Verlauf liegt, wird der Stapel bis HS-25 gekürzt und HS-25 mit dem neuen Parameter `camNumber` aktuell (5.3); kein Schleifenverlauf. Gedrückt: `Brush.Button.Pressed`, Kontur `Border.Medium`.
- **Auswahl-Markierung:** Beim Öffnen aus HS-25 öffnet die Tabelle auf der Seite, die die dort gewählte Nocke enthält, und markiert deren Zeile (Kontur `Border.Thick`, `Brush.Border.Focus`, Rahmen als zweiter Kanal); ist die Nocke nicht in der Tabelle, öffnet Seite 1 ohne Markierung (Annahme S26-3).
- **Status je Zeile:** Aktiv = Maschine befindet sich in der aktiven Phase der Nocke: Haken, Wort „aktiv“, Zeile ohne Farbfläche, der Zustand steht nur in Symbol, Wort und Kontur (`Border.Medium`, `Brush.Border.Control`; Subtle-Flächen sind Warnung/Fehler/Info vorbehalten, Designsystem 1.2); sonst leerer Kreis. Die Anzeige aktualisiert sich laufend; nur Anzeige, kein Bedienzustand. Farbe nur zusätzlich zu Symbol und Wort.
- **Leere Nocken:** Nr. 48, 50 und 59 bleiben sichtbar mit „–“, 0 ° und 0 °, Text `Brush.Text.Secondary`, Status inaktiv; Antippen der Nummer öffnet HS-25 trotzdem.
- **Start und Ende:** nur Anzeige in °, bezogen auf den Maschinenwinkel; Start größer als Ende (Nocke über 0 °) wird nicht umgerechnet.
- **Blättern:** „«“ / „»“ blättern seitenweise (11 Zeilen), Positionsanzeige „n von m“; am Rand deaktiviert (gestrichelt); Wischen in der Tabelle gleichwertig. Kein Verlaufseintrag.
- **Berechtigungen:** keine; kein Schlüsselsymbol im Bild; die Übersicht ist ohne Rolle nutzbar (im Handbuch nicht beschrieben, OP-25). Die Eingaben liegen auf HS-25.
- **Navigation:** „Zurück“ und Brotkrümel-Segment „Nockenschaltwerk“ führen zu HS-25. Seitenleiste „Einstellungen“ hervorgehoben. Pop-ups gibt es auf dieser Seite nicht.
- **Fehlerfälle:** Keine Verbindung: Status „---“ (HM-09 Unbekannt), Winkel „---“; die Navigation über die Nummern bleibt möglich.

## Prüfpunkte (Tabelle: ID | Prüfung | erwartetes Ergebnis | Status)
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-26-P01 | Spalten (RS-26-P01) | Spalten Nr., Bezeichnung (ohne Kopftext in der Referenz), Start, Ende, Status/LED in dieser Reihenfolge | offen |
| HS-26-P02 | Zeilen (RS-26-P02) | Die 20 Bildzeilen Nr. 40 bis 59 sind mit Bezeichnung, Start und Ende wie in der Tabelle oben vorhanden (Seite 1: 40 bis 50, Seite 2: 51 bis 59) | offen |
| HS-26-P03 | Nockennummer (RS-26-P03) | Antippen einer Nummer öffnet HS-25 mit der gewählten Nocke; Stapel wird gekürzt, kein Schleifenverlauf | offen |
| HS-26-P04 | Start/Ende (RS-26-P04) | Positionen in ° bezogen auf den Maschinenwinkel, nur Anzeige, nicht editierbar | offen |
| HS-26-P05 | Status (RS-26-P05) | Aktive Phase (Beispiel Nr. 45, 47, 54, 57, 58) mit Haken und Wort „aktiv“; inaktive mit leerem Kreis; Zustand nicht nur über Farbe | offen |
| HS-26-P06 | Leere Nocken (RS-26-P06) | Nr. 48, 50, 59 erscheinen mit „–“ als Bezeichnung, 0 ° / 0 ° und inaktivem Status | offen |
| HS-26-P07 | Funktionsleiste (RS-26-P07) | Tasten „«“ und „»“ vorhanden, keine Taste „Übersicht“; Produktion, Einstellungen, Zurück in der Seitenleiste | offen |
| HS-26-P08 | Zugang (RS-26-P08) | Erreichbar aus HS-25 über „Übersicht“; Brotkrümel „Einstellung › Nockenschaltwerk › Übersicht“ | offen |
| HS-26-P09 | Bildabdeckung (RS-26-P09) | Jedes Element aus [RS-26_01.png](../../02_Referenz-Analyse/Medien/RS-26_01.png) (Tabellenspalten, 20 Zeilen, LED je Zeile, Tasten „<<“ und „>>“, Kopfzeile, Meldezeile, Fußleiste) ist in der Elemente-Tabelle wiederzufinden | offen |
| HS-26-P10 | Blättern | „«“ und „»“ blättern die Tabelle seitenweise mit Positionsanzeige „n von m“; am Rand deaktiviert; kein Verlaufseintrag | offen |
| HS-26-P11 | Touch-Ziele | Nummernfeld ≥ `Size.Touch.Min` hoch, Abstand zwischen Nummernfeldern ≥ `Size.Touch.Gap`; Funktionsleisten-Tasten ≥ `Size.Touch.Default` hoch und `Size.FunctionButton.MinWidth` breit | offen |
| HS-26-P12 | Zweiter Kanal | Status mit Symbol, Wort und Kontur, keine grüne oder farbige Zeilenfläche im Normalbetrieb; ausgewählte Zeile mit Rahmen | offen |
| HS-26-P13 | Tokens | Keine Hex- oder Pixelwerte; Farben, Abstände, Zeilenhöhen nur über Tokens aus dem Designsystem | offen |
| HS-26-P14 | Schreibweise | Beispieldaten führen den Quellwortlaut („Hauptdoserer“, „Fehlaketausstoß“); Standard-Anzeige in der `.resx` korrigiert („Hauptdosierer“, „Fehlpaketausstoß“), ohne Änderung der übrigen Werte; Entscheidung offen (OP-35) | offen |

## Offene Punkte
- OP-25: Ob die Übersicht ohne Berechtigung nutzbar ist, nicht beschrieben; keine Schlüsselsymbole.
- OP-35: Tippfehler in den Bildbezeichnungen („Hauptdoserer“, „Fehlaketausstoß“); Beispieldaten führen den Wortlaut, Standard der Anzeige ist korrigiert in der `.resx`, Entscheidung offen.
- OP-41: Anzahl der Nocken und geräteabhängige Bezeichnungen unbekannt; 20 Zeilen aus dem Bild.
- OP-44: Start 310 ° in Zeile 58 im Bild abgeschnitten; nicht rekonstruiert.
- OP-48: Behandlung von Start größer als Ende und Bedeutung der grauen LED nicht beschrieben; Anzeige unverändert.
- Wirkung der Tasten „<<“ / „>>“ im Handbuch nicht beschrieben (vermutlich Blättern, Gesamtzahl der Nocken unbekannt).

### Annahmen dieser Seite
- S26-1: Touch-Ziel ist nur das Nummernfeld, Zeilenhöhe mindestens `Size.Touch.Min` plus `Size.Touch.Gap`; daher 11 statt 12 Zeilen je Seite (abweichend von A-52). Alternativ Ausnahme für Tabellenzeilen im Designsystem.
- S26-2: „«“ / „»“ blättern die Tabelle seitenweise (Handbuch beschreibt die Wirkung nicht).
- S26-3: Beim Öffnen aus HS-25 wird die dort gewählte Nocke markiert, sofern sie in der Tabelle steht, sonst öffnet Seite 1 ohne Markierung.
- S26-4: Standard-Anzeige der Bezeichnungen korrigiert in der `.resx`; Quellwortlaut bleibt in den Beispieldaten (OP-35).
