# RM-25 – Objekt-Überschrift

## Funktion

Fette, unterstrichene, zentrierte Überschrift, die das Objekt der Seite benennt, das mit Blättertasten gewechselt wird: Waage („16KW1 Kontrollwaage“, RS-27), Antrieb/Aktor („Antrieb Zuführung 2MA1“, RS-31, RS-32) oder EA-Karte („S1_0KDE1“, RS-34). Nicht zu verwechseln mit dem Seitentitel in [RM-01](RM-01_Kopfzeile.md).

Entsprechung im Design: [DM-21](../../01_Design-Analyse/Module/DM-21_Titelzeile-mit-Verschiebesymbol.md).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Objektname | Text | – | Betriebsmittelkennzeichen und Bezeichnung |
| Quelle | Auswahl | – | über [RM-04](RM-04_Blaettertasten.md) gewechselt |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Normal | Text fett und unterstrichen |
| Wechsel | Titel wechselt mit dem Objekt |

## Verwendet auf Seiten (IDs)

- [RS-27](../Seiten/RS-27_Waagen-Kalibrieren.md) – Waagen Kalibrieren (1 Nennung in den Elementtabellen)
- [RS-31](../Seiten/RS-31_Handbetrieb.md) – Handbetrieb (1 Nennung in den Elementtabellen)
- [RS-32](../Seiten/RS-32_Geber-setzen.md) – Geber setzen (1 Nennung in den Elementtabellen)
- [RS-34](../Seiten/RS-34_EA-Anzeige.md) – EA-Anzeige (1 Nennung in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-25-P01 | RS-27 / RS-31 / RS-32 / RS-34 | Überschrift passt zum angewählten Objekt | offen |
| RM-25-P02 | Abgrenzung | Seitentitel steht in RM-01 | offen |
| RM-25-P03 | Verwendet-auf-Liste | alle 4 genannten Seiten verlinken zurück auf RM-25; Links lösen auf | offen |
