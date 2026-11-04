# HS-29 – Produktionsstatistik

- Quelle: [RS-29](../../02_Referenz-Analyse/Seiten/RS-29_Produktionsstatistik.md) (Handbuch Kapitel 29, keine Tabelle, Bild RS-29_01). Es gibt keine Design-Seite (DS); Layout, Rahmen und Optik sind aus [Designsystem](../Designsystem.md), [Navigation.md](../Navigation.md) und den Modulen abgeleitet.
- Navigationspfad (Brotkrümel): **Einstellung › Produktionsstatistik**. Zugang: [HS-04](HS-04_Einstellungen.md) Kachel „Produktionsstatistik“ (belegt einen leeren Platz, A-36); Zurück-Ziel: HS-04 (Verlauf). PageKey `ProductionStatistics` (Route `settings/statistics`), Parameter `dayOffset` (0 bis 29; 0 = heute), Mindestrolle: keine.

## Zweck

Die Seite zeigt den Verlauf der Produktion eines Tages in einem Balkendiagramm (Wortlaut RS-29). Es können die Verläufe der letzten 30 Tage betrachtet werden. Mit den Pfeiltasten über dem Diagramm wird zwischen den Tagen gewechselt; das Textfeld zwischen den Pfeilen zeigt das Datum. Die Seite ist reine Anzeige.

## Aufbau (Bereiche, Layout)

Die Seite füllt den Inhaltsbereich des Rahmen-Grids ([Designsystem](../Designsystem.md) 3.2; Außenrand `Size.Content.Margin`, Gutter `Space.M`). Zeilen im Inhaltsbereich:

- **Zeile 1 (Höhe `Size.Touch.Default`): Datumsleiste** über alle 12 Spalten, wie die Referenz „über dem Diagramm“: linke Pfeiltaste (Spalte 1 bis 2), Datumsfeld (Spalten 3 bis 10), rechte Pfeiltaste (Spalte 11 bis 12). Die Pfeiltasten sind je mindestens `Size.Touch.Default` × `Size.Touch.Default` groß.
- **Zeile 2 (Höhe `1*`, nimmt den Rest):** Balkendiagramm über alle 12 Spalten: Y-Achse links, X-Achse unten (stündliche Beschriftung 0:00 bis 23:00), Gitternetz, Balken, Zahlenwert über jedem Balken.
- **Funktionsleiste unten:** leer, aber sichtbar (Navigation.md 3.3: HS-29 hat die Blättertasten im Inhaltsbereich, nicht in der Funktionsleiste).

```
+---------+--------------------------------------------------------------+
| Seiten- | Kopfzeile: Logo | Meldezeile | Betriebsart | Uhr/Datum       |
| leiste  +--------------------------------------------------------------+
|         | Einstellung > Produktionsstatistik   | Geschw. | Winkel      |
|         +--------------------------------------------------------------+
|         | [ < ]            [ heute ]  (Datumsfeld, HM-18)        [ > ] |
|         +--------------------------------------------------------------+
|         | 1800 |                         ##                            |
|         |  ... |        ##  ##  ##   ## ##  ##  ##                     |
|         |    0 |_##_##_##_##_##_##_##_##_##_##_##_##_ ...             |
|         |      0:00  1:00  2:00 ...                 23:00   (HM-26)    |
|         +--------------------------------------------------------------+
|         | Funktionsleiste (leer)                                       |
+---------+--------------------------------------------------------------+
```

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)

Die Referenz hat keine Tabelle; Herkunft sind der Funktionssatz („Mit den Pfeiltasten über dem Diagramm …; Das Textfeld zeigt das Datum an.“), die Tabellenzeilen des Elemente-Abschnitts von RS-29 und das Bild RS-29_01.

| Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-29) |
|---|---|---|---|---|
| Pfeiltaste links (◄) | Pfeiltaste der Datumsleiste, `Icon.Chevron` links | wechselt zum früheren Tag (Annahme: links = früher, OP-54); am ältesten Tag (`dayOffset` = 29) deaktiviert mit gestrichelter Kontur; kein Verlaufseintrag | [HM-18](../Module/HM-18_Auswahlfeld-Pfeiltasten.md) (`PreviousCommand`) | Elemente-Zeile „Pfeiltaste links“ |
| Pfeiltaste rechts (►) | Pfeiltaste der Datumsleiste, `Icon.Chevron` rechts | wechselt zum späteren Tag; beim aktuellen Tag (`dayOffset` = 0) deaktiviert mit gestrichelter Kontur; kein Verlaufseintrag | [HM-18](../Module/HM-18_Auswahlfeld-Pfeiltasten.md) (`NextCommand`) | Elemente-Zeile „Pfeiltaste rechts“ |
| Textfeld Datum (Bild „heute“) | Anzeigefeld (kein Eingabefeld) zwischen den Pfeilen | zeigt das Datum des angezeigten Tages; für den aktuellen Tag das Wort „heute“, sonst Datum im Format der aktuellen Kultur (TT.MM.JJJJ, Annahme K29-2) | [HM-18](../Module/HM-18_Auswahlfeld-Pfeiltasten.md) (`DisplayText`) | Elemente-Zeile „Textfeld Datum“ |
| Balkendiagramm Tagesverlauf | Diagramm Art Balken, X = Uhrzeit 0:00 bis 23:00, Y = Zahl | zeigt den Produktionsverlauf des gewählten Tages; Balken neutral (`Brush.Progress.Fill`), keine Statusfarbe (keine Grenzen bekannt) | [HM-26](../Module/HM-26_Diagramm.md) (`ChartKind` = Bar) | Elemente-Zeile „Balkendiagramm“; Bild, Orange Balken |
| Y-Achse | Achse ohne Titel, Teilung 0 bis 1800 in Schritten von 200 (Referenz; Skalierung vermutlich automatisch, nicht belegt) | zeigt die Größe der Balken; ohne Titel und ohne Einheit wie in der Referenz (Einheit und Bedeutung offen, OP-29) | [HM-26](../Module/HM-26_Diagramm.md) (`YStep`, `YMinimum`/`YMaximum` = automatisch) | Bild, Y-Achse; RS-29-P03 |
| X-Achse | Achse mit stündlicher Beschriftung 0:00, 1:00, … 23:00 (Beschriftung nicht schräg: Textfeld `Font.Size.Caption`, bei Platzmangel jede zweite Stunde) | ordnet jeden Balken einer Uhrzeit zu | [HM-26](../Module/HM-26_Diagramm.md) (`XLabels`) | Bild, X-Achse |
| Zahlenwerte über den Balken | Wertbeschriftung (Zahl, senkrecht gedreht, `Font.Size.Caption`, `Brush.Text.Primary`), auch „0“ bei leeren Balken | zeigt den Wert je Balken | [HM-26](../Module/HM-26_Diagramm.md) (`ShowValueLabels`) | Elemente-Zeile „Zahlenwerte über den Balken“; RS-29-P04 |
| Gitternetz | Linien `Brush.Divider` | Ablesehilfe; keine Information | [HM-26](../Module/HM-26_Diagramm.md) | Bild, hellblaue Gitternetzlinien |
| Zustand ohne Daten | Diagramm mit Text „Keine Daten“ und `Icon.Status.Inactive` | wird gezeigt, wenn für den gewählten Tag keine Daten vorliegen (Annahme K29-3) | [HM-26](../Module/HM-26_Diagramm.md) | – (Design-Ergänzung, HM-26) |
| Seitentitel „Produktionsstatistik“ | Brotkrümel, letztes Segment | Pfad der Seite; ersetzt den unterstrichenen Titel der Referenz-Kopfzeile | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | Bild, Kopfzeile |
| Logo, Uhrzeit, Datum, Spiralsymbol | Kopfzeile | Rahmen; Spiralsymbol als Betriebsart-Anzeige (A-48) | [HM-02](../Module/HM-02_Kopfzeile.md) | Elemente-Zeile „Kopfzeile, Meldezeile …“; Bild |
| Meldezeile „*450* Palettierung nicht bereit“ | Meldezeile | Rahmen; Format „NNN: Text“ mit Symbol und Wort; Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | Elemente-Zeile „Kopfzeile, Meldezeile …“; Bild |
| Kennzahlen Geschwindigkeit, Maschinenwinkel | Kennzahl-Kachel im Rahmen | Rahmenelemente des Designs | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | Design-Rahmen (nicht RS) |
| Schloss-Symbol, Tasten „Produktion“, „Einstellungen“, „Zurück“ | Seitenleiste | Schloss wird zum Benutzerkreis; Home, Einstellungen, Zurück (Verlauf) | [HM-01](../Module/HM-01_Seitenleiste.md) | Elemente-Zeile „… untere Leiste (Produktion, Einstellungen, Zurück, Schloss)“ |
| Funktionsleiste (leer) | Funktionsleiste ohne Tasten | bleibt als Fläche sichtbar; keine Tasten „<<“ / „>>“ | [HM-06](../Module/HM-06_Funktionsleiste.md) | Bild, untere Leiste; RS-29-P08 |

