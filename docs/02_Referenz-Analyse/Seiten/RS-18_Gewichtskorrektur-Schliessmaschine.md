# RS-18 – Gewichtskorrektur (Schließmaschine)
- Quelle: `src_Data/Referenz/Referenz.docx`, Kapitel „Gewichtskorrektur“ nach „Motorparameter“ (Ebene 2, Nr. 18); Bild [RS-18_01](../Medien/RS-18_01.png) (Originaldatei `image42.png`, identisch mit [RS-21_01](../Medien/RS-21_01.png)); keine Tabellen
- Navigationspfad: Einstellung › Schließmaschine › Gewichtskorrektur (Elternseite unklar, Annahme A-11; Handbuchposition nach [RS-17](RS-17_Motorparameter-Schliessmaschine.md))

## Zweck
Wortgetreu: „Diese Seite dient der Korrektur und Feinabstimmung der Dosiergenauigkeit von Schneckendosierern. Durch die Eingabe mehrerer Soll-Ist-Wertepaare werden sogenannte Stützstellen definiert. Daraus berechnet die Steuerung eine Korrekturkurve, mit der die Dosierleistung über den gesamten Gewichtsbereich verbessert wird.“ Inhaltlich identisch mit [RS-21](RS-21_Gewichtskorrektur-Nachdosierer.md).

## Aufbau (Bereiche, Layout)
Das Seitenbild [RS-18_01](../Medien/RS-18_01.png) (blauer Hintergrund) zeigt:

- **Kopfzeile:** Logo APA-TEC, Titel „Gewichtskorrektur“ (fett, unterstrichen), rundes Wirbelsymbol, Uhrzeit „13:03:35“, Datum „12.05.2025“.
- **Links und Mitte:** zwei nebeneinanderliegende Tabellen mit je zwei Spalten „SOLL“ und „IST“ (Spaltenüberschriften fett, schwarz) und je 10 Zeilen weißer Zahlenfelder mit rotem Wert (Einheit g, zwei Nachkommastellen); also 2 × 10 = 20 Soll-Ist-Paare. Linke Tabelle: Zeile 1 „18,00 g“ / „20,00 g“, Zeile 2 „22,00 g“ / „24,00 g“, Zeilen 3–10 „0,00 g“ / „0,00 g“. Rechte Tabelle: alle 10 Zeilen „0,00 g“ / „0,00 g“. Die Felder dieser Tabellen zeigen kein Schlüsselsymbol.
- **Rechts oben:** zwei graue Tasten untereinander: „Gewichtsanpassung“ und „Dosierer Auslösen manuell“.
- **Rechts darunter:** Beschriftung „Sollgewicht:“ mit Zahlenfeld „250,4 g“ (rot) und gelbem Schlüsselsymbol.
- **Meldezeile** (rot): „\*450\* Palettierung nicht bereit“.
- **Untere Funktionsleiste:** Schloss-Symbol (gelb), Tasten „Produktion“ (Haus), „Einstellungen“ (Zahnrad), „Zurück“; links keine Taste.

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Das Handbuch enthält keine Tabellen für diese Seite; die Funktionen stammen aus der nummerierten Anleitung und den Hinweisen (wortgetreu bzw. sinngemäß gekürzt gekennzeichnet).

| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Sollgewicht | Zahlenfeld mit Schlüsselsymbol, Einheit g (Bild: 250,4 g), rechts unten | „Geben Sie rechts unten das gewünschte Zielgewicht ein (*Sollgewicht*). Dieses Gewicht wird bei der manuellen Dosierung verwendet.“ | Modulkandidat: Eingabefeld mit Schlüsselsymbol (Pop-up-Eingabe) |
| Taste „Dosierer Auslösen manuell“ | Taste | „Verwenden Sie die Taste **Dosierer Auslösen manuell**, um eine Probe mit dem eingestellten Sollgewicht zu dosieren. Die Probe in einem Behälter auffangen und wiegen.“ | Modulkandidat: Funktionstaste |
| Spalte SOLL (2 × 10 Felder) | Zahlenfelder, Einheit g | „Tragen Sie das verwendete Sollgewicht in die linke Spalte (*SOLL*) ein“ | Modulkandidat: Gewichtskorrektur (Soll-Ist-Stützstellentabelle) |
| Spalte IST (2 × 10 Felder) | Zahlenfelder, Einheit g | „… und das gemessene tatsächliche Gewicht in die rechte Spalte (*IST*). Wiederholen Sie diesen Vorgang für mehrere Gewichte über den typischen Arbeitsbereich des Dosierers hinweg.“ | wie SOLL |
| Taste „Gewichtsanpassung“ | Taste | „Nachdem mehrere Stützstellen eingetragen wurden, drücken Sie die Taste **Gewichtsanpassung**. Die Steuerung erstellt daraus eine Korrekturkennlinie, mit der das Dosierergebnis automatisch an das tatsächliche Verhalten des Systems angepasst wird.“ | Modulkandidat: Funktionstaste |

### Bedienablauf (Handbuch, 4 Schritte)
1. Dosiergewicht einstellen (Sollgewicht rechts unten).
2. Manuelle Auslösung des Dosierers (Probe dosieren, auffangen, wiegen).
3. Wert eintragen (SOLL links, IST rechts; mehrere Gewichte über den typischen Arbeitsbereich).
4. Gewichtsanpassung berechnen (Taste „Gewichtsanpassung“).

