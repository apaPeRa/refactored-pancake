# DS-03 – Heißleim
- Quelle: `src_Data/Design/Seite_Heissleim.png`   - Navigationspfad: Einstellung › Zuführungen › Heißleim

## Zweck
Bedienung und Überwachung der Heißleimanlage: Heizung, Standby und Pumpe schalten, Zustände und Temperaturen ansehen, Tank-Füllstand überwachen und Füllparameter setzen, Füllsystem und manuellen Betrieb auslösen.

## Aufbau (Bereiche, Layout)
1. Rahmen wie in der [Design-Dokumentation](../Design-Dokumentation.md), Abschnitt 2; Brotkrümel mit 3 Segmenten.
2. Linke graue Spalte (schmal): Tasten „Heizung“, „Standby“, „Pumpe“ oben, „Zeitplan“ unten.
3. Mittlerer blauer Bereich (`#AFC3DE`, blauer Rand): links Spalte „Status“ mit 7 LEDs, rechts Block „Aktuelle Temperaturen:“ mit 4 Wertfeldern (2 × 2).
4. Rechter blauer Bereich: Füllstand Tank, zwei Eingabefelder, unten zwei Tasten.
5. Funktionsleiste: Tasten „Temperatur“, „Druck“, „Zeitplan“.

## Elemente
| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Rahmen (Benutzer, Navigationssymbole, Logo, Meldezeile, Betriebsart, Uhr, Kennzahlen 112 1/min, 245°) | Rahmen | wie DS-01 | DM-01 bis DM-06, DM-08 |
| Brotkrümel „Einstellung“, „Zuführungen“, „Heißleim“ | Navigation | Pfad, 3 Segmente | DM-07 |
| Taste „Heizung“ (grün) | Zustandstaste | Heizung ein/aus (vermutet) | DM-19 |
| Taste „Standby“ (grün) | Zustandstaste | Standby | DM-19 |
| Taste „Pumpe“ (grün) | Zustandstaste | Pumpe | DM-19 |
| Taste „Zeitplan“ (grün, links unten) | Zustandstaste | Zeitplan der Heizung (vermutet) | DM-19 |
| Überschrift „Status“ (unterstrichen) | Text | Gruppentitel | DM-11 |
| LED „Bereitschaft“ | Status-LED (grün) | Zustand | DM-14 |
| LED „Temperatur“ | Status-LED (grün) | Zustand | DM-14 |
| LED „Füllsystem“ | Status-LED (grün) | Zustand | DM-14 |
| LED „Tankfüllstand“ | Status-LED (grün) | Zustand | DM-14 |
| LED „Tank Klappe“ | Status-LED (grün) | Zustand | DM-14 |
| LED „Keine Störung“ | Status-LED (grün) | Zustand | DM-14 |
| LED „Kein Alarm“ | Status-LED (grün) | Zustand | DM-14 |
| Überschrift „Aktuelle Temperaturen:“ (unterstrichen) | Text | Gruppentitel | DM-11 |
| „Tank:“ / „150 °C“ | Wertfeld (weiß) | Anzeige | DM-16 |
| „Verteiler:“ / „150 °C“ | Wertfeld | Anzeige | DM-16 |
| „Pistole 1:“ / „170 °C“ | Wertfeld | Anzeige | DM-16 |
| „Schlauch 1:“ / „160 °C“ | Wertfeld | Anzeige | DM-16 |
| „Füllstand Tank“ / Balken „83%“ (grün) | Fortschrittsbalken | Füllstand | DM-18 |
| „Ziel Füllstand:“ / „50 %“ (rot, Schlüsselsymbol gelb) | Eingabefeld mit Schlüssel | Sollwert, berechtigungspflichtig | DM-17 |
| „Max Füllzeit:“ / „60 s“ (rot, Schlüsselsymbol gelb) | Eingabefeld mit Schlüssel | Sollwert, berechtigungspflichtig | DM-17 |
| Taste „Füllsystem“ (hellgrün) | Zustandstaste | Füllsystem | DM-19 |
| Taste „Manuell“ (rot) | Zustandstaste | manueller Betrieb | DM-19 |
| Funktionsleiste | Leiste | Container | DM-09 |
| Taste „Temperatur“ (grau) | Funktionstaste | Ansicht/Unterseite Temperatur (vermutet) | DM-10 |
| Taste „Druck“ (grau) | Funktionstaste | Ansicht/Unterseite Druck | DM-10 |
| Taste „Zeitplan“ (grau) | Funktionstaste | Ansicht/Unterseite Zeitplan | DM-10 |

