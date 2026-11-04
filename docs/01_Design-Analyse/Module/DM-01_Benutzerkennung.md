# DM-01 – Benutzerkennung

## Funktion
Zeigt den angemeldeten Benutzer: Kreis mit Initialen, darunter Name und Rolle. Oberster Teil der Seitenleiste (Rahmen, auf allen Seiten gleich).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)
| Name | Typ | Einheit | Wertebereich |
|---|---|---|---|
| Initialen | Text | – | 2 Zeichen (Bild: „MM“) |
| Name | Text | – | Vor- und Nachname (Bild: „Max Mustermann“, zweizeilig umbrochen) |
| Rolle | Text | – | Rollenname (Bild: „Technik“); weitere Rollen unbekannt (OP-04) |

## Zustände und Darstellung
| Zustand | Darstellung |
|---|---|
| Angemeldet | Kreis (im Bild orange `#ED7D31`) mit Initialen in Weiß; Name und Rolle als Text darunter |
| Abgemeldet / kein Benutzer | im Bild nicht dargestellt; Annahme: neutraler Kreis mit Text „Nicht angemeldet“ |

Name und Rolle stehen als Text und sind damit nicht farbabhängig. Im Bild sind Name (blassblau) und Rolle (ocker) auf Blau schwach kontrastiert; im neuen HMI ausreichenden Kontrast sicherstellen. Antippbarkeit (Benutzerwechsel) ist nicht erkennbar (OP-04).

## Verwendet auf Seiten (IDs)
- [DS-01](../Seiten/DS-01_Produktion.md) – Produktion
- [DS-02](../Seiten/DS-02_Einstellungen.md) – Einstellungen
- [DS-03](../Seiten/DS-03_Heissleim.md) – Heißleim
- [DS-04](../Seiten/DS-04_Dosierer.md) – Dosierer
- [DS-05](../Seiten/DS-05_Kartonzufuehrung.md) – Kartonzuführung

## Prüfpunkte
| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| DM-01-P01 | Initialen | Kreis mit „MM“ | offen |
| DM-01-P02 | Name | „Max Mustermann“ unter dem Kreis | offen |
| DM-01-P03 | Rolle | „Technik“ unter dem Namen | offen |
| DM-01-P04 | Lage | oben in der Seitenleiste, auf allen 5 Seiten identisch | offen |
