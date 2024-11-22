using MartianRobots.Models;

namespace MartianRobots.Interfaces;

public interface IRobot
{
    Position CurrentPosition { get; }

    public Position Turn(char instruction);
    public Position MoveForward();
    
}