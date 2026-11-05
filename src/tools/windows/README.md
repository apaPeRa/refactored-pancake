# Windows-Werkzeuge für Meilenstein 3

PowerShell-Skripte für die lokale Finalisierung unter Windows (`Task.md`, Meilenstein 3). Sie wurden in der Cloud nur **geschrieben**, nicht ausgeführt (kein Windows, kein PowerShell); beim ersten Lauf sind kleine Korrekturen möglich und gehören dann in dieses Verzeichnis. Die Ergebnisse der Prüfung stehen in [Pruefbericht_M3.md](../../../docs/04_Pruefung/Pruefbericht_M3.md), die Seitenliste in [M3_Abnahmematrix.md](../../../docs/04_Pruefung/M3_Abnahmematrix.md).

## Voraussetzungen

| Voraussetzung | Wert |
|---|---|
| Betriebssystem | Windows 10 oder 11 (x64) |
| SDK | **.NET SDK ab 8** (ein 9er/10er-SDK baut das Projekt ebenfalls, die .NET-8-Desktop-Laufzeit muss installiert sein), Download: <https://dotnet.microsoft.com/download/dotnet/8.0>; das SDK enthält das Windows-Desktop-Paket für WPF |
| PowerShell | Windows PowerShell 5.1 (vorinstalliert) oder PowerShell 7; bei gesperrter Ausführung einmalig `Set-ExecutionPolicy -Scope Process Bypass` |
| Netzwerk | nur für den ersten `dotnet restore` (NuGet: `CommunityToolkit.Mvvm`, `Microsoft.Extensions.DependencyInjection`, `Microsoft.Extensions.Hosting`) |
| Bildschirm für Aufnahmen | **1920 × 1080 bei 100 % Skalierung** (Windows: Einstellungen › System › Anzeige › Skalierung), ein Monitor, Taskleiste darf das Fenster verdecken (PrintWindow nimmt das Fenster unabhängig davon auf) |
| Git | optional, für den Branch (siehe unten) |

## Schritte

1. **Branch übernehmen** (Cloud-Branch der Session; Name aus dem Verwalter-Bericht bzw. `git branch -r`):
   ```
   git fetch origin
   git checkout <branch>
   ```
   `main` wird nicht verändert (Agent.md Abschnitt 3). Änderungen aus Meilenstein 3 auf demselben Branch committen.
2. **Bauen und starten** (PowerShell im Repository-Wurzelverzeichnis):
   ```
   .\src\tools\windows\Build-And-Run.ps1
   ```
   Das Skript prüft `dotnet --info` und das 8er-SDK, führt `dotnet restore` und `dotnet build -c Release` aus (Warnungen sind Fehler) und startet `src\ApaTec.Hmi\bin\Release\net8.0-windows\ApaTec.Hmi.exe`. Optionen: `-NoRun`, `-SkipRestore`, `-Clean`, `-Configuration Debug`, `-AppArgs '--page=Heaters','--theme=dark'`.
3. **Einzelne Seite ansehen** (Startparameter, siehe unten), z. B. `.\src\tools\windows\Build-And-Run.ps1 -AppArgs '--page=HotGlueNordson','--theme=dark'`.
4. **Screenshots aufnehmen** (Bildabgleich mit Design bzw. Referenz):
   ```
   .\src\tools\windows\Capture-Pages.ps1                      # alle 43 Seiten, hell und dunkel
   .\src\tools\windows\Capture-Pages.ps1 -Pages HS-01,HS-07 -Themes dunkel
   .\src\tools\windows\Capture-Pages.ps1 -IncludeDialogs      # zusätzlich die 10 Dialoge
   ```
   Das Skript startet die Anwendung je Seite und Thema, wartet auf das Fenster (`-SettleSeconds`, Standard 4 s), bringt den Clientbereich auf 1920 × 1080, nimmt ihn mit `PrintWindow` auf (Rückfall `CopyFromScreen`) und speichert nach `docs/04_Pruefung/Screenshots_M3/<HS-xx>_<hell|dunkel>.png` (Dialoge: `DLG-<Key>_<hell|dunkel>.png`). **Warnung** bei Auflösung ≠ 1920 × 1080, Skalierung ≠ 100 % oder abweichender Clientgröße; die Bilder taugen dann nicht für den Pixelvergleich. Der Aufnahmebereich ist der Clientbereich ohne Titelleiste.
