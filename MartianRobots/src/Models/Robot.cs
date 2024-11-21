public class Robot : IRobot
{
    public Position CurrentPosition { get; private set; }

    public Robot(Position startingPosition)
    {
        CurrentPosition = startingPosition;
    }

    public void Turn(char instruction)
    {
        CurrentPosition = CurrentPosition.Turn(instruction);
    }

    public void MoveForward()
    {   
        CurrentPosition = CurrentPosition.MoveForward();
    }
}