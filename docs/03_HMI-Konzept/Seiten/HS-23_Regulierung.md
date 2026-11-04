# HS-23 – Regulierung
- Quelle: [RS-23](../../02_Referenz-Analyse/Seiten/RS-23_Regulierung.md) (Handbuch Kapitel 23, Tabelle T33; Bild [RS-23_01.png](../../02_Referenz-Analyse/Medien/RS-23_01.png)); Design: keine eigene Design-Seite; Aufbau abgeleitet aus [Designsystem](../Designsystem.md), HM-35 und der Panel-Gliederung von DS-04 ([DS-04](../../01_Design-Analyse/Seiten/DS-04_Dosierer.md): Dosierer-Karten) und dem 12-Spalten-Raster.
- Navigationspfad: Einstellung › Regulierung (Brotkrümel, [Navigation.md](../Navigation.md) Abschnitt 2). Zugang: HS-04, Kachel „Regulierung“ (belegt einen der leeren Plätze, A-36); HS-11 und HS-19, Taste „Regulierung“. Zurück-Ziel: Verlauf (HS-04, HS-11 oder HS-19). Schlüssel `Regulation` / Route `settings/regulation`, Mindestrolle: keine (Seitenzugang frei).

## Zweck
Konfiguration der automatischen Gewichtsregulierung für Hauptdosierer und Nachdosierer. Die Regulierung reagiert auf Abweichungen vom Sollgewicht und passt die Dosiermenge entsprechend an; die Einstellungen erlauben eine Feinjustierung der Reaktion auf Gewichtsschwankungen. Die Seite enthält zwei gleich aufgebaute Parametersätze, links für den Hauptdosierer, rechts für den Nachdosierer.

## Aufbau (Bereiche, Layout)
Rahmen wie auf allen Vollseiten ([Designsystem](../Designsystem.md) Abschnitt 3.2); die Funktionsleiste ist leer, aber sichtbar. Der Inhaltsbereich nutzt das 12-Spalten-Raster (Außenrand `Space.L`, Gutter `Space.M`) mit **einer Zeile** und **zwei Panels 6 : 6**:

- Links: Panel „Hauptdosierer“ (Spalten 1 bis 6), rechts: Panel „Nachdosierer“ (Spalten 7 bis 12). Beide Panels sind der Regulierungs-Parameterblock ([HM-35](../Module/HM-35_Regulierungs-Parameterblock.md)) in einem Gruppenbereich ([HM-15](../Module/HM-15_Gruppenbereich.md), Darstellung Panel, Überschrift fett).
- Innenaufbau je Panel (von oben nach unten, Zeilenhöhe `Size.Touch.Default`, Abstand `Size.Touch.Gap`): Überschrift; fünf Eingabezeilen; die Anzeigezeile „Mittelwert“; breite Zustandstaste „Regulierung“; Tastenpaar „Regulierung −“ / „Regulierung +“ (je 3 der 6 Panel-Spalten). In den Zeilen steht die Beschriftung links (2 von 6 Spalten), das Feld rechts (4 von 6 Spalten), Einheit hinter dem Wert.
- Höhe: 8 Zeilen à `Size.Touch.Default` plus Überschrift und Abstände passen in den Inhaltsbereich ohne Bildlauf.

