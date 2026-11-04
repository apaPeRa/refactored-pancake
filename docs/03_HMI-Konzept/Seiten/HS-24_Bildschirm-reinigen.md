# HS-24 – Bildschirm reinigen
- Quelle: [RS-24](../../02_Referenz-Analyse/Seiten/RS-24_Bildschirm-reinigen.md) (Handbuch Kapitel 24, Fließtext ohne Tabelle; Bild [RS-24_01.png](../../02_Referenz-Analyse/Medien/RS-24_01.png)); Design: keine eigene Design-Seite, nur die Kachel „Bildschirm reinigen“ in [DS-02](../../01_Design-Analyse/Seiten/DS-02_Einstellungen.md) (Zugang); Aufbau aus [Designsystem](../Designsystem.md) und [HM-10](../Module/HM-10_Fortschrittsbalken.md).
- Navigationspfad: Einstellung › Bildschirm reinigen; der Brotkrümel wird ausgeblendet (Vollbild ohne Rahmen, [Navigation.md](../Navigation.md) Abschnitt 2). Zugang: HS-04, Kachel „Bildschirm reinigen“. Zurück-Ziel: HS-04; die Seite schließt nach Ablauf selbst. Schlüssel `ScreenCleaning` / Route `settings/screencleaning`, Typ Vollbild, Parameter `durationSeconds` (aus Konfiguration), Mindestrolle: keine.

## Zweck
Der Bildschirm lässt sich reinigen, ohne versehentlich Bedienelemente zu aktivieren. Beim Aufruf startet ein Zeitfenster, das ein Fortschrittsbalken anzeigt; während des Ablaufs werden alle Eingaben ignoriert. Nach Ablauf schließt sich die Seite automatisch. Wird mehr Zeit benötigt, startet erneutes Öffnen der Seite das Zeitfenster neu (Handbuch).

## Aufbau (Bereiche, Layout)
Vollbild ohne Rahmen ([Navigation.md](../Navigation.md) 3.3 und 5.3): Seitenleiste, Brotkrümel mit Kennzahlen, Meldezeile und Funktionsleiste sind ausgeblendet. Es bleibt die **Kopfzeile in der Vollbild-Variante ohne Meldezeile** ([HM-02](../Module/HM-02_Kopfzeile.md), Variante „Vollbild“, über die volle Breite, da die Seitenleiste fehlt; Parameter `ShowMessageLine = false` in HM-02, Entscheidung in Navigation.md 6.5: Kopfzeile ohne Meldezeile bleibt, ein kritischer Alarm beendet die Reinigung): Logo, Betriebsart (die Referenz zeigt hier das Wirbel-Symbol mit rotem „Service“, geführt als Betriebsart „Service“ mit Warnstatus, A-48) sowie Uhrzeit und Datum, alles nur Anzeige. Der Rest der Fläche (Grund `Brush.Window`, neutral; das Blau der Referenz entfällt) ist ein Raster mit drei Stern-Zeilen **1 : 2 : 1** und 12 Spalten (Außenrand `Space.L`):

1. Obere Zeile: leer.
2. Mittlere Zeile: Titel „Bildschirm reinigen“ (Text `Font.Size.Title`, Referenz: Titel in der Kopfzeile), darunter der **Fortschrittsbalken** über 10 der 12 Spalten (Spalten 2 bis 11), Höhe `Size.Progress.Height`, mit Prozentzahl im Balken; darunter ein Info-Hinweis.
3. Untere Zeile: leer.

```
+------------------------------------------------------------------+
| Kopfzeile: Logo | (Meldezeile entfällt) | Betriebsart | Uhr/Datum  |
+------------------------------------------------------------------+
|                                                                  |
|                        Bildschirm reinigen                       |
|     [########################------------]  77 %   (10 Spalten)  |
|        Info: Eingaben sind gesperrt, Seite schließt selbst.      |
|                                                                  |
+------------------------------------------------------------------+
Keine Seitenleiste, kein Brotkrümel, keine Funktionsleiste, keine Taste.
```

