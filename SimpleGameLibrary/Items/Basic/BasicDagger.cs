using SimpleGameLibrary.Attributes;
using SimpleGameLibrary.Interfaces;

namespace SimpleGameLibrary.Items.Basic;

/// <summary>
/// A lightweight dagger with lower hit power but higher range than expected.
/// </summary>
[Creatable]
public class BasicDagger : IAttackItem
{
    public string Name { get; set; } = "Basic Dagger";
    public int HitPower { get; set; } = 8;
    public int Range { get; set; } = 2;

    public int ComputeHit(ICreature user)
    {
        return HitPower;
    }
}
