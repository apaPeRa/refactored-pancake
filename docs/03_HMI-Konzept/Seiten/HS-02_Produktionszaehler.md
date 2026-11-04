# HS-02 – Produktionszähler (Pop-up)
- Quelle: Referenz [RS-02](../../02_Referenz-Analyse/Seiten/RS-02_Produktionszaehler.md) (Funktion, Bild RS-02_01, Prüfpunkte); kein Design-Screenshot, Aufbau aus [Designsystem](../Designsystem.md), [HM-14](../Module/HM-14_Popup-Rahmen.md) und [HM-33](../Module/HM-33_Zaehlerzeile.md) abgeleitet; Navigation: [Navigation.md](../Navigation.md) (Abschnitte 2, 3.3, 4)
- Navigationspfad: **Produktion** (Brotkrümel der Hintergrundseite [HS-01](HS-01_Produktion.md) bleibt stehen; Pop-up-Titel „Produktionszähler“, Pfad der Referenz „Produktion › Produktionszähler“). Zugang: HS-01, Kennzahl „Aktuelle Produktion“ (Symbol und Chevron). Zurück-Ziel: HS-01 über „Schließen“ oder Kreuz. Seitenschlüssel `ProductionCounter` / `production/counter`, Typ Pop-up.

## Zweck
Wortgetreu (Referenz): „Zeigt den Gesamtzähler mit allen produzierten Packungen an und die Betriebsstunden der Maschine. Zusätzlich kann eine manuelle Historie der Produktion geführt werden.“ Die Zeilen „Aktuell“ und „Historie 1 bis 12“ zeigen die ausgebrachten Packungen seit dem Reset-Zeitpunkt, der in der Spalte „Datum / Uhrzeit“ steht. Der Reset (Taste halten) schiebt alle Einträge um eine Zeile nach unten.

## Aufbau (Bereiche, Layout)
Modaler Rahmen [HM-14](../Module/HM-14_Popup-Rahmen.md) mittig über dem Inhaltsbereich, Breitenanteil `Size.Popup.WidthRatio` (höchstens 60 % der Fensterbreite), Kontur `Border.Medium`, `Radius.Card`, Scrim `Brush.Scrim`, kein Schatten. Die Referenz ist hochformatig mit 13 Zeilen untereinander; im Querformat des neuen HMI wird der Inhalt in zwei Spalten geteilt, damit das Pop-up ohne Scrollen in den Inhaltsbereich passt.

```
+--------------------------------------------------------------+
| Produktionszähler                                        [X] |  Titelzeile
+--------------------------------------------+-----------------+
|                      Datum / Uhrzeit       | Gesamte Prod.   |
| Aktuell      874183  09.04.2025 14:55:09   |   1885201       |
| Historie 1        7  28.03.2025 14:08:02   |                 |
| ...  (Historie 2 bis 11)                   | Betriebsstunden |
| Historie 12       0  --.--.---- --:--:--   |   289:38:12     |
+--------------------------------------------+-----------------+
| [Reset (halten)]                                  [Schließen]|
+--------------------------------------------------------------+
```

| Bereich | Aufbau |
|---|---|
| Titelzeile | Höhe `Size.Popup.TitleHeight`, Titel „Produktionszähler“ (`Font.Size.Title`), Schließen-Kreuz oben rechts (`Size.Touch.Default`) |
| Zählertabelle (links, 8 von 12 Spalten des Pop-ups) | Spaltenkopf „Datum / Uhrzeit“ über der rechten Spalte; darunter 13 Zeilen [HM-33](../Module/HM-33_Zaehlerzeile.md) (Zeilenname, Zähler, Zeitpunkt); Zeilen sind reine Anzeige, Zeilenabstand `Space.S` |
| Summenfelder (rechts, 4 von 12 Spalten) | untereinander „Gesamte Produktion“ und „Betriebsstunden“ als Kennzahlen mit Beschriftung |
| Tastenzeile unten | „Reset“ links, „Schließen“ rechts (Navigation.md 4.2 Nr. 6), Höhe `Size.Touch.Default`, Abstand `Size.Touch.Gap` |

