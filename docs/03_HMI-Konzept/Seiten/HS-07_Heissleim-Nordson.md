# HS-07 – Heißleim Nordson

- Quelle: [RS-07](../../02_Referenz-Analyse/Seiten/RS-07_Heissleim-Nordson.md) (Handbuch Kapitel 7, Tabellen T9 und T10, Bild [RS-07_01](../../02_Referenz-Analyse/Medien/RS-07_01.png)) und [DS-03](../../01_Design-Analyse/Seiten/DS-03_Heissleim.md) (Screenshot `src_Data/Design/Seite_Heissleim.png`). Funktion und Fachlogik folgen der Referenz, Layout, Navigation und Optik dem Design.
- Navigationspfad: Einstellung › Zuführungen › Heißleim (Brotkrümel laut [Navigation.md](../Navigation.md), Abschnitt 2). Zugang: [HS-40](HS-40_Zufuehrungen.md) Kachel „Heißleim“; zweiter Zugang über die Taste „Heißleimgerät“ in [HS-06](HS-06_Zufuehrung-Karton.md) und [HS-16](HS-16_Schliessmaschine.md). PageKey `HotGlueNordson`, Route `settings/feeders/hotglue`, Mindestrolle: jeder angemeldete Benutzer.
- Seitentitel (Ressource `Nav_HotGlueNordson_Title`): „Heißleim Nordson“ (Kapitelname, gewinnt nach OP-33; der Bildtitel „Heißleim Zuführung“ ist nur ein Hinweis). Im Inhaltsbereich steht kein eigener Titel; das letzte Brotkrümel-Segment „Heißleim“ ersetzt den Seitentitel der Referenz-Kopfzeile ([HM-04](../Module/HM-04_Brotkruemel-Navigation.md)).

## Zweck

Bedienung und Überwachung des Nordson-Heißleimgeräts über das HMI. Wortgetreu (Handbuch): „Diese Seite dient der Bedienung des Nordson Heißleimgeräts über das HMI. Alle Einstellungen können auch direkt am Nordson-Gerät vorgenommen werden. Für eine detaillierte Beschreibung von Einstellungen und Statusanzeigen siehe bitte das Nordson-Handbuch.“

Auf der Seite werden Heizungen, Standby, Pumpe und Zeitplan geschaltet, sieben Betriebszustände und vier Ist-Temperaturen angezeigt, der Tankfüllstand überwacht, die Füllparameter eingestellt sowie das Nachfüllsystem aktiviert und manuell angefordert. Die Unterseiten Temperatur ([HS-08](HS-08_Heissleim-Parameter.md)), Druck ([HS-09](HS-09_Heissleim-Druck.md)) und Zeitplan ([HS-10](HS-10_Zeitschaltuhr.md)) werden über die untere Funktionsleiste erreicht.

## Aufbau (Bereiche, Layout)

Rahmen wie in [Designsystem.md](../Designsystem.md) Abschnitt 3.2 (Seitenleiste 3\* : 37\*, Kopfzeile 4\*, Brotkrümel-/Kennzahlzeile 3\*, Inhalt 34\*, Funktionsleiste 4\*). Der Inhaltsbereich nutzt das 12-Spalten-Raster (Designsystem 3.3, Außenrand `Size.Content.Margin`, Gutter `Space.M`) mit der Aufteilung des Designs DS-03: **2 : 7 : 3**. Alle Zeilenhöhen sind Stern-Anteile mit den Mindesthöhen der Module; keine festen Pixelpositionen.

