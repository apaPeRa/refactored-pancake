# Designsystem

Verbindliche Gestaltungsvorgaben für das neue HMI (WPF, .NET 8, 1920 × 1080, Touch). Grundlage: `Agent.md` Abschnitt 6, die [Design-Dokumentation](../01_Design-Analyse/Design-Dokumentation.md) und die Module [DM-01](../01_Design-Analyse/Module/DM-01_Benutzerkennung.md) bis [DM-22](../01_Design-Analyse/Module/DM-22_Leimspuren-Grafik.md). Der PowerPoint-Entwurf ist Orientierung für Aufbau und Navigation, nicht für Farben, Fasen und Maße (A-04, A-09). Abweichungen sind in Abschnitt 12 begründet.

Gestaltungsgrundsätze (ISA-101):

1. Ruhiger, neutraler Grund. Der Normalzustand ist grau und unauffällig.
2. **Farbe nur für Status und Alarm** (Ok, Warnung, Fehler, Info, Inaktiv). Keine Marken- oder Zierfarben, keine Farbe zur Gruppierung.
3. Kein Zustand nur über Farbe: jeder Zustand hat einen zweiten Kanal (Symbol, Text, Form, Rahmen).
4. Große Touch-Ziele (mindestens 48 px, Standard 64 px).
5. Flach: keine 3D-Fasen, keine Verläufe, keine Schatten als Informationsträger.
6. Alle Farben, Schriften und Maße kommen aus zentralen `ResourceDictionary`-Dateien (Abschnitt 10). Seiten und Module enthalten keine Literalwerte.

Alle Kontrastverhältnisse sind nach WCAG 2.x berechnet (relative Luminanz, Verhältnis (L1 + 0,05) / (L2 + 0,05)). Ziel: Text und Symbole **mindestens 4,5 : 1**; Bedienelement-Konturen und reine Grafik mindestens 3 : 1.

## 1. Farben

### 1.1 Neutralpalette

Die Seitenleiste ist in beiden Themen dunkel und neutral (Blaugrau), nicht Markenblau. Hex-Werte sind Entscheidungen des Designsystems (der Entwurf liefert nur Schätzwerte).

| Rolle | Hell | Dunkel | Kontrast (Hell / Dunkel) |
|---|---|---|---|
| Fenster (Grund) | `#EEF1F4` | `#141A21` | Text primär darauf: 14,15 / 14,86 |
| Fläche (Karte, Feld) | `#FFFFFF` | `#1E2630` | Text primär darauf: 16,04 / 12,96 |
| Fläche vertieft (Gruppenbereich, Funktionsleiste) | `#E3E8ED` | `#1A2129` | Text primär darauf: 13,01 / 13,78 |
| Text primär | `#1A222C` | `#E8EDF2` | s. o. |
| Text sekundär | `#4A5563` | `#AAB4C0` | auf Fläche 7,58 / 7,27; auf Fenster 6,69 / 8,34 |
| Text deaktiviert | `#6B7480` | `#8993A0` | auf Fläche 4,74 / 4,90 |
| Kontur Bedienelement | `#6B7480` | `#7A8594` | auf Fläche 4,74 / 4,08 (Mindestwert 3 : 1) |
| Trennlinie | `#C5CCD5` | `#313B47` | nur Gliederung, keine Information |
| Seitenleiste Grund | `#2B3846` | `#0E1319` | Text weiß/primär darauf: 11,95 / 15,83 |
| Seitenleiste Text sekundär | `#C9D3DE` | `#AAB4C0` | 7,89 / 8,88 |
| Taste neutral | `#DCE1E7` | `#2E3844` | Text primär: 12,2 / 10,1 |
| Taste gedrückt | `#C3CBD5` | `#3A4656` | Text primär: 9,8 / 8,14 |
| Taste deaktiviert | `#FFFFFF` | `#1E2630` | Text deaktiviert: 4,74 / 4,90 |
| Taste aktiv (Ein) | `#2B3846` | `#44546A` | Text 11,95 / 6,55 |

### 1.2 Statusfarben

Farbe tritt nur hier auf. Jede Statusfarbe hat drei Tokens: `Brush.Status.<Status>.Fill` (Fläche), `.On` (Text und Symbol auf der Fläche) und `.Fg` (Symbol, Text oder Kontur auf neutraler Fläche); dazu `.Subtle` (Flächenton, siehe unten). Zu jeder Statusfarbe gehört ein festes Symbol und ein Statuswort (Tabelle 1.3). **Keine Statusfläche im Normalbetrieb:** Zustände ohne Handlungsbedarf (Ok, aktiv, befüllt, Info) behalten eine neutrale Fläche (`Brush.Surface`); Symbol, Wort und Kontur (`.Fg`) tragen den Zustand. Flächen `.Fill` und `.Subtle` erscheinen nur bei Warnung, Fehler oder Handlungsbedarf (Beispiele: HM-23 Zeile „aktiv“ und HM-32 „In Ordnung“ bleiben neutral).

| Status | Hell Fill | Hell On | Hell Fg | Dunkel Fill | Dunkel On | Dunkel Fg |
|---|---|---|---|---|---|---|
| Ok | `#187228` | `#FFFFFF` | `#187228` | `#4CC264` | `#0B1A0F` | `#4CC264` |
| Warnung | `#F2B600` | `#1A222C` | `#8A5A00` | `#FFC933` | `#141A21` | `#FFC933` |
| Fehler | `#C62828` | `#FFFFFF` | `#C62828` | `#FF6B6B` | `#141A21` | `#FF6B6B` |
| Info | `#1565C0` | `#FFFFFF` | `#1565C0` | `#5AA9F5` | `#0B1620` | `#5AA9F5` |
| Inaktiv | `#5F6975` | `#FFFFFF` | `#5F6975` | `#9AA4B1` | `#141A21` | `#9AA4B1` |

Kontrastverhältnisse (alle ≥ 4,5 : 1; `Fg` ist zusätzlich auf `Surface.Sunken` geprüft, Mindestwert Hell 4,52 (Inaktiv), Dunkel 5,85 (Fehler)):

| Status | On auf Fill (Hell / Dunkel) | Fg auf Fläche (Hell `#FFFFFF` / Dunkel `#1E2630`) | Fg auf Fenster (Hell `#EEF1F4` / Dunkel `#141A21`) |
|---|---|---|---|
| Ok | 6,04 / 7,88 | 6,04 / 6,70 | 5,33 / 7,68 |
| Warnung | 8,76 / 11,38 | 5,93 / 9,93 | 5,23 / 11,38 |
| Fehler | 5,62 / 6,31 | 5,62 / 5,50 | 4,96 / 6,31 |
| Info | 5,75 / 7,33 | 5,75 / 6,13 | 5,07 / 7,03 |
| Inaktiv | 5,58 / 6,94 | 5,58 / 6,05 | 4,92 / 6,94 |

Begründung der Werte:

- Die Ok-, Fehler-, Info- und Inaktiv-Farben im Hellthema sind so abgedunkelt, dass weißer Text auf der Fläche und die Farbe selbst auf Weiß beide 4,5 : 1 erreichen. Das reine Signalgrün `#00FF00` und Rot `#FF0000` des Entwurfs erfüllen dies nicht (Rot `#FF0000` auf Weiß erreicht nur 4,0 : 1; Weiß auf dem Grün `#70AD47` nur 2,7 : 1).
- **Warnung** ist die Ausnahme: Gelb/Amber erreicht als Textfarbe auf Hell nie 4,5 : 1. Deshalb ist die Fläche amber mit dunklem Text (`On` 8,76 : 1), und als Schrift/Symbol auf neutralem Grund dient das dunkle Bernstein `#8A5A00` (5,93 : 1). Warnflächen erhalten eine 2 px Kontur in `Fg`, weil Amber auf Weiß nur 1,83 : 1 hat und sonst als Grafik nicht abgrenzbar wäre.
- Im Dunkelthema sind die Statusfarben aufgehellt und die `On`-Farbe ist dunkel; so bleiben die Verhältnisse ≥ 4,5 : 1.
- Rot ist **ausschließlich** Fehler/Alarm. Die rote Eingabewertschrift und die rote Taste „Manuell“ des Entwurfs entfallen (Abschnitt 12).
- Grün bedeutet „Ok / erfüllt“ und erscheint nur als kleines Symbol (`Brush.Status.Ok.Fg`) an Status-LEDs mit Zustand „erfüllt“ (begründete Ausnahme: Voraussetzungslisten wie in DS-03/DS-04 werden nach dem Vorbild der Referenz mit Grün „erfüllt“ gelesen; das Symbol Haken und das Wort stehen immer dabei). Grün ist **nie** Fläche im Normalbetrieb und **nie** „Taste ist eingeschaltet“. Ein-Zustand von Tasten und Umschaltern ist neutral (Abschnitt 5).

