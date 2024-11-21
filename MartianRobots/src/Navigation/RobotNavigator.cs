public class RobotNavigator
{
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