# RM-28 – Leimspuren-Grafik

## Funktion

Grafik eines aufgefalteten Kartonzuschnitts (Draufsicht) mit 18 Winkelfeldern für die Leimspuren auf [RS-06](../Seiten/RS-06_Zufuehrung-Karton.md). Jede Spur hat Anfangs- und Endpunkt bezogen auf den Maschinenwinkel; die Felder sind [RM-05](RM-05_Eingabefeld-mit-Schluesselsymbol.md). Vier Reihen: 5, 4, 5, 4 Felder.

Entsprechung im Design: [DM-22](../../01_Design-Analyse/Module/DM-22_Leimspuren-Grafik.md).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Reihe 1 (obere Klappen) | 5 Felder | ° | 200, 205, 205, 205, 205 |
| Reihe 2 | 4 Felder | ° | 225, 225, 225, 225 |
| Reihe 3 | 5 Felder | ° | 300, 310, 310, 310, 310 |
| Reihe 4 (untere Klappen) | 4 Felder | ° | 325, 329, 329, 329 |
| Zuordnung Anfang/Ende | – | – | im Handbuch nicht beschrieben (offener Punkt RS-06) |
| Maschinenwinkel | Anzeige im Nachbarbereich | ° | 140 °, siehe RM-07 |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Normal | alle 18 Felder mit Schlüssel, rote Schrift |
| Ungültig | nicht beschrieben |

## Verwendet auf Seiten (IDs)

- [RS-06](../Seiten/RS-06_Zufuehrung-Karton.md) – Zuführung Karton (1 Nennung in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-28-P01 | Felder | 18 Felder in den vier Reihen (5/4/5/4) | offen |
| RM-28-P02 | Werte | Bildwerte stimmen | offen |
| RM-28-P03 | Einheit | Grad, im Bild nur klein erkennbar | offen |
| RM-28-P04 | Verwendet-auf-Liste | alle 1 genannten Seiten verlinken zurück auf RM-28; Links lösen auf | offen |
