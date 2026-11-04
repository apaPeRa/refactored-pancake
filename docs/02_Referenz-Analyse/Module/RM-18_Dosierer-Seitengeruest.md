# RM-18 – Dosierer-Seitengerüst

## Funktion

Gemeinsames Seitengerüst der Dosierer-Seiten [RS-11](../Seiten/RS-11_Hauptdosierer-1-und-2.md) (Hauptdosierer 1 und 2, eine Seite mit Umschaltung) und [RS-19](../Seiten/RS-19_Nachdosierer.md) (Nachdosierer). Kompositionsmodul: setzt die Bausteine [RM-05](RM-05_Eingabefeld-mit-Schluesselsymbol.md) (Parameterfelder), [RM-08](RM-08_Status-LED.md) (Füllstand Trichter oben/unten), [RM-09](RM-09_Fortschrittsbalken.md) (Auslastung), [RM-10](RM-10_Umschalter-Taste.md) (Querschnecke, Rührer, Regulierung aktiv), [RM-11](RM-11_Aktionstaste.md) (Manuell, Entleeren, Eichdosierung, Seitenlinks) und [RM-04](RM-04_Blaettertasten.md) zusammen. Handbuch RS-11: „Die Seite Hauptdosierer beinhaltet die Parameter, die Anwahlen und den Status der beiden Schneckendosierer.“ Varianten als Parameter, keine Kopie.

Entsprechung im Design: [DM-20](../../01_Design-Analyse/Module/DM-20_Dosierer-Karte.md).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Soll (Hauptdosierer) | Zahl | % | Anteil des Zielgewichts; Bild 52 % |
| Soll (Nachdosierer) | Zahl | g | Zielgewicht; Bild 250 g |
| Soll absolut (nur Hauptdosierer) | Zahl, berechnet, schwarz mit Schlüssel | g | Bild 122 g |
| Max. Nachgabe (nur Nachdosierer) | Zahl | g | Bild 50 g; Obergrenze an zu dosierendem Produkt |
| Aktuelle Nachgabe (nur Nachdosierer) | Zahl, berechnet | g | Bild 13 g |
| Eichdosierung Umdrehungen | Zahl | – | Bild 4 (HD), 5 (ND) |
| Eichdosierung | Zahl | g | Bild 137,50 g (HD), 18,50 g (ND) |
| Regulierung Ist | Zahl | g | Bild 0,00 g (HD), 4,81 g (ND) |
| Schnecke Drehzahl | Zahl | 1/min | Bild 2800 |
| Rührer | Zahl | % | Bild 20 % (HD), 30 % (ND) |
| Nachlauf Rührer | Zahl | s | Bild 0 s |
| Querschnecke | Zahl | % | Bild 20 % (HD), 30 % (ND) |
| Füllstand Trichter oben/unten | 2 Status-LEDs | – | Bild oben grau, unten rot |
| Auslastung | Fortschrittsbalken | % | Bild 91 % gelb (HD), 73 % grün (ND) |
| Tastenreihe | 5 bis 7 Tasten | – | Querschnecke, Rührer, Manuell, Entleeren, Eichdosierung, Regulierung aktiv; HD zusätzlich „Einstellung Regulierung“ |
| Funktionsleiste links | Seitentasten | – | RS-11: Motorparameter, »; RS-19: Gewichtskorrektur, Motorparameter, Regulierung |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Variante Hauptdosierer | Seite mit Umschaltung HD1 / HD2 über Pfeiltasten |
| Variante Nachdosierer | Felder Max./Aktuelle Nachgabe statt Soll absolut |
| Zustände der Bausteine | siehe die verlinkten Module (grün/grau, rot bei Trichter unten) |
| Fehler | Ist die Fehlmenge einer Packung größer als „Max. Nachgabe“ …: siehe Handbuch RS-19 |

## Verwendet auf Seiten (IDs)

- [RS-11](../Seiten/RS-11_Hauptdosierer-1-und-2.md) – Hauptdosierer 1 & 2 (Gesamtmodul der Seite, Abschnitt „Verwendete Module“)
- [RS-19](../Seiten/RS-19_Nachdosierer.md) – Nachdosierer (Gesamtmodul der Seite, Abschnitt „Verwendete Module“)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-18-P01 | Felder | HD 9 Felder + 2 LEDs + Balken; ND 10 Felder + 2 LEDs + Balken (RS-11, RS-19) | offen |
| RM-18-P02 | Soll | HD in %, ND in g | offen |
| RM-18-P03 | Tasten | 7 Schaltflächen laut Tabelle T15 (RS-11), 6 + 3 Navigationstasten (RS-19) | offen |
| RM-18-P04 | Wiederverwendung | RS-11 und RS-19 nutzen dasselbe Gerüst; Unterschiede nur als Parameter | offen |
| RM-18-P05 | Motorparameter/Gewichtskorrektur | Ziele RS-12/RS-20 bzw. RS-21 erreichbar | offen |
| RM-18-P06 | Verwendet-auf-Liste | alle 2 genannten Seiten verlinken zurück auf RM-18; Links lösen auf | offen |
