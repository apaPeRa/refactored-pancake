# HS-27 – Waagen Kalibrieren

- Quelle: [RS-27](../../02_Referenz-Analyse/Seiten/RS-27_Waagen-Kalibrieren.md) (Handbuch Kapitel 27, Tabellen T37 und T38, Bild RS-27_01). Es gibt keine Design-Seite (DS) zu dieser Seite; Layout, Rahmen und Optik sind aus [Designsystem](../Designsystem.md), [Navigation.md](../Navigation.md) und den Modulen abgeleitet (Muster: DS-03/DS-04 mit Titelzeile, Gruppenbereich und Funktionsleiste; Kachel „Waagen“ in DS-02).
- Navigationspfad (Brotkrümel): **Einstellung › Waagen › Waagen kalibrieren**. Zugang: [HS-42](../Seiten/HS-42_Waagen.md) Kachel „Waagen kalibrieren“; Zurück-Ziel: HS-42. PageKey `ScaleCalibration` (Route `settings/scales/calibration`), Parameter `scaleIndex`, Mindestrolle: keine (Seitenzugang frei, Berechtigung nur an Feldern und Tasten).

## Zweck

Kalibrierung einer verbauten Waage. Sie ist erforderlich, wenn das angezeigte Gewicht ungenau ist, an der Waage mechanische Veränderungen vorgenommen wurden oder die Waage ersetzt wurde (Wortlaut RS-27). Die Seite zeigt das Livegewicht der gewählten Waage, erlaubt Filterwahl und Nullpunkt und führt durch die Tastenfolge Start Kalibrierung, Entlastet, Belastet; „Reset“ bricht ab. Mit den Blättertasten wird zwischen den verbauten Waagen gewechselt.

## Aufbau (Bereiche, Layout)

Die Seite füllt den Inhaltsbereich des Rahmen-Grids ([Designsystem](../Designsystem.md) 3.2; Außenrand `Size.Content.Margin`, 12-Spalten-Raster 3.3, Gutter `Space.M`). Aufteilung (abgeleitet aus dem Muster DS-05 „Bedienbereich links, Hilfe rechts“):

- Zeile 1 (Höhe `Size.Touch.Default`): Titelzeile mit Waagenname über alle 12 Spalten.
- Darunter links **7 Spalten** Bedienbereich, rechts **5 Spalten** Gruppenbereich „Ablauf Kalibrierung“.
- Bedienbereich von oben nach unten: Gewichtsanzeige (Höhe `Size.Touch.Large`), Filterzeile (Auswahlfeld mit Pfeiltasten, Höhe `Size.Touch.Default`), Tastenpaar „Filter setzen“ und „Nullpunkt setzen“ (2 gleiche Spalten), Statusanzeige (Hinweis-Textfeld, mindestens 2 Textzeilen), Tastenreihe Kalibrierung (4 gleiche Spalten: Start Kalibrierung, Entlastet, Belastet, Reset).
- Abstände zwischen allen Touch-Zielen mindestens `Size.Touch.Gap`; die Zeilen im Bedienbereich haben `Space.M` Abstand.
- Untere Funktionsleiste ([HM-06](../Module/HM-06_Funktionsleiste.md)): nur die Blättertasten „«“ und „»“ links (Navigation.md 3.3, Zeile „Blättern innerhalb eines Satzes“). Die Referenz-Tasten Produktion, Einstellungen, Zurück und das Schloss liegen in der Seitenleiste (Navigation.md 0, Punkt 5).

