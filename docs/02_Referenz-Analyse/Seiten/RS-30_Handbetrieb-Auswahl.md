# RS-30 – Handbetrieb Auswahl

- Quelle: `src_Data/Referenz/Referenz.docx`, Kapitel „Handbetrieb Auswahl“ (Zweck, Seitenübersicht, Funktionsbeschreibung, Tabelle T40); Bild [RS-30_01.png](../Medien/RS-30_01.png); Eintrag „Handbetrieb“ in der Tabelle von RS-04 („Erlaub das steuern jeden Aktors der Maschine.“)
- Navigationspfad: Einstellung › Handbetrieb (Herkunft: Handbuch). Weiterführend: Gruppentaste → Aktorseite [RS-31](RS-31_Handbetrieb.md) (Übergang im Handbuch nicht ausdrücklich beschrieben, siehe Offene Punkte).

## Zweck

Wortgetreu: „Die Seite Handbetrieb Auswahl erlaubt das gezielte Ansteuern einzelner Aktoren der Maschine. Diese Funktion dient der Inbetriebnahme, Wartung und Fehlersuche.“

## Aufbau (Bereiche, Layout)

Bild [RS-30_01.png](../Medien/RS-30_01.png) (Bildschirmfoto der alten HMI, 4:3, blauer Hintergrund):

- **Kopfzeile (hellgrau):** links Logo „APA-TEC GmbH – AUTOMATION AND PACKAGING TECHNOLOGY“; Mitte Seitentitel „Handbetrieb Auswahl“ (fett, unterstrichen); rechts ein Wirbel-/Spiral-Symbol (ohne Beschriftung); ganz rechts Uhrzeit „13:05:29“ (groß) und Datum „12.05.2025“ (klein).
- **Arbeitsbereich:** zentriertes Raster aus 4 Spalten × 4 Zeilen mit dünnen hellen Trennlinien, 14 beschriftete Tasten (hellgrau), die letzten 2 Rasterzellen der vierten Zeile sind leer. Tastenbeschriftungen zeilenweise:
  1. Zeile: „GR1 Hauptantrieb“ · „GR2 Zuführung Papier“ · „GR3 Zuführung Karton“ · „GR4 Dornrad“
  2. Zeile: „GR5 Dornrad“ · „GR6 Heizungen“ · „GR10 Paketübergabe“ · „GR11 Rüttlung“
  3. Zeile: „GR14 Endkontrollwaage“ · „GR20 Schließmaschine“ · „GR41 Hauptdosierer 1“ · „GR42 Hauptdosierer 2“
  4. Zeile: „GR45 Nachdosierer“ · „GR100 Schnittstelle“ · (leer) · (leer)
- **Meldezeile:** durchgehend roter Balken mit schwarzer fetter Schrift „*450* Palettierung nicht bereit“.
- **Untere Funktionsleiste (hellgrau):** links Taste „Suchen“; Mitte-rechts gelbes, geschlossenes Schloss-Symbol; rechts drei Tasten „Produktion“ (mit Haus-Symbol), „Einstellungen“ (mit Zahnrad-Symbol), „Zurück“ (mit Rücktasten-Symbol).
- Keine Zahlenfelder, keine Schlüsselsymbole auf dieser Seite.

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)

| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Kopfzeile (Logo, Seitentitel, Symbol, Uhrzeit/Datum) | Anzeige | Siehe Bildbeschreibung; Titel „Handbetrieb Auswahl“, Uhrzeit „13:05:29“, Datum „12.05.2025“ (Bildbeispiel) | [RM-01](../Module/RM-01_Kopfzeile.md) |
| Gruppentasten GR1 … GR100 (14 Stück, Raster 4 × 4) | Taste | Handbuch (T40 „Tasten Gruppenanwahl“): „Über die Tasten können Bereich / Gruppen in der Maschine gezielt angewählt“ (Satz im Original unvollständig) | [RM-14](../Module/RM-14_Kachel-Navigation.md) |
| Taste „Suchen“ | Taste (untere Leiste, links) | Handbuch (T40 „Suchen“): „Öffnet eine Suchfunktion, um Aktoren anhand ihrer Betriebsmittelkennzeichnung zu finden und auszuwählen.“ | [RM-11](../Module/RM-11_Aktionstaste.md) |
| Meldezeile „*450* Palettierung nicht bereit“ | Anzeige | Rote Meldezeile mit Meldungsnummer in Sternen und Text (Bildbeispiel) | [RM-02](../Module/RM-02_Meldezeile.md) |
| Schloss-Symbol (gelb, geschlossen) | Symbol | Im Handbuch zu dieser Seite nicht erklärt (vermutlich Berechtigungs-/Anmeldestatus) | [RM-03](../Module/RM-03_Funktionsleiste-unten.md) |
| Tasten „Produktion“, „Einstellungen“, „Zurück“ | Navigationstasten | Im Handbuch zu dieser Seite nicht beschrieben; Navigation unten rechts | [RM-03](../Module/RM-03_Funktionsleiste-unten.md) |

