# Rückverfolgung HMI-Konzept

Stand: Meilenstein 1, Phase 3, Punkt 5. Dieses Dokument verfolgt die Herkunft jeder neuen Seite (`HS`) und jedes neuen Moduls (`HM`) zurück zu Referenz (`RS`/`RM`) und Design (`DS`/`DM`) und belegt per Skript, dass nichts verloren geht. Alle Tabellen und alle Prüfwerte werden von dem Skript in Anhang A aus den Dateien in `docs/` erzeugt (Quellen: Kopfzeile „Quelle“ und Abschnitt „Verwendete Module“ der Seitendateien, Abschnitte „Herkunft“ und „Verwendet auf Seiten“ der HM-Dateien, die beiden Modullisten und `Konzept.md`). Es wurde nichts außer dieser Datei geändert; gefundene Abweichungen in anderen Dateien stehen in Abschnitt 6 und werden hier nicht behoben.

Verwandte Dokumente: [Konzept](Konzept.md), [Navigation](Navigation.md), [Designsystem](Designsystem.md), [Modulübersicht HM](Module/Modulliste.md), [Modulliste RM](../02_Referenz-Analyse/Module/Modulliste.md), [Referenz-Übersicht](../02_Referenz-Analyse/Referenz-Uebersicht.md), [Design-Dokumentation](../01_Design-Analyse/Design-Dokumentation.md).

## 1 Ergebnis in Kürze

- Zählwerte: 39 RS, 5 DS, 43 HS (39 1:1 zu den RS plus 4 Zusatzseiten), 36 RM, 22 DM, 38 HM. Alle Werte stimmen mit der Vorgabe überein.
- Jede der 39 Referenzseiten hat genau eine neue Seite (HS-01 bis HS-39, gleiche Nummer). Jede der 5 Design-Seiten ist genau einer HS zugeordnet (DS-01 = HS-01, DS-02 = HS-04, DS-03 = HS-07, DS-04 = HS-41, DS-05 = HS-06).
- Jede HS verwendet nur vorhandene HM (kein unbekannter HM-Verweis, alle Links in den Abschnitten „Verwendete Module“ lösen auf). Jedes der 22 DM und jedes der 36 RM ist auf mindestens ein HM abgebildet; jedes der 38 HM hat einen Abschnitt „Herkunft“, der mit der Modulübersicht übereinstimmt.
- Stichprobe: 187 RS-Elementzeilen auf 10 Seiten, davon 174 automatisch und 13 per Handprüfung einer HS-Zeile mit Herkunft zugeordnet, keine ohne Entsprechung. Gesamtlauf über alle 39 Seiten: 492 RS-Elementzeilen, 22 nicht automatisch zugeordnet, alle 22 bestätigt (Rahmen-Sammelzeilen und Umbenennungen, per Handzuordnung oder Rahmenmuster), 0 offen.
- Befunde (Abschnitt 6): RV-B02 bis RV-B06 sind behoben (Seitenlisten von HM-05, HM-07, HM-19 stimmen mit den HS überein, Hinweise zu DM-01/03/05/07/21 und RM-05 / DM-15 stehen in den Modullisten). Alle Befunde behoben.

## 2 Tabelle A – Seiten

Legende: RS = Referenzseite, DS = Design-Seite, HS = neue Seite. „DS-ID“ nennt nur die Design-Seite, die für die HS die Layout-Vorlage ist (Spalte „Design-Vorlage“ in [Konzept.md](Konzept.md), Annahme A-46); mit „–“ ist die HS aus Designsystem und Modulen abgeleitet. Weitere Bezüge zu Design-Seiten (Zugangskachel in DS-02, Muster) stehen in der Bemerkung. Die Spalte „HM“ ist die Zahl der in der HS verwendeten Module (Tabelle C).

### 2.1 Referenzseiten (RS-01 bis RS-39) auf neue Seiten

| RS-ID | Referenzseite | DS-ID | HS-ID | Neue Seite | HM | Bemerkung |
|---|---|---|---|---|---|---|
| [RS-01](../02_Referenz-Analyse/Seiten/RS-01_Produktion.md) | [Produktion](../02_Referenz-Analyse/Seiten/RS-01_Produktion.md) | [DS-01](../01_Design-Analyse/Seiten/DS-01_Produktion.md) | [HS-01](Seiten/HS-01_Produktion.md) | [Produktion](Seiten/HS-01_Produktion.md) | 12 | Design-Vorlage DS-01 (Screenshot) |
| [RS-02](../02_Referenz-Analyse/Seiten/RS-02_Produktionszaehler.md) | [Produktionszähler (Pop-up)](../02_Referenz-Analyse/Seiten/RS-02_Produktionszaehler.md) | – | [HS-02](Seiten/HS-02_Produktionszaehler.md) | [Produktionszähler (Pop-up)](Seiten/HS-02_Produktionszaehler.md) | 5 | kein Design; abgeleitet aus Designsystem und Modulen; Pop-up |
| [RS-03](../02_Referenz-Analyse/Seiten/RS-03_Maschinengeschwindigkeit.md) | [Maschinengeschwindigkeit (Pop-up)](../02_Referenz-Analyse/Seiten/RS-03_Maschinengeschwindigkeit.md) | – | [HS-03](Seiten/HS-03_Maschinengeschwindigkeit.md) | [Maschinengeschwindigkeit (Pop-up)](Seiten/HS-03_Maschinengeschwindigkeit.md) | 3 | kein Design; abgeleitet aus Designsystem und Modulen; Pop-up |
| [RS-04](../02_Referenz-Analyse/Seiten/RS-04_Einstellungen.md) | [Einstellungen](../02_Referenz-Analyse/Seiten/RS-04_Einstellungen.md) | [DS-02](../01_Design-Analyse/Seiten/DS-02_Einstellungen.md) | [HS-04](Seiten/HS-04_Einstellungen.md) | [Einstellungen](Seiten/HS-04_Einstellungen.md) | 10 | Design-Vorlage DS-02 (Screenshot) |
| [RS-05](../02_Referenz-Analyse/Seiten/RS-05_Zufuehrung-Papier.md) | [Zuführung Papier](../02_Referenz-Analyse/Seiten/RS-05_Zufuehrung-Papier.md) | – | [HS-05](Seiten/HS-05_Zufuehrung-Papier.md) | [Zuführung Papier](Seiten/HS-05_Zufuehrung-Papier.md) | 13 | kein eigenes Design; Bezug DS-03, DS-05 (Zugangskachel oder Muster) |
| [RS-06](../02_Referenz-Analyse/Seiten/RS-06_Zufuehrung-Karton.md) | [Zuführung Karton](../02_Referenz-Analyse/Seiten/RS-06_Zufuehrung-Karton.md) | [DS-05](../01_Design-Analyse/Seiten/DS-05_Kartonzufuehrung.md) | [HS-06](Seiten/HS-06_Zufuehrung-Karton.md) | [Zuführung Karton](Seiten/HS-06_Zufuehrung-Karton.md) | 14 | Design-Vorlage DS-05 (Screenshot) |
| [RS-07](../02_Referenz-Analyse/Seiten/RS-07_Heissleim-Nordson.md) | [Heißleim Nordson](../02_Referenz-Analyse/Seiten/RS-07_Heissleim-Nordson.md) | [DS-03](../01_Design-Analyse/Seiten/DS-03_Heissleim.md) | [HS-07](Seiten/HS-07_Heissleim-Nordson.md) | [Heißleim Nordson](Seiten/HS-07_Heissleim-Nordson.md) | 16 | Design-Vorlage DS-03 (Screenshot) |
| [RS-08](../02_Referenz-Analyse/Seiten/RS-08_Heissleim-Parameter.md) | [Heißleim Parameter](../02_Referenz-Analyse/Seiten/RS-08_Heissleim-Parameter.md) | – | [HS-08](Seiten/HS-08_Heissleim-Parameter.md) | [Heißleim Parameter](Seiten/HS-08_Heissleim-Parameter.md) | 13 | kein eigenes Design; Bezug DS-03 (Zugangskachel oder Muster) |
| [RS-09](../02_Referenz-Analyse/Seiten/RS-09_Heissleim-Druck.md) | [Heißleim Druck](../02_Referenz-Analyse/Seiten/RS-09_Heissleim-Druck.md) | – | [HS-09](Seiten/HS-09_Heissleim-Druck.md) | [Heißleim Druck](Seiten/HS-09_Heissleim-Druck.md) | 11 | kein eigenes Design; Bezug DS-03 (Zugangskachel oder Muster) |
| [RS-10](../02_Referenz-Analyse/Seiten/RS-10_Zeitschaltuhr.md) | [Zeitschaltuhr](../02_Referenz-Analyse/Seiten/RS-10_Zeitschaltuhr.md) | – | [HS-10](Seiten/HS-10_Zeitschaltuhr.md) | [Zeitschaltuhr](Seiten/HS-10_Zeitschaltuhr.md) | 16 | kein eigenes Design; Bezug DS-03 (Zugangskachel oder Muster) |
| [RS-11](../02_Referenz-Analyse/Seiten/RS-11_Hauptdosierer-1-und-2.md) | [Hauptdosierer 1 & 2](../02_Referenz-Analyse/Seiten/RS-11_Hauptdosierer-1-und-2.md) | – | [HS-11](Seiten/HS-11_Hauptdosierer-1-und-2.md) | [Hauptdosierer 1 & 2](Seiten/HS-11_Hauptdosierer-1-und-2.md) | 19 | kein eigenes Design; Bezug DS-04 (Zugangskachel oder Muster) |
| [RS-12](../02_Referenz-Analyse/Seiten/RS-12_Motorparameter.md) | [Motorparameter (Hauptdosierer)](../02_Referenz-Analyse/Seiten/RS-12_Motorparameter.md) | – | [HS-12](Seiten/HS-12_Motorparameter.md) | [Motorparameter (Hauptdosierer)](Seiten/HS-12_Motorparameter.md) | 13 | kein Design; abgeleitet aus Designsystem und Modulen |
| [RS-13](../02_Referenz-Analyse/Seiten/RS-13_Kontrollwaage.md) | [Kontrollwaage](../02_Referenz-Analyse/Seiten/RS-13_Kontrollwaage.md) | – | [HS-13](Seiten/HS-13_Kontrollwaage.md) | [Kontrollwaage](Seiten/HS-13_Kontrollwaage.md) | 11 | kein Design; abgeleitet aus Designsystem und Modulen |
| [RS-14](../02_Referenz-Analyse/Seiten/RS-14_Einzelgewichte.md) | [Einzelgewichte](../02_Referenz-Analyse/Seiten/RS-14_Einzelgewichte.md) | – | [HS-14](Seiten/HS-14_Einzelgewichte.md) | [Einzelgewichte](Seiten/HS-14_Einzelgewichte.md) | 11 | kein Design; abgeleitet aus Designsystem und Modulen |
| [RS-15](../02_Referenz-Analyse/Seiten/RS-15_Trend.md) | [Trend](../02_Referenz-Analyse/Seiten/RS-15_Trend.md) | – | [HS-15](Seiten/HS-15_Trend.md) | [Trend](Seiten/HS-15_Trend.md) | 7 | kein Design; abgeleitet aus Designsystem und Modulen |
| [RS-16](../02_Referenz-Analyse/Seiten/RS-16_Schliessmaschine.md) | [Schließmaschine](../02_Referenz-Analyse/Seiten/RS-16_Schliessmaschine.md) | – | [HS-16](Seiten/HS-16_Schliessmaschine.md) | [Schließmaschine](Seiten/HS-16_Schliessmaschine.md) | 14 | kein eigenes Design; Bezug DS-02 (Zugangskachel oder Muster) |
| [RS-17](../02_Referenz-Analyse/Seiten/RS-17_Motorparameter-Schliessmaschine.md) | [Motorparameter (Schließmaschine)](../02_Referenz-Analyse/Seiten/RS-17_Motorparameter-Schliessmaschine.md) | – | [HS-17](Seiten/HS-17_Motorparameter-Schliessmaschine.md) | [Motorparameter (Schließmaschine)](Seiten/HS-17_Motorparameter-Schliessmaschine.md) | 11 | kein Design; abgeleitet aus Designsystem und Modulen |
| [RS-18](../02_Referenz-Analyse/Seiten/RS-18_Gewichtskorrektur-Schliessmaschine.md) | [Gewichtskorrektur (Schließmaschine)](../02_Referenz-Analyse/Seiten/RS-18_Gewichtskorrektur-Schliessmaschine.md) | – | [HS-18](Seiten/HS-18_Gewichtskorrektur-Schliessmaschine.md) | [Gewichtskorrektur (Schließmaschine)](Seiten/HS-18_Gewichtskorrektur-Schliessmaschine.md) | 13 | kein Design; abgeleitet aus Designsystem und Modulen |
| [RS-19](../02_Referenz-Analyse/Seiten/RS-19_Nachdosierer.md) | [Nachdosierer](../02_Referenz-Analyse/Seiten/RS-19_Nachdosierer.md) | – | [HS-19](Seiten/HS-19_Nachdosierer.md) | [Nachdosierer](Seiten/HS-19_Nachdosierer.md) | 17 | kein eigenes Design; Bezug DS-04 (Zugangskachel oder Muster) |
| [RS-20](../02_Referenz-Analyse/Seiten/RS-20_Motorparameter.md) | [Motorparameter (Nachdosierer)](../02_Referenz-Analyse/Seiten/RS-20_Motorparameter.md) | – | [HS-20](Seiten/HS-20_Motorparameter.md) | [Motorparameter (Nachdosierer)](Seiten/HS-20_Motorparameter.md) | 11 | kein Design; abgeleitet aus Designsystem und Modulen; Vorlage zusätzlich RS-12 |
| [RS-21](../02_Referenz-Analyse/Seiten/RS-21_Gewichtskorrektur.md) | [Gewichtskorrektur (Nachdosierer)](../02_Referenz-Analyse/Seiten/RS-21_Gewichtskorrektur.md) | – | [HS-21](Seiten/HS-21_Gewichtskorrektur.md) | [Gewichtskorrektur (Nachdosierer)](Seiten/HS-21_Gewichtskorrektur.md) | 13 | kein Design; abgeleitet aus Designsystem und Modulen; Vorlage zusätzlich RS-18 |
| [RS-22](../02_Referenz-Analyse/Seiten/RS-22_Heizungen.md) | [Heizungen](../02_Referenz-Analyse/Seiten/RS-22_Heizungen.md) | – | [HS-22](Seiten/HS-22_Heizungen.md) | [Heizungen](Seiten/HS-22_Heizungen.md) | 15 | kein eigenes Design; Bezug DS-02 (Zugangskachel oder Muster) |
| [RS-23](../02_Referenz-Analyse/Seiten/RS-23_Regulierung.md) | [Regulierung](../02_Referenz-Analyse/Seiten/RS-23_Regulierung.md) | – | [HS-23](Seiten/HS-23_Regulierung.md) | [Regulierung](Seiten/HS-23_Regulierung.md) | 14 | kein eigenes Design; Bezug DS-04 (Zugangskachel oder Muster) |
| [RS-24](../02_Referenz-Analyse/Seiten/RS-24_Bildschirm-reinigen.md) | [Bildschirm reinigen](../02_Referenz-Analyse/Seiten/RS-24_Bildschirm-reinigen.md) | – | [HS-24](Seiten/HS-24_Bildschirm-reinigen.md) | [Bildschirm reinigen](Seiten/HS-24_Bildschirm-reinigen.md) | 3 | kein eigenes Design; Bezug DS-02 (Zugangskachel oder Muster) |
| [RS-25](../02_Referenz-Analyse/Seiten/RS-25_Nocken.md) | [Nocken](../02_Referenz-Analyse/Seiten/RS-25_Nocken.md) | – | [HS-25](Seiten/HS-25_Nocken.md) | [Nocken](Seiten/HS-25_Nocken.md) | 15 | kein eigenes Design; Bezug DS-02 (Zugangskachel oder Muster) |
| [RS-26](../02_Referenz-Analyse/Seiten/RS-26_Nockenuebersicht.md) | [Nockenübersicht](../02_Referenz-Analyse/Seiten/RS-26_Nockenuebersicht.md) | – | [HS-26](Seiten/HS-26_Nockenuebersicht.md) | [Nockenübersicht](Seiten/HS-26_Nockenuebersicht.md) | 9 | kein Design; abgeleitet aus Designsystem und Modulen |
| [RS-27](../02_Referenz-Analyse/Seiten/RS-27_Waagen-Kalibrieren.md) | [Waagen Kalibrieren](../02_Referenz-Analyse/Seiten/RS-27_Waagen-Kalibrieren.md) | – | [HS-27](Seiten/HS-27_Waagen-Kalibrieren.md) | [Waagen Kalibrieren](Seiten/HS-27_Waagen-Kalibrieren.md) | 13 | kein eigenes Design; Bezug DS-02, DS-03, DS-04 (Zugangskachel oder Muster) |
| [RS-28](../02_Referenz-Analyse/Seiten/RS-28_Packungsregister.md) | [Packungsregister](../02_Referenz-Analyse/Seiten/RS-28_Packungsregister.md) | – | [HS-28](Seiten/HS-28_Packungsregister.md) | [Packungsregister](Seiten/HS-28_Packungsregister.md) | 8 | kein eigenes Design; Bezug DS-02 (Zugangskachel oder Muster) |
| [RS-29](../02_Referenz-Analyse/Seiten/RS-29_Produktionsstatistik.md) | [Produktionsstatistik](../02_Referenz-Analyse/Seiten/RS-29_Produktionsstatistik.md) | – | [HS-29](Seiten/HS-29_Produktionsstatistik.md) | [Produktionsstatistik](Seiten/HS-29_Produktionsstatistik.md) | 9 | kein Design; abgeleitet aus Designsystem und Modulen |
| [RS-30](../02_Referenz-Analyse/Seiten/RS-30_Handbetrieb-Auswahl.md) | [Handbetrieb Auswahl](../02_Referenz-Analyse/Seiten/RS-30_Handbetrieb-Auswahl.md) | – | [HS-30](Seiten/HS-30_Handbetrieb-Auswahl.md) | [Handbetrieb Auswahl](Seiten/HS-30_Handbetrieb-Auswahl.md) | 10 | kein eigenes Design; Bezug DS-02 (Zugangskachel oder Muster) |
| [RS-31](../02_Referenz-Analyse/Seiten/RS-31_Handbetrieb.md) | [Handbetrieb](../02_Referenz-Analyse/Seiten/RS-31_Handbetrieb.md) | – | [HS-31](Seiten/HS-31_Handbetrieb.md) | [Handbetrieb](Seiten/HS-31_Handbetrieb.md) | 16 | kein Design; abgeleitet aus Designsystem und Modulen |
| [RS-32](../02_Referenz-Analyse/Seiten/RS-32_Geber-setzen.md) | [Geber setzen](../02_Referenz-Analyse/Seiten/RS-32_Geber-setzen.md) | – | [HS-32](Seiten/HS-32_Geber-setzen.md) | [Geber setzen](Seiten/HS-32_Geber-setzen.md) | 12 | kein Design; abgeleitet aus Designsystem und Modulen |
| [RS-33](../02_Referenz-Analyse/Seiten/RS-33_EA-Uebersicht.md) | [EA-Übersicht](../02_Referenz-Analyse/Seiten/RS-33_EA-Uebersicht.md) | – | [HS-33](Seiten/HS-33_EA-Uebersicht.md) | [EA-Übersicht](Seiten/HS-33_EA-Uebersicht.md) | 10 | kein eigenes Design; Bezug DS-02 (Zugangskachel oder Muster) |
| [RS-34](../02_Referenz-Analyse/Seiten/RS-34_EA-Anzeige.md) | [EA-Anzeige](../02_Referenz-Analyse/Seiten/RS-34_EA-Anzeige.md) | – | [HS-34](Seiten/HS-34_EA-Anzeige.md) | [EA-Anzeige](Seiten/HS-34_EA-Anzeige.md) | 11 | kein Design; abgeleitet aus Designsystem und Modulen |
| [RS-35](../02_Referenz-Analyse/Seiten/RS-35_Systemeinstellungen.md) | [Systemeinstellungen](../02_Referenz-Analyse/Seiten/RS-35_Systemeinstellungen.md) | – | [HS-35](Seiten/HS-35_Systemeinstellungen.md) | [Systemeinstellungen](Seiten/HS-35_Systemeinstellungen.md) | 9 | kein eigenes Design; Bezug DS-02 (Zugangskachel oder Muster) |
| [RS-36](../02_Referenz-Analyse/Seiten/RS-36_Service.md) | [Service](../02_Referenz-Analyse/Seiten/RS-36_Service.md) | – | [HS-36](Seiten/HS-36_Service.md) | [Service](Seiten/HS-36_Service.md) | 12 | kein Design; abgeleitet aus Designsystem und Modulen |
| [RS-37](../02_Referenz-Analyse/Seiten/RS-37_Meldearchiv.md) | [Meldearchiv](../02_Referenz-Analyse/Seiten/RS-37_Meldearchiv.md) | – | [HS-37](Seiten/HS-37_Meldearchiv.md) | [Meldearchiv](Seiten/HS-37_Meldearchiv.md) | 10 | kein Design; abgeleitet aus Designsystem und Modulen |
| [RS-38](../02_Referenz-Analyse/Seiten/RS-38_Meldeanzeige.md) | [Meldeanzeige](../02_Referenz-Analyse/Seiten/RS-38_Meldeanzeige.md) | – | [HS-38](Seiten/HS-38_Meldeanzeige.md) | [Meldeanzeige](Seiten/HS-38_Meldeanzeige.md) | 8 | kein eigenes Design; Bezug DS-01 (Zugangskachel oder Muster) |
| [RS-39](../02_Referenz-Analyse/Seiten/RS-39_System-und-Antriebsinfos.md) | [System- und Antriebsinfos](../02_Referenz-Analyse/Seiten/RS-39_System-und-Antriebsinfos.md) | – | [HS-39](Seiten/HS-39_System-und-Antriebsinfos.md) | [System- und Antriebsinfos](Seiten/HS-39_System-und-Antriebsinfos.md) | 14 | kein Design; abgeleitet aus Designsystem und Modulen |

