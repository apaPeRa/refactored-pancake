# HS-20 – Motorparameter (Nachdosierer)

- Quelle: [RS-20](../../02_Referenz-Analyse/Seiten/RS-20_Motorparameter.md) (Funktionsumfang, Tabellen T30, T31, Prüfpunkte; Text und Bild textgleich zu [RS-12](../../02_Referenz-Analyse/Seiten/RS-12_Motorparameter.md)). Kein Design vorhanden (OP-07); Aufbau aus [Designsystem](../Designsystem.md) und den Modulen abgeleitet, identisch zu [HS-12](../Seiten/HS-12_Motorparameter.md). Zugänge und Brotkrümel nach [Navigation.md](../Navigation.md).
- Navigationspfad: Einstellung › Dosierer › Nachdosierer › Motorparameter (Objektkennung (`ObjectSuffix`) „ND“, S20-1). Zugang: [HS-19](../Seiten/HS-19_Nachdosierer.md) Funktionsleiste „Motorparameter“ (aktueller Dosierer = Nachdosierer). Zurück-Ziel: HS-19. Seitenschlüssel `PostDoserMotor` / `settings/dosers/post/motor`.

## Zweck

Wortgetreu (Handbuch, wie RS-12): „Auf dieser Seite werden die Bewegungsparameter für den Verschluss und die Schnecke eines Schneckendosierers konfiguriert. Die Einstellungen ermöglichen eine optimale Anpassung an das Produktverhalten und die Maschinengeschwindigkeit.“ Die Seite gilt für den Nachdosierer. Das Referenzbild zeigt allerdings die Seite des Hauptdosierers 1 (Titel „Motorparameter HD1“, OP-39); die Beispielwerte (0 °, 37 °, 80 %, 0 %) sind deshalb keine Werte des Nachdosierers und nur Platzhalter (OP-28).

## Aufbau (Bereiche, Layout)

Rahmen wie auf allen Seiten (Seitenleiste 3\*, Arbeitsbereich 37\*; Kopfzeile 4\*, Brotkrümel/Kennzahlen 3\*, Inhalt 34\*, Funktionsleiste 4\*). Der **Inhaltsbereich** (Außenrand `Size.Content.Margin`, 12-Spalten-Raster, Gutter `Space.M`) hat eine Zeile mit drei Motorparameter-Karten **4 : 4 : 4** Spalten (Vorgabe aus HM-21 und Raster wie DS-04). Es gibt keine Titelzeile (nur ein Objekt, der Dosierer steht im Brotkrümel).

```
Inhaltsbereich (12 Spalten)
+------------------------+------------------------+------------------------+
| Verschluss Zu (4 Sp.)  | Verschluss Auf (4 Sp.) | Schnecke (4 Sp.)       |
|  Position      [ ° ]   |  Position      [ ° ]   |  [Symbol Schnecke]     |
|  Geschwindigkeit [%]   |  Geschwindigkeit [%]   |  Beschleunigung   [%]  |
|  Beschleunigung  [%]   |  Beschleunigung  [%]   |  Verzögerung      [%]  |
|  Verzögerung     [%]   |  Verzögerung     [%]   |  Ruck             [%]  |
|  Ruck            [%]   |  Ruck            [%]   |                        |
+------------------------+------------------------+------------------------+
| Funktionsleiste: leer                                                     |
+--------------------------------------------------------------------------+
```

Die Anordnung weicht vom Referenzbild ab (dort liegt die Karte „Schnecke“ unten mittig): im 4 : 4 : 4-Raster stehen alle drei Karten nebeneinander, die Reihenfolge Zu, Auf, Schnecke bleibt. Jede Karte ist ein Gruppenbereich (HM-15) mit Überschrift in `Font.Size.Value`; Zeilen aus Beschriftung links und Eingabefeld rechts, Höhe `Size.Touch.Default`, Abstand `Size.Touch.Gap`. Die Funktionsleiste bleibt leer, aber sichtbar. Die Blättertaste „»“ des Referenzbildes entfällt: Es gibt nur einen Nachdosierer, das Blättern HD 1 ⇄ HD 2 gilt nur für HS-11 und HS-12 (Navigation.md 3.3, A-44).

