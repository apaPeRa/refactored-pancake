# RM-36 – Wertegitter

## Funktion

Gitter aus 10 Zeilen × 5 Spalten = 50 Zellen in [RS-14](../Seiten/RS-14_Einzelgewichte.md): je Zelle Status-LED und weißes Gewichtsfeld; ein Pfeil markiert das zuletzt erfasste Gewicht. Sortierung von oben nach unten und links nach rechts. Umschalter „Einzel / Fortlaufend“ (Einzel: manuelle Stichprobe, „Start“ löscht alle Werte; Fortlaufend: nach 50 Werten wird überschrieben).

Entsprechung im Design: keine (Element nur in der Referenz).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Gewicht | Zahl (50) | g | Bild Z1: 235,7 / 235,0 / 236,1 / 234,0 / 235,2 … |
| LED | Status-LED | – | grün = gutes Gewicht, grau = schlechtes Gewicht |
| Positionspfeil | Symbol | – | zeigt auf das zuletzt erfasste Gewicht |
| Modus | Umschalter | – | Einzel / Fortlaufend |
| Start | Taste | – | startet Messdurchlauf (im Bild nicht sichtbar) |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Fortlaufend | automatisch, nach 50 Werten überschrieben |
| Einzel | Stichprobe, Start löscht |
| Leere Zelle | nicht beschrieben |
| Hinweis neues HMI | gut/schlecht nicht nur über LED-Farbe: Text/Symbol ergänzen (Konzeptanforderung, siehe RM-08-P05) |

## Verwendet auf Seiten (IDs)

- [RS-14](../Seiten/RS-14_Einzelgewichte.md) – Einzelgewichte (1 Nennung in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-36-P01 | Zellen | 10 × 5 = 50 | offen |
| RM-36-P02 | LED und Pfeil | grün/grau, Pfeil am letzten Wert | offen |
| RM-36-P03 | Kennzahlen | Standardabweichung, Mittelwert, Anzahl als RM-12 | offen |
| RM-36-P04 | Zustand nicht nur über Farbe | LED-Zustand zusätzlich über Text/Symbol (Konzeptanforderung; Referenz zeigt nur Farbe), vgl. RM-08-P05 | offen |
| RM-36-P05 | Verwendet-auf-Liste | alle 1 genannten Seiten verlinken zurück auf RM-36; Links lösen auf | offen |
