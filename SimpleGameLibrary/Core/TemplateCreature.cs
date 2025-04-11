using SimpleGameLibrary.Interfaces;
using SimpleGameLibrary.Logging;

namespace SimpleGameLibrary.Core;

/// <summary>
/// Represents a template for creatures in the game.
/// </summary>
public abstract class TemplateCreature(string name, int hitPoint, Position position) : ICreature
{
    private readonly List<INotifiable> _observers = [];

    /// <summary>
    /// Gets or sets the name of the creature.
    /// </summary>
    public string Name { get; set; } = name;

    /// <summary>
    /// Gets or sets the hit points of the creature.
    /// </summary>
    public int HitPoint { get; set; } = hitPoint;

    /// <summary>
    /// Gets or sets the position of the creature.
    /// </summary>
    public Position Position { get; set; } = position;

    /// <summary>
    /// Gets or sets the list of attack items the creature has.
    /// </summary>
    public List<IAttackItem> Attacks { get; set; } = [];

    /// <summary>
    /// Gets or sets the list of defense items the creature has.
    /// </summary>
    public List<IDefenseItem> Defenses { get; set; } = [];

    /// <summary>
    /// Gets or sets the attack strategy of the creature.
    /// </summary>
    public IAttackStrategy? AttackStrategy { get; set; }

    /// <summary>
    /// Gets a value indicating whether the creature is alive.
    /// </summary>
    public bool IsAlive => HitPoint > 0;

    /// <summary>
    /// Attaches an observer to the creature.
    /// </summary>
    /// <param name="observer">The observer to attach.</param>
    public void AttachObserver(INotifiable observer)
    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);
    }

    /// <summary>
    /// Detaches an observer from the creature.
    /// </summary>
    /// <param name="observer">The observer to detach.</param>
    public void DetachObserver(INotifiable observer)
    {
        _observers.Remove(observer);
    }

    /// <summary>
    /// Hits the specified target creature.
    /// </summary>
    /// <param name="target">The target creature to hit.</param>
    public virtual void Hit(ICreature target)
    {
        if (target == null)
        {
            GameLogger.Warn($"{Name} tried to hit a null target.");
            return;
        }

        if (!IsAlive)
        {
            GameLogger.Warn($"{Name} is dead and cannot attack.");
            return;
        }

        if (!target.IsAlive)
        {
            GameLogger.Warn($"{Name} tried to hit {target.Name}, but the target is already dead.");
            return;
        }

        if (AttackStrategy != null)
        {
            int damage = AttackStrategy.ExecuteAttack(this, target);
            target.RecieveHit(damage);
            return;
        }

        if (Attacks.Count == 0)
        {
            GameLogger.Warn($"{Name} tried to hit {target.Name} but has no attack items.");
            return;
        }

        var attack = Attacks.OrderByDescending(a => a.HitPower).First();
        if (!TargetIsWithinRange(target, attack))
        {
            GameLogger.Warn($"{Name} is too far away to hit {target.Name}.");
            return;
        }
        int totalHit = attack.ComputeHit(this);
        GameLogger.Info($"{Name} attacks {target.Name} using {attack.Name} for {totalHit} damage.");
        target.RecieveHit(totalHit);
    }

    /// <summary>
    /// Receives a hit with the specified damage.
    /// </summary>
    /// <param name="damage">The damage to receive.</param>
    public virtual void RecieveHit(int damage)
    {
        int reduced = Defenses.Sum(d => d.ReductionValue);
        int finalDamage = Math.Max(0, damage - reduced);
        HitPoint -= finalDamage;

        GameLogger.Info($"{Name} receives {damage} damage (reduced by {reduced}). Remaining HP: {HitPoint}");
        foreach (var observer in _observers)
        {
            observer.OnCreatureHit(this, finalDamage);
        }

        if (!IsAlive)
        {
            GameLogger.Warn($"{Name} has died.");
        }
    }

    /// <summary>
    /// Loots the specified world object.
    /// </summary>
    /// <param name="worldObject">The world object to loot.</param>
    public virtual void Loot(IWorldObject worldObject)
    {
        if (worldObject is not ILootable lootable)
        {
            GameLogger.Warn($"{Name} attempted to loot a non-lootable object at {worldObject.Position.PosX},{worldObject.Position.PosY}.");
            return;
        }

        if (!TargetIsWithinRange(worldObject))
        {
            GameLogger.Warn($"{Name} is too far away to loot {worldObject.Name}.");
            return;
        }

        lootable.LootedBy(this);
        GameLogger.Info($"{Name} looted object at {worldObject.Position.PosX},{worldObject.Position.PosY}.");
    }

    private int RangeToTarget(ICreature target)
    {
        int distanceX = Math.Abs(Position.PosX - target.Position.PosX);
        int distanceY = Math.Abs(Position.PosY - target.Position.PosY);
        return (int)Math.Floor(Math.Sqrt((distanceX ^ 2) + (distanceY ^ 2))); // truncate to int
    }

    private int RangeToTarget(IWorldObject target)
    {
        int distanceX = Math.Abs(Position.PosX - target.Position.PosX);
        int distanceY = Math.Abs(Position.PosY - target.Position.PosY);
        return (int)Math.Floor(Math.Sqrt((distanceX ^ 2) + (distanceY ^ 2))); // truncate to int
    }

    private bool TargetIsWithinRange(ICreature target, IAttackItem attack)
    {
        if (Attacks.Count == 0)
        {
            return false;
        }
        return RangeToTarget(target) <= attack.Range;
    }

    private bool TargetIsWithinRange(IWorldObject target)
    {
        return RangeToTarget(target) <= 1;
    }
}