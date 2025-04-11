namespace SimpleGameLibrary.Attributes;

/// <summary>
/// Indicates that a class can be instantiated via reflection in GameFactory.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class CreatableAttribute : Attribute
{
}