namespace SimpleGameLibrary.Interfaces;

/// <summary>
/// Represents an item that can be used for defense.
/// </summary>
public interface IDefenseItem
{
    /// <summary>
    /// Gets or sets the name of the defense item.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the reduction value of the defense item.
    /// </summary>
    public int ReductionValue { get; set; }
}
