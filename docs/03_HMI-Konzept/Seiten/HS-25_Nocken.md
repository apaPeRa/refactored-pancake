# HS-25 – Nocken
- Quelle: [RS-25](../../02_Referenz-Analyse/Seiten/RS-25_Nocken.md) (Handbuch Kapitel 25, Tabellen T34 „Einstellungen“ und T35 „Navigation (unten links)“; Bild [RS-25_01.png](../../02_Referenz-Analyse/Medien/RS-25_01.png)); Design: keine eigene Design-Seite, nur die Kachel „Nockenschaltwerk“ in [DS-02](../../01_Design-Analyse/Seiten/DS-02_Einstellungen.md) (Zugang); Aufbau aus [Designsystem](../Designsystem.md), HM-24, HM-18, HM-19.
- Navigationspfad: Einstellung › Nockenschaltwerk (Brotkrümel, [Navigation.md](../Navigation.md) Abschnitt 2; das Segment „Nocken“ der Referenz entfällt, A-34). Zugang: HS-04, Kachel „Nockenschaltwerk“; HS-26, Nockennummer antippen. Zurück-Ziel: HS-04 (Verlauf). Schlüssel `Cams` / Route `settings/cams`, Parameter `camNumber`, Mindestrolle: keine.

## Zweck
Die Maschine arbeitet mit einem elektronischen Nockenschaltwerk. Einzelne Nocken können während des Betriebs eingesehen und angepasst werden: Nockennummer wählen, Anfang und Ende (Winkel und Kompensationszeit), Typ, Geber und Bezeichnung einstellen; die Geberposition und der Status (liegt die Geberposition innerhalb der Nocke) werden laufend angezeigt. Änderungen werden erst nach „Werte schreiben“ aktiv.

## Aufbau (Bereiche, Layout)
Rahmen wie auf allen Vollseiten ([Designsystem](../Designsystem.md) Abschnitt 3.2). Funktionsleiste (links beginnend, [HM-06](../Module/HM-06_Funktionsleiste.md)): Blättertasten „«“ und „»“ ([HM-19](../Module/HM-19_Blaettertasten.md)) mit der Taste „Übersicht“ ([HM-07](../Module/HM-07_Aktionstaste.md)) dazwischen, Reihenfolge wie in der Referenz: „«“, „Übersicht“, „»“ (3 Tasten, höchstens 5 erlaubt).

Inhaltsbereich: 12-Spalten-Raster (Außenrand `Space.L`, Gutter `Space.M`), sechs Zeilen in Stern-Höhen mit Mindesthöhe `Size.Touch.Default`, Abstand `Size.Touch.Gap`. Spalten: Beschriftung 2 | Feldbereich 6 | rechte Spalte 4.

| Zeile | Beschriftung (Sp. 1–2) | Feldbereich (Sp. 3–8) | Rechte Spalte (Sp. 9–12) |
|---|---|---|---|
| 1 | Nummer: | Auswahlfeld Nockennummer mit „«“ und „»“ | – |
| 2 | Anfang: | Winkel (°), Zeit (ms), Ergebnis (°), je 2 Spalten | Position: Anzeigefeld (°) |
| 3 | Ende: | Winkel (°), Zeit (ms), Ergebnis (°), je 2 Spalten | Status: Status-LED |
| 4 | Typ: | Feld Typ (2 Spalten) und Hinweistext „0 - 1079“ (4 Spalten) | Taste „Werte schreiben“ (Spalten 9–12, über Zeile 4 und 5) |
| 5 | Geber: | Auswahlfeld Geber mit „«“ und „»“ | (Taste „Werte schreiben“ setzt sich fort) |
| 6 | Bezeichnung: | Textfeld über Spalten 3–12 | |

