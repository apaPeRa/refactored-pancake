# HS-06 – Zuführung Karton
- Quelle: [RS-06](../../02_Referenz-Analyse/Seiten/RS-06_Zufuehrung-Karton.md) (Funktion: Handbuch Kapitel 6, Tabelle T8, Bild RS-06_01) und [DS-05](../../01_Design-Analyse/Seiten/DS-05_Kartonzufuehrung.md) (Layout: `src_Data/Design/Seite_Kartonzufuehrung.png`; DS-05 = HS-06 nach A-46)   - Navigationspfad: Einstellung › Zuführungen › Karton (Zugang: HS-40, Kachel „Karton“; Zurück-Ziel: HS-40 über den Verlauf; [Navigation.md](../Navigation.md) Abschnitt 2)

## Zweck
Wortgetreu (Handbuch): „Auf dieser Seite werden die Leimspuren auf dem Karton eingestellt, sowie die Kompensationszeit der Leimventile und ab wann ein Karton schlecht markiert wird, weil der Heißleim kalt ist. Für das Leimspülen, werden hier die Ventile angewählt und der Heißleimauftrag kann abgewählt werden.“ Die Seite stellt den Anfang und das Ende jeder Leimspur in Maschinenwinkel (°) auf einer Zuschnittsgrafik ein, zeigt den aktuellen Maschinenwinkel an, stellt die Kompensationszeiten der Leimventile und die Zeitspanne „Leim kalt“ ein, wählt die Spülventile an und schaltet den Heißleimauftrag ein oder aus. Über die Funktionsleiste führt „Heißleimgerät“ zur Heißleim-Seite (HS-07).

Konfliktregel (Agent.md Abschnitt 2): Funktion und Umfang folgen der Referenz (alle sieben Zeilen von T8), Platzierung, Gruppierung und Optik dem Design DS-05 (Taste „Ein / Aus“ oben links, Grafik rechts, Aufteilung 5 : 7).

## Aufbau (Bereiche, Layout)
Rahmen nach [Designsystem](../Designsystem.md) Abschnitt 3.2. Der Inhaltsbereich (Außenrand `Size.Content.Margin`, Gutter `Space.M`) hat nach DS-05 zwei Spalten im 12-Spalten-Raster, **5 : 7**:

- **Linke Spalte (5 Spalten): Bedienbereich**, von oben nach unten in fünf Zeilen (Höhe nach Inhalt, Abstand `Space.M`):
  1. Gruppe „Karton“ (HM-15 Panel) mit der Zustandstaste „Ein / Aus“ (volle Gruppenbreite, `Size.Touch.Default` hoch, Schlüsselsymbol).
  2. Zwischenüberschrift „Einstellungen Leimspuren“ (HM-15, Variante Überschrift, Text mit Trennlinie `Brush.Divider`, ohne Unterstreichung und ohne weiße Schrift auf Grau des Entwurfs).
  3. Zwei Gruppen nebeneinander (je 1\* : 1\*): „Maschinenwinkel“ (Anzeigefeld) und „Leim kalt“ (Eingabefeld).
  4. Gruppe „Kompensation“ mit den zwei Eingabefeldern „Ein:“ und „Aus:“ nebeneinander (je 1\* : 1\*).
  5. Gruppe „Anwahl Spülen“ mit fünf Zustandstasten in zwei Reihen (3 + 2), Reihenfolge zeilenweise 3Y25, 3Y26, 3Y27 / 3Y28, 3Y29.
- **Rechte Spalte (7 Spalten): Leimspuren-Grafik** über die volle Inhaltshöhe. Der Kartonzuschnitt skaliert mit seinem Seitenverhältnis (`Viewbox`, begrenzt durch die Höhe); die 18 Winkelfelder behalten Touch-Größe (Höhe `Size.Touch.Default`, Breite mindestens `Size.Touch.Min` und Wertbreite; Positionen aus dem Raster der Grafik). Titel „Leimspuren“ gehört zur Grafik.
- **Funktionsleiste:** links die Taste „Heißleimgerät“, sonst leer.

