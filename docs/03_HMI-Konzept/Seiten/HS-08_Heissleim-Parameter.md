# HS-08 – Heißleim Parameter

- Quelle: [RS-08](../../02_Referenz-Analyse/Seiten/RS-08_Heissleim-Parameter.md) (Handbuch Kapitel 8, Tabelle T11, Zonenliste als Fließtext und Bild [RS-08_01](../../02_Referenz-Analyse/Medien/RS-08_01.png)). Es gibt keine Design-Seite; Aufbau und Optik sind aus dem [Designsystem](../Designsystem.md), den Modulen und der Schwesterseite [HS-07](HS-07_Heissleim-Nordson.md) (Design [DS-03](../../01_Design-Analyse/Seiten/DS-03_Heissleim.md)) abgeleitet.
- Navigationspfad: Einstellung › Zuführungen › Heißleim › Temperatur (Brotkrümel laut [Navigation.md](../Navigation.md), Abschnitt 2; vier Segmente = größte Tiefe). Zugang: Funktionsleiste „Temperatur“ in [HS-07](HS-07_Heissleim-Nordson.md) (abgeleitet, A-14, OP-36). Zurück-Ziel: HS-07. PageKey `HotGlueParameters`, Route `settings/feeders/hotglue/parameters`, Mindestrolle: jeder angemeldete Benutzer.
- Seitentitel (Ressource `Nav_HotGlueParameters_Title`): „Heißleim Parameter“ (Kapitelname und Bildtitel der Referenz identisch). Das Brotkrümel-Segment trägt die Beschriftung des Designs („Temperatur“, Funktionsleisten-Taste in HS-07). Im Inhaltsbereich steht kein eigener Titel.

## Zweck

Wortgetreu (Handbuch): „Auf der Seite Heißleim Parameter werden globale Temperatureinstellungen festgelegt und die Temperaturzonen konfiguriert.“

Die Seite enthält vier globale Einstellwerte (Standby-Absenkung, Bereitschaftsverzögerung, Über- und Untertemperatur-Toleranz) und die Liste aller Temperaturzonen des Heißleimgeräts mit Solltemperatur, Isttemperatur und einer Taste je Zone zum Ab- und Wiederanwählen.

## Aufbau (Bereiche, Layout)

Rahmen wie im Designsystem Abschnitt 3.2. Der Inhaltsbereich nutzt das 12-Spalten-Raster; die Aufteilung ist aus dem Designsystem abgeleitet (zwei Gruppen **4 : 8**, linke Gruppe schmal, rechte Gruppe breit). Zeilen sind Stern-Anteile mit den Mindesthöhen der Module; keine festen Pixelpositionen. Die untere Funktionsleiste ist leer, aber sichtbar (Navigation.md 3.3).

```
Inhaltsbereich (12 Spalten)
+---------------------+--------------------------------------------------+
| Panel (HM-15)  4 Sp.| Panel (HM-15)                                8 Sp.|
| Globale Einstell.   | Temperaturzonen                                   |
|                     |         Soll:        Ist:       Status:           |
| Globale StandBy     | Tank      [150 °C (K)] [150 °C]  [Ausschalten]   |
| Temperatur Delta    | Schlauch 1[160 °C (K)] [160 °C]  [Ausschalten]   |
|  [ 56 °C     (K) ]  | Pistole 1 [170 °C (K)] [170 °C]  [Ausschalten]   |
|  Caption            | Schlauch 2[100 °C (K)] [  0 °C]  [Einschalten]   |
| Bereitschaft        | Pistole 2 [100 °C (K)] [  0 °C]  [Einschalten]   |
| Verzögerung [0 s]   | Verteiler [150 °C (K)] [150 °C]  [Ausschalten]   |
| Übertemperatur Delta|                                                   |
|  [ 15 °C     (K) ]  |                                                   |
| Untertemperatur     |                                                   |
| Delta [ 25 °C (K) ] |                                                   |
+---------------------+--------------------------------------------------+
Funktionsleiste: leer                               ((K) = Schlüsselsymbol)
```

