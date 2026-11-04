# HS-03 – Maschinengeschwindigkeit (Pop-up)
- Quelle: Referenz [RS-03](../../02_Referenz-Analyse/Seiten/RS-03_Maschinengeschwindigkeit.md) (Funktion, Tabelle T3, Bild RS-03_01, Prüfpunkte); kein Design-Screenshot, Aufbau aus [Designsystem](../Designsystem.md), [HM-14](../Module/HM-14_Popup-Rahmen.md) und [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) abgeleitet; Navigation: [Navigation.md](../Navigation.md) (Abschnitte 2, 3.2, 3.3, 4, A-38)
- Navigationspfad: **Produktion** (Brotkrümel der Hintergrundseite bleibt stehen; Pop-up-Titel „Maschinengeschwindigkeit“, Pfad der Referenz „Produktion › Maschinengeschwindigkeit“). Zugang: [HS-01](HS-01_Produktion.md), Kennzahl „Geschwindigkeit Soll“ (Symbol und Chevron); Rahmenkennzahl „Geschwindigkeit“ auf jeder Seite (A-38). Zurück-Ziel: die aufrufende Seite über „Schließen“ oder Kreuz. Seitenschlüssel `MachineSpeed` / `production/speed`, Typ Pop-up.

## Zweck
Wortgetreu (Referenz): „Das Pop-up erlaubt das Einstellen der verschiedenen Geschwindigkeiten der Maschine. Geöffnet wird das Pop-up durch einen Klick auf das rote Tacho-Symbol auf der Produktions-Seite.“ Im neuen HMI ersetzt das Antippen der Kennzahl „Geschwindigkeit Soll“ (Symbol `Icon.Speed` mit Chevron, nicht mehr rot) bzw. der Rahmenkennzahl „Geschwindigkeit“ den Klick auf das rote Symbol. Fünf Geschwindigkeiten: Maximum, Schnell, Langsam, Tippen, Minimum.

## Aufbau (Bereiche, Layout)
Modaler Rahmen [HM-14](../Module/HM-14_Popup-Rahmen.md) mittig über dem Inhaltsbereich, schmaler Breitenanteil (`WidthRatio` 0,4 statt des Standards 0,6, höchstens `Size.Popup.WidthRatio`), Kontur `Border.Medium`, `Radius.Card`, Scrim `Brush.Scrim`, kein Schatten.

```
+--------------------------------------+
| Maschinengeschwindigkeit         [X] |  Titelzeile
+--------------------------------------+
| Maximum:  [        125 1/min    (K)] |
| Schnell:  [         50 1/min       ] |
| Langsam:  [         50 1/min       ] |
| Tippen:   [         15 1/min    (K)] |
| Minimum:  [         10 1/min    (K)] |
|                           [Schließen]|
+--------------------------------------+
(K) = Schlüsselsymbol, Berechtigung erforderlich
```

| Bereich | Aufbau |
|---|---|
| Titelzeile | Höhe `Size.Popup.TitleHeight`, Titel „Maschinengeschwindigkeit“, Schließen-Kreuz oben rechts (`Size.Touch.Default`) |
| Eingabebereich | 5 Zeilen untereinander in der Reihenfolge der Referenz (Maximum, Schnell, Langsam, Tippen, Minimum); je Zeile Beschriftung links und Eingabefeld rechts (Spalten 1\* : 2\*), Höhe `Size.Touch.Default`, Abstand `Size.Touch.Gap`; Wert in `Font.Weight.Strong` mit Einheit „1/min“ |
| Tastenzeile | „Schließen“ unten rechts (Navigation.md 4.2 Nr. 6) |

