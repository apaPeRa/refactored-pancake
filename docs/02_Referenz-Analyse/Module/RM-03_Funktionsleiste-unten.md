# RM-03 – Funktionsleiste unten

## Funktion

Hellgraue Leiste am unteren Rand. Rechts stehen auf allen Seiten dieselben Navigationstasten „Produktion“ (Haus-Symbol, Ziel [RS-01](../Seiten/RS-01_Produktion.md)), „Einstellungen“ (Zahnrad-Symbol, Ziel [RS-04](../Seiten/RS-04_Einstellungen.md)) und „Zurück“ (Pfeil-Symbol, eine Ebene zurück); davor ein gelbes, geschlossenes Schloss-Symbol (Bedeutung im Handbuch nicht erklärt, vermutlich Anmelde-/Berechtigungsstatus). Links befinden sich seitenspezifische Tasten („Navigation unten links“), die das Handbuch für einige Seiten beschreibt. Die festen Tasten sind im Handbuch nur selten erwähnt; Ziele sind aus Beschriftung und Referenz-Übersicht abgeleitet (A-14).

Entsprechung im Design: [DM-09](../../01_Design-Analyse/Module/DM-09_Funktionsleiste.md), [DM-02](../../01_Design-Analyse/Module/DM-02_Navigationsleiste.md).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Feste Tasten | 3 Navigationstasten | – | Produktion, Einstellungen, Zurück |
| Schloss-Symbol | Symbol, gelb, geschlossen | – | Bedeutung nicht beschrieben (Berechtigung vermutet) |
| Seitenspezifische Tasten links | Liste von Tasten, 0 bis 3 (mit Blättertasten bis 4) | – | Beispiele: Motorparameter (RS-11), Gewichtskorrektur/Motorparameter/Regulierung (RS-19), Trend und Einzelgewichte (RS-13), Temperatur/Druck/Zeitschaltuhr (RS-07), Heißleimgerät (RS-06, RS-16), Übersicht (RS-25), Suchen (RS-30, RS-31, RS-33), Archiv (RS-38), Lampentest (RS-35), Wago (RS-36) |
| Aktive Seite | Hervorhebung | – | aktuelle Seite umrandet bzw. unterstrichen (z. B. „Produktion“ auf RS-01, „Druck“ auf RS-07) |
| Blättertasten | Modul | – | [RM-04](RM-04_Blaettertasten.md) kann links eingebettet sein |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Standard | feste Tasten und Schloss, linke Seite leer (z. B. RS-05, RS-08, RS-22) |
| Mit Seitentasten | zusätzliche Tasten links, beschriftet und mit Symbol |
| Aktive Seite | Taste der aktuellen Seite hervorgehoben |
| Schloss gesperrt/offen | nur geschlossenes Schloss im Bild; offener Zustand nicht dargestellt (Annahme) |

## Verwendet auf Seiten (IDs)