```
Inhaltsbereich (12 Spalten)
+--------+-----------------------------------------+------------------+
| Spalte | Mitte-Panel (HM-15)                     | Rechts-Panel     |
|  2     |  7 Spalten                              |  3 Spalten       |
|        | +------------------+------------------+ |                  |
| [Heiz- | | Status           | Aktuelle         | | Füllstand Tank   |
|  ungen]| | (Überschrift)    | Temperaturen     | | [==== 83 % ===]  |
| [Stand-| |  (OK) Bereitsch. |  Tank    Verteil.| |                  |
|  by]   | |  (OK) Temperatur |  Pistole Schlauch| | Ziel Füllstand   |
| Absenk.| |  (OK) Füllsystem |   (2 x 2 Felder, | |   [ 50 %   (K) ] |
| [Pumpe]| |  (OK) Tankfüllst.|    weitere Zonen | | Max Füllzeit     |
|        | |  (OK) Tank Klappe|    darunter)     | |   [ 60 s   (K) ] |
|        | |  (OK) Keine Stör.|                  | |                  |
|        | |  (OK) Kein Alarm |                  | |                  |
|        | |  [Hinweis HM-27] |                  | |                  |
| [Zeit- | +------------------+------------------+ | [Füllsystem]     |
|  schalt|                                         | [Manuell]        |
|  uhr]  |                                         |                  |
+--------+-----------------------------------------+------------------+
Funktionsleiste:  [Temperatur]  [Druck]  [Zeitplan]        ((K) = Schlüsselsymbol)
```

| Bereich | Spalten / Zeilen | Inhalt |
|---|---|---|
| Linke Tastenspalte | 2 von 12 Spalten, volle Inhaltshöhe; Zeilen: drei Zustandstasten oben (Heizungen, Standby, Pumpe) mit der Zusatzanzeige „Absenkung“ unter „Standby“ (Seitenannahme SA-07-1, nicht in RS-07/DS-03), flexibler Leerraum (`*`), eine Zustandstaste unten (Zeitschaltuhr) | Schalter des Geräts; Abstand zwischen den Tasten mindestens `Size.Touch.Gap` |
| Mitte-Panel | 7 von 12 Spalten; [HM-15](../Module/HM-15_Gruppenbereich.md) als Panel (`Brush.Surface.Sunken`), innen zwei Überschrift-Gruppen nebeneinander: **Status** (ca. 3 Spalten des Panels) und **Aktuelle Temperaturen** (ca. 4 Spalten des Panels) | Status-LED-Liste (7 Zeilen), Hinweis zur Betriebsbereitschaft; 2 × 2 Temperaturfelder, weitere Zonen darunter |
| Rechtes Panel | 3 von 12 Spalten; HM-15 als Panel; Zeilen: Füllstandsbalken, Ziel Füllstand, Max Füllzeit, flexibler Leerraum (`*`), untere Tastenreihe mit zwei gleich breiten Tasten (Füllsystem, Manuell) | Füllsystem überwachen und einstellen |
| Funktionsleiste | Rahmen (HM-06), links beginnend, drei Tasten | Navigation zu HS-08, HS-09, HS-10 |

Die Reihenfolge der sieben LEDs, die Beschriftungen der Felder und die Beispielwerte (Tank 150 °C, Verteiler 150 °C, Pistole 1 170 °C, Schlauch 1 160 °C, Füllstand 83 %, Ziel Füllstand 50 %, Max Füllzeit 60 s) entsprechen DS-03 und RS-07; die Werte sind Dummy-Werte (OP-28). Die Beschriftungen „Aktuelle Temperaturen“ und „Status“ erscheinen ohne Unterstreichung (Hierarchie über Größe, Gewicht und Trennlinie, [HM-15](../Module/HM-15_Gruppenbereich.md) Variante Überschrift).

## Elemente

Spalte „Herkunft“ stellt die Rückverfolgung zur Quelle her (RS = Referenz, DS = Design). Alle Tabellenzeilen T9 und T10 sowie alle Elemente des linken Anzeigebereichs und der Rahmenelemente von RS-07 sind enthalten.

