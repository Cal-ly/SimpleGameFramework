namespace SimpleGameLibrary.Core;
/// <summary>
/// Represents a position in a 2D space.
/// </summary>
public class Position(int posX, int posY)
{
    /// <summary>
    /// Gets or sets the X coordinate of the position.
    /// </summary>
    public int PosX { get; set; } = posX;

    /// <summary>
    /// Gets or sets the Y coordinate of the position.
    /// </summary>
    public int PosY { get; set; } = posY;
}
