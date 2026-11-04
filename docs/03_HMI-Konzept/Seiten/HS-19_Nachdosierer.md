# HS-19 – Nachdosierer

- Quelle: [RS-19](../../02_Referenz-Analyse/Seiten/RS-19_Nachdosierer.md) (Funktionsumfang, Tabellen T27, T28, T29, Prüfpunkte); [DS-04](../../01_Design-Analyse/Seiten/DS-04_Dosierer.md) (Karte Nachdosierer der Dosierer-Übersicht, nur Orientierung für Karteninhalt und Zugang über das Detail-Symbol; die Detailseite hat kein Design, OP-07, OP-15); Zugänge und Brotkrümel nach [Navigation.md](../Navigation.md).
- Navigationspfad: Einstellung › Dosierer › Nachdosierer. Zugang: [HS-41](../Seiten/HS-41_Dosierer-Uebersicht.md) Detail-Symbol in der Karte Nachdosierer. Zurück-Ziel: HS-41. Seitenschlüssel `PostDoser` / `settings/dosers/post`.

## Zweck

Wortgetreu (Handbuch): „Die Seite Nachdosierer beinhaltet die Parameter, die Anwahlen und den Status des Schneckendosierers.“ Der Nachdosierer ergänzt die Hauptdosierer ([HS-11](../Seiten/HS-11_Hauptdosierer-1-und-2.md)): Er erhält das aktuelle Gewicht der Packung von der Kontrollwaage und dosiert die Differenz zum Zielgewicht. Die Seite hat denselben Aufbau wie HS-11 (Modul HM-20, Variante Nachdosierer): statt „Soll absolut“ gibt es „Max. Nachgabe“ und „Aktuelle Nachgabe“, statt der Taste „Einstellung Regulierung“ im Inhaltsbereich drei Navigationstasten in der Funktionsleiste, und es gibt keine Blättertasten (es gibt nur einen Nachdosierer).

## Aufbau (Bereiche, Layout)

Rahmen wie auf allen Seiten (Seitenleiste 3\*, Arbeitsbereich 37\*; Kopfzeile 4\*, Brotkrümel/Kennzahlen 3\*, Inhalt 34\*, Funktionsleiste 4\*). Der **Inhaltsbereich** (Außenrand `Size.Content.Margin`, 12-Spalten-Raster, Gutter `Space.M`) hat eine Zeile mit drei Gruppenbereichen **4 : 4 : 4** Spalten (wie die Karten in DS-04). Der Seitentitel „Nachdosierer“ ist das letzte Brotkrümel-Segment; es gibt keine Titelzeile, weil die Seite nur ein Objekt zeigt.

```
Inhaltsbereich (12 Spalten, Gutter Space.M)
+------------------------+------------------------+------------------------+
| Sollwerte und          | Schnecke, Rührer,      | Status und Bedienung   |
| Eichdosierung (4 Sp.)  | Querschnecke (4 Sp.)   | (4 Sp.)                |
|  Soll          [ g ]   |  Schnecke Drehzahl[1/min]| Füllstand Trichter     |
|  Max. Nachgabe [ g ]   |  Rührer  Schalter Ein/Aus|   oben  [LED] Wort     |
|  Hinweis nIO (Info)    |  Rührer          [ % ]   |   unten [LED] Wort     |
|  Aktuelle Nachg. [ g ] |  Nachlauf Rührer [ s ]   | Auslastung  [=== 73 %] |
|  Regulierung Ist [g]   |  Querschnecke Schalter   | Regulierung aktiv  Ein |
|  ---- Eichdosierung    |  Querschnecke    [ % ]   | [Manuell] [Entleeren]  |
|  Umdrehungen    [ ]    |                          | [ Eichdosierung ]      |
|  Eichdosierung  [ g ]  |                          | Hinweis Ablauf (Info)  |
+------------------------+------------------------+------------------------+
| Funktionsleiste: [Gewichtskorrektur] [Motorparameter] [Regulierung]       |
+--------------------------------------------------------------------------+
```

