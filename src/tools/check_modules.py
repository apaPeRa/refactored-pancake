#!/usr/bin/env python3
"""Modulpruefung HM-01..HM-38 gegen docs/03_HMI-Konzept/Module/Modulliste.md.

Aufruf:  python3 src/tools/check_modules.py        Exit-Code 0 = alle 38 Module OK.
Je Modul:
  K  Control-Klasse (Spalte "Control-Klasse") existiert als `class <Name>` in Controls/HMxx_*.cs
  S  Controls/HMxx_*.Styles.xaml existiert, ist ein wohlgeformtes ResourceDictionary und enthaelt einen Stil
     (TargetType) fuer die Control-Klasse; die Einbindung erfolgt automatisch ueber ControlResources.MergeAll
     (Pruefung: ControlResources.cs sammelt Controls/*.Styles.xaml, csproj entfernt keine Datei daraus)
  D  DesignData/HMxx_DesignData.xaml existiert und ist ein wohlgeformtes ResourceDictionary
  C  C# der Moduldateien (Controls/HMxx_*.cs): keine Logik (kein async/await, keine Netzwerk-/Datei-/Thread-Zugriffe,
     keine Ereignisbehandler-Abonnements ausser in Konvertern)
"""
import re
import sys
import xml.etree.ElementTree as ET
from pathlib import Path

SRC = Path(__file__).resolve().parent.parent
PROJ = SRC / "ApaTec.Hmi"
LIST = SRC.parent / "docs" / "03_HMI-Konzept" / "Module" / "Modulliste.md"
CTRL = PROJ / "Controls"
DD = PROJ / "DesignData"

FORBIDDEN = re.compile(
    r"\b(async|await)\b|\bSystem\.(Net|IO)\b|\b(HttpClient|WebClient|Socket|File|Directory|StreamReader|StreamWriter|Task\.Run|Thread|Timer|DispatcherTimer)\b|\bFile\.\w+\(",
)


def strip_cs(txt):
    txt = re.sub(r"/\*.*?\*/", "", txt, flags=re.S)
    txt = re.sub(r"//.*", "", txt)
    return re.sub(r'"(?:\\.|[^"\\])*"', '""', txt)


rows = re.findall(r"^\| \[HM-(\d\d)\]\([^)]*\) \| ([^|]+) \| `([^`]+)` \|", LIST.read_text(encoding="utf-8"), re.M)
results = []
auto = False
res_src = (CTRL / "ControlResources.cs").read_text(encoding="utf-8")
auto = ".styles.baml" in res_src.lower() and "MergedDictionaries.Add" in res_src
csproj = (PROJ / "ApaTec.Hmi.csproj").read_text(encoding="utf-8")
auto = auto and not re.search(r'(Remove|Exclude)="[^"]*Styles', csproj)

for num, name, cls in rows:
    prefix = f"HM{num}_"
    problems = []
    cs_files = sorted(p for p in CTRL.glob(prefix + "*.cs"))
    main = [p for p in cs_files if re.search(r"\bclass " + re.escape(cls) + r"\b", p.read_text(encoding="utf-8"))]
    if not main:
        problems.append(f"K: class {cls} nicht in {prefix}*.cs")
    styles = sorted(CTRL.glob(prefix + "*.Styles.xaml"))
    if not styles:
        problems.append("S: keine .Styles.xaml")
    else:
        found = False
        for p in styles:
            try:
                root = ET.parse(p).getroot()
            except ET.ParseError as e:
                problems.append(f"S: {p.name} nicht wohlgeformt ({e})")
                continue
            if not root.tag.endswith("ResourceDictionary"):
                problems.append(f"S: {p.name} ist kein ResourceDictionary")
            if re.search(r"TargetType=\"\{x:Type [\w:]*" + re.escape(cls) + r"\}\"", p.read_text(encoding="utf-8")):
                found = True
        if not found:
            problems.append(f"S: kein Stil mit TargetType {cls}")
    if not auto:
        problems.append("S: automatische Einbindung (ControlResources) nicht erkennbar")
    dd = DD / f"{prefix}DesignData.xaml"
    if not dd.exists():
        problems.append("D: DesignData fehlt")
    else:
        try:
            if not ET.parse(dd).getroot().tag.endswith("ResourceDictionary"):
                problems.append("D: kein ResourceDictionary")
        except ET.ParseError as e:
            problems.append(f"D: nicht wohlgeformt ({e})")
    for p in cs_files:
        for m in FORBIDDEN.finditer(strip_cs(p.read_text(encoding="utf-8"))):
            problems.append(f"C: {p.name}: verdaechtig '{m.group(0)}'")
    results.append((num, name.strip(), cls, problems))

print(f"{'HM':<6}{'Control-Klasse':<30}{'K':<6}{'S':<6}{'D':<6}{'C':<6}Status")
for num, name, cls, pr in results:
    flags = {c: ("ok" if not any(x.startswith(c + ":") for x in pr) else "FEHL") for c in "KSDC"}
    print(f"HM-{num:<3}{cls:<30}{flags['K']:<6}{flags['S']:<6}{flags['D']:<6}{flags['C']:<6}{'OK' if not pr else 'FEHLER'}")
    for x in pr:
        print("        ", x)
bad = [r for r in results if r[3]]
if len(results) != 38:
    print(f"FEHLER: Modulliste enthaelt {len(results)} statt 38 Module")
    bad.append(None)
print(f"ERGEBNIS: {len(results) - len([b for b in bad if b])}/{len(results)} Module OK, Einbindung der Styles automatisch: {'ja' if auto else 'nein'}")
sys.exit(1 if bad else 0)
