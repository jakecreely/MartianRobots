using MartianRobots.Interfaces;

namespace MartianRobots.Models;

/// <summary>
/// Class representing a robot with its current position and methods to Turns and MoveForward
/// </summary>
public class Robot : IRobot
{
    public Position CurrentPosition { get; set; }

    /// <summary>
    /// Constructs the robot with a starting position
    /// </summary>
    /// <param name="startingPosition"></param>
    public Robot(Position startingPosition)
    {
        CurrentPosition = startingPosition;
    }

    /// <summary>
    /// Handles turning for this robot
    /// </summary>
    /// <param name="instruction">char instruction, should be L or R or F</param>
    /// <returns>The updated position</returns>
    public Position Turn(char instruction)
    {
        CurrentPosition = CurrentPosition.Turn(instruction);
        return CurrentPosition;
    }
 
    /// <summary>
    /// Handles moving the robot forward
    /// </summary>
    /// <returns>The updated position</returns>
    public Position MoveForward()
    {   
        CurrentPosition = CurrentPosition.MoveForward();
        return CurrentPosition;
    }
}