public class Robot : IRobot
{
    public Position CurrentPosition { get; set; }

    public Robot(Position startingPosition)
    {
        CurrentPosition = startingPosition;
    }

    public Position Turn(char instruction)
    {
        CurrentPosition = CurrentPosition.Turn(instruction);
        return CurrentPosition;
    }

    public Position MoveForward()
    {   
        CurrentPosition = CurrentPosition.MoveForward();
        return CurrentPosition;
    }
}