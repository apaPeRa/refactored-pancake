# RM-14 – Kachel-Navigation

## Funktion

Raster aus grauen, rechteckigen Kacheltasten mit fetter, zentrierter, ein- bis mehrzeiliger Beschriftung; Antippen öffnet die zugehörige Seite oder Funktion. Einsatz: [RS-04](../Seiten/RS-04_Einstellungen.md) (5 Spalten × 4 Zeilen, 20 Kacheln, 18 beschriftet, 2 leer), [RS-30](../Seiten/RS-30_Handbetrieb-Auswahl.md) (4 × 4, 14 Gruppentasten „GR1 Hauptantrieb“ bis „GR100 Schnittstelle“), [RS-33](../Seiten/RS-33_EA-Uebersicht.md) (4 × 2, 6 EA-Kacheln) und [RS-35](../Seiten/RS-35_Systemeinstellungen.md) (3 × 3, 8 Funktionskacheln, teils mit Schlüsselsymbol).

Entsprechung im Design: [DM-12](../../01_Design-Analyse/Module/DM-12_Kachel-Taste.md).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Beschriftung | Text | – | z. B. „Zuführung Papier“, „Hauptdosierer“, „GR41 Hauptdosierer 1“, „Bedienung beenden“ |
| Raster | Spalten × Zeilen | – | 5 × 4 (RS-04), 4 × 4 (RS-30), 4 × 2 (RS-33), 3 × 3 (RS-35) |
| Ziel | Seiten-ID oder Funktion | – | Navigation (RS-04, RS-30, RS-33, RS-35 Meldearchiv/Service/Antriebsinfo) oder Aktion (RS-35 Bedienung beenden/minimieren, Steuerung neu starten/ausschalten, Taskmanager) |
| Schlüsselsymbol | Boolean | – | RS-35: sechs Tasten mit Schlüssel (laut Seite) |
| Leer / inaktiv | Boolean | – | RS-04: 2 leere Kacheln (Z2/S2, Z2/S3); RS-30: 2 leere; RS-35: 1 leere |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Aktiv | graue Kachel (einziger Zustand im Bild) |
| Leer / inaktiv | unbeschriftet, ohne Funktion |
| Gesperrt | nicht dargestellt (Annahme: bei fehlender Berechtigung gekennzeichnet) |
| Warnaktionen | RS-35 „Steuerung neu starten/ausschalten“: Handbuch warnt vor Anlagenstopp; Bestätigungsdialog nicht beschrieben |

## Verwendet auf Seiten (IDs)

- [RS-04](../Seiten/RS-04_Einstellungen.md) – Einstellungen (20 Nennungen in den Elementtabellen)
- [RS-30](../Seiten/RS-30_Handbetrieb-Auswahl.md) – Handbetrieb Auswahl (1 Nennung in den Elementtabellen)
- [RS-33](../Seiten/RS-33_EA-Uebersicht.md) – EA-Übersicht (1 Nennung in den Elementtabellen)
- [RS-35](../Seiten/RS-35_Systemeinstellungen.md) – Systemeinstellungen (8 Nennungen in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-14-P01 | RS-04 | 18 beschriftete Kacheln wie Tabelle T4, 2 leere | offen |
| RM-14-P02 | RS-30 / RS-33 | 14 Gruppentasten bzw. 6 EA-Kacheln wie im Bild | offen |
| RM-14-P03 | RS-35 | 8 Funktionen laut Tabelle 45, Schlüsselsymbole laut Bild | offen |
| RM-14-P04 | Ziele | Ziel jeder Kachel stimmt mit der Referenz-Übersicht überein | offen |
| RM-14-P05 | Verwendet-auf-Liste | alle 4 genannten Seiten verlinken zurück auf RM-14; Links lösen auf | offen |
