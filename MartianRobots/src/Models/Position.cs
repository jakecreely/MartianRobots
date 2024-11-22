using MartianRobots.Enums;

namespace MartianRobots.Models;

/// <summary>
/// Class for storing a robots position, it stores the X, Y and Orientation as well as
/// functionality for turning and moving forward
/// </summary>
public class Position
{
    public int X { get; }
    public int Y { get; }
    public Orientation Orientation { get; }

    /// <summary>
    /// Constructor for a position, which requires X, Y and Orientation
    /// </summary>
    /// <param name="x">X position on the grid</param>
    /// <param name="y">Y position on the grid</param>
    /// <param name="orientation">Direction the robot is facing</param>
    public Position(int x, int y, Orientation orientation)
    {
        X = x;
        Y = y;
        Orientation = orientation;
    }

    /// <summary>
    /// Returns the updated position based on the passed instruction
    /// </summary>
    /// <param name="instruction">A char which should be L, R or F</param>
    /// <returns>The updated position</returns>
    /// <exception cref="ArgumentException">If the given instruction is not valid</exception>
    public Position Turn(char instruction)
    {
        return instruction switch
        {
            'L' => Orientation switch
            {
                Orientation.North => new Position(X, Y, Orientation.West),
                Orientation.South => new Position(X, Y, Orientation.East),
                Orientation.East => new Position(X, Y, Orientation.North),
                Orientation.West => new Position(X, Y, Orientation.South),
                _ => throw new ArgumentException("Invalid orientation")
            },
            'R' => Orientation switch
            {
                Orientation.North => new Position(X, Y, Orientation.East),
                Orientation.South => new Position(X, Y, Orientation.West),
                Orientation.East => new Position(X, Y, Orientation.South),
                Orientation.West => new Position(X, Y, Orientation.North),
                _ => throw new ArgumentException("Invalid orientation")
            },
            _ => throw new ArgumentException("Invalid turn instruction")
        };
    }

    /// <summary>
    /// Returns the updated position based on the orientation the robot is currently facing
    /// </summary>
    /// <returns>The updated position</returns>
    /// <exception cref="ArgumentException">Orientation is not a valid enum</exception>
    public Position MoveForward()
    {
        return Orientation switch
        {
            Orientation.North => new Position(X, Y + 1, Orientation),
            Orientation.South => new Position(X, Y - 1, Orientation),
            Orientation.East => new Position(X + 1, Y, Orientation),
            Orientation.West => new Position(X - 1, Y, Orientation),
            _ => throw new ArgumentException("Invalid orientation")
        };
    }

    /// <summary>
    /// Returns the string in the format "X Y orientation"
    /// </summary>
    /// <returns>String</returns>
    public override String ToString()
    {
        char orientation = Orientation switch
        {
            Orientation.North => 'N',
            Orientation.South => 'S',
            Orientation.East => 'E',
            Orientation.West => 'W',
        };
        
        return "" + X + " " + Y + " " + orientation;
    }
    
}