| Bereich | Spalten / Zeilen | Inhalt |
|---|---|---|
| Linkes Panel „Globale Einstellungen“ | 4 von 12 Spalten; vier gleich aufgebaute Zeilen (Beschriftung über dem Feld, Eingabefeld mit Schlüssel, Caption mit dem Handbuchtext darunter) | die vier Felder aus RS-08 Tabelle T11 in der Reihenfolge links oben, links unten, rechts oben, rechts unten des Referenzbilds (Standby Delta, Bereitschaft Verzögerung, Übertemperatur Delta, Untertemperatur Delta) |
| Rechtes Panel „Temperaturzonen“ | 8 von 12 Spalten; Kopfzeile mit den Spaltenköpfen, darunter sechs Zonenzeilen; Spalten der Zeile 2 : 2 : 2 : 2 (Zonenname, Soll, Ist, Status) | alle sechs Zonen der Referenz in einer Liste (die Aufteilung in zwei Felder der Referenz entfällt, die Reihenfolge bleibt: Tank, Schlauch 1, Pistole 1, Schlauch 2, Pistole 2, Verteiler) |

Die Panel-Überschriften „Globale Einstellungen“ und „Temperaturzonen“ sind eine Ergänzung aus dem Zweck-Satz des Handbuchs („globale Temperatureinstellungen“, „Temperaturzonen“). Spaltenköpfe „Soll:“, „Ist:“, „Status:“ ohne Unterstreichung (Größe und Gewicht). Beispielwerte sind Dummy-Werte aus dem Bild (OP-28).

## Elemente

Spalte „Herkunft“ stellt die Rückverfolgung zu RS-08 her. Alle vier Zeilen von T11, alle sechs Zonen und alle Rahmenelemente sind enthalten.

### Rahmen

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Seitenleiste (Benutzerkreis, Home, Einstellungen, Meldungen, Zurück) | Rahmen | Navigation; „Zurück“ führt zu HS-07; Benutzerkreis ersetzt das gelbe Vorhängeschloss | [HM-01](../Module/HM-01_Seitenleiste.md) | RS-08 Rahmenelemente „Vorhängeschloss“, „Produktion/Einstellungen/Zurück“ (A-35) |
| Kopfzeile (Logo, Betriebsart, Uhrzeit/Datum) | Rahmen | Anzeige; das Wirbel-Symbol der Referenz entfällt (OP-26) | [HM-02](../Module/HM-02_Kopfzeile.md) | RS-08 Rahmenelemente „Kopfzeile“ |
| Meldezeile | Rahmen | aktuelle Meldung, Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | RS-08 Rahmenelemente „Meldezeile“ |
| Brotkrümel „Einstellung › Zuführungen › Heißleim › Temperatur“ | Navigation | Pfad; Segmente „Einstellung“, „Zuführungen“, „Heißleim“ antippbar (HS-04, HS-40, HS-07); ersetzt den Bildtitel „Heißleim Parameter“ | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | RS-08 Aufbau Kopfzeile (Titel) |
| Kennzahlen Geschwindigkeit und Maschinenwinkel | Anzeige | Geschwindigkeit öffnet HS-03 | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | Rahmen des Designs (DS-03) |
| Funktionsleiste (leer) | Rahmen | bleibt sichtbar, keine seitenspezifischen Tasten; die Tasten „Temperatur“, „Druck“, „Zeitschaltuhr“ der Referenz-Seite RS-07 fehlen auch im Bild von RS-08 | [HM-06](../Module/HM-06_Funktionsleiste.md) | RS-08 Aufbau Punkt 5 (links leer) |