- **Gruppe 1 „Sollwerte und Eichdosierung“:** Soll, Max. Nachgabe mit dem Hinweis-Textfeld zur nIO-Regel direkt darunter (Position wie in HM-20), Aktuelle Nachgabe (Anzeige), Regulierung Ist; Zwischenüberschrift „Eichdosierung“ (Linie `Brush.Divider`); Eichfelder Umdrehungen und Gewicht.
- **Gruppe 2 „Schnecke, Rührer, Querschnecke“:** wie HS-11 (Drehzahl; Rührer mit Umschalter, Sollgeschwindigkeit, Nachlauf; Querschnecke mit Umschalter und Sollgeschwindigkeit).
- **Gruppe 3 „Status und Bedienung“:** Füllstand oben und unten, Auslastungsbalken, Umschalter „Regulierung aktiv“, Tasten „Manuell“ und „Entleeren“ nebeneinander, Taste „Eichdosierung“, darunter das Hinweis-Textfeld zum Ablauf der Eichdosierung.
- Zeilenhöhen: Felder, Umschalter und Tasten `Size.Touch.Default`, Abstand zwischen Touch-Zielen `Size.Touch.Gap`.
- **Höhenbilanz** (Kontrollrechnung bei 1920 × 1080; nutzbare Inhaltshöhe 768 = Inhaltszeile 34\* abzüglich 2 × `Size.Content.Margin`; keine Titelzeile):

  | Bereich | Rechnung | Summe |
  |---|---|---|
  | Gruppe 1 | 6 Felder (384) + Hinweis nIO (80) + Zwischenüberschrift (40) + 7 Abstände (112) + Kopf (52) + Innenabstand (32) | 700 |
  | Gruppe 2 | 6 Zeilen (384) + 5 Abstände (80) + Kopf (52) + Innenabstand (32) | 548 |
  | Gruppe 3 | Füllstandsblock (128) + Auslastung (72) + 3 Tasten/Umschalter (192) + Hinweis Ablauf (120) + 5 Abstände (80) + Kopf (52) + Innenabstand (32) | 676 |

  Alle Gruppen liegen unter 768; es wird nicht gescrollt (Prüfpunkt HS-19-P21).
- Die Funktionsleiste trägt links drei Tasten in der Reihenfolge des Referenzbildes: „Gewichtskorrektur“, „Motorparameter“, „Regulierung“ (höchstens 5 erlaubt).

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)

Spalte „Herkunft (RS-19)“: T27 = Parameter und Status, T28 = Schaltflächen, T29 = Navigation (unten links), W = nur im Referenzbild. Beispielwerte stammen aus dem Referenzbild und sind keine Standardwerte (OP-28). Das Detail-Layout der Gruppen setzt das Kompositmodul [HM-20](../Module/HM-20_Dosierer-Karte.md) (Darstellung Detail, Variante Nachdosierer) um.

### Rahmen und Kopf

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-19) |
|---|---|---|---|---|
| Seitenleiste (Benutzerkreis, Home, Einstellungen, Meldungen, Zurück) | Rahmen | ersetzt Schloss, „Produktion“, „Einstellungen“, „Zurück“ der Referenz; „Zurück“ öffnet den obersten Verlaufseintrag (HS-41) | [HM-01](../Module/HM-01_Seitenleiste.md) | W: Schloss, Tasten „Produktion“, „Einstellungen“, „Zurück“ |
| Kopfzeile: Logo, Betriebsart, Uhrzeit/Datum | Rahmen | Logo, Betriebsart statt Spiral-Symbol (OP-26), Uhrzeit und Datum | [HM-02](../Module/HM-02_Kopfzeile.md) | W: Logo, Spiral-Symbol, Uhrzeit/Datum |
| Meldezeile | Anzeige | aktuelle Meldung (Referenzbild „*450* Palettierung nicht bereit“); Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | W: Meldezeile |
| Brotkrümel „Einstellung › Dosierer › Nachdosierer“ | Navigation | Seitenpfad; letztes Segment ersetzt den Seitentitel „Nachdosierer“; „Dosierer“ führt zu HS-41 | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | W: Seitentitel „Nachdosierer“ |
| Kennzahlen Geschwindigkeit, Maschinenwinkel | Anzeige | Rahmenkennzahlen | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | (Rahmen) |

