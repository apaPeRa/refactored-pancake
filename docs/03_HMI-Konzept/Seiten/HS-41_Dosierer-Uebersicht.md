# HS-41 – Dosierer-Übersicht
- Quelle: Design [DS-04](../../01_Design-Analyse/Seiten/DS-04_Dosierer.md) (Screenshot `src_Data/Design/Seite_Dosierer.png`); keine RS-Datei (Zusatzseite, A-33). Funktion und Fachlogik der Karten aus [RS-11](../../02_Referenz-Analyse/Seiten/RS-11_Hauptdosierer-1-und-2.md) (Hauptdosierer 1 & 2) und [RS-19](../../02_Referenz-Analyse/Seiten/RS-19_Nachdosierer.md) (Nachdosierer); Kachel „Dosierer“ aus [DS-02](../../01_Design-Analyse/Seiten/DS-02_Einstellungen.md), Zuordnung [RS-04](../../02_Referenz-Analyse/Seiten/RS-04_Einstellungen.md) (Funktionen 3 „Hauptdosierer“ und 6 „Nachdosierer“); [Navigation.md](../Navigation.md) Abschnitt 6.5.
- Navigationspfad: Einstellung › Dosierer (Zugang: [HS-04](HS-04_Einstellungen.md) Kachel „Dosierer“; Zurück-Ziel HS-04)

## Zweck
Übersicht und Schnellbedienung der drei Schneckendosierer (Hauptdosierer 1, Hauptdosierer 2, Nachdosierer) auf einer Seite: Sollwert, Regulierwert, Trichterfüllstand oben/unten, Zu-/Abschalten von Querschnecke, Rührer und Regulierung, Auslastung sowie die Aktionen „Manuell“ und „Entleeren“. Die Titelzeile zeigt Sollgewicht und letztes Gewicht der Kontrollwaage. Das Symbol mit den vier Pfeilen in jeder Karte öffnet die Detailseite des Dosierers ([HS-11](HS-11_Hauptdosierer-1-und-2.md) bzw. [HS-19](HS-19_Nachdosierer.md)); dort liegen alle Parameter (Eichdosierung, Drehzahl, Rührer, Motorparameter, Regulierung). Die Übersicht verdrängt die Einzelkacheln „Hauptdosierer“ und „Nachdosierer“ aus HS-04 (A-36, OP-12).

## Aufbau (Bereiche, Layout)
Rahmen nach [Designsystem](../Designsystem.md) Abschnitt 3.2 (Seitenleiste 3\*, Arbeitsbereich 37\*; Zeilen Kopfzeile 4\* : Brotkrümel 3\* : Inhalt 34\* : Funktionsleiste 4\*). Inhaltsbereich im 12-Spalten-Raster (Designsystem 3.3: „DS-04 Dosierer: Titelzeile über 12 Spalten, darunter 3 Karten 4 : 4 : 4“):

1. **Zeile 1 (Höhe Auto, mindestens `Size.Touch.Default`):** Titelzeile über alle 12 Spalten ([HM-17](../Module/HM-17_Titelzeile.md) mit zwei Kennwerten).
2. **Zeile 2 (Stern, Rest der Inhaltshöhe):** drei Dosierer-Karten ([HM-20](../Module/HM-20_Dosierer-Karte.md), Darstellung Kompakt), je 4 von 12 Spalten, Abstand `Space.M` zwischen Karten und zur Titelzeile. Reihenfolge links nach rechts: Hauptdosierer 1, Hauptdosierer 2, Nachdosierer (wie DS-04).
3. **Funktionsleiste unten leer, aber sichtbar** (Design DS-04; Navigation.md Abschnitt 3.3).

Innenaufbau jeder Karte (Innenabstand `Space.M`, `Radius.Card`, Fläche `Brush.Surface`, Kontur `Border.Thin`), von oben nach unten als Zeilen eines Grids; alle Zeilen mit Touch-Ziel mindestens `Size.Touch.Default`, keine Scroll-Fläche:

