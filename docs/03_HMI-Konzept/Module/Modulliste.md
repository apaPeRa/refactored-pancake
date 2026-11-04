# Modulübersicht HMI-Module (HM)

Stand: Phase 3, Punkt 3. Die 37 HMI-Module HM-01 bis HM-37 führen die 22 Design-Module ([DM](../../01_Design-Analyse/Module/)) und die 36 Referenz-Module ([RM](../../02_Referenz-Analyse/Module/Modulliste.md)) zusammen. Ein HM je Funktion, Varianten sind Parameter (A-45). Die Seiten-IDs HS-01 bis HS-39 entsprechen den RS-Nummern 1:1, HS-40 bis HS-43 sind Zusatzseiten (A-46, A-33); die HS-Dateien entstehen im nächsten Schritt, die Links in den Moduldateien sind vorläufig. Control-Klassen heißen nach der HM-ID (A-56, `Agent.md` Abschnitt 7). In der Spalte Seiten steht in Klammern die Anzahl der Seiten; sie enthält auch Verwendungen über Kompositmodule (in den Moduldateien vermerkt „inkl. Verwendung über Kompositmodul“). HM-01, HM-04 und HM-05 stehen nicht auf dem Vollbild HS-24.

| HM-ID | Name | Control-Klasse | DM-Herkunft | RM-Herkunft | Seiten |
|---|---|---|---|---|---|
| [HM-01](HM-01_Seitenleiste.md) | Seitenleiste | `HM01_Sidebar` | [DM-01](../../01_Design-Analyse/Module/DM-01_Benutzerkennung.md), [DM-02](../../01_Design-Analyse/Module/DM-02_Navigationsleiste.md) | [RM-03](../../02_Referenz-Analyse/Module/RM-03_Funktionsleiste-unten.md) | HS-01, HS-04 bis HS-23, HS-25 bis HS-43 (40) |
| [HM-02](HM-02_Kopfzeile.md) | Kopfzeile (Logo, Betriebsart, Uhr) | `HM02_HeaderBar` | [DM-03](../../01_Design-Analyse/Module/DM-03_Kopfzeile-Logo.md), [DM-05](../../01_Design-Analyse/Module/DM-05_Betriebsart-Anzeige.md), [DM-06](../../01_Design-Analyse/Module/DM-06_Uhrzeit-und-Datum.md) | [RM-01](../../02_Referenz-Analyse/Module/RM-01_Kopfzeile.md) | HS-01, HS-04 bis HS-43 (41) |
| [HM-03](HM-03_Meldezeile.md) | Meldezeile | `HM03_MessageLine` | [DM-04](../../01_Design-Analyse/Module/DM-04_Meldezeile.md) | [RM-02](../../02_Referenz-Analyse/Module/RM-02_Meldezeile.md) | HS-01, HS-04 bis HS-23, HS-25 bis HS-43 (40) |
| [HM-04](HM-04_Brotkruemel-Navigation.md) | Brotkrümel-Navigation | `HM04_Breadcrumb` | [DM-07](../../01_Design-Analyse/Module/DM-07_Brotkruemel-Navigation.md) | [RM-01](../../02_Referenz-Analyse/Module/RM-01_Kopfzeile.md) | HS-01, HS-04 bis HS-23, HS-25 bis HS-43 (40) |
| [HM-05](HM-05_Kennzahl-Kachel.md) | Kennzahl-Kachel | `HM05_MetricTile` | [DM-08](../../01_Design-Analyse/Module/DM-08_Kennzahl-Kachel.md) | [RM-12](../../02_Referenz-Analyse/Module/RM-12_Kennzahl-Kachel.md) | HS-01, HS-02, HS-04 bis HS-23, HS-25 bis HS-43 (41) |
| [HM-06](HM-06_Funktionsleiste.md) | Funktionsleiste unten | `HM06_FunctionBar` | [DM-09](../../01_Design-Analyse/Module/DM-09_Funktionsleiste.md) | [RM-03](../../02_Referenz-Analyse/Module/RM-03_Funktionsleiste-unten.md) | HS-01, HS-04 bis HS-23, HS-25 bis HS-43 (40) |
| [HM-07](HM-07_Aktionstaste.md) | Aktionstaste (Funktionstaste) | `HM07_ActionButton` | [DM-10](../../01_Design-Analyse/Module/DM-10_Funktionstaste-grau.md) | [RM-11](../../02_Referenz-Analyse/Module/RM-11_Aktionstaste.md) | HS-01, HS-02, HS-04, HS-07, HS-10 bis HS-15, HS-18 bis HS-21, HS-23, HS-25 bis HS-27, HS-29 bis HS-39, HS-41 (30) |
| [HM-08](HM-08_Zustandstaste-Umschalter.md) | Zustandstaste / Umschalter | `HM08_ToggleSwitch` | [DM-13](../../01_Design-Analyse/Module/DM-13_Umschalter.md), [DM-19](../../01_Design-Analyse/Module/DM-19_Zustandstaste.md) | [RM-10](../../02_Referenz-Analyse/Module/RM-10_Umschalter-Taste.md) | HS-01, HS-06 bis HS-08, HS-10, HS-11, HS-14, HS-16, HS-19, HS-22, HS-23, HS-41 (12) |
| [HM-09](HM-09_Status-LED.md) | Status-LED | `HM09_StatusLed` | [DM-14](../../01_Design-Analyse/Module/DM-14_Status-LED.md) | [RM-08](../../02_Referenz-Analyse/Module/RM-08_Status-LED.md) | HS-05, HS-07, HS-08, HS-11, HS-14, HS-19, HS-22, HS-25, HS-26, HS-31, HS-32, HS-34, HS-41 (13) |
| [HM-10](HM-10_Fortschrittsbalken.md) | Fortschrittsbalken | `HM10_ProgressBar` | [DM-18](../../01_Design-Analyse/Module/DM-18_Fortschrittsbalken.md) | [RM-09](../../02_Referenz-Analyse/Module/RM-09_Fortschrittsbalken.md) | HS-07, HS-11, HS-19, HS-24, HS-39, HS-41 (6) |
| [HM-11](HM-11_Anzeigefeld.md) | Anzeigefeld (Wert-Zeile) | `HM11_ValueDisplay` | [DM-15](../../01_Design-Analyse/Module/DM-15_Beschriftung-Wert-Zeile.md), [DM-16](../../01_Design-Analyse/Module/DM-16_Wertfeld-Anzeige.md) | [RM-07](../../02_Referenz-Analyse/Module/RM-07_Anzeigefeld.md) | HS-01, HS-02, HS-05 bis HS-09, HS-11, HS-16, HS-19, HS-22, HS-23, HS-25, HS-27, HS-31, HS-32, HS-34, HS-36, HS-39, HS-41 (20) |
| [HM-12](HM-12_Eingabefeld-Schluesselsymbol.md) | Eingabefeld mit Schlüsselsymbol | `HM12_ValueInput` | [DM-17](../../01_Design-Analyse/Module/DM-17_Eingabefeld-mit-Schluesselsymbol.md) | [RM-05](../../02_Referenz-Analyse/Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) | HS-03, HS-05 bis HS-13, HS-16 bis HS-23, HS-25, HS-27, HS-31, HS-36, HS-39, HS-41 (24) |
| [HM-13](HM-13_Eingabe-Pop-up.md) | Eingabe-Pop-up (Ziffernblock) | `HM13_NumericKeypadDialog` | – | [RM-06](../../02_Referenz-Analyse/Module/RM-06_Eingabe-Pop-up.md) | HS-03, HS-05 bis HS-13, HS-16 bis HS-23, HS-25, HS-27, HS-31, HS-36, HS-37, HS-39, HS-41 (25) |
| [HM-14](HM-14_Popup-Rahmen.md) | Pop-up-Rahmen | `HM14_PopupFrame` | – | [RM-13](../../02_Referenz-Analyse/Module/RM-13_Pop-up-Rahmen.md) | HS-01 bis HS-03, HS-05 bis HS-13, HS-16 bis HS-23, HS-25, HS-27, HS-31, HS-36, HS-37, HS-39, HS-41 (27) |
| [HM-15](HM-15_Gruppenbereich.md) | Gruppenbereich | `HM15_GroupPanel` | [DM-11](../../01_Design-Analyse/Module/DM-11_Gruppenbereich.md) | [RM-15](../../02_Referenz-Analyse/Module/RM-15_Gruppenrahmen.md) | HS-01, HS-04 bis HS-07, HS-09, HS-12, HS-16, HS-17, HS-20, HS-23 (11) |
| [HM-16](HM-16_Kachel-Navigation.md) | Kachel-Navigation | `HM16_TileNavigation` | [DM-12](../../01_Design-Analyse/Module/DM-12_Kachel-Taste.md) | [RM-14](../../02_Referenz-Analyse/Module/RM-14_Kachel-Navigation.md) | HS-01, HS-04, HS-30, HS-33, HS-35, HS-40, HS-42 (7) |
| [HM-17](HM-17_Titelzeile.md) | Titelzeile (Objektüberschrift) | `HM17_TitleBar` | [DM-21](../../01_Design-Analyse/Module/DM-21_Titelzeile-mit-Verschiebesymbol.md) | [RM-25](../../02_Referenz-Analyse/Module/RM-25_Objekt-Ueberschrift.md) | HS-27, HS-31, HS-32, HS-34, HS-41 (5) |
| [HM-18](HM-18_Auswahlfeld-Pfeiltasten.md) | Auswahlfeld mit Pfeiltasten | `HM18_SelectorField` | – | [RM-32](../../02_Referenz-Analyse/Module/RM-32_Auswahlfeld-mit-Pfeiltasten.md) | HS-10, HS-15, HS-25, HS-27, HS-29 (5) |
| [HM-19](HM-19_Blaettertasten.md) | Blättertasten | `HM19_PagerButtons` | – | [RM-04](../../02_Referenz-Analyse/Module/RM-04_Blaettertasten.md) | HS-11, HS-12, HS-19, HS-20, HS-25 bis HS-27, HS-31, HS-32, HS-34, HS-39, HS-41 (12) |
| [HM-20](HM-20_Dosierer-Karte.md) | Dosierer-Karte / Dosierer-Seitengerüst | `HM20_DosingCard` | [DM-20](../../01_Design-Analyse/Module/DM-20_Dosierer-Karte.md) | [RM-18](../../02_Referenz-Analyse/Module/RM-18_Dosierer-Seitengeruest.md) | HS-11, HS-19, HS-41 (3) |
| [HM-21](HM-21_Motorparameter-Karte.md) | Motorparameter-Karte | `HM21_MotorParameterCard` | – | [RM-16](../../02_Referenz-Analyse/Module/RM-16_Motorparameter-Karte.md) | HS-12, HS-17, HS-20 (3) |
| [HM-22](HM-22_Gewichtskorrektur-Tabelle.md) | Gewichtskorrektur-Tabelle | `HM22_WeightCorrectionTable` | – | [RM-17](../../02_Referenz-Analyse/Module/RM-17_Gewichtskorrektur-Tabelle.md) | HS-18, HS-21 (2) |
| [HM-23](HM-23_Nockentabelle.md) | Nockentabelle | `HM23_CamTable` | – | [RM-19](../../02_Referenz-Analyse/Module/RM-19_Nockentabelle.md) | HS-26 (1) |
| [HM-24](HM-24_Nocken-Parameterzeile.md) | Nocken-Parameterzeile | `HM24_CamParameterRow` | – | [RM-20](../../02_Referenz-Analyse/Module/RM-20_Nocken-Parameterzeile.md) | HS-16, HS-25 (2) |
| [HM-25](HM-25_Meldungsliste.md) | Meldungsliste | `HM25_MessageList` | – | [RM-21](../../02_Referenz-Analyse/Module/RM-21_Meldungsliste.md) | HS-36 bis HS-39 (4) |
| [HM-26](HM-26_Diagramm.md) | Diagramm (Trend / Balken) | `HM26_Chart` | – | [RM-22](../../02_Referenz-Analyse/Module/RM-22_Trend-Diagramm.md), [RM-30](../../02_Referenz-Analyse/Module/RM-30_Tagesbalkendiagramm.md) | HS-15, HS-29 (2) |
| [HM-27](HM-27_Hinweis-Textfeld.md) | Hinweis-Textfeld | `HM27_NoticeBox` | – | [RM-23](../../02_Referenz-Analyse/Module/RM-23_Hinweis-Textfeld.md) | HS-11, HS-19, HS-22, HS-27, HS-31, HS-32, HS-41 (7) |
| [HM-28](HM-28_Temperaturzonen-Zeile.md) | Temperaturzonen-Zeile | `HM28_HeatZoneRow` | – | [RM-24](../../02_Referenz-Analyse/Module/RM-24_Temperaturzonen-Zeile.md) | HS-08, HS-22 (2) |
| [HM-29](HM-29_Wochen-Zeitplan.md) | Wochen-Zeitplan | `HM29_WeekSchedule` | – | [RM-26](../../02_Referenz-Analyse/Module/RM-26_Wochen-Zeitplan.md) | HS-10 (1) |
| [HM-30](HM-30_Zeitplan-Eintrag-Pop-up.md) | Zeitplan-Eintrag-Pop-up | `HM30_ScheduleEntryDialog` | – | [RM-27](../../02_Referenz-Analyse/Module/RM-27_Zeitplan-Eintrag-Pop-up.md) | HS-10 (1) |
| [HM-31](HM-31_Leimspuren-Grafik.md) | Leimspuren-Grafik | `HM31_GlueTrackGraphic` | [DM-22](../../01_Design-Analyse/Module/DM-22_Leimspuren-Grafik.md) | [RM-28](../../02_Referenz-Analyse/Module/RM-28_Leimspuren-Grafik.md) | HS-06 (1) |
| [HM-32](HM-32_Packungsregister-Grafik.md) | Packungsregister-Grafik | `HM32_PackRegisterGraphic` | – | [RM-29](../../02_Referenz-Analyse/Module/RM-29_Packungsregister-Grafik.md) | HS-28 (1) |
| [HM-33](HM-33_Zaehlerzeile.md) | Zählerzeile | `HM33_CounterRow` | – | [RM-31](../../02_Referenz-Analyse/Module/RM-31_Zaehlerzeile.md) | HS-02 (1) |
| [HM-34](HM-34_Motor-Statuszeile.md) | Motor-Statuszeile | `HM34_DriveStatusRow` | – | [RM-33](../../02_Referenz-Analyse/Module/RM-33_Motor-Statuszeile.md) | HS-39 (1) |
| [HM-35](HM-35_Regulierungs-Parameterblock.md) | Regulierungs-Parameterblock | `HM35_RegulationBlock` | – | [RM-34](../../02_Referenz-Analyse/Module/RM-34_Regulierungs-Parameterblock.md) | HS-23 (1) |
| [HM-36](HM-36_EA-Zeile.md) | EA-Zeile (Signalzeile) | `HM36_IoRow` | – | [RM-35](../../02_Referenz-Analyse/Module/RM-35_EA-Zeile.md) | HS-34 (1) |
| [HM-37](HM-37_Wertegitter.md) | Wertegitter (Einzelgewichte) | `HM37_ValueGrid` | – | [RM-36](../../02_Referenz-Analyse/Module/RM-36_Wertegitter.md) | HS-14 (1) |

