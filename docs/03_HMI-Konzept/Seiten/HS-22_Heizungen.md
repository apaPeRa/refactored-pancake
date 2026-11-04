# HS-22 – Heizungen
- Quelle: [RS-22](../../02_Referenz-Analyse/Seiten/RS-22_Heizungen.md) (Handbuch Kapitel 22, Tabelle T32, Hinweis-Textfeld; Bild [RS-22_01.png](../../02_Referenz-Analyse/Medien/RS-22_01.png)); Design: keine eigene Design-Seite, nur die Kachel „Heizungen“ in [DS-02](../../01_Design-Analyse/Seiten/DS-02_Einstellungen.md) (Zugang); Aufbau abgeleitet aus [Designsystem](../Designsystem.md) und den Modulen HM-28, HM-08, HM-12, HM-11, HM-09, HM-27.
- Navigationspfad: Einstellung › Heizungen (Brotkrümel, [Navigation.md](../Navigation.md) Abschnitt 2). Zugang: HS-04, Kachel „Heizungen“. Zurück-Ziel: HS-04 (Verlauf). Schlüssel `Heaters` / Route `settings/heaters`, Mindestrolle: keine (Seitenzugang frei).

## Zweck
Im Dornrad und in der Schließmaschine sind Heizungen zum Verschließen des Siegelpapiers verbaut. Die Seite zeigt je Heizzone die Temperaturen und erlaubt, jede Zone einzeln ein- oder auszuschalten, ihre Überwachung (Funktion und Sollwertabweichung) getrennt zu deaktivieren und die Solltemperatur einzustellen. Die Aktivierung der Heizungen insgesamt erfolgt nicht hier, sondern über die Seite Produktion ([HS-01](HS-01_Produktion.md), Handbuch: „Die Aktivierung der Heizungen erfolgt über die Seite Produktion.“). Heizungen bleiben nach dem Abschalten heiß; der Warnhinweis ist deshalb dauerhaft sichtbar.

## Aufbau (Bereiche, Layout)
Rahmen wie auf allen Vollseiten ([Designsystem](../Designsystem.md) Abschnitt 3.2): Seitenleiste, Kopfzeile mit Meldezeile, Brotkrümel mit Kennzahlen, Funktionsleiste (auf dieser Seite leer, aber sichtbar, [Navigation.md](../Navigation.md) 3.3). Der Inhaltsbereich nutzt das 12-Spalten-Raster (Außenrand `Space.L`, Gutter `Space.M`) und hat drei Zeilen:

1. **Hinweiszeile** (Höhe nach Inhalt, mindestens `Size.Touch.Default`): links 8 Spalten der Warnhinweis „Verbrennungsgefahr“, rechts 4 Spalten die Info zur Aktivierung. Die Zeile scrollt nicht mit.
2. **Tabellenkopf** (Höhe `Size.Touch.Min`): Spaltenköpfe, scrollt nicht mit.
3. **Zonenliste** (Stern, übrige Höhe): 12 Zeilen je Heizzone, Zeilenhöhe `Size.Touch.Default`, Abstand `Size.Touch.Gap`. Die 12 Zeilen passen bei der Zielauflösung nicht vollständig in den Inhaltsbereich; die Liste scrollt senkrecht (Wischen und Bildlauftasten, siehe unten), der Tabellenkopf bleibt stehen (HM-28: „12 Zeilen scrollbar“).

Spaltenproportionen der Tabelle (zusammen 12 Spalten, zusätzlich rechts eine schmale Bildlaufleiste in Breite `Size.Touch.Min`):

| Spalte | Spalten von 12 | Inhalt |
|---|---|---|
| (Zone, ohne Kopftext) | 3 | Zonenname, linksbündig (Referenz: rechtsbündig neben der Spalte Heizung) |
| Heizung | 2 | Zustandstaste Ein/Aus, Schlüssel |
| Meldung | 2 | Zustandstaste Überwachung, Schlüssel |
| Soll | 2 | Eingabefeld, Schlüssel |
| Ist | 1 | Anzeigefeld |
| State | 1 | Status-LED mit Wort |
| Out | 1 | Status-LED mit Wort |

