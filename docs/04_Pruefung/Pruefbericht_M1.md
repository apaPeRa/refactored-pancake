# Prüfbericht Meilenstein 1

- Gegenstand: Gesamtprüfung Meilenstein 1 (Dokumentation und Konzept), Stand Branch `claude/nice-curie-u22ycb`, letzter Commit `3ee5c37`.
- Prüfdatum: 2026-11-04.
- Prüfer: unabhängiger Gesamt-Prüf-Agent (hat die Erstellung nicht gesehen), nach `Agent.md` Abschnitte 8 und 9.
- Methode: Skriptprüfung und Stichprobe. Die Skripte liegen im Scratchpad `/tmp/claude-0/-home-user-refactored-pancake/654f0234-74a7-5806-871e-2cb9095687b7/scratchpad/` (`c1.py` Struktur und Links, `c3.py` Vorlagen und Prüfpunkte, `c4c.py` Tabellenzellen, `c4d.py` bis `c4g.py` Bilder, `c5.py` bis `c5d.py` Rückverfolgung und Beidseitigkeit, `c6.py` bis `c6d.py` Konsistenz). Es wurde keine Datei außer diesem Bericht geändert.

## 1 Endurteil

**NICHT BESTANDEN** (knapp). Die inhaltliche Vollständigkeit gegenüber den Quellen ist gegeben: Zählwerte, Tabellenzellen, Bilder, Rückverfolgung, Querverweise und `src_Data` sind in Ordnung. Es bleiben fünf Befunde mittlerer Schwere (Abschnitt 4: B-01 bis B-05), die laut `Agent.md` Abschnitt 8 behoben und nicht nur notiert werden müssen, und sechs Befunde niedriger Schwere. Nach Behebung von B-01 bis B-05 ist der Meilenstein 1 aus Sicht dieser Prüfung bestanden; ein Wiederholungslauf der Skripte genügt.

## 2 Ergebnis je Prüfpunkt der Beauftragung

| Nr. | Prüfung | Ergebnis |
|---|---|---|
| 1 | Ordnerstruktur und Dateien nach `Agent.md` Abschnitt 5; Dateinamen | bestanden |
| 2 | Relative Markdown-Links lösen auf | bestanden (6.817 Links, 0 defekt, 1 bekannter Platzhalter) |
| 3 | Vorlagenkonformität und Prüfpunkt-IDs | teilweise: 1 doppelte ID (B-01), Abweichungen der Abschnittsliste niedrig (N-01) |
| 4 | Zählwerte gegen die Quellen, Tabellenzellen, Bilder | bestanden |
| 5 | Rückverfolgung, Modulabbildung, Beidseitigkeit | bestanden |
| 6 | Konsistenz Designsystem, Navigation, Konzept, Seiten; Annahmen- und OP-IDs; Arbeitsnotizen | teilweise: Arbeitsnotizen und IDs ohne Kennung (B-02 bis B-04) |
| 7 | `Agent.md` Abschnitt 6 an 8 HS-Seiten | bestanden |
| 8 | `src_Data` unverändert | bestanden |
| 9 | Prüfpunkt-Status | bestanden (alle „offen“, zulässig, siehe Abschnitt 3.9) |
| – | Pflege von `Fortschritt.md` und `Task.md` (`Agent.md` Abschnitt 3) | nicht bestanden (B-05) |

## 3 Prüfdetails

### 3.1 Ordnerstruktur und Dateinamen

Vorhanden und vollständig nummeriert, ohne Lücke und ohne Überzähliges:

| Bereich | Soll | Ist |
|---|---|---|
| `00_Plan`: Plan_M1, Fortschritt, Annahmen, Offene-Punkte | 4 | 4 |
| `Design-Dokumentation.md` | 1 | 1 |
| `DS-01` bis `DS-05` | 5 | 5 |
| `DM-01` bis `DM-22` | 22 | 22 |
| `Referenz-Uebersicht.md` | 1 | 1 |
| `RS-01` bis `RS-39` | 39 | 39 |
| `RM-01` bis `RM-36` (+ `Modulliste.md`) | 36 | 36 |
| `Medien` (PNG, `RS-nn_mm.png`; + `Medienliste.md`) | 81 | 81 |
| `Konzept`, `Designsystem`, `Navigation`, `Rueckverfolgung` | 4 | 4 |
| `HM-01` bis `HM-38` (+ `Modulliste.md`) | 38 | 38 |
| `HS-01` bis `HS-43` | 43 | 43 |

