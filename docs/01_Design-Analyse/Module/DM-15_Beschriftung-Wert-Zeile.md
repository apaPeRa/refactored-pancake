# DM-15 – Beschriftung-Wert-Zeile

## Funktion
Zeile aus Beschriftung links und Wert oder Zustandstext rechts, ohne Eingabe- oder Bedienmöglichkeit (reiner Text auf der Fläche).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
| Name | Typ | Einheit | Wertebereich |
|---|---|---|---|
| Beschriftung | Text (`.resx`) | – | z. B. Druckluft, Papier, Produkt, Bandwaage, Folgemaschine, Soll, Regulierwert, Aktuelle Produktion |
| Wert | Text oder Zahl | optional (% , g, Stück) | Bild: „IO“, „Bereit“, „Läuft“, „Tolles Rezept“, 9854, 14531, „48 %“, „113 g“, „5.30g“ |
| Zusatztext | Text (optional) | – | „entspricht“ (Soll-Zeile, DS-04) |

## Zustände und Darstellung
| Zustand | Darstellung |
|---|---|
| Normal | schwarzer/dunkelgrauer Text, Wert rechtsbündig bzw. eingerückt |
| Statuswert | Zustand als Text („IO“, „Bereit“, „Läuft“); weitere Werte aus Referenz (OP-11) |
| Wert ungültig | im Bild nicht dargestellt; Annahme: „---“ |

Statuswerte tragen ihren Zustand als Text; Farbe wird nicht verwendet. Schreibweise der Einheiten im Entwurf uneinheitlich („5.30g“, „113 g“, „48 %“); im neuen HMI einheitlich mit geschütztem Leerzeichen. Die Zwischenüberschrift „Linienbetrieb“ ist **keine** DM-15-Zeile, sondern Text in [DM-11](DM-11_Gruppenbereich.md).

## Verwendet auf Seiten (IDs)
- [DS-01](../Seiten/DS-01_Produktion.md) – Produktion
- [DS-04](../Seiten/DS-04_Dosierer.md) – Dosierer

DS-04: als Teil von [DM-20](DM-20_Dosierer-Karte.md) (Soll, Regulierwert).

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DM-15-P01 | DS-01 Versorgung | Druckluft, Papier, Produkt je „IO“; Bandwaage „Bereit“; Folgemaschine „Läuft“ | offen |
| DM-15-P02 | DS-01 Produktion | Rezeptanwahl „Tolles Rezept“, Aktuelle Produktion 9854, Letzte Produktion 14531 | offen |
| DM-15-P03 | DS-04 | Soll 48 % entspricht 113 g; Regulierwert 5.30g | offen |
| DM-15-P04 | Abgrenzung | „Linienbetrieb“ ist Text in DM-11, keine DM-15-Zeile | offen |
