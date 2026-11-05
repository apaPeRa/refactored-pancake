# Prüfbericht Meilenstein 3 (Übergabeliste)

- **Status: vorbereitet, Durchführung lokal (Windows).** Dieser Bericht ist in der Cloud als Übergabeliste angelegt (Agent.md Abschnitt 9, „Meilenstein 3 ist lokal“). Alle Ergebnisfelder sind leer und werden bei der Durchführung ausgefüllt; danach wird der Status auf „durchgeführt“ gesetzt und die Abnahme eingetragen (Abschnitt 8).
- Vorbereitet am: 2026-11-05. Stand: Branch nach Meilenstein 2 mit behobenen Restbefunden B-02, B-04, B-05, B-06 (Annahme A-100); B-01 bleibt dokumentierte Abweichung; B-03 (Fortschritt, Task.md, Prüfpunktstatus) ist vom Verwalter fortzuschreiben.
- Durchgeführt am / von: ____ / ____

## 1 Zweck

Meilenstein 3 finalisiert die in der Cloud nur kompilierte und statisch geprüfte WPF-Anwendung (`src/`, .NET 8) unter Windows: starten, jede Seite bei 1920 × 1080 mit Design bzw. Referenz und Seitenbeschreibung vergleichen, Touch, Kontrast, Themen, Sprache und Navigation prüfen, die „offenen für Meilenstein 3“ (M3-01 bis M3-26 aus [Pruefbericht_M2.md](Pruefbericht_M2.md) Abschnitt 7) und die zur Abnahme zu entscheidenden Offenen Punkte abarbeiten, Abweichungen beheben (Fehler werden behoben, nicht nur notiert, Agent.md Abschnitt 8) und die Abnahme dokumentieren.

Vorbereitet wurden (alles ohne Windows erledigbare):

| Ergebnis | Ablage |
|---|---|
| Startparameter der Anwendung (`--page`, `--dialog`, `--theme`, `--culture`, `--role`, `--designdata`) | `src/ApaTec.Hmi/StartupOptions.cs`, `Program.cs`; Beschreibung in `src/README.md` (A-99) |
| Windows-Skripte Build/Start und Screenshot-Aufnahme, Anleitung | `src/tools/windows/Build-And-Run.ps1`, `Capture-Pages.ps1`, `README.md` (nur geschrieben, in der Cloud nicht ausführbar) |
| Abnahmematrix je Seite (43), je Modul (38), Dialoge, Querschnittsliste | [M3_Abnahmematrix.md](M3_Abnahmematrix.md) |
| Restbefunde M2 behoben | A-94 (Klarstellung), B-04 (Einheiten aus `.resx`), B-05 (IsTrailing dokumentiert), B-06 (Async-Navigation), siehe A-100 |
| Übergabepunkte in den Plänen | [Offene-Punkte.md](../00_Plan/Offene-Punkte.md) Abschnitt „Übergabe an Meilenstein 3“, [Fortschritt.md](../00_Plan/Fortschritt.md) |

## 2 Voraussetzungen

| Voraussetzung | Wert |
|---|---|
| Betriebssystem | Windows 10 oder 11 (x64) |
| SDK | .NET 8 SDK (`dotnet --list-sdks` zeigt `8.0.x`); Visual Studio 2022 (Workload „.NET-Desktopentwicklung“) für den Designer (M3-03) oder Claude Code auf dem Zielrechner |
| Anzeige | **1920 × 1080 bei 100 % Skalierung**, ein Monitor; Touch-Bildschirm für M3-08/M3-09/M3-17 (Handschuh und Finger); für M3-23 zusätzlich andere Skalierungen und Mehrmonitor |
| Repository | Branch der Cloud-Session übernehmen (`git fetch origin`, `git checkout <branch>`); `main` nicht verändern; `src_Data/` nie ändern |
| Netzwerk | nur für den ersten `dotnet restore` |
| Hilfsmittel | Kontrastmessung (z. B. Colour Contrast Analyser oder Pipette), Graustufenfilter (Windows: Einstellungen › Barrierefreiheit › Farbfilter), Ausgabefenster/Konsole für Bindungsfehler, Windows-Bildschirmtastatur |
| Referenzbilder | Design `src_Data/Design/*.png` (5 Seiten), Referenz `docs/02_Referenz-Analyse/Medien/RS-xx_01.png`, Seitenbeschreibungen `docs/03_HMI-Konzept/Seiten/HS-xx_*.md` |

