# HS-17 – Motorparameter (Schließmaschine)
- Quelle: Referenz [RS-17](../../02_Referenz-Analyse/Seiten/RS-17_Motorparameter-Schliessmaschine.md) (Handbuchtabellen T25, T26; Bild [RS-17_01](../../02_Referenz-Analyse/Medien/RS-17_01.png), identisch mit RS-12_01 und RS-20_01). Design: keine Design-Seite; Aufbau aus [Designsystem](../Designsystem.md) und [HM-21](../Module/HM-21_Motorparameter-Karte.md) (drei Karten 4 : 4 : 4); gleicher Aufbau wie [HS-12](../Seiten/HS-12_Motorparameter.md) und [HS-20](../Seiten/HS-20_Motorparameter.md).
- Navigationspfad: **Einstellung › Schließmaschine › Motorparameter** (Brotkrümel laut [Navigation.md](../Navigation.md), Abschnitt 2). Zugang: [HS-16](HS-16_Schliessmaschine.md) Funktionsleiste „Motorparameter“ (Annahme A-37, Lücke 6.2). Zurück-Ziel: HS-16. PageKey `ClosingMotor`, Route `settings/closing/motor`, Mindestrolle „–“.

## Zweck
Konfiguration der Bewegungsparameter für den **Verschluss** (Zu und Auf) und die **Schnecke**. Wortgetreu (RS-17): „Auf dieser Seite werden die Bewegungsparameter für den Verschluss und die Schnecke eines Schneckendosierers konfiguriert. Die Einstellungen ermöglichen eine optimale Anpassung an das Produktverhalten und die Maschinengeschwindigkeit.“ Der Text ist identisch mit RS-12 und RS-20; der Bezug zur Schließmaschine bleibt fachlich offen (OP-45, OP-55).

## Aufbau (Bereiche, Layout)
Inhaltsbereich des Rahmen-Grids (Zeile 34\* von 45\*, Außenrand `Size.Content.Margin`, 12-Spalten-Raster, Gutter `Space.M`). Eine Zeile mit drei Karten in den Spalten **4 : 4 : 4**: **Verschluss Zu | Verschluss Auf | Schnecke**. Die Karten sind Instanzen von [HM-21](../Module/HM-21_Motorparameter-Karte.md) mit Rahmen [HM-15](../Module/HM-15_Gruppenbereich.md); jede Zeile besteht aus Beschriftung (links) und Eingabefeld (rechts, Höhe `Size.Touch.Default`, Zeilenabstand `Size.Touch.Gap`).

```
Inhaltsbereich (12 Spalten)
+----------------------+----------------------+----------------------+
| Verschluss Zu    (4) | Verschluss Auf   (4) | Schnecke         (4) |
| Position:            | Position:            | [Symbol Schnecke]    |
| [ 0 °            K ] | [ 37 °           K ] | Beschleunigung:      |
| Geschwindigkeit:     | Geschwindigkeit:     | [ 0 %            K ] |
| [ 80 %           K ] | [ 80 %           K ] | Verzögerung:         |
| Beschleunigung:      | Beschleunigung:      | [ 0 %            K ] |
| [ 0 %            K ] | [ 0 %            K ] | Ruck:                |
| Verzögerung:         | Verzögerung:         | [ 0 %            K ] |
| [ 0 %            K ] | [ 0 %            K ] |                      |
| Ruck:                | Ruck:                |                      |
| [ 0 %            K ] | [ 0 %            K ] |                      |
+----------------------+----------------------+----------------------+
Funktionsleiste: leer (sichtbar)
K = Schlüsselsymbol (Icon.Key, oben rechts im Feld)
```

