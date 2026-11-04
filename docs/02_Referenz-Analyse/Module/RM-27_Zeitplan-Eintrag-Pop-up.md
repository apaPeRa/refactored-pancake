# RM-27 – Zeitplan-Eintrag-Pop-up

## Funktion

Pop-up zum Anlegen, Bearbeiten und Löschen einer Phase der Zeitschaltuhr; alle klickbaren Bereiche in [RS-10](../Seiten/RS-10_Zeitschaltuhr.md) öffnen „ein Pop-Up mit derselben Struktur“. Titel „Neuer Eintrag:“ (auch beim Bearbeiten) bzw. „Absenkphase“.

Entsprechung im Design: keine (Element nur in der Referenz).

## Parameter / Daten (Name, Typ, Einheit, Wertebereich)

| Name | Typ | Einheit | Wertebereich / Beispiele |
|---|---|---|---|
| Aktion | Auswahlliste | – | „Heizphase“, „Absenkphase“ |
| Zeit aktiv | 2 Kontrollkästchen | – | je eines für Startzeit und Endzeit; mindestens eine Zeit muss aktiv sein |
| Startzeit | Zeit (hh:mm) | hh:mm | Bild 08:00; leer als „__:__“ |
| Endzeit / Stoppzeit | Zeit (hh:mm) | hh:mm | Bild 16:00; Beschriftung im Pop-up „Endzeit:“, im Handbuch „Stoppzeit“ |
| Unterelemente | Zähler mit Symbol | Stk | Anzahl untergeordneter Absenkphasen (Bild 0 bzw. 1) |
| Übernehmen | Taste (Haken) | – | speichert |
| Abbrechen | Taste (X) | – | schließt ohne Änderung |
| Eintrag löschen | Taste (Papierkorb) | – | Heizphase erst löschbar, wenn alle Absenkphasen gelöscht; Absenkphase direkt |

Wertebereiche, Standardwerte und Berechtigungen nennt das Handbuch grundsätzlich nicht; angegeben sind Beispielwerte aus den Seitenbildern, keine Vorgaben.

## Zustände und Darstellung

| Zustand | Darstellung / Verhalten |
|---|---|
| Neuanlage | Papierkorb nicht aktiv, Zeitfelder leer, Kontrollkästchen aus |
| Bearbeiten Heizphase | Papierkorb ausgegraut bei Unterelemente > 0 |
| Bearbeiten Absenkphase | Papierkorb aktiv |
| Fehler | Endzeit vor Startzeit u. ä. nicht beschrieben |

## Verwendet auf Seiten (IDs)

- [RS-10](../Seiten/RS-10_Zeitschaltuhr.md) – Zeitschaltuhr (9 Nennungen in den Elementtabellen)

## Prüfpunkte

| ID | Prüfung | erwartetes Ergebnis | Status |
|---|---|---|---|
| RM-27-P01 | Struktur | Aufbau wie RS-10_03 | offen |
| RM-27-P02 | Löschregel | Heizphase nur ohne Absenkphasen löschbar | offen |
| RM-27-P03 | Zeitfelder | Format hh:mm, mindestens eine Zeit aktiv | offen |
| RM-27-P04 | Verwendet-auf-Liste | alle 1 genannten Seiten verlinken zurück auf RM-27; Links lösen auf | offen |
