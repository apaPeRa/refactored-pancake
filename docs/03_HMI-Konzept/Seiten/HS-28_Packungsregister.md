# HS-28 – Packungsregister

- Quelle: [RS-28](../../02_Referenz-Analyse/Seiten/RS-28_Packungsregister.md) (Handbuch Kapitel 28, Tabelle T39, Bild RS-28_01). Es gibt keine Design-Seite (DS); Layout, Rahmen und Optik sind aus [Designsystem](../Designsystem.md), [Navigation.md](../Navigation.md) und den Modulen abgeleitet. Die Kachel „Packungsregister“ steht in DS-02 (Einstellungen).
- Navigationspfad (Brotkrümel): **Einstellung › Packungsregister**. Zugang: [HS-04](HS-04_Einstellungen.md) Kachel „Packungsregister“; Zurück-Ziel: HS-04 (Verlauf). PageKey `PackRegister` (Route `settings/packregister`), kein Parameter, Mindestrolle: keine.

## Zweck

Das Packungsregister stellt die einzelnen Stationen der Maschine grafisch dar und zeigt für jede Position, ob dort eine Packung ist und in welchem Zustand (Wortlaut RS-28). Es dient der Nachverfolgung des Packungsstatus durch den Maschinenverlauf. Durch Antippen eines Felds kann der Zustand einer Station manuell geändert werden. Bestimmte Maschinenfunktionen (z. B. Blaslüfte) arbeiten nur korrekt, wenn im Register eine Packung vorhanden ist.

## Aufbau (Bereiche, Layout)

Die Seite füllt den Inhaltsbereich des Rahmen-Grids ([Designsystem](../Designsystem.md) 3.2; Außenrand `Size.Content.Margin`, Gutter `Space.M`). Zeilen im Inhaltsbereich (Stern-Proportionen):

- **Zeile 1 (Höhe `1*`, nimmt den Rest):** Stationsgrafik in einem Bildlaufbereich über die volle Breite (12 Spalten), horizontal (wie Referenz) und bei Bedarf vertikal scrollbar. Die Topologie der Referenz bleibt: linker Block (6 Felder), Drehstern mit Mittelkreis und 12 Armen, vom Stern nach rechts die nummerierte Reihe (ab Nr. 40, mindestens bis 61), unter dem Stern die senkrechte Spalte (9 Felder), Verbindungsstreifen zwischen Block, Stern und rechter Reihe.
- **Zeile 2 (Höhe nach Inhalt, mindestens `Size.Touch.Default`):** Legende mit fünf Einträgen (Symbol, Wort und Zustandsfläche je Eintrag) als feste Leiste unter dem Bildlaufbereich; sie scrollt nicht mit (Annahme K28-2, zugleich ist die Legende dadurch immer sichtbar, was in der Referenz im Bildlauf verloren gehen konnte).
- **Zeile 3 (Höhe nach Inhalt):** Hinweis-Textfeld (Art Info) mit dem Abhängigkeitshinweis zu Maschinenfunktionen, über alle 12 Spalten.
- **Funktionsleiste unten:** leer, aber sichtbar (keine Tasten, [Navigation.md](../Navigation.md) 3.3; keine Blättertasten wie in der Referenz).

Stationsfelder sind Touch-Ziele: Trefferbereich mindestens `Size.Touch.Min` × `Size.Touch.Min`, Abstand zwischen benachbarten Feldern mindestens `Size.Touch.Gap`. Dadurch ist die Grafik größer als der sichtbare Ausschnitt; das erklärt den horizontalen (und vertikalen) Bildlauf (Annahme K28-1).

```
+---------+--------------------------------------------------------------+
| Seiten- | Kopfzeile: Logo | Meldezeile | Betriebsart | Uhr/Datum       |
| leiste  +--------------------------------------------------------------+
|         | Einstellung > Packungsregister       | Geschw. | Winkel      |
|         +--------------------------------------------------------------+
|         |       [] [] []  (Stern, 12 Arme)                             |
|         | [][][][][][][]==(  O  )==[40][41][42] ... [61]...  --> Bildlauf
|         |  Block links 6       |                                       |
|         |                    [] (Spalte, 9 Felder)                     |
|         +--------------------------------------------------------------+
|         | Legende: o Keine | x Schlecht | [] Vorhanden | Befüllt | OK  |
|         | Hinweis: Funktionen wie Blaslüfte arbeiten nur bei Packung   |
|         +--------------------------------------------------------------+
|         | Funktionsleiste (leer)                                       |
+---------+--------------------------------------------------------------+
```

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)

