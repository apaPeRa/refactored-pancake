# RM-16 – Motorparameter-Karte

## Funktion

Karte mit Überschrift und Zeilen aus Beschriftung und Eingabefeld ([RM-05](RM-05_Eingabefeld-mit-Schluesselsymbol.md)) für die Bewegungsparameter eines Schneckendosierers. Zwei Kartentypen: „Verschluss Zu“ / „Verschluss Auf“ (je 5 Zeilen) und „Schnecke“ (3 Zeilen, mit Schnecken-Symbol). Die Seite besteht aus drei Karten (10 + 3 = 13 Felder). Handbuchzweck: „Bewegungsparameter für den Verschluss und die Schnecke eines Schneckendosierers“ (RS-12, RS-17, RS-20, textgleich und mit byteidentischem Bild).

Entsprechung im Design: keine (Element nur in der Referenz).

Struktur: Karte = [RM-15](RM-15_Gruppenrahmen.md) mit Überschrift, Zeilen aus [RM-05](RM-05_Eingabefeld-mit-Schluesselsymbol.md); eigen ist nur die feste Parameterzusammenstellung (Verschluss/Schnecke).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Kartenüberschrift | Text | – | „Verschluss Zu“, „Verschluss Auf“, „Schnecke“ |
| Position (nur Verschluss) | Zahl | ° | Bild: Zu 0 °, Auf 37 °; „Position in Grad, an der der Verschluss geöffnet bzw. geschlossen ist.“ |
| Geschwindigkeit (nur Verschluss) | Zahl | % | Bild: 80 %; „Bewegungsgeschwindigkeit des Aktors in Prozent.“ |
| Beschleunigung | Zahl | % | Bild 0 %; Verschluss: „Anstieg der Geschwindigkeit beim Start der Bewegung“; Schnecke: „Anstieg der Drehgeschwindigkeit beim Start“ |
| Verzögerung | Zahl | % | Bild 0 %; Verschluss: „Abbremsen vor Erreichen der Endposition“; Schnecke: „Abbremsen der Drehung beim Stoppen“ |
| Ruck | Zahl | % | Bild 0 %; „Änderung der Beschleunigung“ (sanfter Bewegungsbeginn/-ende bzw. produktschonend) |
| Bezug | Dosierer | – | gilt für den Dosierer, von dem die Seite geöffnet wurde (Titel „Motorparameter HD1“) |
| Wertebereiche | – | – | Im Handbuch nicht angegeben |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Standard | drei Karten, alle Felder mit Schlüssel und roter Schrift |
| Eingabe | Eingabe-Pop-up nicht beschrieben (A-20) |
| Kartentyp | Verschluss (5 Zeilen) oder Schnecke (3 Zeilen + Symbol) |

## Verwendet auf Seiten (IDs)

- [RS-12](../Seiten/RS-12_Motorparameter.md) – Motorparameter (Hauptdosierer) (9 Nennungen in den Elementtabellen)
- [RS-17](../Seiten/RS-17_Motorparameter-Schliessmaschine.md) – Motorparameter (Schließmaschine) (2 Nennungen in den Elementtabellen)
- [RS-20](../Seiten/RS-20_Motorparameter.md) – Motorparameter (Nachdosierer) (10 Nennungen in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-16-P01 | Karten | „Verschluss Zu“, „Verschluss Auf“ je 5 Felder; „Schnecke“ 3 Felder | offen |
| RM-16-P02 | Einheiten | Position °, übrige % | offen |
| RM-16-P03 | Wiederverwendung | RS-12, RS-17 und RS-20 nutzen dieselbe Definition (Seitentitel „HD1“ bzw. Dosierername variiert) | offen |
| RM-16-P04 | Zugang | über Taste „Motorparameter“ in RS-11/RS-19 (RS-17: Elternseite unklar, A-11) | offen |
| RM-16-P05 | Verwendet-auf-Liste | alle 3 genannten Seiten verlinken zurück auf RM-16; Links lösen auf | offen |