### Linkes Panel: globale Einstellungen (RS-08 Tabelle T11, vier Zeilen)

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Panel „Globale Einstellungen“ | Gruppenbereich (Panel mit Überschrift) | bündelt die vier Felder | [HM-15](../Module/HM-15_Gruppenbereich.md) | RS-08 „Oberer Bereich (blauer Hintergrund)“ |
| Globale Standby Temperatur Delta | Eingabefeld mit Schlüsselsymbol, Einheit °C (Dummy 56 °C, Standardwert laut RS-07) | „Wert um den alle Temperaturen reduziert werden, wenn das Heißleimgerät in Standby versetzt wird.“ (Caption, Wortlaut der Referenz; Beschriftung im Bild „Globale StandBy Temperatur Delta“.) Der Wert ist die Absenkung der Standby-Taste in HS-07 | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), Pop-up [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | RS-08 T11 Zeile 1 |
| Bereitschaft Verzögerung | Eingabefeld mit Schlüsselsymbol, Einheit s (Dummy 0 s) | „Sind alle Bedingungen für einen Betrieb erfüllt, wird erst nach Ablauf der Zeit das Bereitsignal gesendet.“ (Caption) | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | RS-08 T11 Zeile 2 |
| Übertemperatur Delta | Eingabefeld mit Schlüsselsymbol, Einheit °C (Dummy 15 °C) | „Ist eine Temperatur um diesen Betrag höher als die angegebene Solltemperatur wird die Bereitschaft zurückgenommen.“ (Caption) | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | RS-08 T11 Zeile 3 |
| Untertemperatur Delta | Eingabefeld mit Schlüsselsymbol, Einheit °C (Dummy 25 °C) | „Ist eine Temperatur um diesen Betrag niedriger als die angegebene Solltemperatur wird die Bereitschaft zurückgenommen.“ (Caption) | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | RS-08 T11 Zeile 4 |

### Rechtes Panel: Temperaturzonen (RS-08 Hauptbereich)

Wortgetreu (Handbuch): „Alle vorhandenen Zonen des Heißleimgeräts werden hier aufgelistet. Für jede Zone kann eine Solltemperatur festgelegt werden. Die Spalte Ist zeigt die aktuelle Temperatur der Zone an. Über die Tasten in der Spalte Status kann jeden Zone abgewählt werden.“ Jede Zeile ist eine [HM-28](../Module/HM-28_Temperaturzonen-Zeile.md) (Variante Heißleim), zusammengesetzt aus Soll ([HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md)), Ist ([HM-11](../Module/HM-11_Anzeigefeld.md)) und Statustaste ([HM-08](../Module/HM-08_Zustandstaste-Umschalter.md)).

| Element | Typ | Funktion | verwendetes Modul | Herkunft |
|---|---|---|---|---|
| Panel „Temperaturzonen“ mit Spaltenköpfen „Soll:“, „Ist:“, „Status:“ | Gruppenbereich, Spaltenköpfe (Text) | Gruppentitel und Spaltenbeschriftung | [HM-15](../Module/HM-15_Gruppenbereich.md) | RS-08 Hauptbereich (Spaltenköpfe, unterstrichen im Bild) |
| Zone „Tank“ | Zeile: Soll (Eingabe, °C, Schlüssel), Ist (Anzeige, °C), Statustaste | Dummy: Soll 150 °C, Ist 150 °C, Taste „Ausschalten“ | [HM-28](../Module/HM-28_Temperaturzonen-Zeile.md) | RS-08 Zonenliste Zeile 1 |
| Zone „Schlauch 1“ | wie oben | Dummy: Soll 160 °C, Ist 160 °C, Taste „Ausschalten“ | [HM-28](../Module/HM-28_Temperaturzonen-Zeile.md) | RS-08 Zonenliste Zeile 2 |
| Zone „Pistole 1“ | wie oben | Dummy: Soll 170 °C, Ist 170 °C, Taste „Ausschalten“ | [HM-28](../Module/HM-28_Temperaturzonen-Zeile.md) | RS-08 Zonenliste Zeile 3 |
| Zone „Schlauch 2“ | wie oben | Dummy: Soll 100 °C, Ist 0 °C, Taste „Einschalten“ (abgewählt) | [HM-28](../Module/HM-28_Temperaturzonen-Zeile.md) | RS-08 Zonenliste Zeile 4 |
| Zone „Pistole 2“ | wie oben | Dummy: Soll 100 °C, Ist 0 °C, Taste „Einschalten“ (abgewählt) | [HM-28](../Module/HM-28_Temperaturzonen-Zeile.md) | RS-08 Zonenliste Zeile 5 |
| Zone „Verteiler“ | wie oben | Dummy: Soll 150 °C, Ist 150 °C, Taste „Ausschalten“ (im Referenzbild im rechten Feld) | [HM-28](../Module/HM-28_Temperaturzonen-Zeile.md) | RS-08 Zonenliste Zeile 6 (rechtes Feld) |
| Spalte „Soll“ (je Zone) | Eingabefeld mit Schlüsselsymbol, °C | legt die Solltemperatur der Zone fest; öffnet das Eingabe-Pop-up | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | RS-08 Spalte „Soll:“ |
| Spalte „Ist“ (je Zone) | Anzeigefeld, nur lesend, °C, ohne Schlüssel | zeigt die aktuelle Temperatur der Zone; bei abgewählter Zone „0 °C“ | [HM-11](../Module/HM-11_Anzeigefeld.md) | RS-08 Spalte „Ist:“ |
| Spalte „Status“ (je Zone) | Zustandstaste mit wechselnder Beschriftung „Ausschalten“/„Einschalten“ | wählt die Zone ab bzw. wieder an; zusätzlich Symbol und Wort „Ein“/„Aus“ | [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) (Textumschaltung) | RS-08 Spalte „Status:“ |

Die Zonenliste ist konfigurationsabhängig (Anzahl und Namen, OP-41): Standard sind die sechs Zonen des Bildes; weitere Zonen werden in derselben Liste ergänzt (Scrollen bei Überlauf, Annahme).

## Verwendete Module

[HM-01](../Module/HM-01_Seitenleiste.md), [HM-02](../Module/HM-02_Kopfzeile.md), [HM-03](../Module/HM-03_Meldezeile.md), [HM-04](../Module/HM-04_Brotkruemel-Navigation.md), [HM-05](../Module/HM-05_Kennzahl-Kachel.md), [HM-06](../Module/HM-06_Funktionsleiste.md), [HM-08](../Module/HM-08_Zustandstaste-Umschalter.md) (über HM-28), [HM-11](../Module/HM-11_Anzeigefeld.md), [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md), [HM-13](../Module/HM-13_Eingabe-Pop-up.md), [HM-14](../Module/HM-14_Popup-Rahmen.md) (trägt HM-13), [HM-15](../Module/HM-15_Gruppenbereich.md), [HM-28](../Module/HM-28_Temperaturzonen-Zeile.md).

## Zustände und Interaktion

- **Statustaste je Zone:** schaltet die Zone ab bzw. wieder an („abgewählt“). Aktive Zone: Taste „Ausschalten“, `Icon.State.On` und Wort „Ein“. Abgewählte Zone: Taste „Einschalten“, `Icon.State.Off` und Wort „Aus“, Text der Zeile in `Brush.Text.Secondary`, Ist „0 °C“ ([HM-28](../Module/HM-28_Temperaturzonen-Zeile.md)). Die Farben der Referenz (grün = aktiv, rot = abgewählt) entfallen; der Zustand ist über Symbol, Wort und Tastentext lesbar. Das Verhalten bei Standby und bei ausgeschalteten Heizungen ist nicht beschrieben (OP-46).
- **Zone mit Fehler oder nicht bereit** (Annahme, [HM-28](../Module/HM-28_Temperaturzonen-Zeile.md)): Zeile mit `Brush.Status.Error.Subtle`, `Icon.Status.Error` und Wort „Fehler“.
- **Bereitschaft:** Wird zurückgenommen, wenn eine Temperatur um „Übertemperatur Delta“ über oder um „Untertemperatur Delta“ unter der Solltemperatur liegt. Das Bereitsignal folgt erst nach Ablauf von „Bereitschaft Verzögerung“. Die Texte stehen als Captions unverändert bei den Feldern; die Auswirkung ist in HS-07 an der LED „Bereitschaft“ sichtbar.
- **Standby:** alle Temperaturen werden um „Globale Standby Temperatur Delta“ reduziert (Wirkung in HS-07, Taste „Standby“).
- **Eingabe:** Antippen eines Eingabefelds (vier globale Werte, sechs Solltemperaturen) öffnet das Eingabe-Pop-up ([HM-13](../Module/HM-13_Eingabe-Pop-up.md) im [HM-14](../Module/HM-14_Popup-Rahmen.md)) mit vorbelegtem Wert und Dummy-Grenzen; „Übernehmen“ nur bei gültigem Wert. Ungültige Eingabe: Fehlertext mit `Icon.Status.Error`.
- **Berechtigungen:** alle zehn Eingabefelder tragen das Schlüsselsymbol, die Ist-Felder und Statustasten nicht (wie Referenz). Ohne Rolle: `Icon.Lock` und Hinweis „Berechtigung erforderlich: <Rolle>“ (OP-04, OP-25).
- **Sperrzustände und Fehlerfälle:** durch den Betriebszustand gesperrte Elemente sind deaktiviert (gestrichelte Kontur, Grund in der Meldezeile, A-28). Bei gestörter Kommunikation zum Gerät (Annahme) zeigen Ist-Felder „---“ und alle Eingaben sind deaktiviert.
- **Navigation und Zurück:** „Zurück“ (Seitenleiste) führt zu HS-07; Segment „Heißleim“ im Brotkrümel springt dorthin, „Zuführungen“ zu HS-40, „Einstellung“ zu HS-04. Pop-ups stehen nicht im Verlauf; bei offenem Pop-up ist die Navigation gesperrt (Navigation.md 4.2).

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-08-P01 | Feld „Globale Standby Temperatur Delta“ (RS-08-P01) | Eingabefeld °C mit Schlüsselsymbol; Caption „Wert um den alle Temperaturen reduziert werden, …“; Beispielwert 56 °C | offen |
| HS-08-P02 | Feld „Bereitschaft Verzögerung“ (RS-08-P02) | Eingabefeld s mit Schlüsselsymbol; Beispielwert 0 s; Caption mit Wortlaut der Referenz | offen |
| HS-08-P03 | Feld „Übertemperatur Delta“ (RS-08-P03) | Eingabefeld °C mit Schlüsselsymbol; Beispielwert 15 °C | offen |
| HS-08-P04 | Feld „Untertemperatur Delta“ (RS-08-P04) | Eingabefeld °C mit Schlüsselsymbol; Beispielwert 25 °C | offen |
| HS-08-P05 | Zonenliste (RS-08-P05) | sechs Zonen in der Reihenfolge Tank, Schlauch 1, Pistole 1, Schlauch 2, Pistole 2, Verteiler; je Soll (Eingabe), Ist (Anzeige), Status (Taste) | offen |
| HS-08-P06 | Spalte Status (RS-08-P06) | Taste je Zone wählt die Zone ab/an; Beschriftung „Ausschalten“/„Einschalten“; Zustand zusätzlich über Symbol und Wort „Ein“/„Aus“, nicht nur über Farbe | offen |
| HS-08-P07 | Spalte Ist (RS-08-P07) | nur Anzeige in °C, ohne Schlüsselsymbol und nicht antippbar; abgewählte Zone „0 °C“ | offen |
| HS-08-P08 | Bereitschafts-Logik (RS-08-P08) | Texte zu Über-/Untertemperatur, Verzögerung und Standby stehen unverändert als Captions bei den Feldern | offen |
| HS-08-P09 | Brotkrümel (RS-08-P09) | „Einstellung › Zuführungen › Heißleim › Temperatur“ (Abweichung vom Referenzpfad ist in Navigation.md begründet); drei Segmente antippbar | offen |
| HS-08-P10 | Rückweg (RS-08-P10) | „Zurück“, „Home“, „Einstellungen“ und Benutzerkreis in der Seitenleiste; „Zurück“ führt zu HS-07 | offen |
| HS-08-P11 | Quellbezug (RS-08-P11) | RS-08 mit Bild RS-08_01 im Kopf der Seite verlinkt; jede Zeile von T11 und jede Zone steht in der Elemente-Tabelle | offen |
| HS-08-P12 | Funktionsleiste | leer, aber sichtbar; keine Tasten „Temperatur“, „Druck“, „Zeitplan“ | offen |
| HS-08-P13 | Aufteilung | Panels 4 : 8 Spalten von 12; keine festen Pixelpositionen | offen |
| HS-08-P14 | Zweiter Kanal (Designsystem 5) | Zone Ein/Aus, Fehler, Sperre und Schlüssel/Schloss mit Symbol oder Text zusätzlich zur Farbe | offen |
| HS-08-P15 | Farbe nur Status | keine rote Eingabewertschrift, kein gelber Schlüssel, keine grünen oder roten Statustasten | offen |
| HS-08-P16 | Touch (DSY-P04) | alle Eingabefelder und Statustasten mindestens `Size.Touch.Min`, Standard `Size.Touch.Default` hoch; Zeilenabstand mindestens `Size.Touch.Gap` | offen |
| HS-08-P17 | Tokens und Texte (DSY-P06, DSY-P07) | keine Hex- oder Pixelwerte, keine festen Texte im XAML; Captions und Wörter aus `.resx` | offen |
| HS-08-P18 | Eingabe-Pop-up | jedes Eingabefeld öffnet HM-13 im HM-14 mit vorbelegtem Wert; Seite dahinter gesperrt | offen |
| HS-08-P19 | Berechtigung | ohne Rolle: Schloss und Hinweis, kein Pop-up | offen |

## Offene Punkte

- OP-36: Zugang zur Seite im Handbuch nicht beschrieben, abgeleitet aus der Funktionsleiste von HS-07 (A-14).
- OP-25: Berechtigung (Schlüssel an Eingabefeldern, Rollen).
- OP-28: Wertebereiche und Standardwerte (außer Standby 56 °C) fehlen; Bildwerte sind Beispiele.
- OP-29: Einheit „Bereitschaft Verzögerung“ im Handbuch nicht genannt, Bild zeigt „0 s“.
- OP-41: Anzahl und Namen der Zonen gerätabhängig.
- OP-46: Verhalten der Statustaste bei Standby und Aus, Aufteilung der Zonen in zwei Felder der Referenz nicht begründet (im neuen Layout eine Liste).
- OP-16: weitere Pistolen und Schläuche (Design zeigt nur Pistole 1 und Schlauch 1).