## Zusammenführungen (Duplikate entfernt)

| HM | Zusammengeführt aus | Variante als Parameter |
|---|---|---|
| HM-01 | DM-01 + DM-02 (+ RM-03 feste Tasten) | Seitenleiste mit Benutzerkennung und Navigation |
| HM-02 / HM-03 | DM-03, DM-05, DM-06 + RM-01 / DM-04 + RM-02 | Kopfzeile ohne Meldezeile; Meldezeile eigenes Modul |
| HM-04 | DM-07 (+ Seitentitel aus RM-01) | Objektkennung als Zusatz |
| HM-05 | DM-08 + RM-12 | Größe Rahmen/Inhalt, bedienbar |
| HM-06 | DM-09 + RM-03 | rechte Gruppe, Aktuelle Seite |
| HM-07 | DM-10 + RM-11 | Auslösung Antippen/Halten/Dauer, Schlüssel |
| HM-08 | DM-13 + DM-19 + RM-10 | Darstellung Schalter/Taste, Textumschaltung |
| HM-09 | DM-14 + RM-08 | einzeln/Liste/kompakt, Fachsymbol |
| HM-10 | DM-18 + RM-09 | Schwellen, Beschriftungsplatz |
| HM-11 | DM-15 + DM-16 + RM-07 | Feld/Zeile, Zähler, rücksetzbar, Wertart |
| HM-12 | DM-17 + RM-05 | Zahl/Zeit/Text, mit/ohne Schlüssel, Zähler |
| HM-15 | DM-11 + RM-15 | Panel/Überschrift |
| HM-16 | DM-12 + RM-14 | Raster, Kachelgröße, leere Kachel |
| HM-17 | DM-21 + RM-25 | Überschrift/mit Kennwerten |
| HM-20 | DM-20 + RM-18 | Kompakt/Detail, Haupt-/Nachdosierer |
| HM-26 | RM-22 + RM-30 | Linie/Balken |
| HM-31 | DM-22 + RM-28 | – |

