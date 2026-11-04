# HS-43 – Schichtplan (Platzhalter)
- Quelle: keine RS-Datei, keine Design-Seite (Zusatzseite, Annahme A-33, OP-02). Einziger Beleg: Taste „Schichtplan“ in der Funktionsleiste von [DS-01](../../01_Design-Analyse/Seiten/DS-01_Produktion.md) (Element „Taste ‚Schichtplan‘ (grau)“, Funktion „öffnet Schichtplan (vermutet)“); [Navigation.md](../Navigation.md) Abschnitte 1, 2 und 3.3.
- Navigationspfad: Produktion › Schichtplan (Zugang: [HS-01](HS-01_Produktion.md) Funktionsleiste „Schichtplan“; Zurück-Ziel HS-01)

## Zweck
**Platzhalterseite.** Das Design zeigt eine Taste „Schichtplan“ auf der Produktionsseite; die Referenz beschreibt weder eine Schichtplan-Seite noch deren Inhalt, Daten oder Bedienung (OP-02, Agent.md Abschnitt 2 Nr. 3). Die Seite stellt nur sicher, dass die Taste ein Ziel hat, und kennzeichnet sich selbst als Platzhalter. Es werden keine Funktionen, Felder, Schichtmodelle oder Zeiten erfunden. Inhalt und Funktion sind vor der Umsetzung fachlich zu klären; Meilenstein 2 liefert höchstens Dummy-Daten (OP-02: „Platzhalterseite mit Dummy-Daten“).

## Aufbau (Bereiche, Layout)
Rahmen nach [Designsystem](../Designsystem.md) Abschnitt 3.2. Inhaltsbereich im 12-Spalten-Raster:

- **Zeile 1 (Auto):** Hinweis-Textfeld, Art Info, über alle 12 Spalten: Kennzeichnung als Platzhalter (siehe Elemente).
- **Zeile 2 (Stern, Rest):** ein Gruppenbereich „Schichtplan“ über 12 Spalten, leer („Keine Daten“); hier käme später der Inhalt. Es gibt keine Tabellen-, Kalender- oder Eingabeelemente, solange der Inhalt unbekannt ist.
- **Funktionsleiste unten leer, aber sichtbar** (Navigation.md Abschnitt 3.3: HS-43 ohne eigene Tasten).

```
+--------------------------------------------------------------+
| Brotkrümel: Produktion > Schichtplan       | Geschw. | Winkel|
+--------------------------------------------------------------+
| (i) Info: Platzhalter - Schichtplan noch nicht definiert     |
+--------------------------------------------------------------+
| Schichtplan                                                  |
|   Keine Daten                                                |
|                       (leerer Gruppenbereich)                |
+--------------------------------------------------------------+
| Funktionsleiste (leer)                                       |
+--------------------------------------------------------------+
```

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Herkunft: Es gibt keine RS-Elemente; die einzige Quelle ist die Taste in DS-01. Alle weiteren Elemente sind Rahmen oder als Platzhalter gekennzeichnet.

| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Rahmen: Seitenleiste, Kopfzeile mit Meldezeile, Brotkrümel „Produktion › Schichtplan“, Kennzahlen, Funktionsleiste (leer) | Rahmen | wie alle Vollseiten; Brotkrümel: „Produktion“ antippbar (→ HS-01), „Schichtplan“ nur Anzeige (A-34) | [HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md) |
| Hinweis „Platzhalter“ | Hinweis-Textfeld (Art Info, `Icon.Status.Info` und Wort „Info“) | kennzeichnet die Seite als Platzhalter ohne Funktion, z. B. „Platzhalter: Der Schichtplan ist noch nicht definiert.“ (Wortlaut Platzhalter, `.resx`) | [HM-27](../Module/HM-27_Hinweis-Textfeld.md) |
| Gruppenbereich „Schichtplan“, Text „Keine Daten“ | Gruppenbereich (leer) | Container für den späteren Inhalt; nur Überschrift und Leertext (Dummy) | [HM-15](../Module/HM-15_Gruppenbereich.md) |
| Zugangstaste „Schichtplan“ (liegt auf HS-01, nicht auf dieser Seite) | Aktionstaste in der Funktionsleiste von HS-01 mit `Icon.Schedule` | navigiert hierher (DS-01 „Taste Schichtplan“) | [HM-07](../Module/HM-07_Aktionstaste.md) auf HS-01 |

