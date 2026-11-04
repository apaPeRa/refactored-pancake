# RS-07 – Heißleim Nordson

- Quelle: Handbuch `src_Data/Referenz/Referenz.docx`, Kapitel 7 „Heißleim Nordson“ (Zweck, Seitenübersicht, Funktionsbeschreibung mit Tabellen T9 und T10); Bild [RS-07_01](../Medien/RS-07_01.png) (`image15.png`). Außerdem Tabelle T8 / Zeile „Heißleimgerät“ aus RS-06 (Zugang).
- Navigationspfad: Einstellung › Zuführung Karton › Heißleimgerät (Herkunft Handbuch; Zugang über die Taste „Heißleimgerät“ auf RS-06). Seitentitel im Bild: „Heißleim Zuführung“.

## Zweck

Wortgetreu (Handbuch): „Diese Seite dient der Bedienung des Nordson Heißleimgeräts über das HMI. Alle Einstellungen können auch direkt am Nordson-Gerät vorgenommen werden. Für eine detaillierte Beschreibung von Einstellungen und Statusanzeigen siehe bitte das Nordson-Handbuch.“

## Aufbau (Bereiche, Layout)

Bild [RS-07_01](../Medien/RS-07_01.png) (1024 × 768, altes HMI), von oben nach unten:

1. **Kopfzeile:** links Logo „APA-TEC GmbH – Automation and Packaging Technology“; Mitte Seitentitel „Heißleim Zuführung“ (unterstrichen, fett); rechts daneben ein Symbol (stilisierter Wirbel/Spirale, im Handbuch nicht erklärt); ganz rechts Uhrzeit „13:01:52“ mit Datum „12.05.2025“.
2. **Obere Schaltflächen (blauer Hintergrund):** vier große Tasten in einer Reihe: „Heizungen“ (grün), „Standby“ (rot), „Pumpe“ (grün) links nebeneinander; „Zeitschaltuhr“ (rot) rechts außen mit Abstand.
3. **Linker Anzeigebereich (hellblaues Feld):**
   - Links Überschrift „Status“ (unterstrichen) mit sieben runden grünen LEDs und den Beschriftungen: „Bereitschaft“, „Temperatur“, „Füllsystem“, „Tankfüllstand“, „Tank Klappe“, „Keine Störung“, „Kein Alarm“.
   - Rechts daneben Überschrift „Aktuelle Temperaturen:“ mit vier weißen Anzeigefeldern in zwei Spalten: „Tank:“ 150 °C, „Verteiler:“ 150 °C, „Pistole 1:“ 170 °C, „Schlauch 1:“ 160 °C.
4. **Rechter Anzeigebereich (hellblaues Feld):** „Füllstand Tank“ als waagerechter Balken (grün gefüllt, Beschriftung „83%“); darunter „Ziel Füllstand:“ Eingabefeld „50 %“ (rote Schrift, gelbes Schlüsselsymbol oben rechts am Feld); „Max Füllzeit:“ Eingabefeld „60 s“ (rote Schrift, Schlüsselsymbol); unten zwei Tasten „Füllsystem“ (grün) und „Manuell“ (rot).
5. **Meldezeile:** roter Balken über die volle Breite mit Text „*450* Palettierung nicht bereit“ (Beispielmeldung).
6. **Untere Funktionsleiste:** von links nach rechts: „Temperatur“ (Regler-Symbol), „Druck“ (Symbol Kreis mit „P“, mit hellblauem Rahmen/Unterstrich hervorgehoben), „Zeitschaltuhr“ (Kalender-Uhr-Symbol), gelbes geschlossenes Vorhängeschloss (Mitte, ohne Beschriftung), „Produktion“ (Haus-Symbol), „Einstellungen“ (Zahnrad-Symbol), „Zurück“ (Rücktaste-Symbol).

## Elemente

Alle Zeilen der Handbuchtabellen T9 (Obere Schaltflächen) und T10 (Rechter Anzeigebereich) sowie der Textbereich „Linker Anzeigebereich“ und die im Bild sichtbaren Elemente.

### Tabelle T9 – Obere Schaltflächen (4 Zeilen)

