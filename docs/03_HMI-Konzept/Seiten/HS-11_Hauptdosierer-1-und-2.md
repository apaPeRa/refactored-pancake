# HS-11 – Hauptdosierer 1 & 2

- Quelle: [RS-11](../../02_Referenz-Analyse/Seiten/RS-11_Hauptdosierer-1-und-2.md) (Funktionsumfang, Tabellen T14, T15, T16, Prüfpunkte); [DS-04](../../01_Design-Analyse/Seiten/DS-04_Dosierer.md) (Design der Dosierer-Übersicht, nur Orientierung für Karteninhalt, Detail-Symbol und Rahmen; das Design kennt keine Detailseite, OP-07, OP-15); Zugänge und Brotkrümel nach [Navigation.md](../Navigation.md).
- Navigationspfad: Einstellung › Dosierer › Hauptdosierer (Objektkennung „1“ bzw. „2“, Seitentitel „Hauptdosierer 1“ bzw. „Hauptdosierer 2“). Zugang: [HS-41](../Seiten/HS-41_Dosierer-Uebersicht.md) Detail-Symbol in der Karte Hauptdosierer 1 oder 2 (Parameter `doserIndex`); die Blättertasten wechseln HD 1 ⇄ HD 2. Zurück-Ziel: HS-41. Seitenschlüssel `MainDosers` / `settings/dosers/main`.

## Zweck

Wortgetreu (Handbuch): „Die Seite Hauptdosierer beinhaltet die Parameter, die Anwahlen und den Status der beiden Schneckendosierer.“ Eine Seite bedient beide Hauptdosierer; welcher Dosierer gezeigt wird, steht im Parameter `doserIndex` (1 oder 2) und in der Titelzeile. Der Bediener stellt hier Sollanteil, Eichdosierung, Drehzahlen von Schnecke, Rührer und Querschnecke ein, wählt Rührer, Querschnecke und Regulierung an oder ab, löst Dosiervorgänge aus und liest Trichterfüllstand und Auslastung ab.

## Aufbau (Bereiche, Layout)

Rahmen wie auf allen Seiten (Seitenleiste 3\*, Arbeitsbereich 37\*; Kopfzeile 4\*, Brotkrümel/Kennzahlen 3\*, Inhalt 34\*, Funktionsleiste 4\*, siehe Designsystem 3.2). Der **Inhaltsbereich** (Außenrand `Size.Content.Margin`, 12-Spalten-Raster mit Gutter `Space.M`) hat zwei Zeilen:

| Zeile | Höhe | Inhalt |
|---|---|---|
| 1 | Auto (Titelzeile, Höhe `Size.Touch.Default`) | Objektüberschrift „Hauptdosierer 1“ bzw. „Hauptdosierer 2“ über alle 12 Spalten |
| 2 | Rest (1\*) | drei Gruppenbereiche (Panel) **4 : 4 : 4** Spalten, wie die drei Karten in DS-04 (Raster aus Designsystem 3.3 „DS-04 Dosierer“) |

```
Inhaltsbereich (12 Spalten, Gutter Space.M)
+--------------------------------------------------------------------------+
| Titelzeile: Hauptdosierer 1                                    (HM-17)   |
+------------------------+------------------------+------------------------+
| Sollwerte und          | Schnecke, Rührer,      | Status und Bedienung   |
| Eichdosierung (4 Sp.)  | Querschnecke (4 Sp.)   | (4 Sp.)                |
|  Soll          [ % ]   |  Schnecke Drehzahl[1/min]| Füllstand Trichter     |
|  Soll absolut  [ g ]   |  Rührer  Schalter Ein/Aus|   oben  [LED] Wort     |
|  Regulierung Ist [g]   |  Rührer          [ % ]   |   unten [LED] Wort     |
|  ---- Eichdosierung    |  Nachlauf Rührer [ s ]   | Auslastung  [=== 91 %] |
|  Umdrehungen    [ ]    |  Querschnecke Schalter   | Regulierung aktiv  Ein |
|  Eichdosierung  [ g ]  |  Querschnecke    [ % ]   | [Manuell] [Entleeren]  |
|                        |                          | [ Eichdosierung ]      |
|                        |                          | [ Einstellung Regul. ] |
+------------------------+------------------------+------------------------+
| Funktionsleiste: [«] [»]  1 von 2   [Motorparameter]                      |
+--------------------------------------------------------------------------+
```