**Höhenbilanz** (Kontrollrechnung bei 1920 × 1080; nutzbare Inhaltshöhe 768 = Inhaltszeile 34\* abzüglich 2 × `Size.Content.Margin`; keine Titelzeile): Karte Verschluss (größte) = 5 Zeilen (320) + 4 Abstände (64) + Kopf (52) + Innenabstand (32) = 468; Karte Schnecke = 3 Zeilen (192) + 2 Abstände (32) + Kopf (52) + Innenabstand (32) = 308. Beide liegen unter 768; es wird nicht gescrollt (Prüfpunkt HS-20-P15).

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)

Spalte „Herkunft (RS-20)“: T30 = Verschluss Zu / Verschluss Auf (je Karte 5 Zeilen, gesamt 10 Felder), T31 = Schnecke (3 Zeilen), W = nur im Referenzbild. Beispielwerte aus dem Referenzbild (HD1) sind keine Standardwerte des Nachdosierers. Alle 13 Felder tragen in der Referenz ein Schlüsselsymbol.

### Rahmen und Kopf

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-20) |
|---|---|---|---|---|
| Seitenleiste (Benutzerkreis, Home, Einstellungen, Meldungen, Zurück) | Rahmen | ersetzt Schloss, „Produktion“, „Einstellungen“, „Zurück“ der Referenz; „Zurück“ öffnet den obersten Verlaufseintrag (HS-19) | [HM-01](../Module/HM-01_Seitenleiste.md) | W: Schloss, Tasten „Produktion“, „Einstellungen“, „Zurück“ |
| Kopfzeile: Logo, Betriebsart, Uhrzeit/Datum | Rahmen | wie HS-11 (Spiral-Symbol: Betriebsart, OP-26) | [HM-02](../Module/HM-02_Kopfzeile.md) | W: Logo, Spiral-Symbol, Uhrzeit/Datum |
| Meldezeile | Anzeige | aktuelle Meldung (Referenzbild „*450* Palettierung nicht bereit“); Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | W: Meldezeile |
| Brotkrümel „Einstellung › Dosierer › Nachdosierer › Motorparameter“ | Navigation | Seitenpfad, Objektkennung (`ObjectSuffix`) „ND“ am letzten Segment (statt des Bildtitels „Motorparameter HD1“, der den Hauptdosierer meint, OP-39; S20-1); „Nachdosierer“ führt zu HS-19 | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | W: Seitentitel „Motorparameter HD1“ |
| Kennzahlen Geschwindigkeit, Maschinenwinkel | Anzeige | Rahmenkennzahlen | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | (Rahmen) |

### Karten Verschluss Zu und Verschluss Auf (T30)

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-20) |
|---|---|---|---|---|
| Karte „Verschluss Zu“ | Gruppenbereich mit fünf Zeilen | Bewegungsparameter des Verschlusses in Stellung geschlossen | [HM-21](../Module/HM-21_Motorparameter-Karte.md) (Kartenart ClosureClosed, `DoserName` „ND“) mit [HM-15](../Module/HM-15_Gruppenbereich.md) | Karte links oben |
| Karte „Verschluss Auf“ | Gruppenbereich mit fünf Zeilen | Bewegungsparameter des Verschlusses in Stellung geöffnet | HM-21 (Kartenart ClosureOpen) mit HM-15 | Karte rechts oben |
| Position | Eingabefeld mit Schlüssel, Einheit ° | „Position in Grad, an der der Verschluss geöffnet bzw. geschlossen ist.“ Bild (HD1) 0 ° / 37 ° | HM-21 mit [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) | T30 Nr. 1 (je Karte) |
| Geschwindigkeit | Eingabefeld mit Schlüssel, Einheit % | „Bewegungsgeschwindigkeit des Aktors in Prozent.“ Bild 80 % / 80 % | HM-21 mit HM-12 | T30 Nr. 2 (je Karte) |
| Beschleunigung | Eingabefeld mit Schlüssel, Einheit % | „Anstieg der Geschwindigkeit beim Start der Bewegung.“ Bild 0 % / 0 % | HM-21 mit HM-12 | T30 Nr. 3 (je Karte) |
| Verzögerung | Eingabefeld mit Schlüssel, Einheit % | „Abbremsen vor Erreichen der Endposition.“ Bild 0 % / 0 % | HM-21 mit HM-12 | T30 Nr. 4 (je Karte) |
| Ruck | Eingabefeld mit Schlüssel, Einheit % | „Änderung der Beschleunigung (sanfter Bewegungsbeginn und -ende).“ Bild 0 % / 0 % | HM-21 mit HM-12 | T30 Nr. 5 (je Karte) |

