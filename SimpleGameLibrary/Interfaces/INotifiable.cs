namespace SimpleGameLibrary.Interfaces;

/// <summary>
/// Represents an interface for objects that can be notified of creature events.
/// </summary>
public interface INotifiable
{
    /// <summary>
    /// Called when a creature dies.
    /// </summary>
    /// <param name="creature">The creature that died.</param>
    void OnCreatureDied(ICreature creature);

    /// <summary>
    /// Called when a creature is hit.
    /// </summary>
    /// <param name="creature">The creature that was hit.</param>
    /// <param name="damage">The amount of damage received.</param>
    void OnCreatureHit(ICreature creature, int damage);
}