Spalte „Herkunft“ weist die Rückverfolgung nach RS-28 aus (T39 = Tabelle Anzeigezustände, Text = Fließtext der Funktionsbeschreibung, Bild = nur im Bild sichtbar).

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-28) |
|---|---|---|---|---|
| Zustand „Keine Packung“ (Referenz: Feld grau; Legende „Nicht vorhanden“) | Zustandsfeld einer Station: Fläche `Brush.Surface`, Kontur `Border.Thin`, `Icon.Status.Inactive` und Wort „keine“ | an dieser Position befindet sich aktuell keine Packung | [HM-32](../Module/HM-32_Packungsregister-Grafik.md) | T39 Zeile „Feld grau“ |
| Zustand „Schlecht“ (Referenz: Feld rot) | Zustandsfeld: `Brush.Status.Error.Subtle`, Kontur `Border.Thick` `Brush.Status.Error.Fg`, `Icon.Status.Error` und Wort „schlecht“ | Packung ist als Schlechtpackung markiert und wird ausgestoßen | [HM-32](../Module/HM-32_Packungsregister-Grafik.md) | T39 Zeile „Feld rot“ |
| Zustand „Vorhanden“ (Referenz: Feld gelb) | Zustandsfeld: `Brush.Surface.Sunken`, Kontur `Border.Medium`, `Icon.Pack.Present` und Wort „vorhanden“ | Packung ist an dieser Position, aber noch nicht befüllt oder gewogen | [HM-32](../Module/HM-32_Packungsregister-Grafik.md) | T39 Zeile „Feld gelb“ |
| Zustand „Befüllt“ (Referenz: Feld orange) | Zustandsfeld: `Brush.Status.Info.Subtle`, `Icon.Pack.Filled` und Wort „befüllt“ | Packung wurde mit Produkt befüllt | [HM-32](../Module/HM-32_Packungsregister-Grafik.md) | T39 Zeile „Feld orange“ |
| Zustand „Gut“ (Referenz: Feld grün) | Zustandsfeld: `Brush.Status.Ok.Subtle`, `Icon.Status.Ok` und Wort „OK“ | Packung wurde von der Endkontrollwaage (EKW) als in Ordnung bewertet | [HM-32](../Module/HM-32_Packungsregister-Grafik.md) | T39 Zeile „Feld grün“ |
| Linker Block | Stationsreihe, 6 Felder nebeneinander, unnummeriert (Bild: 3 vorhanden, 2 schlecht, 1 keine) | zeigt den Zustand der 6 Stationen; Felder antippbar | [HM-32](../Module/HM-32_Packungsregister-Grafik.md) | Bild, linker Block |
| Drehstern | Stationskranz mit Mittelkreis, 12 Arme mit je einem Feld, unnummeriert (Bild im Uhrzeigersinn ab oben: 4 vorhanden, 1 keine, 4 vorhanden, 3 schlecht) | zeigt den Zustand der 12 Stationen; Felder antippbar | [HM-32](../Module/HM-32_Packungsregister-Grafik.md) | Bild, Drehstern |
| Rechte Reihe | nummerierte Stationsreihe ab Nr. 40, mindestens bis Nr. 61, fortlaufend; Nummer als Text im Feld | zeigt den Zustand der Stationen 40 ff. (Bild: 40, 41 vorhanden; 42 bis 52 befüllt; 53 bis 61 gut); Felder antippbar | [HM-32](../Module/HM-32_Packungsregister-Grafik.md) | Bild, rechte Reihe; RS-28-P11 |
| Vertikale Spalte | Stationsreihe, 9 Felder übereinander, unnummeriert (Bild: alle vorhanden) | zeigt den Zustand der 9 Stationen; Felder antippbar | [HM-32](../Module/HM-32_Packungsregister-Grafik.md) | Bild, vertikale Spalte |
| Manuelle Zustandsänderung | Antippen eines Stationsfelds (`ToggleStationCommand`) | ändert den Zustand der Station manuell; Zustandsfolge ist nicht beschrieben (Dummy: Zyklus in der Reihenfolge der Legende, Annahme K28-3) | [HM-32](../Module/HM-32_Packungsregister-Grafik.md) | Text „Durch Antippen eines Felds …“ |
| Legende | feste Leiste mit 5 Einträgen: Nicht vorhanden, Schlecht, Vorhanden, Befüllt, Gut (Symbol, Fläche, Wort) | erklärt die Zustände; Kurzbezeichnungen aus dem Bild, Zuordnung zu den T39-Zeilen über Zustand | [HM-32](../Module/HM-32_Packungsregister-Grafik.md) (`ShowLegend`) | Bild, Legende (5 Einträge); T39 |
| Bildlauf | horizontale (und bei Bedarf vertikale) Bildlaufleiste mit Touch-Wischen | verschiebt die Stationsgrafik seitlich; Legende und Hinweis bleiben stehen | [HM-32](../Module/HM-32_Packungsregister-Grafik.md) (`HorizontalOffset`) | Bild, Bildlaufleiste |
| Abhängigkeitshinweis | Hinweis-Textfeld, Art Info, nur Anzeige | „Bestimmte Maschinenfunktionen (z. B. Blaslüfte) arbeiten nur korrekt, wenn im Packungsregister eine Packung vorhanden ist.“ | [HM-27](../Module/HM-27_Hinweis-Textfeld.md) | Text, zweite Aussage |
| Seitentitel „Packungsregister“ | Brotkrümel, letztes Segment | Pfad der Seite; ersetzt den unterstrichenen Titel der Referenz-Kopfzeile | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | Bild, Kopfzeile |
| Logo, Uhrzeit, Datum, Spiralsymbol | Kopfzeile | Rahmen; Spiralsymbol als Betriebsart-Anzeige (A-48) | [HM-02](../Module/HM-02_Kopfzeile.md) | Bild, Kopfzeile |
| Meldezeile „*450* Palettierung nicht bereit“ | Meldezeile | Rahmen; Format „NNN: Text“ mit Symbol und Wort; Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | Bild, Meldezeile |
| Kennzahlen Geschwindigkeit, Maschinenwinkel | Kennzahl-Kachel im Rahmen | Rahmenelemente des Designs | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | Design-Rahmen (nicht RS) |
| Schloss-Symbol, Tasten „Produktion“, „Einstellungen“, „Zurück“ | Seitenleiste | Schloss wird zum Benutzerkreis; Home, Einstellungen, Zurück (Verlauf) | [HM-01](../Module/HM-01_Seitenleiste.md) | Bild, untere Leiste (RM-03) |
| Funktionsleiste (leer) | Funktionsleiste ohne Tasten | bleibt als Fläche sichtbar; keine Tasten „<<“ / „>>“ | [HM-06](../Module/HM-06_Funktionsleiste.md) | Bild, untere Leiste; RS-28-P13 |