```
Inhaltsbereich (12 Spalten)
+---------------------------------------------------+-----------------------+
| HM-27 Warnung: Heizungen bleiben ... heiß. Achtung| HM-27 Info: Aktivierung|  Hinweiszeile
| Verbrennungsgefahr!                  (8 Spalten)  | über Produktion (4 Sp.)|  (fest)
+----------+---------+---------+---------+----+-----+----+-----+-----------+
|          | Heizung | Meldung | Soll    |Ist |State|Out |     |           |  Kopf (fest)
|  3 Sp.   |  2 Sp.  |  2 Sp.  |  2 Sp.  |1Sp.|1 Sp.|1Sp.|     |           |
+----------+---------+---------+---------+----+-----+----+-----+-----------+
| 6E1 Läng.| [Ein  ]K | [Haken]K | [150 °C]K| 0 °C| (OK)| (Aus)|  ^  Bildlauf
| ...      |         |         |         |    |     |    |     |  v  (Size.Touch.Min)
| 20E4 Kopf| (Zeilen 8 bis 12 per Bildlauf erreichbar)         |
+----------+---------+---------+---------+----+-----+----+-----+-----------+
Funktionsleiste: leer (sichtbar)
```

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Rückverfolgung: Die Spalte „Herkunft“ nennt die Zeile in [RS-22](../../02_Referenz-Analyse/Seiten/RS-22_Heizungen.md) (T32 = Tabelle des Handbuchs, Bild = Bild RS-22_01.png, Aufbau = Abschnitt Aufbau der RS-Seite).

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Warnhinweis Verbrennungsgefahr | Hinweis-Textfeld, Art Warnung, Symbol und Wort „Warnung“ | Text: „Heizungen bleiben nach dem Abschalten noch eine Zeit lang heiß. Achtung: Verbrennungsgefahr!“; immer sichtbar, auch wenn alle Zonen aus sind; nicht ausblendbar | [HM-27](../Module/HM-27_Hinweis-Textfeld.md) | Hinweis-Textfeld (Warnsymbol) |
| Info Aktivierung | Hinweis-Textfeld, Art Info | Text: „Die Aktivierung der Heizungen erfolgt über die Seite Produktion.“ (Handbuchwortlaut); reine Anzeige, keine Navigation (A-38: Heizungen in HS-01 ist Zustandstaste) | [HM-27](../Module/HM-27_Hinweis-Textfeld.md) | Zweck / Funktionsbeschreibung |
| Tabellenkopf | Beschriftung, 6 Kopftexte „Heizung“, „Meldung“, „Soll“, „Ist“, „State“, „Out“ (Reihenfolge wie Referenz, Ressourcentexte) | benennt die Spalten; bleibt beim Scrollen sichtbar | [HM-28](../Module/HM-28_Temperaturzonen-Zeile.md) (Spaltenraster) | Aufbau, T32 |
| Zeilenbeschriftung (12 Zonen) | Text je Zeile | Zonenname: 1 „6E1 Längsnaht Links Zone 1“, 2 „6E1 Längsnaht Links Zone 2“, 3 „6E1 Längsnaht Links Zone 3“, 4 „6E2 Längsnaht Rechts“, 5 „6E3 Boden Oben Vorsiegeln“, 6 „6E4 Boden Unten Vorsiegeln“, 7 „6E4 Boden Oben Fertigsiegeln“, 8 „6E4 Boden Unten Fertigsiegeln“, 9 „20E1 Kopf Vorsiegeln Hinten“, 10 „20E2 Kopf Vorsiegeln Vorne“, 11 „20E3 Kopf Fertigsiegeln Hinten“, 12 „20E4 Kopf Fertigsiegeln Vorne“ (Zonenzahl und Namen sind konfigurationsabhängig, OP-41) | [HM-28](../Module/HM-28_Temperaturzonen-Zeile.md) (Variante Heizungen, `ZoneName`) | Aufbau (Zeilenbeschriftungen), T32 „Zeilenbeschriftung“ |
| Heizung (je Zone, 12×) | Zustandstaste Ein/Aus mit Schlüsselsymbol | „Jede Heizung kann einzeln ein- oder ausgeschaltet werden.“ Zustand über Symbol und Wort „Ein“/„Aus“, nicht über Grün (A-31) | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) (Darstellung Taste) in [HM-28](../Module/HM-28_Temperaturzonen-Zeile.md) | T32 „Heizung“, Bild Spalte Heizung |
| Meldung (je Zone, 12×) | Zustandstaste Überwachung mit Schlüsselsymbol | „Überwacht jede Heizung auf Funktion und Sollwertabweichung. Die Überwachung ist separat deaktivierbar.“ Ein: Symbol Haken und Wort „Ein“; Aus: `Icon.State.Off` und Wort „Aus“ | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) in [HM-28](../Module/HM-28_Temperaturzonen-Zeile.md) | T32 „Meldung“, Bild Spalte Meldung |
| Soll (je Zone, 12×) | Eingabefeld Zahl, Einheit °C (Bild: „°“), Schlüsselsymbol | „Vorgabe der Zieltemperatur der entsprechenden Heizung.“ Antippen öffnet das Eingabe-Pop-up (A-20); Beispielwerte 150 °C (Zonen 1 bis 8), 170 °C (Zonen 9 bis 12) | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | T32 „Soll“, Bild Spalte Soll |
| Ist (je Zone, 12×) | Anzeigefeld, Einheit °C, ohne Schlüssel | „Aktuell Temperatur der der entsprechenden Heizung.“ (Handbuchschreibweise, sinngemäß „Aktuelle Temperatur der Heizung“); nur Anzeige, Beispiel 0 °C | [HM-11](../Module/HM-11_Anzeigefeld.md) | T32 „Ist“, Bild Spalte Ist |
| State (je Zone, 12×) | Status-LED mit Symbol und Wort | „Zeigt den Status der Heizung an.“ Aus (Handbuch: grau) = leerer Kreis, Wort „Aus“; Zieltemperatur erreicht (grün) = Haken, Wort „OK“; nicht bereit oder Fehler (rot) = Kreuz, Wort „Fehler“ | [HM-09](../Module/HM-09_Status-LED.md) | T32 „State“, Bild Spalte State |
| Out (je Zone, 12×) | Status-LED mit Symbol und Wort | „Zustand des Ausgangs.“ Ausgang an = Zustand An (Haken, Wort „Ein“), aus = leerer Kreis, Wort „Aus“ (Farbbedeutung im Handbuch nicht beschrieben, Annahme H-3) | [HM-09](../Module/HM-09_Status-LED.md) | T32 „Out“, Bild Spalte Out |
| Zonenzeile (12×) | Zeilenkomposition | fasst Name, Heizung, Meldung, Soll, Ist, State, Out zu einer Zeile zusammen; Zeilenhöhe `Size.Touch.Default` | [HM-28](../Module/HM-28_Temperaturzonen-Zeile.md) (`RowKind = Heating`) | T32 „Zeilenbeschriftung (nur im Bild)“, Aufbau |
| Bildlauftasten | Tasten `Icon.Scroll.Up` / `Icon.Scroll.Down` und Bildlaufleiste | scrollen die Zonenliste um eine Zeilenhöhe bzw. zeigen die Position; ergänzt, weil 12 Zeilen nicht in den Inhaltsbereich passen (Annahme H-2) | [HM-07](../Module/HM-07_Aktionstaste.md) | – (Platzbedarf des neuen Layouts) |
| Kopfzeile mit Logo, Titel, Wirbel-Symbol, Uhr/Datum | Rahmen | Logo, Betriebsart, Uhrzeit und Datum; der Seitentitel „Heizungen“ steht im Brotkrümel; das Wirbel-Symbol ist die Betriebsart-Anzeige (A-48, OP-26) | [HM-02](../Module/HM-02_Kopfzeile.md) | Bild Kopfzeile, T32 „Seitenkopf“ |
| Meldezeile („*450* Palettierung nicht bereit“) | Rahmen, Anzeige | Aktuelle Meldung im Format „NNN: Text“, Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | Bild Meldezeile, T32 „Meldezeile“ |
| Brotkrümel und Kennzahlen | Rahmen | „Einstellung › Heizungen“; Kennzahlen Geschwindigkeit und Maschinenwinkel | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | (Design-Rahmen, Navigation.md Abschnitt 2) |
| Fußleiste „Produktion“, „Einstellungen“, „Zurück“ | Rahmentasten | wandern in die Seitenleiste: Home, Einstellungen (Zahnrad), Zurück (A-35); auf dieser Seite hat die Funktionsleiste keine eigenen Tasten (leer, sichtbar) | [HM-01](../Module/HM-01_Seitenleiste.md), [HM-06](../Module/HM-06_Funktionsleiste.md) | Bild Fußleiste, T32 „Fußleiste“ |
| Schloss-Symbol (gelb, Fußleiste Mitte) | Statussymbol | entfällt als eigenes Element; der Anmeldestatus steht im Benutzerkreis der Seitenleiste (A-35, OP-26) | [HM-01](../Module/HM-01_Seitenleiste.md) | Bild Fußleiste |

