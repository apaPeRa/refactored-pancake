# RM-17 – Gewichtskorrektur-Tabelle

## Funktion

Eingabetabelle für Stützstellen der Dosierkorrektur: zwei Blöcke mit je zehn Zeilen und den Spalten „SOLL“ und „IST“ (insgesamt 20 Wertepaare), daneben die Tasten „Gewichtsanpassung“ und „Dosierer Auslösen manuell“ sowie das Feld „Sollgewicht“. Handbuch: „Diese Seite dient der Korrektur und Feinabstimmung der Dosiergenauigkeit von Schneckendosierern.“ Ablauf in vier Schritten: Sollgewicht einstellen, Dosierer manuell auslösen, Soll und gemessenes Ist eintragen, Gewichtsanpassung berechnen. RS-18 und RS-21 sind textgleich.

Entsprechung im Design: keine (Element nur in der Referenz).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| SOLL | Zahl (20 Felder) | g | Bild RS-21 links: 18,00 g, 22,00 g, …; rechter Block 10 × 0,00 g; leere Felder bleiben unberücksichtigt |
| IST | Zahl (20 Felder) | g | Bild RS-21 links: 20,00 g, 24,00 g, …; rechter Block 10 × 0,00 g |
| Sollgewicht | Zahl mit Schlüssel | g | Bild RS-18: 250,4 g; Zielgewicht der manuellen Dosierung |
| Taste „Gewichtsanpassung“ | Aktionstaste | – | berechnet die Korrekturkennlinie aus den Stützstellen |
| Taste „Dosierer Auslösen manuell“ | Aktionstaste | – | dosiert eine Probe mit dem Sollgewicht |
| Anzahl Stützstellen | Zahl | Stk | empfohlen mindestens 3, besser 5 bis 8, gleichmäßig über den Gewichtsbereich (Handbuch) |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Leer | unbenutzte Felder 0,00 g; werden nicht berücksichtigt |
| Berechnet | Korrekturkennlinie erstellt; Rückmeldung nicht beschrieben |
| Zu wenige Stützstellen | Prüfung nicht beschrieben |

## Verwendet auf Seiten (IDs)

- [RS-18](../Seiten/RS-18_Gewichtskorrektur-Schliessmaschine.md) – Gewichtskorrektur (Schließmaschine) (1 Nennung in den Elementtabellen)
- [RS-21](../Seiten/RS-21_Gewichtskorrektur.md) – Gewichtskorrektur (Nachdosierer) (7 Nennungen in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-17-P01 | Spalten | SOLL/IST zweimal je 10 Zeilen | offen |
| RM-17-P02 | Ablauf | 4 Schritte und 4 Hinweise entsprechen dem Handbuch | offen |
| RM-17-P03 | Wiederverwendung | RS-18 (Schließmaschine) und RS-21 (Nachdosierer) identisch | offen |
| RM-17-P04 | Rückmeldung | Anzeige nach „Gewichtsanpassung“ im neuen HMI festlegen (nicht beschrieben) | offen |
| RM-17-P05 | Verwendet-auf-Liste | alle 2 genannten Seiten verlinken zurück auf RM-17; Links lösen auf | offen |