Zusätzlich (Flächenton für Zeilen/Felder im Fehler-, Warn- usw. Zustand, `Subtle`):

| Status | Hell | Dunkel | Kontrast Fg auf Subtle (Hell / Dunkel) |
|---|---|---|---|
| Ok | `#E4F4E7` | `#17341D` | 5,29 / 5,96 |
| Warnung | `#FFF4CC` | `#3D3000` | 5,38 (Fg `#8A5A00`) / 8,42 |
| Fehler | `#FDECEC` | `#3B1D1F` | 4,92 / 5,48 |
| Info | `#E3F0FD` | `#16304A` | 4,97 / 5,42 |

### 1.3 Statussymbole und -wörter (zweiter Kanal)

| Status | Symbol (Form) | Statuswort (Beispiel, `.resx`) | Form unterscheidbar ohne Farbe |
|---|---|---|---|
| Ok | `Icon.Status.Ok`: Kreis mit Haken | „OK“ / „Erfüllt“ | Kreis |
| Warnung | `Icon.Status.Warning`: Dreieck mit „!“ | „Warnung“ | Dreieck |
| Fehler | `Icon.Status.Error`: Achteck/Kreis mit „×“ | „Fehler“ / „Alarm“ | Kreuz |
| Info | `Icon.Status.Info`: Kreis mit „i“ | „Info“ | Kreis mit i |
| Inaktiv | `Icon.Status.Inactive`: leerer Kreis, Strich | „Aus“ / „Inaktiv“ | leer, ungefüllt |

### 1.4 Weitere Rollen

- **Fokus / Auswahl** (Tastaturfokus, Auswahlrahmen in Listen, Bedienfeld in Bearbeitung): Info-Fg-Farbe, 3 px Rahmen. Info-Blau kennzeichnet hier den Eingabefokus, keinen Status; Kontrast 5,07 : 1 (Hell) / 7,03 : 1 (Dunkel) auf Fenster.
- **Scrim** (Pop-up-Hintergrund): Schwarz 50 % Deckkraft (Hell) bzw. 60 % (Dunkel). Keine Information.
- **Grafik Leimspuren** (DM-22): Karton und Leimspur sind Abbildung eines Objekts, keine Statusfarbe; sie dürfen die beiden Neutralbraun-Töne `Brush.Graphic.Carton` (Hell `#B07A52`, Dunkel `#8A6A4F`) und `Brush.Graphic.Glue` (Hell `#FBF0D0`, Dunkel `#F0E2B8`) und die Kontur `Brush.Graphic.Outline` (= Text primär) nutzen. Kontraste: Karton auf `Surface` 3,65 / 3,09, Leimspur auf Karton 3,21 / 3,82, Kontur auf Karton 4,39 / 4,19 (alle ≥ 3 : 1 für Grafik). Das ist die einzige Nicht-Status-Farbe und gilt nur für Produktabbildungen; Eingabefelder darin sind normale Wertfelder.

## 2. Typografie

**Schriftfamilie:** `Segoe UI` (Windows-Systemschrift, in WPF immer vorhanden, gut lesbare Ziffern, vollständige Umlaute und Sonderzeichen °, ³). Rückfall: `Arial`. Der Entwurf nutzt vermutlich Calibri (A-05); Segoe UI hat bei gleicher Größe größere x-Höhe und eindeutigere Ziffern (1/7, 0/O). Festlegung in A-25. Keine Unterstreichungen für Hervorhebung (Entwurf „Status“, „Aktuelle Temperaturen“); Hierarchie über Größe und Gewicht.

Größenstufen für Bedienabstand (Bedienerstand ca. 0,6 bis 0,8 m, 21 bis 24-Zoll-Bildschirm mit 1920 × 1080; ein WPF-Einheitspixel entspricht dort etwa 0,25 mm). Mindestgröße 20 px (≈ 5 mm Schrifthöhe), keine Schrift darunter. Der Entwurf hat teils nur 13 bis 14 px (Brotkrümel, Name/Rolle, Datum); das entfällt.

| Stufe | Token | Größe (px) | Gewicht | Zeilenhöhe | Verwendung |
|---|---|---|---|---|---|
| Caption | `Font.Size.Caption` | 20 | Regular | 26 | Datum, Einheiten, Hinweistexte, Rolle in Seitenleiste |
| Body | `Font.Size.Body` | 24 | Regular | 32 | Beschriftungen, Zeilen, Brotkrümel, Tastentext, Meldungstext |
| Value | `Font.Size.Value` | 28 | SemiBold | 36 | Wertfelder, Eingabefelder, Messwerte in Zeilen, Gruppen- und Kartenüberschriften |
| Title | `Font.Size.Title` | 32 | SemiBold | 40 | Seitentitel, Titelzeile (DM-21), Betriebsart |
| Metric | `Font.Size.Metric` | 36 | SemiBold | 44 | Kennzahlen (Geschwindigkeit, Winkel), Uhrzeit |

Regeln: Textfarbe `Brush.Text.Primary`, Hinweise `Brush.Text.Secondary`. Maximal eine Stufe Gewichtsunterschied je Zeile. Zahlen mit Einheit: Wert, geschütztes Leerzeichen, Einheit (`112 1/min`, `245 °`, `83 %`, `235 g`); das vereinheitlicht „5.30g“, „235g“, „83%“ des Entwurfs. Tabellarische Ziffern (`Typography.NumeralAlignment="Tabular"`) in Messwerten. Textumbruch automatisch statt Trennstrichen (DM-12, OP-13).

## 3. Abstands- und Größenraster

### 3.1 Basis

Alle Maße sind Vielfache von 8 px (Ausnahme 4 px für feine Abstände). Die Maße gelten für 1920 × 1080; das Hauptfenster skaliert bei anderer Größe per `Viewbox` proportional (Seitenverhältnis 16 : 9 erhalten), die Maße bleiben dabei fest in WPF-Einheiten.

| Token | Wert (px) | Verwendung |
|---|---|---|
| `Space.XS` | 4 | Symbol zu Text |
| `Space.S` | 8 | Innenabstand innerhalb eines Elements (Symbol/Text, Zeilenabstand), **nie** Abstand zwischen zwei Touch-Zielen (dort `Size.Touch.Gap` = 16) |
| `Space.M` | 16 | Standardabstand zwischen Elementen (Gutter), Innenabstand Karte |
| `Space.L` | 24 | Abstand zwischen Gruppen; der Außenrand des Inhaltsbereichs wird in Seiten und Modulen einheitlich über `Size.Content.Margin` (Wert 24, = `Space.L`) angegeben |
| `Space.XL` | 32 | Abstand zwischen Hauptbereichen |
| `Size.Touch.Min` | 48 | absolute Untergrenze jedes Touch-Ziels (z. B. Pop-up-Schließen, Tabellenzeile) |
| `Size.Touch.Default` | 64 | Standardhöhe jeder Taste, Eingabefeld, Umschalterzeile |
| `Size.Touch.Large` | 96 | Kachel-Taste (DM-12), Hauptaktionen |
| `Size.Touch.Gap` | 16 | Mindestabstand zwischen zwei Touch-Zielen (= `Space.M`) |
| `Size.Icon.S` / `M` / `L` | 24 / 32 / 48 | Symbolgrößen (in Tasten: M; Seitenleiste und Statuszeile: L bzw. M) |