```
+--------------------------------------------------------------+
| Einstellung > Dosierer                    | Geschw. | Winkel |
+--------------------------------------------------------------+
| Sollgewicht KW: 235 g | Letztes Gewicht KW: 238 g            |  Titelzeile (HM-17)
+----------------------+----------------------+----------------+
| Hauptdosierer 1  [<>]| Hauptdosierer 2  [<>]| Nachdosierer [<>]|  Kopf + Detail-Symbol
| Soll 48 % entspr 113g| Soll ...             | Soll ...       |
| Regulierwert 5,30 g  |                      | (Hinweis nIO)  |
| Füllstand: oben (LED+Wort) unten (LED+Wort) |    |                |
| Querschnecke [Ein]   |                      |                |
| Rührer       [Ein]   |                      |                |
| Regulierung  [Ein]   |                      |                |
| Auslastung [== 92 %] |                      |                |
| [Manuell][Entleeren] |                      |                |
+----------------------+----------------------+----------------+
| Funktionsleiste (leer)                                       |
+--------------------------------------------------------------+
```

Die drei Karten sind identisch aufgebaut (Variante Hauptdosierer bzw. Nachdosierer nur bei Soll, Hinweiszeile und Detailziel).

**Höhenbilanz (1920 × 1080, Maße aus den Tokens des Designsystems):**

| Posten | Rechnung | Höhe (px) |
|---|---|---|
| Inhaltsbereich | 34\* der Rahmenzeilen (Designsystem 3.2) | 816 |
| minus Außenrand `Space.L` oben und unten | 2 × 24 | 768 |
| minus Titelzeile (`Size.Touch.Default`) und Abstand `Space.M` | 64 + 16 | 688 (Kartenhöhe) |
| minus Innenabstand der Karte `Space.M` oben und unten | 2 × 16 | **656 verfügbar** |
| Kopf (Titel `Font.Size.Value`, Detail-Symbol Trefferbereich `Size.Touch.Min`) | | 48 |
| Zeile „Soll … entspricht …“ (`Font.Size.Body`, Zeilenhöhe) | | 32 |
| Zeile „Regulierwert“ | | 32 |
| Zeile Füllstand Trichter: Beschriftung, LED „oben“ und LED „unten“ nebeneinander in einer Zeile (LED 32 in Zeile ≥ 48) | | 48 |
| 3 Schalterzeilen (je `Size.Touch.Default`) mit 2 Abständen `Size.Touch.Gap` | 3 × 64 + 2 × 16 | 224 |
| Zeile Auslastung: Beschriftung links, Balken (`Size.Progress.Height`) | | 40 |
| Tastenzeile „Manuell“, „Entleeren“ (`Size.Touch.Default`) | | 64 |
| 6 Abstände zwischen den 7 Blöcken (`Space.M`) | 6 × 16 | 96 |
| **Summe Normalfall** | 48+32+32+48+224+40+64+96 | **584** |
| Fehlerfall Nachdosierer: Hinweis ersetzt die Zeile „Regulierwert“ (Warnfläche, Caption, 2 Zeilen mit Kontur und Innenabstand ca. 64 statt 32) | 584 + 32 | **616** |
| Reserve | 656 − 616 | 40 |

Damit passt der Karteninhalt ohne Scrollen, auch im Fehlerfall. Die Rechnung gilt für die Werte der Tokens in Designsystem.md Abschnitt 3 und 7; Änderungen an `Size.*` sind erneut zu rechnen (HS-41-P19). Bei 4 von 12 Spalten ist die Karte rund 560 breit (innen rund 528); die Füllstandzeile (Beschriftung, 2 × LED mit Wort) und die zwei Tasten (je mindestens `Size.Button.MinWidth`) passen nebeneinander. Der Abstand zwischen den Touch-Zielen beträgt überall mindestens `Size.Touch.Gap`.

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Herkunft: DS = Design [DS-04](../../01_Design-Analyse/Seiten/DS-04_Dosierer.md), RS-11/RS-19 = Referenzseiten mit Tabelle (T14/T15/T16 bzw. T27/T28/T29).

