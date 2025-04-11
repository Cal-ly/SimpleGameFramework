namespace SimpleGameLibrary.Interfaces;

/// <summary>
/// Represents an item that can be used to attack.
/// </summary>
public interface IAttackItem
{
    /// <summary>
    /// Gets or sets the name of the attack item.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the hit power of the attack item.
    /// </summary>
    public int HitPower { get; set; }

    /// <summary>
    /// Gets or sets the range of the attack item.
    /// </summary>
    public int Range { get; set; }

    /// <summary>
    /// Computes the hit value when used by the specified creature.
    /// </summary>
    /// <param name="user">The creature using the attack item.</param>
    /// <returns>The computed hit value.</returns>
    public int ComputeHit(ICreature user);
}
