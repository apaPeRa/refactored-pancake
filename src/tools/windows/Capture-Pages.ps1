<#
.SYNOPSIS
    Startet die Anwendung je Seite und Thema (Hell/Dunkel) und speichert Screenshots (1920 x 1080) fuer den Bildabgleich. Meilenstein 3.

.DESCRIPTION
    Je Seite (HS-01 bis HS-43) und Thema:
      ApaTec.Hmi.exe --page=<PageKey> --theme=light|dark [--role=...] [--culture=...]
    (HS-02 und HS-03 sind Pop-ups: --dialog=<PageKey>; optional alle Dialoge mit -IncludeDialogs)
    wartet auf das Hauptfenster, wartet -SettleSeconds, nimmt den Client-Bereich des Fensters auf (PrintWindow, Rueckfall CopyFromScreen)
    und speichert nach  docs\04_Pruefung\Screenshots_M3\<HS-xx>_<hell|dunkel>.png  (Dialoge: DLG-<Key>_<hell|dunkel>.png).

    Der Prozess ist DPI-bewusst gestartet. Das Skript prueft Aufloesung und Skalierung des Hauptbildschirms und die Groesse des
    Fenster-Clientbereichs und WARNT, wenn sie von 1920 x 1080 bei 100 % abweichen; die Bilder sind dann nicht fuer den Pixelvergleich geeignet.

.PARAMETER Pages
    Auswahl: HS-Nummern ("HS-07", "7") oder PageKeys ("HotGlueNordson"). Standard: alle 43 Seiten.

.PARAMETER Themes
    hell, dunkel (Standard: beide).

.PARAMETER OutDir
    Zielordner. Standard: <Repo>\docs\04_Pruefung\Screenshots_M3

.PARAMETER Configuration
    Build-Konfiguration der Anwendung (Standard Release); die Programmdatei muss vorhanden sein (zuerst Build-And-Run.ps1 -NoRun).

.PARAMETER SettleSeconds
    Wartezeit nach dem Erscheinen des Fensters bis zur Aufnahme (Standard 4 s; Direktstart der Seite laeuft nach dem Laden des Fensters).

.PARAMETER Culture
    Wird als --culture uebergeben (Standard de-DE).

.PARAMETER IncludeDialogs
    Zusaetzlich die Dialoge (Input, Search, User, Language, Recipe, Confirmation, ScheduleEntry, Filter, FileResult, PostDoserHints) aufnehmen.

.PARAMETER Force
    Warnungen zu Aufloesung/Skalierung nicht mit Rueckfrage bestaetigen lassen.

.EXAMPLE
    .\Capture-Pages.ps1
    .\Capture-Pages.ps1 -Pages HS-01,HS-07,HotGlueNordson -Themes dunkel
#>
[CmdletBinding()]
param(
    [string[]]$Pages = @(),
    [ValidateSet('hell', 'dunkel')]
    [string[]]$Themes = @('hell', 'dunkel'),
    [string]$OutDir = '',
    [string]$Configuration = 'Release',
    [int]$SettleSeconds = 4,
    [string]$Culture = 'de-DE',
    [switch]$IncludeDialogs,
    [switch]$Force
)

$ErrorActionPreference = 'Stop'

$repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..\..\..')).Path
if ([string]::IsNullOrEmpty($OutDir)) { $OutDir = Join-Path $repoRoot 'docs\04_Pruefung\Screenshots_M3' }
$exe = Join-Path $repoRoot ("src\ApaTec.Hmi\bin\{0}\net8.0-windows\ApaTec.Hmi.exe" -f $Configuration)

$TargetWidth = 1920
$TargetHeight = 1080

# --- Win32 und DPI-Bewusstsein ---------------------------------------------------------------------
Add-Type -AssemblyName System.Drawing
Add-Type -AssemblyName System.Windows.Forms
Add-Type -TypeDefinition @'
using System;
using System.Runtime.InteropServices;
public static class HmiNative
{
    [StructLayout(LayoutKind.Sequential)] public struct RECT { public int Left, Top, Right, Bottom; }
    [StructLayout(LayoutKind.Sequential)] public struct POINT { public int X, Y; }
    [DllImport("user32.dll")] public static extern bool SetProcessDPIAware();
    [DllImport("user32.dll")] public static extern uint GetDpiForSystem();
    [DllImport("user32.dll")] public static extern bool GetWindowRect(IntPtr hWnd, out RECT r);
    [DllImport("user32.dll")] public static extern bool GetClientRect(IntPtr hWnd, out RECT r);
    [DllImport("user32.dll")] public static extern bool ClientToScreen(IntPtr hWnd, ref POINT p);
    [DllImport("user32.dll")] public static extern bool SetWindowPos(IntPtr hWnd, IntPtr after, int x, int y, int cx, int cy, uint flags);
    [DllImport("user32.dll")] public static extern bool SetForegroundWindow(IntPtr hWnd);
    [DllImport("user32.dll")] public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdc, uint flags);
}
'@
[void][HmiNative]::SetProcessDPIAware()