Über der gesamten Fläche liegt eine unsichtbare Eingabesperre (Berührungen werden verworfen).

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Rückverfolgung: Spalte „Herkunft“ = Eintrag in [RS-24](../../02_Referenz-Analyse/Seiten/RS-24_Bildschirm-reinigen.md) (Tabelle Elemente = Tabelle im Abschnitt Elemente der RS-Seite, Bild = RS-24_01.png).

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Fortschrittsbalken | Anzeige, Balken mit Prozentzahl im Balken (Beispiel „77 %“, mit geschütztem Leerzeichen), neutrale Füllung links nach rechts von 0 % bis 100 % | Zeigt das ablaufende Zeitfenster der Reinigung; `Value` wird vom ViewModel getaktet (keine Eigenanimation); keine Schwellwertfarbe (die Farbe Gelb der Referenz hat keine beschriebene Bedeutung, OP-27) | [HM-10](../Module/HM-10_Fortschrittsbalken.md) | Tabelle Elemente „Fortschrittsbalken“, Bild |
| Zeitfenster | Zeitgeber (Verhalten, kein sichtbares Element) | Startet beim Aufruf der Seite mit der konfigurierten Dauer `durationSeconds` (Dummy, im Handbuch keine Dauer, OP-42); nach Ablauf schließt die Seite selbst | – (Seitenverhalten, Navigationsdienst `ScreenCleaning`) | Tabelle Elemente „Zeitfenster“ |
| Eingabesperre | Verhalten, unsichtbare Deckschicht | Alle Eingaben werden während des Zeitfensters ignoriert; keine Bedienelemente auf der Seite | – (Seitenverhalten) | Tabelle Elemente „Eingabesperre“, Zweck |
| Erneuter Aufruf | Verhalten | Erneutes Öffnen der Seite (Kachel in HS-04) startet das Zeitfenster neu (Verlängerung) | – (Seitenverhalten) | Tabelle Elemente „Erneuter Aufruf“ |
| Seitentitel „Bildschirm reinigen“ | Text | Titel in der Mitte (die Referenz zeigt ihn unterstrichen in der Kopfzeile; der Brotkrümel entfällt im Vollbild) | – (Text, Ressource `Nav_ScreenCleaning_Title`) | Bild Kopfzeile Titel |
| Info-Hinweis „Eingaben gesperrt“ | Hinweis-Textfeld, Art Info (Symbol und Wort „Info“) | Text sinngemäß „Eingaben sind gesperrt. Die Seite schließt sich nach Ablauf automatisch.“ aus Zweck und Funktionsbeschreibung; ergänzt, damit der Zustand lesbar ist (Annahme S24-1); nicht bedienbar | [HM-27](../Module/HM-27_Hinweis-Textfeld.md) | Zweck / Funktionsbeschreibung |
| Kopfzeile mit Logo, Betriebsart-Symbol „Service“, Uhrzeit, Datum | Rahmen, Anzeige | Kopfzeile in der Vollbild-Variante (ohne Meldezeile); Betriebsart „Service“ mit Warnstatus (A-48); keine Bedienung | [HM-02](../Module/HM-02_Kopfzeile.md) | Tabelle Elemente „Seitenkopf mit Service-Schriftzug“, Bild |
| Keine Meldezeile, keine Fußleiste, keine Tasten | Rahmen ausgeblendet | Meldezeile, Funktionsleiste, Seitenleiste und Brotkrümel sind ausgeblendet; Hinweis: [HM-01](../Module/HM-01_Seitenleiste.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md) stehen nicht auf dieser Seite | – | Bild („Keine Meldezeile, keine Fußleiste, keine Tasten“) |

## Verwendete Module (IDs)
- [HM-10](../Module/HM-10_Fortschrittsbalken.md) – Fortschrittsbalken
- [HM-27](../Module/HM-27_Hinweis-Textfeld.md) – Hinweis-Textfeld (Info)
- [HM-02](../Module/HM-02_Kopfzeile.md) – Kopfzeile (Vollbild-Variante ohne Meldezeile)

