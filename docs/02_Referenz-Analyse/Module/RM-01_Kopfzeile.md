# RM-01 – Kopfzeile

## Funktion

Rahmenelement am oberen Seitenrand; auf allen Seiten außer den Pop-ups (RS-02, RS-03). Im Bild von links nach rechts: Logo „APA-TEC GmbH – Automation and Packaging Technology“, mittig der fette, unterstrichene Seitentitel, daneben ein Wirbel-/Spiral-Symbol (Bedeutung im Handbuch nicht erklärt), rechts Uhrzeit (groß) und Datum. Das Handbuch beschreibt die Kopfzeile nirgends; alle Angaben stammen aus den Seitenbildern.

Entsprechung im Design: [DM-03](../../01_Design-Analyse/Module/DM-03_Kopfzeile-Logo.md), [DM-06](../../01_Design-Analyse/Module/DM-06_Uhrzeit-und-Datum.md).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Logo | Grafik | – | APA-TEC (fest) |
| Seitentitel | Text (fett, unterstrichen) | – | je Seite, z. B. „Produktion“, „Einstellungen“, „Heißleim Zuführung“, „Zeitschaltuhr Zuführung“, „Motorparameter HD1“, „Einzelgewichte KW“, „Trend KW“ |
| Titelzusatz | Text, optional | – | Kennung des Objekts im Titel: „HD1“ (Hauptdosierer 1), „KW“ (Kontrollwaage); sonst entfällt |
| Wirbel-Symbol | Symbol | – | schwarz oder blau; Bedeutung und Funktion nicht beschrieben (offener Punkt der Seiten) |
| Uhrzeit | Zeit, nur Anzeige | hh:mm:ss | z. B. 13:01:12 |
| Datum | Datum, nur Anzeige | tt.mm.jjjj | z. B. 12.05.2025 |
| Zusatzanzeige „Service“ | Schriftzug am Wirbel-Symbol, optional | – | nur auf RS-24 und RS-36 sichtbar (roter Schriftzug); Bedeutung nicht beschrieben |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Standard | Logo, Titel, Symbol, Uhrzeit und Datum, Uhrzeit läuft mit |
| Service-Variante | zusätzlich roter Schriftzug „Service“ (RS-24, RS-36); Auslöser unbekannt (Annahme: Servicebetrieb) |
| Titel mit Zusatz | Titel enthält die Objektkennung, z. B. „Motorparameter HD1“ |

## Verwendet auf Seiten (IDs)

- [RS-01](../Seiten/RS-01_Produktion.md) – Produktion (4 Nennungen in den Elementtabellen)
- [RS-04](../Seiten/RS-04_Einstellungen.md) – Einstellungen (4 Nennungen in den Elementtabellen)
- [RS-05](../Seiten/RS-05_Zufuehrung-Papier.md) – Zuführung Papier (1 Nennung in den Elementtabellen)
- [RS-06](../Seiten/RS-06_Zufuehrung-Karton.md) – Zuführung Karton (1 Nennung in den Elementtabellen)
- [RS-07](../Seiten/RS-07_Heissleim-Nordson.md) – Heißleim Nordson (1 Nennung in den Elementtabellen)
- [RS-08](../Seiten/RS-08_Heissleim-Parameter.md) – Heißleim Parameter (1 Nennung in den Elementtabellen)
- [RS-09](../Seiten/RS-09_Heissleim-Druck.md) – Heißleim Druck (1 Nennung in den Elementtabellen)
- [RS-10](../Seiten/RS-10_Zeitschaltuhr.md) – Zeitschaltuhr (1 Nennung in den Elementtabellen)
- [RS-11](../Seiten/RS-11_Hauptdosierer-1-und-2.md) – Hauptdosierer 1 & 2 (4 Nennungen in den Elementtabellen)
- [RS-12](../Seiten/RS-12_Motorparameter.md) – Motorparameter (Hauptdosierer) (2 Nennungen in den Elementtabellen)
- [RS-13](../Seiten/RS-13_Kontrollwaage.md) – Kontrollwaage (1 Nennung in den Elementtabellen)
- [RS-14](../Seiten/RS-14_Einzelgewichte.md) – Einzelgewichte (1 Nennung in den Elementtabellen)
- [RS-15](../Seiten/RS-15_Trend.md) – Trend (1 Nennung in den Elementtabellen)
- [RS-16](../Seiten/RS-16_Schliessmaschine.md) – Schließmaschine (4 Nennungen in den Elementtabellen)
- [RS-17](../Seiten/RS-17_Motorparameter-Schliessmaschine.md) – Motorparameter (Schließmaschine) (1 Nennung in den Elementtabellen)
- [RS-18](../Seiten/RS-18_Gewichtskorrektur-Schliessmaschine.md) – Gewichtskorrektur (Schließmaschine) (1 Nennung in den Elementtabellen)
- [RS-19](../Seiten/RS-19_Nachdosierer.md) – Nachdosierer (4 Nennungen in den Elementtabellen)
- [RS-20](../Seiten/RS-20_Motorparameter.md) – Motorparameter (Nachdosierer) (2 Nennungen in den Elementtabellen)
- [RS-21](../Seiten/RS-21_Gewichtskorrektur.md) – Gewichtskorrektur (Nachdosierer) (1 Nennung in den Elementtabellen)
- [RS-22](../Seiten/RS-22_Heizungen.md) – Heizungen (1 Nennung in den Elementtabellen)
- [RS-23](../Seiten/RS-23_Regulierung.md) – Regulierung (1 Nennung in den Elementtabellen)
- [RS-24](../Seiten/RS-24_Bildschirm-reinigen.md) – Bildschirm reinigen (1 Nennung in den Elementtabellen)
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
- [RS-38](../Seiten/RS-38_Meldeanzeige.md) – Meldeanzeige (1 Nennung in den Elementtabellen)
- [RS-39](../Seiten/RS-39_System-und-Antriebsinfos.md) – System- und Antriebsinfos (1 Nennung in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-01-P01 | Seitentitel entspricht Seite | Titel stimmt mit der Seitenbeschreibung (Aufbau) der verwendenden Seite überein | offen |
| RM-01-P02 | Uhrzeit und Datum | Format hh:mm:ss und tt.mm.jjjj, Uhrzeit läuft | offen |
| RM-01-P03 | Wirbel-Symbol | Symbol vorhanden; Bedeutung bleibt als offener Punkt vermerkt | offen |
| RM-01-P04 | Service-Schriftzug | erscheint nur auf RS-24 und RS-36 | offen |
| RM-01-P05 | Verwendet-auf-Liste | alle 37 genannten Seiten verlinken zurück auf RM-01; Links lösen auf | offen |
