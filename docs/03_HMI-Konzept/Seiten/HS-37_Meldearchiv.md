# HS-37 – Meldearchiv

- Quelle: [RS-37](../../02_Referenz-Analyse/Seiten/RS-37_Meldearchiv.md) (Kapitel 37, Tabelle 47, Bild RS-37_01); Design: keine eigene Design-Seite (Seitenleiste „Meldungen“ des Designs führt auf [HS-38](HS-38_Meldeanzeige.md), von dort „Archiv“), Aufbau aus [Designsystem](../Designsystem.md) und den Modulen abgeleitet
- Navigationspfad: Einstellung › Systemeinstellungen › Meldearchiv (Zugang: [HS-35](HS-35_Systemeinstellungen.md), Kachel „Meldearchiv“; zweiter Zugang: HS-38, Funktionsleiste „Archiv“; Zurück-Ziel: Verlauf, also HS-35 oder HS-38; Seitenregister `MessageArchive` / `settings/system/archive`)

## Zweck

Anzeige aller gespeicherten Systemmeldungen der Maschine zur Nachverfolgung von Ereignissen, Störungen und Bedienvorgängen sowie zur Analyse und Dokumentation (Handbuch). Die Meldungen lassen sich filtern, zur externen Auswertung exportieren und (berechtigt) aus dem Archiv löschen.

## Aufbau (Bereiche, Layout)

Rahmen wie in HS-35: [HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md) mit [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md) (leer, aber sichtbar).

**Inhaltsbereich** (12-Spalten-Raster, Außenrand `Space.L`, Gutter `Space.M`): zwei Zeilen, Zeile 1 (1\*) Liste mit Scrolltasten, Zeile 2 (Höhe `Size.Touch.Large`) Tastenreihe.

```
Inhaltsbereich (12 Spalten)
+---------------------------------------------------------+----------+
| Spalten 1-11: Meldungsliste                             | Spalte 12|
| Zeit | Ereignis | Beschreibung                          | [ ^^ ]   |
| 05.05.2025 10:13:55 | KO | [Stoerung] 120: Stoerung ... | [ ^  ]   |
| ...                                                     | [ v  ]   |
| ... (Zeilen mit Symbol + Klassenwort + Flaechenton)     | [ vv ]   |
+---------------------------------------------------------+----------+
| [ Export ]   [ Liste leeren ]   [ Filter ]   [ Alle anzeigen ]      |
|  3 Spalten      3 Spalten        3 Spalten      3 Spalten           |
+---------------------------------------------------------------------+
Funktionsleiste unten: leer
```

- **Liste (Spalten 1 bis 11):** Tabellenkopf mit drei Spalten „Zeit“, „Ereignis“, „Beschreibung“ im Verhältnis 3\* : 1\* : 8\*; Zeilenhöhe mindestens `Size.Touch.Min`. Jede Zeile zeigt die Meldungsklasse zusätzlich zur Farbe als Symbol und Klassenwort (A-49).
- **Scrolltasten (Spalte 12):** vier Tasten untereinander (an den Anfang, eine Seite hoch, eine Seite runter, ans Ende), jede `Size.Touch.Default` × `Size.Touch.Default` oder größer, Abstand `Size.Touch.Gap`; an den Rändern deaktiviert (gestrichelt).
- **Tastenreihe (Zeile 2):** vier Aktionstasten gleich breit (je 3 Spalten) in der Reihenfolge der Referenz: „Export“, „Liste leeren“, „Filter“, „Alle anzeigen“. Die Funktionsleiste bleibt leer (Navigation.md 3.3: „Ohne eigene Tasten“); die Aktionen liegen wie im Bild direkt unter der Liste.
- Ist ein Filter aktiv, erscheint über der Liste (im Kopf der Listenzeile) der Hinweis „Filter aktiv“ mit `Icon.Status.Info` (Teil von [HM-25](../Module/HM-25_Meldungsliste.md)).

## Elemente