### Karte Schnecke (T31)

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-20) |
|---|---|---|---|---|
| Karte „Schnecke“ mit Schnecken-Symbol | Gruppenbereich mit drei Zeilen, Symbol `Icon.Motor.Screw` neben der Überschrift | Bewegungsparameter der Dosierschnecke | HM-21 (Kartenart Screw) mit HM-15 | Karte unten mittig; W: Schnecken-Symbol |
| Beschleunigung | Eingabefeld mit Schlüssel, Einheit % | „Anstieg der Drehgeschwindigkeit beim Start.“ Bild 0 % | HM-21 mit HM-12 | T31 Nr. 1 |
| Verzögerung | Eingabefeld mit Schlüssel, Einheit % | „Abbremsen der Drehung beim Stoppen.“ Bild 0 % | HM-21 mit HM-12 | T31 Nr. 2 |
| Ruck | Eingabefeld mit Schlüssel, Einheit % | „Änderung der Beschleunigung für eine produktschonende Bewegung.“ Bild 0 % | HM-21 mit HM-12 | T31 Nr. 3 |

### Funktionsleiste

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-20) |
|---|---|---|---|---|
| Funktionsleiste (leer) | Leiste ohne Tasten | bleibt sichtbar; die Taste „»“ des Referenzbildes (Funktion nicht beschrieben, dort von HS-12 übernommen) entfällt, da nur ein Nachdosierer existiert | [HM-06](../Module/HM-06_Funktionsleiste.md) | W: Taste „»“ |

## Verwendete Module (IDs)

- [HM-01](../Module/HM-01_Seitenleiste.md) – Seitenleiste
- [HM-02](../Module/HM-02_Kopfzeile.md) – Kopfzeile (enthält HM-03)
- [HM-03](../Module/HM-03_Meldezeile.md) – Meldezeile
- [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) – Brotkrümel-Navigation
- [HM-05](../Module/HM-05_Kennzahl-Kachel.md) – Kennzahl-Kachel
- [HM-06](../Module/HM-06_Funktionsleiste.md) – Funktionsleiste unten (leer)
- [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) – Eingabefeld mit Schlüsselsymbol
- [HM-13](../Module/HM-13_Eingabe-Pop-up.md) – Eingabe-Pop-up
- [HM-14](../Module/HM-14_Popup-Rahmen.md) – Pop-up-Rahmen (trägt HM-13)
- [HM-15](../Module/HM-15_Gruppenbereich.md) – Gruppenbereich (Rahmen der Karten)
- [HM-21](../Module/HM-21_Motorparameter-Karte.md) – Motorparameter-Karte

Blättertasten (HM-19) werden nicht verwendet (nur ein Nachdosierer).


## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

- **Bezug zum Dosierer.** Die Seite gilt immer für den Nachdosierer; Brotkrümel und `DoserName` „ND“ nennen ihn. Es gibt keinen Parameter und kein Blättern.
- **Eingabe-Pop-up.** Antippen eines Felds öffnet HM-13 in HM-14 mit Titel (Kartenname und Zeilenname), aktuellem Wert, Einheit (° oder %) und Grenzen; „Übernehmen“ nur bei gültigem Wert, „Abbrechen“ verwirft, Antippen außerhalb schließt nicht (Navigation.md 4.2). Der Handbuchtext der Zeile erscheint als Hilfetext im Pop-up (S20-2), die Karte kann ihn zusätzlich als Tooltip tragen. In der Referenz nicht beschrieben (A-20, OP-30); Grenzen sind Dummy (OP-28).
- **Berechtigung.** Alle 13 Felder tragen `Icon.Key`; ohne Berechtigung `Icon.Lock`, Antippen öffnet kein Eingabe-Pop-up, sondern den Hinweis „Berechtigung erforderlich: <Rolle>“ bzw. das Benutzer-Pop-up (OP-25, OP-04).
- **Fehlerfälle.** Ungültiger Wert: Feld im Zustand Fehler (Kontur `Border.Thick`, `Brush.Status.Error.Subtle`, `Icon.Status.Error`, Text „Wert außerhalb a bis b Einheit“); Übernehmen gesperrt. Werte in Textfarbe (`Brush.Text.Primary`), nicht in Rot.
- **Einheiten.** Position in Grad (°), alle übrigen Felder in Prozent (%); die Bezugsgröße der Prozentwerte ist offen (OP-45).
- **Navigation.** Seitenleiste „Zurück“ → HS-19 (Verlauf); Brotkrümel „Nachdosierer“ → HS-19, „Dosierer“ → HS-41; Meldezeile → HS-38. Bei offenem Pop-up ist alles außer dem Pop-up gesperrt.