## Verwendete Module

[HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md), [HM-27](../Module/HM-27_Hinweis-Textfeld.md), [HM-32](../Module/HM-32_Packungsregister-Grafik.md).

## Zustände und Interaktion

**Stationszustände (5).** Keine Packung, Vorhanden, Befüllt, In Ordnung, Schlecht (A-53). Jeder Zustand hat Symbol und Wort; die Farbe unterstützt nur dort, wo sie einen Status ausdrückt (Fehler, Ok, Info); „Vorhanden“ ist neutral mit Kontur `Border.Medium`. Alle Zustände sind in Schwarz-Weiß unterscheidbar (Form: leerer Kreis, gefülltes Quadrat, Befüllt-Symbol, Haken, Kreuz). Die Referenz stellt die Zustände nur über Farbe dar (OP-43).

**Bedienung.** Antippen eines Felds löst die manuelle Zustandsänderung aus (Wirkung beim Loslassen im Ziel, [Designsystem](../Designsystem.md) 5). Gedrückt: `Brush.Button.Pressed`, Kontur `Border.Medium`. Die Zustandsfolge (Zyklus oder Auswahl) ist in der Quelle nicht beschrieben (OP-53); in der Dummy-Implementierung (M2) wechselt das Feld zyklisch in Legendenreihenfolge (Annahme K28-3). Die Änderung gilt als Eingriff in den Maschinenverlauf: Meldezeile oder Statuswort nennen das Ergebnis, ein Fehlschlag zeigt `Icon.Status.Error` am Feld (Rahmen `Border.Thick`).