```
Inhaltsbereich (12 Spalten, 5 : 7)
+-----------------------------+----------------------------------------------+
| Karton (HM-15)              | Leimspuren (HM-31)                           |
|  [ Ein / Aus ⚿]       |  [200⚿][205⚿][205⚿]  [205⚿][205⚿]  (Reihe 1)|
| Einstellungen Leimspuren    |   |      [225⚿][225⚿]  [225⚿][225⚿]  (Reihe 2)|
| +------------+------------+ |   |  lange Spur links, 4 kurze Spuren oben  |
| |Maschinenw. |Leim kalt   | |                                              |
| |[140 °]     |[3 s ⚿]     | |      Kartonzuschnitt (Draufsicht)            |
| +------------+------------+ |                                              |
| Kompensation                |   |  [300⚿][310⚿][310⚿]  [310⚿][310⚿]  (Reihe 3)|
|  Ein:[20 ms⚿]  Aus:[20 ms⚿] |   |      [325⚿][329⚿]  [329⚿][329⚿]  (Reihe 4)|
| Anwahl Spülen               |                                              |
|  [3Y25][3Y26][3Y27]         |                                              |
|  [3Y28][3Y29]               |                                              |
+-----------------------------+----------------------------------------------+
Funktionsleiste: [Heißleimgerät]
```
(⚿ = Schlüsselsymbol `Icon.Key`; die Skizze zeigt die Reihenfolge, nicht die Positionen der Felder.)

Anordnung der 18 Felder in der Grafik: vier Reihen mit 5, 4, 5, 4 Feldern; die Felder der Reihen 2 und 4 liegen unter den Feldern 2 bis 5 der Reihen 1 und 3 (Bild RS-06 und DS-05). Zuordnung zu den Spuren (Annahme, OP-19): lange linke Spur Anfang = Reihe 1 Feld 1, Ende = Reihe 3 Feld 1; obere kurze Spuren O1 bis O4: Anfang = Reihe 1 Felder 2 bis 5, Ende = Reihe 2 Felder 2 bis 5; untere kurze Spuren U1 bis U4: Anfang = Reihe 3 Felder 2 bis 5, Ende = Reihe 4 Felder 2 bis 5. Die Zuordnung erscheint nur als Barrierefreiheitsname und Tooltip („Spur O1 Anfang“); die Quelle belegt sie nicht.

## Elemente

Spalte „Herkunft“ = Rückverfolgung: RS-06 (Zeile aus T8, Bild) und DS-05 (Elementtabelle). Beschreibungen wortgetreu aus T8 als Hilfetext (`AutomationProperties.HelpText`). Wertebereiche und Standardwerte nennt die Quelle nicht (OP-28, OP-29): angegeben ist der Beispielwert aus dem Bild; Grenzen sind konfigurierbare Dummy-Werte.