```
+---------+--------------------------------------------------------------+
| Seiten- | Kopfzeile: Logo | Meldezeile | Betriebsart | Uhr/Datum       |
| leiste  +--------------------------------------------------------------+
|         | Einstellung > Waagen > Waagen kalibrieren | Geschw. | Winkel |
|         +--------------------------------------------------------------+
|         |  Titelzeile (HM-17): 16KW1 Kontrollwaage        (12 Spalten) |
|         +----------------------------------+---------------------------+
|         |  Gewichtsanzeige  -398,9 g (HM-11)| Gruppe "Ablauf           |
|         |  Filtertyp [<] IIR 5 56ms 8Hz [>] | Kalibrierung" (HM-15)    |
|         |  [Filter setzen] [Nullpunkt setz.]| 1. Waage reinigen ...    |
|         |  Statusanzeige (HM-27)            | 2. Start Kalibrierung    |
|         |  [Start][Entlastet][Belastet][Rst]| ...  7. Wiederholen      |
|         |        7 Spalten                  |        5 Spalten         |
|         +----------------------------------+---------------------------+
|         | Funktionsleiste: [«] [»]   (Position „1 von n“)              |
+---------+--------------------------------------------------------------+
```

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)

Spalte „Herkunft“ weist die Rückverfolgung nach RS-27 aus (T37 = Steuerelemente, T38 = Navigationsbereich, Bild = nur im Bild sichtbar, Text = Kalibriervorgang Schritt n).

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-27) |
|---|---|---|---|---|
| Titelzeile „16KW1 Kontrollwaage“ | Objektüberschrift, zentriert, Trennlinie statt Unterstreichung | Name der gerade angewählten Waage (Betriebsmittelkennzeichen und Bezeichnung); wechselt mit den Blättertasten; keine Kennwerte, kein Detail-Symbol | [HM-17](../Module/HM-17_Titelzeile.md) | Bild, Überschrift „16KW1 Kontrollwaage“ (RM-25) |
| Gewichtsanzeige | Anzeigefeld Zahl, Darstellung Feld, Größe Large, Einheit „g“ | Livegewicht der ausgewählten Waage, eine Nachkommastelle, Dezimalkomma, Minuszeichen bei negativen Werten (Bild „-398.9 g“), Einheit mit geschütztem Leerzeichen; bei ungültigem Wert „---“ | [HM-11](../Module/HM-11_Anzeigefeld.md) | T37 Zeile „Gewichtsanzeige“ |
| Filtertyp | Auswahlfeld mit Pfeiltasten (◄ ►), Schlüsselsymbol, Übernahme erforderlich | wählt einen digitalen Filter zur Stabilisierung der Gewichtsanzeige (Beispieltext „IIR 5 56ms 8Hz“); Änderung wirkt auf Reaktionsgeschwindigkeit und Genauigkeit; die Auswahl wird erst mit „Filter setzen“ übernommen; Liste der Filtertypen konfigurationsabhängig (offen) | [HM-18](../Module/HM-18_Auswahlfeld-Pfeiltasten.md) (Schlüssel über `RequiresPermission`) | T37 Zeile „Filtertyp“; Bild (Schlüssel, ausgegrauter Text) |
| Filter setzen | Aktionstaste mit Schlüsselsymbol | speichert den ausgewählten Filtertyp; ein fehlgeschlagenes Schreiben wird in der Statusanzeige darunter gemeldet | [HM-07](../Module/HM-07_Aktionstaste.md) | T37 Zeile „Filter setzen“ |
| Nullpunkt setzen | Aktionstaste ohne Schlüsselsymbol | setzt den Nullpunkt der Waage; nur bei unbelasteter Waage sinnvoll (Hinweistext „Nur bei unbelasteter Waage“ unter der Taste, Annahme K27-6) | [HM-07](../Module/HM-07_Aktionstaste.md) | T37 Zeile „Nullpunkt setzen“ |
| Statusanzeige | Hinweis-Textfeld (nur Anzeige), Art Info/Fehler | zeigt Meldungen, Fehler und Hinweise zur angewählten Waage; zeigt z. B. „Fehler beim Schreiben der Filterwerte“ (Bild „Fehler beim schreiben der Filterwerte“; Schreibung korrigiert, Annahme K27-5), Aufforderungen und die Bestätigung nach erfolgreicher Kalibrierung (Annahme K27-3) | [HM-27](../Module/HM-27_Hinweis-Textfeld.md) | T37 Zeile „Statusanzeige“; Bild; Text Schritt 5 |
| Start Kalibrierung | Aktionstaste mit Schlüsselsymbol | startet den Kalibriervorgang (Ablauf siehe Gruppe „Ablauf Kalibrierung“) | [HM-07](../Module/HM-07_Aktionstaste.md) | T37 Zeile „Start Kalibrierung“; Text Schritt 2 |
| Entlastet | Aktionstaste mit Schlüsselsymbol | wird während der Kalibrierung gedrückt, wenn sich kein Gewicht auf der Waage befindet und das Gewicht stabil ist | [HM-07](../Module/HM-07_Aktionstaste.md) | T37 Zeile „Entlastet“; Text Schritt 3 |
| Belastet | Aktionstaste mit Schlüsselsymbol | wird gedrückt, wenn das Kalibriergewicht auf der Waage liegt und sich die Anzeige stabilisiert hat | [HM-07](../Module/HM-07_Aktionstaste.md) | T37 Zeile „Belastet“; Text Schritt 4 |
| Reset | Aktionstaste ohne Schlüsselsymbol, Auslösung Antippen | bricht den Kalibriervorgang ab, setzt alle Zwischenschritte zurück und quittiert anstehende Fehler der aktuellen Waage; immer bedienbar | [HM-07](../Module/HM-07_Aktionstaste.md) | T37 Zeile „Reset“; Text Schritt 6 |
| Gruppe „Ablauf Kalibrierung“ | Gruppenbereich (Panel) mit den sieben Schritten als Hinweistext (reine Anzeige) | gibt den Handbuchablauf wieder: (1) Waage gründlich reinigen, korrekt eingebaut und befestigt; (2) „Start Kalibrierung“; (3) bei Aufforderung und stabilem Gewicht „Entlastet“; (4) gefordertes Kalibriergewicht freistehend auflegen, nach Beruhigung „Belastet“; (5) nach Erfolg erscheint eine Bestätigung, danach Nullpunkt und ein Prüfgewicht (z. B. 500 g) prüfen; (6) bei Abbruch „Reset“; (7) bleibt das Gewicht falsch, Waage erneut reinigen und Vorgang wiederholen | [HM-15](../Module/HM-15_Gruppenbereich.md), [HM-27](../Module/HM-27_Hinweis-Textfeld.md) (Art Info) | Text Schritte 1 bis 7; Kein Modul für den Ablauf (A-22), daher als Text |
| Hervorhebung des aktuellen Schritts | Symbol `Icon.State.On` und Text „aktuell“ am Schritt (nur wenn die Steuerung den Schritt meldet) | zeigt dem Bediener, welcher der Schritte 2 bis 5 gerade erwartet wird; ohne Rückmeldung entfällt die Hervorhebung | [HM-27](../Module/HM-27_Hinweis-Textfeld.md) | Text („sobald das System dazu auffordert“); Annahme K27-3 |
| Blättertaste „«“ | Blättertaste in der Funktionsleiste | wechselt zur vorherigen verbauten Waage; Titelzeile, Gewichtsanzeige, Statusanzeige und Filter wechseln mit; kein Verlaufseintrag | [HM-19](../Module/HM-19_Blaettertasten.md) in [HM-06](../Module/HM-06_Funktionsleiste.md) | T38 Zeile „Pfeiltasten“ („<<“) |
| Blättertaste „»“ | Blättertaste in der Funktionsleiste | wechselt zur nächsten verbauten Waage; Positionsanzeige „n von m“ als zweiter Kanal | [HM-19](../Module/HM-19_Blaettertasten.md) in [HM-06](../Module/HM-06_Funktionsleiste.md) | T38 Zeile „Pfeiltasten“ („>>“) |
| Seitentitel „Waagen Kalibrieren“ | Brotkrümel, letztes Segment (mit Objektkennung der Waage) | Pfad der Seite; ersetzt den unterstrichenen Seitentitel der Referenz-Kopfzeile | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | Bild, Kopfzeile |
| Logo, Uhrzeit, Datum, Spiralsymbol | Kopfzeile | Rahmenelemente; das Spiralsymbol wird als Betriebsart-Anzeige geführt (A-48) | [HM-02](../Module/HM-02_Kopfzeile.md) | Bild, Kopfzeile |
| Meldezeile „*450* Palettierung nicht bereit“ | Meldezeile | Rahmen; Format „NNN: Text“ mit Statussymbol und Wort; Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | Bild, Meldezeile |
| Kennzahlen Geschwindigkeit, Maschinenwinkel | Kennzahl-Kachel im Rahmen | Rahmenelemente des Designs, in der Referenz-Seite nicht vorhanden | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | Design-Rahmen (nicht RS) |
| Schloss-Symbol, Tasten „Produktion“, „Einstellungen“, „Zurück“ | Seitenleiste | Schloss wird zum Benutzerkreis (Anmeldestatus), Produktion = Home, Einstellungen, Zurück (Verlauf) | [HM-01](../Module/HM-01_Seitenleiste.md) | Bild, untere Leiste (RM-03) |

