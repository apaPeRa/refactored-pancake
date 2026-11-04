# RS-10 – Zeitschaltuhr

- Quelle: Handbuch `src_Data/Referenz/Referenz.docx`, Kapitel 10 „Zeitschaltuhr“ (Zweck, Seitenübersicht, Funktionsbeschreibung: Bedienung, Beschreibung der Phasen; keine Tabellen); Bilder [RS-10_01](../Medien/RS-10_01.png) bis [RS-10_06](../Medien/RS-10_06.png) (`image18.png` bis `image23.png`).
- Navigationspfad: Einstellung › Zuführung Karton › Heißleimgerät › Zeitschaltuhr (Herkunft „abgeleitet“, Zugang im Handbuch nicht beschrieben). Seitentitel im Bild: „Zeitschaltuhr Zuführung“. Im Bild von [RS-07](RS-07_Heissleim-Nordson.md) die Funktionsleistentaste „Zeitschaltuhr“ (Ziel nach Name vermutet). Die Taste „Zeitschaltuhr“ oben auf RS-07 aktiviert nur den Zeitplan, sie öffnet diese Seite laut Referenz-Übersicht nicht.

## Zweck

Wortgetreu: „Die Zeitschaltuhr erlaubt das zeitgesteuerte Ein- und Ausschalten der Heizung des Heißleimgeräts. Der Zeitplan wird unabhängig von der SPS ausgeführt – solange das Gerät eingeschalten ist. Abschalten des Geräts oder des Hauptschalters der Maschine wird der Zeitplan unterbrochen.“

## Aufbau (Bereiche, Layout)

Bild [RS-10_01](../Medien/RS-10_01.png) (1024 × 768):

1. **Kopfzeile:** Logo, Titel „Zeitschaltuhr Zuführung“, Wirbel-Symbol, Uhrzeit „13:02:05“, Datum „12.05.2025“.
2. **Wochenraster:** sieben gleich breite Spalten mit den Überschriften (unterstrichen) „Montag“, „Dienstag“, „Mittwoch“, „Donnerstag“, „Freitag“, „Samstag“, „Sonntag“. Jede Spalte ist ein hohes hellblaues Feld (nahezu bis zur Meldezeile). Oben in jeder Spalte steht eine rosa/rote Kopfzelle mit schwarzem Kreis und weißem Plus (Neue Phase hinzufügen) und gelbem Schlüsselsymbol rechts. Im Beispiel sind alle Spalten leer (keine Phasen).
3. **Meldezeile:** roter Balken „*450* Palettierung nicht bereit“.
4. **Untere Funktionsleiste:** links leer; rechts gelbes Vorhängeschloss, „Produktion“ (Haus), „Einstellungen“ (Zahnrad), „Zurück“ (Rücktaste).

## Elemente

Die Seite hat keine Handbuchtabellen. Erfasst sind die Bedien- und Beschreibungstexte sowie alle im Bild sichtbaren Elemente.

### Wochenraster und Phasen

| Element | Typ | Funktion (wortgetreu bzw. Bildbeschreibung) | verwendetes Modul |
|---|---|---|---|
| Spalten Montag bis Sonntag | Tagesspalte (7) | Zeitplan je Wochentag; Phasen erscheinen als Einträge in der Spalte | Modulkandidat: Wochen-Zeitplan |
| Plus-Taste je Tag | Taste (Kopfzelle der Spalte, Plus im schwarzen Kreis, Schlüsselsymbol) | „Soll eine neue Phase hinzugefügt werden kann zwischen zwei Aktionen gewählt werden, Heißphase und Absenkphase (StandBy).“ Öffnet das Pop-up „Neuer Eintrag“ ([RS-10_06](../Medien/RS-10_06.png), [RS-10_03](../Medien/RS-10_03.png)). | Modulkandidat: Wochen-Zeitplan |
| Eintrag Heizphase | klickbarer Eintrag in der Spalte (Bild: rosa/rot, Zeilen „08:00 ein“ … „16:00 aus“) | „Heizphase: Startzeit: Das Heißleimgerät beginnt mit dem Aufheizen auf die Soll-Temperaturen. Stoppzeit: Das Heißleimgerät schaltet alle Heizungen ab.“ Öffnet das Pop-up (gleiche Struktur), [RS-10_04](../Medien/RS-10_04.png). | Modulkandidat: Wochen-Zeitplan |
| Eintrag Absenkphase | klickbarer Eintrag, innerhalb einer Heizphase (Bild: türkis/cyan, „12:00 absenken“, „13:00 aufheizen“) | „Absenkphase: Startzeit: Das Heißleimgerät heizt oder kühlt auf eine reduzierte Temperatur. Stoppzeit: Wenn die Heizungen an sind, wird auf die Solltemperaturen hochgeheizt. Sind die Heizungen aus, passiert nichts.“ Kann direkt gelöscht werden, [RS-10_05](../Medien/RS-10_05.png). | Modulkandidat: Wochen-Zeitplan |
| Schlüsselsymbol je Tag | Symbol in der Kopfzelle | Bedeutung im Handbuch nicht erklärt (Berechtigung/Eingabeschutz vermutet) | Modulkandidat: Eingabefeld mit Schlüsselsymbol |

