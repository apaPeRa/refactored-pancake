#!/usr/bin/env python3
"""Statische Pruefungen fuer das WPF-Fundament (M2-V02..V05, V08-Teile).

Aufruf:  python3 src/tools/check_design.py        (vom Repository-Wurzelverzeichnis oder aus src/)
Exit-Code 0 = alles bestanden. Prueft:
  1. alle .xaml/.resx/.csproj sind wohlgeformt (XML)
  2. Theme.Light.xaml und Theme.Dark.xaml haben dieselben Schluessel; alle Brush-Tokens aus Designsystem.md 10.1 mit den dort stehenden Hex-Werten
  3. Tokens.xaml enthaelt alle Tokens aus Designsystem.md 10.2/10.3
  4. Icons.xaml enthaelt jedes Icon.* aus Designsystem.md Abschnitt 6 und 6.1
  5. jeder StaticResource/DynamicResource-Verweis in XAML hat eine Definition
  6. Code-behind (*.xaml.cs) von Views, Fenstern und App enthaelt nur Konstruktor mit InitializeComponent() (A-73)
  7. keine Literale (Hex-Farben, Pixelmasse, feste Texte) in Views/ und MainWindow.xaml
  8. jeder {res:Loc Schluessel} existiert in Resources/Strings*.resx; fuer alle 43 PageKeys existieren Nav_<Key>_Title/_Crumb
  9. PageKeys.cs enthaelt 43 Schluessel
"""
import re
import sys
import xml.etree.ElementTree as ET
from pathlib import Path

HERE = Path(__file__).resolve().parent
SRC = HERE.parent
PROJ = SRC / "ApaTec.Hmi"
REPO = SRC.parent
DS = REPO / "docs" / "03_HMI-Konzept" / "Designsystem.md"
X = "{http://schemas.microsoft.com/winfx/2006/xaml}"

errors = []


def fail(msg):
    errors.append(msg)
    print("FEHLER:", msg)


def keys_of(path):
    root = ET.parse(path).getroot()
    return {e.get(X + "Key"): e for e in root.iter() if e.get(X + "Key")}


# 1 Wohlgeformtheit
files = [p for p in PROJ.rglob("*") if p.suffix in (".xaml", ".resx", ".csproj") and "obj" not in p.parts and "bin" not in p.parts]
for p in files:
    try:
        ET.parse(p)
    except ET.ParseError as e:
        fail(f"{p.relative_to(SRC)}: nicht wohlgeformt: {e}")
print(f"[1] {len(files)} XML-Dateien geprueft")

md = DS.read_text(encoding="utf-8")

# 2 Themes
light = PROJ / "Themes" / "Theme.Light.xaml"
dark = PROJ / "Themes" / "Theme.Dark.xaml"
kl, kd = keys_of(light), keys_of(dark)
if set(kl) != set(kd):
    fail(f"Theme-Schluessel verschieden: nur Light {sorted(set(kl)-set(kd))}, nur Dark {sorted(set(kd)-set(kl))}")
sec = md.split("### 10.1")[1].split("### 10.2")[0]
rows = re.findall(r"\| `(Brush\.[^`]+)` \| SolidColorBrush \| `(#[0-9A-Fa-f]+)` \| `(#[0-9A-Fa-f]+)` \|", sec)
for key, hl, hd in rows:
    for name, ks, hexv in (("Light", kl, hl), ("Dark", kd, hd)):
        if key not in ks:
            fail(f"Theme.{name}: Token {key} fehlt")
        elif (ks[key].get("Color") or "").upper() != hexv.upper():
            fail(f"Theme.{name}: {key} = {ks[key].get('Color')} statt {hexv}")
extra = set(kl) - {r[0] for r in rows}
if extra:
    fail(f"Theme enthaelt Schluessel ausserhalb von 10.1: {sorted(extra)}")
print(f"[2] Themes: {len(rows)} Brush-Tokens in Tabelle 10.1, Light {len(kl)}, Dark {len(kd)}")

# 3 Tokens
tok = keys_of(PROJ / "Themes" / "Tokens.xaml")
sec = md.split("### 10.2")[1].split("Symbole (`Icon.*`")[0]
wanted = set()
for m in re.finditer(r"^\| `((?:Font|Size|Space|Radius|Border)\.[A-Za-z.]+)` \|", sec, re.M):
    wanted.add(m.group(1))
wanted -= {"Size.Header.Columns", "Size.Crumb.Columns"}
wanted |= {f"Size.Header.Col.{n}" for n in ("Logo", "Message", "Mode", "Clock")} | {f"Size.Crumb.Col.{n}" for n in ("Path", "Speed", "Angle")}
for k in sorted(wanted):
    if k not in tok:
        fail(f"Tokens.xaml: Token {k} fehlt")
print(f"[3] Tokens: {len(wanted)} geforderte Tokens, {len(tok)} vorhanden")

# 4 Icons
ic = keys_of(PROJ / "Themes" / "Icons.xaml")
s6 = md.split("## 6. Symbolik")[1].split("## 7. Zusammenspiel")[0]
needed = set()
for line in s6.splitlines():
    if not line.startswith("| `"):
        continue
    cell = line.split("|")[1]
    last = None
    for tk in re.findall(r"`([^`]+)`", cell):
        if tk.startswith("Icon."):
            last = tk
            needed.add(tk)
        elif tk.startswith(".") and last:
            needed.add(last.rsplit(".", 1)[0] + tk)
