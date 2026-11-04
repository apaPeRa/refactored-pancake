# HS-10 – Zeitschaltuhr

- Quelle: [RS-10](../../02_Referenz-Analyse/Seiten/RS-10_Zeitschaltuhr.md) (Handbuch Kapitel 10, ohne Tabellen; Bilder [RS-10_01](../../02_Referenz-Analyse/Medien/RS-10_01.png) bis [RS-10_06](../../02_Referenz-Analyse/Medien/RS-10_06.png)). Es gibt keine Design-Seite; Aufbau und Optik sind aus dem [Designsystem](../Designsystem.md), den Modulen und der Schwesterseite [HS-07](HS-07_Heissleim-Nordson.md) (Design [DS-03](../../01_Design-Analyse/Seiten/DS-03_Heissleim.md), Funktionsleisten-Taste „Zeitplan“) abgeleitet.
- Navigationspfad: Einstellung › Zuführungen › Heißleim › Zeitplan (Brotkrümel laut [Navigation.md](../Navigation.md), Abschnitt 2). Zugang: Funktionsleiste „Zeitplan“ in [HS-07](HS-07_Heissleim-Nordson.md) (abgeleitet, A-14, OP-36), nicht die Zustandstaste „Zeitschaltuhr“ im Arbeitsbereich von HS-07 (diese aktiviert nur den Zeitplan, OP-14). Zurück-Ziel: HS-07. PageKey `HotGlueSchedule`, Route `settings/feeders/hotglue/schedule`, Mindestrolle: jeder angemeldete Benutzer.
- Seitentitel (Ressource `Nav_HotGlueSchedule_Title`): „Zeitschaltuhr“ (Kapitelname, gewinnt nach OP-33; der Bildtitel „Zeitschaltuhr Zuführung“ ist nur ein Hinweis). Im Inhaltsbereich steht kein eigener Titel, das letzte Brotkrümel-Segment „Zeitplan“ (Beschriftung des Designs) ersetzt ihn.

## Zweck

Wortgetreu (Handbuch): „Die Zeitschaltuhr erlaubt das zeitgesteuerte Ein- und Ausschalten der Heizung des Heißleimgeräts. Der Zeitplan wird unabhängig von der SPS ausgeführt – solange das Gerät eingeschalten ist. Abschalten des Geräts oder des Hauptschalters der Maschine wird der Zeitplan unterbrochen.“

Auf der Seite wird der Wochenzeitplan gepflegt: je Wochentag können Heizphasen (Aufheizen und Abschalten der Heizungen) mit eingebetteten Absenkphasen (Standby, reduzierte Temperatur) angelegt, bearbeitet und gelöscht werden.

## Aufbau (Bereiche, Layout)

Rahmen wie im Designsystem Abschnitt 3.2. Der Inhaltsbereich ist abgeleitet aus dem Designsystem und dem Referenzbild: eine Hinweiszeile oben (Zeilenhöhe nach Inhalt), darunter das Wochenraster über die volle Inhaltsbreite mit **sieben gleich breiten Spalten** (Stern 1\* je Spalte, Gutter `Space.M`; die 12 Spalten des Rasters sind für diese Seite durch die 7 Tagesspalten ersetzt, weil 12 nicht durch 7 teilbar ist). Das Wochenraster nimmt den Rest der Höhe ein (Stern). Keine festen Pixelpositionen. Die Funktionsleiste ist leer, aber sichtbar.

```
Inhaltsbereich
+--------------------------------------------------------------------------+
| (i) Hinweis: Der Zeitplan läuft unabhängig von der SPS ...      (HM-27)  |
+----------+----------+----------+----------+----------+----------+--------+
| Montag   | Dienstag | Mittwoch | Donners- | Freitag  | Samstag  | Sonntag|
|          |          |          | tag      |          |          |        |
| [+ (K)]  | [+ (K)]  | [+ (K)]  | [+ (K)]  | [+ (K)]  | [+ (K)]  | [+ (K)]|
|          |          |          |          |          |          |        |
| Heizphase| Heizphase| Heizphase|  leer    |  leer    |  leer    |  leer  |
|  06:30 ein| 06:30 ein| 08:00 ein|          |          |          |        |
|  14:40 aus| 14:40 aus|  Absenk.:|          |          |          |        |
|          |          | 12:00 abs.|          |          |          |        |
|          |          | 13:00 auf.|          |          |          |        |
|          |          | 16:00 aus |          |          |          |        |
+----------+----------+----------+----------+----------+----------+--------+
Funktionsleiste: leer                                    ((K) = Schlüsselsymbol)
```

