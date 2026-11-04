# RM-26 – Wochen-Zeitplan

## Funktion

Raster aus sieben Tagesspalten (Montag bis Sonntag) für die Zeitschaltuhr des Heißleimgeräts ([RS-10](../Seiten/RS-10_Zeitschaltuhr.md)). Jede Spalte hat eine Kopfzelle mit Plus-Taste (mit Schlüsselsymbol) zum Anlegen einer Phase; Einträge sind klickbar und öffnen [RM-27](RM-27_Zeitplan-Eintrag-Pop-up.md). Heizphase (rot/rosa, „08:00 ein“ … „16:00 aus“), Absenkphase (türkis, „12:00 absenken“, „13:00 aufheizen“) innerhalb einer Heizphase. Der Zeitplan läuft unabhängig von der SPS.

Entsprechung im Design: keine (Element nur in der Referenz).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Tage | 7 Spalten | – | Montag bis Sonntag |
| Plus-Taste | Taste mit Schlüssel | – | legt Heizphase oder Absenkphase an |
| Heizphase | Eintrag mit Start- und Stoppzeit | hh:mm | Start: Aufheizen auf Solltemperatur; Stopp: alle Heizungen aus |
| Absenkphase | Eintrag, innerhalb einer Heizphase | hh:mm | Start: auf reduzierte Temperatur; Stopp: zurück auf Solltemperatur |
| Darstellung | Farbe plus Text | – | Heizphase rot, Absenkphase türkis, Text ein/aus/absenken/aufheizen |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Leer | Spalte nur mit Kopfzelle |
| Phasen vorhanden | Einträge in Zeitfolge |
| Überschneidung/Ungültig | nicht beschrieben |

## Verwendet auf Seiten (IDs)

- [RS-10](../Seiten/RS-10_Zeitschaltuhr.md) – Zeitschaltuhr (4 Nennungen in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-26-P01 | Spalten | 7 Tage Montag bis Sonntag | offen |
| RM-26-P02 | Farbe und Text | Heizphase rot, Absenkphase türkis, beschriftet | offen |
| RM-26-P03 | Anlegen | Plus-Taste öffnet Pop-up für neuen Eintrag | offen |
| RM-26-P04 | Verwendet-auf-Liste | alle 1 genannten Seiten verlinken zurück auf RM-26; Links lösen auf | offen |