- Die Schneckenkarte hat drei Zeilen und oben das Symbol `Icon.Motor.Screw` neben der Überschrift (aus HM-21); darunter bleibt die Karte leer (Inhaltshöhe).
- Das Referenzbild ordnet „Schnecke“ mittig unter den beiden Verschlusskarten an; das neue Layout stellt die drei Karten nebeneinander (HM-21: Raster 4 : 4 : 4), damit der Aufbau auf HS-12, HS-17 und HS-20 identisch ist.
- Die HM-21-Eigenschaft `DoserName` ist „Schließmaschine“ (kein Dosierer-Zusatz wie „HD1“).
- Alle 13 Felder zeigen den Wert in `Font.Size.Value` `Font.Weight.Strong` (nicht rot) mit der Einheit hinter dem Wert.
- Funktionsleiste: **leer, aber sichtbar** (Navigation.md Abschnitt 3.3, „Ohne eigene Tasten“). Die Taste „»“ des Referenzbilds entfällt (Begründung unten).

## Elemente (Tabelle: Element | Typ | Funktion | verwendetes Modul)
Spalte „Herkunft“ = Rückverfolgung auf [RS-17](../../02_Referenz-Analyse/Seiten/RS-17_Motorparameter-Schliessmaschine.md). Wertebereiche und Standardwerte sind im Handbuch nicht angegeben (OP-28); die Bildwerte sind Beispielwerte, im neuen HMI Standard-/Dummywerte mit konfigurierbaren Grenzen.

### Karte „Verschluss Zu“ und Karte „Verschluss Auf“ (je 5 Zeilen, T25; Gruppe erscheint zweimal)
| Nr. | Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-17) |
|---|---|---|---|---|---|
| E01 | Karte „Verschluss Zu“ | Karte (Kartenart Verschluss, `ClosureClosed`) | bündelt die fünf Parameter der Bewegung „Verschluss zu“ | [HM-21](../Module/HM-21_Motorparameter-Karte.md) mit [HM-15](../Module/HM-15_Gruppenbereich.md) | Bild: Gruppenfeld „Verschluss Zu“; T25 |
| E02 | Position Zu (Bild 0 °) | Eingabefeld, Zahl, Einheit °, Schlüsselsymbol | Position in Grad, an der der Verschluss geschlossen ist | [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) (in HM-21), Pop-up [HM-13](../Module/HM-13_Eingabe-Pop-up.md) | T25, Zeile „Position“ (Gruppe Zu) |
| E03 | Geschwindigkeit Zu (Bild 80 %) | Eingabefeld, Zahl, Einheit %, Schlüsselsymbol | Bewegungsgeschwindigkeit des Aktors in Prozent | HM-12 (in HM-21) | T25, Zeile „Geschwindigkeit“ (Zu) |
| E04 | Beschleunigung Zu (Bild 0 %) | Eingabefeld, Zahl, Einheit %, Schlüsselsymbol | Anstieg der Geschwindigkeit beim Start der Bewegung | HM-12 (in HM-21) | T25, Zeile „Beschleunigung“ (Zu) |
| E05 | Verzögerung Zu (Bild 0 %) | Eingabefeld, Zahl, Einheit %, Schlüsselsymbol | Abbremsen vor Erreichen der Endposition | HM-12 (in HM-21) | T25, Zeile „Verzögerung“ (Zu) |
| E06 | Ruck Zu (Bild 0 %) | Eingabefeld, Zahl, Einheit %, Schlüsselsymbol | Änderung der Beschleunigung (sanfter Bewegungsbeginn und -ende) | HM-12 (in HM-21) | T25, Zeile „Ruck“ (Zu) |
| E07 | Karte „Verschluss Auf“ | Karte (Kartenart Verschluss, `ClosureOpen`) | bündelt die fünf Parameter der Bewegung „Verschluss auf“ | [HM-21](../Module/HM-21_Motorparameter-Karte.md) mit [HM-15](../Module/HM-15_Gruppenbereich.md) | Bild: Gruppenfeld „Verschluss Auf“; T25 |
| E08 | Position Auf (Bild 37 °) | Eingabefeld, Zahl, Einheit °, Schlüsselsymbol | Position in Grad, an der der Verschluss geöffnet ist | HM-12 (in HM-21) | T25, Zeile „Position“ (Gruppe Auf) |
| E09 | Geschwindigkeit Auf (Bild 80 %) | Eingabefeld, Zahl, Einheit %, Schlüsselsymbol | Bewegungsgeschwindigkeit des Aktors in Prozent | HM-12 (in HM-21) | T25, Zeile „Geschwindigkeit“ (Auf) |
| E10 | Beschleunigung Auf (Bild 0 %) | Eingabefeld, Zahl, Einheit %, Schlüsselsymbol | Anstieg der Geschwindigkeit beim Start der Bewegung | HM-12 (in HM-21) | T25, Zeile „Beschleunigung“ (Auf) |
| E11 | Verzögerung Auf (Bild 0 %) | Eingabefeld, Zahl, Einheit %, Schlüsselsymbol | Abbremsen vor Erreichen der Endposition | HM-12 (in HM-21) | T25, Zeile „Verzögerung“ (Auf) |
| E12 | Ruck Auf (Bild 0 %) | Eingabefeld, Zahl, Einheit %, Schlüsselsymbol | Änderung der Beschleunigung (sanfter Bewegungsbeginn und -ende) | HM-12 (in HM-21) | T25, Zeile „Ruck“ (Auf) |

