# Konzept – Neues HMI (Gesamtbeschreibung und Spezifikation für Meilenstein 2)

Phase 3, Meilenstein 1. Dieses Dokument führt die Teilkonzepte zu einer kohärenten Beschreibung des neuen HMI zusammen und ist die Spezifikation für die WPF-Umsetzung (C# / .NET 8 / MVVM) in Meilenstein 2. Es wiederholt die Teilkonzepte nicht, sondern ordnet sie ein und verweist auf sie: [Designsystem](Designsystem.md) (Farben, Typografie, Maße, Zustände), [Navigation](Navigation.md) (Baum, Brotkrümel, Seitenregister, Dienste), [Modulliste](Module/Modulliste.md) und die Moduldateien `HM-01` bis `HM-38`, die Seitendateien `HS-01` bis `HS-43`. Quellen und Regeln: [Agent.md](../../Agent.md), [Task.md](../../Task.md), [Design-Dokumentation](../01_Design-Analyse/Design-Dokumentation.md), [Referenz-Übersicht](../02_Referenz-Analyse/Referenz-Uebersicht.md), [Plan_M1](../00_Plan/Plan_M1.md), [Annahmen](../00_Plan/Annahmen.md) (A-01 bis A-79), [Offene Punkte](../00_Plan/Offene-Punkte.md) (OP-01 bis OP-66).

Stand: 2026-11-04. Die Zahlen (43 Seiten, 38 Module, Typen, Links) sind per Skript belegt (Abschnitt 8.2, Prüfpunkte KON-P01 bis KON-P14). Bei Widerspruch zwischen diesem Dokument und einer Seiten- oder Moduldatei gilt die Seiten- bzw. Moduldatei; Abweichungen stehen in Abschnitt „Hinweise zur Konsistenz“.

## Inhalt

1. Ziel und Leitprinzipien
2. Rahmenlayout und Rahmenmodule
3. Seitenübersicht (43 Seiten, gruppiert nach Navigationsbaum)
4. Modulkatalog (HM-01 bis HM-38)
5. Querschnittsthemen
6. Technische Umsetzung
7. Umsetzungsreihenfolge und Arbeitspakete für Meilenstein 2
8. Prüfstrategie M2 und Übergabe an M3
9. Annahmen und Offene Punkte
10. Hinweise zur Konsistenz
11. Prüfpunkte dieses Dokuments

## 1. Ziel und Leitprinzipien

**Ziel.** Die Maschinen-HMI der APA-TEC GmbH (Verpackungsmaschinen) wird fachlich vollständig aus dem bestehenden HMI (Referenzhandbuch, 39 Seiten) in ein modernes, touchbedienbares Design übertragen. Das Ergebnis dieses Meilensteins ist die Beschreibung, nicht der Code: 43 Seiten (`HS`) aus 38 wiederverwendbaren Modulen (`HM`), ein Designsystem und eine Navigation. Die Maschinenanbindung ist nicht Teil des Projekts; Daten kommen in Meilenstein 2 aus Dummy-Diensten (Abschnitt 6.6).

**Umfang.**

| Größe | Anzahl | Herkunft |
|---|---|---|
| Referenzseiten (`RS`) | 39 | Kapitel der Ebene 2 des Handbuchs (A-01), einschließlich der Pop-ups Produktionszähler und Maschinengeschwindigkeit |
| Design-Seiten (`DS`) | 5 | Produktion, Einstellungen, Heißleim, Dosierer, Kartonzuführung (PowerPoint-Entwurf, nicht final) |
| Neue Seiten (`HS`) | 43 | `HS-01` bis `HS-39` = `RS-01` bis `RS-39` (A-46); `HS-40` bis `HS-43` Zusatzseiten (A-33) |
| Design-Module (`DM`) / Referenz-Module (`RM`) | 22 / 36 | zusammengeführt zu 38 `HM` (A-45, A-59) |

**Konfliktregeln** (Agent.md Abschnitt 2), angewandt in allen Teilkonzepten:

1. **Funktion und Fachlogik** folgen der Referenz. Beispiel: Die Tasten „Zuführung Papier“, „Zuführung Karton“ und „Heizungen“ auf `HS-01` schalten Funktionen und navigieren nicht (A-38), obwohl der Entwurf Navigation vermuten ließ.
2. **Layout, Navigation und Optik** folgen dem Design, soweit mit den Design-Vorgaben (Agent.md Abschnitt 6) vereinbar. Beispiele: Seitenleiste statt der Fußleisten-Tasten der Referenz (A-35), Brotkrümel nach dem Design (A-34), Kachelmenü `HS-04` mit 16 Plätzen (A-36).
3. **Lücken und Widersprüche** werden nicht erfunden, sondern als Annahme (`Annahmen.md`) und offener Punkt (`Offene-Punkte.md`) geführt. Das gilt für Seiten ohne Design (38 von 43), Design-Elemente ohne Referenz (Rezept, Schichtplan, Sprache, Benutzer) und Referenz-Elemente ohne Beschreibung (Eingabe-Pop-up, Suche, Bestätigungen).

**Leitprinzipien (ISA-101-Grundsätze, [Designsystem](Designsystem.md) Einleitung und Abschnitte 1 bis 5):**

| Nr | Prinzip | Wirkung im Konzept |
|---|---|---|
| 1 | Ruhiger, neutraler Grund; der Normalzustand ist grau | Neutralpalette; Betriebsart „Produktion“ neutral; keine dauerhaft grüne Fläche |
| 2 | Farbe nur für Status und Alarm | fünf Status (Ok, Warnung, Fehler, Info, Inaktiv); Rot nur Fehler, Gelb nur Warnung, Grün nur „erfüllt“; Ein-Zustand von Tasten neutral (A-31) |
| 3 | Zustände nie nur über Farbe | jeder Zustand hat einen zweiten Kanal: Symbol, Wort, Form oder Kontur (Abschnitt 5.2) |
| 4 | Große Touch-Ziele | mindestens 48 px, Standard 64 px, Kachel 96 px, Abstand mindestens 16 px |
| 5 | Flach, klare Hierarchie | keine 3D-Fasen, Verläufe oder Schatten als Informationsträger; Tiefe nur über Flächentöne |
| 6 | Zentrale Ressourcen | Farben, Schriften, Maße nur aus `ResourceDictionary`; Hell- und Dunkelthema mit identischen Schlüsseln |
| 7 | Auflösung 1920 × 1080, skalierbar | Grid mit Stern-Proportionen, 12-Spalten-Raster im Inhaltsbereich, keine festen Pixelpositionen |
| 8 | Kontrast | Text und Symbole mindestens 4,5 : 1, Konturen und Grafik mindestens 3 : 1 (WCAG-Berechnung im Designsystem) |

Aus den Prinzipien folgen drei Vorgaben für die Umsetzung, die in M2 prüfbar sind: keine Literale (Farben, Maße, Texte) in Views und Controls, kein Code-behind in Views, jeder Zustand mit zweitem Kanal.

## 2. Rahmenlayout und Rahmenmodule

Jede Vollseite hat denselben Rahmen (Navigation.md Grundsatz 1, [Designsystem](Designsystem.md) 3.2). Er wird einmal im Hauptfenster aufgebaut, die Seiten füllen nur den Inhaltsbereich.

```
+---------+------------------------------------------------------------+
| Seiten- | Kopfzeile: Logo | Meldezeile | Betriebsart | Uhr/Datum     |  4*
| leiste  +------------------------------------------------------------+
| HM-01   | Brotkrümel HM-04                | Geschw. | Winkel (HM-05) |  3*
| (3*)    +------------------------------------------------------------+
|         |                                                            |
|         |             Inhaltsbereich (Seite, 12 Spalten)             | 34*
|         |                                                            |
|         +------------------------------------------------------------+
|         | Untere Funktionsleiste HM-06                               |  4*
+---------+------------------------------------------------------------+
   3*                              37*
```

Bei 1920 × 1080 ergibt das Seitenleiste 144 px, Kopfzeile 96 px, Brotkrümel-/Kennzahlzeile 72 px, Inhalt 816 px, Funktionsleiste 96 px (Prüfpunkt DSY-P08). Die Kopfzeile teilt sich 12\* : 13\* : 6\* : 4\* (Logo, Meldezeile, Betriebsart, Uhr), die Kennzahlzeile 56\* : 10\* : 10\* (Brotkrümel, Geschwindigkeit, Winkel). Das Hauptfenster skaliert bei anderer Größe proportional (`Viewbox`, Seitenverhältnis 16 : 9).

| Modul | Aufgabe im Rahmen | Navigationsfunktion | Besonderheiten |
|---|---|---|---|
| [HM-01](Module/HM-01_Seitenleiste.md) Seitenleiste | Benutzerkreis (Name, Rolle) oben; Home, Einstellungen, Meldungen (mit Zähler 0 bis 99, ab 100 „99+“); ganz unten Zurück | Home → `HS-01` (Verlauf leer); Einstellungen → `HS-04` (Verlauf `[HS-01]`); Meldungen → `HS-38`; Zurück → Verlauf; Benutzerkreis → Benutzer-Pop-up | ersetzt das gelbe Schloss und die Fußleisten-Tasten der Referenz (A-35); in beiden Themen dunkel und neutral; in `HS-24` ausgeblendet; hinter Pop-ups gesperrt |
| [HM-02](Module/HM-02_Kopfzeile.md) Kopfzeile | Logo (je Thema eine Variante), Meldezeile ([HM-03](Module/HM-03_Meldezeile.md)), Betriebsart, Uhrzeit HH:mm:ss und Datum | nur Anzeige | Betriebsart „Produktion“ neutral, „Service“ als Warnstatus (A-48); in `HS-24` Variante ohne Meldezeile (`ShowMessageLine = false`) |
| [HM-03](Module/HM-03_Meldezeile.md) Meldezeile | wichtigste aktuelle Meldung „NNN: Text“ mit Klasse, Symbol und Wort; bei mehreren Meldungen die höchste Priorität mit „+ n“; ohne Meldung neutral „Keine Meldung“ | Antippen öffnet `HS-38` (auf `HS-38` wirkungslos) | Klassen Betriebsstatus, Hinweis, Störung auf Ok, Warnung, Fehler abgebildet (A-49); nennt auch den Grund deaktivierter Elemente (A-28) |
| [HM-04](Module/HM-04_Brotkruemel-Navigation.md) Brotkrümel | kanonischer Pfad der Seite (nicht der Verlauf), Wurzel „Einstellung“ bzw. „Produktion“ | alle Segmente außer dem letzten springen zur Ebene (`GoToAncestor`) | höchstens 4 Segmente; Objektkennung („1“/„2“, „HD1“/„HD2“, „ND“) und dynamische Segmente (`HS-31`, `HS-34`); auf `HS-24` ausgeblendet |
| [HM-05](Module/HM-05_Kennzahl-Kachel.md) Kennzahl-Kachel | im Rahmen „Geschwindigkeit“ (1/min) und „Maschinenwinkel“ (°); auf Seiten weitere Kennzahlen | Geschwindigkeit öffnet `HS-03` (Pop-up, A-38); Winkel nur Anzeige | Mindestbreite 224 px, Wert 36 px |
| [HM-06](Module/HM-06_Funktionsleiste.md) Funktionsleiste | nur seitenspezifische Tasten ([HM-07](Module/HM-07_Aktionstaste.md), [HM-08](Module/HM-08_Zustandstaste-Umschalter.md), [HM-19](Module/HM-19_Blaettertasten.md)), links beginnend | Tasten navigieren nur, wenn sie ein Ziel haben (z. B. „Temperatur“, „Übersicht“, „Archiv“) | höchstens 5 Tasten plus Überlauf „Mehr“; Tasten mindestens 224 px breit; leere Leiste bleibt sichtbar; in `HS-24` ausgeblendet |

**Rahmenvarianten.**

| Fall | Seiten | Rahmenverhalten |
|---|---|---|
| Vollseite | 37 Seiten (ohne Pop-ups und Zusatz: siehe Abschnitt 3) | alle Rahmenmodule `HM-01` bis `HM-06` |
| Pop-up | `HS-02`, `HS-03` | Rahmen der Hintergrundseite bleibt sichtbar, ist hinter dem Scrim (50 % Schwarz im Hellthema, 60 % im Dunkelthema) gesperrt; Meldezeile und Kopfzeile bleiben Anzeige (Navigation.md 4.2) |
| Vollbild | `HS-24` Bildschirm reinigen | nur Kopfzeile ohne Meldezeile ([HM-02](Module/HM-02_Kopfzeile.md)); Seitenleiste, Brotkrümel, Kennzahlen, Meldezeile und Funktionsleiste ausgeblendet; die Seite schließt nach Ablauf selbst |

Die Rahmentasten der Referenz (Produktion, Einstellungen, Zurück, Schloss) liegen in der Seitenleiste; die Funktionsleiste enthält nur Tasten der jeweiligen Seite (A-35). Die Zuordnung „Funktionsleisten-Tasten je Seitentyp“ steht in Navigation.md 3.3.

## 3. Seitenübersicht

Alle 43 Seiten, gruppiert nach dem Navigationsbaum ([Navigation](Navigation.md) Abschnitt 1). Spalten:

- **Typ:** Vollseite (Rahmen, Navigation, Verlauf), Pop-up (modal, nicht im Verlauf) oder Zusatz (Seite ohne `RS`-Entsprechung: `HS-40` bis `HS-43`, A-33). Gezählt: Pop-up 2, Vollseite 37, Zusatz 4.
- **Design-Vorlage:** „ja“ nur für Seiten, die ein Design-Screenshot direkt zeigt (A-46: `DS-01` = `HS-01`, `DS-02` = `HS-04`, `DS-03` = `HS-07`, `DS-04` = `HS-41`, `DS-05` = `HS-06`; 5 von 43). Bei „nein“ ist der Aufbau aus Designsystem, Rastern und Modulen abgeleitet; einzelne Seiten übernehmen Teilmuster der Design-Seiten (Quellzeile der Seite).
- **Hauptmodule:** die Module aus „Verwendete Module“ der Seitendatei ohne die Rahmenmodule `HM-01` bis `HM-06`, die auf jeder Vollseite stehen. Ausnahmen: `HS-02` führt [HM-05](Module/HM-05_Kennzahl-Kachel.md) als Inhalt, `HS-24` führt [HM-02](Module/HM-02_Kopfzeile.md) (Vollbild-Variante). Module, die nur über ein Kompositmodul auf die Seite kommen, stehen nicht in der Spalte; [Modulliste](Module/Modulliste.md) zählt sie mit.
- **Brotkrümel:** kanonischer Pfad nach Navigation.md Abschnitt 2; Zugänge, Zurück-Ziele und Seitenschlüssel stehen dort und in Abschnitt 5.1 der Navigation.

Die Gruppen folgen dem Baum; `HS-23` Regulierung hängt in der Navigation unter `HS-04` und ist zusätzlich aus `HS-11` und `HS-19` erreichbar, steht hier bei den Dosierern.

### 3.1 Rahmen und Querseite (auf jeder Seite erreichbar)

| HS-ID | Name | Typ | Design-Vorlage | Hauptmodule | Brotkrümel | Link |
|---|---|---|---|---|---|---|
| HS-38 | Meldeanzeige | Vollseite (Querseite) | nein | [HM-07](Module/HM-07_Aktionstaste.md), [HM-25](Module/HM-25_Meldungsliste.md) | Meldungen | [HS-38](Seiten/HS-38_Meldeanzeige.md) |

### 3.2 Produktion

| HS-ID | Name | Typ | Design-Vorlage | Hauptmodule | Brotkrümel | Link |
|---|---|---|---|---|---|---|
| HS-01 | Produktion | Vollseite | ja (DS-01) | [HM-07](Module/HM-07_Aktionstaste.md), [HM-08](Module/HM-08_Zustandstaste-Umschalter.md), [HM-11](Module/HM-11_Anzeigefeld.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-15](Module/HM-15_Gruppenbereich.md), [HM-16](Module/HM-16_Kachel-Navigation.md) | Produktion | [HS-01](Seiten/HS-01_Produktion.md) |
| HS-02 | Produktionszähler | Pop-up | nein | [HM-05](Module/HM-05_Kennzahl-Kachel.md), [HM-07](Module/HM-07_Aktionstaste.md), [HM-11](Module/HM-11_Anzeigefeld.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-33](Module/HM-33_Zaehlerzeile.md) | Produktion (Brotkrümel der Hintergrundseite bleibt; Pop-up-Titel „Produktionszähler“) | [HS-02](Seiten/HS-02_Produktionszaehler.md) |
| HS-03 | Maschinengeschwindigkeit | Pop-up | nein | [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](Module/HM-13_Eingabe-Pop-up.md), [HM-14](Module/HM-14_Popup-Rahmen.md) | Produktion (Brotkrümel der Hintergrundseite bleibt; Pop-up-Titel „Maschinengeschwindigkeit“) | [HS-03](Seiten/HS-03_Maschinengeschwindigkeit.md) |
| HS-43 | Schichtplan | Zusatz (Platzhalter) | nein | [HM-15](Module/HM-15_Gruppenbereich.md), [HM-27](Module/HM-27_Hinweis-Textfeld.md) | Produktion › Schichtplan | [HS-43](Seiten/HS-43_Schichtplan.md) |

### 3.3 Einstellungen (Startseite)

| HS-ID | Name | Typ | Design-Vorlage | Hauptmodule | Brotkrümel | Link |
|---|---|---|---|---|---|---|
| HS-04 | Einstellungen | Vollseite | ja (DS-02) | [HM-07](Module/HM-07_Aktionstaste.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-15](Module/HM-15_Gruppenbereich.md), [HM-16](Module/HM-16_Kachel-Navigation.md) | Einstellung | [HS-04](Seiten/HS-04_Einstellungen.md) |

### 3.4 Einstellung › Zuführungen

| HS-ID | Name | Typ | Design-Vorlage | Hauptmodule | Brotkrümel | Link |
|---|---|---|---|---|---|---|
| HS-40 | Zuführungen | Zusatz (Zwischenseite) | nein | [HM-16](Module/HM-16_Kachel-Navigation.md) | Einstellung › Zuführungen | [HS-40](Seiten/HS-40_Zufuehrungen.md) |
| HS-05 | Zuführung Papier | Vollseite | nein | [HM-09](Module/HM-09_Status-LED.md), [HM-11](Module/HM-11_Anzeigefeld.md), [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](Module/HM-13_Eingabe-Pop-up.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-15](Module/HM-15_Gruppenbereich.md), [HM-27](Module/HM-27_Hinweis-Textfeld.md) | Einstellung › Zuführungen › Papier | [HS-05](Seiten/HS-05_Zufuehrung-Papier.md) |
| HS-06 | Zuführung Karton | Vollseite | ja (DS-05) | [HM-07](Module/HM-07_Aktionstaste.md), [HM-08](Module/HM-08_Zustandstaste-Umschalter.md), [HM-11](Module/HM-11_Anzeigefeld.md), [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](Module/HM-13_Eingabe-Pop-up.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-15](Module/HM-15_Gruppenbereich.md), [HM-31](Module/HM-31_Leimspuren-Grafik.md) | Einstellung › Zuführungen › Karton | [HS-06](Seiten/HS-06_Zufuehrung-Karton.md) |
| HS-07 | Heißleim Nordson | Vollseite | ja (DS-03) | [HM-07](Module/HM-07_Aktionstaste.md), [HM-08](Module/HM-08_Zustandstaste-Umschalter.md), [HM-09](Module/HM-09_Status-LED.md), [HM-10](Module/HM-10_Fortschrittsbalken.md), [HM-11](Module/HM-11_Anzeigefeld.md), [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](Module/HM-13_Eingabe-Pop-up.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-15](Module/HM-15_Gruppenbereich.md), [HM-27](Module/HM-27_Hinweis-Textfeld.md) | Einstellung › Zuführungen › Heißleim | [HS-07](Seiten/HS-07_Heissleim-Nordson.md) |
| HS-08 | Heißleim Parameter | Vollseite | nein | [HM-08](Module/HM-08_Zustandstaste-Umschalter.md), [HM-11](Module/HM-11_Anzeigefeld.md), [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](Module/HM-13_Eingabe-Pop-up.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-15](Module/HM-15_Gruppenbereich.md), [HM-28](Module/HM-28_Temperaturzonen-Zeile.md) | Einstellung › Zuführungen › Heißleim › Temperatur | [HS-08](Seiten/HS-08_Heissleim-Parameter.md) |
| HS-09 | Heißleim Druck | Vollseite | nein | [HM-11](Module/HM-11_Anzeigefeld.md), [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](Module/HM-13_Eingabe-Pop-up.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-15](Module/HM-15_Gruppenbereich.md) | Einstellung › Zuführungen › Heißleim › Druck | [HS-09](Seiten/HS-09_Heissleim-Druck.md) |
| HS-10 | Zeitschaltuhr | Vollseite | nein | [HM-07](Module/HM-07_Aktionstaste.md), [HM-08](Module/HM-08_Zustandstaste-Umschalter.md), [HM-11](Module/HM-11_Anzeigefeld.md), [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](Module/HM-13_Eingabe-Pop-up.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-18](Module/HM-18_Auswahlfeld-Pfeiltasten.md), [HM-27](Module/HM-27_Hinweis-Textfeld.md), [HM-29](Module/HM-29_Wochen-Zeitplan.md), [HM-30](Module/HM-30_Zeitplan-Eintrag-Pop-up.md) | Einstellung › Zuführungen › Heißleim › Zeitplan | [HS-10](Seiten/HS-10_Zeitschaltuhr.md) |

### 3.5 Einstellung › Schließmaschine

| HS-ID | Name | Typ | Design-Vorlage | Hauptmodule | Brotkrümel | Link |
|---|---|---|---|---|---|---|
| HS-16 | Schließmaschine | Vollseite | nein | [HM-07](Module/HM-07_Aktionstaste.md), [HM-08](Module/HM-08_Zustandstaste-Umschalter.md), [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](Module/HM-13_Eingabe-Pop-up.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-15](Module/HM-15_Gruppenbereich.md), [HM-24](Module/HM-24_Nocken-Parameterzeile.md), [HM-27](Module/HM-27_Hinweis-Textfeld.md) | Einstellung › Schließmaschine | [HS-16](Seiten/HS-16_Schliessmaschine.md) |
| HS-17 | Motorparameter (Schließmaschine) | Vollseite | nein | [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](Module/HM-13_Eingabe-Pop-up.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-15](Module/HM-15_Gruppenbereich.md), [HM-21](Module/HM-21_Motorparameter-Karte.md) | Einstellung › Schließmaschine › Motorparameter | [HS-17](Seiten/HS-17_Motorparameter-Schliessmaschine.md) |
| HS-18 | Gewichtskorrektur (Schließmaschine) | Vollseite | nein | [HM-07](Module/HM-07_Aktionstaste.md), [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](Module/HM-13_Eingabe-Pop-up.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-15](Module/HM-15_Gruppenbereich.md), [HM-22](Module/HM-22_Gewichtskorrektur-Tabelle.md), [HM-27](Module/HM-27_Hinweis-Textfeld.md) | Einstellung › Schließmaschine › Gewichtskorrektur | [HS-18](Seiten/HS-18_Gewichtskorrektur-Schliessmaschine.md) |

### 3.6 Einstellung › Dosierer (und Regulierung)

| HS-ID | Name | Typ | Design-Vorlage | Hauptmodule | Brotkrümel | Link |
|---|---|---|---|---|---|---|
| HS-41 | Dosierer-Übersicht | Zusatz (Übersicht) | ja (DS-04) | [HM-07](Module/HM-07_Aktionstaste.md), [HM-08](Module/HM-08_Zustandstaste-Umschalter.md), [HM-09](Module/HM-09_Status-LED.md), [HM-10](Module/HM-10_Fortschrittsbalken.md), [HM-11](Module/HM-11_Anzeigefeld.md), [HM-15](Module/HM-15_Gruppenbereich.md), [HM-17](Module/HM-17_Titelzeile.md), [HM-20](Module/HM-20_Dosierer-Karte.md), [HM-27](Module/HM-27_Hinweis-Textfeld.md) | Einstellung › Dosierer | [HS-41](Seiten/HS-41_Dosierer-Uebersicht.md) |
| HS-11 | Hauptdosierer 1 & 2 | Vollseite | nein | [HM-07](Module/HM-07_Aktionstaste.md), [HM-08](Module/HM-08_Zustandstaste-Umschalter.md), [HM-09](Module/HM-09_Status-LED.md), [HM-10](Module/HM-10_Fortschrittsbalken.md), [HM-11](Module/HM-11_Anzeigefeld.md), [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](Module/HM-13_Eingabe-Pop-up.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-15](Module/HM-15_Gruppenbereich.md), [HM-17](Module/HM-17_Titelzeile.md), [HM-19](Module/HM-19_Blaettertasten.md), [HM-20](Module/HM-20_Dosierer-Karte.md), [HM-27](Module/HM-27_Hinweis-Textfeld.md) | Einstellung › Dosierer › Hauptdosierer | [HS-11](Seiten/HS-11_Hauptdosierer-1-und-2.md) |
| HS-12 | Motorparameter (Hauptdosierer) | Vollseite | nein | [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](Module/HM-13_Eingabe-Pop-up.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-15](Module/HM-15_Gruppenbereich.md), [HM-17](Module/HM-17_Titelzeile.md), [HM-19](Module/HM-19_Blaettertasten.md), [HM-21](Module/HM-21_Motorparameter-Karte.md) | Einstellung › Dosierer › Hauptdosierer › Motorparameter | [HS-12](Seiten/HS-12_Motorparameter.md) |
| HS-19 | Nachdosierer | Vollseite | nein | [HM-07](Module/HM-07_Aktionstaste.md), [HM-08](Module/HM-08_Zustandstaste-Umschalter.md), [HM-09](Module/HM-09_Status-LED.md), [HM-10](Module/HM-10_Fortschrittsbalken.md), [HM-11](Module/HM-11_Anzeigefeld.md), [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](Module/HM-13_Eingabe-Pop-up.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-15](Module/HM-15_Gruppenbereich.md), [HM-20](Module/HM-20_Dosierer-Karte.md), [HM-27](Module/HM-27_Hinweis-Textfeld.md) | Einstellung › Dosierer › Nachdosierer | [HS-19](Seiten/HS-19_Nachdosierer.md) |
| HS-20 | Motorparameter (Nachdosierer) | Vollseite | nein | [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](Module/HM-13_Eingabe-Pop-up.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-15](Module/HM-15_Gruppenbereich.md), [HM-21](Module/HM-21_Motorparameter-Karte.md) | Einstellung › Dosierer › Nachdosierer › Motorparameter | [HS-20](Seiten/HS-20_Motorparameter.md) |
| HS-21 | Gewichtskorrektur (Nachdosierer) | Vollseite | nein | [HM-07](Module/HM-07_Aktionstaste.md), [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](Module/HM-13_Eingabe-Pop-up.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-15](Module/HM-15_Gruppenbereich.md), [HM-22](Module/HM-22_Gewichtskorrektur-Tabelle.md), [HM-27](Module/HM-27_Hinweis-Textfeld.md) | Einstellung › Dosierer › Nachdosierer › Gewichtskorrektur | [HS-21](Seiten/HS-21_Gewichtskorrektur.md) |
| HS-23 | Regulierung | Vollseite | nein | [HM-07](Module/HM-07_Aktionstaste.md), [HM-08](Module/HM-08_Zustandstaste-Umschalter.md), [HM-11](Module/HM-11_Anzeigefeld.md), [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](Module/HM-13_Eingabe-Pop-up.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-15](Module/HM-15_Gruppenbereich.md), [HM-35](Module/HM-35_Regulierungs-Parameterblock.md) | Einstellung › Regulierung | [HS-23](Seiten/HS-23_Regulierung.md) |

### 3.7 Einstellung › Waagen

| HS-ID | Name | Typ | Design-Vorlage | Hauptmodule | Brotkrümel | Link |
|---|---|---|---|---|---|---|
| HS-42 | Waagen | Zusatz (Zwischenseite) | nein | [HM-16](Module/HM-16_Kachel-Navigation.md) | Einstellung › Waagen | [HS-42](Seiten/HS-42_Waagen.md) |
| HS-13 | Kontrollwaage | Vollseite | nein | [HM-07](Module/HM-07_Aktionstaste.md), [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](Module/HM-13_Eingabe-Pop-up.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-15](Module/HM-15_Gruppenbereich.md) | Einstellung › Waagen › Kontrollwaage | [HS-13](Seiten/HS-13_Kontrollwaage.md) |
| HS-14 | Einzelgewichte | Vollseite | nein | [HM-07](Module/HM-07_Aktionstaste.md), [HM-08](Module/HM-08_Zustandstaste-Umschalter.md), [HM-09](Module/HM-09_Status-LED.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-37](Module/HM-37_Wertegitter.md) | Einstellung › Waagen › Kontrollwaage › Einzelgewichte | [HS-14](Seiten/HS-14_Einzelgewichte.md) |
| HS-15 | Trend | Vollseite | nein | [HM-26](Module/HM-26_Diagramm.md) | Einstellung › Waagen › Kontrollwaage › Trend | [HS-15](Seiten/HS-15_Trend.md) |
| HS-27 | Waagen Kalibrieren | Vollseite | nein | [HM-07](Module/HM-07_Aktionstaste.md), [HM-11](Module/HM-11_Anzeigefeld.md), [HM-15](Module/HM-15_Gruppenbereich.md), [HM-17](Module/HM-17_Titelzeile.md), [HM-18](Module/HM-18_Auswahlfeld-Pfeiltasten.md), [HM-19](Module/HM-19_Blaettertasten.md), [HM-27](Module/HM-27_Hinweis-Textfeld.md) | Einstellung › Waagen › Waagen kalibrieren | [HS-27](Seiten/HS-27_Waagen-Kalibrieren.md) |

### 3.8 Einstellung › Heizungen, Maschinenfunktionen

| HS-ID | Name | Typ | Design-Vorlage | Hauptmodule | Brotkrümel | Link |
|---|---|---|---|---|---|---|
| HS-22 | Heizungen | Vollseite | nein | [HM-07](Module/HM-07_Aktionstaste.md), [HM-08](Module/HM-08_Zustandstaste-Umschalter.md), [HM-09](Module/HM-09_Status-LED.md), [HM-11](Module/HM-11_Anzeigefeld.md), [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](Module/HM-13_Eingabe-Pop-up.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-27](Module/HM-27_Hinweis-Textfeld.md), [HM-28](Module/HM-28_Temperaturzonen-Zeile.md) | Einstellung › Heizungen | [HS-22](Seiten/HS-22_Heizungen.md) |
| HS-24 | Bildschirm reinigen | Vollseite (Vollbild) | nein | [HM-02](Module/HM-02_Kopfzeile.md), [HM-10](Module/HM-10_Fortschrittsbalken.md), [HM-27](Module/HM-27_Hinweis-Textfeld.md) | Einstellung › Bildschirm reinigen (Brotkrümel ausgeblendet, Vollbild) | [HS-24](Seiten/HS-24_Bildschirm-reinigen.md) |
| HS-25 | Nocken | Vollseite | nein | [HM-07](Module/HM-07_Aktionstaste.md), [HM-09](Module/HM-09_Status-LED.md), [HM-11](Module/HM-11_Anzeigefeld.md), [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](Module/HM-13_Eingabe-Pop-up.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-18](Module/HM-18_Auswahlfeld-Pfeiltasten.md), [HM-19](Module/HM-19_Blaettertasten.md), [HM-24](Module/HM-24_Nocken-Parameterzeile.md) | Einstellung › Nockenschaltwerk | [HS-25](Seiten/HS-25_Nocken.md) |
| HS-26 | Nockenübersicht | Vollseite | nein | [HM-09](Module/HM-09_Status-LED.md), [HM-19](Module/HM-19_Blaettertasten.md), [HM-23](Module/HM-23_Nockentabelle.md) | Einstellung › Nockenschaltwerk › Übersicht | [HS-26](Seiten/HS-26_Nockenuebersicht.md) |
| HS-28 | Packungsregister | Vollseite | nein | [HM-27](Module/HM-27_Hinweis-Textfeld.md), [HM-32](Module/HM-32_Packungsregister-Grafik.md) | Einstellung › Packungsregister | [HS-28](Seiten/HS-28_Packungsregister.md) |
| HS-29 | Produktionsstatistik | Vollseite | nein | [HM-18](Module/HM-18_Auswahlfeld-Pfeiltasten.md), [HM-26](Module/HM-26_Diagramm.md) | Einstellung › Produktionsstatistik | [HS-29](Seiten/HS-29_Produktionsstatistik.md) |
| HS-32 | Geber setzen | Vollseite | nein | [HM-07](Module/HM-07_Aktionstaste.md), [HM-09](Module/HM-09_Status-LED.md), [HM-11](Module/HM-11_Anzeigefeld.md), [HM-17](Module/HM-17_Titelzeile.md), [HM-19](Module/HM-19_Blaettertasten.md), [HM-27](Module/HM-27_Hinweis-Textfeld.md) | Einstellung › Geber setzen | [HS-32](Seiten/HS-32_Geber-setzen.md) |

### 3.9 Einstellung › Handbetrieb und EA-Übersicht

| HS-ID | Name | Typ | Design-Vorlage | Hauptmodule | Brotkrümel | Link |
|---|---|---|---|---|---|---|
| HS-30 | Handbetrieb Auswahl | Vollseite | nein | [HM-07](Module/HM-07_Aktionstaste.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-16](Module/HM-16_Kachel-Navigation.md), [HM-38](Module/HM-38_Such-Pop-up.md) | Einstellung › Handbetrieb | [HS-30](Seiten/HS-30_Handbetrieb-Auswahl.md) |
| HS-31 | Handbetrieb | Vollseite | nein | [HM-07](Module/HM-07_Aktionstaste.md), [HM-09](Module/HM-09_Status-LED.md), [HM-11](Module/HM-11_Anzeigefeld.md), [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](Module/HM-13_Eingabe-Pop-up.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-17](Module/HM-17_Titelzeile.md), [HM-19](Module/HM-19_Blaettertasten.md), [HM-27](Module/HM-27_Hinweis-Textfeld.md), [HM-38](Module/HM-38_Such-Pop-up.md) | Einstellung › Handbetrieb › &lt;Gruppe&gt; | [HS-31](Seiten/HS-31_Handbetrieb.md) |
| HS-33 | EA-Übersicht | Vollseite | nein | [HM-07](Module/HM-07_Aktionstaste.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-16](Module/HM-16_Kachel-Navigation.md), [HM-38](Module/HM-38_Such-Pop-up.md) | Einstellung › EA-Übersicht | [HS-33](Seiten/HS-33_EA-Uebersicht.md) |
| HS-34 | EA-Anzeige | Vollseite | nein | [HM-09](Module/HM-09_Status-LED.md), [HM-11](Module/HM-11_Anzeigefeld.md), [HM-17](Module/HM-17_Titelzeile.md), [HM-19](Module/HM-19_Blaettertasten.md), [HM-36](Module/HM-36_EA-Zeile.md) | Einstellung › EA-Übersicht › &lt;Karte&gt; | [HS-34](Seiten/HS-34_EA-Anzeige.md) |

### 3.10 Einstellung › Systemeinstellungen

| HS-ID | Name | Typ | Design-Vorlage | Hauptmodule | Brotkrümel | Link |
|---|---|---|---|---|---|---|
| HS-35 | Systemeinstellungen | Vollseite | nein | [HM-07](Module/HM-07_Aktionstaste.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-16](Module/HM-16_Kachel-Navigation.md) | Einstellung › Systemeinstellungen | [HS-35](Seiten/HS-35_Systemeinstellungen.md) |
| HS-36 | Service | Vollseite | nein | [HM-07](Module/HM-07_Aktionstaste.md), [HM-11](Module/HM-11_Anzeigefeld.md), [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](Module/HM-13_Eingabe-Pop-up.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-25](Module/HM-25_Meldungsliste.md) | Einstellung › Systemeinstellungen › Service | [HS-36](Seiten/HS-36_Service.md) |
| HS-37 | Meldearchiv | Vollseite | nein | [HM-07](Module/HM-07_Aktionstaste.md), [HM-13](Module/HM-13_Eingabe-Pop-up.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-25](Module/HM-25_Meldungsliste.md) | Einstellung › Systemeinstellungen › Meldearchiv | [HS-37](Seiten/HS-37_Meldearchiv.md) |
| HS-39 | System- und Antriebsinfos | Vollseite | nein | [HM-10](Module/HM-10_Fortschrittsbalken.md), [HM-11](Module/HM-11_Anzeigefeld.md), [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](Module/HM-13_Eingabe-Pop-up.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-15](Module/HM-15_Gruppenbereich.md), [HM-19](Module/HM-19_Blaettertasten.md), [HM-34](Module/HM-34_Motor-Statuszeile.md) | Einstellung › Systemeinstellungen › System- und Antriebsinfo | [HS-39](Seiten/HS-39_System-und-Antriebsinfos.md) |

Hinweis: Pop-ups ohne eigene Seite (Zeitplan-Eintrag, Eingabe, Suche, Benutzer, Sprachwahl, Rezeptauswahl, Bestätigung, Filter, Datei/Ergebnis) laufen über den `IDialogService` und stehen im Pop-up-Inventar der Navigation (Abschnitt 4.1), nicht in dieser Tabelle.

## 4. Modulkatalog

38 Module `HM-01` bis `HM-38` ([Modulliste](Module/Modulliste.md): Herkunft aus `DM` und `RM`, Verwendung auf Seiten, Hierarchie). Je Funktion ein Modul, Varianten sind Parameter (A-45). Die Control-Klasse heißt `HM<nn>_<EnglischerName>` (A-56). Die ID verlinkt die Moduldatei mit Parametern, Zuständen und Prüfpunkten. „Annahmemodul“ heißt: Dialog oder Funktion ist in Handbuch und Bildern nicht beschrieben (A-20, A-51, A-59).

### 4.1 Rahmenmodule

| HM-ID | Name | Control-Klasse | Kurzbeschreibung |
|---|---|---|---|
| [HM-01](Module/HM-01_Seitenleiste.md) | Seitenleiste | `HM01_Sidebar` | Dunkle Seitenleiste mit Benutzerkreis (Name, Rolle), Tasten Home, Einstellungen, Meldungen (mit Zähler) und Zurück; in HS-24 ausgeblendet. |
| [HM-02](Module/HM-02_Kopfzeile.md) | Kopfzeile (Logo, Betriebsart, Uhr) | `HM02_HeaderBar` | Kopfzeile mit Logo, Meldezeile (HM-03), Betriebsart und Uhrzeit/Datum; Variante ohne Meldezeile für HS-24. |
| [HM-03](Module/HM-03_Meldezeile.md) | Meldezeile | `HM03_MessageLine` | Zeigt die wichtigste aktuelle Meldung „NNN: Text“ mit Klasse, Symbol und Wort; Antippen öffnet HS-38. |
| [HM-04](Module/HM-04_Brotkruemel-Navigation.md) | Brotkrümel-Navigation | `HM04_Breadcrumb` | Brotkrümel-Pfad aus Pfeilsegmenten; alle Segmente außer dem letzten sind antippbar, Objektkennung als Zusatz möglich. |
| [HM-05](Module/HM-05_Kennzahl-Kachel.md) | Kennzahl-Kachel | `HM05_MetricTile` | Kachel mit Symbol und Messwert (Geschwindigkeit, Maschinenwinkel im Rahmen; Kennzahlen auf Seiten), optional bedienbar. |
| [HM-06](Module/HM-06_Funktionsleiste.md) | Funktionsleiste unten | `HM06_FunctionBar` | Untere Leiste für höchstens fünf seitenspezifische Tasten (HM-07, HM-08, HM-19) und Überlauf-Taste. |

### 4.2 Grundelemente

| HM-ID | Name | Control-Klasse | Kurzbeschreibung |
|---|---|---|---|
| [HM-07](Module/HM-07_Aktionstaste.md) | Aktionstaste (Funktionstaste) | `HM07_ActionButton` | Taste mit genau einer Aktion ohne Ein/Aus-Zustand; Auslösung per Antippen, Halten (Totmann) oder Dauerfunktion. |
| [HM-08](Module/HM-08_Zustandstaste-Umschalter.md) | Zustandstaste / Umschalter | `HM08_ToggleSwitch` | Ein/Aus-Element als Schalter oder Taste, neutrale Darstellung mit Haken und Wort; Sammelzustand „Teilweise“. |
| [HM-09](Module/HM-09_Status-LED.md) | Status-LED | `HM09_StatusLed` | Runde Statusanzeige mit Symbol, Wort und Beschriftung (einzeln, Liste oder kompakt); nur Anzeige. |
| [HM-10](Module/HM-10_Fortschrittsbalken.md) | Fortschrittsbalken | `HM10_ProgressBar` | Horizontaler Balken mit Prozentzahl für Füllstand, Auslastung oder Zeitablauf; Statusfarbe nur bei Schwellwert. |
| [HM-11](Module/HM-11_Anzeigefeld.md) | Anzeigefeld (Wert-Zeile) | `HM11_ValueDisplay` | Schreibgeschützte Anzeige eines Werts mit Beschriftung als Feld oder Zeile, optional mit Einheit, Zähler oder Reset. |
| [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md) | Eingabefeld mit Schlüsselsymbol | `HM12_ValueInput` | Eingabefeld mit Beschriftung und Schlüsselsymbol für berechtigungspflichtige Werte; Antippen öffnet HM-13. |
| [HM-15](Module/HM-15_Gruppenbereich.md) | Gruppenbereich | `HM15_GroupPanel` | Gruppenbereich mit Überschrift (Panel oder reine Überschrift), bündelt zusammengehörige Elemente. |
| [HM-16](Module/HM-16_Kachel-Navigation.md) | Kachel-Navigation | `HM16_TileNavigation` | Raster großer Kacheltasten für Navigation und Schnellzugriff, auch mit Zustandstasten und deaktivierten Kacheln. |
| [HM-17](Module/HM-17_Titelzeile.md) | Titelzeile (Objektüberschrift) | `HM17_TitleBar` | Titelzeile für das angezeigte Objekt (Dosierer, Waage, Antrieb, EA-Karte), optional mit zwei Kennwerten. |
| [HM-18](Module/HM-18_Auswahlfeld-Pfeiltasten.md) | Auswahlfeld mit Pfeiltasten | `HM18_SelectorField` | Auswahlfeld mit Pfeiltasten zum Durchschalten einer Auswahl (Filtertyp, Geber, Nockennummer, Datum). |
| [HM-19](Module/HM-19_Blaettertasten.md) | Blättertasten | `HM19_PagerButtons` | Paar Pfeiltasten zum Blättern zwischen gleichartigen Objekten, in der Funktionsleiste oder im Inhaltsbereich. |
| [HM-27](Module/HM-27_Hinweis-Textfeld.md) | Hinweis-Textfeld | `HM27_NoticeBox` | Nicht editierbares Textfeld für Hinweise, Warnungen und Statusmeldungen mit Symbol. |

### 4.3 Pop-up-Module

| HM-ID | Name | Control-Klasse | Kurzbeschreibung |
|---|---|---|---|
| [HM-14](Module/HM-14_Popup-Rahmen.md) | Pop-up-Rahmen | `HM14_PopupFrame` | Modaler Rahmen für alle Pop-ups (freier Inhalt, Bestätigung, Datei/Ergebnis) mit Titelzeile, Scrim und Schließen. |
| [HM-13](Module/HM-13_Eingabe-Pop-up.md) | Eingabe-Pop-up (Ziffernblock) | `HM13_NumericKeypadDialog` | Annahmemodul: Ziffernblock-Dialog für Zahl-, Zeit- und Texteingabe mit Grenzen, Übernehmen und Abbrechen. |
| [HM-30](Module/HM-30_Zeitplan-Eintrag-Pop-up.md) | Zeitplan-Eintrag-Pop-up | `HM30_ScheduleEntryDialog` | Dialog zum Anlegen, Bearbeiten und Löschen eines Zeitplan-Eintrags im Pop-up-Rahmen. |
| [HM-38](Module/HM-38_Such-Pop-up.md) | Such-Pop-up (Suche mit Trefferliste) | `HM38_SearchDialog` | Annahmemodul: Such-Pop-up mit Texteingabe und Trefferliste für Betriebsmittel (HS-30, HS-31, HS-33). |

### 4.4 Komposita aus Grundelementen

| HM-ID | Name | Control-Klasse | Kurzbeschreibung |
|---|---|---|---|
| [HM-20](Module/HM-20_Dosierer-Karte.md) | Dosierer-Karte / Dosierer-Seitengerüst | `HM20_DosingCard` | Karte für einen Schneckendosierer in Kompakt- (Übersicht) und Detaildarstellung (Seitengerüst). |
| [HM-21](Module/HM-21_Motorparameter-Karte.md) | Motorparameter-Karte | `HM21_MotorParameterCard` | Karte mit festen Zeilen aus Beschriftung und Eingabefeld für Verschluss- oder Schneckenparameter. |
| [HM-22](Module/HM-22_Gewichtskorrektur-Tabelle.md) | Gewichtskorrektur-Tabelle | `HM22_WeightCorrectionTable` | Eingabetabelle der 20 Stützstellen (SOLL/IST) der Dosierkorrektur mit Sollgewicht und Ablauftasten. |
| [HM-23](Module/HM-23_Nockentabelle.md) | Nockentabelle | `HM23_CamTable` | Tabelle der Nocken mit Nummer, Bezeichnung, Start, Ende und Status; Antippen der Nummer öffnet HS-25. |
| [HM-24](Module/HM-24_Nocken-Parameterzeile.md) | Nocken-Parameterzeile | `HM24_CamParameterRow` | Zeile für einen Nockenpunkt oder eine Nockenzeit mit bis zu drei Feldern (Winkel, Zeit, Ergebnis). |
| [HM-28](Module/HM-28_Temperaturzonen-Zeile.md) | Temperaturzonen-Zeile | `HM28_HeatZoneRow` | Zeile je Temperaturzone in den Varianten Heißleim (Soll/Ist/Ein-Aus) und Heizungen (Ein/Aus, Meldung, Soll, Ist). |
| [HM-29](Module/HM-29_Wochen-Zeitplan.md) | Wochen-Zeitplan | `HM29_WeekSchedule` | Wochenraster mit sieben Tagesspalten für Heiz- und Absenkphasen der Zeitschaltuhr. |
| [HM-31](Module/HM-31_Leimspuren-Grafik.md) | Leimspuren-Grafik | `HM31_GlueTrackGraphic` | Skalierbare Vektorgrafik des Kartonzuschnitts mit Leimspuren und 18 Winkelfeldern. |
| [HM-33](Module/HM-33_Zaehlerzeile.md) | Zählerzeile | `HM33_CounterRow` | Zeile aus Beschriftung, Zähler und Reset-Zeitpunkt (Aktuell, Historie 1 bis 12). |
| [HM-34](Module/HM-34_Motor-Statuszeile.md) | Motor-Statuszeile | `HM34_DriveStatusRow` | Zeile je Servoantrieb mit Diag-Code, Strom aktuell/max/Limit und Meldung. |
| [HM-35](Module/HM-35_Regulierungs-Parameterblock.md) | Regulierungs-Parameterblock | `HM35_RegulationBlock` | Parametersatz der automatischen Gewichtsregulierung je Dosierer (Eingaben, Mittelwert, Umschalter). |
| [HM-36](Module/HM-36_EA-Zeile.md) | EA-Zeile (Signalzeile) | `HM36_IoRow` | Zeile der EA-Signalliste mit Status-LED (oder Analogwert), SPS-Kennung und Klartext. |
| [HM-37](Module/HM-37_Wertegitter.md) | Wertegitter (Einzelgewichte) | `HM37_ValueGrid` | Gitter aus 10 × 5 Zellen für Einzelgewichte mit Status-LED und Marke am jüngsten Wert. |

### 4.5 Spezialdarstellungen

| HM-ID | Name | Control-Klasse | Kurzbeschreibung |
|---|---|---|---|
| [HM-25](Module/HM-25_Meldungsliste.md) | Meldungsliste | `HM25_MessageList` | Scrollbare Liste für Meldungen und Auswahllisten mit Klassenkennzeichnung und vier Scrolltasten. |
| [HM-26](Module/HM-26_Diagramm.md) | Diagramm (Trend / Balken) | `HM26_Chart` | Reine Anzeige von Messreihen als Liniendiagramm (Trend) oder Balkendiagramm (Tagesverlauf). |
| [HM-32](Module/HM-32_Packungsregister-Grafik.md) | Packungsregister-Grafik | `HM32_PackRegisterGraphic` | Grafische Darstellung der Maschinenstationen mit Zustandssymbolen, Legende und horizontalem Bildlauf. |

**Hierarchie** (Komposition statt Kopien): Rahmen `HM-01` bis `HM-06` (`HM-02` enthält `HM-03`, `HM-06` enthält `HM-07`, `HM-08`, `HM-19`); `HM-14` trägt `HM-13`, `HM-30`, `HM-38`; die Komposita bauen auf den Grundelementen auf (z. B. `HM-20` aus `HM-07` bis `HM-12`).

## 5. Querschnittsthemen

### 5.1 Berechtigungen und Benutzer

- **Rollen** (Dummy, A-41): `Operator < Technician < Service`. Der Standardbenutzer „Max Mustermann“ hat die Rolle `Technician` (im Design „Technik“). Die Referenz beschreibt weder Stufen noch Zuordnung (OP-04, OP-25); die Rollenzuordnung je Feld ist Dummy und zentral konfigurierbar.
- **Zwei Ebenen.** Seitenzugang über `PageDescriptor.MinimumRole`; im Handbuch ist nur `HS-36` Service seitenseitig geschützt (Mindestrolle Technician, Taste mit Schlüsselsymbol). Alle übrigen Berechtigungen liegen auf Feld- und Tastenebene (Schlüsselsymbol in [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-07](Module/HM-07_Aktionstaste.md), [HM-08](Module/HM-08_Zustandstaste-Umschalter.md), [HM-16](Module/HM-16_Kachel-Navigation.md)); der Navigationsdienst stellt dafür nur `IUserSession` bereit.
- **Darstellung.** Schlüssel = berechtigungspflichtig, Berechtigung vorhanden; Schloss = Berechtigung fehlt. Das Symbol (24 px, oben rechts) steht immer und hat Textfarbe, nicht Gelb ([Designsystem](Designsystem.md) 5).
- **Ohne Berechtigung** (einheitlich, Navigation 4.1): Das Eingabe-Pop-up bzw. die Aktion öffnet nicht, die Meldezeile zeigt `Berechtigung erforderlich: <Rolle>`, das Benutzer-Pop-up öffnet sich; nach der Anmeldung läuft die ausgelöste Aktion weiter. Bei Abmeldung auf einer geschützten Seite navigiert der Dienst zum Elternschlüssel (`HS-35`) und schließt Pop-ups.
- **Benutzer-Pop-up.** Anmelden, Abmelden, Rolle anzeigen; Inhalt und Berechtigung sind Platzhalter (OP-63, OP-04).

### 5.2 Zustände und zweiter Kanal

Jedes interaktive Element kennt dieselben Zustände ([Designsystem](Designsystem.md) 5); die Information bleibt auch bei Farbenblindheit oder Blendung erhalten.

| Zustand | Darstellung | Zweiter Kanal |
|---|---|---|
| Normal | neutrale Fläche, Kontur 1 px | Beschriftung; bei Zustandstasten Symbol „Aus“ und Wort |
| Gedrückt | Kontur 2 px | dickere Kontur; Auslösung beim Loslassen im Ziel |
| Deaktiviert | gestrichelte Kontur, Text deaktiviert | Kontur; Grund per Antippen in der Meldezeile (A-28) |
| Aktiv / Ein | neutral dunkel, nicht grün | Haken-Symbol und Wort „Ein“ (A-31) |
| Fehler | Kontur 3 px Fehlerfarbe, Flächenton Fehler | Symbol und Fehlertext unter dem Element |
| Berechtigungsgeschützt | Normal | Schloss bzw. Schlüssel |
| Fokus | Kontur 3 px Fokusfarbe | Rahmen |
| Teilweise, Ausstehend | – | `Icon.State.Partial` / `Icon.State.Pending` mit Wort (z. B. „Automatik Produktion“, A-58) |

Statusanzeigen verwenden die Farben Ok, Warnung, Fehler, Info, Inaktiv zusammen mit festem Symbol und Wort ([Designsystem](Designsystem.md) 1.2, 1.3): Kreis mit Haken, Dreieck mit „!“, Kreuz, Kreis mit „i“, leerer Kreis. Statusflächen erscheinen nur bei Warnung, Fehler oder Handlungsbedarf, nie im Normalbetrieb. Abgeleitete Zuordnungen: Meldungsklassen (A-49), Packungsregister (A-53), Wertegitter (A-55), Zeitplan (A-54), Füllstand (A-62), Auslastung ab 90 % Warnung (A-62).

### 5.3 Pop-up-Regeln

Modale Regeln (Navigation 4.2, A-40), gültig für alle Pop-ups über [HM-14](Module/HM-14_Popup-Rahmen.md):

1. Ein Pop-up zur Zeit, Stapeltiefe höchstens 2 (z. B. Eingabe über Zeitplan-Eintrag, Eingabe über `HS-03`, Bestätigung über Pop-up); alles andere wird abgelehnt.
2. Scrim dahinter; Seitenleiste, Funktionsleiste, Seiteninhalt und Brotkrümel sind gesperrt, Meldezeile und Kopfzeile bleiben Anzeige.
3. Jedes Pop-up hat eine eindeutige Schließen-Aktion; Antippen außerhalb schließt nicht. Ohne „Übernehmen“ geschlossen, wird die Änderung verworfen.
4. Pop-ups stehen nie im Verlauf; „Zurück“ ist gesperrt, solange eines offen ist.
5. Ein Systemwechsel (Zeitablauf `HS-24`, Rollenverlust) schließt offene Pop-ups ohne Übernehmen.
6. Mittig über dem Inhaltsbereich, höchstens 60 % der Fensterbreite, Titelzeile 64 px, Schließen-Taste oben rechts, Bedientasten unten rechts, kein Schatten.
7. Neue Meldungen erscheinen in der Meldezeile, öffnen `HS-38` aber erst nach Schließen.

Pop-up-Arten: Seitenpop-ups `HS-02`, `HS-03`; Eingabe ([HM-13](Module/HM-13_Eingabe-Pop-up.md)); Zeitplan-Eintrag ([HM-30](Module/HM-30_Zeitplan-Eintrag-Pop-up.md)); Suche ([HM-38](Module/HM-38_Such-Pop-up.md)); Bestätigung (Fokus auf „Abbrechen“, für stoppende, zerstörende oder messungsverändernde Aktionen); Filter; Datei/Ergebnis; Benutzer, Sprachwahl, Rezeptauswahl (Platzhalter, OP-01, OP-03, OP-63).

### 5.4 Eingabe

- **Verfahren.** Antippen eines Eingabefelds ([HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md)) öffnet das Eingabe-Pop-up ([HM-13](Module/HM-13_Eingabe-Pop-up.md)): Titel, aktueller Wert, Eingabezeile, Ziffernblock 3 × 4 (0 bis 9, Komma, Vorzeichen, Rücktaste, Löschen; Tasten 96 × 64 px), Grenzen als Caption, „Übernehmen“ nur bei gültigem Wert, „Abbrechen“. Varianten Zeit (hh:mm) und Text (A-51). Das Verfahren ist eine Annahme (A-20), die Referenz dokumentiert es nicht (OP-30).
- **Grenzen.** Wertebereiche, Standardwerte und Plausibilitätsregeln fehlen in den Quellen (OP-28); sie sind konfigurierbare Dummy-Werte im ViewModel (A-50). Ungültige Werte zeigen den Fehlerzustand mit Text („Wert außerhalb 0 bis 100 %“).
- **Anzeigefelder** ([HM-11](Module/HM-11_Anzeigefeld.md)) sind nicht editierbar; rücksetzbare Zähler (Reset in `HS-02`) werden per Haltetaste ([HM-07](Module/HM-07_Aktionstaste.md), Auslösung durch Halten) zurückgesetzt; die Haltedauer ist Dummy (OP-42).
- **Totmann-Tasten** (Jog in `HS-31`, „Manuell“ in `HS-07`): Bewegung nur, solange die Taste gedrückt ist; Ende bei Loslassen, Verlassen der Taste, Seitenwechsel, Rollenverlust und Störung (OP-57).
- **Blättern** ändert nur den Seitenparameter (`ReplaceParameter`), erzeugt keinen Verlaufseintrag (`HS-11`, `HS-12`, `HS-25` bis `HS-27`, `HS-29`, `HS-31`, `HS-32`, `HS-34`).

### 5.5 Meldungen

- **Meldezeile** ([HM-03](Module/HM-03_Meldezeile.md)) zeigt die wichtigste Meldung; **Meldeanzeige** `HS-38` (Liste live, [HM-25](Module/HM-25_Meldungsliste.md)) ist von jeder Seite über Meldezeile oder Seitenleiste erreichbar; **Meldearchiv** `HS-37` (Zeit, Ereignis, Beschreibung, Filter, Export) über `HS-38` „Archiv“ und `HS-35`.
- **Klassen** (A-49): Betriebsstatus → Ok, Hinweis/Status → Warnung, Störung → Fehler; jeweils Symbol und Klassenwort. Seitenleiste „Meldungen“ zeigt einen Zähler (0 bis 99, ab 100 „99+“) und ist hervorgehoben, wenn Meldungen anstehen (zusätzlich Zahl, nicht nur Farbe).
- **Hinweise auf Seiten** ([HM-27](Module/HM-27_Hinweis-Textfeld.md)): Warnhinweise (Not-Aus, Verbrennungsgefahr), Statusanzeigen, Zeile „Meldung:“ der Aktorseite. Die nIO-Regel des Nachdosierers erscheint als Warnhinweis (A-58, A-65).
- **Systemmeldungen für Bedienfehler:** `Berechtigung erforderlich: <Rolle>`, Grund einer deaktivierten Taste (A-28). Ein kritischer Alarm (Störung) beendet die Reinigung in `HS-24` vorzeitig (Annahme, OP-61).

### 5.6 Hell- und Dunkelthema

- Zwei Theme-Dateien mit identischen Schlüsseln (`Theme.Light.xaml`, `Theme.Dark.xaml`, nur Brushes) und `Tokens.xaml` für themenunabhängige Maße, Schriften, Radien (A-30, [Designsystem](Designsystem.md) 8 und 10).
- Alle Brush-Verweise sind `{DynamicResource Brush.…}`, Maße und Schriften dürfen `StaticResource` sein. Umschalten zur Laufzeit über `IThemeService` (ersetzt das Theme-`MergedDictionary`).
- Standard folgt der Windows-Einstellung beim Start; manuelle Umschaltung in den Systemeinstellungen (`HS-35`); die Wahl bleibt gespeichert (Benutzereinstellung).
- Das Logo hat je Thema eine Variante (`LogoLight`, `LogoDark`). Die Seitenleiste ist in beiden Themen dunkel.

### 5.7 Lokalisierung (.resx)

- Alle sichtbaren Texte stehen in `Resources/Strings.resx` (Deutsch, Standard) und `Strings.<Sprache>.resx` (z. B. `en`), nie im XAML (Agent.md Abschnitt 4). Die Sprachwahl ist ein Pop-up über die Funktionsleisten-Taste „Sprache“ in `HS-04` (Platzhalter, OP-03); Umschalten zur Laufzeit über `CultureInfo` und Neuaufbau der Ansicht.
- Schlüsselschema `<Bereich>_<Element>_<Eigenschaft>`, englisch, PascalCase (z. B. `Nav_Home_Label`, `Status_Warning_Word`, `Msg_PermissionRequired`, `Unit_RevPerMin`); Seiten: `Nav_<Key>_Title`, `Nav_<Key>_Crumb` (Navigation 5.1). Statuswörter, Symbolnamen (`AutomationProperties.Name`), Fehlertexte, Einheiten sind ebenfalls Ressourcen.
- Textlängen: Layouts mit +40 % Breite planen; Tasten wachsen in der Breite und brechen mehrzeilig um; Wörter ohne Trennstrich (OP-13); Abschneiden („…“) nur bei Meldungstext mit vollständiger Anzeige im Detail.
- Wortlaut der Referenz wird nicht korrigiert, wenn er zitiert wird (OP-35); die Schreibweise im neuen HMI entscheidet die deutsche `.resx` (OP-34, OP-33: Kapitelname gewinnt als Seitenname).

### 5.8 Zahlenformate

- Zahlen mit Einheit: Wert, geschütztes Leerzeichen, Einheit (`112 1/min`, `245 °`, `83 %`, `235 g`); Tabellenziffern in Messwerten. Dezimal- und Datumsformat nach `CurrentCulture` (Dezimalkomma, `06.01.2026`).
- Uhrzeit im Rahmen `HH:mm:ss` (Referenz mit Sekunden, A-47), Zeitfelder `hh:mm`; Gewichte in g, Temperaturen in °C, Winkel in °, Drehzahl in 1/min (Einheit jeweils aus dem Bild, sonst ohne Einheit, OP-29).
- Schriftgrößen 20 / 24 / 28 / 32 / 36 px (Segoe UI, Rückfall Arial; A-25), Mindestgröße 20 px.
- Nachkommastellen und Einheiten, die die Quellen nicht nennen, sind Dummy-Werte (OP-29, OP-28).

## 6. Technische Umsetzung

### 6.1 Projektstruktur ([A-74](../00_Plan/Annahmen.md))

Lösung unter `src/` (derzeit nicht vorhanden). Eine WPF-Anwendung genügt für M2; eine Aufteilung in Bibliotheken ist später möglich, ohne Namespaces zu ändern.

```
src/
├─ ApaTec.Hmi.sln
└─ ApaTec.Hmi/                       net8.0-windows, UseWPF, Nullable, TreatWarningsAsErrors
   ├─ ApaTec.Hmi.csproj
   ├─ Program.cs                     Einstiegspunkt: Host/DI aufbauen, App starten (App.xaml.cs bleibt leer)
   ├─ App.xaml                       bindet Themes/Tokens.xaml, aktives Theme, Styles, Views/ViewTemplates.xaml
   ├─ MainWindow.xaml                Hauptfenster 1920 × 1080: Rahmen (HM-01 bis HM-06) und Seiten-Host
   ├─ Themes/                        Tokens.xaml, Theme.Light.xaml, Theme.Dark.xaml, Icons.xaml, Styles/*.xaml
   ├─ Resources/                     Strings.resx, Strings.en.resx (+ Logo-Grafiken)
   ├─ Controls/                      HM01_Sidebar … HM38_SearchDialog (Abschnitt 4)
   ├─ Views/                         <Gruppe>/<Key>View.xaml, ViewTemplates.xaml (ViewModel → View)
   ├─ ViewModels/                    MainViewModel, <Key>ViewModel, Basisklassen
   ├─ Models/                        Datenmodelle der Dienste (Meldung, Zähler, Dosiererdaten …)
   ├─ Services/                      Navigation/, Dialogs/, Session/, Theming/, Localization/, Data/ (Schnittstellen)
   │  └─ Dummy/                      Dummy<Name>Service (Implementierungen mit Beispieldaten)
   └─ DesignTime/                    DesignTimeServices.cs (Dummy-Dienste für den Entwurfsmodus)
```

- **Namespaces** (Englisch): Stamm `ApaTec.Hmi`; `ApaTec.Hmi.Controls`, `.Views.<Gruppe>`, `.ViewModels`, `.Models`, `.Services.<Bereich>`, `.Services.Dummy`, `.DesignTime`. Ressourcen: `ApaTec.Hmi.Resources.Strings`.
- **Gruppen der Views** (Vorschlag, grob nach Abschnitt 3): `Production`, `Settings` (`HS-04`, `HS-40`, `HS-42`), `Feeders`, `ClosingMachine`, `Dosers`, `Scales`, `Machine`, `Manual`, `System` (`HS-35` bis `HS-39`, `HS-38`).
- **NuGet** (Agent.md Abschnitt 7): `CommunityToolkit.Mvvm`, `Microsoft.Extensions.DependencyInjection`, `Microsoft.Extensions.Hosting`; keine weiteren (Diagramme zeichnet [HM-26](Module/HM-26_Diagramm.md) selbst mit `Canvas`/`Path`). Weitere Pakete nur mit Eintrag in `Annahmen.md`.
- **Namen.** Controls `HM<nn>_<Name>` (A-56). Seitenschlüssel `PageKey`, `<Key>View`, `<Key>ViewModel` und Ressourcen `Nav_<Key>_Title/_Crumb` nach dem Seitenregister in Navigation 5.1 (A-43). Dialoge: `DialogKey`.

### 6.2 MVVM

- **CommunityToolkit.Mvvm:** ViewModels erben von `ObservableObject` (Basisklasse `PageViewModelBase` mit Titel, `INavigationAware.OnNavigatedTo(object? parameter)` und `OnNavigatedFrom()`); Eigenschaften mit `[ObservableProperty]`, Befehle mit `[RelayCommand]`.
- **Trennung.** Views kennen keine ViewModels außer über `DataContext`; ViewModels kennen keine Views und kein WPF-Fensterobjekt. ViewModel → View wird per `DataTemplate` in `Views/ViewTemplates.xaml` aufgelöst, das Hauptfenster hostet das aktuelle Seiten-ViewModel in einem `ContentControl`.
- **Controls.** Grundelemente ([HM-07](Module/HM-07_Aktionstaste.md) bis [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-15](Module/HM-15_Gruppenbereich.md) bis [HM-19](Module/HM-19_Blaettertasten.md), [HM-27](Module/HM-27_Hinweis-Textfeld.md)) als Controls mit `ControlTemplate`/`Style` in `Themes/Styles`, Komposita als `UserControl`; ihre Parameter sind Dependency Properties (A-50, A-56). Pop-ups ([HM-13](Module/HM-13_Eingabe-Pop-up.md), [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-30](Module/HM-30_Zeitplan-Eintrag-Pop-up.md), [HM-38](Module/HM-38_Such-Pop-up.md)) als Overlay im Hauptfenster über den `IDialogService`.
- **Code-behind.** Views (`*View.xaml.cs`, `MainWindow.xaml.cs`, `App.xaml.cs`) enthalten nur den Konstruktor mit `InitializeComponent()`. Die `HM<nn>_…`-Controls sind benutzerdefinierte Steuerelemente; ihr C# enthält nur Dependency-Property-Deklarationen samt CLR-Eigenschaften, keine Logik und keine Ereignisbehandler ([A-73](../00_Plan/Annahmen.md), KON-K08).

### 6.3 Dependency Injection und Hosting

`Program.cs` baut mit `Microsoft.Extensions.Hosting` den Host auf, registriert Dienste, `PageRegistry` und ViewModels und startet `App` mit `MainWindow`. Als Singletons: `INavigationService`, `IDialogService`, `IUserSession`, `IThemeService`, `ILocalizationService`, alle Datendienste (Abschnitt 6.6). ViewModels sind transient und werden vom `NavigationService` über den `PageDescriptor` (`ViewModelType`) aufgelöst. Die Maschinenanbindung ist nicht Teil des Projekts: Jede Schnittstelle hat in M2 nur eine Dummy-Implementierung.

### 6.4 Navigationsdienst `INavigationService`

Vorgaben liegen vollständig in [Navigation](Navigation.md) Abschnitt 5; hier die Zusammenfassung für M2.

| Element | Inhalt |
|---|---|
| `PageRegistry` | statische Liste von 43 `PageDescriptor` (Schlüssel, Route, `HsId`, `PageKind` Page/Popup/Fullscreen, `ParentKey`, ViewModel-Typ, Titel- und Crumb-Ressource, Funktionsleistenart, Mindestrolle, `ShowFrame`), Quelle Tabelle 5.1 der Navigation |
| `INavigationService` | `Current`, `CurrentParameter`, `History` (Vorgängerseiten ohne aktuelle), `Breadcrumb`, `CanGoBack`; `NavigateToAsync`, `ReplaceParameter` (Blättern ohne Verlaufseintrag), `GoBack`, `GoHome` (Verlauf leer), `GoToSettings` (Verlauf `[HS-01]`), `GoToAncestor`, `OpenMessages`; Ereignis `Navigated` |
| Verlauf | Tiefe 20; Sprung auf eine Seite im Verlauf kürzt den Stapel; gleiche Seite erneut wirkungslos; `HS-24` wird nicht gestapelt (A-42, A-44) |
| `IDialogService` | `IsModalOpen`, `ShowAsync<T>(dialogKey, parameter)`, `CloseTop`, `CloseAll`; erzwingt die modalen Regeln (Abschnitt 5.3) |
| `IUserSession` | `Current` (Dummy „Max Mustermann“, Technician), `HasRole`, `RequestRoleAsync`, `SessionChanged` |
| Brotkrümel | aus der Kette der `ParentKey`; dynamische Segmente über `IBreadcrumbTextProvider.GetCrumbText()` (`HS-31`, `HS-34`), Objektkennung als Zusatz (`HS-11`, `HS-12`, `HS-20`) |
| Sonderfälle | `HS-24` startet einen Timer und navigiert nach Ablauf ohne Stapelwirkung zurück; bei offenem Pop-up wird `OpenMessages` zurückgestellt; der Dienst hat keinen Zugriff auf die Maschine |

### 6.5 Hauptfenster und Rahmen

`MainViewModel` hält das aktuelle Seiten-ViewModel, die Rahmenzustände (Betriebsart, Kennzahlen, aktuelle Meldung, Meldezähler, Benutzer) und die Befehle der Seitenleiste. Das Hauptfenster setzt `HM-01` bis `HM-06` einmal und blendet sie je `PageDescriptor.ShowFrame`/`PageKind` aus (Abschnitt 2). Die Funktionsleiste erhält ihre Tasten vom Seiten-ViewModel (Sammlung von Taste-Beschreibungen), nicht von der View.

### 6.6 Dummy-Datendienste je Seitengruppe ([A-75](../00_Plan/Annahmen.md), [A-77](../00_Plan/Annahmen.md))

Die Quellen legen keine Datenschnittstellen fest. Vorschlag: eine Schnittstelle je fachlichem Bereich unter `Services/Data`, Implementierung `Dummy<Name>Service` mit Beispielwerten aus den Bildern und konfigurierbaren Grenzen (A-50, OP-28, OP-41). Ereignisse (`event`) liefern Änderungen an die ViewModels, Befehle bleiben ohne Wirkung auf eine Maschine.

| Gruppe | Schnittstelle | Zweck (Seiten) |
|---|---|---|
| Rahmen | `IMachineStatusService` | Betriebsart, Geschwindigkeit Ist, Maschinenwinkel (Rahmen) |
| Rahmen | `IMessageService` | aktuelle Meldung, Meldungsliste, Zähler, Quittierung (`HM-03`, `HM-01`, `HS-38`) |
| Rahmen | `IClockService` | Uhrzeit und Datum ([HM-02](Module/HM-02_Kopfzeile.md)) |
| Rahmen / System | `ISettingsService` | Thema, Sprache, Reinigungsdauer (`HS-24`), gespeicherte Benutzereinstellungen |
| Produktion | `IProductionService` | Kennzahlen, Zähler, Historie, Reset (`HS-01`, `HS-02`) |
| Produktion | `IProductionFunctionService` | 16 Betriebsfunktionen als Zustandstasten, Beleuchtung (`HS-01`, `HS-04`) |
| Produktion | `IMachineSpeedService` | fünf Geschwindigkeiten (`HS-03`) |
| Produktion | `IShiftPlanService`, `IRecipeService` | Platzhalter (`HS-43`, Rezept in `HS-01`; OP-01, OP-02) |
| Zuführungen | `IFeederService` | Papier- und Kartonzuführung, Leimspuren (`HS-05`, `HS-06`) |
| Zuführungen | `IHotGlueService`, `IHotGlueScheduleService` | Heißleim Nordson, Temperatur, Druck, Zeitplan (`HS-07` bis `HS-10`) |
| Dosierer, Schließmaschine | `IDoserService` | Haupt- und Nachdosierer, Übersicht und Detail (`HS-11`, `HS-19`, `HS-41`) |
| Dosierer, Schließmaschine | `IMotorParameterService` | Motorparameter (`HS-12`, `HS-17`, `HS-20`) |
| Dosierer, Schließmaschine | `IWeightCorrectionService`, `IRegulationService` | Gewichtskorrektur (`HS-18`, `HS-21`), Regulierung (`HS-23`) |
| Dosierer, Schließmaschine | `IClosingMachineService` | Schließmaschine (`HS-16`) |
| Waagen | `IScaleService` | Kontrollwaage, Einzelgewichte, Trend, Kalibrierung (`HS-13` bis `HS-15`, `HS-27`) |
| Maschinenfunktionen | `IHeaterService`, `ICamService`, `IPackRegisterService`, `IProductionStatisticsService`, `IEncoderService` | `HS-22`, `HS-25`/`HS-26`, `HS-28`, `HS-29`, `HS-32` |
| Handbetrieb, EA | `IManualOperationService`, `IIoService`, `IEquipmentSearchService` | `HS-30`/`HS-31`, `HS-33`/`HS-34`, Suche ([HM-38](Module/HM-38_Such-Pop-up.md)) |
| System | `ISystemControlService`, `IServiceDataService`, `IMessageArchiveService`, `ISystemInfoService` | `HS-35` (Lampentest, Neustart, Ausschalten), `HS-36` (Variablenliste, Wago, Import/Export), `HS-37`, `HS-39` |
| Infrastruktur | `INavigationService`, `IDialogService`, `IUserSession`, `IThemeService`, `ILocalizationService` | Navigation, Pop-ups, Benutzer, Thema, Sprache (6.3) |

Anzahl: 30 fachliche und 5 Infrastruktur-Schnittstellen sind ein Vorschlag, keine Vorgabe; wichtig ist die Trennung nach Bereichen und die Kapselung hinter Schnittstellen. Konkrete Datenmodelle ergeben sich aus den Parametertabellen der Moduldateien (A-50).

### 6.7 Entwurfsmodus (DesignTime-Daten)

- Jede View trägt `d:DataContext="{d:DesignInstance Type=vm:<Key>ViewModel, IsDesignTimeCreatable=True}"`; jedes ViewModel hat einen parameterlosen Konstruktor für den Entwurf, der die Dummy-Dienste aus `DesignTime/DesignTimeServices` nutzt. Zur Laufzeit wird das ViewModel per DI mit den Diensten erzeugt.
- Controls erhalten Beispielwerte über `d:`-Eigenschaften bzw. Standardwerte der Dependency Properties; Beispielwerte stammen aus den Bildern der Referenz und des Designs (Rahmenwerte im Design: Meldung 014, 112 1/min, 245°, 9:15, 06.01.2026; OP-22).
- Optional und nicht Teil der 43 Seiten: eine Debug-Galerie, die alle Module in allen Zuständen zeigt ([A-76](../00_Plan/Annahmen.md)) – Hilfsmittel für die visuelle Prüfung in M3.

### 6.8 Regeln für Views und Controls (prüfbar)

1. **Kein Code-behind in Views:** `*.xaml.cs` von Views und Fenstern enthalten nur den Konstruktor mit `InitializeComponent()`; keine Ereignisbehandler, keine Logik.
2. **Keine Literale:** keine Farben (`#RRGGBB`, `Color=`), Pixelmaße (`Width="…"`, `Margin="…"`, `FontSize="…"` mit Zahl) und Texte in Views und Controls; Verweise nur auf Tokens (`{StaticResource Space.M}`, `{DynamicResource Brush.…}`) und `.resx` (Ausnahmen: `Tokens.xaml`, `Theme.*.xaml`, `Icons.xaml`; Stern-Proportionen im Grid sind erlaubt).
3. **Jeder Zustand mit zweitem Kanal** (Abschnitt 5.2), jedes Touch-Ziel mindestens 48 px (Standard 64 px).
4. **Ein Modul = ein Control:** Wiederholungen werden nicht kopiert; Seiten nutzen nur Module aus Abschnitt 4 (Rückverfolgung [Rueckverfolgung.md](Rueckverfolgung.md)).
5. **Navigation nur über den Dienst;** kein `Frame`, keine Fenster-Aufrufe aus ViewModels.
6. **Benennung** englisch (Klassen, Eigenschaften, Namespaces); sichtbare Texte Deutsch aus `.resx`.

## 7. Umsetzungsreihenfolge und Arbeitspakete für Meilenstein 2

Grundlage ist [Task.md](../../Task.md) Meilenstein 2 (vier Punkte). Nach [Agent.md](../../Agent.md) Abschnitt 9 arbeitet ein Ausführungs-Agent an genau einem Paket; ein getrennter Prüf-Agent prüft jedes Paket; zusammenführende Schritte laufen nacheinander. Pakete dürfen parallel laufen, wenn sie keine gemeinsamen Dateien schreiben (Spalte „parallel“); die Gemeinschaftsdateien (`Strings.resx`, `Icons.xaml`, `ViewTemplates.xaml`, `PageRegistry`, DI-Registrierung) werden dann nur im Zusammenführungsschritt am Paketende nacheinander ergänzt.

| Paket | Inhalt | Voraussetzung | parallel mit |
|---|---|---|---|
| M2-01 | Lösung und Projekt (`ApaTec.Hmi.sln`, `.csproj`, `Program.cs`, `App.xaml`), Warnungen als Fehler, Ordnerstruktur, SDK-Prüfung in der Cloud | – | – |
| M2-02 | Designsystem als `ResourceDictionary`: `Tokens.xaml`, `Theme.Light.xaml`, `Theme.Dark.xaml` (gleiche Schlüssel), `Icons.xaml`, Basisstile; `Strings.resx` (Rahmentexte) | M2-01 | M2-03 |
| M2-03 | Dienste: `PageRegistry` (43 Einträge), `INavigationService`, `IDialogService`, `IUserSession`, `IThemeService`, `ILocalizationService`, Basis-ViewModel, DI-Registrierung, `ViewTemplates.xaml`-Gerüst, `DesignTimeServices` | M2-01 | M2-02 |
| M2-04 | Hauptfenster 1920 × 1080 mit Rahmen: [HM-01](Module/HM-01_Seitenleiste.md) bis [HM-06](Module/HM-06_Funktionsleiste.md), `MainViewModel`, Dummy-Rahmendienste | M2-02, M2-03 | – |
| M2-05 | Grundelemente: [HM-07](Module/HM-07_Aktionstaste.md) bis [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-15](Module/HM-15_Gruppenbereich.md) bis [HM-19](Module/HM-19_Blaettertasten.md), [HM-27](Module/HM-27_Hinweis-Textfeld.md) | M2-02 | M2-04 |
| M2-06 | Pop-ups: [HM-14](Module/HM-14_Popup-Rahmen.md), [HM-13](Module/HM-13_Eingabe-Pop-up.md), [HM-30](Module/HM-30_Zeitplan-Eintrag-Pop-up.md), [HM-38](Module/HM-38_Such-Pop-up.md), Overlay-Host, Benutzer-/Sprach-/Rezept-Platzhalter | M2-03, M2-05 | – |
| M2-07 | Komposita und Spezialmodule in vier Teilen: a) [HM-20](Module/HM-20_Dosierer-Karte.md) bis [HM-22](Module/HM-22_Gewichtskorrektur-Tabelle.md), [HM-35](Module/HM-35_Regulierungs-Parameterblock.md); b) [HM-28](Module/HM-28_Temperaturzonen-Zeile.md), [HM-29](Module/HM-29_Wochen-Zeitplan.md), [HM-31](Module/HM-31_Leimspuren-Grafik.md); c) [HM-23](Module/HM-23_Nockentabelle.md), [HM-24](Module/HM-24_Nocken-Parameterzeile.md), [HM-26](Module/HM-26_Diagramm.md), [HM-32](Module/HM-32_Packungsregister-Grafik.md); d) [HM-25](Module/HM-25_Meldungsliste.md), [HM-33](Module/HM-33_Zaehlerzeile.md), [HM-34](Module/HM-34_Motor-Statuszeile.md), [HM-36](Module/HM-36_EA-Zeile.md), [HM-37](Module/HM-37_Wertegitter.md) | M2-05 | a bis d untereinander |
| M2-08 | Seiten Gruppe 1: Produktion und Einstieg (`HS-01`, `HS-02`, `HS-03`, `HS-43`, `HS-04`, `HS-40`, `HS-42`, `HS-38`) mit Dummy-Diensten | M2-04, M2-06 | – |
| M2-09 | Seiten Gruppe 2: Zuführungen (`HS-05` bis `HS-10`) | M2-07 b, M2-08 | M2-10 bis M2-14 |
| M2-10 | Seiten Gruppe 3: Dosierer und Schließmaschine (`HS-41`, `HS-11`, `HS-12`, `HS-19` bis `HS-21`, `HS-23`, `HS-16` bis `HS-18`) | M2-07 a, M2-08 | M2-09, M2-11 bis M2-14 |
| M2-11 | Seiten Gruppe 4: Waagen (`HS-13` bis `HS-15`, `HS-27`) | M2-07 c/d, M2-08 | s. o. |
| M2-12 | Seiten Gruppe 5: Maschinenfunktionen (`HS-22`, `HS-24`, `HS-25`, `HS-26`, `HS-28`, `HS-29`, `HS-32`) | M2-07 b/c, M2-08 | s. o. |
| M2-13 | Seiten Gruppe 6: Handbetrieb und EA (`HS-30`, `HS-31`, `HS-33`, `HS-34`) | M2-07 d, M2-08 | s. o. |
| M2-14 | Seiten Gruppe 7: System (`HS-35`, `HS-36`, `HS-37`, `HS-39`) | M2-07 d, M2-08 | s. o. |
| M2-15 | Gesamtprüfung: Build, XAML, Code-behind, Literale, Rückverfolgung, `Pruefbericht_M2.md`, Befunde beheben, Commit und Push | alle | – |

