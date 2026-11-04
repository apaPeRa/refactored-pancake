# RS-08 – Heißleim Parameter

- Quelle: Handbuch `src_Data/Referenz/Referenz.docx`, Kapitel 8 „Heißleim Parameter“ (Zweck, Seitenübersicht, Funktionsbeschreibung: Oberer Bereich mit Tabelle T11, Hauptbereich als Fließtext); Bild [RS-08_01](../Medien/RS-08_01.png) (`image16.png`).
- Navigationspfad: Einstellung › Zuführung Karton › Heißleimgerät › Parameter (Herkunft „abgeleitet“, Zugang im Handbuch nicht beschrieben). Seitentitel im Bild: „Heißleim Parameter“. Im Bild von [RS-07](RS-07_Heissleim-Nordson.md) die Funktionsleistentaste „Temperatur“ (Ziel nach Name vermutet).

## Zweck

Wortgetreu: „Auf der Seite Heißleim Parameter werden globale Temperatureinstellungen festgelegt und die Temperaturzonen konfiguriert.“

## Aufbau (Bereiche, Layout)

Bild [RS-08_01](../Medien/RS-08_01.png) (1024 × 768):

1. **Kopfzeile:** Logo APA-TEC links, Titel „Heißleim Parameter“ (unterstrichen), Wirbel-Symbol, Uhrzeit „13:01:55“, Datum „12.05.2025“.
2. **Oberer Bereich (blauer Hintergrund), zwei Spalten mit je zwei Eingabefeldern:** links „Globale StandBy Temperatur Delta:“ 56 °C und „Bereitschaft Verzögerung:“ 0 s; rechts „Übertemperatur Delta:“ 15 °C und „Untertemperatur Delta:“ 25 °C. Alle vier Felder weiß, rote Schrift, gelbes Schlüsselsymbol oben rechts.
3. **Hauptbereich (zwei hellblaue Felder nebeneinander):**
   - Linkes Feld: Spaltenköpfe „Soll:“, „Ist:“, „Status:“ (unterstrichen). Zeilen: „Tank:“, „Schlauch 1:“, „Pistole 1:“, „Schlauch 2:“, „Pistole 2:“. Pro Zeile: Soll-Eingabefeld (rote Schrift, Schlüsselsymbol), Ist-Anzeige (schwarze Schrift) und eine Statustaste.
   - Rechtes Feld: gleiche Spaltenköpfe, eine Zeile „Verteiler:“.
4. **Meldezeile:** roter Balken „*450* Palettierung nicht bereit“.
5. **Untere Funktionsleiste:** links leer; rechts gelbes geschlossenes Vorhängeschloss, „Produktion“ (Haus-Symbol), „Einstellungen“ (Zahnrad-Symbol), „Zurück“ (Rücktaste-Symbol). Die Tasten „Temperatur“, „Druck“, „Zeitschaltuhr“ aus RS-07 fehlen hier.

## Elemente

### Tabelle T11 – Oberer Bereich (4 Zeilen)

| Element | Typ | Funktion (wortgetreu) | verwendetes Modul |
|---|---|---|---|
| Globale Standby Temperatur Delta | Eingabefeld mit Schlüsselsymbol, Einheit °C (Bild: 56 °C; Standardwert 56 °C laut RS-07 „Standby“) | „Wert um den alle Temperaturen reduziert werden, wenn das Heißleimgerät in Standby versetzt wird.“ (Bildbeschriftung „Globale StandBy Temperatur Delta“) | Modulkandidat: Eingabefeld mit Schlüsselsymbol |
| Bereitschaft Verzögerung | Eingabefeld mit Schlüsselsymbol, Einheit s (Bild: 0 s) | „Sind alle Bedingungen für einen Betrieb erfüllt, wird erst nach Ablauf der Zeit das Bereitsignal gesendet.“ | Modulkandidat: Eingabefeld mit Schlüsselsymbol |
| Übertemperatur Delta | Eingabefeld mit Schlüsselsymbol, Einheit °C (Bild: 15 °C) | „Ist eine Temperatur um diesen Betrag höher als die angegebene Solltemperatur wird die Bereitschaft zurückgenommen.“ | Modulkandidat: Eingabefeld mit Schlüsselsymbol |
| Untertemperatur Delta | Eingabefeld mit Schlüsselsymbol, Einheit °C (Bild: 25 °C) | „Ist eine Temperatur um diesen Betrag niedriger als die angegebene Solltemperatur wird die Bereitschaft zurückgenommen.“ | Modulkandidat: Eingabefeld mit Schlüsselsymbol |