## Elemente
Spalte „Herkunft“: Zeile der Tabelle T3 bzw. Bild RS-03_01.

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Titelleiste mit Kreuz | Pop-up-Titelzeile | Titel „Maschinengeschwindigkeit“; Kreuz schließt das Pop-up (in der Referenz nicht beschrieben) | [HM-14](../Module/HM-14_Popup-Rahmen.md) | T3 „Titelleiste mit Kreuz“ |
| Maximum | Eingabefeld, 1/min, mit Schlüsselsymbol | „Die Obergrenze für die Maschinengeschwindigkeit.“ Beispiel 125 1/min | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) (`RequiresPermission`), Eingabe über [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | T3 Zeile Maximum; Bild: Schlüssel |
| Schnell | Eingabefeld, 1/min, ohne Schlüsselsymbol | „Sollgeschwindigkeit, wenn die Taste Maschine Schnell aktiv ist.“ Beispiel 50 1/min | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | T3 Zeile Schnell |
| Langsam | Eingabefeld, 1/min, ohne Schlüsselsymbol | „Sollgeschwindigkeit, wenn die Taste Maschine Schnell inaktiv ist.“ Beispiel 50 1/min | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | T3 Zeile Langsam |
| Tippen | Eingabefeld, 1/min, mit Schlüsselsymbol | „Vorgabe für den Tippbetrieb. Ist in der Regel nahe dem Minimum.“ Beispiel 15 1/min | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) (`RequiresPermission`), [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | T3 Zeile Tippen; Bild: Schlüssel |
| Minimum | Eingabefeld, 1/min, mit Schlüsselsymbol | „Die Untergrenze für die Maschinengeschwindigkeit.“ Beispiel 10 1/min | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) (`RequiresPermission`), [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | T3 Zeile Minimum; Bild: Schlüssel |
| Taste Schließen | Taste im Pop-up-Rahmen | „Schließt das Pop-Up.“ | [HM-14](../Module/HM-14_Popup-Rahmen.md) (`ShowCloseButton`) | T3 „Taste Schließen“ |

Die rote Schrift der Eingabewerte in der Referenz entfällt; Rot ist nur Fehler (HM-12, Designsystem 1.2). Die Eingabewerte stehen in `Brush.Text.Primary` und `Font.Weight.Strong`.

## Verwendete Module (IDs)
[HM-14](../Module/HM-14_Popup-Rahmen.md) (Rahmen, Kreuz, Schließen), [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) (5 Eingabefelder), [HM-13](../Module/HM-13_Eingabe-Pop-up.md) (Eingabe beim Antippen eines Felds, A-20/A-51).

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- **Öffnen:** Antippen von „Geschwindigkeit Soll“ auf [HS-01](HS-01_Produktion.md) oder der Rahmenkennzahl „Geschwindigkeit“ (A-38). Beim Öffnen stehen die gespeicherten Werte in den Feldern.
- **Modal:** Scrim; Seitenleiste, Funktionsleiste, Brotkrümel und Seiteninhalt gesperrt; Meldezeile nur Anzeige. Ein Antippen außerhalb schließt nicht. Das Pop-up steht nicht im Verlauf.
- **Eingabe:** Antippen eines Felds öffnet das Eingabe-Pop-up [HM-13](../Module/HM-13_Eingabe-Pop-up.md) mit vorbelegtem Wert, Einheit „1/min“ und den Grenzen. „Übernehmen“ schreibt den Wert und aktualisiert das Feld; „Abbrechen“ verwirft. Das Eingabe-Pop-up liegt über dem Pop-up (Tiefe 2, Annahme 13).
- **Zuordnung Schnell und Langsam:** Die wirksame Sollgeschwindigkeit ist „Schnell“, wenn die Zustandstaste „Schnell“ auf HS-01 „Ein“ ist, sonst „Langsam“. Die Kennzahl „Geschwindigkeit Soll“ auf HS-01 zeigt den wirksamen Wert und folgt Änderungen im Pop-up.
- **Grenzen:** Die Maschinengeschwindigkeit bleibt zwischen Minimum und Maximum. Plausibilitätsregel als Dummy: Minimum ≤ Tippen ≤ Langsam und Schnell ≤ Maximum (Annahme 15, OP-28); ein Wert außerhalb gibt im Eingabe-Pop-up den Fehlerzustand mit `Icon.Status.Error` und Text (z. B. „Wert außerhalb 10 bis 125 1/min“), „Übernehmen“ bleibt deaktiviert. Ob „Schnell“ und „Langsam“ gleich sein dürfen (Bild: beide 50), ist nicht beschrieben; hier erlaubt.
- **Berechtigung:** Maximum, Tippen und Minimum tragen das Schlüsselsymbol (Berechtigung vorhanden und Anmeldung erforderlich) bzw. das Schloss (Berechtigung fehlt); Schnell und Langsam sind ohne Schlüssel frei bedienbar. Rolle je Feld ist nicht dokumentiert (OP-25, Dummy). Fehlt die Rolle, öffnet das Antippen kein Eingabe-Pop-up; es erscheint „Berechtigung erforderlich: <Rolle>“ und das Benutzer-Pop-up (Navigation.md 4.1, Annahme 16). Nach der Anmeldung wird das Eingabe-Pop-up geöffnet.
- **Fehlerfälle:** Ungültiger Wert siehe Grenzen; Schreibfehler der Maschine: Feld im Fehlerzustand mit Text, Wert bleibt der zuletzt gültige. Geänderte Werte wirken sofort nach „Übernehmen“; ein zusätzliches „Werte schreiben“ gibt es nicht.
- **Schließen:** „Schließen“ oder Kreuz zurück zur aufrufenden Seite. Nicht übernommene Eingaben sind verworfen. Systemseitiger Wechsel (z. B. Abmeldung) schließt ohne Übernehmen.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-03-P01 | Tabelle T3 (RS-03-P01) | Maximum, Schnell, Langsam, Tippen, Minimum und Taste Schließen vorhanden, Beschreibungen stimmen mit RS-03 überein | offen |
| HS-03-P02 | Felder und Einheit (RS-03-P02) | 5 Eingabefelder in der Reihenfolge Maximum, Schnell, Langsam, Tippen, Minimum, jeweils mit Einheit „1/min“ (Beispiel 125, 50, 50, 15, 10) | offen |
| HS-03-P03 | Schlüsselsymbole (RS-03-P03) | Maximum, Tippen und Minimum tragen `Icon.Key` bzw. `Icon.Lock`, Schnell und Langsam nicht | offen |
| HS-03-P04 | Öffnen (RS-03-P04) | Antippen von „Geschwindigkeit Soll“ in HS-01 und der Rahmenkennzahl „Geschwindigkeit“ öffnet das Pop-up | offen |
| HS-03-P05 | Zuordnung Schnell und Langsam (RS-03-P05) | „Geschwindigkeit Soll“ zeigt den Wert „Schnell“, wenn die Taste „Schnell“ „Ein“ ist, sonst „Langsam“ | offen |
| HS-03-P06 | Schließen (RS-03-P06) | „Schließen“ und Kreuz schließen das Pop-up; Antippen außerhalb schließt nicht | offen |
| HS-03-P07 | Bild RS-03_01 (RS-03-P07) | Titel, fünf Zeilen mit Beschriftung, Feld und Einheit sowie die Taste „Schließen“ sind vorhanden | offen |
| HS-03-P08 | Grenzen (RS-03-P08) | die Maschinengeschwindigkeit bleibt zwischen Minimum und Maximum; ungültige Eingabe zeigt Fehlertext mit Symbol und lässt „Übernehmen“ deaktiviert | offen |
| HS-03-P09 | Eingabe | Antippen eines berechtigten Felds öffnet das Eingabe-Pop-up mit vorbelegtem Wert; „Abbrechen“ ändert nichts | offen |
| HS-03-P10 | Nicht berechtigt | Antippen von Maximum, Tippen oder Minimum ohne Rolle öffnet kein Eingabe-Pop-up, zeigt Hinweis „Berechtigung erforderlich“ und das Benutzer-Pop-up | offen |
| HS-03-P11 | Wert nicht rot | Eingabewerte in Textfarbe und Fettschrift, Rot nur im Fehlerzustand | offen |
| HS-03-P12 | Modal | Scrim, Seitenleiste, Funktionsleiste und Brotkrümel gesperrt, kein Eintrag im Verlauf | offen |
| HS-03-P13 | Touch-Ziele | Felder, „Schließen“ und Kreuz mit Trefferfläche ≥ `Size.Touch.Default`, Abstand ≥ `Size.Touch.Gap`; das Schlüsselsymbol ist kein eigenes Ziel | offen |
| HS-03-P14 | Zweiter Kanal | Berechtigung über Symbol, Fehler über Symbol und Text, nicht nur über Farbe; Breite ≤ `Size.Popup.WidthRatio` | offen |
| HS-03-P15 | Tokens und Lokalisierung | keine Hex- oder Pixelwerte; Texte und Einheit aus `.resx`; Zahlenformat nach `CurrentCulture` | offen |

## Offene Punkte
- Berechtigungsstufen und Bedeutung des Schlüssels: OP-25; Farbbedeutung der roten Werte: OP-27 (Rot entfällt); Wertebereiche, Standardwerte, Plausibilität, Fehlermeldungen: OP-28; Art der Werteingabe (Eingabe-Pop-up): OP-30; weitere Lücken (Schnell gleich Langsam): OP-50.
- Neu (für Offene-Punkte.md vorgeschlagen): Plausibilitätsregel Minimum ≤ Tippen ≤ Langsam und Schnell ≤ Maximum ist Annahme; Stapelung Eingabe-Pop-up über HS-03 (Navigation.md 4.2 Nr. 1 nennt sie nicht ausdrücklich).
