namespace ApaTec.Hmi.Navigation;

/// <summary>Segment des Brotkruemel-Pfads (HM-04). Das letzte Segment ist <c>IsCurrent</c> und nicht navigierbar.</summary>
public sealed record BreadcrumbItem(string Key, string DisplayText, bool IsCurrent, bool IsNavigable);