Nicht verwendet, weil Vollbild: HM-01, HM-03, HM-04, HM-05, HM-06 (Modulliste). Kein Modul fehlt.

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
- **Start:** Aufruf über die Kachel in HS-04. Die Seite wird nicht auf den Zurück-Stapel gelegt ([Navigation.md](../Navigation.md) 5.3); sie ersetzt die Anzeige, die Eingabesperre ist sofort aktiv, das Zeitfenster startet bei 0 %. Der Balken läuft von links nach rechts (0 % bis 100 %), die Prozentzahl steht als Text im Balken.
- **Während des Ablaufs:** Alle Berührungen werden verworfen, es gibt keine Bedienelemente und keinen Hover-/Pressed-Zustand. Offene Pop-ups bestehen beim Start nicht (die Kachel liegt auf HS-04); ein System-Seitenwechsel würde offene Pop-ups ohne Übernehmen schließen.
- **Ende:** Bei 100 % schließt sich die Seite selbst, ohne Stapelwirkung (`GoBack()`); die vorherige Seite (HS-04) wird wiederhergestellt. Die Zielseite ist im Handbuch nicht genannt (Annahme S24-2, OP-38).
- **Verlängerung:** Erneutes Öffnen der Seite startet das Zeitfenster neu; während des Laufs ist das wegen der Eingabesperre nicht möglich.
- **Abbruch:** Im Handbuch nicht beschrieben, keine Taste vorhanden; daher kein Abbruch durch den Bediener (Annahme S24-2).
- **Meldungen und kritischer Alarm während der Reinigung (Navigation.md 6.5, OP-61):** Normale Meldungen werden weiter erfasst, aber nicht angezeigt (Meldezeile ausgeblendet). Tritt ein kritischer Alarm (Meldungsklasse Störung) auf, beendet er die Reinigung sofort: Die Eingabesperre wird aufgehoben, der Balken stoppt, die Seite schließt vorzeitig ohne Stapelwirkung und die vorherige Seite (HS-04) wird wiederhergestellt. Deren Meldezeile zeigt den Alarm im Format „NNN: Text“ mit Symbol und Schweregradwort. Dies ist eine Annahme ohne Handbuchbeleg (S24-4); der Alarm wird nie durch die Eingabesperre verdeckt.
- **Berechtigungen, Pop-ups, Fehlerfälle:** keine beschrieben; keine Schlüsselsymbole, keine Pop-ups. Fehlt der Zeitgeber (Konfiguration ungültig), gilt eine Dummy-Dauer; die Seite darf sich nie unbegrenzt sperren (Annahme S24-2).
- **Zweiter Kanal:** Der Fortschritt steht als Zahl im Balken (nicht nur als Füllung); der Zustand „Eingaben gesperrt“ steht als Text im Info-Hinweis.