### Karte „Schnecke“ (3 Zeilen, T26)
| Nr. | Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-17) |
|---|---|---|---|---|---|
| E13 | Karte „Schnecke“ mit Symbol | Karte (Kartenart Schnecke, `Screw`), Symbol `Icon.Motor.Screw` | bündelt die drei Parameter der Schnecke | [HM-21](../Module/HM-21_Motorparameter-Karte.md) mit [HM-15](../Module/HM-15_Gruppenbereich.md) | Bild: Gruppenfeld „Schnecke“ mit Piktogramm der Förderschnecke; T26 |
| E14 | Beschleunigung Schnecke (Bild 0 %) | Eingabefeld, Zahl, Einheit %, Schlüsselsymbol | Anstieg der Drehgeschwindigkeit beim Start | HM-12 (in HM-21) | T26, Zeile „Beschleunigung“ |
| E15 | Verzögerung Schnecke (Bild 0 %) | Eingabefeld, Zahl, Einheit %, Schlüsselsymbol | Abbremsen der Drehung beim Stoppen | HM-12 (in HM-21) | T26, Zeile „Verzögerung“ |
| E16 | Ruck Schnecke (Bild 0 %) | Eingabefeld, Zahl, Einheit %, Schlüsselsymbol | Änderung der Beschleunigung für eine produktschonende Bewegung | HM-12 (in HM-21) | T26, Zeile „Ruck“ |

### Rahmenelemente (aus dem Rahmen-Grid, nicht seitenspezifisch)
| Nr. | Element | Typ | Funktion | verwendetes Modul | Herkunft (RS-17) |
|---|---|---|---|---|---|
| R01 | Logo, Uhrzeit 13:02:24, Datum 12.05.2025 | Anzeige | Kopfzeile (Dummy-Daten) | [HM-02](../Module/HM-02_Kopfzeile.md) | Rahmenelemente: Kopfzeile |
| R02 | Seitentitel „Motorparameter HD1“ | Anzeige | letztes Brotkrümel-Segment „Einstellung › Schließmaschine › Motorparameter“; der Zusatz „HD1“ des Bildes entfällt (Bildkopie von HS-12, OP-33), Objektkennung leer | [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) | Bild: Titel; RS-17 offener Punkt 2 |
| R03 | Rundes Wirbelsymbol | – | entfällt als eigenes Element (OP-26) | [HM-02](../Module/HM-02_Kopfzeile.md) | Bild: Wirbelsymbol |
| R04 | Meldezeile „\*450\* Palettierung nicht bereit“ | Anzeige, Statusfarbe mit Symbol und Schweregradwort | zeigt die anstehende Meldung („450: Palettierung nicht bereit“, Dummy); Antippen öffnet HS-38 | [HM-03](../Module/HM-03_Meldezeile.md) | Rahmenelemente: Meldezeile |
| R05 | Taste „»“ (links unten, grau) | Taste | **entfällt**: Blättern HD 1 ⇄ HD 2 gibt es nur in HS-11/HS-12; Schließmaschine hat keine Dosierer und das Bild ist eine Kopie von RS-12 (Navigation.md Abschnitt 3.3, A-37, A-44). Die Funktionsleiste bleibt leer | [HM-06](../Module/HM-06_Funktionsleiste.md) (leer) | Rahmenelemente: Taste „»“ |
| R06 | Schloss-Symbol | Anzeige/Bedienung | Seitenleiste: Benutzerkennung mit `Icon.Key`/`Icon.Lock`, Benutzer-Pop-up | [HM-01](../Module/HM-01_Seitenleiste.md) | Rahmenelemente: Schloss-Symbol |
| R07 | Tasten „Produktion“, „Einstellungen“, „Zurück“ | Navigation | Seitenleiste: „Home“ → HS-01, „Einstellungen“ → HS-04 (hervorgehoben), „Zurück“ → Verlauf (HS-16) | [HM-01](../Module/HM-01_Seitenleiste.md) | Rahmenelemente: Tasten „Produktion“, „Einstellungen“, „Zurück“ |
| R08 | Kennzahlen Geschwindigkeit und Maschinenwinkel | Anzeige | Rahmen des Designs, in der Referenz nicht vorhanden | [HM-05](../Module/HM-05_Kennzahl-Kachel.md) | Design-Rahmen |