| Bereich | Spalten / Zeilen | Inhalt |
|---|---|---|
| Hinweiszeile | volle Inhaltsbreite, Höhe nach Text | Hinweis zur Geltung des Zeitplans (Wortlaut des Handbuchs) |
| Wochenraster | 7 gleich breite Spalten Montag bis Sonntag (Reihenfolge wie Referenz, erster Wochentag Montag); je Spalte oben die Kopfzelle mit Tagesname und Plus-Taste, darunter die Einträge des Tages von oben nach unten in Zeitreihenfolge | Phasen; eine Heizphase ist eine Karte mit Startzeile und Stoppzeile, eine enthaltene Absenkphase eine eingerückte Karte dazwischen (Schachtelung, [HM-29](../Module/HM-29_Wochen-Zeitplan.md)); die Spalte scrollt vertikal (Wischen), wenn die Einträge nicht passen (Annahme, Anzahl Einträge je Tag nicht genannt, OP-46) |
| Pop-up „Eintrag“ | modal über dem Inhaltsbereich, höchstens 60 % der Breite ([HM-14](../Module/HM-14_Popup-Rahmen.md)); Inhalt von oben: Titelzeile, Auswahl Aktion, Zeile Startzeit, Zeile Endzeit, Zeile Unterelemente, unten Tastenreihe in der Reihenfolge des Referenzbilds RS-10_03 (Übernehmen, Abbrechen, Eintrag löschen) | Anlegen, Bearbeiten, Löschen einer Phase ([HM-30](../Module/HM-30_Zeitplan-Eintrag-Pop-up.md)) |

Beispieleinträge sind Dummy-Werte aus den Bildern der Referenz (RS-10_02: 06:30 ein / 14:40 aus bei Montag bis Mittwoch; RS-10_04: Mittwoch Heizphase 08:00 bis 16:00 mit Absenkphase 12:00 bis 13:00; Beispielzeiten sind keine Standardwerte, OP-46). Im Auslieferungszustand sind alle Spalten leer (RS-10_01).

```
Pop-up beim Bearbeiten einer Heizphase  (bei Neuanlage entfallen Zähler und Löschen)
+----------------------------------------------------------------+
| Neuer Eintrag                                              [X] |
|  Aktion:      [<]  Heizphase  [>]                              |
|  Startzeit:   [Ein/Aus: Zeit aktiv]   [ 08:00 ]                |
|  Endzeit:     [Ein/Aus: Zeit aktiv]   [ 16:00 ]                |
|  Absenkphasen (Unterelemente):  0                              |
|  [Übernehmen]  [Abbrechen]  [Löschen]                   |
+----------------------------------------------------------------+
```

## Elemente

Spalte „Herkunft“ stellt die Rückverfolgung zu RS-10 her. Alle Zeilen der Abschnitte „Wochenraster und Phasen“, „Pop-up Neuer Eintrag“ und „Rahmenelemente“ von RS-10 sind enthalten.

### Rahmen

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Seitenleiste (Benutzerkreis, Home, Einstellungen, Meldungen, Zurück) | Rahmen | Navigation; „Zurück“ führt zu HS-07; Benutzerkreis ersetzt das gelbe Vorhängeschloss | [HM-01](../Module/HM-01_Seitenleiste.md) | RS-10 Rahmenelemente „Vorhängeschloss“, „Produktion/Einstellungen/Zurück“ (A-35) |
| Kopfzeile (Logo, Betriebsart, Uhrzeit/Datum) | Rahmen | Anzeige; das Wirbel-Symbol der Referenz entfällt (OP-26) | [HM-02](../Module/HM-02_Kopfzeile.md) | RS-10 Rahmenelemente „Kopfzeile“ |
| Meldezeile | Rahmen | aktuelle Meldung, Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | RS-10 Rahmenelemente „Meldezeile“ |
| Brotkrümel „Einstellung › Zuführungen › Heißleim › Zeitplan“ | Navigation | Pfad; Segmente „Einstellung“, „Zuführungen“, „Heißleim“ antippbar (HS-04, HS-40, HS-07); ersetzt den Bildtitel „Zeitschaltuhr Zuführung“ | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | RS-10 Aufbau Kopfzeile (Titel) |
| Kennzahlen Geschwindigkeit und Maschinenwinkel | Anzeige | Geschwindigkeit öffnet HS-03 | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | Rahmen des Designs (DS-03) |
| Funktionsleiste (leer) | Rahmen | bleibt sichtbar, keine seitenspezifischen Tasten | [HM-06](../Module/HM-06_Funktionsleiste.md) | RS-10 Aufbau Punkt 4 (links leer) |