## Verwendete Module (IDs)
- [HM-28](../Module/HM-28_Temperaturzonen-Zeile.md) – Temperaturzonen-Zeile (Variante Heizungen, 12 Zeilen)
- [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) – Zustandstaste / Umschalter (Heizung, Meldung)
- [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) – Eingabefeld mit Schlüsselsymbol (Soll)
- [HM-13](../Module/HM-13_Eingabe-Pop-up.md) – Eingabe-Pop-up (Soll), getragen von [HM-14](../Module/HM-14_Popup-Rahmen.md) – Pop-up-Rahmen
- [HM-11](../Module/HM-11_Anzeigefeld.md) – Anzeigefeld (Ist)
- [HM-09](../Module/HM-09_Status-LED.md) – Status-LED (State, Out)
- [HM-27](../Module/HM-27_Hinweis-Textfeld.md) – Hinweis-Textfeld (Verbrennungsgefahr, Aktivierung)
- [HM-07](../Module/HM-07_Aktionstaste.md) – Aktionstaste (Bildlauftasten)
- Rahmen: [HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md)

Kein Modul fehlt.

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- **Heizung ein/aus:** Tippen auf die Zustandstaste einer Zone schaltet diese Zone um (Befehl an die Steuerung). Bis die Rückmeldung eintrifft, zeigt die Taste den Zustand „Ausstehend“ (gestrichelte Kontur, `Icon.State.Pending`, Text „Wird gesetzt“, [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md)). Aus: Zeile in `Brush.Text.Secondary`, Taste mit `Icon.State.Off` und Wort „Aus“; die Ist-Anzeige bleibt sichtbar. Ausschalten verlangt keine Bestätigung (im Handbuch keine beschrieben, Bestätigungs-Pop-ups sind in Navigation.md 4.1 nur für andere Aktionen vorgesehen).
- **Zusammenspiel mit HS-01:** „Ein“ bedeutet: Zone ist angewählt. Ob tatsächlich geheizt wird, entscheidet die Aktivierung auf HS-01. Ist die Aktivierung aus, bleiben State und Out „Aus“ und Ist bleibt niedrig. Das Bild der Referenz (alle Zonen „Ein“, Ist 0 °, State grau) wird so gedeutet (Annahme H-3, OP-52).
- **Meldung (Überwachung):** Tippen schaltet die Überwachung der Zone um. Aus: `Icon.State.Off` und Wort „Aus“; Zone bleibt sichtbar. Die Darstellung „Überwachung aus“ ist in der Referenz nicht beschrieben und folgt dem Designsystem.
- **Soll:** Tippen öffnet das Eingabe-Pop-up ([HM-13](../Module/HM-13_Eingabe-Pop-up.md)) mit dem Zonennamen und „Soll“ im Titel, vorbelegtem Wert und den Grenzen als Dummy (konfigurierbar, OP-28). „Übernehmen“ nur bei gültigem Wert; ungültig: Fehlertext im Pop-up („Wert außerhalb x bis y °C“), Feld im Zustand Fehler (Kontur `Border.Thick`, `Brush.Status.Error.Fg`, `Icon.Status.Error`). „Abbrechen“ verwirft. Modale Regeln: Navigation.md 4.2 (Scrim, kein Schließen durch Tippen außerhalb, Seitenleiste und Funktionsleiste gesperrt).
- **Ist, State, Out:** nur Anzeige, nicht bedienbar, kein Pressed-Zustand. State „Fehler“: Zeile mit `Brush.Status.Error.Subtle`, Symbol `Icon.Status.Error` und Wort „Fehler“ (HM-28); zusätzlich erscheint die Meldung der Steuerung in der Meldezeile (Meldetexte nicht im Handbuch, OP-27).
- **Berechtigungen:** Heizung, Meldung und Soll sind berechtigungsgeschützt (Schlüsselsymbol, Annahme laut OP-25; Stufe offen, Dummy). Fehlt die Rolle: Schloss statt Schlüssel; Tippen öffnet das Benutzer-Pop-up (Navigation.md 4.1) und nach erfolgreicher Anmeldung läuft die ausgelöste Aktion weiter; zusätzlich Hinweis „Berechtigung erforderlich: <Rolle>“ ([Designsystem](../Designsystem.md) Abschnitt 5). Ist, State, Out haben kein Schlüsselsymbol.
- **Bildlauf:** Wischen in der Zonenliste oder Bildlauftasten; die Hinweiszeile und der Tabellenkopf bleiben stehen. Am Listenanfang bzw. -ende ist die jeweilige Bildlauftaste deaktiviert (gestrichelte Kontur).
- **Navigation:** Seitenleiste „Einstellungen“ hervorgehoben; „Zurück“ führt im Verlauf zurück (HS-04). Die Funktionsleiste ist leer. Brotkrümel-Segment „Einstellung“ führt zu HS-04. Die Zielseite für die Aktivierung (HS-01) ist nicht verlinkt (nur Hinweistext).
- **Fehlerfälle:** keine Verbindung zur Steuerung: Werte zeigen „---“ (HM-09 Unbekannt, HM-11 ungültig), Bedienung deaktiviert (gestrichelte Kontur), Grund per Tippen in der Meldezeile (A-28). Meldetexte siehe Meldezeile.
- **Pop-ups:** nur das Eingabe-Pop-up; Tiefe 1.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-22-P01 | Spalten (RS-22-P01) | Tabelle mit den Spalten Heizung, Meldung, Soll, Ist, State, Out in dieser Reihenfolge; Zonenname links davor | offen |
| HS-22-P02 | Zeilen und Zonennamen (RS-22-P02) | 12 Zeilen mit genau den zwölf Zonennamen aus dem Abschnitt Elemente, in der Reihenfolge 6E1 Zone 1/2/3, 6E2, 6E3, 6E4 (3 Zeilen), 20E1 bis 20E4 | offen |
| HS-22-P03 | Heizung je Zone (RS-22-P03) | Jede Zone lässt sich einzeln ein- und ausschalten; Ein ist an Symbol und Wort „Ein“ erkennbar, nicht nur an der Farbe | offen |
| HS-22-P04 | Meldung je Zone (RS-22-P04) | Überwachung je Zone separat aus- und einschaltbar; Zustand mit Symbol und Wort | offen |
| HS-22-P05 | Soll (RS-22-P05) | Zieltemperatur je Zone über das Eingabe-Pop-up einstellbar, Einheit im Feld; Beispielwerte 150 °C (Zonen 1 bis 8) und 170 °C (Zonen 9 bis 12) | offen |
| HS-22-P06 | Ist (RS-22-P06) | Aktuelle Temperatur je Zone als Anzeige mit Einheit, nicht editierbar, Antippen ohne Wirkung | offen |
| HS-22-P07 | State (RS-22-P07) | Aus = leerer Kreis und „Aus“; Zieltemperatur erreicht = Haken und „OK“; nicht bereit/Fehler = Kreuz und „Fehler“; jeweils zusätzlich zur Farbe | offen |
| HS-22-P08 | Out (RS-22-P08) | Zustand des Ausgangs je Zone mit Symbol und Wort, nicht bedienbar | offen |
| HS-22-P09 | Hinweis Verbrennungsgefahr (RS-22-P09) | Wortlaut „Heizungen bleiben nach dem Abschalten noch eine Zeit lang heiß. Achtung: Verbrennungsgefahr!“ mit Warnsymbol und Wort „Warnung“ sichtbar, scrollt nicht weg, auch bei allen Zonen „Aus“ | offen |
| HS-22-P10 | Schlüsselsymbole (RS-22-P10) | Heizung, Meldung und Soll tragen das Schlüsselsymbol; Ist, State, Out nicht | offen |
| HS-22-P11 | Zugang (RS-22-P11) | Erreichbar über Einstellung › Heizungen (HS-04); Info „Aktivierung über Produktion“ sichtbar; Brotkrümel „Einstellung › Heizungen“ | offen |
| HS-22-P12 | Rahmen und Fußleiste (RS-22-P12) | Produktion, Einstellungen, Zurück liegen in der Seitenleiste; Funktionsleiste ist leer und sichtbar; kein Schloss-Symbol unten | offen |
| HS-22-P13 | Bildabdeckung (RS-22-P13) | Jedes Element aus [RS-22_01.png](../../02_Referenz-Analyse/Medien/RS-22_01.png) (Kopfzeile, 12 Zeilen mit 6 Spalten, Meldezeile, Fußleiste, Schloss) ist in der Elemente-Tabelle wiederzufinden | offen |
| HS-22-P14 | Bildlauf | Alle 12 Zonen sind erreichbar; Hinweiszeile und Tabellenkopf bleiben beim Scrollen sichtbar | offen |
| HS-22-P15 | Berechtigung fehlt | Schloss statt Schlüssel; Tippen öffnet das Benutzer-Pop-up, Wert bleibt unverändert | offen |
| HS-22-P16 | Eingabe-Pop-up | Soll-Eingabe mit Titel (Zone, „Soll“), Grenzen, „Übernehmen“ nur bei gültigem Wert, „Abbrechen“ verwirft | offen |
| HS-22-P17 | Touch-Ziele | Zustandstasten, Soll-Felder und Bildlauftasten ≥ `Size.Touch.Min` (Zeilen `Size.Touch.Default`), Abstand zwischen Zeilen ≥ `Size.Touch.Gap` | offen |
| HS-22-P18 | Zweiter Kanal | Kein Zustand (Ein/Aus, Überwachung, State, Out, Fehler) nur über Farbe; jeweils Symbol und Wort | offen |
| HS-22-P19 | Tokens | Keine Hex- oder Pixelwerte in der Seite; Farben, Abstände und Größen nur über Tokens aus dem Designsystem | offen |
| HS-22-P20 | Ausstehend und Fehlerfall | Befehl gesendet, Rückmeldung offen: Taste „Wird gesetzt“; State „Fehler“: Zeile mit `Brush.Status.Error.Subtle`, Symbol und Wort | offen |