## Verwendete Module (IDs)
- [HM-01](../Module/HM-01_Seitenleiste.md) – Seitenleiste
- [HM-02](../Module/HM-02_Kopfzeile.md) – Kopfzeile
- [HM-03](../Module/HM-03_Meldezeile.md) – Meldezeile
- [HM-04](../Module/HM-04_Brotkruemel-Navigation.md) – Brotkrümel-Navigation
- [HM-05](../Module/HM-05_Kennzahl-Kachel.md) – Kennzahl-Kachel
- [HM-06](../Module/HM-06_Funktionsleiste.md) – Funktionsleiste unten (leer)
- [HM-12](../Module/HM-12_Eingabefeld-Schluesselsymbol.md) – Eingabefeld mit Schlüsselsymbol (in HM-21)
- [HM-13](../Module/HM-13_Eingabe-Pop-up.md) – Eingabe-Pop-up
- [HM-14](../Module/HM-14_Popup-Rahmen.md) – Pop-up-Rahmen (trägt HM-13)
- [HM-15](../Module/HM-15_Gruppenbereich.md) – Gruppenbereich (in HM-21)
- [HM-21](../Module/HM-21_Motorparameter-Karte.md) – Motorparameter-Karte

## Zustände und Interaktion (inkl. Pop-ups, Berechtigungen, Fehlerfälle)
**Eingabe.** Antippen eines Felds (E02 bis E06, E08 bis E12, E14 bis E16) öffnet das Eingabe-Pop-up (HM-13 in HM-14) mit Feldname (z. B. „Verschluss Zu – Position“), vorbelegtem Wert, Einheit und Grenzen. „Übernehmen“ nur bei gültigem Wert; „Abbrechen“ verwirft; Antippen außerhalb schließt nicht. Das Feld zeigt während der Eingabe `Border.Thick` `Brush.Border.Focus`. Ungültiger Wert: Fehlerzustand mit `Icon.Status.Error` und Fehlertext (Grenzen Dummy, OP-28). Grenzen: Positionen in °, alle anderen in %; die Bezugsgröße der Prozentwerte ist fachlich offen (OP-45).

**Hilfetexte.** Jede Zeile trägt die Beschreibung aus T25/T26 als Hilfetext (Tooltip, HM-21); auf Touch erscheint er beim Halten der Beschriftung (S17-2).

**Berechtigungen.** Alle 13 Felder tragen das Schlüsselsymbol (`Icon.Key`, `Brush.Text.Primary`). Rollen und Stufen sind Dummy (OP-04, OP-25). Ohne ausreichende Rolle gilt Navigation.md 4.1: `Icon.Lock`, Hinweis „Berechtigung erforderlich: <Rolle>“ und Benutzer-Pop-up zur Anmeldung; das Eingabe-Pop-up öffnet erst nach der Anmeldung.

