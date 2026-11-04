# RM-22 – Trend-Diagramm

## Funktion

Liniendiagramm mit geglätteter orangefarbener Kurve und Punktmarkern über Gitternetz. [RS-15](../Seiten/RS-15_Trend.md): „Auf dieser Seite werden die letzten 20 gewogenen Gewichte grafisch dargestellt. Dadurch können Schwankungen besser erkannt werden.“ (RS-13 nennt dagegen „die letzten 50 Packungen“.) Reine Anzeige ohne Bedienelement.

Entsprechung im Design: keine (Element nur in der Referenz).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Datenreihe | Liste von Gewichten | g | 21 Punkte im Bild (-20 … -0), Beispiel 235,8 / 234,0 / 235,3 … |
| Y-Achse | Skala | g | 234,0 bis 236,5 in Schritten von 0,5 (Bild); Autoskalierung unbekannt |
| X-Achse | Index | – | -20 … -1, -0 (= aktuellstes Gewicht, Annahme) |
| Datenbeschriftung | Text je Punkt | g | Format „235,8g“ ohne Leerzeichen |
| Anzahl Werte | Zahl | Stk | Handbuch 20, Bild 21 Positionen, RS-13 nennt 50 |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Normal | Kurve mit Punkten und Beschriftung |
| Zu wenig Daten | nicht dargestellt |

## Verwendet auf Seiten (IDs)

- [RS-15](../Seiten/RS-15_Trend.md) – Trend (4 Nennungen in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-22-P01 | Anzahl | 20 gegenüber 21 gegenüber 50: Abweichung geklärt oder als offener Punkt vermerkt | offen |
| RM-22-P02 | Achsen | Y-Skala 234,0 bis 236,5 g, X -20 bis -0 | offen |
| RM-22-P03 | Beschriftung | Werte je Punkt vorhanden | offen |
| RM-22-P04 | Verwendet-auf-Liste | alle 1 genannten Seiten verlinken zurück auf RM-22; Links lösen auf | offen |