Alle Dateinamen sind ASCII und entsprechen dem Muster `<Präfix>-<nn>_<Name>.md` (Bindestrich als Trenner, Umlaute ersetzt). Die Zusatzdateien `Modulliste.md` (RM, HM) und `Medienliste.md` sind in `Agent.md` Abschnitt 5 nicht genannt, sind aber sinnvolle Ergänzungen und kein Befund. Die leeren `.gitkeep`-Dateien sind unschädlich. Der Ordner `04_Pruefung` enthielt vor diesem Bericht nur `.gitkeep`; `Pruefbericht_M2.md` und `Pruefbericht_M3.md` gehören zu späteren Meilensteinen.

### 3.2 Links

- Geprüft wurden alle relativen Markdown-Links und Bildlinks in `docs/**/*.md` (Codeblöcke ausgenommen): **6.817**.
- Aufgelöst: 6.816. Defekt: **0**.
- Bekannter Platzhalter: `docs/00_Plan/Annahmen.md` mit `../Module/DM-xx_Name.md` (1, beabsichtigt, Schreibweisenbeispiel).
- Links mit Sprungmarke (`#`) kommen nicht vor.
- Alle Verweise auf IDs liegen im gültigen Bereich (HS bis 43, HM bis 38, RS bis 39, RM bis 36, DM bis 22, DS bis 5). „HS-44“ kommt dreimal nur als Hinweis auf künftige IDs vor (Annahmen A-33, Navigation 6.3, HS-42) und ist zulässig.

### 3.3 Vorlagenkonformität und Prüfpunkte

- 183 Dokumente (5 DS, 22 DM, 39 RS, 36 RM, 43 HS, 38 HM) haben je mindestens 3 Prüfpunkte; insgesamt **1.755 Zeilen** in Prüfpunkt-Tabellen.
- Format `<Dokument-ID>-Pnn` überall richtig, Präfix jeweils gleich der Dokument-ID, jede Tabellenzeile hat 4 Spalten (ID, Prüfung, erwartetes Ergebnis, Status; Zellen mit `\|` wurden korrekt behandelt).
- Lückenlos und fortlaufend ab P01 in 182 von 183 Dokumenten. **Ausnahme:** `HM-23` (B-01).
- Eindeutig: 1.754 verschiedene IDs, eine doppelt (`HM-23-P05`).
- Alle im Text zitierten Prüfpunkt-IDs (2.317 Nennungen) existieren.
- Seitenvorlage (7 Abschnitte: Zweck, Aufbau, Elemente, Verwendete Module, Zustände und Interaktion, Prüfpunkte, Offene Punkte) und Modulvorlage (5 Abschnitte): Alle Pflichtabschnitte sind in allen Dokumenten vorhanden. Die Kopfzeile `# <ID> – <Name>` stimmt überall. Abweichungen siehe N-01.

### 3.4 Zählwerte gegen die Quellen

| Größe | Quelle | Dokumentation | Ergebnis |
|---|---|---|---|
| Design-Screenshots | 5 PNG in `src_Data/Design` | 5 DS | stimmt |
| Handbuchkapitel (Überschrift 2) | 39 | 39 RS, Namen und Reihenfolge stimmen | stimmt |
| Tabellen | 50 (`python-docx`) | 50, Zuordnung zu Kapiteln über Dokumentreihenfolge | stimmt |
| Bildverweise `w:drawing` | 83 | 81 Bilder + 2 Textfelder (RS-22, RS-32, in `Medienliste.md` dokumentiert) | stimmt |
| Bilder (`a:blip`) | 81 (44 im Fließtext, 37 in Tabellen) | 81 Dateien, Verteilung je Kapitel identisch | stimmt |
| Bilddateien | – | alle 81 byteidentisch (MD5) mit den Originalen in `word/media` | stimmt |

**Tabellenzellen:** Geprüft wurden nicht nur 15, sondern **alle 50 Tabellen** (684 verschiedene nicht leere Zellen). Jede Zelle wurde (nach Normalisierung von Leerraum, Markdown-Zeichen und Typografie) im zugehörigen RS-Dokument gesucht. 680 Zellen wortgleich gefunden. 4 Zellen weichen nur im Format ab, nicht im Inhalt (Zeilenumbruch der Quelle als Semikolon, Strichtyp, Klammerzeichen), siehe N-05. Es fehlt keine Tabellenzelle.