**Sperrzustände.** Läuft die Maschine in einem Zustand, in dem Änderungen nicht zulässig sind (Dummy, OP-31), erscheinen die Felder deaktiviert (gestrichelte Kontur, `Brush.Text.Disabled`, `Icon.Block`); Tippen nennt den Grund in der Meldezeile (A-28).

**Navigation und Zurück.** Die Seite hat keine seitenspezifischen Tasten; „Zurück“ (Seitenleiste) führt im Verlauf zu HS-16. Die Segmente „Einstellung“ und „Schließmaschine“ im Brotkrümel sind antippbar (HS-04 bzw. HS-16, Verlauf wird gekürzt). Die Seitenleisten-Taste „Einstellungen“ ist hervorgehoben. Bei offenem Pop-up sind Seitenleiste, Brotkrümel und Seiteninhalt gesperrt. Der Dosierer-Wechsel HD 1 ⇄ HD 2 existiert hier nicht.

**Fehlerfälle.** Wertebereichsverletzung (siehe oben); Meldungen der Steuerung in der Meldezeile; weitere Rückmeldungen oder Fehlermeldungen sind im Handbuch nicht beschrieben (nichts erfunden).

## Prüfpunkte (Tabelle: ID | Prüfung | erwartetes Ergebnis | Status)
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| HS-17-P01 | Titel und Pfad (RS-17-P01) | Brotkrümel „Einstellung › Schließmaschine › Motorparameter“; Seitenname „Motorparameter“ (ohne „HD1“); „Einstellung“ und „Schließmaschine“ antippbar | offen |
| HS-17-P02 | Karten (RS-17-P02) | drei Karten „Verschluss Zu“, „Verschluss Auf“, „Schnecke“ im Raster 4 : 4 : 4 in dieser Reihenfolge | offen |
| HS-17-P03 | Verschluss: Felder (RS-17-P03) | je Verschlusskarte fünf Felder in der Reihenfolge Position, Geschwindigkeit, Beschleunigung, Verzögerung, Ruck | offen |
| HS-17-P04 | Position (RS-17-P04) | Einheit ° (Grad); Hilfetext: Position in Grad, an der der Verschluss geöffnet bzw. geschlossen ist | offen |
| HS-17-P05 | Geschwindigkeit (RS-17-P05) | Einheit %; Hilfetext: Bewegungsgeschwindigkeit des Aktors in Prozent | offen |
| HS-17-P06 | Beschleunigung, Verzögerung, Ruck Verschluss (RS-17-P06) | Einheit %; Hilfetexte gemäß T25 (Anstieg beim Start; Abbremsen vor Endposition; Änderung der Beschleunigung) | offen |
| HS-17-P07 | Schnecke: Felder (RS-17-P07) | drei Felder Beschleunigung, Verzögerung, Ruck, Einheit %, Symbol `Icon.Motor.Screw` an der Karte | offen |
| HS-17-P08 | Schnecke: Beschreibungen (RS-17-P08) | Hilfetexte: Anstieg der Drehgeschwindigkeit beim Start; Abbremsen der Drehung beim Stoppen; Änderung der Beschleunigung für eine produktschonende Bewegung | offen |
| HS-17-P09 | Schlüsselsymbole (RS-17-P09) | alle 13 Felder tragen `Icon.Key` | offen |
| HS-17-P10 | Untere Leiste und Rahmentasten (RS-17-P10) | Funktionsleiste leer, aber sichtbar; Taste „»“ entfällt mit Begründung (A-37, A-44); Schloss/Benutzerkennung, „Produktion“, „Einstellungen“, „Zurück“ in der Seitenleiste | offen |
| HS-17-P11 | Beispielwerte (RS-17-P11) | Zu: 0 ° / 80 % / 0 % / 0 % / 0 %; Auf: 37 ° / 80 % / 0 % / 0 % / 0 %; Schnecke 0 % / 0 % / 0 % | offen |
| HS-17-P12 | Bildabgleich (RS-17-P12) | jedes Element des Bildes [RS-17_01](../../02_Referenz-Analyse/Medien/RS-17_01.png) ist in der Elementtabelle (E01 bis E16, R01 bis R08) wiederzufinden | offen |
| HS-17-P13 | Touch-Ziele | alle 13 Felder ≥ `Size.Touch.Default` hoch, Abstand ≥ `Size.Touch.Gap`; keine Ziele < `Size.Touch.Min` | offen |
| HS-17-P14 | Zweiter Kanal | Fehler mit Symbol und Text; Schloss/Schlüssel als Symbol; deaktiviert gestrichelt; Werte nicht rot | offen |
| HS-17-P15 | Tokens | keine Hex- oder Pixelwerte; nur Tokens des Designsystems; Karten und Felder aus HM-21, HM-12, HM-15 (keine Kopien) | offen |
| HS-17-P16 | Berechtigung | ohne Rolle (Navigation.md 4.1): `Icon.Lock`, Hinweis „Berechtigung erforderlich: <Rolle>“ und Benutzer-Pop-up; Eingabe-Pop-up öffnet nicht vor der Anmeldung | offen |
| HS-17-P17 | Eingabe-Pop-up | öffnet mit Feldname, Wert, Einheit, Grenzen; ungültiger Wert sperrt „Übernehmen“ | offen |
| HS-17-P18 | Layout ohne Scrollen | drei Karten (längste mit Überschrift und fünf Zeilen) passen bei 1920 × 1080 in 768 px Inhaltshöhe | offen |
| HS-17-P19 | Zurück | „Zurück“ führt im Verlauf zu HS-16; bei offenem Pop-up gesperrt | offen |
| HS-17-P20 | Identität mit HS-12/HS-20 | identischer Aufbau (HM-21-P06); kein Dosierer-Wechsel (kein „«“/„»“) | offen |
| HS-17-P21 | Texte | alle sichtbaren Texte aus `.resx` | offen |