### Rahmen und Titelzeile
| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Seitenleiste (Benutzerkreis „MM“, Home, Einstellungen, Meldungen, Zurück), Kopfzeile mit Logo, Meldezeile, Betriebsart, Uhrzeit/Datum, Kennzahlen Geschwindigkeit und Maschinenwinkel, Funktionsleiste (leer) | Rahmen | wie alle Vollseiten; Rahmenwerte im Design sind Dummy (112 1/min, 245°, 9:15, 06.01.2026, Meldung 014) (DS-04 Rahmen, OP-22) | [HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md) |
| Brotkrümel „Einstellung › Dosierer“ | Navigation | Pfad, 2 Segmente; „Einstellung“ antippbar → HS-04, „Dosierer“ nur Anzeige (DS-04 Brotkrümel; A-34) | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) |
| Titelzeile „Sollgewicht KW: 235 g \| Letztes Gewicht KW: 238 g“ | Anzeigezeile mit 2 Kennwerten | Soll- und Istgewicht der Kontrollwaage; Abkürzung „KW“ unverändert übernommen (DS-04 Titelzeile, OP-17); Einheit g mit geschütztem Leerzeichen (Designsystem Abschnitt 2); Abweichungsprüfung (`DeviationLimit`) nicht belegt, daher aus (null) | [HM-17](../Module/HM-17_Titelzeile.md) |
| Symbol Vierfachpfeil (`Icon.Move`) rechts in der Titelzeile | Symboltaste | Funktion im Design nicht beschrieben (DS-04, OP-17); da kein Ziel existiert, im Konzept ausgeblendet (`DetailCommand` = null, Annahme 4) | [HM-17](../Module/HM-17_Titelzeile.md) |

### Dosierer-Karte (3 Instanzen: Hauptdosierer 1, Hauptdosierer 2, Nachdosierer)
Je Karte [HM-20](../Module/HM-20_Dosierer-Karte.md) (Darstellung Kompakt; `DoserKind` Main bzw. Secondary), zusammengesetzt aus HM-07 bis HM-11 (HM-20 enthält keine Kopien).

| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Karte „Hauptdosierer 1“ | Dosierer-Karte | Dosierer 1; Detail-Parameter `doserIndex` = 1 (DS-04 Karte; RS-11, RS-04 T4 Nr. 3) | [HM-20](../Module/HM-20_Dosierer-Karte.md) |
| Karte „Hauptdosierer 2“ | Dosierer-Karte | Dosierer 2; `doserIndex` = 2 (DS-04; RS-11: „Es gibt eine Seite … für Hauptdosierer 1 und 2“) | [HM-20](../Module/HM-20_Dosierer-Karte.md) |
| Karte „Nachdosierer“ | Dosierer-Karte (Variante Nachdosierer, hervorgehoben) | Nachdosierer (DS-04; RS-19, RS-04 T4 Nr. 6) | [HM-20](../Module/HM-20_Dosierer-Karte.md) |
| Titel der Karte (Text) | Beschriftung | Name des Dosierers, `Font.Size.Value` | [HM-20](../Module/HM-20_Dosierer-Karte.md) |
| Detail-Symbol (`Icon.Move`, `Size.Icon.L`) oben rechts in jeder Karte | Symboltaste | öffnet die Detailseite: HD 1/HD 2 → [HS-11](HS-11_Hauptdosierer-1-und-2.md) mit `doserIndex`; Nachdosierer → [HS-19](HS-19_Nachdosierer.md) (DS-04 „Symbol Verschieben/Vollbild je Karte“, OP-17: „öffnet vermutlich Detailseite“; Navigation.md Abschnitt 2) | [HM-20](../Module/HM-20_Dosierer-Karte.md) (`OpenDetailCommand`), [HM-07](../Module/HM-07_Aktionstaste.md) |
| „Soll“ mit Prozentwert „48 %“ und „entspricht“ „113 g“ (Hauptdosierer) | 2 Anzeigewerte | Soll als Anteil am Zielgewicht der Kontrollwaage und abzufüllendes Gewicht („Soll absolut“) (DS-04 „Soll / 48 % / entspricht / 113 g“; RS-11 T14 Nr. 1 „Soll“, Nr. 2 „Soll absolut“); nur Anzeige in der Übersicht, Eingabe in HS-11 | [HM-11](../Module/HM-11_Anzeigefeld.md) |
| „Soll“ mit Gewichtswert in g (Nachdosierer) | Anzeigewert | Zielgewicht des Produkts (RS-19 T27 Nr. 1 „Soll“, Bildwert 250 g); „entspricht“ entfällt, weil der Nachdosierer kein Prozent-Soll hat (Referenz gewinnt, Annahme 2; Design zeigt in der dritten Karte dieselben Dummywerte wie in den anderen) | [HM-11](../Module/HM-11_Anzeigefeld.md) |
| „Regulierwert“ „5,30 g“ | Anzeigewert | aktueller Korrekturwert der Regulierung (DS-04; RS-11 T14 Nr. 5 „Regulierung Ist“, RS-19 T27 Nr. 6); Anzeige, Eingabe in HS-11/HS-19 | [HM-11](../Module/HM-11_Anzeigefeld.md) |
| „Füllstand Trichter“ „oben:“ | Status-LED (Symbol + Wort) | Sensor oberer Trichterbereich (DS-04 LED grün; RS-11 T14 Nr. 10, RS-19 T27 Nr. 11); zweiter Kanal: `Icon.Status.Ok`/`Error` und Wort „OK“/„Fehler“ | [HM-09](../Module/HM-09_Status-LED.md) |
| „Füllstand Trichter“ „unten:“ | Status-LED (Symbol + Wort) | Sensor unterer Trichterbereich (DS-04; RS-11 T14 Nr. 11, RS-19 T27 Nr. 12) | [HM-09](../Module/HM-09_Status-LED.md) |
| Umschalter „Querschnecke“ | Zustandstaste (Schalter) | Querschnecke an-/abwählen; „Abwählen: kein Produkt wird in den Trichter nachgefüllt“ (DS-04; RS-11 T15 Nr. 2, RS-19 T28 Nr. 1); Schlüsselsymbol wie in der Referenz | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) |
| Umschalter „Rührer“ | Zustandstaste (Schalter) | Rührer im Trichter an-/abwählen (DS-04; RS-11 T15 Nr. 3, RS-19 T28 Nr. 2); Schlüsselsymbol wie in der Referenz | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) |
| Umschalter „Regulierung“ | Zustandstaste (Schalter) | automatische Regulierung an-/abwählen (DS-04 „Regulierung“; RS-11 T15 Nr. 7 „Regulierung aktiv“, RS-19 T28 Nr. 6); ohne Schlüsselsymbol wie in der Referenz | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) |
| „Auslastung:“ Balken „92 %“ | Fortschrittsbalken | Anteil der verfügbaren Zeit, den der Dosiervorgang benötigt (DS-04; RS-11 T14 Nr. 12, RS-19 T27 Nr. 13); neutrale Füllung, Zahl im Balken; Warnung (Statusfarbe, `Icon.Status.Warning`) ab Schwelle (Annahme 90 %, HM-10, OP-27) | [HM-10](../Module/HM-10_Fortschrittsbalken.md) |
| Taste „Manuell“ | Aktionstaste (Antippen, mit Schlüsselsymbol) | fordert einen Dosiervorgang an (DS-04; RS-11 T15 Nr. 4, RS-19 T28 Nr. 3); `Icon.Manual` optional | [HM-07](../Module/HM-07_Aktionstaste.md) |
| Taste „Entleeren“ | Aktionstaste (Dauerfunktion, mit Schlüsselsymbol) | Dosierer fördert kontinuierlich, bis abgebrochen wird (DS-04; RS-11 T15 Nr. 5, RS-19 T28 Nr. 4); Zustand „Läuft“ mit Wort; `Icon.Empty` optional | [HM-07](../Module/HM-07_Aktionstaste.md) |
| Hinweiszeile „Fehlmenge größer als Max. Nachgabe: nicht dosiert, Packung nIO“ (nur Nachdosierer, nur im Fehlerfall `RefillResult` = RejectedTooMuch; ersetzt dann die Zeile „Regulierwert“, sonst nicht sichtbar) | Hinweis-Textfeld (Warnung) | macht die nIO-Logik sichtbar (RS-19 T27 Nr. 4 „Max. Nachgabe“, HM-20-P06); im Design nicht abgebildet. HM-20 definiert die Hinweiszeile bisher in der Detaildarstellung; die Kompaktkarte braucht sie zusätzlich (Meldung an den Querschnitts-Agenten) | [HM-27](../Module/HM-27_Hinweis-Textfeld.md) |
| Hervorhebung der Karte „Nachdosierer“ (hellblau im Design) | Kartenzustand „Ausgewählt“ | Kontur `Border.Thick` `Brush.Border.Focus`, zweiter Kanal: Text „Ausgewählt“ und `Icon.State.On` im Titel; Bedeutung „ausgewählt/aktiv“ ist Annahme (DS-04, OP-18), Datenquelle `IsSelected` (Dummy) | [HM-20](../Module/HM-20_Dosierer-Karte.md), [HM-15](../Module/HM-15_Gruppenbereich.md) (`IsHighlighted`, `HighlightText`) |
| Heller dargestellte Tasten „Manuell“/„Entleeren“ bei Hauptdosierer 2 | Zustand „Deaktiviert“ | im Design abgeblendet; wird als „durch Betriebszustand nicht bedienbar“ gelesen (OP-18): gestrichelte Kontur, `Brush.Text.Disabled`, Grund per Antippen als Info-Text in der Meldezeile (A-28) | [HM-07](../Module/HM-07_Aktionstaste.md) |