### Wochenraster und Phasen

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Hinweis zur Geltung | Hinweis-Textfeld (Art Info) | Text sinngemäß (umformuliert, nicht wortgetreu; Original siehe Zweck): Der Zeitplan läuft unabhängig von der SPS, solange das Gerät eingeschaltet ist; Abschalten des Geräts oder des Hauptschalters der Maschine unterbricht ihn. | [HM-27](../Module/HM-27_Hinweis-Textfeld.md) | RS-10 Zweck, Zustände „Ausführung“ (RS-10-P13) |
| Spalten Montag bis Sonntag | Tagesspalten (7), Tagesname ohne Unterstreichung | Zeitplan je Wochentag; Phasen erscheinen als Einträge in der Spalte | [HM-29](../Module/HM-29_Wochen-Zeitplan.md) | RS-10 „Spalten Montag bis Sonntag“ |
| Plus-Taste je Tag | Taste mit Plus-Symbol und Schlüsselsymbol (Kopfzelle der Spalte) | „Soll eine neue Phase hinzugefügt werden kann zwischen zwei Aktionen gewählt werden, Heißphase und Absenkphase (StandBy).“ Öffnet das Pop-up „Neuer Eintrag“ | [HM-29](../Module/HM-29_Wochen-Zeitplan.md) (Plus, `AddCommand`), Pop-up [HM-30](../Module/HM-30_Zeitplan-Eintrag-Pop-up.md) | RS-10 „Plus-Taste je Tag“ (RS-10_06, RS-10_03) |
| Schlüsselsymbol je Tag | Symbol an der Plus-Taste (`Icon.Key` bzw. `Icon.Lock`) | kennzeichnet die berechtigungspflichtige Eingabe (Bedeutung im Handbuch nicht erklärt, OP-25) | [HM-29](../Module/HM-29_Wochen-Zeitplan.md) (Berechtigung der Plus-Taste) | RS-10 „Schlüsselsymbol je Tag“ |
| Eintrag Heizphase | antippbare Karte in der Spalte, Symbol `Icon.Schedule.Heat`; Zeilen „08:00 ein“ … „16:00 aus“ | „Heizphase: Startzeit: Das Heißleimgerät beginnt mit dem Aufheizen auf die Soll-Temperaturen. Stoppzeit: Das Heißleimgerät schaltet alle Heizungen ab.“ Antippen öffnet das Pop-up (gleiche Struktur) im Bearbeiten-Zustand. Ist nur eine Zeit aktiv, zeigt die Karte nur diese Zeile (Annahme, OP-46) | [HM-29](../Module/HM-29_Wochen-Zeitplan.md), Pop-up [HM-30](../Module/HM-30_Zeitplan-Eintrag-Pop-up.md) | RS-10 „Eintrag Heizphase“ (RS-10_04) |
| Eintrag Absenkphase | antippbare, eingerückte Karte innerhalb einer Heizphase, gestrichelte Kontur, Symbol `Icon.Schedule.Setback`; Zeilen „12:00 absenken“, „13:00 aufheizen“ | „Absenkphase: Startzeit: Das Heißleimgerät heizt oder kühlt auf eine reduzierte Temperatur. Stoppzeit: Wenn die Heizungen an sind, wird auf die Solltemperaturen hochgeheizt. Sind die Heizungen aus, passiert nichts.“ Kann direkt gelöscht werden | [HM-29](../Module/HM-29_Wochen-Zeitplan.md), Pop-up [HM-30](../Module/HM-30_Zeitplan-Eintrag-Pop-up.md) | RS-10 „Eintrag Absenkphase“ (RS-10_05) |