## Annahmen dieser Seite
- **S17-1:** Karten im Raster 4 : 4 : 4 (Zu | Auf | Schnecke) nach HM-21; das Bild stellt „Schnecke“ unter die Verschlusskarten.
- **S17-2:** Die Handbuchbeschreibung je Zeile ist Hilfetext (Tooltip, HM-21); auf Touch erscheint er beim Halten der Beschriftung.
- **S17-3:** Der Seitenname lautet „Motorparameter“ ohne „HD1“ (OP-33); die HM-21-Eigenschaft `DoserName` ist „Schließmaschine“, die Objektkennung im Brotkrümel bleibt leer.
- **S17-4:** Die Taste „»“ des Bildes entfällt (A-37, A-44); die Funktionsleiste bleibt leer.

## Offene Punkte
Seiten-Index der [Offene-Punkte.md](../../00_Plan/Offene-Punkte.md) für RS-17: OP-23, OP-25, OP-28, OP-33, OP-39, OP-45, OP-55.
- **OP-23:** Elternseite im Handbuch nicht beschrieben; Annahme A-37 (Taste „Motorparameter“ in HS-16).
- **OP-25:** Bedeutung und Stufe der Schlüsselsymbole offen.
- **OP-28:** Wertebereiche und Standardwerte fehlen; Beispielwerte aus dem Bild, Dummy-Grenzen.
- **OP-33:** Bildtitel „Motorparameter HD1“ gegen Kapitelname „Motorparameter“; Kapitelname gilt.
- **OP-39:** Fehlende Zustände (Aus, gesperrt) nicht im Bild; nach Designsystem dargestellt.
- **OP-45:** „Schneckendosierer“ im Beschreibungstext bei der Schließmaschine, Bezugsgröße der Prozentwerte unklar.
- **OP-55:** RS-12, RS-17 und RS-20 nutzen dasselbe Bild; Seite als eigene Seite geführt. Klärt sich eine Dublette, entfällt HS-17 samt Taste in HS-16 (A-37).