Ein Touch-Ziel darf optisch kleiner sein als sein Trefferbereich, der Trefferbereich aber nie kleiner als 48 × 48 px. Der Abstand zwischen zwei Touch-Zielen beträgt mindestens 16 px (Fehlbedienung bei Handschuhen/Fingern).

### 3.2 Rahmen-Grid (Proportionen statt Pixelpositionen)

Das Hauptfenster ist ein `Grid` mit Stern-Proportionen. Die Pixelwerte in Klammern gelten nur als Kontrolle bei 1920 × 1080.

```
+---------+------------------------------------------------------------+
| Seiten- | Kopfzeile: Logo | Meldezeile | Betriebsart | Uhr/Datum     |  4*
| leiste  +------------------------------------------------------------+
|         | Brotkrümel                          | Geschw. | Winkel    |  3*
| (3*)    +------------------------------------------------------------+
|         |                                                            |
| Benutzer|                    Inhaltsbereich                          | 34*
| Nav.    |                                                            |
| ...     +------------------------------------------------------------+
| Zurück  | Untere Funktionsleiste                                     |  4*
+---------+------------------------------------------------------------+
   3*                              37*
```

Spalten des Hauptfensters: Seitenleiste **3\*** : Arbeitsbereich **37\*** (Summe 40, 1 Einheit = 48 px, Seitenleiste 144 px = 7,5 %). Zeilen des Arbeitsbereichs: Kopfzeile **4\*** : Brotkrümel-/Kennzahlzeile **3\*** : Inhalt **34\*** : Funktionsleiste **4\*** (Summe 45, 1 Einheit = 24 px; 96 : 72 : 816 : 96 px). Die Seitenleiste reicht über die volle Höhe.

| Bereich | Anteil | Aufbau |
|---|---|---|
| **Seitenleiste** (DM-01, DM-02) | 7,5 % der Breite, volle Höhe | von oben: Benutzerkennung (Kreis 64 px, Name, Rolle, Caption 20 px, bis zu 2 Zeilen); darunter Symboltasten Home, Einstellungen, Meldungen (je volle Spaltenbreite × 96 px = `Size.Touch.Large`, Symbol 48 px, 16 px Abstand = `Size.Touch.Gap`); ganz unten Zurück (gleiche Größe, mindestens 16 px Abstand zur darüberliegenden Taste). Auswahl: Symbol der aktuellen Seite mit 6 px Balken (`Size.SelectionBar`) am linken Rand und hellerem Grund (zweiter Kanal zusätzlich zur Farbe). |
| **Kopfzeile** | 92,5 % der Breite, 8,9 % der Höhe | Spalten **12\* : 13\* : 6\* : 4\*** (Summe 35): Logo (≈ 35 %), Meldezeile (≈ 37 %), Betriebsart (≈ 17 %), Uhrzeit/Datum (≈ 11 %); abgeleitet aus dem Entwurf (35 : 37,5 : 18 : 9) mit etwas mehr Platz für Uhrzeit und Datum. Mindestbreiten: Uhrzeit 192, Betriebsart 288 px. |
| **Brotkrümel-/Kennzahlzeile** | 6,7 % der Höhe | Spalten **56\* : 10\* : 10\***: Brotkrümel (links, Segmente je 64 px hoch, antippbar als Annahme A-27), Kennzahl Geschwindigkeit, Kennzahl Maschinenwinkel (je ≈ 13 %, Mindestbreite 224 px; Wert 36 px Metric, Symbol 32 px). |
| **Inhaltsbereich** | 75,6 % der Höhe | Außenrand `Size.Content.Margin` (24 px), 12-Spalten-Raster (3.3). Seitenspezifisch. |
| **Untere Funktionsleiste** (DM-09, DM-10) | 8,9 % der Höhe | Fläche vertieft, Innenrand 16 px oben/unten, Tasten 64 px hoch (Rest 16 px), links beginnend, 16 px Abstand, Breite je Taste mindestens 224 px (`Size.FunctionButton.MinWidth`), **höchstens 5 seitenspezifische Tasten** (wie Navigation.md); weitere Aktionen hinter einer Überlauf-Taste `Icon.More` („Mehr“, 64 × 64 px) am rechten Rand der Leiste. Auf leeren Seiten bleibt die Leiste sichtbar (Rahmenkonsistenz). |

### 3.3 Inhaltsbereich: 12-Spalten-Raster

- 12 gleich breite Spalten, Gutter 16 px (`Space.M`), Außenrand 24 px, Zeilen in Stern-Höhen mit Mindesthöhen (Tasten ≥ 64 px).
- Gruppenbereiche (DM-11) belegen ganze Spalten- und Zeilenanteile; die Innenmaße kommen von den Modulen.
- Ausgangswerte aus dem Entwurf (auf Spaltenanteile gerundet):

| Seite | Aufteilung (Spalten von 12) |
|---|---|
| DS-01 Produktion | obere Reihe 4 Kacheln **2 : 3 : 3 : 4** (Entwurf 222 : 257 : 351 : 397 px ≈ 17 : 20 : 27 : 31 %) und ca. 45 % der Höhe; untere Reihe **5 : 7** (Tastenblock 3 × 2 Kachel-Tasten 96 px, rechts Umschalter-Gruppe in 2 Spalten) |
| DS-02 Einstellungen | 3 Gruppen **4 : 4 : 4**; links „Anwählen/Schnelle Einstellungen“, Mitte und rechts je Kachelraster 2 × 4 (Kachel-Tasten 96 px hoch) |
| DS-03 Heißleim | links schmal **2** (Tastenspalte 3 Zustandstasten + Zeitplan), Mitte **7** (Status-LED-Liste und Temperaturen), rechts **3** (Füllstand, Eingabefelder, Aktionstasten) |
| DS-04 Dosierer | Titelzeile über 12 Spalten, darunter 3 Karten **4 : 4 : 4** |
| DS-05 Kartonzuführung | links **5** (Bedienbereich), rechts **7** (Leimspuren-Grafik, skaliert mit Seitenverhältnis des Zuschnitts) |

Die Aufteilung ist Konzeptvorgabe für Phase 3 (HS-xx); Seiten ohne Design leiten ihre Aufteilung aus diesem Raster ab.

## 4. Radius, Rahmen, Elevation

Flach. Es gibt keine Verläufe, keine Fasen, keine Schlagschatten, keine Glanzlichter.

| Token | Wert | Verwendung |
|---|---|---|
| `Radius.None` | 0 | Rahmenflächen (Seitenleiste, Kopfzeile, Funktionsleiste) |
| `Radius.Control` | 6 | Tasten, Felder, Umschalter-Bahn |
| `Radius.Card` | 8 | Gruppenbereiche, Karten, Pop-ups |
| `Radius.Pill` | 32 | Umschalter-Knopf und Status-LED (rund), Benutzerkreis |
| `Border.Thin` | 1 | Karte, Feld im Normalzustand (`Brush.Border.Control`) |
| `Border.Medium` | 2 | Taste gedrückt, Warnfläche, Fehlerrahmen, Pop-up |
| `Border.Thick` | 3 | Fokus, Auswahl |

Tiefe wird nur über Flächentöne gestaffelt: Fenster → Fläche vertieft (Gruppe) → Fläche (Karte/Feld). Pop-ups stehen über dem Scrim und tragen `Border.Medium`; sie haben **keinen** Schatten.

## 5. Zustände

Jedes interaktive Element kennt die Zustände der Tabelle. Zweiter Kanal = Information, die auch bei Farbenblindheit, Schwarz-Weiß-Druck oder Blendung erhalten bleibt. Geltungsbereich: Tasten (DM-10, DM-12, DM-19), Umschalter (DM-13), Eingabefelder (DM-17), Seitenleisten-Symbole (DM-02).

