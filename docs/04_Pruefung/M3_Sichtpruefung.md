# Sichtprüfung Meilenstein 3 (visueller Abgleich der Windows-Screenshots)

- Gegenstand: `docs/04_Pruefung/Screenshots_M3/` (86 PNG, HS-01 bis HS-43, hell und dunkel, je 1920 × 1061 Pixel), Branch `claude/nice-curie-u22ycb`.
- Vergleich gegen: Seitenbeschreibungen `docs/03_HMI-Konzept/Seiten/HS-xx_*.md`, Design-Screenshots `src_Data/Design/` (Zuordnung nach `Rueckverfolgung.md`: Seite_Produktion = HS-01, Seite_Einstellungen = HS-04, Seite_Heissleim = HS-07, Seite_Kartonzufuehrung = HS-06, **Seite_Dosierer = HS-41 (Dosierer-Übersicht), nicht HS-19**), Designsystem und Controls unter `src/ApaTec.Hmi`.
- Vorgehen: alle 43 Hell-Aufnahmen einzeln angesehen; Dunkel-Aufnahmen einzeln für HS-01, 02, 04, 06, 07, 08, 10, 13, 15, 18, 22, 28, 31, 36, 37, 39, 41 (Seiten mit Kontrast-, Scrollleisten- oder Statusfragen). Die übrigen Dunkel-Aufnahmen wurden nicht einzeln geöffnet; sie verwenden dieselben Controls und Seitenstrukturen, ihr Urteil in Abschnitt 3 ist daher vom Hell-Urteil abgeleitet (in der Tabelle mit „(abgeleitet)“ markiert).
- Kontrast wurde an Stichproben gemessen (Pixel-Auswertung): deaktivierte Zeile „Pistole 2“ 7,6 : 1 (hell) und 7,3 : 1 (dunkel), „Reserviert“ 4,7 : 1, Primärtext über 15 : 1. Es gibt keinen systemischen Kontrastfehler.
- ID-Hinweis: Die hier vergebenen Befund-IDs S-xx (systemisch) und B-xx (seitenspezifisch) sind neu und nicht identisch mit den Restbefunden B-01 bis B-06 aus `Pruefbericht_M2.md`.
- Die Prüfung selbst hat keine Dateien außer diesem Bericht geändert; die Behebung ist in Abschnitt 6 dokumentiert.

## 1 Zusammenfassung

**Gesamtbild:** Das Rahmenlayout (Seitenleiste, Kopfzeile, Brotkrümel, Funktionsleiste), die Kacheln-Übersichtsseiten, Pop-ups, Listen und das Dunkel-Thema sind im Kern gelungen und folgen dem Designsystem (ruhige Flächen, Farbe nur für Status, Zustände mit Symbol und Wort, durchgängig gute Kontraste, Touch-Ziele überwiegend 64 px). Das Dunkel-Thema zeigt keine eigenen Fehler außer nicht thematisierten Scrollleisten (S-09).

**Hauptproblem:** Der Inhaltsbereich ist für die Inhalte zu niedrig. Bei der aufgenommenen Client-Höhe von 1061 px bleiben dem Inhalt nur etwa 754 px (Konzept rechnet mit 768 px bei 1080 px). Viele Seiten fordern mehr Höhe (Auto-Zeilen, feste Mindestmaße 64 px, Schrift 24 bis 36 px) und werden vom WPF-Layout einfach unten abgeschnitten, ohne Scrollleiste. Dadurch fehlen auf mehreren Seiten Bedienelemente und Werte (S-01). Zweites Hauptproblem: Text bricht in schmalen Kacheln, Schaltflächen und Beschriftungsspalten mitten im Wort um (S-02), und Felder mit fester Mindestbreite 160 px werden abgeschnitten oder überlappen (S-03).

**Zählung (Hell, 43 Seiten):** ok 16, Abweichung 18, Fehler 9. Fehler: HS-01, 07, 13, 14, 16, 19, 21, 39, 41; HS-06 und HS-11 sind schwere Abweichungen (fehlende Bedienelemente bzw. abgeschnittene Hinweise). Dunkel entspricht dem Hell-Urteil (keine zusätzlichen Fehler, zusätzliche Abweichung nur durch Scrollleisten).

**Systemische Befunde:** 13 (S-01 bis S-13), davon 3 hoch, 5 mittel, 5 niedrig. **Seitenspezifische Befunde:** B-01 bis B-35.

**Bekannte, nicht neu bewertete Punkte:** Logo ist nur Textplatzhalter „APA-TEC“ (OP-66, A-78, vorgesehen für M3-12), siehe S-06. HM-20-Detail in HS-11/HS-19 (Matrix-Befund B-01) bleibt separate Entscheidung.

**Hinweis zur Aufnahmequalität:** Die Bilder sind 1920 × 1061 statt 1920 × 1080; in mehreren Aufnahmen (u. a. HS-02, 03, 04, 07, 09, 24, 25, 33 bis 36, 39) liegt am rechten und unteren Rand ein schwarzer Streifen. Siehe S-08. Das ändert nichts an den Überlaufbefunden (der Fehlbetrag ist deutlich größer als 19 px), die Aufnahmen sollten aber nach Behebung von S-08 neu erzeugt werden.

## 2 Systemische Befunde

