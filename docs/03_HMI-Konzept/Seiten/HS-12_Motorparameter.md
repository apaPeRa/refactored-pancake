# HS-12 – Motorparameter (Hauptdosierer)

- Quelle: [RS-12](../../02_Referenz-Analyse/Seiten/RS-12_Motorparameter.md) (Funktionsumfang, Tabellen T17, T18, Prüfpunkte). Kein Design vorhanden (OP-07); Aufbau aus [Designsystem](../Designsystem.md) (Raster 3.3) und den Modulen abgeleitet. Zugänge und Brotkrümel nach [Navigation.md](../Navigation.md).
- Navigationspfad: Einstellung › Dosierer › Hauptdosierer › Motorparameter (Objektkennung (`ObjectSuffix`) „HD1“ bzw. „HD2“; Seitentitel der Referenz „Motorparameter HD1“). Zugang: [HS-11](../Seiten/HS-11_Hauptdosierer-1-und-2.md) Funktionsleiste „Motorparameter“ für den aktuell angewählten Dosierer (Parameter `doserIndex`). Zurück-Ziel: HS-11. Seitenschlüssel `MainDoserMotor` / `settings/dosers/main/motor`.

## Zweck

Wortgetreu (Handbuch): „Auf dieser Seite werden die Bewegungsparameter für den Verschluss und die Schnecke eines Schneckendosierers konfiguriert. Die Einstellungen ermöglichen eine optimale Anpassung an das Produktverhalten und die Maschinengeschwindigkeit.“ Die Seite gilt für den Hauptdosierer, von dem aus sie geöffnet wurde („HD1“ oder „HD2“), und ist die Hauptdosierer-Variante der Motorparameter (Nachdosierer: [HS-20](../Seiten/HS-20_Motorparameter.md), gleicher Aufbau, dasselbe Modul HM-21).

## Aufbau (Bereiche, Layout)

Rahmen wie auf allen Seiten (Seitenleiste 3\*, Arbeitsbereich 37\*; Kopfzeile 4\*, Brotkrümel/Kennzahlen 3\*, Inhalt 34\*, Funktionsleiste 4\*). Der **Inhaltsbereich** (Außenrand `Size.Content.Margin`, 12-Spalten-Raster, Gutter `Space.M`) hat zwei Zeilen:

| Zeile | Höhe | Inhalt |
|---|---|---|
| 1 | Auto (Höhe `Size.Touch.Default`) | Objektüberschrift „Hauptdosierer 1“ bzw. „Hauptdosierer 2“ über 12 Spalten |
| 2 | Rest (1\*) | drei Motorparameter-Karten **4 : 4 : 4** Spalten (Raster wie DS-04 und Vorgabe in HM-21) |

```
Inhaltsbereich (12 Spalten)
+--------------------------------------------------------------------------+
| Titelzeile: Hauptdosierer 1                                    (HM-17)   |
+------------------------+------------------------+------------------------+
| Verschluss Zu (4 Sp.)  | Verschluss Auf (4 Sp.) | Schnecke (4 Sp.)       |
|  Position      [ ° ]   |  Position      [ ° ]   |  [Symbol Schnecke]     |
|  Geschwindigkeit [%]   |  Geschwindigkeit [%]   |  Beschleunigung   [%]  |
|  Beschleunigung  [%]   |  Beschleunigung  [%]   |  Verzögerung      [%]  |
|  Verzögerung     [%]   |  Verzögerung     [%]   |  Ruck             [%]  |
|  Ruck            [%]   |  Ruck            [%]   |                        |
+------------------------+------------------------+------------------------+
| Funktionsleiste: [«] [»]  1 von 2                                         |
+--------------------------------------------------------------------------+
```

Die Anordnung weicht vom Referenzbild ab (dort liegt die Karte „Schnecke“ unten mittig): im 4 : 4 : 4-Raster stehen alle drei Karten nebeneinander, die Reihenfolge Zu, Auf, Schnecke bleibt. Jede Karte ist ein Gruppenbereich (HM-15) mit Überschrift in `Font.Size.Value`; Zeilen aus Beschriftung links und Eingabefeld rechts, Höhe `Size.Touch.Default`, Abstand `Size.Touch.Gap`. Die Funktionsleiste enthält nur das Blätterpaar.

