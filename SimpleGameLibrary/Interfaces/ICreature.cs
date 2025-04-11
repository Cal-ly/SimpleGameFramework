using SimpleGameLibrary.Core;

namespace SimpleGameLibrary.Interfaces;
/// <summary>
/// Represents a creature in the game.
/// </summary>
public interface ICreature
{
    /// <summary>
    /// Gets or sets the name of the creature.
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// Gets or sets the hit points of the creature.
    /// </summary>
    int HitPoint { get; set; }

    /// <summary>
    /// Gets or sets the position of the creature.
    /// </summary>
    Position Position { get; set; }

    /// <summary>
    /// Gets or sets the list of attack items the creature has.
    /// </summary>
    List<IAttackItem> Attacks { get; set; }

    /// <summary>
    /// Gets or sets the list of defense items the creature has.
    /// </summary>
    List<IDefenseItem> Defenses { get; set; }

    /// <summary>
    /// Gets a value indicating whether the creature is alive.
    /// </summary>
    bool IsAlive { get; }

    /// <summary>
    /// Gets or sets the attack strategy of the creature.
    /// </summary>
    IAttackStrategy? AttackStrategy { get; set; }

    /// <summary>
    /// Hits the specified target creature.
    /// </summary>
    /// <param name="creature">The target creature to hit.</param>
    void Hit(ICreature creature);

    /// <summary>
    /// Receives a hit with the specified damage.
    /// </summary>
    /// <param name="damage">The damage to receive.</param>
    void RecieveHit(int damage);

    /// <summary>
    /// Loots the specified world object.
    /// </summary>
    /// <param name="worldObject">The world object to loot.</param>
    void Loot(IWorldObject worldObject);
}