### Rückverfolgung: Elemente der Referenz, die nicht auf HS-41 liegen
Diese Elemente von RS-11/RS-19 sind bewusst nur auf den Detailseiten, weil das Design (DS-04) sie in der Übersicht nicht zeigt; Funktion und Zugang bleiben erhalten:

| Referenz-Element | Ziel im neuen HMI |
|---|---|
| RS-11 T14 Nr. 3, 4, 6, 7, 8, 9 (Eichdosierung Umdrehungen, Eichdosierung, Schnecke Drehzahl, Rührer, Nachlauf Rührer, Querschnecke als Sollwerte) und RS-19 T27 Nr. 2, 3, 4, 5, 7, 8, 9, 10 (inkl. Max. Nachgabe, Aktuelle Nachgabe) | [HS-11](HS-11_Hauptdosierer-1-und-2.md) bzw. [HS-19](HS-19_Nachdosierer.md) über das Detail-Symbol |
| RS-11 T15 Nr. 6 / RS-19 T28 Nr. 5 Taste „Eichdosierung“ | HS-11 bzw. HS-19 |
| RS-11 T15 Nr. 1 „Einstellung Regulierung“, RS-19 T29 Nr. 3 „Regulierung“ | HS-11 bzw. HS-19 → [HS-23](HS-23_Regulierung.md) |
| RS-11 T16 Nr. 1 Pfeiltasten HD 1 ⇄ HD 2 | nur HS-11/HS-12; in der Übersicht nicht nötig (beide Karten sichtbar) |
| RS-11 T16 Nr. 2 „Motorparameter“, RS-19 T29 Nr. 2 | HS-11 → [HS-12](HS-12_Motorparameter.md), HS-19 → [HS-20](HS-20_Motorparameter.md) |
| RS-19 T29 Nr. 1 „Gewichtskorrektur“ | HS-19 → [HS-21](HS-21_Gewichtskorrektur.md) |

