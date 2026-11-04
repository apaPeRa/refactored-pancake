# RM-06 – Eingabe-Pop-up

## Funktion

Kleiner Dialog zur Eingabe eines Werts, der beim Antippen eines Eingabefelds ([RM-05](RM-05_Eingabefeld-mit-Schluesselsymbol.md)) erscheint. Das Handbuch beschreibt dieses Pop-up auf keiner Seite und es ist in keinem Bild abgebildet; die verwendenden Seiten (siehe unten) nennen es nur als Vermutung oder offenen Punkt (A-20). Alle folgenden Angaben sind Annahmen. Ein Rahmen wie bei den dokumentierten Pop-ups ([RM-13](RM-13_Pop-up-Rahmen.md)) ist zu erwarten.

Entsprechung im Design: keine (Element nur in der Referenz).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Titel | Text | – | Name des Felds (Annahme) |
| Aktueller Wert | Zahl oder Zeit | Einheit des Felds | übernommen aus dem Feld (Annahme) |
| Neuer Wert | Zahl; Variante Zeitwert hh:mm (RS-10) | Einheit des Felds | Im Handbuch nicht angegeben |
| Grenzen | Min / Max | Einheit des Felds | Im Handbuch nicht angegeben; Anzeige der Grenzen wäre sinnvoll (Annahme) |
| Tasten | Übernehmen, Abbrechen | – | Annahme; Beschriftung nicht belegt |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Geöffnet | Annahme: Zahlenfeld, aktueller Wert vorbelegt |
| Ungültiger Wert | nicht beschrieben; Annahme: Meldung, kein Übernehmen |
| Nicht berechtigt | nicht beschrieben; Annahme: Pop-up öffnet sich nicht |

## Verwendet auf Seiten (IDs)

- [RS-03](../Seiten/RS-03_Maschinengeschwindigkeit.md) – Maschinengeschwindigkeit (Pop-up) (genannt im Abschnitt „Verwendete Module“)
- [RS-05](../Seiten/RS-05_Zufuehrung-Papier.md) – Zuführung Papier (genannt im Abschnitt „Verwendete Module“)
- [RS-06](../Seiten/RS-06_Zufuehrung-Karton.md) – Zuführung Karton (genannt im Abschnitt „Verwendete Module“)
- [RS-07](../Seiten/RS-07_Heissleim-Nordson.md) – Heißleim Nordson (1 Nennung in den Elementtabellen)
- [RS-08](../Seiten/RS-08_Heissleim-Parameter.md) – Heißleim Parameter (genannt im Abschnitt „Verwendete Module“)
- [RS-09](../Seiten/RS-09_Heissleim-Druck.md) – Heißleim Druck (genannt im Abschnitt „Verwendete Module“)
- [RS-10](../Seiten/RS-10_Zeitschaltuhr.md) – Zeitschaltuhr (genannt im Abschnitt „Verwendete Module“)
- [RS-11](../Seiten/RS-11_Hauptdosierer-1-und-2.md) – Hauptdosierer 1 & 2 (genannt im Abschnitt „Verwendete Module“)
- [RS-12](../Seiten/RS-12_Motorparameter.md) – Motorparameter (Hauptdosierer) (genannt im Abschnitt „Verwendete Module“)
- [RS-13](../Seiten/RS-13_Kontrollwaage.md) – Kontrollwaage (6 Nennungen in den Elementtabellen)
- [RS-16](../Seiten/RS-16_Schliessmaschine.md) – Schließmaschine (genannt im Abschnitt „Verwendete Module“)
- [RS-17](../Seiten/RS-17_Motorparameter-Schliessmaschine.md) – Motorparameter (Schließmaschine) (genannt im Abschnitt „Verwendete Module“)
- [RS-18](../Seiten/RS-18_Gewichtskorrektur-Schliessmaschine.md) – Gewichtskorrektur (Schließmaschine) (genannt im Abschnitt „Verwendete Module“)
- [RS-19](../Seiten/RS-19_Nachdosierer.md) – Nachdosierer (genannt im Abschnitt „Verwendete Module“)
- [RS-20](../Seiten/RS-20_Motorparameter.md) – Motorparameter (Nachdosierer) (genannt im Abschnitt „Verwendete Module“)
- [RS-21](../Seiten/RS-21_Gewichtskorrektur.md) – Gewichtskorrektur (Nachdosierer) (genannt im Abschnitt „Verwendete Module“)
- [RS-22](../Seiten/RS-22_Heizungen.md) – Heizungen (1 Nennung in den Elementtabellen)
- [RS-23](../Seiten/RS-23_Regulierung.md) – Regulierung (1 Nennung in den Elementtabellen)
- [RS-25](../Seiten/RS-25_Nocken.md) – Nocken (1 Nennung in den Elementtabellen)
- [RS-37](../Seiten/RS-37_Meldearchiv.md) – Meldearchiv (1 Nennung in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-06-P01 | Dokumentationslage | Modul ist als Annahme gekennzeichnet; Handbuch und Bilder enthalten keinen Beleg | offen |
| RM-06-P02 | Verweise | jede verwendende Seite nennt das Pop-up als offenen Punkt | offen |
| RM-06-P03 | Neues HMI | Eingabe aller RM-05-Felder über ein einheitliches Pop-up festlegen (Phase 3) | offen |
| RM-06-P04 | Verwendet-auf-Liste | alle 20 genannten Seiten verlinken zurück auf RM-06; Links lösen auf | offen |
