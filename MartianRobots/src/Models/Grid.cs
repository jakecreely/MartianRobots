public class Grid
{
    public int Width { get; }
    public int Height { get; }
    public List<Position> LostPositions { get; }

    public Grid(int width, int height)
    {
        // Minimum size of grid is 1 by 1 and max is 50 by 50
        if (width < 1 || height < 1 || width > 50 || height > 50)
        {
            throw new ArgumentException("Grid coordinates must be between 1 and 50");
        }
        Width = width;
        Height = height;
        LostPositions = new List<Position>();
    }

    // Returns true if given position has caused a robot to be lost already
    public bool HasLostFromPosition(Position position)
    {
        return LostPositions.Any(lostPosition => 
            lostPosition.X == position.X && lostPosition.Y == position.Y && lostPosition.Orientation == position.Orientation
        );
    }

    public void AddLostPosition(Position position)
    {
        LostPositions.Add(position);
    }
}