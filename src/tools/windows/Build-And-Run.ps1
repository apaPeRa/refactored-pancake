<#
.SYNOPSIS
    Baut die WPF-Loesung ApaTec.Hmi unter Windows (Release) und startet sie. Meilenstein 3, Schritt 1.

.DESCRIPTION
    1. Prueft mit "dotnet --info" und "dotnet --list-sdks", ob ein .NET-SDK ab Version 8 vorhanden ist (das Projekt zielt auf net8.0-windows; ein neueres SDK kann es bauen).
    2. dotnet restore, dotnet build -c Release (Warnungen sind Fehler, wie in der Cloud).
    3. Startet src\ApaTec.Hmi\bin\<Konfiguration>\net8.0-windows\ApaTec.Hmi.exe mit den uebergebenen Startparametern.

    Startparameter der Anwendung (siehe src\README.md): --page=<PageKey>, --dialog=<DialogKey>, --theme=light|dark,
    --culture=de-DE, --role=operator|technician|service, --designdata

.PARAMETER Configuration
    Build-Konfiguration, Standard Release.

.PARAMETER NoRun
    Nur bauen, nicht starten.

.PARAMETER SkipRestore
    dotnet restore auslassen (Offline-Betrieb nach erstem Restore).

.PARAMETER Clean
    Vorher "dotnet clean" ausfuehren und neu bauen (--no-incremental).

.PARAMETER AppArgs
    Startparameter fuer die Anwendung.

.EXAMPLE
    .\Build-And-Run.ps1
    .\Build-And-Run.ps1 -AppArgs '--page=HotGlueNordson','--theme=dark'
    .\Build-And-Run.ps1 -NoRun
#>
[CmdletBinding()]
param(
    [string]$Configuration = 'Release',
    [switch]$NoRun,
    [switch]$SkipRestore,
    [switch]$Clean,
    [string[]]$AppArgs = @()
)

$ErrorActionPreference = 'Stop'

function Write-Step([string]$Text) { Write-Host ("==> " + $Text) -ForegroundColor Cyan }
function Fail([string]$Text) { Write-Host ("FEHLER: " + $Text) -ForegroundColor Red; exit 1 }

# Repository-Wurzel: dieses Skript liegt in <Repo>\src\tools\windows
$repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..\..\..')).Path
$srcDir = Join-Path $repoRoot 'src'
$solution = Join-Path $srcDir 'ApaTec.Hmi.sln'
$project = Join-Path $srcDir 'ApaTec.Hmi\ApaTec.Hmi.csproj'
$exe = Join-Path $srcDir ("ApaTec.Hmi\bin\{0}\net8.0-windows\ApaTec.Hmi.exe" -f $Configuration)

if (-not (Test-Path $solution)) { Fail "Loesung nicht gefunden: $solution" }

# --- 1. Voraussetzungen -------------------------------------------------------------------------
Write-Step 'Voraussetzungen pruefen'
if ([Environment]::OSVersion.Platform -ne 'Win32NT') { Fail 'WPF laeuft nur unter Windows.' }
if (-not (Get-Command dotnet -ErrorAction SilentlyContinue)) {
    Fail '"dotnet" nicht gefunden. .NET 8 SDK installieren: https://dotnet.microsoft.com/download/dotnet/8.0'
}

& dotnet --info
if ($LASTEXITCODE -ne 0) { Fail '"dotnet --info" ist fehlgeschlagen.' }

$sdks = @(& dotnet --list-sdks)
$has8 = $sdks | Where-Object { [int](($_ -split '\.')[0]) -ge 8 }
if (-not $has8) {
    Fail ("Kein .NET-SDK ab Version 8 installiert. Gefunden: " + ($sdks -join '; '))
}
Write-Host ("SDK >= 8 gefunden: " + (($has8 | Select-Object -Last 1)) + " (Zielframework bleibt net8.0-windows, Laufzeit 8 wird benoetigt)") -ForegroundColor Green

# Anzeige-Hinweis fuer den spaeteren Sichtvergleich (nur Information)
try {
    Add-Type -AssemblyName System.Windows.Forms
    $b = [System.Windows.Forms.Screen]::PrimaryScreen.Bounds
    Write-Host ("Hauptbildschirm (so wie dieser Prozess ihn sieht): {0} x {1}" -f $b.Width, $b.Height)
    Write-Host 'Fuer den Bildabgleich: 1920 x 1080 bei 100 % Skalierung (Capture-Pages.ps1 prueft das genauer).'
} catch {
    Write-Host 'Bildschirmaufloesung konnte nicht ermittelt werden.' -ForegroundColor Yellow
}

# --- 2. Restore und Build ----------------------------------------------------------------------
Push-Location $srcDir
try {
    if ($Clean) {
        Write-Step 'dotnet clean'
        & dotnet clean $solution -c $Configuration
        if ($LASTEXITCODE -ne 0) { Fail 'dotnet clean fehlgeschlagen.' }
    }

    if (-not $SkipRestore) {
        Write-Step 'dotnet restore'
        & dotnet restore $solution
        if ($LASTEXITCODE -ne 0) { Fail 'dotnet restore fehlgeschlagen (Netzwerk / NuGet-Quelle pruefen).' }
    }

    Write-Step ("dotnet build -c {0}" -f $Configuration)
    # Der Restore laeuft oben bereits (ausser bei -SkipRestore); beim Build entfaellt er in beiden Faellen.
    $buildArgs = @('build', $solution, '-c', $Configuration, '--no-restore')
    if ($Clean) { $buildArgs += '--no-incremental' }
    & dotnet @buildArgs
    if ($LASTEXITCODE -ne 0) { Fail 'Build fehlgeschlagen (Meldungen oben; in Meilenstein 3 unter Windows korrigieren).' }
}
finally {
    Pop-Location
}

Write-Host 'Build erfolgreich.' -ForegroundColor Green

# --- 3. Start ----------------------------------------------------------------------------------
if ($NoRun) { Write-Host 'Start uebersprungen (-NoRun).'; exit 0 }
if (-not (Test-Path $exe)) { Fail "Programmdatei nicht gefunden: $exe" }

Write-Step ("Start: {0} {1}" -f $exe, ($AppArgs -join ' '))
if ($AppArgs.Count -gt 0) {
    $p = Start-Process -FilePath $exe -ArgumentList $AppArgs -PassThru
} else {
    $p = Start-Process -FilePath $exe -PassThru
}
Start-Sleep -Seconds 3
if ($p.HasExited) {
    Fail ("Die Anwendung wurde sofort beendet (Exit-Code {0}). Mit 'dotnet run --project {1}' die Ausnahme in der Konsole ansehen, ggf. Ereignisanzeige (Anwendung)." -f $p.ExitCode, $project)
}
Write-Host ("Anwendung laeuft (PID {0})." -f $p.Id) -ForegroundColor Green