## 3 Vorgehen in Reihenfolge (Task.md, Meilenstein 3, Punkt für Punkt)

Alle Befehle im Repository-Wurzelverzeichnis in PowerShell; Einzelheiten und Optionen in `src/tools/windows/README.md`.

### Schritt 1 – Branch übernehmen, Build und Start unter Windows mit .NET 8 (Task.md Punkt 1)
1. Branch auschecken, `.\src\tools\windows\Build-And-Run.ps1` (prüft `dotnet --info`, restore, Release-Build mit Warnungen als Fehler, Start).
2. Erwartung: 0 Fehler, 0 Warnungen; HS-01 erscheint ohne Ausnahme. Schlägt der Start fehl: `dotnet run --project src/ApaTec.Hmi` und Ausnahme ansehen (Risiken in Abschnitt 6).
3. Punkte: **M3-01**, **M3-04**. Zusätzlich Lint wie in der Cloud (`python3 src/tools/check_*.py`, falls Python vorhanden).

### Schritt 2 – Jede Seite bei 1920 × 1080 mit Design/Referenz und Seitenbeschreibung vergleichen (Task.md Punkt 2)
1. Aufnahmen erzeugen: `.\src\tools\windows\Capture-Pages.ps1` (hell und dunkel, nach `docs/04_Pruefung/Screenshots_M3/`); das Skript warnt bei falscher Auflösung/Skalierung.
2. Seite für Seite nach [M3_Abnahmematrix.md](M3_Abnahmematrix.md) Abschnitt 2 abarbeiten: Bildvorlage öffnen, visuelle Prüfpunkte (L/T/K) der HS-Datei prüfen, Ergebnis in der Matrix (Hell, Dunkel, Touch) und Bemerkungen eintragen. Design-Seiten (HS-01, HS-04, HS-06, HS-07, HS-41) gegen `src_Data/Design/`, übrige gegen Referenzbild nur für Funktion und Inhalt (Look kommt aus dem Designsystem), HS-40 bis HS-43 gegen die Seitenbeschreibung.
3. Module nach Abschnitt 3 der Matrix im Designer (`DesignData/HM<nn>_DesignData.xaml`) und auf den einsetzenden Seiten prüfen.
4. Abweichungen sofort beheben (Tokens in `Themes/`, Stile in `Controls/`, Views in `Views/`; keine Literale, kein Code-behind, A-73), Build und Lint wiederholen, Aufnahme erneuern.
5. Punkte: **M3-02**, **M3-03**, **M3-05**, **M3-06**, **M3-07**; Entscheidung B-01 (HM-20 Detail in HS-11/HS-19) beim Bildabgleich.

### Schritt 3 – Touch-Bedienung und Bedienbarkeit (Task.md Punkt 3)
1. Touch-Gerät: Querschnitt Q-04, Q-10 der Matrix (Ziele ≥ 48 px, Standard 64 px, Abstand ≥ 16 px, Handschuh/Finger, Bildschirmtastatur bei Textfeldern, Fokus).
2. Kontrast, Lesbarkeit aus Bedienabstand, Zustände in Graustufen: Q-02, Q-03.
3. Punkte: **M3-08**, **M3-09**, **M3-11**, **M3-13**; Kontrastmessung als Teil von **M3-10**.