| Zustand | Fläche / Kontur / Text | Zweiter Kanal | Hinweis |
|---|---|---|---|
| **Normal** | `Brush.Button.Normal`, Kontur 1 px `Brush.Border.Control`, Text primär | Beschriftung (Text), bei Zustandstasten Symbol „Aus“ (`Icon.State.Off`) und Wort | Eingabefeld: Fläche, Kontur 1 px. |
| **Gedrückt** | `Brush.Button.Pressed`, Kontur 2 px, Text primär | dickere Kontur (Form), Rückmeldung unmittelbar (< 100 ms) | Nur während der Berührung. Touch-Ziel wirkt beim Loslassen im Ziel (kein Auslösen beim Berühren). |
| **Deaktiviert** | Fläche `Brush.Button.Disabled`, Kontur **gestrichelt**, Text `Brush.Text.Disabled` | gestrichelte Kontur, kein Pressed; Grund wird per Tippen in der Meldezeile als Info-Text genannt (Annahme A-28) | Bedienung durch Betriebszustand verhindert, nicht Berechtigung. Entspricht den „abgeblendeten“ Tasten in DS-04 (OP-18). Kontrast Text auf `Button.Disabled` 4,74 / 4,90 (freiwillig ≥ 4,5, obwohl WCAG ausgenommen); `Text.Disabled` nur auf `Button.Disabled`, `Surface` oder Dunkel-`Window` verwenden, nicht auf `Button.Normal` (3,60 / 3,82). |
| **Aktiv / Ein** | `Brush.Button.Active` (neutral dunkel), Text `Brush.Text.OnActive` | Symbol Haken (`Icon.State.On`) und Wort „Ein“; beim Umschalter Knopf rechts, Bahn gefüllt, Wort „Ein“ | Neutral, nicht grün. Aus: Knopf links, Bahn leer, Wort „Aus“ + `Icon.State.Off`. |
| **Fehler** | Kontur 3 px `Brush.Status.Error.Fg`, Fläche `Brush.Status.Error.Subtle`, Text primär | Symbol `Icon.Status.Error` und Fehlertext (Zeile unter dem Element, z. B. „Wert außerhalb 0 bis 100 %“) | Gilt für ungültige Eingabe und gestörte Funktion. Bei Alarm zusätzlich Meldezeile. |
| **Berechtigungsgeschützt** | Fläche Normal, Kontur 1 px | Symbol Schloss (`Icon.Lock`, Berechtigung fehlt, nicht bedienbar) bzw. Schlüssel (`Icon.Key`, Berechtigung vorhanden, bedienbar, Anmeldung bzw. Freigabe erforderlich); Tippen ohne Berechtigung öffnet Hinweis „Berechtigung erforderlich: <Rolle>“ | Symbol 24 px oben rechts im Element (Entwurf: gelber Schlüssel am Eingabefeld). Das Symbol steht immer, die Farbe ist `Brush.Text.Primary`, nicht gelb (Gelb = Warnung). |
| **Fokus** (Ergänzung) | Kontur 3 px `Brush.Border.Focus` | Rahmen (Form) | Bei Tastatur-/Maus-Bedienung, Auswahl in Listen. |

Kombinationen: Berechtigungsgeschützt und deaktiviert zeigen das Schloss und die gestrichelte Kontur. Fehler gewinnt gegenüber Aktiv in der Darstellung; das Aktiv-Symbol bleibt als zweites Zeichen daneben erhalten.

Zustandsanzeigen ohne Bedienung (Status-LED DM-14, Betriebsart DM-05, Meldezeile DM-04) verwenden die Statusfarben aus 1.2 zusammen mit Symbol und Wort aus 1.3:

| Anzeige | Darstellung |
|---|---|
| Status-LED (DM-14) | Kreis 32 px mit Symbol (Haken/!/×/leer) in `Brush.Status.*.Fg` ohne Fläche, daneben die Beschriftung; eine einzige Variante (Ring und flach des Entwurfs werden vereinheitlicht) |
| Betriebsart (DM-05) | Normalzustand neutral: Fläche `Brush.Surface`, Symbol `Icon.Mode.Production`, Wort „Produktion“ in `Brush.Text.Primary` (Grundsatz 1: Normalzustand ist grau). Statusfarbe nur bei abweichendem Zustand der Betriebsart (Warnung/Fehler: Fläche `Status.*.Fill`, Text `.On`, Statussymbol) |
| Meldezeile (DM-04) | Fläche in Statusfarbe der Meldung (Warnung: `Status.Warning.Fill` mit Text `On`), Symbol, Format „NNN: Text“, Schweregradwort; keine Meldung: neutrale Fläche, Text „Keine Meldung“ |
| Fortschrittsbalken (DM-18) | Balken neutral (Fläche `Brush.Progress.Fill` = Text sekundär), Zahl im Balken und Wert; Statusfarbe nur bei Grenzwertüberschreitung (z. B. Auslastung ≥ 90 % = Warnung) mit Symbol |

## 6. Symbolik

Symbole sind monochrome Vektorsymbole (`Geometry` als `Path`, Strichstärke 2 px bei 24 px Rastergröße, abgerundete Enden), nicht Schriftsymbole; sie übernehmen die Textfarbe über `Brush.*`. Größen `Size.Icon.S/M/L`. Jedes Symbol hat einen Namen und einen Beschriftungsschlüssel in der `.resx`; Symboltasten ohne Text (Seitenleiste) tragen den Text als `AutomationProperties.Name` und als Kurzbeschriftung unter dem Symbol (Caption), weil im Entwurf unbeschriftete Symbole unklar sind (OP-21).

| Symbolname | Bedeutung / Verwendung | Quelle im Entwurf |
|---|---|---|
| `Icon.Home` | Produktion (Startseite) | Haus, Seitenleiste |
| `Icon.Settings` | Einstellungen | Zahnrad, Seitenleiste |
| `Icon.Messages` | Meldungen, mit Zähler-Punkt für neue Meldungen | Sprechblase mit „!“ |
| `Icon.Back` | Zurück (eine Ebene) | Rücktaste mit X |
| `Icon.Language` | Sprache wählen (Funktionsleiste DS-02) | Beschriftung „Sprache“ |
| `Icon.User` | Benutzer / Anmeldung | Kreis „MM“ |
| `Icon.Key` | Eingabe berechtigungspflichtig, Berechtigung vorhanden | gelber Schlüssel (DS-03, DS-05) |
| `Icon.Lock` | gesperrt, Berechtigung fehlt | (nicht im Entwurf) |
| `Icon.Block` | nicht verfügbar im aktuellen Betriebszustand | (Annahme) |
| `Icon.Mode.Production` | Betriebsart Produktion | Kreispfeile |
| `Icon.Speed` | Geschwindigkeit | Tacho |
| `Icon.Angle` | Maschinenwinkel | Winkel |
| `Icon.Move` | Fenster/Karte verschieben | Vierfachpfeil (DM-21) |
| `Icon.Chevron` | Brotkrümel-Trenner, Auswahl | Pfeilsegment |
| `Icon.Status.Ok` / `.Warning` / `.Error` / `.Info` / `.Inactive` | Status (1.3) | LED, Meldezeile |
| `Icon.State.On` / `.Off` | Ein/Aus-Zustand (Haken / leerer Kreis) | Umschalter, Zustandstasten |
| `Icon.Close` | Pop-up schließen, Meldung quittieren | (Annahme) |
| `Icon.Confirm` | Eingabe bestätigen | (Annahme, Pop-up RM-06) |
| `Icon.Schedule` | Zeitplan, Schichtplan | Tasten „Zeitplan“, „Schichtplan“ |
| `Icon.Temperature` / `.Pressure` | Temperatur, Druck | Tasten in DS-03 |
| `Icon.Pump`, `Icon.Fill`, `Icon.Heating` | Pumpe, Füllsystem, Heizung | Tasten in DS-03 |
| `Icon.Manual` | Manueller Betrieb | Taste „Manuell“ |
| `Icon.Empty` | Entleeren | Taste „Entleeren“ |
| `Icon.Scroll.Up` / `.Down` | Listen blättern | RM-21 |
| `Icon.More` | Überlauf der Funktionsleiste („Mehr“) | (Annahme) |