```
Inhaltsbereich (12 Spalten)
+--------------- Panel Hauptdosierer (6 Sp.) --+--------------- Panel Nachdosierer (6 Sp.) --+
| Hauptdosierer                                 | Nachdosierer                                 |
| Anzahl Gewichte:   [ 10 Stk      ]K           | Anzahl Gewichte:   [ 15 Stk      ]K          |
| Regulierschritt:   [ 50,0 %      ]K           | Regulierschritt:   [ 50,0 %      ]K          |
| Toleranz:          [ 1,0 g       ]K           | Toleranz:          [ 0,2 g       ]K          |
| Regulierung max:   [ 75,0 g      ]K           | Regulierung max:   [ 20,0 g      ]K          |
| Regulierung ist:   [ 0,0 g       ]K           | Regulierung ist:   [ 4,8 g       ]K          |
| Mittelwert:        [ 0,0 g    0 Stk]          | Mittelwert:        [ 250,4 g  11 Stk]        |
| [  Regulierung   Ein/Aus (Taste)   ]K         | [  Regulierung   Ein/Aus (Taste)   ]K        |
| [ Regulierung - ]K   [ Regulierung + ]K       | [ Regulierung - ]K   [ Regulierung + ]K      |
+-----------------------------------------------+----------------------------------------------+
Funktionsleiste: leer (sichtbar)        K = Schlüsselsymbol
```

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Jedes Element existiert je einmal im Panel Hauptdosierer und im Panel Nachdosierer (identischer Aufbau, [HM-35](../Module/HM-35_Regulierungs-Parameterblock.md)). Rückverfolgung: Spalte „Herkunft“ = Zeile in [RS-23](../../02_Referenz-Analyse/Seiten/RS-23_Regulierung.md) (T33 = Tabelle des Handbuchs, Bild = RS-23_01.png). Beispielwerte aus dem Bild in Klammern: HD = Hauptdosierer, ND = Nachdosierer.

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Panel „Hauptdosierer“ / „Nachdosierer“ | Gruppe mit Überschrift | Parametersatz je Dosierer, identischer Aufbau | [HM-35](../Module/HM-35_Regulierungs-Parameterblock.md), [HM-15](../Module/HM-15_Gruppenbereich.md) | T33 „Panel (nur im Bild)“, Bild |
| Anzahl Gewichte | Eingabefeld Zahl, Einheit „Stk“, Schlüsselsymbol | „Anzahl der Packungen, über die ein gleitender Mittelwert gebildet wird.“ (HD 10 Stk, ND 15 Stk) | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | T33 „Anzahl Gewichte“ |
| Regulierschritt | Eingabefeld Zahl, Einheit „%“, Schlüsselsymbol | „Prozentuale Änderung, wenn der Mittelwert außerhalb der Toleranz liegt.“ (HD 50,0 %, ND 50,0 %) | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) | T33 „Regulierschritt“ |
| Toleranz | Eingabefeld Zahl, Einheit „g“, Schlüsselsymbol | „Bereich um das Sollgewicht, in dem keine Korrektur erfolgt.“ (HD 1,0 g, ND 0,2 g) | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) | T33 „Toleranz“ |
| Regulierung max | Eingabefeld Zahl, Einheit „g“, Schlüsselsymbol | „Maximale Korrektur, die durch die automatische Regulierung vorgenommen werden darf.“ (HD 75,0 g, ND 20,0 g) | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) | T33 „Regulierung max“ |
| Regulierung ist | Eingabefeld Zahl, Einheit „g“, Schlüsselsymbol | „Aktueller Korrekturwert, der auf die Dosierung angewendet wird.“ (HD 0,0 g, ND 4,8 g); im Bild als Eingabefeld mit Schlüssel, daher beibehalten (OP-45); am Limit Warnung mit Text „Maximum erreicht“ | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) | T33 „Regulierung ist“ |
| Mittelwert | Anzeigefeld, Einheit „g“, mit Zähler „Stk“ unten rechts im Feld, ohne Schlüssel | „Durchschnittliches Gewicht der letzten gemessenen Packungen.“ (HD 0,0 g mit 0 Stk, ND 250,4 g mit 11 Stk); Zähler zählt gewogene Packungen, bei Erreichen von „Anzahl Gewichte“ wird anhand des Mittelwerts ein neuer Korrekturwert berechnet; Zähler zusätzlich als Text „von n“ (n = Anzahl Gewichte, HM-35) | [HM-11](../Module/HM-11_Anzeigefeld.md) (mit `Counter`) | T33 „Mittelwert“ |
| Taste „Regulierung“ | Zustandstaste (Darstellung Taste, volle Panelbreite) mit Schlüsselsymbol | „Schaltet die automatische Regulierung ein oder aus.“ Zustand über `Icon.State.On`/`.Off` und Wort „Ein“/„Aus“, neutral, nicht grün (A-31) | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | T33 „Taste Regulierung“, Bild |
| Taste „Regulierung −“ | Aktionstaste (Beschriftung zweizeilig „Regulierung“ / „−“) mit Schlüsselsymbol | „Manuelle Feineinstellung der Korrektur. Reduziert (--) … den aktuellen Korrekturwert.“ | [HM-07](../Module/HM-07_Aktionstaste.md) | T33 „Regulierung - / +“, Bild |
| Taste „Regulierung +“ | Aktionstaste (zweizeilig „Regulierung“ / „+“) mit Schlüsselsymbol | „… erhöht (+) den aktuellen Korrekturwert.“ | [HM-07](../Module/HM-07_Aktionstaste.md) | T33 „Regulierung - / +“, Bild |
| Kopfzeile mit Logo, Titel, Symbol, Uhr/Datum | Rahmen | Titel „Regulierung“ im Brotkrümel; Betriebsart und Uhr in der Kopfzeile | [HM-02](../Module/HM-02_Kopfzeile.md) | Bild Kopfzeile, T33 „Seitenkopf“ |
| Meldezeile („*450* Palettierung nicht bereit“) | Rahmen | Aktuelle Meldung; Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | Bild Meldezeile, T33 „Meldezeile“ |
| Brotkrümel und Kennzahlen | Rahmen | „Einstellung › Regulierung“; Geschwindigkeit, Maschinenwinkel | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | (Design-Rahmen) |
| Fußleiste „Produktion“, „Einstellungen“, „Zurück“, Schloss | Rahmentasten | wandern in die Seitenleiste (Home, Einstellungen, Zurück, Benutzerkreis, A-35); Funktionsleiste ohne eigene Tasten, sichtbar | [HM-01](../Module/HM-01_Seitenleiste.md), [HM-06](../Module/HM-06_Funktionsleiste.md) | Bild Fußleiste, T33 „Fußleiste“ |