## Elemente
Spalte „Herkunft“: Zeile der Referenz (Tabelle „Elemente“ und Bild RS-02_01).

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Titelleiste mit Kreuz | Pop-up-Titelzeile | Titel „Produktionszähler“; Kreuz schließt das Pop-up (in der Referenz nicht beschrieben) | [HM-14](../Module/HM-14_Popup-Rahmen.md) | RS-02 „Titelleiste mit Kreuz“ |
| Spalte Datum / Uhrzeit | Spaltenüberschrift | zeigt den Reset-Zeitpunkt je Zähler | [HM-33](../Module/HM-33_Zaehlerzeile.md) | RS-02 „Spalte Datum / Uhrzeit“ |
| Aktuell | Zählerzeile, nur Anzeige; Beschriftung und Wert in `Font.Weight.Strong` | „Die Felder Aktuell und Historie 1 bis 12 zeigen die ausgebrachten Packungen seit dem Reset-Zeitpunkt, welcher in der Spalte Datum / Uhrzeit angezeigt wird, an.“ Beispiel 874183, 09.04.2025 14:55:09 (Format TT.MM.JJJJ hh:mm:ss) | [HM-33](../Module/HM-33_Zaehlerzeile.md) (`IsCurrent`) mit [HM-11](../Module/HM-11_Anzeigefeld.md) | RS-02 Zeile „Aktuell“ |
| Historie 1 bis Historie 12 (12 Zeilen) | Zählerzeile, nur Anzeige | wie „Aktuell“; Beispiele 7 / 28.03.2025 14:08:02, 7636, 773682, 1, 4622, 225070. Leere Historie: Zähler „0“ und Zeitpunkt „--.--.---- --:--:--“ (Zeilen 7 bis 12 im Bild) | [HM-33](../Module/HM-33_Zaehlerzeile.md) | RS-02 Zeilen „Historie 1 … Historie 12“ |
| Gesamte Produktion | Kennzahl, nur Anzeige (Beschriftung „Gesamte Produktion“, Einheit Stk) | „zeigt den Gesamtzähler an. Das sind alle Packungen, welche seit der Inbetriebnahme der Maschine produziert wurden.“ Beispiel 1885201 | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) (Größe `Content`) | RS-02 „Gesamte Produktion“ |
| Betriebsstunden | Kennzahl, nur Anzeige, Zeitwert hhh:mm:ss | „zeigt die gesamte Zeit an, welche die Maschine bisher produziert hat.“ Beispiel 289:38:12 | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) (`TimeValue`) | RS-02 „Betriebsstunden“ |
| Reset | Aktionstaste, Haltetaste (`TriggerMode` Hold) | „Ein Reset wird ausgeführt, wenn die Taste Reset für eine kurze Zeit gehalten wird. Der Reset wurde erfolgreich ausgeführt, wenn alle Einträge um eine Spalte nach unten rutschen.“ Fortschrittsstreifen und Text „Halten …“ während des Haltens; Haltedauer Dummy (OP-42) | [HM-07](../Module/HM-07_Aktionstaste.md) | RS-02 „Reset“ |
| Schließen | Taste im Pop-up-Rahmen | „Mit Schließen wird das Pop-Up geschlossen.“ | [HM-14](../Module/HM-14_Popup-Rahmen.md) (`ShowCloseButton`) | RS-02 „Schließen“ |

