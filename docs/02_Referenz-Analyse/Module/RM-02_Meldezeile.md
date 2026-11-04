# RM-02 – Meldezeile

## Funktion

Roter Balken über die volle Breite oberhalb der Funktionsleiste mit fetter Schrift: Meldungsnummer zwischen Sternchen und Meldungstext, z. B. „*450* Palettierung nicht bereit“. Auf allen Seiten außer den Pop-ups sichtbar. Antippen öffnet laut Referenz-Übersicht die Meldeanzeige [RS-38](../Seiten/RS-38_Meldeanzeige.md); im Handbuch wird die Meldezeile nicht beschrieben.

Entsprechung im Design: [DM-04](../../01_Design-Analyse/Module/DM-04_Meldezeile.md).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Meldungsnummer | Zahl | – | dreistellig im Bild (450); Nummernkreise siehe RS-37/RS-38 (z. B. 000, 080, 081, 090, 098, 099, 100, 101, 120) |
| Meldungstext | Text | – | Kurzbeschreibung, z. B. „Palettierung nicht bereit“ |
| Farbe | Farbcode | – | im Bild rot; Farbcodierung der Meldungen laut RS-38: Grün Betriebsstatus Automatik, Gelb Hinweise und Statusmeldungen, Rot Störung oder sicherheitsrelevante Meldung (führt zum Stopp) |
| Ziel beim Antippen | Navigation | – | RS-38 (laut Referenz-Übersicht) |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Meldung aktiv | Balken mit Nummer und Text, im Bild rot |
| Andere Meldungsklassen | Farbe nach Klasse (grün/gelb/rot) ist für die Zeile nicht abgebildet; Annahme: wie Farbcodierung in RS-38 |
| Keine Meldung | im Bild nicht dargestellt; Annahme: Zeile bleibt mit neutraler Anzeige |
| Mehrere Meldungen | nicht beschrieben |

## Verwendet auf Seiten (IDs)

- [RS-01](../Seiten/RS-01_Produktion.md) – Produktion (1 Nennung in den Elementtabellen)
- [RS-04](../Seiten/RS-04_Einstellungen.md) – Einstellungen (1 Nennung in den Elementtabellen)
- [RS-05](../Seiten/RS-05_Zufuehrung-Papier.md) – Zuführung Papier (1 Nennung in den Elementtabellen)
- [RS-06](../Seiten/RS-06_Zufuehrung-Karton.md) – Zuführung Karton (1 Nennung in den Elementtabellen)
- [RS-07](../Seiten/RS-07_Heissleim-Nordson.md) – Heißleim Nordson (1 Nennung in den Elementtabellen)
- [RS-08](../Seiten/RS-08_Heissleim-Parameter.md) – Heißleim Parameter (1 Nennung in den Elementtabellen)
- [RS-09](../Seiten/RS-09_Heissleim-Druck.md) – Heißleim Druck (1 Nennung in den Elementtabellen)
- [RS-10](../Seiten/RS-10_Zeitschaltuhr.md) – Zeitschaltuhr (1 Nennung in den Elementtabellen)
- [RS-11](../Seiten/RS-11_Hauptdosierer-1-und-2.md) – Hauptdosierer 1 & 2 (1 Nennung in den Elementtabellen)
- [RS-12](../Seiten/RS-12_Motorparameter.md) – Motorparameter (Hauptdosierer) (1 Nennung in den Elementtabellen)
- [RS-13](../Seiten/RS-13_Kontrollwaage.md) – Kontrollwaage (1 Nennung in den Elementtabellen)
- [RS-14](../Seiten/RS-14_Einzelgewichte.md) – Einzelgewichte (1 Nennung in den Elementtabellen)
- [RS-15](../Seiten/RS-15_Trend.md) – Trend (1 Nennung in den Elementtabellen)
- [RS-16](../Seiten/RS-16_Schliessmaschine.md) – Schließmaschine (1 Nennung in den Elementtabellen)
- [RS-17](../Seiten/RS-17_Motorparameter-Schliessmaschine.md) – Motorparameter (Schließmaschine) (1 Nennung in den Elementtabellen)
- [RS-18](../Seiten/RS-18_Gewichtskorrektur-Schliessmaschine.md) – Gewichtskorrektur (Schließmaschine) (1 Nennung in den Elementtabellen)
- [RS-19](../Seiten/RS-19_Nachdosierer.md) – Nachdosierer (1 Nennung in den Elementtabellen)
- [RS-20](../Seiten/RS-20_Motorparameter.md) – Motorparameter (Nachdosierer) (1 Nennung in den Elementtabellen)
- [RS-21](../Seiten/RS-21_Gewichtskorrektur.md) – Gewichtskorrektur (Nachdosierer) (1 Nennung in den Elementtabellen)
- [RS-22](../Seiten/RS-22_Heizungen.md) – Heizungen (1 Nennung in den Elementtabellen)
- [RS-23](../Seiten/RS-23_Regulierung.md) – Regulierung (1 Nennung in den Elementtabellen)
- [RS-25](../Seiten/RS-25_Nocken.md) – Nocken (genannt im Abschnitt „Verwendete Module“)
- [RS-26](../Seiten/RS-26_Nockenuebersicht.md) – Nockenübersicht (1 Nennung in den Elementtabellen)
- [RS-27](../Seiten/RS-27_Waagen-Kalibrieren.md) – Waagen Kalibrieren (1 Nennung in den Elementtabellen)
- [RS-28](../Seiten/RS-28_Packungsregister.md) – Packungsregister (1 Nennung in den Elementtabellen)
- [RS-29](../Seiten/RS-29_Produktionsstatistik.md) – Produktionsstatistik (1 Nennung in den Elementtabellen)
- [RS-30](../Seiten/RS-30_Handbetrieb-Auswahl.md) – Handbetrieb Auswahl (1 Nennung in den Elementtabellen)
- [RS-31](../Seiten/RS-31_Handbetrieb.md) – Handbetrieb (1 Nennung in den Elementtabellen)
- [RS-32](../Seiten/RS-32_Geber-setzen.md) – Geber setzen (1 Nennung in den Elementtabellen)
- [RS-33](../Seiten/RS-33_EA-Uebersicht.md) – EA-Übersicht (1 Nennung in den Elementtabellen)
- [RS-34](../Seiten/RS-34_EA-Anzeige.md) – EA-Anzeige (1 Nennung in den Elementtabellen)
- [RS-35](../Seiten/RS-35_Systemeinstellungen.md) – Systemeinstellungen (1 Nennung in den Elementtabellen)
- [RS-36](../Seiten/RS-36_Service.md) – Service (1 Nennung in den Elementtabellen)
- [RS-37](../Seiten/RS-37_Meldearchiv.md) – Meldearchiv (1 Nennung in den Elementtabellen)
- [RS-38](../Seiten/RS-38_Meldeanzeige.md) – Meldeanzeige (2 Nennungen in den Elementtabellen)
- [RS-39](../Seiten/RS-39_System-und-Antriebsinfos.md) – System- und Antriebsinfos (1 Nennung in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-02-P01 | Darstellung | Nummer in Sternchen und Text, roter Balken, volle Breite | offen |
| RM-02-P02 | Antippen | öffnet die Meldeanzeige RS-38 (Zugang laut Referenz-Übersicht) | offen |
| RM-02-P03 | Klassen | Farbe wird zusätzlich über Text/Nummer vermittelt, nicht nur über die Farbe (Agent.md Abschnitt 6) | offen |
| RM-02-P04 | Verwendet-auf-Liste | alle 36 genannten Seiten verlinken zurück auf RM-02; Links lösen auf | offen |