Spalte „Herkunft“ = Rückverfolgung zu [RS-37](../../02_Referenz-Analyse/Seiten/RS-37_Meldearchiv.md).

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Export | Aktionstaste, Schlüssel (`Icon.Key`) | Exportiert die aktuelle Meldeliste zur externen Auswertung (Format und Ziel offen, OP-49); bei aktivem Filter die gefilterte Liste (Annahme: „aktuelle Meldeliste“). | [HM-07](../Module/HM-07_Aktionstaste.md) | RS-37 Tabelle 47, Zeile 1 |
| Liste leeren | Aktionstaste, Schlüssel, zerstörerisch | Löscht alle gespeicherten Meldungen aus dem Archiv. Vorher Bestätigungs-Pop-up (A-40, OP-31). | [HM-07](../Module/HM-07_Aktionstaste.md); Bestätigung in [HM-14](../Module/HM-14_Popup-Rahmen.md) | Zeile 2 |
| Filter | Aktionstaste, ohne Schlüssel | Ermöglicht die gezielte Suche nach bestimmten Meldungen anhand von Kriterien wie Zeit oder Meldenummer. Öffnet direkt den Eingabedialog (Filter-Variante, ohne Eingabefeld, nicht gestapelt). | [HM-07](../Module/HM-07_Aktionstaste.md); [HM-13](../Module/HM-13_Eingabe-Pop-up.md) in [HM-14](../Module/HM-14_Popup-Rahmen.md) | Zeile 3 |
| Alle anzeigen | Aktionstaste (im Bild „Alle Anzeigen“), ohne Schlüssel | Hebt Filtereinstellungen auf und zeigt alle verfügbaren Meldungen an; ohne aktiven Filter deaktiviert. | [HM-07](../Module/HM-07_Aktionstaste.md) | Zeile 4 |
| Meldungstabelle (Zeit, Ereignis, Beschreibung) | Liste, Zeilen nach Klasse gekennzeichnet | Zeigt die Meldungen absteigend nach Zeit; Zeitformat „TT.MM.JJJJ hh:mm:ss“; Beschreibung beginnt mit der Meldungsnummer („NNN: Text“, die Sternchen der Referenz entfallen wie in der Meldezeile). Rot = Störung, Gelb = Hinweis/Status, Grün = Betriebsstatus, jeweils mit Symbol und Klassenwort. | [HM-25](../Module/HM-25_Meldungsliste.md) (Listenart Archive) | RS-37 „nur im Bild“, Zeile 1 |
| Scrolltasten (4 Stück) | Tasten | Blättern in der Liste: Anfang, Seite hoch, Seite runter, Ende (aus Symbolen abgeleitet); Wischen ist zusätzlich möglich. | [HM-25](../Module/HM-25_Meldungsliste.md) (`Icon.Scroll.Up`/`Icon.Scroll.Down`) | „nur im Bild“, Zeile 2 |
| Spalte „Ereignis“ (Wert „KO“) | Listenspalte | Nicht beschrieben (vermutlich „kommend“); Wert wird unverändert angezeigt (OP-49). | [HM-25](../Module/HM-25_Meldungsliste.md) | „nur im Bild“, Zeile 3 |
| Meldezeile, Kopfzeile, Funktionsleiste unten | Rahmen | Wie [HS-35](HS-35_Systemeinstellungen.md); Funktionsleiste ohne Tasten; Produktion, Einstellungen, Zurück und Anmeldestatus in der Seitenleiste. | [HM-03](../Module/HM-03_Meldezeile.md), [HM-02](../Module/HM-02_Kopfzeile.md), [HM-06](../Module/HM-06_Funktionsleiste.md), [HM-01](../Module/HM-01_Seitenleiste.md) | „nur im Bild“, Zeile 4 |
| Bestätigungs-Pop-up „Liste leeren“ (Ergänzung) | Pop-up | Warntext „Alle gespeicherten Meldungen werden gelöscht“, „Ja“ und „Abbrechen“. | [HM-14](../Module/HM-14_Popup-Rahmen.md) | Ergänzung zu RS-37 Zustände („Sicherheitsabfrage nicht beschrieben“) |

## Verwendete Module

- Rahmen: [HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md)
- Seite: [HM-25](../Module/HM-25_Meldungsliste.md), [HM-07](../Module/HM-07_Aktionstaste.md), [HM-13](../Module/HM-13_Eingabe-Pop-up.md), [HM-14](../Module/HM-14_Popup-Rahmen.md)

## Zustände und Interaktion