**Höhenbilanz** (Kontrollrechnung bei 1920 × 1080; nutzbare Inhaltshöhe 768 = Inhaltszeile 34\* abzüglich 2 × `Size.Content.Margin`):

| Bereich | Rechnung | Summe |
|---|---|---|
| Titelzeile | Zeile `Size.Touch.Default` plus Abstand `Space.M` | 80, verbleiben 688 |
| Karte Verschluss (größte) | 5 Zeilen (320) + 4 Abstände (64) + Kopf (52) + Innenabstand (32) | 468 |
| Karte Schnecke | 3 Zeilen (192) + 2 Abstände (32) + Kopf (52) + Innenabstand (32) | 308 |

Alle Karten liegen unter 688; es wird nicht gescrollt (Prüfpunkt HS-12-P17).


## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)

Spalte „Herkunft (RS-12)“: T17 = Verschluss Zu / Verschluss Auf (je Karte 5 Zeilen, gesamt 10 Felder), T18 = Schnecke (3 Zeilen), W = nur im Referenzbild. Beispielwerte stammen aus dem Referenzbild (Hauptdosierer 1) und sind keine Standardwerte (OP-28). Alle 13 Felder tragen in der Referenz ein Schlüsselsymbol.

### Rahmen und Kopf

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-12) |
|---|---|---|---|---|
| Seitenleiste (Benutzerkreis, Home, Einstellungen, Meldungen, Zurück) | Rahmen | ersetzt Schloss, „Produktion“, „Einstellungen“, „Zurück“ der Referenz; „Zurück“ öffnet den obersten Verlaufseintrag (HS-11) | [HM-01](../Module/HM-01_Seitenleiste.md) | W: Schloss, Tasten „Produktion“, „Einstellungen“, „Zurück“ |
| Kopfzeile: Logo, Betriebsart, Uhrzeit/Datum | Rahmen | wie HS-11 (Spiral-Symbol der Referenz: Betriebsart, OP-26) | [HM-02](../Module/HM-02_Kopfzeile.md) | W: Logo, Spiral-Symbol, Uhrzeit/Datum |
| Meldezeile | Anzeige | aktuelle Meldung (Referenzbild „*450* Palettierung nicht bereit“); Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | W: Meldezeile |
| Brotkrümel „Einstellung › Dosierer › Hauptdosierer › Motorparameter“ | Navigation | Seitenpfad, Objektkennung (`ObjectSuffix`) „HD1“/„HD2“ am letzten Segment (Referenz-Seitentitel „Motorparameter HD1“); „Hauptdosierer“ führt zu HS-11 mit demselben `doserIndex` | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | W: Seitentitel „Motorparameter HD1“ |
| Kennzahlen Geschwindigkeit, Maschinenwinkel | Anzeige | Rahmenkennzahlen | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | (Rahmen) |
| Titelzeile „Hauptdosierer 1“ / „Hauptdosierer 2“ | Überschrift | benennt den Dosierer, für den die Parameter gelten; wechselt mit den Blättertasten (S12-1) | [HM-17](../Module/HM-17_Titelzeile.md) | W: Zusatz „HD1“ im Titel; Zugangsregel „aktueller Dosierer“ |

### Karten Verschluss Zu und Verschluss Auf (T17)