### 2.2 Zusatzseiten ohne Referenzseite (HS-40 bis HS-43)

Die Zusatzseiten haben keine RS-Datei (Annahme A-33). Herkunft und Belege stehen in der Kopfzeile „Quelle“ der jeweiligen HS-Datei.

| HS-ID | Neue Seite | Herkunft | Bezug RS | Bezug DS | Annahmen / offene Punkte | HM | Bemerkung |
|---|---|---|---|---|---|---|---|
| [HS-40](Seiten/HS-40_Zufuehrungen.md) | [Zuführungen (Zwischenseite)](Seiten/HS-40_Zufuehrungen.md) | Design + Navigation | [RS-04](../02_Referenz-Analyse/Seiten/RS-04_Einstellungen.md), [RS-06](../02_Referenz-Analyse/Seiten/RS-06_Zufuehrung-Karton.md), [RS-07](../02_Referenz-Analyse/Seiten/RS-07_Heissleim-Nordson.md) | [DS-02](../01_Design-Analyse/Seiten/DS-02_Einstellungen.md), [DS-03](../01_Design-Analyse/Seiten/DS-03_Heissleim.md), [DS-05](../01_Design-Analyse/Seiten/DS-05_Kartonzufuehrung.md) | A-33, OP-20 | 7 | Kachel „Zuführungen“ in DS-02 und Brotkrümel „Einstellung › Zuführungen › …“ in DS-03/DS-05 setzen die Zwischenebene voraus; die Seite selbst ist in Design und Referenz nicht abgebildet. |
| [HS-41](Seiten/HS-41_Dosierer-Uebersicht.md) | [Dosierer-Übersicht](Seiten/HS-41_Dosierer-Uebersicht.md) | Design (DS-04) + Referenz-Funktion | [RS-04](../02_Referenz-Analyse/Seiten/RS-04_Einstellungen.md), [RS-11](../02_Referenz-Analyse/Seiten/RS-11_Hauptdosierer-1-und-2.md), [RS-19](../02_Referenz-Analyse/Seiten/RS-19_Nachdosierer.md) | [DS-02](../01_Design-Analyse/Seiten/DS-02_Einstellungen.md), [DS-04](../01_Design-Analyse/Seiten/DS-04_Dosierer.md) | A-33 | 15 | Design-Vorlage DS-04 (Screenshot Dosierer); Fachlogik der Karten aus RS-11 und RS-19. |
| [HS-42](Seiten/HS-42_Waagen.md) | [Waagen (Zwischenseite)](Seiten/HS-42_Waagen.md) | Navigation + Referenz-Kachelliste | [RS-04](../02_Referenz-Analyse/Seiten/RS-04_Einstellungen.md), [RS-13](../02_Referenz-Analyse/Seiten/RS-13_Kontrollwaage.md), [RS-27](../02_Referenz-Analyse/Seiten/RS-27_Waagen-Kalibrieren.md) | [DS-02](../01_Design-Analyse/Seiten/DS-02_Einstellungen.md) | A-33, A-36 | 7 | Kachel „Waagen“ in DS-02 (Ziel nicht abgebildet) und die Waagen-Kacheln der RS-04 (Kontrollwaage, Endkontrollwaage, Waagen kalibrieren) werden hier gebündelt. |
| [HS-43](Seiten/HS-43_Schichtplan.md) | [Schichtplan (Platzhalter)](Seiten/HS-43_Schichtplan.md) | Design (Taste ohne Ziel), OP-02 | – | [DS-01](../01_Design-Analyse/Seiten/DS-01_Produktion.md) | A-33, OP-02 | 8 | Taste „Schichtplan“ in DS-01 hat in der Referenz keine Entsprechung; Platzhalterseite, nichts erfunden. |

### 2.3 Design-Seiten (DS-01 bis DS-05) auf neue Seiten

| DS-ID | Design-Seite | HS-ID (Vorlage) | Neue Seite | Weitere HS mit Bezug auf diese DS | Bemerkung |
|---|---|---|---|---|---|
| [DS-01](../01_Design-Analyse/Seiten/DS-01_Produktion.md) | [Produktion](../01_Design-Analyse/Seiten/DS-01_Produktion.md) | [HS-01](Seiten/HS-01_Produktion.md) | [Produktion](Seiten/HS-01_Produktion.md) | [HS-38](Seiten/HS-38_Meldeanzeige.md), [HS-43](Seiten/HS-43_Schichtplan.md) | Die Taste „Schichtplan“ ist Anlass für HS-43; Meldezeile und Rahmen sind Bezug für HS-38. |
| [DS-02](../01_Design-Analyse/Seiten/DS-02_Einstellungen.md) | [Einstellungen](../01_Design-Analyse/Seiten/DS-02_Einstellungen.md) | [HS-04](Seiten/HS-04_Einstellungen.md) | [Einstellungen](Seiten/HS-04_Einstellungen.md) | [HS-16](Seiten/HS-16_Schliessmaschine.md), [HS-22](Seiten/HS-22_Heizungen.md), [HS-24](Seiten/HS-24_Bildschirm-reinigen.md), [HS-25](Seiten/HS-25_Nocken.md), [HS-27](Seiten/HS-27_Waagen-Kalibrieren.md), [HS-28](Seiten/HS-28_Packungsregister.md), [HS-30](Seiten/HS-30_Handbetrieb-Auswahl.md), [HS-33](Seiten/HS-33_EA-Uebersicht.md), [HS-35](Seiten/HS-35_Systemeinstellungen.md), [HS-40](Seiten/HS-40_Zufuehrungen.md), [HS-41](Seiten/HS-41_Dosierer-Uebersicht.md), [HS-42](Seiten/HS-42_Waagen.md) | Kachelmenü; die Kacheln „Zuführungen“ und „Waagen“ sind Anlass für die Zwischenseiten HS-40 und HS-42. Die übrigen HS mit Bezug sind über Kacheln von HS-04 erreichbar. |
| [DS-03](../01_Design-Analyse/Seiten/DS-03_Heissleim.md) | [Heißleim](../01_Design-Analyse/Seiten/DS-03_Heissleim.md) | [HS-07](Seiten/HS-07_Heissleim-Nordson.md) | [Heißleim Nordson](Seiten/HS-07_Heissleim-Nordson.md) | [HS-05](Seiten/HS-05_Zufuehrung-Papier.md), [HS-08](Seiten/HS-08_Heissleim-Parameter.md), [HS-09](Seiten/HS-09_Heissleim-Druck.md), [HS-10](Seiten/HS-10_Zeitschaltuhr.md), [HS-27](Seiten/HS-27_Waagen-Kalibrieren.md), [HS-40](Seiten/HS-40_Zufuehrungen.md) | Der Screenshot zeigt die Heißleim-Anlage; Brotkrümel „Einstellung › Zuführungen › Heißleim“. |
| [DS-04](../01_Design-Analyse/Seiten/DS-04_Dosierer.md) | [Dosierer](../01_Design-Analyse/Seiten/DS-04_Dosierer.md) | [HS-41](Seiten/HS-41_Dosierer-Uebersicht.md) | [Dosierer-Übersicht](Seiten/HS-41_Dosierer-Uebersicht.md) | [HS-11](Seiten/HS-11_Hauptdosierer-1-und-2.md), [HS-19](Seiten/HS-19_Nachdosierer.md), [HS-23](Seiten/HS-23_Regulierung.md), [HS-27](Seiten/HS-27_Waagen-Kalibrieren.md) | Drei Dosierer-Karten; Detailseiten HS-11 und HS-19 stammen aus der Referenz (RS-11, RS-19). |
| [DS-05](../01_Design-Analyse/Seiten/DS-05_Kartonzufuehrung.md) | [Kartonzuführung](../01_Design-Analyse/Seiten/DS-05_Kartonzufuehrung.md) | [HS-06](Seiten/HS-06_Zufuehrung-Karton.md) | [Zuführung Karton](Seiten/HS-06_Zufuehrung-Karton.md) | [HS-05](Seiten/HS-05_Zufuehrung-Papier.md), [HS-40](Seiten/HS-40_Zufuehrungen.md) | Kartonzuführung mit Leimspuren-Grafik (HM-31). |

## 3 Tabelle B – Module

### 3.1 Referenz-Module (RM-01 bis RM-36) auf Design-Module und neue Module

„DM“ ist die Entsprechung laut [Modulliste RM](../02_Referenz-Analyse/Module/Modulliste.md). „HM“ sind alle neuen Module, deren Abschnitt „Herkunft“ das RM nennt. „Zusammen mit“ nennt die übrigen Quellen dieser HM (Zusammenführung, Duplikate entfernt).