### Bedienbereich links (T8)

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Gruppe „Karton“ mit Text „Karton“ | Gruppenbereich (Panel) | Bereichstitel, trägt die Ein/Aus-Taste | [HM-15](../Module/HM-15_Gruppenbereich.md) | DS-05 „Text Karton“ |
| Taste Ein / Aus | Zustandstaste mit Schlüssel (Darstellung Taste; Zustandswörter „Ein“ und „Aus“, Symbole `Icon.State.On` und `Icon.State.Off`; Bild grün „EIN“, Aus-Zustand nicht abgebildet) | „Erlaubt das Abwählen vom Heißleimauftrag.“ Schaltet den Heißleimauftrag ein (Ein) oder abgewählt (Aus). Beschriftung „Ein / Aus“ wie in RS-06 und DS-05, Gruppenüberschrift „Karton“; Funktion laut Referenz: Heißleimauftrag abwählen (OP-15) | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | RS-06 T8 Zeile 6 „Taste Ein / Aus“; DS-05 „Taste Ein / Aus (grün)“ |
| Zwischenüberschrift „Einstellungen Leimspuren“ | Text | gliedert die Einstellungen des unteren linken Bereichs | [HM-15](../Module/HM-15_Gruppenbereich.md) | DS-05 „Text Einstellungen Leimspuren“ |
| Maschinenwinkel | Anzeigefeld ohne Schlüssel in Gruppe „Maschinenwinkel“, Einheit °, Beispiel 140 ° | „Zeigt den aktuellen Maschinenwinkel an. Dieser wird für die Einstellung der Leimspuren benötigt.“ Gleiche Quelle wie die Kennzahl „Maschinenwinkel“ im Rahmen, steht hier bewusst neben den Eingabefeldern (A-58) | [HM-11](../Module/HM-11_Anzeigefeld.md), [HM-15](../Module/HM-15_Gruppenbereich.md) | RS-06 T8 Zeile 1; Bild Gruppe „Maschinenwinkel“ |
| Kompensation Ein | Eingabefeld mit Schlüssel, Beschriftung „Ein:“, Einheit ms, Beispiel 20 ms | „Zeit in Millisekunden, welche die Leimventile zum Ein- bzw. Ausschalten benötigen. Die Ein- und Ausschaltzeitpunkte werden um diesen Betrag verschoben, um einen gleichmäßigen Leimauftrag unabhängig von der Maschinengeschwindigkeit zu gewährleisten.“ (Beschreibung gilt für beide Felder) | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-15](../Module/HM-15_Gruppenbereich.md) | RS-06 T8 Zeile 3; Bild Gruppe „Kompensation“ |
| Kompensation Aus | Eingabefeld mit Schlüssel, Beschriftung „Aus:“, Einheit ms, Beispiel 20 ms | wie „Kompensation Ein“ (Ausschalten) | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) | RS-06 T8 Zeile 3; Bild Gruppe „Kompensation“ |
| Leim kalt | Eingabefeld mit Schlüssel in Gruppe „Leim kalt“, ohne eigene Beschriftung (die Gruppenüberschrift beschriftet es), Einheit s, Beispiel 3 s | „Wird die Maschine gestoppt, werden alle Kartons mit Leim in der Zuführung nach der Zeitspanne als „schlecht“ markiert.“ | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-15](../Module/HM-15_Gruppenbereich.md) | RS-06 T8 Zeile 4; Bild Gruppe „Leim kalt“ |
| Anwahl Spülen: 3Y25 | Zustandstaste (Darstellung Taste, Wörter „Ein“ = Ventil angewählt, „Aus“) | „An der Zuführung ist eine Hardwaretaste *Leim Spülen* montiert, über die Tasten im Bereich *Anwahl Spülen* kann festgelegt werden, welche Leimventile spülen.“ | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | RS-06 T8 Zeile 5; Bild Taste 1 |
| Anwahl Spülen: 3Y26 | Zustandstaste | wie 3Y25 | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | RS-06 T8 Zeile 5; Bild Taste 2 |
| Anwahl Spülen: 3Y27 | Zustandstaste | wie 3Y25 | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | RS-06 T8 Zeile 5; Bild Taste 3 |
| Anwahl Spülen: 3Y28 | Zustandstaste | wie 3Y25 | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | RS-06 T8 Zeile 5; Bild Taste 4 |
| Anwahl Spülen: 3Y29 | Zustandstaste | wie 3Y25 | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) | RS-06 T8 Zeile 5; Bild Taste 5 (allein in der dritten Zeile) |
| Gruppen „Maschinenwinkel“, „Kompensation“, „Leim kalt“, „Anwahl Spülen“ | Gruppenbereich (Panel) | gliedern den Bedienbereich | [HM-15](../Module/HM-15_Gruppenbereich.md) | RS-06 Rahmenelemente „Gruppenrahmen“ |

### Leimspuren-Grafik rechts (T8 Zeile 2)

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Grafik „Leimspuren“ (Titel „Leimspuren“) | Grafik: aufgefalteter Kartonzuschnitt mit 4 Klappen oben, 4 unten und Verschlusslasche rechts; 1 lange Leimspur am linken Rand, je 4 kurze Spuren oben und unten (`Brush.Graphic.Carton`, `Brush.Graphic.Glue`, Kontur `Brush.Graphic.Outline`) | „Einstellungen für die Leimspuren. Jede Spur besitzt einen Anfangs- und Endpunkt, bezogen auf den *Maschinenwinkel*.“ | [HM-31](../Module/HM-31_Leimspuren-Grafik.md) | RS-06 T8 Zeile 2; DS-05 „Grafik Leimspuren“ und „Leimspuren (helle senkrechte Balken)“; Bild |
| Felder Reihe 1 (5): R1F1 200 °, R1F2 205 °, R1F3 205 °, R1F4 205 °, R1F5 205 ° | Eingabefelder mit Schlüssel, ohne Beschriftung, Einheit ° (Einheit vermutet, OP-19) | Winkel (Maschinenwinkel) je Spur: R1F1 Anfang der langen Spur, R1F2 bis R1F5 Anfang der Spuren O1 bis O4 (Annahme) | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) in [HM-31](../Module/HM-31_Leimspuren-Grafik.md) | RS-06 Tabelle „Einzelne Leimspur-Felder“ Reihe 1; DS-05 „Wertfelder oben, Reihe 1“ |
| Felder Reihe 2 (4): R2F2 225 °, R2F3 225 °, R2F4 225 °, R2F5 225 ° | Eingabefelder mit Schlüssel | Ende der Spuren O1 bis O4 (Annahme) | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) in [HM-31](../Module/HM-31_Leimspuren-Grafik.md) | RS-06 Reihe 2; DS-05 „Wertfelder oben, Reihe 2“ |
| Felder Reihe 3 (5): R3F1 300 °, R3F2 310 °, R3F3 310 °, R3F4 310 °, R3F5 310 ° | Eingabefelder mit Schlüssel | R3F1 Ende der langen Spur; R3F2 bis R3F5 Anfang der Spuren U1 bis U4 (Annahme) | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) in [HM-31](../Module/HM-31_Leimspuren-Grafik.md) | RS-06 Reihe 3; DS-05 „Wertfelder unten, Reihe 1“ |
| Felder Reihe 4 (4): R4F2 325 °, R4F3 329 °, R4F4 329 °, R4F5 329 ° | Eingabefelder mit Schlüssel | Ende der Spuren U1 bis U4 (Annahme) | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) in [HM-31](../Module/HM-31_Leimspuren-Grafik.md) | RS-06 Reihe 4; DS-05 „Wertfelder unten, Reihe 2“ |