### Rahmen

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Seitenleiste (Benutzerkreis, Home, Einstellungen, Meldungen, Zurück) | Rahmen | Navigation; „Zurück“ geht im Verlauf zurück (HS-40, HS-06 oder HS-16). Benutzerkreis ersetzt das gelbe Vorhängeschloss | [HM-01](../Module/HM-01_Seitenleiste.md) | RS-07 Rahmenelemente „Produktion/Einstellungen/Zurück“ und „Vorhängeschloss“ (A-35); DS-03 Rahmen |
| Kopfzeile (Logo, Betriebsart, Uhrzeit/Datum) | Rahmen | Anzeige; das Wirbel-Symbol rechts neben dem Titel entfällt (ohne Funktion, OP-26) | [HM-02](../Module/HM-02_Kopfzeile.md) | RS-07 Rahmenelemente „Kopfzeile“; DS-03 Rahmen |
| Meldezeile | Rahmen | zeigt die aktuelle Meldung, Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | RS-07 Rahmenelemente „Meldezeile“; DS-03 Rahmen |
| Brotkrümel „Einstellung › Zuführungen › Heißleim“ | Navigation | Pfad, erste zwei Segmente antippbar (HS-04, HS-40); ersetzt den Seitentitel „Heißleim Zuführung“ | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | RS-07 Kopfzeile (Titel); DS-03 Brotkrümel |
| Kennzahlen Geschwindigkeit und Maschinenwinkel | Anzeige | Geschwindigkeit öffnet HS-03 (Pop-up), Winkel nur Anzeige | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | DS-03 Rahmen (112 1/min, 245 °) |
| Funktionsleiste | Rahmen | Container der drei Navigationstasten | [HM-06](../Module/HM-06_Funktionsleiste.md) | RS-07 Untere Funktionsleiste; DS-03 Funktionsleiste |
| Taste „Temperatur“ | Aktionstaste, Navigation | öffnet [HS-08](HS-08_Heissleim-Parameter.md); ändert keinen Maschinenzustand | [HM-07](../Module/HM-07_Aktionstaste.md) | RS-07 Funktionsleiste „Temperatur“; DS-03 Taste „Temperatur“ |
| Taste „Druck“ | Aktionstaste, Navigation | öffnet [HS-09](HS-09_Heissleim-Druck.md) | [HM-07](../Module/HM-07_Aktionstaste.md) | RS-07 Funktionsleiste „Druck“; DS-03 Taste „Druck“ |
| Taste „Zeitplan“ | Aktionstaste, Navigation | öffnet [HS-10](HS-10_Zeitschaltuhr.md) (Beschriftung nach Design und Navigation.md; Referenz: „Zeitschaltuhr“). Nicht zu verwechseln mit der Zustandstaste „Zeitschaltuhr“ im Arbeitsbereich | [HM-07](../Module/HM-07_Aktionstaste.md) | RS-07 Funktionsleiste „Zeitschaltuhr“; DS-03 Taste „Zeitplan“ (grau) |

### Linke Tastenspalte (RS-07 Tabelle T9, vier Zeilen)

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Taste „Heizungen“ | Zustandstaste (Ein/Aus) | „Schaltet alle Heizungen des Geräts, der Schläuche und der Düse ein oder aus.“ Zustand über Symbol und Wort „Ein“/„Aus“, nicht über Farbe | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) (Darstellung Taste) | RS-07 T9 Zeile 1; DS-03 Taste „Heizung“ |
| Taste „Standby“ | Zustandstaste (Ein/Aus) | „Reduziert alle eingestellten Temperaturen um 56 °C (Standardwert).“ Der Wert ist die „Globale StandBy Temperatur Delta“ aus [HS-08](HS-08_Heissleim-Parameter.md) | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | RS-07 T9 Zeile 2; DS-03 Taste „Standby“ |
| Anzeige „Absenkung“ unter „Standby“ (ergänzt, Annahme SA-07-1) | Anzeige (Zeile, nicht antippbar) | **Annahme, kein Element von RS-07 oder DS-03; kann ersatzlos entfallen.** Zeigt den wirksamen Absenkwert in °C (Dummy 56 °C), gelesen aus HS-08; macht Einheit und Standardwert der Referenz sichtbar | [HM-11](../Module/HM-11_Anzeigefeld.md) (Darstellung Zeile, Einheit °C) | keine Zeile in RS-07/DS-03; nur abgeleitet aus RS-07 T9 Zeile 2 (Einheit °C, Standardwert 56 °C) |
| Taste „Pumpe“ | Zustandstaste (Ein/Aus) | „Schaltet die Förderpumpe ein oder aus.“ | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | RS-07 T9 Zeile 3; DS-03 Taste „Pumpe“ |
| Taste „Zeitschaltuhr“ | Zustandstaste (Ein/Aus), unten in der Spalte | „Aktiviert den internen Zeitplan des Nordson-Geräts.“ Schaltet nur den Zeitplan ein oder aus, öffnet keine Seite (der Zeitplan selbst wird in HS-10 gepflegt) | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | RS-07 T9 Zeile 4; DS-03 Taste „Zeitplan“ (grün, links unten) |