**Bilder:** Jede der 81 Dateien ist im Dokument der eigenen Seite verlinkt (38 eingebettet mit `![](…)`, übrige als Link und in Medienliste/RM). Keine Datei ist unreferenziert. Mehrfach verwendete Originale (z. B. `RS-12_01.png`) sind zusätzlich von den Seiten verlinkt, die sie wiederverwenden; das ist beabsichtigt.

### 3.5 Rückverfolgung

- **Jede RS hat eine HS:** `HS-01` bis `HS-39` entsprechen den `RS-01` bis `RS-39` 1:1; die „Quelle“-Zeile jeder HS nennt die eigene RS. `HS-40` bis `HS-43` sind dokumentierte Zusatzseiten (A-33, A-46).
- **Jede HS nutzt nur vorhandene HM:** 0 unbekannte HM-Verweise in allen HS- und HM-Dateien. Jede HS nennt mindestens ein HM; jedes der 38 HM wird auf mindestens einer HS verwendet.
- **Elemente gegen Verwendete Module:** Alle in den Elementetabellen genannten HM stehen auch unter „Verwendete Module“ (einzige Auffälligkeit: `HS-43` nennt `HM-07` mit dem Zusatz „auf HS-01“, Zugangstaste liegt auf HS-01; kein Befund).
- **Beidseitigkeit HM ↔ HS:** Jedes HM, das eine HS als Verwendung listet, steht in deren „Verwendete Module“. Umgekehrt nennen die HS-Abschnitte zusätzlich HM nur in Negation („nicht verwendet“: HM-19 in HS-19, HS-20, HS-41; HM-12, HM-13, HM-14 in HS-41; HM-01, HM-03, HM-04, HM-05, HM-06 in HS-24); das ist konsistent.
- **Modulliste HM:** Spalten DM-Herkunft, RM-Herkunft und Seiten (einschließlich der Zählung in Klammern) stimmen für alle 38 HM mit den Moduldateien („Herkunft“, „Verwendet auf Seiten“) überein. Einzige Auffälligkeit: `HM-38` nennt unter „Herkunft“ den Auslöser `RM-14`, in der Modulliste steht „–“ (beabsichtigt: „keine Entsprechung“, A-59).
- **Jedes DM und jedes RM ist auf ein HM abgebildet:** DM-01 bis DM-22 und RM-01 bis RM-36 kommen in mindestens einer „Herkunft“ vor (0 fehlen). Zwei RM sind bewusst auf zwei HM aufgeteilt (RM-01 auf HM-02 und HM-04, RM-03 auf HM-01 und HM-06; Rahmenelemente), alle anderen auf genau ein HM.
- **Keine doppelten Module:** Die 38 HM-Titel sind fachlich verschieden, Varianten sind Parameter (A-45). Es wurden keine Kopien gefunden.
- **RM ↔ RS und DM ↔ DS:** Die Spalten „Seiten“ der RM-Modulliste (Anzahl und Liste) stimmen mit den Abschnitten „Verwendet auf Seiten“ der RM und den „Verwendete Module“ der RS überein (0 Abweichungen). Gleiches gilt für DM und DS (Bereichsangabe „DM-01 bis DM-09“ in den DS berücksichtigt).
- Alle 43 HS, 38 HM sind in `Konzept.md` genannt; alle 43 HS in `Navigation.md`.

### 3.6 Konsistenz Designsystem, Navigation, Konzept, Seiten

- **Tokens:** `Designsystem.md` definiert 151 Tokens (Brush, Size, Space, Border, Radius, Font, Icon, Theme). In HS und HM werden nur Tokens verwendet, die dort definiert sind. Zehn auf den ersten Blick „fehlende“ Namen (z. B. `Icon.Pack.Present`, `Icon.Jog.Plus`, `Icon.State.Pending`, `Icon.Schedule.Setback`, `Icon.Scroll.Down`) sind im Designsystem in der Kurzschreibweise `A / .B` definiert und damit vorhanden. Von den HM neu eingeführte Symbole sind in den Moduldateien als „neu, hier definiert“ gekennzeichnet.
- **Hex- und Pixel-Literale:** In HS/HM keine Hex-Farben. Pixelangaben nur in Herleitungen (Zeilenhöhenrechnungen in HS-13, HS-14, HS-15, HS-18) und in den Prüfpunkt- und Rechenbeispielen; keine festen Pixelpositionen im Layout.
- **Annahmen:** A-01 bis A-79 lückenlos, eindeutig, aufsteigend (79 Einträge). **Offene Punkte:** OP-01 bis OP-66 lückenlos, eindeutig, aufsteigend (66 Einträge). Kein zitierter Verweis `A-nn` oder `OP-nn` liegt außerhalb dieser Bereiche; alle zitierten lokalen Kennungen (`S01-1` bis `S39-5`, `K27-1` bis `K29-4`) sind in den Abschnitten „Annahmen dieser Seite“ definiert und durch Sammeleinträge A-60 bis A-71 in `Annahmen.md` referenziert.
- **Navigationspfade:** Die Navigationspfade der HS (Kopfzeile) stimmen mit den Pfaden in `Navigation.md` überein (Formatunterschiede nur durch Fettdruck).
- **Verweise auf „Bericht“ oder „Annahme n“ ohne Kennung und Arbeitsnotizen:** siehe B-02 bis B-04.

