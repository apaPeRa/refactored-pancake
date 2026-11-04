# RM-30 – Tagesbalkendiagramm

## Funktion

Balkendiagramm mit Datumsnavigation für [RS-29](../Seiten/RS-29_Produktionsstatistik.md): Handbuch: „Mit den Pfeiltasten über dem Diagramm kann zwischen den letzten 30 Tagen gewechselt werden. Das Textfeld zeigt das Datum an.“ Balken je Stunde, orange, mit Zahlenwert darüber.

Entsprechung im Design: keine (Element nur in der Referenz).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Datum | Textfeld | – | Bild „heute“ |
| Pfeiltasten | ◄ ► | – | wechseln zwischen den letzten 30 Tagen |
| X-Achse | Uhrzeit | h | 0:00 bis 23:00, schräg beschriftet |
| Y-Achse | Stückzahl | Stk (Annahme) | 0 bis 1800 in Schritten von 200; ohne Titel/Einheit im Bild |
| Balkenwert | Zahl | Stk (Annahme) | Bild: 63, 802, 624, 591, 449, 0, 41, 0, 22 … |
| Anzahl Tage | Zahl | Tage | 30 |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Heute | Datumstext „heute“ |
| Anderer Tag | Datum, Balken des Tages |
| Grenze | älterer als 30 Tage nicht beschrieben |

## Verwendet auf Seiten (IDs)

- [RS-29](../Seiten/RS-29_Produktionsstatistik.md) – Produktionsstatistik (5 Nennungen in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-30-P01 | Achsen | X 0:00 bis 23:00, Y 0 bis 1800 | offen |
| RM-30-P02 | Navigation | Pfeile wechseln den Tag, Datumsfeld folgt | offen |
| RM-30-P03 | Werte | Zahlenwerte über den Balken | offen |
| RM-30-P04 | Verwendet-auf-Liste | alle 1 genannten Seiten verlinken zurück auf RM-30; Links lösen auf | offen |