## Verwendete Module

[HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md), [HM-07](../Module/HM-07_Aktionstaste.md), [HM-11](../Module/HM-11_Anzeigefeld.md), [HM-15](../Module/HM-15_Gruppenbereich.md), [HM-17](../Module/HM-17_Titelzeile.md), [HM-18](../Module/HM-18_Auswahlfeld-Pfeiltasten.md), [HM-19](../Module/HM-19_Blaettertasten.md), [HM-27](../Module/HM-27_Hinweis-Textfeld.md).

Die Modulliste führt für HS-27 zusätzlich [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](../Module/HM-13_Eingabe-Pop-up.md) und [HM-14](../Module/HM-14_Popup-Rahmen.md). In diesem Konzept werden sie nicht gebraucht: Der Filtertyp ist ein Auswahlfeld mit Schlüssel ([HM-18](../Module/HM-18_Auswahlfeld-Pfeiltasten.md) trägt `RequiresPermission`), die Seite hat keinen Zahlenwert zum Eingeben und kein Pop-up. Das Kalibriergewicht wird von der Steuerung gefordert, nicht eingegeben.

## Zustände und Interaktion

**Waagenwahl.** „«“ und „»“ ändern nur den Parameter `scaleIndex` (`ReplaceParameter`, kein Verlaufseintrag, [Navigation.md](../Navigation.md) 5.3). Titelzeile, Gewichtsanzeige, Filter, Statusanzeige und die Objektkennung im letzten Brotkrümelsegment wechseln mit. Positionsanzeige „n von m“; an Anfang und Ende ist die jeweilige Taste deaktiviert (gestrichelte Kontur, Annahme aus HM-19, Umlauf offen, OP-41). Während ein Kalibriervorgang läuft, sind „«“ und „»“ gesperrt (Annahme K27-4); Tippen nennt den Grund in der Meldezeile (A-28).