## Verwendete Module (IDs)
- [HM-35](../Module/HM-35_Regulierungs-Parameterblock.md) – Regulierungs-Parameterblock (zweimal)
- [HM-15](../Module/HM-15_Gruppenbereich.md) – Gruppenbereich (Panel je Dosierer)
- [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) – Eingabefeld mit Schlüsselsymbol (5 je Panel)
- [HM-13](../Module/HM-13_Eingabe-Pop-up.md) – Eingabe-Pop-up, getragen von [HM-14](../Module/HM-14_Popup-Rahmen.md) – Pop-up-Rahmen
- [HM-11](../Module/HM-11_Anzeigefeld.md) – Anzeigefeld (Mittelwert mit Zähler)
- [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) – Zustandstaste / Umschalter (Regulierung)
- [HM-07](../Module/HM-07_Aktionstaste.md) – Aktionstaste (Regulierung −, Regulierung +)
- Rahmen: [HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md)

Kein Modul fehlt.

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- **Automatische Regulierung:** Die Taste „Regulierung“ schaltet je Dosierer die automatische Regulierung ein oder aus; Hauptdosierer und Nachdosierer sind unabhängig. Ein: `Brush.Button.Active`, Symbol Haken, Wort „Ein“; Aus: `Icon.State.Off`, Wort „Aus“. Nach dem Befehl bis zur Rückmeldung „Ausstehend“ (gestrichelte Kontur, `Icon.State.Pending`, Text „Wird gesetzt“). Die Grünfärbung der Referenz entfällt (A-31).
- **Berechnung (Anzeige):** Pro gewogener Packung zählt der Zähler im Feld „Mittelwert“ hoch. Erreicht er „Anzahl Gewichte“, wird anhand des Mittelwerts ein neuer Korrekturwert berechnet: Liegt der Mittelwert außerhalb der Toleranz, ändert sich der Korrekturwert um den Regulierschritt in Prozent, begrenzt durch „Regulierung max“. Die Berechnung ist Dummy in Meilenstein 2 (OP-45).
- **Manuelle Korrektur:** „Regulierung −“ verringert, „Regulierung +“ erhöht den aktuellen Korrekturwert („Regulierung ist“) je Tastendruck um eine konfigurierbare Schrittweite (im Handbuch nicht angegeben, Dummy, kein Dauerdruck-Wiederholen angenommen). Gedrückt: Kontur `Border.Medium`. Das Feld „Regulierung ist“ aktualisiert sich sofort.
- **Korrektur am Limit:** Erreicht „Regulierung ist“ den Wert „Regulierung max“, zeigt das Feld Warnung (`Icon.Status.Warning`, Text „Maximum erreicht“, [HM-35](../Module/HM-35_Regulierungs-Parameterblock.md)); die Taste in Richtung des Limits ist deaktiviert (gestrichelte Kontur).
- **Eingabefelder:** Antippen öffnet das Eingabe-Pop-up ([HM-13](../Module/HM-13_Eingabe-Pop-up.md)) mit Feldname und Dosierer im Titel, vorbelegtem Wert, Einheit und Dummy-Grenzen (OP-28). „Übernehmen“ nur bei gültigem Wert; ungültig: Fehlertext im Pop-up und Feldzustand Fehler (`Icon.Status.Error`). „Abbrechen“ verwirft. Modale Regeln wie Navigation.md 4.2. Der Mittelwert ist nicht editierbar.
- **Berechtigungen:** Alle fünf Eingabefelder, die Taste „Regulierung“ und beide Tasten „Regulierung −/+“ tragen das Schlüsselsymbol (Annahme laut OP-25; Stufe offen). Fehlende Rolle: Schloss, Tippen öffnet das Benutzer-Pop-up und setzt die Aktion nach Anmeldung fort; gesperrte Elemente bleiben sichtbar (gestrichelte Kontur, `Icon.Lock`). Der Mittelwert hat keinen Schlüssel.
- **Navigation:** Seitenleiste „Einstellungen“ hervorgehoben. Der Brotkrümel bleibt kanonisch „Einstellung › Regulierung“, auch bei Zugang aus HS-11 oder HS-19; „Zurück“ führt im Verlauf zur aufrufenden Seite (A-42). Die Seite hat keinen Parameter (zeigt immer beide Dosierer). Funktionsleiste leer.
- **Fehlerfälle:** keine im Handbuch beschrieben. Keine Verbindung: Werte „---“, Bedienung deaktiviert (gestrichelte Kontur), Grund per Tippen in der Meldezeile (A-28).
- **Pop-ups:** nur das Eingabe-Pop-up (Tiefe 1).

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-23-P01 | Panels (RS-23-P01) | Zwei Panels „Hauptdosierer“ (links) und „Nachdosierer“ (rechts) mit identischem Aufbau, Spaltenverhältnis 6 : 6 | offen |
| HS-23-P02 | Felder je Panel (RS-23-P02) | Sechs Felder in der Reihenfolge Anzahl Gewichte, Regulierschritt, Toleranz, Regulierung max, Regulierung ist, Mittelwert | offen |
| HS-23-P03 | Einheiten (RS-23-P03) | Anzahl Gewichte „Stk“, Regulierschritt „%“, Toleranz, Regulierung max, Regulierung ist und Mittelwert „g“ | offen |
| HS-23-P04 | Beispielwerte Hauptdosierer (RS-23-P04) | 10 Stk, 50,0 %, 1,0 g, 75,0 g, 0,0 g, Mittelwert 0,0 g mit Zähler 0 Stk | offen |
| HS-23-P05 | Beispielwerte Nachdosierer (RS-23-P05) | 15 Stk, 50,0 %, 0,2 g, 20,0 g, 4,8 g, Mittelwert 250,4 g mit Zähler 11 Stk | offen |
| HS-23-P06 | Mittelwert-Zähler (RS-23-P06) | Zähler „Stk“ unten rechts im Feld Mittelwert; bei Erreichen von „Anzahl Gewichte“ wird ein neuer Korrekturwert berechnet (Dummy) | offen |
| HS-23-P07 | Taste Regulierung (RS-23-P07) | Schaltet die automatische Regulierung je Dosierer ein und aus; Zustand mit Symbol und Wort „Ein“/„Aus“, nicht nur über Farbe | offen |
| HS-23-P08 | Regulierung − / + (RS-23-P08) | „Regulierung −“ verringert, „Regulierung +“ erhöht den Korrekturwert je Dosierer; Feld „Regulierung ist“ folgt | offen |
| HS-23-P09 | Eingabefelder (RS-23-P09) | Fünf Eingabefelder je Panel mit Schlüsselsymbol; Mittelwert nicht editierbar und ohne Schlüssel | offen |
| HS-23-P10 | Zugang (RS-23-P10) | Erreichbar über HS-04 (Kachel „Regulierung“) sowie die Taste „Regulierung“ auf HS-11 und HS-19; Brotkrümel stets „Einstellung › Regulierung“ | offen |
| HS-23-P11 | Rahmen und Fußleiste (RS-23-P11) | Produktion, Einstellungen, Zurück liegen in der Seitenleiste; Funktionsleiste leer und sichtbar; kein Schloss unten | offen |
| HS-23-P12 | Bildabdeckung (RS-23-P12) | Jedes Element aus [RS-23_01.png](../../02_Referenz-Analyse/Medien/RS-23_01.png) (zwei Panels mit je sechs Wertfeldern, Taste Regulierung, Tasten − und +, Kopfzeile, Meldezeile, Fußleiste) ist in der Elemente-Tabelle wiederzufinden | offen |
| HS-23-P13 | Berechtigung | Alle Eingabefelder und Tasten außer Mittelwert tragen den Schlüssel; ohne Rolle Schloss, Tippen öffnet das Benutzer-Pop-up | offen |
| HS-23-P14 | Eingabe-Pop-up | Titel mit Feldname und Dosierer, Einheit, Grenzen, „Übernehmen“ nur bei gültigem Wert, „Abbrechen“ verwirft | offen |
| HS-23-P15 | Limit | Erreicht „Regulierung ist“ „Regulierung max“, erscheinen Warnsymbol und Text „Maximum erreicht“; Taste „+“ ist deaktiviert (gestrichelt) | offen |
| HS-23-P16 | Touch-Ziele | Alle Felder und Tasten `Size.Touch.Default` hoch (≥ `Size.Touch.Min`), Abstand ≥ `Size.Touch.Gap` | offen |
| HS-23-P17 | Zweiter Kanal und Tokens | Kein Zustand nur über Farbe; keine Hex- oder Pixelwerte, nur Tokens aus dem Designsystem | offen |
| HS-23-P18 | Layout ohne Bildlauf | Beide Panels vollständig sichtbar ohne Scrollen bei der Zielauflösung | offen |