### 3.7 `Agent.md` Abschnitt 6, Stichprobe in 8 HS-Seiten

Geprüft: HS-01, HS-07, HS-11, HS-13, HS-22, HS-25, HS-31, HS-37.

- **ISA-101, Farbe nur für Status:** Alle Seiten benennen Farbe ausschließlich für Status und Alarm (z. B. HS-01: „Ein/Aus … nie grün (A-31)“, HS-07: Farben des Entwurfs entfallen, HS-13: „Eingabewerte nicht rot … kein Element nutzt Statusfarbe außerhalb Status“, HS-37: Rot/Gelb/Grün nur als Meldeklassen mit Symbol und Wort). Rote Eingabewerte und gelbe Schlüsselsymbole der Referenz werden ausdrücklich nicht übernommen.
- **Zweiter Kanal:** In allen 8 Seiten sind Zustände zusätzlich über Symbol und/oder Wort beschrieben (6 bis 18 Fundstellen je Seite); `HM-09`, `HM-08` und `HM-05` führen den zweiten Kanal in einer eigenen Spalte.
- **Touch-Ziele:** Alle 8 Seiten verwenden `Size.Touch.Default` (64) beziehungsweise `Size.Touch.Min` (48) und `Size.Touch.Gap`; Mindestgrößen sind im Designsystem als Tokens definiert (48/64/96, Abstand 16).
- **Keine 3D-Schaltflächen und Verläufe:** Treffer auf „Verlauf“ betreffen ausschließlich den Navigationsverlauf; Schatten/3D/Farbverläufe kommen nicht als Gestaltungsmittel vor.

### 3.8 `src_Data`

- `git diff f168526 -- src_Data` ist leer (0 Byte).
- `src_Data` wurde nur im ersten Commit `75791af` („Projektgrundlage“) angelegt und seither nicht berührt. Der Arbeitsbaum ist sauber (`git status` leer). `Agent.md` und `Task.md` unterscheiden sich ebenfalls nicht von `f168526`.

### 3.9 Prüfpunkt-Status

Alle 1.755 Prüfpunkte tragen den Status **„offen“**. Das ist für Meilenstein 1 zulässig und gewollt: Die Prüfpunkte der DS, RS und HS beschreiben das erwartete Ergebnis einer Prüfung der Seiten und Module; sie werden erst abgearbeitet, wenn es etwas zu prüfen gibt, also gegen die umgesetzte Anwendung (Meilenstein 2: statische Prüfung, Meilenstein 3: visuelle Prüfung unter Windows). In Meilenstein 1 ist der Prüfgegenstand die Dokumentation selbst; deren Vollständigkeit und Richtigkeit wird durch diesen Bericht belegt, nicht durch einzelne Prüfpunktzeilen. Es gibt keinen Prüfpunkt mit Status „bestanden“ oder „nicht bestanden“, der ohne Nachweis gesetzt wäre.

## 4 Befunde

Schwere: **mittel** = vor Abschluss beheben (Verstoß gegen eine Regel in `Agent.md`/`Task.md`); **niedrig** = Schönheitsfehler oder Hinweis, Behebung empfohlen.

### Mittel

