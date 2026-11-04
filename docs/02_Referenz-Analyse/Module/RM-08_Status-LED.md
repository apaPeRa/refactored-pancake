# RM-08 – Status-LED

## Funktion

Runde Kontrollleuchte. Im Bild grau (aus/inaktiv), grün (in Ordnung/aktiv) oder rot (Fehler/nicht bereit). Wird einzeln, mit Text, mit Symbol oder in Tabellenzeilen verwendet. Die Farbbedeutung beschreibt das Handbuch nur an wenigen Stellen (RS-07, RS-22, RS-26, RS-32, RS-14); in den übrigen Fällen ist sie aus dem Bild abgeleitet. Moduleinheit auch für die Füllstandsanzeige am Trichter (Trichter-Symbol + Leuchte, RS-11, RS-19) und für die Statusliste (LED + Text, RS-07).

Entsprechung im Design: [DM-14](../../01_Design-Analyse/Module/DM-14_Status-LED.md).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Zustand | Aufzählung | – | aus (grau) / ein (grün) / Fehler (rot) |
| Beschriftung | Text, optional | – | z. B. „Bereitschaft“, „Temperatur“, „Füllsystem“, „Tankfüllstand“, „Tank Klappe“, „Keine Störung“, „Kein Alarm“ (RS-07); „Klebestelle erkannt“, „Sensor Klebestelle“ (RS-05); „Achse initialisiert“ (RS-32) |
| Symbol | Grafik, optional | – | Trichter-Symbol oben/unten (RS-11, RS-19) |
| Kennung | Text, optional | – | SPS-Kennung bei EA-Zeilen, siehe [RM-35](RM-35_EA-Zeile.md) |
| Anordnung | Aufzählung | – | einzeln, Liste (Statusliste), Spalte in Tabelle (State, Out in RS-22; Nocken in RS-25/RS-26), Zelle im Gitter ([RM-36](RM-36_Wertegitter.md)) |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Aus / inaktiv | grau |
| Ein / in Ordnung | grün; Heizungen: Zieltemperatur erreicht (RS-22 State); Nocken: Maschine in aktiver Nockenphase (RS-26); Wertegitter: gutes Gewicht (RS-14); Statusliste: alle LEDs grün = betriebsbereit (RS-07) |
| Fehler | rot; Heizung nicht bereit oder Fehler (RS-22 State); Trichter unten rot (RS-11/RS-19, Bedeutung unbeschrieben) |
| Hinweis neues HMI | Zustand zusätzlich über Text oder Symbol, nicht nur Farbe |

## Verwendet auf Seiten (IDs)

- [RS-05](../Seiten/RS-05_Zufuehrung-Papier.md) – Zuführung Papier (2 Nennungen in den Elementtabellen)
- [RS-07](../Seiten/RS-07_Heissleim-Nordson.md) – Heißleim Nordson (7 Nennungen in den Elementtabellen)
- [RS-11](../Seiten/RS-11_Hauptdosierer-1-und-2.md) – Hauptdosierer 1 & 2 (2 Nennungen in den Elementtabellen)
- [RS-14](../Seiten/RS-14_Einzelgewichte.md) – Einzelgewichte (1 Nennung in den Elementtabellen)
- [RS-19](../Seiten/RS-19_Nachdosierer.md) – Nachdosierer (2 Nennungen in den Elementtabellen)
- [RS-22](../Seiten/RS-22_Heizungen.md) – Heizungen (2 Nennungen in den Elementtabellen)
- [RS-25](../Seiten/RS-25_Nocken.md) – Nocken (1 Nennung in den Elementtabellen)
- [RS-26](../Seiten/RS-26_Nockenuebersicht.md) – Nockenübersicht (1 Nennung in den Elementtabellen)
- [RS-31](../Seiten/RS-31_Handbetrieb.md) – Handbetrieb (2 Nennungen in den Elementtabellen)
- [RS-32](../Seiten/RS-32_Geber-setzen.md) – Geber setzen (1 Nennung in den Elementtabellen)
- [RS-34](../Seiten/RS-34_EA-Anzeige.md) – EA-Anzeige (1 Nennung in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-08-P01 | Farbwerte | grau/grün/rot entsprechend den Beschreibungen der verwendenden Seiten | offen |
| RM-08-P02 | RS-07 | sieben LEDs mit Beschriftung; Gerät betriebsbereit nur, wenn alle grün | offen |
| RM-08-P03 | RS-22 | State: grau = aus, grün = Zieltemperatur, rot = nicht bereit/Fehler; Out: Farbbedeutung unbeschrieben | offen |
| RM-08-P04 | RS-26 / RS-14 | grün = in Nockenphase bzw. gutes Gewicht | offen |
| RM-08-P05 | Zustand ohne Farbe | zweiter Kanal (Text/Symbol) im neuen HMI | offen |
| RM-08-P06 | Verwendet-auf-Liste | alle 11 genannten Seiten verlinken zurück auf RM-08; Links lösen auf | offen |
