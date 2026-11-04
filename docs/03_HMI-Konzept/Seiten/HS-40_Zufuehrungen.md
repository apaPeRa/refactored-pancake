# HS-40 – Zuführungen (Zwischenseite)
- Quelle: keine RS-Datei (Zusatzseite, Annahme A-33, Lücke OP-20). Herleitung aus [DS-02](../../01_Design-Analyse/Seiten/DS-02_Einstellungen.md) (Kachel „Zuführungen“), [DS-03](../../01_Design-Analyse/Seiten/DS-03_Heissleim.md) und [DS-05](../../01_Design-Analyse/Seiten/DS-05_Kartonzufuehrung.md) (Brotkrümel „Einstellung › Zuführungen › …“), [RS-04](../../02_Referenz-Analyse/Seiten/RS-04_Einstellungen.md) (Funktionen 1 „Zuführung Papier“ und 2 „Zuführung Karton“), [RS-06](../../02_Referenz-Analyse/Seiten/RS-06_Zufuehrung-Karton.md) (Taste „Heißleimgerät“ → RS-07), [Navigation.md](../Navigation.md) Abschnitt 6.1.
- Navigationspfad: Einstellung › Zuführungen (Zugang: [HS-04](HS-04_Einstellungen.md) Kachel „Zuführungen“; Zurück-Ziel HS-04 laut Navigation.md Abschnitt 2)

## Zweck
Kachelmenü als Zwischenebene für alle Zuführungen der Maschine. Das Design nennt den Brotkrümel „Zuführungen“ und die Kachel in HS-04, zeigt die Seite aber nicht; die Referenz kennt keine Zwischenseite (Papier und Karton sind dort eigene Kacheln in RS-04). HS-40 hat keine eigenen Parameter, Anzeigen oder Aktionen, sie führt nur zu [HS-05](HS-05_Zufuehrung-Papier.md), [HS-06](HS-06_Zufuehrung-Karton.md) und [HS-07](HS-07_Heissleim-Nordson.md). Die gesamte Seite ist eine Annahme (OP-20, A-33).

## Aufbau (Bereiche, Layout)
Rahmen nach [Designsystem](../Designsystem.md) Abschnitt 3.2 (Seitenleiste 3\*, Arbeitsbereich 37\*; Zeilen Kopfzeile 4\* : Brotkrümel 3\* : Inhalt 34\* : Funktionsleiste 4\*). Inhaltsbereich im 12-Spalten-Raster (Außenrand `Space.L`, Gutter `Space.M`), Muster wie die Kachelgruppen in HS-04:

- **Eine Kachelzeile oben** im Inhaltsbereich: 3 Kacheln zu je 4 von 12 Spalten, Höhe `Size.Touch.Large`, Abstand `Size.Touch.Gap`. Reihenfolge links nach rechts: Papier, Karton, Heißleim (Reihenfolge der Brotkrümel/Referenz: Papier RS-05, Karton RS-06, Heißleim RS-07).
- **Restfläche darunter leer** (neutral `Brush.Window`), keine Platzhalter-Kacheln erfunden. Ein späteres Erweitern (weitere Zuführungen) belegt die nächsten Spalten bzw. eine zweite Zeile (HM-16 erlaubt 1 bis 6 Spalten, 1 bis 4 Zeilen).
- **Funktionsleiste unten leer, aber sichtbar** (Navigation.md Abschnitt 3.3, Seitentyp „Kachelmenü / Zwischenseite“).

```
+--------------------------------------------------------------+
| Brotkrümel: Einstellung > Zuführungen      | Geschw. | Winkel|
+--------------------------------------------------------------+
|  [   Papier   ]  [   Karton   ]  [  Heißleim  ]   (3 x 4/12) |
|                                                              |
|                     (leer, reserviert)                       |
+--------------------------------------------------------------+
| Funktionsleiste (leer)                                       |
+--------------------------------------------------------------+
```

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Rahmen: Seitenleiste, Kopfzeile mit Meldezeile, Brotkrümel „Einstellung › Zuführungen“, Kennzahlen Geschwindigkeit und Maschinenwinkel, Funktionsleiste (leer) | Rahmen | wie alle Vollseiten; „Einstellung“ im Brotkrümel führt auf HS-04, „Zuführungen“ ist letztes Segment (nur Anzeige) | [HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md) |
| Kachel „Papier“ | Kachel-Navigation | öffnet [HS-05](HS-05_Zufuehrung-Papier.md) (Papierzuführung). Herkunft: RS-04 Tabelle T4 Nr. 1 „Zuführung Papier“: „Enthält alle Einstellungen der Papierzuführung.“; Raster Z1/S1 | [HM-16](../Module/HM-16_Kachel-Navigation.md) |
| Kachel „Karton“ | Kachel-Navigation | öffnet [HS-06](HS-06_Zufuehrung-Karton.md). Herkunft: RS-04 T4 Nr. 2 „Zuführung Karton“: „Enthält alle Einstellungen der Kartonzuführung. Sowie das Heißleimgerät zuständig für die Kartonzuführung.“; Raster Z2/S1 | [HM-16](../Module/HM-16_Kachel-Navigation.md) |
| Kachel „Heißleim“ | Kachel-Navigation | öffnet [HS-07](HS-07_Heissleim-Nordson.md) (Heißleim Nordson). Herkunft: Design (Brotkrümel DS-03 „Einstellung › Zuführungen › Heißleim“); Referenz-Zugang über Taste „Heißleimgerät“ in RS-06 bleibt als zweiter Zugang in HS-06 erhalten | [HM-16](../Module/HM-16_Kachel-Navigation.md) |

