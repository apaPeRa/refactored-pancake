# RS-16 – Schließmaschine
- Quelle: `src_Data/Referenz/Referenz.docx`, Kapitel „Schließmaschine“ (Ebene 2, Nr. 16); Bild [RS-16_01](../Medien/RS-16_01.png) (Originaldatei `image41.png`); Tabellen T22, T23, T24
- Navigationspfad: Einstellung › Schließmaschine (Eintrag in der Seite Einstellungen [RS-04](RS-04_Einstellungen.md))

## Zweck
Wortgetreu: „Auf der Seite Schließmaschine sind die Einstellungen für das Auslaufband, den Kopfleim und der Rüttlung zu finden.“ (RS-04 beschreibt den Eintrag: „Hier sind die Einstellungen für den Kopfleim, die Rüttlung und des Auslaufbands untergebracht.“)

## Aufbau (Bereiche, Layout)
Das Seitenbild [RS-16_01](../Medien/RS-16_01.png) (Bildschirm 4:3, blauer Hintergrund, drei graue Gruppenfelder) zeigt:

- **Kopfzeile** (hellgrau): links Logo „APA-TEC GmbH AUTOMATION AND PACKAGING TECHNOLOGY“; Mitte Seitentitel „Schließmaschine“ (fett, unterstrichen); rechts daneben ein rundes Symbol (zwei ineinander verschlungene Wirbel, Bedeutung im Handbuch nicht erklärt); ganz rechts Uhrzeit „13:03:21“ (groß) und darunter Datum „12.05.2025“ (klein).
- **Linke Spalte, oben:** Gruppenfeld „Auslaufband“ (Überschrift fett) mit Beschriftung „Geschwindigkeit:“ und einem weißen Zahlenfeld mit rotem Wert „50 %“ und gelbem Schlüsselsymbol in der oberen rechten Ecke. Darunter ist die linke Spalte leer (blau).
- **Rechte Spalte, oben:** Gruppenfeld „Kopfleim“ mit einer breiten grünen Taste „Ein“ (gelbes Schlüsselsymbol oben rechts), darunter drei Zahlenfelder mit Schlüsselsymbol: „Anfang:“ „280 °“, „Ende:“ „325 °“, „Dauer:“ „50 ms“. Links neben den Feldern ein Piktogramm (grauer Block mit zwei nach unten gerichteten Düsen, Leimventil/Kopfleimdüsen).
- **Rechte Spalte, unten:** Gruppenfeld „Rüttlung“ mit breiter grüner Taste „Ein“ (Schlüsselsymbol), darunter „Rüttlung 1:“ „25 %“ und „Rüttlung 2:“ „25 %“ (jeweils mit Schlüsselsymbol).
- **Meldezeile** (rot, volle Breite): „\*450\* Palettierung nicht bereit“.
- **Untere Funktionsleiste** (hellgrau), von links nach rechts: Taste „Heißleimgerät“ (ohne Symbol); in der Mitte ein gelbes, geschlossenes Vorhängeschloss-Symbol; Tasten „Produktion“ (Haus-Symbol), „Einstellungen“ (Zahnrad-Symbol), „Zurück“ (Pfeil-in-Rücktaste-Symbol).

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Quelle der Funktionsbeschreibung: Handbuchtabellen T22–T24 (Spalten „Funktion | Beschreibung“), wortgetreu. Einheiten, Standardwerte und Wertebereiche sind im Handbuch nicht angegeben; die Einheiten stammen aus dem Bild (Beispielwerte, keine Standardwerte).

### T22 – Auslaufband (2 Zeilen inkl. Kopfzeile)
| Element (Funktion) | Typ | Funktion (Beschreibung wortgetreu) | verwendetes Modul |
|---|---|---|---|
| Geschwindigkeit | Zahlenfeld mit Schlüsselsymbol, Einheit % (Bild: 50 %) | Sollgeschwindigkeit des Auslaufbands. | [RM-05](../Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) (Pop-up-Eingabe) |

### T23 – Kopfleim (5 Zeilen inkl. Kopfzeile)
| Element (Funktion) | Typ | Funktion (Beschreibung wortgetreu) | verwendetes Modul |
|---|---|---|---|
| Taste Ein / Aus | Umschalttaste, Anzeige „Ein“ auf grünem Grund (Bild), mit Schlüsselsymbol | Erlaubt das Abwählen des Kopfleims. | [RM-10](../Module/RM-10_Umschalter-Taste.md) Ein/Aus |
| Anfang | Zahlenfeld mit Schlüsselsymbol, Einheit ° (Bild: 280 °) | Beginn der Nocke für den Kopfleim. | [RM-05](../Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) (Pop-up-Eingabe); [RM-20](../Module/RM-20_Nocken-Parameterzeile.md) (Anfang/Ende/Dauer) |
| Ende | Zahlenfeld mit Schlüsselsymbol, Einheit ° (Bild: 325 °) | Ende der Nocke für den Kopfleim. | wie „Anfang“ |
| Dauer | Zahlenfeld mit Schlüsselsymbol, Einheit ms (Bild: 50 ms) | Einschaltdauer des Ventils. Benötigt die Nocke länger, aufgrund einer reduzierten Maschinengeschwindigkeit, wird das Ventil getaktet. Damit wird die Menge an Heißleim reduziert. | wie „Anfang“ |