### Schritt 4 – Offene Punkte aus `Offene-Punkte.md` und `Pruefbericht_M2.md` abarbeiten (Task.md Punkt 4)
1. Die 26 M3-Punkte (Abschnitt 4) vollständig durchgehen, Ergebnis je Punkt in Abschnitt 8.
2. Die Entscheidungsliste (Abschnitt 5) mit dem Auftraggeber klären; je OP: Annahme bestätigen oder ändern, Konsequenz in HS/HM, Code und `Annahmen.md` nachziehen.
3. Platzhalter ersetzen: Symbole (M3-12), Logo (OP-66), zweite Sprache (M3-18).
4. Punkte: **M3-12**, **M3-14**, **M3-15**, **M3-16**, **M3-17**, **M3-19** bis **M3-22**, **M3-24**, **M3-25**.

### Schritt 5 – Hell/Dunkel, Sprachumschaltung und Navigation einmal vollständig durchklicken (Task.md Punkt 5)
1. Beide Themen: Q-01; Sprachumschaltung: Q-05; Navigation in der Reihenfolge von `Navigation.md` Abschnitt 1: Q-06 (Zurück-Stapel Tiefe 20, Brotkrümel-Sprünge, Home, Einstellungen, Querzugänge); Berechtigungsabläufe: Q-07; Halten/Jog: Q-08.
2. Windows-spezifisch: Q-13 (DPI, Fenstergröße, Mehrmonitor, Bildschirmschoner), Q-14 (Performance, Speicher, Threads).
3. Punkte: **M3-10**, **M3-18**, **M3-23**, **M3-26**.

### Schritt 6 – `Pruefbericht_M3.md` schreiben, Abnahme (Task.md Punkt 6)
1. Dieses Dokument fortschreiben: Status „durchgeführt“, Ergebnisse (Abschnitt 8), gefundene und behobene Abweichungen mit Datei, offen gebliebene Punkte mit Begründung.
2. Abnahme: Endurteil, Datum, Prüfer, Unterschrift der Abnahme (Abschnitt 9). Danach `Task.md` (Meilenstein 3, vom Verwalter) und `Fortschritt.md` abhaken, Commit und Push auf den Branch (nicht `main`).

## 4 Die 26 Punkte aus Meilenstein 2 (M3-01 bis M3-26)

Quelle: [Pruefbericht_M2.md](Pruefbericht_M2.md) Abschnitt 7 (verbindlich). „Wo geprüft“ verweist auf die Matrix ([M3_Abnahmematrix.md](M3_Abnahmematrix.md)). Das Ergebnis steht in Abschnitt 8.