**Filter.** Die Pfeiltasten wählen den Filtertyp. Der aktuell geschriebene Filter wird als Anzeigetext des Felds gezeigt (Referenz: ausgegraut); weicht die Auswahl davon ab, zeigt das Feld `Icon.State.Pending` und den Text „Nicht übernommen“ (Annahme K27-2). „Filter setzen“ schreibt die Auswahl. Schlägt das Schreiben fehl, zeigt die Statusanzeige die Fehlerart (Symbol `Icon.Status.Error`, Wort „Fehler“, Text „Fehler beim Schreiben der Filterwerte“) und das Auswahlfeld bleibt im Zustand „Nicht übernommen“.

**Nullpunkt.** „Nullpunkt setzen“ wirkt sofort bei Antippen und ist ohne Schlüssel bedienbar (Referenz). Ist die Waage belastet, kann der Nullpunkt falsch werden; die Referenz nennt keine Sperre, deshalb keine Sperre, aber dauerhafter Hinweistext „Nur bei unbelasteter Waage“ im Caption-Stil unter der Taste (Annahme K27-6).

**Kalibrierung.** Ablauf: Start Kalibrierung → Aufforderung der Steuerung → Entlastet → Kalibriergewicht auflegen → Belastet → Bestätigung. Tastenzustände (Annahme K27-3, in der Quelle nicht beschrieben): Im Ruhezustand sind „Entlastet“ und „Belastet“ deaktiviert (gestrichelte Kontur, Text deaktiviert, Grund in der Meldezeile); „Start Kalibrierung“ wird nach dem Start deaktiviert; „Reset“ ist immer bedienbar. Die Aufforderung und die Bestätigung erscheinen als Text in der Statusanzeige (Art Info), nicht als Pop-up; ihre Form ist im Handbuch nicht beschrieben (OP-38, OP-48). Nach der Bestätigung bleibt der Hinweis „Nullpunkt und Prüfgewicht prüfen“ (Schritt 5) stehen, bis er durch eine neue Meldung ersetzt wird. „Reset“ beendet den Vorgang, setzt die Tastenzustände zurück, quittiert anstehende Fehler der aktuellen Waage und leert die Fehlermeldung der Statusanzeige.