Die Zeilen gelten für beide Karten; „Zu“ und „Auf“ haben je ein Feld pro Zeile. Beispielwerte: Zu / Auf.

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-12) |
|---|---|---|---|---|
| Karte „Verschluss Zu“ | Gruppenbereich mit fünf Zeilen | Bewegungsparameter des Verschlusses in Stellung geschlossen | [HM-21](../Module/HM-21_Motorparameter-Karte.md) (Kartenart ClosureClosed) mit [HM-15](../Module/HM-15_Gruppenbereich.md) | Karte links oben |
| Karte „Verschluss Auf“ | Gruppenbereich mit fünf Zeilen | Bewegungsparameter des Verschlusses in Stellung geöffnet | HM-21 (Kartenart ClosureOpen) mit HM-15 | Karte rechts oben |
| Position | Eingabefeld mit Schlüssel, Einheit ° | „Position in Grad, an der der Verschluss geöffnet bzw. geschlossen ist.“ Beispiel 0 ° / 37 ° | HM-21 mit [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) | T17 Nr. 1 (je Karte) |
| Geschwindigkeit | Eingabefeld mit Schlüssel, Einheit % | „Bewegungsgeschwindigkeit des Aktors in Prozent.“ Beispiel 80 % / 80 % | HM-21 mit HM-12 | T17 Nr. 2 (je Karte) |
| Beschleunigung | Eingabefeld mit Schlüssel, Einheit % | „Anstieg der Geschwindigkeit beim Start der Bewegung.“ Beispiel 0 % / 0 % | HM-21 mit HM-12 | T17 Nr. 3 (je Karte) |
| Verzögerung | Eingabefeld mit Schlüssel, Einheit % | „Abbremsen vor Erreichen der Endposition.“ Beispiel 0 % / 0 % | HM-21 mit HM-12 | T17 Nr. 4 (je Karte) |
| Ruck | Eingabefeld mit Schlüssel, Einheit % | „Änderung der Beschleunigung (sanfter Bewegungsbeginn und -ende).“ Beispiel 0 % / 0 % | HM-21 mit HM-12 | T17 Nr. 5 (je Karte) |

### Karte Schnecke (T18)

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-12) |
|---|---|---|---|---|
| Karte „Schnecke“ mit Schnecken-Symbol | Gruppenbereich mit drei Zeilen, Symbol `Icon.Motor.Screw` neben der Überschrift | Bewegungsparameter der Dosierschnecke | HM-21 (Kartenart Screw) mit HM-15 | Karte unten mittig; W: Schnecken-Symbol |
| Beschleunigung | Eingabefeld mit Schlüssel, Einheit % | „Anstieg der Drehgeschwindigkeit beim Start.“ Beispiel 0 % | HM-21 mit HM-12 | T18 Nr. 1 |
| Verzögerung | Eingabefeld mit Schlüssel, Einheit % | „Abbremsen der Drehung beim Stoppen.“ Beispiel 0 % | HM-21 mit HM-12 | T18 Nr. 2 |
| Ruck | Eingabefeld mit Schlüssel, Einheit % | „Änderung der Beschleunigung für eine produktschonende Bewegung.“ Beispiel 0 % | HM-21 mit HM-12 | T18 Nr. 3 |

### Funktionsleiste

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-12) |
|---|---|---|---|---|
| Pfeiltasten „«“ „»“ mit Positionsanzeige „1 von 2“ | Blättertasten (Paar) in der Funktionsleiste | wechseln HD 1 ⇄ HD 2, Seite und Karten wechseln auf den anderen Dosierer, kein Verlaufseintrag; Randtaste deaktiviert. Die Referenz zeigt nur „»“, deren Funktion ist nicht beschrieben (RS-12 Offener Punkt 3); Navigation.md 3.3 legt das Blättern HD 1 ⇄ HD 2 für HS-12 fest (S12-2) | [HM-19](../Module/HM-19_Blaettertasten.md) in [HM-06](../Module/HM-06_Funktionsleiste.md) | W: Taste „»“ |

Die Taste „Motorparameter“ gibt es auf dieser Seite nicht (wie in der Referenz: erste Position leer).

## Verwendete Module (IDs)

- [HM-01](../Module/HM-01_Seitenleiste.md) – Seitenleiste
- [HM-02](../Module/HM-02_Kopfzeile.md) – Kopfzeile (enthält HM-03)
- [HM-03](../Module/HM-03_Meldezeile.md) – Meldezeile
- [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) – Brotkrümel-Navigation
- [HM-05](../Module/HM-05_Kennzahl-Kachel.md) – Kennzahl-Kachel
- [HM-06](../Module/HM-06_Funktionsleiste.md) – Funktionsleiste unten
- [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) – Eingabefeld mit Schlüsselsymbol
- [HM-13](../Module/HM-13_Eingabe-Pop-up.md) – Eingabe-Pop-up
- [HM-14](../Module/HM-14_Popup-Rahmen.md) – Pop-up-Rahmen (trägt HM-13)
- [HM-15](../Module/HM-15_Gruppenbereich.md) – Gruppenbereich (Rahmen der Karten)
- [HM-17](../Module/HM-17_Titelzeile.md) – Titelzeile (Objektüberschrift)
- [HM-19](../Module/HM-19_Blaettertasten.md) – Blättertasten
- [HM-21](../Module/HM-21_Motorparameter-Karte.md) – Motorparameter-Karte


## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

- **Bezug zum Dosierer.** Die Seite zeigt immer die Parameter eines Dosierers: `doserIndex` aus dem Zugang von HS-11. Titelzeile und Brotkrümel-Objektkennung nennen ihn („Hauptdosierer 1“, „HD1“).
- **Blättern.** „«“ und „»“ wechseln `doserIndex` per `ReplaceParameter`; alle 13 Werte werden durch die des anderen Dosierers ersetzt, kein Verlaufseintrag. Am Rand ist die Taste deaktiviert (gestrichelte Kontur, Positionsanzeige „1 von 2“). „Zurück“ folgt dem Stapeleintrag (Navigation.md 5.3): HS-11 erscheint mit dem Parameter `doserIndex`, mit dem HS-12 geöffnet wurde; das Blättern in HS-12 ändert den Stapel nicht.
- **Eingabe-Pop-up.** Antippen eines Felds öffnet HM-13 mit Titel (Kartenname und Zeilenname, zum Beispiel „Verschluss Auf – Position“), aktuellem Wert, Einheit (° oder %) und Grenzen; „Übernehmen“ nur bei gültigem Wert, „Abbrechen“ verwirft, Antippen außerhalb schließt nicht. Der Handbuchtext der Zeile erscheint als Hilfetext im Pop-up (S12-3), die Karte kann ihn zusätzlich als Tooltip tragen. Das Pop-up ist in der Referenz nicht beschrieben (A-20, OP-30); Grenzen sind Dummy (OP-28).
- **Berechtigung.** Alle 13 Felder tragen `Icon.Key`; ohne Berechtigung `Icon.Lock`, Antippen öffnet kein Eingabe-Pop-up, sondern den Hinweis „Berechtigung erforderlich: <Rolle>“ bzw. das Benutzer-Pop-up (OP-25, OP-04). Gesperrte Felder sind weiterhin lesbar.
- **Fehlerfälle.** Ungültiger Wert: Feld im Zustand Fehler (Kontur `Border.Thick`, `Brush.Status.Error.Subtle`, `Icon.Status.Error`, Text „Wert außerhalb a bis b Einheit“). Fehler beim Schreiben eines Werts: Feld im Zustand Fehler mit Text. Wert in Textfarbe (`Brush.Text.Primary`), nicht in Rot (Designsystem 1.2).
- **Einheiten.** Position in Grad (°), alle übrigen Felder in Prozent (%). Die Bezugsgröße der Prozentwerte bei Beschleunigung, Verzögerung und Ruck ist offen (RS-12 Offener Punkt 2, OP-45); die Beschriftung nennt nur die Einheit.
- **Navigation.** „Zurück“ (Seitenleiste) → HS-11; Brotkrümel „Hauptdosierer“ → HS-11, „Dosierer“ → HS-41; Meldezeile → HS-38. Bei offenem Pop-up ist alles außer dem Pop-up gesperrt.