Summe 5 + 4 + 5 + 4 = 18 Felder (RS-06-P02, DS-05-P04). Alle sind Eingabefelder mit Schlüsselsymbol; das Design zeigt das Symbol nur sehr klein (OP-19), das neue Layout stellt es in `Size.Icon.S` dar.

### Rahmen, Funktionsleiste und Pop-up

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Taste „Heißleimgerät“ | Aktionstaste (Navigation) in der Funktionsleiste, links | „Öffnet die Seite mit Status- und Einstellmöglichkeiten für das Heißleimgerät der Zuführung.“ Ziel HS-07 (zweiter Zugang, Navigation.md 3.3); das Design zeigt die Leiste leer, die Referenz gewinnt bei der Funktion | [HM-07](../Module/HM-07_Aktionstaste.md), [HM-06](../Module/HM-06_Funktionsleiste.md) | RS-06 T8 Zeile 7 „Heißleimgerät“; DS-05 „Funktionsleiste (leer)“ |
| Seitenleiste mit Benutzerkreis, Home, Einstellungen, Meldungen, Zurück | Navigation | ersetzt Schloss und die Tasten „Produktion“, „Einstellungen“, „Zurück“ (A-35) | [HM-01](../Module/HM-01_Seitenleiste.md) | RS-06 Rahmenelemente „Fußleiste“; DS-05 Rahmen |
| Logo, Betriebsart „Service“ mit Warnstatus (Spiralsymbol der Referenz, A-48; Normalzustand neutral „Produktion“), Uhrzeit, Datum | Kopfzeile | Anzeige | [HM-02](../Module/HM-02_Kopfzeile.md) | RS-06 „Seitenkopf“; DS-05 Rahmen |
| Meldezeile | Anzeige und Taste | Beispielmeldung „\*450\* Palettierung nicht bereit“ bzw. „014: Sicherung 4F24 Auslaufband ausgelöst.“; Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | RS-06 „Meldezeile (rot)“ |
| Brotkrümel „Einstellung › Zuführungen › Karton“ | Navigation | drei Segmente, letztes nur Anzeige; ersetzt den Seitentitel „Zuführung Karton“ | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | DS-05 „Brotkrümel mit 3 Segmenten“; RS-06 Bild Titel |
| Kennzahlen Geschwindigkeit und Maschinenwinkel | Anzeige | Rahmen | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | DS-05 Rahmen |
| Eingabe-Pop-up | Pop-up (Ziffernblock) | öffnet beim Antippen jedes der 21 Eingabefelder (18 Winkel, 2 Kompensation, 1 Leim kalt), Annahme A-20 | [HM-13](../Module/HM-13_Eingabe-Pop-up.md), [HM-14](../Module/HM-14_Popup-Rahmen.md) | RS-06 Verwendete Module (RM-06 „vermutet“) |

## Verwendete Module (IDs)

