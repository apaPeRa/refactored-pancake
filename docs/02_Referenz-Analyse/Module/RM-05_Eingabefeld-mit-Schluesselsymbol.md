# RM-05 – Eingabefeld mit Schlüsselsymbol

## Funktion

Weißes Wertfeld mit roter Schrift und kleinem gelbem Schlüsselsymbol an der oberen rechten Ecke zur Eingabe eines Einstellwerts; das häufigste Element der Referenz. Beschriftung links (rechtsbündig vor dem Feld), optional ein Symbol (z. B. Tacho). Das Handbuch erklärt weder Schlüsselsymbol noch Eingabeweg; die Deutung „berechtigungspflichtiges Feld, Eingabe über Pop-up“ ist Annahme (A-20, [RM-06](RM-06_Eingabe-Pop-up.md)). Dieses Modul umfasst auch das „Dosierer-Parameterfeld“ (RS-11, RS-12, RS-19, RS-20), das Eingabefeld ohne Schlüssel (RS-03 „Schnell“, „Langsam“; Nummer in RS-25) und das Textfeld (RS-25 „Bezeichnung“, RS-36). Schwarze, schreibgeschützte Felder sind [RM-07](RM-07_Anzeigefeld.md).

Entsprechung im Design: [DM-17](../../01_Design-Analyse/Module/DM-17_Eingabefeld-mit-Schluesselsymbol.md), [DM-15](../../01_Design-Analyse/Module/DM-15_Beschriftung-Wert-Zeile.md).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Beschriftung | Text | – | z. B. „Ziel Füllstand:“, „Durchmesser Max.:“, „Anfang:“ |
| Wert | Zahl (Dezimalkomma), Text bei Variante Text | siehe Einheit | Wertebereich je Feld: Im Handbuch nicht angegeben; Beispielwerte in den Seiten |
| Einheit | Aufzählung | %, °, ms, s, g, Stk, 1/min, °C, bar, ohne Einheit | Beispiele: 50 % (RS-07), 290 ° (RS-05), 20 ms (RS-06), 60 s (RS-07), 235,0 g (RS-13), 5000 Stk (RS-13), 125 1/min (RS-03), 150 °C (RS-08), 1,7 bar (RS-09), 4 ohne Einheit (RS-11 Eichdosierung Umdrehungen) |
| Nachkommastellen | Zahl | – | 0 bis 3 im Bild: 137,50 g (2, RS-11), 250,4 g (1, RS-18), -2596,261 (3, nur Anzeige, RS-32) |
| Min / Max | Zahl | wie Wert | Im Handbuch nicht angegeben |
| Berechtigung | Rolle / Symbol | – | gelbes Schlüsselsymbol; erforderliche Rolle nicht angegeben |
| Symbol vor dem Feld | Grafik, optional | – | z. B. Tacho-Symbol (RS-11, RS-19), Packungs-Symbole (RS-13) |
| Zusatzzähler | Zahl klein, unten rechts im Feld, optional | Stk | RS-13 „Automatischer Nullpunkt“ (Packungen seit letztem Nullpunkt) |
| Gekoppelter Zähler | Zählfeld unter dem Feld, optional | Stk | RS-13 „Übergewicht“, „Untergewicht TU 1“, „Untergewicht TU 2“ |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Berechtigt, Anzeige | weißes Feld, rote Schrift, gelber Schlüssel (Bild) |
| Ohne Schlüssel | weißes Feld, rote Schrift, ohne Symbol (RS-03 „Schnell“, „Langsam“; RS-25 „Nummer“) |
| Eingabe aktiv | nicht beschrieben; Annahme: Eingabe-Pop-up [RM-06](RM-06_Eingabe-Pop-up.md) |
| Nicht berechtigt | im Bild nicht dargestellt; Annahme: Wert sichtbar, Eingabe gesperrt, Zustand über Symbol/Text, nicht nur Farbe |
| Ungültige Eingabe | nicht beschrieben; Annahme: Meldung mit Text |
| Hinweis neues HMI | Rot gilt im neuen HMI nur für Alarm; Eingabewerte werden anders abgesetzt (Agent.md Abschnitt 6) |

## Verwendet auf Seiten (IDs)

