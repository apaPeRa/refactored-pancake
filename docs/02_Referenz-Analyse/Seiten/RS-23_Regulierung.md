# RS-23 – Regulierung
- Quelle: Referenz.docx, Kapitel 23 „Regulierung“ (Zweck, Seitenübersicht, Funktionsbeschreibung, Tabelle T33 mit 9 Zeilen inkl. Kopfzeile); Bild [RS-23_01.png](../Medien/RS-23_01.png)
- Navigationspfad: Einstellung › Regulierung (Eintrag in der Tabelle von [RS-04](RS-04_Einstellungen.md); zusätzlich Taste „Einstellung Regulierung“ bzw. „Regulierung“ auf [RS-11](RS-11_Hauptdosierer-1-und-2.md) und [RS-19](RS-19_Nachdosierer.md))

## Zweck
Die Seite dient der Konfiguration der automatischen Gewichtsregulierung für Haupt- und Nachdosierer. Die Regulierung reagiert auf Abweichungen vom Sollgewicht und passt die Dosiermenge entsprechend an. Die Einstellungen ermöglichen eine Feinjustierung der Reaktion auf Gewichtsschwankungen. Auf der Seite sind die Parameter für die Hauptdosierer und den Nachdosierer.

## Aufbau (Bereiche, Layout)
Beschreibung des Bildes [RS-23_01.png](../Medien/RS-23_01.png) (Altes HMI, 1024 × 768):

- **Kopfzeile:** Logo „APA-TEC GmbH – Automation and Packaging Technology“, unterstrichener Titel „Regulierung“, Wirbel-Symbol, Uhrzeit „13:02:45“, Datum „12.05.2025“.
- **Arbeitsbereich (blau):** zwei gleich aufgebaute hellgraue Panels nebeneinander: links „Hauptdosierer“, rechts „Nachdosierer“ (Panelüberschrift fett, unterstrichen).
- **Je Panel von oben nach unten:**
  1. Zeile „Anzahl Gewichte:“ – weißes Feld, rote Schrift, Einheit „Stk“, Schlüsselsymbol. Hauptdosierer: „10 Stk“; Nachdosierer: „15 Stk“.
  2. Zeile „Regulierschritt:“ – rotes Wertfeld mit „%“, Schlüsselsymbol. Hauptdosierer: „50,0 %“; Nachdosierer: „50,0 %“.
  3. Zeile „Toleranz:“ – rotes Wertfeld mit „g“, Schlüsselsymbol. Hauptdosierer: „1,0 g“; Nachdosierer: „0,2 g“.
  4. Zeile „Regulierung max:“ – rotes Wertfeld mit „g“, Schlüsselsymbol. Hauptdosierer: „75,0 g“; Nachdosierer: „20,0 g“.
  5. Zeile „Regulierung ist:“ – rotes Wertfeld mit „g“, Schlüsselsymbol. Hauptdosierer: „0,0 g“; Nachdosierer: „4,8 g“.
  6. Zeile „Mittelwert:“ – weißes Feld mit schwarzer Schrift (kein Schlüsselsymbol, reine Anzeige), Einheit „g“; unten rechts im Feld klein ein Zähler „… Stk“. Hauptdosierer: „0,0 g“ mit „0 Stk“; Nachdosierer: „250,4 g“ mit „11 Stk“.
  7. Breite grüne Schaltfläche „Regulierung“ mit Schlüsselsymbol oben rechts (Ein/Aus der automatischen Regulierung; im Bild grün).
  8. Zwei graue Schaltflächen nebeneinander „Regulierung -“ (Beschriftung zweizeilig, „-“ in zweiter Zeile) und „Regulierung +“ mit je großem gelbem Schlüsselsymbol oben rechts.
- **Meldezeile (rot):** „*450* Palettierung nicht bereit“.
- **Fußleiste:** links leer, mittig gelbes Schloss-Symbol, rechts Tasten „Produktion“ (Haus), „Einstellungen“ (Zahnrad), „Zurück“.

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Tabelle T33 des Handbuchs (Spalten Funktion | Beschreibung), 8 Datenzeilen, wortgetreu. Jedes Element existiert je einmal für Hauptdosierer und Nachdosierer.

