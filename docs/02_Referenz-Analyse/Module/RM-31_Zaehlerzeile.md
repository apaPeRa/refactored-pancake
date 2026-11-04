# RM-31 – Zählerzeile

## Funktion

Zeile aus Beschriftung, Zähler und Zeitpunkt des Zurücksetzens in [RS-02](../Seiten/RS-02_Produktionszaehler.md): „Aktuell“ und „Historie 1“ bis „Historie 12“ (13 Zeilen), Spaltenkopf „Datum / Uhrzeit“. Reset (Haltetaste) schiebt alle Einträge um eine Zeile nach unten. Zähler und Datum sind schreibgeschützte Anzeigefelder ([RM-07](RM-07_Anzeigefeld.md)).

Entsprechung im Design: keine (Element nur in der Referenz).

Struktur: Zeilen aus Beschriftung und Anzeigefeldern ([RM-07](RM-07_Anzeigefeld.md)); eigen ist nur die Historienlogik (Reset schiebt Einträge nach unten).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Zeilenname | Text | – | Aktuell, Historie 1 bis Historie 12 |
| Zähler | Zahl | Stk | Bild: 874183, 7, 7636, 773682, 1, 4622, 225070, 0 … |
| Datum / Uhrzeit | Zeitstempel | tt.mm.jjjj hh:mm:ss | Bild: 09.04.2025 14:55:09 …; leer als „--.--.---- --:--:--“ |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Gefüllt | Zähler und Zeitpunkt |
| Leer | Zähler 0, Platzhalter-Datum |
| Nach Reset | alle Einträge um eine Zeile nach unten |

## Verwendet auf Seiten (IDs)

- [RS-02](../Seiten/RS-02_Produktionszaehler.md) – Produktionszähler (Pop-up) (3 Nennungen in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-31-P01 | Zeilen | 13 Zeilen | offen |
| RM-31-P02 | Reset | Taste halten, Einträge rutschen | offen |
| RM-31-P03 | Platzhalter | leere Historie als „--.--.---- --:--:--“ | offen |
| RM-31-P04 | Verwendet-auf-Liste | alle 1 genannten Seiten verlinken zurück auf RM-31; Links lösen auf | offen |
