using SimpleGameLibrary.Interfaces;
using SimpleGameLibrary.Logging;

namespace SimpleGameLibrary.Strategies;
/// <summary>
/// Represents a strategy for executing a random attack.
/// </summary>
public class RandomAttackStrategy : IAttackStrategy
{
    private static readonly Random _random = new();

    /// <summary>
    /// Executes a random attack from the attacker to the target.
    /// </summary>
    /// <param name="attacker">The creature performing the attack.</param>
    /// <param name="target">The creature being attacked.</param>
    /// <returns>The amount of damage dealt to the target.</returns>
    public int ExecuteAttack(ICreature attacker, ICreature target)
    {
        if (attacker.Attacks.Count == 0)
        {
            GameLogger.Warn($"{attacker.Name} has no attack items.");
            return 0;
        }

        var chosen = attacker.Attacks[_random.Next(attacker.Attacks.Count)];
        int damage = chosen.ComputeHit(attacker);
        GameLogger.Info($"{attacker.Name} randomly uses {chosen.Name} on {target.Name} for {damage} damage.");
        return damage;
    }
}