# --- Seitentabelle (aus Navigation/PageCatalog.cs, Navigation.md 5.1) --------------------------------------
# Spalten: HS-Nr, PageKey, Art (Page|Popup|Fullscreen), Rolle (leer = Standard Bediener)
$pageTable = @(
    @('HS-01', 'Production', 'Page', ''),
    @('HS-02', 'ProductionCounter', 'Popup', ''),
    @('HS-03', 'MachineSpeed', 'Popup', ''),
    @('HS-04', 'Settings', 'Page', ''),
    @('HS-05', 'FeederPaper', 'Page', ''),
    @('HS-06', 'FeederCarton', 'Page', ''),
    @('HS-07', 'HotGlueNordson', 'Page', ''),
    @('HS-08', 'HotGlueParameters', 'Page', ''),
    @('HS-09', 'HotGluePressure', 'Page', ''),
    @('HS-10', 'HotGlueSchedule', 'Page', ''),
    @('HS-11', 'MainDosers', 'Page', ''),
    @('HS-12', 'MainDoserMotor', 'Page', ''),
    @('HS-13', 'CheckWeigher', 'Page', ''),
    @('HS-14', 'SingleWeights', 'Page', ''),
    @('HS-15', 'Trend', 'Page', ''),
    @('HS-16', 'ClosingMachine', 'Page', ''),
    @('HS-17', 'ClosingMotor', 'Page', ''),
    @('HS-18', 'ClosingWeightCorrection', 'Page', ''),
    @('HS-19', 'PostDoser', 'Page', ''),
    @('HS-20', 'PostDoserMotor', 'Page', ''),
    @('HS-21', 'PostDoserWeightCorrection', 'Page', ''),
    @('HS-22', 'Heaters', 'Page', ''),
    @('HS-23', 'Regulation', 'Page', ''),
    @('HS-24', 'ScreenCleaning', 'Fullscreen', ''),
    @('HS-25', 'Cams', 'Page', ''),
    @('HS-26', 'CamOverview', 'Page', ''),
    @('HS-27', 'ScaleCalibration', 'Page', ''),
    @('HS-28', 'PackRegister', 'Page', ''),
    @('HS-29', 'ProductionStatistics', 'Page', ''),
    @('HS-30', 'ManualSelection', 'Page', ''),
    @('HS-31', 'ManualOperation', 'Page', ''),
    @('HS-32', 'EncoderSetting', 'Page', ''),
    @('HS-33', 'IoOverview', 'Page', ''),
    @('HS-34', 'IoDisplay', 'Page', ''),
    @('HS-35', 'SystemSettings', 'Page', ''),
    @('HS-36', 'Service', 'Page', 'technician'),
    @('HS-37', 'MessageArchive', 'Page', ''),
    @('HS-38', 'MessageView', 'Page', ''),
    @('HS-39', 'SystemInfo', 'Page', ''),
    @('HS-40', 'Feeders', 'Page', ''),
    @('HS-41', 'DoserOverview', 'Page', ''),
    @('HS-42', 'Scales', 'Page', ''),
    @('HS-43', 'ShiftPlan', 'Page', '')
)
$dialogKeys = @('Input', 'Search', 'User', 'Language', 'Recipe', 'Confirmation', 'ScheduleEntry', 'Filter', 'FileResult', 'PostDoserHints')

# --- Vorpruefungen ---------------------------------------------------------------------------------
if (-not (Test-Path $exe)) {
    Write-Host "FEHLER: Programmdatei nicht gefunden: $exe" -ForegroundColor Red
    Write-Host 'Zuerst bauen:  .\Build-And-Run.ps1 -NoRun' -ForegroundColor Red
    exit 1
}