- [RS-01](../Seiten/RS-01_Produktion.md) – Produktion (4 Nennungen in den Elementtabellen)
- [RS-04](../Seiten/RS-04_Einstellungen.md) – Einstellungen (4 Nennungen in den Elementtabellen)
- [RS-05](../Seiten/RS-05_Zufuehrung-Papier.md) – Zuführung Papier (1 Nennung in den Elementtabellen)
- [RS-06](../Seiten/RS-06_Zufuehrung-Karton.md) – Zuführung Karton (2 Nennungen in den Elementtabellen)
- [RS-07](../Seiten/RS-07_Heissleim-Nordson.md) – Heißleim Nordson (5 Nennungen in den Elementtabellen)
- [RS-08](../Seiten/RS-08_Heissleim-Parameter.md) – Heißleim Parameter (2 Nennungen in den Elementtabellen)
- [RS-09](../Seiten/RS-09_Heissleim-Druck.md) – Heißleim Druck (2 Nennungen in den Elementtabellen)
- [RS-10](../Seiten/RS-10_Zeitschaltuhr.md) – Zeitschaltuhr (2 Nennungen in den Elementtabellen)
- [RS-11](../Seiten/RS-11_Hauptdosierer-1-und-2.md) – Hauptdosierer 1 & 2 (4 Nennungen in den Elementtabellen)
- [RS-12](../Seiten/RS-12_Motorparameter.md) – Motorparameter (Hauptdosierer) (2 Nennungen in den Elementtabellen)
- [RS-13](../Seiten/RS-13_Kontrollwaage.md) – Kontrollwaage (4 Nennungen in den Elementtabellen)
- [RS-14](../Seiten/RS-14_Einzelgewichte.md) – Einzelgewichte (1 Nennung in den Elementtabellen)
- [RS-15](../Seiten/RS-15_Trend.md) – Trend (1 Nennung in den Elementtabellen)
- [RS-16](../Seiten/RS-16_Schliessmaschine.md) – Schließmaschine (5 Nennungen in den Elementtabellen)
- [RS-17](../Seiten/RS-17_Motorparameter-Schliessmaschine.md) – Motorparameter (Schließmaschine) (3 Nennungen in den Elementtabellen)
- [RS-18](../Seiten/RS-18_Gewichtskorrektur-Schliessmaschine.md) – Gewichtskorrektur (Schließmaschine) (1 Nennung in den Elementtabellen)
- [RS-19](../Seiten/RS-19_Nachdosierer.md) – Nachdosierer (2 Nennungen in den Elementtabellen)
- [RS-20](../Seiten/RS-20_Motorparameter.md) – Motorparameter (Nachdosierer) (1 Nennung in den Elementtabellen)
- [RS-21](../Seiten/RS-21_Gewichtskorrektur.md) – Gewichtskorrektur (Nachdosierer) (1 Nennung in den Elementtabellen)
- [RS-22](../Seiten/RS-22_Heizungen.md) – Heizungen (1 Nennung in den Elementtabellen)
- [RS-23](../Seiten/RS-23_Regulierung.md) – Regulierung (1 Nennung in den Elementtabellen)
- [RS-25](../Seiten/RS-25_Nocken.md) – Nocken (genannt im Abschnitt „Verwendete Module“)
- [RS-26](../Seiten/RS-26_Nockenuebersicht.md) – Nockenübersicht (1 Nennung in den Elementtabellen)
- [RS-27](../Seiten/RS-27_Waagen-Kalibrieren.md) – Waagen Kalibrieren (2 Nennungen in den Elementtabellen)
- [RS-28](../Seiten/RS-28_Packungsregister.md) – Packungsregister (1 Nennung in den Elementtabellen)
- [RS-29](../Seiten/RS-29_Produktionsstatistik.md) – Produktionsstatistik (1 Nennung in den Elementtabellen)
- [RS-30](../Seiten/RS-30_Handbetrieb-Auswahl.md) – Handbetrieb Auswahl (2 Nennungen in den Elementtabellen)
- [RS-31](../Seiten/RS-31_Handbetrieb.md) – Handbetrieb (1 Nennung in den Elementtabellen)
- [RS-32](../Seiten/RS-32_Geber-setzen.md) – Geber setzen (1 Nennung in den Elementtabellen)
- [RS-33](../Seiten/RS-33_EA-Uebersicht.md) – EA-Übersicht (1 Nennung in den Elementtabellen)
- [RS-34](../Seiten/RS-34_EA-Anzeige.md) – EA-Anzeige (1 Nennung in den Elementtabellen)
- [RS-35](../Seiten/RS-35_Systemeinstellungen.md) – Systemeinstellungen (3 Nennungen in den Elementtabellen)
- [RS-36](../Seiten/RS-36_Service.md) – Service (2 Nennungen in den Elementtabellen)
- [RS-37](../Seiten/RS-37_Meldearchiv.md) – Meldearchiv (1 Nennung in den Elementtabellen)
- [RS-38](../Seiten/RS-38_Meldeanzeige.md) – Meldeanzeige (3 Nennungen in den Elementtabellen)
- [RS-39](../Seiten/RS-39_System-und-Antriebsinfos.md) – System- und Antriebsinfos (1 Nennung in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-03-P01 | Feste Tasten | Produktion, Einstellungen, Zurück vorhanden; Ziele RS-01, RS-04, vorherige Seite | offen |
| RM-03-P02 | Schloss | gelbes Schloss vorhanden; Bedeutung als offener Punkt vermerkt | offen |
| RM-03-P03 | Seitentasten | linke Tasten stimmen mit der Beschreibung der jeweiligen Seite überein | offen |
| RM-03-P04 | Touch-Ziel | Tasten erfüllen die Mindestgröße des neuen HMI (Agent.md Abschnitt 6) | offen |
| RM-03-P05 | Verwendet-auf-Liste | alle 36 genannten Seiten verlinken zurück auf RM-03; Links lösen auf | offen |
