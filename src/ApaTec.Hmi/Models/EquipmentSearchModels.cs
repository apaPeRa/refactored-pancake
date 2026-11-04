using ApaTec.Hmi.Controls;

namespace ApaTec.Hmi.Models;

/// <summary>
/// Suchbares Betriebsmittel (HM-38). Aktoren: <paramref name="GroupId"/> = groupId (GRxx), <paramref name="ItemId"/> = actorId.
/// EA-Kanaele: <paramref name="GroupId"/> = cardGroup, <paramref name="ItemId"/> = Kartenkennung, <paramref name="ItemIndex"/> = cardIndex.
/// </summary>
public sealed record EquipmentEntry(string Identifier, string Description, string GroupId, string ItemId, int ItemIndex);

/// <summary>Parameter des Such-Pop-ups (<c>DialogKeys.Search</c>); Ergebnis ist der gewaehlte <see cref="SearchHit"/>, dessen <c>TargetKey</c> das <see cref="EquipmentEntry"/> traegt.</summary>
public sealed record SearchRequest(string Title, string Placeholder, IReadOnlyList<SearchHit> Items);
