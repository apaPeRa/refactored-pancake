# RM-20 – Nocken-Parameterzeile

## Funktion

Zeile zur Einstellung eines Nockenpunkts oder einer Nockenzeit: Beschriftung („Anfang“, „Ende“, „Dauer“) und mehrere Felder nebeneinander. RS-25: je drei Felder Winkel (°), Zeit (ms) und Ergebnis (°); die ersten beiden mit Schlüssel. RS-16 (Kopfleim): „Anfang“ 280 °, „Ende“ 325 °, „Dauer“ 50 ms. Handbuch (RS-25): „Über die Zeiten können Ansprechzeiten der Hardware kompensiert werden. Richtig eingestellt führen Kompensationszeiten zu einem gleichbleibenden Ergebnis unabhängig von der Maschinengeschwindigkeit.“ Felder sind [RM-05](RM-05_Eingabefeld-mit-Schluesselsymbol.md), das Ergebnis [RM-07](RM-07_Anzeigefeld.md).

Entsprechung im Design: keine (Element nur in der Referenz).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Beschriftung | Text | – | Anfang, Ende, Dauer |
| Winkel | Zahl (Eingabe) | ° | Bild RS-25: 330 ° (Anfang), 790 ° (Ende); RS-16: 280 °, 325 °; Bereich nicht angegeben |
| Zeit | Zahl (Eingabe) | ms | Bild RS-25: 50 ms; RS-16 „Dauer“ 50 ms (Einschaltdauer des Ventils) |
| Ergebnis | Zahl, berechnet (nur RS-25) | ° | Nockenposition nach Kompensation; im Handbuch nicht erklärt |
| Bezug | Geber | – | Geber der Nocke (RS-25 „Geber 1GF Hauptantrieb“) |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Normal | Felder mit Schlüssel, rote Schrift |
| Wirksam | Änderungen erst nach „Werte schreiben“ aktiv (RS-25) |
| Dauer zu kurz | RS-16: Wird die Nocke länger als die Einschaltdauer benötigt, wirkt die Dauer (Handbuch) |

## Verwendet auf Seiten (IDs)

- [RS-16](../Seiten/RS-16_Schliessmaschine.md) – Schließmaschine (1 Nennung in den Elementtabellen)
- [RS-25](../Seiten/RS-25_Nocken.md) – Nocken (1 Nennung in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-20-P01 | Felder | RS-25: 6 Eingabefelder + 2 Ergebnisfelder; RS-16: 3 Felder | offen |
| RM-20-P02 | Einheiten | Winkel °, Zeit ms | offen |
| RM-20-P03 | Werte schreiben | Änderung erst nach „Werte schreiben“ aktiv (Taste in RM-11) | offen |
| RM-20-P04 | Verwendet-auf-Liste | alle 2 genannten Seiten verlinken zurück auf RM-20; Links lösen auf | offen |
