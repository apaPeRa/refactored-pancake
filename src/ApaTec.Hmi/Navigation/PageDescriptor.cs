using ApaTec.Hmi.Models;

namespace ApaTec.Hmi.Navigation;

/// <summary>
/// Beschreibung einer Seite (Navigation.md 5.2). Metadaten stammen aus <see cref="PageCatalog"/>,
/// <see cref="ViewModelType"/> wird von <see cref="PageRegistry"/> per Reflection ergaenzt (null = noch nicht umgesetzt).
/// </summary>
public sealed record PageDescriptor(
    string Key,
    string Route,
    string HsId,
    PageKind Kind,
    string? ParentKey,
    UserRole? MinimumRole,
    bool ShowFrame = true)
{
    /// <summary>ViewModel-Typ (mit <see cref="PageKeyAttribute"/>) oder null, solange die Seite fehlt.</summary>
    public Type? ViewModelType { get; init; }

    /// <summary>Ressourcenschluessel des Seitentitels, z. B. <c>Nav_HotGlueNordson_Title</c>.</summary>
    public string TitleResourceKey => $"Nav_{Key}_Title";

    /// <summary>Ressourcenschluessel des Brotkruemel-Segments, z. B. <c>Nav_HotGlueNordson_Crumb</c>.</summary>
    public string CrumbResourceKey => $"Nav_{Key}_Crumb";
}