## Prüfpunkte (Tabelle: ID | Prüfung | erwartetes Ergebnis | Status)

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-12-P01 | Zweck (RS-12-P01) | Seite beschreibt Bewegungsparameter für Verschluss und Schnecke eines Schneckendosierers | offen |
| HS-12-P02 | Vollständigkeit T17 (RS-12-P02) | je Verschlusskarte 5 Zeilen: Position, Geschwindigkeit, Beschleunigung, Verzögerung, Ruck | offen |
| HS-12-P03 | Vollständigkeit T18 (RS-12-P03) | Karte Schnecke mit 3 Zeilen: Beschleunigung, Verzögerung, Ruck | offen |
| HS-12-P04 | Verschlusskarten (RS-12-P04) | „Verschluss Zu“ und „Verschluss Auf“ mit je 5 Feldern (gesamt 10 Felder) | offen |
| HS-12-P05 | Karte Schnecke (RS-12-P05) | 3 Felder und Schnecken-Symbol neben der Überschrift | offen |
| HS-12-P06 | Einheiten (RS-12-P06) | Position in ° (Beispiel 0 ° und 37 °), Geschwindigkeit in % (Beispiel 80 %), übrige Felder in %; Einheit hinter dem Wert, Format Wert, geschütztes Leerzeichen, Einheit | offen |
| HS-12-P07 | Bildbezug (RS-12-P07) | alle drei Karten und der Zusatz „HD1“ der Referenz sind abgebildet: Karten Zu, Auf, Schnecke, Objektkennung im Brotkrümel und Titelzeile | offen |
| HS-12-P08 | Zugang (RS-12-P08) | Aufruf nur über HS-11 „Motorparameter“; Seite zeigt den Dosierer, von dem aus sie geöffnet wurde | offen |
| HS-12-P09 | Eingabefeld (RS-12-P09) | jedes der 13 Felder ist ein editierbares Eingabefeld mit Schlüsselsymbol; Antippen öffnet das Eingabe-Pop-up; ohne Berechtigung Schloss und Hinweis | offen |
| HS-12-P10 | Rahmenelemente (RS-12-P10) | Kopfzeile, Meldezeile, Seitenleiste (Benutzer, Home, Einstellungen, Zurück) vorhanden; Funktionsleiste mit Blätterpaar | offen |
| HS-12-P11 | Brotkrümel (RS-12-P11) | „Einstellung › Dosierer › Hauptdosierer › Motorparameter“ mit Objektkennung | offen |
| HS-12-P12 | Blättern | „«“/„»“ wechseln HD 1 ⇄ HD 2 ohne Verlaufseintrag; Randtaste deaktiviert; Werte und Titelzeile wechseln mit | offen |
| HS-12-P13 | Eingabe-Pop-up | Wert außerhalb der Grenzen: Fehlertext mit Symbol, Übernehmen gesperrt; „Abbrechen“ verwirft | offen |
| HS-12-P14 | Touch-Ziele | Felder und Blättertasten mindestens `Size.Touch.Default` hoch (Trefferfläche nie unter `Size.Touch.Min`), Abstand mindestens `Size.Touch.Gap` | offen |
| HS-12-P15 | Zweiter Kanal und Tokens | Schloss/Schlüssel, Fehler, deaktivierte Randtaste mit Symbol, Form oder Text; keine Hex- oder Pixelwerte; Texte aus `.resx` | offen |
| HS-12-P16 | Wiederverwendung | Karten sind HM-21 (Felder HM-12, Rahmen HM-15), identisch aufgebaut wie HS-17 und HS-20 | offen |
| HS-12-P17 | Layout | drei Karten 4 : 4 : 4 unter der Titelzeile; größte Karte passt ohne Scrollen in den Inhaltsbereich | offen |

## Annahmen dieser Seite

Lokale Kennungen; der Querschnitts-Agent überführt sie in Sammeleinträge von Annahmen.md.

| Kennung | Annahme |
|---|---|
| S12-1 | Titelzeile (HM-17) als Objektüberschrift „Hauptdosierer 1/2“; die Seite zeigt den Dosierer, von dem sie geöffnet wurde. |
| S12-2 | Blättern HD 1 ⇄ HD 2 wie in HS-11: `ReplaceParameter` ohne Verlaufseintrag, Positionsanzeige „1 von 2“, Randtaste deaktiviert (Navigation.md 3.3 legt das Blättern für HS-12 fest; das Referenzbild zeigt nur „»“). |
| S12-3 | Der Handbuchtext je Zeile erscheint als Hilfetext im Eingabe-Pop-up (Touch kennt keine Tooltips). |

## Offene Punkte

- OP-25 Berechtigungsstufen und Schlüsselsymbol; OP-04 Benutzer/Anmeldung.
- OP-28 Wertebereiche und Standardwerte; OP-29 Einheiten und Nachkommastellen; OP-30 Eingabe-Pop-up.
- OP-38 Zugang und Navigationspfade; OP-39 fehlender Screenshot Hauptdosierer 2 (Aufbau als identisch angenommen).
- OP-45 Bezugsgröße der Prozentwerte (Beschleunigung, Verzögerung, Ruck).
- OP-55 Seite ist bildidentisch mit RS-17 und RS-20 (gemeinsames Modul HM-21).
