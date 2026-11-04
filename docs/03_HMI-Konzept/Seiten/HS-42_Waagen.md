# HS-42 – Waagen (Zwischenseite)
- Quelle: keine RS-Datei (Zusatzseite, Annahme A-33, A-36). Herleitung aus [DS-02](../../01_Design-Analyse/Seiten/DS-02_Einstellungen.md) (Kachel „Waagen“, Ziel nicht abgebildet), [RS-04](../../02_Referenz-Analyse/Seiten/RS-04_Einstellungen.md) (Funktionen 4 „Kontrollwaage“, 7 „Endkontrollwaage“, 12 „Waagen kalibrieren“), [RS-13](../../02_Referenz-Analyse/Seiten/RS-13_Kontrollwaage.md), [RS-27](../../02_Referenz-Analyse/Seiten/RS-27_Waagen-Kalibrieren.md), [Navigation.md](../Navigation.md) Abschnitte 1, 2, 6.3.
- Navigationspfad: Einstellung › Waagen (Zugang: [HS-04](HS-04_Einstellungen.md) Kachel „Waagen“; Zurück-Ziel HS-04)

## Zweck
Kachelmenü, das die waagenbezogenen Seiten bündelt: Kontrollwaage ([HS-13](HS-13_Kontrollwaage.md)), Waagen kalibrieren ([HS-27](HS-27_Waagen-Kalibrieren.md)) und die in der Referenz aufgeführte, aber nicht beschriebene Endkontrollwaage (deaktivierte Kachel). Das Design hat nur die eine Kachel „Waagen“ in HS-04; die Referenz führt die drei Funktionen als eigene Kacheln in RS-04. HS-42 löst beides auf (A-36). Die Seite hat keine eigenen Parameter, Anzeigen oder Aktionen. Die Gruppierung ist eine Annahme.

## Aufbau (Bereiche, Layout)
Rahmen nach [Designsystem](../Designsystem.md) Abschnitt 3.2. Inhaltsbereich im 12-Spalten-Raster:

- **Eine Kachelzeile oben:** 3 Kacheln zu je 4 von 12 Spalten, Höhe `Size.Touch.Large`, Abstand `Size.Touch.Gap`. Reihenfolge links nach rechts wie im Navigationsbaum: Kontrollwaage, Endkontrollwaage (deaktiviert), Waagen kalibrieren.
- **Restfläche darunter leer.**
- **Funktionsleiste leer, aber sichtbar** (Navigation.md Abschnitt 3.3).

```
+--------------------------------------------------------------+
| Brotkrümel: Einstellung > Waagen           | Geschw. | Winkel|
+--------------------------------------------------------------+
| [ Kontrollwaage ] [ Endkontrollwaage ] [ Waagen kalibrieren ]|
|                    (gestrichelt, deakt.)          (3 x 4/12) |
|                                                              |
|                         (leer)                               |
+--------------------------------------------------------------+
| Funktionsleiste (leer)                                       |
+--------------------------------------------------------------+
```

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Rahmen: Seitenleiste, Kopfzeile mit Meldezeile, Brotkrümel „Einstellung › Waagen“, Kennzahlen, Funktionsleiste (leer) | Rahmen | wie alle Vollseiten | [HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md) |
| Kachel „Kontrollwaage“ | Kachel-Navigation | öffnet [HS-13](HS-13_Kontrollwaage.md). Herkunft: RS-04 Tabelle T4 Nr. 4 „Kontrollwaage“: „Einstellungen der Kontrollwaage und ein Verlauf der letzten Gewichte und Statistik.“; Raster Z4/S1 | [HM-16](../Module/HM-16_Kachel-Navigation.md) |
| Kachel „Endkontrollwaage“ | Kachel-Navigation, Zustand deaktiviert (Platzhalter) | ohne Ziel. Herkunft: RS-04 T4 Nr. 7 „Endkontrollwaage“: „Einstellungen der Endkontrollwaage und ein Verlauf der letzten Gewichte und Statistik.“ (kein Handbuchkapitel, A-12, OP-24); Raster Z4/S2. Darstellung: gestrichelte Kontur, `Brush.Text.Disabled`, `Icon.Block` und Text „Nicht verfügbar“; Antippen nennt den Grund als Info-Text in der Meldezeile (A-28; Text ist Platzhalter) | [HM-16](../Module/HM-16_Kachel-Navigation.md) (Zustand deaktiviert mit Beschriftung) |
| Kachel „Waagen kalibrieren“ | Kachel-Navigation | öffnet [HS-27](HS-27_Waagen-Kalibrieren.md). Herkunft: RS-04 T4 Nr. 12: „Systemseite zu Kalibrierung von Waagen und Wägezellen.“; Raster Z2/S4 | [HM-16](../Module/HM-16_Kachel-Navigation.md) |