| Nr | Gegenstand (verkürzt) | Wo geprüft |
|---|---|---|
| M3-01 | Build und Start unter Windows mit .NET 8; HS-01 erscheint, keine Ausnahme (`FrameworkElement.LanguageProperty.OverrideMetadata`, Stile/Converter, Dienstregistrierung per Reflection, DI-Konstruktorwahl `DummyUserSession`) | Schritt 1, Q-12 |
| M3-02 | Alle 43 Seiten und 10 Dialoge öffnen ohne Fehler; Bindungsfehler im Ausgabefenster auswerten | Matrix 2, 2.1; Q-06, Q-12 |
| M3-03 | Entwurfsmodus im Designer (parameterlose Konstruktoren, `d:DataContext`) für alle Views | Matrix 3 |
| M3-04 | Dummy-Uhr, Meldungen und Betriebsart aktualisieren die Kopfzeile (`PostToUi`) | Q-12 |
| M3-05 | Jede der 43 Seiten bei 1920 × 1080 mit Screenshots/Seitenbeschreibung vergleichen (Gruppe B) | Matrix 2 |
| M3-06 | Skalierung bei abweichender Fenstergröße, Vollbild HS-24 ohne Rahmen | Q-13, HS-24 |
| M3-07 | Funktionsleiste: Überlauf „Mehr“ ab der 6. Taste, rechtsbündige Gruppe, Popup-Platzierung | Q-13, Matrix (Seiten mit Funktionsleiste) |
| M3-08 | Zielgrößen ≥ 48 px (Standard 64 px), Abstände ≥ 16 px am Touch-Gerät; Handschuh/Finger (Gruppe C) | Q-04, Spalte Touch |
| M3-09 | Windows-Bildschirmtastatur bei Touch-Fokus in der Textvariante (HM-13, Filter) | Q-10, Dialoge `Input`, `Filter` |
| M3-10 | Beide Themen durchklicken (`IThemeService.SetTheme`), Kontrastverhältnisse messen, Lesbarkeit aus Bedienabstand | Q-01, Q-02 |
| M3-11 | Zustände in Graustufen unterscheidbar (Gruppe D), Fehlerrot nur für Fehler | Q-03 |
| M3-12 | 68 Platzhaltersymbole gegen die Designvorlage verfeinern; Logo APA-TEC je Thema (OP-65, OP-66) | Q-15 |
| M3-13 | Tab-Reihenfolge, Fokusring, Enter/Leertaste, Fokus im Pop-up gefangen | Q-10 |
| M3-14 | Totmanntasten HS-31 (Jog +/−): nur solange gedrückt, Stopp beim Loslassen/Seitenwechsel/Fokusverlust, beide Richtungen gleichzeitig | Q-08 |
| M3-15 | Haltetasten (HS-32 Geber setzen, Reset): Fortschrittsstreifen, Haltedauer, Abbruch, Sperrgrund | Q-08 |
| M3-16 | Nachfüllen (WhilePressed) HS-11/HS-19/HS-41 | Q-08 |
| M3-17 | Wischen/Bildlauf in HS-22, HS-25/HS-26, HS-37/HS-38, HS-36 (`PanningMode`), Trägheit, Seitenpfeile | Q-09 |
| M3-18 | Sprachdialog (nur `de-DE` wählbar): Umschaltung zur Laufzeit mit mindestens einer zweiten Ressourcensprache; Dezimalkomma/Datumsformat in allen Eingaben | Q-05 |
| M3-19 | Rollenwechsel: Benutzer-Pop-up, Rückkehr zur Aktion, Rollenverlust auf geschützter Seite (Seite verlassen, Pop-ups schließen) | Q-07 |
| M3-20 | Schlüssel-/Schloss-Symbole und gesperrte Felder an allen Eingaben (HM-12, HM-08, HM-07) | Q-07 |
| M3-21 | Eingabe-Pop-up (Zahl, Zeit, Text): Bereichsprüfung, Fehlertext, Übernehmen gesperrt, Stapeltiefe 2, Navigation dahinter gesperrt | Q-11, Dialog `Input` |
| M3-22 | Bestätigung „Änderungen verwerfen?“ (HS-25), Datei-Pop-up (HS-36/HS-37), Suche (HM-38), Zeitplan-Eintrag (HM-30), Filter, Rezept | Q-11, Matrix 2.1 |
| M3-23 | Hochdpi/Skalierung 100 % bis 150 %, Mehrmonitor, Bildschirmschoner/Energie | Q-13 |
| M3-24 | Performance (Start, Seitenwechsel, HM-26, HM-25), Speicher bei langem Betrieb (Abonnements bei `OnNavigatedFrom` freigeben) | Q-14 |
| M3-25 | Thread-Sicherheit der Dummy-Dienste (Ereignisse aus Hintergrundthreads) | Q-14 |
| M3-26 | Gesamtdurchlauf: Navigation vollständig durchklicken (Stapel Tiefe 20, Brotkrümel-Sprünge, Home, Einstellungen), Abnahme | Q-06 |

Zusätzlich offen aus M2: **B-01** (HM-20 Detail in HS-11/HS-19 ungenutzt; Entscheidung beim Bildabgleich) und **B-03** (Fortschritt, `Task.md`, Prüfpunktstatus: `Fortschritt.md` ist ergänzt; `Task.md` und die 1.004 Prüfpunkt-Statuswerte schreibt der Verwalter nach der Abnahme fort).

## 5 Zur Abnahme zu entscheidende Offene Punkte (Top-Liste)

Aus [Offene-Punkte.md](../00_Plan/Offene-Punkte.md); ausgewählt sind die Punkte, die das Aussehen, die Bedienung oder die Abnahmekriterien beeinflussen und ohne Auftraggeber nicht entscheidbar sind. „Annahme“ ist der aktuell umgesetzte Stand. Entscheidung und Datum sind bei der Abnahme einzutragen.

