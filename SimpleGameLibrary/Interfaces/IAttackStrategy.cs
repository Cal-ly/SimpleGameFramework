namespace SimpleGameLibrary.Interfaces;
/// <summary>
/// Defines a strategy for executing an attack.
/// </summary>
public interface IAttackStrategy
{
    /// <summary>
    /// Executes an attack from the attacker to the target.
    /// </summary>
    /// <param name="attacker">The creature performing the attack.</param>
    /// <param name="target">The creature being attacked.</param>
    /// <returns>The amount of damage dealt to the target.</returns>
    int ExecuteAttack(ICreature attacker, ICreature target);
}