- **Gruppe 1 „Sollwerte und Eichdosierung“:** drei Zeilen Sollwerte, Zwischenüberschrift „Eichdosierung“ (Linie `Brush.Divider`, keine Unterstreichung), zwei Eichfelder. Ein Hinweis-Textfeld zum Ablauf der Eichdosierung steht unter den beiden Eichfeldern.
- **Gruppe 2 „Schnecke, Rührer, Querschnecke“:** Drehzahl der Schnecke; Rührer (Umschalter, Sollgeschwindigkeit, Nachlauf); Querschnecke (Umschalter, Sollgeschwindigkeit). Der Umschalter steht jeweils über seinem Feld.
- **Gruppe 3 „Status und Bedienung“:** die beiden Füllstandsanzeigen, der Auslastungsbalken, der Umschalter „Regulierung aktiv“, die Tasten „Manuell“ und „Entleeren“ (nebeneinander, je mindestens `Size.Button.MinWidth`), die Taste „Eichdosierung“ und die Navigationstaste „Einstellung Regulierung“ (je volle Gruppenbreite). Die Anordnung entspricht [HS-19](../Seiten/HS-19_Nachdosierer.md).
- Zeilenhöhen: Eingabefelder, Umschalter und Tasten `Size.Touch.Default`, Abstand zwischen Touch-Zielen `Size.Touch.Gap`. Die Summe jeder Gruppe passt in die Höhe des Inhaltsbereichs, ohne zu scrollen (Prüfpunkt HS-11-P21).
- Die Funktionsleiste enthält links das Blätterpaar (HM-19, mit Positionsanzeige „1 von 2“) und danach die Taste „Motorparameter“ (3 Tasten, höchstens 5 erlaubt).

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)

Die Spalte „Herkunft (RS-11)“ gibt die Zeile der Referenz an (T14 = Parameter und Status, T15 = Schaltflächen, T16 = Navigation, W = „Weitere Elemente, die nur im Screenshot sichtbar sind“). Die Beispielwerte (z. B. 52 %) stammen aus dem Referenzbild und sind keine Standardwerte (OP-28). Das Detail-Layout der Gruppen setzt das Kompositmodul [HM-20](../Module/HM-20_Dosierer-Karte.md) (Darstellung Detail, Variante Hauptdosierer) um; die Einzelfelder sind in der Tabelle mit dem enthaltenen Grundmodul genannt.

### Rahmen und Kopf

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-11) |
|---|---|---|---|---|
| Seitenleiste: Benutzerkreis, Home, Einstellungen, Meldungen, Zurück | Rahmen | übernimmt Schloss (Anmeldestatus), „Produktion“, „Einstellungen“ und „Zurück“ der Referenz (A-35); „Zurück“ öffnet den obersten Verlaufseintrag (HS-41) | [HM-01](../Module/HM-01_Seitenleiste.md) | W: Schloss-Symbol, Tasten „Produktion“, „Einstellungen“, „Zurück“ |
| Kopfzeile: Logo, Betriebsart, Uhrzeit/Datum | Rahmen | Logo, Betriebsart statt Spiral-Symbol (Bedeutung des Spiral-Symbols in der Referenz unbekannt, OP-26), Uhrzeit und Datum | [HM-02](../Module/HM-02_Kopfzeile.md) | W: Logo, Spiral-Symbol, Uhrzeit/Datum |
| Meldezeile | Anzeige | aktuelle Meldung (Referenzbild: „*450* Palettierung nicht bereit“); Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | W: Meldezeile |
| Brotkrümel „Einstellung › Dosierer › Hauptdosierer 1“ | Navigation | Seitenpfad; letztes Segment ersetzt den Seitentitel der Referenz, Objektkennung „1“ bzw. „2“; „Dosierer“ führt zu HS-41, „Einstellung“ zu HS-04 | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | W: Seitentitel „Hauptdosierer 1“ |
| Kennzahlen Geschwindigkeit, Maschinenwinkel | Anzeige | Rahmenkennzahlen (Geschwindigkeit öffnet HS-03) | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | (Rahmen, nicht in RS-11) |
| Titelzeile „Hauptdosierer 1“ / „Hauptdosierer 2“ | Überschrift | benennt den gerade gezeigten Dosierer, ohne Kennwerte und ohne Detail-Symbol; wechselt mit den Blättertasten | [HM-17](../Module/HM-17_Titelzeile.md) | W: Seitentitel „Hauptdosierer 1“; Prüfpunkt RS-11-P15 |