| RM-ID | Referenzmodul | DM (Entsprechung) | HM | Zusammen mit |
|---|---|---|---|---|
| [RM-01](../02_Referenz-Analyse/Module/RM-01_Kopfzeile.md) | [Kopfzeile](../02_Referenz-Analyse/Module/RM-01_Kopfzeile.md) | [DM-03](../01_Design-Analyse/Module/DM-03_Kopfzeile-Logo.md), [DM-06](../01_Design-Analyse/Module/DM-06_Uhrzeit-und-Datum.md) | [HM-02](Module/HM-02_Kopfzeile.md), [HM-04](Module/HM-04_Brotkruemel-Navigation.md) | HM-02: DM-03, DM-05, DM-06; HM-04: DM-07 |
| [RM-02](../02_Referenz-Analyse/Module/RM-02_Meldezeile.md) | [Meldezeile](../02_Referenz-Analyse/Module/RM-02_Meldezeile.md) | [DM-04](../01_Design-Analyse/Module/DM-04_Meldezeile.md) | [HM-03](Module/HM-03_Meldezeile.md) | HM-03: DM-04 |
| [RM-03](../02_Referenz-Analyse/Module/RM-03_Funktionsleiste-unten.md) | [Funktionsleiste unten](../02_Referenz-Analyse/Module/RM-03_Funktionsleiste-unten.md) | [DM-02](../01_Design-Analyse/Module/DM-02_Navigationsleiste.md), [DM-09](../01_Design-Analyse/Module/DM-09_Funktionsleiste.md) | [HM-01](Module/HM-01_Seitenleiste.md), [HM-06](Module/HM-06_Funktionsleiste.md) | HM-01: DM-01, DM-02; HM-06: DM-09 |
| [RM-04](../02_Referenz-Analyse/Module/RM-04_Blaettertasten.md) | [Blättertasten](../02_Referenz-Analyse/Module/RM-04_Blaettertasten.md) | – | [HM-19](Module/HM-19_Blaettertasten.md) | HM-19: nur RM-04 |
| [RM-05](../02_Referenz-Analyse/Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) | [Eingabefeld mit Schlüsselsymbol](../02_Referenz-Analyse/Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) | [DM-15](../01_Design-Analyse/Module/DM-15_Beschriftung-Wert-Zeile.md), [DM-17](../01_Design-Analyse/Module/DM-17_Eingabefeld-mit-Schluesselsymbol.md) | [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md) | HM-12: DM-17 |
| [RM-06](../02_Referenz-Analyse/Module/RM-06_Eingabe-Pop-up.md) | [Eingabe-Pop-up](../02_Referenz-Analyse/Module/RM-06_Eingabe-Pop-up.md) | – | [HM-13](Module/HM-13_Eingabe-Pop-up.md) | HM-13: nur RM-06 |
| [RM-07](../02_Referenz-Analyse/Module/RM-07_Anzeigefeld.md) | [Anzeigefeld](../02_Referenz-Analyse/Module/RM-07_Anzeigefeld.md) | [DM-15](../01_Design-Analyse/Module/DM-15_Beschriftung-Wert-Zeile.md), [DM-16](../01_Design-Analyse/Module/DM-16_Wertfeld-Anzeige.md) | [HM-11](Module/HM-11_Anzeigefeld.md) | HM-11: DM-15, DM-16 |
| [RM-08](../02_Referenz-Analyse/Module/RM-08_Status-LED.md) | [Status-LED](../02_Referenz-Analyse/Module/RM-08_Status-LED.md) | [DM-14](../01_Design-Analyse/Module/DM-14_Status-LED.md) | [HM-09](Module/HM-09_Status-LED.md) | HM-09: DM-14 |
| [RM-09](../02_Referenz-Analyse/Module/RM-09_Fortschrittsbalken.md) | [Fortschrittsbalken](../02_Referenz-Analyse/Module/RM-09_Fortschrittsbalken.md) | [DM-18](../01_Design-Analyse/Module/DM-18_Fortschrittsbalken.md) | [HM-10](Module/HM-10_Fortschrittsbalken.md) | HM-10: DM-18 |
| [RM-10](../02_Referenz-Analyse/Module/RM-10_Umschalter-Taste.md) | [Umschalter-Taste](../02_Referenz-Analyse/Module/RM-10_Umschalter-Taste.md) | [DM-13](../01_Design-Analyse/Module/DM-13_Umschalter.md), [DM-19](../01_Design-Analyse/Module/DM-19_Zustandstaste.md) | [HM-08](Module/HM-08_Zustandstaste-Umschalter.md) | HM-08: DM-13, DM-19 |
| [RM-11](../02_Referenz-Analyse/Module/RM-11_Aktionstaste.md) | [Aktionstaste](../02_Referenz-Analyse/Module/RM-11_Aktionstaste.md) | [DM-10](../01_Design-Analyse/Module/DM-10_Funktionstaste-grau.md) | [HM-07](Module/HM-07_Aktionstaste.md) | HM-07: DM-10 |
| [RM-12](../02_Referenz-Analyse/Module/RM-12_Kennzahl-Kachel.md) | [Kennzahl-Kachel](../02_Referenz-Analyse/Module/RM-12_Kennzahl-Kachel.md) | [DM-08](../01_Design-Analyse/Module/DM-08_Kennzahl-Kachel.md) | [HM-05](Module/HM-05_Kennzahl-Kachel.md) | HM-05: DM-08 |
| [RM-13](../02_Referenz-Analyse/Module/RM-13_Pop-up-Rahmen.md) | [Pop-up-Rahmen](../02_Referenz-Analyse/Module/RM-13_Pop-up-Rahmen.md) | – | [HM-14](Module/HM-14_Popup-Rahmen.md) | HM-14: nur RM-13 |
| [RM-14](../02_Referenz-Analyse/Module/RM-14_Kachel-Navigation.md) | [Kachel-Navigation](../02_Referenz-Analyse/Module/RM-14_Kachel-Navigation.md) | [DM-12](../01_Design-Analyse/Module/DM-12_Kachel-Taste.md) | [HM-16](Module/HM-16_Kachel-Navigation.md) | HM-16: DM-12 |
| [RM-15](../02_Referenz-Analyse/Module/RM-15_Gruppenrahmen.md) | [Gruppenrahmen](../02_Referenz-Analyse/Module/RM-15_Gruppenrahmen.md) | [DM-11](../01_Design-Analyse/Module/DM-11_Gruppenbereich.md) | [HM-15](Module/HM-15_Gruppenbereich.md) | HM-15: DM-11 |
| [RM-16](../02_Referenz-Analyse/Module/RM-16_Motorparameter-Karte.md) | [Motorparameter-Karte](../02_Referenz-Analyse/Module/RM-16_Motorparameter-Karte.md) | – | [HM-21](Module/HM-21_Motorparameter-Karte.md) | HM-21: nur RM-16 |
| [RM-17](../02_Referenz-Analyse/Module/RM-17_Gewichtskorrektur-Tabelle.md) | [Gewichtskorrektur-Tabelle](../02_Referenz-Analyse/Module/RM-17_Gewichtskorrektur-Tabelle.md) | – | [HM-22](Module/HM-22_Gewichtskorrektur-Tabelle.md) | HM-22: nur RM-17 |
| [RM-18](../02_Referenz-Analyse/Module/RM-18_Dosierer-Seitengeruest.md) | [Dosierer-Seitengerüst](../02_Referenz-Analyse/Module/RM-18_Dosierer-Seitengeruest.md) | [DM-20](../01_Design-Analyse/Module/DM-20_Dosierer-Karte.md) | [HM-20](Module/HM-20_Dosierer-Karte.md) | HM-20: DM-20 |
| [RM-19](../02_Referenz-Analyse/Module/RM-19_Nockentabelle.md) | [Nockentabelle](../02_Referenz-Analyse/Module/RM-19_Nockentabelle.md) | – | [HM-23](Module/HM-23_Nockentabelle.md) | HM-23: nur RM-19 |
| [RM-20](../02_Referenz-Analyse/Module/RM-20_Nocken-Parameterzeile.md) | [Nocken-Parameterzeile](../02_Referenz-Analyse/Module/RM-20_Nocken-Parameterzeile.md) | – | [HM-24](Module/HM-24_Nocken-Parameterzeile.md) | HM-24: nur RM-20 |
| [RM-21](../02_Referenz-Analyse/Module/RM-21_Meldungsliste.md) | [Meldungsliste](../02_Referenz-Analyse/Module/RM-21_Meldungsliste.md) | – | [HM-25](Module/HM-25_Meldungsliste.md) | HM-25: nur RM-21 |
| [RM-22](../02_Referenz-Analyse/Module/RM-22_Trend-Diagramm.md) | [Trend-Diagramm](../02_Referenz-Analyse/Module/RM-22_Trend-Diagramm.md) | – | [HM-26](Module/HM-26_Diagramm.md) | HM-26: RM-30 |
| [RM-23](../02_Referenz-Analyse/Module/RM-23_Hinweis-Textfeld.md) | [Hinweis-Textfeld](../02_Referenz-Analyse/Module/RM-23_Hinweis-Textfeld.md) | – | [HM-27](Module/HM-27_Hinweis-Textfeld.md) | HM-27: nur RM-23 |
| [RM-24](../02_Referenz-Analyse/Module/RM-24_Temperaturzonen-Zeile.md) | [Temperaturzonen-Zeile](../02_Referenz-Analyse/Module/RM-24_Temperaturzonen-Zeile.md) | – | [HM-28](Module/HM-28_Temperaturzonen-Zeile.md) | HM-28: nur RM-24 |
| [RM-25](../02_Referenz-Analyse/Module/RM-25_Objekt-Ueberschrift.md) | [Objekt-Überschrift](../02_Referenz-Analyse/Module/RM-25_Objekt-Ueberschrift.md) | – | [HM-17](Module/HM-17_Titelzeile.md) | HM-17: DM-21 |
| [RM-26](../02_Referenz-Analyse/Module/RM-26_Wochen-Zeitplan.md) | [Wochen-Zeitplan](../02_Referenz-Analyse/Module/RM-26_Wochen-Zeitplan.md) | – | [HM-29](Module/HM-29_Wochen-Zeitplan.md) | HM-29: nur RM-26 |
| [RM-27](../02_Referenz-Analyse/Module/RM-27_Zeitplan-Eintrag-Pop-up.md) | [Zeitplan-Eintrag-Pop-up](../02_Referenz-Analyse/Module/RM-27_Zeitplan-Eintrag-Pop-up.md) | – | [HM-30](Module/HM-30_Zeitplan-Eintrag-Pop-up.md) | HM-30: nur RM-27 |
| [RM-28](../02_Referenz-Analyse/Module/RM-28_Leimspuren-Grafik.md) | [Leimspuren-Grafik](../02_Referenz-Analyse/Module/RM-28_Leimspuren-Grafik.md) | [DM-22](../01_Design-Analyse/Module/DM-22_Leimspuren-Grafik.md) | [HM-31](Module/HM-31_Leimspuren-Grafik.md) | HM-31: DM-22 |
| [RM-29](../02_Referenz-Analyse/Module/RM-29_Packungsregister-Grafik.md) | [Packungsregister-Grafik](../02_Referenz-Analyse/Module/RM-29_Packungsregister-Grafik.md) | – | [HM-32](Module/HM-32_Packungsregister-Grafik.md) | HM-32: nur RM-29 |
| [RM-30](../02_Referenz-Analyse/Module/RM-30_Tagesbalkendiagramm.md) | [Tagesbalkendiagramm](../02_Referenz-Analyse/Module/RM-30_Tagesbalkendiagramm.md) | – | [HM-26](Module/HM-26_Diagramm.md) | HM-26: RM-22 |
| [RM-31](../02_Referenz-Analyse/Module/RM-31_Zaehlerzeile.md) | [Zählerzeile](../02_Referenz-Analyse/Module/RM-31_Zaehlerzeile.md) | – | [HM-33](Module/HM-33_Zaehlerzeile.md) | HM-33: nur RM-31 |
| [RM-32](../02_Referenz-Analyse/Module/RM-32_Auswahlfeld-mit-Pfeiltasten.md) | [Auswahlfeld mit Pfeiltasten](../02_Referenz-Analyse/Module/RM-32_Auswahlfeld-mit-Pfeiltasten.md) | – | [HM-18](Module/HM-18_Auswahlfeld-Pfeiltasten.md) | HM-18: nur RM-32 |
| [RM-33](../02_Referenz-Analyse/Module/RM-33_Motor-Statuszeile.md) | [Motor-Statuszeile](../02_Referenz-Analyse/Module/RM-33_Motor-Statuszeile.md) | – | [HM-34](Module/HM-34_Motor-Statuszeile.md) | HM-34: nur RM-33 |
| [RM-34](../02_Referenz-Analyse/Module/RM-34_Regulierungs-Parameterblock.md) | [Regulierungs-Parameterblock](../02_Referenz-Analyse/Module/RM-34_Regulierungs-Parameterblock.md) | – | [HM-35](Module/HM-35_Regulierungs-Parameterblock.md) | HM-35: nur RM-34 |
| [RM-35](../02_Referenz-Analyse/Module/RM-35_EA-Zeile.md) | [EA-Zeile](../02_Referenz-Analyse/Module/RM-35_EA-Zeile.md) | – | [HM-36](Module/HM-36_EA-Zeile.md) | HM-36: nur RM-35 |
| [RM-36](../02_Referenz-Analyse/Module/RM-36_Wertegitter.md) | [Wertegitter](../02_Referenz-Analyse/Module/RM-36_Wertegitter.md) | – | [HM-37](Module/HM-37_Wertegitter.md) | HM-37: nur RM-36 |

### 3.2 Design-Module (DM-01 bis DM-22) auf Referenz-Module und neue Module

„RM laut Modulliste RM“ ist die Entsprechung aus der Modulliste der Referenz; „RM über HM“ sind die RM, die im selben HM zusammengeführt wurden. Unterschiede stehen in der Bemerkung.

| DM-ID | Designmodul | RM laut Modulliste RM | HM | RM über HM | Bemerkung |
|---|---|---|---|---|---|
| [DM-01](../01_Design-Analyse/Module/DM-01_Benutzerkennung.md) | [Benutzerkennung](../01_Design-Analyse/Module/DM-01_Benutzerkennung.md) | – | [HM-01](Module/HM-01_Seitenleiste.md) | [RM-03](../02_Referenz-Analyse/Module/RM-03_Funktionsleiste-unten.md) | Modulliste RM nennt keine Entsprechung; im HM mit RM-03 zusammengeführt |
| [DM-02](../01_Design-Analyse/Module/DM-02_Navigationsleiste.md) | [Navigationsleiste](../01_Design-Analyse/Module/DM-02_Navigationsleiste.md) | [RM-03](../02_Referenz-Analyse/Module/RM-03_Funktionsleiste-unten.md) | [HM-01](Module/HM-01_Seitenleiste.md) | [RM-03](../02_Referenz-Analyse/Module/RM-03_Funktionsleiste-unten.md) | übereinstimmend |
| [DM-03](../01_Design-Analyse/Module/DM-03_Kopfzeile-Logo.md) | [Kopfzeile Logo](../01_Design-Analyse/Module/DM-03_Kopfzeile-Logo.md) | [RM-01](../02_Referenz-Analyse/Module/RM-01_Kopfzeile.md) | [HM-02](Module/HM-02_Kopfzeile.md) | [RM-01](../02_Referenz-Analyse/Module/RM-01_Kopfzeile.md) | übereinstimmend |
| [DM-04](../01_Design-Analyse/Module/DM-04_Meldezeile.md) | [Meldezeile](../01_Design-Analyse/Module/DM-04_Meldezeile.md) | [RM-02](../02_Referenz-Analyse/Module/RM-02_Meldezeile.md) | [HM-03](Module/HM-03_Meldezeile.md) | [RM-02](../02_Referenz-Analyse/Module/RM-02_Meldezeile.md) | übereinstimmend |
| [DM-05](../01_Design-Analyse/Module/DM-05_Betriebsart-Anzeige.md) | [Betriebsart-Anzeige](../01_Design-Analyse/Module/DM-05_Betriebsart-Anzeige.md) | – | [HM-02](Module/HM-02_Kopfzeile.md) | [RM-01](../02_Referenz-Analyse/Module/RM-01_Kopfzeile.md) | Modulliste RM nennt keine Entsprechung; im HM mit RM-01 zusammengeführt |
| [DM-06](../01_Design-Analyse/Module/DM-06_Uhrzeit-und-Datum.md) | [Uhrzeit und Datum](../01_Design-Analyse/Module/DM-06_Uhrzeit-und-Datum.md) | [RM-01](../02_Referenz-Analyse/Module/RM-01_Kopfzeile.md) | [HM-02](Module/HM-02_Kopfzeile.md) | [RM-01](../02_Referenz-Analyse/Module/RM-01_Kopfzeile.md) | übereinstimmend |
| [DM-07](../01_Design-Analyse/Module/DM-07_Brotkruemel-Navigation.md) | [Brotkrümel-Navigation](../01_Design-Analyse/Module/DM-07_Brotkruemel-Navigation.md) | – | [HM-04](Module/HM-04_Brotkruemel-Navigation.md) | [RM-01](../02_Referenz-Analyse/Module/RM-01_Kopfzeile.md) | Modulliste RM nennt keine Entsprechung; im HM mit RM-01 zusammengeführt |
| [DM-08](../01_Design-Analyse/Module/DM-08_Kennzahl-Kachel.md) | [Kennzahl-Kachel](../01_Design-Analyse/Module/DM-08_Kennzahl-Kachel.md) | [RM-12](../02_Referenz-Analyse/Module/RM-12_Kennzahl-Kachel.md) | [HM-05](Module/HM-05_Kennzahl-Kachel.md) | [RM-12](../02_Referenz-Analyse/Module/RM-12_Kennzahl-Kachel.md) | übereinstimmend |
| [DM-09](../01_Design-Analyse/Module/DM-09_Funktionsleiste.md) | [Funktionsleiste](../01_Design-Analyse/Module/DM-09_Funktionsleiste.md) | [RM-03](../02_Referenz-Analyse/Module/RM-03_Funktionsleiste-unten.md) | [HM-06](Module/HM-06_Funktionsleiste.md) | [RM-03](../02_Referenz-Analyse/Module/RM-03_Funktionsleiste-unten.md) | übereinstimmend |
| [DM-10](../01_Design-Analyse/Module/DM-10_Funktionstaste-grau.md) | [Funktionstaste (grau)](../01_Design-Analyse/Module/DM-10_Funktionstaste-grau.md) | [RM-11](../02_Referenz-Analyse/Module/RM-11_Aktionstaste.md) | [HM-07](Module/HM-07_Aktionstaste.md) | [RM-11](../02_Referenz-Analyse/Module/RM-11_Aktionstaste.md) | übereinstimmend |
| [DM-11](../01_Design-Analyse/Module/DM-11_Gruppenbereich.md) | [Gruppenbereich](../01_Design-Analyse/Module/DM-11_Gruppenbereich.md) | [RM-15](../02_Referenz-Analyse/Module/RM-15_Gruppenrahmen.md) | [HM-15](Module/HM-15_Gruppenbereich.md) | [RM-15](../02_Referenz-Analyse/Module/RM-15_Gruppenrahmen.md) | übereinstimmend |
| [DM-12](../01_Design-Analyse/Module/DM-12_Kachel-Taste.md) | [Kachel-Taste](../01_Design-Analyse/Module/DM-12_Kachel-Taste.md) | [RM-14](../02_Referenz-Analyse/Module/RM-14_Kachel-Navigation.md) | [HM-16](Module/HM-16_Kachel-Navigation.md) | [RM-14](../02_Referenz-Analyse/Module/RM-14_Kachel-Navigation.md) | übereinstimmend |
| [DM-13](../01_Design-Analyse/Module/DM-13_Umschalter.md) | [Umschalter](../01_Design-Analyse/Module/DM-13_Umschalter.md) | [RM-10](../02_Referenz-Analyse/Module/RM-10_Umschalter-Taste.md) | [HM-08](Module/HM-08_Zustandstaste-Umschalter.md) | [RM-10](../02_Referenz-Analyse/Module/RM-10_Umschalter-Taste.md) | übereinstimmend |
| [DM-14](../01_Design-Analyse/Module/DM-14_Status-LED.md) | [Status-LED](../01_Design-Analyse/Module/DM-14_Status-LED.md) | [RM-08](../02_Referenz-Analyse/Module/RM-08_Status-LED.md) | [HM-09](Module/HM-09_Status-LED.md) | [RM-08](../02_Referenz-Analyse/Module/RM-08_Status-LED.md) | übereinstimmend |
| [DM-15](../01_Design-Analyse/Module/DM-15_Beschriftung-Wert-Zeile.md) | [Beschriftung-Wert-Zeile](../01_Design-Analyse/Module/DM-15_Beschriftung-Wert-Zeile.md) | [RM-05](../02_Referenz-Analyse/Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md), [RM-07](../02_Referenz-Analyse/Module/RM-07_Anzeigefeld.md) | [HM-11](Module/HM-11_Anzeigefeld.md) | [RM-07](../02_Referenz-Analyse/Module/RM-07_Anzeigefeld.md) | Modulliste RM nennt RM-05, RM-07; im selben HM nur RM-07 (RM-05 liegt in einem anderen HM) |
| [DM-16](../01_Design-Analyse/Module/DM-16_Wertfeld-Anzeige.md) | [Wertfeld (Anzeige)](../01_Design-Analyse/Module/DM-16_Wertfeld-Anzeige.md) | [RM-07](../02_Referenz-Analyse/Module/RM-07_Anzeigefeld.md) | [HM-11](Module/HM-11_Anzeigefeld.md) | [RM-07](../02_Referenz-Analyse/Module/RM-07_Anzeigefeld.md) | übereinstimmend |
| [DM-17](../01_Design-Analyse/Module/DM-17_Eingabefeld-mit-Schluesselsymbol.md) | [Eingabefeld mit Schlüsselsymbol](../01_Design-Analyse/Module/DM-17_Eingabefeld-mit-Schluesselsymbol.md) | [RM-05](../02_Referenz-Analyse/Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) | [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md) | [RM-05](../02_Referenz-Analyse/Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) | übereinstimmend |
| [DM-18](../01_Design-Analyse/Module/DM-18_Fortschrittsbalken.md) | [Fortschrittsbalken](../01_Design-Analyse/Module/DM-18_Fortschrittsbalken.md) | [RM-09](../02_Referenz-Analyse/Module/RM-09_Fortschrittsbalken.md) | [HM-10](Module/HM-10_Fortschrittsbalken.md) | [RM-09](../02_Referenz-Analyse/Module/RM-09_Fortschrittsbalken.md) | übereinstimmend |
| [DM-19](../01_Design-Analyse/Module/DM-19_Zustandstaste.md) | [Zustandstaste](../01_Design-Analyse/Module/DM-19_Zustandstaste.md) | [RM-10](../02_Referenz-Analyse/Module/RM-10_Umschalter-Taste.md) | [HM-08](Module/HM-08_Zustandstaste-Umschalter.md) | [RM-10](../02_Referenz-Analyse/Module/RM-10_Umschalter-Taste.md) | übereinstimmend |
| [DM-20](../01_Design-Analyse/Module/DM-20_Dosierer-Karte.md) | [Dosierer-Karte](../01_Design-Analyse/Module/DM-20_Dosierer-Karte.md) | [RM-18](../02_Referenz-Analyse/Module/RM-18_Dosierer-Seitengeruest.md) | [HM-20](Module/HM-20_Dosierer-Karte.md) | [RM-18](../02_Referenz-Analyse/Module/RM-18_Dosierer-Seitengeruest.md) | übereinstimmend |
| [DM-21](../01_Design-Analyse/Module/DM-21_Titelzeile-mit-Verschiebesymbol.md) | [Titelzeile mit Verschiebesymbol](../01_Design-Analyse/Module/DM-21_Titelzeile-mit-Verschiebesymbol.md) | – | [HM-17](Module/HM-17_Titelzeile.md) | [RM-25](../02_Referenz-Analyse/Module/RM-25_Objekt-Ueberschrift.md) | Modulliste RM nennt keine Entsprechung; im HM mit RM-25 zusammengeführt |
| [DM-22](../01_Design-Analyse/Module/DM-22_Leimspuren-Grafik.md) | [Leimspuren-Grafik](../01_Design-Analyse/Module/DM-22_Leimspuren-Grafik.md) | [RM-28](../02_Referenz-Analyse/Module/RM-28_Leimspuren-Grafik.md) | [HM-31](Module/HM-31_Leimspuren-Grafik.md) | [RM-28](../02_Referenz-Analyse/Module/RM-28_Leimspuren-Grafik.md) | übereinstimmend |

