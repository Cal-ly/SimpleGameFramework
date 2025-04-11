using SimpleGameLibrary.Attributes;
using SimpleGameLibrary.Interfaces;

namespace SimpleGameLibrary.Items.Basic;

/// <summary>
/// A basic shield that provides a small amount of damage reduction.
/// </summary>
[Creatable]
public class BasicShield : IDefenseItem
{
    public string Name { get; set; } = "Basic Shield";
    public int ReductionValue { get; set; } = 5;
}