$warnings = New-Object System.Collections.Generic.List[string]
$screen = [System.Windows.Forms.Screen]::PrimaryScreen.Bounds
$dpi = [HmiNative]::GetDpiForSystem()
$scalePercent = [int][math]::Round($dpi * 100 / 96)
Write-Host ("Hauptbildschirm: {0} x {1}, Skalierung {2} % (DPI {3})" -f $screen.Width, $screen.Height, $scalePercent, $dpi)
if ($screen.Width -ne $TargetWidth -or $screen.Height -ne $TargetHeight) {
    $warnings.Add(("Aufloesung ist {0} x {1}, erwartet {2} x {3}." -f $screen.Width, $screen.Height, $TargetWidth, $TargetHeight))
}
if ($scalePercent -ne 100) {
    $warnings.Add(("Skalierung ist {0} %, erwartet 100 % (Windows: Einstellungen > System > Anzeige > Skalierung)." -f $scalePercent))
}
if ($warnings.Count -gt 0) {
    Write-Host 'WARNUNG: Die Aufnahmen sind nicht fuer den Pixelvergleich mit dem Entwurf geeignet:' -ForegroundColor Yellow
    $warnings | ForEach-Object { Write-Host ("  - " + $_) -ForegroundColor Yellow }
    if (-not $Force) {
        $answer = Read-Host 'Trotzdem fortfahren? (j/N)'
        if ($answer -notin @('j', 'J', 'y', 'Y')) { exit 2 }
    }
}

# Auswahl der Seiten
$selected = $pageTable
if ($Pages.Count -gt 0) {
    $wanted = @()
    foreach ($p in $Pages) {
        $text = $p.Trim()
        if ($text -match '^\d{1,2}$') { $text = 'HS-{0:D2}' -f [int]$text }
        $hit = $pageTable | Where-Object { $_[0] -ieq $text -or $_[1] -ieq $text }
        if (-not $hit) { Write-Host ("WARNUNG: Seite '{0}' unbekannt, uebersprungen." -f $p) -ForegroundColor Yellow } else { $wanted += , $hit }
    }
    $selected = $wanted
}

New-Item -ItemType Directory -Force -Path $OutDir | Out-Null

# --- Aufnahme ----------------------------------------------------------------------------------------
function Wait-MainWindow([System.Diagnostics.Process]$Process, [int]$TimeoutSeconds) {
    $deadline = (Get-Date).AddSeconds($TimeoutSeconds)
    while ((Get-Date) -lt $deadline) {
        if ($Process.HasExited) { return [IntPtr]::Zero }
        $Process.Refresh()
        if ($Process.MainWindowHandle -ne [IntPtr]::Zero) { return $Process.MainWindowHandle }
        Start-Sleep -Milliseconds 250
    }
    return [IntPtr]::Zero
}

function Save-ClientShot([IntPtr]$Handle, [string]$Path) {
    # Fenster auf Clientgroesse 1920 x 1080 bringen (Position links oben; Rest kann ausserhalb des Bildschirms liegen, PrintWindow braucht ihn nicht sichtbar)
    $win = New-Object HmiNative+RECT
    $cli = New-Object HmiNative+RECT
    [void][HmiNative]::GetWindowRect($Handle, [ref]$win)
    [void][HmiNative]::GetClientRect($Handle, [ref]$cli)
    $extraW = ($win.Right - $win.Left) - ($cli.Right - $cli.Left)
    $extraH = ($win.Bottom - $win.Top) - ($cli.Bottom - $cli.Top)
    $SWP_NOZORDER = 0x0004
    [void][HmiNative]::SetWindowPos($Handle, [IntPtr]::Zero, 0, 0, $TargetWidth + $extraW, $TargetHeight + $extraH, $SWP_NOZORDER)
    Start-Sleep -Milliseconds 800
    [void][HmiNative]::SetForegroundWindow($Handle)
    Start-Sleep -Milliseconds 200

    [void][HmiNative]::GetWindowRect($Handle, [ref]$win)
    [void][HmiNative]::GetClientRect($Handle, [ref]$cli)
    $origin = New-Object HmiNative+POINT
    [void][HmiNative]::ClientToScreen($Handle, [ref]$origin)
    $clientW = $cli.Right - $cli.Left
    $clientH = $cli.Bottom - $cli.Top
    $offX = $origin.X - $win.Left
    $offY = $origin.Y - $win.Top

    $winW = $win.Right - $win.Left
    $winH = $win.Bottom - $win.Top
    $full = New-Object System.Drawing.Bitmap($winW, $winH)
    $g = [System.Drawing.Graphics]::FromImage($full)
    $ok = $false
    try {
        $hdc = $g.GetHdc()
        try { $ok = [HmiNative]::PrintWindow($Handle, $hdc, 2) } finally { $g.ReleaseHdc($hdc) }   # 2 = PW_RENDERFULLCONTENT (WPF/DirectX)
    } finally { $g.Dispose() }

    $shot = New-Object System.Drawing.Bitmap($clientW, $clientH)
    $gs = [System.Drawing.Graphics]::FromImage($shot)
    try {
        if ($ok) {
            $gs.DrawImage($full, (New-Object System.Drawing.Rectangle(0, 0, $clientW, $clientH)), (New-Object System.Drawing.Rectangle($offX, $offY, $clientW, $clientH)), [System.Drawing.GraphicsUnit]::Pixel)
        } else {
            # Rueckfall: vom Bildschirm kopieren (Fenster muss dann vollstaendig sichtbar sein)
            $gs.CopyFromScreen($origin.X, $origin.Y, 0, 0, (New-Object System.Drawing.Size($clientW, $clientH)))
        }
    } finally { $gs.Dispose(); $full.Dispose() }
    $shot.Save($Path, [System.Drawing.Imaging.ImageFormat]::Png)
    $shot.Dispose()
    return @{ Width = $clientW; Height = $clientH; Method = $(if ($ok) { 'PrintWindow' } else { 'CopyFromScreen' }) }
}