### Pop-up „Neuer Eintrag“ (alle klickbaren Bereiche öffnen „ein Pop-Up mit derselben Struktur“)

Aufbau laut [RS-10_03](../Medien/RS-10_03.png) (beschriftete Grafik des Pop-ups, Handbuchbeschriftungen):

| Element | Typ | Funktion (Beschriftung im Bild / Handbuch) | verwendetes Modul |
|---|---|---|---|
| Titel „Neuer Eintrag:“ | Überschrift | Pop-up-Titel (auch beim Bearbeiten eines vorhandenen Eintrags unverändert) | Modulkandidat: Pop-up Zeitplan-Eintrag |
| Aktion | Dropdown (Auswahlliste) | Auswahl „Heizphase“ oder „Absenkphase“ (aufgeklappt in [RS-10_06](../Medien/RS-10_06.png)); Handbuch: „Heißphase und Absenkphase (StandBy)“ | Modulkandidat: Pop-up Zeitplan-Eintrag |
| Zeit aktiv | zwei Kontrollkästchen (je eines links neben Startzeit und Endzeit) | Aktiviert die jeweilige Zeit; Handbuch: „Um eine Phase anzulegen, muss eine Startzeit oder Stoppzeit angelegt werden. Beide Zeiten können festgelegt werden.“ In [RS-10_06](../Medien/RS-10_06.png) beide unmarkiert, Zeitfelder leer. | Modulkandidat: Pop-up Zeitplan-Eintrag |
| Startzeit | Zeiteingabefeld (Format hh:mm; Bild: 08:00, rote Schrift; leer als „__:__“) | Startzeit der Phase | Modulkandidat: Pop-up Zeitplan-Eintrag |
| Stoppzeit / Endzeit | Zeiteingabefeld (Format hh:mm; Bild: 16:00) | Stoppzeit der Phase; Beschriftung im Pop-up „Endzeit:“, im Handbuchtext „Stoppzeit“ | Modulkandidat: Pop-up Zeitplan-Eintrag |
| Unterelemente | Symbol (Baumstruktur) mit Zähler (Bild: 0; bei Heizphase mit enthaltener Absenkphase 1, orange hinterlegt) | Anzahl der untergeordneten Absenkphasen. Handbuch: „Innerhalb einer Heizphase können Absenkphase enthalten sein.“ | Modulkandidat: Pop-up Zeitplan-Eintrag |
| Übernehmen | Taste (Haken-Symbol) | Eintrag übernehmen/speichern (Beschriftung nur im Bild) | Modulkandidat: Pop-up Zeitplan-Eintrag |
| Abbrechen | Taste (X-Symbol) | Pop-up ohne Änderung schließen (Beschriftung nur im Bild) | Modulkandidat: Pop-up Zeitplan-Eintrag |
| Eintrag löschen | Taste (Papierkorb-Symbol) | Eintrag löschen. Handbuch: „Um eine Heizphase zu löschen, müssen alle untergeordnete Absenkphasen gelöscht sein.“ In [RS-10_04](../Medien/RS-10_04.png) (Heizphase mit 1 Unterelement) ist die Taste ausgegraut; in [RS-10_05](../Medien/RS-10_05.png) (Absenkphase) aktiv: „Diese Phase kann direkt gelöscht werden.“ Im Neuanlage-Zustand ([RS-10_06](../Medien/RS-10_06.png)) fehlt die Taste. | Modulkandidat: Pop-up Zeitplan-Eintrag |

### Rahmenelemente

| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Kopfzeile | Rahmen | Logo, Titel „Zeitschaltuhr Zuführung“ (in Ausschnitten nur „Zeitschaltuhr“), Symbol, Uhrzeit/Datum | Modulkandidat: Kopfzeile |
| Meldezeile | Rahmen | Meldung (Bild: „*450* Palettierung nicht bereit“) | Modulkandidat: Meldezeile |
| Vorhängeschloss (gelb) | Symbol | im Handbuch nicht erklärt | Modulkandidat: Funktionsleiste unten |
| Produktion / Einstellungen / Zurück | Navigationstasten | Funktion nur aus Beschriftung/Symbol | Modulkandidat: Funktionsleiste unten |

### Bilder (6)