## Verwendete Module (IDs)
DM-01 bis DM-09 (Rahmen), DM-10, DM-11, DM-14, DM-16, DM-17, DM-18, DM-19.

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- Alle 7 LEDs grün. Die Zustände aus / Warnung / Alarm sind nicht dargestellt (Beschriftungen „Keine Störung“, „Kein Alarm“ sind positiv formuliert, grün = erfüllt).
- Die Tasten links sind grün; ob grün „aktiv“ bedeutet, ist nicht erklärt. Zustände ein/aus fehlen im Bild.
- „Füllsystem“ (hellgrün) und „Manuell“ (rot): Bedeutung der Farben nicht erklärt; „Manuell“ in Rot könnte „aktiv“ oder „Gefahr“ bedeuten.
- Eingabefelder mit Schlüssel: nur mit Berechtigung änderbar; Pop-up-Eingabe (Zahlenfeld) nicht abgebildet.
- Füllstand 83 % liegt über dem Ziel 50 %; kein Schwellwert/Farbwechsel erkennbar.
- Doppelter Name „Zeitplan“: Taste links (grün) und Taste in der Funktionsleiste (grau); Unterschied nicht beschrieben.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DS-03-P01 | Brotkrümel | Einstellung › Zuführungen › Heißleim | offen |
| DS-03-P02 | Tasten linke Spalte | Heizung, Standby, Pumpe (oben), Zeitplan (unten) | offen |
| DS-03-P03 | Status-LEDs | 7 LEDs in Reihenfolge: Bereitschaft, Temperatur, Füllsystem, Tankfüllstand, Tank Klappe, Keine Störung, Kein Alarm; alle grün | offen |
| DS-03-P04 | Temperaturwerte | Tank 150 °C, Verteiler 150 °C, Pistole 1 170 °C, Schlauch 1 160 °C | offen |
| DS-03-P05 | Füllstand | Balken 83 % | offen |
| DS-03-P06 | Eingabefelder | Ziel Füllstand 50 %, Max Füllzeit 60 s, je mit Schlüsselsymbol | offen |
| DS-03-P07 | Tasten rechts unten | Füllsystem (grün), Manuell (rot) | offen |
| DS-03-P08 | Funktionsleiste | Temperatur, Druck, Zeitplan | offen |
| DS-03-P09 | Rahmenwerte | wie DS-01 | offen |
| DS-03-P10 | Überschriften | „Status“ und „Aktuelle Temperaturen:“ (unterstrichen) | offen |

## Offene Punkte
- Bedeutung der Tastenfarben (grün/hellgrün/rot) und Ein-/Aus-Zustände: OP-14.
- Schlüsselsymbol = Berechtigung: OP-04.
- Abgleich mit Referenz (Heißleim Nordson, Parameter, Druck, Zeitschaltuhr): OP-15.
- Weitere Pistolen/Schläuche (nur „Pistole 1“, „Schlauch 1“ sichtbar): OP-16.
- Zwischenseite „Zuführungen“ (mittleres Brotkrümel-Segment) fehlt im Design: OP-20; Unterseiten Temperatur/Druck/Zeitplan ohne Design: OP-07.
- Seitenleisten-Symbole, Antippbarkeit von Brotkrümel: OP-08, OP-21; identische Rahmenwerte: OP-22.