```
Inhaltsbereich (12 Spalten)
Nummer:      [   12   ] [<<] [>>]
Anfang:      [330 °]K  [50 ms]K  [330 °]      Position: [140 °]
Ende:        [790 °]K  [50 ms]K  [790 °]      Status:   (LED + Wort)
Typ:         [  3 ]K   0 - 1079               +---------------------+
Geber:       [Geber 1GF Hauptantrieb]K [<<]K [>>]K | Werte schreiben  K |
Bezeichnung: [        Karton ansaugen 1 3KY40        ]K  +----------+
Funktionsleiste:  [  <<  ]  [ Übersicht ]  [  >>  ]
```

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Rückverfolgung: Spalte „Herkunft“ = Zeile in [RS-25](../../02_Referenz-Analyse/Seiten/RS-25_Nocken.md) (T34 / T35 = Tabellen des Handbuchs, Bild = RS-25_01.png). Beispielwerte aus dem Bild in Klammern.

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Nummer (Nockennummer) | Auswahlfeld, Anzeige der Nummer (Bild: 12) mit Pfeiltasten „«“ und „»“, ohne Schlüssel | „Direkte Auswahl einer Nockennummer zur Anzeige oder Bearbeitung. Mit den Pfeiltasten kann zwischen Nocken geblättert werden.“ Antippen der Nummer öffnet das Eingabe-Pop-up für die direkte Eingabe (Annahme H-7); die Pfeile blättern um eine Nocke (kein Verlaufseintrag). Beschriftung „Nummer:“ wie im Bild (Handbuch: „Auswahl Fixierkurve“, OP-33) | [HM-18](../Module/HM-18_Auswahlfeld-Pfeiltasten.md), [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | T34 „Auswahl Fixierkurve“, Bild Zeile Nummer |
| Anfang | Parameterzeile: Winkel (°, Schlüssel), Zeit (ms, Schlüssel), Ergebnis (°, Anzeige) | „Eingabe der Start- und Endposition der Nocke in Bezug auf den ausgewählten Geber. Über die Zeiten können Ansprechzeiten der Hardware kompensiert werden. …“ (Beispiel 330 ° / 50 ms / 330 °) | [HM-24](../Module/HM-24_Nocken-Parameterzeile.md) (mit [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-11](../Module/HM-11_Anzeigefeld.md)) | T34 „Anfang / Ende“, Bild Zeile Anfang |
| Ende | Parameterzeile: Winkel (°, Schlüssel), Zeit (ms, Schlüssel), Ergebnis (°, Anzeige) | wie Anfang für die Endposition (Beispiel 790 ° / 50 ms / 790 °) | [HM-24](../Module/HM-24_Nocken-Parameterzeile.md) | T34 „Anfang / Ende“, Bild Zeile Ende |
| Position | Anzeigefeld, Einheit °, ohne Schlüssel | „Aktueller Wert des angewählten Gebers.“ (Beispiel 140 °), laufend aktualisiert, nur Anzeige | [HM-11](../Module/HM-11_Anzeigefeld.md) | T34 „Position“, Bild |
| Status | Status-LED mit Symbol und Wort | „Zeigt an ob die aktuelle Geberposition innerhalb der Nocke ist.“ Innerhalb: Haken und Wort „Innerhalb“; außerhalb: leerer Kreis und Wort „Außerhalb“ (Bild: grau = außerhalb); nur Anzeige | [HM-09](../Module/HM-09_Status-LED.md) | T34 „Status“, Bild |
| Typ | Eingabefeld Zahl (Bild: 3) mit Schlüsselsymbol | „Erlaubt eine Untersetzung der Nocke. Muss nach der Inbetriebnahme der Maschine nicht mehr verändert werden.“ | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | T34 „Typ“, Bild |
| Hinweistext „0 - 1079“ | Text neben dem Typ-Feld, nur Anzeige | im Handbuch nicht erklärt (vermutlich Wertebereich; Einheit unklar, OP-29); wortgetreu übernommen | [HM-11](../Module/HM-11_Anzeigefeld.md) (Darstellung Zeile, Textwert) | Bild Zeile Typ |
| Geber | Auswahlfeld (Bild: „Geber 1GF Hauptantrieb“, zweizeilig möglich) mit Pfeiltasten „«“ und „»“, alles mit Schlüsselsymbol | „Auswahl des Gebers auf den sich die Nocke bezieht. Ändert sich nicht mehr nach der Inbetriebnahme.“ Die Pfeiltasten schalten durch die Gebernamen; die Auswahl wirkt erst nach „Werte schreiben“; Text wird nicht abgeschnitten (Umbruch statt Abschneiden, OP-44) | [HM-18](../Module/HM-18_Auswahlfeld-Pfeiltasten.md) (mit Schlüssel) | T34 „Geber“, Bild |
| Bezeichnung | Textfeld (Bild: „Karton ansaugen 1 3KY40“) mit Schlüsselsymbol, über die Breite | „Name und Beschreibung der Nocke. Kann angepasst werden, wenn nötig.“ Antippen öffnet die Texteingabe (HM-13, Variante Text) | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) (Eingabeart Text), [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | T34 „Bezeichnung“, Bild |
| Werte schreiben | Aktionstaste mit Schlüsselsymbol, hohe Taste über zwei Zeilen (Höhe mindestens `Size.Touch.Large`) | „Erst nach dem Schreiben werden die Änderungen aktiv.“ Schreibt Anfang, Ende, Typ, Geber und Bezeichnung der gewählten Nocke; danach verschwindet der Zustand „Nicht geschrieben“ | [HM-07](../Module/HM-07_Aktionstaste.md) | T34 „Werte schreiben“, Bild |
| Taste „«“ (Funktionsleiste) | Blättertaste | „Erlaubt das blättern zwischen den Nocken“: vorherige Nocke (`ReplaceParameter camNumber`, kein Verlaufseintrag); am Anfang deaktiviert (gestrichelt) | [HM-19](../Module/HM-19_Blaettertasten.md) | T35 „Pfeiltasten“, Bild Fußleiste links |
| Taste „Übersicht“ (Funktionsleiste) | Aktionstaste (Navigation) mit Listen-Symbol, ohne Schlüssel | „Öffnet die Seite Nockenübersicht.“ → HS-26 | [HM-07](../Module/HM-07_Aktionstaste.md) | T35 „Übersicht“, Bild |
| Taste „»“ (Funktionsleiste) | Blättertaste | nächste Nocke; am Ende deaktiviert | [HM-19](../Module/HM-19_Blaettertasten.md) | T35 „Pfeiltasten“, Bild |
| Kopfzeile mit Logo, Titel, Wirbel-Symbol, Uhr/Datum | Rahmen | Titel „Nocken“ entfällt als Seitentitel (Brotkrümel „Nockenschaltwerk“); Betriebsart, Uhr | [HM-02](../Module/HM-02_Kopfzeile.md) | Bild Kopfzeile, „Nur im Bild“ |
| Meldezeile („*450* Palettierung nicht bereit“) | Rahmen | Aktuelle Meldung; Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | Bild Meldezeile, „Nur im Bild“ |
| Brotkrümel und Kennzahlen | Rahmen | „Einstellung › Nockenschaltwerk“; Geschwindigkeit, Maschinenwinkel | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | (Design-Rahmen) |
| Fußleiste rechts „Produktion“, „Einstellungen“, „Zurück“, Schloss | Rahmentasten | wandern in die Seitenleiste (Home, Einstellungen, Zurück, Benutzerkreis, A-35) | [HM-01](../Module/HM-01_Seitenleiste.md) | Bild Fußleiste, „Nur im Bild“ |

## Verwendete Module (IDs)
- [HM-18](../Module/HM-18_Auswahlfeld-Pfeiltasten.md) – Auswahlfeld mit Pfeiltasten (Nockennummer, Geber)
- [HM-24](../Module/HM-24_Nocken-Parameterzeile.md) – Nocken-Parameterzeile (Anfang, Ende)
- [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) – Eingabefeld mit Schlüsselsymbol (Typ, Bezeichnung)
- [HM-13](../Module/HM-13_Eingabe-Pop-up.md) – Eingabe-Pop-up, getragen von [HM-14](../Module/HM-14_Popup-Rahmen.md) – Pop-up-Rahmen
- [HM-11](../Module/HM-11_Anzeigefeld.md) – Anzeigefeld (Position, Hinweistext)
- [HM-09](../Module/HM-09_Status-LED.md) – Status-LED (Status)
- [HM-07](../Module/HM-07_Aktionstaste.md) – Aktionstaste (Werte schreiben, Übersicht)
- [HM-19](../Module/HM-19_Blaettertasten.md) – Blättertasten (Funktionsleiste)
- Rahmen: [HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md)

Kein Modul fehlt. Gewünscht (nicht angelegt): ein Listen-Symbol `Icon.List` (Taste „Übersicht“, Designsystem Abschnitt 6 kennt keines) und in [HM-18](../Module/HM-18_Auswahlfeld-Pfeiltasten.md) die Variante „Direkteingabe“ (Antippen der Anzeige öffnet HM-13), siehe Bericht.

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- **Nocke wählen:** Nockennummer direkt eingeben (Antippen, Eingabe-Pop-up) oder mit den Pfeilen neben dem Feld bzw. den Blättertasten in der Funktionsleiste blättern. Beide Pfeilpaare tun dasselbe und sind synchron (Referenz zeigt beide, Zusammenspiel nicht beschrieben, OP-25); die Funktionsleiste zeigt zusätzlich „n von m“ ([HM-19](../Module/HM-19_Blaettertasten.md)). Blättern ändert nur den Parameter `camNumber` (kein Verlaufseintrag, [Navigation.md](../Navigation.md) 5.3); am ersten/letzten Eintrag ist die Pfeiltaste deaktiviert (gestrichelt). Nicht existierende Nummer: Fehlertext im Pop-up, „Übernehmen“ gesperrt.
- **Bearbeiten:** Anfang und Ende (Winkel in ° und Kompensationszeit in ms), Typ, Geber und Bezeichnung sind änderbar. Jede Änderung markiert das Feld als „Nicht geschrieben“ (`Icon.State.Pending` und Text, [HM-24](../Module/HM-24_Nocken-Parameterzeile.md), [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md)); aktiv wird sie erst nach „Werte schreiben“. Das dritte Feld je Zeile („Ergebnis“) ist nur Anzeige, ohne Schlüssel; seine Bedeutung ist nicht beschrieben (OP-48).
- **Werte schreiben:** Die Taste ist stets bedienbar (Schlüsselsymbol). Nach dem Schreiben entfällt die Markierung; schlägt das Schreiben fehl, erscheinen Fehlersymbol und Text am Feld bzw. in der Meldezeile. Bestätigungsdialog nicht vorgesehen (im Handbuch keiner beschrieben).
- **Wechsel mit ungeschriebenen Änderungen:** Beim Blättern, Wechsel zu HS-26 oder Verlassen der Seite mit nicht geschriebenen Änderungen erscheint ein Bestätigungs-Pop-up „Änderungen verwerfen?“ mit „Verwerfen“ und „Abbrechen“ (Annahme H-8, im Handbuch nicht beschrieben; Platzhalter-Pop-up nach Navigation.md 4.1).
- **Anzeige:** Position (Geberwert) und Status werden laufend aktualisiert. Status: Haken und Wort „Innerhalb“ = Geberposition innerhalb der Nocke; leerer Kreis und „Außerhalb“ = außerhalb. Die Farbbedeutung der Referenz-LED ist nicht beschrieben (OP-27); Farbe nur zusätzlich.
- **Typ und Geber:** ändern sich nach der Inbetriebnahme nicht mehr; sie bleiben bedienbar, tragen den Schlüssel, die Rollenstufe ist offen.
- **Berechtigungen:** Schlüsselsymbole bei den Feldern Winkel und Zeit von Anfang und Ende, Typ, Geber (Feld und Pfeiltasten), Bezeichnung und Werte schreiben (Annahme laut OP-25). Die Nummernauswahl und die Blättertasten haben keinen Schlüssel. Fehlende Rolle: Schloss, Tippen öffnet das Benutzer-Pop-up und setzt die Aktion nach Anmeldung fort.
- **Navigation:** „Übersicht“ → HS-26 (Stapel: HS-25 wird abgelegt, [Navigation.md](../Navigation.md) 5.3); aus HS-26 führt die Nockennummer zurück zu HS-25 mit der gewählten Nocke. „Zurück“ in der Seitenleiste → Verlauf (HS-04). Seitenleiste „Einstellungen“ hervorgehoben.
- **Pop-ups:** Eingabe-Pop-up (Zahl, Text), Benutzer-Pop-up, Bestätigungs-Pop-up (H-8); Tiefe höchstens 2.
- **Fehlerfälle:** Wertebereiche (Nummer, Winkel, Zeit) fehlen im Handbuch (790 ° liegt über 360 °, OP-28); Grenzen sind Dummy. Ungültige Eingabe: Fehlerzustand am Feld mit Text.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-25-P01 | Nockenauswahl (RS-25-P01) | Nockennummer (Beispiel 12) direkt eingebbar; Pfeile neben dem Feld und „«“ „»“ in der Funktionsleiste blättern zwischen den Nocken | offen |
| HS-25-P02 | Anfang (RS-25-P02) | Drei Felder: Winkel in ° (330 °), Kompensationszeit in ms (50 ms), Ergebnis in ° (330 °, nicht editierbar, ohne Schlüssel) | offen |
| HS-25-P03 | Ende (RS-25-P03) | Drei Felder: Winkel in ° (790 °), Zeit in ms (50 ms), Ergebnis in ° (790 °, nicht editierbar) | offen |
| HS-25-P04 | Typ (RS-25-P04) | Eingabefeld (Beispiel 3) mit Schlüssel und Hinweistext „0 - 1079“ | offen |
| HS-25-P05 | Geber (RS-25-P05) | Auswahl des Gebers (Beispiel „Geber 1GF Hauptantrieb“, nicht abgeschnitten) über „«“ und „»“, mit Schlüssel | offen |
| HS-25-P06 | Bezeichnung (RS-25-P06) | Textfeld für Name und Beschreibung (Beispiel „Karton ansaugen 1 3KY40“) mit Schlüssel | offen |
| HS-25-P07 | Position (RS-25-P07) | Aktueller Geberwert in ° (Beispiel 140 °), nicht editierbar | offen |
| HS-25-P08 | Status (RS-25-P08) | LED zeigt, ob die Geberposition innerhalb der Nocke liegt, mit Symbol und Wort, nicht nur über Farbe | offen |
| HS-25-P09 | Werte schreiben (RS-25-P09) | Änderungen werden erst nach der Taste aktiv; bis dahin sind geänderte Felder mit „Nicht geschrieben“ (Symbol und Text) markiert | offen |
| HS-25-P10 | Funktionsleiste (RS-25-P10) | Tasten „«“, „Übersicht“, „»“ in dieser Reihenfolge; „Übersicht“ öffnet HS-26, die Pfeile blättern zwischen Nocken ohne Verlaufseintrag | offen |
| HS-25-P11 | Schlüsselsymbole (RS-25-P11) | Winkel und Zeit (Anfang, Ende), Typ, Geber (Feld und Pfeile), Bezeichnung und Werte schreiben tragen den Schlüssel; Nummer, Ergebnisfelder, Position, Status nicht | offen |
| HS-25-P12 | Zugang (RS-25-P12) | Erreichbar über Einstellung › Nockenschaltwerk (HS-04) und über die Nockennummer in HS-26; Brotkrümel „Einstellung › Nockenschaltwerk“ | offen |
| HS-25-P13 | Bildabdeckung (RS-25-P13) | Jedes Element aus [RS-25_01.png](../../02_Referenz-Analyse/Medien/RS-25_01.png) (Zeilen Nummer, Anfang, Ende, Position, Status, Typ, Geber, Bezeichnung, Werte schreiben, Funktionstasten, Rahmen) ist in der Elemente-Tabelle wiederzufinden | offen |
| HS-25-P14 | Ungeschriebene Änderungen | Blättern, „Übersicht“ oder Verlassen mit nicht geschriebenen Änderungen öffnet das Bestätigungs-Pop-up; „Abbrechen“ bleibt auf der Nocke mit den Änderungen | offen |
| HS-25-P15 | Eingabe-Pop-up | Titel mit Feldname, Einheit, Grenzen, „Übernehmen“ nur bei gültigem Wert, „Abbrechen“ verwirft | offen |
| HS-25-P16 | Touch-Ziele | Alle Felder und Tasten ≥ `Size.Touch.Default` hoch (Untergrenze `Size.Touch.Min`), Abstand ≥ `Size.Touch.Gap`; Funktionsleisten-Tasten mindestens `Size.FunctionButton.MinWidth` breit | offen |
| HS-25-P17 | Zweiter Kanal und Tokens | Kein Zustand nur über Farbe; keine Hex- oder Pixelwerte, Rote Schrift der Referenzwerte entfällt, Werte in `Font.Weight.Strong` | offen |
| HS-25-P18 | Berechtigung fehlt | Schloss statt Schlüssel; Tippen öffnet das Benutzer-Pop-up; Wert bleibt unverändert | offen |

## Offene Punkte
- OP-25: Berechtigungsstufe der Schlüsselsymbole und Zusammenspiel der doppelten Pfeiltasten (Feld und Funktionsleiste) nicht beschrieben.
- OP-27: Farbbedeutung der Status-LED nicht beschrieben; Symbol und Wort statt Farbe.
- OP-28: Wertebereiche für Nummer, Zeit (ms) und Winkel fehlen (790 ° über 360 °); Dummy-Grenzen.
- OP-29: Bedeutung und Einheit von „0 - 1079“ neben Typ unklar; Wortlaut übernommen.
- OP-33: Handbuch „Auswahl Fixierkurve“, Bild „Nummer:“; Beschriftung „Nummer:“ nach dem Bild.
- OP-44: Geber-Bezeichnung im Bild abgeschnitten („Hauptantrie“); vollständiger Name „Geber 1GF Hauptantrieb“ aus dem Handbuch, Liste der wählbaren Geber unbekannt.
- OP-48: Bedeutung des dritten Feldes je Zeile Anfang/Ende (schwarz) unklar; als berechnetes Ergebnis dargestellt, ohne Fachlogik.
- Annahmen dieser Seite (Nummerierung für den Verwalter): H-7 Direkteingabe der Nockennummer über Antippen der Anzeige (Eingabe-Pop-up); H-8 Bestätigungs-Pop-up beim Wechsel oder Verlassen mit ungeschriebenen Änderungen.