### Parameter und Status (T14)

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-11) |
|---|---|---|---|---|
| Soll | Eingabefeld mit Schlüssel, Beschriftung fett, Einheit % | „Anteil des Zielgewichts, welches bei der Kontrollwaage angegeben wird, welches für den jeweiligen Hauptdosierer abzufüllen ist.“ Beispiel 52 % | [HM-20](../Module/HM-20_Dosierer-Karte.md) (Detail) mit [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) | T14 Nr. 1 |
| Soll absolut | Anzeigefeld, Einheit g, Symbol Gewichtsstück | „Das abzufüllende Gewicht. Ergibt sich aus der Zielgewicht und dem prozentualen Anteil des Dosierers.“ Berechnet, nicht eingebbar (Annahme 3). Beispiel 122 g | HM-20 mit [HM-11](../Module/HM-11_Anzeigefeld.md) | T14 Nr. 2 |
| Eichdosierung Umdrehungen | Eingabefeld mit Schlüssel, ohne Einheit, Symbol Schnecke | „Anzahl Umdrehungen der Dosierschnecke welche bei der Eichdosierung ausgeführt wird. Anhand der Umdrehungen und des Gewichtes im Feld Eichdosierung berechnet die Maschine die Umdrehungen im Automatikbetrieb.“ Beispiel 4 | HM-20 mit HM-12 | T14 Nr. 3 |
| Eichdosierung (Gewicht) | Eingabefeld mit Schlüssel, Einheit g, 2 Nachkommastellen, Symbol Waagschale | „Hier wird das Gewicht, des während der Eichdosierung dosierten Produkts, eingetragen.“ Beispiel 137,50 g | HM-20 mit HM-12 | T14 Nr. 4 |
| Regulierung Ist | Eingabefeld mit Schlüssel, Einheit g, 2 Nachkommastellen | „Aktueller Korrekturwert von der Regulierung. Dieses Gewicht wird auf das Soll absolut aufaddiert. Der Wert kann manuell geändert werden.“ Beispiel 0,00 g | HM-20 mit HM-12 | T14 Nr. 5 |
| Schnecke Drehzahl | Eingabefeld mit Schlüssel, Einheit 1/min, Symbol Tacho | „Solldrehzahl der Dosierschnecke.“ Beispiel 2800 1/min | HM-20 mit HM-12 | T14 Nr. 6 |
| Rührer (Sollgeschwindigkeit) | Eingabefeld mit Schlüssel, Einheit %, Symbol Tacho | „Sollgeschwindigkeit des Rührers im Trichter.“ Beispiel 20 % | HM-20 mit HM-12 | T14 Nr. 7 |
| Nachlauf Rührer | Eingabefeld mit Schlüssel, Einheit s | „Zeit, welche der Rührer bei einem Stopp der Maschine nachläuft.“ Beispiel 0 s | HM-20 mit HM-12 | T14 Nr. 8 |
| Querschnecke (Sollgeschwindigkeit) | Eingabefeld mit Schlüssel, Einheit %, Symbol Tacho | „Sollgeschwindigkeit der Querschnecke in der Produktzuführung.“ Beispiel 20 % | HM-20 mit HM-12 | T14 Nr. 9 |
| Füllstand Trichter oben | Status-LED mit Trichter-Symbol, Beschriftung „oben“ | „Zeigt den Status des Sensors im oberen Bereich des Trichters an.“ Zustand mit Symbol und Wort (Annahme 4) | HM-20 mit [HM-09](../Module/HM-09_Status-LED.md) | T14 Nr. 10 |
| Füllstand Trichter unten | Status-LED mit Trichter-Symbol, Beschriftung „unten“ | „Zeigt den Status des Sensors im unteren Bereich des Trichters an.“ Beschriftung „Füllstand:“ der Referenz als Gruppenzeile über beiden LEDs | HM-20 mit HM-09 | T14 Nr. 11 |
| Auslastung | Fortschrittsbalken mit Zahl im Balken, Einheit % | „Zeigt an wieviel Prozent der verfügbaren Zeit der Dosiervorgang benötigt. Die Zeit ergibt sich aus der Länge der Nocke für den Dosierer und der Maschinengeschwindigkeit.“ Beispiel 91 %; ab Warnschwelle Statusfarbe mit Symbol (Annahme 5) | HM-20 mit [HM-10](../Module/HM-10_Fortschrittsbalken.md) | T14 Nr. 12 |