- [RS-03](../Seiten/RS-03_Maschinengeschwindigkeit.md) – Maschinengeschwindigkeit (Pop-up) (5 Nennungen in den Elementtabellen)
- [RS-05](../Seiten/RS-05_Zufuehrung-Papier.md) – Zuführung Papier (9 Nennungen in den Elementtabellen)
- [RS-06](../Seiten/RS-06_Zufuehrung-Karton.md) – Zuführung Karton (3 Nennungen in den Elementtabellen)
- [RS-07](../Seiten/RS-07_Heissleim-Nordson.md) – Heißleim Nordson (2 Nennungen in den Elementtabellen)
- [RS-08](../Seiten/RS-08_Heissleim-Parameter.md) – Heißleim Parameter (4 Nennungen in den Elementtabellen)
- [RS-09](../Seiten/RS-09_Heissleim-Druck.md) – Heißleim Druck (8 Nennungen in den Elementtabellen)
- [RS-10](../Seiten/RS-10_Zeitschaltuhr.md) – Zeitschaltuhr (1 Nennung in den Elementtabellen)
- [RS-11](../Seiten/RS-11_Hauptdosierer-1-und-2.md) – Hauptdosierer 1 & 2 (9 Nennungen in den Elementtabellen)
- [RS-12](../Seiten/RS-12_Motorparameter.md) – Motorparameter (Hauptdosierer) (genannt im Abschnitt „Verwendete Module“)
- [RS-13](../Seiten/RS-13_Kontrollwaage.md) – Kontrollwaage (6 Nennungen in den Elementtabellen)
- [RS-16](../Seiten/RS-16_Schliessmaschine.md) – Schließmaschine (3 Nennungen in den Elementtabellen)
- [RS-17](../Seiten/RS-17_Motorparameter-Schliessmaschine.md) – Motorparameter (Schließmaschine) (2 Nennungen in den Elementtabellen)
- [RS-18](../Seiten/RS-18_Gewichtskorrektur-Schliessmaschine.md) – Gewichtskorrektur (Schließmaschine) (1 Nennung in den Elementtabellen)
- [RS-19](../Seiten/RS-19_Nachdosierer.md) – Nachdosierer (10 Nennungen in den Elementtabellen)
- [RS-20](../Seiten/RS-20_Motorparameter.md) – Motorparameter (Nachdosierer) (genannt im Abschnitt „Verwendete Module“)
- [RS-21](../Seiten/RS-21_Gewichtskorrektur.md) – Gewichtskorrektur (Nachdosierer) (2 Nennungen in den Elementtabellen)
- [RS-22](../Seiten/RS-22_Heizungen.md) – Heizungen (1 Nennung in den Elementtabellen)
- [RS-23](../Seiten/RS-23_Regulierung.md) – Regulierung (5 Nennungen in den Elementtabellen)
- [RS-25](../Seiten/RS-25_Nocken.md) – Nocken (3 Nennungen in den Elementtabellen)
- [RS-27](../Seiten/RS-27_Waagen-Kalibrieren.md) – Waagen Kalibrieren (1 Nennung in den Elementtabellen)
- [RS-31](../Seiten/RS-31_Handbetrieb.md) – Handbetrieb (3 Nennungen in den Elementtabellen)
- [RS-36](../Seiten/RS-36_Service.md) – Service (1 Nennung in den Elementtabellen)
- [RS-39](../Seiten/RS-39_System-und-Antriebsinfos.md) – System- und Antriebsinfos (1 Nennung in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-05-P01 | Rote Schrift und Schlüssel | jedes Feld mit Schlüssel in der Quelle hat Beschriftung, Wert, Einheit und Schlüsselsymbol | offen |
| RM-05-P02 | Einheiten | Einheit je Feld stimmt mit der Seite überein (Stichprobe: RS-05, RS-07, RS-09, RS-13) | offen |
| RM-05-P03 | Abgrenzung | schwarze Felder ohne Schlüssel sind RM-07, nicht RM-05 | offen |
| RM-05-P04 | Varianten | Feld ohne Schlüssel (RS-03, RS-25) und Textfeld (RS-25, RS-36) als Parameter, nicht als eigenes Modul | offen |
| RM-05-P05 | Eingabe | Antippen eines Feldes führt zu RM-06 (Annahme); nicht berechtigt: kein Pop-up | offen |
| RM-05-P06 | Verwendet-auf-Liste | alle 23 genannten Seiten verlinken zurück auf RM-05; Links lösen auf | offen |
