# HS-38 – Meldeanzeige

- Quelle: [RS-38](../../02_Referenz-Analyse/Seiten/RS-38_Meldeanzeige.md) (Kapitel 38, Tabelle 48, Bild RS-38_01); Design: Seitenleisten-Symbol „Meldungen“ ([DS-01](../../01_Design-Analyse/Seiten/DS-01_Produktion.md) und alle Rahmen, OP-08), keine eigene Design-Seite; Aufbau aus [Designsystem](../Designsystem.md) und den Modulen abgeleitet
- Navigationspfad: Meldungen (einziges Segment, kein Elternsegment; Zugang: Meldezeile auf jeder Seite oder Seitenleiste „Meldungen“; Zurück-Ziel: aufrufende Seite im Verlauf; Seitenregister `MessageView` / `messages`, Navigation.md Abschnitt 2 und 5.1)

## Zweck

Die Meldeanzeige stellt aktuelle Systemmeldungen übersichtlich dar und dient dem Bedienpersonal zur Diagnose von Störungen, Warnungen und Hinweisen (Handbuch). Sie ist eine Querseite zu jeder Seite: Die Meldezeile im Rahmen zeigt automatisch die Meldung mit der höchsten Nummer; Antippen öffnet diese vollständige Liste. Von hier führt die Funktionsleiste ins Meldearchiv ([HS-37](HS-37_Meldearchiv.md)).

## Aufbau (Bereiche, Layout)

Rahmen: [HM-01](../Module/HM-01_Seitenleiste.md) (Symbol „Meldungen“ hervorgehoben), [HM-02](../Module/HM-02_Kopfzeile.md) mit [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) (nur Segment „Meldungen“, nicht antippbar), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md). Die Meldezeile liegt im neuen Rahmen in der Kopfzeile und überdeckt die Liste nicht (im Bild überdeckt sie die letzte Listenzeile, OP-44).

**Inhaltsbereich:** eine einzige Liste über die volle Breite (12 Spalten), Außenrand `Space.L`, Höhe 1\* bis zur Funktionsleiste.

```
Inhaltsbereich (12 Spalten, 1 Zeile 1*)
+----------------------------------------------------------------+---+
| Kopf:  Nummer (1*)  |  Klasse (1*) |  Meldung (8*)             | R |
| 090   [Hinweis]       Palettierung nicht bereit                | o |
| 098   [Hinweis]       Grundstellungsfahrt Hochstoß            | l |
| 100   [Störung]      Steuerung ein Schalter ist ausgeschaltet | l |
| ...                                                            | b |
|                                                                | a |
|                                                                | l |
+----------------------------------------------------------------+---+
Funktionsleiste unten:  [ Archiv ]
```

- **Listenkopf:** Spalten „Nummer“ und „Meldung“ (Referenz). Zusätzlich eine schmale Klassenspalte mit Symbol und Klassenwort als zweiter Kanal zur Zeilenfarbe (A-49, OP-43); sie entsteht aus [HM-25](../Module/HM-25_Meldungsliste.md) und ersetzt keine Referenzspalte.
- **Zeilen:** Höhe mindestens `Size.Touch.Min`; Flächenton nach Klasse (`Brush.Status.Ok.Subtle`, `.Warning.Subtle`, `.Error.Subtle`), aufsteigend nach Nummer (Bild).
- **Rollbalken:** am rechten Listenrand, Trefferbereich mindestens `Size.Touch.Min` breit; Wischen auf der Liste ist zusätzlich möglich.
- **Funktionsleiste unten:** links die Taste „Archiv“ (Archiv-Symbol mit Ausrufezeichen), sonst leer.

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)