| Bild | Beschreibung |
|---|---|
| [RS-10_01.png](../Medien/RS-10_01.png) | Gesamtseite „Zeitschaltuhr Zuführung“: sieben Wochentagsspalten Montag bis Sonntag, je mit rosa/roter Kopfzelle mit Plus-Symbol und Schlüsselsymbol; alle Spalten leer; Meldezeile und Leiste (Produktion, Einstellungen, Zurück). |
| [RS-10_02.png](../Medien/RS-10_02.png) | Ausschnitt (Titel „Zeitschaltuhr“, Spalten Montag bis Donnerstag, Freitag angeschnitten) mit gelb umrandeten, orange hinterlegten klickbaren Bereichen: Plus-Tasten aller vier Tage und Einträge „06:30 ein / 14:40 aus“ bei Montag, Dienstag und Mittwoch (Handbuch: „die klickbaren Bereiche markiert“); Donnerstag nur Plus-Taste. |
| [RS-10_03.png](../Medien/RS-10_03.png) | Beschriftetes Pop-up „Neuer Eintrag:“ mit Dropdown „Heizphase“, zwei Häkchen (Beschriftung „Zeit aktiv“), Startzeit „08:00“, Endzeit „16:00“ (rote Schrift), Baum-Symbol mit „0“ (Beschriftung „Unterelemente“), Tasten Haken („Übernehmen“), X („Abbrechen“), Papierkorb („Eintrag löschen“); Beschriftungen „Aktion“, „Startzeit“, „Stopzeit“ als gelbe Pfeile. |
| [RS-10_04.png](../Medien/RS-10_04.png) | Mittwoch mit Heizphase angeklickt: Einträge „08:00 ein“ (rot), „12:00 absenken“, „13:00 aufheizen“ (türkis), „16:00 aus“; Pop-up Heizphase 08:00 bis 16:00, Unterelemente „1“ (orange Zählerbox), Papierkorb-Taste ausgegraut. |
| [RS-10_05.png](../Medien/RS-10_05.png) | Mittwoch mit Absenkphase angeklickt: Pop-up „Absenkphase“, Startzeit 12:00, Endzeit 13:00, Unterelemente „0“, Papierkorb-Taste aktiv. |
| [RS-10_06.png](../Medien/RS-10_06.png) | Plus-Taste angeklickt (neuer Eintrag): Dropdown aufgeklappt mit „Heizphase“ (markiert) und „Absenkphase“; Startzeit/Endzeit-Kontrollkästchen nicht markiert, Zeitfeld leer („__:__“); nur Tasten Haken und X, kein Papierkorb, kein Unterelemente-Zähler. |

## Verwendete Module (IDs)

Noch keine RM-IDs. Modulkandidaten: Kopfzeile, Meldezeile, Funktionsleiste unten, Wochen-Zeitplan, Pop-up Zeitplan-Eintrag (Dropdown, Zeitfelder, Übernehmen/Abbrechen/Löschen), Eingabefeld mit Schlüsselsymbol, Eingabe-Pop-up (Zeitwert).

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