| Element | Typ | Funktion (wortgetreu) | verwendetes Modul |
|---|---|---|---|
| Heizungen | Taste (Umschalter, im Bild grün) | „Schaltet alle Heizungen des Geräts, der Schläuche und der Düse ein oder aus.“ | Modulkandidat: Umschalter-Taste (Ein/Aus mit Farbzustand) |
| Standby | Taste (Umschalter, im Bild rot) | „Reduziert alle eingestellten Temperaturen um 56 °C (Standardwert).“ Einheit °C, Standardwert 56 °C (entspricht „Globale StandBy Temperatur Delta“ auf [RS-08](RS-08_Heissleim-Parameter.md)). | Modulkandidat: Umschalter-Taste (Ein/Aus mit Farbzustand) |
| Pumpe | Taste (Umschalter, im Bild grün) | „Schaltet die Förderpumpe ein oder aus.“ | Modulkandidat: Umschalter-Taste (Ein/Aus mit Farbzustand) |
| Zeitschaltuhr | Taste (Umschalter, im Bild rot) | „Aktiviert den internen Zeitplan des Nordson-Geräts.“ (Schaltet nur den Zeitplan ein; die Zeitplanseite selbst ist [RS-10](RS-10_Zeitschaltuhr.md).) | Modulkandidat: Umschalter-Taste (Ein/Aus mit Farbzustand) |

### Linker Anzeigebereich (Fließtext, keine Tabelle)

Wortgetreu: „Zeigt Betriebszustände und Temperaturen verschiedener Komponenten. Alle LEDs müssen grün sein, damit das Gerät betriebsbereit ist.“

| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Status-LED „Bereitschaft“ | LED (im Bild grün) | Betriebszustand; muss grün sein (Handbuch: alle LEDs). Einzelbedeutung im Handbuch nicht erklärt. | Modulkandidat: Statusliste (LED + Text) |
| Status-LED „Temperatur“ | LED (grün) | wie oben | Modulkandidat: Statusliste (LED + Text) |
| Status-LED „Füllsystem“ | LED (grün) | wie oben | Modulkandidat: Statusliste (LED + Text) |
| Status-LED „Tankfüllstand“ | LED (grün) | wie oben | Modulkandidat: Statusliste (LED + Text) |
| Status-LED „Tank Klappe“ | LED (grün) | wie oben | Modulkandidat: Statusliste (LED + Text) |
| Status-LED „Keine Störung“ | LED (grün) | wie oben | Modulkandidat: Statusliste (LED + Text) |
| Status-LED „Kein Alarm“ | LED (grün) | wie oben | Modulkandidat: Statusliste (LED + Text) |
| Anzeige „Tank“ (Aktuelle Temperaturen) | Anzeigefeld, nur lesend, im Bild „150 °C“ | Ist-Temperatur Tank (nur aus Bild und Überschrift „Aktuelle Temperaturen:“ ableitbar) | Modulkandidat: Anzeigefeld mit Einheit |
| Anzeige „Verteiler“ | Anzeigefeld, „150 °C“ | Ist-Temperatur Verteiler | Modulkandidat: Anzeigefeld mit Einheit |
| Anzeige „Pistole 1“ | Anzeigefeld, „170 °C“ | Ist-Temperatur Pistole 1 | Modulkandidat: Anzeigefeld mit Einheit |
| Anzeige „Schlauch 1“ | Anzeigefeld, „160 °C“ | Ist-Temperatur Schlauch 1 | Modulkandidat: Anzeigefeld mit Einheit |

### Tabelle T10 – Rechter Anzeigebereich (5 Zeilen)

| Element | Typ | Funktion (wortgetreu) | verwendetes Modul |
|---|---|---|---|
| Füllstand Tank | Balkenanzeige mit Prozentwert (Bild: 83 %), nur lesend | „Zeigt den Füllstand des internen Tanks an. Wenn ein automatisches Nachfüllsystem“ (Satz im Handbuch abgebrochen, siehe Offene Punkte) | Modulkandidat: Füllstandsbalken |
| Ziel Füllstand | Eingabefeld mit Schlüsselsymbol, Einheit % (Bild: 50 %) | „Nur mit Nachfüllsystem. Fällt der Füllstand, des internen Tank, unter dieses Level wird Granulat vom Nachfüllsystem angefordert.“ | Modulkandidat: Eingabefeld mit Schlüsselsymbol |
| Max Füllzeit | Eingabefeld mit Schlüsselsymbol, Einheit s (Bild: 60 s) | „Wird der Ziel Füllstand nicht innerhalb der angegebenen Zeit erreicht, führt das zu einer Störung am Heißleimgerät.“ | Modulkandidat: Eingabefeld mit Schlüsselsymbol |
| Taste Füllsystem | Taste (Umschalter, im Bild grün) | „Aktiviert die Verwendung eines Nachfüllsystems.“ | Modulkandidat: Umschalter-Taste (Ein/Aus mit Farbzustand) |
| Taste Manuel | Taste (im Bild „Manuell“, rot), Tipp-/Haltetaste | „Fordert das Nachfüllen des Tanks an, solange die Taste betätigt wird.“ (Schreibweise „Manuel“ im Handbuch; Beschriftung im Bild „Manuell“.) | Modulkandidat: Haltetaste (solange gedrückt) |

### Rahmenelemente im Bild (nicht in den Handbuchtabellen)

| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Kopfzeile (Logo, Titel „Heißleim Zuführung“, Symbol, Uhrzeit/Datum) | Rahmen | Seitenkopf | Modulkandidat: Kopfzeile |
| Meldezeile | Rahmen, roter Balken mit Text | Zeigt aktuelle Meldung (Bild: „*450* Palettierung nicht bereit“); Antippen öffnet laut Referenz-Übersicht [RS-38](RS-38_Meldeanzeige.md) | Modulkandidat: Meldezeile |
| Funktionsleiste „Temperatur“ | Navigationstaste | im Handbuch nicht beschrieben; Ziel nach Namen vermutlich [RS-08](RS-08_Heissleim-Parameter.md) | Modulkandidat: Funktionsleiste unten |
| Funktionsleiste „Druck“ | Navigationstaste | im Handbuch nicht beschrieben; Ziel nach Namen vermutlich [RS-09](RS-09_Heissleim-Druck.md) | Modulkandidat: Funktionsleiste unten |
| Funktionsleiste „Zeitschaltuhr“ | Navigationstaste | im Handbuch nicht beschrieben; Ziel nach Namen vermutlich [RS-10](RS-10_Zeitschaltuhr.md) | Modulkandidat: Funktionsleiste unten |
| Vorhängeschloss (gelb, geschlossen) | Symbol/Taste ohne Beschriftung | im Handbuch nicht erklärt (vermutlich Bediener-/Rechtestatus) | Modulkandidat: Funktionsleiste unten |
| Funktionsleiste „Produktion“ / „Einstellungen“ / „Zurück“ | Navigationstasten | Wechsel zu [RS-01](RS-01_Produktion.md) / [RS-04](RS-04_Einstellungen.md) / eine Ebene zurück (Funktion nur aus Beschriftung und Symbol) | Modulkandidat: Funktionsleiste unten |

### Bilder

| Bild | Beschreibung |
|---|---|
| [RS-07_01.png](../Medien/RS-07_01.png) | Gesamtansicht der Seite „Heißleim Zuführung“ wie unter „Aufbau“ beschrieben (Handbuchabschnitt „Seitenübersicht“). Zahlenfelder: Tank 150 °C, Verteiler 150 °C, Pistole 1 170 °C, Schlauch 1 160 °C, Füllstand 83 %, Ziel Füllstand 50 %, Max Füllzeit 60 s. |

## Verwendete Module (IDs)

Noch keine RM-IDs vergeben. Modulkandidatn: Kopfzeile, Meldezeile, Funktionsleiste unten, Umschalter-Taste (Ein/Aus mit Farbzustand), Statusliste (LED + Text), Anzeigefeld mit Einheit, Füllstandsbalken, Eingabefeld mit Schlüsselsymbol, Haltetaste.

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

