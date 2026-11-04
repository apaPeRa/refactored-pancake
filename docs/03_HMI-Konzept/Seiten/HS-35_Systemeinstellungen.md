# HS-35 – Systemeinstellungen

- Quelle: [RS-35](../../02_Referenz-Analyse/Seiten/RS-35_Systemeinstellungen.md) (Kapitel 35, Tabelle 45, Bild RS-35_01); Design: keine eigene Design-Seite, Kachel „Systemeinstellungen“ in [DS-02](../../01_Design-Analyse/Seiten/DS-02_Einstellungen.md), Aufbau abgeleitet aus dem Kachelmenü der Einstellungsseite und dem [Designsystem](../Designsystem.md)
- Navigationspfad: Einstellung › Systemeinstellungen (Zugang: [HS-04](HS-04_Einstellungen.md), Kachel „Systemeinstellungen“; Zurück-Ziel: Verlauf, sonst HS-04; Seitenregister `SystemSettings` / `settings/system`, Navigation.md Abschnitt 2 und 5.1)

## Zweck

Systemverwaltung der Bedienoberfläche und der Steuerung: Bedienoberfläche beenden oder minimieren, Windows-Taskmanager öffnen, Steuerung neu starten oder ausschalten sowie Zugang zu den weiterführenden Seiten Service, Meldearchiv und System- und Antriebsinfo (Handbuch: „Auf dieser Seite werden Funktionen zur Systemverwaltung bereitgestellt. Sie dienen der Steuerung der Bedienoberfläche, dem Neustart oder Ausschalten der Steuerung sowie dem Zugriff auf weiterführende Diagnoseseiten.“). Die Seite ist ein reines Kachelmenü; Warnaktionen (Anlage wird gestoppt) sind durch ein Bestätigungs-Pop-up abgesichert.

## Aufbau (Bereiche, Layout)

Die Seite steht im Rahmen-Grid des [Designsystems](../Designsystem.md) (Abschnitt 3.2): Seitenleiste ([HM-01](../Module/HM-01_Seitenleiste.md)), Kopfzeile mit Meldezeile ([HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md)), Zeile Brotkrümel und Kennzahlen ([HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md)), Inhaltsbereich, untere Funktionsleiste ([HM-06](../Module/HM-06_Funktionsleiste.md)). Der Seitentitel der Referenz („Systemeinstellung“ im Bild, „Systemeinstellungen“ im Kapitel; OP-33: Kapitelname gewinnt) ist das letzte Brotkrümel-Segment.

**Inhaltsbereich:** ein einziger Bereich mit dem Kachelraster 3 Spalten × 3 Zeilen ([HM-16](../Module/HM-16_Kachel-Navigation.md), `Columns` = 3, `Rows` = 3), Außenrand `Space.L`, Abstand der Kacheln `Size.Touch.Gap`. Die drei Spalten sind gleich breit (3 × 1\*), die Zeilen gleich hoch (3 × 1\*), jede Kachel mindestens `Size.Touch.Large` hoch. Die Reihenfolge entspricht dem Bild der Referenz (Zeile für Zeile, von links nach rechts); der leere Rasterplatz bleibt an seiner Stelle (Zeile 2, Spalte 3) und erscheint als deaktivierte Kachel „Reserviert“ (A-29, gestrichelte Kontur und Text).

```
Inhaltsbereich (3 Spalten x 3 Zeilen, je 1*)
+-----------------------+-----------------------+-----------------------+
| Bedienung beenden     | Steuerung neu starten | Steuerung ausschalten |
| [Schluessel][Warnung] | [Schluessel][Warnung] | [Schluessel][Warnung] |
+-----------------------+-----------------------+-----------------------+
| Taskmanager           | Bedienung minimieren  | Reserviert (leer,     |
| [Schluessel]          | [Schluessel]          |  deaktiviert)         |
+-----------------------+-----------------------+-----------------------+
| Service               | Meldearchiv           | System- und           |
| [Schluessel][>]       | [>]                   | Antriebsinfo  [>]     |
+-----------------------+-----------------------+-----------------------+
Funktionsleiste unten:  [ Lampentest ]
```