function Invoke-Capture([string]$Label, [string[]]$AppArgs, [string]$Path) {
    $proc = Start-Process -FilePath $exe -ArgumentList $AppArgs -PassThru
    try {
        $handle = Wait-MainWindow $proc 40
        if ($handle -eq [IntPtr]::Zero) {
            Write-Host ("  {0}: FEHLER - kein Hauptfenster (Exit-Code {1})" -f $Label, $(if ($proc.HasExited) { $proc.ExitCode } else { '-' })) -ForegroundColor Red
            return $false
        }
        Start-Sleep -Seconds $SettleSeconds
        if ($proc.HasExited) {
            Write-Host ("  {0}: FEHLER - Anwendung vorzeitig beendet (Exit-Code {1})" -f $Label, $proc.ExitCode) -ForegroundColor Red
            return $false
        }
        $r = Save-ClientShot $handle $Path
        $note = ''
        if ($r.Width -ne $TargetWidth -or $r.Height -ne $TargetHeight) {
            $note = (" WARNUNG: Client {0} x {1} statt {2} x {3}" -f $r.Width, $r.Height, $TargetWidth, $TargetHeight)
            $script:sizeMismatch++
        }
        Write-Host ("  {0}: {1} ({2}){3}" -f $Label, (Split-Path $Path -Leaf), $r.Method, $note) -ForegroundColor $(if ($note) { 'Yellow' } else { 'Green' })
        return $true
    }
    finally {
        if (-not $proc.HasExited) {
            [void]$proc.CloseMainWindow()
            if (-not $proc.WaitForExit(5000)) { $proc.Kill() }
        }
    }
}

$script:sizeMismatch = 0
$done = 0
$failed = 0
foreach ($theme in $Themes) {
    $themeArg = if ($theme -eq 'hell') { 'light' } else { 'dark' }
    foreach ($entry in $selected) {
        $hs = $entry[0]; $key = $entry[1]; $kind = $entry[2]; $role = $entry[3]
        $appArgs = @()
        if ($kind -eq 'Popup') { $appArgs += "--dialog=$key" } else { $appArgs += "--page=$key" }
        $appArgs += "--theme=$themeArg"
        $appArgs += "--culture=$Culture"
        if ($role) { $appArgs += "--role=$role" }
        $file = Join-Path $OutDir ("{0}_{1}.png" -f $hs, $theme)
        if (Invoke-Capture ("{0} {1}" -f $hs, $theme) $appArgs $file) { $done++ } else { $failed++ }
    }
    if ($IncludeDialogs) {
        foreach ($dk in $dialogKeys) {
            $appArgs = @("--dialog=$dk", "--theme=$themeArg", "--culture=$Culture")
            $file = Join-Path $OutDir ("DLG-{0}_{1}.png" -f $dk, $theme)
            if (Invoke-Capture ("DLG-{0} {1}" -f $dk, $theme) $appArgs $file) { $done++ } else { $failed++ }
        }
    }
}

Write-Host ''
Write-Host ("Fertig: {0} Aufnahmen, {1} Fehler, {2} mit abweichender Clientgroesse. Ordner: {3}" -f $done, $failed, $script:sizeMismatch, $OutDir)
if ($warnings.Count -gt 0 -or $script:sizeMismatch -gt 0) {
    Write-Host 'Hinweis: Aufloesung/Skalierung/Clientgroesse weichen ab - Bilder nur zur groben Sicht, nicht fuer den Pixelvergleich.' -ForegroundColor Yellow
}
if ($failed -gt 0) { exit 1 }
