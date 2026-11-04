#!/usr/bin/env python3
"""Seitenpruefung HS-01..HS-43 (und Dialoge) gegen das Seitenregister Navigation.md 5.1.

Aufruf:  python3 src/tools/check_pages.py        Exit-Code 0 = alle 43 Seiten und alle Dialoge OK.
Je Seite (Zuordnung PageKey <-> HS-ID ueber Navigation.md Abschnitt 5.1, gegen PageKeys.cs und PageCatalog.cs geprueft):
  K  PageKeys.cs enthaelt den Schluessel; HS-ID im Kommentar und in PageCatalog.cs, Route und Eltern stimmen mit dem Register ueberein
  V  genau ein ViewModel mit [PageKey(PageKeys.<Key>)] (Klasse <Key>ViewModel in ViewModels/)
  X  Views/**/<Key>View.xaml existiert, x:Class stimmt, Code-behind enthaelt nur InitializeComponent()
  L  alle {res:Loc ...}-Schluessel der View stehen in einer .resx
  T  Nav_<Key>_Title und Nav_<Key>_Crumb stehen in Resources/Strings.resx
  P  keine Literale in der View (Hex-Farbe, Color=, Pixelmasse, Abstand/Radius, fester Text)
Je Dialog (DialogKeys.cs und [DialogKey] in ViewModels): ein ViewModel je Schluessel, View <Name>View.xaml, Code-behind, Loc-Schluessel, Literale.
"""
import re
import sys
import xml.etree.ElementTree as ET
from pathlib import Path

SRC = Path(__file__).resolve().parent.parent
PROJ = SRC / "ApaTec.Hmi"
NAV = SRC.parent / "docs" / "03_HMI-Konzept" / "Navigation.md"

CB_OK = re.compile(
    r"^\s*namespace [\w.]+;\s*(?:public )?(?:sealed )?partial class \w+\s*\{\s*public \w+\(\)\s*\{\s*InitializeComponent\(\);\s*\}\s*\}\s*$",
    re.S,
)
LITERALS = [
    (re.compile(r"#[0-9A-Fa-f]{6,8}\b"), "Hex-Farbe"),
    (re.compile(r'\bColor="(?!\{)'), "Color-Literal"),
    (re.compile(r'\b(?:Width|Height|MinWidth|MinHeight|MaxWidth|MaxHeight|FontSize|StrokeThickness|RadiusX|RadiusY)="(?!\d+(?:\.\d+)?\*")\d'), "Pixelmass"),
    (re.compile(r'\b(?:Margin|Padding|BorderThickness|CornerRadius)="\d'), "Abstand/Radius-Literal"),
    (re.compile(r'\b(?:Text|Content|Title|ToolTip)="(?!\{)[^"]'), "fester Text"),
]


def read(path):
    return path.read_text(encoding="utf-8")


def strip_comments(txt):
    return re.sub(r"<!--.*?-->", "", txt, flags=re.S)


# Ressourcenschluessel aller .resx
resx_keys = {}
for p in (PROJ / "Resources").rglob("*.resx"):
    for d in ET.parse(p).getroot().iter("data"):
        resx_keys.setdefault(d.get("name"), p.name)
strings_keys = {d.get("name") for d in ET.parse(PROJ / "Resources" / "Strings.resx").getroot().iter("data")}

# Seitenregister
nav = read(NAV)
sec = nav.split("### 5.1 Seitenregister")[1].split("### 5.2")[0]
register = {}  # key -> (hs, route, parent_hs)
for m in re.finditer(r"^\| (HS-\d\d) \| `(\w+)` / `([^`]+)` \| (HS-\d\d|–) \|", sec, re.M):
    register[m.group(2)] = (m.group(1), m.group(3), m.group(4))
hs_to_key = {v[0]: k for k, v in register.items()}

# PageKeys.cs
pagekeys_src = read(PROJ / "Navigation" / "PageKeys.cs")
pagekeys = {}  # key -> HS im Kommentar
for m in re.finditer(r"/// <summary>(HS-\d\d)[^<]*</summary>\s*public const string (\w+) = \"\2\";", pagekeys_src):
    pagekeys[m.group(2)] = m.group(1)

# PageCatalog.cs
catalog = {}
for m in re.finditer(r'new\(PageKeys\.(\w+), "([^"]+)", "(HS-\d\d)", PageKind\.\w+, (PageKeys\.\w+|null)', read(PROJ / "Navigation" / "PageCatalog.cs")):
    catalog[m.group(1)] = (m.group(3), m.group(2), m.group(4).removeprefix("PageKeys.") if m.group(4) != "null" else None)

# ViewModels
vm_files = sorted((PROJ / "ViewModels").glob("*.cs"))
page_vms = {}
dialog_vms = {}
for p in vm_files:
    txt = read(p)
    for m in re.finditer(r"\[PageKey\(PageKeys\.(\w+)\)\]\s*(?:public\s+)?(?:sealed\s+)?(?:abstract\s+)?(?:partial\s+)?class (\w+)", txt):
        page_vms.setdefault(m.group(1), []).append(m.group(2))
    for m in re.finditer(r"\[DialogKey\((?:DialogKeys\.)?(\w+)\)\]\s*(?:public\s+)?(?:sealed\s+)?(?:partial\s+)?class (\w+)", txt):
        key = m.group(1)
        if key == "DialogKey":  # lokale Konstante const string DialogKey = "..."
            c = re.search(r'const string DialogKey = "(\w+)"', txt)
            key = c.group(1) if c else key
        dialog_vms.setdefault(key, []).append(m.group(2))

view_files = {}
for p in (PROJ / "Views").rglob("*.xaml"):
    view_files.setdefault(p.stem, []).append(p)