Spalte „Herkunft“ = Rückverfolgung zu [RS-38](../../02_Referenz-Analyse/Seiten/RS-38_Meldeanzeige.md).

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Automatische Anzeige | Verhalten der Meldezeile | Beim Auftreten einer Meldung wird die Meldung mit der höchsten Nummer in der Meldezeile eingeblendet (Rahmen jeder Seite, Format „NNN: Text“, mit Zähler „+ n“ bei weiteren, A-49). | [HM-03](../Module/HM-03_Meldezeile.md) | RS-38 Tabelle 48, Zeile 1 |
| Meldeanzeige öffnen | Interaktion (Antippen der Meldezeile) | Antippen der Meldezeile oder des Seitenleisten-Symbols „Meldungen“ öffnet diese Seite; auf HS-38 selbst ohne Wirkung. Bei offenem Pop-up wird das Öffnen bis zum Schließen zurückgestellt. | [HM-03](../Module/HM-03_Meldezeile.md), [HM-01](../Module/HM-01_Seitenleiste.md) | Zeile 2 |
| Meldeanzeige schließen | Interaktion | Die Schaltfläche „Zurück“ (Seitenleiste) schließt die Anzeige und führt zur aufrufenden Seite. Das erneute Antippen der Meldezeile der Referenz („ein weiterer Klick“) wirkt im neuen Rahmen nicht (Navigation.md 3.2); Ersatz: Zurück oder Seitenleisten-Symbol der gewünschten Seite. | [HM-01](../Module/HM-01_Seitenleiste.md) | Zeile 3 |
| Farbkennzeichnung | Darstellung | Grün = Betriebsstatus Automatik; Gelb = Hinweise und Statusmeldungen; Rot = Störung oder sicherheitsrelevante Meldung, führt zum Stopp. Im neuen HMI zusätzlich Symbol und Klassenwort („Betrieb“, „Hinweis“, „Störung“). | [HM-25](../Module/HM-25_Meldungsliste.md) (Klassenzustände) | Zeile 4 |
| Meldungsnummer | Listenspalte „Nummer“ | Eindeutige Nummer zur Identifikation der Meldung, z. B. für Service oder Dokumentation; dreistellig ohne Sternchen („090“ statt „\*090\*“). | [HM-25](../Module/HM-25_Meldungsliste.md) | Zeile 5 |
| Meldungstext | Listenspalte „Meldung“ | Kurzbeschreibung der Ursache oder des betroffenen Bereichs; Text mit Platzhaltern der Steuerung wie `<GR003_Aktoren.instAktor_3Y1.o_sError, STRING>` wird aufgelöst angezeigt, nicht abgeschnitten (Umbruch in der Zeile). | [HM-25](../Module/HM-25_Meldungsliste.md) | Zeile 6 |
| Taste „Archiv“ | Aktionstaste, Navigation (Funktionsleiste) | Im Handbuch nicht beschrieben; Annahme: wechselt zum [Meldearchiv HS-37](HS-37_Meldearchiv.md) (Verlauf wächst um HS-38). | [HM-06](../Module/HM-06_Funktionsleiste.md), [HM-07](../Module/HM-07_Aktionstaste.md) | RS-38 „nur im Bild“, Zeile 1 |
| Rollbalken | Bedienelement | Blättern in der Liste (Wischen zusätzlich). | [HM-25](../Module/HM-25_Meldungsliste.md) (Rollbalken-Darstellung) | „nur im Bild“, Zeile 2 |
| Kopfzeile, Schloss, Tasten Produktion/Einstellungen/Zurück | Rahmen | Wie [HS-35](HS-35_Systemeinstellungen.md): Uhrzeit und Datum in der Kopfzeile; Produktion, Einstellungen, Zurück und Anmeldestatus in der Seitenleiste. Der Titel „Meldungsanzeige“ des Bildes gilt nicht; Seitenname laut Kapitel „Meldeanzeige“, Brotkrümel „Meldungen“ (OP-33). | [HM-02](../Module/HM-02_Kopfzeile.md), [HM-01](../Module/HM-01_Seitenleiste.md) | „nur im Bild“, Zeile 3 |
| Meldezeile (unten im Bild, rot, „\*450\* Palettierung nicht bereit“) | Rahmen | Im neuen Rahmen in der Kopfzeile; zeigt dieselbe Meldung mit Klassenwort und Symbol. | [HM-03](../Module/HM-03_Meldezeile.md) | Bild RS-38_01 |

## Verwendete Module (IDs)

- Rahmen: [HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md)
- Seite: [HM-25](../Module/HM-25_Meldungsliste.md) (Listenart Live), [HM-07](../Module/HM-07_Aktionstaste.md) („Archiv“)

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

- **Öffnen.** Meldezeile (jede Seite, außer HS-24) oder Seitenleiste „Meldungen“; die Seite wird in den Verlauf gelegt, „Zurück“ führt zur Ausgangsseite. Das Symbol „Meldungen“ in der Seitenleiste ist hervorgehoben (Balken und Zähler-Punkt, nicht nur Farbe).
- **Keine Berechtigung nötig.** Die Seite trägt keine Schlüsselsymbole; Quittieren ist in der Referenz nicht beschrieben, es gibt keine Quittiertaste (OP-27, Annahme: Meldungen verschwinden mit der Ursache).
- **Neue Meldungen.** Während die Seite offen ist, wird die Liste live ergänzt; die Position des Rollbalkens bleibt erhalten, eine neue Störung blendet einen Hinweis „Neue Meldung“ am Listenanfang ein (Annahme).
- **Leerer Zustand.** Ohne anstehende Meldungen zeigt die Liste den Text „Keine Meldungen“, die Meldezeile „Keine Meldung“.
- **Klassen.** Betriebsstatus (Ok), Hinweis (Warnung), Störung (Fehler) wie in A-49; Rot führt zum Stopp (Handbuch, Satz unvollständig, OP-35). Die Zuordnung Nummer zu Farbe (z. B. 090 gelb in der Liste, rot in der Meldezeile) ist nicht erklärt (OP-27); die Klasse folgt der Steuerung je Meldung.
- **Sortierung.** Aufsteigend nach Nummer (Bild); die Meldezeile zeigt die Meldung mit der höchsten Nummer (Handbuch), bei mehreren Meldungen der Rahmen mit Zähler (A-49).
- **Pop-ups.** Keine; ist ein Pop-up einer anderen Seite offen, wird die Anforderung zurückgestellt (Navigation.md 4.2 Punkt 7).
- **Archiv.** Die Taste „Archiv“ wechselt zu HS-37; „Zurück“ dort führt hierher.