| OP | Gegenstand | Aktuelle Annahme (umgesetzt) | Entscheidung / Datum |
|---|---|---|---|
| OP-66 | Logo APA-TEC (HM-02) | Platzhalter; freigestellte Grafik je Thema aus dem Design beschaffen oder vom Auftraggeber anfordern (A-78) | |
| OP-65 | Symbolnamen und Dosierer-Symbole (Gewichtsstück, Waagschale, Schnecke); `Icon.Stat.Sigma`/`Icon.Stat.StdDev` doppelt | beide Namen mit gleicher Bedeutung, auf ein Symbol vereinheitlichen; 68 Platzhaltergeometrien verfeinern | |
| OP-03 | Sprache (Pop-up, Funktionsleiste HS-04) | Umschaltung über `.resx`; derzeit nur `de-DE` wählbar, zweite Sprache für den Test anlegen | |
| OP-04, OP-25, OP-31 | Benutzer, Rollen, Schlüsselsymbol, Sperrzustände und Rückfragen | Schlüsselsymbol = berechtigungspflichtiges Feld; Rollen Bediener < Technik < Service als Dummy; Start als Bediener (A-96); gesperrte Elemente sichtbar mit Grund; Stufe je Feld offen | |
| OP-57, OP-42 | Jog (Totmann) und Halte-/Zeitdauern (Reset, langes Drücken, Zeitfenster) | Totmann nur solange gedrückt, Stopp bei Loslassen/Seitenwechsel/Rollenverlust/Störung; Haltedauern als konfigurierbare Dummy-Werte, keine Handbuchwerte | |
| OP-60 | Not-Aus-Bedingung „Geber setzen“ (HS-32) | Taste nur bei gemeldetem Not-Aus, sonst gesperrt mit Grund in der Meldezeile | |
| OP-61 | Alarm während „Bildschirm reinigen“ (HS-24) | Meldungen erfasst, nicht angezeigt; kritischer Alarm beendet die Reinigung | |
| OP-27, OP-43, OP-14 | Farbbedeutungen und Zustände nur über Farbe | Farbe nur für Status, immer mit Text oder Symbol (ISA-101); bildabgeleitete Bedeutungen als Annahme | |
| OP-44, OP-13 | Abgeschnittene/abweichende Bilder, mehrzeilige Kachelbeschriftungen | Layout für 1920 × 1080 neu gesetzt; Kachelwort ohne Trennstrich mit automatischem Umbruch | |
| OP-05, OP-06, OP-12, OP-24 | Leere/reservierte Kacheln (Geräte, Beleuchtung, EKW, Endkontrollwaage) | leere Plätze als Reserve; „Geräte“/„Endkontrollwaage“ deaktiviert mit Grund; „Beleuchtung“ = Schnellzugriff (A-36) | |
| OP-02, OP-01, OP-63 | Schichtplan (HS-43), Rezeptanwahl, Benutzer-/Sprach-/Rezept-Pop-up | Platzhalterseite bzw. Dummy-Pop-ups im Rahmen HM-14 | |
| OP-09, OP-10, OP-11 | Taste „Schnell“, sechs blaue Tasten, Legende „IO/Bereit/Läuft“ (HS-01) | Zustandstaste mit Dummy-Zuständen; Zuführung Papier/Karton aktivieren nur (A-38); „IO“ = in Ordnung | |
| OP-30, OP-28 | Eingabe-Pop-up, Wertebereiche und Standardwerte | gemeinsames Pop-up (Zahlenfeld, Bereichsprüfung gegen konfigurierbare Dummy-Grenzen); keine Grenzen erfunden | |
| OP-17, OP-18, OP-45 | Dosierer: „KW“, Detail-Symbol, Hervorhebung, fachliche Zusammenhänge; mit B-01 | KW unverändert; Symbol = Detailansicht; Hervorhebung = ausgewählt; Berechnung als Dummy | |
| OP-33, OP-34 | Seitentitel und Beschriftungsabweichungen Bild/Handbuch | Handbuchkapitelname = Seitenname; Bildbeschriftung für die Anzeige, einheitliche Schreibweise in `.resx` | |
| OP-56, OP-32 | Einzelgewichte (Sortierrichtung), Trend (20 oder 21 Punkte) | zeilenweise Lesefolge mit Marker an der jüngsten Zelle; 20 Punkte plus aktuellster Wert, konfigurierbar | |
| OP-49, OP-40 | Datei-Pop-up/Export-Format, Suche, Listenverhalten | Dummy-Funktion; Formate und Ziele offen; Suchfeld mit einfacher Filterung | |