## Offene Punkte
- OP-25: Berechtigungsstufe hinter dem Schlüsselsymbol (Heizung, Meldung, Soll) nicht beschrieben; Dummy-Rolle.
- OP-26: Bedeutung von Schloss, Wirbel-Symbol und „Service“-Schriftzug; hier Anmeldestatus bzw. Betriebsart-Anzeige.
- OP-27: Farbbedeutung der Status-LEDs und der roten Schrift der Sollwerte nicht belegt; Farbe nur mit Symbol und Wort.
- OP-28: Wertebereich und Standardwert der Solltemperatur fehlen; Dummy-Grenzen.
- OP-39: Zustände „Heizung aus“ und „Meldung deaktiviert“ sind nicht abgebildet; Darstellung nach Designsystem.
- OP-41: Anzahl und Namen der Zonen sind geräteabhängig; 12 Zonen aus dem Bild.
- OP-52: Kombination „Ein“ bei Ist 0 ° und State grau; Deutung „Aktivierung über HS-01 fehlt“ nicht belegt.
- Annahmen dieser Seite (Nummerierung für den Verwalter): H-1 Einheit der Temperaturen „°C“ (das Bild zeigt nur „°“, HM-28 führt °C); H-2 Bildlauftasten ergänzt; H-3 Out-Farbbedeutung und Deutung „Ein = Zone angewählt“ wie oben.
