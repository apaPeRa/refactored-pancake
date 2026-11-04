# Offene Punkte

Widersprüche und Lücken zwischen Design und Referenz. Es wird nichts erfunden; die getroffene Annahme steht jeweils dabei.

| Nr | Thema | Annahme | Quelle/Status |
|---|---|---|---|
| OP-01 | Rezeptanwahl („Tolles Rezept“) im Design, in der Referenz nicht beschrieben (zu prüfen in Phase 2) | Als Anzeige-/Auswahlelement im neuen HMI mit Dummy-Daten vorsehen | Design `Seite_Produktion.png`; offen |
| OP-02 | Schichtplan (Schaltfläche in der unteren Leiste der Produktionsseite) ohne Referenz | Platzhalterseite mit Dummy-Daten | Design `Seite_Produktion.png`; offen |
| OP-03 | Sprache (Schaltfläche der Seite Einstellungen) ohne Referenz | Umschaltung de/en über `.resx`, Funktion in M2 nur als Dummy | Design `Seite_Einstellungen.png`; offen |
| OP-04 | Benutzer/Anmeldung (Benutzerkreis „MM“ mit Rolle „Technik“, Schlüsselsymbole an Eingabefeldern) ohne Referenzbeschreibung (zu prüfen) | Rollen und Berechtigungen als Dummy, Schlüsselsymbol = berechtigungspflichtiges Feld | Design alle Seiten; offen |
| OP-05 | Leere Kacheln auf der Seite Einstellungen (4 leer), Kachel „Geräte“ und „Beleuchtung“ ohne Entsprechung in der Referenz (zu prüfen) | Leere Kacheln als reservierte Plätze, nicht belegt | Design `Seite_Einstellungen.png`; offen |
| OP-06 | Kachel „EKW“ der Produktionsseite im Design leer | Leere Kachel mit Überschrift; Inhalt bleibt offen | Design `Seite_Produktion.png`; offen |
| OP-07 | Design nur 5 Seiten; 34 Referenzseiten ohne Design | Layout aus Designsystem und Modulen ableiten (Phase 3) | Task.md; offen |
| OP-08 | Seitenleiste mit Meldungs-Symbol und Zurück-Symbol: Zuordnung zu Meldearchiv/Meldeanzeige bzw. Navigation in der Referenz zu prüfen | Meldungs-Symbol öffnet Meldeanzeige, Zurück = eine Ebene zurück | Design; offen |