### Schaltflächen (T15)

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-11) |
|---|---|---|---|---|
| Einstellung Regulierung | Aktionstaste (Navigation), ohne Schlüssel | „Öffnet die Seite Regulierung.“ Ziel [HS-23](../Seiten/HS-23_Regulierung.md); Taste bleibt wie in der Referenz im Inhaltsbereich (Annahme 2) | [HM-07](../Module/HM-07_Aktionstaste.md) | T15 Nr. 1 |
| Querschnecke (Anwahl) | Umschalter mit Schlüssel | „Erlaubt das Abwählen der Querschnecke. Dadurch wird kein Produkt in den Trichter nachgefüllt.“ Zustand Ein/Aus mit Symbol und Wort | HM-20 mit [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | T15 Nr. 2 |
| Rührer (Anwahl) | Umschalter mit Schlüssel | „Abwahl für den Rührer im Trichter.“ | HM-20 mit HM-08 | T15 Nr. 3 |
| Manuell | Aktionstaste mit Schlüssel (Antippen) | „Anforderung eines Dosiervorgangs.“ (Handbuch „Manuel“, Bildbeschriftung „Manuell“; Schreibweise „Manuell“) | HM-20 mit HM-07 | T15 Nr. 4 |
| Entleeren | Aktionstaste mit Schlüssel (Dauerfunktion) | „Der Dosierer fördert kontinuierlich Produkt, bis der Vorgang abgebrochen wird.“ Läuft-Zustand mit Symbol und Wort „Läuft“; Abbruch durch erneutes Antippen (Annahme 8) | HM-20 mit HM-07 | T15 Nr. 5 |
| Eichdosierung (Taste) | Aktionstaste mit Schlüssel | „Es wird ein Dosiervorgang gestartet. Der Dosierer macht die im Feld Eichdosierung Umdrehungen angegebenen Umdrehungen. Das dosierte Produkt muss aufgefangen und gewogen werden. Das Gewicht in das Feld Eichdosierung eintragen.“ | HM-20 mit HM-07 | T15 Nr. 6 |
| Regulierung aktiv | Umschalter, ohne Schlüssel | „Die automatische Regulierung kann mit dieser Schaltfläche abgewählt werden.“ | HM-20 mit HM-08 | T15 Nr. 7 |

### Navigation unten links (T16)

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-11) |
|---|---|---|---|---|
| Pfeiltasten „«“ „»“ mit Positionsanzeige „1 von 2“ | Blättertasten (Paar) in der Funktionsleiste | „Schaltet die Seiten zwischen den beiden Hauptdosieren um.“ (sic) Ändert nur `doserIndex`, kein Verlaufseintrag; an den Rändern deaktiviert (HD 1: „«“, HD 2: „»“) | [HM-19](../Module/HM-19_Blaettertasten.md) in [HM-06](../Module/HM-06_Funktionsleiste.md) | T16 Nr. 1 |
| Motorparameter | Aktionstaste (Navigation) in der Funktionsleiste | „Öffnet die Seite für die Motorparameter für den aktuellen Dosierer.“ Ziel [HS-12](../Seiten/HS-12_Motorparameter.md) mit demselben `doserIndex` | HM-07 in HM-06 | T16 Nr. 2 |