### 6.1 Fachsymbole aus Modulen und Seiten (Konsolidierung)

Diese Symbole sind in Modulen und Seiten als neu genannt und stehen hier einmal zentral. Spalte „Zweiter Kanal“: Das Symbol steht nie allein, sondern mit dem genannten Text oder der Form. Ausführung als Vektorsymbol nach Abschnitt 6 (Rastergröße 24 px); die Datei `Themes/Icons.xaml` führt dieselben Namen.

| Symbolname | Bedeutung / Verwendung | Zweiter Kanal | Definiert in / verwendet auf |
|---|---|---|---|
| `Icon.Action.Reset` | Zähler zurücksetzen (Pfeil im Kreis) | Beschriftung „Reset“, Tooltip | HM-11, HM-34 |
| `Icon.Add` | Eintrag hinzufügen (Plus) | Tagesname und Text „Neuer Eintrag“ | HM-29 |
| `Icon.Delete` | Löschen (Papierkorb) | Beschriftung „Löschen“ | HM-30 |
| `Icon.Dosing.Weight` | Gewichtsstück: abzufüllendes Gewicht („Soll absolut“) | Beschriftung und Einheit g | HM-20, HS-11 |
| `Icon.Dosing.Calibration` | Eichdosierung (Schnecke mit Waagschale) | Beschriftung „Eichdosierung“ | HM-20, HS-11, HS-19 |
| `Icon.Fill.Hopper` | Füllstand im Trichter | Beschriftung und Zustandswort | HM-09 |
| `Icon.Glue.Nozzle` | Kopfleimdüsen (Piktogramm, nur Anzeige) | Beschriftung „Kopfleim“ | HS-16 |
| `Icon.Jog.Minus` / `.Plus` | Bewegungstasten Jog− / Jog+ des Handbetriebs (Pfeil, Totmann-Taste) | Beschriftung „Jog −“ / „Jog +“ und Zustandswort „Läuft“ | HS-31 |
| `Icon.List` | Liste / Übersicht (Taste „Übersicht“) | Beschriftung „Übersicht“ | HS-25 |
| `Icon.Marker.Last` | Marke am jüngsten Wert im Wertegitter (Pfeil) | Kontur `Border.Thick` und Tooltip „letzter Wert“ | HM-37, HS-14 |
| `Icon.Mode.Service` | Betriebsart Service (Wirbel-/Spiralsymbol der Referenz), Warnstatus | Wort „Service“ auf `Brush.Status.Warning.Fill` | HM-02, HS-36, A-48 |
| `Icon.Motor.Screw` | Schneckenantrieb (Kartenart Schnecke) | Kartenüberschrift | HM-21, HS-12, HS-17, HS-20 |
| `Icon.Nav.List` | Navigation zu den Einzelgewichten (Listensymbol) | Tastenbeschriftung „Einzelgewichte“ | HS-13 |
| `Icon.Nav.Trend` | Navigation zum Trend (Liniendiagramm) | Tastenbeschriftung „Trend“ | HS-13 |
| `Icon.Pack.Filled` / `.Present` | Packung befüllt / vorhanden (Packungsregister) | Zustandswort „befüllt“ / „vorhanden“ | HM-32, HS-28 |
| `Icon.Pack.Target` / `.Tare` | Sollgewicht der Packung / Tara | Feldbeschriftung | HS-13 |
| `Icon.Pack.Over` / `.Under1` / `.Under2` | Übergewicht / Untergewicht TU 1 / TU 2 (Zählfelder) | Feldbeschriftung | HS-13 |
| `Icon.Production.Current` / `.Last` | Aktuelle / Letzte Produktion (Stückzähler) | Beschriftung der Kennzahl | HS-01 |
| `Icon.Schedule.Heat` / `.Setback` | Heizphase / Absenkphase im Wochen-Zeitplan | Text, Einrückung, Kontur (durchgezogen/gestrichelt) | HM-29, HS-10 |
| `Icon.Stat.Mean` | Mittelwert | Beschriftung „Mittelwert“ | HS-01, HS-13, HS-14 |
| `Icon.Stat.Sigma` / `.StdDev` | Standardabweichung (σ in HS-01, „S“ in HS-13/HS-14; gleiche Bedeutung, Vereinheitlichung offen, OP-65) | Beschriftung „Standardabweichung“ | HS-01, HS-13, HS-14 |
| `Icon.State.Partial` / `.Pending` | Teilweise (Strich im Kreis) / Ausstehend (Punkt, Befehl gesendet) | Wort „Teilweise“ / „Wird gesetzt“ bzw. „Nicht geschrieben“ | HM-08, HM-12, HM-18, HM-24, HS-01 |
| `Icon.Weight.AutoZero` | Zähler seit dem letzten automatischen Nullpunkt | Feldbeschriftung | HS-13 |
| `Icon.Weight.Last` | Letztes Gewicht (mit Index der Waage) | Beschriftung „Letztes Gewicht“ | HS-01 |
| `Icon.Weight.Scale` | Waage / Netto-Gewicht | Beschriftung („Netto“) | HS-13 |

Weitere Fachsymbole entstehen mit den Modulen HM-xx und werden hier ergänzt (Namensschema `Icon.<Bereich>.<Name>`). Vollständigkeit: `src/tools/check_icons.py` prüft, dass jedes in Seiten, Controls und ViewModels verwendete `Icon.*` in `Themes/Icons.xaml` definiert und in Abschnitt 6/6.1 beschrieben ist (Stand Integration M2-06: 68 Symbole, keines fehlt; die Geometrien sind Platzhalter, Verfeinerung in M3). Fehlt ein Symbol, wird zuerst die Zeile in dieser Tabelle, dann die Geometrie in `Icons.xaml` ergänzt.

## 7. Zusammenspiel mit Modulen (Maßvorgaben)

| Element | Vorgabe |
|---|---|
| Taste | Höhe 64 (`Size.Touch.Default`), Mindestbreite 160 (`Size.Button.MinWidth`; in der Funktionsleiste 224), Innenabstand 16 horizontal, Symbol links optional, Text Body, `Radius.Control` |
| Kachel-Taste (DM-12) | Höhe 96, Text Body zentriert, Symbol über dem Text optional, mehrzeilig automatisch; leere Kachel: nicht anzeigen oder Zustand „deaktiviert“ mit Beschriftung „Reserviert“ (Annahme A-29) |
| Umschalter (DM-13) | Bahn 96 × 48, Knopf 40 px, ganze Zeile (≥ 64 px hoch) antippbar; Beschriftung links, Wort „Ein/Aus“ rechts |
| Eingabefeld (DM-17) | Höhe 64, Wert Value, Schlüsselsymbol 24 px oben rechts, Einheit hinter dem Wert; Pop-up-Eingabe (Annahme A-20) |
| Wertfeld (DM-16) | Höhe 48, Fläche weiß, Kontur 1 px, Wert Value, rechtsbündig |
| Status-LED | 32 px, mit Beschriftung in einer Zeile ≥ 48 px hoch |
| Fortschrittsbalken | Höhe 40, Zahl im Balken Body, `Radius.Control` |
| Karte (DM-20) | `Radius.Card`, Innenabstand 16, Fläche; hervorgehobene Karte (Nachdosierer) nur mit Text/Symbol begründen, nicht nur über Farbe |
| Pop-up | max. 60 % Breite, `Radius.Card`, 2 px Kontur, Titelzeile 64 px, Schließen-Taste 64 px oben rechts, Scrim dahinter |

