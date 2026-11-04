# Agent.md – Arbeitsanweisung

Diese Datei gilt für jede Session in diesem Repository. **Lies zuerst diese Datei, dann `Task.md`, dann `docs/00_Plan/Fortschritt.md` (falls vorhanden).** Mache dort weiter, wo die letzte Session aufgehört hat.

## 1. Projekt

Neue Maschinen-HMI (C# / WPF / .NET 8) für Verpackungsmaschinen der APA-TEC GmbH. Das bestehende HMI (Referenz) wird fachlich in ein neues, modernes Design übertragen. Der Arbeitsablauf steht in `Task.md`.

## 2. Quellen

| Quelle | Pfad | Bedeutung |
|---|---|---|
| Design-Screenshots | `./src_Data/Design/` | Zielrichtung für Aufbau, Layout und Look. Wurde in PowerPoint entworfen und ist **nicht final**. Es sind nur 5 Seiten. |
| Referenzhandbuch | `./src_Data/Referenz/Referenz.docx` | Das **alte** HMI. Maßgeblich für **Funktionsumfang und Seitenliste** (alle Seiten). Enthält Text, ca. 50 Tabellen und ca. 80 Bilder. |

Das Handbuch ist ein Word-Dokument: Text und Tabellen mit `pandoc` oder `python-docx` lesen. Die Bilder extrahieren (`unzip` oder `python-docx`) und **ansehen**, nicht nur den Text auswerten.

### Konfliktregeln
1. **Funktion und Fachlogik:** die Referenz gewinnt.
2. **Layout, Navigation und Optik:** das Design gewinnt, soweit es mit Abschnitt 6 vereinbar ist.
3. Widersprüche und Lücken (z. B. Seiten ohne Design, Design-Elemente ohne Referenz wie Rezeptanwahl, Schichtplan, Sprache, Benutzer) werden **nicht erfunden**, sondern in `docs/00_Plan/Offene-Punkte.md` eingetragen. Die getroffene Annahme steht dabei.

## 3. Arbeitsweise

- Arbeite selbstständig und **frage nicht nach**. Triff die sinnvollste Annahme und dokumentiere sie in `docs/00_Plan/Annahmen.md`.
- Hake erledigte Punkte in `Task.md` ab (`- [x]`) und pflege `docs/00_Plan/Fortschritt.md` (Datum, was erledigt, was als Nächstes).
- Committe nach jeder abgeschlossenen Phase, bei langen Phasen auch zwischendurch. Commit-Nachrichten auf Deutsch, kurz, im Imperativ (z. B. „Seitenbeschreibungen Design ergänzt“). Pushe auf den Branch der Session, **nicht** direkt auf `main`.
- Lösche oder überschreibe nichts in `src_Data/`. Das sind Originale.
- Ein Punkt ist erst erledigt, wenn seine Prüfung bestanden ist (Abschnitt 7).

## 4. Sprache

- Alle Dokumentation: **Markdown, Deutsch** (korrekte Umlaute im Text).
- Code-Bezeichner (Klassen, Eigenschaften, Namespaces): **Englisch**.
- Sichtbare UI-Texte: Deutsch, aus Ressourcendateien (`.resx`), nicht fest im XAML, damit später Mehrsprachigkeit möglich ist (das Design hat eine Schaltfläche „Sprache“).

## 5. Ordnerstruktur und Dateinamen

```
/
├─ Agent.md, Task.md
├─ src_Data/                      Originale (nur lesen)
├─ docs/
│  ├─ 00_Plan/                    Plan_M1.md, Fortschritt.md, Annahmen.md, Offene-Punkte.md
│  ├─ 01_Design-Analyse/          Design-Dokumentation.md
│  │  ├─ Seiten/                  DS-xx_<Name>.md
│  │  └─ Module/                  DM-xx_<Name>.md
│  ├─ 02_Referenz-Analyse/        Referenz-Uebersicht.md (Seitenliste, Navigationsbaum)
│  │  ├─ Seiten/                  RS-xx_<Name>.md
│  │  ├─ Module/                  RM-xx_<Name>.md
│  │  └─ Medien/                  extrahierte Bilder (Name = Seiten-ID + laufende Nr.)
│  ├─ 03_HMI-Konzept/             Konzept.md, Designsystem.md, Navigation.md, Rueckverfolgung.md
│  │  ├─ Seiten/                  HS-xx_<Name>.md
│  │  └─ Module/                  HM-xx_<Name>.md
│  └─ 04_Pruefung/                Pruefbericht_M1.md, Pruefbericht_M2.md, Pruefbericht_M3.md
└─ src/                           WPF-Lösung (Meilenstein 2)
```

**Präfixe:** `DS`/`DM` = Design-Seite/-Modul, `RS`/`RM` = Referenz-Seite/-Modul, `HS`/`HM` = neue HMI-Seite/-Modul.
**Nummerierung:** zweistellig, fortlaufend, bei den Referenz-Seiten in der Reihenfolge des Handbuchs.
**Dateinamen:** `<Präfix>-<Nr>_<Name>.md`. Der Name ist ASCII mit Bindestrich als Trenner und ersetzt Umlaute (ä→ae, ö→oe, ü→ue, ß→ss), z. B. `RS-07_Heissleim-Nordson.md`, `HM-03_Schaltflaeche-Umschalter.md`.
**Querverweise** zwischen Dokumenten verwenden immer die ID und einen relativen Link, z. B. `[HM-03](../Module/HM-03_Schaltflaeche-Umschalter.md)`.
**Prüfpunkt-IDs:** `<Dokument-ID>-P<nn>`, z. B. `RS-07-P03`.

### Vorlage Seite (`DS`, `RS`, `HS`)
```
# <ID> – <Seitenname>
- Quelle: <Screenshot / Handbuchabschnitt>   - Navigationspfad: <Brotkrümel>
## Zweck
## Aufbau (Bereiche, Layout)
## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
## Verwendete Module (IDs)
## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
## Prüfpunkte (Tabelle: ID | Prüfung | erwartetes Ergebnis | Status)
## Offene Punkte
```

### Vorlage Modul (`DM`, `RM`, `HM`)
```
# <ID> – <Modulname>
## Funktion
## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
## Zustände und Darstellung
## Verwendet auf Seiten (IDs)
## Prüfpunkte (Tabelle wie oben)
```
Ein Modul ist ein wiederkehrendes Element (z. B. Statuskopf, Navigationsleiste, Kennzahl-Kachel, Umschalter, Status-LED, Fortschrittsbalken, Eingabefeld mit Schlüsselsymbol, Pop-up-Eingabe, Dosierer-Karte). Ziel ist ein hoher Grad an Wiederverwendung: Gleiches wird **ein** Modul, keine Kopien.

## 6. Design-Vorgaben (neues HMI)

- Zielauflösung **1920 × 1080**, Touch-Bedienung; Layout skalierbar, keine festen Pixelpositionen im Detail, sondern Grid mit Proportionen.
- Modernes, industrietaugliches HMI nach ISA-101-Grundsätzen: ruhiger, kontrastreicher Hintergrund, **Farbe nur für Status und Alarm**, Zustände nie ausschließlich über Farbe (zusätzlich Symbol oder Text), große Touch-Ziele (mindestens 48 px, besser 64 px), klare Hierarchie, keine 3D-Schaltflächen oder Verläufe aus dem PowerPoint-Entwurf.
- Gemeinsame Rahmenelemente aus dem Design bleiben: Seitenleiste mit Benutzer und Navigation, Kopfzeile mit Logo, Meldezeile, Betriebsart und Uhrzeit/Datum, Brotkrümel-Navigation, Kennzahlen Geschwindigkeit und Maschinenwinkel, untere Funktionsleiste.
- Hell- und Dunkelthema über zentrale Ressourcen (`ResourceDictionary`), keine Farben oder Maße direkt in den Seiten.

## 7. Technik (Meilenstein 2)

- C#, **.NET 8**, WPF, Lösung unter `src/`. Architektur **MVVM**: Seiten und Module als `UserControl`/`ControlTemplate` in XAML, **kein Code-behind** außer reiner View-Initialisierung. Logik in ViewModels, Navigation über Dienst, Daten über Schnittstellen mit Dummy-Implementierung (die Maschinenanbindung ist nicht Teil dieses Projekts).
- Erlaubte NuGet-Pakete: `CommunityToolkit.Mvvm`, `Microsoft.Extensions.DependencyInjection`, `Microsoft.Extensions.Hosting`. Weitere nur mit Eintrag in `Annahmen.md`.
- Wiederverwendbare Module haben Namen entsprechend ihrer HM-ID (z. B. `HM03_ToggleSwitch`) und stehen unter `src/.../Controls/`.
- **Cloud-Einschränkung:** WPF läuft nur unter Windows. In der Cloud ist das .NET-8-SDK ggf. zu installieren und es kann nur kompiliert werden (`dotnet build -p:EnableWindowsTargeting=true`). Die Anwendung kann dort weder gestartet noch per Screenshot geprüft werden. Prüfe in der Cloud daher: Build ohne Fehler und Warnungen, XAML wohlgeformt (`xmllint`), Code-behind leer, jede HS/HM-Definition und jeder Prüfpunkt ist umgesetzt (Abgleich in `Rueckverfolgung.md`). Was nur visuell prüfbar ist, wird in `Pruefbericht_M2.md` als „offen für Meilenstein 3“ markiert. Falls das SDK nicht installierbar ist, dokumentiere es und prüfe statisch.

## 8. Prüfen

Jede Seite und jedes Modul hat Prüfpunkte. Nach jedem Arbeitsschritt wird gegen die Quelle geprüft:
- Meilenstein 1: Vollständigkeit (jede Seite und jedes Element der Quelle ist erfasst), Zahlen und Bezeichnungen stimmen mit der Quelle überein, alle Querverweise lösen auf, keine doppelten Module.
- Meilenstein 2: siehe Abschnitt 7.
- Das Ergebnis steht im jeweiligen `Pruefbericht_M*.md`. Fehler werden behoben, nicht nur notiert.
