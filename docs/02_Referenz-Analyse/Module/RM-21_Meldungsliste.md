# RM-21 – Meldungsliste

## Funktion

Scrollbare Liste mit Zeilen, in den Meldungen farbcodiert (Grün Betriebsstatus Automatik, Gelb Hinweise und Statusmeldungen, Rot Störung oder sicherheitsrelevante Meldung, führt zum Stopp). Dazu vier Scrolltasten („an den Anfang“, „eine Seite hoch“, „eine Seite runter“, „ans Ende“) bzw. ein Rollbalken. Varianten: Meldearchiv [RS-37](../Seiten/RS-37_Meldearchiv.md) (Spalten Zeit, Ereignis „KO“, Beschreibung; mit Tasten Export, Liste leeren, Filter, Alle anzeigen), Meldeanzeige [RS-38](../Seiten/RS-38_Meldeanzeige.md) (Spalten Nummer, Meldung; Rollbalken) und Variablenliste [RS-36](../Seiten/RS-36_Service.md) (scrollbare Auswahlliste, „500 von 111427 Variablen“, markierte Zeile blau).

Entsprechung im Design: keine (Element nur in der Referenz).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Zeit | Datum/Uhrzeit (nur RS-37) | tt.mm.jjjj hh:mm:ss | z. B. 05.05.2025 10:13:55 |
| Ereignis | Text (nur RS-37) | – | Bild „KO“ (vermutlich „kommend“) |
| Nummer | Zahl | – | in Sternchen, z. B. *120*, *081*, *000*, *090* |
| Beschreibung / Meldung | Text | – | z. B. „Störung Hauptantrieb 1MA1“, „Maschine ist bereit“ |
| Zeilenfarbe | Farbcode | – | rot / gelb / grün |
| Sortierung | Verhalten | – | im Bild absteigend nach Nummer bzw. Zeit |
| Scrolltasten | 4 Tasten oder Rollbalken | – | Seitenweise Blättern, Anfang, Ende |
| Auswahl (Variante RS-36) | Zeile markierbar | – | markierte Zeile blau; Mehrfachauswahl nicht beschrieben |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Normal | Zeilen farbig nach Klasse |
| Gefiltert | Taste „Filter“ nach Zeit oder Meldenummer; „Alle anzeigen“ hebt auf (RS-37) |
| Leer | nach „Liste leeren“; Sicherheitsabfrage nicht beschrieben |
| Hinweis neues HMI | Klasse zusätzlich über Symbol oder Text |

## Verwendet auf Seiten (IDs)

- [RS-36](../Seiten/RS-36_Service.md) – Service (1 Nennung in den Elementtabellen)
- [RS-37](../Seiten/RS-37_Meldearchiv.md) – Meldearchiv (3 Nennungen in den Elementtabellen)
- [RS-38](../Seiten/RS-38_Meldeanzeige.md) – Meldeanzeige (5 Nennungen in den Elementtabellen)
- [RS-39](../Seiten/RS-39_System-und-Antriebsinfos.md) – System- und Antriebsinfos (1 Nennung in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-21-P01 | RS-37 | Spalten Zeit, Ereignis, Beschreibung; 4 Tasten laut Tabelle 47 | offen |
| RM-21-P02 | RS-38 | Nummer und Meldung; Farbcodierung wie Handbuch | offen |
| RM-21-P03 | RS-36 | Variablenliste mit Auswahl, Tasten Importieren/Exportieren | offen |
| RM-21-P04 | Farbcodierung | Grün/Gelb/Rot nach Handbuchtext | offen |
| RM-21-P05 | Verwendet-auf-Liste | alle 4 genannten Seiten verlinken zurück auf RM-21; Links lösen auf | offen |
