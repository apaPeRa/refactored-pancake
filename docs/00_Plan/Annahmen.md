# Annahmen

Getroffene Annahmen, wenn Quellen Lücken oder Widersprüche haben (siehe Agent.md Abschnitt 3).

| Nr | Datum | Annahme | Begründung |
|---|---|---|---|
| A-01 | 2026-11-04 | Als „Seite“ der Referenz zählt jedes Kapitel der Ebene 2 im Handbuch (39), einschließlich Pop-ups (Produktionszähler, Maschinengeschwindigkeit). Mehrfach vorkommende Titel (Motorparameter 3×, Gewichtskorrektur 2×) sind getrennte Seiten (je zum Eltern-Gerät). | Agent.md: Referenz maßgeblich für Seitenliste; Nummerierung in Handbuchreihenfolge. Die Kapitel gehören zu verschiedenen Geräten. |
| A-02 | 2026-11-04 | Tabellen werden auf Kapitelebene gezählt (50); vier verschachtelte Tabellen gehören zu ihrer Eltern-Tabelle. Bilder: 83 Bildverweise, 63 eindeutige Mediendateien (Mehrfachverwendung). | Zählung per python-docx und XML-Analyse; Agent.md nennt nur „ca. 50 Tabellen, ca. 80 Bilder“. |
| A-03 | 2026-11-04 | Die Referenz-Pakete R1–R10 werden mit vorab festgelegter ID-Zuordnung parallel bearbeitet. | Keine gemeinsamen Schreibdateien, schnellerer Ablauf (Agent.md Abschnitt 9). |