### Parameter und Status (T27)

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-19) |
|---|---|---|---|---|
| Soll | Eingabefeld mit Schlüssel, Beschriftung fett, Einheit g, Symbol Gewichtsstück | „Zielgewicht des Produkts. Der Nachdosierer bekommt das aktuelle Gewicht der Packung von der Kontrollwaage und dosiert die Differenz.“ Beispiel 250 g | HM-20 (Detail) mit [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) | T27 Nr. 1 |
| Eichdosierung Umdrehungen | Eingabefeld mit Schlüssel, ohne Einheit, Symbol Schnecke | „Anzahl Umdrehungen der Dosierschnecke welche bei der Eichdosierung ausgeführt wird. Anhand der Umdrehungen und des Gewichtes im Feld Eichdosierung berechnet die Maschine die Umdrehungen im Automatikbetrieb.“ Beispiel 5 | HM-20 mit HM-12 | T27 Nr. 2 |
| Eichdosierung (Gewicht) | Eingabefeld mit Schlüssel, Einheit g, 2 Nachkommastellen, Symbol Waagschale | „Hier wird das Gewicht, des während der Eichdosierung dosierten Produkts, eingetragen.“ Beispiel 18,50 g | HM-20 mit HM-12 | T27 Nr. 3 |
| Max. Nachgabe | Eingabefeld mit Schlüssel, Einheit g | „Obergrenze an zu dosierendem Produkt. Ist die Fehlmenge in einer Packung größer, wird nicht dosiert und die Packung wird als nIO ausgeschieden.“ Beispiel 50 g | HM-20 mit HM-12 | T27 Nr. 4 |
| Aktuelle Nachgabe | Anzeigefeld, Einheit g (Anzeige, ohne Schlüssel; S19-1) | „Zu dosierendes Produkt in die aktuelle Packung.“ Beispiel 13 g | HM-20 mit [HM-11](../Module/HM-11_Anzeigefeld.md) | T27 Nr. 5 |
| Regulierung Ist | Eingabefeld mit Schlüssel, Einheit g, 2 Nachkommastellen | „Aktueller Korrekturwert von der Regulierung. Dieses Gewicht wird auf die aktuelle Nachgabe aufaddiert. Der Wert kann manuell geändert werden.“ Beispiel 4,81 g | HM-20 mit HM-12 | T27 Nr. 6 |
| Schnecke Drehzahl | Eingabefeld mit Schlüssel, Einheit 1/min (S19-7), Symbol Tacho | „Solldrehzahl der Dosierschnecke.“ Beispiel 2800 | HM-20 mit HM-12 | T27 Nr. 7 |
| Rührer (Sollgeschwindigkeit) | Eingabefeld mit Schlüssel, Einheit %, Symbol Tacho | „Sollgeschwindigkeit des Rührers im Trichter.“ Beispiel 30 % | HM-20 mit HM-12 | T27 Nr. 8 |
| Nachlauf Rührer | Eingabefeld mit Schlüssel, Einheit s | „Zeit, welche der Rührer bei einem Stopp der Maschine nachläuft.“ Beispiel 0 s | HM-20 mit HM-12 | T27 Nr. 9 |
| Querschnecke (Sollgeschwindigkeit) | Eingabefeld mit Schlüssel, Einheit %, Symbol Tacho | „Sollgeschwindigkeit der Querschnecke in der Produktzuführung.“ Beispiel 30 % | HM-20 mit HM-12 | T27 Nr. 10 |
| Füllstand Trichter oben | Status-LED mit Trichter-Symbol, Beschriftung „oben“ | „Zeigt den Status des Sensors im oberen Bereich des Trichters an.“ Zustand mit Symbol und Wort (S19-2) | HM-20 mit [HM-09](../Module/HM-09_Status-LED.md) | T27 Nr. 11 |
| Füllstand Trichter unten | Status-LED mit Trichter-Symbol, Beschriftung „unten“ | „Zeigt den Status des Sensors im unteren Bereich des Trichters an.“ Beschriftung „Füllstand:“ der Referenz als Gruppenzeile über beiden LEDs | HM-20 mit HM-09 | T27 Nr. 12 |
| Auslastung | Fortschrittsbalken mit Zahl im Balken, Einheit % | „Zeigt an wieviel Prozent der verfügbaren Zeit der Dosiervorgang benötigt. Die Zeit ergibt sich aus der Länge der Nocke für den Dosierer und der Maschinengeschwindigkeit.“ Beispiel 73 % (unter der Warnschwelle: neutrale Füllung; S19-3) | HM-20 mit [HM-10](../Module/HM-10_Fortschrittsbalken.md) | T27 Nr. 13 |
| Hinweis zur Max. Nachgabe | Hinweis-Textfeld (Art Info, bei Ereignis Warnung) | zeigt die Regel zur Max. Nachgabe als Text; ist die Fehlmenge einer Packung größer als „Max. Nachgabe“, wechselt es auf Warnung mit `Icon.Status.Warning` und dem Text „Fehlmenge größer als Max. Nachgabe: nicht dosiert, Packung nIO“ (S19-8) | HM-20 mit [HM-27](../Module/HM-27_Hinweis-Textfeld.md) | T27 Nr. 4 (Beschreibungstext), Prüfpunkt RS-19-P10 |