Gruppierung nach Wirkung (ohne zusätzliche Rahmen, nur über die Zeilenreihenfolge der Referenz): Zeile 1 und Zeile 2 enthalten Aktionen am System, Zeile 3 Navigationsziele. Die Navigationskacheln tragen als zweiten Kanal das Symbol `Icon.Chevron` (führt zu einer Seite), die Aktionskacheln nicht.

**Untere Funktionsleiste:** links eine Taste „Lampentest“; sonst leer. Die Rahmentasten „Produktion“, „Einstellungen“, „Zurück“ und das Schloss der Referenz liegen in der Seitenleiste ([HM-01](../Module/HM-01_Seitenleiste.md), A-35).

## Elemente

Spalte „Herkunft“ = Rückverfolgung zu [RS-35](../../02_Referenz-Analyse/Seiten/RS-35_Systemeinstellungen.md) (Tabelle 45, Zeilen in der Reihenfolge der RS-Datei; „Rahmen“ = Rahmenelementtabelle der RS).

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Bedienung beenden | Kachel, Aktion, Schlüssel (`Icon.Key`), Warnaktion (`Icon.Status.Warning`) | Schließt die Bedienoberfläche. Die Maschine produziert weiter, Einstellungen können nicht mehr geändert werden, Start und Stopp der Anlage bleiben möglich. Vorher Bestätigungs-Pop-up (A-40). | [HM-16](../Module/HM-16_Kachel-Navigation.md); Bestätigung in [HM-14](../Module/HM-14_Popup-Rahmen.md) | RS-35 Tabelle 45, Zeile 1 |
| Bedienung minimieren | Kachel, Aktion, Schlüssel | Minimiert die HMI-Anzeige und gibt den Windows-Desktop frei. | [HM-16](../Module/HM-16_Kachel-Navigation.md) | Zeile 2 |
| Taskmanager | Kachel, Aktion, Schlüssel | Öffnet den Windows-Taskmanager. | [HM-16](../Module/HM-16_Kachel-Navigation.md) | Zeile 3 |
| Steuerung neu starten | Kachel, Aktion, Schlüssel, Warnaktion | Startet die Steuerung neu. Achtung: Die Anlage wird dabei gestoppt. Vorher Bestätigungs-Pop-up mit diesem Warntext. | [HM-16](../Module/HM-16_Kachel-Navigation.md); Bestätigung in [HM-14](../Module/HM-14_Popup-Rahmen.md) | Zeile 4 |
| Steuerung ausschalten | Kachel, Aktion, Schlüssel, Warnaktion | Fährt den IPC herunter. Achtung: Die Anlage wird dabei gestoppt. Ein Neustart erfolgt erst nach dem Wiedereinschalten der Stromversorgung über den Schalter „Steuerung ein“ (physischer Schalter, nicht Teil des HMI). Vorher Bestätigungs-Pop-up mit beiden Hinweisen. | [HM-16](../Module/HM-16_Kachel-Navigation.md); Bestätigung in [HM-14](../Module/HM-14_Popup-Rahmen.md) | Zeile 5 |
| Meldearchiv | Kachel, Navigation, ohne Schlüssel | Öffnet [HS-37](HS-37_Meldearchiv.md). | [HM-16](../Module/HM-16_Kachel-Navigation.md) | Zeile 6 |
| System- und Antriebsinfo | Kachel, Navigation, ohne Schlüssel | Öffnet die Diagnoseseite [HS-39](HS-39_System-und-Antriebsinfos.md). Beschriftung mehrzeilig mit automatischem Umbruch. | [HM-16](../Module/HM-16_Kachel-Navigation.md) | Zeile 7 |
| Service | Kachel, Navigation, Schlüssel (Seitenzugang geschützt) | Öffnet die Service-Seite [HS-36](HS-36_Service.md) mit erweiterten Systemfunktionen; Mindestrolle Technik (A-41). | [HM-16](../Module/HM-16_Kachel-Navigation.md) | Zeile 8 |
| Leerer Rasterplatz (Zeile 2, Spalte 3) | Kachel „Reserviert“, deaktiviert | Ohne Funktion; behält den Platz des Bildes (ungenutzt oder reserviert, OP-44). | [HM-16](../Module/HM-16_Kachel-Navigation.md) (`EmptyTileMode` = Reserved) | Bild RS-35_01, RS-35-P03 |
| Taste „Lampentest“ | Aktionstaste, Funktionsleiste | Funktion im Handbuch nicht beschrieben; Annahme: löst den Lampentest der Steuerung aus (Dummy, OP-49). | [HM-06](../Module/HM-06_Funktionsleiste.md), [HM-07](../Module/HM-07_Aktionstaste.md) | Rahmen: Taste „Lampentest“ |
| Meldezeile „Palettierung nicht bereit“ | Anzeige und Taste | Zeigt die wichtigste Meldung als „NNN: Text“; Antippen öffnet [HS-38](HS-38_Meldeanzeige.md). | [HM-03](../Module/HM-03_Meldezeile.md) (in [HM-02](../Module/HM-02_Kopfzeile.md)) | Rahmen: Meldezeile |
| Kopfzeile: Logo, Seitentitel, Symbol, Uhrzeit, Datum | Rahmen | Logo, Betriebsart und Uhr; Seitentitel im Brotkrümel; das Wirbelsymbol der Referenz ist als Betriebsart geführt (A-48), keine Seitenfunktion. | [HM-02](../Module/HM-02_Kopfzeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | Rahmen: Kopfzeile |
| Vorhängeschloss-Symbol (Fußleiste) | Statusanzeige | Entfällt als Symbol; Anmeldestatus über den Benutzerkreis der Seitenleiste (A-35, OP-26). | [HM-01](../Module/HM-01_Seitenleiste.md) | Rahmen: Vorhängeschloss |
| Tasten „Produktion“, „Einstellungen“, „Zurück“ | Navigation | Wandern in die Seitenleiste: Home, Einstellungen (HS-04), Zurück im Verlauf. | [HM-01](../Module/HM-01_Seitenleiste.md) | Rahmen: Tasten Produktion/Einstellungen/Zurück |
| Bestätigungs-Pop-up (Ergänzung) | Pop-up, Bestätigung | Zeigt Aktionsname, Warnsymbol, Warntext und die Tasten „Ja“ und „Abbrechen“; „Ja“ führt die Aktion aus (A-40). | [HM-14](../Module/HM-14_Popup-Rahmen.md) (Bestätigungsvariante) | Ergänzung zu RS-35 Zustände (Warnhinweise) |

## Verwendete Module

- Rahmen: [HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md)
- Seite: [HM-16](../Module/HM-16_Kachel-Navigation.md) (9 Kacheln, 1 davon leer), [HM-07](../Module/HM-07_Aktionstaste.md) (Lampentest), [HM-14](../Module/HM-14_Popup-Rahmen.md) (Bestätigungs-Pop-up)

## Zustände und Interaktion

- **Berechtigungen.** Sechs Kacheln tragen `Icon.Key` oben rechts (Bedienung beenden, Steuerung neu starten, Steuerung ausschalten, Taskmanager, Bedienung minimieren, Service); „Meldearchiv“ und „System- und Antriebsinfo“ tragen keines. Die Rollenstufe je Kachel ist nicht beschrieben (OP-25, Dummy). Ohne ausreichende Rolle zeigt die Kachel `Icon.Lock`; Antippen öffnet das Benutzer-Pop-up, bei Erfolg läuft die ausgelöste Aktion weiter (Navigation.md 4.1, 5.4). „Service“ ist zusätzlich seitengeschützt (Mindestrolle Technik, Seitenregister).
- **Bestätigung.** „Bedienung beenden“, „Steuerung neu starten“ und „Steuerung ausschalten“ öffnen ein Bestätigungs-Pop-up (Titel mit `Icon.Status.Warning`, Warntext der Referenz, „Ja“ und „Abbrechen“). Ein Antippen außerhalb schließt nicht; „Abbrechen“ führt zurück zur Seite ohne Wirkung. Die Referenz beschreibt keine Sicherheitsabfrage; sie ist Ergänzung (A-40, OP-31).
- **Stopp der Anlage.** Nach „Ja“ bei „Steuerung neu starten“ und „Steuerung ausschalten“ wird die Anlage gestoppt (Warnhinweis im Pop-up vorab); die Seite zeigt keine weitere Bedienung, bis die Steuerung wieder verfügbar ist (Verbindungsverlust-Anzeige über die Meldezeile). Nach „Steuerung ausschalten“ ist ein Neustart nur über den physischen Schalter „Steuerung ein“ möglich (Hinweis im Pop-up).
- **Bedienung beenden.** Die Bedienoberfläche schließt, die Maschine läuft weiter, Start und Stopp bleiben über die Maschinentasten möglich. Wiederaufruf der Bedienung ist in der Referenz nicht beschrieben (offen).
- **Bedienung minimieren und Taskmanager.** Öffnen Betriebssystemfunktionen außerhalb der HMI; keine Rückfrage (nicht beschrieben).
- **Navigation.** Meldearchiv → HS-37, System- und Antriebsinfo → HS-39, Service → HS-36 (Verlauf wächst um HS-35). Zurück: Seitenleiste „Zurück“ (Verlauf, sonst HS-04), Brotkrümel-Segment „Einstellung“ führt auf HS-04.
- **Pop-ups.** Nur das Bestätigungs-Pop-up und das Benutzer-Pop-up; Stapeltiefe höchstens 2, Seitenleiste, Funktionsleiste und Inhalt gesperrt, Meldezeile nur Anzeige (Navigation.md 4.2).
- **Leere Kachel.** Antippen nennt in der Meldezeile als Info-Text „Reserviert“ (A-28); keine Aktion.
- **Fehlerfälle.** Schlägt eine Systemaktion fehl (z. B. Taskmanager nicht startbar), erscheint ein Fehlertext in der Meldezeile mit `Icon.Status.Error`; die Referenz beschreibt keine Fehlerfälle (Annahme, Dummy).

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-35-P01 | Brotkrümel und Zugang (RS-35-P01) | Brotkrümel „Einstellung › Systemeinstellungen“, erreichbar über die Kachel in HS-04; Zurück führt in den Verlauf, sonst nach HS-04 | offen |
| HS-35-P02 | Anzahl und Beschriftung der Kacheln (RS-35-P02) | 8 beschriftete Kacheln: Bedienung beenden, Steuerung neu starten, Steuerung ausschalten, Taskmanager, Bedienung minimieren, Service, Meldearchiv, System- und Antriebsinfo | offen |
| HS-35-P03 | Raster (RS-35-P03) | 3 × 3 Raster in der Reihenfolge der Referenz; Platz Zeile 2, Spalte 3 ist eine deaktivierte Kachel „Reserviert“ | offen |
| HS-35-P04 | Schlüsselsymbole (RS-35-P04) | genau 6 Kacheln mit `Icon.Key` (alle außer Meldearchiv und System- und Antriebsinfo); Symbol bleibt als Form erkennbar, nicht über Gelb codiert | offen |
| HS-35-P05 | Bedienung beenden (RS-35-P05) | Nach Bestätigung schließt die Bedienoberfläche; Maschine produziert weiter, Start/Stopp möglich, Einstellungen nicht änderbar | offen |
| HS-35-P06 | Bedienung minimieren (RS-35-P06) | HMI wird minimiert, Windows-Desktop frei | offen |
| HS-35-P07 | Taskmanager (RS-35-P07) | Windows-Taskmanager öffnet | offen |
| HS-35-P08 | Steuerung neu starten (RS-35-P08) | Bestätigungs-Pop-up mit Warntext „Die Anlage wird dabei gestoppt“; nach „Ja“ startet die Steuerung neu und die Anlage wird gestoppt; „Abbrechen“ ohne Wirkung | offen |
| HS-35-P09 | Steuerung ausschalten (RS-35-P09) | Bestätigungs-Pop-up nennt Anlagenstopp und Neustart nur über den Schalter „Steuerung ein“; nach „Ja“ fährt der IPC herunter | offen |
| HS-35-P10 | Navigation Meldearchiv (RS-35-P10) | Kachel öffnet HS-37 ohne Berechtigungsabfrage | offen |
| HS-35-P11 | Navigation System- und Antriebsinfo (RS-35-P11) | Kachel öffnet HS-39 ohne Berechtigungsabfrage | offen |
| HS-35-P12 | Navigation Service (RS-35-P12) | Kachel öffnet HS-36 bei Rolle Technik; ohne Rolle öffnet das Benutzer-Pop-up, nach Anmeldung läuft die Navigation weiter, bei Abbruch bleibt HS-35 stehen | offen |
| HS-35-P13 | Rahmen (RS-35-P13) | Kopfzeile mit Uhrzeit und Datum, Meldezeile, Funktionsleiste mit „Lampentest“; Produktion, Einstellungen, Zurück, Anmeldestatus in der Seitenleiste | offen |
| HS-35-P14 | Berechtigungs-Rückmeldung | Kachel ohne Rolle zeigt `Icon.Lock`; Tippen nennt „Berechtigung erforderlich: <Rolle>“ | offen |
| HS-35-P15 | Bestätigung nur bei Warnaktionen | Nur die 3 Warnkacheln öffnen ein Bestätigungs-Pop-up; Antippen außerhalb des Pop-ups schließt nicht | offen |
| HS-35-P16 | Touch-Ziele | Kacheln mindestens `Size.Touch.Large` hoch, Abstand `Size.Touch.Gap`, Taste „Lampentest“ mindestens `Size.Touch.Default` hoch und `Size.FunctionButton.MinWidth` breit; Pop-up-Tasten mindestens `Size.Touch.Default` | offen |
| HS-35-P17 | Zweiter Kanal | Warnaktionen tragen `Icon.Status.Warning` und Text, Navigationskacheln `Icon.Chevron`, reservierte Kachel gestrichelte Kontur und Text; kein Zustand nur über Farbe | offen |
| HS-35-P18 | Tokens | Keine Hex- und Pixelwerte im Seitenaufbau; nur `Brush.*`, `Size.*`, `Space.*` des Designsystems | offen |
| HS-35-P19 | Lampentest | Taste „Lampentest“ links in der Funktionsleiste, ohne Navigation; Wirkung als Dummy | offen |

## Offene Punkte

- OP-25: Rollenstufe der sechs Schlüssel-Kacheln nicht beschrieben (Dummy).
- OP-26: Bedeutung von Vorhängeschloss und Kopfzeilen-Symbol (hier: Seitenleiste, Betriebsart).
- OP-31: Bestätigungsdialoge für „Steuerung neu starten“, „Steuerung ausschalten“, „Bedienung beenden“ sind Ergänzung (A-40); Wiederaufruf der Bedienung nach „Bedienung beenden“ nicht beschrieben.
- OP-33: Titel „Systemeinstellung“ (Bild) gegenüber „Systemeinstellungen“ (Kapitel); Kapitelname gilt.
- OP-44: leerer Rasterplatz (Zeile 2, Spalte 3) ungenutzt oder reserviert.
- OP-49: Funktion von „Lampentest“ nicht beschrieben.