### Pop-up „Neuer Eintrag“ (RS-10 „Pop-up Neuer Eintrag“, neun Zeilen)

Alle antippbaren Bereiche (Plus-Taste, Heizphase, Absenkphase) öffnen „ein Pop-Up mit derselben Struktur“ (Handbuch).

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Titel | Titelzeile des Pop-ups mit Schließen-Kreuz | immer „Neuer Eintrag“, auch beim Bearbeiten (Bilder RS-10_04 und RS-10_05 zeigen „Neuer Eintrag:“; die Phasenart steht im Auswahlfeld „Aktion“) | [HM-14](../Module/HM-14_Popup-Rahmen.md) | RS-10 Pop-up „Titel“ |
| Aktion | Auswahlfeld mit Pfeiltasten (Heizphase, Absenkphase); in der Referenz Dropdown | Auswahl „Heizphase“ oder „Absenkphase“ (Handbuch: „Heißphase und Absenkphase (StandBy)“, gleichbedeutend, OP-34). Genau zwei Einträge; beim Bearbeiten eines vorhandenen Eintrags grau gesperrt (so im Bild RS-10_04/_05) | [HM-18](../Module/HM-18_Auswahlfeld-Pfeiltasten.md) (über HM-30) | RS-10 Pop-up „Aktion“ (RS-10_06) |
| Zeit aktiv (Start) | Umschalter („Kontrollkästchen“ der Referenz), Wort „Ein“/„Aus“ | aktiviert die Startzeit; „Um eine Phase anzulegen, muss eine Startzeit oder Stoppzeit angelegt werden. Beide Zeiten können festgelegt werden.“ | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) (über HM-30) | RS-10 Pop-up „Zeit aktiv“ |
| Zeit aktiv (Ende) | Umschalter, Wort „Ein“/„Aus“ | aktiviert die Stoppzeit (Beschriftung „Endzeit“, im Handbuchtext „Stoppzeit“, OP-34) | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) (über HM-30) | RS-10 Pop-up „Zeit aktiv“ |
| Startzeit | Zeiteingabefeld hh:mm (Dummy 08:00; leer „__:__“) | Startzeit der Phase; Antippen öffnet das Eingabe-Pop-up in der Zeitvariante (zweite Pop-up-Ebene) | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) (Eingabeart Zeit), Pop-up [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | RS-10 Pop-up „Startzeit“ |
| Endzeit / Stoppzeit | Zeiteingabefeld hh:mm (Dummy 16:00) | Stoppzeit der Phase; wie Startzeit | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) (Eingabeart Zeit), [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | RS-10 Pop-up „Stoppzeit / Endzeit“ |
| Unterelemente | Zähler der untergeordneten Absenkphasen, nur Anzeige (Symbol Baumstruktur, Zahl) | „Innerhalb einer Heizphase können Absenkphase enthalten sein.“ Bei Heizphase mit enthaltener Absenkphase „1“; bei Neuanlage nicht vorhanden | [HM-30](../Module/HM-30_Zeitplan-Eintrag-Pop-up.md) (Zähler, Darstellung wie [HM-11](../Module/HM-11_Anzeigefeld.md) mit Zähler) | RS-10 Pop-up „Unterelemente“ (RS-10_04) |
| Übernehmen (1. Taste) | Taste mit Haken-Symbol (`Icon.Confirm`) und Beschriftung | übernimmt/speichert den Eintrag; nur bei gültigen Zeiten aktiv | [HM-07](../Module/HM-07_Aktionstaste.md) (im Pop-up, über HM-30) | RS-10 Pop-up „Übernehmen“ |
| Abbrechen (2. Taste) | Taste mit X-Symbol und Beschriftung | schließt das Pop-up ohne Änderung | [HM-07](../Module/HM-07_Aktionstaste.md) (im Pop-up, über HM-30) | RS-10 Pop-up „Abbrechen“ |
| Eintrag löschen (3. Taste) | Taste mit Papierkorb-Symbol (`Icon.Delete`) und Beschriftung | löscht den Eintrag. „Um eine Heizphase zu löschen, müssen alle untergeordnete Absenkphasen gelöscht sein.“ Ausgegraut (gestrichelte Kontur, Hinweis „Zuerst Absenkphasen löschen“) bei Unterelemente > 0; bei Absenkphase aktiv („Diese Phase kann direkt gelöscht werden“); bei Neuanlage nicht vorhanden | [HM-07](../Module/HM-07_Aktionstaste.md) (im Pop-up, über HM-30) | RS-10 Pop-up „Eintrag löschen“ (RS-10_04 bis RS-10_06) |

## Verwendete Module (IDs)

[HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md), [HM-07](../Module/HM-07_Aktionstaste.md) (Pop-up-Tasten), [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) (über HM-30), [HM-11](../Module/HM-11_Anzeigefeld.md) (Zähler, über HM-30), [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) (Zeitfelder, über HM-30), [HM-13](../Module/HM-13_Eingabe-Pop-up.md) (Zeitvariante), [HM-14](../Module/HM-14_Popup-Rahmen.md) (trägt HM-30 und HM-13), [HM-18](../Module/HM-18_Auswahlfeld-Pfeiltasten.md) (über HM-30), [HM-27](../Module/HM-27_Hinweis-Textfeld.md), [HM-29](../Module/HM-29_Wochen-Zeitplan.md), [HM-30](../Module/HM-30_Zeitplan-Eintrag-Pop-up.md).

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

- **Ausführung:** Der Zeitplan läuft unabhängig von der SPS, solange das Gerät eingeschaltet ist; Abschalten des Geräts oder des Hauptschalters der Maschine unterbricht ihn. Ob der Zeitplan aktiv ist, steht an der Zustandstaste „Zeitschaltuhr“ in [HS-07](HS-07_Heissleim-Nordson.md); auf HS-10 wird der Aktivierungszustand nicht angezeigt (die Referenz zeigt ihn dort nicht, offen in OP-14).
- **Phase anlegen:** Plus-Taste des Tages antippen, Aktion wählen (Heizphase oder Absenkphase), Start- und/oder Endzeit aktivieren und eingeben, „Übernehmen“. Mindestens eine Zeit (Start oder Stopp) ist nötig, beide sind möglich. Ohne aktive Zeit ist „Übernehmen“ deaktiviert (gestrichelte Kontur) und ein Fehlertext mit `Icon.Status.Error` nennt den Grund (Annahme, [HM-30](../Module/HM-30_Zeitplan-Eintrag-Pop-up.md)).
- **Heizphase:** Startzeit = Aufheizen auf Solltemperaturen („ein“); Stoppzeit = alle Heizungen aus („aus“). **Absenkphase (Standby):** innerhalb einer Heizphase; Startzeit = auf reduzierte Temperatur heizen oder kühlen („absenken“); Stoppzeit = bei eingeschalteten Heizungen auf Solltemperaturen hochheizen, bei ausgeschalteten Heizungen nichts („aufheizen“). Die Rasteranzeige unterscheidet beide Arten über Symbol (`Icon.Schedule.Heat`, `Icon.Schedule.Setback`), Wort und Kontur (durchgezogen/gestrichelt, eingerückt), nicht nur über Farbe (RS-10-P12, Designsystem Abschnitt 5; die Farben rosa, türkis und orange der Referenz entfallen).
- **Pop-up-Zustände:** Neuanlage (kein Papierkorb, kein Unterelemente-Zähler, Zeitfelder leer „__:__“, beide Umschalter „Aus“), Bearbeiten Heizphase, Bearbeiten Absenkphase ([HM-30](../Module/HM-30_Zeitplan-Eintrag-Pop-up.md)). Das Pop-up hat den Rahmen [HM-14](../Module/HM-14_Popup-Rahmen.md); die Zeiteingabe öffnet darüber das Eingabe-Pop-up (Stapeltiefe 2, zulässig nach Navigation.md 4.2).
- **Löschen:** Heizphase erst löschbar, wenn alle untergeordneten Absenkphasen gelöscht sind (Taste deaktiviert bei Unterelemente > 0, mit Hinweis); Absenkphase direkt löschbar. Eine zusätzliche Bestätigungsrückfrage sieht die Referenz nicht vor und wird nicht ergänzt (die Löschtaste ist bereits Teil des modalen Pop-ups).
- **Fehlerfälle:** Die Referenz beschreibt keine. Annahme nach [HM-30](../Module/HM-30_Zeitplan-Eintrag-Pop-up.md): „Endzeit vor Startzeit“ (auch bei Phase über Mitternacht) wird mit Fehlertext und `Icon.Status.Error` abgelehnt, das Zeitfeld erhält Fehlerkontur; Überschneidungen (mehrere Heizphasen am Tag, Absenkphase außerhalb einer Heizphase) sind nicht beschrieben und nicht festgelegt (OP-46). Kann der Eintrag nicht an das Gerät übertragen werden, bleibt das Pop-up offen und zeigt einen Fehlertext (Annahme).
- **Berechtigungen:** Die Plus-Taste jedes Tages trägt das Schlüsselsymbol. Ohne Rolle: `Icon.Lock` und Hinweis „Berechtigung erforderlich: <Rolle>“, das Pop-up öffnet nicht. Das Antippen vorhandener Einträge zum Ansehen wird nicht gesperrt; „Übernehmen“ und „Eintrag löschen“ sind ohne Rolle gesperrt (Annahme, OP-25, OP-04).
- **Sperrzustände:** Bei gestörter Kommunikation zum Gerät (Annahme) sind Plus-Tasten und Einträge deaktiviert, das Raster zeigt den letzten bekannten Stand mit Hinweis.
- **Navigation und Zurück:** „Zurück“ (Seitenleiste) führt zu HS-07; Segment „Heißleim“ im Brotkrümel springt dorthin, „Zuführungen“ zu HS-40, „Einstellung“ zu HS-04. Pop-ups stehen nicht im Verlauf; bei offenem Pop-up ist die Navigation gesperrt, Schließen nur über „Abbrechen“, „Übernehmen“ oder Kreuz, nicht durch Antippen außerhalb (Navigation.md 4.2). Beim Schließen ohne „Übernehmen“ wird die Änderung verworfen.

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-10-P01 | Wochenraster (RS-10-P01) | sieben Spalten Montag, Dienstag, Mittwoch, Donnerstag, Freitag, Samstag, Sonntag in dieser Reihenfolge, gleich breit | offen |
| HS-10-P02 | Plus-Taste je Tag (RS-10-P02) | in jeder Spalte oben eine Plus-Taste mit Schlüsselsymbol; öffnet das Pop-up „Neuer Eintrag“ | offen |
| HS-10-P03 | Pop-up-Struktur (RS-10-P03) | Plus-Taste, Heizphase und Absenkphase öffnen ein Pop-up derselben Struktur | offen |
| HS-10-P04 | Aktion wählen (RS-10-P04) | Auswahl mit genau „Heizphase“ und „Absenkphase“ | offen |
| HS-10-P05 | Zeiten (RS-10-P05) | Startzeit und Endzeit (Format hh:mm) je mit Umschalter „Zeit aktiv“; ohne aktive Zeit ist „Übernehmen“ gesperrt | offen |
| HS-10-P06 | Pop-up-Tasten (RS-10-P06) | Übernehmen (Haken), Abbrechen (X), Eintrag löschen (Papierkorb) in dieser Reihenfolge mit Symbol und Text; Papierkorb bei Neuanlage nicht vorhanden | offen |
| HS-10-P07 | Unterelemente (RS-10-P07) | Zähler der untergeordneten Absenkphasen im Pop-up (Beispiel 0 oder 1); bei Neuanlage nicht vorhanden | offen |
| HS-10-P08 | Heizphase löschen (RS-10-P08) | bei Unterelemente > 0 ist „Eintrag löschen“ gesperrt (gestrichelt, mit Hinweis); nach Löschen aller Absenkphasen möglich | offen |
| HS-10-P09 | Absenkphase löschen (RS-10-P09) | Absenkphase direkt löschbar | offen |
| HS-10-P10 | Phasenwirkung Heizphase (RS-10-P10) | Beschreibung: Startzeit Aufheizen auf Solltemperaturen, Stoppzeit alle Heizungen aus; Raster zeigt „ein“ und „aus“ | offen |
| HS-10-P11 | Phasenwirkung Absenkphase (RS-10-P11) | Beschreibung: Startzeit auf reduzierte Temperatur, Stoppzeit bei Heizungen an Hochheizen auf Soll, bei Heizungen aus nichts; Raster zeigt „absenken“ und „aufheizen“ | offen |
| HS-10-P12 | Darstellung der Einträge (RS-10-P12) | Heizphase mit „ein“/„aus“, Absenkphase mit „absenken“/„aufheizen“, eingerückt; Typ zusätzlich über Symbol und Kontur, nicht nur über Farbe | offen |
| HS-10-P13 | Geltung (RS-10-P13) | Hinweis „läuft unabhängig von der SPS … Unterbrechung durch Abschalten des Geräts oder Hauptschalters“ als Text sichtbar | offen |
| HS-10-P14 | Brotkrümel (RS-10-P14) | „Einstellung › Zuführungen › Heißleim › Zeitplan“ (Abweichung vom Referenzpfad ist in Navigation.md begründet); drei Segmente antippbar | offen |
| HS-10-P15 | Rückweg (RS-10-P15) | „Zurück“, „Home“, „Einstellungen“ und Benutzerkreis in der Seitenleiste; „Zurück“ führt zu HS-07 | offen |
| HS-10-P16 | Quellbezug (RS-10-P16) | RS-10 mit den sechs Bildern RS-10_01 bis RS-10_06 im Kopf der Seite verlinkt; jede Zeile der Referenz-Elemente steht in der Elemente-Tabelle | offen |
| HS-10-P17 | Zustände des Pop-ups | Neuanlage, Bearbeiten Heizphase und Bearbeiten Absenkphase (Titel jeweils „Neuer Eintrag“, Aktion gesperrt) unterscheiden sich wie in RS-10_06, RS-10_04, RS-10_05 | offen |
| HS-10-P18 | Modal und Stapel (Navigation 4.2) | Pop-up sperrt Seite, Seitenleiste und Brotkrümel; Zeiteingabe öffnet HM-13 als zweite Ebene; Schließen nur über Tasten oder Kreuz | offen |
| HS-10-P19 | Aufteilung | Hinweiszeile oben, darunter 7 gleich breite Spalten; keine festen Pixelpositionen; Funktionsleiste leer, aber sichtbar | offen |
| HS-10-P20 | Zweiter Kanal (Designsystem 5) | Phasenart, Ein/Aus der Zeitaktivierung, gesperrte Taste, Fehler und Schlüssel/Schloss mit Symbol oder Text zusätzlich zur Farbe | offen |
| HS-10-P21 | Farbe nur Status | keine rosa, türkisen oder orangen Zierfarben, keine rote Zeitschrift, kein gelber Schlüssel | offen |
| HS-10-P22 | Touch (DSY-P04) | Plus-Tasten, Einträge, Umschalter und Pop-up-Tasten mindestens `Size.Touch.Min`, Standard `Size.Touch.Default` hoch; Abstand mindestens `Size.Touch.Gap` | offen |
| HS-10-P23 | Tokens und Texte (DSY-P06, DSY-P07) | keine Hex- oder Pixelwerte, keine festen Texte im XAML; Wörter wie „ein“, „aus“, „absenken“, „aufheizen“ und Pop-up-Texte aus `.resx` | offen |
| HS-10-P24 | Berechtigung | ohne Rolle: Schloss und Hinweis an der Plus-Taste, kein Pop-up | offen |

## Offene Punkte

- OP-36: Zugang zur Seite im Handbuch nicht beschrieben, abgeleitet aus der Funktionsleiste von HS-07 (A-14).
- OP-14: Abgrenzung der zwei „Zeitplan“/„Zeitschaltuhr“-Tasten (Zustandstaste in HS-07, Navigationstaste in der Funktionsleiste); Aktivierungszustand wird auf HS-10 nicht angezeigt.
- OP-25: Berechtigung (Schlüssel an der Plus-Taste, Rollen).
- OP-33, OP-34: Seitentitel (Bildtitel „Zeitschaltuhr Zuführung“ gegenüber Kapitelname „Zeitschaltuhr“), Begriffe Heißphase/Heizphase und Stoppzeit/Endzeit.
- OP-42: Dauer der Zeitschaltuhr-Phasen und weitere Zeitangaben fehlen (Dummy-Werte).
- OP-46: Fehlerfälle der Zeitschaltuhr (Überschneidungen, Phase über Mitternacht, mehrere Heizphasen je Tag, Absenkphase außerhalb einer Heizphase, Anzahl Einträge je Tag), Darstellung einer Phase mit nur einer aktiven Zeit.
