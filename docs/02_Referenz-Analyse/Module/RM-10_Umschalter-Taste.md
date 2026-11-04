# RM-10 – Umschalter-Taste

## Funktion

Taste mit mindestens zwei Zuständen und Zustandsfarbe: grün = angewählt/ein, grau = abgewählt/aus (RS-01, RS-06, RS-11, RS-19) beziehungsweise grün/rot (RS-07, RS-08 Statustaste). Oft mit Schlüsselsymbol (RS-06, RS-11, RS-16, RS-19, RS-22, RS-23). Die Farbbedeutung erklärt das Handbuch nur für RS-01 („Ist die Schaltfläche grau, so ist mindestens eine Funktion abgewählt“, Automatik); sonst ist sie aus dem Bild abgeleitet (A-19). Hierzu zählen die 16 Funktionstasten von RS-01, die Anwahl-Tasten der Dosierer, Ein/Aus-Tasten und der Umschalter „Fortlaufend“/„Einzel“.

Entsprechung im Design: [DM-13](../../01_Design-Analyse/Module/DM-13_Umschalter.md), [DM-19](../../01_Design-Analyse/Module/DM-19_Zustandstaste.md).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Beschriftung | Text, ein- bis zweizeilig | – | z. B. „Maschine schnell“, „Querschnecke“, „Rührer“, „Regulierung aktiv“, „Heizungen“, „Standby“, „Pumpe“, „Zeitschaltuhr“, „Füllsystem“, „EIN“/„Ein“, „3Y25“ bis „3Y29“, „Fortlaufend“/„Einzel“ |
| Zustand | Boolean (oder Aufzählung) | – | angewählt / abgewählt; Zusatzwert „Einzel / Fortlaufend“ als zwei Modi |
| Zustandsfarbe | Farbcode | – | grün / grau oder grün / rot (Bedeutung teils nicht beschrieben) |
| Schlüsselsymbol | Boolean | – | wie bei RM-05; gelb oben rechts |
| Symbol | Grafik, optional | – | z. B. Häkchen (RS-22 „Meldung“) |
| Textumschaltung | Text je Zustand | – | „Ausschalten“/„Einschalten“ (RS-08 Zonentaste); „Ein“/„Aus“ (RS-06, RS-16, RS-22) |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Ein / angewählt | grün, im Bild beschriftet „Ein“ bzw. gewählt |
| Aus / abgewählt | grau oder rot; „Aus“-Darstellung der Ein/Aus-Tasten im Bild nicht abgebildet (RS-06, RS-16) |
| Auswirkung | z. B. „Automatik Produktion“ grau, sobald eine Funktion abgewählt ist (RS-01) |
| Nicht berechtigt | nicht beschrieben (Annahme: Taste wirkungslos, gekennzeichnet) |
| Hinweis neues HMI | Zustand zusätzlich über Text oder Symbol, nicht nur Farbe |

## Verwendet auf Seiten (IDs)

- [RS-01](../Seiten/RS-01_Produktion.md) – Produktion (17 Nennungen in den Elementtabellen)
- [RS-06](../Seiten/RS-06_Zufuehrung-Karton.md) – Zuführung Karton (2 Nennungen in den Elementtabellen)
- [RS-07](../Seiten/RS-07_Heissleim-Nordson.md) – Heißleim Nordson (5 Nennungen in den Elementtabellen)
- [RS-11](../Seiten/RS-11_Hauptdosierer-1-und-2.md) – Hauptdosierer 1 & 2 (3 Nennungen in den Elementtabellen)
- [RS-14](../Seiten/RS-14_Einzelgewichte.md) – Einzelgewichte (1 Nennung in den Elementtabellen)
- [RS-16](../Seiten/RS-16_Schliessmaschine.md) – Schließmaschine (2 Nennungen in den Elementtabellen)
- [RS-19](../Seiten/RS-19_Nachdosierer.md) – Nachdosierer (3 Nennungen in den Elementtabellen)
- [RS-22](../Seiten/RS-22_Heizungen.md) – Heizungen (2 Nennungen in den Elementtabellen)
- [RS-23](../Seiten/RS-23_Regulierung.md) – Regulierung (1 Nennung in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-10-P01 | RS-01 | 16 Tasten (4 × 4), grün/grau; Automatik grau, wenn eine Funktion abgewählt | offen |
| RM-10-P02 | RS-07 | Heizungen/Pumpe/Füllsystem grün, Standby/Zeitschaltuhr rot (Bild); Bedeutung nicht beschrieben | offen |
| RM-10-P03 | RS-06 | Anwahl Spülen 3Y25 bis 3Y29 grau (5 Tasten), Ein/Aus mit Schlüssel | offen |
| RM-10-P04 | RS-11 / RS-19 | Querschnecke, Rührer, Regulierung aktiv als Zustandstasten mit Schlüssel | offen |
| RM-10-P05 | Zustand erkennbar | Zustand ist ohne Farbe erkennbar (Text/Symbol) | offen |
| RM-10-P06 | Verwendet-auf-Liste | alle 9 genannten Seiten verlinken zurück auf RM-10; Links lösen auf | offen |