5. **Prüfen** nach [M3_Abnahmematrix.md](../../../docs/04_Pruefung/M3_Abnahmematrix.md): je Seite Aufnahme mit Design (`src_Data/Design/`) bzw. Referenzbild (`docs/02_Referenz-Analyse/Medien/RS-xx_01.png`) vergleichen, Ergebnisse in der Matrix und in `Pruefbericht_M3.md` eintragen, Abweichungen korrigieren, Build erneut.

## Startparameter der Anwendung

`ApaTec.Hmi.exe [Parameter]`, ausgewertet in `StartupOptions.cs` und `Program.cs`. Groß-/Kleinschreibung ist gleichgültig; unbekannte oder fehlerhafte Werte erzeugen eine Warnung (Ausgabefenster, Standardfehlerausgabe) und werden ignoriert.

| Parameter | Wirkung |
|---|---|
| `--page=<PageKey>` | startet auf der Seite (nach Start HS-01 und Navigation dorthin, daher ist „Zurück“ möglich). Alle 43 Schlüssel aus `PageKeys.cs` (z. B. `HotGlueNordson`); es gibt keine Pflichtparameter, die Seiten starten mit ihrem Standardparameter. Mit zu niedriger Rolle (`Service`) erscheint das Benutzer-Pop-up |
| `--dialog=<DialogKey>` | öffnet nach dem Start den Dialog bzw. das Pop-up: `Input` (mit Beispielwert), `Search`, `User`, `Language`, `Recipe`, `Confirmation`, `ScheduleEntry`, `Filter`, `FileResult`, `PostDoserHints` sowie die Pop-up-Seiten `ProductionCounter` (HS-02) und `MachineSpeed` (HS-03). Zusammen mit `--page` liegt der Dialog über der Seite |
| `--theme=light\|dark` | Hell- oder Dunkelthema |
| `--culture=de-DE` | Kultur (Zahlen, Datum, Sprache der Texte); derzeit ist nur `de-DE` mit Ressourcen hinterlegt |
| `--role=operator\|technician\|service` | Rolle der Dummy-Sitzung (Standard: `operator`, A-96); `technician` schaltet Felder mit Schlüsselsymbol frei und HS-36 zugänglich |
| `--designdata` | reserviert für Dummy-Zustandsvarianten; derzeit ohne Wirkung, weil es zur Laufzeit keine Zustandsvarianten gibt (die Entwurfsdaten `DesignData/HM<nn>_DesignData.xaml` dienen nur dem Designer) |

Beispiele:
```
ApaTec.Hmi.exe --page=Service --role=technician --theme=dark
ApaTec.Hmi.exe --dialog=Input --theme=light
ApaTec.Hmi.exe --page=Heaters --dialog=Confirmation
```

## Hinweise und bekannte Grenzen

- Das Fenster ist 1920 × 1080 **inklusive** Titelleiste und Rahmen (`Size.Window.*`); der Clientbereich ist deshalb kleiner als 1920 × 1080, solange das Fenster nicht größer gezogen wird. `Capture-Pages.ps1` vergrößert das Fenster auf einen Clientbereich von 1920 × 1080 (Teile außerhalb des Bildschirms sind für `PrintWindow` unproblematisch). Das Verhalten bei abweichender Fenstergröße ist Prüfpunkt M3-06.
- Das Dummy-Datenmaterial wechselt (Uhr, Meldungen); Aufnahmen können sich in Uhrzeit und Werten unterscheiden.
- Bei hängenden Prozessen: `Get-Process ApaTec.Hmi | Stop-Process`.