- **Umschalter-Tasten** (Heizungen, Standby, Pumpe, Zeitschaltuhr, Füllsystem): im Bild grün = Zustand an/aktiv? bzw. rot = aus/inaktiv. Die Farbbedeutung wird im Handbuch nicht erklärt; Beispielzustand im Bild: Heizungen, Pumpe und Füllsystem grün; Standby, Zeitschaltuhr, Manuell rot.
- **Heizungen:** schaltet Geräte-, Schlauch- und Düsenheizungen gemeinsam ein/aus.
- **Standby:** Temperaturabsenkung um 56 °C (Standardwert); der Wert ist auf RS-08 als „Globale StandBy Temperatur Delta“ einstellbar.
- **Zeitschaltuhr:** aktiviert nur den internen Zeitplan des Geräts. Der Zeitplan selbst wird auf RS-10 gepflegt. Laut Handbuch (RS-10 Zweck) läuft der Zeitplan unabhängig von der SPS, solange das Gerät eingeschaltet ist.
- **Betriebsbereitschaft:** „Alle LEDs müssen grün sein, damit das Gerät betriebsbereit ist.“
- **Nachfüllsystem:** „Ziel Füllstand“ und „Max Füllzeit“ nur mit Nachfüllsystem relevant. Wird Ziel Füllstand nicht in „Max Füllzeit“ erreicht: Störung am Heißleimgerät.
- **Taste Manuell:** Nachfüllanforderung nur, solange die Taste betätigt wird.
- **Berechtigungen:** Felder „Ziel Füllstand“ und „Max Füllzeit“ tragen ein Schlüsselsymbol (Eingabe geschützt/berechtigungsabhängig, Bedeutung im Handbuch nicht erklärt). Das gelbe Vorhängeschloss in der Funktionsleiste ist ebenfalls nicht erklärt. Die Eingabe erfolgt vermutlich über ein Eingabe-Pop-up (Modulkandidat: Eingabe-Pop-up), im Handbuch nicht beschrieben.
- **Pop-ups:** im Handbuch keine beschrieben.
- **Unterseiten:** RS-08, RS-09, RS-10 (Zugang laut Referenz-Übersicht abgeleitet, im Bild über die Funktionsleiste „Temperatur“, „Druck“, „Zeitschaltuhr“ erreichbar).
- **Fehlerfälle:** Störung am Heißleimgerät bei Überschreitung der Max Füllzeit; im Handbuch keine weiteren Fehlertexte.

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RS-07-P01 | Taste „Heizungen“ vorhanden und Beschreibung | Taste vorhanden; schaltet alle Heizungen des Geräts, der Schläuche und der Düse ein/aus | offen |
| RS-07-P02 | Taste „Standby“ und Standardwert | Taste vorhanden; reduziert alle Temperaturen um 56 °C (Standardwert) | offen |
| RS-07-P03 | Taste „Pumpe“ | Taste vorhanden; schaltet die Förderpumpe ein/aus | offen |
| RS-07-P04 | Taste „Zeitschaltuhr“ | Taste vorhanden; aktiviert den internen Zeitplan des Nordson-Geräts | offen |
| RS-07-P05 | Linker Anzeigebereich: Status-LEDs | Sieben LEDs mit den Texten Bereitschaft, Temperatur, Füllsystem, Tankfüllstand, Tank Klappe, Keine Störung, Kein Alarm | offen |
| RS-07-P06 | Betriebsbereitschaft | Hinweis „Alle LEDs müssen grün sein, damit das Gerät betriebsbereit ist“ wird abgebildet (Zustand nicht nur über Farbe) | offen |
| RS-07-P07 | Aktuelle Temperaturen | Vier Anzeigen: Tank, Verteiler, Pistole 1, Schlauch 1 (Einheit °C, nur lesend) | offen |
| RS-07-P08 | Füllstand Tank | Füllstandsbalken mit Prozentwert vorhanden | offen |
| RS-07-P09 | Ziel Füllstand | Eingabefeld (Einheit %) mit Schlüsselsymbol; Text „Nur mit Nachfüllsystem …“ | offen |
| RS-07-P10 | Max Füllzeit | Eingabefeld (Einheit s) mit Schlüsselsymbol; Störung bei Nichterreichen des Ziel Füllstands | offen |
| RS-07-P11 | Taste Füllsystem | Aktiviert die Verwendung eines Nachfüllsystems | offen |
| RS-07-P12 | Taste Manuell | Fordert Nachfüllen an, solange betätigt | offen |
| RS-07-P13 | Navigation zu RS-08/09/10 | Von RS-07 aus sind Temperatur (RS-08), Druck (RS-09) und Zeitschaltuhr (RS-10) erreichbar | offen |
| RS-07-P14 | Brotkrümel | „Einstellung › Zuführung Karton › Heißleimgerät“ | offen |
| RS-07-P15 | Rahmen | Kopfzeile, Meldezeile, Funktionsleiste (Produktion, Einstellungen, Zurück) vorhanden | offen |
| RS-07-P16 | Medienbezug | [RS-07_01](../Medien/RS-07_01.png) ist verlinkt und beschrieben | offen |

## Offene Punkte

1. **Abgebrochener Satz:** T10 „Füllstand Tank“ endet im Handbuch mit „Wenn ein automatisches Nachfüllsystem“ (Satz unvollständig, auch im XML so vorhanden). Annahme: Aussage unbekannt, nicht ergänzt.
2. **Farbbedeutung** der Umschalter-Tasten (grün/rot) und der Textfarbe rot der Eingabefelder nicht beschrieben.
3. **Schlüsselsymbol und Vorhängeschloss:** Berechtigungskonzept (Wer darf was?) nicht beschrieben; Wertebereiche und Standardwerte für Ziel Füllstand (Bild: 50 %) und Max Füllzeit (Bild: 60 s) fehlen. Die Bildwerte sind nur Beispielwerte.
4. **Einzelbedeutung der sieben Status-LEDs** nicht erklärt; Fehlerzustand (Farbe/Text) nicht beschrieben.
5. **Zugang zu RS-08/09/10:** Handbuch beschreibt die Funktionsleisten-Tasten „Temperatur“, „Druck“, „Zeitschaltuhr“ nicht; Ziele nur aus Namen abgeleitet. Die Taste „Heißleimgerät“ auf RS-06 ist die dokumentierte Einsprungstelle.
6. **Anzeigen Pistole/Schlauch:** Bild zeigt nur Pistole 1 und Schlauch 1; RS-08 hat auch Schlauch 2 und Pistole 2. Ob die Anzeige variabel ist (nach Anzahl Zonen), ist nicht beschrieben.
7. Symbol rechts neben dem Titel (Wirbel/Spirale) nicht erklärt.