### Hauptbereich (Fließtext, keine Tabelle)

Wortgetreu: „Alle vorhandenen Zonen des Heißleimgeräts werden hier aufgelistet. Für jede Zone kann eine Solltemperatur festgelegt werden. Die Spalte Ist zeigt die aktuelle Temperatur der Zone an. Über die Tasten in der Spalte Status kann jeden Zone abgewählt werden.“

Zonen laut Bild (Beispielzustand):

| Zone | Soll (Eingabe, Schlüssel) | Ist (Anzeige) | Statustaste (Bild) | verwendetes Modul |
|---|---|---|---|---|
| Tank | 150 °C | 150 °C | „Ausschalten“ (grün) | Modulkandidat: Temperaturzonen-Zeile (Soll, Ist, Status-Taste) |
| Schlauch 1 | 160 °C | 160 °C | „Ausschalten“ (grün) | Modulkandidat: Temperaturzonen-Zeile |
| Pistole 1 | 170 °C | 170 °C | „Ausschalten“ (grün) | Modulkandidat: Temperaturzonen-Zeile |
| Schlauch 2 | 100 °C | 0 °C | „Einschalten“ (rot) | Modulkandidat: Temperaturzonen-Zeile |
| Pistole 2 | 100 °C | 0 °C | „Einschalten“ (rot) | Modulkandidat: Temperaturzonen-Zeile |
| Verteiler (rechtes Feld) | 150 °C | 150 °C | „Ausschalten“ (grün) | Modulkandidat: Temperaturzonen-Zeile |

Spalten: „Soll:“ (Eingabe), „Ist:“ (Anzeige), „Status:“ (Taste, Beschriftung wechselt zwischen „Ausschalten“ und „Einschalten“).

### Rahmenelemente

| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Kopfzeile | Rahmen | Logo, Titel, Symbol, Uhrzeit/Datum | Modulkandidat: Kopfzeile |
| Meldezeile | Rahmen | Meldung (Bild: „*450* Palettierung nicht bereit“) | Modulkandidat: Meldezeile |
| Vorhängeschloss (gelb) | Symbol | im Handbuch nicht erklärt | Modulkandidat: Funktionsleiste unten |
| Produktion / Einstellungen / Zurück | Navigationstasten | Funktion nur aus Beschriftung/Symbol | Modulkandidat: Funktionsleiste unten |

### Bilder

| Bild | Beschreibung |
|---|---|
| [RS-08_01.png](../Medien/RS-08_01.png) | Gesamtansicht „Heißleim Parameter“ wie unter „Aufbau“: oben vier Delta-/Verzögerungsfelder, darunter zwei Zonenfelder mit Soll/Ist/Status (Tank, Schlauch 1, Pistole 1, Schlauch 2, Pistole 2 links; Verteiler rechts), unten Meldezeile und Leiste ohne Temperatur/Druck/Zeitschaltuhr-Tasten. |

## Verwendete Module (IDs)

Noch keine RM-IDs. Modulkandidaten: Kopfzeile, Meldezeile, Funktionsleiste unten, Eingabefeld mit Schlüsselsymbol, Temperaturzonen-Zeile (Soll/Ist/Status-Taste), Anzeigefeld mit Einheit, Eingabe-Pop-up.

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

