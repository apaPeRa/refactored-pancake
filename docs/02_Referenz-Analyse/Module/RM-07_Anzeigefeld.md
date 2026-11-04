# RM-07 – Anzeigefeld

## Funktion

Weißes, schreibgeschütztes Feld mit schwarzer Schrift für Messwerte, Berechnetes und Statustext (kein Schlüsselsymbol). Beschriftung links oder darüber. Varianten als Parameter: mit Einheit, mit Beschriftung, mit Titel, Istwert, mit Zähler, rücksetzbarer Maximalwert, Datum/Uhrzeit, Zeitdauer, Text, große Gewichtsanzeige. Abgrenzung zu [RM-05](RM-05_Eingabefeld-mit-Schluesselsymbol.md) (Eingabe) und [RM-12](RM-12_Kennzahl-Kachel.md) (Kennzahl mit Symbol).

Entsprechung im Design: [DM-16](../../01_Design-Analyse/Module/DM-16_Wertfeld-Anzeige.md), [DM-15](../../01_Design-Analyse/Module/DM-15_Beschriftung-Wert-Zeile.md).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Beschriftung | Text | – | z. B. „Aktueller Druck:“, „Maschinenwinkel“, „Position“ |
| Wert | Zahl, Datum, Zeit oder Text | siehe Einheit | nur Anzeige; Bereich nicht angegeben |
| Einheit | Aufzählung | °C, bar, g, %, °, s, h/m/s, hhh:mm:ss | Beispiele: 150 °C (RS-07), 0,7 bar (RS-09), 140 ° (RS-06), 0 ° (RS-22), 289:38:12 (RS-02), „744 h“ „1 m“ „14 s“ (RS-39), -398.9 g (RS-27, Dezimalpunkt im Bild) |
| Zähler | Zahl klein, unten rechts, optional | Stk | RS-23 „Mittelwert“ (Zähler hoch, bis „Anzahl Gewichte“) |
| Rücksetzbar | Boolean | – | RS-39: Antippen des Maximalwerts (CPU, Strom Max) setzt zurück |
| Hervorhebung | Schriftfarbe/-größe | – | RS-36 Zahl „859,81“ rot (Bedeutung unbekannt), RS-27 große fette Gewichtsanzeige |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Normal | schwarzer Wert auf weiß |
| Rücksetzbar | Antippen setzt den Maximalwert zurück (RS-39); Rückmeldung nicht beschrieben |
| Ungültig / keine Daten | nicht dargestellt; Platzhalter „--.--.---- --:--:--“ bei Datum (RS-02, hier in RM-31) |

## Verwendet auf Seiten (IDs)

- [RS-05](../Seiten/RS-05_Zufuehrung-Papier.md) – Zuführung Papier (2 Nennungen in den Elementtabellen)
- [RS-06](../Seiten/RS-06_Zufuehrung-Karton.md) – Zuführung Karton (1 Nennung in den Elementtabellen)
- [RS-07](../Seiten/RS-07_Heissleim-Nordson.md) – Heißleim Nordson (4 Nennungen in den Elementtabellen)
- [RS-08](../Seiten/RS-08_Heissleim-Parameter.md) – Heißleim Parameter (genannt im Abschnitt „Verwendete Module“)
- [RS-09](../Seiten/RS-09_Heissleim-Druck.md) – Heißleim Druck (1 Nennung in den Elementtabellen)
- [RS-22](../Seiten/RS-22_Heizungen.md) – Heizungen (1 Nennung in den Elementtabellen)
- [RS-23](../Seiten/RS-23_Regulierung.md) – Regulierung (1 Nennung in den Elementtabellen)
- [RS-25](../Seiten/RS-25_Nocken.md) – Nocken (1 Nennung in den Elementtabellen)
- [RS-27](../Seiten/RS-27_Waagen-Kalibrieren.md) – Waagen Kalibrieren (1 Nennung in den Elementtabellen)
- [RS-31](../Seiten/RS-31_Handbetrieb.md) – Handbetrieb (1 Nennung in den Elementtabellen)
- [RS-32](../Seiten/RS-32_Geber-setzen.md) – Geber setzen (3 Nennungen in den Elementtabellen)
- [RS-34](../Seiten/RS-34_EA-Anzeige.md) – EA-Anzeige (1 Nennung in den Elementtabellen)
- [RS-36](../Seiten/RS-36_Service.md) – Service (1 Nennung in den Elementtabellen)
- [RS-39](../Seiten/RS-39_System-und-Antriebsinfos.md) – System- und Antriebsinfos (11 Nennungen in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-07-P01 | Schwarz ohne Schlüssel | Anzeigefelder sind nicht editierbar | offen |
| RM-07-P02 | Einheiten | Einheit stimmt mit der Seite überein (RS-09: bar, RS-39: %, RS-02: hhh:mm:ss) | offen |
| RM-07-P03 | Rücksetzbarer Maximalwert | RS-39: Antippen setzt Prozessor-Maximum zurück | offen |
| RM-07-P04 | Verwendet-auf-Liste | alle 14 genannten Seiten verlinken zurück auf RM-07; Links lösen auf | offen |