**Berechtigungen.** Schlüsselsymbol (`Icon.Key`) an Filtertyp, „Filter setzen“, „Start Kalibrierung“, „Entlastet“, „Belastet“; keines an „Nullpunkt setzen“ und „Reset“ (Annahme A-08: Schlüssel = berechtigungspflichtig; Rolle je Element offen, OP-25, OP-04). Fehlt die Berechtigung: `Icon.Lock` und Hinweis „Berechtigung erforderlich: <Rolle>“, Tippen öffnet das Benutzer-Pop-up ([Navigation.md](../Navigation.md) 4.1); nach erfolgreicher Anmeldung wird die ausgelöste Aktion fortgesetzt. Das Schlüsselsymbol steht in `Brush.Text.Primary`, nicht in Gelb.

**Pop-ups.** Die Seite hat keine eigenen Pop-ups. Das Benutzer-Pop-up folgt den modalen Regeln von [Navigation.md](../Navigation.md) 4.2 (Scrim, Seitenleiste und Funktionsleiste gesperrt, kein Schließen durch Antippen außerhalb).

**Fehlerfälle.** Fehler beim Schreiben des Filters (Statusanzeige), Ausfall der Waage oder ungültiges Gewicht: Gewichtsanzeige zeigt „---“, Statusanzeige nennt die Störung der gewählten Waage; „Reset“ quittiert (Referenz). Anstehende Maschinenmeldungen erscheinen zusätzlich in der Meldezeile.