## 8. Hell/Dunkel-Umschaltung

- Zwei Theme-Dateien mit **identischen Schlüsseln**: `Themes/Theme.Light.xaml`, `Themes/Theme.Dark.xaml` (nur Farben/Brushes). Eine gemeinsame Datei `Themes/Tokens.xaml` enthält die themenunabhängigen Maße, Schriften, Radien (diese sind in beiden Themen gleich).
- `App.xaml` bindet `Tokens.xaml`, die aktive Theme-Datei und `Styles/*.xaml` (Standardstile je Control-Typ, nur `DynamicResource`).
- Umschalten zur Laufzeit: Theme-Dienst (`IThemeService`) ersetzt das erste `MergedDictionary` (Theme) durch das andere. Alle Verweise auf Brushes in Stilen und Seiten verwenden `{DynamicResource Brush.…}`, sonst wirkt die Umschaltung nicht. Maße und Schriften dürfen `StaticResource` sein.
- Auswahl: Standard folgt der Windows-Einstellung beim Start, manuelle Umschaltung in den Systemeinstellungen (Annahme A-30). Die Wahl bleibt gespeichert (Benutzereinstellung).
- Kein Element enthält Hex-Werte, `Color=`-Literale oder Pixelmaße, ausgenommen `Tokens.xaml` und die Theme-Dateien. Seiten nutzen Layoutraster (Abschnitt 3.2/3.3) mit `*`-Spalten; alle in Abschnitt 7 und 3.2 genannten Maße (Mindestbreiten, Umschalter-, LED-, Balken-, Pop-up-Maße) sind Tokens in 10.3.
- Zustandsfarben für Pressed/Disabled usw. sind eigene Tokens, nicht per Opazität berechnet, damit die Kontraste dieses Dokuments garantiert bleiben.

## 9. Namensschema

`Brush.<Rolle>[.<Variante>]`, `Font.<Eigenschaft>.<Stufe>`, `Size.<Art>.<Stufe>`, `Space.<Stufe>`, `Radius.<Stufe>`, `Border.<Stufe>`, `Icon.<Name>`. Typen in WPF: `Brush.*` = `SolidColorBrush`, Maße und Größen = `sys:Double`, Randstärken (`Border.*`) = `Thickness`, Radien = `CornerRadius`, Schriftfamilie = `FontFamily`, Gewichte = `FontWeight`, Icons = `Geometry`.

## 10. Tokenliste

### 10.1 Farben (Brush), themenabhängig

| Token | Typ | Hell | Dunkel | Verwendung |
|---|---|---|---|---|
| `Brush.Window` | SolidColorBrush | `#EEF1F4` | `#141A21` | Fensterhintergrund, Raum zwischen Gruppen |
| `Brush.Surface` | SolidColorBrush | `#FFFFFF` | `#1E2630` | Karte, Wertfeld, Eingabefeld, Pop-up |
| `Brush.Surface.Sunken` | SolidColorBrush | `#E3E8ED` | `#1A2129` | Gruppenbereich (DM-11), Funktionsleiste, Kopfzeile |
| `Brush.Divider` | SolidColorBrush | `#C5CCD5` | `#313B47` | Trennlinien |
| `Brush.Border.Control` | SolidColorBrush | `#6B7480` | `#7A8594` | Kontur von Tasten und Feldern |
| `Brush.Border.Focus` | SolidColorBrush | `#1565C0` | `#5AA9F5` | Fokus-/Auswahlrahmen |
| `Brush.Text.Primary` | SolidColorBrush | `#1A222C` | `#E8EDF2` | Standardtext |
| `Brush.Text.Secondary` | SolidColorBrush | `#4A5563` | `#AAB4C0` | Hinweise, Einheiten, Datum |
| `Brush.Text.Disabled` | SolidColorBrush | `#6B7480` | `#8993A0` | Text deaktivierter Elemente |
| `Brush.Text.OnActive` | SolidColorBrush | `#FFFFFF` | `#E8EDF2` | Text/Symbol auf aktiver Taste |
| `Brush.Sidebar` | SolidColorBrush | `#2B3846` | `#0E1319` | Seitenleiste Grund |
| `Brush.Sidebar.Text` | SolidColorBrush | `#FFFFFF` | `#E8EDF2` | Symbole, Name in Seitenleiste |
| `Brush.Sidebar.Text.Secondary` | SolidColorBrush | `#C9D3DE` | `#AAB4C0` | Rolle, Beschriftungen |
| `Brush.Sidebar.Selected` | SolidColorBrush | `#3F5066` | `#2E3844` | Hintergrund des aktuellen Seitenleisten-Eintrags (mit Balken) |
| `Brush.Button.Normal` | SolidColorBrush | `#DCE1E7` | `#2E3844` | Taste normal (DM-10, DM-12, DM-19 aus) |
| `Brush.Button.Pressed` | SolidColorBrush | `#C3CBD5` | `#3A4656` | Taste gedrückt |
| `Brush.Button.Disabled` | SolidColorBrush | `#FFFFFF` | `#1E2630` | Taste/Umschalter deaktiviert (mit gestrichelter Kontur) |
| `Brush.Button.Active` | SolidColorBrush | `#2B3846` | `#44546A` | Taste aktiv/Ein, Umschalter ein |
| `Brush.Progress.Fill` | SolidColorBrush | `#4A5563` | `#AAB4C0` | Balkenfüllung neutral |
| `Brush.Scrim` | SolidColorBrush | `#80000000` | `#99000000` | Pop-up-Hintergrund |
| `Brush.Status.Ok.Fill` | SolidColorBrush | `#187228` | `#4CC264` | Erfüllt/in Ordnung: Fläche (Text/Symbol darauf in `.On`) |
| `Brush.Status.Ok.On` | SolidColorBrush | `#FFFFFF` | `#0B1A0F` | Text und Symbol auf `.Fill` |
| `Brush.Status.Ok.Fg` | SolidColorBrush | `#187228` | `#4CC264` | Erfüllt/in Ordnung: Symbol, Text und Kontur auf neutralem Grund |
| `Brush.Status.Ok.Subtle` | SolidColorBrush | `#E4F4E7` | `#17341D` | Zeilen-/Feldhintergrund Erfüllt/in Ordnung |
| `Brush.Status.Warning.Fill` | SolidColorBrush | `#F2B600` | `#FFC933` | Warnung: Fläche (Text/Symbol darauf in `.On`) |
| `Brush.Status.Warning.On` | SolidColorBrush | `#1A222C` | `#141A21` | Text und Symbol auf `.Fill` |
| `Brush.Status.Warning.Fg` | SolidColorBrush | `#8A5A00` | `#FFC933` | Warnung: Symbol, Text und Kontur auf neutralem Grund |
| `Brush.Status.Warning.Subtle` | SolidColorBrush | `#FFF4CC` | `#3D3000` | Zeilen-/Feldhintergrund Warnung |
| `Brush.Status.Error.Fill` | SolidColorBrush | `#C62828` | `#FF6B6B` | Fehler/Alarm: Fläche (Text/Symbol darauf in `.On`) |
| `Brush.Status.Error.On` | SolidColorBrush | `#FFFFFF` | `#141A21` | Text und Symbol auf `.Fill` |
| `Brush.Status.Error.Fg` | SolidColorBrush | `#C62828` | `#FF6B6B` | Fehler/Alarm: Symbol, Text und Kontur auf neutralem Grund |
| `Brush.Status.Error.Subtle` | SolidColorBrush | `#FDECEC` | `#3B1D1F` | Zeilen-/Feldhintergrund Fehler/Alarm |
| `Brush.Status.Info.Fill` | SolidColorBrush | `#1565C0` | `#5AA9F5` | Information: Fläche (Text/Symbol darauf in `.On`) |
| `Brush.Status.Info.On` | SolidColorBrush | `#FFFFFF` | `#0B1620` | Text und Symbol auf `.Fill` |
| `Brush.Status.Info.Fg` | SolidColorBrush | `#1565C0` | `#5AA9F5` | Information: Symbol, Text und Kontur auf neutralem Grund |
| `Brush.Status.Info.Subtle` | SolidColorBrush | `#E3F0FD` | `#16304A` | Zeilen-/Feldhintergrund Information |
| `Brush.Status.Inactive.Fill` | SolidColorBrush | `#5F6975` | `#9AA4B1` | Inaktiv/aus: Fläche (Text/Symbol darauf in `.On`) |
| `Brush.Status.Inactive.On` | SolidColorBrush | `#FFFFFF` | `#141A21` | Text und Symbol auf `.Fill` |
| `Brush.Status.Inactive.Fg` | SolidColorBrush | `#5F6975` | `#9AA4B1` | Inaktiv/aus: Symbol, Text und Kontur auf neutralem Grund |
| `Brush.Graphic.Carton` | SolidColorBrush | `#B07A52` | `#8A6A4F` | Kartonzuschnitt (DM-22) |
| `Brush.Graphic.Outline` | SolidColorBrush | `#1A222C` | `#E8EDF2` | Kontur der Grafik (DM-22) |
| `Brush.Graphic.Glue` | SolidColorBrush | `#FBF0D0` | `#F0E2B8` | Leimspuren (DM-22) |

