# RM-12 – Kennzahl-Kachel

## Funktion

Symbol links und weißes Wertfeld rechts für eine Kennzahl; schwarz (nur Anzeige) oder mit bedienbarem Symbol (Antippen öffnet ein Pop-up). RS-01: 8 Kennzahlen laut Tabelle T1 (Geschwindigkeit Soll mit rotem Tacho → [RS-03](../Seiten/RS-03_Maschinengeschwindigkeit.md), Geschwindigkeit Ist, Aktuelle Produktion → [RS-02](../Seiten/RS-02_Produktionszaehler.md), Letzte Produktion, Maschinenwinkel, Letztes Gewicht mit Index unten rechts, Mittelwert mit Umschalter, Standardabweichung). RS-02: Gesamte Produktion, Betriebsstunden. RS-13/RS-14: Netto, Brutto, Live, Mittelwert, Standardabweichung, Leistung Ist, Gut-Packungen, T1 %, Schlecht Packungen, Anzahl.

Entsprechung im Design: [DM-08](../../01_Design-Analyse/Module/DM-08_Kennzahl-Kachel.md).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Symbol | Grafik | – | Tacho, Uhr, Winkel, Waage, X̄, S, grüner/roter Kreis u. a. (RS-01_02 bis RS-01_09, RS-13_02 bis RS-13_14) |
| Wert | Zahl | 1/min, Stk, °, g, %, h:m:s | Beispiele: 50, 874183, 140, 0,0, 250,2, 0,3 (RS-01); 235,1 g, 114,6 1/min, 874794, 1528 (RS-13) |
| Index | Zahl klein, unten rechts, optional | – | RS-01 „Letztes Gewicht“: Nummer des Dosierers/der Waage |
| Bedienbar | Boolean | – | Symbol antippbar: Geschwindigkeit Soll (RS-03), Aktuelle Produktion (RS-02) |
| Schriftfarbe | Farbcode | – | rot bei Sollwert (RS-01), sonst schwarz |
| Zugehöriger Umschalter | Modul | – | RS-01 „Mittelwert“ mit [RM-10](RM-10_Umschalter-Taste.md) „Fortlaufend/Stichprobe“ |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Anzeige | Symbol und Wert |
| Bedienbar | Symbol öffnet ein Pop-up ([RM-13](RM-13_Pop-up-Rahmen.md)) |
| Index | kleine Zahl unten rechts |

## Verwendet auf Seiten (IDs)

- [RS-01](../Seiten/RS-01_Produktion.md) – Produktion (8 Nennungen in den Elementtabellen)
- [RS-02](../Seiten/RS-02_Produktionszaehler.md) – Produktionszähler (Pop-up) (2 Nennungen in den Elementtabellen)
- [RS-13](../Seiten/RS-13_Kontrollwaage.md) – Kontrollwaage (12 Nennungen in den Elementtabellen)
- [RS-14](../Seiten/RS-14_Einzelgewichte.md) – Einzelgewichte (3 Nennungen in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-12-P01 | RS-01 | 8 Kennzahlen laut Tabelle T1, Symbole und Werte wie im Bild; Maschinenwinkel und Index | offen |
| RM-12-P02 | RS-13 | Netto, Brutto, Live, Mittelwert, Standardabweichung, Leistung Ist, Zähler laut Tabelle 19 | offen |
| RM-12-P03 | Bedienbare Symbole | Tacho (RS-03) und Uhr (RS-02) öffnen die Pop-ups | offen |
| RM-12-P04 | Einheit | Einheit je Kachel erkennbar | offen |
| RM-12-P05 | Verwendet-auf-Liste | alle 4 genannten Seiten verlinken zurück auf RM-12; Links lösen auf | offen |
