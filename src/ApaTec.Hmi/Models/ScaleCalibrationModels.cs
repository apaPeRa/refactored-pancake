namespace ApaTec.Hmi.Models;

/// <summary>Schritt des Kalibriervorgangs, den die Steuerung meldet (HS-27, Annahme K27-3).</summary>
public enum CalibrationStep
{
    /// <summary>Kein Vorgang aktiv.</summary>
    Idle,

    /// <summary>Gestartet; die Steuerung fordert "Entlastet" (Handbuch Schritt 3).</summary>
    AwaitUnloaded,

    /// <summary>Entlastet quittiert; die Steuerung fordert das Kalibriergewicht und "Belastet" (Schritt 4).</summary>
    AwaitLoaded,

    /// <summary>Kalibrierung erfolgreich abgeschlossen, Bestaetigung steht an (Schritt 5).</summary>
    Completed,
}

/// <summary>Ergebnis eines Schreibbefehls an die Waage.</summary>
public enum ScaleOperationResult
{
    Success,

    /// <summary>Filterwerte konnten nicht geschrieben werden (Bildtext "Fehler beim schreiben der Filterwerte").</summary>
    FilterWriteFailed,

    /// <summary>Waage gestoert oder nicht erreichbar.</summary>
    ScaleFault,

    /// <summary>Befehl im aktuellen Schritt nicht zulaessig.</summary>
    NotAllowed,
}

/// <summary>Momentaufnahme einer Waage fuer HS-27.</summary>
/// <param name="Index">Nullbasierter Index der verbauten Waage.</param>
/// <param name="Name">Betriebsmittelkennzeichen und Bezeichnung, z. B. "16KW1 Kontrollwaage".</param>
/// <param name="Weight">Livegewicht in g; null = ungueltig ("---").</param>
/// <param name="WrittenFilterIndex">Index des aktuell in die Waage geschriebenen Filters.</param>
/// <param name="Step">Aktueller Schritt der Kalibrierung.</param>
/// <param name="IsFaulted">true bei Ausfall der Waage.</param>
public sealed record ScaleSnapshot(int Index, string Name, double? Weight, int WrittenFilterIndex, CalibrationStep Step, bool IsFaulted);
