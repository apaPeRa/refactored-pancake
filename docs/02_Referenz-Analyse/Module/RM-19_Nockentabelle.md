# RM-19 – Nockentabelle

## Funktion

Tabelle aller Nocken des elektronischen Nockenschaltwerks mit den Spalten Nr., Bezeichnung, Start, Ende und Status-LED. Antippen der Nockennummer öffnet die Einstellseite der Nocke ([RS-25](../Seiten/RS-25_Nocken.md)). Bild: 20 Zeilen, Nr. 40 bis 59 (z. B. 40 „Start Hauptdoserer 1“ 290 °/130 °, 47 „Fehlpaketausstoß hinten 14B10“ 120 °/284 ° grün, 52 „Kopfleim 20KY21“ 280 °/325 °). Leere Nocken: Nr. 48, 50, 59 mit 0 °/0 °. Rechtschreibfehler in den Bezeichnungen („Hauptdoserer“, „Fehlaketausstoß“) stehen so im Bild.

Entsprechung im Design: keine (Element nur in der Referenz).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Nr. | Zahl, antippbar | – | 40 bis 59 im Bild; Typ-Bereich des Handbuchs 0 bis 1079 (RS-25, Feld „Typ“) |
| Bezeichnung | Text, nur Anzeige | – | im Handbuchtext nicht beschrieben, nur im Bild |
| Start | Zahl, nur Anzeige | ° | Startposition bezogen auf den Maschinenwinkel; 0 bis 360 im Bild |
| Ende | Zahl, nur Anzeige | ° | Endposition bezogen auf den Maschinenwinkel |
| LED | Status-LED | – | grün = Maschine befindet sich in der aktiven Phase der Nocke, sonst grau |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Nocke inaktiv | LED grau |
| Nocke aktiv | LED grün (im Bild Nr. 45, 47, 54, 57, 58) |
| Leere Nocke | 0 °/0 °, ohne Bezeichnung |
| Blättern | über [RM-04](RM-04_Blaettertasten.md) „<<“/„>>“; Wirkung nicht beschrieben |
| Hinweis neues HMI | LED-Zustand (aktive Nockenphase) nicht nur über Farbe (Konzeptanforderung, siehe RM-08-P05) |

## Verwendet auf Seiten (IDs)

- [RS-26](../Seiten/RS-26_Nockenuebersicht.md) – Nockenübersicht (4 Nennungen in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-19-P01 | Spalten | Nr., Bezeichnung, Start, Ende, LED | offen |
| RM-19-P02 | Zeilenzahl | 20 Zeilen (Nr. 40 bis 59) wie im Bild | offen |
| RM-19-P03 | Sprung | Antippen der Nr. öffnet RS-25 (Handbuch) | offen |
| RM-19-P04 | LED-Bedeutung | grün = aktive Phase | offen |
| RM-19-P05 | Zustand nicht nur über Farbe | LED-Zustand zusätzlich über Text/Symbol (Konzeptanforderung; Referenz zeigt nur Farbe), vgl. RM-08-P05 | offen |
| RM-19-P06 | Verwendet-auf-Liste | alle 1 genannten Seiten verlinken zurück auf RM-19; Links lösen auf | offen |
