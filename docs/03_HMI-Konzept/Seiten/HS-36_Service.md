# HS-36 – Service

- Quelle: [RS-36](../../02_Referenz-Analyse/Seiten/RS-36_Service.md) (Kapitel 36, Tabelle 46, Bild RS-36_01); Design: keine eigene Design-Seite, Aufbau aus [Designsystem](../Designsystem.md) und den Modulen abgeleitet
- Navigationspfad: Einstellung › Systemeinstellungen › Service (Zugang: [HS-35](HS-35_Systemeinstellungen.md), Kachel „Service“ mit Schlüsselsymbol, Mindestrolle Technik; Zurück-Ziel: HS-35; Seitenregister `Service` / `settings/system/service`)

## Zweck

Sicherung und Wiederherstellung von Maschinenparametern: Alle oder ausgewählte Variablen inklusive ihrer aktuellen Werte werden in einer Datei gespeichert und bei Bedarf wieder eingelesen (Handbuch). Die Seite ist berechtigungspflichtig und läuft in der Betriebsart „Service“, die in der Kopfzeile sichtbar ist (A-48).

## Aufbau (Bereiche, Layout)

Rahmen wie in HS-35: [HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md) mit [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md). Der rote Schriftzug „Service“ und das Wirbelsymbol der Referenzkopfzeile erscheinen als Betriebsart „Service“ in der Kopfzeile (Symbol `Icon.Mode.Service`, Fläche `Brush.Status.Warning.Fill`, Wort „Service“; kein Rot, A-48).

**Inhaltsbereich** (12-Spalten-Raster, Außenrand `Space.L`, Gutter `Space.M`): zwei Bereiche **8 : 4**.

```
Inhaltsbereich (12 Spalten)
+--------------------------------------------+-------------------------+
| Spalten 1-8: Variablen                     | Spalten 9-12: Aktionen  |
| +----------------------------------------+ | +---------------------+ |
| | Filterfeld (Text, ohne Schluessel)     | | | Wert der markierten | |
| +----------------------------------------+ | | Variable "859,81"   | |
| | Variablenliste (Zeilen, scrollbar)     | | +---------------------+ |
| |  .G_astGeber[1].alrPos[10]  <markiert> | | | [ Importieren     ] | |
| |  ...                                   | | | [ Alle exportieren] | |
| |  Rollbalken / Scrolltasten             | | | [ Liste exportieren]| |
| +----------------------------------------+ | +---------------------+ |
| Zaehler: 500 von 111427 Variablen          |                         |
+--------------------------------------------+-------------------------+
Funktionsleiste unten:  [ Wago ]
```

- **Links (Spalten 1 bis 8):** Zeile 1 (Höhe `Size.Touch.Default`) Filterfeld; Zeile 2 (1\*) Variablenliste mit Scrollbedienung; Zeile 3 (`Size.Touch.Min`) Zählertext rechtsbündig „500 von 111427 Variablen“.
- **Rechts (Spalten 9 bis 12):** oben das Anzeigefeld (Höhe `Size.Field.Height`), darunter die drei Aktionstasten untereinander (je `Size.Touch.Large` hoch, Abstand `Size.Touch.Gap`), Rest frei.
- **Funktionsleiste unten:** links die Taste „Wago“; keine weiteren Tasten.

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)