### Gliederung und Hinweis zur Eichdosierung

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-19) |
|---|---|---|---|---|
| Gruppenbereiche „Sollwerte und Eichdosierung“, „Schnecke, Rührer, Querschnecke“, „Status und Bedienung“ | Gruppenbereich (Panel) | gliedern die Felder der Tabellen T27 und T28 in drei Rahmen mit Überschrift; Beschriftung „Füllstand:“ der Referenz als Zeile im dritten Panel | [HM-15](../Module/HM-15_Gruppenbereich.md) | T27 (Gliederung), W: „Füllstand:“ |
| Hinweis Ablauf Eichdosierung | Hinweis-Textfeld (Art Info) | nennt die Schritte der Eichdosierung (Auffangen, Wiegen, Gewicht eintragen; S19-5) | [HM-27](../Module/HM-27_Hinweis-Textfeld.md) | T28 Nr. 5, T27 Nr. 2 und 3 |

### Schaltflächen (T28)

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-19) |
|---|---|---|---|---|
| Querschnecke (Anwahl) | Umschalter mit Schlüssel | „Erlaubt das Abwählen der Querschnecke. Dadurch wird kein Produkt in den Trichter nachgefüllt.“ Zustand Ein/Aus mit Symbol und Wort | HM-20 mit [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | T28 Nr. 1 |
| Rührer (Anwahl) | Umschalter mit Schlüssel | „Abwahl für den Rührer im Trichter.“ | HM-20 mit HM-08 | T28 Nr. 2 |
| Manuell | Aktionstaste mit Schlüssel (Antippen) | „Anforderung eines Dosiervorgangs.“ (Handbuch „Manuel“, Bildbeschriftung „Manuell“) | HM-20 mit [HM-07](../Module/HM-07_Aktionstaste.md) | T28 Nr. 3 |
| Entleeren | Aktionstaste mit Schlüssel (Dauerfunktion) | „Der Dosierer fördert kontinuierlich Produkt, bis der Vorgang abgebrochen wird.“ Zustand „Läuft“ mit Symbol und Wort; Abbruch durch erneutes Antippen (S19-4) | HM-20 mit HM-07 | T28 Nr. 4 |
| Eichdosierung (Taste) | Aktionstaste mit Schlüssel | „Es wird ein Dosiervorgang gestartet. Der Dosierer macht die im Feld Eichdosierung Umdrehungen angegebenen Umdrehungen. Das dosierte Produkt muss aufgefangen und gewogen werden. Das Gewicht in das Feld Eichdosierung eintragen.“ | HM-20 mit HM-07 | T28 Nr. 5 |
| Regulierung aktiv | Umschalter, ohne Schlüssel | „Die automatische Regulierung kann mit dieser Schaltfläche abgewählt werden.“ | HM-20 mit HM-08 | T28 Nr. 6 |

### Navigation (T29, Funktionsleiste)

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-19) |
|---|---|---|---|---|
| Gewichtskorrektur | Aktionstaste (Navigation) in der Funktionsleiste | „Öffnet eine Seite, welches erlaubt die Dosiergenauigkeit zu verbessern.“ (sic) Ziel [HS-21](../Seiten/HS-21_Gewichtskorrektur.md) | HM-07 in [HM-06](../Module/HM-06_Funktionsleiste.md) | T29 Nr. 1 |
| Motorparameter | Aktionstaste (Navigation) in der Funktionsleiste | „Öffnet die Seite für die Motorparameter für den aktuellen Dosierer.“ Ziel [HS-20](../Seiten/HS-20_Motorparameter.md) | HM-07 in HM-06 | T29 Nr. 2 |
| Regulierung | Aktionstaste (Navigation) in der Funktionsleiste | „Öffnet die Seite Regulierung.“ Ziel [HS-23](../Seiten/HS-23_Regulierung.md) | HM-07 in HM-06 | T29 Nr. 3 |