## Prüfpunkte (Tabelle: ID | Prüfung | erwartetes Ergebnis | Status)

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-38-P01 | Automatische Anzeige (RS-38-P01) | Bei neuer Meldung zeigt die Meldezeile auf allen Seiten mit Rahmen die Meldung mit der höchsten Nummer | offen |
| HS-38-P02 | Öffnen (RS-38-P02) | Antippen der Meldezeile und Antippen des Seitenleisten-Symbols öffnen die Meldeanzeige; Brotkrümel „Meldungen“ | offen |
| HS-38-P03 | Schließen (RS-38-P03) | „Zurück“ schließt die Anzeige und führt zur aufrufenden Seite; erneutes Antippen der Meldezeile ist auf HS-38 wirkungslos (dokumentierte Abweichung zum Handbuch) | offen |
| HS-38-P04 | Farbe Grün (RS-38-P04) | Meldungen der Klasse Betriebsstatus Automatik: Flächenton Ok mit `Icon.Status.Ok` und Wort „Betrieb“ | offen |
| HS-38-P05 | Farbe Gelb (RS-38-P05) | Hinweise und Statusmeldungen: Flächenton Warnung mit `Icon.Status.Warning` und Wort „Hinweis“ | offen |
| HS-38-P06 | Farbe Rot (RS-38-P06) | Störung oder sicherheitsrelevante Meldung (führt zum Stopp): Flächenton Fehler mit `Icon.Status.Error` und Wort „Störung“ | offen |
| HS-38-P07 | Listenspalten (RS-38-P07) | Spalten „Nummer“ (z. B. 090) und „Meldung“ (Text); aufsteigend nach Nummer | offen |
| HS-38-P08 | Zustände nicht nur über Farbe (RS-38-P08) | Jede Zeile trägt zusätzlich zum Flächenton Symbol und Klassenwort; in Graustufen unterscheidbar | offen |
| HS-38-P09 | Untere Leiste (RS-38-P09) | Taste „Archiv“ links; Produktion, Einstellungen, Zurück und Anmeldestatus in der Seitenleiste | offen |
| HS-38-P10 | Bildabgleich (RS-38-P10) | Liste mit Rollbalken, Meldezeile mit Meldung 450 im Rahmen (Kopfzeile), Seitenname „Meldeanzeige“, Brotkrümel „Meldungen“; keine Überdeckung der letzten Listenzeile durch die Meldezeile | offen |
| HS-38-P11 | Navigation zum Archiv | Taste „Archiv“ öffnet HS-37; „Zurück“ führt wieder nach HS-38 | offen |
| HS-38-P12 | Touch-Ziele | Listenzeilen mindestens `Size.Touch.Min` hoch, Rollbalken mit Trefferbereich mindestens `Size.Touch.Min`, Taste „Archiv“ mindestens `Size.Touch.Default` hoch und `Size.FunctionButton.MinWidth` breit | offen |
| HS-38-P13 | Leerer Zustand | Ohne Meldungen erscheint „Keine Meldungen“ | offen |
| HS-38-P14 | Tokens | Keine Hex- und Pixelwerte im Seitenaufbau; nur Tokens des Designsystems | offen |

## Annahmen dieser Seite

- S38-1: Abweichung vom Handbuch: „ein weiterer Klick“ auf die Meldezeile schließt die Anzeige nicht, die Meldezeile ist auf HS-38 wirkungslos (Navigation 3.2); geschlossen wird über „Zurück“. Lokale Annahme dieser Seite.
- S38-2: Die Liste ist aufsteigend nach Nummer sortiert (Bild); HM-25 erhält dafür einen Parameter Sortierrichtung.
- S38-3: Zusätzliche Klassenspalte mit Symbol und Wort (A-49) als zweiter Kanal.
- S38-4: Klassenwörter nach HM-25: „Betrieb“, „Hinweis“, „Störung“. HM-03 verwendet „Warnung“ und „Alarm“ für dieselben Klassen; die Inkonsistenz ist gemeldet.
- S38-5: Taste „Archiv“ führt zu HS-37; Hinweis „Neue Meldung“ am Listenanfang bei Live-Ergänzung ist eine Annahme.

## Offene Punkte

- OP-08: Seitenleiste „Meldungen“ als zweiter Zugang (Design).
- OP-22: Verhalten bei mehreren gleichzeitigen Meldungen und Priorität (Meldezeile zeigt die höchste Nummer laut Handbuch, HM-03 die höchste Priorität).
- OP-27: Zuordnung Nummer zu Farbe, Quittierung.
- OP-33: Titel „Meldungsanzeige“ (Bild) gegenüber „Meldeanzeige“ (Kapitel).
- OP-35: Handbuchsatz „Führen zum Stopp“ unvollständig.
- OP-38: Taste „Archiv“ und Seitenleisten-Zugang.
- OP-43: Zustände nur über Farbe im Original; hier durch Symbol und Wort ergänzt.
- OP-44: Meldezeile überdeckt im Bild die letzte Listenzeile.
- OP-49: Sortierung, Quittierung, nicht beschriebene Funktionen.