## Verwendete Module (IDs)
[HM-14](../Module/HM-14_Popup-Rahmen.md) (Rahmen, Kreuz, Schließen), [HM-33](../Module/HM-33_Zaehlerzeile.md) (13 Zählerzeilen, Spaltenkopf), [HM-11](../Module/HM-11_Anzeigefeld.md) (über HM-33), [HM-05](../Module/HM-05_Kennzahl-Kachel.md) (Gesamte Produktion, Betriebsstunden), [HM-07](../Module/HM-07_Aktionstaste.md) (Reset als Haltetaste).

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- **Öffnen:** Antippen der Kennzahl „Aktuelle Produktion“ auf [HS-01](HS-01_Produktion.md). Das Pop-up zeigt beim Öffnen die aktuellen Werte; Zähler aktualisieren sich bei offenem Pop-up.
- **Modal:** Scrim; Seitenleiste, Funktionsleiste, Brotkrümel und Seiteninhalt gesperrt; Meldezeile nur Anzeige (Navigation.md 4.2). Ein Antippen außerhalb schließt nicht. Pop-up steht nicht im Verlauf; „Zurück“ der Seitenleiste ist gesperrt.
- **Reset:** nur durch Halten der Taste über die Haltedauer; ein kurzes Antippen löst nichts aus und zeigt den Fortschrittsstreifen nur während des Haltens. Wird vor Ablauf losgelassen, bricht die Aktion ohne Wirkung ab. Nach erfolgreichem Reset rutschen alle Einträge um eine Zeile nach unten (Aktuell wird zu Historie 1, Historie 12 fällt weg), „Aktuell“ beginnt bei 0 mit neuem Reset-Zeitpunkt (Schluss aus dem Handbuchtext, RS-02 Offene Punkte). Die Haltetaste ersetzt einen Bestätigungsdialog (Annahme 14).
- **Berechtigung:** Die Referenz beschreibt keine Berechtigung für „Reset“ (OP-25). Die Taste trägt kein Schlüsselsymbol und ist für jeden angemeldeten Benutzer bedienbar (Annahme 14); Navigation.md 4.1 sieht das Schlüsselsymbol „je nach Seite“ vor. Wird eine Rolle gefordert, erscheint `Icon.Key` oben rechts in der Taste und bei fehlender Rolle das Benutzer-Pop-up.
- **Leere Historie:** Zähler „0“ und Platzhalterzeitpunkt, Text in `Brush.Text.Secondary`.
- **Ungültige Werte:** Zähler zeigen „---“, Reset ist deaktiviert (gestrichelte Kontur), Grund per Tippen in der Meldezeile.
- **Historie:** reine Anzeige; Eintragen, Ändern und Löschen einzelner Historienzeilen ist nicht beschrieben und nicht vorgesehen (OP-50).
- **Schließen:** „Schließen“ oder Kreuz zurück nach HS-01; offene Eingaben gibt es nicht.
- **Systemseitiger Wechsel** (z. B. Abmeldung) schließt das Pop-up ohne Aktion (Navigation.md 4.2 Nr. 5).

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-02-P01 | Zählertabelle (RS-02-P01) | 13 Zeilen „Aktuell“ und „Historie 1“ bis „Historie 12“, je mit Zähler und Spalte „Datum / Uhrzeit“ | offen |
| HS-02-P02 | Leere Historie (RS-02-P02) | Zeilen ohne Eintrag zeigen 0 und „--.--.---- --:--:--“ | offen |
| HS-02-P03 | Gesamte Produktion (RS-02-P03) | zeigt alle Packungen seit Inbetriebnahme (Beispiel 1885201) | offen |
| HS-02-P04 | Betriebsstunden (RS-02-P04) | zeigt die gesamte Produktionszeit im Format hhh:mm:ss (Beispiel 289:38:12) | offen |
| HS-02-P05 | Reset halten (RS-02-P05) | nach der Haltedauer wird der Reset ausgeführt, alle Einträge rutschen um eine Zeile nach unten | offen |
| HS-02-P06 | Reset nur antippen (RS-02-P06) | kein Reset; Loslassen vor Ablauf der Haltedauer bricht ohne Wirkung ab | offen |
| HS-02-P07 | Schließen (RS-02-P07) | „Schließen“ und Kreuz schließen das Pop-up und führen zu HS-01; Antippen außerhalb schließt nicht | offen |
| HS-02-P08 | Öffnen (RS-02-P08) | Antippen der Kennzahl „Aktuelle Produktion“ in HS-01 öffnet das Pop-up | offen |
| HS-02-P09 | Bild RS-02_01 (RS-02-P09) | Titel, 13 Zeilen, beide Summenfelder und die Tasten „Reset“ und „Schließen“ sind vorhanden | offen |
| HS-02-P10 | Modal | Scrim vorhanden, Seitenleiste, Funktionsleiste und Brotkrümel gesperrt, kein Eintrag im Verlauf | offen |
| HS-02-P11 | Passt ohne Scrollen | alle 13 Zeilen, beide Summenfelder und die Tastenzeile sind bei 1920 × 1080 sichtbar; Breite ≤ `Size.Popup.WidthRatio` | offen |
| HS-02-P12 | Touch-Ziele | „Reset“, „Schließen“ und Kreuz mit Trefferfläche ≥ `Size.Touch.Default`, Abstand ≥ `Size.Touch.Gap` | offen |
| HS-02-P13 | Zweiter Kanal | „Aktuell“ durch Beschriftung und Fettschrift gekennzeichnet; Halten durch Fortschrittsstreifen und Text; leere Zeilen durch Platzhaltertext; nichts nur über Farbe | offen |
| HS-02-P14 | Tokens und Lokalisierung | keine Hex- oder Pixelwerte; Texte aus `.resx`; Datum und Zahlen nach `CurrentCulture` | offen |

## Offene Punkte
- Haltedauer von „Reset“: OP-42 (Dummy-Wert in HM-07); Berechtigung und Rückfrage für Reset: OP-25 und OP-31; Historie manuell oder automatisch geführt, Format des Eintrags und doppelte Zeitstempel (Historie 4 und 5 im Bild): OP-50; Schreibweise „Spalte“ statt „Zeile“ im Handbuch: OP-34.
- Neu (für Offene-Punkte.md vorgeschlagen): Zeilenverhalten nach Reset („Historie 12“ fällt weg); zweispaltiges Layout statt hochformatigem Fenster der Referenz.
