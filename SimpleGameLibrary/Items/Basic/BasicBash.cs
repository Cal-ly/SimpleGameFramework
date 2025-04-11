using SimpleGameLibrary.Attributes;
using SimpleGameLibrary.Interfaces;

namespace SimpleGameLibrary.Items.Basic;
[Creatable]
public class BasicBash : IAttackItem
{
    public string Name { get; set; } = "Basic Bash";
    public int HitPower { get; set; } = 1;
    public int Range { get; set; } = 1;
    public int ComputeHit(ICreature user)
    {
        return HitPower;
    }
}