### Hinweise zur optimalen Nutzung (Handbuch, 4 Aufzählungspunkte, wortgetreu)
- „Es sollten mindestens drei, besser fünf bis acht Stützstellen gleichmäßig über den gesamten Gewichtsbereich verteilt eingetragen werden.“
- „Die Werte sollten unter reproduzierbaren Bedingungen aufgenommen werden (z. B. gleiche Produkttemperatur, gleiche Füllhöhe).“
- „Tragen Sie nur gültige Messwerte ein – leere Felder bleiben unberücksichtigt.“
- „Diese Korrektur ist insbesondere bei nichtlinearer Dosiercharakteristik hilfreich (z. B. bei fein rieselnden oder klebrigen Produkten).“

### Rahmenelemente laut Bild
| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Kopfzeile | Anzeige | im Handbuch nicht beschrieben | Modulkandidat: Statuskopf (Kopfzeile) |
| Meldezeile „\*450\* Palettierung nicht bereit“ | Anzeige (rot) | im Handbuch nicht beschrieben | Modulkandidat: Meldezeile |
| Schloss-Symbol, Tasten Produktion, Einstellungen, Zurück | Symbol/Tasten | im Handbuch nicht beschrieben | Modulkandidat: Navigationsleiste unten |

Erfasst: 0 Handbuchtabellen; 4 Anleitungsschritte, 4 Hinweise, 2 Tasten, 1 Sollgewichtsfeld, 20 Soll-Ist-Paare (40 Felder) im Bild; 1 Bild.

## Verwendete Module (IDs)
Noch keine RM-IDs. Modulkandidaten: Gewichtskorrektur (Soll-Ist-Stützstellentabelle; wiederkehrend auf RS-18 und RS-21); Eingabefeld mit Schlüsselsymbol (Pop-up-Eingabe); Funktionstaste; Statuskopf; Meldezeile; Navigationsleiste unten.

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- Leere Felder bleiben bei der Berechnung unberücksichtigt (Hinweis im Handbuch); im Bild stehen unbenutzte Felder auf „0,00 g“.
- Nach Betätigung von „Gewichtsanpassung“ erstellt die Steuerung eine Korrekturkennlinie; eine Rückmeldung oder Fehlermeldung ist nicht beschrieben.
- Mindestens drei, besser fünf bis acht Stützstellen empfohlen; eine Prüfung/Fehlermeldung bei zu wenigen Stützstellen ist nicht beschrieben.
- Wertebereiche, Standardwerte, Berechtigungen: nicht angegeben; Schlüsselsymbol nur am Feld Sollgewicht.
- Pop-ups/Unterseiten: keine beschrieben.
- Navigation: Brotkrümel Einstellung › Schließmaschine › Gewichtskorrektur (abgeleitet, Elternseite unklar); „Zurück“, „Produktion“, „Einstellungen“ unten rechts.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RS-18-P01 | Titel und Pfad | Seite „Gewichtskorrektur“, Pfad Einstellung › Schließmaschine › Gewichtskorrektur (Elternseite offen) | offen |
| RS-18-P02 | Stützstellentabelle | Zwei Tabellen mit je Spalten SOLL und IST und je 10 Zeilen (20 Wertepaare), Einheit g, zwei Nachkommastellen | offen |
| RS-18-P03 | Sollgewicht | Feld „Sollgewicht:“ mit Schlüsselsymbol, Einheit g (Beispiel 250,4 g); Gewicht für manuelle Dosierung | offen |
| RS-18-P04 | Taste Dosierer Auslösen manuell | Dosiert eine Probe mit dem eingestellten Sollgewicht | offen |
| RS-18-P05 | Taste Gewichtsanpassung | Erstellt aus den Stützstellen eine Korrekturkennlinie | offen |
| RS-18-P06 | Leere Felder | Leere Felder werden bei der Berechnung nicht berücksichtigt | offen |
| RS-18-P07 | Hinweise | Alle vier Hinweise zur optimalen Nutzung sind enthalten (mind. 3, besser 5–8 Stützstellen usw.) | offen |
| RS-18-P08 | Bedienablauf | Vier Schritte in der Reihenfolge Sollgewicht, manuell auslösen, Werte eintragen, Gewichtsanpassung | offen |
| RS-18-P09 | Beispielwerte laut Bild | Paar 1: 18,00 g/20,00 g; Paar 2: 22,00 g/24,00 g; übrige 0,00 g | offen |
| RS-18-P10 | Untere Leiste | Schloss-Symbol, Produktion, Einstellungen, Zurück; keine Taste links | offen |
| RS-18-P11 | Medien | [RS-18_01](../Medien/RS-18_01.png) eingebunden und beschrieben | offen |

## Offene Punkte
1. Elternseite/Navigationsweg unklar (A-11); Seite ist inhaltlich identisch mit RS-21 (dasselbe Bild).
2. Wertebereiche, Standardwerte, Berechtigungsstufen, Rückmeldung nach „Gewichtsanpassung“ und Fehlerfall bei zu wenigen Stützstellen nicht beschrieben.
3. Unklar, ob „Gewichtsanpassung“ bestehende Korrektur ersetzt/zurücksetzt und wie die Korrektur deaktiviert wird.
4. Beschreibung nennt „Schneckendosierer“; Bezug zur Schließmaschine unklar.