### T24 – Rüttlung (3 Zeilen inkl. Kopfzeile)
| Element (Funktion) | Typ | Funktion (Beschreibung wortgetreu) | verwendetes Modul |
|---|---|---|---|
| Taste Ein / Aus | Umschalttaste, Anzeige „Ein“ auf grünem Grund (Bild), mit Schlüsselsymbol | Erlaubt das Abwählen der Rüttlung. Schaltet beide Rüttlungen ab. | [RM-10](../Module/RM-10_Umschalter-Taste.md) Ein/Aus |
| Rüttlung 1 / 2 | zwei Zahlenfelder „Rüttlung 1:“ (Bild: 25 %) und „Rüttlung 2:“ (Bild: 25 %) mit Schlüsselsymbol, Einheit % | Intensität der Rüttlung. | [RM-05](../Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) (Pop-up-Eingabe) |

### Rahmenelemente laut Bild (nicht im Text beschrieben)
| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Logo APA-TEC | Grafik | im Handbuch nicht beschrieben | [RM-01](../Module/RM-01_Kopfzeile.md) (Kopfzeile) |
| Seitentitel „Schließmaschine“ | Text | Seitenname | [RM-01](../Module/RM-01_Kopfzeile.md) (Kopfzeile) |
| Rundes Wirbelsymbol | Symbol | im Handbuch nicht beschrieben | [RM-01](../Module/RM-01_Kopfzeile.md) (Kopfzeile) |
| Uhrzeit 13:03:21, Datum 12.05.2025 | Anzeige | im Handbuch nicht beschrieben | [RM-01](../Module/RM-01_Kopfzeile.md) (Kopfzeile) |
| Meldezeile „\*450\* Palettierung nicht bereit“ | Anzeige (rot) | im Handbuch nicht beschrieben | [RM-02](../Module/RM-02_Meldezeile.md) |
| Taste „Heißleimgerät“ | Taste | im Handbuch nicht beschrieben; Sprungziel unklar (vermutlich Heißleim-Seite, nicht belegt) | [RM-03](../Module/RM-03_Funktionsleiste-unten.md) (seitenspezifische Taste) |
| Schloss-Symbol (gelb, geschlossen) | Symbol | im Handbuch nicht beschrieben (Bedienberechtigung/Sperre?) | [RM-03](../Module/RM-03_Funktionsleiste-unten.md) (Schloss/Berechtigung) |
| Taste „Produktion“ (Haus) | Taste | im Handbuch nicht beschrieben (Name; Sprung zu RS-01 anzunehmen) | [RM-03](../Module/RM-03_Funktionsleiste-unten.md) |
| Taste „Einstellungen“ (Zahnrad) | Taste | im Handbuch nicht beschrieben (Sprung zu RS-04 anzunehmen) | [RM-03](../Module/RM-03_Funktionsleiste-unten.md) |
| Taste „Zurück“ | Taste | im Handbuch nicht beschrieben | [RM-03](../Module/RM-03_Funktionsleiste-unten.md) |

Erfasst: 3 Handbuchtabellen mit zusammen 7 Datenzeilen (1 + 4 + 2; ohne Kopfzeilen) bzw. 10 Tabellenzeilen inkl. Kopfzeilen; 1 Bild.

## Verwendete Module (IDs)

Module dieser Seite (Definitionen in der [Modulliste](../Module/Modulliste.md)):