## Hierarchie (Komposition, keine Kopien)

Rahmen: HM-01, HM-02 (enthält HM-03), HM-04, HM-05, HM-06 (enthält HM-07, HM-08, HM-19). Grundelemente: HM-07 bis HM-12, HM-15, HM-16, HM-18, HM-19, HM-27. Pop-ups: HM-14 trägt HM-13 und HM-30. Komposita aus Grundelementen: HM-20 (HM-07 bis HM-12), HM-21, HM-22, HM-23, HM-24, HM-28, HM-33, HM-34, HM-35, HM-36, HM-37, HM-29, HM-31. Spezialdarstellungen: HM-25, HM-26, HM-32.

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HM-MOD-P01 | Herkunft vollständig | jedes DM-01 bis DM-22 und jedes RM-01 bis RM-36 steht in mindestens einem HM | offen |
| HM-MOD-P02 | Querverweise | alle Links auf DM, RM und HM lösen auf; HS-Links vorläufig | offen |
| HM-MOD-P03 | Eindeutigkeit | je Funktion ein HM; Control-Klassen eindeutig | offen |
| HM-MOD-P04 | Pflichtmodule | Rahmenelemente, Tasten, LED, Balken, Eingabefeld, Pop-ups, Karten, Tabellen, Listen, Diagramme, Zeitplan, Grafiken, Kachel-Navigation, Hinweis-Textfeld vorhanden | offen |