## Verwendete Module (IDs)
- Rahmen: [HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md) (enthält [HM-03](../Module/HM-03_Meldezeile.md)), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md)
- Inhalt: [HM-17](../Module/HM-17_Titelzeile.md), [HM-20](../Module/HM-20_Dosierer-Karte.md) (3 ×; setzt ein: [HM-07](../Module/HM-07_Aktionstaste.md), [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md), [HM-09](../Module/HM-09_Status-LED.md), [HM-10](../Module/HM-10_Fortschrittsbalken.md), [HM-11](../Module/HM-11_Anzeigefeld.md)), [HM-27](../Module/HM-27_Hinweis-Textfeld.md) (Hinweis nIO), [HM-15](../Module/HM-15_Gruppenbereich.md) (nur für Hervorhebungsdarstellung „Ausgewählt“)
- Nicht verwendet: HS-41 nutzt [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](../Module/HM-13_Eingabe-Pop-up.md), [HM-14](../Module/HM-14_Popup-Rahmen.md) und [HM-19](../Module/HM-19_Blaettertasten.md) nicht (Werteingabe und Blättern liegen auf HS-11/HS-19, Annahme 1)

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- **Navigation:** Detail-Symbol einer Karte öffnet HS-11 (HD 1/HD 2, `doserIndex` 1/2) bzw. HS-19; Brotkrümel „Einstellung“ → HS-04; Seitenleiste „Zurück“ folgt dem Verlauf (normal HS-04). Rückweg aus HS-11 und HS-19 ist HS-41 (Verlauf). Navigation ändert keinen Maschinenzustand.
- **Umschalter:** Antippen sendet den Sollzustand; bis zur Rückmeldung Zustand „Ausstehend“ (`Icon.State.Pending`, Text „Wird gesetzt“); Ein: Knopf rechts, Wort „Ein“ und `Icon.State.On`; Aus: Knopf links, Wort „Aus“ und `Icon.State.Off` (HM-08; Grün ist nicht „Ein“, Designsystem 1.2). Im Design stehen alle neun Umschalter auf Ein.
- **Aktionstasten:** „Manuell“ löst auf Antippen genau einen Dosiervorgang aus; „Entleeren“ ist Dauerfunktion bis zum Abbruch, Zustand „Läuft“ (`Icon.State.On`, Wort „Läuft“); Abbruch durch erneutes Antippen (Referenz nennt „bis der Vorgang abgebrochen wird“ ohne Bedienweg, Annahme 3). Bestätigungsdialog nicht beschrieben (OP-31).
- **Berechtigungen:** Seite frei zugänglich (Navigation.md 5.1). Auf Feld-/Tastenebene tragen „Querschnecke“, „Rührer“, „Manuell“, „Entleeren“ das Schlüsselsymbol wie in RS-11/RS-19 (Schlüssel = berechtigt, Schloss = Rolle fehlt, Tippen ohne Rolle öffnet das Benutzer-Pop-up; Rolle Dummy, OP-04, OP-25); „Regulierung“ ohne Schlüssel wie in der Referenz. Das Design zeigt keine Schlüsselsymbole auf dieser Seite; Referenz gewinnt bei der Berechtigung (Annahme 5).
- **Sperrzustände:** Deaktivierte Tasten und Schalter (z. B. „Manuell“/„Entleeren“ bei Hauptdosierer 2 im Design): gestrichelte Kontur, Text `Brush.Text.Disabled`, Grund als Info-Text in der Meldezeile (A-28). Gesperrt durch Berechtigung: `Icon.Lock` und Text „Berechtigung erforderlich: <Rolle>“.
- **Trichter-LEDs:** Ok (Haken, Wort „OK“), Fehler (Kreuz, Wort „Fehler“, z. B. unterer Sensor meldet leer, HM-20), Aus/Unbekannt „---“ (HM-09). Die Zuordnung Sensorzustand → LED-Zustand ist Dummy (OP-27).
- **Auslastung:** 92 % im Design gelb; im Konzept neutrale Füllung bis zur Schwelle, darüber Warnfläche mit `Icon.Status.Warning` und Zahl (Schwelle Annahme 90 %, OP-27).
- **Nachgabe verweigert (nur Nachdosierer, nur im Fehlerfall):** Hinweiszeile HM-27 (Warnung) statt der Zeile „Regulierwert“ mit Text „Fehlmenge größer als Max. Nachgabe: nicht dosiert, Packung nIO“ (HM-20-P06, RS-19 T27 Nr. 4).
- **Fehlerfälle:** gestörte Funktion eines Schalters zeigt Fehlerzustand (Kontur `Border.Thick` `Brush.Status.Error.Fg`, Fehlertext, HM-08); Dosierer ohne Daten: Werte „---“.
- **Pop-ups:** keine eigenen. Eingabe-Pop-up und Zählerwerte-Eingabe liegen auf HS-11/HS-19. Bei offenem Pop-up Seite gesperrt, Meldezeile nur Anzeige (Navigation.md 4.2).
- **Seitenleiste:** „Einstellungen“ ist hervorgehoben.

