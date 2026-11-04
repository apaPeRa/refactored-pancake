# RM-33 – Motor-Statuszeile

## Funktion

Zeile je Servoantrieb in [RS-39](../Seiten/RS-39_System-und-Antriebsinfos.md) mit Antriebsname und den Werten Diag Code, Strom Aktuell, Strom Max (Klick setzt zurück), Strom Limit (mit Schlüssel, rot) und Meldung. Im Bild vier Antriebe, weitere über zwei Pfeiltasten (hoch/runter) erreichbar.

Entsprechung im Design: keine (Element nur in der Referenz).

Struktur: Zeilen aus [RM-07](RM-07_Anzeigefeld.md) (Anzeigewerte), [RM-05](RM-05_Eingabefeld-mit-Schluesselsymbol.md) (Strom Limit) und Textmeldung; eigen ist nur die Antriebszeile.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Antriebsname | Text | – | Antrieb Zuführung 2MA1, Verschluss Dosierer 1 41MA1, Schnecke Dosierer 1 41MA2, Verschluss Dosierer 2 42MA1 |
| Diag Code | Zahl | – | Bild 0 |
| Strom Aktuell | Zahl | % | 0,0 % |
| Strom Max | Zahl, rücksetzbar | % | -24,4 %, -17,5 %, 20,3 %, -9,6 % |
| Strom Limit | Zahl mit Schlüssel | % | 100,0 % / 500,0 % |
| Meldung | Text | – | Bild „Motorschutz ausgelöst“ |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Normal | Werte angezeigt |
| Fehler | Meldungstext, z. B. „Motorschutz ausgelöst“ (im Bild bei allen vier) |
| Max zurücksetzen | Klick auf Maximalwert |

## Verwendet auf Seiten (IDs)

- [RS-39](../Seiten/RS-39_System-und-Antriebsinfos.md) – System- und Antriebsinfos (1 Nennung in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-33-P01 | Spalten | Diag Code, Strom Aktuell/Max/Limit, Meldung | offen |
| RM-33-P02 | Zurücksetzen | Klick auf Strom Max | offen |
| RM-33-P03 | Strom Limit | Eingabe mit Schlüssel | offen |
| RM-33-P04 | Verwendet-auf-Liste | alle 1 genannten Seiten verlinken zurück auf RM-33; Links lösen auf | offen |
