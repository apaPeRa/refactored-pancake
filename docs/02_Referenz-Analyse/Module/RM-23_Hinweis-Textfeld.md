# RM-23 – Hinweis-Textfeld

## Funktion

Textfeld für Hinweise, Warnungen und Statusmeldungen. Varianten: Warnhinweis mit Warnzeichen ⚠ (RS-32 Not-Aus-Hinweis; RS-22 Verbrennungsgefahr), Statusanzeige-Textfeld (RS-27 „Fehler beim schreiben der Filterwerte“), Meldungszeile „Meldung:“ (RS-31 „Motorschutz ausgelöst“, RS-32 Textwert leer). Eigenes Modul, weil es nicht editierbar ist und Textlängen variieren.

Entsprechung im Design: keine (Element nur in der Referenz).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Text | Text, mehrzeilig möglich | – | z. B. „Zum Setzen eines Gebers muss mindestens ein Not-Aus-Taster gedrückt sein …“ |
| Art | Aufzählung | – | Warnhinweis / Statusmeldung / Meldungszeile |
| Warnzeichen | Symbol, optional | – | ⚠ bei Warnhinweis |
| Beschriftung | Text, optional | – | „Meldung:“ |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Hinweis sichtbar | Text im Feld (Handbuch-Hinweis auf RS-32 im Bild nicht zu sehen) |
| Fehler | Text der Meldung, z. B. „Motorschutz ausgelöst“ |
| Leer | Textwert leer (RS-32 Bild) |

## Verwendet auf Seiten (IDs)

- [RS-22](../Seiten/RS-22_Heizungen.md) – Heizungen (genannt im Abschnitt „Verwendete Module“)
- [RS-27](../Seiten/RS-27_Waagen-Kalibrieren.md) – Waagen Kalibrieren (1 Nennung in den Elementtabellen)
- [RS-31](../Seiten/RS-31_Handbetrieb.md) – Handbetrieb (1 Nennung in den Elementtabellen)
- [RS-32](../Seiten/RS-32_Geber-setzen.md) – Geber setzen (2 Nennungen in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-23-P01 | RS-32 | Hinweis zum Not-Aus wortgetreu | offen |
| RM-23-P02 | RS-27 | Statusanzeige zeigt Meldungen, Fehler und Hinweise | offen |
| RM-23-P03 | RS-31 | Meldungszeile mit Text | offen |
| RM-23-P04 | Verwendet-auf-Liste | alle 4 genannten Seiten verlinken zurück auf RM-23; Links lösen auf | offen |