### 10.2 Typografie (themenunabhängig, Datei `Tokens.xaml`)

| Token | Typ | Hell | Dunkel | Verwendung |
|---|---|---|---|---|
| `Font.Family.Default` | FontFamily | `Segoe UI, Arial` | `Segoe UI, Arial` | alle Texte |
| `Font.Weight.Regular` | FontWeight | `Normal` | `Normal` | Fließtext, Beschriftungen |
| `Font.Weight.Strong` | FontWeight | `SemiBold` | `SemiBold` | Werte, Überschriften |
| `Font.Size.Caption` | Double | 20 | 20 | Datum, Einheit, Hinweis |
| `Font.Size.Body` | Double | 24 | 24 | Beschriftung, Tastentext, Brotkrümel |
| `Font.Size.Value` | Double | 28 | 28 | Wert- und Eingabefelder, Gruppen-/Kartenüberschriften |
| `Font.Size.Title` | Double | 32 | 32 | Seitentitel, Betriebsart |
| `Font.Size.Metric` | Double | 36 | 36 | Kennzahlen, Uhrzeit |

### 10.3 Maße, Radius, Rahmen (themenunabhängig)

| Token | Typ | Hell | Dunkel | Verwendung |
|---|---|---|---|---|
| `Size.Touch.Min` | Double | 48 | 48 | absolute Untergrenze Touch-Ziel |
| `Size.Touch.Default` | Double | 64 | 64 | Standardhöhe Taste, Feld |
| `Size.Touch.Large` | Double | 96 | 96 | Kachel-Taste (DM-12), Seitenleisten-Symboltaste (Höhe) |
| `Size.Touch.Gap` | Double | 16 | 16 | Mindestabstand zwischen Touch-Zielen |
| `Size.Icon.S` | Double | 24 | 24 | Schlüssel-/Schlosssymbol im Feld |
| `Size.Icon.M` | Double | 32 | 32 | Symbol in Taste, Status-LED |
| `Size.Icon.L` | Double | 48 | 48 | Seitenleiste |
| `Size.Icon.Stroke` | Double | 2 | 2 | Strichstärke der Symbole und Linien (als Zahl für `StrokeThickness`, Annahme A-86) |
| `Size.Icon.Stroke.Thick` | Double | 3 | 3 | kräftige Strichstärke (Auswahl-/Fokuskontur, Annahme A-86) |
| `Inset.Touch.Gap` | Thickness | 16 | 16 | `Size.Touch.Gap` als Thickness für `Margin`/`Padding` (Annahme A-86); weitere Thickness-Varianten `Inset.XS/S/M/L/XL/Button` siehe A-83 |
| `Size.Sidebar.Width` | GridLength | 3* | 3* | Spalte Seitenleiste (Hauptfenster) |
| `Size.Header.Height` | GridLength | 4* | 4* | Zeile Kopfzeile |
| `Size.Crumb.Height` | GridLength | 3* | 3* | Zeile Brotkrümel/Kennzahlen |
| `Size.FunctionBar.Height` | GridLength | 4* | 4* | Zeile untere Funktionsleiste |
| `Size.Content.Margin` | Thickness | 24 | 24 | Außenrand des Inhaltsbereichs |
| `Size.Button.MinWidth` | Double | 160 | 160 | Mindestbreite Taste |
| `Size.FunctionButton.MinWidth` | Double | 224 | 224 | Mindestbreite Taste in der Funktionsleiste |
| `Size.Avatar` | Double | 64 | 64 | Benutzerkreis (DM-01) |
| `Size.SelectionBar` | Double | 6 | 6 | Auswahlbalken Seitenleiste |
| `Size.Toggle.Width` | Double | 96 | 96 | Umschalter-Bahn (DM-13) |
| `Size.Toggle.Height` | Double | 48 | 48 | Umschalter-Bahn |
| `Size.Toggle.Knob` | Double | 40 | 40 | Umschalter-Knopf |
| `Size.Field.Height` | Double | 48 | 48 | Wertfeld (DM-16); Eingabefeld nutzt `Size.Touch.Default` |
| `Size.Led` | Double | 32 | 32 | Status-LED (DM-14) |
| `Size.Progress.Height` | Double | 40 | 40 | Fortschrittsbalken (DM-18) |
| `Size.Popup.WidthRatio` | Double | 0.6 | 0.6 | maximale Pop-up-Breite (Anteil des Fensters) |
| `Size.Popup.TitleHeight` | Double | 64 | 64 | Titelzeile Pop-up |
| `Size.Header.Clock.MinWidth` | Double | 192 | 192 | Uhrzeit/Datum |
| `Size.Header.Mode.MinWidth` | Double | 288 | 288 | Betriebsart |
| `Size.Metric.MinWidth` | Double | 224 | 224 | Kennzahl-Kachel |
| `Size.Header.Columns` | GridLength[] | 12* : 13* : 6* : 4* | 12* : 13* : 6* : 4* | Kopfzeile: Logo, Meldezeile, Betriebsart, Uhr (als vier Tokens `Size.Header.Col.Logo/.Message/.Mode/.Clock`) |
| `Size.Crumb.Columns` | GridLength[] | 56* : 10* : 10* | 56* : 10* : 10* | Brotkrümel, Geschwindigkeit, Winkel (Tokens `Size.Crumb.Col.Path/.Speed/.Angle`) |
| `Space.XS` | Double | 4 | 4 | feiner Abstand |
| `Space.S` | Double | 8 | 8 | Innenabstand in Elementen (nicht zwischen Touch-Zielen) |
| `Space.M` | Double | 16 | 16 | Standardabstand, Gutter |
| `Space.L` | Double | 24 | 24 | Gruppenabstand, Außenrand |
| `Space.XL` | Double | 32 | 32 | Bereichsabstand |
| `Radius.None` | CornerRadius | 0 | 0 | Rahmenflächen |
| `Radius.Control` | CornerRadius | 6 | 6 | Taste, Feld |
| `Radius.Card` | CornerRadius | 8 | 8 | Karte, Gruppe, Pop-up |
| `Radius.Pill` | CornerRadius | 32 | 32 | Knopf, LED, Kreis |
| `Border.Thin` | Thickness | 1 | 1 | Standardkontur |
| `Border.Medium` | Thickness | 2 | 2 | gedrückt, Warnfläche, Pop-up |
| `Border.Thick` | Thickness | 3 | 3 | Fokus, Fehler |
| `Border.Dash` | DoubleCollection | 4 3 | 4 3 | Strichmuster gestrichelter Kontur (deaktiviert) |

Symbole (`Icon.*`, Geometrien) stehen in `Themes/Icons.xaml`; die Namen sind in Abschnitt 6 festgelegt.

