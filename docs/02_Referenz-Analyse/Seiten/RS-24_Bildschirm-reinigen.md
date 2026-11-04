# RS-24 – Bildschirm reinigen
- Quelle: Referenz.docx, Kapitel 24 „Bildschirm reinigen“ (Zweck, Seitenübersicht, Funktionsbeschreibung als Fließtext, keine Tabelle); Bild [RS-24_01.png](../Medien/RS-24_01.png)
- Navigationspfad: Einstellung › Bildschirm reinigen (Eintrag in der Tabelle von [RS-04](RS-04_Einstellungen.md)); die Seite schließt nach Ablauf der Zeit automatisch

## Zweck
Die Seite ermöglicht das Reinigen des Bildschirms, ohne dabei versehentlich Bedienelemente zu aktivieren. Während des Reinigungsprozesses werden alle Eingaben ignoriert.

## Aufbau (Bereiche, Layout)
Beschreibung des Bildes [RS-24_01.png](../Medien/RS-24_01.png) (Altes HMI, 1024 × 768):

- **Kopfzeile (hellgrau):** links Logo „APA-TEC GmbH – Automation and Packaging Technology“, Mitte unterstrichener Titel „Bildschirm reinigen“, rechts davon das Wirbel-Symbol mit rotem Schriftzug „Service“ darüber, ganz rechts Uhrzeit „14:01:44“ und Datum „01.03.2021“ (grau).
- **Arbeitsbereich:** vollflächig blau, ohne weitere Bedienelemente.
- **Fortschrittsbalken:** mittig, fast über die ganze Breite, dünner dunkler Rahmen; der gelbe Füllstand reicht von links bis etwa drei Viertel der Breite; mittig im Balken fett „77%“. Der Rest des Balkens ist blau (transparent).
- **Keine Meldezeile, keine Fußleiste, keine Tasten** im Bild.

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Das Handbuch enthält keine Tabelle; die Funktion steht im Fließtext (Funktionsbeschreibung, wörtlich): „Beim Aufruf der Funktion wird ein Zeitfenster gestartet, das visuell durch einen Fortschrittsbalken angezeigt wird. Nach Ablauf der Zeit, schließt sich die Seite automatisch. Sollte mehr Zeit benötigt werden, kann der Vorgang durch erneutes öffnen der Seite gestartet werden.“

| Element | Typ | Funktion | verwendetes Modul |
|---|---|---|---|
| Fortschrittsbalken | Anzeige, gelber Balken mit Prozentangabe („77%“) | Zeigt das ablaufende Zeitfenster der Reinigung | Modulkandidat: Fortschrittsbalken |
| Zeitfenster | Zeitgeber (Dauer nicht angegeben) | Startet beim Aufruf; nach Ablauf schließt die Seite automatisch | – (Seitenverhalten) |
| Eingabesperre | Verhalten | Alle Eingaben werden während des Reinigens ignoriert | – (Seitenverhalten) |
| Erneuter Aufruf | Verhalten | Verlängerung durch erneutes Öffnen der Seite | – (Seitenverhalten) |
| Seitenkopf mit „Service“-Schriftzug am Symbol (nur im Bild) | Rahmen | Standardkopfzeile; Schriftzug „Service“ im Handbuch nicht erklärt | Modulkandidat: Seitenkopf (Rahmen) |

Medien dieser Seite (1 Bild):

| Bild | Zeigt |
|---|---|
| [RS-24_01.png](../Medien/RS-24_01.png) | Blaue Seite mit Titel „Bildschirm reinigen“ und gelbem Fortschrittsbalken mit „77%“ |

## Verwendete Module (IDs)
Noch keine RM-IDs vergeben. Modulkandidaten: Fortschrittsbalken; Seitenkopf (Rahmen).

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- **Start:** beim Aufruf der Seite startet das Zeitfenster; Fortschrittsbalken läuft von 0 % bis 100 % (Annahme aus Bild: Prozent, Richtung links nach rechts).
- **Während des Ablaufs:** alle Eingaben werden ignoriert; keine Bedienelemente im Bild.
- **Ende:** nach Ablauf schließt sich die Seite automatisch (Zielseite nicht angegeben).
- **Verlängerung:** erneutes Öffnen der Seite startet den Vorgang neu.
- **Abbruch:** nicht beschrieben (keine Tasten sichtbar).
- **Berechtigungen, Pop-ups, Fehlerfälle:** keine beschrieben.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RS-24-P01 | Aufruf | Seite erreichbar über Einstellung › Bildschirm reinigen; Zeitfenster startet sofort | offen |
| RS-24-P02 | Fortschrittsbalken | Balken mit Prozentanzeige (Beispiel „77%“) zeigt den Ablauf des Zeitfensters | offen |
| RS-24-P03 | Eingabesperre | Während des Zeitfensters löst Berühren des Bildschirms keine Aktion aus | offen |
| RS-24-P04 | Automatisches Schließen | Nach Ablauf der Zeit schließt sich die Seite selbständig | offen |
| RS-24-P05 | Neustart | Erneutes Öffnen der Seite startet das Zeitfenster neu | offen |
| RS-24-P06 | Aufbau | Keine Bedienelemente außer der Fortschrittsanzeige | offen |
| RS-24-P07 | Bildabdeckung | RS-24_01.png ist verlinkt und beschrieben | offen |

## Offene Punkte
- Dauer des Zeitfensters ist nicht angegeben (Bild: Balken bei 77 %).
- Zielseite nach dem automatischen Schließen und eine Abbruchmöglichkeit sind nicht beschrieben.
- Das Bild zeigt weder Meldezeile noch Fußleiste (Vollbild); ob Meldungen währenddessen unterdrückt werden, ist unklar.
- Bedeutung des roten Schriftzugs „Service“ am Wirbel-Symbol (Kopfzeile) ist nicht erklärt; Datum im Bild (01.03.2021) weicht von anderen Seitenbildern (12.05.2025) ab (nur Aufnahmedatum).
- Farbe des Balkens (gelb) hat im Handbuch keine beschriebene Bedeutung.