Die Gruppen 1 bis 7 decken zusammen alle 43 Seiten ab (8 + 6 + 10 + 4 + 7 + 4 + 4). Nach [Task.md](../../Task.md) werden zuerst Rahmen, Designsystem und Navigation (M2-01 bis M2-04), dann alle Module (M2-05 bis M2-07), dann alle Seiten (M2-08 bis M2-14) umgesetzt; M2-15 schließt ab. Die Reihenfolge der Gruppen beginnt mit der Produktionsseite, weil sie als einzige Seite mit Design und Rahmen alle Rahmenmodule prüft.

## 8. Prüfstrategie M2 und Übergabe an M3

### 8.1 Prüfstrategie M2 (Cloud, ohne Windows)

Nach [Agent.md](../../Agent.md) Abschnitt 7 kann WPF in der Cloud nur kompiliert, nicht gestartet werden. Prüfungen und ihre Befehle:

| Nr | Prüfung | Verfahren | Erwartung |
|---|---|---|---|
| M2-V01 | Build | `dotnet build src/ApaTec.Hmi.sln -p:EnableWindowsTargeting=true` mit `TreatWarningsAsErrors` | 0 Fehler, 0 Warnungen; ist das SDK nicht installierbar: dokumentieren und statisch prüfen |
| M2-V02 | XAML wohlgeformt | `xmllint --noout` über alle `*.xaml` und `*.resx` | keine Fehler |
| M2-V03 | Code-behind leer | Skript: jede `*.xaml.cs` von Views, Fenstern und `App` enthält nur Namespace, Klasse, Konstruktor, `InitializeComponent()`; Controls zusätzlich nur Dependency-Property-Deklarationen und CLR-Eigenschaften ([A-73](../00_Plan/Annahmen.md)) | keine Treffer außerhalb der Regel |
| M2-V04 | Keine Literale | `grep` nach `#[0-9A-Fa-f]{6,8}`, `Color="`, Zahlenwerten in `Width/Height/Margin/Padding/FontSize` und festen Texten (`Text="[^{]`, `Content="[^{]`) in `Views/` und `Controls/` | keine Treffer |
| M2-V05 | Themen | `Theme.Light.xaml` und `Theme.Dark.xaml` haben dieselben Schlüssel wie [Designsystem](Designsystem.md) 10.1; `.resx` hat alle Schlüssel, die Views verwenden | Schlüsselmengen gleich |
| M2-V06 | Seiten und Module vollständig | 43 Views mit ViewModel und `PageDescriptor`, 38 Controls `HMnn_*`; jedes verwendete Control existiert | Zählung 43 / 38 |
| M2-V07 | Rückverfolgung | jede `HS`- und `HM`-Definition und jeder Prüfpunkt ist umgesetzt (Abgleich in [Rueckverfolgung.md](Rueckverfolgung.md)); jede `HS` nutzt nur vorhandene `HM` | Tabelle ohne offene Zeilen |
| M2-V08 | Navigation | Skript: jede Registry-Route, jeder Elternschlüssel und jedes Funktionsleisten-Ziel aus Navigation 3.3 existiert; Brotkrümel aus der Registry = Tabelle 2 | keine Abweichung |
| M2-V09 | Berichte | `Pruefbericht_M2.md`; nur visuell prüfbare Punkte als „offen für Meilenstein 3“ | Bericht vollständig |