- [HM-01](../Module/HM-01_Seitenleiste.md) – Seitenleiste
- [HM-02](../Module/HM-02_Kopfzeile.md) – Kopfzeile
- [HM-03](../Module/HM-03_Meldezeile.md) – Meldezeile
- [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) – Brotkrümel-Navigation
- [HM-05](../Module/HM-05_Kennzahl-Kachel.md) – Kennzahl-Kachel
- [HM-06](../Module/HM-06_Funktionsleiste.md) – Funktionsleiste unten
- [HM-07](../Module/HM-07_Aktionstaste.md) – Aktionstaste (Taste „Heißleimgerät“)
- [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) – Zustandstaste / Umschalter (Ein/Aus, Anwahl Spülen)
- [HM-11](../Module/HM-11_Anzeigefeld.md) – Anzeigefeld (Maschinenwinkel)
- [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) – Eingabefeld mit Schlüsselsymbol
- [HM-13](../Module/HM-13_Eingabe-Pop-up.md) – Eingabe-Pop-up
- [HM-14](../Module/HM-14_Popup-Rahmen.md) – Pop-up-Rahmen
- [HM-15](../Module/HM-15_Gruppenbereich.md) – Gruppenbereich
- [HM-31](../Module/HM-31_Leimspuren-Grafik.md) – Leimspuren-Grafik

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)

