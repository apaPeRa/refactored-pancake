# RM-09 – Fortschrittsbalken

## Funktion

Horizontaler Balken mit Prozentwert, mittig im Balken oder daneben, Füllung farbig, Rest grau. Einsatz: Auslastung des Dosierers (RS-11 gelb 91 %, RS-19 grün 73 %), Füllstand Tank (RS-07, grün, 83 %), Zeitablauf der Bildschirmreinigung (RS-24, gelb, 77 %, ohne Beschriftung) und CPU-Auslastung (RS-39, grün ca. 15 %, mit zwei Zahlenfeldern Aktuell/Max.).

Entsprechung im Design: [DM-18](../../01_Design-Analyse/Module/DM-18_Fortschrittsbalken.md).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Wert | Zahl | % | 0 bis 100 (aus der Darstellung) |
| Beschriftung | Text | – | „Auslastung:“, „Füllstand Tank“, „Prozessorauslastung:“; RS-24 ohne Beschriftung |
| Füllfarbe | Farbcode | – | gelb (RS-11, RS-24), grün (RS-07, RS-19, RS-39); Schwellen und Farbwechsel nicht beschrieben |
| Prozenttext | Text | % | mittig im Balken (RS-11, RS-19, RS-24) oder daneben (RS-07: „83%“) |
| Zusatzwerte | Zahlenfelder | % | RS-39: Aktuell und Max. (Max. rücksetzbar) |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Normal | Füllung bis zum Wert, Rest grau |
| Farbwechsel | gelb/grün im Bild; Schwellen nicht beschrieben (Annahme: Zustand zusätzlich über Zahl) |
| Zeitablauf (RS-24) | läuft von 0 % bis 100 %, danach schließt die Seite |

## Verwendet auf Seiten (IDs)

- [RS-07](../Seiten/RS-07_Heissleim-Nordson.md) – Heißleim Nordson (1 Nennung in den Elementtabellen)
- [RS-11](../Seiten/RS-11_Hauptdosierer-1-und-2.md) – Hauptdosierer 1 & 2 (1 Nennung in den Elementtabellen)
- [RS-19](../Seiten/RS-19_Nachdosierer.md) – Nachdosierer (1 Nennung in den Elementtabellen)
- [RS-24](../Seiten/RS-24_Bildschirm-reinigen.md) – Bildschirm reinigen (1 Nennung in den Elementtabellen)
- [RS-39](../Seiten/RS-39_System-und-Antriebsinfos.md) – System- und Antriebsinfos (1 Nennung in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-09-P01 | Auslastung | Prozentwert und Füllung stimmen (RS-11: 91 %, RS-19: 73 %) | offen |
| RM-09-P02 | Füllstand | RS-07: 83 % mit Balken | offen |
| RM-09-P03 | Zeitablauf | RS-24: Balken läuft ab, danach schließt die Seite (laut Handbuch) | offen |
| RM-09-P04 | Zahl neben Farbe | Wert wird als Zahl angezeigt, nicht nur als Farbe | offen |
| RM-09-P05 | Verwendet-auf-Liste | alle 5 genannten Seiten verlinken zurück auf RM-09; Links lösen auf | offen |