### Weitere Elemente nur im Referenzbild

Logo, Seitentitel, Spiral-Symbol, Uhrzeit/Datum, Meldezeile, Schloss und die Tasten „Produktion“, „Einstellungen“, „Zurück“ sind in den Tabellen „Rahmen und Kopf“ oben zugeordnet (Zeilen mit Herkunft „W“).

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
- [HM-17](../Module/HM-17_Titelzeile.md) – Titelzeile (Objektüberschrift)
- [HM-19](../Module/HM-19_Blaettertasten.md) – Blättertasten
- [HM-20](../Module/HM-20_Dosierer-Karte.md) – Dosierer-Karte (Darstellung Detail, Variante Hauptdosierer)
- [HM-27](../Module/HM-27_Hinweis-Textfeld.md) – Hinweis-Textfeld (Ablaufhinweis Eichdosierung)

Fehlendes Modul: keines. Ergänzungswunsch: HM-17 führt HS-11 und HS-12 nicht in „Verwendet auf Seiten“ (siehe Bericht).

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

- **Dosierer-Wechsel.** „«“ und „»“ setzen `doserIndex` (1 oder 2) per `ReplaceParameter`; Titelzeile, Brotkrümel-Objektkennung und alle Werte wechseln, der Verlauf bekommt keinen neuen Eintrag (Navigation.md 5.3). Auf HD 1 ist „«“, auf HD 2 ist „»“ deaktiviert (gestrichelte Kontur, Positionsanzeige „1 von 2“ als zweiter Kanal; Annahme 6, löst RS-11 Offenen Punkt 4).
- **Eingabe-Pop-up.** Antippen jedes Eingabefelds (HM-12) öffnet das Eingabe-Pop-up HM-13 in HM-14 mit Titel (Feldname), aktuellem Wert, Einheit und Grenzen; „Übernehmen“ nur bei gültigem Wert, „Abbrechen“ verwirft. Antippen außerhalb schließt nicht (Navigation.md 4.2). Der Handbuchtext der Zeile steht als Hilfetext im Pop-up (Annahme 7). Das Pop-up ist in der Referenz nicht beschrieben (A-20, OP-30). Wertgrenzen sind Dummy (OP-28).
- **Berechtigung.** Schlüsselsymbol (`Icon.Key`) an den Feldern und Tasten, die in der Referenz einen Schlüssel tragen: alle Eingabefelder, Querschnecke, Rührer, Manuell, Entleeren, Eichdosierung. Ohne ausreichende Rolle: Schloss (`Icon.Lock`), Antippen öffnet das Benutzer-Pop-up bzw. den Hinweis „Berechtigung erforderlich: <Rolle>“; es öffnet kein Eingabe-Pop-up. „Regulierung aktiv“ und „Einstellung Regulierung“ tragen wie in der Referenz keinen Schlüssel (Stufen und Rollen offen, OP-25, OP-04).
- **Betriebszustand.** Ist eine Aktion im aktuellen Betriebszustand nicht zulässig (zum Beispiel Dosiervorgang bei laufender Produktion), sind „Manuell“, „Entleeren“ und „Eichdosierung“ deaktiviert (gestrichelte Kontur, `Brush.Text.Disabled`); Antippen nennt den Grund in der Meldezeile (A-28). Die fachlichen Sperrregeln stehen nicht in der Quelle (Annahme 8, OP-45).
- **Entleeren.** Dauerfunktion: erstes Antippen startet, Zustand „Läuft“ mit `Icon.State.On`; erneutes Antippen bricht ab.
- **Eichdosierung.** Taste startet einen Dosiervorgang mit den Umdrehungen aus dem Feld „Eichdosierung Umdrehungen“. Ein Hinweis-Textfeld (Art Info) bei den Eichfeldern nennt die Schritte des Handbuchs: Produkt auffangen und wiegen, Gewicht in das Feld „Eichdosierung“ eintragen; die Maschine berechnet daraus die Umdrehungen im Automatikbetrieb (Annahme 9). Das Gewichtsfeld wird nicht automatisch gefüllt.
- **Anzeigezustände.** Füllstand-LEDs und Auslastungsbalken zeigen Zustand über Symbol und Wort, nie nur über Farbe. Auslastung ab Warnschwelle (Annahme 5): Statusfarbe, `Icon.Status.Warning` und Zahl. Eingabewerte stehen in Textfarbe (`Brush.Text.Primary`), nicht in Rot; Rot nur für Fehler (Designsystem 1.2).
- **Fehlerfälle.** Wert außerhalb der Grenzen: HM-12 im Zustand Fehler (Kontur `Border.Thick`, `Brush.Status.Error.Subtle`, `Icon.Status.Error`, Fehlertext), Übernehmen gesperrt. Gestörte Umschalter: Zustand Fehler mit Text (HM-08). Ungültiger Anzeigewert: „---“ (HM-11).
- **Navigation.** „Einstellung Regulierung“ → HS-23; „Motorparameter“ → HS-12 (aktueller Dosierer); Seitenleiste „Zurück“ und Brotkrümel „Dosierer“ → HS-41; Meldezeile → HS-38. Bei offenem Pop-up sind Seitenleiste, Funktionsleiste und Inhalt gesperrt.
- **Rolle der Navigation.** Navigation ändert keinen Maschinenzustand (Navigation.md 0.6).

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-11-P01 | Zweck (RS-11-P01) | Seite zeigt Parameter, Anwahlen und Status der Schneckendosierer; eine Seite für HD 1 und HD 2 | offen |
| HS-11-P02 | Vollständigkeit T14 (RS-11-P02) | 12 Elemente vorhanden: Soll, Soll absolut, Eichdosierung Umdrehungen, Eichdosierung, Regulierung Ist, Schnecke Drehzahl, Rührer, Nachlauf Rührer, Querschnecke, Füllstand oben, Füllstand unten, Auslastung | offen |
| HS-11-P03 | Vollständigkeit T15 (RS-11-P03) | 7 Elemente vorhanden: Einstellung Regulierung, Querschnecke, Rührer, Manuell, Entleeren, Eichdosierung, Regulierung aktiv | offen |
| HS-11-P04 | Vollständigkeit T16 (RS-11-P04) | Blättertasten und Taste „Motorparameter“ in der Funktionsleiste vorhanden | offen |
| HS-11-P05 | Beschreibungstexte (RS-11-P05) | Funktionsbeschreibungen entsprechen den Handbuchtexten (Hilfetext im Eingabe-Pop-up, `.resx`); Schreibweise „Manuell“ | offen |
| HS-11-P06 | Bildbezug (RS-11-P06) | jedes Symbol der Referenz hat ein Gegenstück: Gewichtsstück, Schnecke, Waagschale, Tacho (Soll absolut, Eichdosierung Umdrehungen, Eichdosierung, Schnecke Drehzahl, Rührer, Querschnecke), Trichter oben und unten | offen |
| HS-11-P07 | Einheiten (RS-11-P07) | Soll %, Soll absolut g, Eichdosierung Umdrehungen ohne Einheit, Eichdosierung g (2 Nachkommastellen), Regulierung Ist g (2 Nachkommastellen), Schnecke Drehzahl 1/min, Rührer %, Nachlauf Rührer s, Querschnecke %, Auslastung %; Format Wert, geschütztes Leerzeichen, Einheit | offen |
| HS-11-P08 | Soll absolut (RS-11-P08) | Anzeige, berechnet aus Zielgewicht und Prozentanteil, nicht eingebbar, ohne Schlüssel | offen |
| HS-11-P09 | Navigation (RS-11-P09) | „Einstellung Regulierung“ öffnet HS-23; „Motorparameter“ öffnet HS-12 mit gleichem `doserIndex`; Blättertasten wechseln HD 1 ⇄ HD 2 ohne Verlaufseintrag | offen |
| HS-11-P10 | Anwahl-Tasten (RS-11-P10) | Querschnecke, Rührer und Regulierung aktiv sind Umschalter mit Symbol und Wort „Ein“/„Aus“, nicht nur über Farbe | offen |
| HS-11-P11 | Eichdosierung-Ablauf (RS-11-P11) | Taste startet Dosierung mit den Umdrehungen aus „Eichdosierung Umdrehungen“; Hinweis nennt Auffangen, Wiegen und Eintragen des Gewichts im Feld „Eichdosierung“ | offen |
| HS-11-P12 | Füllstandsanzeigen (RS-11-P12) | zwei getrennte Zustände (oben, unten) mit Symbol und Wort zusätzlich zur Farbe | offen |
| HS-11-P13 | Auslastung (RS-11-P13) | Balken mit Prozentzahl als Text im Balken; Wert in %; Warnsymbol ab Schwelle | offen |
| HS-11-P14 | Rahmenelemente (RS-11-P14) | Kopfzeile, Meldezeile, Seitenleiste mit Benutzer, Home, Einstellungen, Zurück vorhanden; Schloss der Referenz als Benutzerkreis (Navigation.md 0.5) | offen |
| HS-11-P15 | Brotkrümel (RS-11-P15) | „Einstellung › Dosierer › Hauptdosierer“ mit Objektkennung; Titelzeile „Hauptdosierer 1“ bzw. „Hauptdosierer 2“ | offen |
| HS-11-P16 | Blätterrand | auf HD 1 ist „«“, auf HD 2 ist „»“ deaktiviert; Positionsanzeige „1 von 2“ sichtbar | offen |
| HS-11-P17 | Eingabe-Pop-up | jedes der acht Eingabefelder öffnet HM-13 mit Einheit und Grenzen; Übernehmen nur bei gültigem Wert; Wert außerhalb der Grenzen zeigt Fehlertext mit Symbol | offen |
| HS-11-P18 | Berechtigung | Schlüsselsymbol an den Feldern und Tasten der Referenz (nicht an „Regulierung aktiv“ und „Einstellung Regulierung“); Schloss und Hinweis ohne Rolle | offen |
| HS-11-P19 | Touch-Ziele | alle Felder, Umschalter und Tasten mindestens `Size.Touch.Default` hoch (Trefferfläche nie unter `Size.Touch.Min`), Abstand mindestens `Size.Touch.Gap` | offen |
| HS-11-P20 | Zweiter Kanal und Tokens | kein Zustand nur über Farbe (Umschalter, LEDs, Balken, Aus-/Sperrzustand, Fehler); keine Hex- oder Pixelwerte, nur Tokens des Designsystems; Texte aus `.resx` | offen |
| HS-11-P21 | Layout | drei Gruppen 4 : 4 : 4 unter der Titelzeile; Inhalt jeder Gruppe passt ohne Scrollen in den Inhaltsbereich bei Zielauflösung 1920 × 1080 | offen |
| HS-11-P22 | Wiederverwendung | Felder, Schalter, LEDs, Balken und Tasten sind HM-07 bis HM-12 über HM-20, keine Kopien | offen |

## Offene Punkte

- OP-25 Berechtigungsstufen und Bedeutung des Schlüsselsymbols; OP-04 Benutzer/Anmeldung.
- OP-26 Bedeutung von Spiral-Symbol und Schloss (Kopf- und Fußleiste der Referenz).
- OP-27 Farbbedeutung (rote Eingabewerte, gelber Balken, grau/rote Füllstandsleuchten); neu: nur Status mit zweitem Kanal.
- OP-28 Wertebereiche und Standardwerte; OP-29 Einheiten (Schnecke Drehzahl); OP-30 Eingabe-Pop-up.
- OP-35 Quellfehler im Handbuch („Manuel“, „Hauptdosieren“, „aus der Zielgewicht“).
- OP-38 Navigationspfade (Zugang aus HS-41 nur durch die Übersicht belegt); OP-39 fehlender Screenshot Hauptdosierer 2.
- OP-45 fachliche Zusammenhänge der Dosierer (Soll absolut, Regulierung, Sperrregeln).
- OP-17 Bedeutung des Detail-Symbols in DS-04 (hier als Zugang zur Seite angenommen); OP-18 Hervorhebung und helle Tasten in DS-04.