## Verwendete Module (IDs)

[HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md), [HM-18](../Module/HM-18_Auswahlfeld-Pfeiltasten.md), [HM-26](../Module/HM-26_Diagramm.md).

Die Modulliste nennt für HS-29 außerdem [HM-07](../Module/HM-07_Aktionstaste.md) (über das Kompositmodul HM-18, Pfeiltasten); auf der Seite selbst gibt es keine weitere Aktionstaste.

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

**Tageswahl.** Die Pfeiltasten ändern nur den Parameter `dayOffset` (`ReplaceParameter`, kein Verlaufseintrag, [Navigation.md](../Navigation.md) 5.3). Abrufbar sind genau die letzten 30 Tage: `dayOffset` 0 (heute) bis 29, also heute und die 29 Vortage (Annahme K29-4: „heute“ ist eingeschlossen, OP-54). Am Rand ist die betroffene Pfeiltaste deaktiviert (gestrichelte Kontur, kein Pressed; Antippen nennt den Grund in der Meldezeile, A-28). Das Datumsfeld und das Diagramm wechseln mit dem Tag; bis die Daten des neuen Tages vorliegen, zeigt das Diagramm den Text „Lädt …“ (Annahme K29-3).

**Anzeige.** Das Balkendiagramm zeigt den Produktionsverlauf des gewählten Tages. Bildwerte als Dummy-Daten (M2): nach etwa 18 leeren Balken die Werte 63, 802, 624, 591, 449, 0, 41, 0, 226, 208, 839, 353, 450, 447, 1761, 294, 56, danach wieder leere Balken; höchster Balken 1761. Die Balkenzahl folgt der Datenreihe der Steuerung. Offene Fragen (OP-29): Was ein Balken darstellt und das Intervall; die Referenz zeigt etwa zwei Balken je Stundenbeschriftung (etwa 48 Balken, Halbstunden vermutet), HM-26 nennt „je Stunde“. Die Y-Achse skaliert automatisch; die Referenzdarstellung 0 bis 1800 in Schritten von 200 ist Ausgangswert der Dummy-Daten.

**Zweiter Kanal.** Die Balken tragen ihre Zahl als Text; der aktuelle Tag trägt das Wort „heute“; deaktivierte Pfeile haben gestrichelte Kontur. Es gibt keine Statusfarben auf dieser Seite (keine Grenzwerte, OP-47).

**Berechtigungen.** Keine (kein Schlüsselsymbol im Bild, keine Angabe im Handbuch; Seite ist reine Anzeige, OP-25, OP-54).

**Pop-ups.** Keine.

**Fehlerfälle.** Keine beschrieben. Fehlende oder ungültige Daten: Diagramm mit „Keine Daten“ (Annahme K29-3); ungültiger Einzelwert: Lücke und Text „---“ an der Stelle (HM-26).

**Navigation.** „Zurück“ (Seitenleiste) führt im Verlauf zu HS-04, unabhängig vom gewählten Tag. Die Navigation löst keine Aktion an der Maschine aus.