## Prüfpunkte
Grundlage: DS-04-P01 bis P12 (Design) und die Referenzfunktionen RS-11/RS-19 (Zeilenbezug in der Elemente-Tabelle).

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-41-P01 | Brotkrümel (DS-04-P01) | „Einstellung › Dosierer“; „Einstellung“ antippbar (→ HS-04), „Dosierer“ nur Anzeige | offen |
| HS-41-P02 | Titelzeile (DS-04-P02) | „Sollgewicht KW: 235 g \| Letztes Gewicht KW: 238 g“ (Beispielwerte), Einheit mit geschütztem Leerzeichen | offen |
| HS-41-P03 | Karten (DS-04-P03) | drei Karten in der Reihenfolge Hauptdosierer 1, Hauptdosierer 2, Nachdosierer, je 4 von 12 Spalten | offen |
| HS-41-P04 | Soll je Karte (DS-04-P04) | Hauptdosierer: „Soll 48 %“ und „entspricht 113 g“, Regulierwert „5,30 g“ (Beispielwerte); Nachdosierer: „Soll“ in g, kein Prozentwert (RS-19 T27 Nr. 1) | offen |
| HS-41-P05 | Trichter (DS-04-P05) | je Karte 2 Status-LEDs „oben“ und „unten“ mit Symbol und Wort, Zustand Ok in der Ansicht | offen |
| HS-41-P06 | Umschalter je Karte (DS-04-P06) | Querschnecke, Rührer, Regulierung je Karte; Zustand mit Wort „Ein“/„Aus“ und Symbol, nicht nur Position oder Farbe | offen |
| HS-41-P07 | Auslastung (DS-04-P07) | je Karte Balken mit Zahl „92 %“ im Balken; bei Wert ab Schwelle Warnfläche mit `Icon.Status.Warning` | offen |
| HS-41-P08 | Tasten je Karte (DS-04-P08) | „Manuell“ und „Entleeren“ je Karte; „Entleeren“ zeigt im Zustand Läuft das Wort „Läuft“ | offen |
| HS-41-P09 | Hervorhebung (DS-04-P09, OP-18) | Karte „Nachdosierer“ trägt Text „Ausgewählt“ und `Icon.State.On`, Kontur `Border.Thick`; Hervorhebung nicht nur über Farbe | offen |
| HS-41-P10 | Symbol Vierfachpfeil (DS-04-P10) | in jeder Karte oben rechts vorhanden (Detail); in der Titelzeile nicht vorhanden (Annahme 4, OP-17) | offen |
| HS-41-P11 | Detailziele | Symbol in Karte HD 1 → HS-11 mit `doserIndex` 1; HD 2 → HS-11 mit 2; Nachdosierer → HS-19; „Zurück“ führt jeweils nach HS-41 | offen |
| HS-41-P12 | Funktionsleiste (DS-04-P11) | leer, aber sichtbar | offen |
| HS-41-P13 | Rahmenwerte (DS-04-P12) | Rahmen wie die übrigen Seiten (Dummywerte 112 1/min, 245°, 9:15, 06.01.2026) | offen |
| HS-41-P14 | Rückverfolgung RS-11/RS-19 | alle Zeilen aus der Rückverfolgungstabelle sind auf HS-11/HS-19/HS-12/HS-20/HS-21/HS-23 vorhanden; Übersicht zeigt Soll, Regulierung Ist, Füllstand oben/unten, Querschnecke, Rührer, Regulierung aktiv, Auslastung, Manuell, Entleeren | offen |
| HS-41-P15 | nIO-Hinweis | Nur im Fehlerfall zeigt der Nachdosierer anstelle der Zeile „Regulierwert“ bei `RefillResult` = RejectedTooMuch Hinweis mit `Icon.Status.Warning` und Text „… nicht dosiert, Packung nIO“ (HM-20-P06) | offen |
| HS-41-P16 | Berechtigung | Schlüsselsymbol an Querschnecke, Rührer, Manuell, Entleeren; keines an Regulierung; ohne Rolle öffnet Antippen das Benutzer-Pop-up (Dummy) | offen |
| HS-41-P17 | Deaktivierter Zustand | deaktivierte Tasten gestrichelt und `Brush.Text.Disabled`; Antippen zeigt den Grund in der Meldezeile (A-28) | offen |
| HS-41-P18 | Touch-Ziele und Abstände | alle Tasten, Schalterzeilen und das Detail-Symbol Trefferbereich mindestens `Size.Touch.Min`, Tasten und Schalterzeilen `Size.Touch.Default`; Abstand mindestens `Size.Touch.Gap` | offen |
| HS-41-P19 | Layout ohne Überlauf | Höhenbilanz: Karteninhalt 584 (Normalfall) bzw. 616 (nIO-Hinweis ersetzt „Regulierwert“) bei verfügbaren 656 bei 1920 × 1080, ohne Scrollen; Rechnung neu prüfen, wenn `Size.*`-Tokens geändert werden; Beschriftungen automatisch umbrechend | offen |
| HS-41-P20 | Zweiter Kanal | Ein/Aus (Symbol und Wort), LED (Symbol und Wort), Warnung Auslastung (Symbol und Zahl), Ausgewählt (Text und Symbol), Deaktiviert (gestrichelt) – keine Information nur über Farbe | offen |
| HS-41-P21 | Tokens | keine Hex-, Pixel- oder Literalwerte; blaue Titelzeile und hellblaue Karte des Entwurfs durch Tokens `Brush.Surface.Sunken`/`Brush.Surface`/`Brush.Border.Focus` ersetzt; Rot/Grün nur als Status | offen |
| HS-41-P22 | Hell/Dunkel | beide Themen: Text auf Karten mindestens 4,5 : 1 (Designsystem Abschnitt 1) | offen |
| HS-41-P23 | Zugang HS-04 | Kachel „Dosierer“ in HS-04 öffnet HS-41; Einzelkacheln „Hauptdosierer“/„Nachdosierer“ gibt es in HS-04 nicht mehr (A-36) | offen |