### 3.3 Neue Module (HM-01 bis HM-38) mit Herkunft

Die Herkunft ist dem Abschnitt „Herkunft“ der HM-Datei entnommen und stimmt mit den Spalten „DM-Herkunft“ und „RM-Herkunft“ der [Modulübersicht](Module/Modulliste.md) überein.

| HM-ID | Neues Modul | Herkunft | DM | RM | Bemerkung |
|---|---|---|---|---|---|
| [HM-01](Module/HM-01_Seitenleiste.md) | [Seitenleiste](Module/HM-01_Seitenleiste.md) | DM+RM | [DM-01](../01_Design-Analyse/Module/DM-01_Benutzerkennung.md), [DM-02](../01_Design-Analyse/Module/DM-02_Navigationsleiste.md) | [RM-03](../02_Referenz-Analyse/Module/RM-03_Funktionsleiste-unten.md) | Zusammenführung aus 3 Modulen |
| [HM-02](Module/HM-02_Kopfzeile.md) | [Kopfzeile (Logo, Betriebsart, Uhr)](Module/HM-02_Kopfzeile.md) | DM+RM | [DM-03](../01_Design-Analyse/Module/DM-03_Kopfzeile-Logo.md), [DM-05](../01_Design-Analyse/Module/DM-05_Betriebsart-Anzeige.md), [DM-06](../01_Design-Analyse/Module/DM-06_Uhrzeit-und-Datum.md) | [RM-01](../02_Referenz-Analyse/Module/RM-01_Kopfzeile.md) | Zusammenführung aus 4 Modulen |
| [HM-03](Module/HM-03_Meldezeile.md) | [Meldezeile](Module/HM-03_Meldezeile.md) | DM+RM | [DM-04](../01_Design-Analyse/Module/DM-04_Meldezeile.md) | [RM-02](../02_Referenz-Analyse/Module/RM-02_Meldezeile.md) | Duplikat zusammengeführt |
| [HM-04](Module/HM-04_Brotkruemel-Navigation.md) | [Brotkrümel-Navigation](Module/HM-04_Brotkruemel-Navigation.md) | DM+RM | [DM-07](../01_Design-Analyse/Module/DM-07_Brotkruemel-Navigation.md) | [RM-01](../02_Referenz-Analyse/Module/RM-01_Kopfzeile.md) | Duplikat zusammengeführt |
| [HM-05](Module/HM-05_Kennzahl-Kachel.md) | [Kennzahl-Kachel](Module/HM-05_Kennzahl-Kachel.md) | DM+RM | [DM-08](../01_Design-Analyse/Module/DM-08_Kennzahl-Kachel.md) | [RM-12](../02_Referenz-Analyse/Module/RM-12_Kennzahl-Kachel.md) | Duplikat zusammengeführt |
| [HM-06](Module/HM-06_Funktionsleiste.md) | [Funktionsleiste unten](Module/HM-06_Funktionsleiste.md) | DM+RM | [DM-09](../01_Design-Analyse/Module/DM-09_Funktionsleiste.md) | [RM-03](../02_Referenz-Analyse/Module/RM-03_Funktionsleiste-unten.md) | Duplikat zusammengeführt |
| [HM-07](Module/HM-07_Aktionstaste.md) | [Aktionstaste (Funktionstaste)](Module/HM-07_Aktionstaste.md) | DM+RM | [DM-10](../01_Design-Analyse/Module/DM-10_Funktionstaste-grau.md) | [RM-11](../02_Referenz-Analyse/Module/RM-11_Aktionstaste.md) | Duplikat zusammengeführt |
| [HM-08](Module/HM-08_Zustandstaste-Umschalter.md) | [Zustandstaste / Umschalter](Module/HM-08_Zustandstaste-Umschalter.md) | DM+RM | [DM-13](../01_Design-Analyse/Module/DM-13_Umschalter.md), [DM-19](../01_Design-Analyse/Module/DM-19_Zustandstaste.md) | [RM-10](../02_Referenz-Analyse/Module/RM-10_Umschalter-Taste.md) | Zusammenführung aus 3 Modulen |
| [HM-09](Module/HM-09_Status-LED.md) | [Status-LED](Module/HM-09_Status-LED.md) | DM+RM | [DM-14](../01_Design-Analyse/Module/DM-14_Status-LED.md) | [RM-08](../02_Referenz-Analyse/Module/RM-08_Status-LED.md) | Duplikat zusammengeführt |
| [HM-10](Module/HM-10_Fortschrittsbalken.md) | [Fortschrittsbalken](Module/HM-10_Fortschrittsbalken.md) | DM+RM | [DM-18](../01_Design-Analyse/Module/DM-18_Fortschrittsbalken.md) | [RM-09](../02_Referenz-Analyse/Module/RM-09_Fortschrittsbalken.md) | Duplikat zusammengeführt |
| [HM-11](Module/HM-11_Anzeigefeld.md) | [Anzeigefeld (Wert-Zeile)](Module/HM-11_Anzeigefeld.md) | DM+RM | [DM-15](../01_Design-Analyse/Module/DM-15_Beschriftung-Wert-Zeile.md), [DM-16](../01_Design-Analyse/Module/DM-16_Wertfeld-Anzeige.md) | [RM-07](../02_Referenz-Analyse/Module/RM-07_Anzeigefeld.md) | Zusammenführung aus 3 Modulen |
| [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md) | [Eingabefeld mit Schlüsselsymbol](Module/HM-12_Eingabefeld-Schluesselsymbol.md) | DM+RM | [DM-17](../01_Design-Analyse/Module/DM-17_Eingabefeld-mit-Schluesselsymbol.md) | [RM-05](../02_Referenz-Analyse/Module/RM-05_Eingabefeld-mit-Schluesselsymbol.md) | Duplikat zusammengeführt |
| [HM-13](Module/HM-13_Eingabe-Pop-up.md) | [Eingabe-Pop-up (Ziffernblock)](Module/HM-13_Eingabe-Pop-up.md) | nur RM | – | [RM-06](../02_Referenz-Analyse/Module/RM-06_Eingabe-Pop-up.md) | nur Referenz; im Design nicht vorhanden |
| [HM-14](Module/HM-14_Popup-Rahmen.md) | [Pop-up-Rahmen](Module/HM-14_Popup-Rahmen.md) | nur RM | – | [RM-13](../02_Referenz-Analyse/Module/RM-13_Pop-up-Rahmen.md) | nur Referenz; im Design nicht vorhanden |
| [HM-15](Module/HM-15_Gruppenbereich.md) | [Gruppenbereich](Module/HM-15_Gruppenbereich.md) | DM+RM | [DM-11](../01_Design-Analyse/Module/DM-11_Gruppenbereich.md) | [RM-15](../02_Referenz-Analyse/Module/RM-15_Gruppenrahmen.md) | Duplikat zusammengeführt |
| [HM-16](Module/HM-16_Kachel-Navigation.md) | [Kachel-Navigation](Module/HM-16_Kachel-Navigation.md) | DM+RM | [DM-12](../01_Design-Analyse/Module/DM-12_Kachel-Taste.md) | [RM-14](../02_Referenz-Analyse/Module/RM-14_Kachel-Navigation.md) | Duplikat zusammengeführt |
| [HM-17](Module/HM-17_Titelzeile.md) | [Titelzeile (Objektüberschrift)](Module/HM-17_Titelzeile.md) | DM+RM | [DM-21](../01_Design-Analyse/Module/DM-21_Titelzeile-mit-Verschiebesymbol.md) | [RM-25](../02_Referenz-Analyse/Module/RM-25_Objekt-Ueberschrift.md) | Duplikat zusammengeführt |
| [HM-18](Module/HM-18_Auswahlfeld-Pfeiltasten.md) | [Auswahlfeld mit Pfeiltasten](Module/HM-18_Auswahlfeld-Pfeiltasten.md) | nur RM | – | [RM-32](../02_Referenz-Analyse/Module/RM-32_Auswahlfeld-mit-Pfeiltasten.md) | nur Referenz; im Design nicht vorhanden |
| [HM-19](Module/HM-19_Blaettertasten.md) | [Blättertasten](Module/HM-19_Blaettertasten.md) | nur RM | – | [RM-04](../02_Referenz-Analyse/Module/RM-04_Blaettertasten.md) | nur Referenz; im Design nicht vorhanden |
| [HM-20](Module/HM-20_Dosierer-Karte.md) | [Dosierer-Karte / Dosierer-Seitengerüst](Module/HM-20_Dosierer-Karte.md) | DM+RM | [DM-20](../01_Design-Analyse/Module/DM-20_Dosierer-Karte.md) | [RM-18](../02_Referenz-Analyse/Module/RM-18_Dosierer-Seitengeruest.md) | Duplikat zusammengeführt |
| [HM-21](Module/HM-21_Motorparameter-Karte.md) | [Motorparameter-Karte](Module/HM-21_Motorparameter-Karte.md) | nur RM | – | [RM-16](../02_Referenz-Analyse/Module/RM-16_Motorparameter-Karte.md) | nur Referenz; im Design nicht vorhanden |
| [HM-22](Module/HM-22_Gewichtskorrektur-Tabelle.md) | [Gewichtskorrektur-Tabelle](Module/HM-22_Gewichtskorrektur-Tabelle.md) | nur RM | – | [RM-17](../02_Referenz-Analyse/Module/RM-17_Gewichtskorrektur-Tabelle.md) | nur Referenz; im Design nicht vorhanden |
| [HM-23](Module/HM-23_Nockentabelle.md) | [Nockentabelle](Module/HM-23_Nockentabelle.md) | nur RM | – | [RM-19](../02_Referenz-Analyse/Module/RM-19_Nockentabelle.md) | nur Referenz; im Design nicht vorhanden |
| [HM-24](Module/HM-24_Nocken-Parameterzeile.md) | [Nocken-Parameterzeile](Module/HM-24_Nocken-Parameterzeile.md) | nur RM | – | [RM-20](../02_Referenz-Analyse/Module/RM-20_Nocken-Parameterzeile.md) | nur Referenz; im Design nicht vorhanden |
| [HM-25](Module/HM-25_Meldungsliste.md) | [Meldungsliste](Module/HM-25_Meldungsliste.md) | nur RM | – | [RM-21](../02_Referenz-Analyse/Module/RM-21_Meldungsliste.md) | nur Referenz; im Design nicht vorhanden |
| [HM-26](Module/HM-26_Diagramm.md) | [Diagramm (Trend / Balken)](Module/HM-26_Diagramm.md) | nur RM | – | [RM-22](../02_Referenz-Analyse/Module/RM-22_Trend-Diagramm.md), [RM-30](../02_Referenz-Analyse/Module/RM-30_Tagesbalkendiagramm.md) | nur Referenz; im Design nicht vorhanden |
| [HM-27](Module/HM-27_Hinweis-Textfeld.md) | [Hinweis-Textfeld](Module/HM-27_Hinweis-Textfeld.md) | nur RM | – | [RM-23](../02_Referenz-Analyse/Module/RM-23_Hinweis-Textfeld.md) | nur Referenz; im Design nicht vorhanden |
| [HM-28](Module/HM-28_Temperaturzonen-Zeile.md) | [Temperaturzonen-Zeile](Module/HM-28_Temperaturzonen-Zeile.md) | nur RM | – | [RM-24](../02_Referenz-Analyse/Module/RM-24_Temperaturzonen-Zeile.md) | nur Referenz; im Design nicht vorhanden |
| [HM-29](Module/HM-29_Wochen-Zeitplan.md) | [Wochen-Zeitplan](Module/HM-29_Wochen-Zeitplan.md) | nur RM | – | [RM-26](../02_Referenz-Analyse/Module/RM-26_Wochen-Zeitplan.md) | nur Referenz; im Design nicht vorhanden |
| [HM-30](Module/HM-30_Zeitplan-Eintrag-Pop-up.md) | [Zeitplan-Eintrag-Pop-up](Module/HM-30_Zeitplan-Eintrag-Pop-up.md) | nur RM | – | [RM-27](../02_Referenz-Analyse/Module/RM-27_Zeitplan-Eintrag-Pop-up.md) | nur Referenz; im Design nicht vorhanden |
| [HM-31](Module/HM-31_Leimspuren-Grafik.md) | [Leimspuren-Grafik](Module/HM-31_Leimspuren-Grafik.md) | DM+RM | [DM-22](../01_Design-Analyse/Module/DM-22_Leimspuren-Grafik.md) | [RM-28](../02_Referenz-Analyse/Module/RM-28_Leimspuren-Grafik.md) | Duplikat zusammengeführt |
| [HM-32](Module/HM-32_Packungsregister-Grafik.md) | [Packungsregister-Grafik](Module/HM-32_Packungsregister-Grafik.md) | nur RM | – | [RM-29](../02_Referenz-Analyse/Module/RM-29_Packungsregister-Grafik.md) | nur Referenz; im Design nicht vorhanden |
| [HM-33](Module/HM-33_Zaehlerzeile.md) | [Zählerzeile](Module/HM-33_Zaehlerzeile.md) | nur RM | – | [RM-31](../02_Referenz-Analyse/Module/RM-31_Zaehlerzeile.md) | nur Referenz; im Design nicht vorhanden |
| [HM-34](Module/HM-34_Motor-Statuszeile.md) | [Motor-Statuszeile](Module/HM-34_Motor-Statuszeile.md) | nur RM | – | [RM-33](../02_Referenz-Analyse/Module/RM-33_Motor-Statuszeile.md) | nur Referenz; im Design nicht vorhanden |
| [HM-35](Module/HM-35_Regulierungs-Parameterblock.md) | [Regulierungs-Parameterblock](Module/HM-35_Regulierungs-Parameterblock.md) | nur RM | – | [RM-34](../02_Referenz-Analyse/Module/RM-34_Regulierungs-Parameterblock.md) | nur Referenz; im Design nicht vorhanden |
| [HM-36](Module/HM-36_EA-Zeile.md) | [EA-Zeile (Signalzeile)](Module/HM-36_EA-Zeile.md) | nur RM | – | [RM-35](../02_Referenz-Analyse/Module/RM-35_EA-Zeile.md) | nur Referenz; im Design nicht vorhanden |
| [HM-37](Module/HM-37_Wertegitter.md) | [Wertegitter (Einzelgewichte)](Module/HM-37_Wertegitter.md) | nur RM | – | [RM-36](../02_Referenz-Analyse/Module/RM-36_Wertegitter.md) | nur Referenz; im Design nicht vorhanden |
| [HM-38](Module/HM-38_Such-Pop-up.md) | [Such-Pop-up (Suche mit Trefferliste)](Module/HM-38_Such-Pop-up.md) | Ergänzung | – | – | Ergänzung aus Seitendateien ohne DM/RM (A-59, OP-30, OP-40) |

Verteilung der Herkunft: DM + RM 17, nur RM 20, nur DM 0, Ergänzung ohne DM/RM 1 (Summe 38).

## 4 Tabelle C – Verwendung der HM auf den HS

„Seiten“ zählt die HS, deren Abschnitt „Verwendete Module“ das HM nennt (Sätze mit „nicht verwendet“ zählen nicht). Die Spalten „Datei“ und „Liste“ sind die Zähler aus dem Abschnitt „Verwendet auf Seiten“ der HM-Datei und aus der [Modulübersicht](Module/Modulliste.md). Abweichungen sind fett markiert (siehe Abschnitt 6).