### Tabelle T40 (Funktionsbeschreibung), 3 Zeilen (1 Kopfzeile + 2 Datenzeilen), vollständig

| Funktion | Beschreibung |
|---|---|
| Tasten Gruppenanwahl | Über die Tasten können Bereich / Gruppen in der Maschine gezielt angewählt |
| Suchen | Öffnet eine Suchfunktion, um Aktoren anhand ihrer Betriebsmittelkennzeichnung zu finden und auszuwählen. |

### Bilder

| Bild | Beschreibung |
|---|---|
| [RS-30_01.png](../Medien/RS-30_01.png) (Original `image52.png`, Fließtext, Seitenübersicht) | Gesamtseite wie oben unter „Aufbau“ beschrieben: 14 Gruppentasten GR1 bis GR100 im Raster, rote Meldezeile, untere Leiste mit „Suchen“, Schloss, „Produktion“, „Einstellungen“, „Zurück“. |

## Verwendete Module (IDs)

Module dieser Seite (Definitionen in der [Modulliste](../Module/Modulliste.md)):

- [RM-01](../Module/RM-01_Kopfzeile.md) – Kopfzeile
- [RM-02](../Module/RM-02_Meldezeile.md) – Meldezeile
- [RM-03](../Module/RM-03_Funktionsleiste-unten.md) – Funktionsleiste unten
- [RM-11](../Module/RM-11_Aktionstaste.md) – Aktionstaste
- [RM-14](../Module/RM-14_Kachel-Navigation.md) – Kachel-Navigation

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

- Gruppentaste antippen wählt Bereich/Gruppe an; vermutlich Wechsel zur Aktorseite (RS-31), im Handbuch nicht beschrieben.
- „Suchen“ öffnet eine Suchfunktion (Pop-up/Unterseite, Aufbau im Handbuch und im Bild nicht dargestellt); Suche nach Betriebsmittelkennzeichnung.
- Berechtigungen: im Handbuch zu dieser Seite keine Angabe. Im Bild kein Schlüsselsymbol an den Tasten.
- Fehlerfälle/Zustandsbeschreibungen: keine im Handbuch. Die Meldezeile zeigt im Bild „*450* Palettierung nicht bereit“.
- Wertebereiche, Einheiten, Standardwerte: keine.

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RS-30-P01 | Seitentitel in der Kopfzeile | „Handbetrieb Auswahl“ | offen |
| RS-30-P02 | Anzahl und Beschriftung der Gruppentasten | 14 Tasten: GR1 Hauptantrieb, GR2 Zuführung Papier, GR3 Zuführung Karton, GR4 Dornrad, GR5 Dornrad, GR6 Heizungen, GR10 Paketübergabe, GR11 Rüttlung, GR14 Endkontrollwaage, GR20 Schließmaschine, GR41 Hauptdosierer 1, GR42 Hauptdosierer 2, GR45 Nachdosierer, GR100 Schnittstelle | offen |
| RS-30-P03 | Anordnung der Gruppentasten | Raster 4 Spalten, Reihenfolge wie in Bild RS-30_01 (Zeile 4 nur zwei Tasten) | offen |
| RS-30-P04 | Taste „Suchen“ vorhanden | Taste links in der unteren Funktionsleiste; öffnet Suche nach Betriebsmittelkennzeichnung zum Finden und Auswählen von Aktoren | offen |
| RS-30-P05 | Gruppentaste antippen | Bereich/Gruppe wird angewählt (Zielseite siehe RS-31) | offen |
| RS-30-P06 | Meldezeile | Zeigt aktive Meldung mit Nummer und Text, im Bildbeispiel „*450* Palettierung nicht bereit“ | offen |
| RS-30-P07 | Untere Funktionsleiste | „Produktion“, „Einstellungen“, „Zurück“ rechts, Schloss-Symbol links davon | offen |
| RS-30-P08 | Brotkrümel/Navigation | Einstellung › Handbetrieb; Zugang über Eintrag „Handbetrieb“ in RS-04 | offen |
| RS-30-P09 | Zweck sichtbar bzw. dokumentiert | Einzelne Aktoren gezielt ansteuern (Inbetriebnahme, Wartung, Fehlersuche) | offen |

## Offene Punkte

1. Der Handbuchsatz zu „Tasten Gruppenanwahl“ ist unvollständig („…gezielt angewählt“).
2. Der Wechsel von der Auswahl zur Aktorseite (RS-31) und die Anzahl der Aktoren je Gruppe sind nicht beschrieben.
3. Aufbau der Suchfunktion (Eingabe, Trefferliste) ist weder beschrieben noch abgebildet.
4. Doppelte Beschriftung „Dornrad“ bei GR4 und GR5 im Bild; Bedeutung (z. B. Dornrad 1/2) unklar.
5. Bedeutung des Schloss-Symbols und Berechtigungsstufe der Seite nicht angegeben.
6. Gruppennummern GR1 … GR100 sind nicht durchgängig (Lücken); ob die Liste maschinenabhängig ist, ist unklar.