**Navigation.** „Zurück“ (Seitenleiste) führt im Verlauf zurück, Ziel HS-42. Brotkrümel-Segmente „Einstellung“ und „Waagen“ springen zu HS-04 bzw. HS-42. Die Navigation löst keine Aktion an der Maschine aus.

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-27-P01 | Seitenname und Pfad (RS-27-P01) | Brotkrümel „Einstellung › Waagen › Waagen kalibrieren“; Zugang über HS-42 Kachel „Waagen kalibrieren“; „Zurück“ führt zu HS-42 | offen |
| HS-27-P02 | Gewichtsanzeige (RS-27-P02) | Livegewicht der gewählten Waage in g mit einer Nachkommastelle, Dezimalkomma, Minuszeichen bei negativen Werten (Beispiel −398,9 g), geschütztes Leerzeichen vor der Einheit | offen |
| HS-27-P03 | Waagentitel (RS-27-P03) | Name der gewählten Waage steht als Titelzeile über der Gewichtsanzeige (Beispiel „16KW1 Kontrollwaage“), Trennlinie statt Unterstreichung | offen |
| HS-27-P04 | Filtertyp-Auswahl (RS-27-P04) | Auswahlfeld mit linker und rechter Pfeiltaste (je mindestens `Size.Touch.Default` × `Size.Touch.Default`) wählt den Filter; Beispieltext „IIR 5 56ms 8Hz“; `Icon.Key` am Feld | offen |
| HS-27-P05 | Filter setzen (RS-27-P05) | Taste mit `Icon.Key` schreibt den gewählten Filtertyp; vorher zeigt das Feld „Nicht übernommen“, nachher nicht mehr | offen |
| HS-27-P06 | Fehler beim Filterschreiben (RS-27-P06) | Fehlgeschlagenes Schreiben erscheint in der Statusanzeige unter den Tasten mit `Icon.Status.Error` und Wort „Fehler“ (Text „Fehler beim Schreiben der Filterwerte“) | offen |
| HS-27-P07 | Nullpunkt setzen (RS-27-P07) | Taste ohne Schlüsselsymbol setzt den Nullpunkt; Hinweis „Nur bei unbelasteter Waage“ steht an der Taste | offen |
| HS-27-P08 | Statusanzeige (RS-27-P08) | Textfeld zeigt Meldungen, Fehler und Hinweise der gewählten Waage; nur Anzeige, nicht bedienbar | offen |
| HS-27-P09 | Tastenreihe Kalibrierung (RS-27-P09) | Vier Tasten in der Reihenfolge Start Kalibrierung, Entlastet, Belastet, Reset; die ersten drei mit `Icon.Key`, Reset ohne | offen |
| HS-27-P10 | Ablauf Kalibrierung (RS-27-P10) | Start Kalibrierung → Aufforderung in der Statusanzeige → Entlastet → Belastet → Bestätigung in der Statusanzeige; „Entlastet“ und „Belastet“ sind vor dem Start deaktiviert (gestrichelte Kontur, Grund in der Meldezeile) | offen |
| HS-27-P11 | Reset (RS-27-P11) | Reset bricht den Vorgang ab, setzt alle Zwischenschritte zurück, quittiert anstehende Fehler der aktuellen Waage und ist in jedem Zustand bedienbar | offen |
| HS-27-P12 | Waagen blättern (RS-27-P12) | „«“ und „»“ in der Funktionsleiste wechseln die Waage; Titelzeile, Gewichtsanzeige und Statusanzeige wechseln mit; Positionsanzeige „n von m“; kein Verlaufseintrag; an den Rändern Taste deaktiviert mit gestrichelter Kontur | offen |
| HS-27-P13 | Rahmenelemente (RS-27-P13) | Kopfzeile (Logo, Betriebsart, Uhrzeit, Datum), Meldezeile im Format „NNN: Text“, Seitenleiste mit Benutzerkreis (Schloss-Ersatz), Home, Einstellungen, Zurück; untere Leiste enthält nur „«“ und „»“ | offen |
| HS-27-P14 | Prüfung nach Kalibrierung (RS-27-P14) | Nach der Bestätigung bleibt der Hinweis „Nullpunkt und ein Prüfgewicht (z. B. 500 g) prüfen“ sichtbar | offen |
| HS-27-P15 | Vollständigkeit (RS-27-P15) | Alle 9 Zeilen aus T37, die Zeile aus T38, die 7 Kalibrierschritte (Gruppe „Ablauf Kalibrierung“) und die Bildelemente aus RS-27_01 sind im Layout wiederzufinden (Spalte „Herkunft“ der Elemente-Tabelle) | offen |
| HS-27-P16 | Ablaufgruppe | Die Gruppe „Ablauf Kalibrierung“ nennt alle 7 Schritte im Handbuchwortlaut (Schritt 5 mit Beispiel 500 g) | offen |
| HS-27-P17 | Berechtigungssymbole | Schlüssel an Filtertyp, Filter setzen, Start Kalibrierung, Entlastet, Belastet; keiner an Nullpunkt setzen und Reset; Symbole in `Brush.Text.Primary`; ohne Berechtigung `Icon.Lock` und Hinweis „Berechtigung erforderlich: <Rolle>“ | offen |
| HS-27-P18 | Touch-Ziele (Designsystem) | Alle Tasten und Pfeiltasten mindestens `Size.Touch.Default` hoch (Trefferbereich nie unter `Size.Touch.Min`), Abstand zwischen Touch-Zielen mindestens `Size.Touch.Gap`; Funktionsleisten-Tasten mindestens `Size.FunctionButton.MinWidth` | offen |
| HS-27-P19 | Zweiter Kanal (Designsystem) | Deaktiviert = gestrichelte Kontur (`Border.Dash`); Fehler = `Icon.Status.Error` plus Wort und Kontur `Border.Thick`; nicht übernommener Filter = `Icon.State.Pending` plus Text; kein Zustand nur über Farbe | offen |
| HS-27-P20 | Tokens und Texte (Designsystem) | Keine Hex-, Pixel- oder Literaltexte im XAML; Farben, Schriften und Maße aus Tokens (Schrift mindestens `Font.Size.Caption`); alle sichtbaren Texte aus `.resx` | offen |
| HS-27-P21 | Hell/Dunkel | Beide Themen zeigen alle Zustände mit Kontrast gemäß Designsystem (Text mindestens 4,5 : 1, Konturen mindestens 3 : 1) | offen |

