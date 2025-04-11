using SimpleGameLibrary.Interfaces;

namespace SimpleGameLibrary.Items.Decorators;
/// <summary>
/// Represents a decorator for attack items.
/// </summary>
public abstract class AttackItemDecorator(IAttackItem innerItem) : IAttackItem
{
    /// <summary>
    /// The inner attack item being decorated.
    /// </summary>
    protected readonly IAttackItem InnerItem = innerItem;

    /// <summary>
    /// Gets or sets the name of the attack item.
    /// </summary>
    public virtual string Name
    {
        get => InnerItem.Name;
        set => InnerItem.Name = value;
    }

    /// <summary>
    /// Gets or sets the hit power of the attack item.
    /// </summary>
    public virtual int HitPower
    {
        get => InnerItem.HitPower;
        set => InnerItem.HitPower = value;
    }

    /// <summary>
    /// Gets or sets the range of the attack item.
    /// </summary>
    public virtual int Range
    {
        get => InnerItem.Range;
        set => InnerItem.Range = value;
    }

    /// <summary>
    /// Computes the hit value when used by the specified creature.
    /// </summary>
    /// <param name="user">The creature using the attack item.</param>
    /// <returns>The computed hit value.</returns>
    public virtual int ComputeHit(ICreature user) => InnerItem.ComputeHit(user);
}
