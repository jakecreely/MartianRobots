using MartianRobots.Models;

namespace MartianRobots.Navigation;

/// <summary>
/// Navigates a given robot along a grid using a string of instructions
/// </summary>
public class RobotNavigator
{
    /// <summary>
    /// Moves the passed robot along the passed grid based on the passed instructions
    /// </summary>
    /// <param name="grid">The grid to navigate around</param>
    /// <param name="robot">The robot to navigate</param>
    /// <param name="instructions">A string of instructions to process</param>
    /// <returns>The position the robot ended in and whether it got lost or not</returns>
    /// <exception cref="ArgumentException">Throws exception if an instruction is invalid</exception>
    public (Position finalPosition, bool isLost) Navigate(Grid grid, Robot robot, string instructions)
    {
        
        Position currentPosition = robot.CurrentPosition;
        bool isLost = false;

        foreach (char instruction in instructions)
        {
            Position newPosition = instruction switch
            {
                'L' or 'R' => currentPosition.Turn(instruction),
                'F' => currentPosition.MoveForward(),
                _ => throw new ArgumentException("Invalid instruction")
            };

            if (grid.IsOutOfBounds(newPosition) && !isLost)
            {
                if (!isLost && !grid.HasAlreadyLostFromPosition(currentPosition))
                {
                    grid.AddLostPosition(currentPosition);
                    isLost = true;

                    // Moves to out of bounds only the first time
                    currentPosition = newPosition;
                    robot.CurrentPosition = newPosition;
                }
            }
            else
            {
                currentPosition = newPosition;
                robot.CurrentPosition = newPosition;
            }
        }
        
        return (currentPosition, isLost);
    }
}