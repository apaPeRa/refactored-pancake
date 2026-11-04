# DM-21 – Titelzeile mit Verschiebesymbol

## Funktion
Blaue Zeile über die Inhaltsbreite mit zwei Werten und Symbol am rechten Rand. Zeigt Soll- und Istgewicht „KW“ (Abkürzung nicht erklärt, OP-17).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
| Name | Typ | Einheit | Wertebereich |
|---|---|---|---|
| Sollgewicht KW | Zahl | g | Bild 235 |
| Letztes Gewicht KW | Zahl | g | Bild 238 |
| Detail-Symbol | Symboltaste | – | vier Pfeile in Rahmen, Funktion nicht beschrieben (OP-17) |

## Zustände und Darstellung
| Zustand | Darstellung |
|---|---|
| Normal | Blau `#4472C4`, Text weiß, Format „Sollgewicht KW: 235g \| Letztes Gewicht KW: 238g“ (Entwurfsschreibweise ohne Leerzeichen vor „g“) |
| Abweichung Soll/Ist | im Bild nicht dargestellt; Annahme: Text oder Symbol, nicht nur Farbe |
| Symbol gedrückt | im Bild nicht dargestellt |

Antippbarkeit der Zeile unklar. Symbol soll ein Touch-Ziel von mindestens 48 px erhalten.

## Verwendet auf Seiten (IDs)
- [DS-04](../Seiten/DS-04_Dosierer.md) – Dosierer

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DM-21-P01 | Text | „Sollgewicht KW: 235g \| Letztes Gewicht KW: 238g“ | offen |
| DM-21-P02 | Symbol | vier Pfeile rechts in der Zeile | offen |
| DM-21-P03 | Lage | über den drei Dosierer-Karten, volle Breite | offen |
