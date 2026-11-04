# DM-19 – Zustandstaste

## Funktion
Farbige Taste mit Beschriftung, die einen Zustand trägt (ein/aus, aktiv/inaktiv) und per Antippen umgeschaltet oder ausgelöst wird. Abgrenzung zu [DM-10](DM-10_Funktionstaste-grau.md): DM-10 grau, einmaliger Auslöser ohne Zustand.

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
| Name | Typ | Einheit | Wertebereich |
|---|---|---|---|
| Beschriftung | Text (`.resx`) | – | Heizung, Standby, Pumpe, Zeitplan, Schnell, Füllsystem, Manuell, Ein / Aus |
| Zustand | Aufzählung | – | Bild nur „grün“ (aktiv, vermutet); Ein/Aus-Zustände nicht erklärt (OP-14, OP-09) |
| Aktivierbar | Wahrheitswert | – | wahr/falsch |

## Zustände und Darstellung
| Zustand | Darstellung |
|---|---|
| Aktiv / Ein | grün `#70AD47` (Entwurf auch `#00FF00`), Text weiß bzw. schwarz; zusätzlich Symbol „Ein“ (Annahme) |
| Inaktiv / Aus | im Bild nicht dargestellt; Annahme: neutrale Fläche, Symbol „Aus“ |
| Sonderfall DS-03 „Manuell“ (rot `#FF0000`) und „Füllsystem“ (hellgrün) | Bedeutung unklar (OP-14); Rot nur für Alarm im neuen HMI, daher für „Manuell aktiv“ andere Kennzeichnung (Symbol/Text) |
| Gesperrt | im Bild nicht dargestellt |

Zustand wird nie nur über Farbe vermittelt (Agent.md Abschnitt 6): zusätzlich Symbol oder Text. Farben und Fasen des Entwurfs sind Schätzwerte bzw. PowerPoint-Artefakte und werden nicht übernommen. Abgrenzung der Namensdopplung: Das graue „Manuell“ in DS-04 ist DM-10.

## Verwendet auf Seiten (IDs)
- [DS-01](../Seiten/DS-01_Produktion.md) – Produktion
- [DS-03](../Seiten/DS-03_Heissleim.md) – Heißleim
- [DS-05](../Seiten/DS-05_Kartonzufuehrung.md) – Kartonzuführung

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DM-19-P01 | DS-03 | Heizung, Standby, Pumpe, Zeitplan (grün); Füllsystem (hellgrün); Manuell (rot) | offen |
| DM-19-P02 | DS-01 | Taste „Schnell“ grün in Kachel „Geschwindigkeit“ | offen |
| DM-19-P03 | DS-05 | Taste „Ein / Aus“ grün | offen |
| DM-19-P04 | Abgrenzung | graue Tasten sind DM-10 | offen |
| DM-19-P05 | Zustand | Ein und Aus unterscheidbar ohne Farbe | offen |