- **Berechtigung.** „Export“ und „Liste leeren“ tragen `Icon.Key`, „Filter“ und „Alle anzeigen“ nicht (RS-37). Rollenstufe offen (OP-25, Dummy). Ohne Rolle: `Icon.Lock`, Antippen öffnet das Benutzer-Pop-up; nach Anmeldung läuft die Aktion weiter.
- **Filter.** „Filter“ öffnet einen Eingabedialog für die Kriterien Meldenummer und Zeit (Format TT.MM.JJJJ hh:mm:ss); „Übernehmen“ filtert die Liste, „Abbrechen“ verwirft. Aktiver Filter: Hinweis „Filter aktiv“ mit `Icon.Status.Info` und Taste „Alle anzeigen“ aktiv. Treffer leer: Text „Keine Meldungen“.
- **Alle anzeigen.** Hebt den Filter auf; die Liste springt an den Anfang (neueste Meldung oben).
- **Liste leeren.** Bestätigungs-Pop-up; nach „Ja“ ist die Liste leer (Text „Keine Meldungen“), die Taste „Export“ bleibt bedienbar, liefert aber eine leere Liste. Abbrechen ohne Wirkung.
- **Export.** Meldung über Erfolg oder Fehler im Ergebnis-Pop-up (Annahme, Format offen); während des Exports ist die Taste deaktiviert.
- **Scrollen.** Am Listenanfang sind „an den Anfang“ und „Seite hoch“ deaktiviert, am Ende „Seite runter“ und „ans Ende“ (gestrichelte Kontur).
- **Fokus.** Im Bild hat die Taste „ans Ende“ einen blauen Rahmen (Fokus); im neuen HMI zeigt nur der Fokus eines bedienten Elements `Border.Thick`, kein dauerhaft markierter Scrollknopf.
- **Zeilenklassen.** Rot (Störung, führt zum Stopp), Gelb (Hinweis/Status), Grün (Betriebsstatus) werden als `Brush.Status.Error.Subtle`, `.Warning.Subtle`, `.Ok.Subtle` mit Symbol und Klassenwort dargestellt.
- **Pop-ups.** Nur eines gleichzeitig (Filter, Bestätigung, Ergebnis, Benutzer); Seitenleiste und Inhalt gesperrt, Schließen nur über „Abbrechen“/„Schließen“ (Navigation.md 4.2).
- **Zurück.** Seitenleiste „Zurück“ folgt dem Verlauf (HS-35 oder HS-38); Brotkrümel-Segment „Systemeinstellungen“ führt nach HS-35, „Einstellung“ nach HS-04.

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-37-P01 | Navigationspfad (RS-37-P01) | Brotkrümel „Einstellung › Systemeinstellungen › Meldearchiv“; Zugang aus HS-35 und aus HS-38 („Archiv“); Zurück folgt dem Verlauf | offen |
| HS-37-P02 | Listenspalten (RS-37-P02) | Spalten „Zeit“, „Ereignis“, „Beschreibung“ | offen |
| HS-37-P03 | Zeitformat und Meldungstext (RS-37-P03) | Zeit „TT.MM.JJJJ hh:mm:ss“; Beschreibung beginnt mit der Meldungsnummer (dreistellig, z. B. „120: …“; Sternchen der Referenz ersetzt wie in der Meldezeile) | offen |
| HS-37-P04 | Zeilenklassen (RS-37-P04) | Störung, Hinweis und Betriebsstatus unterscheidbar über Flächenton, Symbol und Klassenwort | offen |
| HS-37-P05 | Scrolltasten (RS-37-P05) | Vier Tasten (Anfang, hoch, runter, Ende) rechts neben der Liste; an den Rändern deaktiviert | offen |
| HS-37-P06 | Taste Export (RS-37-P06) | Exportiert die aktuelle Meldeliste zur externen Auswertung; trägt `Icon.Key` | offen |
| HS-37-P07 | Taste Liste leeren (RS-37-P07) | Löscht nach Bestätigung alle gespeicherten Meldungen; trägt `Icon.Key`; „Abbrechen“ ändert nichts | offen |
| HS-37-P08 | Taste Filter (RS-37-P08) | Öffnet den Filterdialog für Zeit oder Meldenummer; ohne Schlüsselsymbol; „Übernehmen“ filtert, „Filter aktiv“ sichtbar | offen |
| HS-37-P09 | Taste Alle anzeigen (RS-37-P09) | Filter aufgehoben, alle Meldungen sichtbar; ohne Filter deaktiviert | offen |
| HS-37-P10 | Untere Leiste (RS-37-P10) | Funktionsleiste sichtbar, aber ohne Tasten; Produktion, Einstellungen, Zurück, Anmeldestatus in der Seitenleiste | offen |
| HS-37-P11 | Berechtigung | Export und Liste leeren ohne Rolle mit `Icon.Lock`; Tippen öffnet das Benutzer-Pop-up bzw. nennt „Berechtigung erforderlich: <Rolle>“ | offen |
| HS-37-P12 | Leeres Archiv | Nach „Liste leeren“ erscheint der Text „Keine Meldungen“ | offen |
| HS-37-P13 | Touch-Ziele | Tasten der Tastenreihe mindestens `Size.Touch.Large` hoch, Scrolltasten mindestens `Size.Touch.Default`, Listenzeilen mindestens `Size.Touch.Min`, Abstand `Size.Touch.Gap` | offen |
| HS-37-P14 | Zweiter Kanal | Meldungsklassen mit `Icon.Status.*` und Wort, Filterhinweis mit Symbol und Text, Randzustand der Scrolltasten gestrichelt; kein Zustand nur über Farbe | offen |
| HS-37-P15 | Tokens | Keine Hex- und Pixelwerte im Seitenaufbau; nur Tokens des Designsystems | offen |

## Offene Punkte

- OP-25 (im Seiten-Index für RS-37 nicht geführt, hier ergänzt): Rollenstufe der Schlüssel-Tasten Export und Liste leeren nicht beschrieben (Dummy).
- OP-30: Eingabe-/Filterdialog nicht dokumentiert (Annahme: Variante von HM-13).
- OP-31: Bestätigung bei „Liste leeren“ nicht beschrieben (Ergänzung, A-40).
- OP-38: Zugang über Seitenleiste „Meldungen“ und Taste „Archiv“ (Design/Annahme).
- OP-40: Filterverhalten und Listenverhalten (Sortierung, Archivgröße).
- OP-49: Spalte „Ereignis“ (Wert „KO“), Exportformat und -ziel.
