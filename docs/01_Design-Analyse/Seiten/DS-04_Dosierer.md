# DS-04 – Dosierer
- Quelle: `src_Data/Design/Seite_Dosierer.png`   - Navigationspfad: Einstellung › Dosierer

## Zweck
Übersicht und Bedienung der drei Dosierer (Hauptdosierer 1, Hauptdosierer 2, Nachdosierer): Sollwerte, Trichterfüllstand, Antriebe zu-/abschalten, Auslastung, manuelle Funktionen. Kopfzeile zeigt Sollgewicht und letztes Gewicht.

## Aufbau (Bereiche, Layout)
1. Rahmen wie in der [Design-Dokumentation](../Design-Dokumentation.md), Abschnitt 2; Brotkrümel mit 2 Segmenten.
2. Blaue Titelzeile (`#4472C4`) über die Inhaltsbreite mit Text und Symbol am rechten Rand.
3. Drei gleich breite Karten nebeneinander: zwei graue, die rechte (Nachdosierer) hellblau hinterlegt.
4. Funktionsleiste leer.

## Elemente
| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Rahmen (Benutzer, Navigationssymbole, Logo, Meldezeile, Betriebsart, Uhr, Kennzahlen 112 1/min, 245°) | Rahmen | wie DS-01 | [DM-01](../Module/DM-01_Benutzerkennung.md) bis [DM-06](../Module/DM-06_Uhrzeit-und-Datum.md), [DM-08](../Module/DM-08_Kennzahl-Kachel.md) |
| Brotkrümel „Einstellung“, „Dosierer“ | Navigation | Pfad, 2 Segmente | [DM-07](../Module/DM-07_Brotkruemel-Navigation.md) |
| Titelzeile „Sollgewicht KW: 235g \| Letztes Gewicht KW: 238g“ | Anzeigezeile | Soll- und Istgewicht KW (Abkürzung nicht erklärt) | [DM-21](../Module/DM-21_Titelzeile-mit-Verschiebesymbol.md) |
| Symbol Verschieben/Vollbild (vier Pfeile in Rahmen) rechts in der Titelzeile | Symboltaste | Funktion nicht beschrieben | [DM-21](../Module/DM-21_Titelzeile-mit-Verschiebesymbol.md) |
| Karte „Hauptdosierer 1“ (grau) | Dosierer-Karte | Dosierer 1 | [DM-20](../Module/DM-20_Dosierer-Karte.md) |
| Karte „Hauptdosierer 2“ (grau) | Dosierer-Karte | Dosierer 2 | [DM-20](../Module/DM-20_Dosierer-Karte.md) |
| Karte „Nachdosierer“ (hellblau) | Dosierer-Karte | Nachdosierer | [DM-20](../Module/DM-20_Dosierer-Karte.md) |
| Symbol Verschieben/Vollbild (vier Pfeile) je Karte oben rechts | Symboltaste | öffnet vermutlich Detailseite des Dosierers | [DM-20](../Module/DM-20_Dosierer-Karte.md) |

Je Karte (identische Werte in allen drei Karten):

| Element | Typ | Wert im Bild | verwendetes Modul |
|---|---|---|---|
| „Soll“ / „48 %“ / „entspricht“ / „113 g“ | Beschriftung/Wert | Sollwert in Prozent und Gramm | [DM-15](../Module/DM-15_Beschriftung-Wert-Zeile.md) |
| „Regulierwert“ / „5.30g“ | Beschriftung/Wert | Regulierwert | [DM-15](../Module/DM-15_Beschriftung-Wert-Zeile.md) |
| „Füllstand Trichter“ mit „oben:“ und „unten:“ | 2 Status-LEDs (grün) | Trichterfüllstand oben, unten | [DM-14](../Module/DM-14_Status-LED.md) |
| „Querschnecke“ | Umschalter (ein) | ein/aus | [DM-13](../Module/DM-13_Umschalter.md) |
| „Rührer“ | Umschalter (ein) | ein/aus | [DM-13](../Module/DM-13_Umschalter.md) |
| „Regulierung“ | Umschalter (ein) | ein/aus | [DM-13](../Module/DM-13_Umschalter.md) |
| „Auslastung:“ / Balken „92%“ (gelb) | Fortschrittsbalken | Auslastung | [DM-18](../Module/DM-18_Fortschrittsbalken.md) |
| Taste „Manuell“ (grau) | Funktionstaste | manueller Betrieb (vermutet) | [DM-10](../Module/DM-10_Funktionstaste-grau.md) |
| Taste „Entleeren“ (grau) | Funktionstaste | Dosierer entleeren (vermutet) | [DM-10](../Module/DM-10_Funktionstaste-grau.md) |

| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Funktionsleiste (leer) | Leiste | Container, ohne Tasten | [DM-09](../Module/DM-09_Funktionsleiste.md) |

## Verwendete Module (IDs)
[DM-01](../Module/DM-01_Benutzerkennung.md) bis [DM-09](../Module/DM-09_Funktionsleiste.md) (Rahmen), [DM-10](../Module/DM-10_Funktionstaste-grau.md), [DM-13](../Module/DM-13_Umschalter.md), [DM-14](../Module/DM-14_Status-LED.md), [DM-15](../Module/DM-15_Beschriftung-Wert-Zeile.md), [DM-18](../Module/DM-18_Fortschrittsbalken.md), [DM-20](../Module/DM-20_Dosierer-Karte.md), [DM-21](../Module/DM-21_Titelzeile-mit-Verschiebesymbol.md).

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- Alle Umschalter „ein“, alle Trichter-LEDs grün, Auslastung 92 % in Gelb.
- Die Karte „Nachdosierer“ ist hellblau hinterlegt, die beiden Hauptdosierer-Karten grau. Bedeutung (z. B. ausgewählt/aktiv) nicht erklärt.
- Tasten „Manuell“/„Entleeren“ bei Hauptdosierer 2 mit hellerer Schrift als bei den anderen Karten (mögliche Darstellung „deaktiviert“, nicht sicher).
- Auslastungsbalken gelb bei 92 %: Farbschwellen nicht dokumentiert.
- Keine Schlüsselsymbole; ob Werte auf dieser Seite änderbar sind, ist nicht ersichtlich.
- Pop-ups nicht abgebildet.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DS-04-P01 | Brotkrümel | Einstellung › Dosierer | offen |
| DS-04-P02 | Titelzeile | „Sollgewicht KW: 235g \| Letztes Gewicht KW: 238g“ | offen |
| DS-04-P03 | Karten | drei Karten: Hauptdosierer 1, Hauptdosierer 2, Nachdosierer | offen |
| DS-04-P04 | Sollwerte je Karte | Soll 48 % entspricht 113 g; Regulierwert 5.30g | offen |
| DS-04-P05 | Trichter | je Karte 2 LEDs „oben“, „unten“, grün | offen |
| DS-04-P06 | Umschalter je Karte | Querschnecke, Rührer, Regulierung, alle ein | offen |
| DS-04-P07 | Auslastung | je Karte Balken 92 %, gelb | offen |
| DS-04-P08 | Tasten je Karte | Manuell, Entleeren | offen |
| DS-04-P09 | Hervorhebung | Nachdosierer-Karte hellblau, übrige grau | offen |
| DS-04-P10 | Symbol Verschieben | in Titelzeile und in jeder Karte oben rechts | offen |
| DS-04-P11 | Funktionsleiste | leer | offen |
| DS-04-P12 | Rahmenwerte | wie DS-01 | offen |

## Offene Punkte
- Bedeutung von „KW“ (Titelzeile) und des Verschiebesymbols: OP-17.
- Bedeutung der hellblauen Hervorhebung und deaktivierten Tasten: OP-18.
- Abgleich mit Referenz (Hauptdosierer 1 & 2, Nachdosierer): OP-15.
- Detailseiten der Dosierer (Ziel des Verschiebesymbols) ohne Design: OP-07.
- Seitenleisten-Symbole, Antippbarkeit: OP-08, OP-21; identische Rahmenwerte: OP-22.