- [RM-01](../Module/RM-01_Kopfzeile.md) – Kopfzeile
- [RM-02](../Module/RM-02_Meldezeile.md) – Meldezeile
- [RM-03](../Module/RM-03_Funktionsleiste-unten.md) – Funktionsleiste unten
- [RM-05](../Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) – Eingabefeld mit Schlüsselsymbol
- [RM-06](../Module/RM-06_Eingabe-Pop-up.md) – Eingabe-Pop-up
- [RM-10](../Module/RM-10_Umschalter-Taste.md) – Umschalter-Taste
- [RM-15](../Module/RM-15_Gruppenrahmen.md) – Gruppenrahmen
- [RM-20](../Module/RM-20_Nocken-Parameterzeile.md) – Nocken-Parameterzeile

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- Zahlenfelder mit gelbem Schlüsselsymbol: Das Schlüsselsymbol deutet auf eine berechtigungsgeschützte Eingabe hin; im Handbuch ist weder Bedeutung noch Berechtigungsstufe noch ein Eingabe-Pop-up beschrieben. Pop-ups oder Unterseiten dieser Seite: keine beschrieben.
- Tasten „Ein“/„Aus“ (Kopfleim, Rüttlung): Im Bild Zustand „Ein“ grün. Die Darstellung des Zustands „Aus“ ist nicht gezeigt/beschrieben. „Rüttlung“-Taste schaltet beide Rüttlungen ab.
- Kopfleim „Dauer“: Wird die Nocke länger als die Einschaltdauer benötigt (reduzierte Maschinengeschwindigkeit), wird das Ventil getaktet, die Heißleimmenge sinkt.
- Wertebereiche, Standardwerte, Fehler-/Grenzwertmeldungen: im Handbuch nicht angegeben.
- Navigation: Brotkrümel Einstellung › Schließmaschine; Rücksprung über „Zurück“, Wechsel über „Produktion“ und „Einstellungen“ in der unteren Leiste. Eine „Navigation (unten links)“ zu Unterseiten (Motorparameter [RS-17](RS-17_Motorparameter-Schliessmaschine.md), Gewichtskorrektur [RS-18](RS-18_Gewichtskorrektur-Schliessmaschine.md)) ist auf dieser Seite weder im Text noch im Bild vorhanden; die einzige seitenspezifische Taste unten links heißt „Heißleimgerät“.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RS-16-P01 | Seitentitel und Brotkrümel | Titel „Schließmaschine“, Pfad Einstellung › Schließmaschine | offen |
| RS-16-P02 | Gruppenfelder | Drei Gruppen „Auslaufband“, „Kopfleim“, „Rüttlung“ vorhanden | offen |
| RS-16-P03 | Auslaufband: Geschwindigkeit | Eingabefeld „Geschwindigkeit:“ in %, Sollgeschwindigkeit des Auslaufbands, Beispielwert 50 % | offen |
| RS-16-P04 | Kopfleim: Taste Ein/Aus | Umschalttaste mit Zustand Ein (grün) und Aus; erlaubt das Abwählen des Kopfleims | offen |
| RS-16-P05 | Kopfleim: Anfang | Eingabe in ° (Beispiel 280 °), Beginn der Nocke für den Kopfleim | offen |
| RS-16-P06 | Kopfleim: Ende | Eingabe in ° (Beispiel 325 °), Ende der Nocke für den Kopfleim | offen |
| RS-16-P07 | Kopfleim: Dauer | Eingabe in ms (Beispiel 50 ms), Einschaltdauer des Ventils | offen |
| RS-16-P08 | Kopfleim: Taktung | Benötigt die Nocke bei reduzierter Maschinengeschwindigkeit länger als die Dauer, wird das Ventil getaktet und die Heißleimmenge reduziert | offen |
| RS-16-P09 | Rüttlung: Taste Ein/Aus | Schaltet beide Rüttlungen ab bzw. ein | offen |
| RS-16-P10 | Rüttlung 1 / 2 | Zwei Eingaben in % (Beispiel je 25 %), Intensität der Rüttlung | offen |
| RS-16-P11 | Schlüsselsymbole | Alle Eingabefelder und beide Ein/Aus-Tasten tragen das Schlüsselsymbol (Berechtigung) | offen |
| RS-16-P12 | Untere Leiste | Tasten Heißleimgerät, Produktion, Einstellungen, Zurück sowie Schloss-Symbol vorhanden | offen |
| RS-16-P13 | Kopfzeile und Meldezeile | Logo, Titel, Uhrzeit/Datum, rote Meldezeile vorhanden | offen |
| RS-16-P14 | Medien | [RS-16_01](../Medien/RS-16_01.png) ist eingebunden und beschrieben | offen |

## Offene Punkte
1. Wertebereiche, Standardwerte und Berechtigungsstufen der Felder sind im Handbuch nicht angegeben.
2. Bedeutung des Schlüsselsymbols, des Schloss-Symbols und des Wirbelsymbols in der Kopfzeile ist nicht erklärt.
3. Sprungziel der Taste „Heißleimgerät“ ist nicht beschrieben.
4. Darstellung der Tasten im Zustand „Aus“ ist nicht gezeigt.
5. Die Seiten Motorparameter (RS-17) und Gewichtskorrektur (RS-18) folgen im Handbuch auf diese Seite, sind aber von hier nicht erreichbar beschrieben (Annahme A-11).
6. „Einstellungen“-Beschreibung in RS-04 nennt „Kopfleim, Rüttlung und Auslaufband“ in anderer Reihenfolge; Seite im Bild zeigt Auslaufband zuerst (kein Widerspruch, nur Hinweis).