def check_view(name, problems, prefix):
    """Gemeinsame Pruefungen X, L, P fuer eine View."""
    files = view_files.get(name, [])
    if len(files) != 1:
        problems.append(f"X: {name}.xaml {'fehlt' if not files else 'mehrfach'}")
        return
    xaml = files[0]
    raw = read(xaml)
    cls = re.search(r'x:Class="([\w.]+)"', raw)
    if not cls or not cls.group(1).endswith("." + name):
        problems.append(f"X: x:Class passt nicht zu {name}")
    cb = xaml.with_name(xaml.name + ".cs")
    if not cb.exists():
        problems.append("X: Code-behind fehlt")
    else:
        txt = re.sub(r"/\*.*?\*/", "", re.sub(r"//.*", "", read(cb)), flags=re.S)
        if not CB_OK.match(txt):
            problems.append("X: Code-behind nicht leer")
    txt = strip_comments(raw)
    for k in sorted(set(re.findall(r"\{res:Loc\s+([A-Za-z0-9_]+)\}", txt))):
        if k not in resx_keys:
            problems.append(f"L: Schluessel {k} fehlt in den .resx")
    for rx, what in LITERALS:
        for m in rx.finditer(txt):
            problems.append(f"P: {what}: {m.group(0)}")


rows = []
for hs in [f"HS-{n:02d}" for n in range(1, 44)]:
    problems = []
    key = hs_to_key.get(hs)
    if key is None:
        rows.append((hs, "?", ["K: nicht im Seitenregister Navigation.md 5.1"]))
        continue
    reg_hs, route, parent = register[key]
    # K
    if key not in pagekeys:
        problems.append("K: Schluessel fehlt in PageKeys.cs")
    elif pagekeys[key] != hs:
        problems.append(f"K: PageKeys.cs-Kommentar nennt {pagekeys[key]}")
    if key not in catalog:
        problems.append("K: nicht in PageCatalog.cs")
    else:
        c_hs, c_route, c_parent = catalog[key]
        if c_hs != hs:
            problems.append(f"K: PageCatalog nennt {c_hs}")
        if c_route != route:
            problems.append(f"K: Route {c_route} statt {route}")
        want_parent = hs_to_key.get(parent) if parent != "–" else None
        if c_parent != want_parent:
            problems.append(f"K: Eltern {c_parent} statt {want_parent}")
    # V
    vms = page_vms.get(key, [])
    if len(vms) != 1:
        problems.append(f"V: {len(vms)} ViewModels mit [PageKey] (erwartet 1)")
    elif vms[0] != key + "ViewModel":
        problems.append(f"V: Klasse {vms[0]} statt {key}ViewModel")
    # X, L, P
    check_view(key + "View", problems, key)
    # T
    for suffix in ("Title", "Crumb"):
        if f"Nav_{key}_{suffix}" not in strings_keys:
            problems.append(f"T: Nav_{key}_{suffix} fehlt in Strings.resx")
    rows.append((hs, key, problems))

extra_vm = set(page_vms) - set(register)
dialog_rows = []
dk_src = read(PROJ / "Navigation" / "DialogKeys.cs")
dialog_keys = set(re.findall(r'public const string (\w+) = "\1";', dk_src))
for key in sorted(dialog_keys | set(dialog_vms)):
    problems = []
    vms = dialog_vms.get(key, [])
    if len(vms) != 1:
        problems.append(f"V: {len(vms)} ViewModels mit [DialogKey] (erwartet 1)")
    else:
        vm = vms[0]
        if not vm.endswith("ViewModel"):
            problems.append(f"V: Klasse {vm} endet nicht auf ViewModel")
        else:
            check_view(vm[: -len("ViewModel")] + "View", problems, key)
    dialog_rows.append((key, vms[0] if vms else "-", problems))

print(f"{'HS':<7}{'PageKey':<28}{'K':<5}{'V':<5}{'X':<5}{'L':<5}{'T':<5}{'P':<5}Status")
bad = 0
for hs, key, pr in rows:
    flags = {c: ("ok" if not any(x.startswith(c + ":") for x in pr) else "FEHL") for c in "KVXLTP"}
    print(f"{hs:<7}{key:<28}" + "".join(f"{flags[c]:<5}" for c in "KVXLTP") + ("OK" if not pr else "FEHLER"))
    for x in pr:
        print("        ", x)
    bad += bool(pr)
print()
print(f"{'Dialog':<16}{'ViewModel':<32}{'V':<5}{'X':<5}{'L':<5}{'P':<5}Status")
for key, vm, pr in dialog_rows:
    flags = {c: ("ok" if not any(x.startswith(c + ":") for x in pr) else "FEHL") for c in "VXLP"}
    print(f"{key:<16}{vm:<32}" + "".join(f"{flags[c]:<5}" for c in "VXLP") + ("OK" if not pr else "FEHLER"))
    for x in pr:
        print("        ", x)
    bad += bool(pr)

glob = []
if len(register) != 43:
    glob.append(f"Seitenregister enthaelt {len(register)} statt 43 Seiten")
if len(pagekeys) != 43:
    glob.append(f"PageKeys.cs enthaelt {len(pagekeys)} statt 43 Schluessel")
if extra_vm:
    glob.append(f"[PageKey] auf Schluesseln ausserhalb des Registers: {sorted(extra_vm)}")
for g in glob:
    print("FEHLER:", g)
ok_pages = len([r for r in rows if not r[2]])
ok_dialogs = len([r for r in dialog_rows if not r[2]])
print(f"ERGEBNIS: {ok_pages}/{len(rows)} Seiten OK, {ok_dialogs}/{len(dialog_rows)} Dialoge OK" + ("" if not glob else f", {len(glob)} globale Fehler"))
sys.exit(1 if bad or glob else 0)
