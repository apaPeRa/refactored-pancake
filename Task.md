# Ziel

Aus Screenshots (neues Design) und einem Referenzhandbuch (altes HMI) wird eine C#-Anwendung mit WPF erstellt, die als Ausgangsbasis für eine neue, moderne Maschinen-HMI dient. Arbeitsregeln, Ordnerstruktur, Dateinamen und Vorlagen stehen in `Agent.md`.

Das Referenzhandbuch (alle Seiten) beschreibt den **Funktionsumfang**. Dieser wird in das **neue Design** übertragen. Zielauflösung 1920 × 1080.

# Meilensteine

| Meilenstein | Ort | Inhalt |
|---|---|---|
| 1 | Cloud | Dokumentation und Konzept (Markdown) |
| 2 | Cloud | WPF-Projekt in XAML, kompiliert und statisch geprüft |
| 3 | Lokal (Windows) | Finalisierung: starten, visuell prüfen, korrigieren |

## Meilenstein 1 – Dokumentation und Konzept

Erstellt aus Design und Referenz mehrere Markdown-Dateien, die das Design erklären, Seiten und Module definieren und prüfen.

### Phase 1 – Design-Analyse
- [ ] Umfang erfassen, Plan nach `docs/00_Plan/Plan_M1.md` schreiben, Ordnerstruktur nach `Agent.md` Abschnitt 5 anlegen, `Fortschritt.md`, `Annahmen.md`, `Offene-Punkte.md` anlegen
- [ ] Alle Screenshots in `./src_Data/Design` analysieren und `Design-Dokumentation.md` erstellen (Rahmen, Raster, Farben, Typografie, Elementarten, Navigation)
- [ ] Je Design-Seite eine Seitenbeschreibung `DS-xx` mit Funktion und Prüfpunkten erstellen
- [ ] Wiederkehrende Elemente erkennen und Module `DM-xx` definieren (Funktion, Parameter, Zustände, Prüfpunkte)
- [ ] Phase 1 gegen die Screenshots prüfen, Commit

### Phase 2 – Referenz-Analyse
- [ ] `Referenz.docx` verarbeiten (Text, Tabellen, Bilder extrahieren nach `02_Referenz-Analyse/Medien`), `Referenz-Uebersicht.md` mit vollständiger Seitenliste und Navigationsbaum erstellen
- [ ] Je Seite im Handbuch (alle) eine Seitenbeschreibung `RS-xx` mit Funktion und Prüfpunkten erstellen, einschließlich Pop-ups und Unterseiten
- [ ] Wiederkehrende Elemente erkennen (z. B. Motorparameter, Gewichtskorrektur, Dosierer-Parameter) und Module `RM-xx` definieren
- [ ] Phase 2 gegen das Handbuch prüfen (jede Tabellenzeile und jedes Bild der Quelle ist erfasst), Commit

### Phase 3 – Neues HMI-Konzept
- [ ] `Designsystem.md`: Farben, Typografie, Abstände, Größen für 1920 × 1080, Zustände, Hell/Dunkel, nach den Vorgaben in `Agent.md` Abschnitt 6
- [ ] `Navigation.md`: Navigationsstruktur und Brotkrümel für alle Seiten
- [ ] Module `HM-xx` aus `DM` und `RM` zusammenführen (Duplikate entfernen)
- [ ] Seiten `HS-xx` für alle Seiten der Referenz im neuen Design (Layout aus dem Design, wo vorhanden; sonst abgeleitet vom Designsystem und den Modulen), in `Konzept.md` zu einer kohärenten Beschreibung zusammenführen
- [ ] `Rueckverfolgung.md`: Tabelle Referenzseite → Designseite → neue Seite, Referenzmodul → Designmodul → neues Modul. Jede RS hat eine HS, jede HS verwendet nur vorhandene HM
- [ ] `Pruefbericht_M1.md` schreiben und Befunde beheben, Commit und Push

## Meilenstein 2 – WPF-Projekt (.NET 8, Cloud)

Erstellt ein WPF-Projekt in `src/` aus dem Konzept von Meilenstein 1 Phase 3. Fokus: Design der Seiten und Module in XAML. Code im Hintergrund ist zu vermeiden (MVVM, siehe `Agent.md` Abschnitt 7).

- [ ] Lösungs- und Projektstruktur, Designsystem als `ResourceDictionary` (Farben, Typografie, Größen, Hell/Dunkel), Hauptfenster 1920 × 1080 mit Rahmen (Seitenleiste, Kopfzeile, Brotkrümel, untere Leiste) und Navigationsdienst
- [ ] Alle Module `HM-xx` als wiederverwendbare Controls mit Dummy-Daten im Entwurfsmodus
- [ ] Alle Seiten `HS-xx` als Views mit ViewModels und Dummy-Daten
- [ ] Gegen die Definitionen prüfen (`Agent.md` Abschnitt 7 und 8), `Pruefbericht_M2.md` schreiben, Befunde beheben, Commit und Push

## Meilenstein 3 – Lokale Finalisierung (Windows)

Wird lokal mit Visual Studio oder Claude Code auf dem Zielrechner durchgeführt, nicht in der Cloud.

- [ ] Branch aus der Cloud übernehmen, Build und Start unter Windows mit .NET 8
- [ ] Jede Seite bei 1920 × 1080 mit den Screenshots und der Seitenbeschreibung vergleichen, Abweichungen korrigieren
- [ ] Touch-Bedienung und Bedienbarkeit prüfen (Ziele, Kontrast, Lesbarkeit aus Bedienabstand)
- [ ] Offene Punkte aus `Offene-Punkte.md` und `Pruefbericht_M2.md` („offen für Meilenstein 3“) abarbeiten
- [ ] Hell/Dunkel-Thema, Sprachumschaltung und Navigation einmal vollständig durchklicken
- [ ] `Pruefbericht_M3.md` schreiben, Abnahme
