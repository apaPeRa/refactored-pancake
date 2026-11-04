namespace ApaTec.Hmi.Navigation;

/// <summary>
/// Seitenschluessel (PageKey) aller 43 Seiten HS-01 bis HS-43 nach Navigation.md 5.1.
/// Konstanten sind die Bezeichner fuer <see cref="PageKeyAttribute"/>, <see cref="INavigationService.NavigateToAsync"/> und Tests.
/// Nicht aendern: Schluessel, Reihenfolge und Werte sind durch das Konzept festgelegt.
/// </summary>
public static class PageKeys
{
    /// <summary>Startseite der Anwendung (Pfad HS-01).</summary>
    public const string Start = Production;

    /// <summary>HS-01 Produktion.</summary>
    public const string Production = "Production";
    /// <summary>HS-02 Produktionszähler.</summary>
    public const string ProductionCounter = "ProductionCounter";
    /// <summary>HS-03 Maschinengeschwindigkeit.</summary>
    public const string MachineSpeed = "MachineSpeed";
    /// <summary>HS-04 Einstellungen.</summary>
    public const string Settings = "Settings";
    /// <summary>HS-05 Zuführung Papier.</summary>
    public const string FeederPaper = "FeederPaper";
    /// <summary>HS-06 Zuführung Karton.</summary>
    public const string FeederCarton = "FeederCarton";
    /// <summary>HS-07 Heißleim Nordson.</summary>
    public const string HotGlueNordson = "HotGlueNordson";
    /// <summary>HS-08 Heißleim Parameter.</summary>
    public const string HotGlueParameters = "HotGlueParameters";
    /// <summary>HS-09 Heißleim Druck.</summary>
    public const string HotGluePressure = "HotGluePressure";
    /// <summary>HS-10 Zeitschaltuhr.</summary>
    public const string HotGlueSchedule = "HotGlueSchedule";
    /// <summary>HS-11 Hauptdosierer 1 &amp; 2.</summary>
    public const string MainDosers = "MainDosers";
    /// <summary>HS-12 Motorparameter.</summary>
    public const string MainDoserMotor = "MainDoserMotor";
    /// <summary>HS-13 Kontrollwaage.</summary>
    public const string CheckWeigher = "CheckWeigher";
    /// <summary>HS-14 Einzelgewichte.</summary>
    public const string SingleWeights = "SingleWeights";
    /// <summary>HS-15 Trend.</summary>
    public const string Trend = "Trend";
    /// <summary>HS-16 Schließmaschine.</summary>
    public const string ClosingMachine = "ClosingMachine";
    /// <summary>HS-17 Motorparameter Schließmaschine.</summary>
    public const string ClosingMotor = "ClosingMotor";
    /// <summary>HS-18 Gewichtskorrektur Schließmaschine.</summary>
    public const string ClosingWeightCorrection = "ClosingWeightCorrection";
    /// <summary>HS-19 Nachdosierer.</summary>
    public const string PostDoser = "PostDoser";
    /// <summary>HS-20 Motorparameter.</summary>
    public const string PostDoserMotor = "PostDoserMotor";
    /// <summary>HS-21 Gewichtskorrektur.</summary>
    public const string PostDoserWeightCorrection = "PostDoserWeightCorrection";
    /// <summary>HS-22 Heizungen.</summary>
    public const string Heaters = "Heaters";
    /// <summary>HS-23 Regulierung.</summary>
    public const string Regulation = "Regulation";
    /// <summary>HS-24 Bildschirm reinigen.</summary>
    public const string ScreenCleaning = "ScreenCleaning";
    /// <summary>HS-25 Nocken.</summary>
    public const string Cams = "Cams";
    /// <summary>HS-26 Nockenübersicht.</summary>
    public const string CamOverview = "CamOverview";
    /// <summary>HS-27 Waagen Kalibrieren.</summary>
    public const string ScaleCalibration = "ScaleCalibration";
    /// <summary>HS-28 Packungsregister.</summary>
    public const string PackRegister = "PackRegister";
    /// <summary>HS-29 Produktionsstatistik.</summary>
    public const string ProductionStatistics = "ProductionStatistics";
    /// <summary>HS-30 Handbetrieb Auswahl.</summary>
    public const string ManualSelection = "ManualSelection";
    /// <summary>HS-31 Handbetrieb.</summary>
    public const string ManualOperation = "ManualOperation";
    /// <summary>HS-32 Geber setzen.</summary>
    public const string EncoderSetting = "EncoderSetting";
    /// <summary>HS-33 EA-Übersicht.</summary>
    public const string IoOverview = "IoOverview";
    /// <summary>HS-34 EA-Anzeige.</summary>
    public const string IoDisplay = "IoDisplay";
    /// <summary>HS-35 Systemeinstellungen.</summary>
    public const string SystemSettings = "SystemSettings";
    /// <summary>HS-36 Service.</summary>
    public const string Service = "Service";
    /// <summary>HS-37 Meldearchiv.</summary>
    public const string MessageArchive = "MessageArchive";
    /// <summary>HS-38 Meldeanzeige.</summary>
    public const string MessageView = "MessageView";
    /// <summary>HS-39 System- und Antriebsinfos.</summary>
    public const string SystemInfo = "SystemInfo";
    /// <summary>HS-40 Zuführungen.</summary>
    public const string Feeders = "Feeders";
    /// <summary>HS-41 Dosierer-Übersicht.</summary>
    public const string DoserOverview = "DoserOverview";
    /// <summary>HS-42 Waagen.</summary>
    public const string Scales = "Scales";
    /// <summary>HS-43 Schichtplan.</summary>
    public const string ShiftPlan = "ShiftPlan";
}