Die übrigen OP-Nummern (Fachlogik der Seiten, z. B. OP-45 bis OP-55, OP-58, OP-59, OP-62, OP-64) betreffen die Maschinenanbindung bzw. Fachwissen des Auftraggebers und bleiben offen, sofern sie die Abnahme der Oberfläche nicht beeinflussen; sie sind in [Offene-Punkte.md](../00_Plan/Offene-Punkte.md) Abschnitt „Übergabe an Meilenstein 3“ vermerkt.

## 6 Bekannte Risiken (vorab zu beobachten)

| Risiko | Hintergrund | Wo prüfen / Maßnahme |
|---|---|---|
| **Platzhalter-Icons** | Alle 68 Symbole sind einfache Geometrien im 24 × 24-Raster, nicht die Designvorlage (`Themes/Icons.xaml`, README) | M3-12; Vergleich mit den Design-Screenshots, Strichstärke `Size.Icon.Stroke` |
| **Logo** | Platzhalter in `HM02_HeaderBar.Styles.xaml` (A-78, OP-66) | M3-12; Logo je Thema liefern lassen |
| **Viewbox / Skalierung** | Fenster ist `Size.Window.Width × Height` (1920 × 1080) **einschließlich** Titelleiste/Rahmen; das Layout ist ein Sternraster ohne `Viewbox`; Clientbereich daher kleiner als 1920 × 1080, bei anderer Fenstergröße/DPI ändern sich Proportionen und Textabschneidung | M3-05, M3-06, M3-23; `Capture-Pages.ps1` vergrößert das Fenster auf einen Clientbereich von 1920 × 1080; ggf. Fenster randlos/maximiert festlegen oder `Viewbox` ergänzen |
| **Dictionary-Reihenfolge** | Theme-Dictionary muss in `App.xaml` an erster Stelle stehen (`ThemeService` tauscht das erste Dictionary); `Controls/*.Styles.xaml` werden per `ControlResources.MergeAll` eingebunden, bei gleichem Schlüssel gewinnt das später gemischte Dictionary; Farben nur `DynamicResource`, Maße `StaticResource` | M3-01, M3-10; Themenwechsel zur Laufzeit auf allen Seiten, `XamlParseException` zu fehlenden Ressourcen beim ersten Öffnen |
| **Halten und Jog** | `HM07_PressBehavior` (Press/Release, Capture, `Hold`); Touch wird zu Maus-Ereignissen promotet, Verlust von Capture/Fokus, Mehrfingerbedienung, beide Jog-Richtungen gleichzeitig | M3-14 bis M3-16; Stopp bei Loslassen, Fokus-/Fensterverlust, Seitenwechsel, Rollenverlust |
| **Bildlauf** | `PanningMode`/Trägheit nur am Touch-Gerät prüfbar; Konflikt zwischen Wischen und Tastendruck; HS-22 mit 12 Zonen, Listen HS-36/HS-37/HS-38 | M3-17, Q-09 |
| **Eingabe-Pop-up und Fokus** | Pop-up-Ebene mit Scrim; Fokus muss im Pop-up bleiben; Textvariante (HM-13, Filter, Suche) braucht die Windows-Bildschirmtastatur; Stapeltiefe 2 | M3-09, M3-13, M3-21 |
| **Bindungsfehler** | Bindungspfade wurden in der Cloud nicht geprüft (nur Eigenschaften), 7 Views nur über Kompilieren | M3-02; Ausgabefenster (Debug) filtern auf `BindingExpression` |
| **Direktstart per Parameter** | `--page`/`--dialog` navigieren nach dem Laden des Fensters; Seiten ohne Standardparameter könnten leer erscheinen; `Input` bekommt einen Beispielwert | Aufnahmen kontrollieren; Fehler in der Konsole (`[Start] …`) |
| **Kultur** | `FrameworkElement.LanguageProperty.OverrideMetadata` in `Program.cs` darf nur einmal laufen; nur `de-DE` mit Ressourcen | M3-01, M3-18 |
| **Dummy-Dienste** | Ereignisse aus Hintergrundthreads, Abonnements werden bei `OnNavigatedFrom` freigegeben | M3-24, M3-25 |
| **PowerShell-Skripte** | in der Cloud nicht ausgeführt (kein Windows/PowerShell); erster Lauf kann Anpassungen brauchen | `src/tools/windows/README.md`; Korrekturen dort ablegen |

