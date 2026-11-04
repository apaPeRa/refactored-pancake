# RM-13 – Pop-up-Rahmen

## Funktion

Fenster in der Mitte über der Seite mit Titelleiste, Schließen-Kreuz oben rechts, grauem Hintergrund und großer Taste „Schließen“ unten rechts; Inhalt frei. Dokumentiert für [RS-02](../Seiten/RS-02_Produktionszaehler.md) (Produktionszähler) und [RS-03](../Seiten/RS-03_Maschinengeschwindigkeit.md) (Maschinengeschwindigkeit). Das Eingabe-Pop-up ([RM-06](RM-06_Eingabe-Pop-up.md)) und das Zeitplan-Pop-up ([RM-27](RM-27_Zeitplan-Eintrag-Pop-up.md)) sind eigene Inhalte, nutzen aber denselben Rahmengedanken (Annahme). Im Design nicht vorhanden.

Entsprechung im Design: keine (Element nur in der Referenz).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Titel | Text | – | „Produktionszähler“, „Maschinengeschwindigkeit“ |
| Inhalt | Platzhalter | – | frei, siehe Seite |
| Taste Schließen | Taste | – | grau, unten rechts |
| Schließen-Kreuz | Symbol | – | oben rechts im Bild; im Handbuch nicht beschrieben |
| Öffnen | Auslöser | – | RS-01: Tacho-Symbol (RS-03), Uhr-Symbol (RS-02) |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Offen | Pop-up über der Seite; Hintergrund sperren? nicht beschrieben (Annahme: ja) |
| Geschlossen | Taste Schließen oder Kreuz |

## Verwendet auf Seiten (IDs)

- [RS-01](../Seiten/RS-01_Produktion.md) – Produktion (2 Nennungen in den Elementtabellen)
- [RS-02](../Seiten/RS-02_Produktionszaehler.md) – Produktionszähler (Pop-up) (2 Nennungen in den Elementtabellen)
- [RS-03](../Seiten/RS-03_Maschinengeschwindigkeit.md) – Maschinengeschwindigkeit (Pop-up) (2 Nennungen in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-13-P01 | Titelleiste | Titel und Kreuz wie im Bild | offen |
| RM-13-P02 | Schließen | Taste „Schließen“ schließt das Pop-up (Handbuch) | offen |
| RM-13-P03 | Öffnen | Aufruf von RS-01 aus wie beschrieben | offen |
| RM-13-P04 | Verwendet-auf-Liste | alle 3 genannten Seiten verlinken zurück auf RM-13; Links lösen auf | offen |
