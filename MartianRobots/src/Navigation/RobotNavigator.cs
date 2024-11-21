public class RobotNavigator
{
    public void Navigate(Grid grid, Robot robot, string instructions)
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
                if (!grid.HasAlreadyLostFromPosition(newPosition))
                {
                    currentPosition = newPosition;
                    robot.CurrentPosition = newPosition;
                    isLost = true;
                    grid.AddLostPosition(newPosition);  
                };
            }
            else
            {
                currentPosition = newPosition;
                robot.CurrentPosition = newPosition;
            }
        }
    }
}