## Prüfpunkte (Tabelle: ID | Prüfung | erwartetes Ergebnis | Status)

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-20-P01 | Zweck (RS-20-P01) | Seite beschreibt Bewegungsparameter für Verschluss und Schnecke (Text wie HS-12) | offen |
| HS-20-P02 | Vollständigkeit T30 (RS-20-P02) | je Verschlusskarte 5 Zeilen: Position, Geschwindigkeit, Beschleunigung, Verzögerung, Ruck | offen |
| HS-20-P03 | Vollständigkeit T31 (RS-20-P03) | Karte Schnecke mit 3 Zeilen: Beschleunigung, Verzögerung, Ruck | offen |
| HS-20-P04 | Karten (RS-20-P04) | „Verschluss Zu“, „Verschluss Auf“ (je 5 Felder) und „Schnecke“ (3 Felder, Schnecken-Symbol) vorhanden, gesamt 13 Felder | offen |
| HS-20-P05 | Einheiten (RS-20-P05) | Position in °, Geschwindigkeit in %, übrige Felder in %; Einheit hinter dem Wert, Format Wert, geschütztes Leerzeichen, Einheit | offen |
| HS-20-P06 | Bildbezug (RS-20-P06) | alle Karten der Referenz abgebildet; Titel „Motorparameter HD1“ des Bildes wird nicht übernommen, die Seite trägt „ND“ im Brotkrümel | offen |
| HS-20-P07 | Zugang (RS-20-P07) | Aufruf über „Motorparameter“ in der Funktionsleiste von HS-19 | offen |
| HS-20-P08 | Wiederverwendung (RS-20-P08) | Seite nutzt HM-21 (Felder HM-12, Rahmen HM-15) wie HS-12, keine Kopie | offen |
| HS-20-P09 | Rahmenelemente (RS-20-P09) | Kopfzeile, Meldezeile, Seitenleiste (Benutzer, Home, Einstellungen, Zurück) vorhanden; Funktionsleiste sichtbar, leer | offen |
| HS-20-P10 | Brotkrümel (RS-20-P10) | „Einstellung › Dosierer › Nachdosierer › Motorparameter“ | offen |
| HS-20-P11 | Keine Blättertasten | Funktionsleiste ohne „«“/„»“ (nur ein Nachdosierer) | offen |
| HS-20-P12 | Eingabefeld | jedes der 13 Felder öffnet das Eingabe-Pop-up; Wert außerhalb der Grenzen zeigt Fehlertext mit Symbol; ohne Berechtigung Schloss und Hinweis | offen |
| HS-20-P13 | Touch-Ziele | Felder mindestens `Size.Touch.Default` hoch (Trefferfläche nie unter `Size.Touch.Min`), Abstand mindestens `Size.Touch.Gap` | offen |
| HS-20-P14 | Zweiter Kanal und Tokens | Schloss/Schlüssel und Fehler mit Symbol, Form oder Text; keine Hex- oder Pixelwerte; Texte aus `.resx` | offen |
| HS-20-P15 | Layout | drei Karten 4 : 4 : 4 im Inhaltsbereich; größte Karte passt ohne Scrollen | offen |

## Annahmen dieser Seite

Lokale Kennungen; Sammeleintrag: [A-65](../../00_Plan/Annahmen.md).

| Kennung | Annahme |
|---|---|
| S20-1 | Brotkrümel-Objektkennung (`ObjectSuffix`) „ND“ für den Nachdosierer; Navigation.md und HM-04 nennen sie nicht, das Referenzbild trägt „HD1“. |
| S20-2 | Der Handbuchtext je Zeile erscheint als Hilfetext im Eingabe-Pop-up (Touch kennt keine Tooltips). |

## Offene Punkte

- OP-25 Berechtigungsstufen und Schlüsselsymbol; OP-04 Benutzer/Anmeldung.
- OP-28 Wertebereiche und Standardwerte; OP-29 Einheiten; OP-30 Eingabe-Pop-up.
- OP-39 fehlender Screenshot Nachdosierer: das Bild zeigt den Titel „Motorparameter HD1“; OP-38 Zugang und Navigationspfade.
- OP-55 Seite bildidentisch zu RS-12 und RS-17.
- OP-45 Bezugsgröße der Prozentwerte.
