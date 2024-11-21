public class Position
{
    public int X { get; }
    public int Y { get; }
    public Orientation Orientation { get; }

    public Position(int x, int y, Orientation orientation)
    {
        X = x;
        Y = y;
        Orientation = orientation;
    }

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
    
}