## Offene Punkte
- OP-17: Bedeutung von „KW“ und der Vierfachpfeil-Symbole (Annahme: Detail).
- OP-18: Bedeutung der Hervorhebung des Nachdosierers und der abgeblendeten Tasten bei Hauptdosierer 2.
- OP-15: Abgleich DS-04 mit Referenz (Hauptdosierer 1 & 2, Nachdosierer); OP-45: fachliche Zusammenhänge Soll, Soll absolut, Regulierung; OP-39: Hauptdosierer 2 ohne Screenshot.
- OP-07: Detailseiten ohne Design; OP-12: Zuordnung der Kachel „Dosierer“.
- OP-25/OP-04: Berechtigungsstufen (Dummy); OP-27: Farb-/Schwellenbedeutung (Auslastung, LED); OP-28/OP-29: Wertebereiche und Einheiten (g, %).
- OP-08, OP-21: Seitenleisten-Symbole und Antippbarkeit der Brotkrümel; OP-22: Rahmenwerte Dummy; OP-31: Bestätigungen für „Entleeren“.

## Annahmen dieser Seite
1. Die Übersicht zeigt Sollwerte und Regulierwert nur als Anzeige ([HM-11](../Module/HM-11_Anzeigefeld.md)); Werteingabe (HM-12, HM-13, HM-14) und Blättern (HM-19) liegen auf HS-11/HS-19 (DS-04 zeigt keine Eingabefelder und keine Schlüsselsymbole an Werten).
2. Nachdosierer-Karte: „Soll“ in g ohne „entspricht“ (RS-19 T27 Nr. 1); die identischen Dummywerte der dritten Karte im Design sind keine fachliche Vorgabe.
3. „Entleeren“ wird durch erneutes Antippen abgebrochen (Referenz nennt den Abbruch, aber keinen Bedienweg).
4. Das Vierfachpfeil-Symbol in der Titelzeile hat keine bekannte Funktion und kein Ziel und entfällt; die Symbole in den Karten öffnen die Detailseiten (OP-17).
5. Schlüsselsymbole der Referenz (Querschnecke, Rührer, Manuell, Entleeren) gelten auch in der Übersicht; Regulierung bleibt ohne Schlüssel.