| HM-ID | Neues Modul | Seiten | Datei | Liste | HS-Verwendung |
|---|---|---|---|---|---|
| [HM-01](Module/HM-01_Seitenleiste.md) | [Seitenleiste](Module/HM-01_Seitenleiste.md) | 40 | 40 | 40 | [HS-01](Seiten/HS-01_Produktion.md), [HS-04](Seiten/HS-04_Einstellungen.md), [HS-05](Seiten/HS-05_Zufuehrung-Papier.md), [HS-06](Seiten/HS-06_Zufuehrung-Karton.md), [HS-07](Seiten/HS-07_Heissleim-Nordson.md), [HS-08](Seiten/HS-08_Heissleim-Parameter.md), [HS-09](Seiten/HS-09_Heissleim-Druck.md), [HS-10](Seiten/HS-10_Zeitschaltuhr.md), [HS-11](Seiten/HS-11_Hauptdosierer-1-und-2.md), [HS-12](Seiten/HS-12_Motorparameter.md), [HS-13](Seiten/HS-13_Kontrollwaage.md), [HS-14](Seiten/HS-14_Einzelgewichte.md), [HS-15](Seiten/HS-15_Trend.md), [HS-16](Seiten/HS-16_Schliessmaschine.md), [HS-17](Seiten/HS-17_Motorparameter-Schliessmaschine.md), [HS-18](Seiten/HS-18_Gewichtskorrektur-Schliessmaschine.md), [HS-19](Seiten/HS-19_Nachdosierer.md), [HS-20](Seiten/HS-20_Motorparameter.md), [HS-21](Seiten/HS-21_Gewichtskorrektur.md), [HS-22](Seiten/HS-22_Heizungen.md), [HS-23](Seiten/HS-23_Regulierung.md), [HS-25](Seiten/HS-25_Nocken.md), [HS-26](Seiten/HS-26_Nockenuebersicht.md), [HS-27](Seiten/HS-27_Waagen-Kalibrieren.md), [HS-28](Seiten/HS-28_Packungsregister.md), [HS-29](Seiten/HS-29_Produktionsstatistik.md), [HS-30](Seiten/HS-30_Handbetrieb-Auswahl.md), [HS-31](Seiten/HS-31_Handbetrieb.md), [HS-32](Seiten/HS-32_Geber-setzen.md), [HS-33](Seiten/HS-33_EA-Uebersicht.md), [HS-34](Seiten/HS-34_EA-Anzeige.md), [HS-35](Seiten/HS-35_Systemeinstellungen.md), [HS-36](Seiten/HS-36_Service.md), [HS-37](Seiten/HS-37_Meldearchiv.md), [HS-38](Seiten/HS-38_Meldeanzeige.md), [HS-39](Seiten/HS-39_System-und-Antriebsinfos.md), [HS-40](Seiten/HS-40_Zufuehrungen.md), [HS-41](Seiten/HS-41_Dosierer-Uebersicht.md), [HS-42](Seiten/HS-42_Waagen.md), [HS-43](Seiten/HS-43_Schichtplan.md) |
| [HM-02](Module/HM-02_Kopfzeile.md) | [Kopfzeile (Logo, Betriebsart, Uhr)](Module/HM-02_Kopfzeile.md) | 41 | 41 | 41 | [HS-01](Seiten/HS-01_Produktion.md), [HS-04](Seiten/HS-04_Einstellungen.md), [HS-05](Seiten/HS-05_Zufuehrung-Papier.md), [HS-06](Seiten/HS-06_Zufuehrung-Karton.md), [HS-07](Seiten/HS-07_Heissleim-Nordson.md), [HS-08](Seiten/HS-08_Heissleim-Parameter.md), [HS-09](Seiten/HS-09_Heissleim-Druck.md), [HS-10](Seiten/HS-10_Zeitschaltuhr.md), [HS-11](Seiten/HS-11_Hauptdosierer-1-und-2.md), [HS-12](Seiten/HS-12_Motorparameter.md), [HS-13](Seiten/HS-13_Kontrollwaage.md), [HS-14](Seiten/HS-14_Einzelgewichte.md), [HS-15](Seiten/HS-15_Trend.md), [HS-16](Seiten/HS-16_Schliessmaschine.md), [HS-17](Seiten/HS-17_Motorparameter-Schliessmaschine.md), [HS-18](Seiten/HS-18_Gewichtskorrektur-Schliessmaschine.md), [HS-19](Seiten/HS-19_Nachdosierer.md), [HS-20](Seiten/HS-20_Motorparameter.md), [HS-21](Seiten/HS-21_Gewichtskorrektur.md), [HS-22](Seiten/HS-22_Heizungen.md), [HS-23](Seiten/HS-23_Regulierung.md), [HS-24](Seiten/HS-24_Bildschirm-reinigen.md), [HS-25](Seiten/HS-25_Nocken.md), [HS-26](Seiten/HS-26_Nockenuebersicht.md), [HS-27](Seiten/HS-27_Waagen-Kalibrieren.md), [HS-28](Seiten/HS-28_Packungsregister.md), [HS-29](Seiten/HS-29_Produktionsstatistik.md), [HS-30](Seiten/HS-30_Handbetrieb-Auswahl.md), [HS-31](Seiten/HS-31_Handbetrieb.md), [HS-32](Seiten/HS-32_Geber-setzen.md), [HS-33](Seiten/HS-33_EA-Uebersicht.md), [HS-34](Seiten/HS-34_EA-Anzeige.md), [HS-35](Seiten/HS-35_Systemeinstellungen.md), [HS-36](Seiten/HS-36_Service.md), [HS-37](Seiten/HS-37_Meldearchiv.md), [HS-38](Seiten/HS-38_Meldeanzeige.md), [HS-39](Seiten/HS-39_System-und-Antriebsinfos.md), [HS-40](Seiten/HS-40_Zufuehrungen.md), [HS-41](Seiten/HS-41_Dosierer-Uebersicht.md), [HS-42](Seiten/HS-42_Waagen.md), [HS-43](Seiten/HS-43_Schichtplan.md) |
| [HM-03](Module/HM-03_Meldezeile.md) | [Meldezeile](Module/HM-03_Meldezeile.md) | 40 | 40 | 40 | [HS-01](Seiten/HS-01_Produktion.md), [HS-04](Seiten/HS-04_Einstellungen.md), [HS-05](Seiten/HS-05_Zufuehrung-Papier.md), [HS-06](Seiten/HS-06_Zufuehrung-Karton.md), [HS-07](Seiten/HS-07_Heissleim-Nordson.md), [HS-08](Seiten/HS-08_Heissleim-Parameter.md), [HS-09](Seiten/HS-09_Heissleim-Druck.md), [HS-10](Seiten/HS-10_Zeitschaltuhr.md), [HS-11](Seiten/HS-11_Hauptdosierer-1-und-2.md), [HS-12](Seiten/HS-12_Motorparameter.md), [HS-13](Seiten/HS-13_Kontrollwaage.md), [HS-14](Seiten/HS-14_Einzelgewichte.md), [HS-15](Seiten/HS-15_Trend.md), [HS-16](Seiten/HS-16_Schliessmaschine.md), [HS-17](Seiten/HS-17_Motorparameter-Schliessmaschine.md), [HS-18](Seiten/HS-18_Gewichtskorrektur-Schliessmaschine.md), [HS-19](Seiten/HS-19_Nachdosierer.md), [HS-20](Seiten/HS-20_Motorparameter.md), [HS-21](Seiten/HS-21_Gewichtskorrektur.md), [HS-22](Seiten/HS-22_Heizungen.md), [HS-23](Seiten/HS-23_Regulierung.md), [HS-25](Seiten/HS-25_Nocken.md), [HS-26](Seiten/HS-26_Nockenuebersicht.md), [HS-27](Seiten/HS-27_Waagen-Kalibrieren.md), [HS-28](Seiten/HS-28_Packungsregister.md), [HS-29](Seiten/HS-29_Produktionsstatistik.md), [HS-30](Seiten/HS-30_Handbetrieb-Auswahl.md), [HS-31](Seiten/HS-31_Handbetrieb.md), [HS-32](Seiten/HS-32_Geber-setzen.md), [HS-33](Seiten/HS-33_EA-Uebersicht.md), [HS-34](Seiten/HS-34_EA-Anzeige.md), [HS-35](Seiten/HS-35_Systemeinstellungen.md), [HS-36](Seiten/HS-36_Service.md), [HS-37](Seiten/HS-37_Meldearchiv.md), [HS-38](Seiten/HS-38_Meldeanzeige.md), [HS-39](Seiten/HS-39_System-und-Antriebsinfos.md), [HS-40](Seiten/HS-40_Zufuehrungen.md), [HS-41](Seiten/HS-41_Dosierer-Uebersicht.md), [HS-42](Seiten/HS-42_Waagen.md), [HS-43](Seiten/HS-43_Schichtplan.md) |
| [HM-04](Module/HM-04_Brotkruemel-Navigation.md) | [Brotkrümel-Navigation](Module/HM-04_Brotkruemel-Navigation.md) | 40 | 40 | 40 | [HS-01](Seiten/HS-01_Produktion.md), [HS-04](Seiten/HS-04_Einstellungen.md), [HS-05](Seiten/HS-05_Zufuehrung-Papier.md), [HS-06](Seiten/HS-06_Zufuehrung-Karton.md), [HS-07](Seiten/HS-07_Heissleim-Nordson.md), [HS-08](Seiten/HS-08_Heissleim-Parameter.md), [HS-09](Seiten/HS-09_Heissleim-Druck.md), [HS-10](Seiten/HS-10_Zeitschaltuhr.md), [HS-11](Seiten/HS-11_Hauptdosierer-1-und-2.md), [HS-12](Seiten/HS-12_Motorparameter.md), [HS-13](Seiten/HS-13_Kontrollwaage.md), [HS-14](Seiten/HS-14_Einzelgewichte.md), [HS-15](Seiten/HS-15_Trend.md), [HS-16](Seiten/HS-16_Schliessmaschine.md), [HS-17](Seiten/HS-17_Motorparameter-Schliessmaschine.md), [HS-18](Seiten/HS-18_Gewichtskorrektur-Schliessmaschine.md), [HS-19](Seiten/HS-19_Nachdosierer.md), [HS-20](Seiten/HS-20_Motorparameter.md), [HS-21](Seiten/HS-21_Gewichtskorrektur.md), [HS-22](Seiten/HS-22_Heizungen.md), [HS-23](Seiten/HS-23_Regulierung.md), [HS-25](Seiten/HS-25_Nocken.md), [HS-26](Seiten/HS-26_Nockenuebersicht.md), [HS-27](Seiten/HS-27_Waagen-Kalibrieren.md), [HS-28](Seiten/HS-28_Packungsregister.md), [HS-29](Seiten/HS-29_Produktionsstatistik.md), [HS-30](Seiten/HS-30_Handbetrieb-Auswahl.md), [HS-31](Seiten/HS-31_Handbetrieb.md), [HS-32](Seiten/HS-32_Geber-setzen.md), [HS-33](Seiten/HS-33_EA-Uebersicht.md), [HS-34](Seiten/HS-34_EA-Anzeige.md), [HS-35](Seiten/HS-35_Systemeinstellungen.md), [HS-36](Seiten/HS-36_Service.md), [HS-37](Seiten/HS-37_Meldearchiv.md), [HS-38](Seiten/HS-38_Meldeanzeige.md), [HS-39](Seiten/HS-39_System-und-Antriebsinfos.md), [HS-40](Seiten/HS-40_Zufuehrungen.md), [HS-41](Seiten/HS-41_Dosierer-Uebersicht.md), [HS-42](Seiten/HS-42_Waagen.md), [HS-43](Seiten/HS-43_Schichtplan.md) |
| [HM-05](Module/HM-05_Kennzahl-Kachel.md) | [Kennzahl-Kachel](Module/HM-05_Kennzahl-Kachel.md) | 41 | 41 | 41 | [HS-01](Seiten/HS-01_Produktion.md), [HS-02](Seiten/HS-02_Produktionszaehler.md), [HS-04](Seiten/HS-04_Einstellungen.md), [HS-05](Seiten/HS-05_Zufuehrung-Papier.md), [HS-06](Seiten/HS-06_Zufuehrung-Karton.md), [HS-07](Seiten/HS-07_Heissleim-Nordson.md), [HS-08](Seiten/HS-08_Heissleim-Parameter.md), [HS-09](Seiten/HS-09_Heissleim-Druck.md), [HS-10](Seiten/HS-10_Zeitschaltuhr.md), [HS-11](Seiten/HS-11_Hauptdosierer-1-und-2.md), [HS-12](Seiten/HS-12_Motorparameter.md), [HS-13](Seiten/HS-13_Kontrollwaage.md), [HS-14](Seiten/HS-14_Einzelgewichte.md), [HS-15](Seiten/HS-15_Trend.md), [HS-16](Seiten/HS-16_Schliessmaschine.md), [HS-17](Seiten/HS-17_Motorparameter-Schliessmaschine.md), [HS-18](Seiten/HS-18_Gewichtskorrektur-Schliessmaschine.md), [HS-19](Seiten/HS-19_Nachdosierer.md), [HS-20](Seiten/HS-20_Motorparameter.md), [HS-21](Seiten/HS-21_Gewichtskorrektur.md), [HS-22](Seiten/HS-22_Heizungen.md), [HS-23](Seiten/HS-23_Regulierung.md), [HS-25](Seiten/HS-25_Nocken.md), [HS-26](Seiten/HS-26_Nockenuebersicht.md), [HS-27](Seiten/HS-27_Waagen-Kalibrieren.md), [HS-28](Seiten/HS-28_Packungsregister.md), [HS-29](Seiten/HS-29_Produktionsstatistik.md), [HS-30](Seiten/HS-30_Handbetrieb-Auswahl.md), [HS-31](Seiten/HS-31_Handbetrieb.md), [HS-32](Seiten/HS-32_Geber-setzen.md), [HS-33](Seiten/HS-33_EA-Uebersicht.md), [HS-34](Seiten/HS-34_EA-Anzeige.md), [HS-35](Seiten/HS-35_Systemeinstellungen.md), [HS-36](Seiten/HS-36_Service.md), [HS-37](Seiten/HS-37_Meldearchiv.md), [HS-38](Seiten/HS-38_Meldeanzeige.md), [HS-39](Seiten/HS-39_System-und-Antriebsinfos.md), [HS-40](Seiten/HS-40_Zufuehrungen.md), [HS-41](Seiten/HS-41_Dosierer-Uebersicht.md), [HS-42](Seiten/HS-42_Waagen.md), [HS-43](Seiten/HS-43_Schichtplan.md) |
| [HM-06](Module/HM-06_Funktionsleiste.md) | [Funktionsleiste unten](Module/HM-06_Funktionsleiste.md) | 40 | 40 | 40 | [HS-01](Seiten/HS-01_Produktion.md), [HS-04](Seiten/HS-04_Einstellungen.md), [HS-05](Seiten/HS-05_Zufuehrung-Papier.md), [HS-06](Seiten/HS-06_Zufuehrung-Karton.md), [HS-07](Seiten/HS-07_Heissleim-Nordson.md), [HS-08](Seiten/HS-08_Heissleim-Parameter.md), [HS-09](Seiten/HS-09_Heissleim-Druck.md), [HS-10](Seiten/HS-10_Zeitschaltuhr.md), [HS-11](Seiten/HS-11_Hauptdosierer-1-und-2.md), [HS-12](Seiten/HS-12_Motorparameter.md), [HS-13](Seiten/HS-13_Kontrollwaage.md), [HS-14](Seiten/HS-14_Einzelgewichte.md), [HS-15](Seiten/HS-15_Trend.md), [HS-16](Seiten/HS-16_Schliessmaschine.md), [HS-17](Seiten/HS-17_Motorparameter-Schliessmaschine.md), [HS-18](Seiten/HS-18_Gewichtskorrektur-Schliessmaschine.md), [HS-19](Seiten/HS-19_Nachdosierer.md), [HS-20](Seiten/HS-20_Motorparameter.md), [HS-21](Seiten/HS-21_Gewichtskorrektur.md), [HS-22](Seiten/HS-22_Heizungen.md), [HS-23](Seiten/HS-23_Regulierung.md), [HS-25](Seiten/HS-25_Nocken.md), [HS-26](Seiten/HS-26_Nockenuebersicht.md), [HS-27](Seiten/HS-27_Waagen-Kalibrieren.md), [HS-28](Seiten/HS-28_Packungsregister.md), [HS-29](Seiten/HS-29_Produktionsstatistik.md), [HS-30](Seiten/HS-30_Handbetrieb-Auswahl.md), [HS-31](Seiten/HS-31_Handbetrieb.md), [HS-32](Seiten/HS-32_Geber-setzen.md), [HS-33](Seiten/HS-33_EA-Uebersicht.md), [HS-34](Seiten/HS-34_EA-Anzeige.md), [HS-35](Seiten/HS-35_Systemeinstellungen.md), [HS-36](Seiten/HS-36_Service.md), [HS-37](Seiten/HS-37_Meldearchiv.md), [HS-38](Seiten/HS-38_Meldeanzeige.md), [HS-39](Seiten/HS-39_System-und-Antriebsinfos.md), [HS-40](Seiten/HS-40_Zufuehrungen.md), [HS-41](Seiten/HS-41_Dosierer-Uebersicht.md), [HS-42](Seiten/HS-42_Waagen.md), [HS-43](Seiten/HS-43_Schichtplan.md) |
| [HM-07](Module/HM-07_Aktionstaste.md) | [Aktionstaste (Funktionstaste)](Module/HM-07_Aktionstaste.md) | 27 | 27 | 27 | [HS-01](Seiten/HS-01_Produktion.md), [HS-02](Seiten/HS-02_Produktionszaehler.md), [HS-04](Seiten/HS-04_Einstellungen.md), [HS-06](Seiten/HS-06_Zufuehrung-Karton.md), [HS-07](Seiten/HS-07_Heissleim-Nordson.md), [HS-10](Seiten/HS-10_Zeitschaltuhr.md), [HS-11](Seiten/HS-11_Hauptdosierer-1-und-2.md), [HS-13](Seiten/HS-13_Kontrollwaage.md), [HS-14](Seiten/HS-14_Einzelgewichte.md), [HS-16](Seiten/HS-16_Schliessmaschine.md), [HS-18](Seiten/HS-18_Gewichtskorrektur-Schliessmaschine.md), [HS-19](Seiten/HS-19_Nachdosierer.md), [HS-21](Seiten/HS-21_Gewichtskorrektur.md), [HS-22](Seiten/HS-22_Heizungen.md), [HS-23](Seiten/HS-23_Regulierung.md), [HS-25](Seiten/HS-25_Nocken.md), [HS-27](Seiten/HS-27_Waagen-Kalibrieren.md), [HS-29](Seiten/HS-29_Produktionsstatistik.md), [HS-30](Seiten/HS-30_Handbetrieb-Auswahl.md), [HS-31](Seiten/HS-31_Handbetrieb.md), [HS-32](Seiten/HS-32_Geber-setzen.md), [HS-33](Seiten/HS-33_EA-Uebersicht.md), [HS-35](Seiten/HS-35_Systemeinstellungen.md), [HS-36](Seiten/HS-36_Service.md), [HS-37](Seiten/HS-37_Meldearchiv.md), [HS-38](Seiten/HS-38_Meldeanzeige.md), [HS-41](Seiten/HS-41_Dosierer-Uebersicht.md) |
| [HM-08](Module/HM-08_Zustandstaste-Umschalter.md) | [Zustandstaste / Umschalter](Module/HM-08_Zustandstaste-Umschalter.md) | 12 | 12 | 12 | [HS-01](Seiten/HS-01_Produktion.md), [HS-06](Seiten/HS-06_Zufuehrung-Karton.md), [HS-07](Seiten/HS-07_Heissleim-Nordson.md), [HS-08](Seiten/HS-08_Heissleim-Parameter.md), [HS-10](Seiten/HS-10_Zeitschaltuhr.md), [HS-11](Seiten/HS-11_Hauptdosierer-1-und-2.md), [HS-14](Seiten/HS-14_Einzelgewichte.md), [HS-16](Seiten/HS-16_Schliessmaschine.md), [HS-19](Seiten/HS-19_Nachdosierer.md), [HS-22](Seiten/HS-22_Heizungen.md), [HS-23](Seiten/HS-23_Regulierung.md), [HS-41](Seiten/HS-41_Dosierer-Uebersicht.md) |
| [HM-09](Module/HM-09_Status-LED.md) | [Status-LED](Module/HM-09_Status-LED.md) | 12 | 12 | 12 | [HS-05](Seiten/HS-05_Zufuehrung-Papier.md), [HS-07](Seiten/HS-07_Heissleim-Nordson.md), [HS-11](Seiten/HS-11_Hauptdosierer-1-und-2.md), [HS-14](Seiten/HS-14_Einzelgewichte.md), [HS-19](Seiten/HS-19_Nachdosierer.md), [HS-22](Seiten/HS-22_Heizungen.md), [HS-25](Seiten/HS-25_Nocken.md), [HS-26](Seiten/HS-26_Nockenuebersicht.md), [HS-31](Seiten/HS-31_Handbetrieb.md), [HS-32](Seiten/HS-32_Geber-setzen.md), [HS-34](Seiten/HS-34_EA-Anzeige.md), [HS-41](Seiten/HS-41_Dosierer-Uebersicht.md) |
| [HM-10](Module/HM-10_Fortschrittsbalken.md) | [Fortschrittsbalken](Module/HM-10_Fortschrittsbalken.md) | 6 | 6 | 6 | [HS-07](Seiten/HS-07_Heissleim-Nordson.md), [HS-11](Seiten/HS-11_Hauptdosierer-1-und-2.md), [HS-19](Seiten/HS-19_Nachdosierer.md), [HS-24](Seiten/HS-24_Bildschirm-reinigen.md), [HS-39](Seiten/HS-39_System-und-Antriebsinfos.md), [HS-41](Seiten/HS-41_Dosierer-Uebersicht.md) |
| [HM-11](Module/HM-11_Anzeigefeld.md) | [Anzeigefeld (Wert-Zeile)](Module/HM-11_Anzeigefeld.md) | 20 | 20 | 20 | [HS-01](Seiten/HS-01_Produktion.md), [HS-02](Seiten/HS-02_Produktionszaehler.md), [HS-05](Seiten/HS-05_Zufuehrung-Papier.md), [HS-06](Seiten/HS-06_Zufuehrung-Karton.md), [HS-07](Seiten/HS-07_Heissleim-Nordson.md), [HS-08](Seiten/HS-08_Heissleim-Parameter.md), [HS-09](Seiten/HS-09_Heissleim-Druck.md), [HS-10](Seiten/HS-10_Zeitschaltuhr.md), [HS-11](Seiten/HS-11_Hauptdosierer-1-und-2.md), [HS-19](Seiten/HS-19_Nachdosierer.md), [HS-22](Seiten/HS-22_Heizungen.md), [HS-23](Seiten/HS-23_Regulierung.md), [HS-25](Seiten/HS-25_Nocken.md), [HS-27](Seiten/HS-27_Waagen-Kalibrieren.md), [HS-31](Seiten/HS-31_Handbetrieb.md), [HS-32](Seiten/HS-32_Geber-setzen.md), [HS-34](Seiten/HS-34_EA-Anzeige.md), [HS-36](Seiten/HS-36_Service.md), [HS-39](Seiten/HS-39_System-und-Antriebsinfos.md), [HS-41](Seiten/HS-41_Dosierer-Uebersicht.md) |
| [HM-12](Module/HM-12_Eingabefeld-Schluesselsymbol.md) | [Eingabefeld mit Schlüsselsymbol](Module/HM-12_Eingabefeld-Schluesselsymbol.md) | 22 | 22 | 22 | [HS-03](Seiten/HS-03_Maschinengeschwindigkeit.md), [HS-05](Seiten/HS-05_Zufuehrung-Papier.md), [HS-06](Seiten/HS-06_Zufuehrung-Karton.md), [HS-07](Seiten/HS-07_Heissleim-Nordson.md), [HS-08](Seiten/HS-08_Heissleim-Parameter.md), [HS-09](Seiten/HS-09_Heissleim-Druck.md), [HS-10](Seiten/HS-10_Zeitschaltuhr.md), [HS-11](Seiten/HS-11_Hauptdosierer-1-und-2.md), [HS-12](Seiten/HS-12_Motorparameter.md), [HS-13](Seiten/HS-13_Kontrollwaage.md), [HS-16](Seiten/HS-16_Schliessmaschine.md), [HS-17](Seiten/HS-17_Motorparameter-Schliessmaschine.md), [HS-18](Seiten/HS-18_Gewichtskorrektur-Schliessmaschine.md), [HS-19](Seiten/HS-19_Nachdosierer.md), [HS-20](Seiten/HS-20_Motorparameter.md), [HS-21](Seiten/HS-21_Gewichtskorrektur.md), [HS-22](Seiten/HS-22_Heizungen.md), [HS-23](Seiten/HS-23_Regulierung.md), [HS-25](Seiten/HS-25_Nocken.md), [HS-31](Seiten/HS-31_Handbetrieb.md), [HS-36](Seiten/HS-36_Service.md), [HS-39](Seiten/HS-39_System-und-Antriebsinfos.md) |
| [HM-13](Module/HM-13_Eingabe-Pop-up.md) | [Eingabe-Pop-up (Ziffernblock)](Module/HM-13_Eingabe-Pop-up.md) | 23 | 23 | 23 | [HS-03](Seiten/HS-03_Maschinengeschwindigkeit.md), [HS-05](Seiten/HS-05_Zufuehrung-Papier.md), [HS-06](Seiten/HS-06_Zufuehrung-Karton.md), [HS-07](Seiten/HS-07_Heissleim-Nordson.md), [HS-08](Seiten/HS-08_Heissleim-Parameter.md), [HS-09](Seiten/HS-09_Heissleim-Druck.md), [HS-10](Seiten/HS-10_Zeitschaltuhr.md), [HS-11](Seiten/HS-11_Hauptdosierer-1-und-2.md), [HS-12](Seiten/HS-12_Motorparameter.md), [HS-13](Seiten/HS-13_Kontrollwaage.md), [HS-16](Seiten/HS-16_Schliessmaschine.md), [HS-17](Seiten/HS-17_Motorparameter-Schliessmaschine.md), [HS-18](Seiten/HS-18_Gewichtskorrektur-Schliessmaschine.md), [HS-19](Seiten/HS-19_Nachdosierer.md), [HS-20](Seiten/HS-20_Motorparameter.md), [HS-21](Seiten/HS-21_Gewichtskorrektur.md), [HS-22](Seiten/HS-22_Heizungen.md), [HS-23](Seiten/HS-23_Regulierung.md), [HS-25](Seiten/HS-25_Nocken.md), [HS-31](Seiten/HS-31_Handbetrieb.md), [HS-36](Seiten/HS-36_Service.md), [HS-37](Seiten/HS-37_Meldearchiv.md), [HS-39](Seiten/HS-39_System-und-Antriebsinfos.md) |
| [HM-14](Module/HM-14_Popup-Rahmen.md) | [Pop-up-Rahmen](Module/HM-14_Popup-Rahmen.md) | 30 | 30 | 30 | [HS-01](Seiten/HS-01_Produktion.md), [HS-02](Seiten/HS-02_Produktionszaehler.md), [HS-03](Seiten/HS-03_Maschinengeschwindigkeit.md), [HS-04](Seiten/HS-04_Einstellungen.md), [HS-05](Seiten/HS-05_Zufuehrung-Papier.md), [HS-06](Seiten/HS-06_Zufuehrung-Karton.md), [HS-07](Seiten/HS-07_Heissleim-Nordson.md), [HS-08](Seiten/HS-08_Heissleim-Parameter.md), [HS-09](Seiten/HS-09_Heissleim-Druck.md), [HS-10](Seiten/HS-10_Zeitschaltuhr.md), [HS-11](Seiten/HS-11_Hauptdosierer-1-und-2.md), [HS-12](Seiten/HS-12_Motorparameter.md), [HS-13](Seiten/HS-13_Kontrollwaage.md), [HS-14](Seiten/HS-14_Einzelgewichte.md), [HS-16](Seiten/HS-16_Schliessmaschine.md), [HS-17](Seiten/HS-17_Motorparameter-Schliessmaschine.md), [HS-18](Seiten/HS-18_Gewichtskorrektur-Schliessmaschine.md), [HS-19](Seiten/HS-19_Nachdosierer.md), [HS-20](Seiten/HS-20_Motorparameter.md), [HS-21](Seiten/HS-21_Gewichtskorrektur.md), [HS-22](Seiten/HS-22_Heizungen.md), [HS-23](Seiten/HS-23_Regulierung.md), [HS-25](Seiten/HS-25_Nocken.md), [HS-30](Seiten/HS-30_Handbetrieb-Auswahl.md), [HS-31](Seiten/HS-31_Handbetrieb.md), [HS-33](Seiten/HS-33_EA-Uebersicht.md), [HS-35](Seiten/HS-35_Systemeinstellungen.md), [HS-36](Seiten/HS-36_Service.md), [HS-37](Seiten/HS-37_Meldearchiv.md), [HS-39](Seiten/HS-39_System-und-Antriebsinfos.md) |
| [HM-15](Module/HM-15_Gruppenbereich.md) | [Gruppenbereich](Module/HM-15_Gruppenbereich.md) | 21 | 21 | 21 | [HS-01](Seiten/HS-01_Produktion.md), [HS-04](Seiten/HS-04_Einstellungen.md), [HS-05](Seiten/HS-05_Zufuehrung-Papier.md), [HS-06](Seiten/HS-06_Zufuehrung-Karton.md), [HS-07](Seiten/HS-07_Heissleim-Nordson.md), [HS-08](Seiten/HS-08_Heissleim-Parameter.md), [HS-09](Seiten/HS-09_Heissleim-Druck.md), [HS-11](Seiten/HS-11_Hauptdosierer-1-und-2.md), [HS-12](Seiten/HS-12_Motorparameter.md), [HS-13](Seiten/HS-13_Kontrollwaage.md), [HS-16](Seiten/HS-16_Schliessmaschine.md), [HS-17](Seiten/HS-17_Motorparameter-Schliessmaschine.md), [HS-18](Seiten/HS-18_Gewichtskorrektur-Schliessmaschine.md), [HS-19](Seiten/HS-19_Nachdosierer.md), [HS-20](Seiten/HS-20_Motorparameter.md), [HS-21](Seiten/HS-21_Gewichtskorrektur.md), [HS-23](Seiten/HS-23_Regulierung.md), [HS-27](Seiten/HS-27_Waagen-Kalibrieren.md), [HS-39](Seiten/HS-39_System-und-Antriebsinfos.md), [HS-41](Seiten/HS-41_Dosierer-Uebersicht.md), [HS-43](Seiten/HS-43_Schichtplan.md) |
| [HM-16](Module/HM-16_Kachel-Navigation.md) | [Kachel-Navigation](Module/HM-16_Kachel-Navigation.md) | 7 | 7 | 7 | [HS-01](Seiten/HS-01_Produktion.md), [HS-04](Seiten/HS-04_Einstellungen.md), [HS-30](Seiten/HS-30_Handbetrieb-Auswahl.md), [HS-33](Seiten/HS-33_EA-Uebersicht.md), [HS-35](Seiten/HS-35_Systemeinstellungen.md), [HS-40](Seiten/HS-40_Zufuehrungen.md), [HS-42](Seiten/HS-42_Waagen.md) |
| [HM-17](Module/HM-17_Titelzeile.md) | [Titelzeile (Objektüberschrift)](Module/HM-17_Titelzeile.md) | 7 | 7 | 7 | [HS-11](Seiten/HS-11_Hauptdosierer-1-und-2.md), [HS-12](Seiten/HS-12_Motorparameter.md), [HS-27](Seiten/HS-27_Waagen-Kalibrieren.md), [HS-31](Seiten/HS-31_Handbetrieb.md), [HS-32](Seiten/HS-32_Geber-setzen.md), [HS-34](Seiten/HS-34_EA-Anzeige.md), [HS-41](Seiten/HS-41_Dosierer-Uebersicht.md) |
| [HM-18](Module/HM-18_Auswahlfeld-Pfeiltasten.md) | [Auswahlfeld mit Pfeiltasten](Module/HM-18_Auswahlfeld-Pfeiltasten.md) | 4 | 4 | 4 | [HS-10](Seiten/HS-10_Zeitschaltuhr.md), [HS-25](Seiten/HS-25_Nocken.md), [HS-27](Seiten/HS-27_Waagen-Kalibrieren.md), [HS-29](Seiten/HS-29_Produktionsstatistik.md) |
| [HM-19](Module/HM-19_Blaettertasten.md) | [Blättertasten](Module/HM-19_Blaettertasten.md) | 9 | 9 | 9 | [HS-11](Seiten/HS-11_Hauptdosierer-1-und-2.md), [HS-12](Seiten/HS-12_Motorparameter.md), [HS-25](Seiten/HS-25_Nocken.md), [HS-26](Seiten/HS-26_Nockenuebersicht.md), [HS-27](Seiten/HS-27_Waagen-Kalibrieren.md), [HS-31](Seiten/HS-31_Handbetrieb.md), [HS-32](Seiten/HS-32_Geber-setzen.md), [HS-34](Seiten/HS-34_EA-Anzeige.md), [HS-39](Seiten/HS-39_System-und-Antriebsinfos.md) |
| [HM-20](Module/HM-20_Dosierer-Karte.md) | [Dosierer-Karte / Dosierer-Seitengerüst](Module/HM-20_Dosierer-Karte.md) | 3 | 3 | 3 | [HS-11](Seiten/HS-11_Hauptdosierer-1-und-2.md), [HS-19](Seiten/HS-19_Nachdosierer.md), [HS-41](Seiten/HS-41_Dosierer-Uebersicht.md) |
| [HM-21](Module/HM-21_Motorparameter-Karte.md) | [Motorparameter-Karte](Module/HM-21_Motorparameter-Karte.md) | 3 | 3 | 3 | [HS-12](Seiten/HS-12_Motorparameter.md), [HS-17](Seiten/HS-17_Motorparameter-Schliessmaschine.md), [HS-20](Seiten/HS-20_Motorparameter.md) |
| [HM-22](Module/HM-22_Gewichtskorrektur-Tabelle.md) | [Gewichtskorrektur-Tabelle](Module/HM-22_Gewichtskorrektur-Tabelle.md) | 2 | 2 | 2 | [HS-18](Seiten/HS-18_Gewichtskorrektur-Schliessmaschine.md), [HS-21](Seiten/HS-21_Gewichtskorrektur.md) |
| [HM-23](Module/HM-23_Nockentabelle.md) | [Nockentabelle](Module/HM-23_Nockentabelle.md) | 1 | 1 | 1 | [HS-26](Seiten/HS-26_Nockenuebersicht.md) |
| [HM-24](Module/HM-24_Nocken-Parameterzeile.md) | [Nocken-Parameterzeile](Module/HM-24_Nocken-Parameterzeile.md) | 2 | 2 | 2 | [HS-16](Seiten/HS-16_Schliessmaschine.md), [HS-25](Seiten/HS-25_Nocken.md) |
| [HM-25](Module/HM-25_Meldungsliste.md) | [Meldungsliste](Module/HM-25_Meldungsliste.md) | 3 | 3 | 3 | [HS-36](Seiten/HS-36_Service.md), [HS-37](Seiten/HS-37_Meldearchiv.md), [HS-38](Seiten/HS-38_Meldeanzeige.md) |
| [HM-26](Module/HM-26_Diagramm.md) | [Diagramm (Trend / Balken)](Module/HM-26_Diagramm.md) | 2 | 2 | 2 | [HS-15](Seiten/HS-15_Trend.md), [HS-29](Seiten/HS-29_Produktionsstatistik.md) |
| [HM-27](Module/HM-27_Hinweis-Textfeld.md) | [Hinweis-Textfeld](Module/HM-27_Hinweis-Textfeld.md) | 16 | 16 | 16 | [HS-05](Seiten/HS-05_Zufuehrung-Papier.md), [HS-07](Seiten/HS-07_Heissleim-Nordson.md), [HS-10](Seiten/HS-10_Zeitschaltuhr.md), [HS-11](Seiten/HS-11_Hauptdosierer-1-und-2.md), [HS-16](Seiten/HS-16_Schliessmaschine.md), [HS-18](Seiten/HS-18_Gewichtskorrektur-Schliessmaschine.md), [HS-19](Seiten/HS-19_Nachdosierer.md), [HS-21](Seiten/HS-21_Gewichtskorrektur.md), [HS-22](Seiten/HS-22_Heizungen.md), [HS-24](Seiten/HS-24_Bildschirm-reinigen.md), [HS-27](Seiten/HS-27_Waagen-Kalibrieren.md), [HS-28](Seiten/HS-28_Packungsregister.md), [HS-31](Seiten/HS-31_Handbetrieb.md), [HS-32](Seiten/HS-32_Geber-setzen.md), [HS-41](Seiten/HS-41_Dosierer-Uebersicht.md), [HS-43](Seiten/HS-43_Schichtplan.md) |
| [HM-28](Module/HM-28_Temperaturzonen-Zeile.md) | [Temperaturzonen-Zeile](Module/HM-28_Temperaturzonen-Zeile.md) | 2 | 2 | 2 | [HS-08](Seiten/HS-08_Heissleim-Parameter.md), [HS-22](Seiten/HS-22_Heizungen.md) |
| [HM-29](Module/HM-29_Wochen-Zeitplan.md) | [Wochen-Zeitplan](Module/HM-29_Wochen-Zeitplan.md) | 1 | 1 | 1 | [HS-10](Seiten/HS-10_Zeitschaltuhr.md) |
| [HM-30](Module/HM-30_Zeitplan-Eintrag-Pop-up.md) | [Zeitplan-Eintrag-Pop-up](Module/HM-30_Zeitplan-Eintrag-Pop-up.md) | 1 | 1 | 1 | [HS-10](Seiten/HS-10_Zeitschaltuhr.md) |
| [HM-31](Module/HM-31_Leimspuren-Grafik.md) | [Leimspuren-Grafik](Module/HM-31_Leimspuren-Grafik.md) | 1 | 1 | 1 | [HS-06](Seiten/HS-06_Zufuehrung-Karton.md) |
| [HM-32](Module/HM-32_Packungsregister-Grafik.md) | [Packungsregister-Grafik](Module/HM-32_Packungsregister-Grafik.md) | 1 | 1 | 1 | [HS-28](Seiten/HS-28_Packungsregister.md) |
| [HM-33](Module/HM-33_Zaehlerzeile.md) | [Zählerzeile](Module/HM-33_Zaehlerzeile.md) | 1 | 1 | 1 | [HS-02](Seiten/HS-02_Produktionszaehler.md) |
| [HM-34](Module/HM-34_Motor-Statuszeile.md) | [Motor-Statuszeile](Module/HM-34_Motor-Statuszeile.md) | 1 | 1 | 1 | [HS-39](Seiten/HS-39_System-und-Antriebsinfos.md) |
| [HM-35](Module/HM-35_Regulierungs-Parameterblock.md) | [Regulierungs-Parameterblock](Module/HM-35_Regulierungs-Parameterblock.md) | 1 | 1 | 1 | [HS-23](Seiten/HS-23_Regulierung.md) |
| [HM-36](Module/HM-36_EA-Zeile.md) | [EA-Zeile (Signalzeile)](Module/HM-36_EA-Zeile.md) | 1 | 1 | 1 | [HS-34](Seiten/HS-34_EA-Anzeige.md) |
| [HM-37](Module/HM-37_Wertegitter.md) | [Wertegitter (Einzelgewichte)](Module/HM-37_Wertegitter.md) | 1 | 1 | 1 | [HS-14](Seiten/HS-14_Einzelgewichte.md) |
| [HM-38](Module/HM-38_Such-Pop-up.md) | [Such-Pop-up (Suche mit Trefferliste)](Module/HM-38_Such-Pop-up.md) | 3 | 3 | 3 | [HS-30](Seiten/HS-30_Handbetrieb-Auswahl.md), [HS-31](Seiten/HS-31_Handbetrieb.md), [HS-33](Seiten/HS-33_EA-Uebersicht.md) |