Rückverfolgung zu RS-04: Die drei Einzelkacheln (T4 Nr. 4, 7, 12) sind hier wiederzufinden; in HS-04 steht nur die Kachel „Waagen“ (A-36, OP-51). Die Seiten RS-14 „Einzelgewichte“ und RS-15 „Trend“ bleiben Unterseiten von HS-13 und sind nicht Teil von HS-42.

## Verwendete Module (IDs)
- Rahmen: [HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md) (enthält [HM-03](../Module/HM-03_Meldezeile.md)), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md)
- Inhalt: [HM-16](../Module/HM-16_Kachel-Navigation.md) (3 Kacheln, davon eine deaktiviert)

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- **Interaktion:** Antippen „Kontrollwaage“ → HS-13, „Waagen kalibrieren“ → HS-27. Navigation ändert keinen Maschinenzustand. Brotkrümel der Ziele: „Einstellung › Waagen › Kontrollwaage“ bzw. „… › Waagen kalibrieren“.
- **Kachel „Endkontrollwaage“:** deaktiviert, kein Seitenwechsel, kein Verlaufseintrag, kein Brotkrümelpfad. Fehlerfall/Hinweis: Antippen zeigt in der Meldezeile einen Info-Text (Platzhalter, z. B. „Endkontrollwaage nicht verfügbar“; Wortlaut offen). Existiert später ein Handbuchkapitel, bekommt die Kachel ein Ziel (neue ID ab HS-44, Navigation.md Abschnitt 6.3).
- **Kachelzustände:** Normal, Gedrückt (dickere Kontur), Deaktiviert (gestrichelt, Symbol und Text).
- **Zurück:** Seitenleiste „Zurück“ geht im Verlauf zurück (normal HS-04). Rückweg aus HS-13 und HS-27 ist HS-42; die Blättertasten in HS-27 (Waage ⇄ Waage) erzeugen keinen Verlaufseintrag (A-42).
- **Berechtigungen:** keine Mindestrolle für die Seite (Navigation.md 5.1); Kacheln ohne Schlüsselsymbol. Das Handbuch nennt für die Systemseite „Waagen kalibrieren“ keinen Seitenschutz (A-41); Eingabeschutz liegt auf Feld-/Tastenebene in HS-27.
- **Pop-ups:** keine. Bei offenem Pop-up Seite gesperrt (Navigation.md 4.2).
- **Hervorhebung Seitenleiste:** „Einstellungen“ aktiv.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-42-P01 | Brotkrümel | „Einstellung › Waagen“; „Einstellung“ antippbar (→ HS-04), „Waagen“ nur Anzeige | offen |
| HS-42-P02 | Kacheln | genau 3 Kacheln: Kontrollwaage, Endkontrollwaage, Waagen kalibrieren | offen |
| HS-42-P03 | Kachelziele | Kontrollwaage → HS-13; Waagen kalibrieren → HS-27 (Navigation.md Abschnitt 1) | offen |
| HS-42-P04 | Endkontrollwaage deaktiviert | Kachel gestrichelt, `Icon.Block` und Text „Nicht verfügbar“, kein Navigationsziel, kein Verlaufseintrag (OP-24, RS-04-P07) | offen |
| HS-42-P05 | Hinweis Endkontrollwaage | Antippen der deaktivierten Kachel zeigt Info-Text in der Meldezeile, keine Seitenänderung (A-28) | offen |
| HS-42-P06 | Rückverfolgung RS-04 | T4 Nr. 4, 7, 12 sind über HS-42 auffindbar; HS-04 enthält nur die Kachel „Waagen“ (RS-04-P09, OP-51) | offen |
| HS-42-P07 | Funktionsleiste | leer, aber sichtbar | offen |
| HS-42-P08 | Touch-Ziele | Kacheln Höhe mindestens `Size.Touch.Large`, Abstand mindestens `Size.Touch.Gap` | offen |
| HS-42-P09 | Zweiter Kanal | Deaktiviert über gestrichelte Kontur, Symbol und Text, nicht nur über Farbe (`Brush.Text.Disabled`); Gedrückt über dickere Kontur | offen |
| HS-42-P10 | Tokens | keine Hex- oder Pixelwerte; Maße und Farben nur über Tokens | offen |
| HS-42-P11 | Beschriftung | Texte aus `.resx` (`Nav_Scales_*`), ohne Trennstriche (OP-13) | offen |
| HS-42-P12 | Zurück | „Zurück“ aus HS-13 und HS-27 führt nach HS-42; von HS-42 nach HS-04 (bei Zugang über HS-04) | offen |

## Offene Punkte
- OP-24: Endkontrollwaage ohne Kapitel; deaktivierte Platzhalter-Kachel (A-12, A-36).
- OP-12: Zuordnung der Kachel „Waagen“ zu den Referenzseiten; OP-51: Entfall der Einzelkacheln in HS-04.
- OP-41: Anzahl der Waagen geräteabhängig (betrifft HS-27).
- OP-13: Kachelbeschriftung ohne Trennstrich; OP-21: Antippbarkeit der Brotkrümel.