| Nr. | Datei, Fundstelle | Problem | Soll |
|---|---|---|---|
| B-01 | `docs/03_HMI-Konzept/Module/HM-23_Nockentabelle.md`, Prüfpunkte, Zeilen 55 und 56 | Prüfpunkt-ID `HM-23-P05` kommt zweimal vor („Beispieltexte“ und „Antippen“); die Folge ist 1, 2, 3, 4, 5, 5, 6. Verstößt gegen „lückenlos, eindeutig“. | Zweite Zeile `HM-23-P06`, bisherige P06 zu `HM-23-P07`; zitierte IDs `HM-23-P06` in anderen Dokumenten prüfen (Skript `c3.py`, `c6.py`). |
| B-02 | Arbeitsnotizen im Prozessjargon in HS-Seiten: `HS-11` Z. 184, `HS-12` Z. 145, `HS-19` Z. 172, `HS-20` Z. 121, `HS-21` Z. 115, 148, 163, `HS-25` Z. 67, `HS-26` Z. 12, `HS-27` Z. 130, `HS-28` Z. 118, `HS-29` Z. 107, `HS-30` Z. 121, `HS-31` Z. 134, `HS-32` Z. 121, `HS-34` Z. 115, `HS-36` Z. 96, `HS-37` Z. 96, `HS-41` Z. 93; außerdem `Konzept.md` Z. 559 („Entscheidung des Verwalters“) | Sätze wie „der Querschnitts-Agent überführt sie in Sammeleinträge von Annahmen.md“, „der Verwalter überträgt sie nach Annahmen.md“, „Hinweis an den Verwalter“, „Wünsche an den Querschnitts-Agenten (nicht von mir angelegt)“, „dem Querschnitts-Agenten gemeldet“, „Ohne OP-Eintrag im Seiten-Index“ sind Arbeitsnotizen des Erstellungsprozesses. Sie sind veraltet: Die Sammeleinträge A-60 bis A-71 und die OP-Einträge (z. B. OP-57, OP-58, OP-59, OP-64) sind angelegt, die Wünsche (HM-18 Direkteingabe, HM-19 Übersicht) sind in den Modulen umgesetzt. | Alle genannten Sätze streichen oder in Dauerform umformulieren (z. B. „Sammeleintrag: A-62“, „Eintrag: OP-58“). Bei „ohne OP-Eintrag“ jeweils die vorhandene OP-Nummer nennen oder den Satz entfernen. |
| B-03 | `docs/03_HMI-Konzept/Seiten/HS-07_Heissleim-Nordson.md`, Z. 105 (Taste „Manuell“) | Verweis „…in der Moduldatei noch nicht enthalten, siehe Bericht“. Ein „Bericht“ ohne Kennung als Quelle, und die Aussage ist falsch: `HM-07` enthält `WhilePressed` bereits (Parameter `TriggerMode`, Z. 4 und 15 der Moduldatei, OP-57). | Klammerzusatz ersetzen durch „siehe [HM-07](../Module/HM-07_Aktionstaste.md), OP-57“. |
| B-04 | `docs/03_HMI-Konzept/Seiten/HS-41_Dosierer-Uebersicht.md`, Z. 70, 83, 112, 117, 118, 141 (und Z. 90, 121 „Schwelle Annahme 90 %“) | „Annahme 1“ bis „Annahme 5“ ohne Kennung. Die Aussagen entsprechen A-71 Punkt 1 bis 5 beziehungsweise dem Abschnitt „Annahmen dieser Seite“ der Seite (nummeriert 1 bis 5 ohne Kennung, anders als die Kennungen `Snn-n`/`Knn-n` aller anderen Seiten). Die Formulierung „Annahme 90 %“ ist als Verweis missverständlich. | Abschnitt „Annahmen dieser Seite“ mit Kennungen `S41-1` bis `S41-5` versehen und die sechs Verweise darauf umstellen; „Schwelle Annahme 90 %“ in „Schwelle 90 % (A-nn / OP-27)“ ändern, passende A-Nummer prüfen. In `A-71` die lokalen Kennungen ergänzen. |
| B-05 | `docs/00_Plan/Fortschritt.md` (nur 1 Eintrag, „M1 / Phase 1, Punkt 1“) und `Task.md` (kein einziger Punkt `[x]`) | `Agent.md` Abschnitt 3 verlangt, erledigte Punkte in `Task.md` abzuhaken und `Fortschritt.md` mit Datum, Erledigtem und Nächstem zu pflegen. Der Stand zeigt Phase 1, 2 und 3 als offen, obwohl alle Artefakte vorliegen; die nächste Session würde falsch aufsetzen. | `Fortschritt.md` je Phase/Paket fortschreiben (neueste oben), Phase 1 bis 3 in `Task.md` abhaken, sobald dieser Bericht „bestanden“ lautet; Punkt „Pruefbericht_M1.md schreiben und Befunde beheben, Commit und Push“ erst nach erfolgreichem Wiederholungslauf abhaken. |

