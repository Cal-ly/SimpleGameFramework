using SimpleGameLibrary.Interfaces;
using SimpleGameLibrary.Logging;

namespace SimpleGameLibrary.Items.Composites;
/// <summary>
/// Represents a composite attack item that can contain multiple attack items.
/// </summary>
public class AttackItemComposite : IAttackItem
{
    /// <summary>
    /// Gets or sets the list of child attack items.
    /// </summary>
    public List<IAttackItem> Children { get; set; } = [];

    /// <summary>
    /// Gets or sets the name of the composite attack item.
    /// </summary>
    string IAttackItem.Name { get; set; } = "Composite Attack";

    /// <summary>
    /// Gets the total hit power of the composite attack item.
    /// </summary>
    /// <exception cref="NotSupportedException">Thrown when attempting to set the hit power.</exception>
    int IAttackItem.HitPower
    {
        get => Children.Sum(c => c.HitPower);
        set => throw new NotSupportedException("Cannot set HitPower on a composite item.");
    }

    /// <summary>
    /// Gets the maximum range of the composite attack item.
    /// </summary>
    /// <exception cref="NotSupportedException">Thrown when attempting to set the range.</exception>
    public int Range
    {
        get => Children.Max(c => c.Range);
        set => throw new NotSupportedException("Cannot set Range on a composite item.");
    }

    /// <summary>
    /// Computes the total hit value when used by the specified creature.
    /// </summary>
    /// <param name="user">The creature using the composite attack item.</param>
    /// <returns>The computed total hit value.</returns>
    int IAttackItem.ComputeHit(ICreature user)
    {
        int totalHit = Children.Sum(c => c.ComputeHit(user));
        GameLogger.Debug($"[Composite] Total hit from composite: {totalHit}");
        return totalHit;
    }

    /// <summary>
    /// Adds an attack item to the composite.
    /// </summary>
    /// <param name="item">The attack item to add.</param>
    public void Add(IAttackItem item)
    {
        Children.Add(item);
    }

    /// <summary>
    /// Removes an attack item from the composite.
    /// </summary>
    /// <param name="item">The attack item to remove.</param>
    public void Remove(IAttackItem item)
    {
        Children.Remove(item);
    }
}