## Prüfpunkte (Tabelle: ID | Prüfung | erwartetes Ergebnis | Status)
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-24-P01 | Aufruf (RS-24-P01) | Seite über Einstellung › Bildschirm reinigen (HS-04, Kachel) erreichbar; Zeitfenster startet sofort bei 0 % | offen |
| HS-24-P02 | Fortschrittsbalken (RS-24-P02) | Balken mit Prozentzahl im Balken (Beispiel „77 %“) zeigt den Ablauf; neutrale Füllung, Zahl als Text | offen |
| HS-24-P03 | Eingabesperre (RS-24-P03) | Während des Zeitfensters löst Berühren des Bildschirms keine Aktion aus (auch nicht in Kopfzeile oder an den Rändern) | offen |
| HS-24-P04 | Automatisches Schließen (RS-24-P04) | Nach Ablauf schließt sich die Seite selbst; vorherige Seite (HS-04) wird wiederhergestellt; kein Eintrag im Zurück-Stapel | offen |
| HS-24-P05 | Neustart (RS-24-P05) | Erneutes Öffnen der Seite startet das Zeitfenster bei 0 % neu | offen |
| HS-24-P06 | Aufbau (RS-24-P06) | Keine Bedienelemente außer der Fortschrittsanzeige; Seitenleiste, Brotkrümel, Kennzahlen, Meldezeile und Funktionsleiste ausgeblendet | offen |
| HS-24-P07 | Bildabdeckung (RS-24-P07) | Jedes Element aus [RS-24_01.png](../../02_Referenz-Analyse/Medien/RS-24_01.png) (Kopfzeile mit Titel, Service-Symbol, Uhrzeit und Datum, Fortschrittsbalken, Fehlen von Meldezeile und Fußleiste) ist in der Elemente-Tabelle wiederzufinden | offen |
| HS-24-P08 | Dauer | Die Dauer kommt aus der Konfiguration (`durationSeconds`), nicht aus einem festen Wert im Seitentext | offen |
| HS-24-P09 | Kopfzeile | Kopfzeile in der Vollbild-Variante ohne Meldezeile, rein anzeigend, Betriebsart mit Symbol und Wort | offen |
| HS-24-P10 | Zweiter Kanal | Fortschritt nur mit Zahl im Balken, Sperrzustand mit Text; keine Information nur über Farbe | offen |
| HS-24-P11 | Tokens | Keine Hex- oder Pixelwerte; Grund `Brush.Window`, Balkenhöhe `Size.Progress.Height`, Abstände `Space.*` | offen |
| HS-24-P12 | Navigation | Brotkrümel-Pfad „Einstellung › Bildschirm reinigen“ nur im Seitenregister; auf der Seite nicht sichtbar; Seite nie im Verlauf | offen |
| HS-24-P13 | Touch-Ziele | Es gibt keine Touch-Ziele; der Info-Hinweis reagiert nicht auf Berührung | offen |
| HS-24-P14 | Kritischer Alarm (OP-61) | Tritt während des Zeitfensters ein kritischer Alarm (Störung) auf, endet die Reinigung sofort, die Eingabesperre ist aufgehoben, die vorherige Seite (HS-04) wird wiederhergestellt und deren Meldezeile zeigt den Alarm; normale Meldungen beenden die Reinigung nicht | offen |

## Offene Punkte
- OP-26: Bedeutung des roten „Service“-Schriftzugs am Wirbel-Symbol; hier Betriebsart „Service“ mit Warnstatus (A-48).
- OP-27: Farbe des Balkens (Gelb) ohne beschriebene Bedeutung; neutral umgesetzt.
- OP-31: Sperrzustände und Rückfragen bei kritischen Aktionen nicht beschrieben (hier: Meldungen während der Reinigung).
- OP-38: Zielseite nach dem automatischen Schließen und Abbruchmöglichkeit nicht beschrieben.
- OP-42: Dauer des Zeitfensters nicht angegeben; Dummy-Wert, konfigurierbar.
- OP-44: Das Bild zeigt Vollbild ohne Meldezeile und Fußleiste; ob Meldungen währenddessen unterdrückt werden, ist unklar.
- OP-61: Alarm während „Bildschirm reinigen“: Entscheidung laut Navigation.md 6.5, kritischer Alarm beendet die Reinigung; Annahme ohne Handbuchbeleg.

### Annahmen dieser Seite
- S24-1: Info-Hinweis „Eingaben gesperrt“ (HM-27, Art Info) ergänzt, damit der Sperrzustand lesbar ist.
- S24-2: Nach Ablauf Rückkehr zur vorherigen Seite (HS-04), kein Abbruch durch den Bediener, Dummy-Dauer bei ungültiger Konfiguration (die Seite sperrt nie unbegrenzt).
- S24-3: Die Kopfzeile bleibt in einer Vollbild-Variante ohne Meldezeile sichtbar (RS-Bild zeigt sie; HM-02 ist laut Modulliste auf HS-24 verwendet).
- S24-4: Ein kritischer Alarm (Meldungsklasse Störung) beendet die Reinigung vorzeitig, gibt die Bedienung frei und wird in der Meldezeile der vorherigen Seite angezeigt (Navigation.md 6.5, OP-61).
