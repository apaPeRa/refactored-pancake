namespace ApaTec.Hmi.Services;

/// <summary>
/// Markiert eine Dummy-Implementierung (Beispieldaten, keine Maschinenanbindung; A-75, A-77).
/// <see cref="ServiceCollectionExtensions.AddApaTecHmi"/> registriert jede so markierte Klasse (oder Klassen mit Namen <c>*Dummy*Service</c>)
/// als Singleton fuer alle von ihr implementierten Schnittstellen aus dieser Assembly.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public sealed class DummyServiceAttribute : Attribute
{
}