| Element (Handbuch: Funktion) | Typ | Funktion (Beschreibung wörtlich) | verwendetes Modul |
|---|---|---|---|
| Anzahl Gewichte | Zahlenfeld, Einheit „Stk“, Schlüsselsymbol | „Anzahl der Packungen, über die ein gleitender Mittelwert gebildet wird.“ | Modulkandidat: Eingabefeld mit Schlüsselsymbol; Modulkandidat: Eingabe-Pop-up |
| Regulierschritt | Zahlenfeld, Einheit „%“, Schlüsselsymbol | „Prozentuale Änderung, wenn der Mittelwert außerhalb der Toleranz liegt.“ | Modulkandidat: Eingabefeld mit Schlüsselsymbol |
| Toleranz | Zahlenfeld, Einheit „g“, Schlüsselsymbol | „Bereich um das Sollgewicht, in dem keine Korrektur erfolgt.“ | Modulkandidat: Eingabefeld mit Schlüsselsymbol |
| Regulierung max | Zahlenfeld, Einheit „g“, Schlüsselsymbol | „Maximale Korrektur, die durch die automatische Regulierung vorgenommen werden darf.“ | Modulkandidat: Eingabefeld mit Schlüsselsymbol |
| Regulierung ist | Zahlenfeld, Einheit „g“, Schlüsselsymbol | „Aktueller Korrekturwert, der auf die Dosierung angewendet wird.“ | Modulkandidat: Eingabefeld mit Schlüsselsymbol |
| Mittelwert | Anzeigefeld, Einheit „g“, mit Zähler „Stk“ unten rechts | „Durchschnittliches Gewicht der letzten gemessenen Packungen. Unten rechts werden Packungen gezählt, erreicht der Zähler den Wert in Anzahl Gewichte wird anhand des Mittelwerts ein neuer Korrekturwert berechnet.“ | Modulkandidat: Anzeigefeld mit Zähler |
| Taste Regulierung | Umschalter (grün mit Beschriftung „Regulierung“, Schlüsselsymbol) | „Schaltet die automatische Regulierung ein oder aus.“ | Modulkandidat: Umschalter mit Schlüsselsymbol |
| Regulierung - / + | zwei Tasten mit Schlüsselsymbol | „Manuelle Feineinstellung der Korrektur. Reduziert (--) oder erhöht (+) den aktuellen Korrekturwert.“ | Modulkandidat: Tasten Minus/Plus mit Schlüsselsymbol |
| Panel „Hauptdosierer“ / „Nachdosierer“ (nur im Bild) | Gruppe | Parametersatz je Dosierer, identischer Aufbau | Modulkandidat: Regulierungs-Parameterblock (je Dosierer) |
| Seitenkopf, Meldezeile, Fußleiste (nur im Bild) | Rahmen | Standardrahmen | Modulkandidat: Seitenkopf (Rahmen); Modulkandidat: Meldezeile; Modulkandidat: Fußleiste (Rahmennavigation) |

Medien dieser Seite (1 Bild):

| Bild | Zeigt |
|---|---|
| [RS-23_01.png](../Medien/RS-23_01.png) | Seite Regulierung mit zwei Panels (Hauptdosierer, Nachdosierer), je sechs Wertfeldern, grüner Schaltfläche „Regulierung“ und den Tasten „Regulierung -“ und „Regulierung +“ |

