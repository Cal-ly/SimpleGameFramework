using SimpleGameLibrary.Attributes;
using SimpleGameLibrary.Interfaces;

namespace SimpleGameLibrary.Items.Basic;

/// <summary>
/// A basic sword with moderate hit power and low range.
/// </summary>
[Creatable]
public class BasicSword : IAttackItem
{
    public string Name { get; set; } = "Basic Sword";
    public int HitPower { get; set; } = 15;
    public int Range { get; set; } = 2;

    public int ComputeHit(ICreature user)
    {
        return HitPower;
    }
}