namespace MartianRobots.Models;

/// <summary>
/// Class representing a grid with a width and height
/// </summary>
public class Grid
{
    public int Width { get; }
    public int Height { get; }
    public List<Position> LostPositions { get; }

    /// <summary>
    /// Constructor for grid, requiring a width and height to be passed as parameters
    /// </summary>
    /// <param name="width">Width along the X axis. Must be between 1 and 50. </param>
    /// <param name="height">Height along the Y axis. Must be between 1 and 50.</param>
    /// <exception cref="ArgumentException">If width and/or height are less than 1 or above 50</exception>
    public Grid(int width, int height)
    {
        if (width < 1 || height < 1 || width > 50 || height > 50)
        {
            throw new ArgumentException("Width and height must be between 1 and 50");
        }
        Width = width;
        Height = height;
        LostPositions = new List<Position>();
    }

    /// <summary>
    /// Checks whether the given position is out of bounds of the grid
    /// </summary>
    /// <param name="position">Position to check if out of bounds</param>
    /// <returns>True if position is out of bounds</returns>
    public bool IsOutOfBounds(Position position)
    {
        return (position.X < 0 || position.Y < 0 || position.X > Width || position.Y > Height);
    }
    
    /// <summary>
    /// Checks whether the given position has already caused a robot to be lost
    /// </summary>
    /// <param name="position">Position to check</param>
    /// <returns>True if robot has been lost from position</returns>
    public bool HasAlreadyLostFromPosition(Position position)
    {
        return LostPositions.Any(lostPosition => 
            lostPosition.X == position.X && lostPosition.Y == position.Y
        );
    }

    /// <summary>
    /// Add a position to the list of lost position on the grid
    /// </summary>
    /// <param name="position">Lost position to add</param>
    public void AddLostPosition(Position position)
    {
        LostPositions.Add(position);
    }
}