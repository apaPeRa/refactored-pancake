# RM-29 – Packungsregister-Grafik

## Funktion

Grafische Darstellung der Maschinenstationen von [RS-28](../Seiten/RS-28_Packungsregister.md): Stationsfelder in Reihen (linker Block 6 Felder, Drehstern mit 12 Armen, rechte Reihe Nr. 40 bis mindestens 61, vertikale Spalte 9 Felder), Legende links unten und horizontale Bildlaufleiste. Antippen eines Felds ändert den Zustand der Station manuell.

Entsprechung im Design: keine (Element nur in der Referenz).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Stationsfeld | Zustandsfeld | – | 5 Zustände, Farbe plus Legendentext |
| Zustand grau | Aufzählung | – | an dieser Position keine Packung |
| Zustand rot | Aufzählung | – | Schlechtpackung, wird ausgestoßen |
| Zustand gelb | Aufzählung | – | Packung vorhanden (gut) |
| Zustand orange | Aufzählung | – | Packung mit Produkt befüllt |
| Zustand grün | Aufzählung | – | Packung von der Endkontrollwaage als in Ordnung erkannt |
| Stationsnummer | Zahl | – | nummerierte Reihe ab 40 |
| Bildlauf | horizontal | – | seitliches Scrollen |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Zustandswechsel | Antippen ändert den Zustand manuell; Zustandsfolge nicht beschrieben |
| Legende | fünf Einträge entsprechend Tabelle T39 |

## Verwendet auf Seiten (IDs)

- [RS-28](../Seiten/RS-28_Packungsregister.md) – Packungsregister (11 Nennungen in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-29-P01 | Zustände | fünf Zustände mit Legende | offen |
| RM-29-P02 | Struktur | Blöcke, Stern und Spalte wie im Bild | offen |
| RM-29-P03 | Bedienung | Antippen wirkt; Rückmeldung unbekannt | offen |
| RM-29-P04 | Verwendet-auf-Liste | alle 1 genannten Seiten verlinken zurück auf RM-29; Links lösen auf | offen |