Weitere Elemente nur im Referenzbild (Logo, Seitentitel, Spiral-Symbol, Uhrzeit/Datum, Meldezeile, Schloss, „Produktion“, „Einstellungen“, „Zurück“) sind in der Tabelle „Rahmen und Kopf“ zugeordnet. Pfeiltasten gibt es nicht (nur ein Nachdosierer).

## Verwendete Module (IDs)

- [HM-01](../Module/HM-01_Seitenleiste.md) – Seitenleiste
- [HM-02](../Module/HM-02_Kopfzeile.md) – Kopfzeile (enthält HM-03)
- [HM-03](../Module/HM-03_Meldezeile.md) – Meldezeile
- [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) – Brotkrümel-Navigation
- [HM-05](../Module/HM-05_Kennzahl-Kachel.md) – Kennzahl-Kachel
- [HM-06](../Module/HM-06_Funktionsleiste.md) – Funktionsleiste unten
- [HM-07](../Module/HM-07_Aktionstaste.md) – Aktionstaste
- [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) – Zustandstaste / Umschalter
- [HM-09](../Module/HM-09_Status-LED.md) – Status-LED
- [HM-10](../Module/HM-10_Fortschrittsbalken.md) – Fortschrittsbalken
- [HM-11](../Module/HM-11_Anzeigefeld.md) – Anzeigefeld
- [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) – Eingabefeld mit Schlüsselsymbol
- [HM-13](../Module/HM-13_Eingabe-Pop-up.md) – Eingabe-Pop-up
- [HM-14](../Module/HM-14_Popup-Rahmen.md) – Pop-up-Rahmen (trägt HM-13)
- [HM-15](../Module/HM-15_Gruppenbereich.md) – Gruppenbereich (drei Panels)
- [HM-20](../Module/HM-20_Dosierer-Karte.md) – Dosierer-Karte (Darstellung Detail, Variante Nachdosierer)
- [HM-27](../Module/HM-27_Hinweis-Textfeld.md) – Hinweis-Textfeld (Eichdosierung, Max. Nachgabe)

Blättertasten (HM-19) werden nicht verwendet (nur ein Nachdosierer).


## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