Rückverfolgung zu RS-04: Die Kacheln „Zuführung Papier“ (Nr. 1) und „Zuführung Karton“ (Nr. 2) entfallen als Einzelkacheln in HS-04 und sind hier wiederzufinden (A-36, OP-51). Die Beschreibungstexte der Tabelle T4 erscheinen nicht auf der Kachel (Kachel = Beschriftung, optional Symbol); sie bleiben als Funktionsbeschreibung in dieser Tabelle.

## Verwendete Module (IDs)
- Rahmen: [HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md) (enthält [HM-03](../Module/HM-03_Meldezeile.md)), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md)
- Inhalt: [HM-16](../Module/HM-16_Kachel-Navigation.md) (3 Kacheln, Raster 3 × 1)

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- **Interaktion:** Antippen einer Kachel navigiert (`NavigateTo`) zu HS-05, HS-06 bzw. HS-07; die Navigation ändert keinen Maschinenzustand (Navigation.md Abschnitt 0, Punkt 6). Auslösen beim Loslassen im Ziel (Designsystem Abschnitt 5, Zustand „Gedrückt“).
- **Kachelzustände:** Normal, Gedrückt (dickere Kontur). Keine deaktivierten oder reservierten Kacheln auf dieser Seite.
- **Zurück:** Seitenleiste „Zurück“ geht im Verlauf zurück, normalerweise HS-04 (Navigation.md Abschnitt 5.3); Brotkrümel-Segment „Einstellung“ führt direkt auf HS-04. Rückweg aus HS-05/HS-06/HS-07 ist HS-40 (Verlauf).
- **Hervorhebung Seitenleiste:** „Einstellungen“ ist aktiv (alle Seiten unter „Einstellung“).
- **Pop-ups:** keine. Bei offenem Pop-up (z. B. Benutzer) ist die Seite gesperrt (Navigation.md Abschnitt 4.2).
- **Berechtigungen:** keine seitenseitige Mindestrolle (Navigation.md Abschnitt 5.1: „–“); Kacheln ohne Schlüsselsymbol.
- **Fehlerfälle:** keine eigenen; ein nicht ladbares Ziel wird über die Meldezeile (Info-Text) gemeldet (A-28).
- **Heißleim-Doppelzugang:** HS-07 hat den kanonischen Brotkrümel unter „Zuführungen“ (A-34), unabhängig davon, ob es aus HS-40 oder aus HS-06 geöffnet wurde.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-40-P01 | Brotkrümel | „Einstellung › Zuführungen“; „Einstellung“ antippbar (→ HS-04), „Zuführungen“ nur Anzeige (NAV-P03, A-34) | offen |
| HS-40-P02 | Kacheln | genau 3 Kacheln „Papier“, „Karton“, „Heißleim“ in der Reihenfolge Papier, Karton, Heißleim; keine weitere, keine leere Kachel | offen |
| HS-40-P03 | Kachelziele | Papier → HS-05, Karton → HS-06, Heißleim → HS-07 (Navigation.md Abschnitt 1) | offen |
| HS-40-P04 | Rückverfolgung RS-04 | Funktionen „Zuführung Papier“ (T4 Nr. 1) und „Zuführung Karton“ (T4 Nr. 2) sind über HS-40 erreichbar; sie fehlen als Einzelkacheln in HS-04 (RS-04-P09, OP-51) | offen |
| HS-40-P05 | Zweiter Zugang Heißleim | HS-06 Taste „Heißleimgerät“ öffnet weiterhin HS-07 (RS-06-P08); Brotkrümel von HS-07 bleibt „Einstellung › Zuführungen › Heißleim“ | offen |
| HS-40-P06 | Funktionsleiste | leer, aber sichtbar (Navigation.md Abschnitt 3.3) | offen |
| HS-40-P07 | Touch-Ziele | Kacheln Höhe mindestens `Size.Touch.Large`, Abstand mindestens `Size.Touch.Gap` (HM-16-P06) | offen |
| HS-40-P08 | Zweiter Kanal | Kachelzustand Gedrückt über dickere Kontur (`Border.Medium`), Beschriftung als Text; kein Zustand nur über Farbe | offen |
| HS-40-P09 | Tokens | keine Hex- oder Pixelwerte in der Seite; Farben, Maße, Schriften nur über Tokens aus Designsystem.md | offen |
| HS-40-P10 | Beschriftung | Kachelbeschriftungen aus `.resx` (`HS40_Tile_*`, Annahme A-95: seitenspezifisches Präfix wie `HS04_Tile_*`), ohne Trennstriche, automatischer Umbruch (OP-13) | offen |
| HS-40-P11 | Zurück | „Zurück“ aus HS-05/06/07 führt (bei Zugang über diese Seite) nach HS-40, von HS-40 nach HS-04 | offen |

## Offene Punkte
- OP-20: Zwischenseite „Zuführungen“ fehlt im Design; Aufbau (3 Kacheln) ist Annahme A-33/A-34.
- OP-12: Zuordnung der Einstellungskacheln zu Referenzseiten; OP-51: Entfall der Einzelkacheln Papier/Karton in HS-04.
- OP-13: mehrzeilige Kachelbeschriftung ohne Trennstrich.
- OP-36: Zugang zu den Heißleim-Unterseiten (Sprungziel „Heißleimgerät“) im Handbuch nicht beschrieben.
- OP-21: Antippbarkeit der Brotkrümel-Segmente (Annahme A-34).