# "Icon.Status.Ok / .Warning / ..." steht in einem Backtick-Block
for m in re.finditer(r"`(Icon\.[A-Za-z.]+)` / `?\.[A-Za-z]+`? / `?\.[A-Za-z]+", s6):
    pass
for line in s6.splitlines():
    if "Icon.Status.Ok" in line and "Warning" in line:
        needed |= {f"Icon.Status.{n}" for n in ("Ok", "Warning", "Error", "Info", "Inactive")}
        needed.discard("Icon.Status")
needed = {n for n in needed if n != "Icon.Status"}
for n in sorted(needed):
    if n not in ic:
        fail(f"Icons.xaml: {n} fehlt")
print(f"[4] Icons: {len(needed)} in Designsystem 6/6.1, {len(ic)} in Icons.xaml")

# 5 Ressourcenverweise
defined = set()
for p in PROJ.rglob("*.xaml"):
    if "obj" in p.parts or "bin" in p.parts:
        continue
    defined |= set(keys_of(p))
refs = {}
for p in PROJ.rglob("*.xaml"):
    if "obj" in p.parts or "bin" in p.parts:
        continue
    txt = re.sub(r"<!--.*?-->", "", p.read_text(encoding="utf-8"), flags=re.S)
    for m in re.finditer(r"\{(?:StaticResource|DynamicResource)\s+(?:ResourceKey=)?([^\s}]+)\}", txt):
        refs.setdefault(m.group(1), []).append(p.name)
for k, where in sorted(refs.items()):
    if k not in defined:
        fail(f"Ressourcenverweis {k} ohne Definition (in {sorted(set(where))})")
print(f"[5] {len(refs)} verschiedene Ressourcenverweise geprueft")

# 6 Code-behind
cb_ok = re.compile(
    r"^\s*namespace [\w.]+;\s*(?:public )?(?:sealed )?partial class \w+\s*\{\s*public \w+\(\)\s*\{\s*InitializeComponent\(\);\s*\}\s*\}\s*$",
    re.S,
)
n_cb = 0
for p in PROJ.rglob("*.xaml.cs"):
    if "obj" in p.parts or "bin" in p.parts:
        continue
    n_cb += 1
    txt = re.sub(r"//.*", "", p.read_text(encoding="utf-8"))
    txt = re.sub(r"/\*.*?\*/", "", txt, flags=re.S)
    if not cb_ok.match(txt):
        fail(f"Code-behind nicht leer: {p.relative_to(SRC)}")
print(f"[6] {n_cb} Code-behind-Dateien geprueft")

# 7 Literale
lit = [
    (re.compile(r"#[0-9A-Fa-f]{6,8}\b"), "Hex-Farbe"),
    (re.compile(r'\bColor="(?!\{)'), "Color-Literal"),
    (re.compile(r'\b(?:Width|Height|MinWidth|MinHeight|MaxWidth|MaxHeight|FontSize|StrokeThickness|RadiusX|RadiusY)="\d'), "Pixelmass"),
    (re.compile(r'\b(?:Margin|Padding|BorderThickness|CornerRadius)="\d'), "Abstand/Radius-Literal"),
    (re.compile(r'\b(?:Text|Content|Title|ToolTip)="(?!\{)[^"]'), "fester Text"),
]
targets = [p for p in (PROJ / "Views").rglob("*.xaml")] + [PROJ / "MainWindow.xaml"] + [p for p in (PROJ / "Controls").rglob("*.xaml")]
for p in targets:
    txt = p.read_text(encoding="utf-8")
    txt = re.sub(r"<!--.*?-->", "", txt, flags=re.S)
    for rx, what in lit:
        for m in rx.finditer(txt):
            fail(f"{p.relative_to(SRC)}: {what}: {m.group(0)}")
print(f"[7] {len(targets)} XAML-Dateien auf Literale geprueft")

# 8 Lokalisierung
res_keys = set()
for p in (PROJ / "Resources").rglob("*.resx"):
    root = ET.parse(p).getroot()
    res_keys |= {d.get("name") for d in root.iter("data")}
used = set()
for p in PROJ.rglob("*.xaml"):
    if "obj" in p.parts or "bin" in p.parts:
        continue
    used |= set(re.findall(r"\{res:Loc\s+([A-Za-z0-9_]+)\}", p.read_text(encoding="utf-8")))
for k in sorted(used - res_keys):
    fail(f"Lokalisierungsschluessel {k} fehlt in Strings.resx")
page_keys = re.findall(r'public const string (\w+) = "\1";', (PROJ / "Navigation" / "PageKeys.cs").read_text(encoding="utf-8"))
for k in page_keys:
    for suffix in ("Title", "Crumb"):
        if f"Nav_{k}_{suffix}" not in res_keys:
            fail(f"Strings.resx: Nav_{k}_{suffix} fehlt")
print(f"[8] {len(used)} Loc-Schluessel in XAML, {len(res_keys)} Ressourcen")

# 9 Seitenzahl
if len(page_keys) != 43:
    fail(f"PageKeys.cs enthaelt {len(page_keys)} statt 43 Schluessel")
print(f"[9] PageKeys: {len(page_keys)}")

print("ERGEBNIS:", "BESTANDEN" if not errors else f"{len(errors)} Fehler")
sys.exit(1 if errors else 0)
