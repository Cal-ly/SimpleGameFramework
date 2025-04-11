using SimpleGameLibrary.Interfaces;
using SimpleGameLibrary.Logging;

namespace SimpleGameLibrary.Strategies;
/// <summary>
/// Represents a strategy for executing the strongest attack.
/// </summary>
public class StrongestAttackStrategy : IAttackStrategy
{
    /// <summary>
    /// Executes the strongest attack from the attacker to the target.
    /// </summary>
    /// <param name="attacker">The creature performing the attack.</param>
    /// <param name="target">The creature being attacked.</param>
    /// <returns>The amount of damage dealt to the target.</returns>
    public int ExecuteAttack(ICreature attacker, ICreature target)
    {
        var best = attacker.Attacks.OrderByDescending(a => a.ComputeHit(attacker)).FirstOrDefault();
        if (best == null)
        {
            GameLogger.Warn($"{attacker.Name} has no attack items.");
            return 0;
        }

        int damage = best.ComputeHit(attacker);
        GameLogger.Info($"{attacker.Name} uses {best.Name} (strongest) on {target.Name} for {damage} damage.");
        return damage;
    }
}