### S-01 Inhalt höher als der Inhaltsbereich, Abschneiden ohne Scrollen (hoch)
- **Beschreibung:** Gruppen, Tabellen und Zeilen werden unten hart abgeschnitten, ohne Scrollleiste und ohne Hinweis. Bedienelemente werden dadurch unerreichbar.
- **Betroffene Seiten:** HS-01 (Geschwindigkeit-Gruppe ohne „Schnell“-Taste, Produktion ohne „Letzte Produktion“, Versorgung ohne „Folgemaschine“, Umschalterblock ohne 5. Zeile), HS-05 (Klebestelle und Kupplung ohne Unterkante), HS-06 („Anwahl Spülen“ 2. Reihe fehlt), HS-11 und HS-19 (Eichdosierung, Hinweisbox), HS-13 (komplett), HS-14 (Statistikkacheln), HS-18 (rechte Hinweisspalte), HS-21 (Tabelle, ca. 12 von 20 Wertepaaren sichtbar), HS-39 (IPC-Spalte „HMI Applikation Build“), HS-41 (Auslastung, Manuell, Entleeren). In Listen zusätzlich teilweise sichtbare letzte Zeile (HS-26, 37, 38), siehe S-10.
- **Vermutete Ursache:** `src/ApaTec.Hmi/MainWindow.xaml` Rahmenraster Zeilen 4\* : 3\* : 34\* : 4\* (`Themes/Tokens.xaml`: `Size.Header.Height`, `Size.Crumb.Height`, `Size.Content.Height`, `Size.FunctionBar.Height`) und `Size.Content.Margin` 24 ergeben bei 1061 px nur ca. 754 px Inhaltshöhe (bei 1080 px 768 px). Die Seiten verwenden Auto-Zeilen und Mindestmaße (`Size.Touch.Default` 64, `Font.Size.Body` 24, `Font.Size.Metric` 36, Panel-Innenabstand `Inset.M`, `HM15_GroupPanel` Zeile `*` mit `ContentPresenter`). Übersteigt der gewünschte Platz den Stern-Platz, schneidet WPF per Layout-Clip ab. Es gibt keinen `ScrollViewer` im Inhaltsbereich (nur lokal in HS-10, 18, 22, 24, 27). Die Höhenbilanzen in den Seitendateien (z. B. HS-01-P21, HS-16-P20, HS-19-P21, HS-41-P19, „768 px“) stimmen mit der Praxis nicht überein.
- **Lösungsvorschlag:** (1) Rahmen verschlanken: Kopfzeile, Brotkrümel und Funktionsleiste in festen Höhen (z. B. 80 / 64 / 80 px) statt Sternanteilen und `Size.Content.Margin` auf 16, das bringt rund 50 bis 60 px. (2) Kompakt-Dichte als Token (z. B. `Font.Size.Body` 22 und Zeilenhöhe 56 auf dichten Seiten HS-01, 13, 19, 41) mit Mindestmaß 48 px. (3) Sicherheitsnetz: `Shell.ContentHost` in einen `ScrollViewer` (vertikal Auto, `PanningMode=VerticalOnly`, sichtbare Scrollleiste ≥ 24 px) legen, damit nie etwas unerreichbar ist. (4) Höhenbilanzen in den HS-Dateien auf die gemessenen Werte korrigieren, Prüfpunkte „Passt ohne Scrollen“ nach Behebung erneut aufnehmen.

### S-02 Mitten im Wort umbrochener Text in schmalen Kacheln, Tasten und Beschriftungsspalten (hoch)
- **Beschreibung:** Beschriftungen brechen buchstabenweise um: „Aut / oma / tik“, „Zuführ / ng“, „Leerpak / ete / ausblase / n“, „Bunker leerfahre / n“, „Fü / lls / ys / te / m“, „Zeitschaltu / hr“, „Vertei / ler“, „Pistol / e 1“, „Schla / uch 1“, „Anfa / ng“, „Daue / r“, „Endla / ge“, „Aktuel / l“, „Maschinenbeleuchtun / g“.
- **Betroffene Seiten:** HS-01 (alle 6 Tastenkacheln und „Maschinenbeleuchtung“), HS-07 (Tasten „Füllsystem“, „Zeitschaltuhr“, Temperaturbeschriftungen), HS-16 (Kopfleim-Block), HS-31 (Endlage), HS-39 (IPC „Aktuell“).
- **Vermutete Ursache:** `Controls/HM08_ToggleSwitch.Styles.xaml` Tile-Vorlage: Spalten Auto (Symbol) | \* (Beschriftung, `TextWrapping="Wrap"`) | Auto (Zustandssymbol) | Auto (Zustandswort); die Beschriftung bekommt nur den Restplatz (bei 208 px Kachelbreite wenige Zeichen) und WPF bricht dann mitten im Wort. Gleiches Muster in `HM11_ValueDisplay.Styles.xaml` (Presentation Row, Beschriftungsspalte Auto, Feld `MinWidth` 160) und `HM12_ValueInput.Styles.xaml`.
- **Lösungsvorschlag:** Tile-Variante vertikal aufbauen (Beschriftung oben über volle Breite, darunter Zustandssymbol und Wort), Beschriftung mit Kachel-Schriftgröße `Font.Size.Caption` 20, nur an Wortgrenzen umbrechen (Silbentrennung per `Hyphenate`/weiche Trennzeichen in den .resx, z. B. „Zuführung“ bleibt ein Wort und wird bei Bedarf verkleinert, nicht zerlegt). Beschriftungsspalten in HM11/HM12 mit `MinWidth` (z. B. 120) und Seiten so anordnen, dass Label-Spalte und Feld in einer 2-Spalten-Struktur stehen (Label \*, Feld Auto). Als Regel in `Designsystem.md`: Umbruch nie innerhalb eines Wortes, stattdessen `TextTrimming` plus Tooltip oder zweite Zeile.