- **Navigation:** Zugang nur über HS-40 (Kachel „Karton“); Zurück führt nach HS-40 (Verlauf). „Heißleimgerät“ öffnet HS-07 (Verlauf: HS-06 wird abgelegt; von dort führt Zurück wieder hierher). Brotkrümel-Segmente „Einstellung“ (HS-04) und „Zuführungen“ (HS-40) sind antippbar. Die Taste „Zuführung Karton“ auf HS-01 aktiviert nur die Funktion und navigiert nicht (A-38).
- **Taste Ein / Aus (HM-08):** Zustände Aus (Knopf bzw. Symbol `Icon.State.Off`, Wort „Aus“), Ein (`Brush.Button.Active`, Haken `Icon.State.On`, Wort „Ein“; neutral, nicht grün, A-31), Ausstehend (gestrichelt, „Wird gesetzt“), Fehler, Nicht berechtigt (`Icon.Lock`). Der Aus-Zustand und seine Auswirkung auf Betrieb und Meldungen sind in der Quelle nicht beschrieben (OP-46, RS-06 Offene Punkte 5 und 8). Das Schlüsselsymbol steht oben rechts (berechtigungspflichtig).
- **Anwahl Spülen (HM-08):** unabhängig von der Taste Ein / Aus; Ein = Ventil angewählt (Haken und Wort „Ein“), Aus = nicht angewählt (leerer Kreis und Wort „Aus“). Die Tasten tragen im Bild kein Schlüsselsymbol. Der Zustand „gewählt“ ist im Bild nicht dargestellt (RS-06 Offene Punkte 5), die Darstellung folgt dem Designsystem. Die Tasten stellen nur die Anwahl ein; das Spülen löst die Hardwaretaste *Leim Spülen* an der Zuführung aus.
- **Eingabefelder (HM-12):** 21 Eingabefelder (18 Winkelfelder, Kompensation Ein und Aus, Leim kalt) mit den Zuständen Normal, Gedrückt, In Bearbeitung, Fehler (Rahmen, `Icon.Status.Error`, Fehlertext), Nicht berechtigt (`Icon.Lock`, kein Pop-up). Werte in Textfarbe, nicht rot. Das Anzeigefeld „Maschinenwinkel“ hat keinen Eingabezustand.
- **Berechtigungen:** Schlüsselsymbole an Ein/Aus-Taste und allen Eingabefeldern; Stufe und Rolle sind Dummy (OP-25, OP-04). Ohne Rolle öffnet das Antippen das Benutzer-Pop-up; nach Anmeldung läuft die Aktion weiter.
- **Eingabe-Pop-up (A-20, A-51):** Titel (z. B. „Spur O1 Anfang“, „Kompensation Ein“), aktueller Wert, Grenzen, „Übernehmen“ nur bei gültigem Wert, „Abbrechen“ verwirft. Ein Pop-up zur Zeit; Schließen nur über die Pop-up-Tasten; Seitenleiste, Funktionsleiste und Brotkrümel gesperrt (Navigation.md 4.2). Wertebereiche (Winkel, ms, s) sind konfigurierbare Dummy-Grenzen (OP-28); der Maschinenwinkel dient als Bezug und wird zum Einstellen angezeigt.
- **Leimspuren-Grafik (HM-31):** Normal; Feld in Bearbeitung (Fokusrahmen `Border.Thick`); Feld Fehler (`Icon.Status.Error` und Text). Zustand „Spur aus/Fehler“ ist nicht beschrieben (Annahme: Spur gestrichelt mit Text im Tooltip, nur falls die Quelle später Zustände nennt). Die Grafik zeigt keine Statusfarbe; Karton und Leim sind Abbildung eines Objekts (Designsystem 1.4).
- **Kompensation und Leim kalt:** Kompensation verschiebt die Ein- und Ausschaltzeitpunkte der Ventile um den Wert; „Leim kalt“ markiert nach Maschinenstopp alle Kartons mit Leim in der Zuführung nach Ablauf der Zeitspanne als schlecht. Die Seite zeigt nur die Einstellwerte; die Folgen sind Maschinenlogik.
- **Meldungen:** Meldezeile wie auf allen Seiten; Fehlerfälle der Seite sind in der Quelle nicht beschrieben.
- **Wertdarstellung:** Wert, geschütztes Leerzeichen, Einheit (`140 °`, `20 ms`, `3 s`), Dezimalkomma; Beschriftungen und Einheiten aus `.resx`.

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-06-P01 | T8 abgleichen (RS-06-P01) | alle 7 Funktionen vorhanden: Maschinenwinkel, Leimspuren, Kompensation, Leim kalt, Anwahl Spülen, Taste Ein / Aus, Heißleimgerät; Beschreibungen als Hilfetext | offen |
| HS-06-P02 | Leimspur-Felder zählen (RS-06-P02, DS-05-P04) | 18 Eingabefelder; Reihe 1: 200, 205, 205, 205, 205; Reihe 2: 225 ×4; Reihe 3: 300, 310 ×4; Reihe 4: 325, 329, 329, 329 | offen |
| HS-06-P03 | Anzeige Maschinenwinkel (RS-06-P03) | Anzeigefeld 140 ° ohne Schlüssel, in Gruppe „Maschinenwinkel“ | offen |
| HS-06-P04 | Kompensation (RS-06-P04) | zwei Felder „Ein:“ und „Aus:“, je 20 ms (Einheit ms) | offen |
| HS-06-P05 | Leim kalt (RS-06-P05) | ein Eingabefeld, Beispielwert 3 s | offen |
| HS-06-P06 | Anwahl Spülen (RS-06-P06) | 5 Tasten 3Y25, 3Y26, 3Y27, 3Y28, 3Y29; Anordnung im neuen Layout 3 + 2 statt 2 + 2 + 1 (Abweichung begründet durch die Höhe der linken Spalte) | offen |
| HS-06-P07 | Taste Ein / Aus (RS-06-P07, DS-05-P02) | große Zustandstaste mit Schlüsselsymbol, Zustand über Symbol und Wort „Ein“/„Aus“ (nicht grün); Funktion: Heißleimauftrag abwählen | offen |
| HS-06-P08 | Taste „Heißleimgerät“ (RS-06-P08) | links in der Funktionsleiste, öffnet HS-07; Link lösbar | offen |
| HS-06-P09 | Grafik Leimspuren (RS-06-P09, DS-05-P03, DS-05-P07) | Titel „Leimspuren“; Kartonzuschnitt mit Klappen oben und unten und Verschlusslasche rechts; 1 lange Spur links, je 4 kurze Spuren oben und unten | offen |
| HS-06-P10 | Layout linke/rechte Spalte (RS-06-P10) | Bedienbereich links (Karton Ein/Aus, Maschinenwinkel, Leim kalt, Kompensation, Anwahl Spülen), Grafik rechts; Aufteilung 5 : 7; Reihenfolge links gegenüber der Referenz-Spalte (Maschinenwinkel, Kompensation, Leim kalt, Anwahl Spülen, EIN) bewusst nach DS-05 geändert: Ein / Aus zuerst, dann Maschinenwinkel und Leim kalt, Kompensation, Anwahl Spülen; alle Elemente vorhanden | offen |
| HS-06-P11 | Navigation, Rahmen, Meldezeile (RS-06-P11, DS-05-P01, DS-05-P09) | Brotkrümel „Einstellung › Zuführungen › Karton“; Seitenleiste mit Benutzerkreis (Schloss), Home, Einstellungen, Meldungen, Zurück; Meldezeile; Rahmenwerte wie DS-01 | offen |
| HS-06-P12 | Links (RS-06-P12) | Links auf RS-06, DS-05, Navigation.md, HS-07 und alle HM lösen auf | offen |
| HS-06-P13 | Leimspuren-Einstellungen (RS-06-P13) | alle 18 Winkelfelder (je Spur Anfang und Ende), Kompensation Ein/Aus, Leim kalt, 5 Spülventile und Ein/Aus-Taste vorhanden | offen |
| HS-06-P14 | Funktionsleiste (DS-05-P08) | enthält nur „Heißleimgerät“; die Referenz-Tasten Produktion, Einstellungen, Zurück sind in der Seitenleiste | offen |
| HS-06-P15 | Eingabe-Pop-up | Antippen jedes Eingabefelds öffnet HM-13 mit Titel, Wert, Grenzen; Anzeigefeld Maschinenwinkel öffnet nichts | offen |
| HS-06-P16 | Berechtigung | Schlüsselsymbol an Ein/Aus-Taste und 21 Eingabefeldern; ohne Rolle Schloss und Hinweis „Berechtigung erforderlich: <Rolle>“ | offen |
| HS-06-P17 | Zurück-Verhalten | Zurück auf HS-06 führt nach HS-40; nach „Heißleimgerät“ führt Zurück von HS-07 nach HS-06 | offen |
| HS-06-P18 | Touch-Ziele (Designsystem) | alle Tasten und Felder mindestens `Size.Touch.Min`, Standard `Size.Touch.Default`; Felder in der Grafik: Höhe `Size.Touch.Default`, Breite mindestens `Size.Touch.Min` und so breit wie der Wert samt Einheit erfordert (Wertbreite); Positionen und Abstände ergeben sich aus dem Raster der Grafik (Skalierung mit `Viewbox`), der Abstand zwischen zwei Feldern bleibt bei 1920 × 1080 mindestens `Size.Touch.Gap` | offen |
| HS-06-P19 | Zweiter Kanal (Designsystem) | Ein/Aus und Spülanwahl über Symbol und Wort, Schloss/Schlüssel, Fehler mit Symbol und Text; keine rote Wertschrift, keine grüne Taste | offen |
| HS-06-P20 | Tokens und Grafikfarben (Designsystem) | Karton und Leim nur mit `Brush.Graphic.Carton`, `Brush.Graphic.Glue`, `Brush.Graphic.Outline`; keine Hex-, Pixel- oder Literaltexte; Kontraste der Grafik mindestens 3 : 1 | offen |
| HS-06-P21 | Hell-/Dunkelthema und Skalierung | beide Themen ohne Layoutänderung; die Grafik skaliert mit dem Seitenverhältnis des Zuschnitts, die Felder behalten Touch-Größe; kein Scrollen bei 1920 × 1080 | offen |