Summe der Verwendungen: 488 HM-HS-Paare auf 43 Seiten (im Mittel 11.3 Module je Seite). Seiten mit den meisten Modulen: HS-11 (19), HS-19 (17), HS-07 (16), HS-10 (16); mit den wenigsten: HS-03 (3), HS-24 (3), HS-02 (5).

## 5 Stichprobe: RS-Elementzeilen auf HS-Elemente mit Herkunft

Prüfung der Richtung RS → HS auf Elementebene für zehn Seiten (RS-01, 11, 13, 19, 25, 28, 31, 35, 37, 39). Je RS-Elementzeile (Tabellen mit Spalte „Typ“ im Abschnitt „Elemente“ der RS, ohne Bildlisten) wird in der Spalte „Herkunft“ bzw. im Elementnamen der HS-Tabellen gesucht. Automatisch gilt eine Zeile als zugeordnet, wenn mindestens 60 % der Namensbestandteile in einer HS-Zeile (Element oder Herkunft) vorkommen. Die übrigen Zeilen sind von Hand einer HS-Zeile zugeordnet, die das Skript per Textvergleich belegt. Bei den Seiten mit nummerierten Tabellen (RS-11, RS-13, RS-19) wird zusätzlich jede Nummer einzeln in der Herkunft gesucht.

