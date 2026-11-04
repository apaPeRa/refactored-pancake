# RM-32 – Auswahlfeld mit Pfeiltasten

## Funktion

Anzeigefeld mit Pfeiltasten (◄ ►) zum Durchschalten einer Auswahl, mit oder ohne Schlüsselsymbol. [RS-27](../Seiten/RS-27_Waagen-Kalibrieren.md) „Filtertyp“ (Bild „IIR 5 56ms 8Hz“, mit Schlüssel; „Filter setzen“ speichert), [RS-25](../Seiten/RS-25_Nocken.md) „Geber“ (Bild „Geber 1GF Hauptantrieb“, mit Schlüssel) und Datumsfeld mit Pfeiltasten (RS-29, Auswahl = Tag der letzten 30 Tage, Bild „heute“) und Nockennummer (Feld „12“ mit Tasten „<<“ und „>>“; Handbuch: „Direkte Auswahl einer Fixierkurve“).

Entsprechung im Design: keine (Element nur in der Referenz).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Auswahlliste | Liste | – | Filtertypen (RS-27), Geber (RS-25), Nockennummern (Bereich nicht angegeben) |
| Aktueller Eintrag | Text oder Zahl | – | Bild siehe oben |
| Pfeiltasten | ◄ ► | – | vor / zurück |
| Schlüsselsymbol | Boolean | – | RS-25 Geber, RS-27 Filtertyp |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Normal | Feld mit Pfeilen |
| Übernommen | Filter erst nach „Filter setzen“ (RS-27) |
| Listenende | nicht beschrieben |

## Verwendet auf Seiten (IDs)

- [RS-25](../Seiten/RS-25_Nocken.md) – Nocken (2 Nennungen in den Elementtabellen)
- [RS-27](../Seiten/RS-27_Waagen-Kalibrieren.md) – Waagen Kalibrieren (1 Nennung in den Elementtabellen)
- [RS-29](../Seiten/RS-29_Produktionsstatistik.md) – Produktionsstatistik (Datumsnavigation, 4 Nennungen als RM-30)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-32-P01 | Auswahl | Pfeile schalten die Auswahl weiter | offen |
| RM-32-P02 | Übernehmen | RS-27: Filter setzen; RS-25: Werte schreiben | offen |
| RM-32-P03 | Verwendet-auf-Liste | alle 2 genannten Seiten verlinken zurück auf RM-32; Links lösen auf | offen |