**Berechtigungen.** Im Bild kein Schlüsselsymbol, das Handbuch nennt keine Berechtigung für das manuelle Ändern; die Felder sind für jeden angemeldeten Benutzer bedienbar (Referenz gewinnt, OP-25). Ob eine Rolle nötig ist, bleibt offen (OP-53); wird später ein Schlüssel ergänzt, gilt die Symbolik aus [Designsystem](../Designsystem.md) 5 (Schlüssel/Schloss, Hinweis „Berechtigung erforderlich: <Rolle>“).

**Abhängigkeit.** Der Hinweis zu Blaslüften steht als Info-Text unter der Grafik, damit die Wirkung einer manuellen Änderung erkennbar bleibt.

**Bildlauf.** Wischen bzw. Bildlaufleiste verschiebt die Grafik; die Legende und der Hinweis bleiben stehen. Beim Wechsel auf die Seite steht der Bildlauf am linken Rand (Annahme K28-1).

**Pop-ups.** Keine (Referenz). Pop-up-Regeln aus [Navigation.md](../Navigation.md) 4.2 gelten nur für das Benutzer-Pop-up und Meldungen.

**Fehlerfälle.** Keine beschrieben. Ist keine Verbindung zur Steuerung vorhanden oder fehlen Stationsdaten: Felder zeigen „keine Daten“ mit `Icon.Status.Inactive`, die Seite bleibt bedienbar (Annahme K28-4, nicht zu verwechseln mit dem Zustand „Keine Packung“).

**Navigation.** „Zurück“ führt im Verlauf zu HS-04. Keine Blättertasten, keine Funktionsleisten-Tasten. Die Navigation löst keine Aktion an der Maschine aus.

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-28-P01 | Seitenname und Pfad (RS-28-P01) | Brotkrümel „Einstellung › Packungsregister“; Zugang über HS-04 Kachel „Packungsregister“; „Zurück“ führt zu HS-04 | offen |
| HS-28-P02 | Grafische Darstellung (RS-28-P02) | Block links (6 Felder), Drehstern (12 Felder), nummerierte Reihe rechts (ab Nr. 40), vertikale Spalte (9 Felder) mit Verbindungsstreifen; Anordnung wie im Bild | offen |
| HS-28-P03 | Zustand „Keine Packung“ (RS-28-P03) | `Icon.Status.Inactive` und Wort „keine“; kein Farbton nötig zum Erkennen | offen |
| HS-28-P04 | Zustand „Schlecht“ (RS-28-P04) | `Icon.Status.Error`, Wort „schlecht“, Kontur `Border.Thick`; wird als Schlechtpackung/Ausstoß erkannt | offen |
| HS-28-P05 | Zustand „Vorhanden“ (RS-28-P05) | `Icon.Pack.Present` und Wort „vorhanden“, neutrale Fläche mit Kontur `Border.Medium` | offen |
| HS-28-P06 | Zustand „Befüllt“ (RS-28-P06) | `Icon.Pack.Filled` und Wort „befüllt“ | offen |
| HS-28-P07 | Zustand „Gut“ (RS-28-P07) | `Icon.Status.Ok` und Wort „OK“; Bedeutung „von der Endkontrollwaage (EKW) als in Ordnung bewertet“ ist in der Legende oder im Tooltip nachlesbar | offen |
| HS-28-P08 | Legende (RS-28-P08) | 5 Einträge: Nicht vorhanden, Schlecht, Vorhanden, Befüllt, Gut, je mit Symbol und Wort; Legende bleibt beim Bildlauf sichtbar | offen |
| HS-28-P09 | Manuelle Änderung (RS-28-P09) | Antippen eines Felds ändert den Zustand der Station; Trefferbereich mindestens `Size.Touch.Min`; Auslösen beim Loslassen im Ziel | offen |
| HS-28-P10 | Abhängigkeit Maschinenfunktion (RS-28-P10) | Hinweis „Funktionen wie Blaslüfte arbeiten nur bei vorhandener Packung“ steht als Info-Text auf der Seite | offen |
| HS-28-P11 | Nummerierung (RS-28-P11) | Felder der rechten Reihe tragen Nummern ab 40, fortlaufend (Bild: 40 bis 61 sichtbar, Gesamtzahl konfigurationsabhängig); die übrigen Gruppen sind unnummeriert | offen |
| HS-28-P12 | Scrollen (RS-28-P12) | Grafik ist seitlich scrollbar; der Bildlauf bewegt Legende und Hinweis nicht | offen |
| HS-28-P13 | Rahmenelemente (RS-28-P13) | Kopfzeile, Meldezeile, Seitenleiste (Benutzerkreis statt Schloss, Home, Einstellungen, Zurück); Funktionsleiste leer und sichtbar, keine Tasten „<<“ / „>>“ | offen |
| HS-28-P14 | Vollständigkeit (RS-28-P14) | Alle 5 Zeilen aus T39, beide Fließtextaussagen und die Bildelemente aus RS-28_01 sind im Layout wiederzufinden (Spalte „Herkunft“) | offen |
| HS-28-P15 | Zweiter Kanal (Designsystem, OP-43) | Alle 5 Zustände unterscheiden sich in Schwarz-Weiß durch Symbol und Wort; Farbe ist nie der einzige Kanal | offen |
| HS-28-P16 | Touch-Ziele (Designsystem) | Stationsfelder mindestens `Size.Touch.Min` × `Size.Touch.Min`, Abstand mindestens `Size.Touch.Gap`; Legende und Hinweis erhalten keine Bedienfunktion | offen |
| HS-28-P17 | Tokens und Texte (Designsystem) | Keine Hex-, Pixel- oder Literaltexte im XAML; Zustandsfarben nur aus `Brush.Status.*` und Neutral-Tokens; Wörter der Zustände und die Legende aus `.resx` | offen |
| HS-28-P18 | Hell/Dunkel | Beide Themen: alle fünf Zustände unterscheidbar, Symbole und Text mindestens 4,5 : 1, Konturen mindestens 3 : 1 | offen |