## 11. Lokalisierung

- Sichtbare Texte stehen in `.resx` (Agent.md Abschnitt 4): `Resources/Strings.resx` (Standard, Deutsch) und `Resources/Strings.en.resx` usw. je weitere Sprache. In XAML Zugriff über `x:Static` auf die generierte Ressourcenklasse oder eine `LocalizeExtension`; keine Literaltexte im XAML.
- Schlüssel: `<Bereich>_<Element>_<Eigenschaft>`, englisch, PascalCase, z. B. `Nav_Home_Label`, `Status_Warning_Word`, `State_On_Word`, `Msg_PermissionRequired`, `Unit_RevPerMin`.
- Statuswörter, Symbolnamen (`AutomationProperties.Name`), Fehlertexte und Einheiten sind ebenfalls Ressourcen. Zahlen- und Datumsformat nach `CurrentCulture` (`112 1/min`, `06.01.2026`, Dezimalkomma), Einheiten mit geschütztem Leerzeichen.
- Textlängen: Layouts planen mit +40 % Textbreite (Englisch/Französisch). Tasten wachsen in der Breite (Mindestbreite) und brechen mehrzeilig um; Abschneiden („…“) nur bei Meldungstext mit vollständiger Anzeige im Detail.
- Sprachumschaltung über die Funktionsleisten-Taste `Icon.Language` (DS-02) zur Laufzeit (`CultureInfo` setzen und Ansicht neu aufbauen); Auswahlliste mit Sprachname in der Eigensprache.
- Die Beschriftungen des Entwurfs (Rechtschreibung, z. B. „Heißleim“, „Anwählen“) stehen korrekt in der deutschen `.resx`.

## 12. Abweichungen vom PowerPoint-Entwurf (mit Begründung)

| Entwurf | Neues HMI | Begründung |
|---|---|---|
| Seitenleiste, Tasten, Titelzeile in Markenblau `#4472C4`, Brotkrümel blau bzw. lachsfarben, Uhr blau, Betriebsart grün | Neutrale Blaugrau-Seitenleiste; Tasten, Brotkrümel, Uhr neutral; Farbe nur für Status | Agent.md Abschnitt 6 „Farbe nur für Status und Alarm“. Farbwechsel des Brotkrümels (blau/lachs, DS-01 gegen übrige) war Artefakt (A-09). |
| 3D-Fasen und Verläufe an Tasten, Brotkrümeln, Fortschrittsbalken | flache Flächen, 1 bis 3 px Kontur | Agent.md Abschnitt 6; Fasen sind PowerPoint-Effekte. |
| Meldezeile Amber `#FFC000` mit orangebraunem Text `#C55A11` | Amber mit dunklem Text (8,76 : 1), Symbol und Wort | Orangebraun auf Amber 2,64 : 1 (unter 4,5 : 1); DM-04 verlangt Korrektur und zweiten Kanal. |
| Name blassblau, Rolle ocker auf Blau (DM-01) | Weiß bzw. `#C9D3DE` (≥ 7,89 : 1) | Entwurf kontrastschwach. |
| Betriebsart „Produktion“ als volle grüne Fläche `#70AD47` | neutrale Fläche mit Symbol und Wort; Grün nur als Haken-Symbol an LEDs mit „erfüllt“ | Grundsatz 1: Der Normalbetrieb ist grau und unauffällig; eine dauernd grüne Fläche entwertet Statusfarbe. Ausnahme „Grün = erfüllt“ nur an LEDs. |
| Weiße Schrift auf Grün `#70AD47`, Grau `#A6A6A6`, Kennzahl `#7F7F7F` | Texte auf Statusflächen nur mit `.On`-Werten ≥ 4,5 : 1; Kennzahlen neutral | Weiß auf `#70AD47` 2,71 : 1, Weiß auf `#A6A6A6` 2,43 : 1, Weiß auf `#7F7F7F` 4,0 : 1. |
| Rote Eingabewerte, rote Taste „Manuell“, reingrüne Taste „Füllsystem“ | Neutral; Rot nur für Fehler, Grün nur für Ok | Doppeldeutigkeit: Rot = Alarm. Betriebsart „Manuell aktiv“ wird per Symbol/Text gezeigt (DM-19, OP-14). |
| Grüne Umschalter-Knöpfe und grüne Tasten für „Ein“ | neutraler Ein-Zustand mit Haken und Wort „Ein“ | Grün bedeutet „Ok“ und ist nie Tastenzustand. Ein-Zustand ist kein Status im ISA-101-Sinn; zweiter Kanal Pflicht (A-15). |
| Status-LED in zwei Varianten (Ring/flach), nur Farbe | eine Variante mit Symbol und Wort | Zustand nie nur über Farbe. |
| Fortschrittsbalken gelb/grün-fluoreszierend | neutraler Balken mit Zahl; Statusfarbe nur bei Grenzwert | Farbe nur für Status. |
| Schrift Calibri vermutlich, 13 bis 24 px | Segoe UI, 20 bis 36 px | Lesbarkeit aus Bedienabstand; Entwurf teils zu klein (A-05). |
| Umschalter 95 × 25 px, Symbole klein, Tasten unterschiedlich groß | Touch-Ziele ≥ 48 px, Standard 64 px, einheitliche Größen | Agent.md Abschnitt 6. |
| Pixelpositionen von Hand, Versätze | Stern-Grid mit Proportionen, 8-px-Raster | Agent.md Abschnitt 6; Entwurf uneinheitlich (A-04). |
| Unterstrichene Überschriften, Rechtschreibwellen, Platzhalter („Tolles Rezept“) | Hierarchie über Größe/Gewicht; Wellen und Platzhalter entfallen | A-09. |
| Seitenleistensymbole unbeschriftet | Symbole mit Kurzbeschriftung und Barrierefreiheitsnamen | OP-21; Zuordnung A-07. |
| Gelber Schlüssel (Warnfarbe) am Eingabefeld | Schlüssel/Schloss in Textfarbe | Gelb = Warnung; Berechtigungssymbol ist keine Warnung. |
| Ein- und Aus-Beschriftung „Ein / Aus“ als eine grüne Taste (DS-05) | Zustandstaste mit Zustandswort (Ein oder Aus) | Zustand muss ablesbar sein, nicht nur die Aktion. |

Nicht verändert, weil nur Orientierung: der Rahmenaufbau (Seitenleiste, Kopfzeile, Brotkrümel, Kennzahlen, Funktionsleiste), die Bereichsfolge in der Kopfzeile, die Seitenleisten-Symbole und die Seitenaufteilungen aus 3.3 (als Anteile).

## 13. Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DSY-P01 | Kontraste Text/Symbol | alle Textfarben (inkl. `Text.Disabled` auf `Button.Disabled`) und Status-`On`/`Fg`-Paare ≥ 4,5 : 1; Konturen und Grafik (inkl. DM-22) ≥ 3 : 1 (Tabellen 1.1, 1.2, 1.4) | offen |
| DSY-P02 | Farbe nur Status | außer 1.2 und 1.4 keine Farbtokens | offen |
| DSY-P03 | Zustände | jeder Zustand in Abschnitt 5 hat zweiten Kanal | offen |
| DSY-P04 | Touch | kein Ziel < 48 px, Standard 64 px, Abstand ≥ 16 px | offen |
| DSY-P05 | Tokens | `Theme.Light.xaml` und `Theme.Dark.xaml` haben dieselben Schlüssel wie Abschnitt 10.1 | offen |
| DSY-P06 | Keine Literale | in XAML außerhalb der Token-Dateien keine Hex-/Pixelwerte | offen |
| DSY-P07 | Lokalisierung | keine festen UI-Texte im XAML, alle in `.resx` | offen |
| DSY-P08 | 1920 × 1080 | Rahmen-Grid 3\* : 37\* und 4\* : 3\* : 34\* : 4\* ergibt 144 / 96 / 72 / 816 / 96 px | offen |
