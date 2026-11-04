# RM-15 – Gruppenrahmen

## Funktion

Hellgraues Panel (oder Bereich) mit Überschrift zur Gruppierung zusammengehöriger Felder. Im Bild: RS-05 „Packstoffrolle“, „Klebestelle“, „Kupplung“; RS-06 „Leimspuren“, „Maschinenwinkel“, „Kompensation“, „Leim kalt“, „Anwahl Spülen“; RS-16 „Auslaufband“, „Kopfleim“, „Rüttlung“; ähnliche Überschriften mit Unterstreichung (RS-07 „Status“, RS-09 „Druckregelung“) sind Textüberschriften ohne Rahmen und gehören nicht zu diesem Modul. Überschrift fett (oben links bzw. zentriert).

Entsprechung im Design: [DM-11](../../01_Design-Analyse/Module/DM-11_Gruppenbereich.md).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Überschrift | Text | – | siehe oben |
| Inhalt | Platzhalter | – | Eingabe-/Anzeigefelder, Tasten, Grafik |
| Anordnung | Aufzählung | – | untereinander (RS-05), Spalten (RS-06, RS-16), Karten (RS-12, siehe [RM-16](RM-16_Motorparameter-Karte.md)) |
| Darstellung der Überschrift | Variante | – | fett, teils unterstrichen |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Normal | grauer Rahmen mit Überschrift |
| Sperre | nicht dargestellt |

## Verwendet auf Seiten (IDs)

- [RS-05](../Seiten/RS-05_Zufuehrung-Papier.md) – Zuführung Papier (1 Nennung in den Elementtabellen)
- [RS-06](../Seiten/RS-06_Zufuehrung-Karton.md) – Zuführung Karton (1 Nennung in den Elementtabellen)
- [RS-16](../Seiten/RS-16_Schliessmaschine.md) – Schließmaschine (genannt im Abschnitt „Verwendete Module“)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-15-P01 | RS-05 | drei Gruppen in der angegebenen Reihenfolge | offen |
| RM-15-P02 | RS-06 | fünf Gruppen in der rechten Spalte bzw. links Leimspuren | offen |
| RM-15-P03 | RS-16 | drei Gruppen mit Überschrift | offen |
| RM-15-P04 | Verwendet-auf-Liste | alle 3 genannten Seiten verlinken zurück auf RM-15; Links lösen auf | offen |