| RS | HS | RS-Elementzeilen | automatisch | von Hand | ohne HS-Element | HS-Zeilen mit Herkunft | davon Ergänzung/Annahme | Nummern geprüft |
|---|---|---|---|---|---|---|---|---|
| [RS-01](../02_Referenz-Analyse/Seiten/RS-01_Produktion.md) | [HS-01](Seiten/HS-01_Produktion.md) | 33 | 32 | 1 | 0 | 45 | 0 | – |
| [RS-11](../02_Referenz-Analyse/Seiten/RS-11_Hauptdosierer-1-und-2.md) | [HS-11](Seiten/HS-11_Hauptdosierer-1-und-2.md) | 30 | 25 | 5 | 0 | 29 | 1 | T14: 12 von 12; T15: 7 von 7; T16: 2 von 2 |
| [RS-13](../02_Referenz-Analyse/Seiten/RS-13_Kontrollwaage.md) | [HS-13](Seiten/HS-13_Kontrollwaage.md) | 23 | 21 | 2 | 0 | 25 | 1 | RS-13: 19 von 19 |
| [RS-19](../02_Referenz-Analyse/Seiten/RS-19_Nachdosierer.md) | [HS-19](Seiten/HS-19_Nachdosierer.md) | 29 | 27 | 2 | 0 | 30 | 1 | T27: 13 von 13; T28: 6 von 6; T29: 3 von 3 |
| [RS-25](../02_Referenz-Analyse/Seiten/RS-25_Nocken.md) | [HS-25](Seiten/HS-25_Nocken.md) | 10 | 10 | 0 | 0 | 17 | 1 | – |
| [RS-28](../02_Referenz-Analyse/Seiten/RS-28_Packungsregister.md) | [HS-28](Seiten/HS-28_Packungsregister.md) | 12 | 10 | 2 | 0 | 19 | 1 | – |
| [RS-31](../02_Referenz-Analyse/Seiten/RS-31_Handbetrieb.md) | [HS-31](Seiten/HS-31_Handbetrieb.md) | 15 | 14 | 1 | 0 | 26 | 1 | – |
| [RS-35](../02_Referenz-Analyse/Seiten/RS-35_Systemeinstellungen.md) | [HS-35](Seiten/HS-35_Systemeinstellungen.md) | 13 | 13 | 0 | 0 | 15 | 1 | – |
| [RS-37](../02_Referenz-Analyse/Seiten/RS-37_Meldearchiv.md) | [HS-37](Seiten/HS-37_Meldearchiv.md) | 8 | 8 | 0 | 0 | 9 | 1 | – |
| [RS-39](../02_Referenz-Analyse/Seiten/RS-39_System-und-Antriebsinfos.md) | [HS-39](Seiten/HS-39_System-und-Antriebsinfos.md) | 14 | 14 | 0 | 0 | 15 | 0 | – |
| **Summe** | | **187** | **174** | **13** | **0** | **230** | **8** | |

Von Hand bestätigte Zeilen (Rahmen-Sammelzeilen und umbenannte Elemente):

| RS-Zeile | HS-Zeile (Anfang) | Herkunft in der HS (enthält) |
|---|---|---|
| RS-01: Maschinen-beleuchtung (Z3/S1) | HS-01: Maschinenbeleuchtung | T2 Z3/S1 |
| RS-11: Pfeiltasten vor / zurück | HS-11: Pfeiltasten | T16 Nr. 1 |
| RS-11: Logo APA-TEC | HS-11: Kopfzeile: Logo | W: Logo |
| RS-11: Taste „Produktion“ | HS-11: Seitenleiste | W: Schloss-Symbol |
| RS-11: Taste „Einstellungen“ | HS-11: Seitenleiste | W: Schloss-Symbol |
| RS-11: Taste „Zurück“ | HS-11: Seitenleiste | W: Schloss-Symbol |
| RS-13: T1 % | HS-13: T1 % | RS-13 Nr. 14 |
| RS-13: Einzelgewicht | HS-13: Taste „Einzelgewichte“ | RS-13 Nr. 19 |
| RS-19: Logo APA-TEC | HS-19: Kopfzeile: Logo | W: Logo |
| RS-19: Schloss-Symbol | HS-19: Seitenleiste | W: Schloss |
| RS-28: Bildlaufleiste horizontal | HS-28: Bildlauf | Bildlaufleiste |
| RS-28: Kopfzeile, Meldezeile, untere Leiste (Produktion, Einstellungen, Zurück, Schloss) | HS-28: Schloss-Symbol, Tasten | untere Leiste |
| RS-31: Kopfzeile, Meldezeile, Untere Funktionsleiste | HS-31: E24 Funktionsleiste unten | Untere Funktionsleiste |

Ergebnis: Auf allen zehn Seiten hat jede RS-Elementzeile ein HS-Element mit Herkunftsvermerk; bei RS-11, RS-13 und RS-19 sind alle Nummern der Handbuchtabellen (T14 1 bis 12, T15 1 bis 7, T16 1 bis 2; Tabellen 19 und 20 Nr. 1 bis 19; T27 1 bis 13, T28 1 bis 6, T29 1 bis 3) in der Herkunft genannt. Umgekehrt führen die HS zusätzliche Zeilen (Rahmen aus dem Design, Ergänzungen, Zerlegung von Sammelzeilen wie „Anfang / Ende“), die in der Spalte „Herkunft“ als solche erkennbar sind.

Gesamtlauf mit demselben Verfahren über alle 39 Seiten: 492 RS-Elementzeilen, 470 automatisch zugeordnet, 22 nicht automatisch. Diese 22 sind Rahmen-Sammelzeilen („Kopfzeile, Meldezeile, untere Leiste“, Logo, Schloss, Seitentitel), die HS im Rahmen-Block (HM-01, HM-02, HM-03) abbildet, oder Umbenennungen; Verfahren: Namensmuster plus Nachweis eines Rahmen-Elements in der HS. Offen: 0. Das Verfahren ist eine Näherung (Textvergleich); die Handbestätigung gilt nur für die zehn Stichprobenseiten, für die übrigen 29 Seiten gilt die Regel „Rahmenmuster plus Rahmen-Element in der HS“.

## 6 Befunde und Abweichungen

Die Befunde betreffen Dateien außerhalb dieser Rückverfolgung. Sie wurden nicht in dieser Datei behoben; die Spalte „Stand“ gibt den Zustand beim letzten Lauf des Skripts wieder.

| Nr. | Befund | Beleg | Empfehlung | Stand |
|---|---|---|---|---|
| RV-B01 | Doppelte Zeile HM-38 in der Modulübersicht: zwei Zeilen mit gleicher ID, Verweis einmal auf A-59, einmal auf A-60. Die Tabelle hat 38 Zeilen für 38 HM. | [Modulliste HM](Module/Modulliste.md), Tabelle am Ende | Eine Zeile löschen; passende Annahme prüfen (A-59 oder A-60). | behoben |
| RV-B02 | Ursprünglich führte die HM-05-Datei 43 Seiten (zusätzlich HS-03, HS-24), die HS-Abschnitte und die Modulübersicht 41. | [HM-05](Module/HM-05_Kennzahl-Kachel.md) gegen [HS-03](Seiten/HS-03_Maschinengeschwindigkeit.md), [HS-24](Seiten/HS-24_Bildschirm-reinigen.md) | HS-03 und HS-24 aus der Seitenliste streichen. | behoben |
| RV-B03 | Ursprünglich führten die HM-19-Datei und die Modulübersicht 11 Seiten (zusätzlich HS-19, HS-20); HS-19 und HS-20 schließen HM-19 aus, HM-19-P01 verlangt 9. | [HM-19](Module/HM-19_Blaettertasten.md), [HS-19](Seiten/HS-19_Nachdosierer.md), [HS-20](Seiten/HS-20_Motorparameter.md) | HS-19 und HS-20 streichen, Zähler auf 9. | behoben |
| RV-B04 | Ursprünglich nannte HS-29 das HM-07 (über HM-18), die HM-07-Datei und die Modulübersicht führten HS-29 nicht (26 statt 27 Seiten). | [HS-29](Seiten/HS-29_Produktionsstatistik.md), [HM-07](Module/HM-07_Aktionstaste.md) | HS-29 in HM-07 und der Modulübersicht ergänzen oder HM-07 aus HS-29 streichen. | behoben (HS-29 in HM-07 und Modulübersicht, 27 Seiten) |
| RV-B05 | Die Modulliste der Referenz nennt DM-01, DM-05, DM-07 und DM-21 als Design-Module ohne Entsprechung in der Referenz; im Konzept sind sie jedoch mit einem RM zusammengeführt (DM-01 mit RM-03 in HM-01, DM-05 und DM-07 mit RM-01 in HM-02 bzw. HM-04, DM-21 mit RM-25 in HM-17). Beide Aussagen sind für sich schlüssig (das Design-Modul tritt neben die Referenzfunktion), in Tabelle 3.2 aber als Unterschied sichtbar. | [Modulliste RM](../02_Referenz-Analyse/Module/Modulliste.md), Schlusssatz | Schlusssatz der RM-Modulliste um den Hinweis auf die Zusammenführung ergänzen oder die Spalte „Entsprechung DM“ von RM-03, RM-01, RM-25 nachziehen. | behoben (Hinweis in der Modulliste RM; Unterschied in Tabelle 3.2 bleibt als dokumentierte Zusammenführung sichtbar) |
| RV-B06 | RM-05 nennt in der Modulliste die Entsprechungen DM-17 und DM-15; DM-15 liegt in HM-11 (mit RM-07), RM-05 in HM-12 (mit DM-17). Das Paar RM-05 / DM-15 teilt kein HM. Der Inhalt ist abgedeckt (RM-05 in HM-12, DM-15 in HM-11), nur die Zuordnung ist feiner als die Modulliste. | Tabelle 3.1 und 3.2 | Kein Handlungsbedarf; Hinweis für den Prüfbericht. | behoben (Hinweis in der Modulübersicht HM) |

## 7 Prüfpunkte

Status „bestanden“ heißt: Der Test im Skript (Anhang A) hat das erwartete Ergebnis geliefert. „nicht bestanden“ heißt: Das Skript hat eine Abweichung in einer anderen Datei festgestellt (Abschnitt 6); diese Datei ist von der Abweichung nicht betroffen.

| ID | Prüfung | erwartetes Ergebnis | Messwert | Status |
|---|---|---|---|---|
| RV-P01 | Jede RS hat eine HS (gleiche Nummer, Quelle verlinkt die RS) | 39 von 39, keine ohne HS | 39 von 39; ohne HS: keine | bestanden |
| RV-P02 | Zusatzseiten HS-40 bis HS-43 ohne RS-Datei, Herkunft in „Quelle“ dokumentiert | 4 Seiten, alle mit „keine RS-Datei“ | 4 von 4 Zusatzseiten (HS-40, HS-41, HS-42, HS-43) | bestanden |
| RV-P03 | Jede DS ist genau einer HS zugeordnet (Konzept.md) und die HS verlinkt die DS | 5 von 5 | 5 von 5 (DS-01=HS-01, DS-02=HS-04, DS-03=HS-07, DS-04=HS-41, DS-05=HS-06) | bestanden |
| RV-P04 | Jede HS nennt mindestens ein HM, nur vorhandene HM-IDs, alle Links lösen auf | 43 von 43, 0 unbekannte, 0 tote Links | ohne HM: 0; unbekannte HM: 0; tote Links: 0 | bestanden |
| RV-P05 | Jedes DM ist in mindestens einem HM-Abschnitt „Herkunft“ genannt | 22 von 22 | 22 von 22; nicht abgebildet: keine | bestanden |
| RV-P06 | Jedes RM ist in mindestens einem HM-Abschnitt „Herkunft“ genannt | 36 von 36 | 36 von 36; nicht abgebildet: keine | bestanden |
| RV-P07 | Jedes HM hat einen nicht leeren Abschnitt „Herkunft“; DM/RM-Angaben stimmen mit der Modulübersicht überein | 38 von 38, 0 Abweichungen | ohne Herkunft: 0; abweichend von Modulübersicht: 0; Verteilung DM+RM 17, nur RM 20, nur DM 0, Ergänzung 1 | bestanden |
| RV-P08 | Zählwerte RS, DS, HS, RM, DM, HM | 39 / 5 / 43 / 36 / 22 / 38 | 39 / 5 / 43 / 36 / 22 / 38; RM-Modulliste 36 Zeilen, Seitenzähler der RM stimmen: ja | bestanden |
| RV-P09 | Alle relativen Links in dieser Datei führen auf eine vorhandene Datei | 0 tote Links | 1207 Links geprüft, 0 tot | bestanden |
| RV-P10 | Beidseitigkeit: HS-Abschnitt „Verwendete Module“ gegen HM-Abschnitt „Verwendet auf Seiten“ | 38 von 38 HM ohne Abweichung | 38 von 38; abweichend: keine (RV-B02, RV-B03, RV-B04) | bestanden |
| RV-P11 | Seitenzähler der Modulübersicht gegen HS-Abschnitte | 38 von 38 gleich | 38 von 38; abweichend: keine | bestanden |
| RV-P12 | Modulübersicht HM führt jede HM-ID genau einmal | 38 Zeilen | 38 Zeilen; doppelt: keine (RV-B01) | bestanden |
| RV-P13 | Stichprobe 10 Seiten: jede RS-Elementzeile hat ein HS-Element mit Herkunft | 0 ohne HS-Element, alle Nummern gefunden | 187 Zeilen, 174 automatisch, 13 von Hand, ohne Entsprechung: 0; fehlende Nummern: 0 | bestanden |
| RV-P14 | Gesamtlauf aller 39 Seiten: keine RS-Elementzeile ohne Entsprechung (Näherung) | 0 offen | 492 Zeilen, 22 nicht automatisch, offen: 0 | bestanden |
| RV-P15 | Jedes Paar RM → DM (Entsprechung der Modulliste RM) liegt in einem gemeinsamen HM | 0 Paare ohne gemeinsames HM oder Hinweis in der Modulübersicht | 1 Paar(e): RM-05 / DM-15 (RV-B06; dokumentiert) | bestanden |
| RV-P16 | Unterschiede zwischen „DM ohne RM“ der Modulliste RM und der Zusammenführung im HM | 0 oder dokumentierter Hinweis | 5 DM: DM-01, DM-05, DM-07, DM-15, DM-21 (RV-B05, RV-B06; dokumentiert) | bestanden |

