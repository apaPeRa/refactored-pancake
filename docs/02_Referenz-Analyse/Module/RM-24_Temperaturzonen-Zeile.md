# RM-24 – Temperaturzonen-Zeile

## Funktion

Zeile je Heiz- oder Temperaturzone. Variante Heißleim ([RS-08](../Seiten/RS-08_Heissleim-Parameter.md)): Zonenname, Soll (Eingabe, °C), Ist (Anzeige, °C), Statustaste „Ausschalten“ (grün) / „Einschalten“ (rot); Zonen Tank, Schlauch 1, Pistole 1, Schlauch 2, Pistole 2 (linkes Feld) und Verteiler (rechtes Feld). Variante Heizungen ([RS-22](../Seiten/RS-22_Heizungen.md)): Tabelle aus 12 Zonen (z. B. „6E1 Längsnaht Links Zone 1“ bis „20E4 Kopf Fertigsiegeln Vorne“) mit Spalten Heizung (Ein/Aus), Meldung (Überwachung), Soll, Ist, State, Out.

Entsprechung im Design: keine (Element nur in der Referenz).

Struktur: Zeile aus [RM-05](RM-05_Eingabefeld-mit-Schluesselsymbol.md) (Soll), [RM-07](RM-07_Anzeigefeld.md) (Ist), [RM-10](RM-10_Umschalter-Taste.md) (Statustaste) und [RM-08](RM-08_Status-LED.md) (State/Out); eigen ist nur die Zeilenkomposition.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Zonenname | Text | – | RS-08: Tank, Schlauch 1/2, Pistole 1/2, Verteiler; RS-22: 12 Zonen (6E1 … 20E4) |
| Soll | Zahl (Eingabe mit Schlüssel) | °C (RS-08), ° (RS-22) | RS-08: 150, 160, 170, 100, 100, 150; RS-22: 150 (6E1 bis 6E4), 170 (20E1 bis 20E4) |
| Ist | Zahl (Anzeige) | °C / ° | RS-08: 150, 160, 170, 0, 0, 150; RS-22: 0 |
| Statustaste / Heizung | Umschalter | – | „Ausschalten“/„Einschalten“ (RS-08), „Ein“ (RS-22) |
| Meldung (nur RS-22) | Umschalter mit Häkchen | – | überwacht Funktion und Sollwertabweichung; separat deaktivierbar |
| State / Out (nur RS-22) | Status-LED | – | State: grau aus, grün Zieltemperatur erreicht, rot nicht bereit/Fehler; Out: Zustand des Ausgangs |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Zone aktiv | grüne Statustaste, Ist folgt Soll |
| Zone abgewählt | rote Taste „Einschalten“, Ist 0 °C |
| Fehler | State rot (RS-22) |
| Hinweis neues HMI | Zone aktiv/abgewählt/Fehler nicht nur über Farbe: Beschriftung der Statustaste bleibt, State-LED mit Text/Symbol (Konzeptanforderung, siehe RM-08-P05) |

## Verwendet auf Seiten (IDs)

- [RS-08](../Seiten/RS-08_Heissleim-Parameter.md) – Heißleim Parameter (6 Nennungen in den Elementtabellen)
- [RS-22](../Seiten/RS-22_Heizungen.md) – Heizungen (1 Nennung in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-24-P01 | RS-08 | 6 Zonen mit Soll/Ist/Status wie Tabelle | offen |
| RM-24-P02 | RS-22 | 12 Zonen, 6 Spalten, Zonenbeschriftung laut Bild | offen |
| RM-24-P03 | Einheiten | °C (RS-08), ° (RS-22) | offen |
| RM-24-P04 | Zustand nicht nur über Farbe | LED-Zustand zusätzlich über Text/Symbol (Konzeptanforderung; Referenz zeigt nur Farbe), vgl. RM-08-P05 | offen |
| RM-24-P05 | Verwendet-auf-Liste | alle 2 genannten Seiten verlinken zurück auf RM-24; Links lösen auf | offen |