- **Eingabe-Pop-up.** Antippen jedes Eingabefelds (HM-12) öffnet HM-13 in HM-14 mit Titel (Feldname), aktuellem Wert, Einheit und Grenzen; „Übernehmen“ nur bei gültigem Wert, „Abbrechen“ verwirft, Antippen außerhalb schließt nicht (Navigation.md 4.2). Der Handbuchtext der Zeile steht als Hilfetext im Pop-up (S19-6). Pop-up in der Referenz nicht beschrieben (A-20, OP-30); Grenzen sind Dummy (OP-28).
- **Berechtigung.** Schlüsselsymbol (`Icon.Key`) an allen Eingabefeldern und den Tasten Querschnecke, Rührer, Manuell, Entleeren, Eichdosierung (wie in der Referenz); „Aktuelle Nachgabe“ ist reine Anzeige (S19-1); „Regulierung aktiv“ und die Tasten der Funktionsleiste ohne Schlüssel. Ohne Rolle: `Icon.Lock`, Hinweis „Berechtigung erforderlich: <Rolle>“ bzw. Benutzer-Pop-up, kein Eingabe-Pop-up (OP-25, OP-04).
- **nIO-Logik.** Ist die Fehlmenge einer Packung größer als „Max. Nachgabe“, wird nicht dosiert und die Packung als nIO ausgeschieden („nIO“ im Handbuch nicht erklärt; Annahme: nicht in Ordnung). Die Seite zeigt das im Hinweis-Textfeld mit Symbol und Text, nicht nur über Farbe; „Aktuelle Nachgabe“ zeigt in diesem Fall nicht dosiert (Wert 0 g, S19-8).
- **Regulierung Ist.** wird auf die „Aktuelle Nachgabe“ aufaddiert und kann manuell geändert werden (Eingabefeld). Das Zusammenspiel von „Soll“ (g), Aktueller Nachgabe und „Sollgewicht“ in HS-21 ist fachlich offen (OP-45).
- **Eichdosierung.** Taste startet einen Dosiervorgang mit den Umdrehungen aus „Eichdosierung Umdrehungen“. Ein Hinweis-Textfeld (Art Info) in Gruppe 3 nennt die Schritte des Handbuchs: Produkt auffangen und wiegen, Gewicht in das Feld „Eichdosierung“ eintragen, die Maschine berechnet daraus die Umdrehungen im Automatikbetrieb (S19-5). Das Gewichtsfeld wird nicht automatisch gefüllt.
- **Entleeren.** Dauerfunktion: erstes Antippen startet („Läuft“ mit `Icon.State.On`), erneutes Antippen bricht ab.
- **Betriebszustand.** Nicht zulässige Aktionen (Manuell, Entleeren, Eichdosierung) sind deaktiviert (gestrichelte Kontur, `Brush.Text.Disabled`), Antippen nennt den Grund in der Meldezeile (A-28); fachliche Regeln sind nicht belegt (S19-4, OP-45).
- **Anzeigezustände.** Füllstand-LEDs und Auslastungsbalken zeigen Zustand über Symbol und Wort, nie nur über Farbe; Auslastung ab Warnschwelle in Statusfarbe mit `Icon.Status.Warning` und Zahl (S19-3). Eingabewerte in Textfarbe, nicht in Rot; Rot nur für Fehler.
- **Fehlerfälle.** Wert außerhalb der Grenzen: HM-12 im Zustand Fehler (Kontur `Border.Thick`, `Brush.Status.Error.Subtle`, `Icon.Status.Error`, Fehlertext). Gestörte Umschalter: Zustand Fehler mit Text. Ungültige Anzeige: „---“.
- **Navigation.** „Gewichtskorrektur“ → HS-21; „Motorparameter“ → HS-20; „Regulierung“ → HS-23; Seitenleiste „Zurück“ und Brotkrümel „Dosierer“ → HS-41; Meldezeile → HS-38. Bei offenem Pop-up sind Seitenleiste, Funktionsleiste und Inhalt gesperrt. Navigation ändert keinen Maschinenzustand.