- **Ausführung:** Zeitplan läuft unabhängig von der SPS, solange das Gerät eingeschaltet ist; Abschalten des Geräts oder des Hauptschalters der Maschine unterbricht den Zeitplan.
- **Phase anlegen:** Plus-Taste des Tages, Typ wählen (Heizphase oder Absenkphase), Start- und/oder Stoppzeit aktivieren und eingeben, mit Haken übernehmen. Mindestens eine Zeit (Start oder Stopp) nötig, beide möglich.
- **Heizphase:** Startzeit = Aufheizen auf Solltemperaturen; Stoppzeit = alle Heizungen aus. In Rasterdarstellung: „ein“ / „aus“.
- **Absenkphase (Standby):** innerhalb einer Heizphase. Startzeit = auf reduzierte Temperatur heizen/kühlen; Stoppzeit = bei eingeschalteten Heizungen auf Solltemperaturen hochheizen, bei ausgeschalteten Heizungen nichts. In Rasterdarstellung: „absenken“ / „aufheizen“.
- **Löschen:** Heizphase erst löschbar, wenn alle untergeordneten Absenkphasen gelöscht sind (Papierkorb ausgegraut bei Unterelemente > 0); Absenkphase direkt löschbar.
- **Pop-up-Zustände:** Neuanlage (kein Papierkorb, Zeitfelder leer, Kontrollkästchen aus), Bearbeiten Heizphase, Bearbeiten Absenkphase.
- **Darstellung im Raster:** Heizphase rot/rosa, Absenkphase türkis; ein Eintrag zeigt Zeitpunkte mit „ein“/„aus“ bzw. „absenken“/„aufheizen“. Farbe plus Text.
- **Berechtigungen:** Schlüsselsymbol je Plus-Taste (Bedeutung nicht erklärt).
- **Fehlerfälle:** im Handbuch keine beschrieben (z. B. Überschneidung, Endzeit vor Startzeit).

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RS-10-P01 | Wochenraster | Sieben Spalten Montag, Dienstag, Mittwoch, Donnerstag, Freitag, Samstag, Sonntag in dieser Reihenfolge | offen |
| RS-10-P02 | Plus-Taste je Tag | In jeder Spalte oben eine Plus-Taste mit Schlüsselsymbol; öffnet Pop-up „Neuer Eintrag“ | offen |
| RS-10-P03 | Pop-up-Struktur | Alle klickbaren Bereiche (Plus, Heizphase, Absenkphase) öffnen ein Pop-up derselben Struktur | offen |
| RS-10-P04 | Aktion wählen | Dropdown mit genau „Heizphase“ und „Absenkphase“ | offen |
| RS-10-P05 | Zeiten | Startzeit und Endzeit (Format hh:mm) je mit Kontrollkästchen „Zeit aktiv“; mindestens eine Zeit nötig | offen |
| RS-10-P06 | Pop-up-Tasten | Übernehmen (Haken), Abbrechen (X), Eintrag löschen (Papierkorb) vorhanden; Papierkorb bei Neuanlage nicht vorhanden | offen |
| RS-10-P07 | Unterelemente | Zähler der untergeordneten Absenkphasen im Pop-up (0 oder 1 im Beispiel) | offen |
| RS-10-P08 | Heizphase löschen | Bei Unterelemente > 0 ist „Eintrag löschen“ gesperrt; nach Löschen aller Absenkphasen möglich | offen |
| RS-10-P09 | Absenkphase löschen | Absenkphase direkt löschbar | offen |
| RS-10-P10 | Phasenwirkung Heizphase | Startzeit: Aufheizen auf Solltemperaturen; Stoppzeit: alle Heizungen aus | offen |
| RS-10-P11 | Phasenwirkung Absenkphase | Startzeit: auf reduzierte Temperatur; Stoppzeit: Heizungen an = hochheizen auf Soll, Heizungen aus = nichts | offen |
| RS-10-P12 | Darstellung der Einträge | Heizphase mit „ein“/„aus“, Absenkphase mit „absenken“/„aufheizen“ im Raster; Typ nicht nur über Farbe erkennbar | offen |
| RS-10-P13 | Geltung | Hinweis: Zeitplan läuft unabhängig von der SPS; Unterbrechung durch Abschalten des Geräts/Hauptschalters | offen |
| RS-10-P14 | Brotkrümel | „Einstellung › Zuführung Karton › Heißleimgerät › Zeitschaltuhr“ | offen |
| RS-10-P15 | Rückweg | Tasten Produktion, Einstellungen, Zurück vorhanden | offen |
| RS-10-P16 | Medienbezug | [RS-10_01](../Medien/RS-10_01.png) bis [RS-10_06](../Medien/RS-10_06.png) verlinkt und beschrieben (6 Bilder) | offen |

## Offene Punkte

1. **Zugang** nicht beschrieben (abgeleitet aus Funktionsleiste „Zeitschaltuhr“ auf RS-07). Abgrenzung zur Taste „Zeitschaltuhr“ oben auf RS-07 (aktiviert nur den Zeitplan) ist aus dem Handbuch nur indirekt ableitbar.
2. **Begriffe:** Handbuch „Heißphase“ / Pop-up „Heizphase“; „Stoppzeit“ / „Endzeit“; „Stopzeit“ im Bild; „Absenkphase (StandBy)“. Annahme: jeweils dasselbe.
3. **Fehlerfälle** nicht beschrieben (Überschneidungen, Endzeit vor Startzeit, mehrere Heizphasen pro Tag, Absenkphase außerhalb der Heizphase, Phase über Mitternacht); Anzahl möglicher Einträge je Tag nicht genannt.
4. **Darstellung einer Heizphase mit nur einer aktivierten Zeit** („Start oder Stopp“) im Raster nicht gezeigt.
5. **Schlüsselsymbol, Vorhängeschloss, Farben** (rosa, türkis, orange) nicht erklärt; Beschriftung der Pop-up-Tasten (Übernehmen, Abbrechen, Eintrag löschen) steht nur im Bild.
6. **Kopfzeile:** Bild 1 „Zeitschaltuhr Zuführung“, Bild 2 Ausschnitt „Zeitschaltuhr“ (anderer Seitenstand/Bildausschnitt); Raster in Bild 2 hat Einträge in anderer Farbe (orange) wegen Markierung der klickbaren Bereiche.
7. **Beispielzeiten:** 06:30 ein / 14:40 aus (Bild 2) und 08:00/12:00/13:00/16:00 (Bilder 4/5) sind nur Beispielwerte, keine Standardwerte.
