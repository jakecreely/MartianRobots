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
            
            // if newPosition is out of the grid bounds
            // if has already been lost by robot - skip - dont assign position to robot
            // has not been lost then robot is lost and navigation ends
            // if it is valid position then update the robots position with the current one

            if (grid.IsOutOfBounds(newPosition) && !isLost)
            {
                if (!grid.HasAlreadyLostFromPosition(currentPosition))
                {
                    // Lost at current position on the grid
                    grid.AddLostPosition(currentPosition);  
                    isLost = true;
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