- **Statustaste je Zone:** schaltet die Zone ab bzw. wieder an („abgewählt“). Zustand im Bild: grüne Taste „Ausschalten“ bei aktiver Zone, rote Taste „Einschalten“ bei abgewählter Zone (Ist 0 °C).
- **Bereitschaft:** wird zurückgenommen, wenn eine Temperatur um „Übertemperatur Delta“ über oder um „Untertemperatur Delta“ unter der Solltemperatur liegt. Bereitsignal erst nach Ablauf von „Bereitschaft Verzögerung“.
- **Standby:** alle Temperaturen um „Globale Standby Temperatur Delta“ reduziert.
- **Berechtigungen:** Eingabefelder mit Schlüsselsymbol (Bedeutung nicht erklärt); Ist-Werte ohne Schlüssel (nur Anzeige).
- **Pop-ups:** keine beschrieben (Werteingabe vermutlich über Eingabe-Pop-up, nicht beschrieben).
- **Fehlerfälle:** nur die genannte Rücknahme der Bereitschaft.

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RS-08-P01 | Feld „Globale Standby Temperatur Delta“ | Eingabefeld °C mit Schlüsselsymbol; Beschreibung wie im Handbuch; Bildwert 56 °C | offen |
| RS-08-P02 | Feld „Bereitschaft Verzögerung“ | Eingabefeld s mit Schlüsselsymbol; Bildwert 0 s | offen |
| RS-08-P03 | Feld „Übertemperatur Delta“ | Eingabefeld °C mit Schlüsselsymbol; Bildwert 15 °C | offen |
| RS-08-P04 | Feld „Untertemperatur Delta“ | Eingabefeld °C mit Schlüsselsymbol; Bildwert 25 °C | offen |
| RS-08-P05 | Zonenliste | Sechs Zonen: Tank, Schlauch 1, Pistole 1, Schlauch 2, Pistole 2, Verteiler; je Soll (Eingabe), Ist (Anzeige), Status (Taste) | offen |
| RS-08-P06 | Spalte Status | Taste je Zone wählt die Zone ab/an; Beschriftung „Ausschalten“/„Einschalten“; Zustand nicht nur über Farbe erkennbar | offen |
| RS-08-P07 | Spalte Ist | Zeigt die aktuelle Temperatur der Zone (nur Anzeige) | offen |
| RS-08-P08 | Bereitschafts-Logik | Beschreibungen zu Über-/Untertemperatur und Verzögerung sind unverändert dokumentiert | offen |
| RS-08-P09 | Brotkrümel | „Einstellung › Zuführung Karton › Heißleimgerät › Parameter“ | offen |
| RS-08-P10 | Rückweg | Tasten Produktion, Einstellungen, Zurück vorhanden | offen |
| RS-08-P11 | Medienbezug | [RS-08_01](../Medien/RS-08_01.png) verlinkt und beschrieben | offen |

## Offene Punkte

1. **Zugang** zur Seite im Handbuch nicht beschrieben (abgeleitet aus Funktionsleiste „Temperatur“ auf RS-07).
2. **Wertebereiche und Standardwerte** (außer Standby 56 °C) fehlen; Bildwerte sind nur Beispiele.
3. **„Bereitschaft Verzögerung“:** Einheit im Handbuch nicht genannt; Bild zeigt „0 s“.
4. **Zonenanzahl/Namen:** Handbuch: „Alle vorhandenen Zonen“; Anzahl und Namen ggf. gerätabhängig, nicht beschrieben (Bild: Tank, Schlauch 1/2, Pistole 1/2, Verteiler).
5. **Aufteilung** der Zonen in zwei Felder (links/rechts) im Handbuch nicht begründet; Bedeutung der Farben und des Schlüssel-/Vorhängeschloss-Symbols nicht erklärt.
6. **Verhalten der Statustaste** bei Standby/Aus (Ist 0 °C bei abgewählter Zone) nicht beschrieben.
