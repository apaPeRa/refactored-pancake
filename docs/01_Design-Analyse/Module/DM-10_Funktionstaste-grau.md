# DM-10 – Funktionstaste (grau)

## Funktion
Graue Taste mit Textbeschriftung für eine Funktion der Seite. Sie löst eine Aktion oder einen Seitenwechsel aus und **hat keinen Ein/Aus-Zustand**. Sitzt in der [Funktionsleiste](DM-09_Funktionsleiste.md) und in den [Dosierer-Karten](DM-20_Dosierer-Karte.md).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
| Name | Typ | Einheit | Wertebereich |
|---|---|---|---|
| Beschriftung | Text (`.resx`) | – | Beispiele: Schichtplan, Sprache, Temperatur, Druck, Zeitplan, **Manuell, Entleeren** (graue Tasten in DS-04) |
| Aktivierbar | Wahrheitswert | – | wahr/falsch (gesperrt) |
| Befehl | Aktion | – | Navigation, Pop-up oder Funktion; im Bild nicht erkennbar |

## Zustände und Darstellung
| Zustand | Darstellung |
|---|---|
| Normal | Grau `#A6A6A6`, Beschriftung dunkelgrau (im Entwurf auch weiß, DS-01/02) |
| Gedrückt | im Bild nicht dargestellt |
| Gesperrt | Hinweis: Hauptdosierer 2 in DS-04 zeigt hellere Schrift (OP-18); Annahme: Sperre zusätzlich durch Symbol (Schloss) oder Text, nicht nur durch hellere Schrift |

**Abgrenzung zu [DM-19](DM-19_Zustandstaste.md):** DM-10 ist ein einmaliger Auslöser (grau, neutral). DM-19 ist eine Taste mit Zustand (z. B. ein/aus), farbig. Die rote/farbige „Manuell“ in DS-03 ist DM-19; die graue „Manuell“ in DS-04 ist DM-10. Gleiche Beschriftung, verschiedene Module (OP-14, OP-15). Zustand wird nie nur über Farbe vermittelt (Agent.md Abschnitt 6): zusätzlich Symbol oder Text. Farben und Fasen des Entwurfs sind Schätzwerte bzw. PowerPoint-Artefakte und werden nicht übernommen.

## Verwendet auf Seiten (IDs)
- [DS-01](../Seiten/DS-01_Produktion.md) – Produktion
- [DS-02](../Seiten/DS-02_Einstellungen.md) – Einstellungen
- [DS-03](../Seiten/DS-03_Heissleim.md) – Heißleim
- [DS-04](../Seiten/DS-04_Dosierer.md) – Dosierer

DS-04: als Teil von [DM-20](DM-20_Dosierer-Karte.md) („Manuell“, „Entleeren“); in der Funktionsleiste ist DS-04 leer.

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DM-10-P01 | Beispiele | Schichtplan (DS-01), Sprache (DS-02), Temperatur/Druck/Zeitplan (DS-03), Manuell/Entleeren (DS-04) | offen |
| DM-10-P02 | Abgrenzung | rote „Manuell“ in DS-03 ist DM-19, graue „Manuell“ in DS-04 ist DM-10 | offen |
| DM-10-P03 | Kein Ein/Aus | keine Zustandsanzeige außer gesperrt | offen |
| DM-10-P04 | Gesperrt | Sperre nicht nur über hellere Farbe sichtbar | offen |
