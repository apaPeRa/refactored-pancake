# RM-11 – Aktionstaste

## Funktion

Taste ohne dauerhaften Zustand, die eine Aktion auslöst, in der Regel grau. Mit oder ohne Schlüsselsymbol. Auslöseverhalten als Parameter: einmaliges Antippen, Halten (Haltetaste), Dauerfunktion, Navigationsziel. Dazu zählen Funktionstasten (RS-02 „Reset“, RS-18 „Gewichtsanpassung“, RS-18 „Dosierer Auslösen manuell“), Kalibrier- und Servicetasten (RS-27, RS-36, RS-37), Jog-Tasten (RS-31), „Geber setzen“ (RS-32), „Werte schreiben“ (RS-25), „Regulierung −/+“ (RS-23), die Dosierertasten „Manuell“, „Entleeren“, „Eichdosierung“ (RS-11, RS-19), „Suchen“ (RS-30, RS-31, RS-33) und Seitenlink-Tasten („Einstellung Regulierung“, RS-11). Zustandsbehaftete Tasten sind [RM-10](RM-10_Umschalter-Taste.md).

Entsprechung im Design: [DM-10](../../01_Design-Analyse/Module/DM-10_Funktionstaste-grau.md).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Beschriftung | Text | – | z. B. „Reset“, „Schließen“, „Manuell“, „Entleeren“, „Eichdosierung“, „Jog+“, „Jog−“, „Geber setzen“, „Importieren“, „Alle exportieren“, „Liste exportieren“, „Export“, „Liste leeren“, „Filter“, „Alle anzeigen“, „Filter setzen“, „Nullpunkt setzen“, „Zähler löschen“, „Start Kalibrierung“, „Entlastet“, „Belastet“, „Suchen“ |
| Symbol | Grafik, optional | – | z. B. Zahnrad, Liniendiagramm, Liste, Pfeile |
| Auslöseverhalten | Aufzählung | – | Antippen / Halten (RS-02 Reset: „für eine kurze Zeit gehalten“; RS-07 Manuell: „solange die Taste betätigt wird“) / Dauer (RS-11 Entleeren: „bis der Vorgang abgebrochen wird“) |
| Schlüsselsymbol | Boolean | – | gelb oben rechts; Berechtigung nicht beschrieben (RS-13, RS-18, RS-23, RS-25, RS-27, RS-31, RS-32, RS-35, RS-37) |
| Ziel | Seiten-ID, optional | – | bei Seitenlink-Tasten (RS-11 → RS-23, RS-12) |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Bereit | grau (Bild) |
| Gedrückt | nicht dargestellt; Annahme: sichtbares Feedback |
| Gesperrt | nicht dargestellt (Annahme: nicht berechtigt) |
| Läuft | Dauerfunktion „Entleeren“ bis Abbruch; Rückmeldung nicht beschrieben |

## Verwendet auf Seiten (IDs)

- [RS-02](../Seiten/RS-02_Produktionszaehler.md) – Produktionszähler (Pop-up) (1 Nennung in den Elementtabellen)
- [RS-07](../Seiten/RS-07_Heissleim-Nordson.md) – Heißleim Nordson (1 Nennung in den Elementtabellen)
- [RS-11](../Seiten/RS-11_Hauptdosierer-1-und-2.md) – Hauptdosierer 1 & 2 (5 Nennungen in den Elementtabellen)
- [RS-13](../Seiten/RS-13_Kontrollwaage.md) – Kontrollwaage (2 Nennungen in den Elementtabellen)
- [RS-14](../Seiten/RS-14_Einzelgewichte.md) – Einzelgewichte (1 Nennung in den Elementtabellen)
- [RS-18](../Seiten/RS-18_Gewichtskorrektur-Schliessmaschine.md) – Gewichtskorrektur (Schließmaschine) (2 Nennungen in den Elementtabellen)
- [RS-19](../Seiten/RS-19_Nachdosierer.md) – Nachdosierer (6 Nennungen in den Elementtabellen)
- [RS-21](../Seiten/RS-21_Gewichtskorrektur.md) – Gewichtskorrektur (Nachdosierer) (4 Nennungen in den Elementtabellen)
- [RS-23](../Seiten/RS-23_Regulierung.md) – Regulierung (1 Nennung in den Elementtabellen)
- [RS-25](../Seiten/RS-25_Nocken.md) – Nocken (1 Nennung in den Elementtabellen)
- [RS-27](../Seiten/RS-27_Waagen-Kalibrieren.md) – Waagen Kalibrieren (6 Nennungen in den Elementtabellen)
- [RS-30](../Seiten/RS-30_Handbetrieb-Auswahl.md) – Handbetrieb Auswahl (1 Nennung in den Elementtabellen)
- [RS-31](../Seiten/RS-31_Handbetrieb.md) – Handbetrieb (3 Nennungen in den Elementtabellen)
- [RS-32](../Seiten/RS-32_Geber-setzen.md) – Geber setzen (1 Nennung in den Elementtabellen)
- [RS-33](../Seiten/RS-33_EA-Uebersicht.md) – EA-Übersicht (1 Nennung in den Elementtabellen)
- [RS-35](../Seiten/RS-35_Systemeinstellungen.md) – Systemeinstellungen (6 Nennungen in den Elementtabellen)
- [RS-36](../Seiten/RS-36_Service.md) – Service (3 Nennungen in den Elementtabellen)
- [RS-37](../Seiten/RS-37_Meldearchiv.md) – Meldearchiv (6 Nennungen in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-11-P01 | Auslöseverhalten | Halten/Tippen/Dauer entspricht dem Handbuchtext der Seite | offen |
| RM-11-P02 | Schlüsselsymbol | Tasten mit Schlüssel laut Bild gekennzeichnet | offen |
| RM-11-P03 | Abgrenzung | Zustandstasten sind RM-10, keine RM-11 | offen |
| RM-11-P04 | Sicherheitsrelevante Tasten | Tasten mit Anlageneingriff (RS-35, RS-37 „Liste leeren“): Sicherheitsabfrage im Handbuch nicht beschrieben | offen |
| RM-11-P05 | Verwendet-auf-Liste | alle 18 genannten Seiten verlinken zurück auf RM-11; Links lösen auf | offen |