## 7 Ablageorte

| Was | Wo |
|---|---|
| Screenshots | `docs/04_Pruefung/Screenshots_M3/<HS-xx>_<hell\|dunkel>.png` (Dialoge: `DLG-<Key>_<hell\|dunkel>.png`) |
| Abnahmematrix (Ergebnisse je Seite/Modul/Querschnitt) | `docs/04_Pruefung/M3_Abnahmematrix.md` |
| Dieser Bericht (Übergabeliste, Ergebnisse, Abnahme) | `docs/04_Pruefung/Pruefbericht_M3.md` |
| Entscheidungen zu OP | `docs/00_Plan/Offene-Punkte.md` (Status), `docs/00_Plan/Annahmen.md` (neue Annahmen ab A-101) |
| Korrekturen an Code | `src/ApaTec.Hmi/…` (Views, Controls, Themes, Resources), Skripte `src/tools/windows/` |
| Fortschritt | `docs/00_Plan/Fortschritt.md` |
| Vorgänger | [Pruefbericht_M1.md](Pruefbericht_M1.md), [Pruefbericht_M2.md](Pruefbericht_M2.md) |

## 8 Abnahme-Tabelle je Punkt (leer)

Ergebnis: `bestanden` / `bestanden nach Korrektur` / `Abw. offen` / `n/a`. Bei Korrektur: Datei und Änderung in „Bemerkung“.

| Punkt | Datum | Prüfer | Ergebnis | Bemerkung (Befund, Datei, Korrektur) |
|---|---|---|---|---|
| M3-01 | | | | |
| M3-02 | | | | |
| M3-03 | | | | |
| M3-04 | | | | |
| M3-05 | | | | |
| M3-06 | | | | |
| M3-07 | | | | |
| M3-08 | | | | |
| M3-09 | | | | |
| M3-10 | | | | |
| M3-11 | | | | |
| M3-12 | | | | |
| M3-13 | | | | |
| M3-14 | | | | |
| M3-15 | | | | |
| M3-16 | | | | |
| M3-17 | | | | |
| M3-18 | | | | |
| M3-19 | | | | |
| M3-20 | | | | |
| M3-21 | | | | |
| M3-22 | | | | |
| M3-23 | | | | |
| M3-24 | | | | |
| M3-25 | | | | |
| M3-26 | | | | |
| B-01 (HM-20 Detail) | | | | |
| B-03 (Fortschritt/Task.md/Prüfpunktstatus) | | | | |
| Matrix Abschnitt 2 (43 Seiten) | | | | |
| Matrix Abschnitt 2.1 (Dialoge) | | | | |
| Matrix Abschnitt 3 (38 Module) | | | | |
| Matrix Abschnitt 4 (Q-01 bis Q-15) | | | | |
| OP-Entscheidungen (Abschnitt 5) | | | | |

## 9 Endurteil und Abnahme

| Feld | Eintrag |
|---|---|
| Endurteil | (bestanden / bestanden mit Auflagen / nicht bestanden) |
| Auflagen | |
| Datum der Abnahme | |
| Prüfer | |
| Abnahme durch (Auftraggeber) | |
| Commit / Branch | |