### Niedrig

| Nr. | Datei, Fundstelle | Problem | Soll |
|---|---|---|---|
| N-01 | Vorlagenabweichungen (additiv, Pflichtabschnitte vorhanden): alle `HM-01` bis `HM-38` haben zusätzlich „Herkunft“ und „WPF-Umsetzung“, „Prüfpunkte“ steht am Ende statt direkt nach „Verwendet auf Seiten“; `RS-13`, `RS-14`, `RS-15` haben zusätzlich „Bilder“; `HS-01` hat „Platzhalter-Pop-ups“; `HS-01` bis `HS-03`, `HS-11`, `HS-12`, `HS-16` bis `HS-21`, `HS-27` bis `HS-29`, `HS-35` bis `HS-39`, `HS-41` haben zusätzlich „Annahmen dieser Seite“, in `HS-27`, `HS-28`, `HS-29`, `HS-41` hinter „Offene Punkte“. | Die Vorlage in `Agent.md` Abschnitt 5 kennt 7 beziehungsweise 5 Abschnitte. Die Erweiterungen sind sinnvoll, aber nicht vereinheitlicht (Reihenfolge, Pflicht). | Entweder die Zusatzabschnitte als zulässige Erweiterung in `Annahmen.md` festhalten (eine Zeile) oder in der Vorlage ergänzen; Reihenfolge in HS-27/28/29/41 angleichen („Annahmen dieser Seite“ vor „Offene Punkte“). |
| N-02 | `docs/00_Plan/Plan_M1.md` Z. 23 | „46 direkt im Fließtext“; tatsächlich 44 (`Referenz-Uebersicht.md` Z. 20 dokumentiert die Abweichung bereits: RS-22 und RS-32 haben je ein Textfeld statt eines zweiten Bildes). Z. 24: „Zwischenstand außerhalb des Repos“. | Plan auf 44 / 37 / 2 Textfelder korrigieren oder Hinweis auf die Übersicht ergänzen; „Zwischenstand“ streichen. |
| N-03 | `docs/02_Referenz-Analyse/Module/Modulliste.md` Z. 3 | „Stand: R11“ (interner Paketname). | Durch Datum oder Meilenstein/Phase ersetzen („Stand: Phase 2, abgeschlossen“). |
| N-04 | `docs/02_Referenz-Analyse/Seiten/RS-04_Einstellungen.md` Z. 2 | „Quelle: Handbuch , Kapitel 4 …“, Leerzeichen vor dem Komma. | Leerzeichen entfernen. |
| N-05 | `RS-22` (Tabelle T32, Zeile „State“), `RS-23` (T33, „Regulierung - / +“), `RS-27` (T38, „Pfeiltasten“), `RS-38` (T48, „Farbkennzeichnung“) | Inhalt vollständig, aber nicht buchstabengleich: Zeilenumbrüche der Quelle als „;“, Klammerzeichen „(–)“ als „(--)“ in RS-23, „<< / >>“ als „«“/„»“ beziehungsweise „<<“ / „>>“. Der Wortlaut bleibt erhalten. | Kein Eingriff nötig; bei „wortgetreuen“ Zitaten in RS-23 Strich „–“ statt „--“ verwenden. |
| N-06 | `docs/03_HMI-Konzept/Module/Modulliste.md` / `HM-38` | Die Herkunftsspalte der Modulliste (`–`) und der Abschnitt „Herkunft“ (`RM-14` als Auslöser) sind formal verschieden, inhaltlich nicht widersprüchlich. | In der Modulliste Spalte RM-Herkunft „– (Auslöser RM-14)“ oder im Modul „Auslöser: RM-14, keine Entsprechung“ vereinheitlichen. |

## 5 Wiederholungsprüfung

Nach Behebung von B-01 bis B-05 sind die Skripte `c1.py`, `c3.py`, `c5.py`, `c6.py`, `c6c.py` erneut zu starten. Erwartet: keine Meldung `SEQ`, `dups []`, keine Treffer für „Verwalter“, „Querschnitts“ und „siehe Bericht“, keine Treffer für `Annahme [0-9]` ohne Kennung, `Fortschritt.md` mit Einträgen für Phase 1 bis 3. Danach lautet das Urteil BESTANDEN.

## 6 Offene Punkte

Keine. Die offenen fachlichen Punkte des Projekts stehen in `docs/00_Plan/Offene-Punkte.md` (OP-01 bis OP-66, alle „offen“, zulässig für Meilenstein 1).