## Offene Punkte

Aus dem Seiten-Index in [Offene-Punkte.md](../../00_Plan/Offene-Punkte.md): [OP-26](../../00_Plan/Offene-Punkte.md) (Schloss- und Spiralsymbol), [OP-27](../../00_Plan/Offene-Punkte.md) (Farbbedeutung), [OP-34](../../00_Plan/Offene-Punkte.md) (Legendenkurzbezeichnungen gegen Handbuchbezeichnungen), [OP-41](../../00_Plan/Offene-Punkte.md) (Anzahl der Stationen), [OP-43](../../00_Plan/Offene-Punkte.md) (Zustand nur über Farbe), [OP-44](../../00_Plan/Offene-Punkte.md) (rechte Reihe im Bild abgeschnitten), [OP-53](../../00_Plan/Offene-Punkte.md) (Zustandsfolge beim Antippen, Zustand „gewogen“, Gruppenzuordnung). Zusätzlich berührt: OP-25 (Berechtigung), OP-21 (Antippbarkeit des Brotkrümels).

Annahme-Kandidaten dieser Seite (Verwalter, siehe Bericht): K28-1 Touch-Raster (Trefferbereich `Size.Touch.Min`, Abstand `Size.Touch.Gap`) vergrößert die Grafik, daher Bildlauf horizontal und bei Bedarf vertikal; K28-2 Legende und Hinweis als feste Leisten unterhalb des Bildlaufbereichs; K28-3 Dummy-Zustandsfolge zyklisch in Legendenreihenfolge; K28-4 Zustand „keine Daten“ bei fehlender Verbindung. Weiterhin offen: Gesamtzahl und Zuordnung der Stationen zu realen Maschinenstationen, Nummern der Stationen außerhalb der rechten Reihe, Frage, ob „gewogen“ ein eigener Zustand ist (gelb umfasst „nicht befüllt oder gewogen“), Berechtigung für die manuelle Änderung.