RV-P15 und RV-P16 gelten als bestanden, wenn der Unterschied in den Modullisten ausdrücklich dokumentiert ist (Hinweis zu DM-01/03/05/07/21 in der Modulliste RM, Hinweis zu RM-05 / DM-15 in der Modulübersicht HM); die Existenz des Hinweises wird im Skript per Textsuche geprüft. Offene Abweichungen liegen in Modullisten und HM-Dateien, nicht in dieser Datei (Spalte „Stand“ in Abschnitt 6).

## 8 Offene Punkte

- Offene Befunde: keine (siehe Abschnitt 6). Keine fachliche Lücke: jede RS, jedes RM und jedes DM ist abgebildet.
- Die Elementprüfung (Abschnitt 5) ist ein Textvergleich und nur für zehn Seiten von Hand bestätigt. Eine vollständige Handprüfung der übrigen 29 Seiten ist nicht erfolgt.

## Anhang A – Skript

Das Skript erzeugt diese Datei (`python3 rv.py <Ausgabedatei>`) und liefert alle Messwerte. Hier ist der Prüfteil (Bibliothek und Prüfungen) wiedergegeben; der Erzeugungsteil setzt nur Tabellen aus den Ergebnissen. Es liest ausschließlich Dateien in `docs/` und schreibt nichts außer der Ausgabedatei.

```python
import re, os, glob
ROOT = '/pfad/zum/repo/docs'
def rd(p): return open(p, encoding='utf-8').read()
def files(sub, pre):
    d = {}
    for p in sorted(glob.glob(f'{ROOT}/{sub}/{pre}-*.md')):
        b = os.path.basename(p); m = re.match(rf'({pre}-\d\d)_(.*)\.md', b)
        d[m.group(1)] = (b, rd(p))
    return d
RS = files('02_Referenz-Analyse/Seiten', 'RS'); DS = files('01_Design-Analyse/Seiten', 'DS')
HS = files('03_HMI-Konzept/Seiten', 'HS'); RM = files('02_Referenz-Analyse/Module', 'RM')
DM = files('01_Design-Analyse/Module', 'DM'); HM = files('03_HMI-Konzept/Module', 'HM')
def section(txt, start):
    m = re.search(r'^## ' + re.escape(start) + r'.*?$', txt, re.M)
    if not m: return None
    rest = txt[m.end():]; n = re.search(r'^## ', rest, re.M)
    return rest[:n.start()] if n else rest
def ids(s, pre): return sorted(set(re.findall(rf'\b{pre}-\d\d\b', s)))
def title(t): return re.match(r'# \S+ – (.*)', t).group(1).strip()
def quelle(t): return re.search(r'^- Quelle:.*$', t, re.M).group(0)
NEG = re.compile(r'[Nn]icht verwendet|nutzt .* nicht|werden nicht verwendet')
def hm_used(txt):
    """HM-IDs aus 'Verwendete Module'; Saetze mit Verneinung (nicht verwendet) zaehlen nicht."""
    used = set()
    for line in (section(txt, 'Verwendete Module') or '').split('\n'):
        for sent in re.split(r'(?<=[.;])\s+', line):
            if NEG.search(sent): continue
            used |= set(re.findall(r'HM-\d\d', sent))
    return used
def rngs(lst):
    return ', '.join(lst)
def tables(sec):
    out = []; cur = None
    for line in sec.split('\n'):
        if line.startswith('|'):
            cells = [c.strip() for c in line.strip().strip('|').split('|')]
            if cur is None: cur = {'h': cells, 'rows': []}; out.append(cur)
            elif set(''.join(cells)) <= set('-: '): pass
            else: cur['rows'].append(cells)
        else: cur = None
    return out
def norm(s):
    s = s.lower().replace('ä', 'ae').replace('ö', 'oe').replace('ü', 'ue').replace('ß', 'ss')
    return re.sub(r'[^a-z0-9 ]', ' ', s)
STOP = set('der die das und mit von im in zu auf ein eine den dem des bild laut'.split())
def toks(s):
    s = re.sub(r'\([^)]*\)', '', s)
    return [t for t in norm(s).split() if len(t) >= 3 and t not in STOP]
def rs_elems(n):
    sec = section(RS[n][1], 'Elemente') or ''; res = []
    for tb in tables(sec):
        h = [x.lower() for x in tb['h']]
        if any('datei' in x or 'pixel' in x for x in h) or h[0] == 'bild' or 'typ' not in ' '.join(h): continue
        ei = next((i for i, x in enumerate(h) if x.startswith('element')), None)
        if ei is None: ei = next((i for i, x in enumerate(h) if x.startswith('funktion')), 0)
        ni = 0 if h[0].startswith('nr') else None
        for r in tb['rows']:
            if len(r) > ei: res.append((r[ni] if ni is not None else '', r[ei]))
    return res
def hs_rows(n):
    sec = section(HS[n][1], 'Elemente') or ''; res = []
    for tb in tables(sec):
        h = [x.lower() for x in tb['h']]
        hi = next((i for i, x in enumerate(h) if x.startswith('herkunft')), None)
        if hi is None: continue
        for r in tb['rows']: res.append((r[0], r[hi] if len(r) > hi else '', ' '.join(r)))
    return res

R = {}   # Ergebnisse
# Seiten
hs_q = {h: quelle(HS[h][1]) for h in HS}
R['n'] = dict(RS=len(RS), DS=len(DS), HS=len(HS), RM=len(RM), DM=len(DM), HM=len(HM))
rs2hs = {r: [h for h in HS if r in ids(hs_q[h], 'RS') and h == 'HS-' + r[3:]] for r in RS}
R['rs_without_hs'] = [r for r in RS if len(rs2hs[r]) != 1]
konz = rd(f'{ROOT}/03_HMI-Konzept/Konzept.md')
ds2hs = {}
for m in re.finditer(r'^\| (HS-\d\d) \|.*?\| ja \((DS-\d\d)\) \|', konz, re.M): ds2hs.setdefault(m.group(2), []).append(m.group(1))
R['ds2hs'] = ds2hs
R['ds_bad'] = [d for d in DS if len(ds2hs.get(d, [])) != 1 or d not in ids(hs_q[ds2hs[d][0]], 'DS')] if all(d in ds2hs for d in DS) else list(DS)
# Zusatzseiten
extra = [h for h in HS if h not in {'HS-' + r[3:] for r in RS}]
R['extra'] = extra
R['extra_noRSfile'] = [h for h in extra if 'keine RS-Datei' in hs_q[h]]
# HM je HS
used = {h: hm_used(HS[h][1]) for h in HS}
R['hs_unknown_hm'] = {h: sorted(u - set(HM)) for h, u in used.items() if u - set(HM)}
R['hs_no_hm'] = [h for h in HS if not used[h]]
inv = {}
for h, s in used.items():
    for m in s: inv.setdefault(m, set()).add(h)
# Links in HS-Abschnitten 'Verwendete Module' zeigen auf vorhandene Dateien
bad_links = []
for h in HS:
    for m in re.finditer(r'\]\(([^)#]+)\)', section(HS[h][1], 'Verwendete Module') or ''):
        if not os.path.exists(os.path.normpath(os.path.join(f'{ROOT}/03_HMI-Konzept/Seiten', m.group(1)))): bad_links.append((h, m.group(1)))
R['hs_bad_links'] = bad_links
# HM: Herkunft
def herk(hm):
    s = section(HM[hm][1], 'Herkunft')
    if s is None or not s.strip(): return None
    if 'Keine DM- oder RM-Entsprechung' in s: return dict(DM=[], RM=[], text=s.strip())
    return dict(DM=ids(s, 'DM'), RM=ids(s, 'RM'), text=s.strip())
H = {hm: herk(hm) for hm in HM}
R['hm_without_herkunft'] = [h for h in HM if H[h] is None]
ML = rd(f'{ROOT}/03_HMI-Konzept/Module/Modulliste.md')
mlrows = {}
for l in ML.split('\n'):
    m = re.match(r'\| \[(HM-\d\d)\]', l)
    if m: mlrows.setdefault(m.group(1), []).append([x.strip() for x in l.strip().strip('|').split('|')])
R['ml_dups'] = {k: len(v) for k, v in mlrows.items() if len(v) > 1}
def expand(s):
    out = set()
    for m in re.finditer(r'HS-(\d\d)(?: bis HS-(\d\d))?', s):
        a = int(m.group(1)); b = int(m.group(2) or m.group(1)); out |= {f'HS-{i:02d}' for i in range(a, b + 1)}
    return out
ml_dm = {h: set(ids(v[0][3], 'DM')) for h, v in mlrows.items()}; ml_rm = {h: set(ids(v[0][4], 'RM')) for h, v in mlrows.items()}
ml_hs = {h: expand(v[0][5]) for h, v in mlrows.items()}
ml_cnt = {h: int(re.search(r'\((\d+)\)', v[0][5]).group(1)) for h, v in mlrows.items()}
R['herk_vs_ml'] = [h for h in HM if set(H[h]['DM']) != ml_dm.get(h) or set(H[h]['RM']) != ml_rm.get(h)]
hm_dm = {}; hm_rm = {}
for h in HM:
    for d in H[h]['DM']: hm_dm.setdefault(d, []).append(h)
    for r in H[h]['RM']: hm_rm.setdefault(r, []).append(h)
R['dm_unmapped'] = [d for d in DM if d not in hm_dm]
R['rm_unmapped'] = [r for r in RM if r not in hm_rm]
R['hm_unknown_src'] = {h: [x for x in H[h]['DM'] + H[h]['RM'] if x not in DM and x not in RM] for h in HM}
# Beidseitigkeit
hm_pages = {h: set(re.findall(r'HS-\d\d', section(HM[h][1], 'Verwendet auf Seiten') or '')) for h in HM}
R['bi'] = {h: dict(hs_only=sorted(inv.get(h, set()) - hm_pages[h]), hm_only=sorted(hm_pages[h] - inv.get(h, set())),
                   ml_only=sorted(ml_hs[h] - inv.get(h, set())), notml=sorted(inv.get(h, set()) - ml_hs[h])) for h in HM}
R['bi_dev'] = {h: v for h, v in R['bi'].items() if any(v.values())}
R['cnt_dev'] = {h: (len(inv.get(h, set())), len(hm_pages[h]), ml_cnt[h]) for h in HM if len({len(inv.get(h, set())), len(hm_pages[h]), ml_cnt[h]}) > 1}
# RM-Modulliste
RML = rd(f'{ROOT}/02_Referenz-Analyse/Module/Modulliste.md')
rmrows = {}
for l in RML.split('\n'):
    m = re.match(r'\| \[(RM-\d\d)\]', l)
    if m:
        c = [x.strip() for x in l.strip().strip('|').split('|')]
        rmrows[m.group(1)] = dict(cnt=int(c[2]), pages=ids(c[3], 'RS'), dm=ids(c[4], 'DM'))
R['rm_cnt_bad'] = [r for r, v in rmrows.items() if v['cnt'] != len(v['pages'])]
R['rm_rows'] = len(rmrows)
# RM<->DM Paare ohne gemeinsames HM; DM ohne RM-Entsprechung aber gemeinsames HM mit RM
pairs_nohm = [(r, d) for r, v in rmrows.items() for d in v['dm'] if not (set(hm_rm.get(r, [])) & set(hm_dm.get(d, [])))]
R['pairs_nohm'] = pairs_nohm
dm_rm_ml = {d: [r for r, v in rmrows.items() if d in v['dm']] for d in DM}
dm_rm_hm = {d: sorted({r for hm in hm_dm.get(d, []) for r in H[hm]['RM']}) for d in DM}
R['dm_rm_diff'] = {d: (dm_rm_ml[d], dm_rm_hm[d]) for d in DM if set(dm_rm_ml[d]) != set(dm_rm_hm[d])}
note5 = 'mit dem jeweiligen RM in einem HM zusammengeführt' in RML
note6 = bool(re.search(r'Hinweis zur Zuordnung DM ↔ RM.*RM-05.*DM-15', ML))
R['note5'], R['note6'] = note5, note6
# Stichprobe
SAMPLE = ['01', '11', '13', '19', '25', '28', '31', '35', '37', '39']
MANUAL = {  # nicht automatisch zugeordnete RS-Zeilen -> (HS-Zeile Anfang, Herkunft-Teilstring), per assert belegt
 '01': {'Maschinen-beleuchtung (Z3/S1)': ('Maschinenbeleuchtung', 'T2 Z3/S1')},
 '11': {'Pfeiltasten vor / zurück': ('Pfeiltasten', 'T16 Nr. 1'), 'Logo APA-TEC': ('Kopfzeile: Logo', 'W: Logo'),
        'Taste „Produktion“': ('Seitenleiste', 'W: Schloss-Symbol'), 'Taste „Einstellungen“': ('Seitenleiste', 'W: Schloss-Symbol'),
        'Taste „Zurück“': ('Seitenleiste', 'W: Schloss-Symbol')},
 '13': {'T1 %': ('T1 %', 'RS-13 Nr. 14'), 'Einzelgewicht': ('Taste „Einzelgewichte“', 'RS-13 Nr. 19')},
 '19': {'Logo APA-TEC': ('Kopfzeile: Logo', 'W: Logo'), 'Schloss-Symbol': ('Seitenleiste', 'W: Schloss')},
 '28': {'Bildlaufleiste horizontal': ('Bildlauf', 'Bildlaufleiste'),
        'Kopfzeile, Meldezeile, untere Leiste (Produktion, Einstellungen, Zurück, Schloss)': ('Schloss-Symbol, Tasten', 'untere Leiste')},
 '31': {'Kopfzeile, Meldezeile, Untere Funktionsleiste': ('E24 Funktionsleiste unten', 'Untere Funktionsleiste')},
}
NUMBERED = {'11': [('T14', 12), ('T15', 7), ('T16', 2)], '19': [('T27', 13), ('T28', 6), ('T29', 3)], '13': [('RS-13', 19)]}
def covered_numbers(hs_id, key):
    txt = ' '.join(h for _, h, _ in hs_rows(hs_id)); got = set()
    if key == 'RS-13':
        got = {int(x) for x in re.findall(r'RS-13 Nr\. (\d+)', txt)}
    else:
        for m in re.finditer(key + r' Nr\. (\d+)(?:, ' + key + r' Nr\. (\d+))?(?: und (\d+))?', txt):
            got |= {int(g) for g in m.groups() if g}
        for m in re.finditer(r'(T\d+) Nr\. (\d+)(?: und (\d+))?', txt):
            if m.group(1) == key: got |= {int(g) for g in m.groups()[1:] if g}
    return got
SAMP = {}
for n in SAMPLE:
    rsn, hsn = 'RS-' + n, 'HS-' + n
    el = rs_elems(rsn); hr = hs_rows(hsn)
    pool = [(set(norm(a + ' ' + b).split()), set(norm(c).split())) for a, b, c in hr]
    auto = 0; man = []; miss = []
    for nr, name in el:
        tk = toks(name); best = max((max(sum(1 for t in tk if t in p) / max(1, len(tk)), sum(1 for t in tk if t in f) / max(1, len(tk))) for p, f in pool), default=0)
        if best >= 0.6: auto += 1; continue
        spec = MANUAL.get(n, {}).get(name)
        if spec and any(a.startswith(spec[0]) and spec[1] in b for a, b, c in hr): man.append((name, spec))
        else: miss.append(name)
    extra_rows = [a for a, b, c in hr if re.search(r'Ergänzung|Annahme|nur Design|Design-Rahmen|\(Rahmen|Rahmen nach Designsystem', b)]
    num = {}
    for key, cnt in NUMBERED.get(n, []):
        got = covered_numbers(hsn, key); num[key] = (cnt, sorted(set(range(1, cnt + 1)) - got))
    SAMP[n] = dict(rs=len(el), auto=auto, man=man, miss=miss, hs=len(hr), extra=len(extra_rows), num=num)
R['samp_miss'] = {n: v['miss'] for n, v in SAMP.items() if v['miss']}
R['samp_num_miss'] = {n: {k: v[1] for k, v in s['num'].items() if v[1]} for n, s in SAMP.items() if any(v[1] for v in s['num'].values())}
# Gesamtlauf Elemente (alle 39 Seiten, Naeherung)
ALL = {}
for r in RS:
    n = r[3:]; el = rs_elems(r); hr = hs_rows('HS-' + n)
    pool = [(set(norm(a + ' ' + b).split()), set(norm(c).split())) for a, b, c in hr]
    un = []
    for nr, name in el:
        tk = toks(name); best = max((max(sum(1 for t in tk if t in p) / max(1, len(tk)), sum(1 for t in tk if t in f) / max(1, len(tk))) for p, f in pool), default=0)
        if best < 0.6: un.append(name)
    ALL[r] = (len(el), un, len(hr))
FRAME = re.compile(r'Kopfzeile|Meldezeile|Seitenkopf|Schloss|Fußleiste|Logo|Seitentitel|Gruppenrahmen|Funktionsleiste|Taste „(Produktion|Einstellungen|Zurück)“')
R['all_total'] = sum(v[0] for v in ALL.values()); R['all_unmatched'] = sum(len(v[1]) for v in ALL.values())
R['all_unmatched_open'] = []
for r, (c, un, hrn) in ALL.items():
    hs_txt = ' '.join(x[2] for x in hs_rows('HS-' + r[3:]))
    for name in un:
        if r[3:] in MANUAL and name in MANUAL[r[3:]]: continue
        if r[3:] in ('13',) and name in ('T1 %', 'Einzelgewicht'): continue
        if FRAME.search(name) and (('HM-01' in hs_txt) or ('HM-02' in hs_txt) or ('Gruppenrahmen' in hs_txt)): continue
        R['all_unmatched_open'].append((r, name))
```
