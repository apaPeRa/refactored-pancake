# RM-34 – Regulierungs-Parameterblock

## Funktion

Parametersatz der automatischen Gewichtsregulierung je Dosierer auf [RS-23](../Seiten/RS-23_Regulierung.md) (zweimal gleich aufgebaut: „Hauptdosierer“ und „Nachdosierer“). Felder: Anzahl Gewichte, Regulierschritt, Toleranz, Regulierung max, Regulierung ist (Eingabe, [RM-05](RM-05_Eingabefeld-mit-Schluesselsymbol.md)), Mittelwert (Anzeige mit Zähler), grüne Taste „Regulierung“ (Ein/Aus) und Tasten „Regulierung −“ / „Regulierung +“.

Entsprechung im Design: keine (Element nur in der Referenz).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Anzahl Gewichte | Zahl | Stk | Bild: HD 10, ND 15 |
| Regulierschritt | Zahl | % | 50,0 % / 50,0 % |
| Toleranz | Zahl | g | 1,0 g (HD), 0,2 g (ND) |
| Regulierung max | Zahl | g | 75,0 g (HD), 20,0 g (ND) |
| Regulierung ist | Zahl | g | 0,0 g (HD) |
| Mittelwert | Zahl, Anzeige, Zähler Stk | g | gleitender Mittelwert über Anzahl Gewichte |
| Regulierung | Umschalter | – | Ein/Aus der automatischen Regulierung, mit Schlüssel |
| Regulierung − / + | 2 Tasten mit Schlüssel | – | manuelle Feineinstellung der Korrektur |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Regulierung ein | grüne Taste (Bild) |
| Berechnung | Zähler zählt gewogene Packungen; bei Erreichen von „Anzahl Gewichte“ wird der Mittelwert ausgewertet |
| Handeingriff | Regulierung −/+ |

## Verwendet auf Seiten (IDs)

- [RS-23](../Seiten/RS-23_Regulierung.md) – Regulierung (1 Nennung in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-34-P01 | Panels | zwei gleich aufgebaute Panels | offen |
| RM-34-P02 | Felder | 5 Eingaben, Mittelwert mit Zähler, 3 Tasten je Panel | offen |
| RM-34-P03 | Einheiten | Stk, %, g | offen |
| RM-34-P04 | Verwendet-auf-Liste | alle 1 genannten Seiten verlinken zurück auf RM-34; Links lösen auf | offen |