## Prüfpunkte (Tabelle: ID | Prüfung | erwartetes Ergebnis | Status)

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-19-P01 | Zweck (RS-19-P01) | Seite zeigt Parameter, Anwahlen und Status des Schneckendosierers | offen |
| HS-19-P02 | Vollständigkeit T27 (RS-19-P02) | 13 Elemente vorhanden: Soll, Eichdosierung Umdrehungen, Eichdosierung, Max. Nachgabe, Aktuelle Nachgabe, Regulierung Ist, Schnecke Drehzahl, Rührer, Nachlauf Rührer, Querschnecke, Füllstand oben, Füllstand unten, Auslastung | offen |
| HS-19-P03 | Vollständigkeit T28 (RS-19-P03) | 6 Elemente vorhanden: Querschnecke, Rührer, Manuell, Entleeren, Eichdosierung, Regulierung aktiv | offen |
| HS-19-P04 | Vollständigkeit T29 (RS-19-P04) | 3 Tasten in der Funktionsleiste: Gewichtskorrektur, Motorparameter, Regulierung | offen |
| HS-19-P05 | Beschreibungstexte (RS-19-P05) | Funktionsbeschreibungen entsprechen den Handbuchtexten (Hilfetext im Eingabe-Pop-up, `.resx`); Begriff „nIO“ im Hinweis erhalten, Schreibweise „Manuell“ | offen |
| HS-19-P06 | Bildbezug (RS-19-P06) | Symbole der Referenz haben ein Gegenstück: Gewichtsstück (Soll), Schnecke, Waagschale, Tacho (Drehzahl, Rührer, Querschnecke), Trichter oben und unten | offen |
| HS-19-P07 | Einheiten (RS-19-P07) | Soll g, Eichdosierung Umdrehungen ohne Einheit, Eichdosierung g (2 Nachkommastellen), Max. Nachgabe g, Aktuelle Nachgabe g, Regulierung Ist g (2 Nachkommastellen), Schnecke Drehzahl 1/min, Rührer %, Nachlauf Rührer s, Querschnecke %, Auslastung %; Format Wert, geschütztes Leerzeichen, Einheit | offen |
| HS-19-P08 | Unterschied zu HS-11 (RS-19-P08) | „Max. Nachgabe“ und „Aktuelle Nachgabe“ statt „Soll absolut“; keine Taste „Einstellung Regulierung“ im Inhaltsbereich; drei Navigationstasten statt Blättertasten | offen |
| HS-19-P09 | Navigation (RS-19-P09) | „Gewichtskorrektur“ öffnet HS-21, „Motorparameter“ öffnet HS-20, „Regulierung“ öffnet HS-23 | offen |
| HS-19-P10 | nIO-Logik (RS-19-P10) | Hinweis zu „Max. Nachgabe“: Fehlmenge größer als Obergrenze → keine Dosierung, Packung nIO; Darstellung mit Symbol und Text | offen |
| HS-19-P11 | Anwahl-Tasten (RS-19-P11) | Querschnecke, Rührer und Regulierung aktiv sind Umschalter mit Symbol und Wort „Ein“/„Aus“, nicht nur über Farbe | offen |
| HS-19-P12 | Füllstände und Auslastung (RS-19-P12) | zwei Füllstände (oben, unten) mit Symbol und Wort; Auslastungsbalken mit Prozentzahl im Balken | offen |
| HS-19-P13 | Wiederverwendung (RS-19-P13) | Felder, Füllstandsanzeige, Auslastung und Tasten sind dieselben Module wie auf HS-11 (HM-07 bis HM-12 über HM-20), keine Kopien | offen |
| HS-19-P14 | Rahmenelemente (RS-19-P14) | Kopfzeile, Meldezeile, Seitenleiste (Benutzer, Home, Einstellungen, Zurück) vorhanden | offen |
| HS-19-P15 | Brotkrümel (RS-19-P15) | „Einstellung › Dosierer › Nachdosierer“; Seitentitel „Nachdosierer“ als letztes Segment | offen |
| HS-19-P16 | Keine Blättertasten | Funktionsleiste ohne Blättertasten (nur ein Nachdosierer) | offen |
| HS-19-P17 | Eingabe-Pop-up | jedes Eingabefeld öffnet HM-13 mit Einheit und Grenzen; Wert außerhalb der Grenzen zeigt Fehlertext mit Symbol | offen |
| HS-19-P18 | Berechtigung | Schlüsselsymbol an den Feldern und Tasten der Referenz, nicht an „Aktuelle Nachgabe“ (Anzeige) und „Regulierung aktiv“; Schloss und Hinweis ohne Rolle | offen |
| HS-19-P19 | Touch-Ziele | alle Felder, Umschalter und Tasten mindestens `Size.Touch.Default` hoch (Trefferfläche nie unter `Size.Touch.Min`), Abstand mindestens `Size.Touch.Gap`; Funktionstasten mindestens `Size.FunctionButton.MinWidth` breit | offen |
| HS-19-P20 | Zweiter Kanal und Tokens | kein Zustand nur über Farbe (Umschalter, LEDs, Balken, nIO, Sperre, Fehler); keine Hex- oder Pixelwerte; Texte aus `.resx` | offen |
| HS-19-P21 | Layout | drei Gruppen 4 : 4 : 4; jede Gruppe passt ohne Scrollen in den Inhaltsbereich bei Zielauflösung 1920 × 1080 | offen |