## Offene Punkte
- OP-05: Die Kachel „Regulierung“ belegt einen der leeren Plätze in HS-04 (A-36).
- OP-25: Berechtigungsstufe hinter den Schlüsselsymbolen nicht beschrieben; Dummy-Rolle.
- OP-27: Bedeutung der Farben (rote Schrift der Eingabewerte, grün/grau der Tasten) nicht belegt; hier Symbol, Wort und neutrale Zustände.
- OP-28: Wertebereiche und Standardwerte aller Parameter fehlen (Bildwerte nur Beispiele); Dummy-Grenzen.
- OP-30: Eingabe-Pop-up ist in der Referenz nicht beschrieben (Modulannahme).
- OP-45: Fachliche Zusammenhänge unklar: Bezug des Regulierschritts in % (Sollgewicht oder Abweichung), Schrittweite von „Regulierung −/+“, ob „Regulierung ist“ manuell eingebbar sein soll (Referenz zeigt ein Eingabefeld mit Schlüssel, beschreibt aber einen aktuellen Korrekturwert).
- Annahme dieser Seite (Nummerierung für den Verwalter): H-4 Die Tasten „Regulierung −/+“ ändern den Korrekturwert je Tippen um eine konfigurierbare Dummy-Schrittweite ohne Wiederholfunktion; am Limit „Maximum erreicht“ (HM-35) ist die Taste in Richtung des Limits deaktiviert (Ergänzung, im Handbuch nicht beschrieben).