Die Ergebnisse stehen in `Pruefbericht_M2.md`; Fehler werden behoben, nicht nur notiert (Agent.md Abschnitt 8).

### 8.2 Zählbelege dieses Dokuments

Die Zahlen in Abschnitt 3 und 4 sind aus den Dateien berechnet, nicht von Hand gezählt (Erzeugungsskript, nicht Teil des Repositorys). Befehle zum Nachprüfen:

```
ls docs/03_HMI-Konzept/Seiten/HS-*.md | wc -l                      # 43
ls docs/03_HMI-Konzept/Module/HM-*.md | wc -l                      # 38
grep -cE '^\| HS-[0-9]{2} \|' docs/03_HMI-Konzept/Konzept.md        # 43 (Seitentabellen)
grep -cE '^\| \[HM-[0-9]{2}\]\([^)]*\) \| [^|]+ \| `HM[0-9]{2}_' docs/03_HMI-Konzept/Konzept.md   # 38 (Modulkatalog)
```

### 8.3 Übergabe an Meilenstein 3 (nur visuell oder nur auf Windows prüfbar)

Alles, was ohne Windows nicht entscheidbar ist, bleibt offen und kommt in `Pruefbericht_M3.md` und `Offene-Punkte.md` (Agent.md Abschnitt 9):

| Thema | Was in M3 zu prüfen ist |
|---|---|
| Start und Darstellung | Anwendung startet unter .NET 8; Hauptfenster bei 1920 × 1080; Skalierung bei anderer Größe |
| Layout je Seite | alle 43 Seiten gegen Screenshots (`HS-01`, `HS-04`, `HS-06`, `HS-07`, `HS-41`) und Seitenbeschreibung; Raster 4 : 4 : 4, 2 : 3 : 3 : 4 usw. (Designsystem 3.3); Textumbruch bei +40 % Textbreite; Höhenbilanzen (z. B. `HS-02` 728 von 768 px) |
| Touch und Bedienbarkeit | Zielgrößen, Abstände, Trefferbereiche, Lesbarkeit aus 0,6 bis 0,8 m, Totmann-Tasten (Jog, „Manuell“), Haltetasten (Reset) |
| Kontrast und Themen | Hell- und Dunkelthema, Statusfarben, Konturen; Umschalten zur Laufzeit |
| Grafiken | Leimspuren ([HM-31](Module/HM-31_Leimspuren-Grafik.md)), Packungsregister ([HM-32](Module/HM-32_Packungsregister-Grafik.md)), Diagramme ([HM-26](Module/HM-26_Diagramm.md)), Symbole (`Icons.xaml`), Logo (je Thema) |
| Verhalten | Navigation vollständig durchklicken (Verlauf, Brotkrümel, Pop-up-Regeln), Sprachumschaltung, Bildschirm reinigen (Timer, Rückkehr), Uhr |
| Offene Fachfragen | Punkte aus `Offene-Punkte.md` und aus `Pruefbericht_M2.md` („offen für Meilenstein 3“), insbesondere OP-57 (Totmann), OP-60 (Not-Aus), OP-61 (Alarm in `HS-24`), OP-65 (Symbolnamen) |

Hinweis: Das Logo (APA-TEC) liegt nur als Bild im Design-Screenshot vor; eine freigestellte Logo-Datei je Thema (`LogoLight`, `LogoDark`, [HM-02](Module/HM-02_Kopfzeile.md)) ist nicht Teil der Quellen. In M2 steht ein Platzhalter (Text „APA-TEC“ je Thema), in M3 ist die Grafik einzusetzen ([A-78](../00_Plan/Annahmen.md), OP-66, KON-K11).

## 9. Annahmen und Offene Punkte

Vollständige Listen: [Annahmen.md](../00_Plan/Annahmen.md) (79 Annahmen) und [Offene-Punkte.md](../00_Plan/Offene-Punkte.md) (66 offene Punkte, mit Seiten-Index). Die für das Konzept tragenden Entscheidungen:

| Thema | Entscheidung | Annahme / offener Punkt |
|---|---|---|
| Seitenliste | 39 Referenzkapitel = 39 Seiten, `HS` = `RS`; vier Zusatzseiten | A-01, A-33, A-46 |
| Zwischenseiten | `HS-40` Zuführungen, `HS-42` Waagen, `HS-41` Dosierer-Übersicht, `HS-43` Schichtplan (Platzhalter) | A-33, A-36, OP-20, OP-12, OP-02 |
| Brotkrümel | kanonischer Pfad, nicht Verlauf; Beschriftung nach Design | A-34, OP-21, OP-33 |
| Rahmentasten | Schloss, Produktion, Einstellungen, Zurück wandern in die Seitenleiste; Meldungen = `HS-38` | A-35, OP-08 |
| Kachelmenü | 16 Plätze; „Geräte“ und ein Platz reserviert; „Beleuchtung“ als Aktion | A-36, A-29, OP-05 |
| Schließmaschine | `HS-17` und `HS-18` als Unterseiten von `HS-16` | A-11, A-37, OP-23, OP-55 |
| Navigation von `HS-01` | Tasten Papier, Karton, Heizungen schalten Funktionen; Kennzahl Geschwindigkeit öffnet `HS-03` | A-38, OP-10 |
| Handbetrieb, EA | Gruppen-/Kartentasten öffnen `HS-31`/`HS-34`; Such-Pop-up | A-14, A-39, OP-37, OP-40 |
| Pop-ups | Regeln, Tiefe 2, Bestätigungen | A-40, OP-31, OP-63 |
| Berechtigungen | Rollen `Operator < Technician < Service`, nur `HS-36` seitengeschützt | A-41, OP-04, OP-25 |
| Verlauf | Zurück folgt dem Verlauf, Blättern ohne Eintrag, Tiefe 20 | A-42, A-44 |
| Eingabe | Ziffernblock-Dialog als Annahmemodul; Grenzen Dummy | A-20, A-51, A-50, OP-28, OP-30 |
| Farbe und Zustände | Farbe nur Status, Ein neutral, zweiter Kanal Pflicht | A-31, A-57, OP-27, OP-43 |
| Schrift und Maße | Segoe UI, 20 bis 36 px, 8-px-Raster, Stern-Grid 3 : 37, 4 : 3 : 34 : 4 | A-25, A-26 |
| Themen | Hell/Dunkel über zwei Dictionaries, Start nach Windows | A-30 |
| Module | 38 `HM`; Control-Klassen `HM<nn>_<Name>`; Annahmemodule `HM-13`, `HM-38` | A-45, A-56, A-59 |
| Betriebsarten, Meldungen | Service als Warnstatus; Klassen auf Ok/Warnung/Fehler | A-48, A-49, A-72, OP-22 |
| Stützstellen, nIO-Regel | mindestens 3 gültige Paare; nIO als Hinweis | A-64, A-65, OP-45, OP-64 |

**Annahmen aus der Erstellung dieses Dokuments.** Die Entwurfsentscheidungen aus Abschnitt 6 und 10 stehen in [Annahmen.md](../00_Plan/Annahmen.md):

| Nr | Annahme | Eintrag |
|---|---|---|
| KON-A01 | Projektstruktur, Namespaces und Ordner nach Abschnitt 6.1 (Stamm `ApaTec.Hmi`, ein WPF-Projekt, Composition Root in `Program.cs`) | [A-74](../00_Plan/Annahmen.md) |
| KON-A02 | 35 Dienst-Schnittstellen mit Dummy-Implementierungen nach Abschnitt 6.6 | [A-75](../00_Plan/Annahmen.md) |
| KON-A03 | Code-behind-Regel: Views leer bis auf `InitializeComponent()`; Controls als benutzerdefinierte Steuerelemente mit reinen Dependency-Property-Deklarationen | [A-73](../00_Plan/Annahmen.md) |
| KON-A04 | Optionale Modul-Galerie für die visuelle Prüfung in M3 | [A-76](../00_Plan/Annahmen.md) |
| KON-A05 | `IThemeService`, `IClockService`, `ILocalizationService`, `ISettingsService` ergänzen die Dienste aus Navigation 5.2 | [A-77](../00_Plan/Annahmen.md) |
| – | Logo-Platzhalter in M2, Grafik in M3 (OP-66) | [A-78](../00_Plan/Annahmen.md) |
| – | Klarstellungen KON-K01 bis KON-K05, KON-K09 | [A-79](../00_Plan/Annahmen.md) |

## 10. Hinweise zur Konsistenz

Beim Zusammenführen gefundene Widersprüche und Lücken zwischen Seiten, Modulen, Navigation und Annahmen, mit der jeweiligen Entscheidung. Die Spalte „Stand“ nennt die Bereinigung in den Teildokumenten; Einträge „erledigt“ sind dort umgesetzt, „zu bereinigen“ sind Folgearbeiten an den genannten Dateien.

| Nr | Befund | Fundstellen | Entscheidung / Stand |
|---|---|---|---|
| KON-K01 | `HM-05` war uneinheitlich als Rahmenmodul geführt: Die Modulliste zählte 40 Seiten (ohne `HS-15`), `HS-15` schloss `HM-05` aus, `HS-02` (Pop-up) nutzt es als Inhalt. | [HS-15](Seiten/HS-15_Trend.md), [Modulliste](Module/Modulliste.md) | Entscheidung: `HM-05` gilt auf allen Vollseiten außer `HS-24` ([A-79](../00_Plan/Annahmen.md)); `HS-02` Inhaltsverwendung, `HS-03` nicht. Stand: erledigt, Modulliste zählt 41 Seiten inklusive `HS-15` (Prüfpunkt KON-P14) |
| KON-K02 | `HM-16` und HM-16-P05 nannten für `HS-04` ein Raster 5 × 4; `HS-04`, Designsystem 3.3 und Navigation 6.5 legen 16 Plätze in zwei Rastern 2 × 4 plus „Beleuchtung“ fest (A-36). | [HM-16](Module/HM-16_Kachel-Navigation.md), [HS-04](Seiten/HS-04_Einstellungen.md) | Entscheidung: `HS-04` gilt ([A-79](../00_Plan/Annahmen.md)). Stand: erledigt, `HM-16` korrigiert |
| KON-K03 | Navigation Abschnitt 2 sagte, `HS-09` und `HS-10` nennen noch den Bildtitel; beide tragen bereits den Kapitelnamen (OP-33). | [Navigation](Navigation.md), [HS-09](Seiten/HS-09_Heissleim-Druck.md), [HS-10](Seiten/HS-10_Zeitschaltuhr.md) | erledigt, veralteter Satz gestrichen |
| KON-K04 | `HS-24` kündigte die Vollbild-Variante von `HM-02` als noch zu ergänzen an; sie existiert (`ShowMessageLine`). Breite der Vollbild-Kopfzeile unklar. | [HS-24](Seiten/HS-24_Bildschirm-reinigen.md), [HM-02](Module/HM-02_Kopfzeile.md) | erledigt, Hinweis in `HS-24` gestrichen; Kopfzeile ohne Meldezeile über die volle Fensterbreite ([A-79](../00_Plan/Annahmen.md)) |
| KON-K05 | [A-45](../00_Plan/Annahmen.md) nannte 37 Module (HM-01 bis HM-37). | [Annahmen](../00_Plan/Annahmen.md) A-45, A-59 | Entscheidung: 38 Module (`HM-38` aus A-59); Stand: erledigt |
| KON-K06 | Seitennamen weichen in der Schreibweise ab: Die Seitendateien unterscheiden gleichnamige Seiten durch einen Zusatz in Klammern („Motorparameter (Hauptdosierer)“, „Motorparameter (Nachdosierer)“, „Gewichtskorrektur (Nachdosierer)“, „Motorparameter (Schließmaschine)“); die Navigationstabelle nennt „Motorparameter“ bzw. „Gewichtskorrektur“ (`HS-12`, `HS-20`, `HS-21`) und „Motorparameter Schließmaschine“ (`HS-17`, `HS-18`). | [Navigation](Navigation.md) 2, Seitendateien | zu bereinigen: Dieses Dokument nennt die Namen der Seitendateien; Schlüssel `Nav_<Key>_Title` in der `.resx` einmalig festlegen |
| KON-K07 | Navigation 5.2 nannte nur `INavigationService`, `IDialogService`, `IUserSession`; `IThemeService` (Designsystem 8) und `IClockService` (HM-02) kamen hinzu, für Sprachumschaltung zur Laufzeit (OP-03) und gespeicherte Benutzereinstellungen (A-30) fehlte ein Dienst. | [Navigation](Navigation.md) 5.2, [Designsystem](Designsystem.md) 8 und 11 | Entscheidung: `ILocalizationService` und `ISettingsService` werden aufgenommen ([A-77](../00_Plan/Annahmen.md)); Stand: erledigt |
| KON-K08 | Code-behind: Agent.md und die Moduldateien fordern „kein Code-behind außer `InitializeComponent`“, Dependency Properties (A-50) erfordern aber C# in der Control-Klasse. | Moduldateien (Zeile „Control“), [A-50](../00_Plan/Annahmen.md), [Agent.md](../../Agent.md) 7 | Entscheidung: Views leer (nur `InitializeComponent`); `HM<nn>`-Controls sind benutzerdefinierte Steuerelemente mit reinen Dependency-Property-Deklarationen ohne Logik ([A-73](../00_Plan/Annahmen.md)); Skript M2-V03 |
| KON-K09 | Die Spalte „Seiten“ der Modulliste schließt Kompositverwendungen ein (`HM-07` auf `HS-29` über `HM-18`); „Verwendete Module“ der Seiten nennt sie nicht. Erklärt, kein inhaltlicher Fehler. | [Modulliste](Module/Modulliste.md), [HS-29](Seiten/HS-29_Produktionsstatistik.md), [HS-30](Seiten/HS-30_Handbetrieb-Auswahl.md), [HS-33](Seiten/HS-33_EA-Uebersicht.md) | festgehalten in [A-79](../00_Plan/Annahmen.md); in Abschnitt 3 dokumentiert (KON-P09) |
| KON-K10 | Typenbezeichnungen sind uneinheitlich: Navigation 5.1 kennt Seite, Zwischenseite, Vollbild, Pop-up, Z; die Seitentitel tragen „(Pop-up)“, „(Zwischenseite)“, „(Platzhalter)“. | [Navigation](Navigation.md) 5.1, Seitenköpfe | Dieses Dokument bildet auf Vollseite, Pop-up und Zusatz ab (Abschnitt 3); `PageKind` im Code: Page, Popup, Fullscreen |
| KON-K11 | Das Logo ist in `HM-02` je Thema verlangt, liegt aber nur im Design-Screenshot vor. | [HM-02](Module/HM-02_Kopfzeile.md), `src_Data/Design` | Platzhalter in M2, Grafik in M3 ([A-78](../00_Plan/Annahmen.md), OP-66) |
| KON-K12 | Stand von Task.md Phase 3: [Rueckverfolgung.md](Rueckverfolgung.md) liegt vor und ist verlinkt; `Pruefbericht_M1.md` fehlt noch und wird nur textlich erwähnt. | [Task.md](../../Task.md) | nach Fertigstellung des Prüfberichts Link ergänzen und KON-P05 erneut ausführen |

## 11. Prüfpunkte dieses Dokuments

Die Prüfung ist maschinell (Stand der Erstellung); „bestanden“ gilt für den beschriebenen Dateistand.

| ID | Prüfung | Verfahren | Ergebnis |
|---|---|---|---|
| KON-P01 | 43 Seitendateien `HS-01` bis `HS-43` liegen vor | `ls docs/03_HMI-Konzept/Seiten/HS-*.md` zählen | bestanden (43) |
| KON-P02 | Seitentabellen enthalten genau 43 Zeilen, jede ID genau einmal (01 bis 43) | Zeilen `^\| HS-\d\d \|` in Abschnitt 3 zählen und mit 1 bis 43 vergleichen | bestanden |
| KON-P03 | 38 Moduldateien `HM-01` bis `HM-38`; Modulkatalog hat 38 Zeilen, jede ID einmal | Dateien zählen, Zeilen `^\| \[HM-\d\d\]` in Abschnitt 4 zählen | bestanden |
| KON-P04 | Control-Klassen eindeutig, Präfix `HM<nn>_` passt zur ID | Klassen aus der Modulliste parsen | bestanden |
| KON-P05 | alle 474 relativen Links dieses Dokuments lösen auf | jeden Markdown-Link (Text in eckigen, Pfad in runden Klammern) gegen das Dateisystem prüfen | bestanden |
| KON-P06 | Typen: 37 Vollseiten, 2 Pop-ups, 4 Zusatzseiten | Typspalte zählen (Pop-up 2, Vollseite 37, Zusatz 4) | bestanden |
| KON-P07 | Brotkrümel der 43 Zeilen stimmen mit [Navigation](Navigation.md) Abschnitt 2 überein | Spalte gegen Tabelle 2 vergleichen (Pop-ups und `HS-24` mit Zusatz, `<Gruppe>`/`<Karte>` maskiert) | bestanden |
| KON-P08 | jedes der 38 Module wird auf mindestens einer Seite (Hauptmodule) oder als Rahmenmodul verwendet | Vereinigung der Spalte „Hauptmodule“ mit `HM-01` bis `HM-06` | bestanden |
| KON-P09 | Hauptmodule je Seite stimmen mit der Seitenspalte der Modulliste überein (ohne Rahmenmodule) | Mengenvergleich `HM-07` bis `HM-38` | bestanden: einzige Abweichung `HM-07` auf `HS-29` (über `HM-18`, KON-K09) |
| KON-P10 | Seitenregister (Navigation 5.1) enthält 43 eindeutige Schlüssel und Routen | Tabelle 5.1 parsen | bestanden |
| KON-P11 | Design-Vorlage „ja“ für genau 5 Seiten (`HS-01`, `HS-04`, `HS-06`, `HS-07`, `HS-41`), je eine Design-Seite `DS-01` bis `DS-05` | Spalte zählen | bestanden |
| KON-P12 | Quellenzahlen: 79 Annahmen, 66 offene Punkte, 22 `DM`, 36 `RM`, 39 `RS`, 5 `DS` | Zeilen bzw. Dateien zählen | bestanden |
| KON-P13 | Jede Aussage über Funktion, Navigation, Maße und Annahmen verweist auf Teilkonzept, Annahme oder offenen Punkt; neue Annahmen sind als `KON-A..` gekennzeichnet und auf A-73 bis A-79 abgebildet | Durchsicht Abschnitte 5 bis 9 | durchgesehen |
| KON-P14 | `HM-05`: Modulliste zählt 41 Seiten; die Menge (alle Seiten außer `HS-03` und `HS-24`) stimmt mit den Seitendateien („Verwendete Module“) überein, `HS-15` eingeschlossen | Mengenvergleich Modulliste gegen Seitendateien | bestanden |