### S-03 Wert-/Eingabefelder mit Mindestbreite 160 px werden abgeschnitten oder überlappen (hoch)
- **Beschreibung:** Felder ragen über ihre Spalte hinaus oder werden rechts abgeschnitten: Einheit und Schloss fehlen, Rahmen offen, Wert halb sichtbar.
- **Betroffene Seiten:** HS-16 (Anfang „28“, Ende „32“ ohne Einheit/Schloss; Dauer „50“), HS-22 („Ist“-Feld ohne rechte Kante), HS-39 (Servo-Tabelle: vier Spalten leere Felder oder „0,(“), HS-13 (Wägeparameter, „Automatischer …“), HS-41 (Header-Pfeilschaltfläche überlappt das Soll-Feld).
- **Vermutete Ursache:** `HM11_ValueDisplay.Styles.xaml` (Face `MinWidth="{StaticResource Size.Button.MinWidth}"` = 160) und `HM12_ValueInput.Styles.xaml` (dito). In Spalten unter 160 px (+ Beschriftung) wird das Feld per Layout-Clip abgeschnitten.
- **Lösungsvorschlag:** Mindestbreite im Feld auf 96 bis 112 px senken (Ziffern 28 px: „2.800 1/min“ passt in ca. 140 px), Einheit optional in eine eigene Zeile oder kleinere Schrift bei Platzmangel; für die Tabellenseiten (HS-22, 39) die Spaltenbreiten aus den Inhalten ableiten (Auto/MinWidth statt Stern) und Kopfzeilen an dieselbe `SharedSizeGroup` binden (siehe B-22, B-39).

### S-04 Berechtigungssymbol überlagert Beschriftung (mittel)
- **Beschreibung:** Das Schloss/Schlüssel-Symbol sitzt oben rechts im Button und überdeckt Text: „Start Kalibrierun-“ (HS-27), „Regulierung“ beider Schaltflächen (HS-23), „Eichdosierung“ (HS-11, 19), „Zähler löschen“ (HS-13), „Dosierer Auslösen manuell“.
- **Ursache:** `Controls/HM07_ActionButton.Styles.xaml` (`KeyIcon`/`LockIcon` als Overlay im selben Grid, rechts oben, ohne reservierten Platz). Bei Feldern (`HM12`) sitzt es in eigener Spalte, bei Tasten nicht.
- **Lösung:** Rechts 36 px Innenabstand reservieren, wenn `RequiresPermission` gesetzt ist (Spalte Auto neben dem Text), Symbol mittig statt oben-rechts.

### S-05 Anzeige- und Eingabefelder in einer Spalte sitzen versetzt (mittel)
- **Beschreibung:** Anzeigefelder (nur lesen, ohne Schloss) liegen ca. 16 px rechts von den Eingabefeldern in derselben Zeilengruppe, die rechten Kanten fluchten nicht (HS-05 „Durchmesser Rolle“ und „Aktueller Bremsdruck“, HS-09 „Aktueller Druck“, HS-03 „Maximum“ mit Schloss breiter als die Felder darunter, HS-02 Historie 7/8, HS-06 „Maschinenwinkel“ 80 px hoch).
- **Ursache:** `HM12_ValueInput.Styles.xaml` reserviert eine zusätzliche Spalte (Zähler/Schloss) mit Rand `Inset.S`, `HM11` nicht; Feldbreite hängt vom Inhalt (Schloss, Einheit) ab statt von einer gemeinsamen Spaltenbreite.
- **Lösung:** Feldbreite fest je Gruppe (`SharedSizeGroup`), Schloss als Overlay innerhalb der Feldfläche in beiden Controls gleich behandeln, gleiche Randabstände in HM11 und HM12.

### S-06 Logo fehlt, Kopfzeile ungünstig aufgeteilt (mittel)
- **Beschreibung:** Statt des Logos steht der Text „APA-TEC“; die Spalte „Logo“ (12\*) ist größtenteils leer, während die Meldezeile (13\*) den Text kürzt („Sicherung 4F24 Auslaufband ausgel… + 2“) und die Betriebsart-Spalte (6\*) viel Platz hat.
- **Ursache:** `Controls/HM02_HeaderBar.Styles.xaml` Spalten `Size.Header.Col.*` 12\* : 13\* : 6\* : 4\*; `LogoSource` wird nirgends gesetzt (OP-66, A-78: Logo-Asset fehlt).
- **Lösung:** Logo-Grafik je Thema (SVG/PNG) unter `src/ApaTec.Hmi/Resources` beschaffen und in `MainWindow.xaml` an `LogoSource` binden (Dunkel: helle Variante). Logo-Spalte auf `Auto` (max. ca. 340 px) und Meldezeile auf `*`, damit die Meldung vollständig lesbar ist; vollständigen Text im Meldungs-Pop-up belassen. Schweregrad hoch, sobald das Asset vorliegt, solange Platzhalter: mittel (bekannter offener Punkt).

### S-07 Rahmenelemente ohne Randabstand: Kennzahlkacheln und Uhr kleben am Fensterrand (mittel)
- **Beschreibung:** Die Kachel „Maschinenwinkel“ (und rechts die Uhr) reichen ohne Außenrand bis zum Fensterrand und sind dort teils beschnitten (HS-04, 05, 07, 09, 12, 25, 34 u. a. sichtbar am fehlenden rechten Rahmen); die beiden Kennzahlkacheln haben keinen Abstand zueinander.
- **Ursache:** `MainWindow.xaml` Brotkrümel-Grid, Kacheln `TileSize="Frame"` ohne Margin; Uhr: `HM02_HeaderBar` `Inset.S` nur 8 px.
- **Lösung:** Margin `Space.M` rechts und zwischen den Kacheln, Kachelhöhe an Brotkrümelhöhe angleichen.

### S-08 Aufnahmeformat 1920 × 1061 und schwarze Streifen (niedrig, Aufnahme/Fenster)
- **Beschreibung:** Alle PNG haben 1061 statt 1080 Zeilen; in etwa der Hälfte der Aufnahmen schwarzer Streifen rechts und unten (HS-02, 03, 04, 07, 09, 24, 25, 33 bis 36, 39 sichtbar).
- **Vermutete Ursache:** `MainWindow.xaml` hat `Width/Height` 1080 als Fenstermaß (inklusive Rahmen und Titelleiste) und keinen Kiosk-Modus (`WindowStyle`, `WindowState`, `ResizeMode` nicht gesetzt); `src/tools/windows/Capture-Pages.ps1` skaliert das Fenster auf Client-Maß und warnt bei Abweichung; der Streifen ist vermutlich ein `PrintWindow`-Randartefakt.
- **Lösung:** Für den Betrieb `WindowStyle="None"`, `WindowState="Maximized"`, `ResizeMode="NoResize"` (Kiosk), Client-Fläche dann exakt Bildschirmgröße; Capture-Skript auf Client 1920 × 1080 prüfen (SetWindowPos mit `extraH`), Aufnahmen nach der Korrektur neu erzeugen und die Pixelvergleiche wiederholen.

### S-09 Scrollleisten ohne Themen-Stil, im Dunkel hell (mittel)
- **Beschreibung:** Native Scrollleisten: HS-18 und HS-28 im Dunkel mit hellem Schieber bzw. weißer horizontaler Leiste; im Hell klein und schmal (ca. 16 px), nicht touchtauglich.
- **Ursache:** Kein globaler `ScrollBar`-Stil in `Themes/Controls.Base.xaml` oder den Theme-Dateien (nur lokal `HM25.ScrollBar` in `HM25_MessageList.Styles.xaml`).
- **Lösung:** Impliziten `ScrollBar`-Stil (Schieber 24 bis 32 px, Farben `Brush.Border.Control` / `Brush.Surface.Sunken`) in `Controls.Base.xaml` anlegen und den HM25-Stil dorthin heben; `PanningMode` für Touch an allen Scrollbereichen setzen.

### S-10 Teilweise sichtbare letzte Zeile und uneinheitliche Scroll-/Pager-Muster (niedrig)
- **Beschreibung:** Letzte Zeile angeschnitten in HS-26 (Nr. 49), HS-37 (Zeile 10), HS-38 (Zeile 12), HS-18/21 (Tabellenzeile 7); HS-18 hat Scrollleiste, HS-21 (gleiche Tabelle) nicht, HS-22 hat Pfeiltasten, HS-26 einen Pager „1 von 2“.
- **Ursache:** Seitengröße/Zeilenzahl nicht aus der Höhe abgeleitet; `HM23_CamTable`, `HM25_MessageList` blenden die Scrollleiste aus (`VerticalScrollBarVisibility="Hidden"`).
- **Lösung:** Entweder ganzzahlige Zeilenzahl je Seite (Zeilenhöhe als Token) oder sichtbare Scrollleiste mit Touch-Schieber; ein einheitliches Muster (Pfeiltasten oben/unten 64 px plus „x–y von n“) festlegen.

### S-11 Blätter-Tasten „«“ und „»“ ohne Symbol, deaktivierter Zustand wirkt leer (niedrig)
- **Beschreibung:** Die Funktionsleisten-Tasten zum Blättern (HS-11, 12, 25, 26, 27, 32, 34) zeigen nur winzige Zeichen „«“ „»“, die erste Taste ist im Grenzfall weiß mit gestrichelter Kontur und wirkt wie ein leeres Feld.
- **Ursache:** `Controls/HM19_PagerButtons.Styles.xaml` verwendet Textzeichen statt Symbolen; Deaktiviert-Stil `Brush.Button.Disabled` = weiß (hell).
- **Lösung:** Chevron-Symbole 32 px plus Wort („Zurück“ / „Weiter“ oder „Dosierer 1/2“), deaktiviert mit ausgegrautem Symbol statt weißer Fläche.

### S-12 Diagrammbeschriftung: überlappende Datenlabels (niedrig)
- **Beschreibung:** HS-15 Datenwerte liegen auf der Linie und überdecken einander („235,0“, „235,5“), „−0“ als letzte Achsenmarke, Einheit „g“ kollidiert mit „237,0“; HS-29 Werte überlappen („624591“, „450447“, „226208“) und 24 Nullen als Beschriftung.
- **Ursache:** `Controls/HM26_Chart.Styles.xaml`/`HM26_ChartLayout.cs` ohne Kollisionsvermeidung.
- **Lösung:** Labels nur bei jedem 2. Punkt oder an Extremwerten, Halo (Hintergrundkontur) hinter Labels, Achsenmarke „0“ statt „−0“, Einheit oberhalb der Achse, Nullwerte ohne Label.

### S-13 Hinweisboxen: Wortmarker „Info“/„Warnung“ in großer Schrift am Rand (niedrig)
- **Beschreibung:** Rechts in jeder Hinweisbox steht „Info“ bzw. „Warnung“ in fetter 28-px-Schrift, konkurriert mit dem Text; in schmalen Boxen bricht der Text dadurch auf 4 bis 5 Zeilen um (HS-07, 11, 16, 19, 18).
- **Ursache:** `Controls/HM27_NoticeBox.Styles.xaml` (zweiter Kanal als großes Wort rechts).
- **Lösung:** Wort in `Caption`-Schrift unter das Symbol setzen oder nur Symbol plus Tooltip; Text über die volle Breite.

## 3 Ergebnis je Seite HS-01 bis HS-43

Legende: **ok** = keine relevanten Abweichungen; **Abweichung** = lesbar und bedienbar, aber Layout oder Details abweichend; **Fehler** = Inhalt abgeschnitten/unlesbar oder Bedienelemente fehlen. Dunkel „(abgeleitet)“ = nicht einzeln angesehen.

| HS | Hell | Dunkel | Befund-IDs / Kurzbefund |
|---|---|---|---|
| HS-01 Produktion | Fehler | Fehler (gesehen) | S-01, S-02, S-06, S-07; **B-01** Tastenkacheln brechen mitten im Wort um, Symbol überlagert Text („Aut oma ⓘ Teilweise tik“); **B-02** „Schnell“-Taste der Geschwindigkeit-Gruppe fehlt (abgeschnitten), „Letzte Produktion“ halb sichtbar, Versorgung ohne „Folgemaschine“, Umschalterzeile „Produktüberwachung“ links abgeschnitten (Prüfpunkt P21 nicht erfüllt); **B-03** Bereiche gegenüber Design: Rezeptanwahl und Zustandstasten stimmen, Logo fehlt |
| HS-02 Produktionszähler | Abweichung | Abweichung (gesehen) | **B-04** Pop-up füllt die gesamte Höhe bis zur Fensterkante, „Schließen“ ohne unteren Rand; Zeilen 7/8 haben schmalere Felder als 1 bis 6 (S-05) |
| HS-03 Maschinengeschwindigkeit | ok | ok (abgeleitet) | S-05 gering (Feld „Maximum“ mit Schloss breiter als darunter); Kontrast und Touch ok |
| HS-04 Einstellungen | ok | ok (gesehen) | Raster 4 + 2 × 2 Spalten wie Design, Kachelplätze „Reserviert“, „Geräte“ nicht verfügbar entsprechen Design; S-06, S-07 (Rahmen) |
| HS-05 Zuführung Papier | Abweichung | Abweichung (abgeleitet) | **B-05** Gruppen Klebestelle und Kupplung unten ohne Rand abgeschnitten, Warnbox klebt am Rand (S-01); versetzte Felder (S-05) |
| HS-06 Zuführung Karton | Abweichung | Abweichung (gesehen) | **B-06** „Anwahl Spülen“ nur 1 von 2 Reihen sichtbar (S-01); **B-07** Leimspuren-Grafik stark vereinfacht gegenüber Design (kein Kartonzuschnitt mit Klappen, Leimstriche, Trennlinie schneidet die senkrechte Leimspur, Eingabefelder verdecken die Spur); **B-08** „Maschinenwinkel“-Feld 80 px hoch, unlogisch größer als die übrigen (S-05) |
| HS-07 Heißleim Nordson | Fehler | Fehler (gesehen) | S-02, S-01; **B-09** Taste „Füllsystem“ ist unlesbar (buchstabenweise umbrochen), „Zeitschaltuhr“ zweizeilig; **B-10** „Vertei-ler“, „Pistol-e 1“, „Schla-uch 1“ umbrochen; Füllstandsbalken mit Wertetikett über der Füllung (ok), Absenkung-Zeile nicht ausgerichtet |
| HS-08 Heißleim Parameter | Abweichung | Abweichung (gesehen) | **B-11** Spaltenköpfe „Soll:“ „Ist:“ „Status:“ stehen nicht über den zugehörigen Feldern (S-03); **B-12** Statusschaltfläche zeigt Zustand und Aktion zugleich („✓ Ausschalten“ beim Zustand Ein) mehrdeutig |
| HS-09 Heißleim Druck | ok | ok (abgeleitet) | S-05 (Anzeigefeld „Aktueller Druck“ um 16 px versetzt); viel Leerraum unten, unkritisch |
| HS-10 Zeitschaltuhr | Abweichung | Abweichung (gesehen) | **B-13** Eintrag „12:00 abs… / 13:00 aufl…“ (Absenken/Aufheizen) abgeschnitten und schmaler als die übrigen Einträge, Wochentagsspalten sonst gut |
| HS-11 Hauptdosierer 1 und 2 | Abweichung | Abweichung (abgeleitet) | S-01, S-04, S-11; **B-14** Hinweisbox „Ablauf Eichdosierung“ links unten abgeschnitten, Text bricht mitten im Satz ab; Pager-Tasten leer/klein; HM-20-Detail weiter offen |
| HS-12 Motorparameter (Hauptdosierer) | ok | ok (abgeleitet) | S-11 (Pager klein); sonst Layout wie Beschreibung, 4:4:4 |
| HS-13 Kontrollwaage | Fehler | Fehler (gesehen) | S-01, S-03, S-04; **B-15** Statistik-, Wägeparameter- und Zähler-Zeilen stark beschnitten (nur obere Hälfte der Werte sichtbar, „Automatischer …“ ohne Fortsetzung), Raster-Prüfpunkt P23 nicht erfüllt; Netto/Brutto/Live-Einheit „g“ klein und abgeschnitten |
| HS-14 Einzelgewichte | Fehler | Fehler (abgeleitet) | S-01; **B-16** Statistikkacheln oben beschnitten („S 0,6“ halb), Taste „Start“ doppelt (Seite und Funktionsleiste) neben „Messmodus: Fortlaufend“; **B-17** markierte Zelle (234,8) verschiebt Wert und „gut“ nach unten; Zellabstand 8 px statt 16 px |
| HS-15 Trend | Abweichung | Abweichung (gesehen) | S-12 |
| HS-16 Schließmaschine | Fehler | Fehler (abgeleitet) | S-02, S-03; **B-18** Block Kopfleim zerfallen: Beschriftungen umbrochen, Felder rechts abgeschnitten (ohne Einheit und Schloss), schwebendes Symbol, Feld „Dauer“ versetzt; Hinweisbox 5 Zeilen |
| HS-17 Motorparameter (Schließmaschine) | ok | ok (abgeleitet) | Leerraum unten, sonst wie HS-12 |
| HS-18 Gewichtskorrektur (Schließmaschine) | Abweichung | Abweichung (gesehen) | S-09, S-10; **B-19** rechte Hinweisspalte unten abgeschnitten, ohne Scrollleiste, Tabelle mit; Spaltenköpfe SOLL/IST nicht über den Feldern |
| HS-19 Nachdosierer | Fehler | Fehler (abgeleitet) | S-01, S-13; **B-20** linke Spalte: „Eichdosierung“-Feld abgeschnitten (Bedienwert fehlt), Hinweis „Max. Nachgabe“ belegt ca. 200 px; rechte Spalte: Hinweis „Ablauf Eichdosierung“ abgeschnitten; keine Scrollmöglichkeit |
| HS-20 Motorparameter (Nachdosierer) | ok | ok (abgeleitet) | wie HS-12/17 |
| HS-21 Gewichtskorrektur | Fehler | Fehler (abgeleitet) | S-01, S-10; **B-21** Tabelle nach ca. 5,5 Zeilen abgeschnitten, ca. 12 von 20 Wertepaaren fehlen, keine Scrollleiste (anders als HS-18); P18 nicht erfüllt |
| HS-22 Heizungen | Abweichung | Abweichung (gesehen) | S-03, S-10; **B-22** Spaltenköpfe (Heizung, Meldung, Soll, Ist, State, Out) nicht an den Spalten ausgerichtet, „State“ und „Out“ nicht übersetzt (Englisch), „Ist“-Feld ohne rechte Kante; nur 5 Zeilen sichtbar mit Pfeiltasten |
| HS-23 Regulierung | Abweichung | Abweichung (abgeleitet) | S-04; **B-23** Schaltflächen „◁ Regulierung“ / „▷ Regulierung“: Schloss überlagert Beschriftung; Zähler „0 von 10“ klein und nicht an Feldern ausgerichtet |
| HS-24 Bildschirm reinigen | ok | ok (abgeleitet) | Vollbildseite wie vorgesehen, schwarzer Streifen (S-08) |
| HS-25 Nocken | Abweichung | Abweichung (abgeleitet) | S-11; **B-24** keine Gruppierung (HM-15), lose Felder, „Position“-Feld und „Werte schreiben“ bis zum Rand und größer als übrige Felder, „Anfang/Ende“ fett, „Typ“ und „Geber“ ohne Zusammenhang; unübersichtlich |
| HS-26 Nockenübersicht | Abweichung | Abweichung (abgeleitet) | S-10, S-11; **B-25** Zeile 49 angeschnitten, Spaltenköpfe Start/Ende/Status rechts gedrängt, Bezeichnung sehr breit, großer Leerraum zwischen Zeilentext und Werten |
| HS-27 Waagen Kalibrieren | Abweichung | Abweichung (abgeleitet) | S-04, S-11; **B-26** „Start Kalibrierung“ vom Schloss abgeschnitten, drei Tasten in einer Reihe mit gestricheltem Deaktiviert-Stil, Fläche unten links leer; Listenfeld „Ablauf Kalibrierung“ mit Scrollleiste ok |
| HS-28 Packungsregister | Abweichung | Abweichung (gesehen) | S-09; **B-27** Grafik breiter als der Bereich (horizontale Scrollleiste, Packung 43 und folgende abgeschnitten), keine Anpassung an die Breite (Viewbox); Beschriftung „vorhanden“ stößt an den Kachelrand |
| HS-29 Produktionsstatistik | Abweichung | Abweichung (abgeleitet) | S-12; **B-28** überlappende Werte, Nullwerte als Beschriftung; Datumswähler gut |
| HS-30 Handbetrieb Auswahl | ok | ok (abgeleitet) | 4 × 4 Raster, „Reserviert“ gestrichelt, Leerraum unten |
| HS-31 Handbetrieb | Abweichung | Abweichung (gesehen) | S-02; **B-29** „Endla-ge“ umbrochen, „Position:“ steht weit links vom zugehörigen Wert, mittlerer Bereich locker und unstrukturiert, „Freigabe/Erteilt“ eng |
| HS-32 Geber setzen | ok | ok (abgeleitet) | Hinweisboxen unterschiedlich breit (Info schmaler als Warnung), unkritisch |
| HS-33 EA-Übersicht | ok | ok (abgeleitet) | wie HS-30 |
| HS-34 EA-Anzeige | ok | ok (abgeleitet) | S-11; Statussymbol links weit vom Namen getrennt (Leserichtung), Zustandswort „Aus“ vorhanden |
| HS-35 Systemeinstellungen | ok | ok (abgeleitet) | Warndreieck und Schloss nur als kleine Symbole in den Kachelecken, ohne Wort (zweiter Kanal vorhanden: Schloss, Dreieck) |
| HS-36 Service | ok | ok (gesehen) | Betriebsart „Service“ als Warnfläche mit Symbol; Filterfeld „---“ leer; Listenschieber ohne Kontur |
| HS-37 Meldearchiv | Abweichung | Abweichung (gesehen) | S-10; **B-30** Zeile 10 angeschnitten, Pfeiltasten gruppenweise; sonst Klassen mit Symbol und Wort gut |
| HS-38 Meldeanzeige | Abweichung | Abweichung (abgeleitet) | S-10; **B-31** Brotkrümel nur „Meldungen“, ca. 70 px Leerraum über dem Tabellenkopf, Zeile 12 angeschnitten |
| HS-39 System- und Antriebsinfos | Fehler | Fehler (gesehen) | S-01, S-02, S-03; **B-32** Servomotoren-Tabelle: vier Wertespalten leer/abgeschnitten („0,(“), Status „Motorschutz ausge…“ gekürzt, keine Spaltenköpfe; IPC „Aktuel-l“, „HMI Applikation Build“ abgeschnitten |
| HS-40 Zuführungen | ok | ok (abgeleitet) | drei Kacheln, viel Leerraum |
| HS-41 Dosierer-Übersicht | Fehler | Fehler (gesehen) | S-01, S-03; **B-33** Titelzeile: erste Zeile leer, „Sollgewicht KW: 235 gLetztes Gewicht KW: 238 g“ ohne Trenner zusammengeklebt (Design: „| “); **B-34** Pfeilschaltfläche im Kartenkopf überlappt das Soll-Eingabefeld; **B-35** Auslastung, „Manuell“ und „Entleeren“ fehlen (abgeschnitten), im Design sichtbar; Nachdosierer-Karte hat große Lücke in der Mitte, Hauptdosierer-Karten ohne diese |
| HS-42 Waagen | ok | ok (abgeleitet) | „Endkontrollwaage nicht verfügbar“ gestrichelt mit Symbol und Wort, in Ordnung |
| HS-43 Schichtplan | ok | ok (abgeleitet) | Platzhalter wie in der Seitenbeschreibung („noch nicht definiert“) |

> Hinweis zur Nummerierung: Die Tabelle nennt B-Befunde fortlaufend je Seite (B-01 bis B-35, mit Lücken bei Seiten, die nur systemische Befunde haben). Wo derselbe Mangel auf mehreren Seiten auftritt, steht die systemische ID.

## 4 Touch-Ziele und Zusatzbeobachtungen

- **Touch-Ziele:** Seitenleiste, Brotkrümel, Funktionsleiste (ca. 60 px hoch, ≥ 48 px, unter dem Sollmaß 64 px), Kacheln, Umschalter (96 × 48), Eingabefelder (64 px), Jog-Tasten (groß) erfüllen 48 px. Schwach: Zellabstand in HS-14 (8 px statt 16 px, Zellhöhe ca. 50 px), Listenzeilen in HS-26/34 (Abstand ca. 10 px), Schloss/Schlüsselsymbole (24 px, nur Anzeige), Scrollleisten (S-09), Blätter-Tasten mit sehr kleinem Zeichen (S-11).
- **Zweiter Kanal:** durchgängig vorhanden (Symbol plus Wort bei Ein/Aus, Hinweisklassen, Packungsstatus, Meldungsklassen); Abweichung nur dort, wo Wort abgeschnitten ist (HS-39 „Motorschutz ausge…“).
- **Dunkel-Thema:** Kontraste, Statusflächen (Hinweis gelb, Störung rot, Info blau) und Eingabefelder lesbar; Fehler nur S-09 (Scrollleisten); Pop-up-Scrim (HS-02) wirkt im Dunkel sehr schwach, Pop-up bleibt durch Kontur erkennbar.
- **Abgleich mit Design (nur Look und Aufbau, nicht final):** Das neue HMI ist bewusst flacher und ohne 3D-Tasten und Farbflächen; Aufbau HS-01 (4 Gruppen oben, 2 unten), HS-04 (Raster 1 + 2 × 4), HS-06, HS-07 und HS-41 entspricht dem Design, abgesehen von den Abschneidebefunden.

## 5 Priorisierte Empfehlung

1. S-01 (Inhaltshöhe, Scroll-Sicherheitsnetz) vor allen anderen Arbeiten, da es etwa ein Drittel der Seiten betrifft.
2. S-02 (HM08-Tile und Beschriftungsspalten) behebt auf einen Schlag HS-01, 07, 16, 31, 39.
3. S-03 (Feldmindestbreite) und B-32/B-35/B-18/B-15 danach seitenweise nachziehen.
4. Danach S-08 (Kioskfenster, Neuaufnahme), Aufnahmen aus `Capture-Pages.ps1` ersetzen, M3-Matrix (`M3_Abnahmematrix.md`) mit den hier bestätigten Befunden ausfüllen.

## 6 Behebungsstand (Code, Windows-Neuaufnahme steht aus)

Stand 2026-11-06, Branch `claude/nice-curie-u22ycb`. „behoben (Code, visuell neu zu prüfen)“ heißt: Änderung umgesetzt, Build 0 Fehler/0 Warnungen, `check_design.py`, `check_modules.py`, `check_pages.py`, `check_icons.py` bestanden; ob das Ergebnis auf dem Bildschirm stimmt, ist nur unter Windows prüfbar. Annahmen: [Annahmen.md](../00_Plan/Annahmen.md) A-101. Die Prüfpunkte „Passt ohne Scrollen“ (HS-01-P21, HS-13-P23, HS-16-P20, HS-19-P21, HS-21-P18, HS-41-P19) und die Höhenbilanzen sind neu zu messen.

### 6.1 Systemische Befunde

| ID | Status | Maßnahme / Grund |
|---|---|---|
| S-01 | behoben (Code, visuell neu zu prüfen) | Rahmen mit festen Höhen 88/80/80 px, Außenrand 16, Inhalt `*` im `ScrollViewer` mit Scrollleiste; Listen- und Diagrammseiten (`FillsContentArea`) behalten die begrenzte Höhe; Dichte: `Inset.Panel` 12, Caption-Beschriftungen, 48-px-Zeilen in HM-22. Ob bei 1061/1080 nichts mehr scrollen muss, zeigt erst die Neuaufnahme (HS-01, 13, 41 sind sehr dicht). |
| S-02 | behoben (Code, visuell neu zu prüfen) | HM-08 Kachel zweizeilig, Schalter ohne Zustandssymbol, Beschriftungen in Caption; HM-11/12 mit `Size.Label.MinWidth` und `FieldLabelPlacement`; HM-09 Caption; HS-07, 31, 39 angepasst. Ein Wort, das breiter als die Spalte ist, kann weiterhin brechen (WPF-Verhalten), das wird bei der Neuaufnahme geprüft. |
| S-03 | behoben (Code, visuell neu zu prüfen) | `Size.Field.MinWidth` 112 statt 160 (HM-11, HM-12); HM-34 und HM-24 neu aufgebaut. Die Tabellen HS-22 und HS-39 sind zusätzlich über B-22 und B-32 behandelt. |
| S-04 | behoben (Code, visuell neu zu prüfen) | HM-07 reserviert `Inset.Button.Permission`, Symbol rechts mittig. Gleiche Behandlung in HM-08 (Schloss neben der Beschriftung) war schon vorhanden. |
| S-05 | behoben (Code, visuell neu zu prüfen) | HM-12 reserviert die Zählerspalte nur bei Zähler; gemeinsame Mindestbreite 112 in HM-11 und HM-12. Eine `SharedSizeGroup` je Gruppe wurde nicht eingeführt (würde Seiten ändern); bei sehr langen Werten können Breiten weiter abweichen. |
| S-06 | offen | Es gibt kein Logo-Asset (OP-66, A-78); ein Logo wird nicht erfunden. Der Teil „Kopfzeile ungünstig aufgeteilt“ ist behoben (Spalten Auto : * : Auto : Auto, Meldezeile erhält den Rest, `LogoSource` mit `Size.Logo.MaxWidth`). Übergabe: Logo-Dateien je Thema bereitstellen und `LogoSource` im MainWindow setzen. |
| S-07 | behoben (Code, visuell neu zu prüfen) | Kennzahlkacheln `Inset.Frame.Tile` / `.End`, Uhr mit 16 px Außenrand rechts. |
| S-08 | behoben (Code, visuell neu zu prüfen) | Skript `Capture-Pages.ps1`: Titelleiste und Rahmen werden für die Aufnahme entfernt, Fenster exakt 1920 × 1080 an 0,0, Nachregelung und Warnung. Die Anwendung selbst bleibt ein Fenster mit Rahmen; ein Kioskfenster (`WindowStyle="None"`) ist nicht Teil dieses Pakets und bleibt als Betriebsentscheidung offen. Aufnahmen müssen unter Windows neu erzeugt werden. |
| S-09 | behoben (Code, visuell neu zu prüfen) | Impliziter `ScrollBar`-Stil in `Controls.Base.xaml` (32 px, Themenfarben), HM-25-Sonderstil entfernt, HM-23 mit sichtbarer Leiste. `PanningMode` ist an den Scrollbereichen des Rahmens und der Pop-ups gesetzt. |
| S-10 | offen | teilweise: HM-23 zeigt jetzt eine sichtbare Scrollleiste; ganzzahlige Zeilenzahl je Seite bzw. ein einheitliches Pager-Muster (HM-23, HM-25, HM-22) ist eine Layoutentscheidung und wurde nicht umgesetzt. |
| S-11 | behoben (Code, visuell neu zu prüfen) | Blättertasten waren bereits HM-19-Pfeile mit `Icon.Chevron`; Symbole auf `Size.Icon.L` (48) vergrößert, Innenabstand verkleinert. Das weiße Feld im Grenzfall ist der Deaktiviert-Zustand (`Brush.Button.Disabled` nach Designsystem 10.1, gestrichelte Kontur) und wurde nicht geändert; Wort „Zurück“/„Weiter“ nicht ergänzt. |
| S-12 | behoben (Code, visuell neu zu prüfen) | Achsenmarke „0“ statt „−0“, Datenbeschriftung ausgedünnt (Abstand nach Spaltenbreite, vom letzten Wert aus), Nullbalken ohne Beschriftung, Hintergrund hinter Beschriftungen; Einheit „g“ über der Achse nicht geändert. |
| S-13 | behoben (Code, visuell neu zu prüfen) | HM-27: Wortmarker „Info“/„Warnung“ in Caption unter dem Symbol, Text über die volle Restbreite. |

### 6.2 Seitenspezifische Befunde

| ID | Status | Maßnahme / Grund |
|---|---|---|
| B-01 | behoben (Code, visuell neu zu prüfen) | S-02 (HM-08 Kachel). |
| B-02 | behoben (Code, visuell neu zu prüfen) | S-01 (Scrollbereich, Dichte); Prüfpunkt HS-01-P21 neu messen. |
| B-03 | offen | Logo siehe S-06; Aufbau stimmt mit dem Design überein. |
| B-04 | behoben (Code, visuell neu zu prüfen) | HM-14: Rand um das Pop-up, Inhalt scrollt bei knapper Höhe. |
| B-05 | behoben (Code, visuell neu zu prüfen) | S-01. |
| B-06 | behoben (Code, visuell neu zu prüfen) | S-01 (zweite Reihe „Anwahl Spülen“ per Scroll erreichbar). |
| B-07 | offen | Die Leimspuren-Grafik (HM-31) ist eine Gestaltungsentscheidung (Kartonzuschnitt, Klappen); Design ist nicht final, keine Annahme ohne Rückfrage. |
| B-08 | offen | Ursache der 80 px Höhe des Maschinenwinkel-Felds (HM-11, Presentation/Emphasis) ist ohne Rendering nicht eindeutig; bei der Neuaufnahme prüfen. |
| B-09 | behoben (Code, visuell neu zu prüfen) | HS-07: Tasten als Kacheln (`HotGlue.Switch` mit `ButtonSize=Tile`), Füllsystem und Manuell untereinander. |
| B-10 | behoben (Code, visuell neu zu prüfen) | HS-07: Temperaturen in einer Spalte, Beschriftungsspalte mindestens 120 px. |
| B-11 | behoben (Code, visuell neu zu prüfen) | HS-08: Kopf mit Reservespalte in Breite der Scrollleiste (Leiste immer sichtbar), damit die Köpfe über den Feldern stehen. |
| B-12 | behoben (Code, visuell neu zu prüfen) | HM-28: Zonentaste zeigt „Ein“/„Aus“ statt der Aktion. |
| B-13 | offen | Eintrag „12:00 abs… / 13:00 aufl…“ (HM-29) nicht untersucht; der Bereich scrollt jetzt selbst, die Kürzung der Einträge bleibt zu prüfen. |
| B-14 | behoben (Code, visuell neu zu prüfen) | S-01, S-13; HM-20-Detail bleibt separate Entscheidung (Matrix-Befund B-01). |
| B-15 | behoben (Code, visuell neu zu prüfen) | S-01 (Seite scrollt), S-03, S-04. Zeilenproportionen 4 : 3 : 3 : 4,5 : 3 bleiben, die Höhe richtet sich nach dem Inhalt (Prüfpunkt HS-13-P23 neu messen). |
| B-16 | behoben (Code, visuell neu zu prüfen) | HM-37 mit `ShowHeader`; HS-14 ohne doppelte Tasten im Raster. |
| B-17 | behoben (Code, visuell neu zu prüfen) | Zelle des letzten Werts mit reduziertem Innenabstand (`Inset.Hair`), kein Versatz. Der Zellabstand (4 px je Seite) bleibt. |
| B-18 | behoben (Code, visuell neu zu prüfen) | HS-16: Kopfleim mit Auto-Spalte für das Piktogramm, HM-24 mit Auto-Spalten, Dauer in derselben Spalte wie Anfang/Ende. |
| B-19 | behoben (Code, visuell neu zu prüfen) | S-01 (rechte Spalte scrollt mit); die Ausrichtung SOLL/IST-Köpfe in HM-22 nicht geändert. |
| B-20 | behoben (Code, visuell neu zu prüfen) | S-01, S-04, S-13. |
| B-21 | behoben (Code, visuell neu zu prüfen) | S-01 plus 48-px-Zeilen in HM-22; alle 20 Wertepaare per Scroll erreichbar (Prüfpunkt HS-21-P18 neu messen). |
| B-22 | behoben (Code, visuell neu zu prüfen) | Köpfe „Zustand“ / „Ausgang“ (übersetzt), Felder 112 px; die Ausrichtung der Köpfe an den Spalten ist unverändert (gleiches Spaltenraster) und visuell zu prüfen. |
| B-23 | offen | teilweise: S-04 behoben (Schloss überlagert nicht mehr); Zähler „0 von 10“ klein und nicht an Feldern ausgerichtet (HM-35) nicht geändert. |
| B-24 | offen | teilweise: Beschriftung „Anfang/Ende“ nicht mehr fett (HM-24 Body); Gruppierung mit HM-15, Typ/Geber-Zusammenhang und Feldgrößen sind Layoutentscheidungen. |
| B-25 | offen | Spaltenköpfe und Leerraum in HM-23 nicht geändert; sichtbare Scrollleiste statt abgeschnittener Zeile 49 (siehe S-10). |
| B-26 | behoben (Code, visuell neu zu prüfen) | S-04 (Schloss), Scrollleiste; Deaktiviert-Stil ist Designsystem. Leere Fläche unten links nicht gestaltet. |
| B-27 | offen | Verkleinern der Grafik auf die Breite (Viewbox) würde die Touch-Ziele der Stationen unter 48 px bringen; derzeit horizontaler Bildlauf mit neuer Scrollleiste. Entscheidung nötig. |
| B-28 | behoben (Code, visuell neu zu prüfen) | S-12. |
| B-29 | behoben (Code, visuell neu zu prüfen) | HM-09 Beschriftungen in Caption, „Position“ mit Beschriftung über dem Feld. |
| B-30 | offen | Zeile 10 angeschnitten (S-10), Pfeiltasten gruppenweise: Layoutentscheidung. |
| B-31 | offen | Brotkrümel „Meldungen“ und 70 px Leerraum über dem Tabellenkopf (HS-38) nicht untersucht. |
| B-32 | behoben (Code, visuell neu zu prüfen) | HM-34 zweizeilig (Antrieb und Meldung oben, vier Felder mit Beschriftung darüber); IPC „Aktuell“/„Max“ mit Beschriftung über dem Feld. |
| B-33 | behoben (Code, visuell neu zu prüfen) | HM-17: Trenner über `PreviousData`, leere Titelzeile entfällt. |
| B-34 | behoben (Code, visuell neu zu prüfen) | HM-20: Kartenkopf in Höhe der Detailtaste, Detailtaste 64 px breit. |
| B-35 | behoben (Code, visuell neu zu prüfen) | S-01 (Scroll, kompakte Panel-Innenabstände); Auslastung, Manuell, Entleeren per Scroll erreichbar. Die Lücke in der Nachdosierer-Karte (reservierte Hinweisbox, `Hidden`) bleibt. |

### 6.3 Übergabe an die lokale Windows-Session

1. `Build-And-Run.ps1 -NoRun`, danach `Capture-Pages.ps1` (neues Verfahren, Ziel 1920 × 1080 ohne schwarzen Rand) und die Aufnahmen gegen diesen Bericht neu sichten.
2. Offene Befunde: S-06/B-03 (Logo-Asset), S-10, B-07, B-08, B-13, B-23, B-24, B-25, B-27, B-30, B-31.
3. Prüfen, ob die Seiten ohne `FillsContentArea` bei Client-Höhe 1080 noch scrollen (HS-01, 13, 19, 41 zuerst); falls ja, Dichte weiter senken oder bewusst scrollen lassen.
