# RM-35 – EA-Zeile

## Funktion

Zeile der Signalliste auf [RS-34](../Seiten/RS-34_EA-Anzeige.md): Status-LED, SPS-Kennung und Klartext, z. B. „0F24A_rdy – SICHERUNGS MODUL BEREIT (0F24A)“, „0E3 – KUEHLGERAET BEREIT“. Analoge Ein-/Ausgänge werden als numerische Werte angezeigt (nur auf Analogkarten, im Bild nicht zu sehen). 8 Zeilen je Karte.

Entsprechung im Design: keine (Element nur in der Referenz).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| LED | Status-LED | – | grau = inaktiv (Bild); aktive Farbe nicht beschrieben |
| Kennung | Text | – | SPS-Name, z. B. S1_0KDE1_3 |
| Klartext | Text | – | z. B. RESERVE |
| Analogwert | Zahl | je Kanal | Einheit nicht angegeben |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Inaktiv | LED grau |
| Aktiv | nicht abgebildet |
| Analog | numerischer Wert statt LED |

## Verwendet auf Seiten (IDs)

- [RS-34](../Seiten/RS-34_EA-Anzeige.md) – EA-Anzeige (1 Nennung in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-35-P01 | Zeilen | 8 Zeilen Karte S1_0KDE1 | offen |
| RM-35-P02 | Texte | Kennung und Klartext wie im Bild | offen |
| RM-35-P03 | Blättern | über Blättertasten zur nächsten Karte | offen |
| RM-35-P04 | Verwendet-auf-Liste | alle 1 genannten Seiten verlinken zurück auf RM-35; Links lösen auf | offen |