## Verwendete Module (IDs)
Noch keine RM-IDs vergeben. Modulkandidaten: Regulierungs-Parameterblock (je Dosierer); Eingabefeld mit Schlüsselsymbol; Eingabe-Pop-up; Anzeigefeld mit Zähler; Umschalter mit Schlüsselsymbol; Tasten Minus/Plus mit Schlüsselsymbol; Seitenkopf (Rahmen); Meldezeile; Fußleiste (Rahmennavigation).

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- **Automatische Regulierung:** Taste „Regulierung“ je Dosierer schaltet ein oder aus; im Bild grün (Annahme: grün = eingeschaltet, im Handbuch nicht beschrieben).
- **Berechnung:** Pro gewogener Packung zählt der Zähler (unten rechts im Feld Mittelwert) hoch; erreicht er den Wert in „Anzahl Gewichte“, wird anhand des Mittelwerts ein neuer Korrekturwert berechnet. Liegt der Mittelwert außerhalb der Toleranz, ändert sich der Korrekturwert um den Regulierschritt in Prozent; begrenzt durch „Regulierung max“.
- **Manuelle Korrektur:** Regulierung - verringert, Regulierung + erhöht den aktuellen Korrekturwert (Schrittweite im Handbuch nicht angegeben).
- **Eingabefelder:** Anzahl Gewichte, Regulierschritt, Toleranz, Regulierung max, Regulierung ist (rote Schrift, Schlüsselsymbol). Mittelwert ist reine Anzeige.
- **Berechtigungen:** Handbuch nennt keine; im Bild tragen alle Eingabefelder und alle Tasten ein gelbes Schlüsselsymbol (Annahme: berechtigungsgeschützt).
- **Pop-ups / Unterseiten:** keine beschrieben; Eingabe-Pop-up für Zahlenfelder nicht beschrieben.
- **Fehlerfälle:** keine beschrieben.
- **Zugang:** aus RS-04 oder per Taste auf RS-11 und RS-19.
- **Navigation:** Fußleiste Produktion, Einstellungen, Zurück; keine Navigation unten links.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RS-23-P01 | Panels | Zwei Panels „Hauptdosierer“ und „Nachdosierer“ mit identischem Aufbau | offen |
| RS-23-P02 | Felder je Panel | Sechs Felder in der Reihenfolge Anzahl Gewichte, Regulierschritt, Toleranz, Regulierung max, Regulierung ist, Mittelwert | offen |
| RS-23-P03 | Einheiten | Anzahl Gewichte in „Stk“, Regulierschritt in „%“, Toleranz, Regulierung max, Regulierung ist und Mittelwert in „g“ | offen |
| RS-23-P04 | Beispielwerte Hauptdosierer | 10 Stk, 50,0 %, 1,0 g, 75,0 g, 0,0 g, Mittelwert 0,0 g (Zähler 0 Stk) | offen |
| RS-23-P05 | Beispielwerte Nachdosierer | 15 Stk, 50,0 %, 0,2 g, 20,0 g, 4,8 g, Mittelwert 250,4 g (Zähler 11 Stk) | offen |
| RS-23-P06 | Mittelwert-Zähler | Zähler „Stk“ unten rechts im Feld Mittelwert; bei Erreichen von Anzahl Gewichte wird ein neuer Korrekturwert berechnet | offen |
| RS-23-P07 | Taste Regulierung | Schaltet die automatische Regulierung je Dosierer ein oder aus; Zustand nicht nur über Farbe erkennbar | offen |
| RS-23-P08 | Regulierung - / + | Reduziert („--“) bzw. erhöht („+“) den aktuellen Korrekturwert je Dosierer | offen |
| RS-23-P09 | Eingabefelder | Fünf Eingabefelder je Panel mit Schlüsselsymbol, Mittelwert nicht editierbar | offen |
| RS-23-P10 | Zugang | Erreichbar über RS-04 und per Taste auf RS-11 und RS-19 | offen |
| RS-23-P11 | Fußleiste | Produktion, Einstellungen, Zurück vorhanden; keine Navigation unten links | offen |
| RS-23-P12 | Bildabdeckung | RS-23_01.png ist verlinkt und beschrieben | offen |

## Offene Punkte
- Wertebereiche und Standardwerte aller Parameter sind im Handbuch nicht angegeben (Bildwerte nur Beispiele).
- Schrittweite von „Regulierung - / +“ und Bedeutung der Farbe der Taste „Regulierung“ (grün/grau) sind nicht beschrieben.
- „Regulierung ist“ trägt im Bild ein Eingabefeld mit Schlüsselsymbol, obwohl das Handbuch ihn als aktuellen Korrekturwert (Anzeige) beschreibt; manuelle Eingabe also unklar.
- Zusammenhang „Regulierschritt in %“ (Bezug: Sollgewicht oder Abweichung) ist nicht angegeben.
- Berechtigungsstufe hinter dem Schlüsselsymbol ist nicht beschrieben.
