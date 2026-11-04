# RM-04 – Blättertasten

## Funktion

Paar aus Pfeiltasten („<<“ und „>>“, auf RS-11/RS-20 auch ein einzelnes „»“), das innerhalb derselben Seitenform zwischen gleichartigen Objekten blättert. Sitzt in der Funktionsleiste unten links ([RM-03](RM-03_Funktionsleiste-unten.md)). Im Design nicht vorhanden. Handbuch: „Schaltet die Seiten zwischen den beiden Hauptdosieren um“ (RS-11), „Erlaubt das blättern zwischen den Nocken“ (RS-25), „zwischen den verbauten Waagen“ (RS-27), „zwischen den Gebern“ (RS-32), „zwischen den einzelnen EA-Karten“ (RS-34).

Entsprechung im Design: keine (Element nur in der Referenz).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Objektliste | Liste | – | RS-11: Hauptdosierer 1 und 2; RS-25/RS-26: Nocken (Nr. 40 bis 59 im Bild); RS-27: Waagen; RS-31: Aktoren; RS-32: Geber; RS-34: EA-Karten |
| Richtung | Aufzählung | – | zurück (<<) / vor (>>) |
| Darstellung | Variante | – | Paar „<<“ „>>“ (RS-25, RS-26, RS-27, RS-31, RS-32, RS-34) oder einzelne Taste „»“ (RS-12, RS-20, grau) |
| Wirkung am Rand | Verhalten | – | Im Handbuch nicht angegeben |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Aktiv | Tasten grau, beide sichtbar |
| Am Listenende | nicht beschrieben (Annahme: Taste deaktiviert oder umlaufend) |
| Wirkung auf RS-26 | Wirkung der Tasten im Handbuch nicht beschrieben (offener Punkt RS-26) |

## Verwendet auf Seiten (IDs)

- [RS-11](../Seiten/RS-11_Hauptdosierer-1-und-2.md) – Hauptdosierer 1 & 2 (1 Nennung in den Elementtabellen)
- [RS-12](../Seiten/RS-12_Motorparameter.md) – Motorparameter (Hauptdosierer) (1 Nennung in den Elementtabellen)
- [RS-20](../Seiten/RS-20_Motorparameter.md) – Motorparameter (Nachdosierer) (1 Nennung in den Elementtabellen)
- [RS-25](../Seiten/RS-25_Nocken.md) – Nocken (2 Nennungen in den Elementtabellen)
- [RS-26](../Seiten/RS-26_Nockenuebersicht.md) – Nockenübersicht (1 Nennung in den Elementtabellen)
- [RS-27](../Seiten/RS-27_Waagen-Kalibrieren.md) – Waagen Kalibrieren (1 Nennung in den Elementtabellen)
- [RS-31](../Seiten/RS-31_Handbetrieb.md) – Handbetrieb (1 Nennung in den Elementtabellen)
- [RS-32](../Seiten/RS-32_Geber-setzen.md) – Geber setzen (1 Nennung in den Elementtabellen)
- [RS-34](../Seiten/RS-34_EA-Anzeige.md) – EA-Anzeige (1 Nennung in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-04-P01 | RS-11 | Pfeiltasten schalten zwischen Hauptdosierer 1 und 2 um | offen |
| RM-04-P02 | RS-25 / RS-26 | Tasten blättern zwischen den Nocken | offen |
| RM-04-P03 | RS-27 / RS-32 / RS-34 | Blättern zwischen Waagen, Gebern bzw. EA-Karten | offen |
| RM-04-P04 | Neue HMI | Variante „einzelne Taste“ (RS-12, RS-20) auf Zweck geprüft | offen |
| RM-04-P05 | Verwendet-auf-Liste | alle 9 genannten Seiten verlinken zurück auf RM-04; Links lösen auf | offen |
