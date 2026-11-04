namespace ApaTec.Hmi.Models;

/// <summary>Benutzerrollen (Dummy, A-41). Reihenfolge: Operator &lt; Technician &lt; Service.</summary>
public enum UserRole
{
    Operator = 0,
    Technician = 1,
    Service = 2,
}