### Mitte-Panel: Status und Temperaturen (RS-07 „Linker Anzeigebereich“)

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Überschrift „Status“ | Gruppenüberschrift | Gruppentitel der LED-Liste | [HM-15](../Module/HM-15_Gruppenbereich.md) (Variante Überschrift) | RS-07 Linker Anzeigebereich; DS-03 Überschrift „Status“ |
| LED „Bereitschaft“ | Status-LED (Liste) | Betriebszustand, Anzeige | [HM-09](../Module/HM-09_Status-LED.md) | RS-07 LED 1; DS-03 LED 1 |
| LED „Temperatur“ | Status-LED (Liste) | wie oben | [HM-09](../Module/HM-09_Status-LED.md) | RS-07 LED 2; DS-03 LED 2 |
| LED „Füllsystem“ | Status-LED (Liste) | wie oben | [HM-09](../Module/HM-09_Status-LED.md) | RS-07 LED 3; DS-03 LED 3 |
| LED „Tankfüllstand“ | Status-LED (Liste) | wie oben | [HM-09](../Module/HM-09_Status-LED.md) | RS-07 LED 4; DS-03 LED 4 |
| LED „Tank Klappe“ | Status-LED (Liste) | wie oben | [HM-09](../Module/HM-09_Status-LED.md) | RS-07 LED 5; DS-03 LED 5 |
| LED „Keine Störung“ | Status-LED (Liste) | wie oben; positiv formuliert, „OK“ = keine Störung | [HM-09](../Module/HM-09_Status-LED.md) | RS-07 LED 6; DS-03 LED 6 |
| LED „Kein Alarm“ | Status-LED (Liste) | wie oben; positiv formuliert, „OK“ = kein Alarm | [HM-09](../Module/HM-09_Status-LED.md) | RS-07 LED 7; DS-03 LED 7 |
| Hinweis zur Betriebsbereitschaft | Hinweis-Textfeld (Art Info) | Text sinngemäß: Alle Zustände müssen OK zeigen, damit das Gerät betriebsbereit ist (Handbuch wortgetreu: „Alle LEDs müssen grün sein, damit das Gerät betriebsbereit ist.“, umformuliert, weil Zustand nicht nur über Farbe gelesen werden soll) Der Hinweis nennt das Kriterium in Worten, damit es nicht nur an der Farbe hängt | [HM-27](../Module/HM-27_Hinweis-Textfeld.md) | RS-07 Fließtext „Linker Anzeigebereich“ (RS-07-P06) |
| Überschrift „Aktuelle Temperaturen“ | Gruppenüberschrift | Gruppentitel der Temperaturfelder | [HM-15](../Module/HM-15_Gruppenbereich.md) (Variante Überschrift) | RS-07 Linker Anzeigebereich; DS-03 „Aktuelle Temperaturen:“ |
| Anzeige „Tank“ | Anzeigefeld (Feld, °C) | Ist-Temperatur Tank (Dummy 150 °C) | [HM-11](../Module/HM-11_Anzeigefeld.md) | RS-07 Anzeige „Tank“; DS-03 Wertfeld |
| Anzeige „Verteiler“ | Anzeigefeld (Feld, °C) | Ist-Temperatur Verteiler (Dummy 150 °C) | [HM-11](../Module/HM-11_Anzeigefeld.md) | RS-07 Anzeige „Verteiler“; DS-03 Wertfeld |
| Anzeige „Pistole 1“ | Anzeigefeld (Feld, °C) | Ist-Temperatur Pistole 1 (Dummy 170 °C) | [HM-11](../Module/HM-11_Anzeigefeld.md) | RS-07 Anzeige „Pistole 1“; DS-03 Wertfeld |
| Anzeige „Schlauch 1“ | Anzeigefeld (Feld, °C) | Ist-Temperatur Schlauch 1 (Dummy 160 °C) | [HM-11](../Module/HM-11_Anzeigefeld.md) | RS-07 Anzeige „Schlauch 1“; DS-03 Wertfeld |
| Weitere Zonenanzeigen (Schlauch 2, Pistole 2) | Anzeigefeld (Feld, °C), konfigurationsabhängig | erscheinen im selben 2-Spalten-Raster unter den vier Feldern, wenn das Gerät die Zonen meldet; im Normalfall der Referenz (Bild) ausgeblendet. Bezug: Zonenliste in HS-08 | [HM-11](../Module/HM-11_Anzeigefeld.md) | RS-07 Offener Punkt 6; DS-03 OP-16 (OP-41) |