## Offene Punkte
- OP-15: Zuordnung DS-05 zu RS-06 (Design „Ein / Aus“ unter „Karton“, Referenz „Heißleimauftrag abwählen“; hier Beschriftung „Ein / Aus“ in der Gruppe „Karton“, Funktion als Hilfetext).
- OP-19: Einheit und Bedeutung der 18 Leimspurwerte; Zuordnung der Felder zu Anfang und Ende der Spuren (hier Annahme).
- OP-20: Zwischenseite „Zuführungen“ (HS-40, A-33).
- OP-25, OP-04: Berechtigungsstufen, Schlüsselsymbol.
- OP-27: Farb- und Zustandsbedeutung der Tasten (Ein/Aus, Anwahl Spülen).
- OP-28, OP-29: Wertebereiche, Standardwerte, Einheiten (ms, s, °).
- OP-30: Eingabe-Pop-up undokumentiert.
- OP-31: Sperrzustände und Rückfragen nicht beschrieben.
- OP-36: Zugang „Heißleimgerät“ (Sprungziel HS-07 abgeleitet).
- OP-39: Aus-Zustände und gewählte Zustände nur mit einem Zustand im Bild.
- OP-46: Ventilbezeichnungen 3Y25 bis 3Y29 (Bezug zu Leimspuren/Düsen unklar), Auswirkung der Ein/Aus-Taste.
- OP-08, OP-21, OP-22: Seitenleisten-Symbole, Antippbarkeit, identische Rahmenwerte (Design).