Spalte „Herkunft“ = Rückverfolgung zu [RS-36](../../02_Referenz-Analyse/Seiten/RS-36_Service.md).

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Importieren | Aktionstaste (Schlüssel entfällt: Seite ist bereits geschützt) | Lädt eine zuvor gespeicherte Datei mit Variablenwerten und stellt die enthaltenen Werte wieder her. Ablauf: Dateiauswahl, Bestätigungs-Pop-up (Werte werden in die Maschine geschrieben, Annahme), Ergebnismeldung. | [HM-07](../Module/HM-07_Aktionstaste.md); Pop-ups in [HM-14](../Module/HM-14_Popup-Rahmen.md) | RS-36 Tabelle 46, Zeile 1 |
| Alle exportieren | Aktionstaste (im Bild „Alle Exportieren“, OP-34) | Speichert sämtliche aktuellen Variablen der Maschine in einer Datei. | [HM-07](../Module/HM-07_Aktionstaste.md) | RS-36 Tabelle 46, Zeile 2 |
| Liste exportieren | Aktionstaste (im Bild „Liste Exportieren“) | Speichert nur die in der Liste ausgewählten Variablen in einer Datei; ohne Auswahl deaktiviert (Grund per Tippen in der Meldezeile, A-28). | [HM-07](../Module/HM-07_Aktionstaste.md) | RS-36 Tabelle 46, Zeile 3 |
| Eingabefeld über der Liste | Textfeld ohne Schlüssel | Funktion im Handbuch nicht beschrieben; Annahme: Filter der Variablenliste nach Namensteil (OP-40). Antippen öffnet das Eingabe-Pop-up in der Textvariante. Im Bild leer. | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) (Eingabeart Text), [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | RS-36 „nur im Bild“, Zeile 1 |
| Variablenliste | Scrollbare Auswahlliste, Zeile markierbar | Zeigt Variablennamen (z. B. `.G_astGeber[1].alrPos[10]`); die Auswahl bestimmt den Umfang von „Liste exportieren“ und den Wert im Anzeigefeld. Markierte Zeile mit Rahmen und Haken (nicht nur Blau). | [HM-25](../Module/HM-25_Meldungsliste.md) (Listenart Selection) | RS-36 „nur im Bild“, Zeile 2 |
| Zählertext „500 von 111427 Variablen“ | Anzeige (n von m) | Bedeutung nicht beschrieben (Anzeigelimit oder Treffer, OP-49); Format „n von m Variablen“. | [HM-25](../Module/HM-25_Meldungsliste.md) (`TotalCount`) | Bild, Text unter der Liste |
| Zahlenanzeige „859,81“ | Anzeigefeld | Bedeutung nicht beschrieben; Annahme: aktueller Wert der markierten Variable. Im Bild rote Schrift; im neuen HMI neutral (Rot nur für Fehler). | [HM-11](../Module/HM-11_Anzeigefeld.md) (Feld, Zahl) | RS-36 „nur im Bild“, Zeile 3 |
| Betriebsart „Service“ (roter Schriftzug im Kopf) | Statusanzeige | Zeigt den Servicemodus; Symbol und Wort statt roter Schrift. | [HM-02](../Module/HM-02_Kopfzeile.md) | RS-36 „nur im Bild“, Zeile 4 |
| Taste „Wago“ | Aktionstaste, Funktionsleiste | Funktion im Handbuch nicht beschrieben (Dummy, OP-49); ersetzt „Lampentest“ der Vorseite. | [HM-06](../Module/HM-06_Funktionsleiste.md), [HM-07](../Module/HM-07_Aktionstaste.md) | RS-36 „nur im Bild“, Zeile 5 |
| Meldezeile, Tasten Produktion/Einstellungen/Zurück, Schloss | Rahmen | Wie [HS-35](HS-35_Systemeinstellungen.md): Meldezeile in der Kopfzeile, Navigationstasten und Anmeldestatus in der Seitenleiste. | [HM-03](../Module/HM-03_Meldezeile.md), [HM-01](../Module/HM-01_Seitenleiste.md) | RS-36 „nur im Bild“, Zeile 6 |
| Datei-Pop-up und Ergebnis-Pop-up (Ergänzung) | Pop-up | Dateiauswahl für Import und Export, Fortschritt, Erfolg und Fehler; im Handbuch nicht beschrieben. | [HM-14](../Module/HM-14_Popup-Rahmen.md) | Ergänzung zu „Pop-ups … nicht beschrieben“ |

## Verwendete Module (IDs)

- Rahmen: [HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md)
- Seite: [HM-07](../Module/HM-07_Aktionstaste.md), [HM-11](../Module/HM-11_Anzeigefeld.md), [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](../Module/HM-13_Eingabe-Pop-up.md), [HM-14](../Module/HM-14_Popup-Rahmen.md), [HM-25](../Module/HM-25_Meldungsliste.md)

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

- **Berechtigung.** Der Seitenzugang ist geschützt (Mindestrolle Technik, A-41): Die Kachel „Service“ in HS-35 trägt `Icon.Key` bzw. `Icon.Lock`; ohne Rolle öffnet das Benutzer-Pop-up. Auf der Seite selbst tragen die Tasten kein Schlüsselsymbol (wie in der Referenz). Bei Abmeldung navigiert der Dienst nach HS-35 und schließt offene Pop-ups ohne Übernehmen.
- **Listenauswahl.** Eine ausgewählte Zeile ist durch Rahmen (`Border.Thick`, `Brush.Border.Focus`) und Haken markiert. Die Referenz beschreibt nur eine markierte Zeile; „Liste exportieren“ verlangt „ausgewählte Variablen“, also eine Mehrfachauswahl (Annahme, Modulerweiterung nötig). Antippen einer markierten Zeile hebt die Auswahl auf.
- **Filter.** Eingabe im Filterfeld begrenzt die Liste; „n von m“ zeigt Anzeigemenge und Gesamtzahl. Leere Treffermenge: Text „Keine Variablen“.
- **Importieren.** Dateiauswahl, dann Bestätigungs-Pop-up („Werte aus Datei in die Maschine schreiben?“, Annahme), dann Fortschritt und Ergebnis. Fehler (Datei unlesbar, Wert abgelehnt) erscheinen im Ergebnis-Pop-up mit `Icon.Status.Error` und Text; nichts wird teilweise übernommen, ohne dies zu melden.
- **Exportieren.** „Alle exportieren“ und „Liste exportieren“ öffnen die Dateiauswahl (Dateiformat, Ort offen, OP-49) und melden Erfolg oder Fehler im Ergebnis-Pop-up. Während eines laufenden Vorgangs sind die drei Tasten deaktiviert (gestrichelte Kontur, Fortschrittstext).
- **Ohne Auswahl.** „Liste exportieren“ ist deaktiviert (gestrichelte Kontur); Tippen nennt den Grund in der Meldezeile.
- **Wago.** Aktionstaste ohne Navigation; Funktion offen.
- **Pop-ups.** Es ist immer nur ein Pop-up offen: Dateiauswahl, Bestätigung und Ergebnis öffnen nacheinander, nicht gestapelt; das Eingabe-Pop-up für das Filterfeld liegt über der Seite. Seitenleiste und Inhalt gesperrt; Schließen nur über „Abbrechen“ oder Kreuz (Navigation.md 4.2).
- **Zurück.** Seitenleiste „Zurück“ oder Brotkrümel-Segment „Systemeinstellungen“ führt nach HS-35.

## Prüfpunkte (Tabelle: ID | Prüfung | erwartetes Ergebnis | Status)

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-36-P01 | Navigationspfad (RS-36-P01) | Brotkrümel „Einstellung › Systemeinstellungen › Service“, Zugang über Kachel „Service“ in HS-35, Zurück nach HS-35 | offen |
| HS-36-P02 | Tasten rechts (RS-36-P02) | „Importieren“, „Alle exportieren“, „Liste exportieren“ vorhanden, untereinander, mindestens `Size.Touch.Large` hoch | offen |
| HS-36-P03 | Importieren (RS-36-P03) | Datei mit Variablenwerten wird geladen und die Werte werden wiederhergestellt; vorher Dateiauswahl und Bestätigung | offen |
| HS-36-P04 | Alle exportieren (RS-36-P04) | Sämtliche aktuellen Variablen werden in einer Datei gespeichert | offen |
| HS-36-P05 | Liste exportieren (RS-36-P05) | Nur die in der Liste ausgewählten Variablen werden in einer Datei gespeichert; ohne Auswahl ist die Taste deaktiviert | offen |
| HS-36-P06 | Variablenliste (RS-36-P06) | Scrollbare Liste mit Variablennamen; ausgewählte Zeile mit Rahmen und Haken markiert (nicht nur Farbe) | offen |
| HS-36-P07 | Mengenanzeige (RS-36-P07) | Text „500 von 111427 Variablen“ unter der Liste, Format „n von m Variablen“ | offen |
| HS-36-P08 | Eingabefeld und Zahlenfeld (RS-36-P08) | Leeres Filterfeld über der Liste; Anzeigefeld rechts oben (Bildwert 859,81) in neutraler Schrift | offen |
| HS-36-P09 | Kopfzeile (RS-36-P09) | Brotkrümel/Titel „Service“; Betriebsart „Service“ mit `Icon.Mode.Service` und Wort, Uhrzeit und Datum | offen |
| HS-36-P10 | Untere Leiste (RS-36-P10) | Taste „Wago“ links in der Funktionsleiste; Produktion, Einstellungen, Zurück und Anmeldestatus in der Seitenleiste | offen |
| HS-36-P11 | Seitenschutz | Zugang aus HS-35 ohne Rolle Technik öffnet das Benutzer-Pop-up; bei Abbruch bleibt HS-35 stehen | offen |
| HS-36-P12 | Fehlerfall | Fehler bei Import oder Export erscheint im Ergebnis-Pop-up mit `Icon.Status.Error` und Text | offen |
| HS-36-P13 | Touch-Ziele | Listenzeilen mindestens `Size.Touch.Min` hoch, Filterfeld `Size.Touch.Default`, Tasten `Size.Touch.Large`, Abstand `Size.Touch.Gap`; Scrollbedienung mit Trefferbereich mindestens `Size.Touch.Min` | offen |
| HS-36-P14 | Zweiter Kanal | Servicemodus über Symbol und Wort, Auswahl über Rahmen und Haken, deaktivierte Tasten über gestrichelte Kontur; kein Zustand nur über Farbe, keine rote Schrift für Werte | offen |
| HS-36-P15 | Tokens | Keine Hex- und Pixelwerte im Seitenaufbau; nur Tokens des Designsystems | offen |

## Annahmen dieser Seite

- S36-1: Das Filterfeld filtert die Liste nach Namensteil (OP-40); die Zahl „859,81“ zeigt den Wert der markierten Variable, neutral statt rot.
- S36-2: Layout 8 : 4; die drei Tasten tragen kein Schlüsselsymbol, weil der Seitenzugang geschützt ist (A-41).
- S36-3: Vor „Importieren“ erscheint ein Bestätigungs-Pop-up, Dateiauswahl und Ergebnis laufen über Pop-ups (Navigation 4.1).
- S36-4: „Liste exportieren“ ist ohne Auswahl deaktiviert; während eines Vorgangs sind die drei Tasten gesperrt (Tastensperre).
- S36-5: „Liste exportieren“ erfordert Mehrfachauswahl; HM-25 (Listenart Selection) kennt nur eine Einzelauswahl, Erweiterung nötig.
- S36-6: Betriebsart „Service“ mit `Icon.Mode.Service` in HM-02 (A-48).

## Offene Punkte

- OP-25: Rollenstufe (Dummy: Technik).
- OP-26: Wirbelsymbol und roter Schriftzug „Service“ (hier Betriebsart „Service“, A-48).
- OP-27: Bedeutung der roten Zahl „859,81“ (hier neutral dargestellt).
- OP-34: Schreibweise „Alle exportieren“ (Handbuch) gegenüber „Alle Exportieren“ (Bild).
- OP-40: Funktion des Filterfelds und Listenverhalten (Mehrfachauswahl).
- OP-41: Zahl der Variablen konfigurationsabhängig.
- OP-31: Bestätigungs-Pop-up vor „Importieren“, Datei- und Ergebnis-Pop-up sowie die Sperre der Tasten während eines Vorgangs sind nicht beschrieben (Ergänzungen S36-3, S36-4).
- OP-49: Dateiformat, Ziel, Dateiauswahl, „Wago“, Bedeutung „500 von 111427“.