### Rechtes Panel: Füllsystem (RS-07 Tabelle T10, fünf Zeilen)

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Füllstand Tank | Fortschrittsbalken mit Prozentwert, nur Anzeige | „Zeigt den Füllstand des internen Tanks an. Wenn ein automatisches Nachfüllsystem“ – Satz im Handbuch abgebrochen, nicht ergänzt (OP-35). Dummy 83 %, Füllung neutral, Zahl im Balken | [HM-10](../Module/HM-10_Fortschrittsbalken.md) | RS-07 T10 Zeile 1; DS-03 „Füllstand Tank“ |
| Ziel Füllstand | Eingabefeld mit Schlüsselsymbol, Einheit % | „Nur mit Nachfüllsystem. Fällt der Füllstand, des internen Tank, unter dieses Level wird Granulat vom Nachfüllsystem angefordert.“ (Text als Caption unter dem Feld, Wortlaut der Referenz). Dummy 50 %. Antippen öffnet das Eingabe-Pop-up | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), Pop-up [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | RS-07 T10 Zeile 2; DS-03 „Ziel Füllstand:“ |
| Max Füllzeit | Eingabefeld mit Schlüsselsymbol, Einheit s | „Wird der Ziel Füllstand nicht innerhalb der angegebenen Zeit erreicht, führt das zu einer Störung am Heißleimgerät.“ (Caption, Wortlaut der Referenz). Dummy 60 s | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), Pop-up [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | RS-07 T10 Zeile 3; DS-03 „Max Füllzeit:“ |
| Taste „Füllsystem“ | Zustandstaste (Ein/Aus) | „Aktiviert die Verwendung eines Nachfüllsystems.“ Zustand über Symbol und Wort | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | RS-07 T10 Zeile 4; DS-03 Taste „Füllsystem“ |
| Taste „Manuell“ | Aktionstaste, Auslösung WhilePressed | Handbuch: „Fordert das Nachfüllen des Tanks an, solange die Taste betätigt wird.“ (Schreibweise „Manuel“ im Handbuch, Beschriftung im Bild „Manuell“.) Aktiv nur während der Berührung; kein Ein/Aus-Zustand | [HM-07](../Module/HM-07_Aktionstaste.md) (Auslösemodus `WhilePressed`: aktiv, solange berührt; siehe [HM-07](../Module/HM-07_Aktionstaste.md), OP-57) | RS-07 T10 Zeile 5; DS-03 Taste „Manuell“ (rot) |

## Verwendete Module (IDs)

[HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md), [HM-07](../Module/HM-07_Aktionstaste.md), [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md), [HM-09](../Module/HM-09_Status-LED.md), [HM-10](../Module/HM-10_Fortschrittsbalken.md), [HM-11](../Module/HM-11_Anzeigefeld.md), [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](../Module/HM-13_Eingabe-Pop-up.md), [HM-14](../Module/HM-14_Popup-Rahmen.md) (trägt HM-13), [HM-15](../Module/HM-15_Gruppenbereich.md), [HM-27](../Module/HM-27_Hinweis-Textfeld.md).

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

- **Zustandstasten** (Heizungen, Standby, Pumpe, Zeitschaltuhr, Füllsystem; [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md)): Aus = `Brush.Button.Normal`, `Icon.State.Off` und Wort „Aus“; Ein = `Brush.Button.Active`, `Icon.State.On` und Wort „Ein“, neutral und nicht grün (Designsystem Abschnitt 5, A-31). Die Farben des Entwurfs und der Referenz (grün, hellgrün, rot) entfallen (OP-14). Nach dem Antippen zeigt die Taste „Ausstehend“ (gestrichelte Kontur, `Icon.State.Pending`, Text „Wird gesetzt“), bis das Gerät den Zustand zurückmeldet; kommt keine Rückmeldung, wechselt die Taste in den Fehlerzustand mit Symbol und Text.
- **Heizungen:** schaltet Geräte-, Schlauch- und Düsenheizungen gemeinsam. **Standby:** alle Solltemperaturen werden um den Wert „Globale StandBy Temperatur Delta“ ([HS-08](HS-08_Heissleim-Parameter.md)) reduziert. **Zeitschaltuhr:** aktiviert nur den Zeitplan des Geräts; er läuft unabhängig von der SPS, solange das Gerät eingeschaltet ist (Handbuch RS-10). Wechselwirkungen zwischen Heizungen, Standby und Pumpe sind nicht beschrieben und werden nicht erfunden (OP-46).
- **Betriebsbereitschaft:** Das Gerät ist betriebsbereit, wenn alle sieben LEDs „OK“ zeigen (Handbuch). Jede LED zeigt Zustand als Kreis mit Haken und Wort „OK“, bei Abweichung als Kreuz mit Wort „Fehler“, bei fehlender Kommunikation als „---“ ([HM-09](../Module/HM-09_Status-LED.md)). Die Einzelbedeutung der LEDs ist nicht beschrieben (OP-46).
- **Füllsystem:** „Ziel Füllstand“ und „Max Füllzeit“ sind nur mit Nachfüllsystem relevant. Wird der Ziel Füllstand nicht innerhalb der Max Füllzeit erreicht, entsteht eine Störung am Heißleimgerät: Annahme: die LED „Keine Störung“ wechselt auf „Fehler“, die Meldezeile zeigt die Meldung (die genaue Zuordnung nennt die Quelle nicht).
- **Taste „Manuell“:** fordert Nachfüllen nur an, solange sie berührt wird; dazu nutzt sie den Auslösemodus `WhilePressed` von [HM-07](../Module/HM-07_Aktionstaste.md) (aktiv ab Berühren, Ende beim Loslassen); die genaue Darstellung und der zweite Kanal während der Berührung (Wort „Läuft“ mit `Icon.State.On`) sind dort festgelegt bzw. nachzuziehen. Eine Sperre bei ausgeschaltetem Füllsystem ist nicht belegt und wird nicht angenommen.
- **Eingabe:** Antippen von „Ziel Füllstand“ oder „Max Füllzeit“ öffnet das Eingabe-Pop-up ([HM-13](../Module/HM-13_Eingabe-Pop-up.md) im [HM-14](../Module/HM-14_Popup-Rahmen.md)) mit vorbelegtem Wert; „Übernehmen“ ist nur bei gültigem Wert aktiv, „Abbrechen“ verwirft. Wertebereiche sind Dummy-Grenzen (OP-28).
- **Berechtigungen:** Die zwei Eingabefelder tragen das Schlüsselsymbol (`Icon.Key`, Rolle vorhanden) bzw. `Icon.Lock` (Rolle fehlt, Hinweis „Berechtigung erforderlich: <Rolle>“; das Benutzer-Pop-up öffnet über den Benutzerkreis). Die Tasten tragen in Referenz und Design kein Schlüsselsymbol. Rollenzuordnung ist Dummy (OP-04, OP-25).
- **Sperrzustände:** Tasten und Felder, die der Betriebszustand sperrt, sind deaktiviert (gestrichelte Kontur, `Brush.Text.Disabled`); Tippen nennt den Grund in der Meldezeile (A-28). Konkrete Sperrregeln fehlen in der Quelle.
- **Fehlerfälle:** Kommunikation zum Nordson-Gerät gestört (Annahme, in der Quelle nicht beschrieben): alle Messwerte „---“, LEDs im Zustand „Unbekannt“, Zustandstasten und Eingabefelder deaktiviert. Ungültige Eingabe: Fehlertext mit `Icon.Status.Error` im Eingabe-Pop-up.
- **Navigation und Zurück:** Die Funktionsleisten-Tasten „Temperatur“, „Druck“, „Zeitplan“ führen zu HS-08, HS-09, HS-10 und legen HS-07 auf den Verlaufsstapel. „Zurück“ (Seitenleiste) führt im Verlauf zurück (HS-40, HS-06 oder HS-16). Segment „Zuführungen“ im Brotkrümel springt zu HS-40, „Einstellung“ zu HS-04. Das Hervorheben einer Funktionsleisten-Taste (Referenzbild: „Druck“ hervorgehoben) entfällt, weil HS-07 die Elternseite ist und keine der drei Tasten die aktuelle Seite darstellt.
- **Pop-ups:** Bei offenem Pop-up sind Seitenleiste, Funktionsleiste, Brotkrümel und Seiteninhalt gesperrt (Navigation.md 4.2); Schließen nur über „Abbrechen“, „Übernehmen“ oder Kreuz.

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-07-P01 | Taste „Heizungen“ (RS-07-P01) | Zustandstaste in der linken Spalte; schaltet alle Heizungen von Gerät, Schläuchen und Düse ein/aus; Ein/Aus mit Symbol und Wort | offen |
| HS-07-P02 | Taste „Standby“ und Standardwert (RS-07-P02) | Zustandstaste; Beschreibung „reduziert alle Temperaturen um 56 °C“; optionale Zusatzanzeige „Absenkung“ (Annahme SA-07-1) in °C darunter, Wert aus HS-08 | offen |
| HS-07-P03 | Taste „Pumpe“ (RS-07-P03) | Zustandstaste; schaltet die Förderpumpe ein/aus | offen |
| HS-07-P04 | Taste „Zeitschaltuhr“ (RS-07-P04, DS-03-P02) | Zustandstaste unten in der linken Spalte; aktiviert nur den internen Zeitplan, öffnet keine Seite | offen |
| HS-07-P05 | Status-LEDs (RS-07-P05, DS-03-P03) | sieben LEDs in der Reihenfolge Bereitschaft, Temperatur, Füllsystem, Tankfüllstand, Tank Klappe, Keine Störung, Kein Alarm; jede mit Symbol, Wort und Beschriftung | offen |
| HS-07-P06 | Betriebsbereitschaft (RS-07-P06) | Hinweis (sinngemäß „Alle Zustände müssen OK zeigen …“) in Textform sichtbar; Zustand nie nur über Farbe | offen |
| HS-07-P07 | Aktuelle Temperaturen (RS-07-P07, DS-03-P04) | vier nicht editierbare Felder Tank, Verteiler, Pistole 1, Schlauch 1 mit Einheit °C und Beispielwerten 150/150/170/160 °C; weitere Zonen konfigurationsabhängig | offen |
| HS-07-P08 | Füllstand Tank (RS-07-P08, DS-03-P05) | Balken mit Prozentwert im Balken (Beispiel 83 %); Füllung neutral | offen |
| HS-07-P09 | Ziel Füllstand (RS-07-P09, DS-03-P06) | Eingabefeld % mit Schlüsselsymbol; Caption „Nur mit Nachfüllsystem …“ | offen |
| HS-07-P10 | Max Füllzeit (RS-07-P10, DS-03-P06) | Eingabefeld s mit Schlüsselsymbol; Caption zur Störung bei Nichterreichen des Ziel Füllstands | offen |
| HS-07-P11 | Taste „Füllsystem“ (RS-07-P11) | Zustandstaste; aktiviert die Verwendung eines Nachfüllsystems | offen |
| HS-07-P12 | Taste „Manuell“ (RS-07-P12) | Aktionstaste; fordert Nachfüllen nur an, solange sie berührt wird; Auslösemodus `WhilePressed` aus HM-07, zweiter Kanal während der Berührung (Wort und Symbol) | offen |
| HS-07-P13 | Navigation zu HS-08/09/10 (RS-07-P13, DS-03-P08) | Funktionsleiste zeigt „Temperatur“, „Druck“, „Zeitplan“ und öffnet HS-08, HS-09, HS-10 | offen |
| HS-07-P14 | Brotkrümel (RS-07-P14, DS-03-P01) | „Einstellung › Zuführungen › Heißleim“; die ersten beiden Segmente führen zu HS-04 und HS-40 (Abweichung vom Referenzpfad „… › Zuführung Karton › Heißleimgerät“ ist in Navigation.md begründet) | offen |
| HS-07-P15 | Rahmen (RS-07-P15, DS-03-P09) | Seitenleiste, Kopfzeile, Meldezeile, Kennzahlen und Funktionsleiste vorhanden; „Produktion“, „Einstellungen“, „Zurück“ in der Seitenleiste | offen |
| HS-07-P16 | Quellbezug (RS-07-P16) | RS-07 mit Bild RS-07_01 und DS-03 sind im Kopf der Seite verlinkt; jede Zeile von T9 und T10 steht in der Elemente-Tabelle | offen |
| HS-07-P17 | Überschriften (DS-03-P10) | „Status“ und „Aktuelle Temperaturen“ als Gruppenüberschriften ohne Unterstreichung | offen |
| HS-07-P18 | Aufteilung | Inhaltsbereich 2 : 7 : 3 Spalten von 12; keine festen Pixelpositionen | offen |
| HS-07-P19 | Zweiter Kanal (Designsystem 5) | Ein/Aus, LED-Zustand, Ausstehend, Sperre und Schlüssel/Schloss haben Symbol oder Text zusätzlich zur Farbe | offen |
| HS-07-P20 | Farbe nur Status (DSY-P02) | Ein-Zustand der Tasten neutral; keine rote Eingabewertschrift, kein gelber Schlüssel | offen |
| HS-07-P21 | Touch (DSY-P04) | alle Tasten und Felder mindestens `Size.Touch.Min`, Standard `Size.Touch.Default` hoch; Abstand mindestens `Size.Touch.Gap` | offen |
| HS-07-P22 | Tokens (DSY-P06, DSY-P07) | keine Hex- oder Pixelwerte und keine festen Texte im XAML; Beschriftungen, Wörter und Captions aus `.resx` | offen |
| HS-07-P23 | Eingabe-Pop-up und Modal (Navigation 4.2) | Antippen eines Eingabefelds mit Rolle öffnet HM-13 im HM-14; Seite dahinter gesperrt, kein Schließen durch Antippen außerhalb | offen |
| HS-07-P24 | Berechtigung | ohne Rolle: Schloss und Hinweis „Berechtigung erforderlich“, kein Pop-up | offen |

## Offene Punkte

- OP-14: Bedeutung der Tastenfarben und Ein/Aus-Zustände; zwei „Zeitplan“-Tasten (Annahme: getrennt geführt, Zustandstaste „Zeitschaltuhr“ im Arbeitsbereich, Navigationstaste „Zeitplan“ in der Funktionsleiste).
- OP-04, OP-25: Berechtigung (Schlüssel, Schloss, Rollen).
- OP-15, OP-36: Abgleich Design/Referenz; Zugang zu den Unterseiten HS-08 bis HS-10 ist abgeleitet.
- OP-16, OP-41: Anzahl weiterer Pistolen und Schläuche, konfigurationsabhängig.
- OP-20: Zwischenseite „Zuführungen“ (HS-40, Annahme).
- OP-26: Wirbel-Symbol und Schloss der Referenz (entfallen bzw. in den Benutzerkreis überführt).
- OP-28: Wertebereiche und Standardwerte (Ziel Füllstand, Max Füllzeit).
- OP-35: abgebrochener Satz im Handbuch bei „Füllstand Tank“ (nicht ergänzt).
- OP-39, OP-46: fehlende Zustände (Aus, Fehler der LEDs und Tasten), Einzelbedeutung der LEDs, Wechselwirkungen der Schalter.
