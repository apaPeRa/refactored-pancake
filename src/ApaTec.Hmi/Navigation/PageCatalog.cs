using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Navigation;

/// <summary>
/// Statische Metadaten aller 43 Seiten (Navigation.md 5.1): Route, Elternschluessel, Art, Mindestrolle.
/// Die zugehoerigen ViewModels melden sich per <see cref="PageKeyAttribute"/> an und werden von <see cref="PageRegistry"/> per Reflection gefunden;
/// diese Datei wird dafuer nicht bearbeitet.
/// </summary>
internal static class PageCatalog
{
    public static IReadOnlyList<PageDescriptor> All { get; } = new PageDescriptor[]
    {
        new(PageKeys.Production, "production", "HS-01", PageKind.Page, null, null, true),
        new(PageKeys.ProductionCounter, "production/counter", "HS-02", PageKind.Popup, PageKeys.Production, null, true),
        new(PageKeys.MachineSpeed, "production/speed", "HS-03", PageKind.Popup, PageKeys.Production, null, true),
        new(PageKeys.Settings, "settings", "HS-04", PageKind.Page, null, null, true),
        new(PageKeys.FeederPaper, "settings/feeders/paper", "HS-05", PageKind.Page, PageKeys.Feeders, null, true),
        new(PageKeys.FeederCarton, "settings/feeders/carton", "HS-06", PageKind.Page, PageKeys.Feeders, null, true),
        new(PageKeys.HotGlueNordson, "settings/feeders/hotglue", "HS-07", PageKind.Page, PageKeys.Feeders, null, true),
        new(PageKeys.HotGlueParameters, "settings/feeders/hotglue/parameters", "HS-08", PageKind.Page, PageKeys.HotGlueNordson, null, true),
        new(PageKeys.HotGluePressure, "settings/feeders/hotglue/pressure", "HS-09", PageKind.Page, PageKeys.HotGlueNordson, null, true),
        new(PageKeys.HotGlueSchedule, "settings/feeders/hotglue/schedule", "HS-10", PageKind.Page, PageKeys.HotGlueNordson, null, true),
        new(PageKeys.MainDosers, "settings/dosers/main", "HS-11", PageKind.Page, PageKeys.DoserOverview, null, true),
        new(PageKeys.MainDoserMotor, "settings/dosers/main/motor", "HS-12", PageKind.Page, PageKeys.MainDosers, null, true),
        new(PageKeys.CheckWeigher, "settings/scales/check", "HS-13", PageKind.Page, PageKeys.Scales, null, true),
        new(PageKeys.SingleWeights, "settings/scales/check/weights", "HS-14", PageKind.Page, PageKeys.CheckWeigher, null, true),
        new(PageKeys.Trend, "settings/scales/check/trend", "HS-15", PageKind.Page, PageKeys.CheckWeigher, null, true),
        new(PageKeys.ClosingMachine, "settings/closing", "HS-16", PageKind.Page, PageKeys.Settings, null, true),
        new(PageKeys.ClosingMotor, "settings/closing/motor", "HS-17", PageKind.Page, PageKeys.ClosingMachine, null, true),
        new(PageKeys.ClosingWeightCorrection, "settings/closing/weightcorrection", "HS-18", PageKind.Page, PageKeys.ClosingMachine, null, true),
        new(PageKeys.PostDoser, "settings/dosers/post", "HS-19", PageKind.Page, PageKeys.DoserOverview, null, true),
        new(PageKeys.PostDoserMotor, "settings/dosers/post/motor", "HS-20", PageKind.Page, PageKeys.PostDoser, null, true),
        new(PageKeys.PostDoserWeightCorrection, "settings/dosers/post/weightcorrection", "HS-21", PageKind.Page, PageKeys.PostDoser, null, true),
        new(PageKeys.Heaters, "settings/heaters", "HS-22", PageKind.Page, PageKeys.Settings, null, true),
        new(PageKeys.Regulation, "settings/regulation", "HS-23", PageKind.Page, PageKeys.Settings, null, true),
        new(PageKeys.ScreenCleaning, "settings/screencleaning", "HS-24", PageKind.Fullscreen, PageKeys.Settings, null, false),
        new(PageKeys.Cams, "settings/cams", "HS-25", PageKind.Page, PageKeys.Settings, null, true),
        new(PageKeys.CamOverview, "settings/cams/overview", "HS-26", PageKind.Page, PageKeys.Cams, null, true),
        new(PageKeys.ScaleCalibration, "settings/scales/calibration", "HS-27", PageKind.Page, PageKeys.Scales, null, true),
        new(PageKeys.PackRegister, "settings/packregister", "HS-28", PageKind.Page, PageKeys.Settings, null, true),
        new(PageKeys.ProductionStatistics, "settings/statistics", "HS-29", PageKind.Page, PageKeys.Settings, null, true),
        new(PageKeys.ManualSelection, "settings/manual", "HS-30", PageKind.Page, PageKeys.Settings, null, true),
        new(PageKeys.ManualOperation, "settings/manual/group", "HS-31", PageKind.Page, PageKeys.ManualSelection, null, true),
        new(PageKeys.EncoderSetting, "settings/encoders", "HS-32", PageKind.Page, PageKeys.Settings, null, true),
        new(PageKeys.IoOverview, "settings/io", "HS-33", PageKind.Page, PageKeys.Settings, null, true),
        new(PageKeys.IoDisplay, "settings/io/card", "HS-34", PageKind.Page, PageKeys.IoOverview, null, true),
        new(PageKeys.SystemSettings, "settings/system", "HS-35", PageKind.Page, PageKeys.Settings, null, true),
        new(PageKeys.Service, "settings/system/service", "HS-36", PageKind.Page, PageKeys.SystemSettings, UserRole.Technician, true),
        new(PageKeys.MessageArchive, "settings/system/archive", "HS-37", PageKind.Page, PageKeys.SystemSettings, null, true),
        new(PageKeys.MessageView, "messages", "HS-38", PageKind.Page, null, null, true),
        new(PageKeys.SystemInfo, "settings/system/info", "HS-39", PageKind.Page, PageKeys.SystemSettings, null, true),
        new(PageKeys.Feeders, "settings/feeders", "HS-40", PageKind.Page, PageKeys.Settings, null, true),
        new(PageKeys.DoserOverview, "settings/dosers", "HS-41", PageKind.Page, PageKeys.Settings, null, true),
        new(PageKeys.Scales, "settings/scales", "HS-42", PageKind.Page, PageKeys.Settings, null, true),
        new(PageKeys.ShiftPlan, "production/shiftplan", "HS-43", PageKind.Page, PageKeys.Production, null, true),
    };
}