## Offene Punkte

Aus dem Seiten-Index in [Offene-Punkte.md](../../00_Plan/Offene-Punkte.md): [OP-25](../../00_Plan/Offene-Punkte.md) (Bedeutung des Schlüssels, Berechtigungsstufen), [OP-26](../../00_Plan/Offene-Punkte.md) (Schloss- und Spiralsymbol), [OP-28](../../00_Plan/Offene-Punkte.md) (Wertebereiche, Standardwerte), [OP-35](../../00_Plan/Offene-Punkte.md) (Quellfehler im Wortlaut, z. B. „schreiben“), [OP-38](../../00_Plan/Offene-Punkte.md) (Zugänge und Ziele), [OP-41](../../00_Plan/Offene-Punkte.md) (Zahl und Namen der Waagen), [OP-44](../../00_Plan/Offene-Punkte.md) (Bild 4:3 gegen 1920 × 1080), [OP-48](../../00_Plan/Offene-Punkte.md) (Kalibrierablauf, Aufforderung und Bestätigung). Zusätzlich berührt: OP-04 (Berechtigungsmodell), OP-21 (Antippbarkeit des Brotkrümels).

Annahme-Kandidaten dieser Seite (Verwalter, siehe Bericht): K27-1 Layout 7 : 5 mit Ablaufgruppe; K27-2 „Nicht übernommen“ für den Filtertyp (ausgegrauter Text = geschriebener Filter); K27-3 Tastenzustände und Aufforderung/Bestätigung in der Statusanzeige, aktueller Schritt nur bei Rückmeldung; K27-4 Blättertasten während Kalibrierung gesperrt; K27-5 Korrektur der Schreibweise „Schreiben“ in `.resx`; K27-6 Hinweistext „Nur bei unbelasteter Waage“ an „Nullpunkt setzen“. Weiterhin offen: Liste der Filtertypen und Standardfilter, gefordertes Kalibriergewicht (Wert, Einheit), Verhalten am ersten und letzten Eintrag (Umlauf oder Anschlag), Zahl und Namen der Waagen.
