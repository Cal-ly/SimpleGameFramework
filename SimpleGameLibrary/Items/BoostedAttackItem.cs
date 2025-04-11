using SimpleGameLibrary.Interfaces;
using SimpleGameLibrary.Items.Decorators;
using SimpleGameLibrary.Logging;

namespace SimpleGameLibrary.Items;
/// <summary>
/// Represents an attack item that boosts its hit power when the user's hit points are below a certain threshold.
/// </summary>
public class BoostedAttackItem(IAttackItem innerItem) : AttackItemDecorator(innerItem)
{
    /// <summary>
    /// Computes the hit value when used by the specified creature.
    /// Boosts the hit power by 10 if the user's hit points are below 25.
    /// </summary>
    /// <param name="user">The creature using the attack item.</param>
    /// <returns>The computed hit value.</returns>
    public override int ComputeHit(ICreature user)
    {
        int baseHit = base.ComputeHit(user);
        if (user.HitPoint < 25)
        {
            GameLogger.Debug($"[Decorator] Boosted attack for {user.Name}, +10 hit power!");
            return baseHit + 10;
        }

        return baseHit;
    }
}