## Prüfpunkte (Tabelle: ID | Prüfung | erwartetes Ergebnis | Status)

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-29-P01 | Seitenname und Pfad (RS-29-P01) | Brotkrümel „Einstellung › Produktionsstatistik“; Zugang über HS-04 Kachel „Produktionsstatistik“; „Zurück“ führt zu HS-04 | offen |
| HS-29-P02 | Diagrammart (RS-29-P02) | Produktionsverlauf eines Tages als Balkendiagramm; Balken neutral gefüllt (`Brush.Progress.Fill`), keine Zierfarbe | offen |
| HS-29-P03 | Achsen (RS-29-P03) | X-Achse stündlich 0:00 bis 23:00; Y-Achse bei den Dummy-Daten 0 bis 1800 in Schritten von 200; Y-Achse ohne Titel und ohne Einheit (wie Referenz) | offen |
| HS-29-P04 | Wertbeschriftung (RS-29-P04) | Über jedem Balken steht sein Zahlenwert in mindestens `Font.Size.Caption`, auch „0“ bei leeren Balken | offen |
| HS-29-P05 | Datumsnavigation (RS-29-P05) | Zwei Pfeiltasten links und rechts über dem Diagramm (je mindestens `Size.Touch.Default`) wechseln zwischen den Tagen; links = früher; kein Verlaufseintrag | offen |
| HS-29-P06 | Datumsfeld (RS-29-P06) | Textfeld zwischen den Pfeilen zeigt das Datum des angezeigten Tages; für den aktuellen Tag das Wort „heute“; nur Anzeige, nicht bedienbar | offen |
| HS-29-P07 | Zeitraum (RS-29-P07) | Genau 30 Tage abrufbar (`dayOffset` 0 bis 29); beim ältesten Tag ist die linke Taste, beim aktuellen Tag die rechte Taste deaktiviert (gestrichelte Kontur) | offen |
| HS-29-P08 | Rahmenelemente (RS-29-P08) | Kopfzeile (Logo, Betriebsart, Uhrzeit, Datum), Meldezeile, Seitenleiste (Benutzerkreis statt Schloss, Home, Einstellungen, Zurück); Funktionsleiste leer und sichtbar, keine Tasten „<<“ / „>>“ | offen |
| HS-29-P09 | Vollständigkeit (RS-29-P09) | Zweck, beide Sätze der Funktionsbeschreibung, alle Elemente-Zeilen und die Bildelemente aus RS-29_01 sind im Layout wiederzufinden (Spalte „Herkunft“) | offen |
| HS-29-P10 | Tageswechsel | Nach Tippen auf eine Pfeiltaste zeigen Datumsfeld und Diagramm denselben neuen Tag; Wechsel in unter 1 s oder Text „Lädt …“ | offen |
| HS-29-P11 | Zustand ohne Daten | Ohne Daten zeigt das Diagramm „Keine Daten“ mit `Icon.Status.Inactive`, nicht ein leeres Raster | offen |
| HS-29-P12 | Touch-Ziele (Designsystem) | Pfeiltasten mindestens `Size.Touch.Default` hoch, Trefferbereich nie unter `Size.Touch.Min`, Abstand zum Datumsfeld mindestens `Size.Touch.Gap` | offen |
| HS-29-P13 | Zweiter Kanal (Designsystem) | Deaktivierte Pfeile durch gestrichelte Kontur (`Border.Dash`), nicht nur durch hellere Schrift; Wert je Balken als Zahl | offen |
| HS-29-P14 | Tokens und Texte (Designsystem) | Keine Hex-, Pixel- oder Literaltexte im XAML; Balken, Gitter und Texte aus Tokens; Datum, „heute“, „Keine Daten“, Achsenbeschriftung aus `.resx` | offen |
| HS-29-P15 | Hell/Dunkel | Beide Themen: Balken, Gitter und Werte mindestens 3 : 1 bzw. Text mindestens 4,5 : 1 | offen |

## Offene Punkte

Aus dem Seiten-Index in [Offene-Punkte.md](../../00_Plan/Offene-Punkte.md): [OP-25](../../00_Plan/Offene-Punkte.md) (Berechtigung), [OP-26](../../00_Plan/Offene-Punkte.md) (Schloss- und Spiralsymbol), [OP-29](../../00_Plan/Offene-Punkte.md) (Einheit und Bedeutung der Y-Achse, Zeitintervall der Balken), [OP-47](../../00_Plan/Offene-Punkte.md) (Grenzlinien, Skalierung), [OP-54](../../00_Plan/Offene-Punkte.md) (Pfeilrichtung, Datumsformat, „heute“ in 30 Tagen). Zusätzlich berührt: OP-21 (Antippbarkeit des Brotkrümels).

Weiterhin offen: Was ein Balken darstellt (Packungen, Stück) und dessen Einheit; Intervall (Stunde oder Halbstunde, etwa 48 Balken); Y-Achsen-Skalierung (fest oder automatisch); Pfeilrichtung (Annahme links = früher).

## Annahmen dieser Seite

Lokale Kennungen; der Verwalter überträgt sie nach [Annahmen.md](../../00_Plan/Annahmen.md).

| Kennung | Annahme |
|---|---|
| K29-1 | Die Balkenzahl folgt der Datenreihe der Steuerung; die X-Beschriftung ist stündlich; Y-Achse ohne Einheit und Titel (wie Referenz). |
| K29-2 | Datumsformat der aktuellen Kultur (TT.MM.JJJJ); „heute“ nur für den aktuellen Tag. |
| K29-3 | Diagramm-Zustände „Keine Daten“ und „Lädt …“. |
| K29-4 | 30 Tage = heute plus 29 Vortage (`dayOffset` 0 bis 29, wie Seitenregister); links = früher, Randtasten deaktiviert. |