## Verwendete Module (IDs)
- Rahmen: [HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md) (enthält [HM-03](../Module/HM-03_Meldezeile.md)), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md)
- Inhalt: [HM-27](../Module/HM-27_Hinweis-Textfeld.md), [HM-15](../Module/HM-15_Gruppenbereich.md)

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- **Interaktion:** keine bedienbaren Inhaltselemente. Die Seite ist reine Anzeige.
- **Navigation:** Zugang über die Funktionsleiste von HS-01 (Taste „Schichtplan“, `Icon.Schedule`). Zurück: Seitenleiste „Zurück“ (Verlauf, normal HS-01) oder Brotkrümel-Segment „Produktion“ bzw. Seitenleiste „Home“. Die Seitenleiste hebt „Home“ hervor (Navigation.md Abschnitt 3.1).
- **Berechtigungen:** keine Mindestrolle, kein Schlüsselsymbol (nichts belegt, OP-04).
- **Pop-ups:** keine. Bei offenem Pop-up Seite gesperrt (Navigation.md 4.2).
- **Fehlerfälle:** keine; fehlende Daten werden als „Keine Daten“ angezeigt, nicht als Fehler.
- **Platzhalter-Kennzeichnung:** der Hinweis bleibt dauerhaft sichtbar, bis die Seite fachlich definiert ist.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-43-P01 | Zugang | Taste „Schichtplan“ in der Funktionsleiste von HS-01 öffnet HS-43 (DS-01-P08, Navigation.md Abschnitt 1) | offen |
| HS-43-P02 | Brotkrümel | „Produktion › Schichtplan“; „Produktion“ antippbar (→ HS-01), „Schichtplan“ nur Anzeige | offen |
| HS-43-P03 | Platzhalter gekennzeichnet | Hinweis-Textfeld Art Info mit `Icon.Status.Info` und Wort „Info“ sichtbar; Text nennt die Seite als Platzhalter | offen |
| HS-43-P04 | Nichts erfunden | Seite enthält keine Felder, Tabellen, Zeiten oder Schichtnamen; nur Hinweis, Gruppenbereich „Schichtplan“ mit „Keine Daten“ (OP-02) | offen |
| HS-43-P05 | Funktionsleiste | leer, aber sichtbar (Navigation.md Abschnitt 3.3) | offen |
| HS-43-P06 | Seitenleiste | „Home“ hervorgehoben; „Zurück“ aktiv und führt nach HS-01 | offen |
| HS-43-P07 | Zurück | „Zurück“ führt zur vorherigen Seite im Verlauf (HS-01); Home setzt den Verlauf zurück | offen |
| HS-43-P08 | Zweiter Kanal | Platzhalter-Status über Symbol und Text, nicht nur über Farbe | offen |
| HS-43-P09 | Tokens | keine Hex- oder Pixelwerte; Hinweisfläche `Brush.Status.Info.Subtle`, Gruppenfläche `Brush.Surface.Sunken` | offen |
| HS-43-P10 | Hell/Dunkel | Text auf Hinweisfläche und Gruppenfläche in beiden Themen mindestens 4,5 : 1 | offen |
| HS-43-P11 | Beschriftung | Texte („Schichtplan“, „Keine Daten“, Hinweistext) aus `.resx` (`Nav_ShiftPlan_*`) | offen |

## Offene Punkte
- OP-02: Schichtplan ohne Referenz; Inhalt, Daten, Bedienung und Berechtigung sind fachlich zu klären (Platzhalter mit Dummy-Daten als Annahme).
- OP-04: Benutzer/Berechtigung (Dummy); OP-07: Seite ohne Designvorlage.
- OP-21: Antippbarkeit der Brotkrümel-Segmente.
