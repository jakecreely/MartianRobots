public interface IRobot
{
    Position CurrentPosition { get; }

    public void Turn(char instruction);
    public void MoveForward();
    
}