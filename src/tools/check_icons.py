#!/usr/bin/env python3
"""Symbolpruefung: jedes verwendete Icon.* ist in Themes/Icons.xaml definiert und in Designsystem.md Abschnitt 6/6.1 beschrieben.

Aufruf:  python3 src/tools/check_icons.py        Exit-Code 0 = vollstaendig.
Durchsucht werden alle .xaml- und .cs-Dateien von ApaTec.Hmi (ausser Icons.xaml selbst, bin, obj): StaticResource/DynamicResource-Verweise,
Zeichenfolgen wie "Icon.Home" (IconKey in ViewModels) und DesignData. Tokens der Form Size.Icon.* und Icon.Stroke* sind Masse, keine Symbole.
Fehlt ein Symbol, ergaenzt man eine Platzhaltergeometrie in Icons.xaml und eine Zeile in Designsystem.md 6.1 (Namensschema Icon.<Bereich>.<Name>).
"""
import re
import sys
from pathlib import Path

SRC = Path(__file__).resolve().parent.parent
PROJ = SRC / "ApaTec.Hmi"
DS = SRC.parent / "docs" / "03_HMI-Konzept" / "Designsystem.md"

icons_xaml = PROJ / "Themes" / "Icons.xaml"
defined = set(re.findall(r'x:Key="(Icon\.[\w.]+)"', icons_xaml.read_text(encoding="utf-8")))

TOKEN = re.compile(r"(?<![\w.])(Icon\.[A-Z][\w]*(?:\.[A-Z][\w]*)*)")
MEASURE = re.compile(r"^Icon\.Stroke(\.|$)")

used = {}
for p in sorted(PROJ.rglob("*")):
    if p.suffix not in (".xaml", ".cs") or {"bin", "obj"} & set(p.parts) or p == icons_xaml:
        continue
    txt = p.read_text(encoding="utf-8")
    txt = re.sub(r"<!--.*?-->", "", txt, flags=re.S) if p.suffix == ".xaml" else re.sub(r"//.*", "", txt)
    for m in TOKEN.finditer(txt):
        name = m.group(1)
        if MEASURE.match(name):
            continue
        used.setdefault(name, set()).add(p.name)

errors = []
for name in sorted(used):
    if name not in defined:
        errors.append(f"{name} fehlt in Icons.xaml (verwendet in {', '.join(sorted(used[name])[:4])})")

md = DS.read_text(encoding="utf-8")
s6 = md.split("## 6. Symbolik")[1].split("## 7. Zusammenspiel")[0]
documented = set(re.findall(r"`(Icon\.[\w.]+)`", s6))
for line in s6.splitlines():
    if line.startswith("| `"):
        last = None
        for tk in re.findall(r"`([^`]+)`", line.split("|")[1]):
            if tk.startswith("Icon."):
                last = tk
            elif tk.startswith(".") and last:
                documented.add(last.rsplit(".", 1)[0] + tk)
    if "Icon.Status.Ok" in line and "Warning" in line:
        documented |= {f"Icon.Status.{n}" for n in ("Ok", "Warning", "Error", "Info", "Inactive")}
for name in sorted(defined - documented):
    errors.append(f"{name} ist in Icons.xaml, aber nicht in Designsystem.md Abschnitt 6/6.1 beschrieben")
unused = sorted(defined - set(used))

print(f"Icons.xaml: {len(defined)} Symbole, verwendet: {len(set(used) & defined)}, ungenutzt (Reserve laut Designsystem 6): {len(unused)}")
print(f"Verwendete Symbole in XAML/C#: {len(used)}")
for e in errors:
    print("FEHLER:", e)
print("ERGEBNIS:", "BESTANDEN" if not errors else f"{len(errors)} Fehler")
sys.exit(1 if errors else 0)