## Annahmen dieser Seite

Lokale Kennungen; der Querschnitts-Agent überführt sie in Sammeleinträge von Annahmen.md.

| Kennung | Annahme |
|---|---|
| S19-1 | „Aktuelle Nachgabe“ ist ein Anzeigefeld (HM-11) ohne Schlüssel, nicht eingebbar; das Handbuch nennt es nicht als eingebbar. |
| S19-2 | Füllstand-LEDs: Symbol und Wort; Sensor meldet Produkt = Ok, oben ohne Produkt = Aus, unten ohne Produkt = Fehler (nach HM-20). |
| S19-3 | Auslastung: Warnschwelle 90 % (HM-10); 73 % bleibt neutral. |
| S19-4 | Manuell, Entleeren, Eichdosierung sind im ungeeigneten Betriebszustand deaktiviert (A-28); die fachlichen Sperrregeln fehlen in der Quelle. Entleeren: Abbruch durch erneutes Antippen. |
| S19-5 | Hinweis-Textfeld zur Eichdosierung (Auffangen, Wiegen, Gewicht eintragen); das Gewichtsfeld wird nicht automatisch gefüllt. |
| S19-6 | Der Handbuchtext je Feld erscheint als Hilfetext im Eingabe-Pop-up (Touch kennt keine Tooltips). |
| S19-7 | „Schnecke Drehzahl“ hat die Einheit 1/min wie in HS-11 (das Referenzbild zeigt „2800“ ohne Einheit). |
| S19-8 | Das Hinweis-Textfeld zur Max. Nachgabe zeigt die nIO-Regel immer als Info; bei Fehlmenge über Max. Nachgabe wechselt es auf Warnung („nicht dosiert, Packung nIO“, nach HM-20) und „Aktuelle Nachgabe“ zeigt 0 g. „nIO“ gilt als „nicht in Ordnung“. |

## Offene Punkte

- OP-25 Berechtigungsstufen und Schlüsselsymbol; OP-04 Benutzer/Anmeldung; OP-26 Spiral-Symbol und Schloss.
- OP-27 Farbbedeutung (gelber/grüner Balken, grau/rote Füllstandsleuchten); OP-28 Wertebereiche und Standardwerte; OP-29 Einheit „Schnecke Drehzahl“ (Bild ohne Einheit, RS-11 mit 1/min); OP-30 Eingabe-Pop-up.
- OP-35 Quellfehler („Manuel“, „eine Seite, welches“, „nIO“ unerklärt); OP-38 Navigationspfade; OP-39 fehlende Zustände.
- OP-45 Bezug von „Soll“ (g) zum Hauptdosierer-Anteil und zum „Sollgewicht“ in HS-21; Editierbarkeit von „Aktuelle Nachgabe“.
- OP-17 und OP-18 (DS-04: Detail-Symbol, hellblaue Hervorhebung der Nachdosierer-Karte).
